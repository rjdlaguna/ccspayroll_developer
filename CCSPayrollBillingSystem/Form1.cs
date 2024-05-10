using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class FormMain : Form
    {
        private string userLogged;
        public FormMain()
        {
            InitializeComponent();
            userLogged = SessionManager.LoggedInUser;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabelMainView.Text = userLogged + " logged!";
            if (userLogged != Constants.ADMIN) { 
                usersToolStripMenuItem.Visible = false;
                empSettingsToolStripMenuItem.Visible = false;
            }
        }

        #region Buttons for Prompts
        private void btnPayrollMenu_Click(object sender, EventArgs e)
        {
            PayrollPrompt payrollPrompt = new PayrollPrompt();
            payrollPrompt.InitializeFormPositionConfig();
        }

        private void btnBillingMenu_Click(object sender, EventArgs e)
        {

            QueryProcessor projectProcessor = new QueryProcessor();
            int projectNum = projectProcessor.ExecuteSQLCheckCountProjecrtsQuery(
               () =>
               {
                   Console.WriteLine("Projects are added.");
               },
               () =>
               {
                   Console.WriteLine("No projects were added.");
               });
            if(projectNum > 0)
            {
                frmBilling frmBilling = new frmBilling();
                frmBilling.InitializeFormPositionConfig();
            }
            else
            {
                MessageBox.Show("There are no projects found. Please add.", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnPrintMenu_Click(object sender, EventArgs e)
        {
            PrintForm frmPrint = new PrintForm();
            frmPrint.InitializeFormPositionConfig();
        }

        private void btnProfilePromptEmployee_Click(object sender, EventArgs e)
        {
            EmployeePrompt frmEmployeePrompt = new EmployeePrompt();
            frmEmployeePrompt.InitializeFormPositionConfig();   
        }

        private void btnProfilePromptProject_Click(object sender, EventArgs e)
        {
            ProjectPrompt frmProjectPrompt = new ProjectPrompt();
            frmProjectPrompt.InitializeFormPositionConfig();
        }
        #endregion

        #region Menu Strips
        private void employeePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeePayroll frmEmployeePayroll = new frmEmployeePayroll();
            frmEmployeePayroll.InitializeFormPositionConfig();
        }


        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryProcessor projectProcessor = new QueryProcessor();
            int projectNum = projectProcessor.ExecuteSQLCheckCountProjecrtsQuery(
               () =>
               {
                   Console.WriteLine("Projects are added.");
               },
               () =>
               {
                   Console.WriteLine("No projects were added.");
               });
            if(projectNum > 0)
            {
                frmBilling frmBilling = new frmBilling();
                frmBilling.InitializeFormPositionConfig();
            }
            else
            {
                MessageBox.Show("There are no projects found. Please add.", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeProfileForm frmEmployeeProfile = new EmployeeProfileForm();
            frmEmployeeProfile.InitializeFormPositionConfig();
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProjectProfileForm frmProjectProfile = new ProjectProfileForm();
            frmProjectProfile.InitializeFormPositionConfig();
        }


        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersPrompt usersPrompt = new UsersPrompt();
            usersPrompt.InitializeFormPositionConfig();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ChangePassword changePassword = new ChangePassword(userLogged);
            changePassword.InitializeFormPositionConfig();
        }
        private void jobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Job job = new Job();
            job.InitializeFormPositionConfig();
        }
        private void deductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Deduction deduction = new Deduction();
            deduction.InitializeFormPositionConfig();
        }

        private void updateEmployeePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeUpdatePayroll employeeUpdatePayroll = new EmployeeUpdatePayroll();
            employeeUpdatePayroll.InitializeFormPositionConfig();
        }

        private void payrollToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmployeePrintForm employeePrintForm = new EmployeePrintForm();
            employeePrintForm.InitializeFormPositionConfig();
        }
        #endregion

        public void OnApplicationExit() => Application.Exit();

        private void billingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QueryProcessor projectProcessor = new QueryProcessor();
            int projectNum = projectProcessor.ExecuteSQLCheckCountProjecrtsQuery(
               () =>
               {
                   Console.WriteLine("Projects are added.");
               },
               () =>
               {
                   Console.WriteLine("No projects were added.");
               });
            if (projectNum > 0)
            {
                frmBilling frmBilling = new frmBilling();
                frmBilling.InitializeFormPositionConfig();
            }
            else
            {
                MessageBox.Show("There are no projects found. Please add.", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}

