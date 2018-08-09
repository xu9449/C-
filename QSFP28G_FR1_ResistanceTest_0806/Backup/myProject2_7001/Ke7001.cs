using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using NationalInstruments.NI4882;
using System.Threading;
//using myProject2_7001.Core;
//using myProject2_7001.Interface;o
//using myProject2_7001.Utils;

namespace myProject2_7001
{

  public class Ke7001Error : Exception {

    public Ke7001Error( string errorMessage, Exception innerException, params Object[ ] args )
      : base( String.Format( "Ke7001 Error: " + errorMessage, args ), innerException ) {
    }

    public Ke7001Error( string errorMessage )
      : this( "Ke7001 Error:" + errorMessage, null ) {
    }

    public Ke7001Error( )
      : this( "Keithley7001Error:no message", null ) {
    }
  }

  [Serializable]
  public class Ke7001Settings {
    public byte GpibAddress;
    public TimeoutValue GpibTimeout;
    public int Ke2400_Channel = 1;
    public int Pc_Channel = 1;
    public int Gain_Channel = 1;
    public int Soa_Channel = 1;
    public int Pmz_Channel = 1;
    public int MZr_Channel = 1;
    public int MZl_Channel = 1;
    public int Rr_Channel = 1;
    public int Rl_Channel = 1;
    public int Rth_Channel = 1;
    public double Pc_offset = 0.0;
    public double Gain_offset = 0.0;
    public double Soa_offset = 0.0;
    public double Pmz_offset = 0.0;
    public double MZr_offset = 0.0;
    public double MZl_offset = 0.0;
    public double Rr_offset = 0.0;
    public double Rl_offset = 0.0;
    public double Rth_offset = 0.0;

    static Ke7001Settings( ) { }
  }

  public class Ke7001 : Instrument, IDisposable {
    private Ke7001Settings settings_ = new Ke7001Settings( );
    private GpibDriver gpib_ ;
    private bool isDisposed_ = false;

    /// <summary>
    /// Default constructor for the Ke7001 class
    /// </summary>
    public Ke7001( ) {
      
    }

    /// <summary>
    /// Constructor for the Ke7001 class
    /// </summary>
    /// <param name="address">GPIB address</param>
    public Ke7001( byte address )
      : this( address, TimeoutValue.T30s ) {
    }

    /// <summary>
    /// Constructor for the Ke7001 class
    /// </summary>
    /// <param name="address">GPIB address</param>
    /// <param name="timeout">Enum timeout value</param>
    public Ke7001( byte address, TimeoutValue timeout ) {
      gpib_ = new GpibDriver( address, timeout );
    }
   
    public void Dispose( ) {
      this.LogMessage( "Keithley7001 Dispose ... " );
      if( !this.isDisposed_ ) {
        if( gpib_ != null ) {
          gpib_.Dispose( );
        }
        isDisposed_ = true;
      }
    }

    public override string InternalQuery()
    {
        GpibIdentity hah=gpib_.GetIdentity();
        return hah.model;
    }
    protected override void InternalConnect( ) {
      this.LogMessage( "Keithley7001 Internal Connecting ... " );
      try {
        if( gpib_ == null ) {
          gpib_ = new GpibDriver( settings_.GpibAddress, settings_.GpibTimeout );       
        }
      }
      catch( Exception ex ) {
        throw new Ke7001Error( "Error connecting Keithley7001", ex );
      }
    }

    protected override void InternalDisconnect( ) {
      this.LogMessage( "Keithley7001 Internal Disconnecting ... " );
      try {
        gpib_.Dispose( );
        gpib_ = null;
      }      
      catch( Exception ex ) {
        throw new Ke7001Error( "Error disconnecting Keithley7001 Internal", ex );
      }
    }

    protected override void InternalReset( ) {
      this.LogMessage( "Keithley7001 Internal Resetting ... " );
      try { 
        gpib_.Write( "RESET" );
      }
      catch( Exception ex ) {
        throw new Ke7001Error( "Error resetting Keithley7001", ex );
      }
    }

    public override void ApplySettings( ) {
      this.LogMessage( "Keithley7001 ApplySettings..." );
      try {

      }
      catch( Exception ex ) { throw new Ke7001Error( "Error applying KEITHLEY7001.", ex ); }
    }

    //public override XElement XmlSettings {
    //  get {
    //    return settings_.XmlSerializeToXElement( );
    //  }
    //  set {
    //    settings_ = value.XmlDeserialize<Ke7001Settings>( );
    //  }
    //}

    public Ke7001Settings Settings {
      get {
        return settings_;
      }
      set {
        settings_ = value;
      }
    }

    public GpibDriver Driver {
      get {
        return gpib_;
      }
      set {
        gpib_ = value;
      }
    }

    //public int Ke2400Channel {
    //  set {
    //    settings_.Ke2400_Channel = value;
    //  }
    //  get {
    //    return settings_.Ke2400_Channel;
    //  }
    //}
    public int PcChannel {
      set {
        settings_.Pc_Channel = value;
      }
      get {
        return settings_.Pc_Channel;
      }
    }
    public int GainChannel {
      set {
        settings_.Gain_Channel = value;
      }
      get {
        return settings_.Gain_Channel;
      }
    }
    public int SoaChannel {
      set {
        settings_.Soa_Channel = value;
      }
      get {
        return settings_.Soa_Channel;
      }
    }
    public int PmzChannel {
      set {
        settings_.Pmz_Channel = value;
      }
      get {
        return settings_.Pmz_Channel;
      }
    }
    public int MZrChannel {
      set {
        settings_.MZr_Channel = value;
      }
      get {
        return settings_.MZr_Channel;
      }
    }
    public int MZlChannel {
      set {
        settings_.MZl_Channel = value;
      }
      get {
        return settings_.MZl_Channel;
      }
    }
    public int RrChannel {
      set {
        settings_.Rr_Channel = value;
      }
      get {
        return settings_.Rr_Channel;
      }
    }
    public int RlChannel {
      set {
        settings_.Rl_Channel = value;
      }
      get {
        return settings_.Rl_Channel;
      }
    }
    public int RthChannel {
      set {
        settings_.Rth_Channel = value;
      }
      get {
        return settings_.Rth_Channel;
      }
    }
    public double PcOffset {
      set {
        settings_.Pc_offset = value;
      }
      get {
        return settings_.Pc_offset;
      }
    }
    public double GainOffset {
      set {
        settings_.Gain_offset = value;
      }
      get {
        return settings_.Gain_offset;
      }
    }
    public double SoaOffset {
      set {
        settings_.Soa_offset = value;
      }
      get {
        return settings_.Soa_offset;
      }
    }
    public double PmzOffset {
      set {
        settings_.Pmz_offset = value;
      }
      get {
        return settings_.Pmz_offset;
      }
    }
    public double MZrOffset {
      set {
        settings_.MZr_offset = value;
      }
      get {
        return settings_.MZr_offset;
      }
    }
    public double MZlOffset {
      set {
        settings_.MZl_offset = value;
      }
      get {
        return settings_.MZl_offset;
      }
    }
    public double RrOffset {
      set {
        settings_.Rr_offset = value;
      }
      get {
        return settings_.Rr_offset;
      }
    }
    public double RlOffset {
      set {
        settings_.Rl_offset = value;
      }
      get {
        return settings_.Rl_offset;
      }
    }
    public double RthOffset {
      set {
        settings_.Rth_offset = value;
      }
      get {
        return settings_.Rth_offset;
      }
    }

    //public void SetChannel( int nChannel ) {
    public bool CloseChannel(int Port1, int Port2)
    {
        //try {
        //  string command = ":close (@1!" + nChannel.ToString( ) + ")";

        //  gpib_.Write( command );
        //}
        try
        {
            gpib_.Write("Close (@" + Port1.ToString() + "!" + Port2.ToString() + ")");
            Thread.Sleep(20);
            return true;
        }
        catch (Exception ex)
        {
            throw new Ke7001Error("Error SetChannel Keithley7001", ex);
        }
    }

          public bool OpenChannel( int Port1, int Port2 ) {
      try {
        gpib_.Write( ":open (@" + Port1.ToString( ) + "!" + Port2.ToString( ) + ")" );
        Thread.Sleep( 20 );
        return true;
      }
      catch( Exception ex ) {
        throw new Ke7001Error( "Error OutPutOn Keithley7002", ex );
      }
    }
      public void ScanChannel(){
          try{
              string command1 = ":open all";
              string command2 = "*RST";
              string command3 = ":scan (@1!1,1!2,1!4,1!6,1!7,1!10,1!11,1!21,1!2,1!3,1!22,1!10,1!23,1!24)";
              string command4 = ":trig:coun:auto on";
              string command5 = ":trig:del 1";
              string command6 = ":init";
              //string command7 = ":clos (@1!24)";
              //string command7 = "*OPC";
              //string command8 = "*ESR?";
              gpib_.Write(command1);
              gpib_.Write(command2);
              gpib_.Write(command3);
              gpib_.Write(command4);
              gpib_.Write(command5);
              gpib_.Write(command6);
              //gpib_.Write(command7);
              //gpib_.Write(command7);
              //gpib_.Write(command8);



          }
          catch (Exception ex)
          {
              throw new Ke7001Error("Error open all Channels of Keithley7001", ex);
          }
      }

       
    public void OpenAllChan( ) {
      try {
        string command = "Open all";
        gpib_.Write( command );
      }
      catch( Exception ex ) {
        throw new Ke7001Error( "Error open all Channels of Keithley7001", ex );
      }
    }

    public void CloseAllChan( ) {
      try {
        string command = "close all";
        gpib_.Write( command );
      }
      catch( Exception ex ) {
        throw new Ke7001Error( "Error close all Channels of Keithley7001", ex );
      }
    }  
  }
} 
