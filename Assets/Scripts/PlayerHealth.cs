using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int currentHealth = 100;
	public float healthBarLength;
	/*
	public Vector2 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
	public float x = screenPos.position.x;
	public float y = screenPos.position.y;*/

	void Start(){
		healthBarLength = Screen.width / 10;
	}

	void Update (){
		AdjustCurrentHealth (0);
	}
	/*
	void OnGUI(){
		GUI.Box(new Rect(0,0, healthBarLength, 20), currentHealth + "/" + maxHealth);
	}*/

	public void AdjustCurrentHealth(int adj) {
		currentHealth += adj;

		if (currentHealth < 1)
			 currentHealth = 0;

		if (currentHealth > maxHealth)
			 currentHealth = maxHealth;

		if (maxHealth < 1)
			 maxHealth = 1;

		healthBarLength = (Screen.width / 10) * (currentHealth / (float)maxHealth);
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