using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MakeTheChest : NetworkBehaviour
{
	public GameObject otherPrefab;

	void Start(){
		CmdSpawn();
	}

	[Command]
	public void CmdSpawn()
	{
		var go = (GameObject)Instantiate (otherPrefab, transform.position + new Vector3 (0, 1, 0), Quaternion.identity);
		NetworkServer.SpawnWithClientAuthority (go, connectionToClient);
	}
}