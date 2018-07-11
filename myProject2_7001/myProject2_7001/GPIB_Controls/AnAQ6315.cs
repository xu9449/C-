using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

//using Syntune.Interfaces;

namespace Finisar {

  public class AnAQ6315Error : ArgumentException {
    public AnAQ6315Error( string errorMessage )
      :
      base( "AnAQ6315 Error: " + errorMessage ) {
    }

    public AnAQ6315Error( )
      : base( "AnAQ6315 Error: no message" ) {
    }
  }
  public class AnAQ6315SmsrData {
    public AnAQ6315SmsrData( string osaAnswer ) {
      string pattern = @"(-?\d+\.?\d*[eE]?[+-]?\d*)";
      MatchCollection matches = Regex.Matches( osaAnswer, pattern );
      if( matches.Count != 6 )
        throw new InstrumentError( "[AnAQ6315] Unexpected answer for analysis data: " + osaAnswer );
      List<float> numbers = new List<float>( 6 );
      foreach( Match m in matches ) {
        float f = float.Parse( m.Value, CultureInfo.InvariantCulture );
        numbers.Add( f );
      }
      this.PeakWavelength = float.Parse( matches[ 0 ].Value, CultureInfo.InvariantCulture );
      this.PeakPower = float.Parse( matches[ 1 ].Value, CultureInfo.InvariantCulture );
      this.NextPeakWavelength = float.Parse( matches[ 2 ].Value, CultureInfo.InvariantCulture );
      this.NextPeakPower = float.Parse( matches[ 3 ].Value, CultureInfo.InvariantCulture );
      this.DeltaWavelength = float.Parse( matches[ 4 ].Value, CultureInfo.InvariantCulture );
      this.Smsr = float.Parse( matches[ 5 ].Value, CultureInfo.InvariantCulture );
    }
    public float PeakWavelength;
    public float PeakFrequency;
    public float PeakPower;
    public float NextPeakWavelength;
    public float NextPeakFrequency;
    public float NextPeakPower;
    public float DeltaWavelength;
    public float Smsr;

  }

  #region AnAQ6315 enums

  public enum AnAQ6315SweepMode {
    SINGLE = 0,
    CONTINUOUS
  }
  public enum AnAQ6315DisplayState {
    ON = 0,
    OFF
  }
  public enum AnAQ6315BufferState {
    ON = 0,
    OFF
  }
  #endregion

  public class AnAQ6315Settings {
    public int GpibAddress = 23;
    public AnAQ6315SweepMode SweepMode = AnAQ6315SweepMode.SINGLE;
    public AnAQ6315DisplayState DisplayState = AnAQ6315DisplayState.ON;
    public AnAQ6315BufferState BufferState = AnAQ6315BufferState.ON;
    public bool isSpectralApplicationActive_ = false;
    public float Sensitivity = -50.0f;  //TODO: Find out what the default would be.
    public float ResolutionBandwidth = 10.0f; //TODO: Find out what the default would be.
    public float CenterWavelength= 1305.0f;
    public float StartWavelength;
    public float StopWaveLength;
    public float SpanWavelength = 40.0f;
    public float CenterFrequency;
    public float StartFrequency;
    public float StopFrequency;
    public float SpanFrequency;
    public float SweepStartFrequency;
    public float SweepStopFrequency;
    public NationalInstruments.NI4882.TimeoutValue Timeout = NationalInstruments.NI4882.TimeoutValue.T1000s;
  }


  // Class AnAQ6315

  public class AnAQ6315 {
    //#define TRACE(msg) OutputDebugString(msg)
    const string CONT_ON = "RPT";
    const string CONT_OFF = "SGL";
    const string SINGLE_SWEEP = "SGL";
    //const string AUTO_ALIGN =         "CAL:ALIG:AUTO";
    //const string AUTO_MEASURE =       "DISP:WIND:TRAC:ALL:SCAL:AUTO";
    //const string DISPLAY_ON =         "DISP ON";
    //const string DISPLAY_OFF =        "DISP OFF";
    //const string BUFFER_ON =          "SYST:COMM:GPIB:BUFF ON";
    //const string BUFFER_OFF =         "SYST:COMM:GPIB:BUFF OFF";
    //const string START_DFB_APPL =     "CALC:SOUR:TEST DFB";
    //const string STOP_DFB_APPL =      "CALC:SOUR:TEST OFF";
    //const string GET_DFB_DATA =       "CALC:SOUR:DATA?";

    //const string SET_POWER_UNIT_DBM = "UNIT:POW DBM";
    // const string SET_SENSITIVITY =    "SENS:POW:DC:RANG:LOW";         //Arg
    const string SET_SENSITIVITY_NORMAL_HOLD = "SNHD";
    const string SET_RESOLUTION = "RESLN";                //[nm] 0.01 - 2.0 (1-2-5 steps)
    const string SET_REF_LEVEL = "REFL";  //[dBm]
    const string SET_WL_VACUUM = "MESWL1";
    const string SET_WL_CENTER = "CTRWL";                //[nm]
    const string SET_WL_START = "STAWL";                //[nm]
    const string SET_WL_STOP = "STPWL";                //[nm]
    const string SET_WL_SPAN = "SPAN";                //[nm]
    //const string SET_SRAN_LOW =       "SENS:WAV:SRAN:LOW";            //Arg
    //const string SET_SRAN_UPP =       "SENS:WAV:SRAN:UPP";            //Arg
    //const string SRAN_OFF =           "SENS:WAV:SRAN OFF";
    const string SET_TRACE_POINTS = "SEGP";                //Arg: Nr of Points
    const string SET_COMMA_DELIMITER = "SD0";
    const string GET_TRACE = "LDATA";             //Arg: Trace name
    //const string DATA_FORMAT_ASCII =  "FORM ASCII";
    const string SET_SMSR_ANALYSIS = "SMSR1";
    const string GET_ANALYSIS_DATA = "ANA?";
    const string GET_MKR1_DATA = "MKR1";
    const string GET_MKR2_DATA = "MKR2";
    const string GET_MOVING_MKR_DATA = "MKR?";
    const string SET_MKR_TO_MAX = "PKSR";

    //const string SET_MARK1_TO_MAX =   "CALC:MARK1:MAX";
    //const string SET_MARK2_TO_MAX =   "CALC:MARK2:MAX";
    //const string SET_MARK2_TO_NEXT =  "CALC:MARK2:MAX:NEXT";
    //const string SET_MARK1_TO_CENTER = "CALC:MARK1:SCEN";
    //const string GET_MARK1_WL =       "CALC:MARK1:X?";
    //const string GET_MARK1_POWER =    "CALC:MARK1:Y?";
    //const string GET_MARK2_POWER =    "CALC:MARK2:Y?";
    //const string MARK_TO_REF =        "CALC:MARK:SRL";
    //const string SET_MARK_X_FREQ =    "CALC:MARK:X:READ FREQ";
    //const string SET_MARK_X_WL =      "CALC:MARK:X:READ WAV";

    private AnAQ6315Settings settings_ = new AnAQ6315Settings( );
    private GpibDriver gpib_ = null;
    private bool doWaitForOperations_ = false;
    private bool isSpectralApplicationActive_ = false;
    //private bool isContinuousOn_ = false;

    // Constructor
    public AnAQ6315( byte address )
      : this( address, NationalInstruments.NI4882.TimeoutValue.T30s ) {
    }

    public AnAQ6315( byte address, NationalInstruments.NI4882.TimeoutValue timeout ) {
      gpib_ = new GpibDriver( address, timeout );
      //gpib_.Reset(  );
      //gpib_.Write( "INIT" );
      GpibIdentity id;
      id = gpib_.GetIdentity( );

#if !TEST
      //   if( id.model.Substring( 0, 5 ) != "86140" )
      //     throw new AnAQ6315Error( "Invalid model number" );
      // TODO: Design way to test firmware version 
      //if( id.firmwareVersion < "B.05.00" )
      // throw AnAQ6315Error( "Invalid firmware version" );
#endif

      Initialise( false );
      //DoWaitForOperations = true;
      //StopSpectralApplication( );
      DoWaitForOperations = false;
    }

    public void Initialise( bool wait ) {
      //gpib_.Write( SET_POWER_UNIT_DBM );
      //gpib_.Write( DATA_FORMAT_ASCII );
      SetContinuousOff( wait );
      if( wait )
        gpib_.Wait( );
      //isContinuousOn_ = true;
    }

    /// <summary>
    /// Set the SweepMode of the spectrum analyzer. 
    /// AnAQ6315SweepMode.CONTINUOUS = keep sweeping continuously.
    /// AnAQ6315SweepMode.SINGLE = No sweeps are made unless PerformSingleSweep 
    /// is called.
    /// </summary>
    public AnAQ6315SweepMode SweepMode {
      get {
        return settings_.SweepMode;
      }
      set {
        settings_.SweepMode = value;
        switch( value ) {
          case AnAQ6315SweepMode.CONTINUOUS:
            SetContinuousOn( true );
            break;
          case AnAQ6315SweepMode.SINGLE:
            SetContinuousOff( true );
            break;
        }
      }
    }

    private void SetContinuousOn( bool wait ) {
      gpib_.Write( CONT_ON );
      if( wait )
        gpib_.Wait( );
      //isContinuousOn_ = true;
    }

    private void SetContinuousOff( bool wait ) {
      gpib_.Write( CONT_OFF );
      if( wait )
        gpib_.Wait( );
      //isContinuousOn_ = false;
    }

    /// <summary>
    /// Controls whether commands should wait for an operation to complete before 
    /// returning.
    /// </summary>
    public bool DoWaitForOperations {
      get {
        return doWaitForOperations_;
      }
      set {
        doWaitForOperations_ = value;
      }
    }

    //public float Sensitivity {
    //  get {
    //    //return settings_.Sensitivity;
    //    return GetSensitivity( );
    //  }
    //  set {
    //    //settings_.Sensitivity = value;
    //    SetSensitivity( value, DoWaitForOperations );
    //  }
    //}

    public float ResolutionBandwidth {
      get {
        //return settings_.ResolutionBandwidth;
        return GetResolutionBandwidth( );
      }
      set {
        //settings_.ResolutionBandwidth = value;
        SetResolutionBandwidth( value, DoWaitForOperations );
      }
    }

    public float ReferenceLevel {
      get {
        //return settings_.ReferenceLevel;
        return GetReferenceLevel( );
      }
      set {
        //settings_.ReferenceLevel = value;
        SetReferenceLevel( value, DoWaitForOperations );
      }
    }

    public float CenterWavelength {
      get {
        //return settings_.CenterWavelength;
        return GetCenterWavelength( );
      }
      set {
        //settings_.CenterWavelength = value;
        SetCenterWavelength( value, DoWaitForOperations );
      }
    }

    public float StartWavelength {
      get {
        //return settings_.StartWavelength;
        return GetStartWavelength( );
      }
      set {
        //settings_.StartWavelength = value;
        SetStartWavelength( value, DoWaitForOperations );
      }
    }

    public float StopWavelength {
      get {
        //return settings_.StopWavelength;
        return GetStopWavelength( );
      }
      set {
        //settings_.StopWavelength = value;
        SetStopWavelength( value, DoWaitForOperations );
      }
    }

    public float SpanWavelength {
      get {
        //return settings_.SpanWavelength;
        return GetSpanWavelength( );
      }
      set {
        //settings_.SpanWavelength = value;
        SetSpanWavelength( value, DoWaitForOperations );
      }
    }

    public float CenterFrequency {
      get {
        //return settings_.CenterFrequency;
        return GetCenterFrequency( );
      }
      set {
        //settings_.CenterFrequency = value;
        SetCenterFrequency( value, DoWaitForOperations );
      }
    }

    public float StartFrequency {
      get {
        //return settings_.StartFrequency;
        return GetStartFrequency( );
      }
      set {
        //settings_.StartFrequency = value;
        SetStartFrequency( value, DoWaitForOperations );
      }
    }

    public float StopFrequency {
      get {
        //return settings_.StopFrequency;
        return GetStopFrequency( );
      }
      set {
        //settings_.StopFrequency = value;
        SetStopFrequency( value, DoWaitForOperations );
      }
    }

    public float SpanFrequency {
      get {
        //return settings_.SpanFrequency;
        return GetSpanFrequency( );
      }
      set {
        // settings_.SpanFrequency = value;
        SetSpanFrequency( value, DoWaitForOperations );
      }
    }

    public void SetPeak2ReferenceLevel( ) {
      // TODO
      //gpib_.Write( SET_MKR_TO_MAX );
      //gpib_.Write( SET_MARK1_TO_MAX );
      //gpib_.Write( MARK_TO_REF );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    public void SetPeak2Center( bool wait ) {
      //gpib_.Write( SET_MARK1_TO_MAX );
      //gpib_.Write( SET_MARK1_TO_CENTER );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    public float SweepStartFrequency {
      get {
        return settings_.SweepStartFrequency;
      }
      set {
        settings_.SweepStartFrequency = value;
        setSweepStartFrequency( value, true );
      }
    }

    private void setSweepStartFrequency( float frequency_THz, bool wait ) {
      //string command;
      //command = String.Format( CultureInfo.InvariantCulture, "{0}{1:G6} THZ", SET_SRAN_LOW, frequency_THz );
      //gpib_.Write( command );
      //if ( wait )
      //  gpib_.Wait( );
    }

    public float SweepStopFrequency {
      get {
        return settings_.SweepStopFrequency;
      }
      set {
        settings_.SweepStopFrequency = value;
        setSweepStartFrequency( value, true );
      }
    }

    void setSweepStopFrequency( float frequency_THz, bool wait ) {
      //string command;
      //command = String.Format( "{0}{1:G6} THZ", SET_SRAN_UPP, frequency_THz );
      //gpib_.Write( command );
      //if( wait )
      //  gpib_.Wait(  );
    }

    public int NrOfTracePoints {
      get {
        //return settings_.NrOfTracePoints;
        return GetNrOfTracePoints( );
      }
      set {
        //settings_.NrOfTracePoints = value;
        SetNrOfTracePoints( value, DoWaitForOperations );
      }
    }

    //public void RemoveSweepLimits( )
    //{
    //  //gpib_.Write( SRAN_OFF );
    //  //if ( DoWaitForOperations )
    //  //  gpib_.Wait(  );
    //}

    public void PerformSingleSweep( ) {
      if( SweepMode == AnAQ6315SweepMode.CONTINUOUS )
        SweepMode = AnAQ6315SweepMode.SINGLE;
      gpib_.Write( SINGLE_SWEEP );
      if( DoWaitForOperations )
        gpib_.Wait( );
    }

    //public void PerformAutoAlign( ) {
    //  gpib_.Write( AUTO_ALIGN );
    //  if ( DoWaitForOperations )
    //    gpib_.Wait(  );
    //}

    //void PerformAutoMeasure( ) {
    //  gpib_.Write( AUTO_MEASURE );
    //  if ( DoWaitForOperations )
    //    gpib_.Wait( );
    //}

    public OSASpectrumTrace /*public Array<float>  */  AquireTrace( int length ) {
      string asciiData; // = new char[20*length];
      List<float> data = new List<float>( length );
      bool previousWaitState = DoWaitForOperations;
      DoWaitForOperations = false;
      SweepMode = AnAQ6315SweepMode.SINGLE;
      //SetContinuousOff( false );
      NrOfTracePoints = length;
      //setNrOfTracePoints( length, false );
      DoWaitForOperations = true;
      PerformSingleSweep( );
      DoWaitForOperations = previousWaitState;

      // gpib_.Write( DATA_FORMAT_ASCII );
      // gpib_.Write( GET_TRACE );
      asciiData = gpib_.Read( ); //asciiData, 20*length );

      for( int i = 0; i < length; i++ ) {
        string[ ] strValues = asciiData.Split( ',' );
        data[ i ] = float.Parse( strValues[ i ] );
      }
      OSASpectrumTrace spec = new OSASpectrumTrace( );
      spec.points = data;
      return spec;
    }

    //public void StartSpectralApplication( ) {
    //  gpib_.Write( START_DFB_APPL );
    //  if ( DoWaitForOperations )
    //    gpib_.Wait( );
    //  isSpectralApplicationActive_ = true;
    //}


    //public void StopSpectralApplication( ) {
    //  gpib_.Write( STOP_DFB_APPL );
    //  if ( DoWaitForOperations )
    //    gpib_.Wait( );
    //  isSpectralApplicationActive_ = false;
    //}

    public double GetPeakFrequency( ) {
      if( !isSpectralApplicationActive_ ) {
        bool previousWaitState = DoWaitForOperations;
        DoWaitForOperations = true;
        // StartSpectralApplication( );
        PerformSingleSweep( );
        DoWaitForOperations = previousWaitState;
      }

      // gpib_.Write( GET_DFB_DATA );
      string answer = gpib_.Read( );
      //string answer = gpib_.Read( ); answer_ );
      Ag86140SpectralData d = new Ag86140SpectralData( answer );
      return d.PeakFrequency_THz;
    }

    public double GetPeakWavelength( ) {
      if( !isSpectralApplicationActive_ ) {
        bool previousWaitState = DoWaitForOperations;
        DoWaitForOperations = true;
        // StartSpectralApplication( );
        PerformSingleSweep( );
        DoWaitForOperations = previousWaitState;
      }
      // gpib_.Write( GET_DFB_DATA );
      string answer = gpib_.Read( );
      Ag86140SpectralData d = new Ag86140SpectralData( answer );
      return d.PeakWavelength_nm;
      //return d.peakWavelength * 1.0E9;   // Convert [m] to [nm]
    }
    public virtual double GetModeOffset( ) {
        string answer = gpib_.Read( );
        Ag86140SpectralData d = new Ag86140SpectralData( answer );
        return d.modeOffset;
    }

    public double GetPeakPower( ) {
      //Ag86140SpectralData d = null; // GetSpectralParameters( );
      gpib_.Write( SET_MKR_TO_MAX );

      return 0.0f;
    }

    public double GetSmsr( ) {
      bool previousWaitState = DoWaitForOperations;
      DoWaitForOperations = true;
      // StartSpectralApplication( );
      PerformSingleSweep( );
      Thread.Sleep( 2000 );
      DoWaitForOperations = previousWaitState;
      gpib_.Write( SET_SMSR_ANALYSIS );
      gpib_.Write( GET_ANALYSIS_DATA );
      string ans = gpib_.Read( );
      AnAQ6315SmsrData d = new AnAQ6315SmsrData( ans ); //GetSpectralParameters( );
      return d.Smsr;
    }

    //Ag86140SpectralData GetSpectralParameters(  )
    //{
    //  if ( !isSpectralApplicationActive_ ) {
    //    bool previousWaitState = DoWaitForOperations;
    //    DoWaitForOperations = true;
    //    StartSpectralApplication( );
    //    PerformSingleSweep( );
    //    DoWaitForOperations = previousWaitState;
    //  }

    //  gpib_.Write( GET_DFB_DATA );
    //  string answer = gpib_.Read( );
    //  Ag86140SpectralData d = new Ag86140SpectralData( answer );
    //  return d;
    //}

    //private float 
    //GetSensitivity(  ) {
    //  string command;
    //  command = String.Format( "{0}?", SET_SENSITIVITY );
    //  gpib_.Write( command );
    //  string answer = gpib_.Read( );
    //  float result = float.Parse( answer );
    //  return result;
    //}

    //private void
    //SetSensitivity( float sensitivity_dBm, bool wait ) {
    //  string command;
    //  command = String.Format( "{0} {1:G6} DBM", SET_SENSITIVITY, sensitivity_dBm );
    //  gpib_.Write( command );
    //  if ( wait )
    //    gpib_.Wait( );
    //}

    private float GetResolutionBandwidth( ) {
      string command;
      command = String.Format( "{0}?", SET_RESOLUTION );
      // sprintf( command, "%s?", SET_RESOLUTION );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return result;
    }

    private void SetResolutionBandwidth( float resolution_nm, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6} ", SET_RESOLUTION, resolution_nm );
      //sprintf( command, "%s %.2f NM", SET_RESOLUTION, resolution_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetReferenceLevel( ) {
      string command;
      command = String.Format( "{0}?", SET_REF_LEVEL );
      //sprintf( command, "%s?", SET_REF_LEVEL );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return result;
    }

    private void SetReferenceLevel( float level_dBm, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6} DBM", SET_REF_LEVEL, level_dBm );
      // sprintf( command, "%s %.2f DBM", SET_REF_LEVEL, level_dBm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetCenterWavelength( ) {
      string command;
      command = String.Format( "{0}?", SET_WL_CENTER );
      // sprintf( command, "%s?", SET_WL_CENTER );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return result;
    }

    private void SetCenterWavelength( float wavelength_nm, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6}", SET_WL_CENTER, wavelength_nm );
      //sprintf( command, "%s %4.3f NM", SET_WL_CENTER, wavelength_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetStartWavelength( ) {
      string command;
      command = String.Format( "{0}?", SET_WL_START );
      //sprintf( command, "%s?", SET_WL_START );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return result;
    }

    private void SetStartWavelength( float wavelength_nm, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6} NM", SET_WL_START, wavelength_nm );
      //sprintf( command, "%s %4.3f NM", SET_WL_START, wavelength_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetStopWavelength( ) {
      string command;
      command = String.Format( "{0}?", SET_WL_STOP );
      //sprintf( command, "%s?", SET_WL_STOP );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return result;
    }

    private void SetStopWavelength( float wavelength_nm, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6} NM", SET_WL_STOP, wavelength_nm );
      //sprintf( command, "%s %4.3f NM", SET_WL_STOP, wavelength_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetSpanWavelength( ) {
      string command;
      command = String.Format( "{0}?", SET_WL_SPAN );
      //sprintf( command, "%s?", SET_WL_SPAN );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return result;
    }

    private void SetSpanWavelength( float span_nm, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6}", SET_WL_SPAN, span_nm );
      //sprintf( command, "%s %.2f NM", SET_WL_SPAN, span_nm );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetCenterFrequency( ) {
      string command;
      command = String.Format( "{0}?", SET_WL_CENTER );
      //sprintf( command, "%s?", SET_WL_CENTER );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return Constants.SPEED_OF_LIGHT / result * 1.0E-12f;
      //return static_cast<F32>( SPEED_OF_LIGHT / atof( answer_ ) * 1.0E-12 );
    }

    private void SetCenterFrequency( float frequency_THz, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6} THZ", SET_WL_CENTER, frequency_THz );
      //sprintf( command, "%s %4.3f THZ", SET_WL_CENTER, frequency_THz );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetStartFrequency( ) {
      string command;
      command = String.Format( "{0}?", SET_WL_STOP );
      // sprintf( command, "%s?", SET_WL_STOP );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return Constants.SPEED_OF_LIGHT / result * 1.0E-12f;
    }

    void SetStartFrequency( float frequency_THz, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6} THZ", SET_WL_STOP, frequency_THz );
      //sprintf( command, "%s %4.3f THZ", SET_WL_STOP, frequency_THz );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetStopFrequency( ) {
      string command;
      command = String.Format( "{0}?", SET_WL_START );
      //sprintf( command, "%s?", SET_WL_START );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float result = float.Parse( answer );
      return Constants.SPEED_OF_LIGHT / result * 1.0E-12f;
    }

    private void SetStopFrequency( float frequency_THz, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G6} THZ", SET_WL_START, frequency_THz );
      //sprintf( command, "%s %4.3f THZ", SET_WL_START, frequency_THz );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    private float GetSpanFrequency( ) {
      return GetStopFrequency( ) - GetStartFrequency( );
    }

    private void SetSpanFrequency( float span_THz, bool wait ) {
      string command;
      command = String.Format( "{0}?", SET_WL_CENTER );
      //sprintf( command, "%s?", SET_WL_CENTER );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      float center_nm = float.Parse( answer );
      float span_nm = 1.0E-3f * span_THz * center_nm * center_nm / Constants.SPEED_OF_LIGHT;
      SetSpanWavelength( span_nm, wait );
    }

    private int GetNrOfTracePoints( ) {
      string command;
      command = String.Format( "{0}?", SET_TRACE_POINTS );
      //sprintf( command, "%s?", SET_TRACE_POINTS );
      gpib_.Write( command );
      string answer = gpib_.Read( );
      int result = Int16.Parse( answer );
      return result;
    }

    private void SetNrOfTracePoints( int nr, bool wait ) {
      string command;
      command = String.Format( "{0} {1:G}", SET_TRACE_POINTS, nr );
      //sprintf( command, "%s %d", SET_TRACE_POINTS, nr );
      gpib_.Write( command );
      if( wait )
        gpib_.Wait( );
    }

    //private void  SetBufferOn( bool wait ) {
    //  gpib_.Write( BUFFER_ON );
    //  if ( wait )
    //    gpib_.Wait( );
    //}

    //private void
    //SetBufferOff( bool wait ) {
    //  gpib_.Write( BUFFER_OFF );
    //  if ( wait )
    //    gpib_.Wait( );
    //}

  }
}
