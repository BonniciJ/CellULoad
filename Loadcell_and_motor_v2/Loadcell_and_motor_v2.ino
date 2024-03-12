/*
   -------------------------------------------------------------------------------------
   HX711_ADC
   Arduino library for HX711 24-Bit Analog-to-Digital Converter for Weight Scales
   Olav Kallhovd sept2017
   -------------------------------------------------------------------------------------
*/

/*
   Settling time (number of samples) and data filtering can be adjusted in the config.h file
   For calibration and storing the calibration value in eeprom, see example file "Calibration.ino"

   The update() function checks for new data and starts the next conversion. In order to acheive maximum effective
   sample rate, update() should be called at least as often as the HX711 sample rate; >10Hz@10SPS, >80Hz@80SPS.
   If you have other time consuming code running (i.e. a graphical LCD), consider calling update() from an interrupt routine,
   see example file "Read_1x_load_cell_interrupt_driven.ino".

   This is an example sketch on how to use this library
*/

/* Checking git working 
 */

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

  //initialise();
  
}

int plotCount = 0;
bool isrunning = 1;

float timePermm = 1; //in mins
float movementRemaining = 0;
int direction = 1; 

void loop() {


  float force;
  force = measure();

  if (force != -1000) {  //if there is a force measurement

    if (movementRemaining <= 0){

      float step;
      float error = targetF - force;
      step = control(error) * isrunning;      

      movementRemaining = abs(step);
      if (step > 0) {
        direction = 1;
      } else {
        direction = -1;
      }

    } else {

      float stepSize = 0.001 * direction;

      move(stepSize);
      displacement += stepSize;
      movementRemaining -= abs(stepSize);

      //delay to ensure slow compression at specified rate 
      int timeDelay = timePermm*60000*stepSize; //time to do one step
      timeDelay -= stepSize * 7.5 * 1000;    //correct for the time it takes to turn the motor
      delay(timeDelay);  
    }

    
    
  }

   

  // receive command from serial terminal, send 't' to initiate tare operation:
  if (Serial.available() > 0) {
    char inByte = Serial.read();
    if (inByte == 't') LoadCell.tareNoDelay();
    if (inByte == 'P') targetF += 10;
    if (inByte == 'N') targetF -= 10;
    if (inByte == 'X') isrunning = !isrunning;
  }

  // check if last tare operation is complete:
  if (LoadCell.getTareStatus() == true) {
    Serial.println("Tare complete");
  }

}


float prevError = 0;

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
    if (millis() > t + serialPrintInterval) {
      i = LoadCell.getData();
      newDataReady = 0;
      t = millis();
    }
    measurement = i;
    
    //Plot force
    if (plotCount = 1000 && i != -1000) {
      Serial.println(String(i) + "," + String(targetF) + "," + String(displacement)); // + "," + String(0) + "," + String(40)
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
  //Find the start of the sample - i.e. the zero point

  //First unload completely
  delay(100);
  float forceA = -1000;
  while (forceA == - 1000) {
    forceA = measure();
  }

  move(-1);
  delay(1000);
  float forceB = measure();
  forceB = measure();
  forceB = measure();
  Serial.print("Force B:  ");
  Serial.println(forceB);

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
    
    if (LoadCell.getTareStatus() == true) { tared = 1;}
  }
  Serial.println("Tare complete");

  //Next screw in unitl zero point (until small increase in load
  delay(100);
  forceA = -1000;
  forceA = measure();

  move(0.5);
  forceB = measure();
  Serial.print("Force B:  ");
  Serial.println(forceB);

  while (abs(forceA - forceB) < 0.5) {
    delay(10);
    move(0.1);
    while (forceB == -1000) {
      forceB = measure();
      delay(10);
    };
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
    
    if (LoadCell.getTareStatus() == true) { tared = 1;}
  }
  Serial.println("Tare complete");
}