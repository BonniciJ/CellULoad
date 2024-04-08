using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal class commHandler
    {

        private string port;
        private int baudRate;
        private SerialPort commPort;


        public commHandler(string port, int baudRate)
        {
            this.port = port;
            this.baudRate = baudRate;
            connect();
        }

        private void connect() {

            commPort = new SerialPort();

            commPort.PortName = port;
            commPort.BaudRate = baudRate;
                    
            commPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);


            commPort.Open();

        }

        public void disconnect() { 
            commPort.Close();
        }

        //ref: https://stackoverflow.com/questions/29018001/c-sharp-serial-port-listener
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();

            handleNewData(indata);
        }

        private static void handleNewData(string data)
        {
            // ...
            MessageBox.Show(data);
            
        }

        

        public void setPort(string port) { this.port = port; }
        public void setBaudRate(int baudRate) { this.baudRate = baudRate;}

       


    }
}
