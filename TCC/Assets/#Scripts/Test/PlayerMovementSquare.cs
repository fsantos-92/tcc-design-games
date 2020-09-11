using UnityEngine;

public class PlayerMovementSquare : MonoBehaviour
{
	public float _walkSpeed = 5;

	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if (h > 0)
			transform.rotation = Quaternion.Euler(0, 90 - Camera.main.transform.rotation.y - 90, 0);
		else if (h < 0)
			transform.rotation = Quaternion.Euler(0, -90 - Camera.main.transform.rotation.y - 90, 0);

		if (v > 0)
			transform.rotation = Quaternion.Euler(0, 0 - Camera.main.transform.rotation.y - 90, 0);
		else if (v < 0)
			transform.rotation = Quaternion.Euler(0, 180 - Camera.main.transform.rotation.y - 90, 0);

		if (v != 0 || h != 0)
			transform.Translate (Vector3.forward * Time.deltaTime * _walkSpeed);
	}
}
