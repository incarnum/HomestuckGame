using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CursorScript : NetworkBehaviour {
	Transform transformPos;
	// Use this for initialization
	void Start () {
		transformPos = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.parent.gameObject.name == "LocalPlayer") {
			float distance_to_screen = Camera.main.WorldToScreenPoint (gameObject.transform.position).z;
			Vector3 pos_move = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y + 20, distance_to_screen));
			transform.position = new Vector3 (pos_move.x, transformPos.position.y, pos_move.z);
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().CmdProvideCursorToServer (transform.position);
		}
	}
}
