using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Betterfly.BetterCode
{
    public static partial class IEnumerableEx
    {
        public static bool IsNullOrEmpty(this IEnumerable enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }

            foreach (object o in enumerable)
            {
                return false;
            }

            return true;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null || enumerable.Count() <= 0)
            {
                return true;
            }

            return false;
        }
    }
}