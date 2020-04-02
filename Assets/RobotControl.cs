using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotControl : MonoBehaviour {

	float runSpeed = 2;  // speed character moves
	float jumpForce = 300;// how high can jump
	Animator myAnimator; // creating a reference to the animator



	public bool grounded = true;// define a public bool so we can see when grounded
	public GameObject groundCheck = null;// slot in inspector for our groundcheck


    public bool imDead = false; // bool to set when on red platform
	public bool onGreen = false; // bool to set on green platform
	public Text robotThoughts;





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
			if (hitPlatform != null && hitPlatform.collider.name == "greenBox")
			{ // if the name of the hitplatform object is greenbox

				//robotThoughts.text = "I hit wow - my eyballs are flying";
				onGreen = true; // set the bool that we will send to animator


			}
			else if (hitPlatform != null && hitPlatform.collider.name == "redBox")
			{// if the hitplatform is redBox, set the other bool
				//robotThoughts.text = "I hit death- my eyes are falling out!";
				imDead = true;


			}
		}
		else
		{
			grounded = false;
			imDead = false;
			onGreen = false;
			//if we aren't hitting any platform, set all bools to false
		}


		// send state of all parameters to the animator
		myAnimator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        myAnimator.SetBool("onGreen", onGreen);
		
		myAnimator.SetBool("ImDead", imDead);

		float currentYVel = GetComponent<Rigidbody2D>().velocity.y;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);
			transform.localScale = new Vector2(-1, transform.localScale.y);

		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
			transform.localScale = new Vector2(1, transform.localScale.y);

			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2);
			Debug.DrawRay(transform.position, transform.right, Color.green);
			if (hit.collider != null && hit.collider.tag == "pig")
			{

				transform.position = Vector2.zero;
				robotThoughts.text = "I 'm near a pig - Help, rust! dust!";

			}


		}
		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
		{

			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			Debug.Log(grounded);

		}

	}
}
