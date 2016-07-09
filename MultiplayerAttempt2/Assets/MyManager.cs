using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MyManager : NetworkManager 
{
//	public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
//	{
//		Debug.Log ("something");
//		GameObject player = (GameObject)Instantiate (playerPrefab, Vector3.zero, Quaternion.identity);
//		NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
//	}

//
//	public void ReplacePlayer(NetworkIdentity oldPlayer)
//	{
//		var conn = oldPlayer.connectionToClient;
//		var newPlayer = Instantiate<GameObject> (playerPrefab);
//		Destroy (oldPlayer.gameObject);
//
//		NetworkServer.ReplacePlayerForConnection (conn, newPlayer, 0);
//		Debug.Log ("Ayy lmao");
//	}



//
//	void Awake()
//	{
//		singleton = this;
//	}
//	public void Respawn()
//	{
//		GameObject.FindObjectOfType (typeof(PlayerController)).CmdRespawn ();
//	}

	public GameObject prefab1;
	public GameObject prefab2;

	public void ServerRespawn(PlayerController oldPlayer, float prefabNum)
	{
		var conn = oldPlayer.connectionToClient;

		if (prefabNum == 1) {
			var newPlayer = Instantiate (prefab1);
			Destroy (oldPlayer.gameObject);
			NetworkServer.ReplacePlayerForConnection (conn, newPlayer, 0);
		}
		if (prefabNum == 2) {
			var newPlayer = Instantiate (prefab2);
			Destroy (oldPlayer.gameObject);
			NetworkServer.ReplacePlayerForConnection (conn, newPlayer, 0);
		}

	}

}
