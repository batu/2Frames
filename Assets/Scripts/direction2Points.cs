using UnityEngine;
using System.Collections;

public class direction2Points : MonoBehaviour {
	
	// The distance between two frames, the z value for direction.
	public int frameDistance = 3;
	public float RotationSpeed = 1;

	public GameObject firstPlane, secindPlane;
	public Camera mainCam;
	
	//Frame input simulated using mouse input for now.
	Vector3 firstFrameCapture, secondFrameCapture;
	
	// Important direction module.
	Vector3 _direction;
	Quaternion _lookRotation;
	
	
	// Use this for initialization
	void Start () {
		
		// The inital set up incase of no input.
		firstFrameCapture = new Vector3 (-0.34f, 0.11f, 5.36f);
		secondFrameCapture = new Vector3 (0, 0, frameDistance);
		_direction = new Vector3 (0, 0, 0);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKey (KeyCode.UpArrow)) {
			firstFrameCapture.y = firstFrameCapture.y + 1;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			firstFrameCapture.y = firstFrameCapture.y - 1;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			firstFrameCapture.x = firstFrameCapture.x - 1;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			firstFrameCapture.x = firstFrameCapture.x + 1;
		}


		RaycastHit hit1Info, hit2Info;

		Ray ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);

		
		// If the ray is parallel to the plane, Raycast will return false.
		if (Physics.Raycast(ray2, out hit2Info)) {
			secondFrameCapture = hit2Info.point;
		}



		_direction = (secondFrameCapture - firstFrameCapture).normalized;
		_lookRotation = Quaternion.LookRotation (_direction);
		transform.rotation = _lookRotation;

		transform.position = new Vector3 ((firstFrameCapture.x + secondFrameCapture.x) / 2,
		                                   (firstFrameCapture.y + secondFrameCapture.y) / 2,
		                                  transform.position.z);
	}
}





