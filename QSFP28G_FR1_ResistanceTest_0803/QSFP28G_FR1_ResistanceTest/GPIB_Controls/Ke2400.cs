using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using NationalInstruments.NI4882;
using System.Threading;

namespace Finisar {

    public class Ke2400 : Instrument {

    protected Ke2400Settings settings = Ke2400Settings.DefaultSettings;
    private GpibDriver gpib = null;

    protected bool isDisposed = false;
    protected CultureInfo culture = new CultureInfo( "en-us" );

    public Ke2400( ) {
      // anything needed?
    }

    public Ke2400( byte address )
      : this( ) {
      this.settings.GpibAddress = address;
      InternalConnect( );
      //SetFrontRear( true );
      //setMeasureFunction( VIType.Current, ACDCType.DC );
      //SetFrontRear( false );
      //setMeasureFunction( VIType.Current, ACDCType.DC );
    }

    public Ke2400( byte address, TimeoutValue timeout )
      : this( address ) {
      this.settings.GpibTimeout = timeout;
    }

    /// <summary>
    /// Keithley 2400
    /// </summary>
    public new string Name {
      get { return "Keithley 2400"; }
      set { }
    }

    /// <summary>
    /// Exposes settings
    /// </summary>
    public Ke2400Settings Settings {
      get {
        return this.settings;
      }
      set {
        this.settings = value;
      }
    }

    /// <summary>
    /// Exposes the gpib driver (read only)
    /// </summary>
    public GpibDriver Driver {
      get { return gpib; }
      private set { gpib = value; }
    }

    #region Instrument overrides

    protected override void InternalConnect( ) {
      try {
        if( this.gpib == null ) {
          this.gpib = new GpibDriver( this.settings.GpibAddress, this.settings.GpibTimeout );
          this.InternalReset( ); // does ApplySettings()
        }
      }
      catch( Exception ex ) {
        throw new Exception( string.Format( "Error connecting {0} with address {1}.\n{2}", this.Name, this.settings.GpibAddress.ToString( ), ex.Message ) );
      }
    }

    protected override void InternalDisconnect( ) {
      try {
        this.gpib.Dispose( );
        this.gpib = null;
      }
      catch( Exception ex ) {
        throw new Exception( string.Format( "Error disconnecting {0} with address {1}.\n{2}", this.Name, this.settings.GpibAddress.ToString( ), ex.Message ) );
      }
    }

    protected override void InternalReset( ) {
      try {
        gpib.Reset( );
        gpib.ClearStatus( );
        // anything else?
        ApplySettings( );
      }
      catch( Exception ex ) {
        throw new Exception( string.Format( "Error resetting {0} with address {1}.\n{2}", this.Name, this.settings.GpibAddress.ToString( ), ex.Message ) );
      }
    }


    public void SetFrontRear( bool isFront ) {
        try {
            string wrt = string.Empty;
            if( isFront )
                wrt = "FRON";
            else
                wrt = "REAR";
            wrt = ":ROUT:TERM " + wrt;
            this.gpib.Write( wrt );
        }
        catch( Exception ex ) {

            throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) );
        }
        
    }

    public void SetBeep(bool beeOn)
    {
        try
        {
            string wrt = string.Empty;
            if (beeOn)
                wrt = "ON";
            else
                wrt = "OFF";
            wrt = ":SYST:BEEP:STAT " + wrt;
            this.gpib.Write(wrt);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message + this.gpib.Device.PrimaryAddress.ToString());
        }

    }
    #endregion

    #region IVIMeasurementInstrument

    private VIType measurementVI;
    private ACDCType measurementACDC;
    private int average;

    /// <summary>
    /// Gets and sets the measurement AC/DC setting
    /// Also applies new V/I setting and previous AC/DC setting to the instrument
    /// </summary>
    public VIType MeasurementVI {
      get {
        return this.measurementVI;
      }
      set {
          //( ( IVIMeasurementInstrument )this ).MeasureConfigure( new VIConfig( value, this.MeasurementACDC, this.Average ) );
        this.measurementVI = value;
      }
    }

    /// <summary>
    /// Gets and sets the measurement V/I setting
    /// Also applies new AC/DC setting and previous V/I setting to the instrument
    /// </summary>
    public ACDCType MeasurementACDC {
      get {
        return this.measurementACDC;
      }
      set {
          //( ( IVIMeasurementInstrument )this ).MeasureConfigure( new VIConfig( this.MeasurementVI, value, this.Average ) );
        this.measurementACDC = value;
      }
    }

    /// <summary>
    /// Property to set / get the averaging amount
    /// Ignores values &lt;= 0 (forces to 1)
    /// </summary>
    public int Average {
      get {
        return ( this.average <= 0 ? 1 : this.average );
      }
      set {
        this.average = ( value <= 0 ? 1 : value );
      }
    }

    /// <summary>
    /// Configures measurement for averaging and V/I + AC/DC
    /// </summary>
    /// <param name="cfg">VIConfig object holding the avg, V/I, and AC/DC</param>
    public void MeasureConfigure( VIConfig cfg ) {
        this.Average = cfg.Average;
        this.setMeasureFunction( cfg.Type, cfg.ACDC );
        //this.AutoRange = true;
        this.SetCompliance( ( ( Compliances )( settings.VoltageOrCurrent == VIType.Current ? this.settings.CurrentCompliances : this.settings.VoltageCompliances ) ).Operational );
    }

    /// <summary>
    /// Configures measurement for averaging and V/I + AC/DC
    /// private method
    /// </summary>
    /// <param name="cfg">VIConfig object holding the avg, V/I, and AC/DC</param>
    private void configureMeasurement( VIConfig cfg ) {
      this.Average = cfg.Average;
      this.setMeasureFunction( cfg.Type, cfg.ACDC );
    }

    /// <summary>
    /// Sets measurement function to V/I AC/DC values
    /// </summary>
    /// <param name="type">V/I</param>
    /// <param name="acdcType">AC/DC</param>
    public virtual void setMeasureFunction( VIType type, ACDCType acdcType ) {
      string wrt = string.Empty;
      try {
        if( this.settings.SourceOrMeasurement == SourceMeasurement.Measurement || this.settings.SourceOrMeasurement == SourceMeasurement.SourceMeasurement )
          wrt = string.Format( "SENS:FUNC '{0}:{1}'", type.ToString( ).ToUpper( ).Substring( 0, 4 ), acdcType.ToString( ).ToUpper( ) );
        else
          wrt = string.Format( "INCORRECT CONFIGURATION FOR {0}. Must be configured as measurement if inside SetMeasureFunction( ).", this.Name );
        this.gpib.Write( wrt );
        this.measurementVI = ( VIType )type;
        this.measurementACDC = ( ACDCType )acdcType;
      }
      catch( Exception ex ) {
        throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString() );
      }
    }

    /// <summary>
    /// Sets measurement function to V/I AC/DC values set before
    /// </summary>
    private void setMeasureFunction( ) {
      this.setMeasureFunction( this.measurementVI, this.measurementACDC );
    }

    /// <summary>
    /// Measures the currently selected measure function
    /// </summary>
    /// <returns>Double measured by the 24xx averaged according to previously set averaging</returns>
    public virtual double Measure( ) {
      if( this.OutputEnabled ) {
        List<Double> data = new List<double>( );
        setMeasureFunction( );
        for( int l = 0; l < this.Average; l++ ) {
          data.Add( this.measureByType( this.measurementVI ) );
        }
        return ( double )data.Average( );
      }
      else
        return double.NaN;
    }

    /// <summary>
    /// Measures the currently selected measure function
    /// </summary>
    /// <param name="value">ByRef value to return measurement (if you're into that sort of thing)
    /// Averaged if ageraving was set</param>
    public virtual void Measure( ref double value ) {
      value = this.Measure( );
    }

    /// <summary>
    /// Private method to return measurement based on input argument
    /// </summary>
    /// <param name="type">VIType argument selects voltage or current</param>
    /// <returns>Double level of voltage or current</returns>
    private double measureByType( VIType type ) {
      //return type == VIType.Voltage ? this.measureVoltage( ) : this.measureCurrent( );
      return this.measureInvariant( );
    }
    /// <summary>
    /// Measures according to voltage / current setting
    /// +1.000206E+00, +1.000000E-04, +1.000236E+04, +7.282600E+01, +4.813200E+04
    /// Voltage, Current, Resistance, Time, Status
    /// </summary>
    /// <returns></returns>
    private double measureInvariant( ) {
      Console.WriteLine( "Start measure invariant: {0}.{1}", DateTime.Now.Second, DateTime.Now.Millisecond );
      string rtn = string.Empty;
      string wrt = string.Empty;
      try {
        wrt = "*CLS";
        this.gpib.Write( wrt );
        wrt = ":READ?";
        rtn = this.gpib.Query( wrt );
        string[ ] arr = rtn.Split( ",".ToCharArray( ) );
        return
          arr.GetLength( 0 ) > 0
          ?
          this.measurementVI == VIType.Voltage
            ?
            Convert.ToDouble( arr[ 0 ] ) //voltage
            :
            Convert.ToDouble( arr[ 1 ] ) //current
          :
          double.NaN;
      }
      catch( Exception ex ) {
        Console.WriteLine( "Exception in measure invariant: {0}.{1}", DateTime.Now.Second, DateTime.Now.Millisecond );
        throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) + rtn );
      }
      finally {
        Console.WriteLine( "Finish measure invariant: {0}.{1}", DateTime.Now.Second, DateTime.Now.Millisecond );
      }
    }

    /// <summary>
    /// Private method to measure voltage
    /// </summary>
    /// <returns>Double level of voltage</returns>
    public double measureVoltage( ) {
      string rtn = string.Empty;
      string wrt = string.Empty;
      try {
        wrt = ":DATA?";
        rtn = this.gpib.Query( wrt );
        string[ ] arr = rtn.Split( ",".ToCharArray( ) );
        return arr.GetLength( 0 ) > 0 ? Convert.ToDouble( arr[ 0 ] ) : double.NaN;
        //return Convert.ToDouble( rtn );
      }
      catch( Exception ex ) {
          throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) + rtn );
      }
    }

    /// <summary>
    /// Private method to measure current
    /// Was used in VB6 class to measure current
    /// </summary>
    /// <returns>Double level of current</returns>
    public double measureCurrent( ) {
      string rtn = string.Empty;
      string wrt = string.Empty;
      try {
          //wrt = "*CLS";
          //this.gpib.Write( wrt );
          //wrt = ":ABOR";
          //this.gpib.Write( wrt );
          //wrt = ":ARM:COUNT?";
          //if( Convert.ToDouble( this.gpib.Query( wrt ).Trim( ).Substring( 0, 1 ) ) == 1.0 ) {
          //  wrt = ":ARM:COUNT INF";
          //  this.gpib.Write( wrt );
          //  Thread.Sleep( 10 );
          //  wrt = ":INIT";
          //  this.gpib.Write( wrt );
          //  Thread.Sleep( 10 );
          //}
          //wrt = ":ABOR";
          //this.gpib.Write( wrt );
          //wrt = ":DATA?";
          wrt = "*CLS";
          this.gpib.Write( wrt );
          wrt = ":READ?";

          rtn = this.gpib.Query( wrt );
          string[ ] arr = rtn.Split( ",".ToCharArray( ) );
          return arr.GetLength( 0 ) > 0 ? Convert.ToDouble( arr[ 1 ] ) : double.NaN;
      }
      catch( Exception ex ) {
          throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) + rtn );
      }
    }

    #endregion

    #region IVISourceInstrument

    private VIType sourceVI;
    private ACDCType sourceACDC = ACDCType.DC;
    private Compliances compliance = new Compliances();

    public VIType SourceVI {
      get {
        return this.sourceVI;
      }
      set {
          setSourceFunction( value );
        //( ( IVISourceInstrument )this ).SourceConfigure( new VIConfig( value, this.SourceACDC ) );
        this.sourceVI = value;
      }
    }

    public ACDCType SourceACDC {
      get {
        return this.sourceACDC;
      }
      set {
        if( value == ACDCType.AC )
          throw new Exception( "AC source mode not available in this configuration." );
        else {
          ( ( IVISourceInstrument )this ).SourceConfigure( new VIConfig( this.SourceVI, value ) );
          this.sourceACDC = value;
        }
      }
    }

    /// <summary>
    /// gets / sets output enabled
    /// reads from the instrument to see if it is on
    /// writes to it to turn it on or off
    /// </summary>
    public virtual bool OutputEnabled {
      get {
        string wrt = string.Empty;
        string rtn = string.Empty;
        try {
          wrt = "*CLS";
          this.gpib.Device.Write( wrt );
          wrt = ":OUTP:STAT?";
          this.gpib.Device.Write( wrt );
          rtn = this.gpib.Device.ReadString( ).Trim( );
          return rtn == 1.ToString( ) ? true : false;
        }
        catch( Exception ex ) {
          throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString() );
        }
      }
      set {
        string wrt = string.Empty;
        try {
          if( this.OutputEnabled != value ) {
            wrt = ":OUTP:STAT " + ( value ? "ON" : "OFF" );
            this.gpib.Device.Write( wrt );
            this.Init( );
          }
        }
        catch( Exception ex ) {
            throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) );
        }
      }
    }

    /// <summary>
    /// Sets the source function, only applying voltage or current selection
    /// As of now, AC/DC is not supported
    /// </summary>
    /// <param name="cfg">Holds V/I selection</param>
   public void SourceConfigure( VIConfig cfg ) {
      this.setSourceFunction( cfg.Type );
      //this.AutoRange = true;
      this.SetCompliance( ((Compliances)( cfg.Type == VIType.Voltage ? this.settings.CurrentCompliances : this.settings.VoltageCompliances )).Operational );
    }


    public bool AutoRange {
      get {
        string wrt = string.Empty;
        try {
          // [:SENSe[1]]:CURRent[:DC]:RANGe:AUTO?
          wrt = string.Format( "SENS:{0}:{1}:RANGe:AUTO?", this.SourceVI.Opposite( ).ToString( ), this.SourceACDC.ToString( ));
          this.gpib.Device.Write( wrt );
          return this.gpib.Device.ReadString( ).Trim() == "1" ? true : false;
        }
        catch( Exception ex ) {
            throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) );
        }
      }
      set {
        string wrt = string.Empty;
        try {
          // [:SENSe[1]]:CURRent[:DC]:RANGe:AUTO <b>
          wrt = string.Format( "SENS:{0}:{1}:RANGe:AUTO {2}", this.SourceVI.Opposite( ).ToString( ), this.SourceACDC.ToString( ), value ? 1 : 0 );
          this.gpib.Device.Write( wrt );
        }
        catch( Exception ex ) {
            throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) );
        }
      }
    }

    /// <summary>
    /// Sets the source function, only applying voltage or current selection
    /// As of now, AC/DC is not supported
    /// private method
    /// </summary>
    /// <param name="cfg">Holds V/I selection</param>
    private void configureSource( VIConfig cfg ) {
      this.setSourceFunction( cfg.Type );
    }

    /// <summary>
    /// Set the output level of the source according to voltage / current selection before
    /// Effectively = setOutputLevel(double value) but publicly exposed for interface
    /// </summary>
    /// <param name="value">The voltage or current level in absolute units (V or A)</param>
    public virtual void Set( float value ) {
      this.setOutputLevel( value );
    }

    /// <summary>
    /// Keithley 2400 set compliance. Takes V and A (not mA)
    /// </summary>
    /// <param name="value">
    /// MINimum -1.05A, -210V
    /// MAXimum 1.05A, 210V
    /// </param>
    public virtual void SetCompliance( double value ) {
      try {
        //if( ( this.SourceVI == VIType.Current && ( value < -1.05 || value > 1.05 ) )
        //  || ( this.SourceVI == VIType.Voltage && ( value < -210 || value > 210 ) ) )
        //  throw new Exception( string.Format( "Compliance {0} outside of allowed range ({1}).", this.SourceVI.ToString( ), value.ToString( ) ) );
        //value *= this.sourceVI == VIType.Voltage ? 1e3 : 1; // need to multiply the compliance by 1000 if voltage source (current is sent to Keithley in mA)
        if( value == 0 )
          return;
        this.setCompliance( value.ToString( ) );
      }
      catch( Exception ex ) {
        throw ex;
      }
    }

    /// <summary>
    /// Keithley 2400
    /// </summary>
    /// <param name="value">
    /// DEFault 105uA, 21V
    /// MINimum -1.05A, -210V
    /// MAXimum 1.05A, 210V
    /// </param>
    public virtual void SetCompliance( Compliance value ) {
      this.SetCompliance( ( double )this.Compliances.GetHash(value) );
    }

    /// <summary>
    /// Protected method to set compliance (used for all Ke24xx)
    /// </summary>
    /// <param name="value">Double level or string literal DEF, MIN, or MAX</param>
    protected void setCompliance( string value ) {
      string wrt = string.Empty;
      try {
        wrt = string.Format( "SENS:{0}:{1}:PROT:LEV {2}", (this.settings.SourceOrMeasurement == SourceMeasurement.Measurement ?this.settings.VoltageOrCurrent :  this.settings.VoltageOrCurrent.Opposite( )).ToString( ), this.settings.ACOrDC.ToString( ), value );
        this.gpib.Device.Write( wrt );
      }
      catch( Exception ex ) {
        throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) + wrt );
      }
    }

    public Compliances Compliances {
      get {
        return this.compliance;
      }
      set {
        this.compliance = value;
      }
    }

    /// <summary>
    /// Sets the function of the source to voltage or current
    /// </summary>
    /// <param name="type">Voltage or current selection</param>
    protected virtual void setSourceFunction( VIType type ) {
      string wrt = string.Empty;
      try {
        wrt = String.Format( "SOUR:FUNC:MODE {0}", type.ToString( ).ToUpper( ).Substring( 0, 4 ) );
        this.gpib.Write( wrt );
      }
      catch( Exception ex ) {
        throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress + wrt );
      }
    }

    /// <summary>
    /// Sets the output level of the source according to voltage / current selection
    /// </summary>
    /// <param name="level">The voltage or current level in absolute units (V or A)</param>
    /// <param name="type">Voltage or current selection</param>
    private void setOutputLevel( float level, VIType type ) {
      string wrt = string.Empty;
      try {
        wrt = "*CLS";
        this.gpib.Device.Write( wrt );
        wrt = ":ABOR";
        this.gpib.Device.Write( wrt );
        wrt = string.Format( ":SOUR:{0}:LEV:IMM:AMPL {1}", type.ToString( ).Substring( 0, 4 ), level.ToString( ) );
        //wrt = string.Format( ":SOUR:{0}:LEV {1}", type.ToString( ).Substring( 0, 4 ), level.ToString( ) );
          this.gpib.Device.Write( wrt );
        this.Init( );
      }
      catch( Exception ex ) {
        throw new Exception( ex.Message + this.gpib.Device.PrimaryAddress.ToString( ) + wrt );
      }
    }

    /// <summary>
    /// Sets the output level of the source according to voltage / current selected before
    /// </summary>
    /// <param name="level">The voltage or current level in absolute units (V or A)</param>
    private void setOutputLevel( float level ) {
      this.setOutputLevel( level, this.sourceVI );
    }

    private void Init( ) {
      string wrt = string.Empty;
      if( this.OutputEnabled ) {
        wrt = ":INIT";
        this.gpib.Device.Write( wrt );
      }
    }

    private double maximum;
    public double Maximum {
      get { return this.maximum; }
      private set { this.maximum = value; }
    }

    private double minimum;
    public double Minimum {
      get { return this.minimum; }
      private set { this.minimum = value; }
    }

    #endregion

    #region IDisposable

    public void Dispose( ) {
      if( !this.isDisposed ) {
        if( gpib != null ) {
          gpib.Dispose( );
        }
        isDisposed = true;
      }
    }

    #endregion

    public byte GpibAddress {
      get {
        return this.settings.GpibAddress;
      }
      private set {
        this.settings.GpibAddress = value;
      }
    }

  }

  class Ke2410 : Ke2400 {

    /// <summary>
    /// Keithley 2410
    /// </summary>
    public new string Name {
      get { return "Keithley 2410"; }
    }

    /// <summary>
    /// Keithley 2410
    /// </summary>
    /// <param name="value">
    /// MINimum -1.05A, -1100V
    /// MAXimum 1.05A, 1100V
    /// </param>
    public override void SetCompliance( double value ) {
      try {
        //if( ( this.SourceVI == VIType.Current && ( value < -1.05 || value > 1.05 ) )
        //  || ( this.SourceVI == VIType.Voltage && ( value < -1100 || value > 1100 ) ) )
        //  throw new Exception( string.Format( "Compliance {0} outside of allowed range ({1}).", this.SourceVI.ToString( ), value.ToString( ) ) );
        base.setCompliance( value.ToString( ) );
      }
      catch( Exception ex ) {
        throw ex;
      }
    }

  }

  class Ke2420 : Ke2400 {

    /// <summary>
    /// Keithley 2420
    /// </summary>
    public new string Name {
      get { return "Keithley 2420"; }
    }

    /// <summary>
    /// Keithley 2420
    /// </summary>
    /// <param name="value">
    /// MINimum -3.15A, -63V
    /// MAXimum 3.15A, 63V
    /// </param>
    public override void SetCompliance( double value ) {
      try {
        //if( ( this.SourceVI == VIType.Current && ( value < -3.15 || value > 3.15 ) )
        //  || ( this.SourceVI == VIType.Voltage && ( value < -63 || value > 63 ) ) )
        //  throw new Exception( string.Format( "Compliance {0} outside of allowed range ({1}).", this.SourceVI.ToString( ), value.ToString( ) ) );
        base.setCompliance( value.ToString( ) );
      }
      catch( Exception ex ) {
        throw ex;
      }
    }

  }

  [Serializable]
  public class Ke2400Settings {
    public byte Average;
    public Double Minimum;
    public Double Maximum;
    public Compliances CurrentCompliances = new Compliances( );
    public Compliances VoltageCompliances = new Compliances( );
    public byte GpibAddress;
    public TimeoutValue GpibTimeout;
    public  ACDCType ACOrDC;
    public VIType VoltageOrCurrent;
    public SourceMeasurement SourceOrMeasurement;
    private static Ke2400Settings defaultSettings;
    

    public static Ke2400Settings DefaultSettings {
      get { return ( Ke2400Settings )defaultSettings.MemberwiseClone( ); }
    }

    static Ke2400Settings( ) {
      defaultSettings = new Ke2400Settings( );
      defaultSettings.GpibAddress = 1;
      defaultSettings.GpibTimeout = TimeoutValue.T3s;
      defaultSettings.VoltageOrCurrent = VIType.Current;
      defaultSettings.ACOrDC = ACDCType.DC;
      defaultSettings.Average = 1;
      defaultSettings.SourceOrMeasurement = SourceMeasurement.SourceMeasurement;
      defaultSettings.Maximum = 0.001;
      defaultSettings.Minimum = 0;
      defaultSettings.CurrentCompliances = new Compliances( 0, 0.4, 0.035 );
      defaultSettings.VoltageCompliances = new Compliances( -10, 10, 2.5 );
    
    }

  }

  public class FakeKe2400 : Ke2400 {
    private bool outputEnabled;
    public override void ApplySettings( ) { }
    protected override void InternalConnect( ) { }
    protected override void InternalDisconnect( ) { }
    protected override void InternalReset( ) { }
    public override double Measure( ) { return double.NaN; }
    public override void Measure( ref double value ) { value = double.NaN; }
    public override void Set( float value ) { }
    public override void SetCompliance( Compliance value ) { }
    public override void SetCompliance( double value ) { }
    public override bool OutputEnabled {
      get {
        return this.outputEnabled;
      }
      set {
        this.outputEnabled = value;
      }
    }
    public new string Name {
      get { return string.Format( "Fake {0}", base.Name ); }
      set { }
    }
    public override void setMeasureFunction( VIType type, ACDCType acdcType ) { }
    protected override void setSourceFunction( VIType type ) { }
  }

}