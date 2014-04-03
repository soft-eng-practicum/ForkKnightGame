using UnityEngine;
using System.Collections;

/// <summary>
/// Projectile Behaviour
/// </summary>

public class ShotScript : MonoBehaviour {

//1 - Designer Variables

	///<summary>
	/// Damage Inflicted
	/// </summary>
	public int damage = 1;

	/// <summary>
	/// Damage Inflicted
	/// </summary>
	public bool isEnemyShot = false;

	void Start()
	{
				// 2 - Limited time to live to avoid any leak
				Destroy (gameObject, 20); //20 sec
		}

}
