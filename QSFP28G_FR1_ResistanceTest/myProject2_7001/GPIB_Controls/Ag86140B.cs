using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;
//using Syntune.Core;
//using Syntune.Interfaces;
//using Syntune.Utils;

namespace Finisar {
  #region Class Ag86140Error

  // Class Ag86140Error

  public class Ag86140BError : ArgumentException {
    public Ag86140BError( string errorMessage ) :
      base( "Ag86140B Error: " + errorMessage ) {
    }

    public Ag86140BError( )
      : base( "Ag86140B Error: no message" ) {
    }
  }
  #endregion

  public class Ag86140SpectralData {
    public Ag86140SpectralData( string OsaDataString ) {

      string pattern = @"(-?\d+\.?\d*[eE]?[+-]?\d*)";
      MatchCollection matches = Regex.Matches( OsaDataString, pattern );
      if( matches.Count != 8 )
        throw new InstrumentError( "[Ag86140B] Unexpected answer for analysis data: " + OsaDataString );
      List<float> numbers = new List<float>( 8 );
      foreach( Match m in matches ) {
        float f = float.Parse( m.Value, CultureInfo.InvariantCulture );
        numbers.Add( f );
      }
      this.peakWavelength_ = double.Parse( matches[ 0 ].Value, CultureInfo.InvariantCulture );
      this.modeOffset = double.Parse( matches[ 1 ].Value, CultureInfo.InvariantCulture );
      this.stopBand = double.Parse( matches[ 2 ].Value, CultureInfo.InvariantCulture );
      this.centerOffset = double.Parse( matches[ 3 ].Value, CultureInfo.InvariantCulture );
      this.smsr = double.Parse( matches[ 4 ].Value, CultureInfo.InvariantCulture );
      this.peakAmplitude = double.Parse( matches[ 5 ].Value, CultureInfo.InvariantCulture );
      this.bandwidth = double.Parse( matches[ 6 ].Value, CultureInfo.InvariantCulture );
      this.bandwidthAmplitude = double.Parse( matches[ 7 ].Value, CultureInfo.InvariantCulture );

      this.peakWavelength_ *= 1.0E9f;   // Convert [m] to [nm]
      this.modeOffset *= 1.0E9f;        // Convert [m] to [nm]
      this.stopBand *= 1.0E9f;          // Convert [m] to [nm]
      this.centerOffset *= 1.0E9f;      // Convert [m] to [nm]
      this.bandwidth *= 1.0E9f;         // Convert [m] to [nm]
    }
    private float GetNextValue( ref String CommaSeparatedString ) {
      string nextValueString;
      int StopPos = CommaSeparatedString.IndexOf( "," );
      if( CommaSeparatedString.Length == 0 )
        return -1;
      nextValueString = CommaSeparatedString.Substring( 0, StopPos );
      CommaSeparatedString = CommaSeparatedString.Substring( StopPos + 1,
                             CommaSeparatedString.Length - StopPos - 1 );
      return ( float )Convert.ToDouble( nextValueString, CultureInfo.InvariantCulture );

    }
    public double PeakWavelength_nm {
      get {
        return peakWavelength_; // *1.0E9; peakWavelength_ is already in [nm] // mis
      }
      set {
        peakWavelength_ = value; // / 1.0E9f; peakWavelength_ is already in [nm] // mis
      }
    }
    public double PeakFrequency_THz {
      get {
        return 1.0E-3 * Constants.SPEED_OF_LIGHT / peakWavelength_;
      }
      set {
        peakWavelength_ = value * Constants.SPEED_OF_LIGHT / 1.0E-3f;
      }
    }
    public double peakAmplitude;       // [dBm]
    public double smsr;                // [dB]
    public double modeOffset;          // [nm]
    public double stopBand;            // [nm]
    public double centerOffset;        // [nm]
    public double bandwidth;           // [nm]
    public double bandwidthAmplitude;  // [dB]
    private double peakWavelength_;    // [nm]
    //private double test;

  }
  /*
  public class SpectrumTrace {
    public float StartWavelength;
    public float StopWavelength;
    public List<float> points;
  }*/
  #region Ag86140B enums
  /* Moved to Interfaces.cs OSADisplayState
  [Serializable]
  public enum Ag86140BDisplayState {
    ON = 0,
    OFF
  }
   */
  [Serializable]
  public enum Ag86140BBufferState {
    ON = 0,
    OFF
  }
  [Serializable]
  public enum Ag86140BSweepTimeMode {
    AUTO = 0,
    MANUAL
  }
  [Serializable]
  public enum Ag86140BVideoBandwidthMode {
    AUTO = 0,
    MANUAL
  }
  #endregion

  static class ExtensionMethods {
    public static T ToEnum<T>( this string s ) {
      int result;
      if( Int32.TryParse( s, out result ) )
        return ( T )( object )result;
      else
        return ( T )Enum.Parse( typeof( T ), s );
    }
  }

  [Serializable]
  public class Ag86140BSettings {
    public byte GpibAddress = 23;
    public OSASweepMode SweepMode = OSASweepMode.SINGLE;
    public OSADisplayState DisplayState = OSADisplayState.ON;
    public Ag86140BBufferState BufferState = Ag86140BBufferState.ON;
    public Ag86140BSweepTimeMode SweepTimeMode = Ag86140BSweepTimeMode.AUTO;
    public Ag86140BVideoBandwidthMode VideoBandwidthMode = Ag86140BVideoBandwidthMode.AUTO;
    public bool isSpectralApplicationActive_ = false;
    public float ResolutionBandwidth = 0.06f;
    public float VideoBandwidth = 1000.0f;
    public float Sensitivity = -70;
    public float ReferenceLevel = 10;
    public double VerticalScale = 10;
    public int NrOfTracePoints = 5001;
    public float CenterWavelength = 1325.0f;
    public float SpanWavelength = 150.0f;
    public float SweepStartFrequency;
    public float SweepStopFrequency;
    public float SMSRCorrection = 0f;
    public bool UseSMSRCorrection = true;
    public float SweepTime = 0.50f;
    public NationalInstruments.NI4882.TimeoutValue Timeout = NationalInstruments.NI4882.TimeoutValue.T1000s;
  }


  // Class Ag86140B

  public class Ag86140B : Instrument, IOSA, IWaveMeter {
    //#define TRACE(msg) OutputDebugString(msg)
    const string CONT_ON = "INIT:CONT ON";
    const string CONT_OFF = "INIT:CONT OFF";
    const string SINGLE_SWEEP = "INIT:IMM";
    const string AUTO_ALIGN = "CAL:ALIG:AUTO";
    const string AUTO_MEASURE = "DISP:WIND:TRAC:ALL:SCAL:AUTO";
    const string DISPLAY_ON = "DISP ON";
    const string DISPLAY_OFF = "DISP OFF";
    const string BUFFER_ON = "SYST:COMM:GPIB:BUFF ON";
    const string BUFFER_OFF = "SYST:COMM:GPIB:BUFF OFF";
    const string START_DFB_APPL = "CALC:SOUR:TEST DFB";
    const string STOP_DFB_APPL = "CALC:SOUR:TEST OFF";
    const string GET_DFB_DATA = "CALC:SOUR:DATA?";

    const string SET_POWER_UNIT_DBM = "UNIT:POW DBM";
    const string SET_SENSITIVITY = "SENS:POW:DC:RANG:LOW";         //Arg
    const string SET_RESOLUTION = "SENS:BAND:RES";                //Arg
    const string SET_REF_LEVEL = "DISP:WIND:TRAC:Y1:SCAL:RLEV";  //Arg
    const string SET_SCALE_DIV = "DISPLAY:WINDOW:TRACE:Y1:SCALE:PDIVISION";  //Arg
    const string SET_WL_CENTER = "SENS:WAV:CENT";                //Arg
    const string SET_WL_START = "SENS:WAV:STAR";                //Arg
    const string SET_WL_STOP = "SENS:WAV:STOP";                //Arg
    const string SET_WL_SPAN = "SENS:WAV:SPAN";                //Arg
    const string SET_SRAN_LOW = "SENS:WAV:SRAN:LOW";            //Arg
    const string SET_SRAN_UPP = "SENS:WAV:SRAN:UPP";            //Arg
    const string SRAN_OFF = "SENS:WAV:SRAN OFF";
    const string SET_TRACE_POINTS = "SENS:SWE:POIN";                //Arg: Nr of Points
    const string GET_TRACE = "TRAC:DATA:Y? TRA";             //Arg: Trace name
    const string DATA_FORMAT_ASCII = "FORM ASCII";
    const string SWEEP_TIME_AUTO = "SENS:SWE:TIME:AUTO";
    const string SET_SWEEP_TIME = "SENS:SWE:TIME";
    const string VIDEOBANDWIDTH_AUTO = "SENS:BAND:VID:AUTO";
    const string SET_VIDEOBANDWIDTH = "SENS:BAND:VID";

    const string SET_MARK1_TO_MAX = "CALC:MARK1:MAX";
    const string SET_MARK2_TO_MAX = "CALC:MARK2:MAX";
    const string SET_MARK2_TO_NEXT = "CALC:MARK2:MAX:NEXT";
    const string SET_MARK1_TO_CENTER = "CALC:MARK1:SCEN";
    const string GET_MARK1_WL = "CALC:MARK1:X?";
    const string GET_MARK1_POWER = "CALC:MARK1:Y?";
    const string GET_MARK2_POWER = "CALC:MARK2:Y?";
    const string MARK_TO_REF = "CALC:MARK:SRL";
    const string SET_MARK_X_FREQ = "CALC:MARK:X:READ FREQ";
    const string SET_MARK_X_WL = "CALC:MARK:X:READ WAV";

    private Ag86140BSettings settings_ = new Ag86140BSettings( );
    private Ag86140SpectralData spectralDataCache_ = null;
    private GpibDriver gpib_ = null;
    private bool doWaitForOperations_ = true;
    private bool isSpectralApplicationActive_ = false;
    //private bool isContinuousOn_ = false;

    // Constructors
    public Ag86140B( ) {
    }

    public Ag86140B( byte address ) :
      this( address, NationalInstruments.NI4882.TimeoutValue.T1000s ) {
    }
    public Ag86140B( byte address, NationalInstruments.NI4882.TimeoutValue timeout ) {
      gpib_ = new GpibDriver( address, timeout );
      gpib_.Reset( );
      GpibIdentity id;
      id = gpib_.GetIdentity( );

#if !TEST
      if( id.model.Substring( 0, 4 ) != "8614" )
        throw new Ag86140BError( "Invalid model number" );
      // TODO: Design way to test firmware version 
      //if( id.firmwareVersion < "B.05.00" )
      // throw Ag86140BError( "Invalid firmware version" );
#endif

      Initialise( false );
      DoWaitForOperations = true;
      StopSpectralApplication( );
      //DoWaitForOperations = false;   //It's not nice to force the user to deal with this optimization.
    }

    public void SaveSettings( string xmlFilePath ) {
      XmlSerializer xmlFormat = new XmlSerializer( typeof( Ag86140BSettings ),
        new Type[ ] { typeof( OSASweepMode ), typeof( OSADisplayState ),
           typeof( Ag86140BBufferState ), typeof (Ag86140BSweepTimeMode), typeof(Ag86140BVideoBandwidthMode) } );
      FileStream fStream = new FileStream( xmlFilePath, FileMode.Create, FileAccess.Write, FileShare.None );
      xmlFormat.Serialize( fStream, settings_ );
      fStream.Close( );
    }

    public GpibDriver Gpib {
      get {
        return gpib_;
      }
      set {
        gpib_ = value;
      }
    }

    //public object XmlSettings {
    //  get {
    //    return settings_;
    //  }
    //  set {
    //    if ( value is Ag86140BSettings ) {
    //      settings_ = (Ag86140BSettings ) value;
    //      //TODO: ResetInstrument( );
    //    }
    //    //else 
    //      //throw new InstrumentError( "
    //  }
    //}

    public void
    Initialise( bool wait ) {
      gpib_.Write( SET_POWER_UNIT_DBM );
      gpib_.Write( DATA_FORMAT_ASCII );
      //SetContinuousOn( wait );
      //if( wait )
      //  gpib_.Wait(  );
      //isContinuousOn_ = true;
    }
    //--------------------------------------------------------------------------
    /// <summary>
    /// Set the SweepMode of the spectrum analyzer. 
    /// Ag86140BSweepMode.CONTINUOUS = keep sweeping continuously.
    /// Ag86140BSweepMode.SINGLE = No sweeps are made unless PerformSingleSweep 
    /// is called.
    /// </summary>
    public OSASweepMode SweepMode {
      get {
        //return settings_.SweepMode;
        return GetSweepMode( );
      }
      set {
        //settings_.SweepMode = value;
        switch( value ) {
          case OSASweepMode.CONTINUOUS:
            SetContinuousOn( true );
            break;
          case OSASweepMode.SINGLE:
            SetContinuousOff( true );
            break;
        }
      }
    }

    private OSASweepMode GetSweepMode( ) {
      gpib_.Write( "INIT:CONT?" );
      return gpib_.ReadLast( ).ToEnum<OSASweepMode>( );
    }

    private void SetContinuousOn( bool wait ) {
      spectralDataCache_ = null;
      gpib_.Write( CONT_ON );
      if( wait )
        gpib_.Wait( );
      //isContinuousOn_ = true;
    }

    private void SetContinuousOff( bool wait ) {
      spectralDataCache_ = null;
      gpib_.Write( CONT_OFF );
      if( wait )
        gpib_.Wait( );
      //isContinuousOn_ = false;
    }

    public virtual OSADisplayState DisplayState {
      get {
        //return settings_.DisplayState;
        return GetDisplayState( );
      }
      set {
        //settings_.DisplayState = value;
        switch( value ) {
          case OSADisplayState.ON:
            SetDisplayOn( true );
            break;
          case OSADisplayState.OFF:
            SetDisplayOff( true );
            break;
        }
      }
    }

    private OSADisplayState GetDisplayState( ) {
      gpib_.Write( "DISP?" );
      return gpib_.ReadLast( ).ToEnum<OSADisplayState>( );
    }

    private void SetDisplayOn( bool wait ) {
      gpib_.Write( DISPLAY_ON );
      if( wait )
        gpib_.Wait( );
    }

    private void SetDisplayOff( bool wait ) {
      gpib_.Write( DISPLAY_OFF );
      if( wait )
        gpib_.Wait( );
    }

    public virtual Ag86140BBufferState BufferState {
      get {
        //return settings_.BufferState;
        return GetBufferState( );
      }
      set {
        //settings_.BufferState = value;
        switch( value ) {
          case Ag86140BBufferState.ON:
            SetBufferOn( true );
            break;
          case Ag86140BBufferState.OFF:
            SetBufferOff( true );
            break;
        }
      }
    }
    /// <summary>
    /// Controls whether the sweep time is set by the instrument (auto) or by the user/system (manual)
    /// </summary>
    public virtual Ag86140BSweepTimeMode SweepTimeMode {
      get {
        return settings_.SweepTimeMode;
      }
      set {
        settings_.SweepTimeMode = value;
        switch( value ) {
          case Ag86140BSweepTimeMode.AUTO:
            SetSwepTimeModeAuto( DoWaitForOperations );
            break;
          case Ag86140BSweepTimeMode.MANUAL:
            //Do nothing. Expect that a manual sweep time is set later.
            break;
        }
      }
    }
    /// <summary>
    /// Controls whether the video bandwidth is set by the instrument (auto) or by the user/system (manual)
    /// </summary>
    public virtual Ag86140BVideoBandwidthMode VideoBandwidthMode {
      get {
        return settings_.VideoBandwidthMode;
      }
      set {
        settings_.VideoBandwidthMode = value;
        switch( value ) {
          case Ag86140BVideoBandwidthMode.AUTO:
            SetSwepTimeModeAuto( DoWaitForOperations );
            break;
          case Ag86140BVideoBandwidthMode.MANUAL:
            //Do nothing. Expect that a manual video bandwidth is set later.
            break;
        }
      }
    }

    /// <summary>
    /// Controls whether commands should wait for an operation to complete before 
    /// returning.
    /// </summary>
    public virtual bool DoWaitForOperations {
      get {
        return doWaitForOperations_;
      }
      set {
        doWaitForOperations_ = value;
      }
    }

    public virtual float Sensitivity {
      get {
        //return settings_.Sensitivity;
        return GetSensitivity( );
      }
      set {
        //settings_.Sensitivity = value;
        SetSensitivity( value, DoWaitForOperations );
      }
    }

    /// <summary>
    /// Set/get the video bandwidth in Hz
    /// </summary>
    public virtual float VideoBandwidth {
      get {
        return GetVideoBandwidth( );
      }
      set {
        if( VideoBandwidthMode == Ag86140BVideoBandwidthMode.MANUAL ) {
          //settings_.VideoBandwidth = value;
          SetVideoBandwidth( value, DoWaitForOperations );
        }
        else
          throw new Ag86140BError( "Attempt to set video bandwidth manually when sweep time mode is AUTO" );
      }
    }

    /// <summary>
    /// Set/get the resolution bandwidth in nm
    /// </summary>
    public virtual float ResolutionBandwidth {
      get {
        //return settings_.ResolutionBandwidth;
        return GetResolutionBandwidth( );
      }
      set {
        //settings_.ResolutionBandwidth = value;
        SetResolutionBandwidth( value, DoWaitForOperations );
      }
    }

    public virtual float ReferenceLevel {
      get {
        //return settings_.ReferenceLevel;
        return GetReferenceLevel( );
      }
      set {
        //settings_.ReferenceLevel = value;
        SetReferenceLevel( value, DoWaitForOperations );
      }
    }

    /// <summary>
    /// Set/get the vertical scale in dB/div
    /// </summary>
    public virtual double VerticalScale {
      get {
        return GetVerticalScale( );
      }
      set {
        SetVerticalScale( value, DoWaitForOperations );
      }
    }

    /// <summary>
    /// Get/set the center wavelength in nm
    /// </summary>
    public virtual float CenterWavelength {
      get {
        //return settings_.CenterWavelength;
        return GetCenterWavelength( );
      }
      set {
        //settings_.CenterWavelength = value;
        SetCenterWavelength( value, DoWaitForOperations );
      }
    }

    public virtual float StartWavelength {
      get {
        //return settings_.StartWavelength;
        return GetStartWavelength( );
      }
      set {
        //settings_.StartWavelength = value;
        SetStartWavelength( value, DoWaitForOperations );
      }
    }

    public virtual float StopWavelength {
      get {
        //return settings_.StopWavelength;
        return GetStopWavelength( );
      }
      set {
        //settings_.StopWavelength = value;
        SetStopWavelength( value, DoWaitForOperations );
      }
    }

    /// <summary>
    /// Get/set the wavelength span in nm
    /// </summary>
    public virtual float SpanWavelength {
      get {
        //return settings_.SpanWavelength;
        return GetSpanWavelength( );
      }
      set {
        //settings_.SpanWavelength = value;
        SetSpanWavelength( value, DoWaitForOperations );
      }
    }

    public virtual float CenterFrequency {
      get {
        //return settings_.CenterFrequency;
        return GetCenterFrequency( );
      }
      set {
        //settings_.CenterFrequency = value;
        SetCenterFrequency( value, DoWaitForOperations );
      }
    }

    public virtual float StartFrequency {
      get {
        //return settings_.StartFrequency;
        return GetStartFrequency( );
      }
      set {
        //settings_.StartFrequency = value;
        SetStartFrequency( value, DoWaitForOperations );
      }
    }

    public virtual float StopFrequency {
      get {
        //return settings_.StopFrequency;
        return GetStopFrequency( );
      }
      set {
        //settings_.StopFrequency = value;
        SetStopFrequency( value, DoWaitForOperations );
      }
    }

    public virtual float SpanFrequency {
      get {
        //return settings_.SpanFrequency;
        return GetSpanFrequency( );
      }
      set {
        // settings_.SpanFrequency = value;
        SetSpanFrequency( value, DoWaitForOperations );
      }
    }
    /// <summary>
    /// Get/set the sweep time in seconds.
    /// </summary>
    public virtual float SweepTime {
      get {
        return GetSweepTime( );
      }
      set {
        if( SweepTimeMode == Ag86140BSweepTimeMode.MANUAL ) {
          //settings_.SweepTime = value;
          SetSweepTime( value, DoWaitForOperations );
        }
        else
          throw new Ag86140BError( "Attempt to set sweep time manually when sweep time mode is AUTO" );
      }
    }

    public virtual void SetPeak2ReferenceLevel( ) {
      gpib_.Write( SET_MARK1_TO_MAX );
      gpib_.Write( MARK_TO_REF );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    public virtual void SetPeak2Center( bool wait ) {
      gpib_.Write( SET_MARK1_TO_MAX );
      gpib_.Write( SET_MARK1_TO_CENTER );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    public virtual float SweepStartFrequency {
      get {
        //return settings_.SweepStartFrequency;
        return GetStartFrequency( );
      }
      set {
        //settings_.SweepStartFrequency = value;
        setSweepStartFrequency( value, true );
      }
    }
    private void setSweepStartFrequency( float frequency_THz, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}{1:G6} THZ", SET_SRAN_LOW, frequency_THz );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }
    private float GetSweepStartFrequency( ) {
      gpib_.Write( SET_SRAN_LOW + "?" );
      return float.Parse( gpib_.ReadLast( ) );
    }

    public virtual float SweepStopFrequency {
      get {
        //return settings_.SweepStopFrequency;
        return GetSweepStopFrequency( );
      }
      set {
        //settings_.SweepStopFrequency = value;
        setSweepStopFrequency( value, true );
      }
    }
    private float GetSweepStopFrequency( ) {
      gpib_.Write( SET_SRAN_UPP + "?" );
      return float.Parse( gpib_.ReadLast( ) );
    }
    private void setSweepStopFrequency( float frequency_THz, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}{1:G6} THZ", SET_SRAN_UPP, frequency_THz );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    public virtual int NrOfTracePoints {
      get {
        //return settings_.NrOfTracePoints;
        return GetNrOfTracePoints( );
      }
      set {
        //settings_.NrOfTracePoints = value;
        SetNrOfTracePoints( value, DoWaitForOperations );
      }
    }

    public virtual void RemoveSweepLimits( ) {
      gpib_.Write( SRAN_OFF );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    public virtual void PerformSingleSweep( ) {
      spectralDataCache_ = null;
      if( SweepMode == OSASweepMode.CONTINUOUS )
        SweepMode = OSASweepMode.SINGLE;
      gpib_.Write( SINGLE_SWEEP );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    public virtual void PerformAutoAlign( ) {
      spectralDataCache_ = null;
      gpib_.Write( AUTO_ALIGN );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    public virtual void PerformAutoMeasure( ) {
      spectralDataCache_ = null;
      gpib_.Write( AUTO_MEASURE );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    /// <summary>
    /// Sets sweep points, triggers sweep and downloads trave data.
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public virtual OSASpectrumTrace AquireTrace( int length ) {
      bool previousWaitState = DoWaitForOperations;
      DoWaitForOperations = false;
      SweepMode = OSASweepMode.SINGLE;
      //SetContinuousOff( false );
      NrOfTracePoints = length;
      //setNrOfTracePoints( length, false );
      DoWaitForOperations = true;
      PerformSingleSweep( );
      DoWaitForOperations = previousWaitState;
      gpib_.Write( DATA_FORMAT_ASCII );
      gpib_.Write( GET_TRACE );

      OSASpectrumTrace spec = new OSASpectrumTrace( );
      var res = gpib_.Read( );
      spec.points = res.Split( ',' ).Select( s => float.Parse( s, CultureInfo.InvariantCulture ) ).ToList( );
      spec.StartWavelength = StartWavelength;
      spec.StopWavelength = StopWavelength;

      return spec;
    }

    /// <summary>
    /// Downloads trace data from last OSA sweep
    /// </summary>
    /// <returns></returns>
    public virtual OSASpectrumTrace GetTrace( ) {
      gpib_.Write( DATA_FORMAT_ASCII );
      gpib_.Write( GET_TRACE );

      OSASpectrumTrace spec = new OSASpectrumTrace( );
      spec.points = gpib_.Read( ).Split( ',' ).Select( s => float.Parse( s, CultureInfo.InvariantCulture ) ).ToList( );
      spec.StartWavelength = StartWavelength;
      spec.StopWavelength = StopWavelength;

      return spec;
    }

    public virtual void StartSpectralApplication( ) {
      spectralDataCache_ = null;
      gpib_.Write( START_DFB_APPL );
      if( DoWaitForOperations )
        gpib_.Wait( );
      isSpectralApplicationActive_ = true;
    }


    public virtual void StopSpectralApplication( ) {
      spectralDataCache_ = null;
      gpib_.Write( STOP_DFB_APPL );
      if( DoWaitForOperations )
        gpib_.Wait( );
      isSpectralApplicationActive_ = false;
    }

    public virtual double GetPeakFrequency( ) {
      Ag86140SpectralData d = SpectralParameters;
      return d.PeakFrequency_THz;
    }

    public virtual double GetPeakWavelength( ) {
      Ag86140SpectralData d = SpectralParameters;
      return d.PeakWavelength_nm;
    }

    public virtual double GetPeakPower( ) {
      Ag86140SpectralData d = SpectralParameters;
      return d.peakAmplitude;
    }

    public virtual double GetModeOffset() { 
        Ag86140SpectralData d = SpectralParameters;
        return d.modeOffset;
    }

    public virtual double GetStopBand( ) {
        Ag86140SpectralData d = SpectralParameters;
        return d.stopBand;
    }

    public virtual double GetCenterOffset( ) {
        Ag86140SpectralData d = SpectralParameters;
        return d.centerOffset;
    }

    public virtual double GetPeakAmlpitude( ) {
        Ag86140SpectralData d = SpectralParameters;
        return d.peakAmplitude;
    }

    public virtual double GetBandwidth( ) {
        Ag86140SpectralData d = SpectralParameters;
        return d.bandwidth;
    }

    
    public virtual bool UseSMSRCorrection {
      get {
        return settings_.UseSMSRCorrection;
      }
      set {
        settings_.UseSMSRCorrection = value;
      }
    }

    public virtual double GetSmsr( ) {
      Ag86140SpectralData d = SpectralParameters;
      return d.smsr + ( settings_.UseSMSRCorrection ? settings_.SMSRCorrection : 0 );
    }

    public virtual double GetSmsr_( ) {
      if( !isSpectralApplicationActive_ )
        StartSpectralApplication( );

      //gpib_.Write( "POW:RANG:LOCK ON" );

      gpib_.Write( "INIT:IMM" );
      //gpib_.Wait( );
      gpib_.Write( "CALC:SOUR:DATA?" );
      return double.Parse( gpib_.ReadLast( ).Split( ',' )[ 4 ] ) + ( settings_.UseSMSRCorrection ? settings_.SMSRCorrection : 0 );


      //PerformSingleSweep( );

      //gpib_.Write( GET_DFB_DATA );
      //Ag86140SpectralData d = new Ag86140SpectralData( gpib_.Read( ) );
      //return d.smsr;
    }

    public virtual double GetSMSrFast( ) {
      //String peak, nextpeak;
      //gpib_.Write( "INIT:IMM" );
      //gpib_.Wait( );
      //apa = gpib_.Read( );
      gpib_.Write( "CALC:MARK1:MAX" );
      gpib_.Write( "CALC:MARK1:Y?" );
      string peak = gpib_.ReadLast( );
      gpib_.Write( "CALC:MARK1:MAX:NEXT;" );// ! Set marker 1 to the next highest peak
      gpib_.Write( "CALC:MARK1:Y?" );// ! Get amplitude of the next highest
      string nextpeak = gpib_.ReadLast( );
      return double.Parse( peak ) - double.Parse( nextpeak ) + ( settings_.UseSMSRCorrection ? settings_.SMSRCorrection : 0 );
    }

    /// <summary>
    /// Returns spectral data parameter. Note that SMSR is NOT corrected for its offset value here.
    /// </summary>
    public virtual Ag86140SpectralData SpectralParameters {
      get {
        if( !isSpectralApplicationActive_ ) {
          bool previousWaitState = DoWaitForOperations;
          DoWaitForOperations = true;
          StartSpectralApplication( );
          PerformSingleSweep( );
          DoWaitForOperations = previousWaitState;
        }
        if( spectralDataCache_ == null ) {
          gpib_.Write( GET_DFB_DATA );
          string answer = gpib_.Read( );
          spectralDataCache_ = new Ag86140SpectralData( answer );
        }
        return spectralDataCache_;
      }
    }

    private float GetSensitivity( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_SENSITIVITY );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return result;
    }
    private void SetSensitivity( float sensitivity_dBm, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} DBM", SET_SENSITIVITY, sensitivity_dBm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    /// <summary>
    /// Fetch the resolution bandwidth from the instrument
    /// </summary>
    /// <returns>A float representing the resolution bandwidth in nm</returns>
    private float GetResolutionBandwidth( ) {
      //string command;
      //command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_RESOLUTION );
      // sprintf( command, "%s?", SET_RESOLUTION );
      gpib_.Write( SET_RESOLUTION + "?" );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return result * 1e9f;
    }
    /// <summary>
    /// Set the resolution bandwidth of the instrument
    /// </summary>
    /// <param name="resolution_nm">The resolution bandwidth in nm</param>
    /// <param name="wait">A boolean that controls whether the function shall prevent new commands from being processed until complete</param>
    private void SetResolutionBandwidth( float resolution_nm, bool wait ) {
      //string command;
      //command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} NM", SET_RESOLUTION, resolution_nm );
      //sprintf( command, "%s %.2f NM", SET_RESOLUTION, resolution_nm );
      gpib_.Write( SET_RESOLUTION + ( resolution_nm * 1E-9f ).ToString( " 0.00e00" ) );
      if( wait )
        gpib_.Wait( );
    }

    private float GetReferenceLevel( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_REF_LEVEL );
      //sprintf( command, "%s?", SET_REF_LEVEL );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return result;
    }
    private void SetReferenceLevel( float level_dBm, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} DBM", SET_REF_LEVEL, level_dBm );
      // sprintf( command, "%s %.2f DBM", SET_REF_LEVEL, level_dBm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }
    /// <summary>
    /// Get the vertical scale in dB/div
    /// </summary>
    /// <returns>A double representing the vertical scale in dB/div</returns>
    private double GetVerticalScale( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_SCALE_DIV );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      double result = double.Parse( answer );
      return result;
    }
    /// <summary>
    /// Set the vertical scale in dB/div
    /// </summary>
    /// <param name="scale_dBPdiv">A double representing the vertical scale in dB/div</param>
    /// <param name="wait">A bool that determines whether or not to wait for the OSA to complete operation</param>
    private void SetVerticalScale( double scale_dBPdiv, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} DBM", SET_SCALE_DIV, scale_dBPdiv );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    /// <summary>
    /// Get the center wavelength
    /// </summary>
    /// <returns>A float representing the center wavelength in nm</returns>
    private float GetCenterWavelength( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_WL_CENTER );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer ) * 1e9f;
      return result;
    }
    /// <summary>
    /// Set the center wavelength
    /// </summary>
    /// <param name="wavelength_nm">A float representing the wavelength in nm</param>
    /// <param name="wait">A bool that controls whether or not to wait for the instrument to complete operation</param>
    private void SetCenterWavelength( float wavelength_nm, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} NM", SET_WL_CENTER, wavelength_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float
    GetStartWavelength( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_WL_START );
      //sprintf( command, "%s?", SET_WL_START );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return result;
    }
    private void
    SetStartWavelength( float wavelength_nm, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} NM", SET_WL_START, wavelength_nm );
      //sprintf( command, "%s %4.3f NM", SET_WL_START, wavelength_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float
    GetStopWavelength( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_WL_STOP );
      //sprintf( command, "%s?", SET_WL_STOP );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return result;
    }
    private void
    SetStopWavelength( float wavelength_nm, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} NM", SET_WL_STOP, wavelength_nm );
      //sprintf( command, "%s %4.3f NM", SET_WL_STOP, wavelength_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    /// <summary>
    /// Get the wavelength span
    /// </summary>
    /// <returns>A float representing the wavelength span in nm</returns>
    private float GetSpanWavelength( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_WL_SPAN );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer ) * 1e9f;
      return result;
    }
    /// <summary>
    /// Set the wavelength span
    /// </summary>
    /// <param name="wavelength_nm">A float representing the wavelength in nm</param>
    /// <param name="wait">A bool that controls whether or not to wait for the instrument to complete operation</param>
    private void SetSpanWavelength( float span_nm, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} NM", SET_WL_SPAN, span_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float
    GetCenterFrequency( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_WL_CENTER );
      //sprintf( command, "%s?", SET_WL_CENTER );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return Constants.SPEED_OF_LIGHT / result * 1.0E-12f;
      //return static_cast<F32>( SPEED_OF_LIGHT / atof( answer_ ) * 1.0E-12 );
    }
    private void
    SetCenterFrequency( float frequency_THz, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} THZ", SET_WL_CENTER, frequency_THz );
      //sprintf( command, "%s %4.3f THZ", SET_WL_CENTER, frequency_THz );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float
    GetStartFrequency( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_WL_STOP );
      // sprintf( command, "%s?", SET_WL_STOP );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return Constants.SPEED_OF_LIGHT / result * 1.0E-12f;
    }
    void
    SetStartFrequency( float frequency_THz, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} THZ", SET_WL_STOP, frequency_THz );
      //sprintf( command, "%s %4.3f THZ", SET_WL_STOP, frequency_THz );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float
    GetStopFrequency( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_WL_START );
      //sprintf( command, "%s?", SET_WL_START );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return Constants.SPEED_OF_LIGHT / result * 1.0E-12f;
    }
    private void
    SetStopFrequency( float frequency_THz, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G6} THZ", SET_WL_START, frequency_THz );
      //sprintf( command, "%s %4.3f THZ", SET_WL_START, frequency_THz );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float
    GetSpanFrequency( ) {
      return GetStopFrequency( ) - GetStartFrequency( );
    }

    private void
    SetSpanFrequency( float span_THz, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_WL_CENTER );
      //sprintf( command, "%s?", SET_WL_CENTER );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      float center_nm = float.Parse( answer );
      float span_nm = 1.0E-3f * span_THz * center_nm * center_nm / Constants.SPEED_OF_LIGHT;
      SetSpanWavelength( span_nm, wait );
    }

    private int
    GetNrOfTracePoints( ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0}?", SET_TRACE_POINTS );
      //sprintf( command, "%s?", SET_TRACE_POINTS );
      gpib_.Write( command );
      string answer = gpib_.ReadLast( );
      int result = Int16.Parse( answer );
      return result;
    }

    private void
    SetNrOfTracePoints( int nr, bool wait ) {
      string command;
      command = String.Format( CultureInfo.InvariantCulture, "{0} {1:G}", SET_TRACE_POINTS, nr );
      //sprintf( command, "%s %d", SET_TRACE_POINTS, nr );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private Ag86140BBufferState GetBufferState( ) {
      gpib_.Write( "SYST:COMM:GPIB:BUFF?" );
      return gpib_.ReadLast( ).ToEnum<Ag86140BBufferState>( );
    }

    private void SetBufferOn( bool wait ) {
      gpib_.Write( BUFFER_ON );
      if( wait )
        gpib_.Wait( );
    }

    private void SetBufferOff( bool wait ) {
      gpib_.Write( BUFFER_OFF );
      if( wait )
        gpib_.Wait( );
    }

    /// <summary>
    /// Sets the sweep time mode to AUTO
    /// </summary>
    /// <param name="wait">A boolean that controls whether the function shall prevent new commands from being processed until complete</param>
    private void SetSwepTimeModeAuto( bool wait ) {
      gpib_.Write( SWEEP_TIME_AUTO );
      if( wait )
        gpib_.Wait( );
    }
    /// <summary>
    /// Sets the video bandwidth mode to AUTO
    /// </summary>
    /// <param name="wait">A boolean that controls whether the function shall prevent new commands from being processed until complete</param>
    private void SetVideoBandwidthModeAuto( bool wait ) {
      gpib_.Write( VIDEOBANDWIDTH_AUTO );
      if( wait )
        gpib_.Wait( );
    }

    /// <summary>
    /// Aquires the sweep time from the OSA (AUTO or MANUAL mode)
    /// </summary>
    /// <returns>A float representing the sweep time in seconds</returns>
    private float GetSweepTime( ) {
      gpib_.Write( SET_SWEEP_TIME + "?" );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return result;
    }
    /// <summary>
    /// Sets the sweep time in MANUAL mode
    /// </summary>
    /// <param name="sweepTime">A float representing the desired sweep time in seconds</param>
    /// <param name="wait">A boolean that controls whether the function shall prevent new commands from being processed until complete</param>
    private void SetSweepTime( float sweepTime, bool wait ) {
      gpib_.Write( SET_SWEEP_TIME + " " + sweepTime.ToString( "0.0E00" ) );
      if( wait )
        gpib_.Wait( );
    }

    /// <summary>
    /// Fetch the video bandwidth from the instrument
    /// </summary>
    /// <returns>A float representing the video bandwidth in Hz</returns>
    private float GetVideoBandwidth( ) {
      gpib_.Write( SET_VIDEOBANDWIDTH + "?" );
      string answer = gpib_.ReadLast( );
      float result = float.Parse( answer );
      return result;
    }
    /// <summary>
    /// Set the video bandwidth of the instrument
    /// </summary>
    /// <param name="videoBW_Hz">The video bandwidth in Hz</param>
    /// <param name="wait">A boolean that controls whether the function shall prevent new commands from being processed until complete</param>
    private void SetVideoBandwidth( float videoBW_Hz, bool wait ) {
      gpib_.Write( SET_VIDEOBANDWIDTH + videoBW_Hz.ToString( " 0.00e00" ) );
      if( wait )
        gpib_.Wait( );
    }

    protected override void InternalConnect( ) {
      //gpib_ = new GpibDriver( settings_.GpibAddress, NationalInstruments.NI4882.TimeoutValue.T30s );
      gpib_ = new GpibDriver( settings_.GpibAddress, settings_.Timeout ); // changed by Ube
      //gpib_.Reset( );
      //Initialise( false );
      //DoWaitForOperations = true;
      //StopSpectralApplication( );
      //DoWaitForOperations = false;   //It's not nice to force the user to deal with this optimization.
    }

    protected override void InternalDisconnect( ) {

    }

    protected override void InternalReset( ) {
      gpib_.Reset( );
      Initialise( false );
      DoWaitForOperations = true;
      StopSpectralApplication( );
      ApplySettings( );
      //DoWaitForOperations = false;   //It's not nice to force the user to deal with this optimization.

    }



    public override void ApplySettings( ) {
      //gpib_.Write("SWE:TIME:AUTO ON");

      //gpib_.Write( "POW:RANG:AUTO OFF" );
      //gpib_.Write( "pow:rang:low -60dbm" );
      //gpib_.Write( "POW:RANG:LOCK ON" );

      this.SweepMode = settings_.SweepMode;
      this.DisplayState = settings_.DisplayState;
      this.BufferState = settings_.BufferState;
      this.CenterWavelength = settings_.CenterWavelength;
      this.SpanWavelength = settings_.SpanWavelength;
      this.ResolutionBandwidth = settings_.ResolutionBandwidth;
      this.Sensitivity = settings_.Sensitivity;
      this.ReferenceLevel = settings_.ReferenceLevel;
      this.NrOfTracePoints = settings_.NrOfTracePoints;
      this.SweepTimeMode = settings_.SweepTimeMode;
      if( settings_.SweepTimeMode == Ag86140BSweepTimeMode.MANUAL )
        this.SweepTime = settings_.SweepTime;
      this.VideoBandwidthMode = settings_.VideoBandwidthMode;
      if( settings_.VideoBandwidthMode == Ag86140BVideoBandwidthMode.MANUAL )
        this.VideoBandwidth = settings_.VideoBandwidth;
    }

    //public override XElement XmlSettings {
    //    //get {
    //    //    return settings_.XmlSerializeToXElement( );
    //    //}
    //    //set {
    //    //    settings_ = value.XmlDeserialize<Ag86140BSettings>( );
    //    //}
    //}

    #region IWavemeter interface implementation

    public Double MeasureFrequency( ) {
      return GetCenterFrequency( );
    }

    public Double MeasurePower( ) {
      return GetPeakPower( );
    }

    public UpdateSpeed UpdateSpeed {
      get {
        return UpdateSpeed.UNDEFINED;
      }
      set {
      }
    }

    public int MeasurementTime {
      get {
        return ( int )( GetSweepTime( ) * 1000 );
      }
      set {
        SetSweepTime( ( ( float )value ) / 1000f, true );
      }
    }

    #endregion


  }  //class Ag86140B
} // namespace Syntune.
