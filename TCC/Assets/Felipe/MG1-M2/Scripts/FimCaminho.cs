using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimCaminho : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Carro") {
			GameObject.Destroy (hit.gameObject);
		}
	}
}
