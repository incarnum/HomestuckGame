using UnityEngine;
using System.Collections;

public class PRButtonScript : MonoBehaviour {
	public GameObject window;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggleActive(){
		if (window.activeSelf == true) {
			window.SetActive (false);
		}
		else if (window.activeSelf == false) {
			window.SetActive (true);
		}
		Debug.Log (window.activeSelf);
	}
}
