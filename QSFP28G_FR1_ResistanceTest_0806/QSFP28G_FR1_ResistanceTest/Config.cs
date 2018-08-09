using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QSFP28G_FR1_ResistanceTest
{

    public enum TestPhase
    {
        Sweep,
        Resistance,
        Shortcut
    }
    
    public enum SweepType
    {
        Stair,
        Log,
        Custom,
        SRCMemory
    }

    public enum SweepSource
    {
        SourceV,
        SourceI
    }

    public partial class Config : Form
    {
        public Form1 thisobj = null;
        #region [FormSettings]

        //public Form1 form1 = new Form1();
        public string lotNumber { get; set; }
        public string serialNumber { get; set; }
        public string operatorName { get; set; }

        public string configFile
        {
            get
            {
                return textBox_ConfigFile.Text;
            }
            set
            {
                textBox_ConfigFile.Text = value;
            }
        }

        public string outputdirectory
        {
            get
            {
                return textBox_OutputDirectory.Text;
            }
            set
            {
                textBox_OutputDirectory.Text = value;
            }
        }

        //public string testSpec
        //{
        //    get;
        //    set;
        //}

        public byte Ke2400GPIB
        {
            get
            {
                return ((byte)Ke2400_GPIB.Value);
            }
            set
            {
                Ke2400_GPIB.Value = value;
            }
        }

        public byte Ke7001GPIB
        {
            get
            {
                return ((byte)Ke7001_GPIB.Value);
            }
            set
            {
                Ke7001_GPIB.Value = value;
            }
        }

        public TestPhase testPhase { get; set; }
        public SweepType sweepType { get; set; }
        public SweepSource sweepSource { get; set; }

    #endregion [FormSettings]

        #region [Construction]

        public Config()
        {
            InitializeComponent();
        }

        #endregion [Construction]

        #region [SettingConfigUI]

        public void configReset()
        {

            this.textBox_LotNumber.Text = lotNumber;
            this.textBox_SerialNumber.Text = serialNumber;
            this.textBox_Operator.Text = operatorName;

            this.textBox_ConfigFile.Text = configFile;
            this.textBox_OutputDirectory.Text = outputdirectory;
            //this.textBox_TestSpec.Text = testSpec;

            this.Ke2400_GPIB.Value = (decimal)Ke2400GPIB;
            this.Ke7001_GPIB.Value = (decimal)Ke7001GPIB;

            setTestPhase(testPhase);
        }

        private void setTestPhase(TestPhase tp)
        {
            switch (tp.ToString().ToLower())
            {
                case "Resistance":
                    radioButton1.Checked = true;
                    break;
                case "Sweep":
                    radioButton2.Checked = true;
                    break;
                case "None":
                    radioButton3.Checked = true;
                    break;
                default:
                    break;
            }
        }

        #endregion [SettingConfigUI]

        #region [EventHandlers]

        //private void btn_Ok_Click(object sender, EventArgs e)
        //{
        //    //if (checkConfigFile(configFile) == false)
        //    //{
        //    //    MessageBox.Show("Config File Error: Non-existant " + configFile + "\n");
        //    //    return;
        //    //};
        //    //if (checkOutputDirectory(outputdirectory) == false)
        //    //{
        //    //    MessageBox.Show("Output Directory Error: Non-existant " + outputdirectory + "\n");
        //    //    return;
        //    //};

        //    //if (checkSpecFile(testSpec) == false)
        //    //{
        //    //    MessageBox.Show("Test Spec File Error: Non-existant " + testSpec + "\n");
        //    //    return;
        //    //};

        //    this.Close(); 
        //}


        private void btn_ConfigFile_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_ConfigFile.Text = openFileDialog1.FileName;

            }
        }
        private void btn_OutputDirectctory_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_OutputDirectory.Text = saveFileDialog1.FileName;
            }
        }

        #endregion [EventHandlers]

        #region [ConfigParameters]

        private void textBox_Operator_TextChanged(object sender, EventArgs e)
        {
            operatorName = this.textBox_Operator.Text;
        }

        private void textBox_LotNumber_TextChanged(object sender, EventArgs e)
        {
            lotNumber = this.textBox_LotNumber.Text;
        }

        private void textBox_SerialNumber_TextChanged(object sender, EventArgs e)
        {
            serialNumber = this.textBox_SerialNumber.Text;
        }

        private void textBox_ConfigFile_TextChanged(object sender, EventArgs e)
        {
            configFile = this.textBox_ConfigFile.Text;
        }
        private void textBox_OutputDirectory_TextChanged(object sender, EventArgs e)
        {
            outputdirectory = this.textBox_OutputDirectory.Text;
        
        }
        //private void textBox_TestSpec_TextChanged(object sender, EventArgs e)
        //{
        //    testSpec = textBox_TestSpec.Text;
        //}

        public void Ke7001_GPIB_ValueChanged(object sender, EventArgs e)
        {
            Ke7001GPIB = (byte)Ke7001_GPIB.Value;
        }

        public void Ke2400_GPIB_ValueChanged(object sender, EventArgs e)
        {
            Ke2400GPIB = (byte)Ke2400_GPIB.Value;
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

         #endregion [ConfigParameters]


        #region [Actions]
       
        private Boolean checkConfigFile(string file)
        {
            return (System.IO.File.Exists(file));
        }

        private Boolean checkOutputDirectory(string path)
        {
            return (System.IO.Directory.Exists(path));
        }

        private Boolean checkSpecFile(string file)
        {
            return (System.IO.File.Exists(file));
        }

        #endregion [Actions]

     


        
        public decimal ke2400Ctrl1 { get; set; }

        public string searialNumber { get; set; }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            testPhase = TestPhase.Sweep;
            if (radioButton1.Checked == true)
            {
                radioButton1.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                radioButton1.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            testPhase = TestPhase.Resistance;
            if (radioButton2.Checked == true)
            {
                radioButton2.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                radioButton2.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            testPhase = TestPhase.Shortcut;
            if (radioButton3.Checked == true)
            {
                radioButton3.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                radioButton3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }
        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

  
        private void Config_Load(object sender, EventArgs e)
        {

        }



        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (testPhase == TestPhase.Sweep)
            {
                if (thisobj != null)
                {
                    thisobj.button1_Click(sender, e);
                    this.Close();
                }
            }
            if (testPhase == TestPhase.Resistance)
            {
                if (thisobj != null)
                {
                    thisobj.button4_Click(sender, e);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
                    
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void keToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 aaa = new Form2();
            aaa.Show();
        }

        private void ke7011ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ke7001Ctrl ccc = new Ke7001Ctrl();
            ccc.Show();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "STAIR")
            {
                sweepType = SweepType.Stair;
            }
            else if (comboBox1.Text == " LOG ")
            {

                sweepType = SweepType.Log;
            }
            else if (comboBox1.Text == "COSTOM")
            {
                sweepType = SweepType.Custom;
            }
            else{
                sweepType = SweepType.SRCMemory;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          

            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            sweepSource = SweepSource.SourceI;
            
            if (radioButton5.Checked == true)
            {
                radioButton5.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                radioButton5.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            sweepSource = SweepSource.SourceV;
            
            if (radioButton4.Checked == true)
            {
                radioButton4.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                radioButton4.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void sourceLevel_TextChanged(object sender, EventArgs e)
        {
            double bias = 0;
            if (comboBox1.Text == "STAIR")
            {
                bias = Convert.ToDouble(sourceLevel.Text);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
      