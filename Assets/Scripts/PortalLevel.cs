using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLevel : MonoBehaviour {

	public bool portalOpen;

	public string levelBeingLoaded;

	public Sprite PortalClosed;
	public Sprite PortalOpened;

	public SpriteRenderer portalSprite;

	// Use this for initialization

	void Start () {
		//set the first level to be automatically unlocked when starting the game
		PlayerPrefs.SetInt ("Level 1", 1);

		//if the level to load = 1 (true) then bool for portalOpen is true /same for false
		if (PlayerPrefs.GetInt (levelBeingLoaded) == 1) {
			portalOpen = true;
		} else {
			portalOpen = false;
		}

		//if portal open is true then the grey portal will be inactive
		//while the blue portal will become active to use
		if (portalOpen) {
			portalSprite.sprite = PortalOpened;
		} else {
			portalSprite.sprite = PortalClosed;
		}
	}
	
	// Update is called once per frame
	void Update (){
	}
	
    void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (Input.GetButtonDown("Jump") && portalOpen) 
			{
				SceneManager.LoadScene (levelBeingLoaded);
			}
		}
	}

}
