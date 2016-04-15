namespace Survey.Forms
{
    partial class SensorOptionForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AltiChk = new System.Windows.Forms.CheckBox();
            this.DepthChk = new System.Windows.Forms.CheckBox();
            this.SpeedChk = new System.Windows.Forms.CheckBox();
            this.TempChk = new System.Windows.Forms.CheckBox();
            this.PressureChk = new System.Windows.Forms.CheckBox();
            this.RollChk = new System.Windows.Forms.CheckBox();
            this.PitchChk = new System.Windows.Forms.CheckBox();
            this.HeadingChk = new System.Windows.Forms.CheckBox();
            this.ConfirmBtn = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AltiChk);
            this.groupBox1.Controls.Add(this.DepthChk);
            this.groupBox1.Controls.Add(this.SpeedChk);
            this.groupBox1.Controls.Add(this.TempChk);
            this.groupBox1.Controls.Add(this.PressureChk);
            this.groupBox1.Controls.Add(this.RollChk);
            this.groupBox1.Controls.Add(this.PitchChk);
            this.groupBox1.Controls.Add(this.HeadingChk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据显示";
            // 
            // AltiChk
            // 
            this.AltiChk.AutoSize = true;
            this.AltiChk.Location = new System.Drawing.Point(180, 164);
            this.AltiChk.Name = "AltiChk";
            this.AltiChk.Size = new System.Drawing.Size(48, 16);
            this.AltiChk.TabIndex = 7;
            this.AltiChk.Text = "底深";
            this.AltiChk.UseVisualStyleBackColor = true;
            // 
            // DepthChk
            // 
            this.DepthChk.AutoSize = true;
            this.DepthChk.Location = new System.Drawing.Point(180, 121);
            this.DepthChk.Name = "DepthChk";
            this.DepthChk.Size = new System.Drawing.Size(72, 16);
            this.DepthChk.TabIndex = 6;
            this.DepthChk.Text = "拖体深度";
            this.DepthChk.UseVisualStyleBackColor = true;
            // 
            // SpeedChk
            // 
            this.SpeedChk.AutoSize = true;
            this.SpeedChk.Location = new System.Drawing.Point(180, 78);
            this.SpeedChk.Name = "SpeedChk";
            this.SpeedChk.Size = new System.Drawing.Size(48, 16);
            this.SpeedChk.TabIndex = 5;
            this.SpeedChk.Text = "航速";
            this.SpeedChk.UseVisualStyleBackColor = true;
            // 
            // TempChk
            // 
            this.TempChk.AutoSize = true;
            this.TempChk.Location = new System.Drawing.Point(180, 35);
            this.TempChk.Name = "TempChk";
            this.TempChk.Size = new System.Drawing.Size(48, 16);
            this.TempChk.TabIndex = 4;
            this.TempChk.Text = "温度";
            this.TempChk.UseVisualStyleBackColor = true;
            // 
            // PressureChk
            // 
            this.PressureChk.AutoSize = true;
            this.PressureChk.Location = new System.Drawing.Point(26, 164);
            this.PressureChk.Name = "PressureChk";
            this.PressureChk.Size = new System.Drawing.Size(48, 16);
            this.PressureChk.TabIndex = 3;
            this.PressureChk.Text = "压强";
            this.PressureChk.UseVisualStyleBackColor = true;
            // 
            // RollChk
            // 
            this.RollChk.AutoSize = true;
            this.RollChk.Location = new System.Drawing.Point(26, 121);
            this.RollChk.Name = "RollChk";
            this.RollChk.Size = new System.Drawing.Size(48, 16);
            this.RollChk.TabIndex = 2;
            this.RollChk.Text = "横摇";
            this.RollChk.UseVisualStyleBackColor = true;
            // 
            // PitchChk
            // 
            this.PitchChk.AutoSize = true;
            this.PitchChk.Location = new System.Drawing.Point(26, 78);
            this.PitchChk.Name = "PitchChk";
            this.PitchChk.Size = new System.Drawing.Size(48, 16);
            this.PitchChk.TabIndex = 1;
            this.PitchChk.Text = "纵倾";
            this.PitchChk.UseVisualStyleBackColor = true;
            // 
            // HeadingChk
            // 
            this.HeadingChk.AutoSize = true;
            this.HeadingChk.Location = new System.Drawing.Point(26, 35);
            this.HeadingChk.Name = "HeadingChk";
            this.HeadingChk.Size = new System.Drawing.Size(60, 16);
            this.HeadingChk.TabIndex = 0;
            this.HeadingChk.Text = "艏向角";
            this.HeadingChk.UseVisualStyleBackColor = true;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ConfirmBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ConfirmBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ConfirmBtn.Location = new System.Drawing.Point(312, 199);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ConfirmBtn.TabIndex = 2;
            this.ConfirmBtn.Text = "确定";
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // SensorOptionForm
            // 
            this.AcceptButton = this.ConfirmBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 247);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SensorOptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "传感器数据显示设置";
            this.Load += new System.EventHandler(this.SensorOptionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox RollChk;
        private System.Windows.Forms.CheckBox PitchChk;
        private System.Windows.Forms.CheckBox HeadingChk;
        private System.Windows.Forms.CheckBox AltiChk;
        private System.Windows.Forms.CheckBox DepthChk;
        private System.Windows.Forms.CheckBox SpeedChk;
        private System.Windows.Forms.CheckBox TempChk;
        private System.Windows.Forms.CheckBox PressureChk;
        private DevComponents.DotNetBar.ButtonX ConfirmBtn;
    }
}