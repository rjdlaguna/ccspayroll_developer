using System;
using System.Collections.Generic;
using System.Linq;
namespace CCSPayrollBillingSystem.Scripts.Data
{
    public class PayrollSummary
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string ProjectName { get; set; }
        public decimal PayRate { get; set; }
        public decimal SSSAmount { get; set; }
        public decimal PagIbigAmount { get; set; }
        public decimal PhilHealthAmount { get; set; }
        public decimal PayrollOthers { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        
    }
}
