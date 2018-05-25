using UnityEngine;


namespace Default.Namespace
{
			public struct MyTouch{
		public CGPoint position;
		public TouchPhase phase;
		public int fingerId;
	};

	
    public partial class Constants
    {	
		public class RossColour
		{
 			public int myId;
			public float cRed;
            public float cGreen;
            public float cBlue;
			
			public RossColour(float r,float g,float b)
			{
				myId = -1;
				this.cRed = r;
				this.cGreen = g;
				this.cBlue = b;
			}			
			public RossColour(int inId, float r,float g,float b)
			{
				myId = inId;
				this.cRed = r;
				this.cGreen = g;
				this.cBlue = b;
			}			
        };
				
        public const bool ANDROID_25 = false;
		
//    public partial class Constants
  //  {
        public const int KBaseOffset = 20;
        public const int KBaseSize = 100;
        public const string KFontName = "Arial";
        public const int KStatusFontSize = 24;
        public const int KLabelFontSize = 14;
        public const int KScoreFontSize = 18;
        public const int KFuelBarX = 300;
        public const int KFuelBarY = 350;
        public const int KLabelY = 455;
        public const int KLightY = 460;
        public const int KSpeedX = 20;
        public const int KAngleX = 120;
        public const int KPositionX = 220;
        public const int KLabelOffset = 40;
        public const int KInitialVelocity = 100;
        public const int KInitialFuel = 4;
        public const int KMass = 80;
        public const int KGravity = 40;
       // public const object KMainThrustThreshold = -0.50;
       // public const float KLateralThrustThreshold = 0.00;
        public const int KMainThrust = 10000;
        public const int KRotationSpeed = 100;
        public const int KLateralSpeed = 10;
        public const int KMaxVelocity = 75;
        public const int KMaxRotation = 8;
        public const int KScoreVelocity = 4000;
        public const int KScoreFuel = 2500;
        public const int KScoreRotation = 2000;
        public const int KScoreDistance = 1500;
       // public const float KInputProcessingTime = 0.001;
       // public const string KUserNameDefaultKey = "userName";
        //public const string KHighScoresDefaultKey = "highScores";
        public const float KFPS = 50.0f;
        public const int KAccelerometerFrequency = 15;
      //  public const float KFilteringFactor = 0.1f;
      //  public const float KListenerDistance = 1.0f;
  //  }		

        public const float TILE_SIZE = 64.0f;
        public const float TILE_SIZE_20 = 1280.0f;
        public const float TILE_SIZE_HALF = 32.0f;
        public const float SPRITE_BASE_SCALE = 1.0f;
        public const float PLAYER_MAX_SPEED = 11.4f;
        public const float PLAYER_WHITE_STAR_SPEED = 0.9f;
        public const float TILE_MAP_HEIGHT = 1088.0f;
        public const float SCREEN_POS_BOTTOM = 480.0f;
        public const float LEVEL_BUILDER_TILE_SCALE = 0.68f;
        public const float GAP_FOR_BOTTOM_BUTTS_ON_LB = 224.0f;
        public const int LEFTMOST_TILE_ON_LB = 0;
        public const float LEVEL_BUILDER_MAP_BOTTOM = 390.0f;
        public const int LEVEL_BUILDER_VISIBLE_TILES_WIDTH = 10;
        public const int NUM_TILES_NOT_PLAYABLE_TO_LEFT = 2;
        public const float MAP_WIDTH = 384.0f;
        public const float TRACK_CENTRE_LINE = 192.0f;
        public const float PLAYABLE_MAP_LEFT_EDGE = 0.0f;
        public const float PLAYABLE_MAP_RIGHT_EDGE = 384.0f;
        public const int CUSTOM_LEVEL_OFFSET = 0;
        public const int ALWAYS_LOAD_ = -1;
        public const float kPlayerRadius = 20.0f;
        public const float kTimeDiffRecordingPiggy = 0.42f;
        public const int kMaxCharactersInCustomName = 16;
        public const float kStoneWallHeight = 20.0f;
        public const int NUM_SCENES = 7;
//        public const float kScaleForShorts = 0.05f;
  //      public const float kScreenMultiplierForShorts = 20.0f;
    //    public const float kScreenMultiplierForShorts480 = 9600.0f;

        public const float kScaleForShorts = 1.0f;
        public const float kScreenMultiplierForShorts = 1.0f;
        public const float kScreenMultiplierForShorts480 = 480.0f;
		
		
		
		public const float FIXED_RENDER_SCALE_VALUE = 1.0f;

		public const bool IAP_VERSION = false;

		public const bool SKIP_FRONTEND = false;
        public const int STARTING_LEVEL = 1;
		public const bool START_LB_LEVEL = false;
		public const bool START_LB = false;

        public const bool FORCE_PROFILE_RESET = false;
        public const bool UNLOCK_SOME_LEVELS = false;
        public const int UNLOCK_UPTO_LEVEL = 1;
		
        public const bool TESTING_POPUP = false;
        public const bool TESTING_ALERTS = false;
		public const bool TESTING_HOWYOULIKEMENOW = false;

		public const float SLOWER_SHEEP_VALUE = 0.35f;
        public const float PIGGY_SPEED_ADJUSTMENT_TOOL_HONING_VALUE = 0.08f;
        public const int CAMERA_FOLLOW_WHICH_PIGGY = 1;
        public const bool QUICK_HAND = true;
        public const int MOVE_PLAYER_FORWARD = 0;
				public const bool UNLOCK_ALL_LEVELS = false;
        public const int RESET_LEVEL = -1;
        public const bool UNLOCK_WITH_APPLES = true;
        public const int RECORDING_WHICH_PIGGY = -1;
        public const int MAX_PLAYERS = 5;
        public const int NUM_LEVELS_IN_CUPS_PLUS_BONUSES = 83;
        public const int NUM_APPLES_TO_UNLOCK_5 = 80;
        public const int NUM_APPLES_TO_UNLOCK_7 = 120;
        public const int NUM_APPLES_TO_UNLOCK_9 = 160;
        public const int NUM_APPLES_TO_UNLOCK_10 = 195; 

//		public const int NUM_APPLES_TO_UNLOCK_9 = 180;	//192 = 3 on all
//        public const int NUM_APPLES_TO_UNLOCK_10 = 210; //216 = 3 on all
		//Kind of depends if there are two separate IAP or one IAP unlocks all levels and gets rid
		//of ads - also depends how annoying the ads are...
		
		//        public const int NUM_APPLES_TO_UNLOCK_10 = 195;
        public const bool READ_LEVELS_FROM_BINARY_FILES = true;
        public const bool WRITE_CUSTOM_LEVELS_TO_BINARY_FILES = true;
        public const bool READ_CUSTOM_LEVELS_FROM_BINARY_FILES = true;
        public const bool AI_PIGGIES = true;
        public const bool TURN_OFF_RAYS = true;
        public const bool TESTING_NETWORK_SHIZ = true;
        public const bool SHOW_GAMECENTER_OVER_MAIN = true;
        public const bool PERFORM_LEVEL_FILE_VALIDATION_CHECK = true;
        public const bool REMOVE_ASSERTS_FOR_FINAL_VERSION = true;
        public const bool ASSERT_NOTHING_IS_OUT_OF_BOUNDS = true;
        public const bool TEST_SHORTS = true;
        public const bool TEST_VERT_SHORTS = true;
        public const bool ZOOMING_MATRIX_TEST = true;
        public const bool HARVEST_TEST = true;
        public const bool USE_CRYSTAL = true;
        public const bool DONT_RECORD_PIGGY_TIMES = true;
        public const bool IP4_TEST = true;
        public const bool FACEBOOK_BUTTON = true;
        public const bool VIEWCONTROLLER_TEST = true;
        public const bool ADD_CUSTOM_FLOCKS_TEST = true;
        public const bool TWENTYFOUR_LEVELS = true;
        public const bool SIMULTANEOUS_START_TEST = true;
        public const bool NOT_FINAL_VERSION = true;
   
        public static RossColour kColourOrange = new RossColour((int)World.Colours.kOrange,
        1.0f, 0.4f, 0.0f);
        public static RossColour kColourRedText = new RossColour((int)World.Colours.kColourRedText,
        0.8f, 0.037f, 0.037f);
        public static RossColour kColourRedTip = new RossColour((int)World.Colours.kColourRedTip,
        0.55f * 0.85f, 0.03f * 0.85f, 0.03f * 0.85f);
        public static RossColour kColourRed = new RossColour((int)World.Colours.kRed,
        0.55f, 0.03f, 0.03f);
        public static RossColour kColourStarCupText = new RossColour((int)World.Colours.kStarCup,
        0.32f, 0.22f, 0.5f);
        public static RossColour kColourFarmText = new RossColour((int)World.Colours.kFarmText,
        0.46f, 0.3f, 0.06f);
        public static RossColour kColourCountryText = new RossColour((int)World.Colours.kCountry,
        0.12f, 0.5f, 0.1f);
        public static RossColour kColourPurpleMenuBackRays = new RossColour((int)World.Colours.kPurpleMenuBackRays,
        1, 0.44f, 0.85f);
        public static RossColour kColourYellowMenuBackRays = new RossColour((int)World.Colours.kYellowMenuBackRays,
        1, 1.0f, 0.2f);
        public static RossColour kColourGreenMenuBackRays = new RossColour(
        1, 1.0f, 0.35f);
        public static RossColour kColourPurpleMenuBackText = new RossColour((int)World.Colours.kPurpleMenuBack,
        0.51f, 0.08f, 0.34f);
        public static RossColour kColourPurpleMenuBack = new RossColour((int)World.Colours.kPurpleMenuBack,
        0.64f, 0.44f, 1);
        public static RossColour kColourYellowMenuBack = new RossColour((int)World.Colours.kYellowMenuBack,
        1, 0.6f, 0.2f);
        public static RossColour kColourWhite = new RossColour((int)World.Colours.kWhite,
        1.0f, 1.0f, 1.0f);
        public static RossColour kColourLightGreen = new RossColour((int)World.Colours.kLightGreen,
        0.2f, 0.46f, 0.145f);
        public static RossColour kColourGreenMenuBack = new RossColour((int)World.Colours.kGreenMenuBack,
        0.1f, 0.8f, 0.07f);
        public static RossColour red = new RossColour(
        1, 0, 0);
        public static RossColour darkgreen = new RossColour(
        0, 0.5f, 0);
        public static RossColour betweengreen = new RossColour(
        0, 0.88f, 0.1f);
        public static RossColour kColourBrightGreen = new RossColour(
        0.4f, 0.9f, 0.25f);
        public static RossColour kColourPink = new RossColour((int)World.Colours.kPink,
        0.85f, 0.22f, 0.48f);
        public static RossColour indigo = new RossColour((int)World.Colours.kIndigo,
        0.25f, 0.1f, 1);
        public static RossColour kColourLilac = new RossColour((int)World.Colours.kLilac,
        0.32f, 0.22f, 0.6f);
        public static RossColour orange = new RossColour(
        1, 0.5f, 0.3f);
        public static RossColour kColourBrown = new RossColour((int)World.Colours.kBrown,
        0.47f, 0.3f, 0.075f);
        public static RossColour kColourYellowLemon = new RossColour((int)World.Colours.kYellowLemon,
        0.8f, 0.7f, 0.12f);
        public static RossColour kColourYellow = new RossColour((int)World.Colours.kYellow,
        1, 1, 0.2f);
        public static RossColour kColourDarkblue = new RossColour((int)World.Colours.kDarkBlue,
        0.2f, 0.3f, 0.6f);
        public static RossColour kColourLightblue = new RossColour((int)World.Colours.kLightBlue,
        0.17f, 0.4f, 0.6f);
        public static RossColour kColourTurquoiseText = new RossColour((int)World.Colours.kColourTurquoiseText,
        0.025f, 0.44f, 0.53f);
        public static RossColour kColourTurquoise = new RossColour(
        0.1f, 1, 0.8f);
        public static RossColour kBrown_FleeceMenu = new RossColour((int)World.Colours.kBrown_FleeceMenu,
        0.25f, 0.09f, 0.006f);	
	}
}
