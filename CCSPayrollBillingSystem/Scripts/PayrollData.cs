using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSPayrollBillingSystem.Scripts
{
    public class PayrollData
    {
        public int Payroll_ID { get; set; }
        public DateTime PayrollStartDate { get; set; }
        public DateTime PayrollEndDate { get; set; }
        public int EmpID { get; set; }
        public decimal SSSAmount { get; set; }
        public decimal PagIbigAmount { get; set; }
        public decimal PhilHealthAmount { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public int WorkDayID { get; set; }
        public decimal Tax { get; set; }
    }
}
