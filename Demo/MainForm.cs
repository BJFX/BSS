using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace Demo
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void DataSaveBox_Click(object sender, EventArgs e)
        {
            if (Configuration.bSaveXTF == false)
            {
                DataSaveBox.Text = "正在保存XTF数据";
                DataSaveBox.BackColor = Color.Green;
                Configuration.bSaveXTF = true;
            }
            else
            {
                DataSaveBox.Text = "XTF数据未保存";
                DataSaveBox.BackColor = Color.Red;
                Configuration.bSaveXTF = false;

            }
        }

        private void OpenBssChart_Click(object sender, EventArgs e)
        {

        }



    }
}
