using System;

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
