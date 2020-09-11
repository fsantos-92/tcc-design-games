using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EncherBalde : MonoBehaviour {

	//cada balde enche 5% do reservatorio

	public Text StatusBalde;
	public Text StatusCaixa;
	public Text Cronometro;

	private float gameTime      = 0;
	private int   sign          = 1;
	public  float startTime     = 241;


	private float NivelAguaBalde;
	private float NivelAguaCaixa;
	public bool CaixaCheia;
	private bool embaixoNuvem;
	private bool esvaziarBalde;
	private bool balde;
	public GameObject baldeCenario;
	public GameObject baldeJogador;

	// Use this for initialization
	void Start () {
		gameTime = startTime;
		NivelAguaBalde = 0;
		NivelAguaCaixa = 0;
		embaixoNuvem = false;
		esvaziarBalde = false;
		balde = false;
		CaixaCheia = false;
		baldeCenario.SetActive (true);
		baldeJogador.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		StatusCaixa.text = "Nivel Agua Caixa: " + NivelAguaCaixa.ToString () + "%"; 		//exibe o nivel da caixa dagua no canvas

		gameTime        = gameTime - sign * Time.deltaTime;
		int minutes     = (int)(gameTime / 60);
		int seconds     = (int)(gameTime % 60);
		Cronometro.text       = string.Format("{0:00}:{1:00}", minutes, seconds);

		if (gameTime < 0) {		//condiçao de derrota se acabar o tempo e o nivel de agua da caixa for menor que 80%
			
		}


		if (!balde) {								//se o jogador nao estiver com o balde, ativa o balde no cenário, desativa o do jogador, zera o nivel de agua do balde
			baldeCenario.SetActive (true);
			baldeJogador.SetActive (false);
			NivelAguaBalde = 0;
			StatusBalde.text = "Balde Vazio";
		}
		if (balde) {								//se o jogador estiver com o balde, ativa o balde do jogador, desativa o do cenário, e ao apertar G, o jogador dropa o balde
			baldeCenario.SetActive (false);
			baldeJogador.SetActive (true);
			if (Input.GetKeyDown (KeyCode.G)) {
				balde = false;
			}
		}

		if (embaixoNuvem && balde) {			//se o jogador está embaixo da nuvem e com o balde, aumenta o nivel de agua do balde
			NivelAguaBalde += 0.2f;
		}
		if (NivelAguaBalde >= 100) {			//avisa que o balde esta cheio
			NivelAguaBalde = 100;
			StatusBalde.text = "Balde Cheio";
			//Debug.Log ("balde cheio");
			if (esvaziarBalde && NivelAguaCaixa < 100 && Input.GetKeyDown (KeyCode.E)) {		//esvazia o balde e enche parte do nivel da caixa d'agua
				NivelAguaBalde = 0;
				NivelAguaCaixa += 5;
				StatusBalde.text = "Balde Vazio";
				//Debug.Log ("balde vazio");
			}

		}

		if (NivelAguaCaixa >= 100) {
			CaixaCheia = true;
			//Debug.Log ("CaixaCheia");
		}


	}

	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Nuvem") {
			embaixoNuvem = true;
		}
		if (hit.gameObject.tag == "Caixa_d'agua") {
			esvaziarBalde = true;
		}
		if (hit.gameObject.tag == "balde") {
			balde = true;
		}
	}

	public void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag == "Nuvem") {
			embaixoNuvem = false;
		}
		if (hit.gameObject.tag == "Caixa_d'agua") {
			esvaziarBalde = false;
		}
	}

}
