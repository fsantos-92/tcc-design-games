using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	private int currentModelIndex = 0;
	private int currentModelColorIndex = 0;

	public GameObject[] panels;

	public Button enterGameButton;
	public Button startGameButton;

	public InputField nameField;
	public InputField roomName;

	public Text roomNameTxt;

	public Image tutorialImage;

	public GameObject[] checkmarks;

	[SerializeField]
	public Models[] CharacterModels;

	// Use this for initialization
	void Start()
	{
		PanelsControl("MainMenuPanel");

		//GameManager.instance.CharacterModels = CharacterModels;
	}

	void FixedUpdate()
	{
		//enterGameButton.interactable = PhotonNetwork.connected;

		if (PhotonNetwork.room != null)
		{

			if (PhotonNetwork.isMasterClient && PhotonNetwork.playerList.Length >= 2)
			{
				startGameButton.interactable = true;
				startGameButton.gameObject.SetActive(true);

			}
			else if (PhotonNetwork.isMasterClient && PhotonNetwork.playerList.Length < 2)
			{
				startGameButton.interactable = false;
				startGameButton.gameObject.SetActive(true);

			}
			else
				startGameButton.gameObject.SetActive(false);


			//for (int l = 0; l < 4; l++)
			//	if (l < PhotonNetwork.playerList.Length)
			//		checkmarks [l].SetActive (true);
			//	else
			//		checkmarks [l].SetActive (false);
			roomNameTxt.text = PhotonNetwork.room.Name;
		}
		else
			roomNameTxt.text = null;

		if (tutorialImage.IsActive())
		{
			if (Input.anyKey)
				tutorialImage.gameObject.SetActive(false);
		}
	}

	public void OnCreditsButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
	}

	public void OnQuitButton()
	{
		Application.Quit();
	}

	public void PanelsControl(string panelName)
	{
		for (int i = 0; i < panels.Length; i++)
		{
			if (panels[i].name == panelName)
			{
				panels[i].SetActive(true);
			}
			else
				panels[i].SetActive(false);
		}
	}

	public void OnCreateOrJoinRoomButton()
	{
		if (roomName.text != null && roomName.text != "")
		{
			PhotonNetwork.JoinOrCreateRoom(roomName.text, new RoomOptions() { MaxPlayers = 4 }, null);
			PanelsControl("RoomPanel");

			RefreshCheckmarks();

		}
		else
			Debug.Log("Nome da sala!");
	}

	void OnPhotonJoinRoomFailed(object[] codeAndMsg)
	{
		// codeAndMsg[0] is short ErrorCode. codeAndMsg[1] is string debug msg. 
		for (int i = 0; i < codeAndMsg.Length; i++)
		{
			Debug.Log(codeAndMsg[i].ToString());
		}
	}

	void OnJoinedRoom()
	{
		PanelsControl("RoomPanel");

		RefreshCheckmarks();
	}

	void OnPhotonPlayerConnected()
	{
		RefreshCheckmarks();

	}

	void OnPhotonPlayerDisconnected()
	{
		RefreshCheckmarks();

	}

	void RefreshCheckmarks()
	{
		for (int l = 0; l < 4; l++)
			if (l < PhotonNetwork.playerList.Length)
			{
				checkmarks[l].SetActive(true);
				checkmarks[l].GetComponentInChildren<Text>().text = PhotonNetwork.playerList[l].NickName;
			}
			else
				checkmarks[l].SetActive(false);
	}

	public void OnNextOrPreviouslyColorButton(int sign)
	{
		currentModelColorIndex = sign > 0 && currentModelColorIndex == CharacterModels[currentModelIndex].ModelTextures.Length - 1 ? 0 : (currentModelColorIndex == 0 && sign < 0 ? currentModelColorIndex = CharacterModels[currentModelIndex].ModelTextures.Length - 1 : currentModelColorIndex + sign);
		ChangeCharacterColor();
	}

	public void OnNextOrPreviouslyCharacterButton(int sign)
	{
		CharacterModels[currentModelIndex].Model.SetActive(false);
		currentModelIndex = sign > 0 && currentModelIndex == CharacterModels.Length - 1 ? 0 : (currentModelIndex == 0 && sign < 0 ? currentModelIndex = CharacterModels.Length - 1 : currentModelIndex + sign);
		CharacterModels[currentModelIndex].Model.SetActive(true);
		currentModelColorIndex = 0;
		ChangeCharacterColor();
	}

	void ChangeCharacterColor()
	{
		CharacterModels[currentModelIndex].Model.transform.FindChild("Graphics").GetComponentInChildren<Renderer>().sharedMaterial = CharacterModels[currentModelIndex].ModelTextures.Length > 0 ? CharacterModels[currentModelIndex].ModelTextures[currentModelColorIndex] : CharacterModels[currentModelIndex].Model.GetComponentInChildren<Renderer>().sharedMaterial;
	}

	public void OnDoneCreatingChar()
	{
		if (nameField.text != null && nameField.text != "")
		{
			PhotonNetwork.playerName = nameField.text;
			PanelsControl("LobbyPanel");
		}

		GameManager.instance.CharacterModel = currentModelIndex;
		Debug.Log(currentModelIndex);
		GameManager.instance.CharacterTexture = currentModelColorIndex;
		Debug.Log(currentModelColorIndex);
	}

	public void OnPlayButton()
	{
		//UnityEngine.SceneManagement.SceneManager.LoadScene("School");
		UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
	}

	public void LeaveRoom()
	{
		GameManager.LeaveRoom();
	}

	public void OnCutscene1()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Cutscene_Modulo1");

	}
	public void OnCutscene2()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Cutscene_Modulo2");

	}
	public void OnCutscene3()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Cutscene_Modulo3");

	}
	public void OnCutscene4()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameContext2");

	}

}
