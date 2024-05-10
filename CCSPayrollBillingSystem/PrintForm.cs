using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
        }

        private void btnEmployeePrint_Click(object sender, EventArgs e)
        {
            EmployeePrintForm employeePrintForm = new EmployeePrintForm();
            employeePrintForm.InitializeFormPositionConfig();
        }

        private void btnUserPromptUser2_Click(object sender, EventArgs e)
        {
            QueryProcessor projectProcessor = new QueryProcessor();
            int projectNum = projectProcessor.ExecuteSQLCheckCountProjecrtsQuery(
               () =>
               {
                   Console.WriteLine("Projects are added.");
               },
               () =>
               {
                   Console.WriteLine("No projects were added.");
               });
            if(projectNum > 0)
            {
                frmBilling frmBilling = new frmBilling();
                frmBilling.InitializeFormPositionConfig();
            }
            else
            {
                MessageBox.Show("There are no projects found. Please add.", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
