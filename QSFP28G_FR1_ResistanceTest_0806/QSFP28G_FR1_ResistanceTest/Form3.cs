using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace QSFP28G_FR1_ResistanceTest
{
    public partial class Form3 : Form
    {
        public Form1 thisobj2 = null;
        //Form1 f1 = new Form1();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

      
        

        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;     
            myPane.Title.Text = "I-V Curve";
            myPane.XAxis.Title.Text = "I/A";
            myPane.YAxis.Title.Text = "V/V";
            double x, y1;
            PointPairList list1 = new PointPairList();
            //PointPairList list2 = new PointPairList();
            

            for (int i = 0; i < 16; i++)
            {
                x = (double)i;
                y1 = Form1.doubleArray2[i];
                //y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                list1.Add(x, y1);
                //list2.Add(x, y2);
            }
            LineItem myCurve = myPane.AddCurve("Porsche", list1, Color.Red, SymbolType.Diamond);
            //LineItem myCurve2 = myPane.AddCurve("Piper", list2, Color.Blue, SymbolType.Circle);
            zgc.AxisChange();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
            SetSize();
        }
    }

}
