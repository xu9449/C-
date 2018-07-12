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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Ke7001GpibAddress = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Ke7001SlotNo = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Ke7001ChannelNo = new System.Windows.Forms.NumericUpDown();
            this.label_Status = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_7001Init = new System.Windows.Forms.Button();
            this.button_7001ChannelOn = new System.Windows.Forms.Button();
            this.button_7001ChannelOff = new System.Windows.Forms.Button();
            this.button7002_Scan = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001GpibAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001SlotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001ChannelNo)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(557, 255);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AllowDrop = true;
            this.flowLayoutPanel2.Controls.Add(this.textBox1);
            this.flowLayoutPanel2.Controls.Add(this.Ke7001GpibAddress);
            this.flowLayoutPanel2.Controls.Add(this.textBox2);
            this.flowLayoutPanel2.Controls.Add(this.Ke7001SlotNo);
            this.flowLayoutPanel2.Controls.Add(this.textBox3);
            this.flowLayoutPanel2.Controls.Add(this.Ke7001ChannelNo);
            this.flowLayoutPanel2.Controls.Add(this.label_Status);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(134, 252);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 15);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "GPIB Address";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Ke7001GpibAddress
            // 
            this.Ke7001GpibAddress.Location = new System.Drawing.Point(3, 24);
            this.Ke7001GpibAddress.Name = "Ke7001GpibAddress";
            this.Ke7001GpibAddress.Size = new System.Drawing.Size(131, 22);
            this.Ke7001GpibAddress.TabIndex = 3;
            this.Ke7001GpibAddress.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(3, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(119, 15);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Slot Number";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Ke7001SlotNo
            // 
            this.Ke7001SlotNo.Location = new System.Drawing.Point(3, 73);
            this.Ke7001SlotNo.Name = "Ke7001SlotNo";
            this.Ke7001SlotNo.Size = new System.Drawing.Size(131, 22);
            this.Ke7001SlotNo.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(3, 101);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(119, 15);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "Channel No";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Ke7001ChannelNo
            // 
            this.Ke7001ChannelNo.Location = new System.Drawing.Point(3, 122);
            this.Ke7001ChannelNo.Name = "Ke7001ChannelNo";
            this.Ke7001ChannelNo.Size = new System.Drawing.Size(131, 22);
            this.Ke7001ChannelNo.TabIndex = 2;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(3, 147);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(46, 17);
            this.label_Status.TabIndex = 7;
            this.label_Status.Text = "label1";
            this.label_Status.Click += new System.EventHandler(this.label_Status_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.button_7001Init);
            this.flowLayoutPanel3.Controls.Add(this.button_7001ChannelOn);
            this.flowLayoutPanel3.Controls.Add(this.button_7001ChannelOff);
            this.flowLayoutPanel3.Controls.Add(this.button7002_Scan);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(143, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(172, 252);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // button_7001Init
            // 
            this.button_7001Init.Location = new System.Drawing.Point(3, 3);
            this.button_7001Init.Name = "button_7001Init";
            this.button_7001Init.Size = new System.Drawing.Size(165, 23);
            this.button_7001Init.TabIndex = 1;
            this.button_7001Init.Text = "Init/Reset";
            this.button_7001Init.UseVisualStyleBackColor = true;
            this.button_7001Init.Click += new System.EventHandler(this.button_7001Init_Click);
            // 
            // button_7001ChannelOn
            // 
            this.button_7001ChannelOn.Location = new System.Drawing.Point(3, 32);
            this.button_7001ChannelOn.Name = "button_7001ChannelOn";
            this.button_7001ChannelOn.Size = new System.Drawing.Size(165, 23);
            this.button_7001ChannelOn.TabIndex = 2;
            this.button_7001ChannelOn.Text = "ChannelOn";
            this.button_7001ChannelOn.UseVisualStyleBackColor = true;
            this.button_7001ChannelOn.Click += new System.EventHandler(this.button_7001ChannelOn_Click);
            // 
            // button_7001ChannelOff
            // 
            this.button_7001ChannelOff.Location = new System.Drawing.Point(3, 61);
            this.button_7001ChannelOff.Name = "button_7001ChannelOff";
            this.button_7001ChannelOff.Size = new System.Drawing.Size(165, 23);
            this.button_7001ChannelOff.TabIndex = 3;
            this.button_7001ChannelOff.Text = "ChannelOff";
            this.button_7001ChannelOff.UseVisualStyleBackColor = true;
            this.button_7001ChannelOff.Click += new System.EventHandler(this.button_7001ChannelOff_Click);
            // 
            // button7002_Scan
            // 
            this.button7002_Scan.Location = new System.Drawing.Point(3, 90);
            this.button7002_Scan.Name = "button7002_Scan";
            this.button7002_Scan.Size = new System.Drawing.Size(165, 162);
            this.button7002_Scan.TabIndex = 4;
            this.button7002_Scan.Text = "Test1";
            this.button7002_Scan.UseVisualStyleBackColor = true;
            this.button7002_Scan.Click += new System.EventHandler(this.button7002_Scan_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.richTextBox_Log);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(321, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(224, 252);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.Size = new System.Drawing.Size(221, 249);
            this.richTextBox_Log.TabIndex = 0;
            this.richTextBox_Log.Text = "";
            this.richTextBox_Log.TextChanged += new System.EventHandler(this.richTextBox_Log_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 255);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "7001 SWITCH SYSTEM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001GpibAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001SlotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001ChannelNo)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.NumericUpDown Ke7001ChannelNo;
        private System.Windows.Forms.NumericUpDown Ke7001SlotNo;
        private System.Windows.Forms.NumericUpDown Ke7001GpibAddress;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button_7001Init;
        private System.Windows.Forms.Button button_7001ChannelOff;
        private System.Windows.Forms.Button button_7001ChannelOn;
        private System.Windows.Forms.Button button7002_Scan;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.Button button1;
    }
}

