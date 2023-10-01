using System;
namespace CCSPayrollBillingSystem.Scripts
{
    [Serializable]
    public class WorkDays
    {
        public int WorkDayID { get; set; }
        public float RegularDays { get; set; }
        public float RegularDaysOT { get; set; }
        public float SplHolidays { get; set; }
        public float SplHolidayOT { get; set; }
        public float RegularHoliday { get; set; }
        public float RegularHolidayOT { get; set; }
        public float RegHolRestDay { get; set; }
        public float COLA { get; set; }
        public float PDA { get; set; }
        public float Others { get; set; }
    }
}
