using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	//public static ScoreManager instance = null;

	float signTime = 2;
	int playerToSignID = 0;
	float playerSignOffset = 1.5f;

	public AudioClip wrongSound;
	public AudioClip rightSound;
	[HideInInspector]
	public Image wrong;
	[HideInInspector]
	public Image right;

	[HideInInspector]
	public AudioSource effectsAS;

	public void Score(int score, int playerToShowID, bool isRight)
	{
		playerToSignID = playerToShowID;

		Image signToShow = null;

		if (isRight)
		{
			effectsAS.clip = rightSound;
			signToShow = right;
		}
		else
		{
			effectsAS.clip = wrongSound;
			signToShow = wrong;
		}

		/*for (int i = 0; i < GameManager.playersInGame.Length; i++)
		{
			if (GameManager.playersInGame[i].GetComponent<PhotonView>().ownerId == playerToSignID)
			{

				signToShow.transform.position = Camera.main.WorldToScreenPoint(new Vector3(
					GameManager.playersInGame[i].transform.position.x,
					GameManager.playersInGame[i].transform.position.y + playerSignOffset,
					GameManager.playersInGame[i].transform.position.z
			));
				break;
			}
		}*/
		StopCoroutine(ShowSign(signToShow));
		StopCoroutine(PositionSign(signToShow, playerToShowID));

		effectsAS.Play();
		StartCoroutine(ShowSign(signToShow));
		StartCoroutine(PositionSign(signToShow, playerToShowID));

		GameManager.instance._Score += score;
	}

	IEnumerator ShowSign(Image sign)
	{
		sign.gameObject.SetActive(true);
		yield return new WaitForSeconds(signTime);
		sign.gameObject.SetActive(false);
	}

	IEnumerator PositionSign(Image sign, int playerToShowID)
	{
		while(sign.gameObject.activeSelf)
		{
			for (int i = 0; i < GameManager.playersInGame.Length; i++)
			{
				if (GameManager.playersInGame[i].GetComponent<PhotonView>().ownerId == playerToSignID)
				{

					sign.transform.position = Camera.main.WorldToScreenPoint(new Vector3(
						GameManager.playersInGame[i].transform.position.x,
						GameManager.playersInGame[i].transform.position.y + playerSignOffset,
						GameManager.playersInGame[i].transform.position.z
				));
					break;
				}
			}
			yield return new WaitForEndOfFrame();
		}
	}
}
