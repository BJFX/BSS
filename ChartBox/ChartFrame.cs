using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;
namespace ChartBox
{
    public class ChartFrame
    {
        public Color StartColor = Color.Black;
        public Color EndColor = Color.White;
        public float Gamma = 1;
        Point[] p;
        private double[] wave;
        double min = double.MaxValue;
        double max = double.MinValue;
        public int Ymax = 32768;//数据最大值
        public int Xmax = 100;//宽度
        private Bitmap fftcanvas;
        int BytePerSample =2;
        public int ChartGain = 3;
        public ChartFrame(int  bytepersample, int len, int amp)
        {
            BytePerSample = bytepersample;
            wave = new double[len];
            Ymax = amp;
            ChartGain = 3;
            fftcanvas = new Bitmap(761, 494);
            Graphics g = Graphics.FromImage(fftcanvas);
            g.Clear(Color.Black);
            g.Dispose();
        }

        public void Clear()
        {
            Array.Clear(wave,0,wave.Length);
            Graphics gisScreenDC = Graphics.FromImage(fftcanvas);
            gisScreenDC.Clear(Color.Black);
        }
        /// <summary>
        /// Process 16 bit sample
        /// </summary>
        /// <param name="wave"></param>
        
        public void AddData(byte[] buf, bool reverse=false)
        {
            int h = 0;
            Array.Clear(wave,0,wave.Length);
            for (int i = 0; i < buf.Length / BytePerSample; i++)
            {
                if (reverse==false)
                    wave[i] = BitConverter.ToInt16(buf,h);
                else
                {
                    wave[wave.Length - i-1] = BitConverter.ToInt16(buf, h);
                }
                h += BytePerSample;
            }
        }

        /// <summary>
        /// Render time domain to PictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
         /*
        public void RenderTimeDomain(ref PictureBox pictureBox)
        {
            if (wave == null)
                return;
            // Set up for drawing
            Graphics offScreenDC = Graphics.FromImage(canvas);
            offScreenDC.Clear(Color.Black);
            
            // Determine channnel boundries
            int width = canvas.Width;
            int height = canvas.Height;
            Pen pen = new System.Drawing.Pen(Color.WhiteSmoke);
            p = new Point[width];
            double scale = (double)height /(double) Ymax;  // a 16 bit sample has values from 0 to 32767
            //int xPrev = 0, yPrev = 0;
            double distance = (double)wave.Length / (double)width;
            for (int x = 0; x < width; x++)
            {
                int y = (int)(height - (wave[(int)(distance * x)] * scale));
                p[x] = new Point(x, y);
                
            }
            offScreenDC.DrawCurve(pen,p);
            // Clean up
            pictureBox.Image = canvas;
            offScreenDC.Dispose();
        }
 */

        /// <summary>
        /// Render waterfall Gis to PictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        public void RenderGis(ref PictureBox pictureBox,int slide)
        {

            Graphics offScreenDC = Graphics.FromImage(fftcanvas);

            int width = fftcanvas.Width;
            int height = fftcanvas.Height;

            // lock image
            PixelFormat format = fftcanvas.PixelFormat;
            BitmapData data = fftcanvas.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            int stride = data.Stride;
            int offset = stride - width * 4;
            double distance = (double)wave.Length / (double)width;
            int markheight = 10;
            try
            {
                unsafe
                {
                    //move rect
                    for (int y = height - 1; y >= markheight + slide; y--)
                    {
                        byte* pixel = (byte*) data.Scan0.ToPointer();
                        pixel += (y-slide)* stride; //src
                        for (int x = 0; x < width; x++)
                        {
                            byte* pixeldest = pixel + stride * slide;
                            pixeldest[0] = pixel[0];
                            pixeldest[1] = pixel[1];
                            pixeldest[2] = pixel[2];
                            pixeldest[3] = pixel[3];
                            pixel += 4 + offset;
                        }
                    }
                    //new points
                    for (int i = markheight; i < slide + markheight; i++)
                    {
                        byte* pixel = (byte*)data.Scan0.ToPointer();
                        pixel += i * stride;

                        for (int y = 0; y < width; y++)
                        {
                            double amplitude = (wave[(int)(distance * y)]);
                            amplitude *= ChartGain * ChartGain;
                            byte color = GetColor(amplitude,0);
                            pixel[0] = color;
                            color = GetColor(amplitude, 1);
                            pixel[1] = color;
                            color = GetColor(amplitude, 2);
                            pixel[2] = color;
                            pixel[3] = 255;
                            pixel +=4;
                            pixel += offset;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
           
            // unlock image
            fftcanvas.UnlockBits(data);
            
            // Clean up
            offScreenDC.Dispose();
            pictureBox.Image = fftcanvas;
        }


        /// <summary>
        /// Get color
        /// </summary>

        /// <returns></returns>
        private byte GetColor(double amplitude,int index)
        {
            double color = 0;
            double max = 255;
            switch (index)
            {
                case 0:
                    color = Math.Sqrt(amplitude)*(EndColor.B - StartColor.B)/255 + StartColor.B;
                    max = EndColor.B - StartColor.B;
                    break;
                case 1:
                    color = Math.Sqrt(amplitude) * (EndColor.G - StartColor.G) / 255 + StartColor.G;
                    max = EndColor.G - StartColor.G;
                    break;
                case 2:
                    color = Math.Sqrt(amplitude) * (EndColor.R - StartColor.R) / 255 + StartColor.R;
                    max = EndColor.R - StartColor.R;
                    break;
                default:
                    color = 255;
                    break;

            }
            color = Math.Pow(color / max, Gamma) * max;
            if (color > 255)
                color = 255;
            if (color < 0)
                color = 0;
            return (byte)color;
        }
        public void SetTitle(ref PictureBox picbox,string title)
        {
            Bitmap bitmap = new Bitmap(picbox.Width, picbox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawString(title, new Font("Arial Regular", 20), sb, picbox.Width/2-20,5);
            picbox.Image = bitmap;
            g.Dispose();

        }
        //绘制X轴上的宽度
        public void SetWidthAxis(ref PictureBox picbox)
        {
            Pen p1 = new Pen(Color.Black, 2);
            Pen p2 = new Pen(Color.Black, 1);
            SolidBrush sb = new SolidBrush(Color.Black);
            Bitmap bitmap = new Bitmap(picbox.Width, picbox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            double scale = (double)Ymax * 2 / (picbox.Height/2);//给定的最大刻度与实际像素的比例关系
            //开始画时域
            //第一个刻度的两个端点
            int xl = 3, yl = picbox.Height - 1, xr = 6, yr = picbox.Height - 1;
            for (int j = 0; j < 9; j++)
            {

                g.DrawLine(p1, xl, yl - j * picbox.Height / 16, xr, yl - j * picbox.Height / 16);//刻度线
                if((j>0)&&(j<8))
                {
                    string tempy = (- Ymax + 0.25*j*Ymax).ToString("0");
                    g.DrawString(tempy, new Font("Arial Regular", 8), sb, xl + 5, yl - j * picbox.Height / 16 - 5);
                }
               
            }
            g.DrawString("smpl", new Font("Arial Regular", 8), sb, xl + 1, picbox.Height / 2 + 2);
            
            picbox.Image = bitmap;
            g.Dispose();

        }

    }
}
