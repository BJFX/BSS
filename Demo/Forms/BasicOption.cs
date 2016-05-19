using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Survey.Forms
{
    public partial class BasicOption : Office2007Form
    {
        public BasicOption()
        {
            InitializeComponent();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (SerialPort.GetPortNames().All(t => t != GpsPortBox.Text.ToUpper()))
            {
                MessageBox.Show("端口不存在！");
                return;
            }
            if (!GpsBaudRate.Items.Contains(GpsBaudRate.Text))
            {
                MessageBox.Show("无效的波特率！");
                return;
            }
            BasicConf.GetInstance().SetCommGPS(GpsPortBox.Text);
            BasicConf.GetInstance().SetGPSDataRate(GpsBaudRate.Text);
            
            if (MainForm.mf.gpscore.ReturnSerialPort()!=null&&MainForm.mf.gpscore.ReturnSerialPort().IsOpen)
            {
                MainForm.mf.gpscore.Stop();
            }
            if (MainForm.mf.gpscore.Init(new SerialPort(GpsPortBox.Text, int.Parse(GpsBaudRate.Text))))
            {
                if (MainForm.mf.gpscore.Start())
                {
                    MessageBox.Show("端口已开启！");
                    Hide();
                    return;
                }
            }
            MessageBox.Show("打开GPS端口失败！");
        }

        private void BasicOption_Load(object sender, EventArgs e)
        {
            GpsPortBox.Items.Clear();
            if (SerialPort.GetPortNames().Count()>0)
                GpsPortBox.Items.AddRange(SerialPort.GetPortNames());
            GpsPortBox.Text = BasicConf.GetInstance().GetCommGPS();
            GpsBaudRate.Text = BasicConf.GetInstance().GetGPSDataRate();
        }

        private void BasicOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
