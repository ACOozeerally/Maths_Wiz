using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour {

	public int lifeAmount;

	public LevelManager lvlManager;

	// Use this for initialization
	void Start () {
		lvlManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			lvlManager.AddLife(lifeAmount);
			gameObject.SetActive (false);
		}
	}
}
