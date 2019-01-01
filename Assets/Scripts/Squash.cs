using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squash : MonoBehaviour {
	public GameObject deathBurst;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Skeleton") 
		{
			Destroy (other.gameObject);
			Instantiate(deathBurst, other.transform.position, other.transform.rotation);
		}
	}
}
