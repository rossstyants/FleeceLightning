using UnityEngine;
using System;
using System.Diagnostics;

namespace Default.Namespace
{
    public enum  FrontEndScreenEnum {
        kFrontEndScreen_ExitMenuSystem = -2,
        kFrontEndScreen_Invalid = -1,
        kFrontEndScreen_Title,
        kFrontEndScreen_Options,
        kFrontEndScreen_PlayGameOptions,
        kFrontEndScreen_ChooseTrack,
        kFrontEndScreen_LBChooseTrack,
        kFrontEndScreen_LBPlayOrBuild,
        kFrontEndScreen_HighScoresChooseTrack,
        kFrontEndScreen_NetSendChooseTrack,
        kFrontEndScreen_NetReceiveChooseTrack,
        kFrontEndScreen_Main,
        kFrontEndScreen_About_2_6,
        kFrontEndScreen_About_2_8,
        kFrontEndScreen_About_2_9,
        kFrontEndScreen_About_3,
        kFrontEndScreen_About_4,
        kFrontEndScreen_About_5,
        kFrontEndScreen_Credits,
        kFrontEndScreen_LBHowTo,
        kFrontEndScreen_NoBestTimesInEasy,
        kFrontEndScreen_GreenAnt,
        kFrontEndScreen_LoadingScreenEnd,
        kFrontEndScreen_SendChooseTrack,
        kFrontEndScreen_WaitReceiveTrack,
        kFrontEndScreen_BonusChooseTrack,
        kFrontEndScreen_WaitForClient,
        kFrontEndScreen_BrowseServers,
        kFrontEndScreen_TrackReceived,
        kFrontEndScreen_SendComplete,
        kFrontEndScreen_EnterTrackName,
        kFrontEndScreen_Test,
        kFrontEndScreen_ChooseStage,
        kFrontEndScreen_BehindCrystalSplash,
        kFrontEndScreen_BehindGameCenterStart,
        kFrontEndScreen_ControlChoice_Choose,
        kFrontEndScreen_ControlChoice_ShowFinger,
        kFrontEndScreen_ControlChoice_ShowThumb,
        kFrontEndScreen_ControlChoice_ShowTilt,
        kFrontEndScreen_ControlChoice_ShowTiltExpert,
        kFrontEndScreen_ControlChoice_ShowTiltAuto,
        kFrontEndScreen_ControlChoice_Final,
        kFrontEndScreen_ChooseTerrainForCustomLevel,
        kFrontEndScreen_MultiplayerConnect,
        kFrontEndScreen_FeatureNotAvailable,
        kFrontEndScreen_LoadingFilesFromDropbox,
        kFrontEndScreen_Legal,
        kFrontEndScreen_ChooseControls,
        kFrontEndScreen_Store,
        kNumFrontEndScreens
    }
    public enum  FrontEndActions {
        kFrontEndAction_None = 0,
        kFrontEndAction_SubmitScoresToAgon,
        kFrontEndAction_ViewScoresLeaderboard,
        kFrontEndAction_MusicPreference,
        kFrontEndAction_SoundFxPreference,
        kFrontEndAction_SelectNetTrack,
        kFrontEndAction_TypeCustomTrackName,
        kFrontEndAction_StageSelectGoBackOne,
        kFrontEndAction_StageSelectGoForwardOne,
        kFrontEndAction_TerrainSelectGoBackOne,
        kFrontEndAction_TerrainSelectGoForwardOne,
        kFrontEndAction_UnlockAllLevels,
        kFrontEndAction_ClearAllDataComplete,
        kFrontEndAction_FakeMultiplayer,
        kFrontEndAction_ChangeControlOnMain,
        kFrontEndAction_HideSlideIn,
        kFrontEndAction_SlideAboutShitLeft,
        kFrontEndAction_SlideAboutShitRight,
        kFrontEndAction_ChooseThumbInControlChoiceSetup,
        kFrontEndAction_ChooseFingerInControlChoiceSetup,
        kFrontEndAction_ChooseTiltInControlChoiceSetupAuto,
        kFrontEndAction_ChooseTiltInControlChoiceSetupExpert,
        kFrontEndAction_FinishedViewingControlChoiceSetup,
        kFrontEndAction_TryTrashCustomLevel,
        kFrontEndAction_CreateTrack,
        kFrontEndAction_TrySendTrack,
        kFrontEndAction_TryGoToSendTrack,
        kFrontEndAction_TryGoToReceiveTrack,
        kFrontEndAction_TryGoNetSendChooseTrack,
        kFrontEndAction_TryGoReceiveTrack,
        kFrontEndAction_ChooseControl,
        kFrontEndAction_DropBox,
        kFrontEndAction_SpecialLock1,
        kFrontEndAction_SpecialLock2,
        kFrontEndAction_SpecialLock3,
        kFrontEndAction_SpecialLock4,
        kFrontEndAction_ChangeControlInOptions,
        kFrontEndAction_EmailLog,
        kFrontEndAction_FBLogin,
        kFrontEndAction_FBLogoff,
        kFrontEndAction_LegalEULA,
        kFrontEndAction_LegalPrivacy,
        kFrontEndAction_LegalTerms,
        kFrontEndAction_HideNewsTab,
        kFrontEndAction_ControlsSelectGoForwardOne,
        kFrontEndAction_ControlsSelectGoBackOne,
        kFrontEndAction_BuyUnlockAllLevels,
        kFrontEndAction_BuyRemoveAds,
        kFrontEndAction_RestoreUnlockAllLevels,
				kFrontEndAction_RestoreRemoveAds,
		kFrontEndAction_PressRaceButton,
		kFrontEndAction_OpenDataPrivacySettings,
    }
    public partial class Constants
    {
        public const string KGameIdentifier = "sheeplechase";
    }
    public partial class FrontEnd
    {
        public float inScreenTimer;
        public bool isInternetOn;
        public float waitingToReceiveGotIt;
        public float timeSinceIncomingConnection;
        public int chosenTrack;
        public int numTrackSends;
        public int specialLockId;
        public int specialLockWordId;
        public int optionsMusicId;
        public int optionsSfxId;
        public int optionsGhostId;
        public int optionsControl;
        public int optionsControlImage;
        public int specialWordId;
        public bool controlTilt;
        public bool controlFinger;
        public bool refreshServerTexts;
        public float timeWithoutFindingTrack;
        public float timerToSorryMessage;
        public string serverOwnName;
        public UIAlertView alertViewPermission;
        public bool connectedToServerOk;
        public float readGoogleTimer;
        public SlideInCharacter slideInCharacter;
        public AppleWon appleWonChooseTrack;
        public CreditsText creditsText;
        public FrontEndScreen[] screen = new FrontEndScreen[(int)FrontEndScreenEnum.kNumFrontEndScreens];
        public FrontEndScreenEnum currentScreen;
        public Texture2D_Ross[] buttonTexture = new Texture2D_Ross[(int)Enum.kNumButtonTextures];
        public Profile profile;
        public ExitMenuInfo exitInfo;
        //public Cloud[] cloud = new Cloud[kMaxClouds];
        //public LightBall lightBall;
        public Zscore bestTime;
        public Zshake shake;
        public int[] lastSelectedLevel = new int[(int)Enum2.kNumStages];
        public int chooseStageSideButtonId;
        public int chooseTerrainSideButtonId;
        public int chooseControlsSideButtonId;
        public int[] chooseStageSideButtonIdCT = new int[(int)FrontEndScreenEnum.kNumFrontEndScreens];
        public int bestTimesButtonId;
        public int startButtonId;
        public int startButtonIdnr;
        public int startButtonIdLB;
        public int startButtonFWId;
        public int startButtonIdBonus;
        public int startOfTrophies;
        public int bonusButtonId;
       // public int keybButtonIdLB;
        public int trashButtonIdLB;
        public int controlWordId;
        public int throbThingId;
        public int chooseTrackButtonId;
        public char[] wifiTrackName = new char[32];
        public bool firstInit;
        public bool frontEndDone;
        public int selectedStage;
        public int selectedTerrain;
        public int selectedControls;
        public int mainRaceButtonId;
        public int initMenuAtRaceScreen;
        public bool initMenuWithWellDone;
        public Zobject handStamp;
        public Zobject greenAntLogo;
        public Zobject titleWord1;
        public Zobject titleWord2;
        public int greenAntEffectId;
        public float hopTimerGreenAnt, hopTimerLB;
        public float sendConfirmMessage;
        public float slideInCharacterMainTimer;
        public float blinkTimer;
        public bool slideInShown;
        public bool firstForDay;
        public float chooseStageLateralSlideTimer;
        public float lateralSlideOffset;
        public int lateralSlideFrom;
        public int lateralSlideTo;
        public Constants.RossColour currentColour;
        public Constants.RossColour colourFadeFrom;
        public Constants.RossColour colourFadeTo;
        public float colourFadeTimer;
        public Constants.RossColour currentColourRays;
        public Constants.RossColour colourFadeFromRays;
        public Constants.RossColour colourFadeToRays;
        public float xBackButton;
        public bool showingThatCupIsUnlocked;
        public const float kShiftWithMessage = 50.0f;
        public const int kNumButtonsBeforeTracksLB = 1;
        public const int kNumButtonsBeforeTracks = 0;
        public const float kChooseTrackYEdge = 130;
        public const float kChooseTrackBottomButtonsPos = 440.0f;
        public const float kChooseTrackSlideHeadsPos = 414.0f;
        public const float kChooseTrackArrowsYPos = 232;
        public const float kChooseTrackApplesYPos = 305;
        public const float kChooseTrackScoreYPos = 350;
        public const float kChooseTrackLevelNameYPos = 260;
        public const float kChooseTrackCupNameYPos = 81.0f;
        public const float kToUnlockY = 120.0f;
        public const float kTotalWordYPos = 334.0f;
        public const float kChooseStageSpecialLockYPos = 150.0f;
        public const float kMainScreenRaceYPos = 89.0f;
        public const float kChooseStageAppleXPos = 142.0f;
        public const float kChooseStageSlideHeadsPos = 442.0f;
        public const float kChooseStageBackXPos = 42.0f;
        public const float kChooseTerrainTerrainPos = 310.0f;
        public const float kChooseStageApplesYPos = 355.0f;
        public const float kChooseStageHangingTotalPos = 340.0f;
        public const float kChooseStageMainIconYPos = 200.0f;
        public const float kChooseStageTotalXPos = 110.0f;
        public const float kChooseStageMoreCupsYPos = 175.0f;
        public const float kChooseStageCupNameYPos = 81.0f;
        public const float kStageLateralSlideTime = 0.35f;
        public const int kNumButtonsBeforeOnTerrain = 2;
        public const int kNumButtonsBeforeOnStage = 0;
        public const float kLevelButtonScale = 1.0f;
        public const float kAboutWordScale = 0.5f;
        public const float kStampY = 185;
        public const float kStampX = 65;
        public const int kNumTerrains = 5;
        public float kChooseTrackBackBarTopPosY;

        public enum Enum2 {
            kStageMeadow = 0,
            kStageMud,
            kStagePenguin,
            kStageCountry,
            kStageFarm,
            kStageStarCup,
            kStageSeven,
            kStageEight,
            kStageNine,
            kStageTen,
            kStageBonusLevels,
            kNumStages
        };
//        public struct FrontEndScreen.AddFunnyWordInfo{
  //          CGPoint position;
    //        float scale;
      //      string inString = "";
        //};
        public enum Enum3 {
            kMaxNumButtons = 110,
            kMaxFunnyWords = 29,
            kMaxSwitches = 6,
            kMaxQueries = 5,
            kMaxNumbersPerScreen = 80,
        };
      //  public enum Enum4{
        //    kMaxFunnyWordsInQuery = 7
        //};
 
        //extern float kChooseTrackBackBarTopPosY;
      //  public enum Enum9 {
        //    kMaxClouds = 10
        //};
        public enum Enum {
            kButtonTexture_Play = 0,
            kButtonTexture_Back,
            kButtonTexture_StartGame,
            kButtonTexture_MenuBackGround,
            kButtonTexture_TrophyBronze,
            kButtonTexture_TrophySilver,
            kButtonTexture_TrophyGold,
            kButtonTexture_TrophyNotGot,
            kButtonTexture_NameLevel1,
            kButtonTexture_HandStamp,
            kButtonTexture_TitleWord1,
            kButtonTexture_TitleWord2,
            kButtonTexture_GreenAntStamp,
            kButtonTexture_SwitchOn,
            kButtonTexture_SwitchOff,
            kButtonTexture_AboutBack,
            kButtonTexture_AboutForward,
            kButtonTexture_AboutTitle,
            kButtonTexture_AboutBackScreen,
            kButtonTexture_HowToTopSpeed,
            kButtonTexture_HowToBottomSpeed,
            kButtonTexture_HowToPower0,
            kButtonTexture_HowToPower1,
            kButtonTexture_HowToPower2,
            kButtonTexture_BuildIcon,
            kButtonTexture_QueryBackdrop,
            kButtonTexture_QueryText_ClearData,
            kButtonTexture_QueryText_ClearLB,
            kButtonTexture_QueryText_QuitLB,
            kButtonTexture_QueryYes,
            kButtonTexture_QueryOk,
            kButtonTexture_LabelFast,
            kButtonTexture_LabelSlow,
            kButtonTexture_QueryNo,
            kButtonTexture_LevelEditor,
            kButtonTexture_GreenAnt,
            kButtonTexture_SubmitAll,
            kButtonTexture_ViewLeaderboard,
            kButtonTexture_DiffEasy,
            kButtonTexture_DiffNormal,
            kButtonTexture_TrophyGlow,
            kButtonTexture_TrophyGlowWhite,
            kTextureLabel_Play,
            kTextureLabel_About,
            kTextureLabel_Options,
            kTextureLabel_BestTimes,
            kTextureLabel_Credits,
            kTextureLabel_Bonus,
            kTextureLabel_LB,
            kTextureLabel_NetSend,
            kTextureLabel_NetReceive,
            kButtonTexture_Cloud,
            kButtonTexture_LightBallBlue,
            kButtonTexture_LightBeamBlue,
            kButtonTexture_PlantStem,
            kButtonTexture_PlantHead,
            kButtonTexture_TextBack,
            kButtonTexture_Keyboard,
            kButtonTexture_HideCredits,
            kButtonTexture_StageArrowLeft,
            kButtonTexture_StageArrowRight,
            kButtonTexture_ColouredBack,
            kButtonTexture_ChooseTrackBottomBit,
            kButtonTexture_FarmBottom,
            kButtonTexture_FarmBottomGrey,
            kButtonTexture_TwistedArrow,
            kButtonTexture_Practise,
            kButtonTexture_HowToTiltV,
            kButtonTexture_HowToTiltH,
            kButtonTexture_HowToFinger,
            kButtonTexture_HowToPlus,
            kButtonTexture_ShaunOnPodium,
            kNumButtonTextures
        };
				
        public class SwitchInfo{
            public CGPoint position;
            public Texture2D_Ross[] texture = new Texture2D_Ross[(int)SwitchState.tates];
            public Texture2D_Ross[] labelTexture = new Texture2D_Ross[(int)SwitchState.tates];
        };
        public struct ExitMenuInfo{
            public bool goToLevelBuilder_Ross;
            public bool playCustomLevel;
            public bool multiplayer;
        };

		public class ButtonInfo{
            public CGPoint position;
            public FrontEndScreenEnum goToScreen;
            public Texture2D_Ross texture;
            public Texture2D_Ross textureLabel;
        };


        public int doInitMenuAtRaceScreen
        {
            get;
            set;
        }

        public bool doInitMenuWithWellDone
        {
            get;
            set;
        }

        public bool ShowingThatCupIsUnlocked
        {
            get;
            set;
        }

        public int SelectedStage
        {
            get;
            set;
        }

        public int SelectedTerrain
        {
            get;
            set;
        }

        public float XBackButton
        {
            get;
            set;
        }

        public float InScreenTimer
        {
            get;
            set;
        }

        public Profile Profile
        {
            get;
            set;
        }

        public Zobject HandStamp
        {
            get;
            set;
        }

        public FrontEndScreenEnum CurrentScreen
        {
            get;
            set;
        }

        public ExitMenuInfo ExitInfo
        {
            get;
            set;
        }

public void SetInitMenuAtRaceScreen(int inThing) {initMenuAtRaceScreen = inThing;}///@property(readwrite,assign) int initMenuAtRaceScreen;
public void SetInitMenuWithWellDone(bool inThing) {initMenuWithWellDone = inThing;}///@property(readwrite,assign) bool initMenuWithWellDone;
public void SetShowingThatCupIsUnlocked(bool inThing) {showingThatCupIsUnlocked = inThing;}///@property(readwrite,assign) bool showingThatCupIsUnlocked;
public void SetSelectedStage(int inThing) {selectedStage = inThing;}///@property(readwrite,assign) int selectedStage;
public void SetSelectedTerrain(int inThing) {selectedTerrain = inThing;}///@property(readwrite,assign) int selectedTerrain;
public void SetProfile(Profile inThing) {profile = inThing;}////@property(readwrite,assign) Profile* profile;
//public void SetInTransition(bool inThing) {inTransition = inThing;}///@property(readwrite,assign) bool inTransition;
public void SetHandStamp(Zobject inThing) {handStamp = inThing;}////@property(readwrite,assign) Zobject* handStamp;
public void SetCurrentScreen(FrontEndScreenEnum inThing) {currentScreen = inThing;}///@property(readwrite,assign) FrontEndScreenEnum currentScreen;
public void SetExitInfo(ExitMenuInfo inThing) {exitInfo = inThing;}///@property(readwrite,assign) ExitMenuInfo exitInfo;
//public void SetNetworkController(NetworkController inThing) {networkController = inThing;}////@property(readwrite,assign) NetworkController* networkController;
public void SetXBackButton(float inThing) {xBackButton = inThing;}///@property(readwrite,assign) float xBackButton;
public void SetInScreenTimer(float inThing) {inScreenTimer = inThing;}///@property(readwrite,assign) float inScreenTimer;

        public Texture2D_Ross GetButtonTexture(int textureId)
        {
            Globals.Assert(textureId < (int)Enum.kNumButtonTextures);
            return buttonTexture[textureId];
        }

        public Texture2D_Ross LoadTemporaryTextureP1P2P3(Texture2D_Ross inTex, bool stretchable, string textureName, Texture2D_RossPixelFormat forceType, int assetId, LoadADCQueue.AssetType inType)
        {
//			if (inTex != null)
//				return inTex;
			
            Globals.Assert(inTex == null);
            return Globals.g_world.LoadTextureP1P2(stretchable, textureName, forceType, assetId, inType);
        }

        public Texture2D_Ross LoadTemporaryTextureIfNecessaryP1P2P3(Texture2D_Ross inTex, bool stretchable, string textureName, Texture2D_RossPixelFormat forceType, int assetId, LoadADCQueue.AssetType inType)
        {
            if (inTex == null) {
                return Globals.g_world.LoadTextureP1P2(stretchable, textureName, forceType, assetId, inType);
            }
			return inTex;
        }

        public Texture2D_Ross LoadTemporaryTextureP1P2(Texture2D_Ross inTex, bool stretchable, string textureName, int assetId, LoadADCQueue.AssetType inType)
        {
//			if (inTex != null)
//				return inTex;
			
            Globals.Assert(inTex == null);
            return Globals.g_world.LoadTextureP1(stretchable, textureName, assetId, inType);
        }

        public void LoadWinOrLoseTextures()
        {
            if ((Globals.g_world.game).gameState == GameState.e_ShowResultsLoseToPiggy) {
                this.LoadLoseTextures();
            }
            else {
                this.LoadWinTextures();
            }

        }

        public void ReleaseWinTextures()
        {
            int i = (int)Enum.kButtonTexture_ShaunOnPodium;
            if (buttonTexture[i] != null) 
			{
				buttonTexture[i].Dealloc();
                buttonTexture[i] = null;
            }

            Globals.g_world.ReleaseRaceWinAtlas();
        }

        public void ReleaseLoseTextures()
        {
            Globals.g_world.ReleaseRaceLoseAtlas();
        }

        public void LoadWinTextures()
        {
            if (buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium] == null) {
								if (Globals.useIPadBackScreens) {
                    buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium] = this.LoadTemporaryTextureP1P2P3(buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium], true, "ShaunOnPodium_iPad.png", Texture2D_RossPixelFormat.
                      t_RGB565,(int)Enum.kButtonTexture_ShaunOnPodium,LoadADCQueue.AssetType.ktextureFrontEnd);
                }
                else {
                    buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium] = this.LoadTemporaryTextureP1P2P3(buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium], true, "ShaunOnPodium.png",  
                      Texture2D_RossPixelFormat.t_RGB565,(int)Enum.kButtonTexture_ShaunOnPodium,LoadADCQueue.AssetType.ktextureFrontEnd);
                }

            }

            Globals.g_world.LoadRaceWinAtlas();
        }

        public void LoadLoseTextures()
        {
            Globals.g_world.LoadRaceLoseAtlas();
        }

        public void LoadTexturesTemporary(bool firstTime)
        {
			if (buttonTexture[(int)Enum.kButtonTexture_StageArrowLeft] != null)
			{
//				return;
			}
			
            Globals.Assert(buttonTexture[(int)Enum.kButtonTexture_StageArrowLeft] == null);
						if (Globals.useIPadBackScreens) 
						{
			                buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium] = this.LoadTemporaryTextureIfNecessaryP1P2P3(buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium], true, "ShaunOnPodium_iPad.png", 
			                  Texture2D_RossPixelFormat.t_RGB565,(int)Enum.kButtonTexture_ShaunOnPodium,LoadADCQueue.AssetType.ktextureFrontEnd);
			                buttonTexture[(int)Enum.kButtonTexture_ColouredBack] = this.LoadTemporaryTextureP1P2P3(buttonTexture[(int)Enum.kButtonTexture_ColouredBack], true, "StageChooseBack_iPad.png", Texture2D_RossPixelFormat.
			                  t_RGB565,(int)Enum.kButtonTexture_ColouredBack,LoadADCQueue.AssetType.ktextureFrontEnd);
			            }
           				else 
						{
			                if (Globals.deviceIPhone4) 
								{
			                    buttonTexture[(int)Enum.kButtonTexture_ColouredBack] = this.LoadTemporaryTextureP1P2P3(buttonTexture[(int)Enum.kButtonTexture_ColouredBack], true, "StageChooseBack_iPad.png", Texture2D_RossPixelFormat.
			                      t_RGB565,(int)Enum.kButtonTexture_ColouredBack,LoadADCQueue.AssetType.ktextureFrontEnd);
			                }
			                else {
			                    buttonTexture[(int)Enum.kButtonTexture_ColouredBack] = this.LoadTemporaryTextureP1P2P3(buttonTexture[(int)Enum.kButtonTexture_ColouredBack], true, "StageChooseBack.png", Texture2D_RossPixelFormat.
			                      t_RGB565,(int)Enum.kButtonTexture_ColouredBack,LoadADCQueue.AssetType.ktextureFrontEnd);
			                }

			                buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium] = this.LoadTemporaryTextureIfNecessaryP1P2P3(buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium], true, "ShaunOnPodium.png", Texture2D_RossPixelFormat.
			                  t_RGB565,(int)Enum.kButtonTexture_ShaunOnPodium,LoadADCQueue.AssetType.ktextureFrontEnd);
			            }

            if (firstTime) Globals.g_main.RenderLoadingBar();

            if (firstTime) Globals.g_main.RenderLoadingBar();

            buttonTexture[(int)Enum.kButtonTexture_SwitchOff] = this.LoadTemporaryTextureP1P2(buttonTexture[(int)Enum.kButtonTexture_SwitchOff], true, "LabelOff.png",(int)Enum.kButtonTexture_SwitchOff,LoadADCQueue.AssetType.ktextureFrontEnd);
            buttonTexture[(int)Enum.kButtonTexture_Keyboard] = this.LoadTemporaryTextureP1P2(buttonTexture[(int)Enum.kButtonTexture_Keyboard], true, "Button_Keyboard.png",(int)Enum.kButtonTexture_Keyboard,LoadADCQueue.AssetType.ktextureFrontEnd);
            if (firstTime) Globals.g_main.RenderLoadingBar();

            if (Globals.deviceIPad) {
                buttonTexture[(int)Enum.kButtonTexture_HowToTiltH] = this.LoadTemporaryTextureP1P2P3(buttonTexture[(int)Enum.kButtonTexture_HowToTiltH], true, "HowToTiltH.png", Texture2D_RossPixelFormat.t_RGBA8888,(int)Enum.kButtonTexture_HowToTiltH,LoadADCQueue.AssetType.ktextureFrontEnd);
                buttonTexture[(int)Enum.kButtonTexture_HowToFinger] = this.LoadTemporaryTextureP1P2P3(buttonTexture[(int)Enum.kButtonTexture_HowToFinger], true, "HowToFinger.png", Texture2D_RossPixelFormat.t_RGBA8888,(int)Enum.kButtonTexture_HowToFinger,LoadADCQueue.AssetType.ktextureFrontEnd);
            }
            else {
                buttonTexture[(int)Enum.kButtonTexture_HowToTiltH] = this.LoadTemporaryTextureP1P2(buttonTexture[(int)Enum.kButtonTexture_HowToTiltH], true, "HowToTiltH.png",(int)Enum.kButtonTexture_HowToTiltH,LoadADCQueue.AssetType.ktextureFrontEnd);
                buttonTexture[(int)Enum.kButtonTexture_HowToFinger] = this.LoadTemporaryTextureP1P2(buttonTexture[(int)Enum.kButtonTexture_HowToFinger], true, "HowToFinger.png",(int)Enum.kButtonTexture_HowToFinger,LoadADCQueue.AssetType.ktextureFrontEnd);
            }

            buttonTexture[(int)Enum.kButtonTexture_GreenAnt] = this.LoadTemporaryTextureP1P2P3(buttonTexture[(int)Enum.kButtonTexture_GreenAnt], true, "Button_GreenAnt.png", Texture2D_RossPixelFormat.t_RGBA8888,(int)Enum.kButtonTexture_GreenAnt,LoadADCQueue.AssetType.ktextureFrontEnd);
            if (firstTime) Globals.g_main.RenderLoadingBar();

        }

        public void ReleaseAllButtons()
        {
			UnityEngine.Debug.Log("FrontEnd: Release All Buttons");
			
            for (int i = 0; i < (int) FrontEndScreenEnum.kNumFrontEndScreens; i++) {
                (screen[i]).ReleaseAllButtons();
            }

        }

        public void ReleaseTemporaryTextures()
        {
            for (int i = 0; i < (int)Enum.kNumButtonTextures; i++) {
                if (buttonTexture[i] != null) 
				{
                    if ((i != (int)Enum.kButtonTexture_StartGame) && (i != (int)Enum.kButtonTexture_MenuBackGround) && (i != (int)Enum.kButtonTexture_HandStamp) && (i !=
                      (int)Enum.kButtonTexture_TitleWord1) && (i != (int)Enum.kButtonTexture_QueryOk) && (i != (int)Enum.kButtonTexture_QueryYes) && (i != (int)Enum.kButtonTexture_QueryNo) && (i !=
                      (int)Enum.kButtonTexture_QueryBackdrop) && (i != (int)Enum.kButtonTexture_TrophyGold) && (i != (int)Enum.kButtonTexture_QueryText_QuitLB) && (i !=
                      (int)Enum.kButtonTexture_QueryText_ClearLB) && (i != (int)Enum.kButtonTexture_TitleWord2) && (i != (int)Enum.kButtonTexture_GreenAntStamp) && (i != (int)Enum.kButtonTexture_Back
                      ) && (i != (int)Enum.kButtonTexture_TrophyGlow)) {
                        Globals.Assert(buttonTexture[i] != null);
                        buttonTexture[i].Dealloc();
                        buttonTexture[i] = null;
                    }

                }

            }

        }

        public void LoadTexturesOneTime()
        {
            buttonTexture[(int)Enum.kButtonTexture_MenuBackGround] = Globals.g_world.LoadTextureP1P2(true, "BlueBack.png", Texture2D_RossPixelFormat.t_RGB565,(int)Enum.kButtonTexture_MenuBackGround,LoadADCQueue.AssetType.ktextureFrontEnd);
            buttonTexture[(int)Enum.kButtonTexture_QueryOk] = Globals.g_world.LoadTextureP1(true, "LabelOk.png",(int)Enum.kButtonTexture_QueryOk,LoadADCQueue.AssetType.ktextureFrontEnd);
            buttonTexture[(int)Enum.kButtonTexture_QueryYes] = Globals.g_world.LoadTextureP1(true, "LabelYes.png",(int)Enum.kButtonTexture_QueryYes,LoadADCQueue.AssetType.ktextureFrontEnd);
            buttonTexture[(int)Enum.kButtonTexture_QueryNo] = Globals.g_world.LoadTextureP1(true, "LabelNo.png",(int)Enum.kButtonTexture_QueryNo,LoadADCQueue.AssetType.ktextureFrontEnd);
            buttonTexture[(int)Enum.kButtonTexture_QueryBackdrop] = Globals.g_world.LoadTextureP1(true, "dialogueBack.png",(int)Enum.kButtonTexture_QueryBackdrop,LoadADCQueue.AssetType.ktextureFrontEnd);
        }

        public FrontEnd()
        {
            //if (!base.init()) return null;

            alertViewPermission = null;
            readGoogleTimer = 0.0f;
            isInternetOn = false;

			if (Constants.TESTING_ALERTS)
				initMenuAtRaceScreen = 4;
			else
				initMenuAtRaceScreen = -1;

            initMenuWithWellDone = false;
			
			if (Constants.TESTING_POPUP)
			{
//initMenuWithWellDone = true;
			}
			
            if (true){//Globals.deviceIPad) {
                kChooseTrackBackBarTopPosY = 15.5f;
            }
         //   else {
             //   kChooseTrackBackBarTopPosY = 16.0f;
           // }

            #if NOT_FINAL_VERSION
            #endif

            for (int i = 0; i <  (int)Enum2.kNumStages; i++) 
				lastSelectedLevel[i] = (short)(i * (int)Profile.Enum6.kNumLevelsPerCup);

            currentColour = Constants.kColourGreenMenuBack;
            currentColourRays = Constants.kColourGreenMenuBackRays;
            firstForDay = true;
            appleWonChooseTrack = null;
            slideInCharacter = new SlideInCharacter();
            selectedStage = 0;
            selectedTerrain = 0;
            if (Globals.deviceIPad){//Globals.deviceIPad) {
                selectedControls = 1;
            }
            else {
                selectedControls = 0;
            }

            numTrackSends = 0;
            creditsText = new CreditsText();
            handStamp = new Zobject();
            titleWord1 = new Zobject();
            titleWord2 = new Zobject();
            greenAntLogo = new Zobject();
            shake = new Zshake();
            firstInit = true;
            showingThatCupIsUnlocked = false;
            //lightBall = new LightBall();
            for (int i = 0; i < (int) FrontEndScreenEnum.kNumFrontEndScreens; i++) {
                screen[i] = new FrontEndScreen(i, this);
            }

            //CrashLandingAppDelegate.Print_free_memory();
            //CrashLandingAppDelegate.Print_free_memory();
            profile = new Profile();
            //CrashLandingAppDelegate.Print_free_memory();
            chooseTrackButtonId = 0;
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack]).SetSelectedLevel(0);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack]).SetSelectedLevel(0);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack]).SetSelectedLevel(0);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack]).SetSelectedLevel(0);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack]).SetSelectedLevel(0);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack]).SetSelectedLevel(0);
            hopTimerGreenAnt = 0.0f;
            hopTimerLB = 5.0f;
            exitInfo.multiplayer = false;

            if (Constants.SKIP_FRONTEND)
			{
                if (Constants.START_LB_LEVEL)
				{
                    exitInfo.playCustomLevel = true;

                    if (Constants.START_LB)
					{
                        exitInfo.goToLevelBuilder_Ross = true;
					}
				}
			}

           // Globals.Assert((bool)( (int)Enum2.kNumStages == ((int)Profile.Enum4.kNumCups + 1)));

            Globals.Assert((int)(Profile.Enum4.kCupCountryside) ==  (int)Enum2.kStageCountry);

            xBackButton = Globals.g_world.xScreenEdge + 45.0f;// 52.0f;
            if (Globals.deviceIPad) {
                xBackButton = 22.0f;
            }
			
			
			
            //return this;
        }
        public void AddAboutGenericButtonsP1P2(FrontEndScreenEnum thisScreen, bool isFirstScreen, bool isLastScreen)
        {
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position.x = 60;
            buttonInfo.position.y = 420;
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);

            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position.y = 410.0f;
            if (!isFirstScreen) 
			{
                buttonInfo.position.x = 40;
                buttonInfo.texture = null;
                buttonInfo.goToScreen = (FrontEndScreenEnum)(thisScreen - 1);
                int buttonId2 = (screen[(int)thisScreen]).AddButton(buttonInfo);
                ((screen[(int)thisScreen]).GetButton(buttonId2)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Left);
                ((screen[(int)thisScreen]).GetButton(buttonId2)).SetActionId( FrontEndActions.kFrontEndAction_SlideAboutShitLeft);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowScale(0.6f);
            }
            else {
            }

            if (!isLastScreen) {
                buttonInfo.position.x = 280;
                buttonInfo.texture = null;
                buttonInfo.goToScreen = (FrontEndScreenEnum)(thisScreen + 1);
                buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Right);
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_SlideAboutShitRight);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.6f);
            }

            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
        }

 
        public void FirstInitialisation()
        {
            this.LoadTexturesOneTime();
            this.LoadTexturesTemporary(true);
            this.SetupAllScreens();
            profile.FirstInitialisation();
        }

        public void InitialiseFrontEnd()
        {
            handStamp.SetState( ZobjectState.kZobjectHidden);
            greenAntLogo.SetState( ZobjectState.kZobjectHidden);
            titleWord1.SetState( ZobjectState.kZobjectHidden);
            titleWord2.SetState( ZobjectState.kZobjectHidden);
            frontEndDone = false;
            if (firstInit && !Constants.TESTING_ALERTS) {
                currentScreen = FrontEndScreenEnum.kFrontEndScreen_LoadingScreenEnd;
                firstInit = false;
            }
            else {
                if (Globals.g_world.goingToFrontEndFromShowLevel == 1) {
                    currentScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseTrack;
                    Globals.g_world.SetGoingToFrontEndFromShowLevel(-1);
                }
                else if (Globals.g_world.goingToFrontEndFromShowLevel == 2) {
                    currentScreen = FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack;
                    Globals.g_world.SetGoingToFrontEndFromShowLevel(-1);
                }
                else if (Globals.g_world.goingToFrontEndFromShowLevel == 3) {
                    currentScreen = FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack;
                    Globals.g_world.SetGoingToFrontEndFromShowLevel(-1);
                }
                else if (initMenuAtRaceScreen >= 0) {
                    currentScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseStage;
                    selectedStage = initMenuAtRaceScreen;
                }
                else currentScreen = FrontEndScreenEnum.kFrontEndScreen_Main;

            }

            this.SetupScreen(currentScreen);
        }

        public void CleanUpFrontEnd()
        {
        }

        public void StartTitleScreen()
        {
	        (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash]).StopRender();
	        (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Blink]).StopRender();
	     //   (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo]).StopRender();
			
	      //  (Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash]) = null;
	     //   (Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo]) = null;

			
			titleWord1.SetWaitToShow(0.5f);
            titleWord1.Show();
            titleWord2.SetWaitToShow(1);
            titleWord2.Show();
            handStamp.SetWaitToShow(2.2f);
        }
		
		public void AttemptStopMusic()
		{
			if (profile.preferences.musicOn)
			{										
				if (currentScreen == FrontEndScreenEnum.kFrontEndScreen_GreenAnt)
				{
					SoundEngine.Instance().AVStopSound((int)Audio.Enum2.kSoundEffect_MusicLoop);
				}
				else
				{
					SoundEngine.Instance().AVStopSound((int)Audio.Enum2.kSoundEffect_MenuMusicLoop);
				}
			}
		}
		public void AttemptStartMusic()
		{
			if (profile.preferences.musicOn)
			{										
				if (currentScreen == FrontEndScreenEnum.kFrontEndScreen_GreenAnt)
				{
					SoundEngine.Instance().AVPlaySound((int)Audio.Enum2.kSoundEffect_MusicLoop);
				}
				else
				{
					SoundEngine.Instance().AVPlaySound((int)Audio.Enum2.kSoundEffect_MenuMusicLoop);
				}
			}
		}
		
        public void DoScreenShowIndividualities()
        {
            int myId = (int)currentScreen;
            if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_Main) {
				
	        (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash]).StopRender();
	        (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Blink]).StopRender();
	       // (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo]).StopRender();
			
								Globals.g_main.chillingoBoard.gameObject.SetActive(false);

	      //  (Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash]) = null;
	      //  (Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo]) = null;
				
				
            }

            if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_Title) {
                this.StartTitleScreen();
            }

            if ((myId >= (int) FrontEndScreenEnum.kFrontEndScreen_About_2_8) && (myId <= (int) FrontEndScreenEnum.kFrontEndScreen_About_5)) {
                ((Globals.g_world.game).tileMap).StartOfRace();
                ((Globals.g_world.game).tileMap).InitialiseBeforeObjectsAdded((int) SceneType.kSceneGrass);
                if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_About_5) {
                    ((Globals.g_world.game).tileMap).AddStoneWallP1P2(5, 2, 2);
                }

                if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_About_3) {
                    ((Globals.g_world.game).tileMap).AddHedgeP1P2(3, 5, 4);
                    ((Globals.g_world.game).tileMap).AddHedgeP1P2(5, 7, 4);
                    ((Globals.g_world.game).tileMap).AddPondP1(1, 7);
                }
                else if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_About_4) {
                }

                ((Globals.g_world.game).tileMap).RefreshTextures();
            }

            if ((myId == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || (myId == (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) || (myId == (
              int) FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack) || (myId == (int) FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack) || (myId
              == (int) FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack) || (myId == (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack)) {
                if ((myId == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || (myId == (int) FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack))
                  {
                    (screen[myId]).SetSelectedLevel(profile.selectedLevel);
                }
                else if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) 
				{
                    selectedStage = (int)Enum2.kStageBonusLevels;
                    (screen[myId]).SetSelectedLevel(profile.selectedLevel);
                }
                else (screen[myId]).SetSelectedLevel(profile.selectedLevelCustom);

                {
                }
                if ((screen[myId]).selectedLevel != -1) {
                    (screen[myId]).SetLastPressedButton((screen[myId]).selectedLevel);
                }

                this.ShowCurrentLevel();
            }

        }

        public void SetPreferencesFromSwitches()
        {
            Profile.ProfilePreferences newPrefs = new Profile.ProfilePreferences();
            newPrefs.diffEasy = (bool) ((screen[(int)currentScreen]).GetSwitch(0)).GetStateBool();
            newPrefs.musicOn = (bool) ((screen[(int)currentScreen]).GetSwitch(1)).GetStateBool();
            newPrefs.soundFxOn = (bool) ((screen[(int)currentScreen]).GetSwitch(2)).GetStateBool();
            newPrefs.ghostOn = (bool) ((screen[(int)currentScreen]).GetSwitch(3)).GetStateBool();
            newPrefs.controlTilt = controlTilt;
            newPrefs.controlFinger = controlFinger;
            newPrefs.tiltExpert = false;
            profile.SetPreferences(newPrefs);
            CrashLandingAppDelegate.SetAcceleromterOnOrOff(newPrefs.controlTilt);
        }

        public void ExitScreenChooseControls()
        {
            Profile.ProfilePreferences oldPrefs = new Profile.ProfilePreferences();
            oldPrefs = profile.preferences;
            oldPrefs.controlTilt = controlTilt;
            oldPrefs.controlFinger = controlFinger;
            profile.SetPreferences(oldPrefs);
            profile.SaveBestTimesAndPrefs();
            CrashLandingAppDelegate.SetAcceleromterOnOrOff(oldPrefs.controlTilt);
        }

        public void ExitScreenMain()
        {
						Globals.g_world.HidePullTab();
            if (slideInShown) {
                slideInCharacter.Hide();
            }

            if (Globals.deviceIPad) {
            }
			
        }
		
		public void OnGUI()
		{
			screen[(int)currentScreen].OnGUI();
		}

		
		public void StopRenderCurrentScreen()
		{
			this.StopRenderScreen(currentScreen);
		}
		
		public void StopRenderScreen(FrontEndScreenEnum inScreen)
		{
			screen[(int)inScreen].StopRender();
			
			if (inScreen == FrontEndScreenEnum.kFrontEndScreen_GreenAnt)
			{
                (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash]).StopRender();
                (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Blink]).StopRender();
				creditsText.StopRender();
			}
		}

		
		public void ExitScreenP1(FrontEndScreenEnum oldScreen, FrontEndScreenEnum newScreen)
        {
			this.StopRenderScreen(oldScreen);
			
            switch (oldScreen) {
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose :
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTilt :
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTiltExpert :
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowThumb :
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Final :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild :
                slideInCharacter.Hide();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_Main :
                this.ExitScreenMain();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ChooseControls :
                this.ExitScreenChooseControls();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_EnterTrackName :
                this.ExitScreenEnterName();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_Options :
                this.SetPreferencesFromSwitches();
                profile.SaveBestTimesAndPrefs();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_GreenAnt :
                if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                    (SoundEngine.Instance()).AVChangeToTrackP1((int)Audio.Enum2.kSoundEffect_MenuMusicLoop, 0.4f);
                }

                (ParticleSystemRoss.Instance()).StopParticleEffect(greenAntEffectId);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_WaitForClient :
                this.ExitScreenWaitForClient();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_BrowseServers :
                this.ExitScreenBrowseServers(newScreen);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_LoadingScreenEnd :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_Title :
                this.ExitScreenTitle();
                break;
            default :
                break;
            }

        }

        public void ApplyPrefsToOptionsScreen()
        {
            ((screen[(int)currentScreen]).GetSwitch(0)).SetState(( profile.preferences.diffEasy));
            ((screen[(int)currentScreen]).GetSwitch(1)).SetState((profile.preferences.musicOn));
            ((screen[(int)currentScreen]).GetSwitch(2)).SetState(( profile.preferences.soundFxOn));
            ((screen[(int)currentScreen]).GetSwitch(3)).SetState((profile.preferences.ghostOn));
            controlTilt = profile.preferences.controlTilt;
            controlFinger = profile.preferences.controlFinger;
            this.SetupOptionsControlButtShow();
        }

        public void HideBonusCloudIfNotUnlockedYet()
        {
            if (!this.IsBonusCloudVisible()) {
                ((screen[(int)currentScreen]).GetButton(bonusButtonId)).Disappear();
            }

        }

        public void HideButtonsNotVisibleYet(FrontEndScreenEnum newScreen)
        {
            int numTracks = 8;
            if (selectedStage == (int)Enum2.kStageBonusLevels) {
                numTracks = 3;
            }

            for (int l = 0; l < numTracks; l++) {
                int profileLevelId = l + (8 * selectedStage);
                if (!profile.IsLevelVisible(profileLevelId)) {
                    if (selectedStage == (int)Enum2.kStageBonusLevels) {
                    }
                    else {
                    }

                }

            }

            int level = (screen[(int)currentScreen]).selectedLevel;
            TrophyType t = ((Globals.g_world.frontEnd).profile).GetTrophyGot(level);
            if ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                if (t == TrophyType.kTrophy_NotGot) if (profile.preferences.diffEasy) {
                }

            }

        }

        public void FreeTitleTextures()
        {
            if (buttonTexture[(int)Enum.kButtonTexture_HandStamp] != null) {
                (Globals.g_world.game).FreeTitleTextures();
                Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_RunningSheep1] = null;
                Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_RunningSheep2] = null;
                Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_RunningSheep3] = null;
                buttonTexture[(int)Enum.kButtonTexture_HandStamp] = null;
                buttonTexture[(int)Enum.kButtonTexture_GreenAntStamp] = null;
                buttonTexture[(int)Enum.kButtonTexture_HandStamp] = null;
            }

        }

        public void ExitScreenTitle()
        {
           // if (loadingAtlas != null) {
            ///}

        }

        public void ExitScreenWaitForClient()
        {
        }

        public void ExitScreenBrowseServers(FrontEndScreenEnum newScreen)
        {
        }

        public void ShowScreenFeatureNot()
        {
        //    string inMessage;
/*            if (Globals.g_world.deviceType == (int) UIDevicePlatform.UIDevice1GiPhone) {
                inMessage = "Sorry - this feature is not currently available on the first generation iPhone";
            }
            else if (Globals.g_world.deviceType == (int) UIDevicePlatform.UIDevice1GiPod) {
                inMessage = "Sorry - this feature is not currently available on the first generation iPod";
            }
            else {
                inMessage = "Sorry - this feature is not currently available on your device";
            }*/

        }

        public void ShowScreenMultiplayerConnect()
        {
//            this.StartConnection();
        }

        public void ShowScreenWaitForClient()
        {
  //          this.StartConnection();
        }

        public void ShowScreenReceivedTrack()
        {
            profile.SaveCustomLevelInformation();
        }

        public void ShowScreenBrowseServers()
        {
    //        this.StartConnection();
        }

        public void SelectNetworkTrackButtonAction(FrontEndButton pressedButton)
        {
        }

        public void ShowScreenLBPlayOrBuild()
        {
            profile.CheckAndLoadCustomLevelInformation();
        }

        public void UpdateServerList()
        {
            refreshServerTexts = true;
        }

        public void MakeSureSelectedStageIsAppropriate(FrontEndScreenEnum inScreen)
        {
            if (((int)inScreen != (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) && ((int)inScreen != (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) &&
              ((int)inScreen != (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack)) {
                if (selectedStage >= (int)Profile.Enum6.kNumPagesForCustomLevels) {
                    this.SelectNewStage(0);
                    return;
                }

            }

            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
                this.SelectNewStage((int)Enum2.kStageBonusLevels);
            }
            else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack) {
                this.SelectNewStage(0);
            }
            else {
                if (!profile.IsStageAvailable(selectedStage)) {
                    this.SelectNewStage(0);
                }

            }

        }

        public void ShowScreenOptions()
        {
            this.ApplyPrefsToOptionsScreen();
           // if (!Globals.g_world.CanConnectToInternet()) {
           //     ((screen[(int)currentScreen]).GetSwitch(4)).SetState( SwitchState.kSwitch_On);
             //   return;
            //}

        }

        public void ShowScreenMain()
        {
            Globals.g_world.ShowPullTab();
            if (initMenuWithWellDone) {
                this.ShowPopUpWellDone();
            }
			
			if (Constants.TESTING_POPUP)
			{
				
				//this.OpenQuitAlert();
			//Globals.g_world.game.OpenHowYouLikeMeNowDialogue();
				this.ShowPopUpSpecialLockUnlocked();
			//	this.ShowPopUpSpecialLock();
        //        this.ShowPopUpWellDone();
				//initMenuWithWellDone = true;
			}

            #if SHOW_GAMECENTER_OVER_MAIN
                if (!profile.haveTriedGameCenterYet) {
                    this.SetupCrystalForGameCentre();
                }

            #endif

            if (profile.profileInfo.haveSeenControlChoiceYet) {

                    #if !ALWAYS_SHOW_TILT_THUMB_OPTIONS
                        ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(mainRaceButtonId)).SetGoToScreen( FrontEndScreenEnum.
                          kFrontEndScreen_ChooseStage);
                    #endif


            }

//            this.ReadGoogleText();
            slideInCharacterMainTimer = 2.0f;
            slideInShown = false;
            ////glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Globals.g_world.SetHaveReachedTitleYet(true);
            this.FreeTitleTextures();
            if (profile.preferences.controlTilt) {
            }
            else {
            }

        }

        public void EnteringTheAboutScreens()
        {
            if (Globals.g_world.currentlyLoadedScene != (int) SceneType.kSceneGrass) {
                if (Globals.g_world.currentlyLoadedScene != -1) {
                    Globals.g_world.ReleaseCurrentSceneAtlases();
                }

                Globals.g_world.LoadCountryAtlases();
                Globals.g_world.SetCurrentlyLoadedScene((int) SceneType.kSceneGrass);
            }

            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_About_4]).GetButton(3)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
              kAtlas_GameThingsGrass));
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_About_4]).GetButton(4)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
              kAtlas_GameThingsGrass));
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_About_4]).GetButton(5)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
              kAtlas_GameThingsGrass));
        }


        public void SetupCrystalForGameCentre()
        {
            if (!profile.haveTriedGameCenterYet) {
                profile.SetHaveTriedGameCenterYet(true);
                Console.WriteLine("autherti");
            }
            else {

                #if !SHOW_GAMECENTER_OVER_MAIN
                    this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Main);
                #endif

                this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Main);
            }

        }

        public void HandleTap(CGPoint position)
        {
            if (Globals.g_world.worldState != WorldState.e_FrontEnd) return;

            if (((Ztransition.GetTransition()).inTransition) && ((int)(Ztransition.GetTransition()).area == (int) TransitionArea.kTransition_Frontend)) return;

            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Title) {
                if (false) {
                    (screen[(int)currentScreen]).HandleTap(position);
                    greenAntLogo.SetZobjectState( ZobjectState.kZobjectHidden);
                    this.StartTitleScreen();
                }
                else {

                    #if DROPBOX_ENABLED
                        if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                            (SoundEngine.Instance()).AVFadeOutAndStopP1((int)Audio.Enum1.kSoundEffect_MenuMusicLoop, 0.4f);
                        }

                        this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_BehindCrystalSplash);
                    #else
                        if (false) {
                            if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                                (SoundEngine.Instance()).AVFadeOutAndStopP1((int)Audio.Enum2.kSoundEffect_MenuMusicLoop, 0.4f);
                            }

                            profile.SetSeenCrystalSplash();
                            profile.SaveBestTimesAndPrefs();
                            this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_BehindCrystalSplash);
                        }
                        else {
                            if (!profile.haveTriedGameCenterYet) {
                                this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Main);
                            }
                            else {
                                this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Main);
                            }

                        }

                    #endif

                }

            }
            else {
                if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) {
                    if (chooseStageLateralSlideTimer > 0.0f) {
                        (screen[(int)currentScreen]).HandleTapOnButtonP1(chooseStageSideButtonId, position);
                        (screen[(int)currentScreen]).HandleTapOnButtonP1(chooseStageSideButtonId + 1, position);
                    }
                    else {
                        (screen[(int)currentScreen]).HandleTap(position);
                    }

                }
                else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                    if (chooseStageLateralSlideTimer > 0.0f) {
                        (screen[(int)currentScreen]).HandleTapOnButtonP1(chooseStageSideButtonIdCT[(int)currentScreen], position);
                        (screen[(int)currentScreen]).HandleTapOnButtonP1(chooseStageSideButtonIdCT[(int)currentScreen] + 1, position);
                    }
                    else {
                        (screen[(int)currentScreen]).HandleTap(position);
                    }

                }
                else {
                    (screen[(int)currentScreen]).HandleTap(position);
                }

            }

        }

        public void UpdateInternetStatus()
        {
        }

        public void UpdateTransition()
        {
            if (!(Ztransition.GetTransition()).inTransition) return;

            if ((int)(Ztransition.GetTransition()).area != (int) TransitionArea.kTransition_Frontend) return;

            if ((Ztransition.GetTransition()).timeToDoStuff) {
                if ((Ztransition.GetTransition()).nextState == (int) (int) FrontEndScreenEnum.kFrontEndScreen_ExitMenuSystem) {
                    frontEndDone = true;
                }
                else {
                    this.SetupScreen((FrontEndScreenEnum)(Ztransition.GetTransition()).nextState);
                }

            }

        }

        public void ViewScoresLeaderboard()
        {

            if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                (SoundEngine.Instance()).AVFadeOutAndStopP1((int)Audio.Enum2.kSoundEffect_MenuMusicLoop, 0.4f);
            }

        }

        public void ExitScreenEnterName()
        {
            //gameOverTextField.Hidden = true;
//            int whichLevel = profile.selectedLevelCustom;
//            profile.WriteCustomLevelNameP1P2(whichLevel, ((Globals.g_world.game).lBuilder).currentScene, gameOverTextField.Text);
            profile.SaveCustomLevelInformation();
        }

        public void ShowScreenBehindGameCenter()
        {
            inScreenTimer = 0.0f;
        }

        public void ShowScreenBehindCrystalSplash()
        {

            #if DROPBOX_ENABLED
                inScreenTimer = 0.0f;
                if (!(DBSession.SharedSession()).IsLinked()) {
                    Globals.g_main.ShowDropboxThing();
                    g_myViewController.ShowDropboxThing();
                }
                else {
                    this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_LoadingFilesFromDropbox);
                    g_myViewController.StartGettingThings();
                }

            #else
            #endif

        }

        public void DropboxLoadingFailed()
        {
            this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Main);
        }

        public void LoadedFileFromDropbox()
        {

        }

        public void ShowScreenEnterName()
        {
        //    gameOverTextField.Hidden = false;
          //  gameOverTextField.Text = profile.GetCustomLevelName();
        }

        public void SubmitScores()
        {
            for (int level = 0; level < 19; level++) {
                float theScore = profile.GetBestTimeP1( BestTimeSet.t_Normal, level);
                if (theScore < 1000) {
                    int leaderboardId = level;
                    if (leaderboardId == 10) leaderboardId = 23;
                    else {
                        if (level > 1) leaderboardId += 2;

                        if (leaderboardId > 11) if (leaderboardId > 16) leaderboardId += 1;

                        if (leaderboardId > 20) leaderboardId += 1;

                    }

                }

            }

        }

        public void SetupFromAndToColours()
        {
            colourFadeFrom = this.GetColourFromStageP1(lateralSlideFrom, false);
            colourFadeFromRays = this.GetColourFromStageP1(lateralSlideFrom, true);
            colourFadeTo = this.GetColourFromStageP1(lateralSlideTo, false);
            colourFadeToRays = this.GetColourFromStageP1(lateralSlideTo, true);
        }

        public void SetupFromAndToColoursTerrain()
        {
            colourFadeFrom = this.GetColourFromTerrainP1(lateralSlideFrom, false);
            colourFadeFromRays = this.GetColourFromTerrainP1(lateralSlideFrom, true);
            colourFadeTo = this.GetColourFromTerrainP1(lateralSlideTo, false);
            colourFadeToRays = this.GetColourFromTerrainP1(lateralSlideTo, true);
        }

        public void ChooseTrackSelectNewLevelInStage(int inStage)
        {
            Globals.Assert( (int)Enum2.kNumStages == (int)Profile.Enum4.kNumCups + 1);
            Globals.Assert(inStage <  (int)Enum2.kNumStages);
            int newLevel = lastSelectedLevel[inStage];
            this.SetSelectedLevelOnChooseTrackP1((int)currentScreen, newLevel);
            this.ShowCurrentLevel();
        }

        public void SetControlFromSelected(int newSelected)
        {
            switch (newSelected) {
            case 0 :
                controlFinger = false;
                controlTilt = true;
                break;
            case 1 :
                controlFinger = true;
                controlTilt = false;
                break;
            case 2 :
                controlFinger = false;
                controlTilt = false;
                break;
            default :
                Globals.Assert(false);
                break;
            }

        }

        public void ControlSelectGoForwardOne()
        {
            (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Swish, 0.26f);
            int chooseStageButton = chooseControlsSideButtonId;
            chooseStageLateralSlideTimer = kStageLateralSlideTime;
            lateralSlideFrom = selectedControls;
            lateralSlideTo = selectedControls + 1;
            ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            this.SetControlFromSelected(lateralSlideTo);
            if (lateralSlideTo == (3 - 1)) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).Hide();
            }

            if ((((screen[(int)currentScreen]).GetButton(chooseStageButton)).zobject).state ==  ZobjectState.kZobjectHidden) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).Show();
            }

            colourFadeTimer = kStageLateralSlideTime;
            (((screen[(int)currentScreen]).GetButton(4)).hangingButton).Show(0.8f);
        }

        public void TerrainSelectGoForwardOne()
        {
            (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Swish, 0.26f);
            int chooseStageButton = chooseTerrainSideButtonId;
            chooseStageLateralSlideTimer = kStageLateralSlideTime;
            lateralSlideFrom = selectedTerrain;
            lateralSlideTo = selectedTerrain + 1;
            ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            if (lateralSlideTo == (2 - 1)) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).Hide();
            }

            if ((((screen[(int)currentScreen]).GetButton(chooseStageButton)).zobject).state ==  ZobjectState.kZobjectHidden) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).Show();
            }

            this.SetupFromAndToColoursTerrain();
            colourFadeTimer = kStageLateralSlideTime;
    //        (((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnTerrain - 1 + (0 * 2))).hangingButton).Show(0.8f);
     //       (((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnTerrain - 1 + (1 * 2))).hangingButton).Show(0.8f);
        }

        public void TerrainSelectGoBackOne()
        {
            (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Swish, 0.26f);
            int chooseStageButton = chooseTerrainSideButtonId;
            chooseStageLateralSlideTimer = kStageLateralSlideTime;
            lateralSlideFrom = selectedTerrain;
            lateralSlideTo = selectedTerrain - 1;
            ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            if (lateralSlideTo == 0) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).Hide();
            }

            if ((((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).zobject).state ==  ZobjectState.kZobjectHidden) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).Show();
            }

            this.SetupFromAndToColoursTerrain();
            colourFadeTimer = kStageLateralSlideTime;
      //      (((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnTerrain - 1 + (0 * 2))).hangingButton).Show(0.8f);
     //       (((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnTerrain - 1 + (1 * 2))).hangingButton).Show(0.8f);
        }

        public void ControlSelectGoBackOne()
        {
            (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Swish, 0.26f);
            int chooseStageButton = chooseControlsSideButtonId;
            chooseStageLateralSlideTimer = kStageLateralSlideTime;
            lateralSlideFrom = selectedControls;
            lateralSlideTo = selectedControls - 1;
            this.SetControlFromSelected(lateralSlideTo);
            ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            if (lateralSlideTo == 0) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).Hide();
            }

            if ((((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).zobject).state ==  ZobjectState.kZobjectHidden) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).Show();
            }

            colourFadeTimer = kStageLateralSlideTime;
            (((screen[(int)currentScreen]).GetButton(4)).hangingButton).Show(0.8f);
        }

        public void WobbleIncomingStageButton(int inStage)
        {
            if (((screen[(int)currentScreen]).GetButton((inStage * 3) + 0)).hangingButton != null) {
                (((screen[(int)currentScreen]).GetButton((inStage * 3) + 0)).hangingButton).Show(0.8f);
            }

            if (((screen[(int)currentScreen]).GetButton((inStage * 3) + 1)).hangingButton != null) {
                (((screen[(int)currentScreen]).GetButton((inStage * 3) + 1)).hangingButton).Show(0.8f);
            }

            if (((screen[(int)currentScreen]).GetButton((inStage * 3) + 2)).hangingButton != null) {
                (((screen[(int)currentScreen]).GetButton((inStage * 3) + 2)).hangingButton).Show(0.75f);
            }

        }

        public void WobbleIncomingStageButtonLevelSelect(int inStage)
        {
            if (((screen[(int)currentScreen]).GetButton((inStage * 9) + 0)).hangingButton != null) {
                (((screen[(int)currentScreen]).GetButton((inStage * 9) + 0)).hangingButton).Show(0.8f);
            }

        }

        public void StageSelectGoForwardOne()
        {
            (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Swish, 0.26f);
            int chooseStageButton;
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) chooseStageButton = chooseStageSideButtonId;
            else chooseStageButton = chooseStageSideButtonIdCT[(int)currentScreen];

            chooseStageLateralSlideTimer = kStageLateralSlideTime;
            lateralSlideFrom = selectedStage;
            lateralSlideTo = selectedStage + 1;
            ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) this.WobbleIncomingStageButton(lateralSlideTo);
            else {
                this.WobbleIncomingStageButtonLevelSelect(lateralSlideTo);
            }

            int howManyScreens = this.GetHowManyScreens(currentScreen);
            if (lateralSlideTo == howManyScreens) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).Hide();
            }

            if ((((screen[(int)currentScreen]).GetButton(chooseStageButton)).zobject).state ==  ZobjectState.kZobjectHidden) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).Show();
            }

            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                this.SetupFromAndToColours();
                colourFadeTimer = kStageLateralSlideTime;
            }

            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) {
                this.ChooseTrackSelectNewLevelInStage(lateralSlideTo);
            }

        }

        public void StageSelectGoBackOne()
        {
            (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Swish, 0.26f);
            int chooseStageButton;
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) chooseStageButton = chooseStageSideButtonId;
            else chooseStageButton = chooseStageSideButtonIdCT[(int)currentScreen];

            chooseStageLateralSlideTimer = kStageLateralSlideTime;
            lateralSlideFrom = selectedStage;
            lateralSlideTo = selectedStage - 1;
            ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) this.WobbleIncomingStageButton(lateralSlideTo);
            else {
                this.WobbleIncomingStageButtonLevelSelect(lateralSlideTo);
            }

            if (lateralSlideTo == 0) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).Hide();
            }

            if ((((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).zobject).state ==  ZobjectState.kZobjectHidden) {
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).Show();
            }

            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                this.SetupFromAndToColours();
                colourFadeTimer = kStageLateralSlideTime;
            }

            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) {
                this.ChooseTrackSelectNewLevelInStage(lateralSlideTo);
            }

        }

        public void UpdateColourFading()
        {
			return;
			
            if (colourFadeTimer > 0.0f) {
                colourFadeTimer -= Constants.kFrameRate;
                float ratio = 1.0f - Utilities.GetRatioP1P2(colourFadeTimer, 0.0f, kStageLateralSlideTime);
                currentColour.cRed = Utilities.SetRatioP1P2(ratio, colourFadeFrom.cRed, colourFadeTo.cRed);
                currentColour.cGreen = Utilities.SetRatioP1P2(ratio, colourFadeFrom.cGreen, colourFadeTo.cGreen);
                currentColour.cBlue = Utilities.SetRatioP1P2(ratio, colourFadeFrom.cBlue, colourFadeTo.cBlue);
                currentColourRays.cRed = Utilities.SetRatioP1P2(ratio, colourFadeFromRays.cRed, colourFadeToRays.cRed);
                currentColourRays.cGreen = Utilities.SetRatioP1P2(ratio, colourFadeFromRays.cGreen, colourFadeToRays.cGreen);
                currentColourRays.cBlue = Utilities.SetRatioP1P2(ratio, colourFadeFromRays.cBlue, colourFadeToRays.cBlue);
            }

        }

        public void UnlockAllLevelsFromFrontend()
        {
            profile.UnlockAllLevelsFromFrontend();
        }

        public void TryTrashCustomLevel()
        {
            int levelId = profile.selectedLevelCustom;
            bool levelYaMade = profile.IsCustomLevelMade(levelId);
            if (!levelYaMade) {
                (screen[(int)currentScreen]).ShowQuery(1);
                (screen[(int)currentScreen]).SetInQuery(true);
            }
            else {
                (screen[(int)currentScreen]).ShowQuery(0);
                (screen[(int)currentScreen]).SetInQuery(true);
            }

        }

        public void TryCreateTrack()
        {
            int levelId = profile.selectedLevelCustom;
            if (!exitInfo.goToLevelBuilder_Ross) {
                if (profile.IsCustomLevelMade(levelId)) {
                    frontEndDone = true;
                }
                else {
                    (screen[(int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack]).ShowQuery(2);
                    (screen[(int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack]).SetInQuery(true);
                }

            }
            else {
                if (profile.IsCustomLevelMade(levelId)) {
                    frontEndDone = true;
                }
                else {
                    this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel);
                }

            }

        }

        public void TryGoToScreenThatNeedsBluetooth(FrontEndScreenEnum toScreen)
        {
            if (false) {
                this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_FeatureNotAvailable);
            }
            else if (false) {
                this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_FeatureNotAvailable);
            }
            else {
                this.ChangeToScreen(toScreen);
            }

        }

        public void TrySendTrackButton()
        {
            int levelId = profile.selectedLevelCustom;
            if (profile.IsCustomLevelMade(levelId)) {
                this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_WaitForClient);
            }
            else {
                (screen[(int)currentScreen]).ShowQuery(0);
                (screen[(int)currentScreen]).SetInQuery(true);
            }

        }

        public void SetupOptionsControlButtShow()
        {
            if (controlTilt) {
                (((screen[(int)currentScreen]).GetButton(optionsControlImage)).zobject).HideAndShowP1(this.GetButtonTexture((int)Enum.kButtonTexture_HowToTiltH), -1);
                (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).HideAndShowP1(null, Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                  kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_Tilt));
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    FunnyWord inF = (screen[(int)currentScreen]).GetFunnyWord(controlWordId);
                    (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).SetupTextChangeForHideAndShowP1(Globals.g_world.GetNSString ( StringId.
                      kString_ControlTilt), inF);
                }

            }
            else {
                if (controlFinger) {
                    (((screen[(int)currentScreen]).GetButton(optionsControlImage)).zobject).HideAndShowP1(this.GetButtonTexture((int)Enum.kButtonTexture_HowToFinger), -1);
                    (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).HideAndShowP1(null, Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                      kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_FingerButt));
                    if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                        FunnyWord inF = (screen[(int)currentScreen]).GetFunnyWord(controlWordId);
                        (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).SetupTextChangeForHideAndShowP1(Globals.g_world.GetNSString ( StringId.
                          kString_ControlFinger), inF);
                    }

                }
                else {
                    (((screen[(int)currentScreen]).GetButton(optionsControlImage)).zobject).HideAndShowP1((Globals.g_world.game).GetTexture((TextureType) TextureType.
                      kTexture_HowToThumbs), -1);
                    (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).HideAndShowP1(null, Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                      kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_Thumb));
                    if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                        FunnyWord inF = (screen[(int)currentScreen]).GetFunnyWord(controlWordId);
                        (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).SetupTextChangeForHideAndShowP1(Globals.g_world.GetNSString ( StringId.
                          kString_ControlThumb), inF);
                    }

                }

            }

        }

        public void SetupOptionsControlButts()
        {
            if (((((screen[(int)currentScreen]).GetButton(optionsControlImage)).zobject).state !=  ZobjectState.kZobjectShown) && ((((screen[(int)currentScreen]
              ).GetButton(optionsControlImage)).zobject).state !=  ZobjectState.kZobjectThrobbing)) {
                return;
            }

            if (controlTilt) {
                (((screen[(int)currentScreen]).GetButton(optionsControlImage)).zobject).HideAndShowP1((Globals.g_world.game).GetTexture((TextureType) TextureType.
                  kTexture_HowToThumbs), -1);
                (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).HideAndShowP1(null, Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                  kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_Thumb));
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    FunnyWord inF = (screen[(int)currentScreen]).GetFunnyWord(controlWordId);
                    (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).SetupTextChangeForHideAndShowP1(Globals.g_world.GetNSString ( StringId.
                      kString_ControlThumb), inF);
                }

                controlTilt = false;
                controlFinger = false;
            }
            else {
                if (controlFinger) {
                    controlTilt = true;
                    controlFinger = false;
                    (((screen[(int)currentScreen]).GetButton(optionsControlImage)).zobject).HideAndShowP1(this.GetButtonTexture((int)Enum.kButtonTexture_HowToTiltH), -1);
                    (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).HideAndShowP1(null, Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                      kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_Tilt));
                    if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                        FunnyWord inF = (screen[(int)currentScreen]).GetFunnyWord(controlWordId);
                        (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).SetupTextChangeForHideAndShowP1(Globals.g_world.GetNSString ( StringId.
                          kString_ControlTilt), inF);
                    }

                }
                else {
                    controlFinger = true;
                    (((screen[(int)currentScreen]).GetButton(optionsControlImage)).zobject).HideAndShowP1(this.GetButtonTexture((int)Enum.kButtonTexture_HowToFinger), -1);
                    (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).HideAndShowP1(null, Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                      kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_FingerButt));
                    if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                        FunnyWord inF = (screen[(int)currentScreen]).GetFunnyWord(controlWordId);
                        (((screen[(int)currentScreen]).GetButton(optionsControl)).zobject).SetupTextChangeForHideAndShowP1(Globals.g_world.GetNSString ( StringId.
                          kString_ControlFinger), inF);
                    }

                }

            }

        }

        public void ShowPopUpSpecialLock()
        {
            int[] numApplesNeeded = new int [10]
            {0, 0, 0, 0, Constants.NUM_APPLES_TO_UNLOCK_5, 0, Constants.NUM_APPLES_TO_UNLOCK_7, 0, Constants.NUM_APPLES_TO_UNLOCK_9, Constants.
                  NUM_APPLES_TO_UNLOCK_10};
            Globals.Assert(selectedStage < 10);
            int nanee = numApplesNeeded[selectedStage];
            string title;
            string urrTitle;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                urrTitle = "Cup Gesperrt";
                title = String.Format("Du musst mehr #pfel sammeln\num diesen Cup freizuschalten", nanee);
//                title = String.Format("Du musst {0} #pfel sammeln, \num diesen Cup freizuschalten", nanee);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                urrTitle = "奖杯已上锁";
                title = String.Format("你需要采集{0}\n个苹果来解锁这\n个奖杯。", nanee);
            }
			 else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                urrTitle = "Coupe bloquée";
                title = String.Format("Récupérez {0} pommes\n pour débloquer\n cette coupe.", nanee);
            }			
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                urrTitle = "Cupはロックされています";
                title = String.Format("このCupをアンロックす\nるにはリンゴを{0}個集\nめなくてはいけません。", nanee);
            }
            else {
                urrTitle = "";
//                title = String.Format("You need to collect\n {0} apples to\nunlock this Cup", nanee);
                title = String.Format("Cup Locked!\n\nYou need to collect\n more apples to\nunlock this Cup", nanee);
//                title = String.Format("You need to collect\n");//\n {0} apples to\nunlock this Cup", nanee);
            }

			UnityUIAlert.UnityUIAlertInfo uInfo = new UnityUIAlert.UnityUIAlertInfo();
			uInfo.type = UnityUIAlertType.e_StageLocked;
			uInfo.title = urrTitle;
			uInfo.message = title;
			uInfo.numButtons = 1;
			uInfo.buttonString[0] = "OK\n";
			uInfo.textScale = 0.6f;
			uInfo.useNSStringAnyway = false;
			Globals.g_world.unityUIAlert.Show(uInfo);
        }

        public void ShowPopUpSpecialLockUnlocked()
        {
            int[] numApplesNeeded = new int [10]
            {0, 0, 0, 0, Constants.NUM_APPLES_TO_UNLOCK_5, 0, Constants.NUM_APPLES_TO_UNLOCK_7, 0, Constants.NUM_APPLES_TO_UNLOCK_9, Constants.
                  NUM_APPLES_TO_UNLOCK_10};
            Globals.Assert(selectedStage < 10);
            int nanee = numApplesNeeded[selectedStage];
            string title;
            string heading;

			UnityUIAlert.UnityUIAlertInfo uInfo = new UnityUIAlert.UnityUIAlertInfo();
			uInfo.type = UnityUIAlertType.e_StageLocked;
			uInfo.numButtons = 1;
			uInfo.buttonString[0] = "OK";
			uInfo.textScale = 0.54f;

			uInfo.useNSStringAnyway = false;
			
			
			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
//				title = String.Format("Sie sammelte {0} Äpfel! \nDieser Cup ist nun\n freigeschaltet!", nanee);
				title = String.Format("Sie sammelte genug #pfel! \nDieser Cup ist nun\n freigeschaltet!", nanee);
                heading = "M#h-rchenhaft!";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                title = String.Format("You collected {0} apples!\n This Cup is now unlocked!", nanee);
                heading = "咩妙极了！";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                title = String.Format("You collected {0} apples!\n This Cup is now unlocked!", nanee);
                heading = "おメェェでとう!";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                title = String.Format("Vous avez recueilli {0} pommes!\n Cette Coupe est\n maintenant débloqué!", nanee);
                heading = "Bêê-Rilliant !";
            }
            else {
                title = String.Format("You got enough apples!\n This Cup is now\n unlocked!", nanee);
                heading = "Baa-Rilliant!";
				uInfo.textScale = 0.6f;
            }
			
			uInfo.title = heading;
			uInfo.message = title;

			Globals.g_world.unityUIAlert.Show(uInfo);

        }
		
        public void ShowPopUpWellDone()
        {
            string title;
            string thanksMessage;
            string brilliant;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_English) {
                title = String.Format(
                  "You've passed all the levels!\nFor more fun, why not try to get\n all the apples!");
//                  "You've passed all the levels!\nFor more fun, why not try to get\n all the apples and all the achievements!?\n");
                thanksMessage = "Thanks for Playing!\n";
                brilliant = "Baa-Rilliant!";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                title = String.Format(
      "ゲーム内すべてのレベルをク\nリアしたぞ！もっとやりこんで、\nすべてのリンゴやトロフィー\nを集めてみないか?");
                thanksMessage = "遊んでくれてありがとう！";
                brilliant = "おメェェェでとう！";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                title = String.Format(
                  "你通过了游戏的所有关卡！\n如果想要获得更多欢乐，\n为什么不试试收集所有苹\n果和成就呢？");
                thanksMessage = "感谢游戏！";
                brilliant = "咩妙极了！";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                title = String.Format(
                  "Vous avez passé tous les niveaux du jeu!\nPourquoi ne pas essayer d'obtenir\n toutes les pommes et tous les succès !?");
                thanksMessage = "Merci d’avoir joué";
                brilliant = "Bêê-Rilliant !";
            }
            else {
                title = String.Format(
//                  "Du hast alle Levels in diesem Spiel \nabgeschlossen!Lust auf mehr Spaß?\n Dann versuch doch mal, alle\n #pfel und Errungenschaften zu sammeln!");
                  "M#h-rchenhaft!\nDu hast alle Levels in diesem Spiel\nabgeschlossen!Lust auf mehr Spass?\n Dann versuch doch mal alle\n #pfel und Errungenschaften zu sammeln!");
                thanksMessage = "Vielen Dank f$rs Spielen!";
                brilliant = "";
            }
			UnityUIAlert.UnityUIAlertInfo uInfo = new UnityUIAlert.UnityUIAlertInfo();
			uInfo.type = UnityUIAlertType.e_FinalWellDone;
			uInfo.title = brilliant;
			uInfo.message = title;
			uInfo.numButtons = 1;
			uInfo.textScale = 0.45f;
			uInfo.useNSStringAnyway = false;
			uInfo.buttonString[0] = thanksMessage;
			Globals.g_world.unityUIAlert.Show(uInfo);
        }

        public FrontEndScreen GetScreen(FrontEndScreenEnum inScreen)
        {
            Globals.Assert(inScreen < FrontEndScreenEnum.kNumFrontEndScreens);
            return screen[(int)inScreen];
        }

        public void PerformButtonAction(FrontEndButton button)
        {
						UnityEngine.Debug.Log("<color=yellow>Perform Button Action "+button.actionId.ToString()+"</color>");

            switch (button.actionId) {

						case FrontEndActions.kFrontEndAction_PressRaceButton :
								{
										Globals.g_analytics.StartRace();
								}
								break;


						case FrontEndActions.kFrontEndAction_HideNewsTab :
                {
                    Globals.g_world.HidePullTabNews();
                }
                break;
            case FrontEndActions.kFrontEndAction_LegalEULA :
                {
										string url = "http://shaunthesheep.com/fleece-lightning-terms-privacy";
//										Application.OpenURL("http://shaunthesheep.com/fleece-lightning-terms-privacy");		


//					if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
//                        url = "http://tos.ea.com/legalapp/mobileeula/US/de/GM/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
//                        url = "http://tos.ea.com/legalapp/mobileeula/US/sc/GM/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
//                        url =  "http://tos.ea.com/legalapp/mobileeula/US/ja/GM/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
//                        url =  "http://tos.ea.com/legalapp/mobileeula/US/fr/GM/";
//                    }
//                    else {
//                        url =  "http://tos.ea.com/legalapp/mobileeula/US/en/GM/";
//                    }
				
					Application.OpenURL(url);				

                   // //(UIApplication.SharedApplication()).OpenURL(url);
                }
                break;
            case FrontEndActions.kFrontEndAction_LegalPrivacy :
                {
										string url = "http://shaunthesheep.com/fleece-lightning-terms-privacy";

//                    string url;
//                    if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
//                        url =  "http://tos.ea.com/legalapp/WEBPRIVACY/US/de/PC/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
//                        url =  "http://tos.ea.com/legalapp/WEBPRIVACY/US/sc/PC/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
//                        url =  "http://tos.ea.com/legalapp/WEBPRIVACY/US/ja/PC/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
//                        url =  "http://tos.ea.com/legalapp/WEBPRIVACY/US/fr/PC/";
//                    }
//                    else {
//                        url =  "http://tos.ea.com/legalapp/WEBPRIVACY/US/en/PC/";
//                    }

					Application.OpenURL(url);
				
                    //(UIApplication.SharedApplication()).OpenURL(url);
                }
                break;
            case FrontEndActions.kFrontEndAction_LegalTerms :
                {
										string url = "http://shaunthesheep.com/fleece-lightning-terms-privacy";

//                    string url;
//                    if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
//                        url = "http://tos.ea.com/legalapp/WEBTERMS/US/de/PC/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
//                        url = "http://tos.ea.com/legalapp/WEBTERMS/US/sc/PC/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
//                        url = "http://tos.ea.com/legalapp/WEBTERMS/US/ja/PC/";
//                    }
//                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
//                        url = "http://tos.ea.com/legalapp/WEBTERMS/US/fr/PC/";
//                    }
//                    else {
//                        url = "http://tos.ea.com/legalapp/WEBTERMS/US/en/PC";
//                    }

					Application.OpenURL(url);
				
				//(UIApplication.SharedApplication()).OpenURL(url);
                }
                break;
            case FrontEndActions.kFrontEndAction_FBLogin :
                {
                    if (!Globals.g_world.CanConnectToInternet()) {
                        ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(4)).SetState( SwitchState.kSwitch_On);
                    }
                    else {
                        Globals.g_world.CheckAndLoginToFaceBook();
                    }

                }
                break;
            case FrontEndActions.kFrontEndAction_FBLogoff :
                {
                    Globals.g_world.FaceBookLogoff();
                }
                break;
            case FrontEndActions.kFrontEndAction_SpecialLock1 :
            case FrontEndActions.kFrontEndAction_SpecialLock2 :
            case FrontEndActions.kFrontEndAction_SpecialLock3 :
            case FrontEndActions.kFrontEndAction_SpecialLock4 :
                {
                    this.ShowPopUpSpecialLock();
                }
                break;
            case FrontEndActions.kFrontEndAction_EmailLog :
                {

                    #if EMAIL_LOG_STRING
                        Globals.g_world.SendEmailToP1P2("rossstyants@gmail.com", "log report", emailString);
                    #endif

                }
                break;
            case FrontEndActions.kFrontEndAction_DropBox :
                {

                    #if DROPBOX_ENABLED
                    #endif

                }
                break;
            case FrontEndActions.kFrontEndAction_TryGoNetSendChooseTrack :
                {
  //                  this.TryGoToScreenThatNeedsBluetooth((int) FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack);
                }
                break;
            case FrontEndActions.kFrontEndAction_TryGoReceiveTrack :
                {
//                    this.TryGoToScreenThatNeedsBluetooth((int) FrontEndScreenEnum.kFrontEndScreen_BrowseServers);
                }
                break;
            case FrontEndActions.kFrontEndAction_TrySendTrack :
                this.TrySendTrackButton();
                break;
            case FrontEndActions.kFrontEndAction_CreateTrack :
                this.TryCreateTrack();
                break;
            case FrontEndActions.kFrontEndAction_TryTrashCustomLevel :
                this.TryTrashCustomLevel();
                break;
            case FrontEndActions.kFrontEndAction_FinishedViewingControlChoiceSetup :
                {
                    Profile.ProfileInformation oldInfo = new Profile.ProfileInformation();
                    oldInfo = profile.profileInfo;
                    oldInfo.haveSeenControlChoiceYet = true;
                    profile.SetProfileInfo(oldInfo);
                    profile.SaveBestTimesAndPrefs();
                    slideInCharacter.Hide();
                }
                break;
            case FrontEndActions.kFrontEndAction_ChooseTiltInControlChoiceSetupAuto :
            case FrontEndActions.kFrontEndAction_ChooseTiltInControlChoiceSetupExpert :
                {
                    Profile.ProfileInformation oldInfo = new Profile.ProfileInformation();
                    oldInfo = profile.profileInfo;
                    oldInfo.haveSeenControlChoiceYet = true;
                    profile.SetProfileInfo(oldInfo);
                    Profile.ProfilePreferences oldPrefs = new Profile.ProfilePreferences();
                    oldPrefs = profile.preferences;
                    oldPrefs.controlTilt = true;
                    oldPrefs.controlFinger = false;
                    if (button.actionId == FrontEndActions.kFrontEndAction_ChooseTiltInControlChoiceSetupAuto) {
                        oldPrefs.tiltExpert = false;
                    }
                    else {
                        oldPrefs.tiltExpert = true;
                    }

                    profile.SetPreferences(oldPrefs);
                    slideInCharacter.Hide();
                    profile.SaveBestTimesAndPrefs();
                    slideInCharacter.Hide();
                    CrashLandingAppDelegate.SetAcceleromterOnOrOff(oldPrefs.controlTilt);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(mainRaceButtonId)).SetGoToScreen( FrontEndScreenEnum.
                      kFrontEndScreen_ChooseStage);
                }
                break;
            case FrontEndActions.kFrontEndAction_ChooseThumbInControlChoiceSetup :
                {
                    Profile.ProfileInformation oldInfo = new Profile.ProfileInformation();
                    oldInfo = profile.profileInfo;
                    oldInfo.haveSeenControlChoiceYet = true;
                    profile.SetProfileInfo(oldInfo);
                    Profile.ProfilePreferences oldPrefs = new Profile.ProfilePreferences();
                    oldPrefs = profile.preferences;
                    oldPrefs.controlTilt = false;
                    oldPrefs.controlFinger = false;
                    profile.SetPreferences(oldPrefs);
                    slideInCharacter.Hide();
                    profile.SaveBestTimesAndPrefs();
                    slideInCharacter.Hide();
                    CrashLandingAppDelegate.SetAcceleromterOnOrOff(oldPrefs.controlTilt);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(mainRaceButtonId)).SetGoToScreen( FrontEndScreenEnum.
                      kFrontEndScreen_ChooseStage);
                }
                break;
            case FrontEndActions.kFrontEndAction_ChooseFingerInControlChoiceSetup :
                {
                    Profile.ProfileInformation oldInfo = new Profile.ProfileInformation();
                    oldInfo = profile.profileInfo;
                    oldInfo.haveSeenControlChoiceYet = true;
                    profile.SetProfileInfo(oldInfo);
                    Profile.ProfilePreferences oldPrefs = new Profile.ProfilePreferences();
                    oldPrefs = profile.preferences;
                    oldPrefs.controlTilt = false;
                    oldPrefs.controlFinger = true;
                    profile.SetPreferences(oldPrefs);
                    slideInCharacter.Hide();
                    profile.SaveBestTimesAndPrefs();
                    slideInCharacter.Hide();
                    CrashLandingAppDelegate.SetAcceleromterOnOrOff(oldPrefs.controlTilt);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(mainRaceButtonId)).SetGoToScreen( FrontEndScreenEnum.
                      kFrontEndScreen_ChooseStage);
                }
                break;
            case FrontEndActions.kFrontEndAction_SlideAboutShitRight :
                slideInCharacter.Hide();
                break;
            case FrontEndActions.kFrontEndAction_SlideAboutShitLeft :
                slideInCharacter.Hide();
                break;
            case FrontEndActions.kFrontEndAction_HideSlideIn :
                slideInCharacter.Hide();
                break;
            case FrontEndActions.kFrontEndAction_SelectNetTrack :
                this.SelectNetworkTrackButtonAction(button);
                break;
            case FrontEndActions.kFrontEndAction_SubmitScoresToAgon :
                this.SubmitScores();
                break;
            case FrontEndActions.kFrontEndAction_ViewScoresLeaderboard :
                this.ViewScoresLeaderboard();
                break;
            case FrontEndActions.kFrontEndAction_None :
                break;
            case FrontEndActions.kFrontEndAction_ChangeControlInOptions :
                {
                    this.SetupOptionsControlButts();
                }
                break;
            case FrontEndActions.kFrontEndAction_ChangeControlOnMain :
                {
                    Profile.ProfilePreferences oldPrefs = new Profile.ProfilePreferences();
                    oldPrefs = profile.preferences;
                    if (oldPrefs.controlTilt) {
                        (button.zobject).HideAndShowP1(null, 10);
                        oldPrefs.controlTilt = false;
                    }
                    else {
                        (button.zobject).HideAndShowP1(null, 7);
                        oldPrefs.controlTilt = true;
                    }

                    profile.SetPreferences(oldPrefs);
                    profile.SaveBestTimesAndPrefs();
                }
                break;
            case FrontEndActions.kFrontEndAction_StageSelectGoForwardOne :
                this.StageSelectGoForwardOne();
                break;
            case FrontEndActions.kFrontEndAction_TerrainSelectGoForwardOne :
                this.TerrainSelectGoForwardOne();
                break;
            case FrontEndActions.kFrontEndAction_TerrainSelectGoBackOne :
                this.TerrainSelectGoBackOne();
                break;
            case FrontEndActions.kFrontEndAction_ControlsSelectGoForwardOne :
                this.ControlSelectGoForwardOne();
                break;
            case FrontEndActions.kFrontEndAction_ControlsSelectGoBackOne :
                this.ControlSelectGoBackOne();
                break;
            case FrontEndActions.kFrontEndAction_FakeMultiplayer :
                exitInfo.multiplayer = !exitInfo.multiplayer;
                break;
            case FrontEndActions.kFrontEndAction_ClearAllDataComplete :
                profile.ClearAllBestTimeData();
                profile.ResetBestTimeAndLevelUnlockedData();
                profile.UpdateNumApples();
                profile.SaveBestTimesAndPrefs();
                break;
            case FrontEndActions.kFrontEndAction_UnlockAllLevels :
                this.UnlockAllLevelsFromFrontend();
                break;
            case FrontEndActions.kFrontEndAction_StageSelectGoBackOne :
                this.StageSelectGoBackOne();
                break;
            case FrontEndActions.kFrontEndAction_BuyUnlockAllLevels :
                break;
            case FrontEndActions.kFrontEndAction_BuyRemoveAds :
                break;
            case FrontEndActions.kFrontEndAction_RestoreUnlockAllLevels :
                break;
            case FrontEndActions.kFrontEndAction_RestoreRemoveAds :
                break;

			case FrontEndActions.kFrontEndAction_OpenDataPrivacySettings :
				{
					UnityEngine.Analytics.DataPrivacy.FetchPrivacyUrl(OnDataURLReceived,OnDataFailure);

//					Application.OpenURL(url);
				}
				break;



            default :
                Globals.Assert(false);
                break;
            }

        }

		static void OnDataFailure(string reason)
		{
			UnityEngine.Debug.LogWarning(String.Format("Failed to get data privacy page URL: {0}", reason));
		}

		void OnDataURLReceived(string url)
		{
			Application.OpenURL(url);
		}

        public void PerformSwitchAction (FrontEndSwitch pSwitch)
		{
			int i = (int)pSwitch.state;

			if (i == 0) 
			{
				i =1;
			} 
			else 
			{
				i =0;
			}

			//i = !i;
            if ((i >= 0) && (i <= 1)) {
                FrontEndButton button = pSwitch.GetButton(i);
                this.PerformButtonAction(button);
            }

            switch (pSwitch.actionId) {
            case FrontEndActions.kFrontEndAction_None :
                break;
            case FrontEndActions.kFrontEndAction_ChooseControl :
                {
                    bool tiltOn = (bool) ((screen[(int)currentScreen]).GetSwitch(4)).GetStateBool();
                    if (tiltOn) {
                        (((screen[(int)currentScreen]).GetButton(5)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
                        ((screen[(int)currentScreen]).GetButton(5)).Show();
                        (((screen[(int)currentScreen]).GetButton(6)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
                        ((screen[(int)currentScreen]).GetButton(6)).Hide();
                    }
                    else {
                        (((screen[(int)currentScreen]).GetButton(5)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
                        ((screen[(int)currentScreen]).GetButton(5)).Hide();
                        (((screen[(int)currentScreen]).GetButton(6)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
                        ((screen[(int)currentScreen]).GetButton(6)).Show();
                    }

                }
                break;
            case FrontEndActions.kFrontEndAction_MusicPreference :
                if (pSwitch.state == SwitchState.kSwitch_On) {
                    (SoundEngine.Instance()).AVPlaySound((int)Audio.Enum2.kSoundEffect_MenuMusicLoop);
                    (SoundEngine.Instance()).AVFadeInP1((int)Audio.Enum2.kSoundEffect_MenuMusicLoop, 0.4f);
                }
                else {
                    (SoundEngine.Instance()).AVFadeOutAndStopP1((int)Audio.Enum2.kSoundEffect_MenuMusicLoop, 0.4f);
                }

                break;
            case FrontEndActions.kFrontEndAction_SoundFxPreference :
                if (pSwitch.state ==  SwitchState.kSwitch_On) {
                    (SoundEngine.Instance()).SetPlaySoundFX(true);
                }
                else {
                    (SoundEngine.Instance()).SetPlaySoundFX(false);
                }

                break;
            default :
                Globals.Assert(false);
                break;
            }

        }

        public void DoButtonIndividualitiesP1(FrontEndScreenEnum inScreen, int buttonId)
        {
            switch (inScreen) {
            case FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild :
                if (buttonId == 2) {
                    exitInfo.goToLevelBuilder_Ross = true;
                    exitInfo.playCustomLevel = true;
                }
                else if ((buttonId == 3) || (buttonId == 4) || (buttonId == 5)) {
                    exitInfo.goToLevelBuilder_Ross = false;
                    exitInfo.playCustomLevel = true;
                }

                break;
            case FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack :
            case FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack :
            case FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack :
            case FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack :
                this.ButtonActionChooseTrack(inScreen);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ChooseStage :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ChooseTrack :
            case FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack :
                this.ButtonActionChooseTrack(inScreen);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_Options :
                if (buttonId == 2) {
                    (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).ShowQuery(0);
                    (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).SetInQuery(true);
                }

                break;
            default :
                break;
            }

        }

        public void SetSelectedLevelOnChooseTrackP1(int inScreen, int levId)
        {
            (screen[(int)inScreen]).SetSelectedLevel(levId);
            if (((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_HighScoresChooseTrack)) {
                profile.SetSelectedLevel((screen[(int)inScreen]).selectedLevel);
            }
            else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
                profile.SetSelectedLevel((screen[(int)inScreen]).selectedLevel);
            }
            else {
                profile.SetSelectedLevelCustom((screen[(int)inScreen]).selectedLevel);
            }

        }

        int GetStageIdFromLevel(int inLevel)
        {
            for (int i = ((int)Profile.Enum4.kNumCups); i >= 1; i--) {
                if (inLevel >= ((int)Profile.Enum6.kNumLevelsPerCup * i)) {
                    return i;
                }

            }

            return 0;
        }

        public void HideAndShowTrackButtons(bool justChangeTexture)
        {
            int numButtons;
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                numButtons = (int)Profile.Enum6.kNumLevelsPerCup * (int)Profile.Enum4.kNumCups;
								numButtons += (int)Profile.Enum6.kNumBonusLevels;
                numButtons += (int)Profile.Enum4.kNumCups;
            }
            else {
                numButtons = (int)Profile.Enum6.kNumCustomLevels - 3;
            }

            int profileLevelIndex = 0;
            for (int m = 0; m < numButtons; m++) {
                int buttonIdWithinScreen = kNumButtonsBeforeTracks + m;
                if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                    buttonIdWithinScreen++;
                }

                if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                    if (m % 9 == 0) continue;

                }

                int stageId = this.GetStageIdFromLevel(profileLevelIndex);
                int newAtlas = (int) AtlasType.kAtlas_FrontendAndShowlevel;
                int newTex = 0;
                float newScale = kLevelButtonScale;
                if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.
                  kFrontEndScreen_HighScoresChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack)) {
                    if (profile.IsLevelUnlocked(profileLevelIndex)) {
                        newTex = (int)World.Enum9.kFE_Level0apples + profile.GetNumApplesOnLevel(profileLevelIndex);
                        if (stageId == (int)Enum2.kStageBonusLevels) {
                            int numCupsOverBefore = (int)Profile.Enum4.kNumCups - 3;
                            newTex = profileLevelIndex - 6 - ((int)Profile.Enum6.kNumLevelsPerCup * numCupsOverBefore);
                        }

                    }
                    else {
                        newTex = (int)World.Enum9.kFE_LevelLocked;
                        if (stageId == (int)Enum2.kStageBonusLevels) {
                            newTex = 4 + (6 * 2);
                        }

                        if (profileLevelIndex < 80) {
                            ((screen[(int)currentScreen]).GetNumber(profileLevelIndex)).Disappear();
                        }

                        ((screen[(int)currentScreen]).GetButton(buttonIdWithinScreen)).SetIsClickable(false);
                    }

                }
                else {
                    if (profile.IsCustomLevelMade(profileLevelIndex)) {
                        int terrainId = profile.GetCustomLevelMade(profileLevelIndex);
                        if (terrainId < 2) {
                            newTex = (int)World.Enum9.kFE_TerrainGrasssmall + terrainId;
                            newAtlas = (int)AtlasType.kAtlas_FrontendAndShowlevel;
                            newScale = 1.0f * kLevelButtonScale;
                        }
                        else {
                            newAtlas = (int)AtlasType.kAtlas_TerrainIcons;
                            newScale = 0.57f * kLevelButtonScale;
                        }

                    }
                    else {
                        newAtlas = (int)AtlasType.kAtlas_FrontendAndShowlevel;
                        newTex = (int)World.Enum9.kFE_TerrainEmpty;
                        newScale = 1.0f * kLevelButtonScale;
                    }

                }

                Globals.Assert(newTex != -1);
                (((screen[(int)currentScreen]).GetButton(buttonIdWithinScreen)).zobject).SetSubTextureId(newTex);
                (((screen[(int)currentScreen]).GetButton(buttonIdWithinScreen)).zobject).SetAtlas(Globals.g_world.GetAtlas(newAtlas));
                (((screen[(int)currentScreen]).GetButton(buttonIdWithinScreen)).zobject).SetShowScale(newScale);
                profileLevelIndex++;
            }

        }

        public void SelectNewStage(int whichStage)
        {
            selectedStage = whichStage;
            if (whichStage < (int)Enum2.kStageBonusLevels) currentColour = (profile.GetCup(whichStage)).menuBackColour;

        }

        public void ButtonActionChooseTrack(FrontEndScreenEnum inScreen)
        {
            int pressedButton = (screen[(int)inScreen]).lastPressedButton;
            int numTracks = ((int)Profile.Enum6.kNumLevelsPerCup * (int)Profile.Enum4.kNumCups);
            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
								numTracks += (int)Profile.Enum6.kNumBonusLevels;
                int numStages = pressedButton / 9;
                numStages++;
                pressedButton -= numStages;
            }
            else {
                numTracks = (int)((int)Profile.Enum6.kNumCustomLevels - 3);
            }

            int numButtonsBeforeTracks = kNumButtonsBeforeTracks;
            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                numButtonsBeforeTracks = kNumButtonsBeforeTracksLB;
            }

            if (pressedButton < (numTracks + numButtonsBeforeTracks)) {
                int profileButtonId = pressedButton - numButtonsBeforeTracks;
                if ((profile.IsLevelUnlocked(profileButtonId)) || ((int)inScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) || ((int)inScreen == (int)
                  FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack) || (
                  (int)inScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack)) {
                    if (false) {
                        this.SetSelectedLevelOnChooseTrackP1((int)inScreen, profileButtonId + ((int)Profile.Enum6.kNumLevelsPerCup * 3));
                    }
                    else {
                        if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                            if (!exitInfo.goToLevelBuilder_Ross) {
                                if (!profile.IsCustomLevelMade(profileButtonId)) {
                                }

                            }

                        }

                        this.SetSelectedLevelOnChooseTrackP1((int)inScreen, profileButtonId);
                    }

                    this.ShowCurrentLevel();
                    lastSelectedLevel[selectedStage] = profileButtonId;
                }

            }

        }

        public void UpdateScreenQueries()
        {
            for (int q = 0; q < (screen[(int)currentScreen]).numQueries; q++) {
                FrontEndQuery query = (screen[(int)currentScreen]).GetQuery(q);
                if (query.chosenButton ==  QueryButton.nYes) {
                    switch (currentScreen) {
                    case FrontEndScreenEnum.kFrontEndScreen_Options :
                        profile.ClearAllBestTimeData();
                        profile.UpdateNumApples();
                        profile.SaveBestTimesAndPrefs();
                        query.SetChosenButton( QueryButton.nPressActionDone);
                        break;
                    case FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack :
                        if (q == 0) {
                            int levelId = profile.selectedLevelCustom;
                            profile.SetCustomLevelNotMade(levelId);
                            this.HideAndShowTrackButtons(true);
                            profile.SaveCustomLevelInformation();
                            query.SetChosenButton( QueryButton.nPressActionDone);
                        }

                        break;
                    case FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack :
                        break;
                    default :
                        Globals.Assert(false);
                        break;
                    }

                }

            }
		}
		
        public void OpenQuitAlert()
        {
//           rateAlert.Show();

            string alertMessage = "";
            string buttonYes = "";
            string buttonNo = "";
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                alertMessage = String.Format("Verlassen?");
                buttonYes = "Ja";
                buttonNo = "Nein";
			}
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
				alertMessage = String.Format("退出?");
                buttonYes = "是";
                buttonNo = "没有";
			}
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
				alertMessage = String.Format("見切り?");
                buttonYes = "はい";
                buttonNo = "ノー";
			}
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                alertMessage = String.Format("Arrêter?");
                buttonYes = "Oui";
                buttonNo = "Non";
			}
            else {
                alertMessage = String.Format("Quit?");
                buttonYes = "Yes";
                buttonNo = "No";
            }

			UnityUIAlert.UnityUIAlertInfo uInfo = new UnityUIAlert.UnityUIAlertInfo();
			uInfo.type = UnityUIAlertType.e_Quit;
			uInfo.title = "";
			uInfo.message = alertMessage;
			uInfo.numButtons = 2;
			uInfo.textScale = 0.6f;
			uInfo.useNSStringAnyway = false;

			uInfo.buttonString[0] = buttonYes;
			uInfo.buttonString[1] = buttonNo;
			Globals.g_world.unityUIAlert.Show(uInfo);


        }		

        public void AndroidBackKeyPressed()
        {
			if (currentScreen != FrontEndScreenEnum.kFrontEndScreen_Main)
			{
				this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Main);
			}
			else
			{			
				this.OpenQuitAlert();
			}
		}		
		
        public void UpdateAppleWon()
        {
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
            }

        }

        public void RenderAppleWon()
        {
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
            }

        }

        public void ShowAboutSlideIn(int whichAboutSlideIn)
        {
            SlideInCharacter.SlideInCharacterInfo info = new SlideInCharacter.SlideInCharacterInfo();
            info.yPos = 72.0f;
            info.whichCharacter = -1;
			string line1;// = new char[32];
			string line2;// = new char[32];
            line1 = "\n";
            line2 = "\n";
            switch (whichAboutSlideIn) {
            case 0 :
                line1 ="or use the\n";
                line2 = "tilt controls!\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 1 :
                line1 ="try not to\n";
                line2 = "tilt too high\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 2 :
                line1 ="press left and\n";
                line2 = "right to steer\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 3 :
                line1 ="dodge the\n";
                line2 = "obstacles\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 4 :
                line1 ="this is a\n";
                line2 = "tricky technique\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 5 :
                line1 ="and hit the\n";
                line2 = "speed boosts!\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 6 :
                line1 ="dont go too slow\n";
                line2 = "fluffy!\n";
                info.whichCharacter = (int)PlayerType.kPlayerPig;
                break;
            case 7 :
                line1 ="create your own\n";
                line2 = "training track!\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 8 :
                line1 ="choose a\n";
                line2 = "control method\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 9 :
                line1 ="press left or\n";
                line2 = "right to steer\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 10 :
                break;
            case 11 :
                line1 ="now you're ready\n";
                line2 = "to race!\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            default :
                Globals.Assert(false);
				line1 = "";
				line2 = "";
                break;
            }

            if (info.whichCharacter == -1) return;

            if (info.whichCharacter == (int) PlayerType.kPlayerPig) info.side = SlideInSide.eRight;
            else info.side = SlideInSide.eLeft;

            slideInCharacter.Initialise(info);
            slideInCharacter.SetTextP1(line1, line2);
            slideInCharacter.Show(0.25f);
        }

        public void ShowNextMainSlideIn()
        {
            SlideInCharacter.SlideInCharacterInfo info = new SlideInCharacter.SlideInCharacterInfo();
            info.yPos = 62.0f;
            info.whichCharacter = (int)PlayerType.kPlayerPig;
			string line1;// = new char[32];
			string line2;// = new char[32];
            line2 = "\n";
            int randomComment = Utilities.GetRand( 7);
            if (firstForDay) {
                randomComment = 0;
                firstForDay = false;
            }

            switch (randomComment) {
            case 1 :
                line1 ="you ready to\n";
                line2 = "rumble?\n";
                info.whichCharacter = (int)PlayerType.kPlayerPig;
                break;
            case 2 :
                line1 ="mmmmmmmm\n";
                line2 = "apples\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 3 :
                line1 ="get apples for\n";
                line2 = "bonus levels\n";
                info.whichCharacter = (int)PlayerType.kPlayerSheep;
                break;
            case 4 :
                line1 ="what you\n";
                line2 = "looking at?\n";
                info.whichCharacter = (int)PlayerType.kPlayerPig;
                break;
            case 5 :
                line1 ="you've trotta\n";
                line2 = "lotta nerve\n";
                info.whichCharacter = (int)PlayerType.kPlayerPig;
                break;
            case 6 :
                line1 ="like the taste\n";
                line2 = "of dust?\n";
                info.whichCharacter = (int)PlayerType.kPlayerPig;
                break;
            default :
                line1 ="time to play\n";
                line2 = "sheeplechase\n";
              //  info.whichCharacter = (int)Playinfo.whichCharacter + (int)PlayerType.kPlayerSheep;
                break;
            }

            if (info.whichCharacter == (int) PlayerType.kPlayerPig) info.side = SlideInSide.eRight;
            else info.side = SlideInSide.eLeft;

            slideInCharacter.Initialise(info);
            slideInCharacter.SetTextP1(line1, line2);
            slideInCharacter.Show(1.0f);
        }

        public void RenderScene()
        {
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LoadingScreenEnd) {
                Globals.g_main.RenderLoadingBarItems();
            }

            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_GreenAnt) {
				
				
				
                ////glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
                //glClear (GL_COLOR_BUFFER_BIT);
            }

            if (((int)currentScreen >= (int) FrontEndScreenEnum.kFrontEndScreen_About_2_6) && ((int)currentScreen <= (int) FrontEndScreenEnum.kFrontEndScreen_About_5)) {
                ((Globals.g_world.game).tileMap).RenderScene(0);
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glLoadIdentity();
                //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
            }

            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Title) 
            {
                if (Globals.deviceIPhone4) {
                    FrontEndScreen.SpecialBackParameters sInfo = new FrontEndScreen.SpecialBackParameters();
                    sInfo.scale = 1.0f;
                    sInfo.renderOffset = Utilities.CGPointMake(0.0f, 12.0f);
                    (screen[(int)currentScreen]).RenderBackSceneSpecial(sInfo);
                }
                else {
                    (screen[(int)currentScreen]).RenderBackScene();
                }

                (screen[(int)currentScreen]).RenderFrontScene();
            }
            else {
                if (false) {
                    switch (currentScreen) {
                    case FrontEndScreenEnum.kFrontEndScreen_ChooseStage :
                    case FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild :
                    case FrontEndScreenEnum.kFrontEndScreen_ChooseTrack :
                    case FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack :
                    case FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack :
                    case FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack :
                    case FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack :
                    case FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel :
                        {
                            FrontEndScreen.SpecialBackParameters sInfo = new FrontEndScreen.SpecialBackParameters();
                            sInfo.renderOffset = Utilities.CGPointMake(0.0f, 12.0f);
                            sInfo.scale = 1.0f;
                            (screen[(int)currentScreen]).RenderBackSceneSpecial(sInfo);
                        }
                        break;
                    case FrontEndScreenEnum.kFrontEndScreen_Title :
                        {
                            FrontEndScreen.SpecialBackParameters sInfo = new FrontEndScreen.SpecialBackParameters();
                            sInfo.renderOffset = Utilities.CGPointMake(0.0f, 42.0f);
                            sInfo.scale = 1.0f;
                            (screen[(int)currentScreen]).RenderBackSceneSpecial(sInfo);
                        }
                        break;
                    case FrontEndScreenEnum.kFrontEndScreen_GreenAnt :
                        {
                            FrontEndScreen.SpecialBackParameters sInfo = new FrontEndScreen.SpecialBackParameters();
                            sInfo.renderOffset = Utilities.CGPointMake(0.0f, 112.0f);
                            sInfo.scale = 1.0f;
                       //     (screen[(int)currentScreen]).RenderBackSceneSpecial(sInfo);
                        }
                        break;

										default :
                        (screen[(int)currentScreen]).RenderBackScene();
                        break;
                    }

                }
                else {
					
                    switch (currentScreen) {
                    case FrontEndScreenEnum.kFrontEndScreen_GreenAnt :
                        {
                            FrontEndScreen.SpecialBackParameters sInfo = new FrontEndScreen.SpecialBackParameters();
                            sInfo.renderOffset = Utilities.CGPointMake(0.0f, -22.0f);
                            sInfo.scale = 1.0f;
                            (screen[(int)currentScreen]).RenderBackSceneSpecial(sInfo);
                        }
                        break;
										case FrontEndScreenEnum.kFrontEndScreen_Options :
										case FrontEndScreenEnum.kFrontEndScreen_ChooseControls :
										case FrontEndScreenEnum.kFrontEndScreen_Legal :
												{
														(screen[(int)currentScreen]).RenderBackScene_StretchToFit();
												}
												break;
					default:
                    (screen[(int)currentScreen]).RenderBackScene();
						break;
					}
					
                }

                (screen[(int)currentScreen]).RenderFrontScene();
                if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Options) 
				{
                    ((screen[(int)currentScreen]).GetButton(6)).Render();
                    ((screen[(int)currentScreen]).GetButton(7)).Render();
                    if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                        ((screen[(int)currentScreen]).GetFunnyWord(6)).Render();
                    }

                    (screen[(int)currentScreen]).RenderSwitch(0);
                    (screen[(int)currentScreen]).RenderSwitch(1);
                    (screen[(int)currentScreen]).RenderSwitch(2);
                    (screen[(int)currentScreen]).RenderSwitch(3);
                }

            }

            Globals.g_world.RenderPullTab();
            if (((int)currentScreen >= (int) FrontEndScreenEnum.kFrontEndScreen_About_2_6) && ((int)currentScreen <= (int) FrontEndScreenEnum.kFrontEndScreen_About_5)) {
                slideInCharacter.Render();
            }

            if (((int)currentScreen >= (int) FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose) && ((int)currentScreen <= (int) FrontEndScreenEnum.
              kFrontEndScreen_ControlChoice_Final)) {
                slideInCharacter.Render();
            }

            if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main) || ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild)) {
                slideInCharacter.Render();
            }

            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_GreenAnt) 
			{
                this.RenderGreenAntBack();
                creditsText.Render();
            }

            if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_LBChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack)) {
                this.RenderAppleWon();
            }

            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Title) {
               // greenAntLogo.Render();
                CGPoint pos = titleWord2.screenPosition;
                pos.x += shake.x;
                pos.y -= shake.y;
               // titleWord2.SetScreenPosition(pos);
               // titleWord2.Render();
                pos = titleWord1.screenPosition;
                pos.x += shake.x;
                pos.y -= shake.y;
               // titleWord1.SetScreenPosition(pos);
               // titleWord1.Render();
               // handStamp.Render();
            }

        }
    }
}
