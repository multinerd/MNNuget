using System;
using System.Linq;

namespace Multinerd.Extensions
{
    public static class EnumExtensions
    {
        [Obsolete("This method has been deprecated and moved to 'Project Maya'.\n Please reference that project instead.")]
        public static Enum GetRandomEnumValue(this Type t)
        {
            return Enum.GetValues(t).OfType<Enum>().OrderBy(e => Guid.NewGuid()).FirstOrDefault();
        }
    }
}
