using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Survey.Properties;
using Survey.MapCustmize;

namespace Survey.Forms
{
    public partial class NavigationView : Office2007Form
    {
        private MainForm mf;
        // marker
        public UserMarker NodeMarker;
        GMapMarker center;
        //地图覆盖层
        readonly GMapOverlay mainOverlay;
        // layers
        internal GMapOverlay DistanceInfo;
        internal GMapOverlay objects;
        //internal GMapOverlay routes;
        internal GMapOverlay Net;
        internal GMapOverlay track;
        internal GMapOverlay rulers;
        internal GMapOverlay infolayers;
        internal GMapOverlay WebNodeLayer;
        GMapMarkerRect CurentRectMarker = null;
        GMapMarker CurrentMarker = null;
        GMapMarker ModifyMarker = null;
        GMapMarker DistanceMarker = null;
        bool isMouseDown = false;
        public bool isRulerDown = false;
        bool isOnMarker = false;
        bool isStartDown = false;
        bool isNodeShown = true;
        bool isInfoClick = false;
        bool isShowAni = true;
        private bool isTrackShow = false;
        PointLatLng start;
        PointLatLng end;
        Graphics g;
        List<PointLatLng> gpstrack = new List<PointLatLng>();
        public float bearing = 0.0F;
        public int TrackTrip = 5000;
        public int TrackGap = 10;
        public string MapTitle = "Survey";
        private double R = 6378137; // WGS-84;
        public NavigationView(MainForm mainForm)
        {
            mf = mainForm;
            InitializeComponent();
            mainOverlay = new GMapOverlay(MainMap, "map");
            MainMap.Overlays.Add(mainOverlay);

            //routes = new GMapOverlay(MainMap, "routes");
            //MainMap.Overlays.Add(routes);

            Net = new GMapOverlay(MainMap, "net");
            MainMap.Overlays.Add(Net);

            track = new GMapOverlay(MainMap, "polygons");
            MainMap.Overlays.Add(track);

            objects = new GMapOverlay(MainMap, "objects");
            MainMap.Overlays.Add(objects);

            rulers = new GMapOverlay(MainMap, "rulers");
            MainMap.Overlays.Add(rulers);

            DistanceInfo = new GMapOverlay(MainMap, "DistanceInfo");
            MainMap.Overlays.Add(DistanceInfo);

            infolayers = new GMapOverlay(MainMap, "Info");
            MainMap.Overlays.Add(infolayers);

            WebNodeLayer = new GMapOverlay(MainMap, "webnode");
            MainMap.Overlays.Add(WebNodeLayer);
            g = MainMap.CreateGraphics();

        }

        private void NavigationView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            mf.ChildFormClose(this);
        }

        private void NavigationView_Load(object sender, EventArgs e)
        {
            MainMap.Manager.Mode = AccessMode.CacheOnly;
            PointLatLng p = new PointLatLng(0.0, 0.0);

            // map center
            center = new GMapMarkerCross(MainMap.Position);
            objects.Markers.Add(center);
            MainMap.Position = p;
            NodeMarker = new UserMarker(p);
            NodeMarker.IsHitTestVisible = true;
            objects.Markers.Add(NodeMarker);
            NodeMarker.ToolTip = new MapToolTip(NodeMarker);
            NodeMarker.ToolTipMode = MarkerTooltipMode.Always;
            PointLatLng gpspos = NodeMarker.Position;
            string lngstr, latstr;
            if (gpspos.Lng > 0)
                lngstr = gpspos.Lng.ToString("F06") + " E";
            else
                lngstr = (-gpspos.Lng).ToString("F06") + " W";
            if (gpspos.Lat > 0)
                latstr = gpspos.Lat.ToString("F06") + " N";
            else
                latstr = (-gpspos.Lat).ToString("F06") + " S";
            NodeMarker.ToolTipText = "GPS\r\n经度=" + lngstr + "\r\n纬度=" + latstr;
            MainMap.MapType = MapType.None;
            MainMap.MinZoom = 1;
            MainMap.MaxZoom = 18;
            MainMap.Zoom = 15;
            MainMap.MapName = MapTitle;
            ShowTrack.PerformClick();
            AutoTrack.PerformClick();
            
        }
        public  double CalcDistance(PointLatLng start, PointLatLng end)
        {
            double pidiv180 = Math.PI / 180;
            double a = Math.Pow(Math.Sin((start.Lat - end.Lat) / 2 * pidiv180), 2)
                + Math.Cos(start.Lat * pidiv180) * Math.Cos(end.Lat * pidiv180)
                * Math.Pow(Math.Sin((start.Lng - end.Lng) / 2 * pidiv180), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
        public void AddLocation(double lat, double lng,float bearing)
        {
            var pt = new PointLatLng(lat, lng);
            if (gpstrack.Count == 0)
            {
                gpstrack.Add(pt);
            }
            while (gpstrack.Count > TrackTrip/TrackGap)
            {
                gpstrack.RemoveAt(0);
            }
            if (CalcDistance(gpstrack[gpstrack.Count - 1], pt) > TrackGap)
            {
                gpstrack.Add(pt);
                if (isTrackShow)
                {
                    track.Routes.Clear();
                    GMapRoute gr = new GMapRoute(gpstrack, "Track");
                    track.Routes.Add(gr);
                }
            }
            NodeMarker.Position = pt;
            NodeMarker.Bearing = bearing;
            if (AutoTrack.Checked)
                MainMap.Position = pt;
            CultureInfo ci = new CultureInfo("en-us");
            string lngstr, latstr;
            if (pt.Lng > 0)
                lngstr = pt.Lng.ToString("F06") + " E";
            else
                lngstr = (-pt.Lng).ToString("F06") + " W";
            if (pt.Lat > 0)
                latstr = pt.Lat.ToString("F06") + " N";
            else
                latstr = (-pt.Lat).ToString("F06") + " S";
            NodeMarker.ToolTipText = "GPS\r\n经度=" + lngstr + "\r\n纬度=" + latstr;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            ZoomIn.Enabled = true;
            if (MainMap.Zoom < MainMap.MaxZoom)
                MainMap.Zoom++;
            if (MainMap.Zoom == MainMap.MaxZoom)
                ZoomOut.Enabled = false;
            MainMap.Update();
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            ZoomOut.Enabled = true;
            if (MainMap.Zoom > MainMap.MinZoom)
                MainMap.Zoom--;
            if (MainMap.Zoom == MainMap.MinZoom)
                ZoomIn.Enabled = false;
            MainMap.Update();
        }

        private void TrackSet_Click(object sender, EventArgs e)
        {

        }

        private void ShowTrack_Click(object sender, EventArgs e)
        {
            if (ShowTrack.Checked)
            {
                isTrackShow = true;
                track.IsVisibile = true;
            }
            else
            {
                isTrackShow = false;
                track.IsVisibile = false;
            }
        }

        private void Ranging_Click(object sender, EventArgs e)
        {
            if (!isRulerDown)
                isRulerDown = true;
            else
            {
                isRulerDown = false;
                isStartDown = false;
                MainMap.Refresh();
            }
        }

        private void ReturnNode_Click(object sender, EventArgs e)
        {
            MainMap.Position = NodeMarker.Position;
        }

        private void MainMap_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainMap.Focused)
            {
                if (e.KeyCode == Keys.Escape && isRulerDown)
                {
                    isRulerDown = false;
                    isStartDown = false;
                    MainMap.Refresh();
                }

            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                if (isRulerDown)
                {
                    if (isStartDown)
                    {
                        end = MainMap.FromLocalToLatLng(e.X, e.Y);
                        double d = CalcDistance(start, end);
                        isStartDown = false;

                        //String drawString = "距离 = " + d.ToString("00", CultureInfo.InvariantCulture) + "m";
                        //PointLatLng middle = new PointLatLng();
                        //middle.Lat = start.Lat + (end.Lat - start.Lat)/2;
                        //middle.Lng = start.Lng + (end.Lng - start.Lng)/2;
                        //DistanceMarker = new GMapInfoBoard(middle, drawString);
                        //DistanceMarker.DisableRegionCheck = false;
                        //DistanceInfo.Markers.Add(DistanceMarker);
                        //List<PointLatLng> track = new List<PointLatLng>();
                        //track.Add(start);
                        //track.Add(end);
                        //GMapRoute Ruler = new GMapRoute(track, drawString);
                        //rulers.Routes.Add(Ruler);
                        //DistanceMarker.ToolTipMode = MarkerTooltipMode.Never;

                    }
                    else
                    {
                        start = MainMap.FromLocalToLatLng(e.X, e.Y);
                        isStartDown = true;

                    }
                }
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isRulerDown)
            {
                g = MainMap.CreateGraphics();
                MainMap.Refresh();
                g.DrawImageUnscaled(Resources.ruler, e.X, e.Y);
                if (isStartDown)
                {
                    using (Pen myPen = new Pen(Brushes.Black))
                    {

                        GPoint p = MainMap.FromLatLngToLocal(start);
                        end = MainMap.FromLocalToLatLng(e.X, e.Y);
                        Point pp = new Point(p.X, p.Y);
                        g.DrawLine(myPen, pp, e.Location);
                        double d = CalcDistance(start, end);
                        if (d > 1)
                        {
                            String drawString = "距离 = " + d.ToString("00", CultureInfo.InvariantCulture) + "米";

                            // Create font and brush.
                            Font drawFont = new Font("Arial", 16);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);
                            PointF drawPoint = new PointF(e.X, e.Y);
                            g.DrawString(drawString, drawFont, drawBrush, drawPoint);
                        }
                    }
                }

            }
        }
    }
}
