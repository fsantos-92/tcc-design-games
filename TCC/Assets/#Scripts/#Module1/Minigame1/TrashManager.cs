using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PhotonView))]
public class TrashManager : Photon.MonoBehaviour
{
	public int ViewID { get { return this.photonView.viewID; } }

	public GameObject GarbageAreas;
	private SphereCollider[] areas;

	public int GarbageAmmount;

	public Trash[] GarbagesPrefabs;
	public List<Trash> IngameGarbages = new List<Trash>();

	public float YPositionVariant = 0.5f;

	// Use this for initialization
	void Start()
	{
		GetComponent<PhotonView>().ObservedComponents[0] = this;
		GetComponent<PhotonView>().ownershipTransfer = OwnershipOption.Takeover;
		GetComponent<PhotonView>().synchronization = ViewSynchronization.UnreliableOnChange;

		areas = GarbageAreas.GetComponentsInChildren<SphereCollider>();
	}

	// Update is called once per frame
	void Update()
	{
		if (PhotonNetwork.isMasterClient)
			while (IngameGarbages.Count < GarbageAmmount)
				SpawnGarbage();
	}

	void SpawnGarbage()
	{
		Vector3 pos = Random.insideUnitSphere * areas[Random.Range(0, areas.Length - 1)].radius;

		GameObject garbage = PhotonNetwork.Instantiate(GarbagesPrefabs[Random.Range(0, GarbagesPrefabs.Length)].name, new Vector3(GarbageAreas.transform.position.x + pos.x, Random.Range(-YPositionVariant, YPositionVariant), GarbageAreas.transform.position.z + pos.z), Random.rotation, 0);
		IngameGarbages.Add(garbage.GetComponent<Trash>());
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
		}
		else
		{
		}
	}

	[PunRPC]
	public void DeleteTrash(int trashIndex)
	{
		IngameGarbages.RemoveAt(trashIndex);
	}
}
