using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public string MainMenu;
	public GameObject wizard;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{
			wizard.SetActive (true);
			StartCoroutine ("loadScene");
		}
	}

	public IEnumerator loadScene(){

		yield return new WaitForSeconds (1.5f);

		SceneManager.LoadScene (MainMenu);
	}
}
