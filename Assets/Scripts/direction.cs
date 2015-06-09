using UnityEngine;
using System.Collections;

public class direction : MonoBehaviour {
	
	// The public variables.
	public float RotationSpeed = 1;
	public GameObject mousePlane;
	public Camera mainCam;

	//Frame input simulated using mouse input for now.
	Vector3 firstFrameCapture, secondFrameCapture;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		// Generate a ray from the cursor position
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		// If the ray is parallel to the plane, Raycast will return false.
		if (Physics.Raycast(ray,out hitInfo)) {

			transform.LookAt(hitInfo.point);

		}
	}
}





