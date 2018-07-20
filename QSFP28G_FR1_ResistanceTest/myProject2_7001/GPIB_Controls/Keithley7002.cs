using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Xml;
using NationalInstruments.NI4882;

namespace Finisar
  ///
  /// ported from Keithley7002 of OSA.NET
  /// 
{
  public class Keithley7002Error : Exception {
    public Keithley7002Error( string errorMessage, Exception innerException )
      : base( "Keithley7002Error:" + errorMessage, innerException ) { }
    public Keithley7002Error( string errorMessage )
      : base( "Keithley7002Error:" + errorMessage ) { }
    public Keithley7002Error( )
      : base( "Keithley7002Error:no message..." ) { }
  }
  public class Keithley7002Settings {
    public static Keithley7002Settings defaultSettings_;
    public byte GpibAddress;
    public TimeoutValue GpibTimeout;

    static Keithley7002Settings( ) {
      defaultSettings_ = new Keithley7002Settings( );
      defaultSettings_.GpibAddress = 1;
      defaultSettings_.GpibTimeout = TimeoutValue.T30s;
    }
    public static Keithley7002Settings DefaultSetting {
      get {
        return ( Keithley7002Settings )defaultSettings_.MemberwiseClone( );
      }
    }
  }

  public class Keithley7002 : Instrument, IDisposable {
    private Keithley7002Settings settings_ = Keithley7002Settings.defaultSettings_;
    private GpibDriver gpib_ = null;
    private bool isDisposed_ = false;

    public Keithley7002( ) { }

    public Keithley7002( byte address )
      : this( address, TimeoutValue.T30s ) { }
    public Keithley7002( byte address, TimeoutValue timeout ) {
      settings_.GpibAddress = address;
      settings_.GpibTimeout = timeout;
    }
    public void Dispose( ) {
      try {
        if( !this.isDisposed_ ) {
          if( gpib_ != null ) {
            gpib_.Dispose( );
          }
          isDisposed_ = true;
        }
        this.LogMessage( "Keithley7002 Dispose..." );
      }
      catch( Exception ex ) {
        throw new Keithley7002Error( "Error Keithley7002 Dispose...", ex );
      }

    }
    protected override void InternalConnect( ) {
      try {
        if( gpib_ == null ) {
          gpib_ = new GpibDriver( settings_.GpibAddress, settings_.GpibTimeout );
        }
      }
      catch( Exception ex ) {
        throw new Keithley7002Error( "Error Keithley7002 internalconnet...", ex );
      }
      //this.LogMessage( "Keithley7002 InternalConnet... " );
    }
    protected override void InternalDisconnect( ) {
      try {
        gpib_.Dispose( );
        gpib_ = null;
      }
      catch( Exception ex ) {
        throw new Keithley7002Error( "Error Keithley7002 internaldisconnet...", ex );
      }
      this.LogMessage( "Keithley7002 internalDisconnet..." );
    }
    protected override void InternalReset( ) {
      this.LogMessage( "Keithley7002 InternalReset..." );
      try { gpib_.Reset( ); }
      catch( Exception ex ) { throw new Keithley7002Error( "Error resetting Keithley7002.", ex ); }
    }
    public override void ApplySettings( ) {
      base.ApplySettings( );
    }
    public override XElement XmlSettings {
      get {
        return settings_.XmlWriterSerialize( null, settings_.GetType( ).Name );
      }
      set {
        XmlReader xmlReader = XmlReader.Create( value.CreateReader( ), SerializerExtensions.ReaderSettings );
        settings_ = ( Keithley7002Settings )xmlReader.XmlReaderDeserialize( typeof( Keithley7002Settings ), typeof( Keithley7002Settings ).Name );
      }
    }
    public override string InternalQuery( ) {
      GpibIdentity id;
      try {
        id = gpib_.GetIdentity( );
      }
      catch( Exception ex ) {
        throw new Keithley7002Error( "Error InternalQuery Keithley7002...", ex );
      }
      return "#" + id.manufacturer + "#" + id.model + "#" + id.serialNumber + "#" + id.firmwareVersion;
    }
    public GpibDriver Driver {
      get {
        return gpib_;
      }
      set {
        gpib_ = value;
      }
    }
    public Keithley7002Settings Settings {
      get {
        return settings_;
      }
      set {
        settings_.GpibAddress = value.GpibAddress;
        settings_.GpibTimeout = value.GpibTimeout;
      }

    }

    public void Init( ) {
      try {

      }
      catch( Exception ex ) {
        throw new Keithley7002Error( "Error Keithley7002", ex );
      }
    }

    public bool CloseChannel( int Port1, int Port2 ) {
      try {
        gpib_.Write( "Close (@" + Port1.ToString( ) + "!" + Port2.ToString( ) + ")" );
        Thread.Sleep( 20 );
        return true;
      }
      catch( Exception ex ) {
        throw new Keithley7002Error( "Error OutPutOn Keithley7002", ex );
      }
    }
    public bool OpenChannel( int Port1, int Port2 ) {
      try {
        gpib_.Write( "Open (@" + Port1.ToString( ) + "!" + Port2.ToString( ) + ")" );
        Thread.Sleep( 20 );
        return true;
      }
      catch( Exception ex ) {
        throw new Keithley7002Error( "Error OutPutOn Keithley7002", ex );
      }
    }
    public bool OpenAll( ) {
      try {
        gpib_.Write( "Open All" );
        Thread.Sleep( 20 );
        return true;
      }
      catch( Exception ex ) {
        throw new Keithley7002Error( "Error OutPutOn Keithley7002", ex );
      }
    }

    public byte GpibAddress {
      get {
        return this.Settings.GpibAddress;
      }
      private set {
        this.Settings.GpibAddress = value;
      }
    }

    /*
    public void InternalConnect( ) {
       throw new NotImplementedException( );
    } 
    */
  }

}

