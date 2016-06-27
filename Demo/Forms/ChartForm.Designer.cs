namespace Survey.Forms
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
            this.openXtfFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.SideTable = new System.Windows.Forms.TableLayoutPanel();
            this.waveRight = new ChartBox.WaveBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartLeft = new ChartBox.ChartG();
            this.waveLeft = new ChartBox.WaveBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartRight = new ChartBox.ChartG();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.图像参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.控制参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SideTable.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openXtfFileDialog
            // 
            this.openXtfFileDialog.FileName = "openFileDialog1";
            this.openXtfFileDialog.Title = "选择回放文件";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // SideTable
            // 
            this.SideTable.AutoScroll = true;
            this.SideTable.AutoSize = true;
            this.SideTable.ColumnCount = 2;
            this.SideTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SideTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SideTable.Controls.Add(this.waveRight, 1, 0);
            this.SideTable.Controls.Add(this.panel1, 0, 1);
            this.SideTable.Controls.Add(this.waveLeft, 0, 0);
            this.SideTable.Controls.Add(this.panel2, 1, 1);
            this.SideTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideTable.Location = new System.Drawing.Point(0, 0);
            this.SideTable.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.SideTable.Name = "SideTable";
            this.SideTable.RowCount = 2;
            this.SideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.SideTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.SideTable.Size = new System.Drawing.Size(1391, 616);
            this.SideTable.TabIndex = 13;
            this.SideTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SideTable_MouseClick);
            // 
            // waveRight
            // 
            this.waveRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.waveRight.BackColor = System.Drawing.Color.White;
            this.waveRight.BytePerSample = 2;
            this.waveRight.DisplayAmpMax = 32767;
            this.waveRight.DisplayLength = 2048;
            this.waveRight.DisplayWidthMax = 16000;
            this.waveRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waveRight.Font = new System.Drawing.Font("宋体", 12F);
            this.waveRight.Location = new System.Drawing.Point(696, 0);
            this.waveRight.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.waveRight.Name = "waveRight";
            this.waveRight.Size = new System.Drawing.Size(695, 100);
            this.waveRight.TabIndex = 4;
            this.waveRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.waveRight_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 510);
            this.panel1.TabIndex = 2;
            // 
            // chartLeft
            // 
            this.chartLeft.AutoSize = true;
            this.chartLeft.BytePerSample = 2;
            this.chartLeft.DisplayAmpMax = 32767;
            this.chartLeft.DisplayLength = 2048;
            this.chartLeft.DisplayWidthMax = 200;
            this.chartLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLeft.Font = new System.Drawing.Font("宋体", 12F);
            this.chartLeft.Gain = 3;
            this.chartLeft.Location = new System.Drawing.Point(0, 0);
            this.chartLeft.Margin = new System.Windows.Forms.Padding(0);
            this.chartLeft.Name = "chartLeft";
            this.chartLeft.Size = new System.Drawing.Size(689, 510);
            this.chartLeft.TabIndex = 1;
            this.chartLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartLeft_MouseClick);
            // 
            // waveLeft
            // 
            this.waveLeft.BackColor = System.Drawing.Color.White;
            this.waveLeft.BytePerSample = 2;
            this.waveLeft.DisplayAmpMax = 32767;
            this.waveLeft.DisplayLength = 2048;
            this.waveLeft.DisplayWidthMax = 16000;
            this.waveLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waveLeft.Font = new System.Drawing.Font("宋体", 12F);
            this.waveLeft.Location = new System.Drawing.Point(0, 0);
            this.waveLeft.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.waveLeft.Name = "waveLeft";
            this.waveLeft.Size = new System.Drawing.Size(694, 100);
            this.waveLeft.TabIndex = 3;
            this.waveLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.waveLeft_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chartRight);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(698, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 510);
            this.panel2.TabIndex = 5;
            // 
            // chartRight
            // 
            this.chartRight.AutoSize = true;
            this.chartRight.BytePerSample = 2;
            this.chartRight.DisplayAmpMax = 32767;
            this.chartRight.DisplayLength = 2048;
            this.chartRight.DisplayWidthMax = 200;
            this.chartRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRight.Font = new System.Drawing.Font("宋体", 12F);
            this.chartRight.Gain = 3;
            this.chartRight.Location = new System.Drawing.Point(0, 0);
            this.chartRight.Margin = new System.Windows.Forms.Padding(0);
            this.chartRight.Name = "chartRight";
            this.chartRight.Size = new System.Drawing.Size(690, 510);
            this.chartRight.TabIndex = 2;
            this.chartRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartRight_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像参数ToolStripMenuItem,
            this.控制参数ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 图像参数ToolStripMenuItem
            // 
            this.图像参数ToolStripMenuItem.Name = "图像参数ToolStripMenuItem";
            this.图像参数ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.图像参数ToolStripMenuItem.Text = "图像参数";
            this.图像参数ToolStripMenuItem.Click += new System.EventHandler(this.图像参数ToolStripMenuItem_Click);
            // 
            // 控制参数ToolStripMenuItem
            // 
            this.控制参数ToolStripMenuItem.Name = "控制参数ToolStripMenuItem";
            this.控制参数ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.控制参数ToolStripMenuItem.Text = "控制参数";
            this.控制参数ToolStripMenuItem.Click += new System.EventHandler(this.控制参数ToolStripMenuItem_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 616);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.SideTable);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ChartForm_SizeChanged);
            this.Click += new System.EventHandler(this.ChartForm_Click);
            this.SideTable.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.OpenFileDialog openXtfFileDialog;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private System.Windows.Forms.TableLayoutPanel SideTable;
        private System.Windows.Forms.Panel panel1;
        private ChartBox.ChartG chartLeft;
        private ChartBox.WaveBox waveLeft;
        private ChartBox.WaveBox waveRight;
        private System.Windows.Forms.Panel panel2;
        private ChartBox.ChartG chartRight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 图像参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 控制参数ToolStripMenuItem;
    }
}

