namespace Survey.Forms
{
    partial class ParaForm
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
            this.RangeInput = new DevComponents.Editors.IntegerInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.TvbG = new DevComponents.Editors.IntegerInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.PortBandWidth = new DevComponents.Editors.IntegerInput();
            this.StartBandWidth = new DevComponents.Editors.IntegerInput();
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TvbG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortBandWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartBandWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ConfirmBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ConfirmBtn.Location = new System.Drawing.Point(357, 263);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ConfirmBtn.TabIndex = 0;
            this.ConfirmBtn.Text = "确定";
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // RangeInput
            // 
            this.RangeInput.AllowEmptyState = false;
            // 
            // 
            // 
            this.RangeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.RangeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RangeInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.RangeInput.Increment = 10;
            this.RangeInput.Location = new System.Drawing.Point(91, 34);
            this.RangeInput.MaxValue = 1000;
            this.RangeInput.MinValue = 30;
            this.RangeInput.Name = "RangeInput";
            this.RangeInput.ShowUpDown = true;
            this.RangeInput.Size = new System.Drawing.Size(65, 21);
            this.RangeInput.TabIndex = 1;
            this.RangeInput.Value = 50;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "作用距离";
            // 
            // TvbG
            // 
            this.TvbG.AllowEmptyState = false;
            // 
            // 
            // 
            this.TvbG.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TvbG.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TvbG.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TvbG.Increment = 10;
            this.TvbG.Location = new System.Drawing.Point(285, 34);
            this.TvbG.MaxValue = 400;
            this.TvbG.MinValue = -400;
            this.TvbG.Name = "TvbG";
            this.TvbG.ShowUpDown = true;
            this.TvbG.Size = new System.Drawing.Size(65, 21);
            this.TvbG.TabIndex = 1;
            this.TvbG.Value = -200;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(195, 34);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "起始增益";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(13, 94);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(84, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "左舷信号带宽";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(195, 94);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(84, 23);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "右舷信号带宽";
            // 
            // PortBandWidth
            // 
            this.PortBandWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.PortBandWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PortBandWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PortBandWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PortBandWidth.Increment = 10;
            this.PortBandWidth.Location = new System.Drawing.Point(91, 94);
            this.PortBandWidth.MaxValue = 60000;
            this.PortBandWidth.MinValue = 0;
            this.PortBandWidth.Name = "PortBandWidth";
            this.PortBandWidth.ShowUpDown = true;
            this.PortBandWidth.Size = new System.Drawing.Size(99, 21);
            this.PortBandWidth.TabIndex = 1;
            this.PortBandWidth.Value = 30000;
            // 
            // StartBandWidth
            // 
            this.StartBandWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.StartBandWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartBandWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.StartBandWidth.Increment = 10;
            this.StartBandWidth.Location = new System.Drawing.Point(285, 94);
            this.StartBandWidth.MaxValue = 60000;
            this.StartBandWidth.MinValue = 0;
            this.StartBandWidth.Name = "StartBandWidth";
            this.StartBandWidth.ShowUpDown = true;
            this.StartBandWidth.Size = new System.Drawing.Size(93, 21);
            this.StartBandWidth.TabIndex = 1;
            this.StartBandWidth.Value = 30000;
            // 
            // ParaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 287);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.StartBandWidth);
            this.Controls.Add(this.TvbG);
            this.Controls.Add(this.PortBandWidth);
            this.Controls.Add(this.RangeInput);
            this.Controls.Add(this.ConfirmBtn);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParaForm";
            this.Text = "ParaForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParaForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TvbG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortBandWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartBandWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX ConfirmBtn;
        private DevComponents.Editors.IntegerInput RangeInput;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput TvbG;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.IntegerInput PortBandWidth;
        private DevComponents.Editors.IntegerInput StartBandWidth;
    }
}