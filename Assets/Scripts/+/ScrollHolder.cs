using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHolder : MonoBehaviour {
	
	public GameObject eqBox;
	public bool eqActive;

	private ScrollEqManager scrollEq;

	public bool eqAnswered;

	// Use this for initialization
	void Start () 
	{
		scrollEq = FindObjectOfType<ScrollEqManager> ();
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
			scrollEq.StartTheEquation();
			eqAnswered = true;
		}
	}
}	