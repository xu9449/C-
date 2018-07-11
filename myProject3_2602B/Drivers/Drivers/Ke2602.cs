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

namespace Drivers
{

    public enum K2602Channels
    {
        ChannelA,
        ChannelB
    }

    public static class Ke2602Channel 
    {
        private static string ch1 = "smua";
        private static string ch2 = "smub";
        public static string Ch1 
        {
            get { return ch1; } 
        }
        public static string Ch2 
        {
            get { return ch2; } 
        } 
    }

    public class Ke2602Error : Exception
    {
        public Ke2602Error(string errorMessage, Exception innerException)
            : base("Keithley2602Error:" + errorMessage, innerException) { }
        public Ke2602Error(string errorMessage)
            : base("Keithley2602Error:" + errorMessage) { }
        public Ke2602Error()
            : base("Keithley2602Error:no message...") { }
    }

    public class Ke2602Settings
    {
        public static Ke2602Settings defaultSettings_;
        public byte GpibAddress;
        public TimeoutValue GpibTimeout;
        //public Compliances CurrentCompliances = new Compliances();
        //public Compliances VoltageCompliances = new Compliances();

        //public string ToSettingString()
        //{
        //    string msg = "";
        //    foreach (var prop in this.GetType().GetProperties())
        //    {
        //        msg += prop.Name + "=" + prop.GetValue(this, null) + ",";
        //    }

        //    foreach (var field in this.GetType().GetFields())
        //    {
        //        msg += field.Name + "=" + field.GetValue(this) + ",";
        //    }
        //    return msg;
        //}

        public static Ke2602Settings DefaultSetting
        {
            get { return (Ke2602Settings)defaultSettings_.MemberwiseClone(); }
        }

        static Ke2602Settings()
        {
            defaultSettings_ = new Ke2602Settings();
            defaultSettings_.GpibAddress = 1;
            defaultSettings_.GpibTimeout = TimeoutValue.T30s;//30s? or 3s?
            //defaultSettings_.CurrentCompliances = new Drivers.Compliances(0, 0.4, 0.035);
            //defaultSettings_.VoltageCompliances = new Compliances(-10, 10, 2.5);
        }

    }
    public class Ke2602 : Instrument, IDisposable/*, ISourceMeterMultiCH_Neutron*/
    {
        protected Ke2602Settings settings_ = Ke2602Settings.defaultSettings_;
        Dictionary<K2602Channels, string> channel = new Dictionary<K2602Channels, string>();
        private GpibDriver gpib_ = null;
        protected bool isDisposed_ = false;
        //public bool autoRangeOff = false;
        public Ke2602() 
        { 
        }
        public Ke2602(byte address)
            : this(address, TimeoutValue.T30s) 
        { 
        }
        public Ke2602(byte address, TimeoutValue timeout)
        {
            settings_.GpibAddress = address;
            settings_.GpibTimeout = timeout;
        }

        public Ke2602Settings Settings
        {
            get { return settings_; }
            set
            {
                settings_.GpibAddress = value.GpibAddress;
                settings_.GpibTimeout = value.GpibTimeout;
            }
        }

   
        //public GpibDriver Driver
        //{
        //    get { return gpib_; }
        //    set { gpib_ = value; }
        //}

        #region Instrument override
        
        protected override void InternalConnect()
        {
            try
            {
                if (gpib_ == null)
                {
                    gpib_ = new GpibDriver(settings_.GpibAddress, settings_.GpibTimeout);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error connecting {0} with address {1}. \n{2}", this.Name, settings_.GpibAddress.ToString(), ex.Message));
                this.LogMessage("Keithley2602 InternalConnet... ");
            }
        }

        protected override void InternalDisconnect()
        {
            try
            {
                gpib_.Dispose();
                gpib_ = null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error disconnecting {0} with address {1}.\n{2}", this.Name, settings_.GpibAddress.ToString(), ex.Message));
            }
            this.LogMessage("Keithley2602 internalDisconnet...");
        }

        public string doRead()
        {
            return gpib_.Query("READ?");
        }

        //protected override void InternalReset()
        //{
        //    this.LogMessage("Keithley2602 InternalReset...");
        //    try { gpib_.Reset(); }
        //    //gpib_.ClearStatus();//add
        //    // ApplySettings() shoule I add it? it is not used in this programme.
        //    /*AutoRange = false;*///??
        //    catch (Exception ex)
        //    {
        //        throw new Exception(string.Format("Error disconnecting {0} with address {1}.\n{2}", this.Name, settings_.GpibAddress.ToString(), ex.Message));
        //    }
        //}
        //public void SetCurMeasurementRange(double rangeLevel)  //rangeLevel in unit of A
        //{
        //    //AutoRange = false;
        //    //have to set compliance right first
        //    string cmdStrv = "CURRent:RANGe " + rangeLevel.ToString();
        //    gpib_.Write(cmdStrv);
        //}

        //public override void ApplySettings()
        //{
        //    base.ApplySettings();
        //}
        //public override void ApplySettings()
        //    {
        //        AutoRange = true;
        //    }


        //public double ReadCurMeasurementRange()  
        //rangeLevel in unit of A
        //{
        //    string cmdStrv = "CURRent:RANGe?";
        //    gpib.Write(cmdStrv);
        //    string rangeLevelStr = gpib.Read();

        //    return Convert.ToDouble(rangeLevelStr);
        //}

        //public override void ApplySettings()
        //{
        //    //SetCompliance(0.01);            //10mA for voltage source.
        //    AutoRange = true;
        //}


        //public void SetFrontRear(bool isFront)
        //{
        //    try
        //    {
        //        string wrt = string.Empty;
        //        if (isFront)
        //            wrt = "FRON";
        //        else
        //            wrt = "REAR";
        //        wrt = ":ROUT:TERM " + wrt;
        //        this.gpib.Write(wrt);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message + this.gpib.Device.PrimaryAddress.ToString());
        //    }

        //}
        #endregion

        #region IDisposable
        public void Dispose()
        {
            try
            {
                if (!this.isDisposed_)
                {
                    if (gpib_ != null)
                    {
                        gpib_.Dispose();
                    }
                    isDisposed_ = true;
                }
                this.LogMessage("Keithley2602 Dispose..."); // 2602
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602 Dispose...", ex); //2602
            }

        }
        #endregion

        public byte GpibAddress
        {
            get
            {
                return settings_.GpibAddress;
            }
            private set
            {
                settings_.GpibAddress = value;
            }
        }

       


        //public new string Name
        //{
        //    get { return "Keithley 2602"; }
        //}
        //public virtual void SetCompliance(double value)
        //{
        //    try
        //    {
        //        if (value == 0)
        //            return;
        //        base.SetCompliance(value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public virtual void SetCompliance(Compliance value)
        //{
        //    this.SetCompliance((double)this.Compliances.GetHash(value));
        //}

        //protected void setCompliance(string value)
        //{
        //    string wrt = string.Empty;
        //    try
        //    {

        //        wrt = string.Format("SENS:{0}:{1}:PROT:LEV {2}", (settings_.VoltageOrCurrent == VIType.Voltage ? "CURR" : "VOLT"), settings_.ACOrDC.ToString(), value);
        //        gpib_.Device.Write(wrt);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message + gpib_.Device.PrimaryAddress.ToString() + wrt);
        //    }
        //}

        //public Compliances Compliances
        //{
        //    get
        //    {
        //        return this.compliance;
        //    }
        //    set
        //    {
        //        this.compliance = value;
        //    }
        //}

      
        
        
        

        public override string InternalQuery()
        {
            GpibIdentity id;
            try
            {
                id = gpib_.GetIdentity();
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error InternalQuery Keithley2602...", ex);
            }
            return "#" + id.manufacturer + "#" + id.model + "#" + id.serialNumber + "#" + id.firmwareVersion;
        }

        public void Init()
        {
            try
            {
                //gpib_.Write("Output Off");
                //Thread.Sleep(500);
                gpib_.Write("reset() waitcomplete()");
                Thread.Sleep(500);
                channel.Clear();
                channel.Add(K2602Channels.ChannelA, "smua");
                channel.Add(K2602Channels.ChannelB, "smub");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void InitChannel(K2602Channels channel_)
        {
            try
            {
                string _channel = channel[channel_];
                gpib_.Write(_channel+ ".reset() waitcomplete()");
                Thread.Sleep(500);
                gpib_.Write("SweepILinMeasureV(smua, 1E-4, 1E-1, 0, 10)" );

                
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void InitA()
        {
            try
            {               
                gpib_.Write("smua.reset() waitcomplete()");
                Thread.Sleep(500);

            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        
        public void InitB()
        {
            try
            {
                //gpib_.Write("Output Off");
                //Thread.Sleep(500);
                gpib_.Write("smub.reset() waitcomplete()");
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void Cls(){
            try
            {
                gpib_.Write("CLS");
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void OutPutOn(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".source.output = 1");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void Outputoff(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".source.output = 0");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void SourceFuncV(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".source.func= " + kCHN + ".OUTPUT_DCVOLTS");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }

        }

        public void SourceFuncI(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".source.func= " + kCHN + ".OUTPUT_DCAMPS");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }

        }

        public void SourceLimitV(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".source.limitv = " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void SourceLimitI(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".source.limiti = " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void SourceAutoV(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".source.autorangev = 1");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void SourceAutoI(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".source.autorangei = 1");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void SetSourceVoltRange(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".source.rangev= " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void SetSourceCurrRange(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".source.rangei= " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void SetMeasureCurrRange(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.rangei= " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void SetMeasureVoltageRange(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.rangev= " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void SourceLevelV(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".source.levelv = " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }


        public void SourceLevelI(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".source.leveli = " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void SourceDelay(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".source.delay = " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void MeasureAutoV(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.autorangev = 1");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void MeasureAutoI(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.autorangei = 1");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void MeasureCount(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.count = " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void MeasureFilterON(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.analogfilter = 1");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void MeasureFilterOFF(string kCHN)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.analogfilter = 0");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }

        public void MeasureDelay(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.delay = " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void MeasureNPLC(string kCHN, double value)
        {
            try
            {
                gpib_.Write(kCHN + ".measure.nplc = " + value.ToString());
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void MeasureDisplayI(string kCHN)
        {
            try
            {
                gpib_.Write("display." + kCHN + ".measure.func = display.MEASURE_DCAMPS");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public void MeasureDisplayV(string kCHN)
        {
            try
            {
                gpib_.Write("display." + kCHN + ".measure.func = display.MEASURE_DCVOLTS");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
        }
        public double MeasureV(string kCHN)
        {
            double mea;
            try
            {
                gpib_.Write("MyBuf = " + kCHN + ".makebuffer(1)");
                Thread.Sleep(50);
                gpib_.Write("print(" + kCHN + ".measure.v(MyBuf))");
                Thread.Sleep(50);
                string measure = gpib_.Read();
                mea = Double.Parse(measure);
                gpib_.Write("MyBuf.clear()");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
            return (mea);
        }
        public double MeasureI(string kCHN)
        {
            double mea;
            try
            {
                gpib_.Write("MyBuf = " + kCHN + ".makebuffer(1)");
                Thread.Sleep(10);
                gpib_.Write("print(" + kCHN + ".measure.i(MyBuf))");
                Thread.Sleep(10);
                string measure = gpib_.Read();
                Thread.Sleep(200);
                mea = Double.Parse(measure);
                gpib_.Write("MyBuf.clear()");
            }
            catch (Exception ex)
            {
                throw new Ke2602Error("Error Keithley2602", ex);
            }
            return (mea);
        }

        private string GetChString(int ch)
        {
            string[] chInfo = new string[] { "smua", "smub" };
            try
            {
                return chInfo[ch];
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Please input right CH, for 0 to " + chInfo.Length);
                throw;
            }
        }

        public void Output(int ch, bool trueOn_falseOff)
        {
            string chStr = GetChString(ch);
            if (trueOn_falseOff)
            {
                OutPutOn(chStr);
            }
            else
            {
                Outputoff(chStr);
            }
        }

        public void SetCurrSource(int ch, double current_A, double voltageCompliance_V)
        {
            string chStr = GetChString(ch);
            SourceFuncI(chStr);
            SourceLevelI(chStr, current_A);
            SourceLimitV(chStr, voltageCompliance_V);
        }

        public void SetVoltSource(int ch, double voltage_V, double currentCompliance_A)
        {
            string chStr = GetChString(ch);
            SourceFuncV(chStr);
            SourceLevelV(chStr, voltage_V);
            SourceLimitI(chStr, currentCompliance_A);
        }

        public void SetMeasCurrAutoRange(int ch)
        {
            string chStr = GetChString(ch);
            MeasureAutoI(chStr);
        }

        public void SetMeasCurrRange(int ch, double range_A)
        {
            string chStr = GetChString(ch);
            SetMeasureCurrRange(chStr, range_A);
        }

        public double MeasCurr_A(int ch)
        {
            string chStr = GetChString(ch);
            return MeasureI(chStr);
        }

        public void SetMeasVoltAutoRange(int ch)
        {
            string chStr = GetChString(ch);
            MeasureAutoV(chStr);
        }

        public void SetMeasVoltRange(int ch, double range_V)
        {
            string chStr = GetChString(ch);
            SetMeasureVoltageRange(chStr, range_V);
        }

        public double MeasVolt_V(int ch)
        {
            string chStr = GetChString(ch);
            return MeasureV(chStr);
        }
    }

}
