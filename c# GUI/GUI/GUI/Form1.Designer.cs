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
            this.serialOuttxtbox = new System.Windows.Forms.TextBox();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.dissconnectBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            this.statustextLbl = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.portLbl = new System.Windows.Forms.Label();
            this.baudRateTxtBx = new System.Windows.Forms.TextBox();
            this.baudLbl = new System.Windows.Forms.Label();
            this.scanPortsBtn = new System.Windows.Forms.Button();
            this.availablePortsDropDown = new System.Windows.Forms.ComboBox();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.defLimTxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.forceLimTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.currentDefLbl = new System.Windows.Forms.Label();
            this.targetDeflbl = new System.Windows.Forms.Label();
            this.currentForceLbl = new System.Windows.Forms.Label();
            this.targetForceLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rateTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rawSendTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CurrentRateLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.compRadio = new System.Windows.Forms.RadioButton();
            this.decompRadio = new System.Windows.Forms.RadioButton();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.csvPanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.StopandSaveBtn = new System.Windows.Forms.Button();
            this.dataEntriesLbl = new System.Windows.Forms.Label();
            this.stopConfirmBtn = new System.Windows.Forms.Button();
            this.fileNameTxt = new System.Windows.Forms.TextBox();
            this.controlPanel.SuspendLayout();
            this.connectionPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.csvPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.serialOuttxtbox);
            this.controlPanel.Location = new System.Drawing.Point(9, 282);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(871, 283);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // serialOuttxtbox
            // 
            this.serialOuttxtbox.Location = new System.Drawing.Point(-1, -1);
            this.serialOuttxtbox.Multiline = true;
            this.serialOuttxtbox.Name = "serialOuttxtbox";
            this.serialOuttxtbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serialOuttxtbox.Size = new System.Drawing.Size(413, 279);
            this.serialOuttxtbox.TabIndex = 0;
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
            this.connectionPanel.Size = new System.Drawing.Size(403, 177);
            this.connectionPanel.TabIndex = 1;
            this.connectionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.connectionPanel_Paint);
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
            // settingsPanel
            // 
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsPanel.Controls.Add(this.checkBox2);
            this.settingsPanel.Controls.Add(this.decompRadio);
            this.settingsPanel.Controls.Add(this.compRadio);
            this.settingsPanel.Controls.Add(this.checkBox1);
            this.settingsPanel.Controls.Add(this.CurrentRateLbl);
            this.settingsPanel.Controls.Add(this.label10);
            this.settingsPanel.Controls.Add(this.button3);
            this.settingsPanel.Controls.Add(this.button2);
            this.settingsPanel.Controls.Add(this.button1);
            this.settingsPanel.Controls.Add(this.rawSendTxt);
            this.settingsPanel.Controls.Add(this.label8);
            this.settingsPanel.Controls.Add(this.sendBtn);
            this.settingsPanel.Controls.Add(this.rateTxt);
            this.settingsPanel.Controls.Add(this.label7);
            this.settingsPanel.Controls.Add(this.defLimTxt);
            this.settingsPanel.Controls.Add(this.label12);
            this.settingsPanel.Controls.Add(this.forceLimTxt);
            this.settingsPanel.Controls.Add(this.label11);
            this.settingsPanel.Controls.Add(this.currentDefLbl);
            this.settingsPanel.Controls.Add(this.targetDeflbl);
            this.settingsPanel.Controls.Add(this.currentForceLbl);
            this.settingsPanel.Controls.Add(this.targetForceLbl);
            this.settingsPanel.Controls.Add(this.label6);
            this.settingsPanel.Controls.Add(this.label5);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Enabled = false;
            this.settingsPanel.Location = new System.Drawing.Point(421, 12);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(459, 264);
            this.settingsPanel.TabIndex = 2;
            // 
            // defLimTxt
            // 
            this.defLimTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defLimTxt.Location = new System.Drawing.Point(295, 90);
            this.defLimTxt.Name = "defLimTxt";
            this.defLimTxt.Size = new System.Drawing.Size(95, 24);
            this.defLimTxt.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(214, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 18);
            this.label12.TabIndex = 20;
            this.label12.Text = "Force limit:";
            // 
            // forceLimTxt
            // 
            this.forceLimTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forceLimTxt.Location = new System.Drawing.Point(295, 56);
            this.forceLimTxt.Name = "forceLimTxt";
            this.forceLimTxt.Size = new System.Drawing.Size(95, 24);
            this.forceLimTxt.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(230, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 18);
            this.label11.TabIndex = 8;
            this.label11.Text = "Def limit:";
            // 
            // currentDefLbl
            // 
            this.currentDefLbl.AutoSize = true;
            this.currentDefLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDefLbl.Location = new System.Drawing.Point(166, 145);
            this.currentDefLbl.Name = "currentDefLbl";
            this.currentDefLbl.Size = new System.Drawing.Size(16, 18);
            this.currentDefLbl.TabIndex = 19;
            this.currentDefLbl.Text = "_";
            // 
            // targetDeflbl
            // 
            this.targetDeflbl.AutoSize = true;
            this.targetDeflbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetDeflbl.Location = new System.Drawing.Point(166, 115);
            this.targetDeflbl.Name = "targetDeflbl";
            this.targetDeflbl.Size = new System.Drawing.Size(16, 18);
            this.targetDeflbl.TabIndex = 18;
            this.targetDeflbl.Text = "_";
            // 
            // currentForceLbl
            // 
            this.currentForceLbl.AutoSize = true;
            this.currentForceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentForceLbl.Location = new System.Drawing.Point(166, 85);
            this.currentForceLbl.Name = "currentForceLbl";
            this.currentForceLbl.Size = new System.Drawing.Size(16, 18);
            this.currentForceLbl.TabIndex = 17;
            this.currentForceLbl.Text = "_";
            // 
            // targetForceLbl
            // 
            this.targetForceLbl.AutoSize = true;
            this.targetForceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetForceLbl.Location = new System.Drawing.Point(166, 53);
            this.targetForceLbl.Name = "targetForceLbl";
            this.targetForceLbl.Size = new System.Drawing.Size(16, 18);
            this.targetForceLbl.TabIndex = 8;
            this.targetForceLbl.Text = "_";
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
            // rateTxt
            // 
            this.rateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateTxt.Location = new System.Drawing.Point(295, 124);
            this.rateTxt.Name = "rateTxt";
            this.rateTxt.Size = new System.Drawing.Size(95, 24);
            this.rateTxt.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(246, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Rate:";
            // 
            // rawSendTxt
            // 
            this.rawSendTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rawSendTxt.Location = new System.Drawing.Point(321, 233);
            this.rawSendTxt.Name = "rawSendTxt";
            this.rawSendTxt.Size = new System.Drawing.Size(71, 24);
            this.rawSendTxt.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(214, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Send raw text:";
            // 
            // sendBtn
            // 
            this.sendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtn.Location = new System.Drawing.Point(396, 231);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(58, 28);
            this.sendBtn.TabIndex = 24;
            this.sendBtn.Text = "SEND";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(396, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 28);
            this.button1.TabIndex = 27;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(396, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 28);
            this.button2.TabIndex = 28;
            this.button2.Text = "SEND";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(396, 122);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 28);
            this.button3.TabIndex = 29;
            this.button3.Text = "SEND";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CurrentRateLbl
            // 
            this.CurrentRateLbl.AutoSize = true;
            this.CurrentRateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentRateLbl.Location = new System.Drawing.Point(167, 173);
            this.CurrentRateLbl.Name = "CurrentRateLbl";
            this.CurrentRateLbl.Size = new System.Drawing.Size(16, 18);
            this.CurrentRateLbl.TabIndex = 31;
            this.CurrentRateLbl.Text = "_";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 18);
            this.label10.TabIndex = 30;
            this.label10.Text = "Current Rate:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(396, 173);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 17);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Halt";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // compRadio
            // 
            this.compRadio.AutoSize = true;
            this.compRadio.Checked = true;
            this.compRadio.Enabled = false;
            this.compRadio.Location = new System.Drawing.Point(249, 172);
            this.compRadio.Name = "compRadio";
            this.compRadio.Size = new System.Drawing.Size(85, 17);
            this.compRadio.TabIndex = 33;
            this.compRadio.TabStop = true;
            this.compRadio.Text = "Compression";
            this.compRadio.UseVisualStyleBackColor = true;
            this.compRadio.CheckedChanged += new System.EventHandler(this.compRadio_CheckedChanged);
            // 
            // decompRadio
            // 
            this.decompRadio.AutoSize = true;
            this.decompRadio.Enabled = false;
            this.decompRadio.Location = new System.Drawing.Point(249, 195);
            this.decompRadio.Name = "decompRadio";
            this.decompRadio.Size = new System.Drawing.Size(98, 17);
            this.decompRadio.TabIndex = 34;
            this.decompRadio.Text = "Decompression";
            this.decompRadio.UseVisualStyleBackColor = true;
            this.decompRadio.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(217, 208);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 35;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.csvPanel);
            this.panel2.Location = new System.Drawing.Point(13, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 81);
            this.panel2.TabIndex = 9;
            // 
            // csvPanel
            // 
            this.csvPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csvPanel.Controls.Add(this.fileNameTxt);
            this.csvPanel.Controls.Add(this.stopConfirmBtn);
            this.csvPanel.Controls.Add(this.dataEntriesLbl);
            this.csvPanel.Controls.Add(this.StopandSaveBtn);
            this.csvPanel.Controls.Add(this.label13);
            this.csvPanel.Controls.Add(this.label9);
            this.csvPanel.Enabled = false;
            this.csvPanel.Location = new System.Drawing.Point(89, -1);
            this.csvPanel.Name = "csvPanel";
            this.csvPanel.Size = new System.Drawing.Size(312, 81);
            this.csvPanel.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(5, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 66);
            this.button4.TabIndex = 11;
            this.button4.Text = "Start recording data";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "File Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 18);
            this.label13.TabIndex = 10;
            this.label13.Text = "Data entries:";
            // 
            // StopandSaveBtn
            // 
            this.StopandSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopandSaveBtn.Location = new System.Drawing.Point(6, 50);
            this.StopandSaveBtn.Name = "StopandSaveBtn";
            this.StopandSaveBtn.Size = new System.Drawing.Size(301, 26);
            this.StopandSaveBtn.TabIndex = 12;
            this.StopandSaveBtn.Text = "Stop recording and save data";
            this.StopandSaveBtn.UseVisualStyleBackColor = true;
            this.StopandSaveBtn.Click += new System.EventHandler(this.StopandSaveBtn_Click);
            // 
            // dataEntriesLbl
            // 
            this.dataEntriesLbl.AutoSize = true;
            this.dataEntriesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataEntriesLbl.Location = new System.Drawing.Point(109, 25);
            this.dataEntriesLbl.Name = "dataEntriesLbl";
            this.dataEntriesLbl.Size = new System.Drawing.Size(23, 18);
            this.dataEntriesLbl.TabIndex = 14;
            this.dataEntriesLbl.Text = "---";
            // 
            // stopConfirmBtn
            // 
            this.stopConfirmBtn.Enabled = false;
            this.stopConfirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopConfirmBtn.Location = new System.Drawing.Point(218, 25);
            this.stopConfirmBtn.Name = "stopConfirmBtn";
            this.stopConfirmBtn.Size = new System.Drawing.Size(89, 27);
            this.stopConfirmBtn.TabIndex = 15;
            this.stopConfirmBtn.Text = "Stop";
            this.stopConfirmBtn.UseVisualStyleBackColor = true;
            this.stopConfirmBtn.Click += new System.EventHandler(this.stopConfirmBtn_Click);
            // 
            // fileNameTxt
            // 
            this.fileNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameTxt.Location = new System.Drawing.Point(100, 2);
            this.fileNameTxt.Name = "fileNameTxt";
            this.fileNameTxt.Size = new System.Drawing.Size(207, 24);
            this.fileNameTxt.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 577);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.connectionPanel);
            this.Controls.Add(this.controlPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.connectionPanel.ResumeLayout(false);
            this.connectionPanel.PerformLayout();
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.csvPanel.ResumeLayout(false);
            this.csvPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.ComboBox availablePortsDropDown;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Button scanPortsBtn;
        private System.Windows.Forms.TextBox baudRateTxtBx;
        private System.Windows.Forms.Label baudLbl;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label statustextLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox defLimTxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox forceLimTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label currentDefLbl;
        private System.Windows.Forms.Label targetDeflbl;
        private System.Windows.Forms.Label targetForceLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serialOuttxtbox;
        private System.Windows.Forms.Button dissconnectBtn;
        private System.Windows.Forms.Label currentForceLbl;
        private System.Windows.Forms.TextBox rateTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rawSendTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CurrentRateLbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton decompRadio;
        private System.Windows.Forms.RadioButton compRadio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel csvPanel;
        private System.Windows.Forms.Button stopConfirmBtn;
        private System.Windows.Forms.Label dataEntriesLbl;
        private System.Windows.Forms.Button StopandSaveBtn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox fileNameTxt;
    }
}

