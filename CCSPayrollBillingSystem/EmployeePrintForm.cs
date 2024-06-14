using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using CCSPayrollBillingSystem.Scripts;
using CCSPayrollBillingSystem.Scripts.SystemUtility;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using CCSPayrollBillingSystem.Scripts.Data;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeePrintForm : Form
    {
        
        public int empIdPayroll;
        public string empFnamePayroll;
        public string empLnamePayroll;
        public decimal empRatePayroll;
        public string empRankPayroll;

        private string payrolSlipText;
        
        private string dateFrom;
        private string dateTo;

        private int projectID;
        private string projectName;

        private int defaultColumn = 2; 

        EmployeeListForPayroll employeeListForPayroll = new EmployeeListForPayroll();
        EmployeePayrollDate employeePayrollDate = new EmployeePayrollDate();

        PaySlipData _paySlipData = new PaySlipData();
        
        List<PayrollSummary> _payrollSummary = new List<PayrollSummary>();
        List<PaySlipData> _paySlipDataListItems = new List<PaySlipData>();
        List<string> paySlip2WordDocumentList = new List<string>();
        List<Dictionary<string, object>> keyPayrollSummaryValues = new List<Dictionary<string, object>>();

        private ProjectProcessor projectProcessor;
        private IDictionary<int, string> projectInfo;

        public EmployeePrintForm()
        {
            InitializeComponent();
            projectProcessor = new ProjectProcessor();
        }

        private void Init(PayrollData payroll, WorkDays work)
        {
            _paySlipData.PayrollData = payroll;
            _paySlipData.WorkDays = work;
        }

        private void EmployeePrintForm_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-PH");
            employeeListForPayroll.OnEmployeeSearchedValues += LoadSearchedEmployeeDetails;
            employeePayrollDate.OnPayrollDateSelected += SetPayrollDates;
            projectInfo = projectProcessor.ProjectInfo;
            
            cmbProject.DataSource = new BindingSource(projectInfo, null);
            cmbProject.DisplayMember = "Value";
            cmbProject.ValueMember = "Key";

            ValidationHelper.SingleEnableControls(btnSearch, false);
            ValidationHelper.SingleEnableControls(btnGenerate, false);
            ValidationHelper.SingleEnableControls(btnPreview, false);
        }

        private void SetPayrollDates(string from, string to)
        {
            dateFrom = from;   
            dateTo = to;
        }

        private void InitializePayrollSummary()
        {
            // Convert list of dictionaries to list of PayrollSummary objects
            _payrollSummary = keyPayrollSummaryValues
                .Select(row => new PayrollSummary
                {
                    EmpID = Convert.ToInt32(row["EmployeeID"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    MiddleName = row["MiddleName"].ToString(),
                    ProjectName = row["ProjectName"].ToString(),
                    PayRate = Convert.ToDecimal(row["ProjectRate"]),
                    SSSAmount = Convert.ToDecimal(row["SSS"]),
                    PagIbigAmount = Convert.ToDecimal(row["PagIbig"]),
                    PhilHealthAmount = Convert.ToDecimal(row["PhilHealth"]),
                    PayrollOthers = Convert.ToDecimal(row["Others"]),
                    GrossSalary = Convert.ToDecimal(row["Gross"]),
                    NetSalary = Convert.ToDecimal(row["NET"])
                })
                .ToList();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the ComboBox
            KeyValuePair<int, string> selectedProject = (KeyValuePair<int, string>)cmbProject.SelectedItem;

            // Access the selected project ID and name
            projectID = selectedProject.Key;
            projectName = selectedProject.Value;
        }

        private void LoadSearchedEmployeeDetails(Employee emp)
        {
            empIdPayroll = emp.EmpIdPayroll;
            empFnamePayroll = emp.EmpFnamePayroll;
            empLnamePayroll = emp.EmpLnamePayroll;
            empRatePayroll = emp.EmpPayRatePayroll;
            empRankPayroll = emp.EmpRankPayroll;

            txtEmployeeName.Text = empFnamePayroll + " " + empLnamePayroll;
            txtBaseRate.Text = empRatePayroll.ToString();
            txtRank.Text = empRankPayroll;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.IfNullOrEmpty(cmbPrintFilter))
            {
                MessageBox.Show("Please select proper Print Filter!");
            }
            else if (cmbPrintFilter.SelectedItem.Equals("PaySlip"))
            {
                employeeListForPayroll.ShowDialog();
            }
            else if (cmbPrintFilter.SelectedItem.Equals("PaySlip Per Project"))
            {
                MessageBox.Show("Print All! \n Please click Generate button to process Document");
            }
            else if (cmbPrintFilter.SelectedItem.Equals("Payroll Summary"))
            {
                MessageBox.Show("Printing Preview! \n Please click Generate button to process Document");
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e) //Payslip on solo employee
        {
            rtbPayrollSlip.Clear();
            if (cmbPrintFilter.SelectedItem.Equals("PaySlip"))
            {
                employeePayrollDate.ShowDialog();
                
                QueryProcessor payrollSearchProcessor = new QueryProcessor();

                //projectName = payrollSearchProcessor.ExecuteSqlEPRQueryReturnProjectID(empIdPayroll);

                payrollSearchProcessor.ExecuteSqlPayrollSearchQuery(empIdPayroll, dateFrom, dateTo, (payroll, work) =>
                {
                    Init(payroll, work);
                    GenerateSinglePaySlip();
                }, () =>
                {
                    MessageBox.Show("Problem loading employee payroll information.");
                });
                
            }
            else if (cmbPrintFilter.SelectedItem.Equals("PaySlip Per Project"))
            {
                employeePayrollDate.ShowDialog();
                _paySlipDataListItems.Clear();

                QueryProcessor payrollSearchAllProcessor = new QueryProcessor();

                payrollSearchAllProcessor.ExecuteSqlPayrollAllSearchQuery(dateFrom, dateTo, projectID, (payslipListFromQuery) =>
                {
                    _paySlipDataListItems = payslipListFromQuery;
                    GenerateAllPaySlip();
                }, () =>
                {
                    MessageBox.Show("Problem loading All employee payroll information.");
                });
            }

        }

        private void GenerateSinglePaySlip()
        {
            // Clear the existing content of paySlipWordDocumentList
            paySlip2WordDocumentList.Clear();
            payrolSlipText = string.Empty;

            //payrolSlipText += "-----------------------------------------------------------------------------------\n";
            payrolSlipText += "                                            CCS Payslip                              \n\n";
            //payrolSlipText += "-----------------------------------------------------------------------------------\n";
            payrolSlipText += "Payroll Date: " + dateFrom + " to " + dateTo + "\n";
            payrolSlipText += "Name: " + empLnamePayroll + ", " + empFnamePayroll + "\n";
            payrolSlipText += "Project: "+ projectName +"\n\n";

            payrolSlipText += "Regular Days\t: \t" + _paySlipData.WorkDays.RegularDays + "\t" + (WorkDaysComputation.RegularDays(empRatePayroll, _paySlipData.WorkDays.RegularDays).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Regular OT\t: \t" + _paySlipData.WorkDays.RegularDaysOT + "\t" + (WorkDaysComputation.RegularDaysOT(empRatePayroll, _paySlipData.WorkDays.RegularDaysOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Sp Hol Sun\t: \t" + _paySlipData.WorkDays.SplHolidays + "\t" + (WorkDaysComputation.SunOrSpecialHolidays(empRatePayroll, _paySlipData.WorkDays.SplHolidays).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Sp Hol OT\t: \t" + _paySlipData.WorkDays.SplHolidayOT + "\t" + (WorkDaysComputation.SpecialHolidaysOT(empRatePayroll, _paySlipData.WorkDays.SplHolidayOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Regular Holiday\t: \t" + _paySlipData.WorkDays.RegularHoliday + "\t" + (WorkDaysComputation.RegularHolidays(empRatePayroll, _paySlipData.WorkDays.RegularHoliday).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Reg Hol OT\t: \t" + _paySlipData.WorkDays.RegularHolidayOT + "\t" + (WorkDaysComputation.RegularHolidaysOT(empRatePayroll, _paySlipData.WorkDays.RegularHolidayOT).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "Reg Hol Rest Day\t: \t" + _paySlipData.WorkDays.RegHolRestDay + "\t" + (WorkDaysComputation.RestDayAndRegularHolidays(empRatePayroll, _paySlipData.WorkDays.RegHolRestDay).ToPhpCurrencyFormat()) + "\n";
            payrolSlipText += "COLA\t: \t\t" + _paySlipData.WorkDays.COLA + "\t" + (WorkDaysComputation.COLA(_paySlipData.WorkDays.COLA.ToString().ToDecimal())).ToPhpCurrencyFormat() + "\n";
            payrolSlipText += "PDA\t: \t\t" + _paySlipData.WorkDays.PDA + "\t" + (WorkDaysComputation.PDA(_paySlipData.WorkDays.PDA.ToString().ToDecimal())).ToPhpCurrencyFormat() + "\n";
            payrolSlipText += "Others\t: \t\t" + _paySlipData.WorkDays.Others + "\t" + (WorkDaysComputation.Others(_paySlipData.WorkDays.Others.ToString().ToDecimal()).ToPhpCurrencyFormat()) + "\n\n";
            payrolSlipText += "GROSS PAY\t: " + (_paySlipData.PayrollData.GrossSalary).ToPhpCurrencyFormat() + "\n\n";
            payrolSlipText += "Less: \n";
            payrolSlipText += "  SSS/MED\t: " + _paySlipData.PayrollData.SSSAmount + "\n";
            payrolSlipText += "  PagIbig\t\t: " + _paySlipData.PayrollData.PagIbigAmount + "\n";
            payrolSlipText += "  PhilHealth\t: " + _paySlipData.PayrollData.PhilHealthAmount + "\n";
            payrolSlipText += "  Others\t\t: " + _paySlipData.PayrollData.PayrollOthers + "\n\n";
            payrolSlipText += "NET PAY\t\t: " + (_paySlipData.PayrollData.NetSalary).ToPhpCurrencyFormat() + "\n\n";
            payrolSlipText += "I certify that I have received the above amount.\n";

            paySlip2WordDocumentList.Add(payrolSlipText);
            rtbPayrollSlip.Text = payrolSlipText;
        }

        private void GenerateAllPaySlip() //Generate all payslips of the employees
        {
            // Clear the existing content of paySlipWordDocumentList
            paySlip2WordDocumentList.Clear();
            rtbPayrollSlip.Clear();

            foreach (PaySlipData paySlipData in _paySlipDataListItems)
            {
                payrolSlipText = string.Empty;
                //payrolSlipText += "-----------------------------------------------------------------------------------\n";
                payrolSlipText += "                                            CCS Payslip                              \n\n";
                //payrolSlipText += "-----------------------------------------------------------------------------------\n";
                payrolSlipText += "Payroll Date: " + dateFrom + " to " + dateTo + "\n";
                payrolSlipText += "Name: " + paySlipData.Employee.EmpLastName + ", " + paySlipData.Employee.EmpFirstName + " " + paySlipData.Employee.EmpMiddleName + " \n";
                payrolSlipText += "Project: " + paySlipData.ProjectName + "\n\n";

                payrolSlipText += "Regular Days\t: \t" + paySlipData.WorkDays.RegularDays + "\t" + (WorkDaysComputation.RegularDays(paySlipData.PayRate, paySlipData.WorkDays.RegularDays).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Regular OT\t: \t" + paySlipData.WorkDays.RegularDaysOT + "\t" + (WorkDaysComputation.RegularDaysOT(paySlipData.PayRate, paySlipData.WorkDays.RegularDaysOT).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Sp Hol Sun\t: \t" + paySlipData.WorkDays.SplHolidays + "\t" + (WorkDaysComputation.SunOrSpecialHolidays(paySlipData.PayRate, paySlipData.WorkDays.SplHolidays).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Sp Hol OT\t: \t" + paySlipData.WorkDays.SplHolidayOT + "\t" + (WorkDaysComputation.SpecialHolidaysOT(paySlipData.PayRate, paySlipData.WorkDays.SplHolidayOT).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Regular Holiday\t: \t" + paySlipData.WorkDays.RegularHoliday + "\t" + (WorkDaysComputation.RegularHolidays(paySlipData.PayRate, paySlipData.WorkDays.RegularHoliday).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Reg Hol OT\t: \t" + paySlipData.WorkDays.RegularHolidayOT + "\t" + (WorkDaysComputation.RegularHolidaysOT(paySlipData.PayRate, paySlipData.WorkDays.RegularHolidayOT).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "Reg Hol Rest Day\t: \t" + paySlipData.WorkDays.RegHolRestDay + "\t" + (WorkDaysComputation.RestDayAndRegularHolidays(paySlipData.PayRate, paySlipData.WorkDays.RegHolRestDay).ToPhpCurrencyFormat()) + "\n";
                payrolSlipText += "COLA\t: \t\t" + paySlipData.WorkDays.COLA + "\t" + (WorkDaysComputation.COLA(decimal.Parse(paySlipData.WorkDays.COLA.ToString()))).ToPhpCurrencyFormat() + "\n";
                payrolSlipText += "PDA\t: \t\t" + paySlipData.WorkDays.PDA + "\t" + WorkDaysComputation.PDA(decimal.Parse(paySlipData.WorkDays.PDA.ToString())).ToPhpCurrencyFormat() + "\n";
                payrolSlipText += "Others\t: \t\t" + paySlipData.WorkDays.Others + "\t" + (WorkDaysComputation.Others(decimal.Parse(paySlipData.WorkDays.Others.ToString())).ToPhpCurrencyFormat()) + "\n\n";
                payrolSlipText += "GROSS PAY\t: " + (paySlipData.PayrollData.GrossSalary).ToPhpCurrencyFormat() + "\n\n";
                payrolSlipText += "Less: \n";
                payrolSlipText += "  SSS/MED\t: " + paySlipData.PayrollData.SSSAmount + "\n";
                payrolSlipText += "  PagIbig\t\t: " + paySlipData.PayrollData.PagIbigAmount + "\n";
                payrolSlipText += "  PhilHealth\t: " + paySlipData.PayrollData.PhilHealthAmount + "\n";
                payrolSlipText += "  Others\t\t: " + paySlipData.PayrollData.PayrollOthers + "\n\n";
                payrolSlipText += "NET PAY\t\t: " + (paySlipData.PayrollData.NetSalary).ToPhpCurrencyFormat() + "\n\n";
                payrolSlipText += "I certify that I have received the above amount.\n";
                payrolSlipText += "-----------------------------------------------------------------------------------\n";

                paySlip2WordDocumentList.Add(payrolSlipText);
            }

            PaySlipDisplay(payrolSlipText);
        }

        private void GeneratePreview() //Generate all payslips of the employees
        {
            // Clear the existing content of paySlipWordDocumentList
            paySlip2WordDocumentList.Clear();
            rtbPayrollSlip.Clear();
            payrolSlipText = string.Empty;

            decimal empTotalDeduction = 0M;
            int counter = 1;
            decimal totalDeduction = 0;

            payrolSlipText += "CCS - Manpower & Allied Services \n";
            payrolSlipText += "1251 Miranda Street, Sto. Rosario, Angeles City \n\n";
            payrolSlipText += "Payroll Summary \n\n";
            payrolSlipText += "Payroll for the period: " + dateFrom + " to " + dateTo + "\n";
            payrolSlipText += "Project : " + cmbProject.Text + "\n";
            payrolSlipText += "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n";
            payrolSlipText += "EMPLOYEE NAME                GROSS PAY                DEDUCTION                NET PAY                SIGNATURE   \n";
            payrolSlipText += "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n";
            foreach (PayrollSummary paySlipData in _payrollSummary)
            {
                empTotalDeduction = 0M;
                empTotalDeduction = paySlipData.SSSAmount + paySlipData.PhilHealthAmount + paySlipData.PagIbigAmount + paySlipData.PayrollOthers;
                payrolSlipText += counter + ". " + paySlipData.LastName + ", " + paySlipData.FirstName + " \t\t" +
                    paySlipData.GrossSalary.ToPhpCurrencyFormat() + "\t" + empTotalDeduction.ToPhpCurrencyFormat() + "\t\t" + paySlipData.NetSalary.ToPhpCurrencyFormat() +
                    "\t____________________ \n";

                counter++;
                paySlip2WordDocumentList.Add(payrolSlipText);
                totalDeduction += empTotalDeduction;
            }
            payrolSlipText += "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n";

            decimal totalGrossSalary = _payrollSummary.Sum(p => p.GrossSalary);
            decimal totalNetSalary = _payrollSummary.Sum(p => p.NetSalary);

            payrolSlipText += "\t\t\t" + totalGrossSalary.ToPhpCurrencyFormat() + "\t" + totalDeduction.ToPhpCurrencyFormat() + "\t\t" + totalNetSalary.ToPhpCurrencyFormat() + "\n\n";

            payrolSlipText += "\t\tApproved for Payment: \t\t\t Date of Payment: \n\n";
            payrolSlipText += "\t\t____________________ \t\t\t ____________________ \n";
            payrolSlipText += "\t\t      General Manager \t\t\t                      \n\n";
            payrolSlipText += "I HEREBY CERTIFY that I have personally paid in cash to each employee whose \n";
            payrolSlipText += "name appears in the above payroll the amount set opposite his/her name. \n";
            payrolSlipText += "The total amount paid in this payroll is " + totalNetSalary.ToPhpCurrencyFormat() + " \n";
            payrolSlipText += "                                 \t\t\t ____________________ " + " \n";
            payrolSlipText += "                                       \t\t\t\tPaymaster " + " \n";

            PaySlipDisplay(payrolSlipText);
        }

        private void CreateWordDocument(bool isSummary)
        {
            Word.Application _word = new Word.Application();
            Word.Document _document = _word.Documents.Add();
            Word.Paragraph content = _document.Content.Paragraphs.Add();
            Word.Range _range = _document.Range(0, 0);

            // Set margins style to Narrow
            SetNarrowMargins(_document);

            try
            {
                _document = _word.ActiveDocument;

                if (isSummary)//checks if the to-be printed documents were Payroll Preview
                {
                    for (int i = 0; i < paySlip2WordDocumentList.Count; i++)
                    {
                        content.Range.Text = payrolSlipText;
                    }
                }
                else
                {
                    // Calculate the number of rows needed based on the number of elements in paySlipWordDocumentList
                    int numRows = (int)Math.Ceiling((double)(paySlip2WordDocumentList.Count / defaultColumn));

                    if (numRows <= 0) numRows = 1;

                    Word.Table _wdTable = _document.Tables.Add(_range, numRows, defaultColumn);
                    int row = 1;
                    int column = 1;

                    foreach (var item in paySlip2WordDocumentList)
                    {
                        _wdTable.Cell(row, column).Range.InsertAfter(item.ToString());
                        column++;
                        if (column > defaultColumn)
                        {
                            column = 1;
                            row++;
                        }
                    }  
                }

                content.Format.SpaceAfter = 0f;
                content.Format.SpaceBefore = 0f;
                content.Format.LineSpacing = 1;
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

        private void CreateWordDocumentPreview()
        {
            Word.Application _word = new Word.Application();
            Word.Document _document = _word.Documents.Add();
            Word.Range _range = _document.Range(0, 0);

            // Set margins style to Narrow
            _document.PageSetup.LeftMargin = _word.InchesToPoints(0.5f);
            _document.PageSetup.RightMargin = _word.InchesToPoints(0.5f);
            _document.PageSetup.TopMargin = _word.InchesToPoints(0.5f);
            _document.PageSetup.BottomMargin = _word.InchesToPoints(0.5f);

            try
            {
                _document = _word.ActiveDocument;

                for (int i = 0; i < paySlip2WordDocumentList.Count; i++)
                {
                    _range.Text = (paySlip2WordDocumentList[i].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _word.Visible = true;
                _word.Quit();
                _word = null;
                _document = null;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
            bool isSummary = cmbPrintFilter.SelectedItem.Equals("Payroll Summary") ? true : false;
            CreateWordDocument(isSummary);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtbPayrollSlip.Text, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void PaySlipDisplay(string payslipText)
        {
            rtbPayrollSlip.Text += payslipText +"\t"; 
            rtbPayrollSlip.SelectAll();
            rtbPayrollSlip.SelectionTabs = new int[] { 50};
            rtbPayrollSlip.AcceptsTab = true;
            rtbPayrollSlip.Select(0, 0);
        }

        private void cmbPrintFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrintFilter.Text.Equals("PaySlip"))
            {
                ValidationHelper.SingleEnableControls(btnSearch, true);
                ValidationHelper.SingleEnableControls(btnGenerate, true);
                ValidationHelper.SingleEnableControls(btnPreview, false);
            }
            else if(cmbPrintFilter.Text.Equals("PaySlip Per Project")){
                ValidationHelper.SingleEnableControls(btnSearch, false);
                ValidationHelper.SingleEnableControls(btnGenerate, true);
                ValidationHelper.SingleEnableControls(btnPreview, false);
            }
            else
            {
                ValidationHelper.SingleEnableControls(btnSearch, false);
                ValidationHelper.SingleEnableControls(btnGenerate, false);
                ValidationHelper.SingleEnableControls(btnPreview, true);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            employeePayrollDate.ShowDialog();

            QueryProcessor payrollSearchAllProcessor = new QueryProcessor();

            keyPayrollSummaryValues = payrollSearchAllProcessor.ExecuteSqlPayrollSummaryQuery(dateFrom, dateTo, projectID);
            
            InitializePayrollSummary(); //Initialize the SQL result to PayrollSummary data
            GeneratePreview(); //Display it to the RichTextBox and reflect to the Word Document
        }

        
    }
}
