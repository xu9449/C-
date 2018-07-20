namespace myProject2_7001
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_SerialNumber = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_LotNumber = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_Operator = new System.Windows.Forms.TextBox();
            this.btn_ConfigFile = new System.Windows.Forms.Button();
            this.textBox_ConfigFile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.ke2400GPIB = new System.Windows.Forms.TextBox();
            this.Ke2400_GPIB = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Ke7001_GPIB = new System.Windows.Forms.NumericUpDown();
            this.textBox_OutputDirectory = new System.Windows.Forms.TextBox();
            this.btn_OutputDirectctory = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ke2400_GPIB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001_GPIB)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(213, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(251, 269);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config Info";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_SerialNumber);
            this.groupBox4.Location = new System.Drawing.Point(0, 84);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 65);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SerialNumber";
            // 
            // textBox_SerialNumber
            // 
            this.textBox_SerialNumber.Location = new System.Drawing.Point(11, 21);
            this.textBox_SerialNumber.Name = "textBox_SerialNumber";
            this.textBox_SerialNumber.Size = new System.Drawing.Size(231, 22);
            this.textBox_SerialNumber.TabIndex = 1;
            this.textBox_SerialNumber.TextChanged += new System.EventHandler(this.textBox_SerialNumber_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_LotNumber);
            this.groupBox5.Location = new System.Drawing.Point(0, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 57);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "LotNumber";
            // 
            // textBox_LotNumber
            // 
            this.textBox_LotNumber.Location = new System.Drawing.Point(11, 21);
            this.textBox_LotNumber.Name = "textBox_LotNumber";
            this.textBox_LotNumber.Size = new System.Drawing.Size(231, 22);
            this.textBox_LotNumber.TabIndex = 0;
            this.textBox_LotNumber.TextChanged += new System.EventHandler(this.textBox_LotNumber_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox_Operator);
            this.groupBox6.Location = new System.Drawing.Point(0, 161);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(248, 63);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Operator";
            // 
            // textBox_Operator
            // 
            this.textBox_Operator.Location = new System.Drawing.Point(11, 21);
            this.textBox_Operator.Name = "textBox_Operator";
            this.textBox_Operator.Size = new System.Drawing.Size(231, 22);
            this.textBox_Operator.TabIndex = 2;
            this.textBox_Operator.TextChanged += new System.EventHandler(this.textBox_Operator_TextChanged);
            // 
            // btn_ConfigFile
            // 
            this.btn_ConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConfigFile.Location = new System.Drawing.Point(3, 35);
            this.btn_ConfigFile.Name = "btn_ConfigFile";
            this.btn_ConfigFile.Size = new System.Drawing.Size(230, 28);
            this.btn_ConfigFile.TabIndex = 3;
            this.btn_ConfigFile.Text = "Choose";
            this.btn_ConfigFile.UseVisualStyleBackColor = true;
            this.btn_ConfigFile.Click += new System.EventHandler(this.btn_ConfigFile_Click_1);
            // 
            // textBox_ConfigFile
            // 
            this.textBox_ConfigFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_ConfigFile.Location = new System.Drawing.Point(3, 3);
            this.textBox_ConfigFile.Name = "textBox_ConfigFile";
            this.textBox_ConfigFile.Size = new System.Drawing.Size(455, 26);
            this.textBox_ConfigFile.TabIndex = 1;
            this.textBox_ConfigFile.Text = "ConfigFile";
            this.textBox_ConfigFile.TextChanged += new System.EventHandler(this.textBox_ConfigFile_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel4);
            this.groupBox2.Location = new System.Drawing.Point(470, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 269);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Session Information";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.ke2400GPIB);
            this.flowLayoutPanel4.Controls.Add(this.Ke2400_GPIB);
            this.flowLayoutPanel4.Controls.Add(this.textBox1);
            this.flowLayoutPanel4.Controls.Add(this.Ke7001_GPIB);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(6, 34);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(244, 234);
            this.flowLayoutPanel4.TabIndex = 2;
            // 
            // ke2400GPIB
            // 
            this.ke2400GPIB.Location = new System.Drawing.Point(3, 3);
            this.ke2400GPIB.Name = "ke2400GPIB";
            this.ke2400GPIB.Size = new System.Drawing.Size(100, 22);
            this.ke2400GPIB.TabIndex = 0;
            this.ke2400GPIB.Text = "KE2400_GPIB";
            this.ke2400GPIB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Ke2400_GPIB
            // 
            this.Ke2400_GPIB.Location = new System.Drawing.Point(109, 3);
            this.Ke2400_GPIB.Name = "Ke2400_GPIB";
            this.Ke2400_GPIB.Size = new System.Drawing.Size(100, 22);
            this.Ke2400_GPIB.TabIndex = 0;
            this.Ke2400_GPIB.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Ke2400_GPIB.ValueChanged += new System.EventHandler(this.Ke2400_GPIB_ValueChanged);
            this.Ke2400_GPIB.Enter += new System.EventHandler(this.answer_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "KE7001_GPIB";
            // 
            // Ke7001_GPIB
            // 
            this.Ke7001_GPIB.Location = new System.Drawing.Point(109, 31);
            this.Ke7001_GPIB.Name = "Ke7001_GPIB";
            this.Ke7001_GPIB.Size = new System.Drawing.Size(100, 22);
            this.Ke7001_GPIB.TabIndex = 1;
            this.Ke7001_GPIB.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.Ke7001_GPIB.ValueChanged += new System.EventHandler(this.Ke7001_GPIB_ValueChanged);
            this.Ke7001_GPIB.Enter += new System.EventHandler(this.answer_Enter);
            // 
            // textBox_OutputDirectory
            // 
            this.textBox_OutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_OutputDirectory.Location = new System.Drawing.Point(3, 69);
            this.textBox_OutputDirectory.Name = "textBox_OutputDirectory";
            this.textBox_OutputDirectory.Size = new System.Drawing.Size(455, 26);
            this.textBox_OutputDirectory.TabIndex = 3;
            this.textBox_OutputDirectory.Text = "OutputDirectory";
            this.textBox_OutputDirectory.TextChanged += new System.EventHandler(this.textBox_OutputDirectory_TextChanged);
            // 
            // btn_OutputDirectctory
            // 
            this.btn_OutputDirectctory.Location = new System.Drawing.Point(3, 101);
            this.btn_OutputDirectctory.Name = "btn_OutputDirectctory";
            this.btn_OutputDirectctory.Size = new System.Drawing.Size(230, 25);
            this.btn_OutputDirectctory.TabIndex = 2;
            this.btn_OutputDirectctory.Text = "Choose";
            this.btn_OutputDirectctory.UseVisualStyleBackColor = true;
            this.btn_OutputDirectctory.Click += new System.EventHandler(this.btn_OutputDirectctory_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Ok.Location = new System.Drawing.Point(3, 3);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(230, 38);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.AutoSize = true;
            this.btn_Cancel.Location = new System.Drawing.Point(3, 47);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(230, 38);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Select a ConfigFile";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel5.Controls.Add(this.btn_Ok);
            this.flowLayoutPanel5.Controls.Add(this.btn_Cancel);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(493, 332);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(237, 91);
            this.flowLayoutPanel5.TabIndex = 4;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel6.Controls.Add(this.textBox_ConfigFile);
            this.flowLayoutPanel6.Controls.Add(this.btn_ConfigFile);
            this.flowLayoutPanel6.Controls.Add(this.textBox_OutputDirectory);
            this.flowLayoutPanel6.Controls.Add(this.btn_OutputDirectctory);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(6, 297);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(458, 126);
            this.flowLayoutPanel6.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(210, 268);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.radioButton1);
            this.flowLayoutPanel3.Controls.Add(this.radioButton2);
            this.flowLayoutPanel3.Controls.Add(this.radioButton3);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(209, 265);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(135, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "None                  ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(99, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Resistance";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 57);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Direct Short";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 461);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel6);
            this.Name = "Config";
            this.Text = "Config Info";
            this.Load += new System.EventHandler(this.Config_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ke2400_GPIB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001_GPIB)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox textBox_ConfigFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_ConfigFile;
        private System.Windows.Forms.Button btn_OutputDirectctory;
        private System.Windows.Forms.TextBox textBox_OutputDirectory;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TextBox ke2400GPIB;
        private System.Windows.Forms.NumericUpDown Ke2400_GPIB;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.NumericUpDown Ke7001_GPIB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_SerialNumber;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_LotNumber;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox_Operator;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}