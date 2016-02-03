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

        }
    }
}
