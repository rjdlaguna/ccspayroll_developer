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
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {

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
