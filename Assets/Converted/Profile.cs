using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;



namespace Default.Namespace
{
    public enum  TrophyType {
        kTrophy_NotGot = -1,
        kTrophy_ThreeApples,
        kTrophy_TwoApples,
        kTrophy_OneApple,
        Types
    }
    public enum  BestTimeSet {
        t_Normal = 0,
        t_Custom,
        t_Easy,
        eSets
    }
    public enum  SpeedUpProgressEnum {
        kSpeedUp_InitialSpeed = 0,
        kSpeedUp_FirstSpeedBoost,
        kSpeedUp_SecondSpeedBoost,
        kSpeedUp_ThirdSpeedBoost,
        kNumSpeedUps
    }
    public class Profile
    {
        public Cup[] cup = new Cup[(int)Enum4.kNumCups];
        public int[] pendingAchievementsId = new int[(int)Enum6.kMaxPendingAchievements];
        public int numPendingAchievements;
        public bool[] seenTipForLevel = new bool[(int)Profile.Enum6.kNumLevels];
        public bool[] secretLevelShown = new bool[(int)Profile.Enum6.kNumLevels];
        public bool[] levelVisible = new bool[(int)Profile.Enum6.kNumLevels];
        public int selectedLevel;
        public int selectedLevelCustom;
        public ProfilePreferences preferences;
        public ProfileInformation profileInfo;
        public NotSavedProfileInfo notSavedInfo;
        public bool customLevelInfoLoadedYet;
        public bool haveTriedGameCenterYet;
        public int[] customLevelMade = new int[(int)Profile.Enum6.kNumLevels];
        public string[] customLevelNames = new string[(int)Profile.Enum6.kNumCustomLevels];
        public int[] numApples = new int[(int)Enum4.kNumCups];
        public SpeedUpProgressEnum speedUpProgress;
        public float[] breakerTime = new float[Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES];
        public int[] breakerLevel = new int[(int)Enum2.kNumAchievements];
        string[] outLevelName = new string[144]
        {"Rainbow Power\n", "Hedging Around\n", "\n", "Forest Path\n", "Piggy Meadow\n", "Woolly Wash\n", "Burn The Turns\n", "Hogzwallop\n", "Flying Flock\n",
              "\n", "On The Hoof\n", "Ride The Ramps\n", "herdy gerdy\n", "Moo Moo\n", "Mazy Dazy\n", "Easy One\n", "Duckpond Dash\n", "Hooves Of Wonder\n",
              "Sheep Sprint\n", "Roundabout Route\n", "Hedge Shuffle\n", "banana split\n", "Wet Wet Wet\n", "new lev\n", "Alley Hogs\n", "rooftop rampage\n",
              "Barn Dance\n", "dodofloe\n", "prickle dune\n", "moon zoom\n", "go with the floe\n", "Trotterville\n", "Humpty Jumpty\n", "corralicious\n",
              "welly vision\n", "haystack ave hay fever!\n", "Tractor Factor\n", "alleywallay\n", "stone wall\n", "muddy bumps\n", "The Swineyard\n", "custom\n"
              , "House Block\n", "Lift Off\n", "chicanery\n", "custle\n", "snake ditch\n", "Star Stables\n", "Park Stroll\n", "Forever Bridges\n",
              "twin rivers\n", "Swine Cone\n", "the herd\n", "Ram Shackle\n", "the hedge\n", "Bridge Sprint\n", "sharp turn\n", "Roof Ride\n", "get bumpy \n",
              "Mudville\n", "Barrels Of Fun\n", "barn jump\n", "Stables Sprint\n", "Chicken Flight\n", "Herd Hurdles\n", "new level\n", "Barrel Ram-page\n",
              "new level\n", "new level\n", "new level\n", "new level\n", "new level\n", "Sheep Shape\n", "The Migration\n", "The Woods\n", "Trampoline Turns\n"
              , "Forest Flock\n", "Obstacle Course\n", "Mud Trap\n", "Baa-rathon\n", "The Harvest\n", "new level\n", "Chicken Panic\n", "Woolly Jumper\n",
              "new level\n", "new level\n", "new level\n", "new level\n", "cow field\n", "new level\n", "new level\n", "new level\n", "new level\n",
              "new level\n", "new level\n", "new level\n", "Hedge Rush\n", "hay bales\n", "Mud Slide\n", "The Junkyard\n", "the motorway\n", "Bouncy Ride\n",
              "new level\n", "new level\n", "Pumpkin Patch\n", "Barrel Breeze\n", "Veg Lines\n", "Flower Frenzy\n", "new level\n", "new level\n", "new level\n"
              , "new level\n", "new level\n", "cow field\n", "new level\n", "new level\n", "new level\n", "new level\n", "new level\n", "new level\n",
              "Gnome Sheep Gnome\n", "The Big Jump\n", "Sheep Traffic\n", "River Panic\n", "Tulip Trance\n", "The Campsite\n", "on your marks\n",
              "Pools Of Puddles\n", "The Orchard\n", "Swine Sprint\n", "Gnome Way\n", "new level\n", "Pumpkin Parade\n", "Shear Madness\n", "Gnome Trap\n",
              "Marrow Mayhem\n", "Sheeple Chase\n", "Tricky Tractors\n", "Pumpkin Splat\n", "Bridge Too Baa\n", "Road Hog\n", "Piggy Pile-Up\n", "new level\n",
              "Shirley's Patch\n",};
        string[] outLevelNameGerman = new string[80]
        {"Kinderleicht\n", "Muh Muh\n", "Schweineh%tchen\n", "%ber Sieben B$cke\n", "Spaziergang Im Park\n", "Heckenhectik\n", "HerdenH%rden\n",
              "Flink Wie Eine Ente\n", "Lamm Im Schlamm\n", "Stallsprint\n", "Wilde H%hner\n", "F#sser-Bockspringen\n", "Gem%ser#nder\n", "Schlammheim\n",
              "K%rbiskrieg\n", "Tulpentrance\n", "BR%CKENSPRINT\n", "BR%CKE AN BR%CKE\n", "SAUSTALL\n", "ZWERGENAUFSTAND\n", "MIT QUIETSCHENDEN HUFEN\n",
              "DER GROssE SPRUNG\n", "PANIK AM FLUSS\n", "KREISVERKEHR\n", "WOLL IN FORM\n", "UM DIE KURVEN H%PFEN\n", "SHIRLEYS PL#TZCHEN\n",
              "TONNENWEISE SPAss\n", "SCHURER WAHNSINN \n", "HINDERNISLAUF\n", "K%RBISBEET\n", "K%RBISCHAOS\n", "WUNDERBARE HUFE\n", "ACHTUNG SCHAFE\n",
              "REGENBOGEN\n", "DER ZELTPLATZ\n", "NASS BIS AUF DIE HAUT\n", "IM SCHWEINSGALOPP\n", "HINDERNDE HECKEN \n", "PF%TZEN, PF%TZEN, PF%TZEN\n",
              "M#H-RATHON\n", "SCHEUNENTANZ\n", "BLUMENRAUSCH\n", "SCHLAMMFALLE\n", "GASSENSCHWEINE\n", "H#USERBLOCK\n", "TRAKTORFAKTOR \n",
              "DER SCHROTTPLATZ\n", "DER OBSTGARTEN\n", "ZWERGENFALLE\n", "HOLPERSTRAssE\n", "RAMPENRENNEN\n", "WALDWEG\n", "SCHAFSSPRINT\n", "KREUZ UND QUER\n"
              , "SCHWEINEWIESE\n", "EIN HAUCH VON F#SSERN\n", "DIE WANDERUNG\n", "WALDHERDE\n", "SPRINGSCHAF\n", "DER SCHWEINEPFERCH\n", "DIE W#LDER\n",
              "H%HNERFLUCHT \n", "%BER DIE D#CHER \n", "HERDENLAUF\n", "WAS F%R'N SCHAFSK#SE \n", "WOLLPULLOVER\n", "HECKENDURCHEINANDER\n", "VERKEHRSSCHWEIN\n"
              , "ZWERGENWEG\n", "WOLLW#SCHE\n", "FLUGSCHAF\n", "DAS SCHLAMMBAD\n", "SAUHAUFEN \n", "STARTKLAR\n", "STERNENSTALL\n", "K%RBISMATSCH\n",
              "SCHWEINESPRINT\n", "VERFLIXTE TRAKTOREN\n", "HACHSENHEIM\n",};
        public const float kBigBestTime = 1000000.0f;

		
		
		[System.Serializable]
		public class ProfileInformation{
            public bool haveSeenControlChoiceYet;
            public bool seenHowToYet;
            public bool seenCrystalSplash;
            public bool mentionedTrophy;
            public bool seenUnlockedBonus1;
            public bool seenUnlockedBonus2;
            public bool seenUnlockedBonus3;
            public bool seenAnotherPiggy1;
            public bool seenAnotherPiggy2;
            public bool[] seenWelcomeToCup = new bool [(int)Enum4.kNumCups];
            public bool feelGoodScreenPending;
            public bool appleScreenPending;
            public bool speedUpScreenPending;
            public bool anotherPiggyScreenPending;
            public int feelGoodProgress;
            public int minimumSpeedupProgress;
            public bool[] terrainUnlocked = new bool [(int)Enum6.kMaxTerrains];
            public ProfileInfoPerLevel[] level = new ProfileInfoPerLevel[(int)Profile.Enum6.kNumLevelsPlusOne];
            public int numRacesWithoutBeingAskedToRate;
            public bool[] achievementSeen = new bool [(int)Enum2.kNumAchievements];
            public bool facebookLoggedIn;
            public bool[] reachedCupWhenStillLocked = new bool [(int)Enum4.kNumCups];
        };

		
		public class ProfileInformation_Save_v1{
            public bool haveSeenControlChoiceYet;
            public bool seenHowToYet;
            public bool seenCrystalSplash;
            public bool mentionedTrophy;
            public bool seenUnlockedBonus1;
            public bool seenUnlockedBonus2;
            public bool seenUnlockedBonus3;
            public bool seenAnotherPiggy1;
            public bool seenAnotherPiggy2;
            public bool seenWelcomeToFarmyard;
            public bool seenWelcomeToStar;
            public bool feelGoodScreenPending;
            public bool appleScreenPending;
            public bool speedUpScreenPending;
            public bool anotherPiggyScreenPending;
            public int feelGoodProgress;
            public bool[] terrainUnlocked = new bool [5];
            ProfileInfoPerLevel_Save_v1[] level = new ProfileInfoPerLevel_Save_v1[28];
        };

		public class NotSavedProfileInfo{
            public NotSavedProfileInfoPerLevel[] level = new NotSavedProfileInfoPerLevel [(int)Profile.Enum6.kNumLevelsPlusOne];
        };
        public class NotSavedProfileInfoPerLevel{
            public long[] bestTime = new long [(int)BestTimeSet.eSets];
            public int numConsecutiveFails;
            public int numConsecutiveFailsByTime;
            public int numConsecutiveFails3apples;
            public int numConsecutiveFailsByTime3apples;
        };

		
		[System.Serializable]
        public class ProfileInfoPerLevel{
            public long[] bestTime = new long [(int)BestTimeSet.eSets];
            public TrophyType gotTrophy;
            public bool levelUnlocked;
            public bool usingSlowerPig;
            public bool usingSlowerPig3apples;
        };
		
        public class ProfileInfoPerLevel_Save_v1{
            long[] bestTime = new long [3];
            TrophyType gotTrophy;
            bool levelUnlocked;
            bool usingSlowerPig;
            bool usingSlowerPig3apples;
        };
		
		[System.Serializable]
		public class ProfilePreferencesFake{
            public bool musicOn;
            public bool soundFxOn;
            public bool ghostOn;
            public bool diffEasy;
            public bool controlTilt;
            public bool tiltExpert;
            public bool controlFinger;
        };

		[System.Serializable]
		public class ProfilePreferences{
            public bool musicOn;
            public bool soundFxOn;
            public bool ghostOn;
            public bool diffEasy;
            public bool controlTilt;
            public bool tiltExpert;
            public bool controlFinger;
        };

		public class ProfilePreferences_Save_v1{
            public bool musicOn;
            public bool soundFxOn;
            public bool ghostOn;
            public bool diffEasy;
            public bool controlTilt;
        };
        public enum Enum5 {
            kFeelGoodProgress_Start = 0,
            kFeelGoodProgress_WelcomeToMudCup,
            kFeelGoodProgress_WelcomeToPenguinCup,
            kFeelGoodProgress_WelcomeToCountryCup,
            kFeelGoodProgress_WelcomeToFarmyardCup,
            kFeelGoodProgress_WelcomeToStarCup,
            kFeelGoodProgress_MeadowDone3Apples,
            kFeelGoodProgress_MudDone3Apples,
            kFeelGoodProgress_PenguinDone3Apples,
            kFeelGoodProgress_CountrysideDone3Apples,
            kFeelGoodProgress_FarmyardDone3Apples,
            kFeelGoodProgress_StarDone3Apples,
            kFeelGoodProgress_PassedCup1,
            kFeelGoodProgress_PassedCup2,
            kFeelGoodProgress_PassedCup3,
            kFeelGoodProgress_PassedCup4,
            kFeelGoodProgress_PassedCup5,
            kFeelGoodProgress_PassedCup6,
            kFeelGoodProgress_PassedCup7,
            kFeelGoodProgress_PassedCup8,
            kFeelGoodProgress_PassedCup9,
            kFeelGoodProgress_PassedCup10,
            kFeelGoodProgress_UnlockedTerrainDesert,
            kFeelGoodProgress_UnlockedTerrainIce,
            kFeelGoodProgress_UnlockedTerrainMoon,
            kFeelGoodProgress_CompletedGame
        };
        public enum  Enum6 {
            kNumCustomLevels = 27,
            kNumLevelsPerCup = 8,
            kNumBonusLevels = 3,
            kNumLevelsNotBonus = ((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup),
            kNumLevels = (((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) + Profile.Enum6.kNumBonusLevels),
            kNumLevelsPlusOne,
            kMaxPendingAchievements = 10,
            kMaxTerrains = 7,
            kNumPagesForCustomLevels = 3
        };
        public enum Enum2 {
            kAchievement_UnlockableCup5 = 0,
            kAchievement_UnlockableCup7,
            kAchievement_UnlockableCup9,
            kAchievement_UnlockableCup10,
            kAchievement_CompletedCup1,
            kAchievement_CompletedCup2,
            kAchievement_CompletedCup3,
            kAchievement_CompletedCup4,
            kAchievement_CompletedCup5,
            kAchievement_CompletedCup6,
            kAchievement_CompletedCup7,
            kAchievement_CompletedCup8,
            kAchievement_CompletedCup9,
            kAchievement_CompletedCup10,
            kAchievement_CreateTrack,
            kAchievement_ShirleyThump,
            kAchievement_Beat1Pig,
            kAchievement_Beat3Pigs,
            kAchievement_HighFlier,
            kAchievement_RoofRunner,
            kAchievement_SpeedBoost,
            kAchievement_HitAppleTree,
            kAchievement_Hit5AppleTrees,
            kAchievement_PigPush,
            kAchievement_RecordBreaker_CowField,
            kAchievement_RecordBreaker_LongJumps,
            kAchievement_RecordBreaker_MudVille,
            kAchievement_RecordBreaker_CurlyWurly,
            kAchievement_RecordBreaker_FourRivers,
            kAchievement_RecordBreaker_LongRoof,
            kAchievement_RecordBreaker_PumpkinWiggle,
            kAchievement_RecordBreaker_CampSite,
            kAchievement_RecordBreaker_HOW,
            kAchievement_RecordBreaker_Junkyard,
            kAchievement_RecordBreaker_GetUp,
            kAchievement_RecordBreaker_BridgeJump,
            kAchievement_RecordBreaker_RainbowRuns,
            kAchievement_RecordBreaker_TulipChicane,
            kAchievement_Hit30Rainbows,
            kAchievement_WeaveMagic,
            kAchievement_DryDucks,
            kAchievement_BarrelMaze,
            kAchievement_PassDayDreamNoFlowers,
            kAchievement_PassVegDodgeNoVeg,
            kAchievement_PassSquashDodgeNoVeg,
            kAchievement_PassPCurvyNoFlock,
            kAchievement_PassMigrationNoMud,
            kAchievement_PassRoadSheepNoSheep,
            kAchievement_PassMudvilleNoHouse,
            kAchievement_PassMazyDazyNoHedge,
            kAchievement_WinSnowForestNoTrees,
            kAchievement_WinHogzwallopNotWet,
            kAchievement_WinPumpkinJumpsNoPumpkins,
            kAchievement_WinTrottervilleNoHouse,
            kNumAchievements
        };
        public enum Enum3 {
            kHud_NoRaceTip,
            kHud_RaceTipWithImage,
            kHud_RaceTipWithNothing
        };
        public enum  Enum4 {
            kCupMeadow = 0,
            kCupMud,
            kCupPenguin,
            kCupCountryside,
            kCupFarmyard,
            kCupStar,
            kCupSeven,
            kCupEight,
            kCupNine,
            kCupTen,
            kNumCups,
            kNumCupsPlusBonusLevels
        };
        //extern const float kBigBestTime;
        public int SelectedLevel
        {
            get;
            set;
        }

        public int SelectedLevelCustom
        {
            get;
            set;
        }

        public ProfilePreferences Preferences
        {
            get;
            set;
        }

        public ProfileInformation ProfileInfo
        {
            get;
            set;
        }

        public bool HaveTriedGameCenterYet
        {
            get;
            set;
        }

        public NotSavedProfileInfo NotSavedInfo
        {
            get;
            set;
        }

        public SpeedUpProgressEnum SpeedUpProgress
        {
            get;
            set;
        }

				string xcodeDataFilePath;

		//public void SetFeelGoodScreenPending(BOOL inThing) {feelGoodScreenPending = inThing;}///@property(readwrite,assign) BOOL feelGoodScreenPending;
//public void SetAppleScreenPending(BOOL inThing) {appleScreenPending = inThing;}///@property(readwrite,assign) BOOL appleScreenPending;
//public void SetSpeedUpScreenPending(BOOL inThing) {speedUpScreenPending = inThing;}///@property(readwrite,assign) BOOL speedUpScreenPending;
//public void SetAnotherPiggyScreenPending(BOOL inThing) {anotherPiggyScreenPending = inThing;}///@property(readwrite,assign) BOOL anotherPiggyScreenPending;
//public void SetFeelGoodProgress(short int inThing) {feelGoodProgress = inThing;}///@property(readwrite,assign) short int feelGoodProgress;
public void SetSelectedLevel(int inThing) {selectedLevel = inThing;}///@property(readwrite,assign) int selectedLevel;
public void SetSelectedLevelCustom(int inThing) {selectedLevelCustom = inThing;}///@property(readwrite,assign) int selectedLevelCustom;
public void SetPreferences(ProfilePreferences inThing) {preferences = inThing;}///@property(readwrite,assign) ProfilePreferences preferences;
public void SetProfileInfo(ProfileInformation inThing) {profileInfo = inThing;}///@property(readwrite,assign) ProfileInformation profileInfo;
public void SetNotSavedInfo(NotSavedProfileInfo inThing) {notSavedInfo = inThing;}///@property(readwrite,assign) NotSavedProfileInfo notSavedInfo;
//public void SetLevelBuilder_RossUnlocked(BOOL inThing) {levelBuilderUnlocked = inThing;}///@property(readwrite,assign) BOOL levelBuilderUnlocked;
//public void SetSeenHowToYet(BOOL inThing) {seenHowToYet = inThing;}///@property(readwrite,assign) BOOL seenHowToYet;
//public void SetSeenCrystalSplash(BOOL inThing) {seenCrystalSplash = inThing;}///@property(readwrite,assign) BOOL seenCrystalSplash;
//public void SetMentionedTrophy(BOOL inThing) {mentionedTrophy = inThing;}///@property(readwrite,assign) BOOL mentionedTrophy;
public void SetSpeedUpProgress(SpeedUpProgressEnum inThing) {speedUpProgress = inThing;}///@property(readwrite,assign) SpeedUpProgressEnum speedUpProgress;
public void SetHaveTriedGameCenterYet(bool inThing) {haveTriedGameCenterYet = inThing;}///@property(readwrite,assign) BOOL haveTriedGameCenterYet;

        public Profile ()
		{
			//if (!base.init()) return null;
			
			profileInfo = new ProfileInformation();
			notSavedInfo = new NotSavedProfileInfo();
			
			for(int i = 0; i < (int)Enum6.kNumLevelsPlusOne; i++)
			{
				profileInfo.level[i] = new ProfileInfoPerLevel();
			}
			for(int i = 0; i < (int)Enum6.kNumLevelsPlusOne; i++)
			{
				notSavedInfo.level[i] = new NotSavedProfileInfoPerLevel();
			}
			
			preferences = new ProfilePreferences();
			
/*			for(int i = 0; i < (int)Enum6.kMaxTerrains; i++)
			{
				profileInfo.terrainUnlocked[i] = new bool();
			}
			
			            public bool[] terrainUnlocked = new bool [(int)Enum6.kMaxTerrains];
            public ProfileInfoPerLevel[] level = new ProfileInfoPerLevel[(int)Profile.Enum6.kNumLevelsPlusOne];
            public int numRacesWithoutBeingAskedToRate;
            public bool[] achievementSeen = new bool [(int)Enum2.kNumAchievements];
            public bool facebookLoggedIn;
            public bool[] reachedCupWhenStillLocked = new bool [(int)Enum4.kNumCups];*/

			
			haveTriedGameCenterYet = false;
			profileInfo.appleScreenPending = false;
			profileInfo.speedUpScreenPending = false;
			profileInfo.anotherPiggyScreenPending = false;
			//customLevelNames = new List<string> (0);
			speedUpProgress = SpeedUpProgressEnum.kSpeedUp_InitialSpeed;
			numPendingAchievements = 0;
			for (int i = 0; i < (int)Enum6.kMaxPendingAchievements; i++) {
				pendingAchievementsId [i] = -1;
			}

			for (int i = 0; i < (int)Enum4.kNumCups; i++) {
				cup [i] = new Cup ();
			}

			this.SetupCupInfo ();

			if (Constants.SKIP_FRONTEND)
			{
                selectedLevel = Constants.STARTING_LEVEL;
                selectedLevelCustom = 0;
			}else{
			selectedLevel = 0;
			selectedLevelCustom = 0;
			}

			Globals.Assert ((int)Enum6.kMaxTerrains == (int)SceneType.kNumScenes);
			for (int i = 0; i < (int)Profile.Enum6.kNumLevels; i++) {
				notSavedInfo.level [i] = new NotSavedProfileInfoPerLevel();
				
				secretLevelShown [i] = false;
				seenTipForLevel [i] = false;
				notSavedInfo.level [i].numConsecutiveFails = 0;
				notSavedInfo.level [i].numConsecutiveFailsByTime = 0;
				notSavedInfo.level [i].numConsecutiveFails3apples = 0;
				notSavedInfo.level [i].numConsecutiveFailsByTime3apples = 0;
            }

            profileInfo.seenCrystalSplash = false;
            customLevelInfoLoadedYet = false;
            this.SetupBreakerTimes();
            //return this;
        }
        public string GetGermanNameWithoutSymbols(int level)
        {
            string[] levelName = new string [Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES]
            {"Kinderleicht", "Muh Muh", "Schweinehütchen", "über Sieben Böcke", "Spaziergang Im Park", "Heckenhectik", "HerdenHürden", "Flink Wie Eine Ente"
                  , "Lamm Im Schlamm", "Stallsprint", "Wilde Hühner", "Fässer-Bockspringen", "Gemüseränder", "Schlammheim", "Kürbiskrieg", "Tulpentrance",
                  "BRüCKENSPRINT", "BRüCKE AN BRüCKE", "SAUSTALL", "ZWERGENAUFSTAND", "MIT QUIETSCHENDEN HUFEN", "DER GROssE SPRUNG", "PANIK AM FLUSS",
                  "KREISVERKEHR", "WOLL IN FORM", "UM DIE KURVEN HüPFEN", "SHIRLEYS PLäTZCHEN", "TONNENWEISE SPAss", "SCHURER WAHNSINN ", "HINDERNISLAUF",
                  "KüRBISBEET", "KüRBISCHAOS", "WUNDERBARE HUFE", "ACHTUNG SCHAFE", "REGENBOGEN", "DER ZELTPLATZ", "NASS BIS AUF DIE HAUT",
                  "IM SCHWEINSGALOPP", "HINDERNDE HECKEN ", "PFüTZEN, PFüTZEN, PFüTZEN", "MäH-RATHON", "SCHEUNENTANZ", "BLUMENRAUSCH", "SCHLAMMFALLE",
                  "GASSENSCHWEINE", "HäUSERBLOCK", "TRAKTORFAKTOR ", "DER SCHROTTPLATZ", "DER OBSTGARTEN", "ZWERGENFALLE", "HOLPERSTRAssE", "RAMPENRENNEN",
                  "WALDWEG", "SCHAFSSPRINT", "KREUZ UND QUER", "SCHWEINEWIESE", "EIN HAUCH VON FäSSERN", "DIE WANDERUNG", "WALDHERDE", "SPRINGSCHAF",
                  "DER SCHWEINEPFERCH", "DIE WäLDER", "HüHNERFLUCHT ", "üBER DIE DäCHER ", "HERDENLAUF", "WAS FüR'N SCHAFSKäSE ", "WOLLPULLOVER",
                  "HECKENDURCHEINANDER", "VERKEHRSSCHWEIN", "ZWERGENWEG", "WOLLWäSCHE", "FLUGSCHAF", "DAS SCHLAMMBAD", "SAUHAUFEN ", "STARTKLAR",
                  "STERNENSTALL", "KüRBISMATSCH", "SCHWEINESPRINT", "VERFLIXTE TRAKTOREN", "HACHSENHEIM", "BonusNotUsed", "BonusNotUsed", "BonusNotUsed"};
            Globals.Assert(level < Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES);
            return levelName[(int)level];
        }

        public void FirstInitialisation()
        {
            this.PrintoutCupAndLevelNames();
        }

        public void PrintoutCupAndLevelNames()
        {

            #if PRINTOUT_LEVELNAMES
                int lev = 0;
                for (int i = 0; i < 10; i++) {
                    string cupName = (cup[i]).name;
                    for (int j = 0; j < 8; j++) {
                        string levelName = this.GetLevelNameString(lev);
                        lev++;
                    }

                }

            #endif

            #if PRINTOUT_RACETIPS
                lev = 0;
                for (int i = 0; i < 10; i++) {
                    string cupName = (cup[i]).name;
                    for (int j = 0; j < 8; j++) {
                        if (this.HasRaceTip(lev)) {
                            string levelName = this.GetLevelNameString(lev);
                            for (int l = 0; l < 5; l++) {
                                string nextLine = (((Globals.g_world.game).hud).anotherPiggyScreen).GetTipLineP1(l, lev);
                                string str = new string(nextLine);
                            }

                        }

                        lev++;
                    }

                }

            #endif

            #if PRINTOUT_ACHIEVEMENT_DESCRIPTIONS
                lev = 0;
                for (int i = 0; i < kNumAchievements; i++) {
                    string achName = this.GetAchievementName(i);
                    string strId = this.GetAchievementStringId(i);
                    string str = this.GetAchievementDescription(i);
                }

            #endif

        }

        public void SetupBreakerTimes ()
		{
			float[] tempThing = new float[600];
			int[] tempBL = new int[(int)Enum2.kNumAchievements];
			for (int i = 0; i < 600; i++) {
				tempThing [i] = -1.0f;
			}

			for (int i = 0; i < (int)Enum2.kNumAchievements; i++) {
				tempBL [i] = -1;
			}

			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_CowField] = (int)LevelBuilder_Ross.Enum2.kGrass1_8_MdwCup_Race8_CowField;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_LongJumps] = (int)LevelBuilder_Ross.Enum2.kMud_LongJumps;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_MudVille] = (int)LevelBuilder_Ross.Enum2.kMud_MudVille;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_CurlyWurly] = (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_FourRivers] = (int)LevelBuilder_Ross.Enum2.kGrass9_4_FourRivers;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_LongRoof] = (int)LevelBuilder_Ross.Enum2.kMud2_4_MudCup_Race4_LongRoof;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_PumpkinWiggle] = (int)LevelBuilder_Ross.Enum2.kMud8_5_PumpkinWiggle;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_CampSite] = (int)LevelBuilder_Ross.Enum2.kGrass9_5_Campyard;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_HOW] = (int)LevelBuilder_Ross.Enum2.kGrass4_5_CntCup_Race5_HOW;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_Junkyard] = (int)LevelBuilder_Ross.Enum2.kMud7_4_Junkyard;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_GetUp] = (int)LevelBuilder_Ross.Enum2.kMud5_2_FrmCup_Race2_GetUp;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_BridgeJump] = (int)LevelBuilder_Ross.Enum2.kGrass8_7_BridgeJumps;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_RainbowRuns] = (int)LevelBuilder_Ross.Enum2.kGrassN2_3_RainbowRuns;
			tempBL [(int)Profile.Enum2.kAchievement_RecordBreaker_TulipChicane] = (int)LevelBuilder_Ross.Enum2.kMud8_4_TulipChicane;
			for (int i = 0; i < (int)Enum2.kNumAchievements; i++) {
                if (tempBL[i] != -1) {
                    for (int j = 0; j < Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES; j++) {
                        if (LevelBuilder_Ross.levelOrder[j] == tempBL[i]) {
                            breakerLevel[i] = j;
                            break;
                        }

                    }

                }

            }

            tempThing[(int)LevelBuilder_Ross.Enum2.kGrass1_8_MdwCup_Race8_CowField] = 13.25f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kMud_LongJumps] = 19.25f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kMud_MudVille] = 12.25f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly] = 8.25f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kGrass9_4_FourRivers] = 14.5f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kMud2_4_MudCup_Race4_LongRoof] = 16.25f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kMud8_5_PumpkinWiggle] = 20.25f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kGrass9_5_Campyard] = 16.5f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kGrass4_5_CntCup_Race5_HOW] = 12.5f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kMud7_4_Junkyard] = 19.0f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kMud5_2_FrmCup_Race2_GetUp] = 19.0f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kGrass8_7_BridgeJumps] = 14.5f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kGrassN2_3_RainbowRuns] = 25.0f;
            tempThing[(int)LevelBuilder_Ross.Enum2.kMud8_4_TulipChicane] = 14.0f;
            for (int i = 0; i < Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES; i++) {
                int realLevelId = LevelBuilder_Ross.levelOrder[i];
                Globals.Assert(realLevelId < 600);
                breakerTime[i] = tempThing[realLevelId];
            }

        }

        public void SetupCupInfo()
        {
            for (int i = 0; i < (int)Enum4.kNumCups; i++) {
                (cup[i]).SetMenuBackColour(Constants.kColourLightblue);
                (cup[i]).SetMenuRaysColour(Constants.kColourLilac);
                (cup[i]).SetFontColour(Constants.kColourLilac);
                (cup[i]).SetLevelColour(Constants.kColourLilac);
                (cup[i]).SetIconSet(0);
                (cup[i]).SetName("Rosso Bosso");
                (cup[i]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
            }

            int cupId = (int)Enum4.kCupMeadow;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                (cup[(int)Enum4.kCupMeadow]).SetName("Die Wiese");
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[(int)Enum4.kCupMeadow]).SetName("Le pré");
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                (cup[(int)Enum4.kCupMeadow]).SetName("草原");
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                (cup[(int)Enum4.kCupMeadow]).SetName("牧場");
            }
            else {
                (cup[(int)Enum4.kCupMeadow]).SetName("The Meadow");
            }

            (cup[(int)Enum4.kCupMeadow]).SetFontColour(Constants.kColourCountryText);
            (cup[(int)Enum4.kCupMeadow]).SetMenuBackColour(Constants.kColourGreenMenuBack);
            (cup[(int)Enum4.kCupMeadow]).SetMenuRaysColour(Constants.kColourGreenMenuBackRays);
            (cup[(int)Enum4.kCupMeadow]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
            (cup[(int)Enum4.kCupMeadow]).SetIconSet(0);
            (cup[(int)Enum4.kCupMeadow]).SetLockedIconSet(0);
            (cup[(int)Enum4.kCupMeadow]).SetLevelColour(Constants.kColourCountryText);
            (cup[(int)Enum4.kCupMeadow]).SetAchievementIdPassed("1445497625");
            (cup[(int)Enum4.kCupMeadow]).SetAchievementId24apples("1445496665");

            #if !LITE_VERSION
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[(int)Enum4.kCupMud]).SetName("Der Gem%segarten");
                }
	            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
	                (cup[(int)Enum4.kCupMud]).SetName("Potager");
	            }			
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[(int)Enum4.kCupMud]).SetName("蔬菜园");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[(int)Enum4.kCupMud]).SetName("農園");
                }
                else {
                    (cup[(int)Enum4.kCupMud]).SetName("Veg Garden");
                }

                (cup[(int)Enum4.kCupMud]).SetFontColour(Constants.kColourOrange);
                (cup[(int)Enum4.kCupMud]).SetMenuBackColour(Constants.kColourYellowMenuBack);
                (cup[(int)Enum4.kCupMud]).SetMenuRaysColour(Constants.kColourYellowMenuBackRays);
                (cup[(int)Enum4.kCupMud]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[(int)Enum4.kCupMud]).SetIconSet(1);
                (cup[(int)Enum4.kCupMud]).SetLockedIconSet(1);
                (cup[(int)Enum4.kCupMud]).SetLevelColour(Constants.kColourOrange);
                (cup[(int)Enum4.kCupMud]).SetAchievementIdPassed("1445568194");
                (cup[(int)Enum4.kCupMud]).SetAchievementId24apples("1445564230");
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[(int)Enum4.kCupPenguin]).SetName("Der Park");
                }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[(int)Enum4.kCupPenguin]).SetName("Le parc");
            }			
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[(int)Enum4.kCupPenguin]).SetName("公园");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[(int)Enum4.kCupPenguin]).SetName("公園");
                }
                else {
                    (cup[(int)Enum4.kCupPenguin]).SetName("The Park");
                }

                (cup[(int)Enum4.kCupPenguin]).SetFontColour(Constants.kColourCountryText);
                (cup[(int)Enum4.kCupPenguin]).SetMenuBackColour(Constants.kColourLightblue);
                (cup[(int)Enum4.kCupPenguin]).SetMenuRaysColour(Constants.kColourLightblue);
                (cup[(int)Enum4.kCupPenguin]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[(int)Enum4.kCupPenguin]).SetIconSet(0);
                (cup[(int)Enum4.kCupPenguin]).SetLockedIconSet(2);
                (cup[(int)Enum4.kCupPenguin]).SetLevelColour(Constants.kColourCountryText);
                (cup[(int)Enum4.kCupPenguin]).SetAchievementIdPassed("1450188277");
                (cup[(int)Enum4.kCupPenguin]).SetAchievementId24apples("1450095864");
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[(int)Enum4.kCupCountryside]).SetName("Das K%rbisbeet");
                }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[(int)Enum4.kCupCountryside]).SetName("Carré de citrouilles");
            }			
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[(int)Enum4.kCupCountryside]).SetName("南瓜地");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[(int)Enum4.kCupCountryside]).SetName("カボチャ園");
                }
                else {
                    (cup[(int)Enum4.kCupCountryside]).SetName("Pumpkin Patch");
                }

                (cup[(int)Enum4.kCupCountryside]).SetFontColour(Constants.kColourFarmText);
                (cup[(int)Enum4.kCupCountryside]).SetMenuBackColour(Constants.kColourGreenMenuBack);
                (cup[(int)Enum4.kCupCountryside]).SetMenuRaysColour(Constants.kColourGreenMenuBackRays);
                (cup[(int)Enum4.kCupCountryside]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[(int)Enum4.kCupCountryside]).SetIconSet(0);
                (cup[(int)Enum4.kCupCountryside]).SetLockedIconSet(0);
                (cup[(int)Enum4.kCupCountryside]).SetLevelColour(Constants.kColourFarmText);
                (cup[(int)Enum4.kCupCountryside]).SetAchievementIdPassed("965239920");
                (cup[(int)Enum4.kCupCountryside]).SetAchievementId24apples("1035369786");
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[(int)Enum4.kCupFarmyard]).SetName("Der Zeltplatz");
                }
			            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[(int)Enum4.kCupFarmyard]).SetName("Campement");
            }			

                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[(int)Enum4.kCupFarmyard]).SetName("营地");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[(int)Enum4.kCupFarmyard]).SetName("キャンプ場");
                }
                else {
                    (cup[(int)Enum4.kCupFarmyard]).SetName("Camp Site");
                }

                (cup[(int)Enum4.kCupFarmyard]).SetFontColour(Constants.kColourRed);
                (cup[(int)Enum4.kCupFarmyard]).SetMenuBackColour(Constants.kColourYellowMenuBack);
                (cup[(int)Enum4.kCupFarmyard]).SetMenuRaysColour(Constants.kColourYellowMenuBackRays);
                (cup[(int)Enum4.kCupFarmyard]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[(int)Enum4.kCupFarmyard]).SetIconSet(1);
                (cup[(int)Enum4.kCupFarmyard]).SetLockedIconSet(1);
                (cup[(int)Enum4.kCupFarmyard]).SetLevelColour(Constants.kColourRed);
                (cup[(int)Enum4.kCupFarmyard]).SetAchievementIdPassed("965010833");
                (cup[(int)Enum4.kCupFarmyard]).SetAchievementId24apples("964974268");
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[(int)Enum4.kCupStar]).SetName("Der Schrottplatz");
                }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[(int)Enum4.kCupStar]).SetName("La Casse");
            }						
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[(int)Enum4.kCupStar]).SetName("垃圾场");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[(int)Enum4.kCupStar]).SetName("ジャンクヤード");
                }
                else {
                    (cup[(int)Enum4.kCupStar]).SetName("The Junkyard");
                }

                (cup[(int)Enum4.kCupStar]).SetFontColour(Constants.kColourFarmText);
                (cup[(int)Enum4.kCupStar]).SetMenuBackColour(Constants.kColourPurpleMenuBack);
                (cup[(int)Enum4.kCupStar]).SetMenuRaysColour(Constants.kColourPurpleMenuBackRays);
                (cup[(int)Enum4.kCupStar]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[(int)Enum4.kCupStar]).SetIconSet(2);
                (cup[(int)Enum4.kCupStar]).SetLockedIconSet(2);
                (cup[(int)Enum4.kCupStar]).SetLevelColour(Constants.kColourFarmText);
                (cup[(int)Enum4.kCupStar]).SetAchievementIdPassed("965262719");
                (cup[(int)Enum4.kCupStar]).SetAchievementId24apples("964967367");
                cupId = (int)Enum4.kCupStar + 1;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[cupId]).SetName("Der Obstgarten");
                }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[cupId]).SetName("Le verger");
            }						
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[cupId]).SetName("果园");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[cupId]).SetName("果樹園");
                }
                else {
                    (cup[cupId]).SetName("The Orchard");
                }

                (cup[cupId]).SetFontColour(Constants.kColourLilac);
                (cup[cupId]).SetMenuBackColour(Constants.kColourPurpleMenuBack);
                (cup[cupId]).SetMenuRaysColour(Constants.kColourPurpleMenuBackRays);
                (cup[cupId]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[cupId]).SetIconSet(2);
                (cup[cupId]).SetLockedIconSet(2);
                (cup[cupId]).SetLevelColour(Constants.kColourLilac);
                (cup[cupId]).SetAchievementIdPassed("965262719");
                (cup[cupId]).SetAchievementId24apples("964967367");
                cupId++;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[cupId]).SetName("Der Schweinepferch");
                }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[cupId]).SetName("La porcherie");
            }						
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[cupId]).SetName("猪院");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[cupId]).SetName("養豚場");
                }
                else {
                    (cup[cupId]).SetName("The Swineyard");
                }

                (cup[cupId]).SetFontColour(Constants.kColourFarmText);
                (cup[cupId]).SetMenuBackColour(Constants.kColourPurpleMenuBack);
                (cup[cupId]).SetMenuRaysColour(Constants.kColourPurpleMenuBackRays);
                (cup[cupId]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[cupId]).SetIconSet(2);
                (cup[cupId]).SetLockedIconSet(2);
                (cup[cupId]).SetLevelColour(Constants.kColourFarmText);
                (cup[cupId]).SetAchievementIdPassed("965262719");
                (cup[cupId]).SetAchievementId24apples("964967367");
                cupId++;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[cupId]).SetName("Was f%r'n Schafsk#se");
                }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[cupId]).SetName("Coup de main");
            }						
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[cupId]).SetName("猪言猪语");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[cupId]).SetName("ばかな豚");
                }
                else {
                    (cup[cupId]).SetName("The Hogzwallop");
                }

                (cup[cupId]).SetFontColour(Constants.kColourPink);
                (cup[cupId]).SetMenuBackColour(Constants.kColourPurpleMenuBack);
                (cup[cupId]).SetMenuRaysColour(Constants.kColourPurpleMenuBackRays);
                (cup[cupId]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[cupId]).SetIconSet(2);
                (cup[cupId]).SetLockedIconSet(2);
                (cup[cupId]).SetLevelColour(Constants.kColourStarCupText);
                (cup[cupId]).SetAchievementIdPassed("965262719");
                (cup[cupId]).SetAchievementId24apples("964967367");
                cupId++;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    (cup[cupId]).SetName("Das Schlammbad");
                }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                (cup[cupId]).SetName("Bain de boue");
            }						
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    (cup[cupId]).SetName("泥浴");
                }
                else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    (cup[cupId]).SetName("泥風呂");
                }
                else {
                    (cup[cupId]).SetName("The Mud Bath");
                }

                (cup[cupId]).SetFontColour(Constants.kColourStarCupText);
                (cup[cupId]).SetMenuBackColour(Constants.kColourPurpleMenuBack);
                (cup[cupId]).SetMenuRaysColour(Constants.kColourPurpleMenuBackRays);
                (cup[cupId]).SetStageIcon((int)World.Enum9.kFE_StageIcon);
                (cup[cupId]).SetIconSet(2);
                (cup[cupId]).SetLockedIconSet(2);
                (cup[cupId]).SetLevelColour(Constants.kColourStarCupText);
                (cup[cupId]).SetAchievementIdPassed("965262719");
                (cup[cupId]).SetAchievementId24apples("964967367");
            #endif

        }

        public Cup GetCup(int whichCup)
        {
            Globals.Assert(whichCup < (int)Enum4.kNumCups);
            return cup[whichCup];
        }

        public void SetSeenHowTo()
        {
            profileInfo.seenHowToYet = true;
        }

        public void SetSeenCrystalSplash()
        {
            profileInfo.seenCrystalSplash = true;
        }

        public void SetFeelGoodScreenPending(bool inVal)
        {
            profileInfo.feelGoodScreenPending = inVal;
        }

        public void SetSpeedUpScreenPending(bool inVal)
        {
            profileInfo.speedUpScreenPending = inVal;
        }

        public void SetAnotherPiggyScreenPending(bool inVal)
        {
            profileInfo.anotherPiggyScreenPending = inVal;
        }

        public void SetAppleScreenPending(bool inVal)
        {
            profileInfo.appleScreenPending = inVal;
        }

        public void SetFeelGoodProgress(int inProg)
        {
            profileInfo.feelGoodProgress = inProg;
        }

        float GetGoldTrophyTimeP1(BestTimeSet bestTimeSet, int level)
        {
            return 5.0f;
        }

        public int HasRaceTip(int levelId)
        {
            string testWord = (((Globals.g_world.game).hud).anotherPiggyScreen).GetTipLineP1(0, levelId);
            if (testWord == "\n") {
                return (int)Profile.Enum3.kHud_NoRaceTip;
            }
            else {
                return (int)Enum3.kHud_RaceTipWithImage;
            }

        }

        public int GetNumApples(int stage)
        {
            Globals.Assert(stage < (int)Enum4.kNumCups);
            return numApples[stage];
        }

        public BestTimeSet GetRelevantBestTimeSet()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                return BestTimeSet.t_Custom;
            }
            else {
                if (preferences.diffEasy) return BestTimeSet.t_Easy;
                else return BestTimeSet.t_Normal;

            }

        }

        public void SetSecretLevelShown (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            secretLevelShown[(int)level] = true;
        }

        public bool GetSecretLevelShown (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            return secretLevelShown[(int)level];
        }

        public void SetSeenTipForLevel (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            seenTipForLevel[(int)level] = true;
        }

        public bool SeenTipForLevel (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            return seenTipForLevel[(int)level];
        }

        public void ClearAllBestTimeData ()
		{
			for (int i = 0; i < (int)Profile.Enum6.kNumLevels; i++) {
                notSavedInfo.level[i].bestTime[0] = (long)kBigBestTime;
                notSavedInfo.level[i].bestTime[1] = (long)kBigBestTime;
                notSavedInfo.level[i].bestTime[2] = (long)kBigBestTime;
                profileInfo.level[i].gotTrophy = TrophyType.kTrophy_NotGot;
            }

        }

        public void ResetBestTimeAndLevelUnlockedData ()
		{
			for (int l = 0; l < (int)Profile.Enum6.kNumLevels; l++) {
                this.ResetLevelData(l);
            }

            profileInfo.level[0].levelUnlocked = true;
            this.UpdateLevelVisibility(-1);
            this.UpdateNumApples();
            this.UpdateSpeedUpProgress();
        }

        float GetDecryptedTime(int inVal)
        {
            float OutTime = Utilities.DecryptInt(inVal);
            if (OutTime > 0 && OutTime < 100) return OutTime;
            else {
                return 1000;
            }

        }

        public bool CanUnlockLevel(int whichLevel)
        {
            int totalApples = this.GetTotalNumberOfApples();
            int cupId = this.GetCupFromLevel(whichLevel);
            if (cupId == 4) {
                if (totalApples < Constants.NUM_APPLES_TO_UNLOCK_5) {
                    return false;
                }

            }

            if (cupId == 6) {
                if (totalApples < Constants.NUM_APPLES_TO_UNLOCK_7) {
                    return false;
                }

            }

            if (cupId == 8) {
                if (totalApples < Constants.NUM_APPLES_TO_UNLOCK_9) {
                    return false;
                }

            }
            else if (cupId == 9) {
                if (totalApples < Constants.NUM_APPLES_TO_UNLOCK_10) {
                    return false;
                }

            }

            return true;
        }

        public void UnlockAllLevelsFromFrontend ()
		{
			int buttonIndex = 1;
			int i = 0;
			for (int x = 0; x < 8; x++) {
				buttonIndex++;
				for (int y = 0; y < 10; y++) {

					#if UNLOCK_ALL_DOESNT_INCLUDE_BONUS
                        if (i < (kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) 
#endif

					{
						levelVisible [i] = true;
						profileInfo.level [i].levelUnlocked = true;
						profileInfo.level [i].gotTrophy = TrophyType.kTrophy_NotGot;
						FrontEndButton useButton = ((Globals.g_world.frontEnd).GetScreen (
                          FrontEndScreenEnum.kFrontEndScreen_ChooseTrack
						)).GetButton (buttonIndex);
						useButton.SetIsClickable (true);
						i++;
						buttonIndex++;
					}
				}

			}

			for (int ij = 0; ij < (int)Enum6.kMaxTerrains; ij++) {
                profileInfo.terrainUnlocked[ij] = true;
            }

            this.UpdateLevelVisibility(-1);
            this.UpdateNumApples();
            this.UpdateSpeedUpProgress();
            profileInfo.seenUnlockedBonus3 = false;
            profileInfo.seenUnlockedBonus1 = false;
            profileInfo.seenUnlockedBonus2 = false;
        }

        public void UnlockSomeLevels (int upTo)
		{
			for (int i = 0; i < (int)Enum4.kNumCups - 1; i++) {
				int cupId = i + 1;
				if (upTo < (1 + ((int)Profile.Enum6.kNumLevelsPerCup * cupId))) {
                    profileInfo.seenWelcomeToCup[cupId] = false;
                }
                else {
                    profileInfo.seenWelcomeToCup[cupId] = true;
                }

            }

            profileInfo.seenUnlockedBonus3 = false;
            if (upTo < 17) {
                profileInfo.seenUnlockedBonus2 = false;
            }

            if (upTo < 9) {
                profileInfo.seenUnlockedBonus1 = false;
            }

        }

        public void SetPreferencesDefaults ()
		{
						//so this means it's a completely fresh install (of the transfer build... )
						//which means they don't need to see the consent popup - i think
						Globals.g_consentPopup.DeactivateForGood();

			preferences.ghostOn = false;
			preferences.musicOn = true;
			preferences.soundFxOn = true;
			preferences.diffEasy = false;
			preferences.controlTilt = false;
			preferences.tiltExpert = false;
			preferences.controlFinger = true;
			profileInfo.numRacesWithoutBeingAskedToRate = 8;
			profileInfo.facebookLoggedIn = false;
			for (int t = 0; t < (int)Enum6.kMaxTerrains; t++) {
				profileInfo.terrainUnlocked [t] = false;
			}

			profileInfo.terrainUnlocked [(int)SceneType.kSceneGrass] = true;
			profileInfo.feelGoodScreenPending = false;
			profileInfo.appleScreenPending = false;
			profileInfo.speedUpScreenPending = false;
			profileInfo.anotherPiggyScreenPending = false;
			profileInfo.haveSeenControlChoiceYet = false;
			profileInfo.feelGoodProgress = (int)Enum5.kFeelGoodProgress_Start;
			profileInfo.seenUnlockedBonus3 = false;
			profileInfo.seenHowToYet = false;
			profileInfo.seenCrystalSplash = false;
			profileInfo.seenUnlockedBonus1 = false;
			profileInfo.seenUnlockedBonus2 = false;
			profileInfo.seenAnotherPiggy1 = false;
			profileInfo.seenAnotherPiggy2 = false;
			for (int i = 0; i < (int)Enum2.kNumAchievements; i++) {
                profileInfo.achievementSeen[i] = false;
            }

            profileInfo.minimumSpeedupProgress = (int)SpeedUpProgressEnum.kSpeedUp_ThirdSpeedBoost;
            for (int i = 0; i < (int)Enum4.kNumCups; i++) {
                profileInfo.seenWelcomeToCup[i] = false;
                profileInfo.reachedCupWhenStillLocked[i] = false;
            }

            this.ResetBestTimeAndLevelUnlockedData();
        }
		
		public void SetProfileInfoDefaults ()
		{
			profileInfo.numRacesWithoutBeingAskedToRate = 8;
			profileInfo.facebookLoggedIn = false;
			for (int t = 0; t < (int)Enum6.kMaxTerrains; t++) {
				profileInfo.terrainUnlocked [t] = false;
			}

			profileInfo.terrainUnlocked [(int)SceneType.kSceneGrass] = true;
			profileInfo.feelGoodScreenPending = false;
			profileInfo.appleScreenPending = false;
			profileInfo.speedUpScreenPending = false;
			profileInfo.anotherPiggyScreenPending = false;
			profileInfo.haveSeenControlChoiceYet = false;
			profileInfo.feelGoodProgress = (int)Enum5.kFeelGoodProgress_Start;
			profileInfo.seenUnlockedBonus3 = false;
			profileInfo.seenHowToYet = false;
			profileInfo.seenCrystalSplash = false;
			profileInfo.seenUnlockedBonus1 = false;
			profileInfo.seenUnlockedBonus2 = false;
			profileInfo.seenAnotherPiggy1 = false;
			profileInfo.seenAnotherPiggy2 = false;
			for (int i = 0; i < (int)Enum2.kNumAchievements; i++) {
                profileInfo.achievementSeen[i] = false;
            }

            profileInfo.minimumSpeedupProgress = (int)SpeedUpProgressEnum.kSpeedUp_ThirdSpeedBoost;
            for (int i = 0; i < (int)Enum4.kNumCups; i++) {
                profileInfo.seenWelcomeToCup[i] = false;
                profileInfo.reachedCupWhenStillLocked[i] = false;
            }

            this.ResetBestTimeAndLevelUnlockedData();
        }

        public void SetReachedCupWhenStillLockedP1(int cupId, bool isTrue)
        {
            profileInfo.reachedCupWhenStillLocked[cupId] = isTrue;
        }
		
		public string pathForDocumentsFile( string filename ) 
		{ 

			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
					string path = Application.persistentDataPath + "/" + filename;
					
//					Debug.Log("path NEW for documents = "+ path);
//
//
//					path = Application.dataPath.Substring( 0, Application.dataPath.Length - 5 );
//					path = path.Substring( 0, path.LastIndexOf( '/' ) );
//
//								path = Path.Combine( Path.Combine( path, "Documents" ), filename );
////
//
//								Debug.Log("USING path OLD for documents = "+ path);


								return path;
//
//					string path = Application.persistentDataPath + "/" + filename;
//
//					return path;
			}		
			else if(Application.platform == RuntimePlatform.Android)
			{
				string path = Application.persistentDataPath;	
				path = path.Substring(0, path.LastIndexOf( '/' ) );	
				return Path.Combine (path, filename);
			}	
			else 
			{
				string path = Application.dataPath;	
				path = path.Substring(0, path.LastIndexOf( '/' ) );
				return Path.Combine (path, filename);
			}
		}

				//-------------------------------------------------------------------------
				bool DoesFileExistIOS (string filename)
				{
					//first try the old way
					string path = Application.dataPath.Substring( 0, Application.dataPath.Length - 5 );
					path = path.Substring( 0, path.LastIndexOf( '/' ) );
					path = Path.Combine( Path.Combine( path, "Documents" ), filename );
					xcodeDataFilePath = path;
					if (!File.Exists(path))
					{						
						path = pathForDocumentsFile(filename);
								xcodeDataFilePath = path;
						return File.Exists(path);
					}

					return true;
				}


				//-------------------------------------------------------------------------
				public void ReadXCodeBestTimesData ()
				{
						Debug.Log("<color=red>xcode data File found at "+xcodeDataFilePath+"</color>");

						Debug.Log("trying to readallbytes");

						string path = xcodeDataFilePath;

						//						byte[] bytes = System.IO.File.ReadAllBytes (path);
						//
						////						System.IO.File.ReadAllBytes (path, bytes);
						//
						//						Debug.Log("numBytes is " + bytes.Length);
						//
						//						int byteSize = this.GetObjectSize(preferences);
						//
						//						Debug.Log("Size of a bool is " + sizeof(bool));
						//
						//						//use seek on the file stream to get to the right place to read the second lot
						//
						//						Debug.Log("Size of Preferences class is " + byteSize);//sizeof(ProfilePreferences));
						//						byteSize = this.GetObjectSize(profileInfo);
						//
						//						Debug.Log("Size of profileInfo class is " + byteSize);//sizeof(ProfilePreferences));
						//
						//						Debug.Log("preferences.musicOnb4 "+preferences.musicOn);
						//
						//						preferences.musicOn = Convert.ToBoolean(bytes[0]);// (bool)bytes[0];
						//
						//						Debug.Log("preferences.musicOn "+preferences.musicOn);


						FileStream fileB = new FileStream(path, FileMode.Open, FileAccess.Read);

						BinaryReader sr = new BinaryReader(fileB);

//						Debug.Log("preferences.musicOnb4 "+preferences.musicOn);
//						Debug.Log("preferences.soundFxOn "+preferences.soundFxOn);
//						Debug.Log("preferences.ghostOn "+preferences.ghostOn);
//						Debug.Log("preferences.diffEasy "+preferences.diffEasy);
//						Debug.Log("preferences.controlTilt "+preferences.controlTilt);
//						Debug.Log("preferences.tiltEx "+preferences.tiltExpert);
//						Debug.Log("profileInfo.haveseencon"+profileInfo.haveSeenControlChoiceYet);
//						Debug.Log("profileInfo.anotherPiggyScreenPending"+profileInfo.anotherPiggyScreenPending);
//						Debug.Log("profileInfo.seenAnotherPiggy1"+profileInfo.seenAnotherPiggy1);
//						Debug.Log("profileInfo.seenAnotherPiggy2"+profileInfo.seenAnotherPiggy2);
//						Debug.Log("profileInfo.feelGoodProgress"+profileInfo.feelGoodProgress);
//						Debug.Log("profileInfo.level[0].bestT0 "+profileInfo.level[0].bestTime[0]);
//						Debug.Log("profileInfo.level[0].levelUnlocked "+profileInfo.level[0].levelUnlocked);
//						Debug.Log("profileInfo.level[1].levelUnlocked "+profileInfo.level[1].levelUnlocked);

						preferences.musicOn = Convert.ToBoolean(sr.ReadByte());
						preferences.soundFxOn = Convert.ToBoolean(sr.ReadByte());
						preferences.ghostOn = Convert.ToBoolean(sr.ReadByte());
						preferences.diffEasy = Convert.ToBoolean(sr.ReadByte());
						preferences.controlTilt = Convert.ToBoolean(sr.ReadByte());
						preferences.tiltExpert = Convert.ToBoolean(sr.ReadByte());
						preferences.controlFinger = Convert.ToBoolean(sr.ReadByte());

						//and now the ProfileInfo

						profileInfo.haveSeenControlChoiceYet= Convert.ToBoolean(sr.ReadByte());
						profileInfo.seenHowToYet= Convert.ToBoolean(sr.ReadByte());
						profileInfo.seenCrystalSplash= Convert.ToBoolean(sr.ReadByte());
						profileInfo.mentionedTrophy= Convert.ToBoolean(sr.ReadByte());

						profileInfo.seenUnlockedBonus1= Convert.ToBoolean(sr.ReadByte());
						profileInfo.seenUnlockedBonus2= Convert.ToBoolean(sr.ReadByte());
						profileInfo.seenUnlockedBonus3= Convert.ToBoolean(sr.ReadByte());

						profileInfo.seenAnotherPiggy1= Convert.ToBoolean(sr.ReadByte());
						profileInfo.seenAnotherPiggy2= Convert.ToBoolean(sr.ReadByte());

						for (int i = 0; i < (int)Enum4.kNumCups; i++) 
						{
								sr.ReadByte();
								//								Debug.Log(i);
								//								profileInfo.seenWelcomeToCup [i] = sr.ReadChar();
						}
						//	BOOL seenWelcomeToStar= Convert.ToBoolean(sr.ReadByte());	

						profileInfo.feelGoodScreenPending= Convert.ToBoolean(sr.ReadByte());
						profileInfo.appleScreenPending= Convert.ToBoolean(sr.ReadByte());
						profileInfo.speedUpScreenPending= Convert.ToBoolean(sr.ReadByte());
						profileInfo.anotherPiggyScreenPending= Convert.ToBoolean(sr.ReadByte());

						//Mystery!
						sr.ReadByte();

						profileInfo.feelGoodProgress = (int)sr.ReadInt16();	
						profileInfo.minimumSpeedupProgress = (int)sr.ReadInt16();


						//						for (int i = 0; i < (int)Enum6.kMaxTerrains; i++) 
						for (int i = 0; i < 7; i++) 

						{
								profileInfo.terrainUnlocked[i]= Convert.ToBoolean(sr.ReadByte());

								//								sr.ReadByte();
						}

						//Another Mystery!
						sr.ReadByte();


						for (int l = 0; l < (int)Profile.Enum6.kNumLevelsPlusOne; l++) 
						{
								for (int s = 0; s < 3; s++) 
								{
										//24 bit number?
										//										sr.ReadByte();
										profileInfo.level[l].bestTime[s] = sr.ReadInt32();
								}


								profileInfo.level[l].gotTrophy = (TrophyType)sr.ReadInt32();
								profileInfo.level[l].levelUnlocked  = Convert.ToBoolean(sr.ReadByte());
								profileInfo.level[l].usingSlowerPig  = Convert.ToBoolean(sr.ReadByte());
								profileInfo.level[l].usingSlowerPig3apples  = Convert.ToBoolean(sr.ReadByte());

								//Another Mystery!
								sr.ReadByte();


								//hmm
								///								ProfileInfoPerLevel level[kNumLevelsPlusOne];
						}

						profileInfo.numRacesWithoutBeingAskedToRate = sr.ReadInt16();

						//For our own custom facebook posting
						for (int i = 0; i < (int)Enum2.kNumAchievements; i++) 
						{
								profileInfo.achievementSeen[i] = sr.ReadBoolean();
						}

						profileInfo.facebookLoggedIn = sr.ReadBoolean();;

						for (int i = 0; i < (int)Enum4.kNumCups; i++) {
								profileInfo.reachedCupWhenStillLocked[i] = sr.ReadBoolean();
						}

						Debug.Log("preferences.musicOn "+preferences.musicOn);
						Debug.Log("preferences.soundFxOn "+preferences.soundFxOn);
						Debug.Log("preferences.ghostOn "+preferences.ghostOn);
						Debug.Log("preferences.diffEasy "+preferences.diffEasy);
						Debug.Log("preferences.controlTilt "+preferences.controlTilt);
						Debug.Log("preferences.tiltEx "+preferences.tiltExpert);
						Debug.Log("profileInfo.haveseencon"+profileInfo.haveSeenControlChoiceYet);
						Debug.Log("profileInfo.seenAnotherPiggy1"+profileInfo.seenAnotherPiggy1);
						Debug.Log("profileInfo.seenAnotherPiggy2"+profileInfo.seenAnotherPiggy2);
						Debug.Log("profileInfo.anotherPiggyScreenPending"+profileInfo.anotherPiggyScreenPending);
						Debug.Log("profileInfo.feelGoodProgress"+profileInfo.feelGoodProgress);
						Debug.Log("profileInfo.minimumSpeedupProgress"+profileInfo.minimumSpeedupProgress);

						Debug.Log("profileInfo.level[0].bestT0 "+profileInfo.level[0].bestTime[0]);
						Debug.Log("profileInfo.level[0].bestT1 "+profileInfo.level[0].bestTime[1]);
						Debug.Log("profileInfo.level[0].bestT2 "+profileInfo.level[0].bestTime[2]);
						Debug.Log("profileInfo.level[1].bestT0 "+profileInfo.level[1].bestTime[0]);
						Debug.Log("profileInfo.level[76].bestT1 "+profileInfo.level[76].bestTime[1]);

						Debug.Log("profileInfo.level[0].levelUnlocked "+profileInfo.level[0].levelUnlocked);
						Debug.Log("profileInfo.level[1].levelUnlocked "+profileInfo.level[1].levelUnlocked);						
				}


				//-------------------------------------------------------------------------
				unsafe public void TestENC ()
				{

						Blowfish.BLOWFISH_CTX ctx = new Blowfish.BLOWFISH_CTX();

						//						Globals.g_blowfish.Blowfish_Init(ctx,(char*)"BL1X8WAZ", 8);
						Globals.g_blowfish.Blowfish_Init(ctx,"BL1X8WAZ", 8);

						ulong lScore = 6150;
						ulong rScore = 9070;

						Globals.g_blowfish.Blowfish_Encrypt(ctx,&lScore,&rScore);
				
						Debug.Log("lScore " + lScore);
						Debug.Log("rScore " + rScore);

						Globals.g_blowfish.Blowfish_Decrypt(ctx,&lScore,&rScore);

						Debug.Log("lScore " + lScore);
						Debug.Log("rScore " + rScore);


				}
				//-------------------------------------------------------------------------
				public void LoadBestTimesAndPrefsIOS ()
				{

						//this.TestENC();
						//encrypt test



//						string path = pathForDocumentsFile( "BestTimes_v3.dat" );
//
//						Debug.Log("<color=red>Attempt to load " + path + "</color>");

//						if (Constants.FORCE_PROFILE_RESET) 
//						{
//								this.SetPreferencesDefaults ();
//								this.SetProfileInfoDefaults();
//						}

						string path = pathForDocumentsFile( "BestTimes_v3.dat" );

						if (!File.Exists(path))
						{
								Debug.Log("<color=red>new data file not found at "+path+" - going to check for old data file</color>");


							//Current version of save data doesn't exist...
							//check if the old XCode version exists...

								if (DoesFileExistIOS("BestTimes_v2.dat"))
								{
										Debug.Log("<color=red>old data file found</color>");

										//Ok so we need to read XCode Save Data style
										this.ReadXCodeBestTimesData();

										//Having read the best times etc from xcode - we now need to decrypt them ... as they were decrypted...

										this.DecryptAllBestTimes();
										//huzzah... that'd be amazing if that works.


										path = pathForDocumentsFile( "BestTimes_v3.dat" );

										Debug.Log("<color=red>saving data to new format... at path "+path+"</color>");

										//uhhh... i'm confused...
										this.EncryptAllBestTimes();

										FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
										BinaryFormatter formatter = new BinaryFormatter();
										formatter.Serialize(file,preferences);
										formatter.Serialize(file,profileInfo);
										file.Close();

										this.DoAfterLoadingShit();

										Debug.Log("<color=red>done and exit func</color>");

										return;
								}
								else
								{
										Debug.Log("<color=red>old data file also not found... assuming this is a fresh installation</color>");
								}
						}

//						if (!File.Exists(path))
//						{								
//								Debug.Log("<color=red>File not found at "+path+"- changing path to </color>");
//								path = Application.persistentDataPath + "/" + "BestTimes_v2.dat";
//								Debug.Log("<color=red>New path "+path+" </color>");
//
//
//						}
						if (!File.Exists(path))
						{
								Debug.Log("<color=red>setting profile and preferences defaults</color>");


								this.SetPreferencesDefaults();
								this.SetProfileInfoDefaults();

//								path = pathForDocumentsFile("BestTimes_v3.dat");

								Debug.Log("<color=red>saving prefs and profile info at "+path+"</color>");

								this.EncryptAllBestTimes();

								FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
								BinaryFormatter formatter = new BinaryFormatter();
								formatter.Serialize(file,preferences);
								formatter.Serialize(file,profileInfo);
								file.Close();

								return;
						}

						Debug.Log("<color=red>new style prefs and profile info FOUND at "+path+"</color>");
										


						//this should only happen on the second load...
						//maybe need to save to V3 .. or something...
						FileStream filestream2 = new FileStream (path, FileMode.Open, FileAccess.Read);

						BinaryFormatter unformatter2 = new BinaryFormatter();
						preferences = (ProfilePreferences)unformatter2.Deserialize(filestream2);			
						profileInfo = (ProfileInformation)unformatter2.Deserialize(filestream2);			

						filestream2.Close();


						//info has been loaded.... so, we cool.

						this.DoAfterLoadingShit();

						this.DecryptAllBestTimes();

				}

				private int GetObjectSize(object TestObject)
				{
						BinaryFormatter bf = new BinaryFormatter();
						MemoryStream ms = new MemoryStream();
						byte[] Array;
						bf.Serialize(ms, TestObject);
						Array = ms.ToArray();
						return Array.Length;
				}

				//-------------------------------------------------------------------
				void DoAfterLoadingShit ()
				{
						for (int l = 0; l < (int)Profile.Enum6.kNumLevelsPlusOne; l++) 
						{
								for (int s = 0; s < 3; s++) 
								{
										notSavedInfo.level[l].bestTime[s] = profileInfo.level[l].bestTime[s];
								}
						}								

						preferences.tiltExpert = false;
						for (int i = 0; i < (int)Enum4.kNumCups; i++) {
								profileInfo.seenWelcomeToCup [i] = true;
						}

						if (Constants.RESET_LEVEL != -1) {
								profileInfo.level [Constants.RESET_LEVEL].levelUnlocked = true;
								notSavedInfo.level [Constants.RESET_LEVEL].bestTime [0] = (long)kBigBestTime;
								notSavedInfo.level [Constants.RESET_LEVEL].bestTime [1] = (long)kBigBestTime;
								notSavedInfo.level [Constants.RESET_LEVEL].bestTime [2] = (long)kBigBestTime;
								profileInfo.level [Constants.RESET_LEVEL].gotTrophy = TrophyType.kTrophy_NotGot;
						}

						#if RESET_PASSED_LEVEL_DATA
						for (int l = 0; l < (int)Profile.Enum6.kNumLevelsPlusOne; l++) {
						this.ResetLevelData(l);
						profileInfo.level[l].levelUnlocked = true;
						}

						#endif

						if (Constants.UNLOCK_SOME_LEVELS) {
								profileInfo.seenAnotherPiggy1 = false;
								profileInfo.seenAnotherPiggy2 = false;
						}

						profileInfo.terrainUnlocked[(int) SceneType.kSceneGrass] = true;
						this.UpdateLevelVisibility(-1);
						this.UpdateNumApples();
						this.UpdateSpeedUpProgress();
						numPendingAchievements = 0;
				}


				//-------------------------------------------------------------------
        public void LoadBestTimesAndPrefs ()
		{

						Debug.Log("<color=green>LoadBestTimesAndPrefs</color>");

						FileInfoThing.ListAllFiles(Application.dataPath);

			string path = pathForDocumentsFile( "Preferences.dat" );
			
//			if (Constants.FORCE_PROFILE_RESET) 
//			{
//				this.SetPreferencesDefaults ();
//			}
						#if UNITY_ANDROID && !UNITY_EDITOR
			if (!File.Exists(path))
			{
				Debug.Log("<color=green>Preferences.dat not found at " +path+"</color>");

				//First we are going to check if the file is stored in the old place - 
				//meaning this is the first run of an upgrade.
				
				path = FileInfoThing.GetFallbackPath("Preferences.dat");
			}
						#else

						#endif

			if (!File.Exists(path))
			{
				Debug.Log("<color=green>Preferences.dat also not found at " +path+"</color>");

				//File not found.
				//First thing we need to do is search through all the avaialble files on the device - 
				//try to find the old version of the save files... i don't think they are at pathForDocumentsFile

								path = pathForDocumentsFile( "Preferences.dat" );

								//adding this because if preferences isnt' there then neither is profileinfo basically
								this.SetProfileInfoDefaults();

								this.SetPreferencesDefaults();

				FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(file,preferences);
				file.Close();
				
				return;
			}

			Debug.Log("<color=green>Preferences.dat was found at " + path + "</color>");


			if (!Constants.FORCE_PROFILE_RESET) 
			{

			FileStream filestream = new FileStream (path, FileMode.Open, FileAccess.Read);
			
			BinaryFormatter unformatter = new BinaryFormatter();
			preferences = (ProfilePreferences)unformatter.Deserialize(filestream);
			
			filestream.Close();
			}			
			
			path = pathForDocumentsFile("ProfileInfo9.dat" );

//			if (Constants.FORCE_PROFILE_RESET) 
//			{
//				this.SetProfileInfoDefaults();
//				return;
//			}

			if (!File.Exists(path))
			{
								Debug.Log("<color=green>Preferences.dat not found at " +path+"</color>");

					//First we are going to check if the file is stored in the old place - 
					//meaning this is the first run of an upgrade.

								path = FileInfoThing.GetFallbackPath("ProfileInfo9.dat");
			}

			if (!File.Exists(path))
			{
								Debug.Log("<color=green>Preferences.dat also not found at " +path+"</color>");

								path = pathForDocumentsFile("ProfileInfo9.dat" );


				//file still doesn't exist so this must be a completely new install.

				this.SetProfileInfoDefaults();				
				
				FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(file,profileInfo);
				file.Close();
				
				return;
			}
			
						Debug.Log("<color=green>ProfileInfo9.dat was found at " + path + "</color>");


			FileStream filestream2 = new FileStream (path, FileMode.Open, FileAccess.Read);

			BinaryFormatter unformatter2 = new BinaryFormatter();

			profileInfo = (ProfileInformation)unformatter2.Deserialize(filestream2);			

			filestream2.Close();


			
            for (int l = 0; l < (int)Profile.Enum6.kNumLevelsPlusOne; l++) 
			{
                for (int s = 0; s < 3; s++) 
				{
					notSavedInfo.level[l].bestTime[s] = profileInfo.level[l].bestTime[s];
				}
			}
			
			
			//			result = fread((preferences), sizeof (ProfilePreferences), 1, fp);
			//result = fread((profileInfo), sizeof (ProfileInformation), 1, fp);
			
//			BinaryReader sr = new BinaryReader( file );
			
			//string str = null;
			//str = sr.ReadLine ();
			
			//sr.Close();
			//file.Close();
			
			//return str;
			
			
//			string path = pathForDocumentsFile("BestTimes.dat");
//			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			
//			StreamWriter sw = new StreamWriter( file );
//			sw.WriteLine( str );
			
//			sw.Close();
//			file.Close();						
			
			
			
//			NSArray paths = NSSearchPathForDirectoriesInDomains (NSDocumentDirectory, NSUserDomainMask, true);
//			string documentsDirectory = paths.ObjectAtIndex (0);
//
//			#if ALWAYS_READ_OLD_PROFILE_DATA_TEST
//                string name = String.Format("BestTimes_v2_Phoney.dat");
//			#else
//			string name = String.Format ("BestTimes_v2.dat");
//			#endif
//			string appFile = documentsDirectory.StringByAppendingPathComponent (name);
//			FileStream fp = fopen (appFile.UTF8String (), "rb");

/*			bool haveReadPrefs = false;
			if (Constants.FORCE_PROFILE_RESET) {
				this.SetPreferencesDefaults ();
			} else {
				if (fp == null) {
					string name2 = String.Format ("BestTimesBxx1.dat");
					string appFile2 = documentsDirectory.StringByAppendingPathComponent (name2);
					FileStream fp2 = fopen (appFile2.UTF8String (), "rb");
					if (fp2 == null) {
						this.SetPreferencesDefaults ();
						return;
					} else {
						haveReadPrefs = true;
						this.ReadOldPreferencesAndBestTimes (fp2);
						fclose (fp2);
					}

				}

				if (!haveReadPrefs) {
					this.ReadBestTimesAndPreferencesFromBinaryFile (fp);
					fclose (fp);
				}

			}
			
			*/

			preferences.tiltExpert = false;
			for (int i = 0; i < (int)Enum4.kNumCups; i++) {
				profileInfo.seenWelcomeToCup [i] = true;
			}

			if (Constants.RESET_LEVEL != -1) {
				profileInfo.level [Constants.RESET_LEVEL].levelUnlocked = true;
				notSavedInfo.level [Constants.RESET_LEVEL].bestTime [0] = (long)kBigBestTime;
				notSavedInfo.level [Constants.RESET_LEVEL].bestTime [1] = (long)kBigBestTime;
				notSavedInfo.level [Constants.RESET_LEVEL].bestTime [2] = (long)kBigBestTime;
				profileInfo.level [Constants.RESET_LEVEL].gotTrophy = TrophyType.kTrophy_NotGot;
			}

			#if RESET_PASSED_LEVEL_DATA
                for (int l = 0; l < (int)Profile.Enum6.kNumLevelsPlusOne; l++) {
                    this.ResetLevelData(l);
                    profileInfo.level[l].levelUnlocked = true;
                }

            #endif

            if (Constants.UNLOCK_SOME_LEVELS) {
                profileInfo.seenAnotherPiggy1 = false;
                profileInfo.seenAnotherPiggy2 = false;
            }

            profileInfo.terrainUnlocked[(int) SceneType.kSceneGrass] = true;
            this.UpdateLevelVisibility(-1);
            this.UpdateNumApples();
            this.UpdateSpeedUpProgress();
            numPendingAchievements = 0;
        }

        public void ClearPendingAchievements()
        {
            numPendingAchievements = 0;
        }

        public void WriteCustomLevelInformationToDictionary()
        {
			string path = pathForDocumentsFile("CustomLevels.dat" );
			
            int intValue;
			
//			if (!File.Exists(path))
			{
				FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
				BinaryWriter writer = new BinaryWriter (file);
				
	            for (int i = 0; i < (int)Profile.Enum6.kNumCustomLevels; i++) {
					writer.Write(customLevelMade[i]);
					writer.Write(customLevelNames[i]);
				}
				
				file.Close();
				
				return;
			}        
        }

        public void ReadCustomLevelInformationFromDictionary()
        {
			string path = pathForDocumentsFile("CustomLevels.dat" );
			
            int intValue;
			
			if (!File.Exists(path))
			{
                for (int i = 0; i < (int)Profile.Enum6.kNumCustomLevels; i++) 
				{
                    customLevelMade[i] = -1;
                    string name;
                    if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                        name = String.Format("Eigenes Level");
                    }
                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_English) {
                        name = String.Format("Custom Level");
                    }
                    else {
                        name = Globals.g_world.GetNSString ( StringId.kString_CustomLevel);
                    }

                    customLevelNames[i] = name;  //.AddObject(name);
                }

                return;				
			}
			
			//so file does exist
			
			var sr = new BinaryReader(File.Open(path, FileMode.Open));
				
		    for (int i = 0; i < (int)Profile.Enum6.kNumCustomLevels; i++) 
			{
                customLevelMade[i] = sr.ReadInt32();
                customLevelNames[i] = sr.ReadString();
            }
		}

        public int CheckForUnlockingOfLastCups()
        {
            int justUnlockedCup = -1;
            int totalApples = this.GetTotalNumberOfApples();
            if (totalApples >= Constants.NUM_APPLES_TO_UNLOCK_5) {
                this.QueueAchievement(Profile.Enum2.kAchievement_UnlockableCup5);
                if (this.IsLevelUnlocked(30)) {
                    this.SetLevelUnlockedP1(32, true);
                    if (profileInfo.reachedCupWhenStillLocked[4]) {
                        justUnlockedCup = 4;
                    }

                }

            }

            if (totalApples >= Constants.NUM_APPLES_TO_UNLOCK_7) {
                this.QueueAchievement(Profile.Enum2.kAchievement_UnlockableCup7);
                if (this.IsLevelUnlocked(46)) {
                    this.SetLevelUnlockedP1(48, true);
                    if (profileInfo.reachedCupWhenStillLocked[6]) {
                        justUnlockedCup = 6;
                    }

                }

            }

            if (totalApples >= Constants.NUM_APPLES_TO_UNLOCK_9) {
                this.QueueAchievement(Profile.Enum2.kAchievement_UnlockableCup9);
                if (this.IsLevelUnlocked(62)) {
                    this.SetLevelUnlockedP1(64, true);
                    if (profileInfo.reachedCupWhenStillLocked[8]) {
                        justUnlockedCup = 8;
                    }

                }

            }

            if (totalApples >= Constants.NUM_APPLES_TO_UNLOCK_10) {
                this.QueueAchievement(Profile.Enum2.kAchievement_UnlockableCup10);
                if (this.IsLevelUnlocked(70)) {
                    this.SetLevelUnlockedP1(72, true);
                    if (profileInfo.reachedCupWhenStillLocked[9]) {
                        justUnlockedCup = 9;
                    }

                }

            }

            return justUnlockedCup;
        }

        public void UpdateWhichTerrainsAreUnlocked ()
		{
			if (this.GetBestTimeP1 (BestTimeSet.t_Normal, 8) < 1000.0f) {
				if (!profileInfo.terrainUnlocked [(int)SceneType.kSceneMud]) {
					profileInfo.terrainUnlocked [(int)SceneType.kSceneMud] = true;
				}

			}

			for (int t = 0; t < 3; t++) 
			{
				int intThing = (int)(((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) + t);

				if (this.GetBestTimeP1 (BestTimeSet.t_Normal,intThing) < 1000.0f) 
				{
                    if (!profileInfo.terrainUnlocked[(int) SceneType.kSceneDesert + t]) {
                        profileInfo.terrainUnlocked[(int) SceneType.kSceneDesert + t] = true;
                    }

                }

            }

        }

        public void SetCustomLevelNotMade(int which)
        {
            Globals.Assert(which < (int)Profile.Enum6.kNumCustomLevels);
            customLevelMade[which] = -1;
        }

        public void WriteCustomLevelNoNameP1(int which, int whichScene)
        {
            Globals.Assert(which < (int)Profile.Enum6.kNumCustomLevels);
            customLevelMade[which] = whichScene;
        }

        public void WriteCustomLevelNameP1P2(int which, int whichScene, string name)
        {
            Globals.Assert(which < (int)Profile.Enum6.kNumCustomLevels);
           // customLevelNames.ReplaceObjectAtIndexWithObject(which, name);
        }

        public void SaveCustomLevelInformation()
        {
            this.WriteCustomLevelInformationToDictionary();
    //        Utilities.WriteDictionaryToFileP1(dict, "CustomLevelInfo.dat");
        }

        public void CheckAndLoadCustomLevelInformation()
        {
            if (!customLevelInfoLoadedYet) {
               this.ReadCustomLevelInformationFromDictionary();
                customLevelInfoLoadedYet = true;
			}
        }

        public string GetCustomLevelName()
        {
            Globals.Assert(selectedLevelCustom < (int)Profile.Enum6.kNumCustomLevels);
            return customLevelNames[selectedLevelCustom];
        }

        public bool IsCustomLevelMade(int level)
        {
            Globals.Assert(level < (int)Profile.Enum6.kNumCustomLevels);
            return (customLevelMade[(int)level] != -1);
        }

        public int GetCustomLevelMade(int level)
        {
            Globals.Assert(level < (int)Profile.Enum6.kNumCustomLevels);
            return customLevelMade[(int)level];
        }

/*        public void SaveBestTimeAndPrefsToFile(NSMutableDictionary dict)
        {
            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            if (!documentsDirectory) {
            }

            string name = String.Format("BestTimes.dat");
            string appFile = documentsDirectory.StringByAppendingPathComponent(name);
            dict.WriteToFileAtomically(appFile, true);
        }*/

        unsafe public void EncryptAllBestTimes()
        {
						Blowfish.BLOWFISH_CTX ctx = new Blowfish.BLOWFISH_CTX();

						int kNumLevels = (int)Profile.Enum6.kNumLevels;

						int halfNumLevels = ((kNumLevels+1) / 2);

						for(int l = 0; l < halfNumLevels; l++)
						{	
								this.InitBlowfishForLevel(ctx,l);

								for( int i = 0; i < 3; i++)
								{						
										ulong L = (ulong)notSavedInfo.level[(l*2)].bestTime[i];
										int rightSideLevel = -1;
										ulong R;// = (unsigned long)notSavedInfo.level[rightSideLevel].bestTime[i];
										//int aThing = 10;

										if (((l*2)+1) < kNumLevels)
										{
												rightSideLevel = (l*2)+1;
										}
										else 
										{
												//Just bung score below in here...??? NOO NOO NOO... well ok
												//but don't set the thingy... use val 0...

												//redo both levels beneath us...??

												//JUST SAME NOW THING IS THING BLAH AAAAAAAAAAAAARRRRRRGGGGHHHHHHHH!!!!

												rightSideLevel = (l*2)+1;

												//just use same as Leftside
												//				R = (unsigned long)notSavedInfo.level[(l*2)].bestTime[i];
										}

										R = (ulong)notSavedInfo.level[rightSideLevel].bestTime[i];			

										//	CGFloat abba = notSavedInfo.level[(l*2)].bestTime[i];
										//	CGFloat abba2 = notSavedInfo.level[rightSideLevel].bestTime[i];


										Default.Namespace.Globals.g_blowfish.Blowfish_Encrypt(ctx, &L, &R);			
										//Blowfish_Decrypt(&ctx, &L, &R);

										//Now save encrypted versions in... well in same place i suppose???

										profileInfo.level[l*2].bestTime[i] = (long)L;
										if (rightSideLevel < (int)Profile.Enum6.kNumLevelsPlusOne)
										{
												profileInfo.level[rightSideLevel].bestTime[i] = (long)R;
										}
								}
						}						
        }


				void InitBlowfishForLevel(Blowfish.BLOWFISH_CTX pCtx, int inLevel)
				{
						switch (inLevel) {
						case 0:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx,"BL1X8WAZ", 8);
								break;
						case 1:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "FLUM6PEE", 8);
								break;
						case 2:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "BOGWAP23", 8);
								break;
						case 3:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "LUVB1TES", 8);
								break;
						case 4:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "KEEN2PEE", 8);
								break;
						case 5:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "DRAMW00X", 8);
								break;
						case 6:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "GIZBI2Z2", 8);
								break;
						case 7:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "SALIB092", 8);
								break;
						case 8:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "FREE33ME", 8);
								break;
						case 9:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "ZUMBIPP9", 8);
								break;
						case 10:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "BUGLE3O1", 8);
								break;
						case 11:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "HOWLUV98", 8);
								break;
						case 12:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "B2CKS1CK", 8);
								break;
						case 13:
								Default.Namespace.Globals.g_blowfish.Blowfish_Init(pCtx, "FIXME091", 8);
								break;
						}
				}

        unsafe public void DecryptAllBestTimes()
        {
						Blowfish.BLOWFISH_CTX ctx = new Blowfish.BLOWFISH_CTX();

						int kNumLevels = (int)Profile.Enum6.kNumLevels;

			int halfNumLevels = ((kNumLevels+1) / 2);

			for(int l = 0; l < halfNumLevels; l++)
			{	
								this.InitBlowfishForLevel(ctx,l);

					for( int i = 0; i < 3; i++)
					{						

//										if ((i==0) && (l<8))
//										{
//												int levelId = l*2;
//												ulong timet = (ulong)profileInfo.level[(l*2)].bestTime[i];
//												Debug.Log("bestTime " + levelId.ToString() + " = " + timet.ToString());
//										}


										ulong L = (ulong)profileInfo.level[(l*2)].bestTime[i];
							int rightSideLevel = -1;
							ulong R;

							if (((l*2)+1) < kNumLevels)
							{
									rightSideLevel = (l*2)+1;
							}
							else 
							{
								rightSideLevel = (l*2)+1;
							}

							R = (ulong)profileInfo.level[rightSideLevel].bestTime[i];

							Default.Namespace.Globals.g_blowfish.Blowfish_Decrypt(ctx, &L, &R);			


										if (L < 3000)
							{
												L = (ulong)kBigBestTime;
							}
							if (R < 3000)
							{
												R = (ulong)kBigBestTime;
							}

										notSavedInfo.level[l*2].bestTime[i] = (long)L;

										if (rightSideLevel < (int)Profile.Enum6.kNumLevelsPlusOne)
							{
												notSavedInfo.level[rightSideLevel].bestTime[i] = (long)R;
							}

//										if ((i==0) && (l<8))
//										{
//												int levelId = l*2;
//												ulong timet = (ulong)notSavedInfo.level[(l*2)].bestTime[i];
//
//												Debug.Log("notsaved bestTime " + levelId.ToString() + " = " + timet);
//										}

					}
			}						
        }

        public void SwapLevelInfoP1(int fromRaceId, int toRaceId)
        {
            ProfileInfoPerLevel temp = profileInfo.level[toRaceId];
            profileInfo.level[toRaceId] = profileInfo.level[fromRaceId];
            profileInfo.level[fromRaceId] = temp;
            for (int s = 0; s < (int) BestTimeSet.eSets; s++) {
                long temp2 = notSavedInfo.level[toRaceId].bestTime[s];
                notSavedInfo.level[toRaceId].bestTime[s] = notSavedInfo.level[fromRaceId].bestTime[s];
                notSavedInfo.level[fromRaceId].bestTime[s] = temp2;
            }

        }

        public void MoveOldLevelInfo_v1_to_v2 ()
		{
			const int kLevelOffset3 = 24;
			for (int l = 27; l >= 0; l--) {
				Globals.Assert ((l + kLevelOffset3) < (int)Profile.Enum6.kNumLevelsPlusOne);
				this.SwapLevelInfoP1 (l, l + kLevelOffset3);
			}

			int kCountryStart = 24;
			this.SwapLevelInfoP1 (kCountryStart, 0);
			this.SwapLevelInfoP1 (kCountryStart + 1, 1);
			this.SwapLevelInfoP1 (kCountryStart + 2, 2);
			this.SwapLevelInfoP1 (kCountryStart + 4, kCountryStart);
			this.SwapLevelInfoP1 (kCountryStart + 5, kCountryStart + 4);
			const int kFarmStart = 32;
			this.SwapLevelInfoP1 (kFarmStart + 4, kFarmStart + 3);
			this.SwapLevelInfoP1 (kFarmStart + 5, kFarmStart + 4);
			this.SwapLevelInfoP1 (kFarmStart + 6, kFarmStart + 5);
			this.SwapLevelInfoP1 (kFarmStart + 7, kFarmStart + 6);
			for (int l = 0; l < (int)Profile.Enum6.kNumLevelsNotBonus; l++) 
			{
				if (profileInfo.level [l].gotTrophy != TrophyType.kTrophy_NotGot) {
					profileInfo.level [l + 1].levelUnlocked = true;
				}

			}

			for (int l = 0; l < (int)Profile.Enum6.kNumLevelsNotBonus; l++) {
				if (profileInfo.level [l].levelUnlocked) {
					int stage = this.GetCupFromLevel (l);
					int firstLevelInStage = stage * (int)Profile.Enum6.kNumLevelsPerCup;
                    if (!profileInfo.level[firstLevelInStage].levelUnlocked) {
                        profileInfo.level[firstLevelInStage].levelUnlocked = true;
                    }

                    profileInfo.seenWelcomeToCup[stage] = true;
                }

            }

        }

        public void ResetLevelData (int l)
		{
			Globals.Assert (l < (int)Profile.Enum6.kNumLevelsPlusOne);
            profileInfo.level[l].levelUnlocked = false;
            notSavedInfo.level[l].bestTime[0] = (long)kBigBestTime;
            notSavedInfo.level[l].bestTime[1] = (long)kBigBestTime;
            notSavedInfo.level[l].bestTime[2] = (long)kBigBestTime;

			//???
			profileInfo.level[l].bestTime[0] = (long)kBigBestTime;
            profileInfo.level[l].bestTime[1] = (long)kBigBestTime;
            profileInfo.level[l].bestTime[2] = (long)kBigBestTime;
            profileInfo.level[l].gotTrophy = TrophyType.kTrophy_NotGot;
            profileInfo.level[l].usingSlowerPig = false;
            profileInfo.level[l].usingSlowerPig3apples = false;
        }

        public void SetPreviousVersionSpeedup(int levelReached)
        {
            if (levelReached >= 9) profileInfo.minimumSpeedupProgress = (int)SpeedUpProgressEnum.kSpeedUp_ThirdSpeedBoost;
            else if (levelReached >= 5) profileInfo.minimumSpeedupProgress = (int)SpeedUpProgressEnum.kSpeedUp_SecondSpeedBoost;
            else if (levelReached >= 3) profileInfo.minimumSpeedupProgress = (int)SpeedUpProgressEnum.kSpeedUp_FirstSpeedBoost;
            else profileInfo.minimumSpeedupProgress = (int)SpeedUpProgressEnum.kSpeedUp_InitialSpeed;

        }

        public void ReadOldPreferencesAndBestTimes (FileStream fp)
		{
			/*

			size_t result;
			ProfilePreferences_Save_v1 temporaryPrefs;
			ProfileInformation_Save_v1 temporaryInfo;
			result = fread ((temporaryPrefs), sizeof(ProfilePreferences_Save_v1), 1, fp);
			result = fread ((temporaryInfo), sizeof(ProfileInformation_Save_v1), 1, fp);
			for (int l = 0; l < (int)Profile.Enum6.kNumLevelsPlusOne; l++) {
                    this.ResetLevelData(l);
                }

                int highestLevelThatWasUnlocked = -1;
                for (int l = 0; l < 28; l++) {
                    for (int s = 0; s < 3; s++) {
                        profileInfo.level[l].bestTime[s] = temporaryInfo.level[l].bestTime[s];
                    }

                    profileInfo.level[l].gotTrophy = temporaryInfo.level[l].gotTrophy;
                    if (l < 24) {
                        if (temporaryInfo.level[l].levelUnlocked) {
                            highestLevelThatWasUnlocked = l;
                        }

                    }

                    profileInfo.level[l].levelUnlocked = temporaryInfo.level[l].levelUnlocked;
                    profileInfo.level[l].usingSlowerPig = temporaryInfo.level[l].usingSlowerPig;
                    profileInfo.level[l].usingSlowerPig3apples = temporaryInfo.level[l].usingSlowerPig3apples;
                }

                this.SetPreviousVersionSpeedup(highestLevelThatWasUnlocked);
                profileInfo.seenWelcomeToCup[(int)Enum4.kCupMud] = false;
                profileInfo.seenWelcomeToCup[(int)Enum4.kCupCountryside] = false;
                profileInfo.seenWelcomeToCup[(int)Enum4.kCupPenguin] = false;
                this.DecryptAllBestTimes_v1();
                this.MoveOldLevelInfo_v1_to_v2();
                profileInfo.haveSeenControlChoiceYet = false;
                profileInfo.seenHowToYet = temporaryInfo.seenHowToYet;
                profileInfo.seenCrystalSplash = temporaryInfo.seenCrystalSplash;
                profileInfo.mentionedTrophy = temporaryInfo.mentionedTrophy;
                profileInfo.seenUnlockedBonus1 = temporaryInfo.seenUnlockedBonus1;
                profileInfo.seenUnlockedBonus2 = temporaryInfo.seenUnlockedBonus2;
                profileInfo.seenUnlockedBonus3 = temporaryInfo.seenUnlockedBonus3;
                profileInfo.seenAnotherPiggy1 = temporaryInfo.seenAnotherPiggy1;
                profileInfo.seenAnotherPiggy2 = temporaryInfo.seenAnotherPiggy2;
                profileInfo.seenWelcomeToCup[(int)Enum4.kCupFarmyard] = temporaryInfo.seenWelcomeToFarmyard;
                profileInfo.seenWelcomeToCup[(int)Enum4.kCupStar] = temporaryInfo.seenWelcomeToStar;
                profileInfo.feelGoodScreenPending = temporaryInfo.feelGoodScreenPending;
                profileInfo.appleScreenPending = temporaryInfo.appleScreenPending;
                profileInfo.speedUpScreenPending = temporaryInfo.speedUpScreenPending;
                profileInfo.anotherPiggyScreenPending = temporaryInfo.anotherPiggyScreenPending;
                profileInfo.feelGoodProgress = temporaryInfo.feelGoodProgress;
                for (int t = 0; t < 5; t++) {
                    profileInfo.terrainUnlocked[t] = temporaryInfo.terrainUnlocked[t];
                }

                profileInfo.terrainUnlocked[0] = true;
                preferences.musicOn = temporaryPrefs.musicOn;
                preferences.soundFxOn = temporaryPrefs.soundFxOn;
                preferences.ghostOn = temporaryPrefs.ghostOn;
                preferences.diffEasy = temporaryPrefs.diffEasy;
                preferences.controlTilt = temporaryPrefs.controlTilt;
                preferences.tiltExpert = false;
                */

        }

        public void ReadBestTimesAndPreferencesFromBinaryFile(FileStream fp)
        {
//            size_t result;
  //          result = fread((preferences), sizeof (ProfilePreferences), 1, fp);
    //        result = fread((profileInfo), sizeof (ProfileInformation), 1, fp);
      //      this.DecryptAllBestTimes();
        }

        public void WriteBestTimesToBinaryFile(FileStream fp)
        {
  //          size_t result;
    //        this.EncryptAllBestTimes();
      //      result = fwrite((char) (preferences), sizeof (ProfilePreferences), 1, fp);
        //    result = fwrite((char) (profileInfo), sizeof (ProfileInformation), 1, fp);
        }

        public void SaveBestTimesAndPrefs()
        {
						#if UNITY_IOS
						this.SaveBestTimesAndPrefsIOS();
						return;
						#endif

			string path = pathForDocumentsFile("Preferences.dat" );
					
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(file,preferences);
			file.Close();
			
			path = pathForDocumentsFile( "ProfileInfo9.dat" );
				
			Debug.Log ("profile FileThing " + path);			
			
			for (int l = 0; l < (int)Profile.Enum6.kNumLevelsPlusOne; l++) 
			{
                for (int s = 0; s < 3; s++) 
				{
					profileInfo.level[l].bestTime[s] = notSavedInfo.level[l].bestTime[s];
				}
			}

			
			FileStream file2 = new FileStream (path, FileMode.Create, FileAccess.Write);
			BinaryFormatter formatter2 = new BinaryFormatter();
			formatter2.Serialize(file2,profileInfo);
			file2.Close();

			
/*            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            if (!documentsDirectory) {
            }

            string name = String.Format("BestTimes_v2.dat");
            string appFile = documentsDirectory.StringByAppendingPathComponent(name);
            FileStream fp = fopen(appFile, "wb");
            this.WriteBestTimesToBinaryFile(fp);
            fclose (fp);*/
        }

				public void SaveBestTimesAndPrefsIOS()
				{
						string path = pathForDocumentsFile("BestTimes_v3.dat" );

						Debug.Log("<color=red>Attempt to save " + path + "</color>");

						for (int l = 0; l < (int)Profile.Enum6.kNumLevelsPlusOne; l++) 
						{
								for (int s = 0; s < 3; s++) 
								{
										profileInfo.level[l].bestTime[s] = notSavedInfo.level[l].bestTime[s];
								}
						}

						this.EncryptAllBestTimes();


						FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
						BinaryFormatter formatter = new BinaryFormatter();
						formatter.Serialize(file,preferences);
						formatter.Serialize(file,profileInfo);
						file.Close();

//						path = pathForDocumentsFile( "ProfileInfo9.dat" );

//						Debug.Log ("profile FileThing " + path);			



//						FileStream file2 = new FileStream (path, FileMode.Create, FileAccess.Write);
//						BinaryFormatter formatter2 = new BinaryFormatter();
//						formatter2.Serialize(file2,profileInfo);
//						file2.Close();


						/*            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            if (!documentsDirectory) {
            }

            string name = String.Format("BestTimes_v2.dat");
            string appFile = documentsDirectory.StringByAppendingPathComponent(name);
            FileStream fp = fopen(appFile, "wb");
            this.WriteBestTimesToBinaryFile(fp);
            fclose (fp);*/
				}

        public void SaveBestTimesAndPrefsOldWay()
        {
        }

        public bool CanPlayNextLevel (int nextLevel)
		{
			if (nextLevel == ((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) {
                return false;
            }

            if (Constants.UNLOCK_ALL_LEVELS) {
                return true;
            }

            int thisLevel = nextLevel - 1;
            if (thisLevel >= 0) {
                if (profileInfo.level[thisLevel].gotTrophy == TrophyType.kTrophy_NotGot) {
                    return false;
                }

            }

            return (profileInfo.level[nextLevel].levelUnlocked && levelVisible[nextLevel]);
        }

        public bool SetCurrentBestTimeP1(int level, float inTime)
        {
            return this.SetBestTimeP1P2(this.GetRelevantBestTimeSet(), level, inTime);
        }

        public bool SetBestTimeP1P2 (BestTimeSet inSet, int level, float inTime)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            notSavedInfo.level[(int)level].bestTime[(int)inSet] = (long) (inTime * 1000.0f);
            this.UpdateWhichTerrainsAreUnlocked();
            return false;
        }

        public void SetNumApplesForRaceP1 (int level, int inNumApples)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            if (inNumApples == 0) profileInfo.level[(int)level].gotTrophy = TrophyType.kTrophy_NotGot;
            else if (inNumApples == 1) profileInfo.level[(int)level].gotTrophy = TrophyType.kTrophy_OneApple;
            else if (inNumApples == 2) profileInfo.level[(int)level].gotTrophy = TrophyType.kTrophy_TwoApples;
            else if (inNumApples == 3) {
                profileInfo.level[(int)level].gotTrophy = TrophyType.kTrophy_ThreeApples;
            }

            this.UpdateLevelVisibility(level);
            this.UpdateNumApples();
        }

        public void CheckBonus3Apples(int justPlayedLevel)
        {
        }

        public int GetRacePosition (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            return (int)(profileInfo.level[(int)level].gotTrophy) + 1;
        }

        public bool IsStageAvailable (int inStage)
		{
			return true;
			if (inStage == (int)FrontEnd.Enum2.kStageBonusLevels) {
				return true;
			} else {
				return profileInfo.level [(int)Profile.Enum6.kNumLevelsPerCup * inStage].levelUnlocked;
            }

            return true;
        }

        public void JustPassedLevel (int playingLevel)
		{
			if (playingLevel == 7) {
			} else if (playingLevel == 15) {
			} else if (playingLevel == 23) {
			}

			if (playingLevel == ((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) {
			} else if (playingLevel == ((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) + 1) {
			} else if (playingLevel == ((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) + 2) {
            }

        }

        public bool HasGCLeaderboard(int playingLevel)
        {
						//this 20 limit was for Crystal and i believe we have already got them all
						//in iTunes connect.
						return true;

            int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
            switch (realLevelId) {
            case (int)LevelBuilder_Ross.Enum2.kGrass1_8_MdwCup_Race8_CowField :
            case (int)LevelBuilder_Ross.Enum2.kGrass_DuckpondDance :
            case (int)LevelBuilder_Ross.Enum2.kMud_BarrelMaze :
            case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge :
            case (int)LevelBuilder_Ross.Enum2.kGrass1_6_MdwCup_Race6_CattleRun :
            case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly :
            case (int)LevelBuilder_Ross.Enum2.kMud8_6_BlueTulips :
            case (int)LevelBuilder_Ross.Enum2.kMud8_5_PumpkinWiggle :
            case (int)LevelBuilder_Ross.Enum2.kGrass4_5_CntCup_Race5_HOW :
            case (int)LevelBuilder_Ross.Enum2.kGrass9_5_Campyard :
            case (int)LevelBuilder_Ross.Enum2.kMud8_4_TulipChicane :
            case (int)LevelBuilder_Ross.Enum2.kMud5_4_FrmCup_Race4_AlleyHogs :
            case (int)LevelBuilder_Ross.Enum2.kGrass7_7_Orchard :
            case (int)LevelBuilder_Ross.Enum2.kGrass8_7_BridgeJumps :
            case (int)LevelBuilder_Ross.Enum2.kMud5_7_FrmCup_Race7_HumptyJumpty :
            case (int)LevelBuilder_Ross.Enum2.kMud8_8_MudCup_Race1_HayBaby :
            case (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep :
            case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop :
            case (int)LevelBuilder_Ross.Enum2.kMudN1_5_StarStables :
            case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville :
                return true;
                break;
            }

            return false;
        }

        public string GetLeaderboardId(int playingLevel)
        {
            int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
            switch (realLevelId) {
            case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne :
                return "2367585933";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo :
                return "2367766332";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass1_7_MdwCup_Race7_Bollards :
                return "2367517719";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks :
                return "2367897483";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail :
                return "2367939195";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes :
                return "2367874549";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass1_8_MdwCup_Race8_CowField :
                return "2367599877";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass_DuckpondDance :
                return "2367871440";
                
            case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips :
                return "2385051524";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_EasyStables :
                return "2384924821";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers :
                return "2385066787";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_LongJumps :
                return "2385085125";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_MudVille :
                return "2385079224";
                
            case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines :
                return "2385083900";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_BarrelMaze :
                return "2384501843";
                
            case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge :
                return "2385127285";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass4_6_CntCup_Race6_ABridgeTooMoo :
                return "2385367161";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass4_4_CntCup_Race4_BT :
                return "2385368593";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass4_2_CntCup_Race2_LongBridge :
                return "2385301873";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly :
                return "2385321854";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass1_6_MdwCup_Race6_CattleRun :
                return "2385370403";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass9_4_FourRivers :
                return "2385351280";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass4_7_CntCup_Race7_RP :
                return "2385338728";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass9_2_BigJump :
                return "2385335425";
                
            case (int)LevelBuilder_Ross.Enum2.kMud8_1_PumpkinPatch :
                return "2384204616";
                
            case (int)LevelBuilder_Ross.Enum2.kMud8_5_PumpkinWiggle :
                return "2385299982";
                
            case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage :
                return "2385331407";
                
            case (int)LevelBuilder_Ross.Enum2.kMud2_7_MudCup_Race7_BarrelsOfFun :
                return "2385269155";
                
            case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles :
                return "2384135741";
                
            case (int)LevelBuilder_Ross.Enum2.kMud2_4_MudCup_Race4_LongRoof :
                return "2385304165";
                
            case (int)LevelBuilder_Ross.Enum2.kMud2_2_VegShirleyAndFlock :
                return "2384220874";
                
            case (int)LevelBuilder_Ross.Enum2.kMud3_8_PenCup_Race8_Weave :
                return "2385260778";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass9_5_Campyard :
                return "2385251662";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass4_5_CntCup_Race5_HOW :
                return "2383972870";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass4_8_CntCup_Race8_ABridgeTooBaa :
                return "2385266916";
                
            case (int)LevelBuilder_Ross.Enum2.kGrassN2_2_HayBaleGroove :
                return "2385196968";
                
            case (int)LevelBuilder_Ross.Enum2.kGrassN2_8_ThinTreeAve :
                return "2385185535";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass9_3_BaleLines :
                return "2385305046";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass9_7_Puddles :
                return "2384237696";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass_GnomeHome :
                return "2385272316";
                
            case (int)LevelBuilder_Ross.Enum2.kMud7_4_Junkyard :
                return "2385212527";
                
            case (int)LevelBuilder_Ross.Enum2.kMud5_1_FrmCup_Race1_BarnDance :
                return "2385250771";
                
            case (int)LevelBuilder_Ross.Enum2.kMud5_2_FrmCup_Race2_GetUp :
                return "2385266337";
                
            case (int)LevelBuilder_Ross.Enum2.kMud5_4_FrmCup_Race4_AlleyHogs :
                return "2385262223";
                
            case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard :
                return "2385270360";
                
            case (int)LevelBuilder_Ross.Enum2.kMud3_6_PenCup_Race6_PCurvy :
                return "2385215270";
                
            case (int)LevelBuilder_Ross.Enum2.kMud3_1_PenCup_Race1_IceHoles :
                return "2385259349";
                
            case (int)LevelBuilder_Ross.Enum2.kMud5_3_FrmCup_Race3_TractorFactor :
                return "2385263031";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass7_7_Orchard :
                return "2385220474";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass8_7_BridgeJumps :
                return "2385248022";
                
            case (int)LevelBuilder_Ross.Enum2.kGrassN2_3_RainbowRuns :
                return "2385225376";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass7_6_Trampoline :
                return "2385167743";
                
            case (int)LevelBuilder_Ross.Enum2.kGrassN2_4_SideSideJumps :
                return "2385221329";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass6_6_StrCup_Race6_MazyD :
                return "2385218555";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow :
                return "2384938769";
                
            case (int)LevelBuilder_Ross.Enum2.kGrassN1_7_HayChicanes :
                return "2385184889";
                
            case (int)LevelBuilder_Ross.Enum2.kMud8_2_BarrelThing :
                return "2385222502";
                
            case (int)LevelBuilder_Ross.Enum2.kMud5_7_FrmCup_Race7_HumptyJumpty :
                return "2385187832";
                
            case (int)LevelBuilder_Ross.Enum2.kMud5_8_FrmCup_Race8_Swineyard :
                return "2385211464";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_TheWoods :
                return "2385221082";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_ForestFlock :
                return "2385179921";
                
            case (int)LevelBuilder_Ross.Enum2.kMud10_2_MarrowField :
                return "2385217008";
                
            case (int)LevelBuilder_Ross.Enum2.kMud8_4_TulipChicane :
                return "2384953777";
                
            case (int)LevelBuilder_Ross.Enum2.kMud8_8_MudCup_Race1_HayBaby :
                return "2385188397";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass10_1_LotsOfSheep :
                return "2385128551";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass9_8_Gardens :
                return "2385183398";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass_WideJumps :
                return "2385167367";
                
            case (int)LevelBuilder_Ross.Enum2.kGrassN1_8_SquareHedgeShuffle :
                return "2385195149";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass6_2_StrCup_Race2_Hogwash :
                return "2385118729";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass6_5_StrCup_Race5_scruba :
                return "2385155989";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep :
                return "2385168216";
                
            case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop :
                return "2385119980";
                
            case (int)LevelBuilder_Ross.Enum2.kMud7_8_SquashDodge :
                return "2385010836";
                
            case (int)LevelBuilder_Ross.Enum2.kMud8_6_BlueTulips :
                return "2385069989";
                
            case (int)LevelBuilder_Ross.Enum2.kMud3_7_PenCup_Race7_Migration :
                return "2384994647";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_RoadCrossingsFlowers :
                return "2385110947";
                
            case (int)LevelBuilder_Ross.Enum2.kMud10_3_PumpkinJumps :
                return "2385146420";
                
            case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville :
                return "2385119766";
                
            case (int)LevelBuilder_Ross.Enum2.kMudN1_5_StarStables :
                return "2385106645";
                
            case (int)LevelBuilder_Ross.Enum2.kMud_Harvest :
                return "2385105852";
                
            }

            return "";
        }

        public string GetAchievementName(int achievementId)
        {
            switch ((Profile.Enum2)achievementId) {
            case Profile.Enum2.kAchievement_PigPush :
                {
                    return "Pig Push";
                }
                
            case Profile.Enum2.kAchievement_DryDucks :
                {
                    return "Race 8 - Dry Ducks";
                }
                
            case Profile.Enum2.kAchievement_ShirleyThump :
                {
                    return "Shirley Smash";
                }
                
            case Profile.Enum2.kAchievement_Beat1Pig :
                {
                    return "New Racer";
                }
                
            case Profile.Enum2.kAchievement_Beat3Pigs :
                {
                    return "Getting Better";
                }
                
            case Profile.Enum2.kAchievement_HighFlier :
                {
                    return "High Flier";
                }
                
            case Profile.Enum2.kAchievement_RoofRunner :
                {
                    return "Roof Runner";
                }
                
            case Profile.Enum2.kAchievement_SpeedBoost :
                {
                    return "Sheep Boost";
                }
                
            case Profile.Enum2.kAchievement_HitAppleTree :
                {
                    return "Apple Tree";
                }
                
            case Profile.Enum2.kAchievement_Hit5AppleTrees :
                {
                    return "Apple Crumble";
                }
                
            case Profile.Enum2.kAchievement_Hit30Rainbows :
                {
                    return "Boost Bonanza";
                }
                
            case Profile.Enum2.kAchievement_WeaveMagic :
                {
                    return "Race 25 - Weave Magic";
                }
                
            case Profile.Enum2.kAchievement_BarrelMaze :
                {
                    return "Race 12 - Ram-page";
                }
                
            case Profile.Enum2.kAchievement_PassDayDreamNoFlowers :
                {
                    return "Race 16 - Trance Prance";
                }
                
            case Profile.Enum2.kAchievement_PassVegDodgeNoVeg :
                {
                    return "Race 15 - Vegetarian";
                }
                
            case Profile.Enum2.kAchievement_PassSquashDodgeNoVeg :
                {
                    return "Race 78 - Squash-buckler";
                }
                
            case Profile.Enum2.kAchievement_PassPCurvyNoFlock :
                {
                    return "Race 41 - Baa-rathon Runner";
                }
                
            case Profile.Enum2.kAchievement_PassMigrationNoMud :
                {
                    return "Race 58 - Sheep Clean";
                }
                
            case Profile.Enum2.kAchievement_PassRoadSheepNoSheep :
                {
                    return "Race 69 - Frogger";
                }
                
            case Profile.Enum2.kAchievement_PassMudvilleNoHouse :
                {
                    return "Race 14 - Mudville Myth";
                }
                
            case Profile.Enum2.kAchievement_PassMazyDazyNoHedge :
                {
                    return "Race 55 - Crazy Maze";
                }
                
            case Profile.Enum2.kAchievement_WinSnowForestNoTrees :
                {
                    return "Race 62 - Good Woods";
                }
                
            case Profile.Enum2.kAchievement_WinHogzwallopNotWet :
                {
                    return "Race 71 - Dry Sheep";
                }
                
            case Profile.Enum2.kAchievement_WinPumpkinJumpsNoPumpkins :
                {
                    return "Race 77 - Pumpkin Pie";
                }
                
            case Profile.Enum2.kAchievement_WinTrottervilleNoHouse :
                {
                    return "Race 80 - Trots Alot";
                }
                
            case Profile.Enum2.kAchievement_CreateTrack :
                {
                    return "Track Creator";
                }
                
            case Profile.Enum2.kAchievement_UnlockableCup5 :
                {
                    string outDescription = String.Format("Collect %d Apples", Constants.NUM_APPLES_TO_UNLOCK_5);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_UnlockableCup7 :
                {
                    string outDescription = String.Format("Collect %d Apples", Constants.NUM_APPLES_TO_UNLOCK_7);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_UnlockableCup9 :
                {
                    string outDescription = String.Format("Collect %d Apples", Constants.NUM_APPLES_TO_UNLOCK_9);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_UnlockableCup10 :
                {
                    string outDescription = String.Format("Collect %d Apples", Constants.NUM_APPLES_TO_UNLOCK_10);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_CompletedCup1 :
                {
                    return "Meadow Master";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup2 :
                {
                    return "Garden King";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup3 :
                {
                    return "Park Lark";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup4 :
                {
                    return "Pumpkin Win";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup5 :
                {
                    return "Camp Champ";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup6 :
                {
                    return "Trash Masher";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup7 :
                {
                    return "Tutti Fruiti";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup8 :
                {
                    return "Swine Fine";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup9 :
                {
                    return "Hog Walloper";
                }
                
            case Profile.Enum2.kAchievement_CompletedCup10 :
                {
                    return "Mud Maestro";
                }
                
            case Profile.Enum2.kAchievement_RecordBreaker_CurlyWurly :
            case Profile.Enum2.kAchievement_RecordBreaker_MudVille :
            case Profile.Enum2.kAchievement_RecordBreaker_CowField :
            case Profile.Enum2.kAchievement_RecordBreaker_LongJumps :
            case Profile.Enum2.kAchievement_RecordBreaker_FourRivers :
            case Profile.Enum2.kAchievement_RecordBreaker_LongRoof :
            case Profile.Enum2.kAchievement_RecordBreaker_PumpkinWiggle :
            case Profile.Enum2.kAchievement_RecordBreaker_CampSite :
            case Profile.Enum2.kAchievement_RecordBreaker_HOW :
            case Profile.Enum2.kAchievement_RecordBreaker_Junkyard :
            case Profile.Enum2.kAchievement_RecordBreaker_GetUp :
            case Profile.Enum2.kAchievement_RecordBreaker_BridgeJump :
            case Profile.Enum2.kAchievement_RecordBreaker_RainbowRuns :
            case Profile.Enum2.kAchievement_RecordBreaker_TulipChicane :
                {
                    int whichLevel = breakerLevel[achievementId];
                    string outDescription = String.Format("Record Breaker - Race %d", whichLevel + 1);
                    return outDescription;
                }
                
            }

            return "No Name";
        }

        public string GetAchievementDescription(int achievementId)
        {
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                return this.GetAchievementDescriptionGerman(achievementId);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                return this.GetAchievementDescriptionChinese(achievementId);
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                return this.GetAchievementDescriptionJapanese(achievementId);
            }
            else {
                return this.GetAchievementDescriptionEnglish(achievementId);
            }

        }

        public string GetAchievementDescriptionEnglish(int achievementId)
        {
            switch ((Profile.Enum2)achievementId) {
            case Profile.Enum2.kAchievement_UnlockableCup5 :
            case Profile.Enum2.kAchievement_UnlockableCup7 :
            case Profile.Enum2.kAchievement_UnlockableCup9 :
            case Profile.Enum2.kAchievement_UnlockableCup10 :
                {
                    int[] cupIdThing = new int [4]
                    {4, 6, 8, 9};
                    int cupId = cupIdThing[achievementId - (int)Profile.Enum2.kAchievement_UnlockableCup5];
                    int levelThatNeedsToBeUnlocked = cupId * 8;
                    if (!this.IsLevelUnlocked(levelThatNeedsToBeUnlocked)) {
                        string outDescription = String.Format("Cup %d - %@ is now unlockable!", cupId + 1, (cup[cupId]).name);
                        return outDescription;
                    }
                    else {
                        string outDescription = String.Format("Cup %d - %@ is now unlocked!", cupId + 1, (cup[cupId]).name);
                        return outDescription;
                    }

                }
                 
            case Profile.Enum2.kAchievement_CompletedCup1 :
            case Profile.Enum2.kAchievement_CompletedCup2 :
            case Profile.Enum2.kAchievement_CompletedCup3 :
            case Profile.Enum2.kAchievement_CompletedCup4 :
            case Profile.Enum2.kAchievement_CompletedCup5 :
            case Profile.Enum2.kAchievement_CompletedCup6 :
            case Profile.Enum2.kAchievement_CompletedCup7 :
            case Profile.Enum2.kAchievement_CompletedCup8 :
            case Profile.Enum2.kAchievement_CompletedCup9 :
            case Profile.Enum2.kAchievement_CompletedCup10 :
                {
                    int cupId = achievementId - (int)Profile.Enum2.kAchievement_CompletedCup1;
                    string outDescription = String.Format("Collect 24 apples on %@", (cup[cupId]).name);
                    return outDescription;
                }
                 
            case Profile.Enum2.kAchievement_RecordBreaker_CurlyWurly :
            case Profile.Enum2.kAchievement_RecordBreaker_MudVille :
            case Profile.Enum2.kAchievement_RecordBreaker_CowField :
            case Profile.Enum2.kAchievement_RecordBreaker_LongJumps :
            case Profile.Enum2.kAchievement_RecordBreaker_FourRivers :
            case Profile.Enum2.kAchievement_RecordBreaker_LongRoof :
            case Profile.Enum2.kAchievement_RecordBreaker_PumpkinWiggle :
            case Profile.Enum2.kAchievement_RecordBreaker_CampSite :
            case Profile.Enum2.kAchievement_RecordBreaker_HOW :
            case Profile.Enum2.kAchievement_RecordBreaker_Junkyard :
            case Profile.Enum2.kAchievement_RecordBreaker_GetUp :
            case Profile.Enum2.kAchievement_RecordBreaker_BridgeJump :
            case Profile.Enum2.kAchievement_RecordBreaker_RainbowRuns :
            case Profile.Enum2.kAchievement_RecordBreaker_TulipChicane :
                {
                    int whichLevel = breakerLevel[achievementId];
                    string levelName = this.GetLevelNameStringWithoutNewline(whichLevel);
                    string outDescription = String.Format("Beat %.2f seconds on %@", breakerTime[whichLevel], levelName);
                    return outDescription;
                }
                  
            case Profile.Enum2.kAchievement_Hit30Rainbows :
                return "Hit 30 Boosts in one race!";
                
            case Profile.Enum2.kAchievement_HitAppleTree :
                return "Knock the apples off a tree!";
                 
            case Profile.Enum2.kAchievement_Hit5AppleTrees :
                return "Knock apples off 5 trees and pass a level!";
                 
            case Profile.Enum2.kAchievement_PigPush :
                return "Push the pig in the pond and win Race 1!";
                 
            case Profile.Enum2.kAchievement_Beat1Pig :
                return "Beat a pig through the gates!";
                 
            case Profile.Enum2.kAchievement_Beat3Pigs :
                return "Beat all the pigs through the gates!";
                 
            case Profile.Enum2.kAchievement_HighFlier :
                return "Overtake a pig in mid-air on Race 24!";
                 
            case Profile.Enum2.kAchievement_RoofRunner :
                return "Stay on the roof for half a second!";
                 
            case Profile.Enum2.kAchievement_SpeedBoost :
                return "Hit a speed boost!";
                 
            case Profile.Enum2.kAchievement_ShirleyThump :
                return "Crash into Shirley at full speed!";
                 
            case Profile.Enum2.kAchievement_CreateTrack :
                return "Create your first track!";
                 
            case Profile.Enum2.kAchievement_WeaveMagic :
                return "Win Sheep Shape, avoiding other sheep!";
                 
            case Profile.Enum2.kAchievement_DryDucks :
                return "Win Duckpond Dash and stay dry!";
                
            case Profile.Enum2.kAchievement_BarrelMaze :
                return "Win Barrel Ram-page, avoiding barrels!";
                
            case Profile.Enum2.kAchievement_PassDayDreamNoFlowers :
                return "Pass Tulip Trance, avoiding flowers!";
                
            case Profile.Enum2.kAchievement_PassVegDodgeNoVeg :
                return "Pass Marrow Mayhem, avoiding vegetables!";
                
            case Profile.Enum2.kAchievement_PassSquashDodgeNoVeg :
                return "Pass Swine Sprint, avoiding vegetables!";
                
            case Profile.Enum2.kAchievement_PassPCurvyNoFlock :
                return "Pass Baa-rathon, avoiding other sheep!";
                
            case Profile.Enum2.kAchievement_PassMigrationNoMud :
                return "Pass Migration without getting muddy!";
                
            case Profile.Enum2.kAchievement_PassRoadSheepNoSheep :
                return "Pass Road Hog and apublic void all sheep!";
                
            case Profile.Enum2.kAchievement_PassMudvilleNoHouse :
                return "Pass Mudville, avoiding buildings!";
                
            case Profile.Enum2.kAchievement_PassMazyDazyNoHedge :
                return "Pass Mazy Dazy without hitting a hedge!";
                
            case Profile.Enum2.kAchievement_WinSnowForestNoTrees :
                return "Win The Woods, avoiding trees!";
                
            case Profile.Enum2.kAchievement_WinHogzwallopNotWet :
                return "Win Woolly Wash and don't get wet!";
                
            case Profile.Enum2.kAchievement_WinPumpkinJumpsNoPumpkins :
                return "Win Pumpkin Jumps and apublic void pumpkins!";
                
            case Profile.Enum2.kAchievement_WinTrottervilleNoHouse :
                return "Win Trotterville, avoiding buildings!";
                
            }

            return null;
        }

        string GetAchievementDescriptionChinese(int achievementId)
        {
            switch ((Profile.Enum2)achievementId) {
            case Profile.Enum2.kAchievement_UnlockableCup5 :
            case Profile.Enum2.kAchievement_UnlockableCup7 :
            case Profile.Enum2.kAchievement_UnlockableCup9 :
            case Profile.Enum2.kAchievement_UnlockableCup10 :
                {
                    int[] cupIdThing = new int [4]
                    {4, 6, 8, 9};
                    int cupId = cupIdThing[achievementId - (int)Profile.Enum2.kAchievement_UnlockableCup5];
                    int levelThatNeedsToBeUnlocked = cupId * 8;
                    if (!this.IsLevelUnlocked(levelThatNeedsToBeUnlocked)) {
                        string outDescription = String.Format("奖杯%d - %@ 现在可以被解锁！", cupId + 1, (cup[cupId]).name);
                        return outDescription;
                    }
                    else {
                        string outDescription = String.Format("奖杯%d - %@ 现在可以被解锁！", cupId + 1, (cup[cupId]).name);
                        return outDescription;
                    }

                }
                
            case Profile.Enum2.kAchievement_CompletedCup1 :
            case Profile.Enum2.kAchievement_CompletedCup2 :
            case Profile.Enum2.kAchievement_CompletedCup3 :
            case Profile.Enum2.kAchievement_CompletedCup4 :
            case Profile.Enum2.kAchievement_CompletedCup5 :
            case Profile.Enum2.kAchievement_CompletedCup6 :
            case Profile.Enum2.kAchievement_CompletedCup7 :
            case Profile.Enum2.kAchievement_CompletedCup8 :
            case Profile.Enum2.kAchievement_CompletedCup9 :
            case Profile.Enum2.kAchievement_CompletedCup10 :
                {
                    int cupId = achievementId - (int)Profile.Enum2.kAchievement_CompletedCup1;
                    string outDescription = String.Format("在”%@“采集24个苹果", (cup[cupId]).name);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_RecordBreaker_CurlyWurly :
            case Profile.Enum2.kAchievement_RecordBreaker_MudVille :
            case Profile.Enum2.kAchievement_RecordBreaker_CowField :
            case Profile.Enum2.kAchievement_RecordBreaker_LongJumps :
            case Profile.Enum2.kAchievement_RecordBreaker_FourRivers :
            case Profile.Enum2.kAchievement_RecordBreaker_LongRoof :
            case Profile.Enum2.kAchievement_RecordBreaker_PumpkinWiggle :
            case Profile.Enum2.kAchievement_RecordBreaker_CampSite :
            case Profile.Enum2.kAchievement_RecordBreaker_HOW :
            case Profile.Enum2.kAchievement_RecordBreaker_Junkyard :
            case Profile.Enum2.kAchievement_RecordBreaker_GetUp :
            case Profile.Enum2.kAchievement_RecordBreaker_BridgeJump :
            case Profile.Enum2.kAchievement_RecordBreaker_RainbowRuns :
            case Profile.Enum2.kAchievement_RecordBreaker_TulipChicane :
                {
                    int whichLevel = breakerLevel[achievementId];
                    string levelName = this.GetLevelNameStringWithoutNewline(whichLevel);
                    string outDescription = String.Format("在”%@“中击败%.2f秒！", levelName, breakerTime[whichLevel]);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_Hit30Rainbows :
                return "在一场竞赛中撞到30个加速器！";
                
            case Profile.Enum2.kAchievement_HitAppleTree :
                return "撞击一棵树以掉下苹果！";
                
            case Profile.Enum2.kAchievement_Hit5AppleTrees :
                return "撞击5棵树以掉下苹果，并过了一关！";
                
            case Profile.Enum2.kAchievement_PigPush :
                return "把猪推进水塘，并且赢得竞赛1！";
                
            case Profile.Enum2.kAchievement_Beat1Pig :
                return "通过门击败一头猪！";
                
            case Profile.Enum2.kAchievement_Beat3Pigs :
                return "通过门击败所有猪！";
                
            case Profile.Enum2.kAchievement_HighFlier :
                return "第24场比赛里在半空超过一头猪！";
                
            case Profile.Enum2.kAchievement_RoofRunner :
                return "在屋顶停留半秒！";
                
            case Profile.Enum2.kAchievement_SpeedBoost :
                return "撞到一个加速器！";
                
            case Profile.Enum2.kAchievement_ShirleyThump :
                return "全速撞向雪莉！";
                
            case Profile.Enum2.kAchievement_CreateTrack :
                return "制造你第一条跑道！";
                
            case Profile.Enum2.kAchievement_WeaveMagic :
                return "赢得“井然有序”，躲避其他绵羊！";
                
            case Profile.Enum2.kAchievement_DryDucks :
                return "赢得“鸭池冲刺”，并且保持干燥！";
                
            case Profile.Enum2.kAchievement_BarrelMaze :
                return "赢得“冲撞酒桶”，躲避酒桶！";
                
            case Profile.Enum2.kAchievement_PassDayDreamNoFlowers :
                return "闯过“情迷郁金香”，躲避花朵！";
                
            case Profile.Enum2.kAchievement_PassVegDodgeNoVeg :
                return "闯过”躲避蔬菜“，躲避蔬菜！";
                
            case Profile.Enum2.kAchievement_PassSquashDodgeNoVeg :
                return "闯过”小猪快跑“，躲避蔬菜！";
                
            case Profile.Enum2.kAchievement_PassPCurvyNoFlock :
                return "闯过”马拉松“，躲避其他绵羊！";
                
            case Profile.Enum2.kAchievement_PassMigrationNoMud :
                return "闯过”迁徙“并未沾染泥巴！";
                
            case Profile.Enum2.kAchievement_PassRoadSheepNoSheep :
                return "闯过”路霸“，并躲避所有绵羊！";
                
            case Profile.Enum2.kAchievement_PassMudvilleNoHouse :
                return "闯过”莫德威“，躲避建筑物！";
                
            case Profile.Enum2.kAchievement_PassMazyDazyNoHedge :
                return "闯过”木头人“，并未撞到一块篱笆！";
                
            case Profile.Enum2.kAchievement_WinSnowForestNoTrees :
                return "赢得”丛林“，躲避树木！";
                
            case Profile.Enum2.kAchievement_WinHogzwallopNotWet :
                return "赢得”洗羊毛“，并未弄湿！";
                
            case Profile.Enum2.kAchievement_WinPumpkinJumpsNoPumpkins :
                return "赢得”跳南瓜“，并躲避南瓜！";
                
            case Profile.Enum2.kAchievement_WinTrottervilleNoHouse :
                return "赢得”特洛特威尔“，躲避建筑物！";
                
            }

            return null;
        }

        string GetAchievementDescriptionJapanese(int achievementId)
        {
            switch ((Profile.Enum2)achievementId) {
            case Profile.Enum2.kAchievement_UnlockableCup5 :
            case Profile.Enum2.kAchievement_UnlockableCup7 :
            case Profile.Enum2.kAchievement_UnlockableCup9 :
            case Profile.Enum2.kAchievement_UnlockableCup10 :
                {
                    int[] cupIdThing = new int [4]
                    {4, 6, 8, 9};
                    int cupId = cupIdThing[achievementId - (int)Profile.Enum2.kAchievement_UnlockableCup5];
                    int levelThatNeedsToBeUnlocked = cupId * 8;
                    if (!this.IsLevelUnlocked(levelThatNeedsToBeUnlocked)) {
                        string outDescription = String.Format("Cup %d‐キャンプ場をアンロックできるぞ！", cupId + 1, (cup[cupId]).
                          name);
                        return outDescription;
                    }
                    else {
                        string outDescription = String.Format("Cup %d‐キャンプ場をアンロックできるぞ！", cupId + 1, (cup[cupId]).
                          name);
                        return outDescription;
                    }

                }
                
            case Profile.Enum2.kAchievement_CompletedCup1 :
            case Profile.Enum2.kAchievement_CompletedCup2 :
            case Profile.Enum2.kAchievement_CompletedCup3 :
            case Profile.Enum2.kAchievement_CompletedCup4 :
            case Profile.Enum2.kAchievement_CompletedCup5 :
            case Profile.Enum2.kAchievement_CompletedCup6 :
            case Profile.Enum2.kAchievement_CompletedCup7 :
            case Profile.Enum2.kAchievement_CompletedCup8 :
            case Profile.Enum2.kAchievement_CompletedCup9 :
            case Profile.Enum2.kAchievement_CompletedCup10 :
                {
                    int cupId = achievementId - (int)Profile.Enum2.kAchievement_CompletedCup1;
                    string outDescription = String.Format("%@でリンゴを２４個集める", (cup[cupId]).name);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_RecordBreaker_CurlyWurly :
            case Profile.Enum2.kAchievement_RecordBreaker_MudVille :
            case Profile.Enum2.kAchievement_RecordBreaker_CowField :
            case Profile.Enum2.kAchievement_RecordBreaker_LongJumps :
            case Profile.Enum2.kAchievement_RecordBreaker_FourRivers :
            case Profile.Enum2.kAchievement_RecordBreaker_LongRoof :
            case Profile.Enum2.kAchievement_RecordBreaker_PumpkinWiggle :
            case Profile.Enum2.kAchievement_RecordBreaker_CampSite :
            case Profile.Enum2.kAchievement_RecordBreaker_HOW :
            case Profile.Enum2.kAchievement_RecordBreaker_Junkyard :
            case Profile.Enum2.kAchievement_RecordBreaker_GetUp :
            case Profile.Enum2.kAchievement_RecordBreaker_BridgeJump :
            case Profile.Enum2.kAchievement_RecordBreaker_RainbowRuns :
            case Profile.Enum2.kAchievement_RecordBreaker_TulipChicane :
                {
                    int whichLevel = breakerLevel[achievementId];
                    string levelName = this.GetLevelNameStringWithoutNewline(whichLevel);
                    string outDescription = String.Format("「%@」で%.2f秒を破れ！", levelName, breakerTime[whichLevel]);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_Hit30Rainbows :
                return "一つのレースで３０のブーストをヒット！";
                
            case Profile.Enum2.kAchievement_HitAppleTree :
                return "リンゴを木から叩き落とせ！";
                
            case Profile.Enum2.kAchievement_Hit5AppleTrees :
                return "リンゴを５個叩き落としてレベルをクリアしろ！";
                
            case Profile.Enum2.kAchievement_PigPush :
                return "レース１で豚を押して池に落とせ！";
                
            case Profile.Enum2.kAchievement_Beat1Pig :
                return "豚に勝て！";
                
            case Profile.Enum2.kAchievement_Beat3Pigs :
                return "すべての豚に勝て！";
                
            case Profile.Enum2.kAchievement_HighFlier :
                return "レース２４、空中で豚をオーバーテイクしろ！";
                
            case Profile.Enum2.kAchievement_RoofRunner :
                return "屋根の上に０．５秒留まれ！";
                
            case Profile.Enum2.kAchievement_SpeedBoost :
                return "スピードブーストを使え！";
                
            case Profile.Enum2.kAchievement_ShirleyThump :
                return "フルスピードでシャーリーに突っ込め！";
                
            case Profile.Enum2.kAchievement_CreateTrack :
                return "最初のトラックをつくれ！";
                
            case Profile.Enum2.kAchievement_WeaveMagic :
                return "他のひつじにあたる事なく「ちゃんとヒツジなさい！」をクリアしろ！";
                
            case Profile.Enum2.kAchievement_DryDucks :
                return "濡れる事無く「アヒル池を駆け抜けろ」をクリアしろ！";
                
            case Profile.Enum2.kAchievement_BarrelMaze :
                return "樽に当たらず「バレル・ラムページ」をクリアしろ！";
                
            case Profile.Enum2.kAchievement_PassDayDreamNoFlowers :
                return "花を避けつつ「トランス・パニック」をクリアしろ！";
                
            case Profile.Enum2.kAchievement_PassVegDodgeNoVeg :
                return "「野菜を避けろ」を野菜を回避しながらクリアしろ！";
                
            case Profile.Enum2.kAchievement_PassSquashDodgeNoVeg :
                return "「豚スプリント」を野菜を回避しながらクリアしろ！";
                
            case Profile.Enum2.kAchievement_PassPCurvyNoFlock :
                return "「メェェェラソン」を他のひつじを避けつつクリアしろ！";
                
            case Profile.Enum2.kAchievement_PassMigrationNoMud :
                return "「刈り入れ時」を泥だらけにならずクリアしろ！";
                
            case Profile.Enum2.kAchievement_PassRoadSheepNoSheep :
                return "「豚ロード」をすべてのひつじを回避してクリアしろ！";
                
            case Profile.Enum2.kAchievement_PassMudvilleNoHouse :
                return "「泥地」を建物を避けつつクリアしろ！";
                
            case Profile.Enum2.kAchievement_PassMazyDazyNoHedge :
                return "「くねくね　ふらふら」を囲いにあたる事なくクリアしろ！";
                
            case Profile.Enum2.kAchievement_WinSnowForestNoTrees :
                return "「森」を木にぶつかる事無くクリアしろ！";
                
            case Profile.Enum2.kAchievement_WinHogzwallopNotWet :
                return "「綿毛の洗濯」を濡れる事無くクリアしろ！";
                
            case Profile.Enum2.kAchievement_WinPumpkinJumpsNoPumpkins :
                return "「パンプキン・ジャンプ」をカボチャを避けつつクリアしろ！";
                
            case Profile.Enum2.kAchievement_WinTrottervilleNoHouse :
                return "「トロッターヴィル」を建物に当たる事無くクリアしろ！";
                
            }

            return null;
        }

        public string GetAchievementDescriptionGerman(int achievementId)
        {
            switch ((Profile.Enum2)achievementId) {
            case Profile.Enum2.kAchievement_UnlockableCup5 :
            case Profile.Enum2.kAchievement_UnlockableCup7 :
            case Profile.Enum2.kAchievement_UnlockableCup9 :
            case Profile.Enum2.kAchievement_UnlockableCup10 :
                {
                    int[] cupIdThing = new int [4]
                    {4, 6, 8, 9};
                    int cupId = cupIdThing[achievementId - (int)Profile.Enum2.kAchievement_UnlockableCup5];
                    int levelThatNeedsToBeUnlocked = cupId * 8;
                    if (!this.IsLevelUnlocked(levelThatNeedsToBeUnlocked)) {
                        string outDescription = String.Format("Cup %d – %@ kann nun freigeschaltet werden!", cupId + 1, (cup[cupId]).name);
                        return outDescription;
                    }
                    else {
                        string outDescription = String.Format("Cup %d – %@ kann nun freigeschaltet werden!", cupId + 1, (cup[cupId]).name);
                        return outDescription;
                    }

                }
                
            case Profile.Enum2.kAchievement_CompletedCup1 :
            case Profile.Enum2.kAchievement_CompletedCup2 :
            case Profile.Enum2.kAchievement_CompletedCup3 :
            case Profile.Enum2.kAchievement_CompletedCup4 :
            case Profile.Enum2.kAchievement_CompletedCup5 :
            case Profile.Enum2.kAchievement_CompletedCup6 :
            case Profile.Enum2.kAchievement_CompletedCup7 :
            case Profile.Enum2.kAchievement_CompletedCup8 :
            case Profile.Enum2.kAchievement_CompletedCup9 :
            case Profile.Enum2.kAchievement_CompletedCup10 :
                {
                    int cupId = achievementId - (int)Profile.Enum2.kAchievement_CompletedCup1;
                    string outDescription = String.Format(" Sammle 24 Äpfel bei %@!", (cup[cupId]).name);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_RecordBreaker_CurlyWurly :
            case Profile.Enum2.kAchievement_RecordBreaker_MudVille :
            case Profile.Enum2.kAchievement_RecordBreaker_CowField :
            case Profile.Enum2.kAchievement_RecordBreaker_LongJumps :
            case Profile.Enum2.kAchievement_RecordBreaker_FourRivers :
            case Profile.Enum2.kAchievement_RecordBreaker_LongRoof :
            case Profile.Enum2.kAchievement_RecordBreaker_PumpkinWiggle :
            case Profile.Enum2.kAchievement_RecordBreaker_CampSite :
            case Profile.Enum2.kAchievement_RecordBreaker_HOW :
            case Profile.Enum2.kAchievement_RecordBreaker_Junkyard :
            case Profile.Enum2.kAchievement_RecordBreaker_GetUp :
            case Profile.Enum2.kAchievement_RecordBreaker_BridgeJump :
            case Profile.Enum2.kAchievement_RecordBreaker_RainbowRuns :
            case Profile.Enum2.kAchievement_RecordBreaker_TulipChicane :
                {
                    int whichLevel = breakerLevel[achievementId];
                    string levelName = this.GetLevelNameStringWithoutNewline(whichLevel);
                    string outDescription = String.Format("Sei schneller als %.2f Sekunden bei %@!", breakerTime[whichLevel], levelName);
                    return outDescription;
                }
                
            case Profile.Enum2.kAchievement_Hit30Rainbows :
                return "Triff 30 Schübe in einem Rennen!";
                
            case Profile.Enum2.kAchievement_HitAppleTree :
                return "Lass die Äpfel von einem Baum fallen!";
                
            case Profile.Enum2.kAchievement_Hit5AppleTrees :
                return "Lass die Äpfel von 5 Bäumen hinabfallen und schließe ein Level ab!";
                
            case Profile.Enum2.kAchievement_PigPush :
                return "Schubse das Schwein in den Teich und gewinne das Rennen 1!";
                
            case Profile.Enum2.kAchievement_Beat1Pig :
                return "Schlage das Schwein beim Torlauf!";
                
            case Profile.Enum2.kAchievement_Beat3Pigs :
                return "Schlage alle Schweine beim Torlauf!";
                
            case Profile.Enum2.kAchievement_HighFlier :
                return "Überhole ein Schwein in der Luft beim Rennen 24!";
                
            case Profile.Enum2.kAchievement_RoofRunner :
                return "Bleibe eine halbe Sekunde lang auf dem Dach!";
                
            case Profile.Enum2.kAchievement_SpeedBoost :
                return "Triff einen Sauseschub!";
                
            case Profile.Enum2.kAchievement_ShirleyThump :
                return "Laufe mit voller Geschwindigkeit in Shirley rein!";
                
            case Profile.Enum2.kAchievement_CreateTrack :
                return "Erstelle deine erste Strecke!";
                
            case Profile.Enum2.kAchievement_WeaveMagic :
                return "Gewinne Woll in Form und weiche anderen Schafen aus!";
                
            case Profile.Enum2.kAchievement_DryDucks :
                return "Gewinne Flink wie eine Ente und bleib trocken!";
                
            case Profile.Enum2.kAchievement_BarrelMaze :
                return "Gewinne Fässer-Bockspringen und weiche den Fässern aus!";
                
            case Profile.Enum2.kAchievement_PassDayDreamNoFlowers :
                return "Schließe Tulpentrance ab und weiche den Blumen aus!";
                
            case Profile.Enum2.kAchievement_PassVegDodgeNoVeg :
                return "Schließe Kürbiskrieg ab und weiche dem Gemüse aus!";
                
            case Profile.Enum2.kAchievement_PassSquashDodgeNoVeg :
                return "Schließe Schweinesprint ab und weiche dem Gemüse aus!";
                
            case Profile.Enum2.kAchievement_PassPCurvyNoFlock :
                return "Schließe Mäh-rathon ab und weiche anderen Schafen aus!";
                
            case Profile.Enum2.kAchievement_PassMigrationNoMud :
                return "Schließe Die Wanderung ab, ohne schmutzig zu werden!";
                
            case Profile.Enum2.kAchievement_PassRoadSheepNoSheep :
                return "Schließe Verkehrsschwein ab und weiche allen Schafen aus!";
                
            case Profile.Enum2.kAchievement_PassMudvilleNoHouse :
                return "Schließe Schlammheim ab und weiche den Gebäuden aus!";
                
            case Profile.Enum2.kAchievement_PassMazyDazyNoHedge :
                return "Schließe Kreuz und quer ab, ohne eine Hecke zu treffen!";
                
            case Profile.Enum2.kAchievement_WinSnowForestNoTrees :
                return "Gewinne Die Wälder und weiche Bäumen aus!";
                
            case Profile.Enum2.kAchievement_WinHogzwallopNotWet :
                return "Gewinne Wollwäsche, ohne nass zu werden!";
                
            case Profile.Enum2.kAchievement_WinPumpkinJumpsNoPumpkins :
                return "Gewinne Kürbismatsch und weiche Kürbissen aus!";
                
            case Profile.Enum2.kAchievement_WinTrottervilleNoHouse :
                return "Gewinne Hachsenheim und weiche den Gebäuden aus!";
                
            }

            return null;
        }

        bool AchievementForFacebook(int achievementId)
        {
            switch ((Profile.Enum2)achievementId) {
            case Profile.Enum2.kAchievement_Beat1Pig :
            case Profile.Enum2.kAchievement_HitAppleTree :
            case Profile.Enum2.kAchievement_SpeedBoost :
            case Profile.Enum2.kAchievement_Beat3Pigs :
                return false;
                
            }

            return true;
        }

        public bool HasAchievementBeenSeen (int achId)
		{
			Globals.Assert (achId < (int)Enum2.kNumAchievements);
            return profileInfo.achievementSeen[achId];
        }

        public void FlushPendingAchievements ()
		{
			if (numPendingAchievements == 0) {
				return;
			}

			Globals.Assert (numPendingAchievements > 0);
			Globals.Assert (numPendingAchievements <= (int)Enum6.kMaxPendingAchievements);
            bool updateProfileInfo = false;
            for (int i = 0; i < numPendingAchievements; i++) 
			{
				string gameCenterStringId = this.GetAchievementStringId(pendingAchievementsId[i]);

								GameCenterWrapper.ReportAchievement(gameCenterStringId);

               // #if USE_CRYSTAL



                    {
//                        if (this.AchievementForFacebook(pendingAchievementsId[i])) {
//                            Globals.g_world.FaceBookPostAchievement(pendingAchievementsId[i]);
//                        }

//                        profileInfo.achievementSeen[pendingAchievementsId[i]] = true;
//                        updateProfileInfo = true;
                    }
               // #endif

								if (!profileInfo.achievementSeen[pendingAchievementsId[i]])
								{
										//Globals.g_achievementQueue.ShowAchievement((Profile.Enum2)pendingAchievementsId[i]);
										profileInfo.achievementSeen[pendingAchievementsId[i]] = true;
								}

								updateProfileInfo = true;

            }

            numPendingAchievements = 0;
            if (updateProfileInfo) {
                this.SaveBestTimesAndPrefs();
            }

        }

        public float GetRecordBreakerTimes(int inPlayingLevel)
        {
            Globals.Assert(inPlayingLevel < Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES);
            return breakerTime[inPlayingLevel];
        }

        public void CheckRecordBreakerP1(float inTime, int inLevel)
        {
            Globals.Assert(inLevel < Constants.NUM_LEVELS_IN_CUPS_PLUS_BONUSES);
            if (breakerTime[inLevel] > 0.0f) {
                if (inTime <= breakerTime[inLevel]) {
                    switch (LevelBuilder_Ross.levelOrder[inLevel]) {
                    case (int)LevelBuilder_Ross.Enum2.kGrass1_8_MdwCup_Race8_CowField :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_CowField);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kMud_LongJumps :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_LongJumps);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kMud_MudVille :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_MudVille);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_CurlyWurly);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kGrass9_4_FourRivers :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_FourRivers);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kMud2_4_MudCup_Race4_LongRoof :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_LongRoof);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kMud8_5_PumpkinWiggle :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_PumpkinWiggle);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kGrass9_5_Campyard :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_CampSite);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kGrass4_5_CntCup_Race5_HOW :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_HOW);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kMud7_4_Junkyard :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_Junkyard);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kMud5_2_FrmCup_Race2_GetUp :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_GetUp);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kGrass8_7_BridgeJumps :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_BridgeJump);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kGrassN2_3_RainbowRuns :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_RainbowRuns);
                        break;
                    case (int)LevelBuilder_Ross.Enum2.kMud8_4_TulipChicane :
                        this.QueueAchievement(Profile.Enum2.kAchievement_RecordBreaker_TulipChicane);
                        break;
                    }

                }

            }

        }

        public string GetAchievementStringId(int achievementId)
        {
            switch ((Profile.Enum2)achievementId) {
            case Profile.Enum2.kAchievement_Beat1Pig :
                return "2424880721";
                
            case Profile.Enum2.kAchievement_HighFlier :
                return "2425309671";
                
            case Profile.Enum2.kAchievement_SpeedBoost :
                return "2425365723";
                
            case Profile.Enum2.kAchievement_Beat3Pigs :
                return "2425416164";
                
            case Profile.Enum2.kAchievement_RoofRunner :
                return "2425360501";
                
            case Profile.Enum2.kAchievement_ShirleyThump :
                return "2425404120";
                
            case Profile.Enum2.kAchievement_HitAppleTree :
                return "2470718228";
                
            case Profile.Enum2.kAchievement_PigPush :
                return "2495051798";
                
            case Profile.Enum2.kAchievement_Hit30Rainbows :
                return "2429600145";
                
            case Profile.Enum2.kAchievement_Hit5AppleTrees :
                return "2470683790";
                
            case Profile.Enum2.kAchievement_CreateTrack :
                return "2394603657";
                
            case Profile.Enum2.kAchievement_UnlockableCup5 :
                return "2425411214";
                
            case Profile.Enum2.kAchievement_UnlockableCup7 :
                return "2425341737";
                
            case Profile.Enum2.kAchievement_UnlockableCup9 :
                return "2394736008";
                
            case Profile.Enum2.kAchievement_UnlockableCup10 :
                return "2394736018";
                
            case Profile.Enum2.kAchievement_DryDucks :
                return "2425293982";
                
            case Profile.Enum2.kAchievement_BarrelMaze :
                return "2425480125";
                
            case Profile.Enum2.kAchievement_PassMudvilleNoHouse :
                return "2429448235";
                
            case Profile.Enum2.kAchievement_PassVegDodgeNoVeg :
                return "2429340726";
                
            case Profile.Enum2.kAchievement_PassDayDreamNoFlowers :
                return "2429298590";
                
            case Profile.Enum2.kAchievement_WeaveMagic :
                return "2425484034";
                
            case Profile.Enum2.kAchievement_PassPCurvyNoFlock :
                return "2429452497";
                
            case Profile.Enum2.kAchievement_PassMazyDazyNoHedge :
                return "2480694209";
                
            case Profile.Enum2.kAchievement_PassMigrationNoMud :
                return "2429489384";
                
            case Profile.Enum2.kAchievement_WinSnowForestNoTrees :
                return "2429495601";
                
            case Profile.Enum2.kAchievement_PassRoadSheepNoSheep :
                return "2480403990";
                
            case Profile.Enum2.kAchievement_WinHogzwallopNotWet :
                return "2429440590";
                
            case Profile.Enum2.kAchievement_WinPumpkinJumpsNoPumpkins :
                return "2429430465";
                
            case Profile.Enum2.kAchievement_PassSquashDodgeNoVeg :
                return "2429498464";
                
            case Profile.Enum2.kAchievement_WinTrottervilleNoHouse :
                return "2429539123";
                
            case Profile.Enum2.kAchievement_RecordBreaker_CowField :
                return "2425876019";
                
            case Profile.Enum2.kAchievement_RecordBreaker_LongJumps :
                return "2429482140";
                
            case Profile.Enum2.kAchievement_RecordBreaker_MudVille :
                return "2425760736";
                
            case Profile.Enum2.kAchievement_RecordBreaker_FourRivers :
                return "2429496078";
                
            case Profile.Enum2.kAchievement_RecordBreaker_CurlyWurly :
                return "2394622877";
                
            case Profile.Enum2.kAchievement_RecordBreaker_PumpkinWiggle :
                return "2429416775";
                
            case Profile.Enum2.kAchievement_RecordBreaker_HOW :
                return "2429363933";
                
            case Profile.Enum2.kAchievement_RecordBreaker_CampSite :
                return "2429398715";
                
            case Profile.Enum2.kAchievement_RecordBreaker_RainbowRuns :
                return "2429374532";
                
            case Profile.Enum2.kAchievement_RecordBreaker_TulipChicane :
                return "2429515044";
                
            case Profile.Enum2.kAchievement_RecordBreaker_Junkyard :
                return "2429508025";
                
            case Profile.Enum2.kAchievement_RecordBreaker_BridgeJump :
                return "2429498199";
                
            case Profile.Enum2.kAchievement_RecordBreaker_LongRoof :
                return "2429406757";
                
            case Profile.Enum2.kAchievement_RecordBreaker_GetUp :
                return "2429442658";
                
            case Profile.Enum2.kAchievement_CompletedCup1 :
                return "2394613774";
                
            case Profile.Enum2.kAchievement_CompletedCup2 :
                return "2425427293";
                
            case Profile.Enum2.kAchievement_CompletedCup3 :
                return "2425109875";
                
            case Profile.Enum2.kAchievement_CompletedCup4 :
                return "2425458007";
                
            case Profile.Enum2.kAchievement_CompletedCup5 :
                return "2425307896";
                
            case Profile.Enum2.kAchievement_CompletedCup6 :
                return "2425300932";
                
            case Profile.Enum2.kAchievement_CompletedCup7 :
                return "2425433245";
                
            case Profile.Enum2.kAchievement_CompletedCup8 :
                return "2424777867";
                
            case Profile.Enum2.kAchievement_CompletedCup9 :
                return "2425328483";
                
            case Profile.Enum2.kAchievement_CompletedCup10 :
                return "2425374344";
                
            }

            return "";
        }

        public void QueueAchievement (Enum2 achievementId)
		{

			#if DEBUG_MESSAGES
                string inAchievementId = this.GetAchievementStringId(achievementId);
			#endif

			if (numPendingAchievements < (int)Enum6.kMaxPendingAchievements) {
                pendingAchievementsId[numPendingAchievements] = (int)achievementId;
                numPendingAchievements++;
            }

        }

        public void UpdateFeelGoodP1P2 (int playingLevel, bool gotNewApple, int numApplesBeforeRace)
		{
			if (playingLevel < (int)(Profile.Enum6.kNumLevels - Profile.Enum6.kNumBonusLevels)) {
				int stage = this.GetCupFromLevel (playingLevel);
				if (((Globals.g_world.frontEnd).profile).GetNumApples (stage) == 24) {
					this.QueueAchievement (Profile.Enum2.kAchievement_CompletedCup1 + stage);
				}

			}

			int levelToUnlock = playingLevel + 1;
			if (false) {
			} else {
				Globals.Assert ((int)Profile.Enum6.kNumLevelsPerCup == 8);
                if (levelToUnlock % 8 == 0) {
                    if (numApplesBeforeRace == 0) {
                        int stage = this.GetCupFromLevel(playingLevel);
                        profileInfo.feelGoodProgress = (int)Enum5.kFeelGoodProgress_PassedCup1 + stage;
                        profileInfo.feelGoodScreenPending = true;
                        return;
                    }

                }

            }

        }

        public float GetBestTimeP1 (BestTimeSet inSet, int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            Globals.Assert(inSet <  BestTimeSet.eSets);
            return (((float)(notSavedInfo.level[(int)level].bestTime[(int)inSet])) / 1000.0f);
        }

        public float GetCurrentBestTime(int level)
        {
            return this.GetBestTimeP1(this.GetRelevantBestTimeSet(), level);
        }

        public int GetCupFromLevel (int levelId)
		{
			for (int i = 0; i < (int)Enum4.kNumCups; i++) {
				if (levelId < ((int)Profile.Enum6.kNumLevelsPerCup * (i + 1))) {
                    return i;
                }

            }

            return -1;
        }

        public Constants.RossColour GetLevelColour (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
			if (level == (((int)Profile.Enum6.kNumLevelsPerCup * (int)Enum4.kNumCups) + 0)) {
				return Constants.kColourYellow;
			} else if (level == (((int)Profile.Enum6.kNumLevelsPerCup * (int)Enum4.kNumCups) + 1)) {
				return Constants.kColourLightblue;
			} else if (level == (((int)Profile.Enum6.kNumLevelsPerCup * (int)Enum4.kNumCups) + 2)) {
				return Constants.kColourLilac;
			} else {
				Globals.Assert (level < ((int)Profile.Enum6.kNumLevelsPerCup * (int)Enum4.kNumCups));
                int cupId = this.GetCupFromLevel(level);
                Globals.Assert(cupId < (int)Enum4.kNumCups);
                return (cup[cupId]).levelColour;
            }

            return Constants.kColourLilac;
        }

        public string GetLevelName (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            int editorLevel = LevelBuilder_Ross.levelOrder[(int)level];
            Globals.Assert(LevelBuilder_Ross.kDesignPhase100 <= 500);
            if (editorLevel >= 500) {
                editorLevel -= (500 - 120);
            }
            else if (editorLevel >= 400) {
                editorLevel -= (400 - 96);
            }
            else if (editorLevel >= 300) {
                editorLevel -= (300 - 72);
            }
            else if (editorLevel >= 200) {
                editorLevel -= (200 - 48);
            }
            else if (editorLevel >= 100) {
                editorLevel -= (100 - 24);
            }

            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                return outLevelNameGerman[(int)level];
            }

            return outLevelName[editorLevel];
        }

        public string GetLevelName_Chinese(int level)
        {
            string[] nameArray = new string [80]
            {"简单的任务", "哞哞", "猪锥", "桥上咩咩", "公园散步", "冲篱笆", "牛群跳栏", "鸭池冲刺", "滑泥地", "马厩快跑",
                  "小鸡大恐慌", "冲撞酒桶", "蔬菜线", "莫德威", "葫芦混乱", "情迷郁金香", "桥上快跑", "无尽的桥", "东倒西歪"
                  , "小羊之家", "烧尽", "伟大的一跳", "河流大恐慌", "迂回小径", "井然有序", "蹦床", "雪莉的小地",
                  "一桶桶的欢乐", "疯狂羊毛剪", "障碍赛道", "南瓜地", "南瓜游行", "奇迹之蹄", "羊的交通", "彩虹力量", "营地"
                  , "湿湿湿", "草草打算", "四处受限", "混乱水塘", "马拉松", "谷仓之舞", "疯狂之花", "泥地陷阱", "小巷之猪",
                  "房屋栋栋", "拖拉机因素", "垃圾场", "果园", "地精像陷阱", "摇晃木马", "坡道特技", "森林小道", "绵羊快跑",
                  "木头人", "肮脏的草原", "酒桶风波", "迁徙", "森林羊群", "蛋头先生", "猪院", "丛林", "小鸡飞飞", "兜风",
                  "小羊跨栏赛", "猪言猪语", "羊毛衫", "避开障碍", "路霸", "地精像之路", "洗羊毛", "飞羊群", "收获", "猪堆",
                  "起飞", "马厩之星", "丢南瓜", "小猪快跑", "奇妙拖拉机", "特洛特威尔"};
            return nameArray[(int)level];
        }

        public string GetLevelName_Japanese(int level)
        {
            string[] nameArray = new string [80]
            {"簡単だぜ", "モーモー", "豚コーン", "遠すぎたメェェ", "遊歩道", "イグサの囲い", "ハードル群",
                  "アヒル池を駆け抜けろ", "泥ドリフト", "安定した走り", "チキン・パニック", "バレル・ラムページ",
                  "野菜のウネ", "泥地", "ペポカボチャの大騒ぎ", "チューリップに夢中", "ブリッジ・スプリント", "永遠の橋"
                  , "ラム・シャックル", "イエイ！羊！イエイ！", "火花のターン", "大ジャンプ", "リバー・パニック",
                  "周り道", "ちゃんとヒツジなさい", "トランポリン・ターン", "シャーリーのテリトリー", "バケツの楽しみ"
                  , "凶器の沙汰", "障害コース", "カボチャ園", "カボチャのパレード", "信じられないヒヅメ", "ひつじの渋滞"
                  , "虹の力", "キャンプ場", "濡れ濡れ", "ヒヅメの上で", "まわれー右！", "水たまりのプール",
                  "メェェェラソン", "熱いダンス", "情熱の花", "泥のワナ", "豚の小道", "ハウス・ブロック",
                  "トラクター・ファクター", "ジャンクヤード", "果樹園", "ノーム・トラップ", "でこぼこ道",
                  "スロープに乗っかれ", "森の道", "ひつじの爆走", "くねくね、ふらふら", "豚の牧場", "樽の息吹",
                  "移動する動物の群", "生い茂った森", "ハンプティ・ジャンプティー", "養豚場", "森", "チキンファイト",
                  "屋根を走る", "障害物競羊？！", "ばかな豚", "綿毛ジャンパー", "ヘッジ・シャッフル", "豚ロード",
                  "ノーム・ウェイ", "綿毛の洗濯", "空飛ぶ群れ", "刈り入れ時", "積み重なった豚", "打ち上げ",
                  "スター競走馬", "カボチャ潰し", "豚スプリント", "トリッキー・トラクター", "トロッターヴィル"};
            return nameArray[(int)level];
        }
		
		
		public string GetLevelName_French(int level)
        {
            string[] nameArray = new string [80]
			{
				"Facile",
				"Meuuh",
				"Cône de porc",
				"Le pont",
				"Promenade dans le parc",
				"Course de haies",
				"Troupeau en folie",
				"Marre de la mare",

				"Glissement de terrain",
				"Sprint des écuries",
				"Panique chez les poulets",
				"Tonneau du tonneau",
				"Rangées de légumes",
				"Vaseville",
				"Chaos chez les courgettes",
				"Transe des tulipes",

				"Sprint sur le pont",
				"Les ponts pour toujours",
				"Beau bélier",
				"Mou, le mouton",
				"On brûle les étapes",
				"Le grand saut",
				"Panique sur les eaux",
				"Détour",

				"Dessine-moi un mouton",
				"Trampoline",
				"Le carré de Shirley",
				"Des tonneaux de rigolade",
				"Pure folie",
				"Course d’obstacles",
				"Carré de citrouilles",
				"La parade",

				"Les sabots du bonheur",
				"Ça bouchonne",
				"Arc-en-ciel",
				"Le campement",
				"Ça mouille",
				"Sur la pointe des sabots",
				"On taille",
				"Mares de flaques",

				"Bêêê-rathon",
				"Allez on danse",
				"Folie de fleurs",
				"Piège boueux",
				"Porcs en cavale",
				"Pâté de maisons",
				"Facteur tracteur",
				"La casse",

				"Le verger",
				"Piège de gnome",
				"Ça secoue",
				"Sur les rampes",
				"Chemin forestier",
				"Sprint de moutons",
				"Le labyrinthe",
				"Le pré des porcs",

				"Brise",
				"La migration",
				"Nuée forestière",
				"Badaboum",
				"La porcherie",
				"Les bois",
				"Vol de poulets",
				"Course sur les toits",

				"Chasse au mouton",
				"Coup de main",
				"Laine tomber",
				"Dans la haie",
				"Porc en vue",
				"À la gnome",
				"Mode laine",
				"Volée volante",

				"La récolte",
				"Montagne de cochons",
				"Décollage",
				"Star des écuries",
				"Purée de citrouille",
				"Sprint des porcs",
				"Tracteurs tricheurs",
				"Totteurville",

			};
			
			return nameArray[(int)level];
        }
		
        string GetLevelName_NSString(int level)
        {
            switch (Globals.g_currentLanguage) {
            case World.Enum11.kLanguage_China :
                return this.GetLevelName_Chinese(level);
                break;
            case World.Enum11.kLanguage_Japanese :
                return this.GetLevelName_Japanese(level);
                break;
            case World.Enum11.kLanguage_French :
                return this.GetLevelName_French(level);
                break;
            default :
                Globals.Assert(false);
                break;
            }

            return "";
        }

        public string GetLevelNameString(int level)
        {
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                return this.GetLevelName_NSString(level);
            }

            string name = this.GetLevelName(level);
            return name;
        }

        public string GetLevelNameStringWithoutNewlineAndWithoutExclamation(int level)
        {
            string name = this.GetLevelName(level);
//            int blah = strlen(name);
			string nameShorter;// = new char[32];
            nameShorter = name;
//            nameShorter[blah - 1] = '\n';
  //          nameShorter[blah] = ' ';
			return  nameShorter;// NSString.StringWithUTF8String(nameShorter);
        }

        public string GetLevelNameStringWithoutNewline(int level)
        {
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                return this.GetLevelNameString(level);
            }

            string name = this.GetLevelName(level);
//            int blah = strlen(name);
			string nameShorter;// = new char[32];

			nameShorter = name;
			return name;// NSString.StringWithUTF8String(nameShorter);
        }

        public void UpdateNumApples ()
		{
			for (int i = 0; i < (int)Enum4.kNumCups; i++)
				numApples [i] = 0;

			for (int level = 0; level < (int)Profile.Enum6.kNumLevelsNotBonus; level++) {
                int cupId = this.GetCupFromLevel(level);
                numApples[cupId] += (int)Utilities.GetNumApplesFromTrophy((int)profileInfo.level[(int)level].gotTrophy);
            }

        }

        public void UpdateSpeedUpProgress ()
		{
			int[] numLevelsForSpeedUp = new int [(int)SpeedUpProgressEnum.kNumSpeedUps]
            {0, 0, 0, 0};
			int numLevelsWithTrophy = 0;
			for (int level = 0; level < (int)Profile.Enum6.kNumLevelsNotBonus; level++) {
                if (profileInfo.level[(int)level].gotTrophy != TrophyType.kTrophy_NotGot) {
                    numLevelsWithTrophy++;
                }

            }

            for (int i = 0; i < (int) SpeedUpProgressEnum.kNumSpeedUps; i++) {
                if (numLevelsWithTrophy >= numLevelsForSpeedUp[i]) {
                    speedUpProgress = (SpeedUpProgressEnum)i;
                }

            }

            if ((int)speedUpProgress < profileInfo.minimumSpeedupProgress) {
                speedUpProgress = (SpeedUpProgressEnum)profileInfo.minimumSpeedupProgress;
            }
            else if ((int)speedUpProgress > profileInfo.minimumSpeedupProgress) {
                profileInfo.minimumSpeedupProgress = (int)speedUpProgress;
            }

        }

        public void CheckPassedCupP1 (int cupId, int justPlayedLevel)
		{
			Globals.Assert (cupId < (int)Enum4.kNumCups);
			int levMin = cupId * 8;
			int levMax = 7 + (cupId * 8);
			Globals.Assert (levMax < (int)Profile.Enum6.kNumLevels);
            if ((justPlayedLevel < levMin) || (justPlayedLevel > levMax)) {
                return;
            }

            for (int level = levMin; level <= levMax; level++) {
                if (profileInfo.level[(int)level].gotTrophy == TrophyType.kTrophy_NotGot) {
                    return;
                }

            }

        }

        public void CheckBonusLevelIsVisibleP1P2P3(int justPlayedLevel, int bonusLevelId, int levMin, int levMax)
        {
            bool isVisible = true;
            for (int level = levMin; level <= levMax; level++) {
                if (profileInfo.level[(int)level].gotTrophy == TrophyType.kTrophy_NotGot) {
                    isVisible = false;
                    break;
                }

            }

            if ((isVisible) || (Constants.UNLOCK_ALL_LEVELS)) {
                this.SetLevelVisibleP1(bonusLevelId, true);
                this.SetLevelUnlockedP1(bonusLevelId, true);
            }

        }

        public void UpdateLevelVisibility (int justPlayedLevel)
		{
			for (int level = 0; level < (int)Profile.Enum6.kNumLevels; level++) {
				if (level < ((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup))
					this.SetLevelVisibleP1 (level, true);
				else
					this.SetLevelVisibleP1 (level, false);

			}

			this.CheckBonusLevelIsVisibleP1P2P3 (
				justPlayedLevel,
				((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup), 0, 7);
			this.CheckBonusLevelIsVisibleP1P2P3 (
				justPlayedLevel,
				(((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) + 1), 8, 15);
			this.CheckPassedCupP1 ((int)Enum4.kCupMeadow, justPlayedLevel);

			#if !LITE_VERSION
			this.CheckPassedCupP1 ((int)Enum4.kCupMud, justPlayedLevel);
			this.CheckPassedCupP1 ((int)Enum4.kCupCountryside, justPlayedLevel);
			this.CheckPassedCupP1 ((int)Enum4.kCupFarmyard, justPlayedLevel);
			this.CheckPassedCupP1 ((int)Enum4.kCupStar, justPlayedLevel);
			#endif

			this.CheckBonusLevelIsVisibleP1P2P3 (
				justPlayedLevel,
				(((int)Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) + 2), 16, 23);
        }

        public int GetNumApplesOnLevel (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            if (profileInfo.level[(int)level].gotTrophy == TrophyType.kTrophy_NotGot) return 0;
            else {
                return 3 - (int)profileInfo.level[(int)level].gotTrophy;
            }

        }

        public int GetTotalNumberOfApples()
        {
            int howManyApples = 0;
            for (int i = 0; i < (int)Enum4.kNumCups; i++) {
                howManyApples += this.GetNumApples(i);
            }

            return howManyApples;
        }

        public TrophyType GetTrophyGot (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            return profileInfo.level[(int)level].gotTrophy;
        }

        public bool IsLevelVisible (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            return levelVisible[(int)level];
        }

        public bool SetLevelVisibleP1 (int level, bool isVisible)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            return levelVisible[(int)level] = isVisible;
        }

        public bool IsLevelUnlocked (int level)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            return profileInfo.level[(int)level].levelUnlocked;
        }

        public void SetLevelUnlockedP1 (int level, bool isUnlocked)
		{
			Globals.Assert (level < (int)Profile.Enum6.kNumLevels);
            profileInfo.level[(int)level].levelUnlocked = isUnlocked;
            this.UpdateSpeedUpProgress();
        }

    }
}
