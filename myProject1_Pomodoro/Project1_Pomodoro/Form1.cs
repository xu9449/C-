using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_Pomodoro
{
    public partial class Form1 : Form
    {
        decimal pomoTime, breakTime, timeElapsed;
        bool isPomo = true, isStart = true, hasStarted = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btStarted_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                if (hasStarted)
                {
                    pomoTimer.Start();

                    ((Button)sender).Text = "Stop";
                    isStart = !isStart;

                    return;
                }
                pomoTime = pomoVal.Value * 60; breakTime = breakVal.Value * 60;
                timeElapsed = 0;

                pomoTimer.Start();

                ((Button)sender).Text = "Stop";
                isStart = !isStart;
                hasStarted = true;
            }
            else
            {
                pomoTimer.Stop();
                ((Button)sender).Text = "Start";
                isStart = !isStart;
            }
        }

        private void pomoTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed += (decimal)(((Timer)sender).Interval) / 1000;
            if (timeElapsed > (isPomo ? pomoTime : breakTime))
            {
                timeElapsed = 0;
                isPomo = !isPomo;
                this.Text = (isPomo ? "Pomodoro Timer" : "Break Timer!");

                System.Media.SystemSounds.Asterisk.Play();
            }
            progBar.Value = (int)(timeElapsed / (isPomo ? pomoTime : breakTime) * 100);
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            timeElapsed = 0;
            progBar.Value = 0;
        }

        private void progBar_Click(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, (int)timeElapsed);
            string fmt = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            MessageBox.Show(fmt, "Time Elapsed");
        }

        private void pomoVal_ValueChanged(object sender, EventArgs e)
        {
            pomoTime = ((NumericUpDown)sender).Value * 60;
        }

        private void breakVal_ValueChanged(object sender, EventArgs e)
        {
            breakTime = ((NumericUpDown)sender).Value * 60;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pomoTime = pomoVal.Value * 60; breakTime = breakVal.Value * 60;
            timeElapsed = pomoTime;
        }


        
    }
}
