using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class Deduction : Form
    {
        private string deductionID;
        private string jobID;
        private string jobTitle;
        private string sss;
        private string pagibig;
        private string philhealth;
        private string tax;
        private Dictionary<string, string> jobDict;
        private List<string> keysList;
        private List<string> valuesList;

        public Deduction()
        {
            InitializeComponent();
        }
        public void SetUIs(string deductionID, string jobTitle, string sss, string pagibig, string philhealth, string tax)
        {
            txtDeductionID.Text = deductionID;
            cmbJobs.Text = jobTitle;
            txtSSS.Text = sss;
            txtPAGIBIG.Text = pagibig;
            txtPhilHealth.Text = philhealth;
            txtTax.Text = tax;
        }

        public void SetFields()
        {
            deductionID = txtDeductionID.Text;
            jobTitle = cmbJobs.Text;
            sss = txtSSS.Text;
            pagibig = txtPAGIBIG.Text;
            philhealth = txtPhilHealth.Text;
            tax = txtTax.Text;
        }

        public void ClearUIs()
        {
            txtDeductionID.Text = string.Empty;
            cmbJobs.Text = string.Empty;
            txtSSS.Text = string.Empty;
            txtPAGIBIG.Text = string.Empty;
            txtPhilHealth.Text = string.Empty;
            txtTax.Text = string.Empty;
        }

        private void Deduction_Load(object sender, EventArgs e)
        {
            QueryProcessor deductionProcessor = new QueryProcessor();
            deductionProcessor.ExecuteSqlSearchQueryForJobCombo((resultList) =>
            {
                // Successful Job action
                jobDict = resultList;
                keysList = new List<string>(jobDict.Keys);
                valuesList = new List<string>(jobDict.Values);
                cmbJobs.Items.AddRange(valuesList.ToArray());

            }, () =>
            {
                // Failed Job action
                MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            deductionID = txtDeductionID.Text;
            jobTitle = cmbJobs.Text;

            jobID = GetJobID(jobTitle);

            if (deductionID != string.Empty)
            {
                QueryProcessor deductionProcessor = new QueryProcessor();
                deductionProcessor.ExecuteSqlDeductionSearchQuery(deductionID, jobTitle, (jobID, sss, pagibig, philhealth, tax) =>
                {
                    // Successful Job action
                    SetUIs(deductionID, jobTitle, sss, pagibig, philhealth, tax);
                    MessageBox.Show(" Record Successfully Searched.");

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetFields();

            jobID = GetJobID(jobTitle);

            if (ValidateInput())
            {
                QueryProcessor deductionProcessor = new QueryProcessor();
                deductionProcessor.ExecuteSqlSearchValidationQuery(deductionID, jobID, () =>
                {
                    // Successful Job action
                    deductionProcessor.ExecuteSqlDeductionSaveQuery(jobID, sss, pagibig, philhealth, tax);
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
        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(txtSSS.Text) && !string.IsNullOrEmpty(txtPAGIBIG.Text) && !string.IsNullOrEmpty(txtPhilHealth.Text) && !string.IsNullOrEmpty(txtTax.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            this.Close();
            formMain.Show();
        }

        private string GetJobID(string jobTitle)
        {
            jobID = jobDict.FirstOrDefault(pair => pair.Value == jobTitle).Key;
            return jobID;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetFields();

            if (ValidateInput())
            {
                QueryProcessor jobProcessor = new QueryProcessor();
                jobProcessor.ExecuteSqlDeductionSearchQuery(deductionID, jobID, (jobID, sss, pagibig, philhealth, tax) =>
                {
                    // Successful Job action
                    jobProcessor.ExecuteSqlDeductionUpdateQuery(deductionID, jobID, sss, pagibig, philhealth, tax);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
