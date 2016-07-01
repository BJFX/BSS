using System;
using System.Drawing;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Collections;

namespace Survey.Forms
{
    public partial class ChartOptionForm : Office2007Form
    {
        public ChartOption OwnedOption;
        public BSSParameter Highpara = new BSSParameter(true);
        public BSSParameter Lowpara = new BSSParameter(false);
        public bool CurrentType = false;
        public ChartOptionForm(ChartOption option,int idx=0)
        {
            OwnedOption = option;
            InitializeComponent();
            OptionTab.SelectedTabIndex = idx;
            ChunkEndBtn.SelectedColor = Color.Gold;
            ColorBar.ChunkColor = Color.Gold;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            OwnedOption.AutoTVG = checkAutoTVG.Checked;
            OwnedOption.FreezeTVG = FreezeTVGCheck.Checked;
            OwnedOption.TVG = ((float)AutoTVGSlide.Value)/100.0f;
            OwnedOption.PortA = PortAGainSlider.Value;
            OwnedOption.PortB = PortBGainSlider.Value;
            OwnedOption.PortC = PortCGainSlider.Value;
            OwnedOption.StarboardA = StarAGainSlider.Value;
            OwnedOption.StarboardB = StarBGainSlider.Value;
            OwnedOption.StarboardC = StarCGainSlider.Value;
            OwnedOption.StartColor = ChunkStartBtn.SelectedColor;
            OwnedOption.EndColor = ChunkEndBtn.SelectedColor;
            OwnedOption.Gamma = ((float) GammaSlider.Value)/100.0f;
            OwnedOption.Fq = HighRd.Checked ? Frequence.High : Frequence.Low;
            OwnedOption.Gain = GainSlider.Value;
            OwnedOption.RawMax = (RawMaxBox.SelectedIndex + 1)*4096;
            if(OptionTab.SelectedTab.Text=="参数设置")//option
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
                    ba.CopyTo(tmp, 0);
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
                }
            }
        }

        private void checkAutoTVG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAutoTVG.Checked)
            {
                Starboardgroup.Enabled = false;
                PortGaingroup.Enabled = false;
                labelGain.Enabled = false;
                FreezeTVGCheck.Enabled = true;
                FreezeTVGCheck.Checked = false;
                AutoTVGgroup.Enabled = true;
            }
            else
            {
                Starboardgroup.Enabled = true;
                PortGaingroup.Enabled = true;
                labelGain.Enabled = true;
                FreezeTVGCheck.Enabled = false;
                FreezeTVGCheck.Checked = false;
                AutoTVGgroup.Enabled = false;
            }
        }

        private Color GammaAjust(Color color,float factor)
        {
            Color newColor = new Color();
            double d = Math.Pow(color.R, 1/factor);
            if (d > 255)
                d = 255;
            byte r = (byte)d;
            d = Math.Pow(color.G, 1 / factor);
            if (d > 255)
                d = 255;
            byte g= (byte)d;
            d = Math.Pow(color.B, 1 / factor);
            if (d > 255)
                d = 255;
            byte b = (byte)d;
            
            
            newColor = Color.FromArgb(255, r, g, b);
            return newColor;
        }
        private void ChunkStartBtn_SelectedColorChanged(object sender, EventArgs e)
        {
            ColorBar.ChunkColor2 = ChunkStartBtn.SelectedColor;
        }

        private void ChunkEndBtn_SelectedColorChanged(object sender, EventArgs e)
        {
            ColorBar.ChunkColor = ChunkEndBtn.SelectedColor;
        }

        private void GammaSlider_ValueChanged(object sender, EventArgs e)
        {
            GammaFactor.Text = (((float)GammaSlider.Value)/100).ToString("F02");
            
        }

        private void ChartOptionForm_Load(object sender, EventArgs e)
        {
            if (OwnedOption.Side == ShowSide.Both)
            {
                ShowBothRd.Checked = true;
            }
            else if (OwnedOption.Side == ShowSide.Port)
            {
                PortRd.Checked = true;
            }
            else
            {
                StarboardRd.Checked = true;
            }
            if (OwnedOption.Fq == Frequence.High)
            {
                HighRd.Checked = true;
            }
            if (OwnedOption.Fq == Frequence.Low)
            {
                LowRd.Checked = true;
            }
            FreezeTVGCheck.Checked = OwnedOption.FreezeTVG;
            AutoTVGSlide.Value = (int)(OwnedOption.TVG*100);
            PortAGainSlider.Value = OwnedOption.PortA;
            PortBGainSlider.Value = OwnedOption.PortB;
            PortCGainSlider.Value = OwnedOption.PortC;
            StarAGainSlider.Value = OwnedOption.StarboardA;
            StarBGainSlider.Value = OwnedOption.StarboardB;
            StarCGainSlider.Value = OwnedOption.StarboardC;
            GammaSlider.Value = (int)(OwnedOption.Gamma * 100);
            GammaFactor.Text = OwnedOption.Gamma.ToString("F02");
            ChunkStartBtn.SelectedColor = OwnedOption.StartColor;
            ChunkEndBtn.SelectedColor = OwnedOption.EndColor;
            checkAutoTVG.Checked = OwnedOption.AutoTVG;
            GainSlider.Value = OwnedOption.Gain;
            RawMaxBox.SelectedIndex = OwnedOption.RawMax/4096-1;
            CurrentType = (OwnedOption.Fq == Frequence.High) ? true : false;
        }

        private void AutoTVGSlide_ValueChanged(object sender, EventArgs e)
        {
            AutoTVGValue.Text = (AutoTVGSlide.Value/100).ToString("F02");
        }

        private void PortAGainSlider_ValueChanged(object sender, EventArgs e)
        {
            PortAValue.Text = PortAGainSlider.Value.ToString("F02");
        }

        private void StarAGainSlider_ValueChanged(object sender, EventArgs e)
        {
            starAvalue.Text = StarAGainSlider.Value.ToString("F02");
        }

        private void PortBGainSlider_ValueChanged(object sender, EventArgs e)
        {
            PortBValue.Text = PortBGainSlider.Value.ToString("F02");
        }

        private void PortCGainSlider_ValueChanged(object sender, EventArgs e)
        {
            PortCValue.Text = PortCGainSlider.Value.ToString("F02");
        }

        private void StarBGainSlider_ValueChanged(object sender, EventArgs e)
        {
            StarBvalue.Text = StarBGainSlider.Value.ToString("F02");
        }

        private void StarCGainSlider_ValueChanged(object sender, EventArgs e)
        {
            StarCvalue.Text = StarCGainSlider.Value.ToString("F02");
        }

        private void ShowBothRd_CheckedChanged(object sender, EventArgs e)
        {
            OwnedOption.Side = ShowSide.Both;
        }

        private void StarboardRd_CheckedChanged(object sender, EventArgs e)
        {
            OwnedOption.Side = ShowSide.Starboard;
        }

        private void PortRd_CheckedChanged(object sender, EventArgs e)
        {
            OwnedOption.Side = ShowSide.Port;
        }

        private void GainSlider_ValueChanged(object sender, EventArgs e)
        {
            GainSlider.Text = GainSlider.Value.ToString();
            OwnedOption.Gain = GainSlider.Value;
        }

        private void OptionTab_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if(OptionTab.SelectedTab.Text=="参数设置")
            {
                BSSParameter para = null;
                if (NetEngine.bConnect)
                {
                    if (CurrentType)
                    {
                        RangeInput.MaxValue = 100;
                        para = Highpara;
                        if (MainForm.mf.netcore.SendCommand(Command.GetHighParaCMD()) == false)
                        {
                            MainForm.mf.CmdWindow.DisplayAns("无法得到最新高频参数：" + MainForm.mf.netcore.Status);
                            //this.Text = "设置高频声纳参数" + "-无法得到最新高频参数";
                        }
                        else
                        {
                            MainForm.mf.CmdWindow.DisplayAns("收到最新高频参数：");
                            //this.Text = "设置高频声纳参数";
                        }

                    }
                    else
                    {
                        RangeInput.MaxValue = 200;
                        para = Lowpara;
                        if (MainForm.mf.netcore.SendCommand(Command.GetLowParaCMD()) == false)
                        {
                            MainForm.mf.CmdWindow.DisplayAns("无法得到最新低频参数：" + MainForm.mf.netcore.Status);
                            //this.Text = "设置低频声纳参数" + "-无法得到最新低频参数";
                        }
                        else
                        {
                            MainForm.mf.CmdWindow.DisplayAns("收到最新低频参数：");
                            //this.Text = "设置低频声纳参数";
                        }
                    }

                }
                else
                {
                    para = new BSSParameter(false);
                }
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
                int selectindex = ((ba[2] == true) ? 1 : 0) + ((ba[3] == true) ? 1 : 0) * 2 + ((ba[4] == true) ? 1 : 0) * 4 - 1;
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
        }
    }
}
