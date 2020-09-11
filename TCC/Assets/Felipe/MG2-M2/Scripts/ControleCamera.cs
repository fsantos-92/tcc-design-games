using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamera : MonoBehaviour {

	public GameObject CameraNuvem;
	public GameObject CameraCanos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "SetorCanos") {		// ativa a camera do setor dos canos e desativa a do setor da nuvem
			CameraCanos.SetActive (true);
			CameraNuvem.SetActive (false);
		}
		if (hit.gameObject.tag == "SetorNuvem") {		// ativa a camera do setor da nuvem e desativa a do setor dos canos
			CameraCanos.SetActive (false);
			CameraNuvem.SetActive (true);
		}
	}
}
