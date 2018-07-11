namespace Finisar.Controls {
    partial class LaserControl_Coherent {
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
            this.gboDriverControl = new System.Windows.Forms.GroupBox( );
            this.btnInit = new System.Windows.Forms.Button( );
            this.cobChannel = new System.Windows.Forms.ComboBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.btnCancelRamp = new System.Windows.Forms.Button( );
            this.nudFeild_4 = new System.Windows.Forms.NumericUpDown( );
            this.rdoFeild_4 = new System.Windows.Forms.RadioButton( );
            this.lblSendOut = new System.Windows.Forms.Label( );
            this.nudFeild_3 = new System.Windows.Forms.NumericUpDown( );
            this.nudFeild_2 = new System.Windows.Forms.NumericUpDown( );
            this.nudFeild_1 = new System.Windows.Forms.NumericUpDown( );
            this.label5 = new System.Windows.Forms.Label( );
            this.label4 = new System.Windows.Forms.Label( );
            this.btnRamp = new System.Windows.Forms.Button( );
            this.lblReadback = new System.Windows.Forms.Label( );
            this.btnRead = new System.Windows.Forms.Button( );
            this.btnSend = new System.Windows.Forms.Button( );
            this.nudRampStep = new System.Windows.Forms.NumericUpDown( );
            this.nudRampStop = new System.Windows.Forms.NumericUpDown( );
            this.rdoFeild_3 = new System.Windows.Forms.RadioButton( );
            this.rdoFeild_2 = new System.Windows.Forms.RadioButton( );
            this.rdoFeild_1 = new System.Windows.Forms.RadioButton( );
            this.label1 = new System.Windows.Forms.Label( );
            this.gboDriverControl.SuspendLayout( );
            this.groupBox1.SuspendLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudFeild_4 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudFeild_3 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudFeild_2 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudFeild_1 ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudRampStep ) ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudRampStop ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // gboDriverControl
            // 
            this.gboDriverControl.Controls.Add( this.btnInit );
            this.gboDriverControl.Controls.Add( this.cobChannel );
            this.gboDriverControl.Controls.Add( this.groupBox1 );
            this.gboDriverControl.Controls.Add( this.label1 );
            this.gboDriverControl.Location = new System.Drawing.Point( 1, 1 );
            this.gboDriverControl.Name = "gboDriverControl";
            this.gboDriverControl.Size = new System.Drawing.Size( 317, 200 );
            this.gboDriverControl.TabIndex = 0;
            this.gboDriverControl.TabStop = false;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point( 229, 11 );
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size( 81, 28 );
            this.btnInit.TabIndex = 4;
            this.btnInit.Text = "Initialization";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler( this.btnInit_Click );
            // 
            // cobChannel
            // 
            this.cobChannel.FormattingEnabled = true;
            this.cobChannel.Location = new System.Drawing.Point( 47, 16 );
            this.cobChannel.Name = "cobChannel";
            this.cobChannel.Size = new System.Drawing.Size( 57, 21 );
            this.cobChannel.TabIndex = 3;
            this.cobChannel.SelectedIndexChanged += new System.EventHandler( this.cobChannel_SelectedIndexChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.btnCancelRamp );
            this.groupBox1.Controls.Add( this.nudFeild_4 );
            this.groupBox1.Controls.Add( this.rdoFeild_4 );
            this.groupBox1.Controls.Add( this.lblSendOut );
            this.groupBox1.Controls.Add( this.nudFeild_3 );
            this.groupBox1.Controls.Add( this.nudFeild_2 );
            this.groupBox1.Controls.Add( this.nudFeild_1 );
            this.groupBox1.Controls.Add( this.label5 );
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.btnRamp );
            this.groupBox1.Controls.Add( this.lblReadback );
            this.groupBox1.Controls.Add( this.btnRead );
            this.groupBox1.Controls.Add( this.btnSend );
            this.groupBox1.Controls.Add( this.nudRampStep );
            this.groupBox1.Controls.Add( this.nudRampStop );
            this.groupBox1.Controls.Add( this.rdoFeild_3 );
            this.groupBox1.Controls.Add( this.rdoFeild_2 );
            this.groupBox1.Controls.Add( this.rdoFeild_1 );
            this.groupBox1.Location = new System.Drawing.Point( 8, 41 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 303, 157 );
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DeviceControl";
            // 
            // btnCancelRamp
            // 
            this.btnCancelRamp.Location = new System.Drawing.Point( 118, 117 );
            this.btnCancelRamp.Name = "btnCancelRamp";
            this.btnCancelRamp.Size = new System.Drawing.Size( 64, 23 );
            this.btnCancelRamp.TabIndex = 8;
            this.btnCancelRamp.Text = "Cancel";
            this.btnCancelRamp.UseVisualStyleBackColor = true;
            this.btnCancelRamp.Click += new System.EventHandler( this.btnCancelRamp_Click );
            // 
            // nudFeild_4
            // 
            this.nudFeild_4.Location = new System.Drawing.Point( 59, 118 );
            this.nudFeild_4.Maximum = new decimal( new int[ ] {
            255,
            0,
            0,
            0} );
            this.nudFeild_4.Name = "nudFeild_4";
            this.nudFeild_4.Size = new System.Drawing.Size( 53, 20 );
            this.nudFeild_4.TabIndex = 2;
            this.nudFeild_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFeild_4.Value = new decimal( new int[ ] {
            238,
            0,
            0,
            0} );
            // 
            // rdoFeild_4
            // 
            this.rdoFeild_4.AutoSize = true;
            this.rdoFeild_4.Location = new System.Drawing.Point( 6, 120 );
            this.rdoFeild_4.Name = "rdoFeild_4";
            this.rdoFeild_4.Size = new System.Drawing.Size( 56, 17 );
            this.rdoFeild_4.TabIndex = 7;
            this.rdoFeild_4.TabStop = true;
            this.rdoFeild_4.Text = "Field 4";
            this.rdoFeild_4.UseVisualStyleBackColor = true;
            this.rdoFeild_4.Click += new System.EventHandler( this.rdoFeild_4_Click );
            // 
            // lblSendOut
            // 
            this.lblSendOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSendOut.Location = new System.Drawing.Point( 179, 19 );
            this.lblSendOut.Name = "lblSendOut";
            this.lblSendOut.Size = new System.Drawing.Size( 115, 20 );
            this.lblSendOut.TabIndex = 6;
            this.lblSendOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudFeild_3
            // 
            this.nudFeild_3.Location = new System.Drawing.Point( 59, 87 );
            this.nudFeild_3.Maximum = new decimal( new int[ ] {
            255,
            0,
            0,
            0} );
            this.nudFeild_3.Name = "nudFeild_3";
            this.nudFeild_3.Size = new System.Drawing.Size( 53, 20 );
            this.nudFeild_3.TabIndex = 2;
            this.nudFeild_3.Tag = "";
            this.nudFeild_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFeild_3.Value = new decimal( new int[ ] {
            180,
            0,
            0,
            0} );
            // 
            // nudFeild_2
            // 
            this.nudFeild_2.Location = new System.Drawing.Point( 59, 53 );
            this.nudFeild_2.Maximum = new decimal( new int[ ] {
            255,
            0,
            0,
            0} );
            this.nudFeild_2.Name = "nudFeild_2";
            this.nudFeild_2.Size = new System.Drawing.Size( 53, 20 );
            this.nudFeild_2.TabIndex = 2;
            this.nudFeild_2.Tag = "";
            this.nudFeild_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudFeild_1
            // 
            this.nudFeild_1.Location = new System.Drawing.Point( 59, 19 );
            this.nudFeild_1.Maximum = new decimal( new int[ ] {
            255,
            0,
            0,
            0} );
            this.nudFeild_1.Name = "nudFeild_1";
            this.nudFeild_1.Size = new System.Drawing.Size( 53, 20 );
            this.nudFeild_1.TabIndex = 2;
            this.nudFeild_1.Tag = "";
            this.nudFeild_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFeild_1.Value = new decimal( new int[ ] {
            89,
            0,
            0,
            0} );
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 249, 74 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 29, 13 );
            this.label5.TabIndex = 5;
            this.label5.Text = "Step";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 191, 74 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 29, 13 );
            this.label4.TabIndex = 5;
            this.label4.Text = "Stop";
            // 
            // btnRamp
            // 
            this.btnRamp.Enabled = false;
            this.btnRamp.Location = new System.Drawing.Point( 117, 88 );
            this.btnRamp.Name = "btnRamp";
            this.btnRamp.Size = new System.Drawing.Size( 64, 23 );
            this.btnRamp.TabIndex = 3;
            this.btnRamp.Text = "Ramp";
            this.btnRamp.UseVisualStyleBackColor = true;
            this.btnRamp.Click += new System.EventHandler( this.btnRamp_Click );
            // 
            // lblReadback
            // 
            this.lblReadback.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReadback.Location = new System.Drawing.Point( 179, 52 );
            this.lblReadback.Name = "lblReadback";
            this.lblReadback.Size = new System.Drawing.Size( 115, 20 );
            this.lblReadback.TabIndex = 4;
            this.lblReadback.Text = "  00  00  00  00";
            this.lblReadback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point( 121, 48 );
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size( 53, 26 );
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler( this.btnRead_Click );
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point( 121, 15 );
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size( 53, 26 );
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler( this.btnSend_Click );
            // 
            // nudRampStep
            // 
            this.nudRampStep.Location = new System.Drawing.Point( 246, 91 );
            this.nudRampStep.Maximum = new decimal( new int[ ] {
            255,
            0,
            0,
            0} );
            this.nudRampStep.Name = "nudRampStep";
            this.nudRampStep.Size = new System.Drawing.Size( 53, 20 );
            this.nudRampStep.TabIndex = 2;
            this.nudRampStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRampStep.Value = new decimal( new int[ ] {
            16,
            0,
            0,
            0} );
            // 
            // nudRampStop
            // 
            this.nudRampStop.Location = new System.Drawing.Point( 187, 91 );
            this.nudRampStop.Maximum = new decimal( new int[ ] {
            255,
            0,
            0,
            0} );
            this.nudRampStop.Name = "nudRampStop";
            this.nudRampStop.Size = new System.Drawing.Size( 53, 20 );
            this.nudRampStop.TabIndex = 2;
            this.nudRampStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdoFeild_3
            // 
            this.rdoFeild_3.AutoSize = true;
            this.rdoFeild_3.Location = new System.Drawing.Point( 6, 90 );
            this.rdoFeild_3.Name = "rdoFeild_3";
            this.rdoFeild_3.Size = new System.Drawing.Size( 56, 17 );
            this.rdoFeild_3.TabIndex = 0;
            this.rdoFeild_3.TabStop = true;
            this.rdoFeild_3.Text = "Field 3";
            this.rdoFeild_3.UseVisualStyleBackColor = true;
            this.rdoFeild_3.Click += new System.EventHandler( this.rdoFeild_3_Click );
            // 
            // rdoFeild_2
            // 
            this.rdoFeild_2.AutoSize = true;
            this.rdoFeild_2.Checked = true;
            this.rdoFeild_2.Location = new System.Drawing.Point( 6, 55 );
            this.rdoFeild_2.Name = "rdoFeild_2";
            this.rdoFeild_2.Size = new System.Drawing.Size( 56, 17 );
            this.rdoFeild_2.TabIndex = 0;
            this.rdoFeild_2.TabStop = true;
            this.rdoFeild_2.Text = "Field 2";
            this.rdoFeild_2.UseVisualStyleBackColor = true;
            this.rdoFeild_2.Click += new System.EventHandler( this.rdoFeild_2_Click );
            // 
            // rdoFeild_1
            // 
            this.rdoFeild_1.AutoSize = true;
            this.rdoFeild_1.Location = new System.Drawing.Point( 6, 20 );
            this.rdoFeild_1.Name = "rdoFeild_1";
            this.rdoFeild_1.Size = new System.Drawing.Size( 56, 17 );
            this.rdoFeild_1.TabIndex = 0;
            this.rdoFeild_1.TabStop = true;
            this.rdoFeild_1.Text = "Field 1";
            this.rdoFeild_1.UseVisualStyleBackColor = true;
            this.rdoFeild_1.Click += new System.EventHandler( this.rdoFeild_1_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 5, 18 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 41, 13 );
            this.label1.TabIndex = 1;
            this.label1.Text = "Device";
            // 
            // LaserControl_Coherent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.gboDriverControl );
            this.Name = "LaserControl_Coherent";
            this.Size = new System.Drawing.Size( 322, 204 );
            this.gboDriverControl.ResumeLayout( false );
            this.gboDriverControl.PerformLayout( );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudFeild_4 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudFeild_3 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudFeild_2 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudFeild_1 ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudRampStep ) ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudRampStop ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox gboDriverControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudFeild_3;
        private System.Windows.Forms.NumericUpDown nudFeild_2;
        private System.Windows.Forms.NumericUpDown nudFeild_1;
        private System.Windows.Forms.NumericUpDown nudFeild_4;
        private System.Windows.Forms.RadioButton rdoFeild_3;
        private System.Windows.Forms.RadioButton rdoFeild_2;
        private System.Windows.Forms.RadioButton rdoFeild_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRamp;
        private System.Windows.Forms.Label lblReadback;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.NumericUpDown nudRampStep;
        private System.Windows.Forms.NumericUpDown nudRampStop;
        private System.Windows.Forms.Label lblSendOut;
        private System.Windows.Forms.ComboBox cobChannel;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.RadioButton rdoFeild_4;
        private System.Windows.Forms.Button btnCancelRamp;
    }
}
