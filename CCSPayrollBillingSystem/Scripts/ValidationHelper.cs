using System;
using System.Windows.Forms;
using System.Globalization;

namespace CCSPayrollBillingSystem.Scripts
{
    public class CurrencyFormatter
    {
        public static string ToCurrencyFormat(decimal currency)
        {
            NumberFormatInfo nfi = new CultureInfo("en-PH", false).NumberFormat;
            string curr = currency.ToString("C", nfi);
            return curr;
        }
    }

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

        public static void ClearControls(Control control)
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
                        if (item is TextBox)
                        {
                            ((TextBox)item).Clear();
                        }
                    }
                }
            }
        }

        public static void ResetControls(Control control)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                {
                    ((TextBox)controlItem).Text = "0";
                }
                if (controlItem is GroupBox)
                {
                    foreach (Control item in controlItem.Controls)
                    {
                        if (item is TextBox)
                        {
                            ((TextBox)item).Text = "0";
                        }
                    }
                }
            }
            
        }

        public static void EnableControls(Control control, bool status)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                {
                    ((TextBox)controlItem).Enabled = status;
                }
                if (controlItem is GroupBox)
                {
                    controlItem.Enabled = status;
                    foreach (Control item in controlItem.Controls)
                    {
                        if (controlItem is TextBox)
                        {
                            ((TextBox)controlItem).Enabled = status;
                        }
                    }
                    if (controlItem.Name is "groupBox1")
                    {
                        controlItem.Enabled = !status;
                    }
                }
            }
            
        }

    }
    
}
