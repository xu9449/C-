

namespace myProject2_7001
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ke2400Ctrl2 = new Finisar.GPIB_Controls.Ke2400Ctrl();
            this.SuspendLayout();
            // 
            // ke2400Ctrl2
            // 
            this.ke2400Ctrl2.ChannelNumber = 0;
            this.ke2400Ctrl2.ComplianceSetpoint = 3.5F;
            this.ke2400Ctrl2.CtrlName = "Keithley Control";
            this.ke2400Ctrl2.GpibAddress = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.ke2400Ctrl2.IsFrontMeasure = true;
            this.ke2400Ctrl2.IsVoltageControl = false;
            this.ke2400Ctrl2.IsVoltageMeasurement = false;
            this.ke2400Ctrl2.Location = new System.Drawing.Point(41, 13);
            this.ke2400Ctrl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ke2400Ctrl2.Name = "ke2400Ctrl2";
            this.ke2400Ctrl2.Size = new System.Drawing.Size(320, 219);
            this.ke2400Ctrl2.TabIndex = 0;
            this.ke2400Ctrl2.Load += new System.EventHandler(this.ke2400Ctrl2_Load);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 268);
            this.Controls.Add(this.ke2400Ctrl2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Finisar.GPIB_Controls.Ke2400Ctrl ke2400Ctrl1;
        private Finisar.GPIB_Controls.Ke2400Ctrl ke2400Ctrl2; //change to public
    }
}