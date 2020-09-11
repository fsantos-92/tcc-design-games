using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleCanos : MonoBehaviour {

	public Transform[] Canos;
	public bool[] statusCanos;
	private bool statusCaixa;
	

	// Use this for initialization
	void Start () {
		statusCaixa = false;
		statusCanos = new bool[20];
		for (int i = 0; i < Canos.Length; i++) {
			statusCanos [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		statusCaixa = GetComponent<EncherBalde> ().CaixaCheia;			//Testa se a caixa dagua esta cheia no script encherbalde

		if (Canos [0].rotation.eulerAngles.y == 0) {					//Teste das posições dos canos, de acordo com a tabela enviada junto com o projeto
			statusCanos [0] = true;
		} else {
			statusCanos [0] = false;
		}

		if (Canos [1].rotation.eulerAngles.y == 180) {
			statusCanos [1] = true;
		} else {
			statusCanos [1] = false;
		}

		if (Canos [2].rotation.eulerAngles.y == 90 || Canos [2].rotation.eulerAngles.y == 270) {
			statusCanos [2] = true;
		} else {
			statusCanos [2] = false;
		}

		if (Canos [3].rotation.eulerAngles.y == 0) {
			statusCanos [3] = true;
		} else {
			statusCanos [3] = false;
		}

		if (Canos [4].rotation.eulerAngles.y == 270) {
			statusCanos [4] = true;
		} else {
			statusCanos [4] = false;
		}

		if (Canos [5].rotation.eulerAngles.y == 0 || Canos [5].rotation.eulerAngles.y == 90) {
			statusCanos [5] = true;
		} else {
			statusCanos [5] = false;
		}

		if (Canos [6].rotation.eulerAngles.y == 90 || Canos [6].rotation.eulerAngles.y == 270) {
			statusCanos [6] = true;
		} else {
			statusCanos [6] = false;
		}

		if (Canos [7].rotation.eulerAngles.y == 90 || Canos [7].rotation.eulerAngles.y == 270) {
			statusCanos [7] = true;
		} else {
			statusCanos [7] = false;
		}

		if (Canos [8].rotation.eulerAngles.y == 90 || Canos [8].rotation.eulerAngles.y == 270) {
			statusCanos [8] = true;
		} else {
			statusCanos [8] = false;
		}

		if (Canos [9].rotation.eulerAngles.y == 0) {
			statusCanos [9] = true;
		} else {
			statusCanos [9] = false;
		}

		if (Canos [10].rotation.eulerAngles.y == 0) {
			statusCanos [10] = true;
		} else {
			statusCanos [10] = false;
		}

		if (Canos [11].rotation.eulerAngles.y == 90 || Canos [11].rotation.eulerAngles.y == 270) {
			statusCanos [11] = true;
		} else {
			statusCanos [11] = false;
		}

		if (Canos [12].rotation.eulerAngles.y == 0) {
			statusCanos [12] = true;
		} else {
			statusCanos [12] = false;
		}

		if (Canos [13].rotation.eulerAngles.y == 0) {
			statusCanos [13] = true;
		} else {
			statusCanos [13] = false;
		}

		if (Canos [14].rotation.eulerAngles.y == 90 || Canos [14].rotation.eulerAngles.y == 270) {
			statusCanos [14] = true;
		} else {
			statusCanos [14] = false;
		}

		if (Canos [15].rotation.eulerAngles.y == 90 || Canos [15].rotation.eulerAngles.y == 270) {
			statusCanos [15] = true;
		} else {
			statusCanos [15] = false;
		}

		if (Canos [16].rotation.eulerAngles.y == 90 || Canos [16].rotation.eulerAngles.y == 270) {
			statusCanos [16] = true;
		} else {
			statusCanos [16] = false;
		}

		if (Canos [17].rotation.eulerAngles.y == 90 || Canos [17].rotation.eulerAngles.y == 270) {
			statusCanos [17] = true;
		} else {
			statusCanos [17] = false;
		}

		if (Canos [18].rotation.eulerAngles.y == 90 || Canos [18].rotation.eulerAngles.y == 270) {
			statusCanos [18] = true;
		} else {
			statusCanos [18] = false;
		}

		if (Canos [19].rotation.eulerAngles.y == 0) {
			statusCanos [19] = true;
		} else {
			statusCanos [19] = false;
		}


		for (int i = 0; i < statusCanos.Length; i++) {		//Testa se o array inteiro é verdadeiro, e para o laço for quando encontra um indice falso
			if (statusCanos [i] == false) {
				break;
			}
			if (i == 19 /*&& statusCaixa*/) {	//condiçao de vitoria se alcançar o nivel maximo da caixa antes de acabar o tempo
				Debug.Log("Foi");
				//SceneManager.LoadScene (0);
			}

		}
	}
}
