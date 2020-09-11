using UnityEngine;

public class Module3Minigame2PlayerMechanic : Photon.MonoBehaviour
{

	//Centro
	private GameObject DialogBoxRafaela;
	private GameObject DialogBoxMiguel;
	private GameObject DialogBoxEdgar;

	//Residencia
	private GameObject DialogBoxMonica;
	private GameObject DialogBoxRicardo;
	private GameObject DialogBoxVera;
	private GameObject DialogBoxJeferson;

	//Prefeitura
	private GameObject DialogBoxCelina;
	private GameObject DialogBoxElisa;
	private GameObject DialogBoxLeandro;

	private UnityEngine.UI.Image photoImage;

	private GameObject PhotoCamera1;
	private GameObject PhotoCamera2;
	private GameObject PhotoCamera3;
	private GameObject PhotoCamera4;
	private GameObject PhotoCamera5;
	private GameObject PhotoCamera6;
	private GameObject PhotoCamera7;
	private GameObject PhotoCamera8;
	private GameObject PhotoCamera9;
	private GameObject PhotoCamera10;

	bool onQuest1;
	bool onQuest2;
	bool onQuest3;
	bool onQuest4;
	bool onQuest5;
	bool onQuest6;
	bool onQuest7;
	bool onQuest8;
	bool onQuest9;
	bool onQuest10;

	void Awake()
	{
		if (!photonView.isMine)
			Destroy(this);

		#region NPCs
		DialogBoxRafaela = Module3Stage2Manager.instance.DialogBoxRafaela;
		DialogBoxMiguel = Module3Stage2Manager.instance.DialogBoxMiguel;
		DialogBoxEdgar = Module3Stage2Manager.instance.DialogBoxEdgar;
		DialogBoxMonica = Module3Stage2Manager.instance.DialogBoxMonica;
		DialogBoxRicardo = Module3Stage2Manager.instance.DialogBoxRicardo;
		DialogBoxVera = Module3Stage2Manager.instance.DialogBoxVera;
		DialogBoxJeferson = Module3Stage2Manager.instance.DialogBoxJeferson;
		DialogBoxCelina = Module3Stage2Manager.instance.DialogBoxCelina;
		DialogBoxElisa = Module3Stage2Manager.instance.DialogBoxElisa;
		DialogBoxLeandro = Module3Stage2Manager.instance.DialogBoxLeandro;
		#endregion

		#region CameraQuests
		photoImage = Module3Stage2Manager.instance.photoImage;
		PhotoCamera1 = Module3Stage2Manager.instance.PhotoCamera1;
		PhotoCamera2 = Module3Stage2Manager.instance.PhotoCamera2;
		PhotoCamera3 = Module3Stage2Manager.instance.PhotoCamera3;
		PhotoCamera4 = Module3Stage2Manager.instance.PhotoCamera4;
		PhotoCamera5 = Module3Stage2Manager.instance.PhotoCamera5;
		PhotoCamera6 = Module3Stage2Manager.instance.PhotoCamera6;
		PhotoCamera7 = Module3Stage2Manager.instance.PhotoCamera7;
		PhotoCamera8 = Module3Stage2Manager.instance.PhotoCamera8;
		PhotoCamera9 = Module3Stage2Manager.instance.PhotoCamera9;
		PhotoCamera10 = Module3Stage2Manager.instance.PhotoCamera10;
		#endregion
	}

	void Start()
	{
		onQuest1 = false;
		onQuest2 = false;
		onQuest3 = false;
		onQuest4 = false;
		onQuest5 = false;
		onQuest6 = false;
		onQuest7 = false;
		onQuest8 = false;
		onQuest9 = false;
		onQuest10 = false;
	}

	void Update()
	{
		if (PhotoCamera1.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera1.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[0] = true;
			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera2.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera2.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[1] = true;

			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera3.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera3.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[2] = true;

			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera4.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera4.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[3] = true;

			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera5.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera5.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[4] = true;

			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera6.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera6.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[5] = true;

			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera7.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera7.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[6] = true;

			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera8.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera8.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[7] = true;

			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera9.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera9.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[8] = true;

			//Voltar Controle do jogador ===================================
		}
		if (PhotoCamera10.activeInHierarchy == true && Input.GetMouseButtonDown(0))
		{
			PhotoCamera10.SetActive(false);
			Camera.main.gameObject.SetActive(true);
			Module3Stage2Manager.instance.photos[9] = true;

			//Voltar Controle do jogador ===================================
		}
	}

	#region Trigger Camera Image
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag)
		{
			case "quest1":
				if (!onQuest1)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest2":
				if (!onQuest2)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest3":
				if (!onQuest3)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest4":
				if (!onQuest4)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest5":
				if (!onQuest5)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest6":
				if (!onQuest6)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest7":
				if (!onQuest7)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest8":
				if (!onQuest8)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest9":
				if (!onQuest9)
					break;
				photoImage.gameObject.SetActive(true);
				break;
			case "quest10":
				if (!onQuest10)
					break;
				photoImage.gameObject.SetActive(true);
				break;
		}
	}
	#endregion

	void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.E))
			switch (other.gameObject.tag)
			{
				case "NPCquest1":
					DialogBoxRafaela.SetActive(true);
					onQuest1 = true;
					break;
				case "NPCquest2":
					DialogBoxMiguel.SetActive(true);
					onQuest2 = true;
					break;
				case "NPCquest3":
					DialogBoxEdgar.SetActive(true);
					onQuest3 = true;
					break;
				case "NPCquest4":
					DialogBoxMonica.SetActive(true);
					onQuest4 = true;
					break;
				case "NPCquest5":
					DialogBoxRicardo.SetActive(true);
					onQuest5 = true;
					break;
				case "NPCquest6":
					DialogBoxVera.SetActive(true);
					onQuest6 = true;
					break;
				case "NPCquest7":
					DialogBoxJeferson.SetActive(true);
					onQuest7 = true;
					break;
				case "NPCquest8":
					DialogBoxCelina.SetActive(true);
					onQuest8 = true;
					break;
				case "NPCquest9":
					DialogBoxElisa.SetActive(true);
					onQuest9 = true;
					break;
				case "NPCquest10":
					DialogBoxLeandro.SetActive(true);
					onQuest10 = true;
					break;
				case "quest1":
					if (!onQuest1)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera1.SetActive(true);
					break;
				case "quest2":
					if (!onQuest2)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera2.SetActive(true);
					break;
				case "quest3":
					if (!onQuest3)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera3.SetActive(true);
					break;
				case "quest4":
					if (!onQuest4)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera4.SetActive(true);
					break;
				case "quest5":
					if (!onQuest5)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera5.SetActive(true);
					break;
				case "quest6":
					if (!onQuest6)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera6.SetActive(true);
					break;
				case "quest7":
					if (!onQuest7)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera7.SetActive(true);
					break;
				case "quest8":
					if (!onQuest8)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera8.SetActive(true);
					break;
				case "quest9":
					if (!onQuest9)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera9.SetActive(true);
					break;
				case "quest10":
					if (!onQuest10)
						break;
					photoImage.gameObject.SetActive(false);
					Camera.main.gameObject.SetActive(false);
					PhotoCamera10.SetActive(true);
					break;
			}

		if (other.CompareTag("BusStop"))
		{
			switch (other.transform.parent.name)
			{
				case "BusStop":
					gameObject.transform.position = Module3Stage2Manager.instance.CenterSpawnPoint[0].position;
					break;
				case "CenterBusStop":
					gameObject.transform.position = Module3Stage2Manager.instance.TownHallSpawnPoint[0].position;
					break;
				case "TownHallBusStop":
					gameObject.transform.position = Module3Stage2Manager.instance.NeighborhoodSpawnPoint[0].position;
					break;
			}
		}
	}

	public void OnTriggerExit(Collider other)
	{
		switch (other.gameObject.tag)
		{
			case "NPCquest1":
				DialogBoxRafaela.SetActive(false);
				break;
			case "NPCquest2":
				DialogBoxMiguel.SetActive(false);
				break;
			case "NPCquest3":
				DialogBoxEdgar.SetActive(false);
				break;
			case "NPCquest4":
				DialogBoxMonica.SetActive(false);
				break;
			case "NPCquest5":
				DialogBoxRicardo.SetActive(false);
				break;
			case "NPCquest6":
				DialogBoxVera.SetActive(false);
				break;
			case "NPCquest7":
				DialogBoxJeferson.SetActive(false);
				break;
			case "NPCquest8":
				DialogBoxCelina.SetActive(false);
				break;
			case "NPCquest9":
				DialogBoxElisa.SetActive(false);
				break;
			case "NPCquest10":
				DialogBoxLeandro.SetActive(false);
				break;
			case "quest1":
				if (!onQuest1)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest2":
				if (!onQuest2)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest3":
				if (!onQuest3)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest4":
				if (!onQuest4)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest5":
				if (!onQuest5)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest6":
				if (!onQuest6)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest7":
				if (!onQuest7)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest8":
				if (!onQuest8)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest9":
				if (!onQuest9)
					break;
				photoImage.gameObject.SetActive(false);
				break;
			case "quest10":
				if (!onQuest10)
					break;
				photoImage.gameObject.SetActive(false);
				break;
		}
	}
}
