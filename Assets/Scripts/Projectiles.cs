using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

	public GameObject projectile;
	public Vector2 velocity;

	public bool canFire = true;
	public Vector2 offset = new Vector2(2f, 2f);

	public float coolDown = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.B) && canFire) 
		{
			GameObject object1 = (GameObject)Instantiate (projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
			object1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x * transform.localScale.x, velocity.y);

			StartCoroutine (CanFire ());

			GetComponent<Animator> ().SetTrigger ("Spell");
		}
	}

	IEnumerator CanFire()
	{
		canFire = false;
		yield return new WaitForSeconds (coolDown);
		canFire = true;
	}
}
