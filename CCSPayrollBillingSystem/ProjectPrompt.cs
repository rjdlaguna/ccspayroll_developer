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
    public partial class ProjectPrompt : Form
    {
        public ProjectPrompt()
        {
            InitializeComponent();
        }

        private void btnAddEmployeePrompt_Click(object sender, EventArgs e)
        {
            ProjectProfileForm frmProjectProfile = new ProjectProfileForm();
            frmProjectProfile.StartPosition = FormStartPosition.CenterScreen;
            frmProjectProfile.ShowDialog();
        }

        private void btnUpdateEmployeePrompt_Click(object sender, EventArgs e)
        {
            ProjectProfileList frmProjectProfileList = new ProjectProfileList();
            frmProjectProfileList.ShowDialog();
        }
    }
}
