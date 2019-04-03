using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Betterfly.BetterCode {
	public enum UNetState
	{
		None = 0,
		Host = 1,
		Server = 2,
		Client = 3,
	}
	
	public class UNetStateHolder : MonoBehaviour
	{
		[SerializeField] private UNetState _state;

		public UNetState State
		{
			get { return _state; }
			set
			{
				_state = value;
				Debug.Log("UNet state -> " + _state);
			}
		}

		public void SetNone()
		{
			State = UNetState.None;
		}

		public void SetHost()
		{
			State = UNetState.Host;
		}

		public void SetServer()
		{
			State = UNetState.Server;
		}

		public void SetClient()
		{
			State = UNetState.Client;
		}
	}
}