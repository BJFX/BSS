namespace Demo
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.ribbonTabItem2 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.StatusLabel = new DevComponents.DotNetBar.LabelItem();
            this.RangeLabel = new DevComponents.DotNetBar.LabelItem();
            this.LatLabel = new DevComponents.DotNetBar.LabelItem();
            this.LongLabel = new DevComponents.DotNetBar.LabelItem();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.Session = new DevComponents.DotNetBar.ButtonItem();
            this.NewStateBtn = new DevComponents.DotNetBar.ButtonItem();
            this.OpenStateFileBtn = new DevComponents.DotNetBar.ButtonItem();
            this.SaveBtn = new DevComponents.DotNetBar.ButtonItem();
            this.OpenDeviceFile = new DevComponents.DotNetBar.ButtonItem();
            this.SaveDeviceBtn = new DevComponents.DotNetBar.ButtonItem();
            this.Source = new DevComponents.DotNetBar.ButtonItem();
            this.FromSonar = new DevComponents.DotNetBar.ButtonItem();
            this.FromFile = new DevComponents.DotNetBar.ButtonItem();
            this.Print = new DevComponents.DotNetBar.ButtonItem();
            this.Windows = new DevComponents.DotNetBar.ButtonItem();
            this.Help = new DevComponents.DotNetBar.ButtonItem();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.DataPanel = new DevComponents.DotNetBar.PanelEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenBssChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.DataSaveBox = new System.Windows.Forms.ToolStripTextBox();
            this.ShowBss = new DevComponents.DotNetBar.ButtonItem();
            this.ShowNavi = new DevComponents.DotNetBar.ButtonItem();
            this.ShowSensor = new DevComponents.DotNetBar.ButtonItem();
            this.ShowRaw = new DevComponents.DotNetBar.ButtonItem();
            this.ShowInfoRegion = new DevComponents.DotNetBar.ButtonItem();
            this.dockSite7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.DataPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // ribbonTabItem2
            // 
            this.ribbonTabItem2.Name = "ribbonTabItem2";
            this.ribbonTabItem2.Text = "ribbonTabItem2";
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Checked = true;
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Text = "ribbonTabItem1";
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.StatusLabel,
            this.RangeLabel,
            this.LatLabel,
            this.LongLabel});
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 696);
            this.metroStatusBar1.Margin = new System.Windows.Forms.Padding(4);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(1350, 29);
            this.metroStatusBar1.TabIndex = 0;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.BorderSide = DevComponents.DotNetBar.eBorderSide.Left;
            this.StatusLabel.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.StatusLabel.DividerStyle = true;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Text = "...";
            this.StatusLabel.Width = 300;
            // 
            // RangeLabel
            // 
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Text = "...";
            this.RangeLabel.Width = 200;
            // 
            // LatLabel
            // 
            this.LatLabel.Name = "LatLabel";
            this.LatLabel.Text = "...";
            this.LatLabel.Width = 200;
            // 
            // LongLabel
            // 
            this.LongLabel.Name = "LongLabel";
            this.LongLabel.Text = "Long";
            this.LongLabel.Width = 200;
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManager1.BottomDockSite = this.dockSite4;
            this.dotNetBarManager1.EnableFullSizeDock = false;
            this.dotNetBarManager1.LeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.dockSite2;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManager1.TopDockSite = this.dockSite3;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(0, 725);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(1350, 0);
            this.dockSite4.TabIndex = 5;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(0, 26);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 670);
            this.dockSite1.TabIndex = 2;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(1350, 26);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 670);
            this.dockSite2.TabIndex = 3;
            this.dockSite2.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 725);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(1350, 0);
            this.dockSite8.TabIndex = 9;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 26);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 699);
            this.dockSite5.TabIndex = 6;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(1350, 26);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 699);
            this.dockSite6.TabIndex = 7;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Controls.Add(this.bar1);
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(1350, 26);
            this.dockSite7.TabIndex = 8;
            this.dockSite7.TabStop = false;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Session,
            this.Source,
            this.Print,
            this.Windows,
            this.Help});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.MenuBar = true;
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1350, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 0;
            this.bar1.TabNavigation = true;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // Session
            // 
            this.Session.Name = "Session";
            this.Session.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.NewStateBtn,
            this.OpenStateFileBtn,
            this.SaveBtn,
            this.OpenDeviceFile,
            this.SaveDeviceBtn});
            this.Session.Text = "Session";
            // 
            // NewStateBtn
            // 
            this.NewStateBtn.Name = "NewStateBtn";
            this.NewStateBtn.Text = "状态新建";
            // 
            // OpenStateFileBtn
            // 
            this.OpenStateFileBtn.Name = "OpenStateFileBtn";
            this.OpenStateFileBtn.Text = "打开状态文件";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Text = "保存状态文件";
            // 
            // OpenDeviceFile
            // 
            this.OpenDeviceFile.Name = "OpenDeviceFile";
            this.OpenDeviceFile.Text = "打开设备文件";
            // 
            // SaveDeviceBtn
            // 
            this.SaveDeviceBtn.Name = "SaveDeviceBtn";
            this.SaveDeviceBtn.Text = "保存设备文件";
            // 
            // Source
            // 
            this.Source.Name = "Source";
            this.Source.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.FromSonar,
            this.FromFile});
            this.Source.Text = "Source";
            // 
            // FromSonar
            // 
            this.FromSonar.Name = "FromSonar";
            this.FromSonar.Text = "来自声纳";
            // 
            // FromFile
            // 
            this.FromFile.Name = "FromFile";
            this.FromFile.Text = "来自文件";
            // 
            // Print
            // 
            this.Print.Name = "Print";
            this.Print.Text = "Print";
            // 
            // Windows
            // 
            this.Windows.Name = "Windows";
            this.Windows.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ShowBss,
            this.ShowNavi,
            this.ShowSensor,
            this.ShowRaw,
            this.ShowInfoRegion});
            this.Windows.Text = "Windows";
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Text = "Help";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 26);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(1350, 0);
            this.dockSite3.TabIndex = 4;
            this.dockSite3.TabStop = false;
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "dockContainerItem1";
            // 
            // DataPanel
            // 
            this.DataPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.DataPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DataPanel.Controls.Add(this.tableLayoutPanel1);
            this.DataPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataPanel.Location = new System.Drawing.Point(0, 589);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(1350, 107);
            this.DataPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.DataPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.DataPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.DataPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.DataPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.DataPanel.Style.GradientAngle = 90;
            this.DataPanel.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 107);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenBssChart,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.DataSaveBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1350, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenBssChart
            // 
            this.OpenBssChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenBssChart.Image = ((System.Drawing.Image)(resources.GetObject("OpenBssChart.Image")));
            this.OpenBssChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenBssChart.Name = "OpenBssChart";
            this.OpenBssChart.Size = new System.Drawing.Size(23, 22);
            this.OpenBssChart.Text = "toolStripButton1";
            this.OpenBssChart.Click += new System.EventHandler(this.OpenBssChart_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // DataSaveBox
            // 
            this.DataSaveBox.BackColor = System.Drawing.Color.Red;
            this.DataSaveBox.Name = "DataSaveBox";
            this.DataSaveBox.Size = new System.Drawing.Size(100, 25);
            this.DataSaveBox.Text = "XTF数据未保存";
            this.DataSaveBox.Click += new System.EventHandler(this.DataSaveBox_Click);
            // 
            // ShowBss
            // 
            this.ShowBss.Name = "ShowBss";
            this.ShowBss.Text = "侧扫瀑布图";
            // 
            // ShowNavi
            // 
            this.ShowNavi.Name = "ShowNavi";
            this.ShowNavi.Text = "导航图";
            // 
            // ShowSensor
            // 
            this.ShowSensor.Name = "ShowSensor";
            this.ShowSensor.Text = "传感器图";
            // 
            // ShowRaw
            // 
            this.ShowRaw.Name = "ShowRaw";
            this.ShowRaw.Text = "原始数据图";
            // 
            // ShowInfoRegion
            // 
            this.ShowInfoRegion.Name = "ShowInfoRegion";
            this.ShowInfoRegion.Text = "信息栏";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1350, 725);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.DataPanel);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.metroStatusBar1);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Version 2.01 BSS Sonar Processing System –UAI（北京联合声信海洋技术有限公司）";
            this.TitleText = "Version 2.01 BSS Sonar Processing System –UAI（北京联合声信海洋技术有限公司）";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.dockSite7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.DataPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem2;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem StatusLabel;
        private DevComponents.DotNetBar.LabelItem RangeLabel;
        private DevComponents.DotNetBar.LabelItem LatLabel;
        private DevComponents.DotNetBar.LabelItem LongLabel;
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem Session;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem1;
        private DevComponents.DotNetBar.ButtonItem Source;
        private DevComponents.DotNetBar.ButtonItem Print;
        private DevComponents.DotNetBar.ButtonItem Windows;
        private DevComponents.DotNetBar.ButtonItem Help;
        private DevComponents.DotNetBar.PanelEx DataPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonItem NewStateBtn;
        private DevComponents.DotNetBar.ButtonItem OpenStateFileBtn;
        private DevComponents.DotNetBar.ButtonItem SaveBtn;
        private DevComponents.DotNetBar.ButtonItem OpenDeviceFile;
        private DevComponents.DotNetBar.ButtonItem SaveDeviceBtn;
        private DevComponents.DotNetBar.ButtonItem FromSonar;
        private DevComponents.DotNetBar.ButtonItem FromFile;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton OpenBssChart;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripTextBox DataSaveBox;
        private DevComponents.DotNetBar.ButtonItem ShowBss;
        private DevComponents.DotNetBar.ButtonItem ShowNavi;
        private DevComponents.DotNetBar.ButtonItem ShowSensor;
        private DevComponents.DotNetBar.ButtonItem ShowRaw;
        private DevComponents.DotNetBar.ButtonItem ShowInfoRegion;
    }
}