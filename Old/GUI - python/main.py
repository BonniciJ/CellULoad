import tkinter as tk
import serial
import time
import threading
from matplotlib.figure import Figure
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg



# Create functions for button clicks
def set_force():
    # Get the value from the Entry widget
    force_value = force_entry.get()
    arduino.write(b'#') #our start flag
    arduino.write(b'FFF')
    arduino.write(force_value.encode())
    arduino.write(b'~') #our end flag

def set_displacement():
    # Similar functionality can be added for displacement
    pass




def arduino_reader():
    #The data to plot
    forceData = [0] * 51
    targetForceData = [0] * 51
    dispData = [0] * 51

    while 1:
        
        data = (arduino.readline().strip()).decode("utf-8")
        print(data)
        if data.startswith("Force:"):
            splitData = data.split(":")
            index = splitData[1]
            forceReading = splitData[2]
            current_force_var.set(forceReading)

            #update the plot
            forceData[int(index)] = forceReading

            plot.clear()
            plot.plot(forceData)
            plot.plot(forceData)
            canvas.draw()
            


        elif data.startswith("Displacement:"):
            dispReading = data.split(":")[2]
            current_displacement_var.set(dispReading)
        elif data.startswith("Status:"):
            statusReading = data.split(":")[1]
            status_var.set(statusReading)
        elif data.startswith("Target Force:"):
            forceReading = data.split(":")[2]
            target_force_var.set(forceReading)
        elif data.startswith("Target Displacement:"):
            dispReading = data.split(":")[2]
            target_displacement_var.set(dispReading)
            

        if exit_event.is_set():
            break



def arduino_writier(x):
    arduino.write(bytes(x, 'utf-8'))



    

# Create the main window
root = tk.Tk()
root.title("Control Panel")

# Define the layout
root.columnconfigure(0, weight=1)
root.columnconfigure(1, weight=3)
root.rowconfigure(6, weight=1)


# Create StringVars for 
status_var = tk.StringVar(value="NOT CONNECTED")
target_force_var = tk.StringVar(value="")
current_force_var = tk.StringVar(value="")
target_displacement_var = tk.StringVar(value="")
current_displacement_var = tk.StringVar(value="")



# Create and place the labels and buttons
labels = ["Status:", "Target Force:", "Current Force:", "Target Displacement:", "Current Displacement:"]
for i, text in enumerate(labels):
    tk.Label(root, text=text).grid(column=0, row=i, sticky="e", padx=5, pady=5)

tk.Label(root, textvariable=status_var, relief="sunken", width=20).grid(column=1, row=0, sticky="ew", padx=5, pady=5)
tk.Label(root, textvariable=target_force_var, relief="sunken", width=20).grid(column=1, row=1, sticky="ew", padx=5, pady=5)
tk.Label(root, textvariable=current_force_var, relief="sunken", width=20).grid(column=1, row=2, sticky="ew", padx=5, pady=5)
tk.Label(root, textvariable=target_displacement_var, relief="sunken", width=20).grid(column=1, row=3, sticky="ew", padx=5, pady=5)
tk.Label(root, textvariable=current_displacement_var, relief="sunken", width=20).grid(column=1, row=4, sticky="ew", padx=5, pady=5)


# Set Force and Set Displacement inputs and buttons
tk.Label(root, text="Set Force:").grid(column=2, row=1, sticky="e", padx=5, pady=5)
force_entry = tk.Entry(root)
force_entry.grid(column=3, row=1, sticky="ew", padx=5, pady=5)
tk.Button(root, text="BUTTON", command=set_force).grid(column=4, row=1, padx=5, pady=5)

tk.Label(root, text="Set Displacement:").grid(column=2, row=3, sticky="e", padx=5, pady=5)
displacement_entry = tk.Entry(root)
displacement_entry.grid(column=3, row=3, sticky="ew", padx=5, pady=5)
tk.Button(root, text="BUTTON", command=set_displacement).grid(column=4, row=3, padx=5, pady=5)


# Create a figure for the plot
fig = Figure(figsize=(5, 4), dpi=100)
plot = fig.add_subplot(1, 1, 1)

# Create the canvas and add it to the window
canvas = FigureCanvasTkAgg(fig, master=root)  # A tk.DrawingArea.
canvas.draw()
canvas.get_tk_widget().grid(column=0, row=6, columnspan=5, sticky="nsew", padx=5, pady=5)




#start serial communication 
arduino = serial.Serial('com6', 57600) 

#set up thread
exit_event = threading.Event()
t1 = threading.Thread(target = arduino_reader)
t1.start()

# Start the GUI loop
root.mainloop()


#on close, end threads
arduino.close()
#add thing to close root.

print(f'{threading.active_count()} active threads')
exit_event.set()
print("Window closed")
t1.join()


print(f'{threading.active_count()} active threads')

