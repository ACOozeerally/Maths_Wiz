using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	private LevelManager lvlManager;

	public GameObject pauseScreen;

	private PlayerController playerController;

	// Use this for initialization
	void Start ()
	{
		lvlManager = FindObjectOfType<LevelManager> ();
		playerController = FindObjectOfType<PlayerController> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.P))
		{
			Time.timeScale = 0;
			pauseScreen.SetActive (true);
			playerController.movement = false;
		}
	}

	public void Continue()
	{
		Time.timeScale = 1f;
		pauseScreen.SetActive (false);
		playerController.movement = true;
	}

	public void LevelSelect()
	{
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("Lives", lvlManager.startLives);
		Time.timeScale = 1f;
		SceneManager.LoadScene (levelSelect);
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (mainMenu);
	}
}
