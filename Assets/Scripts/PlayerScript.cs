using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

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
		float inputX = Input.GetAxis ("Horizontal"); //left = -1, right = 1
		movement = speed * inputX;

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
			
			if (inputX < 0 && !facingLeft)
			Flip ();
		if (inputX > 0 && facingLeft)
			Flip ();
		//moveDirection.y -= movement.gravity * Time.deltaTime;
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
	}
}
