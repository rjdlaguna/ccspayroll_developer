using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSPayrollBillingSystem.Scripts
{
    public class WorkDaysRate
    {
        public int WorkDayID { get; set; }
        public decimal RegularDaysRate { get; set; }
        public decimal RegularDaysOTRate { get; set; }
        public decimal SplHolidaysRate { get; set; }
        public decimal SplHolidayOTRate { get; set; }
        public decimal RegularHolidayRate { get; set; }
        public decimal RegularHolidayOTRate { get; set; }
        public decimal RegHolRestDayRate { get; set; }
        public decimal COLARate { get; set; }
        public decimal PDARate { get; set; }
        public decimal OthersRate { get; set; }
    }
}
