using UnityEngine;
using System.Collections;

public class TouchButtonScript : MonoBehaviour 
{

	void Update ()
	{
		//is there a touch on screen?
		if (Input.touches.Length <= 0)
		{
			// If no touches then execute this code

		}
		else //if there is a touch
		{ 
			//loop through all the touches on screen
			for(int i = 0; i < Input.touchCount; i++)
			{
				//executes this code for current touch(i) on screen
				if(this.guiTexture.HitTest(Input.GetTouch(i).position))
				{
					//If current touch hits texture run this code
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					   {
						//Need to send message because function is not linked to this script
						//Debug.Log("The Touch has begun on " + this.name);
						this.SendMessage(this.name);
					   }
					if(Input.GetTouch(i).phase == TouchPhase.Ended)
					{
						Debug.Log("The Touch has ended on " + this.name);
					}
			    }
		    }
		}
	}

}
