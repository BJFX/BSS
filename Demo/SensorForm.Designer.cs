namespace Demo
{
    partial class SensorForm
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
            this.Headinglabel = new System.Windows.Forms.Label();
            this.waveBoxV = new ChartBox.WaveBoxV();
            this.Pitchlabel = new System.Windows.Forms.Label();
            this.Rolllabel = new System.Windows.Forms.Label();
            this.Speedlabel = new System.Windows.Forms.Label();
            this.Altitudelabel = new System.Windows.Forms.Label();
            this.Templabel = new System.Windows.Forms.Label();
            this.Pressurelabel = new System.Windows.Forms.Label();
            this.Depthlabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Headinglabel
            // 
            this.Headinglabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Headinglabel.AutoSize = true;
            this.Headinglabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Headinglabel.Location = new System.Drawing.Point(223, 17);
            this.Headinglabel.Name = "Headinglabel";
            this.Headinglabel.Size = new System.Drawing.Size(31, 21);
            this.Headinglabel.TabIndex = 1;
            this.Headinglabel.Text = "---";
            // 
            // waveBoxV
            // 
            this.waveBoxV.DisplayAmpMax = 180D;
            this.waveBoxV.DisplayCount = 10;
            this.waveBoxV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waveBoxV.Location = new System.Drawing.Point(3, 3);
            this.waveBoxV.Name = "waveBoxV";
            this.tableLayoutPanel1.SetRowSpan(this.waveBoxV, 8);
            this.waveBoxV.Size = new System.Drawing.Size(214, 449);
            this.waveBoxV.TabIndex = 0;
            // 
            // Pitchlabel
            // 
            this.Pitchlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Pitchlabel.AutoSize = true;
            this.Pitchlabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pitchlabel.Location = new System.Drawing.Point(223, 73);
            this.Pitchlabel.Name = "Pitchlabel";
            this.Pitchlabel.Size = new System.Drawing.Size(31, 21);
            this.Pitchlabel.TabIndex = 2;
            this.Pitchlabel.Text = "---";
            // 
            // Rolllabel
            // 
            this.Rolllabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Rolllabel.AutoSize = true;
            this.Rolllabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rolllabel.Location = new System.Drawing.Point(223, 129);
            this.Rolllabel.Name = "Rolllabel";
            this.Rolllabel.Size = new System.Drawing.Size(31, 21);
            this.Rolllabel.TabIndex = 3;
            this.Rolllabel.Text = "---";
            // 
            // Speedlabel
            // 
            this.Speedlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Speedlabel.AutoSize = true;
            this.Speedlabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Speedlabel.Location = new System.Drawing.Point(223, 185);
            this.Speedlabel.Name = "Speedlabel";
            this.Speedlabel.Size = new System.Drawing.Size(31, 21);
            this.Speedlabel.TabIndex = 4;
            this.Speedlabel.Text = "---";
            // 
            // Altitudelabel
            // 
            this.Altitudelabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Altitudelabel.AutoSize = true;
            this.Altitudelabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Altitudelabel.Location = new System.Drawing.Point(223, 241);
            this.Altitudelabel.Name = "Altitudelabel";
            this.Altitudelabel.Size = new System.Drawing.Size(31, 21);
            this.Altitudelabel.TabIndex = 5;
            this.Altitudelabel.Text = "---";
            // 
            // Templabel
            // 
            this.Templabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Templabel.AutoSize = true;
            this.Templabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Templabel.Location = new System.Drawing.Point(223, 297);
            this.Templabel.Name = "Templabel";
            this.Templabel.Size = new System.Drawing.Size(31, 21);
            this.Templabel.TabIndex = 6;
            this.Templabel.Text = "---";
            // 
            // Pressurelabel
            // 
            this.Pressurelabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Pressurelabel.AutoSize = true;
            this.Pressurelabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pressurelabel.Location = new System.Drawing.Point(223, 353);
            this.Pressurelabel.Name = "Pressurelabel";
            this.Pressurelabel.Size = new System.Drawing.Size(31, 21);
            this.Pressurelabel.TabIndex = 7;
            this.Pressurelabel.Text = "---";
            // 
            // Depthlabel
            // 
            this.Depthlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Depthlabel.AutoSize = true;
            this.Depthlabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Depthlabel.Location = new System.Drawing.Point(223, 413);
            this.Depthlabel.Name = "Depthlabel";
            this.Depthlabel.Size = new System.Drawing.Size(31, 21);
            this.Depthlabel.TabIndex = 8;
            this.Depthlabel.Text = "---";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Depthlabel, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.Pressurelabel, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.Templabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Altitudelabel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Speedlabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Rolllabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Pitchlabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.waveBoxV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Headinglabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 455);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 455);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SensorForm";
            this.Text = "数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SensorForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Headinglabel;
        private ChartBox.WaveBoxV waveBoxV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Depthlabel;
        private System.Windows.Forms.Label Pressurelabel;
        private System.Windows.Forms.Label Templabel;
        private System.Windows.Forms.Label Altitudelabel;
        private System.Windows.Forms.Label Speedlabel;
        private System.Windows.Forms.Label Rolllabel;
        private System.Windows.Forms.Label Pitchlabel;



    }
}