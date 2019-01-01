using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqHolderLadder : MonoBehaviour {

	public GameObject eqBox;
	public bool eqActive;

	private EqManagerLadder eqLad;

	public bool eqAnswered;

	// Use this for initialization
	void Start () 
	{
		eqLad = FindObjectOfType<EqManagerLadder> ();
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
			eqLad.StartTheEquation();
			eqAnswered = true;
		}
	}
}	