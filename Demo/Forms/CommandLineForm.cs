using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Survey.Forms
{
    public partial class CommandLineForm : Office2007Form
    {
        private delegate void CMDDelegate(string str);
        private delegate void AnsDelegate(string str);
        public CommandLineForm()
        {
            InitializeComponent();
        }

        public void DisplayCommand(string command)
        {
            if (CommandBox.InvokeRequired)
            {
                CMDDelegate d = new CMDDelegate(DisplayCommand);
                this.Invoke(d, new object[] { command });
            }
            else
            {
                CommandBox.Text = command;
            }
        }
        public void DisplayAns(string ans)
        {
            if (CommandBox.InvokeRequired)
            {
                AnsDelegate d = new AnsDelegate(DisplayAns);
                this.Invoke(d, new object[] { ans });
            }
            else
            {
                CommandBox.Text = ans;
            }
        }
        private void CommandLineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
