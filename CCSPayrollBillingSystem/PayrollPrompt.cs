using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class PayrollPrompt : Form
    {
        public PayrollPrompt()
        {
            InitializeComponent();
        }

        private void btnPayPromptEmployee_Click(object sender, EventArgs e)
        {
            QueryProcessor jobProcessor = new QueryProcessor();
            int jobCount = jobProcessor.ExecuteSQLCountJobsQuery(() =>
           {
               Console.WriteLine("There are jobs in the table.");
           }, () =>
           {
               Console.WriteLine("There are no jobs in the table.");
           });
            if(jobCount == 0)
            {
                MessageBox.Show("No Jobs added. Please add first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
                frmEmployeePayroll employeePayroll = new frmEmployeePayroll();
                employeePayroll.StartPosition = FormStartPosition.CenterScreen;
                employeePayroll.ShowDialog();
            }
            
        }

        private void btnPayPromptProject_Click(object sender, EventArgs e)
        {
            QueryProcessor jobProcessor = new QueryProcessor();
            int jobCount = jobProcessor.ExecuteSQLCountJobsQuery(() =>
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
                this.Close();
                EmployeeUpdatePayroll employeeUpdatePayroll = new EmployeeUpdatePayroll();
                employeeUpdatePayroll.StartPosition = FormStartPosition.CenterScreen;
                employeeUpdatePayroll.ShowDialog();
            }
            
        }
    }
}
