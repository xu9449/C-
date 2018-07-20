using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NationalInstruments.NI4882;

namespace myProject2_7001
{
    public partial class Ke7001Ctrl : Form
    {
        public Ke7001 _Ke7001Ctrl = new Ke7001();
        
        public Ke7001Ctrl()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button_7001Init_Click(object sender, EventArgs e)
        {
            Ke7001_Init();
        }

        private void button_7001ChannelOn_Click(object sender, EventArgs e)
        {
            TurnOnChannel();
        }

        private void button_7001ChannelOff_Click(object sender, EventArgs e)
        {
            TurnOffChannel();
        }

        private bool ScanForTosa_R()
        {
            bool retValue = false;
            _Ke7001Ctrl.Connect();
            _Ke7001Ctrl.ScanChannel();
            return (retValue);
        }

        public bool TurnOnChannel()
        {
            bool retValue = false;
            int slotNumber = (int)Ke7001SlotNo.Value;
            int channelNumber = (int)Ke7001ChannelNo.Value;
            _Ke7001Ctrl.Connect();
            retValue = _Ke7001Ctrl.CloseChannel(slotNumber, channelNumber);
            label_Status.Text = slotNumber.ToString() + "!" + channelNumber.ToString();
            return (retValue);
        }
        public bool TurnOnChannel(int slot, int channel)
        {
            bool retValue = false;
            _Ke7001Ctrl.Connect();
            retValue = _Ke7001Ctrl.CloseChannel(slot, channel);
            //label_anyTest.Text = slot.ToString( ) + "!" + channel.ToString( );
            return (retValue);
        }
        public bool TurnOffChannel()
        {
            bool retValue = false;
            int slotNumber = (int)Ke7001SlotNo.Value;
            int channelNumber = (int)Ke7001ChannelNo.Value;
            _Ke7001Ctrl.Connect();
            retValue = _Ke7001Ctrl.OpenChannel(slotNumber, channelNumber);
            label_Status.Text = " -- ! -- ";
            return (retValue);
        }

        public bool TurnOffChannel(int slot, int channel)
        {
            bool retValue = false;
            _Ke7001Ctrl.Connect();
            retValue = _Ke7001Ctrl.OpenChannel(slot, channel);
            //label_anyTest.Text = slot.ToString( ) + "!" + channel.ToString( );
            return (retValue);
        }

        //public Config _Config = new Config();
        //public Form1 _Form1 = new Form1();
       
        public void Ke7001_Init()
        {

            string answer = "";

            //_Ke7001Ctrl.Settings.GpibAddress = configForm.Ke7001GPIB;
            _Ke7001Ctrl.Settings.GpibAddress = 7;
            _Ke7001Ctrl.Settings.GpibTimeout = TimeoutValue.T30s;

            _Ke7001Ctrl.Connect();
            _Ke7001Ctrl.OpenAllChan();
            answer = _Ke7001Ctrl.Query();
            Thread.Sleep(100);
            label_Status.Text = " -- ! -- ";
            //_Form1.addLog(answer);
            //_Form1.addLog("Ke7001_1 initilized.");
            _Ke7001Ctrl.Disconnect();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Ke7001SlotNo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_7001ChannelOn_Click_1(object sender, EventArgs e)
        {
            TurnOnChannel();
        }

        private void button_7001ChannelOff_Click_1(object sender, EventArgs e)
        {
            TurnOffChannel();
        }

        private void button7002_Scan_Click_1(object sender, EventArgs e)
        {
            Ke7001_Init();
            //ScanForTosa_R();
            
        }



    }
}
