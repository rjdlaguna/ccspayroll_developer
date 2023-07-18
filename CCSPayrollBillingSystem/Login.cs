using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            
            if (ValidateInput())
            {
                lblloginprompt.Hide();
                QueryProcessor loginProcessor = new QueryProcessor();
                loginProcessor.ExecuteSqlLoginQuery(username, password, () =>
                {
                    // Successful login action
                    SessionManager.LoggedInUser = username;

                    FormMain formMain = new FormMain();
                    this.Hide();
                    formMain.Show();
                }, () =>
                {
                    // Failed login action
                    MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            else
            {
                lblloginprompt.Show();
                if(string.IsNullOrEmpty(txtUsername.Text))
                {
                    txtUsername.Focus();
                } 
                else
                {
                    txtPassword.Focus();
                }
                lblloginprompt.Text = "Please fill in the username and password.";
            }

        }
        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            lblloginprompt.Hide();
        }
    }
}

