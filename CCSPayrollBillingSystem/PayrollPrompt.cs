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
    public partial class PayrollPrompt : Form
    {
        public PayrollPrompt()
        {
            InitializeComponent();
        }

        private void btnPayPromptEmployee_Click(object sender, EventArgs e)
        {
            this.Close();
            frmEmployeePayroll employeePayroll = new frmEmployeePayroll();
            employeePayroll.Show();
        }

        private void btnPayPromptProject_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeUpdatePayroll employeeUpdatePayroll = new EmployeeUpdatePayroll();
            employeeUpdatePayroll.Show();
        }
    }
}
