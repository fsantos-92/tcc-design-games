using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module3Minigame1PlayerMechanic : Photon.MonoBehaviour
{
	private Transform muzzle;

	public bool isHolding = false;

	private Wheelchair wheelchair { get; set; }

	void Awake()
	{
		if (!photonView.isMine)
			Destroy(this);
	}

	// Use this for initialization
	void Start()
	{
		photonView.ObservedComponents.Add(this);

		muzzle = transform.FindChild("Muzzle");
	}

	void Update()
	{
		if (isHolding)
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				wheelchair.isHeld = false;
				isHolding = false;
				wheelchair = null;

				if (Module3Stage1Manager.instance.HolesManager.GetComponent<PhotonView>().ownerId != PhotonNetwork.player.ID)
					Module3Stage1Manager.instance.HolesManager.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.masterClient.ID);
			}
			else
			{
				wheelchair.transform.position = new Vector3(muzzle.position.x, wheelchair.transform.position.y, muzzle.position.z);
				wheelchair.transform.rotation = Quaternion.LookRotation(transform.forward); ;
					//new Quaternion(0,-transform.rotation.y,0,0);
			}
		}
	}

	public void OnCollisionStay(Collision hit)
	{
		if ((hit.gameObject.tag == "amarelo" || hit.gameObject.tag == "vermelho") && Input.GetKeyDown(KeyCode.E) && !isHolding)
		{
			foreach (GameObject item in Module3Stage1Manager.instance.HolesManager.Holes)
			{
				if (Module3Stage1Manager.instance.HolesManager.GetComponent<PhotonView>().ownerId != PhotonNetwork.player.ID)
					Module3Stage1Manager.instance.HolesManager.GetComponent<PhotonView>().TransferOwnership(GetComponent<PhotonView>().ownerId);

				GameManager.instance.gameObject.GetComponent<ScoreManager>().Score(+10, GetComponent<PhotonView>().ownerId, true);
				hit.gameObject.SetActive(false);

				if (Module3Stage1Manager.instance.HolesManager.GetComponent<PhotonView>().ownerId != PhotonNetwork.player.ID)
					Module3Stage1Manager.instance.HolesManager.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.masterClient.ID);
			}
		}
	}

	public void OnTriggerStay(Collider hit)
	{
		if (Input.GetKeyDown(KeyCode.E) && hit.gameObject.CompareTag("Wheelchair") && !isHolding && !hit.gameObject.GetComponent<Wheelchair>().isHeld)
		{
			if (Module3Stage1Manager.instance.WheelChair.GetComponent<PhotonView>().ownerId != PhotonNetwork.player.ID)
				Module3Stage1Manager.instance.WheelChair.GetComponent<PhotonView>().TransferOwnership(GetComponent<PhotonView>().ownerId);

			wheelchair = hit.gameObject.GetComponent<Wheelchair>();
			wheelchair.isHeld = true;
			isHolding = true;
		}
	}
}
