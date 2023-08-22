using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class frmBilling : Form
    {
        private int projectTestingID = 1;
        //private string empFirstName;
        //private string empLastName;
        //private float rendered;
        //private decimal projectRate;
        private decimal employeeTotalAmount;
        private decimal grandTotalAmount = 0;
        private decimal billingGrossTotalAmount;
        private decimal vat;
        private decimal billingNetTotalAmount;
        List<Dictionary<string, object>> employeeAttribList4Billing = new List<Dictionary<string, object>>();
        List<Dictionary<string, object>> employeeBillingDetails = new List<Dictionary<string, object>>();

        private NumberFormatInfo nfi = new CultureInfo("en-PH", false).NumberFormat;
        public frmBilling()
        {
            InitializeComponent();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryProcessor billingProcessor = new QueryProcessor();
            employeeAttribList4Billing = billingProcessor.ExecuteSqlBillingViewQuery(projectTestingID);

            object projectName = employeeAttribList4Billing.FirstOrDefault().TryGetValue("ProjectName", out var value) ? value : null;
            txtProjectName.Text = projectName.ToString();

            billingProcessor.ExecuteSqlBillingViewQuery4DataGrid(projectTestingID, () =>
            {
                dgvEmployeeList4Billing.DataSource = billingProcessor.GetSqlReaderData();
                dgvEmployeeList4Billing.Columns[0].Visible = false;
            }, () =>
            {
                MessageBox.Show("Problem listing all employees in the Project.");
            });
        }

        private void BillingAttributeListProcessing()
        {
            decimal employeeTotalOTAmount = 0;
            decimal employeeTotalAmount = 0;
            Dictionary<string, object> newEmployeeBillingData = null;

            foreach (DataGridViewRow dgvRow in dgvEmployeeList4Billing.Rows)
            {
                var fname = dgvRow.Cells[1].Value;
                var lname = dgvRow.Cells[2].Value;
                decimal projectRate = Convert.ToDecimal(dgvRow.Cells[4].Value);
                var regDays = dgvRow.Cells[5].Value != DBNull.Value ? dgvRow.Cells[5].Value : 0;
                var splHolidays = dgvRow.Cells[7].Value != DBNull.Value ? dgvRow.Cells[7].Value : 0;
                var regHolidays = dgvRow.Cells[8].Value != DBNull.Value ? dgvRow.Cells[8].Value : 0;

                var cola = dgvRow.Cells[10].Value != DBNull.Value ? dgvRow.Cells[10].Value : 0;
                var pda = dgvRow.Cells[11].Value != DBNull.Value ? dgvRow.Cells[11].Value : 0;
                var others = dgvRow.Cells[12].Value != DBNull.Value ? dgvRow.Cells[5].Value : 0;

                var regDaysOT = dgvRow.Cells[6].Value != DBNull.Value ? dgvRow.Cells[6].Value : 0;
                //string splHolidaysSunOT = (dgvRow.Cells[7].Value.ToString() == "NULL") ? "0" :dgvRow.Cells[?].ToString();
                var regHolidaysOT = dgvRow.Cells[9].Value != DBNull.Value ? dgvRow.Cells[9].Value : 0;

                decimal regDaysAmount = WorkDaysComputation.RegularDays(projectRate, Convert.ToDouble(regDays));
                decimal splHolAmount = WorkDaysComputation.SunOrSpecialHolidays(projectRate, Convert.ToDouble(splHolidays));
                decimal regHolAmount = WorkDaysComputation.RegularHolidays(projectRate, Convert.ToDouble(regHolidays));

                decimal colaAmount = WorkDaysComputation.COLA(Convert.ToDecimal(cola));
                decimal pdaAmount = WorkDaysComputation.PDA(Convert.ToDecimal(pda));
                decimal othersAmount = WorkDaysComputation.Others(Convert.ToDecimal(others));

                decimal regDaysOTAmount = WorkDaysComputation.RegularDaysOT(projectRate, Convert.ToDouble(regDaysOT));
                decimal regDaysOTRateAmount = WorkOTRateComputation.RegularDaysOTRate(projectRate);
                
                decimal splHolOTAmount = WorkDaysComputation.SpecialHolidaysOT(projectRate, Convert.ToDouble(regDaysOT));

                employeeTotalAmount = regDaysAmount + splHolAmount + regHolAmount + colaAmount + pdaAmount + othersAmount + (employeeTotalOTAmount);
                employeeTotalOTAmount = regDaysOTAmount + splHolOTAmount;
                grandTotalAmount += employeeTotalAmount;

                string fullName = lname + ", " + fname;

               newEmployeeBillingData = new Dictionary<string, object>
                {
                    { dgvEmployeeList4Billing.Columns[0].HeaderText, dgvRow.Cells[0].Value },//0
                    { "FullName", fullName },//1
                    { dgvEmployeeList4Billing.Columns[3].HeaderText, dgvRow.Cells[3].Value },//2
                    { dgvEmployeeList4Billing.Columns[4].HeaderText, projectRate }//3
                };


                for (int i = 5; i < dgvRow.Cells.Count; i++)
                {
                    var columnName = dgvEmployeeList4Billing.Columns[i].HeaderText;
                    var columnValue = dgvRow.Cells[i].Value;

                    if (dgvRow.Cells[i].Value == DBNull.Value)
                    {
                        continue;
                    }
                    newEmployeeBillingData.Add(columnName, columnValue);
                    newEmployeeBillingData.Add(columnName+"Rate", WorkOTRateComputation.BillingRateState(columnName, projectRate));
                    Console.Write(columnName +"-"+ columnValue +"-");
                    Console.WriteLine(columnName + "Rate", WorkOTRateComputation.BillingRateState(columnName, projectRate));
                    //newEmployeeBillingData.Add("EmployeeTotalAmount", employeeTotalAmount);
                }
            employeeBillingDetails.Add(newEmployeeBillingData);
            }
            
        }

        private void BillingAttributeList2Display()
        {
            rtbBillingSlip.Text += "Employee Name\t\t\t Hrs/Days \t Rate \t Amount" + "\n"; //Title

            foreach (Dictionary<string, object> employeeBillingData in employeeBillingDetails)
            {
                rtbBillingSlip.Text += employeeBillingData["FullName"] + "\t";
                rtbBillingSlip.Text += "   " + employeeBillingData["ProjectRate"]+"\t\t\n";
                for (int i = 5; i < employeeBillingData.Count; i++)
                {
                    string key = employeeBillingData.Keys.ElementAt(i);
                    object value = employeeBillingData[key];
                    rtbBillingSlip.Text += "\t" + key + "\t\t" + value + "\n";
                }
                rtbBillingSlip.Text += "\n";
                //rtbBillingSlip.Text += employeeTotalAmount.ToString("C", nfi) + "\n";
            }

            rtbBillingSlip.Text += "\n-------------\n";
            rtbBillingSlip.Text += "Grand Total: " + "\t" + grandTotalAmount.ToString("C", nfi);
            rtbBillingSlip.Text += "\n-------------\n";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            BillingAttributeListProcessing();
            BillingAttributeList2Display();
        }
    }
}
