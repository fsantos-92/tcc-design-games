using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageManagerBase : MonoBehaviour
{
	protected GameObject playerPrefab;
	Transform[] spawnPosition;

	[Header("Identification Elements")]
	public Text[] playersNames;
	public Text myName;
	public PlayersNamesDisplay PlayerNamesManager { get; private set; }

	public Image wrong;
	public Image right;

	[Space()]
	[Header("Sound")]
	public AudioClip initialMusic;
	public AudioClip loopMusic;
	public AudioClip finalScoreMusic;
	public AudioSource audio;
	public AudioSource effectsAS;

	[Space()]
	[Header("Game Time")]
	protected float gameTime = 0;
	protected int sign = 1;
	public bool startFromZero = false;
	public float startTime = 181;
	protected float startGameTime = 4;
	protected bool gameStarted = false;
	public Text cron;
	public Text gameStartTime;
	public Image[] numbers;

	[Space()]
	[Header("Score Settings")]
	public int score;
	public Text objectiveScoreTxt;
	public int objectiveScore = 0;
	//public Image finalScore;
	//public Text finalScoreTxt;

	[Space()]
	[Header("End Game Settings")]
	public Image VictoryScreen;
	public Image DefeatScreen;

	protected void Awake()
	{
		this.enabled = false;
	}

	// Use this for initialization
	public void Start()
	{
		//playerPrefab = GameManager.instance.PlayerPrefab;

		spawnPosition = new Transform[4];

		for (int i = 0; i < 4; i++)
			spawnPosition[i] = transform.GetChild(i);

		//if (!GameManager.instance.gameObject.GetComponent<PlayersNamesDisplay>())
		PlayerNamesManager = gameObject.AddComponent<PlayersNamesDisplay>();

		PlayerNamesManager.playersNames = playersNames;
		PlayerNamesManager.myName = myName;
		myName.transform.parent.FindChild("Image").GetComponent<Image>().sprite = GameManager.instance.CharacterModels[GameManager.instance.CharacterModel].CharacterFace;

		GameManager.instance.gameObject.GetComponent<ScoreManager>().effectsAS = effectsAS;
		GameManager.instance.gameObject.GetComponent<ScoreManager>().wrong = wrong;
		GameManager.instance.gameObject.GetComponent<ScoreManager>().right = right;

		audio = GetComponent<AudioSource>();
		audio.loop = true;
		StartCoroutine(playEngineSound());

		playerPrefab = PhotonNetwork.Instantiate(GameManager.instance.CharacterModels[GameManager.instance.CharacterModel].Model.name, spawnPosition[PhotonNetwork.player.ID - 1].position, Quaternion.identity, 0);
		GameManager.instance.photonView.RPC("CharacterSetting", PhotonTargets.All, GameManager.instance.CharacterModel, GameManager.instance.CharacterTexture, playerPrefab.GetComponent<PhotonView>().viewID);

		playerPrefab.GetComponent<PlayerBehaviour>().enabled = false;

		if (!startFromZero)
		{
			sign = -1;
			gameTime = startTime;
		}

		int minutes = (int)(gameTime / 60);
		int seconds = (int)(gameTime % 60);
		cron.text = string.Format("{0:0}:{1:00}", minutes, seconds);
	}

	protected virtual void Update()
	{
		objectiveScoreTxt.text = GameManager.instance._Score.ToString();

		if (gameStarted)
		{
			gameTime = gameTime + sign * Time.deltaTime;

			if (gameTime <= 0)
				PunEndGame(false);

			if (gameTime > 0)
			{

				int minutes = (int)(gameTime / 60);
				int seconds = (int)(gameTime % 60);
				cron.text = string.Format("{0:0}:{1:00}", minutes, seconds);
			}
		}
		else
		{
			startGameTime = startGameTime + sign * Time.deltaTime;

			if (startGameTime < 1 && startGameTime >= 0)
			{
				//gameStartTime.text = "START!";
				//gameStartTime.gameObject.SetActive(true);

				numbers[0].gameObject.SetActive(false);
				numbers[1].gameObject.SetActive(false);
				numbers[2].gameObject.SetActive(false);
			}
			else if (startGameTime >= 1)
			{
				if (startGameTime >= 3)
				{
					numbers[2].gameObject.SetActive(true);
					numbers[1].gameObject.SetActive(false);
					numbers[0].gameObject.SetActive(false);
				}
				else if (startGameTime < 3 && startGameTime >= 2)
				{
					numbers[1].gameObject.SetActive(true);
					numbers[0].gameObject.SetActive(false);
					numbers[2].gameObject.SetActive(false);

				}
				else if (startGameTime < 2 && startGameTime >= 1)
				{
					numbers[0].gameObject.SetActive(true);
					numbers[1].gameObject.SetActive(false);
					numbers[2].gameObject.SetActive(false);
				}
			}
		}
	}

	public virtual void PunEndGame(bool win)
	{
		GameManager.instance.photonView.RPC("EndGame", PhotonTargets.All, win);
	}


	public virtual void EndGame(bool win)
	{
		playerPrefab.GetComponent<PlayerBehaviour>().enabled = false;
		//finalScore.gameObject.SetActive(true);
		//finalScoreTxt.text = score.ToString();
		audio.clip = finalScoreMusic;
		audio.Play();
		//if (PhotonNetwork.isMasterClient)
		//finalScore.transform.GetChild(0).gameObject.SetActive(true);

		if (!win)
		{
			DefeatScreen.gameObject.SetActive(true);
			if (PhotonNetwork.isMasterClient)
				DefeatScreen.GetComponentInChildren<Button>().interactable = true;
		}
		else
		{
			VictoryScreen.gameObject.SetActive(true);
			if (PhotonNetwork.isMasterClient)
				VictoryScreen.GetComponentInChildren<Button>().interactable = true;
		}
	}

	IEnumerator playEngineSound()
	{
		audio.clip = initialMusic;
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = loopMusic;
		audio.Play();
	}

	public void ReturnToWorldMap()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
	}
}
