using Survey.MapCustmize;

namespace Survey.Forms
{
    partial class NavigationView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TrackSet = new System.Windows.Forms.ToolStripButton();
            this.ShowTrack = new System.Windows.Forms.ToolStripButton();
            this.Ranging = new System.Windows.Forms.ToolStripButton();
            this.AutoTrack = new System.Windows.Forms.ToolStripButton();
            this.ReturnNode = new System.Windows.Forms.ToolStripButton();
            this.MainMap = new CustomMap();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomOut,
            this.ZoomIn,
            this.toolStripSeparator1,
            this.TrackSet,
            this.ShowTrack,
            this.Ranging,
            this.AutoTrack,
            this.ReturnNode,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(499, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ZoomOut
            // 
            this.ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOut.Image")));
            this.ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(52, 22);
            this.ZoomOut.Text = "放大";
            this.ZoomOut.ToolTipText = "导航图放大";
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // ZoomIn
            // 
            this.ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomIn.Image")));
            this.ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(52, 22);
            this.ZoomIn.Text = "缩小";
            this.ZoomIn.ToolTipText = "导航图缩小";
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TrackSet
            // 
            this.TrackSet.Image = ((System.Drawing.Image)(resources.GetObject("TrackSet.Image")));
            this.TrackSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TrackSet.Name = "TrackSet";
            this.TrackSet.Size = new System.Drawing.Size(76, 22);
            this.TrackSet.Text = "航迹设置";
            this.TrackSet.Click += new System.EventHandler(this.TrackSet_Click);
            // 
            // ShowTrack
            // 
            this.ShowTrack.CheckOnClick = true;
            this.ShowTrack.Image = ((System.Drawing.Image)(resources.GetObject("ShowTrack.Image")));
            this.ShowTrack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowTrack.Name = "ShowTrack";
            this.ShowTrack.Size = new System.Drawing.Size(76, 22);
            this.ShowTrack.Text = "显示航迹";
            this.ShowTrack.ToolTipText = "将航迹显示在导航图上";
            this.ShowTrack.Click += new System.EventHandler(this.ShowTrack_Click);
            // 
            // Ranging
            // 
            this.Ranging.Image = ((System.Drawing.Image)(resources.GetObject("Ranging.Image")));
            this.Ranging.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ranging.Name = "Ranging";
            this.Ranging.Size = new System.Drawing.Size(52, 22);
            this.Ranging.Text = "测距";
            this.Ranging.ToolTipText = "测量导航图上两点间距,按Esc退出";
            this.Ranging.Click += new System.EventHandler(this.Ranging_Click);
            // 
            // AutoTrack
            // 
            this.AutoTrack.CheckOnClick = true;
            this.AutoTrack.Image = ((System.Drawing.Image)(resources.GetObject("AutoTrack.Image")));
            this.AutoTrack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AutoTrack.Name = "AutoTrack";
            this.AutoTrack.Size = new System.Drawing.Size(76, 22);
            this.AutoTrack.Text = "自动跟踪";
            this.AutoTrack.ToolTipText = "自动将目标置于地图中心";
            // 
            // ReturnNode
            // 
            this.ReturnNode.Image = ((System.Drawing.Image)(resources.GetObject("ReturnNode.Image")));
            this.ReturnNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReturnNode.Name = "ReturnNode";
            this.ReturnNode.Size = new System.Drawing.Size(88, 22);
            this.ReturnNode.Text = "回到目标点";
            this.ReturnNode.ToolTipText = "地图中心点回到目标点";
            this.ReturnNode.Click += new System.EventHandler(this.ReturnNode_Click);
            // 
            // MainMap
            // 
            this.MainMap.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 25);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 17;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(499, 463);
            this.MainMap.TabIndex = 1;
            this.MainMap.Zoom = 17D;
            this.MainMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMap_KeyDown);
            this.MainMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseDown);
            this.MainMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseMove);
            this.MainMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseUp);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NavigationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(499, 488);
            this.Controls.Add(this.MainMap);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NavigationView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导航";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NavigationView_FormClosing);
            this.Load += new System.EventHandler(this.NavigationView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ZoomOut;
        private System.Windows.Forms.ToolStripButton ZoomIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TrackSet;
        private System.Windows.Forms.ToolStripButton ShowTrack;
        private System.Windows.Forms.ToolStripButton Ranging;
        private CustomMap MainMap;
        private System.Windows.Forms.ToolStripButton AutoTrack;
        private System.Windows.Forms.ToolStripButton ReturnNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        
    }
}