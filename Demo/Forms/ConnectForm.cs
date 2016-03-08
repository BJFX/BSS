using System;
using System.Net;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Survey.Forms
{
    public partial class ConnectForm : Office2007Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Any;
            if (TPUAddress.Value!=null&&IPAddress.TryParse(TPUAddress.Value, out ip))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("无法解析网络地址");
                DialogResult = DialogResult.None;
            }

        }

        private void ModifySonarSetup_Click(object sender, EventArgs e)
        {

        }

        private void StartWizard_Click(object sender, EventArgs e)
        {
            WizardForm wf = new WizardForm();
            wf.ShowDialog();

        }
    }
}
