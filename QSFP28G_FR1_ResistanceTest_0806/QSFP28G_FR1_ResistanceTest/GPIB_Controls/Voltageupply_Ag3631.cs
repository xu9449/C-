using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Finisar.GPIB_Controls {
    public partial class Voltageupply_Ag3631 : UserControl {
        public Voltageupply_Ag3631( ) {
            InitializeComponent( );
        }
        
        #region Private fields
        public delegate void InstrumentEventHandler( object sender );
        public event InstrumentEventHandler ControlDataChanged;
        public event InstrumentEventHandler OperationCompleted;
        public event InstrumentEventHandler ResultDataChanged;
        private AgE3631A smVoltageSupply;
        private Dictionary<int, VoltageSupplyPort> ports;
        //private Dictionary<int, AgE3631AOutputVoltage> portMappings;
        private Dictionary<int, double[ ]> limitMappings;
        private bool control_OutputEnabled;

        #endregion
        
        public void FireControlDataChanged( ) {
            if( this.ControlDataChanged != null )
                this.ControlDataChanged( this );
        }
        public void FireOperationCompleted( ) {
            if( this.OperationCompleted != null )
                this.OperationCompleted( this );
        }
        public void FireResultDataChanged( ) {
            if( this.ResultDataChanged != null )
                this.ResultDataChanged( this );
        }
        
        public void Setting_P06I_Compliance( double value ) {
            if( ports[ 6 ].CurrentCompliance == value )
                return;
            ports[ 6 ].CurrentCompliance = value;
            FireControlDataChanged( );
        }

        public double Get_P06I_compliance( ) {
            return ports[ 6 ].CurrentCompliance;
        }

        public void Setting_P25I_Compliance( double value ) {

            if( ports[ 25 ].CurrentCompliance == value )
                return;

            ports[ 25 ].CurrentCompliance = value;
            FireControlDataChanged( );
        }

        public double Get_P25I_Compliance( ) { 
                 return ports[ 25 ].CurrentCompliance;
       }

        public void Setting_N25I_Compliance( double value ) {

            if( ports[ -25 ].CurrentCompliance == value )
                return;

            ports[ -25 ].CurrentCompliance = value;
            FireControlDataChanged( );
        }

        public double Get_N25I_Compliance( ) { 
            return ports[ -25 ].CurrentCompliance;
        }

        public void Setting_Control_P06V( double value ) {

            if( ports[ 6 ].Voltage == value )
                return;

            if( value < ports[ 6 ].VoltageLimits[ 0 ] || value > ports[ 6 ].VoltageLimits[ 1 ] ) {
                SetStateDescription( "Attempt to set Control_P06V value (" + value.ToString( "0.00" ) + "V) out of allowed range (" + ports[ 6 ].VoltageLimits[ 0 ].ToString( "0.00" ) + "V, " + ports[ 6 ].VoltageLimits[ 1 ].ToString( "0.00" ) + "V)" );
                return;
            }

            ports[ 6 ].Voltage = value;
            FireControlDataChanged( );
        }

        public double Get_Control_P06V( ) { 
                return ports[ 6 ].Voltage;
        }

        public void Setting_Control_P25V( double value ) {

            if( ports[ 25 ].Voltage == value )
                return;

            if( value < ports[ 25 ].VoltageLimits[ 0 ] || value > ports[ 25 ].VoltageLimits[ 1 ] ) {
                SetStateDescription( "Attempt to set Control_P25V value (" + value.ToString( "0.00" ) + "V) out of allowed range (" + ports[ 25 ].VoltageLimits[ 0 ].ToString( "0.00" ) + "V, " + ports[ 25 ].VoltageLimits[ 1 ].ToString( "0.00" ) + "V)" );
                return;
            }

            ports[ 25 ].Voltage = value;
            FireControlDataChanged( );
        }

        public double Get_Control_P25V( ) { 
                return ports[ 25 ].Voltage;
        }

        public void Setting_Control_N25V( double value ) {

            if( ports[ -25 ].Voltage == value )
                return;

            if( value < ports[ -25 ].VoltageLimits[ 0 ] || value > ports[ -25 ].VoltageLimits[ 1 ] ) {
                SetStateDescription( "Attempt to set Control_N25V value (" + value.ToString( "0.00" ) + "V) out of allowed range (" + ports[ -25 ].VoltageLimits[ 0 ].ToString( "0.00" ) + "V, " + ports[ -25 ].VoltageLimits[ 1 ].ToString( "0.00" ) + "V)" );
                return;
            }

            ports[ -25 ].Voltage = value;
            FireControlDataChanged( );
        }

        public double Get_Control_N25V( ) { 
                 return ports[ -25 ].Voltage;
       }

        public void Setting_Control_OutputEnabled( bool value ) {

            if( value == control_OutputEnabled )
                return;
            control_OutputEnabled = value;
            smVoltageSupply.OutputEnabled = value;
            FireControlDataChanged( );
            SetStateDescription( "Control_OutputEnabled set to " + control_OutputEnabled.ToString( ) );
        }

        public bool Get_Control_OutputEnabled( ) { 
                return control_OutputEnabled;
        }

        public double Result_P06V( ) {
            return ports[ 6 ].MeasuredVoltage;
        }

        public double Result_P25V( ) {
            return ports[ 25 ].MeasuredVoltage;
        }
        public double Result_N25V( ) {
            return ports[ -25 ].MeasuredVoltage;
        }
        public double Result_P06I( ) {
            return ports[ 6 ].MeasuredCurrent;
        }
        public double Result_P25I( ) {
            return ports[ 25 ].MeasuredCurrent;
        }
        public double Result_N25I( ) {
            return ports[ -25 ].MeasuredCurrent;
        }

        public bool Initialization( byte address ) {
            try {
                smVoltageSupply = new AgE3631A( address);


                ports = new Dictionary<int, VoltageSupplyPort>( );
                ports.Add( 6, new VoltageSupplyPort( AgE3631AOutputVoltage.P06V ) );
                ports.Add( 25, new VoltageSupplyPort( AgE3631AOutputVoltage.P25V ) );
                ports.Add( -25, new VoltageSupplyPort( AgE3631AOutputVoltage.N25V ) );

                limitMappings = new Dictionary<int, double[ ]>( );
                limitMappings.Add( 6, new double[ 2 ] { 0.0, 6.0 } );
                limitMappings.Add( 25, new double[ 2 ] { 0.0, 10.0 } );
                limitMappings.Add( -25, new double[ 2 ] { -10.0, 0.0 } );
                smVoltageSupply.OutputEnabled = true;
                Connect( );
                InitializeGlobal( );
                control_OutputEnabled = true;
                return control_OutputEnabled;
            }
            catch( Exception e ) {
                throw new Exception( "Error instantiating the Voltage" + e.ToString( ) );
            }
        }

        public void Connect( ) {

            smVoltageSupply.ApplySettings( );
            foreach( KeyValuePair<int, VoltageSupplyPort> kvp in ports ) {
                if( kvp.Key == 6 ) {
                    smVoltageSupply.Output = kvp.Value.Port;
                    kvp.Value.VoltageLimits = limitMappings[ kvp.Key ];
                    kvp.Value.Voltage = smVoltageSupply.VoltageLimit;
                    kvp.Value.CurrentCompliance = smVoltageSupply.CurrentLimit;
                }
            }
            FireControlDataChanged( );

            //SetVoltages( );
        }
        /// <summary>
        /// Turns off the output before base.Disconnect( )
        /// </summary>
        public void Disconnect( ) {
            control_OutputEnabled = false;
        }

        public void Reset( ) {
            // base.Reset( );
        }
        public void InitializeGlobal( ) {
            SetVoltages( );
        }
        public override string ToString( ) {
            return "VoltageSupply";
        }

        /// <summary>
        /// Sets the voltages and current compliances to the E3631A
        /// </summary>
        public void SetVoltages( ) {
            if( smVoltageSupply == null )
                return;
            try {
                foreach( KeyValuePair<int, VoltageSupplyPort> kvp in ports ) {
                    if( kvp.Key == 6 ) {
                        smVoltageSupply.Output = kvp.Value.Port;
                        smVoltageSupply.VoltageLimit = ( float )kvp.Value.Voltage;
                        smVoltageSupply.CurrentLimit = ( float )kvp.Value.CurrentCompliance;
                    }
                }
                FireControlDataChanged( );
                SetStateDescription( "Output voltages set." );

            }
            catch( Exception e ) {
                throw new Exception( "Error setting output voltage = " + e.ToString( ) );
            }
            finally {
                FireOperationCompleted( );
            }
        }
        /// <summary>
        /// Measures all voltages and currents on an E3631A
        /// </summary>
        public void MeasureAll( ) {
            try {
                foreach( KeyValuePair<int, VoltageSupplyPort> kvp in ports ) {
                    if( kvp.Key == 6 ) {
                        smVoltageSupply.Output = kvp.Value.Port;
                        kvp.Value.MeasuredVoltage = smVoltageSupply.Voltage;
                        kvp.Value.MeasuredCurrent = smVoltageSupply.Current;
                    }
                }
                UpdateAllLabels( );
                FireResultDataChanged( );

            }
            catch( Exception e ) {
                throw new Exception( "MeasureAll error = " + e.ToString( ) );
            }
            finally {
                FireOperationCompleted( );
            }
        }
        private void SetStateDescription( string description ) {

            lblStatus.Text = description;
        }


        void UpdateAllInputs( ) {
            nud_6V.Value = ( decimal )Get_Control_P06V();
            //nud_p25V.Value = ( decimal )Control_P25V;
            //nud_n25V.Value = ( decimal )Control_N25V;

            nud_6I.Value = ( decimal )Get_P06I_compliance( );
            //nud_p25I.Value = ( decimal )Setting_P25I_Compliance;
            //nud_n25I.Value = ( decimal )Setting_N25I_Compliance;

            enableCB.Checked = Get_Control_OutputEnabled();
            enableCB.BackColor = Get_Control_OutputEnabled() ? Color.Lime : SystemColors.Control;
        }
        void UpdateAllLabels( ) {
            voltageLabelp6V.Text = Result_P06V().ToString( "0.000" );
            //voltageLabelp25V.Text = Result_P25V().ToString( "0.000" );
            //voltageLabeln25V.Text = Result_N25V().ToString( "0.000" );
            currentLabelp6V.Text = Result_P06I().ToString( "0.000" );
            //currentLabelp25V.Text = Result_P25I().ToString( "0.000" );
            //currentLabeln25V.Text = Result_N25I().ToString( "0.000" );
        }

        private void btnMeasure_Click( object sender, EventArgs e ) {
            MeasureAll( );
        }
        
        private void nud_6V_ValueChanged( object sender, EventArgs e ) {
            if( smVoltageSupply != null ) {
                Setting_Control_P06V (( double )nud_6V.Value);
                SetVoltages( );
            }
        }

        private void nud_p25V_ValueChanged( object sender, EventArgs e ) {
            if( smVoltageSupply != null ) {
                Setting_Control_P25V( ( double )nud_p25V.Value );
                SetVoltages( );
            }
        }

        private void nud_n25V_ValueChanged( object sender, EventArgs e ) {
            if( smVoltageSupply != null ) {
                Setting_Control_N25V( ( double )nud_n25V.Value );
                SetVoltages( );
            }
        }

        private void nud_6I_ValueChanged( object sender, EventArgs e ) {
            if( smVoltageSupply != null ) {
                Setting_P06I_Compliance( ( double )nud_6I.Value );
                SetVoltages( );
            }
        }

        private void nud_p25I_ValueChanged( object sender, EventArgs e ) {
            if( smVoltageSupply != null ) {
                Setting_P25I_Compliance( ( double )nud_p25I.Value );
                SetVoltages( );
            }
        }

        private void nud_n25I_ValueChanged( object sender, EventArgs e ) {
            if( smVoltageSupply != null ) {
                Setting_N25I_Compliance( ( double )nud_n25I.Value );
                SetVoltages( );
            }

        }
        /// <summary>
        /// Class defining name and settings for an E3631A output port used as a voltage supply.
        /// </summary>
        public class VoltageSupplyPort {
            private AgE3631AOutputVoltage port;
            private double setVoltage;
            private double[ ] voltageLimits;
            private double currentCompliance;

            private double measuredVoltage;
            private double measuredCurrent;

            public AgE3631AOutputVoltage Port {
                set {
                    port = value;
                }
                get {
                    return port;
                }
            }
            public double Voltage {
                set {
                    setVoltage = value;
                }
                get {
                    return setVoltage;
                }
            }
            public double[ ] VoltageLimits {
                set {
                    voltageLimits = value;
                }
                get {
                    return voltageLimits;
                }
            }
            public double CurrentCompliance {
                set {
                    currentCompliance = value;
                }
                get {
                    return currentCompliance;
                }
            }
            public double MeasuredVoltage {
                set {
                    measuredVoltage = value;
                }
                get {
                    return measuredVoltage;
                }
            }
            public double MeasuredCurrent {
                set {
                    measuredCurrent = value;
                }
                get {
                    return measuredCurrent;
                }
            }

            public VoltageSupplyPort( ) {
            }
            public VoltageSupplyPort( AgE3631AOutputVoltage port ) {
                this.port = port;
            }
        }

        private void enableCB_CheckedChanged( object sender, EventArgs e ) {
            smVoltageSupply.OutputEnabled = enableCB.Checked;
            
        }

    }
}