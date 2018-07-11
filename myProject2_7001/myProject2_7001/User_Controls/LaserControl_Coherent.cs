using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Finisar.Controls {
    public partial class LaserControl_Coherent : UserControl {
        #region Member Data
        byte CurrentDeviceAddress;
        byte CurrentRegisterAddress;
        int RampIndex;
        bool CancelRamp;
        Finisar.Com_I2C I2C_comm;
        string LastReading;
        byte[ ] DataOut;
        byte[ ] DataIn;
        Finisar.Ag86100C objDCA_ctrl;
        public delegate void StatusReport_EventHandler( string statusMsg );
        public event StatusReport_EventHandler StatusReport;
        public delegate void InstrumentEventHandler( object sender );
        public event InstrumentEventHandler OperationCompleted;
        public event InstrumentEventHandler AdjustmentIsDone;
        #endregion

        public LaserControl_Coherent( ) {
            InitializeComponent( );
            cobChannel.Items.Add( "XI" );
            cobChannel.Items.Add( "YI" );
            cobChannel.Items.Add( "XQ" );
            cobChannel.Items.Add( "YQ" );
        }

        public bool Initialization( ) {
            cobChannel.Text = "XI";
            CurrentDeviceAddress = 0x2C;
            CurrentRegisterAddress = 0x00;
            DataOut = new byte[ 5 ];
            DataIn = new byte[ 4 ];
            I2C_comm = new Com_I2C( CurrentDeviceAddress );
            bool isOK = I2C_comm.Init( );
            RampIndex = 2;
            btnInit.Enabled = !isOK;
            btnRamp.Enabled = isOK;
            btnRead.Enabled = isOK;
            btnSend.Enabled = isOK;
            return isOK;
        }

        public string GetChannelName
        {
            get { return cobChannel.Text; }
        }
        public byte[ ] GetDataOut( ) {
            return DataOut;
        }

        public byte[ ] GetDataIn( ) {
            return DataIn;
        }

        public int GetRampIndex( ) {
            return RampIndex;
        }

        public byte RampStartValue { get; set; }
        public byte RampTargetValue { get; set; }

        private string SendSetpoint( ) {
            string msg;
            msg = I2C_comm.WriteData( CurrentDeviceAddress, DataOut );
            if( StatusReport != null )
                StatusReport( msg );
            Thread.Sleep( 100 );
            GetReading( );
            return msg;
        }

        public Finisar.Ag86100C SetDCACtrol
        {
            set{
                objDCA_ctrl = value;
            }
        }

        public void Setpoint( byte Value, int index ) {
            
            DataOut[ index ] = Value;
            lblSendOut.Text = SendSetpoint( );
        }

        public byte[ ] GetReading( ) {
            DataIn = I2C_comm.ReadData( CurrentDeviceAddress, CurrentRegisterAddress, 4 );
            lblReadback.Text = string.Format( "{0}  {1}  {2}   {3}", DataIn[ 0 ], DataIn[ 1 ], DataIn[ 2 ], DataIn[ 3 ] );
            return DataIn;
        }

        public void PrepareToRamp( ) {
            
            DataOut.Initialize( );
            DataOut[ 0 ] = CurrentRegisterAddress;
            DataOut[ 1 ] = ( byte )nudFeild_1.Value;
            DataOut[ 2 ] = ( byte )nudFeild_2.Value;
            DataOut[ 3 ] = ( byte )nudFeild_3.Value;
            DataOut[ 4 ] = ( byte )nudFeild_4.Value;
            RampStartValue = DataOut[ RampIndex ];
            RampTargetValue = ( byte )nudRampStop.Value;
            SendSetpoint( );
        }

        public void RampToNext( ) {

            int step = ( int )nudRampStep.Value;
            if( !IsGreater )
                step = -step;
            DataOut[ RampIndex ] += (byte) step;
            RampStartValue = DataOut[ RampIndex ];
            SendSetpoint( );
            if( OperationCompleted != null )
                OperationCompleted( this );
        }

        //public void RampToNextwithAdjust( float crossingValue ) {
        //    DoAdjustment( crossingValue);
        //    RampToNext( );
        //}

        public void DoAdjustment(  ) {
            if( objDCA_ctrl != null ) {
                float crossingValue = objDCA_ctrl.GetCrossingMeanValue();
                while( !IsCrossingInRange( crossingValue ) ) {
                    int adjustValue = ( int )Math.Abs( crossingValue - 50 ) * 2;
                    if( RampIndex == 1 ) {
                        if( crossingValue > 50 )
                            DataOut[ 3 ] -= ( byte )adjustValue;
                        else
                            DataOut[ 3 ] += ( byte )adjustValue;
                    }
                    else if( RampIndex == 2 ) {
                        if( crossingValue > 50 )
                            DataOut[ 4 ] += ( byte )adjustValue;
                        else
                            DataOut[ 4 ] -= ( byte )adjustValue;
                    }
                    SendSetpoint( );
                    Thread.Sleep( 200 );
                    objDCA_ctrl.StartEyeMeasurement( 100, 60000f );
                    crossingValue = objDCA_ctrl.MeasureCrossing( );
                }
                if( AdjustmentIsDone != null )
                    AdjustmentIsDone( this );
            }
        }

        public bool IsRampDone( ) {
            if (RampStartValue == RampTargetValue)
                return true;
            bool isGreater = RampStartValue < RampTargetValue ? true : false;
            return isRampDone( DataOut[ RampIndex ], RampTargetValue, RampStartValue, isGreater );
        }

        private bool IsGreater {
            get { return RampStartValue < RampTargetValue ? true : false; }
        }

        private bool IsCrossingInRange( float value ) {
            return ( value <= 51 && value >= 49 ) ;
        }
        private void InternalRamp( byte[ ] dataOut, int index ) {
            int step = (int) nudRampStep.Value;
            bool done = false;
            bool isGreater = true;
            byte startValue = dataOut[ index ];
            if( startValue > ( int )nudRampStop.Value ) {
                step = -step;
                isGreater = false;
            }
            do {
                lblSendOut.Text = SendSetpoint( );
                dataOut[ index ] += ( byte )step;
                System.Windows.Forms.Application.DoEvents( );
                Thread.Sleep( 500 );

                if( CancelRamp )
                    break;
                
                done = isRampDone( dataOut[ index ], ( byte )nudRampStop.Value, startValue,isGreater );

                //if( dataOut[ index ] == ( int )nudRampStop.Value ) {
                //    lblSendOut.Text = I2C_comm.WriteData( CurrentDeviceAddress, dataOut );
                //    System.Windows.Forms.Application.DoEvents( );
                //    done = true;
                //}
            } while( !done );

        }
        private bool isRampDone( byte curValue, byte targetValue, byte startValue,bool isGreater) {
            if( isGreater )
                return curValue <= targetValue ? false : true;
            else
                return ( curValue >= targetValue && curValue < startValue ) ? false : true;
        }
        
        public void ClosePort( ) {
            I2C_comm.closePort( );
        }

        private void cobChannel_SelectedIndexChanged( object sender, EventArgs e ) {
            if (cobChannel.Text.Equals("XI"))
                CurrentDeviceAddress = 0x2c;
            else if( cobChannel.Text.Equals( "YI" ) )
                CurrentDeviceAddress = 0x2d;
            else if( cobChannel.Text.Equals( "YQ" ) )
                CurrentDeviceAddress = 0x2e;
            else if( cobChannel.Text.Equals( "XQ" ) )
                CurrentDeviceAddress = 0x2f;
        }

       
        private void rdoFeild_4_Click( object sender, EventArgs e ) {
            if( rdoFeild_4.Checked ) {
                RampIndex = 4;
            }
        }
        private void rdoFeild_3_Click( object sender, EventArgs e ) {
            if( rdoFeild_3.Checked ) {
                RampIndex = 3;
            }
        }

        private void rdoFeild_2_Click( object sender, EventArgs e ) {
            if( rdoFeild_2.Checked ) {
                RampIndex = 2;
            }
        }

        private void rdoFeild_1_Click( object sender, EventArgs e ) {
            if( rdoFeild_1.Checked ) {
                RampIndex = 1;
            }
        }

        private void btnRamp_Click( object sender, EventArgs e ) {
            CancelRamp = false;
            DataOut.Initialize( );
            DataOut[ 0 ] = CurrentRegisterAddress;
            DataOut[ 1 ] = ( byte )nudFeild_1.Value;
            DataOut[ 2 ] = ( byte )nudFeild_2.Value;
            DataOut[ 3 ] = ( byte )nudFeild_3.Value;
            DataOut[ 4 ] = ( byte )nudFeild_4.Value;
            InternalRamp( DataOut, RampIndex );

        }

        private void btnSend_Click( object sender, EventArgs e ) {
            DataOut.Initialize( );
            DataOut[ 0 ] = CurrentRegisterAddress;
            DataOut[ 1 ] = ( byte )nudFeild_1.Value;
            DataOut[ 2 ] = ( byte )nudFeild_2.Value;
            DataOut[ 3 ] = ( byte )nudFeild_3.Value;
            DataOut[ 4 ] = ( byte )nudFeild_4.Value;
            lblSendOut.Text = SendSetpoint( );
        }

        private void btnRead_Click( object sender, EventArgs e ) {
            byte[ ] readBack = new byte[ 3 ];
            readBack = I2C_comm.ReadData( CurrentDeviceAddress, CurrentRegisterAddress, 4 );
            lblReadback.Text = string.Format( "{0}  {1}  {2}   {3}", readBack[ 0 ], readBack[ 1 ], readBack[ 2 ], readBack[ 3 ] );
            LastReading = string.Format("{0},{1},{2},{3}",readBack[ 0 ], readBack[ 1 ], readBack[ 2 ], readBack[ 3 ] );
        }

        private void btnInit_Click( object sender, EventArgs e ) {
            Initialization( );
            
        }

        private void btnCancelRamp_Click( object sender, EventArgs e ) {
            CancelRamp = true;
        }


        public string GetDackReading( ) {
            return LastReading;
        }

    }
}
