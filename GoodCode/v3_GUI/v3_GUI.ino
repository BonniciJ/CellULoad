#include <HX711_ADC.h>
#include <Stepper.h>


void(* resetFunc) (void) = 0;


// initialize the stepper library on pins 8 through 11:
const int stepsPerRevolution = 2048;  // resolution of motor
Stepper myStepper(stepsPerRevolution, 8, 10, 9, 11);


//pins:
const int HX711_dout = 4; //mcu > HX711 dout pin
const int HX711_sck = 3; //mcu > HX711 sck pin

//HX711 constructor:
HX711_ADC LoadCell(HX711_dout, HX711_sck);

unsigned long t = 0;


float targetF = 10;   //target force
float displacement = 0; //current displacement

void setup() {


  Serial.begin(57600); delay(10); //start the serial port on a baud rate the load cell can understand


  // set the speed at 5 rpm:
  myStepper.setSpeed(5);

  //Set up the load cell

  LoadCell.begin();
  //LoadCell.setReverseOutput(); //uncomment to turn a negative output value to positive
  float calibrationValue; // calibration value (see example file "Calibration.ino")
  calibrationValue = -43311.62; // uncomment this if you want to set the calibration value in the sketch

  unsigned long stabilizingtime = 2000; // preciscion right after power-up can be improved by adding a few seconds of stabilizing time
  boolean _tare = true; //set this to false if you don't want tare to be performed in the next step
  LoadCell.start(stabilizingtime, _tare);
  if (LoadCell.getTareTimeoutFlag()) {
    Serial.println("Timeout, check MCU>HX711 wiring and pin designations");
    while (1);
  }
  else {
    LoadCell.setCalFactor(calibrationValue); // set calibration value (float)
    //Serial.println("Startup is complete");
  }

  initialise();


}

int plotCount = 0;

float timePermm = 2; //in mins
float movementRemaining = 0;
int direction = 1; 
bool decomp = 0;
float maxCompression = 2.5; //measured in mm. Maximum compression 


bool halted = 1;
bool atMaxCompress = 0;


void loop() {
  

  if (halted) {
    delay(50);
    float force = measure();
  } else {

    if (displacement >= maxCompression && !decomp) {
      // Do not carry on compressing if we are at the max compression
      atMaxCompress = 1;
    }

    if (atMaxCompress) {
      delay(50);
      if (displacement < maxCompression | decomp) {
        atMaxCompress = 0;
      }
      float force = measure();
    } else {
      //if we arent at max compression and we arent halted:
      
      float force = measure();

      if (force != -1000) {  //if there is a force measurement

        if (decomp) {
          //decompressing - this part is rough, needs improvement

          delay(50);
          float step;
          float error = targetF - force;
          step = 0.001 * (error); 
          float trueStep = move(step);      
        } else {
          //compressing
          doCompression(force);
        
        }
        
      } else {
        delay(50);
      }
    }
    
  }

  listenToSerial(); 
  
}

void doCompression(float force) {
  float padding = 0.1; //how close is close enough force. allows the motor to jitter back and forth less
  float stepSize = 0.001;
  float trueStep;
  if ((targetF - force) > padding) {
    // we need to compress
    trueStep = move(stepSize);

  } else if ((targetF - force) < -padding) {
    // we need to DEcompress
    trueStep = move(-stepSize);

  }

  //delay to ensure slow compression at specified rate 
  int timeDelay = timePermm*60000*trueStep; //time to do one step
  timeDelay -= trueStep * 7.5 * 1000;    //correct for the time it takes to turn the motor
  delay(timeDelay);  

}


float prevError = 0;
String incoming; //used for incoming messages - might be bad to use string??
bool isReading = 0;

void listenToSerial(){


  if (Serial.available() > 0) {
    char inByte = Serial.read();


    if (inByte == 'H') halted = true;  
    if (inByte == 'X') halted = false;  
    if (inByte == 'Y') decomp = true; 
    if (inByte == 'K') decomp = false; 
    if (inByte == '_') resetFunc();              //compress

    if (inByte == '~') { //stop reading
      isReading = 0;
      
      // used for setting new force and deformation limits, and the rate
      if (incoming.substring(0, 3) == "FOR") {
        targetF = incoming.substring(3, incoming.length()).toFloat();
      }
      if (incoming.substring(0, 3) == "DEF") {
        maxCompression = incoming.substring(3, incoming.length()).toFloat();
      }
      if (incoming.substring(0, 3) == "RAT") {
        timePermm = incoming.substring(3, incoming.length()).toFloat();
      }

      // //used to change mode 
      // if (incoming.substring(0, 6) == "DECOMP") { //decompression mode (i.e. fast rate)
      //   decomp = 1;
      // }
      // if (incoming.substring(0, 4) == "COMP") { //compression mode (i.e. constant, low rate)
      //   decomp = 0;
      // }

    } else if (inByte == '#') { //start reading
      isReading = 1;
      incoming = "";
    } else if (isReading) { //read
      incoming.concat(inByte);
    }
  }
}



float measure() {

  float measurement = -1000;

  static boolean newDataReady = 0;
  const int serialPrintInterval = 10; //increase value to slow down serial print activity

  // check for new data/start next conversion:
  if (LoadCell.update()) newDataReady = true;

  // get smoothed value from the dataset:
  if (newDataReady) {
    float i;
    
    i = LoadCell.getData();
    newDataReady = 0;

    measurement = i;


    //Plot force
    if (plotCount = 1000 && i != -1000) {
      Serial.println("DATA: ," + String(i) + "," + String(targetF) + "," + String(displacement) + "," + String(maxCompression) + "," + String(timePermm));
      plotCount = 0;
    } else {
      plotCount++;
    }

  }

  return measurement;


}

float move(float dist) {
  //postive values compress
  //dist is measured in mm
  float pitch = 1;
  float revolutions = dist / pitch;
  int steps = stepsPerRevolution * revolutions;

  float trueDisplacementChange = steps * (pitch / stepsPerRevolution);
  displacement += trueDisplacementChange;

  myStepper.step(-steps);

  return trueDisplacementChange;
}

void initialise() {

  //Find the start of the sample - i.e. the zero point

  //First unload completely
  delay(100);
  float forceA = -1000;
  while (forceA == - 1000) {
    forceA = measure();
    Serial.print("Force A:  ");
    Serial.println(forceA);
  }

  float trueStep; //just a placeholder 
  trueStep = move(-1);
  delay(1000);
  float forceB = measure();
  forceB = measure();
  forceB = measure();
  //Serial.print("Force B:  ");
  //Serial.println(forceB);

  while (abs(forceA - forceB) > 0.1) {
    delay(100);
    forceA = measure();
    trueStep = move(-0.5);
    forceB = measure();
    Serial.print("Force A:  ");
    Serial.print(forceA);
    Serial.print("     Force B:  ");
    Serial.println(forceB);
  }

  Serial.println("ZERO - UNLOADED");
  LoadCell.tareNoDelay();
  // wait until last tare operation is complete:
  bool tared = false;
  while (!tared) {
    delay(10);
    measure();

    if (LoadCell.getTareStatus() == true) {
      tared = 1;
    }
  }
  Serial.println("Tare complete");

  //Next screw in unitl zero point (until small increase in load
  delay(100);
  forceA = -1000;
  while (forceA == - 1000) {
    forceA = measure();
    Serial.print("Force A:  ");
    Serial.println(forceA);
  }

  trueStep = move(0.5);
  forceB = measure();
  Serial.print("Force B:  ");
  Serial.println(forceB);

  while (abs(forceA - forceB) < 0.3) {
    delay(10);
    trueStep = move(0.05);
    forceB = measure();
    Serial.print("Force A:  ");
    Serial.print(forceA);
    Serial.print("     Force B:  ");
    Serial.println(forceB);
  }

  Serial.println("ZERO DISPLACEMENT");
  LoadCell.tareNoDelay();
  displacement = 0;

  // wait until last tare operation is complete:
  tared = false;
  while (!tared) {
    delay(10);
    measure();

    if (LoadCell.getTareStatus() == true) {
      tared = 1;
    }
  }
  Serial.println("Tare complete");

}
