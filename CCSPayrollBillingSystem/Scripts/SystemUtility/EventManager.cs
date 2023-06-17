using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSPayrollBillingSystem.Scripts
{
    public static class EventManager
    {
        public static Action<string> OnAdminLogged;

        public static void InvokeOnAdminLogged(string user)
        {
            OnAdminLogged?.Invoke(user);
        }
    }
}
