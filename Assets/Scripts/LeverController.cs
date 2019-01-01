using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverController : MonoBehaviour {

	public Sprite leverClosed;
	public Sprite leverOpen;
	private SpriteRenderer leverSpriteRenderer;
	public EquationManager EqMan;

	// Use this for initialization
	void Start () {
	    leverSpriteRenderer = GetComponent<SpriteRenderer>();
		 EqMan = FindObjectOfType<EquationManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}		

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
		leverSpriteRenderer.sprite = leverOpen;
		}
	}
}
