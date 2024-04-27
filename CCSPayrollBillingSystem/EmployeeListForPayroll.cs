using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;
using CCSPayrollBillingSystem.Scripts.Data;
using CCSPayrollBillingSystem.Scripts.SystemUtility;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeeListForPayroll : Form
    {
        private int empId;
        private string empFname;
        private string empLname;

        public int projId;
        public string projName;
        public decimal projRate;

        public event Action<Employee> OnEmployeeSearchedValues;
        QueryProcessor projectProcessor = new QueryProcessor();

        public EmployeeListForPayroll()
        {
            InitializeComponent();
            _projectProcessor = new ProjectProcessor();
        }

        private ProjectProcessor _projectProcessor;
        private IDictionary<int, string> projectInfo;

        private void EmployeeListForPayroll_Load(object sender, EventArgs e)
        {

            LoadPayrollEmployeeINfo(empFname, empLname);
            projectInfo = _projectProcessor.ProjectInfo;
            projectInfo.Add(projectInfo.Count + 1, "ALL");

            cmbProjectList.DataSource = new BindingSource(projectInfo, null);
            cmbProjectList.DisplayMember = "Value";
            cmbProjectList.ValueMember = "Key";

            OnEmployeeSearchedValues += LoadSearchedEmployeeDetails;
        }

        private void btnEmpSearch_Click(object sender, EventArgs e)
        {
            empFname = txtsearchfname.Text;
            empLname = txtsearchlname.Text;
            if (String.IsNullOrEmpty(empFname))
            {
                empFname = null;
            }
            if (String.IsNullOrEmpty(empLname))
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

            SelectedEmployee.EmpFnamePayroll = dgPayrollEmpList.SelectedRows[0].Cells[0].Value.ToString();
            SelectedEmployee.EmpLnamePayroll = dgPayrollEmpList.SelectedRows[0].Cells[2].Value.ToString();
            SelectedEmployee.EmpRatePayroll = Convert.ToDecimal(dgPayrollEmpList.SelectedRows[0].Cells[3].Value);
            SelectedEmployee.EmpRankPayroll = dgPayrollEmpList.SelectedRows[0].Cells[4].Value.ToString();

            OnEmployeeSearchedValues?.Invoke(SelectedEmployee);

            Close();
        }

        private void LoadSearchedEmployeeDetails(Employee emp)
        {
            empId = emp.EmpIdPayroll;
            empLname = emp.EmpFnamePayroll;
            empFname = emp.EmpLnamePayroll;

        }

        private void cmbProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            projName = cmbProjectList.Text;
            projId = projectInfo.FirstOrDefault(x => x.Value == projName).Key;
            dgPayrollEmpList.DataSource = null;
            LoadProjectEmployees(projId,projName);
        }

        private void LoadProjectEmployees(int id, string pName)
        {
            projectProcessor.ExecuteSQLLoadProjectEmployeesQuery(id, pName,() =>
            {
                dgPayrollEmpList.DataSource = projectProcessor.GetSqlReaderData();
                Console.WriteLine("Loading Employee for the Project successful.");
            }, () =>
            {
                Console.WriteLine("Problem loading employee for the project.");
            });
        }
    }
}
