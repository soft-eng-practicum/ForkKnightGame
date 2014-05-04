using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 8;
	int currentHealth;
	Health healthguiScript;
	PlayerScript pScript;
	Transform weapon;
	Score score; 

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
			//Debug.Log ("PLAYER DEAD");
			score = GameObject.Find ("Score").GetComponent<Score>();
			score.GOMsg = "GAME OVER\n";
			score.checkFinalScore();

			pScript.enabled = false;
			SpriteRenderer sprite = GetComponent<SpriteRenderer>();
			BoxCollider2D hitbox = GetComponent<BoxCollider2D>();
			weapon = pScript.weapon.transform;
			pScript.weapon.AddComponent("Rigidbody2D");
			pScript.weapon.rigidbody2D.fixedAngle = true;
			weapon.parent = null;
			hitbox.isTrigger = true;
			rigidbody2D.gravityScale = 10;
			//enemy death anim (up and fall through ground)
			rigidbody2D.AddForce(new Vector2(0f, 800f));
			sprite.sortingOrder = 8;

			//reload level
			//Application.LoadLevel(Application.loadedLevel);
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
	}

	public void TakeDamage (float amount)
	{
		// Decrement the player's health by amount.
		hp -= amount;
	}

	void FixedUpdate(){}
}*/