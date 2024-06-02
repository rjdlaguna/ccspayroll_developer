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
            projectInfo = _projectProcessor.ProjectInfo;
            var projectValue = projectInfo.Any(x => x.Value == "ALL");
            if (!projectValue)
            {
                projectInfo.Add(projectInfo.Count + 1, "ALL");
            }

            cmbProjectList.DataSource = new BindingSource(projectInfo, null);
            cmbProjectList.DisplayMember = "Value";
            cmbProjectList.ValueMember = "Key";
            dgPayrollEmpList.Columns[0].Visible = false;

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
            //LoadPayrollEmployeeINfo(empFname, empLname);
            LoadProjectEmployees(projId, projName);
        }

        private void LoadPayrollEmployeeINfo(string fname, string lname)
        {
            QueryProcessor payrollProcessor = new QueryProcessor();
            payrollProcessor.ExecuteSqlPayrollEmpLoadInfoQuery(fname, lname, () =>
            {
                ControlsManager.SingleEnableControls(btnLoad, true);
                dgPayrollEmpList.DataSource = payrollProcessor.GetSqlReaderData();
                Console.WriteLine("Loading Employee Payroll Information successful.");
            }, () =>
            {
                ControlsManager.SingleEnableControls(btnLoad, false);
                Console.WriteLine("Problem loading employee payroll information.");
            });
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Employee SelectedEmployee = new Employee();
            var empProjectRate = dgPayrollEmpList.SelectedRows[0].Cells[5].Value;
            var empPayRate = dgPayrollEmpList.SelectedRows[0].Cells[6].Value;
            
            SelectedEmployee.EmpIdPayroll = Convert.ToInt32(dgPayrollEmpList.SelectedRows[0].Cells[0].Value.ToString());
            SelectedEmployee.EmpFnamePayroll = dgPayrollEmpList.SelectedRows[0].Cells[1].Value.ToString();
            SelectedEmployee.EmpLnamePayroll = dgPayrollEmpList.SelectedRows[0].Cells[3].Value.ToString();
            SelectedEmployee.EmpPayRatePayroll = empPayRate != DBNull.Value ? Convert.ToDecimal(empPayRate) : 0;
            SelectedEmployee.EmpProjectRatePayroll = empProjectRate != DBNull.Value ? Convert.ToDecimal(empProjectRate) : 0;
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
            projectProcessor.ExecuteSQLLoadProjectEmployeesQuery(id, pName, () =>
             {
                 ControlsManager.SingleEnableControls(btnLoad, true);
                 dgPayrollEmpList.DataSource = projectProcessor.GetSqlReaderData();
                 Console.WriteLine("Loading Employee for the Project successful.");
             }, () =>
             {
                 ControlsManager.SingleEnableControls(btnLoad, false);
                 Console.WriteLine("Problem loading employee for the project.");
             }, txtsearchfname.Text, txtsearchlname.Text);

            HideFirstColumn();
        }

        private void HideFirstColumn()
        {
            if(dgPayrollEmpList.Columns.Contains("EmpID"))
            {
                dgPayrollEmpList.Columns[0].Visible = false;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
