using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
    public partial class SensorForm : Form
    {
        private readonly MainForm _mf;
        private Dictionary<int, string> _lineName = new Dictionary<int, string>(); 
        public SensorForm(MainForm mainForm)
        {
            _mf = mainForm;
            InitializeComponent();
            waveBoxV.Initialize(10,10,-10);
            _lineName.Add((int)DataType.Heading, "艏向角");
            _lineName.Add((int)DataType.Pitch, "纵倾");
            _lineName.Add((int)DataType.Roll, "横摇");
            _lineName.Add((int)DataType.Pressure, "托体压强");
            _lineName.Add((int)DataType.Temperature, "艏向角"); 
            _lineName.Add((int)DataType.Speed, "航速");
            _lineName.Add((int)DataType.Depth, "拖体深度");
            _lineName.Add((int)DataType.Altitude, "拖体底深");
            waveBoxV.AddLine(_lineName[(int)DataType.Pitch], Color.Teal);
            waveBoxV.AddLine(_lineName[(int)DataType.Roll], Color.Tomato);
        }

        public void Display(DataType type, double data)
        {
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
                    waveBoxV.Display(data, _lineName[(int)type]);
                    break;
                case DataType.Pressure:
                    Pressurelabel.Text = _lineName[(int)type] + ":" + data.ToString("F2")+"Pa";
                    break;
                case DataType.Roll:
                    Rolllabel.Text = _lineName[(int)type] + ":" + data.ToString("F2")+"°";
                    waveBoxV.Display(data, _lineName[(int)type]);
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
        }
        private void SensorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _mf.ChildFormClose(this);
        }
    }
}
