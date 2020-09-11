using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform Target { get; set; }
	public float _OffsetZ = 10;
	public float _OffsetX = 10;
	public float _predefinedFOV = 10;
	public bool _isFollowing = false;

	private float _defaultFOV;

	void Start()
	{
		_defaultFOV = gameObject.GetComponent<Camera>().fieldOfView;
	}

	// Update is called once per frame
	void Update () {

		if (Target == null)
			return;

		if (_isFollowing)
			gameObject.transform.position = new Vector3(Target.position.x + _OffsetX, transform.position.y,Target.position.z + _OffsetZ);

		if (_isFollowing)
			gameObject.GetComponent<Camera>().fieldOfView = _predefinedFOV;
		else
			gameObject.GetComponent<Camera>().fieldOfView = _defaultFOV;
	}
}
