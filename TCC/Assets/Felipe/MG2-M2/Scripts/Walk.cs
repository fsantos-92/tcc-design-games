using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		transform.Translate (Input.GetAxis ("Vertical") * 0.06f, 0, 0);
		transform.Rotate (0, Input.GetAxis ("Horizontal") * 2.5f, 0);
	}
}
