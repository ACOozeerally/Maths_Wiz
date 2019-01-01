using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {

	public PlayerController theWizard;

	public float delayRespawn;
	public GameObject deathBurst;
	public GameObject gameOver;

	public int loseHealth;

	public Image heart1;
	public Image heart2;
	public Image heart3;

	public Sprite heartFull;
	public Sprite heartEmpty;

	public int maxHealth;
	public int healthCounter;

	public Text scoreText;

	public int lives;
	public int startLives;
	public Text lifeText;


	public int scoreCounter;
	private int scoreLifeCounter;

	private bool respawnCheck;

	public bool invincible;

	public AudioSource coinSound;
	public AudioSource gameMusic;
	public AudioSource gameOverMusic;

	// Use this for initialization

	void Start () 
	{
		//Will find obj in active scene that has playercontroller script attached
		theWizard = FindObjectOfType<PlayerController> ();

		if (PlayerPrefs.HasKey ("Score"))
		{
			scoreCounter = PlayerPrefs.GetInt ("Score");
		}

		scoreText.text = "Score: " + scoreCounter;

		healthCounter = maxHealth;

		if (PlayerPrefs.HasKey ("Lives")) {
			lives = PlayerPrefs.GetInt ("Lives");
		} else {
			lives = startLives;
		}
			
		lifeText.text = "Lives: " + lives;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (healthCounter <= 0 && !respawnCheck) {
			Respawn ();
			respawnCheck = true;
		}

		if (scoreLifeCounter >= 100) {
			lives += 1;
			lifeText.text = "Lives: " + lives;
			scoreLifeCounter = 0;
		}
	}

	//function that deactivates, repositions and then reactivates wizard
	public void Respawn()
	{
		//takes away one life when respawn is called
		lives -= 1;
		//updates life text to display new life count
		lifeText.text = "Lives: " + lives;

		//if player's lives are greater than 0 then it will run the respawn co routine, if not
		//then it will display the game over screen
		if (lives > 0) {
			//runs respawn co routine
			StartCoroutine ("RespawnCo");
		} else {
			//sets wizard inactive and game over screen active
			theWizard.gameObject.SetActive (false);
			gameOver.SetActive (true);
			gameMusic.Stop ();
			gameOverMusic.Play ();
		}
	}

	public IEnumerator RespawnCo()
	{
		//sets the wizard as inactive
		theWizard.gameObject.SetActive (false);

		//starts the partical burst to be played when respawn co is called
		Instantiate (deathBurst, theWizard.transform.position, theWizard.transform.rotation);

		//delays respawning the character by the number of seconds specified
		yield return new WaitForSeconds (delayRespawn);

		//sets the healh for the player to be full again
		healthCounter = maxHealth;
		//updates new health
		updateHealthStatus ();
		respawnCheck = false;

		//resets score counter to 0 when player dies
		scoreCounter = 0;
		//updates score to new health
		scoreText.text = "Score :" + scoreCounter;
		scoreLifeCounter = 0;

		//sets the wizards respawning position
		theWizard.transform.position = theWizard.respawnPosition;
		//sets wizard as active
		theWizard.gameObject.SetActive (true);
	}

	//adds score when a coin is picked up, equation solved, monster killed
	public void AddScore(int scoreAdd)
	{
		scoreCounter += scoreAdd;

		scoreLifeCounter += scoreAdd;

		scoreText.text = "Score: " + scoreCounter;

		coinSound.Play ();
	}

	//makes player lose health
	public void HurtPlayer (int loseHealth)
	{
		if (!invincible) 
		{
			healthCounter -= loseHealth;
			updateHealthStatus ();
			theWizard.PushBack ();

			theWizard.hurtSound.Play ();
		}
	}

	//Adds an extra life to the player when a life is picked up
	public void AddLife (int lifeToAdd)
	{
		lives += lifeToAdd;
		lifeText.text = "Lives: " + lives;
		coinSound.Play ();
	}

	public void AddHealth (int healthToAdd)
	{
		healthCounter += healthToAdd;

		if (healthCounter > maxHealth) {
			healthCounter = maxHealth;
		}

		updateHealthStatus ();
		coinSound.Play ();
	}


	//updates the images in the health meter based on how many hearts the wizard has, default is full health (3 hearts)
	public void updateHealthStatus()
	{
		switch(healthCounter)
		{
		case 3:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			return;

		case 2:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartEmpty;
			return;

		case 1: 
			heart1.sprite = heartFull;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;

		case 0:
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;

		default:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			return;
			
		}
	}


}
