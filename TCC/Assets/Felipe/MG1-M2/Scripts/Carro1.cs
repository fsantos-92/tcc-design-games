using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro1 : MonoBehaviour {
	private bool canDrive;

	// Use this for initialization
	void Start () {
		canDrive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (canDrive) {
			transform.Translate (-0.2f, 0, 0);
		}
	}

	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Semaforo") {
			if (hit.gameObject.GetComponent<Semaforo> ().open) {
				canDrive = false;
			}
		}
		else {
			canDrive = false;
		}
	}
	public void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag == "Semaforo") {
			if (hit.gameObject.GetComponent<Semaforo> ().open) {
				canDrive = true;
			}
		}
		else {
			canDrive = true;
		}
	}
}
