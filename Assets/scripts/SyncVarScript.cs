using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SyncVarScript : NetworkBehaviour {
	/// <summary>
	/// color will be synchronizzed on all clients. 
	/// Call changeMaterialColor when color's value changes.
	/// </summary>
	[SyncVar(hook="changeMaterialColor")]
	public Color color = Color.white;

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
	/// change color's value
	/// </summary>
	public void changeColor()
	{
		if(isServer)
			if (color == Color.black)
				color = Color.blue;
			else
				color = Color.black;
	}

	/// <summary>
	/// Changes the color of the material.
	/// This function is called on all clients when color's value changes
	/// </summary>
	/// <param name="col">The new color to assign to the material</param>
	void changeMaterialColor(Color col){
		if(!isServer)
			material.color = col;
	}
}