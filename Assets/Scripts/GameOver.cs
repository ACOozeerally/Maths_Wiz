using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	private LevelManager lvlManager;

	// Use this for initialization
	void Start () {
		lvlManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart()
	{
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("Lives", lvlManager.startLives);

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void LevelSelect()
	{
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("Lives", lvlManager.startLives);

		SceneManager.LoadScene (levelSelect);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene (mainMenu);
	}


}
