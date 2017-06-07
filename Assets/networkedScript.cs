using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class networkedScript : NetworkBehaviour {
	[SyncVar]
	public Color color;
	private Material material;

	void Start () {
		material = new Material (Shader.Find ("Diffuse"));
	}

	void Update(){
		material.color = color;
		this.GetComponent<Renderer> ().material = material;
	}

	[ClientRpc]
	public void RpcAction()
	{
		if (color == Color.black)
			color = Color.blue;
		else
			color = Color.black;
	}
}
