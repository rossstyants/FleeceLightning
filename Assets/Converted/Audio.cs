using System;
using System.Collections;

namespace Default.Namespace
{
    public class Audio
    {
        public bool birdsOn;
        public int currentlyLoadedScene;
        public int currentlyLoadedOpponent;
        public int tractorSoundId;
        public int numOpponentSounds;
        public int numSheepSounds;
        public enum Enum {
            kMaxPendingFinchSounds = 100
        };
		
        public enum  Enum1 {
            kSoundEffect_ButtonPress = 0,
            kSoundEffect_BaaImpact1,
            kSoundEffect_BaaImpact2,
            kSoundEffect_BaaImpact3,
            kSoundEffect_Baa1,
            kSoundEffect_Baa2,
            kSoundEffect_Baa3,
            kSoundEffect_Baa4,
            kSoundEffect_Baa5,
            kSoundEffect_BaaLaugh1,
            kSoundEffect_BaaLaugh2,
            kSoundEffect_BaaLaugh3,
            kSoundEffect_BaaLaugh4,
            kSoundEffect_BaaLaugh5,
            kSoundEffect_BaaJump1,
            kSoundEffect_BaaJump2,
            kSoundEffect_PigOink1,
            kSoundEffect_PigOink2,
            kSoundEffect_PigOink3,
            kSoundEffect_PigOink4,
            kSoundEffect_PigOink5,
            kSoundEffect_PigOink6,
            kSoundEffect_PigOink7,
            kSoundEffect_PigLaugh1,
            kSoundEffect_PigLaugh2,
            kSoundEffect_PigLaugh3,
            kSoundEffect_PigLaugh4,
            kSoundEffect_PigOinkLaugh,
            kSoundEffect_Jump,
            kSoundEffect_Land,
            kSoundEffect_RunSoft1,
            kSoundEffect_RunSoft2,
            kSoundEffect_RunSoft3,
            kSoundEffect_RunSoft4,
            kSoundEffect_RunHard1,
            kSoundEffect_RunHard2,
            kSoundEffect_RunHard3,
            kSoundEffect_RunHard4,
            kSoundEffect_RunSoftPig1,
            kSoundEffect_RunSoftPig2,
            kSoundEffect_RunSoftPig3,
            kSoundEffect_RunSoftPig4,
            kSoundEffect_Splash,
            kSoundEffect_SwimLoop,
            kSoundEffect_Rainbow,
            kSoundEffect_HowlingWind,
            kSoundEffect_RoaringFire,
            kSoundEffect_HitTree,
            kSoundEffect_HitRock,
            kSoundEffect_HitFlowers,
            kSoundEffect_HitWall,
            kSoundEffect_HitCow,
            kSoundEffect_MudSquelch1,
            kSoundEffect_MudSquelch2,
            kSoundEffect_AnimalMerriment,
            kSoundEffect_GateOpen,
            kSoundEffect_GateClose,
            kSoundEffect_HitHedge,
            kSoundEffect_SkidStart,
            kSoundEffect_SkidLoop,
            kSoundEffect_HitBoostArrow,
            kSoundEffect_Bird1,
            kSoundEffect_Bird2,
            kSoundEffect_Bird3,
            kSoundEffect_Bird4,
            kSoundEffect_Bird5,
            kSoundEffect_Bird6,
            kSoundEffect_Bird7,
            kSoundEffect_Bird8,
            kSoundEffect_Bird9,
            kSoundEffect_Bird10,
            kSoundEffect_BubblesHigh,
            kSoundEffect_BubblesLowLoop,
            kSoundEffect_Swish,
            kSoundEffect_AmbientCow1,
            kSoundEffect_AmbientCow2,
            kSoundEffect_AmbientCow3,
            kSoundEffect_ChickenCluck1,
            kSoundEffect_ChickenCluck2,
            kSoundEffect_Goat,
            kSoundEffect_Horse,
            kSoundEffect_Howl,
            kSoundEffect_Bark1,
            kSoundEffect_Bark2,
            kSoundEffect_Bark3,
            kSoundEffect_Cat,
            kSoundEffect_Rooster,
            kSoundEffect_ChickenSquawk1,
            kSoundEffect_ChickenFlapWings,
            kSoundEffect_ChickenRunAway,
            kSoundEffect_TractorLoop,
            kSoundEffect_TractorBeep,
            kSoundEffect_ChickenPop,
            kSoundEffect_Boing,
            kSoundEffect_Frog1,
            kSoundEffect_MetalHoof,
            kSoundEffect_Cuckoo,
            kSoundEffect_Owl,
            kSoundEffect_Crunch,
            kSoundEffect_SheepOoh,
            kSoundEffect_Wahoo,
            kSoundEffect_HitStar,
            kSoundEffect_PiggyWin,
            kSoundEffect_Bell,
            kSoundEffect_DripAntBlink,
            kSoundEffect_PenguinSquawk1,
            kSoundEffect_PenguinSquawk2,
            kSoundEffect_PenguinSquawk3,
            kSoundEffect_ShaunJump,
            kSoundEffect_HitMetal,
            kSoundEffect_AppleDrop,
            kSoundEffect_AnimalBump,
            kSoundEffect_Whistle,
            kSoundEffect_HitBarrel,
            kSoundEffect_HitShirley,
            kSoundEffect_GnomeSmash,
            kSoundEffect_OtherSheep1,
            kSoundEffect_OtherSheep2,
            kSoundEffect_OtherSheep3,
            kNumSoundEffects
        };
        public enum Enum2 {
            kSoundEffect_MusicLoop = 0,
            kSoundEffect_MenuMusicLoop,
            kSoundEffect_Ambience,
            kSoundEffect_StartLevel,
            kSoundEffect_CompleteLevel_JustMusic,
            kSoundEffect_CompleteLevelPigs1_NoMusic,
            kSoundEffect_CompleteLevelPigs2_NoMusic,
            kSoundEffect_CompleteLevelPigs3_NoMusic,
            kSoundEffect_CompleteLevelPigs1,
            kSoundEffect_CompleteLevelPigs2,
            kSoundEffect_CompleteLevelPigs3,
            kSoundEffect_CompleteLevelShaun1,
            kSoundEffect_CompleteLevelShaun2,
            kSoundEffect_CompleteLevelShaun3,
            kSoundEffect_CompleteLevelShaun4,
            kSoundEffect_CompleteLevelShaun1_NoMusic,
            kSoundEffect_CompleteLevelShaun2_NoMusic,
            kSoundEffect_CompleteLevelShaun3_NoMusic,
            kSoundEffect_CompleteLevelShaun4_NoMusic,
            kSoundEffect_CountrysideMusic,
            kSoundEffect_MudMusic,
        };
        public int NumOpponentSounds
        {
            get;
            set;
        }

        public int NumSheepSounds
        {
            get;
            set;
        }

public void SetNumOpponentSounds(short inThing) {numOpponentSounds = inThing;}///@property(readwrite,assign) int numOpponentSounds;
public void SetNumSheepSounds(short inThing) {numSheepSounds = inThing;}///@property(readwrite,assign) int numSheepSounds;


        public Audio()
        {
            //if (!base.init()) return null;

            birdsOn = false;
            currentlyLoadedScene = -1;
            currentlyLoadedOpponent = -1;
            tractorSoundId = -1;
            numSheepSounds = 5;
            //return this;
        }
        public void PreloadMusicAndMenuEffects ()
		{

			#if AUDIO_OFF
                return;
			#endif

			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 ((int)Enum2.kSoundEffect_MusicLoop, "whothecaddymusic", "mp3", -1);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 ((int)Enum2.kSoundEffect_MenuMusicLoop, "menu", "mp3", -1);
			(SoundEngine.Instance ()).AVSetVolumeP1 ((int)Enum2.kSoundEffect_MenuMusicLoop, 0.65f);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 ((int)Enum2.kSoundEffect_Ambience, "backgroundambience1", "mp3", -1);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 ((int)Enum2.kSoundEffect_StartLevel, "levelstartmusic", "mp3", 0);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevel_JustMusic, "levelcompletemusic", "mp3", 0);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelPigs1, "levelcompletemusic_lose1", "mp3", 0);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelPigs2, "levelcompletemusic_lose2", "mp3", 0);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelPigs3, "levelcompletemusic_lose3", "mp3", 0);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelShaun1, "levelcompletemusic_win1", "mp3", 0);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelShaun2,
				"levelcompletemusic_win2",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelShaun3,
				"levelcompletemusic_win3",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelShaun4,
				"levelcompletemusic_win4",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelPigs1_NoMusic,
				"levelcompletenomusic_lose1",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelPigs2_NoMusic,
				"levelcompletenomusic_lose2",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelPigs3_NoMusic,
				"levelcompletenomusic_lose3",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelShaun1_NoMusic,
				"levelcompletenomusic_win1",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelShaun2_NoMusic,
				"levelcompletenomusic_win2",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelShaun3_NoMusic,
				"levelcompletenomusic_win3",
				"mp3",
				0
			);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CompleteLevelShaun4_NoMusic, "levelcompletenomusic_win4", "mp3", 0);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 (
				(int)Enum2.kSoundEffect_CountrysideMusic, "countrysidelevel", "mp3", -1);
			(SoundEngine.Instance ()).LoadAVSoundP1P2P3 ((int)Enum2.kSoundEffect_MudMusic, "mudlevel", "mp3", -1);
        }

        public void ReleaseOpponentSoundEffects (int whichOpponent)
		{
			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_PigOink1) != null);
			for (int i = 0; i < numOpponentSounds; i++) {
				Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_PigOink1 + i) != null);
				(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_PigOink1 + i);
            }

        }

        public void LoadNewOpponentSoundEffects (int whichOpponent)
		{
			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_PigOink1) == null);
			switch (whichOpponent) {
			case (int)PlayerType.kPlayerPig:
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink1, "pigs_various_01.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink2, "pigs_various_02.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink3, "pigs_various_03.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink4, "pigs_various_04.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink5, "pigs_various_05.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink6, "pigs_various_06.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink7, "pigs_various_07.wav");
				numOpponentSounds = 7;
				break;
			case (int)PlayerType.kPlayerOstrich:
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_PigOink1, "Ostrich1.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_PigOink2, "Ostrich2.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_PigOink3, "Ostrich3.wav", 0.5f);
				numOpponentSounds = 3;
				break;
			case (int)PlayerType.kPlayerPenguin:
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink1, "Penguin1.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_PigOink2, "Penguin4.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigOink3, "Penguin3.wav");
                numOpponentSounds = 3;
                break;
            default :
                Globals.Assert(false);
                break;
            }

        }

        public void CheckAndLoadNewOpponentSoundEffects(int whichOpponent)
        {
            if (whichOpponent != currentlyLoadedOpponent) {
                if (currentlyLoadedOpponent != -1) {
                    this.ReleaseOpponentSoundEffects(currentlyLoadedOpponent);
                }

                this.LoadNewOpponentSoundEffects(whichOpponent);
                currentlyLoadedOpponent = (short)whichOpponent;
            }

        }

        public void UpdateTractorSound (bool aTractorIsOnScreen)
		{
			if (tractorSoundId != -1) {
				if (!aTractorIsOnScreen) {
					(SoundEngine.Instance ()).FadeOutP1 ((int)Enum1.kSoundEffect_TractorLoop, 2.0f);
					tractorSoundId = -1;
				}

			} else {
				if (aTractorIsOnScreen) {
					(SoundEngine.Instance ()).LoopFinchSoundFadeInP1P2 ((int)Enum1.kSoundEffect_TractorLoop, 1.0f, 0.5f);
					tractorSoundId = (short)Enum1.kSoundEffect_TractorLoop;
                }

            }

        }

        public void ReleaseSceneSoundEffects (int whichScene)
		{

			#if AUDIO_OFF
                return;
			#endif

			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_RunSoft1) != null);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunHard1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunHard2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunHard3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunHard4);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunSoft1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunSoft2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunSoft3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunSoft4);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunSoftPig1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunSoftPig2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunSoftPig3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RunSoftPig4);
            if (whichScene == (int) SceneType.kSceneGrass) {
                this.ReleaseCountryEffects();
            }
            else if (whichScene == (int) SceneType.kSceneIce) {
                this.ReleasePenguinCupEffects();
            }
            else if (whichScene == (int) SceneType.kSceneMud) {
                this.ReleaseFarmEffects();
            }

        }

        public void LoadNewSceneSoundEffects (int whichScene)
		{

			#if AUDIO_OFF
                return;
			#endif

			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_RunSoft1) == null);
			switch ((SceneType)whichScene) {
			case SceneType.kSceneMud:
				break;
			case SceneType.kSceneGrass:
			case SceneType.kSceneIce:
			case SceneType.kSceneDesert:
			case SceneType.kSceneMoon:
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunHard1, "HoofHard1.wav", 0.9f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunHard2, "HoofHard2.wav", 0.9f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunHard3, "HoofHard1.wav", 0.9f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunHard4, "HoofHard3.wav", 0.9f);
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_RunSoft1, "HoofSoft5.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_RunSoft2, "HoofSoft3.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_RunSoft3, "HoofSoft5.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_RunSoft4, "HoofSoft4.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_RunSoftPig1, "HoofSoft5.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_RunSoftPig2, "HoofSoft3.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_RunSoftPig3, "HoofSoft5.wav");
				(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_RunSoftPig4, "HoofSoft4.wav");
				break;
			default :
				Globals.Assert (false);
				break;
			}

			if (whichScene == (int)SceneType.kSceneGrass) {
				this.LoadCountryEffects ();
			} else if (whichScene == (int)SceneType.kSceneIce) {
				this.LoadPenguinCupEffects ();
			} else if (whichScene == (int)SceneType.kSceneMud) {
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunHard1, "HoofHard1.wav", 0.9f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunHard2, "HoofHard2.wav", 0.9f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunHard3, "HoofHard1.wav", 0.9f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunHard4, "HoofHard3.wav", 0.9f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunSoft1, "MudStep1.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunSoft2, "MudStep2.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunSoft3, "MudStep1.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunSoft4, "MudStep3.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunSoftPig1, "MudStep1.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunSoftPig2, "MudStep2.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunSoftPig3, "MudStep1.wav", 0.5f);
				(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RunSoftPig4, "MudStep3.wav", 0.5f);
                this.LoadFarmEffects();
            }

        }

        public void CheckAndLoadNewSceneSoundEffects(int whichScene)
        {
            if (whichScene != currentlyLoadedScene) {
                if (currentlyLoadedScene != -1) {
                    this.ReleaseSceneSoundEffects(currentlyLoadedScene);
                }

                this.LoadNewSceneSoundEffects(whichScene);
                currentlyLoadedScene = (short)whichScene;
            }

        }

        public void CheckAndReleaseTemporarySoundEffects ()
		{

			#if AUDIO_OFF
                return;
			#endif

			if ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_HitBoostArrow) == null) {
				return;
			}

			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitBoostArrow);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Land);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitTree);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitWall);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitFlowers);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_MudSquelch1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_MudSquelch2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitHedge);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_SkidStart);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_GateOpen);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_GateClose);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Splash);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_SwimLoop);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Rainbow);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bell);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Whistle);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_RoaringFire);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Baa1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Baa2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Baa3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Baa4);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Baa5);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaLaugh1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaLaugh2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaLaugh3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaLaugh4);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaLaugh5);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaImpact1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaImpact2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaImpact3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaJump1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_BaaJump2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_PigLaugh1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_PigLaugh2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_PigLaugh3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_PigLaugh4);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bird1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bird2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bird3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bird4);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bird5);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bird6);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bird7);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bird8);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitCow);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitShirley);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_GnomeSmash);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_OtherSheep1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_OtherSheep2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_OtherSheep3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Frog1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Boing);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_TractorBeep);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_TractorLoop);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Howl);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_ChickenCluck1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_ChickenCluck2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_ChickenSquawk1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_ChickenFlapWings);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_ChickenPop);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Goat);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Horse);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bark1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bark2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Bark3);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Rooster);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitMetal);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_ShaunJump);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_AppleDrop);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_AnimalBump);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_HitBarrel);
        }

        public void LoadPenguinCupEffects ()
		{
			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_PenguinSquawk1) == null);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PenguinSquawk1, "Penguin1.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_PenguinSquawk2, "Penguin4.wav", 0.5f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PenguinSquawk3, "Penguin3.wav");
        }

        public void ReleasePenguinCupEffects ()
		{
			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_PenguinSquawk1) != null);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_PenguinSquawk1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_PenguinSquawk2);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_PenguinSquawk3);
        }

        public void LoadCountryEffects ()
		{
			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_Cuckoo) == null);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Cuckoo, "Cuckoo.wav", 0.03f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Owl, "Owl.wav", 0.2f);
        }

        public void ReleaseCountryEffects ()
		{
			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_Cuckoo) != null);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Cuckoo);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Owl);
        }

        public void LoadFarmEffects ()
		{
			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_MetalHoof) == null);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_MetalHoof, "Metal_Hit-2.wav", 0.9f);
        }

        public void ReleaseFarmEffects ()
		{
			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_MetalHoof) != null);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_MetalHoof);
        }

        public void PlayRandomBaa (float inVol)
		{
			(SoundEngine.Instance ()).PlayFinchSoundP1 (
				(int)((int)Enum1.kSoundEffect_Baa1 + Utilities.GetRand(numSheepSounds)), inVol);
        }

        public void CheckAndLoadLevelBuilder_RossEffects ()
		{
			if ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_ChickenPop) != null) {
				return;
			}

			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Frog1, "Frog1.wav", 0.16f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Boing, "bounceOffTrampoline.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_ChickenPop, "Pop.wav", 0.7f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Rainbow, "CNC_turbo_pickup_01.wav");
        }

        public void CheckAndReleaseLevelBuilder_RossEffects ()
		{
			if ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_ChickenPop) == null) {
				return;
			}

			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Rainbow);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Boing);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_Frog1);
			(SoundEngine.Instance ()).ReleaseFinchSound ((int)Enum1.kSoundEffect_ChickenPop);
        }

        public void CheckAndLoadCommonGameEffects ()
		{

			#if AUDIO_OFF
                return;
			#endif

			if ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_HitBoostArrow) != null) {
				return;
			}

			Globals.Assert ((SoundEngine.Instance ()).GetFinchSound ((int)Enum1.kSoundEffect_Land) == null);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_HitBoostArrow, "zipzap1.wav", 0.25f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_HitWall, "BassThump.wav", 0.8f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_MudSquelch2, "MudSquelch2.wav", 0.85f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_SkidStart, "SkidStart.wav", 0.33f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_GateOpen, "GateOpenFinal.wav", 0.85f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_GateClose, "GateCloseFinal.wav", 0.85f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_SwimLoop, "SwimLoop.wav", 0.9f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_RoaringFire, "Fire-2-Loop.wav", 0.65f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Frog1, "Frog1.wav", 0.16f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_TractorBeep, "farmers_tractor_horn_02.wav", 1.0f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_TractorLoop, "Diesel_EngineLoop.wav", 0.17f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Howl, "HOWL_SHORT.wav", 0.55f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_ChickenCluck1, "Chicken_cluck.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_ChickenCluck2, "CHICKEN1.WAV");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_ChickenSquawk1, "ChikenSquawk2.wav", 0.4f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_ChickenFlapWings, "Flapping.wav", 0.8f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_ChickenPop, "Pop.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Goat, "GOAT.WAV", 0.5f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Horse, "HORSE.WAV");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bark1, "MADBARK.WAV", 0.25f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Bark2, "DOG1.WAV");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Bark3, "YAP.WAV");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Rooster, "ROOSTER1.WAV");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bird1, "Bell_bird.wav", 0.1f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bird2, "Bird-8.wav", 0.1f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bird3, "Bird-13.wav", 0.1f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bird4, "Green_Sandpiper.wav", 0.1f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bird5, "Tufted_Titmouse.wav", 0.1f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bird6, "BIRD1.WAV", 0.1f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bird7, "BIRD2.WAV", 0.1f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bird8, "BIRD3_shorter.wav", 0.1f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_HitCow, "StrongFadingBleat.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_HitShirley, "shirley_gotHit.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_GnomeSmash, "BG_glasssmash1.wav", 0.8f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_OtherSheep1, "AdultSheepBleat.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_OtherSheep2, "Sheep-3.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_OtherSheep3, "Sheep-4.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaImpact1, "SHAUN - Impact.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaImpact2, "SHAUN - Impact1.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaImpact3, "SHAUN - ImpactsLaugh.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Baa1, "shaun_baa_04.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Baa2, "shaun_baa_05.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Baa3, "shaun_baa_08.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Baa4, "shaun_baa_12.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaLaugh1, "SHAUN - Celebrating1.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaLaugh2, "SHAUN - Celebrating2.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaLaugh3, "SHAUN - Celebrating3.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaLaugh4, "SHAUN - Celebrating4.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaLaugh5, "SHAUN - Celebrating5.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaJump1, "SHAUN - weeees1.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_BaaJump2, "SHAUN - weeees2 - jump.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigLaugh1, "PIGS - Laughs Short Snorty1.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigLaugh2, "PIGS - Laughs Short Snorty2.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigLaugh3, "PIGS - Laughs Short Snorty3.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_PigLaugh4, "PIGS - Laughs Short Snorty4.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Bell, "whistle1.wav", 0.22f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Rainbow, "CNC_turbo_pickup_01.wav", 0.5f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_MudSquelch1, "CNS_crashobjectmud4.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Splash, "pondsplash4.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Boing, "bounceOffTrampoline.wav", 0.8f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_HitFlowers, "HitFlowerBunch.wav", 0.7f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_HitHedge, "sheepbounceinhedge.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_HitTree, "BG_woodbounce1.wav", 0.7f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Land, "sheepfallorland9.wav", 0.7f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_ShaunJump, "sheepjump3.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_HitMetal, "tractorhit.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_AppleDrop, "foot-step-b.wav", 0.5f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_AnimalBump, "sheepbounceonsheep1.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_Whistle, "whistle1.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_HitBarrel, "barrel_hit_03.wav");
        }

        public void LoadMenuSoundEffects ()
		{
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_BubblesHigh, "BubblesNew.wav", 0.4f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)
				Enum1.kSoundEffect_BubblesLowLoop, "BubbleLowLoopNew.wav", 0.75f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Crunch, "Crunch.wav", 0.5f);
			(SoundEngine.Instance ()).LoadFinchSoundP1 ((int)Enum1.kSoundEffect_SheepOoh, "sheep_oohs_admiration_04.wav");
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_ButtonPress, "buttonclick2.wav", 1.0f);
			(SoundEngine.Instance ()).LoadFinchSoundP1P2 ((int)Enum1.kSoundEffect_Swish, "Whish.wav", 1.0f);
        }

        public void SetAudioSession(bool gameMusicOn)
        {
            if (gameMusicOn) {
//                UInt32 sessionCategory = kAudioSessionCategory_AmbientSound;
  //              AudioSessionSetProperty(kAudioSessionProperty_AudioCategory, sizeof (sessionCategory), sessionCategory);
            }
            else {
    //            UInt32 sessionCategory = kAudioSessionCategory_AmbientSound;
      //          AudioSessionSetProperty(kAudioSessionProperty_AudioCategory, sizeof (sessionCategory), sessionCategory);
            }

        }

        public void StartBirds()
        {
            birdsOn = true;
        }

        public void StopBirds()
        {
            birdsOn = false;
        }

        public void PlayRandomSheepWin ()
		{
			int randInt = Utilities.GetRand(4);
			(SoundEngine.Instance ()).AVPlaySound ((int)Enum2.kSoundEffect_CompleteLevelShaun1_NoMusic + randInt);
        }

        public void PlayRandomPigLaugh (CGPoint inPosition)
		{
			int whichSound = Utilities.GetRand (4);
			Globals.g_world.PlayFinchSoundWithPositionP1P2 ((int)Enum1.kSoundEffect_PigLaugh1 + whichSound, 1.0f, inPosition);
        }

        public void PlayRandomPigOinkP1 (float vol, CGPoint inPosition)
		{
			int whichSound = Utilities.GetRand (7);
			Globals.g_world.PlayFinchSoundWithPositionP1P2 ((int)Enum1.kSoundEffect_PigOink1 + whichSound, vol, inPosition);
        }

        public void PlayRandomShaunLaugh ()
		{
			int whichSound = Utilities.GetRand (5);
			(SoundEngine.Instance ()).PlayFinchSound ((int)Enum1.kSoundEffect_BaaLaugh1 + whichSound);
        }

        public void PlayRandomShaunJump ()
		{
			int whichSound = Utilities.GetRand (2);
			(SoundEngine.Instance ()).PlayFinchSound ((int)Enum1.kSoundEffect_BaaJump1 + whichSound);
        }

        public void PlayRandomShaunImpact ()
		{
			int whichSound = Utilities.GetRand (3);
			(SoundEngine.Instance ()).PlayFinchSound ((int)Enum1.kSoundEffect_BaaImpact1 + whichSound);
        }

        public void PlayRandomShaunBaa ()
		{
			int whichSound = Utilities.GetRand (4);
			(SoundEngine.Instance ()).PlayFinchSound ((int)Enum1.kSoundEffect_Baa1 + whichSound);
        }

        public void PlayerBumpedP1(Player inPlayer, float bumpVol)
        {
            if ((int)inPlayer.playerType == (int) PlayerType.kPlayerSheep) {
                int thing = (int)(3.0f * Utilities.GetRatioP1P2(bumpVol, 0.5f, 0.9f));
                int soundChance = 5 - (int) thing;
                if (Utilities.GetRand( soundChance) == 0) this.PlayRandomShaunImpact();

            }
            else {
            }

        }

        public void UpdateBirds ()
		{
			if (birdsOn) {
				int r = Utilities.GetRand (250);
				if (r == 0) {
					int whichSound = Utilities.GetRand (10);
					(SoundEngine.Instance ()).PlayFinchSound ((int)Enum1.kSoundEffect_Bird1 + whichSound);
                }

            }

        }

        public void UpdateRandomAnimalSoundCountry (int chance)
		{
			const int kNumRandomSoundsCountry = 20;
			int r = Utilities.GetRand(chance);
			if (r == 0) {
				Enum1[] soundId = new Enum1[20]
                {Enum1.kSoundEffect_PigOink4, Enum1.kSoundEffect_PigOink5, Enum1.kSoundEffect_PigOink6, Enum1.kSoundEffect_Baa1, Enum1.kSoundEffect_Baa2, Enum1.kSoundEffect_Baa3, Enum1.kSoundEffect_Baa4
                      , Enum1.kSoundEffect_Baa5, Enum1.kSoundEffect_Rooster, Enum1.kSoundEffect_Goat, Enum1.kSoundEffect_Horse, Enum1.kSoundEffect_ChickenCluck1, Enum1.kSoundEffect_Rooster,
                      Enum1.kSoundEffect_Goat, Enum1.kSoundEffect_Horse, Enum1.kSoundEffect_ChickenCluck1, Enum1.kSoundEffect_Rooster, Enum1.kSoundEffect_Goat, Enum1.kSoundEffect_Horse,
                      Enum1.kSoundEffect_ChickenCluck1};
                int whichSound = Utilities.GetRand( kNumRandomSoundsCountry);
                float volume = Utilities.GetRandBetweenP1(0.3f, 0.65f);
                (SoundEngine.Instance()).PlayFinchSoundP1((int)soundId[whichSound], volume);
            }

        }

        public void UpdateRandomAnimalSoundFarm (int chance)
		{
			const int kNumFarmRandomSounds = 29;
			int r = Utilities.GetRand (chance);
			if (r == 0) {
				Enum1[] soundId = new Enum1[29]
                {Enum1.kSoundEffect_PigOink1, Enum1.kSoundEffect_PigOink2, Enum1.kSoundEffect_PigOink3, Enum1.kSoundEffect_Baa1, Enum1.kSoundEffect_Baa2, Enum1.kSoundEffect_Baa3, Enum1.kSoundEffect_Baa4
                      , Enum1.kSoundEffect_Baa5, Enum1.kSoundEffect_Goat, Enum1.kSoundEffect_Horse, Enum1.kSoundEffect_Howl, Enum1.kSoundEffect_Bark1, Enum1.kSoundEffect_Bark2, Enum1.kSoundEffect_Bark3
                      , Enum1.kSoundEffect_Rooster, Enum1.kSoundEffect_Goat, Enum1.kSoundEffect_Horse, Enum1.kSoundEffect_Howl, Enum1.kSoundEffect_Bark1, Enum1.kSoundEffect_Bark2,
                      Enum1.kSoundEffect_Bark3, Enum1.kSoundEffect_Rooster, Enum1.kSoundEffect_Goat, Enum1.kSoundEffect_Horse, Enum1.kSoundEffect_Howl, Enum1.kSoundEffect_Bark1, Enum1.kSoundEffect_Bark2
                      , Enum1.kSoundEffect_Bark3, Enum1.kSoundEffect_Rooster};
                int whichSound = Utilities.GetRand( kNumFarmRandomSounds);
                (SoundEngine.Instance()).PlayFinchSound((int)soundId[whichSound]);
            }

        }

    }
}
