using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.VisualStyles;

namespace Leistungsmesser_C
{
    public partial class Stromscale : Form
    {

        private struct hall_current_sensors
        {
            public string shown_name;
            public float scale_value;
        }

        //TODO: test
        // Vref +- 1.25 * Iact / Iset
        // e.g. Vref +- 1.25 * 100 A / 200 A -> 200 A HALL Sensor
        // Hardware schematic gain / 2
        // ---> +- 1.25 * Iact / Iset / 2
        // 3.3 V -> 4096 digits
        static readonly hall_current_sensors[] listbox_hall_content = new hall_current_sensors[] {
            new hall_current_sensors { shown_name = "HTFS 200-P (±200 A)", scale_value = 0.2578125F },
            new hall_current_sensors { shown_name = "HTFS 400-P (±400 A)", scale_value = 0.2578125F * 2.0F },
            new hall_current_sensors { shown_name = "HTFS 600-P (±600 A)", scale_value = 0.2578125F * 3.0F },
            new hall_current_sensors { shown_name = "HTFS 800-P (±800 A)", scale_value = 0.2578125F * 4.0F }
        };

        private MDIParent1 MDIParent;
        private PowerMeter pm;

        public Stromscale(MDIParent1 MDIP, PowerMeter powermeter)
        {
            InitializeComponent();
            MDIParent = MDIP;
            pm = powermeter;
        }

        private void Stromscale_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            MDIParent.Refresh();
        }

        private void Stromscale_Load(object sender, EventArgs e)
        {
            this.Text = pm.VC_Window.Text;
            scale_cc.Text = pm.scale_C.ToString();
            scale_ch.Text = pm.scale_CH.ToString();
            scale_v.Text = pm.scale_V.ToString();
            textBoxNickname.Text = pm.nick_name;

            List<string> MyList = new List<string>();
            foreach (var hallsensor in listbox_hall_content)
            {
                MyList.Add(hallsensor.shown_name);
            }

            hallsensorlistbox.DataSource = MyList;

            switch (pm.current_mode)
            {
                case 0:
                    HallradioButton.Checked = true;
                    break;
                case 1:
                    ShuntradioButton.Checked = true;
                    break;
                case 2:
                    BothradioButton.Checked = true;
                    break;
                default:
                    HallradioButton.Checked = false;
                    ShuntradioButton.Checked = false;
                    ShuntradioButton.Checked = false;
                    break;
            }


        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (pm.nick_name != textBoxNickname.Text)
            {
                pm.SetNickName(textBoxNickname.Text);
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

        private void scale_cc_TextChanged(object sender, EventArgs e)
        {
            if (scale_cc.BackColor == Color.Red || scale_cc.BackColor == Color.Green)
            {
                scale_cc.BackColor = SystemColors.Window;
            }
        }

        private void scale_ch_TextChanged(object sender, EventArgs e)
        {
            if (scale_ch.BackColor == Color.Red || scale_ch.BackColor == Color.Green)
            {
                scale_ch.BackColor = SystemColors.Window;
            }
        }

        private void scale_v_TextChanged(object sender, EventArgs e)
        {
            if (scale_v.BackColor == Color.Red || scale_v.BackColor == Color.Green)
            {
                scale_v.BackColor = SystemColors.Window;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ShuntOptions.Enabled = true;
            HallOptions.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ShuntOptions.Enabled = true;
            HallOptions.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ShuntOptions.Enabled = false;
            HallOptions.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ResistanceradioButton_CheckedChanged(null, null);
        }

        private void ResistanceradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ResistanceradioButton.Checked)
            {
                textBoxResistance.Enabled = true;
                textBoxDINCurrent.Enabled = false;
                textBoxDINCurrent.BackColor = SystemColors.Window;
                textBoxDINVoltage.Enabled = false;
                textBoxDINVoltage.BackColor = SystemColors.Window;

                double res;

                if (double.TryParse(textBoxResistance.Text.Replace('.', ',').Replace("mΩ", "").Replace(" ", ""), out res))
                {
                    float scale = (float)((0.04 / (res / 1000)) / 4000); //10 uV LSB -> 0.04 V / 4000
                    scale_cc.Text = scale.ToString();

                    textBoxResistance.BackColor = SystemColors.Window;
                }
                else
                {
                    textBoxResistance.BackColor = Color.Red;
                }
            }
            else
            {
                textBoxResistance.Enabled = false;
                textBoxResistance.BackColor = SystemColors.Window;
                textBoxDINCurrent.Enabled = true;
                textBoxDINVoltage.Enabled = true;


                double strom_s;
                double spannung_s;

                bool DINCokay = double.TryParse(textBoxDINCurrent.Text.Replace('.', ',').Replace("A", "").Replace(" ", ""), out strom_s);
                bool DINVokay = double.TryParse(textBoxDINVoltage.Text.Replace('.', ',').Replace("mV", "").Replace(" ", ""), out spannung_s);

                if (DINCokay)
                    textBoxDINCurrent.BackColor = SystemColors.Window;
                else
                    textBoxDINCurrent.BackColor = Color.Red;

                if (DINVokay)
                    textBoxDINVoltage.BackColor = SystemColors.Window;
                else
                    textBoxDINVoltage.BackColor = Color.Red;

                if (DINCokay && DINVokay)
                {
                    float scale = (float)(((0.04 / (spannung_s / 1000)) * strom_s) / 4000); //10 uV LSB -> 0.04 V / 4000
                    scale_cc.Text = scale.ToString();
                }
            }
        }

        private void strom_TextChanged(object sender, EventArgs e)
        {
            string unit = "A";
            textBoxDINCurrent.TextChanged -= strom_TextChanged; //detach event handler
            textBoxDINCurrent.Text = textBoxDINCurrent.Text.Replace(unit, "").Replace(" ", "") + " " + unit;
            ResistanceradioButton_CheckedChanged(null, null);
            textBoxDINCurrent.TextChanged += strom_TextChanged; //attach event handler

            //correct cursor also
            if (textBoxDINCurrent.Text.Length <= unit.Length + 2)
                textBoxDINCurrent.Select(1, 0);
        }

        private void spannung_TextChanged(object sender, EventArgs e)
        {
            string unit = "mV";
            textBoxDINVoltage.TextChanged -= spannung_TextChanged; //detach event handler
            textBoxDINVoltage.Text = textBoxDINVoltage.Text.Replace(unit, "").Replace(" ", "") + " " + unit;
            ResistanceradioButton_CheckedChanged(null, null);
            textBoxDINVoltage.TextChanged += spannung_TextChanged; //attach event handler

            //correct cursor also
            if (textBoxDINVoltage.Text.Length <= unit.Length + 2)
                textBoxDINVoltage.Select(1, 0);
        }

        private void resist_TextChanged(object sender, EventArgs e)
        {
            string unit = "mΩ";
            textBoxResistance.TextChanged -= resist_TextChanged; //detach event handler
            textBoxResistance.Text = textBoxResistance.Text.Replace(unit, "").Replace(" ", "") + " " + unit;
            ResistanceradioButton_CheckedChanged(null, null);
            textBoxResistance.TextChanged += resist_TextChanged; //attach event handler

            //correct cursor also
            if (textBoxResistance.Text.Length <= unit.Length + 2)
                textBoxResistance.Select(1, 0);
        }

        private void hallsensorlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            scale_ch.Text = listbox_hall_content[hallsensorlistbox.SelectedIndex].scale_value.ToString();
        }

        private void buttonLoadDefault_Click(object sender, EventArgs e)
        {
            float default_v = 0.0040206F; //4 mV LSB -> but small difference because of GND protection resistor and INA219 supply current
            scale_v.Text = default_v.ToString();
        }

        private void buttonWriteCC_Click(object sender, EventArgs e)
        {
            scale_cc.BackColor = Color.Red;

            float strom_s;
            byte[] strom_b = new byte[5];

            scale_cc.Text = scale_cc.Text.Replace('.', ',');

            int current_source = GetCurrentSource();

            if (float.TryParse(scale_cc.Text, out strom_s))
            {

                if (DialogResult.Yes == MessageBox.Show(this,
                        "Scale value shunt current changing to " + Convert.ToString(strom_s) + " ?", "Change Value?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    pm.write_scale_values(0.0f, strom_s, 0.0f, current_source);
                }
            }
            else
            {
                MessageBox.Show("No numeric value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWriteCH_Click(object sender, EventArgs e)
        {
            scale_ch.BackColor = Color.Red;

            float strom_s;
            byte[] strom_b = new byte[5];

            scale_ch.Text = scale_ch.Text.Replace('.', ',');

            int current_source = GetCurrentSource();

            if (float.TryParse(scale_ch.Text, out strom_s))
            {

                if (DialogResult.Yes == MessageBox.Show(this,
                        "Scale value HALL current changing to " + Convert.ToString(strom_s) + " ?", "Change Value?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    pm.write_scale_values(0.0f, 0.0f, strom_s, current_source);
                }
            }
            else
            {
                MessageBox.Show("No numeric value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWriteV_Click(object sender, EventArgs e)
        {
            scale_v.BackColor = Color.Red;

            float volt_s;
            byte[] strom_b = new byte[5];

            int current_source = GetCurrentSource();

            if (float.TryParse(scale_v.Text.Replace('.', ','), out volt_s))
            {
                if (DialogResult.Yes == MessageBox.Show(this,
                        "Scale value voltage changing to " + Convert.ToString(volt_s) + " ?", "Change Value?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    pm.write_scale_values(volt_s, 0.0f, 0.0f, current_source);
                }
            }
            else
            {
                MessageBox.Show("No numeric value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCurrentSource()
        {
            if (ShuntradioButton.Checked == true)
            {
                return 1;
            }
            else if (BothradioButton.Checked == true)
            {
                return 2;
            }

            return 0;
        }
    }
}
