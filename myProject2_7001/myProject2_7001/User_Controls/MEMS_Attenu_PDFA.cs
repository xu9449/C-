using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;

namespace Finisar.User_Controls {
    public partial class MEMS_Attenu_PDFA : UserControl {
        public delegate void InstrumentEventHandler( object sender );
        //public event InstrumentEventHandler Atten_OperationCompleted;
        public event InstrumentEventHandler ShutterStatusUpdated;
        FinOE.Driver_MEMSAttenuator _MEMSAttenuator;
        Finisar.AMP_FL8611 _PDFA;
        Finisar.Ag86100C objDCA_ctrl;
        public Hashtable htAttenTable;
        private float LastAttenSetpoint;
        private float AttenAddjustValue;
        public MEMS_Attenu_PDFA( ) {
            InitializeComponent( );
            
        }

        #region [ User Action ]

        private void btnLaunchVenderGUI_Click( object sender, EventArgs e ) {
            _MEMSAttenuator.FormLaunch( );
        }

        private void nudSetAtten_ValueChanged( object sender, EventArgs e ) {

            if (LastAttenSetpoint != (float)nudSetAtten.Value)
            {
                LastAttenSetpoint = (float)nudSetAtten.Value;
                SetMemsAttenByDac(LastAttenSetpoint);
            }
            //SetMemsAtten( ( float )nudSetAtten.Value );
            //Thread.Sleep( 200 );
            //lblAttenReading.Text = GetMemsAtten( ).ToString( );
        }
       
        private void btnTurnOn_PDFA_Click( object sender, EventArgs e ) {
            TurnOnOff_PDFA(true);
        }

        private void btnTurnOff_PDFA_Click( object sender, EventArgs e ) {
            TurnOnOff_PDFA(false);
        }


        private void btnOpenShutter_Click( object sender, EventArgs e ) {
            SetMemsAttenShutter( true );
            Thread.Sleep( 200 );
        }

        private void btnCloseShutter_Click( object sender, EventArgs e ) {
            SetMemsAttenShutter( false );
            Thread.Sleep( 200 );
            UpdateShutterStatus( );
        }

        private void btnDCA_Power_Click( object sender, EventArgs e ) {
            //objDCA_ctrl.StartEyeMeasurement( 100, 60000f );
            GetDCAPower();
        }

        private void btnInit_Click( object sender, EventArgs e ) {
            Initlization("");
        }

        private void btnGetReading_Click( object sender, EventArgs e ) {
            lblPdfa_Ch1_current.Text = _PDFA.GetChannelCurrent( 1 ).ToString();
            lblPdfa_Ch2_current.Text = _PDFA.GetChannelCurrent( 2 ).ToString( );
        }

        private void nudDacSetpoint_ValueChanged(object sender, EventArgs e)
        {
            SetMEMSAttenDac((int)nudDacSetpoint.Value);
        }

        #endregion

        #region [Support Functions/Properties ]

        public bool Initlization(string sn ) {
            
            _PDFA = new AMP_FL8611(1);
            _PDFA.OutputEnabled = true;
            
            _MEMSAttenuator = new FinOE.Driver_MEMSAttenuator( );

            loadLookupTable();
            
            _MEMSAttenuator.SetParameters(sn, 1310);
            _MEMSAttenuator.AttenInit((short)1310);

            string reading = _MEMSAttenuator.GetMemsFWVersion();
            lblFWversion.Text = reading;
            _MEMSAttenuator.GetMemsSN(ref reading);
            lblSN.Text = reading;
            _MEMSAttenuator.GetHwID(ref reading);
            lblHwId.Text = reading;
            SetAttenToSafeMode();
            btnInit.Enabled = false;
            
            nudSetAtten.Enabled = true;
            nudDacSetpoint.Enabled = true;

            return true;
        }

        public float LastDCAPower
        {
            get { return float.Parse(lblDCA_Power.Text); }
            set { lblDCA_Power.Text = value.ToString(); }
        }

        public float LastAttenValue
        {
            get { return LastAttenSetpoint; }
            set { LastAttenSetpoint = value; }
        }

        public float LastAddjustAttenValue
        {
            get { return AttenAddjustValue; }
        }

        public void TurnOnOff_PDFA(bool state)
        {
            SetAttenToSafeMode();
            if (state)
            {
                _PDFA.OutputEnabled = true;
                Thread.Sleep(2000);
                _PDFA.SetACC(1, 400);
                _PDFA.SetACC(2, 400);
            }
            else
            {
                _PDFA.OutputEnabled = false;
            }
        }

        public void SetAttenToSafeMode()
        {
            LastAttenSetpoint = 45;
            nudSetAtten.Value = 45;
            SetMEMSAttenDac(65000);
        }

        public void SetMemsAtten( float iAtten ) {
            _MEMSAttenuator.SetAtten( iAtten );
        }
        
        public void SetMEMSAttenDac(int iDacValue)
        {
           string retValue = "";
            _MEMSAttenuator.SetDac(iDacValue);
            
            _MEMSAttenuator.GetDAC( ref retValue);
            
            lblAtten_dac.Text = retValue;
        }

        public void SetDCAHISTMode(string OnOff)
        { 
            if (objDCA_ctrl != null)
            {
                objDCA_ctrl.SetHISTMode( OnOff );
            }
            else
            {
                MessageBox.Show("objDCA_ctrl is null");
            }
            return;
        }

        public float GetDCAPower()
        {
            float powerReading = 0f;
            if (objDCA_ctrl != null)
            {
                powerReading = objDCA_ctrl.MeasureOpticalPower();
                lblDCA_Power.Text = powerReading.ToString();

                if (lblDCA_Power.Text.Contains("NaN"))
                    powerReading = -50;
            }
            else
            {
                MessageBox.Show("objDCA_ctrl is null");
            }
            return powerReading;
        }
        public float GetMemsAtten( ) {
            return _MEMSAttenuator.ReadAtten( );
        }

        public void SetMemsAttenShutter( bool bOpen ) {
            if (bOpen)
                //_MEMSAttenuator.SetShutter( FinOE.Driver_MEMSAttenuator.ATTENUATOR_SHUTTERSTATE.SHUTTER_OPEN );
                _MEMSAttenuator.SetShutter( 0 );
            else
                _MEMSAttenuator.SetShutter( 0 );
        }

        public bool IsMEMESAttenShutterOpen( ) {
            bool bOpen = false;
            string retValue = "";
            _MEMSAttenuator.GetShutterStatus( ref retValue );
            bOpen = retValue.Contains( "False" ) ? false : true;
            return bOpen;
        }

        public void SetMemsAtten_Dac( int iDac ) {
            _MEMSAttenuator.SetDac( iDac );
        }

        public void SetMemsAttenByDac(float atten)
        {
            int dacNumber;
            atten = float.Parse(string.Format(atten.ToString("0.00")));
            AttentuatorLookUpTable atable = (AttentuatorLookUpTable)htAttenTable[atten.ToString()];
            if (atable != null)
            {
                dacNumber = atable.Dac_1310;
                SetMEMSAttenDac(dacNumber);
                LastAttenValue = atten;
            }
            else
            {
                LastAttenValue = 0;
                MessageBox.Show("Error to get Dac number");
            }
        }

        public int GetMemsAtten_Dac( ) {
            string dacValue = "0";
            _MEMSAttenuator.GetDAC( ref dacValue );

            return int.Parse( dacValue );
        }

        public string GetMEMSAtten_HwId( ) {
            string strValue = "";
            _MEMSAttenuator.GetHwID( ref strValue );
            
            return strValue;
        }

        public string GetMemsAttenFwVersion( ) {
            return _MEMSAttenuator.GetMemsFWVersion( );
        }

        private void UpdateShutterStatus( ) {
            if( IsMEMESAttenShutterOpen( ) )
                lblShutterStatus.Text = "Shutter Opened";
            else
                lblShutterStatus.Text = "Shutter Closed";

            if( ShutterStatusUpdated != null )
                ShutterStatusUpdated( this );
        }


        public Finisar.Ag86100C SetDCACtrol {
            set {
                objDCA_ctrl = value;
            }
        }

        public void MeasureDCAPowerLoop()
        {
            float dcaPower = GetDCAPower();
            
            while (dcaPower < 3)
            {
                if (LastAttenSetpoint == 0)
                {
                    SetAttenToSafeMode();
                    MessageBox.Show("Failed to CheckDCAPower! Please check around!!");
                    break;
                }
                if (dcaPower < -10 && LastAttenSetpoint >= 10)
                {
                    SetMemsAttenByDac(LastAttenSetpoint - 5);
                }
                else if (dcaPower < 1)
                {
                    SetMemsAttenByDac(LastAttenSetpoint - 1);
                }
                else
                {
                    SetMemsAttenByDac(LastAttenSetpoint - 0.1f);
                }
                Thread.Sleep(100);
                dcaPower = GetDCAPower();

            }
            LastDCAPower = dcaPower;
            nudSetAtten.Value = (decimal)LastAttenSetpoint;
            AttenAddjustValue = LastAttenSetpoint;
        }

        private void loadLookupTable()
        {
            htAttenTable = new Hashtable();
            //StreamReader streamReader = new StreamReader(@"C:\Temp\OSA_World\Finisar_OSA\Finisar_OSA\Finisar_OSA\bin\Debug\A1215.txt");
            string path = Directory.GetCurrentDirectory();
             StreamReader streamReader = new StreamReader(path + @"\A1215.txt");
            
            string currentLine = "";
            currentLine = streamReader.ReadLine().Trim();

            while (streamReader.Peek() >= 0)
            {
              currentLine = streamReader.ReadLine().Trim();
                //if (currentLine != null)
                string[] parts = currentLine.Split('\t');
                htAttenTable.Add(parts[0], new AttentuatorLookUpTable(float.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])));
            }
        }

        #endregion " [Support Functions] "
    }

    public class AttentuatorLookUpTable 
    {
        public float AttenSetpoint;
        public int Dac_1310;
        public int Dac_1550;
        public AttentuatorLookUpTable(float atten, int dac_1310, int dac_1550)
        {
            AttenSetpoint = atten;
            Dac_1310 = dac_1310;
            Dac_1550 = dac_1550;
        }
    }

}
