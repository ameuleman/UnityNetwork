using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ButtonScript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if (!isServer)
			this.GetComponent<Button>().gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
