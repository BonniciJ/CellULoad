// Initialisation function should include clearing of controller variables


// PID

const float Kp = 0.001
const float Ki = 0.001
const float Kd = 0.001
const float T = 0.05 // What's our sampling time? How reg are we reading force value from load cell
const float tau = 0.1 // Find suitable cut-off frequency for filtering of high frequency noise

// Set cut-off frequency at around 30/40Hz --> most noise affecting load cells is power frequency noise (~ 50/60 Hz) 

// omega_0 = 1/tau so set tau = 1/40 = 0.025

//// Need to define measurement (readout of load cell) + store prevMeasurement

float prevError = 0

float control(float error){

  float step = 0;

  proportional = Kp * error
  integral = integral + 0.5 * T * Ki * (error + prevError)
  derivative = -(2.0 * Kd * (measurement - prevMeasurement) /* Note: derivative on measurement, therefore minus sign in front of equation! */
                        + (2.0f * tau - T) * derivative)
                        / (2.0f * tau + T);

  step = proportional + integral + derivative
}
