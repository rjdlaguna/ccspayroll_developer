using System;
using System.Globalization;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeeUpdatePayroll : Form
    {
        EmployeeListForPayroll employeeListForPayroll = new EmployeeListForPayroll();
        WorkDays _workDays = new WorkDays();
        PayrollData _payrollData = new PayrollData();

        public int empIdPayroll;
        public string empFnamePayroll;
        public string empLnamePayroll;
        public double empRatePayroll;
        public string empRankPayroll;
        private int payrollID;
        private int workDayID;

        private NumberFormatInfo nfi;

        public EmployeeUpdatePayroll()
        {
            InitializeComponent();
        }

        private void GetUIValues()
        {
            //Payroll get to UI Values
            _payrollData.Payroll_ID = payrollID;
            _payrollData.PayrollStartDate = dtPayrollStartDate.Value;
            _payrollData.PayrollEndDate = dtPayrollCutOffDate.Value;
            _payrollData.EmpID = empIdPayroll;
            _payrollData.SSSAmount = Convert.ToDecimal(txtSSS.Text);
            _payrollData.PhilHealthAmount = Convert.ToDecimal(txtPhilHealth.Text);
            _payrollData.PagIbigAmount = Convert.ToDecimal(txtPagIbig.Text);
            _payrollData.Tax = Convert.ToDecimal(txtTax.Text);
            _payrollData.GrossSalary = Convert.ToDecimal(txtGrossPay.Text);
            _payrollData.NetSalary = Convert.ToDecimal(txtNetPay.Text);
            _payrollData.WorkDayID = workDayID;

            //Workdays get to UI Values
            _workDays.WorkDayID = workDayID;
            _workDays.RegularDays = float.Parse(txtRegDays.Text);
            _workDays.RegularDaysOT = float.Parse(txtRegOT.Text);
            _workDays.SplHolidays = float.Parse(txtSplHolidays.Text);
            _workDays.SplHolidayOT = float.Parse(txtSplHolidaysOT.Text);
            _workDays.RegularHoliday = float.Parse(txtRegHolidays.Text);
            _workDays.RegularHolidayOT = float.Parse(txtRegHolidaysOT.Text);
            //_workDays.RegHolRestDay = float.Parse(txtRegHolRestDay.Text);
            _workDays.COLA = float.Parse(txtCOLA.Text);
            _workDays.PDA = float.Parse(txtPDA.Text);
            _workDays.Others = float.Parse(txtOthers.Text);
        }

        private void SetUIValues(PayrollData payroll, WorkDays work)
        {
            //Payroll Data
            payrollID = payroll.Payroll_ID;
            dtPayrollStartDate.Value = payroll.PayrollStartDate;
            dtPayrollCutOffDate.Value = payroll.PayrollEndDate;
            txtSSS.Text = payroll.SSSAmount.ToString();
            txtPhilHealth.Text = payroll.PhilHealthAmount.ToString();
            txtPagIbig.Text = payroll.PagIbigAmount.ToString();
            txtTax.Text = payroll.Tax.ToString();
            txtGrossPay.Text = payroll.GrossSalary.ToString();
            txtNetPay.Text = payroll.NetSalary.ToString();

            //WorkDays data
            workDayID = work.WorkDayID;
            txtRegDays.Text = work.RegularDays.ToString();
            txtRegOT.Text = work.RegularDaysOT.ToString();
            txtSplHolidays.Text = work.SplHolidays.ToString();
            txtSplHolidaysOT.Text = work.SplHolidays.ToString();
            txtRegHolidays.Text = work.RegularHoliday.ToString();
            txtRegHolidaysOT.Text = work.RegularHolidayOT.ToString();
            //txtRegHolRestDay.Text = work.RegHolRestDay.ToString();
            txtCOLA.Text = work.COLA.ToString();
            txtPDA.Text = work.PDA.ToString();
            txtOthers.Text = work.Others.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GetUIValues();
            QueryProcessor payrollUpdateProcessor = new QueryProcessor();

            payrollUpdateProcessor.ExecuteSqlPayrollUpdateQuery(_payrollData, _workDays, () =>
            {
                MessageBox.Show("Updating Employee Payroll information successful.");
            }, () =>
            {
                MessageBox.Show("Problem in Updating Employee Payroll information.");
            });

            ClearControls(this);
            ResetControls(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            QueryProcessor payrollDeleteProcessor = new QueryProcessor();

            payrollDeleteProcessor.ExecuteSqlPayrollDeleteQuery(empIdPayroll, payrollID, workDayID, () =>
            {
                MessageBox.Show("Deleting Employee Payroll information successful.");
                this.Close();
            }, () =>
            {
                MessageBox.Show("Problem in Deleting Employee Payroll information.");
            });


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableControls(this, true);
            ValidationHelper.SingleEnableControls(btnUpdate, true);
            ValidationHelper.SingleEnableControls(btnDelete, true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            employeeListForPayroll.Show();
            ValidationHelper.SingleEnableControls(btnEdit, true);
        }

        private void EmployeeUpdatePayroll_Load(object sender, EventArgs e)
        {
            employeeListForPayroll.OnEmployeeSearchedValues += LoadSearchedEmployeeDetails;
            EnableControls(this, false);
            ValidationHelper.SingleEnableControls(btnUpdate, false);
            ValidationHelper.SingleEnableControls(btnDelete, false);
            ValidationHelper.SingleEnableControls(btnEdit, false);

        }

        private void LoadSearchedEmployeeDetails(Employee emp)
        {
            empIdPayroll = emp.EmpIdPayroll;
            empFnamePayroll = emp.EmpFnamePayroll;
            empLnamePayroll = emp.EmpLnamePayroll;
            empRatePayroll = emp.EmpRatePayroll;
            empRankPayroll = emp.EmpRankPayroll;

            nfi = new CultureInfo("en-PH", false).NumberFormat;
            txtEmployeeName.Text = empFnamePayroll + " " + empLnamePayroll;
            txtBaseRate.Text = empRatePayroll.ToString();
            txtRank.Text = empRankPayroll;

            QueryProcessor payrollSearchProcessor = new QueryProcessor();

            payrollSearchProcessor.ExecuteSqlPayrollSearchQuery(empIdPayroll, (payroll, work) =>
            {
                SetUIValues(payroll, work);

                Console.WriteLine("Loading Employee Payroll Information successful.");
            }, () =>
            {
                Console.WriteLine("Problem loading employee payroll information.");
            });
        }

        private void ClearControls(Control control)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                {
                    ((TextBox)controlItem).Clear();
                }
                if (controlItem is GroupBox)
                {
                    foreach (Control item in controlItem.Controls)
                    {
                        if (controlItem is TextBox)
                        {
                            ((TextBox)controlItem).Clear();
                        }
                    }
                }
            }
        }
        private void ResetControls(Control control)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                {
                    ((TextBox)controlItem).Text = "0";
                }
                if (controlItem is GroupBox)
                {
                    foreach (Control item in controlItem.Controls)
                    {
                        if (controlItem is TextBox)
                        {
                            ((TextBox)controlItem).Text = "0";
                        }
                    }
                }
            }
        }


        private void EnableControls(Control control, bool status)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                {
                    ((TextBox)controlItem).Enabled = status;
                }
                if (controlItem is GroupBox)
                {
                    controlItem.Enabled = status;
                    foreach (Control item in controlItem.Controls)
                    {
                        if (controlItem is TextBox)
                        {
                            ((TextBox)controlItem).Enabled = status;
                        }
                    }
                }
            }
            groupBox1.Enabled = !status;
        }


    }
}
