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

        public static void SingleEnableControls(Control control, bool status)
        {
            control.Enabled = status;
        }

        public static Control ClearControls(Control control)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                {
                    ((TextBox)controlItem).Clear();
                }
                if (controlItem is GroupBox)
                {
                    foreach (Control item in controlItem.Controls)
                    {
                        if (controlItem is TextBox)
                        {
                            ((TextBox)controlItem).Clear();
                        }
                    }
                }
            }

            return control;
        }

    }
    
}
