using UnityEngine;
using System.Collections;

public class ZombieHealth : MonoBehaviour {
	public int x = 8;
	public int maxHealth;
	private int currentHealth;
	public float healthBarLength;
	private SpriteRenderer sprite;
	public int enemyscore;
	GameObject score;
	
	void Start(){
		healthBarLength = Screen.width / 2;
		score = GameObject.Find("Score");
		currentHealth = maxHealth;
	}
	
	void Update (){
		if (transform.position.y < -5) {
			Destroy (gameObject);
			Score scoreScript = score.GetComponent<Score>();
			scoreScript.score += enemyscore;
		}
	}
	/*
	void OnGUI(){
		GUI.Box(new Rect(0, 40, healthBarLength, 20), currentHealth + "/" + maxHealth);
	}*/
	
	public void AdjustCurrentHealth(int adj) {
		currentHealth += adj;
		
		if (currentHealth < 1)
			currentHealth = 0;
		
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
		
		if (maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 2) * (currentHealth / (float)maxHealth);

		if (currentHealth <= 0) {
			Debug.Log ("dead!");
			sprite = GetComponent<SpriteRenderer>();
			rigidbody2D.AddForce(new Vector2(0f, 200f));
			BoxCollider2D hitbox = GetComponent<BoxCollider2D>();
			hitbox.isTrigger = true;
			sprite.sortingOrder = x;

		}

	}
}