using UnityEngine;
using System.Collections;


public class TouchManager : MonoBehaviour {
	
	bool macKeyDown;
	public static float xScreenWidth;
	public static float xScreenStartPixel;
	
	
	// Use this for initialization
	void Start () {
		macKeyDown = false;

		float heigthRatio = Screen.height / 480.0f;
		float widthShouldBeWithThisHeight = 320.0f * heigthRatio;
		float widthRatio = Screen.width / widthShouldBeWithThisHeight;
		xScreenWidth = 320.0f * widthRatio;
		float diff = 320.0f - xScreenWidth;
		xScreenStartPixel = diff / 2.0f;
		
		Debug.Log ("SCREEN xScreenStartPixel = " + xScreenStartPixel.ToString());
		Debug.Log ("SCREEN xScreenWidth = " + xScreenWidth.ToString());
	}
	
	// Update is called once per frame
	void Update () {

//		const float kScreenWidth = 320.0f;	//Screen.width
		//const float kScreenHeight = 480.0f;  //Screen.height
		float kScreenWidth = Screen.width;
		float kScreenHeight = Screen.height;
		
		
		for (int i = 0; i < Input.touchCount; i++)
		{
			Default.Namespace.MyTouch tempTouch = new Default.Namespace.MyTouch();
			tempTouch.position.x = (Input.touches[i].position.x / kScreenWidth) * xScreenWidth;
			tempTouch.position.x += xScreenStartPixel;
			tempTouch.position.y = 480.0f - ((Input.touches[i].position.y / kScreenHeight) * 480.0f);
			tempTouch.phase = Input.touches[i].phase;
			tempTouch.fingerId = Input.touches[i].fingerId;
			
			//Debug.Log("Touch x-" + tempTouch.position.x + "  y-" + tempTouch.position.y);
			
//			Default.Namespace.Globals.g_world.HandleTouchP1P2P3(Input.touches[i]);
			Default.Namespace.Globals.g_world.HandleTouchP1P2P3(tempTouch);
		}
		
//		return;
		
		//Debug.Log("x:"+Input.mousePosition.x + " y:"+Input.mousePosition.y);
		
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
            if (Default.Namespace.Globals.g_world.worldState == Default.Namespace.WorldState.e_InGame) 
			{
                if (((Default.Namespace.Globals.g_world.game).gameState == Default.Namespace.GameState.e_GamePlay) || 
					((Default.Namespace.Globals.g_world.game).gameState == Default.Namespace.GameState.e_GetReady)) 
				{
                    (Default.Namespace.Globals.g_world.game).SetFlagStartPause(true);
                }
				else if ((Default.Namespace.Globals.g_world.game).gameState == Default.Namespace.GameState.e_Paused)
				{
	                Default.Namespace.Globals.g_world.game.hud.EndPause();
	                (Default.Namespace.Globals.g_world.game.hud.restartButton).SetIsClickable(false);
	                (Default.Namespace.Globals.g_world.game.hud.menuButton).SetIsClickable(false);
	                (Default.Namespace.Globals.g_world.game.hud.nextLevelButton).SetIsClickable(false);
	                (Default.Namespace.Globals.g_world.game.hud.nextLevelButton).wasPressed = true;
	                (Default.Namespace.Globals.g_world.game.hud.nextLevelButton).Update();
					
//					(Default.Namespace.Globals.g_world.game).SetNewGameState(Default.Namespace.GameState.e_GamePlay);
				}
				else
				{
					Default.Namespace.Globals.g_world.ChangeToWorldState(Default.Namespace.WorldState.e_FrontEnd);
				}
            }
			else
			{
				Default.Namespace.Globals.g_world.frontEnd.AndroidBackKeyPressed();
			}
		}
		
		if (Input.touchCount == 0)
		{
			//For testing on mac
						
//			if (true) //Input.GetKey(KeyCode.m))
			if( Input.anyKey)
    	    {
				
				
        		if (macKeyDown == true)
				{
					Default.Namespace.MyTouch fakeTouch = new Default.Namespace.MyTouch();
					fakeTouch.phase = TouchPhase.Moved;
					fakeTouch.position.x = (Input.mousePosition.x / kScreenWidth) * xScreenWidth;
					fakeTouch.position.x += xScreenStartPixel;
					fakeTouch.position.y = 480.0f - ((Input.mousePosition.y / kScreenHeight) * 480.0f);
					fakeTouch.fingerId = 0;
					
					Default.Namespace.Globals.g_world.HandleTouchP1P2P3(fakeTouch);

				}
				else
					{
						macKeyDown = true;
					Default.Namespace.MyTouch fakeTouch = new Default.Namespace.MyTouch();
					fakeTouch.phase = TouchPhase.Began;
					fakeTouch.position.x = (Input.mousePosition.x / kScreenWidth) * xScreenWidth;
					fakeTouch.position.x += xScreenStartPixel;
					fakeTouch.position.y = 480.0f - ((Input.mousePosition.y / kScreenHeight) * 480.0f);
					fakeTouch.fingerId = 0;
					
					Default.Namespace.Globals.g_world.HandleTouchP1P2P3(fakeTouch);
					}
			}
			else
			{
        		if (macKeyDown == true)
				{
					macKeyDown = false;
					
					Default.Namespace.MyTouch fakeTouch = new Default.Namespace.MyTouch();
					fakeTouch.phase = TouchPhase.Ended;
					fakeTouch.position.x = (Input.mousePosition.x / kScreenWidth) * xScreenWidth;
					fakeTouch.position.x += xScreenStartPixel;
					fakeTouch.position.y = 480.0f - ((Input.mousePosition.y / kScreenHeight) * 480.0f);
					fakeTouch.fingerId = 0;
					
					Default.Namespace.Globals.g_world.HandleTouchP1P2P3(fakeTouch);
				}
			}
		}
	}
}
