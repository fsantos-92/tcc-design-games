using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConversaNPC : MonoBehaviour {

	public Text TextoConversa;			//O texto da conversa no canvas
	private string texto;				// Variavel tipo string para receber o texto do npc e enviar ao canvas
	private GameObject npc;				//referencia do npc
	private GameObject torneira;		//referencia torneira

	// Use this for initialization
	void Start () {
		TextoConversa.text = "";
	}


	// Update is called once per frame
	void Update () {

		if (torneira) {
			if (torneira.GetComponent<Torneira> ().aberta == true) {
				TextoConversa.text = "Aperte [E] para fechar a torneira";
			}
		} else if (npc) {
			TextoConversa.text = texto;
		} else {
			TextoConversa.text = "";
		}
	}
	void OnTriggerEnter(Collider hit){
		// Coloca a referencia do npc
		if(hit.gameObject.tag == "conversa"){
			npc = hit.gameObject;
			texto = npc.GetComponent<Dialogo> ().conversa();
		}
		if (hit.gameObject.tag == "torneira") {
			torneira = hit.gameObject;
		}
	}
	void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag == "conversa") {
			npc = null;
		}
		if (hit.gameObject.tag == "torneira") {
			torneira = null;
		}
	}

}