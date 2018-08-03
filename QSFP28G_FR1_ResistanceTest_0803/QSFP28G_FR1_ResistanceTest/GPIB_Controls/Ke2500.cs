using System;

namespace Finisar {

  public class Ke2500Settings {
    public Ke2500.RangeValues Resolution = Ke2500.RangeValues.R20yA;
  }


  public partial class Ke2500 {
    string r;
    string[ ] r2;
    private GpibDriver gpib_ = null;
    public enum RangeValues {
      R2nA,
      R20nA,
      R200nA,
      R2yA,
      R20yA,
      R200yA,
      R2mA,
      R20mA
    };
    Ke2500Settings DefaultSettings_ = new Ke2500Settings( );

    private Ke2500( ) {
    }

    public Ke2500( byte address )
      : this( address, NationalInstruments.NI4882.TimeoutValue.T30s ) {
    }

    public Ke2500( byte address, NationalInstruments.NI4882.TimeoutValue timeout ) {
      gpib_ = new GpibDriver( address, timeout );

      DefaultSettings_ = new Ke2500Settings( );

      this.Reset( );
    }

    public void Reset( ) {
      gpib_.Write( RESET );
      gpib_.Write( CLEAR_ALL );
      gpib_.Write( SET_DISPLAY_RES_MAX );

      Channel1Range = DefaultSettings_.Resolution;
      Channel2Range = DefaultSettings_.Resolution;
    }

    public RangeValues Channel1Range {
      get {
        gpib_.Write( GET_C1_RANGE );
        String res = gpib_.Read( );
        res = res.Trim( );

        switch( res ) {
          case "2.000000E-09":
            return Ke2500.RangeValues.R2nA;
          case "2.000000E-08":
            return Ke2500.RangeValues.R20nA;
          case "2.000000E-07":
            return Ke2500.RangeValues.R200nA;
          case "2.000000E-06":
            return Ke2500.RangeValues.R2yA;
          case "2.000000E-05":
            return Ke2500.RangeValues.R20yA;
          case "2.000000E-04":
            return Ke2500.RangeValues.R200yA;
          case "2.000000E-03":
            return Ke2500.RangeValues.R2mA;
          case "2.000000E-02":
            return Ke2500.RangeValues.R20mA;
        }
        throw new ArgumentException( "Invalid argument passed to Ke2500.Channel1Range: " + res );
      }
      set {
        switch( value ) {
          case RangeValues.R2nA:
            gpib_.Write( C1_RANGE_2NA );
            break;
          case RangeValues.R20nA:
            gpib_.Write( C1_RANGE_20NA );
            break;
          case RangeValues.R200nA:
            gpib_.Write( C1_RANGE_200NA );
            break;
          case RangeValues.R2yA:
            gpib_.Write( C1_RANGE_2yA );
            break;
          case RangeValues.R20yA:
            gpib_.Write( C1_RANGE_20yA );
            break;
          case RangeValues.R200yA:
            gpib_.Write( C1_RANGE_200yA );
            break;
          case RangeValues.R2mA:
            gpib_.Write( C1_RANGE_2MA );
            break;
          case RangeValues.R20mA:
            gpib_.Write( C1_RANGE_20MA );
            break;
        }
      }
    }

    public RangeValues Channel2Range {
      get {
        gpib_.Write( GET_C2_RANGE );
        String res = gpib_.Read( );
        res = res.Trim( );
        switch( res ) {
          case "2.000000E-09":
            return Ke2500.RangeValues.R2nA;
          case "2.000000E-08":
            return Ke2500.RangeValues.R20nA;
          case "2.000000E-07":
            return Ke2500.RangeValues.R200nA;
          case "2.000000E-06":
            return Ke2500.RangeValues.R2yA;
          case "2.000000E-05":
            return Ke2500.RangeValues.R20yA;
          case "2.000000E-04":
            return Ke2500.RangeValues.R200yA;
          case "2.000000E-03":
            return Ke2500.RangeValues.R2mA;
          case "2.000000E-02":
            return Ke2500.RangeValues.R20mA;
        }
        throw new ArgumentException( "Invalid argument passed to Ke2500.Channel2Range: " + res );
      }
      set {
        switch( value ) {
          case RangeValues.R2nA:
            gpib_.Write( C2_RANGE_2NA );
            break;
          case RangeValues.R20nA:
            gpib_.Write( C2_RANGE_20NA );
            break;
          case RangeValues.R200nA:
            gpib_.Write( C2_RANGE_200NA );
            break;
          case RangeValues.R2yA:
            gpib_.Write( C2_RANGE_2yA );
            break;
          case RangeValues.R20yA:
            gpib_.Write( C2_RANGE_20yA );
            break;
          case RangeValues.R200yA:
            gpib_.Write( C2_RANGE_200yA );
            break;
          case RangeValues.R2mA:
            gpib_.Write( C2_RANGE_2MA );
            break;
          case RangeValues.R20mA:
            gpib_.Write( C2_RANGE_20MA );
            break;
        }
      }
    }

    public float GetPower( ) {
      return GetPower( 1 );
    }

    public float MeasurePower( ) {
      return MeasurePower( 1 );
      ;
    }

    public float GetPower( int channel ) {
      float res = -1f;
      char c = ',';

      if( channel == 1 )
        channel = 0;
      else
        channel = 1;

      try {
        lock( this ) {
          gpib_.Write( FETCH_POWER );
          r = gpib_.Read( );
          r2 = r.Split( c );
          res = float.Parse( r2[ channel ] );
        }
      }
      catch( Exception e ) {

        throw e;
      }
      return res;
    }

    public float MeasurePower( int channel ) {
      float res = -1f;
      char c = ',';

      if( channel == 1 )
        channel = 0;
      else
        channel = 1;


      try {
        lock( this ) {
          gpib_.Write( MEASURE_POWER );
          r = gpib_.Read( );
          r2 = r.Split( c );
          res = float.Parse( r2[ channel ] );
        }
      }
      catch( Exception e ) {

        throw e;
      }
      return res;
    }

    public GpibDriver Driver {
      get {
        return gpib_;
      }
      set {
        gpib_ = value;
      }
    }
  }



  public partial class Ke2500 {
    //Common Commands

    private const string REMOTE_ENABLE = "REN"; //Goes into remote when next addressed to listen.
    private const string INTERFACE_CLEAR = "IFC";//Goes into talker and listener idle states.
    private const string LOCAL_LOCKOUT = "LLO";//LOCAL key locked out.
    private const string GO_TO_LOCAL = "GTL";//Cancel remote; restore Model 2500 front panel operation.
    private const string HARD_RESET = "DCL";//Returns all devices to known conditions.
    private const string SOFT_RESET = "SDC";//Returns Model 2500 to known conditions.
    private const string GROUP_EXECUTE_TRIGGER = "GET";   //Initiates a trigger.
    private const string SERIAL_POLL = "SPE";//Serial polls the Model 2500.

    private const string CLEAR_ALL = "*CLS";            //Clears all event registers and the error queue. 
    private const string GET_ESE = "*ESE?";           //Queries the bits in the standard event status enable register. 
    private const string SET_ESE = "*ESE";            //<integer> Sets the bits in the standard event status enable register. 
    private const string GET_ESR = "*ESR?";           //Queries value standard event status register. 
    private const string GET_IDN = "*IDN?";           //Queries instrument model number, serial number and firmware version. 
    private const string GET_OPC = "*OPC?";           //Queries the operation complete bit of the standard-event status register. 
    private const string SET_OPC = "*OPC";            //Sets operation complete bit of the standard event status register. 
    private const string RESTORE_ALL = "*RCL";            //Restores instrument settings. 
    private const string RESET = "*RST";            //Resets instrument to default settings. 
    private const string SAVE_SETTINGS = "*SAV";            //Saves instrument settings. 
    private const string GET_STATUS = "*STB?";           //Queries the value of status byte. 

    private const string FETCH_POWER = "FETCh?";
    private const string MEASURE_POWER = "MEASure:CURRent:DC?";

    private const string GET_C1_RANGE = ":SENSe1:CURRent:RANGe?";
    private const string GET_C2_RANGE = ":SENSe2:CURRent:RANGe?";

    private const string C1_RANGE_2NA = ":SENSe1:CURRent:RANGe 2e-9";
    private const string C1_RANGE_20NA = ":SENSe1:CURRent:RANGe 20e-9";
    private const string C1_RANGE_200NA = ":SENSe1:CURRent:RANGe 200e-9";

    private const string C1_RANGE_2yA = ":SENSe1:CURRent:RANGe 2e-6";
    private const string C1_RANGE_20yA = ":SENSe1:CURRent:RANGe 20e-6";
    private const string C1_RANGE_200yA = ":SENSe1:CURRent:RANGe 200e-6";

    private const string C1_RANGE_2MA = ":SENSe1:CURRent:RANGe 2e-3";
    private const string C1_RANGE_20MA = ":SENSe1:CURRent:RANGe 20e-3";

    private const string C2_RANGE_2NA = ":SENSe2:CURRent:RANGe 2e-9";
    private const string C2_RANGE_20NA = ":SENSe2:CURRent:RANGe 20e-9";
    private const string C2_RANGE_200NA = ":SENSe2:CURRent:RANGe 200e-9";

    private const string C2_RANGE_2yA = ":SENSe2:CURRent:RANGe 2e-6";
    private const string C2_RANGE_20yA = ":SENSe2:CURRent:RANGe 20e-6";
    private const string C2_RANGE_200yA = ":SENSe2:CURRent:RANGe 200e-6";

    private const string C2_RANGE_2MA = ":SENSe2:CURRent:RANGe 2e-3";
    private const string C2_RANGE_20MA = ":SENSe2:CURRent:RANGe 20e-3";

    private const string GET_DISPLAY_RES = ":DISPlay:DIGits?";            // Queries the display resolution. 
    private const string SET_DISPLAY_RES_MAX = ":DISPlay:DIGits MAX";            // Selects the display resolution. The .0001 resolution is not available on the model WA-1150. 
  }
}
