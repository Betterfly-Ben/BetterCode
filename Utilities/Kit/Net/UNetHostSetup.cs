using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace Betterfly.BetterCode {
	public class UNetHostSetup : MonoBehaviour
	{
		[SerializeField] private NetworkManager _manager;
		[SerializeField] private NetworkDiscovery _discovery;

		[SerializeField] private UnityEvent _setupHostFinish;

		public NetworkManager Manager
		{
			get { return _manager; }
			set { _manager = value; }
		}

		public NetworkDiscovery Discovery
		{
			get { return _discovery; }
			set { _discovery = value; }
		}

		public void StartSetupHost()
		{
			Coroutine hostSetupCor = StartCoroutine(HostSetupCor());
		}
		
		IEnumerator HostSetupCor(){
			if(Manager == null || Discovery == null){ yield break;}
			
			IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
			string localIP = string.Empty;
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					localIP = ip.ToString();
					break;
				}
			}
			if(!string.IsNullOrEmpty(localIP)){
				Manager.networkAddress = localIP;
			}

			Discovery.Initialize();
			Discovery.StartAsServer();
			Manager.StartHost();

			_setupHostFinish?.Invoke();

			yield return null;
		}
	}
}