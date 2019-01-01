using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string newGame;
	public string levelSelect;
	public string howToPlay;
	public string[] levels;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void NewGame()
	{
		SceneManager.LoadScene (newGame);
		for (int i = 0; i < levels.Length; i++) 
		{
			PlayerPrefs.SetInt (levels [i], 0);
			PlayerPrefs.SetInt("Score", 0);
			PlayerPrefs.SetInt ("Lives", 3);
		}
	}

	public void ContinueGame()
	{
		SceneManager.LoadScene (levelSelect);
	}

	public void HowToPlay()
	{
		SceneManager.LoadScene (howToPlay);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}


}
