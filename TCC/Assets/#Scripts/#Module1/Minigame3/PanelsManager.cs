using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class PanelsManager : Photon.MonoBehaviour
{
	public int ViewID { get { return this.photonView.viewID; } }

	public Transform[] _posters;

	// Use this for initialization
	void Start () {

		GetComponent<PhotonView>().ObservedComponents[0] = this;
		GetComponent<PhotonView>().ownershipTransfer = OwnershipOption.Takeover;
		GetComponent<PhotonView>().synchronization = ViewSynchronization.UnreliableOnChange;

		foreach (Transform poster in _posters)
		{
			poster.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		foreach (Transform poster in _posters)
		{
			if (poster.GetComponent<MeshRenderer>().enabled)
				poster.GetChild(0).gameObject.SetActive(false);

			if (!poster.GetComponent<MeshRenderer>().enabled)
				poster.GetChild(0).gameObject.SetActive(true);
		}
	}

	public Transform GetPoster(Transform poster)
	{
		foreach(Transform newPoster in _posters)
		{
			if (poster == newPoster)
				return newPoster;
		}

		return null;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn

		for (int i = 0; i < _posters.Length; i++)
		{
			if (stream.isWriting)
			{
				stream.SendNext((bool)_posters[i].GetComponent<MeshRenderer>().enabled);
			}
			else
			{
				bool isRendererEnabled = (bool)stream.ReceiveNext();
				_posters[i].GetComponent<MeshRenderer>().enabled = (bool)isRendererEnabled;
			}
		}
	}
}
