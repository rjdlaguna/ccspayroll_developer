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
        public FormMain()
        {
            InitializeComponent();
        }

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
    }
}
