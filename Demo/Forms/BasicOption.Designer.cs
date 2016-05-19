namespace Survey.Forms
{
    partial class BasicOption
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
            this.ConfirmBtn = new DevComponents.DotNetBar.ButtonX();
            this.GpsPortBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GpsBaudRate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ConfirmBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ConfirmBtn.Location = new System.Drawing.Point(197, 226);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ConfirmBtn.TabIndex = 0;
            this.ConfirmBtn.Text = "确定";
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // GpsPortBox
            // 
            this.GpsPortBox.FormattingEnabled = true;
            this.GpsPortBox.Location = new System.Drawing.Point(83, 24);
            this.GpsPortBox.Name = "GpsPortBox";
            this.GpsPortBox.Size = new System.Drawing.Size(103, 20);
            this.GpsPortBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "GPS端口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率";
            // 
            // GpsBaudRate
            // 
            this.GpsBaudRate.FormattingEnabled = true;
            this.GpsBaudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400"});
            this.GpsBaudRate.Location = new System.Drawing.Point(83, 63);
            this.GpsBaudRate.Name = "GpsBaudRate";
            this.GpsBaudRate.Size = new System.Drawing.Size(103, 20);
            this.GpsBaudRate.TabIndex = 4;
            // 
            // BasicOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.GpsBaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GpsPortBox);
            this.Controls.Add(this.ConfirmBtn);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基本设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BasicOption_FormClosing);
            this.Load += new System.EventHandler(this.BasicOption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX ConfirmBtn;
        private System.Windows.Forms.ComboBox GpsPortBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox GpsBaudRate;
    }
}