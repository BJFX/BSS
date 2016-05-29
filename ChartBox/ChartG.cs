using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace ChartBox
{
    public partial class ChartG : UserControl, IDisposable
    {
        private int _displayLength = 2048; //
        private int _bytePerSample = 2; //
        private int _displayWidthMax = 16000;
        private int _displayAmpMax = 32767;
        private ChartFrame GisFrame = null;
        private int _gain = 3;
        

        public ChartG()
        {
            InitializeComponent();

        }

        ~ChartG()
        {

            GC.SuppressFinalize(this);
        }

        public void Initialize(int bytepersample,int len, int max, int width)
        {
            BytePerSample = bytepersample;
            DisplayLength = len;
            DisplayAmpMax = max;
            DisplayWidthMax = width;
            Gain = 3;
            GisFrame = new ChartFrame(bytepersample,DisplayLength, DisplayAmpMax);
        }

        public int DisplayWidthMax
        {
            get { return _displayWidthMax; }
            set
            {
                _displayWidthMax = value;
                if (GisFrame != null)
                    GisFrame.Xmax = _displayWidthMax;
            } 
        }
        public int Gain
        {
            get { return _gain; }
            set
            {
                _gain = value;
                if (GisFrame != null)
                    GisFrame.ChartGain = _gain;
            }
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
        public void SetColor(Color startColor,Color endColor,float gamma)
        {
            if (GisFrame != null)
            {
                GisFrame.StartColor = startColor;
                GisFrame.EndColor = endColor;
                GisFrame.Gamma = gamma;
            }
        }
        public int DisplayAmpMax
        {
            get { return _displayAmpMax; }
            set { _displayAmpMax = value; }
        }

        public void Clear()
        {
            if(GisFrame == null)
                return;
            GisFrame.Clear();
            Gain = 1;
            Graphics g = GisChart.CreateGraphics();
            g.Clear(Color.Black);
            g.Dispose();
        }

        public void Display(byte[] buf,bool reverse=false)
        {

                if (GisFrame != null)
                {
                    GisFrame.AddData(buf,reverse);
                    GisFrame.RenderGis(ref GisChart,1);
                }
                 
        }

        private void GisChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                base.OnMouseClick(e);
            }
        }

    }
}