using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour {	

	void Update () {
		if (GameObject.FindWithTag ("Player") != null) {
				}
		else 
			Application.LoadLevel ("GameOver");
	}
}
