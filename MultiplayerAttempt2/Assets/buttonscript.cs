﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class buttonscript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void TellPlayerToRespawn()
	{
		GameObject.Find("LocalPlayer").GetComponent<PlayerController>().CmdRespawn1();
	}
}