namespace CCSPayrollBillingSystem.Scripts
{
    [System.Serializable]
    public class PaySlipData
    {
        public PayrollData PayrollData;
        public WorkDays WorkDays;
        public EmployeePayrollData Employee;
        public decimal PayRate;
    }
}