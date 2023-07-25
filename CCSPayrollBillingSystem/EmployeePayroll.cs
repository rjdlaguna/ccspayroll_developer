using System;
using System.Globalization;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{

    public partial class frmEmployeePayroll : Form
    {
        private decimal baseRate;
        private decimal deductions;
        private decimal gross;
        private decimal net;
        private decimal vat;

        private decimal _RegDaysRate;
        private decimal _RegOTRate;
        private decimal _SplHolidaysRate;
        private decimal _SplHolidaysOTRate;
        private decimal _RegHolidaysRate;
        private decimal _RegHolidaysOTRate;
        private decimal _COLARate;
        private decimal _PDARate;
        private decimal _OthersRate;

        private NumberFormatInfo nfi;

        public void Init(decimal baseRate)
        {
            this.baseRate = baseRate;

            txtRegDaysRate.Text = Constants.DEFAULT_VALUE;
            txtRegOTRate.Text = Constants.DEFAULT_VALUE;
            txtSplHolidaysRate.Text = Constants.DEFAULT_VALUE;
            txtSplHolidaysOTRate.Text = Constants.DEFAULT_VALUE;
            txtRegHolidaysRate.Text = Constants.DEFAULT_VALUE;
            txtRegHolidaysOTRate.Text = Constants.DEFAULT_VALUE;
            txtCOLARate.Text = Constants.DEFAULT_VALUE;
            txtPDARate.Text = Constants.DEFAULT_VALUE;
            txtOthersRate.Text = Constants.DEFAULT_VALUE;
        }

        public frmEmployeePayroll()
        {
            InitializeComponent();
        }

        private void frmEmployeePayroll_Load(object sender, EventArgs e)
        {
            nfi = new CultureInfo("en-PH", false).NumberFormat;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Init(450);//initial testing 
            EmployeeListForPayroll frmEmployeeListPayroll = new EmployeeListForPayroll();
            frmEmployeeListPayroll.Show();
        }

        private void txtRegDays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegDays.Text)) txtRegDays.Text = "0";
            _RegDaysRate = WorkDaysComputation.RegularDays(baseRate, float.Parse(txtRegDays.Text));
            txtRegDaysRate.Text = _RegDaysRate.ToString("C", nfi);
            
        }

        private void txtRegOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegOT.Text)) txtRegOT.Text = "0";
            _RegOTRate = WorkDaysComputation.RegularDaysOT(baseRate, float.Parse(txtRegOT.Text));
            txtRegOTRate.Text = _RegOTRate.ToString("C", nfi);
        }

        private void txtSplHolidays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSplHolidays.Text)) txtSplHolidays.Text = "0";
            _SplHolidaysRate = WorkDaysComputation.SunOrSpecialHolidays(baseRate, float.Parse(txtSplHolidays.Text));
            txtSplHolidaysRate.Text = _SplHolidaysRate.ToString("C", nfi);
        }

        private void txtSplHolidaysOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSplHolidaysOT.Text)) txtSplHolidaysOT.Text = "0";
            _SplHolidaysOTRate = WorkDaysComputation.SpecialHolidaysOT(baseRate, float.Parse(txtSplHolidaysOT.Text));
            txtSplHolidaysOTRate.Text = _SplHolidaysOTRate.ToString("C", nfi);
        }

        private void txtRegHolidays_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegHolidays.Text)) txtRegHolidays.Text = "0";
            _RegHolidaysRate = WorkDaysComputation.RestDayOrRegularHolidays(baseRate, float.Parse(txtRegHolidays.Text));
            txtRegHolidaysRate.Text = _RegHolidaysRate.ToString("C", nfi);
        }

        private void txtRegHolidaysOT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegHolidaysOT.Text)) txtRegHolidaysOT.Text = "0";
            _RegHolidaysOTRate = WorkDaysComputation.RegularHolidaysOT(baseRate, float.Parse(txtRegHolidaysOT.Text));
            txtRegHolidaysOTRate.Text = _RegHolidaysOTRate.ToString("C", nfi);
        }

        private void txtCOLA_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCOLA.Text)) txtCOLA.Text = "0";
            _COLARate = WorkDaysComputation.COLA(baseRate, float.Parse(txtCOLA.Text));
            txtCOLARate.Text = _COLARate.ToString("C", nfi);
        }

        private void txtPDA_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPDA.Text)) txtPDA.Text = "0";
            _PDARate = WorkDaysComputation.PDA(baseRate, float.Parse(txtPDA.Text));
            txtPDARate.Text = _PDARate.ToString("C", nfi);
        }

        private void txtOthers_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOthers.Text)) txtOthers.Text = "0";
            _OthersRate = WorkDaysComputation.Others(baseRate, float.Parse(txtOthers.Text));
            txtOthersRate.Text = _OthersRate.ToString("C", nfi);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            gross = _RegDaysRate + _RegOTRate + _SplHolidaysRate + _SplHolidaysOTRate + _RegHolidaysRate + _RegHolidaysOTRate + _COLARate + _PDARate + _OthersRate;
            deductions = decimal.Parse(txtSSS.Text) + decimal.Parse(txtPhilHealth.Text) + decimal.Parse(txtPagIbig.Text) + decimal.Parse(txtTax.Text);
            //vat = decimal.Parse();
            txtGrossPay.Text = gross.ToString("C", nfi);
            txtNetPay.Text = (gross - deductions).ToString("C", nfi);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
