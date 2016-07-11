using UnityEngine;
using System.Collections;

public class DeployButtonScript : MonoBehaviour {
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
		GM.GetComponent<GameMode> ().currentGameMode = 3;
		Cursor.visible = false;
		//curs.GetComponent<SpriteRenderer> ().enabled = true;
		curs.GetComponent<Animator> ().SetTrigger ("Deploy");
		//make it an animation where one state is just invisible, sync with network animator
	}
}
