using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_SyncPosition : NetworkBehaviour {

    [SyncVar]
    private Vector3 syncPos;
	public Vector3 heading;

    [SerializeField] float lerpRate = 15;

    private Vector3 lastPos;
    private float threshold = 0.2f;

	
	void FixedUpdate ()
    {
        TransmitPosition();
        LerpPosition();
	}

    void LerpPosition()
    {
        if(!isLocalPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, syncPos, Time.deltaTime * lerpRate);
        }
    }

    [Command]
    void CmdProvidePositionToServer (Vector3 pos)
    {
        syncPos = pos;
    }

    [ClientCallback]
    void TransmitPosition()
    {
        if (isLocalPlayer && Vector3.Distance(transform.position, lastPos) > threshold)
        {
            CmdProvidePositionToServer(transform.position);
            lastPos = transform.position;
        }
    }
}