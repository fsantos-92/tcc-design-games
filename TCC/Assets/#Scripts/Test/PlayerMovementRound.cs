using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRound : MonoBehaviour
{

	Transform _mainCamera;
	Vector3 _mainCameraForward;
	Vector3 _move;
	Vector3 _groundNormal;

	float _walkSpeed = 5;
	float _turnAmount;
	float _forwardAmount;

	public float _stationaryTurnSpeed = 180;
	public float _movingTurnSpeed = 360;

	void Start ()
	{
		_mainCamera = Camera.main.transform;
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		_mainCameraForward = Vector3.Scale (_mainCamera.forward, new Vector3 (1, 0, 1)).normalized;
		_move = v * _mainCameraForward + h * _mainCamera.right;

		Move (_move);
	}

	public void Move (Vector3 move)
	{

		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (move.magnitude > 1f)
			move.Normalize ();
		move = transform.InverseTransformDirection (move);
		move = Vector3.ProjectOnPlane (move, _groundNormal);
		_turnAmount = Mathf.Atan2 (move.x, move.z);
		_forwardAmount = move.z;

		ApplyExtraTurnRotation ();

		if (_move.magnitude > 0)
			transform.Translate (Vector3.forward * Time.deltaTime * _walkSpeed);
	}

	void ApplyExtraTurnRotation ()
	{
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp (_stationaryTurnSpeed, _movingTurnSpeed, _forwardAmount);
		transform.Rotate (0, _turnAmount * turnSpeed * Time.deltaTime, 0);
	}
}
