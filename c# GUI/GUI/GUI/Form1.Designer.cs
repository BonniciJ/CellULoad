namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlPanel = new System.Windows.Forms.Panel();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.statusLbl = new System.Windows.Forms.Label();
            this.statustextLbl = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.portLbl = new System.Windows.Forms.Label();
            this.baudRateTxtBx = new System.Windows.Forms.TextBox();
            this.baudLbl = new System.Windows.Forms.Label();
            this.scanPortsBtn = new System.Windows.Forms.Button();
            this.availablePortsDropDown = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dissconnectBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            this.connectionPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.button2);
            this.controlPanel.Controls.Add(this.textBox3);
            this.controlPanel.Location = new System.Drawing.Point(9, 282);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(777, 283);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // connectionPanel
            // 
            this.connectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionPanel.Controls.Add(this.dissconnectBtn);
            this.connectionPanel.Controls.Add(this.statusLbl);
            this.connectionPanel.Controls.Add(this.statustextLbl);
            this.connectionPanel.Controls.Add(this.connectBtn);
            this.connectionPanel.Controls.Add(this.portLbl);
            this.connectionPanel.Controls.Add(this.baudRateTxtBx);
            this.connectionPanel.Controls.Add(this.baudLbl);
            this.connectionPanel.Controls.Add(this.scanPortsBtn);
            this.connectionPanel.Controls.Add(this.availablePortsDropDown);
            this.connectionPanel.Location = new System.Drawing.Point(12, 12);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(365, 177);
            this.connectionPanel.TabIndex = 1;
            this.connectionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.connectionPanel_Paint);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(63, 144);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(105, 18);
            this.statusLbl.TabIndex = 7;
            this.statusLbl.Text = "Not connected";
            // 
            // statustextLbl
            // 
            this.statustextLbl.AutoSize = true;
            this.statustextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statustextLbl.Location = new System.Drawing.Point(3, 144);
            this.statustextLbl.Name = "statustextLbl";
            this.statustextLbl.Size = new System.Drawing.Size(54, 18);
            this.statustextLbl.TabIndex = 6;
            this.statustextLbl.Text = "Status:";
            // 
            // connectBtn
            // 
            this.connectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.Location = new System.Drawing.Point(112, 85);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(148, 28);
            this.connectBtn.TabIndex = 5;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLbl.Location = new System.Drawing.Point(3, 15);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(40, 18);
            this.portLbl.TabIndex = 4;
            this.portLbl.Text = "Port:";
            // 
            // baudRateTxtBx
            // 
            this.baudRateTxtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baudRateTxtBx.Location = new System.Drawing.Point(90, 43);
            this.baudRateTxtBx.Name = "baudRateTxtBx";
            this.baudRateTxtBx.Size = new System.Drawing.Size(105, 24);
            this.baudRateTxtBx.TabIndex = 3;
            this.baudRateTxtBx.Text = "57600";
            // 
            // baudLbl
            // 
            this.baudLbl.AutoSize = true;
            this.baudLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baudLbl.Location = new System.Drawing.Point(3, 46);
            this.baudLbl.Name = "baudLbl";
            this.baudLbl.Size = new System.Drawing.Size(81, 18);
            this.baudLbl.TabIndex = 2;
            this.baudLbl.Text = "Baud Rate:";
            // 
            // scanPortsBtn
            // 
            this.scanPortsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanPortsBtn.Location = new System.Drawing.Point(234, 12);
            this.scanPortsBtn.Name = "scanPortsBtn";
            this.scanPortsBtn.Size = new System.Drawing.Size(74, 26);
            this.scanPortsBtn.TabIndex = 1;
            this.scanPortsBtn.Text = "Scan Ports";
            this.scanPortsBtn.UseVisualStyleBackColor = true;
            this.scanPortsBtn.Click += new System.EventHandler(this.scanPortsBtn_Click);
            // 
            // availablePortsDropDown
            // 
            this.availablePortsDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availablePortsDropDown.FormattingEnabled = true;
            this.availablePortsDropDown.Location = new System.Drawing.Point(90, 12);
            this.availablePortsDropDown.Name = "availablePortsDropDown";
            this.availablePortsDropDown.Size = new System.Drawing.Size(125, 26);
            this.availablePortsDropDown.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(421, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 264);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(257, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(257, 225);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(105, 24);
            this.textBox2.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(200, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 18);
            this.label12.TabIndex = 20;
            this.label12.Text = "Force:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(257, 195);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 24);
            this.textBox1.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(216, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 18);
            this.label11.TabIndex = 8;
            this.label11.Text = "Def:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(166, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "_";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(166, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "_";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(166, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "_";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(166, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "_";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Current Deformation:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Current Force";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Target Deformation:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Target Force:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton2.Location = new System.Drawing.Point(13, 225);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(106, 22);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Target force";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(13, 197);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(151, 22);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.Text = "Target deformation";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Not connected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(163, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // dissconnectBtn
            // 
            this.dissconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dissconnectBtn.Location = new System.Drawing.Point(112, 115);
            this.dissconnectBtn.Name = "dissconnectBtn";
            this.dissconnectBtn.Size = new System.Drawing.Size(148, 28);
            this.dissconnectBtn.TabIndex = 8;
            this.dissconnectBtn.Text = "Disconnect";
            this.dissconnectBtn.UseVisualStyleBackColor = true;
            this.dissconnectBtn.Click += new System.EventHandler(this.dissconnectBtn_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(140, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "Listen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.connectionPanel);
            this.Controls.Add(this.controlPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.connectionPanel.ResumeLayout(false);
            this.connectionPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.ComboBox availablePortsDropDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button scanPortsBtn;
        private System.Windows.Forms.TextBox baudRateTxtBx;
        private System.Windows.Forms.Label baudLbl;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label statustextLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button dissconnectBtn;
        private System.Windows.Forms.Button button2;
    }
}

