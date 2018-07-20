namespace myProject2_7001
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ResultTxt = new System.Windows.Forms.TextBox();
            this.btn_StartTest = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ke2400oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_clearLog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.Label_lotNumber = new System.Windows.Forms.Label();
            this.Label_searialNumber = new System.Windows.Forms.Label();
            this.Label_operatorName = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Label_testType = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(707, 23);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(141, 18);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.Size = new System.Drawing.Size(374, 417);
            this.richTextBox_Log.TabIndex = 3;
            this.richTextBox_Log.Text = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.richTextBox_Log);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 421);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // ResultTxt
            // 
            this.ResultTxt.Location = new System.Drawing.Point(12, 603);
            this.ResultTxt.Name = "ResultTxt";
            this.ResultTxt.Size = new System.Drawing.Size(207, 22);
            this.ResultTxt.TabIndex = 4;
            // 
            // btn_StartTest
            // 
            this.btn_StartTest.Location = new System.Drawing.Point(3, 3);
            this.btn_StartTest.Name = "btn_StartTest";
            this.btn_StartTest.Size = new System.Drawing.Size(279, 66);
            this.btn_StartTest.TabIndex = 6;
            this.btn_StartTest.Text = "Start Test";
            this.btn_StartTest.UseVisualStyleBackColor = true;
            this.btn_StartTest.Click += new System.EventHandler(this.btn_StartTest_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(3, 75);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(279, 45);
            this.btn_Exit.TabIndex = 7;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(42, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 41);
            this.button2.TabIndex = 10;
            this.button2.Text = "Config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btn_StartTest);
            this.flowLayoutPanel2.Controls.Add(this.btn_Exit);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(413, 403);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(294, 120);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 26);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ke2400oToolStripMenuItem,
            this.keToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.configToolStripMenuItem.Text = "Config Info";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // ke2400oToolStripMenuItem
            // 
            this.ke2400oToolStripMenuItem.Name = "ke2400oToolStripMenuItem";
            this.ke2400oToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ke2400oToolStripMenuItem.Text = "Ke2400  \t";
            this.ke2400oToolStripMenuItem.Click += new System.EventHandler(this.ke2400oToolStripMenuItem_Click);
            // 
            // keToolStripMenuItem
            // 
            this.keToolStripMenuItem.Name = "keToolStripMenuItem";
            this.keToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.keToolStripMenuItem.Text = "Ke7001  \t";
            this.keToolStripMenuItem.Click += new System.EventHandler(this.keToolStripMenuItem_Click);
            // 
            // btn_clearLog
            // 
            this.btn_clearLog.Location = new System.Drawing.Point(227, 468);
            this.btn_clearLog.Name = "btn_clearLog";
            this.btn_clearLog.Size = new System.Drawing.Size(106, 41);
            this.btn_clearLog.TabIndex = 8;
            this.btn_clearLog.Text = "Clear Log";
            this.btn_clearLog.UseVisualStyleBackColor = true;
            this.btn_clearLog.Click += new System.EventHandler(this.btn_clearLog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_lotNumber);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 81);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Label_searialNumber);
            this.groupBox2.Location = new System.Drawing.Point(3, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 85);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Label_operatorName);
            this.groupBox3.Location = new System.Drawing.Point(3, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 75);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.groupBox1);
            this.flowLayoutPanel3.Controls.Add(this.groupBox2);
            this.flowLayoutPanel3.Controls.Add(this.groupBox3);
            this.flowLayoutPanel3.Controls.Add(this.groupBox4);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(410, 35);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(285, 362);
            this.flowLayoutPanel3.TabIndex = 10;
            // 
            // Label_lotNumber
            // 
            this.Label_lotNumber.AutoSize = true;
            this.Label_lotNumber.Location = new System.Drawing.Point(32, 32);
            this.Label_lotNumber.Name = "Label_lotNumber";
            this.Label_lotNumber.Size = new System.Drawing.Size(46, 17);
            this.Label_lotNumber.TabIndex = 0;
            this.Label_lotNumber.Text = "label1";
            // 
            // Label_searialNumber
            // 
            this.Label_searialNumber.AutoSize = true;
            this.Label_searialNumber.Location = new System.Drawing.Point(32, 43);
            this.Label_searialNumber.Name = "Label_searialNumber";
            this.Label_searialNumber.Size = new System.Drawing.Size(46, 17);
            this.Label_searialNumber.TabIndex = 1;
            this.Label_searialNumber.Text = "label2";
            // 
            // Label_operatorName
            // 
            this.Label_operatorName.AutoSize = true;
            this.Label_operatorName.Location = new System.Drawing.Point(32, 36);
            this.Label_operatorName.Name = "Label_operatorName";
            this.Label_operatorName.Size = new System.Drawing.Size(46, 17);
            this.Label_operatorName.TabIndex = 2;
            this.Label_operatorName.Text = "label3";
            this.Label_operatorName.Click += new System.EventHandler(this.Label_operatorName_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Label_testType);
            this.groupBox4.Location = new System.Drawing.Point(3, 262);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(282, 85);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // Label_testType
            // 
            this.Label_testType.AutoSize = true;
            this.Label_testType.Location = new System.Drawing.Point(32, 51);
            this.Label_testType.Name = "Label_testType";
            this.Label_testType.Size = new System.Drawing.Size(46, 17);
            this.Label_testType.TabIndex = 0;
            this.Label_testType.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 549);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.btn_clearLog);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ResultTxt);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "QSFP28G FR1 resistance test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox ResultTxt;
        private System.Windows.Forms.Button btn_StartTest;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ke2400oToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keToolStripMenuItem;
        private System.Windows.Forms.Button btn_clearLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Label_lotNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Label_searialNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Label_operatorName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label Label_testType;
    }
}

