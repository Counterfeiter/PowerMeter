using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Leistungsmesser_C
{
    public partial class CalcStrom : Form
    {
        Stromscale strom_menu;

        public CalcStrom(Stromscale strom_m)
        {
            InitializeComponent();
            strom_menu = strom_m;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                resist.Enabled = false;
                strom.Enabled = true;
                spannung.Enabled = true;
            }
            else
            {
                resist.Enabled = false;
                strom.Enabled = true;
                spannung.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                resist.Enabled = false;
                strom.Enabled = true;
                spannung.Enabled = true;
            }
            else
            {
                resist.Enabled = false;
                strom.Enabled = true;
                spannung.Enabled = true;
            }
        }

        private void CalcStrom_Load(object sender, EventArgs e)
        {
 
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            double scale;

            if (radioButton1.Checked)
            {
                resist.Enabled = false;
                strom.Enabled = true;
                spannung.Enabled = true;

                double strom_s;
                double spannung_s;

                if (double.TryParse(strom.Text.Replace('.', ','), out strom_s) && double.TryParse(spannung.Text.Replace('.', ','), out spannung_s))
                {
                    scale = ((0.04 / (spannung_s / 1000)) * strom_s) / 4000;
                    scaleBox.Text = Convert.ToString(Math.Round(scale, 7));

                }
            }
            else
            {

                double res;

                if (double.TryParse(resist.Text.Replace('.', ','), out res))
                {
                    scale = (0.04 / (res/1000)) / 4000;
                    scaleBox.Text = Convert.ToString(Math.Round(scale, 7));
                }

                resist.Enabled = true;
                strom.Enabled = false;
                spannung.Enabled = false;
            }
        }



        private void strom_TextChanged(object sender, EventArgs e)
        {
            double strom_s;
            double spannung_s;

            double scale;

            if (double.TryParse(strom.Text.Replace('.', ','), out strom_s) && double.TryParse(spannung.Text.Replace('.', ','), out spannung_s))
            {
                scale = ((0.04 / (spannung_s / 1000)) * strom_s) / 4000;
                scaleBox.Text = Convert.ToString(Math.Round(scale,7));
                
            }
        }

        private void spannung_TextChanged(object sender, EventArgs e)
        {
            double strom_s;
            double spannung_s;

            double scale;

            if (double.TryParse(strom.Text.Replace('.', ','), out strom_s) && double.TryParse(spannung.Text.Replace('.', ','), out spannung_s))
            {
                scale = ((0.04 / (spannung_s / 1000)) * strom_s) / 4000;
                scaleBox.Text = Convert.ToString(Math.Round(scale, 7));

            }
        }

        private void resist_TextChanged(object sender, EventArgs e)
        {
            double res;

            double scale;

            if (double.TryParse(resist.Text.Replace('.', ','), out res))
            {
                scale = (0.04 / (res / 1000)) / 4000;
                scaleBox.Text = Convert.ToString(Math.Round(scale, 7));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            strom_menu.SetNewINACurrent(scaleBox.Text);
            this.Close();
        }
    }
}
