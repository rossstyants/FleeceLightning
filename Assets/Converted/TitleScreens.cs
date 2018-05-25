using UnityEngine;
using System.Collections;

public enum TitleScreenPhase{
		kFadingIn,
		kShowing,
		kFadingOut,
		kBetweenScreens,
	};

public enum TitleScreensEnum{
		kChillingoBanner,
		kGreenAnt,
	};

public class TitleScreens {	
	TitleScreensEnum currentScreen;
	TitleScreenPhase titleScreenPhase;
	float titlePhaseStart;
	float titlePhaseEnd;	
	public bool finished;
	
	public void StartApp () 
	{	
		titleScreenPhase = TitleScreenPhase.kFadingIn;
		//resourcesLoadedYet = false;
		titlePhaseStart = 0.0f;
		titlePhaseEnd = 0.28f;	
		
		titleScreenPhase = TitleScreenPhase.kShowing;
		//titlePhaseStart = loadingTimeSoFar;
		titlePhaseEnd = 0.0f + 3.0f;
		
		currentScreen = TitleScreensEnum.kChillingoBanner;
		finished = false;
	}
	
	public void Render () 
	{
		float loadingTimeSoFar = Default.Namespace.Globals.g_main.GetTimeSinceLoadingStarted();

		//Debug.Log ("loadingTimeSoFar = " + loadingTimeSoFar.ToString());		
		
		float ratio = 0.0f;
		const float kFadeSpeedForScreen = 0.28f;
		const float kTimeChillingoScreen = 3.0f;
		const float kTimeGreenAntScreen = 2.0f;
		const float kTimeBetweenScreens = 0.6f;		
		
		if (titleScreenPhase == TitleScreenPhase.kFadingIn)
		{
			ratio = Default.Namespace.Utilities.GetRatioP1P2((float)loadingTimeSoFar,(float)titlePhaseStart,(float)titlePhaseEnd);			

			if (ratio >= 1.0f)
			{
				titleScreenPhase = TitleScreenPhase.kShowing;
				titlePhaseStart = loadingTimeSoFar;
				titlePhaseEnd = loadingTimeSoFar + kTimeChillingoScreen;
			
				Debug.Log ("Set titleState to " + titleScreenPhase.ToString() + " with phaseStart " + titlePhaseStart.ToString() + " and phaseEnd " + titlePhaseEnd.ToString());
			}
		}
		else if (titleScreenPhase == TitleScreenPhase.kFadingOut)
		{
			ratio = 1.0f - Default.Namespace.Utilities.GetRatioP1P2((float)loadingTimeSoFar,(float)titlePhaseStart,(float)titlePhaseEnd);			

			if (ratio <= 0.0f)
			{
				titleScreenPhase = TitleScreenPhase.kBetweenScreens;
				titlePhaseStart = loadingTimeSoFar;
				titlePhaseEnd = loadingTimeSoFar + kTimeBetweenScreens;

				Debug.Log ("Set titleState to " + titleScreenPhase.ToString() + " with phaseStart " + titlePhaseStart.ToString() + " and phaseEnd " + titlePhaseEnd.ToString());
			}					
		}
		else if (titleScreenPhase == TitleScreenPhase.kBetweenScreens)
		{
			ratio = 0.0f;
			
			if (loadingTimeSoFar >= titlePhaseEnd)
			{
				if (currentScreen == TitleScreensEnum.kChillingoBanner)
				{
					titleScreenPhase = TitleScreenPhase.kFadingIn;
					titlePhaseStart = loadingTimeSoFar;
					titlePhaseEnd = loadingTimeSoFar + kFadeSpeedForScreen;
					currentScreen = TitleScreensEnum.kGreenAnt;
	
					Debug.Log ("Set titleState to " + titleScreenPhase.ToString() + " with phaseStart " + titlePhaseStart.ToString() + " and phaseEnd " + titlePhaseEnd.ToString());
				}
				else
				{
					finished = true;
				}
			}			
		}
		else if (titleScreenPhase == TitleScreenPhase.kShowing)
		{
			ratio = 1.0f;
			
			bool loadDone = true;
			
			if (currentScreen == TitleScreensEnum.kChillingoBanner)
			{
				loadDone = Default.Namespace.Globals.g_main.loadDone;
			}
			
			if ((loadingTimeSoFar >= titlePhaseEnd) && (loadDone))
			{
				if (currentScreen == TitleScreensEnum.kChillingoBanner)
				{	
					titleScreenPhase = TitleScreenPhase.kFadingOut;
					titlePhaseStart = loadingTimeSoFar;
					titlePhaseEnd = loadingTimeSoFar + kFadeSpeedForScreen;
	
					Debug.Log ("Set titleState to " + titleScreenPhase.ToString() + " with phaseStart " + titlePhaseStart.ToString() + " and phaseEnd " + titlePhaseEnd.ToString());			
				}
				else
				{
					finished = true;
				}
			}			
		}
		else
		{
			Default.Namespace.Globals.Assert(false);
		}

		switch(currentScreen)
		{
		case TitleScreensEnum.kChillingoBanner:
			this.RenderChillingoScreen(ratio);
			break;
		case TitleScreensEnum.kGreenAnt:
			this.RenderGreenAntScreen(ratio);
			break;
		
		}				

//	this.RenderChillingoScreen(1.0f);
	}
	
	
	public bool IsReadyToLoad()
	{
		if (currentScreen == TitleScreensEnum.kChillingoBanner)
		{
			if (titleScreenPhase >= TitleScreenPhase.kShowing)
			{
				float loadingTimeSoFar = Default.Namespace.Globals.g_main.GetTimeSinceLoadingStarted();
		
				if (loadingTimeSoFar >= (titlePhaseStart + 1.2f))
					return true;
			}
		}
		else
			return true;
		
		return false;
	}
	
	void RenderChillingoScreen(float ratio)
	{
            Default.Namespace.CGRect chillRect = new Default.Namespace.CGRect();
			
			float scaleMultiplier;
			
			if (Default.Namespace.Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_Low)
				scaleMultiplier = 320.0f / Screen.width;
			else
				scaleMultiplier = 1024.0f / Screen.height;

			chillRect.Size.Width = Screen.width * scaleMultiplier;
			chillRect.Size.Height = chillRect.Size.Width * 2.0f;// * scaleMultiplier;


//				col.a = ratio;
				Default.Namespace.Globals.g_main.chillingoBoard.alpha = ratio;

//				Default.Namespace.Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo].SetAlphaWithColour(ratio);
	}
	void RenderGreenAntScreen(float ratio)
	{
        Default.Namespace.CGRect bounds = Default.Namespace.UIScreen.bounds;
		
				//crikey this is nuts.

				if (Default.Namespace.Globals.g_world.screenWidth > bounds.Size.Width)
				{
						float scaleM = Default.Namespace.Globals.g_world.screenWidth / bounds.Size.Width;
						bounds.Size.Width *= scaleM;
						bounds.Size.Height *= scaleM;
				}
						
				Default.Namespace.Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash].RenderInRect(bounds, ratio);
//				Default.Namespace.Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash].RenderAtPosition(bounds, ratio);
	}
}
