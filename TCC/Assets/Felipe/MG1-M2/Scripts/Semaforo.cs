using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour {
	private float timer;
	public bool open;

	// Use this for initialization
	void Start () {
		timer = 0;
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 10) {
			open = !open;
			timer = 0;
		}
	}
}
