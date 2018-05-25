using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Default.Namespace
{
    public enum  TextureType {
        kTexture_Invalid = -1,
        kTexture_BoostExplosion,
        kTexture_TrackNormal,
        kTexture_TrackNormalToSmudged,
        kTexture_TrackSmudged,
        kTexture_TrackSmudgedToNormal,
        kTexture_StartingGateShadow,
        kTexture_Rainbow,
        kTexture_BushHalfLeft,
        kTexture_BushHalfRight,
        kTexture_BushHalfLeftBottom,
        kTexture_BushHalfRightBottom,
        kTexture_BushFragment1,
        kTexture_BushFragment2,
        kTexture_GrassUnderBushParting,
        kTexture_BushCrashToPasteAfter,
        kTexture_Footstep1,
        kTexture_Footstep2,
        kTexture_TreeTopPink,
        kTexture_TreeTop,
        kHudTexture_Rosette,
        kHudTexture_SunMoon1,
        kHudTexture_SunMoon2,
        kHudTexture_SunMoon3,
        kHudTexture_SunMoon4,
        kHudTexture_SunMoon5,
        kHudTexture_SunMoon6,
        kHudTexture_Moon,
        kHudTexture_DarkFall,
        kTexture_Cow,
        kTexture_Cow2,
        kTexture_CowShadow,
        kTexture_CowPat,
        kTexture_OhNo_O,
        kTexture_OhNo_h,
        kTexture_OhNo_N,
        kTexture_OhNo_o,
        kTexture_OhNo_exclam,
        kTexture_OhNo_T,
        kTexture_OhNo_s,
        kTexture_OhNo_l,
        kTexture_OhNo_w,
        kTexture_Number0,
        kTexture_Number1,
        kTexture_Number2,
        kTexture_Number3,
        kTexture_Number4,
        kTexture_Number5,
        kTexture_Number6,
        kTexture_Number7,
        kTexture_Number8,
        kTexture_Number9,
        kTexture_NumberPoint,
        kTexture_NumberColon,
        kTexture_HudWordGood,
        kTexture_HudWordGreat,
        kTexture_HudWordTerrific,
        kTexture_HudWordExcellent,
        kTexture_HudWordGold,
        kTexture_ButtonNewBest,
        kTexture_ButtonBest,
        kTexture_ButtonHome,
        kTexture_ButtonRetry,
        kTexture_ButtonNext,
        kTexture_ButtonInfo,
        kTexture_ButtonNextGrey,
        kTexture_ButtonBigCloud,
        kTexture_ButtonLittleCloud,
        kTexture_HowToThumbs,
        kTexture_ButtonHighScores,
        kTexture_ButtonLevelEdit,
        kTexture_ButtonAbout,
        kTexture_ButtonOptions,
        kTexture_HandClosed,
        kTexture_HandOpen,
        kTexture_FlowerBunchWith,
        kTexture_FlowerBunchShadowWith,
        kTexture_FlowerBunchWithout,
        kTexture_FlowerBunchShadowWithout,
        kTexture_FlyingFlower1,
        kTexture_FlyingFlower2,
        kTexture_FlyingFlower3,
        kTexture_FlyingFlower4,
        kTexture_FlyingFlower5,
        kTexture_FlyingFlower6,
        kTexture_FlyingFlower7,
        kTexture_FlyingFlower8,
        kTexture_FlyingFlower9,
        kTexture_FlyingFlower10,
        kTexture_FlyingFlower11,
        kTexture_FlyingFlower12,
        kTexture_FlyingFlower13,
        kTexture_FlyingFlowerShadow1,
        kTexture_FlyingFlowerShadow2,
        kTexture_FlyingFlowerShadow3,
        kTexture_FlyingFlowerShadow4,
        kTexture_FlyingFlowerShadow5,
        kTexture_FlyingFlowerShadow6,
        kTexture_FlyingFlowerShadow7,
        kTexture_WarmOverlay,
        kHudTexture_NextLevelPic,
        kTexture_Whiteout,
        kTexture_LightBall,
        kTexture_LightBeam,
        kTexture_LB_CopyButton,
        kTexture_LB_MoveButton,
        kTexture_PinkBox,
        kTexture_LevelBuilder_RossScreen,
        kTexture_SpeedTrail,
        kTexture_SpeedTrailWhiteStar,
        kTexture_LB_TrashCan,
        kTexture_LB_DeleteAll,
        kTexture_LB_Done,
        kTexture_LB_Left,
        kTexture_LB_Right,
        kTexture_LB_ScrollBar,
        kTexture_LB_Back,
        kTexture_BoostArrowStraightDown1,
        kTexture_BoostArrowStraightDown2,
        kTexture_BoostArrowStraightDown3,
        kTexture_BoostArrowStraightDown4,
        kTexture_BoostArrowStraightDown5,
        kTexture_GateLeft1,
        kTexture_GateLeft2,
        kTexture_GateLeft3,
        kTexture_GateLeft4,
        kTexture_GateLeft5,
        kTexture_GateLeft6,
        kTexture_GateRight1,
        kTexture_GateRight2,
        kTexture_GateRight3,
        kTexture_GateRight4,
        kTexture_GateRight5,
        kTexture_GateRight6,
        kTexture_PiggyHeadFE,
        kTexture_PiggyHead,
        kTexture_SheepyHead,
        kTexture_PiggySpeechBubble,
        kTexture_HudLoading,
        kTexture_TiltTooHigh,
        kHudTexture_SecretLevelUnlocked,
        kGameTexture_RM_SheepIcon,
        kGameTexture_RM_PigIcon,
        kGameTexture_RM_Track,
        kTexture_LBHowTo,
        kChillDemo,
        kTextureSplashTitlePic,
        kTextureTitlePic,
        kTextureApple,
        kTextureAppleWhite,
        kTextureAppleCartTop,
        kTextureAppleCartBottom,
        kTextureAppleCartRabbit,
        kTextureTurnip,
        kTextureTurnipSheep,
        kTextureTurnipSheepShadow,
        kTexture_StarCupStar,
        kTexture_BubbleBack,
        kTexture_WinCork,
        kTexture_WinFade,
        kTextureDimOverlay,
        kTextureBubbleRing,
        kTextureBubbleRingBehind,
        kTexture_DontAddThisMapObjectToPendingList,
        kTexture_FullScreen_ShaunRunning,
        kTexture_FullScreen_ShaunClose,
        kTextureSplashTitlePlaque,
        kTextureSplashTitleSTSChinJap,
        Types
    }
    public enum  PlayerHeight {
        t_Low = 0,
        t_Normal,
        t_High,
        ights
    }
    public enum  GameState {
        e_None_GoToMenu = -1,
        e_NotInGameYet,
        e_GetReady,
        e_TrafficLights,
        e_GamePlay,
        e_ShowResultsLoseTooSlow,
        e_ShowResultsLoseToPiggy,
        e_ShowResultsWin,
        e_Paused,
        e_ShowLevel,
        e_FeelGoodScreen,
        e_AppleCartScreen,
        e_SpeedBoostScreen,
        e_AnotherPiggy
    }
    public enum  TrailState {
        e_ShowingSmudged,
        e_SmudgedToNormal,
        e_Normal,
        e_NormalToSmudged
    }
    public enum  TrafficShowState {
        kShowPhase1,
        kShowPhase2,
        kShowPhase3
    }
    public enum  ListType {
        e_RenderUnderPlayer = 0,
        e_RenderAbovePlayer,
        e_RenderGatesAbovePlayer,
        e_RenderTracks,
        e_RenderTrees,
        e_Shadows,
        Types
    }
    public enum  PlayerType {
        kPlayerSheep = 0,
        kPlayerPig,
        kPlayerOstrich,
        kPlayerPenguin,
        Types
    }
    public enum  GameObjectType {
        kGameObject_FlowerBunches = 0,
        kGameObject_NoGoZones,
        kGameObject_Ponds,
        kGameObject_Rainbows,
        kGameObject_Cows,
        kGameObject_Hedges,
        kGameObject_BoostArrows,
        kGameObject_Buildings,
        kGameObject_HayBale,
        kGameObject_Tractor,
        kGameObject_Chicken,
        kGameObject_CliffPieces,
        kGameObject_Crater,
        kGameObject_StarSpeedUp,
        kGameObject_Flock,
        kGameObject_Waterfall,
        kGameObject_WoodenLog,
        kGameObject_Venus,
        kGameObject_CrossingThing,
        kGameObject_Lion,
        kGameObject_Tree,
        kGameObject_Trampoline,
        Types
    }
    public partial class Game
    {
		public bool isPlayerLow;
		
		bool[,] isDrawn = new bool[3,Constants.MAX_PLAYERS];

//        public UIAlertView rateAlert;
		public SpeedAdjustmentTool speedAdjustmentTool; 
        public StarSpeedUp[] starSpeedUp = new StarSpeedUp[ (int)Enum2.kMaxStarSpeedUps];
        public LevelBuilder_Ross lBuilder;
        public Ramp[] ramp = new Ramp[ (int)Enum2.kMaxRamps];
        public FlowerHead[] flowerHead = new FlowerHead[ (int)Enum2.kMaxFlowerHeads];
        public FlowerBunch[] flowerBunch = new FlowerBunch[ (int)Enum2.kMaxFlowerBunches];
        public Rainbow[] rainbow = new Rainbow[ (int)Enum2.kMaxRainbows];
        public BoostArrow[] boostArrow = new BoostArrow[ (int)Enum2.kMaxBoostArrows];
        public Cow[] cow = new Cow[ (int)Enum2.kMaxCows];
        public Pond[] pond = new Pond[ (int)Enum2.kMaxPonds];
        public CowPat[] cowpat = new CowPat[ (int)Enum2.kMaxCowPats];
        public Tractor[] tractor = new Tractor[ (int)Enum2.kMaxTractors];
        public Chicken[] chicken = new Chicken[ (int)Enum2.kMaxChickens];
        public Waterfall[] waterfall = new Waterfall[ (int)Enum2.kMaxWaterfalls];
        public WoodenLog[] woodenLog = new WoodenLog[ (int)Enum2.kMaxWoodenLogs];
        public Venus[] venus = new Venus[ (int)Enum2.kMaxVenus];
        public Lion[] lion = new Lion[ (int)Enum2.kMaxLions];
        public Hud hud;
        public StoneWall[] stoneWall = new StoneWall[ (int)Enum2.kMaxStoneWalls];
        public TileMap tileMap;
        public Player player;
        public Player[] playerPiggy = new Player[ (int)Enum2.kMaxPiggiesPerLevel];
        public Building[] building = new Building[ (int)Enum2.kMaxBuildings];
        public HayBale[] hayBale = new HayBale[ (int)Enum2.kMaxHayBales];
        public CliffPiece[] cliffPiece = new CliffPiece[ (int)Enum2.kMaxCliffPieces];
        public Crater[] crater = new Crater[ (int)Enum2.kMaxCraters];
        public Flock[] flock = new Flock[ (int)Enum2.kMaxFlocks];
        public CrossingThing[] crossingThing = new CrossingThing[ (int)Enum2.kMaxCrossingThings];
        public ZAtlas gameThingsAtlas;
        public ZAtlas shadowsAtlas;
        public List<int> orderList;
        public List<int> yPosList;
        public int heapNumHeads;
        public Tree[] tree = new Tree[ (int)Enum2.kMaxTrees];
        public Trampoline[] trampoline = new Trampoline[ (int)Enum2.kMaxTrampolines];
        public float desiredRenderScale;
        public float actualRenderScale;
        public PlayerType currentOpponent;
        public float yMinTilt;
        public float yMaxTilt;
        public int[,] pendingListMapObjects = new int[(int)ListType.Types,  (int)Enum2.kMaxMapObjects];
        public int[] nextMapObjectInPendingList = new int[(int)ListType.Types];
        public int[] numMapObjectInPendingList = new int[(int)ListType.Types];
        public bool shownHudYet;
        public bool startedGetLeaderboardPosYet;
        public bool playedWinMusicYet;
        public bool gameMusicStoppedYet;
        public bool savedProfileInfoYet;
        public bool firstTimeInShowLevelSinceMenu;
        int controlTouchLeft;
        int controlTouchRight;
        int controlTouchFinger;
        public Ghost playingGhost;
        public Ghost recordingGhost;
        public Ghost[] ghostPiggy = new Ghost[ (int)Enum2.kMaxPiggiesPerLevel];
        public int playingCustom;
        public int playingLevel;
        public int lastPlayedLevel;
        public NoGoZone[] noGoZone = new NoGoZone[ (int)Enum2.kMaxNoGoZones];
        public int[] startUpdateId = new int[(int)GameObjectType.Types];
        public int[] endUpdateId = new int[(int)GameObjectType.Types];
        public int[] numGameObject = new int[(int)GameObjectType.Types];
        public List<int>[] yPositionListForStart = new List<int>[(int)GameObjectType.Types];
        public List<int>[] updateOrder = new List<int>[(int)GameObjectType.Types];
        public int numRamps;
        public int nextParticleEffect;
        public int numStoneWalls;
        public int numCowPats;
        public int numFlowerHeads;
        public bool goToNextLevel;
        public int numPiggyRaces;
        public bool tiltMuchTooBig;
        public bool nextLevelAllowed;
        public bool flagStartPause;
        public bool aboveRoofThisFrame;
        public CGPoint onMapPosition;
        public CGPoint scrollPosition;
        public CGPoint prevScrollPosition;
        public float animateRoll;
        public int animateIndex;
        public CGPoint tiltDirection;
        public CGPoint prevOffset;
        public CGPoint prevOffset2;
        public float xSlope;
        public int cameraFollowWhichPiggy;
        public int afterFeelGoodAction;
        public int currentlyLoadedScene;
        public int currentlyLoadedLevel;
        public int currentlyLoadedPlayer;
        public int currentlyLoadedOpponent;
        public int numApplesBeforeRace;
        public int numApplesAfterRace;
        public bool withinMapObjectUpdate;
        public bool shownPullTabYet;
        public float timeToUse;
        public float timeOfLastOink;
        public float timeOfLastTreeBumpSound;
        public GameState gameState;
        public float stateTimer;
        public float lightYPos;
        public float lightXPos;
        public float lightYVelocity;
        public float avgTiltSpeedY;
        public float avgTiltSpeedTotalY;
        public float currentTiltSpeedY;
        public float[] tiltSpeedY = new float[20];
        public int whichTiltSpeed;
        public float prevAccelerationY;
        public float finishYPos;
        public float timeLimit;
        public float raceTimer;
        public float gameTimer;
        public bool newBestTimeRecorded;
        public bool inLevelBuilder;
        public bool hitClosedGate;
        public int[] usedListHead = new int[(int)ListType.Types];
        public int freeListHead;
        public MapObject[] mapObject = new MapObject[ (int)Enum2.kMaxMapObjects];
        public float distanceSinceTrackDown;
        public TrailState trailState;
        public int lastPiggyIndex;
        public int numAllowedPastLine;
        public int whichPigLoaded;
        public int whichSheepGhostLoaded;
        public int whichSheepGhostLoadedSet;
        public float trafficY;
        public int numTrafBonce;
        public CGPoint handPos;
        public int numRivers;
        public FlowerCliff[] river = new FlowerCliff[ (int)Enum2.kMaxRivers];
        public Hedge[] hedge = new Hedge[ (int)Enum2.kMaxHedges];
        public float[] gateWidth = new float[ (int)Enum2.kMaxHedges];
        public CGPoint[] gatePos = new CGPoint[ (int)Enum2.kMaxHedges];
        public Texture2D_Ross[] textureObject = new Texture2D_Ross[(int)TextureType.Types];
        public Billboard[] textureObjectBillboard = new Billboard[(int)TextureType.Types];
        public int justUnlockedCup;
        public int getReadyPhase;
        public int getReadyNumberIndex;
        public int startFromPiggy;
        public float kMinTiltUsed;
        public float kMaxTiltUsed;
        public float phaseTimer;
        public StartingGate[] startingGate = new StartingGate[ (int)Enum2.kMaxStartingGates];
        public bool goBackToFrontEnd;
        public bool flagSaveProfileInfo;
        public float yScrollVelocity;
        public float yScrollEndStart;
        public float levelBuilderScroll;
        public int numStartingGates;
        public bool reactivatedCrystalBackground;
        public bool flushedAt3seconds;
        public bool multiplayerInSync;
        public bool serverSentMessage;
        public float timeToStart;
        public double raceStartedAtTime;
        public int numPlayersOnScreen;
        public int my_Rank;
        public float rainbowUpdateBackDist;
        public float buildingUpdateBackDist;
        public FingerControl fingerControl;

        Game g_game;
        const float kShiftSpritesY = -24.0f;
        const float kShiftSpritesX = -0.0f;
        const float kTractorJumpHeight = 30.0f;

		public const float kClifffDepth = 40;	
		const float kWaterfallDepth = 25;	
		const float kYOffForFallInMud = 26.0f;
		const float kFlowerBunchJumpHeight = 33.0f;	
		const float kRiverDropLength = 10; //Kind of the shadow dropping down the cliff
		//const float kRiverRaiseLength = 120; //river bank on other side....
		const float kRiverUpSlopeEnd = 30.0f;
		const float kTimeBetweenPigsGoAndYouGo = 0.4f;

		const float kRenderScaleMin = 0.535f;
		const float kRenderScaleRange = 0.465f;	//0.86(max) - 0.535

		const float kRenderScaleMinIPhone5 = 0.47f;
		const float kRenderScaleRangeIPhone5 = 0.465f;	//0.86(max) - 0.535


				//const float kRenderScaleMin = 0.6f;
		//const float kRenderScaleRange = 0.4f;	//0.86(max) - 0.535

		const float kRenderScaleMax = 1.0f;	//kRenderScaleMin+kRenderScaleRange



        //extern const float Game.kClifffDepth;
        public enum Enum2 {
            kMaxStoneWalls = 30,
            kMaxCows = 45,
            kMaxCowPats = 35,
            kMaxRainbows = 40,
            kMaxBoostArrows = 25,
            kMaxMapObjects = 600,
            kMaxStartingGates = 4,
            kMaxPonds = 170,
            kMaxRamps = 16,
            kMaxFlowerHeads = 50,
            kMaxFlowerBunches = 150,
            kMaxNoGoZones = 600,
            kMaxRivers = 10,
            kMaxBuildings = 85,
            kMaxHedges = 60,
            kMaxHayBales = 120,
            kMaxTractors = 40,
            kMaxOilDrums = 80,
            kMaxChickens = 40,
            kMaxWaterfalls = 40,
            kMaxWoodenLogs = 50,
            kMaxLions = 100,
            kMaxVenus = 20,
            kMaxCliffPieces = 50,
            kNumHighScoreSets = 3,
            kMaxPiggiesPerLevel = 3,
            kMaxStarSpeedUps = 40,
            kMaxCraters = 100,
            kMaxFlocks = 5,
            kMaxCrossingThings = 60,
            kMaxTrees = 100,
            kMaxTrampolines = 20,
        };
        public enum Enum1 {
            kAfterFeelGoodToMenu = 0,
            kAfterFeelGoodRetry,
            kAfterFeelGoodNextLevel,
            kAfterFeelGoodShowLevel,
            kAfterFeelGoodGetReady,
        };
        public float[] playerHeightMax = new float[(int)PlayerHeight.ights];
        public float[] playerHeightMin = new float[(int)PlayerHeight.ights];

        public class SpeedAdjustmentTool{
            public float[] lastTrySpeed = new float[600];
            public float[] lastTryTime = new float[600];
            public float[] desiredTime = new float[600];
            public short whichRunForThisTrack;
            public float closestTimeDiffForThisTrack;
            public float closestTimeDiffForThisTrack_SpeedUsed;
            public float closestTimeDiffForThisTrack_TimeGot;
        };

		public int LastPlayedLevel
        {
            get;
            set;
        }

        public Player Player
        {
            get;
            set;
        }

        public GameState GameState
        {
            get;
            set;
        }

        public CGPoint ScrollPosition
        {
            get;
            set;
        }

        public float RaceTimer
        {
            get;
            set;
        }

        public float GameTimer
        {
            get;
            set;
        }

        public float TimeLimit
        {
            get;
            set;
        }

        public float StateTimer
        {
            get;
            set;
        }

        public bool NewBestTimeRecorded
        {
            get;
            set;
        }

        public float FinishYPos
        {
            get;
            set;
        }

//        public bool LevelBuilder_Ross
  //      {
    //        get;
      //      set;
        //}

        public TileMap TileMap
        {
            get;
            set;
        }

//        public LevelBuilder_Ross LBuilder
  //      {
    //        get;
      //      set;
        //}

        public bool TiltMuchTooBig
        {
            get;
            set;
        }

        public int LastPiggyIndex
        {
            get;
            set;
        }

        public ZAtlas GameThingsAtlas
        {
            get;
            set;
        }

        public bool FlagStartPause
        {
            get;
            set;
        }

        public bool FirstTimeInShowLevelSinceMenu
        {
            get;
            set;
        }

        public int StartFromPiggy
        {
            get;
            set;
        }

        public Hud Hud
        {
            get;
            set;
        }

        public int PlayingLevel
        {
            get;
            set;
        }

        public float TimeToStart
        {
            get;
            set;
        }

        public double RaceStartedAtTime
        {
            get;
            set;
        }

        public int NumPlayersOnScreen
        {
            get;
            set;
        }

        public PlayerType CurrentOpponent
        {
            get;
            set;
        }

        public bool ShownHudYet
        {
            get;
            set;
        }

        public FingerControl FingerControl
        {
            get;
            set;
        }

        public int NumApplesBeforeRace
        {
            get;
            set;
        }


public void SetPlayer(Player inThing) {player = inThing;}////@property(readwrite,assign) Player* player;
public void SetGameState(GameState inThing) {gameState = inThing;}///@property(readwrite,assign) GameState gameState;
public void SetScrollPosition(CGPoint inThing) {scrollPosition = inThing;}///@property(readwrite,assign) CGPoint scrollPosition;
public void SetLastPiggyIndex(int inThing) {lastPiggyIndex = inThing;}///@property(readwrite,assign) int lastPiggyIndex;
public void SetTimeLimit(float inThing) {timeLimit = inThing;}///@property(readwrite,assign) float timeLimit;
public void SetRaceTimer(float inThing) {raceTimer = inThing;}///@property(readwrite,assign) float raceTimer;
public void SetGameTimer(float inThing) {gameTimer = inThing;}///@property(readwrite,assign) float gameTimer;
public void SetStateTimer(float inThing) {stateTimer = inThing;}///@property(readwrite,assign) float stateTimer;
public void SetNewBestTimeRecorded(bool inThing) {newBestTimeRecorded = inThing;}///@property(readwrite,assign) bool newBestTimeRecorded;
public void SetInLevelBuilder(bool inThing) {inLevelBuilder = inThing;}///@property(readwrite,assign) bool levelBuilder;
public void SetFinishYPos(float inThing) {finishYPos = inThing;}///@property(readwrite,assign) float finishYPos;	
public void SetTileMap(TileMap inThing) {tileMap = inThing;}////@property(readwrite,assign) TileMap* tileMap;
//public void SetLBuilder(LevelBuilder_Ross inThing) {lBuilder = inThing;}////@property(readwrite,assign) LevelBuilder_Ross* lBuilder;
//public void SetGhostPiggy(Ghost inThing) {ghostPiggy = inThing;}////@property(readwrite,assign) Ghost* ghostPiggy;
public void SetTiltMuchTooBig(bool inThing) {tiltMuchTooBig = inThing;}///@property(readwrite,assign) bool tiltMuchTooBig;
public void SetGameThingsAtlas(ZAtlas inThing) {gameThingsAtlas = inThing;}////@property(readwrite,assign) ZAtlas* gameThingsAtlas;
public void SetFlagStartPause(bool inThing) {flagStartPause = inThing;}///@property(readwrite,assign) bool flagStartPause;
public void SetFirstTimeInShowLevelSinceMenu(bool inThing) {firstTimeInShowLevelSinceMenu = inThing;}///@property(readwrite,assign) bool firstTimeInShowLevelSinceMenu;
public void SetStartFromPiggy(int inThing) {startFromPiggy = inThing;}///@property(readwrite,assign) int startFromPiggy;
public void SetHud(Hud inThing) {hud = inThing;}////@property(readwrite,assign) Hud* hud;
public void SetPlayingLevel(int inThing) {playingLevel = inThing;}///@property(readwrite,assign) int playingLevel;
public void SetTimeToStart(float inThing) {timeToStart = inThing;}///@property(readwrite,assign) float timeToStart;
public void SetRaceStartedAtTime(double inThing) {raceStartedAtTime = inThing;}///@property(readwrite,assign) double raceStartedAtTime;
public void SetNumPlayersOnScreen(int inThing) {numPlayersOnScreen = inThing;}///@property(readwrite,assign) int numPlayersOnScreen;
public void SetCurrentOpponent(PlayerType inThing) {currentOpponent = inThing;}///@property(readwrite,assign) PlayerType currentOpponent;
public void SetShownHudYet(bool inThing) {shownHudYet = inThing;}///@property(readwrite,assign) bool shownHudYet;
public void SetFingerControl(FingerControl inThing) {fingerControl = inThing;}////@property(readwrite,assign) FingerControl* fingerControl;
public void SetLastPlayedLevel(int inThing) {lastPlayedLevel = inThing;}///@property(readwrite,assign) int lastPlayedLevel;
public void SetNumApplesBeforeRace(int inThing) {numApplesBeforeRace = inThing;}///@property(readwrite,assign) int numApplesBeforeRace;

      //  @synthesize outputTileInfo;
        public float GetStateTimer()
        {
            return stateTimer;
        }

        public CGPoint GetScrollPosition()
        {
            return scrollPosition;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public CGPoint GetTiltDirection()
        {
            return tiltDirection;
        }

        public Texture2D_Ross GetTexture(TextureType inType)
        {
            Globals.Assert(inType < TextureType.Types);
            return textureObject[(int)inType];
        }

        public Game()
        {
            //if (!base.init()) return null;

            Globals.Assert((int)BoostArrow.Enum.kBAMaxPlayers == (int)Rainbow.Enum.kRAMaxPlayers);
            for (int i = 0; i < (int) TextureType.Types; i++) {
                textureObject[i] = null;
            }

            cameraFollowWhichPiggy = Constants.CAMERA_FOLLOW_WHICH_PIGGY;
            fingerControl = new FingerControl();
            my_Rank = -1;
            startFromPiggy = 0;
            currentlyLoadedScene = -1;
            currentlyLoadedLevel = -1;
            currentlyLoadedPlayer = -1;
            justUnlockedCup = -1;
            //CrashLandingAppDelegate.Print_free_memory();
            lastPlayedLevel = -1;
            newBestTimeRecorded = false;
            lBuilder = new LevelBuilder_Ross();
            gameState = GameState.e_NotInGameYet;
            g_game = this;
            player = new Player();
            for (int i = 0; i <  (int)Enum2.kMaxPiggiesPerLevel; i++) {
                playerPiggy[i] = new Player();
                ghostPiggy[i] = new Ghost();
                (playerPiggy[i]).SetPlayerId(i + 1);
            }

            player.SetPlayerId(0);
           // Globals.g_main.RenderLoadingBar();
            tileMap = new TileMap();
           // Globals.g_main.RenderLoadingBar();
            flagStartPause = false;
            whichSheepGhostLoaded = -1;
            whichPigLoaded = -1;
            gameThingsAtlas = null;
            withinMapObjectUpdate = false;
            timeLimit = 500.0f;
           for (int i = 0; i < (int) GameObjectType.Types; i++) {
           
				updateOrder[i] = new List<int>(0);
               yPositionListForStart[i] = new List<int>(0);
            }

            playingGhost = new Ghost();
            Globals.Assert( (int)Enum2.kNumHighScoreSets == (int) BestTimeSet.eSets);
            recordingGhost = new Ghost();
            hud = new Hud();
           // Globals.g_main.RenderLoadingBar();
            for (int i = 0; i <  (int)Enum2.kMaxHedges; i++) hedge[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxRainbows; i++) rainbow[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxStarSpeedUps; i++) starSpeedUp[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxCraters; i++) crater[i] = null;

          //  Globals.g_main.RenderLoadingBar();
            for (int i = 0; i <  (int)Enum2.kMaxStartingGates; i++) startingGate[i] = new StartingGate();

            for (int i = 0; i <  (int)Enum2.kMaxRamps; i++) ramp[i] = new Ramp();

            for (int i = 0; i <  (int)Enum2.kMaxFlowerBunches; i++) flowerBunch[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxBoostArrows; i++) boostArrow[i] = null;

        //    Globals.g_main.RenderLoadingBar();
            
            for (int i = 0; i <  (int)Enum2.kMaxFlowerHeads; i++) 
            	flowerHead[i] = new FlowerHead(i); //  (FlowerHead.Alloc()).MyInit(i);

            for (int i = 0; i <  (int)Enum2.kMaxPonds; i++) pond[i] = null;

          //  Globals.g_main.RenderLoadingBar();
            for (int i = 0; i <  (int)Enum2.kMaxCows; i++) cow[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxCowPats; i++) cowpat[i] = new CowPat();

            for (int i = 0; i <  (int)Enum2.kMaxFlocks; i++) flock[i] = null;

//            Globals.g_main.RenderLoadingBar();
            for (int i = 0; i <  (int)Enum2.kMaxRivers; i++) {
                river[i] = null;//new FlowerCliff();
            }

            for (int i = 0; i <  (int)Enum2.kMaxStoneWalls; i++) stoneWall[i] = new StoneWall();

            for (int i = 0; i <  (int)Enum2.kMaxBuildings; i++) building[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxHayBales; i++) hayBale[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxTractors; i++) tractor[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxWaterfalls; i++) waterfall[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxVenus; i++) venus[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxLions; i++) lion[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxCrossingThings; i++) crossingThing[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxWoodenLogs; i++) woodenLog[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxChickens; i++) chicken[i] = null;

            for (int i = 0; i <  (int)Enum2.kMaxCliffPieces; i++) cliffPiece[i] = null;

            Globals.g_main.RenderLoadingBar();
            orderList = new List<int>(0);
            yPosList = new List<int>(0);
            //CrashLandingAppDelegate.Print_free_memory();
            numPiggyRaces = 0;

            playerHeightMin[(int) PlayerHeight.t_Low] = -1000.0f;
            playerHeightMax[(int) PlayerHeight.t_Low] = -1.0f;
            playerHeightMin[(int) PlayerHeight.t_Normal] = playerHeightMax[(int) PlayerHeight.t_Low];
            playerHeightMax[(int) PlayerHeight.t_Normal] = 20.0f;
            playerHeightMin[(int) PlayerHeight.t_High] = playerHeightMax[(int) PlayerHeight.t_Normal];
            playerHeightMax[(int) PlayerHeight.t_High] = 1000.0f;


            //return this;
        }
        public void SetupPlayersAfterDropbox()
        {
            player.SetupAfterDropbox();
            for (int i = 0; i <  (int)Enum2.kMaxPiggiesPerLevel; i++) {
                (playerPiggy[i]).SetupAfterDropbox();
            }

        }

		public void OnGUI ()
				{
			hud.OnGUI();
				}

        public void Dealloc()
        {
//            if (rateAlert.Visible) {
  //              rateAlert.DismissWithClickedButtonIndexAnimated(-1, false);
    //        }

//            rateAlert = null;
        }

        public Ghost GetGhostPiggy(int which)
        {
            Globals.Assert(which <  (int)Enum2.kMaxPiggiesPerLevel);
            return ghostPiggy[which];
        }

        public Player GetPlayerPiggy(int which)
        {
            Globals.Assert(which <  (int)Enum2.kMaxPiggiesPerLevel);
            return playerPiggy[which];
        }

        public CGPoint GetScreenPosition(CGPoint mapPosition)
        {
            CGPoint outScreenPosition;
            Globals.Assert(Constants.LEVEL_BUILDER_VISIBLE_TILES_WIDTH == 10);
            outScreenPosition.x = mapPosition.x - scrollPosition.x - 32.0f;// - Globals.g_world.leftDrawEdge;


                outScreenPosition.y = (mapPosition.y - scrollPosition.y);
                if (gameState == GameState.e_Paused) {
                }


            return outScreenPosition;
        }

        public void ClearAllBestTimeAndGhostData()
        {
        }

        string GetFilenameForPiggyOrGhostSaveP1P2(int whichPiggy, int inLevel, int ghostSet)
        {
			string name;
           // NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
           // string documentsDirectory = paths.ObjectAtIndex(0);
            //if (!documentsDirectory) {
           // }

            //string name;

 /*           #if CONVERTING_PIGGY_DATA
                int loadLevel;
                if (ghostSet != (int) BestTimeSet.t_Custom) {
                    loadLevel = LevelBuilder_Ross.levelOrder[inLevel];
                }
                else loadLevel = inLevel;

                if (whichPiggy == 0) {
                    name = String.Format("PiggyData{0}.binary.%.2f.gho", loadLevel, raceTimer);
                }
                else {
                    name = String.Format("PiggyData{0}_Pig{0}.binary.%.2f.gho", loadLevel, whichPiggy + 1, raceTimer);
                }

            #else

                #if RACe_AS_PIGGY
                    int loadLevel;
                    if (ghostSet != (int) BestTimeSet.t_Custom) {
                        loadLevel = LevelBuilder_Ross.levelOrder[inLevel];
                    }
                    else {
                        loadLevel = inLevel;
                    }

                    #if RACe_AS_PIGGY_EASY
                        name = String.Format("PiggyData_Easy{0}.binary.gho", loadLevel);
                    #else

                        #if DONT_RECORD_PIGGY_TIMES
                            if (whichPiggy == 0) {
                                name = String.Format("PiggyData{0}.binary.gho", loadLevel);
                            }
                            else {
                                name = String.Format("PiggyData{0}_Pig{1}.binary.gho", loadLevel, whichPiggy + 1);
                            }

                        #else
                            if (whichPiggy == 0) {
                                name = String.Format("PiggyData{0}.binary.%.2f.gho", loadLevel, raceTimer - Constants.kTimeDiffRecordingPiggy);
                            }
                            else {
                                name = String.Format("PiggyData{0}_Pig{1}.binary.%.2f.gho", loadLevel, whichPiggy + 1, raceTimer - Constants.
                                  KTimeDiffRecordingPiggy);
                            }

                        #endif

                    #endif

                #else
                    if (ghostSet == (int) BestTimeSet.t_Custom) name = String.Format("GhostDataCustom_v2{0}.binary.gho", inLevel);
                    else if (ghostSet == (int) BestTimeSet.t_Normal) name = String.Format("GhostData_v2{0}.binary.gho", inLevel);
                    else name = String.Format("GhostDataEasy_v2{0}.binary.gho", inLevel);

                #endif

            #endif*/
			
						//in the interest of my own health and sanity we are going to up the Version here and let
						//people lose their ghosts... sorry.

            if (ghostSet == (int) BestTimeSet.t_Custom) 
				name = String.Format("GhostDataCustom_v3{0}.binary.gho", inLevel);
            else if (ghostSet == (int) BestTimeSet.t_Normal) 
				name = String.Format("GhostData_v3{0}.binary.gho", inLevel);
            else 
				name = String.Format("GhostDataEasy_v3{0}.binary.gho", inLevel);
			
			//string appFile = "blah";//documentsDirectory.StringByAppendingPathComponent(name);
            return name;
        }

/*        public void SaveBestTimeAndGhostToFileP1P2(NSMutableDictionary dict, int i, int ghostSet)
        {
            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            if (!documentsDirectory) {
            }

            string name;
            numPiggyRaces++;

  /*          #if CONVERTING_PIGGY_DATA
                int loadLevel;
                if (ghostSet != (int) BestTimeSet.t_Custom) {
                    loadLevel = LevelBuilder_Ross.levelOrder[i];
                }
                else loadLevel = i;

                if (Constants.RECORDING_WHICH_PIGGY == 0) {
                    name = String.Format("PiggyData{0}.gho", loadLevel);
                }
                else {
                    name = String.Format("PiggyData{0}_Pig{1}.gho", loadLevel, Constants.RECORDING_WHICH_PIGGY + 1);
                }

            #else

                #if RACe_AS_PIGGY
                    int loadLevel;
                    if (ghostSet != (int) BestTimeSet.t_Custom) {
                        loadLevel = LevelBuilder_Ross.levelOrder[i];
                    }
                    else loadLevel = i;

                    #if RACe_AS_PIGGY_EASY
                        name = String.Format("PiggyData_Easy{0}.gho", loadLevel);
                    #else
                        if (Constants.RECORDING_WHICH_PIGGY == 0) {
                            name = String.Format("PiggyData{0}.gho", loadLevel);
                        }
                        else {
                            name = String.Format("PiggyData{0}_Pig{1}.gho", loadLevel, Constants.RECORDING_WHICH_PIGGY + 1);
                        }

                    #endif

                #else
                    if (ghostSet == (int) BestTimeSet.t_Custom) name = String.Format("GhostDataCustom_v2{0}.gho", i);
                    else if (ghostSet == (int) BestTimeSet.t_Normal) name = String.Format("GhostData_v2{0}.gho", i);
                    else name = String.Format("GhostDataEasy_v2{0}.gho", i);

                #endif

            #endif*/

//            string appFile = documentsDirectory.StringByAppendingPathComponent(name);
  //          dict.WriteToFileAtomically(appFile, true);
    //    }

        public void WriteBestTimeAndGhostToDictionary()
        {
            ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();

/*            #if CONVERTING_PIGGY_DATA
                for (int i = 0; i < lastPiggyIndex; i++) {
                    string appFile = this.GetFilenameForPiggyOrGhostSaveP1(i, playingLevel);
                    FileStream fp = fopen(appFile, "wb");
                    (ghostPiggy[i]).WriteGhostDataToBinaryFileUsingIndices(fp);
                    fclose (fp);
                }

            #else

                #if WRITe_GHOST_FILES_OLD_WAY
                    NSMutableDictionary dict = new NSMutableDictionary();
                    recordingGhost.WriteGhostDataToDictionaryUsingIndices(dict);
                    this.SaveBestTimeAndGhostToFileP1(dict, playingLevel);
                #else
                    string appFile = this.GetFilenameForPiggyOrGhostSaveP1P2(Constants.RECORDING_WHICH_PIGGY, playingLevel, (int) 
                      ((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet());
                    FileStream fp = fopen(appFile, "wb");
                    recordingGhost.WriteGhostDataToBinaryFileUsingIndices(fp);
                    fclose (fp);
                #endif

            #endif*/
			
			
            string appFile = this.GetFilenameForPiggyOrGhostSaveP1P2(Constants.RECORDING_WHICH_PIGGY, playingLevel, (int) 
              ((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet());
            
			string path = Globals.g_world.frontEnd.profile.pathForDocumentsFile(appFile);
			
			Debug.Log ("FileThing " + path);
			
			FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            
			recordingGhost.WriteGhostDataToBinaryFileUsingIndices(file);
            
			file.Close();
			
			
        }

        public void WriteNextLevelUnlocked()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) return;
/*
            int nextLevel = ((Globals.g_world.frontEnd).profile).selectedLevel + 1;
            if (nextLevel >= (int)Profile.Enum6.kNumLevels) return;

            NSMutableDictionary dict = new NSMutableDictionary();
            string string1 = String.Format("levelUnlocked");
            NSNumber value = new NSNumber(true);
            dict.SetObjectForKey(value, string1);
            string name;
            name = String.Format("GhostData{0}.gho", nextLevel);
            Utilities.WriteDictionaryToFileP1(dict, name);*/
        }

        string GetPiggyFileNameP1P2(bool useSlowerPiggy, int whichPiggy, int loadLevel)
        {
            if (useSlowerPiggy) {
                if (whichPiggy == 0) {
                    return String.Format("PiggyData{0}.binary", loadLevel);
                }
                else {
                    return String.Format("PiggyData{0}_Pig{1}.binary", loadLevel, whichPiggy + 1);
                }

            }
            else {
                if (whichPiggy == 0) {
                    return String.Format("PiggyData{0}.binary", loadLevel);
                }
                else {

                    #if SHOW_BOTH_PIG3
                        if (whichPiggy == 3) return String.Format("PiggyData{0}_Pig3.binary.slower.gho", loadLevel);
                        else {
                            return String.Format("PiggyData{0}_Pig{1}.binary.gho", loadLevel, whichPiggy + 1);
                        }

                    #else
                        return String.Format("PiggyData{0}_Pig{1}.binary", loadLevel, whichPiggy + 1);
                    #endif

                }

            }

        }

        string GetBestTimeAndGhostBinaryFileP1P2P3(int whichPiggy, int level, int ghostSet, bool isPig)
        {
			if (isPig)
			{
                bool useSlowerPiggy = ((((Globals.g_world.frontEnd).profile).profileInfo.level[level].usingSlowerPig) && (whichPiggy == 2));				
				
				int loadLevel = LevelBuilder_Ross.levelOrder[level];

				return this.GetPiggyFileNameP1P2(useSlowerPiggy, whichPiggy, loadLevel);
			}
			else
			{
				string name;
				
                if (ghostSet == (int) BestTimeSet.t_Custom) name = String.Format("GhostDataCustom_v3{0}.binary.gho", level);
                else if (ghostSet == (int) BestTimeSet.t_Normal) name = String.Format("GhostData_v3{0}.binary.gho", level);
                else name = String.Format("GhostDataEasy_v3{0}.binary.gho", level);

                return name;				
			}

			/*
            string name;
            if (isPig) {
                int loadLevel = level;
                if (ghostSet == (int) BestTimeSet.t_Custom) return "";

                loadLevel = LevelBuilder_Ross.levelOrder[level];
                bool useSlowerPiggy = ((((Globals.g_world.frontEnd).profile).profileInfo.Level[level].usingSlowerPig) && (whichPiggy == 2));

                #if DISABLE_SLOWER_PIG3
                    useSlowerPiggy = false;
                #endif

                name = this.GetPiggyFileNameP1P2(useSlowerPiggy, whichPiggy, loadLevel);
               // string resourcesPath = ((NSBundle.MainBundle()).ResourcePath()).StringByAppendingPathComponent(name);
                fp = fopen(resourcesPath, "rb");
                if (fp == null) {
                    if (useSlowerPiggy) {
                        useSlowerPiggy = false;
                        string name2 = this.GetPiggyFileNameP1P2(useSlowerPiggy, whichPiggy, loadLevel);
                        string resourcesPath2 = ((NSBundle.MainBundle()).ResourcePath()).StringByAppendingPathComponent(name2);
                        fp = fopen(resourcesPath2, "rb");
                    }

                }

            }
            else {
                if (ghostSet == (int) BestTimeSet.t_Custom) name = String.Format("GhostDataCustom_v2{0}.binary", level);
                else if (ghostSet == (int) BestTimeSet.t_Normal) name = String.Format("GhostData_v2{0}.binary", level);
                else name = String.Format("GhostDataEasy_v2{0}.binary", level);

                string appFile = documentsDirectory.StringByAppendingPathComponent(name);
                fp = fopen(appFile, "rb");
            }

            return fp;*/
        }

 /*       NSDictionary GetBestTimeAndGhostDictionaryP1P2P3(int whichPiggy, int level, int ghostSet, bool isPig)
        {
            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            string name;
            NSDictionary dict;
            if (isPig) {
                int loadLevel = level;
                if (ghostSet == (int) BestTimeSet.t_Custom) return null;

                loadLevel = LevelBuilder_Ross.levelOrder[level];
                if (((Globals.g_world.frontEnd).profile).preferences.diffEasy) name = String.Format("PiggyData_Easy{0}.gho", loadLevel);
                else {
                    if (whichPiggy == 0) {
                        name = String.Format("PiggyData{0}.gho", loadLevel);
                    }
                    else {
                        name = String.Format("PiggyData{0}_Pig{1}.gho", loadLevel, whichPiggy + 1);
                    }

                }

                string resourcesPath = ((NSBundle.MainBundle()).ResourcePath()).StringByAppendingPathComponent(name);
                dict = new NSDictionary(resourcesPath);
            }
            else {
                if (ghostSet == (int) BestTimeSet.t_Custom) name = String.Format("GhostDataCustom_v2{0}.gho", level);
                else if (ghostSet == (int) BestTimeSet.t_Normal) name = String.Format("GhostData_v2{0}.gho", level);
                else name = String.Format("GhostDataEasy_v2{0}.gho", level);

                string appFile = documentsDirectory.StringByAppendingPathComponent(name);
                dict = new NSDictionary(appFile);
            }

            return dict;
        }*/

        public void ReadGhostInformationFromData()
        {
			Debug.Log ("ReadGhostInformationFromData");
			
            BestTimeSet ghostSet = ((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet();

            #if READ_GHOST_FILES_OLD_WAY
                NSDictionary dict = this.GetBestTimeAndGhostDictionaryP1P2(0, playingLevel, false);
                playingGhost.ReadDataFromDictionaryUsingIndices(dict);
            #else

			String fileName = this.GetBestTimeAndGhostBinaryFileP1P2P3(0, playingLevel, (int) ghostSet, false);
            
			string fullFileName = Globals.g_world.frontEnd.profile.pathForDocumentsFile(fileName);
			
			Debug.Log ("fullFileName " + fullFileName);
			
			
//			String fullFileName = "Assets/Resources/Piggies/" + fileName;	
			
//			String resourcesFileName = "Piggies/" + fileName;	
		
			if (!File.Exists(fullFileName))
			{
			Debug.Log ("Can't find it");
				
                    playingGhost.Reset();
			}
			else
			{			
//				TextAsset asset = Resources.Load(resourcesFileName) as TextAsset;
				
				FileStream file = new FileStream(fullFileName, FileMode.Open, FileAccess.Read);
				
				if (file == null)
				{
	            	playingGhost.Reset();
				}
				else
				{				
//					Stream s = new MemoryStream(asset.bytes);
					BinaryReader sr = new BinaryReader(file);
					
	//				var sr = new BinaryReader(File.Open(fullFileName, FileMode.Open));//Application.dataPath + "/" + "Resources/Levels/LevelBin0.lev");
				
					if (sr != null) 
					{ 
						Debug.Log ("Worked!");
						
	                    playingGhost.ReadDataFromBinaryFileUsingIndices(sr);
	                }
	                else
					{
	                    playingGhost.Reset();
	                }
				}
			}

            #endif

        }

        public void SetupTiltMinsAndMaxes()
        {
            const float k1GPodMinTilt = -0.72f;
            const float k1GPodMaxTilt = -0.65f;
            const float kPodMinTilt = -0.85f;
            const float kPodMaxTilt = -0.75f;
            const float kPhoneMinTilt = -0.72f;
            const float kPhoneMaxTilt = -0.65f;
            if (Globals.g_world.deviceType == (int) UIDevicePlatform.UIDevice1GiPod) {
                yMinTilt = k1GPodMinTilt;
                yMaxTilt = k1GPodMaxTilt;
            }
            else if ((Globals.g_world.deviceType == (int) UIDevicePlatform.UIDevice2GiPod) || (Globals.g_world.deviceType == (int) UIDevicePlatform.UIDeviceUnknowniPod)) {
                yMinTilt = kPodMinTilt;
                yMaxTilt = kPodMaxTilt;
            }
            else {
                yMinTilt = kPhoneMinTilt;
                yMaxTilt = kPhoneMaxTilt;
            }

            if ((Globals.g_world.deviceType == (int) UIDevicePlatform.UIDeviceUnknown) || (Globals.g_world.deviceType == (int) UIDevicePlatform.UIDeviceUnknown)) {

            //    #if USE_ACCELEROMETERSIM
              //      kMinTiltUsed = 0.055f;
                //    kMaxTiltUsed = 0.22f;
                //#else
                    kMinTiltUsed = 0.055f;
                    kMaxTiltUsed = 0.22f;
               // #endif

            }
            else if ((Globals.g_world.deviceType == (int) UIDevicePlatform.UIDevice1GiPod) || (Globals.g_world.deviceType == (int) UIDevicePlatform.UIDevice2GiPod) || (
              Globals.g_world.deviceType == (int) UIDevicePlatform.UIDeviceUnknowniPod)) {
                kMinTiltUsed = 0.055f;
                kMaxTiltUsed = 0.26f;
            }
            else {
                kMinTiltUsed = 0.055f;
                kMaxTiltUsed = 0.26f;
            }

        }

        public void FirstInitialisation_Pre()
        {
        }

        public void FirstInitialisation()
        {
            this.SetupTiltMinsAndMaxes();
            this.LoadOtherPlayer(PlayerType.kPlayerPig);
            this.LoadTextures();
            Globals.g_main.RenderLoadingBar();
            Globals.g_main.RenderLoadingBar();
            //CrashLandingAppDelegate.Print_free_memory();
            this.AllocGameObjects();
			            this.InitialiseLinkedList();

			Globals.g_main.RenderLoadingBar();
            hud.FirstInitialisation();
            Globals.g_main.RenderLoadingBar();

						#if UNITY_IOS
						((Globals.g_world.frontEnd).profile).LoadBestTimesAndPrefsIOS();
						#else
						((Globals.g_world.frontEnd).profile).LoadBestTimesAndPrefs();
						#endif

            bool useTilt = ((Globals.g_world.frontEnd).profile).preferences.controlTilt;
            CrashLandingAppDelegate.SetAcceleromterOnOrOff(useTilt);
            (SoundEngine.Instance()).SetPlaySoundFX(((Globals.g_world.frontEnd).profile).preferences.soundFxOn);
            (Globals.g_world.audio).SetAudioSession(((Globals.g_world.frontEnd).profile).preferences.musicOn);
            Globals.g_main.RenderLoadingBar();
            ((Globals.g_world.frontEnd).profile).SetLevelUnlockedP1(0, true);
            if (Constants.UNLOCK_ALL_LEVELS) {
                for (int i = 0; i < (int)Profile.Enum6.kNumLevels; i++) {
                    ((Globals.g_world.frontEnd).profile).SetLevelUnlockedP1(i, true);
                    ((Globals.g_world.frontEnd).profile).SetLevelVisibleP1(i, true);
                }

            }

            if (Constants.UNLOCK_SOME_LEVELS) {
                for (int i = 0; i < (int)Profile.Enum6.kNumLevels; i++) {
                    if (i < Constants.UNLOCK_UPTO_LEVEL) {
                        ((Globals.g_world.frontEnd).profile).SetLevelUnlockedP1(i, true);
                        ((Globals.g_world.frontEnd).profile).SetLevelVisibleP1(i, true);
                        if (i < (Constants.UNLOCK_UPTO_LEVEL - 1)) {
                            if (Constants.UNLOCK_WITH_APPLES) {
                                ((Globals.g_world.frontEnd).profile).SetBestTimeP1P2( BestTimeSet.t_Normal, i, 5.0f);
                                if (i < 14) ((Globals.g_world.frontEnd).profile).SetNumApplesForRaceP1(i, 3);
                                else ((Globals.g_world.frontEnd).profile).SetNumApplesForRaceP1(i, 2);

                                ((Globals.g_world.frontEnd).profile).ClearPendingAchievements();
                            }

                        }
                        else {
                            if (Constants.UNLOCK_WITH_APPLES) {
                                ((Globals.g_world.frontEnd).profile).SetBestTimeP1P2( BestTimeSet.t_Normal, i, 55.0f);
                                ((Globals.g_world.frontEnd).profile).SetNumApplesForRaceP1(i, 0);
                            }

                        }

                    }
                    else {
                        ((Globals.g_world.frontEnd).profile).SetLevelUnlockedP1(i, false);
                        if (i < ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) {
                            ((Globals.g_world.frontEnd).profile).SetLevelVisibleP1(i, true);
                        }

                        if (Constants.UNLOCK_WITH_APPLES) {
                            ((Globals.g_world.frontEnd).profile).SetBestTimeP1P2( BestTimeSet.t_Normal, i, Profile.kBigBestTime);
                            ((Globals.g_world.frontEnd).profile).SetNumApplesForRaceP1(i, 0);
                        }

                    }

                }

                ((Globals.g_world.frontEnd).profile).UnlockSomeLevels(Constants.UNLOCK_UPTO_LEVEL);
            }

        }

        public void SetAccelerometer(UIAcceleration acceleration)
        {
            currentTiltSpeedY = prevAccelerationY - acceleration.y;
            prevAccelerationY = acceleration.y;
            const float kTiltForWarning = -1.1f;
            const float kMinSpeed = 0.2f;
            float accY = acceleration.y;
            if (accY < kTiltForWarning) {
                tiltMuchTooBig = true;
            }
            else {
                tiltMuchTooBig = false;
            }

            if (accY > yMaxTilt) accY = yMaxTilt;

            tiltDirection.y = Utilities.GetRatioP1P2P3P4(accY, yMinTilt, yMaxTilt, 1.0f, kMinSpeed);
            float kMinPosForExtra = -0.1f;
            if (tiltDirection.y >= kMinPosForExtra) {
                float kHowMuchExtraTilt = 0.0f;
                float cosVal = Utilities.GetCosInterpolationHalfP1P2(tiltDirection.y, kMinPosForExtra, 4.0f);
                float extraTilt = cosVal * kHowMuchExtraTilt;
                tiltDirection.y += extraTilt;
            }

            float xAccValue;
            if (Globals.g_main.upsideDown == true) {
                xAccValue = -acceleration.x;
            }
            else {
                xAccValue = acceleration.x;
            }

            float absX = Utilities.GetABS(xAccValue);
            if (player.position.y < 600) {
                float ratio = Utilities.GetRatioP1P2(player.position.y, 100.0f, 450.0f);
                absX *= ratio;
            }

            if (xAccValue < 0) {
                tiltDirection.x = -Utilities.GetRatioP1P2(absX, kMinTiltUsed, kMaxTiltUsed);
            }
            else {
                tiltDirection.x = Utilities.GetRatioP1P2(absX, kMinTiltUsed, kMaxTiltUsed);
            }

        }

        public void DereferenceStuff()
        {
			for (int i = 0; i < (int)Enum2.kMaxMapObjects; i++)
			{
				if (mapObject[i] != null)
				{
					mapObject[i].Dereference();
					//mapObject[i] = null;
				}
			}
			
            for (int i = 0; i < 3; i++) 
			{
				playerPiggy[i].Dereference();
            }
			player.Dereference();
		}		
		
        public void ReleaseGameObjects()
        {
            for (int i = 0; i <  (int)Enum2.kMaxRivers; i++) 
			{
				if (river[i] != null)
				{
	                river[i].Dealloc();
					river[i] = null;
				}
            }
			
			
			
            //CrashLandingAppDelegate.Print_free_memory();
            for (int o = 0; o < (int) GameObjectType.Types; o++) {
                for (int i = 0; i < numGameObject[o]; i++) {
                    switch ((GameObjectType)o) {
                    case GameObjectType.kGameObject_Flock :
                       // flock[i];
                        flock[i].Dealloc();
                        flock[i] = null;
                        break;
                    case GameObjectType.kGameObject_CrossingThing :
                      //  crossingThing[i];
                        crossingThing[i].Dealloc();
                        crossingThing[i] = null;
                        break;
                    case GameObjectType.kGameObject_FlowerBunches :
                       // flowerBunch[i];
//                        flowerBunch[i].Dealloc();
                        flowerBunch[i] = null;
                        break;
                    case GameObjectType.kGameObject_NoGoZones :
                      //  noGoZone[i];
                        noGoZone[i].Dealloc();
                        noGoZone[i] = null;
                        break;
                    case GameObjectType.kGameObject_Ponds :
                      //  pond[i];
//                        pond[i].Dealloc();
                        pond[i] = null;
                        break;
                    case GameObjectType.kGameObject_Rainbows :
                       // rainbow[i];
//                        rainbow[i].Dealloc();
                        rainbow[i] = null;
                        break;
                    case GameObjectType.kGameObject_Cows :
                      //  cow[i];
                        cow[i].Dealloc();
                        cow[i] = null;
                        break;
                    case GameObjectType.kGameObject_Hedges :
                      //  hedge[i];
//                        hedge[i].Dealloc();
                        hedge[i] = null;
                        break;
                    case GameObjectType.kGameObject_BoostArrows :
                      //  boostArrow[i];
  //                      boostArrow[i].Dealloc();
                        boostArrow[i] = null;
                        break;
                    case GameObjectType.kGameObject_Buildings :
                      //  building[i];
    //                    building[i].Dealloc();
                        building[i] = null;
                        break;
                    case GameObjectType.kGameObject_HayBale :
                     //   hayBale[i];
    //                    hayBale[i].Dealloc();
                        hayBale[i] = null;
                        break;
                    case GameObjectType.kGameObject_Tractor :
                     //   tractor[i];
//                        tractor[i].Dealloc();
                        tractor[i] = null;
                        break;
                    case GameObjectType.kGameObject_Chicken :
                     //   chicken[i];
                        chicken[i].Dealloc();
                        chicken[i] = null;
                        break;
                    case GameObjectType.kGameObject_Crater :
                      //  crater[i];
                        crater[i] = null;
                        break;
                    case GameObjectType.kGameObject_WoodenLog :
                     //   woodenLog[i];
                        woodenLog[i] = null;
                        break;
                    case GameObjectType.kGameObject_Venus :
                      //  venus[i];
                        venus[i] = null;
                        break;
                    case GameObjectType.kGameObject_Lion :
                     //   lion[i];
                        lion[i] = null;
                        break;
                    case GameObjectType.kGameObject_Tree :
                     //   tree[i];
        //                tree[i].Dealloc();
                        tree[i] = null;
                        break;
                    case GameObjectType.kGameObject_Trampoline :
                     //   trampoline[i];
                        trampoline[i] = null;
                        break;
                    case GameObjectType.kGameObject_Waterfall :
                      //  waterfall[i];
                        waterfall[i] = null;
                        break;
                    case GameObjectType.kGameObject_CliffPieces :
                     //   cliffPiece[i];
                        cliffPiece[i] = null;
                        break;
                    case GameObjectType.kGameObject_StarSpeedUp :
                      //  starSpeedUp[i];
             //           starSpeedUp[i].Dealloc();
                        starSpeedUp[i] = null;
                        break;
                    default :
                        Globals.Assert(false);
                        break;
                    }

                }

            }

            //CrashLandingAppDelegate.Print_free_memory();
        }
		
		public void SetSpritesToTileCamera(bool isTipThing)
		{
			for (int i = 0; i < (int)Enum2.kMaxMapObjects; i++)
			{
				mapObject[i].SetToTileCamera(isTipThing);
			}
		}

        public void CheckReleaseGameThings()
        {
            if (currentlyLoadedLevel == -1) {
                currentlyLoadedLevel = playingLevel;
            }

            if (playingLevel != currentlyLoadedLevel) 
			{
                this.ReleaseGameObjects();
                currentlyLoadedLevel = playingLevel;
            }

        }

        public void RenderMapObjectsInAreaP1P2P3(CGPoint topLeft, CGPoint areaSize, float inScale, CGPoint centrePoint)
        {
            int[] renderOrder = new int[(int)ListType.Types];
            renderOrder[0] = (int)ListType.e_RenderTracks;
            renderOrder[1] = (int)ListType.e_Shadows;
            renderOrder[2] = (int)ListType.e_RenderUnderPlayer;
            renderOrder[3] = (int)ListType.e_RenderAbovePlayer;
            renderOrder[4] = (int)ListType.e_RenderGatesAbovePlayer;
            renderOrder[5] = (int)ListType.e_RenderTrees;
            Globals.Assert( (int)ListType.Types == 6);
            int runThrough = 1;
            {
                if (runThrough == 1) {
                    ////glEnableClientState (GL_COLOR_ARRAY);
                }

                for (int w = 0; w <  (int)ListType.Types; w++) {
                    int l = renderOrder[w];
                    if (runThrough == 0) {
                    }
                    else {
                        switch (l) {
                        case (int)ListType.e_RenderGatesAbovePlayer :
                            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_PiggyAnims));
                            break;
                        default :
                            (DrawManager.Instance()).Begin(gameThingsAtlas);
                            break;
                        }

                    }

                    for (int n = 0; n < numMapObjectInPendingList[l]; n++) {
                        Globals.Assert(n <  (int)Enum2.kMaxMapObjects);
                        int i = pendingListMapObjects[l, n];
                        bool inArea = false;
                        if (((mapObject[i]).position.x >= topLeft.x) && ((mapObject[i]).position.x <= (topLeft.x + areaSize.x))) {
                            if (((mapObject[i]).position.y >= topLeft.y) && ((mapObject[i]).position.y <= (topLeft.y + areaSize.y))) {
                                inArea = true;
                            }

                        }

                        if (inArea) {
                            CGPoint offset = Utilities.CGPointMake((mapObject[i]).position.x - topLeft.x, (mapObject[i]).position.y - topLeft.y);
                            offset.x *= inScale;
                            offset.y *= inScale;
                            CGPoint displayPos = Utilities.CGPointMake(centrePoint.x + offset.x - ((areaSize.x * inScale) / 2.0f), centrePoint.y + offset.y - ((areaSize.
                              y * inScale) / 2.0f));
                            if (false) {

                                #if TEST_SHORTS
                                    //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                                #endif

                                //glPushMatrix();
                                Globals.g_world.DoGLTranslateP1(displayPos.x, displayPos.y);
                                ((mapObject[i]).texture).DrawAtPointScaled((mapObject[i]).scale * inScale);
								

                                #if TEST_SHORTS
                                    //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                                #endif

                                //glPopMatrix();
                            }
                            else {
  //                              (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(displayPos, (mapObject[i]).scale * inScale, (mapObject[i]).rotation, (
//                                  mapObject[i]).rotationScale * inScale, (mapObject[i]).alpha, (mapObject[i]).subTextureId);

                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(mapObject[i].myAtlasBillboard, displayPos, (mapObject[i]).scale * inScale, (mapObject[i]).rotation, (mapObject[i]).
                      rotationScale * inScale, (mapObject[i]).alpha, (mapObject[i]).subTextureId);
							
							}

                        }

                    }

                    if (runThrough == 1) {
                        (DrawManager.Instance()).Flush();
                    }

                }

                ////glDisableClientState (GL_COLOR_ARRAY);
            }
        }

        public void RenderTileMap()
        {
            if ((gameState == GameState.e_Paused) || (gameState == GameState.e_AnotherPiggy) || (gameState == GameState.e_SpeedBoostScreen)) {
                tileMap.RenderScene(0);
            }
            else if ((gameState == GameState.e_ShowResultsWin) || (gameState == GameState.e_ShowResultsLoseToPiggy)) {
                if (!hud.showResultsScreenShown) {
                    tileMap.RenderScene(-(scrollPosition.y-prevScrollPosition.y));
                }

            }
            else tileMap.RenderScene(-(scrollPosition.y-prevScrollPosition.y));

        }

        public void AddStartingGateP1P2P3(int yPos, int xPos, StartingGateType inType, StartingGateState inStartState)
        {
            if (this.CheckNumObjectsP1(numStartingGates,  (int)Enum2.kMaxStartingGates)) {
                return;
            }

            int objectId;
			StartingGate.StartingGateInfo info = new StartingGate.StartingGateInfo();
            info.inType = inType;
            info.startingState = inStartState;
            if (inType == (int) StartingGateType.e_Left) {
                info.mapPosition = Utilities.CGPointMake(34.0f + (xPos * 64.0f), 49.0f + (yPos * 64.0f));
                objectId = this.AddMapObjectP1P2P3P4P5( TextureType.kTexture_GateLeft1, (int) info.mapPosition.x, (int) info.mapPosition.y,  ListType
                  .e_RenderGatesAbovePlayer, 0, 1);
            }
            else {
                info.mapPosition = Utilities.CGPointMake(30.0f + (xPos * 64.0f), 49.0f + (yPos * 64.0f));
                objectId = this.AddMapObjectP1P2P3P4P5( TextureType.kTexture_GateRight1, (int) info.mapPosition.x, (int) info.mapPosition.y,  ListType
                  .e_RenderGatesAbovePlayer, 0, 1);
            }

            if (this.IsMapObjectIdInvalid(objectId)) return;

            (startingGate[numStartingGates]).AddToScene(info);
            (startingGate[numStartingGates]).SetMapObjectId(objectId);
            (mapObject[objectId]).SetScale(1.0f);
			if (!inLevelBuilder)
			{
	            (mapObject[objectId]).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_PiggyAnims));
    	        (mapObject[objectId]).SetSubTextureId((startingGate[numStartingGates]).GetSubTextureId());
			}
            numStartingGates++;
        }

        int AddStoneWallFarmP1P2(int xPos, int yPos, int inType)
        {
            Globals.Assert(numStoneWalls <  (int)Enum2.kMaxStoneWalls);
            StoneWall.WallInfo info = new StoneWall.WallInfo();
            float kWallWidth;
            if (inType ==  (int)ObjectType.kOT_WallFarmYard) kWallWidth = 4.0f;
            else if (inType ==  (int)ObjectType.kOT_WallFarmYardLong) {
                kWallWidth = 6.0f;
            }
            else {
                Globals.Assert(false);
                kWallWidth = 4.0f;
            }

            info.xGatePosition = xPos + 1 + (kWallWidth / 2.0f);
            info.xGatePosition *= 64.0f;
            info.xGateWidth = 64 * kWallWidth;
            info.xGateWidth -= 40.0f;
            info.yMapPosition = yPos * 64.0f;
            info.hasGate = false;
            (stoneWall[numStoneWalls]).Initialise(info);
            numStoneWalls++;
            const int kCircleSize = 14;
            const int kYOffset = 36;
            float xPosCircle = info.xGatePosition - (info.xGateWidth / 2.0f) - kCircleSize;
            int noGoZoneId = this.AddNoGoZoneP1P2(xPosCircle, info.yMapPosition + kYOffset, kCircleSize);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_StoneWallPost);
            (noGoZone[noGoZoneId]).SetCeilingHeight(Constants.kStoneWallHeight);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            xPosCircle = info.xGatePosition + (info.xGateWidth / 2.0f) + kCircleSize;
            noGoZoneId = this.AddNoGoZoneP1P2(xPosCircle, info.yMapPosition + kYOffset, kCircleSize);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_StoneWallPost);
            (noGoZone[noGoZoneId]).SetCeilingHeight(Constants.kStoneWallHeight);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            return (numStoneWalls - 1);
        }

        int AddStoneWallP1P2(int yPos, int inGatePos, int inGateWidth)
        {
            Globals.Assert(numStoneWalls <  (int)Enum2.kMaxStoneWalls);
            tileMap.AddStoneWallP1P2(yPos, inGatePos, inGateWidth);
            StoneWall.WallInfo info = new StoneWall.WallInfo();
            info.xGatePosition = (((float) inGatePos) + (((float) inGateWidth) / 2));
            info.xGatePosition *= 64;
            info.xGateWidth = 64 * ((float) inGateWidth);
            info.yMapPosition = (yPos * 64);
            info.hasGate = true;
            (stoneWall[numStoneWalls]).Initialise(info);
            numStoneWalls++;
            const int kCircleSize = 15;
            const int kYOffset = 34;
            this.AddNoGoZoneP1P2(info.xGatePosition - (info.xGateWidth / 2) - kCircleSize, info.yMapPosition + kYOffset, kCircleSize);
            this.AddNoGoZoneP1P2(info.xGatePosition + (info.xGateWidth / 2) + kCircleSize, info.yMapPosition + kYOffset, kCircleSize);
            return (numStoneWalls - 1);
        }

        public void NewStateGamePlay()
        {
        }

        public void TimeUp()
        {
            this.SetNewGameState( GameState.e_ShowResultsLoseTooSlow);
            hud.ShowInGameButtonsLoseTooSlow();
            numApplesBeforeRace = (int)((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel) + 1;
            numApplesAfterRace = numApplesBeforeRace;
            if (playingCustom > 0) (stoneWall[1]).GatesFlyOff();

			Globals.g_analytics.CompleteRace(playingLevel,-1);

        }

        public void SaveProfileInformation()
        {
            if (savedProfileInfoYet) return;

            if (newBestTimeRecorded) {
                playingGhost.CopyData(recordingGhost);
                this.WriteBestTimeAndGhostToDictionary();
                this.WriteNextLevelUnlocked();
            }
            else if (flagSaveProfileInfo) {
                ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
                flagSaveProfileInfo = false;
            }

            savedProfileInfoYet = true;
        }

        public void UpdateConsecutiveLossStats()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                return;
            }

            Profile.NotSavedProfileInfo info = ((Globals.g_world.frontEnd).profile).notSavedInfo;
            info.level[playingLevel].numConsecutiveFails++;
            float slowestPiggy = -1.0f;
            for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
                if ((playerPiggy[i]).finishTime > slowestPiggy) {
                    slowestPiggy = (playerPiggy[i]).finishTime;
                }

            }

            float byTime = (raceTimer - slowestPiggy);
            if (byTime > 0.7f) {
                info.level[playingLevel].numConsecutiveFailsByTime++;
            }
            else {
                info.level[playingLevel].numConsecutiveFailsByTime = 0;
            }

            ((Globals.g_world.frontEnd).profile).SetNotSavedInfo(info);
        }

        public void UpdateConsecutiveLossStats3apples_Failed()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                return;
            }

            int numApplesGot = (int)((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel) + 1;
            if (numApplesGot != 2) {
                return;
            }

            Profile.NotSavedProfileInfo info = ((Globals.g_world.frontEnd).profile).notSavedInfo;
            info.level[playingLevel].numConsecutiveFails3apples++;
            info.level[playingLevel].numConsecutiveFailsByTime3apples++;
            ((Globals.g_world.frontEnd).profile).SetNotSavedInfo(info);
        }

        public void UpdateConsecutiveLossStats3apples_PassedLine()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                return;
            }

            int numApplesGot = (int)((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel) + 1;
            if (numApplesGot != 2) {
                return;
            }

            Profile.NotSavedProfileInfo info = ((Globals.g_world.frontEnd).profile).notSavedInfo;
            info.level[playingLevel].numConsecutiveFails3apples++;
            float fastestPiggy = 1000.0f;
            for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
                if ((playerPiggy[i]).finishTime > 0.0f) {
                    if ((playerPiggy[i]).finishTime < fastestPiggy) {
                        fastestPiggy = (playerPiggy[i]).finishTime;
                    }

                }

            }

            float byTime = (raceTimer - fastestPiggy);
            if (byTime > 0.8f) {
                info.level[playingLevel].numConsecutiveFailsByTime3apples++;
            }
            else {
                info.level[playingLevel].numConsecutiveFailsByTime3apples = 0;
            }

            ((Globals.g_world.frontEnd).profile).SetNotSavedInfo(info);
        }

        public void UpdateConsecutiveLossStats3apples_Won()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                return;
            }

            int numApplesGot = (int)((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel) + 1;
            if (numApplesGot != 2) {
                return;
            }

            Profile.NotSavedProfileInfo info = ((Globals.g_world.frontEnd).profile).notSavedInfo;
            info.level[playingLevel].numConsecutiveFails3apples = 0;
            info.level[playingLevel].numConsecutiveFailsByTime3apples = 0;
            ((Globals.g_world.frontEnd).profile).SetNotSavedInfo(info);
            Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
            if (savedInfo.level[playingLevel].usingSlowerPig3apples) {
                savedInfo.level[playingLevel].usingSlowerPig3apples = false;
                ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
                flagSaveProfileInfo = true;
            }

        }

        public void HitClosedGate()
        {
            this.SetNewGameState( GameState.e_ShowResultsLoseToPiggy);
            numApplesBeforeRace = (int)((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel) + 1;
            numApplesAfterRace = numApplesBeforeRace;
            this.UpdateConsecutiveLossStats();
            this.UpdateConsecutiveLossStats3apples_Failed();
            player.SetXScrollLook(0.0f);

			Globals.g_analytics.CompleteRace(playingLevel,-1);
        }

        public void NextCameraFollowPiggy()
        {
            int newLevel;
            if (cameraFollowWhichPiggy > 0) {
                cameraFollowWhichPiggy--;
                if (cameraFollowWhichPiggy == 1) {
                    newLevel = 4;
                }
                else if (cameraFollowWhichPiggy == 2) {
                    newLevel = 12;
                }
                else {
                    newLevel = 0;
                }

                ((Globals.g_world.frontEnd).profile).SetSelectedLevel(newLevel);

                #if PIGGY_SPEED_ADJUSTMENT_TOOL
                    for (int i = 0; i < 600; i++) {
                        speedAdjustmentTool.lastTryTime[i] = 0.0f;
                    }

                    this.SetupDesiredTrackTimes();
                #endif

                return;
            }
            else {
                Globals.Assert(false);
            }

        }

        public void ExitGameStateShowResults(GameState nextState)
        {
            if (Globals.g_world.artLevel == 0) {
                (Globals.g_world.frontEnd).ReleaseWinTextures();
                (Globals.g_world.frontEnd).ReleaseLoseTextures();
            }

            if (!gameMusicStoppedYet) {
                if (((Globals.g_world.frontEnd).profile).preferences.soundFxOn) {
                }
                else {
                }

                gameMusicStoppedYet = true;
            }

            Globals.g_world.SetRenderScale(1.0f);
            hud.ExitGameState_ShowResultsWin();
			hud.DeallocWinOrLoseScreen();
            recordingGhost.SetRaceTime(raceTimer);

            #if RECORDING_PLAYER_FOR_SIMULATOR_VIDEO
                NSMutableDictionary dict = new NSMutableDictionary();
                recordingGhost.WriteGhostDataToDictionary(dict);
                string inName;
                inName = String.Format("videoDataLevel{0}.vd", playingLevel);
                Utilities.WriteDictionaryToFileP1(dict, inName);
            #endif

            ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
            this.IncreaseHowYouLikeMeNowCounter();
            if (!savedProfileInfoYet) {
                this.PostHighScoresToCrystal();
            }

            this.SaveProfileInformation();
            if (!reactivatedCrystalBackground) {
                this.CheckCrystalBackgroundActivity(true);
                reactivatedCrystalBackground = true;
            }

            #if RACE_AS_PIGGY
                this.WriteBestTimeAndGhostToDictionary();
            #endif

            #if CONVERTING_PIGGY_DATA
                this.WriteBestTimeAndGhostToDictionary();
            #endif

            if (goToNextLevel) {
                if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                    int newLevel = ((Globals.g_world.frontEnd).profile).selectedLevelCustom + 1;
                    ((Globals.g_world.frontEnd).profile).SetSelectedLevelCustom(newLevel);
                }
                else {
                    int newLevel = ((Globals.g_world.frontEnd).profile).selectedLevel + 1;

                    #if RUN_AND_RECORD_PIG_TIMES
                        if (newLevel == 80) {
                            this.NextCameraFollowPiggy();
                        }

                    #endif

                    #if PIGGY_SPEED_ADJUSTMENT_TOOL
                        bool foundOne = false;
                        int realLevelId = LevelBuilder_Ross.levelOrder[newLevel];
                        do {
                            if (speedAdjustmentTool.desiredTime[realLevelId] > 0.0f) {
                                foundOne = true;
                            }
                            else {
                                newLevel++;
                                if (newLevel < (Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES - Profile.Enum6.kNumBonusLevels)) {
                                    realLevelId = LevelBuilder_Ross.levelOrder[newLevel];
                                }
                                else {
                                    this.NextCameraFollowPiggy();
                                    return;
                                }

                            }

                        }
                        while (!foundOne);

                    #endif

                    ((Globals.g_world.frontEnd).profile).SetSelectedLevel(newLevel);
                }

            }

        }

        public void AddLineOfCowsP1P2P3P4(int yTilePos, float xPos, float xSpacing, int inNumCows, float direction)
        {
            for (int i = 0; i < inNumCows; i++) {
                this.AddCowP1P2(yTilePos, xPos + (xSpacing * (float) i), (int)direction);
            }

        }

        public void AddLineOfCowsP1P2P3(int yTilePos, float xPos, float xSpacing, int inNumCows)
        {
            this.AddLineOfCowsP1P2P3P4(yTilePos, xPos, xSpacing, inNumCows, -1);
        }

        public NoGoZone GetNoGoZone(int inId)
        {
            Globals.Assert(inId < numGameObject[(int) GameObjectType.kGameObject_NoGoZones]);
            return noGoZone[inId];
        }

        public MapObject GetMapObject(int inId)
        {
            Globals.Assert(inId <  (int)Enum2.kMaxMapObjects);
            return mapObject[inId];
        }

        public StartingGate GetGate(int inId)
        {
            Globals.Assert(inId <  (int)Enum2.kMaxStartingGates);
            return startingGate[inId];
        }

        public bool IsMapObjectIdInvalid(int inId)
        {

            if (Constants.REMOVE_ASSERTS_FOR_FINAL_VERSION)
                if (inId == -1) return true;
			else
				Globals.Assert(inId != -1);

            return false;
        }

        public void PutCowPatP1(int yPos, float xPos)
        {
            CowPat.CowPatInfo info = new CowPat.CowPatInfo();
            info.position = Utilities.CGPointMake(xPos, yPos);
            info.mapObjectId = this.AddMapObjectP1P2P3( TextureType.kTexture_CowPat, (int) info.position.x, (int) info.position.y,  ListType.
              e_RenderUnderPlayer);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_SheepPoo);
            if (this.CheckNumObjectsP1(numCowPats,  (int)Enum2.kMaxCowPats)) return;

            (cowpat[numCowPats]).AddToScene(info);
            numCowPats++;
        }

        public void AddCowPatP1(int yTilePos, float xPos)
        {
            this.PutCowPatP1((32 + (64 * yTilePos)), xPos);
        }

        public void AddCowPatP1P2P3(int yTilePos, float xTilePos, int yPos, float xPos)
        {
            this.PutCowPatP1((32 + yPos + (64 * yTilePos)), (32 + xPos + (64 * xTilePos)));
        }

        public void AddCowP1(int yTilePos, float xPos)
        {
            this.AddCowP1P2(yTilePos, xPos, (int) (int) CowMovement.kCowWalkingLeft);
        }

        public void AddCowXYP1P2(int yPos, float xPos, int cowMovement)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_Cows],  (int)Enum2.kMaxCows)) {
                return;
            }

            Cow.CowInfo info = new Cow.CowInfo();
            info.position = Utilities.CGPointMake(xPos, (float) yPos);
            info.movement = (CowMovement)cowMovement;
            float trueRotationScale;
            info.mapObjectId = this.AddMapObjectP1P2P3(0, (int) info.position.x, (int) info.position.y,  ListType.e_RenderAbovePlayer);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            if (cowMovement == (int) (int) CowMovement.kCowWalkingRight) {
                if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_CowRight2);
                    trueRotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale((int)World.Enum3.kGTGrass_CowRight2);
                }
                else {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_CowRight2);
                    trueRotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud)).GetSubTextureRotationScale((int)World.Enum2.kGTMud_CowRight2);
                }

            }
            else {
                if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_CowLeft2);
                    trueRotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale((int)World.Enum3.kGTGrass_CowLeft2);
                }
                else {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_CowLeft2);
                    trueRotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud)).GetSubTextureRotationScale((int)World.Enum2.kGTMud_CowLeft2);
                }

            }

            const float kMinScale = 0.8f;
            const float kMaxScale = 1.0f;
            float range = kMaxScale - kMinScale;
            float rPlus = Utilities.GetRandBetweenP1(0.0f, range);
            float rThing = kMinScale + rPlus;
            trueRotationScale *= rThing;
            (mapObject[info.mapObjectId]).SetRotationScale(trueRotationScale);
            (mapObject[info.mapObjectId]).SetType( MapObjectType.e_Cow);
            const float kCowJumpHeight = 27;
            int noGoZoneId = this.AddNoGoZoneP1P2(info.position.x, info.position.y - 15.0f, 35.0f * rThing);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Cow);
            (noGoZone[noGoZoneId]).SetObjectId(numGameObject[(int) GameObjectType.kGameObject_Cows]);
            (noGoZone[noGoZoneId]).SetCeilingHeight(kCowJumpHeight);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_Cows, info.position.y);
            if (cow[numGameObject[(int) GameObjectType.kGameObject_Cows]] == null) {
                cow[numGameObject[(int) GameObjectType.kGameObject_Cows]] = new Cow();
            }

            (mapObject[info.mapObjectId]).SetObjectId(numGameObject[(int) GameObjectType.kGameObject_Cows]);
            if (Utilities.GetRand( 4) == 0) {
                if (cowMovement == (int) CowMovement.kCowWalkingRight) {
                    cowMovement = (int)CowMovement.kCowStandingStillRight;
                }
                else {
                    cowMovement = (int)CowMovement.kCowStandingStillLeft;
                }

            }

            info.noGoZoneId = noGoZoneId;
            (cow[numGameObject[(int) GameObjectType.kGameObject_Cows]]).AddToScene(info);
            numGameObject[(int) GameObjectType.kGameObject_Cows]++;
        }

        public void CheckAndSwapMapObjectForward(int mId)
        {

            if ((mapObject[mId]).listType ==  (int)ListType.e_RenderUnderPlayer) {

                this.SwapMapObjectForward(mId);
            }

        }

        public void CheckAndSwapMapObjectBackward(int mId)
        {

            #if MO_DEBUG
            #endif

            if ((mapObject[mId]).listType ==  (int)ListType.e_RenderAbovePlayer) {

                #if MO_DEBUG
                #endif

                this.SwapMapObjectBackward(mId);
            }
            else if ((mapObject[mId]).listType ==  (int)ListType.e_RenderTrees) {

                #if MO_DEBUG
                #endif

                this.SwapMapObjectBackwardFromTree(mId);
            }

        }

        public void AddWelly(CGPoint position)
        {
            float randomRotation = (((float)(Utilities.GetRand( 100))) / 200.0f) - 0.25f;
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderUnderPlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_Welly);
            (mapObject[mapObjectId]).SetRotation(randomRotation);
            float rotScaleWell = 622.0f;
            if (Globals.deviceIPad) {
                rotScaleWell *= 2.0f;
            }

            (mapObject[mapObjectId]).SetRotationScale(rotScaleWell);
            int shadowMapObjectId = this.AddMapObjectP1P2P3P4(0, (int)(position.x + 5.0f), (int)(position.y + 0.0f),  ListType.e_Shadows, 0);
            if (this.IsMapObjectIdInvalid(shadowMapObjectId)) return;

            (mapObject[shadowMapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_WellyShadow);
            (mapObject[shadowMapObjectId]).SetType( MapObjectType.e_WellyShadow);
            (mapObject[shadowMapObjectId]).SetRotation(randomRotation);
            float rotScaleWellShadow = 568.0f;
            if (Globals.deviceIPad) {
                rotScaleWellShadow *= 2.0f;
            }

            (mapObject[shadowMapObjectId]).SetRotationScale(rotScaleWellShadow);
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y, 20);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Welly);
            (noGoZone[noGoZoneId]).SetObjectId(mapObjectId);
            (noGoZone[noGoZoneId]).SetShadowObjectId(shadowMapObjectId);
            (mapObject[mapObjectId]).SetType( MapObjectType.e_Veg);
            (mapObject[mapObjectId]).SetObjectId(noGoZoneId);
        }

        public void AddBucket(CGPoint position)
        {
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderUnderPlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            (mapObject[mapObjectId]).SetSubTextureId(55);
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y, 20);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Bucket);
            (noGoZone[noGoZoneId]).SetObjectId(mapObjectId);
        }

        public void AddBollard(CGPoint position)
        {
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            if (lBuilder.currentScene == (int) SceneType.kSceneGrass) (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_Bollard);
            else {
                (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_TrafficCone);
            }

            int noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y, 20);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Bollard);
            (noGoZone[noGoZoneId]).SetObjectId(mapObjectId);
            (mapObject[mapObjectId]).SetType( MapObjectType.e_Veg);
            (mapObject[mapObjectId]).SetObjectId(noGoZoneId);
        }

        public void AddCauliflower(CGPoint position)
        {
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            if (lBuilder.currentScene == (int) SceneType.kSceneGrass) (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_Bollard);
            else {
                (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_CauliFlower);
            }

            int noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y, 20);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Cauliflower);
            (noGoZone[noGoZoneId]).SetObjectId(mapObjectId);
            (mapObject[mapObjectId]).SetType( MapObjectType.e_Veg);
            (mapObject[mapObjectId]).SetObjectId(noGoZoneId);
        }

        public void AddHayStack(CGPoint position)
        {
            GameObjectType objectType = GameObjectType.kGameObject_HayBale;
            if (this.CheckNumObjectsP1(numGameObject[(int)objectType],  (int)Enum2.kMaxHayBales)) {
                return;
            }

            HayBale.HayBaleInfo info = new HayBale.HayBaleInfo();
            info.position = Utilities.CGPointMake((position.x * 64.0f) + 96.0f, (position.y * 64.0f) + 64.0f);
            info.type = HayBaleType.e_Stack;
            const float kHayNoGoRadius = 65.0f;
            info.noGoZoneId = this.AddNoGoZoneP1P2(info.position.x - 15.0f, info.position.y + 20.0f, kHayNoGoRadius);
            (noGoZone[info.noGoZoneId]).SetCeilingHeight(HayBale.kBaleMaxHeight);
            (noGoZone[info.noGoZoneId]).SetType(NoGoType.e_HayStack);
            (noGoZone[info.noGoZoneId]).SetObjectId(numGameObject[(int)objectType]);
            info.position.y -= 40.0f;
            info.radius = kHayNoGoRadius - 15.0f;
            this.InsertThisObjectIntoListP1(objectType, info.position.y);
            if (hayBale[numGameObject[(int)objectType]] == null) {
                hayBale[numGameObject[(int)objectType]] = new HayBale();
            }

            (hayBale[numGameObject[(int)objectType]]).AddToScene(info);
            numGameObject[(int)objectType]++;
        }

        public void AddHayBaleP1(CGPoint position, HayBaleType inType)
        {
            GameObjectType objectType = GameObjectType.kGameObject_HayBale;
            if (this.CheckNumObjectsP1(numGameObject[(int)objectType],  (int)Enum2.kMaxHayBales)) {
                return;
            }

            HayBale.HayBaleInfo info = new HayBale.HayBaleInfo();
            info.position = position;
            info.type = inType;
            info.mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) info.position.x, (int) info.position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            if (inType == (int) HayBaleType.e_Single) {
                Globals.Assert(false);
            }
            else {
                (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_HayBaleSingle);
                const float kNoGoRadiusHayBale = 26.0f;
                info.noGoZoneId = this.AddNoGoZoneP1P2(info.position.x, info.position.y - 1.0f, kNoGoRadiusHayBale);
                (noGoZone[info.noGoZoneId]).SetCeilingHeight(HayBale.kBaleMaxHeight);
            }

            (noGoZone[info.noGoZoneId]).SetType(NoGoType.e_HayBale);
            (noGoZone[info.noGoZoneId]).SetObjectId(numGameObject[(int)objectType]);
            (noGoZone[info.noGoZoneId]).SetIsBouncable(true);
            (noGoZone[info.noGoZoneId]).SetCeilingHeight(20.0f);
            this.InsertThisObjectIntoListP1(objectType, info.position.y);
            if (hayBale[numGameObject[(int)objectType]] == null) {
                hayBale[numGameObject[(int)objectType]] = new HayBale();
            }

            (mapObject[info.mapObjectId]).SetType( MapObjectType.e_HayBale);
            (mapObject[info.mapObjectId]).SetObjectId(numGameObject[(int)objectType]);
            (hayBale[numGameObject[(int)objectType]]).AddToScene(info);
            numGameObject[(int)objectType]++;
        }

        public void AddChicken(CGPoint position)
        {
            GameObjectType objectType = GameObjectType.kGameObject_Chicken;
            if (this.CheckNumObjectsP1(numGameObject[(int)objectType],  (int)Enum2.kMaxChickens)) {
                return;
            }

            Chicken.ChickenInfo info = new Chicken.ChickenInfo();
            info.position = position;
            info.facingDirection = ChickenDirection.kChickenFacingLeft;
            if (true) {
                info.facingDirection = ChickenDirection.kChickenFacingRight;
            }

            info.mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) info.position.x, (int) info.position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_ChickenPeck1);
            this.InsertThisObjectIntoListP1(objectType, info.position.y);
            if (chicken[numGameObject[(int)objectType]] == null) {
                chicken[numGameObject[(int)objectType]] = new Chicken();
            }

            (chicken[numGameObject[(int)objectType]]).AddToScene(info);
            numGameObject[(int)objectType]++;
        }

        public void AddVenus(CGPoint position)
        {

        }

        public void AddLion(CGPoint position)
        {

        }

        public void AddGnome(CGPoint position)
        {
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_Gnome);
            (mapObject[mapObjectId]).SetScale(Constants.SPRITE_BASE_SCALE);
            (mapObject[mapObjectId]).SetIsSimpleObject(true);
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y + 12.0f, 10.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Gnome);
            (noGoZone[noGoZoneId]).SetObjectId(mapObjectId);
            (mapObject[mapObjectId]).SetType( MapObjectType.e_Veg);
            (mapObject[mapObjectId]).SetObjectId(noGoZoneId);
        }

        public void AddVegetableP1(int type, CGPoint position)
        {
            float noGoRadius = 0.0f;
            int listType = -1;
            switch ((ObjectType)type) {
            case ObjectType.kOT_Squash :
                noGoRadius = 18.0f;
                listType = (int)ListType.e_RenderUnderPlayer;
                break;
            case ObjectType.kOT_Courgette :
                noGoRadius = 18.0f;
                listType = (int)ListType.e_RenderUnderPlayer;
                break;
            case ObjectType.kOT_Pumpkin :
                noGoRadius = 23.0f;
                listType = (int)ListType.e_RenderAbovePlayer;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y, (ListType)listType, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            float randomThing = Utilities.GetRandBetweenP1(0.96f, 1.04f);
            (mapObject[mapObjectId]).SetScale(Constants.SPRITE_BASE_SCALE * randomThing);
            (mapObject[mapObjectId]).SetIsSimpleObject(true);
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y + 12.0f, noGoRadius);
            (noGoZone[noGoZoneId]).SetObjectId(mapObjectId);
            switch ((ObjectType)type) {
            case ObjectType.kOT_Squash :
                (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_Squash);
                (noGoZone[noGoZoneId]).SetType(NoGoType.e_Squash);
                break;
            case ObjectType.kOT_Courgette :
                (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_Courgette);
                (noGoZone[noGoZoneId]).SetType(NoGoType.e_Courgette);
                break;
            case ObjectType.kOT_Pumpkin :
                (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_Pumpkin);
                (noGoZone[noGoZoneId]).SetType(NoGoType.e_Pumpkin);
                (noGoZone[noGoZoneId]).SetCeilingHeight(20.0f);
                break;
            default :
                Globals.Assert(false);
                break;
            }

            (mapObject[mapObjectId]).SetType( MapObjectType.e_Veg);
            (mapObject[mapObjectId]).SetObjectId(noGoZoneId);
        }

        public void AddLog(CGPoint position)
        {

        }

        public void AddWaterfall(CGPoint position)
        {
        }

        public void AddCart(CGPoint position)
        {
            this.AddSkip(position);
            return;
            CGPoint mapPos = Utilities.CGPointMake(position.x * 64.0f, position.y * 64.0f);
            mapPos.x += 64.0f;
            mapPos.y += 64.0f;
            int noGoZoneId = this.AddNoGoZoneP1P2(mapPos.x, mapPos.y + 20.0f, 59.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Cart);
        }

        public void AddCactus(CGPoint position)
        {
            CGPoint mapPos = Utilities.CGPointMake(position.x * 64.0f, position.y * 64.0f);
            mapPos.x += 64.0f;
            mapPos.y += 64.0f;
            int noGoZoneId = this.AddNoGoZoneP1P2(mapPos.x, mapPos.y + 5.0f, 32.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Cactus);
        }

        public void AddCraterP1(CGPoint position, CraterType inType)
        {

        }

        public void AddTrampoline(CGPoint position)
        {
            GameObjectType gameObject = GameObjectType.kGameObject_Trampoline;
            CGPoint mapPosition = Utilities.CGPointMake(position.x * 64.0f, position.y * 64.0f);
            mapPosition.x += 96.0f;
            mapPosition.y += 96.0f;
            int noGoZoneId = this.AddNoGoZoneP1P2(mapPosition.x, mapPosition.y, 105.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Trampoline);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            (noGoZone[noGoZoneId]).SetCeilingHeight(20.0f);
            (noGoZone[noGoZoneId]).SetObjectId(numGameObject[(int)gameObject]);
            this.InsertThisObjectIntoListP1(gameObject, mapPosition.y);
            if (trampoline[numGameObject[(int)gameObject]] == null) {
                trampoline[numGameObject[(int)gameObject]] = new Trampoline();
            }

            Trampoline.TrampolineInfo info = new Trampoline.TrampolineInfo();
            info.position = mapPosition;
            (trampoline[numGameObject[(int)gameObject]]).AddToScene(info);
            (noGoZone[noGoZoneId]).SetObjectId(numGameObject[(int)gameObject]);
            numGameObject[(int)gameObject]++;
        }

        public void AddSmallSnow(CGPoint position)
        {
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderUnderPlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            (mapObject[mapObjectId]).SetSubTextureId(4);
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_Ponds],  (int)Enum2.kMaxPonds)) {
                return;
            }

            Pond.PondInfo info = new Pond.PondInfo();
            info.radius = 28.0f;
            info.type = PondType.e_Snow;
            info.position = position;
            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_Ponds, info.position.y);
            if (pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]] == null) {
                pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]] = new Pond();
            }

            (pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]]).AddToScene(info);
            numGameObject[(int) GameObjectType.kGameObject_Ponds]++;
        }

        public void AddOilDrum(CGPoint position)
        {
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_Barrel);
            (mapObject[mapObjectId]).SetIsSimpleObject(true);
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x - 20.0f, position.y - 0.0f, 41.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_OilDrum);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            (noGoZone[noGoZoneId]).SetCeilingHeight(20.0f);
        }

        public void AddScarecrow(CGPoint position)
        {
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            (mapObject[mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_ScareCrow);
            (mapObject[mapObjectId]).SetIsSimpleObject(true);
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x - 20.0f, position.y - 0.0f, 31.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_OilDrum);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            (noGoZone[noGoZoneId]).SetCeilingHeight(20.0f);
        }

        public void AddSeal(CGPoint position)
        {
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(mapObjectId)) return;

            (mapObject[mapObjectId]).SetSubTextureId(0);
            (mapObject[mapObjectId]).SetIsSimpleObject(true);
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x - 20.0f, position.y - 0.0f, 33.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Seal);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            (noGoZone[noGoZoneId]).SetCeilingHeight(20.0f);
            noGoZoneId = this.AddNoGoZoneP1P2(position.x + 20.0f, position.y - 0.0f, 33.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Seal);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            (noGoZone[noGoZoneId]).SetCeilingHeight(20.0f);
        }

        public void AddIgloo(CGPoint position)
        {
            position.x += 128.0f;
            position.y += 128.0f;
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y + 5.0f, 130.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Igloo);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            (noGoZone[noGoZoneId]).SetCeilingHeight(40.0f);
            int mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) position.x, (int) position.y,  ListType.e_RenderAbovePlayer, 0);
            (mapObject[mapObjectId]).SetSubTextureId(0);
        }

        public void AddCrocodile(CGPoint position)
        {
            position.x += 64.0f;
            position.y += 32.0f;
            int noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y, 30.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Crocodile);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            (noGoZone[noGoZoneId]).SetCeilingHeight(-35.0f);
            position.x += 64.0f;
            noGoZoneId = this.AddNoGoZoneP1P2(position.x, position.y, 30.0f);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Crocodile);
            (noGoZone[noGoZoneId]).SetIsBouncable(true);
            (noGoZone[noGoZoneId]).SetCeilingHeight(-35.0f);
        }

        public void AddTractorP1(ObjectType inType, CGPoint position)
        {
            GameObjectType objectType = GameObjectType.kGameObject_Tractor;
            if (this.CheckNumObjectsP1(numGameObject[(int)objectType],  (int)Enum2.kMaxTractors)) {
                return;
            }

            Tractor.TractorInfo info = new Tractor.TractorInfo();
            info.position = position;
            info.type = (int)inType;
            info.mapObjectId = this.AddMapObjectP1P2P3P4(0, (int) info.position.x, (int) info.position.y,  ListType.e_RenderAbovePlayer, 0);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            if ((inType ==  ObjectType.kOT_Tractor) || (inType ==  ObjectType.kOT_CrossingTractor)) {
                (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_Tractor);
            }
            else {
                (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_LandRover);
            }

            (mapObject[info.mapObjectId]).SetObjectId(numGameObject[(int)objectType]);
            (mapObject[info.mapObjectId]).SetType( MapObjectType.e_Tractor);
            info.wheelsMapObjectId1 = this.AddMapObjectP1P2P3P4(0, (int) (info.position.x + 1000.0f), (int) info.position.y,  ListType.e_RenderAbovePlayer, 
              0);
            if (!this.IsMapObjectIdInvalid(info.wheelsMapObjectId1)) {
                if ((inType ==  ObjectType.kOT_Tractor) || (inType ==  ObjectType.kOT_CrossingTractor)) {
                    (mapObject[info.wheelsMapObjectId1]).SetSubTextureId((int)World.Enum2.kGTMud_TractorBackWheel);
                }
                else {
                    (mapObject[info.wheelsMapObjectId1]).SetSubTextureId((int)World.Enum2.kGTMud_lrFrontWheel);
                }

            }

            info.wheelsMapObjectId2 = this.AddMapObjectP1P2P3P4(0, (int) (info.position.x + 1000.0f), (int) info.position.y,  ListType.e_RenderAbovePlayer, 
              0);
            if (!this.IsMapObjectIdInvalid(info.wheelsMapObjectId2)) {
                if ((inType ==  ObjectType.kOT_Tractor) || (inType ==  ObjectType.kOT_CrossingTractor)) {
                    (mapObject[info.wheelsMapObjectId2]).SetSubTextureId((int)World.Enum2.kGTMud_TractorFrontWheel);
                }
                else {
                    (mapObject[info.wheelsMapObjectId2]).SetSubTextureId((int)World.Enum2.kGTMud_lrBackWheel);
                }

            }

            float nogoRadius;
            if ((inType ==  ObjectType.kOT_Tractor) || (inType ==  ObjectType.kOT_CrossingTractor)) {
                nogoRadius = 62.0f;
            }
            else {
                nogoRadius = 52.0f;
            }

            info.noGoZoneId[0] = this.AddNoGoZoneP1P2(info.position.x - 40.0f, info.position.y - 10.0f, nogoRadius);
            info.noGoZoneId[1] = this.AddNoGoZoneP1P2(info.position.x + 40.0f, info.position.y - 10.0f, nogoRadius);
            for (int i = 0; i < 2; i++) {
                (noGoZone[info.noGoZoneId[i]]).SetType(NoGoType.e_Tractor);
                (noGoZone[info.noGoZoneId[i]]).SetObjectId(numGameObject[(int)objectType]);
                (noGoZone[info.noGoZoneId[i]]).SetIsBouncable(true);
                (noGoZone[info.noGoZoneId[i]]).SetCeilingHeight(kTractorJumpHeight + 1.0f);
            }

            this.InsertThisObjectIntoListP1(objectType, info.position.y);
            if (tractor[numGameObject[(int)objectType]] == null) {
                tractor[numGameObject[(int)objectType]] = new Tractor();
            }

            switch (inType) {
            case ObjectType.kOT_Tractor :
            case ObjectType.kOT_BlueTractor :
                info.inMovementType = TractorMovementType.kTMT_Oscillate;
                break;
            case ObjectType.kOT_CrossingTractor :
            case ObjectType.kOT_CrossingLandRover :
                info.inMovementType = TractorMovementType.kTMT_CrossingScreen;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            (tractor[numGameObject[(int)objectType]]).AddToScene(info);
            numGameObject[(int)objectType]++;
        }

        public void AddMuddyPuddleP1(CGPoint position, int radius)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_Ponds],  (int)Enum2.kMaxPonds)) {
                return;
            }

            Pond.PondInfo info = new Pond.PondInfo();
            if (radius == 2) {
                info.position = Utilities.CGPointMake(64 + (position.x * 64), 62 + (position.y * 64));
                info.radius = 65.0f;
            }
            else {
                info.position = Utilities.CGPointMake(32 + (position.x * 64), 32 + (position.y * 64));
                info.radius = 42.0f;
            }

            info.radius = 30.0f * ((float) radius);
            info.type = PondType.e_MuddyPuddle;
            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_Ponds, info.position.y);
            if (pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]] == null) {
                pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]] = new Pond();
            }

            (pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]]).AddToScene(info);
            numGameObject[(int) GameObjectType.kGameObject_Ponds]++;
        }

        public void AddChimney(CGPoint position)
        {
            CGPoint mapPosition = Utilities.CGPointMake(position.x * 64.0f, position.y * 64.0f);
            mapPosition.x += 32.0f;
            mapPosition.y += 42.0f;
            int noGoZoneId = this.AddNoGoZoneP1P2(mapPosition.x, mapPosition.y, 25);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_Chimney);
        }

        public void AddStoneWell(CGPoint position)
        {
            CGPoint mapPosition = Utilities.CGPointMake(position.x * 64.0f, position.y * 64.0f);
            mapPosition.x += 64.0f;
            mapPosition.y += 64.0f;
            return;
            int nogoz = this.AddNoGoZoneP1P2(mapPosition.x, mapPosition.y - 8.0f, 35);
            (noGoZone[nogoz]).SetType(NoGoType.e_StoneWell);
            (noGoZone[nogoz]).SetIsBouncable(true);
            (noGoZone[nogoz]).SetCeilingHeight(21.0f);
        }

        public void AddCowP1P2(int yTilePos, float xPos, int cowMovement)
        {
            this.AddCowXYP1P2(32 + (yTilePos * 64), xPos, cowMovement);
        }

        public FlowerHead GetFlowerHead(int flowerHeadId)
        {
            Globals.Assert(flowerHeadId <  (int)Enum2.kMaxFlowerHeads);
            return flowerHead[flowerHeadId];
        }

        public int GetFreeFlowerHead()
        {
            for (int i = 0; i <  (int)Enum2.kMaxFlowerHeads; i++) 
			{
                if ((flowerHead[i]).state == FlowerHeadState.e_Inactive) return i;
            }

            return -1;
        }

        public void AddSomeFlowerHeadsP1P2(int bunchId, Player inPlayer, bool hitByPiggy)
        {
            const int kMaxNumHeads = 12;
            FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
            info.addUnderPlayer = false;
            CGPoint[] startPositionOffset = new CGPoint[kMaxNumHeads];
            switch ((flowerBunch[bunchId]).type) {
            case FlowerBunchType.kFlowerBunch_Sunflowers :
                heapNumHeads = 6;
                startPositionOffset[5] = Utilities.CGPointMake(-55, -20);
                startPositionOffset[4] = Utilities.CGPointMake(-40, 0);
                startPositionOffset[3] = Utilities.CGPointMake(-10, -20);
                startPositionOffset[2] = Utilities.CGPointMake(14, -40);
                startPositionOffset[1] = Utilities.CGPointMake(0, 0);
                startPositionOffset[0] = Utilities.CGPointMake(50, -10);
                info.type = FlowerHeadType.kFlowerHead_Sunflower;
                if (hitByPiggy) {
                    if (Globals.g_world.artLevel == 0) {
                        heapNumHeads = 3;
                    }
                    else {
                        heapNumHeads = 5;
                    }

                }

                break;
            case FlowerBunchType.kFlowerBunch_Daffodil :
                heapNumHeads = 6;
                startPositionOffset[5] = Utilities.CGPointMake(-18, -40);
                startPositionOffset[4] = Utilities.CGPointMake(-25, -32);
                startPositionOffset[3] = Utilities.CGPointMake(-20, -20);
                startPositionOffset[2] = Utilities.CGPointMake(0, -34);
                startPositionOffset[1] = Utilities.CGPointMake(12, -25);
                startPositionOffset[0] = Utilities.CGPointMake(20, -36);
                info.type = FlowerHeadType.kFlowerHead_Daffodil;
                if (hitByPiggy) {
                    if (Globals.g_world.artLevel == 0) {
                        heapNumHeads = 6;
                    }
                    else {
                        heapNumHeads = 6;
                    }

                }

                break;
            case FlowerBunchType.kFlowerBunch_Tulips :
            case FlowerBunchType.kFlowerBunch_TulipsWhite :
            case FlowerBunchType.kFlowerBunch_TulipsYellow :
            case FlowerBunchType.kFlowerBunch_TulipsBlue :
                heapNumHeads = 10;
                startPositionOffset[4] = Utilities.CGPointMake(-25, -32);
                startPositionOffset[3] = Utilities.CGPointMake(-20, -40);
                startPositionOffset[2] = Utilities.CGPointMake(-5, -34);
                startPositionOffset[1] = Utilities.CGPointMake(12, -25);
                startPositionOffset[0] = Utilities.CGPointMake(2, -36);
                for (int i = 0; i < 5; i++) {
                    startPositionOffset[5 + i].x = startPositionOffset[i].x - 5.0f + (float)(Utilities.GetRand( 10));
                    startPositionOffset[5 + i].y = startPositionOffset[i].y - 5.0f + (float)(Utilities.GetRand( 10));
                }

                if ((flowerBunch[bunchId]).type == FlowerBunchType.kFlowerBunch_Tulips) {
                    info.type = FlowerHeadType.kFlowerHead_Tulip;
                }
                else if ((flowerBunch[bunchId]).type == FlowerBunchType.kFlowerBunch_TulipsWhite) {
                    info.type = FlowerHeadType.kFlowerHead_TulipWhite;
                }
                else if ((flowerBunch[bunchId]).type == FlowerBunchType.kFlowerBunch_TulipsYellow) {
                    info.type = FlowerHeadType.kFlowerHead_TulipYellow;
                }
                else if ((flowerBunch[bunchId]).type == FlowerBunchType.kFlowerBunch_TulipsBlue) {
                    info.type = FlowerHeadType.kFlowerHead_TulipBlue;
                }

                if (hitByPiggy) {
                    if (Globals.g_world.artLevel == 0) {
                        heapNumHeads = 10;
                    }
                    else {
                        heapNumHeads = 10;
                    }

                }

                break;
            default :
                Globals.Assert(false);
                break;
            }

            int whatTheHeck = heapNumHeads;
            if (whatTheHeck > 0) {
            }

            for (int y = 0; y < whatTheHeck; y++) {
                int i = y;
                info.position = Utilities.CGPointMake((flowerBunch[bunchId]).position.x + startPositionOffset[i].x, (flowerBunch[bunchId]).position.y +
                  startPositionOffset[i].y);
                float directionMulti = 3.0f - (Utilities.GetABS((((float) whatTheHeck) / 2.0f) - ((float) i)));
                float randVelocity = (((float)(Utilities.GetRand( 4))) / 10.0f) + 0.4f;
                directionMulti *= randVelocity;
                float circleSize = Constants.PI_ - 1.0f;
                float perThing = circleSize / ((float) whatTheHeck);
                float angle = (inPlayer.moveAngle - Constants.HALF_PI) - (circleSize / 2.0f) + (perThing * ((float) i));
                float outSpeed = 3.2f;
                info.velocity = Utilities.GetVectorFromAngleP1(angle, outSpeed);
                info.velocity.x += (0.8f * ((Globals.g_world.GetGame()).GetPlayer()).GetSpeed().x);
                info.velocity.y += (0.8f * ((Globals.g_world.GetGame()).GetPlayer()).GetSpeed().y);
                info.rotation = -angle;
                info.position = Utilities.CGPointMake(info.position.x + info.velocity.x * directionMulti, info.position.y + info.velocity.y * directionMulti);
                if ((((flowerBunch[bunchId]).type) == FlowerBunchType.kFlowerBunch_Daffodil) || (((flowerBunch[bunchId]).type) == 
                  FlowerBunchType.kFlowerBunch_Tulips) || (((flowerBunch[bunchId]).type) == FlowerBunchType.kFlowerBunch_TulipsWhite) || 
                  (((flowerBunch[bunchId]).type) == FlowerBunchType.kFlowerBunch_TulipsYellow) || (((flowerBunch[bunchId]).type) == 
                  FlowerBunchType.kFlowerBunch_TulipsBlue)) {
                    if (Utilities.GetRand( 2) == 0) {
                        info.velocity.x *= 0.5f;
                        info.velocity.y *= 0.5f;
                    }

                }

                int freeHead = this.GetFreeFlowerHead();
                if (freeHead != -1) {
                    (flowerHead[freeHead]).AddToScene(info);
                }
                else {
                }

            }

        }

        public FlowerHead GetFreeFlowerHeadPointer()
        {
            int freeHead = this.GetFreeFlowerHead();
            if (freeHead != -1) return flowerHead[freeHead];
            else {
                return null;
            }

        }

        public void AddFlyingBucketP1(CGPoint position, CGPoint velocity)
        {
            FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
            info.addUnderPlayer = false;
            info.position = position;
            info.velocity = velocity;
            info.velocity.x *= 2.0f;
            info.velocity.y *= 1.5f;
            info.rotation = 0;
            info.type = FlowerHeadType.kFlowerHead_Bucket;
            int freeHead = this.GetFreeFlowerHead();
            if (freeHead != -1) {
                (flowerHead[freeHead]).AddToScene(info);
            }

        }

        public void AddFlyingBollardP1(CGPoint position, CGPoint velocity)
        {
            FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
            info.addUnderPlayer = false;
            info.position = position;
            info.velocity = velocity;
            info.velocity.x *= 2.0f;
            info.velocity.y *= 1.5f;
            info.rotation = 0;
            info.type = FlowerHeadType.kFlowerHead_Bollard;
            int freeHead = this.GetFreeFlowerHead();
            if (freeHead != -1) {
                (flowerHead[freeHead]).AddToScene(info);
            }

        }

        public void AddFlyingCauliP1(CGPoint position, CGPoint velocity)
        {
            FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
            info.addUnderPlayer = false;
            info.position = position;
            info.velocity = velocity;
            info.velocity.x *= 2.0f;
            info.velocity.y *= 1.5f;
            info.rotation = 0;
            info.type = FlowerHeadType.kFlowerHead_Cauliflower;
            int freeHead = this.GetFreeFlowerHead();
            if (freeHead != -1) {
                (flowerHead[freeHead]).AddToScene(info);
            }

        }

        public void AddFlyingWellyP1(CGPoint position, CGPoint velocity)
        {
            FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
            info.addUnderPlayer = false;
            info.position = position;
            info.velocity = velocity;
            info.velocity.x *= 1.5f;
            info.velocity.y *= 1.25f;
            info.rotation = 0;
            info.type = FlowerHeadType.kFlowerHead_Welly;
            int freeHead = this.GetFreeFlowerHead();
            if (freeHead != -1) {
                (flowerHead[freeHead]).AddToScene(info);
            }

        }

        public void AddBushExplosionP1(int bunchId, Player inPlayer)
        {
            FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
            info.addUnderPlayer = false;
            CGPoint startPositionOffset = Utilities.CGPointMake(0, 0);
            info.position = Utilities.CGPointMake((flowerBunch[bunchId]).position.x + startPositionOffset.x, (flowerBunch[bunchId]).position.y + startPositionOffset.
              y);
            info.velocity = Utilities.CGPointMake(0, 2.0f);
            info.velocity.y += (0.4f * inPlayer.GetSpeed().y);
            info.rotation = 0;
            info.position = Utilities.CGPointMake(info.position.x + info.velocity.x, info.position.y + info.velocity.y);
            info.type = FlowerHeadType.kFlowerHead_BushExplosion;
            int freeHead = this.GetFreeFlowerHead();
            if (freeHead != -1) {
                (flowerHead[freeHead]).AddToScene(info);
            }

        }

        public void RenderFlowerHeadsInAir()
        {
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_FlowerHeads));
            for (int i = 0; i <  (int)Enum2.kMaxFlowerHeads; i++) {
                if ((flowerHead[i]).state != (int) FlowerHeadState.e_Active) continue;

            }

            (DrawManager.Instance()).Flush();
        }

        public void RenderFlowerHeadsOnGround()
        {
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_FlowerHeads));
            for (int i = 0; i <  (int)Enum2.kMaxFlowerHeads; i++) {
                if ((flowerHead[i]).state != FlowerHeadState.e_OnGround) continue;

            }

            (DrawManager.Instance()).Flush();
        }

        public void InitialiseLinkedList()
        {
            for (int i = 0; i <  (int)ListType.Types; i++) usedListHead[i] = -1;

            freeListHead = 0;
            for (int i = 0; i < ( (int)Enum2.kMaxMapObjects - 1); i++) {
                (mapObject[i]).SetNext(i + 1);
            }

            (mapObject[( (int)Enum2.kMaxMapObjects - 1)]).SetNext(-1);
        }

        public void FillMapObjectPendingList()
        {
        }

        public void ResetMapObjects()
        {

            this.InitialiseLinkedList();
            for (int i = 0; i <  (int)ListType.Types; i++) {

								int m = usedListHead[i];
								while (m != -1) {
										(mapObject[m]).StopRender();
										m = (mapObject[m]).GetNext();
								}


                nextMapObjectInPendingList[i] = 0;
                numMapObjectInPendingList[i] = 0;
            }

        }

        int GetNextFreeMapObject()
        {
            return freeListHead;
        }

        public void RemoveFromFreeList(int whichObject)
        {
            if (whichObject == freeListHead) {
                freeListHead = (mapObject[whichObject]).GetNext();
                return;
            }

            int item = freeListHead;
            while ((mapObject[item]).GetNext() != whichObject) {
                item = (mapObject[item]).GetNext();
            };

            (mapObject[item]).SetNext((mapObject[whichObject]).GetNext());
        }

        public void AddToPendingListP1(ListType listType, int whichObject)
        {
            float inYPos = mapObject[whichObject].position.y;
            int insertPoint = -1;
            int numSoFar = numMapObjectInPendingList[(int)listType];
            for (int i = 0; i < numSoFar; i++) {
                float yPos = mapObject[pendingListMapObjects[(int)listType, i]].position.y;
                if (inYPos < yPos) {
                    insertPoint = i;
                    break;
                }

            }

            if (insertPoint == -1) {
                pendingListMapObjects[(int)listType, numSoFar] = whichObject;
                numMapObjectInPendingList[(int)listType]++;
            }
            else {
                for (int i = numSoFar; i >= insertPoint; i--) {
                    Globals.Assert(numSoFar <  (int)Enum2.kMaxMapObjects);
                    pendingListMapObjects[(int)listType, i + 1] = pendingListMapObjects[(int)listType, i];
                }

                pendingListMapObjects[(int)listType, insertPoint] = whichObject;
                numMapObjectInPendingList[(int)listType]++;
            }

        }

        public void AddToUsedListP1(ListType listType, int whichObject)
        {
            Globals.Assert(!withinMapObjectUpdate);

            #if MO_DEBUG
                if (whichObject == 70) {
                    int ross = 0;
                }

            #endif

            (mapObject[whichObject]).SetNext(usedListHead[(int)listType]);
            usedListHead[(int)listType] = whichObject;
        }

        public void AddToEndOfUsedListP1(ListType listType, int whichObject)
        {
            Globals.Assert(!withinMapObjectUpdate);

            #if MO_DEBUG
                if (whichObject == 141) {
                    int ross = 0;
                }

            #endif

            int item = usedListHead[(int)listType];
            if (item == -1) {
                this.AddToUsedListP1(listType, whichObject);
                return;
            }

            int prevItem = 0;
            while (item != -1) {
                prevItem = item;
                item = (mapObject[item]).GetNext();
            };

            (mapObject[prevItem]).SetNext(whichObject);
            (mapObject[whichObject]).SetNext(-1);
        }

        public void SwapMapObjectBackwardFromTree(int whichObject)
        {
            if (!(mapObject[whichObject]).HasBeenDisplayed()) {

                #if MO_DEBUG
                #endif

                (mapObject[whichObject]).SetListType( (int)ListType.e_RenderTrees);
                return;
            }

            this.RemoveFromUsedListP1( ListType.e_RenderTrees, whichObject);
            if ((mapObject[whichObject]).isSimpleObject) {
                this.AddToEndOfUsedListP1( ListType.e_RenderUnderPlayer, whichObject);
            }
            else {
                this.AddToUsedListP1( ListType.e_RenderUnderPlayer, whichObject);
            }

            (mapObject[whichObject]).SetListType( (int)ListType.e_RenderUnderPlayer);
        }

        public void SwapMapObjectBackward(int whichObject)
        {
            if (!(mapObject[whichObject]).HasBeenDisplayed()) {

                #if MO_DEBUG
                #endif

                (mapObject[whichObject]).SetListType( (int)ListType.e_RenderUnderPlayer);
                return;
            }

            this.RemoveFromUsedListP1( ListType.e_RenderAbovePlayer, whichObject);
            if ((mapObject[whichObject]).isSimpleObject) {
                this.AddToEndOfUsedListP1( ListType.e_RenderUnderPlayer, whichObject);
            }
            else {
                this.AddToUsedListP1( ListType.e_RenderUnderPlayer, whichObject);
            }

            (mapObject[whichObject]).SetListType( (int)ListType.e_RenderUnderPlayer);
        }

        public void SwapMapObjectForward(int whichObject)
        {
            if (!(mapObject[whichObject]).HasBeenDisplayed()) {

                #if MO_DEBUG
                #endif

                (mapObject[whichObject]).SetListType( (int)ListType.e_RenderAbovePlayer);
                return;
            }

            this.RemoveFromUsedListP1( ListType.e_RenderUnderPlayer, whichObject);
            if ((mapObject[whichObject]).isSimpleObject) {
                this.AddToEndOfUsedListP1( ListType.e_RenderAbovePlayer, whichObject);
            }
            else {
                this.AddToUsedListP1( ListType.e_RenderAbovePlayer, whichObject);
            }

            (mapObject[whichObject]).SetListType( (int)ListType.e_RenderAbovePlayer);
        }

        public void RemoveFromUsedListP1(ListType listType, int whichObject)
        {
            Globals.Assert(!withinMapObjectUpdate);

            #if MO_DEBUG
            #endif

            if (whichObject == usedListHead[(int)listType]) {
                usedListHead[(int)listType] = (mapObject[whichObject]).GetNext();
                return;
            }

            int item = usedListHead[(int)listType];
            Globals.Assert(item != -1);
            while ((mapObject[item]).GetNext() != whichObject) {
                item = (mapObject[item]).GetNext();
                Globals.Assert(item != -1);
            };

            (mapObject[item]).SetNext((mapObject[whichObject]).GetNext());
        }

        public void AddToFreeList(int whichObject)
        {
            (mapObject[whichObject]).SetNext(freeListHead);
            freeListHead = whichObject;
        }

        public int AddMapObjectP1P2P3(TextureType inType, int mapX, int mapY, ListType listType)
        {
            return this.AddMapObjectP1P2P3P4P5(inType, mapX, mapY, listType, 0, 1);
        }

        public int AddMapObjectP1P2P3P4(TextureType inType, int mapX, int mapY, ListType listType, float inRotation)
        {
            return this.AddMapObjectP1P2P3P4P5(inType, mapX, mapY, listType, inRotation, 1);
        }

        public int AddMapObjectToFrontP1P2P3(TextureType inType, int mapX, int mapY, ListType listType)
        {
            return this.AddMapObjectToFrontOrBackP1P2P3P4P5P6(true, inType, mapX, mapY, listType, 0.0f, 1.0f);
        }

        public int AddMapObjectToFrontP1P2P3P4P5(TextureType inType, int mapX, int mapY, ListType listType, float inRotation, float alpha)
        {
            return this.AddMapObjectToFrontOrBackP1P2P3P4P5P6(true, inType, mapX, mapY, listType, inRotation, alpha);
        }

        public int AddMapObjectP1P2P3P4P5(TextureType inType, int mapX, int mapY, ListType listType, float inRotation, float alpha)
        {
            return this.AddMapObjectToFrontOrBackP1P2P3P4P5P6(false, inType, mapX, mapY, listType, inRotation, alpha);
        }
		
		public void SetMapObjectAtlas(int moId, ListType listId)
		{
			switch(listId)
			{
			case ListType.e_RenderUnderPlayer:
			case ListType.e_RenderAbovePlayer:
				mapObject[moId].SetAtlas(gameThingsAtlas);
			break;				
			}
		}

        public int AddMapObjectToFrontOrBackP1P2P3P4P5P6(bool toFront, TextureType inType, int mapX, int mapY, ListType listType, float inRotation, float
          alpha)
        {
            int nextMapObject = freeListHead;

            if (Constants.REMOVE_ASSERTS_FOR_FINAL_VERSION)
                if (nextMapObject == -1) 
					return -1;
			else                
				Globals.Assert(nextMapObject != -1);
            

            this.RemoveFromFreeList(nextMapObject);
            (mapObject[nextMapObject]).AddToSceneP1P2P3((int)inType, Utilities.CGPointMake(mapX, mapY), inRotation, alpha);
            (mapObject[nextMapObject]).SetBaseList((int)listType);
			this.SetMapObjectAtlas(nextMapObject,listType);

            #if MO_DEBUG
                if (nextMapObject == 141) {
                    int ross = 0;
                }

            #endif

            if ((gameState == GameState.e_GamePlay) || (gameState == GameState.e_ShowResultsWin) || (gameState == GameState.
              e_ShowResultsLoseToPiggy) || (listType == ListType.e_RenderTracks) || (inLevelBuilder)) {
                if (toFront) {
                    this.AddToEndOfUsedListP1(listType, nextMapObject);
                }
                else {
                    this.AddToUsedListP1(listType, nextMapObject);
                }

            }
            else {
                if (inType !=  TextureType.kTexture_DontAddThisMapObjectToPendingList) {
                    this.AddToPendingListP1(listType, nextMapObject);
                }
                else {
                }

            }

            (mapObject[nextMapObject]).SetListType((int) listType);
            return nextMapObject;
        }

  		
		  }

}
