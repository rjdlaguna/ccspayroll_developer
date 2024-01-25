using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;
using CCSPayrollBillingSystem.Scripts.SystemUtility;

namespace CCSPayrollBillingSystem
{
    public partial class ProjectEmployeeList : Form
    {
        public int empId;
        public string empFname;
        public string empLname;
        public decimal empRate;
        public string empRank;

        public int projId;
        public string projName;
        public decimal projRate;

        EmployeeListForPayroll employeeList = new EmployeeListForPayroll();
        QueryProcessor projectProcessor = new QueryProcessor();


        public ProjectEmployeeList()
        {
            InitializeComponent();
            _projectProcessor = new ProjectProcessor();
        }

        private ProjectProcessor _projectProcessor;
        private IDictionary<int, string> projectInfo;

        private void ProjectEmployeeList_Load(object sender, EventArgs e)
        {
            projectInfo = _projectProcessor.ProjectInfo;

            cmbProject.DataSource = new BindingSource(projectInfo, null);
            cmbProject.DisplayMember = "Value";
            cmbProject.ValueMember = "Key";

            employeeList.OnEmployeeSearchedValues += LoadSearchedEmployeeDetails;

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            empFname = txtaddfirstname.Text;
            empLname = txtaddlastname.Text;
            projRate = Convert.ToDecimal(txtprojectrate.Text);
            projName = cmbProject.Text;
            if (String.IsNullOrEmpty(empFname))
            {
                MessageBox.Show("First name cannot be empty.");
            }
            else if (String.IsNullOrEmpty(empLname))
            {
                MessageBox.Show("Last name cannot be empty.");
            }
            else if (projRate <= 0)
            {
                MessageBox.Show("Project rate cannot be 0 or negative.");
                txtprojectrate.Focus();
            }
            else if (projName == "Select" || String.IsNullOrEmpty(projName))
            {
                MessageBox.Show("Please select a project.");
                cmbProject.Focus();
            }
            else
            {
                if (CheckEmployeeInfoExists(empFname, empLname) != 1)
                {
                    projId = projectInfo.FirstOrDefault(x => x.Value == projName).Key;
                    projectProcessor.ExecuteSQLAddEmployeeToProject(empId, projId, projRate, () =>
                    {
                        MessageBox.Show("Employee successfully added in project.");
                        ResetAddEmployeeToProjectTextFields();
                    }, () =>
                    {
                        MessageBox.Show("Problem adding employee in the project.");
                    });
                }
                else
                {
                    MessageBox.Show("Employee already added in project.");
                    txtaddlastname.Focus();
                }
            }
            
        }

        private int CheckEmployeeInfoExists(string fname, string lname)
        {
            empId = projectProcessor.ExecuteSQLCheckEmployeeExist(fname, lname, () =>
            {
                Console.WriteLine("Employee Information existing.");
            }, () =>
            {
                Console.WriteLine("Employee information ot existing.");
            });

            return empId;

        }

        private void ResetAddEmployeeToProjectTextFields()
        {
            txtaddfirstname.Clear();
            txtaddlastname.Clear();
            txtprojectrate.Text = "0.00";
            cmbProject.Text = "Select";
        }

        private void LoadProjectEmployees(int id)
        {
            projectProcessor.ExecuteSQLLoadProjectEmployeesQuery(id, () =>
            {
                dgEmployeeInProjectList.DataSource = projectProcessor.GetSqlReaderData();
                Console.WriteLine("Loading Employee for the Project successful.");
            }, () =>
            {
                Console.WriteLine("Problem loading employee for the project.");
            });
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            projName = cmbProject.Text;
            projId = projectInfo.FirstOrDefault(x => x.Value == projName).Key;
            dgEmployeeInProjectList.DataSource = null;
            LoadProjectEmployees(projId);
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            employeeList.Show();
        }

        private void LoadSearchedEmployeeDetails(Employee emp)
        {
            empId = emp.EmpIdPayroll;
            empLname = emp.EmpFnamePayroll;
            empFname = emp.EmpLnamePayroll;

            txtaddfirstname.Text = empFname;
            txtaddlastname.Text = empLname;
        }
    }
}
