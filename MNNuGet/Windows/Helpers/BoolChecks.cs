using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multinerd.Windows.Helpers
{
    public static class BoolChecks
    {
        public static bool IsNotAFreaking<T>(this object obj)
        {
            return !(obj is T);
        }
    }
}
