using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class frmLoan : Form
    {
        private int loanId;
        private string loanDescription;
        private string loanType;
        private decimal loanAmount;

        public int empIdLoan;
        public string empFnameLoan;
        public string empLnameLoan;

        QueryProcessor loanProcessor = new QueryProcessor();

        public frmLoan()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoanForm_Load(object sender, EventArgs e)
        {
            txtLoanEmpName.Text = empLnameLoan + ", " + empFnameLoan;
        }

        private void btnSelectEmployee_Click(object sender, EventArgs e)
        {
            LoanEmployeeListForm frmLoanEmployeeList = new LoanEmployeeListForm();
            this.Close();
            frmLoanEmployeeList.Show();
        }

        private void btnAddLoan_Click(object sender, EventArgs e)
        {
            string promptText = null;
            SetLoanValues();
            promptText = ValidateLoanDataFields();
            txtLoanDataPrompt.Text = promptText;
            if(String.IsNullOrEmpty(promptText))
            {
                txtLoanDataPrompt.Visible = false;
                loanProcessor.ExecuteSQLLoanDataSaveQuery(empIdLoan,loanDescription,loanType,loanAmount, () => 
                {
                    ClearLoanDataFields();
                    MessageBox.Show("Loan data successfully saved.");
                }, () =>
                {
                    MessageBox.Show("Problem saving loan data.");
                });
            }
        }

        private string ValidateLoanDataFields()
        {
            string prompt = "";
            if(empIdLoan == 0 || empIdLoan == null)
            {
                prompt = "Employee should be selected.";
                txtLoanDataPrompt.Visible = true;
                txtLoanEmpName.Focus();
            }
            else if (String.IsNullOrEmpty(loanDescription))
            {
                prompt = "Description cannot be empty.";
                txtLoanDataPrompt.Visible = true;
                txtLoanDescription.Focus();
            }
            else if (String.IsNullOrEmpty(loanType))
            {
                prompt = "Loan type should be selected.";
                txtLoanDataPrompt.Visible = true;
                comboLoanType.Focus();
            }
            else if (loanAmount == null || loanAmount == 0)
            {
                prompt = "Loan amount cannot be empty.";
                txtLoanDataPrompt.Visible = true;
                txtLoanAmount.Focus();
            }

            return prompt;
        }

        private void SetLoanValues()
        {
            loanDescription = txtLoanDescription.Text;
            loanType = comboLoanType.Text;
            loanAmount = Convert.ToDecimal(txtLoanAmount.Text);

        }

        private void ClearLoanDataFields()
        {
            empIdLoan = 0;
            txtLoanEmpName.Clear();
            txtLoanDescription.Clear();
            comboLoanType.Text = "";
            txtLoanAmount.Text = "0.00";
        }
        
    }
}
