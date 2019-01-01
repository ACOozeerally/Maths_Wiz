using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiEqHolder : MonoBehaviour {

	public GameObject eqBox;
	public bool eqActive;

	private MultiEq eqMan;

	public bool eqAnswered;


	// Use this for initialization
	void Start () 
	{
		eqMan = FindObjectOfType<MultiEq> ();
		eqAnswered = false;
	}

	// Update is called once per frame
	void Update () 
	{


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Wizard" && eqAnswered == false) 
		{
			eqActive = true;
			eqBox.SetActive(true);
			eqMan.StartTheEquation();
			eqAnswered = true;
		}
	}
}	