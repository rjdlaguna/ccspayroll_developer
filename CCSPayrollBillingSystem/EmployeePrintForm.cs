using System;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeePrintForm : Form
    {
        public EmployeePrintForm()
        {
            InitializeComponent();
        }

        private string employee;
        private decimal gross;
        private decimal net;

        private NumberFormatInfo nfi;
        private void Init()
        {
            nfi = new CultureInfo("en-PH", false).NumberFormat;
            employee = txtEmployee.Text;
            gross = decimal.Parse(txtGrossPay.Text);
            net = decimal.Parse(txtNetPay.Text);
        }

        private string RTBBoldSelection()
        {
            return string.Empty;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbPayrollSlip.Clear();
            
            Init();
            
            rtbPayrollSlip.Text += "----------------------------------------------\n";
            rtbPayrollSlip.Text += "-----          CCS Payslip          -----\n";
            rtbPayrollSlip.Text += "----------------------------------------------\n";
            rtbPayrollSlip.Text += "From: "+ DateTime.Now +"\n";
            rtbPayrollSlip.Text += "Name: "+ employee +"\n";
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
            rtbPayrollSlip.Text += "GROSS PAY: "+ gross.ToString("C", nfi) + "\n\n";
            rtbPayrollSlip.Text += "Less: \n";
            rtbPayrollSlip.Text += "\tSSS/MED: \n";
            rtbPayrollSlip.Text += "\tPhilHealth: \n";
            rtbPayrollSlip.Text += "\tOthers: \n\n";
            rtbPayrollSlip.Text += "NET PAY: "+ net.ToString("C", nfi) + "\n\n";
            rtbPayrollSlip.Text += "I certify that I have received the above amount.\n";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtbPayrollSlip.Text, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }
    }
}
