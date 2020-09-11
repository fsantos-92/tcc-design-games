using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module3Stage2Manager : StageManagerBase
{
	public static Module3Stage2Manager instance = null;

	//Centro
	public GameObject DialogBoxRafaela;
	public GameObject DialogBoxMiguel;
	public GameObject DialogBoxEdgar;

	//Residencia
	public GameObject DialogBoxMonica;
	public GameObject DialogBoxRicardo;
	public GameObject DialogBoxVera;
	public GameObject DialogBoxJeferson;

	//Prefeitura
	public GameObject DialogBoxCelina;
	public GameObject DialogBoxElisa;
	public GameObject DialogBoxLeandro;

	public UnityEngine.UI.Image photoImage;

	public GameObject PhotoCamera1;
	public GameObject PhotoCamera2;
	public GameObject PhotoCamera3;
	public GameObject PhotoCamera4;
	public GameObject PhotoCamera5;
	public GameObject PhotoCamera6;
	public GameObject PhotoCamera7;
	public GameObject PhotoCamera8;
	public GameObject PhotoCamera9;
	public GameObject PhotoCamera10;

	public Transform[] NeighborhoodSpawnPoint;
	public Transform[] CenterSpawnPoint;
	public Transform[] TownHallSpawnPoint;

	public bool[] photos;

	// Use this for initialization
	void Start()
	{
		#region SingletonAwake
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		#endregion

		base.Start();

		DialogBoxRafaela.SetActive(false);
		DialogBoxMiguel.SetActive(false);
		DialogBoxEdgar.SetActive(false);
		DialogBoxMonica.SetActive(false);
		DialogBoxRicardo.SetActive(false);
		DialogBoxVera.SetActive(false);
		DialogBoxJeferson.SetActive(false);
		DialogBoxCelina.SetActive(false);
		DialogBoxElisa.SetActive(false);
		DialogBoxLeandro.SetActive(false);

		photoImage.gameObject.SetActive(false);

		PhotoCamera1.SetActive(false);
		PhotoCamera2.SetActive(false);
		PhotoCamera3.SetActive(false);
		PhotoCamera4.SetActive(false);
		PhotoCamera5.SetActive(false);
		PhotoCamera6.SetActive(false);
		PhotoCamera7.SetActive(false);
		PhotoCamera8.SetActive(false);
		PhotoCamera9.SetActive(false);
		PhotoCamera10.SetActive(false);

		//Camera.main.GetComponent<UnityStandardAssets.Utility.SmoothFollow>().target = playerPrefab.transform;
		Camera.main.GetComponent<WowCamera>().Target = playerPrefab.transform;
		photos = new bool[10];

		for (int i = 0; i < photos.Length; i++)
			photos[i] = false;

	}

	// Update is called once per frame
	void Update()
	{
		base.Update();

		if (gameTime <= 0)
		{
			playerPrefab.GetComponent<PlayerBehaviour>().enabled = false;
			playerPrefab.GetComponent<Module2Minigame1PlayerMechanic>().enabled = false;
			EndGame(false);
		}
		else
		{
			for (int i = 0; i < photos.Length; i++)
				if (i == photos.Length - 1 && photos[i])
					EndGame(true);
				else if (!photos[i])
					break;
		}

		if (!gameStarted && startGameTime < 0)
		{
			gameStartTime.gameObject.SetActive(false);
			gameStarted = true;
			playerPrefab.GetComponent<PlayerBehaviour>().enabled = true;
			if (!playerPrefab.GetComponent<Module3Minigame2PlayerMechanic>())
				playerPrefab.AddComponent<Module3Minigame2PlayerMechanic>();
			playerPrefab.GetComponent<Module3Minigame2PlayerMechanic>().enabled = true;
		}
	}

	void EndGame(bool win)
	{
		base.PunEndGame(win);
	}

	public void OnNextGameButton()
	{
		if (PhotonNetwork.isMasterClient)
			ReturnToWorldMap();
		//UnityEngine.SceneManagement.SceneManager.LoadScene("Minigame2");
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn

		for (int i = 0; i < photos.Length; i++)
			if (stream.isWriting)
				stream.SendNext((bool)photos[i]);
			else
			{
				bool lastPhoto = (bool)stream.ReceiveNext();
				photos[i] = (bool)lastPhoto;
			}
	}
}
