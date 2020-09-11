using UnityEngine;
using UnityEngine.UI;

public class DialogManeger : MonoBehaviour {

	public static DialogManeger instance;

	public Transform dialogueBox;
	public Text textBody;

	// Use this for initialization
	void Start () {

		if (instance == null) instance = this;

		//dialogueBox = GameObject.Find("DialoguePanel").transform;
		//dialogueBox.Find("DialogueText").GetComponent<Text>();
	}
	
	public void PrintOnDialogBox (string text) {
		dialogueBox.gameObject.SetActive(true);
		textBody.text = text;

	}

	public void CloseDialogBox()
	{
		dialogueBox.gameObject.SetActive(false);
	}


	public void CloseDialogBoxCallback()
	{
		CloseDialogBox();
	}
}
