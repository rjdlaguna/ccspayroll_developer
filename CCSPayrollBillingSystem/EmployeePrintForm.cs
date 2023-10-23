using System;
using System.Collections.Generic;
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

        private string payrolSlipText;

        EmployeeListForPayroll employeeListForPayroll = new EmployeeListForPayroll();
        PaySlipData _paySlipData = new PaySlipData();

        List<PaySlipData> _paySlipDataListItems = new List<PaySlipData>();
        private void Init(PayrollData payroll, WorkDays work)
        {
            _paySlipData.PayrollData = payroll;
            _paySlipData.WorkDays = work;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            payrolSlipText = string.Empty;

            payrolSlipText += "-------------------------------------------------------------------------------------\n";
            payrolSlipText += "-----                                CCS Payslip                       -----\n";
            payrolSlipText += "-------------------------------------------------------------------------------------\n";
            payrolSlipText += "From: " + _paySlipData.PayrollData.PayrollEndDate + "\n";
            payrolSlipText += "Name: " + empLnamePayroll + ", " + empFnamePayroll + "\n";
            payrolSlipText += "Project: \n\n";

            payrolSlipText += "Regular Days\t: \t" + _paySlipData.WorkDays.RegularDays + "\t" + (WorkDaysComputation.RegularDays(empRatePayroll, _paySlipData.WorkDays.RegularDays).ToCurrencyFormat()) + "\n";
            payrolSlipText += "Regular OT\t: \t" + _paySlipData.WorkDays.RegularDaysOT + "\t" + (WorkDaysComputation.RegularDaysOT(empRatePayroll, _paySlipData.WorkDays.RegularDaysOT).ToCurrencyFormat()) + "\n";
            payrolSlipText += "Sp Hol Sun\t: \t" + _paySlipData.WorkDays.SplHolidays + "\t" + (WorkDaysComputation.SunOrSpecialHolidays(empRatePayroll, _paySlipData.WorkDays.SplHolidays).ToCurrencyFormat()) + "\n";
            payrolSlipText += "Sp Hol OT\t: \t" + _paySlipData.WorkDays.SplHolidayOT + "\t" + (WorkDaysComputation.SpecialHolidaysOT(empRatePayroll, _paySlipData.WorkDays.SplHolidayOT).ToCurrencyFormat()) + "\n";
            payrolSlipText += "Regular Holiday\t: \t" + _paySlipData.WorkDays.RegularHoliday + "\t" + (WorkDaysComputation.RegularHolidays(empRatePayroll, _paySlipData.WorkDays.RegularHoliday).ToCurrencyFormat()) + "\n";
            payrolSlipText += "Reg Hol OT\t: \t" + _paySlipData.WorkDays.RegularHolidayOT + "\t" + (WorkDaysComputation.RegularHolidaysOT(empRatePayroll, _paySlipData.WorkDays.RegularHolidayOT).ToCurrencyFormat()) + "\n";
            payrolSlipText += "Reg Hol Rest Day\t: \t" + _paySlipData.WorkDays.RegHolRestDay + "\t" + (WorkDaysComputation.RestDayAndRegularHolidays(empRatePayroll, _paySlipData.WorkDays.RegHolRestDay).ToCurrencyFormat()) + "\n";
            payrolSlipText += "COLA\t: \t\t" + _paySlipData.WorkDays.COLA + "\t" + (WorkDaysComputation.COLA(decimal.Parse(_paySlipData.WorkDays.COLA.ToString()))).ToCurrencyFormat() + "\n";
            payrolSlipText += "PDA\t: \t\t" + _paySlipData.WorkDays.PDA + "\t" + WorkDaysComputation.PDA(decimal.Parse(_paySlipData.WorkDays.PDA.ToString())).ToCurrencyFormat() + "\n";
            payrolSlipText += "Others\t: \t\t" + _paySlipData.WorkDays.Others + "\t" + (WorkDaysComputation.Others(decimal.Parse(_paySlipData.WorkDays.Others.ToString())).ToCurrencyFormat()) + "\n\n";
            payrolSlipText += "GROSS PAY\t: " + (_paySlipData.PayrollData.GrossSalary).ToCurrencyFormat() + "\n\n";
            payrolSlipText += "Less: \n";
            payrolSlipText += "  SSS/MED\t: " + _paySlipData.PayrollData.SSSAmount + "\n";
            payrolSlipText += "  PagIbig\t\t: " + _paySlipData.PayrollData.PagIbigAmount + "\n";
            payrolSlipText += "  PhilHealth\t: " + _paySlipData.PayrollData.PhilHealthAmount + "\n";
            payrolSlipText += "  Others\t\t: " + _paySlipData.PayrollData.PayrollOthers + "\n\n";
            payrolSlipText += "NET PAY\t\t: " + (_paySlipData.PayrollData.NetSalary).ToCurrencyFormat() + "\n\n";
            payrolSlipText += "I certify that I have received the above amount.\n";

            rtbPayrollSlip.Text = payrolSlipText;
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
            ValidationHelper.SingleEnableControls(btnSearch, false);
            ValidationHelper.SingleEnableControls(btnGenerate, false);
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
            if (ValidationHelper.IfNullOrEmpty(cmbPrintFilter) || cmbPrintFilter.SelectedItem.Equals("None"))
            {
                MessageBox.Show("Please select proper Print Filter!");
            }
            else if (cmbPrintFilter.SelectedItem.Equals("Single"))
            {
                employeeListForPayroll.ShowDialog();
            }
            else
            {
                MessageBox.Show("Print All!");

                QueryProcessor payrollSearchAllProcessor = new QueryProcessor();

                payrollSearchAllProcessor.ExecuteSqlPayrollAllSearchQuery((payslipListFromQuery) =>
                {
                    _paySlipDataListItems = payslipListFromQuery;
                    GenerateAllPaySlip();
                }, () =>
                {
                    MessageBox.Show("Problem loading All employee payroll information.");
                });
            }
            
        }

        private void GenerateAllPaySlip() //Generate all payslips of the employees
        {
            payrolSlipText = string.Empty;

            foreach (PaySlipData paySlipData in _paySlipDataListItems)
            {
                payrolSlipText += "-------------------------------------------------------------------------------------\n";
                payrolSlipText += "-----                                CCS Payslip                       -----\n";
                payrolSlipText += "-------------------------------------------------------------------------------------\n";
                payrolSlipText += "From: " + paySlipData.PayrollData.PayrollEndDate + "\n";
                payrolSlipText += "Name: " + paySlipData.Employee.EmpLastName + ", "+ paySlipData.Employee.EmpFirstName + " "+ paySlipData.Employee.EmpMiddleName + " \n";
                payrolSlipText += "Project: \n\n";

                payrolSlipText += "Regular Days\t: \t" + paySlipData.WorkDays.RegularDays + "\t" + (WorkDaysComputation.RegularDays(empRatePayroll, paySlipData.WorkDays.RegularDays).ToCurrencyFormat()) + "\n";
                payrolSlipText += "Regular OT\t: \t" + paySlipData.WorkDays.RegularDaysOT + "\t" + (WorkDaysComputation.RegularDaysOT(empRatePayroll, paySlipData.WorkDays.RegularDaysOT).ToCurrencyFormat()) + "\n";
                payrolSlipText += "Sp Hol Sun\t: \t" + paySlipData.WorkDays.SplHolidays + "\t" + (WorkDaysComputation.SunOrSpecialHolidays(empRatePayroll, paySlipData.WorkDays.SplHolidays).ToCurrencyFormat()) + "\n";
                payrolSlipText += "Sp Hol OT\t: \t" + paySlipData.WorkDays.SplHolidayOT + "\t" + (WorkDaysComputation.SpecialHolidaysOT(empRatePayroll, paySlipData.WorkDays.SplHolidayOT).ToCurrencyFormat()) + "\n";
                payrolSlipText += "Regular Holiday\t: \t" + paySlipData.WorkDays.RegularHoliday + "\t" + (WorkDaysComputation.RegularHolidays(empRatePayroll, paySlipData.WorkDays.RegularHoliday).ToCurrencyFormat()) + "\n";
                payrolSlipText += "Reg Hol OT\t: \t" + paySlipData.WorkDays.RegularHolidayOT + "\t" + (WorkDaysComputation.RegularHolidaysOT(empRatePayroll, paySlipData.WorkDays.RegularHolidayOT).ToCurrencyFormat()) + "\n";
                payrolSlipText += "Reg Hol Rest Day\t: \t" + paySlipData.WorkDays.RegHolRestDay + "\t" + (WorkDaysComputation.RestDayAndRegularHolidays(empRatePayroll, paySlipData.WorkDays.RegHolRestDay).ToCurrencyFormat()) + "\n";
                payrolSlipText += "COLA\t: \t\t" + paySlipData.WorkDays.COLA + "\t" + (WorkDaysComputation.COLA(decimal.Parse(paySlipData.WorkDays.COLA.ToString()))).ToCurrencyFormat() + "\n";
                payrolSlipText += "PDA\t: \t\t" + paySlipData.WorkDays.PDA + "\t" + WorkDaysComputation.PDA(decimal.Parse(paySlipData.WorkDays.PDA.ToString())).ToCurrencyFormat() + "\n";
                payrolSlipText += "Others\t: \t\t" + paySlipData.WorkDays.Others + "\t" + (WorkDaysComputation.Others(decimal.Parse(paySlipData.WorkDays.Others.ToString())).ToCurrencyFormat()) + "\n\n";
                payrolSlipText += "GROSS PAY\t: " + (paySlipData.PayrollData.GrossSalary).ToCurrencyFormat() + "\n\n";
                payrolSlipText += "Less: \n";
                payrolSlipText += "  SSS/MED\t: " + paySlipData.PayrollData.SSSAmount + "\n";
                payrolSlipText += "  PagIbig\t\t: " + paySlipData.PayrollData.PagIbigAmount + "\n";
                payrolSlipText += "  PhilHealth\t: " + paySlipData.PayrollData.PhilHealthAmount + "\n";
                payrolSlipText += "  Others\t\t: " + paySlipData.PayrollData.PayrollOthers + "\n\n";
                payrolSlipText += "NET PAY\t\t: " + (paySlipData.PayrollData.NetSalary).ToCurrencyFormat() + "\n\n";
                payrolSlipText += "I certify that I have received the above amount.\n";
                payrolSlipText += "-------------------------------------------------------------------------------------\n";
            }
            
            rtbPayrollSlip.Text = payrolSlipText;
        }

        private void cmbPrintFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrintFilter.Text.Equals("Single") || !ValidationHelper.IfNullOrEmpty(cmbPrintFilter))
            {
                ValidationHelper.SingleEnableControls(btnSearch, true);
                ValidationHelper.SingleEnableControls(btnGenerate, true);
            }
        }
    }
}
