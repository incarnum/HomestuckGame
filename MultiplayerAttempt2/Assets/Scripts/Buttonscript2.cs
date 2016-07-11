using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Buttonscript2 : NetworkBehaviour {
	public Sprite cursorSprite;
	public GameObject sburbUI;
	private Vector2 hotSpot = Vector2.zero;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void TellPlayerToRespawn()
	{
		GameObject.Find("LocalPlayer").GetComponent<PlayerController>().CmdRespawn2();
		GameObject.Find ("GameMode").GetComponent<GameMode> ().currentGameMode = 0;
		//Cursor.SetCursor(cursorSprite.texture, hotSpot, CursorMode.Auto);
		//Cursor.visible=false;
		GameObject.Find ("CharacterSelectionUI").SetActive (false);
		sburbUI.SetActive (true);
	}
}
