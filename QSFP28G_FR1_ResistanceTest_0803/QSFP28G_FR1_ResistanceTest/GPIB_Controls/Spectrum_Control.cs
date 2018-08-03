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

namespace Finisar.GPIB_Controls {
    public partial class Spectrum_Control : UserControl {
        
        public delegate void InstrumentEventHandler( object sender );
        public event InstrumentEventHandler OSA_OperationCompleted;

        public Finisar.Ag86140B Spectrum_OSA;
        //Finisar.AnAQ6315 Spectrum_OSA;
        List<int> allowedNumberOfTracePoints;
        List<double> allowedRBW;
        List<double> allowedSensitivities;

        //private Finisar.AlignMode control_AlignMode;
        //private Finisar.AlignMode control_PreviousAlignMode;

        public float[ ] result_OSAWavelengthLimits;
        public float[ ] result_OSAPowerLimits;
        public float[ ] result_SMSRLimits;

        private double result_OSAActualPower;
        private float result_OSAWavelength;
        private float result_OSAPower;
        private float result_SMSR;
        private double result_ModeOffset;
        private double result_StopBand;
        private double result_CenterOffset;
        private double result_PeakAmplitude;
        private double result_Bandwidth;
        private float secondResult_OSAWavelength;
        private float secondResult_SMSR;
        private double secondResult_ModeOffset;
        private double osa_Poweroffset;
        public Finisar.Ag86140BSettings preAlignSettings;
        public Hashtable htChannelMeasure;
        private Finisar.OSASpectrumTrace result_OSASweep;
        private byte GpibAddress = 23;
        
        public byte GPIB_Address {
            get { return GpibAddress; }
            set {
                GpibAddress = value;
            }
        }
        
        public int CurrentChannel
        { 
            get; 
            set; 
        }
        
        public Spectrum_Control( ) {
            InitializeComponent( );
        }

        public bool Initialization( ) {
            bool retValue = false;
            Spectrum_OSA = new Finisar.Ag86140B( GPIB_Address );
            //Spectrum_OSA = new Finisar.AnAQ6315( GPIB_Address );
            if( Spectrum_OSA != null ) {
                result_OSAWavelengthLimits = new float[ 2 ] { 1200.00f, 1400.00f };
                result_OSAPowerLimits = new float[ 2 ] { -100.0f, 100.0f };
                result_SMSRLimits = new float[ 2 ] { 0, 100 };

                result_OSAWavelength = float.NaN;
                result_OSAPower = float.NaN;
                result_SMSR = float.NaN;
                result_ModeOffset = double.NaN;
                result_StopBand = double.NaN;
                result_CenterOffset = double.NaN;
                result_PeakAmplitude = double.NaN;
                result_Bandwidth = double.NaN;
                secondResult_ModeOffset = double.NaN;
                secondResult_OSAWavelength = float.NaN;
                secondResult_SMSR = float.NaN;

                result_OSASweep = new Finisar.OSASpectrumTrace( );

                allowedNumberOfTracePoints = new List<int> { 1001, 2001, 5001, 10001 };
                allowedSensitivities = new List<double> { -80, -70, -60, -50, -40, -30 };
                allowedRBW = new List<double> { 0.06, 0.1, 0.2, 0.5, 1.0, 2.0, 5.0 };

                //control_AlignMode = control_PreviousAlignMode = Finisar.AlignMode.OFF;
                BuildChannelMeasure();
                preAlignSettings = new Finisar.Ag86140BSettings( );
                btnInitSpec.Enabled = false;
                btnSpec_Measure.Enabled = true;
                retValue = true;
            }
            return retValue;
        }

        private void BuildChannelMeasure()
        {
            htChannelMeasure = new Hashtable();
            htChannelMeasure.Add("Ch0", new SpectrumMeasure(1293.0f, 1297.5f, 1295.56f, (float) GetPowerOffset()));
            htChannelMeasure.Add("Ch1", new SpectrumMeasure(1297.5f, 1302.5f, 1300.05f, (float)GetPowerOffset()));
            htChannelMeasure.Add("Ch2", new SpectrumMeasure(1302.5f, 1304.58f, 1304.59f, (float)GetPowerOffset()));
            htChannelMeasure.Add("Ch3", new SpectrumMeasure(1306.0f, 1311.14f, 1309.14f, (float)GetPowerOffset()));
        }
        
        private void btnInitSpec_Click( object sender, EventArgs e ) {
            Initialization( );
        }

        private void btnSpec_Measure_Click( object sender, EventArgs e ) {
           
            DoOverAllMeasurement( );
        }


        private void chkMeasureAllChannels_CheckedChanged(object sender, EventArgs e)
        {
            EnableAllChMeasurement = chkMeasureAllChannels.Checked;
        }

        public void DoOverAllMeasurement( ) {
            ApplyOSAMeasureAll( );

            wavelengthDataLabel.Text = float.IsNaN( Result_OSAWavelength ) ? "----" : Result_OSAWavelength.ToString( "0.000" );
            SMSRDataLabel.Text = float.IsNaN( Result_SMSR ) ? "----" : Result_SMSR.ToString( "0.00" );
            ModeOffsetDataLabel.Text = double.IsNaN( Result_ModeOffset ) ? "----" : Result_ModeOffset.ToString( "0.00" );
            PeakPowerLabel.Text = double.IsNaN( Result_PeakAmplitude ) ? "----" : Result_PeakAmplitude.ToString( "0.00" );
            ActualPowerLabel.Text = GetActualPower( ).ToString( "0.00" );
            if (EnableAllChMeasurement == false)
            {
                SMSR2DataLabel.Text = double.IsNaN(SecondResult_SMSR) ? "----" : SecondResult_SMSR.ToString("0.00");
                wavelength2DataLabel.Text = double.IsNaN(SecondResult_Wavelength) ? "----" : SecondResult_Wavelength.ToString("0.000");
                ModeOffset2DataLabel.Text = double.IsNaN(SecondResult_ModeOffset) ? "----" : SecondResult_ModeOffset.ToString("0.00");
            }
            System.Windows.Forms.Application.DoEvents( );
            FireOverAllMeasurementCompleted( );
        }

        private double GetActualPower( ) {
            result_OSAActualPower = result_PeakAmplitude + GetPowerOffset();
            return result_OSAActualPower;
        }

        private void FireOverAllMeasurementCompleted( ) {
            if( OSA_OperationCompleted != null )
                OSA_OperationCompleted( this );
        }
        private void FireOSAResultDataChanged( ) {
            
        }

        public double GetPowerOffset( ) {
            osa_Poweroffset = double.Parse( txtPowerOffset.Text );
            return osa_Poweroffset;
        }

        #region [ OSA Handling ]

        #region [ OSA Properties ]

        public double Result_OSAActualPower {
            get { return result_OSAActualPower; }
        }

        public float Result_OSAWavelength {
            get { return result_OSAWavelength; }
            set {
                if( value == result_OSAWavelength )
                    return;

                if( value >= result_OSAWavelengthLimits[ 0 ] && value <= result_OSAWavelengthLimits[ 1 ] ) {
                    result_OSAWavelength = value;
                }
                else {
                    result_OSAWavelength = float.NaN;
                }
                FireOSAResultDataChanged( );
            }
        }
        public float Result_OSAPower {
            get { return result_OSAPower; }
            set {
                if( value == result_OSAPower )
                    return;

                if( value >= result_OSAPowerLimits[ 0 ] && value <= result_OSAPowerLimits[ 1 ] ) {
                    result_OSAPower = value;
                }
                else {
                    result_OSAPower = float.NaN;
                }
                FireOSAResultDataChanged( );
            }
        }
        public float Result_SMSR {
            get { return result_SMSR; }
            set {
                if( value == result_SMSR )
                    return;

                if( value >= result_SMSRLimits[ 0 ] && value <= result_SMSRLimits[ 1 ] ) {
                    result_SMSR = value;
                    
                }
                else {
                    result_SMSR = -1;
                }
                FireOSAResultDataChanged( );
            }
        }

        public double Result_ModeOffset {
            get { return result_ModeOffset; }
        }

        public double Result_StopBand {
            get { return result_StopBand; }
        }

        public double Result_CenterOffset {
            get { return result_CenterOffset; }
        }

        public double Result_PeakAmplitude {
            get { return result_PeakAmplitude; }
        }

        public double Result_Bandwidth {
            get { return result_Bandwidth; }
        }

        public float SecondResult_Wavelength {
            get {
                
                return secondResult_OSAWavelength; 
            }
        }

        public float SecondResult_SMSR {
            get
            {
                if (secondResult_SMSR > 60F)
                {
                    secondResult_SMSR = 60F;
                }
            return secondResult_SMSR; }
        }

        public double SecondResult_ModeOffset {
            get { return secondResult_ModeOffset; }
        }

        public Finisar.OSASpectrumTrace Result_OSASweep {
            get { return result_OSASweep; }
        }

        public bool EnableAllChMeasurement
        {
            get { return chkMeasureAllChannels.Checked; }
            set {
                chkMeasureAllChannels.Checked = value;
                SMSR2DataLabel.Visible = !value;
                wavelength2DataLabel.Visible = !value;
                ModeOffset2DataLabel.Visible = !value;
                Validate();
            }
        }
        #endregion

        public void ApplyOSAMeasureAll( ) {
            
            try {
                DateTime startMeas = DateTime.UtcNow;
                SetAlignMode( true );

                Spectrum_OSA.PerformSingleSweep( );

                if (EnableAllChMeasurement) // All channel's ON
                {
                    // just measure secleted channel
                    SpectrumMeasure sm = (SpectrumMeasure)htChannelMeasure["Ch" + CurrentChannel.ToString()];
                    if (sm != null)
                    {
                        Spectrum_OSA.StartWavelength = sm.StartWavelength;
                        Spectrum_OSA.StopWavelength = sm.StopWavelength;
                        Spectrum_OSA.CenterWavelength = sm.CenterWavelength;
                        Spectrum_OSA.SpanWavelength = 5.2f;
                        Spectrum_OSA.PerformSingleSweep();
                        Thread.Sleep(2000);
                        GetMeasureResult("Ch" + CurrentChannel.ToString());
                        Thread.Sleep(1000);
                    }
                    // don't measure 4 of them.
                    //for (int i = 0; i < 4; i++)
                    //{
                    //    SpectrumMeasure sm = (SpectrumMeasure)htChannelMeasure["Ch" + i.ToString()];
                    //    if (sm != null)
                    //    {
                    //        Spectrum_OSA.StartWavelength = sm.StartWavelength;
                    //        Spectrum_OSA.StopWavelength = sm.StopWavelength;
                    //        Spectrum_OSA.CenterWavelength = sm.CenterWavelength;
                    //        Spectrum_OSA.SpanWavelength = 5.2f;
                    //        Spectrum_OSA.PerformSingleSweep();
                    //        Thread.Sleep(2000);
                    //        GetMeasureResult("Ch" + i.ToString());
                    //        Thread.Sleep(1000);
                    //    }

                    //}
                }
                else // just one channel ON.
                {
                    GetMeasureResult(true);

                    SetAlignMode(false);
                    Spectrum_OSA.PerformSingleSweep();

                    GetMeasureResult(false);
                }
                FireOSAResultDataChanged( );
            }
            catch( Exception ex ) {
                throw new Exception( "MeasureAll ex=" + ex.ToString( ) );
            }
            finally {
            }
        }

        private void GetMeasureResult( bool isFirst ) {
            if( isFirst ) {
                Result_OSAWavelength = ( float )Spectrum_OSA.GetPeakWavelength( );
                Result_SMSR = ( float )Spectrum_OSA.GetSmsr( );
                result_ModeOffset = Spectrum_OSA.GetModeOffset( );
                result_PeakAmplitude = Spectrum_OSA.GetPeakPower( );
            }
            else {
                secondResult_OSAWavelength = ( float )Spectrum_OSA.GetPeakWavelength( );
                secondResult_SMSR = ( float )Spectrum_OSA.GetSmsr( );
                secondResult_ModeOffset = Spectrum_OSA.GetModeOffset( );
            }
        }

        private void GetMeasureResult(string channelName)
        {
            Result_OSAWavelength = (float)Spectrum_OSA.GetPeakWavelength();
            Result_SMSR = (float)Spectrum_OSA.GetSmsr();
            result_ModeOffset = Spectrum_OSA.GetModeOffset();
            result_PeakAmplitude = Spectrum_OSA.GetPeakPower();
            
            SpectrumMeasure sm = (SpectrumMeasure)htChannelMeasure[channelName];
            if (sm != null)
            {
                sm.PeakWavelength = Result_OSAWavelength;
                sm.Smsr = Result_SMSR;
                sm.ModeOffset = (float) result_ModeOffset;
                sm.PeakAmplitude = (float) result_PeakAmplitude;
            }
        }

        public override string ToString( ) {
            return "OSA";
        }

        /// <summary>
        /// Set the OSA peak to center, span = 0nm, RBW = 2nm, and scale according to the coarse/fine mode setting
        /// </summary>
        public void SetAlignMode( bool isFirstMeasure ) {

            if( isFirstMeasure ) {
                WideRangMeasurment();
            }
            else {

                Spectrum_OSA.SetPeak2Center( true );
                Thread.Sleep( 2000 );
                Spectrum_OSA.SpanWavelength = 5.0f;
            }
            //SetStateDescription( "Setting vertical scale..." );
            //float vScale = control_AlignMode == AlignMode.COARSE ? 10f : 2f;
            //Spectrum_OSA.VerticalScale = vScale;
            
            //control_PreviousAlignMode = control_AlignMode;

        }

        public void WideRangMeasurment()
        {
            Spectrum_OSA.ResolutionBandwidth = preAlignSettings.ResolutionBandwidth;
            Spectrum_OSA.StartWavelength = 1285;
            Spectrum_OSA.StopWavelength = 1325;
            Spectrum_OSA.CenterWavelength = preAlignSettings.CenterWavelength;
            Spectrum_OSA.SpanWavelength = preAlignSettings.SpanWavelength;
            Spectrum_OSA.ReferenceLevel = preAlignSettings.ReferenceLevel;

            Spectrum_OSA.Sensitivity = preAlignSettings.Sensitivity;
            Spectrum_OSA.VideoBandwidthMode = Finisar.Ag86140BVideoBandwidthMode.MANUAL;
            Spectrum_OSA.VideoBandwidth = preAlignSettings.VideoBandwidth;
            Spectrum_OSA.SweepMode = preAlignSettings.SweepMode;
        }

        public void SingleChannelMeasurement( float starWl, float stropWl, float centerWl)
        {
            Spectrum_OSA.ResolutionBandwidth = preAlignSettings.ResolutionBandwidth;
            Spectrum_OSA.StartWavelength = starWl;
            Spectrum_OSA.StopWavelength = stropWl;
            Spectrum_OSA.CenterWavelength = centerWl;
            Spectrum_OSA.SpanWavelength = 4.5f;
            Spectrum_OSA.ReferenceLevel = preAlignSettings.ReferenceLevel;

            Spectrum_OSA.Sensitivity = preAlignSettings.Sensitivity;
            Spectrum_OSA.VideoBandwidthMode = Finisar.Ag86140BVideoBandwidthMode.MANUAL;
            Spectrum_OSA.VideoBandwidth = preAlignSettings.VideoBandwidth;
            Spectrum_OSA.SweepMode = preAlignSettings.SweepMode;
        }

        private void SetPeakCenter( ) {
            Spectrum_OSA.SetPeak2Center( true );
        }

        public void SaveOSASweep( ) {
            if( Result_OSASweep.points == null || Result_OSASweep.points.Count == 0 ) {
                throw new Exception( "No sweep to save." );
            }
            StreamWriter streamWriter = null;

            try {
                SaveFileDialog sfd = new SaveFileDialog( );
                sfd.DefaultExt = ".csv";
                sfd.InitialDirectory = Directory.GetCurrentDirectory( );
                sfd.Filter = "Comma separated files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.RestoreDirectory = true;

                if( sfd.ShowDialog( ) == DialogResult.OK ) {
                    streamWriter = new StreamWriter( sfd.FileName );
                    streamWriter.WriteLine( "TYPE,TRACE,A" );
                    streamWriter.WriteLine( );
                    streamWriter.WriteLine( "DATE & TIME," + DateTime.UtcNow.ToString( ) );
                    streamWriter.WriteLine( "INSTRUMENT," + Spectrum_OSA.GetType( ) );
                    streamWriter.WriteLine( "AIR/VACUUM/STP,VACUUM" );
                    streamWriter.WriteLine( );
                    streamWriter.WriteLine( "TRACE,A" );
                    streamWriter.WriteLine( "START,1285" );  //setting_StartWavelength.ToString( "0.000" ) );
                    streamWriter.WriteLine( "STOP,1325" ); // + setting_StopWavelength.ToString( "0.000" ) );
                    streamWriter.WriteLine( "HORIZONTAL SCALE,nm" );
                    streamWriter.WriteLine( "LENGTH (pts)," + preAlignSettings.NrOfTracePoints );// setting_NumberOfTracePoints );
                    streamWriter.WriteLine( "RBW (nm)," + preAlignSettings.ResolutionBandwidth.ToString( "0.000" ) );
                    streamWriter.WriteLine( "VBW (Hz)," + preAlignSettings.VideoBandwidth.ToString( "0.00" ) );
                    streamWriter.WriteLine( );
                    streamWriter.WriteLine( "REFERENCE LEVEL (dBm)," + Spectrum_OSA.ReferenceLevel.ToString( "0.000" ) );
                    //streamWriter.WriteLine( "VERTICAL SCALE (dBm)," + Spectrum_OSA.VerticalScale.ToString( "0.00" ) );
                    streamWriter.WriteLine( "SENSITIVITY (dBm)," + preAlignSettings.Sensitivity.ToString( "0.00" ) );
                    streamWriter.WriteLine( );
                    streamWriter.WriteLine( "AVERAGING,OFF" );
                    streamWriter.WriteLine( "MIN,OFF" );
                    streamWriter.WriteLine( "MAX,OFF" );
                    streamWriter.WriteLine( "SMOOTHING,OFF" );
                    streamWriter.WriteLine( "TRACE MATH,OFF" );
                    streamWriter.WriteLine( "OFFSET (dB)," );
                    streamWriter.WriteLine( "" );
                    streamWriter.WriteLine( "INDEX,A" );

                    for( int index = 0; index < result_OSASweep.points.Count; index++ )
                        streamWriter.WriteLine( index + "," + result_OSASweep.points[ index ] );
                }
            }
            catch( Exception ) {
                throw new Exception( "Failed writing OSA sweep to file" );
            }
            finally {
                streamWriter.Close( );
            }
        }

        #endregion


    }
}

    public class SpectrumMeasure
    {
        public float StartWavelength;
        public float StopWavelength;
        public float CenterWavelength;
        public float PeakWavelength;
        public float Smsr;
        public float ModeOffset;
        public float PeakAmplitude;
        public float PowerOffset;

        public SpectrumMeasure(float startWl, float stopWl, float centerWl, float powerOffset)
        {
            StartWavelength = startWl;
            StopWavelength = stopWl;
            CenterWavelength = centerWl;
        }
        public float PowerWithOffset
        {
            get { return PeakAmplitude + PowerOffset; }
        }
    }
