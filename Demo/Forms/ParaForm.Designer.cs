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
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).BeginInit();
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
            this.RangeInput.Location = new System.Drawing.Point(75, 34);
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
            // ParaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 287);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.RangeInput);
            this.Controls.Add(this.ConfirmBtn);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParaForm";
            this.Text = "ParaForm";
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX ConfirmBtn;
        private DevComponents.Editors.IntegerInput RangeInput;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}