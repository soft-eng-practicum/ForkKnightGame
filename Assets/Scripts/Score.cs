using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public int score = 0;

	void Awake(){
		}


	void Update ()
	{
		// Set the score text.
		guiText.text = " " + score;

	}

}
