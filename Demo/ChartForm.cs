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
        private MainForm mf;
        public ChartForm(MainForm mainForm)
        {
            mf = mainForm;
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //回放ToolStripMenuItem.Enabled = false;
            //暂停ToolStripMenuItem.Enabled = false;
            //重置ToolStripMenuItem.Enabled = false;
            //加速ToolStripMenuItem.Enabled = false;
            //减速ToolStripMenuItem.Enabled = false;
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.PlaybackTime.Stop();
            if (mf.playbackFileStream != null)
                mf.playbackFileStream.Close();
        }



        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openXtfFileDialog.ShowDialog() == DialogResult.OK)
            {
                mf.filename = openXtfFileDialog.SafeFileName;
                mf.fi = new FileInfo(openXtfFileDialog.FileName);
                if (mf.playbackFileStream!=null)
                    mf.playbackFileStream.Close();
                mf.playbackFileStream = new BinaryReader(openXtfFileDialog.OpenFile());
                //this.Text = "XTF回放" + " - " + filename;
                //回放ToolStripMenuItem.Enabled = false;
                //暂停ToolStripMenuItem.Enabled = true;
                //重置ToolStripMenuItem.Enabled = true;
                //加速ToolStripMenuItem.Enabled = true;
                //减速ToolStripMenuItem.Enabled = true;
                mf.PlaybackTime.Enabled = true;
                mf.PlaybackTime.Interval = mf.tick;
                mf.PlaybackTime.Start();
                mf.offset = 0;
                chartLeft.Clear();
                chartRight.Clear();
                BinitailChart1 = false;
                BinitailChart2 = false;
                //Level.Text = pixellevel.ToString();

            }
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
            if (panel1.Size.Height < chartLeft.Height)
            {
                
            }
        }
        
       
        #region menu
        
        
        /*
        private void 回放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Enabled = true;
            PlaybackTime.Interval = tick;
            PlaybackTime.Start();
            回放ToolStripMenuItem.Enabled = false;
            暂停ToolStripMenuItem.Enabled = true;
            重置ToolStripMenuItem.Enabled = true;
            加速ToolStripMenuItem.Enabled = true;
            减速ToolStripMenuItem.Enabled = true;
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();
            回放ToolStripMenuItem.Enabled = true;
            暂停ToolStripMenuItem.Enabled = false;
            重置ToolStripMenuItem.Enabled = false;
            加速ToolStripMenuItem.Enabled = false;
            减速ToolStripMenuItem.Enabled = false;
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();
            tick = 16;
            playbackFileStream.BaseStream.Position = 0;
            offset = 0;
            chartG1.Clear();
            chartG2.Clear();
            回放ToolStripMenuItem.Enabled = true;
            暂停ToolStripMenuItem.Enabled = false;
            重置ToolStripMenuItem.Enabled = false;
            加速ToolStripMenuItem.Enabled = false;
            减速ToolStripMenuItem.Enabled = false;
        }
        
        private void 加速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();

            if (tick > 1)
            {
                tick = tick / 2;
                减速ToolStripMenuItem.Enabled = true;
            }
            else
            {
                加速ToolStripMenuItem.Enabled = false;
            }
            PlaybackTime.Interval = tick;
            PlaybackTime.Start();
        }

        private void 减速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();

            if (tick < 256)
            {
                tick = tick * 2;
                加速ToolStripMenuItem.Enabled = true;
            }
            else
            {
                减速ToolStripMenuItem.Enabled = false;
            }
            PlaybackTime.Interval = tick;
            PlaybackTime.Start();
        }*/
        #endregion



    }
}
