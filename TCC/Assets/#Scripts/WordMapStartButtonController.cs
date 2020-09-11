using UnityEngine;

public class WordMapStartButtonController : MonoBehaviour
{
	void awake()
	{
		if (!PhotonNetwork.isMasterClient)
			GetComponent<UnityEngine.UI.Button>().interactable = false;
	}
}
