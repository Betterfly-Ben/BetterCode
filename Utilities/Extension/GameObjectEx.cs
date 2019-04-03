using UnityEngine;

namespace Betterfly.BetterCode
{
	public static partial class GameObjectEx
	{
		public static T GetOrAddComponent<T>(this GameObject go) where T : Component
		{
			if (go == null)
			{
				return null;
			}

			return go.GetComponent<T>() ?? go.AddComponent<T>();
		}
	}
}