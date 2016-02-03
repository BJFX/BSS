namespace Demo.Forms
{
    partial class ConnectForm
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.TPUAddress = new DevComponents.Editors.IpAddressInput();
            this.label1 = new System.Windows.Forms.Label();
            this.MasterRad = new System.Windows.Forms.RadioButton();
            this.SlaveRad = new System.Windows.Forms.RadioButton();
            this.ConfirmBtn = new DevComponents.DotNetBar.ButtonX();
            this.CancelBtn = new DevComponents.DotNetBar.ButtonX();
            this.ModifySonarSetup = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.StartWizard = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TPUAddress)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.TPUAddress);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Location = new System.Drawing.Point(12, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(272, 100);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "网络地址设置";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.SlaveRad);
            this.groupPanel2.Controls.Add(this.MasterRad);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(290, 12);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(135, 100);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "连接模式";
            // 
            // TPUAddress
            // 
            this.TPUAddress.AutoOverwrite = true;
            // 
            // 
            // 
            this.TPUAddress.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TPUAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TPUAddress.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TPUAddress.ButtonFreeText.Visible = true;
            this.TPUAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TPUAddress.Location = new System.Drawing.Point(122, 19);
            this.TPUAddress.Name = "TPUAddress";
            this.TPUAddress.Size = new System.Drawing.Size(141, 29);
            this.TPUAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TPUAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "TPU连接地址";
            // 
            // MasterRad
            // 
            this.MasterRad.AutoSize = true;
            this.MasterRad.Location = new System.Drawing.Point(16, 4);
            this.MasterRad.Name = "MasterRad";
            this.MasterRad.Size = new System.Drawing.Size(47, 16);
            this.MasterRad.TabIndex = 0;
            this.MasterRad.TabStop = true;
            this.MasterRad.Text = "主机";
            this.MasterRad.UseVisualStyleBackColor = true;
            // 
            // SlaveRad
            // 
            this.SlaveRad.AutoSize = true;
            this.SlaveRad.Location = new System.Drawing.Point(16, 32);
            this.SlaveRad.Name = "SlaveRad";
            this.SlaveRad.Size = new System.Drawing.Size(47, 16);
            this.SlaveRad.TabIndex = 1;
            this.SlaveRad.TabStop = true;
            this.SlaveRad.Text = "从机";
            this.SlaveRad.UseVisualStyleBackColor = true;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ConfirmBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ConfirmBtn.Location = new System.Drawing.Point(268, 226);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ConfirmBtn.TabIndex = 2;
            this.ConfirmBtn.Text = "确定";
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(349, 226);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ModifySonarSetup
            // 
            this.ModifySonarSetup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ModifySonarSetup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ModifySonarSetup.Location = new System.Drawing.Point(155, 226);
            this.ModifySonarSetup.Name = "ModifySonarSetup";
            this.ModifySonarSetup.Size = new System.Drawing.Size(107, 23);
            this.ModifySonarSetup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ModifySonarSetup.TabIndex = 4;
            this.ModifySonarSetup.Text = "修改声纳参数";
            this.ModifySonarSetup.Click += new System.EventHandler(this.ModifySonarSetup_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.StartWizard);
            this.groupPanel3.Controls.Add(this.label2);
            this.groupPanel3.Location = new System.Drawing.Point(12, 120);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(412, 88);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 5;
            this.groupPanel3.Text = "设置向导";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "sonard wizard is an optional procedure which can be used to setup the sonar surve" +
    "y parameters";
            // 
            // StartWizard
            // 
            this.StartWizard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.StartWizard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.StartWizard.Location = new System.Drawing.Point(317, 38);
            this.StartWizard.Name = "StartWizard";
            this.StartWizard.Size = new System.Drawing.Size(75, 23);
            this.StartWizard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.StartWizard.TabIndex = 1;
            this.StartWizard.Text = "运行向导";
            this.StartWizard.Click += new System.EventHandler(this.StartWizard_Click);
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.ConfirmBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(436, 261);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.ModifySonarSetup);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TPU Connection";
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TPUAddress)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.IpAddressInput TPUAddress;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.RadioButton SlaveRad;
        private System.Windows.Forms.RadioButton MasterRad;
        private DevComponents.DotNetBar.ButtonX ConfirmBtn;
        private DevComponents.DotNetBar.ButtonX CancelBtn;
        private DevComponents.DotNetBar.ButtonX ModifySonarSetup;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX StartWizard;
        private System.Windows.Forms.Label label2;
    }
}