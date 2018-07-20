using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NationalInstruments.NI4882;
using System.Diagnostics;

namespace Finisar {

  /// <summary>
  /// Class containing the settings for the Agilent E3631A Triple Output DC Power Supply
  /// </summary>
  [Serializable]
  public class AgSettings {
      protected static AgSettings defaultSettings_;

      public byte GpibAddress;
      public TimeoutValue GpibTimeout;
      public VIType CtrolType;
      
      static AgSettings( ) {
          defaultSettings_ = new AgSettings( );
          defaultSettings_.GpibAddress = 1;
          defaultSettings_.GpibTimeout = TimeoutValue.T30s;
          defaultSettings_.CtrolType = VIType.Voltage;
      }
      public static AgSettings DefaultSettings {
          get {
              return ( AgSettings )defaultSettings_.MemberwiseClone( );
          }
      }
  }
  public class AgPowerSupply {
    protected GpibDriver gpib = null;
    protected bool isDisposed = false;
    protected CultureInfo culture = new CultureInfo( "en-US" );
    protected AgSettings settings;

    /// <summary>
    /// int: Gpib address
    /// AgE3640AOutputVoltage: Output select
    /// VIType: Voltage or Current
    /// Double: Corresponding compliance value
    /// </summary>

    public AgPowerSupply( ) { settings = AgSettings.DefaultSettings; }

    public AgPowerSupply( byte address ) : this( address, TimeoutValue.T30s ) { }

    public AgPowerSupply( byte address, TimeoutValue timeout )
      : this( ) {
          settings = AgSettings.DefaultSettings;
      settings.GpibAddress = address;
      settings.GpibTimeout = timeout;
      this.InternalConnect( );
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
    public virtual bool OutputEnabled {
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
    /// Method used to set SourceControl as Voltage or Current control
    /// </summary>
    public VIType SourceControlType {
        get { return settings.CtrolType; }
        set {
            settings.CtrolType = value;
        }
    }

    public virtual string Name {
        get { return "Agilent E3646A"; }
        set { }
    }

    public byte GpibAddress {
        get {
            return this.settings.GpibAddress;
        }
        set {
            this.settings.GpibAddress = value;
        }
    }

    /// <summary>
    /// Method used to enable all three outputs
    /// </summary>
    protected virtual void EnableOutput( ) {
      try {
        gpib.Write( ":OUTP ON" );
      }
      catch( Exception ex ) {
        throw new Exception( "Error enabling output.", ex );
      }
    }

    /// <summary>
    /// Method used to disable all three outputs
    /// </summary>
    protected virtual void DisableOutput( ) {
      try {
        gpib.Write( ":OUTP OFF" );
      }
      catch( Exception ex ) {
          throw new Exception( "Error disabling output.", ex );
      }
    }

    /// <summary>
    /// Method used to see if all three outputs are enabled or disabled
    /// </summary>
    /// <returns>True if enabled, false otherwise</returns>
    public bool IsOutputEnabled( ) {
      try {
        gpib.Write( ":OUTP?" );

        string answer = gpib.ReadLast( );

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
          throw new Exception( sb.ToString( ) );
        }
      }
      catch( Exception ex ) {
          throw new Exception( "Error getting output state.", ex );
      }
    }

    public void Measure( ref float value1, ref float value2, bool isMeasureVoltage ) {
        if( isMeasureVoltage ) {
            value1 = GetVoltageReading( "OUT1" );
            value2 = GetVoltageReading( "OUT2" );
        }
        else {
            value1 = GetCurrentReading( "OUT1" );
            value2 = GetCurrentReading( "OUT2" );
        }
    }

    public float GetVoltage( ) {
        try {
            gpib.Write( "MEAS:VOLT?" );

            return gpib.ReadFloat( );
        }
        catch( Exception ex ) {
            throw new Exception( "Error measuring voltage.", ex );
        }
    }

    /// <summary>
    /// Method used to retrieve a measured current value
    /// </summary>
    public float GetCurrent( ) {
        try {
            gpib.Write( "MEAS:CURR?" );

            return gpib.ReadFloat( );
        }
        catch( Exception ex ) {
            throw new Exception( "Error measuring current.", ex );
        }
    }

    public float GetCurrentReading( string output ) {
        SetOutput( output );
        return GetCurrent( );
    }
    public float GetVoltageReading( string output ) {
        SetOutput( output );
        return GetVoltage( );
    }

    public virtual void SetOutput( string output ) {
        try {
            string outputString = string.Empty;

            switch( output.ToLower() ) {
                case "out1":
                    outputString = "OUT1";
                    break;

                case "out2":
                    outputString = "OUT2";
                    break;
            }

            string command = String.Format( "INST:SELECT {0}", outputString );

            this.gpib.Write( command );
        }
        catch( Exception ex ) {
            throw new Exception( "Error setting E3646A output.", ex );
        }
    }

    public void Set( string output, float value ) {
        if( SourceControlType == VIType.Voltage ) {
            SetVoltage( output, value );
        }
        else {
            SetCurrent( output, value );
        }
    }
    public void SetVoltage(string output, float voltage ) {
        SetOutput( output );
        string command = String.Format( "VOLT {0}", voltage.ToString( "00.000", culture ) );
        gpib.Write( command );
    }
    public void SetCurrentLimit(string output, float current)
    {
        SetOutput(output);
        string command = String.Format("CURR {0}", current.ToString("00.000", culture));
        gpib.Write(command);
    }
    public void SetCurrent( string output, float value ) {
        SetOutput( output );
        string command = String.Format( "CURR {0}", value.ToString( "00.000", culture ) );
        gpib.Write( command );
    }

    #region IInstrument implementation

    protected void InternalConnect( ) {
      try {
        this.gpib = new GpibDriver( this.settings.GpibAddress );
        GpibIdentity id = gpib.GetIdentity( );
        if( id != null ) {
            string strId = id.serialNumber;
        }
      }
      catch {
          throw new Exception( "Error connecting instrument." );
      }
    }

    protected void InternalDisconnect( ) {
      try {
        this.gpib = null;
      }
      catch {
          throw new Exception( "Error disconnecting instrument." );
      }
    }

    protected void InternalReset( ) {
      try {
        this.gpib.Reset( );
      }
      catch {
          throw new Exception( "Error resetting instrument." );
      }
    }

    

    #endregion

    public void Dispose( ) {
      this.gpib.Dispose( );
    }
    

  }

}
