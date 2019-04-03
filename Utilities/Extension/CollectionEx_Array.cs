using System;

namespace Betterfly.BetterCode
{
    public static partial class CollectionEx
    {
        public static void ForEach<T>(this T[] array,Action<T> action)
        {
            if (array == null || action == null)
            {
                return;
            }
            Array.ForEach(array,action);
        }

        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            if (array == null || array.Length <= 0)
            {
                return true;
            }

            return false;
        }
    }
}