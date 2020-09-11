using UnityEngine;

public class Module3Stage1Manager : StageManagerBase
{
	public static Module3Stage1Manager instance = null;

	public HolesManager HolesManager;

	public Wheelchair WheelChair;

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

			playerPrefab.GetComponent<Module3Minigame1PlayerMechanic>().enabled = false;

			PunEndGame(false);
		}

		if (!gameStarted && startGameTime < 0)
		{
			gameStartTime.gameObject.SetActive(false);
			gameStarted = true;
			playerPrefab.GetComponent<PlayerBehaviour>().enabled = true;

			playerPrefab.AddComponent<Module3Minigame1PlayerMechanic>();
		}
	}
}
