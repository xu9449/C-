namespace Finisar.GPIB_Controls {
    partial class Spectrum_Control {
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
            this.btnInitSpec = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.btnSpec_Measure = new System.Windows.Forms.Button();
            this.chkMeasureAllChannels = new System.Windows.Forms.CheckBox();
            this.lblGpibAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.wavelength2DataLabel = new System.Windows.Forms.Label();
            this.txtPowerOffset = new System.Windows.Forms.TextBox();
            this.ActualPowerLabel = new System.Windows.Forms.Label();
            this.ModeOffset2DataLabel = new System.Windows.Forms.Label();
            this.PeakPowerLabel = new System.Windows.Forms.Label();
            this.ModeOffsetDataLabel = new System.Windows.Forms.Label();
            this.SMSRDataLabel = new System.Windows.Forms.Label();
            this.wavelengthDataLabel = new System.Windows.Forms.Label();
            this.SMSR2DataLabel = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox24.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitSpec
            // 
            this.btnInitSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnInitSpec.Location = new System.Drawing.Point(321, 10);
            this.btnInitSpec.Name = "btnInitSpec";
            this.btnInitSpec.Size = new System.Drawing.Size(35, 26);
            this.btnInitSpec.TabIndex = 35;
            this.btnInitSpec.Text = "Init Spectrum";
            this.btnInitSpec.UseVisualStyleBackColor = true;
            this.btnInitSpec.Click += new System.EventHandler(this.btnInitSpec_Click);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.btnSpec_Measure);
            this.groupBox24.Controls.Add(this.chkMeasureAllChannels);
            this.groupBox24.Controls.Add(this.lblGpibAddress);
            this.groupBox24.Controls.Add(this.label3);
            this.groupBox24.Controls.Add(this.btnInitSpec);
            this.groupBox24.Controls.Add(this.groupBox25);
            this.groupBox24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox24.Location = new System.Drawing.Point(0, 0);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(366, 135);
            this.groupBox24.TabIndex = 41;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Spectrum Analyzer";
            // 
            // btnSpec_Measure
            // 
            this.btnSpec_Measure.Enabled = false;
            this.btnSpec_Measure.Location = new System.Drawing.Point(242, 10);
            this.btnSpec_Measure.Name = "btnSpec_Measure";
            this.btnSpec_Measure.Size = new System.Drawing.Size(76, 26);
            this.btnSpec_Measure.TabIndex = 36;
            this.btnSpec_Measure.Text = "Measure";
            this.btnSpec_Measure.UseVisualStyleBackColor = true;
            this.btnSpec_Measure.Click += new System.EventHandler(this.btnSpec_Measure_Click);
            // 
            // chkMeasureAllChannels
            // 
            this.chkMeasureAllChannels.AutoSize = true;
            this.chkMeasureAllChannels.Checked = true;
            this.chkMeasureAllChannels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMeasureAllChannels.Location = new System.Drawing.Point(126, 15);
            this.chkMeasureAllChannels.Name = "chkMeasureAllChannels";
            this.chkMeasureAllChannels.Size = new System.Drawing.Size(119, 17);
            this.chkMeasureAllChannels.TabIndex = 40;
            this.chkMeasureAllChannels.Text = "Measure All CHs";
            this.chkMeasureAllChannels.UseVisualStyleBackColor = true;
            this.chkMeasureAllChannels.CheckedChanged += new System.EventHandler(this.chkMeasureAllChannels_CheckedChanged);
            // 
            // lblGpibAddress
            // 
            this.lblGpibAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGpibAddress.Location = new System.Drawing.Point(90, 16);
            this.lblGpibAddress.Name = "lblGpibAddress";
            this.lblGpibAddress.Size = new System.Drawing.Size(30, 15);
            this.lblGpibAddress.TabIndex = 39;
            this.lblGpibAddress.Text = "23";
            this.lblGpibAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "GPIB Address";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.wavelength2DataLabel);
            this.groupBox25.Controls.Add(this.txtPowerOffset);
            this.groupBox25.Controls.Add(this.ActualPowerLabel);
            this.groupBox25.Controls.Add(this.ModeOffset2DataLabel);
            this.groupBox25.Controls.Add(this.PeakPowerLabel);
            this.groupBox25.Controls.Add(this.ModeOffsetDataLabel);
            this.groupBox25.Controls.Add(this.SMSRDataLabel);
            this.groupBox25.Controls.Add(this.wavelengthDataLabel);
            this.groupBox25.Controls.Add(this.SMSR2DataLabel);
            this.groupBox25.Controls.Add(this.label48);
            this.groupBox25.Controls.Add(this.label50);
            this.groupBox25.Controls.Add(this.label4);
            this.groupBox25.Controls.Add(this.label2);
            this.groupBox25.Controls.Add(this.label1);
            this.groupBox25.Controls.Add(this.label43);
            this.groupBox25.Controls.Add(this.label44);
            this.groupBox25.Controls.Add(this.label46);
            this.groupBox25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox25.Location = new System.Drawing.Point(3, 34);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(359, 97);
            this.groupBox25.TabIndex = 37;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Measure Result";
            // 
            // wavelength2DataLabel
            // 
            this.wavelength2DataLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.wavelength2DataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wavelength2DataLabel.Location = new System.Drawing.Point(172, 46);
            this.wavelength2DataLabel.Name = "wavelength2DataLabel";
            this.wavelength2DataLabel.Size = new System.Drawing.Size(55, 18);
            this.wavelength2DataLabel.TabIndex = 33;
            this.wavelength2DataLabel.Text = "----";
            this.wavelength2DataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPowerOffset
            // 
            this.txtPowerOffset.Location = new System.Drawing.Point(300, 18);
            this.txtPowerOffset.Name = "txtPowerOffset";
            this.txtPowerOffset.Size = new System.Drawing.Size(55, 20);
            this.txtPowerOffset.TabIndex = 35;
            this.txtPowerOffset.Text = "2.8";
            this.txtPowerOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ActualPowerLabel
            // 
            this.ActualPowerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ActualPowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualPowerLabel.Location = new System.Drawing.Point(300, 67);
            this.ActualPowerLabel.Name = "ActualPowerLabel";
            this.ActualPowerLabel.Size = new System.Drawing.Size(55, 18);
            this.ActualPowerLabel.TabIndex = 33;
            this.ActualPowerLabel.Text = "----";
            this.ActualPowerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModeOffset2DataLabel
            // 
            this.ModeOffset2DataLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModeOffset2DataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeOffset2DataLabel.Location = new System.Drawing.Point(172, 70);
            this.ModeOffset2DataLabel.Name = "ModeOffset2DataLabel";
            this.ModeOffset2DataLabel.Size = new System.Drawing.Size(55, 18);
            this.ModeOffset2DataLabel.TabIndex = 30;
            this.ModeOffset2DataLabel.Text = "----";
            this.ModeOffset2DataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PeakPowerLabel
            // 
            this.PeakPowerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PeakPowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeakPowerLabel.Location = new System.Drawing.Point(300, 44);
            this.PeakPowerLabel.Name = "PeakPowerLabel";
            this.PeakPowerLabel.Size = new System.Drawing.Size(55, 18);
            this.PeakPowerLabel.TabIndex = 33;
            this.PeakPowerLabel.Text = "----";
            this.PeakPowerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModeOffsetDataLabel
            // 
            this.ModeOffsetDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModeOffsetDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeOffsetDataLabel.Location = new System.Drawing.Point(95, 67);
            this.ModeOffsetDataLabel.Name = "ModeOffsetDataLabel";
            this.ModeOffsetDataLabel.Size = new System.Drawing.Size(55, 18);
            this.ModeOffsetDataLabel.TabIndex = 33;
            this.ModeOffsetDataLabel.Text = "----";
            this.ModeOffsetDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SMSRDataLabel
            // 
            this.SMSRDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SMSRDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMSRDataLabel.Location = new System.Drawing.Point(95, 22);
            this.SMSRDataLabel.Name = "SMSRDataLabel";
            this.SMSRDataLabel.Size = new System.Drawing.Size(55, 18);
            this.SMSRDataLabel.TabIndex = 33;
            this.SMSRDataLabel.Text = "----";
            this.SMSRDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wavelengthDataLabel
            // 
            this.wavelengthDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.wavelengthDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wavelengthDataLabel.Location = new System.Drawing.Point(95, 44);
            this.wavelengthDataLabel.Name = "wavelengthDataLabel";
            this.wavelengthDataLabel.Size = new System.Drawing.Size(55, 18);
            this.wavelengthDataLabel.TabIndex = 30;
            this.wavelengthDataLabel.Text = "----";
            this.wavelengthDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SMSR2DataLabel
            // 
            this.SMSR2DataLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SMSR2DataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMSR2DataLabel.Location = new System.Drawing.Point(172, 22);
            this.SMSR2DataLabel.Name = "SMSR2DataLabel";
            this.SMSR2DataLabel.Size = new System.Drawing.Size(55, 18);
            this.SMSR2DataLabel.TabIndex = 30;
            this.SMSR2DataLabel.Text = "----";
            this.SMSR2DataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(151, 25);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(20, 13);
            this.label48.TabIndex = 34;
            this.label48.Text = "dB";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(151, 52);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(21, 13);
            this.label50.TabIndex = 31;
            this.label50.Text = "nm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(225, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Actual Power:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Power Offset:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "PeakPower:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(29, 70);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(68, 13);
            this.label43.TabIndex = 32;
            this.label43.Text = "Mode Offset:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(56, 24);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(41, 13);
            this.label44.TabIndex = 32;
            this.label44.Text = "SMSR:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(4, 46);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(93, 13);
            this.label46.TabIndex = 32;
            this.label46.Text = "Peak Wavelengh:";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Spectrum_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox24);
            this.Name = "Spectrum_Control";
            this.Size = new System.Drawing.Size(366, 135);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitSpec;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.Button btnSpec_Measure;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label wavelength2DataLabel;
        private System.Windows.Forms.Label ModeOffsetDataLabel;
        private System.Windows.Forms.Label SMSRDataLabel;
        private System.Windows.Forms.Label ModeOffset2DataLabel;
        private System.Windows.Forms.Label SMSR2DataLabel;
        private System.Windows.Forms.Label wavelengthDataLabel;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label lblGpibAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PeakPowerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPowerOffset;
        private System.Windows.Forms.Label ActualPowerLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox chkMeasureAllChannels;
    }
}
