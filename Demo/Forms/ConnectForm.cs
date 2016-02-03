using System;
using DevComponents.DotNetBar;

namespace Demo.Forms
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
