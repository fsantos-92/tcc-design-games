using UnityEngine;

[RequireComponent(typeof(PhotonView))]

public class HolesManager : Photon.MonoBehaviour
{
	public int ViewID { get { return this.photonView.viewID; } }


	public GameObject[] Holes;

	// Use this for initialization
	void Start()
	{
		GetComponent<PhotonView>().ObservedComponents[0] = this;
		GetComponent<PhotonView>().ownershipTransfer = OwnershipOption.Takeover;
		GetComponent<PhotonView>().synchronization = ViewSynchronization.UnreliableOnChange;

		foreach (GameObject item in Holes)
			item.SetActive(true);
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn

		foreach (GameObject item in Holes)
		{
			if (stream.isWriting)
			{
				stream.SendNext((bool)item.activeSelf);
			}
			else
			{
				bool lastActive = (bool)stream.ReceiveNext();
				item.SetActive((bool)lastActive);
			}
		}
	}
}
