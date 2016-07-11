using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class buttonscript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void TellPlayerToRespawn()
	{
		GameObject.Find("LocalPlayer").GetComponent<PlayerController>().CmdRespawn1();
		GameObject.Find ("CharacterSelectionUI").SetActive (false);
		GameObject.Find ("GameMode").GetComponent<GameMode> ().currentGameMode = 2;
		GameObject.Find ("PlayerDefaultUI").SetActive (true);
	}
}
