using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace Default.Namespace
{
    public enum  SceneType {
        kSceneGrass = 0,
        kSceneMud,
        kSceneDesert,
        kSceneIce,
        kSceneMoon,
        kSceneJungle,
        kSceneSavanna,
        kNumScenes
    }
    public enum  ObjectType {
        kOT_Tree = 0,
        kOT_Pond,
        kOT_Rainbow,
        kOT_Flowers,
        kOT_River,
        kOT_Ramp,
        kOT_Rock,
        kOT_CowLeft,
        kOT_CowRight,
        kOT_CowPatSprite,
        kOT_HedgeLeft,
        kOT_HedgeRight,
        kOT_Bridge1,
        kOT_BigRamp,
        kOT_Bridge2,
        kOT_Puddle,
        kOT_InsertSpace,
        kOT_FinishingLine,
        kOT_ArrowLeft,
        kOT_ArrowDown,
        kOT_ArrowRight,
        kOT_BoostArrowDown,
        kOT_BigRock,
        kOT_RemoveSpace,
        kOT_Cliff2,
        kOT_Cliff3,
        kOT_Cliff4,
        kOT_Barn,
        kOT_BigSidewaysShed,
        kOT_StoneWell,
        kOT_HayBaleSingle,
        kOT_HayBaleDouble,
        kOT_Tractor,
        kOT_Chicken,
        kOT_FarmRamp,
        kOT_MudPuddle2x1,
        kOT_MudPuddle1x1,
        kOT_House,
        kOT_BushLilac,
        kOT_BushPink,
        kOT_ChimneyLeft,
        kOT_ChimneyRight,
        kOT_WallFarmYard,
        kOT_WallFarmYardLong,
        kOT_FinishingLineFarm,
        kOT_Bucket,
        kOT_Cart,
        kOT_Welly,
        kOT_Cactus,
        kOT_Snowdrift,
        kOT_Crater,
        kOT_HayStackDestroyed,
        kOT_HayStack,
        kOT_GreenAntWordsOnMoon,
        kOT_StarSpeedUp,
        kOT_HillockFarmyard,
        kOT_SmallBump,
        kOT_Crater2x2,
        kOT_Crater1x1,
        kOT_Bus,
        kOT_BlueTractor,
        kOT_OilDrum,
        kOT_Bollard,
        kOT_TreeGreen,
        kOT_Seal,
        kOT_SmallSnow,
        kOT_Igloo,
        kOT_Waterfall,
        kOT_Log,
        kOT_Venus,
        kOT_Elephant,
        kOT_Snake,
        kOT_Lion,
        kOT_Crocodile,
        kOT_Road,
        kOT_RoadCrossing,
        kOT_Gnome,
        kOT_Skip,
        kOT_MudPuddle2x2,
        kOT_Tent,
        kOT_Tulips,
        kOT_Scarecrow,
        kOT_CrossingTractor,
        kOT_CrossingLandRover,
        kOT_CrossingShirley,
        kOT_VegetablePatch,
        kOT_Pumpkin,
        kOT_Courgette,
        kOT_Squash,
        kOT_Cauliflower,
        kOT_Trampoline,
        kOT_CrossingFlockRight,
        kOT_CrossingFlockLeft,
        kOT_TulipsYellow,
        kOT_TulipsWhite,
        kOT_TulipsBlue,
        Types
    }
    public enum  LevelBuilder_RossState {
        kLBState_Dragging,
        kLBState_DroppingLimbo,
        kLBState_FingerIsUp,
        kLBState_PressingLimbo,
        kLBState_Scrolling,
        kLBState_FingerDownInLimbo
    }
    public enum  LevelBuilder_RossButtons {
        kLBButton_Copy = 0,
        kLBButton_Move,
        kLBButton_WriteData,
        kLBButton_DeleteAll,
        kLBButton_Done,
        kLBButton_Trash,
        kLBButton_Scroll,
        kLBButton_Info,
        kNumLBButtons
    }
    public enum  LevelBuilder_RossQueries {
        kLBQuery_QuitAndWrite = 0,
        kLBQuery_DeleteObjects,
        kLBQuery_InfoBridge,
        kLBQuery_TooManyObjects,
        kNumLBQueries
    }

    public class LevelBuilder_Ross
    {
		Billboard spriteBillboardPickable;
		Billboard spriteBillboardCarried;
		
        public string savedTrackName;
        public ObjectType[] pickableObjectType = new ObjectType[(int)Enum3.kNumPickableTiles];
        public FrontEndButton[] upButton = new FrontEndButton[(int)Enum3.kNumPickableTiles];
        public FrontEndButton[] downButton = new FrontEndButton[(int)Enum3.kNumPickableTiles];
        public FrontEndButton[] button = new FrontEndButton[(int)LevelBuilder_RossButtons.kNumLBButtons];
        public FrontEndQuery[] query = new FrontEndQuery[(int)LevelBuilder_RossQueries.kNumLBQueries];
        public float[] tileHeight = new float[(int)ObjectType.Types];
        public ObjectTileInfo[] objectInfo = new ObjectTileInfo[(int)ObjectType.Types];
        public CGPoint[] pickableObjectPosition = new CGPoint[(int)Enum3.kNumPickableTiles];
        public float tileMapOffset;
        public float prevTileMapOffset;
        public float tileMapMoveVelocity;
        public bool copySet;
        public LevelBuilder_RossState state;
        public bool touchingThisFrame;
        public CGPoint touchingPosition;
        public CGPoint currentDropSquare;
        public CGPoint pickedUpFromSquare;
        public float stateTimer;
        public DraggingInfo drag;
        public bool inQuery;
        public double fileCheckValue;
        public int fileCheckOperation;
        public int lastLoadedLevel;
        public int numPlacedObjects;
        public PlacedObjectInfo[] placedObject = new PlacedObjectInfo[(int)Enum3.kMaxPlacedObjects];
        public float notTouchingTimer;
        public bool levelBuilderFinished;
        public float goTooFarTimer;
        public int finishObject;
        public int currentScene;
        public int currentIndexSceneList;
        public int[,] sceneObjectList = new int[(int)SceneType.kNumScenes, (int)Enum3.kMaxObjectsInSceneList];
        public int[] numOjectsInSceneList = new int[(int)SceneType.kNumScenes];
        public FunnyWord[] funnyWord = new FunnyWord[(int)Enum.kLBNumFunnyWords];
        public UIAlertView quitAlert;
        public UIAlertView deleteAlert;
        public float kXRightSide;
        const float kScrollButtonHeight = 280;
        const float kScrollButtonY = 290;
        const float kBinButtonY = 104;
        const float kDoneButtonY = 40;
        const float kPickableObjectSize = 46;
        const float kShowTileScale = Constants.LEVEL_BUILDER_TILE_SCALE;
        const float kLBSmallerButtonMinScale = 1.0f;
        const float kLBButtonMinScale = 1.0f;

       public static int[] levelOrder = new int [Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES]
        { (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne,(int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo,(int)LevelBuilder_Ross.Enum2.kGrass1_7_MdwCup_Race7_Bollards,(int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks ,(int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail,
              (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes ,(int)LevelBuilder_Ross.Enum2.kGrass1_8_MdwCup_Race8_CowField ,(int)LevelBuilder_Ross.Enum2.kGrass_DuckpondDance ,(int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips ,(int)LevelBuilder_Ross.Enum2.kMud_EasyStables ,(int)LevelBuilder_Ross.Enum2.kMud_LongJumps,
             (int)LevelBuilder_Ross.Enum2.kMud_BarrelMaze ,(int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines ,(int)LevelBuilder_Ross.Enum2.kMud_MudVille ,(int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge ,(int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers ,(int)LevelBuilder_Ross.Enum2.kGrass4_6_CntCup_Race6_ABridgeTooMoo,
             (int)LevelBuilder_Ross.Enum2.kGrass4_2_CntCup_Race2_LongBridge ,(int)LevelBuilder_Ross.Enum2.kGrass1_6_MdwCup_Race6_CattleRun ,(int)LevelBuilder_Ross.Enum2.kGrass_GnomeHome ,(int)LevelBuilder_Ross.Enum2.kGrass4_4_CntCup_Race4_BT ,(int)LevelBuilder_Ross.Enum2.kGrass9_2_BigJump,
             (int)LevelBuilder_Ross.Enum2.kGrass9_4_FourRivers ,(int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly ,(int)LevelBuilder_Ross.Enum2.kMud3_8_PenCup_Race8_Weave ,(int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage ,(int)LevelBuilder_Ross.Enum2.kMud2_2_VegShirleyAndFlock
               ,(int)LevelBuilder_Ross.Enum2.kMud2_7_MudCup_Race7_BarrelsOfFun ,(int)LevelBuilder_Ross.Enum2.kMud8_6_BlueTulips ,(int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles ,(int)LevelBuilder_Ross.Enum2.kMud8_1_PumpkinPatch ,(int)LevelBuilder_Ross.Enum2.kMud8_5_PumpkinWiggle,
             (int)LevelBuilder_Ross.Enum2.kGrass4_5_CntCup_Race5_HOW ,(int)LevelBuilder_Ross.Enum2.kGrass9_3_BaleLines ,(int)LevelBuilder_Ross.Enum2.kGrass4_7_CntCup_Race7_RP ,(int)LevelBuilder_Ross.Enum2.kGrass9_5_Campyard ,(int)LevelBuilder_Ross.Enum2.kGrassN2_2_HayBaleGroove ,(int)LevelBuilder_Ross.Enum2.kGrassN2_3_RainbowRuns,
             (int)LevelBuilder_Ross.Enum2.kGrass4_8_CntCup_Race8_ABridgeTooBaa ,(int)LevelBuilder_Ross.Enum2.kGrass9_7_Puddles ,(int)LevelBuilder_Ross.Enum2.kMud3_6_PenCup_Race6_PCurvy ,(int)LevelBuilder_Ross.Enum2.kMud5_1_FrmCup_Race1_BarnDance ,(int)LevelBuilder_Ross.Enum2.kMud8_4_TulipChicane,
             (int)LevelBuilder_Ross.Enum2.kMud3_1_PenCup_Race1_IceHoles ,(int)LevelBuilder_Ross.Enum2.kMud5_4_FrmCup_Race4_AlleyHogs ,(int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard ,(int)LevelBuilder_Ross.Enum2.kMud5_3_FrmCup_Race3_TractorFactor,
             (int)LevelBuilder_Ross.Enum2.kMud7_4_Junkyard ,(int)LevelBuilder_Ross.Enum2.kGrass7_7_Orchard ,(int)LevelBuilder_Ross.Enum2.kGrass8_7_BridgeJumps ,(int)LevelBuilder_Ross.Enum2.kGrass7_6_Trampoline ,(int)LevelBuilder_Ross.Enum2.kGrassN2_4_SideSideJumps ,(int)LevelBuilder_Ross.Enum2.kGrassN2_8_ThinTreeAve,
             (int)LevelBuilder_Ross.Enum2.kGrassN1_7_HayChicanes ,(int)LevelBuilder_Ross.Enum2.kGrass6_6_StrCup_Race6_MazyD ,(int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow ,(int)LevelBuilder_Ross.Enum2.kMud8_2_BarrelThing ,(int)LevelBuilder_Ross.Enum2.kMud3_7_PenCup_Race7_Migration,
             (int)LevelBuilder_Ross.Enum2.kMud_ForestFlock ,(int)LevelBuilder_Ross.Enum2.kMud5_7_FrmCup_Race7_HumptyJumpty ,(int)LevelBuilder_Ross.Enum2.kMud5_8_FrmCup_Race8_Swineyard ,(int)LevelBuilder_Ross.Enum2.kMud_TheWoods ,(int)LevelBuilder_Ross.Enum2.kMud8_8_MudCup_Race1_HayBaby,
             (int)LevelBuilder_Ross.Enum2.kMud2_4_MudCup_Race4_LongRoof ,(int)LevelBuilder_Ross.Enum2.kGrass10_1_LotsOfSheep ,(int)LevelBuilder_Ross.Enum2.kGrass6_5_StrCup_Race5_scruba ,(int)LevelBuilder_Ross.Enum2.kGrass_WideJumps ,(int)LevelBuilder_Ross.Enum2.kGrassN1_8_SquareHedgeShuffle,
             (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep ,(int)LevelBuilder_Ross.Enum2.kGrass9_8_Gardens ,(int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop ,(int)LevelBuilder_Ross.Enum2.kGrass6_2_StrCup_Race2_Hogwash ,(int)LevelBuilder_Ross.Enum2.kMud_Harvest,
             (int)LevelBuilder_Ross.Enum2.kMud_RoadCrossingsFlowers ,(int)LevelBuilder_Ross.Enum2.kMud5_2_FrmCup_Race2_GetUp ,(int)LevelBuilder_Ross.Enum2.kMudN1_5_StarStables ,(int)LevelBuilder_Ross.Enum2.kMud10_3_PumpkinJumps ,(int)LevelBuilder_Ross.Enum2.kMud7_8_SquashDodge ,(int)LevelBuilder_Ross.Enum2.kMud10_2_MarrowField
               ,(int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville ,(int)Enum2.kBonus1_Prickle ,(int)Enum2.kBonus2_Floe ,(int)Enum2.kBonus3_Moon};


        public enum Enum {
            kLBWord_Builder = 0,
            kLBWord_TrackName,
            kLBWord_Object,
            kLBWord_Done,
            kLBWord_Clear,
            kLBWord_Move,
            kLBWord_Copy,
            kLBNumFunnyWords
        };
        public struct DraggingInfo{
            public ObjectType objectType;
            public CGPoint tileDragOrigin;
            public int objectOnMapDraggingId;
            public bool haveFoundValidDropPosition;
            public bool trashing;
        };
        public struct PlacedObjectInfo{
            public ObjectType objectType;
            public CGPoint position;
            public int mapObjectId;
            public int linkedToObject;
        };
        public class ObjectTileInfo
		{
            public int[,] objectTile = new int [(int)Enum3.kMaxObjectXSize,(int)Enum3.kMaxObjectYSize];
            public float tileWidth;
            public float tileHeight;
            public bool isSprite;
            public ZAtlas atlas;
            public short subTextureId;
        };
        public enum Enum1 {
            kAtlasBarnX = 4,
            kAtlasBarnY = 4,
            kAtlasShedX = 0,
            kAtlasShedY = 0,
            kAtlasWellX = 4,
            kAtlasWellY = 0,
            kAtlasRampX = 3,
            kAtlasRampY = 2,
            kAtlasHouseX = 8,
            kAtlasHouseY = 0,
            kAtlasMud1X = 6,
            kAtlasMud1Y = 2,
            kAtlasMud2X = 2,
            kAtlasMud2Y = 0,
            kAtlasMud3X = 3,
            kAtlasMud3Y = 0,
            kAtlasMud4X = 6,
            kAtlasMud4Y = 3,
            kAtlasMud5X = 7,
            kAtlasMud5Y = 3,
            kAtlasChimneyLeftX = 14,
            kAtlasChimneyLeftY = 3,
            kAtlasChimneyRightX = 1,
            kAtlasChimneyRightY = 1,
            kAtlasStoneWallX = 9,
            kAtlasStoneWallY = 5,
            kAtlasPondX = 13,
            kAtlasPondY = 5,
            kAtlasBucketX = 12,
            kAtlasBucketY = 5,
            kAtlasCartX = 9,
            kAtlasCartY = 6,
        };
        public enum Enum2 {
            kGrass_EasyOne = 15,
            kGrass1_2_MdwCup_Race2_MooMoo = 13,
            kGrass_DuckpondDance = 16,
            kGrass1_4_MdwCup_Race4_ForestTrail = 200,
            kGrass1_5_MdwCup_Race5_TwoRivers = 202,
            kGrass1_6_MdwCup_Race6_CattleRun = 205,
            kGrass1_7_MdwCup_Race7_Bollards = 203,
            kGrass1_8_MdwCup_Race8_CowField = 216,
            kMud2_1_VegDodge = 515,
            kMud_MudVille = 211,
            kMud2_4_MudCup_Race4_LongRoof = 209,
            kMud_EasyStables = 214,
            kMud2_6_MudCup_Race6_Barny = 213,
            kMud2_7_MudCup_Race7_BarrelsOfFun = 212,
            kMud_BarrelMaze = 218,
            kMud3_1_PenCup_Race1_IceHoles = 306,
            kMud3_2_PenCup_Race2_IglooVillage = 303,
            kMud_ForestFlock = 304,
            kMud3_4_PenCup_Race4_Huddles = 305,
            kMud_TheWoods = 302,
            kMud3_6_PenCup_Race6_PCurvy = 307,
            kMud3_7_PenCup_Race7_Migration = 301,
            kMud3_8_PenCup_Race8_Weave = 300,
            kMud_Harvest = 308,
            kMud_LongJumps = 310,
            kGrass_WideJumps = 311,
            kGrass4_1_CntCup_Race1_CurlyWurly = 19,
            kGrass4_2_CntCup_Race2_LongBridge = 201,
            kGrass4_3_CntCup_Race3_TheHerd = 204,
            kGrass4_4_CntCup_Race4_BT = 6,
            kGrass4_5_CntCup_Race5_HOW = 17,
            kGrass4_6_CntCup_Race6_ABridgeTooMoo = 207,
            kGrass4_7_CntCup_Race7_RP = 0,
            kGrass4_8_CntCup_Race8_ABridgeTooBaa = 1,
            kMud5_1_FrmCup_Race1_BarnDance = 102,
            kMud5_2_FrmCup_Race2_GetUp = 119,
            kMud5_3_FrmCup_Race3_TractorFactor = 112,
            kMud5_4_FrmCup_Race4_AlleyHogs = 100,
            kMud5_5_FrmCup_Race5_TheBarnyard = 118,
            kMud5_6_FrmCup_Race6_Corralicious = 109,
            kMud5_7_FrmCup_Race7_HumptyJumpty = 108,
            kMud5_8_FrmCup_Race8_Swineyard = 116,
            kGrass6_1_StrCup_Race1_PiggyMeadow = 4,
            kGrass6_2_StrCup_Race2_Hogwash = 8,
            kMud6_3_StrCup_Race3_Wellyv = 110,
            kMud6_4_StrCup_Race4_RoofR = 101,
            kGrass6_5_StrCup_Race5_scruba = 7,
            kGrass6_6_StrCup_Race6_MazyD = 14,
            kMud6_7_StrCup_Race7_trottville = 107,
            kGrass6_8_StrCup_Race8_Hogzwallop = 5,
            kGrass7_1_HedgesAndGnomes = 400,
            kMud7_2_HayBales = 401,
            kMud7_3_MudTulips = 402,
            kMud7_4_Junkyard = 403,
            kMud7_5_Motorway = 404,
            kGrass7_6_Trampoline = 405,
            kGrass7_7_Orchard = 508,
            kMud7_8_SquashDodge = 509,
            kMud8_1_PumpkinPatch = 408,
            kMud8_2_BarrelThing = 409,
            kMud8_3_VegLines = 410,
            kMud8_4_TulipChicane = 411,
            kMud8_5_PumpkinWiggle = 512,
            kMud8_6_BlueTulips = 513,
            kGrass8_7_BridgeJumps = 514,
            kMud8_8_MudCup_Race1_HayBaby = 215,
            kGrass_GnomeHome = 500,
            kGrass9_2_BigJump = 501,
            kGrass9_3_BaleLines = 502,
            kGrass9_4_FourRivers = 503,
            kGrass9_5_Campyard = 505,
            kGrass9_6_RandomMark = 506,
            kGrass9_7_Puddles = 507,
            kGrass9_8_Gardens = 510,
            kMud_DayDreamFlowers = 504,
            kGrass_RoadSheep = 520,
            kMud_RoadCrossingsFlowers = 521,
            kMud_Nada = 511,
            kGrass10_1_LotsOfSheep = 516,
            kMud10_2_MarrowField = 517,
            kMud10_3_PumpkinJumps = 518,
            kGrass1_5_OneRiverAndFlocks = 519,
            kMud2_2_VegShirleyAndFlock = 523,
            kGrassN2_1 = 21,
            kGrassN2_2_HayBaleGroove = 22,
            kGrassN2_3_RainbowRuns = 10,
            kGrassN2_4_SideSideJumps = 11,
            kMudN2_5_SkipsZigZag = 111,
            kMudN2_6_Alleys = 113,
            kMudN2_7_NewCorralicious = 114,
            kGrassN2_8_ThinTreeAve = 3,
            kGrassN1_1_PuddlesChicane = 2,
            kMudN1_2_Chicanery = 120,
            kGrassN1_3_WateryWeave = 9,
            kMudN1_4_SnakeDitch = 122,
            kMudN1_5_StarStables = 123,
            kGrassN1_6_HerdyGerdy = 12,
            kGrassN1_7_HayChicanes = 18,
            kGrassN1_8_SquareHedgeShuffle = 20,
            kBonus1_Prickle = 104,
            kBonus2_Floe = 106,
            kBonus3_Moon = 105,
        };
        public enum Enum3 {
            kNumPickableTiles = 1,
            kMaxObjectXSize = 10,
            kMaxObjectYSize = 8,
            kMaxPlacedObjects = 400,
            kMaxObjectsInSceneList = 50
        };
        //extern int[] levelOrder = new int[Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES];
    //    const int kDesignPhase100;
        //extern const float kShowTileScale;
        public float TileMapOffset
        {
            get;
            set;
        }

        public float PrevTileMapOffset
        {
            get;
            set;
        }

        public int NumPlacedObjects
        {
            get;
            set;
        }

        public int CurrentScene
        {
            get;
            set;
        }

        public string SavedTrackName
        {
            get;
            set;
        }


public void SetSavedTrackName(string inThing) {savedTrackName = inThing;}////@property(readwrite,assign) NSMutableString* savedTrackName;
public void SetTileMapOffset(float inThing) {tileMapOffset = inThing;}///@property(readwrite,assign) float tileMapOffset;
public void SetPrevTileMapOffset(float inThing) {prevTileMapOffset = inThing;}///@property(readwrite,assign) float prevTileMapOffset;
public void SetNumPlacedObjects(int inThing) {numPlacedObjects = inThing;}///@property(readwrite,assign) int numPlacedObjects;
public void SetCurrentScene(int inThing) {currentScene = inThing;}///@property(readwrite,assign) int currentScene;

        public const int kDesignPhase100 = 500;

        public LevelBuilder_Ross()
        {
            //if (!base.init()) return null;
			            for (int i = 0; i < (int) ObjectType.Types; i++) {
                objectInfo[i] = new ObjectTileInfo();
			}
			
			
			spriteBillboardPickable = new Billboard("lb");
			spriteBillboardCarried = new Billboard("lb");
			
			
			
//			objectInfo = new ObjectTileInfo[(int)ObjectType.Types];

            for (int i = 0; i < (int)Enum3.kNumPickableTiles; i++) 
			{
                upButton[i] = new FrontEndButton(0);
                downButton[i] = new FrontEndButton(0);
            }

            for (int i = 0; i < (int) LevelBuilder_RossButtons.kNumLBButtons; i++) button[i] = new FrontEndButton(0);

            for (int i = 0; i < (int) LevelBuilder_RossQueries.kNumLBQueries; i++) query[i] = new FrontEndQuery();

            for (int i = 0; i < (int)Enum.kLBNumFunnyWords; i++) funnyWord[i] = new FunnyWord();
			
	//		            for (int i = 0; i < (int) ObjectType.Types; i++) {
      //          objectInfo[i].isSprite = new ;
		//	}
			
           // this.Setup(-1);
            inQuery = false;
            currentScene = (short)SceneType.kSceneGrass;
            //savedTrackName = new string();
            Globals.Assert((int)Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES == (int)Profile.Enum6.kNumLevels);
            kXRightSide = 290.0f;
            if (Globals.deviceIPad) {
                kXRightSide = 322.0f;
            }

            //return this;
        }
        public void Dealloc()
        {
           // if (quitAlert.Visible) {
            //}

            quitAlert = null;
        }

        public void AlertViewClickedButtonAtIndex(UIAlertView alertView, int buttonIndex)
        {
            if (alertView == quitAlert) {
                if (buttonIndex == 0) {
                    this.QuitAndWriteData();
                    levelBuilderFinished = true;
                }
                else if (buttonIndex == 1) {
                    levelBuilderFinished = true;
                }
                else if (buttonIndex == 2) {
                }

                inQuery = false;
            }

        }

        public void SetupWords()
        {
            float kMapWordScale = 0.55f;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                kMapWordScale = 0.46f;
            }

            const float kObjectWordScale = 0.34f;
            const float kObjectWordScaleCH = 0.3f;
            for (int i = 0; i < (int)Enum.kLBNumFunnyWords; i++) {
                (funnyWord[i]).SetFont(Globals.g_world.font);
                (funnyWord[i]).SetLineAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines));
                (funnyWord[i]).SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));
            }

            FunnyWord.WordInfo info;
            info.position = Utilities.CGPointMake(192.0f * Constants.LEVEL_BUILDER_TILE_SCALE, 20.0f);
            if (Globals.deviceIPad) {
                info.position.x += 32.0f;
            }

            info.scale = kMapWordScale;
            info.isCentrePos = true;
            string inWord;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                (funnyWord[(int)Enum.kLBWord_Builder]).InitWithWordNewP1(info, Globals.g_world.GetNSString ( StringId.kString_LevelBuilder_Ross));
            }
            else {
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    inWord = "leveleditor\n";
                }
                else {
                    inWord = "level editor\n";
                }

                (funnyWord[(int)Enum.kLBWord_Builder]).InitWithWordP1(info, inWord);
            }

            (funnyWord[(int)Enum.kLBWord_Builder]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (funnyWord[(int)Enum.kLBWord_Builder]).SetColour(Constants.kColourWhite);
            info.position = Utilities.CGPointMake(192.0f * Constants.LEVEL_BUILDER_TILE_SCALE, 364.0f);
            if (Globals.deviceIPad) {
                info.position.x += 32.0f;
                info.position.y += 50.0f;
            }

            info.scale = kMapWordScale;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                info.position.y -= 10.0f;
                (funnyWord[(int)Enum.kLBWord_TrackName]).InitWithWordNewP1(info, Globals.g_world.GetNSString ( StringId.kString_CustomLevel));
            }
            else {
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    inWord = "Eigenes Level\n";
                }
                else {
                    inWord = "Custom Level\n";
                }

                (funnyWord[(int)Enum.kLBWord_TrackName]).InitWithWordP1(info, inWord);
            }

            (funnyWord[(int)Enum.kLBWord_TrackName]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            info.position = Utilities.CGPointMake(168.0f, 417.0f);
            if (Globals.deviceIPad) {
                info.position.y += 25.0f;
            }

            info.scale = kObjectWordScale;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                info.scale = kObjectWordScaleCH;
                (funnyWord[(int)Enum.kLBWord_Object]).InitWithWordNewP1(info, "Pond");
            }
            else {
                inWord = "Pond\n";
                (funnyWord[(int)Enum.kLBWord_Object]).InitWithWordP1(info, inWord);
            }

            (funnyWord[(int)Enum.kLBWord_Object]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (funnyWord[(int)Enum.kLBWord_Object]).SetColour(Constants.kColourDarkblue);
//            Constants.RossColour thing = new Constants.RossColour(0,0,0);
//            thing.cRed = 0.1f;
//            thing.cGreen = 0.1f;
//            thing.cBlue = 0.0f;
            info.position = Utilities.CGPointMake(290.0f, 420.0f);
            if (Globals.deviceIPad) {
                info.position.y += 25.0f;
            }

            info.scale = kObjectWordScale;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                info.scale = kObjectWordScaleCH;
            }

            (funnyWord[(int)Enum.kLBWord_Done]).InitWithStringIdP1(info, (int) StringId.kString_Done);
            (funnyWord[(int)Enum.kLBWord_Done]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
            (funnyWord[(int)Enum.kLBWord_Done]).SetColour(Constants.kColourBrown);
            info.position = Utilities.CGPointMake(33.0f, 420.0f);
            if (Globals.deviceIPad) {
                info.position.y += 25.0f;
            }

            info.scale = kObjectWordScale;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                info.scale = 0.31f;
                info.position.x -= 2.0f;
            }

            (funnyWord[(int)Enum.kLBWord_Clear]).InitWithStringIdP1(info, (int) StringId.kString_Clear);
            (funnyWord[(int)Enum.kLBWord_Clear]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
            (funnyWord[(int)Enum.kLBWord_Clear]).SetColour(Constants.kColourBrown);
            (funnyWord[(int)Enum.kLBWord_Clear]).FitToWidth(50.0f);
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                info.scale = 0.3f;
                info.position = Utilities.CGPointMake(590.0f * 0.5f, 181.0f * 0.5f);
                if (Globals.deviceIPad) {
                    info.position.x += 30.0f;
                }

                (funnyWord[(int)Enum.kLBWord_Move]).InitWithStringIdP1(info, (int) StringId.kString_Copy);
                (funnyWord[(int)Enum.kLBWord_Move]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
                (funnyWord[(int)Enum.kLBWord_Move]).SetColour(Constants.kColourBrown);
                (funnyWord[(int)Enum.kLBWord_Move]).FitToWidth(40.0f);
                info.scale = 0.28f;
                info.position = Utilities.CGPointMake(590.0f * 0.5f, 276.0f * 0.5f);
                if (Globals.deviceIPad) {
                    info.position.x += 30.0f;
                }

                (funnyWord[(int)Enum.kLBWord_Copy]).InitWithStringIdP1(info, (int) StringId.kString_Move);
                (funnyWord[(int)Enum.kLBWord_Copy]).SetShowStyle((int) FunnyWordShowStyle.kFunnyWordShow_Immediate);
                (funnyWord[(int)Enum.kLBWord_Copy]).SetColour(Constants.kColourBrown);
                (funnyWord[(int)Enum.kLBWord_Copy]).FitToWidth(40.0f);
            }

        }

        public void ChangeTrackNameDisplay()
        {
			string nsstring;// = new char[32];
            nsstring = (((Globals.g_world.frontEnd).profile).GetCustomLevelName());
            //strcat(nsstring, "\n");
            (funnyWord[(int)Enum.kLBWord_TrackName]).ChangeText(nsstring);
            (funnyWord[(int)Enum.kLBWord_TrackName]).Show();
        }

        string GetStringChinese(ObjectType inType)
        {
            switch (inType) {
            case ObjectType.kOT_Tree :
                return "树";
                
            case ObjectType.kOT_Road :
                return "路";
                
            case ObjectType.kOT_RoadCrossing :
                return "交叉口";
                
            case ObjectType.kOT_Pond :
                return "池塘";
                
            case ObjectType.kOT_Rainbow :
                return "加速器";
                
            case ObjectType.kOT_Flowers :
                return "水仙花";
                
            case ObjectType.kOT_Tulips :
                return "郁金香";
                
            case ObjectType.kOT_TulipsYellow :
                return "郁金香";
                
            case ObjectType.kOT_TulipsWhite :
                return "郁金香";
                
            case ObjectType.kOT_TulipsBlue :
                return "郁金香";
                
            case ObjectType.kOT_CrossingShirley :
                return "雪莉";
                
            case ObjectType.kOT_Bollard :
                return "圆锥体";
                
            case ObjectType.kOT_River :
                return "河流";
                
            case ObjectType.kOT_Ramp :
                return "坡道";
                
            case ObjectType.kOT_Rock :
                return "岩石";
                
            case ObjectType.kOT_CowLeft :
                return "绵羊";
                
            case ObjectType.kOT_CowRight :
                return "绵羊";
                
            case ObjectType.kOT_CowPatSprite :
                return "羊便便";
                
            case ObjectType.kOT_HedgeLeft :
                return "篱笆";
                
            case ObjectType.kOT_HedgeRight :
                return "篱笆";
                
            case ObjectType.kOT_Bridge1 :
                return "桥";
                
            case ObjectType.kOT_BigRamp :
                return "大斜坡";
                
            case ObjectType.kOT_Bridge2 :
                return "桥";
                
            case ObjectType.kOT_Puddle :
                return "水坑";
                
            case ObjectType.kOT_InsertSpace :
                return "插入空间";
                
            case ObjectType.kOT_FinishingLine :
                return "";
                
            case ObjectType.kOT_ArrowLeft :
                return "箭头";
                
            case ObjectType.kOT_ArrowDown :
                return "箭头";
                
            case ObjectType.kOT_ArrowRight :
                return "箭头";
                
            case ObjectType.kOT_BoostArrowDown :
                return "野餐毯";
                
            case ObjectType.kOT_BigRock :
                return "干草捆";
                
            case ObjectType.kOT_RemoveSpace :
                return "移除空间";
                
            case ObjectType.kOT_Trampoline :
                return "蹦床";
                
            case ObjectType.kOT_Barn :
                return "谷仓";
                
            case ObjectType.kOT_MudPuddle2x2 :
                return "泥塘";
                
            case ObjectType.kOT_BigSidewaysShed :
                return "棚屋";
                
            case ObjectType.kOT_StoneWell :
                return "";
                
            case ObjectType.kOT_HayBaleSingle :
                return "干草捆";
                
            case ObjectType.kOT_HayBaleDouble :
                return "干草捆";
                
            case ObjectType.kOT_Tractor :
                return "拖拉机";
                
            case ObjectType.kOT_BlueTractor :
                return "路虎";
                
            case ObjectType.kOT_Cauliflower :
                return "花菜";
                
            case ObjectType.kOT_Squash :
                return "西葫芦";
                
            case ObjectType.kOT_Pumpkin :
                return "南瓜";
                
            case ObjectType.kOT_Courgette :
                return "胡瓜";
                
            case ObjectType.kOT_CrossingTractor :
                return "拖拉机";
                
            case ObjectType.kOT_CrossingLandRover :
                return "路虎";
                
            case ObjectType.kOT_CrossingFlockLeft :
                return "移动绵羊";
                
            case ObjectType.kOT_CrossingFlockRight :
                return "移动绵羊";
                
            case ObjectType.kOT_OilDrum :
                return "酒桶";
                
            case ObjectType.kOT_Igloo :
                return "";
                
            case ObjectType.kOT_Seal :
                return "";
                
            case ObjectType.kOT_SmallSnow :
                return "";
                
            case ObjectType.kOT_Chicken :
                return "小鸡";
                
            case ObjectType.kOT_Waterfall :
                return "瀑布";
                
            case ObjectType.kOT_Log :
                return "";
                
            case ObjectType.kOT_Gnome :
                return "地精像";
                
            case ObjectType.kOT_Skip :
                return "废料桶";
                
            case ObjectType.kOT_Tent :
                return "帐篷";
                
            case ObjectType.kOT_Scarecrow :
                return "稻草人";
                
            case ObjectType.kOT_Venus :
                return "";
                
            case ObjectType.kOT_Elephant :
                return "";
                
            case ObjectType.kOT_Snake :
                return "";
                
            case ObjectType.kOT_Lion :
                return "";
                
            case ObjectType.kOT_FarmRamp :
                return "";
                
            case ObjectType.kOT_MudPuddle2x1 :
                return "泥塘";
                
            case ObjectType.kOT_MudPuddle1x1 :
                return "泥塘";
                
            case ObjectType.kOT_House :
                return "房屋";
                
            case ObjectType.kOT_BushLilac :
                return "";
                
            case ObjectType.kOT_BushPink :
                return "";
                
            case ObjectType.kOT_ChimneyLeft :
                return "";
                
            case ObjectType.kOT_ChimneyRight :
                return "";
                
            case ObjectType.kOT_WallFarmYard :
                return "石墙";
                
            case ObjectType.kOT_Welly :
                return "长筒雨靴";
                
            default :
                break;
            }

            return "";
        }

        string GetStringJapanese(ObjectType inType)
        {
            switch (inType) {
            case ObjectType.kOT_Tree :
                return "木";
                
            case ObjectType.kOT_Road :
                return "道";
                
            case ObjectType.kOT_RoadCrossing :
                return "曲がり角";
                
            case ObjectType.kOT_Pond :
                return "池";
                
            case ObjectType.kOT_Rainbow :
                return "ブースト";
                
            case ObjectType.kOT_Flowers :
                return "スイセン";
                
            case ObjectType.kOT_Tulips :
                return "チューリップ";
                
            case ObjectType.kOT_TulipsYellow :
                return "チューリップ";
                
            case ObjectType.kOT_TulipsWhite :
                return "チューリップ";
                
            case ObjectType.kOT_TulipsBlue :
                return "チューリップ";
                
            case ObjectType.kOT_CrossingShirley :
                return "シャーリー";
                
            case ObjectType.kOT_Bollard :
                return "コーン";
                
            case ObjectType.kOT_River :
                return "川";
                
            case ObjectType.kOT_Ramp :
                return "坂道";
                
            case ObjectType.kOT_Rock :
                return "岩";
                
            case ObjectType.kOT_CowLeft :
                return "ひつじ";
                
            case ObjectType.kOT_CowRight :
                return "ひつじ";
                
            case ObjectType.kOT_CowPatSprite :
                return "ひつじのう○こ";
                
            case ObjectType.kOT_HedgeLeft :
                return "囲い";
                
            case ObjectType.kOT_HedgeRight :
                return "囲い";
                
            case ObjectType.kOT_Bridge1 :
                return "橋";
                
            case ObjectType.kOT_BigRamp :
                return "おおきい坂道";
                
            case ObjectType.kOT_Bridge2 :
                return "橋";
                
            case ObjectType.kOT_Puddle :
                return "水たまり";
                
            case ObjectType.kOT_InsertSpace :
                return "追加場所";
                
            case ObjectType.kOT_FinishingLine :
                return "";
                
            case ObjectType.kOT_ArrowLeft :
                return "矢印";
                
            case ObjectType.kOT_ArrowDown :
                return "矢印";
                
            case ObjectType.kOT_ArrowRight :
                return "矢印";
                
            case ObjectType.kOT_BoostArrowDown :
                return "ブランケット";
                
            case ObjectType.kOT_BigRock :
                return "干し草";
                
            case ObjectType.kOT_RemoveSpace :
                return "取り外し場所";
                
            case ObjectType.kOT_Trampoline :
                return "トランポリン";
                
            case ObjectType.kOT_Barn :
                return "小屋";
                
            case ObjectType.kOT_MudPuddle2x2 :
                return "泥溜まり";
                
            case ObjectType.kOT_BigSidewaysShed :
                return "物置き";
                
            case ObjectType.kOT_StoneWell :
                return "";
                
            case ObjectType.kOT_HayBaleSingle :
                return "干し草";
                
            case ObjectType.kOT_HayBaleDouble :
                return "干し草";
                
            case ObjectType.kOT_Tractor :
                return "トラクター";
                
            case ObjectType.kOT_BlueTractor :
                return "ランドローバー";
                
            case ObjectType.kOT_Cauliflower :
                return "カリフラワー";
                
            case ObjectType.kOT_Squash :
                return "トウナス";
                
            case ObjectType.kOT_Pumpkin :
                return "カボチャ";
                
            case ObjectType.kOT_Courgette :
                return "ウリ";
                
            case ObjectType.kOT_CrossingTractor :
                return "動くトラクター";
                
            case ObjectType.kOT_CrossingLandRover :
                return "動くランドローバー";
                
            case ObjectType.kOT_CrossingFlockLeft :
                return "動くひつじ";
                
            case ObjectType.kOT_CrossingFlockRight :
                return "動くひつじ";
                
            case ObjectType.kOT_OilDrum :
                return "樽";
                
            case ObjectType.kOT_Igloo :
                return "";
                
            case ObjectType.kOT_Seal :
                return "";
                
            case ObjectType.kOT_SmallSnow :
                return "";
                
            case ObjectType.kOT_Chicken :
                return "ニワトリ";
                
            case ObjectType.kOT_Waterfall :
                return "滝";
                
            case ObjectType.kOT_Log :
                return "";
                
            case ObjectType.kOT_Gnome :
                return "ノーム";
                
            case ObjectType.kOT_Skip :
                return "スキップ";
                
            case ObjectType.kOT_Tent :
                return "テント";
                
            case ObjectType.kOT_Scarecrow :
                return "カカシ";
                
            case ObjectType.kOT_Venus :
                return "";
                
            case ObjectType.kOT_Elephant :
                return "";
                
            case ObjectType.kOT_Snake :
                return "";
                
            case ObjectType.kOT_Lion :
                return "";
                
            case ObjectType.kOT_FarmRamp :
                return "";
                
            case ObjectType.kOT_MudPuddle2x1 :
                return "泥溜まり";
                
            case ObjectType.kOT_MudPuddle1x1 :
                return "泥溜まり";
                
            case ObjectType.kOT_House :
                return "お家";
                
            case ObjectType.kOT_BushLilac :
                return "";
                
            case ObjectType.kOT_BushPink :
                return "";
                
            case ObjectType.kOT_ChimneyLeft :
                return "";
                
            case ObjectType.kOT_ChimneyRight :
                return "";
                
            case ObjectType.kOT_WallFarmYard :
                return "石壁";
                
            case ObjectType.kOT_Welly :
                return "ウェリー";
                
            default :
                break;
            }

            return "";
        }
		


        string GetStringFrench(ObjectType inType)
        {
            switch (inType) {
            case ObjectType.kOT_Tree :
                return "木";
                
            case ObjectType.kOT_Road :
                return "道";
                
            case ObjectType.kOT_RoadCrossing :
                return "曲がり角";
                
            case ObjectType.kOT_Pond :
                return "池";
                
            case ObjectType.kOT_Rainbow :
                return "ブースト";
                
            case ObjectType.kOT_Flowers :
                return "スイセン";
                
            case ObjectType.kOT_Tulips :
                return "チューリップ";
                
            case ObjectType.kOT_TulipsYellow :
                return "チューリップ";
                
            case ObjectType.kOT_TulipsWhite :
                return "チューリップ";
                
            case ObjectType.kOT_TulipsBlue :
                return "チューリップ";
                
            case ObjectType.kOT_CrossingShirley :
                return "シャーリー";
                
            case ObjectType.kOT_Bollard :
                return "コーン";
                
            case ObjectType.kOT_River :
                return "川";
                
            case ObjectType.kOT_Ramp :
                return "坂道";
                
            case ObjectType.kOT_Rock :
                return "岩";
                
            case ObjectType.kOT_CowLeft :
                return "ひつじ";
                
            case ObjectType.kOT_CowRight :
                return "ひつじ";
                
            case ObjectType.kOT_CowPatSprite :
                return "ひつじのう○こ";
                
            case ObjectType.kOT_HedgeLeft :
                return "囲い";
                
            case ObjectType.kOT_HedgeRight :
                return "囲い";
                
            case ObjectType.kOT_Bridge1 :
                return "橋";
                
            case ObjectType.kOT_BigRamp :
                return "おおきい坂道";
                
            case ObjectType.kOT_Bridge2 :
                return "橋";
                
            case ObjectType.kOT_Puddle :
                return "水たまり";
                
            case ObjectType.kOT_InsertSpace :
                return "追加場所";
                
            case ObjectType.kOT_FinishingLine :
                return "";
                
            case ObjectType.kOT_ArrowLeft :
                return "矢印";
                
            case ObjectType.kOT_ArrowDown :
                return "矢印";
                
            case ObjectType.kOT_ArrowRight :
                return "矢印";
                
            case ObjectType.kOT_BoostArrowDown :
                return "ブランケット";
                
            case ObjectType.kOT_BigRock :
                return "干し草";
                
            case ObjectType.kOT_RemoveSpace :
                return "取り外し場所";
                
            case ObjectType.kOT_Trampoline :
                return "トランポリン";
                
            case ObjectType.kOT_Barn :
                return "小屋";
                
            case ObjectType.kOT_MudPuddle2x2 :
                return "泥溜まり";
                
            case ObjectType.kOT_BigSidewaysShed :
                return "物置き";
                
            case ObjectType.kOT_StoneWell :
                return "";
                
            case ObjectType.kOT_HayBaleSingle :
                return "干し草";
                
            case ObjectType.kOT_HayBaleDouble :
                return "干し草";
                
            case ObjectType.kOT_Tractor :
                return "トラクター";
                
            case ObjectType.kOT_BlueTractor :
                return "ランドローバー";
                
            case ObjectType.kOT_Cauliflower :
                return "カリフラワー";
                
            case ObjectType.kOT_Squash :
                return "トウナス";
                
            case ObjectType.kOT_Pumpkin :
                return "カボチャ";
                
            case ObjectType.kOT_Courgette :
                return "ウリ";
                
            case ObjectType.kOT_CrossingTractor :
                return "動くトラクター";
                
            case ObjectType.kOT_CrossingLandRover :
                return "動くランドローバー";
                
            case ObjectType.kOT_CrossingFlockLeft :
                return "動くひつじ";
                
            case ObjectType.kOT_CrossingFlockRight :
                return "動くひつじ";
                
            case ObjectType.kOT_OilDrum :
                return "樽";
                
            case ObjectType.kOT_Igloo :
                return "";
                
            case ObjectType.kOT_Seal :
                return "";
                
            case ObjectType.kOT_SmallSnow :
                return "";
                
            case ObjectType.kOT_Chicken :
                return "ニワトリ";
                
            case ObjectType.kOT_Waterfall :
                return "滝";
                
            case ObjectType.kOT_Log :
                return "";
                
            case ObjectType.kOT_Gnome :
                return "ノーム";
                
            case ObjectType.kOT_Skip :
                return "スキップ";
                
            case ObjectType.kOT_Tent :
                return "テント";
                
            case ObjectType.kOT_Scarecrow :
                return "カカシ";
                
            case ObjectType.kOT_Venus :
                return "";
                
            case ObjectType.kOT_Elephant :
                return "";
                
            case ObjectType.kOT_Snake :
                return "";
                
            case ObjectType.kOT_Lion :
                return "";
                
            case ObjectType.kOT_FarmRamp :
                return "";
                
            case ObjectType.kOT_MudPuddle2x1 :
                return "泥溜まり";
                
            case ObjectType.kOT_MudPuddle1x1 :
                return "泥溜まり";
                
            case ObjectType.kOT_House :
                return "お家";
                
            case ObjectType.kOT_BushLilac :
                return "";
                
            case ObjectType.kOT_BushPink :
                return "";
                
            case ObjectType.kOT_ChimneyLeft :
                return "";
                
            case ObjectType.kOT_ChimneyRight :
                return "";
                
            case ObjectType.kOT_WallFarmYard :
                return "石壁";
                
            case ObjectType.kOT_Welly :
                return "ウェリー";
                
            default :
                break;
            }

            return "";
        }		

        string GetString(ObjectType inType)
        {
            switch (Globals.g_currentLanguage) {
            case World.Enum11.kLanguage_China :
                return this.GetStringChinese(inType);
            case World.Enum11.kLanguage_Japanese :
                return this.GetStringJapanese(inType);
            case World.Enum11.kLanguage_French :
                return this.GetStringFrench(inType);
            default :
                Globals.Assert(false);
                break;
            }

            return "";
        }

        public void ChangeObjectNameNSString(ObjectType inType)
        {
            (funnyWord[(int)Enum.kLBWord_Object]).ChangeTextNew(this.GetString(inType));
            (funnyWord[(int)Enum.kLBWord_Object]).FitToWidth(82.0f);
            (funnyWord[(int)Enum.kLBWord_Object]).Show();
        }

        public void ChangeObjectNameDisplay(ObjectType inType)
        {
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                this.ChangeObjectNameNSString(inType);
                return;
            }

            string[] objectName = new string[(int)ObjectType.Types];
            for (int i = 0; i < (int) ObjectType.Types; i++) objectName[i] = "Dunno\n";

            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                objectName[(int) ObjectType.kOT_Tree] = "Baum\n";
                objectName[(int) ObjectType.kOT_Road] = "Strasse\n";
                objectName[(int) ObjectType.kOT_RoadCrossing] = "Kreuzung\n";
                objectName[(int) ObjectType.kOT_Pond] = "Teich\n";
                objectName[(int) ObjectType.kOT_Rainbow] = "Schub\n";
                objectName[(int) ObjectType.kOT_Flowers] = "Osterglocken\n";
                objectName[(int) ObjectType.kOT_Tulips] = "Tulpen\n";
                objectName[(int) ObjectType.kOT_TulipsYellow] = "Tulpen\n";
                objectName[(int) ObjectType.kOT_TulipsWhite] = "Tulpen\n";
                objectName[(int) ObjectType.kOT_TulipsBlue] = "Tulpen\n";
                objectName[(int) ObjectType.kOT_CrossingShirley] = "Shirley\n";
                objectName[(int) ObjectType.kOT_Bollard] = "Verkehrsh%tchen\n";
                objectName[(int) ObjectType.kOT_River] = "Fluss\n";
                objectName[(int) ObjectType.kOT_Ramp] = "Rampe\n";
                objectName[(int) ObjectType.kOT_Rock] = "Stein\n";
                objectName[(int) ObjectType.kOT_CowLeft] = "Schaf\n";
                objectName[(int) ObjectType.kOT_CowRight] = "Schaf\n";
                objectName[(int) ObjectType.kOT_CowPatSprite] = "Schafk$ttel\n";
                objectName[(int) ObjectType.kOT_HedgeLeft] = "Hecke\n";
                objectName[(int) ObjectType.kOT_HedgeRight] = "Hecke\n";
                objectName[(int) ObjectType.kOT_Bridge1] = "Br%cke\n";
                objectName[(int) ObjectType.kOT_BigRamp] = "Grosse Rampe\n";
                objectName[(int) ObjectType.kOT_Bridge2] = "Br%cke\n";
                objectName[(int) ObjectType.kOT_Puddle] = "Pf%tze\n";
                objectName[(int) ObjectType.kOT_InsertSpace] = "L%cke einf%gen\n";
                objectName[(int) ObjectType.kOT_FinishingLine] = "Finish Line\n";
                objectName[(int) ObjectType.kOT_ArrowLeft] = "Pfeil\n";
                objectName[(int) ObjectType.kOT_ArrowDown] = "Pfeil\n";
                objectName[(int) ObjectType.kOT_ArrowRight] = "Pfeil\n";
                objectName[(int) ObjectType.kOT_BoostArrowDown] = "Picknickdecke\n";
                objectName[(int) ObjectType.kOT_BigRock] = "Heuballen\n";
                objectName[(int) ObjectType.kOT_RemoveSpace] = "L%cke l$schen\n";
                objectName[(int) ObjectType.kOT_Trampoline] = "Trampolin\n";
                objectName[(int) ObjectType.kOT_Barn] = "Scheune\n";
                objectName[(int) ObjectType.kOT_MudPuddle2x2] = "Schlamm\n";
                objectName[(int) ObjectType.kOT_BigSidewaysShed] = "Schuppen\n";
                objectName[(int) ObjectType.kOT_StoneWell] = "Stone Well\n";
                objectName[(int) ObjectType.kOT_HayBaleSingle] = "Hay Bale\n";
                objectName[(int) ObjectType.kOT_HayBaleDouble] = "Hay Bale\n";
                objectName[(int) ObjectType.kOT_Tractor] = "Traktor\n";
                objectName[(int) ObjectType.kOT_BlueTractor] = "Landrover\n";
                objectName[(int) ObjectType.kOT_Cauliflower] = "Blumenkohl\n";
                objectName[(int) ObjectType.kOT_Squash] = "Speisek%rbis\n";
                objectName[(int) ObjectType.kOT_Pumpkin] = "K%rbis\n";
                objectName[(int) ObjectType.kOT_Courgette] = "Zucchini\n";
                objectName[(int) ObjectType.kOT_CrossingTractor] = "Fahrender Traktor\n";
                objectName[(int) ObjectType.kOT_CrossingLandRover] = "Fahrender Landrover\n";
                objectName[(int) ObjectType.kOT_CrossingFlockLeft] = "Laufendes Schaf\n";
                objectName[(int) ObjectType.kOT_CrossingFlockRight] = "Laufendes Schaf\n";
                objectName[(int) ObjectType.kOT_OilDrum] = "Fass\n";
                objectName[(int) ObjectType.kOT_Igloo] = "Igloo\n";
                objectName[(int) ObjectType.kOT_Seal] = "Seal\n";
                objectName[(int) ObjectType.kOT_SmallSnow] = "Small Snow\n";
                objectName[(int) ObjectType.kOT_Chicken] = "Huhn\n";
                objectName[(int) ObjectType.kOT_Waterfall] = "Wasserfall\n";
                objectName[(int) ObjectType.kOT_Log] = "Log\n";
                objectName[(int) ObjectType.kOT_Gnome] = "Zwerg\n";
                objectName[(int) ObjectType.kOT_Skip] = "%berspringen\n";
                objectName[(int) ObjectType.kOT_Tent] = "Zelt\n";
                objectName[(int) ObjectType.kOT_Scarecrow] = "Vogelscheuche\n";
                objectName[(int) ObjectType.kOT_Venus] = "Venus Plant\n";
                objectName[(int) ObjectType.kOT_Elephant] = "Elephant\n";
                objectName[(int) ObjectType.kOT_Snake] = "Snake\n";
                objectName[(int) ObjectType.kOT_Lion] = "Lion\n";
                objectName[(int) ObjectType.kOT_FarmRamp] = "Ramp\n";
                objectName[(int) ObjectType.kOT_MudPuddle2x1] = "Vogelscheuche\n";
                objectName[(int) ObjectType.kOT_MudPuddle1x1] = "Vogelscheuche\n";
                objectName[(int) ObjectType.kOT_House] = "Haus\n";
                objectName[(int) ObjectType.kOT_BushLilac] = "Lilac Bush\n";
                objectName[(int) ObjectType.kOT_BushPink] = "Pink Bush\n";
                objectName[(int) ObjectType.kOT_ChimneyLeft] = "Shed Chimney\n";
                objectName[(int) ObjectType.kOT_ChimneyRight] = "Shed Chimney\n";
                objectName[(int) ObjectType.kOT_WallFarmYard] = "Steinmauer\n";
                objectName[(int) ObjectType.kOT_Welly] = "Gummistiefel\n";
            }
            else {
                objectName[(int) ObjectType.kOT_Tree] = "Tree\n";
                objectName[(int) ObjectType.kOT_Road] = "Road\n";
                objectName[(int) ObjectType.kOT_RoadCrossing] = "Crossing\n";
                objectName[(int) ObjectType.kOT_Pond] = "Pond\n";
                objectName[(int) ObjectType.kOT_Rainbow] = "Boost\n";
                objectName[(int) ObjectType.kOT_Flowers] = "Daffodils\n";
                objectName[(int) ObjectType.kOT_Tulips] = "Tulips\n";
                objectName[(int) ObjectType.kOT_TulipsYellow] = "Tulips\n";
                objectName[(int) ObjectType.kOT_TulipsWhite] = "Tulips\n";
                objectName[(int) ObjectType.kOT_TulipsBlue] = "Tulips\n";
                objectName[(int) ObjectType.kOT_CrossingShirley] = "Shirley\n";
                objectName[(int) ObjectType.kOT_Bollard] = "Cone\n";
                objectName[(int) ObjectType.kOT_River] = "River\n";
                objectName[(int) ObjectType.kOT_Ramp] = "Ramp\n";
                objectName[(int) ObjectType.kOT_Rock] = "Rock\n";
                objectName[(int) ObjectType.kOT_CowLeft] = "Sheep\n";
                objectName[(int) ObjectType.kOT_CowRight] = "Sheep\n";
                objectName[(int) ObjectType.kOT_CowPatSprite] = "Sheep Poo\n";
                objectName[(int) ObjectType.kOT_HedgeLeft] = "Hedge\n";
                objectName[(int) ObjectType.kOT_HedgeRight] = "Hedge\n";
                objectName[(int) ObjectType.kOT_Bridge1] = "Bridge\n";
                objectName[(int) ObjectType.kOT_BigRamp] = "Big Ramp\n";
                objectName[(int) ObjectType.kOT_Bridge2] = "Bridge\n";
                objectName[(int) ObjectType.kOT_Puddle] = "Puddle\n";
                objectName[(int) ObjectType.kOT_InsertSpace] = "Insert Space\n";
                objectName[(int) ObjectType.kOT_FinishingLine] = "Finish Line\n";
                objectName[(int) ObjectType.kOT_ArrowLeft] = "Arrow\n";
                objectName[(int) ObjectType.kOT_ArrowDown] = "Arrow\n";
                objectName[(int) ObjectType.kOT_ArrowRight] = "Arrow\n";
                objectName[(int) ObjectType.kOT_BoostArrowDown] = "Picnic Blanket\n";
                objectName[(int) ObjectType.kOT_BigRock] = "Hay Bale\n";
                objectName[(int) ObjectType.kOT_RemoveSpace] = "Remove Space\n";
                objectName[(int) ObjectType.kOT_Trampoline] = "Trampoline\n";
                objectName[(int) ObjectType.kOT_Barn] = "Barn\n";
                objectName[(int) ObjectType.kOT_MudPuddle2x2] = "Mud\n";
                objectName[(int) ObjectType.kOT_BigSidewaysShed] = "Shed\n";
                objectName[(int) ObjectType.kOT_StoneWell] = "Stone Well\n";
                objectName[(int) ObjectType.kOT_HayBaleSingle] = "Hay Bale\n";
                objectName[(int) ObjectType.kOT_HayBaleDouble] = "Hay Bale\n";
                objectName[(int) ObjectType.kOT_Tractor] = "Tractor\n";
                objectName[(int) ObjectType.kOT_BlueTractor] = "Landrover\n";
                objectName[(int) ObjectType.kOT_Cauliflower] = "Cauliflower\n";
                objectName[(int) ObjectType.kOT_Squash] = "Squash\n";
                objectName[(int) ObjectType.kOT_Pumpkin] = "Pumpkin\n";
                objectName[(int) ObjectType.kOT_Courgette] = "Courgette\n";
                objectName[(int) ObjectType.kOT_CrossingTractor] = "Crossing Tractor\n";
                objectName[(int) ObjectType.kOT_CrossingLandRover] = "Crossing Landrover\n";
                objectName[(int) ObjectType.kOT_CrossingFlockLeft] = "Crossing Sheep\n";
                objectName[(int) ObjectType.kOT_CrossingFlockRight] = "Crossing Sheep\n";
                objectName[(int) ObjectType.kOT_OilDrum] = "Barrel\n";
                objectName[(int) ObjectType.kOT_Igloo] = "Igloo\n";
                objectName[(int) ObjectType.kOT_Seal] = "Seal\n";
                objectName[(int) ObjectType.kOT_SmallSnow] = "Small Snow\n";
                objectName[(int) ObjectType.kOT_Chicken] = "Chicken\n";
                objectName[(int) ObjectType.kOT_Waterfall] = "Waterfall\n";
                objectName[(int) ObjectType.kOT_Log] = "Log\n";
                objectName[(int) ObjectType.kOT_Gnome] = "Gnome\n";
                objectName[(int) ObjectType.kOT_Skip] = "Skip\n";
                objectName[(int) ObjectType.kOT_Tent] = "Tent\n";
                objectName[(int) ObjectType.kOT_Scarecrow] = "Scarecrow\n";
                objectName[(int) ObjectType.kOT_Venus] = "Venus Plant\n";
                objectName[(int) ObjectType.kOT_Elephant] = "Elephant\n";
                objectName[(int) ObjectType.kOT_Snake] = "Snake\n";
                objectName[(int) ObjectType.kOT_Lion] = "Lion\n";
                objectName[(int) ObjectType.kOT_FarmRamp] = "Ramp\n";
                objectName[(int) ObjectType.kOT_MudPuddle2x1] = "Big Mud Puddle\n";
                objectName[(int) ObjectType.kOT_MudPuddle1x1] = "Small Mud Puddle\n";
                objectName[(int) ObjectType.kOT_House] = "House\n";
                objectName[(int) ObjectType.kOT_BushLilac] = "Lilac Bush\n";
                objectName[(int) ObjectType.kOT_BushPink] = "Pink Bush\n";
                objectName[(int) ObjectType.kOT_ChimneyLeft] = "Shed Chimney\n";
                objectName[(int) ObjectType.kOT_ChimneyRight] = "Shed Chimney\n";
                objectName[(int) ObjectType.kOT_WallFarmYard] = "Farm Wall\n";
                objectName[(int) ObjectType.kOT_Bucket] = "Bucket\n";
                objectName[(int) ObjectType.kOT_Cart] = "Cart\n";
                objectName[(int) ObjectType.kOT_Welly] = "Welly\n";
                objectName[(int) ObjectType.kOT_Cactus] = "Cactus\n";
                objectName[(int) ObjectType.kOT_Snowdrift] = "Snow\n";
                objectName[(int) ObjectType.kOT_Crater] = "Crater\n";
                objectName[(int) ObjectType.kOT_HayStack] = "Hay Stack\n";
                objectName[(int) ObjectType.kOT_StarSpeedUp] = "Star Speedup\n";
                objectName[(int) ObjectType.kOT_HillockFarmyard] = "Big Hill\n";
                objectName[(int) ObjectType.kOT_SmallBump] = "Small Hill\n";
                objectName[(int) ObjectType.kOT_Crater2x2] = "Medium Crater\n";
                objectName[(int) ObjectType.kOT_Crater1x1] = "Small Crater\n";
                objectName[(int) ObjectType.kOT_Bus] = "Bus\n";
            }

            (funnyWord[(int)Enum.kLBWord_Object]).ChangeText(objectName[(int)inType]);
            (funnyWord[(int)Enum.kLBWord_Object]).FitToWidth(82.0f);
            (funnyWord[(int)Enum.kLBWord_Object]).Show();
        }

        public void FirstInit()
        {
            this.SetupGrassObjects();
            this.SetupMudObjects();
            this.SetupWords();
        }

        public void SetupSceneObjectLists()
        {
            this.SetupSceneObjectListGrass();
            this.SetupSceneObjectListMud();
        }

        public PlacedObjectInfo GetPlacedObject(int i)
        {
            Globals.Assert(i < numPlacedObjects);
            return placedObject[i];
        }

        public void SetPlacedObjectTypeP1(int poId, int inType)
        {
            Globals.Assert(poId < numPlacedObjects);
            placedObject[poId].objectType = (ObjectType)inType;
        }

        public void SetupSceneObjectListGrass()
        {
            const SceneType kSceneType = SceneType.kSceneGrass;
            numOjectsInSceneList[(int)kSceneType] = 0;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_House;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Tree;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Pond;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Puddle;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Rainbow;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_BoostArrowDown;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Tent;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_BigRamp;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Gnome;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Road;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_RoadCrossing;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Rock;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_BigRock;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_CowLeft;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_CowRight;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_CrossingFlockLeft;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_CrossingFlockRight;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Flowers;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Tulips;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_TulipsWhite;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_TulipsYellow;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_TulipsBlue;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Trampoline;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_CowPatSprite;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Bollard;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_River;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_Bridge2;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_HedgeLeft;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_HedgeRight;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_ArrowLeft;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_ArrowDown;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_ArrowRight;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_InsertSpace;
            sceneObjectList[(int)kSceneType, numOjectsInSceneList[(int)kSceneType]++] = (int)ObjectType.kOT_RemoveSpace;
        }

        public void SetupSceneObjectListMud()
        {
            SceneType thisScene = SceneType.kSceneMud;
            numOjectsInSceneList[(int)thisScene] = 0;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Pond;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Skip;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_BigSidewaysShed;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_FarmRamp;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Barn;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Tree;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Tractor;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_BlueTractor;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Chicken;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Trampoline;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Scarecrow;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_HayBaleDouble;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Cauliflower;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Squash;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Pumpkin;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Courgette;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Tulips;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_TulipsWhite;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_TulipsYellow;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_TulipsBlue;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_BigRock;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_CowLeft;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_CowRight;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Welly;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Trampoline;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_OilDrum;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Bollard;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Rainbow;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_BoostArrowDown;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_Road;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_RoadCrossing;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_CrossingTractor;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_CrossingLandRover;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_MudPuddle2x2;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_WallFarmYard;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_ArrowLeft;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_ArrowDown;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_ArrowRight;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_InsertSpace;
            sceneObjectList[(int)thisScene, numOjectsInSceneList[(int)thisScene]++] = (int)ObjectType.kOT_RemoveSpace;
        }

        public void SetupObjectTileRowP1P2P3P4P5(int objectId, int width, int height, int startTilesIndex, int exceptX, int exceptY)
        {
            Globals.Assert(width <= (int)Enum3.kMaxObjectXSize);
            Globals.Assert(height <= (int)Enum3.kMaxObjectYSize);
            objectInfo[objectId].tileWidth = width;
            objectInfo[objectId].tileHeight = height;
            int numTilesInRow = 16;
            int tileIndex = 0;
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    objectInfo[objectId].objectTile[x, y] = -1;
                    if ((x != exceptX) || (y != exceptY)) {
                        objectInfo[objectId].objectTile[x, y] = startTilesIndex + x + (y * numTilesInRow);
                        tileIndex++;
                    }

                }

            }

        }

        public void SetupObjectTileRowP1P2P3(int objectId, int width, int height, int startTilesIndex)
        {
            this.SetupObjectTileRowP1P2P3P4P5(objectId, width, height, startTilesIndex, -1, -1);
        }

        int GetTileMapStartTileId(int whichAtlas)
        {
            if (whichAtlas == (int) AtlasType.kAtlas_MudTiles) {
                return (int)TileMap.Enum1.kTile_FarmAtlasFirstTile;
            }
            else if (whichAtlas == (int) AtlasType.kAtlas_GrassTiles) {
                return 0;
            }
            else if (whichAtlas == (int) AtlasType.kAtlas_MudSpriteTiles) {
                return (int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile;
            }
            else if (whichAtlas == (int) AtlasType.kAtlas_MudTiles3) {
                return (int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile;
            }
            else if (whichAtlas == (int) AtlasType.kAtlas_DesertTiles) {
                return (int)TileMap.Enum1.kTileStartOfDesertAtlas;
            }
            else if (whichAtlas == (int) AtlasType.kAtlas_IceTiles) {
                return (int)TileMap.Enum1.kTileStartOfIceAtlas;
            }
            else if (whichAtlas == (int) AtlasType.kAtlas_MoonTiles) {
                return (int)TileMap.Enum1.kTileStartOfMoonAtlas;
            }
            else {
                Globals.Assert(false);
            }
			return 0;

        }

        public void SetupObjectWithAtlasP1P2P3P4P5P6P7P8(int whichScene, int whichAtlas, int objectId, int startX, int startY, int width, int height, int
          exceptX, int exceptY)
        {
            Globals.Assert(width <= (int)Enum3.kMaxObjectXSize);
            Globals.Assert(height <= (int)Enum3.kMaxObjectYSize);
            objectInfo[objectId].tileWidth = width;
            objectInfo[objectId].tileHeight = height;
            int numTilesInRow = 0;
            int tileMapStart = 0;
            if (whichAtlas != -1) {
                numTilesInRow = Globals.g_world.GetNumTilesInRow(whichAtlas);
                tileMapStart = this.GetTileMapStartTileId(whichAtlas);
            }
            else {
                if (whichScene == (int) SceneType.kSceneMud) {
                    if (whichAtlas == (int) AtlasType.kAtlas_MudTiles) {
                        tileMapStart = (int)TileMap.Enum1.kTile_FarmAtlasFirstTile;
                        numTilesInRow = 16;
                    }
                    else {
                        tileMapStart = (int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile;
                        numTilesInRow = 8;
                    }

                }
                else if (whichScene == (int) SceneType.kSceneDesert) {
                    tileMapStart = (int)TileMap.Enum1.kTileStartOfDesertAtlas;
                    numTilesInRow = 8;
                }
                else if (whichScene == (int) SceneType.kSceneIce) {
                    tileMapStart = (int)TileMap.Enum1.kTileStartOfIceAtlas;
                    numTilesInRow = 16;
                }
                else if (whichScene == (int) SceneType.kSceneMoon) {
                    tileMapStart = (int)TileMap.Enum1.kTileStartOfMoonAtlas;
                    numTilesInRow = 8;
                }
                else {
                    Globals.Assert(false);
                }

            }

            int tileIndex = 0;
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    objectInfo[objectId].objectTile[x, y] = -1;
                    if ((x != exceptX) || (y != exceptY)) {
                        int tileId = (startY * numTilesInRow) + startX + x + (y * numTilesInRow);
                        tileId += tileMapStart;
                        objectInfo[objectId].objectTile[x, y] = tileId;
                        tileIndex++;
                    }

                }

            }

        }

        public void SetupObjectWithGapP1P2P3P4P5P6P7(int whichScene, int objectId, int startX, int startY, int width, int height, int exceptX, int exceptY)
        {
            if (whichScene == (int) SceneType.kSceneMud) {
                this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8(whichScene, (int) AtlasType.kAtlas_MudTiles, objectId, startX, startY, width, height, exceptX, 
                  exceptY);
            }
            else if (whichScene == (int) SceneType.kSceneMoon) {
                this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8(whichScene, (int) AtlasType.kAtlas_MoonTiles, objectId, startX, startY, width, height, exceptX,
                  exceptY);
            }
            else {
                this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8(whichScene, -1, objectId, startX, startY, width, height, exceptX, exceptY);
            }

        }

        public void SetupObjectP1P2P3P4P5(int whichScene, int objectId, int startX, int startY, int width, int height)
        {
            this.SetupObjectWithGapP1P2P3P4P5P6P7(whichScene, objectId, startX, startY, width, height, -1, -1);
        }

        public void SetupSpriteP1P2(int objectId, int atlasId, int inSubTextureId)
        {
            objectInfo[objectId].isSprite = true;
            objectInfo[objectId].atlas = Globals.g_world.GetAtlas(atlasId);
            objectInfo[objectId].subTextureId = (short)inSubTextureId;
        }

        public void SetupShed()
        {
            this.SetupObjectWithGapP1P2P3P4P5P6P7((int) SceneType.kSceneMud, (int) ObjectType.kOT_BigSidewaysShed ,(int)Enum1.kAtlasShedX ,(int)Enum1.kAtlasShedY, 4, 8, 3, 0);
            for (int y = 0; y < 5; y++) {
                objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[3, y + 1] = objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[2, y + 1];
            }

            for (int y = 0; y < 6; y++) {
                objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[1, y] = objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[0, y];
                objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[2, y] = objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[0, y];
            }

        }

        public void SetupHouse()
        {
            this.SetupObjectWithGapP1P2P3P4P5P6P7((int) SceneType.kSceneMud, (int) ObjectType.kOT_House ,(int)Enum1.kAtlasHouseX ,(int)Enum1.kAtlasHouseY, 6, 5, 5, 0);
        }

        public void SetupGrassObjects()
        {
            int inAtlas = (int) AtlasType.kAtlas_GrassTiles;
            objectInfo[(int) ObjectType.kOT_InsertSpace].tileWidth = 1;
            objectInfo[(int) ObjectType.kOT_InsertSpace].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_InsertSpace].objectTile[0, 0] = (int)TileMap.Enum1.kTile_LB_InsertSpace;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].tileWidth = 1;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].objectTile[0, 0] = (int)TileMap.Enum1.kTile_LB_RemoveSpace;
            objectInfo[(int) ObjectType.kOT_FinishingLine].tileWidth = 6;
            objectInfo[(int) ObjectType.kOT_FinishingLine].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[0, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 6);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[1, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 6);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[2, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 6);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[3, 0] = this.GetTileMapTileP1P2(inAtlas, 8, 6);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[4, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 6);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[5, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 6);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_Pond, 0, 2, 3, 3, -1
              , -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_Rock, 3, 5, 2, 1, -1
              , -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_BigRock, 0, 6, 3, 2,
              -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_BigRamp, 11, 6, 3, 2
              , -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_Tree, 2, 1, 3, 2, 0,
              1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_ArrowLeft, 0, 1, 1, 1
              , -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_ArrowDown, 1, 1, 1, 1
              , -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_ArrowRight, 2, 5, 1,
              1, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_House, 5, 1, 6, 5, 
              -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_Bridge2, 12, 0, 3, 6
              , -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, inAtlas, (int) ObjectType.kOT_Tent, 4, 9, 3, 2, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, inAtlas, (int) ObjectType.kOT_Puddle, 3, 3, 2, 2, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, inAtlas, (int) ObjectType.kOT_Trampoline, 7, 9, 3, 4, -1, -1);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Gnome, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_Gnome);
            objectInfo[(int) ObjectType.kOT_River].tileWidth = 6;
            objectInfo[(int) ObjectType.kOT_River].tileHeight = 6;
            for (int x = 0; x < 6; x++) {
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 0] = this.GetTileMapTileP1P2(inAtlas, 15, 0);
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 1] = this.GetTileMapTileP1P2(inAtlas, 15, 1);
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 2] = this.GetTileMapTileP1P2(inAtlas, 15, 2);
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 3] = this.GetTileMapTileP1P2(inAtlas, 15, 3);
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 4] = this.GetTileMapTileP1P2(inAtlas, 15, 4);
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 5] = this.GetTileMapTileP1P2(inAtlas, 15, 5);
            }

            objectInfo[(int) ObjectType.kOT_Road].tileWidth = 6;
            objectInfo[(int) ObjectType.kOT_Road].tileHeight = 3;
            for (int x = 0; x < 6; x++) {
                objectInfo[(int) ObjectType.kOT_Road].objectTile[x, 0] = this.GetTileMapTileP1P2(inAtlas, 2, 8);
                objectInfo[(int) ObjectType.kOT_Road].objectTile[x, 1] = this.GetTileMapTileP1P2(inAtlas, 2, 9);
                objectInfo[(int) ObjectType.kOT_Road].objectTile[x, 2] = this.GetTileMapTileP1P2(inAtlas, 2, 10);
            }

            objectInfo[(int) ObjectType.kOT_RoadCrossing].tileWidth = 2;
            objectInfo[(int) ObjectType.kOT_RoadCrossing].tileHeight = 3;
            for (int x = 0; x < 2; x++) {
                objectInfo[(int) ObjectType.kOT_RoadCrossing].objectTile[x, 0] = this.GetTileMapTileP1P2(inAtlas, 0 + x, 8);
                objectInfo[(int) ObjectType.kOT_RoadCrossing].objectTile[x, 1] = this.GetTileMapTileP1P2(inAtlas, 0 + x, 9);
                objectInfo[(int) ObjectType.kOT_RoadCrossing].objectTile[x, 2] = this.GetTileMapTileP1P2(inAtlas, 0 + x, 10);
            }

            this.SetupSpriteP1P2((int) ObjectType.kOT_Rainbow, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_Rainbow);
            this.SetupSpriteP1P2((int) ObjectType.kOT_BoostArrowDown, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_PicnicBlanket);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CrossingFlockLeft, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_CowLeft1);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CrossingFlockRight, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_CowRight1);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CowLeft, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_CowLeft2);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CowRight, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_CowRight2);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Flowers, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_Flowers);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Tulips, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_TulipsRed);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CowPatSprite, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_SheepPoo);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Bollard, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_Bollard);
            this.SetupSpriteP1P2((int) ObjectType.kOT_TulipsWhite, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_TulipWhite);
            this.SetupSpriteP1P2((int) ObjectType.kOT_TulipsYellow, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_TulipsYellow);
            this.SetupSpriteP1P2((int) ObjectType.kOT_TulipsBlue, (int) AtlasType.kAtlas_GameThingsGrass ,(int)World.Enum3.kGTGrass_TulipsBlue);
            objectInfo[(int) ObjectType.kOT_HedgeLeft].tileWidth = 7;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[0, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[1, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[2, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[3, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[4, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[5, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[6, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 7);
            objectInfo[(int) ObjectType.kOT_HedgeRight].tileWidth = 7;
            objectInfo[(int) ObjectType.kOT_HedgeRight].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[0, 0] = this.GetTileMapTileP1P2(inAtlas, 8, 7);
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[1, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[2, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[3, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[4, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[5, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[6, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 7);
        }

        public void SetupMudObjects()
        {
            int inAtlas = (int) AtlasType.kAtlas_MudTiles;
            SceneType inScene = SceneType.kSceneMud;
            objectInfo[(int) ObjectType.kOT_InsertSpace].tileWidth = 1;
            objectInfo[(int) ObjectType.kOT_InsertSpace].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_InsertSpace].objectTile[0, 0] = (int)TileMap.Enum1.kTile_LB_InsertSpace;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].tileWidth = 1;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].objectTile[0, 0] = (int)TileMap.Enum1.kTile_LB_RemoveSpace;
            objectInfo[(int) ObjectType.kOT_FinishingLine].tileWidth = 6;
            objectInfo[(int) ObjectType.kOT_FinishingLine].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[0, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[1, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[2, 0] = this.GetTileMapTileP1P2(inAtlas, 11, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[3, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[4, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLine].objectTile[5, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLineFarm].tileWidth = 6;
            objectInfo[(int) ObjectType.kOT_FinishingLineFarm].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_FinishingLineFarm].objectTile[0, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLineFarm].objectTile[1, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLineFarm].objectTile[2, 0] = this.GetTileMapTileP1P2(inAtlas, 11, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLineFarm].objectTile[3, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLineFarm].objectTile[4, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_FinishingLineFarm].objectTile[5, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_WallFarmYard].tileWidth = 6;
            objectInfo[(int) ObjectType.kOT_WallFarmYard].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_WallFarmYard].objectTile[0, 0] = this.GetTileMapTileP1P2(inAtlas, 9, 5);
            objectInfo[(int) ObjectType.kOT_WallFarmYard].objectTile[1, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_WallFarmYard].objectTile[2, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_WallFarmYard].objectTile[3, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_WallFarmYard].objectTile[4, 0] = this.GetTileMapTileP1P2(inAtlas, 10, 5);
            objectInfo[(int) ObjectType.kOT_WallFarmYard].objectTile[5, 0] = this.GetTileMapTileP1P2(inAtlas, 11, 5);
            objectInfo[(int) ObjectType.kOT_Road].tileWidth = 6;
            objectInfo[(int) ObjectType.kOT_Road].tileHeight = 3;
            for (int x = 0; x < 6; x++) {
                objectInfo[(int) ObjectType.kOT_Road].objectTile[x, 0] = this.GetTileMapTileP1P2(inAtlas, 2, 8);
                objectInfo[(int) ObjectType.kOT_Road].objectTile[x, 1] = this.GetTileMapTileP1P2(inAtlas, 2, 9);
                objectInfo[(int) ObjectType.kOT_Road].objectTile[x, 2] = this.GetTileMapTileP1P2(inAtlas, 2, 10);
            }

            objectInfo[(int) ObjectType.kOT_RoadCrossing].tileWidth = 2;
            objectInfo[(int) ObjectType.kOT_RoadCrossing].tileHeight = 3;
            for (int x = 0; x < 2; x++) {
                objectInfo[(int) ObjectType.kOT_RoadCrossing].objectTile[x, 0] = this.GetTileMapTileP1P2(inAtlas, x, 8);
                objectInfo[(int) ObjectType.kOT_RoadCrossing].objectTile[x, 1] = this.GetTileMapTileP1P2(inAtlas, x, 9);
                objectInfo[(int) ObjectType.kOT_RoadCrossing].objectTile[x, 2] = this.GetTileMapTileP1P2(inAtlas, x, 10);
            }

            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_Pond, 13, 5, 3, 3, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_BigSidewaysShed, 0, 0, 4, 8, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_Tree, 13, 3, 3, 2, 0, 1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_Skip, 10, 3, 3, 2, 2, 0);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_ArrowLeft, 12, 1, 1, 1, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_ArrowDown, 13, 1, 1, 1, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_ArrowRight, 14, 1, 1, 1, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_FarmRamp, 5, 2, 3, 2, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_MudPuddle2x2, 9, 6, 2, 2, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_Barn, 4, 4, 5, 5, 4, 0);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int)inScene, inAtlas, (int) ObjectType.kOT_Trampoline, 9, 8, 3, 4, -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneMud, (int) AtlasType.kAtlas_MudTiles, (int) ObjectType.kOT_BigRock, 8, 1, 3, 2, -1,
              -1);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Tractor, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_Tractor);
            this.SetupSpriteP1P2((int) ObjectType.kOT_BlueTractor, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_LandRover);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CrossingTractor, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_Tractor);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CrossingLandRover, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_LandRover);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Scarecrow, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_ScareCrow);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Cauliflower, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_CauliFlower);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Squash, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_Squash);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Pumpkin, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_Pumpkin);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Courgette, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_Courgette);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Chicken, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_ChickenPeck1);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Rainbow, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_Rainbow);
            this.SetupSpriteP1P2((int) ObjectType.kOT_HayBaleDouble, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_HayBaleSingle);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CowLeft, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_CowRight2);
            this.SetupSpriteP1P2((int) ObjectType.kOT_CowRight, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_CowLeft2);
            this.SetupSpriteP1P2((int) ObjectType.kOT_BoostArrowDown, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_PicnicBlanket);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Welly, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_Welly);
            this.SetupSpriteP1P2((int) ObjectType.kOT_OilDrum, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_Barrel);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Bollard, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_TrafficCone);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Tulips, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_TulipsRed);
            this.SetupSpriteP1P2((int) ObjectType.kOT_TulipsWhite, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_TulipWhite);
            this.SetupSpriteP1P2((int) ObjectType.kOT_TulipsYellow, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_TulipsYellow);
            this.SetupSpriteP1P2((int) ObjectType.kOT_TulipsBlue, (int) AtlasType.kAtlas_GameThingsMud ,(int)World.Enum2.kGTMud_TulipsBlue);
        }

        public void SetupVenus()
        {
        }

        public void SetupJungleObjects()
        {
            this.SetupWaterfallP1((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles);
  //          this.SetupSpriteP1P2((int) ObjectType.kOT_Log, (int) AtlasType.kAtlas_GameThingsGrass ,(int)Enum2.kGTJungle_Log);
//            this.SetupSpriteP1P2((int) ObjectType.kOT_Elephant, (int) AtlasType.kAtlas_GameThingsGrass ,(int)Enum2.kGTJungle_Elephant);
    //        this.SetupSpriteP1P2((int) ObjectType.kOT_Snake, (int) AtlasType.kAtlas_GameThingsGrass ,(int)Enum2.kGTJungle_Snake1);
            this.SetupVenus();
            objectInfo[(int) ObjectType.kOT_InsertSpace].tileWidth = 1;
            objectInfo[(int) ObjectType.kOT_InsertSpace].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_InsertSpace].objectTile[0, 0] = (int)TileMap.Enum1.kTile_LB_InsertSpace;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].tileWidth = 1;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_RemoveSpace].objectTile[0, 0] = (int)TileMap.Enum1.kTile_LB_RemoveSpace;
            this.SetupFinishingLineP1((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_Tree, 10, 0, 5, 1, 
              -1, -1);
            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_TreeGreen, 10, 0, 5,
              2, -1, -1);
            objectInfo[(int) ObjectType.kOT_Cliff2].tileWidth = 3;
            objectInfo[(int) ObjectType.kOT_Cliff2].tileHeight = 2;
            objectInfo[(int) ObjectType.kOT_Cliff2].objectTile[0, 0] = (int)TileMap.Enum1.kTile_GrassCliff4;
            objectInfo[(int) ObjectType.kOT_Cliff2].objectTile[1, 0] = (int)TileMap.Enum1.kTile_GrassCliff5;
            objectInfo[(int) ObjectType.kOT_Cliff2].objectTile[2, 0] = (int)TileMap.Enum1.kTile_GrassCliff6;
            objectInfo[(int) ObjectType.kOT_Cliff2].objectTile[0, 1] = (int)TileMap.Enum1.kTile_Grass;
            objectInfo[(int) ObjectType.kOT_Cliff2].objectTile[1, 1] = (int)TileMap.Enum1.kTile_Grass;
            objectInfo[(int) ObjectType.kOT_Cliff3].tileWidth = 7;
            objectInfo[(int) ObjectType.kOT_Cliff3].tileHeight = 2;
            objectInfo[(int) ObjectType.kOT_Cliff3].objectTile[0, 0] = (int)TileMap.Enum1.kTile_GrassCliff4;
            objectInfo[(int) ObjectType.kOT_Cliff3].objectTile[1, 0] = (int)TileMap.Enum1.kTile_Grass;
            objectInfo[(int) ObjectType.kOT_Cliff3].objectTile[2, 0] = (int)TileMap.Enum1.kTile_Grass;
            objectInfo[(int) ObjectType.kOT_Cliff3].objectTile[3, 0] = (int)TileMap.Enum1.kTile_Grass;
            objectInfo[(int) ObjectType.kOT_Cliff3].objectTile[4, 0] = (int)TileMap.Enum1.kTile_Grass;
            objectInfo[(int) ObjectType.kOT_Cliff3].objectTile[5, 0] = (int)TileMap.Enum1.kTile_GrassCliff5;
            objectInfo[(int) ObjectType.kOT_Cliff3].objectTile[6, 0] = (int)TileMap.Enum1.kTile_GrassCliff6;
            for (int n = 0; n < 7; n++) {
                objectInfo[(int) ObjectType.kOT_Cliff2].objectTile[n, 1] = (int)TileMap.Enum1.kTile_Grass;
            }

            this.SetupObjectWithAtlasP1P2P3P4P5P6P7P8((int) SceneType.kSceneGrass, (int) AtlasType.kAtlas_GrassTiles, (int) ObjectType.kOT_Pond, 0, 2, 3, 3, -1
              , -1);
            objectInfo[(int) ObjectType.kOT_Puddle].tileWidth = 2;
            objectInfo[(int) ObjectType.kOT_Puddle].tileHeight = 2;
            int d = 0;
            for (int y = 0; y < 2; y++) for (int x = 0; x < 2; x++) {
                objectInfo[(int) ObjectType.kOT_Puddle].objectTile[x, y] = (int)TileMap.Enum1.kTile_Puddle1 + x + (y * 8);
                d++;
            }

            objectInfo[(int) ObjectType.kOT_BoostArrowDown].isSprite = true;
            objectInfo[(int) ObjectType.kOT_BoostArrowDown].atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass);
            objectInfo[(int) ObjectType.kOT_BoostArrowDown].subTextureId = 6;
            objectInfo[(int) ObjectType.kOT_Rainbow].isSprite = true;
            objectInfo[(int) ObjectType.kOT_Rainbow].atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass);
            objectInfo[(int) ObjectType.kOT_Rainbow].subTextureId = 3;
       //     this.SetupSpriteP1P2((int) ObjectType.kOT_Flowers, (int) AtlasType.kAtlas_GameThingsGrass ,(int)Enum2.kGTJungle_FlowersPurp);
            this.SetupSpriteP1P2((int) ObjectType.kOT_Bollard, (int) AtlasType.kAtlas_GameThingsGrass, 27);
            objectInfo[(int) ObjectType.kOT_CowLeft].isSprite = true;
            objectInfo[(int) ObjectType.kOT_CowLeft].atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass);
            objectInfo[(int) ObjectType.kOT_CowLeft].subTextureId = 2;
            objectInfo[(int) ObjectType.kOT_CowRight].isSprite = true;
            objectInfo[(int) ObjectType.kOT_CowRight].atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass);
            objectInfo[(int) ObjectType.kOT_CowRight].subTextureId = 1;
            objectInfo[(int) ObjectType.kOT_CowPatSprite].isSprite = true;
            objectInfo[(int) ObjectType.kOT_CowPatSprite].atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass);
            objectInfo[(int) ObjectType.kOT_CowPatSprite].subTextureId = 4;
            objectInfo[(int) ObjectType.kOT_BigRock].tileWidth = 3;
            objectInfo[(int) ObjectType.kOT_BigRock].tileHeight = 2;
            objectInfo[(int) ObjectType.kOT_BigRock].objectTile[0, 0] = (int)TileMap.Enum1.kTile_BigRock1;
            objectInfo[(int) ObjectType.kOT_BigRock].objectTile[1, 0] = (int)TileMap.Enum1.kTile_BigRock2;
            objectInfo[(int) ObjectType.kOT_BigRock].objectTile[2, 0] = (int)TileMap.Enum1.kTile_BigRock3;
            objectInfo[(int) ObjectType.kOT_BigRock].objectTile[0, 1] = (int)TileMap.Enum1.kTile_BigRock4;
            objectInfo[(int) ObjectType.kOT_BigRock].objectTile[1, 1] = (int)TileMap.Enum1.kTile_BigRock5;
            objectInfo[(int) ObjectType.kOT_BigRock].objectTile[2, 1] = (int)TileMap.Enum1.kTile_BigRock6;
            objectInfo[(int) ObjectType.kOT_River].tileWidth = 6;
            objectInfo[(int) ObjectType.kOT_River].tileHeight = 6;
            for (int x = 0; x < 6; x++) {
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 0] = (int)TileMap.Enum1.kTile_FlowerCliff;
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 1] = (int)TileMap.Enum1.kTile_WaterShadow1;
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 2] = (int)TileMap.Enum1.kTile_WaterRiver;
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 3] = (int)TileMap.Enum1.kTile_WaterRiver;
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 4] = (int)TileMap.Enum1.kTile_WaterRiver;
                objectInfo[(int) ObjectType.kOT_River].objectTile[x, 5] = (int)TileMap.Enum1.kTile_WaterToNormal;
            }

            objectInfo[(int) ObjectType.kOT_Bridge1].tileWidth = 2;
            objectInfo[(int) ObjectType.kOT_Bridge1].tileHeight = 6;
            {
                objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[0, 0] = (int)TileMap.Enum1.kTile_BridgeStart;
                objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[0, 1] = (int)TileMap.Enum1.kTile_Bridge1;
                objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[0, 2] = (int)TileMap.Enum1.kTile_Bridge2;
                objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[0, 3] = (int)TileMap.Enum1.kTile_Bridge1;
                objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[0, 4] = (int)TileMap.Enum1.kTile_Bridge2;
                objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[0, 5] = (int)TileMap.Enum1.kTile_Bridge1;
            }
            objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[1, 0] = (int)TileMap.Enum1.kTile_FlowerCliff;
            objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[1, 1] = (int)TileMap.Enum1.kTile_WaterShadow2;
            objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[1, 2] = (int)TileMap.Enum1.kTile_WaterShadow3;
            objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[1, 3] = (int)TileMap.Enum1.kTile_WaterShadow3;
            objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[1, 4] = (int)TileMap.Enum1.kTile_WaterShadow3;
            objectInfo[(int) ObjectType.kOT_Bridge1].objectTile[1, 5] = (int)TileMap.Enum1.kTile_OtherBankWaterShadow;
            objectInfo[(int) ObjectType.kOT_Bridge2].tileWidth = 3;
            objectInfo[(int) ObjectType.kOT_Bridge2].tileHeight = 6;
            for (int x = 0; x < 2; x++) {
                objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[0 + x, 0] = (int)TileMap.Enum1.kTile_BridgeStart;
                objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[0 + x, 1] = (int)TileMap.Enum1.kTile_Bridge1;
                objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[0 + x, 2] = (int)TileMap.Enum1.kTile_Bridge2;
                objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[0 + x, 3] = (int)TileMap.Enum1.kTile_Bridge1;
                objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[0 + x, 4] = (int)TileMap.Enum1.kTile_Bridge2;
                objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[0 + x, 5] = (int)TileMap.Enum1.kTile_Bridge1;
            }

            objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[2, 0] = (int)TileMap.Enum1.kTile_FlowerCliff;
            objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[2, 1] = (int)TileMap.Enum1.kTile_WaterShadow2;
            objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[2, 2] = (int)TileMap.Enum1.kTile_WaterShadow3;
            objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[2, 3] = (int)TileMap.Enum1.kTile_WaterShadow3;
            objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[2, 4] = (int)TileMap.Enum1.kTile_WaterShadow3;
            objectInfo[(int) ObjectType.kOT_Bridge2].objectTile[2, 5] = (int)TileMap.Enum1.kTile_OtherBankWaterShadow;
            objectInfo[(int) ObjectType.kOT_Ramp].tileWidth = 2;
            objectInfo[(int) ObjectType.kOT_Ramp].tileHeight = 2;
            objectInfo[(int) ObjectType.kOT_Ramp].objectTile[0, 0] = (int)TileMap.Enum1.kTile_Ramp1;
            objectInfo[(int) ObjectType.kOT_Ramp].objectTile[1, 0] = (int)TileMap.Enum1.kTile_WideRamp3;
            objectInfo[(int) ObjectType.kOT_Ramp].objectTile[0, 1] = (int)TileMap.Enum1.kTile_Ramp2;
            objectInfo[(int) ObjectType.kOT_Ramp].objectTile[1, 1] = (int)TileMap.Enum1.kTile_WideRamp6;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].tileWidth = 7;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[0, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[1, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[2, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[3, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[4, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[5, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeLeft].objectTile[6, 0] = (int)TileMap.Enum1.kTile_GatePostLeft;
            objectInfo[(int) ObjectType.kOT_HedgeRight].tileWidth = 7;
            objectInfo[(int) ObjectType.kOT_HedgeRight].tileHeight = 1;
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[0, 0] = (int)TileMap.Enum1.kTile_GatePostRight;
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[1, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[2, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[3, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[4, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[5, 0] = (int)TileMap.Enum1.kTile_Hedge;
            objectInfo[(int) ObjectType.kOT_HedgeRight].objectTile[6, 0] = (int)TileMap.Enum1.kTile_Hedge;
        }

        public int GetRandomTileFromSquareP1P2(int whichScene, CGPoint topLeft, CGPoint rectSize)
        {
            int whichAtlas;
            if (whichScene == (int) SceneType.kSceneGrass) whichAtlas = (int)AtlasType.kAtlas_GrassTiles;
            else {
                whichAtlas = (int)AtlasType.kAtlas_MudTiles;
            }

            int randX = Utilities.GetRand( ((int) rectSize.x));
            int randY = Utilities.GetRand( ((int) rectSize.y));
            int tileId = this.GetTileMapTileP1P2(whichAtlas, randX + (int) topLeft.x, randY + (int) topLeft.y);
            return tileId;
        }

        public int GetTileMapTileP1P2(int whichAtlas, int x, int y)
        {
            int tileMapStart = this.GetTileMapStartTileId(whichAtlas);
            int numTilesInRow = Globals.g_world.GetNumTilesInRow(whichAtlas);
            int tileId = (y * numTilesInRow) + x;
            tileId += tileMapStart;
            return tileId;
        }

        public void SetupFinishingLineP1(int inScene, int inAtlas)
        {
            ObjectType kObjectType = ObjectType.kOT_FinishingLine;
            const int kTileMapX = 5;
            const int kTileMapY = 4;
            objectInfo[(int)kObjectType].tileWidth = 6;
            objectInfo[(int)kObjectType].tileHeight = 1;
            objectInfo[(int)kObjectType].objectTile[0, 0] = this.GetTileMapTileP1P2(inAtlas ,(int)kTileMapX ,(int)kTileMapY);
            objectInfo[(int)kObjectType].objectTile[1, 0] = this.GetTileMapTileP1P2(inAtlas ,(int)kTileMapX ,(int)kTileMapY);
            objectInfo[(int)kObjectType].objectTile[2, 0] = this.GetTileMapTileP1P2(inAtlas ,(int)kTileMapX + 2 ,(int)kTileMapY);
            objectInfo[(int)kObjectType].objectTile[3, 0] = (int)TileMap.Enum1.kTile_Grass;
            objectInfo[(int)kObjectType].objectTile[4, 0] = this.GetTileMapTileP1P2(inAtlas ,(int)kTileMapX ,(int)kTileMapY);
            objectInfo[(int)kObjectType].objectTile[5, 0] = this.GetTileMapTileP1P2(inAtlas ,(int)kTileMapX ,(int)kTileMapY);
        }

        public void SetupWaterfallP1(int inScene, int inAtlas)
        {
            ObjectType kObjectType =  ObjectType.kOT_Waterfall;
            const int kTileMapX = 8;
            const int kTileMapY = 4;
            objectInfo[(int)kObjectType].tileWidth = 10;
            objectInfo[(int)kObjectType].tileHeight = 4;
            for (int x = 0; x < 7; x++) {
                objectInfo[(int)kObjectType].objectTile[3 + x, 1] = this.GetTileMapTileP1P2(inAtlas ,(int)kTileMapX + 3 ,(int)kTileMapY + 1);
                objectInfo[(int)kObjectType].objectTile[3 + x, 2] = this.GetTileMapTileP1P2(inAtlas ,(int)kTileMapX + 3 ,(int)kTileMapY + 2);
            }

        }

        public void SetupObjects()
        {
            for (int i = 0; i < (int) ObjectType.Types; i++) {
                objectInfo[i].isSprite = false;
                for (int x = 0; x < (int) objectInfo[i].tileWidth; x++) {
                    for (int y = 0; y < (int) objectInfo[i].tileHeight; y++) {
                        objectInfo[i].objectTile[x, y] = -1;
                    }

                }

            }

            if (currentScene == (int) SceneType.kSceneMud) {
                this.SetupMudObjects();
            }
            else if (currentScene == (int) SceneType.kSceneGrass) {
                this.SetupGrassObjects();
            }
            else if (currentScene == (int) SceneType.kSceneSavanna) {
            }
            else if (currentScene == (int) SceneType.kSceneJungle) {
                this.SetupJungleObjects();
            }
            else if (currentScene == (int) SceneType.kSceneDesert) {
            }
            else if (currentScene == (int) SceneType.kSceneIce) {
            }
            else if (currentScene == (int) SceneType.kSceneMoon) {
            }
            else {
                Globals.Assert(false);
            }

        }

        public void SetupButtons()
        {
            float kYPos = 454;
            const float kXPos = 164;
            const float kInfoXPos = 42;
            float kPickableTileY = 434.0f;
            if (Globals.deviceIPad) {
                kYPos = 462.0f;
                kPickableTileY += 26.0f;
            }

            FrontEnd.ButtonInfo info = new FrontEnd.ButtonInfo();
            info.textureLabel = null;
            for (int i = 0; i < (int)Enum3.kNumPickableTiles; i++) {
                pickableObjectPosition[i] = Utilities.CGPointMake(kXPos - 10 ,(int)kPickableTileY);
                info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_Right);
                info.position = Utilities.CGPointMake(kXPos + 58 ,(int)kYPos);
                (upButton[i]).Initialise(info);
                info.position = Utilities.CGPointMake(kXPos - 58 ,(int)kYPos);
                info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_Left);
                (downButton[i]).Initialise(info);
                (upButton[i]).SetWidth(64);
                (downButton[i]).SetWidth(64);
                (upButton[i]).SetHeight(64);
                (downButton[i]).SetHeight(64);
                ((downButton[i]).zobject).SetShowScale(kLBSmallerButtonMinScale);
                ((upButton[i]).zobject).SetShowScale(kLBSmallerButtonMinScale);
                ((upButton[i]).zobject).SetThrobSize(0.1f);
                ((downButton[i]).zobject).SetThrobSize(0.1f);
                (upButton[i]).Show();
                (downButton[i]).Show();
            }

            info.position = Utilities.CGPointMake(kXRightSide + 5, 116);
            if (Globals.deviceIPad) {
                info.position.y -= 16.0f;
                info.position.x -= 2.0f;
            }

            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_CopyButton);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).Initialise(info);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).SetHeight(64);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).SetWidth(64);
            info.texture = null;
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_MoveButton);
            }

            (button[(int) LevelBuilder_RossButtons.kLBButton_Move]).Initialise(info);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_Move]).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_Move]).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_Immediate);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_Immediate);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Move]).SetHeight(64);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Move]).SetWidth(64);
            info.position = Utilities.CGPointMake(kXRightSide + 3.0f, 32.0f);
            if (Globals.deviceIPad) {
                info.position.y -= 16.0f;
            }

            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_TrashCan);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Trash]).Initialise(info);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_Trash]).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            info.position = Utilities.CGPointMake(32.0f ,(int)kYPos - 2.0f);
            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_DeleteAll);
            (button[(int) LevelBuilder_RossButtons.kLBButton_DeleteAll]).Initialise(info);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_DeleteAll]).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (button[(int) LevelBuilder_RossButtons.kLBButton_DeleteAll]).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_DeleteAll]).zobject).SetShowScale(kLBButtonMinScale);
            info.position = Utilities.CGPointMake(kXRightSide ,(int)kYPos);
            if (Globals.deviceIPad) {
                info.position.x -= 32.0f;
            }

            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_Done);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Done]).Initialise(info);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_Done]).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Done]).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_Done]).zobject).SetShowScale(kLBButtonMinScale);
            info.position = Utilities.CGPointMake(kInfoXPos ,(int)kYPos);
            info.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_ButtonInfo);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Info]).Initialise(info);
            (button[(int) LevelBuilder_RossButtons.kLBButton_Info]).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            ((button[(int) LevelBuilder_RossButtons.kLBButton_Info]).zobject).SetShowScale(kLBSmallerButtonMinScale);
            FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
            qInfo.position = Utilities.CGPointMake(160, 240);
            qInfo.boxDimensions = Utilities.CGPointMake(200, 200);
            qInfo.backdropTexture = (Globals.g_world.frontEnd).GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_QueryBackdrop);
            qInfo.noButton = (Globals.g_world.frontEnd).GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_QueryNo);
            qInfo.yesButton = (Globals.g_world.frontEnd).GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_QueryYes);
            qInfo.useActualText = true;
            qInfo.dimTexture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureDimOverlay);
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                qInfo.theInfo1 = "Ende\n";
                qInfo.theInfo2 = "\n";
                qInfo.theInfo3 = "#nderungen speichern?\n";
            }
            else {
                qInfo.theInfo1 = "quit\n";
                qInfo.theInfo2 = "\n";
                qInfo.theInfo3 = "save your changes?\n";
            }

            qInfo.theInfo4 = "\n";
            qInfo.theInfo5 = "\n";
            qInfo.theInfo6 = "\n";
            qInfo.theInfo7 = "\n";
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndQuery.QueryInfoNew nqInfo = new FrontEndQuery.QueryInfoNew();
                nqInfo.backdropTexture = qInfo.backdropTexture;
                nqInfo.boxDimensions = Utilities.CGSizeMake(240.0f, 100.0f);
                nqInfo.noButton = qInfo.noButton;
                nqInfo.yesButton = qInfo.yesButton;
                nqInfo.inTextScale = 26.0f;
                nqInfo.newStyleWithAtlas = false;
                nqInfo.position = qInfo.position;
				nqInfo.numButtons = 0;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    nqInfo.queryText = "退出，是否保存你的改变？";
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                    nqInfo.queryText = "Quitter, sauvegarder les modifications ?";
                }
                else {
                    nqInfo.boxDimensions = Utilities.CGSizeMake(240.0f, 100.0f);
                    nqInfo.queryText = "変更をセーブ、終了しますか？";
                }

                (query[(int) LevelBuilder_RossQueries.kLBQuery_QuitAndWrite]).InitialiseNew(nqInfo);
            }
            else {
                (query[(int) LevelBuilder_RossQueries.kLBQuery_QuitAndWrite]).Initialise(qInfo);
            }

            (query[(int) LevelBuilder_RossQueries.kLBQuery_QuitAndWrite]).SetWordScale(0.38f);
            (query[(int) LevelBuilder_RossQueries.kLBQuery_QuitAndWrite]).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.
              GetAtlas( AtlasType.kAtlas_FontColours));
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                qInfo.theInfo1 = "Gesamtes\n";
                qInfo.theInfo2 = "Level leeren?\n";
            }
            else {
                qInfo.theInfo1 = "clear\n";
                qInfo.theInfo2 = "the entire level?\n";
            }

            qInfo.theInfo3 = "\n";
            qInfo.theInfo4 = "\n";
            qInfo.theInfo5 = "\n";
            qInfo.theInfo6 = "\n";
            qInfo.theInfo7 = "\n";
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndQuery.QueryInfoNew nqInfo = new FrontEndQuery.QueryInfoNew();
                nqInfo.backdropTexture = qInfo.backdropTexture;
                nqInfo.boxDimensions = Utilities.CGSizeMake(240.0f, 100.0f);
                nqInfo.noButton = qInfo.noButton;
                nqInfo.yesButton = qInfo.yesButton;
                nqInfo.inTextScale = 26.0f;
                nqInfo.newStyleWithAtlas = false;
                nqInfo.position = qInfo.position;
				nqInfo.numButtons = 0;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    nqInfo.queryText = "清除这整个关卡？";
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                    nqInfo.queryText = "Supprimer tout le niveau ?";
                }
                else {
                    nqInfo.inTextScale = 24.0f;
                    nqInfo.boxDimensions = Utilities.CGSizeMake(240.0f, 100.0f);
                    nqInfo.queryText = "すべてのレベルをリセットしますか？";
                }

                (query[(int) LevelBuilder_RossQueries.kLBQuery_DeleteObjects]).InitialiseNew(nqInfo);
            }
            else {
                (query[(int) LevelBuilder_RossQueries.kLBQuery_DeleteObjects]).Initialise(qInfo);
            }

            (query[(int) LevelBuilder_RossQueries.kLBQuery_DeleteObjects]).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.
              GetAtlas( AtlasType.kAtlas_FontColours));
            qInfo.noButton = null;
            qInfo.yesButton = (Globals.g_world.frontEnd).GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_QueryOk);
            qInfo.useActualText = true;
            qInfo.theInfo1 = "the bridge\n";
            qInfo.theInfo2 = "must be\n";
            qInfo.theInfo3 = "placed on water\n";
            qInfo.theInfo4 = "\n";
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndQuery.QueryInfoNew nqInfo = new FrontEndQuery.QueryInfoNew();
                nqInfo.backdropTexture = qInfo.backdropTexture;
                nqInfo.boxDimensions = Utilities.CGSizeMake(240.0f, 100.0f);
                nqInfo.noButton = qInfo.noButton;
                nqInfo.yesButton = qInfo.yesButton;
                nqInfo.inTextScale = 26.0f;
                nqInfo.newStyleWithAtlas = false;
                nqInfo.position = qInfo.position;
				nqInfo.numButtons = 0;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    nqInfo.queryText = "移动终点线，使跑道更长。";
                }
                else {
                    nqInfo.inTextScale = 26.0f;
                    nqInfo.boxDimensions = Utilities.CGSizeMake(240.0f, 100.0f);
                    nqInfo.queryText = "もっと長いトラックへ終了線を動かして下さい。";
                }

                (query[(int) LevelBuilder_RossQueries.kLBQuery_InfoBridge]).InitialiseNew(nqInfo);
            }
            else {
                (query[(int) LevelBuilder_RossQueries.kLBQuery_InfoBridge]).Initialise(qInfo);
            }

            (query[(int) LevelBuilder_RossQueries.kLBQuery_InfoBridge]).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.
              GetAtlas( AtlasType.kAtlas_FontColours));
            qInfo.theInfo1 = "you may not\n";
            qInfo.theInfo2 = "place more of\n";
            qInfo.theInfo3 = "these objects\n";
            qInfo.theInfo4 = "\n";
            (query[(int) LevelBuilder_RossQueries.kLBQuery_TooManyObjects]).Initialise(qInfo);
            (query[(int) LevelBuilder_RossQueries.kLBQuery_TooManyObjects]).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.
              GetAtlas( AtlasType.kAtlas_FontColours));
            (query[(int) LevelBuilder_RossQueries.kLBQuery_TooManyObjects]).SetupTileBox(Globals.g_world.GetAtlas( AtlasType.kAtlas_InfoBubbles));
        }

        public void PostProcessChangeTileP1P2P3(int objectId, int tileId, int xOffset, int yOffset)
        {
            int x = (int)placedObject[objectId].position.x + xOffset;
            int y = (int)placedObject[objectId].position.y + yOffset;
            (((Globals.g_world.game).tileMap).GetTileGrid()).SetTileIdP1P2(x, y, tileId);
        }

        public void PostProcessingShedsP1(int i, int j)
        {
            if (placedObject[i].position.y == (placedObject[j].position.y + 6.0f)) {
                if (placedObject[i].position.x == placedObject[j].position.x) {
                    const int kTileSheds1 = (int)TileMap.Enum1.kTile_FarmAtlasFirstTile + 14;
                    this.PostProcessChangeTileP1P2P3(i ,(int)kTileSheds1, 3, 1);
                }
                else if ((placedObject[i].position.x == (placedObject[j].position.x - 1.0f)) || (placedObject[i].position.x == (placedObject[j].position.x -
                  2.0f))) {
                    const int kTileSheds2 = (int)TileMap.Enum1.kTile_FarmAtlasFirstTile + 15;
                    this.PostProcessChangeTileP1P2P3(i ,(int)kTileSheds2, 3, 1);
                }
                else if (placedObject[i].position.x == (placedObject[j].position.x - 3.0f)) {
                    const int kTileSheds2 = (int)TileMap.Enum1.kTile_FarmAtlasFirstTile + 31;
                    this.PostProcessChangeTileP1P2P3(i ,(int)kTileSheds2, 3, 1);
                }

            }

        }

        public void PostProcessCliffP1P2(int i, int cliffBelowId, int cliffAboveId)
        {
  /*          float leftEdge = placedObject[i].position.x;
            float leftEdgeBelow = placedObject[cliffBelowId].position.x;
            float width = 0.0f;
            float widthBelow = 0.0f;
            const int kNumTilesToMaybeChange = 10;
            int[] newTileId = new int[(int)kNumTilesToMaybeChange];
            for (int n = 0; n < (int)kNumTilesToMaybeChange; n++) {
                newTileId[n] = -1;
            }

            switch (placedObject[i].objectType) {
            case ObjectType.kOT_Cliff2 :
                width = 2.0f;
                break;
            case ObjectType.kOT_Cliff3 :
                width = 6.0f;
                break;
            case ObjectType.kOT_Cliff4 :
                width = 4.0f;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            float rightEdge = leftEdge + width;
            int rightEdgeTile = (int) width + 1;
            if (cliffBelowId != -1) {
                switch (placedObject[cliffBelowId].objectType) {
                case ObjectType.kOT_Cliff2 :
                    widthBelow = 2.0f;
                    break;
                case ObjectType.kOT_Cliff3 :
                    widthBelow = 6.0f;
                    break;
                case ObjectType.kOT_Cliff4 :
                    widthBelow = 4.0f;
                    break;
                default :
                    Globals.Assert(false);
                    break;
                }

                float rightEdgeBelow = leftEdgeBelow + widthBelow;
                if (leftEdge == leftEdgeBelow) {
                }
                else if (leftEdge == (leftEdgeBelow + 1)) {
                }
                else if (leftEdge == (leftEdgeBelow - 1)) {
                    newTileId[1] = (int)TileMap.Enum1.kTile_GrassCliff7;
                }

                if (rightEdge == (rightEdgeBelow - 1)) {
                    newTileId[rightEdgeTile - 1] = (int)TileMap.Enum1.kTile_GrassCliff8;
                    newTileId[rightEdgeTile] = (int)TileMap.Enum1.kTile_GrassCliff9;
                }
                else if (rightEdge == (rightEdgeBelow + 1)) {
                }

                if (cliffAboveId == -1) {
                    newTileId[1] = (int)TileMap.Enum1.kTile_StartGrassCliff;
                    if (width > 2.0f) {
                        for (int n = 0; n < 4; n++) {
                            newTileId[n + 2] = (int)TileMap.Enum1.kTile_Grass;
                        }

                        newTileId[6] = (int)TileMap.Enum1.kTile_GrassCliff2;
                        newTileId[7] = (int)TileMap.Enum1.kTile_GrassCliff3;
                    }
                    else {
                        newTileId[2] = (int)TileMap.Enum1.kTile_GrassCliff2;
                        newTileId[3] = (int)TileMap.Enum1.kTile_GrassCliff3;
                    }

                }

            }

            if (cliffAboveId != -1) {
                float leftEdgeAbove = placedObject[cliffAboveId].position.x;
                float widthAbove;
                switch (placedObject[cliffAboveId].objectType) {
                case ObjectType.kOT_Cliff2 :
                    widthAbove = 2.0f;
                    break;
                case ObjectType.kOT_Cliff3 :
                    widthAbove = 6.0f;
                    break;
                case ObjectType.kOT_Cliff4 :
                    widthAbove = 4.0f;
                    break;
                default :
                    Globals.Assert(false);
                    break;
                }

                if (leftEdgeAbove == (leftEdge + 1.0f)) {
                    newTileId[1] = (int)TileMap.Enum1.kTile_GrassCliff11;
                    newTileId[rightEdgeTile - 1] = (int)TileMap.Enum1.kTile_GrassCliff12;
                    newTileId[rightEdgeTile] = (int)TileMap.Enum1.kTile_GrassCliff14;
                    newTileId[rightEdgeTile + 1] = (int)TileMap.Enum1.kTile_GrassCliff6;
                }
                else if (leftEdgeAbove == (leftEdge - 1.0f)) {
                    newTileId[0] = (int)TileMap.Enum1.kTile_GrassCliff19;
                }

                int x = rightEdge;
                int y = placedObject[cliffAboveId].position.y;
                int mapTileType = (((Globals.g_world.game).tileMap).GetTileGrid()).GetTileIdP1(x, y);
                int mapTileTypeback1 = (((Globals.g_world.game).tileMap).GetTileGrid()).GetTileIdP1(x - 1, y);
                if (mapTileType == TileMap.Enum1.kTile_GrassCliff14) {
                    newTileId[rightEdgeTile] = (int)TileMap.Enum1.kTile_GrassCliff16;
                    newTileId[rightEdgeTile + 1] = (int)TileMap.Enum1.kTile_GrassCliff17;
                }

                if (mapTileTypeback1 == TileMap.Enum1.kTile_GrassCliff9) {
                    newTileId[rightEdgeTile] = (int)TileMap.Enum1.kTile_GrassCliff10;
                }

            }

            if (cliffBelowId == -1) {
                newTileId[1] = (int)TileMap.Enum1.kTile_GrassCliff18;
                newTileId[2] = (int)TileMap.Enum1.kTile_GrassCliff23;
                if (width > 2.0f) {
                    newTileId[2] = (int)TileMap.Enum1.kTile_GrassCliff18;
                    newTileId[3] = (int)TileMap.Enum1.kTile_GrassCliff18;
                    newTileId[4] = (int)TileMap.Enum1.kTile_GrassCliff18;
                    newTileId[5] = (int)TileMap.Enum1.kTile_GrassCliff18;
                    newTileId[6] = (int)TileMap.Enum1.kTile_GrassCliff23;
                }

            }

            for (int n = 0; n < (int)kNumTilesToMaybeChange; n++) {
                if (newTileId[n] != -1) {
                    (((Globals.g_world.game).tileMap).GetTileGrid()).SetTileIdP1P2(((int) placedObject[i].position.x) - 1 + n, (int) placedObject[i].position.y,
                      newTileId[n]);
                }

            }
*/

        }

        public void PostProcessingCliff(int i)
        {
            int cliffAboveId = -1;
            int cliffBelowId = -1;
            for (int j = 0; j < numPlacedObjects; j++) {
                if (i == j) continue;

                if ((placedObject[j].objectType >= ObjectType.kOT_Cliff2) && (placedObject[j].objectType <= ObjectType.kOT_Cliff4)) {
                    if (placedObject[j].position.y == (placedObject[i].position.y + 1)) {
                        cliffBelowId = j;
                    }
                    else if (placedObject[j].position.y == (placedObject[i].position.y - 1)) {
                        cliffAboveId = j;
                    }

                }

            }

            if ((cliffAboveId != -1) || (cliffBelowId != -1)) {
                this.PostProcessCliffP1P2(i, cliffBelowId, cliffAboveId);
            }
        }

        public void PostTileProcessing()
        {
            for (int i = 0; i < numPlacedObjects; i++) {
                if (placedObject[i].objectType == ObjectType.kOT_BigSidewaysShed) {
                    for (int j = 0; j < numPlacedObjects; j++) {
                        if (i == j) {
                            continue;
                        }

                        if (placedObject[j].objectType == ObjectType.kOT_BigSidewaysShed) {
                            this.PostProcessingShedsP1(i, j);
                        }

                    }

                }
                else if ((placedObject[i].objectType >= ObjectType.kOT_Cliff2) && (placedObject[i].objectType <= ObjectType.kOT_Cliff4)) {
                    this.PostProcessingCliff(i);
                }

            }

        }

        public void Setup(int level)
        {
			if (level != -1)
			{
				spriteBillboardPickable.SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_GameThingsGrass));
				spriteBillboardPickable.SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_GameThingsGrass),0);
	
				spriteBillboardCarried.SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_GameThingsGrass));
				spriteBillboardCarried.SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_GameThingsGrass),0);
		
				spriteBillboardPickable.myObject.layer = LayerMask.NameToLayer("tiles");
				spriteBillboardCarried.myObject.layer = LayerMask.NameToLayer("tiles");
				
				
				Globals.g_world.game.tileMap.StartLevelBuilder(Globals.g_world.GetAtlas(AtlasType.kAtlas_GrassTiles));

				Globals.g_world.tileCam.enabled = true;
				
				float x = pickableObjectPosition[0].x;
				float y = pickableObjectPosition[0].y;
				
				Scissor.DoGLScissor(Globals.g_world.tileCam,x,y,60.0f,60.0f);
			}			
			
            finishObject = 0;
            goTooFarTimer = 0.0f;
            levelBuilderFinished = false;
            copySet = false;
            tileMapMoveVelocity = 0;
            tileMapOffset = 0;
            prevTileMapOffset = 0;
            state = LevelBuilder_RossState.kLBState_FingerDownInLimbo;
            inQuery = false;
            currentIndexSceneList = 0;
            pickableObjectType[0] = (ObjectType)sceneObjectList[currentScene, currentIndexSceneList];
            this.SetupButtons();
            this.SetupObjects();
            for (int i = 0; i < (int) LevelBuilder_RossButtons.kNumLBButtons; i++) {
                (button[i]).Disappear();
                (button[i]).Update();
            }

            (button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).Hide();
            (button[(int) LevelBuilder_RossButtons.kLBButton_Move]).Show();
            (button[(int) LevelBuilder_RossButtons.kLBButton_Trash]).Show();
            (button[(int) LevelBuilder_RossButtons.kLBButton_DeleteAll]).Show();
            (button[(int) LevelBuilder_RossButtons.kLBButton_Done]).Show();
            (button[(int) LevelBuilder_RossButtons.kLBButton_Info]).Show();
            (button[(int) LevelBuilder_RossButtons.kLBButton_Scroll]).Show();
            for (int i = 0; i < (int) LevelBuilder_RossButtons.kNumLBButtons; i++) {
                (button[i]).Update();
            }

            for (int i = 0; i < (int)Enum.kLBNumFunnyWords; i++) {
                (funnyWord[i]).Show();
            }

            this.SetupLinkedObjects();
            if (level != -1) {
                this.ChangeTrackNameDisplay();
                this.ChangeObjectNameDisplay(pickableObjectType[0]);
            }

        }

        public ObjectType GetObjectFromTileId(int inTile)
        {
            for (int i = 0; i < numOjectsInSceneList[currentScene]; i++) {
                int objectTypeId = sceneObjectList[currentScene, i];
                if (objectInfo[(int)objectTypeId].isSprite) {
                    continue;
                }

                if ((objectTypeId != (int) ObjectType.kOT_House) && (objectTypeId != (int) ObjectType.kOT_Barn) && (objectTypeId != (int) ObjectType.
                  kOT_BigSidewaysShed) && (objectTypeId != (int) ObjectType.kOT_Road) && (objectTypeId != (int) ObjectType.kOT_RoadCrossing)) {
                    continue;
                }

                int xSize;
                if (objectTypeId == (int) ObjectType.kOT_Road) {
                    xSize = 1;
                }
                else if (objectTypeId == (int) ObjectType.kOT_RoadCrossing) {
                    xSize = (int) objectInfo[(int)objectTypeId].tileWidth;
                }
                else {
                    xSize = (int) objectInfo[(int)objectTypeId].tileWidth - 1;
                }

                for (int x = 0; x < xSize; x++) {
                    for (int y = 0; y < (int) objectInfo[(int)objectTypeId].tileHeight; y++) {
                        int thisTileId = objectInfo[(int)objectTypeId].objectTile[x, y];
                        if (thisTileId == inTile) {
                            return (ObjectType)objectTypeId;
                        }

                    }

                }

            }

            return (ObjectType)(-1);
        }

        public void SetCurrentSceneFromLevelP1(int levelToLoad, bool inLevelBuilder_Ross)
        {
            Dictionary<string,int> dict = this.GetLevelDictionaryP1(levelToLoad, inLevelBuilder_Ross);
            string string1;
            string1 = String.Format("sceneType");
			int myInt = 0;//(dict.ObjectForKey(string1)).IntValue();
            if (myInt > 1) {
                currentScene = myInt - 1;
            }
            else {
                this.SetCurrentSceneFromLevelForceP1(levelToLoad, inLevelBuilder_Ross);
            }

        }

        public void SetCurrentSceneFromLevelForceP1(int levelToLoad, bool inLevelBuilder_Ross)
        {
            if (levelToLoad < 8) {
                currentScene = (int)SceneType.kSceneGrass;
            }
            else if (levelToLoad < 16) {
                currentScene = (int)SceneType.kSceneMud;
            }
            else {
                {
                    if (levelToLoad < 18) currentScene = (int)SceneType.kSceneGrass;
                    else if (levelToLoad < 20) currentScene = (int)SceneType.kSceneMud;
                    else if (levelToLoad == 20) currentScene = (int)SceneType.kSceneGrass;
                    else if (levelToLoad == 21) currentScene = (int)SceneType.kSceneGrass;
                    else if (levelToLoad == 22) currentScene = (int)SceneType.kSceneMud;
                    else if (levelToLoad == 23) currentScene = (int)SceneType.kSceneGrass;

                }
            }

            if (Constants.ALWAYS_LOAD_ != -1) {
                currentScene = Constants.ALWAYS_LOAD_;
            }

        }

        public void SetupLinkedObjects()
        {
            for (int i = 0; i < numPlacedObjects; i++) {
                if ((placedObject[i].objectType != ObjectType.kOT_Tree) && (placedObject[i].objectType != ObjectType.kOT_TreeGreen) && (
                  placedObject[i].objectType != ObjectType.kOT_Elephant)) {
                    placedObject[i].linkedToObject = -1;
                }

                if ((placedObject[i].objectType == ObjectType.kOT_Bridge1) || (placedObject[i].objectType == ObjectType.kOT_Bridge2)) {
                    for (int j = 0; j < numPlacedObjects; j++) {
                        if (i == j) continue;

                        if (placedObject[j].objectType == ObjectType.kOT_River) {
                            if (placedObject[i].position.y == placedObject[j].position.y) {
                                placedObject[i].linkedToObject = j;
                                break;
                            }

                        }

                    }

                }
                else if ((placedObject[i].objectType == ObjectType.kOT_ChimneyLeft) || (placedObject[i].objectType == ObjectType.kOT_ChimneyRight))
                  {
                    for (int j = 0; j < numPlacedObjects; j++) {
                        if (i == j) continue;

                        if (placedObject[j].objectType == ObjectType.kOT_BigSidewaysShed) {
                            if (placedObject[i].position.y == (placedObject[j].position.y + 1.0f)) {
                                placedObject[i].linkedToObject = j;
                                break;
                            }

                        }

                    }

                }

            }

        }

        public void ActuallyWriteLevelToBinaryFile(FileStream fp)
        {
/*            int result;
            result = fwrite((char) (numPlacedObjects), sizeof (int), 1, fp);
            int sceneVal = currentScene + 1;
            result = fwrite((char) (sceneVal), sizeof (int), 1, fp);
            for (int i = 0; i < numPlacedObjects; i++) {
                int val = (int) (placedObject[i].objectType);
                result = fwrite((char) (val), sizeof (int), 1, fp);
                val = (int) (placedObject[i].position.x);
                result = fwrite((char) (val), sizeof (int), 1, fp);
                val = (int) (placedObject[i].position.y);
                result = fwrite((char) (val), sizeof (int), 1, fp);
            }
*/
        }

        public void WriteLevelToDictionary(Dictionary<string,int> dict)
        {
/*            string string1;
            string1 = String.Format("trackName");
            string myName = ((Globals.g_world.frontEnd).profile).GetCustomLevelName();
            dict.SetObjectForKey(myName, string1);
            string1 = String.Format("numObjects");
            NSNumber value;
            value = new NSNumber(numPlacedObjects);
            dict.SetObjectForKey(value, string1);
            string1 = String.Format("sceneType");
            value = new NSNumber(currentScene + 1);
            dict.SetObjectForKey(value, string1);

            #if CREATE_LEVEL_DATA
            #endif

            for (int i = 0; i < numPlacedObjects; i++) {
                string1 = String.Format("objectType%d", i);
                value = new NSNumber((int) (placedObject[i].objectType));
                dict.SetObjectForKey(value, string1);
                string1 = String.Format("objectPosX%d", i);
                value = new NSNumber((int) (placedObject[i].position.x));
                dict.SetObjectForKey(value, string1);
                string1 = String.Format("objectPosY%d", i);
                value = new NSNumber((int) (placedObject[i].position.y));
                dict.SetObjectForKey(value, string1);
            }
*/
        }

        public void RenderSpriteObjectP1P2(ObjectType inType, CGPoint atPos, bool scaled)
        {
            float actualWidth = (objectInfo[(int)inType].atlas).GetSubTextureWidth(objectInfo[(int)inType].subTextureId);
            float actualHeight = (objectInfo[(int)inType].atlas).GetSubTextureHeight(objectInfo[(int)inType].subTextureId);
            float xScale = kPickableObjectSize / (actualWidth * 2.0f);
            float yScale = kPickableObjectSize / (actualHeight * 2.0f);

            #if TEST_VERT_SHORTS
                xScale *= Constants.kScreenMultiplierForShorts;
                yScale *= Constants.kScreenMultiplierForShorts;
            #endif

            if (!scaled) {
                xScale = kShowTileScale;
                yScale = kShowTileScale;
                if (Globals.deviceIPad) {
                    atPos.x += 44.0f;
                    atPos.y += 2.0f;
                }

            }

            float drawScale = Utilities.GetMinP1(xScale, yScale);
            if (scaled) {
                //glEnable (GL_SCISSOR_TEST);
                //glScissor(143, 6, 45, 45);
                if (Globals.deviceIPad) {
                    drawScale *= 2.0f;
                    //glScissor(349, 25, 95, 93);
                }
                else {
                    if ( Globals.useRetina){//(UIScreen.MainScreen()).RespondsToSelector(@selector (scale)) == true && (UIScreen.MainScreen()).scale == 2.00) {
                        //glScissor(286, 12, 90, 90);
                    }
                    else {
                        //glScissor(143, 6, 45, 45);
                    }

                }

                int atlasId = ((Globals.g_world.game).tileMap).GetAtlasIdForThisSceneP1(0, currentScene);
                (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas(atlasId));
                if (currentScene == (int) SceneType.kSceneGrass) ((Globals.g_world.game).tileMap).RenderSquareOfTilesP1P2P3P4(atPos, drawScale, 5, 5, 0);
                else {
                    ((Globals.g_world.game).tileMap).RenderSquareOfTilesP1P2P3P4(atPos, drawScale, 5, 5, 3);
                }

                (DrawManager.Instance()).Flush();
            }

            (DrawManager.Instance()).Begin(objectInfo[(int)inType].atlas);
//            (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(atPos, drawScale, 0, 0, 1.0f, objectInfo[(int)inType].subTextureId);
            (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(spriteBillboardPickable, atPos, drawScale, 0, 0, 1.0f, objectInfo[(int)inType].subTextureId);
            (DrawManager.Instance()).Flush();
            if (scaled) {
                //glDisable (GL_SCISSOR_TEST);
            }

        }

        public void RenderTileObjectP1P2(ObjectType inType, CGPoint atPos, bool scaled)
        {
            const float kIPadXDrawOffset = 40.0f;
            float actualWidth = objectInfo[(int)inType].tileWidth * 64;
            float actualHeight = objectInfo[(int)inType].tileHeight * 64;
            float xScale = kPickableObjectSize / actualWidth;
            float yScale = kPickableObjectSize / actualHeight;
            if (!scaled) {
                xScale = kShowTileScale;
                yScale = kShowTileScale;
            }

            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_CommonLevelBuilder_Ross));
            for (int x = 0; x < (int) objectInfo[(int)inType].tileWidth; x++) {
                for (int y = 0; y < (int) objectInfo[(int)inType].tileHeight; y++) {
                    CGPoint tilePosition;
                    if (!scaled) tilePosition = Utilities.CGPointMake(atPos.x + (x * xScale * 64), (atPos.y + (y * yScale * 64)));
                    else tilePosition = Utilities.CGPointMake(-((xScale*0.5f*((float)objectInfo[(int)inType].tileWidth))) - 8.0f + (64.0f * 0.5f * xScale) + (atPos.x + ((
                      float) x * xScale * 64.0f)), (-((yScale*0.5f*((float)objectInfo[(int)inType].tileHeight))) - 8.0f + (64.0f * 0.5f * yScale) + (atPos.y + (
                      (float) y * yScale * 64.0f))));

                    int tileId = objectInfo[(int)inType].objectTile[x, y];
                    if (!scaled) {
                        if (drag.haveFoundValidDropPosition) {
                            const float kRightEdgeMap = 10.5f;
                            Globals.Assert((float)(Constants.LEVEL_BUILDER_VISIBLE_TILES_WIDTH + 1) > kRightEdgeMap);
                            Globals.Assert((float)(Constants.LEVEL_BUILDER_VISIBLE_TILES_WIDTH - 0) < kRightEdgeMap);
                            float xMinPos;
                            if (Globals.deviceIPad) {
                                xMinPos = -64.0f;
                            }
                            else {
                                xMinPos = 0.0f;
                            }

                            if ((tilePosition.x < xMinPos) || (tilePosition.x > (kRightEdgeMap * (64 * kShowTileScale)))) {
                                tileId = -1;
                            }

                            if (tilePosition.y > Constants.LEVEL_BUILDER_MAP_BOTTOM) {
                                tileId = -1;
                            }

                        }

                        if (Globals.deviceIPad) {
                            tilePosition.x += kIPadXDrawOffset;
                        }

                    }

                    if (tileId != -1) {
                        (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(tilePosition, xScale + 0.1f, yScale + 0.1f, 1);
                    }

                }

            }

            (DrawManager.Instance()).Flush();
            int numAtlasesToRender = ((Globals.g_world.game).tileMap).GetNumAtlasesForThisScene(currentScene);
            int[] atlasIdToRender = new int[10];
            for (int i = 0; i < numAtlasesToRender; i++) {
                atlasIdToRender[i] = ((Globals.g_world.game).tileMap).GetAtlasIdForThisSceneP1(i, currentScene);
            }

            atlasIdToRender[numAtlasesToRender] = (int)AtlasType.kAtlas_CommonLevelBuilder_Ross;
            numAtlasesToRender++;
            for (int i = 0; i < numAtlasesToRender; i++) {
                int useAtlas = atlasIdToRender[i];
                (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas(useAtlas));
                for (int x = 0; x < (int) objectInfo[(int)inType].tileWidth; x++) {
                    for (int y = 0; y < (int) objectInfo[(int)inType].tileHeight; y++) {
                        CGPoint tilePosition;
                        if (!scaled) tilePosition = Utilities.CGPointMake(atPos.x + (x * xScale * 64), (atPos.y + (y * yScale * 64)));
                        else tilePosition = Utilities.CGPointMake(-((xScale*0.5f*((float)objectInfo[(int)inType].tileWidth))) - 8.0f + (64.0f * 0.5f * xScale) + (atPos.x + (
                          (float) x * xScale * 64.0f)), (-((yScale*0.5f*((float)objectInfo[(int)inType].tileHeight))) - 8.0f + (64.0f * 0.5f * yScale) + (atPos.
                          y + ((float) y * yScale * 64.0f))));

                        int tileId = objectInfo[(int)inType].objectTile[x, y];
                        if (!scaled) {
                            const float kRightEdgeMap = 10.5f;
                            float xMinPos;
                            if (Globals.deviceIPad) {
                                xMinPos = -64.0f;
                            }
                            else {
                                xMinPos = 0.0f;
                            }

                            if ((tilePosition.x < xMinPos) || (tilePosition.x > (kRightEdgeMap * (64 * kShowTileScale)))) {
                                tileId = -1;
                            }

                            if (tilePosition.y > Constants.LEVEL_BUILDER_MAP_BOTTOM) {
                                tileId = -1;
                            }

                            if (Globals.deviceIPad) {
                                tilePosition.x += kIPadXDrawOffset;
                            }

                        }

                        if (tileId != -1) {
                            if (((Globals.g_world.game).tileMap).GetAtlasId(tileId) == useAtlas) {
                                (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(tilePosition, xScale, yScale, ((Globals.g_world.game).tileMap).
                                  GetSubTextureId(tileId));
                            }

                        }

                    }

                }

                (DrawManager.Instance()).Flush();
            }

        }

        public ObjectTileInfo GetObjectInfo(ObjectType inType)
        {
            Globals.Assert(inType < ObjectType.Types);
            return objectInfo[(int)inType];
        }

        public void RenderPickableTiles()
        {
            for (int i = 0; i < (int)Enum3.kNumPickableTiles; i++) {
                CGPoint objPos = pickableObjectPosition[i];
                if (Globals.deviceIPad) {
                    objPos.x += 32.0f;
                }

                if (objectInfo[(int)pickableObjectType[i]].isSprite) {
                    objPos.x += 16.0f;
                    objPos.y += 16.0f;
                    this.RenderSpriteObjectP1P2(pickableObjectType[i], objPos, true);
                }
                else {
                    objPos.x -= 2.0f;
                    objPos.y += 2.0f;
                    this.RenderTileObjectP1P2(pickableObjectType[i], objPos, true);
                }

            }

        }

        CGPoint GetScreenPosOfTile(CGPoint inTile)
        {
            if (inTile.y > 1) {
            }

            CGPoint objPos;
            CGPoint mapPos = Utilities.CGPointMake(inTile.x * Constants.TILE_SIZE, inTile.y * Constants.TILE_SIZE);

            #if UP_RACE
                objPos.x = mapPos.x * Constants.LEVEL_BUILDER_TILE_SCALE;
                objPos.x += 16;
                objPos.x += ((-Constants.LEFTMOST_TILE_ON_LB * Constants.TILE_SIZE) * kShowTileScale);
                objPos.y = mapPos.y - tileMapOffset;
                objPos.y -= 92.0f;
                objPos.y += 64.0f;
                objPos.y *= Constants.LEVEL_BUILDER_TILE_SCALE;
                objPos.y = Constants.LEVEL_BUILDER_MAP_BOTTOM - objPos.y;
            #else
                objPos.y = mapPos.y - tileMapOffset;
                objPos.y -= 32.0f;
                objPos.y += (float)(objectInfo[(int)drag.objectType].tileHeight) * Constants.TILE_SIZE;
                objPos.y *= Constants.LEVEL_BUILDER_TILE_SCALE;
                objPos.x = mapPos.x * Constants.LEVEL_BUILDER_TILE_SCALE;
                objPos.x += ((-Constants.LEFTMOST_TILE_ON_LB * Constants.TILE_SIZE) * kShowTileScale);
                objPos.x += (32.0f * Constants.LEVEL_BUILDER_TILE_SCALE);
            #endif

            return objPos;
        }

        public void RenderDragging()
        {
            CGPoint objPos;
            if (!drag.haveFoundValidDropPosition) {
                objPos = touchingPosition;
                objPos.x -= 50;
                objPos.y -= 50;
            }
            else {
                objPos = this.GetScreenPosOfTile(currentDropSquare);
                objPos.y -= (objectInfo[(int)drag.objectType].tileHeight - 1) * Constants.TILE_SIZE * kShowTileScale;
            }

            if (objectInfo[(int)drag.objectType].isSprite) {
                objPos = touchingPosition;
                objPos.x -= 40;
                objPos.y -= 40;
                this.RenderSpriteObjectP1P2(drag.objectType, objPos, false);
            }
            else this.RenderTileObjectP1P2(drag.objectType, objPos, false);

        }

        public void Render()
        {
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glLoadIdentity();
            //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
            if ((state == LevelBuilder_RossState.kLBState_Dragging) || (state == LevelBuilder_RossState.kLBState_DroppingLimbo)) this.RenderDragging();

        }

        public void RenderButtons()
        {
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glLoadIdentity();
            //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
            for (int i = 0; i < (int)Enum3.kNumPickableTiles; i++) {
                (upButton[i]).Render();
                (downButton[i]).Render();
            }

            this.RenderPickableTiles();
            for (int i = 0; i < (int) LevelBuilder_RossButtons.kNumLBButtons; i++) (button[i]).Render();

            for (int i = 0; i < (int)Enum.kLBNumFunnyWords; i++) (funnyWord[i]).Render();

            for (int i = 0; i < (int) LevelBuilder_RossQueries.kNumLBQueries; i++) (query[i]).Render();

        }

        bool IsOnMap(CGPoint pos)
        {
            if (pos.x <= 280.0f) {
                if (pos.y <= 390.0f) {
                    return true;
                }

            }

            return false;
        }

        public void SetState(LevelBuilder_RossState inState)
        {
            state = inState;
            stateTimer = 0;
            switch (inState) {
            case LevelBuilder_RossState.kLBState_FingerDownInLimbo :
                break;
            case LevelBuilder_RossState.kLBState_Dragging :
                break;
            case LevelBuilder_RossState.kLBState_FingerIsUp :
                break;
            default :
                break;
            }

        }

        public void StartDragging(ObjectType inType)
        {
        }

        public void HandleTouchP1(CGPoint pos, WhichTouch whichTouch)
        {
            for (int i = 0; i < (int) LevelBuilder_RossQueries.kNumLBQueries; i++) (query[i]).HandleTap(pos);

            if (whichTouch ==  WhichTouch.kTouchEnded) touchingThisFrame = false;
            else touchingThisFrame = true;

            touchingPosition = pos;
        }

        public void Update_FingerDownInLimbo()
        {
            if (!touchingThisFrame) {
                this.SetState( LevelBuilder_RossState.kLBState_FingerIsUp);
            }

        }

        public void InsertSpace()
        {
            float spritePos = (float)(currentDropSquare.y * 64);
            for (int i = 0; i < numPlacedObjects; i++) {
                if (objectInfo[(int)placedObject[i].objectType].isSprite) {
                    if (placedObject[i].position.y > spritePos) {
                        placedObject[i].position.y += 64;
                        CGPoint newPos = placedObject[i].position;
                        ((Globals.g_world.game).GetMapObject(placedObject[i].mapObjectId)).SetPosition(newPos);
                    }

                }
                else {
                    if (placedObject[i].position.y > currentDropSquare.y) {
                        this.RemoveObjectFromMap(i);
                        placedObject[i].position.y += 1;
                        ((Globals.g_world.game).tileMap).PlaceObjectP1((int)placedObject[i].objectType, placedObject[i].position);
                        this.AddAdditionalSpritesForTileObjects(i);
                        ((Globals.g_world.game).tileMap).RefreshTextures();
                    }

                }

            }

        }

        public void RemoveSpace()
        {
            float spritePos = (float)(currentDropSquare.y * 64);
            for (int i = 0; i < numPlacedObjects; i++) {
                if (objectInfo[(int)placedObject[i].objectType].isSprite) {
                    if (placedObject[i].position.y > spritePos) {
                        placedObject[i].position.y -= 64;
                        CGPoint newPos = placedObject[i].position;
                        ((Globals.g_world.game).GetMapObject(placedObject[i].mapObjectId)).SetPosition(newPos);
                    }

                }
                else {
                    if (placedObject[i].position.y > currentDropSquare.y) {
                        this.RemoveObjectFromMap(i);
                        placedObject[i].position.y -= 1;
                        ((Globals.g_world.game).tileMap).PlaceObjectP1((int)placedObject[i].objectType, placedObject[i].position);
                        this.AddAdditionalSpritesForTileObjects(i);
                        ((Globals.g_world.game).tileMap).RefreshTextures();
                    }

                }

            }

        }

        public void CheckRemoveAdditionalSprites(int i)
        {
            if ((placedObject[i].objectType == ObjectType.kOT_Tree) || (placedObject[i].objectType == ObjectType.kOT_TreeGreen) || (placedObject[i]
              .objectType == ObjectType.kOT_Elephant)) {
                int moId = placedObject[i].linkedToObject;
                if (moId != -1) {
                    (Globals.g_world.game).RemoveFromUsedListP1( ListType.e_RenderAbovePlayer, moId);
                    (Globals.g_world.game).AddToFreeList(moId);
                    placedObject[i].linkedToObject = -1;
                }

            }

        }

        public void AddAdditionalSpritesForTileObjects(int inObjectId)
        {
            if ((placedObject[inObjectId].objectType == ObjectType.kOT_Tree) || (placedObject[inObjectId].objectType == ObjectType.kOT_TreeGreen)) {
                float yOffset = 0;
                float xOffset = 0;
                int spriteId = 0;
                if (currentScene == (int) SceneType.kSceneGrass) {
                    spriteId = (int)World.Enum3.kGTGrass_TreeTop1_WithApples;
                    xOffset = 64.0f;
                    yOffset = -25.0f;
                    if (placedObject[inObjectId].objectType == ObjectType.kOT_Tree) {
                    }

                }
                else if (currentScene == (int) SceneType.kSceneMud) {
                    spriteId = (int)World.Enum2.kGTMud_TreeTop3;
                    xOffset = 64.0f;
                    yOffset = -25.0f;
                }
                else if (currentScene == (int) SceneType.kSceneIce) {
                    yOffset = 41.0f;
                }

                if (Globals.deviceIPad) {
                    xOffset -= 0.0f;
                    yOffset -= 9.0f;
                }

                int moId = (Globals.g_world.game).AddMapObjectP1P2P3(0, (int) (((placedObject[inObjectId].position.x * (64.0f))) + xOffset), (int)(((int) (placedObject[
                  inObjectId].position.y * (64.0f))) + yOffset),  ListType.e_RenderAbovePlayer);
				 ((Globals.g_world.game).GetMapObject(moId)).SetAtlas(Globals.g_world.game.gameThingsAtlas);
                ((Globals.g_world.game).GetMapObject(moId)).SetSubTextureId(spriteId);
                ((Globals.g_world.game).GetMapObject(moId)).SetScale(Constants.SPRITE_BASE_SCALE);
                placedObject[inObjectId].linkedToObject = moId;
            }

            if (placedObject[inObjectId].objectType == ObjectType.kOT_Elephant) {
                float yOffset = 0;
                float xOffset = 0;
                int spriteId = 0;
                if (currentScene == (int) SceneType.kSceneGrass) {
                }
                else if (currentScene == (int) SceneType.kSceneMud) {
//                    spriteId = kGTSavanna_ElephantBody;
                    yOffset = -3.0f;
                    xOffset = 149.0f - 35.0f;
                }
                else if (currentScene == (int) SceneType.kSceneIce) {
                }

                int moId = (Globals.g_world.game).AddMapObjectP1P2P3(0, (int) (((placedObject[inObjectId].position.x * (64.0f))) + xOffset), (int)(( (placedObject[
                  inObjectId].position.y * (64.0f))) - yOffset),  ListType.e_RenderAbovePlayer);
                ((Globals.g_world.game).GetMapObject(moId)).SetSubTextureId(spriteId);
                ((Globals.g_world.game).GetMapObject(moId)).SetScale(Constants.SPRITE_BASE_SCALE);
                placedObject[inObjectId].linkedToObject = moId;
            }

        }

        public void DropInCurrentPosition()
        {
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_ChickenPop);
            placedObject[numPlacedObjects].objectType = drag.objectType;
            placedObject[numPlacedObjects].linkedToObject = -1;
            if (objectInfo[(int)drag.objectType].isSprite) {
                CGPoint dropPos = Utilities.CGPointMake(touchingPosition.x - 40.0f, touchingPosition.y - 40.0f);

                #if UP_RACE
                    dropPos.y = Constants.LEVEL_BUILDER_MAP_BOTTOM - dropPos.y;
                    dropPos.x *= (1 / kShowTileScale);
                    dropPos.y *= (1 / kShowTileScale);
                    dropPos.y += tileMapOffset;
                    dropPos.y -= 26.0f;
                #else
                    dropPos.x *= (1 / kShowTileScale);
                    dropPos.y *= (1 / kShowTileScale);
                    dropPos.y += tileMapOffset;
                    dropPos.x -= 0;
                    dropPos.y += 26;
                    if (Globals.deviceIPad) {
                    }

                #endif

                placedObject[numPlacedObjects].position = dropPos;
                placedObject[numPlacedObjects].mapObjectId = (Globals.g_world.game).AddMapObjectP1P2P3(0, (int) placedObject[numPlacedObjects].position.x, (int)
                  placedObject[numPlacedObjects].position.y,  ListType.e_RenderAbovePlayer);
                ((Globals.g_world.game).GetMapObject(placedObject[numPlacedObjects].mapObjectId)).SetSubTextureId(objectInfo[(int)placedObject[numPlacedObjects].
                  objectType].subTextureId);
                ((Globals.g_world.game).GetMapObject(placedObject[numPlacedObjects].mapObjectId)).SetScale(Constants.SPRITE_BASE_SCALE);
                if ((Globals.g_world.game).IsMapObjectIdInvalid(placedObject[numPlacedObjects].mapObjectId)) {
                    return;
                }

            }
            else {
                if ((drag.objectType != ObjectType.kOT_InsertSpace) && (drag.objectType != ObjectType.kOT_RemoveSpace)) {
                    placedObject[numPlacedObjects].position = currentDropSquare;
                    ((Globals.g_world.game).tileMap).PlaceObjectP1((int)drag.objectType, currentDropSquare);
                    this.AddAdditionalSpritesForTileObjects(numPlacedObjects);
                    if (placedObject[numPlacedObjects].objectType == ObjectType.kOT_FinishingLine) {
                        finishObject = numPlacedObjects;
                    }

                }

            }

            if ((drag.objectType != ObjectType.kOT_InsertSpace) && (drag.objectType != ObjectType.kOT_RemoveSpace)) {
                numPlacedObjects++;
            }
            else {
                if (drag.objectType != ObjectType.kOT_InsertSpace) this.RemoveSpace();
                else this.InsertSpace();

            }

            this.SetupLinkedObjects();
            this.RedrawTileMap();
            this.PostTileProcessing();
            ((Globals.g_world.game).tileMap).RefreshTextures();
        }

        public void RedrawTileMap()
        {
            (((Globals.g_world.game).tileMap).GetTileGrid()).ClearWithGrassyTiles(currentScene);
            ((Globals.g_world.game).tileMap).AddStoneWallP1P2(4, 2, 2);
            List<int> outList = new List<int>(0);
            List<int> yList = new List<int>(0);
            for (int i = 0; i < numPlacedObjects; i++) {
                Utilities.InsertThisObjectIntoOrderedListP1P2P3(i, placedObject[i].position.y, outList, yList);
            }

          //  NSNumber item = null;
            foreach (int item in outList) {
				int i = item;//.IntValue();
                ((Globals.g_world.game).tileMap).PlaceObjectP1((int)placedObject[i].objectType, placedObject[i].position);
            }
            (((Globals.g_world.game).tileMap).tileGrid).AddSideWalls(currentScene);
            (((Globals.g_world.game).tileMap).tileGrid).AddFinishingWallsExtended(currentScene);
        }

        CGPoint GetMapTouchPos(CGPoint inTouch)
        {
            float yMapPos;
            float xPos;

            #if UP_RACE
                float touchingYOffset = ((480.0f - (Constants.GAP_FOR_BOTTOM_BUTTS_ON_LB * Constants.LEVEL_BUILDER_TILE_SCALE)) - inTouch.y);
                float offsetIntoMapCoords = touchingYOffset * (1.0f / Constants.LEVEL_BUILDER_TILE_SCALE);
                yMapPos = tileMapOffset + offsetIntoMapCoords;
                yMapPos += Constants.TILE_SIZE;
                xPos = inTouch.x * (1.0f / Constants.LEVEL_BUILDER_TILE_SCALE);
            #else
                float offsetIntoMapCoords = inTouch.y * (1.0f / Constants.LEVEL_BUILDER_TILE_SCALE);
                yMapPos = tileMapOffset + offsetIntoMapCoords;
                xPos = inTouch.x * (1.0f / Constants.LEVEL_BUILDER_TILE_SCALE);
            #endif

            return Utilities.CGPointMake(xPos, yMapPos);
        }

        CGPoint GetTileSquare(CGPoint inTouch)
        {
            float yMapPos = this.GetMapTouchPos(inTouch).y;
            int outX = (int) (inTouch.x / (64 * kShowTileScale));
            int outY = (int) (yMapPos / (64));
            outX += Constants.LEFTMOST_TILE_ON_LB;
            return Utilities.CGPointMake((float) outX, (float) outY);
        }

        bool IsInTileRectangleP1P2P3(int inTile, int atlasId, CGPoint startTile, CGPoint rectangleSize)
        {
            for (int x = 0; x < rectangleSize.x; x++) {
                for (int y = 0; y < rectangleSize.y; y++) {
                    int xPosOnTileMap = (int)startTile.x + x;
                    int yPosOnTileMap = (int)startTile.y + y;
                    if (inTile == this.GetTileMapTileP1P2(atlasId, xPosOnTileMap, yPosOnTileMap)) {
                        return true;
                    }

                }

            }

            return false;
        }

        bool CanPlaceObectOnSquareP1(ObjectType inType, CGPoint inSquare)
        {
            int width = (int) objectInfo[(int)inType].tileWidth;
            bool ignoreTileId = false;
            if ((inType ==  ObjectType.kOT_Bridge1) || (inType ==  ObjectType.kOT_Bridge2)) {
                width = 6;
                inSquare.x = 0;
                ignoreTileId = true;
            }

         //   #if ZOOMING_MATRIX_TEST
                inSquare.x += Constants.NUM_TILES_NOT_PLAYABLE_TO_LEFT;
         //   #endif

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < (int) objectInfo[(int)inType].tileHeight; y++) {
                    int tileId = objectInfo[(int)inType].objectTile[x, y];
                    if ((tileId != -1) || (ignoreTileId)) {
                        int tileX = ((int) inSquare.x) + x;
                        int tileY = ((int) inSquare.y) + y;
                        int mapTileType = (((Globals.g_world.game).tileMap).GetTileGrid()).GetTileIdP1(tileX, tileY);
                        if (mapTileType == -1) {
                            continue;
                        }

                        switch (inType) {
                        case ObjectType.kOT_Crocodile :
                            if (mapTileType != this.GetTileMapTileP1P2((int) AtlasType.kAtlas_MudTiles, 0, 6)) {
                                return false;
                            }

                            break;
                        case ObjectType.kOT_RoadCrossing :
                            if (currentScene == (int) SceneType.kSceneGrass) {
                                if (!this.IsInTileRectangleP1P2P3(mapTileType, (int) AtlasType.kAtlas_GrassTiles, Utilities.CGPointMake(2, 8), Utilities.CGPointMake(1, 3))) {
                                    return false;
                                }

                            }
                            else {
                                if (!this.IsInTileRectangleP1P2P3(mapTileType, (int) AtlasType.kAtlas_MudTiles, Utilities.CGPointMake(2, 8), Utilities.CGPointMake(1, 3))) {
                                    return false;
                                }

                            }

                            break;
                        case ObjectType.kOT_Bridge1 :
                        case ObjectType.kOT_Bridge2 :
                            if (!this.IsInTileRectangleP1P2P3(mapTileType, (int) AtlasType.kAtlas_GrassTiles, Utilities.CGPointMake(15, 0), Utilities.CGPointMake(1, 6))) {
                                return false;
                            }

                            break;
                        case ObjectType.kOT_InsertSpace :
                        case ObjectType.kOT_RemoveSpace :
                            {
                                return true;
                            }
                            break;
                        case ObjectType.kOT_BigSidewaysShed :
                            {
                                if (!(((Globals.g_world.game).tileMap).GetTileGrid()).IsGrassyTileP1((int) SceneType.kSceneMud, mapTileType)) {
                                    if ((mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[0, 6]) || (mapTileType == objectInfo[(int)
                                      ObjectType.kOT_BigSidewaysShed].objectTile[1, 6]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].
                                      objectTile[2, 6]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[3, 6]) || (mapTileType ==
                                      objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[0, 7]) || (mapTileType == objectInfo[(int) ObjectType.
                                      kOT_BigSidewaysShed].objectTile[1, 7]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[2, 
                                      7]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[3, 7]) || (mapTileType == objectInfo[(
                                      int) ObjectType.kOT_BigSidewaysShed].objectTile[0, 0]) || (mapTileType == objectInfo[(int) 
                                      ObjectType.kOT_BigSidewaysShed].objectTile[1, 0]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].
                                      objectTile[2, 0]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[3, 0]) || (mapTileType ==
                                      objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[0, 1]) || (mapTileType == objectInfo[(int) ObjectType.
                                      kOT_BigSidewaysShed].objectTile[1, 1]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[2, 
                                      1]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[3, 1])) {
                                    }
                                    else {
                                        return false;
                                    }

                                }

                            }
                            break;
                        case ObjectType.kOT_ChimneyLeft :
                            {
                                if ((mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[0, 1]) || (mapTileType == objectInfo[(int)
                                  ObjectType.kOT_BigSidewaysShed].objectTile[0, 2]) || (mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].
                                  objectTile[1, 2])) {
                                }
                                else {
                                    return false;
                                }

                            }
                            break;
                        case ObjectType.kOT_BigRamp :
                            {
                                if (currentScene == (int) SceneType.kSceneGrass) {
                                    if (!(((Globals.g_world.game).tileMap).GetTileGrid()).IsGrassyTileP1(currentScene, mapTileType)) {
                                        if ((mapTileType != objectInfo[(int) ObjectType.kOT_BigRamp].objectTile[0, 0]) && (mapTileType != objectInfo[(int)
                                          ObjectType.kOT_BigRamp].objectTile[0, 1]) && (mapTileType != objectInfo[(int) ObjectType.kOT_BigRamp].objectTile[2, 
                                          0]) && (mapTileType != objectInfo[(int) ObjectType.kOT_BigRamp].objectTile[2, 1])) {
                                            return false;
                                        }

                                    }

                                }
                                else if ((currentScene == (int) SceneType.kSceneMud) || (currentScene == (int) SceneType.kSceneDesert) || (currentScene == (int
                                  ) SceneType.kSceneIce) || (currentScene == (int) SceneType.kSceneMoon)) {
                                    if (!(((Globals.g_world.game).tileMap).GetTileGrid()).IsGrassyTileP1(currentScene, mapTileType)) {
                                        return false;
                                    }

                                }

                            }
                            break;
                        case ObjectType.kOT_FarmRamp :
                            {
                                if (currentScene == (int) SceneType.kSceneMud) {
                                    if (!(((Globals.g_world.game).tileMap).GetTileGrid()).IsGrassyTileP1(currentScene, mapTileType)) {
                                        if ((mapTileType != objectInfo[(int) ObjectType.kOT_FarmRamp].objectTile[0, 0]) && (mapTileType != objectInfo[(int)
                                          ObjectType.kOT_FarmRamp].objectTile[0, 1]) && (mapTileType != objectInfo[(int) ObjectType.kOT_FarmRamp].objectTile[2,
                                          0]) && (mapTileType != objectInfo[(int) ObjectType.kOT_FarmRamp].objectTile[2, 1])) {
                                            return false;
                                        }

                                    }

                                }
                                else if ((currentScene == (int) SceneType.kSceneGrass) || (currentScene == (int) SceneType.kSceneDesert) || (currentScene == (
                                  int) SceneType.kSceneIce) || (currentScene == (int) SceneType.kSceneMoon)) {
                                    if (!(((Globals.g_world.game).tileMap).GetTileGrid()).IsGrassyTileP1(currentScene, mapTileType)) {
                                        return false;
                                    }

                                }

                            }
                            break;
                        case ObjectType.kOT_ChimneyRight :
                            {
                                if ((mapTileType == objectInfo[(int) ObjectType.kOT_BigSidewaysShed].objectTile[2, 1]) || (mapTileType == objectInfo[(int)
                                  ObjectType.kOT_BigSidewaysShed].objectTile[2, 2])) {
                                }
                                else {
                                    return false;
                                }

                            }
                            break;
                        default :
                            if (currentScene == (int) SceneType.kSceneGrass) {
                                if (!(((Globals.g_world.game).tileMap).GetTileGrid()).IsGrassyTileP1(currentScene, mapTileType)) {
                                    return false;
                                }

                            }
                            else if ((currentScene == (int) SceneType.kSceneMud) || (currentScene == (int) SceneType.kSceneDesert) || (currentScene == (int)
                              SceneType.kSceneIce) || (currentScene == (int) SceneType.kSceneMoon)) {
                                if (!(((Globals.g_world.game).tileMap).GetTileGrid()).IsGrassyTileP1(currentScene, mapTileType)) {
                                    return false;
                                }

                            }

                            break;
                        }

                    }

                }

            }

            return true;
        }

        public void Update_DroppingLimbo()
        {
            if (touchingThisFrame) {
                state = LevelBuilder_RossState.kLBState_Dragging;
            }
            else if (stateTimer > 0.2f) {
                if (drag.trashing) {
                    (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Crunch);
                    this.SetState( LevelBuilder_RossState.kLBState_FingerIsUp);
                }
                else if (drag.haveFoundValidDropPosition) {
                    this.DropInCurrentPosition();
                    this.SetState( LevelBuilder_RossState.kLBState_FingerIsUp);
                }
                else {
                    if (drag.objectType == ObjectType.kOT_FinishingLine) {
                        currentDropSquare = pickedUpFromSquare;
                        this.DropInCurrentPosition();
                    }

                    this.SetState( LevelBuilder_RossState.kLBState_FingerIsUp);
                }

                ((button[(int) LevelBuilder_RossButtons.kLBButton_Trash]).zobject).SetShowScale(kLBButtonMinScale);
                drag.trashing = false;
            }

        }

        public void Update_Dragging()
        {
            if (!touchingThisFrame) {
                this.SetState( LevelBuilder_RossState.kLBState_DroppingLimbo);
                return;
            }

            if ((button[(int) LevelBuilder_RossButtons.kLBButton_Trash]).IsTouchedP1((int) touchingPosition.x, (int) touchingPosition.y)) {
                if (drag.objectType != ObjectType.kOT_FinishingLine) {
                    ((button[(int) LevelBuilder_RossButtons.kLBButton_Trash]).zobject).SetShowScale((kLBButtonMinScale * 2.0f));
                    drag.trashing = true;
                }

            }
            else {
                ((button[(int) LevelBuilder_RossButtons.kLBButton_Trash]).zobject).SetShowScale(kLBButtonMinScale);
                drag.trashing = false;
            }

            CGPoint newSquare = this.GetTileSquare(touchingPosition);
            newSquare.x -= drag.tileDragOrigin.x;
            newSquare.y -= drag.tileDragOrigin.y;
            if ((newSquare.x != currentDropSquare.x) || (newSquare.y != currentDropSquare.y)) {
                if ((drag.objectType == ObjectType.kOT_River) || (drag.objectType == ObjectType.kOT_FinishingLine) || (drag.objectType ==
                  ObjectType.kOT_Road)) {
                    newSquare.x = 0;
                }

                if (drag.objectType == ObjectType.kOT_FinishingLine) {
                    if (newSquare.y > 600) newSquare.y = 600;

                    if (newSquare.y < 10) newSquare.y = 10;

                }

                if (this.CanPlaceObectOnSquareP1(drag.objectType, newSquare)) {
                    currentDropSquare = newSquare;
                    drag.haveFoundValidDropPosition = true;
                }
                else {
                    if (drag.objectType == ObjectType.kOT_RoadCrossing) {
                        float yOffset = drag.tileDragOrigin.y;
                        for (int i = 0; i < 3; i++) {
                            CGPoint fakeNewSquare = Utilities.CGPointMake(newSquare.x, newSquare.y + yOffset - ((float) i));
                            if ((fakeNewSquare.x != currentDropSquare.x) || (fakeNewSquare.y != currentDropSquare.y)) {
                                if (this.CanPlaceObectOnSquareP1(drag.objectType, fakeNewSquare)) {
                                    currentDropSquare = fakeNewSquare;
                                    drag.haveFoundValidDropPosition = true;
                                    drag.tileDragOrigin.y = (float) i;
                                    break;
                                }

                            }

                        }

                    }
                    else if ((drag.objectType == ObjectType.kOT_Bridge1) || (drag.objectType == ObjectType.kOT_Bridge2)) {
                        float yOffset = drag.tileDragOrigin.y;
                        for (int i = 0; i < 5; i++) {
                            CGPoint fakeNewSquare = Utilities.CGPointMake(newSquare.x, newSquare.y + yOffset - ((float) i));
                            if ((fakeNewSquare.x != currentDropSquare.x) || (fakeNewSquare.y != currentDropSquare.y)) {
                                if (this.CanPlaceObectOnSquareP1(drag.objectType, fakeNewSquare)) {
                                    currentDropSquare = fakeNewSquare;
                                    drag.haveFoundValidDropPosition = true;
                                    drag.tileDragOrigin.y = (float) i;
                                    break;
                                }

                            }

                        }

                    }

                }

            }

        }

        public void AddFinishingGate()
        {
            ObjectType oType = ObjectType.kOT_FinishingLine;
            placedObject[numPlacedObjects].objectType = oType;
            placedObject[numPlacedObjects].position = Utilities.CGPointMake(0, 30);
            ((Globals.g_world.game).tileMap).PlaceObjectP1((int)oType, placedObject[numPlacedObjects].position);
            finishObject = numPlacedObjects;
            numPlacedObjects++;
        }

        public void ReadLevelObjectsFromDictionaryP1(Dictionary<string,int> dict, bool inLevelBuilder_Ross)
        {
/*            string string1;
            string1 = String.Format("trackName");
            savedTrackName = (dict.ObjectForKey(string1)).Copy();
            string1 = String.Format("numObjects");
            NSInteger myInt = (dict.ObjectForKey(string1)).IntValue();
            numPlacedObjects = myInt;
            string1 = String.Format("sceneType");
            myInt = (dict.ObjectForKey(string1)).IntValue();
            if (myInt > 0) {
                currentScene = myInt - 1;
            }
            else {
                currentScene = (Globals.g_world.frontEnd).SelectedTerrain();
            }

            if (Constants.ALWAYS_LOAD_ != -1) {
                currentScene = Constants.ALWAYS_LOAD_;
            }

            ((Globals.g_world.game).tileMap).InitialiseBeforeObjectsAdded(currentScene);
            this.SetupSceneObjectLists();
            this.SetupObjects();
            if (numPlacedObjects == 0) {
                this.AddFinishingGate();
                return;
            }

            for (int i = 0; i < numPlacedObjects; i++) {
                string1 = String.Format("objectType%d", i);
                myInt = (dict.ObjectForKey(string1)).IntValue();
                placedObject[i].objectType = myInt;
                string1 = String.Format("objectPosX%d", i);
                myInt = (dict.ObjectForKey(string1)).IntValue();
                placedObject[i].position.x = (float) myInt;
                string1 = String.Format("objectPosY%d", i);
                myInt = (dict.ObjectForKey(string1)).IntValue();
                placedObject[i].position.y = (float) myInt;
                if (inLevelBuilder_Ross) {
                    if (objectInfo[(int)placedObject[i].objectType].isSprite) {
                        placedObject[i].mapObjectId = (Globals.g_world.game).AddMapObjectP1P2P3(0, (int) placedObject[i].position.x, (int) placedObject[i].position.y
                          ,  ListType.e_RenderAbovePlayer);
                        ((Globals.g_world.game).GetMapObject(placedObject[i].mapObjectId)).SetSubTextureId(objectInfo[(int)placedObject[i].objectType].subTextureId);
                    }
                    else {
                        ((Globals.g_world.game).tileMap).PlaceObjectP1((int)placedObject[i].objectType, placedObject[i].position);
                        ((Globals.g_world.game).tileMap).RefreshTextures();
                        this.AddAdditionalSpritesForTileObjects(i);
                        if ((placedObject[i].objectType == ObjectType.kOT_FinishingLine) || (placedObject[i].objectType == ObjectType.
                          kOT_FinishingLineFarm)) {
                            finishObject = i;
                        }

                    }

                }

                if (currentScene == (int) SceneType.kSceneMud) {
                    if (placedObject[i].objectType == ObjectType.kOT_FinishingLineFarm) {
                        placedObject[i].objectType = ObjectType.kOT_FinishingLine;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_House) {
                        placedObject[i].objectType = ObjectType.kOT_Barn;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_Bucket) {
                        placedObject[i].objectType = ObjectType.kOT_Bollard;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_HayStack) {
                        placedObject[i].objectType = ObjectType.kOT_Skip;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_Igloo) {
                        placedObject[i].objectType = ObjectType.kOT_Barn;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_BigRamp) {
                        placedObject[i].objectType = ObjectType.kOT_FarmRamp;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_Snowdrift) {
                        placedObject[i].objectType = ObjectType.kOT_MudPuddle2x2;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_Seal) {
                        placedObject[i].objectType = ObjectType.kOT_OilDrum;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_SmallSnow) {
                        placedObject[i].objectType = ObjectType.kOT_Tulips;
                    }

                }

            }
*/
        }

        public void AddValueToFileCheck(float inObject)
        {
            switch (fileCheckOperation) {
            case 0 :
                fileCheckValue += inObject;
                break;
            case 1 :
                if (inObject != 0) fileCheckValue *= inObject;

                break;
            case 2 :
                fileCheckValue -= inObject;
                break;
            case 3 :
                if (inObject != 0) fileCheckValue /= inObject;

                break;
            default :
                Globals.Assert(false);
                break;
            }

            fileCheckOperation++;
            if (fileCheckOperation == 4) {
                fileCheckOperation = 0;
            }

        }

        public void AddValuesToFileCheck(PlacedObjectInfo inObject)
        {
            this.AddValueToFileCheck((float)(inObject.objectType));
            this.AddValueToFileCheck(inObject.position.x);
            this.AddValueToFileCheck(inObject.position.y);
        }

        public void ReadLevelObjectsFromBinaryFileP1(int whichLevel, bool inLevelBuilder_Ross)
        {
			int loadLevel = LevelBuilder_Ross.levelOrder[whichLevel];
			
			String levelFileString = "Levels/LevelBin" + loadLevel;
			
			TextAsset asset = Resources.Load(levelFileString) as TextAsset;
			Stream s = new MemoryStream(asset.bytes);
			BinaryReader sr = new BinaryReader(s);
			
            int intValue;
//            size_t result;
            fileCheckOperation = 0;
            fileCheckValue = 0;
			
//			var sr = new BinaryReader(File.Open(levelFileString, FileMode.Open));//Application.dataPath + "/" + "Resources/Levels/LevelBin0.lev");
    		//var fileContents = sr.ReadToEnd();
    		//sr.Close();

			
        //    if (fp == null) {
                numPlacedObjects = 0;
                intValue = 0;
          //  }
          //  else {
			
				intValue = sr.ReadInt32();
			
//                result = fread(intValue, 4, 1, fp);
                numPlacedObjects = intValue;
				intValue = sr.ReadInt32();

			//              result = fread(intValue, 4, 1, fp);
            //}

            this.AddValueToFileCheck((float) numPlacedObjects);
            this.AddValueToFileCheck((float) 0); //resutl
            if (intValue > 0) {
                currentScene = intValue - 1;
            }
            else {
                currentScene = (Globals.g_world.frontEnd).selectedTerrain;
            }

            if (Constants.ALWAYS_LOAD_ != -1) {
                currentScene = Constants.ALWAYS_LOAD_;
            }

            if (currentScene == (int) SceneType.kSceneIce) {
                currentScene = (int)SceneType.kSceneMud;
            }

            ((Globals.g_world.game).tileMap).InitialiseBeforeObjectsAdded(currentScene);
            this.SetupSceneObjectLists();
            this.SetupObjects();
            if (numPlacedObjects == 0) {
                this.AddFinishingGate();
                return;
            }

            for (int i = 0; i < numPlacedObjects; i++) {
                intValue = sr.ReadInt32();//result = fread(intValue, 4, 1, fp);
                placedObject[i].objectType = (ObjectType) intValue;
                intValue = sr.ReadInt32();//result = fread(intValue, 4, 1, fp);
                placedObject[i].position.x = (float) intValue;
                intValue = sr.ReadInt32();//result = fread(intValue, 4, 1, fp);
                placedObject[i].position.y = (float) intValue;
                this.AddValuesToFileCheck((placedObject[i]));
                if (currentScene == (int) SceneType.kSceneMud) {
                    if (placedObject[i].objectType == ObjectType.kOT_House) {
                        placedObject[i].objectType = ObjectType.kOT_Barn;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_Bucket) {
                        placedObject[i].objectType = ObjectType.kOT_Bollard;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_HayStack) {
                        placedObject[i].objectType = ObjectType.kOT_Skip;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_Igloo) {
                        placedObject[i].objectType = ObjectType.kOT_Barn;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_BigRamp) {
                        placedObject[i].objectType = ObjectType.kOT_FarmRamp;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_Snowdrift) {
                        placedObject[i].objectType = ObjectType.kOT_MudPuddle2x2;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_Seal) {
                        placedObject[i].objectType = ObjectType.kOT_OilDrum;
                    }

                    if (placedObject[i].objectType == ObjectType.kOT_SmallSnow) {
                        placedObject[i].objectType = ObjectType.kOT_Tulips;
                    }

                }

                if (inLevelBuilder_Ross) {
                    if (objectInfo[(int)placedObject[i].objectType].isSprite) {
                        placedObject[i].mapObjectId = (Globals.g_world.game).AddMapObjectP1P2P3(0, (int) placedObject[i].position.x, (int) placedObject[i].position.y
                          ,  ListType.e_RenderAbovePlayer);
                        ((Globals.g_world.game).GetMapObject(placedObject[i].mapObjectId)).SetSubTextureId(objectInfo[(int)placedObject[i].objectType].subTextureId);
                    }
                    else {
                        ((Globals.g_world.game).tileMap).PlaceObjectP1((int)placedObject[i].objectType, placedObject[i].position);
                        this.AddAdditionalSpritesForTileObjects(i);
						((Globals.g_world.game).tileMap).tileYOffset = (int)Default.Namespace.TileMap.kTilesHigh;
                        ((Globals.g_world.game).tileMap).RefreshTextures();
                        if ((placedObject[i].objectType == ObjectType.kOT_FinishingLine) || (placedObject[i].objectType == ObjectType.
                          kOT_FinishingLineFarm)) {
                            finishObject = i;
                        }

                    }

                }

            }

            #if PRINTOUT_VALIDATION_NUMBERS
                int levelNum = ((Globals.g_world.frontEnd).profile).selectedLevel;
                fileCheckVal[levelNum] = fileCheckValue;
                if (true) {
                    MyLog("switch (levelFileId) {\n");
                    for (int i = 0; i < levelNum + 1; i++) {
                        int levelId = LevelBuilder_Ross.levelOrder[i];
                        double fiddle = fileCheckVal[i];
                        if (fiddle > 0.0f) {
                            while (fiddle < 10000000000000000.0f) {
                                fiddle *= 10.0f;
                            };

                        }
                        else {
                            while (fiddle > -10000000000000000.0f) {
                                fiddle *= 10.0f;
                            };

                        }

                        MyLog("case %d:\n", levelId);
                        MyLog("   return (fileCheckValue == %f);\n", fiddle);
                        MyLog("   break;\n");
                    }

                }

            #endif
            

        }

        public FileStream GetLevelFileP1(int whichLevel, bool inLevelBuilder_Ross)
        {
            int loadLevel = whichLevel;
            bool openCustomFile = (Globals.g_world.frontEnd).exitInfo.playCustomLevel;
            bool openCustomFileFromRealLevels = false;

            #if LOAD_CUSTOM_LEVEL_FROM_REAL_LEVELS
                bool tryLoadFromCustomFirst = false;
                if (inLevelBuilder_Ross) {
                    inLevelBuilder_Ross = false;
                    openCustomFile = false;
                    whichLevel += Constants.CUSTOM_LEVEL_OFFSET;
                    tryLoadFromCustomFirst = true;
                }
                else if (openCustomFile) {
                    whichLevel += Constants.CUSTOM_LEVEL_OFFSET;
                    tryLoadFromCustomFirst = true;
                    openCustomFileFromRealLevels = true;
                }

            #endif

            if (!inLevelBuilder_Ross) {
                if (!openCustomFile) {
                    loadLevel = LevelBuilder_Ross.levelOrder[whichLevel];
                }
                else {
                    if (openCustomFileFromRealLevels) {
                        loadLevel = LevelBuilder_Ross.levelOrder[whichLevel];
                    }
                    else {
                        loadLevel += kDesignPhase100;
                    }

                }

            }
            else {
                loadLevel += kDesignPhase100;
            }
			/*
            lastLoadedLevel = loadLevel;
            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            string name;
            name = String.Format("LevelBin%d.lev", loadLevel);
            string appFile = documentsDirectory.StringByAppendingPathComponent(name);
            FileStream fp;
            if (openCustomFile) {
                fp = fopen(appFile, "rb");
            }
            else {
                bool foundIt = false;

                #if LOAD_CUSTOM_LEVEL_FROM_REAL_LEVELS
                    if (tryLoadFromCustomFirst) {
                        fp = fopen(appFile, "rb");
                        if (fp) {
                            foundIt = true;
                        }

                    }

                #endif

                if (!foundIt) {
                    string resourcesPath = ((NSBundle.MainBundle()).ResourcePath()).StringByAppendingPathComponent(name);
                    fp = fopen(resourcesPath, "rb");
                }

            }
*/
			return null;//fp;
        }

        public Dictionary<string,int> GetLevelDictionaryP1(int whichLevel, bool inLevelBuilder_Ross)
        {
            int loadLevel = whichLevel;
            if (!inLevelBuilder_Ross) {
                if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                    loadLevel = LevelBuilder_Ross.levelOrder[whichLevel];
                }
                else {
                    loadLevel += kDesignPhase100;
                }

            }
            else {
                loadLevel += kDesignPhase100;
            }
			/*
            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            string name;
            name = String.Format("LevelData%d.lev", loadLevel);
            string appFile = documentsDirectory.StringByAppendingPathComponent(name);
            NSDictionary dict;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                dict = new NSDictionary(appFile);
            }
            else {
                string resourcesPath = ((NSBundle.MainBundle()).ResourcePath()).StringByAppendingPathComponent(name);
                dict = new NSDictionary(resourcesPath);
            }*/

			return null;//dict;
        }

        public bool CheckFileIntegrity()
        {
            int levelFileId = lastLoadedLevel;
            double fiddle = fileCheckValue;
            if (fiddle > 0.0f) {
                while (fiddle < 10000000000000000.0f) {
                    fiddle *= 10.0f;
                };

            }
            else {
                while (fiddle > -10000000000000000.0f) {
                    fiddle *= 10.0f;
                };

            }

            fileCheckValue = fiddle;
            switch (levelFileId) {
            case 15 :
                return (fileCheckValue == -61392877693511048.000000);
                
            case 13 :
                return (fileCheckValue == 11074698485479296.000000);
                
            case 203 :
                return (fileCheckValue == -33354513633437640.000000);
                
            case 519 :
                return (fileCheckValue == 29606076822771556.000000);
                
            case 200 :
                return (fileCheckValue == 93159047774928496.000000);
                
            case 400 :
                return (fileCheckValue == -21345268175664236.000000);
                
            case 216 :
                return (fileCheckValue == -43420049222940336.000000);
                
            case 16 :
                return (fileCheckValue == 58758179622529776.000000);
                
            case 402 :
                return (fileCheckValue == 15360844036698864.000000);
                
            case 214 :
                return (fileCheckValue == 32934218605787008.000000);
                
            case 310 :
                return (fileCheckValue == 11743973473131386.000000);
                
            case 218 :
                return (fileCheckValue == 32332983253463080.000000);
                
            case 410 :
                return (fileCheckValue == -46429480794888792.000000);
                
            case 211 :
                return (fileCheckValue == -12448891096451238.000000);
                
            case 515 :
                return (fileCheckValue == 76512162519807216.000000);
                
            case 504 :
                return (fileCheckValue == 82467409904444576.000000);
                
            case 207 :
                return (fileCheckValue == -26537913443214604.000000);
                
            case 201 :
                return (fileCheckValue == -31535109607655720.000000);
                
            case 205 :
                return (fileCheckValue == -23381421653620592.000000);
                
            case 500 :
                return (fileCheckValue == 41071887041644864.000000);
                
            case 6 :
                return (fileCheckValue == 85057019892408944.000000);
                
            case 501 :
                return (fileCheckValue == 40520416725244968.000000);
                
            case 503 :
                return (fileCheckValue == -18249737015275412.000000);
                
            case 19 :
                return (fileCheckValue == 46839688440707056.000000);
                
            case 300 :
                return (fileCheckValue == 45143238450242392.000000);
                
            case 303 :
                return (fileCheckValue == 55089590672376880.000000);
                
            case 523 :
                return (fileCheckValue == 10406208571464262.000000);
                
            case 212 :
                return (fileCheckValue == 24794251878952560.000000);
                
            case 513 :
                return (fileCheckValue == 61930586067479696.000000);
                
            case 305 :
                return (fileCheckValue == -79642392002487056.000000);
                
            case 408 :
                return (fileCheckValue == 26390633690838192.000000);
                
            case 512 :
                return (fileCheckValue == 12063858373272148.000000);
                
            case 17 :
                return (fileCheckValue == -29006735701631556.000000);
                
            case 502 :
                return (fileCheckValue == 71520451429214752.000000);
                
            case 0 :
                return (fileCheckValue == -97245367880673200.000000);
                
            case 505 :
                return (fileCheckValue == 24913829823034496.000000);
                
            case 22 :
                return (fileCheckValue == -26673148125121128.000000);
                
            case 10 :
                return (fileCheckValue == 40378012248377376.000000);
                
            case 1 :
                return (fileCheckValue == -55057262005705296.000000);
                
            case 507 :
                return (fileCheckValue == 42638834172447992.000000);
                
            case 307 :
                return (fileCheckValue == -64672059349274408.000000);
                
            case 102 :
                return (fileCheckValue == 70148991964990384.000000);
                
            case 411 :
                return (fileCheckValue == 17212450851017910.000000);
                
            case 306 :
                return (fileCheckValue == -50373723650599888.000000);
                
            case 100 :
                return (fileCheckValue == 12586937322604416.000000);
                
            case 118 :
                return (fileCheckValue == 55067174571215776.000000);
                
            case 112 :
                return (fileCheckValue == -24500738185912936.000000);
                
            case 403 :
                return (fileCheckValue == 97748254936388480.000000);
                
            case 508 :
                return (fileCheckValue == 84678186230344000.000000);
                
            case 514 :
                return (fileCheckValue == 50174886216336800.000000);
                
            case 405 :
                return (fileCheckValue == 19102079716652144.000000);
                
            case 11 :
                return (fileCheckValue == -56301332760436680.000000);
                
            case 3 :
                return (fileCheckValue == -24805467622745660.000000);
                
            case 18 :
                return (fileCheckValue == -59218201941370064.000000);
                
            case 14 :
                return (fileCheckValue == 13142509799810960.000000);
                
            case 4 :
                return (fileCheckValue == 10750238282104738.000000);
                
            case 409 :
                return (fileCheckValue == -14078748256856976.000000);
                
            case 301 :
                return (fileCheckValue == 91354744810948784.000000);
                
            case 304 :
                return (fileCheckValue == -55959995916524101566464.000000);
                
            case 108 :
                return (fileCheckValue == -56663980646485112.000000);
                
            case 116 :
                return (fileCheckValue == 42719736013199616.000000);
                
            case 302 :
                return (fileCheckValue == 77632454123676224.000000);
                
            case 215 :
                return (fileCheckValue == -57408589048229600.000000);
                
            case 209 :
                return (fileCheckValue == 25702847152003476.000000);
                
            case 516 :
                return (fileCheckValue == -85819692791692256.000000);
                
            case 7 :
                return (fileCheckValue == 10956536226762316.000000);
                
            case 311 :
                return (fileCheckValue == -87000350915853408.000000);
                
            case 20 :
                return (fileCheckValue == -11043749946912718.000000);
                
            case 520 :
                return (fileCheckValue == -31403791040805928.000000);
                
            case 510 :
                return (fileCheckValue == 85626347780658752.000000);
                
            case 5 :
                return (fileCheckValue == -70623012122015216.000000);
                
            case 8 :
                return (fileCheckValue == -3948853310091849686319104.000000);
                
            case 308 :
                return (fileCheckValue == 24797687232861688.000000);
                
            case 521 :
                return (fileCheckValue == -22187392704127776.000000);
                
            case 119 :
                return (fileCheckValue == 74849130738090640.000000);
                
            case 123 :
                return (fileCheckValue == -30091923083383740.000000);
                
            case 518 :
                return (fileCheckValue == 42676521300083400.000000);
                
            case 509 :
                return (fileCheckValue == 79842797503147344.000000);
                
            case 517 :
                return (fileCheckValue == 10603933665823888.000000);
                
            case 107 :
                return (fileCheckValue == -14742177223459262.000000);
                
            }

            return true;
        }

        public void ReadSomeLevelDataFromBinaryFileP1(int whichLevel, bool inLevelBuilder_Ross)
        {
            FileStream fp;
            bool tryLoadLevel = true;
            if (inLevelBuilder_Ross) 
			{
                if (!((Globals.g_world.frontEnd).profile).IsCustomLevelMade(whichLevel)) {

                        #if !LOAD_CUSTOM_LEVEL_FROM_REAL_LEVELS
                            tryLoadLevel = false;
                        #endif

                }

            }

            if (tryLoadLevel) {
          //      fp = this.GetLevelFileP1(whichLevel, inLevelBuilder_Ross);
            }
            else {
            //    fp = null;
            }

            this.ReadLevelObjectsFromBinaryFileP1(whichLevel, inLevelBuilder_Ross);
//            fclose (fp);
        }

        public void ReadSomeLevelDataP1(int whichLevel, bool inLevelBuilder_Ross)
        {

//                #if READ_CUSTOM_LEVELS_FROM_BINARY_FILES
                    this.ReadSomeLevelDataFromBinaryFileP1(whichLevel, inLevelBuilder_Ross);
                    return;
 //               #else
   //                 if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
     //                   this.ReadSomeLevelDataFromBinaryFileP1(whichLevel, inLevelBuilder_Ross);
       //                 return;
         //           }
			//
                //#endif

            bool tryLoadLevel = true;
            if (inLevelBuilder_Ross) {
                if (!((Globals.g_world.frontEnd).profile).IsCustomLevelMade(whichLevel)) {

                    #if !LOAD_LEVELS_ANYWAY
                        tryLoadLevel = false;
                    #endif

                }

            }

            Dictionary<string,int> dict;
            if (tryLoadLevel) {
//                dict = this.GetLevelDictionaryP1(whichLevel, inLevelBuilder_Ross);
            }
            else {
  //              dict = null;
            }

//            this.ReadLevelObjectsFromDictionaryP1(dict, inLevelBuilder_Ross);
        }

        public void LoadOfObjectsFinished()
        {
            this.RedrawTileMap();
            this.PostTileProcessing();
        }

        public void WriteLevelToBinaryFile()
        {
            int playingLevel = (Globals.g_world.game).playingLevel;
            int level = LevelBuilder_Ross.levelOrder[playingLevel];
            this.WriteLevelToBinaryFile(level);
        }

        public void WriteLevelToBinaryFile(int levelNumber)
        {/*
            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            string name;
            FileStream fp;
            name = String.Format("LevelBin%d.lev", levelNumber);
            string appFile = documentsDirectory.StringByAppendingPathComponent(name);
            fp = fopen(appFile, "wb");
            this.ActuallyWriteLevelToBinaryFile(fp);
            fclose (fp);*/
        }

        public void QuitAndWriteData()
        {
            int whichLevel = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
            ((Globals.g_world.frontEnd).profile).SetBestTimeP1P2( BestTimeSet.t_Custom, whichLevel, 1000);
            ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();

            #if WRITE_CUSTOM_LEVELS_TO_BINARY_FILES

                #if LOAD_CUSTOM_LEVEL_FROM_REAL_LEVELS
                    int saveNameLevel = LevelBuilder_Ross.levelOrder[whichLevel + Constants.CUSTOM_LEVEL_OFFSET];
                    this.WriteLevelToBinaryFile(saveNameLevel);
                #else
                    this.WriteLevelToBinaryFile(whichLevel + kDesignPhase100);
                #endif

            #else
			//	Dictionary<string,int> dict = new NSMutableDictionary();
              //  this.WriteLevelToDictionary(dict);
                string name;
                name = String.Format("LevelData%d.lev", whichLevel + kDesignPhase100);
                //Utilities.WriteDictionaryToFileP1(dict, name);
            #endif

            ((Globals.g_world.frontEnd).profile).WriteCustomLevelNoNameP1(whichLevel, currentScene);
            ((Globals.g_world.frontEnd).profile).SaveCustomLevelInformation();

            #if USE_CRYSTAL
            #endif

        }
		/*
        public void saveGameDataToDevice (string dataString) {
            NSUserDefaults prefs = NSUserDefaults.StandardUserDefaults();
            string convertedString = new string(dataString);
            prefs.setObjectForKey(convertedString, "mySaveGameData");
            prefs.synchronize();
        }

        static string loadGameDataFromDevice () {
            NSUserDefaults prefs = NSUserDefaults.StandardUserDefaults();
            string myString = prefs.stringForKey("mySaveGameData");
            return myString;
        }*/

        public void SetInfoWordsTooFar()
        {
            FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                qInfo.theInfo1 = "Bewege die Ziellinie\n";
                qInfo.theInfo2 = "um eine l#ngere\n";
                qInfo.theInfo3 = "Strecke zu erhalten.\n";
            }
            else {
                qInfo.theInfo1 = "move the finish\n";
                qInfo.theInfo2 = "line for a\n";
                qInfo.theInfo3 = "longer track\n";
            }

            qInfo.theInfo4 = "\n";
            qInfo.theInfo5 = "\n";
            qInfo.theInfo6 = "\n";
            qInfo.theInfo7 = "\n";
            if (!Globals.g_world.DoesCurrentLanguageUseNSString()) 
			{
                (query[(int) LevelBuilder_RossQueries.kLBQuery_InfoBridge]).ChangeFunnyWords(qInfo);
            }

        }

        public void SetInfoWords()
        {
            FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
            qInfo.theInfo1 = "\n";
            qInfo.theInfo2 = "\n";
            qInfo.theInfo3 = "\n";
            qInfo.theInfo4 = "\n";
            qInfo.theInfo5 = "\n";
            qInfo.theInfo6 = "\n";
            qInfo.theInfo7 = "\n";
            switch (pickableObjectType[0]) {
            case ObjectType.kOT_Tree :
                qInfo.theInfo1 = "place trees\n";
                qInfo.theInfo2 = "on free patches\n";
                qInfo.theInfo3 = "of grass\n";
                break;
            case ObjectType.kOT_Pond :
            case ObjectType.kOT_Puddle :
                qInfo.theInfo1 = "place ponds\n";
                qInfo.theInfo2 = "on free patches\n";
                qInfo.theInfo3 = "of grass\n";
                break;
            case ObjectType.kOT_Rainbow :
                qInfo.theInfo1 = "place rainbows\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_Flowers :
                qInfo.theInfo1 = "place flowers\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_CowLeft :
                qInfo.theInfo1 = "place cows\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_CowRight :
                qInfo.theInfo1 = "place cows\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_BoostArrowDown :
                qInfo.theInfo1 = "place boost\n";
                qInfo.theInfo2 = "arrows\n";
                qInfo.theInfo3 = "anywhere\n";
                break;
            case ObjectType.kOT_CowPatSprite :
                qInfo.theInfo1 = "place cowpats\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_River :
                qInfo.theInfo1 = "place  rivers\n";
                qInfo.theInfo2 = "on free areas\n";
                qInfo.theInfo3 = "of grass\n";
                break;
            case ObjectType.kOT_Ramp :
            case ObjectType.kOT_BigRamp :
                qInfo.theInfo1 = "place ramps\n";
                qInfo.theInfo2 = "on free patches\n";
                qInfo.theInfo3 = "of grass\n";
                break;
            case ObjectType.kOT_Rock :
            case ObjectType.kOT_BigRock :
                qInfo.theInfo1 = "place rocks\n";
                qInfo.theInfo2 = "on free patches\n";
                qInfo.theInfo3 = "of grass\n";
                break;
            case ObjectType.kOT_HedgeRight :
            case ObjectType.kOT_HedgeLeft :
                qInfo.theInfo1 = "place hedges\n";
                qInfo.theInfo2 = "on the\n";
                qInfo.theInfo3 = "grass\n";
                break;
            case ObjectType.kOT_Bridge1 :
            case ObjectType.kOT_Bridge2 :
                qInfo.theInfo1 = "bridges must\n";
                qInfo.theInfo2 = "be placed\n";
                qInfo.theInfo3 = "on rivers\n";
                break;
            case ObjectType.kOT_InsertSpace :
                qInfo.theInfo1 = "shifts\n";
                qInfo.theInfo2 = "all objects\n";
                qInfo.theInfo3 = "down a bit\n";
                break;
            case ObjectType.kOT_RemoveSpace :
                qInfo.theInfo1 = "shifts\n";
                qInfo.theInfo2 = "objects up\n";
                qInfo.theInfo3 = "a bit\n";
                break;
            case ObjectType.kOT_ArrowLeft :
            case ObjectType.kOT_ArrowRight :
            case ObjectType.kOT_ArrowDown :
                qInfo.theInfo1 = "place arrows\n";
                qInfo.theInfo2 = "on free patches\n";
                qInfo.theInfo3 = "of grass\n";
                break;
            case ObjectType.kOT_Barn :
            case ObjectType.kOT_House :
            case ObjectType.kOT_BigSidewaysShed :
                qInfo.theInfo1 = "place buildings\n";
                qInfo.theInfo2 = "on free areas\n";
                qInfo.theInfo3 = "of mud\n";
                break;
            case ObjectType.kOT_StoneWell :
                qInfo.theInfo1 = "place well\n";
                qInfo.theInfo2 = "on a free area\n";
                qInfo.theInfo3 = "of mud\n";
                break;
            case ObjectType.kOT_HayBaleDouble :
                qInfo.theInfo1 = "place hay bales\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_Tractor :
            case ObjectType.kOT_BlueTractor :
                qInfo.theInfo1 = "put the\n";
                qInfo.theInfo2 = "tractor\n";
                qInfo.theInfo3 = "anywhere\n";
                break;
            case ObjectType.kOT_OilDrum :
                qInfo.theInfo1 = "put the\n";
                qInfo.theInfo2 = "oil drum\n";
                qInfo.theInfo3 = "anywhere\n";
                break;
            case ObjectType.kOT_Igloo :
                qInfo.theInfo1 = "put the\n";
                qInfo.theInfo2 = "igloo\n";
                qInfo.theInfo3 = "anywhere\n";
                break;
            case ObjectType.kOT_Seal :
                qInfo.theInfo1 = "put the\n";
                qInfo.theInfo2 = "seal\n";
                qInfo.theInfo3 = "anywhere\n";
                break;
            case ObjectType.kOT_SmallSnow :
                qInfo.theInfo1 = "put the\n";
                qInfo.theInfo2 = "small snow\n";
                qInfo.theInfo3 = "anywhere\n";
                break;
            case ObjectType.kOT_Bollard :
                qInfo.theInfo1 = "put the\n";
                qInfo.theInfo2 = "bollard\n";
                qInfo.theInfo3 = "anywhere\n";
                break;
            case ObjectType.kOT_Chicken :
                qInfo.theInfo1 = "place chickens\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_FarmRamp :
                qInfo.theInfo1 = "place ramps\n";
                qInfo.theInfo2 = "on a free area\n";
                qInfo.theInfo3 = "of mud\n";
                break;
            case ObjectType.kOT_MudPuddle2x1 :
            case ObjectType.kOT_MudPuddle1x1 :
                qInfo.theInfo1 = "place puddle\n";
                qInfo.theInfo2 = "on a free area\n";
                qInfo.theInfo3 = "of mud\n";
                break;
            case ObjectType.kOT_BushLilac :
            case ObjectType.kOT_BushPink :
                qInfo.theInfo1 = "place bushes\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_ChimneyLeft :
            case ObjectType.kOT_ChimneyRight :
                qInfo.theInfo1 = "place chimneys\n";
                qInfo.theInfo2 = "on top of\n";
                qInfo.theInfo3 = "metal sheds\n";
                break;
            case ObjectType.kOT_WallFarmYard :
                qInfo.theInfo1 = "place walls\n";
                qInfo.theInfo2 = "on a free area\n";
                qInfo.theInfo3 = "of mud\n";
                break;
            case ObjectType.kOT_Bucket :
                qInfo.theInfo1 = "place buckets\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_Cart :
                qInfo.theInfo1 = "put the cart\n";
                qInfo.theInfo2 = "on a free area\n";
                qInfo.theInfo3 = "of mud\n";
                break;
            case ObjectType.kOT_Welly :
                qInfo.theInfo1 = "place wellies\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_HayStack :
                qInfo.theInfo1 = "place haystack\n";
                qInfo.theInfo2 = "on a free area\n";
                qInfo.theInfo3 = "of mud\n";
                break;
            case ObjectType.kOT_StarSpeedUp :
                qInfo.theInfo1 = "place stars\n";
                qInfo.theInfo2 = "anywhere\n";
                break;
            case ObjectType.kOT_HillockFarmyard :
            case ObjectType.kOT_SmallBump :
                qInfo.theInfo1 = "place hillocks\n";
                qInfo.theInfo2 = "on a free area\n";
                qInfo.theInfo3 = "of mud\n";
                break;
            default :
                break;
            }

            (query[(int) LevelBuilder_RossQueries.kLBQuery_InfoBridge]).ChangeFunnyWords(qInfo);
        }

        bool IsButtonPressed()
        {
            for (int i = 0; i < (int)Enum3.kNumPickableTiles; i++) {
                if ((upButton[i]).IsTouchedP1((int) touchingPosition.x, (int) touchingPosition.y)) {
                    currentIndexSceneList = Utilities.IncrementLoopP1P2(currentIndexSceneList, 0, numOjectsInSceneList[currentScene] - 1);
                    pickableObjectType[i] = (ObjectType)sceneObjectList[currentScene, currentIndexSceneList];
                    this.ChangeObjectNameDisplay(pickableObjectType[i]);
                    (upButton[i]).Throb();
                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_Rainbow, 0.1f);
                    return true;
                }
                else if ((downButton[i]).IsTouchedP1((int) touchingPosition.x, (int) touchingPosition.y)) {
                    currentIndexSceneList = Utilities.DecrementLoopP1P2(currentIndexSceneList, 0, numOjectsInSceneList[currentScene] - 1);
                    pickableObjectType[i] = (ObjectType)sceneObjectList[currentScene, currentIndexSceneList];
                    this.ChangeObjectNameDisplay(pickableObjectType[i]);
                    (downButton[i]).Throb();
                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_Rainbow, 0.1f);
                    return true;
                }

            }

            if (((button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).IsTouchedP1((int) touchingPosition.x, (int) touchingPosition.y)) || ((button[(int)
              LevelBuilder_RossButtons.kLBButton_Move]).IsTouchedP1((int) touchingPosition.x, (int) touchingPosition.y))) {
                copySet = !copySet;
                if (copySet) {
                    (button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).Show();
                    (button[(int) LevelBuilder_RossButtons.kLBButton_Move]).Hide();
                }
                else {
                    (button[(int) LevelBuilder_RossButtons.kLBButton_Copy]).Hide();
                    (button[(int) LevelBuilder_RossButtons.kLBButton_Move]).Show();
                }

                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_Rainbow, 0.1f);
            }

            if ((button[(int) LevelBuilder_RossButtons.kLBButton_DeleteAll]).IsTouched(touchingPosition)) {
                (query[(int) LevelBuilder_RossQueries.kLBQuery_DeleteObjects]).Show();
                inQuery = true;
                (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_BubblesHigh);
                (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_BubblesLowLoop, 0.3f);
            }

            if ((button[(int) LevelBuilder_RossButtons.kLBButton_Info]).IsTouched(touchingPosition)) {
                this.SetInfoWords();
                (query[(int) LevelBuilder_RossQueries.kLBQuery_InfoBridge]).Show();
                inQuery = true;
                (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_BubblesHigh);
                (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_BubblesLowLoop, 0.3f);
            }

            if (touchingPosition.x > 270 && touchingPosition.y > 400) {
                (query[(int) LevelBuilder_RossQueries.kLBQuery_QuitAndWrite]).Show();
                inQuery = true;
                (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_BubblesHigh);
                (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_BubblesLowLoop, 0.3f);
                return true;
            }

            return false;
        }

        public void SetFinishObjectAgain()
        {
            for (int i = 0; i < numPlacedObjects; i++) {
                if (placedObject[i].objectType == ObjectType.kOT_FinishingLine) {
                    finishObject = i;
                    return;
                }

            }

        }

        bool CheckStartMapDragSprite(CGPoint mapTouchPos)
        {
            int objectId = -1;
            for (int i = 0; i < numPlacedObjects; i++) {
                if (!objectInfo[(int)placedObject[i].objectType].isSprite) continue;

                const float kRadiusSqr = 900;
                if (Utilities.GetSqrDistanceP1(mapTouchPos, placedObject[i].position) < kRadiusSqr) {
                    objectId = i;
                    break;
                }

            }

            if (objectId == -1) return false;

            if (copySet) {
                if (!this.CanIPleaseGetAnother(placedObject[objectId].objectType)) {
                    (query[(int) LevelBuilder_RossQueries.kLBQuery_TooManyObjects]).Show();
                    inQuery = true;
                    this.SetState( LevelBuilder_RossState.kLBState_FingerDownInLimbo);
                    return false;
                }

            }

            drag.objectType = placedObject[objectId].objectType;
            drag.objectOnMapDraggingId = objectId;
            drag.haveFoundValidDropPosition = false;
            drag.tileDragOrigin = Utilities.CGPointMake(0, 0);
            drag.trashing = false;
            this.SetState( LevelBuilder_RossState.kLBState_Dragging);
            if (!copySet) {
                this.RemoveObjectFromMap(objectId);
                this.RemoveObjectFromList(objectId);
                this.SetupLinkedObjects();
                this.SetFinishObjectAgain();
            }

            return true;
        }

        public void RemoveObjectFromMap(int i)
        {
            int inType = (int)placedObject[i].objectType;
            if (objectInfo[(int)inType].isSprite) {
                (Globals.g_world.game).RemoveFromUsedListP1( ListType.e_RenderAbovePlayer, placedObject[i].mapObjectId);
                (Globals.g_world.game).AddToFreeList(placedObject[i].mapObjectId);
            }
            else {
                for (int x = 0; x < (int) objectInfo[(int)inType].tileWidth; x++) {
                    for (int y = 0; y < (int) objectInfo[(int)inType].tileHeight; y++) {
                        int tileId = objectInfo[(int)inType].objectTile[x, y];
                        if (tileId != -1) {
                            int xPos = ((int) placedObject[i].position.x) + x;
                            int yPos = ((int) placedObject[i].position.y) + y;
                            int grassyTile = (((Globals.g_world.game).tileMap).GetTileGrid()).GetRandomGrassyTileP1(currentScene, yPos);
                            (((Globals.g_world.game).tileMap).GetTileGrid()).SetTileIdP1P2(xPos, yPos, grassyTile);
                            ((Globals.g_world.game).tileMap).RefreshTextures();
                        }

                    }

                }

                this.CheckRemoveAdditionalSprites(i);
            }

        }

        public void RemoveObjectFromList(int objectId)
        {
            if (objectId == (numPlacedObjects - 1)) {
                numPlacedObjects--;
                return;
            }

            for (int i = 0; i < numPlacedObjects; i++) {
                if (i < objectId) continue;
                else if (i >= objectId) {
                    placedObject[i] = placedObject[i + 1];
                }

            }

            numPlacedObjects--;
        }

        public void CheckRemoveLinkedObjects(int objectId)
        {
            const int kMaxRemovals = 2;
            int numToRemove = 0;
            int[] removeObject = new int[2];
            for (int i = 0; i < numPlacedObjects; i++) {
                if ((placedObject[i].objectType == ObjectType.kOT_Tree) || (placedObject[i].objectType == ObjectType.kOT_TreeGreen) || (
                  placedObject[i].objectType == ObjectType.kOT_Elephant)) {
                    continue;
                }

                if (placedObject[i].linkedToObject == objectId) {
                    Globals.Assert(numToRemove < kMaxRemovals);
                    removeObject[numToRemove] = i;
                    numToRemove++;
                }

            }

            int shift = 0;
            for (int i = 0; i < numToRemove; i++) {
                this.RemoveObjectFromMap(removeObject[i] - shift);
                this.RemoveObjectFromList(removeObject[i] - shift);
                shift++;
            }

            this.SetupLinkedObjects();
        }

        public void RefreshCurrentScene()
        {
            this.SetFinishObjectAgain();
            this.RedrawTileMap();
            this.PostTileProcessing();
            ((Globals.g_world.game).tileMap).RefreshTextures();
        }

        bool CheckStartMapDragTile(CGPoint mapTouchPos)
        {
            if (mapTouchPos.x < 0.0f) {
                mapTouchPos.x -= 64.0f;
            }

            int xTile = (int) (mapTouchPos.x / (64.0f));
            int yTile = (int) (mapTouchPos.y / (64.0f));
            CGPoint mapTouchTile = Utilities.CGPointMake((float) xTile, (float) yTile);
            const int kMaxPerSquare = 2;
            int numFound = 0;
            int[] foundObject = new int[2];
            CGPoint[] foundDrag = new CGPoint[2];
            for (int i = 0; i < numPlacedObjects; i++) {
                ObjectType inType = placedObject[i].objectType;
                if (objectInfo[(int)inType].isSprite) continue;

                if ((inType ==  ObjectType.kOT_FinishingLine) && (copySet)) continue;

                for (int x = 0; x < (int) objectInfo[(int)inType].tileWidth; x++) {
                    for (int y = 0; y < (int) objectInfo[(int)inType].tileHeight; y++) {
                        int tileId = objectInfo[(int)inType].objectTile[x, y];
                        if (tileId != -1) {
                            float thisTileX = placedObject[i].position.x + (float) x;
                            float thisTileY = placedObject[i].position.y + (float) y;
                            if ((thisTileX == mapTouchTile.x) && (thisTileY == mapTouchTile.y)) {
                                Globals.Assert(numFound < kMaxPerSquare);
                                foundObject[numFound] = i;
                                foundDrag[numFound] = Utilities.CGPointMake((float) x, (float) y);
                                numFound++;
                            }

                        }

                    }

                }

            }

            if (numFound == 0) return false;

            int i2;
            if (numFound == 1) {
                i2 = 0;
            }
            else {
                ObjectType oType = placedObject[foundObject[0]].objectType;
                if ((oType == ObjectType.kOT_ChimneyLeft) || (oType == ObjectType.kOT_ChimneyRight) || (oType == ObjectType.kOT_Bridge1) || (
                  oType == ObjectType.kOT_Bridge2)) {
                    i2 = 0;
                }
                else {
                    i2 = 1;
                }

            }

            if (copySet) {
                if (!this.CanIPleaseGetAnother(placedObject[foundObject[i2]].objectType)) {
                    (query[(int) LevelBuilder_RossQueries.kLBQuery_TooManyObjects]).Show();
                    inQuery = true;
                    this.SetState( LevelBuilder_RossState.kLBState_FingerDownInLimbo);
                    return false;
                }

            }

            pickedUpFromSquare = placedObject[foundObject[i2]].position;
            drag.objectType = placedObject[foundObject[i2]].objectType;
            drag.objectOnMapDraggingId = foundObject[i2];
            drag.haveFoundValidDropPosition = false;
            drag.tileDragOrigin = foundDrag[i2];
            drag.trashing = false;
            this.SetState( LevelBuilder_RossState.kLBState_Dragging);
            if (!copySet) {
                this.RemoveObjectFromMap(foundObject[i2]);
                this.RemoveObjectFromList(foundObject[i2]);
                this.CheckRemoveLinkedObjects(foundObject[i2]);
                this.SetupLinkedObjects();
                this.RefreshCurrentScene();
            }

            return true;
        }

        int CountMyObjects(ObjectType inType)
        {
            int howMany = -1;
            switch (inType) {
            case ObjectType.kOT_Pond :
            case ObjectType.kOT_Snowdrift :
            case ObjectType.kOT_Puddle :
            case ObjectType.kOT_MudPuddle1x1 :
            case ObjectType.kOT_MudPuddle2x1 :
                howMany = this.CountMyObjectsPerType(ObjectType.kOT_Pond);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_Snowdrift);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_Puddle);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_MudPuddle1x1);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_MudPuddle2x1);
                break;
            case ObjectType.kOT_Flowers :
            case ObjectType.kOT_BushLilac :
            case ObjectType.kOT_BushPink :
                howMany = this.CountMyObjectsPerType(ObjectType.kOT_Flowers);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_BushLilac);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_BushPink);
                break;
            case ObjectType.kOT_Ramp :
            case ObjectType.kOT_BigRamp :
            case ObjectType.kOT_FarmRamp :
                howMany = this.CountMyObjectsPerType(ObjectType.kOT_Ramp);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_BigRamp);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_FarmRamp);
                break;
            case ObjectType.kOT_CowLeft :
            case ObjectType.kOT_CowRight :
                howMany = this.CountMyObjectsPerType(ObjectType.kOT_CowLeft);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_CowRight);
                break;
            case ObjectType.kOT_HedgeLeft :
            case ObjectType.kOT_HedgeRight :
                howMany = this.CountMyObjectsPerType(ObjectType.kOT_HedgeLeft);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_HedgeRight);
                break;
            case ObjectType.kOT_Barn :
            case ObjectType.kOT_BigSidewaysShed :
            case ObjectType.kOT_House :
            case ObjectType.kOT_Bus :
                howMany = this.CountMyObjectsPerType(ObjectType.kOT_Barn);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_BigSidewaysShed);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_House);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_Bus);
                break;
            case ObjectType.kOT_Crater :
            case ObjectType.kOT_HillockFarmyard :
            case ObjectType.kOT_SmallBump :
            case ObjectType.kOT_Crater2x2 :
            case ObjectType.kOT_Crater1x1 :
                howMany = this.CountMyObjectsPerType(ObjectType.kOT_Crater);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_HillockFarmyard);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_SmallBump);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_Crater2x2);
                howMany += this.CountMyObjectsPerType(ObjectType.kOT_Crater1x1);
                break;
            default :
                howMany = this.CountMyObjectsPerType(inType);
                break;
            }

            Globals.Assert(howMany != -1);
            return howMany;
        }

        public int CountMyObjectsPerType(ObjectType inType)
        {
            int howMany = 0;
            for (int i = 0; i < numPlacedObjects; i++) {
                if (placedObject[i].objectType == inType) {
                    howMany++;
                }

            }

            return howMany;
        }

        int GetMaxAllowedForType(ObjectType inType)
        {
            switch (inType) {
            case ObjectType.kOT_BigRock :
                return 200;
                
            case ObjectType.kOT_River :
                return (int)Game.Enum2.kMaxRivers;
                
            case ObjectType.kOT_Pond :
            case ObjectType.kOT_Snowdrift :
            case ObjectType.kOT_Puddle :
            case ObjectType.kOT_MudPuddle1x1 :
            case ObjectType.kOT_MudPuddle2x1 :
                return (int)Game.Enum2.kMaxPonds;
                
            case ObjectType.kOT_Rainbow :
                return (int)Game.Enum2.kMaxRainbows;
                
            case ObjectType.kOT_BoostArrowDown :
                return (int)Game.Enum2.kMaxBoostArrows;
                
            case ObjectType.kOT_Flowers :
            case ObjectType.kOT_BushLilac :
            case ObjectType.kOT_BushPink :
            case ObjectType.kOT_Tulips :
            case ObjectType.kOT_TulipsYellow :
            case ObjectType.kOT_TulipsWhite :
            case ObjectType.kOT_TulipsBlue :
                return (int)Game.Enum2.kMaxFlowerBunches;
                
            case ObjectType.kOT_Ramp :
            case ObjectType.kOT_BigRamp :
            case ObjectType.kOT_FarmRamp :
                return (int)Game.Enum2.kMaxRamps;
                
            case ObjectType.kOT_CowLeft :
            case ObjectType.kOT_CowRight :
                return (int)Game.Enum2.kMaxCows;
                
            case ObjectType.kOT_CowPatSprite :
                return (int)Game.Enum2.kMaxCowPats;
                
            case ObjectType.kOT_HedgeLeft :
            case ObjectType.kOT_HedgeRight :
                return (int)Game.Enum2.kMaxHedges;
                
            case ObjectType.kOT_Barn :
            case ObjectType.kOT_BigSidewaysShed :
            case ObjectType.kOT_House :
            case ObjectType.kOT_Bus :
                return (int)Game.Enum2.kMaxBuildings;
                
            case ObjectType.kOT_HayBaleDouble :
                return (int)Game.Enum2.kMaxHayBales;
                
            case ObjectType.kOT_Tractor :
            case ObjectType.kOT_BlueTractor :
                return (int)Game.Enum2.kMaxTractors;
                
            case ObjectType.kOT_OilDrum :
                return (int)Game.Enum2.kMaxOilDrums;
                
            case ObjectType.kOT_Chicken :
                return (int)Game.Enum2.kMaxChickens;
                
            case ObjectType.kOT_Venus :
                return (int)Game.Enum2.kMaxVenus;
                
            case ObjectType.kOT_Elephant :
                return (int)Game.Enum2.kMaxCrossingThings;
                
            case ObjectType.kOT_Snake :
                return (int)Game.Enum2.kMaxCrossingThings;
                
            case ObjectType.kOT_Lion :
                return (int)Game.Enum2.kMaxLions;
                
            case ObjectType.kOT_Log :
                return (int)Game.Enum2.kMaxWoodenLogs;
                
            case ObjectType.kOT_Waterfall :
                return (int)Game.Enum2.kMaxWaterfalls;
                
            case ObjectType.kOT_WallFarmYard :
                return (int)Game.Enum2.kMaxStoneWalls;
                
            case ObjectType.kOT_Crater :
            case ObjectType.kOT_HillockFarmyard :
            case ObjectType.kOT_SmallBump :
            case ObjectType.kOT_Crater2x2 :
            case ObjectType.kOT_Crater1x1 :
                return (int)Game.Enum2.kMaxCraters;
                
            case ObjectType.kOT_StarSpeedUp :
                return (int)Game.Enum2.kMaxStarSpeedUps;
                
            default :
                break;
            }

            return 100;
        }

        public bool CanIPleaseGetAnother(ObjectType inType)
        {
            if (numPlacedObjects >= 600) {
                return false;
            }

            int howManyDoIHave = this.CountMyObjects(inType);
            int maxAllowed = this.GetMaxAllowedForType(inType);
            return (howManyDoIHave < maxAllowed);
        }

        bool IsPickingUpAnObject()
        {
            for (int i = 0; i < (int)Enum3.kNumPickableTiles; i++) {
                if ((touchingPosition.x < (pickableObjectPosition[i].x + kPickableObjectSize)) && (touchingPosition.x > (pickableObjectPosition[i].x))) {
                    if ((touchingPosition.y < (pickableObjectPosition[i].y + kPickableObjectSize)) && (touchingPosition.y > (pickableObjectPosition[i].y))) {
                        if (!this.CanIPleaseGetAnother(pickableObjectType[i])) {
                            (query[(int) LevelBuilder_RossQueries.kLBQuery_TooManyObjects]).Show();
                            inQuery = true;
                            this.SetState( LevelBuilder_RossState.kLBState_FingerDownInLimbo);
                            return false;
                        }

                        drag.objectType = pickableObjectType[i];
                        drag.tileDragOrigin = Utilities.CGPointMake(0, 0);
                        drag.objectOnMapDraggingId = -1;
                        drag.haveFoundValidDropPosition = false;
                        drag.trashing = false;
                        this.SetState( LevelBuilder_RossState.kLBState_Dragging);
                        return true;
                    }

                }

            }

            return false;
        }

        public bool CheckScrollButton()
        {
            if (touchingPosition.x > 280) {
                if ((touchingPosition.y < (kScrollButtonY + (kScrollButtonHeight / 3))) && (touchingPosition.y > (kScrollButtonY - (kScrollButtonHeight / 3))))
                  {
                    this.SetState( LevelBuilder_RossState.kLBState_Scrolling);
                    notTouchingTimer = 0;
                    return true;
                }

            }

            return false;
        }

        public void Update_Scrolling()
        {
            const float kScrollSpeed = 55.0f;
            if (!touchingThisFrame) {
                notTouchingTimer += Constants.kFrameRate;
                if (notTouchingTimer > 0.2f) {
                    this.SetState( LevelBuilder_RossState.kLBState_FingerIsUp);
                    return;
                }

            }
            else {
                notTouchingTimer = 0;
            }

            float posOnBar;
            float barStart = kScrollButtonY - (kScrollButtonHeight / 2);
            float barEnd = kScrollButtonY + (kScrollButtonHeight / 2);
            posOnBar = -0.5f + Utilities.GetCosInterpolationHalfP1P2(touchingPosition.y, barStart, barEnd);

            #if UP_RACE
                tileMapOffset -= (kScrollSpeed * posOnBar);
            #else
                tileMapOffset += (kScrollSpeed * posOnBar);
            #endif

            if (tileMapOffset < 0) tileMapOffset = 0;

            float kMaxSize = Constants.TILE_SIZE * (float)(placedObject[finishObject].position.y - 2.0f);
            kMaxSize -= 64.0f;
            if (tileMapOffset > kMaxSize) {
                tileMapOffset = kMaxSize;
                goTooFarTimer += Constants.kFrameRate;
                if (goTooFarTimer > 0.75f) {
                    this.SetInfoWordsTooFar();
                    (query[(int) LevelBuilder_RossQueries.kLBQuery_InfoBridge]).Show();
                    inQuery = true;
                    (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_BubblesHigh);
                    (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_BubblesLowLoop, 0.3f);
                    this.SetState( LevelBuilder_RossState.kLBState_FingerDownInLimbo);
                    goTooFarTimer = 0.0f;
                }

            }
            else goTooFarTimer = 0.0f;

        }

        public void Update_PressingLimbo()
        {
            if (this.CheckScrollButton()) return;

            if (stateTimer < 0.019f) {
                if (!touchingThisFrame) {
                    this.IsButtonPressed();
                    this.SetState( LevelBuilder_RossState.kLBState_FingerIsUp);
                }

            }
            else {
                if (!touchingThisFrame) {
                    if (stateTimer < 1.5f) {
                        this.IsButtonPressed();
                    }

                    this.SetState( LevelBuilder_RossState.kLBState_FingerIsUp);
                    return;
                }

                if (this.IsPickingUpAnObject()) return;

                if (this.IsOnMap(touchingPosition)) {
                    CGPoint mapTouchPos = this.GetMapTouchPos(touchingPosition);
                    if (this.CheckStartMapDragSprite(mapTouchPos)) return;

                    mapTouchPos.x += (Constants.TILE_SIZE * Constants.LEFTMOST_TILE_ON_LB);
                    if (this.CheckStartMapDragTile(mapTouchPos)) {
                        return;
                    }

                }

            }

        }

        public void Update_FingerIsUp()
        {
            if (!touchingThisFrame) return;

            this.SetState( LevelBuilder_RossState.kLBState_PressingLimbo);
        }

        public void UpdateInQuery(int queryId)
        {
            if ((query[queryId]).chosenButton ==  QueryButton.nYes) {
                if (queryId == (int) LevelBuilder_RossQueries.kLBQuery_QuitAndWrite) {
                    this.QuitAndWriteData();
                    levelBuilderFinished = true;
                }
                else if (queryId == (int) LevelBuilder_RossQueries.kLBQuery_DeleteObjects) {
                    numPlacedObjects = 0;
                    (((Globals.g_world.game).tileMap).GetTileGrid()).ClearWithGrassyTiles(currentScene);
                    ((Globals.g_world.game).tileMap).AddStoneWallP1P2(4, 2, 2);
                    this.AddFinishingGate();
                    (((Globals.g_world.game).tileMap).tileGrid).AddSideWalls(currentScene);
                    (((Globals.g_world.game).tileMap).tileGrid).AddFinishingWallsExtended(currentScene);
                    ((Globals.g_world.game).tileMap).RefreshTextures();
                    (Globals.g_world.game).ResetMapObjects();
                }

            }
            else if ((query[queryId]).chosenButton ==  QueryButton.nNo) {
                if (queryId == (int) LevelBuilder_RossQueries.kLBQuery_QuitAndWrite) {
                    levelBuilderFinished = true;
                }

            }

        }

        public bool Update()
        {
            prevTileMapOffset = tileMapOffset;
            stateTimer += Constants.kFrameRate;
            for (int i = 0; i < (int)Enum.kLBNumFunnyWords; i++) (funnyWord[i]).Update();

            for (int i = 0; i < (int) LevelBuilder_RossQueries.kNumLBQueries; i++) {
                if ((query[i]).Update()) {
                    this.UpdateInQuery(i);
                    (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Swish);
                    inQuery = false;
                }

            }

            if (inQuery) return false;

            for (int i = 0; i < (int)Enum3.kNumPickableTiles; i++) {
                (upButton[i]).Update();
                (downButton[i]).Update();
            }

            for (int i = 0; i < (int) LevelBuilder_RossButtons.kNumLBButtons; i++) (button[i]).Update();

            switch (state) {
            case LevelBuilder_RossState.kLBState_FingerDownInLimbo :
                this.Update_FingerDownInLimbo();
                break;
            case LevelBuilder_RossState.kLBState_Dragging :
                this.Update_Dragging();
                break;
            case LevelBuilder_RossState.kLBState_DroppingLimbo :
                this.Update_DroppingLimbo();
                break;
            case LevelBuilder_RossState.kLBState_FingerIsUp :
                this.Update_FingerIsUp();
                break;
            case LevelBuilder_RossState.kLBState_Scrolling :
                this.Update_Scrolling();
                break;
            case LevelBuilder_RossState.kLBState_PressingLimbo :
                this.Update_PressingLimbo();
                break;
            default :
                break;
            }

            return (levelBuilderFinished);
        }

    }
}
