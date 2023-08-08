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
    public partial class Projects : Form
    {
        public Projects()
        {
            InitializeComponent();
        }

        private void Projects_Load(object sender, EventArgs e)
        {

        }

        private void ClearProjectTextFields()
        {
            txtprojectname.Clear();
            txtprojectdesc.Clear();
            txtprojectaddress.Clear();
            txtpersonincharge.Clear();
            txtprojectcontact.Clear();
            txtprojectemail.Clear();
        }

        private void EnableDisableProjectTextFields(bool isEnabled)
        {
            txtprojectname.Enabled = isEnabled;
            txtprojectdesc.Enabled = isEnabled;
            txtprojectaddress.Enabled = isEnabled;
            txtpersonincharge.Enabled = isEnabled;
            txtprojectcontact.Enabled = isEnabled;
            txtprojectcontact.Enabled = isEnabled;
            txtprojectemail.Enabled = isEnabled;
        }

        private string ValidateProjectTextFields(string projname, string projdesc, string projaddress, string personincharge, string projcontact, string projemail)
        {
            string prompt = null;
            if(String.IsNullOrEmpty(projname))
            {
                txtprojectname.Focus();
                prompt = "Project Name cannot be empty.";
            }
            else if(String.IsNullOrEmpty(projaddress))
            {
                txtprojectaddress.Focus();
                prompt = "Project Address cannot be empty.";
            }
            else if(String.IsNullOrEmpty(personincharge))
            {
                txtpersonincharge.Focus();
                prompt = "Person In-Charge cannot be empty.";
            }
            else if(String.IsNullOrEmpty(projcontact))
            {
                txtprojectcontact.Focus();
                prompt = "Project Contact No. cannot be empty.";
            }

            return prompt;

        }
    }
}
