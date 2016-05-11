using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Attack1 : NetworkBehaviour {

    [SerializeField]
    Transform myTransform;
    public GameObject prefab;
    public float damage;
    public GameObject Creator;
    public GameObject target;
	public float movePauseTime;
    private GameObject hitBox;
    private AttackColliderScript colscript;
    public bool attackOnUpdate;


	void Update ()
    {
        CheckifAttacking();
        if (attackOnUpdate == true)
        {
            CmdTellServerWhoWasShot(target);
            attackOnUpdate = false;
        }

//		if (movePauseTime > 0) {
//			movePauseTime -= Time.deltaTime;
//		}

		if (movePauseTime <= Time.time) {GetComponent<PlayerController> ().canMove = true;}
        
	}

    void CheckifAttacking()
    {
        if (!isLocalPlayer)
            return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
		GetComponent<PlayerController> ().canMove = false;
		movePauseTime = Time.time + .4f;
        if (GetComponent<PlayerController>().direction == true)
        {
            GameObject hitBox = Instantiate(prefab, myTransform.position + new Vector3(1, 0, -1), Quaternion.identity) as GameObject;
            hitBox.GetComponent<AttackColliderScript>().creator = Creator;
        }

        if (GetComponent<PlayerController>().direction == false)
        {
            GameObject hitBox = Instantiate(prefab, myTransform.position + new Vector3(-1, 0, 1), Quaternion.identity) as GameObject;
            hitBox.GetComponent<AttackColliderScript>().creator = Creator;
        }

    }


    [Command]
    void CmdTellServerWhoWasShot(GameObject trgt)
    {
        trgt.GetComponent<Health>().DeductHealth(5);
        
    }


}
