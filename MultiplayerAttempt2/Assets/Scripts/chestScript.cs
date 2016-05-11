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
        body.useGravity = false;
		//GetComponent<Object_SyncPosition> ().selected = true;
        startPos = transformpos.position.y;
		GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().working = true;
		GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().gravity1 = false;
		Debug.Log ("sent the change");

        if (Input.GetMouseButtonDown(1))
        {
            //verticalOffset = 0;
        }
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + 20, distance_to_screen + verticalOffset/2));
        transform.position = new Vector3(pos_move.x, startPos + verticalOffset, pos_move.z);
    }

    void OnMouseUp()
    {
        body.useGravity = true;
        verticalOffset = 0;
		GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().working = false;
		GameObject.Find ("LocalPlayer").GetComponent<Object_SyncPosition> ().gravity1 = true;
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
