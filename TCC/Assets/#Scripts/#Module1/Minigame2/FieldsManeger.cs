using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class FieldsManeger : Photon.MonoBehaviour
{
	public struct NewFields
	{
		public FieldStatus currentFieldStatus;
		public GameObject field;
	}

	public int ViewID { get { return this.photonView.viewID; } }

	//[HideInInspector]
	public NewFields[] fields;

	// Use this for initialization
	void Start()
	{
		GetComponent<PhotonView>().ObservedComponents[0] = this;
		GetComponent<PhotonView>().ownershipTransfer = OwnershipOption.Takeover;
		GetComponent<PhotonView>().synchronization = ViewSynchronization.UnreliableOnChange;

		fields = new NewFields[transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
		{
			fields[i].field = transform.GetChild(i).gameObject;
			fields[i].currentFieldStatus = (FieldStatus)0;
		}
	}

	void Update()
	{
		for (int i = 0; i < fields.Length; i++)
			for (int l = 0; l < fields[i].field.transform.childCount; l++)
				if (fields[i].currentFieldStatus == FieldStatus.wet)
				{
					fields[i].field.transform.GetChild(fields[i].field.transform.childCount - 1).gameObject.SetActive(true);
					fields[i].field.transform.GetChild(fields[i].field.transform.childCount - 2).gameObject.SetActive(true);
				}
				else if (l == (int)fields[i].currentFieldStatus)
					fields[i].field.transform.GetChild(l).gameObject.SetActive(true);
				else
					fields[i].field.transform.GetChild(l).gameObject.SetActive(false);
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// read the description in SecondsBeforeRespawn

		for (int i = 0; i < fields.Length; i++)
		{
			if (stream.isWriting)
			{
				stream.SendNext((int)fields[i].currentFieldStatus);
			}
			else
			{
				int lastFieldStatus = (int)stream.ReceiveNext();
				fields[i].currentFieldStatus = (FieldStatus)lastFieldStatus;
			}
		}
	}

	[PunRPC]
	public void EnableParticle(string particle, Vector3 position)
	{
		switch (particle)
		{
			case "Water":
				Module1Stage2Manager.instance.Water.transform.position = position;
				Module1Stage2Manager.instance.Water.enabled = true;
				break;
			case "Seed":
				Module1Stage2Manager.instance.Seed.transform.position = position;
				Module1Stage2Manager.instance.Seed.enabled = true;
				break;
			case "Dirty":
				Module1Stage2Manager.instance.Dirty.transform.position = position;
				Module1Stage2Manager.instance.Dirty.enabled = true;
				break;
			default:
				break;
		}
	}
}
