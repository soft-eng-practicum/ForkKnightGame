using UnityEngine;
using System.Collections;

public class AttackBitches : MonoBehaviour {
	public GameObject target;
	BoxCollider2D hitbox; 
	//bool attacking;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		hitbox = GetComponent<BoxCollider2D>();
		if (Input.GetKeyUp (KeyCode.Space)) {
			Attacking ();
		}	
	}

	void Attacking(){
		//attacking = true;
		hitbox.enabled = true;
		StartCoroutine("AttackCooldown");
	}

	void OnTriggerEnter2D(Collider2D coll){
		target = coll.gameObject;
		Debug.Log (target.name);
		Attack ();
	}

	IEnumerator AttackCooldown(){
		yield return new WaitForSeconds(0.3f);
		Attacked();
	}

	void Attacked() {
		//attacking = false;
		hitbox.enabled = false;
	}

	private void Attack(){
		EnemyHealthScript zh = (EnemyHealthScript)target.GetComponent ("EnemyHealthScript");
		zh.AdjustCurrentHealth (-1);
	}
}
