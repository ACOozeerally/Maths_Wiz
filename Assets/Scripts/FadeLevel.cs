using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeLevel : MonoBehaviour {

	public float fadeLength;

	private Image fadeScreen;

	// Use this for initialization
	void Start () {
		fadeScreen = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		fadeScreen.CrossFadeAlpha(0, fadeLength, false);

		if (fadeScreen.color.a == 0) 
		{
			Destroy (gameObject);
		}
		
	}
}
