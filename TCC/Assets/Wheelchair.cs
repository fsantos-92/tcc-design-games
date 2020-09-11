using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelchair : Photon.MonoBehaviour
{
	public int ViewID { get { return this.photonView.viewID; } }

	public bool isHeld = false;


	// Use this for initialization
	void Start()
	{
		photonView.ObservedComponents.Add(this);
	}

	public void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.CompareTag("amarelo") || hit.gameObject.CompareTag("vermelho") || hit.gameObject.CompareTag("pessoa") || hit.gameObject.CompareTag("poste"))
			GameManager.instance.gameObject.GetComponent<ScoreManager>().Score(-10, GetComponent<PhotonView>().ownerId, false);


	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.CompareTag("clinica"))
		{
			GameManager.instance.gameObject.GetComponent<ScoreManager>().Score(100, GetComponent<PhotonView>().ownerId, true);
			Module3Stage1Manager.instance.PunEndGame(true);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn

		if (stream.isWriting)
			stream.SendNext((bool)isHeld);
		else
		{
			bool lastIsHeld = (bool)stream.ReceiveNext();
			isHeld = lastIsHeld;
		}
	}
}
