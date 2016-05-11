using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Object_SyncPosition : NetworkBehaviour {

	//[SyncVar]
	//public GameObject serverObject;

	[SyncVar]
	public GameObject targetObject;

	[SyncVar]
	private Vector3 syncPos;

	//[SyncVar]
	//public bool selected;

	public Vector3 heading;

	[SerializeField] float lerpRate = 1;

	private Vector3 lastPos;
	private float threshold = 0.2f;
	private bool working = false;

	void Start() {
		targetObject = GameObject.Find ("Chest");
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Q))
		{
			working = true;
		}
	}

	void FixedUpdate ()
	{
		//if (isLocalPlayer && targetObject){
			//Debug.Log (targetObject);
		TransmitPosition();
			//Debug.Log (targetObject.transform.position);
			//Debug.Log (syncPos);
		LerpPosition();
//		if (selected == false)
//			targetObject.GetComponent<Rigidbody>().useGravity = true;
//		if (selected)
//			targetObject.GetComponent<Rigidbody>().useGravity = false;
		//}
	}

	void LerpPosition()
	{
			if(!isLocalPlayer && working == false)
		//{
		//serverObject.transform.position = Vector3.Lerp(serverObject.transform.position, syncPos, Time.deltaTime * lerpRate);
		//}
		targetObject.transform.position = syncPos;
	}

	[Command]
	void CmdProvidePositionToServer (Vector3 pos)
	{
		syncPos = pos;
		//serverObject = targetObject;
		targetObject.GetComponent<chestScript> ().serverPosition = targetObject.GetComponent<Transform>().position;
		targetObject.GetComponent<chestScript> ().updateSyncVar(targetObject.GetComponent<Transform>().position);
		Debug.Log ("provided position to server");
	}

	[ClientCallback]
	void TransmitPosition()
	{
			if (Vector3.Distance(targetObject.transform.position, lastPos) > threshold && working)
		{
			CmdProvidePositionToServer(targetObject.transform.position);

			lastPos = targetObject.transform.position;

		}
	}

}