using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AttackColliderScript : NetworkBehaviour {
    public float damage;
    public GameObject creator;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, .1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject!= creator && other.gameObject.tag == "Player")
        {
            creator.GetComponent<Attack1>().target = other.gameObject;
            creator.GetComponent<Attack1>().attackOnUpdate = true;
        }
    }

    
}
