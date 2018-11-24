using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Leistungsmesser_C
{
    public partial class INA1_Power : Form
    {
        private INA1 ina;

        public INA1_Power(INA1 ina_x)
        {
            ina = ina_x; 
            InitializeComponent();
        }

        private PointPairList ppl_p = new PointPairList();

        private LineItem myCurve;

        private void Set_Size()
        {
            Point loc = new Point(0, 0);
            Size size = new Size(0, 0);
            zg1.Location = loc;
            size.Width = this.ClientRectangle.Width;
            size.Height = this.ClientRectangle.Height;
            zg1.Size = size;

        }

        public void Display_NewPointList(long counter, int rounder) {
            UpdateNickName();
            myCurve.Clear();

            double temp;

            zg1.GraphPane.YAxis.Scale.Max = 0;
            zg1.GraphPane.YAxis.Scale.Min = 0;

            for (int i = 0; i < counter; i++)
            {
                temp = ina.SaveData_U[i] * ina.SaveData_I[i];

                if (zg1.GraphPane.YAxis.Scale.Max < (temp * 1.15)) zg1.GraphPane.YAxis.Scale.Max = (temp * 1.15);
                if (zg1.GraphPane.YAxis.Scale.Min > (temp * 1.15)) zg1.GraphPane.YAxis.Scale.Min = (temp * 1.15);

                ppl_p.Add(i, Math.Round(temp, rounder));
            }

            //myCurve2 = zg1.GraphPane.AddCurve("", ppl_i, Color.Red, SymbolType.None);

            //myCurve = zg1.GraphPane.AddCurve("", ppl_u, Color.Green, SymbolType.None);
            //myCurve.Symbol.Fill = new Fill(Color.White);
            //myCurve2.IsY2Axis = true;

            //myCurve.IsY2Axis = false;
            //myCurve.Symbol.Fill = new Fill(Color.White);

            zg1.ZoomOutAll(zg1.GraphPane);

            zg1.AxisChange();
            zg1.Refresh();
            zg1.Invalidate();
        }

        private void INA1_Power_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.Clone() as Icon;

            GraphPane myPane = zg1.GraphPane;

            myCurve = myPane.AddCurve("Power", ppl_p, Color.Blue, SymbolType.None);
            // Set the titles and axis labels
            myPane.Title.Text = "Probe 1 Power";
            myPane.XAxis.Title.Text = "t/ms";
            myPane.YAxis.Title.Text = "P/W";

            myCurve.IsY2Axis = false;

            // Fill the symbols with white
            //myCurve.Symbol.Fill = new Fill(Color.White);
            //myCurve2.Symbol.Fill = new Fill(Color.White);

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;

            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 0;
            // Manually set the axis range
            //myPane.YAxis.Scale.Min = 0;
            //myPane.YAxis.Scale.Max = 0;

            myPane.XAxis.Scale.MajorStepAuto = true;
            //myPane.XAxis.Scale.MajorStep = 200
            //myPane.XAxis.Scale.MinorStep = 50
            myPane.XAxis.Scale.MinGrace = 0;
            myPane.XAxis.Scale.MaxGrace = 0;

            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0F);

            // Enable scrollbars if needed
            zg1.IsShowHScrollBar = true;
            //zg1.IsShowVScrollBar = True
            zg1.IsAutoScrollRange = true;
            //zg1.IsScrollY2 = True

            zg1.IsShowPointValues = true;

            //myPane.GraphObjList.Add(Mittelwerte_Darstellung)



            // Tell ZedGraph to calculate the axis ranges
            // Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
            // up the proper scrolling parameters
            zg1.AxisChange();
            // Make sure the Graph gets redrawn
            zg1.Invalidate();


            Set_Size();
        }

        private void INA1_Power_Resize(object sender, EventArgs e)
        {
            Set_Size();
        }

        private void INA1_Power_Paint(object sender, PaintEventArgs e)
        {
            zg1.AxisChange();
            zg1.Refresh();
            zg1.Invalidate();
        }

        public void UpdateNickName()
        {
            String temp_text;
            if (ina.pm.hall_active == true)
            {
                temp_text = "hall sensor active";
            }
            else
            {
                temp_text = "shunt sensor active";
            }
            this.Text = ina.pm.nick_name + " - " + temp_text + " - firmware version: " + ina.pm.version[0].ToString() + "." + ina.pm.version[1].ToString();
            zg1.GraphPane.Title.Text = "Probe \"" + ina.pm.nick_name + "\" Measurement";
        }

        private string zg1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];

            if (curve.Color == Color.Green)
                return pt.X.ToString() + " ms  " + pt.Y.ToString() + " V";
            else if (curve.Color == Color.Red)
                return pt.X.ToString() + " ms  " + pt.Y.ToString() + " A";
            else if (curve.Color == Color.Blue)
                return pt.X.ToString() + " ms  " + pt.Y.ToString() + " W";

            return null;
        }

        private void zg1_Load(object sender, EventArgs e)
        {

        }

    }
}
