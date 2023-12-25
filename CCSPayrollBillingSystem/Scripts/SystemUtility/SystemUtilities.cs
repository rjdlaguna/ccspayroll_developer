namespace CCSPayrollBillingSystem.Scripts
{
    public class SystemUtilities
    {
        public static string GetConnectionString()
        {
            return @"Data Source=(localdb)\ProjectsV13;Initial Catalog=db_PayrollBilling;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }

    public static class Constants
    {
        //Users
        public const string ADMIN = "admin";
        public const string USER1 = "user1";
        public const string USER2 = "user2";
        public const string DEFAULT_VALUE = "0.0";
        
        //Rates
        public const double REG_OT_RATE = 1.25;
        public const decimal SUN_SP_HOLIDAYS_RATE = 1.30M;
        public const double SP_HOLIDAYS_OT_RATE = 1.69;
        public const decimal REST_REG_HOLIDAYS_RATE = 2.60M;
        public const double REST_REG_HOLIDAYS_OT_RATE = 3.38;
        public const decimal REG_HOLIDAYS_RATE = 2.0M;
        public const double REG_HOLIDAYS_OT_RATE = 2.6;
        public const double MAX_HRS_WORKED_RATE = 8;
        
        public const double NSD_RATE = 0.10;
    }

    public static class BillingConstants
    {
        //Billing Workdays
        public const string REG_DAYS = "RegularDays";
        public const string REG_DAYS_OT = "RegularDaysOT";
        public const string SPL_DAYS = "SplHolidays";
        public const string SPL_DAYS_OT = "SplHolidayOT";
        public const string REG_HOLIDAY = "RegularHoliday";
        public const string REG_HOLIDAY_OT = "RegularHolidayOT";
        public const string REG_HOL_RESTDAY = "RegHolRestday";
        public const string COLA = "COLA";
        public const string PDA = "PDA";
        public const string OTHERS = "Others";
    }

    public class WorkDaysComputation
    {
        public static decimal BillingRateState(string rate, decimal baseRate, double n)
        {
            decimal billingOTResult = 0;
            switch (rate)
            {
                case BillingConstants.REG_DAYS:
                    billingOTResult = RegularDays(baseRate, n);
                    break;
                case BillingConstants.REG_DAYS_OT:
                    billingOTResult = RegularDaysOT(baseRate, n);
                    break;
                case BillingConstants.SPL_DAYS:
                    billingOTResult = SunOrSpecialHolidays(baseRate, n);
                    break;
                case BillingConstants.SPL_DAYS_OT:
                    billingOTResult = SpecialHolidaysOT(baseRate, n);
                    break;
                case BillingConstants.REG_HOLIDAY:
                    billingOTResult = RegularHolidays(baseRate, n);
                    break;
                case BillingConstants.REG_HOLIDAY_OT:
                    billingOTResult = RegularHolidaysOT(baseRate, n);
                    break;
                case BillingConstants.REG_HOL_RESTDAY:
                    billingOTResult = RestDayAndRegularHolidays(baseRate, n);
                    break;
                case BillingConstants.COLA:
                    billingOTResult = COLA(baseRate);
                    break;
                case BillingConstants.PDA:
                    billingOTResult = PDA(baseRate);
                    break;
                case BillingConstants.OTHERS:
                    billingOTResult = Others(baseRate);
                    break;
                default:
                    billingOTResult = 0;
                    break;
            }

            return billingOTResult;
        }

        public static decimal RegularDays(decimal baseRate, double noOfDays)
        {
            return baseRate * (decimal)noOfDays;
        }
        public static decimal RegularDaysOT(decimal baseRate, double noOfHours)
        {
            return ((decimal)noOfHours * RegularDaysOTRate(baseRate, noOfHours));
        }
        public static decimal SunOrSpecialHolidays(decimal baseRate, double noOfDays)
        {
            return (decimal)noOfDays * SunOrSpecialHolidaysRate(baseRate, noOfDays);
        }
        public static decimal SpecialHolidaysOT(decimal baseRate, double noOfHours)
        {
            return (decimal)noOfHours * SpecialHolidaysOTRate(baseRate, noOfHours);
        }
        public static decimal RegularHolidays(decimal baseRate, double noOfDays)
        {
            return (decimal)noOfDays * RegularHolidaysRate(baseRate, noOfDays);
        }
        public static decimal RegularHolidaysOT(decimal baseRate, double noOfHours)
        {
            return (decimal)noOfHours * RegularHolidaysOTRate(baseRate, noOfHours);
        }
        public static decimal RestDayAndRegularHolidays(decimal baseRate, double noOfDays)
        {
            return (decimal)noOfDays * RestDayAndRegularHolidaysRate(baseRate, noOfDays);
        }

        public static decimal COLA(decimal valueCOLA)
        {
            return valueCOLA;
        }
        public static decimal PDA(decimal valuePDA)
        {
            return valuePDA;
        }
        public static decimal Others(decimal valueOthers)
        {
            return valueOthers;
        }

        public static decimal NightShiftDifferential(decimal baseRate, float noOfHoursInNSD)
        {
            return ((baseRate / (decimal)Constants.MAX_HRS_WORKED_RATE) * (decimal)Constants.NSD_RATE) * (decimal)noOfHoursInNSD;
        }


        //Rates................
        public static decimal RegularDaysOTRate(decimal baseRate, double no)
        {
            return (baseRate / (decimal)Constants.MAX_HRS_WORKED_RATE) * (decimal)Constants.REG_OT_RATE;
        }

        public static decimal SpecialHolidaysOTRate(decimal baseRate, double no)
        {
            return (baseRate / (decimal)Constants.MAX_HRS_WORKED_RATE) * (decimal)Constants.SP_HOLIDAYS_OT_RATE;
        }

        public static decimal SunOrSpecialHolidaysRate(decimal baseRate, double no)
        {
            return (baseRate * Constants.SUN_SP_HOLIDAYS_RATE);
        }

        public static decimal RegularHolidaysRate(decimal baseRate, double no)
        {
            return ((baseRate) * Constants.REG_HOLIDAYS_RATE);
        }

        public static decimal RegularHolidaysOTRate(decimal baseRate, double no)
        {
            return ((baseRate) / (decimal)(Constants.MAX_HRS_WORKED_RATE) * (decimal)Constants.REG_HOLIDAYS_OT_RATE);
        }
        public static decimal RestDayAndRegularHolidaysRate(decimal baseRate, double no)
        {
            return ((baseRate) * Constants.REST_REG_HOLIDAYS_RATE);
        }
    }
}
