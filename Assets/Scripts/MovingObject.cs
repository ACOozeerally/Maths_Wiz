using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

	public GameObject movingObj;

	public Transform endPoint;
	public Transform startPoint;

	public float moveSpeed;

	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {
		currentTarget = endPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		movingObj.transform.position = Vector3.MoveTowards (movingObj.transform.position, currentTarget, moveSpeed * Time.deltaTime);

		if (movingObj.transform.position == endPoint.position) 
		{
			currentTarget = startPoint.position;
		}

		if(movingObj.transform.position == startPoint.position)
			{
				currentTarget = endPoint.position;
			}
	}
}
