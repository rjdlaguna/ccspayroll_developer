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
            payrollPrompt.StartPosition = FormStartPosition.CenterScreen;
            payrollPrompt.ShowDialog();
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
                frmBilling.StartPosition = FormStartPosition.CenterScreen;
                frmBilling.ShowDialog();
            }
            else
            {
                MessageBox.Show("There are no projects found. Please add.", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnPrintMenu_Click(object sender, EventArgs e)
        {
            PrintForm frmPrint = new PrintForm();
            frmPrint.StartPosition = FormStartPosition.CenterScreen;
            frmPrint.ShowDialog();
        }

        private void btnProfilePromptEmployee_Click(object sender, EventArgs e)
        {
            EmployeeProfileForm frmEmployeeProfile = new EmployeeProfileForm();
            frmEmployeeProfile.StartPosition = FormStartPosition.CenterScreen;
            frmEmployeeProfile.ShowDialog();
        }

        private void btnProfilePromptProject_Click(object sender, EventArgs e)
        {
            ProjectProfileForm frmProjectProfile = new ProjectProfileForm();
            frmProjectProfile.StartPosition = FormStartPosition.CenterScreen;
            frmProjectProfile.ShowDialog();
        }
        #endregion

        #region Menu Strips
        private void employeePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeePayroll frmEmployeePayroll = new frmEmployeePayroll();
            frmEmployeePayroll.StartPosition = FormStartPosition.CenterScreen;
            frmEmployeePayroll.ShowDialog();
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
                frmBilling.StartPosition = FormStartPosition.CenterScreen;
                frmBilling.ShowDialog();
            }
            else
            {
                MessageBox.Show("There are no projects found. Please add.", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeProfileForm frmEmployeeProfile = new EmployeeProfileForm();
            frmEmployeeProfile.StartPosition = FormStartPosition.CenterScreen;
            frmEmployeeProfile.ShowDialog();
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProjectProfileForm frmProjectProfile = new ProjectProfileForm();
            frmProjectProfile.StartPosition = FormStartPosition.CenterScreen;
            frmProjectProfile.ShowDialog();
        }


        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UsersPrompt usersPrompt = new UsersPrompt();
            usersPrompt.StartPosition = FormStartPosition.CenterScreen;
            usersPrompt.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            formLogin formLogin = new formLogin();
            formLogin.Show();
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ChangePassword changePassword = new ChangePassword(userLogged);
            changePassword.StartPosition = FormStartPosition.CenterScreen;
            changePassword.ShowDialog();
        }
        private void jobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Job job = new Job();
            job.Show();
        }
        private void deductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Deduction deduction = new Deduction();
            deduction.StartPosition = FormStartPosition.CenterScreen;
            deduction.ShowDialog();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            EmployeePrintForm employeePrintForm = new EmployeePrintForm();
            employeePrintForm.StartPosition = FormStartPosition.CenterScreen;
            employeePrintForm.ShowDialog();
        }
        #endregion

        public void OnApplicationExit() => Application.Exit();

        private void billingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBilling frmBilling = new frmBilling();
            frmBilling.StartPosition = FormStartPosition.CenterScreen;
            frmBilling.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void updateEmployeePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeUpdatePayroll employeeUpdatePayroll = new EmployeeUpdatePayroll();
            employeeUpdatePayroll.StartPosition = FormStartPosition.CenterScreen;
            employeeUpdatePayroll.ShowDialog();
        }
    }
}
