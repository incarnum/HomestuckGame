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


	public void ReplacePlayer(NetworkIdentity oldPlayer)
	{
		var conn = oldPlayer.connectionToClient;
		var newPlayer = Instantiate<GameObject> (playerPrefab);
		Destroy (oldPlayer.gameObject);

		NetworkServer.ReplacePlayerForConnection (conn, newPlayer, 0);
		Debug.Log ("Ayy lmao");
	}

}
