using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;

namespace Demo
{
    public partial class WizardForm : Office2007Form
    {
        public WizardForm()
        {
            InitializeComponent();
        }

        private void wizardPage8_Enter(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("任务名称：" + Configuration.SlnName);
            sb.AppendLine();
            sb.AppendLine("数据文件目录：" + Configuration.DataPath);
            sb.AppendLine("数据文件前缀：" + Configuration.prefix);
            sb.AppendLine("数据文件保存间隔（分）：" + Configuration.Intelval.ToString());
            sb.AppendLine();
            sb.AppendLine("目标文件目录：" + Configuration.TargetCatalogFile);
            sb.AppendLine();
            sb.AppendLine("路径图文件：" + Configuration.SurveyRouteFile);
            sb.AppendLine("声纳状态文件名：" + Configuration.StateFile);
            string word = Configuration.SaveStateFileAfterSurveyFinish ? "是" : "否";
            sb.AppendLine("完成向导后保存状态文件：" + word);
            sb.AppendLine();
            word = Configuration.UsePress ? "是" : "否";
            sb.AppendLine("使用压力传感器：" + word);
            if (Configuration.UsePress)
            {
                sb.AppendLine("比例因子：" + Configuration.ScaleFactor.ToString("F3"));
                sb.AppendLine("偏移值：" + Configuration.PressOffset);
            }
        }

        private bool IsValidFileName(string fileName)
        {
            bool isValid = true;
            string errChar = "\\/:*?\"<>|";  //
            if (string.IsNullOrEmpty(fileName))
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < errChar.Length; i++)
                {
                    if (fileName.Contains(errChar[i].ToString()))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            return isValid;
        }     
        private void SolutionName_TextChanged(object sender, EventArgs e)
        {
            if (IsValidFileName(SolutionName.Text))
            {
                NamePage.NextButtonEnabled = eWizardButtonState.True;
            }
            else
                NamePage.NextButtonEnabled = eWizardButtonState.False;
        }

        private void wizardPage2_Enter(object sender, EventArgs e)
        {
            if (File.Exists(TargetCatalogFileBox.Text))
            {
                wizardPage2.NextButtonEnabled = eWizardButtonState.True;
            }
            else
                wizardPage2.NextButtonEnabled = eWizardButtonState.False;
        }

        private void wizardPage5_Enter(object sender, EventArgs e)
        {
            if (ExitRd.Checked)
            {
                groupBoxExit.Enabled = true;
                groupBoxNew.Enabled = false;
            }
            if (NewRd.Checked)
            {
                groupBoxExit.Enabled = false;
                groupBoxNew.Enabled = true;
            }
        }

        private void ExitRd_Click(object sender, EventArgs e)
        {
            groupBoxExit.Enabled = true;
            groupBoxNew.Enabled = false;
        }

        private void NewRd_Click(object sender, EventArgs e)
        {
            groupBoxExit.Enabled = false;
            groupBoxNew.Enabled = true;
        }

        private void wizardPage5_NextButtonClick(object sender, CancelEventArgs e)
        {
            if (ExitRd.Checked)
            {
                if (!File.Exists(SelectRouteFileBox.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("文件不存在！");
                    return;
                }
                Configuration.SurveyRouteFile = SelectRouteFileBox.Text;
            }
            if (NewRd.Checked)
            {
                try
                {
                    FileStream fs = new FileStream(NewRouteFileBox.Text,FileMode.CreateNew);
                    fs.Close();
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    MessageBox.Show(ex.Message);
                    return;
                }
                Configuration.SurveyRouteFile = NewRouteFileBox.Text;
            }

        }

        private void NamePage_NextButtonClick(object sender, CancelEventArgs e)
        {
            Configuration.SlnName = SolutionName.Text;
        }

        private void wizardPage1_NextButtonClick(object sender, CancelEventArgs e)
        {
            Configuration.DataPath = SelectPath.Text;
            Configuration.prefix = PrefixBox.Text;
            Configuration.Intelval = StoreInteval.Value;
            Configuration.SaveOption = OnlyRawRd.Checked ? 0 : OnlyResultRd.Checked ? 1 : 2;
        }

        private void wizardPage2_NextButtonClick(object sender, CancelEventArgs e)
        {
            Configuration.TargetCatalogFile = TargetCatalogFileBox.Text;
        }

        private void wizardPage6_NextButtonClick(object sender, CancelEventArgs e)
        {
            Configuration.StateFile = StateFileBox.Text;
            Configuration.SaveStateFileAfterSurveyFinish = SaveStateCheck.Checked;
        }

        private void wizardPage7_NextButtonClick(object sender, CancelEventArgs e)
        {
            Configuration.UsePress = PressSensorCheck.Checked;
            if (Configuration.UsePress)
            {
                bool ret = float.TryParse(PressScaleBox.Text, out Configuration.ScaleFactor) &&
                           float.TryParse(PressOffsetBox.Text, out Configuration.PressOffset);
                if (!ret)
                {
                    MessageBox.Show("数据输入有误！");
                    e.Cancel = true;
                }
            }
        }


    }
}
