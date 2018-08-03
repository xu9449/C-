using System;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using NationalInstruments.NI4882;

namespace Finisar {
  /// <summary>
  /// Enumerator values for the limits of the output voltage
  /// </summary>
  public enum AgE3631AOutputVoltage {
    P06V = 1,
    P25V = 2,
    N25V = 3
  };

  /// <summary>
  /// Enumerator values for the +-25 V tracking mode
  /// </summary>
  public enum AgE3631AOutputTrackingMode {
    On = 1,
    Off = 0
  };

  /// <summary>
  /// Class used to represent an exception thrown for the Agilent E3631A Triple Output DC Power Supply
  /// </summary>
  public class AgE3631AError : Exception {

    public AgE3631AError( string errorMessage, Exception innerException )
      : base( "AgE3631AError: " + errorMessage, innerException ) {
    }
    public AgE3631AError( string errorMessage )
      : base( "AgE3631AError: " + errorMessage ) {
    }
    public AgE3631AError( )
      : base( "AgE3631AError: no message" ) {
    }
  }


  /// <summary>
  /// Class containing the settings for the Agilent E3631A Triple Output DC Power Supply
  /// </summary>
  [Serializable]
  public class AgE3631ASettings {
    protected static AgE3631ASettings defaultSettings_;

    public byte GpibAddress;
    public TimeoutValue GpibTimeout;
    public double P06_Voltage;
    public double P06_Compliance;
    public double P25_Voltage;
    public double P25_Compliance;
    public double N25_Voltage;
    public double N25_Compliance;

    static AgE3631ASettings( ) {
      defaultSettings_ = new AgE3631ASettings( );
      defaultSettings_.GpibAddress = 6;
      defaultSettings_.GpibTimeout = TimeoutValue.T30s;
      defaultSettings_.P06_Voltage = 5.00;
      defaultSettings_.P06_Compliance = 0.22;
      defaultSettings_.P25_Voltage = 0.00;
      defaultSettings_.P25_Compliance = 0.000;
      defaultSettings_.N25_Voltage = -0.00;
      defaultSettings_.N25_Compliance = 0.000;
    }

    public static AgE3631ASettings DefaultSettings {
      get {
        return ( AgE3631ASettings )defaultSettings_.MemberwiseClone( );
      }
    }
  }


  /// <summary>
  /// API properties and methods for programming scripts using the Agilent E3631A Triple Output DC Power Supply
  /// </summary>
  public class AgE3631A : Instrument, IDisposable {
    private const string ALL_DIGITS = "0123456789";
    protected AgE3631ASettings settings_ = AgE3631ASettings.DefaultSettings;
    protected GpibDriver gpib_ = null;
    protected bool isDisposed_ = false;
    protected CultureInfo culture_ = new CultureInfo( "en-US" );
    protected AgE3631AOutputVoltage output_;

    /// <summary>
    /// Default constructor for the AgE3631A class
    /// </summary>
    public AgE3631A( ) {
    }

    /// <summary>
    /// Constructor for the AgE3631A class
    /// </summary>
    /// <param name="address">GPIB address</param>
    public AgE3631A( byte address )
      : this( address, TimeoutValue.T30s ) {
          InternalConnect( );
    }

    /// <summary>
    /// Constructor for the AgE3631A class
    /// </summary>
    /// <param name="address">GPIB address</param>
    /// <param name="timeout">Enum timeout value</param>
    public AgE3631A( byte address, TimeoutValue timeout ) {
      settings_ = AgE3631ASettings.DefaultSettings;
      settings_.GpibAddress = address;
      settings_.GpibTimeout = timeout;
    }

    /// <summary>
    /// Dispose method for the AgE3631A class
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
    protected override void InternalConnect( ) {
      try {
        if( gpib_ == null ) {
          gpib_ = new GpibDriver( settings_.GpibAddress, settings_.GpibTimeout );
        }
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error connecting E3631A.", ex );
      }
    }

    /// <summary>
    /// Disposes the current instance of the GPIB driver
    /// </summary>
    protected override void InternalDisconnect( ) {
      try {
        gpib_.Dispose( );
        gpib_ = null;
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error disconnecting E3631A.", ex );
      }
    }

    /// <summary>
    /// Method used to reset the Agilent E3631A Triple Output DC Power Supply unit
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <i>"*RST"</i>
    /// </summary>
    protected override void InternalReset( ) {
      try {
        gpib_.Reset( );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error resetting E3631A.", ex );
      }
    }

    public override void ApplySettings( ) {
      base.ApplySettings( );

      //foreach( AgE3631AOutputVoltage output in Enum.GetValues( typeof( AgE3631AOutputVoltage ) ) ) {
      SetOutput( AgE3631AOutputVoltage.P06V );
      SetVoltageLimit( ( float )settings_.P06_Voltage );
      SetCurrentLimit( ( float )settings_.P06_Compliance );

      SetOutput( AgE3631AOutputVoltage.P25V );
      SetVoltageLimit( ( float )settings_.P25_Voltage );
      SetCurrentLimit( ( float )settings_.P25_Compliance );

      SetOutput( AgE3631AOutputVoltage.N25V );
      SetVoltageLimit( ( float )settings_.N25_Voltage );
      SetCurrentLimit( ( float )settings_.N25_Compliance );
      //}
    }

    /// <summary>
    /// Gets/sets the settings for the instrument
    /// </summary>
    public AgE3631ASettings Settings {
      get {
        return settings_;
      }
      set {
        settings_.GpibAddress = value.GpibAddress;
        settings_.GpibTimeout = value.GpibTimeout;
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
    /// Gets/sets the currently selected output 
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Set: </b> 
    /// <i>"INST:SEL {0}"</i>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>"INST:SEL?"</i>
    /// </summary> 
    public AgE3631AOutputVoltage Output {
      get {
        return GetOutput( );
      }
      set {
        SetOutput( value );
      }
    }

    /// <summary>
    /// Gets a measured voltage value
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>"MEAS:VOLT?"</i>
    /// </summary> 
    public float Voltage {
      get {
        return GetVoltage( );
      }
    }

    /// <summary>
    /// Gets a measured current value
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>"MEAS:CURR?"</i>
    /// </summary> 
    public float Current {
      get {
        return GetCurrent( );
      }
    }

    /// <summary>
    /// Gets/sets the voltage limit for the chosen output
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Set: </b> 
    /// <i>"VOLT {00.000}"</i>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>"VOLT?"</i>
    /// </summary> 
    public float VoltageLimit {
      get {
        return GetVoltageLimit( );
      }
      set {
        SetVoltageLimit( value );
      }
    }

    /// <summary>
    /// Gets/sets the current limit for the chosen output
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Set: </b> 
    /// <i>"CURR {00.000}"</i>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>"CURR?"</i>
    /// </summary> 
    public float CurrentLimit {
      get {
        return GetCurrentLimit( );
      }
      set {
        SetCurrentLimit( value );
      }
    }

    /// <summary>
    /// Gets/sets whether the output is enabled or disabled
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Set: </b> 
    /// <i>":OUTP ON", ":OUTP OFF"</i>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>":OUTP?"</i>
    /// </summary> 
    public bool OutputEnabled {
      get {
        return IsOutputEnabled( );
      }
      set {
        if( value == true ) {
          EnableOutput( );
        }
        else {
          DisableOutput( );
        }
      }
    }

    /// <summary>
    /// Gets/sets the tracking mode for +-25 V outputs on or off
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <b>Set: </b> 
    /// <i>":OUTP:TRAC ON", ":OUTP:TRAC OFF"</i>
    /// <para/>
    /// <b>Get: </b> 
    /// <i>":OUTP:TRAC?"</i>
    /// </summary> 
    public AgE3631AOutputTrackingMode TrackingMode {
      get {
        return Get25VOutputTrackingMode( );
      }
      set {
        Set25VOutputTrackingMode( value );
      }
    }

    /// <summary>
    /// Method used to save the current state of the power supply to a save register (1 - 3)
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <i>"*SAV {0}"</i>
    /// </summary> 
    /// <param name="register">Value for the save register</param>
    public void SaveSetup( int register ) {
      try {
        if( ( register < 1 ) || ( register > 3 ) ) {
          throw new AgE3631AError( "Invalid save register value. Allowed values are 1 - 3." );
        }

        string command = String.Format( "*SAV {0}", register );

        gpib_.Write( command );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error saving E3631A setup.", ex );
      }
    }

    /// <summary>
    /// Method used to restore the state of the power supply to a previously stored 
    /// configuration in the save/recall register (1 - 3).
    /// <para/>
    /// <b>GPIB COMMANDS</b>
    /// <para/>
    /// <b>============</b>
    /// <para/>
    /// <i>"*RCL {0}"</i>
    /// </summary> 
    /// <param name="register">Value for the save register</param>
    public void RecallSetup( int register ) {
      try {
        if( ( register < 1 ) || ( register > 3 ) ) {
          throw new AgE3631AError( "Invalid save register value. Allowed values are 1 - 3." );
        }

        string command = String.Format( "*RCL {0}", register );

        gpib_.Write( command );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error recalling E3631A setup.", ex );
      }
    }

    /// <summary>
    /// Method used to select the output to use
    /// </summary>
    public virtual void SetOutput( AgE3631AOutputVoltage output ) {
      try {
        string outputString = string.Empty;

        switch( output ) {
          case AgE3631AOutputVoltage.P06V:
            outputString = "P6V";
            break;

          case AgE3631AOutputVoltage.P25V:
            outputString = "P25V";
            break;

          case AgE3631AOutputVoltage.N25V:
            outputString = "N25V";
            break;

          default:
            throw new AgE3631AError( "Invalid output enumerator value. Allowed values are P6V, P25V, N25V." );
        }

        string command = String.Format( "INST:SEL {0}", outputString );

        gpib_.Write( command );

        output_ = output;
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error setting E3631A output.", ex );
      }
    }

    /// <summary>
    /// Method used to retrieve the currently selected output
    /// </summary>
    protected virtual AgE3631AOutputVoltage GetOutput( ) {
      try {
        gpib_.Write( "INST:SEL?" );

        string answer = gpib_.ReadLast( );

        if( answer.Contains( "P6V" ) ) {
          return AgE3631AOutputVoltage.P06V;
        }
        else if( answer.Contains( "P25V" ) ) {
          return AgE3631AOutputVoltage.P25V;
        }
        else if( answer.Contains( "N25V" ) ) {
          return AgE3631AOutputVoltage.N25V;
        }
        else {
          StringBuilder sb = new StringBuilder( );
          sb.Append( "Bad result from INST:SEL? -> " );
          sb.Append( answer );
          throw new AgE3631AError( sb.ToString( ) );
        }
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error getting E3631A output.", ex );
      }
    }

    /// <summary>
    /// Method used to retrieve a measured voltage value
    /// </summary>
    protected float GetVoltage( ) {
      try {
        gpib_.Write( "MEAS:VOLT?" );

        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error measuring voltage.", ex );
      }
    }

    /// <summary>
    /// Method used to retrieve a measured current value
    /// </summary>
    protected float GetCurrent( ) {
      try {
        gpib_.Write( "MEAS:CURR?" );

        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error measuring current.", ex );
      }
    }

    /// <summary>
    /// Method used to set the voltage limit for the chosen output
    /// </summary>
    /// <param name="voltage">Voltage value</param>
    protected virtual void SetVoltageLimit( float voltage ) {
      try {
        switch( output_ ) {
          case AgE3631AOutputVoltage.P06V:
            if( voltage < 0 || voltage > 6.18 ) {
              throw new AgE3631AError( "Invalid voltage value for the P6V output. Allowed values are between 0 - 6.18 V " );
            }
            break;

          case AgE3631AOutputVoltage.P25V:
            if( voltage < 0 || voltage > 25.75 ) {
              throw new AgE3631AError( "Invalid voltage value for the P25V output. Allowed value are between 0 - 25.75 V" );
            }
            break;

          case AgE3631AOutputVoltage.N25V:
            if( voltage < -25.75 || voltage > 0 ) {
              throw new AgE3631AError( "Invalid voltage value for the N25V output. Allowed value are between -25.75 - 0 V" );
            }
            break;

          default:
            throw new AgE3631AError( "Invalid output enumerator value." );
        }

        this.SetOutput( this.output_ );
        
        string command = String.Format( "VOLT {0}", voltage.ToString( "00.000", culture_ ) );

        gpib_.Write( command );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error setting voltage limit.", ex );
      }
    }

    /// <summary>
    /// Method used to retrieve the voltage limit for the chosen output
    /// </summary>
    /// <returns>Voltage limit value</returns>
    protected virtual float GetVoltageLimit( ) {
      try {
        gpib_.Write( "VOLT?" );

        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error getting voltage limit.", ex );
      }
    }

    /// <summary>
    /// Method used to set the current limit for the chosen output
    /// </summary>
    /// <param name="current">Current value</param>
    protected virtual void SetCurrentLimit( float current ) {
      try {
        switch( output_ ) {
          case AgE3631AOutputVoltage.P06V:
            if( current < 0 || current > 5.15 ) {
              throw new AgE3631AError( "Invalid current value for the P6V output. Allowed values are between 0 - 5.15 A " );
            }
            break;

          case AgE3631AOutputVoltage.P25V:
            if( current < 0 || current > 1.03 ) {
              throw new AgE3631AError( "Invalid current value for the P25V output. Allowed value are between 0 - 1.03 A" );
            }
            break;

          case AgE3631AOutputVoltage.N25V:
            if( current < 0 || current > 1.03 ) {
              throw new AgE3631AError( "Invalid current value for the N25V output. Allowed value are between 0 - 1.03 A" );
            }
            break;
        }

        string command = String.Format( "CURR {0}", current.ToString( "00.000", culture_ ) );

        gpib_.Write( command );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error setting current compliance.", ex );
      }
    }

    /// <summary>
    /// Method used to retrieve the current limit for the chosen output
    /// </summary>
    /// <returns>Current limit value</returns>
    protected virtual float GetCurrentLimit( ) {
      try {
        gpib_.Write( "CURR?" );

        return ReadFloat( );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error getting current compliance.", ex );
      }
    }

    /// <summary>
    /// Method used to enable all three outputs
    /// </summary>
    protected virtual void EnableOutput( ) {
      try {
        gpib_.Write( ":OUTP ON" );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error enabling output.", ex );
      }
    }

    /// <summary>
    /// Method used to disable all three outputs
    /// </summary>
    protected virtual void DisableOutput( ) {
      try {
        gpib_.Write( ":OUTP OFF" );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error disabling output.", ex );
      }
    }

    /// <summary>
    /// Method used to see if all three outputs are enabled or disabled
    /// </summary>
    /// <returns>True if enabled, false otherwise</returns>
    private bool IsOutputEnabled( ) {
      try {
        gpib_.Write( ":OUTP?" );

        string answer = gpib_.ReadLast( );

        if( answer.Contains( "1" ) ) {
          return true;
        }
        else if( answer.Contains( "0" ) ) {
          return false;
        }
        else {
          StringBuilder sb = new StringBuilder( );
          sb.Append( "Bad result from :OUTP? -> " );
          sb.Append( answer );
          throw new AgE3631AError( sb.ToString( ) );
        }
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error getting output state.", ex );
      }
    }

    /// <summary>
    /// Method used to enable or disable the +- 25V tracking mode
    /// </summary>
    /// <param name="mode">Enum value for the tracking mode</param>
    private void Set25VOutputTrackingMode( AgE3631AOutputTrackingMode mode ) {
      try {
        if( mode == AgE3631AOutputTrackingMode.On ) {
          gpib_.Write( ":OUTP:TRAC ON" );
        }
        else {
          gpib_.Write( "OUTP:TRAC OFF" );
        }
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error setting tracking mode.", ex );
      }
    }

    /// <summary>
    /// Method to retrieve whether the +- 25V tracking mode is enabled or disabled
    /// </summary>
    /// <param name="mode">Enum value for the tracking mode</param>
    private AgE3631AOutputTrackingMode Get25VOutputTrackingMode( ) {
      try {
        gpib_.Write( ":OUTP:TRAC?" );

        string answer = gpib_.ReadLast( );

        if( answer.Contains( "1" ) ) {
          return AgE3631AOutputTrackingMode.On;
        }
        else if( answer.Contains( "0" ) ) {
          return AgE3631AOutputTrackingMode.Off;
        }
        else {
          StringBuilder sb = new StringBuilder( );
          sb.Append( "Bad result from :OUTP:TRAC? -> " );
          sb.Append( answer );
          throw new AgE3631AError( sb.ToString( ) );
        }
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error getting tracking mode.", ex );
      }
    }

    /// <summary>
    /// Method used to parse a float value from an incoming response string
    /// </summary>
    /// <returns>Float value, parsed from incoming response string</returns>
    private float ReadFloat( ) {
      try {
        string answer = gpib_.ReadLast( );
        int start = answer.IndexOfAny( ALL_DIGITS.ToCharArray( ) );

        if( ( start < 0 ) || ( start >= answer.Length ) ) {
          StringBuilder sb = new StringBuilder( "ReadFloat: Invalid response string -> \"" );
          sb.Append( answer );
          sb.Append( "\"" );
          throw new AgE3631AError( sb.ToString( ) );
        }

        // Move back one step to include negative '-' sign
        if( start != 0 ) {
          if( answer[ start - 1 ] == '-' ) {
            start--;
          }
        }

        int stop = answer.IndexOf( Environment.NewLine, start );

        if( ( stop < 0 ) || ( stop >= answer.Length ) ) {
          stop = answer.Length;
        }

        return float.Parse( answer.Substring( start, stop - start ), NumberStyles.Any, culture_ );
      }
      catch( Exception ex ) {
        throw new AgE3631AError( "Error reading float.", ex );
      }
    }

  }
}
