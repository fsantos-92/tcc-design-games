using UnityEngine.UI;
using UnityEngine;

public class PlayersNamesDisplay : MonoBehaviour
{
	[HideInInspector]public Text myName;
	[HideInInspector]public Text[] playersNames;

	float playerNameOffset = 1.5f;

	// Use this for initialization
	void Start () {
		myName.text = PhotonNetwork.player.NickName;
	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < GameManager.playersInGame.Length; i++)
		{
			if (!playersNames[i].gameObject.activeSelf)
				playersNames[i].gameObject.SetActive(true);

			playersNames[i].text = GameManager.playersInGame[i].GetComponent<PhotonView>().owner.NickName;
			playersNames[i].transform.position = Camera.main.WorldToScreenPoint(new Vector3(
				GameManager.playersInGame[i].transform.position.x, 
				GameManager.playersInGame[i].transform.position.y + playerNameOffset, 
				GameManager.playersInGame[i].transform.position.z
				));
		}
	}
}
