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
    public partial class ProfilePrompt : Form
    {
        public ProfilePrompt()
        {
            InitializeComponent();
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
    }
}
