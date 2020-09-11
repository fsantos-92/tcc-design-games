using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectConnect : MonoBehaviour {

	public Text CurrentIpAdressText;
	public InputField GivenIpAdress;

	void OnEnable()
	{
		CurrentIpAdressText.text = string.Format("{0}", GameManager.instance.ipAdress);
	}

	public void OnConnect()
	{
		PhotonNetwork.PhotonServerSettings.ServerAddress = GivenIpAdress.text;
		GameManager.instance.Connect();
	}
}
