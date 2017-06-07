using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SyncVarScript : NetworkBehaviour {
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
		if(isServer)
			if (color == Color.black)
				color = Color.blue;
			else
				color = Color.black;
	}

	void changeMaterialColor(Color col){
		if(!isServer)
			material.color = col;
	}
}