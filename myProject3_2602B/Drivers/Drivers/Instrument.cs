using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drivers
{
    public abstract class Instrument : IInstrument
    {
        private bool isConnected = false, isReset = false;
        //private String name_;
        protected object instrumentSync = new object();

        //private InstrumentScheduler scheduler = new InstrumentScheduler( );

        //public InstrumentScheduler Scheduler {
        //  get { return scheduler; }
        //}

        public Instrument()
        {
            InternalInstruments = new Dictionary<string, IInstrument>();
        }

        protected virtual void InternalConnect()
        {

        }

        protected virtual void InternalDisconnect()
        {

        }

        protected virtual void InternalReset()
        {

        }

        public virtual string InternalQuery()
        {
            return null;
        }

        public string Query()
        {
            if (IsConnected)
            {
                return InternalQuery();
            }
            else
            {
                return "the instrument is not connected";
            }
        }

        public void Connect()
        {
            Connect(true);
        }

        public void Connect(bool force)
        {
            lock (instrumentSync)
                if (force || !IsConnected)
                {
                    InternalConnect();
                    IsConnected = true;
                }
        }

        public void Disconnect()
        {
            lock (instrumentSync)
                if (IsConnected)
                {
                    try
                    {
                        //Task.Factory.StartNew( ( ) => { }, new CancellationToken( ), TaskCreationOptions.None, Scheduler ).Wait( );
                        InternalDisconnect();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Instrument Error: " + e.ToString(), e);

                    }
                    IsConnected = false;
                    IsReset = false;
                }
        }

        public void Reset()
        {
            Reset(false);
        }

        public void Reset(bool force)
        {
            lock (instrumentSync)
            {
                if (!IsConnected)
                    Connect();
                if (force || !IsReset)
                {
                    InternalReset();
                    IsReset = true;
                }
            }
        }

        public virtual void ApplySettings()
        {

        }

        public bool IsConnected
        {
            get
            {
                lock (instrumentSync)
                    return isConnected;
            }
            set
            {
                lock (instrumentSync)
                {
                    isConnected = value;
                    NotifyPropertyChanged("IsConnected");
                }
            }
        }

        public bool IsReset
        {
            get
            {
                lock (instrumentSync)
                    return isReset;
            }
            set
            {
                lock (instrumentSync)
                {
                    isReset = value;
                    NotifyPropertyChanged("IsReset");
                }
            }
        }

        public string Name { get; set; }

        public virtual XElement XmlSettings { get; set; }

        public void LogMessage(String message, string messagetype)
        {
            if (Name == null)
                Name = this.GetType().Name;
            LogMessage(message + @", " + messagetype);
        }

        public void LogMessage(String message)
        {
            //LogMessage( message, "Info" );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //private Exception e;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        public Dictionary<String, IInstrument> InternalInstruments { get; set; }
    }

}
