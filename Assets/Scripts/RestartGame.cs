using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

		private GUISkin skin;
		
		void Start()
		{
			// Load a skin for the buttons
			skin = Resources.Load("RestartSkin") as GUISkin;
		}
		
		void OnGUI()
		{
			const int buttonWidth = 154;
			const int buttonHeight = 77;
			
			// Set the skin to use
			GUI.skin = skin;
			
			// Draw a button to start the game
			if (GUI.Button(
				// Center in X, 2/3 of the height in Y
				new Rect(605, 275, buttonWidth, buttonHeight),
				""
				))
			{
				// On Click, load the first level.
				Application.LoadLevel("GameStart"); // "Stage1" is the scene name
			}
		}
	}