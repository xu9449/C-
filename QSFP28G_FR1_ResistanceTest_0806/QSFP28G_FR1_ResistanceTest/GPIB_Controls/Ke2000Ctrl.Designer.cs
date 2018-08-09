namespace Finisar.GPIB_Controls {
    partial class Ke2000Ctrl {
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
            this.chkDC = new System.Windows.Forms.CheckBox( );
            this.btnInit = new System.Windows.Forms.Button( );
            this.chkVoltageCtrl = new System.Windows.Forms.CheckBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.gboKeithleyCtrl = new System.Windows.Forms.GroupBox( );
            this.measureButton = new System.Windows.Forms.Button( );
            this.resultLabel = new System.Windows.Forms.Label( );
            this.nudGpibAddress = new System.Windows.Forms.NumericUpDown( );
            this.gboKeithleyCtrl.SuspendLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudGpibAddress ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // chkDC
            // 
            this.chkDC.AutoSize = true;
            this.chkDC.Checked = true;
            this.chkDC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDC.Font = new System.Drawing.Font( "Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.chkDC.Location = new System.Drawing.Point( 6, 38 );
            this.chkDC.Name = "chkDC";
            this.chkDC.Size = new System.Drawing.Size( 40, 18 );
            this.chkDC.TabIndex = 9;
            this.chkDC.Text = "DC";
            this.chkDC.UseVisualStyleBackColor = true;
            this.chkDC.CheckedChanged += new System.EventHandler( this.chkchkDC_CheckedChanged );
            // 
            // btnInit
            // 
            this.btnInit.Font = new System.Drawing.Font( "Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.btnInit.Location = new System.Drawing.Point( 104, 8 );
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size( 52, 23 );
            this.btnInit.TabIndex = 8;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler( this.btnInit_Click );
            // 
            // chkVoltageCtrl
            // 
            this.chkVoltageCtrl.Location = new System.Drawing.Point( 6, 17 );
            this.chkVoltageCtrl.Name = "chkVoltageCtrl";
            this.chkVoltageCtrl.Size = new System.Drawing.Size( 69, 15 );
            this.chkVoltageCtrl.TabIndex = 7;
            this.chkVoltageCtrl.Text = "V Control";
            this.chkVoltageCtrl.UseVisualStyleBackColor = true;
            this.chkVoltageCtrl.CheckedChanged += new System.EventHandler( this.chkVoltageCtrl_CheckedChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 42, 38 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 73, 13 );
            this.label3.TabIndex = 6;
            this.label3.Text = "GPIB Address";
            // 
            // gboKeithleyCtrl
            // 
            this.gboKeithleyCtrl.Controls.Add( this.measureButton );
            this.gboKeithleyCtrl.Controls.Add( this.resultLabel );
            this.gboKeithleyCtrl.Controls.Add( this.nudGpibAddress );
            this.gboKeithleyCtrl.Controls.Add( this.chkDC );
            this.gboKeithleyCtrl.Controls.Add( this.label3 );
            this.gboKeithleyCtrl.Controls.Add( this.btnInit );
            this.gboKeithleyCtrl.Controls.Add( this.chkVoltageCtrl );
            this.gboKeithleyCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboKeithleyCtrl.Location = new System.Drawing.Point( 0, 0 );
            this.gboKeithleyCtrl.Name = "gboKeithleyCtrl";
            this.gboKeithleyCtrl.Size = new System.Drawing.Size( 166, 94 );
            this.gboKeithleyCtrl.TabIndex = 10;
            this.gboKeithleyCtrl.TabStop = false;
            this.gboKeithleyCtrl.Text = "Ke2000";
            // 
            // measureButton
            // 
            this.measureButton.Enabled = false;
            this.measureButton.Location = new System.Drawing.Point( 87, 65 );
            this.measureButton.Name = "measureButton";
            this.measureButton.Size = new System.Drawing.Size( 69, 23 );
            this.measureButton.TabIndex = 11;
            this.measureButton.Text = "Measure";
            this.measureButton.UseVisualStyleBackColor = true;
            this.measureButton.Click += new System.EventHandler( this.measureButton_Click );
            // 
            // resultLabel
            // 
            this.resultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultLabel.Location = new System.Drawing.Point( 17, 66 );
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size( 64, 20 );
            this.resultLabel.TabIndex = 12;
            this.resultLabel.Text = "---";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudGpibAddress
            // 
            this.nudGpibAddress.Location = new System.Drawing.Point( 117, 35 );
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
            this.nudGpibAddress.Value = new decimal( new int[ ] {
            22,
            0,
            0,
            0} );
            // 
            // Ke2000Ctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.gboKeithleyCtrl );
            this.Name = "Ke2000Ctrl";
            this.Size = new System.Drawing.Size( 166, 94 );
            this.gboKeithleyCtrl.ResumeLayout( false );
            this.gboKeithleyCtrl.PerformLayout( );
            ( ( System.ComponentModel.ISupportInitialize )( this.nudGpibAddress ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        public System.Windows.Forms.CheckBox chkDC;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.CheckBox chkVoltageCtrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gboKeithleyCtrl;
        private System.Windows.Forms.NumericUpDown nudGpibAddress;
        protected System.Windows.Forms.Button measureButton;
        private System.Windows.Forms.Label resultLabel;
    }
}
