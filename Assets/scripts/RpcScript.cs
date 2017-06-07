using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RpcScript : NetworkBehaviour {
	private Material material;

	/// <summary>
	/// Start this instance. 
	/// Hide the mesh on server side 
	/// Assign the material of the mesh to material on client side
	/// </summary>
	void Start () {
		if (isServer)
			GetComponent<MeshRenderer> ().enabled = false;
		else
			material = GetComponent<MeshRenderer> ().material;
	}

	/// <summary>
	/// Call RpcChangeMaterialColor() on all clients
	/// </summary>
	public void changeColor()
	{
		// Call the function on all clients
		RpcChangeMaterialColor ();
	}

	// [ClientRpc] enables to call this function on all clients
	[ClientRpc]
	/// <summary>
	/// Rpcs change the color of the material. 
	/// Called on all clients when called on the server
	/// </summary>
	void RpcChangeMaterialColor(){
		if(!isServer)
			if (material.color == Color.black)
				material.color = Color.blue;
			else
				material.color = Color.black;
	}
}