namespace Project1_Pomodoro
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pomoVal = new System.Windows.Forms.NumericUpDown();
            this.btStarted = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.breakVal = new System.Windows.Forms.NumericUpDown();
            this.btReset = new System.Windows.Forms.Button();
            this.pomoTimer = new System.Windows.Forms.Timer(this.components);
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pomoVal)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.breakVal)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 73);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(276, 178);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pomoVal);
            this.flowLayoutPanel2.Controls.Add(this.btStarted);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(134, 172);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // pomoVal
            // 
            this.pomoVal.Location = new System.Drawing.Point(3, 3);
            this.pomoVal.Name = "pomoVal";
            this.pomoVal.Size = new System.Drawing.Size(131, 22);
            this.pomoVal.TabIndex = 0;
            this.pomoVal.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.pomoVal.ValueChanged += new System.EventHandler(this.pomoVal_ValueChanged);
            // 
            // btStarted
            // 
            this.btStarted.Location = new System.Drawing.Point(3, 31);
            this.btStarted.Name = "btStarted";
            this.btStarted.Size = new System.Drawing.Size(131, 136);
            this.btStarted.TabIndex = 1;
            this.btStarted.Text = "Start";
            this.btStarted.UseVisualStyleBackColor = true;
            this.btStarted.Click += new System.EventHandler(this.btStarted_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.breakVal);
            this.flowLayoutPanel3.Controls.Add(this.btReset);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(143, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(123, 167);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // breakVal
            // 
            this.breakVal.Location = new System.Drawing.Point(3, 3);
            this.breakVal.Name = "breakVal";
            this.breakVal.Size = new System.Drawing.Size(120, 22);
            this.breakVal.TabIndex = 0;
            this.breakVal.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.breakVal.ValueChanged += new System.EventHandler(this.breakVal_ValueChanged);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(3, 31);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(120, 136);
            this.btReset.TabIndex = 1;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // pomoTimer
            // 
            this.pomoTimer.Tick += new System.EventHandler(this.pomoTimer_Tick);
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(0, 12);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(280, 41);
            this.progBar.TabIndex = 1;
            this.progBar.Click += new System.EventHandler(this.progBar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Pomodoro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pomoVal)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.breakVal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.NumericUpDown pomoVal;
        private System.Windows.Forms.Button btStarted;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.NumericUpDown breakVal;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Timer pomoTimer;
        private System.Windows.Forms.ProgressBar progBar;
    }
}

