using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Demo.MapCustmize;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Demo.Forms
{
    public partial class NavigationView : Form
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
        PointLatLng start;
        PointLatLng end;
        Graphics g;
        List<PointLatLng> gpstrack = new List<PointLatLng>();
        public float bearing = 0.0F;
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
            NodeMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            CultureInfo ci = new CultureInfo("en-us");
            PointLatLng gpspos = NodeMarker.Position;
            NodeMarker.ToolTipText = "GPS\r\n经度=" + gpspos.Lng.ToString("F06", ci) + "\r\n纬度=" + gpspos.Lat.ToString("F06", ci);
            MainMap.MapType = MapType.None;
            MainMap.MinZoom = 1;
            MainMap.MaxZoom = 18;
            MainMap.Zoom = 16;
            MainMap.MapName = "Survey";
            
        }
    }
}
