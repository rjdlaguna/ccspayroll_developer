using System;
using System.Globalization;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;
using CCSPayrollBillingSystem.Scripts.Data;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeeUpdatePayroll : Form
    {
        EmployeeListForPayroll employeeListForPayroll = new EmployeeListForPayroll();
        WorkDays _workDays = new WorkDays();
        PayrollData _payrollData = new PayrollData();

        private decimal deductions;
        private decimal gross;
        private decimal net;

        private decimal _RegDaysRate;
        private decimal _RegOTRate;
        private decimal _SplHolidaysRate;
        private decimal _SplHolidaysOTRate;
        private decimal _RegHolidaysRate;
        private decimal _RegHolidaysOTRate;
        private decimal _RegHolRestDayRate;
        private decimal _COLARate;
        private decimal _PDARate;
        private decimal _OthersRate;

        public int empIdPayroll;
        public string empFnamePayroll;
        public string empLnamePayroll;
        public decimal empRatePayroll;
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
            _payrollData.PayrollOthers = Convert.ToDecimal(txtPayrollOthers.Text);
            
            
            _payrollData.GrossSalary = gross;
            _payrollData.NetSalary = net;
            _payrollData.WorkDayID = workDayID;

            //Workdays get to UI Values
            _workDays.WorkDayID = workDayID;
            _workDays.RegularDays = float.Parse(txtRegDays.Text);
            _workDays.RegularDaysOT = float.Parse(txtRegOT.Text);
            _workDays.SplHolidays = float.Parse(txtSplHolidays.Text);
            _workDays.SplHolidayOT = float.Parse(txtSplHolidaysOT.Text);
            _workDays.RegularHoliday = float.Parse(txtRegHolidays.Text);
            _workDays.RegularHolidayOT = float.Parse(txtRegHolidaysOT.Text);
            _workDays.RegHolRestDay = float.Parse(txtRegHolRestDay.Text);
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
            txtPayrollOthers.Text = payroll.PayrollOthers.ToString();
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
            txtRegHolRestDay.Text = work.RegHolRestDay.ToString();
            txtCOLA.Text = work.COLA.ToString();
            txtPDA.Text = work.PDA.ToString();
            txtOthers.Text = work.Others.ToString();
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

            //ClearControls(this);
            ValidationHelper.ResetControls(this);
            ValidationHelper.EnableControls(this, false);

            ValidationHelper.SingleEnableControls(btnUpdate, false);
            ValidationHelper.SingleEnableControls(btnDelete, false);
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

            ValidationHelper.SingleEnableControls(btnUpdate, false);
            ValidationHelper.SingleEnableControls(btnDelete, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            QueryProcessor payrollSearchProcessor = new QueryProcessor();
            DateTime dtFrom = dtPayrollStartDate.Value;
            DateTime dtTo = dtPayrollCutOffDate.Value;

            payrollSearchProcessor.ExecuteSqlPayrollSearchQuery(empIdPayroll, dtFrom.ToShortDateString(), dtTo.ToShortDateString(), (payroll, work) =>
            {
                SetUIValues(payroll, work);

                Console.WriteLine("Loading Employee Payroll Information successful.");
            }, () =>
            {
                Console.WriteLine("Problem loading employee payroll information.");
            });

            ValidationHelper.EnableControls(this, true);
            ValidationHelper.SingleEnableControls(btnUpdate, true);
            ValidationHelper.SingleEnableControls(btnCalculate, true);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            employeeListForPayroll.ShowDialog();
            ValidationHelper.SingleEnableControls(gbPayrollDate, true);
            ValidationHelper.SingleEnableControls(btnEdit, true);
            
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            gross = _RegDaysRate + _RegOTRate + _SplHolidaysRate + _SplHolidaysOTRate + _RegHolidaysRate + _RegHolidaysOTRate + _RegHolRestDayRate + _COLARate + _PDARate + _OthersRate;
            deductions = Convert.ToDecimal(txtSSS.Text) + Convert.ToDecimal(txtPhilHealth.Text) + Convert.ToDecimal(txtPagIbig.Text) + Convert.ToDecimal(txtPayrollOthers.Text);
            net = gross - deductions;
            txtGrossPay.Text = gross.ToString("C", nfi);
            txtNetPay.Text = net.ToString("C", nfi);

            ValidationHelper.SingleEnableControls(btnUpdate, true);
            ValidationHelper.SingleEnableControls(btnDelete, true);
        }

        private void EmployeeUpdatePayroll_Load(object sender, EventArgs e)
        {
            employeeListForPayroll.OnEmployeeSearchedValues += LoadSearchedEmployeeDetails;
            ValidationHelper.EnableControls(this, false);
            ValidationHelper.SingleEnableControls(btnUpdate, false);
            ValidationHelper.SingleEnableControls(btnDelete, false);
            ValidationHelper.SingleEnableControls(btnEdit, false);
            ValidationHelper.SingleEnableControls(btnCalculate, false);

        }

        private void txtRegDays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegDays.Text)) txtRegDays.Text = "0";
            _RegDaysRate = WorkDaysComputation.RegularDays(empRatePayroll, float.Parse(txtRegDays.Text));
            txtRegDaysRate.Text = _RegDaysRate.ToString("C", nfi);
        }

        private void txtRegOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegOT.Text)) txtRegOT.Text = "0";
            _RegOTRate = WorkDaysComputation.RegularDaysOT(empRatePayroll, float.Parse(txtRegOT.Text));
            txtRegOTRate.Text = _RegOTRate.ToString("C", nfi);
        }

        private void txtSplHolidays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSplHolidays.Text)) txtSplHolidays.Text = "0";
            _SplHolidaysRate = WorkDaysComputation.SunOrSpecialHolidays(empRatePayroll, float.Parse(txtSplHolidays.Text));
            txtSplHolidaysRate.Text = _SplHolidaysRate.ToString("C", nfi);
        }

        private void txtSplHolidaysOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSplHolidaysOT.Text)) txtSplHolidaysOT.Text = "0";
            _SplHolidaysOTRate = WorkDaysComputation.SpecialHolidaysOT(empRatePayroll, float.Parse(txtSplHolidaysOT.Text));
            txtSplHolidaysOTRate.Text = _SplHolidaysOTRate.ToString("C", nfi);
        }

        private void txtRegHolidays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegHolidays.Text)) txtRegHolidays.Text = "0";
            _RegHolidaysRate = WorkDaysComputation.RegularHolidays(empRatePayroll, float.Parse(txtRegHolidays.Text));
            txtRegHolidaysRate.Text = _RegHolidaysRate.ToString("C", nfi);
        }

        private void txtRegHolidaysOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegHolidaysOT.Text)) txtRegHolidaysOT.Text = "0";
            _RegHolidaysOTRate = WorkDaysComputation.RegularHolidaysOT(empRatePayroll, float.Parse(txtRegHolidaysOT.Text));
            txtRegHolidaysOTRate.Text = _RegHolidaysOTRate.ToString("C", nfi);
        }

        private void txtRegHolRestDay_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegHolRestDay.Text)) txtRegHolRestDay.Text = "0";
            _RegHolRestDayRate = WorkDaysComputation.RestDayAndRegularHolidays(empRatePayroll, float.Parse(txtRegHolRestDay.Text));
            txtRegHolRestDayRate.Text = _RegHolRestDayRate.ToString("C", nfi);
        }

        private void txtCOLA_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCOLA.Text)) txtCOLA.Text = "0";
            _COLARate = WorkDaysComputation.COLA(decimal.Parse(txtCOLA.Text));
            txtCOLARate.Text = _COLARate.ToString("C", nfi);
        }

        private void txtPDA_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPDA.Text)) txtPDA.Text = "0";
            _PDARate = WorkDaysComputation.PDA(decimal.Parse(txtPDA.Text));
            txtPDARate.Text = _PDARate.ToString("C", nfi);
        }

        private void txtOthers_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOthers.Text)) txtOthers.Text = "0";
            _OthersRate = WorkDaysComputation.Others(decimal.Parse(txtOthers.Text));
            txtOthersRate.Text = _OthersRate.ToString("C", nfi);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
