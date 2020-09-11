using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Fence : MonoBehaviour
{
	//void OnCollisionEnter(Collision hit)
	void OnTriggerEnter(Collider hit)
	{
		return;

		Debug.Log("Colided on " + gameObject.name + " with " + hit.gameObject.name);
		if (hit.gameObject.GetComponent<Trash>())
		{
			Debug.Log("trash type: " + hit.gameObject.GetComponent<Trash>().Type);

			switch (hit.gameObject.GetComponent<Trash>().Type)
			{
				case TrashType.None:
					break;
				case TrashType.Glass:
					if (Module1Stage1Manager.instance.currentTrashType != TrashType.Glass)
						GameManager.instance.photonView.RPC("Score", PhotonTargets.All, -5, PhotonNetwork.player.ID, false);
					break;
				case TrashType.Metal:
					if (Module1Stage1Manager.instance.currentTrashType != TrashType.Glass)
						GameManager.instance.photonView.RPC("Score", PhotonTargets.All, -5, PhotonNetwork.player.ID, false);
					break;
				case TrashType.Paper:
					if (Module1Stage1Manager.instance.currentTrashType != TrashType.Glass)
						GameManager.instance.photonView.RPC("Score", PhotonTargets.All, -5, PhotonNetwork.player.ID, false);
					break;
				case TrashType.Plastic:
					if (Module1Stage1Manager.instance.currentTrashType != TrashType.Glass)
						GameManager.instance.photonView.RPC("Score", PhotonTargets.All, -5, PhotonNetwork.player.ID, false);
					break;
				default:
					break;
			}
		}
	}
}
