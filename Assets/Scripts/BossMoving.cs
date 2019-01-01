using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoving : MonoBehaviour {

	public GameObject movingObj;

	public Transform startPoint;

	public float moveSpeed;

	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		movingObj.transform.position = Vector3.MoveTowards (movingObj.transform.position, currentTarget, moveSpeed * Time.deltaTime);
		currentTarget = startPoint.position;
	}
}
