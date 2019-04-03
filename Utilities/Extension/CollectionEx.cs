using System;
using System.Collections.Generic;

namespace Betterfly.BetterCode
{
	public static partial class CollectionEx
	{
		public static bool IsNullOrEmpty<T>(this ICollection<T> coll)
		{
			if (coll == null || coll.Count <= 0)
			{
				return true;
			}

			return false;
		}
	}
}