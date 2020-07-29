using System;

namespace Multinerd.Windows.Application.Extensions
{
    public static partial class Extensions
    {
        [Obsolete("This method has been deprecated and moved to 'Project Maya'.\n Please reference that project instead.")]
        public static bool Contains(this string source, string toCheck, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, stringComparison) >= 0;
        }
    }
}