using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSPayrollBillingSystem.Scripts.SystemUtility
{
    public class PaySlipGenerator
    {
        private string payrolSlipText;
        private List<string> paySlip2WordDocumentList = new List<string>();

        public void GeneratePaySlips(List<PaySlipData> paySlipDataListItems, string dateFrom, string dateTo, string empLnamePayroll = "", string empFnamePayroll = "", string projectName = "", WorkDays workDays = null, decimal empRatePayroll = 0, PayrollData payrollData = null)
        {
            if (paySlipDataListItems == null || paySlipDataListItems.Count == 0) return;
            
            InitializePaySlipContent();

            if (paySlipDataListItems.Count == 1)
            {
                GenerateSinglePaySlip(dateFrom, dateTo, empLnamePayroll, empFnamePayroll, projectName, workDays, empRatePayroll, payrollData);
            }
            else
            {
                foreach (PaySlipData paySlipData in paySlipDataListItems)
                {
                    GenerateSinglePaySlip(dateFrom, dateTo, paySlipData.Employee.EmpLastName, paySlipData.Employee.EmpFirstName, paySlipData.ProjectName, paySlipData.WorkDays, paySlipData.PayRate, paySlipData.PayrollData);
                    AppendPaySlipSeparator();
                }
            }
        }

        private void InitializePaySlipContent()
        {
            paySlip2WordDocumentList.Clear();
            payrolSlipText = string.Empty;
        }

        private void GenerateSinglePaySlip(string dateFrom, string dateTo, string empLnamePayroll, string empFnamePayroll, string projectName, WorkDays workDays, decimal empRatePayroll, PayrollData payrollData, string empMnamePayroll = "")
        {
            AppendPaySlipHeader(dateFrom, dateTo, empLnamePayroll, empFnamePayroll, empMnamePayroll, projectName);
            AppendPaySlipDetails(workDays, empRatePayroll, payrollData);
        }

        private void AppendPaySlipHeader(string dateFrom, string dateTo, string lastName, string firstName, string middleName, string projectName)
        {
            payrolSlipText += "-----------------------------------------------------------------------------------\n";
            payrolSlipText += "                                            CCS Payslip                              \n";
            payrolSlipText += "-----------------------------------------------------------------------------------\n";
            payrolSlipText += "Payroll Date: " + dateFrom + " to " + dateTo + "\n";
            payrolSlipText += "Name: " + lastName + ", " + firstName + " " + middleName + "\n";
            payrolSlipText += "Project: " + projectName + "\n\n";
        }

        private void AppendPaySlipDetails(WorkDays workDays, decimal empRatePayroll, PayrollData payrollData)
        {
            payrolSlipText += "Regular Days\t: \t" + workDays.RegularDays + "\t" + (WorkDaysComputation.RegularDays(empRatePayroll, workDays.RegularDays).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Regular OT\t: \t" + workDays.RegularDaysOT + "\t" + (WorkDaysComputation.RegularDaysOT(empRatePayroll, workDays.RegularDaysOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Sp Hol Sun\t: \t" + workDays.SplHolidays + "\t" + (WorkDaysComputation.SunOrSpecialHolidays(empRatePayroll, workDays.SplHolidays).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Sp Hol OT\t: \t" + workDays.SplHolidayOT + "\t" + (WorkDaysComputation.SpecialHolidaysOT(empRatePayroll, workDays.SplHolidayOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Regular Holiday\t: \t" + workDays.RegularHoliday + "\t" + (WorkDaysComputation.RegularHolidays(empRatePayroll, workDays.RegularHoliday).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Reg Hol OT\t: \t" + workDays.RegularHolidayOT + "\t" + (WorkDaysComputation.RegularHolidaysOT(empRatePayroll, workDays.RegularHolidayOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Reg Hol Rest Day\t: \t" + workDays.RegHolRestDay + "\t" + (WorkDaysComputation.RestDayAndRegularHolidays(empRatePayroll, workDays.RegHolRestDay).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "COLA\t: \t\t" + workDays.COLA + "\t" + (WorkDaysComputation.COLA(decimal.Parse(workDays.COLA.ToString()))).ToPhpCurrencyFormat() + "\n";
            payrolSlipText += "PDA\t: \t\t" + workDays.PDA + "\t" + WorkDaysComputation.PDA(decimal.Parse(workDays.PDA.ToString())).ToPhpCurrencyFormat() + "\n";
            payrolSlipText += "Others\t: \t\t" + workDays.Others + "\t" + (WorkDaysComputation.Others(decimal.Parse(workDays.Others.ToString())).ToPhpCurrencyFormat()) + "\n\n";
            payrolSlipText += "GROSS PAY\t: " + (payrollData.GrossSalary).ToPhpCurrencyFormat() + "\n\n";
            payrolSlipText += "Less: \n";
            payrolSlipText += "  SSS/MED\t: " + payrollData.SSSAmount + "\n";
            payrolSlipText += "  PagIbig\t\t: " + payrollData.PagIbigAmount + "\n";
            payrolSlipText += "  PhilHealth\t: " + payrollData.PhilHealthAmount + "\n";
            payrolSlipText += "  Others\t\t: " + payrollData.PayrollOthers + "\n\n";
            payrolSlipText += "NET PAY\t\t: " + (payrollData.NetSalary).ToPhpCurrencyFormat() + "\n\n";
            payrolSlipText += "I certify that I have received the above amount.\n";
        }

        private void AppendPaySlipSeparator()
        {
            payrolSlipText += "-----------------------------------------------------------------------------------\n";
        }


    }
}
