using UnityEngine;
using System.Collections;

public class CameraIso : MonoBehaviour {
    /// <summary>
    /// Coloca aqui o player
    /// </summary>
    public GameObject target;
    /// <summary>
    /// Ajuste de Camera
    /// </summary>
    [SerializeField]
    Vector3 ajuste;
	// Use this for initialization
	void Start () {
	    
	}


	void LateUpdate () {
		transform.position = Vector3.Lerp(transform.position, target.transform.position + ajuste, Time.deltaTime * 100f);
        transform.LookAt(target.transform.position);
	}
}
