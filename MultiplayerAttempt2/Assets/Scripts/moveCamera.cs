using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {

    


	void Start () {
    
    }

    void Update()
    {
        
    }

    public void MoveRight()
    {
        transform.position += new Vector3 (5, 0, -5);
    }

    public void MoveLeft()
    {
        transform.position += new Vector3(-5, 0, 5);
    }
}
