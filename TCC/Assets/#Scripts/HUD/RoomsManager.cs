using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RoomsManager : Photon.MonoBehaviour {

	RoomInfo[] _roomList;
	Button[] _openRoomsList = new Button[0];

	public float secondsToAutoResfresh = 2;
	float secondsToAutoResfreshCounter = 0;

	public Button _roomButtonModel;
	public Transform _openRoomsPanel;

	void Update()
	{
		if (secondsToAutoResfreshCounter >= secondsToAutoResfresh)
		{
			RefreshRoomList();
			Debug.Log("Auto Refresh");
		}
		else secondsToAutoResfreshCounter += Time.deltaTime;
	}

	void OnJoinedLobby()
	{
		RefreshRoomList();
		Debug.Log("Lobby Refresh");
	}

	public void RefreshRoomList()
	{
		secondsToAutoResfreshCounter = 0;

		if (_openRoomsList.Length > 0)
		{
			for (int i = 0; i < _openRoomsList.Length; i++)
			{
				Destroy(_openRoomsList[i].gameObject);
			}
		}

		_roomList = PhotonNetwork.GetRoomList();
		_openRoomsList = new Button[_roomList.Length];

			for (int j = 0; j < _roomList.Length; j++)
		{
			_openRoomsList[j] = (Button)Instantiate(_roomButtonModel, _openRoomsPanel);
			_openRoomsList[j].onClick.AddListener(OnClickRoom);
			_openRoomsList[j].name = _roomList[j].Name;
			_openRoomsList[j].GetComponentInChildren<Text>().text = string.Format("{0}\n{1}/{2}", _roomList[j].Name, _roomList[j].PlayerCount,_roomList[j].MaxPlayers);
		}
	}

	public void OnClickRoom()
	{
		string roomName = EventSystem.current.currentSelectedGameObject.name;
		PhotonNetwork.JoinRoom(roomName);
	}

	void OnPhotonJoinRoomFailed()
	{
		//Mostrar janela de erro dizendo Erro ao entrar na sala. Por favor, tente novamente."
	}
}
