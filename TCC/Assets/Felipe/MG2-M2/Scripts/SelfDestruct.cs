using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Destroy (gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
