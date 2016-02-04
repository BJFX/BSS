using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace Demo.MapCustmize
{
    public class CustomMap:GMapControl
    {
        public long ElapsedMilliseconds;
        public string MapName;
        readonly Font DebugFont = new Font(FontFamily.GenericMonospace, 25, FontStyle.Regular);
        readonly Font latFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Regular);
        Pen latPen = new Pen(Brushes.Purple,1);
        Pen longPen = new Pen(Brushes.Brown, 1);
        /// <summary>
        /// any custom drawing here
        /// </summary>
        /// <param name="drawingContext"></param>
        protected override void OnPaintEtc(Graphics g)
        {
            base.OnPaintEtc(g);
            string name = MapName;
            PointLatLng p = this.Position;
            //name += "(" + p.Lng.ToString("F05", CultureInfo.InvariantCulture) + "," + p.Lat.ToString("F05", CultureInfo.InvariantCulture) + ")";
            g.DrawString(name, DebugFont, Brushes.Black, 23, 23);
            g.DrawLine(latPen,0,this.Height/3,this.Width,this.Height/3);
            g.DrawLine(latPen,0,this.Height*2/3,this.Width,this.Height*2/3);
            g.DrawLine(longPen,this.Width/3,0,this.Width/3,this.Height);
            g.DrawLine(longPen,this.Width*2/3,0,this.Width*2/3,this.Height);
            PointLatLng lat1 = FromLocalToLatLng(0, this.Height/3);
            PointLatLng lat2 = FromLocalToLatLng(0, this.Height*2 / 3);
            PointLatLng long1 = FromLocalToLatLng(this.Width/3, 0);
            PointLatLng long2 = FromLocalToLatLng(this.Width*2/3, 0);
            string latstr,longstr;
            if(lat1.Lat>0)
                latstr  = lat1.Lat.ToString("F06")+" N";
            else
                latstr = (-lat1.Lat).ToString("F06") + " S";
            g.DrawString(latstr, latFont, Brushes.Purple, 0, this.Height / 3 - 15);
            if (lat2.Lat > 0)
                latstr = lat2.Lat.ToString("F06") + " N";
            else
                latstr = (-lat2.Lat).ToString("F06") + " S";
            g.DrawString(latstr, latFont, Brushes.Purple, 0, this.Height * 2 / 3 - 15);

            if (long1.Lng > 0)
                longstr = long1.Lng.ToString("F06") + " E";
            else
                longstr = (-long1.Lng).ToString("F06") + " W";
            g.DrawString(longstr, latFont, Brushes.Brown,  this.Width / 3,0);
            if (long2.Lng > 0)
                longstr = long2.Lng.ToString("F06") + " E";
            else
                longstr = (-long2.Lng).ToString("F06") + " W";
            g.DrawString(longstr, latFont, Brushes.Brown,this.Width * 2 / 3,0);
        }
    }
}
