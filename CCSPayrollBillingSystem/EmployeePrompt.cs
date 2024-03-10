using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeePrompt : Form
    {
        public EmployeePrompt()
        {
            InitializeComponent();
        }

        private void btnAddEmployeePrompt_Click(object sender, EventArgs e)
        {
            QueryProcessor empDataProcessor = new QueryProcessor();
            int jobCount = empDataProcessor.ExecuteSQLCountJobsQuery(() =>
            {
                Console.WriteLine("There are jobs in the table.");
            }, () =>
            {
                Console.WriteLine("There are no jobs in the table.");
            });
            if (jobCount == 0)
            {
                MessageBox.Show("No Jobs added. Please add first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EmployeeProfileForm frmEmployeeProfile = new EmployeeProfileForm();
                frmEmployeeProfile.StartPosition = FormStartPosition.CenterScreen;
                frmEmployeeProfile.ShowDialog();
            }

        }

        private void btnUpdateEmployeePrompt_Click(object sender, EventArgs e)
        {
            EmployeeListForm frmEmpList = new EmployeeListForm();
            frmEmpList.StartPosition = FormStartPosition.CenterScreen;
            frmEmpList.ShowDialog();
        }
    }
}
