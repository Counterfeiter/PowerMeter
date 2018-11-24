using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Leistungsmesser_C
{
    public partial class Stromscale : Form
    {

        private MDIParent1 MDIParent;
        private PowerMeter pm;

        private CalcStrom calc_strom;

        public Stromscale(MDIParent1 MDIP, PowerMeter powermeter)
        {
            InitializeComponent();
            MDIParent = MDIP;
            pm = powermeter;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            scale_cc.BackColor = Color.Red;

            float strom_s;
            byte[] strom_b = new byte[5];

            scale_cc.Text = scale_cc.Text.Replace('.', ',');

            int current_source = 0;

            if(radioButton2.Checked == true) {
                current_source = 1;
            } else if(radioButton3.Checked == true) {
                current_source = 2;
            }

            if (float.TryParse(scale_cc.Text, out strom_s))
            {

                if (DialogResult.Yes == MessageBox.Show(this, "Scale current value shunt changing to " + Convert.ToString(strom_s) + " ?", "Change Value?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    pm.write_scale_values(0.0f, strom_s, 0.0f,current_source);
                }
            } else {
                MessageBox.Show("No numeric value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            scale_ch.BackColor = Color.Red;

            float strom_s;
            byte[] strom_b = new byte[5];

            scale_ch.Text = scale_ch.Text.Replace('.', ',');

            int current_source = 0;

            if (radioButton2.Checked == true)
            {
                current_source = 1;
            }
            else if (radioButton3.Checked == true)
            {
                current_source = 2;
            }

            if (float.TryParse(scale_ch.Text, out strom_s))
            {

                if (DialogResult.Yes == MessageBox.Show(this, "Scale current value HALL changing to " + Convert.ToString(strom_s) + " ?", "Change Value?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    pm.write_scale_values(0.0f, 0.0f, strom_s, current_source);
                }
            }
            else
            {
                MessageBox.Show("No numeric value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calc_Click(object sender, EventArgs e)
        {
            if (null != Application.OpenForms["CalcStrom"])
            {
                //calc_strom.Visible = true;
                calc_strom.Activate();
            }
            else
            {
                calc_strom = new CalcStrom(this);
                calc_strom.MdiParent = MDIParent;
                calc_strom.Show();
            }
        }

        private void Stromscale_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != Application.OpenForms["CalcStrom"])
            {
                calc_strom.Close();
            }
        }

        private void Stromscale_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            MDIParent.Refresh();
        }

        public void SetNewINACurrent(String scalevalue)
        {
            scale_cc.Text = scalevalue;
        }

        private void Stromscale_Load(object sender, EventArgs e)
        {
            this.Text = pm.VC_Window.Text;
            scale_cc.Text = pm.scale_C.ToString();
            scale_ch.Text = pm.scale_CH.ToString();
            scale_v.Text = pm.scale_V.ToString();
            textBox1.Text = pm.nick_name;

            switch (pm.current_mode)
            {
                case 0:
                    radioButton1.Checked = true;
                    break;
                case 1:
                    radioButton2.Checked = true;
                    break;
                case 2:
                    radioButton3.Checked = true;
                    break;
                default:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton2.Checked = false;
                    break;
            }

            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            scale_v.BackColor = Color.Red;

            float volt_s;
            byte[] strom_b = new byte[5];

            scale_v.Text = scale_v.Text.Replace('.', ',');

            int current_source = 0;

            if (radioButton2.Checked == true)
            {
                current_source = 1;
            }
            else if (radioButton3.Checked == true)
            {
                current_source = 2;
            }

             if (float.TryParse(scale_v.Text, out volt_s))
            {
                if (DialogResult.Yes == MessageBox.Show(this, "Scale current value voltage changing to " + Convert.ToString(volt_s) + " ?", "Change Value?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    pm.write_scale_values(volt_s,0.0f,0.0f,current_source);
                }
            }
            else
            {
                MessageBox.Show("No numeric value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (pm.nick_name != textBox1.Text)
            {
                pm.SetNickName(textBox1.Text);
            }
        }

        private void scale_cc_TextChanged(object sender, EventArgs e)
        {
            if (scale_cc.BackColor == Color.Red || scale_cc.BackColor == Color.Green)
            {
                scale_cc.BackColor = Color.White;
            }
        }

        private void Check_Values_Tick(object sender, EventArgs e)
        {
            float value;
            if (scale_cc.BackColor == Color.Red)
            {
                if (float.TryParse(scale_cc.Text, out value))
                {
                    if (value == pm.scale_C)
                    {
                        scale_cc.BackColor = Color.Green;
                    }
                }
            }

            if (scale_ch.BackColor == Color.Red)
            {
                if (float.TryParse(scale_ch.Text, out value))
                {
                    if (value == pm.scale_CH)
                    {
                        scale_ch.BackColor = Color.Green;
                    }
                }
            }

            if (scale_v.BackColor == Color.Red)
            {
                if (float.TryParse(scale_v.Text, out value))
                {
                    if (value == pm.scale_V)
                    {
                        scale_v.BackColor = Color.Green;
                    }
                }
            }
        }

        private void scale_ch_TextChanged(object sender, EventArgs e)
        {
            if (scale_ch.BackColor == Color.Red || scale_ch.BackColor == Color.Green)
            {
                scale_ch.BackColor = Color.White;
            }
        }

        private void scale_v_TextChanged(object sender, EventArgs e)
        {
            if (scale_v.BackColor == Color.Red || scale_v.BackColor == Color.Green)
            {
                scale_v.BackColor = Color.White;
            }
        }

    }
}
