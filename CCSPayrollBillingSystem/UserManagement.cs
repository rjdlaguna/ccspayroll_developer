using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class UserManagement : Form
    {
        private string user;
        public UserManagement(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            toolStripStatusLabelView.Text = user+" - logged";
            txtUsernameView.Text = user;
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUsernameView.Text;
            int empID = Int32.Parse(txtEmpID.Text);

            if (ValidateInput())
            {
                QueryProcessor loginProcessor = new QueryProcessor();
                loginProcessor.ExecuteSqlSearchChangeUsersQuery(username, empID, () =>
                {
                    // Successful Change User action
                    MessageBox.Show("Password Changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormMain formMain = new FormMain();
                    this.Close();
                    formMain.Show();
                }, () =>
                {
                    // Failed Change User action
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
            return !string.IsNullOrEmpty(txtUsernameView.Text) && !string.IsNullOrEmpty(txtEmpID.Text);
        }
    }
}
