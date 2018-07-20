using System;
using System.Xml.Linq;
using System.Globalization;
using NationalInstruments.NI4882;
using System.Collections.Generic;

namespace Finisar
{
    public class Ke2000 : Instrument, IDisposable
    {

        protected Ke2000Settings settings = Ke2000Settings.DefaultSettings;

        public Ke2000Settings Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        private VIType type = VIType.Current;
        private int average = 1;
        private ACDCType acdc = ACDCType.DC;
        private GpibDriver gpib = null;

        #region GPIB Commands
        private GpibCommandString _cmdQueryValue = new GpibCommandString("SENSE:DATA?");
        private GpibCommandString _cmdSetMeasureFunction = new GpibCommandString(":FUNCTION");
        private GpibCommandString _cmdSetAverage = new GpibCommandString("SENSE:VOLTAGE:DC:AVERAGE:COUNT");
        private GpibCommandString _cmdSetAverageEnableDisable = new GpibCommandString("SENSE:VOLTAGE:DC:AVERAGE:STATE");
        private String _cmdAverageEnabled = "ON";
        private String _cmdAverageDisabled = "OFF";
        #endregion

        public Ke2000(byte primaryAddress)
        {
            this.settings.GpibAddress = primaryAddress;
            InternalConnect();
        }

        public Ke2000()
        {
            //InternalConnect( );
        }

        public VIType MeasurementVI
        {
            get { return this.type; }
            set
            {
                this.type = value;
                //set the measurement type on the instrument
                this.ApplyMeasurementType();
                //modify the average commands as well
                foreach (String s in Enum.GetNames(typeof(VIType)))
                {
                    this._cmdSetAverage.CommandString.ToUpper().Substring(0).Replace(s.ToString().ToUpper(), this.type.ToString().ToUpper());
                    this._cmdSetAverageEnableDisable.CommandString.ToUpper().Substring(0).Replace(s.ToString().ToUpper(), this.type.ToString().ToUpper());
                }
                foreach (String s in Enum.GetNames(typeof(ACDCType)))
                {
                    this._cmdSetAverage.CommandString.ToUpper().Substring(0).Replace(s.ToString().ToUpper(), this.acdc.ToString().ToUpper());
                    this._cmdSetAverageEnableDisable.CommandString.ToUpper().Substring(0).Replace(s.ToString().ToUpper(), this.acdc.ToString().ToUpper());
                }
                this.ApplyAverage();
            }
        }

        public int Average
        {
            get { return this.average; }
            set
            {
                this.average = (((Double)value).IsBetweenInclusive(1, 100) ? value : 1);
                //set the average on the gpib instrument
                this.ApplyAverage();
            }
        }

        public ACDCType MeasurementACDC
        {
            get { return this.acdc; }
            set
            {
                this.acdc = value;
                this.ApplyACDC();
            }
        }

        protected virtual void ApplyMeasurementType()
        {
            this.gpib.Write(this._cmdSetMeasureFunction.Write("'" + this.type.ToString().ToUpper() + ":" + this.acdc.ToString().ToUpper()) + "'");
        }

        protected virtual void ApplyAverage()
        {
            this.gpib.Write(this._cmdSetAverage.Write(this.average));
            this.gpib.Write(this._cmdSetAverageEnableDisable.Write((this.average != 1 ? this._cmdAverageEnabled : this._cmdAverageDisabled)));
        }

        private void ApplyACDC()
        {
            this.ApplyMeasurementType();
        }

        public void Configure(VIConfig cfg)
        {
            // invoke the properties, which actually calls the gpib commands
            //this.Average = cfg.Average;
            this.MeasurementVI = cfg.Type;
            this.MeasurementACDC = cfg.ACDC;
        }

        public virtual Double Measure()
        {
            // multiply the value by 1000 if it's current (to get mA)
            //return ( this._type == VIType.Current ? 1000 : 1 ) *
            return (Double)(double.Parse(this.gpib.Query(this._cmdQueryValue.Query()).Trim()));
        }

        public void Measure(ref Double value)
        {
            value = this.Measure();
        }

        #region Instrument implementation

        public override void ApplySettings()
        {
            this.Configure(new VIConfig(this.Settings.VoltageOrCurrent, this.Settings.ACOrDC, this.Settings.Average));
        }

        protected override void InternalConnect()
        {
            try
            {
                if (this.gpib == null)
                {
                    this.gpib = new GpibDriver(this.Settings.GpibAddress, this.Settings.GpibTimeout);
                    ApplySettings();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error connecting {0} with address {1}.\n{2}", this.Name, this.settings.GpibAddress.ToString(), ex.Message));
            }
        }

        protected override void InternalDisconnect()
        {
            this.gpib = null;
            //base.InternalDisconnect();
        }

        protected override void InternalReset()
        {
            base.InternalDisconnect();
            this.InternalConnect();
        }

        #endregion

        //public override XElement XmlSettings {
        //  get {
        //    return Settings.XmlSerializeToXElement( );
        //  }
        //  set {
        //    settings = value.XmlDeserialize<Ke2000Settings>( );
        //  }
        //}

        public void Dispose()
        {
            InternalDisconnect();

        }

        public virtual new string Name
        {
            get { return "Keithley 2000"; }
            set { }
        }

        public byte GpibAddress
        {
            get
            {
                return this.settings.GpibAddress;
            }
            private set
            {
                this.settings.GpibAddress = value;
            }
        }

    }

    [Serializable]
    public class Ke2000Settings : IVISettings
    {

        public int Average;

        private static Ke2000Settings defaultSettings;

        public static Ke2000Settings DefaultSettings
        {
            get { return (Ke2000Settings)defaultSettings.MemberwiseClone(); }
        }

        static Ke2000Settings()
        {
            defaultSettings = new Ke2000Settings();
            defaultSettings.GpibAddress = 1;
            defaultSettings.SourceOrMeasurement = SourceMeasurement.Measurement;
            defaultSettings.VoltageOrCurrent = VIType.Current;
            defaultSettings.ACOrDC = ACDCType.DC;
            defaultSettings.Average = 1;
            defaultSettings.GpibTimeout = TimeoutValue.T3s;
        }

    }

    public class FakeKe2000 : Ke2000
    {

        public override double Measure() { return double.NaN; }
        public override void ApplySettings() { }
        protected override void InternalConnect() { }
        protected override void InternalDisconnect() { }
        protected override void InternalReset() { }
        public override string Name
        {
            get { return string.Format("Fake {0}", base.Name); }
            set { }
        }

    }
}
