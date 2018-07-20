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


    public enum TestPhase
    {
        None,
        Resistance,
        DirectShort
    }

    #region FormSettings
    public partial class Config : Form
    {


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

    #endregion FormSettings

        #region Construction

        public Config()
        {
            InitializeComponent();
        }

        #endregion Construction

        #region SettingConfigUI

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
                case "None":
                    radioButton1.Checked = true;
                    break;
                case "Resistance":
                    radioButton2.Checked = true;
                    break;
                case "DirectShort":
                    radioButton3.Checked = true;
                    break;
                default:
                    break;
            }
        }

        #endregion SettingConfigUI

        #region EventHandlers

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (checkConfigFile(configFile) == false)
            {
                MessageBox.Show("Config File Error: Non-existant " + configFile + "\n");
                return;
            };
            if (checkOutputDirectory(outputdirectory) == false)
            {
                MessageBox.Show("Output Directory Error: Non-existant " + outputdirectory + "\n");
                return;
            };

            //if (checkSpecFile(testSpec) == false)
            //{
            //    MessageBox.Show("Test Spec File Error: Non-existant " + testSpec + "\n");
            //    return;
            //};

            this.Close(); // why we need this 
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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


        #endregion EventHandlers

        #region ConfigParameters

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

        public void Ke2400_GPIB_ValueChanged(object sender, EventArgs e)
        {
            Ke2400GPIB = (byte)Ke2400_GPIB.Value;
        }

        public void Ke7001_GPIB_ValueChanged(object sender, EventArgs e)
        {
            Ke7001GPIB = (byte)Ke7001_GPIB.Value;
        }

        #endregion ConfigParameters

        #region Actions


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

        private void loadConfigFile()
        {
            // TBD.  API to external object, not this.
        }

        #endregion Actions

        public decimal ke2400Ctrl1 { get; set; }

        public string searialNumber { get; set; }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            testPhase = TestPhase.None;
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
            testPhase = TestPhase.DirectShort;
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



        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }





        private void Config_Load(object sender, EventArgs e)
        {
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }


        }
    }
}
