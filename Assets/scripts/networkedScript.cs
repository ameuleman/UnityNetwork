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
		color = Color.white;
		material = new Material (Shader.Find ("Diffuse"));
		if (isServer) {
			this.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	void Update(){
		material.color = color;
		this.GetComponent<Renderer> ().material = material;
	}

	[ClientRpc]
	public void RpcAction()
	{
		if(isServer)
			if (color == Color.black)
				color = Color.blue;
			else
				color = Color.black;
	}
}
