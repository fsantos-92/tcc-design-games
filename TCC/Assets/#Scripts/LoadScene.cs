using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : Photon.MonoBehaviour
{
	public int ViewID { get { return this.photonView.viewID; } }

	#region SingletonDeclaration

	public static LoadScene instance = null;

	#endregion

	private string sceneToLoad;

	public Image[] Frames;
	public Text[] percentLoaded;
	public Image[] readyImage;

	public Text LoadingText;

	private float myLoadPercentage = 0;

	private bool canStartGame = false;

	private bool[] playersReady;

	void Awake()
	{
		//if (!photonView.isMine)
		//Destroy(this);

		#region SingletonAwake

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		#endregion

		playersReady = new bool[PhotonNetwork.playerList.Length];

		for (int i = 0; i < playersReady.Length; i++)
		{
			Frames[i].gameObject.SetActive(true);
			playersReady[i] = false;
		}

		StartCoroutine(LoadNewScene());
	}

	public IEnumerator LoadNewScene()
	{
		yield return new WaitForSeconds(2f);

		Debug.Log("player.ID: " + PhotonNetwork.player.ID);
		Debug.Log("ownerId: " + photonView.ownerId);

		AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(GameManager.instance.LoadingSceneName);
		async.allowSceneActivation = false;

		while (async.progress < .9f || !canStartGame)
		{
			myLoadPercentage = async.progress * 100;
			Debug.Log(myLoadPercentage);
			percentLoaded[PhotonNetwork.player.ID - 1].text = string.Format("{0:0}%", myLoadPercentage);

			if (!playersReady[PhotonNetwork.player.ID - 1] && async.progress < .9f)
				photonView.RPC("ImReady", PhotonTargets.All, PhotonNetwork.player.ID - 1);

			yield return new WaitForEndOfFrame();
		}

		async.allowSceneActivation = true;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn
		if (stream.isWriting)
			for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
				stream.SendNext(percentLoaded[i].text);
		else
			for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
				percentLoaded[i].text = (string)stream.ReceiveNext();
	}

	[PunRPC]
	public void ImReady(int id)
	{

		playersReady[id] = true;
		readyImage[id].gameObject.SetActive(true);
		percentLoaded[id].gameObject.SetActive(false);

		foreach (bool rdy in playersReady)
			if (!rdy)
				return;

		canStartGame = true;
	}
}