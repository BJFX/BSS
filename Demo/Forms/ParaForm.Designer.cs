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
            this.PortCentralFq = new DevComponents.Editors.IntegerInput();
            this.StartCentralFq = new DevComponents.Editors.IntegerInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.PulseLength = new DevComponents.Editors.IntegerInput();
            this.WorkPeriod = new DevComponents.Editors.IntegerInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartBox = new System.Windows.Forms.ComboBox();
            this.PortBox = new System.Windows.Forms.ComboBox();
            this.StartSendEnable = new System.Windows.Forms.CheckBox();
            this.PortSendEnable = new System.Windows.Forms.CheckBox();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SingleWorkValid = new System.Windows.Forms.CheckBox();
            this.CalcTVG = new System.Windows.Forms.CheckBox();
            this.EnableStartBSS = new System.Windows.Forms.CheckBox();
            this.EnablePortBSS = new System.Windows.Forms.CheckBox();
            this.TrigerMode = new System.Windows.Forms.CheckBox();
            this.StartFqBox = new System.Windows.Forms.ComboBox();
            this.PortFqBox = new System.Windows.Forms.ComboBox();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.TVGDelay = new DevComponents.Editors.IntegerInput();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.TvgBeta = new DevComponents.Editors.IntegerInput();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.TvgAlpha = new DevComponents.Editors.IntegerInput();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TvbG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortBandWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartBandWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortCentralFq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartCentralFq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PulseLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkPeriod)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TVGDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TvgBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TvgAlpha)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ConfirmBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ConfirmBtn.Location = new System.Drawing.Point(598, 252);
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
            this.RangeInput.Location = new System.Drawing.Point(112, 10);
            this.RangeInput.MaxValue = 1000;
            this.RangeInput.MinValue = 30;
            this.RangeInput.Name = "RangeInput";
            this.RangeInput.ShowUpDown = true;
            this.RangeInput.Size = new System.Drawing.Size(77, 21);
            this.RangeInput.TabIndex = 1;
            this.RangeInput.Value = 50;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "探测距离";
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
            this.TvbG.Location = new System.Drawing.Point(313, 12);
            this.TvbG.MaxValue = 400;
            this.TvbG.MinValue = -400;
            this.TvbG.Name = "TvbG";
            this.TvbG.ShowUpDown = true;
            this.TvbG.Size = new System.Drawing.Size(76, 21);
            this.TvbG.TabIndex = 1;
            this.TvbG.Value = -200;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(223, 12);
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
            this.labelX3.Location = new System.Drawing.Point(13, 71);
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
            this.labelX4.Location = new System.Drawing.Point(223, 71);
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
            this.PortBandWidth.Location = new System.Drawing.Point(112, 71);
            this.PortBandWidth.MaxValue = 120000;
            this.PortBandWidth.MinValue = 0;
            this.PortBandWidth.Name = "PortBandWidth";
            this.PortBandWidth.ShowUpDown = true;
            this.PortBandWidth.Size = new System.Drawing.Size(77, 21);
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
            this.StartBandWidth.Location = new System.Drawing.Point(313, 71);
            this.StartBandWidth.MaxValue = 120000;
            this.StartBandWidth.MinValue = 0;
            this.StartBandWidth.Name = "StartBandWidth";
            this.StartBandWidth.ShowUpDown = true;
            this.StartBandWidth.Size = new System.Drawing.Size(76, 21);
            this.StartBandWidth.TabIndex = 1;
            this.StartBandWidth.Value = 30000;
            // 
            // PortCentralFq
            // 
            this.PortCentralFq.AllowEmptyState = false;
            // 
            // 
            // 
            this.PortCentralFq.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PortCentralFq.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PortCentralFq.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PortCentralFq.Increment = 10;
            this.PortCentralFq.Location = new System.Drawing.Point(112, 38);
            this.PortCentralFq.MaxValue = 1200000;
            this.PortCentralFq.MinValue = 0;
            this.PortCentralFq.Name = "PortCentralFq";
            this.PortCentralFq.ShowUpDown = true;
            this.PortCentralFq.Size = new System.Drawing.Size(77, 21);
            this.PortCentralFq.TabIndex = 1;
            this.PortCentralFq.Value = 30000;
            // 
            // StartCentralFq
            // 
            this.StartCentralFq.AllowEmptyState = false;
            // 
            // 
            // 
            this.StartCentralFq.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartCentralFq.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.StartCentralFq.Increment = 10;
            this.StartCentralFq.Location = new System.Drawing.Point(313, 39);
            this.StartCentralFq.MaxValue = 1200000;
            this.StartCentralFq.MinValue = 0;
            this.StartCentralFq.Name = "StartCentralFq";
            this.StartCentralFq.ShowUpDown = true;
            this.StartCentralFq.Size = new System.Drawing.Size(76, 21);
            this.StartCentralFq.TabIndex = 1;
            this.StartCentralFq.Value = 30000;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(13, 39);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(84, 23);
            this.labelX5.TabIndex = 3;
            this.labelX5.Text = "左舷中心频率";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(223, 39);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(84, 23);
            this.labelX6.TabIndex = 4;
            this.labelX6.Text = "右舷中心频率";
            // 
            // PulseLength
            // 
            this.PulseLength.AllowEmptyState = false;
            // 
            // 
            // 
            this.PulseLength.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PulseLength.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PulseLength.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PulseLength.Increment = 10;
            this.PulseLength.Location = new System.Drawing.Point(112, 102);
            this.PulseLength.MaxValue = 1000;
            this.PulseLength.MinValue = 2;
            this.PulseLength.Name = "PulseLength";
            this.PulseLength.ShowUpDown = true;
            this.PulseLength.Size = new System.Drawing.Size(77, 21);
            this.PulseLength.TabIndex = 1;
            this.PulseLength.Value = 200;
            // 
            // WorkPeriod
            // 
            this.WorkPeriod.AllowEmptyState = false;
            // 
            // 
            // 
            this.WorkPeriod.BackgroundStyle.Class = "DateTimeInputBackground";
            this.WorkPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WorkPeriod.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.WorkPeriod.Increment = 10;
            this.WorkPeriod.Location = new System.Drawing.Point(313, 104);
            this.WorkPeriod.MaxValue = 20;
            this.WorkPeriod.MinValue = 1;
            this.WorkPeriod.Name = "WorkPeriod";
            this.WorkPeriod.ShowUpDown = true;
            this.WorkPeriod.Size = new System.Drawing.Size(76, 21);
            this.WorkPeriod.TabIndex = 1;
            this.WorkPeriod.Value = 1;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(13, 104);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(56, 23);
            this.labelX7.TabIndex = 2;
            this.labelX7.Text = "脉冲长度";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(223, 104);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(56, 23);
            this.labelX8.TabIndex = 2;
            this.labelX8.Text = "工作周期";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartBox);
            this.groupBox1.Controls.Add(this.PortBox);
            this.groupBox1.Controls.Add(this.StartSendEnable);
            this.groupBox1.Controls.Add(this.PortSendEnable);
            this.groupBox1.Controls.Add(this.labelX14);
            this.groupBox1.Controls.Add(this.labelX13);
            this.groupBox1.Location = new System.Drawing.Point(2, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发射控制标识";
            // 
            // StartBox
            // 
            this.StartBox.FormattingEnabled = true;
            this.StartBox.Items.AddRange(new object[] {
            "12.5",
            "25",
            "37.5",
            "50",
            "62.5",
            "75"});
            this.StartBox.Location = new System.Drawing.Point(233, 47);
            this.StartBox.Name = "StartBox";
            this.StartBox.Size = new System.Drawing.Size(71, 20);
            this.StartBox.TabIndex = 1;
            // 
            // PortBox
            // 
            this.PortBox.FormattingEnabled = true;
            this.PortBox.Items.AddRange(new object[] {
            "12.5",
            "25",
            "37.5",
            "50",
            "62.5",
            "75"});
            this.PortBox.Location = new System.Drawing.Point(233, 22);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(71, 20);
            this.PortBox.TabIndex = 1;
            // 
            // StartSendEnable
            // 
            this.StartSendEnable.AutoSize = true;
            this.StartSendEnable.Checked = true;
            this.StartSendEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StartSendEnable.Location = new System.Drawing.Point(11, 51);
            this.StartSendEnable.Name = "StartSendEnable";
            this.StartSendEnable.Size = new System.Drawing.Size(96, 16);
            this.StartSendEnable.TabIndex = 0;
            this.StartSendEnable.Text = "右舷发射允许";
            this.StartSendEnable.UseVisualStyleBackColor = true;
            // 
            // PortSendEnable
            // 
            this.PortSendEnable.AutoSize = true;
            this.PortSendEnable.Checked = true;
            this.PortSendEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PortSendEnable.Location = new System.Drawing.Point(11, 24);
            this.PortSendEnable.Name = "PortSendEnable";
            this.PortSendEnable.Size = new System.Drawing.Size(96, 16);
            this.PortSendEnable.TabIndex = 0;
            this.PortSendEnable.Text = "左舷发射允许";
            this.PortSendEnable.UseVisualStyleBackColor = true;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(131, 44);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(84, 23);
            this.labelX14.TabIndex = 2;
            this.labelX14.Text = "右舷功率选择";
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(131, 19);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(84, 23);
            this.labelX13.TabIndex = 2;
            this.labelX13.Text = "左舷功率选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SingleWorkValid);
            this.groupBox2.Controls.Add(this.CalcTVG);
            this.groupBox2.Controls.Add(this.EnableStartBSS);
            this.groupBox2.Controls.Add(this.EnablePortBSS);
            this.groupBox2.Controls.Add(this.TrigerMode);
            this.groupBox2.Controls.Add(this.StartFqBox);
            this.groupBox2.Controls.Add(this.PortFqBox);
            this.groupBox2.Controls.Add(this.labelX16);
            this.groupBox2.Controls.Add(this.labelX15);
            this.groupBox2.Location = new System.Drawing.Point(405, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 193);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "命令标识";
            // 
            // SingleWorkValid
            // 
            this.SingleWorkValid.AutoSize = true;
            this.SingleWorkValid.Location = new System.Drawing.Point(6, 174);
            this.SingleWorkValid.Name = "SingleWorkValid";
            this.SingleWorkValid.Size = new System.Drawing.Size(96, 16);
            this.SingleWorkValid.TabIndex = 0;
            this.SingleWorkValid.Text = "单次工作有效";
            this.SingleWorkValid.UseVisualStyleBackColor = true;
            // 
            // CalcTVG
            // 
            this.CalcTVG.AutoSize = true;
            this.CalcTVG.Checked = true;
            this.CalcTVG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CalcTVG.Location = new System.Drawing.Point(6, 152);
            this.CalcTVG.Name = "CalcTVG";
            this.CalcTVG.Size = new System.Drawing.Size(66, 16);
            this.CalcTVG.TabIndex = 0;
            this.CalcTVG.Text = "计算TVG";
            this.CalcTVG.UseVisualStyleBackColor = true;
            // 
            // EnableStartBSS
            // 
            this.EnableStartBSS.AutoSize = true;
            this.EnableStartBSS.Checked = true;
            this.EnableStartBSS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableStartBSS.Location = new System.Drawing.Point(6, 130);
            this.EnableStartBSS.Name = "EnableStartBSS";
            this.EnableStartBSS.Size = new System.Drawing.Size(144, 16);
            this.EnableStartBSS.TabIndex = 0;
            this.EnableStartBSS.Text = "处理右舷侧扫数据允许";
            this.EnableStartBSS.UseVisualStyleBackColor = true;
            // 
            // EnablePortBSS
            // 
            this.EnablePortBSS.AutoSize = true;
            this.EnablePortBSS.Checked = true;
            this.EnablePortBSS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnablePortBSS.Location = new System.Drawing.Point(6, 108);
            this.EnablePortBSS.Name = "EnablePortBSS";
            this.EnablePortBSS.Size = new System.Drawing.Size(144, 16);
            this.EnablePortBSS.TabIndex = 0;
            this.EnablePortBSS.Text = "处理左舷侧扫数据允许";
            this.EnablePortBSS.UseVisualStyleBackColor = true;
            // 
            // TrigerMode
            // 
            this.TrigerMode.AutoSize = true;
            this.TrigerMode.Location = new System.Drawing.Point(7, 28);
            this.TrigerMode.Name = "TrigerMode";
            this.TrigerMode.Size = new System.Drawing.Size(60, 16);
            this.TrigerMode.TabIndex = 0;
            this.TrigerMode.Text = "外触发";
            this.TrigerMode.UseVisualStyleBackColor = true;
            // 
            // StartFqBox
            // 
            this.StartFqBox.FormattingEnabled = true;
            this.StartFqBox.Items.AddRange(new object[] {
            "UP",
            "DOWN"});
            this.StartFqBox.Location = new System.Drawing.Point(109, 82);
            this.StartFqBox.Name = "StartFqBox";
            this.StartFqBox.Size = new System.Drawing.Size(71, 20);
            this.StartFqBox.TabIndex = 1;
            // 
            // PortFqBox
            // 
            this.PortFqBox.FormattingEnabled = true;
            this.PortFqBox.Items.AddRange(new object[] {
            "UP",
            "DOWN"});
            this.PortFqBox.Location = new System.Drawing.Point(109, 53);
            this.PortFqBox.Name = "PortFqBox";
            this.PortFqBox.Size = new System.Drawing.Size(71, 20);
            this.PortFqBox.TabIndex = 1;
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(7, 79);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(84, 23);
            this.labelX16.TabIndex = 2;
            this.labelX16.Text = "右舷调频方向";
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(7, 50);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(84, 23);
            this.labelX15.TabIndex = 2;
            this.labelX15.Text = "左舷调频方向";
            // 
            // TVGDelay
            // 
            this.TVGDelay.AllowEmptyState = false;
            // 
            // 
            // 
            this.TVGDelay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TVGDelay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TVGDelay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TVGDelay.Increment = 10;
            this.TVGDelay.Location = new System.Drawing.Point(67, 212);
            this.TVGDelay.MaxValue = 200;
            this.TVGDelay.MinValue = 0;
            this.TVGDelay.Name = "TVGDelay";
            this.TVGDelay.ShowUpDown = true;
            this.TVGDelay.Size = new System.Drawing.Size(77, 21);
            this.TVGDelay.TabIndex = 1;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(12, 214);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(56, 23);
            this.labelX9.TabIndex = 2;
            this.labelX9.Text = "TVG延时";
            // 
            // TvgBeta
            // 
            this.TvgBeta.AllowEmptyState = false;
            // 
            // 
            // 
            this.TvgBeta.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TvgBeta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TvgBeta.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TvgBeta.Increment = 10;
            this.TvgBeta.Location = new System.Drawing.Point(237, 212);
            this.TvgBeta.MaxValue = 400;
            this.TvgBeta.MinValue = 0;
            this.TvgBeta.Name = "TvgBeta";
            this.TvgBeta.ShowUpDown = true;
            this.TvgBeta.Size = new System.Drawing.Size(77, 21);
            this.TvgBeta.TabIndex = 1;
            this.TvgBeta.Value = 300;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(155, 214);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(76, 23);
            this.labelX10.TabIndex = 2;
            this.labelX10.Text = "TVG比例因子";
            // 
            // TvgAlpha
            // 
            this.TvgAlpha.AllowEmptyState = false;
            // 
            // 
            // 
            this.TvgAlpha.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TvgAlpha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TvgAlpha.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TvgAlpha.Increment = 10;
            this.TvgAlpha.Location = new System.Drawing.Point(412, 212);
            this.TvgAlpha.MaxValue = 60000;
            this.TvgAlpha.MinValue = 0;
            this.TvgAlpha.Name = "TvgAlpha";
            this.TvgAlpha.ShowUpDown = true;
            this.TvgAlpha.Size = new System.Drawing.Size(77, 21);
            this.TvgAlpha.TabIndex = 1;
            this.TvgAlpha.Value = 2600;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(329, 214);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(76, 23);
            this.labelX11.TabIndex = 2;
            this.labelX11.Text = "TVG吸收衰减";
            // 
            // ParaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.StartCentralFq);
            this.Controls.Add(this.labelX11);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.StartBandWidth);
            this.Controls.Add(this.PortCentralFq);
            this.Controls.Add(this.WorkPeriod);
            this.Controls.Add(this.TvbG);
            this.Controls.Add(this.TvgAlpha);
            this.Controls.Add(this.TvgBeta);
            this.Controls.Add(this.TVGDelay);
            this.Controls.Add(this.PortBandWidth);
            this.Controls.Add(this.PulseLength);
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
            ((System.ComponentModel.ISupportInitialize)(this.PortCentralFq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartCentralFq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PulseLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkPeriod)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TVGDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TvgBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TvgAlpha)).EndInit();
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
        private DevComponents.Editors.IntegerInput PortCentralFq;
        private DevComponents.Editors.IntegerInput StartCentralFq;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.IntegerInput PulseLength;
        private DevComponents.Editors.IntegerInput WorkPeriod;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.Editors.IntegerInput TVGDelay;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.Editors.IntegerInput TvgBeta;
        private DevComponents.Editors.IntegerInput TvgAlpha;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX11;
        private System.Windows.Forms.ComboBox StartBox;
        private System.Windows.Forms.ComboBox PortBox;
        private System.Windows.Forms.CheckBox StartSendEnable;
        private System.Windows.Forms.CheckBox PortSendEnable;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX13;
        private System.Windows.Forms.CheckBox EnableStartBSS;
        private System.Windows.Forms.CheckBox EnablePortBSS;
        private System.Windows.Forms.CheckBox TrigerMode;
        private System.Windows.Forms.ComboBox StartFqBox;
        private System.Windows.Forms.ComboBox PortFqBox;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX labelX15;
        private System.Windows.Forms.CheckBox SingleWorkValid;
        private System.Windows.Forms.CheckBox CalcTVG;
    }
}