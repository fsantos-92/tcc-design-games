using UnityEngine;
using UnityEngine.UI;

public class Module1Stage2Manager : StageManagerBase
{

	public static Module1Stage2Manager instance = null;

	public GameObject shovel;
	public GameObject waterCan;
	public GameObject fert;
	public GameObject seed;

	public ParticlesController Water;
	public ParticlesController Seed;
	public ParticlesController Dirty;

	public FieldsManeger fieldManeger;

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

		playerPrefab.GetComponent<PlayerBehaviour>().enabled = true;
		if (!playerPrefab.GetComponent<Minigame2PlayerMechanic>())
			playerPrefab.AddComponent<Minigame2PlayerMechanic>();
		playerPrefab.GetComponent<Minigame2PlayerMechanic>().enabled = true;
	}

	// Update is called once per frame
	void Update()
	{
		base.Update();

		if (gameTime <= 0)
		{
			playerPrefab.GetComponent<PlayerBehaviour>().enabled = false;
			playerPrefab.GetComponent<Minigame2PlayerMechanic>().enabled = false;
			PunEndGame(true);
		}
		else
			CheckFields();

		if (!gameStarted && startGameTime < 0)
		{
			gameStartTime.gameObject.SetActive(false);
			gameStarted = true;
			playerPrefab.GetComponent<PlayerBehaviour>().enabled = true;
			if (!playerPrefab.GetComponent<Minigame1PlayerMechanic>())
				playerPrefab.AddComponent<Minigame1PlayerMechanic>();
			playerPrefab.GetComponent<Minigame1PlayerMechanic>().enabled = true;
		}
	}

	public void CheckFields()
	{
		for (int i = 0; i < fieldManeger.fields.Length; i++)
			if (fieldManeger.fields[i].currentFieldStatus != FieldStatus.wet)
				return;

		PunEndGame(true);
	}

	public void OnNextGameButton()
	{
		if (PhotonNetwork.isMasterClient)
			//GameManager.LeaveRoom ();
			//UnityEngine.SceneManagement.SceneManager.LoadScene("Module1Minigame3");
			UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
		//ReturnToWorldMap();
	}

}
