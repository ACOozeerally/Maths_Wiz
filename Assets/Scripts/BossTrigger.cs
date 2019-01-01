using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {

	private BossMoving bossMove;
	public GameObject bossActive;

	// Use this for initialization
	void Start () {
		bossMove = FindObjectOfType<BossMoving>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") 
		{
			bossActive.SetActive (true);
			Destroy (gameObject);
		}
	}

}
