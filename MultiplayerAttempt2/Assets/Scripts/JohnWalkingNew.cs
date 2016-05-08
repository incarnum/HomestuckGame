using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class JohnWalkingNew : NetworkBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	void Update() {
		if (gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity> ().isLocalPlayer) {
			float inputX = Input.GetAxisRaw ("Horizontal");
			float inputY = Input.GetAxisRaw ("Vertical");

			anim.SetFloat ("SpeedX", inputX);
			anim.SetFloat ("SpeedY", inputY);

			if(Input.GetKeyDown(KeyCode.Space))
			{
				anim.SetTrigger ("Swing");
			}
		}
	}


	void FixedUpdate () {
		if (gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity> ().isLocalPlayer) {
			float lastInputX = Input.GetAxisRaw ("Horizontal");
			float lastInputY = Input.GetAxisRaw ("Vertical");

			if (lastInputX != 0 || lastInputY != 0) {
				anim.SetBool ("Walking", true);
				if (lastInputX > 0) {
					anim.SetFloat ("LastMoveX", 1f);
				} else if (lastInputX < 0) {
					anim.SetFloat ("LastMoveX", -1f);
				} 

				if (lastInputY > 0) {
					anim.SetFloat ("LastMoveY", 1f);
				} else if (lastInputY < 0) {
					anim.SetFloat ("LastMoveY", -1f);
				} 

			} else {
				anim.SetBool ("Walking", false);
			}
		}
	}
}
