using UnityEngine;

public class Module2Minigame1PlayerMechanic : Photon.MonoBehaviour
{
	private GameObject DialogBoxJorge;
	private GameObject DialogBoxEdite;
	private GameObject DialogBoxFatima;
	private GameObject DialogBoxNelson;
	private GameObject DialogBoxClaudia;
	private GameObject DialogBoxRosa;
	private GameObject DialogBoxAlberto;
	private GameObject DialogBoxCarlos;

	void Awake()
	{
		if (!photonView.isMine)
			Destroy(this);

		DialogBoxJorge = Module2Stage1Manager.instance.DialogBoxJorge;
		DialogBoxEdite = Module2Stage1Manager.instance.DialogBoxEdite;
		DialogBoxFatima = Module2Stage1Manager.instance.DialogBoxFatima;
		DialogBoxNelson = Module2Stage1Manager.instance.DialogBoxNelson;
		DialogBoxClaudia = Module2Stage1Manager.instance.DialogBoxClaudia;
		DialogBoxRosa = Module2Stage1Manager.instance.DialogBoxRosa;
		DialogBoxAlberto = Module2Stage1Manager.instance.DialogBoxAlberto;
		DialogBoxCarlos = Module2Stage1Manager.instance.DialogBoxCarlos;

	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("WaterTap") && Input.GetKeyDown(KeyCode.E))
			for (int i = 0; i < Module2Stage1Manager.instance._waterTapsManager._waterTaps.Length; i++)
				if (Module2Stage1Manager.instance._waterTapsManager._waterTaps[i].waterTap == other.gameObject && Module2Stage1Manager.instance._waterTapsManager._waterTaps[i].isOpen == true)
				{
					StartCoroutine(GetComponent<PlayerBehaviour>().WaitThenWalk(1.5f));
					GetComponent<PlayerBehaviour>().Animator.SetTrigger("CloseWaterTap");
					//Module2Stage1Manager.instance.effectsAS.PlayOneShot(Module2Stage1Manager.instance.WaterTapClosingSFX);
					GameManager.instance.gameObject.GetComponent<ScoreManager>().Score(1, GetComponent<PhotonView>().ownerId, true);
					Module2Stage1Manager.instance._waterTapsManager.photonView.RPC("CloseWaterTap", PhotonTargets.All, i);
				}

		if (Input.GetKeyDown(KeyCode.E))
			switch (other.tag)
			{
				case "NPCquest1":
					DialogBoxJorge.SetActive(true);
					break;
				case "NPCquest2":
					DialogBoxEdite.SetActive(true);
					break;
				case "NPCquest3":
					DialogBoxFatima.SetActive(true);
					break;
				case "NPCquest4":
					DialogBoxNelson.SetActive(true);
					break;
				case "NPCquest5":
					DialogBoxClaudia.SetActive(true);
					break;
				case "NPCquest6":
					DialogBoxRosa.SetActive(true);
					break;
				case "NPCquest7":
					DialogBoxAlberto.SetActive(true);
					break;
				case "NPCquest8":
					DialogBoxCarlos.SetActive(true);
					break;
				default:
					break;
			}
	}

	public void OnTriggerExit(Collider hit)
	{
		switch (hit.tag)
		{
			case "NPCquest1":
				DialogBoxJorge.SetActive(false);
				break;
			case "NPCquest2":
				DialogBoxEdite.SetActive(false);
				break;
			case "NPCquest3":
				DialogBoxFatima.SetActive(false);
				break;
			case "NPCquest4":
				DialogBoxNelson.SetActive(false);
				break;
			case "NPCquest5":
				DialogBoxClaudia.SetActive(false);
				break;
			case "NPCquest6":
				DialogBoxRosa.SetActive(false);
				break;
			case "NPCquest7":
				DialogBoxAlberto.SetActive(false);
				break;
			case "NPCquest8":
				DialogBoxCarlos.SetActive(false);
				break;
			default:
				break;
		}
	}
}
