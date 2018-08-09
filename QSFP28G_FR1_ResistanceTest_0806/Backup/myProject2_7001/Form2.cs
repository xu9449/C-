using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject2_7001
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }



        private void ke2400Ctrl1_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public byte ke2400_gpib
        {
            get { return (byte)ke2400Ctrl2.GpibAddress; }
            set { ke2400Ctrl2.GpibAddress = (decimal)value; }
        }

        private void ke2400Ctrl2_Load(object sender, EventArgs e)
        {

        }

    }
}
