using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public float hp = 2f;
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
}