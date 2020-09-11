using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2Stage1Manager : StageManagerBase
{
	public static Module2Stage1Manager instance = null;

	public WaterTapsManager _waterTapsManager;

	public AudioClip WaterTapClosingSFX;

	public GameObject DialogBoxJorge;
	public GameObject DialogBoxEdite;
	public GameObject DialogBoxFatima;
	public GameObject DialogBoxNelson;
	public GameObject DialogBoxClaudia;
	public GameObject DialogBoxRosa;
	public GameObject DialogBoxAlberto;
	public GameObject DialogBoxCarlos;

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

		DialogBoxJorge.SetActive(false);
		DialogBoxEdite.SetActive(false);
		DialogBoxFatima.SetActive(false);
		DialogBoxNelson.SetActive(false);
		DialogBoxClaudia.SetActive(false);
		DialogBoxRosa.SetActive(false);
		DialogBoxAlberto.SetActive(false);
		DialogBoxCarlos.SetActive(false);

		//Camera.main.GetComponent<UnityStandardAssets.Utility.SmoothFollow>().target = playerPrefab.transform;
		Camera.main.GetComponent<WowCamera>().Target = playerPrefab.transform;
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
			objectiveScore = 0;
			bool isGameEnded = true;

			for (int i = 0; i < _waterTapsManager._waterTaps.Length; i++)
				if (!_waterTapsManager._waterTaps[i].isOpen)
					objectiveScore++;
				else if (isGameEnded)
					isGameEnded = false;

			objectiveScoreTxt.text = string.Format("{0}/{1}", objectiveScore, _waterTapsManager._waterTaps.Length);

			if (isGameEnded)
				EndGame(true);
		}

		if (!gameStarted && startGameTime < 0)
		{
			gameStartTime.gameObject.SetActive(false);
			gameStarted = true;
			playerPrefab.GetComponent<PlayerBehaviour>().enabled = true;
			if (!playerPrefab.GetComponent<Module2Minigame1PlayerMechanic>())
				playerPrefab.AddComponent<Module2Minigame1PlayerMechanic>();
			playerPrefab.GetComponent<Module2Minigame1PlayerMechanic>().enabled = true;
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
}
