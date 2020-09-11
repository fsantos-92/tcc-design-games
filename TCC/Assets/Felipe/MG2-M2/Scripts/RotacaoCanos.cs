using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoCanos : MonoBehaviour {
	private float originalYRotation;
	private float currentYRotation;
	private bool ativo;

	// Use this for initialization
	void Start () {
		originalYRotation = transform.rotation.eulerAngles.y;
		ativo = false;
	}
	
	// Update is called once per frame
	void Update () {
		currentYRotation = transform.rotation.eulerAngles.y;
	}
		

	public void Rotacionar(){
		if(transform.rotation.eulerAngles.y >= 270){
			transform.Rotate(0, originalYRotation - transform.rotation.eulerAngles.y, 0);
		}
		else {
			transform.Rotate(0, 90, 0);
		}

	}
}
