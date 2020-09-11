using UnityEngine;
using UnityEngine.UI;

public class Module1Stage3Manager : StageManagerBase
{

	public static Module1Stage3Manager instance = null;

	[HideInInspector]
	public Transform _classCameraPos;
	[HideInInspector]
	public Transform _playgroundCameraPos;
	[HideInInspector]
	public Transform _canteenCameraPos;

	public Transform[] _ClassSpawnPos;
	public Transform[] _PlaygroundSpawnPos;
	public Transform[] _CanteenSpawnPos;

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

		Camera.main.GetComponent<UnityStandardAssets.Utility.SmoothFollow>().target = playerPrefab.transform;

		_classCameraPos = transform.FindChild("ClassCameraPosition");
		_playgroundCameraPos = transform.FindChild("PlaygroundCameraPosition");
		_canteenCameraPos = transform.FindChild("CanteenCameraPosition");

		playerPrefab.GetComponent<PlayerBehaviour>().enabled = true;
		if (!playerPrefab.GetComponent<Minigame3PlayerMechanic>())
			playerPrefab.AddComponent<Minigame3PlayerMechanic>();
		playerPrefab.GetComponent<Minigame3PlayerMechanic>().enabled = true;
	}

	// Update is called once per frame
	void Update()
	{
		base.Update();
	}

	public void OnNextGameButton()
	{
		//if (PhotonNetwork.isMasterClient)
		//GameManager.LeaveRoom ();
		ReturnToWorldMap();
	}
}
