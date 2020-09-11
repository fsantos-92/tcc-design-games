using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vazamento : MonoBehaviour {

	public Text Texto;				//referencia do texto no canvas
	private GameObject box;			//referencia do local do vazamento

	// Use this for initialization
	void Start () {
		Texto.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Vazamento") {
			box = hit.gameObject;
			Texto.text = "Tem um vazamento aqui, preciso avisar o faxineiro";
		}
	}
	public void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag == "Vazamento") {
			Texto.text = "";
		}
	}
}
