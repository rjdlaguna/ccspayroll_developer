using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class ProjectProfileForm : Form
    {
        private string projectName;
        private string projectDescription;
        private string projectAddress;
        private string projectPersonInCharge;
        private string projectContactNo;
        private string projectEmailAddress;
        public ProjectProfileForm()
        {
            InitializeComponent();
        }

        private string ValidateProjectDataFields(string projname, string projdesc, string projaddress, string personincharge, string projcontactno, string projemail)
        {
            string prompt = "";
            if (IsProjectFieldEmpty(projname))
            {
                txtProjectName.Focus();
                prompt = "Project Name cannot be empty.";
            }
            /* else if (IsProjectFieldEmpty(projaddress))
             {
                 txtProjectAddress.Focus();
                 prompt = "Project Address cannot be empty.";
             }
             else if (IsProjectFieldEmpty(personincharge))
             {
                 txtPersonInCharge.Focus();
                 prompt = "Person In-Charge cannot be empty.";
             }
             else if (IsProjectFieldEmpty(projcontactno))
             {
                 txtProjectContactNo.Focus();
                 prompt = "Contact No. cannot be empty.";
             }*/
            return prompt;

        }

        private bool IsProjectFieldEmpty(string projectValue)
        {
            bool isEmpty = false;
            if (String.IsNullOrEmpty(projectValue))
            {
                lblProjectPrompt.Text = "";
                lblProjectPrompt.Show();
                isEmpty = true;
            }
            return isEmpty;
        }

        private void SetProjectFieldValues()
        {
            projectName = txtProjectName.Text;
            projectDescription = txtProjectDescription.Text;
            projectAddress = txtProjectAddress.Text;
            projectPersonInCharge = txtPersonInCharge.Text;
            projectContactNo = txtProjectContactNo.Text;
            projectEmailAddress = txtProjectEmailAddress.Text;
        }

        private void ClearProjectTextFields()
        {
            txtProjectName.Clear();
            txtProjectDescription.Clear();
            txtProjectAddress.Clear();
            txtPersonInCharge.Clear();
            txtProjectContactNo.Clear();
            txtProjectEmailAddress.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string projectPrompt = null;
            SetProjectFieldValues();
            lblProjectPrompt.Text = ValidateProjectDataFields(projectName, projectDescription, projectAddress, projectPersonInCharge, projectContactNo, projectEmailAddress);
            projectPrompt = lblProjectPrompt.Text;
            if (String.IsNullOrEmpty(projectPrompt) || projectPrompt == "")
            {
                QueryProcessor projectProcessor = new QueryProcessor();
                projectProcessor.ExecuteSQLProjectDataSaveQuery(projectName, projectDescription, projectAddress, projectPersonInCharge, projectContactNo, projectEmailAddress, () =>
                {
                    MessageBox.Show("Project details successfully saved.");
                    ClearProjectTextFields();
                }, () =>
                {
                    MessageBox.Show("Problem saving project details.");
                });
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
