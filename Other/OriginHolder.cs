using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Betterfly.BetterCode {
	public class OriginHolder : MonoBehaviour {
		private static readonly List<OriginHolder> Instances = new List<OriginHolder>();

		public static OriginHolder GetInstance()
		{
			if (Instances.Count == 0)
			{
				GameObject originHolderEntity = new GameObject(typeof(OriginHolder).Name,typeof(OriginHolder));
				originHolderEntity.transform.SetParent(null);
				originHolderEntity.transform.ResetLocal();
				OriginHolder holder = originHolderEntity.GetComponent<OriginHolder>();
				if (Instances.Count == 0)
				{
					Instances.Add(holder);
				}
			}

			return Instances[0];
		}

		private void Awake()
		{
			if (Instances.Contains(this) == false)
			{
				Instances.Add(this);	
			}
		}

		private void OnDestroy()
		{
			Instances.Remove(this);
		}
	}
}