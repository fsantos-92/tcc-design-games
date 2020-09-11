using UnityEngine;
public class PathFindingWayPoints : MonoBehaviour {
	public  float       speed    = 5;
	public  float       rotSpeed = 10;
	public  Transform[] waypoints;
	private int         currentWayPoint;
	private Rigidbody rb;
	
	public void Start() {
		currentWayPoint = 0;
		rb = GetComponent<Rigidbody> ();
	}
	
	public void FixedUpdate() {
		Vector3 dir = waypoints[currentWayPoint].position - transform.position; //Onde quero chegar - Onde estou
		
		// Look at the target
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
		
		// Keep the rotation only around vertical axis (Y)
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		
		// Check if the NPC has reached currentwaypoint
		if (dir.sqrMagnitude <= 1) {
			// Go to the next one unless ...
			currentWayPoint++;
			
			// ... the NPC has reached the last waypoint. Return to the first wp in this case
			if (currentWayPoint >= waypoints.Length)
				currentWayPoint = 0;
		} else
			rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
	}
}