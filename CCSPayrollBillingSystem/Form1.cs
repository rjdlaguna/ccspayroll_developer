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
                //menuStrip.Items[3].Visible = false;
                usersToolStripMenuItem.Visible = false;
                empSettingsToolStripMenuItem.Visible = false;
            }
        }

        #region Buttons for Prompts
        private void btnPayrollMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            PayrollPrompt payrollPrompt = new PayrollPrompt();
            payrollPrompt.Show();
        }

        private void btnProfileMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            ProfilePrompt profilePrompt = new ProfilePrompt();
            profilePrompt.Show();
        }

        private void btnBillingMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            frmBilling frmBilling = new frmBilling();
            frmBilling.Show();
        }

        private void btnPrintMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            PrintForm frmPrint = new PrintForm();
            frmPrint.Show();
        }
        #endregion

        #region Menu Strips
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.Close();
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
            this.Close();
            Deduction deduction = new Deduction();
            deduction.Show();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeePrintForm employeePrintForm = new EmployeePrintForm();
            employeePrintForm.Show();
        }
        #endregion

        public void OnApplicationExit()
        {
            Application.Exit();
        }

        
    }
}
