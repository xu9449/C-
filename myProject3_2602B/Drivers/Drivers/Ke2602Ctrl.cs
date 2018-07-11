using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments;
using System.Threading;
using System.IO;
//using ZedGraph;
//using ACR_Resistance_QSFPDD.Tests;
using Drivers;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Drivers
{
    public partial class Ke2602Ctrl : Form
    {

        //protected object instrumentSync = new object();
        public Ke2602 _ke2602Ctrl;
        float rampStep = 0.5F;
        float CurrentSetpoint = 0;
        float CurrentMeasureResult = 0;
        bool UpdateOnly = false;

        public delegate void OutputStatusUpdate(object sender, bool state); 
        public event OutputStatusUpdate UpdateOutputStatus; 

        public delegate void Voltage_Current_EventHandler(double voltageValue, double currentValue); 
/*        public event Voltage_Current_EventHandler VoltageCurrentUp date;*/ 


        public Ke2602Ctrl()
        {
            InitializeComponent();
            
        }

        public decimal GpibAddress
        {
            get { return nudGpibAddress.Value; }
            set { nudGpibAddress.Value = value; }
        }

        public int ChannelNumber { get; set; }

        public bool IsVoltageControl
        {
            get { return chkVoltageCtrl.Checked; }
            set { chkVoltageCtrl.Checked = value; }
        }

        public bool IsVoltageMeasurement
        {
            get { return chkMeasureVoltage.Checked; }
            set { chkMeasureVoltage.Checked = value; }
        }

        public float ComplianceSetpoint {
            get
            {
                return (float)nudComplianceSetpoint.Value;
            }
            set { nudComplianceSetpoint.Value = (decimal)value; }
        }

        public bool Initialization()
        {
            bool retValue = false;
            _ke2602Ctrl = new Drivers.Ke2602((byte)GpibAddress);
            GpibAddress = byte.Parse(nudGpibAddress.Value.ToString());
            if (_ke2602Ctrl != null){
                btnInit.Enabled = false;
                //_ke2602Ctrl.SetCompliance((double)nudComplianceSetpoint.Value);
                //_ke2602Ctrl.SourceVI = IsVoltageControl ? VIType.Voltage : VIType.Current;
                if (IsVoltageMeasurement)
                { }
                    //_ke2602Ctrl.MeasurementVI = VIType.Voltage;
                    //_ke2602Ctrl.MeasurementACDC = ACDCType.DC;
                    //_ke2602Ctrl.setMeasureFunction(VIType.Voltage, ACDCType.DC);
                btnRead.Enabled = true;
                retValue = true;
                CurrentSetpoint = 0;
            }
                //_ke2602Ctrl.SetBeep(false);
            return retValue;
        }
        private void gpibNumber_ValueChanged(object sender, EventArgs e)
        {
            GpibAddress = (byte)nudGpibAddress.Value;
        }

        /// <summary>
        /// Button Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnInit_Click(object sender, EventArgs e)
        {
            Initialization();
            _ke2602Ctrl.Connect();
            _ke2602Ctrl.Init(); 
            textBox1.Text = "Hello Kexin！";
            string dddd = _ke2602Ctrl.InternalQuery();
            
        }

        private void btnResA_Click(object sender, EventArgs e)
        {
          _ke2602Ctrl.InitA();
            _ke2602Ctrl.InitChannel(K2602Channels.ChannelA);

        }

        private void btnResB_Click(object sender, EventArgs e)
        {
            _ke2602Ctrl.InitB();
            _ke2602Ctrl.InitChannel(K2602Channels.ChannelB);
        }

        private void btnDiscon_Click(object sender, EventArgs e)
        {
            _ke2602Ctrl.Disconnect();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nudGpibAddress_ValueChanged(object sender, EventArgs e)
        {
            GpibAddress = (byte)nudGpibAddress.Value;
        }


        private void chkVoltageCtrl_CheckedChanged_1(object sender, EventArgs e)
        {
            IsVoltageControl = chkVoltageCtrl.Checked;
            if (_ke2602Ctrl != null)
            {
                //if (IsVoltageControl)
                //    _ke2602Ctrl.SourceVI = VIType.Voltage;
                //else
                //    _ke2602Ctrl.SourceVI = VIType.Current;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            TakeMeasurement();
        }

        private void nudSetpoint_ValueChanged(object sender, EventArgs e)
        {
            if (!UpdateOnly)
                Setpoint((float)nudSetpoint.Value);
        }

        private void nudComplianceSetpoint_ValueChanged(object sender, EventArgs e)
        {
            if (_ke2602Ctrl == null)
                return;
            double value = (double)nudComplianceSetpoint.Value; // / 1000;
            //_ke2602Ctrl.SetCompliance( value ); // Change this line as below to handle both current and voltage, but note the interface only designed for current source initially that we did not update
            // FM-16-07-01
            if (IsVoltageControl)
            {
                //_ke2602Ctrl.setComplianceI(value.ToString());
            }
            else
            {
                //_ke2602Ctrl.SetCompliance(value);
            }
        }

        private void Ke2602Ctrl_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ramp_Click(object sender, EventArgs e)
        {
           /* Ramp((float)nudSetpoint.Value, (float)nudTargetPoint.Value, true)*/;
        }

        #region Support Functions

        public void setBeep(bool on)
        {
            //_ke2602Ctrl.SetBeep(on);
        }
        void DisableConfig()
        {
            chkVoltageCtrl.Enabled = false;
            //chkFrontMeasure.Enabled = false;
            nudComplianceSetpoint.Enabled = false;
            nudGpibAddress.Enabled = false;
            btnInit.Enabled = false;
        }
        void EnableSetting()
        {
            //chkTurnOn.Enabled = true;
            nudSetpoint.Enabled = true;
            btnRead.Enabled = true;
        }

        public void Ramp(float startValue, float targetValue, bool raiseEvent)
        {
            float rampValue = (targetValue - startValue) > 0 ? 1 : -1;
            rampValue = rampValue * rampStep;
            //UpdateOnly = true;
            while (startValue != targetValue)
            {
                //startValue += rampValue;
                //_ke2602Ctrl.Set(startValue);
                //double curRead = _ke2602Ctrl.measureCurrent();
                //if (VoltageCurrentUpdate != null)
                //    VoltageCurrentUpdate(startValue, curRead);

            }
            if (startValue != targetValue)
                //_ke2602Ctrl.Set(targetValue);
            //CurrentSetpoint = targetValue;
            //nudSetpoint.Value = ( decimal )CurrentSetpoint;
            UpdateOnly = false;
        }
        //public string doRead()
        //{
        //    //return _ke2602Ctrl.doRead();
        //}

        public void EnableOutput(bool state)
        {
            if (_ke2602Ctrl != null)
            {
                //_ke2602Ctrl.OutputEnabled = state;
                //UpdateOnly = true;
                //chkTurnOn.Checked = state;
                //UpdateOnly = false;
                if (state == false)
                {
                    CurrentMeasureResult = 0;
                    //lblReading.Text = "--";
                    CurrentSetpoint = 0;
                }
                else
                    CurrentSetpoint = (float)nudSetpoint.Value;
                if (UpdateOutputStatus != null)
                    UpdateOutputStatus(this, state);
            }
        }

        public void Setpoint(float setValue)
        {
            if (_ke2602Ctrl != null)
            {
                UpdateOnly = true;
                setValue = setValue / 1000;
                //_ke2602Ctrl.Set(setValue, false);
                CurrentSetpoint = setValue * 1000;
                nudSetpoint.Value = (decimal)CurrentSetpoint;
                UpdateOnly = false;
            }
        }

        public void SetpointV(float setValue) //FM-16-07-01 added
        {
            if (_ke2602Ctrl != null)
            {
                UpdateOnly = true;
                //_ke2602Ctrl.Set(setValue);
                CurrentSetpoint = setValue;
                nudSetpoint.Value = (decimal)CurrentSetpoint;
                UpdateOnly = false;
            }
        }

        //public float GetCurrentVoltage()
        //{
        //    //return (float)_ke2602Ctrl.measureVoltage();
        //}

        //public float GetCurrent()
        //{
        //    //return _ke2602Ctrl.Measure( );
        //    //return (float)_ke2602Ctrl.measureCurrent();
        //}
        private void SetToGround()
        {
            Setpoint(0);
        }

        public double GetCurrentMeasurement()
        {
            return CurrentMeasureResult;
        }

        public float GetCurrentSetPoint()
        {
            return CurrentSetpoint;
        }

        public float TakeMeasurement()
        {
           
            return CurrentMeasureResult;
        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Blue;
            textBox1.ForeColor = Color.White;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void autoRBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void disconnectButton_Click_1(object sender, EventArgs e)
        {

        }

    }
}
