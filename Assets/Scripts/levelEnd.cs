using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEnd : MonoBehaviour {

	public string levelUnlocked;
	public string nextLevel;

	public LevelManager lvlManager;

	public float delayLoad;



	// Use this for initialization
	void Start ()
	{
		lvlManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			StartCoroutine ("endLevelCo");
		}
	}

	public IEnumerator endLevelCo()
	{
		//PlayerPrefs store information in game (permanently available)
		PlayerPrefs.SetInt("Score", lvlManager.scoreCounter);

		PlayerPrefs.SetInt ("Lives", lvlManager.lives);

		PlayerPrefs.SetInt (levelUnlocked, 1);

		yield return new WaitForSeconds (delayLoad);

		SceneManager.LoadScene (nextLevel);
	}

}
