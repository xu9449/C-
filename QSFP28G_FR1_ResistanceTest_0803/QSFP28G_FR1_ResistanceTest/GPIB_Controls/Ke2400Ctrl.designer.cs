namespace Finisar.GPIB_Controls {
    partial class Ke2400Ctrl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
      this.gboKeithleyCtrl = new System.Windows.Forms.GroupBox();
      this.chkMeasureVoltage = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnRamp = new System.Windows.Forms.Button();
      this.nudTargetPoint = new System.Windows.Forms.NumericUpDown();
      this.lblReading = new System.Windows.Forms.Label();
      this.nudSetpoint = new System.Windows.Forms.NumericUpDown();
      this.btnRead = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.chkTurnOn = new System.Windows.Forms.CheckBox();
      this.btnInit = new System.Windows.Forms.Button();
      this.chkVoltageCtrl = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.chkFrontMeasure = new System.Windows.Forms.CheckBox();
      this.nudGpibAddress = new System.Windows.Forms.NumericUpDown();
      this.nudComplianceSetpoint = new System.Windows.Forms.NumericUpDown();
      this.gboKeithleyCtrl.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTargetPoint)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetpoint)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGpibAddress)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudComplianceSetpoint)).BeginInit();
      this.SuspendLayout();
      // 
      // gboKeithleyCtrl
      // 
      this.gboKeithleyCtrl.Controls.Add(this.chkMeasureVoltage);
      this.gboKeithleyCtrl.Controls.Add(this.label2);
      this.gboKeithleyCtrl.Controls.Add(this.groupBox1);
      this.gboKeithleyCtrl.Controls.Add(this.chkTurnOn);
      this.gboKeithleyCtrl.Controls.Add(this.btnInit);
      this.gboKeithleyCtrl.Controls.Add(this.chkVoltageCtrl);
      this.gboKeithleyCtrl.Controls.Add(this.label3);
      this.gboKeithleyCtrl.Controls.Add(this.chkFrontMeasure);
      this.gboKeithleyCtrl.Controls.Add(this.nudGpibAddress);
      this.gboKeithleyCtrl.Controls.Add(this.nudComplianceSetpoint);
      this.gboKeithleyCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gboKeithleyCtrl.Location = new System.Drawing.Point(0, 0);
      this.gboKeithleyCtrl.Name = "gboKeithleyCtrl";
      this.gboKeithleyCtrl.Size = new System.Drawing.Size(240, 178);
      this.gboKeithleyCtrl.TabIndex = 0;
      this.gboKeithleyCtrl.TabStop = false;
      this.gboKeithleyCtrl.Text = "Keithley Control";
      // 
      // chkMeasureVoltage
      // 
      this.chkMeasureVoltage.AutoSize = true;
      this.chkMeasureVoltage.Location = new System.Drawing.Point(10, 57);
      this.chkMeasureVoltage.Name = "chkMeasureVoltage";
      this.chkMeasureVoltage.Size = new System.Drawing.Size(103, 17);
      this.chkMeasureVoltage.TabIndex = 7;
      this.chkMeasureVoltage.Text = "MeasureVoltage";
      this.chkMeasureVoltage.UseVisualStyleBackColor = true;
      this.chkMeasureVoltage.CheckedChanged += new System.EventHandler(this.chkMeasureVoltage_CheckedChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(115, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(75, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Compliance(V)";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnRamp);
      this.groupBox1.Controls.Add(this.nudTargetPoint);
      this.groupBox1.Controls.Add(this.lblReading);
      this.groupBox1.Controls.Add(this.nudSetpoint);
      this.groupBox1.Controls.Add(this.btnRead);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(6, 77);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(227, 94);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      // 
      // btnRamp
      // 
      this.btnRamp.Location = new System.Drawing.Point(119, 67);
      this.btnRamp.Name = "btnRamp";
      this.btnRamp.Size = new System.Drawing.Size(75, 23);
      this.btnRamp.TabIndex = 6;
      this.btnRamp.Text = "Ramp";
      this.btnRamp.UseVisualStyleBackColor = true;
      this.btnRamp.Click += new System.EventHandler(this.btnRamp_Click);
      // 
      // nudTargetPoint
      // 
      this.nudTargetPoint.DecimalPlaces = 2;
      this.nudTargetPoint.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudTargetPoint.Location = new System.Drawing.Point(66, 69);
      this.nudTargetPoint.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudTargetPoint.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
      this.nudTargetPoint.Name = "nudTargetPoint";
      this.nudTargetPoint.Size = new System.Drawing.Size(47, 20);
      this.nudTargetPoint.TabIndex = 5;
      // 
      // lblReading
      // 
      this.lblReading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblReading.Location = new System.Drawing.Point(118, 16);
      this.lblReading.Name = "lblReading";
      this.lblReading.Size = new System.Drawing.Size(51, 19);
      this.lblReading.TabIndex = 2;
      // 
      // nudSetpoint
      // 
      this.nudSetpoint.DecimalPlaces = 2;
      this.nudSetpoint.Location = new System.Drawing.Point(57, 14);
      this.nudSetpoint.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
      this.nudSetpoint.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this.nudSetpoint.Name = "nudSetpoint";
      this.nudSetpoint.Size = new System.Drawing.Size(56, 20);
      this.nudSetpoint.TabIndex = 1;
      this.nudSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.nudSetpoint.Value = new decimal(new int[] {
            55,
            0,
            0,
            0});
      this.nudSetpoint.ValueChanged += new System.EventHandler(this.nudSetpoint_ValueChanged);
      // 
      // btnRead
      // 
      this.btnRead.Enabled = false;
      this.btnRead.Location = new System.Drawing.Point(171, 14);
      this.btnRead.Name = "btnRead";
      this.btnRead.Size = new System.Drawing.Size(56, 23);
      this.btnRead.TabIndex = 4;
      this.btnRead.Text = "Measure";
      this.btnRead.UseVisualStyleBackColor = true;
      this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(22, 72);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(38, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "Target";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(4, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Set Point";
      // 
      // chkTurnOn
      // 
      this.chkTurnOn.AutoSize = true;
      this.chkTurnOn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkTurnOn.Location = new System.Drawing.Point(10, 13);
      this.chkTurnOn.Name = "chkTurnOn";
      this.chkTurnOn.Size = new System.Drawing.Size(66, 18);
      this.chkTurnOn.TabIndex = 5;
      this.chkTurnOn.Text = "TurnOn";
      this.chkTurnOn.UseVisualStyleBackColor = true;
      this.chkTurnOn.CheckedChanged += new System.EventHandler(this.chkTurnOn_CheckedChanged);
      // 
      // btnInit
      // 
      this.btnInit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnInit.Location = new System.Drawing.Point(183, 8);
      this.btnInit.Name = "btnInit";
      this.btnInit.Size = new System.Drawing.Size(52, 23);
      this.btnInit.TabIndex = 4;
      this.btnInit.Text = "Init";
      this.btnInit.UseVisualStyleBackColor = true;
      this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
      // 
      // chkVoltageCtrl
      // 
      this.chkVoltageCtrl.Location = new System.Drawing.Point(10, 36);
      this.chkVoltageCtrl.Name = "chkVoltageCtrl";
      this.chkVoltageCtrl.Size = new System.Drawing.Size(69, 15);
      this.chkVoltageCtrl.TabIndex = 3;
      this.chkVoltageCtrl.Text = "V Control";
      this.chkVoltageCtrl.UseVisualStyleBackColor = true;
      this.chkVoltageCtrl.CheckedChanged += new System.EventHandler(this.chkVoltageCtrl_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(117, 36);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(73, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "GPIB Address";
      // 
      // chkFrontMeasure
      // 
      this.chkFrontMeasure.AutoSize = true;
      this.chkFrontMeasure.Checked = true;
      this.chkFrontMeasure.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkFrontMeasure.Location = new System.Drawing.Point(83, 14);
      this.chkFrontMeasure.Name = "chkFrontMeasure";
      this.chkFrontMeasure.Size = new System.Drawing.Size(94, 17);
      this.chkFrontMeasure.TabIndex = 3;
      this.chkFrontMeasure.Text = "Front Measure";
      this.chkFrontMeasure.UseVisualStyleBackColor = true;
      this.chkFrontMeasure.CheckedChanged += new System.EventHandler(this.chkFrontMeasure_CheckedChanged);
      // 
      // nudGpibAddress
      // 
      this.nudGpibAddress.Location = new System.Drawing.Point(193, 33);
      this.nudGpibAddress.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.nudGpibAddress.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudGpibAddress.Name = "nudGpibAddress";
      this.nudGpibAddress.Size = new System.Drawing.Size(39, 20);
      this.nudGpibAddress.TabIndex = 1;
      this.nudGpibAddress.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
      this.nudGpibAddress.ValueChanged += new System.EventHandler(this.nudGpibAddress_ValueChanged);
      // 
      // nudComplianceSetpoint
      // 
      this.nudComplianceSetpoint.DecimalPlaces = 1;
      this.nudComplianceSetpoint.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudComplianceSetpoint.Location = new System.Drawing.Point(193, 57);
      this.nudComplianceSetpoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.nudComplianceSetpoint.Name = "nudComplianceSetpoint";
      this.nudComplianceSetpoint.Size = new System.Drawing.Size(39, 20);
      this.nudComplianceSetpoint.TabIndex = 1;
      this.nudComplianceSetpoint.Value = new decimal(new int[] {
            35,
            0,
            0,
            65536});
      this.nudComplianceSetpoint.ValueChanged += new System.EventHandler(this.nudComplianceSetpoint_ValueChanged);
      // 
      // Ke2400Ctrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.gboKeithleyCtrl);
      this.Name = "Ke2400Ctrl";
      this.Size = new System.Drawing.Size(240, 178);
      this.gboKeithleyCtrl.ResumeLayout(false);
      this.gboKeithleyCtrl.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTargetPoint)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetpoint)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGpibAddress)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudComplianceSetpoint)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboKeithleyCtrl;
        private System.Windows.Forms.Label lblReading;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox chkTurnOn;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnInit;
        public System.Windows.Forms.CheckBox chkFrontMeasure;
        private System.Windows.Forms.CheckBox chkVoltageCtrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudGpibAddress;
        private System.Windows.Forms.NumericUpDown nudComplianceSetpoint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRamp;
        private System.Windows.Forms.NumericUpDown nudTargetPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkMeasureVoltage;
        public System.Windows.Forms.NumericUpDown nudSetpoint;
    }
}
