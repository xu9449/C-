namespace myProject2_7001
{
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
            this.gboKeithleyCtrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboKeithleyCtrl.Name = "gboKeithleyCtrl";
            this.gboKeithleyCtrl.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboKeithleyCtrl.Size = new System.Drawing.Size(320, 219);
            this.gboKeithleyCtrl.TabIndex = 0;
            this.gboKeithleyCtrl.TabStop = false;
            this.gboKeithleyCtrl.Text = "Keithley Control";
            this.gboKeithleyCtrl.Enter += new System.EventHandler(this.gboKeithleyCtrl_Enter);
            // 
            // chkMeasureVoltage
            // 
            this.chkMeasureVoltage.AutoSize = true;
            this.chkMeasureVoltage.Location = new System.Drawing.Point(13, 70);
            this.chkMeasureVoltage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMeasureVoltage.Name = "chkMeasureVoltage";
            this.chkMeasureVoltage.Size = new System.Drawing.Size(133, 21);
            this.chkMeasureVoltage.TabIndex = 7;
            this.chkMeasureVoltage.Text = "MeasureVoltage";
            this.chkMeasureVoltage.UseVisualStyleBackColor = true;
            this.chkMeasureVoltage.CheckedChanged += new System.EventHandler(this.chkMeasureVoltage_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(303, 116);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnRamp
            // 
            this.btnRamp.Location = new System.Drawing.Point(159, 82);
            this.btnRamp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRamp.Name = "btnRamp";
            this.btnRamp.Size = new System.Drawing.Size(100, 28);
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
            this.nudTargetPoint.Location = new System.Drawing.Point(88, 85);
            this.nudTargetPoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nudTargetPoint.Size = new System.Drawing.Size(63, 22);
            this.nudTargetPoint.TabIndex = 5;
            // 
            // lblReading
            // 
            this.lblReading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReading.Location = new System.Drawing.Point(157, 20);
            this.lblReading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new System.Drawing.Size(68, 23);
            this.lblReading.TabIndex = 2;
            // 
            // nudSetpoint
            // 
            this.nudSetpoint.DecimalPlaces = 2;
            this.nudSetpoint.Location = new System.Drawing.Point(76, 17);
            this.nudSetpoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nudSetpoint.Size = new System.Drawing.Size(75, 22);
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
            this.btnRead.Location = new System.Drawing.Point(228, 17);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 28);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "Measure";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Target";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set Point";
            // 
            // chkTurnOn
            // 
            this.chkTurnOn.AutoSize = true;
            this.chkTurnOn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTurnOn.Location = new System.Drawing.Point(13, 16);
            this.chkTurnOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTurnOn.Name = "chkTurnOn";
            this.chkTurnOn.Size = new System.Drawing.Size(81, 20);
            this.chkTurnOn.TabIndex = 5;
            this.chkTurnOn.Text = "TurnOn";
            this.chkTurnOn.UseVisualStyleBackColor = true;
            this.chkTurnOn.CheckedChanged += new System.EventHandler(this.chkTurnOn_CheckedChanged);
            // 
            // btnInit
            // 
            this.btnInit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInit.Location = new System.Drawing.Point(244, 10);
            this.btnInit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(69, 28);
            this.btnInit.TabIndex = 4;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // chkVoltageCtrl
            // 
            this.chkVoltageCtrl.Location = new System.Drawing.Point(13, 44);
            this.chkVoltageCtrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkVoltageCtrl.Name = "chkVoltageCtrl";
            this.chkVoltageCtrl.Size = new System.Drawing.Size(92, 18);
            this.chkVoltageCtrl.TabIndex = 3;
            this.chkVoltageCtrl.Text = "V Control";
            this.chkVoltageCtrl.UseVisualStyleBackColor = true;
            this.chkVoltageCtrl.CheckedChanged += new System.EventHandler(this.chkVoltageCtrl_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "GPIB Address";
            // 
            // chkFrontMeasure
            // 
            this.chkFrontMeasure.AutoSize = true;
            this.chkFrontMeasure.Checked = true;
            this.chkFrontMeasure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFrontMeasure.Location = new System.Drawing.Point(111, 17);
            this.chkFrontMeasure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFrontMeasure.Name = "chkFrontMeasure";
            this.chkFrontMeasure.Size = new System.Drawing.Size(122, 21);
            this.chkFrontMeasure.TabIndex = 3;
            this.chkFrontMeasure.Text = "Front Measure";
            this.chkFrontMeasure.UseVisualStyleBackColor = true;
            this.chkFrontMeasure.CheckedChanged += new System.EventHandler(this.chkFrontMeasure_CheckedChanged);
            // 
            // nudGpibAddress
            // 
            this.nudGpibAddress.Location = new System.Drawing.Point(257, 41);
            this.nudGpibAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nudGpibAddress.Size = new System.Drawing.Size(52, 22);
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
            this.nudComplianceSetpoint.Location = new System.Drawing.Point(257, 70);
            this.nudComplianceSetpoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudComplianceSetpoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudComplianceSetpoint.Name = "nudComplianceSetpoint";
            this.nudComplianceSetpoint.Size = new System.Drawing.Size(52, 22);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gboKeithleyCtrl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ke2400Ctrl";
            this.Size = new System.Drawing.Size(320, 219);
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
