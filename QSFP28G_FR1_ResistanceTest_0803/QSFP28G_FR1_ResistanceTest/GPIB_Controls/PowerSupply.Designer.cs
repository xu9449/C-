namespace Finisar.GPIB_Controls {
    partial class PowerSupply {
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
            this.nudSetOutput2 = new System.Windows.Forms.NumericUpDown( );
            this.nudSetOutput1 = new System.Windows.Forms.NumericUpDown( );
            this.btnPowerOff = new System.Windows.Forms.Button( );
            this.btnPowerOn = new System.Windows.Forms.Button( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.lblResult2 = new System.Windows.Forms.Label( );
            this.lblResult1 = new System.Windows.Forms.Label( );
            this.nudGpibAddress = new System.Windows.Forms.NumericUpDown( );
            this.label2 = new System.Windows.Forms.Label( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.btnInit = new System.Windows.Forms.Button( );
            this.chkVoltageCtrl = new System.Windows.Forms.CheckBox( );
            this.btnMeasure = new System.Windows.Forms.Button( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudSetOutput2 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudSetOutput1 ) ).BeginInit( );
            this.groupBox2.SuspendLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudGpibAddress ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // nudSetOutput2
            // 
            this.nudSetOutput2.DecimalPlaces = 2;
            this.nudSetOutput2.Font = new System.Drawing.Font( "Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.nudSetOutput2.Increment = new decimal( new int[ ] {
            1,
            0,
            0,
            65536} );
            this.nudSetOutput2.Location = new System.Drawing.Point( 77, 54 );
            this.nudSetOutput2.Maximum = new decimal( new int[ ] {
            6,
            0,
            0,
            0} );
            this.nudSetOutput2.Name = "nudSetOutput2";
            this.nudSetOutput2.Size = new System.Drawing.Size( 47, 21 );
            this.nudSetOutput2.TabIndex = 56;
            this.nudSetOutput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetOutput2.Value = new decimal( new int[ ] {
            34,
            0,
            0,
            65536} );
            this.nudSetOutput2.ValueChanged += new System.EventHandler( this.nudSetOutput2_ValueChanged );
            // 
            // nudSetOutput1
            // 
            this.nudSetOutput1.DecimalPlaces = 2;
            this.nudSetOutput1.Font = new System.Drawing.Font( "Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.nudSetOutput1.Increment = new decimal( new int[ ] {
            1,
            0,
            0,
            65536} );
            this.nudSetOutput1.Location = new System.Drawing.Point( 9, 54 );
            this.nudSetOutput1.Maximum = new decimal( new int[ ] {
            6,
            0,
            0,
            0} );
            this.nudSetOutput1.Name = "nudSetOutput1";
            this.nudSetOutput1.Size = new System.Drawing.Size( 47, 21 );
            this.nudSetOutput1.TabIndex = 56;
            this.nudSetOutput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetOutput1.Value = new decimal( new int[ ] {
            27,
            0,
            0,
            65536} );
            this.nudSetOutput1.ValueChanged += new System.EventHandler( this.nudSetOutput1_ValueChanged );
            // 
            // btnPowerOff
            // 
            this.btnPowerOff.Enabled = false;
            this.btnPowerOff.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.btnPowerOff.Location = new System.Drawing.Point( 159, 95 );
            this.btnPowerOff.Name = "btnPowerOff";
            this.btnPowerOff.Size = new System.Drawing.Size( 44, 27 );
            this.btnPowerOff.TabIndex = 2;
            this.btnPowerOff.Text = "OFF";
            this.btnPowerOff.UseVisualStyleBackColor = true;
            this.btnPowerOff.Click += new System.EventHandler( this.btnPowerOff_Click );
            // 
            // btnPowerOn
            // 
            this.btnPowerOn.Enabled = false;
            this.btnPowerOn.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.btnPowerOn.Location = new System.Drawing.Point( 159, 54 );
            this.btnPowerOn.Name = "btnPowerOn";
            this.btnPowerOn.Size = new System.Drawing.Size( 44, 27 );
            this.btnPowerOn.TabIndex = 2;
            this.btnPowerOn.Text = "ON";
            this.btnPowerOn.UseVisualStyleBackColor = true;
            this.btnPowerOn.Click += new System.EventHandler( this.btnPowerOn_Click );
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.lblResult2 );
            this.groupBox2.Controls.Add( this.lblResult1 );
            this.groupBox2.Controls.Add( this.nudSetOutput2 );
            this.groupBox2.Controls.Add( this.nudGpibAddress );
            this.groupBox2.Controls.Add( this.nudSetOutput1 );
            this.groupBox2.Controls.Add( this.label2 );
            this.groupBox2.Controls.Add( this.label1 );
            this.groupBox2.Controls.Add( this.label3 );
            this.groupBox2.Controls.Add( this.btnInit );
            this.groupBox2.Controls.Add( this.chkVoltageCtrl );
            this.groupBox2.Controls.Add( this.btnMeasure );
            this.groupBox2.Controls.Add( this.btnPowerOff );
            this.groupBox2.Controls.Add( this.btnPowerOn );
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point( 0, 0 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 210, 132 );
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Power Supply";
            // 
            // lblResult2
            // 
            this.lblResult2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult2.Location = new System.Drawing.Point( 68, 82 );
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size( 62, 20 );
            this.lblResult2.TabIndex = 57;
            this.lblResult2.Text = "0.000";
            this.lblResult2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult1
            // 
            this.lblResult1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult1.Location = new System.Drawing.Point( 3, 82 );
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size( 62, 20 );
            this.lblResult1.TabIndex = 57;
            this.lblResult1.Text = "0.000";
            this.lblResult1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudGpibAddress
            // 
            this.nudGpibAddress.Location = new System.Drawing.Point( 117, 15 );
            this.nudGpibAddress.Maximum = new decimal( new int[ ] {
            99,
            0,
            0,
            0} );
            this.nudGpibAddress.Minimum = new decimal( new int[ ] {
            1,
            0,
            0,
            0} );
            this.nudGpibAddress.Name = "nudGpibAddress";
            this.nudGpibAddress.Size = new System.Drawing.Size( 39, 20 );
            this.nudGpibAddress.TabIndex = 10;
            this.nudGpibAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudGpibAddress.Value = new decimal( new int[ ] {
            4,
            0,
            0,
            0} );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 74, 40 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 64, 13 );
            this.label2.TabIndex = 6;
            this.label2.Text = "Set Output2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 4, 38 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 64, 13 );
            this.label1.TabIndex = 6;
            this.label1.Text = "Set Output1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 72, 18 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 45, 13 );
            this.label3.TabIndex = 6;
            this.label3.Text = "Address";
            // 
            // btnInit
            // 
            this.btnInit.Font = new System.Drawing.Font( "Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.btnInit.Location = new System.Drawing.Point( 159, 11 );
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size( 44, 27 );
            this.btnInit.TabIndex = 8;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler( this.btnInit_Click );
            // 
            // chkVoltageCtrl
            // 
            this.chkVoltageCtrl.Checked = true;
            this.chkVoltageCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVoltageCtrl.Location = new System.Drawing.Point( 6, 17 );
            this.chkVoltageCtrl.Name = "chkVoltageCtrl";
            this.chkVoltageCtrl.Size = new System.Drawing.Size( 69, 15 );
            this.chkVoltageCtrl.TabIndex = 7;
            this.chkVoltageCtrl.Text = "V Control";
            this.chkVoltageCtrl.UseVisualStyleBackColor = true;
            this.chkVoltageCtrl.Visible = false;
            // 
            // btnMeasure
            // 
            this.btnMeasure.Enabled = false;
            this.btnMeasure.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.btnMeasure.Location = new System.Drawing.Point( 3, 105 );
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size( 127, 22 );
            this.btnMeasure.TabIndex = 2;
            this.btnMeasure.Text = "Measure";
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler( this.btnMeasure_Click );
            // 
            // PowerSupply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.groupBox2 );
            this.Name = "PowerSupply";
            this.Size = new System.Drawing.Size( 210, 132 );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudSetOutput2 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudSetOutput1 ) ).EndInit( );
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudGpibAddress ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudSetOutput2;
        private System.Windows.Forms.NumericUpDown nudSetOutput1;
        private System.Windows.Forms.Button btnPowerOff;
        private System.Windows.Forms.Button btnPowerOn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblResult2;
        private System.Windows.Forms.Label lblResult1;
        private System.Windows.Forms.NumericUpDown nudGpibAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.CheckBox chkVoltageCtrl;
        private System.Windows.Forms.Button btnMeasure;
    }
}
