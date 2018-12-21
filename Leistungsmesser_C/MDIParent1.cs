using HidLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;


namespace Leistungsmesser_C
{
    public partial class MDIParent1 : Form
    {

        private HidDevice[] _deviceList;

        private Stromscale stromscale;

        private Info_Display info_box;

        List<PowerMeter> powermeter = new List<PowerMeter>();

        public static String SoftwareVersion = "v1.6.2";

        static String Banner_Window_Text = "Power Meter " + SoftwareVersion;

        public enum gui_states : int { UNREADY,READY,PLAY,RECORD,STOP,ACTIV_DATA};
        private int gui_state = (int) gui_states.UNREADY;


        private Encoding enc = Encoding.GetEncoding(28591);


        PowerMeter pm_trigger_source = null;
           
        private void Stop_Funktion()
        {
            timer1.Enabled = false;

            SetGUIOptions((int)gui_states.STOP);

        }

        private void Play_Funktion()
        {
            timer1.Enabled = true;

            SetGUIOptions((int)gui_states.PLAY);

        }

        public MDIParent1()
        {
            InitializeComponent();
            
        }


        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int min_data = Int32.MaxValue;

            foreach (var pw in powermeter)
            {
                if (pw.VC_Window.UI_List.Count < min_data)
                {
                    min_data = pw.VC_Window.UI_List.Count;
                }
            }

            if(min_data == 0 || min_data == Int32.MaxValue)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Title = "Save to CSV file...";
            saveFileDialog.Filter = "csv file (*.csv)|*.csv";
            saveFileDialog.DefaultExt = "csv";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK && saveFileDialog.FileName != "")
            {

                using (var w = new System.IO.StreamWriter(saveFileDialog.FileName))
                {

                    string delimiter = ";";

                    //generate headline
                    string line = "\"t/ms\"" + delimiter;

                    foreach (var pw in powermeter)
                    {
                        line += "\"" + pw.nick_name.Replace("\"", "\"\"") + " U/V" + "\"";
                        line += delimiter;
                        line += "\"" + pw.nick_name.Replace("\"", "\"\"") + " I/A" + "\"";
                        line += delimiter;
                    }
                    w.WriteLine(line);

                    //generate data points
                    for (int i = 0; i < min_data; i++)
                    {
                        line = i.ToString();

                        line += delimiter;

                        foreach (var pw in powermeter)
                        {
                            line += pw.VC_Window.UI_List[i].U.ToString("F");
                            line += delimiter;
                            line += pw.VC_Window.UI_List[i].I.ToString("F");
                            line += delimiter;
                        }

                        w.WriteLine(line);
                    }
                }
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            this.Text = Banner_Window_Text;

            gui_state = (int)gui_states.UNREADY;
        }

        public void SetGUIOptions(int option)
        {

            bool a_pm_is_ready = false;

            switch (option)
            {
                case (int)gui_states.UNREADY:
                    
                    
                    foreach (PowerMeter client in powermeter)
                    {
                        if((int)PowerMeter.pm_states.SCALE_RECV == client.State || 
                            (int)PowerMeter.pm_states.PLAY == client.State ||
                            (int)PowerMeter.pm_states.STOP == client.State ||
                            (int)PowerMeter.pm_states.RECORD == client.State)
                        {
                            a_pm_is_ready = true;
                        }

                    }

                    if (!a_pm_is_ready)
                    {
                        gui_state = (int)gui_states.UNREADY;

                        toolStripStatusLabel.Text = "no device is ready";

                        PlayStripButton.Enabled = false;
                        StopStripButton.Enabled = false;
                        RecordStripButton.Enabled = false;
                        //start menu
                        startToolStripMenuItem.Enabled = false;
                        watchingToolStripMenuItem.Enabled = false;
                        stopToolStripMenuItem.Enabled = false;
                        recodingToolStripMenuItem.Enabled = false;
                        
                        ScaleMenu.Enabled = false;

                        softwareUpdateToolStripMenuItem.Enabled = false;

                        calctoolStripButton.Enabled = false;
                        powerChartToolStripMenuItem.Enabled = false;
                        rMSCalculatorToolStripMenuItem.Enabled = false;
                        powertoolStripButton.Enabled = false;

                        saveAsImageToolStripMenuItem.Enabled = false;
                        saveasimagetoolStripButton6.Enabled = false;

                        saveAsToolStripMenuItem.Enabled = false;
                        saveToolStripButton.Enabled = false;
                    }
                    break;
                case (int)gui_states.READY:
                    if (gui_state == (int)gui_states.UNREADY)
                    {
                        foreach (PowerMeter client in powermeter)
                        {
                            if((int)PowerMeter.pm_states.SCALE_RECV == client.State || 
                                (int)PowerMeter.pm_states.PLAY == client.State ||
                                (int)PowerMeter.pm_states.STOP == client.State ||
                                (int)PowerMeter.pm_states.RECORD == client.State)
                            {
                                a_pm_is_ready = true;
                            }

                        }

                        if (a_pm_is_ready)
                        {

                            gui_state = (int)gui_states.READY;

                            toolStripStatusLabel.Text = "at minimum one device is ready";
                            PlayStripButton.Enabled = true;
                            StopStripButton.Enabled = true;
                            RecordStripButton.Enabled = true;

                            //start menu
                            startToolStripMenuItem.Enabled = true;
                            watchingToolStripMenuItem.Enabled = true;
                            stopToolStripMenuItem.Enabled = true;
                            recodingToolStripMenuItem.Enabled = true;

                            ScaleMenu.Enabled = true;

                            softwareUpdateToolStripMenuItem.Enabled = true;

                            calctoolStripButton.Enabled = false;
                            powerChartToolStripMenuItem.Enabled = false;
                            rMSCalculatorToolStripMenuItem.Enabled = false;
                            powertoolStripButton.Enabled = false;

                            saveAsImageToolStripMenuItem.Enabled = false;
                            saveasimagetoolStripButton6.Enabled = false;

                            saveAsToolStripMenuItem.Enabled = false;
                            saveToolStripButton.Enabled = false;
                        }
                    }
                    break;
                case (int)gui_states.STOP:
                    if (gui_state == (int)gui_states.PLAY || gui_state == (int)gui_states.RECORD)
                    {
                        bool recordeddata = false;
                        foreach (PowerMeter client in powermeter)
                        {
                            client.SetStop();
                            if (client.IsRecordedDataAvailable())
                            {
                                recordeddata = true;
                            }
                        }

                        gui_state = (int)gui_states.STOP;

                        toolStripStatusLabel.Text = "all devices are stopped";

                        timer1.Enabled = false;

                        PlayStripButton.Enabled = true;
                        StopStripButton.Enabled = true;
                        RecordStripButton.Enabled = true;

                        //start menu
                        startToolStripMenuItem.Enabled = true;
                        watchingToolStripMenuItem.Enabled = true;
                        stopToolStripMenuItem.Enabled = true;
                        recodingToolStripMenuItem.Enabled = true;


                        startToolStripMenuItem.Enabled = true;
                        watchingToolStripMenuItem.Enabled = true;
                        recodingToolStripMenuItem.Enabled = true;

                        ScaleMenu.Enabled = true;

                        softwareUpdateToolStripMenuItem.Enabled = true;

                        if (recordeddata)
                        {
                            calctoolStripButton.Enabled = true;
                            powerChartToolStripMenuItem.Enabled = true;
                            rMSCalculatorToolStripMenuItem.Enabled = true;
                            powertoolStripButton.Enabled = true;
                            saveAsToolStripMenuItem.Enabled = true;
                            saveToolStripButton.Enabled = true;
                        }
                        else
                        {
                            calctoolStripButton.Enabled = false;
                            powerChartToolStripMenuItem.Enabled = false;
                            rMSCalculatorToolStripMenuItem.Enabled = false;
                            powertoolStripButton.Enabled = false;
                        }

                        saveAsImageToolStripMenuItem.Enabled = true;
                        saveasimagetoolStripButton6.Enabled = true;
                    }
                    
                    break;

                case (int)gui_states.PLAY:
                    if (gui_state == (int)gui_states.STOP || gui_state == (int)gui_states.READY)
                    {
                        foreach (PowerMeter client in powermeter)
                        {
                            client.SetPlay();
                        }

                        gui_state = (int)gui_states.PLAY;

                        toolStripStatusLabel.Text = "start displaying data...";

                        timer1.Enabled = true;

                        if (null != Application.OpenForms["Stromscale"])
                            stromscale.Close();

                        PlayStripButton.Enabled = false;
                        StopStripButton.Enabled = true;
                        RecordStripButton.Enabled = true;

                        //start menu
                        startToolStripMenuItem.Enabled = true;
                        watchingToolStripMenuItem.Enabled = false;
                        stopToolStripMenuItem.Enabled = true;
                        recodingToolStripMenuItem.Enabled = true;

                        ScaleMenu.Enabled = false;

                        softwareUpdateToolStripMenuItem.Enabled = false;

                        calctoolStripButton.Enabled = false;
                        powerChartToolStripMenuItem.Enabled = false;
                        rMSCalculatorToolStripMenuItem.Enabled = false;
                        powertoolStripButton.Enabled = false;

                        saveAsImageToolStripMenuItem.Enabled = false;
                        saveasimagetoolStripButton6.Enabled = false;

                        saveAsToolStripMenuItem.Enabled = false;
                        saveToolStripButton.Enabled = false;
                    }

                    break;

                case (int)gui_states.RECORD:
                    if (gui_state == (int)gui_states.STOP || gui_state == (int)gui_states.READY || gui_state == (int)gui_states.PLAY)
                    {
                        long record_time;
                        double threshold_value;

                        if (long.TryParse(toolStripRecordTime.Text, out record_time) && record_time != 0 && double.TryParse(toolStriptrigger_threshold.Text, out threshold_value))
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("Please insert a valid record time and threshold!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool trigger_ready = false;

                        if (threshold_value != 0.0)
                        {
                            foreach (PowerMeter client in powermeter)
                            {
                                if (client == pm_trigger_source)
                                {
                                    if (client.Ready_for_Action())
                                    {
                                        trigger_ready = true;
                                    }
                                }
                            }

                            if(trigger_ready == false) {
                                MessageBox.Show("Please select a valid trigger source!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }



                        gui_state = (int)gui_states.RECORD;

                        toolStripStatusLabel.Text = "start recording...";

                        foreach (PowerMeter client in powermeter)
                        {
                            client.SetStop();
                            if (client == pm_trigger_source)
                            {
                                client.SetRecord(record_time, threshold_value, true);
                            }
                            else
                            {
                                client.SetRecord(record_time, threshold_value, false);
                            }
                        }

                        timer1.Enabled = true;

                        if (null != Application.OpenForms["Stromscale"])
                            stromscale.Close();

                        PlayStripButton.Enabled = false;
                        StopStripButton.Enabled = true;
                        RecordStripButton.Enabled = false;

                        //start menu
                        startToolStripMenuItem.Enabled = true;
                        watchingToolStripMenuItem.Enabled = false;
                        stopToolStripMenuItem.Enabled = true;
                        recodingToolStripMenuItem.Enabled = false;

                        ScaleMenu.Enabled = false;

                        softwareUpdateToolStripMenuItem.Enabled = false;

                        calctoolStripButton.Enabled = false;
                        powerChartToolStripMenuItem.Enabled = false;
                        rMSCalculatorToolStripMenuItem.Enabled = false;
                        powertoolStripButton.Enabled = false;

                        saveAsImageToolStripMenuItem.Enabled = false;
                        saveasimagetoolStripButton6.Enabled = false;

                        saveAsToolStripMenuItem.Enabled = false;
                        saveToolStripButton.Enabled = false;
                    }

                    break;
            }
        }

        private PowerMeter GetPowerMeter_ActiveMdi(bool VCWindow)
        {
            // Determine the active child form.
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form....
             if (activeChild != null)
            {
                try
                {
                    foreach (PowerMeter client in powermeter)
                    {
                        if (activeChild == client.VC_Window && VCWindow)
                        {

                            return client;
                        }
                        if (activeChild == client.P_Window && !VCWindow)
                        {

                            return client;
                        }
                    }
                }
                catch
                {
                   
                }
             }

            return null;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PowerMeter client = GetPowerMeter_ActiveMdi(true);
            if (client != null)
            {
                Form currentForm = Application.OpenForms["Stromscale"];

                if (currentForm != null)
                {
                    stromscale.Close();
                }


                stromscale = new Stromscale(this, client);
                stromscale.MdiParent = this;
                stromscale.Show();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Play_Funktion();
        }

        public void toolStripButton2_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            Stop_Funktion();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SetGUIOptions((int)gui_states.RECORD);
        }

        private void softwareUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PowerMeter client = GetPowerMeter_ActiveMdi(true);
            if (client == null)
                client = GetPowerMeter_ActiveMdi(false);

            if (client == null)
            {
                return;
            }
          

            MessageBox.Show("Please start now the Atmel Flip application. You could download the software from the Atmel Webpage. Load then the PowerMeter.hex file and click \"Start Application\".", "Hint",MessageBoxButtons.OK, MessageBoxIcon.Information);

            client.StartBootloader();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            foreach (PowerMeter client in powermeter)
            {
                client.update_axis();
            }
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (PowerMeter client in powermeter)
            {
                client.disconnect();
            }
        }

        private void watchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(null, null);
        }

        public void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(null, null);
        }

        private void recodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(null, null);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveAsToolStripMenuItem_Click(null, null);
        }

        private void powertoolStripButton_Click(object sender, EventArgs e)
        {
            PowerMeter client = GetPowerMeter_ActiveMdi(true);

            if (client == null || !client.IsRecordedDataAvailable())
            {
                return;
            }

            client.OpenPowerChart();
        }

        private void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {
            if ((this.ActiveMdiChild is INA1 || this.ActiveMdiChild is INA1_Power))// && !play_mode)
            {
                //saveAsImageToolStripMenuItem.Enabled = true;
                //saveasimagetoolStripButton6.Enabled = true;
            }
            else
            {
                //saveAsImageToolStripMenuItem.Enabled = false;
                //saveasimagetoolStripButton6.Enabled = false;
            }

            if ((this.ActiveMdiChild is INA1))// && record_data)
            {
                /*calctoolStripButton.Enabled = true;
                powerChartToolStripMenuItem.Enabled = true;
                rMSCalculatorToolStripMenuItem.Enabled = true;
                powertoolStripButton.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripButton.Enabled = true;*/
            }
            else
            {
                /*calctoolStripButton.Enabled = false;
                powerChartToolStripMenuItem.Enabled = false;
                rMSCalculatorToolStripMenuItem.Enabled = false;
                powertoolStripButton.Enabled = false;*/
            }
            if (this.ActiveMdiChild is INA1)
            {
                //if (ina_1.rms_drag > 0 && ina_1.rms_drag != 6)
                //{
                //    ina_1.rms_drag = 0;
                //}
            }

            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != Application.OpenForms["Info_Display"])
            {
                info_box.Activate();
            }
            else
            {
                info_box = new Info_Display();
                info_box.MdiParent = this;
                info_box.Show();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PowerMeter client = GetPowerMeter_ActiveMdi(true);
            if (client != null)
            {
                client.VC_Window.zg1.ZoomOut(client.VC_Window.zg1.GraphPane);
            }

            client = GetPowerMeter_ActiveMdi(false);
            if (client != null)
            {
                client.P_Window.zg1.ZoomOut(client.P_Window.zg1.GraphPane);
            }


        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            PowerMeter client = GetPowerMeter_ActiveMdi(true);
            if (client != null)
            {
                client.VC_Window.zg1.ZoomOutAll(client.VC_Window.zg1.GraphPane);
            }

            client = GetPowerMeter_ActiveMdi(false);
            if (client != null)
            {
                client.P_Window.zg1.ZoomOutAll(client.P_Window.zg1.GraphPane);
            }
        }

        private void calctoolStripButton_Click(object sender, EventArgs e)
        {
            PowerMeter client = GetPowerMeter_ActiveMdi(true);
            
            if (client == null || !client.IsRecordedDataAvailable()) 
            {
                return;
            }
            if(client.IsInaLableVisible())
            {
                toolStripStatusLabel.Text = "pause";
                client.VC_Window.text.IsVisible = false;
                client.VC_Window.zg1.Invalidate();
                client.VC_Window.rms_drag = 0;
            }
            else
            {
                client.VC_Window.rms_drag = 1;
                toolStripStatusLabel.Text = "Click on the chart on the first sample, then click the stop sample and chose the text position with the last click";
            }
               
        }

        private void saveasimagetoolStripButton6_Click(object sender, EventArgs e)
        {
            PowerMeter client = GetPowerMeter_ActiveMdi(true);
            if (client != null)
            {
                client.VC_Window.zg1.SaveAs();
            }
            client = GetPowerMeter_ActiveMdi(false);
            if (client != null)
            {
                client.P_Window.zg1.SaveAs();
            }
           
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveasimagetoolStripButton6_Click(null, null);
        }

        private void rMSCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calctoolStripButton_Click(null, null);
        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            
            _deviceList = HidDevices.Enumerate(0x03EB, 0x2402).ToArray();
            //_deviceList = HidDevices.Enumerate().ToArray();


            bool one_divice_ready = false;
            //delete possible unconnected devices
            for (int i = 0; i < powermeter.Count; i++)
            {
                if (powermeter[i].State == (int)PowerMeter.pm_states.DISCONNECTED)
                {
                    Console.WriteLine("delete a unconnected device");
                    powermeter.RemoveAt(i);
                } else if(powermeter[i].Ready_for_Action())
                {
                    one_divice_ready = true;
                }
            }

            if (one_divice_ready)
            {
                SetGUIOptions((int)gui_states.READY);
            }
            else
            {
                SetGUIOptions((int)gui_states.UNREADY);
            }


            if (_deviceList.Length > 0)
            {
                foreach (HidDevice new_client in _deviceList)
                {
                    bool device_in_list = false;
                    for (int i = 0; i < powermeter.Count; i++)
                    {
                        if (new_client.DevicePath == powermeter[i].device.DevicePath)
                        {
                            device_in_list = true;
                        }
                    }

                    if (device_in_list == false)
                    {
                        PowerMeter temp = new PowerMeter(this, new_client, DeviceAttachedHandler, DeviceRemovedHandler);

                        powermeter.Add(temp);

                        Console.WriteLine("add a new device");
                    }
                }

            }

        }

        private void DeviceAttachedHandler()
        {
            Console.WriteLine("Device attached.");
        }

        private void DeviceRemovedHandler()
        {
            Console.WriteLine("Device removed.");

        }

        private void probetoolStripComboBox_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Click(object sender, EventArgs e)
        {

        }

        private void search_powermeter_Click(object sender, EventArgs e)
        {
            timer2_Tick(null, null);
        }

        private void toolStripButtonSetTriggerS_Click(object sender, EventArgs e)
        {
            if (toolStripButtonSetTriggerS.Text == "Set Trigger Source:")
            {
                pm_trigger_source = GetPowerMeter_ActiveMdi(true);
                if (pm_trigger_source != null)
                {
                    TextTriggerSource.Text = pm_trigger_source.nick_name;
                    toolStripButtonSetTriggerS.Text = "Rst Trigger Source:";
                }
            }
            else
            {
                TextTriggerSource.Text = "";
                pm_trigger_source = null;
                toolStripButtonSetTriggerS.Text = "Set Trigger Source:";
            }
        }

        private void powerChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            powertoolStripButton_Click(null, null);
        }
    }
}
