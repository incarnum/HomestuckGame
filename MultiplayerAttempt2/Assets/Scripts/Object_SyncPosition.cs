using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Object_SyncPosition : NetworkBehaviour {


	//[SyncVar]
	public GameObject targetObject;

	[SyncVar (hook = "UpdateSelected")] public GameObject selected;
	[SyncVar (hook = "LerpPosition")] private Vector3 syncPos;
	[SyncVar (hook = "UpdateGravity")] public bool gravity = true;
	[SyncVar (hook = "UpdateCursor")] private Vector3 cursorPos;



	public Vector3 heading;


	private Vector3 lastPos;
	private float threshold = 0.2f;
	public bool working = false;

	void Start() {
		//targetObject = GameObject.Find ("Chest");
		//CmdProvideGravityToServer(true);
	}

	void FixedUpdate ()
	{

		if(targetObject != null)
		TransmitPosition();
	}

	void LerpPosition(Vector3 pos)
	{
		if(!isLocalPlayer && working == false && GameObject.Find("LocalPlayer").GetComponent<Object_SyncPosition>().working == false)
		targetObject.transform.position = pos;
		Debug.Log (gameObject.name + "moved the object");
	}

	void UpdateGravity(bool gravity)
	{
		targetObject.GetComponent<Rigidbody> ().useGravity = gravity;
		Debug.Log ("gravity updated to" + gravity);
	}

	void UpdateSelected(GameObject sel)
	{
		targetObject = sel;
	}

	void UpdateCursor(Vector3 pos)
	{
		if (!isLocalPlayer)
			GameObject.Find ("Cursor").transform.position = pos;
	}

	[Command]
	void CmdProvidePositionToServer (Vector3 pos)
	{
			syncPos = pos;
			Debug.Log (gameObject.name + "provided position to server");
	}
		
	[Command]
	public void CmdProvideGravityToServer (bool grav)
	{
			gravity = grav;
		Debug.Log (selected);
	}

	[Command]
	public void CmdProvideSelectedToServer (GameObject sel)
	{
		selected = sel;
	}

	[Command]
	public void CmdProvideCursorToServer (Vector3 pos)
	{

	}
		
	void TransmitPosition()
	{
			if (Vector3.Distance(targetObject.transform.position, lastPos) > threshold && working)
		{
			CmdProvidePositionToServer(targetObject.transform.position);
			lastPos = targetObject.transform.position;
		}
	}

}