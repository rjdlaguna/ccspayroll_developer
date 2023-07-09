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
    public partial class EmployeeListForm : Form
    {
        private string empFirstName;
        private string empLastName;

        public EmployeeListForm()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetEmployeeSearchValues();
            QueryProcessor employeeProcessor = new QueryProcessor();
            employeeProcessor.ExecuteSqlEmpDataViewQuery(empFirstName,empLastName, () =>
            {
                dgEmployeesList.DataSource = employeeProcessor.GetEmpData();
            }, () =>
            {
                MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void SetEmployeeSearchValues()
        {
            empFirstName = txtsearchfirstname.Text;
            empLastName = txtsearchlastname.Text;
        }

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            QueryProcessor employeeProcessor = new QueryProcessor();
            employeeProcessor.ExecuteSqlEmpDataViewQuery(empFirstName, empLastName, () =>
             {
                 dgEmployeesList.DataSource = employeeProcessor.GetEmpData();
                 ConvertToDateValue();
                 dgEmployeesList.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
             }, () =>
             {
                 MessageBox.Show("Problem listing all employees.");
             });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dgEmployeesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txteditfirstname.Text = dgEmployeesList.SelectedRows[0].Cells[0].Value.ToString();
            txteditmiddlename.Text = dgEmployeesList.SelectedRows[0].Cells[1].Value.ToString();
            txteditlastname.Text = dgEmployeesList.SelectedRows[0].Cells[2].Value.ToString();
            txtedithomeaddress.Text = dgEmployeesList.SelectedRows[0].Cells[3].Value.ToString();
            txteditcontactno.Text = dgEmployeesList.SelectedRows[0].Cells[4].Value.ToString();
            dteditbirthdate.Text = dgEmployeesList.SelectedRows[0].Cells[5].Value.ToString();
            dteditdatehired.Text = dgEmployeesList.SelectedRows[0].Cells[6].Value.ToString();
            dteditcontractend.Text = dgEmployeesList.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void ConvertToDateValue()
        {
            // Assuming the desired columns are the second and third columns (0-based index)
            int[] dateColumns = { 5, 6, 7 };

            foreach (DataGridViewRow row in dgEmployeesList.Rows)
            {
                foreach (int columnIndex in dateColumns)
                {
                    if (row.Cells[columnIndex].Value != null)
                    {
                        string dateString = row.Cells[columnIndex].Value.ToString();
                        DateTime date;

                        if (DateTime.TryParse(dateString, out date))
                        {
                            row.Cells[columnIndex].Value = date.ToShortDateString();
                        }
                        else
                        {
                            // Handle the case when the string cannot be parsed as a valid date
                            // For example, set a default value or display an error message
                        }
                    }
                }
            }

        }
    }
}
