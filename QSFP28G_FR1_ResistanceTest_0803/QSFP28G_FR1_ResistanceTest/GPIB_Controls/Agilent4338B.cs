using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.NI4882;
//using TOS.Log;
//using TOS.Parameter;
using System.Diagnostics;
using System.Xml.Linq;
using System.Globalization;
using System.Xml;
using System.Threading;
using System.Text.RegularExpressions;

namespace Finisar
  ///
  /// ported from Agi4338B of OSA.NET
  /// 
{
    //throw error
    public class Agilent_4338BError : Exception
    {
        public Agilent_4338BError(string errorMessage, Exception innerException)
            : base("Agilent_4338BError: " + errorMessage, innerException) { }
        public Agilent_4338BError(string errorMessage)
            : base("Agilent_4338BError: " + errorMessage) { }
        public Agilent_4338BError()
            : base("Agilent_4338BError: no message...") { }
    }
    // Class containing the settings for the Agilent E3633A Triple Output DC Power Supply
    [Serializable]
    //Class containing the settings for the Agilent E3633A Triple Output DC Power Supply
    public class Agilent_4338BSettings
    {
        protected static Agilent_4338BSettings defaultSettings_;
        public byte GpibAddress;
        public TimeoutValue GpibTimeout;

        static Agilent_4338BSettings()
        {
            defaultSettings_ = new Agilent_4338BSettings();
            defaultSettings_.GpibAddress = 5;
            defaultSettings_.GpibTimeout = TimeoutValue.T30s;
        }

        public static Agilent_4338BSettings DefaultSettings
        {
            get
            {
                return (Agilent_4338BSettings)defaultSettings_.MemberwiseClone();
            }
        }
    }
    //API properties and methods for programming scripts using the Agilent E3633A Triple Output DC Power Supply
    public class Agilent_4338B : Instrument, IDisposable
    {
        protected Agilent_4338BSettings settings_ = Agilent_4338BSettings.DefaultSettings;
        protected GpibDriver gpib_ = null;
        protected bool isDisposed_ = false;
        protected CultureInfo culture_ = new CultureInfo("en-US");//English

        // Default constructor for the AgE3633A class
        public Agilent_4338B()
        { }
        public Agilent_4338B(byte address)
            : this(address, TimeoutValue.T30s)
        { }
        public Agilent_4338B(byte address, TimeoutValue timeout)
        {
            settings_ = Agilent_4338BSettings.DefaultSettings;
            settings_.GpibAddress = address;
            settings_.GpibTimeout = timeout;
        }
        // Dispose method for the AgE3633A class
        public void Dispose()
        {
            this.LogMessage("Agilent4338B Dispose...");

            if (!this.isDisposed_)
            {
                if (gpib_ != null)
                { gpib_.Dispose(); }
            }
        }
        // Method used to initialize the GPIB interface
        protected override void InternalConnect()
        {
            this.LogMessage("Agilent4338B InternalConnect...");
            try
            {
                if (gpib_ == null)
                {
                    gpib_ = new GpibDriver(settings_.GpibAddress, settings_.GpibTimeout);
                }
            }
            catch (Exception ex)
            { throw new Agilent_4338BError("Error connecting Agilent4338B!", ex); }
        }
        //Disposes the current instance of the GPIB driver
        protected override void InternalDisconnect()
        {
            this.LogMessage("Agilent4338B InternalDisconnect...");
            try
            {
                gpib_.Dispose();
                gpib_ = null;
            }
            catch (Exception ex)
            { throw new Agilent_4338BError("Error disconnecting Agilent4338B!", ex); }
        }
        protected override void InternalReset()
        {
            this.LogMessage("Agilent4338B InternalReset...");
            try
            { gpib_.Reset(); }
            catch (Exception ex)
            { throw new Agilent_4338BError("Error resetting Agilent4338B.", ex); }
        }
        public override void ApplySettings()
        {
            base.ApplySettings();
        }
        // Gets/sets the settings for the instrument (XML)
        public override XElement XmlSettings
        {
            get
            {
                return settings_.XmlWriterSerialize(null, settings_.GetType().Name);
            }
            set
            {
                XmlReader xmlReader = XmlReader.Create(value.CreateReader(), SerializerExtensions.ReaderSettings);
                settings_ = (Agilent_4338BSettings)xmlReader.XmlReaderDeserialize(typeof(Agilent_4338BSettings), typeof(Agilent_4338BSettings).Name);
            }
        }
        public override string InternalQuery()
        {
            //return base.InternalQuery();
            GpibIdentity id;
            try
            {
                id = gpib_.GetIdentity();

            }
            catch (Exception ex)
            { throw new Agilent_4338BError("Error resetting Agilent_4338BError.", ex); }
            return "#" + id.manufacturer + "#" + id.model + "#" + id.serialNumber + "#" + id.firmwareVersion;
        }

        // Gets/sets the settings for the instrument
        public Agilent_4338BSettings Settings
        {
            get
            { return settings_; }
            set
            {
                settings_.GpibAddress = value.GpibAddress;
                settings_.GpibTimeout = value.GpibTimeout;
            }
        }
        // Gets/sets the driver for the GPIB interface
        public GpibDriver Driver
        {
            get { return gpib_; }
            set { gpib_ = value; }
        }
        public void SetInitCont()
        {
            try
            {
                gpib_.Write(":INITiate:CONTinuous 1");
            }
            catch (Exception ex)
            {
                throw new Agilent_4338BError("Agilent 4338B Init Cont error...", ex);
            }
        }
        public double Measure()
        {
            try
            {
                gpib_.Write(":FETCH?");
                string ReturnString = gpib_.Read();
                string[] sArray = Regex.Split(ReturnString, ",", RegexOptions.IgnoreCase);
                return Convert.ToDouble(sArray[1]);
            }
            catch (Exception ex)
            {
                throw new Agilent_4338BError("Setoutput error...", ex);
            }
        }
    }
}

