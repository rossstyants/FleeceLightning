using UnityEngine;
using System.Collections;



public enum SfxHandleFadeState{

	kFadeState_FadingIn,
	kFadeState_NotFading,
	kFadeState_FadingOut
};

public class SfxHandle {
	
	public bool isFree;
	public float fadeVolume;
	public SfxHandleFadeState fadeState;
	public int soundId;
	
	// Use this for initialization
	void Start() 
	{
	
	}
	
	// Update is called once per frame
	public bool Update ()
	{
		if (fadeState == SfxHandleFadeState.kFadeState_FadingIn)
		{
			if (fadeVolume < 1.0f)
			{
				fadeVolume += 0.02f;
				
				if (fadeVolume >= 1.0f)
				{
					fadeVolume = 1.0f;
					fadeState = SfxHandleFadeState.kFadeState_NotFading;
				}
			}
		}
		else if (fadeState == SfxHandleFadeState.kFadeState_FadingOut)
		{
			//Debug.Log ("fadeingOut...");
			
			if (fadeVolume > 0.0f)
			{
				fadeVolume -= 0.02f;
				
				if (fadeVolume <= 0.0f)
				{
					return true;
				}
			}
		}

		return false;
	}
}
