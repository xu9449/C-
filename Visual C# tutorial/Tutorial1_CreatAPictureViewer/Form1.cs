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
using ZedGraph;
//using ACR_Resistance_QSFPDD.Tests;
using ACR_Resistance_QSFPDD;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ACR_Resistance_QSFPDD
{
    public partial class Form1 : Form
    {
        protected object instrumentSync = new object();
        public Form1()
        {
            InitializeComponent();
        }

        private void Resistance_button1_Click(object sender, EventArgs e)
        {
            //Keithley2400 KE2400_Number1;
            //try
            //{
            //    KE2400_Number1 = new Keithley2400 (Convert.ToByte(ConfigurationManager.AppSettings["laser_GPIB_address"]));
            //    KE2400_Number1.Connect();
            //    KE2400_Number1.OutPutOn();
            //    KE2400_Number1.SetVoltSource(2, 0.000105);


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("" + ex);
            //    return;
            //}

            Ke2000 KE2000_Number1;
            try
            {
                KE2000_Number1 = new Ke2000(Convert.ToByte(ConfigurationManager.AppSettings["laser_GPIB_addressmultimeter"]));
                KE2000_Number1.Connect();
                KE2000_Number1.MeasurementVI = VIType.Current;
                //KE2400_Number1.SetVoltSource(2, 0.000105);


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return;
            }


            Double Out = 0;
            Double Out2 = 0;

            //Out = KE2400_Number1.MeasVolt_V();
            //Out2 = KE2400_Number1.MeasCurr_A();
            //Measure_textBox1.Text = string.Format("{0:0.000000}", Out);
            Measure_textBox1.Text = (KE2000_Number1.Measure() * 1000).ToString();
            //KE4981Al_Number1.Outputoff();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
