using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 8;
	int currentHealth;
	Health healthguiScript;
	PlayerScript pScript;

	void Start(){
		currentHealth = maxHealth;
		GameObject health = GameObject.Find ("Health");
		healthguiScript = (Health)health.GetComponent ("Health");
		pScript = GetComponent<PlayerScript> ();
	}

	void Update (){

	}

	public void AdjustCurrentHealth(int adj) {
		currentHealth += adj;

		if (currentHealth < 1)
			 currentHealth = 0;

		if (currentHealth > maxHealth)
			 currentHealth = maxHealth;

		if (maxHealth < 1)
			 maxHealth = 1;

		healthguiScript.modifyHealth (currentHealth);

		if (currentHealth <= 0) {
			Debug.Log ("PLAYER DEAD");
			pScript.enabled = false;
			SpriteRenderer sprite = GetComponent<SpriteRenderer>();
			BoxCollider2D hitbox = GetComponent<BoxCollider2D>();
			
			//enemy death anim (up and fall through ground)
			rigidbody2D.AddForce(new Vector2(0f, 200f));
			hitbox.isTrigger = true;
			sprite.sortingOrder = 8;

		}

	}
}	
	/*public float hp = 2f;
	public float resetAfterDeathTime = 5f;

	private PlayerScript playerMovement;
	private float timer;
	private bool playerDead;

	void Start(){}

	void Update(){
		if (hp <= 0f)
		{
			if(!playerDead)
				PlayerDying();
			else
				PlayerDead();
		}
	}

	void Alive(){
		
		playerMovement = GetComponent<PlayerScript>();
		
	}

	void PlayerDying(){
		
		playerDead = true;
	}

	void PlayerDead(){
		
		playerMovement.enabled = false;
	}
	
	void LevelReset(){
		
		timer += Time.deltaTime;
		
		if (timer >= resetAfterDeathTime)
			//fade out
			print("Level reset");
	}
	
	public void TakeDamage (float amount)
	{
		// Decrement the player's health by amount.
		hp -= amount;
	}

	void FixedUpdate(){}
}*/