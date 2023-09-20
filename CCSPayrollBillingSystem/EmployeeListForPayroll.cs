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
    public partial class EmployeeListForPayroll : Form
    {
        private string empFname;
        private string empLname;

        public event Action<Employee> OnEmployeeSearchedValues;

        public EmployeeListForPayroll()
        {
            InitializeComponent();
        }

        private void EmployeeListForPayroll_Load(object sender, EventArgs e)
        {
            
            LoadPayrollEmployeeINfo(empFname, empLname);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEmpSearch_Click(object sender, EventArgs e)
        {
            empFname = txtsearchfname.Text;
            empLname = txtsearchlname.Text;
            if(String.IsNullOrEmpty(empFname))
            {
                empFname = null;
            }
            if(String.IsNullOrEmpty(empLname))
            {
                empLname = null;
            }
            LoadPayrollEmployeeINfo(empFname, empLname);

        }

        private void LoadPayrollEmployeeINfo(string fname, string lname)
        {
            QueryProcessor payrollProcessor = new QueryProcessor();
            payrollProcessor.ExecuteSqlPayrollEmpLoadInfoQuery(fname, lname, () =>
            {
                dgPayrollEmpList.DataSource = payrollProcessor.GetSqlReaderData();
                dgPayrollEmpList.Columns[0].Visible = false;
                Console.WriteLine("Loading Employee Payroll Information successful.");
            }, () =>
            {
                Console.WriteLine("Problem loading employee payroll information.");
            });
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Employee SelectedEmployee = new Employee();

            SelectedEmployee.EmpIdPayroll = Convert.ToInt32(dgPayrollEmpList.SelectedRows[0].Cells[0].Value.ToString());
            SelectedEmployee.EmpFnamePayroll = dgPayrollEmpList.SelectedRows[0].Cells[1].Value.ToString();
            SelectedEmployee.EmpLnamePayroll = dgPayrollEmpList.SelectedRows[0].Cells[2].Value.ToString();
            SelectedEmployee.EmpRatePayroll = Convert.ToDouble(dgPayrollEmpList.SelectedRows[0].Cells[4].Value.ToString());
            SelectedEmployee.EmpRankPayroll = dgPayrollEmpList.SelectedRows[0].Cells[5].Value.ToString();
            
            OnEmployeeSearchedValues?.Invoke(SelectedEmployee);

            Close();
        }

        private void dgPayrollEmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
