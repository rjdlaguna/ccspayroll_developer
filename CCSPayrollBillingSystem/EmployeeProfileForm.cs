using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeeProfileForm : Form
    {
        private string empFirstName;
        private string empLastName;
        private string empMiddleName;
        private string empHomeAddress;
        private string empContactNo;
        private DateTime empBirthDate;
        private DateTime empDateHired;
        private DateTime empContractEnd;
        private int empDeductionID;
        private int empJobID;
        private int empStatus = 1;

        IDictionary<int, string> jobInfo = new Dictionary<int, string>();
        public EmployeeProfileForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string promptText = null;
            SetEmployeeValues();
            txtEmpDataPrompt.Text = ValidateEmpDataFields(empFirstName, empMiddleName, empLastName, empHomeAddress, empContactNo, empBirthDate, empDateHired, empContractEnd, empJobID, empDeductionID);
            promptText = txtEmpDataPrompt.Text;
            
            if(String.IsNullOrEmpty(promptText) || promptText == "")
            {

                QueryProcessor empDataProcessor = new QueryProcessor();
                empDataProcessor.ExecuteSqlEmpDataSaveQuery(empFirstName, empMiddleName, empLastName, empHomeAddress, empContactNo, empBirthDate, empDateHired, empContractEnd, empJobID,empStatus, empDeductionID,() =>
                {
                    // Successful Job action
                    ClearEmpDataTextFields();
                    MessageBox.Show("Employee data successfully saved.");
                }, () =>
                {
                    MessageBox.Show("Error inserting employee data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                );
            }
        }

        private void SetEmployeeValues()
        {
            empFirstName = txtfirstname.Text;
            empMiddleName = txtmiddlename.Text;
            empLastName = txtlastname.Text;
            empHomeAddress = txthomeaddress.Text;
            empContactNo = txtcontactno.Text;
            empBirthDate = dtbirthdate.Value;
            empDateHired = dtdatehired.Value;
            empContractEnd = dtcontractend.Value;
        }

        private string ValidateEmpDataFields(string fname, string mname, string lname, string homeadd, string contactno, DateTime bdate, DateTime dhired, DateTime contractend, int jobID, int deductionID)
        {
            string prompt = "";

            if (IsEmptyEmpDataFields(fname))
            {
                txtfirstname.Focus();
                prompt = "First Name cannot be empty.";
            }
            else if (IsEmptyEmpDataFields(lname))
            {
                txtlastname.Focus();
                prompt = "Last Name cannot be empty.";
            }
            else if (IsEmptyEmpDataFields(homeadd))
            {
                txthomeaddress.Focus();
                prompt = "Home Address cannot be empty.";
            }
            else if (IsEmptyEmpDataFields(contactno))
            {
                txtcontactno.Focus();
                prompt = "Contact No. cannot be empty.";
            }
            else if (GetAge(Convert.ToDateTime(bdate)) < 18)
            {
                dtbirthdate.Focus();
                txtEmpDataPrompt.Text = "";
                txtEmpDataPrompt.Show();
                prompt = "Age must be atleast 18 years old. Check date of birth.";
            } 
            else if (jobID == 0)
            {
                cmbJob.Focus();
                txtEmpDataPrompt.Text = "";
                txtEmpDataPrompt.Show();
                prompt = "Job should be selected.";
            }
            else if (deductionID == 0)
            {
                cmbJob.Focus();
                txtEmpDataPrompt.Text = "";
                txtEmpDataPrompt.Show();
                prompt = "Selected job does not have a deduction.";
            }
            else
            {
                txtEmpDataPrompt.Text = "";
                txtEmpDataPrompt.Show();
                prompt = "";
            }
            return prompt;
        }

        private void EmployeeProfileForm_Load(object sender, EventArgs e)
        {
            txtEmpDataPrompt.Hide();
            List<string[]>jobList = new List<string[]>();

            QueryProcessor jobsProcessor = new QueryProcessor();
            jobList = jobsProcessor.ExecuteSqlLoadJobsQuery(
            () =>
            {
                Console.WriteLine("Load jobs successfully.");
            }, () =>
            {
                Console.WriteLine("Problem loading jobs.");
            });

            ExtractJobTitle(jobList);

        }

        public static int GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now;
            int age = n.Year - birthDate.Year;
            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age;
        }

        private bool IsEmptyEmpDataFields(string empValue)
        {
            bool isEmpty = false;
            if(String.IsNullOrEmpty(empValue))
            {
                txtEmpDataPrompt.Text = "";
                txtEmpDataPrompt.Show();
                isEmpty = true;
            }
            return isEmpty;
        }

        private void ClearEmpDataTextFields()
        {
            txtfirstname.Clear();
            txtmiddlename.Clear();
            txtlastname.Clear();
            txthomeaddress.Clear();
            txtcontactno.Clear();
            cmbJob.Text = "Select";
            dtbirthdate.Value = DateTime.Now;
            dtdatehired.Value = DateTime.Now;
            dtcontractend.Value = DateTime.Now;
        }

        private void btnViewEmp_Click(object sender, EventArgs e)
        {
            EmployeeListForm frmEmpList = new EmployeeListForm();
            frmEmpList.Show();
        }

        private int GetJobIdAssigned(int jobId)
        {
            return jobId;
        }

        private void cmbJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobTitle = cmbJob.Text.Trim();
            int jobTitleId = jobInfo.FirstOrDefault(x => x.Value.Trim() == jobTitle).Key;
            empJobID = GetJobIdAssigned(jobTitleId);
            QueryProcessor deductionProcessor = new QueryProcessor();
            empDeductionID = deductionProcessor.ExecuteSQLGetDeductionIDbyJobID(empJobID, () =>
            {
                Console.WriteLine("Successfully retrieved deduction ID.");
            }, () =>
            {
                Console.WriteLine("Deduction ID not found.");
            });

        }

        private void ExtractJobTitle(List<string[]> jobList)
        {
            int[] jobIds = new int[jobList.Count];
            string jobTitleVal = "";
            int jobTitleId = 0;
            int count = 0;
            foreach (string[] job in jobList)
            {
                // Access the elements within each row
                foreach (string value in job)
                {
                    if (int.TryParse(value, out int id))
                    {
                        jobIds[count] = id;
                        jobTitleId = id;
                        count++;
                    }
                    else
                    {
                        cmbJob.Items.Add(value);
                        jobTitleVal = value;
                    }

                }
                jobInfo.Add(jobTitleId, jobTitleVal);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtbirthdate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
