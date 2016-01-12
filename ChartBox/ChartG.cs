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
            GisFrame = new ChartFrame(bytepersample,DisplayLength, DisplayAmpMax, DisplayWidthMax);
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
        public void SetLevel(int value)
        {
            if(GisFrame!=null) 
                GisFrame.level = value;
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
    }
}