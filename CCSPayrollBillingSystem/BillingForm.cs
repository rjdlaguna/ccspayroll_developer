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
            }, () =>
            {
                MessageBox.Show("Problem listing all employees in the Project.");
            });
        }

        private void BillingAttributeList()
        {
            foreach (DataGridViewRow dgvRow in dgvEmployeeList4Billing.Rows)
            {
                //Dictionary<string, object> employeeAttributes = new Dictionary<string, object>();
                var fname = dgvRow.Cells[1].Value;
                var lname = dgvRow.Cells[2].Value;
                string projectRate = dgvRow.Cells[4].Value.ToString();
                string regDays = (dgvRow.Cells[5].Value.ToString() == "NULL") ? "0" : dgvRow.Cells[5].Value.ToString();
                string splHolidays = (dgvRow.Cells[7].Value.ToString() == "NULL") ? "0" : dgvRow.Cells[7].Value.ToString();
                string regHolidays = (dgvRow.Cells[8].Value.ToString() == "NULL") ? "0" : dgvRow.Cells[8].Value.ToString();

                string cola = (dgvRow.Cells[10].Value.ToString() == "NULL") ? "0" : dgvRow.Cells[10].Value.ToString();
                string pda = (dgvRow.Cells[11].Value.ToString() == "NULL") ? "0" : dgvRow.Cells[11].Value.ToString();
                string others = (dgvRow.Cells[12].Value.ToString() == "NULL") ? "0" : dgvRow.Cells[12].Value.ToString();

                string regDaysOT = (dgvRow.Cells[6].Value.ToString() == "NULL") ? "0" : dgvRow.Cells[6].Value.ToString();
                //string splHolidaysSunOT = (dgvRow.Cells[7].Value.ToString() == "NULL") ? "0" :dgvRow.Cells[?].ToString();
                string regHolidaysOT = (dgvRow.Cells[9].Value.ToString() == "NULL") ? "0" : dgvRow.Cells[9].Value.ToString();

                decimal regDaysAmount = WorkDaysComputation.RegularDays(Convert.ToDecimal(projectRate), float.Parse(regDays));
                decimal splHolAmount = WorkDaysComputation.SunOrSpecialHolidays(Convert.ToDecimal(projectRate), float.Parse(splHolidays));
                decimal regHolAmount = WorkDaysComputation.RegularHolidays(Convert.ToDecimal(projectRate), float.Parse(regHolidays));

                decimal colaAmount = WorkDaysComputation.COLA(Convert.ToDecimal(cola));
                decimal pdaAmount = WorkDaysComputation.PDA(Convert.ToDecimal(pda));
                decimal othersAmount = WorkDaysComputation.Others(Convert.ToDecimal(others));

                decimal employeeTotalAmount = regDaysAmount + splHolAmount + regHolAmount + colaAmount + pdaAmount + othersAmount;

                rtbBillingSlip.Text += lname+", "+fname+"\n";
                rtbBillingSlip.Text += ForDisplay(projectRate);
                rtbBillingSlip.Text += ForDisplay(regDays);
                rtbBillingSlip.Text += ForDisplay(splHolidays);
                rtbBillingSlip.Text += ForDisplay(regHolidays);

                //rtbBillingSlip.Text += ForDisplay(cola);
                //rtbBillingSlip.Text += ForDisplay(pda);
                //rtbBillingSlip.Text += ForDisplay(others);

                //rtbBillingSlip.Text += ForDisplay(regDaysOT);
                //rtbBillingSlip.Text += splHolidaysSunOT + "\n";
                //rtbBillingSlip.Text += ForDisplay(regHolidaysOT);
                rtbBillingSlip.Text += "Amount: \t" + employeeTotalAmount.ToString("C", nfi);
                rtbBillingSlip.Text += "-------------\n";
            }
        }

        private string ForDisplay(object attribute)
        {
            if (attribute != null)
            {
                return attribute + "\n";
            }
            return "object is null";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            BillingAttributeList();
        }
    }
}
