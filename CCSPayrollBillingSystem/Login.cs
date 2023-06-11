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
                QueryProcessor loginProcessor = new QueryProcessor();
                loginProcessor.ExecuteSqlLoginQuery(username, password, () =>
                {
                    // Successful login action
                    FormMain formMain = new FormMain(username);
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
                MessageBox.Show("Please Fill the Required Fields Correctly!");
            }

        }
        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }

    }
}

