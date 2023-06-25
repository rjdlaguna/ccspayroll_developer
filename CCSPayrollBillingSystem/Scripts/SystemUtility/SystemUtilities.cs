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
    }
}
