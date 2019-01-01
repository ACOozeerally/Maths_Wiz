using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWizardMove : MonoBehaviour {

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
			movingMonster.transform.position = Vector3.MoveTowards (movingMonster.transform.position,
				currentTarget, moveSpeed * Time.deltaTime);

			if (movingMonster.transform.position == endPoint.position) 
			{
				currentTarget = startPoint.position;
			transform.localScale = new Vector3(-0.5800003f, 0.5800003f, -2f);


			}

			if(movingMonster.transform.position == startPoint.position)
			{
				currentTarget = endPoint.position;
			transform.localScale = new Vector3 (0.5800003f, 0.5800003f, -2f);

			}
		}
	}