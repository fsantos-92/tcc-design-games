using UnityEngine;

public class Minigame3PlayerMechanic : Photon.MonoBehaviour
{
	void OnTriggerStay(Collider hit)
	{
		if (hit.CompareTag("Poster") && Input.GetKeyDown(KeyCode.E))
		{
			Transform poster = Module1Stage3Manager.instance.transform.FindChild("PanelsManager").GetComponent<PanelsManager>().GetPoster(hit.transform);
			if (Module1Stage3Manager.instance.transform.FindChild("PanelsManager").GetComponent<PhotonView>().ownerId != PhotonNetwork.player.ID)
				Module1Stage3Manager.instance.transform.FindChild("PanelsManager").GetComponent<PhotonView>().TransferOwnership(GetComponent<PhotonView>().ownerId);

			poster.GetComponent<MeshRenderer>().enabled = true;
			GameManager.instance.photonView.RPC("Score", PhotonTargets.All, 5, PhotonNetwork.player.ID, true);

			if (Module1Stage3Manager.instance.transform.FindChild("PanelsManager").GetComponent<PhotonView>().ownerId != PhotonNetwork.player.ID)
				Module1Stage3Manager.instance.transform.FindChild("PanelsManager").GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.masterClient.ID);
		}
	}

	void OnTriggerEnter(Collider hit)
	{
		if (!isActiveAndEnabled)
			return;

		if (hit.CompareTag("PortalCollider"))
		{
			switch (hit.transform.parent.name)
			{
				case "Classroom":
					Camera.main.GetComponent<UnityStandardAssets.Utility.SmoothFollow>().enabled = true;
					gameObject.transform.position = Module1Stage3Manager.instance._CanteenSpawnPos[0].position;
					Camera.main.transform.position = Module1Stage3Manager.instance._canteenCameraPos.position;
					Camera.main.transform.rotation = Module1Stage3Manager.instance._canteenCameraPos.rotation;
					break;
				case "Canteen":
					gameObject.transform.position = Module1Stage3Manager.instance._PlaygroundSpawnPos[0].position;
					break;
				case "Playground":
					Camera.main.GetComponent<UnityStandardAssets.Utility.SmoothFollow>().enabled = false;
					Camera.main.transform.position = Module1Stage3Manager.instance._classCameraPos.position;
					Camera.main.transform.rotation = Module1Stage3Manager.instance._classCameraPos.rotation;
					gameObject.transform.position = Module1Stage3Manager.instance._ClassSpawnPos[0].position;
					break;
			}
		}
	}
}
