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
    public partial class UsersPrompt : Form
    {
        public UsersPrompt()
        {
            InitializeComponent();
        }

        private void btnUserPromptUser1_Click(object sender, EventArgs e)
        {
            UserManagerFormView("user1");
        }

        private void btnUserPromptUser2_Click(object sender, EventArgs e)
        {
            UserManagerFormView("user2");
        }

        private void UserManagerFormView(string user)
        {
            UserManagement userManagement = new UserManagement();
            this.Close();
            userManagement.Show();
        }
    }
}
