using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 17f;
	public float jumpForce = 9999f;
	public bool facingLeft = true;
	public bool grounded = false;
	public GameObject weapon;

	private float movement;	

	
	void Start () {
		weapon = GameObject.Find ("pitchfork");
	}
	
	void Update () {
		float inputX = Input.GetAxis ("Horizontal"); //left = -1, right = 1
		
		movement = speed * inputX;

		//if (Input.GetKeyDown(KeyCode.UpArrow)) {
		//	Jump();
		//}

		if (inputX < 0 && !facingLeft)
			Flip ();
		if (inputX > 0 && facingLeft)
			Flip ();
	}

	void Jump(){
		rigidbody2D.AddForce(new Vector2(0f, 9999f));
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
		//grounded = Physics2D.OverlapCircle (groundCheck);
	}
}
