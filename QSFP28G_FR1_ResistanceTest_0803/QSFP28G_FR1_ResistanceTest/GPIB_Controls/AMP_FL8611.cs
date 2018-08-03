using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.NI4882;
using System.Globalization;
using System.Threading;

namespace Finisar {
    class AMP_FL8611  {
        protected GpibDriver gpib = null;
        protected bool isDisposed = false;
        protected CultureInfo culture = new CultureInfo( "en-US" );
        protected AgSettings settings;
        private string AMP_Name = "AMP-FL8611-OB";
        private char delimiter = '\n'; //'\r';
        /// <summary>
        /// int: Gpib address
        /// AgE3640AOutputVoltage: Output select
        /// VIType: Voltage or Current
        /// Double: Corresponding compliance value
        /// </summary>

        public AMP_FL8611( ) { settings = AgSettings.DefaultSettings; }

        public AMP_FL8611( byte address ) : this( address, TimeoutValue.T30s ) { }

        public AMP_FL8611( byte address, TimeoutValue timeout )
            : this( ) {
            settings = AgSettings.DefaultSettings;
            settings.GpibAddress = address;
            settings.GpibTimeout = timeout;
            this.gpib = new GpibDriver( this.settings.GpibAddress );
            gpib.GetIdentity( );
        }
        /// <summary>
        /// Gets/sets whether the output is enabled or disabled
        /// <para/>
        /// <b>GPIB COMMANDS</b>
        /// <para/>
        /// <b>============</b>
        /// <para/>
        /// <b>Set: </b> 
        /// <i>":ACTIVE, 1", "1 is ON; 0 is OFF"</i>
        /// <para/>
        /// </summary> 
        public virtual bool OutputEnabled {
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
        /// Method used to enable all three outputs
        /// </summary>
        protected virtual void EnableOutput( ) {
            try {
                gpib.Query( "ACTIVE,1" + delimiter );
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
                gpib.Query( "ACTIVE,0" + delimiter );
            }
            catch( Exception ex ) {
                throw new Exception( "Error disabling output.", ex );
            }
        }

        public void SetMod( bool isACC, int chNumber ) {
            try {
                string strValue = "";
                string mode = isACC == true ? "1" : "0";
               strValue =  gpib.Query( "SETMODE," + chNumber.ToString( ) + delimiter );
                DelayHere( );
                
               strValue =  gpib.Query( "SETMODE," + chNumber.ToString( ) + "," + mode + delimiter );
                
            }
            catch( Exception ex ) {
                throw new Exception( "Error at SetMod().", ex );
            }
        }

        public float GetACC( int chNumber ) {
            string strValue = "";
            strValue = gpib.Query( "SETACC," + chNumber.ToString( ) + delimiter );
            return GetValue( strValue );
        }
        public void SetACC( int chNumber, int value_mA ) {
            try {
                string strValue = "";
               strValue = gpib.Query( "SETACC," + chNumber.ToString( ) + delimiter );
                DelayHere( );
                //strValue = gpib.Read( );
               strValue = gpib.Query( "SETACC," + chNumber.ToString( ) + "," + value_mA.ToString( ) + delimiter );
               strValue = GetValue( strValue ).ToString();
                //DelayHere( );
                // gpib.Read( );
            }
            catch( Exception ex ) {
                throw new Exception( "Error at SetACC().", ex );
            }
        }

        public float GetALC( int chNumber ) {
            string strValue = "";
            strValue = gpib.Query( "SETALC," + chNumber.ToString( ) + delimiter );
            return GetValue( strValue );
        }
        
        public void SetALC( int chNumber, int value_dB ) {
            try {
                string strValue = "";
                strValue  = gpib.Query( "SETALC," + chNumber.ToString( ) + delimiter );
                DelayHere( );
                
               strValue = gpib.Query( "SETALC," + chNumber.ToString( ) + "," + value_dB.ToString( ) + delimiter );
                
            }
            catch( Exception ex ) {
                throw new Exception( "Error at SetALC().", ex );
            }
        }

        public void SaveRef( ) {
            try {
                string strValue = "";
                strValue = gpib.Query( "SAVEREF" + delimiter );
                DelayHere( );
                
            }
            catch( Exception ex ) {
                throw new Exception( "Error at SetALC().", ex );
            }
        }

        public float GetOpticalOutputPower( ) {
            try {
                float retValue = 0.0f;
                string strValue = "";
                strValue = gpib.Query( "MONOUT" + delimiter );
                retValue = float.Parse( strValue.Substring( 0, strValue.IndexOf( "," ) - 1 ) );
                return retValue;
            }
            catch( Exception ex ) {
                throw new Exception( "Error at GetOpticalOutputPower().", ex );
            }
        }

        public float GetOpticalInputPower( ) {
            try {
                float retValue = 0.0f;
                string strValue = gpib.Query( "MONIN" + delimiter );
                retValue = GetValue( strValue );
                return retValue;
            }
            catch( Exception ex ) {
                throw new Exception( "Error at GetOpticalInputPower().", ex );
            }
        }

        public float GetOpticalPower( ) {
            try {
                float retValue = 0.0f;
                string strValue = gpib.Query( "MONRET" + delimiter );
                retValue = GetValue( strValue );
                return retValue;
            }
            catch( Exception ex ) {
                throw new Exception( "Error at GetOpticalPower().", ex );
            }
        }

        public float GetCaseTemperture( ) {
            try {
                float retValue = 0.0f;
                string strValue = gpib.Query( "MONCTMP" + delimiter );
                retValue = GetValue( strValue );
                return retValue;
            }
            catch( Exception ex ) {
                throw new Exception( "Error at GetTemperture().", ex );
            }
        }
        
        public float GetChannelCurrent( int chNumber ) {
            try {
                float retValue = 0.0f;
                //gpib.Query( "MONLDC," + chNumber.ToString( ) );
                string retString = gpib.Query( "MONLDC," + chNumber.ToString( ) + delimiter );
                retValue = float.Parse( retString );
                //retValue = float.Parse( gpib.Read( ) );
                return retValue;
            }
            catch( Exception ex ) {
                throw new Exception( "Error at GetTemperture().", ex );
            }
        }

        public float GetChannelTemperature( int chNumber ) {
            try {
                float retValue = 0.0f;
                gpib.Write( "MONLDT," + chNumber.ToString( ) + delimiter );
                retValue = float.Parse( gpib.Read( ) );
                return retValue;
            }
            catch( Exception ex ) {
                throw new Exception( "Error at GetTemperture().", ex );
            }
        }

        public float GetChannelTEC( int chNumber ) {
            try {
                float retValue = 0.0f;
                gpib.Write( "MONTEC," + chNumber.ToString( ) + delimiter );
                retValue = float.Parse( gpib.Read( ) );
                return retValue;
            }
            catch( Exception ex ) {
                throw new Exception( "Error at GetTemperture().", ex );
            }
        }

        private float GetValue( string replyStr ) {
            try {
                float retValue = 0f;

                String[ ] value = replyStr.Split( ',' );
                retValue = float.Parse( value[ 2 ] );

                return retValue;
            }
            catch( Exception ex ) {
                
                throw new Exception( "Error at GetValue().", ex );
            }
        }
        private void DelayHere( ) {
            Thread.Sleep( 2000 );
        }

        public virtual string Name {
            get { return AMP_Name; }
            set { AMP_Name = value; }
        }

        public byte GpibAddress {
            get {
                return this.settings.GpibAddress;
            }
            set {
                this.settings.GpibAddress = value;
            }
        }
    }
    /// <summary>
    /// Class containing the settings for the Agilent E3631A Triple Output DC Power Supply
    /// </summary>
    [Serializable]
    public class AMPSettings {
        protected static AMPSettings defaultSettings_;

        public byte GpibAddress;
        public TimeoutValue GpibTimeout;

        static AMPSettings( ) {
            defaultSettings_ = new AMPSettings( );
            defaultSettings_.GpibAddress = 6;
            defaultSettings_.GpibTimeout = TimeoutValue.T30s;
            
        }
        public static AgSettings DefaultSettings {
            get {
                return ( AgSettings )defaultSettings_.MemberwiseClone( );
            }
        }
    }
}
