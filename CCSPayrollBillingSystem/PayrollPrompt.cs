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
            frmEmployeePayroll frmEmployeePayroll = new frmEmployeePayroll();
            frmEmployeePayroll.Show();
        }

        private void btnPayPromptProject_Click(object sender, EventArgs e)
        {
            frmProjectPayroll frmProjectPayroll = new frmProjectPayroll();
            frmProjectPayroll.Show();
        }
    }
}
