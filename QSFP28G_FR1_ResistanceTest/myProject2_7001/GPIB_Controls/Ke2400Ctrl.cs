using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Finisar.GPIB_Controls {
    public partial class Ke2400Ctrl : UserControl{

        Finisar.Ke2400 _ke2400Ctrl;
        float rampStep = 0.5F;
        float CurrentSetpoint = 0;
        float CurrentMeasureResult = 0;
        bool UpdateOnly = false;

        public delegate void OutputStatusUpdate(object sender ,bool state );
        public event OutputStatusUpdate UpdateOutputStatus;

        public delegate void Voltage_Current_EventHandler( double voltageValue, double currentValue );
        public event Voltage_Current_EventHandler VoltageCurrentUpdate;

        public Ke2400Ctrl( ) {
            InitializeComponent( );
        }

        public string CtrlName {
            get { return gboKeithleyCtrl.Text; }
            set { gboKeithleyCtrl.Text = value; }
        }
        public decimal GpibAddress {
            get { return nudGpibAddress.Value; }
            set {
                nudGpibAddress.Value = value;
            }
        }
        public int ChannelNumber { get; set; }

        public bool IsVoltageControl {
            get { return chkVoltageCtrl.Checked; }
            set { chkVoltageCtrl.Checked = value; }
        }
        public bool IsFrontMeasure {
            get { return chkFrontMeasure.Checked; }
            set { chkFrontMeasure.Checked = value; }
        }
        public bool IsVoltageMeasurement {
            get { return chkMeasureVoltage.Checked; }
            set { chkMeasureVoltage.Checked = value; }
        }
        public float  ComplianceSetpoint {
            get
            {
                return (float) nudComplianceSetpoint.Value;
            }
            set { nudComplianceSetpoint.Value=(decimal)value; }
        }

        public bool Initialization( ) {
            bool retValue = false;
            _ke2400Ctrl = new Finisar.Ke2400( ( byte )GpibAddress );
            GpibAddress = byte.Parse( nudGpibAddress.Value.ToString( ) );
            

            if( _ke2400Ctrl != null ) {
                btnInit.Enabled = false;
                _ke2400Ctrl.SetFrontRear( IsFrontMeasure );
                //_ke2400Ctrl.SetCompliance( ( double )nudComplianceSetpoint.Value / 1000 );
                _ke2400Ctrl.SetCompliance( ( double )nudComplianceSetpoint.Value );
                _ke2400Ctrl.SourceVI = IsVoltageControl ? VIType.Voltage : VIType.Current;
                if( IsVoltageMeasurement ) {
                    _ke2400Ctrl.MeasurementVI = VIType.Voltage;
                    _ke2400Ctrl.MeasurementACDC = ACDCType.DC;
                    _ke2400Ctrl.setMeasureFunction( VIType.Voltage, ACDCType.DC );
                }
                btnRead.Enabled = true;
                retValue = true;
                CurrentSetpoint = 0;
                _ke2400Ctrl.SetBeep(false);  // Turn beeping off.
                //if( IsVoltageControl )
                //    _ke2400Ctrl.SourceVI = VIType.Voltage;
                //else
                //    _ke2400Ctrl.SourceVI = VIType.Current;

            }
            return retValue;
        }
        
        private void btnInit_Click( object sender, EventArgs e ) {
            Initialization( );
        }

        private void chkTurnOn_CheckedChanged( object sender, EventArgs e ) {
            if (!UpdateOnly)
            {
                //if (chkTurnOn.Checked)
                //{
                //    _ke2400Ctrl.SetCompliance(0D);
                //    Thread.Sleep(100);
                //}
                EnableOutput(chkTurnOn.Checked);
                //if (chkTurnOn.Checked)
                //{
                //    for (int i = 0; i < 35; i++)
                //    {
                //        _ke2400Ctrl.SetCompliance(i*0.1);
                //        Thread.Sleep(100);
                //        Application.DoEvents();
                //        _ke2400Ctrl.measureVoltage();

                //    }
                //    _ke2400Ctrl.SetCompliance(3.5d);
                //}
            }
        }

        private void nudGpibAddress_ValueChanged( object sender, EventArgs e ) {
            GpibAddress = (byte)nudGpibAddress.Value;
        }

        private void chkFrontMeasure_CheckedChanged( object sender, EventArgs e ) {
            IsFrontMeasure = chkFrontMeasure.Checked;
            if( _ke2400Ctrl != null ) {
                SetToGround( );
                EnableOutput( false );
                _ke2400Ctrl.SetFrontRear( IsFrontMeasure );
                EnableOutput( true );
            }
        }

        private void chkVoltageCtrl_CheckedChanged( object sender, EventArgs e ) {
            IsVoltageControl = chkVoltageCtrl.Checked;
            if( _ke2400Ctrl != null ) {
                if( IsVoltageControl )
                    _ke2400Ctrl.SourceVI = VIType.Voltage;
                else
                    _ke2400Ctrl.SourceVI = VIType.Current;
            }
        }

        private void btnRead_Click( object sender, EventArgs e ) {
            TakeMeasurement( );
        }

        private void nudSetpoint_ValueChanged( object sender, EventArgs e ) {
            if( !UpdateOnly )
                Setpoint( ( float )nudSetpoint.Value );
        }

        private void nudComplianceSetpoint_ValueChanged( object sender, EventArgs e ) {
            if( _ke2400Ctrl == null )
                return;
            double value = ( double )nudComplianceSetpoint.Value ; // / 1000;
            _ke2400Ctrl.SetCompliance( value );
        }

        private void btnRamp_Click( object sender, EventArgs e ) {
            Ramp( ( float )nudSetpoint.Value, ( float)nudTargetPoint.Value, true );
        }

        #region Support Functions
        public void setBeep(bool on) {
            _ke2400Ctrl.SetBeep(on);
        }
        void DisableConfig( ) {
            chkVoltageCtrl.Enabled = false;
            chkFrontMeasure.Enabled = false;
            nudComplianceSetpoint.Enabled = false;
            nudGpibAddress.Enabled = false;
            btnInit.Enabled = false;
        }
        void EnableSetting( ) {
            chkTurnOn.Enabled = true;
            nudSetpoint.Enabled = true;
            btnRead.Enabled = true;
        }

        public void Ramp( float startValue, float targetValue, bool raiseEvent ) {
            float rampValue = (targetValue  - startValue ) > 0 ? 1 : -1;
            rampValue = rampValue * rampStep;
             UpdateOnly = true;
             while( startValue != targetValue ) {
                startValue += rampValue;
                _ke2400Ctrl.Set( startValue );
               double curRead = _ke2400Ctrl.measureCurrent( );
               if( VoltageCurrentUpdate != null )
                   VoltageCurrentUpdate( startValue, curRead );
                
            }

            if( startValue != targetValue )
                _ke2400Ctrl.Set( targetValue );
            //CurrentSetpoint = targetValue;
            //nudSetpoint.Value = ( decimal )CurrentSetpoint;
            UpdateOnly = false;
        }

        public void EnableOutput( bool state ) {
            if( _ke2400Ctrl != null ) {
                _ke2400Ctrl.OutputEnabled = state;
                UpdateOnly = true;
                chkTurnOn.Checked = state;
                UpdateOnly = false;
                if( state == false ) {
                    CurrentMeasureResult = 0;
                    lblReading.Text = "--";
                    CurrentSetpoint = 0;
                }
                else
                    CurrentSetpoint = ( float )nudSetpoint.Value;
                if( UpdateOutputStatus != null )
                    UpdateOutputStatus(this, state );
            }
        }

        public void Setpoint( float setValue ) {
            if( _ke2400Ctrl != null ) {
                UpdateOnly = true;
                setValue = setValue / 1000;
                _ke2400Ctrl.Set( setValue );
                CurrentSetpoint = setValue * 1000;
                nudSetpoint.Value = ( decimal )CurrentSetpoint;
                UpdateOnly = false;
            }
        }

        public float GetCurrentVoltage( ) {
            return (float)_ke2400Ctrl.measureVoltage( );
        }

        public float GetCurrent( ) {
            //return _ke2400Ctrl.Measure( );
            return (float) _ke2400Ctrl.measureCurrent( );
        }
        private void SetToGround( ) {
            Setpoint( 0 );
        }

        public double GetCurrentMeasurement( ) {
            return CurrentMeasureResult;
        }

        public float GetCurrentSetPoint( ) {
            return CurrentSetpoint;
        }

        public float TakeMeasurement( ) {
            if( _ke2400Ctrl.OutputEnabled ) {
                if( IsVoltageMeasurement )
                    CurrentMeasureResult = ( float )_ke2400Ctrl.measureVoltage( );
                else
                    CurrentMeasureResult = ( float )_ke2400Ctrl.measureCurrent( );

                lblReading.Text = CurrentMeasureResult.ToString( );
            }
            return CurrentMeasureResult;
        }
        #endregion

        private void chkMeasureVoltage_CheckedChanged( object sender, EventArgs e ) {
            if( _ke2400Ctrl != null ) {
                     _ke2400Ctrl.MeasurementACDC = ACDCType.DC;
               if( chkMeasureVoltage.Checked ) {
                    _ke2400Ctrl.MeasurementVI = VIType.Voltage;
                    _ke2400Ctrl.setMeasureFunction( VIType.Voltage, ACDCType.DC );
                }
                else {
                   _ke2400Ctrl.MeasurementVI = VIType.Current;
                   _ke2400Ctrl.setMeasureFunction( VIType.Current, ACDCType.DC );
                }
            }
        }

    }
}
