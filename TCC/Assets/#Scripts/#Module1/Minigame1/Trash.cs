using UnityEngine;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(BoxCollider))]
public class Trash : Photon.MonoBehaviour
{
	public int ViewID { get { return this.photonView.viewID; } }

	public bool isHeld = false;

	public TrashType Type = TrashType.None;

	void Start()
	{
		switch (tag)
		{
			case "vidro":
				Type = TrashType.Glass;
				break;
			case "metal":
				Type = TrashType.Metal;
				break;
			case "papel":
				Type = TrashType.Paper;
				break;
			case "plastico":
				Type = TrashType.Plastic;
				break;
			default:
				break;
		}

		photonView.ObservedComponents.Add(this);
	}

	public void OnTriggerStay(Collider hit)
	{
		if (hit.GetComponent<Minigame1PlayerMechanic>())
			if (Input.GetKeyDown(KeyCode.E) && hit.GetComponent<Minigame1PlayerMechanic>().holdTrash == null)
			{
				if (photonView.ownerId != PhotonNetwork.player.ID)
					photonView.TransferOwnership(hit.GetComponent<PhotonView>().ownerId);

				hit.GetComponent<Minigame1PlayerMechanic>().holdTrash = gameObject;
				hit.GetComponent<Minigame1PlayerMechanic>().isHolding = true;
				Module1Stage1Manager.instance.effectsAS.PlayOneShot(Module1Stage1Manager.instance.ItemPickupSound);
				this.isHeld = true;
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
