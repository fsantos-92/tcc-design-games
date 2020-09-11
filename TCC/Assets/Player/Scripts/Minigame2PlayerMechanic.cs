using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Enum = System.Enum;

public class Minigame2PlayerMechanic : Photon.MonoBehaviour
{
	public GameObject[] tools;

	Animator _aniamtor;

	public bool haveTool = false;
	public Tools tool = Tools.None;

	bool exited = true;

	int _currentFieldInteracting;

	private Vector3 particleToPos = Vector3.zero;

	void Start()
	{
		if (!photonView.isMine)
			Destroy(this);

		photonView.ObservedComponents.Add(this);

		//tools[0] = Module1Stage2Manager.instance.shovel;
		//tools[1] = Module1Stage2Manager.instance.waterCan;
		//tools[2] = Module1Stage2Manager.instance.seed;
		//tools[3] = Module1Stage2Manager.instance.fert;

		tools = new GameObject[GetComponent<PlayerBehaviour>().tools.Length];

		for (int i = 0; i < tools.Length; i++)
		{
			tools[i] = GetComponent<PlayerBehaviour>().tools[i];
			tools[i].gameObject.SetActive(false);
		}

		_aniamtor = GetComponent<Animator>();

		//GetComponent<PlayerBehaviour>()._WalkSpeed /= 2;

	}

	// Update is called once per frame
	void Update()
	{
		foreach (PickupItem item in PickupItem.DisabledPickupItems)
		{
			if (item.PickupIsMine && item.SecondsBeforeRespawn <= 0)
			{
				if (Input.GetKey(KeyCode.G) && haveTool)
				{
					SetTool(Tools.None);
					item.Drop();
				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (!haveTool && other.GetComponent<Tool>())
		{
			foreach (string toolName in Enum.GetNames(typeof(Tools)))
			{
				if (toolName == other.GetComponent<Tool>().tool.ToString())
				{
					other.GetComponent<PickupItem>().Pickup();

					SetTool(other.GetComponent<Tool>().tool);
				}
			}
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Field")
		{
			for (int i = 0; i < Module1Stage2Manager.instance.fieldManeger.fields.Length; i++)
			{
				if (Module1Stage2Manager.instance.fieldManeger.fields[i].field == other.gameObject)
				{
					if (haveTool && Input.GetKey(KeyCode.E) && exited)
					{

						exited = false;

						if (other.gameObject.transform.parent.GetComponent<PhotonView>().ownerId != PhotonNetwork.player.ID)
							other.gameObject.transform.parent.GetComponent<PhotonView>().TransferOwnership(GetComponent<PhotonView>().ownerId);

						FieldStatus currentFieldStatus = Module1Stage2Manager.instance.fieldManeger.fields[i].currentFieldStatus;

						if (((currentFieldStatus == FieldStatus.dirty) && (tool == Tools.Shovel)) ||
							(currentFieldStatus == FieldStatus.dug) && (tool == Tools.Fertilizer) ||
							(currentFieldStatus == FieldStatus.fertilized) && (tool == Tools.Seeds) ||
							(currentFieldStatus == FieldStatus.sown) && (tool == Tools.WaterCan))
						{
							_aniamtor.SetTrigger("UseTool");
							GetComponent<PlayerBehaviour>()._CanMove = false;
							_currentFieldInteracting = i;
							particleToPos = other.transform.position;
							//transform.LookAt(other.transform.position,Vector3.up);
							//transform.rotation = Quaternion.Euler(0,transform.rotation.y,0);
							//transform.rotation = Quaternion.LookRotation(other.transform.position);
						}
						else
							GameManager.instance.gameObject.GetComponent<ScoreManager>().Score(-10, GetComponent<PhotonView>().ownerId, false);

						if (other.gameObject.transform.parent.GetComponent<PhotonView>().ownerId != PhotonNetwork.player.ID)
							other.gameObject.transform.parent.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.masterClient.ID);
					}
				}
			}
		}
	}

	void SetTool(Tools toolToSet)
	{
		tool = toolToSet;
		_aniamtor.SetInteger("ToolNumber", (int)toolToSet);

		if (toolToSet <= 0)
		{
			haveTool = false;

			for (int i = 0; i < tools.Length; i++)
				tools[i].gameObject.SetActive(false);
		}
		else
		{
			haveTool = true;

			for (int i = 0; i < tools.Length; i++)
			{
				if (tools[i].tag == tool.ToString())
					tools[i].gameObject.SetActive(true);
			}
		}
	}
	public void UseTool()
	{
		switch (tool)
		{
			case Tools.WaterCan:
				Module1Stage2Manager.instance.fieldManeger.photonView.RPC("EnableParticle", PhotonTargets.All, "Water", particleToPos + Vector3.up * 1);
				break;
			case Tools.Seeds:
				Module1Stage2Manager.instance.fieldManeger.photonView.RPC("EnableParticle", PhotonTargets.All, "Seed", particleToPos + Vector3.up * 1);
				break;
			case Tools.Shovel:
				Module1Stage2Manager.instance.fieldManeger.photonView.RPC("EnableParticle", PhotonTargets.All, "Dirty", particleToPos + Vector3.up * 1);
				break;
			case Tools.Fertilizer:
				Module1Stage2Manager.instance.fieldManeger.photonView.RPC("EnableParticle", PhotonTargets.All, "Dirty", particleToPos + Vector3.up * 1);
				break;
		}

		FieldStatus newFieldStatus = (Module1Stage2Manager.instance.fieldManeger.fields[_currentFieldInteracting].currentFieldStatus + 1);
		Module1Stage2Manager.instance.fieldManeger.fields[_currentFieldInteracting].currentFieldStatus = newFieldStatus;
		GameManager.instance.gameObject.GetComponent<ScoreManager>().Score(10, GetComponent<PhotonView>().ownerId, true);
	}

	public void EndUsingTool()
	{
		GetComponent<PlayerBehaviour>()._CanMove = true;
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Field")
		{
			for (int i = 0; i < Module1Stage2Manager.instance.fieldManeger.fields.Length; i++)
			{
				if (Module1Stage2Manager.instance.fieldManeger.fields[i].field == other.gameObject && !exited)
				{
					exited = true;
				}
			}
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext((int)tool);
			stream.SendNext((bool)haveTool);
		}
		else
		{
			int lastTool = (int)stream.ReceiveNext();
			tool = (Tools)lastTool;
			bool lastHaveTool = (bool)stream.ReceiveNext();
			haveTool = lastHaveTool;
		}
	}
}