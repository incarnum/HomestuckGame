using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Object_SyncPosition : NetworkBehaviour {


	//[SyncVar]
	public GameObject targetObject;

	[SyncVar (hook = "LerpPosition")] private Vector3 syncPos;
	[SyncVar (hook = "UpdateGravity")] public bool gravity = true;


	public Vector3 heading;


	private Vector3 lastPos;
	private float threshold = 0.2f;
	public bool working = false;
	//public bool gravity1 = true;
	//public float test = 0f;
	public bool selected = false;

	void Start() {
		targetObject = GameObject.Find ("Chest");
		CmdProvideGravityToServer(true);
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if (working == false) {
				working = true;
			} else {
				working = false;
			}
		}
		//gravity = gravity1;
	}

	void FixedUpdate ()
	{
		//if (isLocalPlayer && targetObject){
			//Debug.Log (targetObject);
		TransmitPosition();
		//CmdProvideGravityToServer();
			//Debug.Log (targetObject.transform.position);
			//Debug.Log (syncPos);
		//LerpPosition();
//		if (selected == false)
//			targetObject.GetComponent<Rigidbody>().useGravity = true;
//		if (selected)
//			targetObject.GetComponent<Rigidbody>().useGravity = false;
		//}
		//Debug.Log(syncPos + gameObject.name);
	}

	void LerpPosition(Vector3 pos)
	{
		if(!isLocalPlayer && working == false && GameObject.Find("LocalPlayer").GetComponent<Object_SyncPosition>().working == false)
		//{
		//serverObject.transform.position = Vector3.Lerp(serverObject.transform.position, syncPos, Time.deltaTime * lerpRate);
		//}
		targetObject.transform.position = pos;
		Debug.Log (gameObject.name + "moved the object");
	}

	void UpdateGravity(bool gravity)
	{
		targetObject.GetComponent<Rigidbody> ().useGravity = gravity;
		Debug.Log ("gravity updated to" + gravity);
	}

	[Command]
	void CmdProvidePositionToServer (Vector3 pos)
	{
		
			syncPos = pos;
			//serverObject = targetObject;
			//targetObject.GetComponent<chestScript> ().serverPosition = targetObject.GetComponent<Transform>().position;
			//targetObject.GetComponent<chestScript> ().updateSyncVar(targetObject.GetComponent<Transform>().position);

			Debug.Log (gameObject.name + "provided position to server");

	}

	//[ClientCallback]
	[Command]
	public void CmdProvideGravityToServer (bool grav)
	{
		//if (!isLocalPlayer && working == false && GameObject.Find("LocalPlayer").GetComponent<Object_SyncPosition>().working == false) {
			gravity = grav;
			Debug.Log ("provided gravity to server");
		//}
	}

	//[ClientCallback]
	void TransmitPosition()
	{
			if (Vector3.Distance(targetObject.transform.position, lastPos) > threshold && working)
		{
			CmdProvidePositionToServer(targetObject.transform.position);
			//GameObject.Find("JohnEgbert(Clone)").GetComponent<Object_SyncPosition>().syncPos = targetObject.transform.position;
			lastPos = targetObject.transform.position;

		}
	}

}