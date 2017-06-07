using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SyncVarScript : NetworkBehaviour {
	/// color will be synchronizzed on all clients. 
	/// Call changeMaterialColor when color's value changes.
	[SyncVar(hook="changeMaterialColor")]
	public Color color = Color.white;
	private Material material;

	void Start () {
		if (isServer)
			GetComponent<MeshRenderer> ().enabled = false;
		else
			material = GetComponent<MeshRenderer> ().material;
	}

	public void changeColor()
	{
		// change color's value
		if(isServer)
			if (color == Color.black)
				color = Color.blue;
			else
				color = Color.black;
	}

	/// Changes the color of the material.
	/// This function is called on all clients when color's value changes
	void changeMaterialColor(Color col){
		if(!isServer)
			material.color = col;
	}
}