namespace Finisar.User_Controls {
    partial class MEMS_Attenu_PDFA {
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
            this.btnLaunchVenderGUI = new System.Windows.Forms.Button();
            this.gboMemsAttenuator = new System.Windows.Forms.GroupBox();
            this.lblSN = new System.Windows.Forms.Label();
            this.lblFWversion = new System.Windows.Forms.Label();
            this.lblHwId = new System.Windows.Forms.Label();
            this.lblPdfa_Ch2_current = new System.Windows.Forms.Label();
            this.lblPdfa_Ch1_current = new System.Windows.Forms.Label();
            this.lblPdfa_Ref_Current = new System.Windows.Forms.Label();
            this.btnGetReading = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnDCA_Power = new System.Windows.Forms.Button();
            this.lblDCA_Power = new System.Windows.Forms.Label();
            this.btnTurnOff_PDFA = new System.Windows.Forms.Button();
            this.btnTurnOn_PDFA = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudDacSetpoint = new System.Windows.Forms.NumericUpDown();
            this.nudSetAtten = new System.Windows.Forms.NumericUpDown();
            this.lblAttenReading = new System.Windows.Forms.Label();
            this.lblAtten_dac = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblShutterStatus = new System.Windows.Forms.Label();
            this.btnCloseShutter = new System.Windows.Forms.Button();
            this.btnOpenShutter = new System.Windows.Forms.Button();
            this.gboMemsAttenuator.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDacSetpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetAtten)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaunchVenderGUI
            // 
            this.btnLaunchVenderGUI.Location = new System.Drawing.Point(6, 239);
            this.btnLaunchVenderGUI.Name = "btnLaunchVenderGUI";
            this.btnLaunchVenderGUI.Size = new System.Drawing.Size(96, 23);
            this.btnLaunchVenderGUI.TabIndex = 0;
            this.btnLaunchVenderGUI.Text = "Lanuch GUI";
            this.btnLaunchVenderGUI.UseVisualStyleBackColor = true;
            this.btnLaunchVenderGUI.Click += new System.EventHandler(this.btnLaunchVenderGUI_Click);
            // 
            // gboMemsAttenuator
            // 
            this.gboMemsAttenuator.Controls.Add(this.lblSN);
            this.gboMemsAttenuator.Controls.Add(this.lblFWversion);
            this.gboMemsAttenuator.Controls.Add(this.lblHwId);
            this.gboMemsAttenuator.Controls.Add(this.lblPdfa_Ch2_current);
            this.gboMemsAttenuator.Controls.Add(this.lblPdfa_Ch1_current);
            this.gboMemsAttenuator.Controls.Add(this.lblPdfa_Ref_Current);
            this.gboMemsAttenuator.Controls.Add(this.btnGetReading);
            this.gboMemsAttenuator.Controls.Add(this.btnInit);
            this.gboMemsAttenuator.Controls.Add(this.btnDCA_Power);
            this.gboMemsAttenuator.Controls.Add(this.lblDCA_Power);
            this.gboMemsAttenuator.Controls.Add(this.btnTurnOff_PDFA);
            this.gboMemsAttenuator.Controls.Add(this.btnTurnOn_PDFA);
            this.gboMemsAttenuator.Controls.Add(this.groupBox1);
            this.gboMemsAttenuator.Controls.Add(this.label5);
            this.gboMemsAttenuator.Controls.Add(this.label4);
            this.gboMemsAttenuator.Controls.Add(this.label1);
            this.gboMemsAttenuator.Controls.Add(this.lblShutterStatus);
            this.gboMemsAttenuator.Controls.Add(this.btnCloseShutter);
            this.gboMemsAttenuator.Controls.Add(this.btnOpenShutter);
            this.gboMemsAttenuator.Controls.Add(this.btnLaunchVenderGUI);
            this.gboMemsAttenuator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboMemsAttenuator.Location = new System.Drawing.Point(0, 0);
            this.gboMemsAttenuator.Name = "gboMemsAttenuator";
            this.gboMemsAttenuator.Size = new System.Drawing.Size(244, 265);
            this.gboMemsAttenuator.TabIndex = 2;
            this.gboMemsAttenuator.TabStop = false;
            this.gboMemsAttenuator.Text = "MEMS Attenuator and PDFA";
            // 
            // lblSN
            // 
            this.lblSN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSN.Location = new System.Drawing.Point(39, 182);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(75, 18);
            this.lblSN.TabIndex = 6;
            this.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFWversion
            // 
            this.lblFWversion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFWversion.Location = new System.Drawing.Point(39, 149);
            this.lblFWversion.Name = "lblFWversion";
            this.lblFWversion.Size = new System.Drawing.Size(75, 18);
            this.lblFWversion.TabIndex = 6;
            this.lblFWversion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHwId
            // 
            this.lblHwId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHwId.Location = new System.Drawing.Point(39, 217);
            this.lblHwId.Name = "lblHwId";
            this.lblHwId.Size = new System.Drawing.Size(75, 18);
            this.lblHwId.TabIndex = 6;
            this.lblHwId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPdfa_Ch2_current
            // 
            this.lblPdfa_Ch2_current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPdfa_Ch2_current.Location = new System.Drawing.Point(172, 145);
            this.lblPdfa_Ch2_current.Name = "lblPdfa_Ch2_current";
            this.lblPdfa_Ch2_current.Size = new System.Drawing.Size(61, 17);
            this.lblPdfa_Ch2_current.TabIndex = 15;
            // 
            // lblPdfa_Ch1_current
            // 
            this.lblPdfa_Ch1_current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPdfa_Ch1_current.Location = new System.Drawing.Point(172, 128);
            this.lblPdfa_Ch1_current.Name = "lblPdfa_Ch1_current";
            this.lblPdfa_Ch1_current.Size = new System.Drawing.Size(61, 17);
            this.lblPdfa_Ch1_current.TabIndex = 15;
            // 
            // lblPdfa_Ref_Current
            // 
            this.lblPdfa_Ref_Current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPdfa_Ref_Current.Location = new System.Drawing.Point(172, 111);
            this.lblPdfa_Ref_Current.Name = "lblPdfa_Ref_Current";
            this.lblPdfa_Ref_Current.Size = new System.Drawing.Size(61, 17);
            this.lblPdfa_Ref_Current.TabIndex = 15;
            // 
            // btnGetReading
            // 
            this.btnGetReading.Location = new System.Drawing.Point(127, 105);
            this.btnGetReading.Name = "btnGetReading";
            this.btnGetReading.Size = new System.Drawing.Size(42, 61);
            this.btnGetReading.TabIndex = 14;
            this.btnGetReading.Text = "REF  CH1 CH2";
            this.btnGetReading.UseVisualStyleBackColor = true;
            this.btnGetReading.Click += new System.EventHandler(this.btnGetReading_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(151, 10);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 13;
            this.btnInit.Text = "Initialization";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnDCA_Power
            // 
            this.btnDCA_Power.Location = new System.Drawing.Point(133, 179);
            this.btnDCA_Power.Name = "btnDCA_Power";
            this.btnDCA_Power.Size = new System.Drawing.Size(93, 24);
            this.btnDCA_Power.TabIndex = 12;
            this.btnDCA_Power.Text = "Get DCA Power";
            this.btnDCA_Power.UseVisualStyleBackColor = true;
            this.btnDCA_Power.Click += new System.EventHandler(this.btnDCA_Power_Click);
            // 
            // lblDCA_Power
            // 
            this.lblDCA_Power.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDCA_Power.Location = new System.Drawing.Point(140, 210);
            this.lblDCA_Power.Name = "lblDCA_Power";
            this.lblDCA_Power.Size = new System.Drawing.Size(73, 25);
            this.lblDCA_Power.TabIndex = 11;
            this.lblDCA_Power.Text = "0";
            this.lblDCA_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTurnOff_PDFA
            // 
            this.btnTurnOff_PDFA.Location = new System.Drawing.Point(142, 70);
            this.btnTurnOff_PDFA.Name = "btnTurnOff_PDFA";
            this.btnTurnOff_PDFA.Size = new System.Drawing.Size(101, 25);
            this.btnTurnOff_PDFA.TabIndex = 10;
            this.btnTurnOff_PDFA.Text = "TurnOFF_PDFA";
            this.btnTurnOff_PDFA.UseVisualStyleBackColor = true;
            this.btnTurnOff_PDFA.Click += new System.EventHandler(this.btnTurnOff_PDFA_Click);
            // 
            // btnTurnOn_PDFA
            // 
            this.btnTurnOn_PDFA.Location = new System.Drawing.Point(142, 39);
            this.btnTurnOn_PDFA.Name = "btnTurnOn_PDFA";
            this.btnTurnOn_PDFA.Size = new System.Drawing.Size(101, 25);
            this.btnTurnOn_PDFA.TabIndex = 10;
            this.btnTurnOn_PDFA.Text = "TurnOn_PDFA";
            this.btnTurnOn_PDFA.UseVisualStyleBackColor = true;
            this.btnTurnOn_PDFA.Click += new System.EventHandler(this.btnTurnOn_PDFA_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudDacSetpoint);
            this.groupBox1.Controls.Add(this.nudSetAtten);
            this.groupBox1.Controls.Add(this.lblAttenReading);
            this.groupBox1.Controls.Add(this.lblAtten_dac);
            this.groupBox1.Location = new System.Drawing.Point(3, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 69);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atten DAC";
            // 
            // nudDacSetpoint
            // 
            this.nudDacSetpoint.Enabled = false;
            this.nudDacSetpoint.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudDacSetpoint.Location = new System.Drawing.Point(6, 18);
            this.nudDacSetpoint.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nudDacSetpoint.Name = "nudDacSetpoint";
            this.nudDacSetpoint.Size = new System.Drawing.Size(51, 20);
            this.nudDacSetpoint.TabIndex = 8;
            this.nudDacSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDacSetpoint.Value = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nudDacSetpoint.ValueChanged += new System.EventHandler(this.nudDacSetpoint_ValueChanged);
            // 
            // nudSetAtten
            // 
            this.nudSetAtten.DecimalPlaces = 2;
            this.nudSetAtten.Enabled = false;
            this.nudSetAtten.Location = new System.Drawing.Point(8, 44);
            this.nudSetAtten.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.nudSetAtten.Minimum = new decimal(new int[] {
            45,
            0,
            0,
            -2147483648});
            this.nudSetAtten.Name = "nudSetAtten";
            this.nudSetAtten.Size = new System.Drawing.Size(47, 20);
            this.nudSetAtten.TabIndex = 8;
            this.nudSetAtten.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetAtten.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.nudSetAtten.ValueChanged += new System.EventHandler(this.nudSetAtten_ValueChanged);
            // 
            // lblAttenReading
            // 
            this.lblAttenReading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAttenReading.Location = new System.Drawing.Point(61, 47);
            this.lblAttenReading.Name = "lblAttenReading";
            this.lblAttenReading.Size = new System.Drawing.Size(41, 19);
            this.lblAttenReading.TabIndex = 2;
            this.lblAttenReading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAttenReading.Visible = false;
            // 
            // lblAtten_dac
            // 
            this.lblAtten_dac.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAtten_dac.Location = new System.Drawing.Point(60, 19);
            this.lblAtten_dac.Name = "lblAtten_dac";
            this.lblAtten_dac.Size = new System.Drawing.Size(44, 24);
            this.lblAtten_dac.TabIndex = 2;
            this.lblAtten_dac.Text = "65000";
            this.lblAtten_dac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "HW ID";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "SN";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "FW version";
            // 
            // lblShutterStatus
            // 
            this.lblShutterStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShutterStatus.Location = new System.Drawing.Point(8, 123);
            this.lblShutterStatus.Name = "lblShutterStatus";
            this.lblShutterStatus.Size = new System.Drawing.Size(88, 18);
            this.lblShutterStatus.TabIndex = 5;
            this.lblShutterStatus.Text = "Shutter Closed";
            // 
            // btnCloseShutter
            // 
            this.btnCloseShutter.Location = new System.Drawing.Point(60, 91);
            this.btnCloseShutter.Name = "btnCloseShutter";
            this.btnCloseShutter.Size = new System.Drawing.Size(48, 21);
            this.btnCloseShutter.TabIndex = 4;
            this.btnCloseShutter.Text = "Close Shutter";
            this.btnCloseShutter.UseVisualStyleBackColor = true;
            this.btnCloseShutter.Click += new System.EventHandler(this.btnCloseShutter_Click);
            // 
            // btnOpenShutter
            // 
            this.btnOpenShutter.Location = new System.Drawing.Point(3, 91);
            this.btnOpenShutter.Name = "btnOpenShutter";
            this.btnOpenShutter.Size = new System.Drawing.Size(55, 21);
            this.btnOpenShutter.TabIndex = 4;
            this.btnOpenShutter.Text = "Open Shutter";
            this.btnOpenShutter.UseVisualStyleBackColor = true;
            this.btnOpenShutter.Click += new System.EventHandler(this.btnOpenShutter_Click);
            // 
            // MEMS_Attenu_PDFA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gboMemsAttenuator);
            this.Name = "MEMS_Attenu_PDFA";
            this.Size = new System.Drawing.Size(244, 265);
            this.gboMemsAttenuator.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDacSetpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetAtten)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLaunchVenderGUI;
        private System.Windows.Forms.GroupBox gboMemsAttenuator;
        private System.Windows.Forms.Label lblAttenReading;
        private System.Windows.Forms.Label lblShutterStatus;
        private System.Windows.Forms.Button btnCloseShutter;
        private System.Windows.Forms.Button btnOpenShutter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFWversion;
        private System.Windows.Forms.NumericUpDown nudSetAtten;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTurnOff_PDFA;
        private System.Windows.Forms.Button btnTurnOn_PDFA;
        private System.Windows.Forms.Button btnDCA_Power;
        private System.Windows.Forms.Label lblDCA_Power;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label lblPdfa_Ch2_current;
        private System.Windows.Forms.Label lblPdfa_Ch1_current;
        private System.Windows.Forms.Label lblPdfa_Ref_Current;
        private System.Windows.Forms.Button btnGetReading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHwId;
        private System.Windows.Forms.Label lblSN;
        private System.Windows.Forms.NumericUpDown nudDacSetpoint;
        private System.Windows.Forms.Label lblAtten_dac;
    }
}
