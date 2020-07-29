using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multinerd.Windows.Helpers
{
    public static class BoolChecks
    {
        [Obsolete("This method has been deprecated and moved to 'Project Maya'.\n Please reference that project instead.")]
        public static bool IsNotAFreaking<T>(this object obj)
        {
            return !(obj is T);
        }
    }
}
