using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MultiEq12 : MonoBehaviour {

	public GameObject eqBox;

	public Text eqLeft;
	public Text eqRight;
	public Text realAnsText;

	public int num1;
	public int num2;
	public InputField userAnswer;
	public int realAnswer;

	public bool eqActive;

	public GameObject objectOne;
	public GameObject objectTwo;

	private LevelManager lvlManager;
	public int scoreValue;


	private SpriteRenderer leverSpriteRenderer;

	// Use this for initialization
	void Start () { 
		lvlManager = FindObjectOfType<LevelManager> ();
		eqLeft.text = " " + num1;
		eqRight.text = " " + num2;

		objectOne.SetActive (true);
		objectTwo.SetActive (false);

	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void StartTheEquation()
	{
		//eqActive = true;
		//eqBox.SetActive(true);

		num1 = UnityEngine.Random.Range(2, 6);
		num2 = UnityEngine.Random.Range(2, 5);

		num1.ToString ();
		num2.ToString ();

		eqLeft.text = num1.ToString() + " x ";
		eqRight.text = num2.ToString() + " =";

		realAnswer = num1 * num2;
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
			Destroy (objectOne);
			objectTwo.SetActive (true);
			Destroy (gameObject);

		} 

		if (inputAnswer != realAnswer) 
		{
			lvlManager.healthCounter -= 1;
			lvlManager.updateHealthStatus ();

		}
	}


}