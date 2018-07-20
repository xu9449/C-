using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Finisar.GPIB_Controls {
    public partial class Ke2000Ctrl : UserControl {
        Finisar.VIConfig ke2000Config;
        Finisar.Ke2000 Ke2000;
        Finisar.VIType MeasureType = Finisar.VIType.Current;
        Finisar.ACDCType AcDc;
        private double CurrentMeasureResult = 0;
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

        public Ke2000Ctrl( ) {
            InitializeComponent( );
        }

        public void Initialization( byte gpibAddress ) {
            GpibAddress = gpibAddress;
            Initialization( );
        }

        public bool Initialization( ) {
            bool retValue = false;
            Ke2000 = new Finisar.Ke2000( ( byte )GpibAddress );
            ke2000Config = new Finisar.VIConfig( MeasureType, ACDCType );
            if( Ke2000 != null ) {
                Ke2000.Configure( ke2000Config );
                measureButton.Enabled = true;
                btnInit.Enabled = false;
                retValue = true;
            }
            return retValue;
        }
        private void btnInit_Click( object sender, EventArgs e ) {
            Initialization( );
        }

        private void measureButton_Click( object sender, EventArgs e ) {
           //resultLabel.Text = Ke2000.Measure( ).ToString();
           TakeMeasurement( );
        }

        private void chkVoltageCtrl_CheckedChanged( object sender, EventArgs e ) {
            SetMeasureType( chkVoltageCtrl.Checked );
        }

        private void chkchkDC_CheckedChanged( object sender, EventArgs e ) {
            ACDCType = chkDC.Checked ? Finisar.ACDCType.DC : Finisar.ACDCType.AC;
        }

        public void SetMeasureType( bool isVoltage ) {
            if( isVoltage )
                MeasureType = Finisar.VIType.Voltage;
            else
                MeasureType = Finisar.VIType.Current;
        }

        public Finisar.ACDCType ACDCType {
            get { return AcDc =  chkDC.Checked ? Finisar.ACDCType.DC : Finisar.ACDCType.AC; }
            set { AcDc = value; }
            //if( Ke2000 != null ) {
            //    Ke2000.MeasurementACDC = isDC ? Finisar.ACDCType.DC : Finisar.ACDCType.AC;
            //}
        }

        public double GetCurrentMeasurement() {
            return CurrentMeasureResult;
        }

        public double TakeMeasurement( ) {
            
            CurrentMeasureResult = Ke2000.Measure( ) * 1000;
            if( CurrentMeasureResult > 8 )
                CurrentMeasureResult = CurrentMeasureResult / 1000;
            resultLabel.Text = CurrentMeasureResult.ToString( );
            
            return CurrentMeasureResult;
        }
        public void Reset( ) {
            CurrentMeasureResult = 0;
            resultLabel.Text = "--";
        }
    }
}
