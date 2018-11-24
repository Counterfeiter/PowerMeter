using System;
using HidLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Configuration;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Leistungsmesser_C
{
    public class PowerMeter
    {
        public INA1 VC_Window;
        public INA1_Power P_Window;
        private MDIParent1 mdiparent;

        private HidDevice _device;
        public delegate void ReadHandlerDelegate(HidReport report, int pakete);

        private Byte[] _ser = new Byte[4];
        public Byte[] version = new Byte[2];
        public String nick_name;

        public enum pm_states : int { UNCONNECTED, DISCONNECTED, CONNECTED,AUTHORIZED, SCALE_RECV,PLAY, STOP, RECORD };
        private int _state;

        public float scale_V;
        public float scale_C;
        public float scale_CH;

        //use with scale values to calc the possible resolution and set the rounding
        private int current_rounder = 1;

        public bool hall_active = false;

        public int current_mode = 0;

        public Int32 filter_V;
        public Int32 filter_C;

        private Action _actionAttached = null;
        private Action _actionRemoved = null;

        // Handle Play states
        private bool trigger_active = false;

        private long count_x = 0;
        private long trigger_sample = 0;

        private double  threshold_value = 0;
        private long    record_time = 0;
        private bool    is_trigger = false;

        private int counter_filter = 10;

        private const UInt16 FILTER_DIS = 4;


        public PowerMeter(MDIParent1 mdip, HidDevice dev)
        {
            init(mdip, dev);
        }

        public PowerMeter(MDIParent1 mdip, HidDevice dev, Action _actionAtt, Action _actionRem)
        {
            init(mdip, dev);

            _actionAttached = _actionAtt;
            _actionRemoved = _actionRem;

        }

        ~PowerMeter()  // destructor
        {
            // cleanup statements...
            disconnect();
        }

        private void init(MDIParent1 mdip, HidDevice dev)
        {
            //NativeMethods.HidD_SetNumInputBuffers((int)_device.ReadHandle, 512);

            _state = (int)pm_states.UNCONNECTED;
            _device = dev;
            mdiparent = mdip;

            if (_device == null)
            {
                mdiparent.debug_form.Recived.Text += "Device null!" + "\r\n";
                return;
            }

            mdiparent.debug_form.Recived.Text += "Try to connect" + "\r\n";

            _device.OpenDevice();

            _device.Inserted += DeviceAttachedHandler;
            _device.Removed += DeviceRemovedHandler;

            _device.MonitorDeviceEvents = true;

            _device.ReadReport(OnReport);

        }

        int paketzaehler2 = 0;

        private void OnReport(HidReport report)
        {

            _device.ReadReport(OnReport);

           //var reportAs = _device.ReadReportAsync();            

            if (!_device.IsConnected) { return; }

            paketzaehler2++;

            try
            {
                mdiparent.BeginInvoke(new ReadHandlerDelegate(ReadHandler), new object[] { report, paketzaehler });
            }
            catch { }

            /*if (reportAs != null)
            {
                mdiparent.BeginInvoke(new ReadHandlerDelegate(ReadHandler), new object[] { reportAs, paketzaehler });
            }*/

            
        }

        int paketzaehler = 0;

        private void ReadHandler(HidReport report, int pakete)
        {

            
            //_deviceList[Devices.SelectedIndex].ReadReport(ReadProcess);
            //mdiparent.debug_form.Recived.Text += "recv msg:" + "\r\n";
            //mdiparent.debug_form.Recived.Text += System.Text.Encoding.Default.GetString(report.Data);
            //mdiparent.debug_form.Recived.Text += "\r\n";

            

            parse_tpm2(report.Data, report.Data.Length);

            //MessageBox.Show("Write result: " + System.Text.Encoding.Default.GetString(report.Data));
            //debug_form.Recived.Text += report.Data.Select(d => d.ToString("X2")) + "\r\n";
        }

        public void update_axis()
        {
            if (IsFormOpen())
            {
                VC_Window.zg1.AxisChange();
                VC_Window.zg1.Invalidate();
            }
        }

        public void disconnect()
        {
            _device.CloseDevice();
            if (IsFormOpen())
            {
                VC_Window.Close();
            }
            _state = (int)pm_states.DISCONNECTED;
        }

        

        public HidDevice device
        {
            get { return _device; }
        }

        public int State
        {
            get { return _state; }
        }

        //use delegate in WinForm
        private void DeviceAttachedHandler()
        {

            if (mdiparent.InvokeRequired)
            {
                mdiparent.BeginInvoke(new Action(DeviceAttachedHandler));
                return;
            }
            else
            {
                _state = (int)pm_states.CONNECTED;
                if (_actionAttached != null)
                    _actionAttached();
            }
        }

        //use delegate in WinForm
        private void DeviceRemovedHandler()
        {
            if (mdiparent.InvokeRequired)
            {
                mdiparent.BeginInvoke(new Action(DeviceRemovedHandler));
                return;
            }
            else
            {
                disconnect();
                if (_actionRemoved != null)
                    _actionRemoved();
            }
            
        }

        public bool IsFormOpen()
        {
            if (VC_Window == null)
                return false;
            return VC_Window.IsHandleCreated;
        }



        public bool SetNickName(String name)
        {


            //update trigger source
            if (mdiparent.TextTriggerSource.Text == nick_name)
            {
                mdiparent.TextTriggerSource.Text = name;
            }
            nick_name = name;

            // Open App.Config of executable
            System.Configuration.Configuration config =
             ConfigurationManager.OpenExeConfiguration
                        (Application.ExecutablePath);

            String section = ByteArrayToHexString(_ser);

            // Add an Application Setting.
            config.AppSettings.Settings.Remove(section);
            config.AppSettings.Settings.Add(section, nick_name);
            config.AppSettings.SectionInformation.ForceSave = true;

            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

  

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection(section);

            UpdateNickname();

            return true;
        }

        public static String ByteArrayToHexString(byte[] bytes)
        {
            return "0x" + string.Concat(bytes.Select(b => b.ToString("X2")));
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private static void WriteResult(bool success)
        {
            //MessageBox.Show("Write result: " + success);
        }

        public void StartBootloader()
        {
            var outData = _device.CreateReport();

            outData.ReportId = 0x00;

            byte[] nachricht = { TPM2_BLOCK_START, TPM2_BLOCK_DATAFRAME, 0x00, 0x01, PM_BOOTLOADER, TPM2_BLOCK_END };
            Array.Copy(nachricht, 0, outData.Data, 0, nachricht.Length);

            _device.WriteReport(outData, WriteResult);
        }

        public void write_scale_values(float sc_v = 0.0f, float sc_cc = 0.0f, float sc_ch = 0.0f, int use_current_source = 0)
        {
            var outData = _device.CreateReport();

            byte vv = 0x00;
            byte cc = 0x00;
            byte ch = 0x00;

            byte[] vv_b = new byte[5];
            byte[] cc_b = new byte[5];
            byte[] ch_b = new byte[5];

            if (sc_v == 0.0f)
            {
                //also write 
                vv = 0x01;
            } else {
                vv = 0x03;
            }

            if (sc_cc != 0.0f)
            {
                cc = 0x02;
            }

            if (sc_ch != 0.0f)
            {
                ch = 0x02;
            }

            if(use_current_source == 0) {
                ch |= 0x01;
            }
            else if (use_current_source == 1)
            {
                cc |= 0x01;
            }
            else
            {
                ch |= 0x01;
                cc |= 0x01;
            }

            vv_b = BitConverter.GetBytes(sc_v);
            cc_b = BitConverter.GetBytes(sc_cc);
            ch_b = BitConverter.GetBytes(sc_ch);
            

            outData.ReportId = 0x00;

            byte[] nachricht = { TPM2_BLOCK_START, TPM2_BLOCK_DATAFRAME, 0x00, 0x10, PM_SCALEVALUES, 
                                   vv, vv_b[0],vv_b[1],vv_b[2],vv_b[3],
                                   cc, cc_b[0],cc_b[1],cc_b[2],cc_b[3],
                                   ch, ch_b[0],ch_b[1],ch_b[2],ch_b[3],
                                   TPM2_BLOCK_END };

            Array.Copy(nachricht, 0, outData.Data, 0, nachricht.Length);

            _device.WriteReport(outData, WriteResult);
        }


        private Byte []msg = new Byte[64];

        //private void recv_device_id(Byte[] buffer,int len)
        private void recv_device_id(Byte[] buffer, int len)
        {
            if (len < 6) return;

            Array.Copy(buffer, 0, _ser, 0, 4);
            Array.Copy(buffer, 4, version, 0, 2);

            if (_state == (int)pm_states.CONNECTED)
            {
                _state = (int)pm_states.AUTHORIZED;
            }
            else
            {
                return;
            }

            String serial_number = "0x" + string.Concat(_ser.Select(b => b.ToString("X2")));

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration((Application.ExecutablePath));
            try
            {
                nick_name = config.AppSettings.Settings[serial_number].Value;
            }
            catch
            {
                nick_name = serial_number;
            }

            if (nick_name.Length > 20)
            {
                nick_name = nick_name.Substring(0, 20);
            }

            if (!IsFormOpen())
            {
                VC_Window = new INA1((MDIParent1)mdiparent,this);
                VC_Window.MdiParent = (MDIParent1)mdiparent;
                VC_Window.Show();

                VC_Window.Display_NewRollList();
            }          
        }

        public void UpdateNickname() {
            if (IsFormOpen())
            {
                VC_Window.UpdateNickName();
            }
        }
        private void recv_scale_values(Byte[] buffer, int len)
        {

            if (len < 15) return;

            scale_V     = BitConverter.ToSingle(buffer, 1);
            scale_C     = BitConverter.ToSingle(buffer, 1 + 5);
            scale_CH    = BitConverter.ToSingle(buffer, 1 + 5 + 5);

            if ((buffer[10] & 0x04) > 0)
            {
                if (hall_active == false)
                {
                    hall_active = true;
                    UpdateNickname();
                }
                else
                {
                    hall_active = true;
                }

            }
            else
            {
                if (hall_active == true)
                {
                    hall_active = false;
                    UpdateNickname();
                }
                else
                {
                    hall_active = false;
                }
            }

            if ((buffer[10] & 0x01) > 0 && (buffer[5] & 0x01) > 0)
            {
                current_mode = 2;
            }
            else if((buffer[10] & 0x01) > 0 && (buffer[5] & 0x01) <= 0) { 
                current_mode = 0;
            } else {
                current_mode = 1;
            }

            if (_state == (int)pm_states.AUTHORIZED)
            {
                UpdateNickname();  
                _state = (int)pm_states.SCALE_RECV;
            }


            float scale_current = 0.0f;

            if (hall_active)
            {
                scale_current = scale_CH;
            }
            else
            {
                scale_current = scale_C;
            }

            if (scale_current * 4000 > 0.0001)
            {
                current_rounder = 7;
            }
            else if (scale_current * 4000 > 0.001)
            {
                current_rounder = 6;
            }
            else if (scale_current * 4000 > 0.01)
            {
                current_rounder = 5;
            }
            else if (scale_current * 4000 > 0.1)
            {
                current_rounder = 4;
            }
            else if (scale_current * 4000 > 1.0)
            {
                current_rounder = 3;
            }
            else if (scale_current * 4000 > 10.0)
            {
                current_rounder = 2;
            }
            else if (scale_current * 4000 > 100.0)
            {
                current_rounder = 1;
            }
            else if (scale_current * 4000 > 1000.0)
            {
                current_rounder = 0;
            }

            //callback für scale values revc!

        }

        private void ClosePowerChart()
        {
            if (P_Window != null)
            {
                if (P_Window.IsHandleCreated)
                {
                    P_Window.Close();
                }
            }
        }

        public void OpenPowerChart()
        {
            if (P_Window != null)
            {
                if (!P_Window.IsHandleCreated)
                {
                    P_Window = new INA1_Power(VC_Window);
                    P_Window.MdiParent = (MDIParent1)mdiparent;
                    P_Window.Show();
                }
            }
            else
            {
                P_Window = new INA1_Power(VC_Window);
                P_Window.MdiParent = (MDIParent1)mdiparent;
                P_Window.Show();
            }

            P_Window.Display_NewPointList(count_x - trigger_sample, current_rounder);
        }

        public bool IsRecordedDataAvailable()
        {
            return trigger_active;
        }

        public bool IsInaLableVisible()
        {
            return VC_Window.text.IsVisible;
        }

        public bool Ready_for_Action()
        {
            if(_state == (int)pm_states.SCALE_RECV || _state == (int)pm_states.STOP ||
                _state == (int)pm_states.RECORD || _state == (int)pm_states.PLAY)
            {
                return true;
            }
            return false;
        }

        public bool SetPlay()
        {
            if (_state == (int)pm_states.SCALE_RECV || _state == (int)pm_states.STOP)
            {
                _state = (int)pm_states.PLAY;

                ClosePowerChart();

                count_x = 0;

                trigger_active = false;

                if (!IsFormOpen())
                {
                    VC_Window = new INA1((MDIParent1)mdiparent,this);
                    VC_Window.MdiParent = (MDIParent1)mdiparent;
                    VC_Window.Show();
                }

                VC_Window.roll_spannung.Clear();
                VC_Window.roll_strom.Clear();

                VC_Window.Display_NewRollList();

                return true;
            }
            return false;
        }

        public bool SetStop()
        {
            if (_state == (int)pm_states.SCALE_RECV || _state == (int)pm_states.STOP ||
                _state == (int)pm_states.RECORD || _state == (int)pm_states.PLAY)
            {
                if (_state == (int)pm_states.RECORD && trigger_active == true)
                {
                    VC_Window.Display_NewPointList(count_x - trigger_sample);
                }
                _state = (int)pm_states.STOP;
                return true;
            }
            return false;
        }

        public void SetRecord(long record_t, double threshold_v, bool is_trig)
        {
            if (_state == (int)pm_states.STOP || _state == (int)pm_states.PLAY)
            {
                _state = (int)pm_states.RECORD;

                ClosePowerChart();

                count_x = 0;

                record_time = record_t * 1000;

                trigger_sample = 0;

                is_trigger = is_trig;

                if (threshold_v == 0.0)
                {
                    trigger_active = true;
                }
                else
                {
                    trigger_active = false;
                }

                if (threshold_v < 0) threshold_value = threshold_v * (-1.0);
                else threshold_value = threshold_v;

                if (IsFormOpen())
                {
                    VC_Window.roll_spannung.Clear();
                    VC_Window.roll_strom.Clear();

                    VC_Window.Display_NewRollList();
                }
            }
        }

        private void recv_new_data(Byte[] buffer,int len)
        {
            if (!(_state == (int)pm_states.PLAY || _state == (int)pm_states.RECORD))
            {
                return;
            }

            float scale_current = 0.0f;

            if (hall_active)
            {
                scale_current = scale_CH;
            }
            else
            {
                scale_current = scale_C;
            }

            for (int i = 0; i < len; i += 4)
            {
                UInt16 voltage = BitConverter.ToUInt16(buffer, i);
                Int16 current = BitConverter.ToInt16(buffer, i + 2);

                paketzaehler++;

                if (0 == (paketzaehler % 1000))
                {
                    String timeStamp = DateTime.Now.ToString("mm:ss.ffff: ");

                    mdiparent.debug_form.Recived.Text += timeStamp + paketzaehler.ToString() +  "\r\n";

                }

                if (count_x==0)
                {
                    filter_V = (voltage << FILTER_DIS);
                    filter_C = (current << FILTER_DIS);
                }

                double cur_pos = 0;

                if (current < 0) cur_pos = (current * (-1) * scale_current);
                else cur_pos = current * scale_current;

                if (trigger_active == true)
                {
                    if(IsFormOpen()) {
                        VC_Window.SaveData_U[count_x - trigger_sample] = Math.Round(voltage * scale_V, 2);
                        VC_Window.SaveData_I[count_x - trigger_sample] = Math.Round(current * scale_current, current_rounder);
                    }
                }

                filter_V = filter_V - (filter_V >> FILTER_DIS) + (Int32)voltage;
                filter_C = filter_C - (filter_C >> FILTER_DIS) + (Int32)current;

                double temp_u = (filter_V >> FILTER_DIS) * scale_V;
                double temp_i = (filter_C >> FILTER_DIS) * scale_current;

                if(IsFormOpen()) {
                    if (VC_Window.zg1.GraphPane.YAxis.Scale.Max < (temp_u * 1.2)) VC_Window.zg1.GraphPane.YAxis.Scale.Max = (temp_u * 1.2);
                    if (VC_Window.zg1.GraphPane.Y2Axis.Scale.Max < (temp_i * 1.15)) VC_Window.zg1.GraphPane.Y2Axis.Scale.Max = (temp_i * 1.15);
                    if (VC_Window.zg1.GraphPane.Y2Axis.Scale.Min > (temp_i * 1.15)) VC_Window.zg1.GraphPane.Y2Axis.Scale.Min = (temp_i * 1.15);
                }


                if (counter_filter == 0)
                {
                    if(IsFormOpen()) {
                        VC_Window.roll_spannung.Add(count_x, Math.Round(temp_u, 2));
                        VC_Window.roll_strom.Add(count_x, Math.Round(temp_i, current_rounder));
                    }

                    counter_filter = 9;
                }
                else counter_filter--;

                count_x++;

                if (cur_pos >= threshold_value && trigger_active == false && _state == (int)pm_states.RECORD && is_trigger)
                {
                    trigger_active = true;
                    mdiparent.toolStripStatusLabel.Text = "recording... trigger started";
                    //MessageBox.Show(Convert.ToString(aktueller_pos_strom) + ">" + Convert.ToString(threshold_value));
                    trigger_sample = count_x;
                }

                if (_state == (int)pm_states.RECORD && record_time <= (count_x - trigger_sample) && trigger_active == true)
                {
                    mdiparent.toolStripButton2_Click(null, null);
                }
            }
        }

        /// <summary>
        /// ///////////TPM2 RECV HANDLE//////////////////////
        /// </summary>
        enum tpm2 : int { IDLE, STARTB, STARTB2, STARTB3, STARTB4, STARTB5, STARTB6, ENDB };			//tpm2 states

        private Byte TPM2_BLOCK_START       = 0xC9;
        private Byte TPM2_BLOCK_DATAFRAME   = 0xDA;
        private Byte TPM2_BLOCK_END         = 0x36;

        private Byte PM_DATAFRAME       = 0xDA;
        private Byte PM_SCALEVALUES     = 0x5C;
        private Byte PM_SENDSCALE       = 0x5D;
        private Byte PM_HELLO           = 0x11;
        private Byte PM_START           = 0x5A;
        private Byte PM_STOP            = 0x50;
        private Byte PM_BOOTLOADER      = 0xB0;

        private Byte TPM2_ACK = 0xAC;

        private int tpm2state = (int)tpm2.IDLE;
        private int framesize = 0;
        private int count = 0;

        private void parse_tpm2(Byte[] buffer, int len)
        {
            for (int i = 0; i < len; i++)
            {
                Byte buf = buffer[i];

                if (tpm2state == (int)tpm2.STARTB4)
                {
                    if (count < framesize)
                    {
                        msg[count] = buf;
                        count++;
                    }
                    else
                        tpm2state = (int)tpm2.ENDB;
                }

                //check for start- and sizebyte
                if (tpm2state == (int)tpm2.IDLE && buf == TPM2_BLOCK_START)
                {
                    tpm2state = (int)tpm2.STARTB;
                    continue;
                }

                if (tpm2state == (int)tpm2.STARTB && buf == TPM2_BLOCK_DATAFRAME)
                {
                    tpm2state = (int)tpm2.STARTB2;
                    continue;
                }

                if (tpm2state == (int)tpm2.STARTB2)
                {
                    framesize = (int)buf << 8;
                    tpm2state = (int)tpm2.STARTB3;
                    continue;
                }

                if (tpm2state == (int)tpm2.STARTB3)
                {
                    framesize += (int)buf;
                    if (framesize <= 64)
                    {
                        count = 0;
                        tpm2state = (int)tpm2.STARTB4;
                    }
                    else tpm2state = (int)tpm2.IDLE;

                    continue;

                }

                //check end byte
                if (tpm2state == (int)tpm2.ENDB)
                {
                    if (buf == TPM2_BLOCK_END)
                    {
                        Byte[] temp_msg = new Byte[64];
                        count--;
                        Array.Copy(msg, 1, temp_msg, 0, count);

                        if (count >= 4 && msg[0] == PM_DATAFRAME)
                        {
                            recv_new_data(temp_msg, count);
                            //mdiparent.debug_form.Recived.Text += count.ToString();
                        } else if(count >= 15 && msg[0] == PM_SCALEVALUES)
                        {
                            recv_scale_values(temp_msg, count);
                        } else if (count >= 6 && msg[0] == PM_HELLO)
                        {
                            recv_device_id(temp_msg, count);
                        }
                    }

                    tpm2state = (int)tpm2.IDLE;
                }
            }
        }

    } //class
} //namespace
