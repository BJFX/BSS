using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ChartBox
{
    public partial class WaveBox : UserControl, IDisposable
    {
        private int _displayLength = 2048; //
        private int _bytePerSample = 2; //
        private int _displayWidthMax = 16000;
        private int _displayAmpMax = 32767;
        private WaveFrame waveFrame = null;
        public WaveBox()
        {
            InitializeComponent();
        }
        ~WaveBox()
        {

            GC.SuppressFinalize(this);
        }
        public void Initialize(int bytepersample, int len, int max, int width)
        {
            BytePerSample = bytepersample;
            DisplayLength = len;
            DisplayAmpMax = max;
            DisplayWidthMax = width;
            waveFrame = new WaveFrame(bytepersample, DisplayLength, DisplayAmpMax, DisplayWidthMax);
        }
        public int BytePerSample
        {
            get { return _bytePerSample; }
            set { _bytePerSample = value; }
        }
        public int DisplayLength
        {
            get { return _displayLength; }
            set { _displayLength = value; }
        }

        public int DisplayWidthMax
        {
            get { return _displayWidthMax; }
            set { _displayWidthMax = value; }
        }

        public int DisplayAmpMax
        {
            get { return _displayAmpMax; }
            set { _displayAmpMax = value; }
        }

        public void Clear()
        {
            if (waveFrame == null)
                return;
            waveFrame.Clear();
            Graphics g = WaveSection.CreateGraphics();
            g.Clear(Color.Black);
            g.Dispose();
        }

        public void Display(byte[] buf, bool reverse = false)
        {

            if (waveFrame != null)
            {
                waveFrame.AddData(buf, reverse);
                waveFrame.RenderTimeDomain(ref WaveSection);
            }

        }

        private void WaveSection_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                base.OnMouseClick(e);
            }
        }
    }
}
