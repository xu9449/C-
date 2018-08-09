#define ADAPTIVELY

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Xml.Linq;


namespace Finisar {

  [Serializable]
  public class Ke2510Settings : ICloneable {
    public byte Adress = 0;
    public PIDSet Fast = new PIDSet( -1, 50, 1, 0, 100 );
    public double brakeTime = 10;
    public List<PIDSet> StablePids = new List<PIDSet>( );
    public PIDSet StabilizationPID = new PIDSet { P = 50, I = 7, D = 0 }; // Initial PID-values
    public int StabilizationSamples = 10; // Sample window size and also Chi-squared degrees of freedom
    public double StabilizationDelay = 0.1; // seconds
    public double StabilizationTimeout = 600; // seconds
    public double StabilizationStdDev = 0.01; // Acceptable standard deviation in degree Celcius
    public double StabilizationAlpha = 0.05; // Probability of misjudging the standard deviation as to high.
// 2010-09-30 public double StabilizationChi2 = 18.31; // Chi-squared value for samples degrees of freedom
    // 2010-09-30 public double StabilizationChi2 = 18.31; // Chi-squared value for samples degrees of freedom
    public double StabilizationGamma = 0.3; // Hand-tuned constant for PID autotuning
    public double MaxTStdDev = 0.1;
    public double MaxTError = 0.1;
    //public double fastMaxTStdDev_ = 0.1;
    //public double fastMaxTError_ = 0.1;

    public double R0 = 1e4;
    public double T0 = 25;
    public double SteinhartHartC1 = 1.063e-3;
    public double SteinhartHartC2 = 2.4277e-4;
    public double SteinhartHartC3 = 7.0472e-8;
    public double Beta = 3930;

    public Ke2510Settings( bool createNew ) {
      StablePids.Add( new PIDSet( -5, 50, 1, 0, 85 ) );
      StablePids.Add( new PIDSet( 25, 50, 1, 0, 45 ) );
      StablePids.Add( new PIDSet( 75, 50, 1, 0, 60 ) );
    }

    public Ke2510Settings( ) {
    }

    public object Clone( ) {
      Ke2510Settings v = ( Ke2510Settings ) this.MemberwiseClone( );
      return v;
    }
  }

  public class Ke2510 : Instrument, ITec, TemperatureControl.TEC.ITECController {
    private const string SWITCH_TEC_ON = ":OUTP ON";
    private const string SWITCH_TEC_OFF = ":OUTP OFF";
    private const string SWITCH_TEC_QUERY = ":OUTP?";

    private const string SET_SOURCE_CURRENT = ":SOUR:FUNC:MODE CURR";
    private const string SET_SOURCE_TEMPERATURE = ":SOUR:FUNC:MODE TEMP";

    private const string SET_TEMPERATURE = ":SOUR:TEMP";
    private const string SET_MAX_TEMPERATURE = ":SOUR:TEMP:PROT";
    private const string SET_MIN_TEMPERATURE = ":SOUR:TEMP:PROT:LOW ";
    private const string SET_TEC_MAXCURRENT = ":SENS:CURR:PROT";
    private const string SET_SENSOR_TYPE = ":TEMP:RTD:TYPE";
    private const string SET_CURRENT = ":SOUR:CURR ";

    private const string MEAS_TEC_POWER = ":MEAS:POW?";
    private const string MEAS_TEC_CURRENT = ":MEAS:CURR?";
    private const string MEAS_TEC_RESISTANCE = ":MEAS:RES?";
    private const string MEAS_TEC_VOLTAGE = ":MEAS:VOLT?";
    private const string MEAS_TEMPERATURE = ":MEAS:TEMP?";

    private bool hasSetPidParams_;
    private String PowerOnSettings_;
    private bool hasSetThermistorParams_;
    //private String name_ = "";
    bool isStable_ = false;
    bool stabilizeForever_ = false;
    bool writeLogMessages_ = true;
    //bool tecActive = false;
    bool blockFastMode_ = false;
    public bool debugMode_ = false;
    public bool doOverrideSettings = false;

    IAsyncResult stab = null;
    delegate double StabilizationDelegate( );
    StabilizationDelegate del;
    private static Ke2510Settings settings_ = new Ke2510Settings( true );
    private Ke2510Settings overridingSettings_;

    private GpibDriver gpib_ = null;

    private static SteinhartModel steinhartModel = new SteinhartModel( settings_.SteinhartHartC1, settings_.SteinhartHartC2, settings_.SteinhartHartC3 );
    private static ExponentialModel exponentialModel = new ExponentialModel( settings_.Beta, settings_.R0, settings_.T0 );

    public static string Revision = "$Revision: 16589 $";

    public Ke2510( ) {
      del = new StabilizationDelegate( StabilizeTemperature );
    }

    public Ke2510( byte address )
      : this( address, NationalInstruments.NI4882.TimeoutValue.T30s ) {
    }

    public Ke2510( byte address, NationalInstruments.NI4882.TimeoutValue timeout ) {
      gpib_ = new GpibDriver( address, timeout );
      del = new StabilizationDelegate( StabilizeTemperature );
    }

    public void restoreSavedSetup( int setupNumber ) {
      gpib_.Write( "*RCL " + setupNumber );
    }

    public PIDSet calcStablePidSet( double temp ) {

      PIDSet low = new PIDSet( ), high = new PIDSet( ), p = new PIDSet( );

      settings_.StablePids.Sort( );

      low = settings_.StablePids[ 0 ];
      for( int i = 0; i < settings_.StablePids.Count; i++ ) {
        if( temp == settings_.StablePids[ i ].Temp )
          return settings_.StablePids[ i ];

        if( temp > settings_.StablePids[ i ].Temp )
          low = settings_.StablePids[ i ];
        else
          break;
      }

      high = settings_.StablePids[ settings_.StablePids.Count - 1 ];
      for( int i = settings_.StablePids.Count - 1; i > -1; i-- ) {
        if( temp == settings_.StablePids[ i ].Temp )
          return settings_.StablePids[ i ];

        if( temp < settings_.StablePids[ i ].Temp )
          high = settings_.StablePids[ i ];
        else
          break;
      }

      if( low == settings_.StablePids[ settings_.StablePids.Count - 1 ] )
        return settings_.StablePids[ settings_.StablePids.Count - 1 ];

      if( high == settings_.StablePids[ 0 ] )
        return settings_.StablePids[ 0 ];


      p.Temp = temp;
      p.P = low.P + ( temp - low.Temp ) * ( ( high.P - low.P ) / ( high.Temp - low.Temp ) );
      p.I = low.I + ( temp - low.Temp ) * ( ( high.I - low.I ) / ( high.Temp - low.Temp ) );
      p.D = low.D + ( temp - low.Temp ) * ( ( high.D - low.D ) / ( high.Temp - low.Temp ) );
      p.ILimit = low.ILimit + ( temp - low.Temp ) * ( ( high.ILimit - low.ILimit ) / ( high.Temp - low.Temp ) );

      return p;
    }

    public void BeginStabilizeTemperature( ) {
      if( stab != null )
        throw new Exception( "ke2510 is already stabilizing" );

      stab = del.BeginInvoke( null, null );
    }

    public double EndStabilizeTemperature( ) {
      try {
        return del.EndInvoke( stab );
      }
      finally {
        stab = null;
      }
    }

    public bool StabilizeForever {
      set {
        stabilizeForever_ = value;
      }
    }

    public bool WriteLogMessages {
      set {
        writeLogMessages_ = value;
      }
    }

    private bool selfTuning_ = false; // Whether to use the self-tuning algorithm for temperature stabilization.
    public bool SelfTuning {
      get {
        return selfTuning_;
      }
      set {
        selfTuning_ = value;
      }
    }

    //public double StabilizeTemperature( ) {
    //  if( SelfTuning ) {
    //    "SelfTuning = true".LogInfo( );
    //    return StabilizeTemperatureSelfTuningTrue( );
    //  }
    //  else {
    //    "SelfTuning = false".LogInfo( );
    //    return StabilizeTemperatureSelfTuningFalse( );
    //  }
    //}

    private string benchmarkLabel_ = "";

    public string BenchMarkLabel {
      set {
        benchmarkLabel_ = "TECstab_" + value;
      }
    }

    public double StabilizeTemperature( ) {
      //if (benchmarkLabel_ != "" ) 
      //  benchmarkLabel_.BenchmarkDebug( );
      double res;
      if( SelfTuning ) {
        LogMessage("SelfTuning = true" );
        res = StabilizeTemperatureSelfTuningTrue( );
      }
      else {
        LogMessage("SelfTuning = false");
        res = StabilizeTemperatureSelfTuningFalse( );
      }
      //if( benchmarkLabel_ != "" ) 
      //  benchmarkLabel_.BenchmarkDebug( );
      return res;
    } 

    public double StabilizeTemperatureSelfTuningTrue( ) { // Experimental self-tuning of the PID controller.
      gpib_.Write( SET_SOURCE_TEMPERATURE );
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo( "en-US" );

      // Get values from settings_
      // Note that StabilizationSamples and StabilizationDelay combines to give a lower bound on time,
      // e.g., StabilizationSamples = 10 and StabilizationDelay = 0.1 yields 1.0 seconds.

      PIDSet PID = settings_.StabilizationPID;
      LogMessage( string.Format( "StabilizationPID = {0}, {1}, {2} before stabilization.", PID.P, PID.I, PID.D ) );

      int samples = settings_.StabilizationSamples;
      LogMessage(string.Format( "StabilizationSamples = {0} samples.", samples ));

      TimeSpan delay = new TimeSpan( 0, 0, 0, 0, ( int )( settings_.StabilizationDelay * 1000 ) );
      LogMessage(string.Format( "StabilizationDelay = {0} seconds.", delay.TotalSeconds ));

      TimeSpan timeout = new TimeSpan( 0, 0, 0, 0, ( int )( settings_.StabilizationTimeout * 1000 ) );
      LogMessage( string.Format( "StabilizationTimeout = {0} seconds.", timeout.TotalSeconds ) );

      double stdDev = settings_.StabilizationStdDev;
      LogMessage(string.Format( "StabilizationStdDev = {0} degree Celcius.", stdDev ));

      // Chi-square value for samples degrees of freedom, was "double chi2 = settings_.StabilizationChi2;"
      double alpha = settings_.StabilizationAlpha;
      double chi2 = Syntune.UberMath.FSharp.Statistics.Newton.inverseChi2( 0.01, samples, 1.0 - alpha );
      // string.Format( "StabilizationChi2 = {0}.", chi2 ).LogInfo( );

      double gamma = settings_.StabilizationGamma; // Hand-tuned constant for PID tuning
      // string.Format( "StabilizationGamma = {0}.", gamma ).LogInfo( );

      // Upper bound for convergence: sumOfSquares / acceptableVariance < chi2
      // The Chi-squared value is choosen based on sample size and the confidence desired.
      // Please consult a textbook in statistics (or Beta) for a table over the Chi-squared distribution.
      // This criteria only an approximate solution but it seems to work well in practice.
      double upperBound = chi2 * Math.Pow( stdDev, 2 );

      // Measuremet variables

      var targetTemperature = this.getTargetTemperature( );
      double difference = 0;
      double square = 0;
      double sumOfSquares = 0;
      Queue<double> squares = new Queue<double>( );

      // Auxilliary variables for PID tuning
      // The tuning algorithm is based on "Self-Tuning of PID Controllers by Adaptive Interaction"
      // by Feng Lin et al.
      double auxP = 0, auxI = 0, auxD = 0, weight;

      // The number of iterations done; just interesting to know
      int numberOfIterations = 0;

      LogMessage( "Stabilizing ..." );

      var start = DateTime.UtcNow;

      // Continue to measure until timeout or a sufficient numer of samples and convergence

      do {
        Thread.Sleep( ( int )delay.TotalMilliseconds );
        numberOfIterations++;

        difference = targetTemperature - measureTemperature( );
        square = Math.Pow( difference, 2 );
        sumOfSquares += square;
        squares.Enqueue( square );

        // string.Format( "{0}", difference ).LogInfo( ); // Just verifying convergence

        auxD = ( difference - auxD ) / delay.TotalSeconds;
        auxI = difference * delay.TotalSeconds + auxI;
        auxP = difference;
        weight = gamma * difference * delay.TotalSeconds;

        // The constant D have been hardwired to 0, which seems to work well in practise.
        // Dynamic D behave unpredictable for many values of gamma.
        PID = new PIDSet {
          P = PID.P - weight * auxP,
          I = PID.I - weight * auxI,
          D = 0 // PID.D - weight * auxD
        };

        setTempSourcePidParams( PID );

        if( squares.Count > samples ) {
          sumOfSquares -= squares.Dequeue( );
        }

      } while( ( DateTime.UtcNow - start ) < timeout
        && ( squares.Count < samples || upperBound < sumOfSquares ) );

      var stop = DateTime.UtcNow;

      settings_.StabilizationPID = PID;
      LogMessage(string.Format( "StabilizationPID = {0}, {1}, {2} after {3} iterations.", PID.P, PID.I, PID.D, numberOfIterations ));

      if( ( stop - start ) < timeout ) {
        LogMessage( "The temperature stabilized after " + ( stop - start ).TotalSeconds.ToString( "####.0" ) + " seconds." );
        return ( stop - start ).TotalSeconds;
      }
      else {
        LogMessage( "Hit timelimit while stabilizing temperature" );
        throw new Exception( "Hit timelimit while stabilizing temperature" );
      }
    }

    public double StabilizeTemperatureSelfTuningFalse( ) { // was StabilizeTemperature

      if( doOverrideSettings ) {
        settings_ = overridingSettings_;
      }
      
      gpib_.Write( SET_SOURCE_TEMPERATURE );
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo( "en-US" );
      var target = this.getTargetTemperature( );
      LogMessage( "Starting to stabilize" );
      bool hitTimeout = false;
      TimeSpan timeout = new TimeSpan( 0, 0, 0, 0, ( int )( settings_.StabilizationTimeout * 1000 ) );
      DateTime start = DateTime.UtcNow;

      Queue<double> tempQ = new Queue<double>( );
      double avg = 0;
      double stddev = 1000;  // a large number
      double temp;
      double dif;
      TimeSpan delay = new TimeSpan( 0, 0, 0, 0, ( int )( settings_.StabilizationDelay * 1000 ) );
      ;

      Stopwatch t = new Stopwatch( );
      t.Start( );
      PIDSet PID = new PIDSet( ), stablePIDset_;

      double sum = 0;
      double sum2 = 0;
      bool exitForbidden = true;
      int iteration = 0;
      do {
        try {
          iteration++;
          hitTimeout = ( DateTime.UtcNow - start ) > timeout;
          Thread.Sleep( ( int )delay.TotalMilliseconds );
          stablePIDset_ = calcStablePidSet( target );

          temp = measureTemperature( );
          tempQ.Enqueue( temp );
          sum += temp;
          sum2 += Math.Pow( temp, 2 );
          if( tempQ.Count > settings_.StabilizationSamples ) {
            double tdequed = tempQ.Dequeue( );
            sum -= tdequed;
            sum2 -= Math.Pow( tdequed, 2 );
            exitForbidden = false;
          }

          avg = sum / tempQ.Count;

          stddev = Math.Sqrt( sum2 / ( double )tempQ.Count - Math.Pow( avg, 2 ) );

          bool stdDevOK = ( stddev < settings_.MaxTStdDev );
          bool offsetOK = ( Math.Abs( avg - target ) < settings_.MaxTError );

          if( debugMode_ ) {
              LogMessage( ( "Iteration = " + iteration + " Samples used in calculation = " + settings_.StabilizationSamples ) );
              LogMessage( ( "T = " + temp ) );
              LogMessage( ( "stddev = " + stddev + " Limit = " + settings_.MaxTStdDev + " OK =" + stdDevOK.ToString( ) ) );
              LogMessage( ( "Mean offset = " + ( avg - target ) + " Limit = " + settings_.MaxTError + " OK =" + offsetOK.ToString( ) ) );
              LogMessage( "----" );
          }

          isStable_ = stdDevOK && offsetOK;

          if( isStable_ ) {
            if( !PID.EqualTo( stablePIDset_ ) ) {
              LogMessage( "Switching to stable PID parameters" );  // ...if necessary
              setTempSourcePidParams( stablePIDset_ );
              PID = stablePIDset_;
              isStable_ = false;   // isStable must be recalculated at least once if PID's were changed..
            }
          }
          else if( !PID.EqualTo( settings_.Fast ) ) {
            LogMessage( "Switching to fast PID parameters" );
            setTempSourcePidParams( settings_.Fast );
            PID = settings_.Fast;
          }

          dif = temp - target;
          if( writeLogMessages_ ) {
            if( t.ElapsedMilliseconds > 10000 ) {
              LogMessage( "Currently at: " + measureTemperature( ) + ". Dif is: " + dif );
              t.Reset( );
              t.Start( );
            }
          }
        }
        catch( Exception ex ) {
          LogMessage( "Got an exception in stabilization loop: " + ex.Message + "(this has no effect on temperature)" );
          continue;
        }

      } while( ( !hitTimeout && !isStable_ ) || exitForbidden || stabilizeForever_ );

      DateTime stop = DateTime.UtcNow;

      if( hitTimeout ) {
        LogMessage( "Hit timelimit while stabilizing temperature" );
        throw new Exception( "Hit timelimit while stabilizing temperature" );
      }
      else {
        LogMessage( "Done stabilizing after " + ( stop - start ).TotalSeconds.ToString( "####.0" ) + " Seconds." );
        return ( stop - start ).TotalMinutes;
      }
    }

    /// <summary>
    /// This property waits for a stable temperature and return. Temperature stab is continuing
    /// </summary>
    public void WaitForStableTemp( ) {
      do {
        Thread.Sleep( ( int )settings_.StabilizationDelay * 1000 ); // Wait some time to allow the system to react
      } while( !isStable_ );
    }

    public void setThermistorParams( double range, double a, double b, double c ) {
      gpib_.Write( ":TEMP:TRAN THER" );
      gpib_.Write( ":TEMP:THER:RANG " + range.ToString( CultureInfo.InvariantCulture ) );
      gpib_.Write( ":TEMP:THER:A " + a.ToString( CultureInfo.InvariantCulture ) );
      gpib_.Write( ":TEMP:THER:B " + b.ToString( CultureInfo.InvariantCulture ) );
      gpib_.Write( ":TEMP:THER:C " + c.ToString( CultureInfo.InvariantCulture ) );
      hasSetThermistorParams_ = true;
    }

    [Obsolete( "use setTempSourcePidParams" )]
    public virtual void setPidParams( PIDSet pid ) {
      setTempSourcePidParams( pid );
    }

    public virtual void setTempSourcePidParams( PIDSet pid ) {
      setTemperatureSourcePidParams( pid.P, pid.I, pid.D );
    }

    public void setCurrSourcePidParams( PIDSet pid ) {
      gpib_.Write( SET_SOURCE_CURRENT );
      setCurrentSourcePidParams( pid.P, pid.I, pid.D );
      gpib_.Write( SET_SOURCE_TEMPERATURE );   // be pragmatic and set back to temperature ctrl
    }

    public virtual PIDSet getPidParams( ) {
      PIDSet pid = new PIDSet( );

      gpib_.Write( ":SOUR:TEMP:LCON:GAIN?" );
      pid.P = readFloat( );
      gpib_.Write( ":SOUR:TEMP:LCON:INT?" );
      pid.I = readFloat( );
      gpib_.Write( ":SOUR:TEMP:LCON:DER?" );
      pid.D = readFloat( );

      return pid;
    }

    public virtual void setTemperatureSourcePidParams( double p, double i, double d ) {
      gpib_.Write( ":SOUR:TEMP:LCON:GAIN " + p.ToString( CultureInfo.InvariantCulture ) );
      gpib_.Write( ":SOUR:TEMP:LCON:INT " + i.ToString( CultureInfo.InvariantCulture ) );
      gpib_.Write( ":SOUR:TEMP:LCON:DER " + d.ToString( CultureInfo.InvariantCulture ) );
      hasSetPidParams_ = true;
    }

    public virtual void setCurrentSourcePidParams( double p, double i, double d ) {
      gpib_.Write( ":SOUR:CURR:LCON:GAIN " + p.ToString( CultureInfo.InvariantCulture ) );
      gpib_.Write( ":SOUR:CURR:LCON:INT " + i.ToString( CultureInfo.InvariantCulture ) );
      gpib_.Write( ":SOUR:CURR:LCON:DER " + d.ToString( CultureInfo.InvariantCulture ) );
    }

    public virtual void switchTec( bool switchOn ) {
      if( switchOn )
        gpib_.Write( SWITCH_TEC_ON );
      else
        gpib_.Write( SWITCH_TEC_OFF );
    }

    public virtual bool isTecOn( ) {
      gpib_.Write( SWITCH_TEC_QUERY );
      int result;
      try {
        result = readInt( );
      }
      catch( Exception ex ) {
        if( ex is System.FormatException ) {
          try {
            result = readInt( );
          }
          catch( Exception ) {
            result = 0;
          }
        }
        else {
          result = 0;
        }
      }
      return ( result.Equals( 1 ) ? true : false );
    }

    public float setMaxCurrent( float current ) {
      gpib_.Write( SET_TEC_MAXCURRENT + " " + ( current * 1.0E-3 ).ToString( CultureInfo.InvariantCulture ) );
      return getMaxCurrent( );
    }

    public float getMaxCurrent( ) {
      gpib_.Write( SET_TEC_MAXCURRENT + "?" );
      return readFloat( );
    }

    public virtual float setTemperature( float temperature ) {
      gpib_.Write( SET_SOURCE_TEMPERATURE );
      gpib_.Write( SET_TEMPERATURE + " " + temperature );
      gpib_.Write( SWITCH_TEC_ON );
      return getTargetTemperature( );
    }


    public void setCurrent( float currentInAmp ) {
      gpib_.Write( SET_SOURCE_CURRENT );
      gpib_.Write( SET_CURRENT + currentInAmp );
      gpib_.Write( SWITCH_TEC_ON );
    }

    /// <summary>
    /// Set max protection temperature
    /// </summary>
    /// <param name="maxTemperature"></param>
    /// <returns></returns>
    public virtual void setMaxTemperature( float maxTemperature ) {
      gpib_.Write( SET_MAX_TEMPERATURE + " " + maxTemperature );
    }

    public virtual void setMinTemperature( float maxTemperature ) {
      gpib_.Write( SET_MIN_TEMPERATURE + " " + maxTemperature );
    }

    public virtual float measureTecPower( ) {
      gpib_.Write( MEAS_TEC_POWER );
      return readFloat( );
    }

    public virtual float measureTemperature( ) {
      gpib_.Write( MEAS_TEMPERATURE );
      return readFloat( );
    }

    public virtual float measureTecCurrent( ) {
      gpib_.Write( MEAS_TEC_CURRENT );
      return ( float )( readFloat( ) * 1.0E3 );
    }

    public virtual float measureTecVoltage( ) {
      gpib_.Write( MEAS_TEC_VOLTAGE );
      return readFloat( );
    }

    public float getTargetTemperature( ) {
      gpib_.Write( SET_TEMPERATURE + "?" );
      return readFloat( );
    }

    private int readInt( ) {
      String r;
      r = gpib_.Read( );
      return int.Parse( r );
    }

    private float readFloat( ) {
      String r;
      r = gpib_.Read( );
      return float.Parse( r, CultureInfo.InvariantCulture );
    }

    public bool HasSetThermistorParams {
      get {
        return hasSetThermistorParams_;
      }
      set {
        hasSetThermistorParams_ = value;
      }
    }

    public bool HasSetPidParams {
      get {
        return hasSetPidParams_;
      }
      set {
        hasSetPidParams_ = value;
      }
    }
    /// <summary>
    /// Get a bool indicating whether the 2510 is stabilizing
    /// </summary>
    public bool IsStabilizing {
      get {
        return stab.IsCompleted;
      }
    }
    public String PowerOnSettings {
      get {
        return PowerOnSettings_;
      }
      set {
        PowerOnSettings_ = value;
      }
    }

    public int StabilizationSamples {
      set {
        settings_.StabilizationSamples = value;
      }
      get {
        return settings_.StabilizationSamples;
      }
    }

    public double StabilizationDelay {
      set {
        settings_.StabilizationDelay = value;
      }
      get {
        return settings_.StabilizationDelay;
      }
    }

    public double MaxTErrorStableMode {
      set {
        settings_.MaxTError = value;
      }
      get {
        return settings_.MaxTError;
      }
    }

    public double MaxTStdErrorStableMode {
      set {
        settings_.MaxTStdDev = value;
      }
      get {
        return settings_.MaxTStdDev;
      }
    }
    //public double MaxTErrorInitMode {
    //  set {
    //    settings_.fastMaxTError_ = value;
    //  }
    //  get {
    //    return settings_.fastMaxTError_;
    //  }
    //}

    //public double MaxTStdErrorInitMode {
    //  set {
    //    settings_.fastMaxTStdDev_ = value;
    //  }
    //  get {
    //    return settings_.fastMaxTStdDev_;
    //  }
    //}

    public bool BlockFastRegulation {
      set {
        blockFastMode_ = value;
      }
      get {
        return blockFastMode_;
      }
    }

    //public override void Measure( ref MeasureMultiPoint point ) {
    //  if( point.Entities.Contains( MeasureEntity.Tlaser ) ) {

    //    if( !tecActive )
    //      switchTec( true );

    //    for( int i = 0; i < point[ MeasureEntity.Tlaser ].Length; i++ ) {
    //      point[ MeasureEntity.Tlaser ][ i ] = measureTemperature( );
    //    }
    //  }
    //}


    //public override void SetControlPoint( ControlPoint point ) {
    //  foreach( KeyValuePair<ControlEntity, EntityState> kvp in point ) {
    //    if( kvp.Key.ToString( ) == "Tlaser" )
    //      setTemperature( ( float )kvp.Value.Value );
    //    else if( kvp.Key.ToString( ) == "Itec" )
    //      setCurrent( ( float )kvp.Value.Value );
    //    else
    //      throw new ApplicationException( "Ke2510 cannot set control entity: " + kvp.Key.ToString( ) );
    //  }
    //}
    #region help methods and classes

    /// <summary>
    /// Returns the resistance for a given temperature using the Steinhart model = default for instrument ctrl/meas.
    /// </summary>
    /// <param name="T">In celcius</param>
    /// <returns></returns>
    public double ThermistorResistance( double T ) {
      // We have not implemented any exponential control. Therefore:
      return steinhartModel.Resistance( T );
    }

    /// <summary>
    /// Returns the temperature for given resistance using the exponential model.
    /// </summary>
    /// <param name="ThermistorResistance"></param>
    /// <returns></returns>
    public double TemperatureUsingExponentialModel( double ThermistorResistance ) {
      return exponentialModel.Temperature( ThermistorResistance );
    }

    /// <summary>
    /// Return the temperature for given resistance using the Steinhart-Hart model.
    /// </summary>
    /// <param name="ThermistorResistance"></param>
    /// <returns></returns>
    public double TemperatureUsingSteinhartHartModel( double ThermistorResistance ) {
      return steinhartModel.Temperature( ThermistorResistance );
    }

    /// <summary>
    /// Returns the resistance for given temperature using the exponential model.
    /// </summary>
    /// <param name="Temperature">In celcius</param>
    /// <returns></returns>
    public double ResistanceUsingExponentialModel( double Temperature ) {
      return exponentialModel.Resistance( Temperature );
    }
    ///<summary>
    /// Computes the temperature dependent thermistor resistance
    /// with Steinhart-Hart approxiamtion
    ///<\summary>
    private class SteinhartModel {
      private double a_;
      private double b_;
      private double c_;

      private double alpha;
      private double beta;

      //  public double a_;
      //  public double b_;
      //  public double c_;
      private const double T_zeroCelcius = 273.15; // Degrees Kelvin at zero degrees Celcius

      public SteinhartModel( double A, double B, double C ) {
        a_ = A;
        b_ = B;
        c_ = C;
      }

      public double Resistance( double T ) {
        // double alpha; 
        // double beta; 

        double R;
        double t = T + T_zeroCelcius;

        alpha = ( a_ - 1.0D / t ) / c_;
        beta = Math.Sqrt( Math.Pow( ( b_ / ( 3.0D * c_ ) ), 3 ) + alpha * alpha / 4.0D );

        // Debug
        // (String.Format("A = {0:E4}, B = {1:E4}, C = {2:E4}", a_, b_, c_)).LogInfo();
        //(String.Format("alpha = {0:E4}, beta = {1:E4}",alpha,beta)).LogInfo();

        R = Math.Exp( ( Math.Pow( ( beta - ( alpha / 2.0D ) ), ( 1.0D / 3.0D ) ) - Math.Pow( ( beta + ( alpha / 2.0D ) ), ( 1.0D / 3.0D ) ) ) );

        return R;
      }

      public double Temperature( double R ) {
        double resiprokalT = a_ + b_ * ( Math.Log( R ) ) + c_ * Math.Pow( Math.Log( R ), 3 );
        return 1f / resiprokalT - T_zeroCelcius;
      }

      public double A {
        get {
          return a_;
        }
        set {
          a_ = value;
        }
      }

      public double B {
        get {
          return b_;
        }
        set {
          b_ = value;
        }
      }

      public double C {
        get {
          return c_;
        }
        set {
          c_ = value;
        }
      }

      // make alpha and beta available for debugging purpose
      public double Alpha {
        get {
          return alpha;
        }
      }
      public double Beta {
        get {
          return beta;
        }
      }
    }

    ///<summary>
    /// Computes the temperature dependent thermistor resistance
    /// with the Exponential approxiamtion
    ///
    /// R = R0 exp(beta*(T0 - T)/(T*T0))
    ///
    ///<\summary>
    private class ExponentialModel {
      private double beta_;
      private double r0_;
      private double t0_;

      private const double T_zeroCelcius = 273.15; // Degrees Kelvin at zero degrees Celcius

      /// <summary>
      /// Exponential thermisor model.
      /// </summary>
      /// <param name="Beta"></param>
      /// <param name="R0">In ohms</param>
      /// <param name="T0">In celcius</param>
      public ExponentialModel( double Beta, double R0, double T0 ) {
        beta_ = Beta;
        r0_ = R0;
        t0_ = T0;
      }

      public double Resistance( double T ) {

        double R;
        double t = T + T_zeroCelcius;
        double t0 = T0 + T_zeroCelcius;


        R = r0_ * Math.Exp( beta_ * ( t0 - t ) / ( t * t0 ) );

        return R;
      }

      public double Temperature( double R ) {
        double T;

        T = 1 / ( 1 / ( t0_ + T_zeroCelcius ) + 1 / beta_ * Math.Log( R / r0_ ) );

        return T - T_zeroCelcius;
      }

      public double Beta {
        get {
          return beta_;
        }
        set {
          beta_ = value;
        }
      }

      public double R0 {
        get {
          return r0_;
        }
        set {
          r0_ = value;
        }
      }

      public double T0 {
        get {
          return t0_;
        }
        set {
          t0_ = value;
        }
      }

    }

    #endregion


    protected override void InternalConnect( ) {
      gpib_ = new GpibDriver( settings_.Adress, NationalInstruments.NI4882.TimeoutValue.T30s );
    }

    protected override void InternalDisconnect( ) {
    }

    protected override void InternalReset( ) {
      setThermistorParams( settings_.R0, settings_.SteinhartHartC1, settings_.SteinhartHartC2, settings_.SteinhartHartC3 );
      setTempSourcePidParams( settings_.Fast );
    }

    //public override XElement XmlSettings {
    //  get {
    //    return settings_.XmlSerializeToXElement( );
    //  }
    //  set {
    //    settings_ = value.XmlDeserialize<Ke2510Settings>( );
    //  }
    //}

    public Ke2510Settings Settings {
      get {
        return settings_;
      }
      set {
        settings_ = value;
      }
    }

    public Ke2510Settings OverrideSettings {
      set {
        overridingSettings_ = value;
      }
    }

    public virtual double CurrentTemperature {
      get {
        return measureTemperature( );
      }
      set {
        setTemperature( ( float )value );
      }
    }

    void ITec.StabilizeTemperature( ) {
      StabilizeTemperature( );
    }

    double ITec.CurrentTemperature {
      get { return CurrentTemperature; }
    }

    double ITec.TargetTemperature {
      get {
        return ( double )getTargetTemperature( );
      }
      set {
        setTemperature( ( float )value );
      }
    }


    //public override ControlPoint CurrentState {
    //  get { throw new NotImplementedException( ); }
    //}

    //public override ControlPoint DefaultState {
    //  get { throw new NotImplementedException( ); }
    //}

    //public override double GetCompliance( ControlEntity c ) {
    //  throw new NotImplementedException( );
    //}

    //public override void SetCompliance( ControlEntity c, double value ) {
    //  throw new NotImplementedException( );
    //}

    //public override OffState GetOffState( ControlEntity c ) {
    //  throw new NotImplementedException( );
    //}

    //public override void SetOffState( ControlEntity c, OffState state ) {
    //  throw new NotImplementedException( );
    //}

    #region Syntune.TemperatureControl.TEC.ITECController

    private void WriteString( string s ) {
      gpib_.Write( s );
    }

    private double ReadDouble( ) {
      string s = gpib_.Read( );
      return double.Parse( s, CultureInfo.InvariantCulture );
    }

    double TemperatureControl.TEC.ITECController.Current {

      get {
        WriteString( ":MEAS:CURR?" );
        return ReadDouble( );
      }

      set {
        WriteString( ":SOUR:FUNC:MODE CURR" );
        WriteString( ":SOUR:CURR " + value );
        WriteString( ":OUTP ON" );
      }

    }

    double TemperatureControl.TEC.ITECController.Resistance {

      get {
        WriteString( ":MEAS:RES?" );
        return ReadDouble( );
      }

      set {
        WriteString( ":SOUR:FUNC:MODE RES" );
        WriteString( ":SOUR:RES " + value );
        WriteString( ":OUTP ON" );
      }

    }

    double TemperatureControl.TEC.ITECController.Voltage {

      get {
        WriteString( ":MEAS:VOLT?" );
        return ReadDouble( );
      }

      set {
        WriteString( ":SOUR:FUNC:MODE VOLT" );
        WriteString( ":SOUR:VOLT " + value );
        WriteString( ":OUTP ON" );
      }

    }

    double TemperatureControl.TEC.ITECController.Power {

      get {
        WriteString( ":MEAS:POW?" );
        return ReadDouble( );
      }

      set {
        WriteString( ":SOUR:FUNC:MODE POW" );
        WriteString( ":SOUR:POW " + value );
        WriteString( ":OUTP ON" );
      }

    }

    double TemperatureControl.TEC.ITECController.Temperature {

      get {
        WriteString( ":MEAS:TEMP?" );
        return ReadDouble( );
      }

      set {
        WriteString( ":SOUR:FUNC:MODE TEMP" );
        WriteString( ":SOUR:TEMP " + value );
        WriteString( ":OUTP ON" );
      }

    }

    TemperatureControl.TEC.PID TemperatureControl.TEC.ITECController.PID {

      get {
        WriteString( ":SOUR:TEMP:LCON:GAIN?" );
        double p = ReadDouble( );
        WriteString( ":SOUR:TEMP:LCON:INT?" );
        double i = ReadDouble( );
        WriteString( ":SOUR:TEMP:LCON:DER?" );
        double d = ReadDouble( );
        return new TemperatureControl.TEC.PID( p, i, d );
      }

      set {
        WriteString( ":SOUR:TEMP:LCON:GAIN " + value.P.ToString( CultureInfo.InvariantCulture ) );
        WriteString( ":SOUR:TEMP:LCON:INT " + value.I.ToString( CultureInfo.InvariantCulture ) );
        WriteString( ":SOUR:TEMP:LCON:DER " + value.D.ToString( CultureInfo.InvariantCulture ) );
      }

    }

    void TemperatureControl.TEC.ITECController.InternalReset( ) {
      gpib_.Reset( );
      setThermistorParams( settings_.R0, settings_.SteinhartHartC1, settings_.SteinhartHartC2, settings_.SteinhartHartC3 );
      setTempSourcePidParams( settings_.Fast );
    }

    #endregion

  }

}