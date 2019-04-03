using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace Betterfly.BetterCode {
	public class UNetClientSetup : MonoBehaviour {
		static string HostMark = "NetworkManager";
		
		[SerializeField] private NetworkManager _manager;
		[SerializeField] private NetworkDiscovery _discovery;

		[SerializeField] private UnityEvent _setupClientFinish;

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

		public void StartSetupClient()
		{
			Coroutine setupClientCor = StartCoroutine(ClientSetupCor());
		}
		
		IEnumerator ClientSetupCor(){
			if(Manager == null || Discovery == null){ yield break;}
			
			Discovery.Initialize();
			Discovery.StartAsClient();
			yield return null;
			Dictionary<string,NetworkBroadcastResult> dis = Discovery.broadcastsReceived;
			if(dis == null || dis.Count <= 0){
				yield return null;
			}
			bool contentToServer = false;
			while(!contentToServer){
				foreach(string key in dis.Keys){
					if(contentToServer){ break;}
					NetworkBroadcastResult br = dis[key];
					string dataStr = BytesToString(br.broadcastData);
					string[] items = dataStr.Split(':');
					if(items.Length == 3 && items[0] == HostMark){
						Manager.networkAddress = items[1];
						Manager.networkPort = Convert.ToInt32(items[2]);
						Debug.Log("Setup client -> " + items[0] + " : " + items[1] + " : " + items[2]);
						Manager.StartClient();

						_setupClientFinish?.Invoke();

						contentToServer = true;
					}
				}
				if(!contentToServer){ yield return null;}
			}
		}

		static string BytesToString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}
	}
}