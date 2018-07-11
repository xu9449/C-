using System;

namespace Drivers
{
    partial class Ke2602Ctrl
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
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkVoltageCtrl = new System.Windows.Forms.CheckBox();
            this.nudSetpoint = new System.Windows.Forms.NumericUpDown();
            this.chkMeasureVoltage = new System.Windows.Forms.CheckBox();
            this.btnRamp = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.nudComplianceSetpoint = new System.Windows.Forms.NumericUpDown();
            this.autoRBox1 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRead = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnResA = new System.Windows.Forms.Button();
            this.btnResB = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDiscon = new System.Windows.Forms.Button();
            this.nudGpibAddress = new System.Windows.Forms.NumericUpDown();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetpoint)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComplianceSetpoint)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGpibAddress)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.chkVoltageCtrl);
            this.flowLayoutPanel5.Controls.Add(this.nudSetpoint);
            this.flowLayoutPanel5.Controls.Add(this.chkMeasureVoltage);
            this.flowLayoutPanel5.Controls.Add(this.btnRamp);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 324);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(392, 110);
            this.flowLayoutPanel5.TabIndex = 6;
            // 
            // chkVoltageCtrl
            // 
            this.chkVoltageCtrl.AutoSize = true;
            this.chkVoltageCtrl.Location = new System.Drawing.Point(3, 3);
            this.chkVoltageCtrl.Name = "chkVoltageCtrl";
            this.chkVoltageCtrl.Size = new System.Drawing.Size(123, 21);
            this.chkVoltageCtrl.TabIndex = 0;
            this.chkVoltageCtrl.Text = "VoltageControl";
            this.chkVoltageCtrl.UseVisualStyleBackColor = true;
            this.chkVoltageCtrl.CheckedChanged += new System.EventHandler(this.chkVoltageCtrl_CheckedChanged_1);
            // 
            // nudSetpoint
            // 
            this.nudSetpoint.Location = new System.Drawing.Point(132, 3);
            this.nudSetpoint.Name = "nudSetpoint";
            this.nudSetpoint.Size = new System.Drawing.Size(123, 22);
            this.nudSetpoint.TabIndex = 2;
            // 
            // chkMeasureVoltage
            // 
            this.chkMeasureVoltage.AutoSize = true;
            this.chkMeasureVoltage.Location = new System.Drawing.Point(3, 31);
            this.chkMeasureVoltage.Name = "chkMeasureVoltage";
            this.chkMeasureVoltage.Size = new System.Drawing.Size(164, 21);
            this.chkMeasureVoltage.TabIndex = 1;
            this.chkMeasureVoltage.Text = "VoltageMeasurement";
            this.chkMeasureVoltage.UseVisualStyleBackColor = true;
            // 
            // btnRamp
            // 
            this.btnRamp.Location = new System.Drawing.Point(173, 31);
            this.btnRamp.Name = "btnRamp";
            this.btnRamp.Size = new System.Drawing.Size(75, 23);
            this.btnRamp.TabIndex = 3;
            this.btnRamp.Text = "Ramp";
            this.btnRamp.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.nudComplianceSetpoint);
            this.flowLayoutPanel4.Controls.Add(this.autoRBox1);
            this.flowLayoutPanel4.Controls.Add(this.btnDiscon);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(401, 90);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(191, 228);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Compliance:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // nudComplianceSetpoint
            // 
            this.nudComplianceSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nudComplianceSetpoint.Location = new System.Drawing.Point(3, 32);
            this.nudComplianceSetpoint.Name = "nudComplianceSetpoint";
            this.nudComplianceSetpoint.Size = new System.Drawing.Size(188, 22);
            this.nudComplianceSetpoint.TabIndex = 3;
            this.nudComplianceSetpoint.ValueChanged += new System.EventHandler(this.nudComplianceSetpoint_ValueChanged);
            // 
            // autoRBox1
            // 
            this.autoRBox1.AutoSize = true;
            this.autoRBox1.Location = new System.Drawing.Point(3, 60);
            this.autoRBox1.Name = "autoRBox1";
            this.autoRBox1.Size = new System.Drawing.Size(101, 21);
            this.autoRBox1.TabIndex = 4;
            this.autoRBox1.Text = "AutoRange";
            this.autoRBox1.UseVisualStyleBackColor = true;
            this.autoRBox1.CheckedChanged += new System.EventHandler(this.autoRBox1_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnRead);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(401, 324);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(191, 110);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(3, 3);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(188, 107);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Measure";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnInit);
            this.flowLayoutPanel2.Controls.Add(this.btnResA);
            this.flowLayoutPanel2.Controls.Add(this.btnResB);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(401, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(191, 81);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(3, 3);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(179, 33);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnResA
            // 
            this.btnResA.Location = new System.Drawing.Point(3, 42);
            this.btnResA.Name = "btnResA";
            this.btnResA.Size = new System.Drawing.Size(80, 31);
            this.btnResA.TabIndex = 1;
            this.btnResA.Text = "ResetA";
            this.btnResA.UseVisualStyleBackColor = true;
            // 
            // btnResB
            // 
            this.btnResB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResB.Location = new System.Drawing.Point(89, 42);
            this.btnResB.Name = "btnResB";
            this.btnResB.Size = new System.Drawing.Size(76, 31);
            this.btnResB.TabIndex = 3;
            this.btnResB.TabStop = false;
            this.btnResB.Text = "ResetB";
            this.btnResB.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textBox3);
            this.flowLayoutPanel1.Controls.Add(this.nudGpibAddress);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(392, 81);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnDiscon
            // 
            this.btnDiscon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDiscon.Location = new System.Drawing.Point(3, 87);
            this.btnDiscon.Name = "btnDiscon";
            this.btnDiscon.Size = new System.Drawing.Size(188, 141);
            this.btnDiscon.TabIndex = 2;
            this.btnDiscon.Text = "Disconnect";
            this.btnDiscon.UseVisualStyleBackColor = true;
            this.btnDiscon.Click += new System.EventHandler(this.btnDiscon_Click);
            // 
            // nudGpibAddress
            // 
            this.nudGpibAddress.Location = new System.Drawing.Point(69, 3);
            this.nudGpibAddress.Name = "nudGpibAddress";
            this.nudGpibAddress.Size = new System.Drawing.Size(63, 22);
            this.nudGpibAddress.TabIndex = 3;
            this.nudGpibAddress.Value = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.nudGpibAddress.ValueChanged += new System.EventHandler(this.nudGpibAddress_ValueChanged);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(19, 48);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(64, 31);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "ChanA";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.92308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.07692F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel6, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.10843F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.89156F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.textBox1);
            this.flowLayoutPanel6.Controls.Add(this.comboBox1);
            this.flowLayoutPanel6.Controls.Add(this.groupBox1);
            this.flowLayoutPanel6.Controls.Add(this.comboBox2);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 90);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(392, 228);
            this.flowLayoutPanel6.TabIndex = 7;
            this.flowLayoutPanel6.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel6_Paint);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.MintCream;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 114);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.disconnectButton);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(130, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(102, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(63, 15);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "ON/OFF";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "OUTPUT";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(41, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(197, 21);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "                                          ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "ChanB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(200, 21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(17, 16);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(3, 229);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(3, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(60, 15);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "GPIB";
            // 
            // Ke2602Ctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 437);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Ke2602Ctrl";
            this.Text = "                ";
            this.Load += new System.EventHandler(this.Ke2602Ctrl_Load);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetpoint)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComplianceSetpoint)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGpibAddress)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void autoRBox1_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.CheckBox chkVoltageCtrl;
        private System.Windows.Forms.CheckBox chkMeasureVoltage;
        private System.Windows.Forms.NumericUpDown nudSetpoint;
        private System.Windows.Forms.Button btnRamp;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.NumericUpDown nudComplianceSetpoint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button btnDiscon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnResB;
        private System.Windows.Forms.Button btnResA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox autoRBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown nudGpibAddress;
        private System.Windows.Forms.TextBox textBox3;
    }
}