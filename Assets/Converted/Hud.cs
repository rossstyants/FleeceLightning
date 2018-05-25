using UnityEngine;
using System;

namespace Default.Namespace
{
    public class Hud
    {
		public Billboard[] directionButtonBillboard = new Billboard[2];
//		public Billboard whirlyThingBillboard;
		
        public SpeedBoostScreen speedBoostScreen;
        public AnotherPiggyScreen anotherPiggyScreen;
        public LightBall lightBall;
        public AppleWon appleWon;
        public Zobject[] winBackApple = new Zobject[3];
        public Zobject winBackCorkTop;
        public Zobject winBackCorkMid;
        public Zobject winBackFade;
        public Zobject winBackFadeBot;
        public Zobject bigHand;
        public Zobject sunmoon;	//= PAUSE!
        public Zobject tiltWarning;
        public ZRaceMeter raceMeter;
        public FunnyWord[] funnyWord = new FunnyWord[(int)Enum.kHud_NumFunnyWords];
        public Zobject whistlingBitzer;
        public Zobject piggyHead;
        public Zobject sheepyHead;
        public Zobject radialLight;
        public Zobject starCupStar;
        public Zobject piggyCommentBubble;
        public Zobject pauseBack;
        public Zscore time;
        public Zscore bestTime;
        public FrontEndScreen feelGoodScreen;
        public FrontEndScreen showNextLevelScreen;
        public FrontEndScreen winScreen;
        public FrontEndScreen loseScreen;
        public FunnyWord ohno;
        public FunnyWord levelWord;
        public Zscore levelWordNumber;
        public FunnyWord levelName;
        public bool canPlayNextLevel;
        public Texture2D_Ross darkTexture;
        public int sunPhase;
        public int nextLevelButtonId;
        public int tipButtonId;
        public float darkTextureScrollPosition;
        public bool darkHasStartedToFall;
        public bool dimFalling;
        public bool dimGoing;
        public bool hasBeenReset;
        public float dimAlpha;
        public float tiltWarningTimer;
        public FrontEndButton restartButton;
        public FrontEndButton nextLevelButton;
        public FrontEndButton menuButton;
        public float waitToShowGlow;
        public float sunSwitchTimer;
        public bool sunLeftSide;
        public bool showResultsScreenShown;
        public CGPoint sunStartPos;
        public float timeThrobber;
        public float controlFade;
        public float feelGoodBounceTimer;
      //  public Zobject rosette;
        public float pauseEndTimer;
        public Zobject[] grZob = new Zobject[2];
        public float targetSpinPos;
        const float kControlArrowFadeMax = 0.6f;
        const float kPauseBarPos = 13.0f;
        const float kScaleForButtonsTip = 0.6f;
        const float kScaleForButtonsNotWin = 0.85f;
        const float kScaleForButtonsWin = 0.85f;
        const float kBottomLineButtsPos = 455.0f;
        const float kShowLevelBestTimeY = 177.0f;
        const float kLevelNameY = 120.0f;
        const float kLevelWordY = 70.0f;
        const float kWordStartHeight = -320;
        const float kSunSwitchTime = 0.5f;
        public enum Enum {
            kHudFW_PiggyComment1 = 0,
            kHudFW_PiggyComment2,
            kHudFW_PiggyComment3,
            kHudFW_ExcellentComment,
            kHudFW_bestTime,
            kHudFW_time,
            kHud_NumFunnyWords
        };
        public FunnyWord Ohno
        {
            get;
            set;
        }

        public FunnyWord LevelWord
        {
            get;
            set;
        }

        public FrontEndButton RestartButton
        {
            get;
            set;
        }

        public FrontEndButton NextLevelButton
        {
            get;
            set;
        }

        public FrontEndButton MenuButton
        {
            get;
            set;
        }

        public Zobject BigHand
        {
            get;
            set;
        }

        public bool CanPlayNextLevel
        {
            get;
            set;
        }

        public Zobject Sunmoon
        {
            get;
            set;
        }

        public SpeedBoostScreen SpeedBoostScreen
        {
            get;
            set;
        }

        public AnotherPiggyScreen AnotherPiggyScreen
        {
            get;
            set;
        }

        public FrontEndScreen ShowNextLevelScreen
        {
            get;
            set;
        }

        public FrontEndScreen WinScreen
        {
            get;
            set;
        }

        public FrontEndScreen LoseScreen
        {
            get;
            set;
        }

        public ZRaceMeter RaceMeter
        {
            get;
            set;
        }

        public bool ShowResultsScreenShown
        {
            get;
            set;
        }

		public void SetRaceMeter(ZRaceMeter inThing) {raceMeter = inThing;}////@property(readwrite,assign) ZRaceMeter* raceMeter;
public void SetBigHand(Zobject inThing) {bigHand = inThing;}////@property(readwrite,assign) Zobject* bigHand;
public void SetOhno(FunnyWord inThing) {ohno = inThing;}////@property(readwrite,assign) FunnyWord* ohno;
public void SetLevelWord(FunnyWord inThing) {levelWord = inThing;}////@property(readwrite,assign) FunnyWord* levelWord;
public void SetRestartButton(FrontEndButton inThing) {restartButton = inThing;}////@property(readwrite,assign) FrontEndButton* restartButton;
public void SetNextLevelButton(FrontEndButton inThing) {nextLevelButton = inThing;}////@property(readwrite,assign) FrontEndButton* nextLevelButton;
public void SetMenuButton(FrontEndButton inThing) {menuButton = inThing;}////@property(readwrite,assign) FrontEndButton* menuButton;
//public void SetTipButton(FrontEndButton inThing) {tipButton = inThing;}////@property(readwrite,assign) FrontEndButton* tipButton;
public void SetCanPlayNextLevel(bool inThing) {canPlayNextLevel = inThing;}///@property(readwrite,assign) bool canPlayNextLevel;
public void SetSunmoon(Zobject inThing) {sunmoon = inThing;}////@property(readwrite,assign) Zobject* sunmoon;
//public void SetRosette(Zobject inThing) {rosette = inThing;}////@property(readwrite,assign) Zobject* rosette;
//public void SetAppleCart(AppleCart inThing) {appleCart = inThing;}////@property(readwrite,assign) AppleCart* appleCart;
public void SetSpeedBoostScreen(SpeedBoostScreen inThing) {speedBoostScreen = inThing;}////@property(readwrite,assign) SpeedBoostScreen* speedBoostScreen;
public void SetAnotherPiggyScreen(AnotherPiggyScreen inThing) {anotherPiggyScreen = inThing;}////@property(readwrite,assign) AnotherPiggyScreen* anotherPiggyScreen;
//public void SetDimOverlay(string inThing) {dimOverlay = inThing;}////@property(readwrite,assign) Texture2D* dimOverlay;

public void SetShowNextLevelScreen(FrontEndScreen inThing) {showNextLevelScreen = inThing;}////@property(readwrite,assign) FrontEndScreen* showNextLevelScreen;
public void SetWinScreen(FrontEndScreen inThing) {winScreen = inThing;}////@property(readwrite,assign) FrontEndScreen* winScreen;
public void SetLoseScreen(FrontEndScreen inThing) {loseScreen = inThing;}////@property(readwrite,assign) FrontEndScreen* loseScreen;
public void SetShowResultsScreenShown(bool inThing) {showResultsScreenShown = inThing;}///@property(readwrite,assign) bool showResultsScreenShown;

        public Hud()
        {
            //if (!base.init()) return null;
			
			directionButtonBillboard[0] = null;
			directionButtonBillboard[1] = null;
//			whirlyThingBillboard = null;
			
            targetSpinPos = 0.0f;
            hasBeenReset = false;
            speedBoostScreen = new SpeedBoostScreen();
            anotherPiggyScreen = new AnotherPiggyScreen();
            appleWon = new AppleWon();
            piggyHead = new Zobject();
            whistlingBitzer = null;
            sheepyHead = new Zobject();
            starCupStar = new Zobject();
            radialLight = new Zobject();
            piggyCommentBubble = new Zobject();
            feelGoodScreen = new FrontEndScreen(0,Globals.g_world.frontEnd);
            showNextLevelScreen = null;
            winScreen = null;
            loseScreen = null;
            lightBall = new LightBall();
            for (int i = 0; i < 3; i++) winBackApple[i] = new Zobject();

            winBackCorkTop = new Zobject();
            winBackCorkMid = new Zobject();
            winBackFade = new Zobject();
            winBackFadeBot = new Zobject();
            sunmoon = new Zobject();
            tiltWarning = null;
            bigHand = new Zobject();
            ohno = new FunnyWord();
            grZob[0] = new Zobject();
            grZob[1] = new Zobject();
            ohno.SetFont(Globals.g_world.font);
            ohno.SetRenderOldStyle(true);
            levelName = new FunnyWord();
            levelWord = new FunnyWord();
            for (int i = 0; i < (int)Enum.kHud_NumFunnyWords; i++) {
                funnyWord[i] = new FunnyWord();
            }

            levelWordNumber = new Zscore();
            time = new Zscore();
            bestTime = new Zscore();
            restartButton = new FrontEndButton(0);
            nextLevelButton = new FrontEndButton(0);
            menuButton = new FrontEndButton(0);
            pauseBack = new Zobject();
            raceMeter = new ZRaceMeter();
            this.Initialise();
            //return this;
        }
        public void HandleTap(CGPoint position)
        {
            switch ((Globals.g_world.game).gameState) {
            case GameState.e_ShowLevel :
                showNextLevelScreen.HandleTap(position);
                break;
            case GameState.e_ShowResultsWin :
				if (winScreen != null)
				{
	                winScreen.HandleTap(position);
				}
                break;
            case GameState.e_ShowResultsLoseToPiggy :
				if (loseScreen != null)
	                loseScreen.HandleTap(position);
                break;
            case GameState.e_AnotherPiggy :
                anotherPiggyScreen.HandleTap(position);
                break;
            default :
                break;
            }

        }

		public void OnGUI ()
		{
            switch ((Globals.g_world.game).gameState) {
            case GameState.e_GamePlay :
                break;
            case GameState.e_AnotherPiggy :
				anotherPiggyScreen.OnGUI();
				break;
            case GameState.e_ShowLevel :
				levelWord.OnGUI();
				levelName.OnGUI();
				showNextLevelScreen.OnGUI();
				break;
            case GameState.e_FeelGoodScreen :
				feelGoodScreen.OnGUI();
                break;
            case GameState.e_Paused :
                break;
            case GameState.e_ShowResultsWin :
				if (winScreen != null)
					winScreen.OnGUI();
	
				//(funnyWord[(int)Enum.kHudFW_ExcellentComment]).OnGUI();
				break;
            case GameState.e_ShowResultsLoseTooSlow :
            case GameState.e_ShowResultsLoseToPiggy :
				if (loseScreen != null)
					loseScreen.OnGUI ();
				(funnyWord[(int)Enum.kHudFW_PiggyComment1]).OnGUI();
				(funnyWord[(int)Enum.kHudFW_PiggyComment2]).OnGUI();
				(funnyWord[(int)Enum.kHudFW_PiggyComment3]).OnGUI();
				break;
            default :
                break;
            }
		}


        public void SetupShowNextLevelScreen ()
		{
			if (showNextLevelScreen != null) 
			{
				showNextLevelScreen.Dealloc();
				showNextLevelScreen = null;
			}

			showNextLevelScreen = new FrontEndScreen (0,Globals.g_world.frontEnd);
			showNextLevelScreen.SetBackScreen ((Globals.g_world.game).GetTexture (TextureType.kTexture_FullScreen_ShaunRunning));
			FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo();
			bInfo.texture = null;
			bInfo.position = Utilities.CGPointMake (82.0f, 210.0f);
			int buttId = showNextLevelScreen.AddButton (bInfo);
			(showNextLevelScreen.GetButton (buttId)).SetIsClickable (false);
			(showNextLevelScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
//			(showNextLevelScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (Globals.g_world.GetAtlas (AtlasType.kAtlas_ParticlesScene), 0);
              GetSubTextLanguageP1 ((int)AtlasType.kAtlas_ShowLevelAndTip, (int)World.Enum6.kSSH_BestTimeSign)
			);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
			hInfo.showWobbleMultiplier = 1.0f;
			hInfo.subTextureId = (int)World.Enum6.kSSH_Rope;
			hInfo.type = HangingButtonType.kHB_Chain;
			hInfo.offset = Utilities.CGPointMake (53.0f, -32.0f);
			(showNextLevelScreen.GetButton (buttId)).AddHangingButton (hInfo);
			bestTime.SetOrientationButton ((showNextLevelScreen.GetButton (buttId)).hangingButton);
			time.SetOrientationButton ((showNextLevelScreen.GetButton (buttId)).hangingButton);
			if (Globals.g_world.DoesCurrentLanguageUseNSString ()) {
				FrontEndScreen.AddFunnyWordInfo fInfo;
				fInfo.inString = Globals.g_world.GetNSString (StringId.kString_BestTime);
				fInfo.position = bInfo.position;
				fInfo.position.y -= 8.0f;
				fInfo.scale = 0.4f;
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) 				
					fInfo.scale = 0.5f;

				
				
				int fwId = showNextLevelScreen.AddFunnyWord (fInfo);
				(showNextLevelScreen.GetFunnyWord (fwId)).SetColour (Constants.kColourRedText);
				(showNextLevelScreen.GetFunnyWord (fwId)).SetShowStyleNew ((int)ZobjectShowStyle.kZobjectShow_Immediate);
				(showNextLevelScreen.GetFunnyWord (fwId)).SetPositionButton (showNextLevelScreen.GetButton (buttId));
				(showNextLevelScreen.GetFunnyWord (fwId)).SetOrientationButton ((showNextLevelScreen.GetButton (buttId)).hangingButton);
					
					(showNextLevelScreen.GetFunnyWord (fwId)).FitToWidth (110.0f);
			}

			bInfo.position = Utilities.CGPointMake (240.0f, 202.0f);
			buttId = showNextLevelScreen.AddButton (bInfo);
			(showNextLevelScreen.GetButton (buttId)).SetIsClickable (false);
			(showNextLevelScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_AppleSign),
				0
			);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			hInfo.type = HangingButtonType.kHB_Rope;
			hInfo.subTextureId = 1;
			hInfo.offset = Utilities.CGPointMake (45.0f, -22.0f);
			(showNextLevelScreen.GetButton (buttId)).AddHangingButton (hInfo);
			bInfo.position = Utilities.CGPointMake (160.0f, 285.0f);
			buttId = showNextLevelScreen.AddButton (bInfo);
			(showNextLevelScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetSubTextLanguageP1 ((int)AtlasType.kAtlas_ShowLevelAndTip, (int)World.Enum6.kSSH_PlaySign)
			);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			hInfo.type = HangingButtonType.kHB_Rope;
			hInfo.subTextureId = (int)World.Enum6.kSSH_Rope;
			hInfo.showWobbleMultiplier = 2.0f;
			hInfo.offset = Utilities.CGPointMake (0.1f, -10.0f);
			(showNextLevelScreen.GetButton (buttId)).AddHangingButton (hInfo);
			((showNextLevelScreen.GetButton (buttId)).hangingButton).SetLongerRope (2.0f);
			if (Globals.g_world.DoesCurrentLanguageUseNSString ()) {
				FrontEndScreen.AddFunnyWordInfo fInfo;
				fInfo.inString = Globals.g_world.GetNSString (StringId.kString_Play);
				fInfo.position = bInfo.position;
				fInfo.position.y -= 2.0f;
				fInfo.scale = 0.25f;
				
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French)
				{
					fInfo.scale = 0.45f;
				}
				
				int fwId = showNextLevelScreen.AddFunnyWord (fInfo);
				(showNextLevelScreen.GetFunnyWord (fwId)).SetColour (Constants.kBrown_FleeceMenu);
				(showNextLevelScreen.GetFunnyWord (fwId)).SetShowStyleNew ((int)ZobjectShowStyle.kZobjectShow_Immediate);
				(showNextLevelScreen.GetFunnyWord (fwId)).SetPositionButton (showNextLevelScreen.GetButton (buttId));
				(showNextLevelScreen.GetFunnyWord (fwId)).SetOrientationButton ((showNextLevelScreen.GetButton (buttId)).hangingButton);
			}

			bInfo.position = Utilities.CGPointMake (160.0f, 93.0f);
			buttId = showNextLevelScreen.AddButton (bInfo);
			int levelButtonId = buttId;
			(showNextLevelScreen.GetButton (buttId)).SetIsClickable (false);
			(showNextLevelScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip),
				(int)World.Enum6.kSSH_LongTitleSign
			);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			hInfo.type = HangingButtonType.kHB_Rope;
			hInfo.showWobbleMultiplier = 1.0f;
			hInfo.offset = Utilities.CGPointMake (100.0f, 20.0f);
			(showNextLevelScreen.GetButton (buttId)).AddHangingButton (hInfo);
			((showNextLevelScreen.GetButton (buttId)).hangingButton).SetYOffset (24.0f);
			levelName.SetOrientationButton ((showNextLevelScreen.GetButton (levelButtonId)).hangingButton);
			levelWord.SetOrientationButton ((showNextLevelScreen.GetButton (levelButtonId)).hangingButton);
			levelWordNumber.SetOrientationButton ((showNextLevelScreen.GetButton (levelButtonId)).hangingButton);
			bInfo.position = Utilities.CGPointMake (160.0f, Globals.g_world.frontEnd.kChooseTrackBackBarTopPosY);
			buttId = showNextLevelScreen.AddButton (bInfo);
			(showNextLevelScreen.GetButton (buttId)).SetIsClickable (false);
			(showNextLevelScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip), 
              Globals.g_world.GetIPadSubTexture ((int)World.Enum6.kSSH_BackBar));
			((showNextLevelScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((showNextLevelScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			bInfo.position = Utilities.CGPointMake (
				((Globals.g_world.frontEnd).xBackButton),
				Globals.g_world.frontEnd.kChooseTrackBackBarTopPosY - 1.0f);
            bInfo.texture = null;
            buttId = showNextLevelScreen.AddButton(bInfo);
            (showNextLevelScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            ((showNextLevelScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            ((showNextLevelScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (showNextLevelScreen.GetButton(buttId)).SetHeight(30.0f);
            Globals.g_world.AddBackWordsP1(showNextLevelScreen, buttId);
            bInfo.position = Utilities.CGPointMake((320.0f - (Globals.g_world.frontEnd).xBackButton) + 12.0f, 15);
            bInfo.texture = null;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                bInfo.position.x -= 16.0f;
            }

            buttId = showNextLevelScreen.AddButton(bInfo);
            tipButtonId = buttId;
            (showNextLevelScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetSubTextLanguageP1((int) AtlasType.kAtlas_ShowLevelAndTip, (int)World.Enum6.kSSH_TipButton));
            (showNextLevelScreen.GetButton(buttId)).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            ((showNextLevelScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (showNextLevelScreen.GetButton(buttId)).SetWidth(70);
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Tip);
                fInfo.position = bInfo.position;
                fInfo.position.y -= 0.0f;
                fInfo.scale = 0.3f;
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
					fInfo.scale = 0.4f;//kWordScale * 0.43f;
					fInfo.position.y -= 2.0f;
				}
				
                int fwId = showNextLevelScreen.AddFunnyWord(fInfo);
                (showNextLevelScreen.GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
                (showNextLevelScreen.GetFunnyWord(fwId)).SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (showNextLevelScreen.GetFunnyWord(fwId)).SetPositionButton(showNextLevelScreen.GetButton(buttId));
            }

        }

        public void SetupWinScreen ()
		{
			if (winScreen != null) {
				(funnyWord [(int)Enum.kHudFW_ExcellentComment]).SetOrientationButton (null);			
				winScreen.Dealloc();
				winScreen = null;
			}

			winScreen = new FrontEndScreen (0,Globals.g_world.frontEnd);
			winScreen.SetBackScreen ((Globals.g_world.frontEnd).GetButtonTexture ((int)FrontEnd.Enum.kButtonTexture_ShaunOnPodium));
			FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo();
			bInfo.texture = null;
			bInfo.position = Utilities.CGPointMake (160.0f, 240.0f);
			bInfo.texture = (Globals.g_world.frontEnd).GetButtonTexture ((int)FrontEnd.Enum.kButtonTexture_ShaunOnPodium);
			int buttId = winScreen.AddButton (bInfo);
			(winScreen.GetButton (buttId)).SetIsClickable (false);
			((winScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_SlideInBottom);
			((winScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			((winScreen.GetButton (buttId)).zobject).SetShowLagSpeed (0.035f);
			((winScreen.GetButton (buttId)).zobject).SetSlideInBottomStartY (360);
//			((winScreen.GetButton (buttId)).zobject).myAtlasBillboard.width = Globals.g_world.screenHeight;
//			((winScreen.GetButton (buttId)).zobject).myAtlasBillboard.height = Globals.g_world.screenWidth;
			((winScreen.GetButton (buttId)).zobject).myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");

			bInfo.texture = null;
			bInfo.position = Utilities.CGPointMake (87.0f, 205.0f);
			buttId = winScreen.AddButton (bInfo);
			(winScreen.GetButton (buttId)).SetIsClickable (false);
			(winScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetSubTextLanguageP1 ((int)
              AtlasType.kAtlas_ShowLevelAndTip, (int)World.Enum6.kSSH_BestTimeSign)
			);
			((winScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((winScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
			hInfo.showWobbleMultiplier = 1.0f;
			hInfo.subTextureId = (int)World.Enum6.kSSH_Rope;
			hInfo.type = HangingButtonType.kHB_Chain;
			hInfo.offset = Utilities.CGPointMake (53.0f, -32.0f);
			(winScreen.GetButton (buttId)).AddHangingButton (hInfo);
			bestTime.SetOrientationButton ((winScreen.GetButton (buttId)).hangingButton);
			if (Globals.g_world.DoesCurrentLanguageUseNSString ()) {
				FrontEndScreen.AddFunnyWordInfo fInfo;
				fInfo.inString = Globals.g_world.GetNSString (StringId.kString_BestTime);
				fInfo.position = bInfo.position;
				fInfo.position.y -= 8.0f;
				fInfo.scale = 0.4f;

				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) 				
					fInfo.scale = 0.5f;
				
				int fwId = winScreen.AddFunnyWord (fInfo);
				(winScreen.GetFunnyWord (fwId)).SetColour (Constants.kColourRedText);
				(winScreen.GetFunnyWord (fwId)).SetShowStyleNew ((int)ZobjectShowStyle.kZobjectShow_Immediate);
				(winScreen.GetFunnyWord (fwId)).SetPositionButton (winScreen.GetButton (buttId));
				(winScreen.GetFunnyWord (fwId)).SetOrientationButton ((winScreen.GetButton (buttId)).hangingButton);
				
					(winScreen.GetFunnyWord (fwId)).FitToWidth (110.0f);
			}

			bInfo.position = Utilities.CGPointMake (236.0f, 202.0f);
			buttId = winScreen.AddButton (bInfo);
			(winScreen.GetButton (buttId)).SetIsClickable (false);
			(winScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_AppleSign),
				0
			);
			((winScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((winScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			hInfo.type = HangingButtonType.kHB_Rope;
			hInfo.subTextureId = 1;
			hInfo.offset = Utilities.CGPointMake (45.0f, -22.0f);
			(winScreen.GetButton (buttId)).AddHangingButton (hInfo);
			bInfo.position = Utilities.CGPointMake (160.0f, 93.0f);
			buttId = winScreen.AddButton (bInfo);
			(winScreen.GetButton (buttId)).SetIsClickable (false);
			(winScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip),
				(int)World.Enum6.kSSH_LongTitleSign
			);
			((winScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((winScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			hInfo.type = HangingButtonType.kHB_Rope;
			hInfo.subTextureId = (int)World.Enum6.kSSH_Rope;
			hInfo.offset = Utilities.CGPointMake (100.0f, 20.0f);
			(winScreen.GetButton (buttId)).AddHangingButton (hInfo);
			
			(funnyWord [(int)Enum.kHudFW_ExcellentComment]).SetOrientationButton ((winScreen.GetButton (buttId)).hangingButton);
			
			time.SetOrientationButton ((winScreen.GetButton (buttId)).hangingButton);
			((winScreen.GetButton (buttId)).hangingButton).SetYOffset (24.0f);
			bInfo.position = Utilities.CGPointMake (160.0f, Globals.g_world.frontEnd.kChooseTrackBackBarTopPosY);
			buttId = winScreen.AddButton (bInfo);
			(winScreen.GetButton (buttId)).SetIsClickable (false);
			(winScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetIPadSubTexture (
              (int)World.Enum6.kSSH_BackBar)
			);
			((winScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((winScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			bInfo.position = Utilities.CGPointMake (
				(Globals.g_world.frontEnd).xBackButton,
				Globals.g_world.frontEnd.kChooseTrackBackBarTopPosY - 1.0f);
							
            bInfo.texture = null;
            buttId = winScreen.AddButton(bInfo);
            (winScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            ((winScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            ((winScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            Globals.g_world.AddBackWordsP1(winScreen, buttId);
            bInfo.position = Utilities.CGPointMake(24.0f, 295.0f);
						if (Globals.useIPadBackScreens) {
                bInfo.position.x -= 20.0f;
   
			}

			
			bInfo.position.x = Globals.g_world.xScreenEdge + 24.0f;			
						
            buttId = winScreen.AddButton(bInfo);
            (winScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), (int)World.Enum6.kSSH_Restart);
            ((winScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            ((winScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
//            bInfo.position.x = 296.0f;
						if (Globals.useIPadBackScreens) {
  //              bInfo.position.x += 20.0f;
            }
						
			bInfo.position.x = 320.0f - (bInfo.position.x);			
			
            buttId = winScreen.AddButton(bInfo);
            nextLevelButtonId = buttId;
            (winScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), (int)World.Enum6.kSSH_NextLevel);
            ((winScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            ((winScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);

            #if FACEBOOK_BUTTON
                if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                    bInfo.position.x = 299.0f;
                    bInfo.position.y = 467.0f;
                    if (Globals.deviceIPad) {
                        bInfo.position.x += 32.0f;
                        bInfo.position.y += 32.0f;
                    }

                    buttId = winScreen.AddButton(bInfo);
                    (winScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), (int)World.Enum6.kSSH_Facebook);
                    (winScreen.GetButton(buttId)).SetClickStyle( ButtonClickStyle.kButtonClick_ThrobAndGo);
                    ((winScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
                    ((winScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
                    ((winScreen.GetButton(buttId)).zobject).SetShowScale(0.74f);
                    ((winScreen.GetButton(buttId)).zobject).SetWaitToShow(1.0f);
                    (winScreen.GetButton(buttId)).SetWidth(60.0f);
                    (winScreen.GetButton(buttId)).SetHeight(60.0f);
                    bInfo.position.x = 13.0f;
                    bInfo.position.y = 363.0f;
                    if (Globals.deviceIPad) {
                        bInfo.position.x -= 32.0f;
                        bInfo.position.y += 48.0f;
                    }

                    buttId = winScreen.AddButton(bInfo);
                    (winScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), (int)World.Enum6.kSSH_Facebook);
                    (winScreen.GetButton(buttId)).SetClickStyle( ButtonClickStyle.kButtonClick_ThrobAndGo);
                    ((winScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
                    ((winScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
                    ((winScreen.GetButton(buttId)).zobject).SetShowScale(0.7f);
                    ((winScreen.GetButton(buttId)).zobject).SetWaitToShow(0.5f);
                }

            #endif

        }

        public void DeallocWinOrLoseScreen()
		{
			if (loseScreen != null) 
			{

			(funnyWord [(int)Enum.kHudFW_PiggyComment1]).ClearOrientatinoThing();
			(funnyWord [(int)Enum.kHudFW_PiggyComment2]).ClearOrientatinoThing();
			(funnyWord [(int)Enum.kHudFW_PiggyComment3]).ClearOrientatinoThing();
				
				
				loseScreen.Dealloc();
				loseScreen = null;

				if (piggyHead != null)
				{
					piggyHead.Dealloc();
					piggyHead = null;
				}
			}
			if (winScreen != null) {
				(funnyWord [(int)Enum.kHudFW_ExcellentComment]).SetOrientationButton (null);
				winScreen.Dealloc();
				winScreen = null;
			}			
		}		
		
        public void SetupLoseScreen ()
		{
			if (loseScreen != null) {
				
			(funnyWord [(int)Enum.kHudFW_PiggyComment1]).ClearOrientatinoThing();
			(funnyWord [(int)Enum.kHudFW_PiggyComment2]).ClearOrientatinoThing();
			(funnyWord [(int)Enum.kHudFW_PiggyComment3]).ClearOrientatinoThing();
				
				
				loseScreen.Dealloc();
				loseScreen = null;
			}

			loseScreen = new FrontEndScreen (0,Globals.g_world.frontEnd);
			loseScreen.SetBackScreen ((Globals.g_world.frontEnd).GetButtonTexture ((int)FrontEnd.Enum.kButtonTexture_MenuBackGround));
			FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo();
			bInfo.texture = null;
			bInfo.position = Utilities.CGPointMake (135, 150);
			int buttId = loseScreen.AddButton (bInfo);
			(loseScreen.GetButton (buttId)).SetIsClickable (false);
			(loseScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_RaceLose),
				(int)World.Enum5.kRL_Sign
			);
			((loseScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((loseScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
			hInfo.showWobbleMultiplier = 1.0f;
			hInfo.subTextureId = (int)World.Enum5.kRL_Rope;
			hInfo.type = HangingButtonType.kHB_Chain;
			hInfo.offset = Utilities.CGPointMake (86.0f, -90.0f);
			(loseScreen.GetButton (buttId)).AddHangingButton (hInfo);
			((loseScreen.GetButton (buttId)).hangingButton).SetBaseAngleOffset (0.12f);
			(funnyWord [(int)Enum.kHudFW_PiggyComment1]).SetOrientationButton ((loseScreen.GetButton (buttId)).hangingButton);
			(funnyWord [(int)Enum.kHudFW_PiggyComment2]).SetOrientationButton ((loseScreen.GetButton (buttId)).hangingButton);
			(funnyWord [(int)Enum.kHudFW_PiggyComment3]).SetOrientationButton ((loseScreen.GetButton (buttId)).hangingButton);
			bInfo.position = Utilities.CGPointMake (160.0f, Globals.g_world.frontEnd.kChooseTrackBackBarTopPosY);
			buttId = loseScreen.AddButton (bInfo);
			(loseScreen.GetButton (buttId)).SetIsClickable (false);
						if (Globals.useIPadBackScreens) {
				(loseScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
					Globals.g_world.GetAtlas (AtlasType.kAtlas_RaceLose),
					(int)World.Enum5.kRL_BackBar_Ipad
				);
			} else {
				(loseScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
					Globals.g_world.GetAtlas (AtlasType.kAtlas_RaceLose),
					(int)World.Enum5.kRL_BackBar
				);
			}

			((loseScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((loseScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			bInfo.position = Utilities.CGPointMake (
				(Globals.g_world.frontEnd).xBackButton,
				Globals.g_world.frontEnd.kChooseTrackBackBarTopPosY - 1.0f);
            bInfo.texture = null;
            buttId = loseScreen.AddButton(bInfo);
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                (loseScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_RaceLose), (int)World.Enum5.kRL_BackButtonGerman);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_English) {
                (loseScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_RaceLose), (int)World.Enum5.kRL_BackButton);
            }
            else {
                (loseScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_RaceLose), (int)World.Enum5.kRL_BackArrowEmpty);
                Globals.g_world.AddBackWordsP1(loseScreen, buttId);
            }

            ((loseScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            ((loseScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            bInfo.position = Utilities.CGPointMake(24.0f, 380.0f);
						if (Globals.useIPadBackScreens) {
                bInfo.position.x -= 20.0f;
            }
			
			bInfo.position.x = Globals.g_world.xScreenEdge + 24.0f;	
			
            buttId = loseScreen.AddButton(bInfo);
            (loseScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_RaceLose), (int)World.Enum5.kRL_Retry);
            ((loseScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            ((loseScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
//            bInfo.position.x = 296.0f;
						if (Globals.useIPadBackScreens) {
  //              bInfo.position.x += 20.0f;
            }
			
			bInfo.position.x = 320.0f - (bInfo.position.x);//Globals.g_world.xScreenEdge + 24.0f;				
			
            buttId = loseScreen.AddButton(bInfo);
            nextLevelButtonId = buttId;
            (loseScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_RaceLose), (int)World.Enum5.kRL_NextLevel);
            ((loseScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            ((loseScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
        }

        public void DeallocFeelGood()
        {
			feelGoodScreen.Dealloc();
			feelGoodScreen = null;
		}		

        public void DeallocAnotherPiggy()
        {
			anotherPiggyScreen.DeallocTipOrAnotherPiggyScreen();
		}		
		
		
        public void FirstInitialisation()
        {
            levelWord.SetFont(Globals.g_world.font);
            levelName.SetFont(Globals.g_world.font);
            levelName.SetLineAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines));
            levelName.SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));
            FunnyWord.WordInfo wInfo;
            wInfo.position = Utilities.CGPointMake(160, kLevelNameY);
            wInfo.scale = 0.7f;
            wInfo.isCentrePos = true;
            string inWord = "empty\n";
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                wInfo.position.y -= 3.0f;
                wInfo.scale = 0.55f;
                levelName.InitWithWordNewP1(wInfo, "empty");
            }
            else {
                levelName.InitWithWordP1(wInfo, inWord);
            }

            levelName.SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
            for (int i = 0; i < (int)Enum.kHud_NumFunnyWords; i++) {
                (funnyWord[i]).SetFont(Globals.g_world.font);
                (funnyWord[i]).SetLineAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines));
                (funnyWord[i]).SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));
            }

            ZRaceMeter.ZRaceMeterData rmData = new ZRaceMeter.ZRaceMeterData();
            rmData.numTeams = 4;
            rmData.position = Utilities.CGPointMake(25, 200);
            
			rmData.position.x = Globals.g_world.xScreenEdge + 45.0f;
			
			if (Globals.deviceIPad) {
//                rmData.position.x -= 28.0f;
            }

            rmData.markerTexture[0] = null;
            rmData.markerTexture[1] = null;
            rmData.markerTexture[2] = null;
            rmData.markerTexture[3] = null;
            rmData.trackTexture = null;
            rmData.atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud);
            rmData.subtextureId[0] = (int)World.Enum4.kHU_Shaun;
            int opponentStId = (int)World.Enum4.kHU_Piggy;
            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneIce) opponentStId = 7;
            else if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneDesert) opponentStId = 8;

            rmData.subtextureId[1] = opponentStId;
            rmData.subtextureId[2] = opponentStId;
            rmData.subtextureId[3] = opponentStId;
            raceMeter.FirstInitialisation(rmData);
            ZRaceMeter.ZRaceMeterReinitData rmrData = new ZRaceMeter.ZRaceMeterReinitData();
            rmrData.scale = 1;
            rmrData.markerScale = 1;
            rmrData.raceMeterScreenPosition = Utilities.CGPointMake(25, 200);
			rmrData.raceMeterScreenPosition.x = Globals.g_world.xScreenEdge + 45.0f;
			
            rmrData.raceMarkersScreenFrom = Utilities.CGPointMake(0, -80);
            rmrData.raceMarkersScreenTo = Utilities.CGPointMake(0, 94.0f);
            rmrData.useLocator = false;
						if (Globals.useIPadBackScreens) {
                rmrData.raceMeterScreenPosition.x -= 28.0f;
            }

            raceMeter.ReInit(rmrData);
            this.SetupShowNextLevelScreen();
            feelGoodScreen.SetBackScreen(null);
            FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo();
            bInfo.position = Utilities.GetScreenCentre();
            bInfo.texture = null;
            int buttId = feelGoodScreen.AddButton(bInfo);
            (feelGoodScreen.GetButton(buttId)).SetWidth(320);
            (feelGoodScreen.GetButton(buttId)).SetWidth(480);
            float kWordScale = 0.7f;
            float kFitWidth = 240;
            float xPos = 160;
            float y = 46;
            string inString = "excellent\n";
            int wId = feelGoodScreen.AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, Constants.kColourYellow);
            (feelGoodScreen.GetFunnyWord(wId)).SetTimeToShowSpeed(0.035f);
            (feelGoodScreen.GetFunnyWord(wId)).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (feelGoodScreen.GetFunnyWord(wId)).FitToWidth(kFitWidth);
            (feelGoodScreen.GetFunnyWord(wId)).SetBounceSize(0.5f);
            float yPlus = 45;
            kWordScale = 0.715f;
            y = 130;
            inString = "six levels done\n";
            wId = feelGoodScreen.AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.
              kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true);
            (feelGoodScreen.GetFunnyWord(wId)).SetTimeToShowSpeed(0.06f);
            (feelGoodScreen.GetFunnyWord(wId)).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (feelGoodScreen.GetFunnyWord(wId)).Jiggle();
            (feelGoodScreen.GetFunnyWord(wId)).FitToWidth(kFitWidth);
            y += yPlus;
            inString = "you are getting\n";
            wId = feelGoodScreen.AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, Constants.indigo);
            (feelGoodScreen.GetFunnyWord(wId)).SetTimeToShowSpeed(0.06f);
            (feelGoodScreen.GetFunnyWord(wId)).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (feelGoodScreen.GetFunnyWord(wId)).FitToWidth(kFitWidth);
            y = 400;
            inString = "good at this\n";
            wId = feelGoodScreen.AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, Constants.indigo);
            (feelGoodScreen.GetFunnyWord(wId)).SetTimeToShowSpeed(0.06f);
            (feelGoodScreen.GetFunnyWord(wId)).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (feelGoodScreen.GetFunnyWord(wId)).FitToWidth(kFitWidth);
            y += yPlus;
            inString = "\n";
            wId = feelGoodScreen.AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, Constants.indigo);
            (feelGoodScreen.GetFunnyWord(wId)).SetTimeToShowSpeed(0.06f);
            (feelGoodScreen.GetFunnyWord(wId)).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (feelGoodScreen.GetFunnyWord(wId)).FitToWidth(kFitWidth);
        }

        public void PrepareRaceMeter()
        {
           ZRaceMeter.ZRaceMeterData rmData = new ZRaceMeter.ZRaceMeterData();
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) rmData.numTeams = 1;
            else rmData.numTeams = (Globals.g_world.game).GetNumPiggies() + 1;

            rmData.position = Utilities.CGPointMake(25, 200);
            rmData.markerTexture[0] = null;
            rmData.markerTexture[1] = null;
            rmData.markerTexture[2] = null;
            rmData.markerTexture[3] = null;
            rmData.trackTexture = null;
						if (Globals.useIPadBackScreens) {
                rmData.position.x -= 18.0f;
            }

            rmData.atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud);
            rmData.subtextureId[0] = (int)World.Enum4.kHU_Shaun;
            int opponentStId = 0;
            if ((Globals.g_world.game).currentOpponent == PlayerType.kPlayerPenguin) opponentStId = 6;
            else if ((Globals.g_world.game).currentOpponent == PlayerType.kPlayerOstrich) opponentStId = 5;
            else if ((Globals.g_world.game).currentOpponent == PlayerType.kPlayerPig) opponentStId = (int)World.Enum4.kHU_Piggy;
            else {
                Globals.Assert(false);
            }

            rmData.subtextureId[1] = opponentStId;
            rmData.subtextureId[2] = opponentStId;
            rmData.subtextureId[3] = opponentStId;
            raceMeter.FirstInitialisation(rmData);
            ZRaceMeter.ZRaceMeterGetReadyData rmInfo = new ZRaceMeter.ZRaceMeterGetReadyData();
            rmInfo.raceFrom = 0;
            rmInfo.raceTo = (Globals.g_world.game).finishYPos;
            raceMeter.NewGameStateGetReady(rmInfo);
            ZRaceMeter.ZRaceMeterReinitData rmrData = new ZRaceMeter.ZRaceMeterReinitData();
            rmrData.scale = 1;
            rmrData.markerScale = 1;
            rmrData.raceMeterScreenPosition = Utilities.CGPointMake(25, 200);
			rmrData.raceMeterScreenPosition.x = Globals.g_world.xScreenEdge + 21.0f;
			
            rmrData.raceMarkersScreenFrom = Utilities.CGPointMake(0, -104);
            rmrData.raceMarkersScreenTo = Utilities.CGPointMake(0, 94.0f);
            rmrData.useLocator = false;
						if (Globals.useIPadBackScreens) {
                rmrData.raceMeterScreenPosition.x -= 18.0f;
            }

            raceMeter.ReInit(rmrData);
        }

        public void NewGameStateGamePlay()
        {
            whistlingBitzer.SetWaitToHide(1.0f);
            whistlingBitzer.Hide();
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Whistle);
            sunmoon.Show();
			grZob[0].StopRender();
			grZob[1].StopRender();
        }

        public void NewGameStateGetReady()
        {
			for (int i = 0; i < 2; i++)
			{
				if (directionButtonBillboard[i] == null)
				{
					directionButtonBillboard[i] = new Billboard("dirButt");
				}
				
				directionButtonBillboard[i].SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_Hud));
				directionButtonBillboard[i].SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_Hud),0);

				directionButtonBillboard[i].SetRenderQueue(11000);

				directionButtonBillboard[i].myObject.layer = LayerMask.NameToLayer("guistuff");


								float dirButtonScale = 0.9f;

								if (Globals.deviceIPhone5)
										dirButtonScale = 0.75f;

								directionButtonBillboard[i].myObject.gameObject.transform.localScale = new Vector3(dirButtonScale,dirButtonScale,1.0f);
			}
			
///			if (whirlyThingBillboard == null)
			//{
			//		whirlyThingBillboard = new Billboard();
			//}
			//	whirlyThingBillboard.SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_Hud));
			//	whirlyThingBillboard.SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_Hud),0);
			//	whirlyThingBillboard.SetRenderQueue(11000);
			//	whirlyThingBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");

			sunmoon.StopRender();
			
            ((Globals.g_world.frontEnd).profile).ClearPendingAchievements();
            showResultsScreenShown = false;
            if (whistlingBitzer == null) {
                whistlingBitzer = new Zobject();
            }

            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            zInfo.position = Utilities.CGPointMake(240.0f, 395.0f);
            zInfo.isMapObject = false;
            zInfo.texture = null;
						if (Globals.useIPadBackScreens) {
                zInfo.position.x += 5.0f;
                zInfo.position.y += 42.0f;
            }

            whistlingBitzer.Initialise(zInfo);
            whistlingBitzer.SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud));
            whistlingBitzer.SetSubTextureId((int)World.Enum4.kHU_Bitzer);
            whistlingBitzer.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            whistlingBitzer.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            whistlingBitzer.SetWaitToShow(2.1f);
            whistlingBitzer.Show();
            whistlingBitzer.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
				
            controlFade = kControlArrowFadeMax;
            this.Reset();
            bigHand.Show();
            tiltWarningTimer = 0;
            this.PrepareRaceMeter();
        }

        public void Initialise()
        {
        }

        public void SetupLevelWord()
        {
            levelWord.Reset();
            FunnyWord.WordInfo wInfo;
            wInfo.position = Utilities.CGPointMake(140, kLevelWordY);
            wInfo.scale = 0.8f;
            wInfo.isCentrePos = true;
            string inWord;
            int i;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) i = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
            else i = ((Globals.g_world.frontEnd).profile).selectedLevel;

            if (i < ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) inWord = "level\n";
            else {
                inWord = "bonus level\n";
                wInfo.position.x = 160.0f;
                wInfo.scale = 0.9f;
            }

            levelWord.SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
            levelWord.SetLineAtlas(null);
            levelWord.SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));
            levelWord.SetFont(Globals.g_world.font);
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                wInfo.position.x = 160.0f;
                wInfo.scale = 0.62f;
                levelWord.InitWithWordNewP1(wInfo, "level");
            }
            else {
                levelWord.InitWithWordP1(wInfo, inWord);
            }

            levelWord.SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
            levelWord.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            levelWord.SetColour(Constants.kColourLightblue);
            Zscore.ZscoreInfo sInfo = new Zscore.ZscoreInfo();
            sInfo.position = Utilities.CGPointMake(220, kLevelWordY - 1.0f);
            int numDigits = 1;
            if (i > 8) {
                numDigits = 2;
            }

            sInfo.numDigits = numDigits;
            levelWordNumber.Initialise(sInfo);
            levelWordNumber.SetScale(0.9f);
            levelWordNumber.ChangeNumDigits(numDigits);
            levelWordNumber.SetScore(i + 1);
            levelWordNumber.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            levelWordNumber.SetColour(Constants.kColourLightblue);
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                levelWordNumber.Disappear();
            }

        }

        public void SetupWordsForFeelGood()
        {
        }

        public bool UpdateAnotherPiggyScreen()
        {
            return anotherPiggyScreen.Update();
        }

        public bool UpdateSpeedBoostScreen()
        {
            return speedBoostScreen.Update();
        }

        public void ShowWinBackObjects()
        {
            const float kWaitToShowWinBacks = 1.5f;
            for (int i = 0; i < 3; i++) (winBackApple[i]).Disappear();

            winBackCorkTop.Disappear();
            winBackCorkMid.Disappear();
            winBackFade.Disappear();
            winBackFadeBot.Disappear();
            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                winBackFade.SetColour(Constants.darkgreen);
                winBackFadeBot.SetColour(Constants.darkgreen);
            }
            else if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMud) {
                winBackFade.SetColour(Constants.kColourBrown);
                winBackFadeBot.SetColour(Constants.kColourBrown);
            }
            else if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneIce) {
                winBackFade.SetColour(Constants.kColourLightblue);
                winBackFadeBot.SetColour(Constants.kColourLightblue);
            }
            else if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneDesert) {
                winBackFade.SetColour(Constants.kColourYellowLemon);
                winBackFadeBot.SetColour(Constants.kColourYellowLemon);
            }
            else if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMoon) {
                winBackFade.SetColour(Constants.kColourPink);
                winBackFadeBot.SetColour(Constants.kColourPink);
            }
            else {
                Globals.Assert(false);
            }

            bool areShown = false;
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                {
                    areShown = true;
                    for (int i = 0; i < 3; i++) (winBackApple[i]).Show();

                }
            }

            if (!areShown) {
                for (int i = 0; i < 3; i++) (winBackApple[i]).Disappear();

            }

            winBackCorkTop.Show();
            winBackCorkMid.Show();
            winBackFade.Show();
            winBackFadeBot.Show();
            winBackCorkTop.SetWaitToShow(kWaitToShowWinBacks);
            winBackCorkMid.SetWaitToShow(kWaitToShowWinBacks);
            winBackFade.SetWaitToShow(kWaitToShowWinBacks);
            winBackFadeBot.SetWaitToShow(kWaitToShowWinBacks);
            if (areShown) {
                for (int i = 0; i < 3; i++) (winBackApple[i]).SetWaitToShow(kWaitToShowWinBacks);

            }

            (funnyWord[(int)Enum.kHudFW_ExcellentComment]).Show();
        }

        public void NewGameState_ShowResultsWin(int inNumApples)
        {
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                int useLevel;
                if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) useLevel = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
                else useLevel = ((Globals.g_world.frontEnd).profile).selectedLevel;

                {
                    AppleWon.AppleWonInfo aInfo = new AppleWon.AppleWonInfo();
                    aInfo.position = Utilities.CGPointMake(206.0f, 204.0f);
										if (Globals.deviceIPad) {
                        aInfo.position.x += 1.0f;
                        aInfo.position.y -= 16.0f;
                    }

                    aInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureApple);
                    aInfo.timeBetweenApples = 0.2f;
                    aInfo.distanceBetweenApples = 33.0f;
                    aInfo.appleScale = 0.75f;
                    aInfo.soundEffectId = (int)Audio.Enum1.kSoundEffect_Crunch;
                    appleWon.Setup(aInfo);
                    appleWon.ShowP1(inNumApples, 0.1f);
                }
            }

        }

		public void StopRenderGameStuff()
		{
			raceMeter.StopRender();
			sunmoon.StopRender();
						if (whistlingBitzer !=null)
							whistlingBitzer.StopRender();
			//warmglow
		}

        public void ExitGameState_FeelGood()
        {
			feelGoodScreen.StopRender();
		}		
		
        public void ExitGameState_ShowLevel()
        {
            appleWon.Hide();
			showNextLevelScreen.StopRender();
			levelWord.StopRender();
			levelWordNumber.StopRender();
			bestTime.StopRender();
			time.StopRender();
			levelName.StopRender();
		}

        public void ExitGameState_ShowResultsWin()
        {
            appleWon.Hide();
			if (winScreen != null)
			{
				winScreen.StopRender();
				(funnyWord[(int)Enum.kHudFW_ExcellentComment]).StopRender();
			}
			if (loseScreen != null)
			{
				loseScreen.StopRender();
				
				for (int i=0; i < (int)Enum.kHud_NumFunnyWords; i++)
				{
					funnyWord[i].StopRender();
				}				
				piggyHead.StopRender();
			}
			bestTime.StopRender();
			time.StopRender();		
        }
		
		

        public void NewGameState_AnotherPiggy()
        {
            anotherPiggyScreen.InitialiseZobjects();
            anotherPiggyScreen.Show();
        }

        public void NewGameState_SpeedBoost()
        {
            speedBoostScreen.InitialiseZobjects();
            speedBoostScreen.Show();
        }

        public void SetupFeelGoodScreen()
        {
            const float kTopButtPos = 37.0f;
            const float kBotButtPos = 113.0f;
            if (feelGoodScreen != null) {
            }

            feelGoodScreen = new FrontEndScreen(0,Globals.g_world.frontEnd);
            feelGoodScreen.SetBackScreen((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_FullScreen_ShaunClose));
            FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo();
            bInfo.texture = null;
            bInfo.position = Utilities.CGPointMake(160.0f, kBotButtPos);
            int buttId = feelGoodScreen.AddButton(bInfo);
            int whochCgldskfid = buttId;
            (feelGoodScreen.GetButton(buttId)).SetIsClickable(false);
            (feelGoodScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FeelGood), (int)World.Enum7.kFL_CongratsSign);
            ((feelGoodScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            ((feelGoodScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            hInfo.type = (HangingButtonType) World.Enum7.kFL_Rope;
            hInfo.subTextureId = (int)World.Enum7.kFL_Rope;
            hInfo.showWobbleMultiplier = 1.75f;
            hInfo.offset = Utilities.CGPointMake(95.0f, 20.0f);
            (feelGoodScreen.GetButton(buttId)).AddHangingButton(hInfo);
            ((feelGoodScreen.GetButton(buttId)).hangingButton).SetYOffset(24.0f);
            float kWordScale = 0.46f;
            float xPos = bInfo.position.x + 4.0f;
            float y = bInfo.position.y - 3.0f;
            string inString = "";
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                inString = "ABGESCHLOSSEN\n";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                y -= 5.0f;
                kWordScale = 0.6f;
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                y -= 5.0f;
                kWordScale = 0.6f;
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                y -= 8.0f;
                kWordScale = 0.5f;
            }
            else {
                inString = "You've completed\n";
            }

            int wId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8P9(feelGoodScreen, (int) StringId.kString_Completed, Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true,
              Constants.kColourPurpleMenuBackText);
            (feelGoodScreen.GetFunnyWord(wId)).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
            (feelGoodScreen.GetFunnyWord(wId)).SetOrientationButton((feelGoodScreen.GetButton(buttId)).hangingButton);
            bInfo.position = Utilities.CGPointMake(160.0f, kTopButtPos);
            buttId = feelGoodScreen.AddButton(bInfo);
            int titleid = buttId;
            (feelGoodScreen.GetButton(buttId)).SetIsClickable(false);
            (feelGoodScreen.GetButton(buttId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FeelGood), (int)World.Enum7.kFL_LongTitle);
            ((feelGoodScreen.GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            ((feelGoodScreen.GetButton(buttId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            hInfo.showWobbleMultiplier = 1.75f;
            hInfo.offset = Utilities.CGPointMake(100.0f, 20.0f);
            (feelGoodScreen.GetButton(buttId)).AddHangingButton(hInfo);
            ((feelGoodScreen.GetButton(buttId)).hangingButton).SetYOffset(24.0f);
            kWordScale = 0.6f;
            xPos = 160;
            y = kTopButtPos + 9.0f;
            string inString2;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                inString2 = "M#H-RCHENHAFT!\n";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                kWordScale = 0.8f;
				inString2 = "nada";
			}
			else {
                inString2 = "Baa-rilliant!\n";
            }

            wId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8P9(feelGoodScreen, (int) StringId.kString_BaaRilliant, Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.
              kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString2, true, Constants.kColourLightblue);
            (feelGoodScreen.GetFunnyWord(wId)).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
            (feelGoodScreen.GetFunnyWord(wId)).SetOrientationButton((feelGoodScreen.GetButton(titleid)).hangingButton);
            int cupId = ((Globals.g_world.frontEnd).profile).GetCupFromLevel((Globals.g_world.game).playingLevel);
            string cupName = (((Globals.g_world.frontEnd).profile).GetCup(cupId)).name;
            y = kBotButtPos + 21.0f;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                kWordScale = 0.5f;
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                y -= 3.0f;
                kWordScale = 0.58f;
            }

//            char[] nsstring = new char[32];
  
			string nsstring = cupName;
//            strcat(nsstring, "!\n");
            wId = feelGoodScreen.AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, nsstring, true, Constants.kColourLightblue);
            (feelGoodScreen.GetFunnyWord(wId)).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
            (feelGoodScreen.GetFunnyWord(wId)).SetColour((((Globals.g_world.frontEnd).profile).GetCup(cupId)).fontColour);
            (feelGoodScreen.GetFunnyWord(wId)).FitToWidth(220.0f);
            (feelGoodScreen.GetFunnyWord(wId)).SetOrientationButton((feelGoodScreen.GetButton(whochCgldskfid)).hangingButton);
        }

        public void NewGameState_FeelGood()
        {
            this.Reset();
            this.SetupFeelGoodScreen();
            starCupStar.SetTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_StarCupStar));
            starCupStar.Show();
            starCupStar.QueueAction( ZobjectAction.nThrobLooping);
            radialLight.Show();
            dimAlpha = 0;
            feelGoodScreen.ShowButtons();
            feelGoodBounceTimer = 0.8f;
            if (((Globals.g_world.frontEnd).profile).preferences.soundFxOn) {
            }

//            lightBall.SetAppearAlpha(0);
  //          lightBall.SetAppearing(false);
            ((Globals.g_world.frontEnd).profile).SetFeelGoodScreenPending(false);
            ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
        }

        public void InitialiseWinBacks()
        {
            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            zInfo.position = Utilities.CGPointMake(160.0f, 50.0f);
            zInfo.isMapObject = false;
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_WinCork);
            winBackCorkTop.Initialise(zInfo);
            winBackCorkTop.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            winBackCorkTop.SetShowScale(1.25f);
            zInfo.position = Utilities.CGPointMake(160.0f, 300.0f);
            winBackCorkMid.Initialise(zInfo);
            winBackCorkMid.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
            winBackCorkMid.SetShowScale(1.25f);
            zInfo.position = Utilities.CGPointMake(160.0f, 188.0f);
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_WinFade);
            winBackFade.Initialise(zInfo);
            winBackFade.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_FadeIn);
            winBackFade.SetShowScale(3.75f);
            winBackFade.SetColour(Constants.darkgreen);
            zInfo.position = Utilities.CGPointMake(160.0f, 480.0f);
            winBackFadeBot.Initialise(zInfo);
            winBackFadeBot.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
            winBackFadeBot.SetShowScale(2.75f);
            winBackFadeBot.SetShowAlpha(0.7f);
            winBackFadeBot.SetColour(Constants.darkgreen);
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureAppleWhite);
            for (int i = 0; i < 3; i++) {
                int xPos = 100 + (69 * i);
                zInfo.position = Utilities.CGPointMake((float) xPos, 300.0f);
                (winBackApple[i]).Initialise(zInfo);
                (winBackApple[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
                (winBackApple[i]).SetShowScale(1.1f);
            }

        }

        public void Reset()
        {
            hasBeenReset = true;
            this.InitialiseGetReady();
            this.InitialiseWinBacks();
//            LightBallInfo ballInfo;
  //          ballInfo.inBallTex = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LightBall);
    //        ballInfo.inBeamTex = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LightBeam);
      //      ballInfo.rotSpeed = 0.012f;
        //    lightBall.Initialise(ballInfo);
          //  lightBall.SetAppearAlpha(0);
            //lightBall.SetAppearing(false);
            timeThrobber = 5;
            sunSwitchTimer = 0;
            sunLeftSide = false;
            dimAlpha = 0;
            dimFalling = false;
            dimGoing = false;
            Zscore.ZscoreInfo zsInfo = new Zscore.ZscoreInfo();
            zsInfo.position = Utilities.CGPointMake(160, 70);
            zsInfo.numDigits = 5;
            time.Reset();
            time.SetScale(1);
			            time.SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
			time.Initialise(zsInfo);
            time.SetDecimalPoint(2);
            time.SetColour(Constants.kColourLightblue);
            levelWordNumber.SetDigitWidth(25);
            levelWordNumber.SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
            zsInfo.position = Utilities.CGPointMake(86, 135);
            bestTime.Reset();
            bestTime.SetScale(0.5f);
			            bestTime.SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));

			bestTime.Initialise(zsInfo);
            bestTime.SetDecimalPoint(2);
            bestTime.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            bestTime.SetTimeBetweenShowingDigits(0.0f);
            bestTime.SetColour(Constants.kColourLightblue);
            FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo();
            bInfo.textureLabel = null;
            bInfo.position = Utilities.CGPointMake(263.0f, 16);
            bInfo.texture = null;
            bInfo.textureLabel = null;
            bInfo.position = Utilities.CGPointMake(85, 300);
            bInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_ButtonRetry);
            restartButton.Initialise(bInfo);
            restartButton.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
            (restartButton.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            restartButton.SetWidth(70);
            bInfo.position = Utilities.CGPointMake(260.0f, 300);
            bInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_ButtonNext);
            nextLevelButton.Initialise(bInfo);
            nextLevelButton.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (nextLevelButton.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            nextLevelButton.SetWidth(70);
			
			
            bInfo.position = Utilities.CGPointMake(60.0f, 420);
            bInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_ButtonHome);
            menuButton.Initialise(bInfo);
            menuButton.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            (menuButton.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            sunPhase = 0;
            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.position = Utilities.CGPointMake(304, 16);
			
			if (Globals.useIPadBackScreens) 
						{
                info.position.x += 20.0f;
            }
			
			info.position.x = 320.0f - (Globals.g_world.xScreenEdge + 16.0f);
			
            sunStartPos = info.position;
            info.texture = null;
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            darkTexture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kHudTexture_DarkFall);
            darkHasStartedToFall = false;
            sunmoon.Initialise(info);
            sunmoon.SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud));
            sunmoon.SetSubTextureId((int)World.Enum4.kHU_PauseButton);
			sunmoon.myAtlasBillboard.SetRenderQueue(10000);
            sunmoon.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            sunmoon.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            sunmoon.SetThrobTime(0.3f);
			
            sunmoon.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			
            info.position = Utilities.CGPointMake(20, 20);
            sunStartPos = info.position;
            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_TiltTooHigh);
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            FunnyWord.WordInfo wInfo;
            wInfo.position = Utilities.CGPointMake(252, 194);
            wInfo.scale = 0.45f;
            wInfo.isCentrePos = true;
            string inWord = "best time\n";
/*            Constants.RossColour zCol = new Constants.RossColour(0,0,0);
            zCol.cRed = (float) 250 / (float) 255;
            zCol.cGreen = (float) 252 / (float) 255;
            zCol.cBlue = (float) 85 / (float) 255;*/
            wInfo.position = Utilities.CGPointMake(160.0f, 118.0f);
            wInfo.scale = 0.85f;
            wInfo.isCentrePos = true;
            inWord = "excellent!\n";
            (funnyWord[(int)Enum.kHudFW_ExcellentComment]).InitWithWordP1(wInfo, inWord);
            (funnyWord[(int)Enum.kHudFW_ExcellentComment]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
            (funnyWord[(int)Enum.kHudFW_ExcellentComment]).SetColour(Constants.kColourLightblue);
            wInfo.position = Utilities.CGPointMake(124.0f, 176.0f);
            wInfo.scale = 0.5f;
            wInfo.isCentrePos = true;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                inWord = "Bestzeit\n";
            }
            else {
                inWord = "best time\n";
            }

            (funnyWord[(int)Enum.kHudFW_bestTime]).InitWithWordP1(wInfo, inWord);
            (funnyWord[(int)Enum.kHudFW_bestTime]).SetColour(Constants.kColourLightblue);
            wInfo.position = Utilities.CGPointMake(235.0f, 103.0f);
            wInfo.scale = 0.5f;
            wInfo.isCentrePos = true;
            inWord = "time\n";
            (funnyWord[(int)Enum.kHudFW_time]).InitWithWordP1(wInfo, inWord);
            (funnyWord[(int)Enum.kHudFW_time]).SetColour(Constants.kColourLightblue);
            ohno.Reset();
            this.SetupLevelWord();
          //  LetterInfo lInfo;
            const float kStartPosForward = 50.0f;

            #if RACE_AS_PIGGY
                if (Constants.RECORDING_WHICH_PIGGY == 0) info.position = Utilities.CGPointMake(120, 40 + kStartPosForward);
                else if (Constants.RECORDING_WHICH_PIGGY == 1) {
                    info.position = Utilities.CGPointMake(120, -20 + kStartPosForward);
                }
                else if (Constants.RECORDING_WHICH_PIGGY == 2) {
                    info.position = Utilities.CGPointMake(180, 40 + kStartPosForward);
                }
                else if (Constants.RECORDING_WHICH_PIGGY == 3) {
                    info.position = Utilities.CGPointMake(120, 100 + kStartPosForward);
                }
                else if (Constants.RECORDING_WHICH_PIGGY == 4) {
                    info.position = Utilities.CGPointMake(180, 100 + kStartPosForward);
                }
                else {
                    Globals.Assert(false);
                    info.position = Utilities.CGPointMake(120, 40 + kStartPosForward);
                }

            #else
                info.position = Utilities.CGPointMake(188, -20 + kStartPosForward);
                if ((Globals.g_world.frontEnd).exitInfo.multiplayer) {
                }

            #endif

            #if HAND_DANGLE
                info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_HandClosed);
            #else
                info.texture = null;
            #endif

            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = true;
            bigHand.Initialise(info);
            bigHand.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            bigHand.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            bigHand.SetIsFloaty(true);
            bigHand.SetShowScale((300 / 256));
            info.position = Utilities.CGPointMake(160, kWordStartHeight);
            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_HudWordTerrific);
            info.startState = ZobjectState.kZobjectShown;
            info.isMapObject = false;
            Zobject.ZgravityInfo gInfo = new Zobject.ZgravityInfo();
            gInfo.gravity = 0.4f;
            gInfo.bounce = 0.25f;
            gInfo.yStartVelocity = -2;
            gInfo.floorLevel = 41;
            info.position = Utilities.CGPointMake(160, 452);
            info.texture = null;
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            pauseBack.SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud));
            pauseBack.SetSubTextureId((int)Globals.g_world.GetIPadSubTexture((int)World.Enum4.kHU_PauseBar));
            pauseBack.Initialise(info);
            pauseBack.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            pauseBack.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
			pauseBack.myAtlasBillboard.SetRenderQueue(10000);
            info.position = Utilities.CGPointMake(280, 40);
            info.texture = (Globals.g_world.frontEnd).GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_TrophyGold);
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            info.position = Utilities.CGPointMake(230, 190);
            info.texture = null;
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
							if (piggyHead == null)
				{
					piggyHead = new Zobject();
				}

            piggyHead.Initialise(info);
            piggyHead.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            piggyHead.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            piggyHead.SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_PigOinkLaugh);
            piggyHead.SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_RaceLose));
           // piggyHead.SetSubTextureId((int)(int)World.Enum5.kRL_Piggy);
            info.position = Utilities.CGPointMake(65, 185);
            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_SheepyHead);
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            sheepyHead.Initialise(info);
            sheepyHead.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            sheepyHead.SetShowScale(0.9f);
            info.position = Utilities.CGPointMake(160, 300);
            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_StarCupStar);
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            starCupStar.Initialise(info);
            starCupStar.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_ZoomAndWobble);
            starCupStar.SetShowScale(1.0f);
            starCupStar.SetThrobSize(0.04f);
            starCupStar.SetThrobTime(1.1f);
            info.position = Utilities.CGPointMake(160, 300);
            info.texture = (Globals.g_world.frontEnd).GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_TrophyGlow);
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            radialLight.Initialise(info);
            radialLight.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_FadeIn);
            radialLight.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            radialLight.SetShowScale(1.55f);
            radialLight.SetHasSpin(0.01f);
            radialLight.SetThrobSize(0.04f);
            radialLight.SetThrobTime(1.1f);
            radialLight.SetShowAlpha(0.6f);
            info.position = Utilities.CGPointMake(160, 142);
            info.texture = null;
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            piggyCommentBubble.Initialise(info);
            piggyCommentBubble.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            piggyCommentBubble.SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_RaceLose));
            //piggyCommentBubble.SetSubTextureId((int)(int)World.Enum5.kRL_Sign);
            int i = 0;
            int x = 100;
            int y = 150;
            int wordGap = 23;
			
			
         /*   lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_O);
            lInfo.position = Utilities.CGPointMake(x + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_h);
            lInfo.position = Utilities.CGPointMake(x + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_N);
            lInfo.position = Utilities.CGPointMake(x + 20 + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_o);
            lInfo.position = Utilities.CGPointMake(x + 20 + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_exclam);
            lInfo.position = Utilities.CGPointMake(x + 20 + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            x = 80;
            y = 205;
            i = 0;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_T);
            lInfo.position = Utilities.CGPointMake(x + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_o);
            lInfo.position = Utilities.CGPointMake(x + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_o);
            lInfo.position = Utilities.CGPointMake(x + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_s);
            lInfo.position = Utilities.CGPointMake(x + 20 + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_l);
            lInfo.position = Utilities.CGPointMake(x + 20 + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_o);
            lInfo.position = Utilities.CGPointMake(x + 20 + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_w);
            lInfo.position = Utilities.CGPointMake(x + 20 + (i * wordGap), y);
            ohno.AddLetter(lInfo);
            i++;
            lInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_OhNo_exclam);
            lInfo.position = Utilities.CGPointMake(x + 20 + (i * wordGap), y);
            ohno.AddLetter(lInfo);*/
			

        }

        public void ShrinkHudButtonsForWin()
        {
            const float kShrinkRatio = 0.76f;
            float currentScale = (restartButton.zobject).GetShowScale();
            (restartButton.zobject).SetShowScale((currentScale * kShrinkRatio));
            currentScale = (nextLevelButton.zobject).GetShowScale();
            (nextLevelButton.zobject).SetShowScale((currentScale * kShrinkRatio));
            currentScale = (menuButton.zobject).GetShowScale();
            (menuButton.zobject).SetShowScale((currentScale * kShrinkRatio));
        }

        public void ShowHudButtons(bool isWin)
        {
			
			raceMeter.StopRender();

			
            #if RUN_PROFILE_TEST
                Globals.Assert(false);
            #endif

            showResultsScreenShown = true;
            int useLevel;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) useLevel = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
            else useLevel = ((Globals.g_world.frontEnd).profile).selectedLevel;

            int nextLevel = useLevel + 1;
            if (nextLevel < (int)(Profile.Enum6.kNumLevels - Profile.Enum6.kNumBonusLevels)) {
                canPlayNextLevel = ((Globals.g_world.frontEnd).profile).CanPlayNextLevel(nextLevel);
            }
            else if (nextLevel == (int)(Profile.Enum6.kNumLevels - Profile.Enum6.kNumBonusLevels)) {
                if ((isWin) && ((Globals.g_world.game).numApplesBeforeRace == 0)) {
                    canPlayNextLevel = true;
                }
                else {
                    canPlayNextLevel = false;
                }

            }
            else canPlayNextLevel = false;

            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                if (nextLevel < (int)(Profile.Enum6.kNumLevels - Profile.Enum6.kNumBonusLevels)) {
                    if (((Globals.g_world.frontEnd).profile).IsCustomLevelMade(nextLevel)) {
                        canPlayNextLevel = true;
                    }
                    else {
                        canPlayNextLevel = false;
                    }

                }
                else {
                    canPlayNextLevel = false;
                }

            }

            #if CAN_ALWAYS_PLAY_NEXT_LEVEL
                if (((Globals.g_world.frontEnd).profile).IsLevelUnlocked(nextLevel)) {
                    if (nextLevel < (int)Profile.Enum6.kNumLevels) canPlayNextLevel = true;

                }

            #endif

            restartButton.ChangePosition(Utilities.CGPointMake(160.0f, kBottomLineButtsPos));
            if (isWin) {
                restartButton.ChangePosition(Utilities.CGPointMake(160.0f, kBottomLineButtsPos));
            }

            (restartButton.zobject).SetWaitToShow(1.8f);
            restartButton.Show();
            restartButton.NotClickableTilShown();
            CGPoint pos = Utilities.CGPointMake((restartButton.zobject).screenPosition.x, (restartButton.zobject).screenPosition.y);
            pos.x -= 150;
            (restartButton.zobject).SetScreenPosition(pos);
            if ((Globals.g_world.game).gameState !=  GameState.e_ShowResultsWin) {
                (restartButton.zobject).SetShowScale(kScaleForButtonsWin);
                (restartButton.zobject).SetFlashTime(0.12f);
                (restartButton.zobject).QueueAction( ZobjectAction.nFlash);
            }
            else {
                (restartButton.zobject).SetShowScale(kScaleForButtonsWin);
            }

            if (canPlayNextLevel) {
                nextLevelButton.ChangeTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_ButtonNext));
                nextLevelButton.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
                nextLevelButton.ChangePosition(Utilities.CGPointMake(260.0f, kBottomLineButtsPos));
                if (isWin) {
                }

                (nextLevelButton.zobject).SetWaitToShow(1.8f);
                nextLevelButton.Show();
                nextLevelButton.NotClickableTilShown();
                if ((Globals.g_world.game).gameState == GameState.e_ShowResultsWin) {
                    (nextLevelButton.zobject).SetShowScale(kScaleForButtonsWin);
                    (nextLevelButton.zobject).SetFlashTime(0.12f);
                    (nextLevelButton.zobject).QueueAction( ZobjectAction.nFlash);
                }
                else (nextLevelButton.zobject).SetShowScale(kScaleForButtonsNotWin);

            }
            else {
                if (isWin) {
                    (winScreen.GetButton(nextLevelButtonId)).Disappear();
                }
                else {
                    (loseScreen.GetButton(nextLevelButtonId)).Disappear();
                }

            }

            menuButton.ChangePosition(Utilities.CGPointMake(60.0f, kBottomLineButtsPos));
            if (isWin) {
            }

            (menuButton.zobject).SetWaitToShow(2);
            menuButton.Show();
            menuButton.NotClickableTilShown();
            (menuButton.zobject).SetShowScale(kScaleForButtonsNotWin);
            if (isWin) {
                (menuButton.zobject).SetShowScale(kScaleForButtonsWin);
            }

        }

        public void ShowRosette(int place)
        {
        }

        public void ShowLevelName(float pauseBefore)
        {
            string inString = "";
			string nsstring;// = new char[32];
            bool useNS = false;
			string useNsstring = "";
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    useNS = true;
                    useNsstring = ((Globals.g_world.frontEnd).profile).GetLevelNameString(((Globals.g_world.frontEnd).profile).selectedLevel);
                }
                else {
                    inString = ((Globals.g_world.frontEnd).profile).GetLevelName(((Globals.g_world.frontEnd).profile).selectedLevel);
                }

            }
            else {
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    useNS = true;
                    useNsstring = ((Globals.g_world.frontEnd).profile).GetCustomLevelName();
                }
                else {
                    nsstring = (((Globals.g_world.frontEnd).profile).GetCustomLevelName());
                    //strcat(nsstring, "\n");
                    inString = nsstring;
                }

            }

            Constants.RossColour inColour = ((Globals.g_world.frontEnd).profile).GetLevelColour(((Globals.g_world.frontEnd).profile).selectedLevel);
            if (useNS) {
                levelName.ChangeTextNew(useNsstring);
            }
            else {
                levelName.ChangeText(inString);
            }

            levelName.FitToWidth(240);
            levelName.SetColour(inColour);
            levelName.SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
            levelName.Show();
        }

        public void ShowNextLevel()
        {
            Globals.g_world.DisappearLeaderBoardThing();
            this.SetupShowNextLevelScreen();
            showNextLevelScreen.ShowButtons();
            (showNextLevelScreen.GetButton(tipButtonId)).Disappear();
            int nextLevelToPlay;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) nextLevelToPlay = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
            else {
                nextLevelToPlay = ((Globals.g_world.frontEnd).profile).selectedLevel;
                {
                    AppleWon.AppleWonInfo aInfo = new AppleWon.AppleWonInfo();
                    aInfo.position = Utilities.CGPointMake(210.0f, 204.0f);
										if (Globals.deviceIPad) {
                        aInfo.position.x += 1.0f;
                        aInfo.position.y -= 16.0f;
                    }

                    aInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureApple);
                    aInfo.timeBetweenApples = 0.2f;
                    aInfo.distanceBetweenApples = 33.0f;
                    aInfo.appleScale = 0.8f;
                    aInfo.soundEffectId = (int)Audio.Enum1.kSoundEffect_Crunch;
                    appleWon.Setup(aInfo);
                    int trophyThisRace = (int)((Globals.g_world.frontEnd).profile).GetTrophyGot(nextLevelToPlay);
                    appleWon.ShowP1((int)Utilities.GetNumApplesFromTrophy(trophyThisRace), 1.0f);
                }
                if (((Globals.g_world.frontEnd).profile).HasRaceTip(nextLevelToPlay) != (int)Profile.Enum3.kHud_NoRaceTip) {
                    (showNextLevelScreen.GetButton(tipButtonId)).Show();
                }

            }

            float theScore = ((Globals.g_world.frontEnd).profile).GetCurrentBestTime(nextLevelToPlay);
            if (theScore < 1000.0f) {
                Zscore.ZscoreInfo zsInfo = new Zscore.ZscoreInfo();
                zsInfo.position = Utilities.CGPointMake(81, 239);
                zsInfo.numDigits = 5;
                time.Reset();
                time.SetScale(0.5f);
                time.Initialise(zsInfo);
                time.SetScore(theScore);
                time.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                time.SetTimeBetweenShowingDigits(0.0f);
                time.Show();
            }
            else {
            }

            float pauseBefore = 0;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                string levelString = String.Format("第{0}关", nextLevelToPlay + 1);
                levelWord.ChangeTextNew(levelString);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                string levelString = String.Format("レベル{0}", nextLevelToPlay + 1);
                levelWord.ChangeTextNew(levelString);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                string levelString = String.Format("Niveau {0}", nextLevelToPlay + 1);
                levelWord.ChangeTextNew(levelString);
            }

            levelWord.SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
            levelWord.Show(pauseBefore);
            if (nextLevelToPlay < ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) {
                if (!Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    levelWordNumber.Show();
                }

            }
            else {
                levelWordNumber.Disappear();
            }

            this.ShowLevelName(pauseBefore);
        }

        public void ShowTimeUp()
        {
            this.ShowHudButtons(false);
            ohno.Show();
        }

        public void ShowInGameButtonsLoseTooSlow()
        {
            ohno.Show();
            this.ShowHudButtons(false);
        }

        string GetPiggyWords_ChineseP1P2(float pigYPlus, int randNum, int inLine)
        {
            string[] outWords = new string[3];
            for (int i = 0; i < 3; i++) {
                outWords[i] = "";
            }

            switch (randNum) {
            case 0 :
                outWords[0] = "去给我织";
                outWords[1] = "一件毛衣！";
                break;
            case 1 :
                outWords[0] = "啊，";
                outWords[1] = "差之毫厘！";
                break;
            case 2 :
                outWords[0] = "呼呼呼呼呼";
                pigYPlus = 20.0f;
                break;
            case 3 :
                outWords[0] = "馋嘴";
                outWords[1] = "的羊！";
                break;
            case 4 :
                outWords[0] = "老子才是原";
                outWords[1] = "版的路霸！";
                break;
            default :
                outWords[0] = "太慢了，";
                outWords[1] = "胖子！";
                break;
            }

            return outWords[inLine];
        }
		
string GetPiggyWords_French(float pigYPlus, int randNum, int inLine)
        {
            string[] outWords = new string[3];
            for (int i = 0; i < 3; i++) {
                outWords[i] = "";
            }

            switch (randNum) {
            case 0 :
                outWords[0] = "trop lent,";
                outWords[1] = "laine à pattes !";//"綿毛野郎！";
                break;
            case 1 :
                outWords[0] = "va jouer";//"「ジャンパーで";
                outWords[1] = "à";//"も織ってりゃ";
                outWords[2] = "saute mouton !";				
                pigYPlus = 22.0f;
                break;
            case 2 :
                outWords[0] = "dommage, c’était";//"「あぁーあ、";
                outWords[1] = "à un poil!";//"惜しかったなぁ」";
                break;
            case 3 :
                outWords[0] = "un mouton qui";//"「zzzzzzzzzzz」";
                outWords[1] = "se fait";//"「zzzzzzzzzzz」";
                outWords[2] = "passer pour un agneau!";//"「zzzzzzzzzzz」";
                pigYPlus = 22.0f;
                break;
            case 4 :
                outWords[0] = "zzzzzzzzzzz";//"「マトン食わ";
                break;
            case 5 :
                outWords[0] = "qu'on le";//"「なんか眠";
                outWords[1] = "tonde!";//"くなってきた」";
                break;
            case 6 :
                outWords[0] = "il a les";//"「なんか眠";
                outWords[1] = "nerfs";//"くなってきた」";
                outWords[2] = "en pelote !";//"くなってきた」";
                break;
            case 7 :
                outWords[0] = "porc à";//"「なんか眠";
                outWords[1] = "bon port!";//"くなってきた」";
                break;
            default :
                outWords[0] = "cherche pas,";//"俺様が元祖豚";
                outWords[1] = "c’est moi!";//"レーサーだっ！";
                break;
            }

            return outWords[inLine];
        }		
		
        string GetPiggyWords_JapaneseP1P2(float pigYPlus, int randNum, int inLine)
        {
            string[] outWords = new string[3];
            for (int i = 0; i < 3; i++) {
                outWords[i] = "";
            }

            switch (randNum) {
            case 0 :
                outWords[0] = "遅すぎるぜ！";
                outWords[1] = "綿毛野郎！";
                break;
            case 1 :
                outWords[0] = "「ジャンパーで";
                outWords[1] = "も織ってりゃ";
                outWords[2] = "いいんだよ！」";
                pigYPlus = 22.0f;
                break;
            case 2 :
                outWords[0] = "「あぁーあ、";
                outWords[1] = "惜しかったなぁ」";
                break;
            case 3 :
                outWords[0] = "「zzzzzzzzzzz」";
                pigYPlus = 22.0f;
                break;
            case 4 :
                outWords[0] = "「マトン食わ";
                outWords[1] = "すぞっ！」";
                break;
            case 5 :
                outWords[0] = "「なんか眠";
                outWords[1] = "くなってきた」";
                break;
            default :
                outWords[0] = "俺様が元祖豚";
                outWords[1] = "レーサーだっ！";
                break;
            }

            return outWords[inLine];
        }

        float ShowPiggyWords()
        {
            int numLines = 1;
            FunnyWord.WordInfo wInfo1;
            wInfo1.scale = 0.9f;
            wInfo1.position = Utilities.CGPointMake(140, 140);
            wInfo1.isCentrePos = true;
            FunnyWord.WordInfo wInfo2;
            wInfo2.scale = 1.0f;
            wInfo2.isCentrePos = true;
            FunnyWord.WordInfo wInfo3;
            wInfo3.scale = 1.0f;
            wInfo3.isCentrePos = true;
            string inWord1 = "";
            string inWord2 = "";
            string inWord3 = "";
            const float kPigPlus = 18.0f;
            float pigPlusY = 0.0f;
            string[] inNSString = new string[3];
            for (int i = 0; i < 3; i++) {
                inNSString[i] = "";
            }

            if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                int randNum = Utilities.GetRand( 6);
                for (int i = 0; i < 3; i++) {
                    inNSString[i] = this.GetPiggyWords_ChineseP1P2(pigPlusY, randNum, i);
                }

            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                int randNum = Utilities.GetRand( 7);
                for (int i = 0; i < 3; i++) {
                    inNSString[i] = this.GetPiggyWords_JapaneseP1P2(pigPlusY, randNum, i);
                }

            }
			else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                int randNum = Utilities.GetRand( 9);
                for (int i = 0; i < 3; i++) {
                    inNSString[i] = this.GetPiggyWords_French(pigPlusY, randNum, i);
                }

            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                int randNum = Utilities.GetRand( 9);
                switch (randNum) {
                case 0 :
                    inWord1 = "geh 'nen\n";
                    inWord2 = "pullover\n";
                    inWord3 = "stricken!\n";
                    numLines = 3;
                    wInfo1.scale = 0.95f;
                    wInfo2.scale = 0.85f;
                    wInfo3.scale = 0.82f;
                    pigPlusY = kPigPlus + 2.0f;
                    break;
                case 1 :
                    inWord1 = "ohh das\n";
                    inWord2 = "war\n";
                    inWord3 = "haarschaf!\n";
                    numLines = 3;
                    wInfo1.scale = 0.9f;
                    wInfo2.scale = 0.85f;
                    wInfo3.scale = 0.65f;
                    break;
                case 2 :
                    inWord1 = "du\n";
                    inWord2 = "alter\n";
                    inWord3 = "bock!\n";
                    numLines = 3;
                    wInfo1.scale = 1.1f;
                    wInfo2.scale = 0.88f;
                    wInfo3.scale = 1.1f;
                    pigPlusY = 20.0f;
                    break;
                case 3 :
                    inWord1 = "zzzzzzz\n";
                    pigPlusY = 15.0f;
                    wInfo1.scale = 1.0f;
                    break;
                case 4 :
                    inWord1 = "heut\n";
                    inWord2 = "gibt's\n";
                    inWord3 = "LAMMBRATEN!\n";
                    numLines = 3;
                    wInfo1.scale = 0.9f;
                    wInfo2.scale = 0.75f;
                    wInfo3.scale = 0.6f;
                    break;
                case 5 :
                    inWord1 = "hast du zu\n";
                    inWord2 = "viele SCHAFE\n";
                    inWord3 = "GEZ#HLT?\n";
                    numLines = 3;
                    wInfo1.scale = 0.8f;
                    wInfo2.scale = 0.6f;
                    wInfo3.scale = 0.8f;
                    pigPlusY = kPigPlus;
                    break;
                case 6 :
                    inWord1 = "ZU\n";
                    inWord2 = "LAHM\n";
                    inWord3 = "WATTEBAUSCH!\n";
                    numLines = 3;
                    wInfo1.scale = 1.1f;
                    wInfo2.scale = 0.8f;
                    wInfo3.scale = 0.55f;
                    pigPlusY = kPigPlus;
                    break;
                case 7 :
                    inWord1 = "ICH HAB DEN\n";
                    inWord2 = "SCHWEINSGALOPP\n";
                    inWord3 = "EBEN DRAUF!\n";
                    numLines = 3;
                    wInfo1.scale = 0.7f;
                    wInfo2.scale = 0.5f;
                    wInfo3.scale = 0.64f;
                    pigPlusY = kPigPlus;
                    break;
                default :
                    inWord1 = "SCHWEIN\n";
                    inWord2 = "GEHABT!\n";
                    numLines = 2;
                    wInfo1.scale = 1.0f;
                    wInfo2.scale = 0.85f;
                    wInfo3.scale = 1.1f;
                    break;
                }

            }
            else {
                if ((Globals.g_world.game).currentOpponent == PlayerType.kPlayerPenguin) {
                    int randNum = Utilities.GetRand( 6);
                    switch (randNum) {
                    case 0 :
                        inWord1 = "this ain't figure\n";
                        inWord2 = "skating!\n";
                        numLines = 2;
                        break;
                    case 1 :
                        inWord1 = "landlubber ahoy!\n";
                        break;
                    default :
                        inWord1 = "ice cold baby!\n";
                        break;
                    }

                }
                else if ((Globals.g_world.game).currentOpponent == PlayerType.kPlayerOstrich) {
                    int randNum = Utilities.GetRand( 6);
                    switch (randNum) {
                    case 0 :
                        inWord1 = "you got\n";
                        inWord2 = "sand blasted!\n";
                        numLines = 2;
                        break;
                    case 1 :
                        inWord1 = "oh were you\n";
                        inWord2 = "racing too?\n";
                        numLines = 2;
                        break;
                    case 2 :
                        inWord1 = "look who's last in\n";
                        inWord2 = "the pecking order!\n";
                        numLines = 2;
                        break;
                    case 3 :
                        inWord1 = "that was poultry\n";
                        inWord2 = "in motion!\n";
                        numLines = 2;
                        break;
                    default :
                        inWord1 = "too hot for\n";
                        inWord2 = "you?\n";
                        numLines = 2;
                        break;
                    }

                }
                else {
                    int randNum = Utilities.GetRand( 11);
                    int blah = 0;
                    randNum = blah;
                    blah++;
                    switch (randNum) {
                    case 0 :
                        inWord1 = "go knit\n";
                        inWord2 = "me a\n";
                        inWord3 = "jumper!\n";
                        numLines = 3;
                        wInfo1.scale = 1.06f;
                        wInfo2.scale = 0.9f;
                        wInfo3.scale = 0.85f;
                        break;
                    case 1 :
                        inWord1 = "awww\n";
                        inWord2 = "that was\n";
                        inWord3 = "woolly close!\n";
                        numLines = 3;
                        wInfo1.scale = 1.12f;
                        wInfo2.scale = 0.85f;
                        wInfo3.scale = 0.55f;
                        pigPlusY = kPigPlus;
                        break;
                    case 2 :
                        inWord1 = "mutton\n";
                        inWord2 = "dressed\n";
                        inWord3 = "as lamb!\n";
                        numLines = 3;
                        wInfo1.scale = 1.1f;
                        wInfo2.scale = 0.95f;
                        wInfo3.scale = 0.75f;
                        pigPlusY = kPigPlus + 4.0f;
                        break;
                    case 3 :
                        inWord1 = "zzzzzzz\n";
                        pigPlusY = 15.0f;
                        wInfo1.scale = 1.0f;
                        break;
                    case 4 :
                        inWord1 = "mutton\n";
                        inWord2 = "for\n";
                        inWord3 = "punishment!\n";
                        numLines = 3;
                        wInfo1.scale = 0.9f;
                        wInfo2.scale = 0.75f;
                        wInfo3.scale = 0.65f;
                        break;
                    case 5 :
                        inWord1 = "feeling\n";
                        inWord2 = "a bit\n";
                        inWord3 = "sheepish?\n";
                        numLines = 3;
                        wInfo1.scale = 0.9f;
                        wInfo2.scale = 0.75f;
                        wInfo3.scale = 0.7f;
                        break;
                    case 6 :
                        inWord1 = "look who\n";
                        inWord2 = "got\n";
                        inWord3 = "hogswalloped!\n";
                        numLines = 3;
                        wInfo1.scale = 0.86f;
                        wInfo2.scale = 0.8f;
                        wInfo3.scale = 0.55f;
                        break;
                    case 7 :
                        inWord1 = "i'm the\n";
                        inWord2 = "original\n";
                        inWord3 = "road hog!\n";
                        numLines = 3;
                        pigPlusY = 18.0f;
                        wInfo1.scale = 0.9f;
                        wInfo2.scale = 0.7f;
                        wInfo3.scale = 0.82f;
                        break;
                    default :
                        inWord1 = "too\n";
                        inWord2 = "slow\n";
                        inWord3 = "fluffy!\n";
                        numLines = 3;
                        wInfo1.scale = 1.05f;
                        wInfo2.scale = 0.85f;
                        wInfo3.scale = 1.1f;
                        break;
                    }

                }

            }

            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                numLines = 0;
                for (int i = 0; i < 3; i++) {
                    if ((inNSString[i]) != ("")) {
                        numLines++;
                    }

                }

                wInfo1.scale *= 0.6f;
                wInfo2.scale *= 0.6f;
                wInfo3.scale *= 0.6f;
            }

            if (numLines == 3) {
                wInfo1.position.y = 102;
                wInfo2.position = Utilities.CGPointMake(140, 152);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).InitWithWordOrStringP1P2(wInfo2, inWord2, inNSString[1]);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).SetColour(Constants.kColourRed);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).Show();
                wInfo3.position = Utilities.CGPointMake(140, 202);
                (funnyWord[(int)Enum.kHudFW_PiggyComment3]).InitWithWordOrStringP1P2(wInfo3, inWord3, inNSString[2]);
                (funnyWord[(int)Enum.kHudFW_PiggyComment3]).SetColour(Constants.kColourRed);
                (funnyWord[(int)Enum.kHudFW_PiggyComment3]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
                (funnyWord[(int)Enum.kHudFW_PiggyComment3]).Show();
            }
            else if (numLines == 2) {
                wInfo1.position.y = 120;
                wInfo2.position = Utilities.CGPointMake(140, 180);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).InitWithWordOrStringP1P2(wInfo2, inWord2, inNSString[1]);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).SetColour(Constants.kColourRed);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).Show();
                (funnyWord[(int)Enum.kHudFW_PiggyComment3]).Disappear();
            }
            else {
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).Disappear();
                (funnyWord[(int)Enum.kHudFW_PiggyComment3]).Disappear();
            }

            (funnyWord[(int)Enum.kHudFW_PiggyComment1]).InitWithWordOrStringP1P2(wInfo1, inWord1, inNSString[0]);
            (funnyWord[(int)Enum.kHudFW_PiggyComment1]).SetColour(Constants.kColourRed);
            (funnyWord[(int)Enum.kHudFW_PiggyComment1]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
            (funnyWord[(int)Enum.kHudFW_PiggyComment1]).Show();
			
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                (funnyWord[(int)Enum.kHudFW_PiggyComment1]).FitToWidth(200.0f);
                (funnyWord[(int)Enum.kHudFW_PiggyComment2]).FitToWidth(200.0f);
                (funnyWord[(int)Enum.kHudFW_PiggyComment3]).FitToWidth(200.0f);
            }

            return pigPlusY;
        }

        public void ShowInGameButtonsLoseToPiggy()
        {
            sunmoon.Hide();
            this.SetupLoseScreen();
            loseScreen.ShowButtons();
            waitToShowGlow = 0.0f;
            
										if (piggyHead == null)
				{
					piggyHead = new Zobject();
				}

			
			piggyHead.SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_RaceLose));
            piggyHead.SetSubTextureId((int)(int)World.Enum5.kRL_Piggy);
			piggyHead.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
            float piggyX = 260.0f;
						if (Globals.useIPadBackScreens) {
                piggyX = 274.0f;
            }

            float piggyPlus = this.ShowPiggyWords();
            piggyHead.SetPosition(Utilities.CGPointMake(piggyX, 215.0f + piggyPlus));
            piggyHead.Show();
            piggyHead.SetWaitToShow(0.1f);
            this.ShowHudButtons(false);
            this.ShowWinBackObjects();
//                    (funnyWord[(int)Enum.kHudFW_PiggyComment1]).Show();
  //                  (funnyWord[(int)Enum.kHudFW_PiggyComment2]).Show();
    //                (funnyWord[(int)Enum.kHudFW_PiggyComment3]).Show();
        }
		
		string GetSuccessWord_French(int finishedPosition)
        {
            string[] successWord = new string[5];
            int numChoices;
            switch (finishedPosition) {
            case 3 :
                numChoices = 3;
                successWord[0] = "Super!";
                successWord[1] = "Bien!";
                successWord[2] = "よくやBien joué!";
                break;
            case 2 :
                numChoices = 3;
                successWord[0] = "Excellent!";
                successWord[1] = "Magnifique!";
                successWord[2] = "Superbe!";
                break;
            case 1 :
                numChoices = 5;
                successWord[0] = "En or!";
                successWord[1] = "Wonder-mouton!";
                successWord[2] = "La star!";
                successWord[3] = "Incroyable!";
                successWord[4] = "Fantastique!";
                break;
            default :
                numChoices = 1;
                successWord[0] = "Grand!";
                break;
            }

            int whichW = Utilities.GetRand( numChoices);
            return successWord[whichW];
        }
		
        string GetSuccessWord_Japanese(int finishedPosition)
        {
            string[] successWord = new string[5];
            int numChoices;
            switch (finishedPosition) {
            case 3 :
                numChoices = 3;
                successWord[0] = "グレート!";
                successWord[1] = "グッド!";
                successWord[2] = "よくやった!";
                break;
            case 2 :
                numChoices = 3;
                successWord[0] = "エクセレント!";
                successWord[1] = "素晴らしい!";
                successWord[2] = "お見事!";
                break;
            case 1 :
                numChoices = 5;
                successWord[0] = "ゴールデン!";
                successWord[1] = "ワンダー・ウール!";
                successWord[2] = "羊の星!";
                successWord[3] = "信じられない!";
                successWord[4] = "ファンタスティック!";
                break;
            default :
                numChoices = 1;
                successWord[0] = "Grand!";
                break;
            }

            int whichW = Utilities.GetRand( numChoices);
            return successWord[whichW];
        }

        string GetSuccessWord_Chinese(int finishedPosition)
        {
            string[] successWord = new string[5];
            int numChoices;
            switch (finishedPosition) {
            case 3 :
                numChoices = 3;
                successWord[0] = "真好!";
                successWord[1] = "不错!";
                successWord[2] = "干得好!";
                break;
            case 2 :
                numChoices = 3;
                successWord[0] = "非常棒!";
                successWord[1] = "太出色了!";
                successWord[2] = "超级优秀!";
                break;
            case 1 :
                numChoices = 5;
                successWord[0] = "绝佳的!";
                successWord[1] = "奇迹之羊!";
                successWord[2] = "羊之星!";
                successWord[3] = "难以置信!";
                successWord[4] = "好极了!";
                break;
            default :
                numChoices = 1;
                successWord[0] = "肖恩获胜!";
                break;
            }

            int whichW = Utilities.GetRand( numChoices);
            return successWord[whichW];
        }

        public void SetSuccessWord()
        {
            int useLevel;
            int howGood;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                useLevel = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
                howGood = 2 + Utilities.GetRand( 2);
            }
            else {
            }

            int finishedPosition = ((Globals.g_world.game).player).finishPosition;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                finishedPosition = 2 + Utilities.GetRand( 2);
            }

            const int kMaxChoices = 5;
            int numChoices = -1;
            string[] successWord = new string[kMaxChoices];
            float[] wordScale = new float[kMaxChoices];
            string successNSString = "";
            for (int i = 0; i < kMaxChoices; i++) {
                wordScale[i] = 0.85f;
            }

            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                switch (finishedPosition) {
                case 3 :
                    numChoices = 3;
                    successWord[0] ="SUPER!\n";
                    successWord[1] ="TOLL!\n";
                    successWord[2] ="GUT GEMACHT!\n";
                    break;
                case 2 :
                    numChoices = 3;
                    successWord[0] ="AUSGEZEICHNET!\n";
                    successWord[1] ="GROssARTIG!\n";
                    successWord[2] ="HERVORRAGEND!\n";
                    break;
                case 1 :
                    numChoices = 5;
                    successWord[0] ="EINSAME SPITZE!\n";
                    successWord[1] ="WUNDER'WOLL!\n";
                    successWord[2] ="HELD DER HERDE!\n";
                    successWord[3] ="UNGLAUBLICH!\n";
                    successWord[4] ="FANTASTISCH!\n";
                    break;
                default :
                    numChoices = 3;
                    successWord[0] ="Awesome!\n";
                    successWord[1] ="Brilliant!\n";
                    successWord[2] ="Shining Star!\n";
                    break;
                }

            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                successNSString = this.GetSuccessWord_Chinese(finishedPosition);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                successNSString = this.GetSuccessWord_French(finishedPosition);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                successNSString = this.GetSuccessWord_Japanese(finishedPosition);
            }
            else {
                switch (finishedPosition) {
                case 3 :
                    numChoices = 3;
                    successWord[0] ="Great!\n";
                    successWord[1] ="Good!\n";
                    successWord[2] ="Well Done!\n";
                    break;
                case 2 :
                    numChoices = 3;
                    successWord[0] ="Excellent!\n";
                    successWord[1] ="Terrific!\n";
                    successWord[2] ="Superb!\n";
                    break;
                case 1 :
                    numChoices = 5;
                    successWord[0] ="Golden!\n";
                    successWord[1] ="Wonder'wool!\n";
                    wordScale[1] = 0.7f;
                    successWord[2] ="Sheeple Star!\n";
                    wordScale[2] = 0.7f;
                    successWord[3] ="Incredible!\n";
                    successWord[4] ="Fantastic!\n";
                    break;
                default :
                    numChoices = 3;
                    successWord[0] ="Awesome!\n";
                    successWord[1] ="Brilliant!\n";
                    successWord[2] ="Shining Star!\n";
                    break;
                }

            }

            int whichText = Utilities.GetRand( numChoices);
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) 
			{
                (funnyWord[(int)Enum.kHudFW_ExcellentComment]).SetScale(0.6f);
                (funnyWord[(int)Enum.kHudFW_ExcellentComment]).ChangeTextNew(successNSString);
                (funnyWord[(int)Enum.kHudFW_ExcellentComment]).FitToWidth(240.0f);
            }
            else {
                (funnyWord[(int)Enum.kHudFW_ExcellentComment]).SetScale(wordScale[whichText]);
                (funnyWord[(int)Enum.kHudFW_ExcellentComment]).ChangeText(successWord[whichText]);
            }

            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                (funnyWord[(int)Enum.kHudFW_ExcellentComment]).FitToWidth(240.0f);
            }

            (funnyWord[(int)Enum.kHudFW_ExcellentComment]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
        }

        public void ShowInGameButtonsWin(float timeToUse)
        {
            sunmoon.Hide();
            this.SetupWinScreen();
            winScreen.ShowButtons();
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
          //      (winScreen.GetButton(9)).Disappear();
            //    if (!Globals.g_world.CanConnectToInternet()) {
              //      (winScreen.GetButton(8)).Disappear();
               // }

            }

            this.SetSuccessWord();
            this.ShowWinBackObjects();
            waitToShowGlow = 0.0f;
            this.ShowRosette(1);
            sheepyHead.Show();
            sheepyHead.SetWaitToShow(1.3f);

            #if RACE_AS_PIGGY
                time.SetScore((Globals.g_world.game).raceTimer - Constants.kTimeDiffRecordingPiggy);
            #else
                time.SetScore(timeToUse);
            #endif

            int useLevel;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) useLevel = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
            else useLevel = ((Globals.g_world.frontEnd).profile).selectedLevel;

            float bestTimeF = ((Globals.g_world.frontEnd).profile).GetBestTimeP1(((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet(), useLevel);
            bestTime.SetScore(bestTimeF);
            this.ShowHudButtons(true);
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                if (((Globals.g_world.game).player).finishPosition == 1) {
                    waitToShowGlow = 2.2f;
                }

            }

        }

        public void UpdateSunMoonSwitchSides()
        {
            const float kTriggerDistance = 100;
            const float kLineMaxDistance = 120;
            float distanceToLine = (Globals.g_world.game).finishYPos - ((Globals.g_world.game).player).position.y;
            if (sunSwitchTimer <= 0) {
                if (sunLeftSide) {
                    if (distanceToLine > kLineMaxDistance) {
                        if (((Globals.g_world.game).player).position.x < kTriggerDistance) {
                            sunSwitchTimer = kSunSwitchTime;
                        }

                    }

                }
                else {
                    if ((((Globals.g_world.game).player).position.x > (384 - kTriggerDistance)) || (distanceToLine <= kLineMaxDistance)) {
                        sunSwitchTimer = kSunSwitchTime;
                    }

                }

            }
            else {
                sunSwitchTimer -= Constants.kFrameRate;
                if (sunSwitchTimer <= 0) {
                    if (sunLeftSide) {
                        CGPoint sunPos = sunStartPos;
                        sunPos.x = 320 - sunStartPos.x;
                        sunmoon.SetScreenPosition(sunPos);
                    }
                    else {
                        sunmoon.SetScreenPosition(sunStartPos);
                    }

                    sunLeftSide = !sunLeftSide;
                }
                else {
                    CGPoint sunPos = sunStartPos;
                    float xPlus;
                    if (sunLeftSide) {
                        xPlus = -40 * (1 - Utilities.GetCosInterpolationHalfP1P2(sunSwitchTimer, 0, kSunSwitchTime));
                    }
                    else {
                        sunPos.x = (320 - sunStartPos.x);
                        xPlus = 40 * (1 - Utilities.GetCosInterpolationHalfP1P2(sunSwitchTimer, 0, kSunSwitchTime));
                    }

                    sunPos.x += xPlus;
                    sunmoon.SetScreenPosition(sunPos);
                }

            }

        }

        public void UpdateSunMoonTime()
        {
            float timeGap = (Globals.g_world.game).timeLimit / 6;
            int phase = (int) ((Globals.g_world.game).raceTimer / timeGap);
            if (phase != sunPhase) {
                if (phase < 7) {
                    sunmoon.SetSubTextureId(phase);
                    sunPhase = phase;
                }

            }

            float timeLeft = (Globals.g_world.game).timeLimit - ((Globals.g_world.game).raceTimer - 2);
            if (timeLeft <= timeThrobber) {
                sunmoon.Throb();
                if (timeLeft <= 2) {
                    sunmoon.SetThrobTime(0.15f);
                    timeThrobber -= 0.5f;
                }
                else timeThrobber -= 1;

            }

        }

        public void UpdateDimOverlay()
        {
            const float dimSpeed = 0.08f;
            if (dimFalling) if (dimAlpha < 0.5f) dimAlpha += dimSpeed;

            if (dimGoing) {
                dimAlpha -= dimSpeed;
                if (dimAlpha <= 0) {
                    dimAlpha = 0;
                    dimGoing = false;
                }

            }

        }

        public void UpdateDarkFall()
        {
            Globals.Assert(false);
            const float fallTime = 4.5f;
            float timeLeft = (Globals.g_world.game).timeLimit - ((Globals.g_world.game).raceTimer - 2);
            if (timeLeft <= fallTime) {
                if (!darkHasStartedToFall) {
                    darkTextureScrollPosition = 0;
                    darkHasStartedToFall = true;
                }
                else {
                    if (darkTextureScrollPosition < 0.73f) darkTextureScrollPosition += (0.73f / (fallTime / Constants.kFrameRate));

                }

            }

        }

        public void UpdateTiltWarning()
        {
            if (!((Globals.g_world.frontEnd).profile).preferences.controlTilt) {
                return;
            }

            if ((Globals.g_world.game).tiltMuchTooBig) {
                tiltWarningTimer += Constants.kFrameRate;
                if (tiltWarning.state ==  ZobjectState.kZobjectHidden) {
                    if (tiltWarningTimer >= 1.6f) {
                    }

                }

            }
            else {
                tiltWarningTimer = 0;
                {
                }
            }

        }

        public void UpdatePaused()
        {
            pauseBack.Update();
            if (pauseEndTimer > 0.0f) 
			{
                pauseEndTimer -= Constants.kFrameRate;
                if (pauseEndTimer <= 0.0f) 
				{
                    this.EndPause();
                }

            }

            if (pauseEndTimer > 0.0f) 
			{
                pauseEndTimer -= Constants.kFrameRate;
                if (pauseEndTimer <= 0.0f) 
				{
                    this.EndPause();
                }

            }

        }

        public void FlagEndPause()
        {
            pauseEndTimer = 0.4f;
        }

        public void EndPause()
        {
            sunmoon.SetScreenPosition(Utilities.CGPointMake(304, 16));
            sunmoon.Show();
            if (restartButton.state ==  ButtonState.EActive) 
				restartButton.Hide();

            if (menuButton.state == ButtonState.EActive) 
				menuButton.Hide();

            if (nextLevelButton.state == ButtonState.EActive) 
				nextLevelButton.Hide();

            pauseBack.Hide();
        }

        public void ShowPausedState()
        {
            sunmoon.Hide();
            pauseEndTimer = 0.0f;
            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.position = Utilities.CGPointMake(160, kPauseBarPos);
            info.texture = null;
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            pauseBack.Initialise(info);
            pauseBack.Show();
            nextLevelButton.SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud), (int)World.Enum4.kHU_ButtonNext);
            float buttPosX = 290.0f;
            float buttPosY = kPauseBarPos;

			buttPosX = 320.0f - (Globals.g_world.xScreenEdge + 30.0f);
			
            nextLevelButton.ChangePosition(Utilities.CGPointMake(buttPosX, buttPosY));
            (nextLevelButton.zobject).SetShowScale(kScaleForButtonsWin);
            (nextLevelButton.zobject).SetWaitToShow(0);
            (nextLevelButton.zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            nextLevelButton.Show();
            nextLevelButton.NotClickableTilShown();
            (nextLevelButton.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
            nextLevelButton.SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            nextLevelButton.SetWidth(60.0f);
            nextLevelButton.SetHeight(60.0f);
            restartButton.SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud), (int)World.Enum4.kHU_ButtonRetry);
            buttPosY = kPauseBarPos;
						if (Globals.useIPadBackScreens) {
                buttPosY += 2.0f;
            }

            restartButton.ChangePosition(Utilities.CGPointMake(160, buttPosY));
            (restartButton.zobject).SetShowScale(kScaleForButtonsWin);
            (restartButton.zobject).SetWaitToShow(0.0f);
            (restartButton.zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            restartButton.Show();
            restartButton.NotClickableTilShown();
            (restartButton.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
            restartButton.SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            restartButton.SetWidth(60.0f);
            restartButton.SetHeight(60.0f);
            menuButton.SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud), (int)World.Enum4.kHU_ButtonMenu);
            buttPosX = 30.0f;
            buttPosY = kPauseBarPos;
						if (Globals.useIPadBackScreens) {
                buttPosX -= 20.0f;
                buttPosY += 2.0f;
            }
			
			buttPosX = Globals.g_world.xScreenEdge + 30.0f;
			
            menuButton.ChangePosition(Utilities.CGPointMake(buttPosX, buttPosY));
            (menuButton.zobject).SetShowScale(kScaleForButtonsWin);
            (menuButton.zobject).SetWaitToShow(0.0f);
            (menuButton.zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            menuButton.Show();
            menuButton.NotClickableTilShown();
            (menuButton.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
            menuButton.SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            menuButton.SetWidth(60.0f);
            menuButton.SetHeight(60.0f);
			
			nextLevelButton.zobject.myAtlasBillboard.SetRenderQueue(11000);
			restartButton.zobject.myAtlasBillboard.SetRenderQueue(11000);
			menuButton.zobject.myAtlasBillboard.SetRenderQueue(11000);
            pauseBack.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
            nextLevelButton.zobject.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
            menuButton.zobject.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
            restartButton.zobject.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");


		}

        public void UpdateShowNextLevelScreen()
        {
            showNextLevelScreen.Update();
        }

        public void UpdateFeelGoodScreen()
        {
            feelGoodBounceTimer += Constants.kFrameRate;
            if (false) {
                ((feelGoodScreen.GetButton(0)).hangingButton).Show(0.3f);
                ((feelGoodScreen.GetButton(0)).hangingButton).WobbleDeclineMultiplier(0.35f);
                ((feelGoodScreen.GetButton(1)).hangingButton).Show(0.3f);
                ((feelGoodScreen.GetButton(1)).hangingButton).WobbleDeclineMultiplier(0.6f);
                feelGoodBounceTimer = 0;
            }

            feelGoodScreen.Update();
        }

        public void UpdateLightBallAppear()
        {
            if (waitToShowGlow > 0.0f) {
                waitToShowGlow -= Constants.kFrameRate;
                if (waitToShowGlow <= 0.0f) {
                    {
                        if (lightBall.appearAlpha == 0) {
//                            lightBall.SetAppearing(true);
                        }

                    }
                }

            }

        }

        public void UpdateLightBallAppearFeelGood()
        {
            if ((Globals.g_world.game).stateTimer >= 0.5f) {
                if (lightBall.appearAlpha == 0) {
               //     lightBall.SetAppearing(true);
                }

            }

        }

        public void InitialiseGetReady()
        {
        }

        public void HideGetReadyNumber(int nextGetReadyNumber)
        {
            int useZobId = nextGetReadyNumber % 2;
            (grZob[useZobId]).Hide();
        }

        public void ShowGetReadyNumber(int nextGetReadyNumber)
        {
            int useZobId = nextGetReadyNumber % 2;
            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.position = Utilities.CGPointMake(160, 200);
            info.texture = null;
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            (grZob[useZobId]).Initialise(info);
            (grZob[useZobId]).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_321));
            (grZob[useZobId]).SetSubTextureId(nextGetReadyNumber);
            (grZob[useZobId]).SetShowLagSpeed(0.2f);
            if (nextGetReadyNumber == 3) {
                (grZob[useZobId]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
                (grZob[useZobId]).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_Zoom);
            }
            else {
                (grZob[useZobId]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
                (grZob[useZobId]).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            }

            (grZob[useZobId]).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
            (grZob[useZobId]).Show();
            (grZob[useZobId]).QueueActionP1( ZobjectAction.nHide, 0.35f);
            nextGetReadyNumber++;
        }

        public void UpdateGetReady()
        {
            for (int i = 0; i < 2; i++) {
                (grZob[i]).Update();
            }

            whistlingBitzer.Update();
        }

        public bool Update()
        {
            if (!hasBeenReset) return false;

            switch ((Globals.g_world.game).gameState) {
            case GameState.e_GamePlay :
                whistlingBitzer.Update();
                break;
            case GameState.e_ShowLevel :
                this.UpdateShowNextLevelScreen();
                starCupStar.Update();
                radialLight.Update();
                levelWord.Update();
                levelWordNumber.Update();
                levelName.Update();
                nextLevelButton.Update();
                menuButton.Update();
                appleWon.Update();
                time.Update();
                (funnyWord[(int)Enum.kHudFW_bestTime]).Update();
                break;
            case GameState.e_FeelGoodScreen :
                starCupStar.Update();
                radialLight.Update();
                this.UpdateFeelGoodScreen();
                this.UpdateLightBallAppearFeelGood();
                lightBall.Update();
                sheepyHead.Update();
                return false;
                break;
            case GameState.e_AppleCartScreen :
                return false;
                break;
            case GameState.e_Paused :
                this.UpdatePaused();
                break;
            case GameState.e_ShowResultsWin :
                if ((Globals.g_world.game).shownHudYet) {
                    winScreen.Update();
                    (funnyWord[(int)Enum.kHudFW_bestTime]).Update();
                    (funnyWord[(int)Enum.kHudFW_time]).Update();
                    winBackFade.Update();
                    winBackFadeBot.Update();
                    winBackCorkMid.Update();
                    winBackCorkTop.Update();
                    for (int i = 0; i < 3; i++) (winBackApple[i]).Update();

                    restartButton.Update();
                    nextLevelButton.Update();
                    menuButton.Update();
                    ohno.Update();
                    appleWon.Update();
                }

                break;
            case GameState.e_ShowResultsLoseTooSlow :
            case GameState.e_ShowResultsLoseToPiggy :
                if ((Globals.g_world.game).shownHudYet) {
                    loseScreen.Update();
                    (funnyWord[(int)Enum.kHudFW_bestTime]).Update();
                    (funnyWord[(int)Enum.kHudFW_time]).Update();
                    winBackFade.Update();
                    winBackFadeBot.Update();
                    winBackCorkMid.Update();
                    winBackCorkTop.Update();
                    for (int i = 0; i < 3; i++) (winBackApple[i]).Update();

                    restartButton.Update();
                    nextLevelButton.Update();
                    menuButton.Update();
                    ohno.Update();
                    appleWon.Update();
                }

                break;
            default :
                break;
            }

            ZRaceMeter.ZRMUpdateData rmData = new ZRaceMeter.ZRMUpdateData();
            rmData.racePos[0] = ((Globals.g_world.game).player).position.y;
            if (((Globals.g_world.game).player).finishPosition != -1) {
                float thing = (float) ((Globals.g_world.game).player).finishPosition;
                rmData.racePos[0] = 900000.0f + ((10.0f - thing) * 10.0f);
            }

            int piggyIndex = 1;
            for (int i = (Globals.g_world.game).startFromPiggy; i < (Globals.g_world.game).lastPiggyIndex; i++) {
                if (((Globals.g_world.game).GetPlayerPiggy(i)).finishPosition != -1) {
                    float thing = (float) ((Globals.g_world.game).GetPlayerPiggy(i)).finishPosition;
                    rmData.racePos[piggyIndex] = 900000.0f + ((10.0f - thing) * 10.0f);
                }
                else {
                    rmData.racePos[piggyIndex] = ((Globals.g_world.game).GetPlayerPiggy(i)).position.y;
                }

                piggyIndex++;
            }

            raceMeter.Update(rmData);
            this.UpdateDimOverlay();
            if ((Globals.g_world.game).gameState !=  GameState.e_GamePlay) {
                for (int i = 0; i < (int)Enum.kHud_NumFunnyWords; i++) (funnyWord[i]).Update();

            }

            sunmoon.Update();
            if (((Globals.g_world.game).gameState == GameState.e_ShowResultsWin) || ((Globals.g_world.game).gameState == GameState.e_ShowResultsLoseTooSlow
              ) || ((Globals.g_world.game).gameState == GameState.e_ShowResultsLoseToPiggy)) {
                this.UpdateLightBallAppear();
                time.Update();
                bestTime.Update();
                piggyCommentBubble.Update();
				if (piggyHead != null)
					piggyHead.Update();
    
				sheepyHead.Update();
            }

            if ((Globals.g_world.game).gameState == GameState.e_ShowResultsLoseToPiggy) {
                if ((Globals.g_world.game).stateTimer >= 0.4f) {
                    dimFalling = true;
                }

            }

            if ((Globals.g_world.game).gameState == GameState.e_ShowResultsWin) {
                this.UpdateShowResultsWin();
            }

            return false;
        }

        public void UpdateShowResultsWin()
        {
            float timer = (Globals.g_world.game).stateTimer;
            if (timer >= 1) {
                dimFalling = true;
            }

            if (timer >= 1.5f) {
                if (time.state == (int) ZscoreState.e_Hidden) {
                    time.Show();
                    Zscore.ZscoreInfo zsInfo = new Zscore.ZscoreInfo();
                    zsInfo.numDigits = 5;
                    zsInfo.position = Utilities.CGPointMake(86, 235);
                    bestTime.Reset();
                    bestTime.SetScale(0.5f);
                    bestTime.Initialise(zsInfo);
                    bestTime.SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
                    bestTime.SetDecimalPoint(2);
                    bestTime.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                    bestTime.SetTimeBetweenShowingDigits(0.0f);
                    bestTime.SetColour(Constants.kColourLightblue);
                    bestTime.Show();
                    if ((Globals.g_world.game).newBestTimeRecorded) 
					{
                       bestTime.QueueAction( (int)ZobjectAction.nFlash);
                    }
                    else {
                    }

                }

            }

        }

        public void RenderControlArrows()
        {
            if (!((Globals.g_world.frontEnd).profile).preferences.controlTilt) {
                if (!((Globals.g_world.frontEnd).profile).preferences.controlFinger) {
                    if (((Globals.g_world.game).gameState == GameState.e_GamePlay) || ((Globals.g_world.game).gameState == GameState.e_GetReady)) {
                        if (controlFade < kControlArrowFadeMax) controlFade += 0.1f;
                        else if (controlFade > kControlArrowFadeMax) {
                            controlFade = kControlArrowFadeMax;
                        }

												if (Globals.deviceIPhone5)//Globals.useIPadBackScreens) 
						
												{
														(DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[0],Utilities.CGPointMake(60.0f, 440.0f), 1.0f, 0.0f, 0.0f, controlFade, (int)World.Enum4.kHU_Left);
														(DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[1],Utilities.CGPointMake(260.0f, 440.0f), 1.0f, 0.0f, 0.0f, controlFade, (int)World.Enum4.kHU_Right);
                        }
                        else {
                            (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[0],Utilities.CGPointMake(40.0f, 440.0f), 1.0f, 0.0f, 0.0f, controlFade, (int)World.Enum4.kHU_Left);
                            (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[1],Utilities.CGPointMake(280.0f, 440.0f), 1.0f, 0.0f, 0.0f, controlFade, (int)World.Enum4.kHU_Right);
                        }

                    }
                    else {
                        if (controlFade > 0.0f) {
                            controlFade -= 0.1f;
                            if (controlFade < 0.0f) {
                                controlFade = 0.0f;
                            }

														if (Globals.deviceIPhone5){//Globals.useIPadBackScreens) {
																(DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[0],Utilities.CGPointMake(60.0f, 440.0f), 1.0f, 0.0f, 0.0f, controlFade, (int)World.Enum4.kHU_Left);
																(DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[1],Utilities.CGPointMake(260.0f, 440.0f), 1.0f, 0.0f, 0.0f, controlFade, (int)World.Enum4.kHU_Right);
                            }
                            else {
                                (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[0],Utilities.CGPointMake(40.0f, 440.0f), 1.0f, 0.0f, 0.0f, controlFade, (int)World.Enum4.kHU_Left);
                                (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[1],Utilities.CGPointMake(280.0f, 440.0f), 1.0f, 0.0f, 0.0f, controlFade, (int)World.Enum4.kHU_Right);
                            }

                        }

                    }

                }
                else {
                    float kRotScale = 50.0f * Constants.kScreenMultiplierForShorts;
                    if (((Globals.g_world.game).gameState == GameState.e_GamePlay) || ((Globals.g_world.game).gameState == GameState.e_GetReady)) {
                        if (((Globals.g_world.game).fingerControl).fingerDown) {
                            if (controlFade < 1.0f) controlFade += 0.1f;

                        }
                        else {
                            if (controlFade > 0.0f) controlFade -= 0.1f;

                        }

                        if (controlFade > 0.0f) {
                            CGPoint fingerPos = ((Globals.g_world.game).fingerControl).fingerPosition;
                            targetSpinPos -= 0.07f;
														if (Globals.useIPadBackScreens) {
                                fingerPos.x += 32.0f;
                                kRotScale *= 2.0f;
                            }

                            (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[0], fingerPos, 1.0f, targetSpinPos, kRotScale, controlFade, (int)World.Enum4.kHU_Target);
                        }

                    }
                    else {
                        if (controlFade > 0.0f) {
                            controlFade -= 0.1f;
                            CGPoint fingerPos = ((Globals.g_world.game).fingerControl).fingerPosition;
                            targetSpinPos -= 0.07f;
                            (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(directionButtonBillboard[0],fingerPos, 1.0f, targetSpinPos, kRotScale, controlFade, (int)World.Enum4.kHU_Target);
                        }

                    }

                }

            }

            if (((Globals.g_world.game).gameState == GameState.e_GamePlay) || ((Globals.g_world.game).gameState == GameState.e_ShowResultsWin) || ((Globals.g_world
              .game).gameState == GameState.e_ShowResultsLoseToPiggy) || ((Globals.g_world.game).gameState == GameState.e_Paused)) {
                sunmoon.RenderToDrawArrays();
            }

        }

        public void RenderDimOverlay()
        {
            if (dimAlpha > 0) ((Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureDimOverlay)).DrawInRectAlphaP1(Utilities.CGRectMake(0, 0, 320, 480), dimAlpha);

        }

        public void RenderAppleSilhouettes()
        {
            float x = 27.0f;
            for (int i = 0; i < 3; i++) {
                CGPoint pos = Utilities.CGPointMake(x, 27.0f);
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glPushMatrix();
                Globals.g_world.DoGLTranslateP1(pos.x, pos.y);
                ((Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureAppleWhite)).DrawAtPointScaledAlphaP1(0.7f, 0.35f);
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glPopMatrix();
                x += 42.0f;
            }

        }

        public void Render()
        {

            #if RECORDING_SIMULATOR_VIDEO_FULL_FRAMERATE
                return;
            #endif

            if (darkHasStartedToFall) {
                darkTexture.DrawInRectTexScrollP1P2(Utilities.CGRectMake(0, -20, 320, 500), 0.25f, darkTextureScrollPosition);
            }

            ////glEnableClientState (GL_COLOR_ARRAY);
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_Hud));
            this.RenderControlArrows();
			if (!(Globals.g_world.game).shownHudYet) 
			{

				raceMeter.Render();
			}
            (DrawManager.Instance()).Flush();
            ////glDisableClientState (GL_COLOR_ARRAY);
            switch ((Globals.g_world.game).gameState) {
            case GameState.e_Paused :
                this.RenderDimOverlay();
                pauseBack.RenderFromAtlas();
                restartButton.Render();
                nextLevelButton.Render();
                menuButton.Render();
                break;
            case GameState.e_ShowLevel :
                {
                    //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                    //glLoadIdentity();
                    //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
                    if (Globals.deviceIPhone4) {
                        FrontEndScreen.SpecialBackParameters sInfo = new FrontEndScreen.SpecialBackParameters();
                        sInfo.scale = 1.0f;
                        sInfo.renderOffset = Utilities.CGPointMake(0.0f, 14.0f);
                        showNextLevelScreen.RenderBackSceneSpecial(sInfo);
                    }
                    else {
                        showNextLevelScreen.RenderBackScene();
                    }

                    showNextLevelScreen.RenderFrontScene();
				                    levelName.Render();

				appleWon.Render();
                    time.Render();
                    levelWord.Render();
                    levelWordNumber.Render();
                    break;
                }
            case GameState.e_FeelGoodScreen :
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glLoadIdentity();
                //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
               // ((Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureTitlePic)).DrawInRect(Utilities.CGRectMake(0, 0, 320, 480));
                if ((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_StarCupStar) != null) {
                //    radialLight.Render();
                //    starCupStar.Render();
                }

                sheepyHead.Render();
//                lightBall.Render();
                if (Globals.deviceIPhone4) {
                    FrontEndScreen.SpecialBackParameters sInfo = new FrontEndScreen.SpecialBackParameters();
                    sInfo.renderOffset = Utilities.CGPointMake(0.0f, 16.0f);
                    sInfo.scale = 1.0f;
                    feelGoodScreen.RenderBackSceneSpecial(sInfo);
                }
                else {
                    feelGoodScreen.RenderBackScene();
                }

                feelGoodScreen.RenderFrontScene();
                break;
            case GameState.e_AppleCartScreen :
                break;
            case GameState.e_SpeedBoostScreen :
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glLoadIdentity();
                //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
                speedBoostScreen.Render();
                break;
            case GameState.e_AnotherPiggy :
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glLoadIdentity();
                //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
        
				anotherPiggyScreen.Render();
                break;
            case GameState.e_GetReady :
                for (int i = 0; i < 2; i++) {
                    (grZob[i]).RenderFromAtlas();
                }

                whistlingBitzer.RenderFromAtlas();
                break;
            case GameState.e_GamePlay :
                whistlingBitzer.RenderFromAtlas();
                break;
            case GameState.e_ShowResultsWin :
                if ((Globals.g_world.game).shownHudYet) {
                    //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                    //glLoadIdentity();
                    //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
                    winScreen.RenderBackScene();
                    winScreen.RenderFrontScene();
                    Globals.g_world.RenderPullTab();

                    #if FACEBOOK_BUTTON
                        if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                            (winScreen.GetButton(9)).Render();
                        }

                    #endif

                    time.Render();
                    bestTime.Render();
                    appleWon.Render();
                    (funnyWord[(int)Enum.kHudFW_ExcellentComment]).Render();
                }

                break;
            case GameState.e_ShowResultsLoseTooSlow :
                ohno.Render();
                restartButton.Render();
                nextLevelButton.Render();
                menuButton.Render();
                break;
            case GameState.e_ShowResultsLoseToPiggy :
                if ((Globals.g_world.game).shownHudYet) {
										loseScreen.RenderBackScene_StretchToFit();
                    loseScreen.RenderFrontScene();
                    (funnyWord[(int)Enum.kHudFW_PiggyComment1]).Render();
                    (funnyWord[(int)Enum.kHudFW_PiggyComment2]).Render();
                    (funnyWord[(int)Enum.kHudFW_PiggyComment3]).Render();
                    piggyHead.RenderFromAtlas();
                }

                break;
            default :
                break;
            }

        }

    }
}
