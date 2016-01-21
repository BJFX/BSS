namespace Demo
{
    partial class AboutBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DspVersion = new System.Windows.Forms.Label();
            this.DspDate = new System.Windows.Forms.Label();
            this.ProductDate = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.labelCopyright = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.98851F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.01149F));
            this.tableLayoutPanel.Controls.Add(this.DspVersion, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.DspDate, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.ProductDate, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(15, 14);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.71003F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.71003F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.71003F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.71003F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.71003F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.73981F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.71003F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(743, 326);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // DspVersion
            // 
            this.DspVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DspVersion.Location = new System.Drawing.Point(180, 123);
            this.DspVersion.Margin = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.DspVersion.MaximumSize = new System.Drawing.Size(0, 28);
            this.DspVersion.Name = "DspVersion";
            this.DspVersion.Size = new System.Drawing.Size(558, 28);
            this.DspVersion.TabIndex = 27;
            this.DspVersion.Text = "版本";
            this.DspVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DspDate
            // 
            this.DspDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DspDate.Location = new System.Drawing.Point(180, 164);
            this.DspDate.Margin = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.DspDate.MaximumSize = new System.Drawing.Size(0, 28);
            this.DspDate.Name = "DspDate";
            this.DspDate.Size = new System.Drawing.Size(558, 28);
            this.DspDate.TabIndex = 26;
            this.DspDate.Text = "date";
            this.DspDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductDate
            // 
            this.ProductDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductDate.Location = new System.Drawing.Point(180, 82);
            this.ProductDate.Margin = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.ProductDate.MaximumSize = new System.Drawing.Size(0, 28);
            this.ProductDate.Name = "ProductDate";
            this.ProductDate.Size = new System.Drawing.Size(558, 28);
            this.ProductDate.TabIndex = 25;
            this.ProductDate.Text = "date";
            this.ProductDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(5, 5);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 7);
            this.logoPictureBox.Size = new System.Drawing.Size(160, 316);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(180, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 28);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(558, 28);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "产品名称";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(180, 41);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 28);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(558, 28);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "版本";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(613, 287);
            this.okButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(125, 34);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "确定(&O)";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Location = new System.Drawing.Point(175, 210);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelCopyright.Multiline = true;
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.ReadOnly = true;
            this.labelCopyright.Size = new System.Drawing.Size(563, 67);
            this.labelCopyright.TabIndex = 28;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 354);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(15, 14, 15, 14);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About BSS Sonar Software";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label ProductDate;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label DspVersion;
        private System.Windows.Forms.Label DspDate;
        private System.Windows.Forms.TextBox labelCopyright;
    }
}
