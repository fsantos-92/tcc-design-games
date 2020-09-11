using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar1 : MonoBehaviour {

	public GameObject[] carros1;

	private float timer;
	private int randomTime;

	private int randomCar;

	// Use this for initialization
	void Start () {
		timer = 0;
		randomTime = Random.Range (12, 20);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= randomTime) {
			randomCar = Random.Range (0, carros1.Length);
			GameObject.Instantiate (carros1 [randomCar], transform.position, transform.rotation);
			randomTime = Random.Range (12, 20);
			//Debug.Log (randomTime);
			//Debug.Log (randomCar);
			timer = 0;
		}

	}
}
