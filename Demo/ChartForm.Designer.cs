namespace Demo
{
    partial class ChartForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PlaybackTime = new System.Windows.Forms.Timer(this.components);
            this.openXtfFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartG1 = new ChartBox.ChartG();
            this.chartG2 = new ChartBox.ChartG();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.GPS = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PingTimeLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.Lat = new System.Windows.Forms.Label();
            this.Long = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.HeadLabel = new System.Windows.Forms.Label();
            this.RollLabel = new System.Windows.Forms.Label();
            this.PitchLabel = new System.Windows.Forms.Label();
            this.HeaveLabel = new System.Windows.Forms.Label();
            this.YawLabel = new System.Windows.Forms.Label();
            this.LiveMenu = new System.Windows.Forms.MenuStrip();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.GPS.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlaybackTime
            // 
            this.PlaybackTime.Enabled = true;
            this.PlaybackTime.Tick += new System.EventHandler(this.Playback_Tick);
            // 
            // openXtfFileDialog
            // 
            this.openXtfFileDialog.FileName = "openFileDialog1";
            this.openXtfFileDialog.Title = "选择回放文件";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(1298, 644);
            this.splitContainer1.SplitterDistance = 534;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartG1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartG2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1298, 534);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chartG1
            // 
            this.chartG1.AutoScroll = true;
            this.chartG1.AutoSize = true;
            this.chartG1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chartG1.BytePerSample = 2;
            this.chartG1.DisplayAmpMax = 32767;
            this.chartG1.DisplayLength = 2048;
            this.chartG1.DisplayWidthMax = 16000;
            this.chartG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartG1.Location = new System.Drawing.Point(4, 4);
            this.chartG1.Margin = new System.Windows.Forms.Padding(4);
            this.chartG1.Name = "chartG1";
            this.chartG1.Size = new System.Drawing.Size(641, 526);
            this.chartG1.TabIndex = 0;
            // 
            // chartG2
            // 
            this.chartG2.AutoScroll = true;
            this.chartG2.AutoSize = true;
            this.chartG2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chartG2.BytePerSample = 2;
            this.chartG2.DisplayAmpMax = 32767;
            this.chartG2.DisplayLength = 2048;
            this.chartG2.DisplayWidthMax = 16000;
            this.chartG2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartG2.Location = new System.Drawing.Point(653, 4);
            this.chartG2.Margin = new System.Windows.Forms.Padding(4);
            this.chartG2.Name = "chartG2";
            this.chartG2.Size = new System.Drawing.Size(641, 526);
            this.chartG2.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.GPS, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1298, 105);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // GPS
            // 
            this.GPS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GPS.Controls.Add(this.tableLayoutPanel2);
            this.GPS.Location = new System.Drawing.Point(4, 4);
            this.GPS.Margin = new System.Windows.Forms.Padding(4);
            this.GPS.Name = "GPS";
            this.GPS.Padding = new System.Windows.Forms.Padding(4);
            this.GPS.Size = new System.Drawing.Size(641, 97);
            this.GPS.TabIndex = 0;
            this.GPS.TabStop = false;
            this.GPS.Text = "GPS";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.PingTimeLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.SpeedLabel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Lat, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.Long, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(633, 70);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "纬度";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ping时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "船速";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "经度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PingTimeLabel
            // 
            this.PingTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PingTimeLabel.AutoSize = true;
            this.PingTimeLabel.Location = new System.Drawing.Point(122, 3);
            this.PingTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PingTimeLabel.Name = "PingTimeLabel";
            this.PingTimeLabel.Size = new System.Drawing.Size(16, 16);
            this.PingTimeLabel.TabIndex = 4;
            this.PingTimeLabel.Text = "-";
            this.PingTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(437, 3);
            this.SpeedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(16, 16);
            this.SpeedLabel.TabIndex = 5;
            this.SpeedLabel.Text = "-";
            this.SpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lat
            // 
            this.Lat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Lat.AutoSize = true;
            this.Lat.Location = new System.Drawing.Point(122, 26);
            this.Lat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lat.Name = "Lat";
            this.Lat.Size = new System.Drawing.Size(16, 16);
            this.Lat.TabIndex = 6;
            this.Lat.Text = "-";
            this.Lat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Long
            // 
            this.Long.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Long.AutoSize = true;
            this.Long.Location = new System.Drawing.Point(437, 26);
            this.Long.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Long.Name = "Long";
            this.Long.Size = new System.Drawing.Size(16, 16);
            this.Long.TabIndex = 7;
            this.Long.Text = "-";
            this.Long.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Location = new System.Drawing.Point(653, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(641, 97);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "姿态";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.HeadLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.RollLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.PitchLabel, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.HeaveLabel, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.YawLabel, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(633, 70);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Yaw";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Roll";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Heading";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Pitch";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Heave";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HeadLabel
            // 
            this.HeadLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HeadLabel.AutoSize = true;
            this.HeadLabel.Location = new System.Drawing.Point(122, 3);
            this.HeadLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(16, 16);
            this.HeadLabel.TabIndex = 5;
            this.HeadLabel.Text = "-";
            this.HeadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RollLabel
            // 
            this.RollLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RollLabel.AutoSize = true;
            this.RollLabel.Location = new System.Drawing.Point(122, 26);
            this.RollLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RollLabel.Name = "RollLabel";
            this.RollLabel.Size = new System.Drawing.Size(16, 16);
            this.RollLabel.TabIndex = 6;
            this.RollLabel.Text = "-";
            this.RollLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PitchLabel
            // 
            this.PitchLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PitchLabel.AutoSize = true;
            this.PitchLabel.Location = new System.Drawing.Point(437, 3);
            this.PitchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PitchLabel.Name = "PitchLabel";
            this.PitchLabel.Size = new System.Drawing.Size(16, 16);
            this.PitchLabel.TabIndex = 7;
            this.PitchLabel.Text = "-";
            this.PitchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HeaveLabel
            // 
            this.HeaveLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HeaveLabel.AutoSize = true;
            this.HeaveLabel.Location = new System.Drawing.Point(437, 26);
            this.HeaveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeaveLabel.Name = "HeaveLabel";
            this.HeaveLabel.Size = new System.Drawing.Size(16, 16);
            this.HeaveLabel.TabIndex = 8;
            this.HeaveLabel.Text = "-";
            this.HeaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // YawLabel
            // 
            this.YawLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.YawLabel.AutoSize = true;
            this.YawLabel.Location = new System.Drawing.Point(122, 50);
            this.YawLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.YawLabel.Name = "YawLabel";
            this.YawLabel.Size = new System.Drawing.Size(16, 16);
            this.YawLabel.TabIndex = 9;
            this.YawLabel.Text = "-";
            this.YawLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LiveMenu
            // 
            this.LiveMenu.Location = new System.Drawing.Point(0, 0);
            this.LiveMenu.Name = "LiveMenu";
            this.LiveMenu.Size = new System.Drawing.Size(1298, 24);
            this.LiveMenu.TabIndex = 6;
            this.LiveMenu.Text = "menuStrip1";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 668);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LiveMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.LiveMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChartForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.GPS.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer PlaybackTime;
        private System.Windows.Forms.OpenFileDialog openXtfFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox GPS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label PingTimeLabel;
        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Label RollLabel;
        private System.Windows.Forms.Label PitchLabel;
        private System.Windows.Forms.Label HeaveLabel;
        private System.Windows.Forms.Label YawLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label Lat;
        private System.Windows.Forms.Label Long;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ChartBox.ChartG chartG1;
        private ChartBox.ChartG chartG2;
        private System.Windows.Forms.MenuStrip LiveMenu;
    }
}

