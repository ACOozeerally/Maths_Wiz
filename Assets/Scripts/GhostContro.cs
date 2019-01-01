using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostContro : MonoBehaviour {

	public Transform ghostGroundCheck;
	public float ghostGroundCheckRadius;
	public LayerMask ghostWhatIsGround;


	private Animator ghostAnim;
	public bool ghostGrounded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ghostGrounded = Physics2D.OverlapCircle (ghostGroundCheck.position, ghostGroundCheckRadius, ghostWhatIsGround);



		ghostAnim = GetComponent<Animator>();



		ghostAnim.SetBool ("Grounded", ghostGrounded);


	}
}
