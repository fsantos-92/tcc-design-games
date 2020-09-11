using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSemaforos : MonoBehaviour {

	public GameObject semaforo1;
	public GameObject semaforo2;
	private float timer;

	// Use this for initialization
	void Start () {
		semaforo1.SetActive (true);
		semaforo2.SetActive (false);
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 10f) {
			if (semaforo1.activeInHierarchy) {
				semaforo1.SetActive (false);
				semaforo2.SetActive (true);
			} 
			else {
				semaforo1.SetActive (true);
				semaforo2.SetActive (false);
			}
			timer = 0;
		}
	}
}
