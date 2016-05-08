using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetManagerCustom : NetworkManager {

	[SerializeField] Vector3 playerSpawnPos;
	[SerializeField] GameObject theNewPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
		var player = (GameObject)GameObject.Instantiate (theNewPlayer, playerSpawnPos, Quaternion.identity);
		NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
	}
		
}
