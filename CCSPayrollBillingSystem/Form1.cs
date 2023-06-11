using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCSPayrollBillingSystem
{
    public partial class FormMain : Form
    {
        private const string ADMIN = "admin";
        private string userLogged;
        public FormMain(string user)
        {
            InitializeComponent();
            //EventManager.OnAdminLogged += OnUserLoggedIdentifier;
            userLogged = user;
        }

        //private void OnUserLoggedIdentifier(string user)
        //{
        //    //userLogged = user;
        //    toolStripStatusLabelMainView.Text = userLogged;
        //}

        private void FormMain_Load(object sender, EventArgs e)
        {
            //statusStripMain.Items[0].Text = userLogged;
            toolStripStatusLabelMainView.Text = userLogged + "logged!";
            if (userLogged != ADMIN) { menuStrip.Items[3].Visible = false; }
        }

        #region Buttons...
        private void btnPayrollMenu_Click(object sender, EventArgs e)
        {
            PayrollPrompt payrollPrompt = new PayrollPrompt();
            payrollPrompt.Show();
        }

        private void btnProfileMenu_Click(object sender, EventArgs e)
        {
            ProfilePrompt profilePrompt = new ProfilePrompt();
            profilePrompt.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersPrompt usersPrompt = new UsersPrompt();
            usersPrompt.Show();
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
        #endregion

        #region Menu Strips
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            formLogin formLogin = new formLogin();
            formLogin.Show();
        }
        #endregion

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ChangePassword changePassword = new ChangePassword(userLogged);
            changePassword.Show();
        }
    }
}
