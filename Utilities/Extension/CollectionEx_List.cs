using System.Collections.Generic;
using System.Linq;

namespace Betterfly.BetterCode
{
    public static partial class CollectionEx
    {
        public static T GetRandom<T>(this List<T> col) where T : class
        {
            if (col.IsNullOrEmpty())
            {
                return default(T);
            }

            return col[UnityEngine.Random.Range(0, col.Count)];
        }
    }
}