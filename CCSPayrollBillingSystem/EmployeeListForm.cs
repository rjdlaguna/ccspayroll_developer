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
    public partial class EmployeeListForm : Form
    {
        private int empId;
        private string empFirstName;
        private string empLastName;
        private string empMiddleName;
        private string empHomeAddress;
        private int empContactNo;
        private DateTime empDateOfBirth;
        private string empJobTitle;
        private DateTime dateHired;
        private DateTime endOfContractDate;

        QueryProcessor employeeProcessor = new QueryProcessor();
        //EmployeeListForm frmEmpList = new EmployeeListForm();
        IDictionary<int, string> jobInfo = new Dictionary<int, string>();

        public EmployeeListForm()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LoadSelectedEmployeeToTextFields();
            btnUpdate.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetEmployeeSearchValues();
            employeeProcessor.ExecuteSqlEmpDataViewQuery(empFirstName,empLastName, () =>
            {
                dgEmployeesList.DataSource = employeeProcessor.GetEmpData();
            }, () =>
            {
                MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            List<string[]> jobList = new List<string[]>();
            ViewEmployees(empFirstName, empLastName);
            jobList = employeeProcessor.ExecuteSqlLoadJobsQuery(
            () =>   
            {
                Console.WriteLine("Job list successfully retrieved.");
            }, () =>
            {
                Console.WriteLine("Problem retrieving job list.");
            }
            );

            ExtractJobTitle(jobList);
            EnableDisableTextFields(false);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int jobID = 0;
            jobID = employeeProcessor.ExecuteSqlFindJobID(cmbEditJob.Text.Trim(), () =>
            {
                Console.WriteLine("Job title of Job ID successfully retrieved.");
            }, () =>
            {
                Console.WriteLine("Problem retrieving Job ID of Job Title.");
            });
            employeeProcessor.ExecuteSqlEmpDataUpdate(empId, txteditfirstname.Text, txteditmiddlename.Text, txteditlastname.Text,
                                                      txtedithomeaddress.Text, txteditcontactno.Text, dteditbirthdate.Value, dteditdatehired.Value,
                                                      dteditcontractend.Value, jobID,() =>
                                                      {
                                                          MessageBox.Show("Employee Information successfully updated.");
                                                          ClearTextFields();
                                                          EnableDisableTextFields(false);
                                                          ViewEmployees(empFirstName,empLastName);
                                                      }, () =>
                                                      {
                                                          Console.WriteLine("Problem updating employee information.");
                                                      }
                                                      );

        }
        private void dgEmployeesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedEmployeeToTextFields();
            btnEdit.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgEmployeesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void LoadSelectedEmployeeToTextFields()
        {
            empId = Convert.ToInt32(dgEmployeesList.SelectedRows[0].Cells[0].Value.ToString());
            txteditfirstname.Text = dgEmployeesList.SelectedRows[0].Cells[1].Value.ToString();
            txteditmiddlename.Text = dgEmployeesList.SelectedRows[0].Cells[2].Value.ToString();
            txteditlastname.Text = dgEmployeesList.SelectedRows[0].Cells[3].Value.ToString();
            txtedithomeaddress.Text = dgEmployeesList.SelectedRows[0].Cells[4].Value.ToString();
            txteditcontactno.Text = dgEmployeesList.SelectedRows[0].Cells[5].Value.ToString();
            dteditbirthdate.Text = dgEmployeesList.SelectedRows[0].Cells[6].Value.ToString();
            dteditdatehired.Text = dgEmployeesList.SelectedRows[0].Cells[7].Value.ToString();
            dteditcontractend.Text = dgEmployeesList.SelectedRows[0].Cells[8].Value.ToString();

            string firstName = null, lastName = null, middleName = null;
            int jobID = 0;
            firstName = txteditfirstname.Text;
            lastName = txteditlastname.Text;
            middleName = txteditmiddlename.Text;

            jobID = employeeProcessor.ExecuteSQLGetJobIDThruEmployeeData(firstName, middleName, lastName, () =>
            {

            }, () =>
            {

            });
            string jobTitle = "";

            if (jobInfo.TryGetValue(jobID, out jobTitle))
            {
                cmbEditJob.Text = jobTitle;
                EnableDisableTextFields(true);
            }
            else
            {
                Console.WriteLine($"Key '{jobID}' not found in the dictionary.");
            }
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
                        cmbEditJob.Items.Add(value);
                        jobTitleVal = value;
                    }

                }
                jobInfo.Add(jobTitleId, jobTitleVal);

            }
        }

        private void SetEmployeeSearchValues()
        {
            empFirstName = txtsearchfirstname.Text;
            empLastName = txtsearchlastname.Text;
        }

        private void EnableDisableTextFields(bool isEnabled)
        {
            txteditfirstname.Enabled = isEnabled;
            txteditmiddlename.Enabled = isEnabled;
            txteditlastname.Enabled = isEnabled;
            txteditcontactno.Enabled = isEnabled;
            txtedithomeaddress.Enabled = isEnabled;
            dteditbirthdate.Enabled = isEnabled;
            dteditdatehired.Enabled = isEnabled;
            dteditcontractend.Enabled = isEnabled;
            cmbEditJob.Enabled = isEnabled;
        }

        private void ConvertToDateValue()
        {
            // Assuming the desired columns are the second and third columns (0-based index)
            int[] dateColumns = { 6, 7, 8 };

            foreach (DataGridViewRow row in dgEmployeesList.Rows)
            {
                foreach (int columnIndex in dateColumns)
                {
                    if (row.Cells[columnIndex].Value != null)
                    {
                        string dateString = row.Cells[columnIndex].Value.ToString();
                        DateTime date;

                        if (DateTime.TryParse(dateString, out date))
                        {
                            row.Cells[columnIndex].Value = date.ToShortDateString();
                        }
                        else
                        {
                            // Handle the case when the string cannot be parsed as a valid date
                            // For example, set a default value or display an error message
                        }
                    }
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult deleteAction = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteAction == DialogResult.Yes)
            {
                employeeProcessor.ExecuteSqlEmpStatusUpdateQuery(empId, () =>
                {
                    Console.WriteLine("Employee Status successfully updated.");
                    ViewEmployees(empFirstName,empLastName);
                }, () =>
                {
                    Console.WriteLine("Problem updating Employee Status.");
                });
            }
            else if (deleteAction == DialogResult.No)
            {
                dgEmployeesList.Focus();
            }
        }

        private void dgEmployeesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            empId = Convert.ToInt32(dgEmployeesList.SelectedRows[0].Cells[0].Value.ToString());
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void ClearTextFields()
        {
            txteditfirstname.Clear();
            txteditmiddlename.Clear();
            txteditlastname.Clear();
            txtedithomeaddress.Clear();
            txteditcontactno.Clear();
            dteditbirthdate.Value = DateTime.Now;
            dteditdatehired.Value = DateTime.Now;
            dteditcontractend.Value = DateTime.Now;
        }

        private void ViewEmployees(string fname, string lname)
        {
            employeeProcessor.ExecuteSqlEmpDataViewQuery(fname, lname, () =>
            {
                dgEmployeesList.DataSource = employeeProcessor.GetEmpData();
                ConvertToDateValue();
                dgEmployeesList.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgEmployeesList.Columns[0].Visible = false;
            }, () =>
            {
                MessageBox.Show("Problem listing all employees.");
            });
        }
    }
}
