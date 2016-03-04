using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ChartBox
{
    public class Line
    {

        public string Name;
        public Color LineColor;
        private int Count;
        public List<double> Points = new List<double>();
        public Line(int count,string catalog, Color color)
        {
            Count = count;
            Name = catalog;
            LineColor = color;
        }

        public void Add(double data)
        {
            Points.Add(data);
            if (Points.Count == Count+1)
            {
                Points.RemoveAt(0);
            }
        }

        public void Clear()
        {
            Points.Clear();
        }
    }
    public class WaveFrameV
    {
        Hashtable LineTable = new Hashtable();
        public PictureBox Picture = null;
        public double Max = double.MaxValue;
        public double Min = double.MinValue;
        public int Count = 10;
        private Bitmap canvas;

        public WaveFrameV(int len, double max,double min)
        {
            Count = len;
            Max = max;
            Min = min;
            canvas = new Bitmap(240, 460);
            Graphics g = Graphics.FromImage(canvas);
            g.Clear(Color.Black);
            g.Dispose();
            
        }

        public void Paint(ref PictureBox picture)
        {
            Graphics offScreenDC = Graphics.FromImage(canvas);
            offScreenDC.Clear(Color.Black);
            offScreenDC.Dispose();
            SetLegend();
            SetWidthAxis();
            Render();
            picture.Image = canvas;

        }
        public void DeleteLine(string catalog)
        {
            if (LineTable.ContainsKey(catalog))
            {
                LineTable.Remove(catalog);
            }
        }

        public void DeleteAll()
        {
            LineTable.Clear();
        }
        public void Clear()
        {
            if (LineTable.Count > 0)
            {
                var et = LineTable.GetEnumerator();
                while (et.MoveNext())
                {
                    ((Line)et.Value).Clear();
                }
            }
        }

        public bool AddLine(string catalog, Color color)
        {
            if (LineTable.ContainsKey(catalog))
                return false;
            var newline = new Line(Count,catalog,color);
            LineTable.Add(catalog, newline);
            return true;
        }
        /// <summary>
        /// Process 16 bit sample
        /// </summary>
        /// <param name="wave"></param>
        
        public void AddData(double data, string catalog)
        {
            if (LineTable.ContainsKey(catalog))
            {
                var line = LineTable[catalog] as Line;
                if (line != null)
                {
                    if (data < Min)
                        Min = data;
                    if (data > Max)
                        Max = data;
                    line.Add(data);
                }
            }
        }

        public void Render()
        {
            if (LineTable.Count == 0)
                return;

            int width = 230;
            int height = 360;
            Graphics offScreenDC = Graphics.FromImage(canvas);
            var et = LineTable.GetEnumerator();
            while (et.MoveNext())
            {
                Line line = et.Value as Line;
                if (line != null && line.Points.Count>0)
                {
                    Pen pen = new System.Drawing.Pen(line.LineColor);
                    Point[] p = new Point[line.Points.Count];
                    double step = (double)height / (double)Count;
                    double distance = (double)width/ (Max-Min);
                    for (int i = 0; i < line.Points.Count; i++)
                    {
                        int x = 5 + (int)((line.Points[i] -Min)*distance);
                        int y = 80 + (int)step*i;
                        p[i] = new Point(x, y);

                    }
                    if (line.Points.Count==1)
                        offScreenDC.DrawEllipse(pen,p[0].X,p[0].Y,1,1);
                    else
                        offScreenDC.DrawLines(pen,p);
                }
            } 

            offScreenDC.Dispose();
        }

        

        public void SetLegend()
        {
            Graphics offScreenDC = Graphics.FromImage(canvas);
            var et = LineTable.GetEnumerator();
            int i = -1;
            int offset = 0;
            while (et.MoveNext())
            {
                i++;
                Line line = et.Value as Line;
                if (i == 4)
                {
                    i = 0;
                    offset = 110;
                }
                if (line != null)
                {
                    Pen p1 = new Pen(line.LineColor, 4);
                    string strdata = "0";
                    if (line.Points.Count>0)
                        strdata = line.Points[line.Points.Count - 1].ToString("F1");
                    string str = line.Name + ": " + strdata;
                    SolidBrush sb = new SolidBrush(Color.White);
                    offScreenDC.DrawString(str, new Font("Arial Regular", 8), sb, 5 + offset, 6 + i * 15);
                    offScreenDC.DrawLine(p1, 85 + offset, 10 + i * 15, 110 + offset, 10 + i * 15);
                }
            }

            offScreenDC.Dispose();
        }
        //绘制X/Y轴
        public void SetWidthAxis()
        {
            Pen p1 = new Pen(Color.White, 2);
            Pen p2 = new Pen(Color.White, 1);
            p2.DashStyle = DashStyle.Dash;
            SolidBrush sb = new SolidBrush(Color.White);
            Graphics g = Graphics.FromImage(canvas);
            g.DrawLine(p1, 5, 80, 235, 80);
            g.DrawLine(p1, 5, 440, 235, 440);
            g.DrawLine(p1, 5, 80, 5, 440);
            g.DrawLine(p1, 235, 80, 235, 440);
            g.DrawLine(p1,120,80,120,440);
            g.DrawLine(p2, 63, 80, 63, 440);
            g.DrawLine(p2, 177, 80, 177, 440);
            string axr = Max.ToString("F1");
            g.DrawString(axr, new Font("Arial Regular", 8), sb, 210, 65);
            axr = Min.ToString("F1");
            g.DrawString(axr, new Font("Arial Regular", 8), sb, 0, 65);
            axr = ((Max+Min)/2).ToString("F1");
            g.DrawString(axr, new Font("Arial Regular", 8), sb, 110, 65);
            g.Dispose();
        }
    }
}
