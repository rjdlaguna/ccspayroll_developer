using System;
using System.Windows.Forms;
using System.Globalization;

namespace CCSPayrollBillingSystem.Scripts
{
    public static class CurrencyFormatter
    {
        public static string ToPhpCurrencyFormat(this decimal currency)
        {
            NumberFormatInfo nfi = new CultureInfo("en-PH", false).NumberFormat;
            string curr = currency.ToString("C", nfi);
            return curr;
        }
    }

    public static class Helper
    {
        public static bool IsNullOrValue(this float? value, float valueToCheck)
        {
            return (value ?? valueToCheck) == valueToCheck;
        }

        public static float ToFloat(this string numberValue)
        {
            if (float.TryParse(numberValue, out float result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid numberValue");
            }
        }

        public static decimal ToDecimal(this string numberValue)
        {
            return Convert.ToDecimal(numberValue);
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

            if (control is ComboBox cmb)
            {
                return string.IsNullOrEmpty(cmb.Text);
            }
            return true;
        }

        public static void SingleEnableControls(Control control, bool status)
        {
            control.Enabled = status;
        }

        public static void ResetDefaultValueTextBoxControls(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.Text = "0.0";
            }
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

        public static void EnableGroupBoxControls(Control control, bool status)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is GroupBox)
                {
                    controlItem.Enabled = status;
                    if (controlItem.Name.Contains("gb"))
                    {
                        controlItem.Enabled = status;
                    }
                }
            }

        }
    }
    
}
