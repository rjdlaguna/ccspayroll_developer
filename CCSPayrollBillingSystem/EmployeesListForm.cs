using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCSPayrollBillingSystem
{
    public partial class EmployeeListForm : Form
    {
        public EmployeeListForm()
        {
            InitializeComponent();
        }

        private void EmployeesListForm_Load(object sender, EventArgs e)
        {
            EnableDisableEmployeeTextFields(false);
        }

        private void EnableDisableEmployeeTextFields(bool isEnabled)
        {
            txteditfirstname.Enabled = isEnabled;
            txteditmiddlename.Enabled = isEnabled;
            txteditlastname.Enabled = isEnabled;
            txtedithomeaddress.Enabled = isEnabled;
            txteditcontactno.Enabled = isEnabled;
            dteditbirthdate.Enabled = isEnabled;
            dteditdatehired.Enabled = isEnabled;
            dteditcontractend.Enabled = isEnabled;
        }
    }
}
