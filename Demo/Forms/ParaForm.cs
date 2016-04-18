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
        public BSSParameter Highpara = new BSSParameter();
        public BSSParameter Lowpara = new BSSParameter();
        public bool CurrentType = false;
        public ParaForm()
        {
            InitializeComponent();
        }

        public void Show(bool type)//1:high,0:low
        {
            if (NetEngine.bConnect)
            {
                CurrentType = type;
                //MainForm.mf.CmdWindow.Show();
                if (CurrentType)
                {
                    if (MainForm.mf.netcore.SendCommand(Command.GetHighParaCMD()) == false)
                    {
                        MainForm.mf.CmdWindow.DisplayAns("无法得到最新高频参数：" + MainForm.mf.netcore.Status);
                        return;
                    }
                }
                else
                {
                    if (MainForm.mf.netcore.SendCommand(Command.GetLowParaCMD()) == false)
                    {
                        MainForm.mf.CmdWindow.DisplayAns("无法得到最新低频参数：" + MainForm.mf.netcore.Status);
                        return;
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
            if (CurrentType)
                this.Text = "设置高频声纳参数";
            else
            {
                this.Text = "设置低频声纳参数";
            }
            //显示参数
            //
            //
            //
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {

            if (NetEngine.bConnect)
            {
                MainForm.mf.CmdWindow.Show();
                BSSParameter para = new BSSParameter();
                para.Ts = (ushort)(RangeInput.Value * 65121 / 750 );
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
    }
}
