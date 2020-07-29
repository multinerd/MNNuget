using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multinerd.Windows.Application.Extensions
{
    public static partial class Extensions
    {
        [Obsolete("This method has been deprecated and moved to 'Project Maya'.\n Please reference that project instead.")]
        public static bool IsInDesignMode()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio");
        }
    }
}
