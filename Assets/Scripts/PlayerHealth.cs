using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 8;
	int currentHealth;
	Health healthguiScript;

	void Start(){
		currentHealth = maxHealth;
		GameObject health = GameObject.Find ("Health");
		healthguiScript = (Health)health.GetComponent ("Health");
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

		if (currentHealth <= 0)
			Debug.Log ("PLAYER DEAD");

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