using Demo.MapCustmize;

namespace Demo.Forms
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
            this.MainMap = new Demo.MapCustmize.CustomMap();
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
            this.Ranging});
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
            // 
            // ZoomIn
            // 
            this.ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomIn.Image")));
            this.ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(52, 22);
            this.ZoomIn.Text = "缩小";
            this.ZoomIn.ToolTipText = "导航图缩小";
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
            // 
            // Ranging
            // 
            this.Ranging.Image = ((System.Drawing.Image)(resources.GetObject("Ranging.Image")));
            this.Ranging.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ranging.Name = "Ranging";
            this.Ranging.Size = new System.Drawing.Size(52, 22);
            this.Ranging.Text = "测距";
            this.Ranging.ToolTipText = "测量导航图上两点间距";
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
    }
}