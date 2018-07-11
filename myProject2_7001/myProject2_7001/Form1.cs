using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;
using System.Threading;
namespace myProject2_7001
{
    public partial class Form1 : Form
    {
        public Ke7001 Ke7001Ctrl = new Ke7001();
       
        private byte ke7001_gpib{
            get { return (byte)Ke7001GpibAddress.Value; }
            set
            {
                Ke7001GpibAddress.Value = value; 
           }
        }
       public Form1()
        {
            InitializeComponent();
        }
       
        #region buttons

       private void button_7001Init_Click(object sender, EventArgs e)
       {
           Ke7001_Init( );
       }

       private void button_7001ChannelOn_Click(object sender, EventArgs e)
       {
           turnOnChannel( );
       }

       private void button_7001ChannelOff_Click(object sender, EventArgs e)
       {
           turnOffChannel( );
       }

#endregion

       private bool turnOnChannel()
       {
           bool retValue = false;
           int slotNumber = (int)Ke7001SlotNo.Value;
           int channelNumber = (int)Ke7001ChannelNo.Value;
           Ke7001Ctrl.Connect();
           retValue = Ke7001Ctrl.CloseChannel( slotNumber, channelNumber);
           label_Status.Text = slotNumber.ToString() + "!" + channelNumber.ToString();
           return (retValue);
       }

       private bool turnOffChannel()
       {
           bool retValue = false;
           int slotNumber = (int)Ke7001SlotNo.Value;
           int channelNumber = (int)Ke7001ChannelNo.Value;
           Ke7001Ctrl.Connect();
           retValue = Ke7001Ctrl.OpenChannel(slotNumber, channelNumber);
           label_Status.Text = " -- ! -- ";
           return (retValue);
       }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        
        private void Ke7001_Init()
        {

            string answer = "";

            Ke7001Ctrl.Settings.GpibAddress = ke7001_gpib;
            //Ke7001Ctrl.Settings.GpibAddress = 10;
            Ke7001Ctrl.Settings.GpibTimeout = TimeoutValue.T30s;

            Ke7001Ctrl.Connect();
            Ke7001Ctrl.OpenAllChan();
            answer = Ke7001Ctrl.Query();
            Thread.Sleep(100);
            label_Status.Text = " -- ! -- ";
            addLog(answer);
            addLog("Ke7001_1 initilized.");
            Ke7001Ctrl.Disconnect();

        }
        private void addLog(string log)
        {
            richTextBox_Log.AppendText(DateTime.Now.ToString() + ": " + log + "\r\n");
            richTextBox_Log.Focus();//?
            richTextBox_Log.Refresh();

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
