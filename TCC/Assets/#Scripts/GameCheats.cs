using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCheats : MonoBehaviour
{
	bool createdQuickRoom = false;

	void LateUpdate()
	{
		if (PhotonNetwork.connected && PhotonNetwork.connectedAndReady)
		{
			if (!PhotonNetwork.inRoom)
			{
				if (Input.GetKey(KeyCode.F1) && !createdQuickRoom)
				{
					PhotonNetwork.JoinRandomRoom();
					createdQuickRoom = true;
				}
			}
			else
			{
				if (createdQuickRoom)
				{
					createdQuickRoom = false;
					SceneManager.LoadScene("WorldMap");
				}

				if (Input.GetKey(KeyCode.F1))
					SceneManager.LoadScene("WorldMap");
			}
		}
	}

	public void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.JoinOrCreateRoom("Room" + PhotonNetwork.countOfRooms, new RoomOptions() { MaxPlayers = 4 }, null);
	}
}
