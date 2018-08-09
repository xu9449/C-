namespace Finisar.GPIB_Controls {
    partial class DCA_Control {
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
            this.gboDCA = new System.Windows.Forms.GroupBox( );
            this.screenDumpPB = new System.Windows.Forms.PictureBox( );
            this.btnSetEdataPath = new System.Windows.Forms.Button( );
            this.txtEdataFilePath = new System.Windows.Forms.TextBox( );
            this.lblStatus = new System.Windows.Forms.Label( );
            this.gboEyeMode = new System.Windows.Forms.GroupBox( );
            this.rdoOsilloscopeMode = new System.Windows.Forms.RadioButton( );
            this.rdoEyeMode = new System.Windows.Forms.RadioButton( );
            this.screenDumpButton = new System.Windows.Forms.Button( );
            this.btnInit_DCA = new System.Windows.Forms.Button( );
            this.gboEyeMeasurement = new System.Windows.Forms.GroupBox( );
            this.lblEyeAmplitude = new System.Windows.Forms.Label( );
            this.label51 = new System.Windows.Forms.Label( );
            this.label54 = new System.Windows.Forms.Label( );
            this.label55 = new System.Windows.Forms.Label( );
            this.allEyeMeasurementsButton = new System.Windows.Forms.Button( );
            this.overShotLable = new System.Windows.Forms.Label( );
            this.signal2noiseLable = new System.Windows.Forms.Label( );
            this.jitterPPLable = new System.Windows.Forms.Label( );
            this.jitterLabel = new System.Windows.Forms.Label( );
            this.label56 = new System.Windows.Forms.Label( );
            this.label58 = new System.Windows.Forms.Label( );
            this.label59 = new System.Windows.Forms.Label( );
            this.label60 = new System.Windows.Forms.Label( );
            this.label61 = new System.Windows.Forms.Label( );
            this.fallTimeLabel = new System.Windows.Forms.Label( );
            this.label62 = new System.Windows.Forms.Label( );
            this.extinctionRatioLabel = new System.Windows.Forms.Label( );
            this.riseTimeLabel = new System.Windows.Forms.Label( );
            this.label65 = new System.Windows.Forms.Label( );
            this.maskMarginLable = new System.Windows.Forms.Label( );
            this.label66 = new System.Windows.Forms.Label( );
            this.crossingLabel = new System.Windows.Forms.Label( );
            this.label52 = new System.Windows.Forms.Label( );
            this.label53 = new System.Windows.Forms.Label( );
            this.label63 = new System.Windows.Forms.Label( );
            this.label64 = new System.Windows.Forms.Label( );
            this.label57 = new System.Windows.Forms.Label( );
            this.label67 = new System.Windows.Forms.Label( );
            this.nudDCAChannelNumber = new System.Windows.Forms.NumericUpDown( );
            this.gboDCA.SuspendLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.screenDumpPB ) ).BeginInit( );
            this.gboEyeMode.SuspendLayout( );
            this.gboEyeMeasurement.SuspendLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudDCAChannelNumber ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // gboDCA
            // 
            this.gboDCA.Controls.Add( this.nudDCAChannelNumber );
            this.gboDCA.Controls.Add( this.screenDumpPB );
            this.gboDCA.Controls.Add( this.btnSetEdataPath );
            this.gboDCA.Controls.Add( this.txtEdataFilePath );
            this.gboDCA.Controls.Add( this.lblStatus );
            this.gboDCA.Controls.Add( this.gboEyeMode );
            this.gboDCA.Controls.Add( this.screenDumpButton );
            this.gboDCA.Controls.Add( this.btnInit_DCA );
            this.gboDCA.Controls.Add( this.gboEyeMeasurement );
            this.gboDCA.Controls.Add( this.label67 );
            this.gboDCA.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.gboDCA.Location = new System.Drawing.Point( 3, 3 );
            this.gboDCA.Name = "gboDCA";
            this.gboDCA.Size = new System.Drawing.Size( 508, 480 );
            this.gboDCA.TabIndex = 40;
            this.gboDCA.TabStop = false;
            this.gboDCA.Text = "DCA Control";
            // 
            // screenDumpPB
            // 
            this.screenDumpPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screenDumpPB.Location = new System.Drawing.Point( 3, 141 );
            this.screenDumpPB.Name = "screenDumpPB";
            this.screenDumpPB.Size = new System.Drawing.Size( 501, 308 );
            this.screenDumpPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.screenDumpPB.TabIndex = 27;
            this.screenDumpPB.TabStop = false;
            // 
            // btnSetEdataPath
            // 
            this.btnSetEdataPath.Font = new System.Drawing.Font( "Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.btnSetEdataPath.Location = new System.Drawing.Point( 465, 108 );
            this.btnSetEdataPath.Name = "btnSetEdataPath";
            this.btnSetEdataPath.Size = new System.Drawing.Size( 33, 32 );
            this.btnSetEdataPath.TabIndex = 41;
            this.btnSetEdataPath.Text = "Set Path";
            this.btnSetEdataPath.UseVisualStyleBackColor = true;
            this.btnSetEdataPath.Visible = false;
            this.btnSetEdataPath.Click += new System.EventHandler( this.btnSetEdataPath_Click );
            // 
            // txtEdataFilePath
            // 
            this.txtEdataFilePath.Location = new System.Drawing.Point( 229, 114 );
            this.txtEdataFilePath.Name = "txtEdataFilePath";
            this.txtEdataFilePath.Size = new System.Drawing.Size( 233, 20 );
            this.txtEdataFilePath.TabIndex = 40;
            this.txtEdataFilePath.Text = "\\\\fre-netapp-01\\Shared\\zzz\\";
            this.txtEdataFilePath.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.lblStatus.Location = new System.Drawing.Point( 3, 451 );
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size( 501, 25 );
            this.lblStatus.TabIndex = 29;
            // 
            // gboEyeMode
            // 
            this.gboEyeMode.Controls.Add( this.rdoOsilloscopeMode );
            this.gboEyeMode.Controls.Add( this.rdoEyeMode );
            this.gboEyeMode.Enabled = false;
            this.gboEyeMode.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.gboEyeMode.Location = new System.Drawing.Point( 7, 80 );
            this.gboEyeMode.Name = "gboEyeMode";
            this.gboEyeMode.Size = new System.Drawing.Size( 92, 53 );
            this.gboEyeMode.TabIndex = 28;
            this.gboEyeMode.TabStop = false;
            this.gboEyeMode.Text = "Mode Switch";
            // 
            // rdoOsilloscopeMode
            // 
            this.rdoOsilloscopeMode.AutoSize = true;
            this.rdoOsilloscopeMode.Location = new System.Drawing.Point( 8, 33 );
            this.rdoOsilloscopeMode.Name = "rdoOsilloscopeMode";
            this.rdoOsilloscopeMode.Size = new System.Drawing.Size( 79, 17 );
            this.rdoOsilloscopeMode.TabIndex = 0;
            this.rdoOsilloscopeMode.TabStop = true;
            this.rdoOsilloscopeMode.Text = "Osilloscope";
            this.rdoOsilloscopeMode.UseVisualStyleBackColor = true;
            this.rdoOsilloscopeMode.CheckedChanged += new System.EventHandler( this.DCAMode_CheckedChanged );
            // 
            // rdoEyeMode
            // 
            this.rdoEyeMode.AutoSize = true;
            this.rdoEyeMode.Location = new System.Drawing.Point( 7, 15 );
            this.rdoEyeMode.Name = "rdoEyeMode";
            this.rdoEyeMode.Size = new System.Drawing.Size( 43, 17 );
            this.rdoEyeMode.TabIndex = 0;
            this.rdoEyeMode.TabStop = true;
            this.rdoEyeMode.Text = "Eye";
            this.rdoEyeMode.UseVisualStyleBackColor = true;
            this.rdoEyeMode.CheckedChanged += new System.EventHandler( this.DCAMode_CheckedChanged );
            // 
            // screenDumpButton
            // 
            this.screenDumpButton.Enabled = false;
            this.screenDumpButton.Location = new System.Drawing.Point( 104, 107 );
            this.screenDumpButton.Name = "screenDumpButton";
            this.screenDumpButton.Size = new System.Drawing.Size( 121, 30 );
            this.screenDumpButton.TabIndex = 26;
            this.screenDumpButton.Text = "Get screen dump";
            this.screenDumpButton.UseVisualStyleBackColor = true;
            this.screenDumpButton.Click += new System.EventHandler( this.screenDumpButton_Click );
            // 
            // btnInit_DCA
            // 
            this.btnInit_DCA.Font = new System.Drawing.Font( "Arial", 12F, System.Drawing.FontStyle.Bold );
            this.btnInit_DCA.Location = new System.Drawing.Point( 6, 19 );
            this.btnInit_DCA.Name = "btnInit_DCA";
            this.btnInit_DCA.Size = new System.Drawing.Size( 81, 24 );
            this.btnInit_DCA.TabIndex = 0;
            this.btnInit_DCA.Text = "Init DCA";
            this.btnInit_DCA.UseVisualStyleBackColor = true;
            this.btnInit_DCA.Click += new System.EventHandler( this.btnInit_DCA_Click );
            // 
            // gboEyeMeasurement
            // 
            this.gboEyeMeasurement.Controls.Add( this.lblEyeAmplitude );
            this.gboEyeMeasurement.Controls.Add( this.label51 );
            this.gboEyeMeasurement.Controls.Add( this.label54 );
            this.gboEyeMeasurement.Controls.Add( this.label55 );
            this.gboEyeMeasurement.Controls.Add( this.allEyeMeasurementsButton );
            this.gboEyeMeasurement.Controls.Add( this.overShotLable );
            this.gboEyeMeasurement.Controls.Add( this.signal2noiseLable );
            this.gboEyeMeasurement.Controls.Add( this.jitterPPLable );
            this.gboEyeMeasurement.Controls.Add( this.jitterLabel );
            this.gboEyeMeasurement.Controls.Add( this.label56 );
            this.gboEyeMeasurement.Controls.Add( this.label58 );
            this.gboEyeMeasurement.Controls.Add( this.label59 );
            this.gboEyeMeasurement.Controls.Add( this.label60 );
            this.gboEyeMeasurement.Controls.Add( this.label61 );
            this.gboEyeMeasurement.Controls.Add( this.fallTimeLabel );
            this.gboEyeMeasurement.Controls.Add( this.label62 );
            this.gboEyeMeasurement.Controls.Add( this.extinctionRatioLabel );
            this.gboEyeMeasurement.Controls.Add( this.riseTimeLabel );
            this.gboEyeMeasurement.Controls.Add( this.label65 );
            this.gboEyeMeasurement.Controls.Add( this.maskMarginLable );
            this.gboEyeMeasurement.Controls.Add( this.label66 );
            this.gboEyeMeasurement.Controls.Add( this.crossingLabel );
            this.gboEyeMeasurement.Controls.Add( this.label52 );
            this.gboEyeMeasurement.Controls.Add( this.label53 );
            this.gboEyeMeasurement.Controls.Add( this.label63 );
            this.gboEyeMeasurement.Controls.Add( this.label64 );
            this.gboEyeMeasurement.Controls.Add( this.label57 );
            this.gboEyeMeasurement.Enabled = false;
            this.gboEyeMeasurement.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
            this.gboEyeMeasurement.Location = new System.Drawing.Point( 105, 10 );
            this.gboEyeMeasurement.Name = "gboEyeMeasurement";
            this.gboEyeMeasurement.Size = new System.Drawing.Size( 394, 95 );
            this.gboEyeMeasurement.TabIndex = 25;
            this.gboEyeMeasurement.TabStop = false;
            this.gboEyeMeasurement.Text = "Eye Measurement Results";
            // 
            // lblEyeAmplitude
            // 
            this.lblEyeAmplitude.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEyeAmplitude.Location = new System.Drawing.Point( 257, 72 );
            this.lblEyeAmplitude.Name = "lblEyeAmplitude";
            this.lblEyeAmplitude.Size = new System.Drawing.Size( 38, 15 );
            this.lblEyeAmplitude.TabIndex = 24;
            this.lblEyeAmplitude.Text = "----";
            this.lblEyeAmplitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label51.Location = new System.Drawing.Point( 28, 49 );
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size( 76, 13 );
            this.label51.TabIndex = 9;
            this.label51.Text = "Extinction ratio";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label54.Location = new System.Drawing.Point( 272, 20 );
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size( 68, 13 );
            this.label54.TabIndex = 10;
            this.label54.Text = "Mask Margin";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label55.Location = new System.Drawing.Point( 167, 48 );
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size( 47, 13 );
            this.label55.TabIndex = 10;
            this.label55.Text = "Crossing";
            // 
            // allEyeMeasurementsButton
            // 
            this.allEyeMeasurementsButton.Location = new System.Drawing.Point( 5, 19 );
            this.allEyeMeasurementsButton.Name = "allEyeMeasurementsButton";
            this.allEyeMeasurementsButton.Size = new System.Drawing.Size( 67, 27 );
            this.allEyeMeasurementsButton.TabIndex = 6;
            this.allEyeMeasurementsButton.Text = "Measure";
            this.allEyeMeasurementsButton.UseVisualStyleBackColor = true;
            this.allEyeMeasurementsButton.Click += new System.EventHandler( this.allEyeMeasurementsButton_Click );
            // 
            // overShotLable
            // 
            this.overShotLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.overShotLable.Location = new System.Drawing.Point( 216, 70 );
            this.overShotLable.Name = "overShotLable";
            this.overShotLable.Size = new System.Drawing.Size( 37, 18 );
            this.overShotLable.TabIndex = 22;
            this.overShotLable.Text = "----";
            this.overShotLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signal2noiseLable
            // 
            this.signal2noiseLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.signal2noiseLable.Location = new System.Drawing.Point( 109, 67 );
            this.signal2noiseLable.Name = "signal2noiseLable";
            this.signal2noiseLable.Size = new System.Drawing.Size( 37, 18 );
            this.signal2noiseLable.TabIndex = 22;
            this.signal2noiseLable.Text = "----";
            this.signal2noiseLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // jitterPPLable
            // 
            this.jitterPPLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.jitterPPLable.Location = new System.Drawing.Point( 216, 18 );
            this.jitterPPLable.Name = "jitterPPLable";
            this.jitterPPLable.Size = new System.Drawing.Size( 37, 18 );
            this.jitterPPLable.TabIndex = 22;
            this.jitterPPLable.Text = "----";
            this.jitterPPLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // jitterLabel
            // 
            this.jitterLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.jitterLabel.Location = new System.Drawing.Point( 109, 17 );
            this.jitterLabel.Name = "jitterLabel";
            this.jitterLabel.Size = new System.Drawing.Size( 37, 18 );
            this.jitterLabel.TabIndex = 22;
            this.jitterLabel.Text = "----";
            this.jitterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label56.Location = new System.Drawing.Point( 290, 47 );
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size( 50, 13 );
            this.label56.TabIndex = 11;
            this.label56.Text = "Rise time";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label58.Location = new System.Drawing.Point( 295, 73 );
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size( 45, 13 );
            this.label58.TabIndex = 12;
            this.label58.Text = "Fall time";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label59.Location = new System.Drawing.Point( 154, 73 );
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size( 61, 13 );
            this.label59.TabIndex = 13;
            this.label59.Text = "Over Shoot";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label60.Location = new System.Drawing.Point( 22, 71 );
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size( 82, 13 );
            this.label60.TabIndex = 13;
            this.label60.Text = "Signal To Noise";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label61.Location = new System.Drawing.Point( 171, 21 );
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size( 43, 13 );
            this.label61.TabIndex = 13;
            this.label61.Text = "JitterPP";
            // 
            // fallTimeLabel
            // 
            this.fallTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fallTimeLabel.Location = new System.Drawing.Point( 341, 73 );
            this.fallTimeLabel.Name = "fallTimeLabel";
            this.fallTimeLabel.Size = new System.Drawing.Size( 37, 18 );
            this.fallTimeLabel.TabIndex = 20;
            this.fallTimeLabel.Text = "----";
            this.fallTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label62.Location = new System.Drawing.Point( 75, 20 );
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size( 29, 13 );
            this.label62.TabIndex = 13;
            this.label62.Text = "Jitter";
            // 
            // extinctionRatioLabel
            // 
            this.extinctionRatioLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.extinctionRatioLabel.Location = new System.Drawing.Point( 109, 42 );
            this.extinctionRatioLabel.Name = "extinctionRatioLabel";
            this.extinctionRatioLabel.Size = new System.Drawing.Size( 37, 18 );
            this.extinctionRatioLabel.TabIndex = 14;
            this.extinctionRatioLabel.Text = "----";
            this.extinctionRatioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // riseTimeLabel
            // 
            this.riseTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.riseTimeLabel.Location = new System.Drawing.Point( 341, 44 );
            this.riseTimeLabel.Name = "riseTimeLabel";
            this.riseTimeLabel.Size = new System.Drawing.Size( 37, 18 );
            this.riseTimeLabel.TabIndex = 18;
            this.riseTimeLabel.Text = "----";
            this.riseTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label65.Location = new System.Drawing.Point( 145, 48 );
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size( 20, 13 );
            this.label65.TabIndex = 15;
            this.label65.Text = "dB";
            // 
            // maskMarginLable
            // 
            this.maskMarginLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.maskMarginLable.Location = new System.Drawing.Point( 341, 20 );
            this.maskMarginLable.Name = "maskMarginLable";
            this.maskMarginLable.Size = new System.Drawing.Size( 37, 18 );
            this.maskMarginLable.TabIndex = 16;
            this.maskMarginLable.Text = "----";
            this.maskMarginLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label66.Location = new System.Drawing.Point( 255, 49 );
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size( 15, 13 );
            this.label66.TabIndex = 17;
            this.label66.Text = "%";
            // 
            // crossingLabel
            // 
            this.crossingLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crossingLabel.Location = new System.Drawing.Point( 216, 44 );
            this.crossingLabel.Name = "crossingLabel";
            this.crossingLabel.Size = new System.Drawing.Size( 37, 18 );
            this.crossingLabel.TabIndex = 16;
            this.crossingLabel.Text = "----";
            this.crossingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label52.Location = new System.Drawing.Point( 254, 21 );
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size( 18, 13 );
            this.label52.TabIndex = 23;
            this.label52.Text = "ps";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label53.Location = new System.Drawing.Point( 145, 20 );
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size( 18, 13 );
            this.label53.TabIndex = 23;
            this.label53.Text = "ps";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label63.Location = new System.Drawing.Point( 375, 49 );
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size( 18, 13 );
            this.label63.TabIndex = 19;
            this.label63.Text = "ps";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label64.Location = new System.Drawing.Point( 378, 23 );
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size( 15, 13 );
            this.label64.TabIndex = 17;
            this.label64.Text = "%";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label57.Location = new System.Drawing.Point( 375, 76 );
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size( 18, 13 );
            this.label57.TabIndex = 21;
            this.label57.Text = "ps";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point( 4, 49 );
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size( 50, 26 );
            this.label67.TabIndex = 9;
            this.label67.Text = "Chanel Number";
            // 
            // nudDCAChannelNumber
            // 
            this.nudDCAChannelNumber.Location = new System.Drawing.Point( 53, 53 );
            this.nudDCAChannelNumber.Maximum = new decimal( new int[ ] {
            4,
            0,
            0,
            0} );
            this.nudDCAChannelNumber.Minimum = new decimal( new int[ ] {
            1,
            0,
            0,
            0} );
            this.nudDCAChannelNumber.Name = "nudDCAChannelNumber";
            this.nudDCAChannelNumber.Size = new System.Drawing.Size( 39, 20 );
            this.nudDCAChannelNumber.TabIndex = 26;
            this.nudDCAChannelNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDCAChannelNumber.Value = new decimal( new int[ ] {
            1,
            0,
            0,
            0} );
            this.nudDCAChannelNumber.ValueChanged += new System.EventHandler( this.nudDCAChannelNumber_ValueChanged );
            this.nudDCAChannelNumber.Click += new System.EventHandler( this.nudDCAChannelNumber_ValueChanged );
            // 
            // DCA_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.gboDCA );
            this.Name = "DCA_Control";
            this.Size = new System.Drawing.Size( 515, 487 );
            this.gboDCA.ResumeLayout( false );
            this.gboDCA.PerformLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.screenDumpPB ) ).EndInit( );
            this.gboEyeMode.ResumeLayout( false );
            this.gboEyeMode.PerformLayout( );
            this.gboEyeMeasurement.ResumeLayout( false );
            this.gboEyeMeasurement.PerformLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudDCAChannelNumber ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox gboDCA;
        private System.Windows.Forms.GroupBox gboEyeMode;
        private System.Windows.Forms.RadioButton rdoOsilloscopeMode;
        private System.Windows.Forms.RadioButton rdoEyeMode;
        private System.Windows.Forms.Button screenDumpButton;
        private System.Windows.Forms.PictureBox screenDumpPB;
        private System.Windows.Forms.Button btnInit_DCA;
        private System.Windows.Forms.GroupBox gboEyeMeasurement;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button allEyeMeasurementsButton;
        private System.Windows.Forms.Label overShotLable;
        private System.Windows.Forms.Label signal2noiseLable;
        private System.Windows.Forms.Label jitterPPLable;
        private System.Windows.Forms.Label jitterLabel;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label fallTimeLabel;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label extinctionRatioLabel;
        private System.Windows.Forms.Label riseTimeLabel;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label maskMarginLable;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label crossingLabel;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.NumericUpDown nudDCAChannelNumber;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSetEdataPath;
        private System.Windows.Forms.TextBox txtEdataFilePath;
        private System.Windows.Forms.Label lblEyeAmplitude;
    }
}
