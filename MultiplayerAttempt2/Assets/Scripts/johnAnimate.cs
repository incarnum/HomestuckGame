using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class johnAnimate : NetworkBehaviour {
    Animator anim;
	
	void Start () 
	{
        anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate () {
		if (gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity> ().isLocalPlayer) 
		{
			float move = Input.GetAxisRaw ("Vertical");
			float movex = Input.GetAxisRaw ("Horizontal");
			anim.SetFloat ("Speed", move);
			anim.SetFloat ("SpeedX", movex);
       
        
			//if (movex > 0) {
				//transform.localScale = new Vector3 (1, 1, 1);
			//}
			//if (movex < 0) {
				//transform.localScale = new Vector3 (-1, 1, 1);
			//}

		}

	}
    
}
