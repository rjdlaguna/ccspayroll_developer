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
        private int projectID;
        private string projectName;
        private decimal projectRate;
        private decimal gross = 0;
        private decimal net = 0;
        private decimal vat = 0;

        private decimal grandTotalAmount;

        List<Dictionary<string, object>> employeeAttribFromQuery = new List<Dictionary<string, object>>();
        List<Dictionary<string, object>> employeeBillingDetails = new List<Dictionary<string, object>>();

        QueryProcessor projectProcessor = new QueryProcessor();
        IDictionary<int, string> projetInfo = new Dictionary<int, string>();

        private NumberFormatInfo nfi = new CultureInfo("en-PH", false).NumberFormat;
        public frmBilling() => InitializeComponent();

        private void frmBilling_Load(object sender, EventArgs e)
        {
            List<string[]> projectList = new List<string[]>();

            projectList = projectProcessor.ExecuteSqlLoadProjectsQuery(
                () =>
                {
                    Console.WriteLine("Projects successfully loaded.");
                }, 
            
                () =>
                {
                    Console.WriteLine("Problem loading projects.");
                });

            ExtractProjectName(projectList);
        }

        private void ExtractProjectName(List<string[]> projectList)
        {
            int[] projIds = new int[projectList.Count];
            string projNameVal = "";
            int projNameId = 0;
            int count = 0;

            foreach (string[] project in projectList)
            {
                // Access the elements within each row
                foreach (string value in project)
                {
                    if (int.TryParse(value, out int id))
                    {
                        projIds[count] = id;
                        projNameId = id;
                        count++;
                    }
                    else
                    {
                        cmbProject.Items.Add(value);
                        projNameVal = value;
                    }

                }
                projetInfo.Add(projNameId, projNameVal);
            }
        }
        private void LoadProjectEmployees(int projID)
        {
            QueryProcessor billingProcessor = new QueryProcessor();
            employeeAttribFromQuery = billingProcessor.ExecuteSqlBillingViewQuery(projID);

            object projectName = employeeAttribFromQuery.FirstOrDefault().TryGetValue("ProjectName", out var value) ? value : null;

            billingProcessor.ExecuteSqlBillingViewQuery4DataGrid(projID, () =>
            {
                DataTable tempDataTableBilling = billingProcessor.GetSqlReaderData();
                dgvEmployeeList4Billing.DataSource = AddInputColumnsOnBillingDVG(tempDataTableBilling);
                dgvEmployeeList4Billing.Columns[0].Visible = false;
                ChangeStyleDGV();
            }, () =>
            {
                MessageBox.Show("Problem listing all employees in the Project.");
            });

        }

        private DataTable AddInputColumnsOnBillingDVG(DataTable dataTableBilling)
        {//Create the DataTable and insert Rate columns, 
            DataTable tempDataTable = new DataTable();
            
            for (int i = 0; i < 5; i++)
            {
                tempDataTable.Columns.Add(dataTableBilling.Columns[i].ColumnName);
            }

            for (int i = 5; i < dataTableBilling.Columns.Count; i++)
            {
                tempDataTable.Columns.Add(dataTableBilling.Columns[i].ColumnName);
                tempDataTable.Columns.Add(dataTableBilling.Columns[i].ColumnName + "Rate", typeof(Decimal));
            }
            //then add the DataTable result of the SQL query
            foreach (DataRow row in dataTableBilling.Rows)
            {
                DataRow newRow = tempDataTable.NewRow();
                foreach (DataColumn column in dataTableBilling.Columns)
                {
                    newRow[column.ColumnName] = row[column];
                }
                var regAmount = Convert.ToDecimal(newRow[4]) * Convert.ToDecimal(newRow[5]);
                newRow[6] = regAmount;

                tempDataTable.Rows.Add(newRow);
            }

            return tempDataTable;
        }

        private void ChangeStyleDGV()
        {//To Color the DataGridView cells for Rates....
            foreach (DataGridViewRow dgvRow in dgvEmployeeList4Billing.Rows)
            {
                int fifthColumn = 5;
                for (int i = fifthColumn; i < dgvEmployeeList4Billing.Columns.Count; i++)
                {
                    if (dgvEmployeeList4Billing.Columns[i].HeaderText.Contains("Rate") && dgvRow.Cells[i-1].Value != DBNull.Value)
                    {
                        dgvRow.Cells[i].Style.BackColor = Color.CadetBlue;
                    }
                    else
                    {
                        dgvEmployeeList4Billing.Columns[i].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
                    }
                }
            }
        }

        private object ObjectValidation(object obj)
        {//DBNull Validation
            var _obj = (obj != DBNull.Value) ? obj : 0;
            return _obj;
        }

        private string StringToPeso(decimal value)
        {
            return value.ToString("C", nfi);
        }

        private void BillingAttributeListProcessing()
        {
            Dictionary<string, object> newEmployeeBillingData = null;

            foreach (DataGridViewRow dgvRow in dgvEmployeeList4Billing.Rows)
            {
                var fname = dgvRow.Cells[1].Value;
                var lname = dgvRow.Cells[2].Value;
                decimal projectRate = Convert.ToDecimal(dgvRow.Cells[4].Value);

                string fullName = lname + ", " + fname;

                newEmployeeBillingData = new Dictionary<string, object>
                {
                    { dgvEmployeeList4Billing.Columns[0].HeaderText, dgvRow.Cells[0].Value },//0 - Employee ID
                    { "FullName", fullName },                                                //1 - FullName
                    { dgvEmployeeList4Billing.Columns[3].HeaderText, dgvRow.Cells[3].Value },//2 - ProjectName
                    { dgvEmployeeList4Billing.Columns[4].HeaderText, projectRate }           //3 - ProjectRate
                };

                for (int index = 5; index < dgvRow.Cells.Count; index++)
                {
                    var columnName = dgvEmployeeList4Billing.Columns[index].HeaderText;
                    var columnValue = ObjectValidation(dgvRow.Cells[index].Value);
                    if (dgvRow.Cells[index].Value == DBNull.Value)
                    {
                        continue;
                    }
                    newEmployeeBillingData.Add(columnName, columnValue);
                }
                   
            employeeBillingDetails.Add(newEmployeeBillingData);
            }
            
        }

        private void BillingAttributeList2Display()
        {
            rtbBillingSlip.Text += "CCS - Manpower & Allied Services \n";
            rtbBillingSlip.Text += "1251 Miranda Street, Sto. Rosario, Angeles City \n\n";
            rtbBillingSlip.Text += "ProjectName: "+ cmbProject.Text +"\n";
            rtbBillingSlip.Text += "Services rendered for the period: "+ DateTime.Now + "\n";
            rtbBillingSlip.Text += "\n----------------------------------------------------------------------------------------------------------------------------------\n";
            rtbBillingSlip.Text += "Employee Name\t\t\t Hrs/Days\t Rate \t\t Amount"; //Title
            rtbBillingSlip.Text += "\n----------------------------------------------------------------------------------------------------------------------------------\n";
            foreach (DataGridViewRow dgvRow in dgvEmployeeList4Billing.Rows)
            {
                var fname = dgvRow.Cells[1].Value;
                var lname = dgvRow.Cells[2].Value;
                decimal projectRate = Convert.ToDecimal(ObjectValidation(dgvRow.Cells[4].Value));
                decimal regDaysAmount = Convert.ToDecimal(ObjectValidation(dgvRow.Cells[6].Value));
                decimal total = 0;

                rtbBillingSlip.Text += lname + ", " + fname + "\t";
                rtbBillingSlip.Text += " \t\t" + dgvRow.Cells[5].Value + "\t\t" + dgvRow.Cells[4].Value + "\t\t" + regDaysAmount + "\n";
                for (int i = 7; i < dgvRow.Cells.Count; i++)
                {
                    decimal rate = 0;
                    decimal render = 0;
                    decimal amount = 0;
                    

                    string key = dgvEmployeeList4Billing.Columns[i].HeaderText;
                    object value = ObjectValidation(dgvRow.Cells[i].Value);
                    rate = Math.Round(Convert.ToDecimal(value), 2);
                    if (dgvRow.Cells[i].Value == DBNull.Value)
                    {
                        continue;
                    }
                    if (key.Contains("Rate"))
                    {
                        render = Convert.ToDecimal(ObjectValidation(dgvRow.Cells[i-1].Value));
                        amount = rate * render;
                        rtbBillingSlip.Text += rate + "\t\t" + amount + "\n";
                    }
                    else
                    {                        
                        rtbBillingSlip.Text += "    " + key + "\t\t\t" + rate + "\t\t";
                    }
                    total += amount;
                }
                grandTotalAmount = total + regDaysAmount;
                rtbBillingSlip.Text += "\n";
                gross += grandTotalAmount;
            }

            rtbBillingSlip.Text += "\n\t\t-----------------------------------------------------------------\n";
            rtbBillingSlip.Text += "\t\tSales: " + "\t\t\t" + StringToPeso(gross);
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectName = cmbProject.Text;
            projectID = projetInfo.FirstOrDefault(x => x.Value == projectName).Key;
            dgvEmployeeList4Billing.DataSource = null;
            LoadProjectEmployees(projectID);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            gross = 0;
            grandTotalAmount = 0;
            rtbBillingSlip.Clear();
            BillingAttributeListProcessing();
            BillingAttributeList2Display();
            txtGrossTotal.Text = StringToPeso(gross);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            vat = Convert.ToDecimal(txtVAT.Text);
            net = gross + vat;
            txtNetTotal.Text = StringToPeso(net);

            rtbBillingSlip.Text += "\n\t\tVat: " + "\t\t\t" + StringToPeso(vat);
            rtbBillingSlip.Text += "\n\t\t-----------------------------------------------------------------\n";
            rtbBillingSlip.Text += "\t\tGrand Total: " + "\t\t" + StringToPeso(net);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtbBillingSlip.Text, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }
    }
}
