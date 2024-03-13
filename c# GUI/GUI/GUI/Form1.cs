using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private commHandler commHandler;

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
            int baudrate = 0;
            if (!Int32.TryParse(baudRateTxtBx.Text, out baudrate))
            {
                //failure to parse as int
            }

            commHandler = new commHandler(port, baudrate);

        }


        private void dissconnectBtn_Click(object sender, EventArgs e)
        {
            commHandler.disconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = commHandler.commListener();
        }
    }

}
