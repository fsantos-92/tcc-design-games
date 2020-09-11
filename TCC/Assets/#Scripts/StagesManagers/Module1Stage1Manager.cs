using UnityEngine;
using UnityEngine.UI;

public enum TrashType { None, Glass, Metal, Paper, Plastic }

public class Module1Stage1Manager : StageManagerBase
{
	public static Module1Stage1Manager instance = null;

	//public string currentTrashType;
	public TrashType currentTrashType = TrashType.None;

	//private float gameTime = 0;
	//private int sign = 1;
	//public bool startFromZero = false;
	//public float startTime = 181;
	//public float startGameTime = 6;
	//bool gameStarted = false;

	//public Text cron;
	//public Text gameStartTime;

	public Text trash;

	//public Image[] numbers;
	public Image metalPlate;
	public Image paperPlate;
	public Image plasticPlate;
	public Image glassPlate;

	public TrashManager TrashManager;

	public AudioClip ItemPickupSound;
	public AudioClip ItemDropSound;

	void Start()
	{
		#region SingletonAwake

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		#endregion

		base.Start();

		//if (!startFromZero)
		//{
		//	sign = -1;
		//	gameTime = startTime;
		GetGarbage(TrashType.Glass);
		//}
	}

	// Update is called once per frame
	void Update()
	{
		base.Update();

		if (gameStarted)
		{
			if (gameTime <= 136)
			{
				GetGarbage(TrashType.Metal);
			}
			if (gameTime <= 91)
			{
				GetGarbage(TrashType.Paper);
			}
			if (gameTime <= 46)
			{
				GetGarbage(TrashType.Plastic);
			}
		}
		//if (!gameStarted && startGameTime < 0)
		else if (startGameTime < 0)
		{
			gameStartTime.gameObject.SetActive(false);
			gameStarted = true;
			playerPrefab.GetComponent<PlayerBehaviour>().enabled = true;
			if (!playerPrefab.GetComponent<Minigame1PlayerMechanic>())
				playerPrefab.AddComponent<Minigame1PlayerMechanic>();
			playerPrefab.GetComponent<Minigame1PlayerMechanic>().enabled = true;
		}
	}

	void GetGarbage(TrashType trashType)
	{
		glassPlate.gameObject.SetActive(false);
		metalPlate.gameObject.SetActive(false);
		plasticPlate.gameObject.SetActive(false);
		paperPlate.gameObject.SetActive(false);

		switch (trashType)
		{
			case TrashType.Glass:
				glassPlate.gameObject.SetActive(true);
				Module1Stage1Manager.instance.currentTrashType = TrashType.Glass;
				break;
			case TrashType.Metal:
				metalPlate.gameObject.SetActive(true);
				Module1Stage1Manager.instance.currentTrashType = TrashType.Metal;
				break;
			case TrashType.Plastic:
				plasticPlate.gameObject.SetActive(true);
				currentTrashType = TrashType.Plastic;
				break;
			case TrashType.Paper:
				paperPlate.gameObject.SetActive(true);
				Module1Stage1Manager.instance.currentTrashType = TrashType.Paper;
				break;
		}
	}

	void EndGame(bool win)
	{
		//finalScoreTxt.text = score.ToString();
		base.PunEndGame(win);
		//playerPrefab.GetComponent<Minigame1PlayerMechanic>().enabled = false;
	}

	public void OnNextGameButton()
	{
		if (PhotonNetwork.isMasterClient)
			//	ReturnToWorldMap();
			//UnityEngine.SceneManagement.SceneManager.LoadScene("Module1Minigame2");
			UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");

	}
}
