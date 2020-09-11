using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	public float _WalkSpeed;
	public float _RotateSpeed;
	private Vector3 _moveDirection = Vector3.zero;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

		_moveDirection = new Vector3(0, 0, (Input.GetAxisRaw("Vertical") != 0 ? (Input.GetAxisRaw("Vertical") > 0 ? _WalkSpeed : -_WalkSpeed) : 0));
		//	_moveDirection = transform.TransformDirection(_moveDirection);

		transform.Rotate(0, Input.GetAxisRaw("Horizontal") * _RotateSpeed * Time.deltaTime, 0);

		transform.Translate(_moveDirection * Time.deltaTime);

	}
}
