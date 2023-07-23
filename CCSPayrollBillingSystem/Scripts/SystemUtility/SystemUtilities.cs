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
        public const string ADMIN = "admin";
        public const string USER1 = "user1";
        public const string USER2 = "user2";
        public const string DEFAULT_VALUE = "0.0";

        public const float REG_OT = 1.25F;
        public const decimal SUN_SP_HOLIDAYS = 1.30M;
        public const float SP_HOLIDAYS_OT = 1.69F;
        public const decimal REST_REG_HOLIDAYS = 2.60M;
        public const float REST_REG_HOLIDAYS_OT = 3.38F;
        public const decimal REG_HOLIDAYS = 2.0M;
        public const float REG_HOLIDAYS_OT = 2.6F;
        
        public const float NSD = 0.10F;
    }

    public class WorkDaysComputation
    {
        public static decimal RegularDays(decimal baseRate, float noOfDays)
        {
            return baseRate * (decimal)noOfDays;
        }
        public static decimal RegularDaysOT(decimal baseRate, float noOfDays)
        {
            return (baseRate * (decimal)noOfDays) + ((baseRate)/(decimal)(8*Constants.REG_OT));
        }
        public static decimal SunOrSpecialHolidays(decimal baseRate, float noOfDays)
        {
            return baseRate * (decimal)noOfDays + (baseRate * Constants.SUN_SP_HOLIDAYS);
        }
        public static decimal SpecialHolidaysOT(decimal baseRate, float noOfDays)
        {
            return baseRate * (decimal)noOfDays + ((baseRate) / (decimal)(8 * Constants.SP_HOLIDAYS_OT));
        }
        public static decimal RestDayOrRegularHolidays(decimal baseRate, float noOfDays)
        {
            return baseRate * (decimal)noOfDays + ((baseRate) * Constants.REST_REG_HOLIDAYS);
        }
        public static decimal RegularHolidaysOT(decimal baseRate, float noOfDays)
        {
            return baseRate * (decimal)noOfDays + ((baseRate) / (decimal)(8 * Constants.REG_HOLIDAYS_OT));
        }
        public static decimal COLA(decimal valueCOLA)
        {
            return (decimal)valueCOLA;
        }
        public static decimal PDA(decimal valuePDA)
        {
            return (decimal)valuePDA;
        }
        public static decimal Others(decimal baseRate, float valueOthers)
        {
            return baseRate * (decimal)valueOthers;
        }

        public static decimal NightShiftDifferential(decimal baseRate, float noOfDays, float noOfHoursInNSD)
        {
            return baseRate * (decimal)noOfDays + (((baseRate) / (decimal)(8 *Constants.NSD)) * (decimal)noOfHoursInNSD);
        }
    }
}
