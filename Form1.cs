//==============================================================================================
//==============================================================================================
//==============================================================================================
// KE9NS 11/7/2025
// Connect to a KMSWITCH to be used as an antenna switch via HTTP internet
// Connect to your radio via COM port. 
// If your radio is remote you will need remote access to the COM port
//==============================================================================================
//==============================================================================================
//==============================================================================================



using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KMSWITCH
{

    // FF0000
    public partial class Form1 : Form
    {

    
        
        String[] buttonArray = { "Ant-1", "Ant-2", "Ant-3", "Ant-4", "Ant-5", "Ant-6", "Ant-7", "Ant-8" };
        Image[] imageArray = new Image[6];

        bool GotImages = false;

        public Setup setupForm;

        public CATParser parser;                       // ke9ns: add to allow serial port (but currently only used in setup for CATURL

        public CATCommands commands;                   // ke9ns: add

        public SDRSerialPort sDRSerialPort;

        public enum Band
        {
            FIRST = -1,
            GEN, // 0
            B160M, // 1
            B80M,
            B60M,
            B40M,
            B30M,
            B20M,
            B17M,
            B15M,
            B12M,
            B10M,
            B6M,
            B2M,
            WWV, // 13

            VHF0,
            VHF1,

            VHF2, //16
            VHF3,
            VHF4,
            VHF5,
            VHF6,
            VHF7,
            VHF8,
            VHF9,
            VHF10,
            VHF11,
            VHF12,
            VHF13, // 27

            BLMF, // 28 ke9ns move down below vhf
            B120M,
            B90M,
            B61M,
            B49M,
            B41M,
            B31M,
            B25M,
            B22M,
            B19M,
            B16M,
            B14M,
            B13M,
            B11M, // 41

            LAST,
        }

        public static TcpClient client;                                               //           ' socket

        public static NetworkStream networkStream;                                   //         ' stream
        public static BinaryWriter SP_writer;
        public static BinaryReader SP_Reader;

        public static StreamReader SP_reader;
        public static StreamWriter SP_Writer;



        private bool detectEncodingFromByteOrderMarks = true;

        public byte RX1 = (byte)'X';
        public byte RX2 = (byte)'Y';

        public bool CONNECTSTREAM = false;
        public bool DATACONNECT = false;

        private SIOListenerII siolisten = null;              // original CAT port

        public bool[,] AntennaArray = new bool[17, 10];

        private SynchronizationContext _syncContext;

        public Form1()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            _syncContext = SynchronizationContext.Current; // UI thread context

            //  Form1.FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();

            Setup.form1 = this;
            SDRSerialPort.form1 = this;

            if (setupForm == null || setupForm.IsDisposed) setupForm = new Setup(this); //.271 copy



            pictureBox1.BackColor = status1.BackColor = Color.Orange;
            pictureBox2.BackColor = status2.BackColor = Color.Orange;
            pictureBox3.BackColor = status3.BackColor = Color.Orange;
            pictureBox4.BackColor = status4.BackColor = Color.Orange;
            pictureBox5.BackColor = status5.BackColor = Color.Orange;
            pictureBox6.BackColor = status6.BackColor = Color.Orange;
            pictureBox7.BackColor = status7.BackColor = Color.Orange;
            pictureBox8.BackColor = status8.BackColor = Color.Orange;




            commands = new CATCommands(this, parser); // ke9ns add


            DataBase();

        } // Form1()

        public int antennaCommand = 0;
        public bool GoodUrl = false;


        public void DataBase()
        {
            Debug.WriteLine("DATABASE ==============================");


            string file_name2 = "C:\\KMSWITCH\\ke9ns8.dat"; // save data for my mods
            string image1 = @"C:\KMSWITCH\1.jpg";
            string image2 = "C:\\KMSWITCH\\2.jpg";
            string image3 = "C:\\KMSWITCH\\3.jpg";
            string image4 = "C:\\KMSWITCH\\4.jpg";
            string image5 = "C:\\KMSWITCH\\5.jpg";
            string image6 = "C:\\KMSWITCH\\6.jpg";
            string image7 = "C:\\KMSWITCH\\7.jpg";
            string image8 = "C:\\KMSWITCH\\8.jpg";

            if (!Directory.Exists("C:\\KMSWITCH"))
            {
                Directory.CreateDirectory("C:\\KMSWITCH");
            }

            if (File.Exists(image1))
            {
             
                try
                {
                    Image img = Image.FromFile(image1);
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            } // file exists

            if (File.Exists(image2))
            {
              
                try
                {
                    Image img = Image.FromFile(image2);
                    pictureBox2.Image = img;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            } // file exists


            if (File.Exists(image3))
            {

                try
                {
                    Image img = Image.FromFile(image3);
                    pictureBox3.Image = img;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            } // file exists

            if (File.Exists(image4))
            {

                try
                {
                    Image img = Image.FromFile(image4);
                    pictureBox4.Image = img;
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            } // file exists

            if (File.Exists(image5))
            {

                try
                {
                    Image img = Image.FromFile(image5);
                    pictureBox5.Image = img;
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            } // file exists

            if (File.Exists(image6))
            {

                try
                {
                    Image img = Image.FromFile(image6);
                    pictureBox6.Image = img;
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            } // file exists

            if (File.Exists(image7))
            {

                try
                {
                    Image img = Image.FromFile(image7);
                    pictureBox7.Image = img;
                    pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            } // file exists

            if (File.Exists(image8))
            {

                try
                {
                    Image img = Image.FromFile(image8);
                    pictureBox8.Image = img;
                    pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            } // file exists






            if (!File.Exists(file_name2))
            {

                Debug.WriteLine("Create new database file");

                FileStream stream2 = new FileStream(file_name2, FileMode.Create); // open BMP  file
                BinaryWriter writer2 = new BinaryWriter(stream2);

                writer2.Write(CATBaudRate);                             // Baud rate for COM PORT
                writer2.Write(CATPort);                                 // COM PORT to use
                writer2.Write(CATOn);                                   // enable

                writer2.Write(URLName);                                 // URL  of the KWSwitch 
                writer2.Write(URLPort);                                 //  Port of the KWSwitch
                writer2.Write(URLUser);                                 //  URL username
                writer2.Write(URLPass);                                 // URL password



                writer2.Write(buttonArray[0]);                             // button1 name
                writer2.Write(buttonArray[1]);                             // button2 name
                writer2.Write(buttonArray[2]);                             // button3 name
                writer2.Write(buttonArray[3]);                             // button4 name
                writer2.Write(buttonArray[4]);                             // button5 name
                writer2.Write(buttonArray[5]);                             // button6 name
                writer2.Write(buttonArray[6]);                             // button7 name
                writer2.Write(buttonArray[7]);                             // button8 name

                for (int i = 0; i <= 16; i++)
                {
                    for (int j = 0; j <= 8; j++)
                    {
                        writer2.Write(AntennaArray[i, j]);                  // store antenna array matix
                    }
                }

                writer2.Write("END");

                writer2.Close();    // close  file
                stream2.Close();   // close stream
                Debug.WriteLine("Create new database file");

            }
            else // yes ke9ns.dat file does exist
            {
                Debug.WriteLine("\r\nREAD ke9ns DATABASE NOW");

                FileStream stream2 = new FileStream(file_name2, FileMode.Open); // open ke9ns file
                BinaryReader reader2 = new BinaryReader(stream2);


                CATBaudRate = (int)reader2.ReadUInt32();                    // Baud rate for COM PORT
                CATPort = (int)reader2.ReadUInt32();                        // COM PORT to use
                CATOn = reader2.ReadBoolean();                              // CAT enable


                URLName = reader2.ReadString();                             // URL  of the KWSwitch 
                URLPort = (int)reader2.ReadUInt32();                        //  Port of the KWSwitch

                URLUser = reader2.ReadString();                            //  URL username
                URLPass = reader2.ReadString();                             // URL password


                Debug.WriteLine("CAT: " + CATPort + ", " + CATBaudRate + ", " + CATOn + ", " + URLName + ", " + URLPort + ", " + URLUser + ", " + URLPass);


                buttonArray[0] = reader2.ReadString();                           // button1 name
                buttonArray[1] = reader2.ReadString();                            // button2 name
                buttonArray[2] = reader2.ReadString();                            // button3 name
                buttonArray[3] = reader2.ReadString();                            // button4 name
                buttonArray[4] = reader2.ReadString();                            // button5 name
                buttonArray[5] = reader2.ReadString();                            // button6 name
                buttonArray[6] = reader2.ReadString();                           // button7 name
                buttonArray[7] = reader2.ReadString();                           // button8 name

                for (int i = 0; i <= 16; i++)
                {
                    for (int j = 0; j <= 8; j++)
                    {
                        AntennaArray[i, j] = reader2.ReadBoolean();             // store antenna array matix

                        if (AntennaArray[i, j] == true) Debug.WriteLine("Read " + i + "," + j + " " + AntennaArray[i, j]);
                    }
                }


                reader2.Close();    // close  file
                stream2.Close();   // close stream
                                   //   Debug.WriteLine("Read database file");

            } // yes ke9ns.dat file does exist



            textBox1.Text = button1.Text = buttonArray[0];
            textBox2.Text = button2.Text = buttonArray[1];
            textBox3.Text = button3.Text = buttonArray[2];
            textBox4.Text = button4.Text = buttonArray[3];
            textBox5.Text = button5.Text = buttonArray[4];
            textBox6.Text = button6.Text = buttonArray[5];
            textBox7.Text = button7.Text = buttonArray[6];
            textBox8.Text = button8.Text = buttonArray[7];

            setupForm.comboCATPort.Text = "COM" + CATPort.ToString();
            setupForm.comboCATbaud.Text = CATBaudRate.ToString();
            setupForm.URLaddress.Text = URLName;
            setupForm.URLport.Text = URLPort.ToString();
            setupForm.URLuser.Text = URLUser.ToString();    
            setupForm.URLpass.Text = URLPass.ToString();

            setupForm.band630_1.Checked = AntennaArray[1, 1];
            setupForm.band630_2.Checked = AntennaArray[1, 2];
            setupForm.band630_3.Checked = AntennaArray[1, 3];
            setupForm.band630_4.Checked = AntennaArray[1, 4];
            setupForm.band630_5.Checked = AntennaArray[1, 5];
            setupForm.band630_6.Checked = AntennaArray[1, 6];
            setupForm.band630_7.Checked = AntennaArray[1, 7];
            setupForm.band630_8.Checked = AntennaArray[1, 8];

            setupForm.band160_1.Checked = AntennaArray[2, 1];
            setupForm.band160_2.Checked = AntennaArray[2, 2];
            setupForm.band160_3.Checked = AntennaArray[2, 3];
            setupForm.band160_4.Checked = AntennaArray[2, 4];
            setupForm.band160_5.Checked = AntennaArray[2, 5];
            setupForm.band160_6.Checked = AntennaArray[2, 6];
            setupForm.band160_7.Checked = AntennaArray[2, 7];
            setupForm.band160_8.Checked = AntennaArray[2, 8];

            setupForm.band80_1.Checked = AntennaArray[3, 1];
            setupForm.band80_2.Checked = AntennaArray[3, 2];
            setupForm.band80_3.Checked = AntennaArray[3, 3];
            setupForm.band80_4.Checked = AntennaArray[3, 4];
            setupForm.band80_5.Checked = AntennaArray[3, 5];
            setupForm.band80_6.Checked = AntennaArray[3, 6];
            setupForm.band80_7.Checked = AntennaArray[3, 7];
            setupForm.band80_8.Checked = AntennaArray[3, 8];

            setupForm.band60_1.Checked = AntennaArray[4, 1];
            setupForm.band60_2.Checked = AntennaArray[4, 2];
            setupForm.band60_3.Checked = AntennaArray[4, 3];
            setupForm.band60_4.Checked = AntennaArray[4, 4];
            setupForm.band60_5.Checked = AntennaArray[4, 5];
            setupForm.band60_6.Checked = AntennaArray[4, 6];
            setupForm.band60_7.Checked = AntennaArray[4, 7];
            setupForm.band60_8.Checked = AntennaArray[4, 8];

            setupForm.band40_1.Checked = AntennaArray[5, 1];
            setupForm.band40_2.Checked = AntennaArray[5, 2];
            setupForm.band40_3.Checked = AntennaArray[5, 3];
            setupForm.band40_4.Checked = AntennaArray[5, 4];
            setupForm.band40_5.Checked = AntennaArray[5, 5];
            setupForm.band40_6.Checked = AntennaArray[5, 6];
            setupForm.band40_7.Checked = AntennaArray[5, 7];
            setupForm.band40_8.Checked = AntennaArray[5, 8];

            setupForm.band30_1.Checked = AntennaArray[6, 1];
            setupForm.band30_2.Checked = AntennaArray[6, 2];
            setupForm.band30_3.Checked = AntennaArray[6, 3];
            setupForm.band30_4.Checked = AntennaArray[6, 4];
            setupForm.band30_5.Checked = AntennaArray[6, 5];
            setupForm.band30_6.Checked = AntennaArray[6, 6];
            setupForm.band30_7.Checked = AntennaArray[6, 7];
            setupForm.band30_8.Checked = AntennaArray[6, 8];

            setupForm.band20_1.Checked = AntennaArray[7, 1];
            setupForm.band20_2.Checked = AntennaArray[7, 2];
            setupForm.band20_3.Checked = AntennaArray[7, 3];
            setupForm.band20_4.Checked = AntennaArray[7, 4];
            setupForm.band20_5.Checked = AntennaArray[7, 5];
            setupForm.band20_6.Checked = AntennaArray[7, 6];
            setupForm.band20_7.Checked = AntennaArray[7, 7];
            setupForm.band20_8.Checked = AntennaArray[7, 8];

            setupForm.band17_1.Checked = AntennaArray[8, 1];
            setupForm.band17_2.Checked = AntennaArray[8, 2];
            setupForm.band17_3.Checked = AntennaArray[8, 3];
            setupForm.band17_4.Checked = AntennaArray[8, 4];
            setupForm.band17_5.Checked = AntennaArray[8, 5];
            setupForm.band17_6.Checked = AntennaArray[8, 6];
            setupForm.band17_7.Checked = AntennaArray[8, 7];
            setupForm.band17_8.Checked = AntennaArray[8, 8];

            setupForm.band15_1.Checked = AntennaArray[9, 1];
            setupForm.band15_2.Checked = AntennaArray[9, 2];
            setupForm.band15_3.Checked = AntennaArray[9, 3];
            setupForm.band15_4.Checked = AntennaArray[9, 4];
            setupForm.band15_5.Checked = AntennaArray[9, 5];
            setupForm.band15_6.Checked = AntennaArray[9, 6];
            setupForm.band15_7.Checked = AntennaArray[9, 7];
            setupForm.band15_8.Checked = AntennaArray[9, 8];

            setupForm.band12_1.Checked = AntennaArray[10, 1];
            setupForm.band12_2.Checked = AntennaArray[10, 2];
            setupForm.band12_3.Checked = AntennaArray[10, 3];
            setupForm.band12_4.Checked = AntennaArray[10, 4];
            setupForm.band12_5.Checked = AntennaArray[10, 5];
            setupForm.band12_6.Checked = AntennaArray[10, 6];
            setupForm.band12_7.Checked = AntennaArray[10, 7];
            setupForm.band12_8.Checked = AntennaArray[10, 8];

            setupForm.band10_1.Checked = AntennaArray[11, 1];
            setupForm.band10_2.Checked = AntennaArray[11, 2];
            setupForm.band10_3.Checked = AntennaArray[11, 3];
            setupForm.band10_4.Checked = AntennaArray[11, 4];
            setupForm.band10_5.Checked = AntennaArray[11, 5];
            setupForm.band10_6.Checked = AntennaArray[11, 6];
            setupForm.band10_7.Checked = AntennaArray[11, 7];
            setupForm.band10_8.Checked = AntennaArray[11, 8];

            setupForm.band6_1.Checked = AntennaArray[12, 1];
            setupForm.band6_2.Checked = AntennaArray[12, 2];
            setupForm.band6_3.Checked = AntennaArray[12, 3];
            setupForm.band6_4.Checked = AntennaArray[12, 4];
            setupForm.band6_5.Checked = AntennaArray[12, 5];
            setupForm.band6_6.Checked = AntennaArray[12, 6];
            setupForm.band6_7.Checked = AntennaArray[12, 7];
            setupForm.band6_8.Checked = AntennaArray[12, 8];

            setupForm.band2_1.Checked = AntennaArray[13, 1];
            setupForm.band2_2.Checked = AntennaArray[13, 2];
            setupForm.band2_3.Checked = AntennaArray[13, 3];
            setupForm.band2_4.Checked = AntennaArray[13, 4];
            setupForm.band2_5.Checked = AntennaArray[13, 5];
            setupForm.band2_6.Checked = AntennaArray[13, 6];
            setupForm.band2_7.Checked = AntennaArray[13, 7];
            setupForm.band2_8.Checked = AntennaArray[13, 8];

            setupForm.band70_1.Checked = AntennaArray[14, 1];
            setupForm.band70_2.Checked = AntennaArray[14, 2];
            setupForm.band70_3.Checked = AntennaArray[14, 3];
            setupForm.band70_4.Checked = AntennaArray[14, 4];
            setupForm.band70_5.Checked = AntennaArray[14, 5];
            setupForm.band70_6.Checked = AntennaArray[14, 6];
            setupForm.band70_7.Checked = AntennaArray[14, 7];
            setupForm.band70_8.Checked = AntennaArray[14, 8];

            setupForm.band_1.Checked = AntennaArray[15, 1];
            setupForm.band_2.Checked = AntennaArray[15, 2];
            setupForm.band_3.Checked = AntennaArray[15, 3];
            setupForm.band_4.Checked = AntennaArray[15, 4];
            setupForm.band_5.Checked = AntennaArray[15, 5];
            setupForm.band_6.Checked = AntennaArray[15, 6];
            setupForm.band_7.Checked = AntennaArray[15, 7];
            setupForm.band_8.Checked = AntennaArray[15, 8];


            Debug.WriteLine("\r\nUPDATE ke9ns DATABASE NOW");





        } // Database check



        //==============================================================================================
        //==============================================================================================

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // Debug.WriteLine("Mouse Location: " + e.Location);
        }

        public int lastClick = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (CONNECTSTREAM == true)
            {
                manualAnt = true;
                //  CATEnabled = false;

                if (lastClick != 2)
                {
                    antennaCommand = 2;
                    lastClick = 2;
                }
                else
                {
                    antennaCommand = 1; // turn off all relays by double clicking
                    lastClick = 1;
                }

            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (CONNECTSTREAM == true)
            {
                manualAnt = true;
                //  CATEnabled = false;

                if (lastClick != 3)
                {
                    antennaCommand = 3;
                    lastClick = 3;
                }
                else
                {
                    antennaCommand = 1;
                    lastClick = 1;
                }

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (CONNECTSTREAM == true)
            {
                manualAnt = true;
                //  CATEnabled = false;

                if (lastClick != 4)
                {
                    antennaCommand = 4;
                    lastClick = 4;
                }
                else
                {
                    antennaCommand = 1;
                    lastClick = 1;
                }

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (CONNECTSTREAM == true)
            {

                manualAnt = true;
                //  CATEnabled = false;

                if (lastClick != 5)
                {
                    antennaCommand = 5;
                    lastClick = 5;
                }
                else
                {
                    antennaCommand = 1;
                    lastClick = 1;
                }

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (CONNECTSTREAM == true)
            {

                manualAnt = true;
                //  CATEnabled = false;

                if (lastClick != 6)
                {
                    antennaCommand = 6;
                    lastClick = 6;
                }
                else
                {
                    antennaCommand = 1;
                    lastClick = 1;
                }

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (CONNECTSTREAM == true)
            {

                manualAnt = true;
                // CATEnabled = false;

                if (lastClick != 7)
                {
                    antennaCommand = 7;
                    lastClick = 7;
                }
                else
                {
                    antennaCommand = 1;
                    lastClick = 1;
                }

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (CONNECTSTREAM == true)
            {

                manualAnt = true;
                //  CATEnabled = false;


                if (lastClick != 8)
                {
                    antennaCommand = 8;
                    lastClick = 8;
                }
                else
                {
                    antennaCommand = 1;
                    lastClick = 1;
                }

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            manualAnt = true;

            if (CONNECTSTREAM == true)
            {
                manualAnt = true;
                if (lastClick != 9)
                {
                    antennaCommand = 9;
                    lastClick = 9;
                }
                else
                {
                    antennaCommand = 1;
                    lastClick = 1;
                }

            }
        }


        public bool openurl = false;
        public bool manualAnt = true; // start in manual mode first

        public int VFOA = 0; //ke9ns storage for VFOA
        public int AntComm = 0;

        private int lastVFOA = 0;


        //  public int[] setupForm.band630 = { 00000000000, 00001799999 }; AntennaArray[ 1,x ]
        //  public int[] setupForm.band160 = { 00001800000, 00002000000 }; AntennaArray[ 2,x ]
        //  public int[] setupForm.band80 = { 00002000001, 00004000000 };  AntennaArray[ 3,x ]
        //  public int[] setupForm.band60 = { 00004000001, 00006499999 };  AntennaArray[ 4,x ]
        //  public int[] setupForm.band40 = { 00006500000, 00008000000 };  AntennaArray[ 5,x ]
        //  public int[] setupForm.band30 = { 00008000001, 00012999999 };  AntennaArray[ 6,x ]
        //  public int[] setupForm.band20 = { 00013000000, 00016000000 };  AntennaArray[ 7,x ]
        //  public int[] setupForm.band17 = { 00016000001, 00020000000 };  AntennaArray[ 8,x ]
        //  public int[] setupForm.band15 = { 00020000001, 00023000000 };  AntennaArray[ 9,x ]
        //  public int[] setupForm.band12 = { 00023000001, 00026000000 };  AntennaArray[ 10,x ]
        //  public int[] setupForm.band10 = { 00026000001, 00040000000 };  AntennaArray[ 11,x ]
        //  public int[] setupForm.band6 =  { 00040000001, 00060000000 };  AntennaArray[ 12,x ]
        //  public int[] setupForm.band2 =  { 00120000000, 00160000000 };  AntennaArray[ 13,x ]
        //  public int[] setupForm.band70 = { 00400000000, 00500000000 };  AntennaArray[ 14,x ]
        //  public int[] setupForm.band_ =  { 00500000001, 10000000000 };  AntennaArray[ 15,x ]

        // FA00027385000;  27.385.000
        // 630      00000000000 , 00001799999
        // 160      00001800000 , 00002000000
        // 80       00002000001 , 00004000000
        // 60       00004000001 , 00006499999
        // 40       00006500000 , 00008000000
        // 30       00008000001 , 00012999999
        // 20       00013000000 , 00016000000
        // 17       00016000001 , 00020000000
        // 15       00020000001 , 00023000000
        // 12       00023000001 , 00026000000
        // 10       00026000001 , 00040000000
        //  6       00040000001 , 00060000000
        //  2       00120000000 , 00160000000
        // 70       00400000000 , 00500000000

        public int[] M630 = { 00000000000, 00001799999 };
        public int[] M160 = { 00001800000, 00002000000 };
        public int[] M80 = { 00002000001, 00004000000 };
        public int[] M60 = { 00004000001, 00006499999 };
        public int[] M40 = { 00006500000, 00008000000 };
        public int[] M30 = { 00008000001, 00012999999 };
        public int[] M20 = { 00013000000, 00016000000 };
        public int[] M17 = { 00016000001, 00020000000 };
        public int[] M15 = { 00020000001, 00023000000 };
        public int[] M12 = { 00023000001, 00026000000 };
        public int[] M10 = { 00026000001, 00040000000 };
        public int[] M6 = { 00040000001, 00060000000 };
        public int[] M2 = { 00120000000, 00160000000 };
        public int[] M70 = { 00400000000, 00500000000 };
        public int[] M = { 00500000001, 00040000000 };


        // reference AntennaArray[ , ]

        public int NewVFOA
        {
            set
            {
                int x = 0;

                VFOA = lastVFOA = value;   // 7729500   is 7.729.500mhz

                if (VFOA >= M630[0] && VFOA <= M630[1])
                {
                    x = 1;
                }
                else if (VFOA >= M160[0] && VFOA <= M160[1])
                {
                    x = 2;
                }
                else if (VFOA >= M80[0] && VFOA <= M80[1])
                {
                    x = 3;
                }
                else if (VFOA >= M60[0] && VFOA <= M60[1])
                {
                    x = 4;
                }
                else if (VFOA >= M40[0] && VFOA <= M40[1])
                {
                    x = 5;
                }
                else if (VFOA >= M30[0] && VFOA <= M30[1])
                {
                    x = 6;
                }
                else if (VFOA >= M20[0] && VFOA <= M20[1])
                {
                    x = 7;
                }
                else if (VFOA >= M17[0] && VFOA <= M17[1])
                {
                    x = 8;
                }
                else if (VFOA >= M15[0] && VFOA <= M15[1])
                {
                    x = 9;
                }
                else if (VFOA >= M12[0] && VFOA <= M12[1])
                {
                    x = 10;
                }
                else if (VFOA >= M10[0] && VFOA <= M10[1])
                {
                    x = 11;
                }
                else if (VFOA >= M6[0] && VFOA <= M6[1])
                {
                    x = 12;
                }
                else if (VFOA >= M2[0] && VFOA <= M2[1])
                {
                    x = 13;

                }
                else if (VFOA >= M70[0] && VFOA <= M70[1])
                {

                    x = 14;
                }
                else if (VFOA >= M[0] && VFOA <= M[1])
                {

                    x = 15;
                }
                else x = 0; // problem if you come here

                Debug.WriteLine("Freq based on Matrix= " + x);

                for (int i = 1; i <= 9; i++)
                {

                    if (AntennaArray[x, i]) // if checkbox found from frequency, determine which ant to select
                    {
                        if (lastClick != (i + 1))
                        {
                            AntComm = i + 1;
                            lastClick = i + 1;
                            Debug.WriteLine("FOUND ANTENNA based on Matrix= " + AntComm);

                        }

                        break;
                    }

                    if (i == 9)
                    {
                        textBox12.Text = "Frequency: " + VFOA + " has no matching antenna";

                    }

                } // for




            }
            get
            {
                return lastVFOA;
            }
        }




        private void button5_Click(object sender, EventArgs e) // CONNECT button
        {
            textBox13.Text = "Connecting!";

            Debug.WriteLine("TESTING..");


            if (openurl == false) // connect to KMSwitch if not connected
            {
                openurl = true;
                textBox13.Text = "Attempt";

                Thread t = new Thread(new ThreadStart(OpenUrl)); //.314


                t.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                t.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

                t.Name = " Thread";
                t.IsBackground = true;
                t.Priority = ThreadPriority.BelowNormal;
                t.Start();

                textBox12.Text = textBox12.Text + "Thread start ";

            }
            else // disconnect if you were connected
            {

            }
        }  // button5_Click
      
        
        bool initflag = false;


        //=============================================================================================
        public void OpenUrl()
        {

            // example target:  http://URLUser:URLPass@URLName:URLPort/status.xml  // but this only works as a URL for a web browser (not in c# code)
            string baseUrl = "http://" + URLName + ":" + URLPort.ToString() + "/status.xml"; //  use this in c# with the user:pass are authenticaed separately later on
      
            Debug.WriteLine("baseURL " + baseUrl);
            Debug.WriteLine("Port " + URLPort.ToString());
            Debug.WriteLine("User " + URLUser);
            Debug.WriteLine("Pass " + URLPass);
 
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl);
                request.Method = "GET";
                request.Timeout = 5000; // 5 seconds timeout
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";

                // Add authentication credentials (you MUST use this to access the website from C#, otherwise you will be denied access)
                if (!string.IsNullOrEmpty(URLUser) && !string.IsNullOrEmpty(URLPass))
                {
                    string authInfo = $"{URLUser}:{URLPass}";
                    string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(authInfo));
                    request.Headers.Add("Authorization", "Basic " + encodedAuthInfo);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string content = reader.ReadToEnd();  //  Debug.WriteLine("content================= " + content);

                            XmlStatus(content); // update display with relay status here if your url has /status.xml on the end
                     
                            Debug.WriteLine("GOT RELAY STATUS. DONE");
                        } // using
                    } // using
                } // using

                CONNECTSTREAM = true; // we got a connection

            } // try
            catch (WebException ex)
            {
                Debug.WriteLine($"Connection error: {ex.Message}");
                GoodUrl = false;
                openurl = false;
                CONNECTSTREAM = false;
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Connection error: {ex.Message}");
                GoodUrl = false;
                openurl = false;
                CONNECTSTREAM = false;
                return;
            }
       

          
            //.......................................................................................................................
            // Keep the program running and accept commands
            while (true)
            {

                Thread.Sleep(100);

                /*
                                if (CATEnabled == true)
                                {
                                    textBox9.Invoke((MethodInvoker)delegate
                                    {
                                        textBox9.Text = "CAT Enabled";
                                    });
                                }
                                else
                                {
                                    textBox9.Invoke((MethodInvoker)delegate
                                    {
                                        textBox9.Text = "CAT Disabled";
                                    });
                                }
                */
                if (manualAnt == false)
                {
                    textBox13.Invoke((MethodInvoker)delegate
                    {
                        textBox13.Text = "Automatic mode On";

                    });

                    antennaCommand = AntComm; // passed from newVFOA routine
                    AntComm = 0;

                }
                else // Auto mode below
                {
                    textBox13.Invoke((MethodInvoker)delegate
                    {
                        textBox13.Text = "Manual mode On";

                    });


                } // AUTO ANT SELECT VIA FA CAT COMMAND


                if (antennaCommand == 10)
                {
                    break;
                }

           //    if (initflag == false)
             //   {
                //    SendCommand(0);
                  initflag = true;
             //   }
                if (antennaCommand == 0) continue;

                // Send the command via URL

                Debug.WriteLine("SENDCOMMAND NOW: " + antennaCommand);
                SendCommand(antennaCommand);

                antennaCommand = 0;  // reset after sending it to KMSwitch

            } // while end
            //.......................................................................................................................


        } // OpenUrl



//==================================================================================================
        void SendCommand(int antcomm)
        {
            // antcomm
            // 0= no relay change read status
            // 1 = All relays OFF 
            // 2-9 = Turn ON relays 1,2,3,4,5,6,7,8
            // 10 = close connection


            // format for turning relays on/off
            //   M  bits L  hex
            // 1 0000 0001  01 
            // 2 0000 0010  02
            // 3 0000 0100  04
            // 4 0000 1000  08
            // 5 0001 0000  10
            // 6 0010 0000  20
            // 7 0100 0000  40
            // 8 1000 0000  80
            // read status FF0000

            // Base URL and credentials

            //                      read status  all OFF   1 on       2 on       3             4        5            6         7          8      shut down
            string[] endpoints = { "/FF0000", "/FFE000", "/FFE001", "/FFE002", "/FFE004", "/FFE008", "/FFE010", "/FFE020", "/FFE040", "/FFE080", "" };

            string baseUrl = "http://" + URLName + ":" + URLPort.ToString() + endpoints[antcomm];
           
            if (antcomm == 0) baseUrl = "http://" + URLName + ":" + URLPort.ToString() + "/status.xml"; //  use this in c# with the user:pass are authenticaed separately later on


            Debug.WriteLine("baseurl " + baseUrl);
          //  Debug.WriteLine("readurl " + readUrl);
            Debug.WriteLine("Port " + URLPort.ToString());
            Debug.WriteLine("User " + URLUser);
            Debug.WriteLine("Pass " + URLPass);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl);
                request.Method = "GET";
                request.Timeout = 5000; // 5 seconds timeout
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";

                // Add authentication credentials (you MUST use this to access the website from C#, otherwise you will be denied access)
                if (!string.IsNullOrEmpty(URLUser) && !string.IsNullOrEmpty(URLPass))
                {
                    string authInfo = $"{URLUser}:{URLPass}";
                    string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(authInfo));
                    request.Headers.Add("Authorization", "Basic " + encodedAuthInfo);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string content = reader.ReadToEnd();  //  Debug.WriteLine("content================= " + content);

                            if (antcomm == 0)
                            {
                                XmlStatus(content); // xml status update only if antcomm = 0 
                            }
                            else
                            {

                                // find Status: 0 0  0 0  0 0  0 0 of all 8 relays within content
                                int index = content.IndexOf("Status: ");

                                if (index > 0)
                                {
                                    Debug.WriteLine(" index " + index);
                                    Debug.WriteLine("content " + content.Substring(index, 15));
                                }


                                _syncContext.Post(_ =>
                                {

                                    if (content[index + 8] == '1')
                                    {
                                        pictureBox1.BackColor = status1.BackColor = Color.Red;
                                        status1.Text = "ON";
                                    }
                                    else
                                    {
                                        pictureBox1.BackColor = status1.BackColor = Color.Green;
                                        status1.Text = "OFF";
                                    }

                                    if (content[index + 10] == '1')
                                    {
                                        pictureBox2.BackColor = status2.BackColor = Color.Red;
                                        status2.Text = "ON";
                                    }
                                    else
                                    {
                                        pictureBox2.BackColor = status2.BackColor = Color.Green;
                                        status2.Text = "OFF";
                                    }

                                    if (content[index + 13] == '1')
                                    {
                                        pictureBox3.BackColor = status3.BackColor = Color.Red;
                                        status3.Text = "ON";
                                    }
                                    else
                                    {
                                        pictureBox3.BackColor = status3.BackColor = Color.Green;
                                        status3.Text = "OFF";
                                    }

                                    if (content[index + 15] == '1')
                                    {
                                        pictureBox4.BackColor = status4.BackColor = Color.Red;
                                        status4.Text = "ON";
                                    }
                                    else
                                    {
                                        pictureBox4.BackColor = status4.BackColor = Color.Green;
                                        status4.Text = "OFF";
                                    }

                                    if (content[index + 18] == '1')
                                    {
                                        pictureBox5.BackColor = status5.BackColor = Color.Red;
                                        status5.Text = "ON";
                                    }
                                    else
                                    {
                                        pictureBox5.BackColor = status5.BackColor = Color.Green;
                                        status5.Text = "OFF";
                                    }

                                    if (content[index + 20] == '1')
                                    {
                                        pictureBox6.BackColor = status6.BackColor = Color.Red;
                                        status6.Text = "ON";
                                    }
                                    else
                                    {
                                        pictureBox6.BackColor = status6.BackColor = Color.Green;
                                        status6.Text = "OFF";
                                    }

                                    if (content[index + 23] == '1')
                                    {
                                        pictureBox7.BackColor = status7.BackColor = Color.Red;
                                        status7.Text = "ON";
                                    }
                                    else
                                    {
                                        pictureBox7.BackColor = status7.BackColor = Color.Green;
                                        status7.Text = "OFF";
                                    }

                                    if (content[index + 25] == '1')
                                    {
                                        pictureBox8.BackColor = status8.BackColor = Color.Red;
                                        status8.Text = "ON";
                                    }
                                    else
                                    {
                                        pictureBox8.BackColor = status8.BackColor = Color.Green;
                                        status8.Text = "OFF";
                                    }

                                }, null);

                            } // antcomm != 0

                            Debug.WriteLine("SEND COMMAND DONE");

                            CONNECTSTREAM = true;
                        } // read stream
                    } // read stream

                } // http

            } //try
            catch (WebException ex)
            {
                Debug.WriteLine($"Connection error: {ex.Message}");
                CONNECTSTREAM = false;
                GoodUrl = false;
                openurl = false;
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Connection error: {ex.Message}");
                CONNECTSTREAM = false;
                GoodUrl = false;
                openurl = false;
                return;
            }

        } // sendcommand


        //==============================================================================================
        // save changes made to text now as you close
        //==============================================================================================

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string file_name2 = "C:\\KMSWITCH\\ke9ns8.dat"; // save data for my mods

            Debug.WriteLine("\r\nCLOSE... UPDATE database file");

            FileStream stream2 = new FileStream(file_name2, FileMode.Create); // open BMP  file
            BinaryWriter writer2 = new BinaryWriter(stream2);

            writer2.Write(CATBaudRate);                             // Baud rate for COM PORT
            writer2.Write(CATPort);                                 // COM PORT to use
            writer2.Write(CATOn);                                   // enable

            writer2.Write(URLName);                                 // URL  of the KWSwitch 
            writer2.Write(URLPort);                                 //  Port of the KWSwitch
            writer2.Write(URLUser);                                 //  URL username
            writer2.Write(URLPass);                                 // URL password

            writer2.Write(buttonArray[0]);                             // button1 name
            writer2.Write(buttonArray[1]);                             // button2 name
            writer2.Write(buttonArray[2]);                             // button3 name
            writer2.Write(buttonArray[3]);                             // button4 name
            writer2.Write(buttonArray[4]);                             // button5 name
            writer2.Write(buttonArray[5]);                             // button6 name
            writer2.Write(buttonArray[6]);                             // button7 name
            writer2.Write(buttonArray[7]);                             // button8 name


            Debug.WriteLine("CAT Write: " + CATPort + ", " + CATBaudRate + ", " + CATOn + ", " + URLName + ", " + URLPort + ", " + URLUser + ", " + URLPass);


            for (int i = 0; i <= 16; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    writer2.Write(AntennaArray[i, j]);                  // store antenna array matix

                    if (AntennaArray[i, j] == true) Debug.WriteLine("Write " + i + "," + j + " " + AntennaArray[i, j]);
                }
            }

            writer2.Write("END");

            writer2.Close();    // close  file
            stream2.Close();   // close stream
            Debug.WriteLine("UPDATE new database file");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Select();

        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button2.Text = buttonArray[1] = textBox2.Text;
            textBox2.Visible = false;
        }

        public SIOListenerII Siolisten
        {
            get { return siolisten; }
            set { siolisten = value; }
        }

        private int cat_rig_type;
        public int CATRigType
        {
            get { return cat_rig_type; }
            set {
                cat_rig_type = value;
            }
        }

        private int url_port = 0;   // PORT 
        public int URLPort
        {
            get { return url_port; }
            set { url_port = value; }
        }


        private string url_name = ""; // URL to get into the KMSWITCH
        public string URLName
        {
            get { return url_name; }
            set { url_name = value; }
        }


        private string url_user = ""; // User name
        public string URLUser
        {
            get { return url_user; }
            set { url_user = value; }
        }


        private string url_pass = ""; // password 
        public string URLPass
        {
            get { return url_pass; }
            set { url_pass = value; }
        }


        public bool MaxtrixWait = false;

        public bool[,] ANTARRAY
        {
            get
            {
                return AntennaArray;
            }
            set
            {
                Array.Copy(value, AntennaArray, value.Length);
                Debug.WriteLine("Update Antennaarray maxtrix setup ANTARRY");

            }

        } //antarray


        private bool cat_on;
        public bool CATOn
        {
            get
            {
                return cat_on;
            }
            set
            {
                cat_on = value;
                if (setupForm != null)
                {
                    setupForm.chkCATEnable.Checked = cat_on;
                }
            }
        }


        private int cat_port;
        public int CATPort
        {
            get { return cat_port; }
            set { cat_port = value; }
        }

        private Parity cat_parity = Parity.None;
        public Parity CATParity
        {
            set { cat_parity = value; }
            get { return cat_parity; }
        }

        private StopBits cat_stop_bits = StopBits.One;
        public StopBits CATStopBits
        {
            set { cat_stop_bits = value; }
            get { return cat_stop_bits; }
        }


        private Handshake cat_handshake = Handshake.None;
        public Handshake CATHandshake
        {
            set { cat_handshake = value; }
            get { return cat_handshake; }
        }

        private int cat_data_bits = 8;
        public int CATDataBits
        {
            set { cat_data_bits = value; }
            get { return cat_data_bits; }
        }

        private int cat_baud_rate = 57600;
        public int CATBaudRate
        {
            set
            {
                Debug.WriteLine("set baud " + value);
                cat_baud_rate = value;
            }
            get
            {

                return cat_baud_rate;
            }
        }


        private bool cat_enabled;
        public bool CATEnabled
        {
            set
            {
                try
                {
                    cat_enabled = value;

                    Debug.WriteLine("cat enabled0 " + value);

                    if (siolisten == null) siolisten = new SIOListenerII(this);

                    if (siolisten != null)  // if we've got a listener tell them about state change 
                    {
                        if (cat_enabled)
                        {
                            Debug.WriteLine("cat enabled1 " + value);

                          // Siolisten.enableCAT(); // opens commPort here SIOListenerII.cs

                           // sDRSerialPort = new SDRSerialPort(CATPort, CATBaudRate, CATParity, CATDataBits, CATStopBits, CATHandshake);

                                                      
                            Debug.WriteLine("cat enabled2 " + value);


                         sDRSerialPort.put("AI1;"); // send Auto Info command to force SmartSDR to send FA vfo data back 


                        }

                        else
                        {
                            Siolisten.disableCAT();

                        }
                    }
                }
                catch (Exception)
                {
                    if (cat_port != 0)
                    {
                        MessageBox.Show(new Form { TopMost = true }, "Error enabling CAT on COM" + cat_port + ".\n" +
                            "Please check CAT settings and try again.",
                            "CAT Initialization Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(new Form { TopMost = true }, "Error enabling CAT comm port.\n" +
                            "Previously defined CAT comm port not enumerated.\n" +
                            "Please check CAT settings and try again.",
                            "CAT Initialization Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    //  if (spotForm != null) spotForm.CATEnabled = false;
                    CATEnabled = false;
                }

            } // set
            get { return cat_enabled; }
        } // CATEnabled

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox2.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            textBox3.Select();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            textBox4.Select();
        }



        private void button9_Click(object sender, EventArgs e)
        {

            if (setupForm == null || setupForm.IsDisposed) setupForm = new Setup(this); //.271 copy


            setupForm.Show();
            setupForm.Focus();
        }

        public int AF
        {
            get
            {
                //  return ptbAF.Value;
                return 0;
            }
            set
            {
                value = Math.Max(0, value);         // lower bound
                value = Math.Min(100, value);       // upper bound

                // ptbAF.Value = value;
                //ptbAF_Scroll(this, EventArgs.Empty);
            }
        }
        bool kw_auto_information = false;
        public bool KWAutoInformation
        {
            get { return kw_auto_information; }
            set { kw_auto_information = value; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //  string answer = parser.Get("FA;");
            //  textBox12.Text = answer;


            if (initflag == true)
                SendCommand(0); // periodically get status update of relays

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            button1.Text = buttonArray[0] = textBox1.Text;
            textBox1.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Text = buttonArray[1] = textBox2.Text;
            textBox2.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button3.Text = buttonArray[2] = textBox3.Text;
            textBox3.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button4.Text = buttonArray[3] = textBox4.Text;
            textBox4.Visible = false;
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            button5.Text = buttonArray[4] = textBox5.Text;
            textBox5.Visible = false;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            button6.Text = buttonArray[5] = textBox6.Text;
            textBox6.Visible = false;
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            button7.Text = buttonArray[6] = textBox7.Text;
            textBox7.Visible = false;
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            button8.Text = buttonArray[7] = textBox8.Text;
            textBox8.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox5.Visible = true;
            textBox5.Select();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Visible = true;
            textBox6.Select();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox7.Visible = true;
            textBox7.Select();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox8.Visible = true;
            textBox8.Select();
        }

        private void status6_TextChanged(object sender, EventArgs e)
        {

        }

        private void status6_TextChanged_1(object sender, EventArgs e)
        {

        }

        public void XmlStatus(string content)
        {

            XDocument doc = XDocument.Parse(content); // doc is a text based XML file

            int rly1 = int.Parse((doc.Root.Element("relay1"))?.Value?.Trim() ?? "0"); // look for the <element> then parse out its value (set 0 if the value is missing)
            int rly2 = int.Parse((doc.Root.Element("relay2"))?.Value?.Trim() ?? "0");
            int rly3 = int.Parse((doc.Root.Element("relay3"))?.Value?.Trim() ?? "0");
            int rly4 = int.Parse((doc.Root.Element("relay4"))?.Value?.Trim() ?? "0");
            int rly5 = int.Parse((doc.Root.Element("relay5"))?.Value?.Trim() ?? "0");
            int rly6 = int.Parse((doc.Root.Element("relay6"))?.Value?.Trim() ?? "0");
            int rly7 = int.Parse((doc.Root.Element("relay7"))?.Value?.Trim() ?? "0");
            int rly8 = int.Parse((doc.Root.Element("relay8"))?.Value?.Trim() ?? "0");

            Debug.WriteLine("XML RELAYS position: " + rly1 + rly2 + rly3 + rly4 + rly5 + rly6 + rly7 + rly8);


            // this allows the GUI to run asynchronously on a captured sychronization context
            // this  _syncContext.Post(_ => { stuff }, null); safely marshales the GUI update
            _syncContext.Post(_ =>
            {

                if (rly1 == 1)
                {
                    pictureBox1.BackColor = status1.BackColor = Color.Red;
                    status1.Text = "ON";
                }
                else
                {
                    pictureBox1.BackColor = status1.BackColor = Color.Green;
                    status1.Text = "OFF";
                }

                if (rly2 == 1)
                {
                    pictureBox2.BackColor = status2.BackColor = Color.Red;
                    status2.Text = "ON";
                }
                else
                {
                    pictureBox2.BackColor = status2.BackColor = Color.Green;
                    status2.Text = "OFF";
                }

                if (rly3 == 1)
                {
                    pictureBox3.BackColor = status3.BackColor = Color.Red;
                    status3.Text = "ON";
                }
                else
                {
                    pictureBox3.BackColor = status3.BackColor = Color.Green;
                    status3.Text = "OFF";
                }

                if (rly4 == 1)
                {
                    pictureBox4.BackColor = status4.BackColor = Color.Red;
                    status4.Text = "ON";
                }
                else
                {
                    pictureBox4.BackColor = status4.BackColor = Color.Green;
                    status4.Text = "OFF";
                }

                if (rly5 == 1)
                {
                    pictureBox5.BackColor = status5.BackColor = Color.Red;
                    status5.Text = "ON";
                }
                else
                {
                    pictureBox5.BackColor = status5.BackColor = Color.Green;
                    status5.Text = "OFF";
                }

                if (rly6 == 1)
                {
                    pictureBox6.BackColor = status6.BackColor = Color.Red;
                    status6.Text = "ON";
                }
                else
                {
                    pictureBox6.BackColor = status6.BackColor = Color.Green;
                    status6.Text = "OFF";
                }

                if (rly7 == 1)
                {
                    pictureBox7.BackColor = status7.BackColor = Color.Red;
                    status7.Text = "ON";
                }
                else
                {
                    pictureBox7.BackColor = status7.BackColor = Color.Green;
                    status7.Text = "OFF";
                }

                if (rly8 == 1)
                {
                    pictureBox8.BackColor = status8.BackColor = Color.Red;
                    status8.Text = "ON";
                }
                else
                {
                    pictureBox8.BackColor = status8.BackColor = Color.Green;
                    status8.Text = "OFF";
                }

            }, null);

        } // xmlstatus here



    }
 }
