using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHolder2 : MonoBehaviour {

	public GameObject eqBox;
	public bool eqActive;

	private ScrollEqManager2 scrollEq2;

	public bool eqAnswered;

	// Use this for initialization
	void Start () 
	{
		scrollEq2 = FindObjectOfType<ScrollEqManager2> ();
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
			scrollEq2.StartTheEquation();
			eqAnswered = true;
		}
	}
}	