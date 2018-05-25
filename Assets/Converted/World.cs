using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using PlistCS;

namespace Default.Namespace
{
    public enum  WhichTouch {
        kTouchBegan,
        kTouchMoved,
        kTouchEnded
    }
    public enum  WorldState {
        e_PreloadingSounds,
        e_TitleScreens,
        e_FrontEnd,
        e_InGame
    }
    public enum  StringId {
        kString_Best = 0,
        kString_Music,
        kString_SoundFX,
        kString_Ghost,
        kString_ClearData,
        kString_About,
        kString_ControlMethod,
        kString_ChooseControl,
        kString_Practise,
        kString_Total,
        kString_Unlock,
        kString_Done,
        kString_Clear,
        kString_Move,
        kString_Copy,
        kString_Create,
        kString_CustomLevel,
        kString_ChooseTerrain,
        kString_LevelBuilder_Ross,
        kString_Tip,
        kString_TiltLeftAnd1,
        kString_TiltLeftAnd2,
        kString_ButtonControl1,
        kString_ButtonControl2,
        kString_FingerFollow1,
        kString_FingerFollow2,
        kString_EULA,
        kString_Privacy,
        kString_Terms,
        kString_EA,
        kString_WatchOut,
        kString_JoinedRace,
        kString_AnotherPig,
        kString_FBLogin,
        kString_FBLogout,
        kString_EnterTrack,
        kString_LevelAlreadyEmpty,
        kString_SureClearTrack,
        kString_ControlTilt,
        kString_ControlThumb,
        kString_ControlFinger,
        kString_BestTime,
        kString_Play,
        kString_Completed,
        kString_BaaRilliant,
		kString_BuyNoAds,		
		kString_BuyAllLevels,
		kString_Store,
		kString_Restore,
	}
    public enum  AtlasType {
        kAtlas_RainbowParticles = 0,
        kAtlas_ParticlesScene,
        kAtlas_Trees,
        kAtlas_Footsteps,
        kAtlas_GrassTiles,
        kAtlas_GameThingsGrass,
        kAtlas_Shadows,
        kAtlas_FlowerHeads,
        kAtlas_FlowerShadows,
        kAtlas_GrassSpriteTiles,
        kAtlas_FontLines,
        kAtlas_FontColours,
        kAtlas_InfoBubbles,
        kAtlas_SceneButtons,
        kAtlas_MudTiles,
        kAtlas_MudSpriteTiles,
        kAtlas_MudTiles3,
        kAtlas_GameThingsMud,
        kAtlas_ShadowsFarm,
        kAtlas_321,
        kAtlas_Hud,
        kAtlas_DesertTiles,
        kAtlas_DesertTiles2,
        kAtlas_GameThingsGrassDesert,
        kAtlas_IceTiles,
        kAtlas_IceTiles2,
        kAtlas_MoonTiles,
        kAtlas_GrassCliff,
        kAtlas_CommonLevelBuilder_Ross,
        kAtlas_FontNumbers,
        kAtlas_FontArial,
        kAtlas_TerrainIcons,
        kAtlas_IceSprites,
        kAtlas_Debug,
        kAtlas_SheepAnims,
        kAtlas_PiggyAnims,
        kAtlas_TilesJungle,
        kAtlas_FrontendAndShowlevel,
        kAtlas_RaceLose,
        kAtlas_RaceWin,
        kAtlas_ShowLevelAndTip,
        kAtlas_AppleSign,
        kAtlas_AnotherPiggy,
        kAtlas_FeelGood,
        kNumAtlases
    }
    public enum  FaceBookThing {
        kFB_GettingTime,
        kFB_GettingRank,
        kFB_LoggingIn
    }

		public class World : MonoBehaviour
    {
		//this bool allows ADC to completely steal the run cycle
//		public bool isLoadingADCAssets; 
		
		public UnityUIAlert unityUIAlert;
		
		public Font guiFont;
				public float xScreenEdgeReal;
		public float xScreenEdge;
		public UnityEngine.Material[] myMaterialWithColour = new UnityEngine.Material[(int)Colours.kNum];

//        public Reachability reachability;
//        public NetworkStatus remoteHostStatus;
		public string outString;// = new char[64];
		public Camera gameCam;
		public Camera tileCam;
        public float mapObjectAppearDistance;
        public float renderScale;
        public float previousRenderScale;
        public float leftDrawEdge;
        public float rightDrawEdge;
        public float drawWidth;
        public float drawHeight;
        public float screenWidth;
        public float screenHeight;
        public float coordinatesWidth;
        public float coordinatesHeight;
        public float tileMapHeight;
        public ZAtlas[] atlas = new ZAtlas[(int)AtlasType.kNumAtlases];
        public Game game;
        public FrontEnd frontEnd;
        public ZFont font;
        public Audio audio;
        public bool inFirstLoad;
        public int goingToFrontEndFromShowLevel;
        public int deviceType;
        public WorldState worldState;
        public float stateTimer;
        public bool gameSoundsLoadedYet;
        public bool haveReachedTitleYet;
        public int artLevel;
        public int currentlyLoadedScene;
        public int currentlyLoadedOpponent;
        public FrontEndButton pullTab;
        public FrontEndButton pullTabNews;
        public FrontEndButton leaderboardRank;
        public FunnyWord rankWord;
        public FunnyWord rankWordTop;
        public Zscore rankScore;
        public FrontEndQuery facebookQuery;
        public FaceBookThing fbIsTime;
        public CGPoint scoreStartPosition;
        public CGPoint topStartPosition;
        public enum Enum {
            kGTSavanna_HippoLeft = 0,
            kGTSavanna_HippoRight,
            kGTSavanna_Bush,
            kGTSavanna_BushFlat,
            kGTSavanna_Acacia,
            kGTSavanna_Zebra1,
            kGTSavanna_Zebra2,
            kGTSavanna_Zebra3,
            kGTSavanna_Rainbow,
            kGTSavanna_ElephantBody,
            kNumGameThingsSavanna
        };
        public enum Enum1 {
            kGTJungle_Paradise = 0,
            kGTJungle_Log,
            kGTJungle_Venus1,
            kGTJungle_Venus2,
            kGTJungle_Venus3,
            kGTJungle_FernTop,
            kGTJungle_TreePurp,
            kGTJungle_TreePink,
            kGTJungle_Elephant,
            kGTJungle_FlowersPurp,
            kGTJungle_Snake1,
            kGTJungle_Snake2,
            kGTJungle_Snake3,
            kGTJungle_Rainbow,
            kGTJungle_Flowers2,
            kGTJungle_FlowerHead1,
            kGTJungle_FlowerHead2,
            kGTJungle_FlowerHead3,
            kGTJungle_FlowerHead4,
            kGTJungle_FlowerHead5,
            kGTJungle_FlowerHead6,
            kGTJungle_FlowerHead7,
            kGTJungle_FlowerHead8,
            kGTJungle_FlowerHead9,
            kGTJungle_FlowerHead10,
            kGTJungle_FlowerHead11,
            kGTJungle_FlowerHead12,
            kGTJungle_FlowerHead13,
            kGTJungle_FlowerHead14,
            kNumGameThingsJungle
        };
        public enum Enum2 {
            kGTMud_TreeTop3 = 0,
            kGTMud_Footstep1,
            kGTMud_Footstep2,
            kGTMud_GenericShadow,
            kGTMud_PlayerShadow,
            kGTMud_LandRover,
            kGTMud_Tractor,
            kGTMud_TractorBackWheel,
            kGTMud_TractorFrontWheel,
            kGTMud_lrBackWheel,
            kGTMud_lrFrontWheel,
            kGTMud_ScareCrow,
            kGTMud_Rainbow,
            kGTMud_HayBaleSingle,
            kGTMud_HayBaleSingleSquashed,
            kGTMud_Welly,
            kGTMud_Barrel,
            kGTMud_TrafficCone,
            kGTMud_WellyShadow,
            kGTMud_ShaunShadow1,
            kGTMud_ShaunShadow2,
            kGTMud_ShaunShadow3,
            kGTMud_ShaunShadow4,
            kGTMud_ShaunShadow5,
            kGTMud_PiggyShadow,
            kGTMud_Foamy,
            kGTMud_CauliFlower,
            kGTMud_CauliFlowerBit,
            kGTMud_TulipsRed,
            kGTMud_TulipRedPetal1,
            kGTMud_TulipRedPetal2,
            kGTMud_TulipsRedOnFloor,
            kGTMud_Courgette,
            kGTMud_CourgetteSmashed,
            kGTMud_CourgettePiece,
            kGTMud_CourgettePieceOnFloor,
            kGTMud_Squash,
            kGTMud_SquashSmashed,
            kGTMud_SquashPiece,
            kGTMud_SquashPieceOnFloor,
            kGTMud_Pumpkin,
            kGTMud_PumpkinSmashed,
            kGTMud_PumpkinPiece,
            kGTMud_PumpkinPieceOnFloor,
            kGTMud_FootstepWithMarrow,
            kGTMud_FootstepWithPumpkin,
            kGTMud_FootstepWithSquash,
            kGTMud_ShirleyDown1,
            kGTMud_ShirleyDown2,
            kGTMud_ShirleyDown3,
            kGTMud_ChickenFly1,
            kGTMud_ChickenFly2,
            kGTMud_ChickenFlyShadow1,
            kGTMud_ChickenFlyShadow2,
            kGTMud_ChickenPeck1,
            kGTMud_ChickenPeck2,
            kGTMud_ChickenPeck3,
            kGTMud_FlockSheepDown1,
            kGTMud_FlockSheepDown2,
            kGTMud_FlockSheepDown3,
            kGTMud_CowRight1,
            kGTMud_CowRight2,
			kGTMud_CowRight2Blink,
            kGTMud_CowRight3,
            kGTMud_CowLeft1,
            kGTMud_CowLeft2,
            kGTMud_CowLeft2Blink,
			kGTMud_CowLeft3,
            kGTMud_PicnicBlanket,
            kGTMud_TulipsYellow,
            kGTMud_TulipYellowPetal1,
            kGTMud_TulipYellowPetal2,
            kGTMud_TulipWhite,
            kGTMud_TulipWhitePetal1,
            kGTMud_TulipWhitePetal2,
            kGTMud_TulipsBlue,
            kGTMud_TulipBluePetal1,
            kGTMud_TulipBluePetal2,
            kGTMud_TulipPetalShadow,
            kGTMud_RoofLine1,
            kGTMud_RoofLine2,
            kGTMud_RoofLine3,
            kNumGameThingsMud
        };
        public enum Enum3 {
            kGTGrass_Flowers = 0,
            kGTGrass_Flowers2,
            kGTGrass_Bollard,
            kGTGrass_CowRight1,
            kGTGrass_CowRight2,
            kGTGrass_CowRight2Blink,
            kGTGrass_CowRight3,
            kGTGrass_CowLeft1,
            kGTGrass_CowLeft2,
            kGTGrass_CowLeft2Blink,
            kGTGrass_CowLeft3,
            kGTGrass_CowDown1,
            kGTGrass_CowDown2,
            kGTGrass_CowDown3,
            kGTGrass_TreeTop1_WithApples,
            kGTGrass_TreeTop2,
            kGTGrass_Rainbow,
            kGTGrass_AppleShadow,
            kGTGrass_FlowerHead1,
            kGTGrass_BushFragment1,
            kGTGrass_BushFragment2,
            kGTGrass_Footstep1,
            kGTGrass_Footstep2,
            kGTGrass_GenericShadow,
            kGTGrass_PlayerShadow,
            kGTGrass_CowShadow,
            kGTGrass_FlowerShadow1,
            kGTGrass_FlowerShadow2,
            kGTGrass_FlowerShadow3,
            kGTGrass_FlowerShadow4,
            kGTGrass_FlowerShadow5,
            kGTGrass_FlowerShadow6,
            kGTGrass_FlowerShadow7,
            kGTGrass_BushCrashTop,
            kGTGrass_BushCrashBottom,
            kGTGrass_TreeTop1,
            kGTGrass_TreeTop3,
            kGTGrass_Apple1,
            kGTGrass_Gnome,
            kGTGrass_GnomeSmashed,
            kGTGrass_GnomePieceRed1,
            kGTGrass_GnomePieceRed2,
            kGTGrass_GnomePieceRed3,
            kGTGrass_GnomePieceRed4,
            kGTGrass_GnomePieceRed5,
            kGTGrass_GnomePieceBlack1,
            kGTGrass_GnomePieceBlack2,
            kGTGrass_GnomePieceBlack3,
            kGTGrass_GnomePieceBlack4,
            kGTGrass_GnomePieceBlack5,
            kGTGrass_FoamyRatio,
            kGTGrass_FoamyRatio2,
            kGTGrass_SheepPoo,
            kGTGrass_TulipsRed,
            kGTGrass_TulipsRed_Petal1,
            kGTGrass_TulipsRed_Petal2,
            kGTGrass_TulipsRed_Squashed,
            kGTGrass_PicnicBlanket,
            kGTGrass_ShaunShadow1,
            kGTGrass_ShaunShadow2,
            kGTGrass_ShaunShadow3,
            kGTGrass_ShaunShadow4,
            kGTGrass_ShaunShadow5,
            kGTGrass_PiggyShadow,
            kGTGrass_TulipsYellow,
            kGTGrass_TulipYellowPetal1,
            kGTGrass_TulipYellowPetal2,
            kGTGrass_TulipWhite,
            kGTGrass_TulipWhitePetal1,
            kGTGrass_TulipWhitePetal2,
            kGTGrass_TulipsBlue,
            kGTGrass_TulipBluePetal1,
            kGTGrass_TulipBluePetal2,
            kGTGrass_TulipPetalShadow,
            kNumGameThingsGrass
        };
        public enum Enum4 {
            kHU_Bitzer = 0,
            kHU_RaceLine,
            kHU_Shaun,
            kHU_Piggy,
            kHU_Right,
            kHU_Left,
            kHU_PauseButton,
            kHU_PauseBar,
            kHU_ButtonNext,
            kHU_ButtonRetry,
            kHU_ButtonMenu,
            kHU_Target,
            kHU_PauseBar_Ipad,
        };
        public enum Enum5 {
            kRL_Sign = 0,
            kRL_Piggy,
            kRL_Back,
            kRL_Rope,
            kRL_Retry,
            kRL_NextLevel,
            kRL_BackButton,
            kRL_BackBar,
            kRL_BackButtonGerman,
            kRL_BackArrowEmpty,
            kRL_BackBar_Ipad,
        };
        public enum Enum6 {
            kSSH_TipSign = 0,
            kSSH_Piggy,
            kSSH_PlaySign,
            kSSH_Rope,
            kSSH_BestTimeSign,
            kSSH_LongTitleSign,
            kSSH_TipButton,
            kSSH_Restart,
            kSSH_NextLevel,
            kSSH_BackButton,
            kSSH_BackBar,
            kSSH_Facebook,
            kSSH_BackInGerman,
            kSSH_BestTimeInGerman,
            kSSH_TipInGerman,
            kSSH_PlayInGerman,
            kSSH_BackBar_iPad,
            kSSH_BestTimeSignEmpty,
            kSSH_PlaySignEmpty,
            kSSH_TipArrowEmpty,
            kSSH_BackArrowEmpty,
        };
        public enum Enum7 {
            kFL_Rope = 0,
            kFL_CongratsSign,
            kFL_LongTitle,
        };
        public enum Enum8 {
            kAN_Pig = 0,
            kAN_Hedge,
            kAN_PlaySign,
            kAN_Rope,
        };
        public enum Enum9 {
            kFE_LongNameButton = 0,
            kFE_Rope,
            kFE_StageIcon,
            kFE_Chain,
            kFE_Total,
            kFE_Right,
            kFE_Left,
            kFE_StageLocked,
            kFE_BlankButton,
            kFE_Thumb,
            kFE_Tilt,
            kFE_Create,
            kFE_Race,
            kFE_Level0apples,
            kFE_Level1apples,
            kFE_Level2apples,
            kFE_Level3apples,
            kFE_LevelLocked,
            kFE_Info,
            kFE_Crystal,
            kFE_Options,
            kFE_Credits,
            kFE_Practise,
            kFE_TerrainGrass,
            kFE_TerrainMud,
            kFE_BackBarCreate,
            kFE_BackBarPlay,
            kFE_SpecialLock,
            kFE_FingerButt,
            kFE_TerrainEmpty,
            kFE_TerrainGrasssmall,
            kFE_TerrainMudsmall,
            kFE_Trash,
            kFE_FBLogin,
            kFE_FBLogoff,
            kFE_StartSmallButton1,
            kFE_StartSmallButton2,
            kFE_StartSmallButton3,
            kFE_ThumbGerman,
            kFE_TiltGerman,
            kFE_CreateGermanBackButton,
            kFE_NewsTab,
            kFE_Rennen,
            kFE_Spielen,
            kFE_StageButtonWordPlay,
            kFE_StageButtonWordPlayDE,
            kFE_TipArrowEmpty,
            kFE_BackArrowEmpty,
            kFE_FaceBookEmpty,
            kFE_RaceJap,
            kFE_RaceChin,
            kFE_StageButtonWordPlayChin,
            kFE_StageButtonWordPlayJap,
            kFE_StageButtonWordPlayFrench,
            kFE_RaceFrench,
        };
        public enum Enum10 {
            kSTGrass_FoamyRatio = 0,
            kSTGrass_BushHalfLeftTop,
            kSTGrass_BushHalfRightTop,
        };
        public enum  Enum11 {
            kLanguage_English = 0,
            kLanguage_French,
            kLanguage_Spanish,
            kLanguage_German,
            kLanguage_China,
            kLanguage_Japanese,
        };
        public struct DropboxVariables{
            short sheepRunAnim_NumTurnAnims;
            short sheepRunAnim_NumRunAnims;
            bool sheepRunAnim_Bounces;
            float sheepRunAnim_DistancePerAnimFrame;
        };
			
		
		public enum Colours
		{
			kRed = 0,
			kWhite,
			kLightGreen,
			kLilac,
			kLightBlue,
			kGreenMenuBack,
			kGreenMenuBackRays,
			kYellow,
			kPink,
			kPurpleMenuBack,
			kPurpleMenuBackRays,
			kDarkBlue,
			kBrown_FleeceMenu,
			kColourRedText,
			kColourTurquoiseText,
			kFarmText,
			kBrown,
			kYellowLemon,
			kOrange,
			kStarCup,
			kCountry,
			kYellowMenuBackRays,
			kYellowMenuBack,
			kIndigo,
			kColourRedTip,
			kNum
		};
		
		
	public UnityEngine.Material GetFontColourMaterial(Colours inColour, Default.Namespace.Constants.RossColour rossCol)
	{	
		//Debug.Log ("GetFontColourMaterial " + inColour.ToString());	
			
		if (myMaterialWithColour[(int)inColour] == null)
		{
			myMaterialWithColour[(int)inColour] = new UnityEngine.Material(Shader.Find( "GUI/Text Shader" ));		
							
			UnityEngine.Color tempC = new UnityEngine.Color();
			tempC.a=0.8f;
			tempC.r=rossCol.cRed;
			tempC.g=rossCol.cGreen;
			tempC.b=rossCol.cBlue;

				
		//Debug.Log ("tempC r:" + tempC.r.ToString() + ",g:" + tempC.g + ",b:" + tempC.b);	
				
				
				//			tempC.r=1.0f;
//			tempC.g=Utilities.GetRandBetweenP1(0.0f,1.0f);
//			tempC.b=Utilities.GetRandBetweenP1(0.0f,1.0f);
//				Debug.Log("tempC.r" + tempC.r);
				
			myMaterialWithColour[(int)inColour].mainTexture = guiFont.material.mainTexture;
			myMaterialWithColour[(int)inColour].color = tempC;
//			myMaterialWithColour[(int)inColour].SetColor("blah",tempC);
		}
		
		return myMaterialWithColour[(int)inColour];
	}
		
		
	public UnityEngine.Material GetFontColourMaterial(Default.Namespace.Constants.RossColour inColour)
	{
		if (inColour.myId == -1)
			{
				Globals.Assert(false);
			}
			else
			{
				return this.GetFontColourMaterial((Colours)inColour.myId,inColour);
					
			}
			
			
			
			
		if (inColour == Default.Namespace.Constants.kColourWhite)
			{
				Debug.Log("inWhite");

				return this.GetFontColourMaterial(Colours.kWhite,inColour);
			}
		else if (inColour == Default.Namespace.Constants.kColourLightGreen)
			{
				Debug.Log("inLightGreen");
				
			return this.GetFontColourMaterial(Colours.kLightGreen,inColour);
			}
		else if (inColour == Default.Namespace.Constants.kColourRed)
			return this.GetFontColourMaterial(Colours.kRed,inColour);
		else if (inColour == Default.Namespace.Constants.kColourLilac)
			return this.GetFontColourMaterial(Colours.kLilac,inColour);
		else if (inColour == Default.Namespace.Constants.kColourLightblue)
			return this.GetFontColourMaterial(Colours.kLightBlue,inColour);
		else if (inColour == Default.Namespace.Constants.kColourGreenMenuBack)
			return this.GetFontColourMaterial(Colours.kGreenMenuBack,inColour);
		else if (inColour == Default.Namespace.Constants.kColourGreenMenuBackRays)
			return this.GetFontColourMaterial(Colours.kGreenMenuBackRays,inColour);
		else if (inColour == Default.Namespace.Constants.kColourYellow)
			return this.GetFontColourMaterial(Colours.kYellow,inColour);
		else if (inColour == Default.Namespace.Constants.kColourPink)
			return this.GetFontColourMaterial(Colours.kPink,inColour);
		else if (inColour == Default.Namespace.Constants.kColourPurpleMenuBack)
			return this.GetFontColourMaterial(Colours.kPurpleMenuBack,inColour);
		else if (inColour == Default.Namespace.Constants.kColourDarkblue)
			return this.GetFontColourMaterial(Colours.kDarkBlue,inColour);
		else if (inColour == Default.Namespace.Constants.kBrown_FleeceMenu)
			return this.GetFontColourMaterial(Colours.kBrown_FleeceMenu,inColour);
		else if (inColour == Default.Namespace.Constants.kColourRedText)
			return this.GetFontColourMaterial(Colours.kColourRedText,inColour);
		else if (inColour == Default.Namespace.Constants.kColourTurquoiseText)
			return this.GetFontColourMaterial(Colours.kColourTurquoiseText,inColour);
		else if (inColour == Default.Namespace.Constants.kColourFarmText)
			return this.GetFontColourMaterial(Colours.kFarmText,inColour);
		else if (inColour == Default.Namespace.Constants.kColourBrown)
			return this.GetFontColourMaterial(Colours.kBrown,inColour);
		else if (inColour == Default.Namespace.Constants.kColourYellowLemon)
			return this.GetFontColourMaterial(Colours.kYellowLemon,inColour);
		else
		{
			return this.GetFontColourMaterial(Colours.kLightGreen,inColour);

			Debug.Log ("Tried to set colour " + inColour.ToString());
//			Default.Namespace.Globals.Assert(false);
		}
			return null;
	}			
		
        //extern short Globals.g_currentLanguage;
        public Game GetGame()
        {
            return game;
        }

        public FrontEnd GetFrontEnd()
        {
            return frontEnd;
        }

        public ZAtlas GetAtlas(AtlasType inType)
        {
            Globals.Assert(inType < AtlasType.kNumAtlases);
            return atlas[(int)inType];
        }

        public ZAtlas GetAtlas (int inType)
		{
			return this.GetAtlas((AtlasType)inType);
		}

        public float TileMapHeight
        {
            get;
            set;
        }

        public float ScreenWidth
        {
            get;
            set;
        }

        public float ScreenHeight
        {
            get;
            set;
        }

        public float CoordinatesWidth
        {
            get;
            set;
        }

        public float CoordinatesHeight
        {
            get;
            set;
        }

        public Game Game
        {
            get;
            set;
        }

        public FrontEnd FrontEnd
        {
            get;
            set;
        }

        public WorldState WorldState
        {
            get;
            set;
        }

        public ZFont Font
        {
            get;
            set;
        }

        public Audio Audio
        {
            get;
            set;
        }

        public bool HaveReachedTitleYet
        {
            get;
            set;
        }

        public int ArtLevel
        {
            get;
            set;
        }

        public int CurrentlyLoadedScene
        {
            get;
            set;
        }

        public int GoingToFrontEndFromShowLevel
        {
            get;
            set;
        }

        public int DeviceType
        {
            get;
            set;
        }

        public float RenderScale
        {
            get;
            set;
        }

        public float PreviousRenderScale
        {
            get;
            set;
        }

        public float MapObjectAppearDistance
        {
            get;
            set;
        }

        public float DrawWidth
        {
            get;
            set;
        }

        public float DrawHeight
        {
            get;
            set;
        }

        public float LeftDrawEdge
        {
            get;
            set;
        }

        public float RightDrawEdge
        {
            get;
            set;
        }

//#ifdef ZOOMING_MATRIX_TEST
public void SetDrawWidth(float inThing) {drawWidth = inThing;}///@property(readwrite,assign) float drawWidth;
public void SetDrawHeight(float inThing) {drawHeight = inThing;}///@property(readwrite,assign) float drawHeight;
public void SetLeftDrawEdge(float inThing) {leftDrawEdge = inThing;}///@property(readwrite,assign) float leftDrawEdge;
public void SetRightDrawEdge(float inThing) {rightDrawEdge = inThing;}///@property(readwrite,assign) float rightDrawEdge;
public void SetRenderScale(float inThing) {renderScale = inThing;}///@property(readwrite,assign) float renderScale;
	public void SetPreviousRenderScale(float inThing) {previousRenderScale = inThing;}///@property(readwrite,assign) float previousRenderScale;
	public void SetMapObjectAppearDistance(float inThing) {mapObjectAppearDistance = inThing;}///@property(readwrite,assign) float mapObjectAppearDistance;
//#endif
public void SetScreenWidth(float inThing) {screenWidth = inThing;}///@property(readwrite,assign) float screenWidth;
public void SetHaveReachedTitleYet(bool inThing) {haveReachedTitleYet = inThing;}///@property(readwrite,assign) float screenWidth;
public void SetScreenHeight(float inThing) {screenHeight = inThing;}///@property(readwrite,assign) float screenHeight;
public void SetCoordinatesWidth(float inThing) {coordinatesWidth = inThing;}///@property(readwrite,assign) float coordinatesWidth;
public void SetCoordinatesHeight(float inThing) {coordinatesHeight = inThing;}///@property(readwrite,assign) float coordinatesHeight;
public void SetTileMapHeight(float inThing) {tileMapHeight = inThing;}///@property(readwrite,assign) float tileMapHeight;
public void SetGoingToFrontEndFromShowLevel(int inThing) {goingToFrontEndFromShowLevel = inThing;}///@property(readwrite,assign) float tileMapHeight;
public void SetCurrentlyLoadedScene(int inThing) {currentlyLoadedScene = inThing;}///@property(readwrite,assign) float tileMapHeight;

//public void SetPosition(CGPoint inThing) {position = inThing;}///@property NetworkStatus remoteHostStatus;

//        public NetworkStatus RemoteHostStatus
  //      {
    //        get;
      //      set;
        //}

//        @synthesize dropBoxVariables;
        

//				public World () //CrashLandingAppDelegate mainThing)
				public void DoLoadingShit () //CrashLandingAppDelegate mainThing)
		{
			//if (!base.init()) return null;
			
//			loadADCQueue = new LoadADCQueue();
			//isLoadingADCAssets = false;
			
		for (int i = 0; i < (int)Colours.kNum; i++)
		{
			myMaterialWithColour[i] = null;
		}
			
			
			Globals.g_world = this;
			for (int i = 0; i < (int) AtlasType.kNumAtlases; i++) {
				atlas [i] = null;
			}
			
			gameCam = GameObject.Find("Main Camera").GetComponent<Camera>();
			tileCam = GameObject.Find(" Main Camera For Tiles").GetComponent<Camera>();
			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				gameCam.orthographicSize = 480.0f;
				tileCam.orthographicSize = 480.0f;
				Camera guiCam = GameObject.Find(" Main Camera For GUI").GetComponent<Camera>();
				guiCam.orthographicSize = 480.0f;
			}
			
						this.SetScreenEdgeValues();

//			float xScreenIPhoneWidth = Screen.height * 0.66666666f;
//			float offscreenWidth = xScreenIPhoneWidth - Screen.width;
//						float ratio = (offscreenWidth * 0.5f) / xScreenIPhoneWidth;
//
//						if (offscreenWidth > 0.0f)
//			{
//				xScreenEdge = ratio * 320.0f;
//			}
//			else
//				xScreenEdge = 0.0f;
//
//						xScreenEdgeReal = ratio * 320.0f;


	//					xScreenEdge = 0.0f;

			rankWord = null;
			rankWordTop = null;
			renderScale = 1.0f;
			previousRenderScale = -1.0f;
			mapObjectAppearDistance = 530.0f;
			goingToFrontEndFromShowLevel = -1;
			currentlyLoadedScene = -1;
			currentlyLoadedOpponent = -1;
			inFirstLoad = true;
			UnityEngine.SystemLanguage language = Application.systemLanguage;// "en";//(NSLocale.PreferredLanguages()).ObjectAtIndex(0);
            if (language == SystemLanguage.German) {
                Globals.g_currentLanguage = World.Enum11.kLanguage_German;
            }
            else if (language == SystemLanguage.Chinese) {
                Globals.g_currentLanguage = World.Enum11.kLanguage_China;
            }
            else if (language == SystemLanguage.Japanese) {
                Globals.g_currentLanguage = World.Enum11.kLanguage_Japanese;
            }
            else if (language == SystemLanguage.French) {
                Globals.g_currentLanguage = World.Enum11.kLanguage_French;
            }
            else {
                Globals.g_currentLanguage = World.Enum11.kLanguage_English;
            }
						
//            Globals.g_currentLanguage = World.Enum11.kLanguage_Japanese;
 //          Globals.g_currentLanguage = World.Enum11.kLanguage_China;
       //     Globals.g_currentLanguage = World.Enum11.kLanguage_German;
        //    Globals.g_currentLanguage = World.Enum11.kLanguage_French;

			
			unityUIAlert = new UnityUIAlert();
			guiFont = new Font();
			
			
			guiFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
//			guiFont = (Font) Resources.Load( "Fonts/ArialUnicode") as Font;	
			
			font = new ZFont();
            audio = new Audio();
            this.SetupAtlases();
            Globals.Assert(Constants.kScreenMultiplierForShorts480 == (Constants.kScreenMultiplierForShorts * 480.0f));
            gameSoundsLoadedYet = false;
            haveReachedTitleYet = false;
            frontEnd = new FrontEnd();
            game = new Game();
			game.lBuilder.Setup(-1);
            SoundEngine.Instance();
            ParticleSystemRoss.Instance();
            ((Ztransition.GetTransition()).zobject).SetSpinAmount(5);
            pullTab = null;
            pullTabNews = null;
            leaderboardRank = null;
            //return this;
        }
        public void SendEmailToP1P2(string to, string subject, string body)
        {
        }

        public Texture2D_Ross LoadTextureFromURLP1P2P3(bool stretchable, int tempFileId, string textureName, Texture2D_RossPixelFormat forceType)
        {
			return null;//new Texture2D_Ross(stretchable, true, tempFileId, textureName, forceType);
        }

        public Texture2D_Ross LoadTextureP1(bool stretchable, string textureName, int assetId, LoadADCQueue.AssetType inType)
        {
			return this.LoadTextureP1P2(stretchable,textureName,Texture2D_RossPixelFormat.t_Automatic, assetId, inType
				);
			
/*            if (inFirstLoad) Globals.g_main.RenderLoadingBar();

            string useName = "";
            bool iPhone4 = false;
            if (textureName == ("LevelBuilderBack.png")) {
                if (Globals.deviceIPad) {
                    string temp = System.IO.Path.GetFileNameWithoutExtension(textureName);// textureName.StringByDeletingPathExtension();
                    useName = String.Format("%@@2x~iphone.png", temp);
                    iPhone4 = true;
                }

            }
            else {
                if (Globals.useRetina) {
                    string temp = System.IO.Path.GetFileNameWithoutExtension(textureName);//textureName.StringByDeletingPathExtension();
                    useName = String.Format("%@@2x~iphone.png", temp);
                    iPhone4 = true;
                }

            }

            if (!iPhone4) {
				useName = textureName;////.Copy();
            }


			return null;//new Texture2D_Ross(stretchable, useName);*/
        }
			
		
/*		public UnityEngine.Texture LoadTextureFromADC(string resourceName, ref UnityEngine.Material inMat, int atlasId) 
		{
			Debug.Log ("Try to load texture from ADC " + resourceName);
			
			Globals.g_main.loadADC.LoadTextureFromADC2(resourceName, ref inMat, atlasId);

			Debug.Log ("Getting texture from loadADC class " + resourceName + " : " + Globals.g_main.loadADC.loadedTexture);
			
			
//			double timePassed = 0.0f;
//			double startTime = DateTime.Now.TimeOfDay.Milliseconds;
			
//			while((Globals.g_main.loadADC.isBusy) && (timePassed < 5000.0f))
		//	{
		//		double nowTime = DateTime.Now.TimeOfDay.Milliseconds;
		//		timePassed = nowTime - startTime;
		//	};

//			Globals.Assert(Globals.g_main.loadADC.loadedTexture != null);
			
			return Globals.g_main.loadADC.loadedTexture;
			
//			return null;
			
/*			www = new WWW("file:///" + Application.persistentDataPath + "/../assetbundles/Lightmap_" + level + ".unity3d");
			
			yield www;

			if(www == null) 
			{ 
				Debug.Log("No Assets found, make sure SD card is inserted and mounted properly."); 
			}
			
//			return www.assetBundle.Load(resourceName) as Texture2D;
						
			Texture returnThis = www.assetBundle.Load(resourceName) as Texture;
		
//			lightmaparray = LightmapSettings.lightmaps;
//					
//			var mapdata : LightmapData = new LightmapData();
//			
//					for (var i = 0; i < lightmaparray.length; i++) {
//			    mapdata.lightmapFar = lmObject;
//			    lightmaparray[i] = mapdata;
//			}
//			LightmapSettings.lightmaps = lightmaparray;
		
			
			www.assetBundle.Unload(false);
		
//			if(!paused)
//			{
//				www = new WWW("file:///" + Application.persistentDataPath + "/../assetbundles/M_" + worldText + ".unity3d");
//		
//				yield www;
//				if(www == null) 
//				{
//					Debug.Log("No Assets found, make sure SD card is inserted and mounted properly."); 
//				}
//		
//				CharController.worldMusic.audio.clip =
//				www.assetBundle.Load("Level_" + worldText);
//				CharController.worldMusic.audio.Play();
//			}
//	
//		www.assetBundle.Unload(false);
			
			return returnThis;*/
//	}		
		

        public Texture2D_Ross LoadTextureP1P2(bool stretchable, string textureName, Texture2D_RossPixelFormat forceType, int assetId, LoadADCQueue.AssetType inType)
        {
            if (inFirstLoad) Globals.g_main.RenderLoadingBar();

            string useName = "";
            bool iPhone4 = false;
            if (textureName == ("PiggyAnims.png")) {
                if (Globals.useRetina) {
                    string temp = System.IO.Path.GetFileNameWithoutExtension(textureName);//textureName.StringByDeletingPathExtension();
                    useName = String.Format("%@@big.png", temp);
                    iPhone4 = true;
                }

            }
            else if (textureName == ("LevelBuilderBack.png")) {
                if (Globals.deviceIPad) {
                    string temp = System.IO.Path.GetFileNameWithoutExtension(textureName);//textureName.StringByDeletingPathExtension();
                    useName = String.Format("%@@2x~iphone.png", temp);
                    iPhone4 = true;
                }

            }
            else if (textureName == ("BlueBack.png")) {
            }
            else {
                if (Globals.useRetina) {
                    string temp = System.IO.Path.GetFileNameWithoutExtension(textureName);//textureName.StringByDeletingPathExtension();
                    useName = String.Format("%@@2x~iphone.png", temp);
                    iPhone4 = true;
                }

            }
						
			bool withTransparency;
			if (forceType == Texture2D_RossPixelFormat.t_RGB565)
			{
				withTransparency = false;
			}
			else
			{
				withTransparency = true;
			}
			
			return new Texture2D_Ross(stretchable, textureName, withTransparency, assetId, inType);
        }

        public float GetRotationScaleForShorts(float inVal)
        {

        //    #if TEST_VERT_SHORTS
           //     return inVal * Constants.kScreenMultiplierForShorts;
          //  #else
                return inVal;
            //#endif

        }

        public void DoGLTranslateDistanceP1(float x, float y)
        {

            #if TEST_VERT_SHORTS
                //glTranslatef(x * Constants.kScreenMultiplierForShorts, (y * Constants.kScreenMultiplierForShorts), 0);
            #else
                //glTranslatef(x, 480.0 - y, 0);
            #endif

        }

        public void DoGLTranslateP1(float x, float y)
        {

            #if TEST_VERT_SHORTS
                if (Globals.deviceIPad) {
                    x *= 2.0f;
                    x += 64.0f;
                    y *= 2.0f;
                    y += 32.0f;
                    y = Globals.g_world.tileMapHeight - y;
                    //glTranslatef(x * Constants.kScreenMultiplierForShorts, y * Constants.kScreenMultiplierForShorts, 0);
                }
                else {
                    //glTranslatef(x * Constants.kScreenMultiplierForShorts, Constants.kScreenMultiplierForShorts480 - (y * Constants.kScreenMultiplierForShorts)
                      , 0);
                }

            #else
                //glTranslatef(x, 480.0 - y, 0);
            #endif

        }

        public int AddFunnyWordP1P2P3P4P5P6P7P8P9(FrontEndScreen inScreen, int stringId, ZFont inFont, ZAtlas inLinesAtlas, ZAtlas inColoursAtlas, CGPoint
          inPosition, float inScale, string inWord, bool isCentrePosition, Constants.RossColour inCol)
        {
            int fwId = -1;
            if (this.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo = new FrontEndScreen.AddFunnyWordInfo();
                fInfo.inString = this.GetNSString((StringId)stringId);
                fInfo.position = inPosition;
                fInfo.scale = inScale * 0.75f;
                fwId = inScreen.AddFunnyWord(fInfo);
            }
            else {
                fwId = inScreen.AddFunnyWordP1P2P3P4P5P6(inFont, inLinesAtlas, inColoursAtlas, inPosition, inScale, inWord, isCentrePosition);
            }

            (inScreen.GetFunnyWord(fwId)).SetColour(inCol);
            return fwId;
        }

        public int AddFunnyWordP1P2P3P4P5P6P7P8(FrontEndScreen inScreen, int stringId, ZFont inFont, ZAtlas inLinesAtlas, ZAtlas inColoursAtlas, CGPoint
          inPosition, float inScale, string inWord, bool isCentrePosition)
        {
            return this.AddFunnyWordP1P2P3P4P5P6P7P8P9(inScreen, stringId, inFont, inLinesAtlas, inColoursAtlas, inPosition, inScale, inWord, isCentrePosition,
              Constants.kColourLightGreen);
        }

        string GetStringEnglish(StringId inStringId)
        {
            switch (inStringId) {
            case StringId.kString_Best :
                outString = "best\n";
                break;
            case StringId.kString_Music :
                outString = "music\n";
                break;
            case StringId.kString_SoundFX :
                outString = "fx\n";
                break;
            case StringId.kString_Ghost :
                outString = "ghost\n";
                break;
            case StringId.kString_ClearData :
                outString = "clear data\n";
                break;
            case StringId.kString_About :
                outString = "About\n";
                break;
            case StringId.kString_ControlMethod :
                outString = "Control Method\n";
                break;
            case StringId.kString_ChooseControl :
                outString = "Choose Controls\n";
                break;
            case StringId.kString_Practise :
                outString = "Practise\n";
                break;
            case StringId.kString_Total :
                outString = "Total\n";
                break;
            case StringId.kString_Unlock :
                outString = "To Unlock\n";
                break;
            case StringId.kString_Done :
                outString = "Done\n";
                break;
            case StringId.kString_Move :
                outString = "Move\n";
                break;
            case StringId.kString_Clear :
                outString = "Clear\n";
                break;
            case StringId.kString_Copy :
                outString = "Copy\n";
                break;
            case StringId.kString_Create :
                outString = "Create\n";
                break;
            case StringId.kString_Store :
                outString = "Store\n";
                break;
            case StringId.kString_BuyAllLevels :
                outString = "Unlock All Levels\n";
                break;
            case StringId.kString_BuyNoAds :
                outString = "Remove Ads\n";
                break;
			case StringId.kString_Restore :
                outString = "Restore\n";
                break;

			default :
                Globals.Assert(false);
                break;
            }

            return outString;
        }

        public bool DoesCurrentLanguageUseNSString()
        {
            switch (Globals.g_currentLanguage) 
			{
            case World.Enum11.kLanguage_English :
				return false;
			case World.Enum11.kLanguage_German :
                return false;
            default :
                break;
            }

            return true;
        }

        string GetStringChinese (StringId inStringId)
		{
			switch (inStringId) 
			{
            case StringId.kString_Best :
                return "best";
            case StringId.kString_Music :
                return "音乐";
                
            case StringId.kString_SoundFX :
                return "音效";
                
            case StringId.kString_Ghost :
                return "幽灵";
                
            case StringId.kString_ClearData :
                return "clear data";
                
            case StringId.kString_About :
                return "关于";
                
            case StringId.kString_ControlMethod :
                return "控制方式";
                
            case StringId.kString_ChooseControl :
                return "选择控制方式";
                
            case StringId.kString_Practise :
                return "练习";
                
            case StringId.kString_Total :
                return "总共";
                
            case StringId.kString_Unlock :
                return "解锁";
                
            case StringId.kString_Done :
                return "完成\n";
                
            case StringId.kString_Move :
                return "移动";
                
            case StringId.kString_Clear :
                return "清除";
                
            case StringId.kString_Copy :
                return "复制";
                
            case StringId.kString_Create :
                return "创建";
                
            case StringId.kString_CustomLevel :
                return "自定义关卡";
                
            case StringId.kString_ChooseTerrain :
                return "选择地形";
                
            case StringId.kString_LevelBuilder_Ross :
                return "关卡编辑器";
                
            case StringId.kString_Tip :
                return "提示";
                
            case StringId.kString_TiltLeftAnd1 :
                return "向左向右倾";
                
            case StringId.kString_TiltLeftAnd2 :
                return "斜设备来驾驶";
                
            case StringId.kString_ButtonControl1 :
                return "按左右键";
                
            case StringId.kString_ButtonControl2 :
                return "来驾驶";
                
            case StringId.kString_FingerFollow1 :
                return "让肖恩跟";
                
            case StringId.kString_FingerFollow2 :
                return "着你的手指";
                
            case StringId.kString_EULA :
                return "最终用户许可协议";
                
            case StringId.kString_Privacy :
								return "保密和Cookie协议";
                
            case StringId.kString_Terms :
                return "服务条款";
                
            case StringId.kString_EA :
                return "购买或/以及使用这\n款程序，表示您同意\n最终用户许可条款";
                
            case StringId.kString_WatchOut :
                return "小心！";
                
            case StringId.kString_AnotherPig :
                return "另一头猪已经";
                
            case StringId.kString_JoinedRace :
                return "加入竞赛！";
                
            case StringId.kString_FBLogin :
                return "FB登入";
                
            case StringId.kString_FBLogout :
                return "FB登出";
                
            case StringId.kString_EnterTrack :
                return "输入跑道名称";
                
            case StringId.kString_SureClearTrack :
                return "你确定要清除这个关卡么？";
                
            case StringId.kString_LevelAlreadyEmpty :
                return "关卡已经清空";
                
            case StringId.kString_ControlThumb :
                return "拇指";
                
            case StringId.kString_ControlTilt :
                return "倾斜";
                
            case StringId.kString_ControlFinger :
                return "手指";
                
            case StringId.kString_BestTime :
                return "最快时间";
                
            case StringId.kString_Play :
                return "开始游戏";
                
            case StringId.kString_Completed :
                return "你完成了";
                
            case StringId.kString_BaaRilliant :
                return "咩妙极了！";                
            default :
                Globals.Assert(false);
				break;
            }

            return "";
        }
		

        string GetStringFrench (StringId inStringId)
		{
			switch (inStringId) 
			{
            case StringId.kString_Best :
                return "best";
            case StringId.kString_Music :
                return "Musique";
                
            case StringId.kString_SoundFX :
                return "Effets";
                
            case StringId.kString_Ghost :
                return "Fantôme";
                
            case StringId.kString_ClearData :
                return "clear data";
                
            case StringId.kString_About :
                return "À propos";
                
            case StringId.kString_ControlMethod :
                return "Commandes";
                
            case StringId.kString_ChooseControl :
                return "Choix des commandes";
                
            case StringId.kString_Practise :
                return "Entraînement";
                
            case StringId.kString_Total :
                return "Total";
                
            case StringId.kString_Unlock :
                return "Pour débloquer";
                
            case StringId.kString_Done :
                return "Terminé";
                
            case StringId.kString_Move :
                return "Déplacer";
                
            case StringId.kString_Clear :
                return "Supprimer";
                
            case StringId.kString_Copy :
                return "Copier";
                
            case StringId.kString_Create :
                return "Créer";
                
            case StringId.kString_CustomLevel :
                return "Niveau personnalisé";
                
            case StringId.kString_ChooseTerrain :
                return "Choix du terrain";
                
            case StringId.kString_LevelBuilder_Ross :
                return "Éditeur de niveau";
                
            case StringId.kString_Tip :
                return "Astuce";
                
            case StringId.kString_TiltLeftAnd1 :
                return "Penchez l’appareil à Gauche";
                
            case StringId.kString_TiltLeftAnd2 :
                return "et à Droite pour tourner";
                
            case StringId.kString_ButtonControl1 :
                return "Appuyez sur les boutons Gauche";
                
            case StringId.kString_ButtonControl2 :
                return "et Droite pour tourner";
                
            case StringId.kString_FingerFollow1 :
                return "Shaun va suivre";
                
            case StringId.kString_FingerFollow2 :
                return "votre doigt";
                
            case StringId.kString_EULA :
                return "CLUF";
                
            case StringId.kString_Privacy :
								return "Politique relative à la protection des \ndonnées personnelles et aux cookies";
                
            case StringId.kString_Terms :
                return "Conditions d’utilisation";
                
            case StringId.kString_EA :
                return "En achetant et/ou en utilisant \ncette application, vous acceptez les \ntermes du contrat de licence d'utilisateur \nfinal, ainsi que les règles de \nconfidentialité et les conditions \nd'utilisation d’Aardman.";
                
            case StringId.kString_WatchOut :
                return "Attention !";
                
            case StringId.kString_AnotherPig :
                return "Un autre cochon";
                
            case StringId.kString_JoinedRace :
                return "a rejoint la course !";
                
            case StringId.kString_FBLogin :
                return "Connexion FB";
                
            case StringId.kString_FBLogout :
                return "Déconnexion FB";
                
            case StringId.kString_EnterTrack :
                return "Nom du circuit";
                
            case StringId.kString_SureClearTrack :
                return "Supprimer ce niveau ?";
                
            case StringId.kString_LevelAlreadyEmpty:
                return "Le niveau est vide";
                
            case StringId.kString_ControlThumb :
                return "Pouce";
                
            case StringId.kString_ControlTilt :
                return "Pencher";
                
            case StringId.kString_ControlFinger :
                return "Doigt";
                
            case StringId.kString_BestTime :
                return "Record";
                
            case StringId.kString_Play :
                return "Jouer";
                
            case StringId.kString_Completed :
                return "Vous avez terminé";
                
            case StringId.kString_BaaRilliant :
                return "Bêê-rillant!";
				
            case StringId.kString_Store :
                return "Store\n";
                break;
            case StringId.kString_BuyAllLevels :
                return "Unlock All Levels\n";
                break;
            case StringId.kString_BuyNoAds :
                return "Remove Ads\n";
                break;
            case StringId.kString_Restore :
                outString = "Restore\n";
                break;
				
                
            default :
                Globals.Assert(false);
				break;
            }

            return "";
        }		

        string GetStringJapanese(StringId inStringId)
        {
            switch (inStringId) 
			{
            case StringId.kString_Best :
                return "best\n";   
            case StringId.kString_Music :
                return "音楽";
                
            case StringId.kString_SoundFX :
                return "効果音";
                
            case StringId.kString_Ghost :
                return "ゴースト";
                
            case StringId.kString_ClearData :
                return "clear data\n";
                
            case StringId.kString_About :
                return "～について";
                
            case StringId.kString_ControlMethod :
                return "操作方法";
                
            case StringId.kString_ChooseControl :
                return "操作方法";
                
            case StringId.kString_Practise :
                return "練習";
                
            case StringId.kString_Total :
                return "合計";
                
            case StringId.kString_Unlock :
                return "アンロックの仕方";
                
            case StringId.kString_Done :
                return "終了";
                
            case StringId.kString_Move :
                return "移動";
                
            case StringId.kString_Clear :
                return "クリア";
                
            case StringId.kString_Copy :
                return "コピー";
                
            case StringId.kString_Create :
                return "クリエイト";
                
            case StringId.kString_CustomLevel :
                return "カスタムレベル";
                
            case StringId.kString_ChooseTerrain :
                return "地域を選択して下さい";
                
            case StringId.kString_LevelBuilder_Ross :
                return "レベルエディター";
                
            case StringId.kString_Tip :
                return "ヒント";
                
            case StringId.kString_TiltLeftAnd1 :
                return "デバイスを左右に傾けて";
                
            case StringId.kString_TiltLeftAnd2 :
                return "ハンドル操作をして下さい";
                
            case StringId.kString_ButtonControl1 :
                return "右ボタン、左ボタンを押し";
                
            case StringId.kString_ButtonControl2 :
                return "てハンドル操作をして下さい";
                
            case StringId.kString_FingerFollow1 :
                return "ショーンはあな";
                
            case StringId.kString_FingerFollow2 :
                return "たの指に従います";
                
            case StringId.kString_EULA :
                return "EULA";
                
            case StringId.kString_Privacy :
								return "プライバシー ＆ クッキーポリシー";
                
            case StringId.kString_Terms :
                return "利用規約";
                
            case StringId.kString_EA :
                return
                    "このアプリケーションの購入もしくは\n使用でエンドユーザ使用許諾契約書\n及びAardmanのプライバシーポリシー及び利\n用規約に同意した物とみなします。"
                ;
                
            case StringId.kString_WatchOut :
                return "おっと！気をつけて！";
                
            case StringId.kString_AnotherPig :
                return "他の豚がレースに参";
                
            case StringId.kString_JoinedRace :
                return "加してしきました！";
                
            case StringId.kString_FBLogin :
                return "ログイン";
                
            case StringId.kString_FBLogout :
                return "ログアウト";
                
            case StringId.kString_EnterTrack :
                return "トラックの名前を入力して下さい";
                
            case StringId.kString_SureClearTrack :
                return "ほんとうにこのレベルをリセットしますか？";
                
            case StringId.kString_LevelAlreadyEmpty :
                return "レベルは既に空です";
                
            case StringId.kString_ControlThumb :
                return "親指";
                
            case StringId.kString_ControlTilt :
                return "傾ける";
                
            case StringId.kString_ControlFinger :
                return "指";
                
            case StringId.kString_BestTime :
                return "ベストタイム";
                
            case StringId.kString_Play :
                return "プレイ";
                
            case StringId.kString_Completed :
                return "コンプリートしたぞ";
                
            case StringId.kString_BaaRilliant :
                return "おメェェでとう！";
            case StringId.kString_Store :
                return "Store\n";
                break;
            case StringId.kString_BuyAllLevels :
                return "Unlock All Levels\n";
                break;
            case StringId.kString_BuyNoAds :
                return "Remove Ads\n";
                break;
            case StringId.kString_Restore :
                outString = "Restore\n";
                break;
                
            default :
                Globals.Assert(false);
				break;   
            }

            return "";
        }

        public void AddBackWordsP1(FrontEndScreen inScreen, int inButtonId)
        {
            if (this.DoesCurrentLanguageUseNSString()) {
                FrontEndButton inButton = inScreen.GetButton(inButtonId);
                FrontEndScreen.AddFunnyWordInfo fInfo = new FrontEndScreen.AddFunnyWordInfo();

				fInfo.scale = 0.28f;
				
				switch (Globals.g_currentLanguage) {
                case World.Enum11.kLanguage_China :
                    fInfo.inString = "返回";
                    break;
                case World.Enum11.kLanguage_Japanese :
                    fInfo.inString = "バック";
                    break;
                case World.Enum11.kLanguage_French :
                    fInfo.inString = "Retour";
					fInfo.scale = 0.4f;
					break;
                default :
                    Globals.Assert(false);
                    break;
                }

                fInfo.position = inButton.position;
                fInfo.position.x += 2.0f;
                fInfo.position.y -= 2.0f;
                int fwId = inScreen.AddFunnyWord(fInfo);
                (inScreen.GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
                (inScreen.GetFunnyWord(fwId)).SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (inScreen.GetFunnyWord(fwId)).SetPositionButton(inButton);
            }

        }

        public void AddWordsP1P2(string inWords, FrontEndScreen inScreen, FrontEndButton inButton)
        {
            if (this.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo = new FrontEndScreen.AddFunnyWordInfo();
                fInfo.inString = inWords;
                fInfo.position = inButton.position;
                fInfo.position.x += 1.0f;
                fInfo.position.y += 5.0f;
                fInfo.scale = 0.26f;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    fInfo.scale = 0.2f;
                }

                int fwId = inScreen.AddFunnyWord(fInfo);
                (inScreen.GetFunnyWord(fwId)).SetColour(Constants.kColourDarkblue);
                (inScreen.GetFunnyWord(fwId)).SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (inScreen.GetFunnyWord(fwId)).SetPositionButton(inButton);
                (inScreen.GetFunnyWord(fwId)).SetOrientationButton(inButton.hangingButton);
            }

        }

        public int GetBackST()
        {
            switch (Globals.g_currentLanguage) {
            case World.Enum11.kLanguage_English :
                return (int)Enum6.kSSH_BackButton;
            case World.Enum11.kLanguage_German :
                return (int)Enum6.kSSH_BackInGerman;
            case World.Enum11.kLanguage_China :
            case World.Enum11.kLanguage_Japanese :
            case World.Enum11.kLanguage_French :
                return (int)Enum6.kSSH_BackArrowEmpty;
            default :
                Globals.Assert(false);
                break;
            }

			return 0;
        }

        int GetSubTextLanguage_FE(int inEnglish)
        {
            if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) || (Globals.g_currentLanguage == World.Enum11.kLanguage_French)) {
                switch (inEnglish) {
                case (int)Enum9.kFE_BackBarPlay :
                case (int)Enum9.kFE_BackBarCreate :
                    return (int)Enum9.kFE_TipArrowEmpty;
                case (int)Enum9.kFE_Tilt :
                case (int)Enum9.kFE_Thumb :
                case (int)Enum9.kFE_FingerButt :
                    return (int)Enum9.kFE_BlankButton;
                default :
                    break;
                }
            }

            if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                switch (inEnglish) {
                case (int)Enum9.kFE_StageButtonWordPlay :
                    return (int)Enum9.kFE_StageButtonWordPlayChin;
                default :
                    break;
                }

            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) 
			{
                switch (inEnglish) {
                case (int)Enum9.kFE_StageButtonWordPlay :
                    return (int)Enum9.kFE_StageButtonWordPlayJap;
                default :
                    break;
                }

            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) 
			{
                switch (inEnglish) 
				{
                case (int)Enum9.kFE_StageButtonWordPlay :
                    return (int)Enum9.kFE_StageButtonWordPlayFrench;
                default :
                    break;
                }

            }

            switch (inEnglish) {
            case (int)Enum9.kFE_Tilt :
                return (int)Enum9.kFE_TiltGerman;
                
            case (int)Enum9.kFE_Thumb :
                return (int)Enum9.kFE_ThumbGerman;
                
            case (int)Enum9.kFE_FingerButt :
                return (int)Enum9.kFE_FingerButt;
                
            case (int)Enum9.kFE_BackBarCreate :
                return (int)Enum9.kFE_CreateGermanBackButton;
                
            case (int)Enum9.kFE_BackBarPlay :
                return (int)Enum9.kFE_Spielen;
                
            case (int)Enum9.kFE_StageButtonWordPlay :
                return (int)Enum9.kFE_StageButtonWordPlayDE;
                
            default :
                Globals.Assert(false);
                break;
            }

			return 0;
        }

        public int GetSubTextLanguageP1(int atlasId, int inEnglish)
        {
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_English) {
                return inEnglish;
            }

            switch ((AtlasType)atlasId) {
            case AtlasType.kAtlas_FrontendAndShowlevel :
                return this.GetSubTextLanguage_FE(inEnglish);
            default :
                break;
            }

            if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) || (Globals.g_currentLanguage == World.Enum11.kLanguage_French)) 
			{
                switch (inEnglish) {
                case (int)Enum6.kSSH_BestTimeSign :
                    return (int)Enum6.kSSH_BestTimeSignEmpty;
                    
                case (int)Enum6.kSSH_PlaySign :
                    return (int)Enum6.kSSH_PlaySignEmpty;
                    
                case (int)Enum6.kSSH_TipButton :
                    return (int)Enum6.kSSH_TipArrowEmpty;
                    
                case (int)Enum6.kSSH_BackButton :
                    return (int)Enum6.kSSH_BackArrowEmpty;
                    
                default :
                    break;
                }

            }

            switch (inEnglish) {
            case (int)Enum6.kSSH_BestTimeSign :
                return (int)Enum6.kSSH_BestTimeInGerman;
                
            case (int)Enum6.kSSH_PlaySign :
                return (int)Enum6.kSSH_PlayInGerman;
                
            case (int)Enum6.kSSH_TipButton :
                return (int)Enum6.kSSH_TipInGerman;
                
            default :
                Globals.Assert(false);
                break;
            }

			return 0;
        }

        public string GetStringGerman(StringId inStringId)
        {
            switch (inStringId) {
            case StringId.kString_Best :
                outString = "best\n";
                break;
            case StringId.kString_Music :
                outString = "Musik\n";
                break;
            case StringId.kString_SoundFX :
                outString = "fx\n";
                break;
            case StringId.kString_Ghost :
                outString = "Geist\n";
                break;
            case StringId.kString_ClearData :
                outString = "clear data\n";
                break;
            case StringId.kString_About :
                outString = "%ber\n";
                break;
            case StringId.kString_ControlMethod :
                outString = "Steuerung\n";
                break;
            case StringId.kString_ChooseControl :
                outString = "Steuermethode w#hlen\n";
                break;
            case StringId.kString_Practise :
                outString = "trainieren\n";
                break;
            case StringId.kString_Total :
                outString = "Summe\n";
                break;
            case StringId.kString_Unlock :
                outString = "Freischalten\n";
                break;
            case StringId.kString_Done :
                outString = "ende\n";
                break;
            case StringId.kString_Move :
                outString = "beweg\n";
                break;
            case StringId.kString_Clear :
                outString = "Leeren\n";
                break;
            case StringId.kString_Copy :
                outString = "kopie\n";
                break;
            case StringId.kString_Create :
                outString = "Erstellen\n";
                break;
            case StringId.kString_Store :
                outString = "Store\n";
                break;
            case StringId.kString_BuyAllLevels :
                outString = "Unlock All Levels\n";
                break;
            case StringId.kString_BuyNoAds :
                outString = "Remove Ads\n";
                break;
            case StringId.kString_Restore :
                outString = "Restore\n";
                break;
			default :
                Globals.Assert(false);
                break;
            }

            return outString;
        }


        public string GetNSString(StringId inStringId)
        {
            switch (Globals.g_currentLanguage) {
            case World.Enum11.kLanguage_China :
                return this.GetStringChinese(inStringId);
            case World.Enum11.kLanguage_Japanese :
                return this.GetStringJapanese(inStringId);
            case World.Enum11.kLanguage_French :
                return this.GetStringFrench(inStringId);
            case World.Enum11.kLanguage_English :
                return this.GetStringEnglish(inStringId);
            case World.Enum11.kLanguage_German :
                return this.GetStringGerman(inStringId);
            default :
                Globals.Assert(false);
                break;
            }

            return null;
        }

        public string GetString(StringId inStringId)
        {
            switch (Globals.g_currentLanguage) {
            case World.Enum11.kLanguage_English :
                return this.GetStringEnglish(inStringId);
            case World.Enum11.kLanguage_German :
            case World.Enum11.kLanguage_China :
            case World.Enum11.kLanguage_Japanese :
            case World.Enum11.kLanguage_French :
                return this.GetStringGerman(inStringId);
            default :
                Globals.Assert(false);
                break;
            }

            return null;
        }

        public void PlayFinchSoundWithPositionP1P2(int soundId, float volume, CGPoint inPos)
        {
            float offscreenDistance;
            if (inPos.y < game.scrollPosition.y) {
                offscreenDistance = game.scrollPosition.y - inPos.y;
            }
            else if (inPos.y > (game.scrollPosition.y + mapObjectAppearDistance)) {
                offscreenDistance = inPos.y - (game.scrollPosition.y + mapObjectAppearDistance);
            }
            else {
                (SoundEngine.Instance()).PlayFinchSoundP1(soundId, volume);
                return;
            }

            float vol = 1.0f - Utilities.GetRatioP1P2(offscreenDistance, 0.0f, 300.0f);
            if (vol > 0.0f) {
                (SoundEngine.Instance()).PlayFinchSoundP1(soundId, volume * vol);
            }

        }

        public void ConvertAndAddSubtextureToAtlasP1P2P3P4P5(int oldBaseVal, List<int> inArray, int minx, int miny, int maxx, int maxy)
        {
            inArray.Add((int)(minx * oldBaseVal));
            inArray.Add((int)(miny * oldBaseVal));
            inArray.Add((int)(maxx * oldBaseVal));
            inArray.Add((int)(maxy * oldBaseVal));
        }

        public void AddSubtextureToAtlasP1P2P3P4(List<int> inArray, int minx, int miny, int maxx, int maxy)
        {
            inArray.Add((int)(minx));
            inArray.Add((int)(miny));
            inArray.Add((int)(maxx));
            inArray.Add((int)(maxy));
        }

        public void AddRowOfSubtexturesP1P2P3P4P5(List<int> inArray, int num, int width, int height, int startX, int startY)
        {
            for (int i = 0; i < num; i++) {
                this.AddSubtextureToAtlasP1P2P3P4(inArray, startX + (width * i), startY, startX + (width * (i + 1)), startY + height);
            }

        }

        public void AddColumnOfSubtexturesP1P2P3P4P5(List<int> inArray, int num, int width, int height, int startX, int startY)
        {
            for (int i = 0; i < num; i++) {
                this.AddSubtextureToAtlasP1P2P3P4(inArray, startX, startY + (height * i), startX + width, startY + (height * (i + 1)));
            }

        }

        public void SetupFontSubTexturesArial(List<int> inArray)
        {
            inArray.Clear();//RemoveAllObjects();
            inArray.Add((int)(38));
            inArray.Add((int)(26));
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 13, 1, 1, 0, 0);
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 9, 1, 1, 0, 1);
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, 2, 1, 9, 1);
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 2, 1, 1, 11, 1);
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, 1, 1, 0, 2);
        }

        public void SetupFontSubTextures(List<int> inArray)
        {
            inArray.Clear();//RemoveAllObjects();
            inArray.Add((int)(1));
            inArray.Add((int)(34));
            float kWidth;
            float kHeight;
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)) 
			{
                kWidth = 68.0f;
                kHeight = 74.0f;
            }
            else {
                kWidth = 34.0f;
                kHeight = 36.0f;
            }

            float letterX = 0.0f;
            for (int i = 0; i < 7; i++) {
                this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)kWidth, (int)kHeight, (int)letterX, 0);
                letterX += kWidth;
            }

            float widthH = 38.0f;
            float widthM = 68.0f;
            float widthI = 30.0f;
            float widthExclamation = 17.0f;
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)) 
			{
                widthH *= 2.0f;
                widthM *= 2.0f;
                widthI *= 2.0f;
                widthExclamation *= 2.0f;
            }

            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)widthH, (int)kHeight, (int)letterX, 0);
            letterX += widthH;
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)widthI, (int)kHeight, (int)letterX, 0);
            letterX += widthI;
            for (int i = 0; i < 3; i++) {
                this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)kWidth, (int)kHeight, (int)letterX, 0);
                letterX += kWidth;
            }

            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)widthM, (int)kHeight, (int)letterX, 0);
            letterX += widthM;
            letterX = 0.0f;
            for (int i = 0; i < 9; i++) {
                this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)kWidth, (int)kHeight, (int)letterX, (int)kHeight);
                letterX += kWidth;
            }

            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)widthM, (int)kHeight, (int)letterX, (int)kHeight);
            letterX += widthM;
            for (int i = 0; i < 3; i++) {
                this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)kWidth, (int)kHeight, (int)letterX, (int)kHeight);
                letterX += kWidth;
            }

            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)widthExclamation, (int)kHeight, (int)letterX, (int)kHeight);
            letterX += widthExclamation;
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)widthExclamation, (int)kHeight, (int)letterX, (int)kHeight);
            letterX -= widthExclamation;
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 1, (int)kWidth, (int)kHeight, (int)letterX, 0);
            
            int extraForLastRow = 4;
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)) 
			{
				extraForLastRow = 14;
			}
            
            this.AddRowOfSubtexturesP1P2P3P4P5(inArray, 5, (int)kWidth, (int)kHeight + extraForLastRow, 0, extraForLastRow + ((int)kHeight * 2));
        }

        public void SetupAtlasFromPListP1P2(bool doubleSize, List<int> gridArray, string inName)
        {
            this.SetupAtlasFromPListP1P2P3(doubleSize, gridArray, inName, false);
        }

        public void SetupAtlasFromPListP1P2P3 (bool doubleSize, List<int> gridArray, string inName, bool fromDropbox)
				{
						// UnityEngine.Debug.Log (string.Format("Setting Up Atlas from PList {0}",inName));
			
						string useName;
						bool iPhone4 = false;
						if (Globals.useRetina) {
								string temp = System.IO.Path.GetFileNameWithoutExtension (inName);
								useName = String.Format ("%@@2x~iphone_plist", temp);
								iPhone4 = true;
						}

						if (!iPhone4) {
								useName = inName;//.Copy();
						}
			
						Dictionary<string, object> plistDict = new Dictionary<string, object> ();
						Dictionary<string, object> plistDictValues = new Dictionary<string, object> ();

						gridArray.Clear ();//RemoveAllObjects();
						gridArray.Add ((int)(1));
						gridArray.Add ((int)(0));
			
			
//            NSDictionary frames;
						//    string resourcesPath = ((NSBundle.MainBundle()).ResourcePath()).StringByAppendingPathComponent(useName);
						//    NSDictionary dict = new NSDictionary(resourcesPath);
						//   frames = dict.ObjectForKey("frames");
			
						plistDict = (Dictionary<string, object>)Plist.readPlist (Globals.g_main.GetFolderPrefixForTextureResolution() + inName + Globals.g_main.GetSuffixForTextureResolution());
			
						Dictionary<string, string> result = new Dictionary<string, string> ();
						//		foreach (KeyValuePair<string, object> kvp in plistDict) 
						//		{
						//			result.Add(kvp.Key, Convert.ToString(kvp.Value));
						//			//Debug.Log(kvp.Key + "and " + Convert.ToString(kvp.Value));
						//		}
			
						plistDictValues = (Dictionary<string, object>)plistDict ["frames"];
			
//			List<KeyValuePair<string, object>> myList = plistDictValues.ToList();
			
						List<string> rossList = new List<string> ();
			
						foreach (KeyValuePair<string, object> kvp in plistDictValues) {
								rossList.Add (kvp.Key);
						}			
						
						rossList.Sort ();

			int fileIndex = 0;

						foreach (string s in rossList) {
						
			fileIndex = 0;

			foreach (KeyValuePair<string, object> kvp in plistDictValues) 
			{
					if (s == kvp.Key)
					{

				Dictionary<string, object> tempDict = new Dictionary<string, object>();
				tempDict = (Dictionary<string, object>)plistDictValues[kvp.Key];

				string tx = (string)tempDict["spritePosX"];
				string ty = (string)tempDict["spritePosY"];
				string tw = (string)tempDict["spriteSizeX"];
				string th = (string)tempDict["spriteSizeY"];
				
				int ix = Convert.ToInt32(tx);
				int iy = Convert.ToInt32(ty);
				int iw = Convert.ToInt32(tw);
				int ih = Convert.ToInt32(th);

				CGPoint spriteSize = Utilities.CGPointMake(iw, ih);
                CGPoint spriteOrigin = Utilities.CGPointMake(ix, iy);
                this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, (int) spriteSize.x, (int) spriteSize.y, (int) spriteOrigin.x, (int) spriteOrigin.y);
					}

						fileIndex++;
			}
						

						}


			//(
//		        delegate(KeyValuePair<string, string> firstPair,
		 //       KeyValuePair<string, string> nextPair)
		   //     {
		     //       return firstPair.Value.CompareTo(nextPair.Value);
		      //  }
		    //);
			
			//plistDictValues = plistDict.Values;
			
//			int ted = plistDict.Values;
//			int ross = 0;

			gridArray[1] = (int)fileIndex;
			
//            gridArray.ReplaceObjectAtIndexWithObject(1, (int)(fileIndex));
			
			int billb = 6;	
			
 /*           NSArray thing = frames.AllKeys();
            NSArray alphabeticList = null;//thing.SortedArrayUsingSelector(@selector (localizedCaseInsensitiveCompare:));
            int fileIndex = 0;
            foreach (int key in frames) {
                string keyString = alphabeticList.ObjectAtIndex(fileIndex);
                NSDictionary sheepy = frames.ObjectForKey(keyString);
                fileIndex++;
                string posXString = sheepy.ObjectForKey("spritePosX");
                string posYString = sheepy.ObjectForKey("spritePosY");
                string sizeXs = sheepy.ObjectForKey("spriteSizeX");
                string sizeYs = sheepy.ObjectForKey("spriteSizeY");
                float posX = posXString.FloatValue();
                float posY = posYString.FloatValue();
                float sizeX = sizeXs.FloatValue();
                float sizeY = sizeYs.FloatValue();
                if (false) {
                    posX /= 2.0f;
                    posY /= 2.0f;
                    sizeX /= 2.0f;
                    sizeY /= 2.0f;
                }

                CGPoint spriteSize = Utilities.CGPointMake(sizeX, sizeY);
                CGPoint spriteOrigin = Utilities.CGPointMake(posX, posY);
                this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, (int) spriteSize.x, (int) spriteSize.y, (int) spriteOrigin.x, (int) spriteOrigin.y);
            }
            gridArray.ReplaceObjectAtIndexWithObject(1, (int)(fileIndex));*/
            
        }

        public void SetupAtlases ()
				{
						List<int> gridArray = new List<int> ();// = new List<int>(0);
						
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High))
			{
								gridArray.Add ((int)(32));
						} else {
								gridArray.Add ((int)(16));
						}

						gridArray.Add ((int)(31));
						int index = 0;
						for (int y = 0; y < 4; y++) {
								for (int x = 0; x < 8; x++) {
										if ((y < 3) || (x < 6)) {
												this.AddSubtextureToAtlasP1P2P3P4 (gridArray, x, y, x + 1, y + 1);
												index++;
										}

								}

						}

						this.AddSubtextureToAtlasP1P2P3P4 (gridArray, 6, 3, 8, 4);

//            if (!g_myViewController.IsLoadingAtlas((int) AtlasType.kAtlas_RainbowParticles)) {
						atlas [(int)AtlasType.kAtlas_RainbowParticles] = new ZAtlas ((int)AtlasType.kAtlas_RainbowParticles);
						atlas [(int)AtlasType.kAtlas_RainbowParticles].initAtlasWithString (this, true, 16, 16, gridArray, "RainbowSparklesNoRot.png");
						//          }

						this.SetupFontSubTextures (gridArray);
						atlas [(int)AtlasType.kAtlas_FontColours] = new ZAtlas ((int)AtlasType.kAtlas_FontColours);
						atlas [(int)AtlasType.kAtlas_FontColours].initAtlasWithString (this, true, 64, 64, gridArray, "AtlasFleeceLightningFont.png");

		/*				#if DEBUG_DRAW_RACING_LINE
                gridArray.Clear();//RemoveAllObjects();
                gridArray.Add((int)(1));
                gridArray.Add((int)(2));
                this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 16, 16, 0, 0);
                this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 16, 16, 16, 0);
                atlas[(int) AtlasType.kAtlas_Debug] = new ZAtlas(); atlas[(int) AtlasType.kAtlas_Huh].initAtlasWithString(this, false, 0, 0, gridArray, "AtlasDebug.png");
					//	#endif*/

	            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)) 
			{
								atlas [(int)AtlasType.kAtlas_FontNumbers] = new ZAtlas ((int)AtlasType.kAtlas_FontNumbers); 
								atlas [(int)AtlasType.kAtlas_FontNumbers].initAtlasWithString (this, true, 84, 68, null, "AtlasNumbers.png");
						} else {
								atlas [(int)AtlasType.kAtlas_FontNumbers] = new ZAtlas ((int)AtlasType.kAtlas_FontNumbers);
								atlas [(int)AtlasType.kAtlas_FontNumbers].initAtlasWithString (this, true, 42, 34, null, "AtlasNumbers.png");
						}

            gridArray.Clear();//RemoveAllObjects();
            gridArray.Add((int)(1));
            gridArray.Add((int)(4));
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)) 
			{
                this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 3, 96, 128, 0, 0);
                this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 224, 128, 284, 0);
            }
            else {
                this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 3, 48, 64, 0, 0);
                this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 112, 64, 142, 0);
            }

            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)) 
			{
				atlas[(int) AtlasType.kAtlas_321] = new ZAtlas((int) AtlasType.kAtlas_321); 
				atlas[(int) AtlasType.kAtlas_321].initAtlasWithString(this, true, 0, 0, gridArray, "Atlas321.png", (int) Texture2D_RossPixelFormat.t_RGBA8888);
			}
	        else
			{
				atlas[(int) AtlasType.kAtlas_321] = new ZAtlas((int) AtlasType.kAtlas_321); 
				atlas[(int) AtlasType.kAtlas_321].initAtlasWithString(this, true, 0, 0, gridArray, "Atlas321.png");
			}

            this.SetupAtlasFromPListP1P2(false, gridArray, "HudAtlas_plist");
            atlas[(int) AtlasType.kAtlas_Hud] = new ZAtlas((int) AtlasType.kAtlas_Hud); 
			atlas[(int) AtlasType.kAtlas_Hud].initAtlasWithString(this, true, 0, 0, gridArray, "HudAtlas.png", (int) Texture2D_RossPixelFormat.t_RGBA8888);
		}

        public void LoadRaceLoseAtlas()
        {
            List<int> gridArray = new List<int>();// = new List<int>(0);
            if (atlas[(int) AtlasType.kAtlas_RaceLose] == null) {
                this.ReleaseAtlasIfLoaded(AtlasType.kAtlas_RaceWin);
                this.SetupAtlasFromPListP1P2(false, gridArray, "RaceLoseAtlas_plist");
                atlas[(int) AtlasType.kAtlas_RaceLose] = new ZAtlas((int) AtlasType.kAtlas_RaceLose); 
				atlas[(int) AtlasType.kAtlas_RaceLose].initAtlasWithString(this, true, 0, 0, gridArray, "RaceLoseAtlas.png", (int) Texture2D_RossPixelFormat.t_RGBA8888);
            }

        }

        public void ReleaseRaceWinAtlas()
        {
            this.ReleaseAtlasIfLoaded(AtlasType.kAtlas_AppleSign);
        }

        public void ReleaseRaceLoseAtlas()
        {
            this.ReleaseAtlasIfLoaded(AtlasType.kAtlas_RaceLose);
        }

        public void LoadRaceWinAtlas()
        {
            List<int> gridArray = new List<int>();// = new List<int>(0);
            if (atlas[(int) AtlasType.kAtlas_ShowLevelAndTip] == null) {
                this.ReleaseAtlasIfLoaded(AtlasType.kAtlas_RaceLose);
                this.SetupAtlasFromPListP1P2(false, gridArray, "ShowLevelAndTipAtlas_plist");
                atlas[(int) AtlasType.kAtlas_ShowLevelAndTip] = new ZAtlas((int) AtlasType.kAtlas_ShowLevelAndTip); 
				atlas[(int) AtlasType.kAtlas_ShowLevelAndTip].initAtlasWithString(this, true, 0, 0, gridArray, "ShowLevelAndTipAtlas.png", (int) Texture2D_RossPixelFormat.
                  t_RGBA8888);
            }

            if (atlas[(int) AtlasType.kAtlas_AppleSign] == null) {
                this.SetupAtlasFromPListP1P2(false, gridArray, "AppleSignAtlas_plist");
                atlas[(int) AtlasType.kAtlas_AppleSign] = new ZAtlas((int) AtlasType.kAtlas_AppleSign); 
				atlas[(int) AtlasType.kAtlas_AppleSign].initAtlasWithString(this, true, 0, 0, gridArray, "AppleSignAtlas.png", (int) Texture2D_RossPixelFormat.t_RGBA8888);
            }

        }

        public void LoadPlayersAtlas()
        {
            Globals.Assert(atlas[(int) AtlasType.kAtlas_PiggyAnims] == null);
            List<int> gridArray = new List<int>();// = new List<int>(0);
            this.SetupAtlasFromPListP1P2(false, gridArray, "PiggyAnims_plist");
            atlas[(int) AtlasType.kAtlas_PiggyAnims] = new ZAtlas((int) AtlasType.kAtlas_PiggyAnims); 
			atlas[(int) AtlasType.kAtlas_PiggyAnims].initAtlasWithString(this, true, 0, 0, gridArray, "PiggyAnims.png", (int) Texture2D_RossPixelFormat.t_RGBA8888);
        }

        public void RemovePlayersAtlas()
        {
            Globals.Assert(atlas[(int) AtlasType.kAtlas_PiggyAnims] != null);
            atlas[(int) AtlasType.kAtlas_PiggyAnims].Dealloc();
            atlas[(int) AtlasType.kAtlas_PiggyAnims] = null;
        }

        public void LoadedPlistFromDropbox()
        {

            #if DROPBOX_ENABLED
                if (g_myViewController.GetLastLoadedFileInfo().atlasId == -1) {
                    NSDictionary dict = new NSDictionary(g_myViewController.TempFilePathPlist());
                    NSDictionary assetList = dict.ObjectForKey("AssetsToLoad");
                    int numAssetsToLoad = 0;
                    for (int i = 0; i < assetList.Count(); i++) {
                        numAssetsToLoad++;
                        string keyString = String.Format("Asset%d", i + 1);
                        g_myViewController.SetAssetToLoadIdP1(numAssetsToLoad, (assetList.ObjectForKey(keyString)).IntValue());
                    }

                    g_myViewController.SetNumFilesToGet(numAssetsToLoad + 1);
                    dropBoxVariables.SheepRunAnim_NumTurnAnims = (dict.ObjectForKey("SheepRun_NumTurnAnims")).IntValue();
                    dropBoxVariables.SheepRunAnim_NumRunAnims = (dict.ObjectForKey("SheepRun_NumRunAnims")).IntValue();
                    dropBoxVariables.SheepRunAnim_Bounces = (dict.ObjectForKey("SheepRun_AnimBounces")).IntValue();
                    dropBoxVariables.SheepRunAnim_DistancePerAnimFrame = (dict.ObjectForKey("SheepRun_DistancePerAnimFrame")).FloatValue();
                }

            #endif

        }

        public void LoadedAtlasFromDropbox()
        {


        }

        public void ReleaseCurrentSceneAtlases()
        {
            switch ((SceneType)currentlyLoadedScene) {
            case SceneType.kSceneGrass :
                this.ReleaseCountryAtlases();
                break;
            case SceneType.kSceneMud :
                this.ReleaseFarmAtlases();
                break;
            case SceneType.kSceneDesert :
                this.ReleaseDesertAtlases();
                break;
            case SceneType.kSceneIce :
                this.ReleaseIceAtlases();
                break;
            case SceneType.kSceneMoon :
                this.ReleaseMoonAtlases();
                break;
            case (SceneType)(-1) :
                break;
            default :
                Globals.Assert(false);
                break;
            }

        }

        public void ReleaseFrontEndAtlases()
        {
            Globals.Assert(atlas[(int) AtlasType.kAtlas_FrontendAndShowlevel] != null);
           
			atlas[(int) AtlasType.kAtlas_FrontendAndShowlevel].Dealloc();
            atlas[(int) AtlasType.kAtlas_FrontendAndShowlevel] = null;
        }

        public void ReleaseShowLevelAtlases()
        {
            if (atlas[(int) AtlasType.kAtlas_ShowLevelAndTip] != null) {
                atlas[(int) AtlasType.kAtlas_ShowLevelAndTip].Dealloc();
                atlas[(int) AtlasType.kAtlas_ShowLevelAndTip] = null;
            }

            if (atlas[(int) AtlasType.kAtlas_AppleSign] != null) {
                atlas[(int) AtlasType.kAtlas_AppleSign].Dealloc();
                atlas[(int) AtlasType.kAtlas_AppleSign] = null;
            }

        }

        public void ReleaseAtlasIfLoaded(AtlasType inType)
        {
            if (atlas[(int)inType] != null) {
                atlas[(int)inType].Dealloc();
                atlas[(int)inType] = null;
            }

        }

        public int GetIPadSubTexture(int normalST)
        {
						if (!Globals.useIPadBackScreens) {
                return normalST;
            }

            switch (normalST) {
            case (int)Enum6.kSSH_BackBar :
                return (int)Enum6.kSSH_BackBar_iPad;
            case (int)World.Enum4.kHU_PauseBar :
                return (int)World.Enum4.kHU_PauseBar_Ipad;
            default :
                break;
            }

            return -1;
        }

        public void LoadShowLevelAtlases()
        {
            List<int> gridArray = new List<int>();// = new List<int>(0);
            if (atlas[(int) AtlasType.kAtlas_ShowLevelAndTip] == null) {
                this.SetupAtlasFromPListP1P2(false, gridArray, "ShowLevelAndTipAtlas_plist");
                atlas[(int) AtlasType.kAtlas_ShowLevelAndTip] = new ZAtlas((int) AtlasType.kAtlas_ShowLevelAndTip); 
                atlas[(int) AtlasType.kAtlas_ShowLevelAndTip].initAtlasWithString(this, true, 0, 0, gridArray, "ShowLevelAndTipAtlas.png", (int) Texture2D_RossPixelFormat.
                  t_RGBA8888);
            }

            if (atlas[(int) AtlasType.kAtlas_AppleSign] == null) {
                this.SetupAtlasFromPListP1P2(false, gridArray, "AppleSignAtlas_plist");
                atlas[(int) AtlasType.kAtlas_AppleSign] = new ZAtlas((int) AtlasType.kAtlas_AppleSign);
				atlas[(int) AtlasType.kAtlas_AppleSign].initAtlasWithString(this, true, 0, 0, gridArray, "AppleSignAtlas.png", (int) Texture2D_RossPixelFormat.t_RGBA8888);
            }

        }

        public void ReleaseAnotherPiggyAtlases()
        {
            this.ReleaseAtlasIfLoaded(AtlasType.kAtlas_AnotherPiggy);
        }

        public void ReleaseFeelGoodAtlas()
        {
            this.ReleaseAtlasIfLoaded(AtlasType.kAtlas_FeelGood);
        }

        public void LoadFeelGoodAtlas()
        {
            if (atlas[(int) AtlasType.kAtlas_FeelGood] == null) {
                List<int> gridArray = new List<int>();// = new List<int>(0);
                this.SetupAtlasFromPListP1P2(false, gridArray, "FeelGoodAtlas_plist");
                atlas[(int) AtlasType.kAtlas_FeelGood] = new ZAtlas((int) AtlasType.kAtlas_FeelGood); atlas[(int) AtlasType.kAtlas_FeelGood].initAtlasWithString(this, true, 0, 0, gridArray, "FeelGoodAtlas.png", (int) Texture2D_RossPixelFormat.t_RGBA8888);
            }

        }

        public void LoadAnotherPiggyAtlases()
        {
            if (atlas[(int) AtlasType.kAtlas_AnotherPiggy] == null) {
                List<int> gridArray = new List<int>();// = new List<int>(0);
                this.SetupAtlasFromPListP1P2(false, gridArray, "AnotherPiggy_plist");
                atlas[(int) AtlasType.kAtlas_AnotherPiggy] = new ZAtlas((int) AtlasType.kAtlas_AnotherPiggy); atlas[(int) AtlasType.kAtlas_AnotherPiggy].initAtlasWithString(this, true, 0, 0, gridArray, "AnotherPiggy.png", (int) Texture2D_RossPixelFormat.t_RGBA8888)
                  ;
            }

        }

        public void LoadFrontEndAtlases()
        {
            List<int> gridArray = new List<int>();// = new List<int>(0);
            Globals.Assert(atlas[(int) AtlasType.kAtlas_FrontendAndShowlevel] == null);
            this.SetupAtlasFromPListP1P2(true, gridArray, "ButtonsAtlas_plist");
            atlas[(int) AtlasType.kAtlas_FrontendAndShowlevel] = new ZAtlas((int) AtlasType.kAtlas_FrontendAndShowlevel); atlas[(int) AtlasType.kAtlas_FrontendAndShowlevel].initAtlasWithString(this, true, 0, 0, gridArray, "ButtonsAtlas4.png", (int) Texture2D_RossPixelFormat.
              t_RGBA8888);
//            atlas[(int) AtlasType.kAtlas_FrontendAndShowlevel] = new ZAtlas((int) AtlasType.kAtlas_FrontendAndShowlevel); atlas[(int) AtlasType.kAtlas_FrontendAndShowlevel].initAtlasWithString(this, true, 0, 0, gridArray, "ButtonsAtlas.png", (int) Texture2D_RossPixelFormat.
  //            t_RGBA8888);
        }

        public void ReleaseAtlasForLevelBuilder_Ross()
        {
          	atlas[(int) AtlasType.kAtlas_CommonLevelBuilder_Ross].Dealloc();
            atlas[(int) AtlasType.kAtlas_CommonLevelBuilder_Ross] = null;
        }

        public void LoadAtlasForLevelBuilder_Ross()
        {
            int tileSize = 64;
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High))
			{
				tileSize = 128;
			}
            Globals.Assert(atlas[(int) AtlasType.kAtlas_CommonLevelBuilder_Ross] == null);
            atlas[(int) AtlasType.kAtlas_CommonLevelBuilder_Ross] = new ZAtlas((int) AtlasType.kAtlas_CommonLevelBuilder_Ross); 
			atlas[(int) AtlasType.kAtlas_CommonLevelBuilder_Ross].initAtlasWithString(this, false, tileSize, tileSize, null, "AtlasCommonLevelBuilder.png", (int)
              Texture2D_RossPixelFormat.t_RGB565);
        }

        public void LoadSceneAtlases()
        {
            if ((game.lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                if (currentlyLoadedScene != (int) SceneType.kSceneGrass) {
                    this.ReleaseCurrentSceneAtlases();
                    this.LoadCountryAtlases();
                    currentlyLoadedScene = (int)SceneType.kSceneGrass;
					game.tileMap.SetupAtlas((int)AtlasType.kAtlas_GrassTiles);
					game.SetGameThingsAtlas (Globals.g_world.GetAtlas (AtlasType.kAtlas_GameThingsGrass));
				}

            }
            else if ((game.lBuilder).currentScene == (int) SceneType.kSceneDesert) {
                if (currentlyLoadedScene != (int) SceneType.kSceneDesert) {
                    this.ReleaseCurrentSceneAtlases();
                    this.LoadDesertAtlases();
                    currentlyLoadedScene = (int)SceneType.kSceneDesert;
                }

            }
            else if ((game.lBuilder).currentScene == (int) SceneType.kSceneIce) {
                if (currentlyLoadedScene != (int) SceneType.kSceneIce) {
                    this.ReleaseCurrentSceneAtlases();
                    this.LoadIceAtlases();
                    currentlyLoadedScene = (int)SceneType.kSceneIce;
                }

            }
            else if ((game.lBuilder).currentScene == (int) SceneType.kSceneMoon) {
                if (currentlyLoadedScene != (int) SceneType.kSceneMoon) {
                    this.ReleaseCurrentSceneAtlases();
                    this.LoadMoonAtlases();
                    currentlyLoadedScene = (int)SceneType.kSceneMoon;
                }

            }
            else {
                if (currentlyLoadedScene != (int) SceneType.kSceneMud) {
                    this.ReleaseCurrentSceneAtlases();
                    this.LoadMudAtlases();
                    currentlyLoadedScene = (int)SceneType.kSceneMud;
					game.tileMap.SetupAtlas((int)AtlasType.kAtlas_MudTiles);
					game.SetGameThingsAtlas (Globals.g_world.GetAtlas (AtlasType.kAtlas_GameThingsMud));					
				}

            }
			
//			ParticleSystemRoss.Instance().SetupAtlasDetails();

        }

        public void ReleaseCountryAtlases()
        {
            const int kNumToRelease = 4;
            int[] releaseList = new int [4]
            {(int) AtlasType.kAtlas_ParticlesScene, (int) AtlasType.kAtlas_GrassTiles, (int) AtlasType.kAtlas_GrassSpriteTiles, (int) AtlasType.
                  kAtlas_GameThingsGrass,};
            for (int i = 0; i < kNumToRelease; i++) {

                #if !TESTING_REMOVE_ATL
                    Globals.Assert(atlas[releaseList[i]] != null);
                #endif

                atlas[releaseList[i]].Dealloc();
                atlas[releaseList[i]] = null;
            }

        }

        public void LoadCountryAtlases()
        {
            List<int> gridArray = new List<int>();// = new List<int>(0);

            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High))
				gridArray.Add((int)(64));
            else gridArray.Add((int)(32));

            gridArray.Add((int)(24));
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 0, 2, 2);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 2, 0, 4, 2);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 4, 0, 6, 2);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 6, 0, 8, 2);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 2, 2, 4);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 2, 2, 3, 3);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 6, 2, 8);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 2, 6, 4, 8);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 4, 2, 6, 4);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 6, 2, 8, 4);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 4, 2, 5);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 5, 2, 6);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 2, 4, 4, 5);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 2, 5, 4, 6);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 4, 4, 6, 5);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 4, 5, 5, 6);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 5, 5, 6, 6);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 6, 4, 8, 6);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 2, 3, 3, 4);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 3, 2, 4, 3);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 4, 6, 6, 8);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 6, 6, 8, 8);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 2, 1, 0, 8);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 1, 1, 2, 8);

			Globals.Assert(atlas[(int) AtlasType.kAtlas_ParticlesScene] == null);
            atlas[(int) AtlasType.kAtlas_ParticlesScene] = new ZAtlas((int) AtlasType.kAtlas_ParticlesScene); 
			atlas[(int) AtlasType.kAtlas_ParticlesScene].initAtlasWithString(this, true, 16, 16, gridArray, "AtlasParticles.png");

            int tileSize = 64;
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High))
			{
				tileSize = 128;
			}
                Globals.Assert(atlas[(int) AtlasType.kAtlas_GrassTiles] == null);
                atlas[(int) AtlasType.kAtlas_GrassTiles] = new ZAtlas((int) AtlasType.kAtlas_GrassTiles); atlas[(int) AtlasType.kAtlas_GrassTiles].initAtlasWithString(this, true, tileSize, tileSize, null, "AtlasGrass.png", -1, Texture2D_RossPixelFormat.
                  t_RGB565);

            gridArray.Clear();//RemoveAllObjects();
            gridArray.Add((int)(1));
            gridArray.Add((int)(64));
            for (int i = 0; i < 8; i++) this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 8, 51, 51, 0, 0 + (51 * i));

            Globals.Assert(atlas[(int) AtlasType.kAtlas_GrassSpriteTiles] == null);
            atlas[(int) AtlasType.kAtlas_GrassSpriteTiles] = new ZAtlas((int) AtlasType.kAtlas_GrassSpriteTiles); atlas[(int) AtlasType.kAtlas_GrassSpriteTiles].initAtlasWithString(this, true, tileSize, tileSize, null, "AtlasGrass_SpriteTiles.png", (int)
              Texture2D_RossPixelFormat.t_RGBA8888);
                Globals.Assert(atlas[(int) AtlasType.kAtlas_GameThingsGrass] == null);
                this.SetupAtlasFromPListP1P2(false, gridArray, "GameThingsGrass_plist");
                atlas[(int) AtlasType.kAtlas_GameThingsGrass] = new ZAtlas((int) AtlasType.kAtlas_GameThingsGrass); atlas[(int) AtlasType.kAtlas_GameThingsGrass].initAtlasWithString(this, true, 0, 0, gridArray, "GameThingsGrass.png", (int) Texture2D_RossPixelFormat.
                  t_RGBA8888);

            gridArray.Clear();//RemoveAllObjects();
            gridArray.Add((int)(32));
            gridArray.Add((int)(10));
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 0, 2, 1);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 2, 0, 4, 2);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 3, 2, 4);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 2, 1, 1, 0, 0);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 2, 1, 1, 0, 1);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 3, 1, 1, 0, 2);
        }

        public void ReleaseIceAtlases()
        {


        }

        public void ReleaseDesertAtlases()
        {

        }

        public void ReleaseMoonAtlases()
        {
/*            const int kNumToRelease = 5;
            AtlasType[] releaseList = new AtlasType [5]
            {(int) AtlasType.kAtlas_ParticlesScene, (int) AtlasType.kAtlas_MoonTiles, (int) AtlasType.kAtlas_GameThingsGrassDesert, (int) AtlasType.
                  kAtlas_ShadowsFarm, (int) AtlasType.kAtlas_Footsteps};
            for (int i = 0; i < kNumToRelease; i++) {

                #if !TESTING_REMOVE_ATL
                    Globals.Assert(atlas[releaseList[i]] != null);
                #endif

//                atlas[releaseList[i]];
                atlas[releaseList[i]] = null;
            }*/

        }

        public void ReleaseFarmAtlases()
        {
            const int kNumToRelease = 4;
            int[] releaseList = new int [4]
            {(int) AtlasType.kAtlas_ParticlesScene, (int) AtlasType.kAtlas_MudTiles, (int) AtlasType.kAtlas_MudSpriteTiles, (int) AtlasType.
                  kAtlas_GameThingsMud,};
            for (int i = 0; i < kNumToRelease; i++) {

                #if !TESTING_REMOVE_ATL
                    Globals.Assert(atlas[releaseList[i]] != null);
                #endif

                    atlas[releaseList[i]].Dealloc();
                    atlas[releaseList[i]] = null;

            }

        }

        public void LoadMudAtlases()
        {
            List<int> gridArray = new List<int>();// = new List<int>(0);
            gridArray.Clear();//RemoveAllObjects();

            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High))
				gridArray.Add((int)(2));
            else gridArray.Add((int)(1));

            gridArray.Add((int)(26));
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 0, 0, 2, 2);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 2, 0, 4, 2);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 4, 0, 6, 2);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 6, 0, 8, 2);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 0, 2, 2, 4);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 0, 6, 1, 7);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 1, 6, 3, 7);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 0, 7, 2, 8);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 2, 7, 4, 8);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 6, 2, 8, 4);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 0, 4, 2, 5);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 0, 5, 2, 6);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 2, 4, 4, 5);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 2, 5, 4, 6);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 4, 4, 6, 5);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 4, 5, 5, 6);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 5, 5, 6, 6);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 6, 4, 8, 6);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 2, 2, 3, 3);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 2, 3, 4, 4);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 4, 3, 6, 4);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 4, 2, 6, 3);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 4, 6, 5, 7);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 5, 6, 6, 8);
            this.ConvertAndAddSubtextureToAtlasP1P2P3P4P5(32, gridArray, 6, 6, 8, 8);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 128, 240, 144, 256);
                Globals.Assert(atlas[(int) AtlasType.kAtlas_ParticlesScene] == null);
                atlas[(int) AtlasType.kAtlas_ParticlesScene] = new ZAtlas((int) AtlasType.kAtlas_ParticlesScene); atlas[(int) AtlasType.kAtlas_ParticlesScene].initAtlasWithString(this, true, 32, 32, gridArray, "AtlasParticlesFarm.png");

            int tileSize = 64;
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High))
				tileSize = 128;

                Globals.Assert(atlas[(int) AtlasType.kAtlas_MudTiles] == null);
                atlas[(int) AtlasType.kAtlas_MudTiles] = new ZAtlas((int) AtlasType.kAtlas_MudTiles); atlas[(int) AtlasType.kAtlas_MudTiles].initAtlasWithString(this, true, tileSize, tileSize, null, "AtlasMud.png", -1,Texture2D_RossPixelFormat.t_RGB565);

            Globals.Assert(atlas[(int) AtlasType.kAtlas_MudSpriteTiles] == null);
            atlas[(int) AtlasType.kAtlas_MudSpriteTiles] = new ZAtlas((int) AtlasType.kAtlas_MudSpriteTiles); atlas[(int) AtlasType.kAtlas_MudSpriteTiles].initAtlasWithString(this, true, tileSize, tileSize, null, "AtlasMud_SpriteTiles.png", (int)
              Texture2D_RossPixelFormat.t_RGBA8888);
            gridArray.Clear();//RemoveAllObjects();
            gridArray.Add((int)(1));
            gridArray.Add((int)(67));
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 0, 126, 108);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 96, 0, 144, 108);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 158, 0, 320, 128);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 112, 60, 168);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 60, 112, 140, 192);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 140, 128, 248, 230);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 256, 128, 384, 256);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 256, 128, 384, 256);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 320, 0, 430, 100);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 430, 0, 512, 100);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 5, 64, 56, 0, 272);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 5, 64, 56, 0, 328);
            this.AddColumnOfSubtexturesP1P2P3P4P5(gridArray, 8, 16, 16, 96, 384);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 392, 188, 500, 256);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 392, 108, 500, 188);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 320, 252, 448, 332);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 448, 256, 512, 320);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 384, 96, 448);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 448, 96, 512);
            this.AddColumnOfSubtexturesP1P2P3P4P5(gridArray, 8, 16, 16, 112, 384);
            this.AddColumnOfSubtexturesP1P2P3P4P5(gridArray, 6, 16, 16, 128, 384);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 320, 332, 448, 384);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 5, 64, 128, 192, 384);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 176, 64, 224);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 64, 192, 112, 236);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 7, 32, 36, 0, 236);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 32, 64, 448, 320);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 160, 384, 192, 416);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 192, 128, 0, 512);
            this.AddRowOfSubtexturesP1P2P3P4P5(gridArray, 1, 104, 128, 192, 512);

			Globals.Assert(atlas[(int) AtlasType.kAtlas_GameThingsMud] == null);
                this.SetupAtlasFromPListP1P2(false, gridArray, "GameThingsMud_plist");
                atlas[(int) AtlasType.kAtlas_GameThingsMud] = new ZAtlas((int) AtlasType.kAtlas_GameThingsMud); atlas[(int) AtlasType.kAtlas_GameThingsMud].initAtlasWithString(this, true, 0, 0, gridArray, "GameThingsMud.png");

            gridArray.Clear();//RemoveAllObjects();
            gridArray.Add((int)(1));
            gridArray.Add((int)(7));
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 0, 32, 64);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 64, 0, 128, 64);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 96, 64, 128);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 0, 64, 16, 80);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 16, 64, 32, 80);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 32, 0, 64, 64);
            this.AddSubtextureToAtlasP1P2P3P4(gridArray, 64, 64, 96, 128);
        }

        public void LoadDesertAtlases()
        {
        }

        public void LoadIceAtlases()
        {
        }

        public void LoadMoonAtlases()
        {
        }

        public void SecondInitialisation()
        {
        }

        public void UpdateWorldPreloadingSounds()
        {
			//this.SetNewWorldState(WorldState.e_FrontEnd);
			

            if (true) {

                if (Constants.SKIP_FRONTEND)
				{
                    haveReachedTitleYet = true;
                    audio.CheckAndLoadCommonGameEffects();
                    frontEnd.ReleaseTemporaryTextures();
                    game.ReleaseFrontEndTextures();
                    this.ReleaseFrontEndAtlases();
                    this.LoadShowLevelAtlases();

                    if (Constants.START_LB_LEVEL)
					{
                        if (Constants.STARTING_LEVEL < 8) {
                            frontEnd.SetSelectedStage((int) SceneType.kSceneGrass);
                            (game.lBuilder).SetCurrentScene((int) SceneType.kSceneGrass);
                        }
                        else {
                            frontEnd.SetSelectedStage((int) SceneType.kSceneMud);
                            (game.lBuilder).SetCurrentScene((int) SceneType.kSceneMud);
                        }

                        if ((game.lBuilder).currentScene == (int) SceneType.kSceneGrass) game.SetGameThingsAtlas(atlas[(int) AtlasType.
                          kAtlas_GameThingsGrass]);
                        else {
                            game.SetGameThingsAtlas(atlas[(int) AtlasType.kAtlas_GameThingsMud]);
                        }

					}

                    ((Globals.g_world.frontEnd).profile).CheckAndLoadCustomLevelInformation();

                    if (Constants.START_LB)
					{
                        game.SetInLevelBuilder(true);
                        game.SetupLevelBuilder_Ross();
					}

                    this.SetNewWorldState(WorldState.e_InGame);
				}else{

                  //  this.SetNewWorldState(WorldState.e_TitleScreens);
                    this.SetNewWorldState(WorldState.e_FrontEnd);
                
				}

            }

        }

        public void PractiseSavingThing()
        {
        }


				public void SetScreenEdgeValues()
				{
						float xScreenIPhoneWidth = Screen.height * 0.66666666f;
						float offscreenWidth = xScreenIPhoneWidth - Screen.width;
						float ratio = (offscreenWidth * 0.5f) / xScreenIPhoneWidth;

						if (offscreenWidth > 0.0f)
						{
								xScreenEdge = ratio * 320.0f;
						}
						else
								xScreenEdge = 0.0f;

						xScreenEdgeReal = ratio * 320.0f;

//						xScreenEdge = 24.78874f;
//						xScreenEdgeReal = 24.78874f;
							
				}

        public void FirstInitialisation()
        {
//			Globals.g_main.loadADCQueue.InitialiseLoad();
			
						//wondering if Screen.height and Screen.width are wrong in Start() (!)
						this.SetScreenEdgeValues();

            string value;
//            value = (UIDevice.CurrentDevice()).Model();
  //          value = (UIDevice.CurrentDevice()).name;
    //        value = (UIDevice.CurrentDevice()).SystemName();
      //      value = (UIDevice.CurrentDevice()).SystemVersion();
			deviceType = (int) UIDevicePlatform.UIDevice3GiPhone;//(UIDevice.CurrentDevice()).PlatformType();
            if ((deviceType == (int) UIDevicePlatform.UIDevice1GiPhone) || (deviceType == (int) UIDevicePlatform.UIDevice1GiPod) || (deviceType == (int)
              UIDevicePlatform.UIDevice3GiPhone)) {
                artLevel = 0;
            }
            else {
                artLevel = 1;
            }

            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High))
				artLevel = 2;
			
			artLevel = 2;
			
            if (!Constants.NOT_FINAL_VERSION)
			{

	           if (Constants.TESTING_HOWYOULIKEMENOW)
                    Globals.Assert(false);

                if (Constants.UNLOCK_ALL_LEVELS) {
                    Globals.Assert(false);
                }

                if (Constants.SKIP_FRONTEND)
			{
                    Globals.Assert(false);
			}

                #if DEBUG_MESSAGES
                    Globals.Assert(false);
                #endif

                #if UNLOCK_ALL_BUTTON_IN_OPTIONS
                    Globals.Assert(false);
                #endif

			}

            string fontFile = "fleece_fnt";
            string useName = "";
            bool iPhone4 = false;
            if (Globals.useRetina) 
			{
				string temp =  System.IO.Path.GetFileNameWithoutExtension(fontFile);
                useName = String.Format("%@@2x~iphone.fnt", temp);
                iPhone4 = true;
            }

            if (!iPhone4) {
				useName = fontFile;//.Copy();
            }
			
	//		guiFont = (Font) Resources.Load( "Arial") as Font;			
			
            font.ParseConfigFile(useName);
            game.LoadStartupTextures();
            (game.lBuilder).FirstInit();
            (game.tileMap).FirstInit();
            game.LoadFrontEndTextures();
            this.LoadFrontEndAtlases();
			this.SetupPullTab();
			this.SetupPullTabs();
            this.LoadShowLevelAtlases();
            frontEnd.FirstInitialisation();
            game.FirstInitialisation();
            (Ztransition.GetTransition()).SetPBackTexture(game.GetTexture((TextureType) TextureType.kTexture_HudLoading));
            (Ztransition.GetTransition()).SetPTexture(game.GetTexture((TextureType) TextureType.kTexture_Whiteout));
            audio.PreloadMusicAndMenuEffects();
            audio.LoadMenuSoundEffects();
            this.SetNewWorldState(WorldState.e_PreloadingSounds);
            FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
            qInfo.position = Utilities.CGPointMake(160, 240);
            qInfo.boxDimensions = Utilities.CGPointMake(200, 200);
            qInfo.backdropTexture = frontEnd.GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_QueryBackdrop);
            qInfo.noButton = null;
            qInfo.yesButton = (Globals.g_world.frontEnd).GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_QueryOk);
            qInfo.useActualText = true;
            qInfo.dimTexture = game.GetTexture((TextureType) TextureType.kTextureDimOverlay);
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                qInfo.theInfo1 = "Dein Zeit wurde\n";
                qInfo.theInfo2 = "auf Facebook\n";
                qInfo.theInfo3 = "veröffentlicht!\n";
            }
            else {
                qInfo.theInfo1 = "your time\n";
                qInfo.theInfo2 = "was posted\n";
                qInfo.theInfo3 = "to facebook!\n";
            }

            qInfo.theInfo4 = "\n";
            qInfo.theInfo5 = "\n";
            qInfo.theInfo6 = "\n";
            qInfo.theInfo7 = "\n";
            facebookQuery = new FrontEndQuery();
            facebookQuery.Initialise(qInfo);
            facebookQuery.SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours))
              ;
            inFirstLoad = false;
            if ((frontEnd.profile).profileInfo.facebookLoggedIn) {
                this.CheckAndAllocateFaceBook();
            }
			
			this.LoadFeelGoodAtlas();
//            this.InitReachability();
			
//			Globals.g_main.loadADCQueue.DoLoad();//LoadADCQueue.LoadType.kLoadFirstInit);
		}

        public void SetupPullTabs()
        {
/*            FrontEnd.ButtonInfo info = new FrontEnd.ButtonInfo();
            info.position = Utilities.CGPointMake(165.0f, 465.0f);
            if (Globals.deviceIPad) {
                info.position.y += 17.0f;
            }

            info.texture = null;
            info.position.y += 1.0f;
            if (Globals.deviceIPad) {
                info.position.y += 21.0f;
            }

            pullTabNews.Initialise(info);
            pullTabNews.SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)Enum9.kFE_NewsTab);
            (pullTabNews.zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
            (pullTabNews.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToBottom);
            pullTabNews.SetClickStyle( ButtonClickStyle.kButtonClick_ThrobAndGo);
            if (Globals.deviceIPad) {
            }
            else {
                if (Globals.deviceIPhone4) {
                    (pullTabNews.zobject).SetShowScale(2.0f);
                }

            }*/

        }

        public void SetupPullTab()
        {
//						pullTabNews
            pullTab = new FrontEndButton(0);
         //   pullTabNews = new FrontEndButton(0);
            FrontEnd.ButtonInfo info = new FrontEnd.ButtonInfo();
//            info.texture = this.LoadTextureP1(false, "pullTab.png");

//						info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureApple);
						info.texture = Globals.g_world.LoadTextureP1(true, "pullTab.png",-1,LoadADCQueue.AssetType.kTextureGame);

								//Globals.g_world.LoadTextureP1(true, "pullTab.png",(int)Enum.pull,LoadADCQueue.AssetType.ktextureFrontEnd);//(Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_MoveButton);


//						buttonTexture[(int)Enum.kButtonTexture_QueryOk] = 


            info.position = Utilities.CGPointMake(165.0f, 465.0f);
            if (Globals.deviceIPad) {
                info.position.y += 17.0f;
                info.position.y += 6.0f;
                info.position.x -= 5.0f;
            }

            if (Globals.deviceIPhone4) {
                info.position.y += 1.0f;
            }

            info.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            pullTab.Initialise(info);
            (pullTab.zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
            (pullTab.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToBottom);
            pullTab.SetClickStyle( ButtonClickStyle.kButtonClick_ThrobAndGo);
            pullTab.SetHeight(48.0f);
            pullTab.SetWidth(100.0f);
						pullTab.actionId = FrontEndActions.kFrontEndAction_ViewScoresLeaderboard;
            if (Globals.deviceIPhone4) {
                (pullTab.zobject).SetShowScale(2.0f);
            }

//            this.SetupPullTabs();
//            leaderboardRank = new FrontEndButton(0);
//            info.texture = null;//this.LoadTextureP1(false, "leaderBoardRank.png");
//            info.position = Utilities.CGPointMake(155.0f, 365.0f);
//            CGPoint rankOffsetForPad = Utilities.CGPointMake(-35.0f, 30.0f);
//            if (Globals.deviceIPad) {
//                info.position.y += rankOffsetForPad.y;
//                info.position.x += rankOffsetForPad.x;
//            }
//
//            info.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
//            leaderboardRank.Initialise(info);
//            (leaderboardRank.zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
//            (leaderboardRank.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
//            (leaderboardRank.zobject).SetThrobSize(0.025f);
//            leaderboardRank.SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
//            rankWord = new FunnyWord();
//            rankWordTop = new FunnyWord();
//            rankScore = new Zscore();
//            FunnyWord.WordInfo wInfo;
//            wInfo.position = Utilities.CGPointMake(info.position.x - 8.0f, info.position.y - 9.0f);
//            wInfo.position.x -= 32.0f;
//            wInfo.position.y += 8.0f;
//            wInfo.scale = 0.43f;
//            wInfo.isCentrePos = true;
//            if (Globals.deviceIPad) {
//                wInfo.position.y += rankOffsetForPad.y - 13.0f;
//                wInfo.position.x += rankOffsetForPad.x + 41.0f;
//            }
//
//            string inWord = "";
//            string stringWord = "";
//            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
//                inWord = "Weltrangliste\n";
//            }
//            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
//                stringWord = "世界排名 -";
//            }
//            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
//                stringWord = "ワールドランキング";
//            }
//            else {
//                inWord = "world ranking\n";
//            }
//
//            rankWord.SetFont(Globals.g_world.font);
//			            rankWord.SetColourAtlas(this.GetAtlas( AtlasType.kAtlas_FontColours));
//			rankWord.InitWithWordOrStringP1P2(wInfo, inWord, stringWord);
//            rankWord.SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
//            rankWord.SetPositionButton(leaderboardRank);
//            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
//                inWord = "top\n";
//            }
//            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
//                stringWord = "前";
//            }
//            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
//                stringWord = "トップ";
//            }
//            else {
//                inWord = "top\n";
//            }
//
//            wInfo.scale = 0.3f;
//            wInfo.position.x += 104.0f;
//            wInfo.position.y += 0.0f;
//            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
//                wInfo.position.x += 2.0f;
//            }
//
//            if (Globals.deviceIPad) {
//            }
//
//            topStartPosition = wInfo.position;
//            rankWordTop.SetFont(Globals.g_world.font);
//			            rankWordTop.SetColourAtlas(this.GetAtlas( AtlasType.kAtlas_FontColours));
//
//			rankWordTop.InitWithWordOrStringP1P2(wInfo, inWord, stringWord);
//            rankWordTop.SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
//            rankWordTop.SetPositionButton(leaderboardRank);
//            Zscore.ZscoreInfo sInfo = new Zscore.ZscoreInfo();
//            sInfo.position = Utilities.CGPointMake(info.position.x + 104.0f, info.position.y - 1.0f);
//            if (Globals.deviceIPad) {
//                sInfo.position.y += rankOffsetForPad.y - 14.0f;
//                sInfo.position.x += rankOffsetForPad.x + 38.0f;
//            }
//
//            scoreStartPosition = sInfo.position;
//            int numDigits = 3;
//            sInfo.numDigits = numDigits;
//			            rankScore.SetFontAtlas(this.GetAtlas( AtlasType.kAtlas_FontNumbers));
//
//			rankScore.Initialise(sInfo);
//            rankScore.SetScale(0.63f);
//            rankScore.ChangeNumDigits(numDigits);
//            rankScore.SetScore(99);
//            rankScore.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
//            rankScore.SetColour(Constants.kColourWhite);
//            rankScore.SetPositionButton(leaderboardRank);
        }

        public void SetAccelerometer(UIAcceleration acceleration)
        {
            game.SetAccelerometer(acceleration);
        }

        public void FinishWorldInGame(WorldState nextState)
        {
            if (nextState == WorldState.e_FrontEnd) 
			{				
				game.StopRender();
				game.hud.StopRenderGameStuff();
				
                this.RemovePlayersAtlas();
                if (frontEnd.exitInfo.goToLevelBuilder_Ross) audio.CheckAndReleaseLevelBuilder_RossEffects();
                else audio.CheckAndReleaseTemporarySoundEffects();
				
				game.DereferenceStuff();
				
                frontEnd.LoadTexturesTemporary(false);
                game.ReleaseCommonGameOnlyTextures();
                game.LoadFrontEndTextures();
                this.LoadFrontEndAtlases();
                this.SetupPullTabs();
                this.LoadShowLevelAtlases();
                frontEnd.SetupAllScreens();
            }

        }

        public void FinishWorldStateFrontEnd()
        {
						
			frontEnd.StopRenderCurrentScreen();
            frontEnd.ReleaseTemporaryTextures();
            game.ReleaseFrontEndTextures();
            this.ReleaseFrontEndAtlases();
          //  frontEnd.ResetNetworkShit();
            frontEnd.ReleaseAllButtons();
            //CrashLandingAppDelegate.Print_free_memory();
        }

        public void SetNewWorldState(WorldState inState)
        {			
						//keep doing this cos it was broke...
						this.SetScreenEdgeValues();

            switch (worldState) {
            case WorldState.e_FrontEnd :
					//Globals.g_main.loadADCQueue.InitialiseLoad();

				this.FinishWorldStateFrontEnd();
                break;
            case WorldState.e_InGame :
                {
//					Globals.g_main.loadADCQueue.InitialiseLoad();
				
                    this.FinishWorldInGame(inState);
                    (ParticleSystemRoss.Instance()).ResetParticleSystemRoss();
                    break;
                }
            default :
                break;
            }

            worldState = inState;
            switch (worldState) {
            case WorldState.e_FrontEnd :
                this.NewStateFrontEnd();
//				Globals.g_main.loadADCQueue.DoLoad();
				break;
            case WorldState.e_InGame :
                this.NewStateInGame();
				//Globals.g_main.loadADCQueue.DoLoad();
				break;
            default :
                break;
            }

            stateTimer = 0;
        }

        public void TestRenderScene()
        {
        }

        public void RenderScene()
        {
			//Debug.Log ("Render");
			
            if (Globals.bInBackground) return;
			
                #if FIXED_RENDER_SCALE
                    renderScale = Constants.FIXED_RENDER_SCALE_VALUE;
                #endif
						
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glLoadIdentity();
			
                drawWidth = 1.0f / renderScale * Globals.g_world.coordinatesWidth;
                drawHeight = 1.0f / renderScale * Globals.g_world.coordinatesHeight;
            
				//glScalef(renderScale * Constants.kScaleForShorts, renderScale * Constants.kScaleForShorts, 0.0f);
                previousRenderScale = renderScale;
                leftDrawEdge = Constants.TRACK_CENTRE_LINE - (drawWidth / 2.0f);
                rightDrawEdge = leftDrawEdge + drawWidth;
                mapObjectAppearDistance = drawHeight + 50.0f;
			
//				Camera gameCam = GameObject.Find(" Main Camera For GUI").camera;
			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				gameCam.orthographicSize = (drawHeight);
			}
			else
			{
				gameCam.orthographicSize = (drawHeight * 0.5f);
			}
//				gameCam.transform.position = 
				
			
			
			Vector3 newPosition = gameCam.transform.position;
			newPosition.y = -(drawHeight - 480.0f) * 0.5f;
			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				newPosition.y *= 2.0f;
			}
			
			gameCam.transform.position = newPosition;
			
            switch (worldState) {
            case WorldState.e_InGame :
                {
                    if (game.inLevelBuilder) game.RenderLevelBuilder_Ross();
                    else game.RenderScene();

                }
                break;
            case WorldState.e_FrontEnd :
                frontEnd.RenderScene();
               // pullTabNews.Render();
                ////glEnableClientState (GL_COLOR_ARRAY);
                (ParticleSystemRoss.Instance()).RenderScene();
                ////glDisableClientState (GL_COLOR_ARRAY);
                break;
            default :
                break;
            }

            Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndRenderParticles] = DateTime.Now.TimeOfDay.Milliseconds;

            #if PARTICLE_PROFILING
                static int testTileCount = -100;
                testTileCount++;
                if ((Globals.g_world.game).gameState == GameState.e_GamePlay) {
                    if (testTileCount >= 10) {
                        static int numCounts = 0;
                        static double timeSum = 0;
                        double timeUpdate = (double) (Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndRenderParticles] - Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartRenderParticles]);
                        timeSum += timeUpdate;
                        numCounts++;
                        double timeAverage = timeSum / (double) numCounts;
                        testTileCount = 0;
                    }

                }

            #endif

            //facebookQuery.Render();
            (Ztransition.GetTransition()).Render();

            #if CHILLINGO_DEMO
                static int flashCount = 0;
                if ((Globals.g_world.game).gameState !=  GameState.e_GamePlay) {
                    flashCount += 1;
                    if (flashCount > 1000) {
                        (game.GetTexture((TextureType) TextureType.kChillDemo)).DrawAtPoint((Utilities.CGPointMake(160.0f, 40.0f)));
                    }

                    if (flashCount > 1100) {
                        flashCount = 0;
                    }

                }

            #endif
			
			unityUIAlert.Render();
			//DebugTexts.Render();
        }

        public void NewStateFrontEnd()
        {
            game.CheckCrystalBackgroundActivity(true);
            frontEnd.InitialiseFrontEnd();
            if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                (SoundEngine.Instance()).AVChangeToTrackP1((int)Audio.Enum2.kSoundEffect_MenuMusicLoop, 0.63f);
            }
            else {
                (SoundEngine.Instance()).AVFadeOutAndStopP1((int)Audio.Enum2.kSoundEffect_Ambience, 0.5f);
            }
            (Globals.g_world.audio).StopBirds();
        }

        public void NewStateInGame()
        {
            if (frontEnd.exitInfo.goToLevelBuilder_Ross) {
                if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                    (SoundEngine.Instance()).AVFadeOutAndStop(0.5f);
                }

            }

            this.LoadPlayersAtlas();
            game.LoadCommonGameOnlyTextures();
            goingToFrontEndFromShowLevel = -1;
            game.StartNewGameFromFrontEnd();
            (ParticleSystemRoss.Instance()).ResetParticleSystemRoss();
        }

        public void ChangeToWorldState(WorldState inState)
        {
            renderScale = 1.0f;
            if ((inState == WorldState.e_InGame) || (inState == WorldState.e_FrontEnd)) {
                (Ztransition.GetTransition()).SetPTexture(game.GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).SetPBackTexture(game.GetTexture((TextureType) TextureType.kTexture_HudLoading));
                (Ztransition.GetTransition()).StartP1P2((int) inState,  TransitionArea.kTransition_World, TransitionType.e_WhirlingShape);
                ((Ztransition.GetTransition()).zobject).SetShowScale(1.0f);
                (((Ztransition.GetTransition()).zobject).GetInterpolation(0)).SetEndValue(0.99f);
            }
            else {
                (Ztransition.GetTransition()).SetPTexture(game.GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) inState, TransitionArea.kTransition_World, TransitionType.e_Fade);
            }

        }

        public void UpdateWorldFrontEnd()
        {
            if (((Ztransition.GetTransition()).inTransition) && ((Ztransition.GetTransition()).area == (int) TransitionArea.kTransition_World)) {
                if ((Ztransition.GetTransition()).nextState != (int) WorldState.e_FrontEnd) {
                    return;
                }

            }

            stateTimer += Constants.kFrameRate;
            if (frontEnd.Update()) {
                if (frontEnd.exitInfo.goToLevelBuilder_Ross) {
                    game.SetInLevelBuilder(true);
                    game.SetupLevelBuilder_Ross();
                }
                else {
                    game.SetInLevelBuilder(false);
                    if (frontEnd.exitInfo.playCustomLevel) {
                    }
                    else {
                    }

                }

                this.ChangeToWorldState(WorldState.e_InGame);
            }

        }

        public void UpdateWorldInGame()
        {
			
			UIAcceleration acc = new UIAcceleration();
			
			acc.x = Input.acceleration.x;
			acc.y = Input.acceleration.y;
			acc.z = Input.acceleration.z;
			
			this.SetAccelerometer(acc);
			
            #if SLOW_THE_GAME_DOWN
                if (!game.lBuilder) {
                    if ((Globals.g_world.game).gameState == GameState.e_GamePlay) {
                        for (int i = 0; i < 100; i++) {
                        }

                    }

                }

            #endif

            if (((Ztransition.GetTransition()).inTransition) && ((Ztransition.GetTransition()).area == (int) TransitionArea.kTransition_World)) {
                this.UpdatePullTab();
                return;
            }

            if (game.inLevelBuilder) {
                if (game.UpdateLevelBuilder_Ross()) {
                    this.ChangeToWorldState(WorldState.e_FrontEnd);
                }

            }
            else {
                if (game.Update()) {
                    this.ChangeToWorldState(WorldState.e_FrontEnd);
                }

            }

        }

       public void HandleTouchP1P2P3 (MyTouch inTouch) //   WhichTouch whichTouch, NSSet touches, UIEvent inEvent, MyEAGLView eaglView)
		{
//			uint heapNow = Profiler.GetMonoHeapSize();
//			uint heapNowUSed = Profiler.GetMonoUsedSize();
			//uint heapNowRun = Profiler.GetRuntimeMemorySize();
			
		//	Debug.Log("Memory ... heapSize:" + heapNow + " used:" + heapNowUSed);
			
			if (unityUIAlert.visible) 
			{
				unityUIAlert.HandleTouch(inTouch);
				return;
			}

			if (Globals.g_consentPopup.isShown)
					return;

            CGPoint pos = Utilities.CGPointMake(inTouch.position.x,inTouch.position.y);  // touch.LocationInView(eaglView);
                
//			pos.x -= 384.0f;
			//pos.y = 480.0f - pos.y;
			
			if (Globals.deviceIPad) {
                    pos.x -= 64.0f;
                    pos.x /= 2.0f;
                    pos.y /= 2.0f;
                }

                if (inTouch.phase == TouchPhase.Began) //  touch.Phase() == UITouchPhaseBegan) {
				{
					frontEnd.HandleTap(pos);
                    if (facebookQuery.state !=  QueryState.e_Active) {
                        //pullTabNews.HandleTap(pos);
                        pullTab.HandleTap(pos);
                      //  leaderboardRank.HandleTap(pos);
                    }
                    else {
                        facebookQuery.HandleTap(pos);
                    }

                }

                game.HandleTapP1(inTouch, pos);
        }

        public void ShowLeaderboardRank(int rank)
        {
            if (rank <= 0) return;

            CGPoint scorePos = scoreStartPosition;
            CGPoint topPos = topStartPosition;
            if (rank < 10) {
                scorePos.x += 7.0f;
                topPos.x += 2.0f;
            }
            else if (rank < 100) {
                scorePos.x += 0.0f;
            }
            else {
                scorePos.x -= 2.0f;
                topPos.x -= 2.0f;
                if (Globals.deviceIPad) {
                    scorePos.x -= 1.0f;
                    topPos.x -= 2.0f;
                }

            }

            rankWordTop.ChangePositionNew(topPos);
            leaderboardRank.Show();
            rankWord.SetLineAtlas(this.GetAtlas( AtlasType.kAtlas_FontLines));
            rankWord.SetColourAtlas(this.GetAtlas( AtlasType.kAtlas_FontColours));
            rankWordTop.SetLineAtlas(this.GetAtlas( AtlasType.kAtlas_FontLines));
            rankWordTop.SetColourAtlas(this.GetAtlas( AtlasType.kAtlas_FontColours));
            if (this.CanConnectToInternet()) {
                (((game.hud).winScreen).GetButton(9)).Show();
            }

            rankWord.Show();
            rankWordTop.Show();
            rankScore.SetPosition(scorePos);
            rankScore.SetScoreAndDigits((float) rank);
            rankScore.Show();
        }

        public void HideLeaderboardRank()
        {
//            (leaderboardRank.zobject).QueueAction( ZobjectAction.nHide);
        }

        public void DisappearLeaderBoardThing()
        {
//            leaderboardRank.Disappear();
//            rankWord.Disappear();
//            rankWordTop.Disappear();
//            rankScore.Disappear();
            pullTab.Disappear();
        }

        public void ShowPullTab()
        {
						#if UNITY_IOS
						Globals.g_guiFrontend.achievementsAndLeaderboards.Show();
						#endif
        }

        public void HidePullTab()
        {
						#if UNITY_IOS
						Globals.g_guiFrontend.achievementsAndLeaderboards.Hide();
#endif
						//            pullTab.Hide();
        }

        public void ShowPullTabNews()
        {
         //   pullTabNews.Show();
        }

        public void HidePullTabNews()
        {
        //    pullTabNews.Hide();
        }

        public void ShowLeaderboardForThisRace()
        {
            string leaderboardId = (frontEnd.profile).GetLeaderboardId(game.playingLevel);
//            NSArray tabs = NSArray.ArrayWithObjects("leaderboards", "achievements", null);
        }

        public void UpdatePullTabNews()
        {
//            if (pullTabNews.Update()) {
//                if (frontEnd.inScreenTimer > 0.1f) {
//                    string leaderboardId = (frontEnd.profile).GetLeaderboardId(game.playingLevel);
//            //        NSArray tabs = NSArray.ArrayWithObjects("news", null);
//                }
//
//            }

        }

        public void UpdatePullTab()
        {
            if (pullTab.Update()) {
                if (game.stateTimer > 0.1f) {
                    this.ShowLeaderboardForThisRace();
                }

            }

//            if (leaderboardRank.Update()) {
//                if (game.stateTimer > 0.1f) {
//                    bool faceBookPressedRank = (((game.hud).winScreen).lastPressedButton == 9);
//                    if (!faceBookPressedRank) {
//                        this.ShowLeaderboardForThisRace();
//                    }
//
//                }
//
//            }

//            rankWord.Update();
//            rankWordTop.Update();
//            rankScore.Update();
        }

        public void RenderPullTab()
        {
            pullTab.Render();
            //leaderboardRank.Render();
            //rankWord.Render();
            //rankWordTop.Render();
            //rankScore.Render();
        }

        public void TestInit()
        {
        }

        public void TestUpdate()
        {
        }
		
		public void OnGUI () {

			unityUIAlert.OnGUI();

/*			GUIStyle style = new GUIStyle();

	//		GUI.skin.font = (Font) Resources.Load( "Fonts/Arial Unicode" );

			style.wordWrap = true;
			style.font = (Font) Resources.Load( "Fonts/ARIALUNI" );
			
			GUI.Box(new Rect(10,10,100,100),"とで加速するんだ！ rosso",style);
			
//					GUI.Button(new Rect(10,0,100,100),"This is an example of a very long text in a small text box ---- oooh yeah let's see what the fuck happens now mother!");	
*/

			if (worldState == WorldState.e_FrontEnd)
				frontEnd.OnGUI();
			else
				game.OnGUI();
		}


				public void ManualUpdate()
        {		
			DebugTexts.StartUpdate();
			
		//	Debug.Log("mats = " + GameObject.FindObjectsOfType(typeof(Material)).Length);			
			
			Globals.renderCounter = 0.0f;
			Globals.renderQueueCounter = 0;
			
			unityUIAlert.Update();
			
            this.UpdateTransition();
            (SoundEngine.Instance()).UpdateSoundEngine();
            switch (worldState) {
            case WorldState.e_PreloadingSounds :
                this.UpdateWorldPreloadingSounds();
                break;
            case WorldState.e_TitleScreens :
                break;
            case WorldState.e_FrontEnd :
                (ParticleSystemRoss.Instance()).UpdateParticleSystemRoss();
                this.UpdateWorldFrontEnd();
                break;
            case WorldState.e_InGame :
                if (game.gameState !=  GameState.e_Paused) 
				{

                    #if PROFILING_OUT
                        Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdateParticles] = DateTime.Now.TimeOfDay.Milliseconds;
                    #endif

                    (ParticleSystemRoss.Instance()).UpdateParticleSystemRoss();

                    #if PROFILING_OUT
                        Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdateParticles] = DateTime.Now.TimeOfDay.Milliseconds;
                    #endif

                }

                this.UpdateWorldInGame();
                break;
            }

            audio.UpdateBirds();
            facebookQuery.Update();
        }

        public void UpdateTransition()
        {
            (Ztransition.GetTransition()).UpdateTransition();
            if (!(Ztransition.GetTransition()).inTransition) return;

            if ((Ztransition.GetTransition()).area != TransitionArea.kTransition_World) return;

            if ((Ztransition.GetTransition()).timeToDoStuff) {
                if (worldState == WorldState.e_InGame) 
				{
                    game.ExitGameStateP1(game.gameState, (GameState)(-1));
                    if (game.inLevelBuilder) {
                        game.ReleaseLevelBuilder_RossTextures();
                        this.ReleaseAtlasForLevelBuilder_Ross();
                    }

                }

                this.SetNewWorldState((WorldState)(Ztransition.GetTransition()).nextState);
            }

        }

        public int GetNumTilesInRow(int whichAtlas)
        {
////            if (atlas[whichAtlas]) {
    //        }

            switch ((AtlasType)whichAtlas) {
            case AtlasType.kAtlas_MudSpriteTiles :
                return 8;
            case AtlasType.kAtlas_GrassSpriteTiles :
                return 8;
            case AtlasType.kAtlas_GrassTiles :
                return 16;
            case AtlasType.kAtlas_MudTiles :
                return 16;
            default :
                Globals.Assert(false);
                return 8;
                break;
            }

        }

        public void FaceBookLogoff()
        {
        }

        public void FaceBookPostTimeP1(float inTime, int inLevel)
        {
/*            inTime *= 100.0f;
            int intTime = (int) inTime;
            float roundedTime = (float) intTime;
            roundedTime /= 100.0f;
            NSMutableDictionary fbArguments = new NSMutableDictionary();
            string levelName;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                levelName = (frontEnd.profile).GetGermanNameWithoutSymbols(inLevel);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                levelName = (frontEnd.profile).GetLevelName_Chinese(inLevel);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                levelName = (frontEnd.profile).GetLevelName_Japanese(inLevel);
            }
            else {
                levelName = (frontEnd.profile).GetLevelNameStringWithoutNewline(inLevel);
            }

            string wallPost;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                wallPost = String.Format(
                  "spielt Shaun the Sheep's Fleece Lightning!\n%.2f Sekunden für das Rennen %d - %@! Kannst du das schlagen?", roundedTime, inLevel + 1,
                  levelName);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                wallPost = String.Format("竞赛%d - ”%@“  %.2f秒。你能打败它么？", inLevel + 1, levelName, roundedTime);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                wallPost = String.Format(
"ロスが『ひつじのショーン‐フリース・ライトニング‐』で遊んでいます！レース%d「%@」で%.2f秒のタイムを出しました！あなた、勝てますか？"
                , inLevel + 1, levelName, roundedTime);
            }
            else {
                wallPost = String.Format("is playing Shaun the Sheep's Fleece Lightning!\n%.2f seconds on race %d - %@Can you beat that?",
                  roundedTime, inLevel + 1, levelName);
            }

            string linkURL = "http://itunes.apple.com/us/app/fleece-lightning/id460905456?mt=8";
            string imgURL = "http://91.223.16.58/greenant/Icon.png";
            fbArguments.SetObjectForKey(wallPost, "message");
            fbArguments.SetObjectForKey(linkURL, "link");
            fbArguments.SetObjectForKey(imgURL, "picture");
            FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                qInfo.theInfo1 = "Dein Zeit wurde\n";
                qInfo.theInfo2 = "auf Facebook\n";
                qInfo.theInfo3 = "veröffentlicht!\n";
            }
            else {
                qInfo.theInfo1 = "your time\n";
                qInfo.theInfo2 = "was posted\n";
                qInfo.theInfo3 = "to facebook!\n";
            }

            qInfo.theInfo4 = "\n";
            qInfo.theInfo5 = "\n";
            qInfo.theInfo6 = "\n";
            qInfo.theInfo7 = "\n";
            facebookQuery.ChangeFunnyWords(qInfo);
            facebookQuery.Show();*/
        }

        public void FaceBookPostAchievement(int achievementId)
        {
/*            if (!this.CanConnectToInternet()) {
                return;
            }

            NSMutableDictionary fbArguments = new NSMutableDictionary();
            string achName = (frontEnd.profile).GetAchievementName(achievementId);
            string achDescription = (frontEnd.profile).GetAchievementDescription(achievementId);
            string wallPost;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) wallPost = String.Format("hat einen Erfolg erzielt - %@!\n%@\n", achName, achDescription);
            else {
                wallPost = String.Format("just achieved \'%@!\'\n%@\n", achName, achDescription);
            }

            string linkURL = "http://itunes.apple.com/us/app/fleece-lightning/id460905456?mt=8";
            string imgURL = "http://91.223.16.58/greenant/Icon.png";
            fbArguments.SetObjectForKey(wallPost, "message");
            fbArguments.SetObjectForKey(linkURL, "link");
            fbArguments.SetObjectForKey(imgURL, "picture");
            */
        }

        public void FaceBookPostRankP1(float inRank, int inLevel)
        {
			/*
            NSMutableDictionary fbArguments = new NSMutableDictionary();
            int intRank = (int) inRank;
            string levelName;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                levelName = (frontEnd.profile).GetGermanNameWithoutSymbols(inLevel);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                levelName = (frontEnd.profile).GetLevelName_Chinese(inLevel);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                levelName = (frontEnd.profile).GetLevelName_Japanese(inLevel);
            }
            else {
                levelName = (frontEnd.profile).GetLevelNameStringWithoutNewline(inLevel);
            }

            string wallPost;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                wallPost = String.Format(
                  "spielt Shaun the Sheep's Fleece Lightning und befindet sich momentan unter den besten %d%% in Rennen %d - %@! Kannst du das schlagen?",
                  intRank, inLevel + 1, levelName);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                wallPost = String.Format(
                  "罗斯在玩Shaun the Sheep's Fleece Lightning并且目前在竞赛%d - ”%@“中排名前%d%% \n你能打败他么？", inLevel + 1,
                  levelName, intRank);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                wallPost = String.Format(
"ロスが『ひつじのショーン‐フリース・ライトニング‐』で遊んでいます。たった今レース%d‐「%@」でトップ%d％にランクインしましたよ！"
                , inLevel + 1, levelName, intRank);
            }
            else {
                wallPost = String.Format(
                  "is playing Shaun the Sheep's Fleece Lightning and is currently ranked in the top %d%% on race %d - %@Can you beat that?", intRank, inLevel +
                  1, levelName);
            }

            string linkURL = "http://itunes.apple.com/us/app/fleece-lightning/id460905456?mt=8";
            string imgURL = "http://91.223.16.58/greenant/Icon.png";
            fbArguments.SetObjectForKey(wallPost, "message");
            fbArguments.SetObjectForKey(linkURL, "link");
            fbArguments.SetObjectForKey(imgURL, "picture");
            FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                qInfo.theInfo1 = "Dein Rang wurde\n";
                qInfo.theInfo2 = "auf Facebook\n";
                qInfo.theInfo3 = "veröffentlicht!\n";
            }
            else {
                qInfo.theInfo1 = "your rank\n";
                qInfo.theInfo2 = "was posted\n";
                qInfo.theInfo3 = "to facebook!\n";
            }

            qInfo.theInfo4 = "\n";
            qInfo.theInfo5 = "\n";
            qInfo.theInfo6 = "\n";
            qInfo.theInfo7 = "\n";
            facebookQuery.ChangeFunnyWords(qInfo);
            facebookQuery.Show();
            */
        }

        public void CheckAndAllocateFaceBook()
        {
            if (false) {
            }

        }

        public void CheckAndLoginToFaceBook()
        {
            fbIsTime = FaceBookThing.kFB_LoggingIn;
            this.CheckAndAllocateFaceBook();
            string message;
            switch (Globals.g_currentLanguage) {
            case World.Enum11.kLanguage_German :
                message = String.Format(
                  "Du bist jetzt bei Facebook angemeldet. Einige Erfolge werden automatisch an deiner Pinnwand veröffentlicht.");
                break;
            case World.Enum11.kLanguage_English :
                message = String.Format("You are now logged in to Facebook. Some achievements will automatically post to your wall.");
                break;
            case World.Enum11.kLanguage_China :
                message = String.Format("你现在已登入Facebook。一些成就会自动发布到你的墙上。");
                break;
            case World.Enum11.kLanguage_Japanese :
                message = String.Format(
               "現在、Facebookにログインされています。一部のトロフィーは自動的にあなたのウォールへと掲示されます。"
                  );
                break;
            default :
                Globals.Assert(false);
                break;
            }

        }

        public void CheckAndInitialiseFaceBook(FaceBookThing isTime)
        {
            fbIsTime = isTime;
            this.CheckAndAllocateFaceBook();
        }

        public void FbDidLogin()
        {
			/*
            NSUserDefaults prefs = NSUserDefaults.StandardUserDefaults();
            prefs.synchronize();
            if (fbIsTime == FaceBookThing.kFB_GettingTime) {
                this.FaceBookPostTimeP1((game.player).FinishTime(), game.playingLevel);
            }
            else if (fbIsTime == FaceBookThing.kFB_GettingRank) {
                float currentRank = rankScore.Score();
                this.FaceBookPostRankP1(currentRank, game.playingLevel);
            }
            else {
                string message;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    message = String.Format(
                      "Du bist jetzt bei Facebook angemeldet. Einige Erfolge werden automatisch an deiner Pinnwand veröffentlicht.");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    message = String.Format("你现在已登入Facebook。一些成就会自动发布到你的墙上。");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    message = String.Format(
               "現在、Facebookにログインされています。一部のトロフィーは自動的にあなたのウォールへと掲示されます。"
                      );
                }
                else {
                    message = String.Format("You are now logged in to Facebook. Some achievements will automatically post to your wall.");
                }

            }

            Profile.ProfileInformation savedInfo = (frontEnd.profile).profileInfo;
            savedInfo.facebookLoggedIn = true;
            (frontEnd.profile).SetProfileInfo(savedInfo);
            (frontEnd.profile).SaveBestTimesAndPrefs();
            */
        }

        public void FbDidNotLogin(bool cancelled)
        {
            string message;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                message = String.Format("Du hast dich nicht bei Facebook angemeldet.");
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                message = String.Format("你没有登入Facebook。");
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                message = String.Format("Facebookにログインしていませんでした。");
            }
            else {
                message = String.Format("You didn't log in to Facebook.");
            }

            if (fbIsTime == FaceBookThing.kFB_LoggingIn) {
                ((frontEnd.GetScreen(FrontEndScreenEnum.kFrontEndScreen_Options)).GetSwitch(4)).SetState( SwitchState.kSwitch_On);
            }
            else if (fbIsTime == FaceBookThing.kFB_GettingTime) {
                (((game.hud).winScreen).GetButton(8)).Show();
            }
            else if (fbIsTime == FaceBookThing.kFB_GettingRank) {
                (((game.hud).winScreen).GetButton(9)).Show();
            }

        }

        public void FbDidLogout()
        {
            string message;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                message = String.Format("Du hast dich von Facebook abgemeldet.");
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                message = String.Format("你现在已登出Facebook。");
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                message = String.Format("現在、Facebookからログアウトされています。");
            }
            else {
                message = String.Format("You are now logged out of Facebook.");
            }

            Profile.ProfileInformation savedInfo = (frontEnd.profile).profileInfo;
            savedInfo.facebookLoggedIn = false;
            (frontEnd.profile).SetProfileInfo(savedInfo);
            (frontEnd.profile).SaveBestTimesAndPrefs();
        }

        public bool CanConnectToInternet()
        {
            return false;//(remoteHostStatus != (int) NetworkStatus.NotReachable);
        }

/*        public void InitReachability()
        {
            reachability = Reachability.ReachabilityForInternetConnection();
            reachability.StartNotifier();
            this.UpdateReachabilityStatus();
        }*/

//        public void HandleNetworkChange(NSNotification notice)
  //      {
    //        this.UpdateReachabilityStatus();
      //  }

        public void UpdateReachabilityStatus()
        {
         /*   remoteHostStatus = reachability.CurrentReachabilityStatus();
            if (remoteHostStatus == (int) NetworkStatus.NotReachable) {
            }
            else if (remoteHostStatus == (int) NetworkStatus.ReachableViaWiFi) {
            }
            else if (remoteHostStatus == (int) NetworkStatus.ReachableViaWWAN) {
            }*/

        }

    }
}
