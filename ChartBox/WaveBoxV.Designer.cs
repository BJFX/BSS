﻿namespace ChartBox
{
    partial class WaveBoxV
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.WaveSection = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WaveSection)).BeginInit();
            this.SuspendLayout();
            // 
            // WaveSection
            // 
            this.WaveSection.BackColor = System.Drawing.Color.Black;
            this.WaveSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaveSection.Location = new System.Drawing.Point(0, 0);
            this.WaveSection.Margin = new System.Windows.Forms.Padding(0);
            this.WaveSection.Name = "WaveSection";
            this.WaveSection.Size = new System.Drawing.Size(240, 460);
            this.WaveSection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WaveSection.TabIndex = 0;
            this.WaveSection.TabStop = false;
            this.WaveSection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WaveSection_MouseClick);
            // 
            // WaveBoxV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WaveSection);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WaveBoxV";
            this.Size = new System.Drawing.Size(240, 460);
            ((System.ComponentModel.ISupportInitialize)(this.WaveSection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WaveSection;
    }
}
