using System;

namespace CCSPayrollBillingSystem.Scripts
{
    public abstract class StaticInstance<T>
    {
        private static readonly Lazy<T> _Instance = new Lazy<T>(() => Activator.CreateInstance<T>());

        public static T GetInstance()
        {
            return _Instance.Value;
        }
    }
}
