namespace Demo
{
    partial class WizardForm
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
            this.SurveyWizard = new DevComponents.DotNetBar.Wizard();
            this.NamePage = new DevComponents.DotNetBar.WizardPage();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SolutionName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wizardPage1 = new DevComponents.DotNetBar.WizardPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PrefixBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BothRd = new System.Windows.Forms.RadioButton();
            this.OnlyResultRd = new System.Windows.Forms.RadioButton();
            this.OnlyRawRd = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.StoreInteval = new DevComponents.Editors.IntegerInput();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SelPath = new DevComponents.DotNetBar.ButtonX();
            this.SelectPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.wizardPage2 = new DevComponents.DotNetBar.WizardPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SelectTargetBtn = new DevComponents.DotNetBar.ButtonX();
            this.TargetCatalogFileBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.wizardPage5 = new DevComponents.DotNetBar.WizardPage();
            this.NewRd = new System.Windows.Forms.RadioButton();
            this.ExitRd = new System.Windows.Forms.RadioButton();
            this.groupBoxNew = new System.Windows.Forms.GroupBox();
            this.NewRouteFileBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBoxExit = new System.Windows.Forms.GroupBox();
            this.SelectRouteBtn = new DevComponents.DotNetBar.ButtonX();
            this.SelectRouteFileBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.wizardPage6 = new DevComponents.DotNetBar.WizardPage();
            this.SaveStateCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.StateFileBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.wizardPage7 = new DevComponents.DotNetBar.WizardPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.PressOffsetBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PressScaleBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PressSensorCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.wizardPage8 = new DevComponents.DotNetBar.WizardPage();
            this.WizardSummaryBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SurveyWizard.SuspendLayout();
            this.NamePage.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StoreInteval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.wizardPage5.SuspendLayout();
            this.groupBoxNew.SuspendLayout();
            this.groupBoxExit.SuspendLayout();
            this.wizardPage6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.wizardPage7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.wizardPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // SurveyWizard
            // 
            this.SurveyWizard.BackButtonText = "< 后退";
            this.SurveyWizard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))));
            this.SurveyWizard.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007;
            this.SurveyWizard.CancelButtonText = "取消";
            this.SurveyWizard.Cursor = System.Windows.Forms.Cursors.Default;
            this.SurveyWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SurveyWizard.FinishButtonTabIndex = 3;
            this.SurveyWizard.FinishButtonText = "完成";
            // 
            // 
            // 
            this.SurveyWizard.FooterStyle.BackColor = System.Drawing.Color.Transparent;
            this.SurveyWizard.FooterStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SurveyWizard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(57)))), ((int)(((byte)(129)))));
            this.SurveyWizard.HeaderCaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.SurveyWizard.HeaderDescriptionFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SurveyWizard.HeaderDescriptionIndent = 16;
            this.SurveyWizard.HeaderHeight = 90;
            // 
            // 
            // 
            this.SurveyWizard.HeaderStyle.BackColor = System.Drawing.Color.Transparent;
            this.SurveyWizard.HeaderStyle.BackColorGradientAngle = 90;
            this.SurveyWizard.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.SurveyWizard.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(157)))), ((int)(((byte)(182)))));
            this.SurveyWizard.HeaderStyle.BorderBottomWidth = 1;
            this.SurveyWizard.HeaderStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SurveyWizard.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.SurveyWizard.HelpButtonVisible = false;
            this.SurveyWizard.Location = new System.Drawing.Point(0, 0);
            this.SurveyWizard.Name = "SurveyWizard";
            this.SurveyWizard.NextButtonText = "下一步 >";
            this.SurveyWizard.Size = new System.Drawing.Size(503, 319);
            this.SurveyWizard.TabIndex = 0;
            this.SurveyWizard.WizardPages.AddRange(new DevComponents.DotNetBar.WizardPage[] {
            this.NamePage,
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage5,
            this.wizardPage6,
            this.wizardPage7,
            this.wizardPage8});
            // 
            // NamePage
            // 
            this.NamePage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NamePage.BackColor = System.Drawing.Color.Transparent;
            this.NamePage.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.NamePage.Controls.Add(this.labelX1);
            this.NamePage.Controls.Add(this.SolutionName);
            this.NamePage.Controls.Add(this.label1);
            this.NamePage.Controls.Add(this.label2);
            this.NamePage.Controls.Add(this.label3);
            this.NamePage.InteriorPage = false;
            this.NamePage.Location = new System.Drawing.Point(0, 0);
            this.NamePage.Name = "NamePage";
            this.NamePage.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False;
            this.NamePage.Size = new System.Drawing.Size(503, 273);
            // 
            // 
            // 
            this.NamePage.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.NamePage.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.NamePage.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NamePage.TabIndex = 8;
            this.NamePage.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.NamePage_NextButtonClick);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(212, 182);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(69, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "任务名称";
            // 
            // SolutionName
            // 
            // 
            // 
            // 
            this.SolutionName.Border.Class = "TextBoxBorder";
            this.SolutionName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SolutionName.Location = new System.Drawing.Point(287, 182);
            this.SolutionName.Name = "SolutionName";
            this.SolutionName.Size = new System.Drawing.Size(188, 21);
            this.SolutionName.TabIndex = 3;
            this.SolutionName.TextChanged += new System.EventHandler(this.SolutionName_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎来到任务设置向导";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(210, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 157);
            this.label2.TabIndex = 1;
            this.label2.Text = "本向导将引导您设置BSS Sonar Processing System\r\n\r\n请输入本次任务的名称\r\n";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(210, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "继续点击Next。";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage1.AntiAlias = false;
            this.wizardPage1.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage1.Controls.Add(this.groupBox2);
            this.wizardPage1.Controls.Add(this.groupBox4);
            this.wizardPage1.Controls.Add(this.groupBox3);
            this.wizardPage1.Controls.Add(this.groupBox1);
            this.wizardPage1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wizardPage1.Location = new System.Drawing.Point(7, 102);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.PageDescription = "数据将保存在选定路径下的任务名称文件夹中";
            this.wizardPage1.PageTitle = "数据保存路径";
            this.wizardPage1.Size = new System.Drawing.Size(489, 159);
            // 
            // 
            // 
            this.wizardPage1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage1.TabIndex = 7;
            this.wizardPage1.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.wizardPage1_NextButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.PrefixBox);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 64);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件名前缀";
            // 
            // PrefixBox
            // 
            // 
            // 
            // 
            this.PrefixBox.Border.Class = "TextBoxBorder";
            this.PrefixBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PrefixBox.Location = new System.Drawing.Point(6, 22);
            this.PrefixBox.Name = "PrefixBox";
            this.PrefixBox.Size = new System.Drawing.Size(99, 23);
            this.PrefixBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.BothRd);
            this.groupBox4.Controls.Add(this.OnlyResultRd);
            this.groupBox4.Controls.Add(this.OnlyRawRd);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(337, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(152, 84);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "保存选项";
            // 
            // BothRd
            // 
            this.BothRd.AutoSize = true;
            this.BothRd.Location = new System.Drawing.Point(15, 60);
            this.BothRd.Name = "BothRd";
            this.BothRd.Size = new System.Drawing.Size(50, 21);
            this.BothRd.TabIndex = 2;
            this.BothRd.TabStop = true;
            this.BothRd.Text = "全部";
            this.BothRd.UseVisualStyleBackColor = true;
            // 
            // OnlyResultRd
            // 
            this.OnlyResultRd.AutoSize = true;
            this.OnlyResultRd.Location = new System.Drawing.Point(15, 39);
            this.OnlyResultRd.Name = "OnlyResultRd";
            this.OnlyResultRd.Size = new System.Drawing.Size(86, 21);
            this.OnlyResultRd.TabIndex = 1;
            this.OnlyResultRd.TabStop = true;
            this.OnlyResultRd.Text = "仅结果数据";
            this.OnlyResultRd.UseVisualStyleBackColor = true;
            // 
            // OnlyRawRd
            // 
            this.OnlyRawRd.AutoSize = true;
            this.OnlyRawRd.Checked = true;
            this.OnlyRawRd.Location = new System.Drawing.Point(15, 18);
            this.OnlyRawRd.Name = "OnlyRawRd";
            this.OnlyRawRd.Size = new System.Drawing.Size(86, 21);
            this.OnlyRawRd.TabIndex = 0;
            this.OnlyRawRd.TabStop = true;
            this.OnlyRawRd.Text = "仅原始数据";
            this.OnlyRawRd.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.StoreInteval);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(134, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据保存间隔";
            // 
            // StoreInteval
            // 
            // 
            // 
            // 
            this.StoreInteval.BackgroundStyle.Class = "DateTimeInputBackground";
            this.StoreInteval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StoreInteval.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.StoreInteval.Location = new System.Drawing.Point(54, 22);
            this.StoreInteval.MaxValue = 10000;
            this.StoreInteval.MinValue = 1;
            this.StoreInteval.Name = "StoreInteval";
            this.StoreInteval.ShowUpDown = true;
            this.StoreInteval.Size = new System.Drawing.Size(53, 23);
            this.StoreInteval.TabIndex = 3;
            this.StoreInteval.Value = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "分钟保存";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "每";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelPath);
            this.groupBox1.Controls.Add(this.SelectPath);
            this.groupBox1.Location = new System.Drawing.Point(-7, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择路径";
            // 
            // SelPath
            // 
            this.SelPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SelPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.SelPath.Location = new System.Drawing.Point(459, 26);
            this.SelPath.Name = "SelPath";
            this.SelPath.Size = new System.Drawing.Size(34, 23);
            this.SelPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SelPath.TabIndex = 1;
            this.SelPath.Text = "...";
            // 
            // SelectPath
            // 
            // 
            // 
            // 
            this.SelectPath.Border.Class = "TextBoxBorder";
            this.SelectPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SelectPath.Location = new System.Drawing.Point(12, 25);
            this.SelectPath.Name = "SelectPath";
            this.SelectPath.ReadOnly = true;
            this.SelectPath.Size = new System.Drawing.Size(440, 26);
            this.SelectPath.TabIndex = 0;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage2.AntiAlias = false;
            this.wizardPage2.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage2.Controls.Add(this.groupBox5);
            this.wizardPage2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wizardPage2.Location = new System.Drawing.Point(7, 102);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.PageDescription = "可以为目标数据选定存放文件名称";
            this.wizardPage2.PageTitle = "目标数据目录选择";
            this.wizardPage2.Size = new System.Drawing.Size(489, 159);
            // 
            // 
            // 
            this.wizardPage2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage2.TabIndex = 11;
            this.wizardPage2.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.wizardPage2_NextButtonClick);
            this.wizardPage2.Enter += new System.EventHandler(this.wizardPage2_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.SelectTargetBtn);
            this.groupBox5.Controls.Add(this.TargetCatalogFileBox);
            this.groupBox5.Location = new System.Drawing.Point(6, 17);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(478, 77);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "目标数据存放目录选择";
            // 
            // SelectTargetBtn
            // 
            this.SelectTargetBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SelectTargetBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.SelectTargetBtn.Location = new System.Drawing.Point(426, 26);
            this.SelectTargetBtn.Name = "SelectTargetBtn";
            this.SelectTargetBtn.Size = new System.Drawing.Size(35, 23);
            this.SelectTargetBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SelectTargetBtn.TabIndex = 1;
            this.SelectTargetBtn.Text = "...";
            // 
            // TargetCatalogFileBox
            // 
            // 
            // 
            // 
            this.TargetCatalogFileBox.Border.Class = "TextBoxBorder";
            this.TargetCatalogFileBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TargetCatalogFileBox.Location = new System.Drawing.Point(6, 25);
            this.TargetCatalogFileBox.Name = "TargetCatalogFileBox";
            this.TargetCatalogFileBox.Size = new System.Drawing.Size(413, 26);
            this.TargetCatalogFileBox.TabIndex = 0;
            // 
            // wizardPage5
            // 
            this.wizardPage5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage5.AntiAlias = false;
            this.wizardPage5.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage5.Controls.Add(this.NewRd);
            this.wizardPage5.Controls.Add(this.ExitRd);
            this.wizardPage5.Controls.Add(this.groupBoxNew);
            this.wizardPage5.Controls.Add(this.groupBoxExit);
            this.wizardPage5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wizardPage5.Location = new System.Drawing.Point(7, 102);
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.PageDescription = "选择或新建本次任务的路径图";
            this.wizardPage5.PageTitle = "调查任务路径图";
            this.wizardPage5.Size = new System.Drawing.Size(489, 159);
            // 
            // 
            // 
            this.wizardPage5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage5.TabIndex = 12;
            this.wizardPage5.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.wizardPage5_NextButtonClick);
            this.wizardPage5.Enter += new System.EventHandler(this.wizardPage5_Enter);
            // 
            // NewRd
            // 
            this.NewRd.AutoSize = true;
            this.NewRd.Location = new System.Drawing.Point(76, -4);
            this.NewRd.Name = "NewRd";
            this.NewRd.Size = new System.Drawing.Size(50, 21);
            this.NewRd.TabIndex = 3;
            this.NewRd.TabStop = true;
            this.NewRd.Text = "新建";
            this.NewRd.UseVisualStyleBackColor = true;
            this.NewRd.Click += new System.EventHandler(this.NewRd_Click);
            // 
            // ExitRd
            // 
            this.ExitRd.AutoSize = true;
            this.ExitRd.Location = new System.Drawing.Point(15, -4);
            this.ExitRd.Name = "ExitRd";
            this.ExitRd.Size = new System.Drawing.Size(50, 21);
            this.ExitRd.TabIndex = 2;
            this.ExitRd.TabStop = true;
            this.ExitRd.Text = "选择";
            this.ExitRd.UseVisualStyleBackColor = true;
            this.ExitRd.Click += new System.EventHandler(this.ExitRd_Click);
            // 
            // groupBoxNew
            // 
            this.groupBoxNew.Controls.Add(this.NewRouteFileBox);
            this.groupBoxNew.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxNew.Location = new System.Drawing.Point(8, 84);
            this.groupBoxNew.Name = "groupBoxNew";
            this.groupBoxNew.Size = new System.Drawing.Size(481, 73);
            this.groupBoxNew.TabIndex = 1;
            this.groupBoxNew.TabStop = false;
            this.groupBoxNew.Text = "新建路径文件";
            // 
            // NewRouteFileBox
            // 
            // 
            // 
            // 
            this.NewRouteFileBox.Border.Class = "TextBoxBorder";
            this.NewRouteFileBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NewRouteFileBox.Location = new System.Drawing.Point(7, 25);
            this.NewRouteFileBox.Name = "NewRouteFileBox";
            this.NewRouteFileBox.Size = new System.Drawing.Size(411, 26);
            this.NewRouteFileBox.TabIndex = 1;
            // 
            // groupBoxExit
            // 
            this.groupBoxExit.Controls.Add(this.SelectRouteBtn);
            this.groupBoxExit.Controls.Add(this.SelectRouteFileBox);
            this.groupBoxExit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxExit.Location = new System.Drawing.Point(8, 18);
            this.groupBoxExit.Name = "groupBoxExit";
            this.groupBoxExit.Size = new System.Drawing.Size(481, 65);
            this.groupBoxExit.TabIndex = 0;
            this.groupBoxExit.TabStop = false;
            this.groupBoxExit.Text = "选择路径文件";
            // 
            // SelectRouteBtn
            // 
            this.SelectRouteBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SelectRouteBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.SelectRouteBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectRouteBtn.Location = new System.Drawing.Point(425, 21);
            this.SelectRouteBtn.Name = "SelectRouteBtn";
            this.SelectRouteBtn.Size = new System.Drawing.Size(30, 23);
            this.SelectRouteBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SelectRouteBtn.TabIndex = 1;
            this.SelectRouteBtn.Text = "...";
            // 
            // SelectRouteFileBox
            // 
            // 
            // 
            // 
            this.SelectRouteFileBox.Border.Class = "TextBoxBorder";
            this.SelectRouteFileBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SelectRouteFileBox.Location = new System.Drawing.Point(7, 21);
            this.SelectRouteFileBox.Name = "SelectRouteFileBox";
            this.SelectRouteFileBox.Size = new System.Drawing.Size(411, 26);
            this.SelectRouteFileBox.TabIndex = 0;
            // 
            // wizardPage6
            // 
            this.wizardPage6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage6.AntiAlias = false;
            this.wizardPage6.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage6.Controls.Add(this.SaveStateCheck);
            this.wizardPage6.Controls.Add(this.groupBox8);
            this.wizardPage6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wizardPage6.Location = new System.Drawing.Point(7, 102);
            this.wizardPage6.Name = "wizardPage6";
            this.wizardPage6.PageDescription = "状态文件用于保存应用程序的所有状态设置";
            this.wizardPage6.PageTitle = "声纳状态文件名";
            this.wizardPage6.Size = new System.Drawing.Size(489, 159);
            // 
            // 
            // 
            this.wizardPage6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage6.TabIndex = 13;
            this.wizardPage6.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.wizardPage6_NextButtonClick);
            // 
            // SaveStateCheck
            // 
            // 
            // 
            // 
            this.SaveStateCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SaveStateCheck.Location = new System.Drawing.Point(196, 77);
            this.SaveStateCheck.Name = "SaveStateCheck";
            this.SaveStateCheck.Size = new System.Drawing.Size(269, 23);
            this.SaveStateCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SaveStateCheck.TabIndex = 1;
            this.SaveStateCheck.Text = "在向导完成时保存状态数据";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.StateFileBox);
            this.groupBox8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox8.Location = new System.Drawing.Point(0, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(486, 67);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "状态文件路径";
            // 
            // StateFileBox
            // 
            // 
            // 
            // 
            this.StateFileBox.Border.Class = "TextBoxBorder";
            this.StateFileBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StateFileBox.Location = new System.Drawing.Point(7, 26);
            this.StateFileBox.Name = "StateFileBox";
            this.StateFileBox.Size = new System.Drawing.Size(458, 26);
            this.StateFileBox.TabIndex = 0;
            // 
            // wizardPage7
            // 
            this.wizardPage7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage7.AntiAlias = false;
            this.wizardPage7.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage7.Controls.Add(this.groupBox9);
            this.wizardPage7.Controls.Add(this.PressSensorCheck);
            this.wizardPage7.Location = new System.Drawing.Point(7, 102);
            this.wizardPage7.Name = "wizardPage7";
            this.wizardPage7.PageDescription = "选择压力传感器并设置参数";
            this.wizardPage7.PageTitle = "压力传感器参数设置";
            this.wizardPage7.Size = new System.Drawing.Size(489, 159);
            // 
            // 
            // 
            this.wizardPage7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage7.TabIndex = 14;
            this.wizardPage7.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.wizardPage7_NextButtonClick);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.PressOffsetBox);
            this.groupBox9.Controls.Add(this.PressScaleBox);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Location = new System.Drawing.Point(22, 33);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(402, 100);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "设置";
            // 
            // PressOffsetBox
            // 
            // 
            // 
            // 
            this.PressOffsetBox.Border.Class = "TextBoxBorder";
            this.PressOffsetBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PressOffsetBox.Location = new System.Drawing.Point(272, 39);
            this.PressOffsetBox.Name = "PressOffsetBox";
            this.PressOffsetBox.Size = new System.Drawing.Size(100, 21);
            this.PressOffsetBox.TabIndex = 3;
            // 
            // PressScaleBox
            // 
            // 
            // 
            // 
            this.PressScaleBox.Border.Class = "TextBoxBorder";
            this.PressScaleBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PressScaleBox.Location = new System.Drawing.Point(65, 39);
            this.PressScaleBox.Name = "PressScaleBox";
            this.PressScaleBox.Size = new System.Drawing.Size(100, 21);
            this.PressScaleBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "偏移值";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "比例因子";
            // 
            // PressSensorCheck
            // 
            // 
            // 
            // 
            this.PressSensorCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PressSensorCheck.Location = new System.Drawing.Point(22, 4);
            this.PressSensorCheck.Name = "PressSensorCheck";
            this.PressSensorCheck.Size = new System.Drawing.Size(200, 23);
            this.PressSensorCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PressSensorCheck.TabIndex = 0;
            this.PressSensorCheck.Text = "使用压力传感器";
            // 
            // wizardPage8
            // 
            this.wizardPage8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage8.AntiAlias = false;
            this.wizardPage8.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage8.Controls.Add(this.WizardSummaryBox);
            this.wizardPage8.Controls.Add(this.label4);
            this.wizardPage8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wizardPage8.InteriorPage = false;
            this.wizardPage8.Location = new System.Drawing.Point(0, 0);
            this.wizardPage8.Name = "wizardPage8";
            this.wizardPage8.Size = new System.Drawing.Size(503, 273);
            // 
            // 
            // 
            this.wizardPage8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage8.TabIndex = 15;
            this.wizardPage8.Enter += new System.EventHandler(this.wizardPage8_Enter);
            // 
            // WizardSummaryBox
            // 
            // 
            // 
            // 
            this.WizardSummaryBox.Border.Class = "TextBoxBorder";
            this.WizardSummaryBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WizardSummaryBox.Location = new System.Drawing.Point(16, 52);
            this.WizardSummaryBox.Multiline = true;
            this.WizardSummaryBox.Name = "WizardSummaryBox";
            this.WizardSummaryBox.ReadOnly = true;
            this.WizardSummaryBox.Size = new System.Drawing.Size(463, 208);
            this.WizardSummaryBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "本次运行设置向导总结";
            // 
            // WizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 319);
            this.Controls.Add(this.SurveyWizard);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置向导";
            this.SurveyWizard.ResumeLayout(false);
            this.NamePage.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StoreInteval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.wizardPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.wizardPage5.ResumeLayout(false);
            this.wizardPage5.PerformLayout();
            this.groupBoxNew.ResumeLayout(false);
            this.groupBoxExit.ResumeLayout(false);
            this.wizardPage6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.wizardPage7.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.wizardPage8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Wizard SurveyWizard;
        private DevComponents.DotNetBar.WizardPage NamePage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.WizardPage wizardPage2;
        private DevComponents.DotNetBar.WizardPage wizardPage1;
        private DevComponents.DotNetBar.WizardPage wizardPage5;
        private DevComponents.DotNetBar.WizardPage wizardPage6;
        private DevComponents.DotNetBar.WizardPage wizardPage7;
        private DevComponents.DotNetBar.WizardPage wizardPage8;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX SolutionName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton BothRd;
        private System.Windows.Forms.RadioButton OnlyResultRd;
        private System.Windows.Forms.RadioButton OnlyRawRd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX SelPath;
        private DevComponents.DotNetBar.Controls.TextBoxX SelectPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.TextBoxX PrefixBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevComponents.DotNetBar.ButtonX SelectTargetBtn;
        private DevComponents.DotNetBar.Controls.TextBoxX TargetCatalogFileBox;
        private System.Windows.Forms.GroupBox groupBoxNew;
        private System.Windows.Forms.GroupBox groupBoxExit;
        private DevComponents.DotNetBar.Controls.TextBoxX NewRouteFileBox;
        private DevComponents.DotNetBar.ButtonX SelectRouteBtn;
        private DevComponents.DotNetBar.Controls.TextBoxX SelectRouteFileBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private DevComponents.DotNetBar.Controls.TextBoxX StateFileBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevComponents.DotNetBar.Controls.CheckBoxX SaveStateCheck;
        private DevComponents.DotNetBar.Controls.TextBoxX WizardSummaryBox;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.CheckBoxX PressSensorCheck;
        private DevComponents.DotNetBar.Controls.TextBoxX PressOffsetBox;
        private DevComponents.DotNetBar.Controls.TextBoxX PressScaleBox;
        private DevComponents.Editors.IntegerInput StoreInteval;
        private System.Windows.Forms.RadioButton NewRd;
        private System.Windows.Forms.RadioButton ExitRd;
    }
}