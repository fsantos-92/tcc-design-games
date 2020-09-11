using UnityEngine;
using System.Collections;

public enum FieldStatus
{
	dirty,
	dug,
	fertilized,
	sown,
	wet
}

[RequireComponent (typeof(PhotonView))]
public class Field : Photon.MonoBehaviour, IPunObservable
{
	public int ViewID { get { return this.photonView.viewID; } }

	public FieldStatus currentFieldStatus;

	void Start ()
	{
		GetComponent <PhotonView> ().ObservedComponents [0] = this;
		GetComponent <PhotonView> ().ownershipTransfer = OwnershipOption.Takeover;
		GetComponent <PhotonView> ().synchronization = ViewSynchronization.UnreliableOnChange;

		//currentFieldStatus = (FieldStatus)Random.Range (0, 4);
		currentFieldStatus = (FieldStatus)0;
	}

	void FixedUpdate ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			if (currentFieldStatus == FieldStatus.wet) {
				transform.GetChild (transform.childCount - 1).gameObject.SetActive (true);
				transform.GetChild (transform.childCount - 2).gameObject.SetActive (true);
			} else if (i == (int)currentFieldStatus)
				transform.GetChild (i).gameObject.SetActive (true);
			else
				transform.GetChild (i).gameObject.SetActive (false);
		}
	}

	public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext ((int)this.currentFieldStatus);
		} else {
			int lastFieldStatus = (int)stream.ReceiveNext ();
			currentFieldStatus = (FieldStatus)lastFieldStatus;
		}
	}
}
