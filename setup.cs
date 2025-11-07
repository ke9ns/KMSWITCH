//=================================================================
// spot_options.cs
//=================================================================
// KMSWITCH is a C# implementation of a Software Defined Radio.
// Copyright (C) 2003-2013  FlexRadio Systems
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// You may contact us via email at: gpl@flexradio.com.
// Paper mail may be sent to: 
//    FlexRadio Systems
//    4616 W. Howard Lane  Suite 1-150
//    Austin, TX 78728
//    USA
//=================================================================

using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Reflection;
using System.Windows.Forms;

namespace KMSWITCH
{
    /// <summary>
    /// Summary description for WaveOptions.
    /// </summary>
    public class Setup : System.Windows.Forms.Form
    {

        public static Form1 form1;   //
        public CATParser parser; // ke9ns add: for CAT URL support

        #region Variable Declaration
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
        public ComboBox comboCATPort;
        public CheckBox chkCATEnable;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        public ComboBox comboCATbaud;
        public ComboBox comboCATparity;
        public ComboBox comboCATdatabits;
        public ComboBox comboCATstopbits;
        private Label label5;
        public CheckBox band630_1;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        public CheckBox band160_1;
        public CheckBox band80_1;
        public CheckBox band60_1;
        public CheckBox band40_1;
        public CheckBox band30_1;
        public CheckBox band6_1;
        public CheckBox band10_1;
        public CheckBox band12_1;
        public CheckBox band15_1;
        public CheckBox band17_1;
        public CheckBox band20_1;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        public CheckBox band2_1;
        public CheckBox band70_1;
        private Label label27;
        private Label label28;
        public Label label29;
        public Label label30;
        public Label label31;
        public Label label32;
        public Label label33;
        public Label label34;
        public CheckBox band70_2;
        public CheckBox band2_2;
        public CheckBox band6_2;
        public CheckBox band10_2;
        public CheckBox band12_2;
        public CheckBox band15_2;
        public CheckBox band17_2;
        public CheckBox band20_2;
        public CheckBox band30_2;
        public CheckBox band40_2;
        public CheckBox band60_2;
        public CheckBox band80_2;
        public CheckBox band160_2;
        public CheckBox band630_2;
        public CheckBox band70_3;
        public CheckBox band2_3;
        public CheckBox band6_3;
        public CheckBox band10_3;
        public CheckBox band12_3;
        public CheckBox band15_3;
        public CheckBox band17_3;
        public CheckBox band20_3;
        public CheckBox band30_3;
        public CheckBox band40_3;
        public CheckBox band60_3;
        public CheckBox band80_3;
        public CheckBox band160_3;
        public CheckBox band630_3;
        public CheckBox band70_4;
        public CheckBox band2_4;
        public CheckBox band6_4;
        public CheckBox band10_4;
        public CheckBox band12_4;
        public CheckBox band15_4;
        public CheckBox band17_4;
        public CheckBox band20_4;
        public CheckBox band30_4;
        public CheckBox band40_4;
        public CheckBox band60_4;
        public CheckBox band80_4;
        public CheckBox band160_4;
        public CheckBox band630_4;
        public CheckBox band70_5;
        public CheckBox band2_5;
        public CheckBox band6_5;
        public CheckBox band10_5;
        public CheckBox band12_5;
        public CheckBox band15_5;
        public CheckBox band17_5;
        public CheckBox band20_5;
        public CheckBox band30_5;
        public CheckBox band40_5;
        public CheckBox band60_5;
        public CheckBox band80_5;
        public CheckBox band160_5;
        public CheckBox band630_5;
        public CheckBox band70_6;
        public CheckBox band2_6;
        public CheckBox band6_6;
        public CheckBox band10_6;
        public CheckBox band12_6;
        public CheckBox band15_6;
        public CheckBox band17_6;
        public CheckBox band20_6;
        public CheckBox band30_6;
        public CheckBox band40_6;
        public CheckBox band60_6;
        public CheckBox band80_6;
        public CheckBox band160_6;
        public CheckBox band630_6;
        public CheckBox band70_7;
        public CheckBox band2_7;
        public CheckBox band6_7;
        public CheckBox band10_7;
        public CheckBox band12_7;
        public CheckBox band15_7;
        public CheckBox band17_7;
        public CheckBox band20_7;
        public CheckBox band30_7;
        public CheckBox band40_7;
        public CheckBox band60_7;
        public CheckBox band80_7;
        public CheckBox band160_7;
        public CheckBox band630_7;
        public CheckBox band70_8;
        public CheckBox band2_8;
        public CheckBox band6_8;
        public CheckBox band10_8;
        public CheckBox band12_8;
        public CheckBox band15_8;
        public CheckBox band17_8;
        public CheckBox band20_8;
        public CheckBox band30_8;
        public CheckBox band40_8;
        public CheckBox band60_8;
        public CheckBox band80_8;
        public CheckBox band160_8;
        public CheckBox band630_8;
        public Label label35;
        private Label label36;
        public CheckBox band_8;
        public CheckBox band_7;
        public CheckBox band_6;
        public CheckBox band_5;
        public CheckBox band_4;
        public CheckBox band_3;
        public CheckBox band_2;
        public CheckBox band_1;
        public TextBox URLaddress;
        public TextBox URLport;
        private Label label37;
        private Label label38;
        public TextBox URLuser;
        public TextBox URLpass;
        private Label label39;
        private Button button11;
        private Label label6;
      
      //  public static SpotControl SpotForm;                       // ke9ns add DX spotter function

        #endregion

        #region Constructor and Destructor

        public Setup(Form1 c)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //  Common.RestoreForm(this, "Setup", false);

            form1 = c;
            parser = new CATParser(form1);


            RefreshCOMPortLists();

            if (comboCATPort.Items.Count > 0) comboCATPort.SelectedIndex = 0;

          //  comboCATPort.Text = "COM10";
          //  comboCATbaud.Text = "56700";
            comboCATparity.Text = "none";
            comboCATdatabits.Text = "8";
            comboCATstopbits.Text = "1";

            if (comboCATPort.SelectedIndex < 0)
            {
                if (comboCATPort.Items.Count > 0) comboCATPort.SelectedIndex = 0;
                else
                {
                    chkCATEnable.Checked = false;
                    chkCATEnable.Enabled = false;
                }
            }

            if (chkCATEnable.Checked)
            {
              //  chkCATEnable_CheckedChanged(this, EventArgs.Empty);
            }

            if (comboCATPort.SelectedIndex >= 1)
                form1.CATPort = Int32.Parse(comboCATPort.Text.Substring(3));

            if (comboCATbaud.SelectedIndex >= 0)
                form1.CATBaudRate = Int32.Parse(comboCATbaud.Text);

                form1.CATParity = SDRSerialPort.StringToParity(comboCATparity.SelectedText);
                form1.CATDataBits = int.Parse(comboCATdatabits.Text);
                form1.CATStopBits = SDRSerialPort.StringToStopBits(comboCATstopbits.Text);
                form1.CATOn = chkCATEnable.Checked;


            this.TopMost = true; //.262
        } //setup

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboCATPort = new System.Windows.Forms.ComboBox();
            this.comboCATbaud = new System.Windows.Forms.ComboBox();
            this.URLaddress = new System.Windows.Forms.TextBox();
            this.URLport = new System.Windows.Forms.TextBox();
            this.URLuser = new System.Windows.Forms.TextBox();
            this.URLpass = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.chkCATEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCATparity = new System.Windows.Forms.ComboBox();
            this.comboCATdatabits = new System.Windows.Forms.ComboBox();
            this.comboCATstopbits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.band630_1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.band160_1 = new System.Windows.Forms.CheckBox();
            this.band80_1 = new System.Windows.Forms.CheckBox();
            this.band60_1 = new System.Windows.Forms.CheckBox();
            this.band40_1 = new System.Windows.Forms.CheckBox();
            this.band30_1 = new System.Windows.Forms.CheckBox();
            this.band6_1 = new System.Windows.Forms.CheckBox();
            this.band10_1 = new System.Windows.Forms.CheckBox();
            this.band12_1 = new System.Windows.Forms.CheckBox();
            this.band15_1 = new System.Windows.Forms.CheckBox();
            this.band17_1 = new System.Windows.Forms.CheckBox();
            this.band20_1 = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.band2_1 = new System.Windows.Forms.CheckBox();
            this.band70_1 = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.band70_2 = new System.Windows.Forms.CheckBox();
            this.band2_2 = new System.Windows.Forms.CheckBox();
            this.band6_2 = new System.Windows.Forms.CheckBox();
            this.band10_2 = new System.Windows.Forms.CheckBox();
            this.band12_2 = new System.Windows.Forms.CheckBox();
            this.band15_2 = new System.Windows.Forms.CheckBox();
            this.band17_2 = new System.Windows.Forms.CheckBox();
            this.band20_2 = new System.Windows.Forms.CheckBox();
            this.band30_2 = new System.Windows.Forms.CheckBox();
            this.band40_2 = new System.Windows.Forms.CheckBox();
            this.band60_2 = new System.Windows.Forms.CheckBox();
            this.band80_2 = new System.Windows.Forms.CheckBox();
            this.band160_2 = new System.Windows.Forms.CheckBox();
            this.band630_2 = new System.Windows.Forms.CheckBox();
            this.band70_3 = new System.Windows.Forms.CheckBox();
            this.band2_3 = new System.Windows.Forms.CheckBox();
            this.band6_3 = new System.Windows.Forms.CheckBox();
            this.band10_3 = new System.Windows.Forms.CheckBox();
            this.band12_3 = new System.Windows.Forms.CheckBox();
            this.band15_3 = new System.Windows.Forms.CheckBox();
            this.band17_3 = new System.Windows.Forms.CheckBox();
            this.band20_3 = new System.Windows.Forms.CheckBox();
            this.band30_3 = new System.Windows.Forms.CheckBox();
            this.band40_3 = new System.Windows.Forms.CheckBox();
            this.band60_3 = new System.Windows.Forms.CheckBox();
            this.band80_3 = new System.Windows.Forms.CheckBox();
            this.band160_3 = new System.Windows.Forms.CheckBox();
            this.band630_3 = new System.Windows.Forms.CheckBox();
            this.band70_4 = new System.Windows.Forms.CheckBox();
            this.band2_4 = new System.Windows.Forms.CheckBox();
            this.band6_4 = new System.Windows.Forms.CheckBox();
            this.band10_4 = new System.Windows.Forms.CheckBox();
            this.band12_4 = new System.Windows.Forms.CheckBox();
            this.band15_4 = new System.Windows.Forms.CheckBox();
            this.band17_4 = new System.Windows.Forms.CheckBox();
            this.band20_4 = new System.Windows.Forms.CheckBox();
            this.band30_4 = new System.Windows.Forms.CheckBox();
            this.band40_4 = new System.Windows.Forms.CheckBox();
            this.band60_4 = new System.Windows.Forms.CheckBox();
            this.band80_4 = new System.Windows.Forms.CheckBox();
            this.band160_4 = new System.Windows.Forms.CheckBox();
            this.band630_4 = new System.Windows.Forms.CheckBox();
            this.band70_5 = new System.Windows.Forms.CheckBox();
            this.band2_5 = new System.Windows.Forms.CheckBox();
            this.band6_5 = new System.Windows.Forms.CheckBox();
            this.band10_5 = new System.Windows.Forms.CheckBox();
            this.band12_5 = new System.Windows.Forms.CheckBox();
            this.band15_5 = new System.Windows.Forms.CheckBox();
            this.band17_5 = new System.Windows.Forms.CheckBox();
            this.band20_5 = new System.Windows.Forms.CheckBox();
            this.band30_5 = new System.Windows.Forms.CheckBox();
            this.band40_5 = new System.Windows.Forms.CheckBox();
            this.band60_5 = new System.Windows.Forms.CheckBox();
            this.band80_5 = new System.Windows.Forms.CheckBox();
            this.band160_5 = new System.Windows.Forms.CheckBox();
            this.band630_5 = new System.Windows.Forms.CheckBox();
            this.band70_6 = new System.Windows.Forms.CheckBox();
            this.band2_6 = new System.Windows.Forms.CheckBox();
            this.band6_6 = new System.Windows.Forms.CheckBox();
            this.band10_6 = new System.Windows.Forms.CheckBox();
            this.band12_6 = new System.Windows.Forms.CheckBox();
            this.band15_6 = new System.Windows.Forms.CheckBox();
            this.band17_6 = new System.Windows.Forms.CheckBox();
            this.band20_6 = new System.Windows.Forms.CheckBox();
            this.band30_6 = new System.Windows.Forms.CheckBox();
            this.band40_6 = new System.Windows.Forms.CheckBox();
            this.band60_6 = new System.Windows.Forms.CheckBox();
            this.band80_6 = new System.Windows.Forms.CheckBox();
            this.band160_6 = new System.Windows.Forms.CheckBox();
            this.band630_6 = new System.Windows.Forms.CheckBox();
            this.band70_7 = new System.Windows.Forms.CheckBox();
            this.band2_7 = new System.Windows.Forms.CheckBox();
            this.band6_7 = new System.Windows.Forms.CheckBox();
            this.band10_7 = new System.Windows.Forms.CheckBox();
            this.band12_7 = new System.Windows.Forms.CheckBox();
            this.band15_7 = new System.Windows.Forms.CheckBox();
            this.band17_7 = new System.Windows.Forms.CheckBox();
            this.band20_7 = new System.Windows.Forms.CheckBox();
            this.band30_7 = new System.Windows.Forms.CheckBox();
            this.band40_7 = new System.Windows.Forms.CheckBox();
            this.band60_7 = new System.Windows.Forms.CheckBox();
            this.band80_7 = new System.Windows.Forms.CheckBox();
            this.band160_7 = new System.Windows.Forms.CheckBox();
            this.band630_7 = new System.Windows.Forms.CheckBox();
            this.band70_8 = new System.Windows.Forms.CheckBox();
            this.band2_8 = new System.Windows.Forms.CheckBox();
            this.band6_8 = new System.Windows.Forms.CheckBox();
            this.band10_8 = new System.Windows.Forms.CheckBox();
            this.band12_8 = new System.Windows.Forms.CheckBox();
            this.band15_8 = new System.Windows.Forms.CheckBox();
            this.band17_8 = new System.Windows.Forms.CheckBox();
            this.band20_8 = new System.Windows.Forms.CheckBox();
            this.band30_8 = new System.Windows.Forms.CheckBox();
            this.band40_8 = new System.Windows.Forms.CheckBox();
            this.band60_8 = new System.Windows.Forms.CheckBox();
            this.band80_8 = new System.Windows.Forms.CheckBox();
            this.band160_8 = new System.Windows.Forms.CheckBox();
            this.band630_8 = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.band_8 = new System.Windows.Forms.CheckBox();
            this.band_7 = new System.Windows.Forms.CheckBox();
            this.band_6 = new System.Windows.Forms.CheckBox();
            this.band_5 = new System.Windows.Forms.CheckBox();
            this.band_4 = new System.Windows.Forms.CheckBox();
            this.band_3 = new System.Windows.Forms.CheckBox();
            this.band_2 = new System.Windows.Forms.CheckBox();
            this.band_1 = new System.Windows.Forms.CheckBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboCATPort
            // 
            this.comboCATPort.FormattingEnabled = true;
            this.comboCATPort.Location = new System.Drawing.Point(64, 47);
            this.comboCATPort.Name = "comboCATPort";
            this.comboCATPort.Size = new System.Drawing.Size(93, 21);
            this.comboCATPort.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboCATPort, "Serial port");
            this.comboCATPort.SelectedIndexChanged += new System.EventHandler(this.comboCATPort_SelectedIndexChanged);
            // 
            // comboCATbaud
            // 
            this.comboCATbaud.FormattingEnabled = true;
            this.comboCATbaud.Items.AddRange(new object[] {
            "300",
            "1200",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboCATbaud.Location = new System.Drawing.Point(64, 74);
            this.comboCATbaud.Name = "comboCATbaud";
            this.comboCATbaud.Size = new System.Drawing.Size(93, 21);
            this.comboCATbaud.TabIndex = 7;
            this.toolTip1.SetToolTip(this.comboCATbaud, "Baud Rate");
            this.comboCATbaud.SelectedIndexChanged += new System.EventHandler(this.comboCATbaud_SelectedIndexChanged);
            // 
            // URLaddress
            // 
            this.URLaddress.Location = new System.Drawing.Point(12, 235);
            this.URLaddress.MaxLength = 30;
            this.URLaddress.Name = "URLaddress";
            this.URLaddress.Size = new System.Drawing.Size(193, 20);
            this.URLaddress.TabIndex = 261;
            this.toolTip1.SetToolTip(this.URLaddress, "Select the URL address \r\nNo HTTP\r\nExamples:\r\n192.168.0.125 or\r\nddd.ddns.net ");
            this.URLaddress.WordWrap = false;
            this.URLaddress.TextChanged += new System.EventHandler(this.URLaddress_TextChanged);
            // 
            // URLport
            // 
            this.URLport.Location = new System.Drawing.Point(12, 284);
            this.URLport.Name = "URLport";
            this.URLport.Size = new System.Drawing.Size(62, 20);
            this.URLport.TabIndex = 262;
            this.toolTip1.SetToolTip(this.URLport, "Port to allow DDNS access through your Router");
            this.URLport.TextChanged += new System.EventHandler(this.URLport_TextChanged);
            // 
            // URLuser
            // 
            this.URLuser.Location = new System.Drawing.Point(12, 341);
            this.URLuser.Name = "URLuser";
            this.URLuser.Size = new System.Drawing.Size(99, 20);
            this.URLuser.TabIndex = 265;
            this.toolTip1.SetToolTip(this.URLuser, "Port to allow DDNS access through your Router");
            this.URLuser.TextChanged += new System.EventHandler(this.URLuser_TextChanged);
            // 
            // URLpass
            // 
            this.URLpass.Location = new System.Drawing.Point(12, 367);
            this.URLpass.Name = "URLpass";
            this.URLpass.Size = new System.Drawing.Size(99, 20);
            this.URLpass.TabIndex = 266;
            this.toolTip1.SetToolTip(this.URLpass, "Port to allow DDNS access through your Router");
            this.URLpass.TextChanged += new System.EventHandler(this.URLpass_TextChanged);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(125, 432);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(71, 19);
            this.button11.TabIndex = 268;
            this.button11.Text = "Update";
            this.toolTip1.SetToolTip(this.button11, "Adjust the URL and Port values \r\nthen CLICK to try and connect now.");
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // chkCATEnable
            // 
            this.chkCATEnable.AutoSize = true;
            this.chkCATEnable.Location = new System.Drawing.Point(178, 18);
            this.chkCATEnable.Name = "chkCATEnable";
            this.chkCATEnable.Size = new System.Drawing.Size(42, 17);
            this.chkCATEnable.TabIndex = 1;
            this.chkCATEnable.Text = "ON";
            this.chkCATEnable.UseVisualStyleBackColor = true;
            this.chkCATEnable.CheckedChanged += new System.EventHandler(this.chkCATEnable_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Baud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stop";
            // 
            // comboCATparity
            // 
            this.comboCATparity.FormattingEnabled = true;
            this.comboCATparity.Items.AddRange(new object[] {
            "none",
            "odd",
            "even",
            "mark",
            "space"});
            this.comboCATparity.Location = new System.Drawing.Point(64, 101);
            this.comboCATparity.Name = "comboCATparity";
            this.comboCATparity.Size = new System.Drawing.Size(93, 21);
            this.comboCATparity.TabIndex = 8;
            this.comboCATparity.Text = "none";
            this.comboCATparity.SelectedIndexChanged += new System.EventHandler(this.comboCATparity_SelectedIndexChanged);
            // 
            // comboCATdatabits
            // 
            this.comboCATdatabits.FormattingEnabled = true;
            this.comboCATdatabits.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
            this.comboCATdatabits.Location = new System.Drawing.Point(64, 128);
            this.comboCATdatabits.Name = "comboCATdatabits";
            this.comboCATdatabits.Size = new System.Drawing.Size(93, 21);
            this.comboCATdatabits.TabIndex = 9;
            this.comboCATdatabits.Text = "8";
            this.comboCATdatabits.SelectedIndexChanged += new System.EventHandler(this.comboCATdatabits_SelectedIndexChanged);
            // 
            // comboCATstopbits
            // 
            this.comboCATstopbits.FormattingEnabled = true;
            this.comboCATstopbits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboCATstopbits.Location = new System.Drawing.Point(64, 155);
            this.comboCATstopbits.Name = "comboCATstopbits";
            this.comboCATstopbits.Size = new System.Drawing.Size(93, 21);
            this.comboCATstopbits.TabIndex = 10;
            this.comboCATstopbits.Text = "1";
            this.comboCATstopbits.SelectedIndexChanged += new System.EventHandler(this.comboCATstopbits_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Com#";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cat Control Com port";
            // 
            // band630_1
            // 
            this.band630_1.AutoSize = true;
            this.band630_1.Location = new System.Drawing.Point(281, 54);
            this.band630_1.Name = "band630_1";
            this.band630_1.Size = new System.Drawing.Size(15, 14);
            this.band630_1.TabIndex = 13;
            this.band630_1.UseVisualStyleBackColor = true;
            this.band630_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ant1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(329, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ant2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(392, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ant3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(449, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Ant4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(502, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Ant5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(548, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Ant6";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(603, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Ant7";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(654, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Ant8";
            // 
            // band160_1
            // 
            this.band160_1.AutoSize = true;
            this.band160_1.Location = new System.Drawing.Point(281, 81);
            this.band160_1.Name = "band160_1";
            this.band160_1.Size = new System.Drawing.Size(15, 14);
            this.band160_1.TabIndex = 22;
            this.band160_1.UseVisualStyleBackColor = true;
            this.band160_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band80_1
            // 
            this.band80_1.AutoSize = true;
            this.band80_1.Location = new System.Drawing.Point(281, 104);
            this.band80_1.Name = "band80_1";
            this.band80_1.Size = new System.Drawing.Size(15, 14);
            this.band80_1.TabIndex = 23;
            this.band80_1.UseVisualStyleBackColor = true;
            this.band80_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band60_1
            // 
            this.band60_1.AutoSize = true;
            this.band60_1.Location = new System.Drawing.Point(281, 130);
            this.band60_1.Name = "band60_1";
            this.band60_1.Size = new System.Drawing.Size(15, 14);
            this.band60_1.TabIndex = 24;
            this.band60_1.UseVisualStyleBackColor = true;
            this.band60_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band40_1
            // 
            this.band40_1.AutoSize = true;
            this.band40_1.Location = new System.Drawing.Point(281, 157);
            this.band40_1.Name = "band40_1";
            this.band40_1.Size = new System.Drawing.Size(15, 14);
            this.band40_1.TabIndex = 25;
            this.band40_1.UseVisualStyleBackColor = true;
            this.band40_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band30_1
            // 
            this.band30_1.AutoSize = true;
            this.band30_1.Location = new System.Drawing.Point(281, 186);
            this.band30_1.Name = "band30_1";
            this.band30_1.Size = new System.Drawing.Size(15, 14);
            this.band30_1.TabIndex = 26;
            this.band30_1.UseVisualStyleBackColor = true;
            this.band30_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band6_1
            // 
            this.band6_1.AutoSize = true;
            this.band6_1.Location = new System.Drawing.Point(281, 347);
            this.band6_1.Name = "band6_1";
            this.band6_1.Size = new System.Drawing.Size(15, 14);
            this.band6_1.TabIndex = 32;
            this.band6_1.UseVisualStyleBackColor = true;
            this.band6_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band10_1
            // 
            this.band10_1.AutoSize = true;
            this.band10_1.Location = new System.Drawing.Point(281, 318);
            this.band10_1.Name = "band10_1";
            this.band10_1.Size = new System.Drawing.Size(15, 14);
            this.band10_1.TabIndex = 31;
            this.band10_1.UseVisualStyleBackColor = true;
            this.band10_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band12_1
            // 
            this.band12_1.AutoSize = true;
            this.band12_1.Location = new System.Drawing.Point(281, 291);
            this.band12_1.Name = "band12_1";
            this.band12_1.Size = new System.Drawing.Size(15, 14);
            this.band12_1.TabIndex = 30;
            this.band12_1.UseVisualStyleBackColor = true;
            this.band12_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band15_1
            // 
            this.band15_1.AutoSize = true;
            this.band15_1.Location = new System.Drawing.Point(281, 265);
            this.band15_1.Name = "band15_1";
            this.band15_1.Size = new System.Drawing.Size(15, 14);
            this.band15_1.TabIndex = 29;
            this.band15_1.UseVisualStyleBackColor = true;
            this.band15_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band17_1
            // 
            this.band17_1.AutoSize = true;
            this.band17_1.Location = new System.Drawing.Point(281, 242);
            this.band17_1.Name = "band17_1";
            this.band17_1.Size = new System.Drawing.Size(15, 14);
            this.band17_1.TabIndex = 28;
            this.band17_1.UseVisualStyleBackColor = true;
            this.band17_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band20_1
            // 
            this.band20_1.AutoSize = true;
            this.band20_1.Location = new System.Drawing.Point(281, 215);
            this.band20_1.Name = "band20_1";
            this.band20_1.Size = new System.Drawing.Size(15, 14);
            this.band20_1.TabIndex = 27;
            this.band20_1.UseVisualStyleBackColor = true;
            this.band20_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(242, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "630m";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(242, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "160m";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(246, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "80m";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(246, 131);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 36;
            this.label18.Text = "60m";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(246, 157);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "40m";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(246, 187);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(27, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "30m";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(246, 215);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(27, 13);
            this.label21.TabIndex = 39;
            this.label21.Text = "20m";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(246, 242);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 13);
            this.label22.TabIndex = 40;
            this.label22.Text = "17m";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(246, 265);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(27, 13);
            this.label23.TabIndex = 41;
            this.label23.Text = "15m";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(246, 291);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(27, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "12m";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(246, 319);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(27, 13);
            this.label25.TabIndex = 43;
            this.label25.Text = "10m";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(252, 348);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(21, 13);
            this.label26.TabIndex = 44;
            this.label26.Text = "6m";
            // 
            // band2_1
            // 
            this.band2_1.AutoSize = true;
            this.band2_1.Location = new System.Drawing.Point(281, 377);
            this.band2_1.Name = "band2_1";
            this.band2_1.Size = new System.Drawing.Size(15, 14);
            this.band2_1.TabIndex = 45;
            this.band2_1.UseVisualStyleBackColor = true;
            this.band2_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band70_1
            // 
            this.band70_1.AutoSize = true;
            this.band70_1.Location = new System.Drawing.Point(281, 407);
            this.band70_1.Name = "band70_1";
            this.band70_1.Size = new System.Drawing.Size(15, 14);
            this.band70_1.TabIndex = 46;
            this.band70_1.UseVisualStyleBackColor = true;
            this.band70_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(254, 377);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(21, 13);
            this.label27.TabIndex = 47;
            this.label27.Text = "2m";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(242, 408);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(33, 13);
            this.label28.TabIndex = 48;
            this.label28.Text = "70cm";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(211, 92);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(490, 13);
            this.label29.TabIndex = 147;
            this.label29.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(211, 142);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(490, 13);
            this.label30.TabIndex = 148;
            this.label30.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(211, 200);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(490, 13);
            this.label31.TabIndex = 149;
            this.label31.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(211, 252);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(490, 13);
            this.label32.TabIndex = 150;
            this.label32.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(211, 306);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(490, 13);
            this.label33.TabIndex = 151;
            this.label33.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(211, 365);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(490, 13);
            this.label34.TabIndex = 152;
            this.label34.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "";
            // 
            // band70_2
            // 
            this.band70_2.AutoSize = true;
            this.band70_2.Location = new System.Drawing.Point(332, 408);
            this.band70_2.Name = "band70_2";
            this.band70_2.Size = new System.Drawing.Size(15, 14);
            this.band70_2.TabIndex = 166;
            this.band70_2.UseVisualStyleBackColor = true;
            this.band70_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band2_2
            // 
            this.band2_2.AutoSize = true;
            this.band2_2.Location = new System.Drawing.Point(332, 378);
            this.band2_2.Name = "band2_2";
            this.band2_2.Size = new System.Drawing.Size(15, 14);
            this.band2_2.TabIndex = 165;
            this.band2_2.UseVisualStyleBackColor = true;
            this.band2_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band6_2
            // 
            this.band6_2.AutoSize = true;
            this.band6_2.Location = new System.Drawing.Point(332, 348);
            this.band6_2.Name = "band6_2";
            this.band6_2.Size = new System.Drawing.Size(15, 14);
            this.band6_2.TabIndex = 164;
            this.band6_2.UseVisualStyleBackColor = true;
            this.band6_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band10_2
            // 
            this.band10_2.AutoSize = true;
            this.band10_2.Location = new System.Drawing.Point(332, 319);
            this.band10_2.Name = "band10_2";
            this.band10_2.Size = new System.Drawing.Size(15, 14);
            this.band10_2.TabIndex = 163;
            this.band10_2.UseVisualStyleBackColor = true;
            this.band10_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band12_2
            // 
            this.band12_2.AutoSize = true;
            this.band12_2.Location = new System.Drawing.Point(332, 292);
            this.band12_2.Name = "band12_2";
            this.band12_2.Size = new System.Drawing.Size(15, 14);
            this.band12_2.TabIndex = 162;
            this.band12_2.UseVisualStyleBackColor = true;
            this.band12_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band15_2
            // 
            this.band15_2.AutoSize = true;
            this.band15_2.Location = new System.Drawing.Point(332, 266);
            this.band15_2.Name = "band15_2";
            this.band15_2.Size = new System.Drawing.Size(15, 14);
            this.band15_2.TabIndex = 161;
            this.band15_2.UseVisualStyleBackColor = true;
            this.band15_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band17_2
            // 
            this.band17_2.AutoSize = true;
            this.band17_2.Location = new System.Drawing.Point(332, 243);
            this.band17_2.Name = "band17_2";
            this.band17_2.Size = new System.Drawing.Size(15, 14);
            this.band17_2.TabIndex = 160;
            this.band17_2.UseVisualStyleBackColor = true;
            this.band17_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band20_2
            // 
            this.band20_2.AutoSize = true;
            this.band20_2.Location = new System.Drawing.Point(332, 216);
            this.band20_2.Name = "band20_2";
            this.band20_2.Size = new System.Drawing.Size(15, 14);
            this.band20_2.TabIndex = 159;
            this.band20_2.UseVisualStyleBackColor = true;
            this.band20_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band30_2
            // 
            this.band30_2.AutoSize = true;
            this.band30_2.Location = new System.Drawing.Point(332, 187);
            this.band30_2.Name = "band30_2";
            this.band30_2.Size = new System.Drawing.Size(15, 14);
            this.band30_2.TabIndex = 158;
            this.band30_2.UseVisualStyleBackColor = true;
            this.band30_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band40_2
            // 
            this.band40_2.AutoSize = true;
            this.band40_2.Location = new System.Drawing.Point(332, 158);
            this.band40_2.Name = "band40_2";
            this.band40_2.Size = new System.Drawing.Size(15, 14);
            this.band40_2.TabIndex = 157;
            this.band40_2.UseVisualStyleBackColor = true;
            this.band40_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band60_2
            // 
            this.band60_2.AutoSize = true;
            this.band60_2.Location = new System.Drawing.Point(332, 131);
            this.band60_2.Name = "band60_2";
            this.band60_2.Size = new System.Drawing.Size(15, 14);
            this.band60_2.TabIndex = 156;
            this.band60_2.UseVisualStyleBackColor = true;
            this.band60_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band80_2
            // 
            this.band80_2.AutoSize = true;
            this.band80_2.Location = new System.Drawing.Point(332, 105);
            this.band80_2.Name = "band80_2";
            this.band80_2.Size = new System.Drawing.Size(15, 14);
            this.band80_2.TabIndex = 155;
            this.band80_2.UseVisualStyleBackColor = true;
            this.band80_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band160_2
            // 
            this.band160_2.AutoSize = true;
            this.band160_2.Location = new System.Drawing.Point(332, 82);
            this.band160_2.Name = "band160_2";
            this.band160_2.Size = new System.Drawing.Size(15, 14);
            this.band160_2.TabIndex = 154;
            this.band160_2.UseVisualStyleBackColor = true;
            this.band160_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band630_2
            // 
            this.band630_2.AutoSize = true;
            this.band630_2.Location = new System.Drawing.Point(332, 55);
            this.band630_2.Name = "band630_2";
            this.band630_2.Size = new System.Drawing.Size(15, 14);
            this.band630_2.TabIndex = 153;
            this.band630_2.UseVisualStyleBackColor = true;
            this.band630_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band70_3
            // 
            this.band70_3.AutoSize = true;
            this.band70_3.Location = new System.Drawing.Point(395, 408);
            this.band70_3.Name = "band70_3";
            this.band70_3.Size = new System.Drawing.Size(15, 14);
            this.band70_3.TabIndex = 180;
            this.band70_3.UseVisualStyleBackColor = true;
            this.band70_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band2_3
            // 
            this.band2_3.AutoSize = true;
            this.band2_3.Location = new System.Drawing.Point(395, 378);
            this.band2_3.Name = "band2_3";
            this.band2_3.Size = new System.Drawing.Size(15, 14);
            this.band2_3.TabIndex = 179;
            this.band2_3.UseVisualStyleBackColor = true;
            this.band2_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band6_3
            // 
            this.band6_3.AutoSize = true;
            this.band6_3.Location = new System.Drawing.Point(395, 348);
            this.band6_3.Name = "band6_3";
            this.band6_3.Size = new System.Drawing.Size(15, 14);
            this.band6_3.TabIndex = 178;
            this.band6_3.UseVisualStyleBackColor = true;
            this.band6_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band10_3
            // 
            this.band10_3.AutoSize = true;
            this.band10_3.Location = new System.Drawing.Point(395, 319);
            this.band10_3.Name = "band10_3";
            this.band10_3.Size = new System.Drawing.Size(15, 14);
            this.band10_3.TabIndex = 177;
            this.band10_3.UseVisualStyleBackColor = true;
            this.band10_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band12_3
            // 
            this.band12_3.AutoSize = true;
            this.band12_3.Location = new System.Drawing.Point(395, 292);
            this.band12_3.Name = "band12_3";
            this.band12_3.Size = new System.Drawing.Size(15, 14);
            this.band12_3.TabIndex = 176;
            this.band12_3.UseVisualStyleBackColor = true;
            this.band12_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band15_3
            // 
            this.band15_3.AutoSize = true;
            this.band15_3.Location = new System.Drawing.Point(395, 266);
            this.band15_3.Name = "band15_3";
            this.band15_3.Size = new System.Drawing.Size(15, 14);
            this.band15_3.TabIndex = 175;
            this.band15_3.UseVisualStyleBackColor = true;
            this.band15_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band17_3
            // 
            this.band17_3.AutoSize = true;
            this.band17_3.Location = new System.Drawing.Point(395, 243);
            this.band17_3.Name = "band17_3";
            this.band17_3.Size = new System.Drawing.Size(15, 14);
            this.band17_3.TabIndex = 174;
            this.band17_3.UseVisualStyleBackColor = true;
            this.band17_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band20_3
            // 
            this.band20_3.AutoSize = true;
            this.band20_3.Location = new System.Drawing.Point(395, 216);
            this.band20_3.Name = "band20_3";
            this.band20_3.Size = new System.Drawing.Size(15, 14);
            this.band20_3.TabIndex = 173;
            this.band20_3.UseVisualStyleBackColor = true;
            this.band20_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band30_3
            // 
            this.band30_3.AutoSize = true;
            this.band30_3.Location = new System.Drawing.Point(395, 187);
            this.band30_3.Name = "band30_3";
            this.band30_3.Size = new System.Drawing.Size(15, 14);
            this.band30_3.TabIndex = 172;
            this.band30_3.UseVisualStyleBackColor = true;
            this.band30_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band40_3
            // 
            this.band40_3.AutoSize = true;
            this.band40_3.Location = new System.Drawing.Point(395, 158);
            this.band40_3.Name = "band40_3";
            this.band40_3.Size = new System.Drawing.Size(15, 14);
            this.band40_3.TabIndex = 171;
            this.band40_3.UseVisualStyleBackColor = true;
            this.band40_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band60_3
            // 
            this.band60_3.AutoSize = true;
            this.band60_3.Location = new System.Drawing.Point(395, 131);
            this.band60_3.Name = "band60_3";
            this.band60_3.Size = new System.Drawing.Size(15, 14);
            this.band60_3.TabIndex = 170;
            this.band60_3.UseVisualStyleBackColor = true;
            this.band60_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band80_3
            // 
            this.band80_3.AutoSize = true;
            this.band80_3.Location = new System.Drawing.Point(395, 105);
            this.band80_3.Name = "band80_3";
            this.band80_3.Size = new System.Drawing.Size(15, 14);
            this.band80_3.TabIndex = 169;
            this.band80_3.UseVisualStyleBackColor = true;
            this.band80_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band160_3
            // 
            this.band160_3.AutoSize = true;
            this.band160_3.Location = new System.Drawing.Point(395, 82);
            this.band160_3.Name = "band160_3";
            this.band160_3.Size = new System.Drawing.Size(15, 14);
            this.band160_3.TabIndex = 168;
            this.band160_3.UseVisualStyleBackColor = true;
            this.band160_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band630_3
            // 
            this.band630_3.AutoSize = true;
            this.band630_3.Location = new System.Drawing.Point(395, 55);
            this.band630_3.Name = "band630_3";
            this.band630_3.Size = new System.Drawing.Size(15, 14);
            this.band630_3.TabIndex = 167;
            this.band630_3.UseVisualStyleBackColor = true;
            this.band630_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band70_4
            // 
            this.band70_4.AutoSize = true;
            this.band70_4.Location = new System.Drawing.Point(452, 408);
            this.band70_4.Name = "band70_4";
            this.band70_4.Size = new System.Drawing.Size(15, 14);
            this.band70_4.TabIndex = 194;
            this.band70_4.UseVisualStyleBackColor = true;
            this.band70_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band2_4
            // 
            this.band2_4.AutoSize = true;
            this.band2_4.Location = new System.Drawing.Point(452, 378);
            this.band2_4.Name = "band2_4";
            this.band2_4.Size = new System.Drawing.Size(15, 14);
            this.band2_4.TabIndex = 193;
            this.band2_4.UseVisualStyleBackColor = true;
            this.band2_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band6_4
            // 
            this.band6_4.AutoSize = true;
            this.band6_4.Location = new System.Drawing.Point(452, 348);
            this.band6_4.Name = "band6_4";
            this.band6_4.Size = new System.Drawing.Size(15, 14);
            this.band6_4.TabIndex = 192;
            this.band6_4.UseVisualStyleBackColor = true;
            this.band6_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band10_4
            // 
            this.band10_4.AutoSize = true;
            this.band10_4.Location = new System.Drawing.Point(452, 319);
            this.band10_4.Name = "band10_4";
            this.band10_4.Size = new System.Drawing.Size(15, 14);
            this.band10_4.TabIndex = 191;
            this.band10_4.UseVisualStyleBackColor = true;
            this.band10_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band12_4
            // 
            this.band12_4.AutoSize = true;
            this.band12_4.Location = new System.Drawing.Point(452, 292);
            this.band12_4.Name = "band12_4";
            this.band12_4.Size = new System.Drawing.Size(15, 14);
            this.band12_4.TabIndex = 190;
            this.band12_4.UseVisualStyleBackColor = true;
            this.band12_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band15_4
            // 
            this.band15_4.AutoSize = true;
            this.band15_4.Location = new System.Drawing.Point(452, 266);
            this.band15_4.Name = "band15_4";
            this.band15_4.Size = new System.Drawing.Size(15, 14);
            this.band15_4.TabIndex = 189;
            this.band15_4.UseVisualStyleBackColor = true;
            this.band15_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band17_4
            // 
            this.band17_4.AutoSize = true;
            this.band17_4.Location = new System.Drawing.Point(452, 243);
            this.band17_4.Name = "band17_4";
            this.band17_4.Size = new System.Drawing.Size(15, 14);
            this.band17_4.TabIndex = 188;
            this.band17_4.UseVisualStyleBackColor = true;
            this.band17_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band20_4
            // 
            this.band20_4.AutoSize = true;
            this.band20_4.Location = new System.Drawing.Point(452, 216);
            this.band20_4.Name = "band20_4";
            this.band20_4.Size = new System.Drawing.Size(15, 14);
            this.band20_4.TabIndex = 187;
            this.band20_4.UseVisualStyleBackColor = true;
            this.band20_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band30_4
            // 
            this.band30_4.AutoSize = true;
            this.band30_4.Location = new System.Drawing.Point(452, 187);
            this.band30_4.Name = "band30_4";
            this.band30_4.Size = new System.Drawing.Size(15, 14);
            this.band30_4.TabIndex = 186;
            this.band30_4.UseVisualStyleBackColor = true;
            this.band30_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band40_4
            // 
            this.band40_4.AutoSize = true;
            this.band40_4.Location = new System.Drawing.Point(452, 158);
            this.band40_4.Name = "band40_4";
            this.band40_4.Size = new System.Drawing.Size(15, 14);
            this.band40_4.TabIndex = 185;
            this.band40_4.UseVisualStyleBackColor = true;
            this.band40_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band60_4
            // 
            this.band60_4.AutoSize = true;
            this.band60_4.Location = new System.Drawing.Point(452, 131);
            this.band60_4.Name = "band60_4";
            this.band60_4.Size = new System.Drawing.Size(15, 14);
            this.band60_4.TabIndex = 184;
            this.band60_4.UseVisualStyleBackColor = true;
            this.band60_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band80_4
            // 
            this.band80_4.AutoSize = true;
            this.band80_4.Location = new System.Drawing.Point(452, 105);
            this.band80_4.Name = "band80_4";
            this.band80_4.Size = new System.Drawing.Size(15, 14);
            this.band80_4.TabIndex = 183;
            this.band80_4.UseVisualStyleBackColor = true;
            this.band80_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band160_4
            // 
            this.band160_4.AutoSize = true;
            this.band160_4.Location = new System.Drawing.Point(452, 82);
            this.band160_4.Name = "band160_4";
            this.band160_4.Size = new System.Drawing.Size(15, 14);
            this.band160_4.TabIndex = 182;
            this.band160_4.UseVisualStyleBackColor = true;
            this.band160_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band630_4
            // 
            this.band630_4.AutoSize = true;
            this.band630_4.Location = new System.Drawing.Point(452, 55);
            this.band630_4.Name = "band630_4";
            this.band630_4.Size = new System.Drawing.Size(15, 14);
            this.band630_4.TabIndex = 181;
            this.band630_4.UseVisualStyleBackColor = true;
            this.band630_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band70_5
            // 
            this.band70_5.AutoSize = true;
            this.band70_5.Location = new System.Drawing.Point(505, 408);
            this.band70_5.Name = "band70_5";
            this.band70_5.Size = new System.Drawing.Size(15, 14);
            this.band70_5.TabIndex = 208;
            this.band70_5.UseVisualStyleBackColor = true;
            this.band70_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band2_5
            // 
            this.band2_5.AutoSize = true;
            this.band2_5.Location = new System.Drawing.Point(505, 378);
            this.band2_5.Name = "band2_5";
            this.band2_5.Size = new System.Drawing.Size(15, 14);
            this.band2_5.TabIndex = 207;
            this.band2_5.UseVisualStyleBackColor = true;
            this.band2_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band6_5
            // 
            this.band6_5.AutoSize = true;
            this.band6_5.Location = new System.Drawing.Point(505, 348);
            this.band6_5.Name = "band6_5";
            this.band6_5.Size = new System.Drawing.Size(15, 14);
            this.band6_5.TabIndex = 206;
            this.band6_5.UseVisualStyleBackColor = true;
            this.band6_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band10_5
            // 
            this.band10_5.AutoSize = true;
            this.band10_5.Location = new System.Drawing.Point(505, 319);
            this.band10_5.Name = "band10_5";
            this.band10_5.Size = new System.Drawing.Size(15, 14);
            this.band10_5.TabIndex = 205;
            this.band10_5.UseVisualStyleBackColor = true;
            this.band10_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band12_5
            // 
            this.band12_5.AutoSize = true;
            this.band12_5.Location = new System.Drawing.Point(505, 292);
            this.band12_5.Name = "band12_5";
            this.band12_5.Size = new System.Drawing.Size(15, 14);
            this.band12_5.TabIndex = 204;
            this.band12_5.UseVisualStyleBackColor = true;
            this.band12_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band15_5
            // 
            this.band15_5.AutoSize = true;
            this.band15_5.Location = new System.Drawing.Point(505, 266);
            this.band15_5.Name = "band15_5";
            this.band15_5.Size = new System.Drawing.Size(15, 14);
            this.band15_5.TabIndex = 203;
            this.band15_5.UseVisualStyleBackColor = true;
            this.band15_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band17_5
            // 
            this.band17_5.AutoSize = true;
            this.band17_5.Location = new System.Drawing.Point(505, 243);
            this.band17_5.Name = "band17_5";
            this.band17_5.Size = new System.Drawing.Size(15, 14);
            this.band17_5.TabIndex = 202;
            this.band17_5.UseVisualStyleBackColor = true;
            this.band17_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band20_5
            // 
            this.band20_5.AutoSize = true;
            this.band20_5.Location = new System.Drawing.Point(505, 216);
            this.band20_5.Name = "band20_5";
            this.band20_5.Size = new System.Drawing.Size(15, 14);
            this.band20_5.TabIndex = 201;
            this.band20_5.UseVisualStyleBackColor = true;
            this.band20_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band30_5
            // 
            this.band30_5.AutoSize = true;
            this.band30_5.Location = new System.Drawing.Point(505, 187);
            this.band30_5.Name = "band30_5";
            this.band30_5.Size = new System.Drawing.Size(15, 14);
            this.band30_5.TabIndex = 200;
            this.band30_5.UseVisualStyleBackColor = true;
            this.band30_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band40_5
            // 
            this.band40_5.AutoSize = true;
            this.band40_5.Location = new System.Drawing.Point(505, 158);
            this.band40_5.Name = "band40_5";
            this.band40_5.Size = new System.Drawing.Size(15, 14);
            this.band40_5.TabIndex = 199;
            this.band40_5.UseVisualStyleBackColor = true;
            this.band40_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band60_5
            // 
            this.band60_5.AutoSize = true;
            this.band60_5.Location = new System.Drawing.Point(505, 131);
            this.band60_5.Name = "band60_5";
            this.band60_5.Size = new System.Drawing.Size(15, 14);
            this.band60_5.TabIndex = 198;
            this.band60_5.UseVisualStyleBackColor = true;
            this.band60_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band80_5
            // 
            this.band80_5.AutoSize = true;
            this.band80_5.Location = new System.Drawing.Point(505, 105);
            this.band80_5.Name = "band80_5";
            this.band80_5.Size = new System.Drawing.Size(15, 14);
            this.band80_5.TabIndex = 197;
            this.band80_5.UseVisualStyleBackColor = true;
            this.band80_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band160_5
            // 
            this.band160_5.AutoSize = true;
            this.band160_5.Location = new System.Drawing.Point(505, 82);
            this.band160_5.Name = "band160_5";
            this.band160_5.Size = new System.Drawing.Size(15, 14);
            this.band160_5.TabIndex = 196;
            this.band160_5.UseVisualStyleBackColor = true;
            this.band160_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band630_5
            // 
            this.band630_5.AutoSize = true;
            this.band630_5.Location = new System.Drawing.Point(505, 55);
            this.band630_5.Name = "band630_5";
            this.band630_5.Size = new System.Drawing.Size(15, 14);
            this.band630_5.TabIndex = 195;
            this.band630_5.UseVisualStyleBackColor = true;
            this.band630_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band70_6
            // 
            this.band70_6.AutoSize = true;
            this.band70_6.Location = new System.Drawing.Point(551, 408);
            this.band70_6.Name = "band70_6";
            this.band70_6.Size = new System.Drawing.Size(15, 14);
            this.band70_6.TabIndex = 222;
            this.band70_6.UseVisualStyleBackColor = true;
            this.band70_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band2_6
            // 
            this.band2_6.AutoSize = true;
            this.band2_6.Location = new System.Drawing.Point(551, 378);
            this.band2_6.Name = "band2_6";
            this.band2_6.Size = new System.Drawing.Size(15, 14);
            this.band2_6.TabIndex = 221;
            this.band2_6.UseVisualStyleBackColor = true;
            this.band2_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band6_6
            // 
            this.band6_6.AutoSize = true;
            this.band6_6.Location = new System.Drawing.Point(551, 348);
            this.band6_6.Name = "band6_6";
            this.band6_6.Size = new System.Drawing.Size(15, 14);
            this.band6_6.TabIndex = 220;
            this.band6_6.UseVisualStyleBackColor = true;
            this.band6_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band10_6
            // 
            this.band10_6.AutoSize = true;
            this.band10_6.Location = new System.Drawing.Point(551, 319);
            this.band10_6.Name = "band10_6";
            this.band10_6.Size = new System.Drawing.Size(15, 14);
            this.band10_6.TabIndex = 219;
            this.band10_6.UseVisualStyleBackColor = true;
            this.band10_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band12_6
            // 
            this.band12_6.AutoSize = true;
            this.band12_6.Location = new System.Drawing.Point(551, 292);
            this.band12_6.Name = "band12_6";
            this.band12_6.Size = new System.Drawing.Size(15, 14);
            this.band12_6.TabIndex = 218;
            this.band12_6.UseVisualStyleBackColor = true;
            this.band12_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band15_6
            // 
            this.band15_6.AutoSize = true;
            this.band15_6.Location = new System.Drawing.Point(551, 266);
            this.band15_6.Name = "band15_6";
            this.band15_6.Size = new System.Drawing.Size(15, 14);
            this.band15_6.TabIndex = 217;
            this.band15_6.UseVisualStyleBackColor = true;
            this.band15_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band17_6
            // 
            this.band17_6.AutoSize = true;
            this.band17_6.Location = new System.Drawing.Point(551, 243);
            this.band17_6.Name = "band17_6";
            this.band17_6.Size = new System.Drawing.Size(15, 14);
            this.band17_6.TabIndex = 216;
            this.band17_6.UseVisualStyleBackColor = true;
            this.band17_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band20_6
            // 
            this.band20_6.AutoSize = true;
            this.band20_6.Location = new System.Drawing.Point(551, 216);
            this.band20_6.Name = "band20_6";
            this.band20_6.Size = new System.Drawing.Size(15, 14);
            this.band20_6.TabIndex = 215;
            this.band20_6.UseVisualStyleBackColor = true;
            this.band20_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band30_6
            // 
            this.band30_6.AutoSize = true;
            this.band30_6.Location = new System.Drawing.Point(551, 187);
            this.band30_6.Name = "band30_6";
            this.band30_6.Size = new System.Drawing.Size(15, 14);
            this.band30_6.TabIndex = 214;
            this.band30_6.UseVisualStyleBackColor = true;
            this.band30_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band40_6
            // 
            this.band40_6.AutoSize = true;
            this.band40_6.Location = new System.Drawing.Point(551, 158);
            this.band40_6.Name = "band40_6";
            this.band40_6.Size = new System.Drawing.Size(15, 14);
            this.band40_6.TabIndex = 213;
            this.band40_6.UseVisualStyleBackColor = true;
            this.band40_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band60_6
            // 
            this.band60_6.AutoSize = true;
            this.band60_6.Location = new System.Drawing.Point(551, 131);
            this.band60_6.Name = "band60_6";
            this.band60_6.Size = new System.Drawing.Size(15, 14);
            this.band60_6.TabIndex = 212;
            this.band60_6.UseVisualStyleBackColor = true;
            this.band60_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band80_6
            // 
            this.band80_6.AutoSize = true;
            this.band80_6.Location = new System.Drawing.Point(551, 105);
            this.band80_6.Name = "band80_6";
            this.band80_6.Size = new System.Drawing.Size(15, 14);
            this.band80_6.TabIndex = 211;
            this.band80_6.UseVisualStyleBackColor = true;
            this.band80_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band160_6
            // 
            this.band160_6.AutoSize = true;
            this.band160_6.Location = new System.Drawing.Point(551, 82);
            this.band160_6.Name = "band160_6";
            this.band160_6.Size = new System.Drawing.Size(15, 14);
            this.band160_6.TabIndex = 210;
            this.band160_6.UseVisualStyleBackColor = true;
            this.band160_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band630_6
            // 
            this.band630_6.AutoSize = true;
            this.band630_6.Location = new System.Drawing.Point(551, 55);
            this.band630_6.Name = "band630_6";
            this.band630_6.Size = new System.Drawing.Size(15, 14);
            this.band630_6.TabIndex = 209;
            this.band630_6.UseVisualStyleBackColor = true;
            this.band630_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band70_7
            // 
            this.band70_7.AutoSize = true;
            this.band70_7.Location = new System.Drawing.Point(606, 408);
            this.band70_7.Name = "band70_7";
            this.band70_7.Size = new System.Drawing.Size(15, 14);
            this.band70_7.TabIndex = 236;
            this.band70_7.UseVisualStyleBackColor = true;
            this.band70_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band2_7
            // 
            this.band2_7.AutoSize = true;
            this.band2_7.Location = new System.Drawing.Point(606, 378);
            this.band2_7.Name = "band2_7";
            this.band2_7.Size = new System.Drawing.Size(15, 14);
            this.band2_7.TabIndex = 235;
            this.band2_7.UseVisualStyleBackColor = true;
            this.band2_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band6_7
            // 
            this.band6_7.AutoSize = true;
            this.band6_7.Location = new System.Drawing.Point(606, 348);
            this.band6_7.Name = "band6_7";
            this.band6_7.Size = new System.Drawing.Size(15, 14);
            this.band6_7.TabIndex = 234;
            this.band6_7.UseVisualStyleBackColor = true;
            this.band6_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band10_7
            // 
            this.band10_7.AutoSize = true;
            this.band10_7.Location = new System.Drawing.Point(606, 319);
            this.band10_7.Name = "band10_7";
            this.band10_7.Size = new System.Drawing.Size(15, 14);
            this.band10_7.TabIndex = 233;
            this.band10_7.UseVisualStyleBackColor = true;
            this.band10_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band12_7
            // 
            this.band12_7.AutoSize = true;
            this.band12_7.Location = new System.Drawing.Point(606, 292);
            this.band12_7.Name = "band12_7";
            this.band12_7.Size = new System.Drawing.Size(15, 14);
            this.band12_7.TabIndex = 232;
            this.band12_7.UseVisualStyleBackColor = true;
            this.band12_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band15_7
            // 
            this.band15_7.AutoSize = true;
            this.band15_7.Location = new System.Drawing.Point(606, 266);
            this.band15_7.Name = "band15_7";
            this.band15_7.Size = new System.Drawing.Size(15, 14);
            this.band15_7.TabIndex = 231;
            this.band15_7.UseVisualStyleBackColor = true;
            this.band15_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band17_7
            // 
            this.band17_7.AutoSize = true;
            this.band17_7.Location = new System.Drawing.Point(606, 243);
            this.band17_7.Name = "band17_7";
            this.band17_7.Size = new System.Drawing.Size(15, 14);
            this.band17_7.TabIndex = 230;
            this.band17_7.UseVisualStyleBackColor = true;
            this.band17_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band20_7
            // 
            this.band20_7.AutoSize = true;
            this.band20_7.Location = new System.Drawing.Point(606, 216);
            this.band20_7.Name = "band20_7";
            this.band20_7.Size = new System.Drawing.Size(15, 14);
            this.band20_7.TabIndex = 229;
            this.band20_7.UseVisualStyleBackColor = true;
            this.band20_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band30_7
            // 
            this.band30_7.AutoSize = true;
            this.band30_7.Location = new System.Drawing.Point(606, 187);
            this.band30_7.Name = "band30_7";
            this.band30_7.Size = new System.Drawing.Size(15, 14);
            this.band30_7.TabIndex = 228;
            this.band30_7.UseVisualStyleBackColor = true;
            this.band30_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band40_7
            // 
            this.band40_7.AutoSize = true;
            this.band40_7.Location = new System.Drawing.Point(606, 158);
            this.band40_7.Name = "band40_7";
            this.band40_7.Size = new System.Drawing.Size(15, 14);
            this.band40_7.TabIndex = 227;
            this.band40_7.UseVisualStyleBackColor = true;
            this.band40_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band60_7
            // 
            this.band60_7.AutoSize = true;
            this.band60_7.Location = new System.Drawing.Point(606, 131);
            this.band60_7.Name = "band60_7";
            this.band60_7.Size = new System.Drawing.Size(15, 14);
            this.band60_7.TabIndex = 226;
            this.band60_7.UseVisualStyleBackColor = true;
            this.band60_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band80_7
            // 
            this.band80_7.AutoSize = true;
            this.band80_7.Location = new System.Drawing.Point(606, 105);
            this.band80_7.Name = "band80_7";
            this.band80_7.Size = new System.Drawing.Size(15, 14);
            this.band80_7.TabIndex = 225;
            this.band80_7.UseVisualStyleBackColor = true;
            this.band80_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band160_7
            // 
            this.band160_7.AutoSize = true;
            this.band160_7.Location = new System.Drawing.Point(606, 82);
            this.band160_7.Name = "band160_7";
            this.band160_7.Size = new System.Drawing.Size(15, 14);
            this.band160_7.TabIndex = 224;
            this.band160_7.UseVisualStyleBackColor = true;
            this.band160_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band630_7
            // 
            this.band630_7.AutoSize = true;
            this.band630_7.Location = new System.Drawing.Point(606, 55);
            this.band630_7.Name = "band630_7";
            this.band630_7.Size = new System.Drawing.Size(15, 14);
            this.band630_7.TabIndex = 223;
            this.band630_7.UseVisualStyleBackColor = true;
            this.band630_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band70_8
            // 
            this.band70_8.AutoSize = true;
            this.band70_8.Location = new System.Drawing.Point(657, 408);
            this.band70_8.Name = "band70_8";
            this.band70_8.Size = new System.Drawing.Size(15, 14);
            this.band70_8.TabIndex = 250;
            this.band70_8.UseVisualStyleBackColor = true;
            this.band70_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band2_8
            // 
            this.band2_8.AutoSize = true;
            this.band2_8.Location = new System.Drawing.Point(657, 378);
            this.band2_8.Name = "band2_8";
            this.band2_8.Size = new System.Drawing.Size(15, 14);
            this.band2_8.TabIndex = 249;
            this.band2_8.UseVisualStyleBackColor = true;
            this.band2_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band6_8
            // 
            this.band6_8.AutoSize = true;
            this.band6_8.Location = new System.Drawing.Point(657, 348);
            this.band6_8.Name = "band6_8";
            this.band6_8.Size = new System.Drawing.Size(15, 14);
            this.band6_8.TabIndex = 248;
            this.band6_8.UseVisualStyleBackColor = true;
            this.band6_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band10_8
            // 
            this.band10_8.AutoSize = true;
            this.band10_8.Location = new System.Drawing.Point(657, 319);
            this.band10_8.Name = "band10_8";
            this.band10_8.Size = new System.Drawing.Size(15, 14);
            this.band10_8.TabIndex = 247;
            this.band10_8.UseVisualStyleBackColor = true;
            this.band10_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band12_8
            // 
            this.band12_8.AutoSize = true;
            this.band12_8.Location = new System.Drawing.Point(657, 292);
            this.band12_8.Name = "band12_8";
            this.band12_8.Size = new System.Drawing.Size(15, 14);
            this.band12_8.TabIndex = 246;
            this.band12_8.UseVisualStyleBackColor = true;
            this.band12_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band15_8
            // 
            this.band15_8.AutoSize = true;
            this.band15_8.Location = new System.Drawing.Point(657, 266);
            this.band15_8.Name = "band15_8";
            this.band15_8.Size = new System.Drawing.Size(15, 14);
            this.band15_8.TabIndex = 245;
            this.band15_8.UseVisualStyleBackColor = true;
            this.band15_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band17_8
            // 
            this.band17_8.AutoSize = true;
            this.band17_8.Location = new System.Drawing.Point(657, 243);
            this.band17_8.Name = "band17_8";
            this.band17_8.Size = new System.Drawing.Size(15, 14);
            this.band17_8.TabIndex = 244;
            this.band17_8.UseVisualStyleBackColor = true;
            this.band17_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band20_8
            // 
            this.band20_8.AutoSize = true;
            this.band20_8.Location = new System.Drawing.Point(657, 216);
            this.band20_8.Name = "band20_8";
            this.band20_8.Size = new System.Drawing.Size(15, 14);
            this.band20_8.TabIndex = 243;
            this.band20_8.UseVisualStyleBackColor = true;
            this.band20_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band30_8
            // 
            this.band30_8.AutoSize = true;
            this.band30_8.Location = new System.Drawing.Point(657, 187);
            this.band30_8.Name = "band30_8";
            this.band30_8.Size = new System.Drawing.Size(15, 14);
            this.band30_8.TabIndex = 242;
            this.band30_8.UseVisualStyleBackColor = true;
            this.band30_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band40_8
            // 
            this.band40_8.AutoSize = true;
            this.band40_8.Location = new System.Drawing.Point(657, 158);
            this.band40_8.Name = "band40_8";
            this.band40_8.Size = new System.Drawing.Size(15, 14);
            this.band40_8.TabIndex = 241;
            this.band40_8.UseVisualStyleBackColor = true;
            this.band40_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band60_8
            // 
            this.band60_8.AutoSize = true;
            this.band60_8.Location = new System.Drawing.Point(657, 131);
            this.band60_8.Name = "band60_8";
            this.band60_8.Size = new System.Drawing.Size(15, 14);
            this.band60_8.TabIndex = 240;
            this.band60_8.UseVisualStyleBackColor = true;
            this.band60_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band80_8
            // 
            this.band80_8.AutoSize = true;
            this.band80_8.Location = new System.Drawing.Point(657, 105);
            this.band80_8.Name = "band80_8";
            this.band80_8.Size = new System.Drawing.Size(15, 14);
            this.band80_8.TabIndex = 239;
            this.band80_8.UseVisualStyleBackColor = true;
            this.band80_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band160_8
            // 
            this.band160_8.AutoSize = true;
            this.band160_8.Location = new System.Drawing.Point(657, 82);
            this.band160_8.Name = "band160_8";
            this.band160_8.Size = new System.Drawing.Size(15, 14);
            this.band160_8.TabIndex = 238;
            this.band160_8.UseVisualStyleBackColor = true;
            this.band160_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band630_8
            // 
            this.band630_8.AutoSize = true;
            this.band630_8.Location = new System.Drawing.Point(657, 55);
            this.band630_8.Name = "band630_8";
            this.band630_8.Size = new System.Drawing.Size(15, 14);
            this.band630_8.TabIndex = 237;
            this.band630_8.UseVisualStyleBackColor = true;
            this.band630_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(211, 425);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(490, 13);
            this.label35.TabIndex = 251;
            this.label35.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(240, 438);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(31, 13);
            this.label36.TabIndex = 252;
            this.label36.Text = "other";
            // 
            // band_8
            // 
            this.band_8.AutoSize = true;
            this.band_8.Location = new System.Drawing.Point(657, 439);
            this.band_8.Name = "band_8";
            this.band_8.Size = new System.Drawing.Size(15, 14);
            this.band_8.TabIndex = 260;
            this.band_8.UseVisualStyleBackColor = true;
            this.band_8.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band_7
            // 
            this.band_7.AutoSize = true;
            this.band_7.Location = new System.Drawing.Point(606, 439);
            this.band_7.Name = "band_7";
            this.band_7.Size = new System.Drawing.Size(15, 14);
            this.band_7.TabIndex = 259;
            this.band_7.UseVisualStyleBackColor = true;
            this.band_7.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band_6
            // 
            this.band_6.AutoSize = true;
            this.band_6.Location = new System.Drawing.Point(551, 439);
            this.band_6.Name = "band_6";
            this.band_6.Size = new System.Drawing.Size(15, 14);
            this.band_6.TabIndex = 258;
            this.band_6.UseVisualStyleBackColor = true;
            this.band_6.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band_5
            // 
            this.band_5.AutoSize = true;
            this.band_5.Location = new System.Drawing.Point(505, 439);
            this.band_5.Name = "band_5";
            this.band_5.Size = new System.Drawing.Size(15, 14);
            this.band_5.TabIndex = 257;
            this.band_5.UseVisualStyleBackColor = true;
            this.band_5.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band_4
            // 
            this.band_4.AutoSize = true;
            this.band_4.Location = new System.Drawing.Point(452, 439);
            this.band_4.Name = "band_4";
            this.band_4.Size = new System.Drawing.Size(15, 14);
            this.band_4.TabIndex = 256;
            this.band_4.UseVisualStyleBackColor = true;
            this.band_4.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band_3
            // 
            this.band_3.AutoSize = true;
            this.band_3.Location = new System.Drawing.Point(395, 439);
            this.band_3.Name = "band_3";
            this.band_3.Size = new System.Drawing.Size(15, 14);
            this.band_3.TabIndex = 255;
            this.band_3.UseVisualStyleBackColor = true;
            this.band_3.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band_2
            // 
            this.band_2.AutoSize = true;
            this.band_2.Location = new System.Drawing.Point(332, 439);
            this.band_2.Name = "band_2";
            this.band_2.Size = new System.Drawing.Size(15, 14);
            this.band_2.TabIndex = 254;
            this.band_2.UseVisualStyleBackColor = true;
            this.band_2.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // band_1
            // 
            this.band_1.AutoSize = true;
            this.band_1.Location = new System.Drawing.Point(281, 438);
            this.band_1.Name = "band_1";
            this.band_1.Size = new System.Drawing.Size(15, 14);
            this.band_1.TabIndex = 253;
            this.band_1.UseVisualStyleBackColor = true;
            this.band_1.CheckedChanged += new System.EventHandler(this.band_CheckedChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(12, 219);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 13);
            this.label37.TabIndex = 263;
            this.label37.Text = "URL:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(12, 267);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(62, 13);
            this.label38.TabIndex = 264;
            this.label38.Text = "Web Port#:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(12, 320);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(58, 13);
            this.label39.TabIndex = 267;
            this.label39.Text = "user, pass:";
            // 
            // Setup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(722, 471);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.URLpass);
            this.Controls.Add(this.URLuser);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.URLport);
            this.Controls.Add(this.URLaddress);
            this.Controls.Add(this.band_8);
            this.Controls.Add(this.band_7);
            this.Controls.Add(this.band_6);
            this.Controls.Add(this.band_5);
            this.Controls.Add(this.band_4);
            this.Controls.Add(this.band_3);
            this.Controls.Add(this.band_2);
            this.Controls.Add(this.band_1);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.band70_8);
            this.Controls.Add(this.band2_8);
            this.Controls.Add(this.band6_8);
            this.Controls.Add(this.band10_8);
            this.Controls.Add(this.band12_8);
            this.Controls.Add(this.band15_8);
            this.Controls.Add(this.band17_8);
            this.Controls.Add(this.band20_8);
            this.Controls.Add(this.band30_8);
            this.Controls.Add(this.band40_8);
            this.Controls.Add(this.band60_8);
            this.Controls.Add(this.band80_8);
            this.Controls.Add(this.band160_8);
            this.Controls.Add(this.band630_8);
            this.Controls.Add(this.band70_7);
            this.Controls.Add(this.band2_7);
            this.Controls.Add(this.band6_7);
            this.Controls.Add(this.band10_7);
            this.Controls.Add(this.band12_7);
            this.Controls.Add(this.band15_7);
            this.Controls.Add(this.band17_7);
            this.Controls.Add(this.band20_7);
            this.Controls.Add(this.band30_7);
            this.Controls.Add(this.band40_7);
            this.Controls.Add(this.band60_7);
            this.Controls.Add(this.band80_7);
            this.Controls.Add(this.band160_7);
            this.Controls.Add(this.band630_7);
            this.Controls.Add(this.band70_6);
            this.Controls.Add(this.band2_6);
            this.Controls.Add(this.band6_6);
            this.Controls.Add(this.band10_6);
            this.Controls.Add(this.band12_6);
            this.Controls.Add(this.band15_6);
            this.Controls.Add(this.band17_6);
            this.Controls.Add(this.band20_6);
            this.Controls.Add(this.band30_6);
            this.Controls.Add(this.band40_6);
            this.Controls.Add(this.band60_6);
            this.Controls.Add(this.band80_6);
            this.Controls.Add(this.band160_6);
            this.Controls.Add(this.band630_6);
            this.Controls.Add(this.band70_5);
            this.Controls.Add(this.band2_5);
            this.Controls.Add(this.band6_5);
            this.Controls.Add(this.band10_5);
            this.Controls.Add(this.band12_5);
            this.Controls.Add(this.band15_5);
            this.Controls.Add(this.band17_5);
            this.Controls.Add(this.band20_5);
            this.Controls.Add(this.band30_5);
            this.Controls.Add(this.band40_5);
            this.Controls.Add(this.band60_5);
            this.Controls.Add(this.band80_5);
            this.Controls.Add(this.band160_5);
            this.Controls.Add(this.band630_5);
            this.Controls.Add(this.band70_4);
            this.Controls.Add(this.band2_4);
            this.Controls.Add(this.band6_4);
            this.Controls.Add(this.band10_4);
            this.Controls.Add(this.band12_4);
            this.Controls.Add(this.band15_4);
            this.Controls.Add(this.band17_4);
            this.Controls.Add(this.band20_4);
            this.Controls.Add(this.band30_4);
            this.Controls.Add(this.band40_4);
            this.Controls.Add(this.band60_4);
            this.Controls.Add(this.band80_4);
            this.Controls.Add(this.band160_4);
            this.Controls.Add(this.band630_4);
            this.Controls.Add(this.band70_3);
            this.Controls.Add(this.band2_3);
            this.Controls.Add(this.band6_3);
            this.Controls.Add(this.band10_3);
            this.Controls.Add(this.band12_3);
            this.Controls.Add(this.band15_3);
            this.Controls.Add(this.band17_3);
            this.Controls.Add(this.band20_3);
            this.Controls.Add(this.band30_3);
            this.Controls.Add(this.band40_3);
            this.Controls.Add(this.band60_3);
            this.Controls.Add(this.band80_3);
            this.Controls.Add(this.band160_3);
            this.Controls.Add(this.band630_3);
            this.Controls.Add(this.band70_2);
            this.Controls.Add(this.band2_2);
            this.Controls.Add(this.band6_2);
            this.Controls.Add(this.band10_2);
            this.Controls.Add(this.band12_2);
            this.Controls.Add(this.band15_2);
            this.Controls.Add(this.band17_2);
            this.Controls.Add(this.band20_2);
            this.Controls.Add(this.band30_2);
            this.Controls.Add(this.band40_2);
            this.Controls.Add(this.band60_2);
            this.Controls.Add(this.band80_2);
            this.Controls.Add(this.band160_2);
            this.Controls.Add(this.band630_2);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.band70_1);
            this.Controls.Add(this.band2_1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.band6_1);
            this.Controls.Add(this.band10_1);
            this.Controls.Add(this.band12_1);
            this.Controls.Add(this.band15_1);
            this.Controls.Add(this.band17_1);
            this.Controls.Add(this.band20_1);
            this.Controls.Add(this.band30_1);
            this.Controls.Add(this.band40_1);
            this.Controls.Add(this.band60_1);
            this.Controls.Add(this.band80_1);
            this.Controls.Add(this.band160_1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.band630_1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboCATstopbits);
            this.Controls.Add(this.comboCATdatabits);
            this.Controls.Add(this.comboCATparity);
            this.Controls.Add(this.comboCATbaud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkCATEnable);
            this.Controls.Add(this.comboCATPort);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setup";
            this.Text = "Setup";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Setup_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Properties






        #endregion

        #region Event Handler

        private void Setup_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // SpotForm.VOACAP_FORCE = false;
            this.Hide();
            e.Cancel = true;
          //  System.Data.Common.SaveForm(this, "Setup");
        }



        #endregion


        private bool allow_freq_broadcast = false;
        public bool AllowFreqBroadcast
        {
            get { return allow_freq_broadcast; }
            set
            {
                allow_freq_broadcast = value;
                if (value)
                {
                    form1.KWAutoInformation = true;

                }
                else
                {
                    form1.KWAutoInformation = false;

                }
            }
        }


        private void RefreshCOMPortLists()
        {
            string[] com_ports = SortedComPorts();   // Common.SortedComPorts();
         
            comboCATPort.Items.Clear();

            comboCATPort.Items.Add("None");
            comboCATPort.Items.AddRange(com_ports);
       
        } // RefreshCOMPortsLists()

        public static string[] SortedComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort<string>(ports, delegate (string strA, string strB)
            {
                try
                {
                    int idA = int.Parse(strA.Substring(3));
                    int idB = int.Parse(strB.Substring(3));

                    return idA.CompareTo(idB);
                }
                catch (Exception)
                {
                    return strA.CompareTo(strB);
                }
            });
            return ports;
        }

        private void comboCATPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCATPort.SelectedIndex >= 1)
                form1.CATPort = Int32.Parse(comboCATPort.Text.Substring(3));


        }

        private void chkCATEnable_CheckedChanged(object sender, EventArgs e)
        {
            form1.CATOn = chkCATEnable.Checked;
           
            if (comboCATPort.SelectedIndex >= 1)
                  form1.CATPort = Int32.Parse(comboCATPort.Text.Substring(3));

            if (chkCATEnable.Checked)
            {
                form1.CATEnabled = true;
                form1.manualAnt = false;

            }
            else
            {
                form1.CATEnabled = false;
                form1.manualAnt = true;
            }

        }

        private void comboCATbaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCATbaud.SelectedIndex >= 0)
                form1.CATBaudRate = Int32.Parse(comboCATbaud.Text);
        }

        private void comboCATparity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = comboCATparity.SelectedText;
            if (selection == null) return;

            form1.CATParity = SDRSerialPort.StringToParity(selection);
        }

        private void comboCATdatabits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCATdatabits.SelectedIndex >= 0)
                form1.CATDataBits = int.Parse(comboCATdatabits.Text);
        }

        private void comboCATstopbits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCATstopbits.SelectedIndex >= 0)
                form1.CATStopBits = SDRSerialPort.StringToStopBits(comboCATstopbits.Text);
        }

        public bool[,] AntArray = new bool[17,10];

        
        private void band_CheckedChanged(object sender, EventArgs e)
        {

            AntArray[1,1] = band630_1.Checked;
            AntArray[1,2] = band630_2.Checked;
            AntArray[1,3] = band630_3.Checked;
            AntArray[1,4] = band630_4.Checked;
            AntArray[1,5] = band630_5.Checked;
            AntArray[1,6] = band630_6.Checked;
            AntArray[1,7] = band630_7.Checked;
            AntArray[1,8] = band630_8.Checked;

            AntArray[2,1] = band160_1.Checked;
            AntArray[2,2] = band160_2.Checked;
            AntArray[2,3] = band160_3.Checked;
            AntArray[2,4] = band160_4.Checked;
            AntArray[2,5] = band160_5.Checked;
            AntArray[2,6] = band160_6.Checked;
            AntArray[2,7] = band160_7.Checked;
            AntArray[2,8] = band160_8.Checked;

            AntArray[3,1] = band80_1.Checked;
            AntArray[3,2] = band80_2.Checked;
            AntArray[3,3] = band80_3.Checked;
            AntArray[3,4] = band80_4.Checked;
            AntArray[3,5] = band80_5.Checked;
            AntArray[3,6] = band80_6.Checked;
            AntArray[3,7] = band80_7.Checked;
            AntArray[3,8] = band80_8.Checked;

            AntArray[4,1] = band60_1.Checked;
            AntArray[4,2] = band60_2.Checked;
            AntArray[4,3] = band60_3.Checked;
            AntArray[4,4] = band60_4.Checked;
            AntArray[4,5] = band60_5.Checked;
            AntArray[4,6] = band60_6.Checked;
            AntArray[4,7] = band60_7.Checked;
            AntArray[4,8] = band60_8.Checked;

            AntArray[5,1] = band40_1.Checked;
            AntArray[5,2] = band40_2.Checked;
            AntArray[5,3] = band40_3.Checked;
            AntArray[5,4] = band40_4.Checked;
            AntArray[5,5] = band40_5.Checked;
            AntArray[5,6] = band40_6.Checked;
            AntArray[5,7] = band40_7.Checked;
            AntArray[5,8] = band40_8.Checked;

            AntArray[6,1] = band30_1.Checked;
            AntArray[6,2] = band30_2.Checked;
            AntArray[6,3] = band30_3.Checked;
            AntArray[6,4] = band30_4.Checked;
            AntArray[6,5] = band30_5.Checked;
            AntArray[6,6] = band30_6.Checked;
            AntArray[6,7] = band30_7.Checked;
            AntArray[6,8] = band30_8.Checked;

            AntArray[7,1] = band20_1.Checked;
            AntArray[7,2] = band20_2.Checked;
            AntArray[7,3] = band20_3.Checked;
            AntArray[7,4] = band20_4.Checked;
            AntArray[7,5] = band20_5.Checked;
            AntArray[7,6] = band20_6.Checked;
            AntArray[7,7] = band20_7.Checked;
            AntArray[7,8] = band20_8.Checked;

            AntArray[8,1] = band17_1.Checked;
            AntArray[8,2] = band17_2.Checked;
            AntArray[8,3] = band17_3.Checked;
            AntArray[8,4] = band17_4.Checked;
            AntArray[8,5] = band17_5.Checked;
            AntArray[8,6] = band17_6.Checked;
            AntArray[8,7] = band17_7.Checked;
            AntArray[8,8] = band17_8.Checked;

            AntArray[9, 1] = band15_1.Checked;
            AntArray[9, 2] = band15_2.Checked;
            AntArray[9, 3] = band15_3.Checked;
            AntArray[9, 4] = band15_4.Checked;
            AntArray[9, 5] = band15_5.Checked;
            AntArray[9, 6] = band15_6.Checked;
            AntArray[9, 7] = band15_7.Checked;
            AntArray[9, 8] = band15_8.Checked;

            AntArray[10, 1] = band12_1.Checked;
            AntArray[10, 2] = band12_2.Checked;
            AntArray[10, 3] = band12_3.Checked;
            AntArray[10, 4] = band12_4.Checked;
            AntArray[10, 5] = band12_5.Checked;
            AntArray[10, 6] = band12_6.Checked;
            AntArray[10, 7] = band12_7.Checked;
            AntArray[10, 8] = band12_8.Checked;

            AntArray[11, 1] = band10_1.Checked;
            AntArray[11, 2] = band10_2.Checked;
            AntArray[11, 3] = band10_3.Checked;
            AntArray[11, 4] = band10_4.Checked;
            AntArray[11, 5] = band10_5.Checked;
            AntArray[11, 6] = band10_6.Checked;
            AntArray[11, 7] = band10_7.Checked;
            AntArray[11, 8] = band10_8.Checked;

            AntArray[12, 1] = band6_1.Checked;
            AntArray[12, 2] = band6_2.Checked;
            AntArray[12, 3] = band6_3.Checked;
            AntArray[12, 4] = band6_4.Checked;
            AntArray[12, 5] = band6_5.Checked;
            AntArray[12, 6] = band6_6.Checked;
            AntArray[12, 7] = band6_7.Checked;
            AntArray[12, 8] = band6_8.Checked;

            AntArray[13, 1] = band2_1.Checked;
            AntArray[13, 2] = band2_2.Checked;
            AntArray[13, 3] = band2_3.Checked;
            AntArray[13, 4] = band2_4.Checked;
            AntArray[13, 5] = band2_5.Checked;
            AntArray[13, 6] = band2_6.Checked;
            AntArray[13, 7] = band2_7.Checked;
            AntArray[13, 8] = band2_8.Checked;

            AntArray[14, 1] = band70_1.Checked;
            AntArray[14, 2] = band70_2.Checked;
            AntArray[14, 3] = band70_3.Checked;
            AntArray[14, 4] = band70_4.Checked;
            AntArray[14, 5] = band70_5.Checked;
            AntArray[14, 6] = band70_6.Checked;
            AntArray[14, 7] = band70_7.Checked;
            AntArray[14, 8] = band70_8.Checked;

            AntArray[15, 1] = band_1.Checked;
            AntArray[15, 2] = band_2.Checked;
            AntArray[15, 3] = band_3.Checked;
            AntArray[15, 4] = band_4.Checked;
            AntArray[15, 5] = band_5.Checked;
            AntArray[15, 6] = band_6.Checked;
            AntArray[15, 7] = band_7.Checked;
            AntArray[15, 8] = band_8.Checked;

        
         
     
        } // band_CheckedChanged

        private void URLaddress_TextChanged(object sender, EventArgs e)
        {
            form1.URLName = URLaddress.Text;
        }

        private void URLport_TextChanged(object sender, EventArgs e)
        {
            form1.URLPort = int.Parse(URLport.Text);
               
        }

        private void URLuser_TextChanged(object sender, EventArgs e)
        {
            form1.URLUser = URLuser.Text;
        }

        private void URLpass_TextChanged(object sender, EventArgs e)
        {
            form1.URLPass = URLpass.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            form1.ANTARRAY = AntArray; // send a copy of the current matrix ant array to form1

        }
    } // Setup

} // KMSWITCH6
