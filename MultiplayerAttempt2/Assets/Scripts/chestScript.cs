using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class chestScript : MonoBehaviour {
    public Animator anim;
    private bool touchingChest = false;
    private float verticalOffset;
    private float startPos;
    Rigidbody body;
    Transform transformpos;
	// Use this for initialization
	void Start () {
        //anim = GetComponentInChildren<Animator>();
        verticalOffset = 0;
        body = GetComponent<Rigidbody>();
        transformpos = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.E))
        {
            if (touchingChest)
                anim.SetTrigger("ChestOpen");
            SceneManager.LoadScene("Collide");
        }
        verticalOffset += Input.GetAxis("Mouse ScrollWheel");
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            touchingChest = true; 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            touchingChest = false;
    }

    void OnMouseDown()
    {
        body.useGravity = false;
        startPos = transformpos.position.y;
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
    }
}
