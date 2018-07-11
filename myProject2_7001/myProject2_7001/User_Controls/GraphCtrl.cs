using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Finisar.Controls {
    public partial class GraphCtrl : UserControl {
        ZedGraph.LineItem Line_1;

        public GraphCtrl( ) {
            InitializeComponent( );
        }

        public void InitGraph( string graphTitle, string xAxisTitle, string yAxisTitle ) {
            zedGraphCtrl.GraphPane.Title.Text = graphTitle;
            zedGraphCtrl.GraphPane.XAxis.Title.Text = xAxisTitle;
            zedGraphCtrl.GraphPane.YAxis.Title.Text = yAxisTitle;

            zedGraphCtrl.GraphPane.XAxis.Scale.MinAuto = true;
            zedGraphCtrl.GraphPane.XAxis.Scale.MinAuto = true;
            zedGraphCtrl.GraphPane.YAxis.Type = ZedGraph.AxisType.Linear;
            zedGraphCtrl.GraphPane.YAxis.Scale.MinAuto = true;
            zedGraphCtrl.GraphPane.YAxis.Scale.MaxAuto = true;

            zedGraphCtrl.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedGraphCtrl.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zedGraphCtrl.GraphPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45.0F );

            Line_1 = zedGraphCtrl.GraphPane.AddCurve( "Current Reading", null, Color.Red, ZedGraph.SymbolType.Diamond );
            Line_1.Line.Width = 2;
            zedGraphCtrl.AxisChange( );
            zedGraphCtrl.Invalidate( );
        }


        private void GraphCtrl_SizeChanged( object sender, EventArgs e ) {
            zedGraphCtrl.Width = ( this.Width - 5 );
            zedGraphCtrl.Height = ( this.Height - 5 );
        }

        public void ClearGraph( ) {
            Line_1.Clear( );
            zedGraphCtrl.Invalidate( );
            zedGraphCtrl.AxisChange( );
        }
        public void AddPointToLine( double xValue, double yValue ) {
            Line_1.AddPoint( xValue, yValue );
            zedGraphCtrl.Invalidate( );
            zedGraphCtrl.AxisChange( );
        }
    }
}
