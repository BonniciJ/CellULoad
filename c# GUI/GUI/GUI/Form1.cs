using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class Form1 : Form
    {

       
        private SerialPort mySerialPort;
        private bool recordingData = false;
        List<string> receivedValues = new List<string>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //on load, scan for ports
            updateAvailablePorts();



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void connectionPanel_Paint(object sender, PaintEventArgs e)
        {

        }



        private void updateAvailablePorts()
        {
            //display all available COMs on a dropdown list

            availablePortsDropDown.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                availablePortsDropDown.Items.Add(p);
            }
        }

        private void scanPortsBtn_Click(object sender, EventArgs e)
        {
            updateAvailablePorts();
        }

        

        private void connectBtn_Click(object sender, EventArgs e)
        {
            string port = availablePortsDropDown.SelectedItem.ToString();
            int baudrate;
            if (!Int32.TryParse(baudRateTxtBx.Text, out baudrate))
            {
                //failure to parse as int
            }

            
            mySerialPort = new SerialPort(port);

            mySerialPort.BaudRate = baudrate;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            mySerialPort.Open();
            connectBtn.Enabled = false;
            settingsPanel.Enabled = true;
            

        }

        public void DataReceivedHandler(object sender,SerialDataReceivedEventArgs e) {      //ref: https://stackoverflow.com/questions/29018001/c-sharp-serial-port-listener
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();

            callmyfunction(indata);
        }

        public void callmyfunction(string data) {

            serialOuttxtbox.Invoke(new MethodInvoker(delegate
            {
                // This code block is executed on the UI thread
                //serialOuttxtbox.AppendText(DateTime.Now.TimeOfDay.ToString() + "   ");
                serialOuttxtbox.AppendText(data);
            }));

            if (data.StartsWith("DATA: "))
            {
                //split data
                string[] splitData = data.Split(',');
                string currentForce = splitData[1];
                string targetForce = splitData[2];
                string currentDisplacement = splitData[3];
                string targetDisplacement = splitData[4];
                string currentRate = splitData[5];

                //if we need to record the values for csv
                if (recordingData)
                {
                    receivedValues.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + data.Remove(0, 6));
                    dataEntriesLbl.Invoke(new MethodInvoker(delegate
                    {
                        dataEntriesLbl.Text = receivedValues.Count.ToString();
                    }));
                    
                }

                currentForceLbl.Invoke(new MethodInvoker(delegate
                {
                    currentForceLbl.Text = currentForce;
                }));

                targetForceLbl.Invoke(new MethodInvoker(delegate
                {
                    targetForceLbl.Text = targetForce;
                }));

                currentDefLbl.Invoke(new MethodInvoker(delegate
                {
                    currentDefLbl.Text = currentDisplacement;
                }));

                targetDeflbl.Invoke(new MethodInvoker(delegate
                {
                    targetDeflbl.Text = targetDisplacement;
                }));

                CurrentRateLbl.Invoke(new MethodInvoker(delegate
                {
                    CurrentRateLbl.Text = currentRate;
                }));
            }

        }



        private void dissconnectBtn_Click(object sender, EventArgs e)
        {
            mySerialPort.Close();
            connectBtn.Enabled = true;
            settingsPanel.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            mySerialPort.WriteLine(rawSendTxt.Text);
            rawSendTxt.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySerialPort.Write("##");
            mySerialPort.Write("FOR");
            mySerialPort.Write(forceLimTxt.Text);
            mySerialPort.WriteLine("~");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            mySerialPort.Write("##");
            mySerialPort.Write("DEF");
            mySerialPort.Write(defLimTxt.Text);
            mySerialPort.WriteLine("~");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mySerialPort.Write("##");
            mySerialPort.Write("RAT");
            mySerialPort.Write(rateTxt.Text);
            mySerialPort.WriteLine("~");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                mySerialPort.WriteLine("H");
            } else
            {
                mySerialPort.WriteLine("X");
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            compRadio.Enabled = ! compRadio.Enabled;
            decompRadio.Enabled = ! decompRadio.Enabled;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            csvPanel.Enabled = true;
            recordingData = true;
            receivedValues.Add("DATETIME, FORCE, FORCE LIM, DISP, DISP LIM, RATE");
        }

        private void StopandSaveBtn_Click(object sender, EventArgs e)
        {
            stopConfirmBtn.Enabled = true;
        }

        private void stopConfirmBtn_Click(object sender, EventArgs e)
        {
            string filePath = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss.fff") + "  " + fileNameTxt.Text + ".csv";

            using (StreamWriter file = new StreamWriter(filePath))
            {
                foreach (string value in receivedValues)
                {
                    file.WriteLine(value); // Writing each value on a new line
                }
            }
            receivedValues.Clear();

            recordingData = false;
            stopConfirmBtn.Enabled = false;
            csvPanel.Enabled = false;

            MessageBox.Show("Saved Successfully!");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mySerialPort.WriteLine("Y");
        }

        private void compRadio_CheckedChanged(object sender, EventArgs e)
        {
            mySerialPort.WriteLine("K");
        }
    }

}
