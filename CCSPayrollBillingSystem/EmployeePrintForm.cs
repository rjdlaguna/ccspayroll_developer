using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using CCSPayrollBillingSystem.Scripts;
using System.Reflection;

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
        private string dateFrom;
        private string dateTo;

        EmployeeListForPayroll employeeListForPayroll = new EmployeeListForPayroll();
        EmployeePayrollDate employeePayrollDate = new EmployeePayrollDate();

        PaySlipData _paySlipData = new PaySlipData();

        List<PaySlipData> _paySlipDataListItems = new List<PaySlipData>();
        private void Init(PayrollData payroll, WorkDays work)
        {
            _paySlipData.PayrollData = payroll;
            _paySlipData.WorkDays = work;
        }

        private void EmployeePrintForm_Load(object sender, EventArgs e)
        {
            employeeListForPayroll.OnEmployeeSearchedValues += LoadSearchedEmployeeDetails;
            employeePayrollDate.OnPayrollDateSelected += SetPayrollDates;

            ValidationHelper.SingleEnableControls(btnSearch, false);
            ValidationHelper.SingleEnableControls(btnGenerate, false);
            ValidationHelper.SingleEnableControls(btnPreview, false);
        }

        private void SetPayrollDates(string from, string to)
        {
            dateFrom = from;
            dateTo = to;
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
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.IfNullOrEmpty(cmbPrintFilter))
            {
                MessageBox.Show("Please select proper Print Filter!");
            }
            else if (cmbPrintFilter.SelectedItem.Equals("Single"))
            {
                employeeListForPayroll.ShowDialog();
            }
            else if (cmbPrintFilter.SelectedItem.Equals("All"))
            {
                MessageBox.Show("Print All! \n Please click Generate button to process Document");
            }
            else if (cmbPrintFilter.SelectedItem.Equals("Preview"))
            {
                MessageBox.Show("Printing Preview! \n Please click Generate button to process Document");
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e) //Payslip on solo employee
        {
            
            if (cmbPrintFilter.SelectedItem.Equals("Single"))
            {
                employeePayrollDate.ShowDialog();
                
                QueryProcessor payrollSearchProcessor = new QueryProcessor();

                payrollSearchProcessor.ExecuteSqlPayrollSearchQuery(empIdPayroll, dateFrom, dateTo, (payroll, work) =>
                {
                    Init(payroll, work);
                    GenerateSinglePaySlip();
                }, () =>
                {
                    MessageBox.Show("Problem loading employee payroll information.");
                });
                
            }
            else if (cmbPrintFilter.SelectedItem.Equals("All"))
            {
                employeePayrollDate.ShowDialog();

                QueryProcessor payrollSearchAllProcessor = new QueryProcessor();

                payrollSearchAllProcessor.ExecuteSqlPayrollAllSearchQuery(dateFrom, dateTo, (payslipListFromQuery) =>
                {
                    _paySlipDataListItems = payslipListFromQuery;
                    GenerateAllPaySlip();
                }, () =>
                {
                    MessageBox.Show("Problem loading All employee payroll information.");
                });
            }else if (cmbPrintFilter.SelectedItem.Equals("Preview"))
            {
                
            }

        }

        private void GenerateSinglePaySlip()
        {
            payrolSlipText = string.Empty;

            payrolSlipText += "-------------------------------------------------------------------------------------\n";
            payrolSlipText += "-----                                CCS Payslip                       -----\n";
            payrolSlipText += "-------------------------------------------------------------------------------------\n";
            payrolSlipText += "Payroll Date: " + dateFrom + " to " + dateTo + "\n";
            payrolSlipText += "Name: " + empLnamePayroll + ", " + empFnamePayroll + "\n";
            payrolSlipText += "Project: \n\n";

            payrolSlipText += "Regular Days\t: \t" + _paySlipData.WorkDays.RegularDays + "\t" + (WorkDaysComputation.RegularDays(empRatePayroll, _paySlipData.WorkDays.RegularDays).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Regular OT\t: \t" + _paySlipData.WorkDays.RegularDaysOT + "\t" + (WorkDaysComputation.RegularDaysOT(empRatePayroll, _paySlipData.WorkDays.RegularDaysOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Sp Hol Sun\t: \t" + _paySlipData.WorkDays.SplHolidays + "\t" + (WorkDaysComputation.SunOrSpecialHolidays(empRatePayroll, _paySlipData.WorkDays.SplHolidays).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Sp Hol OT\t: \t" + _paySlipData.WorkDays.SplHolidayOT + "\t" + (WorkDaysComputation.SpecialHolidaysOT(empRatePayroll, _paySlipData.WorkDays.SplHolidayOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Regular Holiday\t: \t" + _paySlipData.WorkDays.RegularHoliday + "\t" + (WorkDaysComputation.RegularHolidays(empRatePayroll, _paySlipData.WorkDays.RegularHoliday).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Reg Hol OT\t: \t" + _paySlipData.WorkDays.RegularHolidayOT + "\t" + (WorkDaysComputation.RegularHolidaysOT(empRatePayroll, _paySlipData.WorkDays.RegularHolidayOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Reg Hol Rest Day\t: \t" + _paySlipData.WorkDays.RegHolRestDay + "\t" + (WorkDaysComputation.RestDayAndRegularHolidays(empRatePayroll, _paySlipData.WorkDays.RegHolRestDay).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "COLA\t: \t\t" + _paySlipData.WorkDays.COLA + "\t" + (WorkDaysComputation.COLA(decimal.Parse(_paySlipData.WorkDays.COLA.ToString()))).ToPhpCurrencyFormat() + "\n";
            payrolSlipText += "PDA\t: \t\t" + _paySlipData.WorkDays.PDA + "\t" + WorkDaysComputation.PDA(decimal.Parse(_paySlipData.WorkDays.PDA.ToString())).ToPhpCurrencyFormat() + "\n";
            payrolSlipText += "Others\t: \t\t" + _paySlipData.WorkDays.Others + "\t" + (WorkDaysComputation.Others(decimal.Parse(_paySlipData.WorkDays.Others.ToString())).ToPhpCurrencyFormat()) + "\n\n";
            payrolSlipText += "GROSS PAY\t: " + (_paySlipData.PayrollData.GrossSalary).ToPhpCurrencyFormat() + "\n\n";
            payrolSlipText += "Less: \n";
            payrolSlipText += "  SSS/MED\t: " + _paySlipData.PayrollData.SSSAmount + "\n";
            payrolSlipText += "  PagIbig\t\t: " + _paySlipData.PayrollData.PagIbigAmount + "\n";
            payrolSlipText += "  PhilHealth\t: " + _paySlipData.PayrollData.PhilHealthAmount + "\n";
            payrolSlipText += "  Others\t\t: " + _paySlipData.PayrollData.PayrollOthers + "\n\n";
            payrolSlipText += "NET PAY\t\t: " + (_paySlipData.PayrollData.NetSalary).ToPhpCurrencyFormat() + "\n\n";
            payrolSlipText += "I certify that I have received the above amount.\n";

            rtbPayrollSlip.Text = payrolSlipText;
        }

        private void GenerateAllPaySlip() //Generate all payslips of the employees
        {
            payrolSlipText = string.Empty;

            foreach (PaySlipData paySlipData in _paySlipDataListItems)
            {
                payrolSlipText += "-------------------------------------------------------------------------------------\n";
                payrolSlipText += "-----                                CCS Payslip                       -----\n";
                payrolSlipText += "-------------------------------------------------------------------------------------\n";
                payrolSlipText += "Payroll Date: " + dateFrom + " to " + dateTo + "\n";
                payrolSlipText += "Name: " + paySlipData.Employee.EmpLastName + ", " + paySlipData.Employee.EmpFirstName + " " + paySlipData.Employee.EmpMiddleName + " \n";
                payrolSlipText += "Project: \n\n";

                payrolSlipText += "Regular Days\t: \t" + paySlipData.WorkDays.RegularDays + "\t" + (WorkDaysComputation.RegularDays(paySlipData.PayRate, paySlipData.WorkDays.RegularDays).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Regular OT\t: \t" + paySlipData.WorkDays.RegularDaysOT + "\t" + (WorkDaysComputation.RegularDaysOT(paySlipData.PayRate, paySlipData.WorkDays.RegularDaysOT).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Sp Hol Sun\t: \t" + paySlipData.WorkDays.SplHolidays + "\t" + (WorkDaysComputation.SunOrSpecialHolidays(paySlipData.PayRate, paySlipData.WorkDays.SplHolidays).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Sp Hol OT\t: \t" + paySlipData.WorkDays.SplHolidayOT + "\t" + (WorkDaysComputation.SpecialHolidaysOT(paySlipData.PayRate, paySlipData.WorkDays.SplHolidayOT).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Regular Holiday\t: \t" + paySlipData.WorkDays.RegularHoliday + "\t" + (WorkDaysComputation.RegularHolidays(paySlipData.PayRate, paySlipData.WorkDays.RegularHoliday).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Reg Hol OT\t: \t" + paySlipData.WorkDays.RegularHolidayOT + "\t" + (WorkDaysComputation.RegularHolidaysOT(paySlipData.PayRate, paySlipData.WorkDays.RegularHolidayOT).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Reg Hol Rest Day\t: \t" + paySlipData.WorkDays.RegHolRestDay + "\t" + (WorkDaysComputation.RestDayAndRegularHolidays(paySlipData.PayRate, paySlipData.WorkDays.RegHolRestDay).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "COLA\t: \t\t" + paySlipData.WorkDays.COLA + "\t" + (WorkDaysComputation.COLA(decimal.Parse(paySlipData.WorkDays.COLA.ToString()))).ToPhpCurrencyFormat() + "\n";
                payrolSlipText += "PDA\t: \t\t" + paySlipData.WorkDays.PDA + "\t" + WorkDaysComputation.PDA(decimal.Parse(paySlipData.WorkDays.PDA.ToString())).ToPhpCurrencyFormat() + "\n";
                payrolSlipText += "Others\t: \t\t" + paySlipData.WorkDays.Others + "\t" + (WorkDaysComputation.Others(decimal.Parse(paySlipData.WorkDays.Others.ToString())).ToPhpCurrencyFormat()) + "\n\n";
                payrolSlipText += "GROSS PAY\t: " + (paySlipData.PayrollData.GrossSalary).ToPhpCurrencyFormat() + "\n\n";
                payrolSlipText += "Less: \n";
                payrolSlipText += "  SSS/MED\t: " + paySlipData.PayrollData.SSSAmount + "\n";
                payrolSlipText += "  PagIbig\t\t: " + paySlipData.PayrollData.PagIbigAmount + "\n";
                payrolSlipText += "  PhilHealth\t: " + paySlipData.PayrollData.PhilHealthAmount + "\n";
                payrolSlipText += "  Others\t\t: " + paySlipData.PayrollData.PayrollOthers + "\n\n";
                payrolSlipText += "NET PAY\t\t: " + (paySlipData.PayrollData.NetSalary).ToPhpCurrencyFormat() + "\n\n";
                payrolSlipText += "I certify that I have received the above amount.\n";
                payrolSlipText += "-------------------------------------------------------------------------------------\n";


            }

            PaySlipDisplay(payrolSlipText);
        }

        private void GeneratePreview() //Generate all payslips of the employees
        {
            payrolSlipText = string.Empty;

            payrolSlipText += "CCS - Manpower & Allied Services \n";
            payrolSlipText += "1251 Miranda Street, Sto. Rosario, Angeles City \n\n";
            payrolSlipText += "Payroll Preview \n\n";
            payrolSlipText += "Payroll for the period: " + dateFrom + " to " + dateTo + "\n";
            payrolSlipText += "----------------------------------------------------------------------------------------------------\n";
            payrolSlipText += "EMPLOYEE NAME                Hrs/Days                Amount  \n";
            payrolSlipText += "----------------------------------------------------------------------------------------------------\n";
            foreach (PaySlipData paySlipData in _paySlipDataListItems)
            {
                payrolSlipText += "Name: " + paySlipData.Employee.EmpLastName + ", " + paySlipData.Employee.EmpFirstName + " \n";
                foreach (var property in typeof(WorkDays).GetProperties())
                {
                    float temp = 0f;
                    if (property.PropertyType == typeof(float) && (property.Name != "WorkDayID"))
                    {
                        temp = (float)property.GetValue(paySlipData.WorkDays);
                        if (temp == 0)
                        {
                            continue;
                        }
                        payrolSlipText += property.Name + "\t: \t" + temp + "\t\t" + WorkDaysComputation.BillingRateState(property.Name, paySlipData.PayRate, temp).ToPhpCurrencyFormat() + "\n";
                    }
                }
                payrolSlipText += "----------------------------------------------------------------------------------------------------\n";


            }

            PaySlipDisplay(payrolSlipText);
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

        private void PaySlipDisplay(string payslipText)
        {
            rtbPayrollSlip.Text += payslipText +"\t"; 
            rtbPayrollSlip.SelectAll();
            rtbPayrollSlip.SelectionTabs = new int[] { 50};
            rtbPayrollSlip.AcceptsTab = true;
            rtbPayrollSlip.Select(0, 0);
        }

        private void cmbPrintFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrintFilter.Text.Equals("Single"))
            {
                ValidationHelper.SingleEnableControls(btnSearch, true);
                ValidationHelper.SingleEnableControls(btnGenerate, true);
                ValidationHelper.SingleEnableControls(btnPreview, false);
            }
            else if(cmbPrintFilter.Text.Equals("All")){
                ValidationHelper.SingleEnableControls(btnSearch, false);
                ValidationHelper.SingleEnableControls(btnGenerate, true);
                ValidationHelper.SingleEnableControls(btnPreview, false);
            }
            else
            {
                ValidationHelper.SingleEnableControls(btnSearch, false);
                ValidationHelper.SingleEnableControls(btnGenerate, false);
                ValidationHelper.SingleEnableControls(btnPreview, true);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            employeePayrollDate.ShowDialog();

            QueryProcessor payrollSearchAllProcessor = new QueryProcessor();

            payrollSearchAllProcessor.ExecuteSqlPayrollAllSearchQuery(dateFrom, dateTo, (payslipListFromQuery) =>
            {
                _paySlipDataListItems = payslipListFromQuery;
                GeneratePreview();
            }, () =>
            {
                MessageBox.Show("Problem loading All employee payroll information.");
            });
        }
    }
}
