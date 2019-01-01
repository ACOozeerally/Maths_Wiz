using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float cameraAhead;

	private Vector3 targetPosition;

	public float smoothing;

	private Vector3 offset;

	public bool follow;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - target.transform.position;
		follow = true;
	
		
	}
	
	// Update is called once per frame
	void Update () {
		if(follow){
			targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

		}
	}

	void LateUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = target.transform.position + offset;
	}
}
