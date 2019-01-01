using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class EquationManager : MonoBehaviour {

	public GameObject eqBox;
	public GameObject doorToDestroy;

	public Text eqLeft;
	public Text eqRight;
	public Text realAnsText;

	public int num1;
	public int num2;
	public InputField userAnswer;
	public int realAnswer;

	public bool eqActive;


	// Use this for initialization
	void Start () { 
		eqLeft.text = " " + num1;
		eqRight.text = " " + num2;

	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void StartTheEquation()
	{
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
		if (inputAnswer == realAnswer)
		{
			Destroy (doorToDestroy);
			eqBox.SetActive (false);
			eqActive = false;
		}
	}

	public void CloseBox()
	{
		if (eqActive && Input.GetKeyDown(KeyCode.Z))
		{
			eqBox.SetActive (false);
			eqActive = false;

		}
	}

}
