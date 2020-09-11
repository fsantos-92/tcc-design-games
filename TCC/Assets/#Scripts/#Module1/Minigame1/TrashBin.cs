using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class TrashBin : MonoBehaviour
{
	public TrashType BinType = TrashType.None;

	//void OnCollisionEnter(Collision hit)
	void OnTriggerEnter(Collider hit)
	{
		Debug.Log("Colided on " + gameObject.name + " with " + hit.gameObject.name);
		if (hit.gameObject.GetComponent<Trash>())
		{
			Debug.Log("trash type: " + hit.gameObject.GetComponent<Trash>().Type);
			switch (hit.gameObject.GetComponent<Trash>().Type)
			{
				case TrashType.None:
					break;

				case TrashType.Glass:
					if (BinType == TrashType.Glass)
						RightTrash(hit);
					else
						WrongTrash();
					break;

				case TrashType.Metal:
					if (BinType == TrashType.Metal)
						RightTrash(hit);
					else
						WrongTrash();
					break;

				case TrashType.Paper:
					if (BinType == TrashType.Paper)
						RightTrash(hit);
					else
						WrongTrash();
					break;

				case TrashType.Plastic:
					if (BinType == TrashType.Plastic)
						RightTrash(hit);
					else
						WrongTrash();
					break;

				default:
					break;
			}
		}
	}

	void RightTrash(Collider hit)
	{
		GameManager.instance.photonView.RPC("Score", PhotonTargets.All, 10, PhotonNetwork.player.ID, true);
		Module1Stage1Manager.instance.TrashManager.photonView.RPC("DeleteTrash", PhotonTargets.Others, Module1Stage1Manager.instance.TrashManager.IngameGarbages.IndexOf(hit.gameObject.GetComponent<Trash>()));
		//hit.gameObject.GetComponent<Trash>().photonView.TransferOwnership(PhotonNetwork.masterClient.ID);
		PhotonNetwork.Destroy(hit.gameObject);
	}

	void WrongTrash()
	{
		GameManager.instance.photonView.RPC("Score", PhotonTargets.All, -5, PhotonNetwork.player.ID, false);
	}
}
