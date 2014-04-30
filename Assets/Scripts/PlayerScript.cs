using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class PlayerScript : MonoBehaviour {

	// GUI textures
	public GUITexture guiLeft;
	public GUITexture guiRight;
	public GUITexture guiJump;
	
	// Movement variables
	public float moveSpeed = 5f;
	public float maxJumpVelocity = 2f;
	public int   facing;
	
	// Movement flags
	private bool moveLeft, moveRight, doJump = false;

	public float speed = 17f;
	public float jumpForce = 1100f;
	public bool jumpEnabled = true;
	public bool facingLeft = true;
	public bool isGrounded = false;
	public GameObject weapon;

	private float movement;	
	public float moddedJumpForce;
	private bool jumping = false;
	private Transform groundCheck;
	private Vector2 groundCheckPos;
	private Vector2 playerPos;

	void Start () {
		weapon = GameObject.Find ("pitchfork");
		groundCheck = GameObject.Find ("groundCheck").transform;
		moddedJumpForce = jumpForce;
	}
	
	void Update () {


		groundCheckPos = new Vector2 (groundCheck.position.x, groundCheck.position.y);
		playerPos = new Vector2 (transform.position.x, transform.position.y);
		isGrounded = Physics2D.Linecast(playerPos, groundCheckPos, 1 << LayerMask.NameToLayer("Ground"));

		if (jumpEnabled)
			if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
				jumping = true;

		if(jumping){
			if (moddedJumpForce < -jumpForce && isGrounded){
				jumping = false;
				moddedJumpForce = jumpForce;
			}
		}
			

		float inputX = Input.GetAxis ("Horizontal"); //left = -1, right = 1
		movement = speed * inputX;

			if (inputX < 0 && !facingLeft)
			Flip ();
		if (inputX > 0 && facingLeft)
			Flip ();
		//moveDirection.y -= movement.gravity * Time.deltaTime;

		// Check to see if the screen is being touched
		if (Input.touchCount > 0)
		{
			// Get the touch info
			Touch t = Input.GetTouch(0);
			
			// Did the touch action just begin?
			if (t.phase == TouchPhase.Began)
			{
				// Are we touching the left arrow?
				if (guiLeft.HitTest(t.position, Camera.main))
				{
					Debug.Log("Touching Left Control");
					moveLeft = true;
					facing = -1;
					if (facing < 0 && !facingLeft)
						Flip ();
				}
				
				// Are we touching the right arrow?
				if (guiRight.HitTest(t.position, Camera.main))
				{
					Debug.Log("Touching Right Control");
					moveRight = true;
					facing = 1;
					if (facing > 0 && facingLeft)
						Flip ();
				}
				
				// Are we touching the jump button?
				if (guiJump.HitTest(t.position, Camera.main))
				{
					Debug.Log("Touching Jump Control");
					doJump = true;
				}
			}
			
			// Did the touch end?
			if (t.phase == TouchPhase.Ended)
			{
				// Stop all movement
				doJump = moveLeft = moveRight = false;
				rigidbody2D.velocity = Vector2.zero;
			}
		}
		
		// Is the left mouse button down?
		if (Input.GetMouseButtonDown(0))
		{
			// Are we clicking the left arrow?
			if (guiLeft.HitTest(Input.mousePosition, Camera.main))
			{
				Debug.Log("Touching Left Control");
				moveLeft = true;
			}
			
			// Are we clicking the right arrow?
			if (guiRight.HitTest(Input.mousePosition, Camera.main))
			{
				Debug.Log("Touching Right Control");
				moveRight = true;
			}
			
			// Are we clicking the jump button?
			if (guiJump.HitTest(Input.mousePosition, Camera.main))
			{
				Debug.Log("Touching Jump Control");
				doJump = true;
			}
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			// Stop all movement on left mouse button up
			doJump = moveLeft = moveRight = false;
			rigidbody2D.velocity = Vector2.zero;
		}

	}

	void Flip(){
		facingLeft = !facingLeft;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector2 (movement, 0);

		if (jumping) {
			rigidbody2D.AddForce (new Vector2 (0f, moddedJumpForce));
			moddedJumpForce -= 40;
		}

		// Set velocity based on our movement flags.
		if (moveLeft)
		{

			rigidbody2D.velocity = -Vector2.right * moveSpeed;

		}
		
		if (moveRight)
		{

			rigidbody2D.velocity = Vector2.right * moveSpeed;
		}
		
		if (doJump)
		{
			// If we have not reached the maximum jump velocity, keep applying force.
			if (rigidbody2D.velocity.y < maxJumpVelocity)
			{
				rigidbody2D.AddForce(Vector2.up * jumpForce);
			} else {
				// Otherwise stop jumping
				doJump = false;
			}
		}

	}
}
