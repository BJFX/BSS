using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ChartBox
{
    public partial class WaveBoxV : UserControl,IDisposable
    {
        private int _displayLength = 10; //
        private string _title = "Chart";
        private double _displayAmpMax = 30;
        private double _displayAmpMin = -30;
        private WaveFrameV waveFrame = null;
        public WaveBoxV()
        {
            InitializeComponent();
        }
        ~WaveBoxV()
        {

            GC.SuppressFinalize(this);
        }
        public void Initialize(int len, double max,double min)
        {
            _displayLength = len;
            _displayAmpMax = max;
            _displayAmpMin = min;
            waveFrame = new WaveFrameV(_displayLength, _displayAmpMax, _displayAmpMin);
        }

        public int DisplayCount
        {
            get { return _displayLength; }
            set { _displayLength = value; }
        }


        public double DisplayAmpMax
        {
            get { return _displayAmpMax; }
            set { _displayAmpMax = value; }
        }

        public void Clear()
        {
            if (waveFrame == null)
                return;
            waveFrame.Clear();
            waveFrame.Paint(ref WaveSection);
        }

        public bool AddLine(string catalog,Color color)
        {
            if (waveFrame != null)
            {
                if (waveFrame.AddLine(catalog, color))
                {
                    waveFrame.Paint(ref WaveSection);
                    return true;
                }
                
            }
            return false;
        }

        public void DeleteLine(string catalog)
        {
            if (waveFrame != null)
            {
                waveFrame.DeleteLine(catalog);
                waveFrame.Paint(ref WaveSection);
            }
        }
        public void DeleteLines()
        {
            if (waveFrame != null)
            {
                waveFrame.DeleteAll();
                waveFrame.Paint(ref WaveSection);
            }
        }
        public void Display(double data, string catalog)
        {
            if (waveFrame != null)
            {
                waveFrame.AddData(data, catalog);
                waveFrame.Paint(ref WaveSection);
            }

        }
    }
}
