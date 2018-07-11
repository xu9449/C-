using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace Finisar.Controls {
    public partial class MEMS_Switch_Control : UserControl {

        public delegate void InstrumentEventHandler( object sender );
        public event InstrumentEventHandler Switch_OperationCompleted;
        public event InstrumentEventHandler Switch_OperationInProcess;

        FinOE.Driver_MEMSSwitch _Switch;
        SerialPort Serial_Comm;
        bool hasPowerMeter = false;
        short curChannel;
        private double PowerOffSet;
        bool bUpdateOnly = false;
        public MEMS_Switch_Control( ) {
            InitializeComponent( );
            SerialNumber = "S1200";
        }

        public bool IsPowerMeterAttached {
            get { return hasPowerMeter; }
            set { 
                hasPowerMeter = value;
                gboPower.Visible = hasPowerMeter;
                Validate( );
            }
        }
        public string SerialNumber { get; set; }
        public string ControlName {
            get { return gboChSwitch.Text; }
            set { gboChSwitch.Text = value; }
        }

        public string Chanel_1_Name {
            get { return rdoPower.Text; }
            set { rdoPower.Text = value; }
        }

        public string Channel_2_Name {
            get { return rdoSpec.Text; }
            set { rdoSpec.Text = value; }
        }

        public string Channel_3_Name {
            get { return rdoEye.Text; }
            set { rdoEye.Text = value; }
        }

        public string Channel_4_Name {
            get { return rdoOther.Text; }
            set { rdoOther.Text = value; }
        }

        public RadioButton GetRadioButton( short index) {
            if( index == 1 )
                return rdoPower;
            else if( index == 2 )
                return rdoSpec;
            else if( index == 3 )
                return rdoEye;
            else
                return rdoOther;
    }
        public bool Initialization( string serialNo) {
            bool retValue = false;
            _Switch = new FinOE.Driver_MEMSSwitch( );
            
            if( _Switch != null ) {
                
                _Switch.SetParameters(serialNo, 1310);//( "S2184", 1550 );
                retValue = _Switch.Init( );
                btnInitSwitch.Enabled = !retValue;

                gboChSwitch.Enabled = retValue;
                if( hasPowerMeter ) {
                    Init_PowerMeter( );
                }
                _Switch.SetChannel( ref curChannel );
                rdoPower.Enabled = retValue;
                rdoEye.Enabled = retValue;
                rdoSpec.Enabled = retValue;
                rdoOther.Enabled = retValue;
            }
            return retValue;
        }
        #region [ MEMS Switch Control ]

        private void btnInitSwitch_Click( object sender, EventArgs e ) {
            if( _Switch == null )
                _Switch = new FinOE.Driver_MEMSSwitch( );
            Initialization( SerialNumber );
        }

        public void SwitchChannel( short chNumber ) {
            if( _Switch != null ) {
                FireGoingToSwitchChannel();
                curChannel = chNumber;
                bUpdateOnly = true;
                GetRadioButton( chNumber ).Checked = true;
                Validate( );
                _Switch.SetChannel( ref curChannel );
                bUpdateOnly = false;
                FireSwitchChanged(curChannel.ToString());
            }
        }
        private void rdoPower_CheckedChanged( object sender, EventArgs e ) {
            //if( _Swith == null )
            //    return;
            if( rdoPower.Checked == true ) {
                curChannel = 1;
                if (!bUpdateOnly)
                {
                    SwitchChannel(1);
                }
                if( Serial_Comm != null ) {
                    Thread.Sleep( 200 );
                    PowerMeterMeasurement( );
                    Thread.Sleep( 100 );
                    PowerMeterMeasurement( );
                    lblPowerReading.Text = PowerMeterReading;
                }
                
            }
        }

        private void rdoSpec_CheckedChanged( object sender, EventArgs e ) {

            if( rdoSpec.Checked == true ) {
                if (!bUpdateOnly)
                {
                    SwitchChannel(2);
                }
            }
        }

        private void rdoEye_CheckedChanged( object sender, EventArgs e ) {
            if( rdoEye.Checked == true ) {
                if (!bUpdateOnly)
                {
                    SwitchChannel(3);
                }
                
            }
        }
        private void rdoOther_CheckedChanged( object sender, EventArgs e ) {
            if( rdoOther.Checked == true ) {
                if (!bUpdateOnly)
                {
                    SwitchChannel(4);
                }
            }
        }
        private void FireSwitchChanged( string currentChannel ) {
            if( Switch_OperationCompleted != null )
                Switch_OperationCompleted( currentChannel );
        }

        private void FireGoingToSwitchChannel()
        {
            if (Switch_OperationInProcess != null)
                Switch_OperationInProcess(this);
        }
        #endregion

        #region [ PowerMeter Handling ]

        public bool Init_PowerMeter( ) {
            Serial_Comm = new SerialPort( );
            Serial_Comm.BaudRate = 19200;
            Serial_Comm.DataBits = 8;
            Serial_Comm.PortName = @"COM3";
            Serial_Comm.StopBits = StopBits.One;
            Serial_Comm.Parity = 0;
            Serial_Comm.ReadTimeout = 100;
            Serial_Comm.Open( );
            return Serial_Comm.IsOpen;
        }
        
        public string PowerMeterReading { get; set; }
        
        public double GetPowerOffset( ) {
            PowerOffSet = double.Parse( txtPowerOffset.Text );
            return PowerOffSet;
        }
        public double PowerActualValue { get; set; }

        public void PowerMeterMeasurement( ) {
            if( Serial_Comm == null || Serial_Comm.IsOpen == false )
                return;
            Serial_Comm.WriteLine( "v" );
            Thread.Sleep( 200 );
            string reading = Serial_Comm.ReadLine( );
            if( reading.Contains( "L" ) )
                reading = "NaN";
            else
                reading = Convert.ToDouble( reading ).ToString( );
            //double powerReading = Convert.ToDouble( Serial_Comm.ReadLine( ) );
            PowerMeterReading = reading;
            lblActualPower.Text = GetActualPowerValue( ).ToString( "0.00" );

            Validate();
        }

        public double GetActualPowerValue( ) {
            PowerActualValue = double.Parse( PowerMeterReading ) + GetPowerOffset();
            return PowerActualValue;
        }
        #endregion

        private void txtPowerOffset_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
