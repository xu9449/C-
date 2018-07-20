namespace myProject2_7001
{
    partial class Ke7001Ctrl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
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
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001SlotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001ChannelNo)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Controls.Add(this.flowLayoutPanel3);
            this.groupBox1.Controls.Add(this.flowLayoutPanel5);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 282);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ke7001";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AllowDrop = true;
            this.flowLayoutPanel2.Controls.Add(this.textBox2);
            this.flowLayoutPanel2.Controls.Add(this.Ke7001SlotNo);
            this.flowLayoutPanel2.Controls.Add(this.textBox3);
            this.flowLayoutPanel2.Controls.Add(this.Ke7001ChannelNo);
            this.flowLayoutPanel2.Controls.Add(this.label_Status);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(20, 21);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(159, 260);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(119, 15);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Slot Number";
            // 
            // Ke7001SlotNo
            // 
            this.Ke7001SlotNo.Location = new System.Drawing.Point(3, 24);
            this.Ke7001SlotNo.Name = "Ke7001SlotNo";
            this.Ke7001SlotNo.Size = new System.Drawing.Size(131, 22);
            this.Ke7001SlotNo.TabIndex = 3;
            this.Ke7001SlotNo.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.Ke7001SlotNo.ValueChanged += new System.EventHandler(this.Ke7001SlotNo_ValueChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(3, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(119, 15);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "Channel No";
            // 
            // Ke7001ChannelNo
            // 
            this.Ke7001ChannelNo.Location = new System.Drawing.Point(3, 73);
            this.Ke7001ChannelNo.Name = "Ke7001ChannelNo";
            this.Ke7001ChannelNo.Size = new System.Drawing.Size(131, 22);
            this.Ke7001ChannelNo.TabIndex = 2;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(3, 98);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(46, 17);
            this.label_Status.TabIndex = 7;
            this.label_Status.Text = "label1";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.button_7001Init);
            this.flowLayoutPanel3.Controls.Add(this.button_7001ChannelOn);
            this.flowLayoutPanel3.Controls.Add(this.button_7001ChannelOff);
            this.flowLayoutPanel3.Controls.Add(this.button7002_Scan);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(185, 21);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(174, 268);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // button_7001Init
            // 
            this.button_7001Init.Location = new System.Drawing.Point(3, 3);
            this.button_7001Init.Name = "button_7001Init";
            this.button_7001Init.Size = new System.Drawing.Size(165, 52);
            this.button_7001Init.TabIndex = 1;
            this.button_7001Init.Text = "Init/Reset";
            this.button_7001Init.UseVisualStyleBackColor = true;
            this.button_7001Init.Click += new System.EventHandler(this.button_7001Init_Click);
            // 
            // button_7001ChannelOn
            // 
            this.button_7001ChannelOn.Location = new System.Drawing.Point(3, 61);
            this.button_7001ChannelOn.Name = "button_7001ChannelOn";
            this.button_7001ChannelOn.Size = new System.Drawing.Size(165, 54);
            this.button_7001ChannelOn.TabIndex = 2;
            this.button_7001ChannelOn.Text = "ChannelOn";
            this.button_7001ChannelOn.UseVisualStyleBackColor = true;
            this.button_7001ChannelOn.Click += new System.EventHandler(this.button_7001ChannelOn_Click_1);
            // 
            // button_7001ChannelOff
            // 
            this.button_7001ChannelOff.Location = new System.Drawing.Point(3, 121);
            this.button_7001ChannelOff.Name = "button_7001ChannelOff";
            this.button_7001ChannelOff.Size = new System.Drawing.Size(165, 59);
            this.button_7001ChannelOff.TabIndex = 3;
            this.button_7001ChannelOff.Text = "ChannelOff";
            this.button_7001ChannelOff.UseVisualStyleBackColor = true;
            this.button_7001ChannelOff.Click += new System.EventHandler(this.button_7001ChannelOff_Click_1);
            // 
            // button7002_Scan
            // 
            this.button7002_Scan.Location = new System.Drawing.Point(3, 186);
            this.button7002_Scan.Name = "button7002_Scan";
            this.button7002_Scan.Size = new System.Drawing.Size(165, 74);
            this.button7002_Scan.TabIndex = 4;
            this.button7002_Scan.Text = "Test1";
            this.button7002_Scan.UseVisualStyleBackColor = true;
            this.button7002_Scan.Click += new System.EventHandler(this.button7002_Scan_Click_1);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Location = new System.Drawing.Point(401, 13);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(291, 526);
            this.flowLayoutPanel5.TabIndex = 3;
            // 
            // Ke7001Ctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 322);
            this.Controls.Add(this.groupBox1);
            this.Name = "Ke7001Ctrl";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001SlotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ke7001ChannelNo)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown Ke7001SlotNo;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.NumericUpDown Ke7001ChannelNo;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button button_7001Init;
        private System.Windows.Forms.Button button_7001ChannelOn;
        private System.Windows.Forms.Button button_7001ChannelOff;
        private System.Windows.Forms.Button button7002_Scan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
    }
}