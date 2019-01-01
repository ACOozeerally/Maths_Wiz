using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

	public GameObject movingMonster;

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
		movingMonster.transform.position = Vector3.MoveTowards (movingMonster.transform.position, currentTarget, moveSpeed * Time.deltaTime);

		if (movingMonster.transform.position == endPoint.position) 
		{
			currentTarget = startPoint.position;


		}

		if(movingMonster.transform.position == startPoint.position)
		{
			currentTarget = endPoint.position;

		}
	}
}

