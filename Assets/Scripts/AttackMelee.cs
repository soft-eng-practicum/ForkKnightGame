using UnityEngine;
using System.Collections;

public class AttackMelee : MonoBehaviour {
	//A melee attack script, usable by weaponless zombies and the standard pitchfork (after implementing tags)

	public GameObject target;
	BoxCollider2D hitbox; 
	public int weaponDamage;
	public bool isPlayerAttack = true; //the script is attached to the player, not enemy
	//public anim
	
	void Start () {
		hitbox = GetComponent<BoxCollider2D>();
		weaponDamage = -1;
	}

	void Update () {
		if (isPlayerAttack && Input.GetKeyUp (KeyCode.Space)) {
			Attacking ();
		}	
	}

	public void Attacking(){
		//play anim
		hitbox.enabled = true;
		StartCoroutine("AttackCooldown");
	}

	void OnTriggerEnter2D(Collider2D coll){
		target = coll.gameObject;
		Debug.Log (target.name);
		if (isPlayerAttack) {
			if (target.tag == "Attackable")
				AttackEnemy ();
		}
		else {
			if(target.tag == "Player")
				AttackPlayer();
		}
	}

	IEnumerator AttackCooldown(){
		yield return new WaitForSeconds(0.3f);
		Attacked();
	}

	void Attacked() {
		hitbox.enabled = false;
	}

	private void AttackEnemy(){
		EnemyHealthScript zh = (EnemyHealthScript)target.GetComponent ("EnemyHealthScript");
		zh.AdjustCurrentHealth (weaponDamage);
	}

	private void AttackPlayer(){
		Debug.Log ("player hurt");
		PlayerHealth ph = (PlayerHealth)target.GetComponent ("PlayerHealth");
		ph.AdjustCurrentHealth (weaponDamage);
	}
}
