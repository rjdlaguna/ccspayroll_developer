using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            payrollPrompt.Show();
        }

        private void btnBillingMenu_Click(object sender, EventArgs e)
        {

            frmBilling frmBilling = new frmBilling();
            frmBilling.Show();
        }

        private void btnPrintMenu_Click(object sender, EventArgs e)
        {
            PrintForm frmPrint = new PrintForm();
            frmPrint.Show();
        }

        private void btnProfilePromptEmployee_Click(object sender, EventArgs e)
        {
            EmployeeProfileForm frmEmployeeProfile = new EmployeeProfileForm();
            frmEmployeeProfile.Show();
        }

        private void btnProfilePromptProject_Click(object sender, EventArgs e)
        {
            ProjectProfileForm frmProjectProfile = new ProjectProfileForm();
            frmProjectProfile.Show();
        }
        #endregion

        #region Menu Strips
        private void employeePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeePayroll frmEmployeePayroll = new frmEmployeePayroll();
            frmEmployeePayroll.Show();
        }


        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmBilling frmBilling = new frmBilling();
            frmBilling.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeProfileForm frmEmployeeProfile = new EmployeeProfileForm();
            frmEmployeeProfile.Show();
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProjectProfileForm frmProjectProfile = new ProjectProfileForm();
            frmProjectProfile.Show();
        }


        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UsersPrompt usersPrompt = new UsersPrompt();
            usersPrompt.Show();
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
            changePassword.Show();
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
            deduction.Show();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            EmployeePrintForm employeePrintForm = new EmployeePrintForm();
            employeePrintForm.Show();
        }
        #endregion

        public void OnApplicationExit() => Application.Exit();

        private void billingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBilling frmBilling = new frmBilling();
            frmBilling.Show();
        }


    }
}
