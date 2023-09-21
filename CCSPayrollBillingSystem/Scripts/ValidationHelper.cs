using System.Windows.Forms;

namespace CCSPayrollBillingSystem.Scripts
{
    public class ValidationHelper
    {
        public static bool IfNullOrEmpty(Control control)
        {
            if (control is TextBox textBox)
            {
                return string.IsNullOrEmpty(textBox.Text);
            }
            return true;
        }
    }
}
