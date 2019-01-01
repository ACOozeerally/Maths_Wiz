using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationHolder3 : MonoBehaviour {

	public GameObject eqBox;
	public bool eqActive;

	private EqManager3 eqMan3;

	public bool eqAnswered;

	// Use this for initialization
	void Start () 
	{
		eqMan3 = FindObjectOfType<EqManager3> ();
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
			eqMan3.StartTheEquation();
			eqAnswered = true;
		}
	}
}	