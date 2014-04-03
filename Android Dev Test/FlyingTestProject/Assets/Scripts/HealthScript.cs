using UnityEngine;
using System.Collections;


///<summary>
/// Handle Hit points and damages
/// </summary>

public class HealthScript : MonoBehaviour {
	/// <summary>
	/// Total hitpoints
	/// </summary>	

	public int hp = 1;

	///<summary>
	/// Enemy or player?
	/// </summary>

	public bool isEnemy = true;

	///<summary>
	/// Inflicts damage and check if the object should be destoryed
	/// </summary>
	/// <param name="damageCount"></para>
	public void Damage(int damageCount)
	{
				hp -= damageCount;

				if (hp <= 0)
		        {
						//Dead!
						Destroy(gameObject);
				}
		}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
				//Is this a shot?
				ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
				if (shot != null) {
						//Avoid friendly fire
						if (shot.isEnemyShot != isEnemy) {
								Damage(shot.damage);

								// Destroy the shot
								Destroy(shot.gameObject); //Remember to always target the game object, otherwise you will remove the script
						}
				}
		}


}
