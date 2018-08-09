namespace Finisar.GPIB_Controls {
    partial class TempControl {
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
            this.label2 = new System.Windows.Forms.Label();
            this.Tset_NUD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.measureButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.gboTempControl = new System.Windows.Forms.GroupBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudGpibAddress = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gboMoreMeasure = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.powerLabel = new System.Windows.Forms.Label();
            this.voltageLabel = new System.Windows.Forms.Label();
            this.currentLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkTurnOn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Tset_NUD)).BeginInit();
            this.gboTempControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGpibAddress)).BeginInit();
            this.gboMoreMeasure.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Set";
            // 
            // Tset_NUD
            // 
            this.Tset_NUD.DecimalPlaces = 3;
            this.Tset_NUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.Tset_NUD.Location = new System.Drawing.Point(29, 49);
            this.Tset_NUD.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.Tset_NUD.Name = "Tset_NUD";
            this.Tset_NUD.Size = new System.Drawing.Size(55, 20);
            this.Tset_NUD.TabIndex = 8;
            this.Tset_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tset_NUD.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Tset_NUD.ValueChanged += new System.EventHandler(this.Tset_NUD_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "(ºC)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "(ºC)";
            // 
            // measureButton
            // 
            this.measureButton.Enabled = false;
            this.measureButton.Location = new System.Drawing.Point(143, 98);
            this.measureButton.Name = "measureButton";
            this.measureButton.Size = new System.Drawing.Size(57, 23);
            this.measureButton.TabIndex = 8;
            this.measureButton.Text = "Measure";
            this.measureButton.UseVisualStyleBackColor = true;
            this.measureButton.Click += new System.EventHandler(this.measureButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultLabel.Location = new System.Drawing.Point(73, 78);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(64, 20);
            this.resultLabel.TabIndex = 9;
            this.resultLabel.Text = "---";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gboTempControl
            // 
            this.gboTempControl.Controls.Add(this.btnInit);
            this.gboTempControl.Controls.Add(this.label3);
            this.gboTempControl.Controls.Add(this.nudGpibAddress);
            this.gboTempControl.Controls.Add(this.label1);
            this.gboTempControl.Controls.Add(this.label2);
            this.gboTempControl.Controls.Add(this.Tset_NUD);
            this.gboTempControl.Controls.Add(this.label6);
            this.gboTempControl.Controls.Add(this.label7);
            this.gboTempControl.Controls.Add(this.measureButton);
            this.gboTempControl.Controls.Add(this.resultLabel);
            this.gboTempControl.Controls.Add(this.gboMoreMeasure);
            this.gboTempControl.Controls.Add(this.chkTurnOn);
            this.gboTempControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboTempControl.Location = new System.Drawing.Point(0, 0);
            this.gboTempControl.Name = "gboTempControl";
            this.gboTempControl.Size = new System.Drawing.Size(203, 192);
            this.gboTempControl.TabIndex = 13;
            this.gboTempControl.TabStop = false;
            this.gboTempControl.Text = "Temperature";
            // 
            // btnInit
            // 
            this.btnInit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInit.Location = new System.Drawing.Point(143, 15);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(34, 23);
            this.btnInit.TabIndex = 15;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(110, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 27);
            this.label3.TabIndex = 14;
            this.label3.Text = "GPIB Address";
            // 
            // nudGpibAddress
            // 
            this.nudGpibAddress.Location = new System.Drawing.Point(154, 47);
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
            this.nudGpibAddress.TabIndex = 13;
            this.nudGpibAddress.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Temperature";
            // 
            // gboMoreMeasure
            // 
            this.gboMoreMeasure.Controls.Add(this.label5);
            this.gboMoreMeasure.Controls.Add(this.powerLabel);
            this.gboMoreMeasure.Controls.Add(this.voltageLabel);
            this.gboMoreMeasure.Controls.Add(this.currentLabel);
            this.gboMoreMeasure.Controls.Add(this.label11);
            this.gboMoreMeasure.Controls.Add(this.label9);
            this.gboMoreMeasure.Location = new System.Drawing.Point(26, 95);
            this.gboMoreMeasure.Name = "gboMoreMeasure";
            this.gboMoreMeasure.Size = new System.Drawing.Size(113, 90);
            this.gboMoreMeasure.TabIndex = 16;
            this.gboMoreMeasure.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Power";
            // 
            // powerLabel
            // 
            this.powerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.powerLabel.Location = new System.Drawing.Point(47, 11);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(64, 20);
            this.powerLabel.TabIndex = 9;
            this.powerLabel.Text = "---";
            this.powerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voltageLabel
            // 
            this.voltageLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.voltageLabel.Location = new System.Drawing.Point(47, 37);
            this.voltageLabel.Name = "voltageLabel";
            this.voltageLabel.Size = new System.Drawing.Size(64, 20);
            this.voltageLabel.TabIndex = 9;
            this.voltageLabel.Text = "---";
            this.voltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentLabel
            // 
            this.currentLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentLabel.Location = new System.Drawing.Point(47, 62);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(64, 20);
            this.currentLabel.TabIndex = 9;
            this.currentLabel.Text = "---";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Current";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Voltage";
            // 
            // chkTurnOn
            // 
            this.chkTurnOn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTurnOn.Location = new System.Drawing.Point(8, 16);
            this.chkTurnOn.Name = "chkTurnOn";
            this.chkTurnOn.Size = new System.Drawing.Size(67, 24);
            this.chkTurnOn.TabIndex = 17;
            this.chkTurnOn.Text = "TurnOn";
            this.chkTurnOn.UseVisualStyleBackColor = true;
            this.chkTurnOn.CheckedChanged += new System.EventHandler(this.chkTurnOn_CheckedChanged);
            // 
            // TempControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gboTempControl);
            this.Name = "TempControl";
            this.Size = new System.Drawing.Size(203, 192);
            ((System.ComponentModel.ISupportInitialize)(this.Tset_NUD)).EndInit();
            this.gboTempControl.ResumeLayout(false);
            this.gboTempControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGpibAddress)).EndInit();
            this.gboMoreMeasure.ResumeLayout(false);
            this.gboMoreMeasure.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Button measureButton;
        private System.Windows.Forms.Label resultLabel;
        protected System.Windows.Forms.GroupBox gboTempControl;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudGpibAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Label voltageLabel;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.GroupBox gboMoreMeasure;
        public System.Windows.Forms.CheckBox chkTurnOn;
        public System.Windows.Forms.NumericUpDown Tset_NUD;
    }
}
