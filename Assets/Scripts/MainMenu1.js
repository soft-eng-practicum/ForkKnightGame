var mainmenuSkin : GUISkin; //Skin
var areaWidth :float; //GUI Area Width
var areaHeight : float; //GUI Area Height


function OnGUI()
{
  GUI.skin = mainmenuSkin;
  var ScreenX = ((Screen.width * 0.5) - (areaWidth * 0.5));
  var ScreenY = ((Screen.height) - (areaHeight * 0.5));
  
  GUILayout.BeginArea(Rect(ScreenX, ScreenY, areaWidth, areaHeight));
  
  if(GUILayout.Button("Play"))
  {
     Application.LoadLevel("Stage1");
  }
  if(GUILayout.Button("Quit"))
  {
      Application.Quit();
  }
  GUILayout.EndArea();
}
  