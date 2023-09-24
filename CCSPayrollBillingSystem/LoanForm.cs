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
    public partial class LoanForm : Form
    {
        private int loanId;
        private string loanDescription;
        private string loanType;
        private decimal loanAmount;
        private int payrollId;

        private decimal amountToPay;
        private decimal amountPaid;
        private decimal remBalance;

        public int empIdLoan;
        public string empFnameLoan;
        public string empLnameLoan;

        QueryProcessor loanProcessor = new QueryProcessor();

        public LoanForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoanForm_Load(object sender, EventArgs e)
        {
            txtLoanEmpName.Text = empLnameLoan + ", " + empFnameLoan;
            loanProcessor.ExecuteSQLLoanDataViewQuery(empIdLoan, () =>
            {
                dgEmployeeLoanList.DataSource = loanProcessor.GetSqlReaderData();
                dgEmployeeLoanList.Columns[0].Visible = false;
                dgEmployeeLoanList.Columns[1].Visible = false;
                dgEmployeeLoanList.Columns[8].Visible = false;
                Console.WriteLine("Employee loan details successfully loaded.");
            }, () =>
            {
                Console.WriteLine("Problem loading employee loan details.");
            });

            grpLoanPayment.Enabled = false;
            btnPayLoan.Enabled = false;

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
            if (String.IsNullOrEmpty(promptText))
            {
                txtLoanDataPrompt.Visible = false;
                loanProcessor.ExecuteSQLLoanDataSaveQuery(empIdLoan, loanDescription, loanType, loanAmount, () =>
                   {
                       ClearLoanDataFields();
                       MessageBox.Show("Loan data successfully saved.");
                       ResetLoanListFields();
                       loanProcessor.ExecuteSQLLoanDataViewQuery(empIdLoan, () =>
                       {
                           dgEmployeeLoanList.DataSource = loanProcessor.GetSqlReaderData();
                           Console.WriteLine("Employee loan details successfully loaded.");
                       }, () =>
                       {
                           Console.WriteLine("Problem loading employee loan details.");
                       });
                   }, () =>
                   {
                       MessageBox.Show("Problem saving loan data.");
                   });
            }
        }

        private string ValidateLoanDataFields()
        {
            string prompt = "";
            if (empIdLoan == 0 || empIdLoan == null)
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
            else if (String.IsNullOrEmpty(loanType) || comboLoanType.Text == "Select")
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

        private void btnPayLoan_Click(object sender, EventArgs e)
        {
            grpLoanPayment.Enabled = true;
            loanProcessor.ExecuteSQLLoanPaymentDataViewQuery(loanId, () =>
            {
                dgLoanEmployeePaymentList.DataSource = loanProcessor.GetSqlReaderData();
                Console.WriteLine("Loan payment list successfully loaded.");
            }, () =>
            {
                Console.WriteLine("Problem loading loan payment list.");
            });

            int count = 0;
            while (count < dgEmployeeLoanList.Rows.Count)
            {
                if (dgEmployeeLoanList.Rows[count].Selected)
                {
                    if(Convert.ToInt32(dgEmployeeLoanList.Rows[count].Cells[8].Value) == 1)
                    {
                        MessageBox.Show("This loan is already paid. Select another loan.");
                        grpLoanPayment.Enabled = false;
                        btnPayLoan.Enabled = false;
                        dgLoanEmployeePaymentList.DataSource = null;
                        dgEmployeeLoanList.Focus();
                    }
                    
                }
                count++;
            }

        }

        private void dgEmployeeLoanList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgEmployeeLoanList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(empIdLoan > 0 || empIdLoan != null)
            {
                btnPayLoan.Enabled = true;
            }

            
            loanId = Convert.ToInt32(dgEmployeeLoanList.SelectedRows[0].Cells[0].Value);
            empIdLoan = Convert.ToInt32(dgEmployeeLoanList.SelectedRows[0].Cells[1].Value);
            loanAmount = Convert.ToDecimal(dgEmployeeLoanList.SelectedRows[0].Cells[6].Value);

        }

        private void btnSaveLoanPayment_Click(object sender, EventArgs e)
        {
            amountToPay = Convert.ToDecimal(txtLoanAmountToPay.Text);
            DateTime startDate = dtLoanPayrollStartDate.Value;
            DateTime endDate = dtLoanPayrollCutoffDate.Value;

            if (loanAmount - (amountPaid+amountToPay) < 0)
            {
                MessageBox.Show("This payment will be more than the remaining balance. Please double-check amount entered.");
            }
            else
            {
                loanProcessor.ExecuteSQLLoanPaymentAdd(loanId, payrollId, amountToPay, startDate, endDate, amountPaid, remBalance, () =>
                {
                    Console.WriteLine("Loan payment successfully added.");
                    loanProcessor.ExecuteSQLLoanPaymentDataViewQuery(loanId, () =>
                    {
                        dgLoanEmployeePaymentList.DataSource = loanProcessor.GetSqlReaderData();
                        Console.WriteLine("Loan payment list successfully loaded.");
                    }, () =>
                    {
                        Console.WriteLine("Problem loading loan payment list.");
                    });
                    ResetLoanPaymentFields();

                }, () =>
                {
                    Console.WriteLine("Problem adding loan payment.");
                });

                if (loanAmount - amountPaid == 0)
                {
                    loanProcessor.ExecuteSqlLoanIsPaidUpdateQuery(loanId, () =>
                    {
                        Console.WriteLine("Loan successfully marked paid.");

                    }, () =>
                    {
                        Console.WriteLine("Problem updating loan is paid.");
                    });
                }
            }
           
        }

        private void txtLoanAmountPaid_TextChanged(object sender, EventArgs e)
        {
            DateTime startDate = dtLoanPayrollStartDate.Value;
            DateTime endDate = dtLoanPayrollCutoffDate.Value;
            payrollId = loanProcessor.ExecuteSQLGetPayrollIDByPayrollDates(startDate, endDate, () =>
             {
                 Console.WriteLine("Payroll ID successfully retrieved.");
             }, () =>
             {
                 Console.WriteLine("Problem retrieving Payroll ID.");
             });
        }

        private void dtLoanPayrollCutoffDate_ValueChanged(object sender, EventArgs e)
        {
            amountPaid = GetTotalAmountPaidForLoan();


            remBalance = loanAmount - amountPaid; 

            txtLoanAmountPaid.Text = amountPaid.ToString();
            txtLoanRemainingAmount.Text = remBalance.ToString();

            DateTime startDate = dtLoanPayrollStartDate.Value;
            DateTime endDate = dtLoanPayrollCutoffDate.Value;
            payrollId = loanProcessor.ExecuteSQLGetPayrollIDByPayrollDates(startDate, endDate, () =>
            {
                Console.WriteLine("Payroll ID successfully retrieved.");
            }, () =>
            {
                Console.WriteLine("Problem retrieving Payroll ID.");
            });
        }

        private void ResetLoanPaymentFields()
        {
            txtLoanAmount.Clear();
            dtLoanPayrollStartDate.Value = DateTime.Now;
            dtLoanPayrollCutoffDate.Value = DateTime.Now;
            txtLoanAmountPaid.Clear();
            txtLoanRemainingAmount.Clear();
            txtLoanAmountToPay.Clear();
        }

        private void ResetLoanListFields()
        {
            txtLoanEmpName.Clear();
            comboLoanType.Text = "Select";
            txtLoanDescription.Text = "";
            txtLoanAmount.Text = "0.00";
        }

        private decimal GetTotalAmountPaidForLoan()
        {
            decimal paidAmt = 0.00M;
            return paidAmt = loanProcessor.ExecuteSQLComputeTotalAmountPaidForLoan(loanId, () =>
            {
                Console.WriteLine("Amount paid successfully computed.");
            }, () =>
            {
                Console.WriteLine("Problem computing amount paid.");
            });
        }

        private void ValidateLoanPaymentDataFields()
        {
            if(txtLoanAmountToPay.Text == "" || txtLoanAmountToPay.Text == "0.00")
            {

            }
        }
    }
}
