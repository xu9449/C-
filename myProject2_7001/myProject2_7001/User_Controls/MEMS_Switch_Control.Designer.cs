namespace Finisar.Controls {
    partial class MEMS_Switch_Control {
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
            this.rdoPower = new System.Windows.Forms.RadioButton();
            this.lblPowerUnit = new System.Windows.Forms.Label();
            this.lblPowerReading = new System.Windows.Forms.Label();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.gboChSwitch = new System.Windows.Forms.GroupBox();
            this.gboPower = new System.Windows.Forms.GroupBox();
            this.txtPowerOffset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActualPower = new System.Windows.Forms.Label();
            this.btnInitSwitch = new System.Windows.Forms.Button();
            this.rdoEye = new System.Windows.Forms.RadioButton();
            this.rdoSpec = new System.Windows.Forms.RadioButton();
            this.gboChSwitch.SuspendLayout();
            this.gboPower.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoPower
            // 
            this.rdoPower.AutoSize = true;
            this.rdoPower.Checked = true;
            this.rdoPower.Enabled = false;
            this.rdoPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPower.Location = new System.Drawing.Point(11, 19);
            this.rdoPower.Name = "rdoPower";
            this.rdoPower.Size = new System.Drawing.Size(55, 17);
            this.rdoPower.TabIndex = 0;
            this.rdoPower.TabStop = true;
            this.rdoPower.Text = "Power";
            this.rdoPower.UseVisualStyleBackColor = true;
            this.rdoPower.CheckedChanged += new System.EventHandler(this.rdoPower_CheckedChanged);
            // 
            // lblPowerUnit
            // 
            this.lblPowerUnit.AutoSize = true;
            this.lblPowerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPowerUnit.Location = new System.Drawing.Point(51, 15);
            this.lblPowerUnit.Name = "lblPowerUnit";
            this.lblPowerUnit.Size = new System.Drawing.Size(20, 13);
            this.lblPowerUnit.TabIndex = 24;
            this.lblPowerUnit.Text = "dB";
            // 
            // lblPowerReading
            // 
            this.lblPowerReading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPowerReading.Location = new System.Drawing.Point(5, 13);
            this.lblPowerReading.Name = "lblPowerReading";
            this.lblPowerReading.Size = new System.Drawing.Size(46, 18);
            this.lblPowerReading.TabIndex = 23;
            this.lblPowerReading.Text = "-0.1452";
            this.lblPowerReading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Enabled = false;
            this.rdoOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoOther.Location = new System.Drawing.Point(285, 19);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(70, 17);
            this.rdoOther.TabIndex = 0;
            this.rdoOther.Text = "Not Used";
            this.rdoOther.UseVisualStyleBackColor = true;
            this.rdoOther.CheckedChanged += new System.EventHandler(this.rdoOther_CheckedChanged);
            // 
            // gboChSwitch
            // 
            this.gboChSwitch.Controls.Add(this.gboPower);
            this.gboChSwitch.Controls.Add(this.rdoPower);
            this.gboChSwitch.Controls.Add(this.rdoOther);
            this.gboChSwitch.Controls.Add(this.btnInitSwitch);
            this.gboChSwitch.Controls.Add(this.rdoEye);
            this.gboChSwitch.Controls.Add(this.rdoSpec);
            this.gboChSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboChSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gboChSwitch.Location = new System.Drawing.Point(0, 0);
            this.gboChSwitch.Name = "gboChSwitch";
            this.gboChSwitch.Size = new System.Drawing.Size(379, 76);
            this.gboChSwitch.TabIndex = 5;
            this.gboChSwitch.TabStop = false;
            this.gboChSwitch.Text = "Channel Switch";
            // 
            // gboPower
            // 
            this.gboPower.Controls.Add(this.lblPowerReading);
            this.gboPower.Controls.Add(this.txtPowerOffset);
            this.gboPower.Controls.Add(this.label2);
            this.gboPower.Controls.Add(this.label1);
            this.gboPower.Controls.Add(this.lblActualPower);
            this.gboPower.Controls.Add(this.lblPowerUnit);
            this.gboPower.Location = new System.Drawing.Point(4, 36);
            this.gboPower.Name = "gboPower";
            this.gboPower.Size = new System.Drawing.Size(236, 35);
            this.gboPower.TabIndex = 25;
            this.gboPower.TabStop = false;
            // 
            // txtPowerOffset
            // 
            this.txtPowerOffset.Location = new System.Drawing.Point(109, 11);
            this.txtPowerOffset.Name = "txtPowerOffset";
            this.txtPowerOffset.Size = new System.Drawing.Size(36, 20);
            this.txtPowerOffset.TabIndex = 25;
            this.txtPowerOffset.Text = "1.2";
            this.txtPowerOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPowerOffset.TextChanged += new System.EventHandler(this.txtPowerOffset_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 27);
            this.label2.TabIndex = 26;
            this.label2.Text = "Actual Power";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 27);
            this.label1.TabIndex = 26;
            this.label1.Text = "Power Offset";
            // 
            // lblActualPower
            // 
            this.lblActualPower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblActualPower.Location = new System.Drawing.Point(185, 12);
            this.lblActualPower.Name = "lblActualPower";
            this.lblActualPower.Size = new System.Drawing.Size(46, 18);
            this.lblActualPower.TabIndex = 23;
            this.lblActualPower.Text = "----";
            this.lblActualPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInitSwitch
            // 
            this.btnInitSwitch.Location = new System.Drawing.Point(243, 41);
            this.btnInitSwitch.Name = "btnInitSwitch";
            this.btnInitSwitch.Size = new System.Drawing.Size(125, 26);
            this.btnInitSwitch.TabIndex = 3;
            this.btnInitSwitch.Text = "Initialize MEMS Switch";
            this.btnInitSwitch.UseVisualStyleBackColor = true;
            this.btnInitSwitch.Click += new System.EventHandler(this.btnInitSwitch_Click);
            // 
            // rdoEye
            // 
            this.rdoEye.AutoSize = true;
            this.rdoEye.Enabled = false;
            this.rdoEye.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoEye.Location = new System.Drawing.Point(188, 19);
            this.rdoEye.Name = "rdoEye";
            this.rdoEye.Size = new System.Drawing.Size(71, 17);
            this.rdoEye.TabIndex = 0;
            this.rdoEye.Text = "Eye_DCA";
            this.rdoEye.UseVisualStyleBackColor = true;
            this.rdoEye.CheckedChanged += new System.EventHandler(this.rdoEye_CheckedChanged);
            // 
            // rdoSpec
            // 
            this.rdoSpec.AutoSize = true;
            this.rdoSpec.Enabled = false;
            this.rdoSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSpec.Location = new System.Drawing.Point(92, 19);
            this.rdoSpec.Name = "rdoSpec";
            this.rdoSpec.Size = new System.Drawing.Size(70, 17);
            this.rdoSpec.TabIndex = 0;
            this.rdoSpec.Text = "Spectrum";
            this.rdoSpec.UseVisualStyleBackColor = true;
            this.rdoSpec.CheckedChanged += new System.EventHandler(this.rdoSpec_CheckedChanged);
            // 
            // MEMS_Switch_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gboChSwitch);
            this.Name = "MEMS_Switch_Control";
            this.Size = new System.Drawing.Size(379, 76);
            this.gboChSwitch.ResumeLayout(false);
            this.gboChSwitch.PerformLayout();
            this.gboPower.ResumeLayout(false);
            this.gboPower.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPowerUnit;
        private System.Windows.Forms.Label lblPowerReading;
        private System.Windows.Forms.GroupBox gboChSwitch;
        private System.Windows.Forms.Button btnInitSwitch;
        private System.Windows.Forms.GroupBox gboPower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActualPower;
        public System.Windows.Forms.TextBox txtPowerOffset;
        public System.Windows.Forms.RadioButton rdoPower;
        public System.Windows.Forms.RadioButton rdoOther;
        public System.Windows.Forms.RadioButton rdoEye;
        public System.Windows.Forms.RadioButton rdoSpec;
    }
}
