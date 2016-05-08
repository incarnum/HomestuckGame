using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {

	public GameObject localPlayer;
	public bool flag;
	//public Vector3 offset;



	void Start () {
		flag = true;
		//offset = new Vector3 (-9.4f, 8.25f, -9.4f);
    }

    void Update()
    {
		if (localPlayer && flag) {
			transform.position = localPlayer.GetComponent<Transform> ().position + new Vector3 (-9.4f, 8.25f, -9.4f);
		}
    }

    public void MoveRight()
    {
		flag = true;
    }

    public void MoveLeft()
    {
		flag = false;
    }
}
