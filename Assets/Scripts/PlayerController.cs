using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//movement
	public bool movement;
	public float scale;
	public float moveSpeed;
	public float jumpSpeed;
	public Rigidbody2D myRigidbody;

	//ground
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	//Booleans to check if player is on the ground and if the player can double jump
	public bool isGrounded;
	public bool doubleJump;

	//accesses Unity's animator in order to run specific animations attached to the player
	private Animator myAnim;

	//Sets the player's respawn position
	public Vector3 respawnPosition;

	//Player's climbing speed
	public float climbSpeed = 5;	

	public LevelManager theLevelManager;

	public float pushbackPower;
	public float pushbackDistance;
	private float pushbackCounter;

	public AudioSource jumpSound;
	public AudioSource hurtSound;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();	
		myAnim = GetComponent<Animator>();

		//Sets the respawn position to be the player's current position
		respawnPosition = transform.position;

		theLevelManager = FindObjectOfType<LevelManager> ();

		//sets the player's movement bool to be true so that the player can move
		movement = true;
	}

	
	// Update is called once per frame
	void Update () {

		//Checks whether the groundcheck object attached to the player is touching ground
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		//if the player is not being pushed back and movement is true then the player will be able to move and jump
		if (pushbackCounter <= 0 && movement == true) 
		{

			//move left and right
			if (Input.GetAxisRaw ("Horizontal") > 0f) 
			{
				//moves the player to the right
				myRigidbody.velocity = new Vector3 (moveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3 (scale, scale, scale);
			} 
			else if (Input.GetAxisRaw ("Horizontal") < 0f) 
			{
				//moves the player to the left
				myRigidbody.velocity = new Vector3 (-moveSpeed, myRigidbody.velocity.y, 0f);
				//flips the player's scale so that he is facing the left
				transform.localScale = new Vector3 (-scale, scale, scale);
			} 
			else 
			{
				myRigidbody.velocity = new Vector3 (0f, myRigidbody.velocity.y, 0f);
			}

			//jump button - will jump when button is pressed AND when grounded
			if (Input.GetButtonDown ("Jump") && isGrounded)
			{
				Jump ();
			}
			//double jump
			if (isGrounded)
				doubleJump = false;

			if (Input.GetButtonDown ("Jump") && !doubleJump && !isGrounded) 
			{
				Jump ();
				doubleJump = true;
			}
		}

		if (pushbackCounter > 0) 
		{
			pushbackCounter -= Time.deltaTime;

			if (transform.localScale.x > 0) 
			{
				myRigidbody.velocity = new Vector3 (-pushbackPower, pushbackPower, 0f);
			} 
			else 
			{
				myRigidbody.velocity = new Vector3 (pushbackPower, pushbackPower, 0f);
			}

			theLevelManager.invincible = false;
		}

			//animate walking, Abs gets an absolute value (turns a negative number into a positive)
			myAnim.SetFloat ("Speed", Mathf.Abs (myRigidbody.velocity.x));
			myAnim.SetBool ("Grounded", isGrounded);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//if player collides with Kill Plane then they will respawn
		if (other.tag == "KillPlane") 
		{

			theLevelManager.Respawn();
		}
			
		//if player collides with checkpoint then respawn poisition is set to the checkpoints position
		if (other.tag == "Checkpoint") 
		{
			respawnPosition = other.transform.position;
		}
			
	}

	public void Jump()
	{
		//player moves up the y axis based on jumpSpeed int
		myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, jumpSpeed, 0f);
		jumpSound.Play ();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//if player collides with MovingPlatform then the player becomes a child of it
		//this allows the player to stay on the platform and not slide off
		if (other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = other.transform;
		}
			
	}

	void OnCollisionExit2D(Collision2D other)
	{
		//when the player leaves the moving platform the player is no longer a child of anything
		if (other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = null;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		//if the player collides with a ladder and the up arrow is pressed then the player will move up the ladder
		if (other.tag == "Ladder" && Input.GetKey (KeyCode.UpArrow)) 
		{
			myRigidbody.velocity = new Vector2 (0, climbSpeed);
		} 
		//if down arrow is pressed while on ladder then the player will move down the ladder
		else if (other.tag == "Ladder" && Input.GetKey (KeyCode.DownArrow)) 
		{
			myRigidbody.velocity = new Vector2 (0, -climbSpeed);
		} 
		else 
		{
			//if nothing is pressed while on the ladder then the player will remain stationary on it
			myRigidbody.velocity = new Vector2 (0, 1);
		}
	}

	//Occurs when the player is hurt and gets pushed back, they become invincible
	public void PushBack ()
	{
		pushbackCounter = pushbackDistance;
		theLevelManager.invincible = true;
	}
}
