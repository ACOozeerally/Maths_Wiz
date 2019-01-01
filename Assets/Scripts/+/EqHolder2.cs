using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqHolder2 : MonoBehaviour {

	public GameObject eqBox;
	public bool eqActive;

	private EqManager2 eqMan2;

	public bool eqAnswered;

	// Use this for initialization
	void Start () 
	{
		eqMan2 = FindObjectOfType<EqManager2> ();
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
			eqMan2.StartTheEquation();
			eqAnswered = true;
		}
	}
}	