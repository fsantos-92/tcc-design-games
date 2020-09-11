using UnityEngine;
using System.Collections;

public class SchoolManeger : StageManagerBase
{
	public static SchoolManeger instance = null;
	
	[SerializeField]
	Vector3 cameraAdjust;

	//public UnityEngine.UI.Image objectiveCompass;

	//public Transform objectivePosition;

	//public UnityEngine.UI.Image dialogueBox;
	//public UnityEngine.UI.Text dialogueText;

	// Use this for initialization
	void Start ()
	{
		#region SingletonAwake

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		#endregion

		//base.Start ();

		//playerPrefab.GetComponent<PlayerBehaviour> ().enabled = true;

		//objectivePosition = GameObject.Find ("Minigame1Local").transform;
	}

	void LateUpdate ()
	{
		//Camera Control
		//Camera.main.transform.position = Vector3.Lerp(transform.position, playerPrefab.transform.position + cameraAdjust, Time.deltaTime * 100f);

		//CompassControl ();
	}

	void CompassControl ()
	{
		//float angleOfCompass = Quaternion.Angle (playerPrefab.transform.rotation, objectivePosition.rotation);
		//objectiveCompass.rectTransform.rotation = Quaternion.Euler (0, 0, angleOfCompass);
	}
}
