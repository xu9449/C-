using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using NationalInstruments.NI4882;
using System.Drawing;

namespace Finisar {

  /// <summary>
  /// Class used to represent an exception thrown for the Agilent 86100A/B/C Wide-Bandwidth Oscilloscope
  /// </summary>
  public class Ag86100Error : Exception {
    public Ag86100Error( string errorMessage, Exception innerException )
      : base( "Ag86100Error: " + errorMessage, innerException ) {
    }
    public Ag86100Error( string errorMessage )
      : base( "Ag86100Error: " + errorMessage ) {
    }
    public Ag86100Error( )
      : base( "Ag86100Error: no message" ) {
    }
  }

  [Serializable]
  public class Ag86100Settings {
    private static Ag86100Settings defaultSettings_;

    public byte GpibAddress;
    public TimeoutValue GpibTimeout;
    public uint Channel;
    public Ag86100FilterOption Filter;
    public Ag86100BandWidthOption Bandwidth;
    public double ExtinctionRatioCorrectionFactor;
    public double EyesOnScreen;
    public Ag86100ImageArea ImageArea;
    public double RiseTimeOffsetps;
    public double FallTimeOffsetps;

    static Ag86100Settings( ) {
      defaultSettings_ = new Ag86100Settings( );
      defaultSettings_.GpibAddress = 1;
      defaultSettings_.GpibTimeout = TimeoutValue.T30s;
      defaultSettings_.Channel = 1; //make configurable for both cases!!!!!!!!!!!!!!!!!!
      defaultSettings_.Filter = Ag86100FilterOption.Filter10709;
      defaultSettings_.Bandwidth = Ag86100BandWidthOption.High;
      defaultSettings_.ExtinctionRatioCorrectionFactor = 0.0;
      defaultSettings_.EyesOnScreen = 2.5;
      defaultSettings_.ImageArea = Ag86100ImageArea.Screen;
      //defaultSettings_.ImageArea = Ag86100ImageArea.Graticule;
      defaultSettings_.RiseTimeOffsetps = 0.0;
      defaultSettings_.FallTimeOffsetps = 0.0;
    }

    public static Ag86100Settings DefaultSettings {
      get {
        return ( Ag86100Settings )defaultSettings_.MemberwiseClone( );
      }
    }
  }

  public class Ag86100C {
    protected Ag86100Settings settings_ = Ag86100Settings.DefaultSettings;
    protected GpibDriver gpib_ = null;
    protected bool isDisposed_ = false;
    protected CultureInfo culture_ = new CultureInfo( "en-US" );
    protected double darkLevel = double.NaN;
    protected String setupFile = "";
    string msg = "";
    // Dictionary to translate a filter option into a string used for gpib.
    protected Dictionary<Ag86100FilterOption, string> filterStrings;
    // Dictionary to translate a bandwidth option into a string used for gpib.
    protected Dictionary<Ag86100BandWidthOption, string> bandwidthStrings;
    // Dictionary to translate an image area option into a string used for gpib.
    protected Dictionary<Ag86100ImageArea, string> imageAreaStrings;
    // Dictionary to translate an image mode option into a string used for gpib.
    protected Dictionary<Ag86100ImageMode, string> imageModeStrings;
  
    private Object dcaSync = new Object( );
    private String screenImageFileName;
    private string ipAddress = @"\\10.34.22.55\";//Tedros'
    private MemoryStream screenImageMS;
    private int maskMarginPercent;

    public String SetupFile {
      get { return setupFile; }
      set { setupFile = value; }
    }

    /// <summary>
    /// Default constructor for the Ag86100 class
    /// </summary>
    public Ag86100C( ) {
      filterStrings = new Dictionary<Ag86100FilterOption, string>( );
      filterStrings.Add( Ag86100FilterOption.Filter1063, "FILT1" );
      filterStrings.Add( Ag86100FilterOption.Filter1250, "FILT2" );
      filterStrings.Add( Ag86100FilterOption.Filter2125, "FILT3" );
      filterStrings.Add( Ag86100FilterOption.Filter2488, "FILT4" );
      filterStrings.Add( Ag86100FilterOption.Filter2500, "FILT5" );
      filterStrings.Add( Ag86100FilterOption.Filter9953, "FILT6" );
      filterStrings.Add( Ag86100FilterOption.Filter10312, "FILT7" );
      filterStrings.Add( Ag86100FilterOption.Filter10518, "FILT8" );
      filterStrings.Add( Ag86100FilterOption.Filter10664, "FILT9" );
      filterStrings.Add( Ag86100FilterOption.Filter10709, "FILT10" );
      filterStrings.Add( Ag86100FilterOption.Filter17000, "FILT11" );
      filterStrings.Add( Ag86100FilterOption.Filter25781, "FILT12" );
      filterStrings.Add( Ag86100FilterOption.Filter27739, "FILT13" );
      

      bandwidthStrings = new Dictionary<Ag86100BandWidthOption, string>( );
      bandwidthStrings.Add( Ag86100BandWidthOption.Low, "LOW" );
      bandwidthStrings.Add( Ag86100BandWidthOption.High, "HIGH" );

      imageAreaStrings = new Dictionary<Ag86100ImageArea, string>( );
      imageAreaStrings.Add( Ag86100ImageArea.Screen, "SCR" );
      imageAreaStrings.Add( Ag86100ImageArea.Graticule, "GRAT" );

      imageModeStrings = new Dictionary<Ag86100ImageMode, string>( );
      imageModeStrings.Add( Ag86100ImageMode.Normal, "NORM" );
      imageModeStrings.Add( Ag86100ImageMode.Inverted, "INV" );
      imageModeStrings.Add( Ag86100ImageMode.Monochrome, "MON" );
    }
    /// <summary>
    /// Constructor for the Ag86100 class
    /// </summary>
    /// <param name="address">GPIB address</param>
    public Ag86100C( byte address )
      : this( ) {
        
      settings_.GpibAddress = address;

      Name = "86100C";
    }
    /// <summary>
    /// Constructor for the Ag86100 class
    /// </summary>
    /// <param name="address">GPIB address</param>
    /// <param name="timeout">Enum timeout value</param>
    public Ag86100C( byte address, TimeoutValue timeout )
      : this( ) {
      settings_.GpibAddress = address;
      settings_.GpibTimeout = timeout;
    }
    /// <summary>
    /// Dispose method for the Ag86100 class
    /// </summary>
    public void Dispose( ) {
      if( !this.isDisposed_ ) {
        if( gpib_ != null ) {
          gpib_.Dispose( );
        }
        isDisposed_ = true;
      }
    }

    /// <summary>
    /// Method used to initialize the GPIB interface
    /// </summary>
    public void InternalConnect( ) {
      try {
        if( gpib_ == null ) {
          gpib_ = new GpibDriver( settings_.GpibAddress, settings_.GpibTimeout );
        }
        GpibIdentity id = gpib_.GetIdentity( );
        if( id != null ) {
            string strId = id.serialNumber;
        }

        GetFilterOptions( );
          
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error connecting 86100.", ex );
      }
    }
    /// <summary>
    /// Disposes the current instance of the GPIB driver
    /// </summary>
    protected void InternalDisconnect( ) {
      try {
        gpib_.Dispose( );
        gpib_ = null;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error disconnecting 86100.", ex );
      }
    }
    /// <summary>
    /// Method used to reset the Tektronix CSA8000 Communications Signal Analyzer unit
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <i>"*RST", "*CLS"</i>
    /// </summary>
    protected void InternalReset( ) {
      try {
        gpib_.Reset( );
        RecallSetup( );
        gpib_.ClearStatus( );
        SetHeadersOff( );
        ApplySettings( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error resetting 86100.", ex );
      }
    }
    /// <summary>
    /// Method used to configure the instrument according to the settings
    /// </summary>
    public void ApplySettings( ) {
      try {
        SetChannel( settings_.Channel );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error applying settings to 86100.", ex );
      }
    }
  
    public Ag86100Settings Settings {
      get {
        return settings_;
      }
      set {
        settings_.GpibAddress = value.GpibAddress;
        settings_.GpibTimeout = value.GpibTimeout;
        settings_.Channel = value.Channel;
        settings_.Filter = value.Filter;
        settings_.Bandwidth = value.Bandwidth;
      }
    }
    /// <summary>
    /// Gets/sets the driver for the GPIB interface
    /// </summary>
    public GpibDriver Driver {
      get {
        return gpib_;
      }
      set {
        gpib_ = value;
      }
    }

    /// <summary>
    /// Gets/sets the vertical full scale range value for the current channel (V)
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Set: </b> 
    /// <i>":CHAN{0}:SCAL {1}"</i>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>":CHAN{0}:SCAL?" ("SYST:HEAD OFF")</i>
    /// </summary> 
    public double VerticalScale {
      get {
        return GetVerticalScale( );
      }
      set {
        SetVerticalScale( value );
      }
    }
    public string Name { get; set; }
    /// <summary>
    /// Gets/sets the voltage value represented at the center of the screen
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Set: </b> 
    /// <i>":CHAN{0}:OFFS {1}"</i>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>":CHAN{0}:OFFS?" ("SYST:HEAD OFF")</i>
    /// </summary> 
    public double VerticalOffset {
      get {
        return GetVerticalPosition( );
      }
      set {
        SetVerticalPosition( value );
      }
    }
    /// <summary>
    /// The dark level of the latest calibration
    /// </summary>
    public double DarkLevel {
      get {
        return darkLevel;
      }
    }

    public string EquipmentIpAddress {
        get { return ipAddress; }
        set { ipAddress = value; }
    }
    /// <summary>
    /// Method used to select which channel's waveform to display
    /// </summary>
    /// <param name="channel">Channel to select</param>
    public void SetChannel( uint channel ) {
      try {
        if( channel < 1 || channel > 4 ) {
          throw new Ag86100Error( "Invalid channel number. Allowed values are 1 - 4." );
        }

        gpib_.Write( ":CHAN" + channel.ToString( ) + ":DISP ON" );
        settings_.Channel = channel;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error setting channel.", ex );
      }
    }
    public virtual bool RecallSetup( ) {
      try {
        // Clear the event status register.
        Driver.GetEventStatusRegister( );
        // Recall instrument state.
        gpib_.Write( ":DISK:LOAD \"" + setupFile + "\"" );
        // Check for errors.
        return !ErrorOccured( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error recalling 86100 setup file: " + setupFile, ex );
      }
    }

    public virtual bool SetEyeMode( bool isEye ) {
        if( isEye )
            return SetOscMode( Ag86100OscilloscopeMode.Eye );
        else
            return SetOscMode( Ag86100OscilloscopeMode.Oscilloscope );
    }

    public bool IsEyeMode { get; set; }

    public bool SetOscMode( Ag86100OscilloscopeMode mode ) {
      try {
        string m = "OSC";
        IsEyeMode = false;
        switch( mode ) {
            case Ag86100OscilloscopeMode.Eye:
                IsEyeMode = true;
                m = "EYE";
                break;
            case Ag86100OscilloscopeMode.Jitter:
                m = "JIT";
                break;
            case Ag86100OscilloscopeMode.Oscilloscope:
                m = "OSC";
                break;
            case Ag86100OscilloscopeMode.Tdr:
                m = "TDR";
                break;
        }

        // Clear the ESR of possible errors.
        Driver.GetEventStatusRegister( );
        // Stop acquiring.
        gpib_.Write( ":STOP" );
        // Set oscilloscope mode.
        gpib_.Write( "SYSTEM:MODE " + m );
        // Clear it.
        gpib_.Write( ":CDISPLAY" );
        
        // Turn limit acquisition off.
        //gpib_.Write( ":ACQUIRE:RUNTIL OFF" );
        // And start running.
        gpib_.Write( ":RUN" );

        return ( !ErrorOccured( ) );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error setting oscilloscope mode.", ex );
      }
    }
    public bool StartEyeMeasurement( uint waveforms, float timeout ) {
      try {
        // Clear the Event status register of possible errors
        Driver.GetEventStatusRegister( );
        // We make sure the oscilloscope is not acquiring data.
        gpib_.Write( ":STOP" );
        // Set eye mode.
        gpib_.Write( ":SYSTEM:MODE EYE" );

        // Set ERCF if not zero
        if( !settings_.ExtinctionRatioCorrectionFactor.Equals( 0.0 ) )
          gpib_.Write( ":MEASure:CGRade:ERFactor CHANnel" + settings_.Channel.ToString( ) + ",ON," + settings_.ExtinctionRatioCorrectionFactor.ToString( "0.00" ) );

        // Clear oscilloscope.
        gpib_.Write( ":CDISPLAY" );
        if( ErrorOccured( ) )
          return false;

        // If we use a number of waveforms, we wait until they are done. Otherwise we can return right away.
        // This will leave the oscilloscope running.
        if( waveforms == 0 ) {
          gpib_.Write( ":ACQUIRE:RUNTIL OFF" );
          gpib_.Write( ":RUN" );
          Thread.Sleep( 200 );
        }
        else {
          gpib_.Write( ":ACQ:RUNT WAV," + waveforms.ToString( ) );
          gpib_.Write( ":RUN" );
          WaitUntilAllComplete( timeout );
        }

        return ( !ErrorOccured( ) );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error performing eye measurements.", ex );
      }

    }
    public virtual bool StartAcquireTest(uint waveforms, float timeout)
    {
        try
        {
            if (waveforms == 0)
            {
                //gpib_.Write(":DISP:LAB \"" + label + "\"");
                //gpib_.Write(String.Format(":MTEST:LOAD \"{0}\"", filename));
                //string command = ":ACQUIRE:SSCREEN DISK,\"" + filename + "\"";
                //gpib_.Write(command);
                gpib_.Write(":ACQUIRE:RUNTIL WAVeforms,1");
                gpib_.Write(":RUN");
                Thread.Sleep(300);
                gpib_.Write(":AUTOSCALE");
                Thread.Sleep(300);
                
                

                WaitUntilAllComplete(timeout);
            }
            else
            {
                //string command = ":ACQUIRE:SSCREEN DISK,\"" + filename + "\"";
                //gpib_.Write(command);
                gpib_.Write(":ACQUIRE:RUNTIL WAVeforms," + waveforms.ToString());
                //this.LogMessage( waveforms.ToString( ) );
                gpib_.Write(":RUN");
                
                
                Thread.Sleep(300);
                gpib_.Write(":AUTOSCALE");
                Thread.Sleep(700);
                WaitUntilAllComplete(timeout);
                
            }

            return (!ErrorOccured());
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error ending 86100 acquire test", ex);
        }
    }
    public bool AutoCal()
    {
        try
        {
            // Clear oscilloscope.
            gpib_.Write(":MTESt:AMARgin:CALCulate");
            if (ErrorOccured())
                return false;
            return (!ErrorOccured());
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error Auto Calculate", ex);
        }
    }
    public bool MaskTestOn()
    {
        try
        {
            
            gpib_.Write(":MTEST:TEST ON");
            WaitUntilAllComplete(16000F);
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error mask margin state on.", ex);
        }
    }
    public bool MaskTestExit()
    {
        try
        {
            gpib_.Write(":MTEST:EXIT");
            return true;
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error mask test exit.", ex);
        }
    }
    public virtual bool EndAcquireTest()
    {
        try
        {
            gpib_.Write(":ACQuire:RUNTil OFF");
            gpib_.Write(":ACQuire:SSCReen OFF");
            return !ErrorOccured();
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error ending 86100 acquire test", ex);
        }
    }

    public virtual bool PerformAutoScale( float dataRate ) {
      try {
        //double targetScale = 0;
        // Clear the event status register
        Driver.GetEventStatusRegister( );
        // If the hintfrequency is 0, we keep the current horizontal scale.
        //if( dataRate == 0 ) {
        //  // Get the current scale.
        //  gpib_.Write( ":TIMEBASE:SCALE?" );
        //  // Use this scale after the scale operation.
        //  targetScale = ReadFloat( );
        //}
        //else {
        //  targetScale = eyesOnScreen / ( 10.0 * dataRate );
        //}

        // No hint frequency
        if( dataRate == 0 )
          gpib_.Write( ":AUTOSCALE" );
        // With hint frequency
        else
          gpib_.Write( ":AUTOSCALE " + dataRate.ToString( ) );

        // This result string will become available when the autoalign has been performed.
        gpib_.Write( ":AUTOSCALE?" );
        string result = ReadString( );
        if( result != "" )
          return false;

        /* Finish with a power scale for nice vertical position. 
         * */
        try {
          PerformPowerScale( );
        }
        catch( Exception ) {
        }

        // An empty string indicates that the align was succesful, and that's all we need to know.
        if( result == "" )
          return true;

        return ErrorOccured( );
      }

      catch( Exception ex ) {
        throw new Ag86100Error( "Error performing autoscale.", ex );
      }
    }
    public bool PerformPowerScale( ) {
      try {
        // Clear the event status register.
        Driver.GetEventStatusRegister( );

        /* We measure the average power going into the scope (in Watts). We use this 
         * to calculate the new watt/division target scale. Setting it to the average 
         * power divided by x makes the waveform occupy 2x vertical divisions. There 
         * are 8 divisions on the screen - We target to use 5 and assume a 50% dutycycle.
         * */
        float currentPower = MeasureOpticalPower( );
        float targetScale = currentPower / 2.5f; // 2*2.5 = 5 divisions!!
        // The limits for this are 2e-5/div to 5e-4/div.
        if( targetScale > 5e-4f )
          targetScale = 5e-4f;
        if( targetScale < 2e-5f )
          targetScale = 2e-5f;
        // Set the target offset. We use divs division from the bottom.
        float divs = 1;
        gpib_.Write( ":CHANNEL" + settings_.Channel.ToString( ) + ":OFFSET " + ( targetScale * divs ).ToString( ) ); // 
        // Set the target scale.
        gpib_.Write( ":CHANNEL" + settings_.Channel.ToString( ) + ":SCALE " + targetScale.ToString( ) );

        return ( !ErrorOccured( ) );

      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error performing powerscale.", ex );
      }
    }

    public virtual bool QuickMeasure()
    {
        try
        {

            gpib_.Write(":MEAS:CGR:ERAT DEC");
            gpib_.Write(":MEAS:CGR:JITT PP");
            gpib_.Write(":MEAS:CGR:JITT RMS");
            gpib_.Write(":MEASURE:CGRADE:CROSSING");

            return !ErrorOccured();
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error setting measure define", ex);
        }
    }

    /// <summary>
    /// Method used to set the vertical scale or units per division value of the 
    /// current channel (V)
    /// </summary>
    /// <param name="scale">Scale value</param>
    public void SetVerticalScale( double scale ) {
      try {
        string command = String.Format( ":CHAN{0}:SCAL {1}", settings_.Channel, scale.ToString( "E", culture_ ) );

        gpib_.Write( command );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error setting vertical scale.", ex );
      }
    }
    /// <summary>
    /// Method used to retrieve the the vertical scale or units per division value of the 
    /// current channel (V)
    /// </summary>
    /// <returns>Scale value</returns>
    public double GetVerticalScale( ) {
      try {
        SetHeadersOff( );

        string command = String.Format( ":CHAN{0}:SCAL?", settings_.Channel );
        gpib_.Write( command );

        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error getting vertical scale.", ex );
      }
    }
    /// <summary>
    /// Method used to set the voltage represented at the center of the screen (V)
    /// </summary>
    /// <param name="position">Position offset voltage</param>
    public void SetVerticalPosition( double position ) {
      try {
        string command = String.Format( ":CHAN{0}:OFFS {1}", settings_.Channel, position.ToString( "E", culture_ ) );

        gpib_.Write( command );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error setting vertical position.", ex );
      }
    }
    /// <summary>
    /// Method used to retriev the voltage represented at the center of the screen (V)
    /// </summary>
    /// <returns>Position offset voltage</returns>
    public double GetVerticalPosition( ) {
      try {
        SetHeadersOff( );

        string command = String.Format( ":CHAN{0}:OFFS?", settings_.Channel );
        gpib_.Write( command );

        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error getting vertical position.", ex );
      }
    }
    /// <summary>
    /// Method used to get the DCA's trigger level
    /// </summary>
    /// <returns>The trigger level</returns>
    public Double GetTriggerLevel( ) {
      try {
        SetHeadersOff( );

        String command = ":TRIGger:LEVel?";
        gpib_.Write( command );

        return ReadFloat( );

      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error getting trigger level.", ex );
      }
    }
    /// <summary>
    /// Method used to set the DCA's trigger level
    /// </summary>
    /// <param name="level"></param>
    public void SetTriggerLevel( Double level ) {
      try {
        SetHeadersOff( );

        String command = String.Format( ":TRIGger:LEVel {0}", level );
        gpib_.Write( command );

      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error setting trigger level.", ex );
      }
    }

    public virtual bool PerformHorizontalAlign( float dataRate ) {
      double minimumDelay = 24.01e-9;

      try {
        // Clear ESR
        Driver.GetEventStatusEnableRegister( );

        // With a datarate, adjust the horizontal scale, otherwise leave it as is
        if( dataRate != 0 ) {
          gpib_.Write( ":TIMEBASE:SCALE " + ( settings_.EyesOnScreen / 10.0 / dataRate ).ToString( "0.00e0" ) );
        }

        double timcro = MeasureCrossingPosition( );

        if( !double.IsNaN( timcro ) ) {
          double delay = timcro - ( settings_.EyesOnScreen - 1 ) / 2 / dataRate;
          delay = timcro + 1 / 2 / dataRate;
          delay = timcro + ( 2 - settings_.EyesOnScreen ) / 2 / dataRate;
          while( delay < minimumDelay )
            delay += ( 1 / dataRate );
          gpib_.Write( ":TIMEBASE:POSITION " + delay.ToString( "0.00000e0" ) );
          return ( !ErrorOccured( ) );
        }
        else
          return false;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error performing horizontal align.", ex );
      }
    }
    public bool Clear( ) {
      try {
        // Clear oscilloscope.
        gpib_.Write( ":CDIS" );
        if( ErrorOccured( ) )
          return false;
        return ( !ErrorOccured( ) );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error clearing oscilloscope.", ex );
      }
    }
    public bool Run()
    {
        try
        {
            // Set oscilloscope running.
            gpib_.Write(":RUN");
            if (ErrorOccured())
                return false;
            return (!ErrorOccured());
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error setting oscilloscope run.", ex);
        }
    }
    public bool PerformCalibration( ) {
      try {
        // Clear ESR.
        Driver.GetEventStatusRegister( );
        // We do a simple check to see if there is power going into the oscilloscope (> 10 uW).
        // If there is, we cancel the calibration and return a fail.
        gpib_.Write( ":MEASure:APOWer? WATT, CHANnel" + settings_.Channel.ToString( ) );
        float currentPower = ReadFloat( );
        if( float.IsNaN( currentPower ) || currentPower > 10.0e-6f )
          return false;

        gpib_.Write( ":CALibrate:RECommend? CHANnel" + settings_.Channel.ToString( ) );
        string calibrationRecommended = ReadString( );
        if( ( int.Parse( calibrationRecommended.Substring( 0, 1 ) ) + int.Parse( calibrationRecommended.Substring( 4, 1 ) ) ).Equals( 0 ) )
          return true;  // Because then calibration is not recommended for mainframe or module

        // Set timeout 100s and start calibration.
        gpib_.Device.IOTimeout = TimeoutValue.T100s;
        gpib_.Write( ":CALibrate:ERATio:STARt CHANnel" + settings_.Channel.ToString( ) ); // Mats ISaksson 2007-12-07
        // Ignore dialog.
        gpib_.Write( ":CALibrate:CONTinue" );
        Thread.Sleep( 100 );
        gpib_.Write( ":CALibrate:SDONe?" );
        String result = ReadString( );

        if( result != "Done" )
          throw new Ag86100Error( "Error during calibration. :CALibrate:SDONe? returned <" + result + ">" );

        // Set back timeout value
        gpib_.Device.IOTimeout = settings_.GpibTimeout;
        gpib_.Write( ":CALibrate:ERATio:DLEVel? CHANnel" + settings_.Channel.ToString( ) );
        darkLevel = ReadFloat( );
        return true;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error compensating for dark level.", ex );
      }

    }
    public float MeasureExtinctionRatio( ) {
      try {
        gpib_.Write( ":MEAS:CGR:ERAT? DEC" );
        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring Extinction ratio.", ex );
      }
    }
    public virtual float MeasureCrossing( ) {
      try {
        gpib_.Write( ":MEASURE:CGRADE:CROSSING? CHANNEL" + settings_.Channel.ToString( ) );
        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring Eye crossing.", ex );
      }
    }
    public float GetCrossingMeanValue()
    {
        float retVal;
        String[] wholeTestResult = GetWholeMeasrueResults().Split(',');
        retVal = float.Parse(wholeTestResult[4]);
        return retVal;
    }
    public virtual float MeasureHistoGramMean()
    {
        try
        {
            gpib_.Write(":MEASure:HISTogram:MEAN?");
            return ReadFloat();
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error measuring HISTogram:MEAN.", ex);
        }
    }
    public virtual float MeasureHistoGramStdDev()
    {
        try
        {
            gpib_.Write(":MEASURE:HISTogram:STDDev?");
            return ReadFloat();
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error measuring HISTogram:STDDev?.", ex);
        }
    }
    public virtual float MeasureHistoGramPP()
    {
        try
        {
            gpib_.Write(":MEASure:HISTogram:PP?");
            return ReadFloat();
        }
        catch (Exception ex)
        {
            throw new Ag86100Error("Error measuring HISTogram:PP.", ex);
        }
    }
    public float MeasureRiseTime( ) {
      try {
        gpib_.Write( ":MEAS:RIS?" );
        //Thread.Sleep( 200 );
        //gpib_.Write( ":MEAS:RIS:SDev?" );
        //Thread.Sleep( 200 );
        //gpib_.Write( ":MEAS:RIS:Min?" );
        //Thread.Sleep( 200 );
        //gpib_.Write( ":MEAS:RIS:Max?" );
        if( this.settings_.RiseTimeOffsetps != 0 )
          msg = String.Format("{0}: Rise time offset applied: {1}ps", this.Name, this.settings_.RiseTimeOffsetps );
        return ReadFloat( ) - (float)(this.settings_.RiseTimeOffsetps * 1e-12);
        
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring Rise time.", ex );
      }
    }
    public float MeasureFallTime( ) {
      try {
        gpib_.Write( ":MEAS:FALL?" );
        if( this.settings_.FallTimeOffsetps != 0 )
          msg = String.Format( "{0}: Fall time offset applied: {1}ps", this.Name, this.settings_.FallTimeOffsetps );
        return ReadFloat( ) - (float)(this.settings_.FallTimeOffsetps * 1e-12);
        
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring Fall time.", ex );
      }
    }
    public float MeasureJitter( ) {
      try {
        gpib_.Write( ":MEAS:CGR:JITT? RMS, CHANNEL" + settings_.Channel.ToString( ) );
        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring RMS jitter.", ex );
      }
    }
    public float MeasureJitterPP( ) {
      try {
          gpib_.Write( ":MEAS:CGR:JITT? PP" );
        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring PP jitterRms.", ex );
      }
    }
    
    public float MeasureEyeHeight( ) {
      try {
          gpib_.Write( ":SYSTEM:MODE?" );
          string oldMode = gpib_.Read( );

          SetEyeMode( false );
          SetHeadersOff( );
        gpib_.Write( ":MEASURE:CGRADE:EHEIGHT?" );
        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring Eye height.", ex );
      }
    }
    public float MeasureCrossingPosition( ) {
      try {
        gpib_.Write( ":SYSTEM:MODE?" );
        string oldMode = gpib_.Read( );

        SetEyeMode( false );
        gpib_.Write( ":MEASURE:TEDGE? MIDDLE,+1,CHANNEL" + settings_.Channel.ToString( ) );
        float result = ReadFloat( );

        gpib_.Write( ":SYSTEM:MODE " + oldMode );
        return result;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring crossing position", ex );
      }
    }
    
      public float MeasureOpticalPower( ) {
      try {
        Driver.GetEventStatusEnableRegister( );
       // gpib_.Write( ":MEASURE:APOWER? WATT,CHANNEL" + settings_.Channel.ToString( ) );
        gpib_.Write(":MEASURE:APOWER? DECibel,CHANNEL" + settings_.Channel.ToString());
        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring Optical power.", ex );
      }


    }

    public float MeasureMaskMargin( ) {
        try {

            //gpib_.Write( ":MTEST:AMARgin: BER 5e-005" );
            //Thread.Sleep( 100 );
            //gpib_.Write( ":MTEST:STAR" );
            ////gpib_.Write( "*OPC?" );
            //WaitUntilAllComplete( 10000 );
            //gpib_.Write( ":MTEST:AMARgin:CALCulate" );
            //Thread.Sleep( 1000 );
            //Just read only
            SetHeadersOff( );
            gpib_.Write( ":MTEST:MMARGIN:PERCENT?" );
            return ReadFloat( );
        }
        catch( Exception ex ) {

            throw new Ag86100Error( "Error MeasureMaskMargin.", ex );
        }
    }

    public float MeasureSignalToNoise( ) {
        try {
            SetHeadersOff( );
            gpib_.Write( ":MEASure:CGRade:ESN? CHANNEL" + settings_.Channel.ToString( ) );
            return ReadFloat( );
        }
        catch( Exception ex ) {

            throw new Ag86100Error( "Error MeasureMaskMargin.", ex );
        }
    }

    public float MeasureOverShoot( ) {
        try {
            gpib_.Write( ":SYSTEM:MODE?" );
            string oldMode = gpib_.Read( );

            SetEyeMode( false );
            SetHeadersOff( );
            gpib_.Write( ":MEASure:OVERshoot? CHANNEL" + settings_.Channel.ToString( ) );
            float result = ReadFloat( );
            
            gpib_.Write( ":SYSTEM:MODE " + oldMode );
            return result;
        }
        catch( Exception ex ) {
            throw new Ag86100Error( "Error at MeasureOverShoot.", ex );
        }
    }

    public float Measure_VAmplitude( int waveforms,float timeout ) {
        try {
            //gpib_.Write( ":SYSTEM:MODE?" );
            //string oldMode = gpib_.Read( );
            //SetEyeMode( false );
            //gpib_.Write( ":ACQ:RUNT WAV," + waveforms.ToString( ) );
            //gpib_.Write( ":RUN" );
            //WaitUntilAllComplete( timeout );
            // comment mode switch since we do mode swich before it!!!!!!!!!!!!!
            SetHeadersOff( );
            gpib_.Write( ":MEASURE:SOURce channel1" );
            Thread.Sleep( 100 );
            gpib_.Write( ":MEASURE:VAMPLITUDE?");
            float result = ReadFloat( );
            //gpib_.Write( ":SYSTEM:MODE " + oldMode );
            return result;
        }
        catch( Exception ex) {

            throw new Ag86100Error( "Error at Measure_VAmplitude.", ex );
        }
    }
    public float Measure_VPeak_Peak( int waveforms, float timeout ) {
        try {
            float result;
            gpib_.Write( ":SYSTEM:MODE?" );
            string oldMode = gpib_.Read( );
            SetEyeMode( false );
            gpib_.Write( ":ACQ:RUNT WAV," + waveforms.ToString( ) );
            gpib_.Write( ":RUN" );
            WaitUntilAllComplete( timeout );
            SetHeadersOff( );
            gpib_.Write( ":MEASURE:SOURCE CHANNEL1" );
            Thread.Sleep( 100 );
            //gpib_.Write( ":MEASURE:OSCilloscope:VAMPLITUDE:MEAN?" );
            Thread.Sleep( 100 );
            //gpib_.Write( ":MEASURE:VAMPLITUDE:STDDEV?" );
            gpib_.Write( ":MEASURE:VAMPLITUDE?" );
            Thread.Sleep( 100 );
            result = ReadFloat( );
            //gpib_.Write( ":MEASURE:VPP:MEAN?" );
            //SetHeadersOff( );
            gpib_.Write( ":MEASURE:VPP?" );
            Thread.Sleep( 100 );
            //gpib_.Write( ":MEASURE:VPP:STDDEV?" );
            result = ReadFloat( );
            gpib_.Write( ":SYSTEM:MODE " + oldMode );
            return result;
        }
        catch( Exception ex ) {

            throw new Ag86100Error( "Error at Measure_VPeak_Peak.", ex );
        }
    }
    public string GetWholeMeasrueResults()
    {
        try
        {
            gpib_.Write(":MEASURE:RESULTS?");
            string wholeMsg = gpib_.Read( );
            return wholeMsg;
        }
        catch (Exception ex)
        {
            
            throw new Ag86100Error( "Error at GetWholeMeasrueResults.", ex );
        }
    }
    public bool SetDefine_Thresholds( ) { 
        //[:MEASure:DEFine] THR {{STAN} | {PERcent,<upper_pct>,<middle_pct>,<lower_pct>} |
        //{VOLTage, <upper_volts>,<middle_volts>,<lower_volts>}}<NL>
        try {
            gpib_.Write( ":MEASure:DEFine THResholds, PERcent,80,50,20" ); 
            return !ErrorOccured( );
        }
        catch( Exception ex ) {
            
            throw new Ag86100Error( "Error measuring Define setting.", ex );
        }

    }
    public virtual bool SetFilter( bool enabled ) {
      try {
        // Clear event status register.
        Driver.GetEventStatusRegister( );
        // If we want a filter, we enable it and make sure the right filter is used.
        if( enabled ) {
          // Turn on filter.
          gpib_.Write( "CHANNEL" + settings_.Channel.ToString( ) + ":FILTER ON" );
          // Select filter. We use the dictionary to get the right gpib string, defined in the constructor.
          //gpib_.Write( "CHANNEL" + settings_.Channel.ToString( ) + ":FSELECT " + filterStrings[ settings_.Filter ] );
            // comment out for Coherent, need to fix for both cases!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
          //gpib_.Write( "CHANNEL" + settings_.Channel.ToString( ) + ":FSELECT " + filterStrings[Ag86100FilterOption.Filter25781 ] );

        }
        else {
          // Turn filter off.
          gpib_.Write( "CHANNEL" + settings_.Channel.ToString( ) + ":FILTER OFF" );
          // Select bandwidth, using dictionary for the gpib string.
          gpib_.Write( "CHANNEL" + settings_.Channel.ToString( ) + ":BANDWIDTH " + bandwidthStrings[ settings_.Bandwidth ] );
        }

        return !ErrorOccured( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error setting filter/bandwidth: " + ( enabled ? settings_.Filter.ToString( ) : settings_.Bandwidth.ToString( ) ), ex );
      }
    }

    public bool SaveScreenImage( string filename, Ag86100ImageArea area, Ag86100ImageMode mode, string label ) {
      lock( dcaSync ) {
        screenImageMS = null;
        string localFullname = EquipmentIpAddress + @"user (d)\User Files\aaa.jpg";//Tedros
        //string localFullname = @"\\10.34.22.156\user (d)\User Files\aaa.jpg";//Sylvia's DCA

        string localFilename = @"D:\User Files\aaa.jpg";
        screenImageFileName = filename;
        FileInfo localfi = new FileInfo( localFilename );
        try {
          // Remove measurements from screen, add label 
          //gpib_.Write( ":MEASURE:CLEAR" );
          gpib_.Write( ":DISP:LAB \"" + label + "\"" );

          // Delete file if it already exists
          if( localfi.Exists )
              localfi.Delete( );
          for( int n = 0; n < 100; n++ ) {
            Thread.Sleep( 50 );
            localfi.Refresh( );
            if( !localfi.Exists )
              break;
          }

          // Take screenshot
          gpib_.Write( ":DISK:SIMAGE \"" + localfi + "\"," + imageAreaStrings[ area ] + "," + imageModeStrings[ mode ] );

          Thread.Sleep( 1000 );

          System.IO.File.Copy( localFullname, screenImageFileName, true );

            // Wait a bit for the file to be written.
          Thread.Sleep( 200 );
          FileInfo fi = new FileInfo( filename );
          int timeout = 10000;
          while( !fi.Exists ) {
            Thread.Sleep( 50 );
            timeout -= 50;
            if( timeout < 0 )
              break;
            fi.Refresh( );
          }
          // Remove the label
          gpib_.Write( ":DISP:LABEL:DALL" );

          // If the new file exists now, we have success.
          fi.Refresh( );
          if( fi.Exists )
            return true;
          return false;
        }
        catch( Exception ex ) {
          throw new Ag86100Error( "Error saving screen image with label.", ex );
        }
      }
    }
    public bool SaveScreenImage( string filename ) {
      return SaveScreenImage( filename, settings_.ImageArea, Ag86100ImageMode.Inverted, "" );
    }
    public bool SaveScreenImage( string filename, string label ) {
      return SaveScreenImage( filename, settings_.ImageArea, Ag86100ImageMode.Inverted, label );
      //return SaveScreenImage( filename, settings_.ImageArea, Ag86100ImageMode.Normal, label ); // background is in black
    }
    /// <summary>
    /// The DCA screen image read into memory stream from the same file location 
    /// it was saved to by SaveScreenImage( ... )
    /// </summary>
    public Image ScreenImage {
      get {
        lock( dcaSync ) {
          int delay = 100, count = 0;

          while( screenImageMS == null) {
            try {
              using( var fs = File.Open( screenImageFileName, FileMode.Open, FileAccess.Read, FileShare.None ) ) {

                // Read FileStream into MemoryStream
                screenImageMS = new MemoryStream( );
                screenImageMS.SetLength( fs.Length );
                fs.Read( screenImageMS.GetBuffer( ), 0, ( int )fs.Length );
                screenImageMS.Flush( );

                // Release the FileStream resource (i.e. the image file)
                fs.Close( );
                //if( screenImageMS.IsNull( ) )
                if( screenImageMS == null )
                  throw new IOException( "Memory stream is empty." );
              }
            }
            catch( IOException ioex ) {
              if( count > 9 ) {
                  throw new Exception( "Could not read image from file.", ioex );
                //throw new TeCSA8000Error( "Could not read image from file.", ioex );
              }
              else {
                screenImageMS = null;
                Thread.Sleep( delay );
                count++;
              }
            }
          }
          return Image.FromStream( screenImageMS );
        }
      }
    }

    /// <summary>
    /// Method used to parse a float value from an incoming response string.
    /// An unavailable value is represented by 9.9999e37, which we translate into float.NaN.
    /// </summary>
    /// <returns>Float value, parsed from incoming response string</returns>
    protected float ReadFloat( ) {
      try {
        string answer = gpib_.Read( ).Trim( );

        float result = 0;
        if( !float.TryParse( answer, NumberStyles.Any, culture_, out result ) )
          throw new Ag86100Error( "Can not parse response value to float (ReadFloat): \"" + answer + "\"" );

        if( result > 9.0e37f )
          return float.NaN;

        return result;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error GPIB reading float.", ex );
      }
    }
    /// <summary>
    /// Method used to read a string value from an incoming response string
    /// </summary>
    /// <returns>String value, read from incoming response string</returns>
    protected string ReadString( ) {
      try {
        string answer = gpib_.Read( ).Trim( );

        return answer;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error GPIB reading string.", ex );
      }
    }

    /// <summary>
    /// Method used to turn system response header off, used with queries
    /// </summary>
    protected void SetHeadersOff( ) {
      try {
        gpib_.Write( "SYSTEM:HEADER OFF" );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error setting headers' state", ex );
      }
    }
    /// <summary>
    /// Method that halts the thread until the oscilloscope has finished all pending instructions.
    /// Uses the Event Status Register. We could also use the ALER? command for acquisition limited measurement.
    /// </summary>
    /// <param name="timeout">Maximum time to wait in milliseconds.</param>
    /// <returns>A bool indicating whether the wait finished properly. True if properly.</returns>
    protected bool WaitUntilAllComplete( float timeout ) {
      try {
        bool done = false, error = false;
        float timeWaited = 0;
        float timeWaitStep = 500;

        // Set the OPC bit to 1 when the operation completes.
        gpib_.Write( "*OPC" );

        // Clear the Event Status Register
        byte currentESRValue = Driver.GetEventStatusRegister( );

        while( !done && !error && timeWaited <= timeout ) {

          if( ( currentESRValue & ESR.OPC ) > 0 )
            done = true;
          if( ( currentESRValue & ( ESR.CME | ESR.DDE | ESR.EXE | ESR.QYE ) ) > 0 )
            error = true;

          Thread.Sleep( ( int )timeWaitStep );
          timeWaited = timeWaited + timeWaitStep;

          // Reading the ESR clears it!
          currentESRValue = Driver.GetEventStatusRegister( );
        }

        if( error || timeWaited > timeout )
          return false;

        return true;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error in waiting for comleting operations", ex );
      }
    }
    /// <summary>
    /// Method that checks whether an error has occurred.
    /// Uses the Event Status Register.
    /// </summary>
    /// <returns>True if an error occurred in the instrument.</returns>
    protected bool ErrorOccured( ) {
      try {
        if( ( Driver.GetEventStatusRegister( ) & ( ESR.CME | ESR.DDE | ESR.EXE | ESR.QYE ) ) > 0 )
          return true;

        return false;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error occured getting error status.", ex );
      }
    }
    /// <summary>
    /// Get the filter options available from the current module
    /// </summary>
    /// <returns>True if operation was successful</returns>
    protected bool GetFilterOptions( ) {
      filterStrings = new Dictionary<Ag86100FilterOption, string>( );
      bool sucess = false;

      try {
        String response = gpib_.Query( "CHANnel" + settings_.Channel.ToString( ) + ":FDEScription?" );
        String[ ] values = response.Split( ',' );

        int numberOfFilters = int.Parse( values[ 0 ] );

        for( int fx = 1; fx <= numberOfFilters; fx++ ) {
          Ag86100FilterOption fOption;
          Double fBandWidth = Double.Parse( values[ fx ].Split( ' ' )[ 0 ] );
          String suffix = values[ fx ].Split( ' ' )[ 1 ].Substring( 0, 1 );
          Double multiplier = 1;
          if( suffix.Equals( "G" ) )
            multiplier = 1E9;
          if( suffix.Equals( "M" ) )
            multiplier = 1E6;
          if( suffix.Equals( "k" ) )
            multiplier = 1E3;

          sucess = Enum.TryParse<Ag86100FilterOption>( "Filter" + ( int )( fBandWidth * multiplier / 1E6 ), out fOption );
          filterStrings.Add( fOption, "FILT" + fx );
        }
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Failed getting filter options from DCA plugin", ex );
      }
      return !ErrorOccured( );
    }

    public float MaskMeasureMargin( ) {
      try {
        MaximizeMargin( );
        return maskMarginPercent;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring mask margin.", ex );
      }
    }

    protected bool MaximizeMargin( ) {
      return MaximizeMargin( 0 );
    }

    protected bool MaximizeMargin( int percent ) {
      try {
        MaskSetPercent( percent );
        float hits = CountHits( );
        if( hits == 0 ) { // there were no hits
          if( maskMarginPercent < 0 )
            return true;
          else // greater than or equal to zero
            return MaximizeMargin( maskMarginPercent++ );
        }
        else { // there were hits
          if( maskMarginPercent <= 0 )
            return MaximizeMargin( maskMarginPercent-- );
          else{ // positive
            maskMarginPercent--; // since margin was increased to find a hit, know it's one less
            return true;
          }
        }
      }
      catch( Exception ) {
        return false; // if for some reason the optimization didn't work, returns false
      }
    }

    protected float CountHits( ) {
      try {
        gpib_.Write( ":SYSTEM:HEADER OFF" );
        gpib_.Write( ":MTEST:COUNT:HITS? TOTal" ); //total includes hits in the margin and in the mask
        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error counting hits.", ex );
      }
    }

    public bool MaskLoad( string filename ) {
      try {
        gpib_.Write( String.Format( ":MTEST:LOAD \"{0}\"", filename ) );
        return true;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error loading mask from the file {0}.", ex );
      }
    }

    public bool MaskSetPercent( int percent ) {
      throw new NotImplementedException( );
    }

    public bool MaskClear( ) {
      throw new NotImplementedException( );
    }

    public bool MaskAlign( ) {
      try {
        gpib_.Write( ":MTEST:ALIGN" );
        return true;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error aligning mask.", ex );
      }
    }

    public void DoAutoMeasurement( ) {
        try {
            gpib_.Write( ":MEASURE:CLEAR" );
            gpib_.Write( ":AUTOSCALE" );
            gpib_.Write( ":AUTOSCALE?" );
            string result = ReadString( );
            if( result != "" )
                return;

        }
        catch( Exception ex ) {

            throw new Ag86100Error( "Error aligning mask.", ex );
        }
    }

    public void SetHISTMode(string OnOff)
    {
        try {
            gpib_.Write(":HIST:MODE "+ OnOff);
            string result = ReadString();
            if ( result != "")
                return;
        }
        catch (Exception ex)
        {

            throw new Ag86100Error("Error aligning mask.", ex);
        }
    }

  }

  public class Ag86100A : Ag86100C, IDisposable {
    public override bool PerformAutoScale( float dataRate ) {
      bool result = false;

      try {
        Double TriggerLevel = GetTriggerLevel( );
        result = base.PerformAutoScale( 0 );
        SetTriggerLevel( TriggerLevel );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error performing autoscale", ex );
      }
      return result;
    }

    public override bool PerformHorizontalAlign( float dataRate ) {
      try {
        if( dataRate != 0 ) {
          gpib_.Write( ":TIMEBASE:SCALE " + ( settings_.EyesOnScreen / 10.0 / dataRate ).ToString( "0.00e0" ) );
          return ( !ErrorOccured( ) );
          //return PerformAutoScale( 0 );
        }
        else
          return false;
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error performing horizontal align.", ex );
      }
    }
  }

  public class Ag86100A_XingFix : Ag86100A, IDisposable {
    public override float MeasureCrossing( ) {
      try {
        //gpib_.Write(":MEASURE:CGRADE:CROSSING? CHANNEL" + settings_.Channel.ToString());
        gpib_.Write( ":MEASURE:CGRADE:CROSSING?" );
        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new Ag86100Error( "Error measuring Eye crossing.", ex );
      }
    }
  }
  /// <summary>
  /// Enumerator values for the mode of the oscilloscope
  /// </summary>
  public enum Ag86100OscilloscopeMode {
    Eye,
    Oscilloscope,
    Tdr,
    Jitter
  };

  public enum Ag86100FilterOption {
    Filter1063,
    Filter1250,
    Filter2125,
    Filter2488,
    Filter2500,
    Filter9953,
    Filter10312,
    Filter10518,
    Filter10664,
    Filter10709,
    Filter17000,
    Filter25781,
    Filter27739,
    Filter39813,
    Filter43018
  }
  public enum Ag86100BandWidthOption {
    Low,
    High
  }
  public enum Ag86100ImageArea {
    Screen,
    Graticule
  }
  public enum Ag86100ImageMode {
    Normal,
    Inverted,
    Monochrome
  }

}
public static class ESR {
    public static byte OPC = 0x01, RQC = 0x02, QYE = 0x04, DDE = 0x08, EXE = 0x10, CME = 0x20, PON = 0x80;
}