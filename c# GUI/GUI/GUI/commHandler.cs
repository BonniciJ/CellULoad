using System;
using System.Collections.Generic;
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

            commPort.Open();


        }

        public void disconnect() { 
            commPort.Close();
        }

        public string commListener()
        {
            while (commPort.IsOpen)
            {
                try
                {
                    if (commPort.BytesToRead > 0)
                    {
                        string message = commPort.ReadLine();

                        //handle incoming data
                        return message;

                    }
                }
                catch (TimeoutException) { }
            }
            return "-1";
        }

        public void setPort(string port) { this.port = port; }
        public void setBaudRate(int baudRate) { this.baudRate = baudRate;}

       


    }
}
