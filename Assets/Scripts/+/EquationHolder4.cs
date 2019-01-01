using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationHolder4 : MonoBehaviour {

	public GameObject eqBox;
	public bool eqActive;

	private EqManager4 eqMan4;

	public bool eqAnswered;

	// Use this for initialization
	void Start () 
	{
		eqMan4 = FindObjectOfType<EqManager4> ();
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
			eqMan4.StartTheEquation();
			eqAnswered = true;
		}
	}
}	