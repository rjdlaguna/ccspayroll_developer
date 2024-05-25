using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CCSPayrollBillingSystem.Scripts;
using CCSPayrollBillingSystem.Scripts.SystemUtility;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using CCSPayrollBillingSystem.Scripts.Data;

namespace CCSPayrollBillingSystem
{
    public partial class frmBilling : Form
    {
        private int projectID;
        private string projectName;
        private decimal gross = 0;
        private decimal net = 0;
        private decimal vat = 0;
        private int currentID = 0;
        private int slideValue = 1;

        private decimal grandTotalAmount;

        List<Dictionary<string, object>> employeeAttribFromQuery = new List<Dictionary<string, object>>();
        List<Dictionary<string, object>> employeeBillingDetails = new List<Dictionary<string, object>>();

        List<WorkDays> employeeListWorkdays = new List<WorkDays>();
        List<WorkDaysRate> employeeListWorkdaysRate = new List<WorkDaysRate>();

        private ProjectProcessor projectProcessor;
        IDictionary<int, string> projectInfo;

        public frmBilling()
        {
            InitializeComponent();
            projectProcessor = new ProjectProcessor();
        }

        private void frmBilling_Load(object sender, EventArgs e)
        {
            projectInfo = projectProcessor.ProjectInfo;

            cmbProject.DataSource = new BindingSource(projectInfo, null);
            cmbProject.DisplayMember = "Value";
            cmbProject.ValueMember = "Key";

            ValidationHelper.SingleEnableControls(btnGenerate, false);
            ValidationHelper.SingleEnableControls(btnCalculate, false);
            ValidationHelper.SingleEnableControls(btnPrint, false);
        }

        private void LoadProjectEmployees(int projID, DateTime date)
        {
            ExtractProjectBySelectedID(projID);

            QueryProcessor billingProcessor = new QueryProcessor();
            //employeeAttribFromQuery = billingProcessor.ExecuteSqlBillingViewQuery(projID, date);

            billingProcessor.ExecuteSqlBillingViewQuery4DataGrid(projID, date, () =>
            {
                DataTable tempDataTableBilling = billingProcessor.GetSqlReaderData();
                dgvEmployeeList4Billing.DataSource = AddInputColumnsOnBillingDVG(tempDataTableBilling);
                //WorkDaysBillingInitialization();
                dgvEmployeeList4Billing.Columns[0].Visible = false;
                dgvEmployeeList4Billing.Columns[3].Visible = false;
                //ChangeStyleDGV();
                dgvEmployeeList4Billing.Columns["LastName"].Frozen = true;
                LoadBillingWorkdaysOnGroupbox(currentID);
            }, () =>
            {
                ControlsManager.ClearGBControlsInTextBox(gbWorkDays.Controls);
                ControlsManager.EnableButtonControlsInGroupBox(gbWorkDays.Controls, false);
                SetDefaultWorkDaysRate();
                MessageBox.Show("Problem listing all employees in the Project.");
            });

        }

        private DataTable ConvertToDataTable(List<Dictionary<string, object>> list)
        {
            DataTable dataTable = new DataTable();

            if (list.Count > 0)
            {
                foreach (var key in list[0].Keys)
                {
                    dataTable.Columns.Add(key);
                }

                foreach (var dict in list)
                {
                    DataRow row = dataTable.NewRow();
                    foreach (var key in dict.Keys)
                    {
                        row[key] = dict[key] ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }


        private void ExtractProjectBySelectedID(int projectID)
        {
            // Find the KeyValuePair with the specified ProjectID
            KeyValuePair<int, string> selectedProject = projectInfo.FirstOrDefault(pair => pair.Key == projectID);

            // Set the selected item in the ComboBox
            projectName = selectedProject.Value;
        }

        private void WorkDaysBillingInitialization()//Initialize the WorkDays property based on the datagridview source
        {
            foreach (DataGridViewRow dataGridViewRow in dgvEmployeeList4Billing.Rows)
            {
                WorkDays _workDays = new WorkDays
                {
                    WorkDayID = Convert.ToInt32(dataGridViewRow.Cells[0].Value),
                    RegularDays = dataGridViewRow.Cells[5].Value.ToString().ToFloat(),
                    RegularDaysOT = dataGridViewRow.Cells[6].Value.ToString().ToFloat(),
                    SplHolidays = dataGridViewRow.Cells[7].Value.ToString().ToFloat(),
                    SplHolidayOT = dataGridViewRow.Cells[8].Value.ToString().ToFloat(),
                    RegularHoliday = dataGridViewRow.Cells[9].Value.ToString().ToFloat(),
                    RegularHolidayOT = dataGridViewRow.Cells[10].Value.ToString().ToFloat(),
                    RegHolRestDay = dataGridViewRow.Cells[11].Value.ToString().ToFloat(),
                    COLA = dataGridViewRow.Cells[12].Value.ToString().ToFloat(),
                    PDA = dataGridViewRow.Cells[13].Value.ToString().ToFloat(),
                    Others = dataGridViewRow.Cells[14].Value.ToString().ToFloat()
                };

                employeeListWorkdays.Add(_workDays);
            } 
        }

        private void LoadBillingWorkdaysOnGroupbox(int rowID)
        {
            ControlsManager.EnableButtonControlsInGroupBox(gbWorkDays.Controls, true);
            if (dgvEmployeeList4Billing.RowCount > 0)
            {
                //Load the employees in the textboxes under the groupbox Employee Billing
                DataGridViewRow dataGridViewRow = dgvEmployeeList4Billing.Rows[rowID];

                txtFullName.Text = dataGridViewRow.Cells[2].Value.ToString() + ", " + dataGridViewRow.Cells[1].Value.ToString();
                txtRegDays.Text = dataGridViewRow.Cells[5].Value.ToString();
                txtRegOT.Text = dataGridViewRow.Cells[7].Value.ToString();
                txtSplHolidays.Text = dataGridViewRow.Cells[9].Value.ToString();
                txtSplHolidaysOT.Text = dataGridViewRow.Cells[11].Value.ToString();
                txtRegHolidays.Text = dataGridViewRow.Cells[13].Value.ToString();
                txtRegHolidaysOT.Text = dataGridViewRow.Cells[15].Value.ToString();
                txtRegHolRestDay.Text = dataGridViewRow.Cells[17].Value.ToString();
                txtCOLA.Text = dataGridViewRow.Cells[19].Value.ToString();
                txtPDA.Text = dataGridViewRow.Cells[21].Value.ToString();
                txtOthers.Text = dataGridViewRow.Cells[23].Value.ToString();

                txtRegDaysRate.Text = (dataGridViewRow.Cells[6].Value).ObjectValidation().ToString();
                txtRegOTRate.Text = (dataGridViewRow.Cells[8].Value).ObjectValidation().ToString();
                txtSplHolidaysRate.Text = (dataGridViewRow.Cells[10].Value).ObjectValidation().ToString();
                txtSplHolidaysOTRate.Text = (dataGridViewRow.Cells[12].Value).ObjectValidation().ToString();
                txtRegHolidaysRate.Text = (dataGridViewRow.Cells[14].Value).ObjectValidation().ToString();
                txtRegHolidaysOTRate.Text = (dataGridViewRow.Cells[16].Value).ObjectValidation().ToString();
                txtRegHolRestDayRate.Text = (dataGridViewRow.Cells[18].Value).ObjectValidation().ToString();
                txtCOLARate.Text = txtCOLA.Text;
                txtPDARate.Text = txtPDA.Text;
                txtOthersRate.Text = txtOthers.Text;
            }
            
        }

        private void SetInputWorkDaysRate(int rowID)
        {
            //Set the Workdays Rate textboxes in the groupbox Employee Billing

            WorkDaysRate _workDaysRate = new WorkDaysRate()
            {
                RowID = employeeListWorkdays[rowID].WorkDayID,
                RegularDaysRate = txtRegDaysRate.Text.ToDecimal(),
                RegularDaysOTRate = txtRegOTRate.Text.ToDecimal(),
                SplHolidaysRate = txtSplHolidaysRate.Text.ToDecimal(),
                SplHolidayOTRate = txtSplHolidaysOTRate.Text.ToDecimal(),
                RegularHolidayRate = txtRegHolidaysRate.Text.ToDecimal(),
                RegularHolidayOTRate = txtRegHolidaysOTRate.Text.ToDecimal(),
                RegHolRestDayRate = txtRegHolRestDayRate.Text.ToDecimal(),
                COLARate = txtCOLARate.Text.ToDecimal(),
                PDARate = txtPDARate.Text.ToDecimal(),
                OthersRate = txtOthersRate.Text.ToDecimal()
            };

            employeeListWorkdaysRate.Add(_workDaysRate);
        }

        private void SetDefaultWorkDaysRate()
        {
            txtRegDaysRate.Text = Constants.DEFAULT_VALUE;
            txtRegOTRate.Text = Constants.DEFAULT_VALUE;
            txtSplHolidaysRate.Text = Constants.DEFAULT_VALUE;
            txtSplHolidaysOTRate.Text = Constants.DEFAULT_VALUE;
            txtRegHolidaysRate.Text = Constants.DEFAULT_VALUE;
            txtRegHolidaysOTRate.Text = Constants.DEFAULT_VALUE;
            txtRegHolRestDayRate.Text = Constants.DEFAULT_VALUE;
            txtCOLARate.Text = Constants.DEFAULT_VALUE;
            txtPDARate.Text = Constants.DEFAULT_VALUE;
            txtOthersRate.Text = Constants.DEFAULT_VALUE;

            employeeListWorkdays.Clear();
            employeeListWorkdaysRate.Clear();
        }

        private DataTable AddInputColumnsOnBillingDVG(DataTable dataTableBilling)
        {
            //Create the DataTable and insert Rate columns, 
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
                    if ((dgvEmployeeList4Billing.Columns[i].HeaderText.Contains("Rate")) && (!dgvRow.Cells[i-1].Value.Equals("0")))
                    {
                        dgvRow.Cells[i].Style.BackColor = Color.CadetBlue;
                        Console.WriteLine(dgvRow.Cells[i - 1].Value);
                    }
                    else
                    {
                        //dgvEmployeeList4Billing.Columns[i].ReadOnly = true;
                        dgvEmployeeList4Billing.Columns[i].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
                    }
                }
            }
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
                    var columnValue = (dgvRow.Cells[index].Value).ObjectValidation();
                    //var value = Convert.ToInt32(dgvRow.Cells[index].Value.ToString());
                    if (dgvRow.Cells[index].Value is null)
                    {
                        continue;
                    }
                    newEmployeeBillingData.Add(columnName, columnValue);
                }
                   
            employeeBillingDetails.Add(newEmployeeBillingData);
            }
            
        }

        private void BillingAttributeList2Display()
        {//Populate the RichTextBox with Billing Slip for Printing
            rtbBillingSlip.Text += "CCS - Manpower & Allied Services \n";
            rtbBillingSlip.Text += "1251 Miranda Street, Sto. Rosario, Angeles City \n\n";
            rtbBillingSlip.Text += "ProjectName: "+ projectName + "\n";
            rtbBillingSlip.Text += "Services rendered for the period: "+ DateTime.Now + "\n";
            rtbBillingSlip.Text += "\n----------------------------------------------------------------------------------------------------------------------------------\n";
            rtbBillingSlip.Text += "Employee Name\t\t\t Hrs/Days\t Rate \t\t Amount"; //Title
            rtbBillingSlip.Text += "\n----------------------------------------------------------------------------------------------------------------------------------\n";
            foreach (DataGridViewRow dgvRow in dgvEmployeeList4Billing.Rows)
            {
                var fname = dgvRow.Cells[1].Value;
                var lname = dgvRow.Cells[2].Value;
                decimal projectRate = (dgvRow.Cells[4].Value).ToString().ToDecimal();
                decimal regDaysAmount = (dgvRow.Cells[6].Value).ToString().ToDecimal();
                decimal total = 0;

                rtbBillingSlip.Text += lname + ", " + fname + "\t";
                rtbBillingSlip.Text += " \t\t" + dgvRow.Cells[5].Value + "\t\t" + dgvRow.Cells[4].Value + "\t\t" + regDaysAmount + "\n";
                for (int i = 7; i < dgvRow.Cells.Count; i++)
                {
                    decimal amount = 0;
                    string key = dgvEmployeeList4Billing.Columns[i].HeaderText;
                    object value = dgvRow.Cells[i].Value;
                    decimal rate = Convert.ToDecimal((value).ObjectValidation());
                    if (rate == 0)
                    {
                        grandTotalAmount = total + regDaysAmount;
                        continue;
                    }
                    else
                    {
                        
                        if (key.Contains("Rate"))
                        {
                            decimal render = Convert.ToDecimal(dgvRow.Cells[i - 1].Value.ToString());
                            amount = rate * render;
                            rtbBillingSlip.Text += rate + "\t\t" + amount + "\n";
                        }
                        else
                        {
                            rtbBillingSlip.Text += "    " + key + "\t\t\t" + rate + "\t\t";
                        }
                    }
                    total += amount;
                    grandTotalAmount = total + regDaysAmount;
                }
                rtbBillingSlip.Text += "\n----------------------------------------------------------------------------------------------------------------------------------\n";
                rtbBillingSlip.Text += "                                                                                                            Subtotal: " + grandTotalAmount.ToPhpCurrencyFormat() + "\n";
                
                rtbBillingSlip.Text += "\n";
                gross += grandTotalAmount;
            }

            rtbBillingSlip.Text += "\n\t\t-----------------------------------------------------------------\n";
            rtbBillingSlip.Text += "\t\tSales: " + "\t\t\t" + gross.ToPhpCurrencyFormat();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProject.SelectedItem.Equals("Select")) return;

            // Get the selected item from the ComboBox
            KeyValuePair<int, string> selectedProject = (KeyValuePair<int, string>)cmbProject.SelectedItem;

            // Access the selected project ID and name
            projectID = selectedProject.Key;
            projectName = selectedProject.Value;

            dgvEmployeeList4Billing.DataSource = null;
            SetDefaultWorkDaysRate();
            LoadProjectEmployees(projectID, dateBillingPicker.Value);
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            gross = 0;
            grandTotalAmount = 0;
            rtbBillingSlip.Clear();
            BillingAttributeListProcessing();
            BillingAttributeList2Display();
            txtGrossTotal.Text = gross.ToPhpCurrencyFormat();

            ValidationHelper.SingleEnableControls(btnCalculate, true);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            vat = Convert.ToDecimal(txtVAT.Text);
            net = gross + vat;
            txtNetTotal.Text = net.ToPhpCurrencyFormat();

            rtbBillingSlip.Text += "\n\t\tVat: " + "\t\t\t" + vat.ToPhpCurrencyFormat();
            rtbBillingSlip.Text += "\n\t\t-----------------------------------------------------------------\n";
            rtbBillingSlip.Text += "\t\tGrand Total: " + "\t\t" + net.ToPhpCurrencyFormat();
            
            BillingSaveQuery();

            ValidationHelper.SingleEnableControls(btnPrint, true);
        }

        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(txtVAT.Text) && !string.IsNullOrEmpty(txtGrossTotal.Text) && !string.IsNullOrEmpty(txtNetTotal.Text);
        }

        private void BillingSaveQuery()
        {
            QueryProcessor billingSaveQueryProcessor = new QueryProcessor();
            billingSaveQueryProcessor.ExecuteSqlBillingInsertQuery(DateTime.Today, DateTime.Today, gross, vat, projectID, net, () =>
            {
                MessageBox.Show("Billing slip Saved.");
            }, () =>
            {
                MessageBox.Show("Problem Saving the Billing slip of the Project.");
            });
        }



        #region GroupBox Button Logics
        private void EndOfRecordCheck(int currentID)//Validation on End of Record
        {
            if ((currentID > slideValue) || (currentID <= 0) || (currentID > slideValue))
            {
                MessageBox.Show("End of the Record.");
                ValidationHelper.SingleEnableControls(btnGenerate, true);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentID = (currentID >= (dgvEmployeeList4Billing.Rows.Count - slideValue)) ? (dgvEmployeeList4Billing.Rows.Count - slideValue) : (currentID + slideValue);

            LoadBillingWorkdaysOnGroupbox(currentID);

            EndOfRecordCheck(currentID);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentID = (currentID <= 0) ? 0 : (currentID - slideValue);

            LoadBillingWorkdaysOnGroupbox(currentID);

            EndOfRecordCheck(currentID);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!txtRegDays.Text.Equals("0.0"))
            {
                dgvEmployeeList4Billing.Rows[currentID].Cells[6].Value = txtRegDaysRate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[8].Value = txtRegOTRate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[10].Value = txtSplHolidaysRate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[12].Value = txtSplHolidaysOTRate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[14].Value = txtRegHolidaysRate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[16].Value = txtRegHolidaysOTRate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[18].Value = txtRegHolRestDayRate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[20].Value = txtCOLARate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[22].Value = txtPDARate.Text;
                dgvEmployeeList4Billing.Rows[currentID].Cells[24].Value = txtOthersRate.Text;

                currentID = (currentID >= (dgvEmployeeList4Billing.Rows.Count - slideValue)) ? (dgvEmployeeList4Billing.Rows.Count - slideValue) : (currentID + slideValue);

                LoadBillingWorkdaysOnGroupbox(currentID);
            }
            else
            {
                MessageBox.Show("Please input proper Workdays rate","Try Again",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            EndOfRecordCheck(currentID);
        }
        #endregion


        #region Printing | Saving to Word Section
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();

            CreateWordDocument();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtbBillingSlip.Text, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void CreateWordDocument()
        {
            Word.Application _word = new Word.Application();
            Word.Document _document = _word.Documents.Add();
            Word.Range _range = _document.Range(0, 0);

            // Set margins style to Narrow
            SetNarrowMargins(_document);

            try
            {
                _document = _word.ActiveDocument;

                _range.Text = rtbBillingSlip.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CleanUpWordObjects(_word, _document);
            }
        }

        private void CleanUpWordObjects(Word.Application wordApp, Word.Document document)
        {
            if (document != null)
            {
                try
                {
                    wordApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Marshal.ReleaseComObject(document);
                    Marshal.ReleaseComObject(wordApp);
                }
            }
        }

        private void SetNarrowMargins(Word.Document document)
        {
            Word.Application wordApp = document.Application;
            float marginSize = 0.5f; // inches
            document.PageSetup.LeftMargin = wordApp.InchesToPoints(marginSize);
            document.PageSetup.RightMargin = wordApp.InchesToPoints(marginSize);
            document.PageSetup.TopMargin = wordApp.InchesToPoints(marginSize);
            document.PageSetup.BottomMargin = wordApp.InchesToPoints(marginSize);
        }


        #endregion
    }
}
