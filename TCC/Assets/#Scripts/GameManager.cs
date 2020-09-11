using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public struct Models
{
	public GameObject Model;
	public Material[] ModelTextures;
	public Sprite CharacterFace;
}

public class GameManager : Photon.MonoBehaviour
{

	#region SingletonDeclaration

	public static GameManager instance = null;

	#endregion

	public bool AutoConnect = true;

	public GameObject PlayerPrefab { get; set; }
	public int CharacterModel { get; set; }
	public int CharacterTexture { get; set; }

	const string version = "v1";

	bool connected = false;
	bool connecting = false;
	bool disconnected = false;

	public string ipAdress = null;

	[HideInInspector]
	public static bool _ingame = false;
	public static GameObject[] playersInGame;

	[SerializeField]
	public Models[] CharacterModels;

	public int _Score;

	public string LoadingSceneName { get; set; }

	public System.Collections.Generic.Dictionary<string, bool> UnlockedMinigames = new System.Collections.Generic.Dictionary<string, bool>()
	{
		{ "School",true },
		{ "Module1Minigame1",true },
		{ "Module1Minigame2",false },
		{ "Module1Minigame3",false },
		{ "Module2Minigame1",false },
		{ "Module2Minigame2",false },
		{ "Module2Minigame3",false },
		{ "Module3Minigame1",false },
		{ "Module3Minigame2",false },
		{ "Module3Minigame3",false },
	};

	void Awake()
	{
		#region SingletonAwake

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		#endregion

#if !UNITY_EDITOR
		Debug.logger.logEnabled = false;
#endif
		LoadingSceneName = string.Empty;
	}

	// Use this for initialization
	void Start()
	{
		ipAdress = Network.player.ipAddress;

		if (!AutoConnect)
			return;

		Connect();
	}

	public void Connect()
	{
		PhotonNetwork.ConnectUsingSettings(version);
		Debug.Log("Connecting...");
		PhotonNetwork.automaticallySyncScene = true;
	}

	void OnConnectedToPhoton()
	{
		Debug.Log("Connected!");
	}

	void OnDisconnectedFromPhoton()
	{
		Debug.Log("Disconnected.");
	}

	void OnFailedToConnectToPhoton()
	{
		Debug.Log("Failed To Connect To Photon. Trying again...");
		Connect();
	}

	public static void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
	}

	void OnPhotonPlayerConnected()
	{
		playersInGame = GameObject.FindGameObjectsWithTag("Player");
	}

	void OnPhotonPlayerDisconnected()
	{
		playersInGame = GameObject.FindGameObjectsWithTag("Player");
	}

	void OnApplicationQuit()
	{
		PhotonNetwork.Disconnect();
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn

		if (stream.isWriting)
		{
		}
		else
		{
		}
	}

	public void LoadScene(string sceneName)
	{
		//UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
		photonView.RPC("SetScene", PhotonTargets.All, sceneName);
	}

	[PunRPC]
	void Score(int score, int playerToShowID, bool isRight)
	{
		GetComponent<ScoreManager>().Score(score, playerToShowID, isRight);
	}

	[PunRPC]
	void SetScene(string sceneName)
	{
		LoadingSceneName = sceneName;
		Debug.Log("Loading Scene:" + LoadingSceneName);

		if (PhotonNetwork.isMasterClient)
			//PhotonNetwork.LoadLevel("LoadingScene");
			UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
	}

	[PunRPC]
	void InstantiatePlayer(int modelNumber, int textureNumber, Vector3 spawnPosition, int myNumber)
	{
		GameObject playerPrefab = null;
		//playersInGame[playersInGame.Length] = playerPrefab;

		if (photonView.ownerId == myNumber)
		{
			playerPrefab = PhotonNetwork.Instantiate(CharacterModels[modelNumber].Model.name, spawnPosition, Quaternion.identity, 0);
			PlayerPrefab = playerPrefab;
		}

		if (textureNumber > 0)
			playerPrefab.GetComponentInChildren<Renderer>().sharedMaterial = CharacterModels[modelNumber].ModelTextures[textureNumber];
	}

	[PunRPC]
	void CharacterSetting(int modelNumber, int textureNumber, int myNumber)
	{
		playersInGame = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject item in playersInGame)
			if (item.GetComponent<PhotonView>().viewID == myNumber && CharacterModels[modelNumber].ModelTextures.Length > 0)
				item.transform.FindChild("Graphics").GetComponentInChildren<Renderer>().sharedMaterial = CharacterModels[modelNumber].ModelTextures[textureNumber];
	}

	[PunRPC]
	void EndGame(bool win)
	{
		GameObject.Find("StageManager").GetComponent<StageManagerBase>().EndGame(win);
	}

	void OnGUI()
	{
		//GUI.Label(new Rect(10, 40, 100, 100), ipAdress);
	}
}