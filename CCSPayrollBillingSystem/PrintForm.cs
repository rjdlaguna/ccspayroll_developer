using System;
using System.Windows.Forms;

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
            employeePrintForm.Show();
        }

        private void btnUserPromptUser2_Click(object sender, EventArgs e)
        {
            frmBilling frmBilling = new frmBilling();
            frmBilling.Show();
        }
    }
}
