using UnityEngine;
using System.Collections;

public class Minigame1PlayerMechanic : Photon.MonoBehaviour
{
	Transform Muzzle;

	public bool isHolding = false;
	public GameObject holdTrash = null;

	// Use this for initialization
	void Start()
	{
		if (!photonView.isMine)
			Destroy(this);

		Muzzle = transform.FindChild("Muzzle");

		GetComponent<PlayerBehaviour>()._WalkSpeed /= 2;
	}

	// Update is called once per frame
	void Update()
	{

		if (holdTrash != null)
		{
			holdTrash.transform.position = Muzzle.position;

			if (Input.GetKeyDown(KeyCode.G))
			{
				holdTrash.GetComponent<Trash>().isHeld = false;
				holdTrash = null;
				Module1Stage1Manager.instance.effectsAS.PlayOneShot(Module1Stage1Manager.instance.ItemDropSound);
			}
		}
	}
}