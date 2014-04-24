using UnityEngine;
using System.Collections;

public class ZombieAttack : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;

	public bool facingLeft = true;

	public float spacing = 1.3f;


	private Transform myTransform;
	private Transform weaponTransform;

	void Awake(){
		myTransform = transform;
	}

	void Start(){
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		weaponTransform = transform.Find ("attackBox");
	}

	void Update(){

		//Debug.DrawLine(target.position, myTransform.position, Color.yellow);

		//Look at Perry.
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

		//Move towards Perry
		if (target.position.x < myTransform.position.x) { 
			myTransform.position -= myTransform.right * moveSpeed * Time.deltaTime; // player is left of enemy, move left
			if(!facingLeft) Flip();
		} 
		else if (target.position.x > myTransform.position.x) { 
			myTransform.position += myTransform.right * moveSpeed * Time.deltaTime; // player is right of enemy, move right
			if(facingLeft) Flip ();
		}

		//Attack Perry
		if (Mathf.Abs (weaponTransform.position.x - target.position.x) < spacing) {
			//ref attack, call function
			Debug.Log ("z attk");
			AttackMelee myscript = gameObject.GetComponentInChildren<AttackMelee> ();
			myscript.Attacking ();
		}
	}

	void Flip(){
		facingLeft = !facingLeft;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		}
	}