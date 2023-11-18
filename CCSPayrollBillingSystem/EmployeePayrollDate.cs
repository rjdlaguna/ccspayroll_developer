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
    public partial class EmployeePayrollDate : Form
    {
        public EmployeePayrollDate()
        {
            InitializeComponent();
        }

        public event Action<string, string> OnPayrollDateSelected;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = Convert.ToDateTime(dateTimePickerFrom.Value);
            DateTime dtTo = Convert.ToDateTime(dateTimePickerTo.Value);
            OnPayrollDateSelected?.Invoke(dtFrom.ToShortDateString(), dtTo.ToShortDateString());
            
            Close();
        }
    }
}
