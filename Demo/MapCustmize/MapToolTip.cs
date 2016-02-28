using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using GMap.NET.WindowsForms;
namespace Survey.MapCustmize
{
    public class MapToolTip : GMapToolTip
    {
        public float Radius = 10f;

      public MapToolTip(GMapMarker marker)
         : base(marker)
      {
         Stroke = new Pen(Color.FromArgb(120, Color.Black));
         Stroke.Width = 1;
         this.Stroke.LineJoin = LineJoin.Round;
         this.Stroke.StartCap = LineCap.RoundAnchor;
         Fill = Brushes.Azure;
         Foreground = Brushes.Black;
      }

      public override void Draw(Graphics g)
      {
         Size st = g.MeasureString(Marker.ToolTipText, Font).ToSize();
         Rectangle rect = new Rectangle(Marker.ToolTipPosition.X, Marker.ToolTipPosition.Y - st.Height, st.Width + TextPadding.Width, st.Height + TextPadding.Height);
          Offset.X = 0;
          rect.Offset(Offset.X, Offset.Y);

         using(GraphicsPath objGP = new GraphicsPath())
         {
            objGP.AddLine(rect.X + 2 * Radius, rect.Y + rect.Height, rect.X + Radius, rect.Y + rect.Height + Radius);
            objGP.AddLine(rect.X + Radius, rect.Y + rect.Height + Radius, rect.X + Radius, rect.Y + rect.Height);

            objGP.AddArc(rect.X, rect.Y + rect.Height - (Radius * 2), Radius * 2, Radius * 2, 90, 90);
            objGP.AddLine(rect.X, rect.Y + rect.Height - (Radius * 2), rect.X, rect.Y + Radius);
            objGP.AddArc(rect.X, rect.Y, Radius * 2, Radius * 2, 180, 90);
            objGP.AddLine(rect.X + Radius, rect.Y, rect.X + rect.Width - (Radius * 2), rect.Y);
            objGP.AddArc(rect.X + rect.Width - (Radius * 2), rect.Y, Radius * 2, Radius * 2, 270, 90);
            objGP.AddLine(rect.X + rect.Width, rect.Y + Radius, rect.X + rect.Width, rect.Y + rect.Height - (Radius * 2));
            objGP.AddArc(rect.X + rect.Width - (Radius * 2), rect.Y + rect.Height - (Radius * 2), Radius * 2, Radius * 2, 0, 90); // Corner

            objGP.CloseFigure();

            g.FillPath(Fill, objGP);
            g.DrawPath(Stroke, objGP);
         }

         g.DrawString(Marker.ToolTipText, Font, Foreground, rect, Format);

   }

}
}
