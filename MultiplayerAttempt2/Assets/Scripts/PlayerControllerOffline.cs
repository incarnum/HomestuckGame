using UnityEngine;
using System.Collections;

public class PlayerControllerOffline : MonoBehaviour{

    public float speed = 6f;
    Vector3 movement;
    Rigidbody playerRigidbody;
    
	void Awake () {
        playerRigidbody = GetComponent<Rigidbody>();
        //transform.Rotate(30, 45, 0);
	}
	void Update()
    {
        
    }
	void FixedUpdate () {
       

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
	}

    void Move (float h, float v)
    {
        movement.Set(h+v, 0f, v-h);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
