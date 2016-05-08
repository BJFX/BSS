using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Survey.Forms
{
    public partial class ParaForm : Office2007Form
    {
        public BSSParameter Highpara = new BSSParameter(true);
        public BSSParameter Lowpara = new BSSParameter(false);
        public bool CurrentType = false;
        public ParaForm()
        {
            InitializeComponent();
        }

        public void Show(bool type)//1:high,0:low
        {
            BSSParameter para = null;
            if (NetEngine.bConnect)
            {
                CurrentType = type;
                
                if (CurrentType)
                {
                    this.Text = "设置高频声纳参数";
                    RangeInput.MaxValue = 100;
                    para = Highpara;
                    if (MainForm.mf.netcore.SendCommand(Command.GetHighParaCMD()) == false)
                    {
                        MainForm.mf.CmdWindow.DisplayAns("无法得到最新高频参数：" + MainForm.mf.netcore.Status);
                        this.Text = "设置高频声纳参数" + "-无法得到最新高频参数";
                    }
                }
                else
                {
                    this.Text = "设置低频声纳参数";
                    RangeInput.MaxValue = 200;
                    para = Lowpara;
                    if (MainForm.mf.netcore.SendCommand(Command.GetLowParaCMD()) == false)
                    {
                        MainForm.mf.CmdWindow.DisplayAns("无法得到最新低频参数：" + MainForm.mf.netcore.Status);
                        this.Text = "设置低频声纳参数" + "-无法得到最新低频参数";
                    }
                }
                
            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
                return;
            }
            //得到参数，显示UI
            this.Show();
            
            
            //显示参数
            RangeInput.Value = para.Range;
            TvbG.Value = para.TvgG;
            PortBandWidth.Value = (int)para.PortBandWidth;
            StartBandWidth.Value = (int)para.StarBoardBandWidth;

        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {

            if (NetEngine.bConnect)
            {
                MainForm.mf.CmdWindow.Show();
                BSSParameter para = null;
                if (CurrentType)
                {
                    para = Highpara;
                }
                else
                {
                    para = Lowpara;
                }   
                para.Range = (ushort)RangeInput.Value;
                para.TvgG = (short)TvbG.Value;
                para.PortBandWidth = (uint)PortBandWidth.Value;
                para.StarBoardBandWidth = (uint)StartBandWidth.Value;
                if (CurrentType)
                {

                    MainForm.mf.CmdWindow.DisplayCommand("下发命令：设置高频声纳工作参数");

                    if (MainForm.mf.netcore.SendCommand(Command.SetupHighBSS(para)) == false)
                    {
                        MainForm.mf.CmdWindow.DisplayAns("下发命令不成功：" + MainForm.mf.netcore.Status);
                    }
                    else
                    {
                        MessageBox.Show("设置高频声纳工作参数成功！");
                    }
                }
                else
                {

                    MainForm.mf.CmdWindow.DisplayCommand("下发命令：设置低频声纳工作参数");

                    if (MainForm.mf.netcore.SendCommand(Command.SetupLowBSS(para)) == false)
                    {
                        MainForm.mf.CmdWindow.DisplayAns("下发命令不成功：" + MainForm.mf.netcore.Status);
                    }
                    else
                    {
                        MessageBox.Show("设置低频声纳工作参数成功！");
                    }
                }
            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }

        private void ParaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
