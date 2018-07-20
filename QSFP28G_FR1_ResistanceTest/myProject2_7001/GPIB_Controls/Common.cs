using System;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace Finisar {
  public class InstrumentError : ApplicationException {
    public InstrumentError( string msg ) :
      base( "Instrument error: " + msg ) {
    }
  }
  public class Constants {
    public const float SPEED_OF_LIGHT = 299792458.0f;
    public const float PI = 3.1415926535897932384626433832795f;
  }
  public class MessageLog {
      private StreamWriter txtWriter;
      private const string logFilePath = @"C:\DeviceData";
      public void Log( string msg ) {
          if( txtWriter == null )
              InitWriter( );
          txtWriter.WriteLine( msg );
          txtWriter.Flush( );
      }
      private void InitWriter( ) {
          if( !System.IO.Directory.Exists( logFilePath ) ) {
              System.IO.Directory.CreateDirectory( logFilePath );
          }
          txtWriter = new StreamWriter( logFilePath + @"\LogFile_" + DateTime.Now.ToString( "yyyy-MM-dd_HH_mm" ) + "txt" );

      }
      public void CloseMessageLog( ) {
          txtWriter.Close( );
      }
  }
}
