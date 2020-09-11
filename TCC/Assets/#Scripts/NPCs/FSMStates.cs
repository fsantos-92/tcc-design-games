using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(Rigidbody))]
public class FSM : MonoBehaviour
{
	#region FSM
	public enum FSMStates
	{
		Idle,
		Walking,
		Watering,
		Seeding,
		Digging,
		Fertilizing,
	}

	public FSMStates currentState = FSMStates.Idle;
	#endregion

	protected Animator animator;
	protected Rigidbody rigidBody;

	#region Movement
	protected float xSpd = 0;
	protected float ySpd = 0;

	public float rotSpeed = 10;
	public float moveSpeed = 100;
	#endregion

	// Use this for initialization
	public void Start ()
	{
		animator = GetComponent <Animator> ();
		rigidBody = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	public void Update ()
	{
		AnimatorController ();
		FSMControl ();
	}

	#region FSM

	void AnimatorController ()
	{
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Adubar")) {
			currentState = FSMStates.Fertilizing;

		} else if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Semear")) {
			currentState = FSMStates.Seeding;
		
		} else if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Cavar")) {
			currentState = FSMStates.Digging;
		
		} else if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Regar")) {
			currentState = FSMStates.Watering;
		
		} else if (xSpd != 0 || ySpd != 0)
			currentState = FSMStates.Walking;
		else
			currentState = FSMStates.Idle;
	}

	void FSMControl ()
	{
		#region Idle
		#endregion

		#region Walking
		if (currentState == FSMStates.Walking) {
			rigidBody.AddRelativeForce (Vector3.forward * xSpd);
			rigidBody.AddRelativeTorque (Vector3.up * ySpd);
		}
		animator.SetFloat ("Speed", xSpd);
		#endregion
	}

	#endregion
}
