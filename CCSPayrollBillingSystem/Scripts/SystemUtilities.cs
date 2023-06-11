using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSPayrollBillingSystem.Scripts
{
    public class SystemUtilities:StaticInstance<SystemUtilities>
    {
        private string user;

        public void SetUser(string user)
        {
            this.user = user;
        }
        public static string GetConnectionString()
        {
            return @"Data Source=(localdb)\ProjectsV13;Initial Catalog=db_PayrollBilling;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public string GetUserLoggedIn()
        {
            return user;
        }
    }
}
