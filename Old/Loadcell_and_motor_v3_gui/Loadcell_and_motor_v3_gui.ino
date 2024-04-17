#include <HX711_ADC.h>
#if defined(ESP8266)|| defined(ESP32) || defined(AVR)
#include <EEPROM.h>
#endif

#include <Stepper.h>

const int stepsPerRevolution = 2048;  // resolution of motor

// initialize the stepper library on pins 8 through 11:
Stepper myStepper(stepsPerRevolution, 8, 10, 9, 11);


//pins:
const int HX711_dout = 4; //mcu > HX711 dout pin
const int HX711_sck = 3; //mcu > HX711 sck pin

//HX711 constructor:
HX711_ADC LoadCell(HX711_dout, HX711_sck);

const int calVal_eepromAdress = 0;
unsigned long t = 0;


// PID
const float p = 0.001;
const float i;
const float d;

float targetF = 20;   //target force

float displacement = 0; //


void setup() {


  
  Serial.begin(57600); delay(10);


  // set the speed at 5 rpm:
  myStepper.setSpeed(5);
  
  //Set up the load cell
  
  LoadCell.begin();
  //LoadCell.setReverseOutput(); //uncomment to turn a negative output value to positive
  float calibrationValue; // calibration value (see example file "Calibration.ino")
  calibrationValue = -43311.62; // uncomment this if you want to set the calibration value in the sketch
#if defined(ESP8266)|| defined(ESP32)
  //EEPROM.begin(512); // uncomment this if you use ESP8266/ESP32 and want to fetch the calibration value from eeprom
#endif
  //EEPROM.get(calVal_eepromAdress, calibrationValue); // uncomment this if you want to fetch the calibration value from eeprom

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


  Serial.println("Status: Initialising");
  //Find the start of the sample - i.e. the zero point
  //initialise();

  
}

int plotCount = 0;
bool isrunning = 1;


bool isReading = 0;
String incoming; //used for incoming messages - might be bad to use string??

int sendCount = 0;

void loop() {

  float force;
  force = measure();

  if (force != -1000) {  //if there is a force measurement

    float step;

    //control
    step = p * (targetF - force) * isrunning;
      
    move(step);
    displacement += step;
    delay(50);
    
    
  }

   

  // receive command from serial 
  if (Serial.available() > 0) {
    char inByte = Serial.read();
    if (inByte == '~') { //stop reading
      isReading = 0;
      if (incoming.substring(0, 2) = "FFF") {
        targetF = incoming.substring(3, incoming.length()).toFloat();
      }
    } else if (inByte == '#') { //start reading
      isReading = 1;
      incoming = "";
    } else if (isReading) { //read
      incoming.concat(inByte);
    }
  }

  // check if last tare operation is complete:
  if (LoadCell.getTareStatus() == true) {
    Serial.println("debug: Tare complete");
  }

  if (sendCount < 50){sendCount++;} else {sendCount=0;}

}

float measure() {

  float measurement = -1000;

  static boolean newDataReady = 0;
  const int serialPrintInterval = 10; //increase value to slow down serial print activity

  // check for new data/start next conversion:
  if (LoadCell.update()) newDataReady = true;

  // if the data is not ready, check again after a small delay. Only do this once
  if (!newDataReady) {
    delay(10);
    if (LoadCell.update()) newDataReady = true;
  }

  // get smoothed value from the dataset:
  if (newDataReady) {
    float i;
    if (millis() > t + serialPrintInterval) {
      i = LoadCell.getData();
      newDataReady = 0;
      t = millis();
    }

    measurement = i;

    
    //Plot force
    if (plotCount = 1000) {
      Serial.print(String("Force:"));
      Serial.print(String(sendCount));
      Serial.print(String(":"));
      Serial.println(i);

      Serial.print(String("Displacement:"));
      Serial.print(String(sendCount));
      Serial.print(String(":"));
      Serial.println(displacement);

      Serial.print(String("Target Force:"));
      Serial.print(String(sendCount));
      Serial.print(String(":"));
      Serial.println(targetF);

      Serial.print(String("Target Displacement:"));
      Serial.print(String(sendCount));
      Serial.print(String(":"));
      Serial.println("NONE");
      plotCount = 0;
    } else {
      plotCount++;
    }
        
  }

  return measurement;

  
}


void move(float dist) {
  //postive values compress
  float pitch = 1;
  float revolutions = dist/pitch;
  int steps = stepsPerRevolution * revolutions;

  myStepper.step(-steps);
}


void initialise() {

  //First unload completely

  //get a mearuement for the start force
  delay(100);
  float forceA = -1000;
  while (forceA == - 1000) { //this may cause issues if the load cell has a problem
    forceA = measure();
    delay(10);
  }
  Serial.print("debug: Force A:  ");
  Serial.println(forceA);

  move(-1);  //uncompress by 1mm
  delay(1000);
  float forceB = -1000;
  while (forceB == - 1000) { //this may cause issues if the load cell has a problem
    forceB = measure();
    delay(10);
  }
  Serial.print("debug: Force B:  ");
  Serial.println(forceB);

  while (abs(forceA - forceB) > 0.1) {
    delay(100);
    forceA = measure();
    move(-0.5);
    forceB = measure();
    Serial.print("debug: Force A:  ");
    Serial.print(forceA);
    Serial.print("     Force B:  ");
    Serial.println(forceB);
  }
  
  Serial.println("Status: Finding zero displacement");
  LoadCell.tareNoDelay();
  // wait until last tare operation is complete:
  bool tared = false;
  while (!tared) {
    delay(10);
    measure();
    
    if (LoadCell.getTareStatus() == true) { tared = 1;}
  }
  Serial.println("debug: Tare complete");

  //Next screw in unitl zero point (until small increase in load
  delay(100);
  forceA = -1000;
  while (forceA == - 1000) {
    forceA = measure();
    Serial.print("debug: Force A:  ");
    Serial.println(forceA);
  }

  move(0.5);
  forceB = measure();
  Serial.print("debug: Force B:  ");
  Serial.println(forceB);

  while (abs(forceA - forceB) < 1) {
    delay(100);
    move(0.1);
    forceB = measure();
    Serial.print("debug: Force A:  ");
    Serial.print(forceA);
    Serial.print("     Force B:  ");
    Serial.println(forceB);
  }
  
  Serial.println("Status: Fully Zeroed");
  LoadCell.tareNoDelay();
  displacement = 0;

    // wait until last tare operation is complete:
  tared = false;
  while (!tared) {
    delay(10);
    measure();
    
    if (LoadCell.getTareStatus() == true) { tared = 1;}
  }
  Serial.println("debug: Tare complete");
}
