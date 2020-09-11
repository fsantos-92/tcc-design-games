using UnityEngine;
using System.Collections;

public class NPCBehaviour : FSM
{
	[SerializeField] string[] dialogues;
	public int dialoguesIndex = 0;

	//public string dialogText = null;
	Quaternion originalRotation;

	// Use this for initialization
	void Start ()
	{
		base.Start ();
		originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		base.Update ();
	}

	public void ShowDialogue (Transform lookAtPlayer)
	{
		if (dialoguesIndex > dialogues.Length - 1)
		{
			DialogManeger.instance.CloseDialogBox();
			dialoguesIndex = -1;
			transform.rotation = originalRotation;
			return;
		}

		DialogManeger.instance.PrintOnDialogBox(name + ": " + dialogues[dialoguesIndex]);
		transform.LookAt(lookAtPlayer);
	}
}
