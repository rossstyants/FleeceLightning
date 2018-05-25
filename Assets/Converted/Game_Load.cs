using UnityEngine;
using System.Collections;

namespace Default.Namespace
{
public partial class Game 
{

	//Game_Load
	
	
    public void LoadOtherPlayer(PlayerType inType)
    {
        if (currentlyLoadedPlayer != (int)inType) {
            if (currentlyLoadedPlayer != -1) {
            }

            currentlyLoadedPlayer = (int)inType;
        }

    }

		
    public void SetupTextureBillboard(int gameTextureId, string inDescription)
    {
			if (textureObjectBillboard[gameTextureId] == null)
			{
				textureObjectBillboard[gameTextureId] = new Billboard(inDescription);
			}
			textureObjectBillboard[gameTextureId].SetTexture2D(textureObject[gameTextureId]);
	}		
		
    public void LoadStartupTextures()
    {
        this.LoadSceneSpecificTextures(0);
        if (textureObject[(int) TextureType.kTextureSplashTitlePic] == null) 
		{

								if (Globals.useIPadBackScreens || Globals.deviceIPhone5)
						            textureObject[(int) TextureType.kTextureSplashTitlePic] = Globals.g_world.LoadTextureP1P2(false, "TitlePic_iPad.png", Texture2D_RossPixelFormat.t_RGB565,(int)TextureType.kTextureSplashTitlePic,LoadADCQueue.AssetType.kTextureGame);			
								else
									textureObject[(int) TextureType.kTextureSplashTitlePic] = Globals.g_world.LoadTextureP1P2(false, "TitlePic.png", Texture2D_RossPixelFormat.t_RGB565,(int)TextureType.kTextureSplashTitlePic,LoadADCQueue.AssetType.kTextureGame);			

			this.SetupTextureBillboard((int) TextureType.kTextureSplashTitlePic,"splashtitlething");
				
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) 
			{
                textureObject[(int) TextureType.kTextureSplashTitleSTSChinJap] = Globals.g_world.LoadTextureP1P2(false, "STSChin.png", Texture2D_RossPixelFormat.
                  t_RGBA8888,(int)TextureType.kTextureSplashTitleSTSChinJap,LoadADCQueue.AssetType.kTextureGame);

			this.SetupTextureBillboard((int) TextureType.kTextureSplashTitleSTSChinJap,"STSChin");
				
				}
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                textureObject[(int) TextureType.kTextureSplashTitleSTSChinJap] = Globals.g_world.LoadTextureP1P2(false, "STSJap.png", Texture2D_RossPixelFormat.
                  t_RGBA8888,(int)TextureType.kTextureSplashTitleSTSChinJap,LoadADCQueue.AssetType.kTextureGame);

			this.SetupTextureBillboard((int) TextureType.kTextureSplashTitleSTSChinJap,"STSJap");				
				}

        }

        textureObject[(int) TextureType.kTextureDimOverlay] = Globals.g_world.LoadTextureP1(true, "dimOverlay.png",(int)TextureType.kTextureDimOverlay,LoadADCQueue.AssetType.kTextureGame);
    }

    public void LoadShowLevelAndTip()
    {
        if (textureObject[(int) TextureType.kTexture_FullScreen_ShaunRunning] == null) {
								if (Globals.useIPadBackScreens) {
                textureObject[(int) TextureType.kTexture_FullScreen_ShaunRunning] = Globals.g_world.LoadTextureP1P2(true, "ShaunRunning_iPad.png", 
                  Texture2D_RossPixelFormat.t_RGB565,(int)TextureType.kTexture_FullScreen_ShaunRunning,LoadADCQueue.AssetType.kTextureGame);
            }
            else {
										if (Globals.useIPadBackScreens) {
                    textureObject[(int) TextureType.kTexture_FullScreen_ShaunRunning] = Globals.g_world.LoadTextureP1P2(true, "ShaunRunning_iPad.png",
                      Texture2D_RossPixelFormat.t_RGB565,(int)TextureType.kTexture_FullScreen_ShaunRunning,LoadADCQueue.AssetType.kTextureGame);
                }
                else {
                    textureObject[(int) TextureType.kTexture_FullScreen_ShaunRunning] = Globals.g_world.LoadTextureP1P2(true, "ShaunRunning.png", 
                      Texture2D_RossPixelFormat.t_RGB565,(int)TextureType.kTexture_FullScreen_ShaunRunning,LoadADCQueue.AssetType.kTextureGame);
                }

            }

        }

        Globals.g_world.LoadShowLevelAtlases();
    }

    public void LoadStarCupStar()
    {
    }

    public void CheckAndReleaseStarCupTexture()
    {
        if (textureObject[(int) TextureType.kTexture_StarCupStar] != null) {
           // textureObject[(int) TextureType.kTexture_StarCupStar];
            textureObject[(int) TextureType.kTexture_StarCupStar] = null;
        }

    }

    public void LoadFrontEndTextures()
    {
        Globals.Assert(textureObject[(int) TextureType.kTexture_HowToThumbs] == null);
        if (Globals.deviceIPad) {
            textureObject[(int) TextureType.kTexture_HowToThumbs] = Globals.g_world.LoadTextureP1P2(true, "HowToThumbs.png", Texture2D_RossPixelFormat.t_RGBA8888,(int)TextureType.kTexture_HowToThumbs,LoadADCQueue.AssetType.kTextureGame);
        }
        else if ( Globals.useRetina) {//(UIScreen.MainScreen()).RespondsToSelector(@selector (scale)) == true && (UIScreen.MainScreen()).scale == 2.00) {
            textureObject[(int) TextureType.kTexture_HowToThumbs] = Globals.g_world.LoadTextureP1P2(true, "HowToThumbs.png", Texture2D_RossPixelFormat.t_RGBA8888,(int)TextureType.kTexture_HowToThumbs,LoadADCQueue.AssetType.kTextureGame);
        }
        else {
            textureObject[(int) TextureType.kTexture_HowToThumbs] = Globals.g_world.LoadTextureP1(true, "HowToThumbs.png",(int)TextureType.kTexture_HowToThumbs,LoadADCQueue.AssetType.kTextureGame);
        }

        if (textureObject[(int) TextureType.kTexture_TiltTooHigh] == null) {
        }

        if (textureObject[(int) TextureType.kTextureApple] == null) {
            textureObject[(int) TextureType.kTextureApple] = Globals.g_world.LoadTextureP1(true, "apple.png",(int)TextureType.kTextureApple,LoadADCQueue.AssetType.kTextureGame);
        }

        if (textureObject[(int) TextureType.kTexture_SheepyHead] == null) {
        }

        if (textureObject[(int) TextureType.kTexture_LB_TrashCan] == null) {
            textureObject[(int) TextureType.kTexture_LB_TrashCan] = Globals.g_world.LoadTextureP1(true, "LB_trashcan.png",(int)TextureType.kTexture_LB_TrashCan,LoadADCQueue.AssetType.kTextureGame);
        }

        if (textureObject[(int) TextureType.kTexture_LB_Done] == null) {
            textureObject[(int) TextureType.kTexture_LB_Done] = Globals.g_world.LoadTextureP1(true, "LB_Done.png",(int)TextureType.kTexture_LB_Done,LoadADCQueue.AssetType.kTextureGame);
        }

    }

    public void ReleaseTexture(int texId)
    {
        Globals.Assert(textureObject[texId] != null);
       // textureObject[texId];
        textureObject[texId] = null;
    }

    public void ReleaseFrontEndTextures()
    {
        this.ReleaseTexture((int) TextureType.kTexture_HowToThumbs);
    }

    public void DropMenuAssetsPreGame()
    {
        Globals.g_world.ReleaseShowLevelAtlases();
        if (textureObject[(int) TextureType.kTextureTitlePic] != null) {
         //   textureObject[(int) TextureType.kTextureTitlePic];
            textureObject[(int) TextureType.kTextureTitlePic] = null;
            currentlyLoadedScene = -1;
        }

    }

    public void LoadSceneSpecificTextureP1P2P3P4P5P6P7P8(int whichScene, int textureId, string countryName, string farmName, string desertName, string iceName, string
      moonName, bool isStretchable, Texture2D_RossPixelFormat inType)
    {
        if (textureObject[textureId] != null) {
            textureObject[textureId] = null;
        }

        if (whichScene == (int) SceneType.kSceneGrass) {
            textureObject[textureId] = Globals.g_world.LoadTextureP1P2(isStretchable, countryName, inType,(int) TextureType.kTexture_WarmOverlay,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (whichScene == (int) SceneType.kSceneMud) {
            textureObject[textureId] = Globals.g_world.LoadTextureP1P2(isStretchable, farmName, inType,(int) TextureType.kTexture_WarmOverlay,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (whichScene == (int) SceneType.kSceneDesert) {
            textureObject[textureId] = Globals.g_world.LoadTextureP1P2(isStretchable, desertName, inType,(int) TextureType.kTexture_WarmOverlay,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (whichScene == (int) SceneType.kSceneIce) {
            textureObject[textureId] = Globals.g_world.LoadTextureP1P2(isStretchable, iceName, inType,(int) TextureType.kTexture_WarmOverlay,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (whichScene == (int) SceneType.kSceneMoon) {
            textureObject[textureId] = Globals.g_world.LoadTextureP1P2(isStretchable, moonName, inType,(int) TextureType.kTexture_WarmOverlay,LoadADCQueue.AssetType.kTextureGame);
        }
        else {
            Globals.Assert(false);
        }

    }

/*    public void LoadOpponentSpecificTextureP1P2P3P4P5P6(int whichOpponent, int textureId, string pigName, string penName, string ostName, bool isStretchable,
      Texture2D_RossPixelFormat inType)
    {
        if (textureObject[textureId] != null) {
            textureObject[textureId] = null;
        }

        if (whichOpponent == (int) PlayerType.kPlayerPig) {
            textureObject[textureId] = Globals.g_world.LoadTextureP1P2(isStretchable, pigName, inType);
        }
        else if (whichOpponent == (int) PlayerType.kPlayerPenguin) {
            textureObject[textureId] = Globals.g_world.LoadTextureP1P2(isStretchable, penName, inType);
        }
        else if (whichOpponent == (int) PlayerType.kPlayerOstrich) {
            textureObject[textureId] = Globals.g_world.LoadTextureP1P2(isStretchable, ostName, inType);
        }
        else {
            Globals.Assert(false);
        }

    }*/

    public void LoadCommonGameOnlyTextures()
    {
    }

    public void ReleaseCommonGameOnlyTextures()
    {
    }

    public void LoadSceneSpecificTextures(int whichScene)
    {
        if (currentlyLoadedScene != whichScene) {
            if (currentlyLoadedScene != -1) {
            }

            this.LoadSceneSpecificTextureP1P2P3P4P5P6P7P8(whichScene, (int) TextureType.kTexture_WarmOverlay, "WarmGlowOverlay.png", "WarmGlowOverlay.png",
              "WarmGlowOverlay.png", "WarmGlowOverlay.png", "WarmGlowOverlay.png", true, Texture2D_RossPixelFormat.t_RGBA8888);
            currentlyLoadedScene = whichScene;
				
			this.SetupTextureBillboard((int) TextureType.kTexture_WarmOverlay,"WarmGlowOverlay");
				
			textureObjectBillboard[(int) TextureType.kTexture_WarmOverlay].myObject.layer = LayerMask.NameToLayer("guistuff");
        }

    }

    public void LoadOpponentSpecificTextures(int whichOpponent)
    {
    }

    public void LoadSpeedBoostTextures()
    {
/*        Globals.Assert(textureObject[(int) TextureType.kTextureTurnip] == null);
        SpeedUpProgressEnum speedUp = ((Globals.g_world.frontEnd).profile).speedUpProgress;
        if (speedUp == SpeedUpProgressEnum.kSpeedUp_FirstSpeedBoost) {
            textureObject[(int) TextureType.kTextureTurnip] = Globals.g_world.LoadTextureP1(true, "Turnip24.png",(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
            textureObject[(int) TextureType.kTextureTurnipSheep] = Globals.g_world.LoadTextureP1P2(true, "TurnipSheep24.png", Texture2D_RossPixelFormat.t_RGBA8888,(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (speedUp == SpeedUpProgressEnum.kSpeedUp_SecondSpeedBoost) {
            textureObject[(int) TextureType.kTextureTurnip] = Globals.g_world.LoadTextureP1(true, "item_scissors.png",(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
            textureObject[(int) TextureType.kTextureTurnipSheep] = Globals.g_world.LoadTextureP1P2(true, "sheep_wool24.png", Texture2D_RossPixelFormat.t_RGBA8888,(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (speedUp == SpeedUpProgressEnum.kSpeedUp_ThirdSpeedBoost) {
            textureObject[(int) TextureType.kTextureTurnip] = Globals.g_world.LoadTextureP1(true, "item_cattleprod.png",(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
            textureObject[(int) TextureType.kTextureTurnipSheep] = Globals.g_world.LoadTextureP1P2(true, "sheep_electricitypng24.png", Texture2D_RossPixelFormat.
              t_RGBA8888,(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
        }

        textureObject[(int) TextureType.kTextureTurnipSheepShadow] = Globals.g_world.LoadTextureP1(true, "runFastShadow24.png",(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
   */ }

    public void LoadFeelGoodTextures()
    {
        if (textureObject[(int) TextureType.kTexture_FullScreen_ShaunClose] == null) {
								if (Globals.useIPadBackScreens) 
								{
                textureObject[(int) TextureType.kTexture_FullScreen_ShaunClose] = Globals.g_world.LoadTextureP1P2(true, "Congrats_iPad.png", Texture2D_RossPixelFormat
                  .t_RGBA8888,(int)TextureType.kTexture_FullScreen_ShaunClose,LoadADCQueue.AssetType.kTextureGame);
            }
            else {
                    textureObject[(int) TextureType.kTexture_FullScreen_ShaunClose] = Globals.g_world.LoadTextureP1P2(true, "Congrats.png", Texture2D_RossPixelFormat.
                      t_RGBA8888,(int)TextureType.kTexture_FullScreen_ShaunClose,LoadADCQueue.AssetType.kTextureGame);

            }

        }

        Globals.g_world.LoadFeelGoodAtlas();
    }

    public void ReleaseFeelGoodTextures()
    {
        if (textureObject[(int) TextureType.kTexture_FullScreen_ShaunClose] != null) {
          //  textureObject[(int) TextureType.kTexture_FullScreen_ShaunClose];
            textureObject[(int) TextureType.kTexture_FullScreen_ShaunClose] = null;
        }
			
			//because we want the longName button for the Query-dropdown butts
//        Globals.g_world.ReleaseFeelGoodAtlas();
    }

    public void LoadAnotherPiggyTextures()
    {
        Globals.Assert(textureObject[(int) TextureType.kTextureTurnipSheep] == null);
        if ((hud.anotherPiggyScreen).type == AnotherPiggyType.kAP_AnotherPiggy) {
            Globals.g_world.LoadAnotherPiggyAtlases();
        }
        else if ((hud.anotherPiggyScreen).type == AnotherPiggyType.kAP_PreFeelGoodWords) 
			{
            if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress <= (int)Profile.Enum5.kFeelGoodProgress_WelcomeToStarCup) {
            }
            else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress == (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainDesert) {
            }
            else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress == (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainIce) {
            }
            else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress == (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainMoon) {
            }
            else {
            }

        }
        else if ((hud.anotherPiggyScreen).type == AnotherPiggyType.kAP_RaceTip) {
        }
        else {
            Globals.Assert(false);
        }

    }

    public void FreeTitleTextures()
    {
        textureObject[(int) TextureType.kTextureSplashTitlePic] = null;
        if (Globals.useRetina) 
			{
            textureObject[(int) TextureType.kTextureSplashTitlePlaque] = null;
        }

        if (textureObject[(int) TextureType.kTextureSplashTitleSTSChinJap] != null) 
		{
            textureObject[(int) TextureType.kTextureSplashTitleSTSChinJap] = null;
        }

    }

    public void ReleaseSpeedBoostTextures()
    {
        if (textureObject[(int) TextureType.kTextureTurnip] != null) {
            textureObject[(int) TextureType.kTextureTurnip]= null;
            textureObject[(int) TextureType.kTextureTurnipSheep]= null;
            textureObject[(int) TextureType.kTextureTurnipSheepShadow]= null;
            textureObject[(int) TextureType.kTextureTurnip] = null;
            textureObject[(int) TextureType.kTextureTurnipSheep] = null;
        }

    }

    public void ReleaseAnotherPiggyTextures()
    {
        Globals.g_world.ReleaseAnotherPiggyAtlases();
        if (textureObject[(int) TextureType.kTextureTurnipSheep] != null) {
//            textureObject[(int) TextureType.kTextureTurnipSheep];
            textureObject[(int) TextureType.kTextureTurnipSheep] = null;
        }

        if (textureObject[(int) TextureType.kTextureBubbleRing] != null) {
  //          textureObject[(int) TextureType.kTextureBubbleRing];
            textureObject[(int) TextureType.kTextureBubbleRing] = null;
        }

        if (textureObject[(int) TextureType.kTextureBubbleRingBehind] != null) {
    //        textureObject[(int) TextureType.kTextureBubbleRingBehind];
            textureObject[(int) TextureType.kTextureBubbleRingBehind] = null;
        }

    }

    public void LoadAppleCartTextures()
    {
/*        Globals.Assert(textureObject[(int) TextureType.kTextureAppleCartRabbit] == null);
        textureObject[(int) TextureType.kTextureAppleCartRabbit] = Globals.g_world.LoadTextureP1(true, "rabbit.png",(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
        textureObject[(int) TextureType.kTextureAppleCartBottom] = Globals.g_world.LoadTextureP1(true, "cartbott.png",(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
        textureObject[(int) TextureType.kTextureAppleCartTop] = Globals.g_world.LoadTextureP1(true, "carttop.png",(int)Enum.NNNNNNN,LoadADCQueue.AssetType.kTextureGame);
  */  }

    public void ReleaseAppleCartTextures()
    {
/*        Globals.Assert(textureObject[(int) TextureType.kTextureAppleCartRabbit] != null);
        textureObject[(int) TextureType.kTextureAppleCartRabbit]= null;
        textureObject[(int) TextureType.kTextureAppleCartBottom]= null;
        textureObject[(int) TextureType.kTextureAppleCartTop]= null;
        textureObject[(int) TextureType.kTextureAppleCartRabbit] = null;
  */  }

    public void LoadLevelBuilder_RossTextures()
    {
        Globals.Assert(textureObject[(int) TextureType.kTexture_LB_CopyButton] == null);
        if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
								textureObject[(int) TextureType.kTexture_LB_CopyButton] = Globals.g_world.LoadTextureP1(true, "LB_Copy_German11.png",(int)(int)TextureType.kTexture_LB_CopyButton,LoadADCQueue.AssetType.kTextureGame);
								textureObject[(int) TextureType.kTexture_LB_MoveButton] = Globals.g_world.LoadTextureP1(true, "LB_Copy_German12.png",(int)TextureType.kTexture_LB_MoveButton,LoadADCQueue.AssetType.kTextureGame);
        }
        else if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese)) {
								textureObject[(int) TextureType.kTexture_LB_CopyButton] = Globals.g_world.LoadTextureP1(true, "LB_Copy_China1.png",(int)TextureType.kTexture_LB_CopyButton,LoadADCQueue.AssetType.kTextureGame);
								textureObject[(int) TextureType.kTexture_LB_MoveButton] = Globals.g_world.LoadTextureP1(true, "LB_Copy_China2.png",(int)TextureType.kTexture_LB_MoveButton,LoadADCQueue.AssetType.kTextureGame);
        }
        else {
								textureObject[(int) TextureType.kTexture_LB_CopyButton] = Globals.g_world.LoadTextureP1(true, "LB_Copy.png",(int)TextureType.kTexture_LB_CopyButton,LoadADCQueue.AssetType.kTextureGame);
        }

						textureObject[(int) TextureType.kTexture_LB_DeleteAll] = Globals.g_world.LoadTextureP1(true, "LB_clearAll.png",(int)TextureType.kTexture_LB_DeleteAll,LoadADCQueue.AssetType.kTextureGame);
        if (Globals.deviceIPad) {
								textureObject[(int) TextureType.kTexture_LB_Back] = Globals.g_world.LoadTextureP1(true, "LevelBuilderBack_iPad.png",(int)TextureType.kTexture_LB_Back,LoadADCQueue.AssetType.kTextureGame);
        }
        else {
								textureObject[(int) TextureType.kTexture_LB_Back] = Globals.g_world.LoadTextureP1(true, "LevelBuilderBack.png",(int)TextureType.kTexture_LB_Back,LoadADCQueue.AssetType.kTextureGame);
        }

						textureObject[(int) TextureType.kTexture_LB_Left] = Globals.g_world.LoadTextureP1(true, "LB_Left.png",(int)TextureType.kTexture_LB_Left,LoadADCQueue.AssetType.kTextureGame);
						textureObject[(int) TextureType.kTexture_LB_Right] = Globals.g_world.LoadTextureP1(true, "LB_Right.png",(int)TextureType.kTexture_LB_Right,LoadADCQueue.AssetType.kTextureGame);
    }

    public void ReleaseLevelBuilder_RossTextures()
    {
        Globals.Assert(textureObject[(int) TextureType.kTexture_LB_CopyButton] != null);
        textureObject[(int) TextureType.kTexture_LB_Left]= null;
        textureObject[(int) TextureType.kTexture_LB_Right]= null;
        textureObject[(int) TextureType.kTexture_LB_Back]= null;
        textureObject[(int) TextureType.kTexture_LB_CopyButton]= null;
        textureObject[(int) TextureType.kTexture_LB_DeleteAll]= null;
        textureObject[(int) TextureType.kTexture_LB_CopyButton] = null;
        if (textureObject[(int) TextureType.kTexture_LB_MoveButton] != null) {
//            textureObject[(int) TextureType.kTexture_LB_MoveButton];
            textureObject[(int) TextureType.kTexture_LB_MoveButton] = null;
        }

    }

    public void LoadTextures()
    {

        #if PROFILING_OUT
//            textureObject[(int) TextureType.kTexture_PinkBox] = Globals.g_world.LoadTextureP1(true, "ButtonBack.png");
        #endif

        Globals.g_main.RenderLoadingBar();
        Globals.g_main.RenderLoadingBar();

        #if CHILLINGO_DEMO
            textureObject[(int) TextureType.kChillDemo] = Globals.g_world.LoadTextureP1(false, "ChillDemo.png");
        #endif

        Globals.g_main.RenderLoadingBar();
        Globals.g_main.RenderLoadingBar();
        Globals.g_main.RenderLoadingBar();
        textureObject[(int) TextureType.kTexture_Whiteout] = Globals.g_world.LoadTextureP1(true, "Whiteout.png",(int)TextureType.kTexture_Whiteout,LoadADCQueue.AssetType.kTextureGame);
        Globals.g_main.RenderLoadingBar();
        for (int i = 0; i < 13; i++) {
        }

        for (int i = 0; i < 7; i++) {
        }

        Globals.g_main.RenderLoadingBar();
        if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
            textureObject[(int) TextureType.kTexture_HudLoading] = Globals.g_world.LoadTextureP1(true, "loadingword_German.png",(int)TextureType.kTexture_HudLoading,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
            textureObject[(int) TextureType.kTexture_HudLoading] = Globals.g_world.LoadTextureP1(true, "loadingword_Chinese.png",(int)TextureType.kTexture_HudLoading,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
            textureObject[(int) TextureType.kTexture_HudLoading] = Globals.g_world.LoadTextureP1(true, "loadingword_French.png",(int)TextureType.kTexture_HudLoading,LoadADCQueue.AssetType.kTextureGame);
        }
        else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
            textureObject[(int) TextureType.kTexture_HudLoading] = Globals.g_world.LoadTextureP1(true, "loadingword_Japanese.png",(int)TextureType.kTexture_HudLoading,LoadADCQueue.AssetType.kTextureGame);
        }
        else {
            textureObject[(int) TextureType.kTexture_HudLoading] = Globals.g_world.LoadTextureP1(true, "loadingword.png",(int)TextureType.kTexture_HudLoading,LoadADCQueue.AssetType.kTextureGame);
        }
			
		this.SetupTextureBillboard((int) TextureType.kTexture_HudLoading,"loadingword");
			
		textureObjectBillboard[(int) TextureType.kTexture_HudLoading].width = 250.0f;		
		textureObjectBillboard[(int) TextureType.kTexture_HudLoading].height = 50.0f;		
		textureObject[(int) TextureType.kTexture_HudLoading].pixelsWide = 250;	
		textureObject[(int) TextureType.kTexture_HudLoading].pixelsHigh = 50;	
			
        Globals.g_main.RenderLoadingBar();

        #if HAND_DANGLE
        #endif

        Globals.g_main.RenderLoadingBar();
        //CrashLandingAppDelegate.Print_free_memory();
    }
		
	//Game_PiggySpeeds
		
	public void SetupDesiredTrackTimes()
    {
        for (int i = 0; i < 600; i++) {
            speedAdjustmentTool.desiredTime[i] = -1.0f;
        }

        if (cameraFollowWhichPiggy == 0) {
            this.SetupDesiredTrackTimes_Pig0();
        }
        else if (cameraFollowWhichPiggy == 1) {
            this.SetupDesiredTrackTimes_Pig1();
        }
        else if (cameraFollowWhichPiggy == 2) {
            this.SetupDesiredTrackTimes_Pig2();
        }
        else {
            Globals.Assert(false);
        }

    }

    public void SetupDesiredTrackTimes_Pig2()
    {
    }

    public void SetupDesiredTrackTimes_Pig1()
    {
    }

    public void SetupDesiredTrackTimes_Pig0()
    {
        speedAdjustmentTool.desiredTime[(int)LevelBuilder_Ross.Enum2.kMud5_4_FrmCup_Race4_AlleyHogs] = 31.3f;
    }

    public void UsePiggySpeedAdjustmentToolP1(float pigSpeed, int track)
    {
        if (speedAdjustmentTool.whichRunForThisTrack == 0) {
            speedAdjustmentTool.lastTrySpeed[track] = pigSpeed;
            return;
        }

        if (speedAdjustmentTool.lastTryTime[track] < 0.0f) {
            return;
        }

        float timeDiff = (speedAdjustmentTool.lastTryTime[track] - speedAdjustmentTool.desiredTime[track]);
        float speedChange;
        speedChange = 0.66f * timeDiff;
        speedAdjustmentTool.lastTrySpeed[track] += speedChange;
    }

    public void PrintoutSpeeds()
    {
        int whichCup = 1;
        for (int i = 0; i < playingLevel + 1; i++) {
            if (i % 8 == 0) {
                whichCup++;
            }

            int realLevel = LevelBuilder_Ross.levelOrder[i];
            if (speedAdjustmentTool.lastTryTime[realLevel] > 0.0f) {
            }

        }

    }

    public void SendResultsToPiggySpeedAdjustmentToolP1P2(float pigTime, int track, bool pigStuck)
    {
        float timeDiff = (pigTime - speedAdjustmentTool.desiredTime[track]);
        if (speedAdjustmentTool.desiredTime[track] < 0.0f) {
            speedAdjustmentTool.whichRunForThisTrack = -1;
            return;
        }

        if (Utilities.GetABS(timeDiff) <= Constants.PIGGY_SPEED_ADJUSTMENT_TOOL_HONING_VALUE) {
            speedAdjustmentTool.lastTryTime[track] = pigTime;
            this.PrintoutSpeeds();
            speedAdjustmentTool.whichRunForThisTrack = -1;
            return;
        }

        speedAdjustmentTool.lastTryTime[track] = pigTime;
        speedAdjustmentTool.whichRunForThisTrack++;
        if (Utilities.GetABS(timeDiff) < speedAdjustmentTool.closestTimeDiffForThisTrack) {
            speedAdjustmentTool.closestTimeDiffForThisTrack = Utilities.GetABS(timeDiff);
            speedAdjustmentTool.closestTimeDiffForThisTrack_SpeedUsed = speedAdjustmentTool.lastTrySpeed[track];
            speedAdjustmentTool.closestTimeDiffForThisTrack_TimeGot = speedAdjustmentTool.lastTryTime[track];
        }

        if (speedAdjustmentTool.whichRunForThisTrack >= 10) {
            speedAdjustmentTool.lastTryTime[track] = speedAdjustmentTool.closestTimeDiffForThisTrack_TimeGot;
            speedAdjustmentTool.lastTrySpeed[track] = speedAdjustmentTool.closestTimeDiffForThisTrack_SpeedUsed;
            this.PrintoutSpeeds();
            speedAdjustmentTool.whichRunForThisTrack = -1;
            return;
        }

    }

    public void SetupPiggySpeeds()
    {
        ((playerPiggy[0]).racingBrain).SetSpeedOutOfBlocks(0.073f);
        ((playerPiggy[1]).racingBrain).SetSpeedOutOfBlocks(0.07f);
        ((playerPiggy[2]).racingBrain).SetSpeedOutOfBlocks(0.066f);
        int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
        float kSlowestPiggyMultiplier = 10.0f;
        float kMiddlePiggyMultiplier = 10.3f;
        float kFastestPiggyMultiplier = 11.55f;
        ((playerPiggy[0]).racingBrain).SetBaseSpeed(kFastestPiggyMultiplier);
        ((playerPiggy[1]).racingBrain).SetBaseSpeed(kMiddlePiggyMultiplier);
        ((playerPiggy[2]).racingBrain).SetBaseSpeed(kSlowestPiggyMultiplier);
        ((playerPiggy[0]).racingBrain).SetBaseSpeedInFinalThird(10.8f);
        ((playerPiggy[1]).racingBrain).SetBaseSpeedInFinalThird(9.5f);
        ((playerPiggy[2]).racingBrain).SetBaseSpeedInFinalThird(9.2f);
        float[] pigspeed = new float[3]
        {-1.0f, -1.0f, -1.0f};
        float[] finalThird = new float[3]
        {-1.0f, -1.0f, -1.0f};
        float[] outOfBlocks = new float[3]
        {-1.0f, -1.0f, -1.0f};
        float[] catchUp = new float[3]
        {1.5f, 1.0f, 0.8f};
        float[] slowDown = new float[3]
        {2.9f, 1.9f, 1.65f};
        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne :
            pigspeed[0] = 9.0f;
            finalThird[0] = 8.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo :
            pigspeed[0] = 8.0f;
            finalThird[0] = 8.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass1_7_MdwCup_Race7_Bollards :
            pigspeed[0] = 9.462f;
            finalThird[0] = 9.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks :
            pigspeed[0] = 7.8f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail :
            pigspeed[0] = 8.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass_DuckpondDance :
            pigspeed[0] = 12.0f;
            finalThird[0] = 10.5f;
            pigspeed[1] = 11.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes :
            pigspeed[0] = 10.3f;
            pigspeed[1] = 10.3f;
            finalThird[1] = 9.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass1_8_MdwCup_Race8_CowField :
            pigspeed[0] = 14.0f;
            finalThird[0] = 10.6f;
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep :
            finalThird[0] = 9.15f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge :
            pigspeed[0] = 12.4f;
            outOfBlocks[0] = 0.08f;
            slowDown[0] = 3.0f;
            pigspeed[1] = 9.25f;
            finalThird[1] = 8.3f;
            catchUp[1] = 1.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips :
            finalThird[0] = 8.0f;
            finalThird[1] = 8.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud_EasyStables :
            pigspeed[1] = 10.2f;
            pigspeed[0] = 12.5f;
            finalThird[0] = 10.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers :
            pigspeed[2] = 9.0f;
            pigspeed[1] = 10.9f;
            pigspeed[0] = 12.5f;
            finalThird[0] = 8.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud_LongJumps :
            pigspeed[1] = 9.6f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud2_6_MudCup_Race6_Barny :
            pigspeed[0] = 11.8f;
            finalThird[0] = 10.8f;
            pigspeed[2] = 10.2f;
            finalThird[2] = 10.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud_MudVille :
            pigspeed[0] = 11.8f;
            finalThird[0] = 10.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines :
            pigspeed[2] = 9.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud_BarrelMaze :
            pigspeed[2] = 10.8f;
            finalThird[2] = 10.0f;
            pigspeed[0] = 10.8f;
            pigspeed[1] = 10.0f;
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly :
            pigspeed[0] = 10.0f;
            pigspeed[1] = 9.1f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass4_2_CntCup_Race2_LongBridge :
            pigspeed[0] = 11.05f;
            finalThird[0] = 9.1f;
            finalThird[1] = 8.1f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass4_4_CntCup_Race4_BT :
            pigspeed[0] = 9.5f;
            finalThird[2] = 8.8f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass4_7_CntCup_Race7_RP :
            pigspeed[0] = 11.2f;
            pigspeed[1] = 9.2f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass9_4_FourRivers :
            pigspeed[2] = 9.2f;
            finalThird[2] = 8.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass1_6_MdwCup_Race6_CattleRun :
            pigspeed[0] = 11.56f;
            pigspeed[1] = 10.0f;
            pigspeed[2] = 9.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass4_6_CntCup_Race6_ABridgeTooMoo :
            pigspeed[2] = 11.6f;
            finalThird[0] = 9.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass9_2_BigJump :
            pigspeed[0] = 8.5f;
            pigspeed[1] = 8.8f;
            pigspeed[2] = 10.2f;
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kMud8_5_PumpkinWiggle :
            pigspeed[0] = 10.65f;
            pigspeed[1] = 9.0f;
            pigspeed[2] = 8.8f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage :
            pigspeed[0] = 10.85f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud2_7_MudCup_Race7_BarrelsOfFun :
            pigspeed[0] = 10.5f;
            pigspeed[2] = 9.3f;
            finalThird[0] = 9.7f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles :
            pigspeed[0] = 9.5f;
            pigspeed[1] = 10.0f;
            pigspeed[2] = 9.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud2_4_MudCup_Race4_LongRoof :
            finalThird[0] = 9.0f;
            finalThird[2] = 9.4f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud8_1_PumpkinPatch :
            pigspeed[2] = 9.0f;
            pigspeed[0] = 10.3f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass9_3_BaleLines :
            pigspeed[0] = 10.5f;
            pigspeed[1] = 10.0f;
            pigspeed[2] = 9.0f;
            finalThird[0] = 9.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud10_3_PumpkinJumps :
            pigspeed[0] = 10.4f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud3_8_PenCup_Race8_Weave :
            finalThird[0] = 8.0f;
            finalThird[2] = 9.3f;
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kGrass9_5_Campyard :
            pigspeed[0] = 11.0f;
            pigspeed[2] = 9.7f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass4_5_CntCup_Race5_HOW :
            pigspeed[0] = 10.3f;
            pigspeed[1] = 10.2f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass4_8_CntCup_Race8_ABridgeTooBaa :
            finalThird[2] = 10.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrassN2_2_HayBaleGroove :
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrassN2_8_ThinTreeAve :
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass9_6_RandomMark :
            pigspeed[0] = 10.5f;
            pigspeed[1] = 10.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass9_7_Puddles :
            finalThird[0] = 9.8f;
            finalThird[2] = 9.8f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass_GnomeHome :
            pigspeed[0] = 11.2f;
            pigspeed[2] = 9.0f;
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kMud7_4_Junkyard :
            finalThird[0] = 9.4f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud5_1_FrmCup_Race1_BarnDance :
            pigspeed[0] = 10.0f;
            pigspeed[2] = 9.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud5_2_FrmCup_Race2_GetUp :
            pigspeed[0] = 10.5f;
            pigspeed[1] = 9.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud5_4_FrmCup_Race4_AlleyHogs :
            finalThird[0] = 10.15f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard :
            pigspeed[0] = 10.2f;
            pigspeed[1] = 9.3f;
            pigspeed[2] = 9.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud3_6_PenCup_Race6_PCurvy :
            pigspeed[0] = 11.0f;
            slowDown[0] = 4.0f;
            pigspeed[2] = 10.4f;
            finalThird[0] = 10.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud3_1_PenCup_Race1_IceHoles :
            finalThird[0] = 9.75f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud5_3_FrmCup_Race3_TractorFactor :
            finalThird[0] = 8.9f;
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kGrass7_7_Orchard :
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass8_7_BridgeJumps :
            pigspeed[0] = 10.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass7_6_Trampoline :
            pigspeed[0] = 10.5f;
            pigspeed[2] = 11.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrassN1_1_PuddlesChicane :
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrassN2_4_SideSideJumps :
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass6_6_StrCup_Race6_MazyD :
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow :
            pigspeed[0] = 12.5f;
            pigspeed[2] = 11.0f;
            finalThird[1] = 8.8f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrassN1_7_HayChicanes :
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kMud8_2_BarrelThing :
            pigspeed[0] = 11.0f;
            pigspeed[2] = 9.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud5_7_FrmCup_Race7_HumptyJumpty :
            pigspeed[0] = 10.0f;
            pigspeed[1] = 9.5f;
            pigspeed[2] = 9.0f;
            finalThird[2] = 7.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud5_8_FrmCup_Race8_Swineyard :
            pigspeed[0] = 10.8f;
            pigspeed[2] = 9.0f;
            slowDown[0] = 0.6f;
            slowDown[1] = 0.6f;
            slowDown[2] = 0.6f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud_TheWoods :
            pigspeed[0] = 10.5f;
            pigspeed[2] = 9.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud_ForestFlock :
            finalThird[2] = 10.1f;
            finalThird[0] = 10.9f;
            slowDown[0] = 4.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud10_2_MarrowField :
            finalThird[0] = 11.2f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud10_3_PumpkinJumps :
            pigspeed[0] = 10.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud8_8_MudCup_Race1_HayBaby :
            pigspeed[0] = 10.9f;
            pigspeed[2] = 9.3f;
            finalThird[1] = 10.4f;
            finalThird[0] = 9.1f;
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kGrass10_1_LotsOfSheep :
            pigspeed[0] = 10.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass9_8_Gardens :
            finalThird[0] = 13.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass_WideJumps :
            pigspeed[0] = 11.1f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrassN1_8_SquareHedgeShuffle :
            finalThird[0] = 10.4f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrassN2_3_RainbowRuns :
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass6_2_StrCup_Race2_Hogwash :
            pigspeed[0] = 10.8f;
            pigspeed[2] = 10.3f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass6_5_StrCup_Race5_scruba :
            pigspeed[0] = 10.5f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop :
            pigspeed[2] = 10.5f;
            finalThird[1] = 9.3f;
            break;
        }

        switch (realLevelId) {
        case (int)LevelBuilder_Ross.Enum2.kMud8_4_TulipChicane :
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud7_8_SquashDodge :
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud8_6_BlueTulips :
            slowDown[0] = 4.3f;
            slowDown[1] = 3.0f;
            finalThird[0] = 9.75f;
            catchUp[0] = 0.0f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud3_7_PenCup_Race7_Migration :
            finalThird[2] = 9.4f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville :
            finalThird[0] = 12.762f;
            break;
        case (int)LevelBuilder_Ross.Enum2.kMudN1_5_StarStables :
            break;
        case (int)LevelBuilder_Ross.Enum2.kMudN1_2_Chicanery :
            break;
        case (int)LevelBuilder_Ross.Enum2.kMudN2_6_Alleys :
            break;
        }

        for (int i = 0; i < 3; i++) {
            pigspeed[i] = this.ReadPigSpeedFromAdjustedDataP1P2(i, pigspeed[i], realLevelId);
        }

        #if PIGGY_SPEED_ADJUSTMENT_TOOL
            if (pigspeed[cameraFollowWhichPiggy] <= -1.0f) {
                pigspeed[cameraFollowWhichPiggy] = ((playerPiggy[cameraFollowWhichPiggy]).racingBrain).BaseSpeed();
            }

            this.UsePiggySpeedAdjustmentToolP1(pigspeed[cameraFollowWhichPiggy], realLevelId);
            pigspeed[cameraFollowWhichPiggy] = speedAdjustmentTool.lastTrySpeed[realLevelId];
        #endif

        for (int i = 0; i < 3; i++) {
            if (pigspeed[i] > -1.0f) {
                ((playerPiggy[i]).racingBrain).SetBaseSpeed(pigspeed[i]);
                if (finalThird[i] == -1.0f) {
                    ((playerPiggy[i]).racingBrain).SetBaseSpeedInFinalThird(pigspeed[i] * 0.9f);
                }

            }

            if (outOfBlocks[i] > -1.0f) {
                ((playerPiggy[i]).racingBrain).SetSpeedOutOfBlocks(outOfBlocks[i]);
            }

            if (finalThird[i] > -1.0f) {
                ((playerPiggy[i]).racingBrain).SetBaseSpeedInFinalThird(finalThird[i]);
            }

            ((playerPiggy[i]).racingBrain).SetMinAndMaxSpeedP1(-slowDown[i], catchUp[i]);
        }

    }

    float ReadPigSpeedFromAdjustedDataP1P2(int whichPig, float speedBefore, int realLevelId)
    {
        float[,] piggySpeed = new float[3, 600];
        for (int p = 0; p < 3; p++) {
            for (int i = 0; i < 600; i++) {
                piggySpeed[p, i] = 0.0f;
            }

        }

        piggySpeed[0, 402] = 12.000000f;
        piggySpeed[0, 214] = 12.0251f;
        piggySpeed[0, 6] = 10.014964f;
        piggySpeed[0, 503] = 11.167392f;
        piggySpeed[0, 0] = 10.5798f;
        piggySpeed[0, 512] = 10.9670f;
        piggySpeed[0, 303] = 11.0421f;
        piggySpeed[0, 212] = 10.9561f;
        piggySpeed[0, 305] = 10.9282f;
        piggySpeed[0, 408] = 11.0587f;
        piggySpeed[0, 502] = 10.2241f;
        piggySpeed[0, 523] = 11.0353f;
        piggySpeed[0, 300] = 10.3848f;
        piggySpeed[0, 212] = 12.335847f;
        piggySpeed[0, 408] = 10.966795f;
        piggySpeed[0, 523] = 10.428389f;
        piggySpeed[0, 505] = 12.0081f;
        piggySpeed[0, 17] = 9.6762f;
        piggySpeed[0, 1] = 11.0648f;
        piggySpeed[0, 22] = 11.9943f;
        piggySpeed[0, 3] = 12.0782f;
        piggySpeed[0, 506] = 9.9960f;
        piggySpeed[0, 507] = 9.9001f;
        piggySpeed[0, 500] = 14.3206f;
        piggySpeed[0, 17] = 10.468463f;
        piggySpeed[0, 3] = 11.576838f;
        piggySpeed[0, 500] = 13.555145f;
        piggySpeed[0, 403] = 11.9569f;
        piggySpeed[0, 102] = 9.7361f;
        piggySpeed[0, 119] = 9.9363f;
        piggySpeed[0, 100] = 10.2000f;
        piggySpeed[0, 118] = 10.1402f;
        piggySpeed[0, 307] = 11.3017f;
        piggySpeed[0, 306] = 11.1685f;
        piggySpeed[0, 112] = 10.7335f;
        piggySpeed[0, 508] = 9.1321f;
        piggySpeed[0, 514] = 11.1242f;
        piggySpeed[0, 405] = 10.6320f;
        piggySpeed[0, 520] = 11.5500f;
        piggySpeed[0, 11] = 11.0820f;
        piggySpeed[0, 14] = 11.5500f;
        piggySpeed[0, 4] = 12.6813f;
        piggySpeed[0, 18] = 11.8502f;
        piggySpeed[0, 514] = 9.778394f;
        piggySpeed[0, 520] = 11.061766f;
        piggySpeed[0, 11] = 9.590579f;
        piggySpeed[0, 14] = 9.570317f;
        piggySpeed[0, 409] = 8.7805f;
        piggySpeed[0, 108] = 10.6126f;
        piggySpeed[0, 116] = 10.8000f;
        piggySpeed[0, 302] = 10.7406f;
        piggySpeed[0, 304] = 11.5500f;
        piggySpeed[0, 517] = 13.7347f;
        piggySpeed[0, 518] = 8.6403f;
        piggySpeed[0, 215] = 10.1803f;
        piggySpeed[0, 304] = 12.711937f;
        piggySpeed[0, 215] = 10.035956f;
        piggySpeed[0, 516] = 10.4885f;
        piggySpeed[0, 510] = 12.5463f;
        piggySpeed[0, 9] = 15.3545f;
        piggySpeed[0, 20] = 10.6984f;
        piggySpeed[0, 10] = 11.5500f;
        piggySpeed[0, 8] = 11.2094f;
        piggySpeed[0, 7] = 13.2622f;
        piggySpeed[0, 5] = 14.4676f;
        piggySpeed[0, 510] = 11.635679f;
        piggySpeed[0, 20] = 10.764643f;
        piggySpeed[0, 8] = 11.119043f;
        piggySpeed[0, 411] = 11.7061f;
        piggySpeed[0, 509] = 13.0635f;
        piggySpeed[0, 513] = 12.3312f;
        piggySpeed[0, 301] = 11.5500f;
        piggySpeed[0, 107] = 10.9322f;
        piggySpeed[0, 123] = 11.8022f;
        piggySpeed[0, 308] = 14.1511f;
        piggySpeed[0, 509] = 12.470505f;
        piggySpeed[0, 513] = 12.331200f;
        piggySpeed[0, 301] = 14.851949f;
        piggySpeed[0, 308] = 15.604623f;
        piggySpeed[0, 3] = 10.772717f;
        piggySpeed[0, 500] = 11.654822f;
        piggySpeed[0, 403] = 11.377090f;
        piggySpeed[0, 119] = 9.474475f;
        piggySpeed[0, 514] = 9.514649f;
        piggySpeed[0, 520] = 10.745142f;
        piggySpeed[0, 11] = 9.590579f;
        piggySpeed[0, 4] = 11.988482f;
        piggySpeed[0, 20] = 9.590609f;
        piggySpeed[0, 7] = 12.180752f;
        piggySpeed[1, 16] = 10.7520f;
        piggySpeed[1, 410] = 9.7482f;
        piggySpeed[1, 402] = 9.196804f;
        piggySpeed[1, 214] = 8.946677f;
        piggySpeed[1, 0] = 8.104692f;
        piggySpeed[1, 300] = 8.855998f;
        piggySpeed[1, 506] = 8.970647f;
        piggySpeed[1, 514] = 9.323579f;
        piggySpeed[1, 405] = 10.300000f;
        piggySpeed[1, 116] = 10.0487f;
        piggySpeed[1, 517] = 9.6886f;
        piggySpeed[1, 518] = 10.3000f;
        piggySpeed[1, 409] = 10.657078f;
        piggySpeed[1, 518] = 9.864514f;
        piggySpeed[1, 7] = 13.262200f;
        piggySpeed[1, 411] = 11.6323f;
        piggySpeed[1, 411] = 13.097812f;
        piggySpeed[1, 409] = 9.536072f;
        piggySpeed[1, 411] = 12.662595f;
        piggySpeed[2, 310] = 10.0000f;
        piggySpeed[2, 211] = 11.2002f;
        piggySpeed[2, 410] = 9.1681f;
        piggySpeed[2, 218] = 9.8641f;
        piggySpeed[2, 410] = 8.904224f;
        piggySpeed[2, 19] = 10.0000f;
        piggySpeed[2, 201] = 10.0000f;
        piggySpeed[2, 6] = 10.0722f;
        piggySpeed[2, 0] = 10.0000f;
        piggySpeed[2, 503] = 10.5204f;
        piggySpeed[2, 205] = 10.0882f;
        piggySpeed[2, 207] = 10.1724f;
        piggySpeed[2, 501] = 8.1961f;
        piggySpeed[2, 512] = 9.3164f;
        piggySpeed[2, 303] = 10.0000f;
        piggySpeed[2, 212] = 9.6241f;
        piggySpeed[2, 305] = 11.0604f;
        piggySpeed[2, 408] = 9.7681f;
        piggySpeed[2, 502] = 9.5646f;
        piggySpeed[2, 523] = 10.8884f;
        piggySpeed[2, 300] = 9.7521f;
        piggySpeed[2, 505] = 10.0001f;
        piggySpeed[2, 17] = 12.2924f;
        piggySpeed[2, 1] = 10.0000f;
        piggySpeed[2, 22] = 10.2042f;
        piggySpeed[2, 3] = 9.8206f;
        piggySpeed[2, 506] = 10.0000f;
        piggySpeed[2, 507] = 9.9602f;
        piggySpeed[2, 500] = 8.7842f;
        piggySpeed[2, 22] = 9.928208f;
        piggySpeed[0, 403] = 10.883680f;
        piggySpeed[2, 102] = 9.0000f;
        piggySpeed[2, 119] = 9.9f;
        piggySpeed[2, 100] = 9.3373f;
        piggySpeed[2, 118] = 9.0000f;
        piggySpeed[2, 307] = 10.4000f;
        piggySpeed[2, 306] = 11.7124f;
        piggySpeed[2, 112] = 10.8643f;
        piggySpeed[2, 508] = 10.3044f;
        piggySpeed[2, 514] = 10.3722f;
        piggySpeed[2, 405] = 11.5000f;
        piggySpeed[2, 520] = 10.0000f;
        piggySpeed[2, 11] = 10.7443f;
        piggySpeed[2, 14] = 9.1842f;
        piggySpeed[2, 4] = 11.2166f;
        piggySpeed[2, 18] = 10.0000f;
        piggySpeed[2, 520] = 7.705604f;
        piggySpeed[2, 409] = 9.8242f;
        piggySpeed[2, 108] = 9.4927f;
        piggySpeed[2, 116] = 9.9244f;
        piggySpeed[2, 302] = 8.8082f;
        piggySpeed[2, 304] = 10.8285f;
        piggySpeed[2, 517] = 10.5764f;
        piggySpeed[2, 518] = 10.0000f;
        piggySpeed[2, 215] = 9.3000f;
        piggySpeed[2, 409] = 10.300000f;
        piggySpeed[2, 516] = 10.0000f;
        piggySpeed[2, 510] = 10.3121f;
        piggySpeed[2, 9] = 8.8131f;
        piggySpeed[2, 20] = 10.0000f;
        piggySpeed[2, 10] = 9.9406f;
        piggySpeed[2, 8] = 10.4331f;
        piggySpeed[2, 7] = 10.8050f;
        piggySpeed[2, 5] = 10.5000f;
        piggySpeed[2, 411] = 10.2401f;
        piggySpeed[2, 509] = 10.4566f;
        piggySpeed[2, 513] = 8.8505f;
        piggySpeed[2, 301] = 10.0000f;
        piggySpeed[2, 107] = 10.7042f;
        piggySpeed[2, 123] = 9.0773f;
        piggySpeed[2, 311] = 10.489046f;
        piggySpeed[0, 408] = 9.000479f;
        piggySpeed[0, 22] = 10.146722f;
        piggySpeed[0, 507] = 9.900100f;
        piggySpeed[0, 500] = 11.166598f;
        piggySpeed[0, 403] = 10.737397f;
        piggySpeed[1, 22] = 10.063313f;
        piggySpeed[1, 507] = 9.698187f;
        piggySpeed[1, 500] = 10.036198f;
        piggySpeed[2, 507] = 9.776634f;
        piggySpeed[2, 119] = 9.834179f;
        piggySpeed[0, 402] = 8.436595f;
        piggySpeed[0, 214] = 10.482135f;
        piggySpeed[0, 515] = 11.119873f;
        piggySpeed[0, 310] = 10.891306f;
        piggySpeed[0, 403] = 10.883680f;
        piggySpeed[0, 18] = 11.401747f;
        piggySpeed[2, 11] = 10.468195f;
        piggySpeed[2, 8] = 10.710624f;
        piggySpeed[1, 8] = 9.456867f;
        piggySpeed[0, 214] = 10.337123f;
        piggySpeed[0, 207] = 11.550000f;
        piggySpeed[0, 303] = 11.451632f;
        piggySpeed[0, 300] = 10.965880f;
        piggySpeed[0, 3] = 9.242842f;
        piggySpeed[0, 500] = 11.430873f;
        piggySpeed[0, 307] = 10.604191f;
        piggySpeed[0, 517] = 11.438768f;
        piggySpeed[0, 205] = 11.857844f;
        piggySpeed[0, 209] = 10.066130f;
        piggySpeed[0, 300] = 11.230015f;
        piggySpeed[1, 411] = 12.940188f;
        piggySpeed[1, 123] = 10.696168f;
        piggySpeed[0, 7] = 12.670591f;
        piggySpeed[0, 311] = 11.259825f;
        piggySpeed[0, 20] = 10.225718f;
        piggySpeed[0, 107] = 13.666430f;
        piggySpeed[2, 308] = 13.577752f;
        piggySpeed[2, 119] = 10.177561f;
        piggySpeed[2, 123] = 10.346363f;
        piggySpeed[2, 107] = 11.563726f;
        piggySpeed[1, 518] = 9.996635f;
        piggySpeed[1, 107] = 12.360411f;
        piggySpeed[0, 521] = 12.566504f;
        piggySpeed[0, 107] = 14.181604f;
        piggySpeed[0, 119] = 10.940207f;
        piggySpeed[1, 119] = 9.949057f;
        piggySpeed[0, 119] = 10.5f;
        piggySpeed[2, 300] = 10.663475f;
        piggySpeed[2, 212] = 12.554959f;
        piggySpeed[2, 513] = 10.027873f;
        piggySpeed[2, 409] = 10.987667f;
        piggySpeed[2, 215] = 12.318433f;
        piggySpeed[2, 311] = 14.793160f;
        piggySpeed[1, 300] = 9.200542f;
        piggySpeed[1, 303] = 10.723679f;
        piggySpeed[1, 212] = 10.5f;
        piggySpeed[1, 305] = 11.412858f;
        piggySpeed[1, 215] = 12.835358f;
        piggySpeed[1, 311] = 14.043001f;
        piggySpeed[1, 5] = 13.919250f;
        piggySpeed[0, 116] = 11.235771f;
        piggySpeed[0, 510] = 13.536961f;
        piggySpeed[2, 22] = 10.311485f;
        piggySpeed[2, 10] = 11.725721f;
        piggySpeed[1, 10] = 11.820641f;
        piggySpeed[0, 100] = 11.006608f;
        piggySpeed[0, 308] = 12.92f;
        piggySpeed[1, 308] = 10.0f;
        piggySpeed[2, 308] = 12.8f;
        piggySpeed[0, 516] = 12.6f;
        piggySpeed[2, 516] = 11.2f;
        piggySpeed[0, 510] = 14.4f;
        piggySpeed[1, 510] = 13.0f;
        piggySpeed[0, 112] = 10.2f;
        piggySpeed[1, 112] = 10.8f;
        piggySpeed[1, 123] = 11.1f;
        piggySpeed[2, 107] = 12.0f;
        piggySpeed[1, 107] = 12.8f;
        piggySpeed[0, 507] = 12.1f;
        piggySpeed[2, 507] = 12.0f;
        piggySpeed[1, 507] = 10.5f;
        piggySpeed[0, 508] = 10.0f;
        piggySpeed[1, 508] = 12.5f;
        piggySpeed[2, 508] = 11.3044f;
        piggySpeed[2, 18] = 12.5000f;
        piggySpeed[0, 4] = 11.45f;
        piggySpeed[1, 4] = 10.0f;
        piggySpeed[2, 4] = 11.2166f;
        piggySpeed[2, 409] = 10.987667f;
        piggySpeed[0, 409] = 10.0f;
        piggySpeed[2, 301] = 10.75f;
        piggySpeed[1, 301] = 11.5f;
        piggySpeed[0, 301] = 12.75f;
        piggySpeed[0, 108] = 10.3f;
        piggySpeed[2, 108] = 9.4927f;
        piggySpeed[0, 302] = 11.8f;
        piggySpeed[1, 302] = 11.4f;
        piggySpeed[2, 302] = 10.0f;
        piggySpeed[1, 215] = 12.4f;
        piggySpeed[0, 215] = 9.7f;
        piggySpeed[0, 502] = 11.0f;
        piggySpeed[0, 307] = 11.4f;
        piggySpeed[2, 102] = 9.8000f;
        piggySpeed[0, 306] = 13.18f;
        piggySpeed[1, 306] = 12.9f;
        piggySpeed[2, 306] = 11.7f;
        piggySpeed[2, 100] = 11.0f;
        piggySpeed[1, 100] = 9.7f;
        piggySpeed[0, 100] = 11.5f;
        piggySpeed[2, 118] = 10.5f;
        piggySpeed[0, 403] = 11.0f;
        piggySpeed[1, 403] = 11.0f;
        piggySpeed[2, 403] = 10.8f;
        piggySpeed[0, 513] = 12.331200f;
        piggySpeed[2, 6] = 10.46f;
        piggySpeed[0, 7] = 11.925f;
        piggySpeed[1, 7] = 11.8f;
        piggySpeed[0, 209] = 11.6f;
        piggySpeed[1, 209] = 10.35f;
        piggySpeed[2, 209] = 11.6f;
        piggySpeed[2, 123] = 11.8f;
        piggySpeed[0, 123] = 11.8022f;
        piggySpeed[2, 520] = 10.3f;
        piggySpeed[1, 520] = 11.8f;
        piggySpeed[0, 520] = 11.4f;
        piggySpeed[0, 5] = 14.4676f;
        piggySpeed[1, 5] = 13.919250f;
        piggySpeed[2, 5] = 12.0f;
        piggySpeed[2, 1] = 13.5f;
        piggySpeed[1, 1] = 10.3f;
        piggySpeed[0, 1] = 11.0648f;
        piggySpeed[0, 514] = 9.85f;
        piggySpeed[1, 514] = 11.0f;
        piggySpeed[2, 514] = 10.3722f;
        piggySpeed[0, 3] = 9.35f;
        piggySpeed[1, 3] = 11.5f;
        piggySpeed[2, 3] = 11.0f;
        piggySpeed[2, 22] = 10.311485f;
        piggySpeed[1, 22] = 10.063313f;
        piggySpeed[0, 22] = 10.146722f;
        piggySpeed[0, 402] = 9.4f;
        piggySpeed[1, 402] = 9.2f;
        piggySpeed[1, 300] = 9.200542f;
        piggySpeed[2, 300] = 11.2f;
        piggySpeed[0, 300] = 12.5f;
        piggySpeed[1, 303] = 11.7f;
        piggySpeed[0, 303] = 11.451632f;
        piggySpeed[2, 303] = 10.0000f;
        piggySpeed[0, 212] = 12.335847f;
        piggySpeed[2, 304] = 12.0f;
        piggySpeed[1, 304] = 11.8f;
        piggySpeed[0, 304] = 13.4f;
        piggySpeed[0, 20] = 11.4f;
        piggySpeed[1, 20] = 10.95f;
        piggySpeed[2, 20] = 10.0000f;
        piggySpeed[0, 119] = 12.1f;
        piggySpeed[1, 119] = 13.2f;
        piggySpeed[2, 119] = 11.1f;
        piggySpeed[0, 107] = 14.181604f;
        piggySpeed[1, 107] = 12.8f;
        piggySpeed[2, 107] = 12.0f;
        piggySpeed[0, 116] = 12.0f;
        piggySpeed[1, 116] = 12.7f;
        piggySpeed[2, 116] = 10.5f;
        piggySpeed[1, 311] = 14.043001f;
        piggySpeed[1, 17] = 11.6f;
        if (piggySpeed[whichPig, realLevelId] > 0.0f) {
            return piggySpeed[whichPig, realLevelId];
        }

        return speedBefore;
    }
	
	}
}
