using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Finisar.GPIB_Controls {
    public partial class DCA_Control : UserControl {

        public delegate void StatusReport_EventHandler( string msg );
        public event StatusReport_EventHandler StateChanged;

        public delegate void InstrumentEventHandler( object sender );
        public event InstrumentEventHandler DCA_OperationCompleted;
        public event InstrumentEventHandler ScreenImageChanged;
        private byte GpibAddress = 7 ;
        private int CurrentChannel = 2;
        Finisar.Ag86100C DCA_ctrl;

        #region [ Oscilloscope Data ]
        private FileInfo setting_ImageFile;
        //private string setting_EyeImageLabel;
        //private string setting_EyeImageLabelExtension;
        //private uint setting_WaveformsToAcquire;
        //private float setting_Frequency;
        //private bool setting_UseFilter;
        private float result_ExtinctionRatio;
        private float result_Crossing;
        private float result_Jitter;
        private float result_JitterPP;
        private float result_RiseTime;
        private float result_FallTime;
        private float result_EyeHeight;
        private float result_OpticalPower;
        private float result_MaskMargin;
        private float result_OverShot;
        private float result_SignalToNoise;
        private float result_VAmplitude;
        private float result_VPeakPeak;
        private string ServerPath = @"\\fre-netapp-01\Shared\zzz\";
        private string _eyeImageName = "aaa";
        private string ipAddress = @"\\10.34.22.55\";
        #endregion

        public string EyeFileFullName {
            get;
            set;
        }
        
        public DCA_Control( ) {
            InitializeComponent( );
        }
        #region DCA Control Center

        private void btnInit_DCA_Click( object sender, EventArgs e ) {
            Init_DCA( );
        }
        
        public byte GPIB_Address {
            get { return GpibAddress; }
            set {
                GpibAddress = value;
            }
        }
        
        public string DCA_IPaddress {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
        
        public int DCA_Channel2Use {
            get { return CurrentChannel; }
            set {
               
                CurrentChannel = value; 
            }
        }
        
        public Finisar.Ag86100C GetDCAControl( ) {
            return DCA_ctrl;
        }

        public bool Init_DCA( ) {
            bool retValue = false;
            DCA_ctrl = new Finisar.Ag86100C( GpibAddress );
            if( DCA_ctrl != null ) {
                DCA_ctrl.InternalConnect( );
                DCA_ctrl.SetFilter( true );
                DCA_ctrl.SetDefine_Thresholds( );
                retValue = true;
                DCA_ctrl.EquipmentIpAddress = DCA_IPaddress;
                nudDCAChannelNumber.Value = DCA_Channel2Use;
            }
            setting_ImageFile = new FileInfo( @"\\C\\test\\GpibTest\\EyeImages\\DCAtempImage.bmp" );

            //setting_WaveformsToAcquire = 100;

            result_ExtinctionRatio = float.NaN;
            result_Crossing = float.NaN;
            result_Jitter = float.NaN;
            result_JitterPP = float.NaN;
            result_RiseTime = float.NaN;
            result_FallTime = float.NaN;
            result_EyeHeight = float.NaN;
            result_OpticalPower = float.NaN;
            result_MaskMargin = float.NaN;
            result_SignalToNoise = float.NaN;
            result_OverShot = float.NaN;
            result_VAmplitude = float.NaN;
            result_VPeakPeak = float.NaN;

            gboEyeMeasurement.Enabled = retValue;
            gboEyeMode.Enabled = retValue;
            screenDumpButton.Enabled = retValue;
            btnInit_DCA.Enabled = !retValue;
            

            //SetChannel((uint)CurrentChannel);
            return retValue;
        }
        
        private void FireResultDataChanged( ) {
            UpdateAllLabels_DCA( );
            if( DCA_OperationCompleted != null )
                DCA_OperationCompleted( this );
        }
       
        public void FireScreenImageChanged( ) {
            if( this.ScreenImageChanged != null )
                this.ScreenImageChanged( this );
        }

        private void SetStateDescription( string description ) {
            if( StateChanged != null )
                StateChanged( description );
            lblStatus.Text = description;
        }

        private void allEyeMeasurementsButton_Click( object sender, EventArgs e ) {
            DoOverAllMeasurements( );
        }

        private void DCAMode_CheckedChanged( object sender, EventArgs e ) {

            SetDCAToOscilloscopeMode( rdoEyeMode.Checked );
        }

        private void UpdateAllLabels_DCA( ) {
            extinctionRatioLabel.Text = float.IsNaN( Result_ExtinctionRatio ) ? "----" : Result_ExtinctionRatio.ToString( "0.00" );
            crossingLabel.Text = float.IsNaN( Result_Crossing ) ? "----" : Result_Crossing.ToString( "0.0" );
            maskMarginLable.Text = float.IsNaN( Result_MaskMargin ) ? "----" : Result_MaskMargin.ToString( "0.0" );
            riseTimeLabel.Text = float.IsNaN( Result_RiseTime ) ? "----" : ( Result_RiseTime * 1e12f ).ToString( "0.00" );
            fallTimeLabel.Text = float.IsNaN( Result_FallTime ) ? "----" : ( Result_FallTime * 1e12f ).ToString( "0.00" );
            jitterLabel.Text = float.IsNaN( Result_Jitter ) ? "----" : ( Result_Jitter * 1e12f ).ToString( "0.00" );
            jitterPPLable.Text = float.IsNaN( Result_JitterPP ) ? "----" : ( Result_JitterPP * 1e12f ).ToString( "0.00" );
            signal2noiseLable.Text = float.IsNaN( Result_SignalToNoise ) ? "----" : ( Result_SignalToNoise.ToString( "0.00" ) );
            overShotLable.Text = float.IsNaN( Result_OverShot ) ? "----" : ( Result_OverShot.ToString( "0.00" ) );
            lblEyeAmplitude.Text = float.IsNaN( Result_VAmplitude ) ? "----" : ( Result_VAmplitude.ToString( "0.00" ) );

            System.Windows.Forms.Application.DoEvents( );
        }
       
        private void screenDumpButton_Click( object sender, EventArgs e ) {
            //if( !setting_ImageFile.FullName.Equals( ServerPath + _eyeImageName + ".jpg" ) ) {
            //    setting_ImageFile = new FileInfo( ServerPath + _eyeImageName + ".jpg" );
            //}
            ////string fileFullname = ServerPath + _eyeFileName + ".jpg";
            // //string.Format( @"{0}{1}_{2}_L{3}_Cur{4}_Temp{5}_Prbs{6}.jpg",
            // //   ServerPath, txtSerialNumber.Text, txtBriefMsg.Text, nudChannelNumber.Value, txtLaserCur.Text,
            // //   txtTecTemp.Text, txtPrbs.Text );
            //SaveScreenImage();
            SaveScreenImage( );

        }

        private void nudDCAChannelNumber_ValueChanged( object sender, EventArgs e ) {
            if( DCA_ctrl != null ) {
                SetChannel( ( uint )nudDCAChannelNumber.Value );
                CurrentChannel = ( int )nudDCAChannelNumber.Value;
            }
        }

        #endregion

        #region [ Oscilloscope Handling ]

        public void DoEyeMeasurementOnly( ) {
            DCA_ctrl.StartEyeMeasurement( 100, 60000f );
        }

        public void DoOverAllMeasurements( uint waveforms ) {

            if (DCA_ctrl.StartEyeMeasurement( waveforms, 60000f ))
                DoOverAllMeasurements( );
        }

        public void DoOverAllMeasurements( ) {
            try {

                //DCA_86100.PerformAutoScale(0  );

                DateTime startMeas = DateTime.UtcNow;

                SetStateDescription( "Performing full eye measurement..." );

                 result_RiseTime = DCA_ctrl.MeasureRiseTime( );
                SetStateDescription( "RiseTime measured: " + result_RiseTime.ToString( "0.00e0" ) + " sec." );
                result_FallTime = DCA_ctrl.MeasureFallTime( );
                SetStateDescription( "FallTime measured: " + result_FallTime.ToString( "0.00e0" ) + " sec." );
                result_Crossing = DCA_ctrl.MeasureCrossing( );
                SetStateDescription( "Eye crossing measured: " + result_Crossing.ToString( "0.00" ) + "%" );
                result_Jitter = DCA_ctrl.MeasureJitter( );
                SetStateDescription( "Jitter measured: " + result_Jitter.ToString( "0.00e0" ) + " sec." );
                if( CurrentChannel == 2 ) {
                    result_ExtinctionRatio = DCA_ctrl.MeasureExtinctionRatio( );
                    SetStateDescription( "Extinction ratio measured: " + result_ExtinctionRatio.ToString( "0.00" ) + " dB" );
                    result_JitterPP = DCA_ctrl.MeasureJitterPP( );
                    SetStateDescription( "JitterRms measured: " + result_JitterPP.ToString( "0.00e0" ) + " sec." );
                    result_OpticalPower = DCA_ctrl.MeasureOpticalPower( );
                    SetStateDescription( "Optical power measured: " + result_OpticalPower.ToString( "0.00e0" ) + " W." );
                    result_SignalToNoise = DCA_ctrl.MeasureSignalToNoise( );
                    SetStateDescription( "Optical MeasureSignalToNoise: " + result_SignalToNoise.ToString( "0.00e0" ) + " W." );
                    result_EyeHeight = DCA_ctrl.MeasureEyeHeight( );
                    SetStateDescription( "Eye height measured: " + result_EyeHeight.ToString( "0.00e0" ) + " W." );

                    result_MaskMargin = DCA_ctrl.MeasureMaskMargin( );
                    SetStateDescription( "Eye MaskMargin measured: " + result_MaskMargin.ToString( "0.00" ) + "%" );

                    result_OverShot = DCA_ctrl.MeasureOverShoot( );
                }
                else if( CurrentChannel == 1 ) {
                    GeWholetMeasureResult_EyeMode();
                    DCA_ctrl.SetEyeMode(false);
                    //result_VAmplitude = DCA_ctrl.Measure_VAmplitude(100, 6000f );
                    //SetStateDescription( "Optical Measure_VAmplitude: " + result_VAmplitude.ToString( "0.00" ) );
                    result_VPeakPeak = DCA_ctrl.Measure_VPeak_Peak(100, 6000f );
                    SetStateDescription( "Optical Measure_VPeak_Peak: " + result_VPeakPeak.ToString( "0.00" ) );
                    GeWholetMeasureResult_ScopeMode();
                }

                rdoEyeMode.Checked = DCA_ctrl.IsEyeMode;
                DCA_ctrl.SetEyeMode( true );
                System.Windows.Forms.Application.DoEvents( );
                FireResultDataChanged( );
            }
            catch( Exception ex ) {

                SetStateDescription( "DoAllEyeMeasurements exception=" + ex.ToString( ) );
            }
            finally {

            }
        }

        public void SetDCAToOscilloscopeMode( bool isEye ) {
            if( isEye != DCA_ctrl.IsEyeMode ) {
                DCA_ctrl.SetEyeMode( isEye );
            }
        }

        public void SaveScreenImage( string fileFullname ) {
            DCA_ctrl.SaveScreenImage( fileFullname );
            FireScreenImageChanged( );
        }

        public void SaveScreenImage( ) {
            try {
                SetStateDescription( "Saving screen image to: " + setting_ImageFile.FullName );

                //if( DCA_ctrl.SaveScreenImage( setting_ImageFile.FullName, setting_EyeImageLabel + setting_EyeImageLabelExtension ) ) {
                if( DCA_ctrl.SaveScreenImage( setting_ImageFile.FullName ) ) {

                    screenDumpPB.Image = DCA_ctrl.ScreenImage;

                    SetStateDescription( "Image succesfully saved." );
                    System.Windows.Forms.Application.DoEvents( );
                    FireScreenImageChanged( );
                    //setting_EyeImageLabelExtension = "";
                }

                else {
                    SetStateDescription( "Saving image failed." );
                }
            }
            catch( Exception ex ) {
                SetStateDescription( "Error while saving image." + ex.ToString( ) );

            }
        }

        public string GeWholetMeasureResult_EyeMode()
        {
             EyeModeMeasurementResult = DCA_ctrl.GetWholeMeasrueResults();
             EyeModeMeasurementResult = EyeModeMeasurementResult.Substring(0, EyeModeMeasurementResult.Length - 1);
             return EyeModeMeasurementResult;
        }

        public string EyeModeMeasurementResult
        { get; set; }

        public string GeWholetMeasureResult_ScopeMode()
        {
            OsilliocopeMeasurementResult = DCA_ctrl.GetWholeMeasrueResults();
            OsilliocopeMeasurementResult = OsilliocopeMeasurementResult.Substring(0, OsilliocopeMeasurementResult.Length - 1);
            return OsilliocopeMeasurementResult;
        }
        public string OsilliocopeMeasurementResult
        { get; set; }
        #region [ Oscilloscope Properties ]
        /// <summary>
        /// The measured Extinction Ratio (dB).
        /// </summary>
        public float Result_ExtinctionRatio {
            get {
                return result_ExtinctionRatio;
            }
        }
        /// <summary>
        /// The measured Eye crossing in percentage.
        /// </summary>
        public float Result_Crossing {
            get {
                return result_Crossing;
            }
        }
        /// <summary>
        /// The measured jitter in seconds.
        /// </summary>
        public float Result_Jitter {
            get {
                return result_Jitter;
            }
        }
        public float Result_JitterPP {
            get {
                return result_JitterPP;
            }
        }
        /// <summary>
        /// The measured risetime in seconds.
        /// </summary>
        public float Result_RiseTime {
            get {
                return result_RiseTime;
            }
        }
        /// <summary>
        /// The measured falltime in seconds.
        /// </summary>
        public float Result_FallTime {
            get {
                return result_FallTime;
            }
        }
        /// <summary>
        /// The measured eye height in Watts.
        /// </summary>
        public float Result_EyeHeight {
            get {
                return result_EyeHeight;
            }
        }
        /// <summary>
        /// The measured optical power in Watts.
        /// </summary>
        public float Result_OpticalPower {
            get {
                return result_OpticalPower;
            }
        }
        public float Result_OverShot {
            get {
                return result_OverShot;
            }
        }
        public float Result_MaskMargin {
            get {
                return result_MaskMargin;
            }
        }
        public float Result_SignalToNoise {
            get {
                return result_SignalToNoise;
            }
        }
        public float Result_VAmplitude {
            get {
                return result_VAmplitude;
            }
        }
        public float Result_VPeakPeak {
            get {
                return result_VPeakPeak;
            }
        }
        /// <summary>
        /// An eye diagram image representing the DCA screen saved after eye measurements
        /// </summary>
        public Image Result_Image {
            get {
                return DCA_ctrl.ScreenImage;
            }
        }

        public FileInfo SetImageFile {
            get { return setting_ImageFile; }
            set {
                setting_ImageFile = value;
            }
        }

        public void SetChannel( uint chNumber ) {
            DCA_ctrl.SetChannel( chNumber );
        }

        public string GetServerPath {
            get { return ServerPath; }
        }

        public string EyeFileName {
            get { return _eyeImageName; }
            set {
                if( value.Contains( "." ) ) {
                    value = value.Substring( 0, value.IndexOf( "." ) );
                }
                _eyeImageName = value;
            }
        }
        #endregion

        private void btnSetEdataPath_Click( object sender, EventArgs e ) {
            //FolderBrowserDialog folderDialogDstin = new FolderBrowserDialog( );

            //if( folderDialogDstin.ShowDialog( ) == DialogResult.OK ) {
            //    Thread.Sleep( 10 );
            //    txtEdataFilePath.Text = folderDialogDstin.SelectedPath;
            //}
            
            ServerPath = txtEdataFilePath.Text;
        }

        
        #endregion
        public bool Clear()//86100Clear
        {
            DCA_ctrl.Clear();
            return true;
        }

        public bool Run()//86100Run
        {
            DCA_ctrl.Run();
            return true;
        }
        public bool AutoScale()//86100Auto
        {
            DCA_ctrl.PerformAutoScale(0);
            return true;
        }
        public bool QuickMeasure()
        {
            DCA_ctrl.QuickMeasure();
            return true;
        }
        public bool StartAcquireTest(uint waveforms, float timeout)
        {
            DCA_ctrl.StartAcquireTest(waveforms, timeout);
            return true;
        }
        public bool AutoCal()
        {
            DCA_ctrl.AutoCal();
            return true;
        }
        public bool MaskTeston()
        {
            DCA_ctrl.MaskTestOn();
            return true;
        }
        public bool ExitMaskTest()
        {
            DCA_ctrl.MaskTestExit();
            return true;
        }
        public bool EndAcquireTest()
        {
            DCA_ctrl.EndAcquireTest();
            return true;
        }
        public bool SetMaskMargin(int point)
        {
            
            return true;
        }
        public float MeasureER()
        {
            return DCA_ctrl.MeasureExtinctionRatio();
        }
        public float JitterRMS()
        {
            return DCA_ctrl.MeasureJitter();
        }
        public float HistoMean()
        {
            return DCA_ctrl.MeasureHistoGramMean();
        }
        public float HistoPP()
        {
            return DCA_ctrl.MeasureHistoGramPP();
        }
        public float HistoStdDev()
        {
            return DCA_ctrl.MeasureHistoGramStdDev();
        }
    }
}
