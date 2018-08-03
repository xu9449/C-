namespace Finisar.GPIB_Controls {
    partial class Voltageupply_Ag3631 {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.lblStatus = new System.Windows.Forms.Label( );
            this.btnMeasure = new System.Windows.Forms.Button( );
            this.enableCB = new System.Windows.Forms.CheckBox( );
            this.nud_n25I = new System.Windows.Forms.NumericUpDown( );
            this.nud_n25V = new System.Windows.Forms.NumericUpDown( );
            this.nud_p25I = new System.Windows.Forms.NumericUpDown( );
            this.nud_6I = new System.Windows.Forms.NumericUpDown( );
            this.nud_p25V = new System.Windows.Forms.NumericUpDown( );
            this.nud_6V = new System.Windows.Forms.NumericUpDown( );
            this.label11 = new System.Windows.Forms.Label( );
            this.label15 = new System.Windows.Forms.Label( );
            this.label14 = new System.Windows.Forms.Label( );
            this.label13 = new System.Windows.Forms.Label( );
            this.currentLabeln25V = new System.Windows.Forms.Label( );
            this.voltageLabeln25V = new System.Windows.Forms.Label( );
            this.currentLabelp25V = new System.Windows.Forms.Label( );
            this.voltageLabelp25V = new System.Windows.Forms.Label( );
            this.currentLabelp6V = new System.Windows.Forms.Label( );
            this.voltageLabelp6V = new System.Windows.Forms.Label( );
            this.label6 = new System.Windows.Forms.Label( );
            this.label7 = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.label1 = new System.Windows.Forms.Label( );
            this.groupBox1.SuspendLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_n25I ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_n25V ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_p25I ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_6I ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_p25V ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_6V ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.lblStatus );
            this.groupBox1.Controls.Add( this.btnMeasure );
            this.groupBox1.Controls.Add( this.enableCB );
            this.groupBox1.Controls.Add( this.nud_n25I );
            this.groupBox1.Controls.Add( this.nud_n25V );
            this.groupBox1.Controls.Add( this.nud_p25I );
            this.groupBox1.Controls.Add( this.nud_6I );
            this.groupBox1.Controls.Add( this.nud_p25V );
            this.groupBox1.Controls.Add( this.nud_6V );
            this.groupBox1.Controls.Add( this.label11 );
            this.groupBox1.Controls.Add( this.label15 );
            this.groupBox1.Controls.Add( this.label14 );
            this.groupBox1.Controls.Add( this.label13 );
            this.groupBox1.Controls.Add( this.currentLabeln25V );
            this.groupBox1.Controls.Add( this.voltageLabeln25V );
            this.groupBox1.Controls.Add( this.currentLabelp25V );
            this.groupBox1.Controls.Add( this.voltageLabelp25V );
            this.groupBox1.Controls.Add( this.currentLabelp6V );
            this.groupBox1.Controls.Add( this.voltageLabelp6V );
            this.groupBox1.Controls.Add( this.label6 );
            this.groupBox1.Controls.Add( this.label7 );
            this.groupBox1.Controls.Add( this.label5 );
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point( 0, 0 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 523, 320 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PowerSupply 3631";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Location = new System.Drawing.Point( 8, 154 );
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size( 296, 16 );
            this.lblStatus.TabIndex = 37;
            // 
            // btnMeasure
            // 
            this.btnMeasure.Location = new System.Drawing.Point( 226, 124 );
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size( 81, 27 );
            this.btnMeasure.TabIndex = 36;
            this.btnMeasure.Text = "Measure";
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler( this.btnMeasure_Click );
            // 
            // enableCB
            // 
            this.enableCB.AutoSize = true;
            this.enableCB.Location = new System.Drawing.Point( 9, 130 );
            this.enableCB.Name = "enableCB";
            this.enableCB.Size = new System.Drawing.Size( 94, 17 );
            this.enableCB.TabIndex = 35;
            this.enableCB.Text = "Output On/Off";
            this.enableCB.UseVisualStyleBackColor = true;
            this.enableCB.CheckedChanged += new System.EventHandler( this.enableCB_CheckedChanged );
            // 
            // nud_n25I
            // 
            this.nud_n25I.DecimalPlaces = 3;
            this.nud_n25I.Enabled = false;
            this.nud_n25I.Increment = new decimal( new int[ ] {
            1,
            0,
            0,
            65536} );
            this.nud_n25I.Location = new System.Drawing.Point( 234, 57 );
            this.nud_n25I.Maximum = new decimal( new int[ ] {
            6,
            0,
            0,
            0} );
            this.nud_n25I.Name = "nud_n25I";
            this.nud_n25I.Size = new System.Drawing.Size( 48, 20 );
            this.nud_n25I.TabIndex = 34;
            this.nud_n25I.ValueChanged += new System.EventHandler( this.nud_n25I_ValueChanged );
            // 
            // nud_n25V
            // 
            this.nud_n25V.DecimalPlaces = 3;
            this.nud_n25V.Enabled = false;
            this.nud_n25V.Increment = new decimal( new int[ ] {
            1,
            0,
            0,
            65536} );
            this.nud_n25V.Location = new System.Drawing.Point( 234, 33 );
            this.nud_n25V.Maximum = new decimal( new int[ ] {
            6,
            0,
            0,
            0} );
            this.nud_n25V.Name = "nud_n25V";
            this.nud_n25V.Size = new System.Drawing.Size( 48, 20 );
            this.nud_n25V.TabIndex = 34;
            this.nud_n25V.ValueChanged += new System.EventHandler( this.nud_n25V_ValueChanged );
            // 
            // nud_p25I
            // 
            this.nud_p25I.DecimalPlaces = 3;
            this.nud_p25I.Enabled = false;
            this.nud_p25I.Increment = new decimal( new int[ ] {
            1,
            0,
            0,
            65536} );
            this.nud_p25I.Location = new System.Drawing.Point( 172, 57 );
            this.nud_p25I.Maximum = new decimal( new int[ ] {
            6,
            0,
            0,
            0} );
            this.nud_p25I.Name = "nud_p25I";
            this.nud_p25I.Size = new System.Drawing.Size( 48, 20 );
            this.nud_p25I.TabIndex = 34;
            this.nud_p25I.ValueChanged += new System.EventHandler( this.nud_p25I_ValueChanged );
            // 
            // nud_6I
            // 
            this.nud_6I.DecimalPlaces = 3;
            this.nud_6I.Increment = new decimal( new int[ ] {
            1,
            0,
            0,
            65536} );
            this.nud_6I.Location = new System.Drawing.Point( 110, 57 );
            this.nud_6I.Maximum = new decimal( new int[ ] {
            22,
            0,
            0,
            131072} );
            this.nud_6I.Name = "nud_6I";
            this.nud_6I.Size = new System.Drawing.Size( 48, 20 );
            this.nud_6I.TabIndex = 34;
            this.nud_6I.Value = new decimal( new int[ ] {
            22,
            0,
            0,
            131072} );
            this.nud_6I.ValueChanged += new System.EventHandler( this.nud_6I_ValueChanged );
            // 
            // nud_p25V
            // 
            this.nud_p25V.DecimalPlaces = 3;
            this.nud_p25V.Enabled = false;
            this.nud_p25V.Increment = new decimal( new int[ ] {
            1,
            0,
            0,
            65536} );
            this.nud_p25V.Location = new System.Drawing.Point( 172, 33 );
            this.nud_p25V.Maximum = new decimal( new int[ ] {
            6,
            0,
            0,
            0} );
            this.nud_p25V.Name = "nud_p25V";
            this.nud_p25V.Size = new System.Drawing.Size( 48, 20 );
            this.nud_p25V.TabIndex = 34;
            this.nud_p25V.ValueChanged += new System.EventHandler( this.nud_p25V_ValueChanged );
            // 
            // nud_6V
            // 
            this.nud_6V.DecimalPlaces = 3;
            this.nud_6V.Increment = new decimal( new int[ ] {
            1,
            0,
            0,
            65536} );
            this.nud_6V.Location = new System.Drawing.Point( 110, 33 );
            this.nud_6V.Maximum = new decimal( new int[ ] {
            6,
            0,
            0,
            0} );
            this.nud_6V.Name = "nud_6V";
            this.nud_6V.Size = new System.Drawing.Size( 48, 20 );
            this.nud_6V.TabIndex = 34;
            this.nud_6V.Value = new decimal( new int[ ] {
            5,
            0,
            0,
            0} );
            this.nud_6V.ValueChanged += new System.EventHandler( this.nud_6V_ValueChanged );
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point( 292, 102 );
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size( 22, 13 );
            this.label11.TabIndex = 33;
            this.label11.Text = "( I )";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point( 292, 83 );
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size( 20, 13 );
            this.label15.TabIndex = 33;
            this.label15.Text = "(V)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point( 292, 59 );
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size( 20, 13 );
            this.label14.TabIndex = 32;
            this.label14.Text = "(A)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point( 292, 32 );
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size( 20, 13 );
            this.label13.TabIndex = 31;
            this.label13.Text = "(V)";
            // 
            // currentLabeln25V
            // 
            this.currentLabeln25V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentLabeln25V.Location = new System.Drawing.Point( 231, 103 );
            this.currentLabeln25V.Name = "currentLabeln25V";
            this.currentLabeln25V.Size = new System.Drawing.Size( 55, 13 );
            this.currentLabeln25V.TabIndex = 30;
            this.currentLabeln25V.Text = "---";
            this.currentLabeln25V.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voltageLabeln25V
            // 
            this.voltageLabeln25V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.voltageLabeln25V.Location = new System.Drawing.Point( 231, 84 );
            this.voltageLabeln25V.Name = "voltageLabeln25V";
            this.voltageLabeln25V.Size = new System.Drawing.Size( 55, 13 );
            this.voltageLabeln25V.TabIndex = 30;
            this.voltageLabeln25V.Text = "---";
            this.voltageLabeln25V.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentLabelp25V
            // 
            this.currentLabelp25V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentLabelp25V.Location = new System.Drawing.Point( 170, 103 );
            this.currentLabelp25V.Name = "currentLabelp25V";
            this.currentLabelp25V.Size = new System.Drawing.Size( 55, 13 );
            this.currentLabelp25V.TabIndex = 29;
            this.currentLabelp25V.Text = "---";
            this.currentLabelp25V.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voltageLabelp25V
            // 
            this.voltageLabelp25V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.voltageLabelp25V.Location = new System.Drawing.Point( 170, 84 );
            this.voltageLabelp25V.Name = "voltageLabelp25V";
            this.voltageLabelp25V.Size = new System.Drawing.Size( 55, 13 );
            this.voltageLabelp25V.TabIndex = 29;
            this.voltageLabelp25V.Text = "---";
            this.voltageLabelp25V.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentLabelp6V
            // 
            this.currentLabelp6V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentLabelp6V.Location = new System.Drawing.Point( 109, 103 );
            this.currentLabelp6V.Name = "currentLabelp6V";
            this.currentLabelp6V.Size = new System.Drawing.Size( 55, 15 );
            this.currentLabelp6V.TabIndex = 28;
            this.currentLabelp6V.Text = "---";
            this.currentLabelp6V.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voltageLabelp6V
            // 
            this.voltageLabelp6V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.voltageLabelp6V.Location = new System.Drawing.Point( 109, 84 );
            this.voltageLabelp6V.Name = "voltageLabelp6V";
            this.voltageLabelp6V.Size = new System.Drawing.Size( 55, 15 );
            this.voltageLabelp6V.TabIndex = 28;
            this.voltageLabelp6V.Text = "---";
            this.voltageLabelp6V.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 4, 102 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 41, 13 );
            this.label6.TabIndex = 27;
            this.label6.Text = "Current";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 4, 83 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 43, 13 );
            this.label7.TabIndex = 27;
            this.label7.Text = "Voltage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 4, 59 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 99, 13 );
            this.label5.TabIndex = 26;
            this.label5.Text = "Current Compliance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 4, 32 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 62, 13 );
            this.label4.TabIndex = 25;
            this.label4.Text = "Set Voltage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label3.Location = new System.Drawing.Point( 236, 12 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 40, 15 );
            this.label3.TabIndex = 24;
            this.label3.Text = "- 25V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 171, 12 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 43, 15 );
            this.label2.TabIndex = 23;
            this.label2.Text = "+ 25V";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label1.Location = new System.Drawing.Point( 110, 12 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 35, 15 );
            this.label1.TabIndex = 22;
            this.label1.Text = "+ 6V";
            // 
            // Voltageupply_Ag3631
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.groupBox1 );
            this.Name = "Voltageupply_Ag3631";
            this.Size = new System.Drawing.Size( 523, 320 );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_n25I ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_n25V ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_p25I ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_6I ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_p25V ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nud_6V ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label voltageLabeln25V;
        private System.Windows.Forms.Label voltageLabelp25V;
        private System.Windows.Forms.Label voltageLabelp6V;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.CheckBox enableCB;
        private System.Windows.Forms.NumericUpDown nud_n25I;
        private System.Windows.Forms.NumericUpDown nud_n25V;
        private System.Windows.Forms.NumericUpDown nud_p25I;
        private System.Windows.Forms.NumericUpDown nud_6I;
        private System.Windows.Forms.NumericUpDown nud_p25V;
        private System.Windows.Forms.NumericUpDown nud_6V;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label currentLabeln25V;
        private System.Windows.Forms.Label currentLabelp25V;
        private System.Windows.Forms.Label currentLabelp6V;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStatus;
    }
}
