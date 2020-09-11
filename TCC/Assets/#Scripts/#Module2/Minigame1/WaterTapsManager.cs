using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class WaterTapsManager : Photon.MonoBehaviour
{

	public struct WaterTap
	{
		public GameObject waterTap;
		public bool isOpen;
	}

	public int ViewID { get { return this.photonView.viewID; } }

	public WaterTap[] _waterTaps;

	void Start()
	{
		GetComponent<PhotonView>().ObservedComponents[0] = this;
		GetComponent<PhotonView>().ownershipTransfer = OwnershipOption.Takeover;
		GetComponent<PhotonView>().synchronization = ViewSynchronization.ReliableDeltaCompressed;

		_waterTaps = new WaterTap[transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
		{
			_waterTaps[i].waterTap = transform.GetChild(i).gameObject;
			_waterTaps[i].isOpen = true;
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn

		//for (int i = 0; i < _waterTaps.Length; i++)
		if (stream.isWriting)
		{
			//stream.SendNext((bool)_waterTaps[i].isOpen);
		}
		else
		{
			//bool lastWaterTapStatus = (bool)stream.ReceiveNext();
			//_waterTaps[i].isOpen = (bool)lastWaterTapStatus;
		}
	}

	[PunRPC]
	public void CloseWaterTap(int waterTapIndex)
	{
		_waterTaps[waterTapIndex].isOpen = false;
		_waterTaps[waterTapIndex].waterTap.GetComponent<AudioSource>().Stop();
		var emission = _waterTaps[waterTapIndex].waterTap.transform.GetComponentInChildren<ParticleSystem>().emission;
		emission.rateOverTime = 0;
	}
}
