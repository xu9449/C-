using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using NationalInstruments.NI4882;

namespace myProject2_7001
{
    public interface IInstrument : INotifyPropertyChanged {
        bool IsConnected { get; set; }
        bool IsReset { get; set; }
        String Name { get; set; }
        
        Dictionary<String, IInstrument> InternalInstruments { get; set; }

        void Connect( );

        void Disconnect( );

        void Reset( );

        void Connect( bool force );

        void Reset( bool force );

        void ApplySettings( );
    }

    public interface IOSA : IInstrument {
        //void ApplySettings( );
        OSASpectrumTrace AquireTrace( int length );
        //bool DoWaitForOperations { get; set; }
        float CenterFrequency { get; set; }
        float CenterWavelength { get; set; }
        OSADisplayState DisplayState { get; set; }  //change name
        double GetSmsr( );
        double GetPeakFrequency( );
        double GetPeakPower( );
        double GetPeakWavelength( );
        int NrOfTracePoints { get; set; }
        void PerformSingleSweep( );
        float ResolutionBandwidth { get; set; }
        float SpanFrequency { get; set; }
        float SpanWavelength { get; set; }
        float ReferenceLevel { get; set; }
        float Sensitivity { get; set; }
        void SetPeak2Center( bool wait );
        OSASweepMode SweepMode { get; set; }
        float SweepStartFrequency { get; set; }
        float SweepStopFrequency { get; set; }
        //void StartSpectralApplication( );
        //void StopSpectralApplication( );
        double VerticalScale { get; set; }
        float VideoBandwidth { get; set; }


        /*
        Ag86140BBufferState BufferState { get; set; }

        double GetSmsr_( );
        double GetSMSrFast( );
        SpectrumTrace GetTrace( );
        GpibDriver Gpib { get; set; }
        void Initialise( bool wait );

        void PerformAutoAlign( );
        void PerformAutoMeasure( );

        float ReferenceLevel { get; set; }
        void RemoveSweepLimits( );

        void SaveSettings( string xmlFilePath );

    
        void SetPeak2ReferenceLevel( );

        Ag86140SpectralData SpectralParameters { get; }
        float StartFrequency { get; set; }
    
        float StartWavelength { get; set; }
        float StopFrequency { get; set; }

        float StopWavelength { get; set; }
        Ag86140BSweepMode SweepMode { get; set; }

        float SweepTime { get; set; }
        Ag86140BSweepTimeMode SweepTimeMode { get; set; }
        bool UseSMSRCorrection { get; set; }
   
        Ag86140BVideoBandwidthMode VideoBandwidthMode { get; set; }
        System.Xml.Linq.XElement XmlSettings { get; set; }
         * */
    }
    /// <summary>
    /// Helper class needed in the IOSA
    /// </summary>
    public class OSASpectrumTrace {
        public float StartWavelength { get; set; }
        public float StopWavelength { get; set; }
        public List<float> points { get; set; }
    }

    /// <summary>
    /// Interface for optical receiver control in Syntune.HfCranes
    /// </summary>
    public interface IReceiver {
        Double DecisionThreshold {
            get;
            set;
        }
        String ReceiverInfo {
            get;
        }
    }

    [Serializable]
    public enum OSASweepMode {
        SINGLE = 0,
        CONTINUOUS
    }

    [Serializable]
    public enum OSADisplayState {
        ON = 0,
        OFF
    }

    public enum UpdateSpeed {
        SLOW = 0,
        FAST,
        UNDEFINED
    }
    public enum AlignMode {
        OFF,
        COARSE,
        FINE
    }

    public interface IWaveMeter : IInstrument {

        /// <summary>
        /// Method to measure the optical frequency
        /// </summary>
        /// <returns>Measured optical frequency in THz</returns>
        double MeasureFrequency( );

        /// <summary>
        /// Method to measure the optical power
        /// </summary>
        /// <returns>Measured optical power in dBm</returns>
        double MeasurePower( );

        /// <summary>
        /// Sets/gets the update speed (Normal/Fast) of the wavelength meter.
        /// Legacy from Agilent 86120.
        /// </summary>
        UpdateSpeed UpdateSpeed {
            get;
            set;
        }

        /// <summary>
        /// Sets the total measurement time for a measurement in ms. 
        /// MeasureFrequency and MeasurePower methods will adapt their wait time before measuring such
        /// that the total measurement time will be as specified by this property.  
        /// </summary>
        int MeasurementTime {
            set;
            get;
        }
    }
    public static class HelperFunctions {
        /// <summary>
        /// converts any frequency number into nm
        /// </summary>
        /// <param name="value">frequency number to be converted</param>
        /// <returns>wavelength in nanometers</returns>
        public static Double ToWavelength( this Double value ) {
            return value / ( 10 ^ ( Int32 )( Math.Round( Math.Log10( value ), MidpointRounding.AwayFromZero ) - 1 ) ) * 1.0e+3;
        }

        public static Boolean IsBetweenInclusive( this Double value, Double min, Double max ) {
            return value >= min & value <= max;
        }

        public static Boolean IsBetweenExclusive( this Double value, Double min, Double max ) {
            return value > min & value < max;
        }

        public static VIType Opposite( this VIType type ) {
            return type == VIType.Current ? VIType.Voltage : VIType.Current  ; //order changed
        }

        /// <summary>
        /// Solves the least squares approximation of y = a + b * log x.
        /// In this form:
        /// b = (n*sum(y*logx) - sum(y)*sum(logx)) / (n*sum((logx)^2)-(sum(logx))^2)
        /// a = (sum(y) - b*sum(logx)) / n
        /// </summary>
        /// <param name="x">independent variable array</param>
        /// <param name="y">dependent variable array</param>
        /// <param name="logarithmBase">base of the logarithm</param>
        /// <param name="a">ref a coefficient result of the approximation</param>
        /// <param name="b">ref b coefficient result of the approximation</param>
        public static void SolveLogarithmLeastSquares( Double[ ] x, Double[ ] y, Double logarithmBase, ref Double a, ref Double b ) {
            Double sumOfYLogxTimesN = 0, sumOfY = 0, sumOfLogx = 0, sumOfLogxSquaredTimesN = 0, squareOfSumOfLogx = 0;
            for( int i = x.GetLowerBound( 0 ); i <= x.GetUpperBound( 0 ); i++ ) {
                sumOfY += y[ i ];
                sumOfYLogxTimesN += y[ i ] * ( Math.Log( x[ i ] ) / Math.Log( logarithmBase ) );
                sumOfLogx += ( Math.Log( x[ i ] ) / Math.Log( logarithmBase ) );
                sumOfLogxSquaredTimesN += Math.Pow( ( Math.Log( x[ i ] ) / Math.Log( logarithmBase ) ), 2 );
            }
            sumOfYLogxTimesN *= ( x.GetUpperBound( 0 ) + 1 );
            sumOfLogxSquaredTimesN *= ( x.GetUpperBound( 0 ) + 1 );
            squareOfSumOfLogx = Math.Pow( sumOfLogx, 2 );
            b = ( sumOfYLogxTimesN - sumOfY * sumOfLogx ) / ( sumOfLogxSquaredTimesN - squareOfSumOfLogx );
            a = ( sumOfY - b * sumOfLogx ) / ( x.GetUpperBound( 0 ) + 1 );
        }

        /// <summary>
        /// Solves the least squares approximation of y = a * base ^ (b * x)
        /// It is recommended to use natural logarithm base, e
        /// </summary>
        /// <param name="x">independent variable array</param>
        /// <param name="y">dependent variable array</param>
        /// <param name="logarithmBase">base of the logarithm / exponential</param>
        /// <param name="a">ref a coefficient result of the approximation</param>
        /// <param name="b">ref b coefficient result of the approximation</param>
        public static void SolveEponentialLeastSquares( Double[ ] x, Double[ ] y, Double logarithmBase, ref Double a, ref Double b ) {
            Double sumx2y = 0, sumylogy = 0, sumxy = 0, sumxylogy = 0, sumy = 0;
            for( int i = x.GetLowerBound( 0 ); i <= x.GetUpperBound( 0 ); i++ ) {
                sumx2y += Math.Pow( x[ i ], 2 ) * y[ i ];
                sumylogy += y[ i ] * Math.Log( y[ i ], logarithmBase );
                sumxy += x[ i ] * y[ i ];
                sumxylogy += x[ i ] * y[ i ] * Math.Log( y[ i ], logarithmBase );
                sumy += y[ i ];
            }
            a = ( sumx2y * sumylogy - sumxy * sumxylogy ) / ( sumy * sumx2y - Math.Pow( sumxy, 2 ) );
            a = Math.Pow( logarithmBase, a );
            b = ( sumy * sumxylogy - sumxy * sumylogy ) / ( sumy * sumx2y - Math.Pow( sumxy, 2 ) );
        }

    }
    
    public class IVISettings {

        public byte GpibAddress {
            get { return address; }
            set {
                this.address = ( ( ( Double )value ).IsBetweenInclusive( 1, 31 ) ? value : ( Byte )1 );
            }
        }
        private byte address;
        public TimeoutValue GpibTimeout;
        public VIType VoltageOrCurrent;
        public ACDCType ACOrDC;
        public SourceMeasurement SourceOrMeasurement;
    }

    public class VIConfig {
        private VIType _type;
        private ACDCType _acdc;
        private int _average;

        #region default constants
        private const VIType DEFAULT_TYPE = VIType.Voltage;
        private const ACDCType DEFAULT_ACDC = ACDCType.DC;
        private const int DEFAULT_AVERAGE = 1;
        #endregion

        public VIType Type {
            get { return _type; }
            set { _type = value; }
        }
        public ACDCType ACDC {
            get { return _acdc; }
            set { _acdc = value; }
        }
        public int Average {
            get { return _average; }
            set {
                _average = value > 0 ? value : 1;
            }
        }

        public VIConfig( VIType type, ACDCType acdc, int average ) {
            this._type = type;
            this._acdc = acdc;
            this._average = average;
        }

        public VIConfig( VIType type, ACDCType acdc ) {
            this._type = type;
            this._acdc = acdc;
            this._average = DEFAULT_AVERAGE;
        }

        public VIConfig( ) {
            //Default constructor. Use some default values
            this._type = DEFAULT_TYPE;
            this._acdc = DEFAULT_ACDC;
            this._average = DEFAULT_AVERAGE;
        }
    }
    public interface IVIMeasurementInstrument : IInstrument {
        VIType MeasurementVI { get; set; }
        ACDCType MeasurementACDC { get; set; }
        int Average { get; set; }
        void MeasureConfigure( VIConfig cfg );
        Double Measure( );
        void Measure( ref Double value );
    }

    public interface IVISourceInstrument : IInstrument {
        VIType SourceVI { get; set; }
        ACDCType SourceACDC { get; set; }
        void SourceConfigure( VIConfig cfg );
        void Set( Double value );
        void SetCompliance( Double value );
        void SetCompliance( Compliance value );
        bool OutputEnabled { get; set; }
        Compliances Compliances { get; set; }
        Double Maximum { get; }
        Double Minimum { get; }
    }

    public interface IVoltageIsolator : IInstrument {
        Double Delta { get; set; }
        Double LastMeasurement { get; }
        Double LastSetting { get; }
        Double Measure( );
        void Set( Double value );
        void SetMeasurement( );
    }

    public interface ITec : IInstrument {
        double CurrentTemperature { get; }
        double TargetTemperature { get; set; }
        void StabilizeTemperature( );
    }

    namespace TemperatureControl.TEC {

        [Serializable]
        public class PID {

            public double P { get; set; }

            public double I { get; set; }

            public double D { get; set; }

            public PID( double p, double i, double d ) {
                P = p;
                I = i;
                D = d;
            }

            public PID( ) {
            }

        }

        public interface ITECController : IInstrument {

            double Current { get; set; } // ampere 

            double Resistance { get; set; } // ohm

            double Voltage { get; set; } // volt

            double Power { get; set; } // watt

            double Temperature { get; set; } // celcius

            PID PID { get; set; } // celcius, celsius per second and celcius seconds

            void InternalReset( );

        }
    }
}
