using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Betterfly.BetterCode {
	public class FPSCore : MonoBehaviour
	{
		[SerializeField] private float _fpsUpdateInterval = 0.5F;
		[SerializeField] private FloatUnityEvent _fpsValueChangeEvent;

		public float FpsUpdateInterval
		{
			get
			{
				if (_fpsUpdateInterval < 0F)
				{
					_fpsUpdateInterval = -_fpsUpdateInterval;
				}

				return _fpsUpdateInterval;
			}
			
			set
			{
				if (value > 0F)
				{
					_fpsUpdateInterval = value;
				}
				else
				{
					_fpsUpdateInterval = -value;
				}
			}
		}

		public Action<float> _fpsValueChangeAction;

		private float lastUpdateTime;
		private int frameCount;
		private float fpsValue;
		
		private void Start()
		{
			lastUpdateTime = Time.realtimeSinceStartup;
			frameCount = 0;
		}

		private void Update()
		{
			++frameCount;
			float currentTime = Time.realtimeSinceStartup;
			if (currentTime > lastUpdateTime + FpsUpdateInterval)
			{
				fpsValue = frameCount / (currentTime - lastUpdateTime);
				frameCount = 0;
				lastUpdateTime = currentTime;
				_fpsValueChangeEvent?.Invoke(fpsValue);
				_fpsValueChangeAction?.Invoke(fpsValue);
			}
		}
	}
}