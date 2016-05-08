using System;
using System.Drawing;
using DevComponents.DotNetBar;

namespace Survey.Forms
{
    public partial class ChartOptionForm : Office2007Form
    {
        public ChartOption OwnedOption;
        public ChartOptionForm(ChartOption option,int idx=0)
        {
            OwnedOption = option;
            InitializeComponent();
            OptionTab.SelectedTabIndex = idx;
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
    }
}
