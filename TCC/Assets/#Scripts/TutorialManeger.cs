using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManeger : MonoBehaviour
{

	public Image panel;

	public Image tutorialImage;

	public Text tutorialTimeText;

	public float tutorialTime = 15;
	float tutorialTimer = 0;

	public AudioSource audio;
	public AudioClip tutorialMusic;

	float gameTime;

	// Use this for initialization
	void Start()
	{
		audio.loop = true;
		audio.clip = tutorialMusic;
		audio.Play();
		gameTime = tutorialTime;
	}

	// Update is called once per frame
	void Update()
	{
		gameTime = gameTime + (-1) * Time.deltaTime;

		int minutes = (int)(gameTime / 60);
		int seconds = (int)(gameTime % 60);
		//int miliseconds = (int)(gameTime * 100) % 100;
		tutorialTimeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

		if (tutorialTimer >= tutorialTime)
		{
			panel.gameObject.SetActive(false);

			if (gameObject.GetComponent<Module1Stage1Manager>())
				gameObject.GetComponent<Module1Stage1Manager>().enabled = true;

			if (gameObject.GetComponent<Module1Stage2Manager>())
				gameObject.GetComponent<Module1Stage2Manager>().enabled = true;

			if (gameObject.GetComponent<Module2Stage1Manager>())
				gameObject.GetComponent<Module2Stage1Manager>().enabled = true;

			if (gameObject.GetComponent<Module2Stage2Manager>())
				gameObject.GetComponent<Module2Stage2Manager>().enabled = true;

			if (gameObject.GetComponent<Module3Stage1Manager>())
				gameObject.GetComponent<Module3Stage1Manager>().enabled = true;

			if (gameObject.GetComponent<Module3Stage2Manager>())
				gameObject.GetComponent<Module3Stage2Manager>().enabled = true;

		}
		else
			tutorialTimer += Time.deltaTime;

	}
}
