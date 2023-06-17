using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class Job : Form
    {
        private string jobTitle;
        private string jobDescription;
        private string jobRank;
        private decimal jobPayRate;
        public Job()
        {
            InitializeComponent();
        }

        public void SetUIs(string jobTitle, string jobDescription, string jobRank, decimal jobPayRate)
        {
            txtJobTitle.Text = jobTitle;
            txtJobDescription.Text = jobDescription;
            comboRank.Text = jobRank;
            txtPayRate.Text = jobPayRate.ToString();
        }

        public void SetFields()
        {
            jobTitle = txtJobTitle.Text;
            jobDescription = txtJobDescription.Text;
            jobRank = comboRank.Text;
            jobPayRate = decimal.Parse(txtPayRate.Text);
        }

        public void ClearUIs()
        {
            txtJobTitle.Text = string.Empty;
            txtJobDescription.Text = string.Empty;
            comboRank.Text = string.Empty;
            txtPayRate.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetFields();

            if (ValidateInput())
            {
                QueryProcessor jobProcessor = new QueryProcessor();
                jobProcessor.ExecuteSqlSearchValidationQuery(jobTitle, () =>
                {
                    // Successful Job action
                    jobProcessor.ExecuteSqlSaveQuery(jobTitle, jobDescription, jobRank, jobPayRate);
                    MessageBox.Show(" Record Successfully Inserted.");

                    FormMain formMain = new FormMain();
                    this.Close();
                    formMain.Show();
                }, () =>
                {
                    // Failed Job action
                    MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            else
            {
                MessageBox.Show("Please Fill the Required Fields Correctly!");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetFields();

            if (ValidateInput())
            {
                QueryProcessor jobProcessor = new QueryProcessor();
                jobProcessor.ExecuteSqlSearchJobQuery(jobTitle, (jobTitle, jobDescription, jobRank, jobPayRate) =>
                {
                    // Successful Job action
                    jobProcessor.ExecuteSqlUpdateQuery(jobTitle, jobDescription, jobRank, decimal.Parse(jobPayRate));
                    MessageBox.Show(" Record Successfully Updated.");

                    FormMain formMain = new FormMain();
                    this.Close();
                    formMain.Show();
                }, () =>
                {
                    // Failed Job action
                    MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            else
            {
                MessageBox.Show("Please Fill the Required Fields Correctly!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            jobTitle = txtJobTitle.Text;

            if (jobTitle != string.Empty)
            {
                QueryProcessor jobProcessor = new QueryProcessor();
                jobProcessor.ExecuteSqlSearchJobQuery(jobTitle, (jobTitle, jobDescription, jobRank, jobPayRate) =>
                {
                    // Successful Job action
                    SetUIs(jobTitle, jobDescription, jobRank, decimal.Parse(jobPayRate));
                    MessageBox.Show(" Record Successfully Searched.");

                    //FormMain formMain = new FormMain();
                    //this.Close();
                    //formMain.Show();
                }, () =>
                {
                    // Failed Job action
                    MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            else
            {
                MessageBox.Show("Please Fill the Required Fields Correctly!");
            }
        }

        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(txtJobTitle.Text) && !string.IsNullOrEmpty(comboRank.Text) && !string.IsNullOrEmpty(txtPayRate.Text);
        }
    }
}
