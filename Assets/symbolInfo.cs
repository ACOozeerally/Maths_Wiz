using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class symbolInfo : MonoBehaviour {

	public GameObject information;
	public bool active;

	// Use this for initialization
	void Start () {
		information.SetActive (false);
		active = false;

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (active && Input.GetKeyDown(KeyCode.Space))
		{
			information.SetActive(false);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Wizard") 
		{
			active = true;
			information.SetActive (true);

		}


	}


}
