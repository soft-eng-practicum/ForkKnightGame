using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {
	
	//A general health script for anything the player can attack.
	//
	//Handles take damage, score update.

	public int maxHealth = 1;
	public int pointWorth = 1;
	public bool isDead;
	public AudioClip enemyHurt;
	
	private GameObject score;
	//private GameObject enemy;

	int currentHealth;

	void Start () {
		score = GameObject.Find ("Score");
		currentHealth = maxHealth;
		isDead = false;
	}

	void Update () {
		//destroy after falling off screen, add points
		if (transform.position.y < -5) {
			Destroy (gameObject);
			Score scoreScript = score.GetComponent<Score>();
			scoreScript.score += pointWorth;
		}
	}

	public void AdjustCurrentHealth(int adj) {
		currentHealth += adj;
		audio.PlayOneShot(enemyHurt);

		if (maxHealth < 1)
			maxHealth = 1;

		if (currentHealth < 1)
			currentHealth = 0;
		
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
				
		if (currentHealth <= 0) {
			isDead = true;
			SpriteRenderer sprite = GetComponent<SpriteRenderer>();
			BoxCollider2D hitbox = GetComponent<BoxCollider2D>();

			//enemy death anim (up and fall through ground)
			rigidbody2D.AddForce(new Vector2(0f, 200f));
			hitbox.isTrigger = true;
			sprite.sortingOrder = 8;
			
		}
		
	}
}
