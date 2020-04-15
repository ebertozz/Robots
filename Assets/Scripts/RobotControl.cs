using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotControl : MonoBehaviour {

	float runSpeed = 2;  // speed character moves
	float jumpForce = 300;// how high can jump
	Animator myAnimator; // creating a reference to the animator



	public bool grounded = true;// define a public bool so we can see when grounded
	public GameObject groundCheck = null;// slot in inspector for our groundcheck
    private bool lookingRight = true;


	Vector2 target = new Vector2(-5, 4);



	// Use this for initialization
	void Start()
	{
		myAnimator = GetComponent<Animator>();// attaching the animator to the reference
		
	}

	// Update is called once per frame
	void Update()
	{


		Debug.DrawLine(transform.position, groundCheck.transform.position, Color.yellow);
		// causes a yellow line to appear between center of bot and ground check;

		if (Physics2D.Linecast(transform.position, groundCheck.transform.position))
		// executes a linecast
		{
			grounded = true; // if there is a hit on our linecast we are on a platform - set grounded to true
         

			RaycastHit2D hitPlatform = Physics2D.Linecast(transform.position, groundCheck.transform.position); // name the object we are hitting hitplatform
			if (hitPlatform != null && hitPlatform.collider.name == "elevator")
			{ // if the name of the hitplatform object is elevator

				//send the player back to the start position
				transform.position = Vector2.zero;
			

			}

		}
		else
		{
			grounded = false;
			
			//if we aren't hitting a platform, set grounded to false
		}


		// send state of all parameters to the animator
		myAnimator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));


		float currentYVel = GetComponent<Rigidbody2D>().velocity.y;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);
			transform.localScale = new Vector2(-1, transform.localScale.y);
			lookingRight = false;
		}
		 if (Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
			transform.localScale = new Vector2(1, transform.localScale.y);
			lookingRight = true;

		}
		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
		{

			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			//Debug.Log(grounded);

		}

		if (Input.GetKeyDown(KeyCode.T))
		{
			 
			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
			
            Debug.DrawLine(transform.position, transform.position + transform.right, Color.yellow);
			
  
			
			if (hit.collider != null && hit.collider.tag == "Character")
			{


					WhosTalking hitCharacter = hit.collider.GetComponent<WhosTalking>();
					if (hitCharacter)
					{
						hitCharacter.startTalking();
					}


				}
			

		}
	}
}
