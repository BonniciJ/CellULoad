import serial
import time
import threading

class arduinoHandler:

    baud = 9600
    port = 'com6'
    arduino = serial.Serial('com6', 57600) 

    targetForce = 0
    setForce = 0

    targetDisp = 0
    setDisp = 0

    status = ''



    def __init__(self, newBaud, newPort):
        #constructor
        self.baud = newBaud
        self.port = newPort
        arduino = serial.Serial(newBaud, newPort) 

    def arduino_reader(self):
        while 1:
            
            data = (self.arduino.readline().strip()).decode("utf-8")
            if data.startswith("Force:"):
                forceReading = data.split(":")[1]
                current_force_var.set(forceReading)
            elif data.startswith("Displacement:"):
                dispReading = data.split(":")[1]
                current_displacement_var.set(dispReading)
            elif data.startswith("Status:"):
                statusReading = data.split(":")[1]
                status_var.set(statusReading)
            elif data.startswith("Target Force:"):
                forceReading = data.split(":")[1]
                target_force_var.set(forceReading)
            elif data.startswith("Target Displacement:"):
                dispReading = data.split(":")[1]
                target_displacement_var.set(dispReading)
                

            if exit_event.is_set():
                break

    def sendNewForce(self, newF):
        
        if not ((type(newF) is int) or (type(newF) is float)):
            return

        self.arduino.write(b'#') #our start flag
        self.arduino.write(b'FFF')
        self.arduino.write(newF.encode())
        self.arduino.write(b'~') #our end flag



    

    