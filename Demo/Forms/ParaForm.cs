using System.Collections;
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
                    else
                    {
                        MainForm.mf.CmdWindow.DisplayAns("收到最新高频参数：");
                        this.Text = "设置高频声纳参数";
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
                    else
                    {
                        MainForm.mf.CmdWindow.DisplayAns("收到最新低频参数：");
                        this.Text = "设置低频声纳参数";
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
            PortCentralFq.Value = (int)para.PortCentralFq;
            StartCentralFq.Value = (int)para.StarBoardCentralFq;
            WorkPeriod.Value = (int)para.Period;
            PulseLength.Value = (int)para.Ls;
            TVGDelay.Value = (int)para.TVGDelay;
            TvgAlpha.Value = (int)para.TvgAlpha;
            TvgBeta.Value = (int)para.TvgBeta;
            //发射控制
            BitArray ba = new BitArray(BitConverter.GetBytes(para.Flag));
            PortSendEnable.Checked = ba[0];
            StartSendEnable.Checked = ba[1];
            int selectindex = ((ba[2] == true) ? 1 : 0) + ((ba[3] == true) ? 1 : 0)*2 + ((ba[4] == true) ? 1 : 0)*4 - 1;
            PortBox.SelectedIndex = selectindex;
            selectindex = ((ba[5] == true) ? 1 : 0) + ((ba[6] == true) ? 1 : 0) * 2 + ((ba[7] == true) ? 1 : 0) * 4 - 1;
            StartBox.SelectedIndex = selectindex;
            //命令标识
            TrigerMode.Checked = para.ComArray[3];
            PortFqBox.SelectedIndex = para.ComArray[6] == false ? 0 : 1;
            StartFqBox.SelectedIndex = para.ComArray[7] == false ? 0 : 1;
            EnablePortBSS.Checked = para.ComArray[21];
            EnableStartBSS.Checked = para.ComArray[22];
            CalcTVG.Checked = para.ComArray[24];
            SingleWorkValid.Checked = para.ComArray[25];
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {

            if (NetEngine.bConnect)
            {
                //MainForm.mf.CmdWindow.Show();
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
                para.PortCentralFq = (uint)PortCentralFq.Value;
                para.StarBoardCentralFq = (uint)StartCentralFq.Value;
                para.PortBandWidth = PortBandWidth.Value;
                para.StarBoardBandWidth = StartBandWidth.Value;
                para.Period = (ushort)WorkPeriod.Value;
                para.Ls = (ushort)PulseLength.Value;
                para.TVGDelay = (ushort)TVGDelay.Value;
                para.TvgAlpha = (ushort)TvgAlpha.Value;
                para.TvgBeta = (ushort)TvgBeta.Value;
                //发射控制
                BitArray ba = new BitArray(32);
                ba[0] = PortSendEnable.Checked;
                ba[1] = StartSendEnable.Checked;
                if (PortBox.SelectedIndex == -1 || StartBox.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择有效功率");
                    return;
                }
                switch (PortBox.SelectedIndex)
                {
                    case 0:
                        ba[2] = true;
                        ba[3] = false;
                        ba[4] = false;
                        break;
                    case 1:
                        ba[2] = false;
                        ba[3] = true;
                        ba[4] = false;
                        break;
                    case 2:
                        ba[2] = true;
                        ba[3] = true;
                        ba[4] = false;
                        break;
                    case 3:
                        ba[2] = false;
                        ba[3] = false;
                        ba[4] = true;
                        break;
                    case 4:
                        ba[2] = true;
                        ba[3] = false;
                        ba[4] = true;
                        break;
                    case 5:
                        ba[2] = false;
                        ba[3] = true;
                        ba[4] = true;
                        break;
                    default:
                        ba[2] = false;
                        ba[3] = true;
                        ba[4] = true;
                        break;
                }
                switch (StartBox.SelectedIndex)
                {
                    case 0:
                        ba[5] = true;
                        ba[6] = false;
                        ba[7] = false;
                        break;
                    case 1:
                        ba[5] = false;
                        ba[6] = true;
                        ba[7] = false;
                        break;
                    case 2:
                        ba[5] = true;
                        ba[6] = true;
                        ba[7] = false;
                        break;
                    case 3:
                        ba[5] = false;
                        ba[6] = false;
                        ba[7] = true;
                        break;
                    case 4:
                        ba[5] = true;
                        ba[6] = false;
                        ba[7] = true;
                        break;
                    case 5:
                        ba[5] = false;
                        ba[6] = true;
                        ba[7] = true;
                        break;
                    default:
                        ba[5] = false;
                        ba[6] = true;
                        ba[7] = true;
                        break;
                }
                int[] tmp = new int[1];
                ba.CopyTo(tmp,0);
                para.Flag = (ushort)tmp[0];
                //命令标识
                if (PortFqBox.SelectedIndex == -1 || StartFqBox.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择有效调频方向");
                    return;
                }
                para.ComArray[3] = TrigerMode.Checked;
                para.ComArray[6] = PortFqBox.SelectedIndex == 0 ? false : true;
                para.ComArray[7] = StartFqBox.SelectedIndex == 0 ? false : true;
                para.ComArray[21] = EnablePortBSS.Checked;
                para.ComArray[22] = EnableStartBSS.Checked;
                para.ComArray[24] = CalcTVG.Checked;
                para.ComArray[25] = SingleWorkValid.Checked;
                int[] tmpcmd = new int[1];
                para.ComArray.CopyTo(tmpcmd, 0);
                para.Com = (uint)tmpcmd[0];
                if (CurrentType)
                {

                    MainForm.mf.CmdWindow.DisplayCommand("下发命令：设置高频声纳工作参数");

                    if (MainForm.mf.netcore.SendCommand(Command.SetupHighBSS(para)) == false)
                    {
                        MainForm.mf.CmdWindow.DisplayAns("下发命令不成功：" + MainForm.mf.netcore.Status);
                        MessageBox.Show("设置高频声纳工作参数失败！");
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
                        MessageBox.Show("设置低频声纳工作参数失败！");
                    }
                    else
                    {
                        MessageBox.Show("设置低频声纳工作参数成功！");
                    }
                }
                this.Hide();
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
