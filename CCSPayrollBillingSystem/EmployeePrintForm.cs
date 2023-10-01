using System;
using System.Windows.Forms;
using System.Drawing;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeePrintForm : Form
    {
        public EmployeePrintForm()
        {
            InitializeComponent();
        }

        public int empIdPayroll;
        public string empFnamePayroll;
        public string empLnamePayroll;
        public decimal empRatePayroll;
        public string empRankPayroll;

        EmployeeListForPayroll employeeListForPayroll = new EmployeeListForPayroll();
        PaySlipData _paySlipData = new PaySlipData();
        private void Init(PayrollData payroll, WorkDays work)
        {
            _paySlipData.PayrollData = payroll;
            _paySlipData.WorkDays = work;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbPayrollSlip.Clear();
            
            rtbPayrollSlip.Text += "-------------------------------------------------------------------------------------\n";
            rtbPayrollSlip.Text += "-----                                CCS Payslip                       -----\n";
            rtbPayrollSlip.Text += "-------------------------------------------------------------------------------------\n";
            rtbPayrollSlip.Text += "From: "+ DateTime.Now +"\n";
            rtbPayrollSlip.Text += "Name: "+ empLnamePayroll+ ", "+ empFnamePayroll +"\n";
            rtbPayrollSlip.Text += "Project: \n\n";

            rtbPayrollSlip.Text += "Regular Days\t: \t" + _paySlipData.WorkDays.RegularDays+"\t"+ CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.RegularDays(empRatePayroll, _paySlipData.WorkDays.RegularDays)) + "\n";
            rtbPayrollSlip.Text += "Regular OT\t: \t" + _paySlipData.WorkDays.RegularDaysOT+ "\t" + CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.RegularDaysOT(empRatePayroll, _paySlipData.WorkDays.RegularDaysOT)) + "\n";
            rtbPayrollSlip.Text += "Sp Hol Sun\t: \t" + _paySlipData.WorkDays.SplHolidays + "\t" + CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.SunOrSpecialHolidays(empRatePayroll, _paySlipData.WorkDays.SplHolidays)) + "\n";
            rtbPayrollSlip.Text += "Sp Hol OT\t: \t" + _paySlipData.WorkDays.SplHolidayOT + "\t" + CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.SpecialHolidaysOT(empRatePayroll, _paySlipData.WorkDays.SplHolidayOT)) +"\n";
            rtbPayrollSlip.Text += "Regular Holiday\t: \t" + _paySlipData.WorkDays.RegularHoliday + "\t" + CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.RegularHolidays(empRatePayroll, _paySlipData.WorkDays.RegularHoliday)) + "\n";
            rtbPayrollSlip.Text += "Reg Hol OT\t: \t" + _paySlipData.WorkDays.RegularHolidayOT + "\t" + CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.RegularHolidaysOT(empRatePayroll, _paySlipData.WorkDays.RegularHolidayOT)) + "\n";
            rtbPayrollSlip.Text += "Reg Hol Rest Day\t: \t" + _paySlipData.WorkDays.RegHolRestDay + "\t" + CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.RestDayAndRegularHolidays(empRatePayroll, _paySlipData.WorkDays.RegHolRestDay)) + "\n";
            rtbPayrollSlip.Text += "COLA\t: \t\t" + _paySlipData.WorkDays.COLA + "\t" + CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.COLA(decimal.Parse(_paySlipData.WorkDays.COLA.ToString()))) + "\n";
            rtbPayrollSlip.Text += "PDA\t: \t\t" + _paySlipData.WorkDays.PDA + "\t" + WorkDaysComputation.PDA(decimal.Parse(_paySlipData.WorkDays.PDA.ToString())) + "\n";
            rtbPayrollSlip.Text += "Others\t: \t\t" + _paySlipData.WorkDays.Others + "\t" + CurrencyFormatter.ToCurrencyFormat(WorkDaysComputation.Others(decimal.Parse(_paySlipData.WorkDays.Others.ToString()))) + "\n\n";
            rtbPayrollSlip.Text += "GROSS PAY\t: "+ CurrencyFormatter.ToCurrencyFormat(_paySlipData.PayrollData.GrossSalary) +"\n\n";
            rtbPayrollSlip.Text += "Less: \n";
            rtbPayrollSlip.Text += "  SSS/MED\t: "+_paySlipData.PayrollData.SSSAmount+"\n";
            rtbPayrollSlip.Text += "  PagIbig\t\t: "+_paySlipData.PayrollData.PagIbigAmount+"\n";
            rtbPayrollSlip.Text += "  PhilHealth\t: "+_paySlipData.PayrollData.PhilHealthAmount+"\n";
            rtbPayrollSlip.Text += "  Others\t\t: "+ _paySlipData.PayrollData.PayrollOthers + "\n\n";
            rtbPayrollSlip.Text += "NET PAY\t\t: "+ CurrencyFormatter.ToCurrencyFormat(_paySlipData.PayrollData.NetSalary) + "\n\n";
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

        private void EmployeePrintForm_Load(object sender, EventArgs e)
        {
            employeeListForPayroll.OnEmployeeSearchedValues += LoadSearchedEmployeeDetails;
        }

        private void LoadSearchedEmployeeDetails(Employee emp)
        {
            empIdPayroll = emp.EmpIdPayroll;
            empFnamePayroll = emp.EmpFnamePayroll;
            empLnamePayroll = emp.EmpLnamePayroll;
            empRatePayroll = emp.EmpRatePayroll;
            empRankPayroll = emp.EmpRankPayroll;

            txtEmployeeName.Text = empFnamePayroll + " " + empLnamePayroll;
            txtBaseRate.Text = empRatePayroll.ToString();
            txtRank.Text = empRankPayroll;

            QueryProcessor payrollSearchProcessor = new QueryProcessor();

            payrollSearchProcessor.ExecuteSqlPayrollSearchQuery(empIdPayroll, (payroll, work) =>
            {
                Init(payroll, work);

            }, () =>
            {
                MessageBox.Show("Problem loading employee payroll information.");
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            employeeListForPayroll.ShowDialog();
        }
    }
}
