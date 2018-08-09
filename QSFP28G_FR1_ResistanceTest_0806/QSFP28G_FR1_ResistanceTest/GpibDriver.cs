using System;
using System.Linq;
using NationalInstruments.NI4882;
using System.Globalization;

namespace QSFP28G_FR1_ResistanceTest
{
  public class GpibDriver : IDisposable {

    private Device device_;
    private object sync = new object( );
    CultureInfo culture_ = new CultureInfo( "en-US" );

    public Device Device {
      get { return device_; }
      set { device_ = value; }
    }
    private bool isDisposed_ = false;
    //private bool isConnected_ = false;
    private string answer_ = "";
    private string command_ = "";
    public string Answer {
      get {
        return answer_;
      }
    }

    public GpibDriver( byte primaryAddress ) : this( primaryAddress, TimeoutValue.T100s ) { }

    public GpibDriver( byte primaryAddress, TimeoutValue timeout ) {
      device_ = null;
      int boardId = 0;
      byte secondaryAddress = 0;
      device_ = new Device( boardId, primaryAddress, secondaryAddress, timeout );
      device_.SynchronizeCallbacks = true;
      device_.DefaultBufferSize = 1048576;
      device_.EndOfStringCharacter = 0x0A;
      device_.TerminateReadOnEndOfString = true;
    }

    //public GpibDriver( int boardId, byte primaryAddress, byte secondaryAddress ) {
    //  device_ = new Device( boardId, primaryAddress, secondaryAddress );

    //  device_.DefaultBufferSize = 1048576;
    //  device_.EndOfStringCharacter = 0x0A;
    //  device_.TerminateReadOnEndOfString = true;
    //}

    public void Dispose( ) {
      try {
        if( !this.isDisposed_ ) {
          device_.Dispose( );
          isDisposed_ = true;
        }
      }
      catch( Exception e ) {
        throw new Exception( "Gpib Error", e );
      }
    }

    public virtual void Write( string stringToWrite ) {
      lock( sync )
        device_.Write( stringToWrite );
    }

    public string Query( string message ) {
      lock( sync ) {
        device_.Write( message );
        return device_.ReadString( );
      }
    }

    public string Read( ) {
      lock( sync )
        return device_.ReadString( );
    }

    public string ReadLast( ) {
      lock( sync )
        return device_.ReadString( ).Split( ';' ).Last( ).Trim( );
    }

    public void ReadAndIgnore( ) {
      lock( sync )
        device_.ReadString( );
    }

    public byte[ ] ReadByteArray( ) {
      lock( sync )
        return device_.ReadByteArray( );
    }
    /// <summary>
    /// Method used to parse a float value from an incoming response string.
    /// An unavailable value is represented by 9.9999e37, which we translate into float.NaN.
    /// </summary>
    /// <returns>Float value, parsed from incoming response string</returns>
    public float ReadFloat( ) {
        try {
            string answer = Read( ).Trim( );

            float result = 0;
            if( !float.TryParse( answer, NumberStyles.Any, culture_, out result ) )
                throw new Exception( "Can not parse response value to float (ReadFloat): \"" + answer + "\"" );

            if( result > 9.0e37f )
                return float.NaN;

            return result;
        }
        catch( Exception ex ) {
            throw new Exception( "Error GPIB reading float.", ex );
        }
    }
    /// <summary>
    ///  Read instrument ID: Manufacturer, Model #, Serial #, FW revision
    /// </summary>
    /// <returns></returns>
    public GpibIdentity GetIdentity( ) {
      this.Write( "*IDN?" );
      answer_ = Read( );

      GpibIdentity id = new GpibIdentity( );
      string idString = answer_;
      int length = idString.Length;
      int start, stop;

      start = 0;
      while( idString[ start ] == ',' ) {
        start++;
      };

      if( ( start >= 0 ) && ( start < length ) ) {
        stop = idString.IndexOf( ",", start );
        if( ( stop < 0 ) || ( stop > length ) )
          stop = length;
        id.manufacturer = idString.Substring( start, stop - start );
        start = idString.IndexOf( ",", stop ) + 1;
      }
      if( ( start >= 0 ) && ( start < length ) ) {
        stop = idString.IndexOf( ",", start );
        if( ( stop < 0 ) || ( stop > length ) )
          stop = length;
        id.model = idString.Substring( start, stop - start );

        start = stop-1;
        while( idString[ start ] == ',' ) {
          start++;
        };
      }
      if( ( start >= 0 ) && ( start < length ) ) {
        stop = idString.IndexOf( ",", start );
        if( ( stop < 0 ) || ( stop > length ) )
          stop = length;
        id.serialNumber = idString.Substring( start, stop - start );
        start = stop - 1;
        while( idString[ start ] == ',' ) {
          start++;
        };
      }
      if( ( start >= 0 ) && ( start < length ) ) {
        stop = idString.IndexOf( ",", start );
        if( ( stop < 0 ) || ( stop > length ) )
          stop = length;
        id.firmwareVersion = idString.Substring( start, stop - start );
      }
      return id;
    }

    /// <summary>
    /// Preset the instrument to a factory defined condition
    /// </summary>
    public void Reset( ) {
      lock( sync )
        this.Write( "*RST" );
    }

    /// <summary>
    ///  Empty the error queue and clear all bits in all of the event registers
    /// </summary>
    public void ClearStatus( ) {
      lock( sync )
        this.Write( "*CLS" );
    }

    /// <summary>
    /// Cause the instrument to wait until all pending commands are completed
    /// before executing any additional commands
    /// </summary>
    public void Wait( ) {
      lock( sync )
        this.Query( "*OPC?" );
    }

    /// <summary>
    /// Stop any new commands from being processed until the current processing
    /// is complete
    /// </summary>
    public int WaitOperationComplete( ) {

        return int.Parse(this.Query( "*OPC?" ));
    }

    /// <summary>
    /// Perform a full self-test.
    /// </summary>
    public void PerformSelfTest( ) {
      lock( sync )
        answer_ = this.Query( "*TST?" );

      if( Convert.ToByte( answer_ ) != 0 )
        throw new GpibException( string.Format( "Device self test failed." ) );
    }

    /// <summary>
    /// Serial poll the device and return the response byte
    /// </summary>
    /// <returns></returns>
    public byte PerformSerialPoll( ) {
      // char serialPollResponseByte;   // C++ code, delete when C# code verified
      SerialPollFlags serialPollResponseByte;
      lock( sync ) {
        serialPollResponseByte = device_.SerialPoll( );
      }
      return Convert.ToByte( serialPollResponseByte );
    }

    /// <summary>
    /// Return the value of the status byte register without erasing its contents
    /// </summary>
    /// <returns></returns>
    public byte GetStatusByte( ) {
      lock( sync )
        answer_ = this.Query( "*STB?" );
      return Convert.ToByte( answer_ );
    }

    /// <summary>
    /// Return the value of (and clear) the Standard Event Status register
    /// </summary>
    /// <returns></returns>
    public byte GetEventStatusRegister( ) {
      lock( sync )
        answer_ = this.Query( "*ESR?" );
      return Convert.ToByte( answer_ );
    }

    /// <summary>
    /// Set the Standard Event Status Enable register
    /// </summary>
    /// <param name="ese"></param>
    public void SetEventStatusEnableRegister( byte ese ) {
      // sprintf( command_, "*ESE %d", ese );   // C++ code, keep until C# code verified
      command_ = string.Format( "*ESE {0}", ese );
      this.Write( command_ );
    }

    /// <summary>
    /// Return the value of the Standard Event Status Enable register
    /// </summary>
    /// <returns></returns>
    public byte GetEventStatusEnableRegister( ) {
      lock( sync )
        answer_ = this.Query( "*ESE?" );
      return Convert.ToByte( answer_ );
    }

    /// <summary>
    /// Set the Service Request Enable register
    /// </summary>
    /// <param name="sre"></param>
    public void SetServiceRequestEnableRegister( byte sre ) {
      // sprintf( command_, "*SRE %d", sre );    // C++ code, keep until C# code verified
      command_ = string.Format( "*SRE {0}", sre );
      this.Write( command_ );
    }

    /// <summary>
    /// Return the value of the Service Request Enable register
    /// </summary>
    /// <returns></returns>
    public byte GetServiceRequestEnableRegister( ) {
      lock( sync )
        answer_ = Query( "*SRE?" );
      return Convert.ToByte( answer_ );
    }
  }

  public class GpibIdentity {
    public string manufacturer;
    public string model;
    public string serialNumber;
    public string firmwareVersion;
  };

  public class GpibException : ApplicationException {
    private string messageDetails_;

    public GpibException( ) {
    }

    public GpibException( string message ) {
      messageDetails_ = message;
    }

    public override string Message {
      get {
        return string.Format( "GPIB communication error: {0}.", messageDetails_ );
      }
    }
  }
  
    public enum Compliance { Minimum, Maximum, Operational }

    public enum VIType {
        Voltage,
        Current
    }

    public enum ACDCType {
        AC,
        DC
    }

    public enum SourceMeasurement {
        Source = 1, // 001
        Measurement = 2, // 010
        SourceMeasurement = 3 // 001 + 010 = 011
    }

    public class GpibCommandString {
        private String _cmd = String.Empty;

        public String CommandString {
            get {
                if( this._cmd == string.Empty ) {
                    throw new NoCommandStringException( );
                }
                else {
                    return _cmd;
                }
            }
            set { _cmd = value.Trim( ); }
        }

        public GpibCommandString( String cmd ) {
            //trimmed in the property set
            this.CommandString = cmd;
        }

        public GpibCommandString( ) { }

        private class NoCommandStringException : Exception { }

        public String Query( ) {
            // assume string is already trimmed, because we trim in constructor and property set
            try {
                return ( this.CommandString.Substring( this.CommandString.Length - 1 ) == "?" ?
                    this.CommandString :
                    this.CommandString + "?" );
            }
            catch( NoCommandStringException ) {
                // exception is handled when the string has not been initialized
                // this is possible since there is an empty constructor
                return String.Empty;
            }
        }

        public String Write( String value ) {
            return _cmd + " " + value.Trim( );
        }

        public String Write<T>( T value ) {
            return this.Write( value.ToString( ).Trim( ) );
        }
    }


  public class Compliances {

      public double GetHash( Compliance compliance ) {
          switch( compliance ) {
              case Compliance.Minimum:
                  return this.Minimum;
              case Compliance.Maximum:
                  return this.Maximum;
              case Compliance.Operational:
                  return this.Operational;
              default:
                  return this.Minimum;
          }
      }

      public Compliances( )
          : this( 0, 0, 0 ) {
      }

      public Compliances( double minimum, double maximum, double operational ) {
          this.Minimum = minimum;
          this.Maximum = maximum;
          this.Operational = operational;
      }

      public double Minimum { get; set; }
      public double Maximum { get; set; }
      public double Operational { get; set; }
  }

  [Serializable]
  public class PIDSet : IComparable {
      public double P, I, D, ILimit, Temp;

      public PIDSet( ) {

      }

      public PIDSet( double temp, double p, double i, double d, double ilim ) {
          Temp = temp;
          P = p;
          I = i;
          D = d;
          ILimit = ilim;
      }

      public bool EqualTo( PIDSet p ) {
          if( p != null )
              return ( this.P == p.P ) && ( this.I == p.I ) && ( this.D == p.D );
          else
              return false;
      }

      public int CompareTo( object obj ) {
          try {
              PIDSet p = ( PIDSet )obj;
              return Temp.CompareTo( p.Temp );
          }
          catch {

              return -1;
          }
      }
  }

}