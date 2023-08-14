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
    public partial class frmBilling : Form
    {
        private int projectTestingID = 1;
        private string empFirstName;
        private string empLastName;
        public frmBilling()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryProcessor billingProcessor = new QueryProcessor();
            billingProcessor.ExecuteSqlBillingViewQuery(projectTestingID, () =>
            {
                
                
                dataGridView1.DataSource = billingProcessor.GetSqlReaderData();
            }, () =>
            {
                MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }
    }
}
