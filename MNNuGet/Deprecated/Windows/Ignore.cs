using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multinerd.Windows
{
    [Obsolete("This class has been deprecated and moved to 'Project Maya'.\n Please reference that project instead.")]
    public static class Ignore
    {
        public static void IgnoreExceptions(Action act)
        {
            try
            {
                act.Invoke();
            }
            catch
            {
                //
            }
        }
    }
}
