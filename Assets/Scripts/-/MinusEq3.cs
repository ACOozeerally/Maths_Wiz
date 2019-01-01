using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MinusEq3 : MonoBehaviour {

	public GameObject eqBox;

	public Text eqLeft;
	public Text eqRight;
	public Text realAnsText;

	public int scoreValue;

	public int num1;
	public int num2;
	public InputField userAnswer;
	public int realAnswer;

	public bool eqActive;

	public GameObject bridgeBroken;
	public GameObject bridgeFixed;

	private LevelManager lvlManager;


	private SpriteRenderer leverSpriteRenderer;

	// Use this for initialization
	void Start () { 
		lvlManager = FindObjectOfType<LevelManager> ();

		eqLeft.text = " " + num1;
		eqRight.text = " " + num2;

		bridgeBroken.SetActive (true);
		bridgeFixed.SetActive (false);

	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void StartTheEquation()
	{
		//eqActive = true;
		//eqBox.SetActive(true);

		num1 = UnityEngine.Random.Range(10, 16);
		num2 = UnityEngine.Random.Range(1, 10);

		num1.ToString ();
		num2.ToString ();

		eqLeft.text = num1.ToString() + " - ";
		eqRight.text = num2.ToString() + " =";

		realAnswer = num1 - num2;
	}

	public void GetInput (string inputStringAnswer)
	{
		CompareAnswers (int.Parse (inputStringAnswer));
		userAnswer.text = "";

	}

	public void CompareAnswers (int inputAnswer)
	{
		if (inputAnswer == realAnswer)
		{

			eqBox.SetActive (false);
			eqActive = false;
			Destroy (bridgeBroken);
			bridgeFixed.SetActive (true);
			Destroy (gameObject);

		} 

		if (inputAnswer != realAnswer) 
		{
			lvlManager.healthCounter -= 1;
			lvlManager.updateHealthStatus ();

		}
	}



}
