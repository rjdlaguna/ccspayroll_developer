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
    public partial class ProjectEmployeeList : Form
    {
        private int empId;
        private string empFname;
        private string empLname;
        private int projId;
        private string projName;
        private decimal projRate;

        QueryProcessor projectProcessor = new QueryProcessor();
        IDictionary<int, string> projetInfo = new Dictionary<int, string>();
        public ProjectEmployeeList()
        {
            InitializeComponent();
        }

        private void ProjectEmployeeList_Load(object sender, EventArgs e)
        {
            List<string[]> projectList = new List<string[]>();
            
            projectList = projectProcessor.ExecuteSqlLoadProjectsQuery(
            () =>
            {
                Console.WriteLine("Projects successfully loaded.");
            }, () =>
            {
                Console.WriteLine("Problem loading projects.");
            });

            ExtractProjectName(projectList);

        }

        private void ExtractProjectName(List<string[]> projectList)
        {
            int[] projIds = new int[projectList.Count];
            string projNameVal = "";
            int projNameId = 0;
            int count = 0;
            foreach (string[] project in projectList)
            {
                // Access the elements within each row
                foreach (string value in project)
                {
                    if (int.TryParse(value, out int id))
                    {
                        projIds[count] = id;
                        projNameId = id;
                        count++;
                    }
                    else
                    {
                        cmbProject.Items.Add(value);
                        projNameVal = value;
                    }

                }
                projetInfo.Add(projNameId, projNameVal);

            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            empFname = txtaddfirstname.Text;
            empLname = txtaddlastname.Text;
            projRate = Convert.ToDecimal(txtprojectrate.Text);
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
            }
            else
            {
                projName = cmbProject.Text;
                CheckEmployeeInfoExists(empFname, empLname);
                projId = projetInfo.FirstOrDefault(x => x.Value == projName).Key;
                projectProcessor.ExecuteSQLAddEmployeeToProject(empId, projId, projRate, () =>
                  {
                      MessageBox.Show("Employee successfully added in project.");
                      ResetAddEmployeeToProjectTextFields();
                  }, () =>
                  {
                      MessageBox.Show("Problem adding employee in the project.");
                  });
            }
            
        }

        private void CheckEmployeeInfoExists(string fname, string lname)
        {
            empId = projectProcessor.ExecuteSQLCheckEmployeeExist(fname, lname, () =>
            {
                Console.WriteLine("Employee Information existing.");
            }, () =>
            {
                Console.WriteLine("Employee information ot existing.");
            });

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
            projId = projetInfo.FirstOrDefault(x => x.Value == projName).Key;
            dgEmployeeInProjectList.DataSource = null;
            LoadProjectEmployees(projId);
        }
    }
}
