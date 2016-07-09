using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public float speed = 6f;
    public bool direction = true;
	public bool canMove = true;
	public Camera playerCamera;
    Vector3 movement;
    Rigidbody playerRigidbody;
	private float playerCheck;
    
	void Awake () {
        playerRigidbody = GetComponent<Rigidbody>();
		playerCheck = .1f;

	}

	void Start () {
		if (isLocalPlayer){
			Camera.main.GetComponent<moveCamera> ().localPlayer = gameObject;
			gameObject.tag = "LocalPlayer";
			gameObject.name = "LocalPlayer";
		}
	}

	void Update()
    {
//		if (playerCheck > 0) {
//			playerCheck -= Time.deltaTime;
//		}
//		if (playerCheck <= 0 && playerCheck > -1f) {
//			if (isLocalPlayer) {
//				Camera.main.transform.parent = transform;
//			}
//			playerCheck = -2f;
//		}


    }
	void FixedUpdate () {
		if (!isLocalPlayer)
            return;
		if (canMove) {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        if (h < 0)
            direction = false;
        if (h > 0)
            direction = true;
	}
	}

    void Move (float h, float v)
    {
        movement.Set(h+v, 0f, v-h);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

	[Command]
	public void CmdRespawn1()
	{
		GameObject.Find ("NetworkManager").GetComponent<MyManager> ().ServerRespawn (this,1);
	}

	[Command]
	public void CmdRespawn2()
	{
		GameObject.Find ("NetworkManager").GetComponent<MyManager> ().ServerRespawn (this,2);
	}
}
