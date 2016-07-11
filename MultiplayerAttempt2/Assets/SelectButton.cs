using UnityEngine;
using System.Collections;

public class SelectButton : MonoBehaviour {
	private GameObject GM;
	public GameObject curs;
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GameMode");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onMouseDown(){
		

	}

	public void buttonPressed(){
		GM.GetComponent<GameMode> ().currentGameMode = 1;
		Cursor.visible = false;
		//curs.GetComponent<SpriteRenderer> ().enabled = true;
		curs.GetComponent<Animator> ().SetTrigger ("Select");
		//make it an animation where one state is just invisible, sync with network animator
	}
}
