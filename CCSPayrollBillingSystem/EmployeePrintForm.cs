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
    public partial class EmployeePrintForm : Form
    {
        public EmployeePrintForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbPayrollSlip.Clear();

            rtbPayrollSlip.Text += "-----------------------------------------\n";
            rtbPayrollSlip.Text += "-----          CCS Payslip          -----\n";
            rtbPayrollSlip.Text += "-----------------------------------------\n";
            rtbPayrollSlip.Text += "From: \n";
            rtbPayrollSlip.Text += "Name: \n";
            rtbPayrollSlip.Text += "Project: \n";

            rtbPayrollSlip.Text += "Regular Days: \n";
            rtbPayrollSlip.Text += "Regular OT: \n";
            rtbPayrollSlip.Text += "Sp Hol Sun: \n";
            rtbPayrollSlip.Text += "Sp Hol OT: \n";
            rtbPayrollSlip.Text += "Reg Hol: \n";
            rtbPayrollSlip.Text += "Reg Hol OT: \n";
            rtbPayrollSlip.Text += "Reg Hol Rest Day: \n";
            rtbPayrollSlip.Text += "COLA: \n";
            rtbPayrollSlip.Text += "PDA: \n";
            rtbPayrollSlip.Text += "Others: \n";
            rtbPayrollSlip.Text += "GROSS PAY: \n\n";
            rtbPayrollSlip.Text += "Less: \n";
            rtbPayrollSlip.Text += "\tSSS/MED: \n";
            rtbPayrollSlip.Text += "\tPhilHealth: \n";
            rtbPayrollSlip.Text += "\tOthers: \n\n";
            rtbPayrollSlip.Text += "NET PAY: \n\n";
            rtbPayrollSlip.Text += "I certify that I have received the above amount.\n";

        }
    }
}
