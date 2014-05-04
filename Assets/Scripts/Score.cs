using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public int score = 0;
	public string GOMsg = "";

	void Awake(){
		}


	void Update ()	{
		// Set the score text.
		guiText.text = " " + GOMsg + score;

	}

	public void checkFinalScore(){
		if (PlayerPrefs.HasKey ("Player Score")) {
			if (PlayerPrefs.GetInt ("Player Score") < score){
				PlayerPrefs.SetInt ("Player Score", score);
				PlayerPrefs.Save();
			}
		}
		else {
			PlayerPrefs.SetInt ("Player Score", score);
		}
		Debug.Log (PlayerPrefs.GetInt ("Player Score"));
	}
}
