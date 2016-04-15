using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Survey.Forms
{
    public enum DataType
    {
        Heading,
        Pitch,
        Roll,
        Pressure,
        Temperature,
        Speed,
        Depth,
        Altitude

    }
    public partial class SensorForm : Office2007Form
    {
        private readonly MainForm _mf;
        private Dictionary<int, string> _lineName = new Dictionary<int, string>();
        private Mutex dispMutex;
        public SensorOption option = new SensorOption();
        public List<Color> MonoColors = new List<Color>();
        public SensorForm(MainForm mainForm)
        {
            _mf = mainForm;
            dispMutex = new Mutex();
            InitializeComponent();
            waveBoxV.Initialize(10,10,-10);
            _lineName.Add((int)DataType.Heading, "艏向角");
            _lineName.Add((int)DataType.Pitch, "纵倾");
            _lineName.Add((int)DataType.Roll, "横摇");
            _lineName.Add((int)DataType.Pressure, "压强");
            _lineName.Add((int)DataType.Temperature, "温度"); 
            _lineName.Add((int)DataType.Speed, "航速");
            _lineName.Add((int)DataType.Depth, "拖体深度");
            _lineName.Add((int)DataType.Altitude, "底深");
            MonoColors.Add(Color.Aqua);
            MonoColors.Add(Color.Blue);
            MonoColors.Add(Color.BlueViolet);
            MonoColors.Add(Color.Brown);
            MonoColors.Add(Color.BurlyWood);
            MonoColors.Add(Color.CadetBlue);
            MonoColors.Add(Color.Chartreuse);
            MonoColors.Add(Color.Chocolate);
            MonoColors.Add(Color.CornflowerBlue);
            MonoColors.Add(Color.Crimson);
            MonoColors.Add(Color.DeepPink);
            waveBoxV.AddLine(_lineName[(int)DataType.Heading], MonoColors[0]);
            waveBoxV.AddLine(_lineName[(int)DataType.Pitch], MonoColors[1]);
            waveBoxV.AddLine(_lineName[(int)DataType.Roll], MonoColors[2]);
            option.bShowHeading = true;
            option.bShowPitch = true;
            option.bShowRoll = true;
        }

        public void Display(DataType type, double data)
        {
            dispMutex.WaitOne();
            switch (type)
            {
                case DataType.Altitude:

                        Altitudelabel.Text = _lineName[(int)type] + ":" + data.ToString("F2") + "m";
                    break;
                case DataType.Depth:

                        Depthlabel.Text = _lineName[(int)type] + ":" + data.ToString("F2")+"m";
                    break;
                case DataType.Heading:

                        Headinglabel.Text = _lineName[(int)type] + ":" + data.ToString("F2") + "°";
                    break;
                case DataType.Pitch:

                        Pitchlabel.Text = _lineName[(int)type] + ":" + data.ToString("F2") + "°";
                    break;
                case DataType.Pressure:

                        Pressurelabel.Text = _lineName[(int)type] + ":" + data.ToString("F2")+"Pa";
                    break;
                case DataType.Roll:

                        Rolllabel.Text = _lineName[(int)type] + ":" + data.ToString("F2")+"°";
                    
                    break;
                case DataType.Speed:

                        Speedlabel.Text = _lineName[(int)type] + ":" + data.ToString("F2")+"knot";
                    break;
                case DataType.Temperature:

                        Templabel.Text = _lineName[(int)type] + ":" + data.ToString("F2")+"℃";
                    break;
                default:
                    break;
                
            }
            waveBoxV.Display(data, _lineName[(int)type]);//display lines if added already
            dispMutex.ReleaseMutex();
        }
        private void SensorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _mf.ChildFormClose(this);
        }

        private void PopUpOption()
        {
            using (SensorOptionForm cof = new SensorOptionForm(option))
            {
                if (cof.ShowDialog() == DialogResult.OK)
                {
                    waveBoxV.DeleteLines();
                    waveBoxV.ReSetRange();
                    int idx = 0;
                    if (option.bShowAltitude)
                    {
                        waveBoxV.AddLine(_lineName[(int)DataType.Altitude], MonoColors[idx]);
                        idx++;
                    }
                    if (option.bShowDepth)
                    {
                        waveBoxV.AddLine(_lineName[(int)DataType.Depth], MonoColors[idx]);
                        idx++;
                    }
                    if (option.bShowHeading)
                    {
                        waveBoxV.AddLine(_lineName[(int)DataType.Heading], MonoColors[idx]);
                        idx++;
                    }
                    if (option.bShowPitch)
                    {
                        waveBoxV.AddLine(_lineName[(int)DataType.Pitch], MonoColors[idx]);
                        idx++;
                    }
                    if (option.bShowPressure)
                    {
                        waveBoxV.AddLine(_lineName[(int)DataType.Pressure], MonoColors[idx]);
                        idx++;
                    }
                    if (option.bShowRoll)
                    {
                        waveBoxV.AddLine(_lineName[(int)DataType.Roll], MonoColors[idx]);
                        idx++;
                    }
                    if (option.bShowSpeed)
                    {
                        waveBoxV.AddLine(_lineName[(int)DataType.Speed], MonoColors[idx]);
                        idx++;
                    }
                    if (option.bShowTemperature)
                    {
                        waveBoxV.AddLine(_lineName[(int)DataType.Temperature], MonoColors[idx]);
                        idx++;
                    }
                    
                }
            }
        }

        private void waveBoxV_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PopUpOption();
            }
        }
    }
}
