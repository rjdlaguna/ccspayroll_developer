using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class ChangePassword : Form
    {
        private string user;
        public ChangePassword(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (ValidateInput())
            {
                QueryProcessor loginProcessor = new QueryProcessor();
                loginProcessor.ExecuteSqlSearchChangePasswordQuery(user, currentPassword, newPassword, confirmPassword, () =>
                {
                    // Successful Update action
                    MessageBox.Show("Password Changed!", "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    
                    FormMain formMain = new FormMain();
                    this.Hide();
                    formMain.Show();
                }, () =>
                {
                    // Failed Update action
                    MessageBox.Show("Transaction Unsuccessful!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            else
            {
                MessageBox.Show("Please Fill the Required Fields Correctly!");
            }
        }

        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(txtCurrentPassword.Text) && !string.IsNullOrEmpty(txtNewPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text);
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtCurrentPassword.PasswordChar = '*';
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }
    }
}
