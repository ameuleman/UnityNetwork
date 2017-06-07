using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RpcScript : NetworkBehaviour {
	private Material material;

	void Start () {
		if (isServer)
			// Hide the mesh on server side 
			GetComponent<MeshRenderer> ().enabled = false;
		else
			material = GetComponent<MeshRenderer> ().material;
	}

	public void changeColor()
	{
		// Call the function on all clients
		RpcChangeMaterialColor ();
	}

	// [ClientRpc] enables to call this function on all clients
	[ClientRpc]
	void RpcChangeMaterialColor(){
		// Switch colors
		if(!isServer)
			if (material.color == Color.black)
				material.color = Color.blue;
			else
				material.color = Color.black;
	}
}