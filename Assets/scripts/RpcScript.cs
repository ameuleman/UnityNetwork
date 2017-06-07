using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RpcScript : NetworkBehaviour {
	private Material material;

	void Start () {
		if (isServer)
			GetComponent<MeshRenderer> ().enabled = false;
		else
			material = GetComponent<MeshRenderer> ().material;
	}

	public void changeColor()
	{
		RpcChangeMaterialColor ();
	}

	[ClientRpc]
	void RpcChangeMaterialColor(){
		if(!isServer)
			if (material.color == Color.black)
				material.color = Color.blue;
			else
				material.color = Color.black;
	}
}