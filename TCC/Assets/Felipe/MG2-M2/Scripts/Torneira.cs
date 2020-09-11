using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torneira : MonoBehaviour {

	public bool aberta;
	public Rigidbody agua;
	private float frequencia;
	public Transform referencia;
	private bool canClose;

	// Use this for initialization
	void Start () {
		aberta = true;
		frequencia = 0;
		canClose = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (canClose && Input.GetKeyDown (KeyCode.E)) {
			aberta = false;
		}

		if (aberta) {
			frequencia++;
			if (frequencia > 30f) {
				Rigidbody rb = GameObject.Instantiate (agua, referencia.position, referencia.rotation) as Rigidbody;
				frequencia = 0;
			}
		} 
		else {

		}
	}

	public void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.tag == "Player") {
			canClose = true;
		}
	}
	public void OnTriggerExit(Collider hit) {
		if (hit.gameObject.tag == "Player") {
			canClose = false;
		}
	}

}
