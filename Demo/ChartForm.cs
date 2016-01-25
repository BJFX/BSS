using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ChartBox;
using DevComponents.DotNetBar;
namespace Demo
{
    public partial class ChartForm:Office2007Form
    {
        
        private bool BinitailChart1 = false;
        private bool BinitailChart2 = false;
        private ChartOption option;
        public ChartForm()
        {
            InitializeComponent();
        }

        public void Initial()
        {
                chartLeft.Clear();
                chartRight.Clear();
                BinitailChart1 = false;
                BinitailChart2 = false;
        }
        private void SideTable_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        public void DisplayChart(int ChannelNumber, int DataNeedToRead, byte[] buf, int pixellevel)
        {
            if (ChannelNumber == 0)
            {
                if (!BinitailChart1)
                    chartLeft.Initialize(2, (int)DataNeedToRead / 2, 4096, 100);
                BinitailChart1 = true;
                chartLeft.SetLevel(pixellevel);

                chartLeft.Display(buf, false);
            }
            if (ChannelNumber == 1)
            {
                if (!BinitailChart2)
                    chartRight.Initialize(2, (int)DataNeedToRead / 2, 4096, 100);
                BinitailChart2 = true;
                chartRight.SetLevel(pixellevel);
                chartRight.Display(buf, false);
            }
        }

        private void ChartForm_SizeChanged(object sender, EventArgs e)
        {

        }
        
       
        #region menu
        
        
        
        #endregion



    }
}
