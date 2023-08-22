using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public const float REG_OT_RATE = 1.25F;
        public const decimal SUN_SP_HOLIDAYS_RATE = 1.30M;
        public const float SP_HOLIDAYS_OT_RATE = 1.69F;
        public const decimal REST_REG_HOLIDAYS_RATE = 2.60M;
        public const float REST_REG_HOLIDAYS_OT_RATE = 3.38F;
        public const decimal REG_HOLIDAYS_RATE = 2.0M;
        public const float REG_HOLIDAYS_OT_RATE = 2.6F;
        public const float MAX_HRS_WORKED_RATE = 8F;
        
        public const float NSD_RATE = 0.10F;
    }

    public static class BillingConstants
    {
        //Billing Workdays
        public const string REG_DAYS = "RegularDays";
        public const string REG_DAYS_OT = "RegularDayOT";
        public const string SPL_DAYS = "SplHolidays";
        public const string SPL_DAYS_OT = "SplHolidaysOT";
        public const string REG_HOLIDAY = "RegularHoliday";
        public const string REG_HOLIDAY_OT = "RegularHolidayOT";
        public const string COLA = "COLA";
        public const string PDA = "PDA";
        public const string OTHERS = "Others";
    }

    public class WorkDaysComputation
    {
        public static decimal RegularDays(decimal baseRate, double noOfDays)
        {
            return baseRate * (decimal)noOfDays;
        }
        public static decimal RegularDaysOT(decimal baseRate, double noOfHours)
        {
            return ((decimal)noOfHours) * WorkOTRateComputation.RegularDaysOTRate(baseRate);
        }
        public static decimal SunOrSpecialHolidays(decimal baseRate, double noOfDays)
        {
            return (decimal)noOfDays * (baseRate * Constants.SUN_SP_HOLIDAYS_RATE);
        }
        public static decimal SpecialHolidaysOT(decimal baseRate, double noOfHours)
        {
            return (decimal)noOfHours * WorkOTRateComputation.SpecialHolidaysOTRate(baseRate);
        }
        public static decimal RegularHolidays(decimal baseRate, double noOfDays)
        {
            return (decimal)noOfDays * ((baseRate) * Constants.REG_HOLIDAYS_RATE);
        }
        public static decimal RegularHolidaysOT(decimal baseRate, double noOfHours)
        {
            return (decimal)noOfHours * ((baseRate) / (decimal)(Constants.MAX_HRS_WORKED_RATE * Constants.REG_HOLIDAYS_OT_RATE));
        }
        public static decimal RestDayAndRegularHolidays(decimal baseRate, double noOfDays)
        {
            return (decimal)noOfDays * ((baseRate) * Constants.REST_REG_HOLIDAYS_RATE);
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
            return (((baseRate) / (decimal)(Constants.MAX_HRS_WORKED_RATE * Constants.NSD_RATE)) * (decimal)noOfHoursInNSD);
        }
    }

    public class WorkOTRateComputation
    {
        public static decimal BillingRateState(string rate, decimal baseRate)
        {
            decimal billingOTResult = 0;
            switch (rate)
            {
                case BillingConstants.REG_DAYS:
                    billingOTResult = RegularDaysOTRate(baseRate);
                    break;
                case BillingConstants.SPL_DAYS:
                    billingOTResult = SpecialHolidaysOTRate(baseRate);
                    break;
            }

            return billingOTResult;
        }


        public static decimal RegularDaysOTRate(decimal baseRate)
        {
            return ((baseRate) / (decimal)(Constants.MAX_HRS_WORKED_RATE * Constants.REG_OT_RATE));
        }

        public static decimal SpecialHolidaysOTRate(decimal baseRate)
        {
            return (baseRate) / (decimal)(Constants.MAX_HRS_WORKED_RATE * Constants.SP_HOLIDAYS_OT_RATE);
        }
    }
}
