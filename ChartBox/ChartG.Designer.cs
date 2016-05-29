namespace ChartBox
{
    partial class ChartG
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GisChart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GisChart)).BeginInit();
            this.SuspendLayout();
            // 
            // GisChart
            // 
            this.GisChart.BackColor = System.Drawing.Color.Black;
            this.GisChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GisChart.Location = new System.Drawing.Point(0, 0);
            this.GisChart.Margin = new System.Windows.Forms.Padding(4);
            this.GisChart.Name = "GisChart";
            this.GisChart.Size = new System.Drawing.Size(761, 494);
            this.GisChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GisChart.TabIndex = 1;
            this.GisChart.TabStop = false;
            this.GisChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GisChart_MouseClick);
            // 
            // ChartG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.GisChart);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChartG";
            this.Size = new System.Drawing.Size(761, 494);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GisChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox GisChart;
    }
}
