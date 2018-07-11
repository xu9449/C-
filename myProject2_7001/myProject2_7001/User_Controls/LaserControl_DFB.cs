using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Finisar;

namespace Finisar.Controls {
    public partial class LaserControl_DFB : UserControl {
        
        public delegate void PowerTurnedON( );
        public event PowerTurnedON StatusReport;

        Finisar.Com_SPI Spi;
        ArrayList DFBdatalist;
        public LaserControl_DFB( ) {
            InitializeComponent( );
            DFBdatalist = new ArrayList( );
        }

        #region [Orphaned methods]

        private Byte GetUserInput( string userInput ) {
            byte address = 0;
            try {
                string add;
                if( ( userInput.Contains( "x" ) ) || ( userInput.Contains( "X" ) ) )
                    add = userInput.Substring( 2 );
                else
                    add = userInput;
                address = byte.Parse( add, System.Globalization.NumberStyles.HexNumber );
                return address;
            }
            catch( Exception ex ) {
                throw new Exception( ex.ToString( ) );
            }
        }

        private void btnExit_Click( object sender, EventArgs e ) {
            if( Spi != null )
                Spi.closePort( );
            //btnPowerOff_Click( null, null );
        }

        #endregion [Orphaned methods]

        #region Channel 0

        private void chkEnableRFStage_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x14, GetByteFromBoolean( chkEnableRFStage_Ch0.Checked ), 8, 1 );
        }

        private void nudSetModCurrent_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x17, ( byte )nudSetModCurrent_Ch0.Value, 8, 0xFF );
        }

        private void nudRiseFallTime_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x17, ( byte )nudRiseFallTime_Ch0.Value, 4, 0xF );
        }

        private void chkEnableBoost_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x14, GetByteFromBoolean( chkEnableBoost_Ch0.Checked ), 11, 1 );
        }

        private void chkEnableBoostRange_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x14, GetByteFromBoolean( chkEnableBoostRange_Ch0.Checked ), 12, 1 );
        }

        private void nudBoostAmont_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x14, ( byte )nudBoostAmont_Ch0.Value, 13, 7 );
        }

        private void nudBoostDelay_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x13, ( byte )nudBoostDelay_Ch0.Value, 13, 7 );
        }

        private void chkEnablePosiAsymBoost_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x13, GetByteFromBoolean( chkEnablePosiAsymBoost_Ch0.Checked ), 8, 1 );
        }

        private void chkEnableNegAsymBoost_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x13, GetByteFromBoolean( chkEnableNegAsymBoost_Ch0.Checked ), 9, 1 );
        }

        private void nudAsymBoostValue_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x13, ( byte )nudAsymBoostValue_Ch0.Value, 10, 7 );
        }

        private void chkEnablePrecursor_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x12, GetByteFromBoolean( chkEnablePrecursor_Ch0.Checked ), 12, 1 );
        }

        private void nudPrecursorValue_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x12, ( byte )nudPrecursorValue_Ch0.Value, 13, 7 );
        }

        private void chkCrossPointPolarity_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x13, GetByteFromBoolean( chkCrossPointPolarity_Ch0.Checked ), 3, 1 );
        }

        private void nudCrossPointValue_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x13, ( byte )nudCrossPointValue_Ch0.Value, 4, 0xF );
        }

        private void chkEnableJEQ_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x14, GetByteFromBoolean( chkEnableJEQ_Ch0.Checked ), 10, 1 );
        }

        private void nudJEQUpValue_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x17, ( byte )nudJEQUpValue_Ch0.Value, 0, 0xF );
        }

        private void nudJEQDownValue_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, ( byte )nudJEQDownValue_Ch0.Value, 4, 0xF );
        }

        private void chkJEQ_PredownTransition_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, GetByteFromBoolean( chkJEQ_PredownTransition_Ch0.Checked ), 2, 1 );
        }

        private void chkJEQ_PreupTransition_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, GetByteFromBoolean( chkJEQ_PreupTransition_Ch0.Checked ), 3, 1 );
        }

        private void chkRiseFallTimeIndependent_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x14, GetByteFromBoolean( chkRiseFallTimeIndependent_Ch0.Checked ), 9, 1 );
        }

        private void chkPolaritySwap_Ch0_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x13, GetByteFromBoolean( chkPolaritySwap_Ch0.Checked ), 0, 1 );
        }

        private void nudInputStageEquaSet_Ch0_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x13, ( byte )nudInputStageEquaSet_Ch0.Value, 1, 3 );
        }

        private void btnTurnOn_Ch0_Click( object sender, EventArgs e ) {
            TurnOnOffCh0( true );
        }

        private void btnTurnOff_Ch0_Click( object sender, EventArgs e ) {
            TurnOnOffCh0( false );
        }

        public void TurnOnOffCh0( bool state ) {
            if( state ) {
                chkEnableRFStage_Ch0.Checked = true;
                nudSetModCurrent_Ch0.Value = 159;
                nudRiseFallTime_Ch0.Value = 15;
                chkEnableBoost_Ch0.Checked = true;
                chkEnableBoostRange_Ch0.Checked = true;
                nudBoostAmont_Ch0.Value = 7;
            }
            else {
                chkEnableRFStage_Ch0.Checked = false;
                nudSetModCurrent_Ch0.Value = 0;
                nudRiseFallTime_Ch0.Value = 0;
                chkEnableBoost_Ch0.Checked = false;
                chkEnableBoostRange_Ch0.Checked = false;
                nudBoostAmont_Ch0.Value = 0;
            }
            if( StatusReport != null )
                StatusReport( );
        }

        #endregion Channel 0

        #region Channel 1

        private void chkEnableRFStage_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x11, GetByteFromBoolean( chkEnableRFStage_Ch1.Checked ), 0, 1 );
        }

        private void nudSetModCurrent_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x12, ( byte )nudSetModCurrent_Ch1.Value, 0, 0xFF );
        }

        private void nudRiseFallTime_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x11, ( byte )nudRiseFallTime_Ch1.Value, 12, 0xF );
        }

        private void chkEnableBoost_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x11, GetByteFromBoolean( chkEnableBoost_Ch1.Checked ), 3, 1 );
        }

        private void chkEnableBoostRange_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x11, GetByteFromBoolean( chkEnableBoostRange_Ch1.Checked ), 4, 1 );
        }

        private void nudBoostAmont_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x11, ( byte )nudBoostAmont_Ch1.Value, 5, 7 );
        }

        private void nudBoostDelay_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0B, ( byte )nudBoostDelay_Ch1.Value, 13, 7 );
        }

        private void chkEnablePosiAsymBoost_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0B, GetByteFromBoolean( chkEnablePosiAsymBoost_Ch1.Checked ), 8, 1 );
        }

        private void chkEnableNegAsymBoost_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0B, GetByteFromBoolean( chkEnableNegAsymBoost_Ch1.Checked ), 9, 1 );
        }

        private void nudAsymBoostValue_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0B, ( byte )nudAsymBoostValue_Ch1.Value, 10, 7 );
        }

        private void chkEnablePrecursor_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x12, GetByteFromBoolean( chkEnablePrecursor_Ch1.Checked ), 8, 1 );
        }

        private void nudPrecursorValue_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x12, ( byte )nudPrecursorValue_Ch1.Value, 9, 7 );
        }

        private void chkCrossPointPolarity_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, GetByteFromBoolean( chkCrossPointPolarity_Ch1.Checked ), 11, 1 );
        }

        private void nudCrossPointValue_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, ( byte )nudCrossPointValue_Ch1.Value, 12, 0xF );
        }

        private void chkEnableJEQ_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x11, GetByteFromBoolean( chkEnableJEQ_Ch1.Checked ), 2, 1 );
        }

        private void nudJEQUpValue_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x11, ( byte )nudJEQUpValue_Ch1.Value, 8, 0xF );
        }

        private void nudJEQDownValue_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x14, ( byte )nudJEQDownValue_Ch1.Value, 4, 0xF );
        }

        private void chkJEQ_PredownTransition_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, GetByteFromBoolean( chkJEQ_PredownTransition_Ch1.Checked ), 0, 1 );
        }

        private void chkJEQ_PreupTransition_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, GetByteFromBoolean( chkJEQ_PreupTransition_Ch1.Checked ), 1, 1 );
        }

        private void chkRiseFallTimeIndependent_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x11, GetByteFromBoolean( chkRiseFallTimeIndependent_Ch1.Checked ), 1, 1 );
        }

        private void chkPolaritySwap_Ch1_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, GetByteFromBoolean( chkPolaritySwap_Ch1.Checked ), 8, 1 );
        }

        private void nudInputStageEquaSet_Ch1_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0A, ( byte )nudInputStageEquaSet_Ch1.Value, 9, 3 );
        }

        private void btnTurnOn_Ch1_Click( object sender, EventArgs e ) {
            TurnOnOffCh1( true );
        }

        private void btnTurnOff_Ch1_Click( object sender, EventArgs e ) {
            TurnOnOffCh1( false );
        }

        public void TurnOnOffCh1( bool state) {
            if( state ) {
                chkEnableRFStage_Ch1.Checked = true;
                nudSetModCurrent_Ch1.Value = 159;
                nudRiseFallTime_Ch1.Value = 15;
                chkEnableBoost_Ch1.Checked = true;
                chkEnableBoostRange_Ch1.Checked = true;
                nudBoostAmont_Ch1.Value = 7;
            }
            else {
                chkEnableRFStage_Ch1.Checked = false;
                nudSetModCurrent_Ch1.Value = 0;
                nudRiseFallTime_Ch1.Value = 0;
                chkEnableBoost_Ch1.Checked = false;
                chkEnableBoostRange_Ch1.Checked = false;
                nudBoostAmont_Ch1.Value = 0;
            }
            if( StatusReport != null )
                StatusReport( );
        }
        #endregion Channel 1

        #region Channel 2

        private void chkEnableRFStage_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, GetByteFromBoolean( chkEnableRFStage_Ch2.Checked ), 0, 1 );
        }

        private void nudSetModCurrent_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0D, ( byte )nudSetModCurrent_Ch2.Value, 8, 0xFF );
        }

        private void nudRiseFallTime_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0D, ( byte )nudRiseFallTime_Ch2.Value, 4, 0xF );
        }

        private void chkEnableBoost_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, GetByteFromBoolean( chkEnableBoost_Ch2.Checked ), 3, 1 );
        }

        private void chkEnableBoostRange_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, GetByteFromBoolean( chkEnableBoostRange_Ch2.Checked ), 4, 1 );
        }

        private void nudBoostAmont_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, ( byte )nudBoostAmont_Ch2.Value, 5, 7 );
        }

        private void nudBoostDelay_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0B, ( byte )nudBoostDelay_Ch2.Value, 5, 7 );
        }

        private void chkEnablePosiAsymBoost_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0B, GetByteFromBoolean( chkEnablePosiAsymBoost_Ch2.Checked ), 0, 1 );
        }

        private void chkEnableNegAsymBoost_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0B, GetByteFromBoolean( chkEnableNegAsymBoost_Ch2.Checked ), 1, 1 );
        }

        private void nudAsymBoostValue_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0B, ( byte )nudAsymBoostValue_Ch2.Value, 2, 7 );
        }

        private void chkEnablePrecursor_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0E, GetByteFromBoolean( chkEnablePrecursor_Ch2.Checked ), 0, 1 );
        }

        private void nudPrecursorValue_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0E, ( byte )nudPrecursorValue_Ch2.Value, 1, 7 );
        }

        private void chkCrossPointPolarity_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, GetByteFromBoolean( chkCrossPointPolarity_Ch2.Checked ), 11, 1 );
        }

        private void nudCrossPointValue_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, ( byte )nudCrossPointValue_Ch2.Value, 12, 0xF );
        }

        private void chkEnableJEQ_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, GetByteFromBoolean( chkEnableJEQ_Ch2.Checked ), 2, 1 );
        }

        private void nudJEQUpValue_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0D, ( byte )nudJEQUpValue_Ch2.Value, 0, 0xF );
        }

        private void nudJEQDownValue_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x14, ( byte )nudJEQDownValue_Ch2.Value, 0, 0xF );
        }

        private void chkJEQ_PredownTransition_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x15, GetByteFromBoolean( chkJEQ_PredownTransition_Ch2.Checked ), 6, 1 );
        }

        private void chkJEQ_PreupTransition_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x15, GetByteFromBoolean( chkJEQ_PreupTransition_Ch2.Checked ), 7, 1 );
        }
        
        private void chkPolaritySwap_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, GetByteFromBoolean( chkPolaritySwap_Ch2.Checked ), 8, 1 );
        }

        private void chkRiseFallTimeIndependent_Ch2_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, GetByteFromBoolean( chkRiseFallTimeIndependent_Ch2.Checked ), 1, 1 );
        }

        private void nudInputStageEquaSet_Ch2_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0C, ( byte )nudInputStageEquaSet_Ch2.Value, 9, 3 );
        }

        private void btnTurnOn_Ch2_Click( object sender, EventArgs e ) {
            TurnOnOffCh2( true );
        }

        private void btnTurnOff_Ch2_Click( object sender, EventArgs e ) {
            TurnOnOffCh2( false );
        }

        public void TurnOnOffCh2( bool state ) {
            if( state ) {
                chkEnableRFStage_Ch2.Checked = true;
                nudSetModCurrent_Ch2.Value = 159;
                nudRiseFallTime_Ch2.Value = 15;
                chkEnableBoost_Ch2.Checked = true;
                chkEnableBoostRange_Ch2.Checked = true;
                nudBoostAmont_Ch2.Value = 7;
            }
            else {
                chkEnableRFStage_Ch2.Checked = false;
                nudSetModCurrent_Ch2.Value = 0;
                nudRiseFallTime_Ch2.Value = 0;
                chkEnableBoost_Ch2.Checked = false;
                chkEnableBoostRange_Ch2.Checked = false;
                nudBoostAmont_Ch2.Value = 0;
            }
            if( StatusReport != null )
                StatusReport( );
        }
        #endregion Channel 2

        #region Channel 3

        private void chkEnableRFStage_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, GetByteFromBoolean( chkEnableRFStage_Ch3.Checked ), 8, 1 );
        }

        private void nudSetModCurrent_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x10, ( byte )nudSetModCurrent_Ch3.Value, 8, 0xFF );
        }

        private void nudRiseFallTime_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x10, ( byte )nudRiseFallTime_Ch3.Value, 4, 0xF );
        }

        private void chkEnableBoost_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, GetByteFromBoolean( chkEnableBoost_Ch3.Checked ), 11, 1 );
        }

        private void chkEnableBoostRange_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, GetByteFromBoolean( chkEnableBoostRange_Ch3.Checked ), 12, 1 );
        }

        private void nudBoostAmont_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, ( byte )nudBoostAmont_Ch3.Value, 13, 7 );
        }

        private void nudBoostDelay_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, ( byte )nudBoostDelay_Ch3.Value, 5, 7 );
        }

        private void chkEnablePosiAsymBoost_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, GetByteFromBoolean( chkEnablePosiAsymBoost_Ch3.Checked ), 0, 1 );
        }

        private void chkEnableNegAsymBoost_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, GetByteFromBoolean( chkEnableNegAsymBoost_Ch3.Checked ), 1, 1 );
        }

        private void nudAsymBoostValue_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, ( byte )nudAsymBoostValue_Ch3.Value, 2, 7 );
        }

        private void chkEnablePrecursor_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0E, GetByteFromBoolean( chkEnablePrecursor_Ch3.Checked ), 4, 1 );
        }

        private void nudPrecursorValue_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0E, ( byte )nudPrecursorValue_Ch3.Value, 5, 7 );
        }

        private void chkCrossPointPolarity_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0E, GetByteFromBoolean( chkCrossPointPolarity_Ch3.Checked ), 11, 1 );
        }

        private void nudCrossPointValue_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0E, ( byte )nudCrossPointValue_Ch3.Value, 12, 0xF );
        }

        private void chkEnableJEQ_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, GetByteFromBoolean( chkEnableJEQ_Ch3.Checked ), 10, 1 );
        }

        private void nudJEQUpValue_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x10, ( byte )nudJEQUpValue_Ch0.Value, 0, 0xF );
        }

        private void nudJEQDownValue_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x15, ( byte )nudJEQDownValue_Ch3.Value, 2, 0xF );
        }

        private void chkJEQ_PredownTransition_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x15, GetByteFromBoolean( chkJEQ_PredownTransition_Ch3.Checked ), 0, 1 );
        }

        private void chkJEQ_PreupTransition_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x15, GetByteFromBoolean( chkJEQ_PreupTransition_Ch3.Checked ), 1, 1 );
        }

        private void chkRiseFallTimeIndependent_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0F, GetByteFromBoolean( chkRiseFallTimeIndependent_Ch3.Checked ), 9, 1 );
        }

        private void chkPolaritySwap_Ch3_CheckedChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0E, GetByteFromBoolean( chkPolaritySwap_Ch3.Checked ), 8, 1 );
        }

        private void nudInputStageEquaSet_Ch3_ValueChanged( object sender, EventArgs e ) {
            Spi.WriteToDevice( 0x0E, ( byte )nudInputStageEquaSet_Ch3.Value, 9, 3 );
        }

        private void btnTurnOn_Ch3_Click( object sender, EventArgs e ) {
            TurnOnOffCh3( true );
        }

        private void btnTurnOff_Ch3_Click( object sender, EventArgs e ) {
            TurnOnOffCh3( false );
        }

        public void TurnOnOffCh3( bool state ) {
            if( state ) {
                chkEnableRFStage_Ch3.Checked = true;
                nudSetModCurrent_Ch3.Value = 159;
                nudRiseFallTime_Ch3.Value = 15;
                chkEnableBoost_Ch3.Checked = true;
                chkEnableBoostRange_Ch3.Checked = true;
                nudBoostAmont_Ch3.Value = 7;
            }
            else {
                chkEnableRFStage_Ch3.Checked = false;
                nudSetModCurrent_Ch3.Value = 0;
                nudRiseFallTime_Ch3.Value = 0;
                chkEnableBoost_Ch3.Checked = false;
                chkEnableBoostRange_Ch3.Checked = false;
                nudBoostAmont_Ch3.Value = 0;
            }
            if( StatusReport != null )
                StatusReport( );
        }
        #endregion Channel 3

        #region Member Data

        string currentFileName = "";
        private Hashtable htDataCollection;
        #endregion

        private void gboChannel_0_Enter(object sender, EventArgs e)
        {

        }

        #region [Parameter-Handling]
        private void btnSaveParameters_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void btnSaveAsParameters_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "*.xml|*.xml";
            saveDialog.RestoreDirectory = true;
            string fileFullName = "";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileFullName = saveDialog.FileName;
                SaveAsNewFile(fileFullName);
            }
        }

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            string fileFullName = "";
            // Set filter options and filter index.
            openDialog.Filter = "*.xml|*.xml";
            openDialog.Multiselect = false;
            openDialog.RestoreDirectory = true;

            // Process input if the user clicked OK.
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Open the selected file to read.
                fileFullName = openDialog.FileName;
                LoadFile(fileFullName);
            }

        }

        private void LoadFile(string fileFullName)
        {
            btnSaveParameters.Enabled = true;
            currentFileName = fileFullName;
            XmlDocument xDoc;
            xDoc = new XmlDocument();
            xDoc.Load(fileFullName);
            XmlNodeList nodeList = xDoc.SelectNodes("/DriverControl/ParameterList/Parameter");
            foreach (XmlNode xnode in nodeList)
            {
                string name = xnode.SelectSingleNode("Name").InnerText;
                int value = int.Parse(xnode.SelectSingleNode("Value").InnerText);
                Control ctr = (Control)htDataCollection[name];
                if (ctr.Name.Equals("chkSet2_6V"))
                {
                    CheckBox chk = (CheckBox)ctr;
                    chk.Checked = value == 1 ? true : false;
                }
                else if (ctr.Name.Equals("nudScalModule") || ctr.Name.Equals("D_JEQ_delay"))
                {
                    NumericUpDown updownNum = (NumericUpDown)ctr;
                    updownNum.Value = value;
                }


            }
            foreach (XmlNode xnode in nodeList)
            {
                string name = xnode.SelectSingleNode("Name").InnerText;
                int value = int.Parse(xnode.SelectSingleNode("Value").InnerText);
                Control ctr = (Control)htDataCollection[name];
                if (ctr is NumericUpDown)
                {
                    NumericUpDown updownNum = (NumericUpDown)ctr;
                    updownNum.Value = value;
                }
                else if (ctr is CheckBox)
                {
                    CheckBox chk = (CheckBox)ctr;
                    chk.Checked = value == 1 ? true : false;
                }
            }
            //btnReadPower_Click( null, null );
        }

        private void SaveFile()
        {
            SaveAsNewFile(currentFileName);
        }

        private void SaveAsNewFile(string fileFullName)
        {
            btnSaveParameters.Enabled = true;
            currentFileName = fileFullName;
            XmlDocument xDoc;
            xDoc = new XmlDocument();
            StringBuilder sb = new StringBuilder();
            int value = 0;
            sb.Append("<DriverControl><ParameterList>");

            foreach (DictionaryEntry de in htDataCollection)
            {
                NumericUpDown updownNum;
                CheckBox chk;

                if (de.Value is CheckBox)
                {
                    chk = (CheckBox)(de.Value);
                    value = chk.Checked == true ? 1 : 0;
                }
                else if (de.Value is NumericUpDown)
                {
                    updownNum = (NumericUpDown)(de.Value);
                    value = (int)updownNum.Value;
                }

                sb.Append(string.Format("<Parameter><Name>{0}</Name><Value>{1}</Value></Parameter>", de.Key, value));
            }
            sb.Append("</ParameterList></DriverControl>");
            xDoc.LoadXml(sb.ToString());
            xDoc.Save(fileFullName);
        }

        #endregion [Parameter-Handling]

        #region [Others]
        private void btnInit_DriverCtrl_Click(object sender, EventArgs e)
        {
            InitDriverCtrl();
        }

        public void InitDriverCtrl()
        {
            Spi = new Com_SPI();
            //btnPowerOff.Enabled = false;
            //btnPowerOn.Enabled = false;
            //btnReadPower.Enabled = false;
            BuiltControlData();
            btnSaveParameters.Enabled = false;
            bool bOK = false;
            bOK = Spi.InitSPI();
            btnCheckReading.Enabled = bOK;
            btnCheckReading.PerformClick();
            btnInit_DriverCtrl.Enabled = !bOK;
        }

        private void BuiltControlData()
        {
            htDataCollection = new Hashtable();
            DFBdatalist.Clear();
            htDataCollection.Add("D_dis_int_v2p6", chkSet2_6V);
            DFBdatalist.Add("D_dis_int_v2p6");
            htDataCollection.Add("D_mod_scale", nudScalModule);
            DFBdatalist.Add("D_mod_scale");
            htDataCollection.Add("D_JEQ_delay", nudJEQ_Delay);
            DFBdatalist.Add("D_JEQ_delay");
            //channel 0
            htDataCollection.Add("D_rf_en_ch0", chkEnableRFStage_Ch0);
            DFBdatalist.Add("D_rf_en_ch0");
            htDataCollection.Add("D_bimod_ch0", nudSetModCurrent_Ch0);
            DFBdatalist.Add("D_bimod_ch0");
            htDataCollection.Add("D_grisefall_ch0", nudRiseFallTime_Ch0);
            DFBdatalist.Add("D_grisefall_ch0");
            htDataCollection.Add("D_en_boost_ch0", chkEnableBoost_Ch0);
            DFBdatalist.Add("D_en_boost_ch0");
            htDataCollection.Add("D_boost_range_hi_ch0", chkEnableBoostRange_Ch0);
            DFBdatalist.Add("D_boost_range_hi_ch0");
            htDataCollection.Add("D_gboost_ch0", nudBoostAmont_Ch0);
            DFBdatalist.Add("D_gboost_ch0");
            htDataCollection.Add("D_gboostdly_ch0", nudBoostDelay_Ch0);
            DFBdatalist.Add("D_gboostdly_ch0");
            htDataCollection.Add("D_pos_asym_ch0", chkEnablePosiAsymBoost_Ch0);
            DFBdatalist.Add("D_pos_asym_ch0");
            htDataCollection.Add("D_neg_asym_ch0", chkEnableNegAsymBoost_Ch0);
            DFBdatalist.Add("D_neg_asym_ch0");
            htDataCollection.Add("D_gasym_ch0", nudAsymBoostValue_Ch0);
            DFBdatalist.Add("D_gasym_ch0");
            htDataCollection.Add("D_en_precursor_ch0", chkEnablePrecursor_Ch0);
            DFBdatalist.Add("D_en_precursor_ch0");
            htDataCollection.Add("D_gprecursor_ch0", nudPrecursorValue_Ch0);
            DFBdatalist.Add("D_gprecursor_ch0");
            htDataCollection.Add("D_xpoint_pol_ch0", chkCrossPointPolarity_Ch0);
            DFBdatalist.Add("D_xpoint_pol_ch0");
            htDataCollection.Add("D_gxpoint_ch0", nudCrossPointValue_Ch0);
            DFBdatalist.Add("D_gxpoint_ch0");

            htDataCollection.Add("D_en_JEQ_ch0", chkEnableJEQ_Ch0);
            DFBdatalist.Add("D_en_JEQ_ch0");
            htDataCollection.Add("D_JEQ_up_ch0", nudJEQUpValue_Ch0);
            DFBdatalist.Add("D_JEQ_up_ch0");
            htDataCollection.Add("D_JEQ_down_ch0", nudJEQDownValue_Ch0);
            DFBdatalist.Add("D_JEQ_down_ch0");
            htDataCollection.Add("D_JEQ_PU_ch0", chkJEQ_PreupTransition_Ch0);
            DFBdatalist.Add("D_JEQ_PU_ch0");
            htDataCollection.Add("D_JEQ_PD_ch0", chkJEQ_PredownTransition_Ch0);
            DFBdatalist.Add("D_JEQ_PD_ch0");

            htDataCollection.Add("D_en_rft_ind_of_mod_ch0", chkRiseFallTimeIndependent_Ch0);
            DFBdatalist.Add("D_en_rft_ind_of_mod_ch0");
            htDataCollection.Add("D_pol_flip_ch0", chkPolaritySwap_Ch0);
            DFBdatalist.Add("D_pol_flip_ch0");
            htDataCollection.Add("D_fr4eq_ch0", nudInputStageEquaSet_Ch0);
            DFBdatalist.Add("D_fr4eq_ch0");
            //channel 1
            htDataCollection.Add("D_rf_en_ch1", chkEnableRFStage_Ch1);
            DFBdatalist.Add("D_rf_en_ch1");
            htDataCollection.Add("D_bimod_ch1", nudSetModCurrent_Ch1);
            DFBdatalist.Add("D_bimod_ch1");
            htDataCollection.Add("D_grisefall_ch1", nudRiseFallTime_Ch1);
            DFBdatalist.Add("D_grisefall_ch1");
            htDataCollection.Add("D_en_boost_ch1", chkEnableBoost_Ch1);
            DFBdatalist.Add("D_en_boost_ch1");
            htDataCollection.Add("D_boost_range_hi_ch1", chkEnableBoostRange_Ch1);
            DFBdatalist.Add("D_boost_range_hi_ch1");
            htDataCollection.Add("D_gboost_ch1", nudBoostAmont_Ch1);
            DFBdatalist.Add("D_gboost_ch1");
            htDataCollection.Add("D_gboostdly_ch1", nudBoostDelay_Ch1);
            DFBdatalist.Add("D_gboostdly_ch1");
            htDataCollection.Add("D_pos_asym_ch1", chkEnablePosiAsymBoost_Ch1);
            DFBdatalist.Add("D_pos_asym_ch1");
            htDataCollection.Add("D_neg_asym_ch1", chkEnableNegAsymBoost_Ch1);
            DFBdatalist.Add("D_neg_asym_ch1");
            htDataCollection.Add("D_gasym_ch1", nudAsymBoostValue_Ch1);
            DFBdatalist.Add("D_gasym_ch1");
            htDataCollection.Add("D_en_precursor_ch1", chkEnablePrecursor_Ch1);
            DFBdatalist.Add("D_en_precursor_ch1");
            htDataCollection.Add("D_gprecursor_ch1", nudPrecursorValue_Ch1);
            DFBdatalist.Add("D_gprecursor_ch1");
            htDataCollection.Add("D_xpoint_pol_ch1", chkCrossPointPolarity_Ch1);
            DFBdatalist.Add("D_xpoint_pol_ch1");
            htDataCollection.Add("D_gxpoint_ch1", nudCrossPointValue_Ch1);
            DFBdatalist.Add("D_gxpoint_ch1");


            htDataCollection.Add("D_en_JEQ_ch1", chkEnableJEQ_Ch1);
            DFBdatalist.Add("D_en_JEQ_ch1");
            htDataCollection.Add("D_JEQ_up_ch1", nudJEQUpValue_Ch1);
            DFBdatalist.Add("D_JEQ_up_ch1");
            htDataCollection.Add("D_JEQ_down_ch1", nudJEQDownValue_Ch1);
            DFBdatalist.Add("D_JEQ_down_ch1");
            htDataCollection.Add("D_JEQ_PU_ch1", chkJEQ_PreupTransition_Ch1);
            DFBdatalist.Add("D_JEQ_PU_ch1");
            htDataCollection.Add("D_JEQ_PD_ch1", chkJEQ_PredownTransition_Ch1);
            DFBdatalist.Add("D_JEQ_PD_ch1");

            htDataCollection.Add("D_en_rft_ind_of_mod_ch1", chkRiseFallTimeIndependent_Ch1);
            DFBdatalist.Add("D_en_rft_ind_of_mod_ch1");
            htDataCollection.Add("D_pol_flip_ch1", chkPolaritySwap_Ch1);
            DFBdatalist.Add("D_pol_flip_ch1");
            htDataCollection.Add("D_fr4eq_ch1", nudInputStageEquaSet_Ch1);
            DFBdatalist.Add("D_fr4eq_ch1");
            //channel 2
            htDataCollection.Add("D_rf_en_ch2", chkEnableRFStage_Ch2);
            DFBdatalist.Add("D_rf_en_ch2");
            htDataCollection.Add("D_bimod_ch2", nudSetModCurrent_Ch2);
            DFBdatalist.Add("D_bimod_ch2");
            htDataCollection.Add("D_grisefall_ch2", nudRiseFallTime_Ch2);
            DFBdatalist.Add("D_grisefall_ch2");
            htDataCollection.Add("D_en_boost_ch2", chkEnableBoost_Ch2);
            DFBdatalist.Add("D_en_boost_ch2");
            htDataCollection.Add("D_boost_range_hi_ch2", chkEnableBoostRange_Ch2);
            DFBdatalist.Add("D_boost_range_hi_ch2");
            htDataCollection.Add("D_gboost_ch2", nudBoostAmont_Ch2);
            DFBdatalist.Add("D_gboost_ch2");
            htDataCollection.Add("D_gboostdly_ch2", nudBoostDelay_Ch2);
            DFBdatalist.Add("D_gboostdly_ch2");
            htDataCollection.Add("D_pos_asym_ch2", chkEnablePosiAsymBoost_Ch2);
            DFBdatalist.Add("D_pos_asym_ch2");
            htDataCollection.Add("D_neg_asym_ch2", chkEnableNegAsymBoost_Ch2);
            DFBdatalist.Add("D_neg_asym_ch2");
            htDataCollection.Add("D_gasym_ch2", nudAsymBoostValue_Ch2);
            DFBdatalist.Add("D_gasym_ch2");
            htDataCollection.Add("D_en_precursor_ch2", chkEnablePrecursor_Ch2);
            DFBdatalist.Add("D_en_precursor_ch2");
            htDataCollection.Add("D_gprecursor_ch2", nudPrecursorValue_Ch2);
            DFBdatalist.Add("D_gprecursor_ch2");
            htDataCollection.Add("D_xpoint_pol_ch2", chkCrossPointPolarity_Ch2);
            DFBdatalist.Add("D_xpoint_pol_ch2");
            htDataCollection.Add("D_gxpoint_ch2", nudCrossPointValue_Ch2);
            DFBdatalist.Add("D_gxpoint_ch2");

            htDataCollection.Add("D_en_JEQ_ch2", chkEnableJEQ_Ch2);
            DFBdatalist.Add("D_en_JEQ_ch2");
            htDataCollection.Add("D_JEQ_up_ch2", nudJEQUpValue_Ch2);
            DFBdatalist.Add("D_JEQ_up_ch2");
            htDataCollection.Add("D_JEQ_down_ch2", nudJEQDownValue_Ch2);
            DFBdatalist.Add("D_JEQ_down_ch2");
            htDataCollection.Add("D_JEQ_PU_ch2", chkJEQ_PreupTransition_Ch2);
            DFBdatalist.Add("D_JEQ_PU_ch2");
            htDataCollection.Add("D_JEQ_PD_ch2", chkJEQ_PredownTransition_Ch2);
            DFBdatalist.Add("D_JEQ_PD_ch2");

            htDataCollection.Add("D_en_rft_ind_of_mod_ch2", chkRiseFallTimeIndependent_Ch2);
            DFBdatalist.Add("D_en_rft_ind_of_mod_ch2");
            htDataCollection.Add("D_pol_flip_ch2", chkPolaritySwap_Ch2);
            DFBdatalist.Add("D_pol_flip_ch2");
            htDataCollection.Add("D_fr4eq_ch2", nudInputStageEquaSet_Ch2);
            DFBdatalist.Add("D_fr4eq_ch2");
            //channel 3
            htDataCollection.Add("D_rf_en_ch3", chkEnableRFStage_Ch3);
            DFBdatalist.Add("D_rf_en_ch3");
            htDataCollection.Add("D_bimod_ch3", nudSetModCurrent_Ch3);
            DFBdatalist.Add("D_bimod_ch3");
            htDataCollection.Add("D_grisefall_ch3", nudRiseFallTime_Ch3);
            DFBdatalist.Add("D_grisefall_ch3");
            htDataCollection.Add("D_en_boost_ch3", chkEnableBoost_Ch3);
            DFBdatalist.Add("D_en_boost_ch3");
            htDataCollection.Add("D_boost_range_hi_ch3", chkEnableBoostRange_Ch3);
            DFBdatalist.Add("D_boost_range_hi_ch3");
            htDataCollection.Add("D_gboost_ch3", nudBoostAmont_Ch3);
            DFBdatalist.Add("D_gboost_ch3");
            htDataCollection.Add("D_gboostdly_ch3", nudBoostDelay_Ch3);
            DFBdatalist.Add("D_gboostdly_ch3");
            htDataCollection.Add("D_pos_asym_ch3", chkEnablePosiAsymBoost_Ch3);
            DFBdatalist.Add("D_pos_asym_ch3");
            htDataCollection.Add("D_neg_asym_ch3", chkEnableNegAsymBoost_Ch3);
            DFBdatalist.Add("D_neg_asym_ch3");
            htDataCollection.Add("D_gasym_ch3", nudAsymBoostValue_Ch3);
            DFBdatalist.Add("D_gasym_ch3");
            htDataCollection.Add("D_en_precursor_ch3", chkEnablePrecursor_Ch3);
            DFBdatalist.Add("D_en_precursor_ch3");
            htDataCollection.Add("D_gprecursor_ch3", nudPrecursorValue_Ch3);
            DFBdatalist.Add("D_gprecursor_ch3");
            htDataCollection.Add("D_xpoint_pol_ch3", chkCrossPointPolarity_Ch3);
            DFBdatalist.Add("D_xpoint_pol_ch3");
            htDataCollection.Add("D_gxpoint_ch3", nudCrossPointValue_Ch3);
            DFBdatalist.Add("D_gxpoint_ch3");

            htDataCollection.Add("D_en_JEQ_ch3", chkEnableJEQ_Ch3);
            DFBdatalist.Add("D_en_JEQ_ch3");
            htDataCollection.Add("D_JEQ_up_ch3", nudJEQUpValue_Ch3);
            DFBdatalist.Add("D_JEQ_up_ch3");
            htDataCollection.Add("D_JEQ_down_ch3", nudJEQDownValue_Ch3);
            DFBdatalist.Add("D_JEQ_down_ch3");
            htDataCollection.Add("D_JEQ_PU_ch3", chkJEQ_PreupTransition_Ch3);
            DFBdatalist.Add("D_JEQ_PU_ch3");
            htDataCollection.Add("D_JEQ_PD_ch3", chkJEQ_PredownTransition_Ch3);
            DFBdatalist.Add("D_JEQ_PD_ch3");

            htDataCollection.Add("D_en_rft_ind_of_mod_ch3", chkRiseFallTimeIndependent_Ch3);
            DFBdatalist.Add("D_en_rft_ind_of_mod_ch3");
            htDataCollection.Add("D_pol_flip_ch3", chkPolaritySwap_Ch3);
            DFBdatalist.Add("D_pol_flip_ch3");
            htDataCollection.Add("D_fr4eq_ch3", nudInputStageEquaSet_Ch3);
            DFBdatalist.Add("D_fr4eq_ch3");
        }

        public void btnCheckReading_Click(object sender, EventArgs e)
        {
            pnlOperation.Enabled = Spi.VerifyVersion();
        }

        private void chkSet2_6V_CheckedChanged(object sender, EventArgs e)
        {
            Spi.WriteToDevice(0x15, GetByteFromBoolean(chkSet2_6V.Checked), 2, 1);
        }

        private void nudScalModule_ValueChanged(object sender, EventArgs e)
        {
            Spi.WriteToDevice(0x16, (byte)nudScalModule.Value, 2, 7);
        }
        private void nudJEQ_Delay_ValueChanged(object sender, EventArgs e)
        {
            Spi.WriteToDevice(0x15, (byte)nudJEQ_Delay.Value, 5, 7);
        }

        private void btnTurnOnAll_Click(object sender, EventArgs e)
        {
            chkSet2_6V.Checked = true;
            nudScalModule.Value = 7;
            TurnOnOffCh0(true);
            TurnOnOffCh1(true);
            TurnOnOffCh2(true);
            TurnOnOffCh3(true);
        }

        private void btnTurnOffAll_Click(object sender, EventArgs e)
        {
            nudScalModule.Value = 0;
            chkSet2_6V.Checked = false;
            TurnOnOffCh0(false);
            TurnOnOffCh1(false);
            TurnOnOffCh2(false);
            TurnOnOffCh3(false);

            pnlOperation.Enabled = false;

        }

        private byte GetByteFromBoolean(bool bValue)
        {
            return (byte)(bValue == true ? 1 : 0);
        }

        public ArrayList GetDFBDatalist
        {
            get { return DFBdatalist; }
        }

        public Hashtable CtrlDataCollection
        {
            get { return htDataCollection; }
        }

        #endregion [Others]
    }
}
