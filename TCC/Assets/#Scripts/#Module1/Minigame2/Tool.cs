using UnityEngine;
using System.Collections;

public enum Tools
{
	None = 0,
	Fertilizer = 1,
	Seeds = 2,
	Shovel = 3,
	WaterCan = 4
}

[RequireComponent (typeof(PhotonView))]
[RequireComponent (typeof(PickupItem))]
public class Tool : Photon.MonoBehaviour, IPunObservable
{
	public int ViewID { get { return this.photonView.viewID; } }

	public Tools tool = Tools.None;

	// Use this for initialization
	void Start ()
	{
		GetComponent <PhotonView> ().ObservedComponents [0] = this;
		GetComponent <PhotonView> ().ObservedComponents.Add (GetComponent <PickupItem> ());

		GetComponent <PhotonView> ().synchronization = ViewSynchronization.UnreliableOnChange;
	}

	public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn

		if (stream.isWriting) {
		} else {
		}
	}
}
