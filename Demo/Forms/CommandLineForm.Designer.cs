namespace Survey.Forms
{
    partial class CommandLineForm
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
            this.CommandBox = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.AnsBox = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // CommandBox
            // 
            // 
            // 
            // 
            this.CommandBox.BackgroundStyle.Class = "RichTextBoxBorder";
            this.CommandBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CommandBox.Location = new System.Drawing.Point(12, 12);
            this.CommandBox.Name = "CommandBox";
            this.CommandBox.ReadOnly = true;
            this.CommandBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.CommandBox.Size = new System.Drawing.Size(348, 72);
            this.CommandBox.TabIndex = 0;
            // 
            // AnsBox
            // 
            // 
            // 
            // 
            this.AnsBox.BackgroundStyle.Class = "RichTextBoxBorder";
            this.AnsBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.AnsBox.Location = new System.Drawing.Point(12, 104);
            this.AnsBox.Name = "AnsBox";
            this.AnsBox.ReadOnly = true;
            this.AnsBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.AnsBox.Size = new System.Drawing.Size(348, 164);
            this.AnsBox.TabIndex = 1;
            // 
            // CommandLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 287);
            this.Controls.Add(this.AnsBox);
            this.Controls.Add(this.CommandBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandLineForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "命令";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandLineForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.RichTextBoxEx CommandBox;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx AnsBox;
    }
}