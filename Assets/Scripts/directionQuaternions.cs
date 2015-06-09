using UnityEngine;
using System.Collections;

public class directionQuaternions : MonoBehaviour {

	// The distance between two frames, the z value for direction.
	public int frameDistance = 3;
	public float RotationSpeed = 1;

	//Frame input simulated using mouse input for now.
	Vector3 firstFrameCapture, secondFrameCapture;

	// Important direction module.
	Vector3 _direction;
	Quaternion _lookRotation;


	// Use this for initialization
	void Start () {

		// The inital set up incase of no input.
		firstFrameCapture = new Vector3 (0, 0, 0);
		secondFrameCapture = new Vector3 (0, 0, frameDistance);
		_direction = new Vector3 (0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
		// Capturing the frame data from the second frame.
		secondFrameCapture = Input.mousePosition;

		// Sets the distance of the frames.
		secondFrameCapture.z = frameDistance;

		_direction = (secondFrameCapture - firstFrameCapture).normalized;
		_lookRotation = Quaternion.LookRotation (_direction);
		transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		Debug.Log (transform.rotation);

	}
}





