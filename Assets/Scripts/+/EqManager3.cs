﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class EqManager3 : MonoBehaviour {

	public GameObject eqBox;

	public GameObject doorToDestroy;

	public Text eqLeft;
	public Text eqRight;
	public Text realAnsText;

	public int scoreValue;

	//creates random object to generate numbers
	//UnityEngine.Random randomNum = new UnityEngine.Random();

	public int num1;
	public int num2;
	public InputField userAnswer;
	public int realAnswer;

	public bool eqActive;
	public bool isValidating;

	private SpriteRenderer leverSpriteRenderer;

	private LevelManager lvlManager;	

	// Use this for initialization
	void Start ()
	{ 
		lvlManager = FindObjectOfType<LevelManager> ();

		eqLeft.text = " " + num1;
		eqRight.text = " " + num2;

		leverSpriteRenderer = GetComponent<SpriteRenderer>();

		isValidating = true;
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void StartTheEquation()
	{
		//eqActive = true;
		//eqBox.SetActive(true);

		num1 = UnityEngine.Random.Range(1, 10);
		num2 = UnityEngine.Random.Range(1, 10);

		num1.ToString ();
		num2.ToString ();

		eqLeft.text = num1.ToString() + " + ";
		eqRight.text = num2.ToString() + " =";

		realAnswer = num1 + num2;
	}

	public void GetInput (string inputStringAnswer)
	{
		CompareAnswers (int.Parse (inputStringAnswer));
		userAnswer.text = "";

	}

	public void CompareAnswers (int inputAnswer)
	{
		if (inputAnswer == realAnswer  && isValidating ==true)
		{

			StartCoroutine (Validate ());


			Destroy (doorToDestroy);
			eqBox.SetActive (false);
			eqActive = false;

			lvlManager.AddScore (scoreValue);

			Destroy (gameObject);

		} 

		if (inputAnswer != realAnswer && isValidating == true) 
		{
			lvlManager.healthCounter -= 1;
			lvlManager.updateHealthStatus ();


			StartCoroutine (Validate ());

		}
	}

	public IEnumerator Validate()
	{
		isValidating = false;
		yield return new WaitForSeconds (2f);
		isValidating = true;
	}


}
