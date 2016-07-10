using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;

public class chestScript : NetworkBehaviour {
    public Animator anim;
    private bool touchingChest = false;
    private float verticalOffset;
    private float startPos;
	private GameObject localPlayer;
    Rigidbody body;
    Transform transformpos;

	//[SyncVar (hook = "syncChestPosition")] public Vector3 serverPosition;

	// Use this for initialization
	void Start () {
        //anim = GetComponentInChildren<Animator>();
        verticalOffset = 0;
        body = GetComponent<Rigidbody>();
        transformpos = GetComponent<Transform>();
		localPlayer = GameObject.Find ("LocalPlayer");

    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.E))
        {
            if (touchingChest)
                anim.SetTrigger("ChestOpen");
            //SceneManager.LoadScene("Collide");
        }
        verticalOffset += Input.GetAxis("Mouse ScrollWheel");
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LocalPlayer")
            touchingChest = true; 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "LocalPlayer")
            touchingChest = false;
    }

    void OnMouseDown()
    {
		if (GameObject.Find ("GameMode").GetComponent<GameMode> ().currentGameMode == 1) {
			body.useGravity = false;
			startPos = transformpos.position.y;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().CmdProvideSelectedToServer (gameObject);
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().gravity = false;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().working = true;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().CmdProvideGravityToServer (false);
		}
    }

    void OnMouseDrag()
    {
		if (GameObject.Find ("GameMode").GetComponent<GameMode> ().currentGameMode == 1) {
			float distance_to_screen = Camera.main.WorldToScreenPoint (gameObject.transform.position).z;
			Vector3 pos_move = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y + 20, distance_to_screen + verticalOffset / 2));
			transform.position = new Vector3 (pos_move.x, startPos + verticalOffset, pos_move.z);
		}
    }

    void OnMouseUp()
    {
		if (GameObject.Find ("GameMode").GetComponent<GameMode> ().currentGameMode == 1) {
			body.useGravity = true;
			verticalOffset = 0;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().gravity = true;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().working = false;
			GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().CmdProvideGravityToServer (true);
		}
//		GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().selected = false;

		//GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().test = 3f;
		//GetComponent<Object_SyncPosition> ().selected = false;
    }

	//public void syncChestPosition(Vector3 pos){
		//serverPosition = pos;
		//transform.position = pos;
		//Debug.Log ("I got the position" + pos);
	//}
		
	//public void updateSyncVar(Vector3 posi){
		//serverPosition = posi;
		//Debug.Log ("posi JJJJJJJJJJ" + posi);
	//}
}
