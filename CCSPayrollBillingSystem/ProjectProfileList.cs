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
    public partial class ProjectProfileList : Form
    {
        private int projectId;
        private string projectName;
        private string projectDescription;
        private string projectAddress;
        private string projectPersonInCharge;
        private string projectContactNo;
        private string projectEmail;

        QueryProcessor projectProcessor = new QueryProcessor();
        public ProjectProfileList()
        {
            InitializeComponent();
        }

        private void ProjectProfileList_Load(object sender, EventArgs e)
        {
            projectName = txtsearchprojectname.Text;
            if(String.IsNullOrEmpty(projectName)  || projectName == "")
            {
                projectName = null;
            }
            LoadProjectProfileInfo(projectName);
            EnableDisableProjectTextFields(false);
            btnAddEmpToProject.Enabled = false;
        }

        private void LoadProjectProfileInfo(string projname)
        {
            ViewProjectsList(projname);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgProjectProfileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedProjectToTextFields();
        }

        private void dgProjectProfileList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedProjectToTextFields();
            EnableDisableProjectTextFields(true);
            btnAddEmpToProject.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LoadSelectedProjectToTextFields();
            btnAddEmpToProject.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetTextFieldValuesToDataMembers();
            projectProcessor.ExecuteSqlProjectDataUpdate(projectId, projectName, projectDescription, projectAddress, projectPersonInCharge, projectContactNo, projectEmail, () =>
                 {
                     MessageBox.Show("Project information successfully updated.");
                     ViewProjectsList(projectName);
                     ClearProjectTextFields();
                     ResetProjectDataMembers();
                 }, () =>
                 {
                     MessageBox.Show("Problem updating project information.");
                 });
        }
        private void LoadSelectedProjectToTextFields()
        {
            projectId = Convert.ToInt32(dgProjectProfileList.SelectedRows[0].Cells[0].Value.ToString());
            txteditProjectName.Text = dgProjectProfileList.SelectedRows[0].Cells[1].Value.ToString();
            txteditProjectDesc.Text = dgProjectProfileList.SelectedRows[0].Cells[2].Value.ToString();
            txteditProjectAdd.Text = dgProjectProfileList.SelectedRows[0].Cells[3].Value.ToString();
            txteditProjectInCharge.Text = dgProjectProfileList.SelectedRows[0].Cells[4].Value.ToString();
            txteditProjectContact.Text = dgProjectProfileList.SelectedRows[0].Cells[5].Value.ToString();
            txteditProjectEmail.Text = dgProjectProfileList.SelectedRows[0].Cells[6].Value.ToString();
            EnableDisableProjectTextFields(true);
        }

        private void SetTextFieldValuesToDataMembers()
        {
            projectName = txteditProjectName.Text;
            projectDescription = txteditProjectDesc.Text;
            projectAddress = txteditProjectAdd.Text;
            projectPersonInCharge = txteditProjectInCharge.Text;
            projectContactNo = txteditProjectContact.Text;
            projectEmail = txteditProjectEmail.Text;
        }

        private void ClearProjectTextFields()
        {
            txteditProjectName.Clear();
            txteditProjectDesc.Clear();
            txteditProjectAdd.Clear();
            txteditProjectInCharge.Clear();
            txteditProjectContact.Clear();
            txteditProjectEmail.Clear();
        }

        private void EnableDisableProjectTextFields(bool isEnabled)
        {
            txteditProjectName.Enabled = isEnabled;
            txteditProjectDesc.Enabled = isEnabled;
            txteditProjectAdd.Enabled = isEnabled;
            txteditProjectInCharge.Enabled = isEnabled;
            txteditProjectContact.Enabled = isEnabled;
            txteditProjectEmail.Enabled = isEnabled;
        }

        private void btnAddEmpToProject_Click(object sender, EventArgs e)
        {
            ProjectEmployeeList frmProjectEmployeeList = new ProjectEmployeeList();
            frmProjectEmployeeList.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult deleteAction = MessageBox.Show("Are you sure you want to delete this project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteAction == DialogResult.Yes)
            {
                projectProcessor.ExecuteSqlProjectStatusUpdateQuery(projectId, () =>
                {
                    Console.WriteLine("Project Status successfully updated.");
                    ViewProjectsList(projectName);
                }, () =>
                {
                    Console.WriteLine("Problem updating Project Status.");
                });
            }
            else if (deleteAction == DialogResult.No)
            {
                dgProjectProfileList.Focus();
            }
        }

        private void ViewProjectsList(string project_name)
        {
            projectProcessor.ExecuteSqlProjectDataViewQuery(project_name, () =>
            {
                Console.WriteLine("Loading Project Profile Information successful.");
                dgProjectProfileList.DataSource = projectProcessor.GetSqlReaderData();
                dgProjectProfileList.Columns[0].Visible = false;
            }, () =>
            {
                Console.WriteLine("Problem loading project profile information.");
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            projectName = txtsearchprojectname.Text;
        }

        private void ResetProjectDataMembers()
        {
            projectName = "";
            projectDescription = "";
            projectAddress = "";
            projectPersonInCharge = "";
            projectContactNo = "";
            projectEmail = "";
        }

        private void dgProjectProfileList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedProjectToTextFields();
            EnableDisableProjectTextFields(false);
            projectId = Convert.ToInt32(dgProjectProfileList.SelectedRows[0].Cells[0].Value.ToString());
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAddEmpToProject.Enabled = true;
        }
    }
}
