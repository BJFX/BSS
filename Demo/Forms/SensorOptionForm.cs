using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Survey.Forms
{
    public partial class SensorOptionForm : Office2007Form
    {
        public SensorOption OwnedOption;
        public SensorOptionForm(SensorOption option)
        {
            OwnedOption = option;
            InitializeComponent();
        }

        private void SensorOptionForm_Load(object sender, EventArgs e)
        {
            HeadingChk.Checked = OwnedOption.bShowHeading;
            PitchChk.Checked = OwnedOption.bShowPitch;
            RollChk.Checked = OwnedOption.bShowRoll;
            PressureChk.Checked = OwnedOption.bShowPressure;
            DepthChk.Checked = OwnedOption.bShowDepth;
            AltiChk.Checked = OwnedOption.bShowAltitude;
            SpeedChk.Checked = OwnedOption.bShowSpeed;
            TempChk.Checked = OwnedOption.bShowTemperature;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            OwnedOption.bShowHeading = HeadingChk.Checked ;
            OwnedOption.bShowPitch = PitchChk.Checked;
            OwnedOption.bShowRoll = RollChk.Checked;
            OwnedOption.bShowPressure = PressureChk.Checked;
            OwnedOption.bShowDepth = DepthChk.Checked;
            OwnedOption.bShowAltitude = AltiChk.Checked;
            OwnedOption.bShowSpeed = SpeedChk.Checked;
            OwnedOption.bShowTemperature = TempChk.Checked;
        }
    }
}
