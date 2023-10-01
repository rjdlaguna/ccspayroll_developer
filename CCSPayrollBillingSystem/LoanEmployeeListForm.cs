using System;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class LoanEmployeeListForm : Form
    {

        private string empFname;
        private string empLname;

        LoanForm frmLoanEmployee = new LoanForm();

        QueryProcessor loanProcessor = new QueryProcessor();
        public LoanEmployeeListForm()
        {
            InitializeComponent();
        }

        private void LoanEmployeeListForm_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo(empFname, empLname);
        }

        private void LoadEmployeeInfo(string fname, string lname)
        {
            
            loanProcessor.ExecuteSqlPayrollEmpLoadInfoQuery(fname, lname, () =>
            {
                dgLoanEmployeeList.DataSource = loanProcessor.GetSqlReaderData();
                dgLoanEmployeeList.Columns[0].Visible = false;
                Console.WriteLine("Loading Employee Information successful.");
            }, () =>
            {
                Console.WriteLine("Problem loading employee information.");
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            empFname = txtloanfirstname.Text;
            empLname = txtloanlastname.Text;
            LoadEmployeeInfo(empFname, empLname);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadEmployeeDetailsToLoan();
        }

        private void dgLoanEmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgLoanEmployeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void LoadEmployeeDetailsToLoan()
        {
            frmLoanEmployee.empIdLoan = Convert.ToInt32(dgLoanEmployeeList.SelectedRows[0].Cells[0].Value.ToString());
            frmLoanEmployee.empFnameLoan = dgLoanEmployeeList.SelectedRows[0].Cells[1].Value.ToString();
            frmLoanEmployee.empLnameLoan = dgLoanEmployeeList.SelectedRows[0].Cells[2].Value.ToString();
            this.Close();
            frmLoanEmployee.Show();
        }

        private void dgLoanEmployeeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadEmployeeDetailsToLoan();
        }
    }
}
