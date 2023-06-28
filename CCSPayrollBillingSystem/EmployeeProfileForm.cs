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
    public partial class EmployeeProfileForm : Form
    {
        private string empFirstName;
        private string empLastName;
        private string empMiddleName;
        private string empHomeAddress;
        private string empContactNo;
        private DateTime empBirthDate;
        private DateTime empDateHired;
        private DateTime empContractEnd;

        public EmployeeProfileForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string promptText = null;
            SetEmployeeValues();
            lblEmpDataPrompt.Text = ValidateEmpDataFields(empFirstName, empMiddleName, empLastName, empHomeAddress, empContactNo, empBirthDate, empDateHired, empContractEnd);
            promptText = lblEmpDataPrompt.Text;
            
            if(!String.IsNullOrEmpty(promptText) || promptText == "")
            {

                QueryProcessor empDataProcessor = new QueryProcessor();
                empDataProcessor.ExecuteSqlEmpDataSaveQuery(empFirstName, empMiddleName, empLastName, empHomeAddress, empContactNo, empBirthDate, empDateHired, empContractEnd);
                MessageBox.Show(" Employee Data Successfully Saved.");
            }
        }

        private void SetEmployeeValues()
        {
            empFirstName = txtfirstname.Text;
            empMiddleName = txtmiddlename.Text;
            empLastName = txtlastname.Text;
            empHomeAddress = txthomeaddress.Text;
            empContactNo = txtcontactno.Text;
            empBirthDate = dtbirthdate.Value;
            empDateHired = dtdatehired.Value;
            empContractEnd = dtcontractend.Value;
            
        }

        private string ValidateEmpDataFields(string fname, string mname, string lname, string homeadd, string contactno, DateTime bdate, DateTime dhired, DateTime contractend)
        {
            string prompt = "";
            if (String.IsNullOrEmpty(fname))
            {
                txtfirstname.Focus();
                lblEmpDataPrompt.Text = "";
                lblEmpDataPrompt.Show();
                prompt = "First Name cannot be empty.";
            }
            else if (String.IsNullOrEmpty(lname))
            {
                txtlastname.Focus();
                lblEmpDataPrompt.Text = "";
                lblEmpDataPrompt.Show();
                prompt = "Last Name cannot be empty.";
            }
            else if (String.IsNullOrEmpty(homeadd))
            {
                txthomeaddress.Focus();
                lblEmpDataPrompt.Text = "";
                lblEmpDataPrompt.Show();
                prompt = "Home Address cannot be empty.";
            }
            else if (String.IsNullOrEmpty(contactno))
            {
                txtcontactno.Focus();
                lblEmpDataPrompt.Text = "";
                lblEmpDataPrompt.Show();
                prompt = "Contact No. cannot be empty.";
            }
            else if (GetAge(Convert.ToDateTime(bdate)) < 18)
            {
                dtbirthdate.Focus();
                lblEmpDataPrompt.Text = "";
                lblEmpDataPrompt.Show();
                prompt = "Age should be 18 years old and above. Check the date of birth.";
            }
            else
            {
                lblEmpDataPrompt.Text = "";
                lblEmpDataPrompt.Show();
                prompt = "";
            }
            return prompt;
        }

        private void EmployeeProfileForm_Load(object sender, EventArgs e)
        {
            lblEmpDataPrompt.Hide();
        }

        public static int GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now;
            int age = n.Year - birthDate.Year;
            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age;
        }


        private void ClearEmpDataTextFields()
        {
            txtfirstname.Clear();
            txtmiddlename.Clear();
            txtlastname.Clear();
            txthomeaddress.Clear();
            txtcontactno.Clear();
            dtbirthdate.Value = DateTime.Now;
            dtdatehired.Value = DateTime.Now;
            dtcontractend.Value = DateTime.Now;
        }
    }
}
