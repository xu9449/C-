using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Finisar.GPIB_Controls {
    public partial class TempControl : UserControl {
        public Finisar.Ke2510 TempCtrl;
        float CurrentTemp;
        float CurrentPower;
        float CurrentVoltage;
        float CurrentI;
        bool _mesureTempOnly = false;
        bool markOnly = false;
        public bool MeasureTempOnly {
            get { return _mesureTempOnly;}
            set {
                _mesureTempOnly = value;
                gboMoreMeasure.Visible = !_mesureTempOnly;
                Validate( );
            }
        }
        public TempControl( ) {
            InitializeComponent( );
        }

        public string ControlName {
            get { return gboTempControl.Text; }
            set { gboTempControl.Text = value; }
        }
        public decimal GpibAddress {
            get { return nudGpibAddress.Value; }
            set {
                nudGpibAddress.Value = value;
            }
        }
        public decimal DefaultTemp {
            get { return Tset_NUD.Value; }
            set { Tset_NUD.Value = value; }
        }
        public bool Initialization( ) {
            bool retValue = false;
            TempCtrl = new Finisar.Ke2510( ( byte )nudGpibAddress.Value );
            if( TempCtrl != null ) {
                Tset_NUD.Enabled = Tset_NUD.Enabled; //TempCtrl.isTecOn( );
                measureButton.Enabled = Tset_NUD.Enabled;
                btnInit.Enabled = !measureButton.Enabled;
                retValue = true;
            }
            return retValue;
        }
        public void EnableOutput( bool state ) {
            TempCtrl.switchTec( state );
            markOnly = true;
            chkTurnOn.Checked = state;
            markOnly = false;
        }
        private void Tset_NUD_ValueChanged( object sender, EventArgs e ) {
            SetTemp( (float) Tset_NUD.Value );
        }

        private void measureButton_Click( object sender, EventArgs e ) {
            TakeMeasurement( );
        }

        private void btnInit_Click( object sender, EventArgs e ) {
            Initialization( );
        }

        public void SetTemp( float value ) {
            if( TempCtrl != null ) {
                if( CurrentTemp != value ) {
                    TempCtrl.setTemperature( ( float )Tset_NUD.Value );
                    Tset_NUD.Value = ( decimal )value;
                }
            }
        }
        public float GetCurrentMeasurement( ) {
            return CurrentTemp;
        }

        public float GetCurrentPower( ) {
            return CurrentPower;
        }

        public float GetCurrentI( ) {
            return CurrentI;
        }

        public float GetCurrentVoltage( ) {
            return CurrentVoltage;
        }

        public float TakeMeasurement( ) {
            CurrentTemp = TempCtrl.measureTemperature( );
            resultLabel.Text = CurrentTemp.ToString( );
            if( !_mesureTempOnly ) {
                
                CurrentPower = TempCtrl.measureTecPower( );
                powerLabel.Text = CurrentPower.ToString( );
             
                CurrentVoltage = TempCtrl.measureTecVoltage( );
                voltageLabel.Text = CurrentVoltage.ToString( );
                
                CurrentI = TempCtrl.measureTecCurrent( );
                if( CurrentI > 10 )
                    CurrentI = CurrentI / 1000;
                currentLabel.Text = CurrentI.ToString( );
            }
            return CurrentTemp;
        }

        private void chkTurnOn_CheckedChanged( object sender, EventArgs e ) {
            if (!markOnly)
                EnableOutput( chkTurnOn.Checked );
        }

    }
}
