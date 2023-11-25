using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{

    public partial class frmEmployeePayroll : Form
    {
        private int workDayID;
        private decimal baseRate;
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

        EmployeeListForPayroll employeeListForPayroll = new EmployeeListForPayroll();

        public void Init(decimal baseRate)
        {
            this.baseRate = baseRate;

            TextDefautValue();
        }

        public frmEmployeePayroll()
        {
            InitializeComponent();
        }

        private void TextDefautValue()
        {
            txtRegDaysRate.Text = Constants.DEFAULT_VALUE;
            txtRegOTRate.Text = Constants.DEFAULT_VALUE;
            txtSplHolidaysRate.Text = Constants.DEFAULT_VALUE;
            txtSplHolidaysOTRate.Text = Constants.DEFAULT_VALUE;
            txtRegHolidaysRate.Text = Constants.DEFAULT_VALUE;
            txtRegHolidaysOTRate.Text = Constants.DEFAULT_VALUE;
            txtCOLARate.Text = Constants.DEFAULT_VALUE;
            txtPDARate.Text = Constants.DEFAULT_VALUE;
            txtOthersRate.Text = Constants.DEFAULT_VALUE;
            txtBaseRate.Text = baseRate.ToString();
        }

        private void frmEmployeePayroll_Load(object sender, EventArgs e)
        {
            employeeListForPayroll.OnEmployeeSearchedValues += LoadSearchedEmployeeDetails;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            employeeListForPayroll.ShowDialog();
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

        private void txtRegDays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegDays.Text)) txtRegDays.Text = "0";
            _RegDaysRate = WorkDaysComputation.RegularDays(baseRate, float.Parse(txtRegDays.Text));
            txtRegDaysRate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_RegDaysRate);
            
        }

        private void txtRegOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegOT.Text)) txtRegOT.Text = "0";
            _RegOTRate = WorkDaysComputation.RegularDaysOT(baseRate, float.Parse(txtRegOT.Text));
            txtRegOTRate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_RegOTRate);
        }

        private void txtSplHolidays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSplHolidays.Text)) txtSplHolidays.Text = "0";
            _SplHolidaysRate = WorkDaysComputation.SunOrSpecialHolidays(baseRate, float.Parse(txtSplHolidays.Text));
            txtSplHolidaysRate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_SplHolidaysRate);
        }

        private void txtSplHolidaysOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSplHolidaysOT.Text)) txtSplHolidaysOT.Text = "0";
            _SplHolidaysOTRate = WorkDaysComputation.SpecialHolidaysOT(baseRate, float.Parse(txtSplHolidaysOT.Text));
            txtSplHolidaysOTRate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_SplHolidaysOTRate);
        }

        private void txtRegHolidays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegHolidays.Text)) txtRegHolidays.Text = "0";
            _RegHolidaysRate = WorkDaysComputation.RegularHolidays(baseRate, float.Parse(txtRegHolidays.Text));
            txtRegHolidaysRate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_RegHolidaysRate);
        }

        private void txtRegHolidaysOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegHolidaysOT.Text)) txtRegHolidaysOT.Text = "0";
            _RegHolidaysOTRate = WorkDaysComputation.RegularHolidaysOT(baseRate, float.Parse(txtRegHolidaysOT.Text));
            txtRegHolidaysOTRate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_RegHolidaysOTRate);
        }

        

        private void txtBaseRate_TextChanged(object sender, EventArgs e)
        {
            Init(Convert.ToDecimal(empRatePayroll));
        }

        private void txtRegHolRestDay_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegHolRestDay.Text)) txtRegHolRestDay.Text = "0";
            _RegHolRestDayRate = WorkDaysComputation.RestDayAndRegularHolidays(baseRate, float.Parse(txtRegHolRestDay.Text));
            txtRegHolRestDayRate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_RegHolRestDayRate);
        }

        private void txtCOLA_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCOLA.Text)) txtCOLA.Text = "0";
            _COLARate = WorkDaysComputation.COLA(decimal.Parse(txtCOLA.Text));
            txtCOLARate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_COLARate);
        }

        private void txtPDA_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPDA.Text)) txtPDA.Text = "0";
            _PDARate = WorkDaysComputation.PDA(decimal.Parse(txtPDA.Text));
            txtPDARate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_PDARate);
        }

        private void txtOthers_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOthers.Text)) txtOthers.Text = "0";
            _OthersRate = WorkDaysComputation.Others(decimal.Parse(txtOthers.Text));
            txtOthersRate.Text = CurrencyFormatter.ToPhpCurrencyFormat(_OthersRate);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            gross = _RegDaysRate + _RegOTRate + _SplHolidaysRate + _SplHolidaysOTRate + _RegHolidaysRate + _RegHolidaysOTRate + _RegHolRestDayRate + _COLARate + _PDARate + _OthersRate;
            deductions = Convert.ToDecimal(txtSSS.Text) + Convert.ToDecimal(txtPhilHealth.Text) + Convert.ToDecimal(txtPagIbig.Text) + Convert.ToDecimal(txtPayrollOthers.Text);
            net = gross - deductions;
            txtGrossPay.Text = CurrencyFormatter.ToPhpCurrencyFormat(gross);
            txtNetPay.Text = CurrencyFormatter.ToPhpCurrencyFormat(net);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IfNullOrEmpty(txtGrossPay) && !ValidationHelper.IfNullOrEmpty(txtNetPay))
            {
                QueryProcessor payrollWDProcessor = new QueryProcessor();

                payrollWDProcessor.ExecuteSqlWorkDaysValidationQuery((int iD) =>
                {
                    workDayID = iD;
                    Console.WriteLine("Loading WorkDayID Information successful.");
                }, () =>
                {
                    Console.WriteLine("Problem loading WorkDays information.");
                });

                PayrollData payroll = SetPayrollData();
                WorkDays work = SetWorkDaysData();

                payrollWDProcessor.ExecuteSqlPayrollSaveQuery(payroll, work, () =>
                {
                    ValidationHelper.ClearControls(this);
                    ValidationHelper.EnableControls(this, false);
                    MessageBox.Show("Saving Payroll Information successful.");
                }, () =>
                {
                    MessageBox.Show("Problem saving Payroll information.");
                });
            }

        }


        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnEdit_Click(object sender, EventArgs e) => ValidationHelper.EnableControls(this, true);

        private PayrollData SetPayrollData()
        {
            PayrollData payrollData = new PayrollData();

            payrollData.PayrollStartDate = dtPayrollStartDate.Value;
            payrollData.PayrollEndDate = dtPayrollStartDate.Value;
            payrollData.EmpID = empIdPayroll;
            payrollData.SSSAmount = Convert.ToDecimal(txtSSS.Text);
            payrollData.PagIbigAmount = Convert.ToDecimal(txtPhilHealth.Text);
            payrollData.PhilHealthAmount = Convert.ToDecimal(txtPagIbig.Text);
            payrollData.GrossSalary = gross;
            payrollData.NetSalary = net;
            payrollData.WorkDayID = workDayID + 1;
            payrollData.PayrollOthers = Convert.ToDecimal(txtPayrollOthers.Text);

            return payrollData;
        }

        private WorkDays SetWorkDaysData()
        {
            WorkDays workDays = new WorkDays();

            workDays.WorkDayID = workDayID + 1;
            workDays.RegularDays = float.Parse(txtRegDays.Text);
            workDays.RegularDaysOT = float.Parse(txtRegOT.Text);
            workDays.SplHolidays = float.Parse(txtSplHolidays.Text);
            workDays.SplHolidayOT = float.Parse(txtSplHolidaysOT.Text);
            workDays.RegularHoliday = float.Parse(txtRegHolidays.Text);
            workDays.RegularHolidayOT = float.Parse(txtRegHolidaysOT.Text);
            workDays.COLA = float.Parse(txtCOLA.Text);
            workDays.PDA = float.Parse(txtPDA.Text);
            workDays.Others = float.Parse(txtOthers.Text);

            return workDays;
        }


    }
}
