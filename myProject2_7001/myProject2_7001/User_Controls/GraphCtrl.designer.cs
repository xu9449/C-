namespace Finisar.Controls {
    partial class GraphCtrl {
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
            this.zedGraphCtrl = new ZedGraph.ZedGraphControl( );
            this.SuspendLayout( );
            // 
            // zedGraphCtrl
            // 
            this.zedGraphCtrl.Font = new System.Drawing.Font( "Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
            this.zedGraphCtrl.Location = new System.Drawing.Point( 0, 0 );
            this.zedGraphCtrl.Margin = new System.Windows.Forms.Padding( 4 );
            this.zedGraphCtrl.Name = "zedGraphCtrl";
            this.zedGraphCtrl.ScrollGrace = 0D;
            this.zedGraphCtrl.ScrollMaxX = 0D;
            this.zedGraphCtrl.ScrollMaxY = 0D;
            this.zedGraphCtrl.ScrollMaxY2 = 0D;
            this.zedGraphCtrl.ScrollMinX = 0D;
            this.zedGraphCtrl.ScrollMinY = 0D;
            this.zedGraphCtrl.ScrollMinY2 = 0D;
            this.zedGraphCtrl.Size = new System.Drawing.Size( 818, 563 );
            this.zedGraphCtrl.TabIndex = 28;
            // 
            // GraphCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.zedGraphCtrl );
            this.Name = "GraphCtrl";
            this.Size = new System.Drawing.Size( 818, 563 );
            this.SizeChanged += new System.EventHandler( this.GraphCtrl_SizeChanged );
            this.ResumeLayout( false );

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphCtrl;
    }
}
