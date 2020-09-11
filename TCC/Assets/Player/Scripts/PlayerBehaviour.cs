using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonTransformView))]
[RequireComponent(typeof(PhotonAnimatorView))]
public class PlayerBehaviour : Photon.MonoBehaviour
{
	public GameObject[] tools;

	public Animator Animator { get; private set; }
	protected Rigidbody _rigidBody;

	ParticleSystem _dustTrail;
	public float _dustParticleEmission = 10.0f;

	#region Movement

	public float _WalkSpeed;
	public float _RotateSpeed;
	private Vector3 _moveDirection = Vector3.zero;
	public bool _CanMove = true;

	//public Renderer PlayerRenderer;
	//public Texture[] Textures;

	#endregion

	// Use this for initialization
	void Start()
	{
		if (!photonView.isMine)
			Destroy(this);

		Animator = GetComponent<Animator>();
		_rigidBody = GetComponent<Rigidbody>();

		_dustTrail = transform.FindChild("DustParticles").GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update()
	{
		MovementControl();
	}

	void MovementControl()
	{
		if (!_CanMove)
			return;

		//if (Camera.main.GetComponent<WowCamera>())
		//transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

		_moveDirection = new Vector3(0, 0, (Input.GetAxisRaw("Vertical") > 0 ? _WalkSpeed : 0));

		transform.Rotate(0, Input.GetAxisRaw("Horizontal") * _RotateSpeed * Time.deltaTime, 0);

		transform.Translate(_moveDirection * Time.deltaTime);

		var emission = _dustTrail.emission;

		if (_moveDirection.z > .1)
			emission.rateOverTime = _dustParticleEmission;
		else
			emission.rateOverTime = 0;

		Animator.SetFloat("Speed", _moveDirection.z);
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.CompareTag("SchoolExit"))
		{
			if (PhotonNetwork.isMasterClient)
				UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
		}
	}

	public IEnumerator WaitThenWalk(float time)
	{
		_CanMove = false;
		yield return new WaitForSeconds(time);
		_CanMove = true;
	}
}