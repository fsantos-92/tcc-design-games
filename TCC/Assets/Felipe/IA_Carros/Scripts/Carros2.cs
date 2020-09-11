using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carros2 : MonoBehaviour {
	private bool canDrive;
	private float speedX;
	private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		canDrive = true;
	}

	// Update is called once per frame
	void Update () {
		if (canDrive) {
			speedX -= 0.05f;
			if (speedX < -0.2f) {
				speedX = -0.2f;
			}
		}
		else {
			speedX += 0.05f;
			if (speedX > 0) {
				speedX = 0;
			}
		}
		transform.Translate (speedX, 0, 0);

	}
	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "fimCaminho") {
			transform.position = originalPosition;
		}  else if (hit.gameObject.tag == "carros1" || hit.gameObject.tag == "carros2") {
			if (transform.localPosition.x < hit.gameObject.transform.localPosition.x) {
				canDrive = false;
			} else {
				canDrive = true;
			}
		}
		else if (hit.gameObject.tag == "carros3" || hit.gameObject.tag == "carros4") {
			if (transform.localPosition.x < hit.gameObject.transform.position.x + 6f) {
				canDrive = false;
			} else {
				canDrive = true;
			}
		}
		else {
			canDrive = false;
		}
	}

	public void OnTriggerStay(Collider hit){
		if (hit.gameObject.tag == "Semaforo1") {
			canDrive = false;
		} else if (hit.gameObject.tag == "Semaforo2") {
			canDrive = true;
		}
	}

	public void OnTriggerExit(Collider hit){
		canDrive = true;
	}
}
