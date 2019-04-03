using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Betterfly.BetterCode {
	public class FPSLiteUITextShower : MonoBehaviour
	{
		[SerializeField] private Text _fpsText;

		public void UpdateFPS(float fpsValue)
		{
			if (_fpsText != null)
			{
				_fpsText.text = $"{fpsValue:F2} FPS";
			}
		}
	}
}