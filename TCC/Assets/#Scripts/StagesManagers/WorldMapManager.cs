using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class MapButtonSettings
{
	public GameObject Button;
	public string RegionName = string.Empty;
	public string[] SceneNames;
	public string[] MinigameNames;
}

public class WorldMapManager : MonoBehaviour
{
	private string[] clickedButtonAvaliableGames;

	public Image ChoosenLevelImage;

	public GameObject ConfirmationPanel;
	public Text MessageText;

	[SerializeField]
	public MapButtonSettings[] MapButtonSettings;

	public Button[] Buttons;

	void Start()
	{
		//ConfirmationPanel.SetActive(false);

		clickedButtonAvaliableGames = new string[Buttons.Length];

		//foreach (MapButtonSettings item in MapButtonSettings)
			//if (item.SceneNames.Length <= 0)
				//item.Button.GetComponent<Button>().interactable = false;
	}

	public void OnPointerEnter(Animator animator)
	{
		//tocar som de feedback
		animator.SetBool("Rotating", true);
	}

	public void OnPointerExit(Animator animator)
	{
		animator.SetBool("Rotating", false);
	}

	public void OnClickButton(GameObject button)
	{
		if (!PhotonNetwork.isMasterClient)
			return;

		//clickedChoosenScene = scene;
		//ConfirmationPanel.SetActive(true);

		foreach (MapButtonSettings item in MapButtonSettings)
			if (item.Button == button)
			{
				MessageText.text = item.RegionName;
				ChoosenLevelImage.sprite = item.Button.GetComponent<Image>().sprite;

				for (int i = 0; i < Buttons.Length; i++)
				{
					if (i >= item.SceneNames.Length)
						Buttons[i].gameObject.SetActive(false);
					else
					{
						Buttons[i].gameObject.SetActive(true);
						Buttons[i].GetComponentInChildren<Text>().text = item.MinigameNames[i];
						clickedButtonAvaliableGames[i] = item.SceneNames[i];
					}
				}

				ConfirmationPanel.SetActive(true);

				break;
			}
	}

	public void OnOkButton(int buttonIndex)
	{
		if (PhotonNetwork.isMasterClient)
			GameManager.instance.LoadScene(clickedButtonAvaliableGames[buttonIndex]);
	}

	public void OnOkButton(string sceneName)
	{
		if (PhotonNetwork.isMasterClient)
			GameManager.instance.LoadScene(sceneName);
	}

	public void OnCancelButton()
	{
		ConfirmationPanel.SetActive(false);
		//clickedChoosenScene = null;
	}

	public void DisableElement(GameObject obj)
	{
		obj.SetActive(false);
	}
}
