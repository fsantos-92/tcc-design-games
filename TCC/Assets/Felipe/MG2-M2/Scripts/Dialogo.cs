using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour {

	public string texto;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public string conversa(){
		return texto;		// retorna o texto atribuido ao npc no inspector
	}
}
