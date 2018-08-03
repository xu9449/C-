using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Finisar.GPIB_Controls {
    public partial class PowerSupply : UserControl {
        Finisar.AgPowerSupply _PowerSupply;

        public PowerSupply( ) {
            InitializeComponent( );
        }

        public void Init( ) {
            _PowerSupply = new Finisar.AgPowerSupply( ( byte )GPIB_Address );
            if( _PowerSupply != null ) {
                _PowerSupply.SourceControlType = chkVoltageCtrl.Checked ? Finisar.VIType.Voltage : Finisar.VIType.Current;
                chkVoltageCtrl.Enabled = false;
                btnInit.Enabled = false;
                nudGpibAddress.Enabled = false;
                btnMeasure.Enabled = true;
                btnPowerOff.Enabled = true;
                btnPowerOn.Enabled = true;
            }
        }
        private void btnInit_Click( object sender, EventArgs e ) {
            Init( );
        }

        private void nudSetOutput1_ValueChanged( object sender, EventArgs e ) {
            if( _PowerSupply == null )
                return;
            SetOutput1( ( float )nudSetOutput1.Value );
        }

        private void nudSetOutput2_ValueChanged( object sender, EventArgs e ) {
            if( _PowerSupply == null )
                return;
            SetOutput2( (float )nudSetOutput2.Value );
        }

        private void btnMeasure_Click( object sender, EventArgs e ) {
            Measure( );
        }

        public void SetOutput1( float set_value ) {
            _PowerSupply.SetVoltage( "out1", set_value );
        }
        public void SetOUT1LimitCurrent(float set_value)
        {
            if (_PowerSupply == null)
                Init();
            _PowerSupply.SetCurrentLimit("out1", set_value);
        }
        public void SetOUT2LimitCurrent(float set_value)
        {
            if (_PowerSupply == null)
                Init();
            _PowerSupply.SetCurrentLimit("out2", set_value);
        }
        public void SetOutput2( float set_value ) {
            _PowerSupply.SetVoltage( "out2", set_value );
        }

        public void Measure( ) {
            float result1 = 0;
            float result2 = 0;
            _PowerSupply.Measure( ref result1, ref result2, false);
            lblResult1.Text = (result1 * 1000).ToString();
            lblResult2.Text = ( result2 * 1000 ).ToString( );
        }
        public float Output1_Voltage {
            get { return (float)nudSetOutput1.Value; }
            set { nudSetOutput1.Value = (decimal) value;
            }
        }
        
        public float Output2_Voltage {
            get { return (float) nudSetOutput2.Value; }
            set { nudSetOutput2.Value =(decimal) value;
            //nudSetOutput2.Validate( );
            }
        }

        public float Output1_MeasureResult {
            get { return float.Parse( lblResult1.Text ); }
        }
        public float Output2_MeasureResult {
            get { return float.Parse( lblResult2.Text ); }
        }
        public decimal GPIB_Address {
            get { return nudGpibAddress.Value; }
            set {
                nudGpibAddress.Value = value;
            }
        }

        private void btnPowerOn_Click( object sender, EventArgs e ) {
            _PowerSupply.OutputEnabled = true;
        }

        private void btnPowerOff_Click( object sender, EventArgs e ) {
            _PowerSupply.OutputEnabled = false;
            lblResult1.Text = "0";
            lblResult2.Text = "0";
            System.Windows.Forms.Application.DoEvents( );
        }

        public void EnablePowerOutput( bool state ) {
            if( _PowerSupply == null )
                Init( );
            _PowerSupply.OutputEnabled = state;
        }
    }
}
