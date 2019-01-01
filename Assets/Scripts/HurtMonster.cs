using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtMonster : MonoBehaviour {

	public GameObject deathBurst;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {


	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Projectile")
		{
			Destroy (gameObject);
			Instantiate (deathBurst, transform.position, transform.rotation);
		}
	}

}