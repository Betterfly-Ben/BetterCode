using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Betterfly.BetterCode {
	public class CoroutineDefinition : MonoBehaviour {
		public static IEnumerator AfterAction(IEnumerator core, Action afterAction)
		{
			yield return core;
			afterAction?.Invoke();
		}
		
		public static IEnumerator BeforeAction(IEnumerator core, Action beforeAction)
		{
			beforeAction?.Invoke();
			yield return core;
		}
		
		public static IEnumerator BeforeAfterAction(IEnumerator core, Action beforeAction, Action afterAction)
		{
			beforeAction?.Invoke();
			yield return core;
			afterAction?.Invoke();
		}

		public static IEnumerator BeforeWaitForSeconds(IEnumerator core, float waitSeconds = -1F)
		{
			if (waitSeconds <= 0F)
			{
				yield return null;
			}
			else
			{
				yield return new WaitForSeconds(waitSeconds);
			}

			yield return core;
		}

		public static IEnumerator AfterWaitForSeconds(IEnumerator core, float waitSeconds = -1F)
		{
			yield return core;
			
			if (waitSeconds <= 0F)
			{
				yield return null;
			}
			else
			{
				yield return new WaitForSeconds(waitSeconds);
			}
		}
	}
}