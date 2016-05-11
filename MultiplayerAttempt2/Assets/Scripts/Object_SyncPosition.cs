using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Object_SyncPosition : NetworkBehaviour {

	//[SyncVar]
	//public GameObject serverObject;

	[SyncVar]
	public GameObject targetObject;

	[SyncVar (hook = "LerpPosition")] private Vector3 syncPos;
	[SyncVar (hook = "UpdateGravity")] public bool gravity;

	//[SyncVar]
	//public bool selected;

	public Vector3 heading;

	[SerializeField] float lerpRate = 1;

	private Vector3 lastPos;
	private float threshold = 0.2f;
	public bool working = false;
	public bool gravity1 = true;

	void Start() {
		targetObject = GameObject.Find ("Chest");
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
		gravity = gravity1;
	}

	void FixedUpdate ()
	{
		//if (isLocalPlayer && targetObject){
			//Debug.Log (targetObject);
		TransmitPosition();
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

		Debug.Log ("provided position to server");
	}

	[ClientCallback]
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