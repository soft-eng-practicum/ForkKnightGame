using UnityEngine;
using System.Collections;

public class ZombieAttack : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public bool facingLeft = true;

	public float spacing = 1.1f;

	private Transform myTransform;
	private Transform weaponTransform;
	private ZombieAttack script;

	EnemyHealthScript deadCheck; 
	bool isDead;

	void Awake(){
		myTransform = transform;
	}

	void Start(){
		deadCheck = (EnemyHealthScript)gameObject.GetComponent ("EnemyHealthScript");
		isDead = deadCheck.isDead;
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		weaponTransform = transform.Find ("attackBox");
		script = GetComponent<ZombieAttack> ();
	}

	void Update(){

		isDead = deadCheck.isDead;
		if (isDead)
			script.enabled = !script.enabled;
		//Debug.DrawLine(target.position, myTransform.position, Color.yellow);

		//Look at Perry.
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

		//Move towards Perry
		if (target.position.x + .5 < myTransform.position.x) { 
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