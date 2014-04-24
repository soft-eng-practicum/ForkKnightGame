using UnityEngine;
using System.Collections;

public class SimpleMoveScript : MonoBehaviour {
	public Vector2 speed = new Vector2(5, 10);
	
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	
	void Update()
	{
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		if (transform.position.x > 70)
			Destroy (gameObject);
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
}

