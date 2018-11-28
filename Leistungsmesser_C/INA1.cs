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
    public struct UI
    {
        public double U;
        public double I;
    }

    public partial class INA1 : Form
    {
        private MDIParent1 MDIParent;
        public PowerMeter pm;

        public INA1(MDIParent1 MDIP, PowerMeter powermeter)
        {
            MDIParent = MDIP;
            pm = powermeter;
            InitializeComponent();
        }

        PointPair rms_first_pt = new PointPair();
        PointPair rms_end_pt = new PointPair();

        public TextObj text;
        public int rms_drag = 0;

        //public PointPairList voltage_daten = new PointPairList();

        public RollingPointPairList roll_spannung = new RollingPointPairList(1000);
        public RollingPointPairList roll_strom = new RollingPointPairList(1000);

        private PointPairList ppl_u = new PointPairList();
        private PointPairList ppl_i = new PointPairList();

        public List<UI> UI_List = new List<UI>();

        private LineItem myCurve;
        private LineItem myCurve2;

        private bool just_opend = true;

        private void Set_Size()
        {
            Point loc = new Point(0, 0);
            Size size = new Size(0, 0);
            zg1.Location = loc;
            size.Width = this.ClientRectangle.Width;
            size.Height = this.ClientRectangle.Height;
            zg1.Size = size;

        }

        public void Display_NewPointList(long counter) {
            myCurve.Clear();
            myCurve2.Clear();
            roll_spannung.Clear();
            roll_strom.Clear();
            zg1.GraphPane.GraphObjList.Clear();

            zg1.GraphPane.YAxis.Scale.Max = 0.0;
            zg1.GraphPane.Y2Axis.Scale.Max = 0.0;
            zg1.GraphPane.Y2Axis.Scale.Min = 0;

            int i = 0;
            foreach (UI ui in UI_List)
            {
                if (zg1.GraphPane.YAxis.Scale.Max < (ui.U * 1.2)) zg1.GraphPane.YAxis.Scale.Max = (ui.U * 1.2);
                if (zg1.GraphPane.Y2Axis.Scale.Max < (ui.I * 1.15)) zg1.GraphPane.Y2Axis.Scale.Max = (ui.I * 1.15);
                if (zg1.GraphPane.Y2Axis.Scale.Min > (ui.I * 1.15)) zg1.GraphPane.Y2Axis.Scale.Min = (ui.I * 1.15);

                ppl_u.Add(i , ui.U);
                ppl_i.Add(i , ui.I);

                i++;
            }

            myCurve = zg1.GraphPane.AddCurve("", ppl_u, Color.Green, SymbolType.None);
            myCurve2 = zg1.GraphPane.AddCurve("", ppl_i, Color.Red, SymbolType.None);


            myCurve2.IsY2Axis = true;

            myCurve.IsY2Axis = false;
            //myCurve.Symbol.Fill = new Fill(Color.White);

            zg1.ZoomOutAll(zg1.GraphPane);

            text.IsVisible = false;

            zg1.AxisChange();
            zg1.Refresh();
            zg1.Invalidate();

            just_opend = false;
        }

        public void Display_NewRollList()
        {
            if (just_opend == false)
            {
                myCurve.Clear();
                myCurve2.Clear();
                roll_spannung.Clear();
                roll_strom.Clear();

                zg1.GraphPane.YAxis.Scale.Max = 0.1;
                zg1.GraphPane.Y2Axis.Scale.Max = 0.001;
                zg1.GraphPane.Y2Axis.Scale.Min = 0;

                zg1.GraphPane.GraphObjList.Clear();

                myCurve = zg1.GraphPane.AddCurve("", roll_spannung, Color.Green, SymbolType.None);
                myCurve2 = zg1.GraphPane.AddCurve("", roll_strom, Color.Red, SymbolType.None);

                myCurve.IsY2Axis = false;
                myCurve2.IsY2Axis = true;

                zg1.ZoomOutAll(zg1.GraphPane);

                text.IsVisible = false;

                zg1.AxisChange();
                zg1.Refresh();
                zg1.Invalidate();
            }

            just_opend = false;
        }

        public void UpdateNickName()
        {
            String temp_text;
            if (pm.hall_active == true)
            {
                temp_text = "hall sensor active";
            }
            else
            {
                temp_text = "shunt sensor active";
            }
            this.Text = pm.nick_name + " - " + temp_text + " - firmware version: " + pm.version[0].ToString() + "." + pm.version[1].ToString();
            zg1.GraphPane.Title.Text = "Probe \"" + pm.nick_name + "\" Measurement";
        }

        private void INA1_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.Clone() as Icon;


            GraphPane myPane = zg1.GraphPane;

            myCurve = myPane.AddCurve("Voltage", roll_spannung, Color.Green, SymbolType.None);
            myCurve2 = myPane.AddCurve("Current", roll_strom, Color.Red, SymbolType.None);
            // Set the titles and axis labels
            UpdateNickName();
            myPane.XAxis.Title.Text = "t/ms";
            myPane.YAxis.Title.Text = "U/V";

            myCurve2.IsY2Axis = true;

            myCurve.IsY2Axis = false;

            myPane.Y2Axis.IsVisible = true;
            myPane.Y2Axis.Title.Text = "I/A";

            // Fill the symbols with white
            //myCurve.Symbol.Fill = new Fill(Color.White);
            //myCurve2.Symbol.Fill = new Fill(Color.White);

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Green;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Green;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 0.1;

            myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Red;
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;

            myPane.Y2Axis.Scale.Min = 0;
            myPane.Y2Axis.Scale.Max = 0.001;
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
            
            //add text here for later use
            text = new TextObj("xxx", 0.05, 0.95, CoordType.PaneFraction, AlignH.Left, AlignV.Bottom);
            zg1.GraphPane.GraphObjList.Add(text);
            text.FontSpec.Fill.IsVisible = false;
            text.FontSpec.Size = 10;
            text.FontSpec.IsBold = true;
            text.IsVisible = false;



            // Tell ZedGraph to calculate the axis ranges
            // Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
            // up the proper scrolling parameters
            zg1.AxisChange();
            // Make sure the Graph gets redrawn
            zg1.Invalidate();


            Set_Size();
        }

        private void INA1_Resize(object sender, EventArgs e)
        {
            Set_Size();
        }

        private void INA1_Paint(object sender, PaintEventArgs e)
        {
            zg1.AxisChange();
            zg1.Refresh();
            zg1.Invalidate();
        }

        private void INA1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MDIParent.play_mode == true)
            //    e.Cancel = true;
        }

        private string zg1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
			PointPair pt = curve[iPt];

            if(curve.Color == Color.Green)
			    return pt.X.ToString() + " ms  " + pt.Y.ToString() + " V";
            else if(curve.Color == Color.Red)
                return pt.X.ToString() + " ms  " + pt.Y.ToString() + " A";
            else if(curve.Color == Color.Blue)
                return pt.X.ToString() + " ms  " + pt.Y.ToString() + " W";



            return null;
        }

        private bool zg1_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            CurveItem nearestCurve;
            int nearestID;

            if (rms_drag == 5)
            {
                if (rms_first_pt.X < rms_end_pt.X)
                {
                    double Spannung = 0;
                    double Strom = 0;
                    double Leistung = 0;
                    double Spannung_rms = 0;
                    double Strom_rms = 0;
                    double Leistung_rms = 0;


                    text.IsVisible = true;
                    zg1.GraphPane.GraphObjList.Add(text);
                    text.Location.X = e.X / zg1.GraphPane.Rect.Width;
                    text.Location.Y = e.Y / zg1.GraphPane.Rect.Height;

                    //MessageBox.Show(text.Location.X.ToString() + "  " + text.Location.Y.ToString());

                    for (int i = Convert.ToInt32(rms_first_pt.X); i < Convert.ToInt32(rms_end_pt.X + 1); i++)
                    {
                        Strom += UI_List[i].I;
                        Spannung += UI_List[i].U;
                        Leistung += UI_List[i].I * UI_List[i].U;

                        Strom_rms += Math.Pow(UI_List[i].I, 2);
                        Spannung_rms += Math.Pow(UI_List[i].U, 2);
                        Leistung_rms += Math.Pow((UI_List[i].I * UI_List[i].U), 2);

                    }

                    double samples = rms_end_pt.X - rms_first_pt.X + 1;

                    Strom /= samples;
                    Spannung /= samples;
                    Leistung /= samples;

                    Strom_rms /= samples;
                    Spannung_rms /= samples;
                    Leistung_rms /= samples;

                    Strom_rms = Math.Sqrt(Strom_rms);
                    Spannung_rms = Math.Sqrt(Spannung_rms);
                    Leistung_rms = Math.Sqrt(Leistung_rms);


                    text.Text = "Average values from " + rms_first_pt.X.ToString() + " ms to " + rms_end_pt.X.ToString() + " ms\r\n" +
                                                    Convert.ToString(Math.Round(Spannung, 2)) + " V avg    " + Convert.ToString(Math.Round(Spannung_rms, 2)) + " V RMS\r\n" +
                                                    Convert.ToString(Math.Round(Strom, pm.current_rounder)) + " A avg    " + Convert.ToString(Math.Round(Strom_rms, pm.current_rounder)) + " A RMS\r\n" +
                                                    Convert.ToString(Math.Round(Leistung, pm.current_rounder)) + " W avg    " + Convert.ToString(Math.Round(Leistung_rms, pm.current_rounder)) + " W RMS\r\n";

                    rms_drag = 6;

                    //MDIParent.toolStripStatusLabel.Text = "textobject was inserted to probe 1";
        
                }
                else
                {
                    text.IsVisible = false;
                    rms_drag = 0;
                    //MDIParent.toolStripStatusLabel.Text = "pause";
                }

                zg1.Invalidate();
            }
            
            if (rms_drag == 1)
            {


                if (zg1.GraphPane.FindNearestPoint(new PointF(e.X, e.Y), out nearestCurve, out nearestID))
                {
                    rms_drag = 3;
                    rms_first_pt.X = nearestCurve.Points[nearestID].X;
                }
            }
            else if (rms_drag == 3)
            {


                if (zg1.GraphPane.FindNearestPoint(new PointF(e.X, e.Y), out nearestCurve, out nearestID))
                {
                    rms_drag = 5;
                    rms_end_pt.X = nearestCurve.Points[nearestID].X;
                }
            }
            

            return default(bool);
        }




    }
}
