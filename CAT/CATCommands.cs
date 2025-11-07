//=================================================================
// CATCommands.cs
//=================================================================
// Copyright (C) 2012  Bob Tracy
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
// You may contact the author via email at: k5kdn@arrl.net
//=================================================================


using System;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KMSWITCH
{
	/// <summary>
	/// Summary description for CATCommands.
	/// </summary>
	public class CATCommands
	{
		#region Variable Definitions

		private Form1 form1;
		private CATParser parser;
		private string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
		private Form1.Band[] BandList;
		private int LastBandIndex;
		private ASCIIEncoding AE = new ASCIIEncoding();
		private string lastFR = "0";
		private string lastFT = "0";

		//		public static Mutex CATmut = new Mutex();

        private bool verbose = false;
        public bool Verbose
        {
            get { return verbose; }
            set { verbose = value; }
        }


		#endregion Variable Definitions

		#region Constructors

		public CATCommands()
		{
		}

		public CATCommands(Form1 c,CATParser p)
		{
			form1 = c;
			parser = p;
		//	MakeBandList();
		}

		#endregion Constructors

		// Commands getting this far have been checked for a valid prefix, a correct suffix length,
		// and a terminator.  All we need to do in this class is to decide what kind of command
		// (read or set) and execute it.  Only read commands generate answers.

		#region Standard CAT Methods A-F

		// Sets or reads the Audio Gain control
		public string AG(string s)
		{
			
			if(s.Length == parser.nSet)	// if the length of the parameter legal for setting this prefix
			{
				int raw = Convert.ToInt32(s.Substring(1));
				int af = (int) Math.Round(raw/2.55,0);	// scale 255:100 (Kenwood vs SDR)
			//	form1.AF = af;		// Set the form1 control
				return "";
			}
			else if(s.Length == parser.nGet)	// if this is a read command
			{
				int af = 0; // (int) Math.Round(form1.AF/0.392,0);
//				return AddLeadingZeros(form1.AF);		// Get the form1 setting
				return AddLeadingZeros(af);
			}
			else
			{
				return parser.Error1;	// return a ?
			}
			
		}

		public string AI(string s)
		{
			return ZZAI(s);
			//			if(form1.SetupForm.AllowFreqBroadcast)
			//			{
			//				if(s.Length == parser.nSet)
			//				{
			//					if(s == "0")
			//						form1.KWAutoInformation = false;
			//					else 
			//						form1.KWAutoInformation = true;
			//					return "";
			//				}
			//				else if(s.Length == parser.nGet)
			//				{
			//					if(form1.KWAutoInformation)
			//						return "1";
			//					else
			//						return "0";
			//				}
			//				else
			//					return parser.Error1;
			//			}
			//			else
			//				return parser.Error1;
		}

		// Moves one band down from the currently selected band
		// write only
		public string BD()
		{
			//			BandDown();
			//			return "";
			return ZZBD();
		}

		// Moves one band up from the currently selected band
		// write only
		public string BU()
		{
			//			BandUp();
			//			return "";
			return ZZBU();
		}

        //Reads or sets the CTCSS frequency
        public string CN(string s)
        {
			// return ZZTB(s);
			return "";
        }

        //Reads or sets the CTCSS enable button
        public string CT(string s)
        {
			//  return ZZTA(s);
			return "";
        }

		//Moves the VFO A frequency by the step size set on the form1
		public string DN()
		{
			//			int step = form1.StepSize;
			//			double[] wheel_tune_list;
			//			wheel_tune_list = new double[13];		// initialize wheel tuning list array
			//			wheel_tune_list[0]  =  0.000001;
			//			wheel_tune_list[1]  =  0.000010;
			//			wheel_tune_list[2]  =  0.000050;
			//			wheel_tune_list[3]  =  0.000100;
			//			wheel_tune_list[4]  =  0.000250;
			//			wheel_tune_list[5]  =  0.000500;
			//			wheel_tune_list[6]  =  0.001000;
			//			wheel_tune_list[7]  =  0.005000;
			//			wheel_tune_list[8]  =  0.009000;
			//			wheel_tune_list[9]  =  0.010000;
			//			wheel_tune_list[10] =  0.100000;
			//			wheel_tune_list[11] =  1.000000;
			//			wheel_tune_list[12] = 10.000000;
			//
			//			form1.VFOAFreq = form1.VFOAFreq - wheel_tune_list[step];
			//			return "";

			//return ZZSA();
			return "";
		}

		// Sets or reads the frequency of VFO A
		public string FA(string s)
		{
			if (s.Length == parser.nSet) // in PowerSDR this is what you receive. Update VFOA with this new received string
			{
				s = s.Insert(5, separator);      //reinsert the global numeric separator

                 //  form1.VFOAFreq = double.Parse(s);

                Debug.WriteLine("nSET... " + s);
				return "";
			}
			else if (s.Length == parser.nGet) // in PowerSDr this is what PowerSDR send out to a request like FA; returns > FA00007299000;    string answer = parser.Get(txtInput.Text);
            {
                Debug.WriteLine("nGET... " + s);




				//  return StrVFOFreq("A");  // normally in PowerSDR this would send the current VFOA value out

				return "";
			}
			else
				return parser.Error1;
             //	return ZZFA(s);
		}

        // Converts a vfo frequency to a proper CAT frequency string
        private string StrVFOFreq(string vfo)
        {
            double freq = 0;
            string cmd_string = "";

			/*
            if (vfo == "A")
                freq = Math.Round(form1.CATVFOA, 6);
            else if (vfo == "B")
                freq = Math.Round(form1.CATVFOB, 6);
            else if (vfo == "C")
                freq = Convert.ToDouble(form1.CATQMSValue);


            if ((int)freq < 10)
            {
                cmd_string += "0000" + freq.ToString();
            }
            else if ((int)freq < 100)
            {
                cmd_string += "000" + freq.ToString();
            }
            else if ((int)freq < 1000)
            {
                cmd_string += "00" + freq.ToString();
            }
            else if ((int)freq < 10000)
            {
                cmd_string += "0" + freq.ToString();
            }
            else
                cmd_string = freq.ToString();

            // Get rid of the decimal separator and pad the right side with 0's 
            // Modified 05/01/05 BT for globalization
            if (cmd_string.IndexOf(separator) > 0)
                cmd_string = cmd_string.Remove(cmd_string.IndexOf(separator), 1);
            cmd_string = cmd_string.PadRight(11, '0');

			*/
            return cmd_string;
        }

        // Sets or reads the frequency of VFO B
        public string FB(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				s = s.Insert(5,separator);
			//				form1.VFOBFreq = double.Parse(s);
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//				return StrVFOFreq("B");
			//			else
			//				return parser.Error1;
			//return ZZFB(s);
			return "";
		}

		// Sets VFO A to control rx
		// this is a dummy command to keep other software happy
		// since the SDR-1000 always uses VFO A for rx
		public string FR(string s)
		{
			if(s.Length == parser.nSet)
			{
				return "";
			}
			else if(s.Length == parser.nGet)
				return "0";
			else
				return parser.Error1;
		}

		// Sets or reads VFO B to control tx
		// another "happiness" command
		public string FT(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "1")
			//				{
			//					form1.VFOSplit = true;
			//				}
			//				else if(s == "0")
			//				{
			//					form1.VFOSplit = false;
			//				}
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return ZZSP(s);
			//			}
			//			else
			//				return parser.Error1;
			//	return ZZSP(s);
			return "";
		}

		// Sets or reads the DSP filter width
		//OBSOLETE
		public string FW(string s)
		{
			if(s.Length == parser.nSet)
			{
				//form1.RX1Filter = String2Filter(s);
				return "";
			}
			//else if(s.Length == parser.nGet)
			//	return Filter2String(form1.RX1Filter);
		//	else
				return parser.Error1;
		}

		#endregion Standard CAT Methods A-F

		#region Standard CAT Methods G-M

		// Sets or reads the AGC constant
		// this is a wrapper that calls ZZGT
		public string GT(string s)
		{
			//if(ZZGT(s).Length > 0)
			//	return ZZGT(s).PadLeft(3,'0');		//Added padleft fix 4/2/2007 BT
			//else
				return "";
		}

		// Reads the transceiver ID number
		// this needs changing when 3rd party folks on line.
		public string ID()
		{
			string id;
			switch(form1.CATRigType)
			{
				case 900:
					id = "900";		//SDR-1000
					break;
				case 13:
					id = "013";		//TS-50S
					break;
				case 19:
					id = "019";		//TS-2000
					break;
				case 20:
					id = "020";		//TS-480
					break;
				default:
					id = "019";
					break;
			}
			return(id);
		}

		// Reads the transceiver status
		// needs work in the split area
	
		//Sets or reads the CWX CW speed
		public string KS(string s)
		{
			//			int cws = 0;
			//			// Make sure we have an instance of the form
			//			if(form1.CWXForm == null || form1.CWXForm.IsDisposed)
			//			{
			//				try
			//				{
			//					form1.CWXForm = new CWX(form1);
			//				}
			//				catch
			//				{
			//					return parser.Error1;
			//				}
			//			}
			//			if(s.Length == parser.nSet)
			//			{
			//				cws = Convert.ToInt32(s);
			//				cws = Math.Max(1, cws);
			//				cws = Math.Min(99, cws);
			//				form1.CWXForm.WPM = cws;
			//				return "";
			//
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return AddLeadingZeros(form1.CWXForm.WPM);
			//			}
			//			else
			//				return parser.Error1;
			//return ZZKS(s);
			return "";
		}

		//Sends text data to CWX for conversion to Morse
	

		// Sets or reads the transceiver mode
		public string MD(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(Convert.ToInt32(s) > 0 && Convert.ToInt32(s) <= 9)
				{
				//	KString2Mode(s);
					return "";
				}
				else
					return parser.Error1;
			}
			
			else
				return parser.Error1;
		}

		// Sets or reads the Mic Gain thumbwheel
		public string MG(string s)
		{
			/*
			int n;
			if(s.Length == parser.nSet)	
			{
				n = Convert.ToInt32(s);
				n = Math.Max(0, n);
				n = Math.Min(100, n);
				int mg = (int) Math.Round(n/1.43,0);	// scale 100:70 (Kenwood vs SDR)
				s = AddLeadingZeros(mg);
				return ZZMG(s);
			}
			else if(s.Length == parser.nGet)
			{
				s = ZZMG("");
				n = Convert.ToInt32(s);
				int mg = (int) Math.Round(n/.7,0);
				s = AddLeadingZeros(mg);
				return s;
			}
			else
				return parser.Error1;

			*/
			return parser.Error1;
		}

		// Sets or reads the Monitor status
		public string MO(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "0")
			//					form1.MON = false;
			//				else if(s == "1")
			//					form1.MON = true;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				bool retval = form1.MON;
			//				if(retval)
			//					return "1";
			//				else
			//					return "0";
			//			}
			//			else
			//				return parser.Error1;
			//return ZZMO(s);
			return "";
		}

		#endregion Standard CAT Methods G-M

		#region Standard CAT Methods N-Q

		// Sets or reads the Noise Blanker 1 status
		public string NB(string s)
		{
			//			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			//			{
			//				form1.CATNB1 = Convert.ToInt32(s);
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return form1.CATNB1.ToString();
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			//return ZZNA(s);
			return "";
		}

		// Sets or reads the Automatic Notch Filter status
		public string NT(string s)
		{
			//			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			//			{
			//				form1.CATANF = Convert.ToInt32(s);
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return form1.CATANF.ToString();
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			//	return ZZNT(s);
			return "";
		}

        //Sets or reads the FM repeater offset frequency
        public string OF(string s)
        {
           // return ZZOT(s);
			return "";

        }

        //Sets or reads the repeater offset direction
        public string OS(string s)
        {
			// return ZZOS(s);
			return "";
        }


		// Sets or reads the PA output thumbwheel
		public string PC(string s)
		{
			//			int pwr = 0;
			//
			//			if(s.Length == parser.nSet)
			//			{
			//				pwr = Convert.ToInt32(s);
			//				form1.PWR = pwr;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return AddLeadingZeros(form1.PWR);
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			//return ZZPC(s);
			return "";

		}

		// Sets or reads the Speech Compressor status
        //Reactivated 10/21/2012 for HRD compatibility BT
		public string PR(string s)
		{
            if (s.Length == parser.nGet)
			{
    			return "0";
            }
            else
            {
                return parser.Error1;
            }
		}

		// Sets or reads the form1 power on/off status
		public string PS(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "0")
			//					form1.PowerOn = false;
			//				else if(s == "1")
			//					form1.PowerOn = true;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				bool pwr = form1.PowerOn;
			//				if(pwr)
			//					return "1";
			//				else
			//					return "0";
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			//return ZZPS(s);
			return "";
		}

		// Sets the Quick Memory with the current contents of VFO A
		public string QI()
		{
//			form1.CATMemoryQS();
			return "";
		//	return ZZQS();
		}

		#endregion Standard CAT Methods N-Q

		#region Standard CAT Methods R-Z

		// Clears the RIT value
		// write only
		public string RC()
		{
//			form1.RITValue = 0;
			return "";
		//	return ZZRC();
		}

		//Decrements RIT
		public string RD(string s)
		{
			//	return ZZRD(s);
			return "";
		}


		// Sets or reads the RIT status (on/off)
		public string RT(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "0")
			//					form1.RITOn = false;
			//				else if(s == "1") 
			//					form1.RITOn = true;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				bool rit = form1.RITOn;
			//				if(rit)
			//					return "1";
			//				else
			//					return "0";
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			//return ZZRT(s);
			return "";
		}

		//Increments RIT
		public string RU(string s)
		{
			//return ZZRU(s);
			return "";
		}


		// Sets or reads the transceiver receive mode status
		// write only but spec shows an answer parameter for a read???
		public string RX(string s)
		{
		//	form1.CATPTT = false;
			return "";
			//return ZZTX("0");
		}

		// Sets or reads the variable DSP filter high side
	
		// Sets or reads the variable DSP filter low side
	
		// Reads the S Meter value
	
		// Sets or reads the Squelch value
		
		// Sets the transmitter on, write only
		// will eventually need eiter Commander change or ZZ code
		// since it is not CAT compliant as it is
		public string TX(string s)
		{
		//	form1.CATPTT = true;
			return "";
			//return ZZTX("1");
		}

		//Moves the VFO A frequency up by the step size set on the form1
		public string UP()
		{
			//			int step = form1.StepSize;
			//			double[] wheel_tune_list;
			//			wheel_tune_list = new double[13];		// initialize wheel tuning list array
			//			wheel_tune_list[0]  =  0.000001;
			//			wheel_tune_list[1]  =  0.000010;
			//			wheel_tune_list[2]  =  0.000050;
			//			wheel_tune_list[3]  =  0.000100;
			//			wheel_tune_list[4]  =  0.000250;
			//			wheel_tune_list[5]  =  0.000500;
			//			wheel_tune_list[6]  =  0.001000;
			//			wheel_tune_list[7]  =  0.005000;
			//			wheel_tune_list[8]  =  0.009000;
			//			wheel_tune_list[9]  =  0.010000;
			//			wheel_tune_list[10] =  0.100000;
			//			wheel_tune_list[11] =  1.000000;
			//			wheel_tune_list[12] = 10.000000;
			//
			//			form1.VFOAFreq = form1.VFOAFreq + wheel_tune_list[step];
			//			return "";

			//	return ZZSB();
			return "";
		}


		// Sets or reads the transceiver XIT status (on/off)
		public string XT(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "0")
			//					form1.XITOn = false;
			//				else
			//					if(s == "1") 
			//					form1.XITOn = true;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				bool xit = form1.XITOn;
			//				if(xit)
			//					return "1";
			//				else
			//					return "0";
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			return ZZXS(s);

		}

		#endregion Standard CAT Methods R-Z

		#region Extended CAT Methods ZZA-ZZF


        //Sets or reads the form1 step size (also see zzst(read only)
      
        //Sets VFO A down nn Tune Steps
    
		// Sets or reads the SDR-1000 Audio Gain control
		public string ZZAG(string s)
		{
			int af = 0;

			if(s.Length == parser.nSet)	// if the length of the parameter legal for setting this prefix
			{
				af = Convert.ToInt32(s);
				af = Math.Max(0, af);
				af = Math.Min(100, af);
				form1.AF = af;		// Set the form1 control
				return "";
			}
			else if(s.Length == parser.nGet)	// if this is a read command
			{
				return AddLeadingZeros(form1.AF);		// Get the form1 setting
			}
			else
			{
				return parser.Error1;	// return a ?
			}

		}

		public string ZZAI(string s)
		{
			if(form1.setupForm.AllowFreqBroadcast)
			{
				if(s.Length == parser.nSet)
				{
					if(s == "0")
						form1.KWAutoInformation = false;
					else 
						form1.KWAutoInformation = true;
					return "";
				}
				else if(s.Length == parser.nGet)
				{
					if(form1.KWAutoInformation)
						return "1";
					else
						return "0";
				}
				else
					return parser.Error1;
			}
			else
				return parser.Error1;
		}

		//Sets or reads the AGC RF gain
		public string ZZAR(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-20, n);
				n = Math.Min(120, n);
			}

			if(s.Length == parser.nSet)
			{
			//	form1.RF = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
			//	x = form1.RF;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}

		}

        //Sets or reads the RX2 AGC-T
        public string ZZAS(string s)
        {
            /*
            if (form1.CurrentModel == Model.FLEX5000 && FWCEEPROM.RX2OK)
            {
                int n = 0;
                int x = 0;
                string sign;

                if (s != "")
                {
                    n = Convert.ToInt32(s);
                    n = Math.Max(-20, n);
                    n = Math.Min(120, n);
                }

                if (s.Length == parser.nSet)
                {
                    form1.RX2RF = n;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    x = form1.RX2RF;
                    if (x >= 0)
                        sign = "+";
                    else
                        sign = "-";
                    // we have to remove the leading zero and replace it with the sign.
                    return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

			*/

            parser.Verbose_Error_Code = 7;
            return parser.Error1;
        }

        //Sets VFO A up nn Tune Steps
        public string ZZAU(string s)
        {
            int step = 0;
            if (s.Length == parser.nSet)
            {
                step = Convert.ToInt32(s);
                if (step >= 0 || step <= 14)
                {
                 //   form1.VFOAFreq = form1.CATVFOA + Step2Freq(step);
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

        //Moves the RX2 bandswitch down one band
        public string ZZBA()
        {
           // if (form1.CurrentModel == Model.FLEX5000 && FWCEEPROM.RX2OK)
          //  {
            //    form1.CATRX2BandUpDown(-1);
                return "";
           // }
          //  else
          //  {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
           // }
        }

        //Moves the RX2 bandswitch up one band
        public string ZZBB()
        {
         //   if (form1.CurrentModel == Model.FLEX5000 && FWCEEPROM.RX2OK)
          //  {
         //       form1.CATRX2BandUpDown(1);
                return "";
          //  }
           // else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }
        }


		//Moves the RX1 bandswitch down one band
		public string ZZBD()
		{
		//	BandDown();
			return "";
		}

		// Sets the Band Group (HF/VHF)
		public string ZZBG(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				//form1.CATBandGroup = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				//return form1.CATBandGroup.ToString();
				return parser.Error1;
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the BIN button status
		public string ZZBI(string s)
		{
			if (s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				//form1.CATBIN = Convert.ToInt32(s);
				return "";
			}
			else if (s.Length == parser.nGet)
			{
				//	return form1.CATBIN.ToString();

				return parser.Error1;
			}
             else
             {
                return parser.Error1;
			}
		}

        //Sets VFO B down nn Tune Steps
        public string ZZBM(string s)
        {
            int step = 0;
            if (s.Length == parser.nSet)
            {
                step = Convert.ToInt32(s);
                if (step >= 0 || step <= 14)
                {
                 //   form1.VFOBFreq = form1.CATVFOB - Step2Freq(step);
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

        //Sets VFO B up nn Tune Steps
        public string ZZBP(string s)
        {
            int step = 0;
            if (s.Length == parser.nSet)
            {
                step = Convert.ToInt32(s);
                if (step >= 0 || step <= 14)
                {
                 //   form1.VFOBFreq = form1.CATVFOB + Step2Freq(step);
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

		//Sets or reads the BCI Rejection button status
		public string ZZBR(string s)
		{
			/*
			if(form1.CurrentModel == Model.SDR1000)
			{
				int sx = 0;

				if(s != "")
					sx = Convert.ToInt32(s);

				if(s.Length == parser.nSet && (s == "0" || s == "1"))
				{
					form1.CATBCIReject = sx;
					return "";
				}
				else if(s.Length == parser.nGet)
				{
					return form1.CATBCIReject.ToString();
				}
				else
				{
					return parser.Error1;
				}
			}
			else
				return parser.Error1;

			*/
			return parser.Error1;
		}


		//Sets or reads the current band setting
		public string ZZBS(string s)
		{
			//return GetBand(s);
			return "";
		}

        //Sets or gets the current RX2 band setting
        public string ZZBT(string s)
        {

            /*
            if (form1.CurrentModel == Model.FLEX5000 && FWCEEPROM.RX2OK)
            {
                if (s.Length == parser.nGet)
                {
                    return Band2String(form1.RX2Band);
                }
                else if (s.Length == parser.nSet)
                {
                    form1.RX2Band = String2Band(s);
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }
			*/
            return parser.Error1;
        }

  
		//Moves the bandswitch up one band
		public string ZZBU()
		{
		//	BandUp();
			return "";
		}

        //Shuts down the form1
        public string ZZBY()
        {
            this.form1.Close();
            return "";
        }

		// Sets or reads the CW Break In Enabled checkbox
		public string ZZCB(string s)
		{

            /*
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					form1.BreakInEnabled = true;
				else
					form1.BreakInEnabled = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(form1.BreakInEnabled)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
			*/
            return parser.Error1;
        }


		// Sets or reads the CW Break In Delay
		public string ZZCD(string s)
		{
			int n = 0;

            /*
			if(s != null && s != "")
				n = Convert.ToInt32(s);
			n = Math.Max(150, n);
			n = Math.Min(5000, n);

			if(s.Length == parser.nSet)
			{
				form1.setupForm.BreakInDelay = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros((int) form1.setupForm.BreakInDelay);
			}
			else
			{
				return parser.Error1;
			}
*/
            return parser.Error1;
        }

		// Sets or reads the Show CW Frequency checkbox
		public string ZZCF(string s)
		{

            /*
			switch(form1.RX1DSPMode)
			{
				case DSPMode.CWL:
				case DSPMode.CWU:
					if(s.Length == parser.nSet && (s == "0" || s == "1"))
					{
						if(s == "1")
							form1.ShowCWTXFreq = true;
						else
							form1.ShowCWTXFreq = false;
						return "";
					}
					else if(s.Length == parser.nGet)
					{
						if(form1.ShowCWTXFreq)
							return "1";
						else
							return "0";
					}
					else
					{
						return parser.Error1;
					}
				default:
					return parser.Error1;
			}

			*/
            return parser.Error1;
        }

		// Sets or reads the CW Iambic checkbox
		public string ZZCI(string s)
		{
            /*
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					form1.CWIambic = true;
				else
					form1.CWIambic = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(form1.CWIambic)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
			*/
            return parser.Error1;
        }

		// Sets or reads the CW Pitch thumbwheel
		public string ZZCL(string s)
		{
            /*
			int n = 0;
			if(s != "")
				n = Convert.ToInt32(s);

			if(s.Length == parser.nSet)
			{
				form1.setupForm.CATCWPitch = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(form1.setupForm.CATCWPitch);
			}
			else
			{
				return parser.Error1;
			}

			*/
            return parser.Error1;
        }

		// Sets or reads the CW Monitor Disable button status
		public string ZZCM(string s)
		{
            /*
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					form1.CWSidetone = false;
				else
					form1.CWSidetone = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(form1.CWSidetone)
					return "0";
				else
					return "1";
			}
			else
			{
				return parser.Error1;
			}
			*/
            return parser.Error1;
        }

		// Sets or reads the compander button status
		public string ZZCP(string s)
		{
            /*
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					form1.CATCmpd = 0;
				else if(s == "1")
					form1.CATCmpd = 1;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return form1.CATCmpd.ToString();
			}
			else
			{
				return parser.Error1;
			}

			*/
            return parser.Error1;
        }

		// Sets or reads the CW Speed thumbwheel
		public string ZZCS(string s)
		{
			int n = 1;
            /*
			if(s != "")
				n = Convert.ToInt32(s);

			if(s.Length == parser.nSet)
			{
				form1.CATCWSpeed = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(form1.CATCWSpeed);
			}
			else
			{
				return parser.Error1;
			}

			*/
            return parser.Error1;
        }

		//Reads or sets the compander threshold
		public string ZZCT(string s)
		{
            /*
			int n = 0;

			if(s != null && s != "")
				n = Convert.ToInt32(s);
			n = Math.Max(0, n);
			n = Math.Min(10, n);

			if(s.Length == parser.nSet)
			{
				form1.CPDRVal = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros((int) form1.CPDRVal);
			}
			else
			{
				return parser.Error1;
			}
*/
            return parser.Error1;
        }

		// Reads the CPU Usage
		public string ZZCU()
		{
		//return form1.CpuUsage.ToString("f").PadLeft(6,'0');

           

            return parser.Error1;
        }

		// Sets or reads the Display Average status
		public string ZZDA(string s)
		{

            /*
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				form1.CATDisplayAvg = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return form1.CATDisplayAvg.ToString();
			}
			else
			{
				return parser.Error1;
			}
*/
            return parser.Error1;
        }

   
		

		
     

     
		
		


		// Sets or reads the F1500F5K Mixer Mic Selected Checkbox
		public string ZZWE(string s)
		{
            /*
            if (form1.CurrentModel == Model.FLEX5000 || form1.CurrentModel == Model.FLEX1500)
            {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        form1.fwcMixForm.MicInputSelected = s;
                    else
                        form1.flex1500MixerForm.MicInputSelectedStr = s;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        return form1.fwcMixForm.MicInputSelected;
                    else
                        return form1.flex1500MixerForm.MicInputSelectedStr;
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

			*/
            return parser.Error1;
        }

		// Sets or reads the F5K Mixer Line In RCA Checkbox
		public string ZZWF(string s)
		{
            /*
            if (form1.CurrentModel == Model.FLEX5000)
            {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    form1.fwcMixForm.LineInRCASelected = s;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    return form1.fwcMixForm.LineInRCASelected;
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

			*/
            return parser.Error1;
        }

		// Sets or reads the F5K Mixer Line In Phono Checkbox
		public string ZZWG(string s)
		{
			/*
            if (form1.CurrentModel == Model.FLEX5000)
            {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    form1.fwcMixForm.LineInPhonoSelected = s;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    return form1.fwcMixForm.LineInPhonoSelected;
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

            */

            return parser.Error1;
        }

		// Sets or reads the F1500/F5K Mixer Line In FlexWire/DB9 Checkbox
		public string ZZWH(string s)
		{
          /*  if (form1.CurrentModel == Model.FLEX5000 || form1.CurrentModel == Model.FLEX1500)
            {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        form1.fwcMixForm.LineInDB9Selected = s;
                    else
                        form1.flex1500MixerForm.LineInDB9Selected = s;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        return form1.fwcMixForm.LineInDB9Selected;
                    else
                        return form1.flex1500MixerForm.LineInDB9Selected;
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }


            */

            return parser.Error1;
        }


		// Sets or reads the F5K Mixer Mute All Checkbox
		public string ZZWJ(string s)
		{
           /*
             if (form1.CurrentModel == Model.FLEX5000 || form1.CurrentModel == Model.FLEX1500)
            {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        form1.fwcMixForm.InputMuteAll = s;
                    else
                        form1.flex1500MixerForm.InputMuteAll = s;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        return form1.fwcMixForm.InputMuteAll;
                    else
                        return form1.flex1500MixerForm.InputMuteAll;
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

            */

            return parser.Error1;
        }

		//Sets or reads the F5K Mixer Internal Speaker level
		public string ZZWK(string s)
		{
//			if(form1.CurrentModel == Model.FLEX5000)
          
			
			/*if (FWCEEPROM.Model == 1) // FLEX-5000C
            {
                int n = 0;
                int x = 0;

                if (s != "")
                {
                    n = Int32.Parse(s);
                    n = Math.Max(128, n);
                    n = Math.Min(255, n);
                }

                if (s.Length == parser.nSet)
                {
                    if (form1.fwcMixForm.InternalSpkrSelected == "1")
                    {
                        form1.fwcMixForm.InternalSpkr = n;
                        return "";
                    }
                    else
                        return parser.Error1;

                }
                else if (s.Length == parser.nGet)
                {
                    x = form1.fwcMixForm.InternalSpkr;
                    return AddLeadingZeros(x);
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }
            */

            return parser.Error1;
        }

		//Sets or reads the F5K Mixer External Speaker level
		public string ZZWL(string s)
		{
          /*  if (form1.CurrentModel == Model.FLEX5000)
            {
                int n = 0;
                int x = 0;

                if (s != "")
                {
                    n = Int32.Parse(s);
                    n = Math.Max(128, n);
                    n = Math.Min(255, n);
                }

                if (s.Length == parser.nSet)
                {
                    if (form1.fwcMixForm.ExternalSpkrSelected == "1")
                    {
                        form1.fwcMixForm.ExternalSpkr = n;
                        return "";
                    }
                    else
                        return parser.Error1;

                }
                else if (s.Length == parser.nGet)
                {
                    x = form1.fwcMixForm.ExternalSpkr;
                    return AddLeadingZeros(x);
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }
            */

            return parser.Error1;
        }

		//Sets or reads the F5K Mixer Headphone level
		public string ZZWM(string s)
		{
            /*  if (form1.CurrentModel == Model.FLEX5000)
              {
                  int n = 0;
                  int x = 0;

                  if (s != "")
                  {
                      n = Int32.Parse(s);
                      n = Math.Max(128, n);
                      n = Math.Min(255, n);
                  }

                  if (s.Length == parser.nSet)
                  {
                      if (form1.fwcMixForm.HeadphoneSelected == "1")
                      {
                          form1.fwcMixForm.Headphone = n;
                          return "";
                      }
                      else
                          return parser.Error1;

                  }
                  else if (s.Length == parser.nGet)
                  {
                      x = form1.fwcMixForm.Headphone;
                      return AddLeadingZeros(x);
                  }
                  else
                      return parser.Error1;
              }
              else
              {
                  parser.Verbose_Error_Code = 7;
                  return parser.Error1;
              }

              */
            return parser.Error1;
        }

		//Sets or reads the F5K Mixer Line Out RCA level
		public string ZZWN(string s)
		{
            /*   if (form1.CurrentModel == Model.FLEX5000)
               {
                   int n = 0;
                   int x = 0;

                   if (s != "")
                   {
                       n = Int32.Parse(s);
                       n = Math.Max(128, n);
                       n = Math.Min(255, n);
                   }

                   if (s.Length == parser.nSet)
                   {
                       if (form1.fwcMixForm.LineOutRCASelected == "1")
                       {
                           form1.fwcMixForm.LineOutRCA = n;
                           return "";
                       }
                       else
                           return parser.Error1;

                   }
                   else if (s.Length == parser.nGet)
                   {
                       x = form1.fwcMixForm.LineOutRCA;
                       return AddLeadingZeros(x);
                   }
                   else
                       return parser.Error1;
               }
               else
               {
                   parser.Verbose_Error_Code = 7;
                   return parser.Error1;
               }

               */
            return parser.Error1;
        }

		// Sets or reads the F5KC Mixer Internal Speaker Selected Checkbox
		public string ZZWO(string s)
		{
           /* if (FWCEEPROM.Model == 1)
            {
                    if (s.Length == parser.nSet && (s == "0" || s == "1"))
                    {
                        form1.fwcMixForm.InternalSpkrSelected = s;
                        return "";
                    }
                    else if (s.Length == parser.nGet)
                    {
                        return form1.fwcMixForm.InternalSpkrSelected;
                    }
                    else
                        return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

            */

            return parser.Error1;
        }

		// Sets or reads the F5K Mixer External Speaker Selected Checkbox
		public string ZZWP(string s)
		{
            /*  if (form1.CurrentModel == Model.FLEX5000)
              {
                  if (s.Length == parser.nSet && (s == "0" || s == "1"))
                  {
                      form1.fwcMixForm.ExternalSpkrSelected = s;
                      return "";
                  }
                  else if (s.Length == parser.nGet)
                  {
                      return form1.fwcMixForm.ExternalSpkrSelected;
                  }
                  else
                      return parser.Error1;
              }
              else
              {
                  parser.Verbose_Error_Code = 7;
                  return parser.Error1;
              }

              */
            return parser.Error1;
        }

		// Sets or reads the F1500F5K Mixer Headphone Selected Checkbox
		public string ZZWQ(string s)
		{
			/*
            if (form1.CurrentModel == Model.FLEX5000 || form1.CurrentModel == Model.FLEX1500)
            {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        form1.fwcMixForm.HeadphoneSelected = s;
                    else
                        form1.flex1500MixerForm.PhonesSelectedStr = s;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        return form1.fwcMixForm.HeadphoneSelected;
                    else
                        return form1.flex1500MixerForm.PhonesSelectedStr;
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

            */

            return parser.Error1;
        }

		// Sets or reads the F1500 FlexWire Out/F5K Mixer Line Out RCA Selected Checkbox
		public string ZZWR(string s)
		{
            /*
            if (form1.CurrentModel == Model.FLEX5000 || form1.CurrentModel == Model.FLEX1500)
            {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        form1.fwcMixForm.LineOutRCASelected = s;
                    else
                        form1.flex1500MixerForm.FlexWireOutSelectedStr = s;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        return form1.fwcMixForm.LineOutRCASelected;
                    else
                        return form1.flex1500MixerForm.FlexWireOutSelectedStr;
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }
			*/
            return parser.Error1;
        }

		// Sets or reads the F1500/F5K Mixer Output Mute All Checkbox
		public string ZZWS(string s)
		{
         /*   if (form1.CurrentModel == Model.FLEX5000 || form1.CurrentModel == Model.FLEX1500)
            {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        form1.fwcMixForm.OutputMuteAll = s;
                    else
                        form1.flex1500MixerForm.OutputMuteAll = s;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    if (form1.CurrentModel == Model.FLEX5000)
                        return form1.fwcMixForm.OutputMuteAll;
                    else
                        return form1.flex1500MixerForm.OutputMuteAll;
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

            */

            return parser.Error1;
        }


        //Reads or sets the F1500 mixer form mic level
        public string ZZWT(string s)
        {
			/*  if (form1.CurrentModel == Model.FLEX1500)
			  {
				  int n = 0;

				  if (s != "")
				  {
					  n = Int32.Parse(s);
					  n = Math.Max(0, n);
					  n = Math.Min(119, n);
				  }

				  if (s.Length == parser.nSet)
				  {
					  if (form1.flex1500MixerForm.MicInputSelectedStr == "1")
					  {
						  form1.flex1500MixerForm.MicInput = n;
						  return "";
					  }
					  else
						  return parser.Error1;

				  }
				  else if (s.Length == parser.nGet)
				  {
					  return AddLeadingZeros(form1.flex1500MixerForm.MicInput);
				  }
				  else
					  return parser.Error1;
			  }
			  else
			  {
				  parser.Verbose_Error_Code = 7;
				  return parser.Error1;
			  }
			*/
			return parser.Error1;
		}

        //Reads or sets the F1500 Mixer Form FireWire Input Level
        public string ZZWU(string s)
        {
			/* if (form1.CurrentModel == Model.FLEX1500)
			 {
				 int n = 0;

				 if (s != "")
				 {
					 n = Int32.Parse(s);
					 n = Math.Max(0, n);
					 n = Math.Min(119, n);
				 }

				 if (s.Length == parser.nSet)
				 {
					 if (form1.flex1500MixerForm.LineInDB9Selected == "1")
					 {
						 form1.flex1500MixerForm.FlexWireIn = n;
						 return "";
					 }
					 else
						 return parser.Error1;

				 }
				 else if (s.Length == parser.nGet)
				 {
					 return AddLeadingZeros(form1.flex1500MixerForm.FlexWireIn);
				 }
				 else
					 return parser.Error1;
			 }
			 else
			 {
				 parser.Verbose_Error_Code = 7;
				 return parser.Error1;
			 }
			*/
			return parser.Error1;
        }

        //Sets ir reads the F1500 Mixer Form Phones level
        public string ZZWV(string s)
        {
			/*    if (form1.CurrentModel == Model.FLEX1500)
				{
					int n = 0;

					if (s != "")
					{
						n = Int32.Parse(s);
						n = Math.Max(0, n);
						n = Math.Min(127, n);
					}

					if (s.Length == parser.nSet)
					{
						if (form1.flex1500MixerForm.PhonesSelectedStr == "1")
						{
							form1.flex1500MixerForm.Phones = n;
							return "";
						}
						else
							return parser.Error1;

					}
					else if (s.Length == parser.nGet)
					{
						return AddLeadingZeros(form1.flex1500MixerForm.Phones);
					}
					else
						return parser.Error1;
				}
				else
				{
					parser.Verbose_Error_Code = 7;
					return parser.Error1;
				}
			*/
			return parser.Error1;
        }

        //Sets or reads the F1500 Mixer Form FlexWire Out level
        public string ZZWW(string s)
        {
            /*
            if (form1.CurrentModel == Model.FLEX1500)
            {
                int n = 0;

                if (s != "")
                {
                    n = Int32.Parse(s);
                    n = Math.Max(0, n);
                    n = Math.Min(127, n);
                }

                if (s.Length == parser.nSet)
                {
                    if (form1.flex1500MixerForm.FlexWireOutSelectedStr == "1")
                    {
                        form1.flex1500MixerForm.FlexWireOut = n;
                        return "";
                    }
                    else
                        return parser.Error1;

                }
                else if (s.Length == parser.nGet)
                {
                    return AddLeadingZeros(form1.flex1500MixerForm.FlexWireOut);
                }
                else
                    return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }

			*/
            return parser.Error1;
        }

		// Clears the XIT frequency
		// write only
		public string ZZXC()
		{
			//form1.XITValue = 0;
			return "";
		}

		// Sets or reads the XIT frequency value
		public string ZZXF(string s)
		{
            /*
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-99999, n);
				n = Math.Min(99999, n);
			}

			if(s.Length == parser.nSet)
			{
				form1.XITValue = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = form1.XITValue;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}

			*/
            return parser.Error1;
        }

		//Sets or reads the XIT button status
		public string ZZXS(string s)
		{

            /*
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					form1.XITOn = false;
				else
					if(s == "1") 
					form1.XITOn = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool xit = form1.XITOn;
				if(xit)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}

			*/
            return parser.Error1;
        }

		//Sets or reads the X2TR button status
		public string ZZXT(string s)
		{

            /*
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					form1.X2TR = false;
				else if(s == "1")
					form1.X2TR = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool x2tr = form1.X2TR;
				if(x2tr)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}

			*/
            return parser.Error1;
        }

        // Reads or sets the VAC2 Direct I/Q checkbox on the setup form
        public string ZZYA(string s)
        {
            /*
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "0")
                    form1.setupForm.VAC2DirectIQ = false;
                else if (s == "1")
                    form1.setupForm.VAC2DirectIQ = true;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                bool retval = form1.setupForm.VAC2DirectIQ;
                if (retval)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
			*/
            return parser.Error1;
        }

        // Reads or sets the VAC2 IQ Calibrate checkbox on the setup form
        public string ZZYB(string s)
        {
            /*
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "0")
                    form1.setupForm.VAC2Calibrate = false;
                else if (s == "1")
                    form1.setupForm.VAC2Calibrate = true;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                bool retval = form1.setupForm.VAC2Calibrate;
                if (retval)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }

			*/
            return parser.Error1;
        }

        //Reads or sets the FM mic gain
        public string ZZYC(string s)
        {
            /*
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(70, n);

            if (s.Length == parser.nSet)
            {
                form1.FMMic = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros((int)form1.FMMic);
            }
            else
            {
                return parser.Error1;
            }
			*/
            return parser.Error1;

        }

		public string ZZZB()
		{
			/*
			if(form1.CATDisplayAvg == 1)
				form1.CATZB = "1";
			*/
			return "";
		}

		public string ZZZZ()
		{
			form1.Siolisten.SIO.Close();
			return "";
		}
		#endregion Extended CAT Methods ZZR-ZZZ


		#region Helper methods

		#region General Helpers

		private string AddLeadingZeros(int n)
		{
			string num = n.ToString();

			while(num.Length < parser.nAns)
				num = num.Insert(0,"0");
			
			return num;
		}

        private string JustSuffix(string s)
        {
            string Sfx = "";
            Sfx = s.Substring(4);
            return Sfx.Substring(0, Sfx.Length - 1);
        }


		#endregion General Helpers

        #region Repeater Methods

        private string OffsetDirection2String()
        {
            string rtn = "";

			/*
            switch (form1.CurrentFMTXMode)
            {
                case FMTXMode.Simplex:
                    rtn = "0";
                    break;
                case FMTXMode.High:
                    rtn = "1";
                    break;
                case FMTXMode.Low:
                    rtn = "2";
                    break;
                default:
                    rtn = "0";
                    break;
            }
			*/
            return rtn;
        }

        private void String2OffsetDirection(string s)
        {
			/*
            switch (s)
            {
                case "0":
                    form1.CurrentFMTXMode = FMTXMode.Simplex;
                    break;
                case "1":
                    form1.CurrentFMTXMode = FMTXMode.High;
                    break;
                case "2":
                    form1.CurrentFMTXMode = FMTXMode.Low;
                    break;
                default:
                    form1.CurrentFMTXMode = FMTXMode.Simplex;
                    break;
            }
			*/
        }

        private double String2CTCSSFreq(string s)
        {
            double freq = 00.0;
            switch (s)
            {
                case "01":
                    freq = 67.0;
                    break;
                case "02":
                    freq = 69.3;
                    break;
                case "03":
                    freq = 71.9;
                    break;
                case "04":
                    freq = 74.4;
                    break;
                case "05":
                    freq = 77.0;
                    break;
                case "06":
                    freq = 79.7;
                    break;
                case "07":
                    freq = 82.5;
                    break;
                case "08":
                    freq = 85.4;
                    break;
                case "09":
                    freq = 88.5;
                    break;
                case "10":
                    freq = 91.5;
                    break;
                case "11":
                    freq = 94.8;
                    break;
                case "12":
                    freq = 97.4;
                    break;
                case "13":
                    freq = 100.0;
                    break;
                case "14":
                    freq = 103.5;
                    break;
                case "15":
                    freq = 107.2;
                    break;
                case "16":
                    freq = 110.9;
                    break;
                case "17":
                    freq = 114.8;
                    break;
                case "18":
                    freq = 118.8;
                    break;
                case "19":
                    freq = 123.0;
                    break;
                case "20":
                    freq = 127.3;
                    break;
                case "21":
                    freq = 131.8;
                    break;
                case "22":
                    freq = 136.5;
                    break;
                case "23":
                    freq = 141.3;
                    break;
                case "24":
                    freq = 146.2;
                    break;
                case "25":
                    freq = 151.4;
                    break;
                case "26":
                    freq = 156.7;
                    break;
                case "27":
                    freq = 159.8;
                    break;
                case "28":
                    freq = 162.2;
                    break;
                case "29":
                    freq = 165.5;
                    break;
                case "30":
                    freq = 167.9;
                    break;
                case "31":
                    freq = 171.3;
                    break;
                case "32":
                    freq = 173.8;
                    break;
                case "33":
                    freq = 177.3;
                    break;
                case "34":
                    freq = 179.9;
                    break;
                case "35":
                    freq = 183.5;
                    break;
                case "36":
                    freq = 186.2;
                    break;
                case "37":
                    freq = 189.9;
                    break;
                case "38":
                    freq = 192.8;
                    break;
                case "39":
                    freq = 199.5;
                    break;
                case "40":
                    freq = 203.5;
                    break;
                case "41":
                    freq = 206.5;
                    break;
                case "42":
                    freq = 210.7;
                    break;
                case "43":
                    freq = 218.1;
                    break;
                case "44":
                    freq = 225.7;
                    break;
                case "45":
                    freq = 229.1;
                    break;
                case "46":
                    freq = 233.6;
                    break;
                case "47":
                    freq = 241.8;
                    break;
                case "48":
                    freq = 250.3;
                    break;
                case "49":
                    freq = 254.1;
                    break;
                default:
                    freq = 67.0;
                    break;
            }
            return freq;
        }

        private string CTCSSFreq2String(int freq)
        {
            string ans = "";
            switch (freq)
            {
                case 670:
                    ans = "01";
                    break;
                case 693:
                    ans = "02";
                    break;
                case 719:
                    ans = "03";
                    break;
                case 744:
                    ans = "04";
                    break;
                case 770:
                    ans = "05";
                    break;
                case 797:
                    ans = "06";
                    break;
                case 825:
                    ans = "07";
                    break;
                case 854:
                    ans = "08";
                    break;
                case 885:
                    ans = "09";
                    break;
                case 915:
                    ans = "10";
                    break;
                case 948:
                    ans = "11";
                    break;
                case 974:
                    ans = "12";
                    break;
                case 1000:
                    ans = "13";
                    break;
                case 1035:
                    ans = "14";
                    break;
                case 1072:
                    ans = "15";
                    break;
                case 1109:
                    ans = "16";
                    break;
                case 1148:
                    ans = "17";
                    break;
                case 1188:
                    ans = "18";
                    break;
                case 1230:
                    ans = "19";
                    break;
                case 1273:
                    ans = "20";
                    break;
                case 1318:
                    ans = "21";
                    break;
                case 1365:
                    ans = "22";
                    break;
                case 1413:
                    ans = "23";
                    break;
                case 1462:
                    ans = "24";
                    break;
                case 1514:
                    ans = "25";
                    break;
                case 1567:
                    ans = "26";
                    break;
                case 1598:
                    ans = "27";
                    break;
                case 1622:
                    ans = "28";
                    break;
                case 1655:
                    ans = "29";
                    break;
                case 1679:
                    ans = "30";
                    break;
                case 1713:
                    ans = "31";
                    break;
                case 1738:
                    ans = "32";
                    break;
                case 1773:
                    ans = "33";
                    break;
                case 1799:
                    ans = "34";
                    break;
                case 1835:
                    ans = "35";
                    break;
                case 1862:
                    ans = "36";
                    break;
                case 1899:
                    ans = "37";
                    break;
                case 1928:
                    ans = "38";
                    break;
                case 1995:
                    ans = "39";
                    break;
                case 2035:
                    ans = "40";
                    break;
                case 2065:
                    ans = "41";
                    break;
                case 2107:
                    ans = "42";
                    break;
                case 2181:
                    ans = "43";
                    break;
                case 2257:
                    ans = "44";
                    break;
                case 2291:
                    ans = "45";
                    break;
                case 2336:
                    ans = "46";
                    break;
                case 2418:
                    ans = "47";
                    break;
                case 2503:
                    ans = "48";
                    break;
                case  2541:
                    ans = "49";
                    break;
                default:
                    ans = "01";
                    break;
            }
            return ans;
        }
/*
        private SortableBindingList<MemoryRecord> GetMemoryList()
        {
            try
            {
                return form1.MemoryList.List;
            }
            catch
            {
                SortableBindingList<MemoryRecord> list = new SortableBindingList<MemoryRecord>();
                parser.Verbose_Error_Code = 4;
                return list;
            }
        }
*/
/*
        private MemoryRecord GetChannelRecord(string channel)
        {
            MemoryRecord rec = new MemoryRecord();
            try
            {
                SortableBindingList<MemoryRecord> list = GetMemoryList();
                int n = 0;
                for (n = 0; n < list.Count; n++)
                {
                    if (list[n].Comments.Substring(0, 4) == channel + ":")
                        rec = list[n];
                }
            }
            catch
            {
            }
            return rec;
        }
*/
/*
        private int GetIndex(string channel)
        {
            int ndx = -1;
            try
            {
                SortableBindingList<MemoryRecord> list = GetMemoryList();
                int n = 0;
                for (n = 0; n < list.Count; n++)
                {
                    if (list[n].Comments.Substring(0, 4) == channel + ":")
                        ndx = n;
                }
            }
            catch
            {
            }
            return ndx;
        }
*/
/*
        private int GetNextChannelNumber()
        {
            SortableBindingList<MemoryRecord> list = new SortableBindingList<MemoryRecord>();
            list = form1.MemoryList.List;
            int n = 0;
            int last = 0;
            for (n = 0; n < list.Count; n++)
            {
                if (list[n].Comments.Contains(":"))
                {
                    int thisN = int.Parse(list[n].Comments.Substring(0, list[n].Comments.IndexOf(":")));
                    if (thisN > last)
                        last = thisN;
                }

            }
            return last+1;
        }
*/
        #endregion Repeater Methods

        #region Antenna Methods

		/*
        private string FWCAntenna2String(FWCAnt ant)
		{
			string ans = "";
			switch(ant)
			{
				case FWCAnt.NC:
					ans = "0";
					break;
				case FWCAnt.ANT1:
                    ans = "1";
					break;
				case FWCAnt.ANT2:
					ans = "2";
					break;
				case FWCAnt.ANT3:
					ans = "3";
					break;
				case FWCAnt.RX1IN:
					ans = "4";
					break;
				case FWCAnt.RX2IN:
					ans = "5";
					break;
				case FWCAnt.RX1TAP:
					ans = "6";
					break;
				case FWCAnt.SIG_GEN:
					ans = "7";
					break;
			}
			return ans;
		}
*/

		/*
		private FWCAnt String2FWCAntenna(string ant)
		{
			FWCAnt ans = FWCAnt.ANT1;
			switch(ant)
			{
				case "0":
					ans = FWCAnt.NC;
					break;
				case "1":
					ans = FWCAnt.ANT1;
					break;
				case "2":
					ans = FWCAnt.ANT2;
					break;
				case "3":
					ans = FWCAnt.ANT3;
					break;
				case "4":
					ans = FWCAnt.RX1IN;
					break;
				case "5":
					ans = FWCAnt.RX2IN;
					break;
				case "6":
					ans = FWCAnt.RX1TAP;
					break;
				case "7":
					ans = FWCAnt.SIG_GEN;
					break;
			}
			return ans;
		}

        private string HIDAntenna2String(HIDAnt ant)
        {
            string ans = "";
            switch (ant)
            {
                case HIDAnt.PA:
                    ans = "0";
                    break;
                case HIDAnt.XVTX_COM:
                    ans = "1";
                    break;
                case HIDAnt.XVRX:
                    ans = "2";
                    break;
                case HIDAnt.BITE:
                    ans = "3";
                    break;
            }
            return ans;
        }

        private HIDAnt String2HIDAntenna(string ant)
        {
            HIDAnt ans = HIDAnt.PA;
            switch (ant)
            {
                case "0":
                    ans = HIDAnt.PA;
                    break;
                case "1":
                    ans = HIDAnt.XVTX_COM;
                    break;
                case "2":
                    ans = HIDAnt.XVRX;
                    break;
                case "3":
                    ans = HIDAnt.BITE;
                    break;
            }
            return ans;
        }


		private string AntMode2String(AntMode ant)
		{
			string ans = "0";
			switch(ant)
			{
				case AntMode.Simple:
					break;
				case AntMode.Expert:
					ans = "1";
					break;
			}
			return ans;
		}

		private AntMode String2AntMode(string amode)
		{
			AntMode ans = AntMode.Simple;
			switch(amode)
			{
				case "0":
					break;
				case "1":
					ans = AntMode.Expert;
					break;
			}
			return ans;
		}

		#endregion Antenna Methods

		#region Split Methods

		private void SetKWSplitStatus(string s)
		{
			if(s == "0")
			{
				form1.VFOSplit = false;
				lastFR = "0";
				lastFT = "0";
			}
			else if(s == "1" && !form1.VFOSplit)
			{
				form1.VFOSplit = true;
				lastFR = "0";
				lastFT = "1";
			}
			else if(s == "1" && lastFR == "1" && lastFT == "1" && form1.VFOSplit)
			{
				form1.VFOSplit = false;
				lastFR = "0";
				lastFT = "0";
			}
			Debug.WriteLine("lastFR = "+lastFR+" lastFT = "+lastFT);
		}

		private string GetP10()
		{
			return lastFT;
		}

		private string GetP12()
		{
			return lastFT;
		}

		#endregion Split Methods

		#region VFO Methods
		// Converts a vfo frequency to a proper CAT frequency string
		private string StrVFOFreq(string vfo)
		{
			double freq = 0;
			string cmd_string = "";

            if (vfo == "A")
                freq = Math.Round(form1.CATVFOA, 6);
            else if (vfo == "B")
                freq = Math.Round(form1.CATVFOB, 6);
            else if (vfo == "C")
                freq = Convert.ToDouble(form1.CATQMSValue);

			
			if((int) freq < 10)
			{
				cmd_string += "0000"+freq.ToString();
			}
			else if((int) freq < 100)
			{
				cmd_string += "000"+freq.ToString();
			}
			else if((int) freq < 1000)
			{
				cmd_string += "00"+freq.ToString();
			}
			else if((int) freq < 10000)
			{
				cmd_string += "0"+freq.ToString();
			}
			else
				cmd_string = freq.ToString();

			// Get rid of the decimal separator and pad the right side with 0's 
			// Modified 05/01/05 BT for globalization
			if(cmd_string.IndexOf(separator) > 0)
				cmd_string = cmd_string.Remove(cmd_string.IndexOf(separator),1);
			cmd_string = cmd_string.PadRight(11,'0');
			return cmd_string;
		}
		#endregion VFO Methods

		#region Filter Methods

		public string Filter2String(Filter f)
		{
			string fw = f.ToString();
			string strfilt = "";
			int retval = 0;
			switch(fw)
			{
				case "F6000":
					strfilt = "6000";
					break;
				case "F4000":
					strfilt = "4000";
					break;
				case "F2600":
					strfilt = "2600";
					break;
				case "F2100":
					strfilt = "2100";
					break;
				case "F1000":
					strfilt = "1000";
					break;
				case "F500":
					strfilt = "0500";
					break;
				case "F250":
					strfilt = "0250";
					break;
				case "F100":
					strfilt = "0100";
					break;
				case "F50":
					strfilt = "0050";
					break;
				case "F25":
					strfilt = "0025";
					break;
				case "VAR1":
					retval = Math.Abs(form1.RX1FilterHigh-form1.RX1FilterLow);
					strfilt = AddLeadingZeros(retval);
					break;
				case "VAR2":
					retval = Math.Abs(form1.RX1FilterHigh-form1.RX1FilterLow);
					strfilt = AddLeadingZeros(retval);
					break;
			}
			return strfilt;
		}

		public Filter String2Filter(string f)
		{
			Filter filter = Filter.FIRST;
			switch(f)
			{
				case "6000":
					filter = Filter.F1;
					break;
				case "4000":
					filter = Filter.F2;
					break;
				case "2600":
					filter = Filter.F3;
					break;
				case "2100":
					filter = Filter.F4;
					break;
				case "1000":
					filter = Filter.F5;
					break;
				case "0500":
					filter = Filter.F6;
					break;
				case "0250":
					filter = Filter.F7;
					break;
				case "0100":
					filter = Filter.F8;
					break;
				case "0050":
					filter = Filter.F9;
					break;
				case "0025":
					filter = Filter.F10;
					break;
				case "VAR1":
					filter = Filter.VAR1;
					break;
				case "VAR2":
					filter = Filter.VAR2;
					break;
			}
			return filter;
		}

		// set variable filter 1 to indicate center and width 
		// 
		// if either center or width is zero, current value of center or width is 
		// contained 
		// fixme ... what should this thing do for am, fm, dsb ... ignore width? 
		private void SetFilterCenterAndWidth(int center, int width) 
		{ 
			int new_lo; 
			int new_hi; 

			if  ( center == 0 || width == 0 )  // need to get current values 
			{ 
				return; // not implemented yet 
			} 
			else 
			{ 
				// Debug.WriteLine("center: " + center  + " width: " + width); 
				new_lo = center - (width/2); 
				new_hi = center + (width/2); 
				if ( new_lo  < 0 ) new_lo = 0; 				
			} 						
			
			// new_lo and new_hi calculated assuming a USB mode .. do the right thing 
			// for lsb and other modes 
			// fixme -- needs more thinking 
			switch ( form1.RX1DSPMode ) 
			{ 
				case DSPMode.LSB: 
					int scratch = new_hi; 
					new_hi = -new_lo; 
					new_lo = -scratch; 
					break; 

				case DSPMode.AM: 
				case DSPMode.SAM: 
					new_lo = -new_hi; 
					break; 
			} 						

			 
			// System.Form1.WriteLine("zzsf: " + new_lo + " " + new_hi); 
			form1.SelectRX1VarFilter();
			form1.UpdateRX1Filters(new_lo, new_hi); 	

			return; 
		} 

		// Converts interger filter frequency into Kenwood SL/SH codes
		private string Frequency2Code(int f, string n)
		{
			f = Math.Abs(f);
			string code = "";
			switch(form1.RX1DSPMode)
			{
				case DSPMode.CWL:
				case DSPMode.CWU:
				case DSPMode.LSB:
				case DSPMode.USB:
				switch(n)
				{
					case "SH":
						if(f >= 0 && f <= 1500)
							code = "00";
						else if(f > 1500 && f <= 1700)
							code = "01";
						else if(f > 1700 && f <= 1900)
							code = "02";
						else if(f > 1900 && f <= 2100)
							code = "03";
						else if(f > 2100 && f <= 2300)
							code = "04";
						else if(f > 2300 && f <= 2500)
							code = "05";
						else if(f > 2500 && f <= 2700)
							code = "06";
						else if(f > 2700 && f <= 2900)
							code = "07";
						else if(f > 2900 && f <= 3200)
							code = "08";
						else if(f > 3200 && f <= 3700)
							code = "09";
						else if(f > 3700 && f <= 4500)
							code = "10";
						else if(f > 4500)
							code = "11";
						break;
					case"SL":
						if(f >= 0 && f <= 25)
							code = "00";
						else if(f > 25 && f <= 75)
							code = "01";
						else if(f > 75 && f <= 150)
							code = "02";
						else if(f > 150 && f <= 250)
							code = "03";
						else if(f > 250 && f <= 350)
							code = "04";
						else if(f > 350 && f <= 450)
							code = "05";
						else if(f > 450 && f <= 550)
							code = "06";
						else if(f > 550 && f <= 650)
							code = "07";
						else if(f > 650 && f <= 750)
							code = "08";
						else if(f > 750 && f <= 850)
							code = "09";
						else if(f > 850 && f <= 950)
							code = "10";
						else if(f > 950)
							code = "11";
						break;
				}
				break;
				case DSPMode.AM:
				case DSPMode.DRM:
				case DSPMode.DSB:
				case DSPMode.FM:
				case DSPMode.SAM:
				switch(n)
				{
					case "SH":
						if(f >= 0 && f <= 2750)
							code = "00";
						else if(f > 2750 && f <= 3500)
							code = "01";
						else if(f > 3500 && f <= 4500)
							code = "02";
						else if(f > 4500)
							code = "03";
						break;
					case "SL":
						if(f >= 0 && f <= 50)
							code = "00";
						else if(f > 50 && f <= 150)
							code = "01";
						else if(f > 150 && f <= 350)
							code = "02";
						else if(f > 350)
							code = "03";
						break;
				}
				break;
			}
			return code;
		}

		// Converts a frequency code pair to frequency in hz according to
		// the Kenwood TS-2000 spec.  Receives code and calling methd as parameters
		private int Code2Frequency(string c, string n)
		{
			int freq = 0;
			string mode = "SSB";
			int fgroup = 0;

			// Get the current form1 mode
			switch(form1.RX1DSPMode)
			{
				case DSPMode.LSB:
				case DSPMode.USB:
					break;
				case DSPMode.AM:
				case DSPMode.DSB:
				case DSPMode.DRM:
				case DSPMode.FM:
				case DSPMode.SAM:
					mode = "DSB";
					break;
			}
			// Get the frequency group(SSB/SL, SSB/SH, DSB/SL, and DSB/SH)
			switch(n)
			{
				case "SL":
					if(mode == "SSB")
						fgroup = 1;
					else
						fgroup = 3;
					break;
				case "SH":
					if(mode == "SSB")
						fgroup = 2;
					else
						fgroup = 4;
					break;
			}
			// return the frequency for the current DSP mode and calling method
			switch(fgroup)
			{
				case 1:		//SL SSB
				switch(c)
					{
					case "00":
						freq = 0;
						break;
					case "01":
						freq = 50;
						break;
					case "02":
						freq = 100;
						break;
					case "03":
						freq = 200;
						break;
					case "04":
						freq = 300;
						break;
					case "05":
						freq = 400;
						break;
					case "06":
						freq = 500;
						break;
					case "07":
						freq = 600;
						break;
					case "08":
						freq = 700;
						break;
					case "09":
						freq = 800;
						break;
					case "10":
						freq = 900;
						break;
					case "11":
						freq = 1000;
						break;
					}
				break;
				case 2:		//SH SSB
					switch(c)
					{
					case "00":
						freq = 1400;
						break;
					case "01":
						freq = 1600;
						break;
					case "02":
						freq = 1800;
						break;
					case "03":
						freq = 2000;
						break;
					case "04":
						freq = 2200;
						break;
					case "05":
						freq = 2400;
						break;
					case "06":
						freq = 2600;
						break;
					case "07":
						freq = 2800;
						break;
					case "08":
						freq = 3000;
						break;
					case "09":
						freq = 3400;
						break;
					case "10":
						freq = 4000;
						break;
					case "11":
						freq = 5000;
						break;
					}
				break;
				case 3:		//SL DSB
					switch(c)
					{
					case "00":
						freq = 0;
						break;
					case "01":
						freq = 100;
						break;
					case "02":
						freq = 200;
						break;
					case "03":
						freq = 500;
						break;
					}
				break;
				case 4:		//SH DSB
					switch(c)
					{
					case "00":
						freq = 2500;
						break;
					case "01":
						freq = 3000;
						break;
					case "02":
						freq = 4000;
						break;
					case "03":
						freq = 5000;
						break;
					}
				break;
			}
			return freq;
			#region old code

//			int freq = 0;
//			switch(form1.RX1DSPMode)
//			{
//				case DSPMode.CWL:
//				case DSPMode.CWU:
//				case DSPMode.LSB:
//				case DSPMode.USB:
//				{
//					switch(c)	//c = filter code, n = SH or SL
//					{
//						case "00":
//							if(n == "SL")
//								freq = 10;
//							else
//								freq = 1400;
//							break;
//						case "01":
//							if(n == "SL")
//								freq = 50;
//							else
//								freq = 1600;
//							break;
//						case "02":
//							if(n == "SL")
//								freq = 100;
//							else
//								freq = 1800;
//							break;
//						case "03":
//							if(n == "SL")
//								freq = 200;
//							else
//								freq = 2000;
//							break;
//						case "04":
//							if(n == "SL")
//								freq = 300;
//							else
//								freq = 2200;
//							break;
//						case "05":
//							if(n == "SL")
//								freq = 400;
//							else
//								freq = 2400;
//							break;
//						case "06":
//							if(n == "SL")
//								freq = 500;
//							else
//								freq = 2600;
//							break;
//						case "07":
//							if(n == "SL")
//								freq = 600;
//							else
//								freq = 2800;
//							break;
//						case "08":
//							if(n == "SL")
//								freq = 700;
//							else
//								freq = 3000;
//							break;
//						case "09":
//							if(n == "SL")
//								freq = 800;
//							else
//								freq = 3400;
//							break;
//						case "10":
//							if(n == "SL")
//								freq = 900;
//							else
//								freq = 4000;
//							break;
//						case "11":
//							if(n == "SL")
//								freq = 1000;
//							else
//								freq = 5000;
//							break;
//						default:
//							break;
//					}
//					break;
//				}
//				case DSPMode.AM:
//				case DSPMode.DRM:
//				case DSPMode.DSB:
//				case DSPMode.FMN:
//				case DSPMode.SAM:
//				{
//					switch(c)
//					{
//						case "00":
//							if(n == "SL")
//								freq = 10;
//							else
//								freq = 2500;
//							break;
//						case "01":
//							if(n == "SL")
//								freq = 100;
//							else
//								freq = 3000;
//							break;
//						case "02":
//							if(n == "SL")
//								freq = 200;
//							else
//								freq = 4000;
//							break;
//						case "03":
//							if(n == "SL")
//								freq = 500;
//							else
//								freq = 5000;
//							break;
//					}
//				}
//				break;
//			}
//			return freq;
			#endregion old code
		}

		private void SetFilter(string c, string n)
		{
			// c = code, n = SH or SL
			form1.RX1Filter = Filter.VAR1;
			int freq = 0;
			int offset = 0;
			string code;

			switch(form1.RX1DSPMode)
			{
				case DSPMode.USB:
				case DSPMode.CWU:
					freq = Code2Frequency(c, n);
					if(n == "SH")
						form1.RX1FilterHigh = freq;	//split the bandwidth at the center frequency
					else
						form1.RX1FilterLow = freq;
					break;
				case DSPMode.LSB:
				case DSPMode.CWL:
					if(n == "SH")
					{
						freq = Code2Frequency(c, "SH");	// get the upper limit from the lower value set
						form1.RX1FilterLow = -freq;	// since we need the more positive value
					}										// closest to the center freq in lsb modes
					else
					{
						freq = Code2Frequency(c, "SL");	// do the reverse here, the less positive value
						form1.RX1FilterHigh = -freq; // is away from the center freq
					}
					break;
				case DSPMode.AM:
				case DSPMode.DRM:
				case DSPMode.DSB:
				case DSPMode.FM:
				case DSPMode.SAM:
					if(n == "SH")
					{
						// Set the bandwith equally across the center freq
						freq = Code2Frequency(c, "SH");	
						form1.RX1FilterHigh = freq/2;
						form1.RX1FilterLow = -freq/2;
					}
					else
					{
						// reset the frequency to the nominal value (in case it's been changed)
						freq = form1.RX1FilterHigh*2;	
						code = Frequency2Code(freq, "SH");
						freq = Code2Frequency(code, "SH");
						form1.RX1FilterHigh = freq/2;
						form1.RX1FilterLow = -freq/2;
						// subtract the SL value from the lower half of the bandwidth
						offset = Code2Frequency(c, "SL");
						form1.RX1FilterLow = form1.RX1FilterLow + offset;			
					}
					break;
			}
		}

		#endregion Filter Methods

		#region Mode Methods

		public void String2Mode(string pIndex)
		{
			string s = pIndex;

			switch(s)
				{
				case "00":								
					form1.RX1DSPMode = DSPMode.LSB;
					break;
				case "01":
					form1.RX1DSPMode = DSPMode.USB;
					break;
				case "02":
					form1.RX1DSPMode = DSPMode.DSB;
					break;
				case "03":
					form1.RX1DSPMode = DSPMode.CWL;
					break;
				case "04":
					form1.RX1DSPMode = DSPMode.CWU;
					break;
				case "05":
					form1.RX1DSPMode = DSPMode.FM;
					break;
				case "06":
					form1.RX1DSPMode = DSPMode.AM;
					break;
				case "07":
					form1.RX1DSPMode = DSPMode.DIGU;
					break;
				case "08":
					form1.RX1DSPMode = DSPMode.SPEC;
					break;
				case "09":
					form1.RX1DSPMode = DSPMode.DIGL;
					break;
				case "10":
					form1.RX1DSPMode = DSPMode.SAM;
					break;
				case "11":
					form1.RX1DSPMode = DSPMode.DRM;
					break;
				}
		}

		public string Mode2String(DSPMode pMode)
		{
			DSPMode s = pMode;
			string retval = "";

			switch(s)
				{
					case DSPMode.LSB:
						retval = "00";  
						break;
					case DSPMode.USB:
						retval = "01";	
						break;
					case DSPMode.DSB:
						retval = "02";	
						break;
					case DSPMode.CWL:
						retval = "03";	
						break;
					case DSPMode.CWU:
						retval = "04";	
						break;
					case DSPMode.FM:
						retval = "05";	
						break;
					case DSPMode.AM:
						retval = "06";	
						break;
					case DSPMode.DIGU:
						retval = "07";	
						break;
					case DSPMode.SPEC:
						retval = "08";	
						break;
					case DSPMode.DIGL:
						retval = "09";	
						break;
					case DSPMode.SAM:
						retval = "10";	
						break;
					case DSPMode.DRM:
						retval = "11";	
						break;
					default:
						retval = parser.Error1;
						break;
				}

			return retval;
		}

		// converts Kenwood single digit mode code to SDR mode
		public void KString2Mode(string pIndex)
		{
			string s = pIndex;

			switch(s)
			{
				case "1":
                    if (form1.setupForm.DigUIsUSB)
                        form1.RX1DSPMode = DSPMode.DIGL;
                    else
                        form1.RX1DSPMode = DSPMode.LSB;
					break;
				case "2":
                    if (form1.setupForm.DigUIsUSB)
                        form1.RX1DSPMode = DSPMode.DIGU;
                    else
    					form1.RX1DSPMode = DSPMode.USB;
					break;
				case "3":
					form1.RX1DSPMode = DSPMode.CWU;
					break;
				case "4":
					form1.RX1DSPMode = DSPMode.FM;
					break;
				case "5":
					form1.RX1DSPMode = DSPMode.AM;
					break;
				case "6":
					form1.RX1DSPMode = DSPMode.DIGL;
					break;
				case "7":
					form1.RX1DSPMode = DSPMode.CWL;
					break;
				case "9":
					form1.RX1DSPMode = DSPMode.DIGU;
					break;
				default:
					form1.RX1DSPMode = DSPMode.USB;
					break;
			}
		}

		// converts SDR mode to Kenwood single digit mode code
		public string Mode2KString(DSPMode pMode)
		{
			DSPMode s = pMode;
			string retval = "";

			switch(s)
			{
				case DSPMode.LSB:
   					retval = "1";  
					break;
				case DSPMode.USB:
   					retval = "2";	
					break;
				case DSPMode.CWU:
					retval = "3";	
					break;
				case DSPMode.FM:
					retval = "4";	
					break;
				case DSPMode.AM:
//				case DSPMode.SAM:		//possible fix for SAM problem
					retval = "5";	
					break;
				case DSPMode.DIGL:
					if(form1.setupForm.DigUIsUSB)
						retval = "1";
					else
						retval = "6";	
					break;
				case DSPMode.CWL:
					retval = "7";	
					break;
				case DSPMode.DIGU:
					if(form1.setupForm.DigUIsUSB)
						retval = "2";
					else
						retval = "9";
					break;
				default:
					retval = parser.Error1;
					break;
			}

			return retval;
		}

		#endregion Mode Methods

		#region Band Methods

		private void MakeBandList()
		//Construct an array of the KMSWITCH.Band enums.
		//If the 2m xverter is present, set the last index to B2M
		//otherwise, set it to B6M.
		{
			int ndx = 0;
			BandList = new Band[(int)Band.LAST + 2];

            foreach (Band b in Enum.GetValues(typeof(Band)))
			{
				BandList.SetValue(b, ndx);
				ndx++;
			}
			if(form1.XVTRPresent)
				LastBandIndex = Array.IndexOf(BandList,Band.B2M);
			else
				LastBandIndex = Array.IndexOf(BandList,Band.B6M);
		}

		private void SetBandGroup(int band)
		{
			int oldval = parser.nSet;
			parser.nSet = 1;
			if(band == 0)
				ZZBG("0"); //HF
			else
				ZZBG("1"); // VHF

			parser.nSet = oldval;
		}

		private string GetBand(string b)
		{
			if(b.Length == parser.nSet)
			{
				if(b.StartsWith("V") || b.StartsWith("v"))
					SetBandGroup(1);
				else 
					SetBandGroup(0);
			}

			if(b.Length == parser.nSet)
			{
				form1.SetCATBand(String2Band(b));
				return "";
			}
			else if(b.Length == parser.nGet)
			{
				return Band2String(form1.RX1Band);
			}
			else
			{
				return parser.Error1;
			}


		}

		private void BandUp()
		{
			Band nextband;
			Band current = form1.RX1Band;
			int currndx = Array.IndexOf(BandList,current);

			if(currndx == LastBandIndex) nextband = BandList[0];
			else	nextband = BandList[currndx+1];

            form1.SetCATBand(nextband);
		}

		private void BandDown()
		{
			Band nextband;
			Band current = form1.RX1Band;
			int currndx = Array.IndexOf(BandList,current);

			if(currndx > 0)	nextband = BandList[currndx-1];
			else	nextband = BandList[LastBandIndex];

			form1.SetCATBand(nextband);

		}

		private string Band2String(Band pBand)
		{
			Band band = pBand;
			string retval;

			switch(band)
			{
				case Band.GEN:
					retval = "888";
					break;
				case Band.B160M:
					retval = "160";
					break;
				case Band.B60M:
					retval = "060";
					break;
				case Band.B80M:
					retval = "080";
					break;
				case Band.B40M:
					retval = "040";
					break;
				case Band.B30M:
					retval = "030";
					break;
				case Band.B20M:
					retval = "020";
					break;
				case Band.B17M:
					retval = "017";
					break;
				case Band.B15M:
					retval = "015";
					break;
				case Band.B12M:
					retval = "012";
					break;
				case Band.B10M:
					retval = "010";
					break;
				case Band.B6M:
					retval = "006";
					break;
				case Band.B2M:
					retval = "002";
					break;
				case Band.WWV:
					retval = "999";
					break;
				case Band.VHF0:
					retval = "V00";
					break;
				case Band.VHF1:
					retval = "V01";
					break;
				case Band.VHF2:
					retval = "V02";
					break;
				case Band.VHF3:
					retval = "V03";
					break;
				case Band.VHF4:
					retval = "V04";
					break;
				case Band.VHF5:
					retval = "V05";
					break;
				case Band.VHF6:
					retval = "V06";
					break;
				case Band.VHF7:
					retval = "V07";
					break;
				case Band.VHF8:
					retval = "V08";
					break;
				case Band.VHF9:
					retval = "V09";
					break;
				case Band.VHF10:
					retval = "V10";
					break;
				case Band.VHF11:
					retval = "V11";
					break;
				case Band.VHF12:
					retval = "V12";
					break;
				case Band.VHF13:
					retval = "V13";
					break;
				default:
					retval = "888";
					break;
			}
			return retval;
		}

		private Band String2Band(string pBand)
		{
			string band = pBand.ToUpper();;
			Band retval;

			switch(band)
			{
				case "888":
					retval = Band.GEN;
					break;
				case "160":
					retval = Band.B160M;
					break;
				case "060":
					retval = Band.B60M;
					break;
				case "080":
					retval = Band.B80M;
					break;
				case "040":
					retval = Band.B40M;
					break;
				case "030":
					retval = Band.B30M;
					break;
				case "020":
					retval = Band.B20M;
					break;
				case "017":
					retval = Band.B17M;
					break;
				case "015":
					retval = Band.B15M;
					break;
				case "012":
					retval = Band.B12M;
					break;
				case "010":
					retval = Band.B10M;
					break;
				case "006":
					retval = Band.B6M;
					break;
				case "002":
					retval = Band.B2M;
					break;
				case "999":
					retval = Band.WWV;
					break;
				case "V00":
					retval = Band.VHF0;
					break;
				case "V01":
					retval = Band.VHF1;
					break;
				case "V02":
					retval = Band.VHF2;
					break;
				case "V03":
					retval = Band.VHF3;
					break;
				case "V04":
					retval = Band.VHF4;
					break;
				case "V05":
					retval = Band.VHF5;
					break;
				case "V06":
					retval = Band.VHF6;
					break;
				case "V07":
					retval = Band.VHF7;
					break;
				case "V08":
					retval = Band.VHF8;
					break;
				case "V09":
					retval = Band.VHF9;
					break;
				case "V10":
					retval = Band.VHF10;
					break;
				case "V11":
					retval = Band.VHF11;
					break;
				case "V12":
					retval = Band.VHF12;
					break;
				case "V13":
					retval = Band.VHF13;
					break;
				default:
					retval = Band.GEN;
					break;
			}
			return retval;
		}

		#endregion Band Methods

		#region Step Methods

        private double Step2Freq(int step)
        {
            double freq = 0.0;
            switch(step)
            {
                case 0:
			        freq  =  0.000001;
                    break;
                case 1:
                    freq  =  0.000010;
                    break;
                case 2:
                    freq  =  0.000050;
                    break;
                case 3:
                    freq  =  0.000100;
                    break;
                case 4:
                    freq  =  0.000250;
                    break;
                case 5:
                    freq  =  0.000500;
                    break;
                case 6:
                    freq  =  0.001000;
                    break;
                case 7:
                    freq  =  0.005000;
                    break;
                case 8:
                    freq  =  0.009000;
                    break;
                case 9:
                    freq  =  0.010000;
                    break;
                case 10:
                    freq = 0.100000;
                    break;
                case 11:
                    freq =  0.250000;
                    break;
                case 12:
                    freq =  0.500000;
                    break;
                case 13:
                    freq =  1.000000;
                    break;
                case 14:
                    freq = 10.000000;
                    break;
            }
            return freq;
        }

		private string Step2String(int pSize)
		{
			// Modified 2/25/07 to accomodate changes to form1 where odd step sizes added.  BT
			string stepval = "";
			int step = pSize;
			switch(step)
			{
				case 0:
					stepval = "0000";	//10e0 = 1 hz
					break;
				case 1:
					stepval = "0001";	//10e1 = 10 hz
					break;
				case 2:
					stepval = "1000";	//special default for 50 hz
					break;
				case 3:
					stepval = "0010";	//10e2 = 100 hz
					break;
				case 4:
					stepval = "1001";	//special default for 250 hz
					break;
				case 5:
					stepval = "1010";	//10e3 = 1 kHz default for 500 hz
					break;
				case 6:
					stepval = "0011";	//10e3 = 1 kHz
					break;
				case 7:
					stepval = "1011";	//special default for 5 kHz
					break;
				case 8:
					stepval = "1100";	//special default for 9 kHz
					break;
				case 9:
					stepval = "0100";	//10e4 = 10 khZ
					break;
				case 10:
					stepval = "0101";	//10e5 = 100 kHz
					break;
                case 11:
                    stepval = "1101";   //special default for 250 kHz
                    break;
                case 12:
                    stepval = "1110";   //special default for 500 kHz
                    break;
				case 13:
					stepval = "0110";	//10e6 = 1 mHz
					break;
				case 14:
					stepval = "0111";	//10e7 = 10 mHz
					break;
			}
			return stepval;
		}

		#endregion Step Methods

		#region Meter Methods

		private void String2RXMeter(int m)
		{
			form1.CurrentMeterRXMode = (MeterRXMode) m;
		}

		private string RXMeter2String()
		{
			return ((int) form1.CurrentMeterRXMode).ToString();
		}

		private void String2TXMeter(int m)
		{
			form1.CurrentMeterTXMode = (MeterTXMode) m;
		}

		private string TXMeter2String()
		{
			return ((int) form1.CurrentMeterTXMode).ToString();
		}

		*/
		#endregion Meter Methods

		#region Rig ID Methods

		private string CAT2RigType()
		{
			return "";
		}

		private string RigType2CAT()
		{
			return "";
		}

		#endregion Rig ID Methods

		#region DSP Filter Size Methods

		private string Width2Index(int txt)
		{
			string ans = "";
			switch(txt)
			{
				case 256:
					ans = "0";
					break;
				case 512:
					ans = "1";
					break;
				case 1024:
					ans = "2";
					break;
				case 2048:
					ans = "3";
					break;
				case 4096:
					ans = "4";
					break;
				default:
					ans = "0";
					break;
			}
			return ans;
		}

		private int Index2Width(string ndx)
		{
			int ans;
			switch(ndx)
			{
				case "0":
					ans = 256;
					break;
				case "1":
					ans = 512;
					break;
				case "2":
					ans = 1024;
					break;
				case "3":
					ans = 2048;
					break;
				case "4":
					ans = 4096;
					break;
				default:
					ans = 256;
					break;
			}
			return ans;
		}

		#endregion DSP Filter Size Methods

		#endregion Helper methods
	}	
}

