﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;
using System.Text.RegularExpressions;
using System.Threading;
using Finisar;
using ZedGraph;
using TotalPhase;


namespace myProject2_7001
{
    public partial class Form1 : Form
    {
        public Ke2400 ke2400Ctrl1;
        public Ke7001Ctrl ke7001Ctrl1 = new Ke7001Ctrl();
        

        #region [INIT]

        #region [Parameters]

        string appVersion = String.Format("({0})",
        typeof(Form1).Assembly.GetName().Version);
        public Config configForm = new Config();

        public string[] testConfigs = new string[200];
        public string[] testResults = new string[200];
        public string[] testspecMin = new string[200];
        public string[] testspecMax = new string[200];
        public int noOfConfigs;
        public string dataOutputFile = "";

        # region [appSettings]

        public string lotNumber = "";
        public string serialNumber = "";
        public string operatorName = "";

        public string configFile = "";
        public string dataOutputPath = "";
        public string testSpec = "";


        private byte ke2400_gpib
        {
            get { return (byte)configForm.Ke2400GPIB; }
            set { configForm.Ke2400GPIB = (byte)value; }
        }
        private byte ke7001_gpib
        {
            get { return (byte)configForm.Ke7001_GPIB.Value; }
            set { configForm.Ke7001GPIB = (byte)value; }
        }

        public TestPhase testPhase { get; set; }

        #endregion [appSettings]

        private static Ke7001 Ke7001_1;
        private Ke7001Settings Ke7001Settings_1;

        System.IO.StreamWriter CvsWriter = null;
        System.IO.StreamReader CvsReader = null;
        Char[] SplitChars = new Char[] { ',', '.', ':' };

        #endregion Parameters

        public Form1()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            btn_StartTest.Enabled = true;
            string appTitle = this.Text + appVersion;
            this.Text = appTitle;
            toolStripStatusLabel1.Text = "Initializing";
            addLog("Initializing ...");

            Ke7001_1 = new Ke7001();
            Ke7001Settings_1 = new Ke7001Settings();
            Ke7001_1.Settings = Ke7001Settings_1;

            ReadDefaultSettings();

            DoConfigForm();

            WriteDefaultSettings();

            toolStripStatusLabel1.Text = "Initialized";

            addLog("Initialized with following paramters:");
            addLog("Lot Number: " + lotNumber);
            addLog("Serial Number: " + serialNumber);
            addLog("Operator Name: " + operatorName);
            addLog("configFile: " + configFile);
            addLog("dataOutputPath: " + dataOutputPath);
            addLog("Test Spec file: " + testSpec);
            addLog("Ke2400 GPIB: " + ke2400_gpib.ToString());
            addLog("Ke7001 GPIB: " + ke7001_gpib.ToString()); 
            addLog("Test Phase: " + TestPhase.ToString());
        }

        #endregion [INIT]

        #region [EventsHandlers]

        private void btn_clearLog_Click(object sender, EventArgs e)
        {
            clearLog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            configForm.Show();
        }

        private void ke2400oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 aaa = new Form2();
            aaa.Show();
        }

        private void keToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ke7001Ctrl ccc = new Ke7001Ctrl();
            ccc.Show();
        }

        private void btn_StartTest_Click(object sender, EventArgs e)
        {
            resistanceTest(1, 1);
            resistanceTest(1, 2);
            resistanceTest(1, 4);
            resistanceTest(1, 6);
            resistanceTest(1, 7);
            resistanceTest(1, 10);
            resistanceTest(1, 11);
            resistanceTest(1, 21);
            resistanceTest(1, 2);
            resistanceTest(1, 4);
            resistanceTest(1, 22);
            resistanceTest(1, 10);
            resistanceTest(1, 23);
            resistanceTest(1, 24);

        }

        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            addLog("End of Execution.");
            MessageBox.Show("Execution ended. Click to proceed.");
            Application.Exit();
        }

        #endregion [EventsHandlers]

        # region [Utilities]

        private void ReadDefaultSettings()
        {

            lotNumber = Properties.Settings.Default.lotNumber;
            serialNumber = Properties.Settings.Default.serialNumber;
            operatorName = Properties.Settings.Default.operatorName;

            Label_lotNumber.Text = lotNumber;
            Label_searialNumber.Text = serialNumber;
            Label_operatorName.Text = operatorName;
            // how to put the value of settings to our configForm?
            configFile = Properties.Settings.Default.configFile;
            dataOutputPath = Properties.Settings.Default.dataOutputPath;
            testSpec = Properties.Settings.Default.testSpec;

            //Label_resultFolder.Text = dataOutputPath;
            //Label_testSpec.Text = testSpec;

            ke2400_gpib = (byte)Properties.Settings.Default.ke2400_gpib;
            ke7001_gpib = (byte)Properties.Settings.Default.ke7001_gpib;


            //TestPhase = (TestPhase)Enum.Parse(
            //  typeof(TestPhase), Properties.Settings.Default.testPhase);
             TestPhase value;
             if (!Enum.TryParse(Properties.Settings.Default.testPhase.ToString(), out value))
            {
                Properties.Settings.Default.testPhase = "None";
                Properties.Settings.Default.Save();
            }
            
        }

        private void WriteDefaultSettings()
        {
            Properties.Settings.Default.lotNumber = lotNumber;
            Properties.Settings.Default.serialNumber = serialNumber;
            Properties.Settings.Default.operatorName = operatorName;

            Properties.Settings.Default.configFile = configFile;
            Properties.Settings.Default.dataOutputPath = dataOutputPath;
            Properties.Settings.Default.testSpec = testSpec;

            Properties.Settings.Default.ke2400_gpib = ke2400_gpib;
            Properties.Settings.Default.ke7001_gpib = ke7001_gpib;


            Properties.Settings.Default.testPhase = TestPhase.ToString();

            Properties.Settings.Default.Save();
        }

        private void DoConfigForm()
        {

            WriteSettingsToConfigForm();

            DialogResult result = configForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                ReadSettingsFromConfigForm();
                btn_StartTest.Enabled = true;
            }

        }

        private void WriteSettingsToConfigForm()
        {
            configForm.lotNumber = lotNumber;
            configForm.serialNumber = serialNumber;
            configForm.operatorName = operatorName;

            configForm.configFile = configFile;
            configForm.outputdirectory = dataOutputPath;
            configForm.testSpec = testSpec;

            configForm.Ke2400GPIB = ke2400_gpib;
            configForm.Ke7001GPIB = ke7001_gpib;

            configForm.testPhase = TestPhase;

            configForm.configReset();
        }

        private void ReadSettingsFromConfigForm()
        {
            lotNumber = configForm.lotNumber;
            serialNumber = configForm.serialNumber;
            operatorName = configForm.operatorName;

            Label_lotNumber.Text = lotNumber;
            Label_searialNumber.Text = serialNumber;
            Label_operatorName.Text = operatorName;

            configFile = configForm.configFile;
            dataOutputPath = configForm.outputdirectory;
            testSpec = configForm.testSpec;

            //Label_resultFolder.Text = dataOutputPath;
            //Label_testSpec.Text = testSpec;


            ke2400_gpib = configForm.Ke2400GPIB;
            ke7001_gpib = configForm.Ke7001GPIB;


            TestPhase = configForm.testPhase;
            //Label_testPhase.Text = testPhase.ToString();
        }


        private void StripStatusDisplay(string strData)
        {

            toolStripStatusLabel1.Text = strData;
        }

        public void addLog(string log)
        {
            richTextBox_Log.AppendText(DateTime.Now.ToString() + ": " + log + "\r\n");
            richTextBox_Log.Focus();//?
            richTextBox_Log.Refresh();

        }
        private void clearLog()
        {
            richTextBox_Log.Clear();
        }

        #endregion [Utilities]

        #region [TestApplication]

         private void resistanceACRTest(string file, string spec)
        {

            dataOutputFile = dataOutputPath + "\\ResistanceTest_" + "_" + configForm.lotNumber + "_" + configForm.testPhase + ".csv";
            string FailOutputFile = dataOutputPath + "\\ResistanceTest_" + "_" + configForm.lotNumber + "_" + configForm.testPhase + "_Fail.csv"; ;
            if (File.Exists(dataOutputFile) == false)
            {
                string[] field1 = { "" };
                File.WriteAllLines(dataOutputFile, field1);
                //string field = "Resule,Serialnumber,Operator,test pase,test time,";
                //saveTestResults(dataOutputFile, field);
                //File.Create(FailOutputFile);
                string[] field = { "Serialnumber,Operator,test pase,test time,Pin-Pin,test value,Spec Min,Spec Max" };
                File.WriteAllLines(FailOutputFile, field);
                //saveTestResults(dataOutputFile, field);
            }
            addLog("dataOutputFile: " + dataOutputFile);
            addLog("Loading config file ... ");
            loadConfigFile(file);
            addLog("Loading DONE.");
            addLog("Loading spec file ... ");
            loadSpecFile(spec, configForm.testPhase.ToString());
            addLog("Loading DONE.");
            addLog("Start testing ...");
            addLog("Initializing Ke2400, Ke7001 ... ");



            TestInitialization();


            ke7001Ctrl1.Ke7001_Init();
            addLog(" Looping ... ");
            ResultTxt.Text = "Testing..........";
            Application.DoEvents();
            bool Result = true;
            DateTime date = DateTime.Now;
            string ResultString = "";
            string ResultFieldString = "," + configForm.serialNumber + "," + configForm.operatorName + "," + configForm.testPhase + "," + date.ToString();
            string CloumnString = "Resule,Serialnumber,Operator,test pase,test time";
            string FailFieldString = configForm.serialNumber + "," + configForm.operatorName + "," + configForm.testPhase + "," + date.ToString();
            string FailString = "";
            int j = 0;
            for (int i = 0; i < noOfConfigs; i++)
            {
                string[] testConfig = testConfigs[i].Split(SplitChars);
                char c = testConfig[0][0];
                if (Char.IsNumber(c) == false)
                {
                    addLog("Line " + i.ToString() + " not a test Config.");
                    addLog(testConfigs[i]);
                    testResults[i] = testConfigs[i];
                    continue;
                }

                int testConf = Convert.ToInt32(testConfig[0]);
                int testType = Convert.ToInt32(testConfig[1]);
                int testSlot = Convert.ToInt32(testConfig[4]);
                int testChannel = Convert.ToInt32(testConfig[5]);
                string customTest = testConfig[6];
                addLog("Test Channel: " + testConf.ToString() + " Type: " + testType.ToString() + " Card Slot: " + testSlot.ToString() + " Card Channel: " + testChannel.ToString());
                string testResult = doTest(testType, testSlot, testChannel, customTest);
                if ((Convert.ToDouble(testResult) < Convert.ToDouble(testspecMin[j])) || (Convert.ToDouble(testResult) > Convert.ToDouble(testspecMax[j])))
                {
                    Result = false;
                    FailString = FailFieldString + "," + testConfig[2] + "_" + testConfig[3] + "," + testResult + "," + testspecMin[j] + "," + testspecMax[j];
                    saveTestResults(FailOutputFile, FailString);
                    j++;
                }
                else
                {
                    j++;
                }
                CloumnString = CloumnString + "," + testConfig[2] + "_" + testConfig[3];
                ResultString = ResultString + "," + testResult;
                testResults[i] = testConfigs[i] + testResult;
            }

            addLog(" Testing DONE. ");
            addLog("Saving test result to file: " + dataOutputFile);
            if (Result == true)
            {
                ResultString = "PASS" + ResultFieldString + ResultString;
                ResultTxt.Text = "Test finish. Result: PASS";
            }
            else
            {
                ResultString = "Fail" + ResultFieldString + ResultString;
                ResultTxt.Text = "Test finish. Result: FAIL";
            }
            saveTestResults(dataOutputFile, ResultString, CloumnString);
            addLog("Saving ... DONE.");
        }

        private string doTest(int testType, int cardSlot, int channelNo, string customTest)
        {
            string retString = "";
            //testType = 1;
            switch (testType)
            {
                case 0:   // No test.
                    retString = "NoTest";
                    break;
                case 1:  // Resistance Test
                    retString = resistanceTest(cardSlot, channelNo);
                    break;
                case 2:  // ACRTest.
                    retString = "DirectShort";
                    break;

            }

            return (retString);
        }

        private string resistanceTest(int cardSlot, int channelNo)
        {
            addLog("Entering resistanceTest ... ");
            string retString = "Init";
            double  v /*ohms*/;
            ke2400Ctrl1 = new Ke2400((byte)configForm.Ke2400GPIB);
            /*
             * 
             * trun on channel (slot, channel)
             
             * turn on 2400
             * set DC
             * set V-measure
             * set Compliance to 2.0v
             * set current on 2400 to ( +.1 mA) //FM-17-12-11, Changed the current setting to 1mA for accuracy
             * sleep( 20ms )
             * measure v on 2400
             * get ohms -> string.
             * turn off 2400.
             * turn off channel
             * return( ohms )
             * 
             */

            ke7001Ctrl1.Ke7001_Init();
            ke7001Ctrl1.TurnOnChannel(cardSlot, channelNo);

            ke2400Ctrl1.Init();
            //ke2400Ctrl1.IsVoltageMeasurement = true; // This sets V-measure and causes ACDCType to DC during init as well.
            //ke2400Ctrl1.MeasurementVI = VIType.Voltage;
            //ke2400Ctrl1.MeasurementACDC = ACDCType.DC;
            //ke2400Ctrl1.setMeasureFunction(VIType.Current, ACDCType.DC);

            //ke2400Ctrl1.setOutputLevel(0.005f, VIType.Current);
            //float compliance = 10.0f;
            //ke2400Ctrl1.ComplianceSetpoint = (float)compliance;
            //ke2400Ctrl1.SetCompliance(compliance);
            //i = .1f;
            /*i = 1.0f;*/ ////FM-17-12-11, Changed the current setting to 1mA for accuracy

            //ke2400Ctrl1.Setpoint((float)i);
            //i = i / 1000;
            //ke2400Ctrl1.Set((float)i);
            //ke2400Ctrl1.setOutputLevel((float)i, VIType.Voltage);

            Thread.Sleep(100);
            ke2400Ctrl1.OutputEnabled = true;
            //Thread.Sleep(5000);
            //v = ke2400Ctrl1.measureVoltage();
            v = ke2400Ctrl1.Test();
            //ohms = v / i;
            retString = v.ToString();
            Thread.Sleep(100);

            //ke2400Ctrl1.OutputEnabled = false;
            ke7001Ctrl1.TurnOffChannel(cardSlot, channelNo);
            Ke7001_1.Disconnect();
            Thread.Sleep(100);
            addLog("Exiting resistanceTest ... ");
            addLog(retString);
            return (retString);
        }

       

        public bool TestInitialization()
        {

            //2400 connect 
            //7001 c
            //2400 setting 
            //2400 intial
            //7001 inti
            bool retValue = false;
            ke2400Ctrl1 = new Ke2400((byte)configForm.Ke2400GPIB);
            //GpibAddress = configForm.Ke2400GPIB;


            if (ke2400Ctrl1 != null)
            {
                //btnInit.Enabled = false;
                ke2400Ctrl1.SetFrontRear(true);
                //_ke2400Ctrl.SetCompliance( ( double )nudComplianceSetpoint.Value / 1000 );
                ke2400Ctrl1.SetCompliance(Properties.Settings.Default.compliance);
                ke2400Ctrl1.SourceVI = VIType.Current;

                ke2400Ctrl1.MeasurementVI = VIType.Voltage;
                ke2400Ctrl1.MeasurementACDC = ACDCType.DC;


                ke2400Ctrl1.setMeasureFunction(VIType.Voltage, ACDCType.DC);

                //btnRead.Enabled = true;
                retValue = true;
                //CurrentSetpoint = 0;
                ke2400Ctrl1.SetBeep(false);  // Turn beeping off.
                //if( IsVoltageControl )
                //    _ke2400Ctrl.SourceVI = VIType.Voltage;
                //else
                //    _ke2400Ctrl.SourceVI = VIType.Current;

            }
            return retValue;
        }

        //public bool Test()
        //{ return true; }

        //public bool Savedata()
        //{ return true; }

        //public bool Fin()
        //{ return true; }


        //    private string doResistanceTestByCurrent( int cardSlot, int channelNo, double current )  // TBD1
        //{

        //  addLog( "Entering doCurrentResistanceTest ... " );
        //  string retString = "Init";
        //  double i, v, ohms;
        //  /*
        //   * 
        //   * trun on channel (slot, channel)
        //   * turn on 2400
        //   * set DC
        //   * set V-measure
        //   * set Compliance to 2.0v
        //   * set current on 2400 to ( current mA)
        //   * sleep( 20ms )
        //   * measure v on 2400
        //   * get ohms -> string.
        //   * turn off 2400.
        //   * turn off channel
        //   * return( ohms )
        //   * 
        //   */

        //  Ke7001_1.Connect( );
        //  ke7001Ctrl1.TurnOnChannel( cardSlot, channelNo );

        //  this.ke2400Ctrl1.OutputEnabled = true;
        //  //this.ke2400Ctrl1.EnableOutput( true );
        //  this.ke2400Ctrl1.MeasurementVI = VIType.Voltage;
        //  this.ke2400Ctrl1.setMeasureFunction(VIType.Voltage, ACDCType.DC);// This sets V-measure and causes ACDCType to DC during init as well.
        //  float compliance = 2.0f;
        //  //this.ke2400Ctrl1.ComplianceSetpoint = ( float )compliance; 删除

        //  i = current;
        //  //this.ke2400Ctrl1.Setpoint( ( float )i );
        //  i = i / 1000;
        //  this.ke2400Ctrl1.Set((float)i); // no two arguments set()
        //  Thread.Sleep( 200 );
        //  //v = this.ke2400Ctrl1.TakeMeasurement( );
        //  v = (float)this.ke2400Ctrl1.measureVoltage();
        //  ohms = v / i;
        //  retString = ohms.ToString( );
        //  Thread.Sleep( 100 );

        //  //this.ke2400Ctrl1.chkTurnOn.Checked = false; 直接删除

        //  ke7001Ctrl1.TurnOffChannel( cardSlot, channelNo );
        //  Ke7001_1.Disconnect( );
        //  Thread.Sleep( 1000 );
        //  addLog( "Exiting resistanceTest ... " );
        //  return ( retString );
        //}

        //private string resistanceTest2( int cardSlot, int channelNo ) {
        //  addLog( "Entering resistanceTest ... " );
        //  string retString = "Init";
        //  double i, v, ohms;
        //  /*
        //   * 
        //   * trun on channel (slot, channel)
        //   * turn on 2400
        //   * set DC
        //   * set V-measure
        //   * set Compliance to 2.0v
        //   * set current on 2400 to ( +.001 mA)
        //   * sleep( 20ms )
        //   * measure v on 2400
        //   * get ohms -> string.
        //   * turn off 2400.
        //   * turn off channel
        //   * return( ohms )
        //   * 
        //   */

        //  Ke7001_1.Connect( );
        //  ke7001Ctrl1.TurnOnChannel(cardSlot, channelNo);

        //  this.ke2400Ctrl1.chkTurnOn.Checked = true;
        //  this.ke2400Ctrl1.EnableOutput( true );
        //  this.ke2400Ctrl1.IsVoltageMeasurement = true; // This sets V-measure and causes ACDCType to DC during init as well.
        //  float compliance = 2.0f;
        //  this.ke2400Ctrl1.ComplianceSetpoint = ( float )compliance;

        //  i = .001f;

        //  this.ke2400Ctrl1.Setpoint( ( float )i );
        //  Thread.Sleep( 200 );
        //  //Thread.Sleep(5000);
        //  v = this.ke2400Ctrl1.TakeMeasurement( );
        //  //Thread.Sleep(500); //fm-17-12-11
        //  ohms = v / i;
        //  retString = ohms.ToString( );
        //  Thread.Sleep( 100 );

        //  this.ke2400Ctrl1.chkTurnOn.Checked = false;
        //  ke7001Ctrl1.TurnOffChannel(cardSlot, channelNo);
        //  Ke7001_1.Disconnect( );
        //  Thread.Sleep( 1000 );
        //  addLog( "Exiting resistanceTest ... " );
        //  return ( retString );
        //}


        private void saveTestResults(string file)
        {
            CvsWriter = new System.IO.StreamWriter(file, false);
            CvsWriter.AutoFlush = true;
            for (int i = 0; i < noOfConfigs; i++)
            {
                CvsWriter.WriteLine(testResults[i]);
            }
            CvsWriter.Flush();
            CvsWriter.Close();
        }
        private void saveTestResults(string file, string line)
        {
            string[] AppendString = { line };
            File.AppendAllLines(file, AppendString);

            //CvsWriter = new System.IO.StreamWriter(file, false);
            //CvsWriter.AutoFlush = true;
            //CvsWriter.WriteLine(line);
            //CvsWriter.Flush();
            //CvsWriter.Close();
        }

        private void saveTestResults(string file, string line, string column)
        {
            FileInfo fvi = new FileInfo(file);
            bool WriteSign;
            if (fvi.Length < 5)
                WriteSign = true;
            else
                WriteSign = false;
            if (WriteSign)
            {
                string[] AppendString = new string[2];
                AppendString[0] = column;
                AppendString[1] = line;
                File.AppendAllLines(file, AppendString);
                //CvsWriter = new System.IO.StreamWriter(file, false);
                //CvsWriter.AutoFlush = true;
                //CvsWriter.WriteLine(column);
                //CvsWriter.WriteLine(line);
                //CvsWriter.Flush();
                //CvsWriter.Close();
            }
            else
            {
                string[] AppendString = { line };
                File.AppendAllLines(file, AppendString);
                //CvsWriter = new System.IO.StreamWriter(file, false);
                //CvsWriter.AutoFlush = true;
                //CvsWriter.WriteLine(line);
                //CvsWriter.Flush();
                //CvsWriter.Close();
            }
        }

        private void loadConfigFile(string file)
        {
            string[] Lines = File.ReadAllLines(file);
            noOfConfigs = Lines.Length;
            for (int i = 0; i < Lines.Length; i++)
            {
                testConfigs[i] = Lines[i];
            }

            //CvsReader = new System.IO.StreamReader( file );
            //int i = 0;
            //string line;
            //while( ( line = CvsReader.ReadLine( ) ) != null ) {
            //  testConfigs[ i ] = line;
            //  i++;
            //}
            //noOfConfigs = i;
            //CvsReader.Close( );
        }
        private void loadSpecFile(string file, string testPhase)
        {
            CvsReader = new System.IO.StreamReader(file);
            int i = 0;
            string line;
            while ((line = CvsReader.ReadLine()) != null)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                string[] specvalue = line.Split(',');
                if (testPhase == "None")
                {
                    testspecMin[i - 1] = specvalue[1];
                    testspecMax[i - 1] = specvalue[2];
                }
                if (testPhase == "Resistance")
                {
                    testspecMin[i - 1] = specvalue[3];
                    testspecMax[i - 1] = specvalue[4];
                }
                if (testPhase == "DirectShort")
                {
                    testspecMin[i - 1] = specvalue[5];
                    testspecMax[i - 1] = specvalue[6];
                }
                //if(testPhase == "TC")
                //{
                //    testspecMin[i-1] = specvalue[7];
                //    testspecMax[i-1] = specvalue[8];
                //}
                //if(testPhase == "LW")
                //{
                //    testspecMin[i-1] = specvalue[9];
                //    testspecMax[i-1] = specvalue[10];
                //}
                i++;
            }
            CvsReader.Close();
        }

        #endregion [TestApplication]


        public TestPhase TestPhase { get; set; }

















        //private void DataStructureSetupToolStripMenuItem_Click( object sender, EventArgs e ) {
        //  string strData = "Define database sturcture ...";
        //  MessageBox.Show( strData );
        //  StripStatusDisplay( strData );
        //  addLog( strData );

        //}

        //private void uploadDataToolStripMenuItem_Click( object sender, EventArgs e ) {
        //  string strData = "Up load data to database ...";
        //  MessageBox.Show( strData );
        //  StripStatusDisplay( strData );
        //  addLog( strData );
        //}

        //private void inputFilePathsToolStripMenuItem_Click( object sender, EventArgs e ) {
        //  toolStripStatusLabel1.Text = "Configuring ...";

        //  ReadDefaultSettings( );
        //  DoConfigForm( );
        //  WriteDefaultSettings( );

        //  toolStripStatusLabel1.Text = "Configured";

        //  addLog( "Configured with following paramters:" );
        //  addLog( "Lot Number: " + lotNumber );
        //  addLog( "Serial Number: " + serialNumber );
        //  addLog( "Operator Name: " + operatorName );
        //  addLog( "configFile: " + configFile );
        //  addLog( "dataOutputPath: " + dataOutputPath );
        //  addLog( "Test Spec file: " + testSpec );
        //  addLog( "Ke2400 GPIB: " + Ke2400_gpib.ToString( ) );
        //  addLog( "Ke7001 GPIB: " + Ke7001_gpib.ToString( ) );
        //  addLog( "Test Phase: " + TestPhase.ToString( ) );

        //  toolStripStatusLabel1.Text = "Ready ...";
        //}
        //private void button_7001Init_Click(object sender, EventArgs e)
        //{
        //    Ke7001_Init( );
        //}

        //private void button_7001ChannelOn_Click(object sender, EventArgs e)
        //{
        //    TurnOnChannel( );
        //}

        //private void button_7001ChannelOff_Click(object sender, EventArgs e)
        //{
        //    TurnOffChannel( );
        //}

        //private void button7002_Scan_Click(object sender, EventArgs e)
        //{
        //    Ke7001_Init();
        //    ScanForTosa_R();

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Config bbb = new Config();
            bbb.Show();
        }




        //private void DoConfigForm()
        //{

        //    WriteSettingsToConfigForm();

        //    DialogResult result = configForm.ShowDialog();

        //    if (result == DialogResult.OK)
        //    {
        //        ReadSettingsFromConfigForm();
        //        btn_StartTest.Enabled = true;
        //    }

        //}


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        //  private void resistanceACRTest(string file, string spec)
        //  {

        //      dataOutputFile = dataOutputPath + "\\ResistanceTest_" + "_" + configForm.lotNumber + "_" + configForm.testPhase + ".csv";
        //      string FailOutputFile = dataOutputPath + "\\ResistanceTest_" + "_" + configForm.lotNumber + "_" + configForm.testPhase + "_Fail.csv"; ;
        //      if (File.Exists(dataOutputFile) == false)
        //      {
        //          string[] field1 = { "" };
        //          File.WriteAllLines(dataOutputFile, field1);
        //          //string field = "Resule,Serialnumber,Operator,test pase,test time,";
        //          //saveTestResults(dataOutputFile, field);
        //          //File.Create(FailOutputFile);
        //          string[] field = { "Serialnumber,Operator,test pase,test time,Pin-Pin,test value,Spec Min,Spec Max" };
        //          File.WriteAllLines(FailOutputFile, field);
        //          //saveTestResults(dataOutputFile, field);
        //      }
        //      addLog("dataOutputFile: " + dataOutputFile);
        //      addLog("Loading config file ... ");
        //      loadConfigFile(file);
        //      addLog("Loading DONE.");
        //      addLog("Loading spec file ... ");
        //      loadSpecFile(spec, configForm.testPhase.ToString());
        //      addLog("Loading DONE.");
        //      addLog("Start testing ...");
        //      addLog("Initializing Ke2400, Ke7002 ... ");
        //      ke2400Ctrl1.Initialization();
        //      Ke7001_Init();
        //      //A4338b_Init( );
        //      addLog(" Looping ... ");
        //      ResultTxt.Text = "Testing..........";
        //      Application.DoEvents();
        //      bool Result = true;
        //      DateTime date = DateTime.Now;
        //      string ResultString = "";
        //      string ResultFieldString = "," + configForm.serialNumber + "," + configForm.operatorName + "," + configForm.testPhase + "," + date.ToString();
        //      string CloumnString = "Resule,Serialnumber,Operator,test pase,test time";
        //      string FailFieldString = configForm.serialNumber + "," + configForm.operatorName + "," + configForm.testPhase + "," + date.ToString();
        //      string FailString = "";
        //      int j = 0;
        //      for (int i = 0; i < noOfConfigs; i++)
        //      {
        //          string[] testConfig = testConfigs[i].Split(SplitChars);
        //          char c = testConfig[0][0];
        //          if (Char.IsNumber(c) == false)
        //          {
        //              addLog("Line " + i.ToString() + " not a test Config.");
        //              addLog(testConfigs[i]);
        //              testResults[i] = testConfigs[i];
        //              continue;
        //          }

        //          int testConf = Convert.ToInt32(testConfig[0]);
        //          int testType = Convert.ToInt32(testConfig[1]);
        //          int testSlot = Convert.ToInt32(testConfig[4]);
        //          int testChannel = Convert.ToInt32(testConfig[5]);
        //          string customTest = testConfig[6];
        //          addLog("Test Channel: " + testConf.ToString() + " Type: " + testType.ToString() + " Card Slot: " + testSlot.ToString() + " Card Channel: " + testChannel.ToString());
        //          string testResult = doTest(testType, testSlot, testChannel, customTest);
        //          if ((Convert.ToDouble(testResult) < Convert.ToDouble(testspecMin[j])) || (Convert.ToDouble(testResult) > Convert.ToDouble(testspecMax[j])))
        //          {
        //              Result = false;
        //              FailString = FailFieldString + "," + testConfig[2] + "_" + testConfig[3] + "," + testResult + "," + testspecMin[j] + "," + testspecMax[j];
        //              saveTestResults(FailOutputFile, FailString);
        //              j++;
        //          }
        //          else
        //          {
        //              j++;
        //          }
        //          CloumnString = CloumnString + "," + testConfig[2] + "_" + testConfig[3];
        //          ResultString = ResultString + "," + testResult;
        //          testResults[i] = testConfigs[i] + testResult;
        //      }

        //      addLog(" Testing DONE. ");
        //      addLog("Saving test result to file: " + dataOutputFile);
        //      if (Result == true)
        //      {
        //          ResultString = "PASS" + ResultFieldString + ResultString;
        //          ResultTxt.Text = "Test finish. Result: PASS";
        //      }
        //      else
        //      {
        //          ResultString = "Fail" + ResultFieldString + ResultString;
        //          ResultTxt.Text = "Test finish. Result: FAIL";
        //      }
        //      saveTestResults(dataOutputFile, ResultString, CloumnString);
        //      addLog("Saving ... DONE.");
        //  }



        //return (retString);
        //  }

        //     private string customResistanceTest( int cardSlot, int channelNo, string customTest ) {

        //  string retString = "Init";
        //  addLog( "Entering custom resistance test ...." );
        //  retString = "Init";

        //  // The custome test string takes the format:
        //  //  <input type> = <value> 
        //  // e.g., I = 10 
        //  // Default unit is mA for I and mV for V.
        //  //

        //  string custom = @"(?<name>[\w]+)(\s*=\s*)(?<value>[\d]+)?";
        //  Match match = Regex.Match( customTest, custom, RegexOptions.CultureInvariant | RegexOptions.ECMAScript );

        //  string name = match.Groups[ "name" ].Value;
        //  string sValue = match.Groups[ "value" ].Value;

        //  switch( name.ToLower( ) ) {
        //    case "i":
        //      retString = doResistanceTestByCurrent( cardSlot, channelNo, Convert.ToDouble( sValue ) );
        //      break;
        //    default:
        //      retString = "Wrong Type";
        //      break;
        //  }

        //  addLog( "Exiting custom resistance test ...." );
        //  return ( retString );
        //}

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox_Log_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Status_Click(object sender, EventArgs e)
        {

        }

        private void Ke7001GpibAddress_ValueChanged(object sender, EventArgs e)
        {

        }





        //private string diodeTest( int cardSlot, int channelNo ) {

        //  addLog( "Entering diodeTest ... " );
        //  string retString = "Init";
        //  double i, compliance, v1, v2;

        //  /*
        //   * 
        //   * trun on channel (slot, channel)
        //   * init 2400
        //   * turn on 2400
        //   * set DC
        //   * set V-measure
        //   * set compliant voltage ( 3V)
        //   * set current on 2400 to ( + 2 mA)
        //   * sleep( 20ms )
        //   * measure v1 on 2400
        //   * set current on 2400 to ( - 2mA)
        //   * sleep (20ms)
        //   * measure v2 on 2400;
        //   * turn off 2400.
        //   * turn off channel
        //   * return( v = "v1, v2" )
        //   * 
        //   */

        //  Ke7001_1.Connect( );
        //  turnOnChannel( cardSlot, channelNo );

        //  this.ke2400Ctrl1.chkTurnOn.Checked = true;
        //  this.ke2400Ctrl1.EnableOutput( true );
        //  this.ke2400Ctrl1.IsVoltageMeasurement = true; // This sets V-measure and causes ACDCType to DC during init as well.
        //  ///
        //  compliance = 2.0f;
        //  this.ke2400Ctrl1.ComplianceSetpoint = ( float )compliance;
        //  i = 2.0f;
        //  this.ke2400Ctrl1.Setpoint( ( float )i );
        //  Thread.Sleep( 200 );
        //  v1 = this.ke2400Ctrl1.TakeMeasurement( );
        //  retString = v1.ToString( );

        //  i = -2.0f;
        //  this.ke2400Ctrl1.Setpoint( ( float )i );
        //  Thread.Sleep( 200 );
        //  v2 = this.ke2400Ctrl1.TakeMeasurement( );
        //  retString = retString + ", " + v2.ToString( );
        //  Thread.Sleep( 200 );

        //  this.ke2400Ctrl1.chkTurnOn.Checked = false;
        //  turnOffChannel( cardSlot, channelNo );
        //  Ke7002_1.Disconnect( );

        //  addLog( "Exiting diodeTest ... " );
        //  return ( retString );
        //}

        //#region [To be implemented]
        //private string ACRTest( int cardSlot, int channelNo ) {
        //  addLog( "Entering ACRTest ... " );
        //  string retString = "Init";
        //  double resistance = 0;

        //  int implemented = 0;

        //  /*
        //   * turn on channel (slot, channel)
        //   * init ACR (Agilent4338B)
        //   * connect ACR (Agilent4338B).
        //   * sleep (20ms)
        //   * measure ACR on A4338B.
        //   * turn off ACR.
        //   * turn off channel.
        //   */

        //  if( implemented == 1 ) {
        //    //Ke7002_1.Connect( );
        //    //turnOnChannel( cardSlot, channelNo );
        //    A4338b_1.Connect( );
        //    A4338b_1.SetInitCont( );
        //    Thread.Sleep( 20 );

        //    resistance = A4338b_1.Measure( );
        //    retString = resistance.ToString( );

        //    A4338b_1.Disconnect( );
        //    //turnOffChannel( cardSlot, channelNo );
        //    //Ke7002_1.Disconnect( );

        //    addLog( "Exiting ACRTest ... " );
        //    return ( retString );
        //  }
        //  else {
        //    return ( retString = "NA" );
        //  }
        //}
        //#endregion [To be implemented]



        //private void tabPage3_Click( object sender, EventArgs e ) {

        //}

        //#region [TestCode]

        //    private void button_anyTest_Click( object sender, EventArgs e ) {

        //  //resistanceACRTest( configFile );

        //  // get Assembly version 
        //  anyTest( );

        //}

        //private void anyTest( ) {
        //  // Test reading config file and write to outout data file.

        //  string dateString = DateTime.UtcNow.ToString( "yyyy-MM-dd-HH-mm-ss" );
        //  dataOutputFile = dataOutputPath + "\\ResistanceTest_" + dateString + "_" + configForm.lotNumber + "_" + configForm.serialNumber + ".csv";

        //  addLog( dateString );
        //  addLog( dataOutputFile );

        //  string assemblyVersion = "";
        //  assemblyVersion = String.Format( "Version of the app is: {0}",
        //    typeof( Form1 ).Assembly.GetName( ).Version );
        //  addLog( "assemblyVersion: " + assemblyVersion );

        /*
          addLog("Initializing Ke2400, Ke7002 and A4338B ... ");
          ke2400Ctrl1.Initialization();

          addLog("Testing anyTest ...");

          int beep = 0;
          for (var i = 0; i < 5; i++)
          {
              beep = 1 - beep;
              addLog("Set Beeping on Ke2400 ...");
              if (beep == 1)
              {
                  ke2400Ctrl1.setBeep(true);
              }
              else { ke2400Ctrl1.setBeep(false);
              }
              addLog("Turn on Ke2400 ...");
              this.ke2400Ctrl1.chkTurnOn.Checked = true;
              Thread.Sleep(500);
              addLog("Turn off Ke2400 ...");
              this.ke2400Ctrl1.chkTurnOn.Checked = false;
              Thread.Sleep(500);
          }


        */
        //loadConfigFile( configFile );

        /*
              Ke7002_Init( );
              int slot = 9;
              for( int i = 1; i <= 40; i++ ) {
                turnOnChannel( slot, i );
                Thread.Sleep( 1000 );
              }
              Ke7002_Init( );
              Thread.Sleep( 1000 );

              for( int i = 1; i <= 40; i++ ) {
                turnOnChannel( slot, i );
                Thread.Sleep( 500 );
                turnOffChannel( slot, i );
                Thread.Sleep( 500 );
              }
              Ke7002_Init( );
         * */






        private void ke2400Ctrl1_Load(object sender, EventArgs e)
        {

        }

        private void hiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Finisar.GPIB_Controls.Ke2400Ctrl aaa = new Finisar.GPIB_Controls.Ke2400Ctrl();
            aaa.Show();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Label_operatorName_Click(object sender, EventArgs e)
        {
        
        }










    }
}
