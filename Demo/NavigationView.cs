using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Demo
{
    public partial class NavigationView : Form
    {
        private MainForm mf;
        public NavigationView(MainForm mainForm)
        {
            mf = mainForm;
            InitializeComponent();
        }

        private void NavigationView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.ChildFormClose(this);
        }
    }
}
