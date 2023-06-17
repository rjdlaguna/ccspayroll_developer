using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
