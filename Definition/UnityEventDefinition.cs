using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Betterfly.BetterCode {
	[Serializable]
	public class FloatUnityEvent : UnityEvent<float>{}
	
	[Serializable]
	public class IntUnityEvent : UnityEvent<int>{}
	
	[Serializable]
	public class StringUnityEvent : UnityEvent<string>{}
	
	[Serializable]
	public class Vector2UnityEvent : UnityEvent<Vector2>{}
	
	[Serializable]
	public class Vector3UnityEvent : UnityEvent<Vector3>{}
}