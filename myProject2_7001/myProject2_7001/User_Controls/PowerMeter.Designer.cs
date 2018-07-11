namespace Finisar.User_Controls {
    partial class PowerMeter {
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
            this.gboPower = new System.Windows.Forms.GroupBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.txtPowerOffset_0 = new System.Windows.Forms.TextBox( );
            this.lblActualPower = new System.Windows.Forms.Label( );
            this.lblPowerReading = new System.Windows.Forms.Label( );
            this.lblPowerUnit = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.txtPowerOffset_1 = new System.Windows.Forms.TextBox( );
            this.label6 = new System.Windows.Forms.Label( );
            this.label7 = new System.Windows.Forms.Label( );
            this.txtPowerOffset_2 = new System.Windows.Forms.TextBox( );
            this.txtPowerOffset_3 = new System.Windows.Forms.TextBox( );
            this.btnSetOffset = new System.Windows.Forms.Button( );
            this.gboPower.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // gboPower
            // 
            this.gboPower.Controls.Add( this.btnSetOffset );
            this.gboPower.Controls.Add( this.label2 );
            this.gboPower.Controls.Add( this.txtPowerOffset_3 );
            this.gboPower.Controls.Add( this.txtPowerOffset_1 );
            this.gboPower.Controls.Add( this.txtPowerOffset_2 );
            this.gboPower.Controls.Add( this.txtPowerOffset_0 );
            this.gboPower.Controls.Add( this.lblActualPower );
            this.gboPower.Controls.Add( this.lblPowerReading );
            this.gboPower.Controls.Add( this.label7 );
            this.gboPower.Controls.Add( this.label5 );
            this.gboPower.Controls.Add( this.label3 );
            this.gboPower.Controls.Add( this.label6 );
            this.gboPower.Controls.Add( this.label4 );
            this.gboPower.Controls.Add( this.lblPowerUnit );
            this.gboPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboPower.Location = new System.Drawing.Point( 0, 0 );
            this.gboPower.Name = "gboPower";
            this.gboPower.Size = new System.Drawing.Size( 228, 102 );
            this.gboPower.TabIndex = 26;
            this.gboPower.TabStop = false;
            this.gboPower.Text = "Power Meter";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 133, 21 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 39, 27 );
            this.label2.TabIndex = 26;
            this.label2.Text = "Actual Power";
            // 
            // txtPowerOffset_0
            // 
            this.txtPowerOffset_0.Location = new System.Drawing.Point( 2, 70 );
            this.txtPowerOffset_0.Name = "txtPowerOffset_0";
            this.txtPowerOffset_0.Size = new System.Drawing.Size( 36, 20 );
            this.txtPowerOffset_0.TabIndex = 25;
            this.txtPowerOffset_0.Text = "12.5";
            // 
            // lblActualPower
            // 
            this.lblActualPower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblActualPower.Location = new System.Drawing.Point( 172, 25 );
            this.lblActualPower.Name = "lblActualPower";
            this.lblActualPower.Size = new System.Drawing.Size( 50, 18 );
            this.lblActualPower.TabIndex = 23;
            this.lblActualPower.Text = "----";
            this.lblActualPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPowerReading
            // 
            this.lblPowerReading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPowerReading.Location = new System.Drawing.Point( 53, 25 );
            this.lblPowerReading.Name = "lblPowerReading";
            this.lblPowerReading.Size = new System.Drawing.Size( 50, 18 );
            this.lblPowerReading.TabIndex = 23;
            this.lblPowerReading.Text = "----";
            this.lblPowerReading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPowerUnit
            // 
            this.lblPowerUnit.AutoSize = true;
            this.lblPowerUnit.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.lblPowerUnit.Location = new System.Drawing.Point( 100, 27 );
            this.lblPowerUnit.Name = "lblPowerUnit";
            this.lblPowerUnit.Size = new System.Drawing.Size( 20, 13 );
            this.lblPowerUnit.TabIndex = 24;
            this.lblPowerUnit.Text = "dB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label3.Location = new System.Drawing.Point( 5, 27 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 47, 13 );
            this.label3.TabIndex = 24;
            this.label3.Text = "Reading";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label4.Location = new System.Drawing.Point( 11, 54 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 19, 13 );
            this.label4.TabIndex = 24;
            this.label4.Text = "L0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label5.Location = new System.Drawing.Point( 57, 54 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 19, 13 );
            this.label5.TabIndex = 24;
            this.label5.Text = "L1";
            // 
            // txtPowerOffset_1
            // 
            this.txtPowerOffset_1.Location = new System.Drawing.Point( 47, 70 );
            this.txtPowerOffset_1.Name = "txtPowerOffset_1";
            this.txtPowerOffset_1.Size = new System.Drawing.Size( 36, 20 );
            this.txtPowerOffset_1.TabIndex = 25;
            this.txtPowerOffset_1.Text = "12.5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label6.Location = new System.Drawing.Point( 101, 54 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 19, 13 );
            this.label6.TabIndex = 24;
            this.label6.Text = "L2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.label7.Location = new System.Drawing.Point( 147, 54 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 19, 13 );
            this.label7.TabIndex = 24;
            this.label7.Text = "L3";
            // 
            // txtPowerOffset_2
            // 
            this.txtPowerOffset_2.Location = new System.Drawing.Point( 92, 70 );
            this.txtPowerOffset_2.Name = "txtPowerOffset_2";
            this.txtPowerOffset_2.Size = new System.Drawing.Size( 36, 20 );
            this.txtPowerOffset_2.TabIndex = 25;
            this.txtPowerOffset_2.Text = "12.5";
            // 
            // txtPowerOffset_3
            // 
            this.txtPowerOffset_3.Location = new System.Drawing.Point( 137, 70 );
            this.txtPowerOffset_3.Name = "txtPowerOffset_3";
            this.txtPowerOffset_3.Size = new System.Drawing.Size( 36, 20 );
            this.txtPowerOffset_3.TabIndex = 25;
            this.txtPowerOffset_3.Text = "12.5";
            // 
            // btnSetOffset
            // 
            this.btnSetOffset.Location = new System.Drawing.Point( 178, 59 );
            this.btnSetOffset.Name = "btnSetOffset";
            this.btnSetOffset.Size = new System.Drawing.Size( 43, 34 );
            this.btnSetOffset.TabIndex = 27;
            this.btnSetOffset.Text = "Set Offset";
            this.btnSetOffset.UseVisualStyleBackColor = true;
            this.btnSetOffset.Click += new System.EventHandler( this.btnSetOffset_Click );
            // 
            // PowerMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.gboPower );
            this.Name = "PowerMeter";
            this.Size = new System.Drawing.Size( 228, 102 );
            this.gboPower.ResumeLayout( false );
            this.gboPower.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox gboPower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPowerOffset_3;
        private System.Windows.Forms.TextBox txtPowerOffset_1;
        private System.Windows.Forms.TextBox txtPowerOffset_2;
        private System.Windows.Forms.TextBox txtPowerOffset_0;
        private System.Windows.Forms.Label lblActualPower;
        private System.Windows.Forms.Label lblPowerReading;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPowerUnit;
        private System.Windows.Forms.Button btnSetOffset;
    }
}
