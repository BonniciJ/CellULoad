#include <HX711_ADC.h>
#include <Stepper.h>



// initialize the stepper library on pins 8 through 11:
const int stepsPerRevolution = 2048;  // resolution of motor
Stepper myStepper(stepsPerRevolution, 8, 10, 9, 11);


//pins:
const int HX711_dout = 4; //mcu > HX711 dout pin
const int HX711_sck = 3; //mcu > HX711 sck pin

//HX711 constructor:
HX711_ADC LoadCell(HX711_dout, HX711_sck);

unsigned long t = 0;


// PID
const float p = 0.001;
const float i;
const float d;

float targetF = 0;   //target force
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
bool isrunning = 1;
float timePermm = 2; //in mins
float movementRemaining = 0;
int direction = 1; 
bool decomp = 0;
float maxCompression = 2.5; //measured in mm. Maximum compression 


bool halted = 0;
bool atMaxCompress = 0;


void loop() {

  if (halted) {
    delay(50);
  } else {

    if (displacement >= maxCompression && !decomp) {
      atMaxCompress = 1;
    }

    if (atMaxCompress) {
      delay(50);
      if (displacement < maxCompression) {
        atMaxCompress = 0;
      }
    } else {
      //if we arent at max compression and we arent halted:
      
      float force;
      force = measure();

      if (force != -1000) {  //if there is a force measurement

        if (decomp) {
          //decompressing

          delay(50);
          float step;
          float error = targetF - force;
          step = control(error) * isrunning; 
          move(step);      
          displacement += step;
        } else {
          //compressing
          doCompression(force);
        
        }
        
      } else {
        delay(50);
      }
    }
    
  }
  
}

void doCompression(float force) {
  if (movementRemaining < 0){

    float step;
    float error = targetF - force;
    step = control(error) * isrunning;  


    movementRemaining = abs(step);
    if (step >= 0) {
      direction = 1;
      movementRemaining = step;
    } else {
      direction = -1;
      movementRemaining = -step;
    }
  
  } else if(movementRemaining = 0) {
    delay(10);
  } else {    
  
    float stepSize = 0.001;

    move(stepSize * direction);
    displacement += stepSize * direction;
    movementRemaining -= direction * stepSize;

    //delay to ensure slow compression at specified rate 
    int timeDelay = timePermm*60000*stepSize; //time to do one step
    timeDelay -= stepSize * 7.5 * 1000;    //correct for the time it takes to turn the motor
    delay(timeDelay);  
  }
  
}

void oldloop() {

  if (displacement > maxCompression && !decomp) {
    isrunning = 0;
  }


  float force;
  force = measure();

  if (force != -1000) {  //if there is a force measurement

    if (decomp && isrunning) { 
      //decompressing

      delay(50);
      float step;
      float error = targetF - force;
      step = control(error) * isrunning; 
      move(step);      
      displacement += step;
      
    } else if (isrunning) {
      //compression
      
      if (movementRemaining < 0){
  
        float step;
        float error = targetF - force;
        step = control(error) * isrunning;  
  
  
        movementRemaining = abs(step);
        if (step >= 0) {
          direction = 1;
          movementRemaining = step;
        } else {
          direction = -1;
          movementRemaining = -step;
        }
  
  
  
      } else if(movementRemaining = 0) {
        delay(10);
        
      } else {    
  
        float stepSize = 0.001;
  
        move(stepSize * direction);
        displacement += stepSize * direction;
        movementRemaining -= direction * stepSize;
  
        //delay to ensure slow compression at specified rate 
        int timeDelay = timePermm*60000*stepSize; //time to do one step
        timeDelay -= stepSize * 7.5 * 1000;    //correct for the time it takes to turn the motor
        delay(timeDelay);  
      }
    }

    
    
  }
  

  listenToSerial(); 

}

float prevError = 0;

void listenToSerial(){
  if (Serial.available() > 0) {
    char inByte = Serial.read();
    if (inByte == 'P') targetF += 10;           //increase target force
    if (inByte == 'N') targetF -= 10;           //decrease target force
    if (inByte == 'X') isrunning = !isrunning;  //toggle compression
    if (inByte == 'D') decomp = 1;              //decompress
    if (inByte == 'C') decomp = 0;              //compress
  }
}

float control(float error){

  float step = 0;
  step = p * error;
  prevError = error;
  return step;

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
      Serial.println(String(i) + "," + String(targetF) + "," + String(displacement * 10));
      plotCount = 0;
    } else {
      plotCount++;
    }

  }

  return measurement;


}


void move(float dist) {
  //postive values compress
  //dist is measured in mm
  float pitch = 1;
  float revolutions = dist / pitch;
  int steps = stepsPerRevolution * revolutions;

  myStepper.step(-steps);
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

  move(-1);
  delay(1000);
  float forceB = measure();
  forceB = measure();
  forceB = measure();
  //Serial.print("Force B:  ");
  //Serial.println(forceB);

  while (abs(forceA - forceB) > 0.1) {
    delay(100);
    forceA = measure();
    move(-0.5);
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

  move(0.5);
  forceB = measure();
  Serial.print("Force B:  ");
  Serial.println(forceB);

  while (abs(forceA - forceB) < 0.5) {
    delay(10);
    move(0.05);
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
