using UnityEngine;
using System;
using System.Collections;

namespace Default.Namespace
{
public partial class Game {

//UPDATE

    public void UpdateShowResults()
    {
        if ((Ztransition.GetTransition()).inTransition) return;

        if (gameState == GameState.e_ShowResultsLoseToPiggy) {
            this.PiggyOinkChance(false);
        }
        else if (gameState == GameState.e_ShowResultsWin) {
            this.PiggyOinkChance(true);
        }

        (Globals.g_world.audio).UpdateTractorSound(false);
        const float kTimeToStartBuzzSound = 1.5f;
        if (!reactivatedCrystalBackground) {
            if (stateTimer > 0.4f) {
                this.CheckCrystalBackgroundActivity(true);
                reactivatedCrystalBackground = true;
            }

        }

        if (!flushedAt3seconds) {
            if (stateTimer > 3.4f) {
                flushedAt3seconds = true;
                ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
            }

        }

        if (!gameMusicStoppedYet) {
            if (stateTimer >= kTimeToStartBuzzSound) {
                if (((Globals.g_world.frontEnd).profile).preferences.soundFxOn) {
                }
                else {
                }

                gameMusicStoppedYet = true;
            }

        }

        if (!player.jumpCelebrateCancelled) 
			{
            if (stateTimer > 1.7f) {
                player.SetJumpCelebrateCancelled(true);
                for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
                    (playerPiggy[j]).SetJumpCelebrateCancelled(true);
                }

            }

        }

        if (gameState !=  GameState.e_ShowResultsLoseToPiggy) {
            if (!shownPullTabYet) {
                if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                    if (stateTimer > 4.2f) {
                        string leaderboardId = ((Globals.g_world.frontEnd).profile).GetLeaderboardId(playingLevel);
                        if (leaderboardId != ("")) {

//                            #if USE_CRYSTAL
                                Globals.g_world.ShowPullTab();
  //                          #endif

                        }

                        shownPullTabYet = true;
                    }

                }

            }

        }

        if (!playedWinMusicYet) {
            if (stateTimer > 0.35f) {
                playedWinMusicYet = true;
                if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                    if (!((Globals.g_world.frontEnd).profile).preferences.soundFxOn) {
                        (SoundEngine.Instance()).AVChangeToTrackP1P2((int)Audio.Enum2.kSoundEffect_CompleteLevel_JustMusic, 0, 0.2f);
                    }
                    else {
                        if (gameState == GameState.e_ShowResultsWin) {
                            int sRand = Utilities.GetRand( 4);
                            (SoundEngine.Instance()).AVChangeToTrackP1P2((int)Audio.Enum2.kSoundEffect_CompleteLevelShaun1 + sRand, 0, 0.2f);
                        }
                        else {
                            int sRand = Utilities.GetRand( 3);
                            (SoundEngine.Instance()).AVChangeToTrackP1P2((int)Audio.Enum2.kSoundEffect_CompleteLevelPigs1 + sRand, 0, 0.2f);
                        }

                    }

                }
                else {
                    if (((Globals.g_world.frontEnd).profile).preferences.soundFxOn) {
                        if (gameState == GameState.e_ShowResultsWin) {
                            int sRand = Utilities.GetRand( 4);
                            (SoundEngine.Instance()).AVChangeToTrackP1P2((int)Audio.Enum2.kSoundEffect_CompleteLevelShaun1_NoMusic + sRand, 0, 0.2f);
                        }
                        else {
                            int sRand = Utilities.GetRand( 3);
                            (SoundEngine.Instance()).AVChangeToTrackP1P2((int)Audio.Enum2.kSoundEffect_CompleteLevelPigs1_NoMusic + sRand, 0, 0.2f);
                        }

                    }

                }

            }

        }

        if (stateTimer > 0.5f) {
            ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
        }

        if (playingCustom == 0) {
            if (!startedGetLeaderboardPosYet) {
                if ((newBestTimeRecorded) || (my_Rank == -1)) {
                    if (stateTimer > 2.5f) {
                        startedGetLeaderboardPosYet = true;
                        string leaderboardId = ((Globals.g_world.frontEnd).profile).GetLeaderboardId(playingLevel);
                        if (leaderboardId != ("")) {

                            #if USE_CRYSTAL
                            #endif

                        }

                    }

                }
                else {
                    if (stateTimer > 4.0f) {
                        Globals.g_world.ShowLeaderboardRank(my_Rank);
                        startedGetLeaderboardPosYet = true;
                    }

                }

            }

        }

        if (!shownHudYet) {
            if (stateTimer > 2.8f) {
                this.CheckSavesAndAchievements();
                (Globals.g_world.frontEnd).LoadWinOrLoseTextures();
                if (gameState == GameState.e_ShowResultsLoseToPiggy) hud.ShowInGameButtonsLoseToPiggy();
                else {
                    hud.ShowInGameButtonsWin(timeToUse);
                }
					
				this.StopRender();
						
				ParticleSystemRoss.Instance().StopRender();	
					
                shownHudYet = true;
            }

        }

        #if PLAYING_SIMULATOR_VIDEO
            playingGhost.UpdateNothingButTheFrame();
            player.UpdateAsGhost(playingGhost);
        #else
            player.Update();
            playingGhost.UpdatePlaying();
        #endif

        this.UpdatePiggies(false);
        recordingGhost.UpdateRecording();
        if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
            this.UpdateHedges();
        }

        this.UpdateScrollingBackground(40);
        this.UpdateStoneWalls(player);
        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                this.UpdateStoneWalls(playerPiggy[i]);
            }

        }

        this.UpdateGameObjectsP1P2( GameObjectType.kGameObject_CrossingThing, 800.0f, -500.0f);
        this.UpdateNoGoZones();
        this.UpdateChickens(false);
        this.UpdateCows();
        this.UpdateStartingGates();
        this.UpdateFlowerHeads();
        this.UpdatePonds();
        this.UpdateFlowerBunches();
        if (!hud.showResultsScreenShown) {
            this.UpdateFlocks();
        }

        for (int i = 0; i <  (int)ListType.Types; i++) this.UpdateMapObjects((ListType)i);

        this.UpdateMovingOnButtons();

 
        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                (playerPiggy[i]).UpdateEndOfFrame();
            }

        }

        player.UpdateEndOfFrame();

        this.UpdateZoomingCamera();
    }
		
	public void StopRender()
    {		
		(textureObject[(int) TextureType.kTexture_WarmOverlay]).StopRender();			
			
			playingGhost.StopRender();
					tileMap.StopRender();	
				player.StopRender();
		        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
		            if (i != Constants.RECORDING_WHICH_PIGGY) {
		                playerPiggy[i].StopRender();
		            }		
		        }

				for (int i = 0; i < (int)Enum2.kMaxMapObjects; i++)
					{
						mapObject[i].StopRender();
					}
			
            for (int i = 0; i <  (int)Enum2.kMaxRivers; i++) {
                river[i].StopRenderBridgeAsSprite();
            }
			
	}
		
    public void UpdateGetReady()
    {
        const float kHandTime = 2.2f;
        const float kDropYOffset = 100;
        const float kGameYOffset = 40;
        const float kWaitBeforeNumbers = 0.75f;
        player.UpdateGetReady(stateTimer);
        if (stateTimer > kWaitBeforeNumbers) {
            gameTimer += Constants.kFrameRate;
        }

        for (int i = 0; i <  (int)ListType.Types; i++) this.UpdateMapObjects((ListType)i);

        if (getReadyPhase == 1) {
            float nextNumberTime = kWaitBeforeNumbers + ((float) getReadyNumberIndex) * (kHandTime / 3.0f);
            if (stateTimer >= nextNumberTime) {
                hud.ShowGetReadyNumber(getReadyNumberIndex);
                getReadyNumberIndex++;
            }

            float endHand;

            #if HAND_DANGLE
                CGPoint danglePos = Utilities.CGPointMake((hud.BigHand()).mapPosition.x + 45, (hud.BigHand()).mapPosition.y + 113 + +Constants.MOVE_PLAYER_FORWARD);
                danglePos.x += prevOffset.x;
                danglePos.y += prevOffset.y;
                prevOffset.x = prevOffset2.x;
                prevOffset.y = prevOffset2.y;
                prevOffset2.x = (hud.BigHand()).FloatyInfo().xOffset;
                prevOffset2.y = (hud.BigHand()).FloatyInfo().yOffset;
                player.SetPosition(danglePos);
                player.SetScreenPos();
                player.SetPositionZ(150);
                handPos = Utilities.CGPointMake((hud.BigHand()).mapPosition.x + 50, (hud.BigHand()).mapPosition.y + 120);
                this.UpdateScrollingBackgroundP1(kDropYOffset, Utilities.CGPointMake(handPos.x, 110));
                endHand = kHandTime + kWaitBeforeNumbers;
                if (Constants.QUICK_HAND) {
                    endHand = 0.5f;
                }

            #else
                player.SetScreenPos();
                player.AddTrickOffsetToScreenPos();
                endHand = kHandTime + kWaitBeforeNumbers;
            #endif

            if (stateTimer >= endHand) {
                getReadyPhase = 2;

                #if HAND_DANGLE
                    (hud.BigHand()).SetTexture(textureObject[(int) TextureType.kTexture_HandOpen]);
                    (hud.BigHand()).Hide((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
                    player.SetNewState(PlayerState.kPlayerMoving_InAir);
                #endif

                phaseTimer = 0;
                hud.ShowGetReadyNumber(3);
                if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Bell);

            }

        }
        else if (getReadyPhase == 2) {
            phaseTimer += Constants.kFrameRate;
            player.UpdatePlayerPosition();
            player.UpdateGroundLevelJump();
            player.UpdateMoveAnim();
            float yOffset = kGameYOffset + ((kDropYOffset - kGameYOffset) * (1 - Utilities.GetCosInterpolationHalfP1P2(phaseTimer, 0, 1)));
            float xOffset = handPos.x + ((player.position.x - handPos.x) * (Utilities.GetCosInterpolationHalfP1P2(phaseTimer, 0, 1)));
            CGPoint slideScreenPos = Utilities.CGPointMake(xOffset, player.position.y);
            this.UpdateScrollingBackgroundP1(yOffset, slideScreenPos);
            player.SetScreenPos();
            player.AddTrickOffsetToScreenPos();
            this.OpenStartGates();
            if (player.numBounces > 0) {
            }

            if (player.state == PlayerState.kPlayerMoving_Normally) {
                this.SetNewGameState( GameState.e_GamePlay);
                player.EndGetReady();
                hud.NewGameStateGamePlay();
            }

        }

        playingGhost.UpdatePlaying();
        playingGhost.SetGhostCurrentFrame(2);
        if (LevelBuilder_Ross.levelOrder[playingLevel] == (int)LevelBuilder_Ross.Enum2.kMud8_4_TulipChicane) {
            this.UpdateFlowerBunches();
        }

        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                if (player.numBounces == 0) {
                    if ((playerPiggy[i]).controlType == PlayerControlType.kControlGhost) {
                        (playerPiggy[i]).UpdateAsGhost(ghostPiggy[i]);
                    }
                    else {
                        (playerPiggy[i]).SetScreenPos();
                    }

                }

                (playerPiggy[i]).UpdateEndOfFrame();
            }

        }

        if (lBuilder.currentScene == (int) SceneType.kSceneMud) {
            this.UpdateChickens(true);
        }

        this.UpdateCows();
        this.UpdateStartingGates();
        player.UpdateEndOfFrame();
        hud.UpdateGetReady();
        this.UpdateZoomingCameraGetReady();
    }

    public void OpenStartGates()
    {
        if (stoneWall[0] != null) {
            if ((stoneWall[0]).hasGate) {
                (stoneWall[0]).GatesFlyOff();
            }

        }

    }

    public void UpdateStarSpeedUpP1(StarSpeedUp inStarSpeedUp, Player inPlayer)
    {
        if (inPlayer.GetPosition().y > inStarSpeedUp.position.y) {
            bool canHitSpeedUp = ((inPlayer.positionZ < 20) && (inPlayer.positionZ > -5)) || (inPlayer.onRoof != -1);
            const float halfWidth = 24.0f;
            if ((inPlayer.GetPosition().x > (inStarSpeedUp.position.x - halfWidth)) && (inPlayer.GetPosition().x < (inStarSpeedUp.position.x + halfWidth))
              && (canHitSpeedUp)) {
                inPlayer.HitStarSpeedUp();
                {
                    ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                    info.type = EffectType.kEffect_RainbowBurst;
                    info.startPosition = inStarSpeedUp.position;
                    (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                }
            }
            else {
            }

            inStarSpeedUp.SetPassedBy(inPlayer);
        }

    }

    public void UpdateRainbowP1(Rainbow inRainbow, Player inPlayer)
    {
        if (inPlayer.position.y > inRainbow.position.y) {
            float heightDiff = Utilities.GetABS(inPlayer.positionZ - inRainbow.groundLevel);
            bool canHitRainbow = (heightDiff <= 20.0f);
            const float halfWidth = 42.0f;
            if ((inPlayer.position.x > (inRainbow.position.x - halfWidth)) && (inPlayer.position.x < (inRainbow.position.x + halfWidth)) && (
              canHitRainbow)) {
                inPlayer.HitRainbow();
                {
                    ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                    info.type = EffectType.kEffect_RainbowBurst;
                    info.startPosition = inRainbow.position;
                    (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                }
                if (player == inPlayer) {
                }

            }
            else {
                if (player == inPlayer) {
                }

            }

            inRainbow.SetPassedBy(inPlayer);
        }

    }

    public void SetupPreFeelGoodWords(bool doItNow)
    {
        this.ChangeToGameState( GameState.e_FeelGoodScreen);
        return;
        if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress <= (int)Profile.Enum5.kFeelGoodProgress_WelcomeToStarCup) {
            if ((((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress == (int)Profile.Enum5.kFeelGoodProgress_WelcomeToCountryCup) || (((Globals.g_world.frontEnd).profile)
              .profileInfo.feelGoodProgress == (int)Profile.Enum5.kFeelGoodProgress_WelcomeToMudCup)) {
                (hud.anotherPiggyScreen).SetNumCommentsInConversation(2);
            }
            else {
                (hud.anotherPiggyScreen).SetNumCommentsInConversation(1);
            }

        }
        else if ((((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress >= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainDesert) && 
          (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress <= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainMoon)) {
            (hud.anotherPiggyScreen).SetNumCommentsInConversation(1);
        }
        else {
            (hud.anotherPiggyScreen).SetNumCommentsInConversation(1);
        }

        (hud.anotherPiggyScreen).SetPreCommentCounter(0);
        (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_PreFeelGoodWords);
        if (doItNow) this.SetNewGameState( GameState.e_AnotherPiggy);
        else this.ChangeToGameState( GameState.e_AnotherPiggy);

    }

    public void CheckPreShowLevelScreens(int inLevel)
    {
        if (!((Globals.g_world.frontEnd).profile).profileInfo.seenAnotherPiggy1) {
            if (inLevel == 4) {
                (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_AnotherPiggy);
                ((Globals.g_world.frontEnd).profile).SetAnotherPiggyScreenPending(true);
                Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
                savedInfo.seenAnotherPiggy1 = true;
                ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
                ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
            }

        }

        if (!((Globals.g_world.frontEnd).profile).profileInfo.seenAnotherPiggy2) {
            if (inLevel == 12) {
                (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_AnotherPiggy);
                ((Globals.g_world.frontEnd).profile).SetAnotherPiggyScreenPending(true);
                Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
                savedInfo.seenAnotherPiggy2 = true;
                ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
                ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
            }

        }

        for (int i = 0; i < (int)Profile.Enum4.kNumCups - 1; i++) {
            int cupId = i + 1;
            if (false) {
                if (inLevel == ((int)Profile.Enum6.kNumLevelsPerCup * cupId)) {
                    ((Globals.g_world.frontEnd).profile).SetFeelGoodProgress((int)Profile.Enum5.kFeelGoodProgress_WelcomeToMudCup + i);
                    ((Globals.g_world.frontEnd).profile).SetFeelGoodScreenPending(true);
                    Globals.Assert(cupId < (int)Profile.Enum4.kNumCups);
                    Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
                    savedInfo.seenWelcomeToCup[cupId] = true;
                    ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
                    ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
                }

            }

        }

    }

    public void ChangeToGameStateGetReadyOrPendingThing()
    {
        if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel)
		{
            this.ChangeToGameState( GameState.e_GetReady);
            return;
        }

        if (((Globals.g_world.frontEnd).profile).profileInfo.speedUpScreenPending) {
            this.ChangeToGameState( GameState.e_SpeedBoostScreen);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodGetReady;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.anotherPiggyScreenPending) {
            (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_AnotherPiggy);
            this.ChangeToGameState( GameState.e_AnotherPiggy);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodGetReady;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
            this.SetupPreFeelGoodWords(false);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodGetReady;
        }
        else {
            this.ChangeToGameState( GameState.e_GetReady);
        }

    }

    public void UpdateShowLevel()
    {
        if (!shownPullTabYet) {
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                if (stateTimer > 0.75f) {
                    string leaderboardId = ((Globals.g_world.frontEnd).profile).GetLeaderboardId(playingLevel);
                    if (leaderboardId != ("")) {

//                        #if USE_CRYSTAL
                            Globals.g_world.ShowPullTab();
  //                      #endif

                    }

                    shownPullTabYet = true;
                }

            }

        }

        bool autoSkip = false;

        #if SKIP_SHOWLEVEL
            if (stateTimer > 4.0f) {
                autoSkip = true;
            }

        #endif

        if ((Ztransition.GetTransition()).inTransition) return;

        #if PLAYING_SIMULATOR_VIDEO
            if (stateTimer >= 1) {
                (SoundEngine.Instance()).AVFadeOutAndStop(0.2f);
                this.ChangeToGameStateGetReadyOrPendingThing();
            }

        #endif

        bool nextLevelButtonPressed = (hud.showNextLevelScreen).lastPressedButton == 2;
        bool menuButtonPressed = (hud.showNextLevelScreen).lastPressedButton == 5;
        bool tipButtonPressed = (hud.showNextLevelScreen).lastPressedButton == 6;
        if ((nextLevelButtonPressed) || (menuButtonPressed) || (tipButtonPressed) || (autoSkip)) {

//            #if USE_CRYSTAL
                Globals.g_world.HidePullTab();
                Globals.g_world.HideLeaderboardRank();
  //          #endif

        }

        if (tipButtonPressed) {
            ((Globals.g_world.frontEnd).profile).SetSeenTipForLevel(playingLevel);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodShowLevel;
            (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_RaceTip);
            this.ChangeToGameState( GameState.e_AnotherPiggy);
        }
        else if (nextLevelButtonPressed || autoSkip) {
            if ((!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) && (!((Globals.g_world.frontEnd).profile).SeenTipForLevel(playingLevel)) && 
              (((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel) == TrophyType.kTrophy_NotGot) && ((Profile.Enum3)((Globals.g_world.frontEnd).profile).HasRaceTip(
              playingLevel) != Profile.Enum3.kHud_NoRaceTip)) {
                ((Globals.g_world.frontEnd).profile).SetSeenTipForLevel(playingLevel);
                afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
                (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_RaceTip);
                this.ChangeToGameState( GameState.e_AnotherPiggy);
            }
            else {
                this.ChangeToGameStateGetReadyOrPendingThing();
                (SoundEngine.Instance()).AVFadeOutAndStop(0.2f);
            }

            firstTimeInShowLevelSinceMenu = false;
        }
        else if (menuButtonPressed) {
            if (firstTimeInShowLevelSinceMenu) {
                if ((Globals.g_world.frontEnd).currentScreen ==  FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) Globals.g_world.SetGoingToFrontEndFromShowLevel(1);
                else if ((Globals.g_world.frontEnd).currentScreen ==  FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
                    Globals.g_world.SetGoingToFrontEndFromShowLevel(3);
                }
                else {
                    Globals.g_world.SetGoingToFrontEndFromShowLevel(2);
                }

                firstTimeInShowLevelSinceMenu = false;
            }

            goBackToFrontEnd = true;
            (SoundEngine.Instance()).AVFadeOutAndStop(0.2f);
        }

    }

    public bool Update()
    {			
        this.UpdateTransition();
        stateTimer += Constants.kFrameRate;
        switch (gameState) {
        case GameState.e_SpeedBoostScreen :
            this.UpdateSpeedBoostScreen();
            break;
        case GameState.e_AnotherPiggy :
            this.UpdateAnotherPiggyScreen();
            break;
        case GameState.e_AppleCartScreen :
            break;
        case GameState.e_Paused :
            this.UpdatePaused();
            break;
        case GameState.e_ShowLevel :
            this.UpdateShowLevel();
            Globals.g_world.UpdatePullTab();
            break;
        case GameState.e_GetReady :
            this.UpdateGetReady();
            break;
        case GameState.e_GamePlay :
            {
                if (stateTimer < 0.5f) {
                    hud.UpdateGetReady();
                }

                this.UpdateGamePlay();
                if (flagStartPause) 
				{
                    this.StartPause();
                    this.UpdatePaused();
                    flagStartPause = false;
                    scrollPosition.y = prevScrollPosition.y;
                }

            }
            break;
        case GameState.e_ShowResultsWin :
        case GameState.e_ShowResultsLoseTooSlow :
        case GameState.e_ShowResultsLoseToPiggy :
            Globals.g_world.UpdatePullTab();
            this.UpdateShowResults();
            break;
        default :
            break;
        }

        hud.Update();
        return goBackToFrontEnd;
    }

    public void UpdateSpeedBoostScreen()
    {
        if ((Ztransition.GetTransition()).inTransition) return;

        if (hud.UpdateSpeedBoostScreen()) {
            if (((Globals.g_world.frontEnd).profile).profileInfo.anotherPiggyScreenPending) {
                (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_AnotherPiggy);
                this.ChangeToGameState( GameState.e_AnotherPiggy);
            }
            else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
                this.SetupPreFeelGoodWords(false);
            }
            else {
                if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodToMenu) {
                    goBackToFrontEnd = true;
                }
                else if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodGetReady) {
                    this.ChangeToGameState( GameState.e_GetReady);
                }
                else {
                    if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodNextLevel) this.ChangeToShowLevelOrFeelGoodScreen(true);
                    else {
                        this.ChangeToShowLevelOrFeelGoodScreen(false);
                    }

                }

            }

        }

    }

    public void UpdateAnotherPiggyScreen()
    {

        #if RUN_AND_RECORD_PIG_TIMES
            if ((!(Ztransition.GetTransition()).inTransition) && (stateTimer > 4.0f)) 
#else

            if (hud.UpdateAnotherPiggyScreen()) 
#endif

        {
            if ((hud.anotherPiggyScreen).type == AnotherPiggyType.kAP_PreFeelGoodWords) {
                int plusOne = (hud.anotherPiggyScreen).preCommentCounter + 1;
                (hud.anotherPiggyScreen).SetPreCommentCounter((short)plusOne);
                if ((hud.anotherPiggyScreen).preCommentCounter < (hud.anotherPiggyScreen).numCommentsInConversation) {
                    this.ChangeToGameState( GameState.e_AnotherPiggy);
                    return;
                }
                else {
                    this.ChangeToGameState( GameState.e_FeelGoodScreen);
                    return;
                }

            }
            else if ((hud.anotherPiggyScreen).type == AnotherPiggyType.kAP_AnotherPiggy) {
                this.ChangeToGameState( GameState.e_ShowLevel);
                (SoundEngine.Instance()).AVFadeOutAndStop(0.5f);
            }
            else {
                if (((hud.anotherPiggyScreen).theScreen).lastPressedButton == 0) {
                    afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodGetReady;
                }
                else {
                    afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodShowLevel;
                }

                if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodToMenu) {
                    goBackToFrontEnd = true;
                }
                else if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodShowLevel) {
                    this.ChangeToGameState( GameState.e_ShowLevel);
                }
                else if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodGetReady) {
                    this.ChangeToGameState( GameState.e_GetReady);
                }
                else {
                    if ((hud.anotherPiggyScreen).type == AnotherPiggyType.kAP_RaceTip) {
                        this.ChangeToGameStateGetReadyOrPendingThing();
                        (SoundEngine.Instance()).AVFadeOutAndStop(0.2f);
                    }
                    else {
                        this.ChangeToGameState( GameState.e_ShowLevel);
                    }

                }

            }

        }
    }

    public void UpdateHedgeP1(int i, Player inPlayer)
    {
        if (!(hedge[i]).IsPassedByPlayer(inPlayer.playerId)) {
            if (inPlayer.GetPosition().y >= gatePos[i].y) {
                if ((inPlayer.GetPosition().x > (gatePos[i].x - (gateWidth[i] / 2))) && (inPlayer.GetPosition().x < (gatePos[i].x + (gateWidth[i] / 2)))) {
                }
                else {
                    if (inPlayer.positionZ < 20.0f) {
                        inPlayer.CrashingThroughHedge(gatePos[i].y);
                    }

                }

                (hedge[i]).SetPassedByPlayer(inPlayer.playerId);
            }

        }

    }

    public void UpdateMapObjectsLevelBuilder_Ross(ListType listType)
    {
        int i = usedListHead[(int)listType];
        CGPoint scroll;
        scroll = Utilities.CGPointMake(0, lBuilder.tileMapOffset * (1 / Constants.LEVEL_BUILDER_TILE_SCALE));
        while (i != -1) {
            (mapObject[i]).UpdateScreenPosLevelBuilder_Ross(scroll);
            if ((mapObject[i]).HasBeenDisplayed()) {
            }
            else {
                (mapObject[i]).SetHasBeenDisplayed();
            }

            i = (mapObject[i]).GetNext();
        }

    }

    public void ResetNumConsecutiveFails()
    {
        if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
            return;
        }

        Profile.NotSavedProfileInfo info = ((Globals.g_world.frontEnd).profile).notSavedInfo;
        info.level[playingLevel].numConsecutiveFails = 0;
        info.level[playingLevel].numConsecutiveFailsByTime = 0;
        ((Globals.g_world.frontEnd).profile).SetNotSavedInfo(info);
        Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
        savedInfo.level[playingLevel].usingSlowerPig = false;
        ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
        flagSaveProfileInfo = true;
    }

    public void UpdateFinishLine()
    {

        #if PIGGY_SPEED_ADJUSTMENT_TOOL
            if (stateTimer > 60.0f) {
                player.SetFinishPosition(3);
                this.HitClosedGate();
                int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                speedAdjustmentTool.lastTrySpeed[realLevelId] += Utilities.GetRandBetweenP1(-0.4f, 0.4f);
                speedAdjustmentTool.whichRunForThisTrack++;
                speedAdjustmentTool.lastTryTime[realLevelId] = -1.0f;
            }

        #endif

        #if RUN_AND_RECORD_PIG_TIMES
            if (stateTimer > 60.0f) {
                player.SetFinishPosition(3);
                this.HitClosedGate();
            }

        #endif

        if (player.hasPassedFinishLine) {

            #if PIGGY_SPEED_ADJUSTMENT_TOOL
                this.SendResultsToPiggySpeedAdjustmentToolP1P2(raceTimer, LevelBuilder_Ross.levelOrder[playingLevel], true);
            #endif

            player.HasCrossedLine();
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                (playerPiggy[0]).CheckLineCrossAchievementsPiggy();
            }

            this.SetNewGameState( GameState.e_ShowResultsWin);
            this.ResetNumConsecutiveFails();
            float bestTimeF = ((Globals.g_world.frontEnd).profile).GetCurrentBestTime(playingLevel);
            numApplesBeforeRace = (int)Utilities.GetNumApplesFromTrophy((int)((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel));
            numApplesAfterRace = numApplesBeforeRace;
            if (player.finishPosition == 1) {
                this.UpdateConsecutiveLossStats3apples_Won();
            }
            else {
                this.UpdateConsecutiveLossStats3apples_PassedLine();
            }

            if (raceTimer < bestTimeF) {
                ((Globals.g_world.frontEnd).profile).SetCurrentBestTimeP1(playingLevel, raceTimer);
                newBestTimeRecorded = true;
            }

            ((Globals.g_world.frontEnd).profile).CheckRecordBreakerP1(raceTimer, playingLevel);
            {
                if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                    {
                        if (player.finishPosition == 1) {
                            numApplesAfterRace = 3;
                        }
                        else {
                            if (player.finishPosition == 2) {
                                numApplesAfterRace = 2;
                            }
                            else {
                                numApplesAfterRace = 1;
                            }

                        }

                    }
                    if (numApplesAfterRace > numApplesBeforeRace) {
                        ((Globals.g_world.frontEnd).profile).SetNumApplesForRaceP1(playingLevel, numApplesAfterRace);
                        justUnlockedCup = ((Globals.g_world.frontEnd).profile).CheckForUnlockingOfLastCups();
                    }
                    else {
                        ((Globals.g_world.frontEnd).profile).UpdateLevelVisibility(playingLevel);
                    }

                    ((Globals.g_world.frontEnd).profile).CheckBonus3Apples(playingLevel);
                }

            }
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                bool gotNewApple = (numApplesAfterRace > numApplesBeforeRace);
                ((Globals.g_world.frontEnd).profile).UpdateFeelGoodP1P2(playingLevel, gotNewApple, numApplesBeforeRace);
                ((Globals.g_world.frontEnd).profile).JustPassedLevel(playingLevel);
                if (playingLevel < ((int)Profile.Enum6.kNumLevels - 1)) {
                    SpeedUpProgressEnum oldSpeed = ((Globals.g_world.frontEnd).profile).speedUpProgress;
                    if (playingLevel < (((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) - 1)) {
                        if (((Globals.g_world.frontEnd).profile).CanUnlockLevel(playingLevel + 1)) {
                            ((Globals.g_world.frontEnd).profile).SetLevelUnlockedP1(playingLevel + 1, true);
                        }

                    }

                    for (int i = 0; i < (int)Profile.Enum4.kNumCups; i++) {
                        if (playingLevel == (5 + (i * 8))) {
                            if (((Globals.g_world.frontEnd).profile).CanUnlockLevel((8 + (i * 8)))) {
                                ((Globals.g_world.frontEnd).profile).SetLevelUnlockedP1((8 + (i * 8)), true);
                            }

                        }

                    }

                    if (((Globals.g_world.frontEnd).profile).speedUpProgress != oldSpeed) {
                        ((Globals.g_world.frontEnd).profile).SetSpeedUpScreenPending(true);
                        if (oldSpeed == SpeedUpProgressEnum.kSpeedUp_FirstSpeedBoost) {
                        }

                    }

                }

                hud.NewGameState_ShowResultsWin(numApplesAfterRace);
            }

            if (newBestTimeRecorded) {
                timeToUse = ((Globals.g_world.frontEnd).profile).GetBestTimeP1(((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet(), playingLevel);
            }
            else {
                timeToUse = raceTimer;
            }

			
			Globals.g_analytics.CompleteRace(playingLevel,player.finishPosition);
        }

    }

    public void PostHighScoresToCrystal()
    {
        if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
            return;
        }

        bool noGameCenterLeaderboard = !((Globals.g_world.frontEnd).profile).HasGCLeaderboard(playingLevel);
        string leaderboardId = ((Globals.g_world.frontEnd).profile).GetLeaderboardId(playingLevel);
        if (leaderboardId != ("")) {
            float time = ((Globals.g_world.frontEnd).profile).GetBestTimeP1( BestTimeSet.t_Normal, playingLevel);
            if (Constants.UNLOCK_SOME_LEVELS) {
                if (time <= 5.0f) {
                    return;
                }

            }

            time *= 100.0f;
            int intTime = (int) time;
            float roundedTime = (float) intTime;

//            #if USE_CRYSTAL
//                if (noGameCenterLeaderboard) {
//                }
//                else {
//                    string leaderboardId_GC = leaderboardId.Copy();
//                }

  //          #endif

								if (!noGameCenterLeaderboard)
								{
										GameCenterWrapper.ReportScore(intTime,leaderboardId);

//										Debug.Log("Report score to " + leaderboardId + " : " + inVal);
//
//										Social.ReportScore (inVal, leaderboardId, success => {
//												Debug.Log(success ? "Reported score successfully" : "Failed to report score");
//										});
								}

        }

    }

    public void PiggyOinkChance(bool isSheepReally)
    {
        const float kChanceMin = 25.0f;
        const float kChanceMax = 100.0f;
        float chance = Utilities.GetRatioP1P2(stateTimer, 4.0f, 13.0f);
        int intChance = (int) (kChanceMin + (chance * (kChanceMax - kChanceMin)));
        if ((stateTimer > 20.0f) || (stateTimer < 2.5f)) {
            return;
        }

        if (Utilities.GetRand( intChance) == 0) {
            float vol = Utilities.GetRandBetweenP1(0.4f, 1.0f);
            if (isSheepReally) {
            }
            else {
                (Globals.g_world.audio).PlayRandomPigOinkP1(vol, (playerPiggy[0]).position);
            }

        }

    }

    public void ShowResultsDo_GoToMenu()
    {
        goToNextLevel = false;
        if (playingLevel >= ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) {
            if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
                if ((((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress >= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainDesert) && (((Globals.g_world.frontEnd).
                  profile).profileInfo.feelGoodProgress <= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainMoon)) {
                    this.SetupPreFeelGoodWords(false);
                    afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
                    return;
                }

            }

        }

        if (((Globals.g_world.frontEnd).profile).profileInfo.speedUpScreenPending) {
            this.ChangeToGameState( GameState.e_SpeedBoostScreen);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.anotherPiggyScreenPending) {
            this.ChangeToGameState( GameState.e_AnotherPiggy);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
            this.SetupPreFeelGoodWords(false);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
        }
        else {
            goToNextLevel = false;
            goBackToFrontEnd = true;
        }

    }

    public void ChangeToShowLevelOrFeelGoodScreen(bool nextLevel)
    {
        if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
            this.ChangeToGameState( GameState.e_ShowLevel);
            return;
        }

        int level = playingLevel;
        if (nextLevel) {
            level++;
        }

        this.CheckPreShowLevelScreens(level);
        if (((Globals.g_world.frontEnd).profile).profileInfo.anotherPiggyScreenPending) {
            (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_AnotherPiggy);
            this.ChangeToGameState( GameState.e_AnotherPiggy);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
            this.SetupPreFeelGoodWords(true);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
        }
        else {
            this.ChangeToGameState( GameState.e_ShowLevel);
        }

    }

    public void ShowResultsDo_Restart()
    {
        goToNextLevel = false;
        if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
            this.ChangeToShowLevelOrFeelGoodScreen(false);
            return;
        }

        if (playingLevel >= ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) {
            if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
                if ((((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress >= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainDesert) && (((Globals.g_world.frontEnd).
                  profile).profileInfo.feelGoodProgress <= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainMoon)) {
                    this.SetupPreFeelGoodWords(false);
                    afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodRetry;
                    return;
                }

            }

            this.ChangeToShowLevelOrFeelGoodScreen(false);
            return;
        }

        if (((Globals.g_world.frontEnd).profile).profileInfo.speedUpScreenPending) {
            this.ChangeToGameState( GameState.e_SpeedBoostScreen);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodRetry;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.anotherPiggyScreenPending) {
            (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_AnotherPiggy);
            this.ChangeToGameState( GameState.e_AnotherPiggy);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodRetry;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
            this.SetupPreFeelGoodWords(false);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodRetry;
        }
        else {
            this.ChangeToShowLevelOrFeelGoodScreen(false);
        }

    }

    public void ShowResultsDo_NextLevel()
    {
        goToNextLevel = true;
        if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
            this.ChangeToShowLevelOrFeelGoodScreen(true);
            return;
        }

        if (playingLevel >= ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) {
            if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
                if ((((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress >= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainDesert) && (((Globals.g_world.frontEnd).
                  profile).profileInfo.feelGoodProgress <= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainMoon)) {
                    this.SetupPreFeelGoodWords(false);
                    afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
                    return;
                }

            }

            this.ChangeToShowLevelOrFeelGoodScreen(true);
            return;
        }

        if (((Globals.g_world.frontEnd).profile).profileInfo.speedUpScreenPending) {
            this.ChangeToGameState( GameState.e_SpeedBoostScreen);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.anotherPiggyScreenPending) {
            (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_AnotherPiggy);
            this.ChangeToGameState( GameState.e_AnotherPiggy);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
        }
        else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
            this.SetupPreFeelGoodWords(false);
            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
        }
        else {
            this.ChangeToShowLevelOrFeelGoodScreen(true);
        }

    }

    public void UpdateMovingOnButtons()
    {
        bool menuPressed;
        bool restartPressed;
        bool nextPressed;
        if (shownHudYet) {
            if (gameState == GameState.e_ShowResultsWin) {
                menuPressed = ((hud.winScreen).lastPressedButton == 5);
                restartPressed = ((hud.winScreen).lastPressedButton == 6);
                nextPressed = ((hud.winScreen).lastPressedButton == 7);

                #if FACEBOOK_BUTTON
                    bool faceBookPressed = ((hud.winScreen).lastPressedButton == 8);
                    bool faceBookPressedRank = ((hud.winScreen).lastPressedButton == 9);
                    if (faceBookPressed) {
                        Globals.g_world.CheckAndInitialiseFaceBook((int) FaceBookThing.kFB_GettingTime);
                        (hud.winScreen).SetLastPressedButton(-1);
                    }
                    else if (faceBookPressedRank) {
                        Globals.g_world.CheckAndInitialiseFaceBook((int) FaceBookThing.kFB_GettingRank);
                        (hud.winScreen).SetLastPressedButton(-1);
                    }

                #endif

            }
            else {
                menuPressed = ((hud.loseScreen).lastPressedButton == 2);
                restartPressed = ((hud.loseScreen).lastPressedButton == 3);
                nextPressed = ((hud.loseScreen).lastPressedButton == 4);
            }

            if ((menuPressed) || (restartPressed) || (nextPressed)) {

//                #if USE_CRYSTAL
                    Globals.g_world.HidePullTab();
                    Globals.g_world.HideLeaderboardRank();
  //              #endif

                if (justUnlockedCup != -1) {
                    (Globals.g_world.frontEnd).SetInitMenuAtRaceScreen(justUnlockedCup);
                    (Globals.g_world.frontEnd).SetShowingThatCupIsUnlocked(true);
                    this.ShowResultsDo_GoToMenu();
                    return;
                }

            }

            if (menuPressed) {
                this.ShowResultsDo_GoToMenu();
            }
            else if (restartPressed) {
                this.ShowResultsDo_Restart();
            }
            else if (nextPressed) {
                if (playingLevel == (((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) - 1)) {
                    this.ShowResultsDo_GoToMenu();
                }
                else {
                    this.ShowResultsDo_NextLevel();
                }

            }

        }

    }

    public void CheckSavesAndAchievements()
    {
        if (!savedProfileInfoYet) {
            this.PostHighScoresToCrystal();
            this.SaveProfileInformation();
            savedProfileInfoYet = true;
        }

        ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
    }



    public void UpdateCowPats()
    {
        if (player.GetHeightOffFloor() > 5) return;

        for (int i = 0; i < numCowPats; i++) {
            if ((cowpat[i]).state == (int) CowPatState.e_Active) {
                float distanceY = player.position.y - (cowpat[i]).position.y;
                if (distanceY > 20) continue;

                if (distanceY < -20) continue;

                float distanceSqr = Utilities.GetSqrDistanceP1(player.position, (cowpat[i]).position);
                if (distanceSqr <= 900) {
                    player.HitCowPat(1);
                }

            }

        }

    }

    public void UpdateRamps()
    {
        this.UpdateRamp(player);
        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                this.UpdateRamp(playerPiggy[i]);
            }

        }

    }

    public void UpdateRamp(Player inPlayer)
    {
        player.SetBumpTiltY(0.0f);
        const float kRampBumpLengthExtra = 20;
        if (inPlayer.onRamp != -1) {
            int i = inPlayer.onRamp;
            float halfWidth = 5 + ((ramp[i]).width / 2);
            if ((inPlayer.position.x < ((ramp[i]).mapPosition.x + halfWidth)) && (inPlayer.position.x > ((ramp[i]).mapPosition.x - halfWidth))) {
                if (inPlayer.position.y > ((ramp[i]).mapPosition.y + (ramp[i]).length)) {
                    inPlayer.SetGroundLevel(0);
                    inPlayer.SetOnRamp(-1);
                    (ramp[i]).SetPlayerHasPassedEnd(inPlayer.playerId);
                    inPlayer.CheckJumpLengthAdjustmentFromRamp((ramp[i]).leapLengthAdjustment);
                    if (inPlayer == player) {
                        this.PlaySheepOohChanceP1(10, inPlayer);
                    }

                }
                else {
                    player.SetBumpTiltY(-0.7f);
                    float groundLevel = (ramp[i]).GetGroundLevel(inPlayer.position.y);
                    inPlayer.SetGroundLevel(groundLevel);
                }

            }
            else {
                inPlayer.SetOnRamp(-1);
                inPlayer.SetGroundLevel(0);
            }

            return;
        }

        for (int i = 0; i < numRamps; i++) {
            if ((ramp[i]).GetPlayerHasPassed(inPlayer.playerId)) {
                if (!(ramp[i]).GetPlayerHasPassedEnd(inPlayer.playerId)) {
                    if (inPlayer.position.y < ((ramp[i]).mapPosition.y + (ramp[i]).length + kRampBumpLengthExtra)) {
                        float halfWidth = (ramp[i]).width / 2;
                        if ((inPlayer.position.x < ((ramp[i]).mapPosition.x + halfWidth)) && (inPlayer.position.x > ((ramp[i]).mapPosition.x - halfWidth
                          ))) {
                            inPlayer.BounceSpeedX(0.5f);
                            CGPoint oldPosition = inPlayer.position;
                            if (inPlayer.position.x < (ramp[i]).mapPosition.x) {
                                oldPosition.x = (ramp[i]).mapPosition.x - halfWidth;
                            }
                            else {
                                oldPosition.x = (ramp[i]).mapPosition.x + halfWidth;
                            }

                            inPlayer.SetPosition(oldPosition);
                        }

                    }

                }

            }
            else {
                if (inPlayer.position.y >= (ramp[i]).mapPosition.y) {
                    (ramp[i]).SetPlayerHasPassed(inPlayer.playerId);
                    float halfWidth = (ramp[i]).width / 2;
                    if ((inPlayer.position.x < ((ramp[i]).mapPosition.x + halfWidth)) && (inPlayer.position.x > ((ramp[i]).mapPosition.x - halfWidth)))
                      {

                        #if NOT_FINAL_VERSION
                        #endif

                        inPlayer.SetOnRamp(i);
                        float groundLevel = (ramp[i]).GetGroundLevel(inPlayer.position.y);
                        inPlayer.SetGroundLevel(groundLevel);
                    }

                }

            }

        }

    }

    public void UpdatePlayerInPond(Player inPlayer)
    {
        const float kDistForFullFoam = 0.35f;
        int i = inPlayer.inPond;
        float dist = Utilities.GetDistanceP1(inPlayer.position, (pond[i]).position);
        (pond[i]).UpdateRipplesP1(dist, inPlayer);
        float foamyRatio = (1 - Utilities.GetRatioP1P2(dist, (pond[i]).radius * kDistForFullFoam, (pond[i]).radius));
        if (((pond[i]).type ==  PondType.e_Normal) || ((pond[i]).type ==  PondType.e_Puddle)) {
            if (dist > ((pond[i]).radius * 1.17f)) {
                inPlayer.SetInPond(-1);
            }

        }
        else {
            foamyRatio = 0.0f;
            inPlayer.IsChargingThroughMud();
            float yOff = inPlayer.position.y - (pond[i]).position.y;
            if ((dist > ((pond[i]).radius * 1.17f)) || (yOff > kYOffForFallInMud)) {
                inPlayer.SetInPond(-1);
            }

        }

        inPlayer.SetFoamyRatio(foamyRatio);
    }

    public void UpdatePonds()
    {
        const GameObjectType kGameObjectType = GameObjectType.kGameObject_Ponds;

        this.UpdateStartAndEndOfGameObjectP1P2(kGameObjectType, 1600.0f + Globals.g_world.mapObjectAppearDistance, -1000.0f);
        if (player.inPond != -1) {
            this.UpdatePlayerInPond(player);
            for (int i = startUpdateId[(int)kGameObjectType]; i < endUpdateId[(int)kGameObjectType]; i++) {
                int arrayIndex = ((updateOrder[(int)kGameObjectType])[i]);
                (pond[arrayIndex]).UpdatePond();
            }

        }
        else {
            bool aPondIsOnScreen = false;
            for (int i = startUpdateId[(int)kGameObjectType]; i < endUpdateId[(int)kGameObjectType]; i++) {
                int arrayIndex = ((updateOrder[(int)kGameObjectType])[i]);
                (pond[arrayIndex]).UpdatePond();
                if (player.positionZ <= 5.0f) {
                    this.UpdatePondP1(arrayIndex, player);
                }

                if (((pond[arrayIndex]).type ==  PondType.e_Normal) || ((pond[arrayIndex]).type ==  PondType.e_Puddle)) aPondIsOnScreen = true;

            }

            if (aPondIsOnScreen) 
								{
										if (Globals.g_world.game.gameState == GameState.e_GamePlay)
											this.UpdateFrogSounds();
								}

        }

        for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
            if ((playerPiggy[j]).inPond != -1) {
                this.UpdatePlayerInPond(playerPiggy[j]);
            }
            else {
                for (int i = startUpdateId[(int)kGameObjectType]; i < endUpdateId[(int)kGameObjectType]; i++) {
                    int arrayIndex = ((updateOrder[(int)kGameObjectType])[i]);
                    if ((playerPiggy[j]).positionZ <= 5.0f) {
                        this.UpdatePondP1(arrayIndex, playerPiggy[j]);
                    }

                }

            }

        }

    }

    public void UpdateFrogSounds()
    {
        if (Utilities.GetRand( 50) == 0) {
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Frog1);
        }

    }

    public void UpdatePondP1(int i, Player inPlayer)
    {
        float distSqr = Utilities.GetSqrDistanceP1(inPlayer.position, (pond[i]).position);
        if (distSqr <= (pond[i]).radiusSqr) {
            if (((pond[i]).type ==  PondType.e_Normal) || ((pond[i]).type ==  PondType.e_Puddle)) {
                inPlayer.SetInPond(i);
                inPlayer.HitPond();
                ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                info.inList = ParticleList.t_BeforePlayer;
                info.type = EffectType.kEffect_SplashRing;
                info.startPosition = inPlayer.GetPosition();
                inPlayer.SetActualSpeed();
                info.velocity = inPlayer.GetActualSpeed();
                info.rotation = inPlayer.moveAngle;
                (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_Splash, 1.0f, inPlayer.position);
            }
            else if ((pond[i]).type ==  PondType.e_Snow) {
                inPlayer.SetInPond(i);
                inPlayer.HitPond();
                ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                info.type = EffectType.kEffect_SplashRingMud;
                info.inList = ParticleList.t_BeforePlayer;
                info.startPosition = inPlayer.GetPosition();
                inPlayer.SetActualSpeed();
                info.velocity = inPlayer.GetActualSpeed();
                info.rotation = inPlayer.moveAngle;
                (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_HitFlowers);
            }
            else {
                float yOff = inPlayer.position.y - (pond[i]).position.y;
                if (yOff <= kYOffForFallInMud) {
                    if (inPlayer.HitMuddyPuddle()) {
                        ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                        info.type = EffectType.kEffect_SplashRingMud;
                        info.inList = ParticleList.t_BeforePlayer;
                        inPlayer.SetActualSpeed();
                        info.velocity = inPlayer.GetActualSpeed();
                        info.startPosition = inPlayer.GetPosition();
                        info.rotation = inPlayer.moveAngle;
                        (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                        Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_MudSquelch1 + Utilities.GetRand( 1), 1.0f, inPlayer.position);
                    }

                }

            }

        }

    }

    public void UpdateBuildingPiggyP1(int i, Player inPlayer)
    {
        if (!Utilities.FIsBetweenP1P2(inPlayer.position.x, (building[i]).GetLeftEdge(inPlayer.positionZ), (building[i]).GetRightEdgeP1(inPlayer.positionZ
          , inPlayer.position.y))) {
            return;
        }

        if (!Utilities.FIsBetweenP1P2(inPlayer.position.y, (building[i]).GetTopEdge(inPlayer.positionZ), (building[i]).GetBottomEdge(inPlayer.positionZ))
          ) {
            return;
        }

        float buildingGroundLevel = (building[i]).GetGroundLevel(inPlayer.position);
        if (buildingGroundLevel > 0.0f) {
            inPlayer.SetGroundLevel(buildingGroundLevel);
            inPlayer.SetOnRoof(i);
        }

    }

    public void PlayWallBumpSoundP1(Building inBuilding, float inBumpSpeed)
    {
        float volRatio = Utilities.GetRatioP1P2(inBumpSpeed, 3.0f, 10.0f);
        if (volRatio <= 0.05f) {
            return;
        }

        (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitWall, volRatio);
        if (volRatio > 0.9f) {
            (Globals.g_world.audio).PlayRandomBaa(volRatio);
        }

        if (Utilities.GetRand( 4) == 0) {
            if (inBuilding.type ==  BuildingType.kBuilding_Barn) {
                if (Utilities.GetRand( 2) == 0) {
                    (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Horse, 0.2f);
                }
                else {
                    (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Goat, 0.2f);
                }

            }
            else if (inBuilding.type ==  BuildingType.kBuilding_House) {
                (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Bark1 + Utilities.GetRand( 4), 0.2f);
            }
            else if (inBuilding.type ==  BuildingType.kBuilding_SideShed) {
                if (Utilities.GetRand( 2) == 0) {
                    (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_Rooster, 0.2f);
                }

            }

        }
        else {
            if (Utilities.GetRand( 6) == 0) {
            }

        }

    }

    public void UpdateBuildingP1(int i, Player inPlayer)
    {
        if (!Utilities.FIsBetweenP1P2(inPlayer.position.x, (building[i]).GetLeftEdge(inPlayer.positionZ), (building[i]).GetRightEdgeP1(inPlayer.positionZ
          , inPlayer.position.y))) {
            return;
        }

        if (!Utilities.FIsBetweenP1P2(inPlayer.position.y, (building[i]).GetTopEdge(inPlayer.positionZ), (building[i]).GetBottomEdge(inPlayer.positionZ))
          ) {
            return;
        }

        float buildingGroundLevel = (building[i]).GetGroundLevel(inPlayer.position);
        float distanceFromRoof = Utilities.GetABS(buildingGroundLevel - inPlayer.positionZ);
        if (buildingGroundLevel == 0.0f) {
            distanceFromRoof = 1000.0f;
        }
        else distanceFromRoof *= 1.5f;

        if (inPlayer.positionZ > (building[i]).height) {
            inPlayer.SetGroundLevel((building[i]).GetGroundLevel(inPlayer.position));
            inPlayer.SetAboveRoof(true);
            aboveRoofThisFrame = true;
            return;
        }

        if (inPlayer.aboveRoof) {
            inPlayer.SetAboveRoof(false);
        }

        float topEdge = (building[i]).GetTopEdge(inPlayer.positionZ);
        float bottyEdge = (building[i]).GetBottomEdge(inPlayer.positionZ);
        float leftEdge = (building[i]).GetLeftEdge(inPlayer.positionZ);
        float rightEdge = (building[i]).GetRightEdgeP1(inPlayer.positionZ, inPlayer.position.y);
        float distFromTop = Utilities.GetABS(inPlayer.position.y - topEdge);
        float distFromBottom = Utilities.GetABS(inPlayer.position.y - bottyEdge);
        float distFromLeft = Utilities.GetABS(inPlayer.position.x - leftEdge);
        float distFromRight = Utilities.GetABS(inPlayer.position.x - rightEdge);
        const float kWallDeadening = 0.5f;
        CGPoint newPlayerPosition;
        if ((distanceFromRoof < distFromLeft) && (distanceFromRoof < distFromRight) && (distanceFromRoof < distFromTop) && (distanceFromRoof < distFromBottom))
          {
            if (inPlayer.zVelocity < -5.0f) {
                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_MetalHoof, 0.7f);
            }

            inPlayer.SetOnRoof(i);
            return;
        }

        if (distFromTop < 64.0f) {
            if ((distFromLeft < 64.0f) && ((building[i]).topLeftGround.x > 32.0f)) {
                NoGoZone cornerZone;
                cornerZone = new NoGoZone(); //[[NoGoZone alloc] init];
                cornerZone.InitialiseP1(Utilities.CGPointMake(leftEdge + 64.0f, topEdge + 64.0f), 64.0f - Constants.kPlayerRadius);
                cornerZone.SetType(NoGoType.e_BuildingCorner);
                this.UpdateNoGoZoneP1P2(cornerZone, inPlayer, false);
                return;
            }

            if ((distFromRight < 64.0f) && ((building[i]).bottomRightGround.x < 352.0f)) {
                NoGoZone cornerZone;
                cornerZone = new NoGoZone();// = [[NoGoZone alloc] init];
                cornerZone.InitialiseP1(Utilities.CGPointMake(rightEdge - 64.0f, topEdge + 64.0f), 64.0f - Constants.kPlayerRadius);
                cornerZone.SetType(NoGoType.e_BuildingCorner);
                this.UpdateNoGoZoneP1P2(cornerZone, inPlayer, false);
                return;
            }

        }

        if (distFromTop < distFromBottom) {
            if ((distFromTop < distFromLeft) && (distFromTop < distFromRight)) {
                if (inPlayer.GetActualSpeed().y > 0.0f) {
                    this.PlayWallBumpSoundP1(building[i], inPlayer.GetActualSpeed().y);
                    newPlayerPosition = Utilities.CGPointMake(inPlayer.position.x, topEdge);
                    inPlayer.BounceSpeedY(kWallDeadening * 0.6f);
                    inPlayer.SetPosition(newPlayerPosition);
                    inPlayer.HitBuilding(building[i]);
                }

            }
            else {
                if (distFromRight < distFromLeft) {
                    if (inPlayer.GetActualSpeed().x < 0.0f) {
                        this.PlayWallBumpSoundP1(building[i], -inPlayer.GetActualSpeed().x);
                        newPlayerPosition = Utilities.CGPointMake(rightEdge, inPlayer.position.y);
                        inPlayer.BounceSpeedX(kWallDeadening);
                        inPlayer.SetPosition(newPlayerPosition);
                        inPlayer.HitBuilding(building[i]);
                    }

                }
                else {
                    if (inPlayer.GetActualSpeed().x > 0.0f) {
                        this.PlayWallBumpSoundP1(building[i], inPlayer.GetActualSpeed().x);
                        newPlayerPosition = Utilities.CGPointMake(leftEdge, inPlayer.position.y);
                        inPlayer.BounceSpeedX(kWallDeadening);
                        inPlayer.SetPosition(newPlayerPosition);
                        inPlayer.HitBuilding(building[i]);
                    }

                }

            }

        }
        else {
            if ((distFromBottom < distFromLeft) && (distFromBottom < distFromRight)) {
                if (inPlayer.GetActualSpeed().y < 0.0f) {
                    newPlayerPosition = Utilities.CGPointMake(inPlayer.position.x, bottyEdge);
                    inPlayer.BounceSpeedY(kWallDeadening);
                    inPlayer.SetPosition(newPlayerPosition);
                    inPlayer.HitBuilding(building[i]);
                }

            }
            else {
                if (distFromRight < distFromLeft) {
                    if (inPlayer.GetActualSpeed().x < 0.0f) {
                        newPlayerPosition = Utilities.CGPointMake(rightEdge, inPlayer.position.y);
                        inPlayer.BounceSpeedX(kWallDeadening);
                        inPlayer.SetPosition(newPlayerPosition);
                        inPlayer.HitBuilding(building[i]);
                    }

                }
                else {
                    if (inPlayer.GetActualSpeed().x > 0.0f) {
                        newPlayerPosition = Utilities.CGPointMake(leftEdge, inPlayer.position.y);
                        inPlayer.BounceSpeedX(kWallDeadening);
                        inPlayer.SetPosition(newPlayerPosition);
                        inPlayer.HitBuilding(building[i]);
                    }

                }

            }

        }

    }

    public void UpdatePlayerOnRoofP1(Player inPlayer, bool isPiggy)
    {
        float groundLevel = (building[inPlayer.onRoof]).GetGroundLevel(inPlayer.position);
        if (groundLevel == 0.0f) {
            if (isPiggy) {
                inPlayer.SetOnRoof(-1);
            }
            else {
                inPlayer.FallenOffBuilding();
                inPlayer.SetZVelocity(4.5f);
                inPlayer.SetTemporaryShadowLengthener(1.65f);
            }

        }

        inPlayer.UpdateOnOrAboveRoof();
        inPlayer.SetGroundLevel(groundLevel);
    }

    public void PlaySheepOohChanceP1(int chance, Player inPlayer)
    {
        if (Utilities.GetRand( chance) == 0) {
            Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_SheepOoh, 1.0f, inPlayer.position);
        }

    }

    public void UpdateBuildings(Player inPlayer)
    {
        aboveRoofThisFrame = false;
        if (inPlayer.onRoof == -1) {
            for (int i = startUpdateId[(int) GameObjectType.kGameObject_Buildings]; i < endUpdateId[(int) GameObjectType.kGameObject_Buildings]; i++) {
                int arrayIndex = ((updateOrder[(int) GameObjectType.kGameObject_Buildings])[i]);
                this.UpdateBuildingP1(arrayIndex, inPlayer);
            }

            if (!aboveRoofThisFrame) {
                if (inPlayer.aboveRoof) {
                    inPlayer.SetAboveRoof(false);
                    inPlayer.SetGroundLevel(0.0f);
                }

            }

        }
        else {
            if (inPlayer == player) {
                this.PlaySheepOohChanceP1(550, inPlayer);
            }

            this.UpdatePlayerOnRoofP1(inPlayer, false);
        }

    }

    public void UpdateBuildings()
    {
        this.UpdateStartAndEndOfGameObjectP1P2( GameObjectType.kGameObject_Buildings, 500.0f + Globals.g_world.mapObjectAppearDistance, buildingUpdateBackDist);
        this.UpdateBuildings(player);
        for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
            if (j != Constants.RECORDING_WHICH_PIGGY) {
                this.UpdateBuildings(playerPiggy[j]);
            }

        }

    }

    public void UpdateHayBale(int which)
    {
        if ((hayBale[which]).type ==  HayBaleType.e_Stack) {
            return;
        }

        if (!(hayBale[which]).burstYet) {
            if ((hayBale[which]).stillHasMapObject) {
                if (player.positionZ >= HayBale.kBaleMaxHeight) {
                    if ((mapObject[(hayBale[which]).mapObjectId]).listType ==  (int)ListType.e_RenderAbovePlayer) {
                        this.SwapMapObjectBackward((hayBale[which]).mapObjectId);
                    }

                }
                else if (player.positionZ < HayBale.kBaleMaxHeight) {
                    if ((mapObject[(hayBale[which]).mapObjectId]).listType ==  (int)ListType.e_RenderUnderPlayer) {
                        this.SwapMapObjectForward((hayBale[which]).mapObjectId);
                    }

                }

            }

            if ((hayBale[which]).Update(player.position)) {
                if ((hayBale[which]).stillHasMapObject) {
                    if ((mapObject[(hayBale[which]).mapObjectId]).listType ==  (int)ListType.e_RenderAbovePlayer) {
                        this.SwapMapObjectBackward((hayBale[which]).mapObjectId);
                    }

                }

            }

        }

    }

    public void UpdateTractor(int i)
    {
        if (!(tractor[i]).mapObjectRemoved) {
            if (player.positionZ >= kTractorJumpHeight) {
                if ((mapObject[(tractor[i]).mapObjectId]).listType ==  (int)ListType.e_RenderAbovePlayer) {

                    #if MO_DEBUG
                    #endif

                    this.SwapMapObjectBackward((tractor[i]).mapObjectId);
                }

            }
            else if (player.positionZ < kTractorJumpHeight) {
                if ((mapObject[(tractor[i]).mapObjectId]).listType ==  (int)ListType.e_RenderUnderPlayer) {

                    #if MO_DEBUG
                    #endif

                    this.SwapMapObjectForward((tractor[i]).mapObjectId);
                }

            }

        }

        (tractor[i]).UpdateTractor(player.position);
    }

    public void UpdateTractors()
    {
        const GameObjectType objectType = GameObjectType.kGameObject_Tractor;
        this.UpdateStartAndEndOfGameObjectP1P2(objectType, 100.0f + Globals.g_world.mapObjectAppearDistance, -100.0f);
        bool aTractorIsOnScreen = false;

        #if NOT_FINAL_VERSION
        #endif

        for (int i = startUpdateId[(int)objectType]; i < endUpdateId[(int)objectType]; i++) {
            int arrayIndex = ((updateOrder[(int)objectType])[i]);
            this.UpdateTractor(arrayIndex);
            aTractorIsOnScreen = true;
        }

        (Globals.g_world.audio).UpdateTractorSound(aTractorIsOnScreen);
    }

    public void UpdateInHayStack(HayBale inStack)
    {
        float distSquared = Utilities.GetSqrDistanceP1(player.position, inStack.position);
        if (distSquared > inStack.radiusSquared) {
            player.SetInHayStack(-1);
            inStack.BurstBaleP1(player.GetActualSpeed(), player.position);
        }

    }

    public void UpdateHayBales()
    {
        this.UpdateStartAndEndOfGameObjectP1P2( GameObjectType.kGameObject_HayBale, -30 + Globals.g_world.mapObjectAppearDistance, -500.0f);
        if (player.inHayStack != -1) {
            this.UpdateInHayStack(hayBale[player.inHayStack]);
        }
        else {
            for (int i = startUpdateId[(int) GameObjectType.kGameObject_HayBale]; i < endUpdateId[(int) GameObjectType.kGameObject_HayBale]; i++) {
                int arrayIndex = ((updateOrder[(int) GameObjectType.kGameObject_HayBale])[i]);
                this.UpdateHayBale(arrayIndex);
            }

        }

    }

    public void AddFeatherBurst(Chicken inChicken)
    {
        FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
        info.addUnderPlayer = false;
        info.position = inChicken.position;
        info.velocity = player.GetActualSpeed();
        info.velocity.x += -1.0f + ((float)(Utilities.GetRand( 200))) / 100.0f;
        info.velocity.y += -1.0f + ((float)(Utilities.GetRand( 200))) / 100.0f;
        info.rotation = 0.0f;
        info.type = FlowerHeadType.kFlowerHead_HayBurstStack;
        FlowerHead hayBurst = (Globals.g_world.game).GetFreeFlowerHeadPointer();
        if (hayBurst != null) {
            hayBurst.AddToScene(info);
        }

    }

    public void UpdateChickenP1(int i, bool inGetReady)
    {
        if ((chicken[i]).state == ChickenState.e_Pecking) {
            if (!inGetReady) {
                (chicken[i]).CheckRunAwayP1(player.position, player.GetActualSpeed());
                (chicken[i]).CheckRunAwayP1((playerPiggy[0]).position, (playerPiggy[0]).GetActualSpeed());
            }

        }
        else if ((chicken[i]).state == ChickenState.e_RunningAway) {
        }

        (chicken[i]).Update();
    }

    public void UpdateVenusForPlayer(int inVenusId)
    {


    }

    public void UpdateWoodenLogForPlayer(int inLogId)
    {

    }

    public void UpdateWaterfallForPlayer(int inFallId)
    {


    }

    public void UpdateWaterfall(int i)
    {
        (waterfall[i]).UpdateWaterfall();
        this.UpdateWaterfallForPlayer(i);
    }

    public void UpdateWoodenLog(int i)
    {
        this.UpdateWoodenLogForPlayer(i);
    }

    public void UpdateLion(int i)
    {
    }

    public void UpdateTree(int i)
    {
        if ((tree[i]).Update()) {
            if ((tree[i]).stillHasMapObject) {
                MapObject mo = mapObject[(tree[i]).mapObjectId];
                mo.SetPosition((tree[i]).GetShakingPosition());
            }

        }

    }

    public void UpdateVenus(int i)
    {
        (venus[i]).UpdateVenus();
        this.UpdateVenusForPlayer(i);
    }

    public void UpdateCrossingThing(int i)
    {
        if ((gameState == GameState.e_ShowResultsWin) || (gameState == GameState.e_ShowResultsLoseToPiggy)) {
            (crossingThing[i]).UpdateCrossingThing((Globals.g_world.game).raceTimer + stateTimer);
        }
        else {
            (crossingThing[i]).UpdateCrossingThing((Globals.g_world.game).raceTimer);
        }

    }

    public void UpdateGameObjectP1(GameObjectType inType, int arrayIndex)
    {
        switch (inType) {
        case GameObjectType.kGameObject_Waterfall :
            this.UpdateWaterfall(arrayIndex);
            break;
        case GameObjectType.kGameObject_WoodenLog :
            this.UpdateWoodenLog(arrayIndex);
            break;
        case GameObjectType.kGameObject_Venus :
            this.UpdateVenus(arrayIndex);
            break;
        case GameObjectType.kGameObject_Lion :
            this.UpdateLion(arrayIndex);
            break;
        case GameObjectType.kGameObject_Tree :
            this.UpdateTree(arrayIndex);
            break;
        case GameObjectType.kGameObject_CrossingThing :
            this.UpdateCrossingThing(arrayIndex);
            break;
        default :
            Globals.Assert(false);
            break;
        }

    }

    public void UpdateGameObjectsP1P2(GameObjectType inType, float startOffset, float behindOffset)
    {
        this.UpdateStartAndEndOfGameObjectP1P2(inType, startOffset + Globals.g_world.mapObjectAppearDistance, behindOffset);
        for (int i = startUpdateId[(int)inType]; i < endUpdateId[(int)inType]; i++) {
            int arrayIndex = ((updateOrder[(int)inType])[i]);
            this.UpdateGameObjectP1(inType, arrayIndex);
        }

    }

    public void UpdateChickens(bool inGetReady)
    {
        this.UpdateStartAndEndOfGameObjectP1( GameObjectType.kGameObject_Chicken, -130 + Globals.g_world.mapObjectAppearDistance);
        for (int i = startUpdateId[(int) GameObjectType.kGameObject_Chicken]; i < endUpdateId[(int) GameObjectType.kGameObject_Chicken]; i++) {
            int arrayIndex = ((updateOrder[(int) GameObjectType.kGameObject_Chicken])[i]);
            this.UpdateChickenP1(arrayIndex, inGetReady);
        }

    }

    public void UpdatePlayerHitCliffP1(int arrayIndex, CliffPiece inCliff)
    {


    }

    public void UpdateCliffs()
    {
        this.UpdateStartAndEndOfGameObjectP1P2( GameObjectType.kGameObject_CliffPieces, 250, -60);
        for (int i = startUpdateId[(int) GameObjectType.kGameObject_CliffPieces]; i < endUpdateId[(int) GameObjectType.kGameObject_CliffPieces]; i++) {
            int arrayIndex = ((updateOrder[(int) GameObjectType.kGameObject_CliffPieces])[i]);
            if ((player.position.y > (cliffPiece[arrayIndex]).topLeft.y) && (player.position.y <= (cliffPiece[arrayIndex]).bottomRight.y)) {
                this.UpdatePlayerHitCliffP1(arrayIndex, cliffPiece[arrayIndex]);
                break;
            }

        }

    }

    public void UpdateCows()
    {
        this.UpdateStartAndEndOfGameObjectP1P2( GameObjectType.kGameObject_Cows, 1000.0f + Globals.g_world.mapObjectAppearDistance, -300.0f);
        for (int i = startUpdateId[(int) GameObjectType.kGameObject_Cows]; i < endUpdateId[(int) GameObjectType.kGameObject_Cows]; i++) {
            int arrayIndex = ((updateOrder[(int) GameObjectType.kGameObject_Cows])[i]);
            this.UpdateCow(arrayIndex);
        }

    }

    public void UpdatePlayerOnPlayerBumps()
    {
        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                this.UpdateNoGoZoneP1P2((playerPiggy[i]).noGoZone, player, false);
                if (player.hasPassedFinishLine) {
                    this.UpdateNoGoZoneP1P2((playerPiggy[i]).noGoZone, player, true);
                }

                for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
                    if (j != Constants.RECORDING_WHICH_PIGGY) {
                        if (i != j) {
                            this.UpdateNoGoZoneP1P2((playerPiggy[j]).noGoZone, playerPiggy[i], false);
                        }

                    }

                }

            }

        }

    }

    public void UpdateNoGoZones()
    {
        Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateNGZStart] = DateTime.Now.TimeOfDay.Milliseconds;
        GameObjectType kGameObjectType = GameObjectType.kGameObject_NoGoZones;
        this.UpdateStartAndEndOfGameObjectP1P2(kGameObjectType, 1500.0f + Globals.g_world.mapObjectAppearDistance, -1000.0f);
        bool aTreeOnScreen = false;
        for (int i = startUpdateId[(int)kGameObjectType]; i < endUpdateId[(int)kGameObjectType]; i++) {
            int arrayIndex = ((updateOrder[(int)kGameObjectType])[i]);
            this.UpdateNoGoZoneP1P2(noGoZone[arrayIndex], player, false);
            if ((noGoZone[arrayIndex]).type == NoGoType.e_Tree) {
                aTreeOnScreen = true;
            }
            else if (((noGoZone[arrayIndex]).type == NoGoType.e_HayBale) || ((noGoZone[arrayIndex]).type == NoGoType.e_Bollard)) {
            }

            for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
                if (j != Constants.RECORDING_WHICH_PIGGY) {
                    this.UpdateNoGoZoneP1P2(noGoZone[arrayIndex], playerPiggy[j], false);
                }

            }

        }

        if (aTreeOnScreen) {
            if (gameState == GameState.e_GamePlay) {
                if (Utilities.GetRand( 150) == 0) {
                    this.PlayRandomTreeBumpSound();
                }

            }

        }

        this.UpdatePlayerOnPlayerBumps();
        Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateNGZEnd] = DateTime.Now.TimeOfDay.Milliseconds;
    }

    public void UpdateHedges()
    {
        const GameObjectType kGameObjectType = GameObjectType.kGameObject_Hedges;
        this.UpdateStartAndEndOfGameObjectP1P2(kGameObjectType, 1000.0f + Globals.g_world.mapObjectAppearDistance, -600.0f);
        for (int i = startUpdateId[(int)kGameObjectType]; i < endUpdateId[(int)kGameObjectType]; i++) {
            int arrayIndex = ((updateOrder[(int)kGameObjectType])[i]);
            this.UpdateHedgeP1(arrayIndex, player);
            for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
                if (j != Constants.RECORDING_WHICH_PIGGY) {
                    this.UpdateHedgeP1(arrayIndex, playerPiggy[j]);
                }

            }

        }

    }

    public void UpdateRainbows()
    {
        const GameObjectType kGameObjectType = GameObjectType.kGameObject_Rainbows;
        this.UpdateStartAndEndOfGameObjectP1P2(kGameObjectType, 600.0f + Globals.g_world.mapObjectAppearDistance, rainbowUpdateBackDist);
        for (int i = startUpdateId[(int)kGameObjectType]; i < endUpdateId[(int)kGameObjectType]; i++) {
            int arrayIndex = ((updateOrder[(int)kGameObjectType])[i]);
            if (!(rainbow[arrayIndex]).IsPassedBy(player)) this.UpdateRainbowP1(rainbow[arrayIndex], player);

            for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
                if (j != Constants.RECORDING_WHICH_PIGGY) {
                    if (!(rainbow[arrayIndex]).IsPassedBy(playerPiggy[j])) this.UpdateRainbowP1(rainbow[arrayIndex], playerPiggy[j]);

                }

            }

        }

    }

    public void UpdateStarSpeedUps()
    {
        const GameObjectType kGameObjectType = GameObjectType.kGameObject_StarSpeedUp;
        this.UpdateStartAndEndOfGameObjectP1(kGameObjectType, 20 + Globals.g_world.mapObjectAppearDistance);
        for (int i = startUpdateId[(int)kGameObjectType]; i < endUpdateId[(int)kGameObjectType]; i++) {
            int arrayIndex = ((updateOrder[(int)kGameObjectType])[i]);
            if (!(starSpeedUp[arrayIndex]).IsPassedBy(player)) this.UpdateStarSpeedUpP1(starSpeedUp[arrayIndex], player);

            if (!(starSpeedUp[arrayIndex]).IsPassedBy(playerPiggy[0])) this.UpdateStarSpeedUpP1(starSpeedUp[arrayIndex], playerPiggy[0]);

        }

    }

    public void UpdateAmbientMoo()
    {
        if (gameState !=  GameState.e_GamePlay) return;

        if (Utilities.GetRand( 250) == 0) {
            const int kTopRange = 100;
            const int kBottomRange = 50;
            int volume = kBottomRange + (Utilities.GetRand( (kTopRange) - kBottomRange));
            float fVolume = ((float) volume) / 100.0f;
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_OtherSheep1 + (Utilities.GetRand( 3)), fVolume);
        }

    }

    public void UpdateAmbientPenguin()
    {
        if (Utilities.GetRand( 150) == 0) {
            const int kTopRange = 100;
            const int kBottomRange = 50;
            int volume = kBottomRange + (Utilities.GetRand( (kTopRange) - kBottomRange));
            float fVolume = ((float) volume) / 100.0f;
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_PenguinSquawk1 + Utilities.GetRand( 3), fVolume);
        }

    }

    public void UpdateCow(int i)
    {
        const float kCowJumpHeight = 27;
        if ((cow[i]).stillHasMapObject) {
            if ((mapObject[(cow[i]).mapObjectId]).isOnScreen) {
                this.UpdateAmbientMoo();
            }

            if (player.positionZ >= kCowJumpHeight) {
                if ((mapObject[(cow[i]).mapObjectId]).listType ==  (int)ListType.e_RenderAbovePlayer) {
                    this.CheckAndSwapMapObjectBackward((cow[i]).mapObjectId);
                }

            }
            else {
                if ((mapObject[(cow[i]).mapObjectId]).listType ==  (int)ListType.e_RenderUnderPlayer) {
                    this.SwapMapObjectForward((cow[i]).mapObjectId);
                }

            }

        }

        (cow[i]).Update();
    }

    public void UpdateBoostArrows()
    {
        const GameObjectType kGameObjectType = GameObjectType.kGameObject_BoostArrows;
        this.UpdateStartAndEndOfGameObjectP1P2(kGameObjectType, 8000.0f + Globals.g_world.mapObjectAppearDistance, -3000.0f);
        for (int i = startUpdateId[(int)kGameObjectType]; i < endUpdateId[(int)kGameObjectType]; i++) {
            int arrayIndex = ((updateOrder[(int)kGameObjectType])[i]);
            (boostArrow[arrayIndex]).Update(player);
            for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
                if (j != Constants.RECORDING_WHICH_PIGGY) {
                    (boostArrow[arrayIndex]).Update(playerPiggy[j]);
                }

            }

        }

    }

    public void UpdateStartingGates()
    {
        for (int i = 0; i < numStartingGates; i++) {
            (startingGate[i]).Update();
        }

    }

    public void CancelPiggyCelebrations()
    {
        for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
            (playerPiggy[j]).SetJumpCelebrateCancelled(true);
        }

    }

    public void UpdateStoneWalls(Player inPlayer)
    {
        for (int i = 0; i < numStoneWalls; i++) {
            if (!(stoneWall[i]).PassedBy(inPlayer.playerId)) {
                float yPos = (stoneWall[i]).yMapPosition;

                #if PLAYING_SIMULATOR_VIDEO
                    if (inPlayer == player) {
                        yPos -= 5;
                    }

                #endif

                if (inPlayer.position.y > yPos) {
                    bool canEnter = true;
                    int gateId = 0;
                    if ((stoneWall[i]).hasGate) {
                        gateId = (stoneWall[i]).GetGateId(0);
                        canEnter = ((startingGate[(int)gateId]).state == StartingGateState.e_Open) || ((startingGate[(int)gateId]).state == 
                          StartingGateState.e_Opening) || (((startingGate[(int)gateId]).state == StartingGateState.e_Closed) && ((startingGate[(int)gateId]).
                          startingState == StartingGateState.e_Closed));
                    }
                    else if (inPlayer.positionZ > Constants.kStoneWallHeight) {
                        (stoneWall[i]).SetPassedBy(inPlayer.playerId);
                        continue;
                    }

                    float halfWidth = ((stoneWall[i]).xGateWidth / 2) + 15.0f;
                    bool canPass;
                    if ((stoneWall[i]).hasGate) {
                        halfWidth -= 16;
                        canPass = ((inPlayer.position.x > ((stoneWall[i]).xGatePosition - halfWidth)) && (inPlayer.position.x < ((stoneWall[i]).
                          xGatePosition + halfWidth)) && (canEnter));
                    }
                    else {
                        if (player == inPlayer) {
                            halfWidth += 10.0f;
                        }
                        else {
                            halfWidth -= 16.0f;
                        }

                        canPass = ((inPlayer.position.x < ((stoneWall[i]).xGatePosition - halfWidth)) || (inPlayer.position.x > ((stoneWall[i]).
                          xGatePosition + halfWidth)));
                    }

                    if (canPass) {
                        if (inPlayer.position.y > ((stoneWall[i]).yMapPosition + 15.0f)) {
                            bool isFinish;
                            if ((stoneWall[i]).hasGate) {
                                isFinish = (startingGate[(int)gateId]).startingState == StartingGateState.e_Open;
                            }
                            else {
                                isFinish = false;
                            }

                            (stoneWall[i]).SetPassedBy(inPlayer.playerId);
                            if (isFinish) {
                                if (((stoneWall[i]).numPlayersPast >= numAllowedPastLine) || (inPlayer == player)) {
                                    (stoneWall[i]).GatesFlyOff();
                                }

                                #if RACE_AS_PIGGY
                                #else


                                #endif

                                inPlayer.SetFinishPosition((stoneWall[i]).numPlayersPast);
                                inPlayer.SetFinishTime(raceTimer);
                            }
                            else {
                                (stoneWall[i]).GatesFlyOff();
                            }

                            inPlayer.PassedWall(isFinish);
                            if (isFinish) {
                                if (inPlayer == player) {
                                    this.CancelPiggyCelebrations();
                                }
                            }

                        }

                    }
                    else {
                        bool isFinish;
                        if ((stoneWall[i]).hasGate) {
                            isFinish = (startingGate[(int)gateId]).startingState == StartingGateState.e_Open;
                        }
                        else {
                            isFinish = false;
                        }

                        float volume = Utilities.GetRatioP1P2(inPlayer.GetActualSpeed().y, 3.5f, 10.0f);
                        CGPoint newPlayerPosition = Utilities.CGPointMake(inPlayer.position.x, (stoneWall[i]).yMapPosition);
                        inPlayer.SetPlayerPosition(newPlayerPosition);
                        inPlayer.BumpingIntoWall(isFinish);
                        if ((inPlayer == player) && (!canEnter)) {
                            hitClosedGate = true;
                            if (volume > 0.05f) {
                                if ((inPlayer.position.x > ((stoneWall[i]).xGatePosition - halfWidth)) && (inPlayer.position.x < ((stoneWall[i]).
                                  xGatePosition + halfWidth))) {
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitTree, volume);
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitBarrel, volume * 0.55f);
                                    (stoneWall[i]).WobbleGate();
                                    (Globals.g_world.audio).PlayerBumpedP1(inPlayer, volume);
                                }
                                else {
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitWall, volume);
                                    (Globals.g_world.audio).PlayerBumpedP1(inPlayer, volume);
                                }

                            }

                        }
                        else if (inPlayer == player) {
                            if (volume > 0.0f) {
                                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitWall, volume);
                                (Globals.g_world.audio).PlayerBumpedP1(inPlayer, volume);
                            }

                        }
                        else {
                            float distFromLine = (stoneWall[i]).yMapPosition - ((Globals.g_world.game).player).position.y;
                            float playerSpeedRatio = Utilities.GetRatioP1P2(inPlayer.GetActualSpeed().y, 5.0f, 12.0f);
                            float volume1 = 1 - Utilities.GetRatioP1P2(distFromLine, 0, 600);
                            volume1 *= playerSpeedRatio;
                            if (volume1 > 0.3f) {
                                if ((inPlayer.position.x > ((stoneWall[i]).xGatePosition - halfWidth)) && (inPlayer.position.x < ((stoneWall[i]).
                                  xGatePosition + halfWidth))) {
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitTree, volume1);
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitBarrel, volume1 * 0.55f);
                                    (Globals.g_world.audio).PlayerBumpedP1(inPlayer, volume1);
                                    (stoneWall[i]).WobbleGate();
                                }
                                else {
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitWall, volume1);
                                    (Globals.g_world.audio).PlayerBumpedP1(inPlayer, volume1);
                                }

                            }

                        }

                    }

                }

            }

        }

    }

    public void PlayRandomTreeBumpSound()
    {
        if (Utilities.GetRand( 2) == 0) {
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Cuckoo);
        }
        else {
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Owl);
        }

    }

    public void MakeBumpSoundPlayersP1P2P3(Player player1, Player player2, NoGoZone inZone, float inPower)
    {
        if (inZone.type == NoGoType.e_Piggy) {
            if ((raceTimer - player1.lastRockSoundTime) > 0.3f) {
                if ((raceTimer - player2.lastRockSoundTime) > 0.3f) {
                    player1.SetLastRockSoundTime(raceTimer);
                    player2.SetLastRockSoundTime(raceTimer);
                    const float kMinPowerForBumpNoise = 0.0f;
                    const float kMaxPowerForBumpNoise = 11.0f;
                    if (inPower > kMinPowerForBumpNoise) {
                        float volRatio = Utilities.GetRatioP1P2(inPower, kMinPowerForBumpNoise, kMaxPowerForBumpNoise);
                        Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_AnimalBump, volRatio, player1.position);
                    }

                }

            }

            float timeSinceOink = (raceTimer - timeOfLastOink);
            if (timeSinceOink >= 0.5f) {
                this.PlayPigBumpSheepSoundP1(player1, player2);
            }

            return;
        }

    }

    public void MakeBumpSoundP1P2(NoGoZone inZone, float inPower, Player inPlayer)
    {
        float volRatio = Utilities.GetRatioP1P2(inPower, 3.0f, 10.0f);
        if (volRatio <= 0.0f) return;

        if (inPower > 5.5f) {
            int randAmount = 3;
            if (inPower > 0.9f) randAmount = 2;

            if (Utilities.GetRand( randAmount) == 0) {
                if (inPlayer == player) (Globals.g_world.audio).PlayRandomShaunImpact();
                else {
                    (Globals.g_world.audio).PlayRandomPigOinkP1(volRatio, inPlayer.position);
                }

            }

        }

        if ((inZone.type == NoGoType.e_Rock) || (inZone.type == NoGoType.e_BigRock)) {
            if ((raceTimer - player.lastRockSoundTime) > 0.1f) {
                if (player.GetDistanceLastFrame() > 5.5f) {
                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_Land, volRatio);
                    player.SetLastRockSoundTime(raceTimer);
                }

            }

        }
        else if (inZone.type == NoGoType.e_Tractor) {
            volRatio *= 3.0f;
            if (volRatio > 0.5f) {
                if (Utilities.GetRand( 3) == 0) (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_TractorBeep);

            }

            if (volRatio > 0.1f) {
                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_MetalHoof, volRatio, inZone.mapPosition);
            }

        }
        else if (inZone.type == NoGoType.e_OilDrum) {
            volRatio *= 2.0f;
            if (volRatio > 1.0f) volRatio = 1.0f;

            Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_HitBarrel, volRatio, inZone.mapPosition);
        }
        else if (inZone.type == NoGoType.e_CrossingThing) {
            volRatio *= 1.2f;
            if (volRatio > 1.0f) volRatio = 1.0f;

            Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_Land, volRatio, inPlayer.position);
            if (Utilities.GetRand( 6) == 0) {
                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_HitCow, volRatio, inPlayer.position);
            }

        }
        else if (inZone.type == NoGoType.e_FlockAnimal) {
            float volRatio1 = Utilities.GetRatioP1P2(inPower, 0.0f, 16.0f);
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_AnimalBump, volRatio1);
        }
        else if (inZone.type == NoGoType.e_Igloo) {
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitWall, volRatio);
        }
        else if (inZone.type == NoGoType.e_Welly) {
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Boing);
        }
        else if (inZone.type == NoGoType.e_StoneWell) {
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitWall, volRatio);
        }
        else if (inZone.type == NoGoType.e_Cart) {
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitTree, volRatio);
        }
        else if (inZone.type == NoGoType.e_Seal) {
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_MudSquelch1, volRatio);
        }
        else if (inZone.type == NoGoType.e_Cow) {
        }
        else if (inZone.type == NoGoType.e_BuildingCorner) {
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitWall, volRatio);
        }
        else if (inZone.type == NoGoType.e_GatePost) {
            float timeSinceTreeBumpSound = (raceTimer - timeOfLastTreeBumpSound);
            if (timeSinceTreeBumpSound >= 0.2f) {
                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitTree, volRatio * 0.83f);
                timeOfLastTreeBumpSound = raceTimer;
            }

        }
        else if (inZone.type == NoGoType.e_Tree) {
            float timeSinceTreeBumpSound = (raceTimer - timeOfLastTreeBumpSound);
            if (timeSinceTreeBumpSound >= 0.2f) {
                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitTree, volRatio);
                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitBarrel, volRatio * 0.55f);
                timeOfLastTreeBumpSound = raceTimer;
                if (Utilities.GetRand( 3) == 0) {
                    this.PlayRandomTreeBumpSound();
                }

            }

        }

    }

    public void HandlePlayerOnPlayerBumpP1P2(Player player1, Player player2, float noGoRadius)
    {
        CGPoint vectorBetweenPlayers = Utilities.CGPointMake(player1.GetPosition().x - player2.GetPosition().x, player1.GetPosition().y - player2.GetPosition().y);
        CGPoint midPoint = Utilities.CGPointMake(player1.GetPosition().x - (vectorBetweenPlayers.x * 0.5f), player1.GetPosition().y - (vectorBetweenPlayers.y * 0.5f));
        vectorBetweenPlayers = Utilities.Normalise(vectorBetweenPlayers);
        CGPoint playerOffset = Utilities.CGPointMake(vectorBetweenPlayers.x * noGoRadius * 0.5f, vectorBetweenPlayers.y * noGoRadius * 0.5f);
        CGPoint newPlayerPosition1 = Utilities.CGPointMake(midPoint.x + playerOffset.x, midPoint.y + playerOffset.y);
        CGPoint newPlayerPosition2 = Utilities.CGPointMake(midPoint.x - playerOffset.x, midPoint.y - playerOffset.y);
        player1.SetPlayerPosition(newPlayerPosition1);
        player2.SetPlayerPosition(newPlayerPosition2);
    }

    public void HandlePlayerOnPlayerHeadBumpP1P2P3(Player player1, CGPoint usePlayerPosition, Player player2, float noGoRadius)
    {
        CGPoint vectorBetweenPlayers = Utilities.CGPointMake(usePlayerPosition.x - player2.GetPosition().x, usePlayerPosition.y - player2.GetPosition().y);
        CGPoint midPoint = Utilities.CGPointMake(usePlayerPosition.x - (vectorBetweenPlayers.x * 0.5f), usePlayerPosition.y - (vectorBetweenPlayers.y * 0.5f));
        vectorBetweenPlayers = Utilities.Normalise(vectorBetweenPlayers);
        CGPoint playerOffset = Utilities.CGPointMake(vectorBetweenPlayers.x * noGoRadius * 0.5f, vectorBetweenPlayers.y * noGoRadius * 0.5f);
        CGPoint newPlayerPosition1 = Utilities.CGPointMake(midPoint.x + playerOffset.x, midPoint.y + playerOffset.y);
        CGPoint newPlayerPosition2 = Utilities.CGPointMake(midPoint.x - playerOffset.x, midPoint.y - playerOffset.y);
        CGPoint headBodyOffset;
        headBodyOffset.x = usePlayerPosition.x - player1.position.x;
        headBodyOffset.y = usePlayerPosition.y - player1.position.y;
        newPlayerPosition1.x -= headBodyOffset.x;
        newPlayerPosition1.y -= headBodyOffset.y;
        player1.SetPlayerPosition(newPlayerPosition1);
        player2.SetPlayerPosition(newPlayerPosition2);
    }

    public void TreeDropApplesP1(Tree inTree, Player inPlayer)
    {
        CGPoint position = inTree.position;
        const int kMaxNumHeads = 7;
        FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
        info.addUnderPlayer = false;
        CGPoint[] startPositionOffset = new CGPoint[kMaxNumHeads];
        int numHeads;
        numHeads = 7;
        startPositionOffset[5] = Utilities.CGPointMake(-47, -27);
        startPositionOffset[4] = Utilities.CGPointMake(-35, 5);
        startPositionOffset[3] = Utilities.CGPointMake(-14, -37);
        startPositionOffset[6] = Utilities.CGPointMake(14, -40);
        startPositionOffset[2] = Utilities.CGPointMake(17, 20);
        startPositionOffset[1] = Utilities.CGPointMake(-3, 3);
        startPositionOffset[0] = Utilities.CGPointMake(45, -15);
        for (int i = 0; i < numHeads; i++) {
            startPositionOffset[i].y += 100;
        }

        info.type = FlowerHeadType.kFlowerHead_Apple;
        for (int i = 0; i < numHeads; i++) {
            info.position = Utilities.CGPointMake(position.x + startPositionOffset[i].x, position.y + startPositionOffset[i].y);
            float directionMulti = 3 - (Utilities.GetABS((((float) numHeads) / 2) - ((float) i)));
            float randVelocity = (((float)(Utilities.GetRand( 4))) / 10) + 0.4f;
            directionMulti *= randVelocity;
            float circleSize = Constants.PI_ - 1;
            float perThing = circleSize / ((float) numHeads);
            float angle = (inPlayer.moveAngle - Constants.HALF_PI) - (circleSize / 2) + (perThing * ((float) i));
            float outSpeed = 3.2f;
            info.velocity = Utilities.GetVectorFromAngleP1(angle, outSpeed);
            info.velocity.x += (0.8f * ((Globals.g_world.GetGame()).GetPlayer()).GetSpeed().x);
            info.velocity.x *= 0.65f;
            info.velocity.y = 1.5f;
            info.velocity.x = startPositionOffset[i].x / 32.0f;
            info.rotation = -angle;
            info.position = Utilities.CGPointMake(info.position.x + info.velocity.x * directionMulti, info.position.y + info.velocity.y * directionMulti);
            int freeHead = (Globals.g_world.game).GetFreeFlowerHead();
            if (freeHead != -1) {
                ((Globals.g_world.game).GetFlowerHead(freeHead)).AddToScene(info);
            }

        }

    }

    public void AddGnomePiecesP1(MapObject inGnome, Player inPlayer)
    {
        CGPoint position = inGnome.position;
        const int kMaxNumHeads = 4;
        FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
        info.addUnderPlayer = false;
        CGPoint[] startPositionOffset = new CGPoint[kMaxNumHeads];
        int numHeads;
        numHeads = 4;
        startPositionOffset[3] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-34.0f, -14.0f), -37);
        startPositionOffset[2] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(10.0f, 27.0f), 20);
        startPositionOffset[1] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-13.0f, 5.0f), 20);
        startPositionOffset[0] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(33.0f, 45.0f), -15);
        for (int i = 0; i < numHeads; i++) {
            startPositionOffset[i].x *= 0.5f;
            startPositionOffset[i].y *= 0.5f;
            startPositionOffset[i].y -= 20.0f;
        }

        info.type = FlowerHeadType.kFlowerHead_GnomePiece;
        for (int i = 0; i < numHeads; i++) {
            info.position = Utilities.CGPointMake(position.x + startPositionOffset[i].x, position.y + startPositionOffset[i].y);
            float directionMulti = 3 - (Utilities.GetABS((((float) numHeads) / 2) - ((float) i)));
            float randVelocity = (((float)(Utilities.GetRand( 4))) / 10) + 0.4f;
            directionMulti *= randVelocity;
            float circleSize = Constants.PI_ - 1;
            float perThing = circleSize / ((float) numHeads);
            float angle = (inPlayer.moveAngle - Constants.HALF_PI) - (circleSize / 2) + (perThing * ((float) i));
            info.velocity.y = 2.3f;
            info.velocity.x = startPositionOffset[i].x / 11.0f;
            info.rotation = -angle;
            info.position = Utilities.CGPointMake(info.position.x + info.velocity.x * directionMulti, info.position.y + info.velocity.y * directionMulti);
            int freeHead = (Globals.g_world.game).GetFreeFlowerHead();
            if (freeHead != -1) {
                ((Globals.g_world.game).GetFlowerHead(freeHead)).AddToScene(info);
            }

        }

    }

    public void AddVegetablePiecesP1P2(MapObject inVeg, NoGoZone inZone, Player inPlayer)
    {
        CGPoint position = inVeg.position;
        const int kMaxNumHeads = 6;
        FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
        info.addUnderPlayer = false;
        CGPoint[] startPositionOffset = new CGPoint[kMaxNumHeads];
        int numHeads;
        numHeads = Utilities.GetRand( 4) + 3;
        startPositionOffset[4] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-30.0f, 30.0f), Utilities.GetRandBetweenP1(-30.0f, 30.0f));
        startPositionOffset[5] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-30.0f, 30.0f), Utilities.GetRandBetweenP1(-30.0f, 30.0f));
        switch (inZone.type) {
        case NoGoType.e_Pumpkin :
            startPositionOffset[3] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-34.0f, -14.0f), -37);
            startPositionOffset[2] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(10.0f, 27.0f), 20);
            startPositionOffset[1] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-13.0f, 5.0f), 8);
            startPositionOffset[0] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(33.0f, 45.0f), -15);
            info.type = FlowerHeadType.kFlowerHead_PumpkinPiece;
            break;
        case NoGoType.e_Squash :
            startPositionOffset[3] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-34.0f, -14.0f), -37);
            startPositionOffset[2] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(10.0f, 27.0f), 20);
            startPositionOffset[1] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-13.0f, 5.0f), 8);
            startPositionOffset[0] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(33.0f, 45.0f), -15);
            info.type = FlowerHeadType.kFlowerHead_SquashPiece;
            break;
        case NoGoType.e_Courgette :
            startPositionOffset[3] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-34.0f, -14.0f), -37);
            startPositionOffset[2] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(10.0f, 27.0f), 20);
            startPositionOffset[1] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(-13.0f, 5.0f), 8);
            startPositionOffset[0] = Utilities.CGPointMake(Utilities.GetRandBetweenP1(33.0f, 45.0f), -15);
            info.type = FlowerHeadType.kFlowerHead_CourgettePiece;
            break;
        default :
            Globals.Assert(false);
            break;
        }

        for (int i = 0; i < numHeads; i++) {
            info.position = Utilities.CGPointMake(position.x + startPositionOffset[i].x, position.y + startPositionOffset[i].y);
            float directionMulti = 3 - (Utilities.GetABS((((float) numHeads) / 2) - ((float) i)));
            float randVelocity = (((float)(Utilities.GetRand( 4))) / 10) + 0.4f;
            directionMulti *= randVelocity;
            float circleSize = Constants.PI_ - 1;
            float perThing = circleSize / ((float) numHeads);
            float angle = (inPlayer.moveAngle - Constants.HALF_PI) - (circleSize / 2) + (perThing * ((float) i));
            info.velocity.y = Utilities.GetRandBetweenP1(2.0f, 4.0f);
            info.velocity.x = startPositionOffset[i].x / 11.0f;
            if (Utilities.GetRand( 3) == 0) {
                info.velocity.x *= 0.5f;
                info.velocity.y *= 0.5f;
            }

            info.rotation = -angle;
            info.position = Utilities.CGPointMake(info.position.x + info.velocity.x * directionMulti, info.position.y + info.velocity.y * directionMulti);
            int freeHead = (Globals.g_world.game).GetFreeFlowerHead();
            if (freeHead != -1) {
                ((Globals.g_world.game).GetFlowerHead(freeHead)).AddToScene(info);
            }

        }

    }

    bool BumpGnomeP1(float bumpPower, NoGoZone inZone)
    {
        if (bumpPower > 4.0f) {
            if (inZone.stillHasMapObject) {
                int moId = inZone.objectId;
                (mapObject[moId]).SetSubTextureId((int)World.Enum3.kGTGrass_GnomeSmashed);
                (mapObject[moId]).SetFlaggedToSwapbackwardNextFrame(true);
                (mapObject[moId]).SetBaseList((int) ListType.e_RenderUnderPlayer);
                CGPoint newPosition = (mapObject[moId]).position;
                newPosition.y += 44.0f;
                newPosition.x -= 3.0f;
                (mapObject[moId]).SetPosition(newPosition);
                this.AddGnomePiecesP1(mapObject[moId], player);
            }

            return true;
        }

        return false;
    }

    bool BumpVegetableP1(float bumpPower, NoGoZone inZone)
    {
        if (bumpPower > 4.0f) {
            if (inZone.stillHasMapObject) {
                int moId = inZone.objectId;
                CGPoint newPosition = (mapObject[moId]).position;
                switch (inZone.type) {
                case NoGoType.e_Pumpkin :
                    (mapObject[moId]).SetSubTextureId((int)World.Enum2.kGTMud_PumpkinSmashed);
                    break;
                case NoGoType.e_Squash :
                    (mapObject[moId]).SetSubTextureId((int)World.Enum2.kGTMud_SquashSmashed);
                    break;
                case NoGoType.e_Courgette :
                    (mapObject[moId]).SetSubTextureId((int)World.Enum2.kGTMud_CourgetteSmashed);
                    break;
                default :
                    Globals.Assert(false);
                    break;
                }

                (mapObject[moId]).SetFlaggedToSwapbackwardNextFrame(true);
                (mapObject[moId]).SetBaseList((int) ListType.e_RenderUnderPlayer);
                newPosition.y += 44.0f;
                newPosition.x -= 3.0f;
                (mapObject[moId]).SetPosition(newPosition);
                this.AddVegetablePiecesP1P2(mapObject[moId], inZone, player);
            }

            return true;
        }

        return false;
    }

    public void BumpAppleTreeP1P2(float bumpPower, NoGoZone inZone, Player inPlayer)
    {
        if (bumpPower > 4.0f) {
            Tree useTree = tree[inZone.objectId];
            useTree.Bump();
            if ((useTree.type == TreeType.kTree_AppleTree) && (useTree.stillHasApples)) {
                if (useTree.stillHasMapObject) {
                    (mapObject[useTree.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_TreeTop1);
                    this.TreeDropApplesP1(useTree, inPlayer);
                }

                inPlayer.KnockedApplesOffTree();
            }

            useTree.SetStillHasApples(false);
        }

    }

    public void UpdateNoGoZoneP1P2(NoGoZone inZone, Player inPlayer, bool isPlayerHead)
    {
        if (inZone.goneInactive) return;

        if (inPlayer.positionZ > inZone.ceilingHeight) return;

        if (inPlayer.positionZ < inZone.groundLevel) return;

        CGPoint usePlayerPosition;
        float useZoneRadius;
        if (isPlayerHead) {
            float ratio = Utilities.GetRatioP1P2(stateTimer, 0.0f, 0.3f);
            useZoneRadius = inZone.GetRadius() * 0.8f * ratio;
            usePlayerPosition = inPlayer.GetHeadPosition();
        }
        else {
            useZoneRadius = inZone.GetRadius();
            usePlayerPosition = inPlayer.GetPosition();
        }

        float noGoRadiusMax = useZoneRadius + Constants.kPlayerRadius;
        if ((inZone.GetPosition().y >= (usePlayerPosition.y - noGoRadiusMax)) && (inZone.GetPosition().y <= (usePlayerPosition.y + noGoRadiusMax))) {
            float diff;
            float radiusHeightRatio;
            if (inZone.type == NoGoType.e_Piggy) {
                diff = Utilities.GetABS((inPlayer.positionZ - (playerPiggy[inZone.objectId]).positionZ));
                radiusHeightRatio = 0.3f;
            }
            else if ((inZone.type == NoGoType.e_StoneWell) || (inZone.type == NoGoType.e_StoneWallPost)) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 5.0f;
            }
            else if (inZone.type == NoGoType.e_Crocodile) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 5.0f;
            }
            else if (inZone.type == NoGoType.e_Chimney) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 0.3f;
            }
            else if (inZone.type == NoGoType.e_Tractor) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 5.0f;
            }
            else if ((inZone.type == NoGoType.e_Cow) || (inZone.type == NoGoType.e_CrossingThing)) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 2.5f;
            }
            else if (inZone.type == NoGoType.e_Igloo) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 5.0f;
            }
            else if (inZone.type == NoGoType.e_Seal) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 5.0f;
            }
            else if (inZone.type == NoGoType.e_Trampoline) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 5.0f;
            }
            else if (inZone.type == NoGoType.e_Bridge) {
                diff = inPlayer.positionZ - inPlayer.GetGroundLevel();
                radiusHeightRatio = 5.0f;
            }
            else if (inZone.type == NoGoType.e_BigRock) {
                diff = inPlayer.positionZ;
                radiusHeightRatio = 5.0f;
            }
            else if (inZone.type == NoGoType.e_HayStack) {
                diff = inPlayer.positionZ;
                radiusHeightRatio = 5.0f;
            }
            else if (inZone.type == NoGoType.e_FlockAnimal) {
                diff = inPlayer.positionZ;
                radiusHeightRatio = 1.2f;
            }
            else if ((inZone.type == NoGoType.e_HayBale) || (inZone.type == NoGoType.e_BuildingCorner)) {
                diff = inPlayer.positionZ;
                radiusHeightRatio = 12.0f;
            }
            else if (inZone.type == NoGoType.e_Pumpkin) {
                diff = inPlayer.positionZ - inZone.groundLevel;
                radiusHeightRatio = 12.0f;
            }
            else {
                diff = inPlayer.positionZ;
                radiusHeightRatio = 0.3f;
            }

            float noGoRadius = 1 - Utilities.GetRatioP1P2(diff, 0, (noGoRadiusMax * radiusHeightRatio));
            noGoRadius *= noGoRadiusMax;
            float distanceSqr = Utilities.GetSqrDistanceP1(inZone.GetPosition(), usePlayerPosition);
            if (distanceSqr <= (noGoRadius * noGoRadius)) {
                if (inZone.type == NoGoType.e_Piggy) {
                }
                else {
                    inPlayer.EndMaxSpeed();
                }

                if (inZone.isBouncable) {
                    if (inPlayer.prevPositionZ > inZone.ceilingHeight) {
                        float oldZVel = inPlayer.zVelocity;
                        inPlayer.SetPositionZ(inZone.ceilingHeight + 0.1f);
                        if (oldZVel < 0.0f) {
                            const float kBounceSlowYFactor = 0.75f;
                            float howBouncy;
                            if (inZone.type == NoGoType.e_Seal) {
                                howBouncy = 0.9f;
                            }
                            else if (inZone.type == NoGoType.e_Trampoline) {
                                howBouncy = 1.5f;
                            }
                            else {
                                howBouncy = 0.5f;
                            }

                            if (inZone.type == NoGoType.e_Crocodile) {
                                float kCrocBounceY = 2.0f;
                                float kCrocBounceZ = 5.0f;
                                FlowerCliff theRiver = river[inPlayer.inRiver];
                                float cliffEnd = theRiver.yCliffStart + theRiver.yCliffLength;
                                float distanceFromEnd = cliffEnd - usePlayerPosition.y;
                                if (distanceFromEnd < 160.0f) {
                                    kCrocBounceZ = 8.0f;
                                    kCrocBounceY = 5.0f;
                                }

                                inPlayer.SetZVelocity(kCrocBounceZ);
                                CGPoint oldSpeed = inPlayer.GetActualSpeed();
                                inPlayer.SetNewSpeed(Utilities.CGPointMake(oldSpeed.x, kCrocBounceY));
                            }
                            else {
                                inPlayer.SetZVelocity(-oldZVel * howBouncy);
                                CGPoint oldSpeed = inPlayer.GetActualSpeed();
                                if (oldSpeed.y > 6.0f) {
                                    inPlayer.SetNewSpeed(Utilities.CGPointMake(oldSpeed.x, oldSpeed.y * kBounceSlowYFactor));
                                }

                            }

                            if (inZone.type == NoGoType.e_Trampoline) {
                                if (inPlayer == player) {
                                    if ((trampoline[inZone.objectId]).hasLeapTarget) {
                                        inPlayer.CheckJumpLengthAdjustmentFromTrampoline((trampoline[inZone.objectId]).leapTarget);
                                    }
                                    else {
                                        inPlayer.FinishJumpAdjusting();
                                    }

                                }

                            }
                            else {
                                inPlayer.FinishJumpAdjusting();
                            }

                            if (oldZVel < -1.5f) {
                                float volume = 1.0f * (1.0f - Utilities.GetRatioP1P2(oldZVel, -5.0f, -1.5f));
                                switch (inZone.type) {
                                case NoGoType.e_Tractor :
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_MetalHoof, volume);
                                    (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_TractorBeep, 0.3f);
                                    break;
                                case NoGoType.e_Seal :
                                    (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_MudSquelch1);
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_Boing, 0.5f);
                                    break;
                                case NoGoType.e_Igloo :
                                case NoGoType.e_StoneWell :
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_RunHard1, volume);
                                    break;
                                case NoGoType.e_Cow :
                                case NoGoType.e_CrossingThing :
                                case NoGoType.e_FlockAnimal :
                                    (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_Land, volume);
                                    (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_HitCow, 0.3f);
                                    break;
                                case NoGoType.e_Trampoline :
                                    (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Boing);
                                    break;
                                default :
                                    break;
                                }

                            }

                        }

                        return;
                    }

                }

                Utilities.CollisionResults newVelocity;
                Utilities.CollisionData inData;
                inData.sphereMass2 = 1.0f;
                if ((inZone.type == NoGoType.e_Rock) || (inZone.type == NoGoType.e_BigRock) || (inZone.type == NoGoType.e_Tree)) {
                    inData.sphereMass2 = 1.65f;
                }

                if (inZone.type == NoGoType.e_OilDrum) {
                    inData.sphereMass2 = 2;
                }
                else if (inZone.type == NoGoType.e_Igloo) {
                    inData.sphereMass2 = 1.0f;
                }
                else if (inZone.type == NoGoType.e_Seal) {
                    inData.sphereMass2 = 2.0f;
                }
                else if (inZone.type == NoGoType.e_Bollard) {
                    inData.sphereMass2 = 0.25f;
                }
                else if (inZone.type == NoGoType.e_Cauliflower) {
                    inData.sphereMass2 = 0.25f;
                }
                else if (inZone.type == NoGoType.e_Bucket) {
                    inData.sphereMass2 = 0.5f;
                }
                else if (inZone.type == NoGoType.e_Piggy) {
                    inData.sphereMass2 = 0.35f;
                }
                else if (inZone.type == NoGoType.e_Welly) {
                    inData.sphereMass2 = 0.5f;
                }
                else if ((inZone.type == NoGoType.e_Cow) || (inZone.type == NoGoType.e_CrossingThing)) {
                    inData.sphereMass2 = 2.2f;
                }
                else if (inZone.type == NoGoType.e_Gnome) {
                    inData.sphereMass2 = 0.2f;
                }
                else if (inZone.type == NoGoType.e_Tractor) {
                    inData.sphereMass2 = 3.0f;
                }
                else if ((inZone.type == NoGoType.e_Squash) || (inZone.type == NoGoType.e_Pumpkin) || (inZone.type == NoGoType.
                  e_Courgette)) {
                    inData.sphereMass2 = 0.2f;
                }

                inData.sphereMass1 = 1;
                inData.sphereRadius1 = 1;
                inData.sphereVelocity1 = inPlayer.GetActualSpeed();
                if (inZone.type == NoGoType.e_FlockAnimal) {
                    inData.sphereVelocity2 = Utilities.CGPointMake(0.0f, 6.5f);
                }
                else if (inZone.type == NoGoType.e_Piggy) {
                    inData.sphereVelocity2 = (playerPiggy[inZone.objectId]).GetActualSpeed();
                }
                else {
                    inData.sphereVelocity2 = Utilities.CGPointMake(0, 0);
                }

                inData.spherePosition1 = usePlayerPosition;
                inData.spherePosition2 = inZone.GetPosition();
                inData.sphereRadius2 = Utilities.GetDistanceP1(inData.spherePosition1, inData.spherePosition2);
                inData.sphereRadius2 -= 1.0f;
                if (inZone.type != NoGoType.e_Piggy) {
                    if ((raceTimer - inZone.collidedTime) > 0.5f) {
                        newVelocity = Utilities.GetSphereCollisionResults(inData);
                        float bumpPower = Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), newVelocity.sphereVelocity2);
                        this.MakeBumpSoundP1P2(inZone, bumpPower, inPlayer);
                        float racingBrainHitGenericTimeRatio = 1.0f;
                        if (inZone.type == NoGoType.e_HayBale) {
                            if (bumpPower > 4.8f) {
                                (hayBale[inZone.objectId]).BurstBaleP1(newVelocity.sphereVelocity2, usePlayerPosition);
                                inPlayer.HitHayBale();
                                inZone.SetGoneInactive(true);
                                return;
                            }

                        }
                        else if (inZone.type == NoGoType.e_Cactus) {
                            CGPoint ouchVelocity = Utilities.CGPointMake(inZone.mapPosition.x - usePlayerPosition.x, inZone.mapPosition.y - usePlayerPosition.y);
                            ouchVelocity = Utilities.Normalise(ouchVelocity);
                            newVelocity.sphereVelocity1.x -= ouchVelocity.x * 5.0f;
                            newVelocity.sphereVelocity1.y -= ouchVelocity.y * 5.0f;
                            inPlayer.SetZVelocity(3.0f);
                            if (Utilities.GetRand( 3) == 0) {
                                (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Baa1 + Utilities.GetRand( 3));
                            }

                        }
                        else if (inZone.type == NoGoType.e_HayStack) {
                            if (bumpPower > 4.0f) {
                                (hayBale[inZone.objectId]).BurstBaleP1(newVelocity.sphereVelocity2, usePlayerPosition);
                                inPlayer.HitHayStack(inZone.objectId);
                                inZone.SetGoneInactive(true);
                                return;
                            }

                        }
                        else if (inZone.type == NoGoType.e_Bucket) {
                            ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                            info.type = EffectType.kEffect_SplashRing;
                            info.inList = ParticleList.t_BeforePlayer;
                            info.velocity = newVelocity.sphereVelocity2;
                            info.startPosition = inData.spherePosition2;
                            float groundLevelYThing = Utilities.kYShiftForZ * inPlayer.positionZ;
                            info.startPosition.y -= groundLevelYThing;
                            info.rotation = Utilities.GetAngleFromXYP1(newVelocity.sphereVelocity2.x, newVelocity.sphereVelocity2.y);
                            (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Splash);
                            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_ChickenPop);
                            inZone.SetGoneInactive(true);
                            (mapObject[inZone.objectId]).SetFlaggedToRemoveNextFrame(true);
                            this.AddFlyingBucketP1(inData.spherePosition2, newVelocity.sphereVelocity2);
                        }
                        else if (inZone.type == NoGoType.e_Bollard) {
							if (inPlayer.racingBrain != null)
								{
	                            (inPlayer.racingBrain).HitGeneric(0.5f);
								}
                            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_ChickenPop);
                            inZone.SetGoneInactive(true);
                            if (inZone.stillHasMapObject) {
                                (mapObject[inZone.objectId]).SetFlaggedToRemoveNextFrame(true);
                            }

                            this.AddFlyingBollardP1(inData.spherePosition2, newVelocity.sphereVelocity2);
                        }
                        else if (inZone.type == NoGoType.e_Cauliflower) {
                            inPlayer.SetHitVeg(true);
								if (inPlayer.racingBrain != null)
		                            (inPlayer.racingBrain).HitGeneric(0.5f);
                            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_ChickenPop);
                            inZone.SetGoneInactive(true);
                            if (inZone.stillHasMapObject) {
                                (mapObject[inZone.objectId]).SetFlaggedToRemoveNextFrame(true);
                            }

                            this.AddFlyingCauliP1(inData.spherePosition2, newVelocity.sphereVelocity2);
                        }
                        else if (inZone.type == NoGoType.e_Cow) {
                            float bumpPower1 = Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), newVelocity.sphereVelocity2);
                            int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                            if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass10_1_LotsOfSheep) {
                                racingBrainHitGenericTimeRatio = 0.7f;
                            }
                            else if ((realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep) || (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass9_3_BaleLines)) {
                                racingBrainHitGenericTimeRatio = 0.5f;
                            }
                            else if ((realLevelId == (int)LevelBuilder_Ross.Enum2.kMud7_8_SquashDodge) || (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud10_2_MarrowField)) {
                                racingBrainHitGenericTimeRatio = 0.4f;
                            }

                            if (inPlayer == player) {
                                if (bumpPower1 > 2.0f) inPlayer.SetHitFlock(true);

                            }

                            if ((cow[inZone.objectId]).knockedOver) {
                                float volume = Utilities.GetRatioP1P2(bumpPower1, 3, 8);
                                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_Land, volume);
                            }
                            else {
                                (cow[inZone.objectId]).BumpedInto(bumpPower1);
                                inPlayer.HitCow(bumpPower1);
                            }

                        }
                        else if (inZone.type == NoGoType.e_CrossingThing) {
                            Globals.Assert(inZone.objectId < numGameObject[(int) GameObjectType.kGameObject_CrossingThing]);
                            CrossingThing thing = crossingThing[inZone.objectId];
                            if (inPlayer == player) {
                                float bumpPowerSqr = thing.GetBumpPowerSqr(newVelocity.sphereVelocity2);
                                if (bumpPowerSqr > 9.0f) inPlayer.SetHitFlock(true);

                                #if NOT_FINAL_VERSION
                                #endif

                            }

                            int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                            if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass10_1_LotsOfSheep) {
                                racingBrainHitGenericTimeRatio = 0.5f;
                            }
                            else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep) {
                                racingBrainHitGenericTimeRatio = 0.4f;
                            }

                            thing.BumpP1(newVelocity.sphereVelocity2, inPlayer);
                        }
                        else if (inZone.type == NoGoType.e_Welly) 
							{
								if (inPlayer.racingBrain != null)
		                            (inPlayer.racingBrain).HitGeneric(0.5f);
        
								inZone.SetGoneInactive(true);
                            if (inZone.stillHasMapObject) {
                                (mapObject[inZone.objectId]).SetFlaggedToRemoveNextFrame(true);
                                (mapObject[inZone.shadowObjectId]).SetFlaggedToRemoveNextFrame(true);
                            }

                            this.AddFlyingWellyP1(inData.spherePosition2, newVelocity.sphereVelocity2);
                        }
                        else if (inZone.type == NoGoType.e_Piggy) {
                        }
                        else if (inZone.type == NoGoType.e_FlockAnimal) {
                            int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                            if ((realLevelId == (int)LevelBuilder_Ross.Enum2.kMud3_7_PenCup_Race7_Migration) || (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass9_3_BaleLines) || (realLevelId ==
                              (int)LevelBuilder_Ross.Enum2.kMud3_6_PenCup_Race6_PCurvy) || (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud3_1_PenCup_Race1_IceHoles)) {
                                racingBrainHitGenericTimeRatio = 0.5f;
                            }

                            float thisBumpPower = ((flock[inZone.objectId]).GetAnimal(inZone.shadowObjectId)).BumpP1(newVelocity.sphereVelocity2, 
                              inPlayer);
                            inPlayer.HitFlockSheep(thisBumpPower);
                        }
                        else if (inZone.type == NoGoType.e_Tree) {
							if (inPlayer.racingBrain != null)
								{
		                            (inPlayer.racingBrain).HitGeneric(0.5f);
								}
                            this.BumpAppleTreeP1P2(bumpPower, inZone, inPlayer);
                            inPlayer.HitTree(bumpPower);
                        }
                        else if (inZone.type == NoGoType.e_OilDrum) {
                            if (inPlayer == player) {
                                if (usePlayerPosition.y <= (inZone.mapPosition.y + 30.0f)) {
                                    if (bumpPower > 3.0f) inPlayer.SetHitBarrel(true);

                                }

                            }
                            else {
                                int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                                if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMudN1_5_StarStables) {
                                    racingBrainHitGenericTimeRatio = 0.5f;
                                }
                                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud8_2_BarrelThing) {
                                    racingBrainHitGenericTimeRatio = 0.4f;
                                }

                            }

                        }
                        else if (inZone.type == NoGoType.e_Gnome) {
                            bool smashed = this.BumpGnomeP1(bumpPower, inZone);
                            inZone.SetGoneInactive(true);
                            inPlayer.HitGnome(smashed);
                            return;
                        }
                        else if ((inZone.type == NoGoType.e_Pumpkin) || (inZone.type == NoGoType.e_Squash) || (inZone.type == NoGoType.
                          e_Courgette)) {
                            if (this.BumpVegetableP1(bumpPower, inZone)) {
                                inZone.SetGoneInactive(true);
                                inPlayer.HitVegetable((int)inZone.type);
                                return;
                            }

                        }
                        else if (inZone.type == NoGoType.e_Tractor) {
                            if (inPlayer.playerId > 0) {
                                int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                                if ((realLevelId == (int)LevelBuilder_Ross.Enum2.kMud_Harvest) || (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud5_3_FrmCup_Race3_TractorFactor) || (realLevelId ==
                                  (int)LevelBuilder_Ross.Enum2.kMud_RoadCrossingsFlowers) || (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud10_2_MarrowField) || (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud5_4_FrmCup_Race4_AlleyHogs) ||
                                  (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud2_7_MudCup_Race7_BarrelsOfFun)) {
                                    if ((realLevelId != (int)LevelBuilder_Ross.Enum2.kMud2_7_MudCup_Race7_BarrelsOfFun) || (inPlayer.playerId == 1)) {
                                        CGPoint vectorFromMiddle = Utilities.CGPointMake(usePlayerPosition.x - inZone.GetPosition().x, usePlayerPosition.y - inZone.
                                          GetPosition().y);
                                        vectorFromMiddle = Utilities.Normalise(vectorFromMiddle);
                                        vectorFromMiddle.x = vectorFromMiddle.x * noGoRadius;
                                        vectorFromMiddle.y = vectorFromMiddle.y * noGoRadius;
                                        CGPoint newPlayerPosition = Utilities.CGPointMake(inZone.GetPosition().x + vectorFromMiddle.x, inZone.GetPosition().y +
                                          vectorFromMiddle.y);
                                        inPlayer.SetPlayerPosition(newPlayerPosition);
                                        (inPlayer.racingBrain).HitGeneric(0.4f);
                                        inZone.SetCollidedTime(raceTimer);
                                        return;
                                    }

                                }

                            }

                        }
							
						if (inPlayer.racingBrain != null)
							{
	                        (inPlayer.racingBrain).HitGeneric(racingBrainHitGenericTimeRatio);
							}
                        inPlayer.SetNewSpeed(newVelocity.sphereVelocity1);
                        inZone.SetCollidedTime(raceTimer);
                        inPlayer.ResetSkidThing();
                    }

                }
                else {
                    newVelocity = Utilities.GetSphereCollisionResults(inData);
                    CGPoint diff1 = Utilities.CGPointMake(newVelocity.sphereVelocity2.x - inData.sphereVelocity2.x, newVelocity.sphereVelocity2.y - inData.sphereVelocity2
                      .y);
                    float bumpPower = Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), diff1);
                    this.MakeBumpSoundPlayersP1P2P3(inPlayer, playerPiggy[inZone.objectId], inZone, bumpPower);
                    if (isPlayerHead) {
                        this.HandlePlayerOnPlayerHeadBumpP1P2P3(inPlayer, usePlayerPosition, playerPiggy[inZone.objectId], noGoRadius);
                    }
                    else {
                        this.HandlePlayerOnPlayerBumpP1P2(inPlayer, playerPiggy[inZone.objectId], noGoRadius);
                    }

                    if (usePlayerPosition.y < inZone.mapPosition.y) {
                        if ((raceTimer - inZone.collidedTime) > 0.5f) {
                            if (inPlayer == player) {
                                if (bumpPower > 8.8f) {
                                    float newYVelocity = newVelocity.sphereVelocity2.y + inData.sphereVelocity2.y;
                                    newYVelocity /= 2.0f;
                                    CGPoint newPiggyVelocity = Utilities.CGPointMake(newVelocity.sphereVelocity2.x, newYVelocity);
                                    (playerPiggy[inZone.objectId]).SetNewSpeed(newPiggyVelocity);
                                    (playerPiggy[inZone.objectId]).GotBumped();
                                }

                            }

                        }

                    }

                    return;
                }

                CGPoint vectorFromMiddle1 = Utilities.CGPointMake(usePlayerPosition.x - inZone.GetPosition().x, usePlayerPosition.y - inZone.GetPosition().y);
                vectorFromMiddle1 = Utilities.Normalise(vectorFromMiddle1);
                vectorFromMiddle1.x = vectorFromMiddle1.x * noGoRadius;
                vectorFromMiddle1.y = vectorFromMiddle1.y * noGoRadius;
                CGPoint newPlayerPosition1 = Utilities.CGPointMake(inZone.GetPosition().x + vectorFromMiddle1.x, inZone.GetPosition().y + vectorFromMiddle1.y);
                inPlayer.SetPlayerPosition(newPlayerPosition1);
            }

        }

    }

    public void UpdateScrollingBackground(float yOff)
    {

        #if !CAMERA_FOLLOW_PIGGY
            this.UpdateScrollingBackgroundP1(yOff, player.GetPositionForScrollOffset());
        #else
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                this.UpdateScrollingBackgroundP1(yOff, player.GetPositionForScrollOffset());
            }
            else {
                this.UpdateScrollingBackgroundP1(yOff + 30, (playerPiggy[cameraFollowWhichPiggy]).GetPositionForScrollOffset());
            }

        #endif

    }

    public void UpdateScrollingBackgroundP1(float yOff, CGPoint usePos)
    {
        const float kCameraFollowPlayerLag = 0.27f;
        prevScrollPosition = scrollPosition;
        scrollPosition.y = scrollPosition.y + (((usePos.y - yOff) - scrollPosition.y) * kCameraFollowPlayerLag);
        if (scrollPosition.y > (finishYPos - 380)) {
            if (yScrollVelocity == -1) {
                yScrollEndStart = scrollPosition.y;
                yScrollVelocity = scrollPosition.y - prevScrollPosition.y;
            }
            else {
                yScrollVelocity *= 0.9f;
                yScrollEndStart += yScrollVelocity;
            }

            scrollPosition.y = yScrollEndStart;
        }

        const float kXScrollLag = 0.1f;
        float desiredScrollPositionX = Utilities.ConstrainP1P2(usePos.x - Constants.TRACK_CENTRE_LINE, -50.0f, 50.0f);
        scrollPosition.x = scrollPosition.x + ((desiredScrollPositionX - scrollPosition.x) * kXScrollLag);
        float tryMapWidth320;
        float tryMapWidth640;
        float tryMapWidth96;
        if (Globals.deviceIPad) {
            float leftEdge = Globals.g_world.leftDrawEdge + scrollPosition.x;
            float howZoomedOut = Utilities.GetRatioP1P2(Globals.g_world.drawWidth, 384.0f, 640.0f);
            float leftLimit = -10 + (-118.0f * howZoomedOut);
            bool fixedLeft = false;
            if (leftEdge < leftLimit) {
                scrollPosition.x += (leftLimit - leftEdge);
                fixedLeft = true;
            }

            float rightEdge = leftEdge + Globals.g_world.drawWidth;
            float rightLimit = 394.0f + (118.0f * howZoomedOut);
            if (rightEdge > rightLimit) {
                if (fixedLeft) {
                    scrollPosition.x = 0.0f;
                }
                else {
                    scrollPosition.x -= (rightEdge - rightLimit);
                }

            }

        }
        else {
            tryMapWidth320 = 320.0f;
            tryMapWidth640 = 640.0f;
            tryMapWidth96 = 96.0f;
            float mapLeftThing = -tryMapWidth320 + (Globals.g_world.drawWidth / 2.0f);
            float projectedMapStartX = mapLeftThing - scrollPosition.x;
            float edgeExtremeR = Utilities.GetRatioP1P2(Globals.g_world.drawWidth, tryMapWidth320, tryMapWidth640);
            float edgeExtreme = tryMapWidth96 - (64.0f * edgeExtremeR);
            bool didTHing = false;
            if (projectedMapStartX > -edgeExtreme) {
                scrollPosition.x += (projectedMapStartX + edgeExtreme);
                didTHing = true;
            }

            float projectedMapEndX = Globals.g_world.leftDrawEdge + Globals.g_world.drawWidth + scrollPosition.x;
            edgeExtreme = 420.0f + (64.0f * edgeExtremeR);
            if (projectedMapEndX > edgeExtreme) {
                scrollPosition.x -= (projectedMapEndX - edgeExtreme);
            }

        }

    }

    public void UpdatePlayerHitFlowerBunchP1P2(FlowerBunch inBunch, int mId, Player inPlayer)
    {
        if (inPlayer.positionZ >= kFlowerBunchJumpHeight) return;

        if ((inPlayer.position.y > inBunch.hitLine) && (inPlayer.position.y < (inBunch.hitLine + 25))) {
            const float kBunchWidth = 30;
            if (!inBunch.isSquashed) {
                if ((inPlayer.position.x < (inBunch.position.x + kBunchWidth)) && (inPlayer.position.x > (inBunch.position.x - kBunchWidth))) {
                    if (inBunch.stillHasMapObject) {
                        this.CheckAndSwapMapObjectBackward(mId);
                    }

                    inBunch.HitByPlayer();
                    inPlayer.HitFlowerBunch(inBunch);
                    this.AddSomeFlowerHeadsP1P2(inBunch.myId, inPlayer, false);
                }

            }

        }

    }

    public void UpdateFlowerBunch(FlowerBunch inBunch)
    {
        int mId = inBunch.mapObjectId;
        if (inBunch.stillHasMapObject) {
            if (player.positionZ >= kFlowerBunchJumpHeight) {
                if ((mapObject[inBunch.mapObjectId]).listType ==  (int)ListType.e_RenderAbovePlayer) {

                    #if MO_DEBUG
                    #endif

                    this.SwapMapObjectBackward(inBunch.mapObjectId);
                }

            }
            else {
                if (!inBunch.isSquashed) {
                    if ((mapObject[inBunch.mapObjectId]).listType ==  (int)ListType.e_RenderUnderPlayer) {

                        #if MO_DEBUG
                        #endif

                        this.SwapMapObjectForward(inBunch.mapObjectId);
                    }

                }

            }

        }

        this.UpdatePlayerHitFlowerBunchP1P2(inBunch, mId, player);
        for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
            this.UpdatePlayerHitFlowerBunchP1P2(inBunch, mId, playerPiggy[j]);
        }

    }

    public void UpdateStartAndEndOfGameObjectP1P2(GameObjectType inType, float updateYOffset, float endYOffset)
    {
        if (startUpdateId[(int)inType] < numGameObject[(int)inType]) {
            int arrayIndex = ((updateOrder[(int)inType])[startUpdateId[(int)inType]]);
            if ((float)((yPositionListForStart[(int)inType])[arrayIndex]) < (scrollPosition.y + endYOffset)) {
                startUpdateId[(int)inType]++;
            }

        }

        if (endUpdateId[(int)inType] < numGameObject[(int)inType]) {
            int arrayIndex = ((updateOrder[(int)inType])[endUpdateId[(int)inType]]);
            if ((float)((yPositionListForStart[(int)inType])[arrayIndex]) < (scrollPosition.y + updateYOffset)) {
                endUpdateId[(int)inType]++;
            }

        }

    }

    public void UpdateStartAndEndOfGameObjectP1(GameObjectType inType, float updateYOffset)
    {
        this.UpdateStartAndEndOfGameObjectP1P2(inType, updateYOffset, 0);
    }

    public void UpdateFlowerBunches()
    {
        this.UpdateStartAndEndOfGameObjectP1P2( GameObjectType.kGameObject_FlowerBunches, 550.0f + Globals.g_world.mapObjectAppearDistance, -500.0f);
        for (int i = startUpdateId[(int) GameObjectType.kGameObject_FlowerBunches]; i < endUpdateId[(int) GameObjectType.kGameObject_FlowerBunches]; i++) {
            int arrayIndex = ((updateOrder[(int) GameObjectType.kGameObject_FlowerBunches])[i]);
            this.UpdateFlowerBunch(flowerBunch[arrayIndex]);
        }

    }

    public void UpdateFlowerHeads()
    {
    }

    public bool UpdateLevelBuilder_Ross()
    {
        bool quit = false;
        CGPoint bpos = Utilities.CGPointMake(192, -lBuilder.tileMapOffset);
        this.UpdateScrollingBackgroundP1(40, bpos);
        scrollPosition.y = lBuilder.tileMapOffset;
        if (lBuilder.Update()) {
            quit = true;
        }

        for (int i = 0; i <  (int)ListType.Types; i++) this.UpdateMapObjects((ListType)i);

        return quit;
    }

    public void CheckForOvertakeSound()
    {
        int who = (hud.raceMeter).GetOverTakerOfPlayer();
        if (who == -1) {
            return;
        }

        if (who == 0) {
            player.CheckPlayOvertakeSound();
            if (player.positionZ > 10.0f) {
                if (player.state == PlayerState.kPlayerMoving_InAir) {
                    int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                    if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_HighFlier);
                        ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
                    }

                }

            }

        }
        else {
            int whichPiggy = who - 1;
            Globals.Assert(whichPiggy < 3);
            (playerPiggy[whichPiggy]).CheckPlayOvertakeSound();
        }

    }

    public void UpdatePiggies(bool inGetReadyPhase)
    {
						#if PROFILING_OUT
						Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdatePiggies] = DateTime.Now.TimeOfDay.Milliseconds;
						#endif


        if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) return;

        #if SLOW_THE_PIG
            return;
        #endif

        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                (ghostPiggy[i]).UpdateNothingButTheFrame();
                if ((Globals.g_world.frontEnd).exitInfo.multiplayer) {
                    (playerPiggy[i]).UpdateNetworkPlayer();
                }
                else {
                    (playerPiggy[i]).UpdateWithBrain();
                }

            }

        }

						#if PROFILING_OUT
						Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdatePiggies] = DateTime.Now.TimeOfDay.Milliseconds;
						#endif


    }

    public void StartPause()
    {
        this.SetNewGameState( GameState.e_Paused);
        hud.ShowPausedState();

        #if TILE_DEBUG
            outputTileInfo = true;
        #endif

    }

    public void UpdatePaused()
    {
        (Globals.g_world.audio).UpdateTractorSound(false);
        bool pauseEnded = false;
        if ((hud.restartButton).Update()) {
            (hud.restartButton).Throb();
            hud.FlagEndPause();
            (hud.restartButton).SetIsClickable(false);
            (hud.menuButton).SetIsClickable(false);
            (hud.nextLevelButton).SetIsClickable(false);
            (hud.restartButton).Update();
            pauseEnded = true;
        }

        if ((hud.menuButton).Update()) {
            if (!pauseEnded) {
                hud.FlagEndPause();
                (hud.restartButton).SetIsClickable(false);
                (hud.menuButton).SetIsClickable(false);
                (hud.nextLevelButton).SetIsClickable(false);
                (hud.menuButton).Update();
                pauseEnded = true;
            }

        }

        if ((hud.nextLevelButton).Update()) {
            if (!pauseEnded) {
                hud.FlagEndPause();
                (hud.restartButton).SetIsClickable(false);
                (hud.menuButton).SetIsClickable(false);
                (hud.nextLevelButton).SetIsClickable(false);
                (hud.nextLevelButton).Update();
            }

        }

        if ((hud.restartButton).wasPressed) {
            if (((hud.restartButton).zobject).state ==  ZobjectState.kZobjectHidden) {
                if (!(Ztransition.GetTransition()).inTransition) {

                    #if PIGGY_SPEED_ADJUSTMENT_TOOL
                        int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                        speedAdjustmentTool.lastTrySpeed[realLevelId] += Utilities.GetRandBetweenP1(-0.4f, 0.4f);
                        speedAdjustmentTool.whichRunForThisTrack++;
                        speedAdjustmentTool.lastTryTime[realLevelId] = -1.0f;
                    #endif

                    (SoundEngine.Instance()).AVFadeOutAndStop(0.2f);
                    this.ChangeToGameState( GameState.e_GetReady);
                }

            }

        }

        if ((hud.nextLevelButton).wasPressed) {
            if (((hud.nextLevelButton).zobject).state ==  ZobjectState.kZobjectHidden) {
                this.SetNewGameState( GameState.e_GamePlay);
            }

        }

        if ((hud.menuButton).wasPressed) {
            if (((hud.menuButton).zobject).state ==  ZobjectState.kZobjectHidden) {
                goBackToFrontEnd = true;
            }

        }

       // #if ZOOMING_MATRIX_TEST
       // #endif

    }

    public void UpdateCountryGameThings()
    {
        (Globals.g_world.audio).UpdateRandomAnimalSoundCountry(250);
        this.UpdateGameObjectsP1P2( GameObjectType.kGameObject_CrossingThing, 800.0f, -500.0f);
        this.UpdateGameObjectsP1P2( GameObjectType.kGameObject_Tree, 800.0f, -500.0f);
        this.UpdateFlocks();
        this.UpdateBuildings();
        this.UpdateHedges();
        this.UpdateCows();
        this.UpdatePonds();
        this.UpdateCowPats();
        this.UpdateRiversP1(player, false);
        for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
            this.UpdateRiversP1(playerPiggy[j], true);
        }

        this.UpdateStoneWalls(player);
        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                this.UpdateStoneWalls(playerPiggy[i]);
            }

        }

        this.UpdateStartingGates();
        this.UpdateRainbows();
        this.UpdateBoostArrows();
        this.UpdateRamps();
        this.UpdateNoGoZones();
    }

    public void UpdateMudGameThings()
    {
        (Globals.g_world.audio).UpdateRandomAnimalSoundFarm(250);
        this.UpdateGameObjectsP1P2( GameObjectType.kGameObject_CrossingThing, 800.0f, -500.0f);
        this.UpdateGameObjectsP1P2( GameObjectType.kGameObject_Tree, 800.0f, -500.0f);
        this.UpdateChickens(false);
        this.UpdatePonds();
        this.UpdateCows();
        this.UpdateStarSpeedUps();
        this.UpdateStoneWalls(player);
        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                this.UpdateStoneWalls(playerPiggy[i]);
            }

        }

        this.UpdateStartingGates();
        this.UpdateRainbows();
        this.UpdateBoostArrows();
        this.UpdateRamps();
        this.UpdateNoGoZones();
        this.UpdateBuildings();
        this.UpdateHayBales();
        this.UpdateHedges();
        for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Flock]; i++) {
            (flock[i]).UpdateFlockNew();
        }

        this.UpdateRiversP1(player, false);
        for (int j = startFromPiggy; j < lastPiggyIndex; j++) {
            this.UpdateRiversP1(playerPiggy[j], true);
        }

        this.UpdateTractors();
    }

    public void UpdateBonusGameThings()
    {
        if (raceTimer >= kTimeBetweenPigsGoAndYouGo) {
            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Flock]; i++) {
                (flock[i]).UpdateFlockNew();
            }

        }

        this.UpdatePonds();
        this.UpdateStoneWalls(player);
        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                this.UpdateStoneWalls(playerPiggy[i]);
            }

        }

        this.UpdateStartingGates();
        this.UpdateRainbows();
        this.UpdateBoostArrows();
        this.UpdateRamps();
        this.UpdateNoGoZones();
        this.UpdateStarSpeedUps();
        this.UpdateBuildings();
    }

    public void UpdateFlocks()
    {
        if (raceTimer >= kTimeBetweenPigsGoAndYouGo) {

            #if PROFILING_OUT
                Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdateFlock] = DateTime.Now.TimeOfDay.Milliseconds;
            #endif

            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Flock]; i++) {
                (flock[i]).UpdateFlockNew();
            }

            #if PROFILING_OUT
                Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdateFlock] = DateTime.Now.TimeOfDay.Milliseconds;
            #endif

        }

    }

    public void UpdateIceGameThings()
    {
        this.UpdateFlocks();
        this.UpdatePonds();
        this.UpdateStoneWalls(player);
        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                this.UpdateStoneWalls(playerPiggy[i]);
            }

        }

        this.UpdateStartingGates();
        this.UpdateRainbows();
        this.UpdateBoostArrows();
        this.UpdateRamps();
        this.UpdateNoGoZones();
        this.UpdateStarSpeedUps();
        this.UpdateBuildings();
    }

    public void UpdateThumbsControl()
    {
        if ((controlTouchLeft != -1) && (controlTouchRight == -1)) {
            player.SetDirectionButtonRight(false);
            player.SetDirectionButtonLeft(true);
        }
        else if ((controlTouchRight != -1) && (controlTouchLeft == -1)) {
            player.SetDirectionButtonRight(true);
            player.SetDirectionButtonLeft(false);
        }
        else {
            player.SetDirectionButtonRight(false);
            player.SetDirectionButtonLeft(false);
        }

    }

    public void UpdateNetworkGame()
    {
        if ((Globals.g_world.frontEnd).exitInfo.multiplayer) {

        }

    }

    public void UpdateNumberOfPiggiesOnScreen()
    {
    }

    public void UpdateZoomingCameraGetReady()
    {
        const float kRenderScaleLag = 0.02f;
        if (stateTimer > 0.0f) {
            float ratio = Utilities.GetRatioP1P2(stateTimer, 0.0f, 1.75f);
            desiredRenderScale = (kRenderScaleMax - 0.2f) + (0.2f * ratio);
            actualRenderScale += ((desiredRenderScale - actualRenderScale) * kRenderScaleLag);
            Globals.g_world.SetRenderScale(actualRenderScale);
        }

    }

    public void UpdateZoomingCamera()
    {
        const float kRenderScaleLag = 0.015f;
        const float kFinishLineZoomIn = 1000.0f;
        const float kPlayerMaxSpeed = 17.25f;
        const float kPlayerMinSpeed = 2.3f;
        float ratio = 1.0f - Utilities.GetRatioP1P2(player.GetActualSpeed().y, kPlayerMinSpeed, kPlayerMaxSpeed);
						if (Globals.deviceIPhone5)
								desiredRenderScale = kRenderScaleMinIPhone5 + (kRenderScaleRangeIPhone5 * ratio);
						else
								desiredRenderScale = kRenderScaleMin + (kRenderScaleRange * ratio);
        
						if (Globals.deviceIPad) {
            if (desiredRenderScale < 0.6f) {
                desiredRenderScale = 0.6f;
            }

        }

        float distanceFromFinishLine = finishYPos - (player.position.y + 800.0f);
        if (distanceFromFinishLine < kFinishLineZoomIn) {
            float minFromThis = kRenderScaleMax - (distanceFromFinishLine / kFinishLineZoomIn);
            if (minFromThis > kRenderScaleMax) minFromThis = kRenderScaleMax;

            if (desiredRenderScale < minFromThis) desiredRenderScale = minFromThis;

        }

        actualRenderScale += ((desiredRenderScale - actualRenderScale) * kRenderScaleLag);
        Globals.g_world.SetRenderScale(actualRenderScale);
    }

    public void UpdateGamePlay()
    {
        gameTimer += Constants.kFrameRate;
        raceTimer += Constants.kFrameRate;

//						#if PROFILING_OUT
//						Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateTiles] = DateTime.Now.TimeOfDay.Milliseconds;
//						#endif


        #if UP_RACE
            this.UpdateScrollingBackground(80.0f);
        #else
            this.UpdateScrollingBackground(40.0f);
        #endif

        if (((Globals.g_world.frontEnd).profile).preferences.controlFinger) {
        }
        else {
            this.UpdateThumbsControl();
        }

//        #if PLAYING_SIMULATOR_VIDEO
//            playingGhost.UpdateNothingButTheFrame();
//            player.UpdateAsGhost(playingGhost);
//        #else

						#if PROFILING_OUT
						Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdateShaun] = DateTime.Now.TimeOfDay.Milliseconds;
						#endif

            player.Update();
//        #endif
						#if PROFILING_OUT
						Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdateShaun] = DateTime.Now.TimeOfDay.Milliseconds;
						#endif

        #if PROFILING_OUT
            Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdateGameThings] = DateTime.Now.TimeOfDay.Milliseconds;
        #endif

        if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
            this.UpdateCountryGameThings();
        }
        else if (lBuilder.currentScene == (int) SceneType.kSceneMud) {
            this.UpdateMudGameThings();
        }
        else if (lBuilder.currentScene == (int) SceneType.kSceneIce) {
            this.UpdateIceGameThings();
        }
        else {
            this.UpdateBonusGameThings();
        }

        this.UpdateFlowerBunches();

        #if PROFILING_OUT
            Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdateGameThings] = DateTime.Now.TimeOfDay.Milliseconds;
        #endif

        this.UpdatePiggies(false);
        Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateMapObjectsStart] = DateTime.Now.TimeOfDay.Milliseconds;
        for (int i = 0; i <  (int)ListType.Types; i++) this.UpdateMapObjects((ListType)i);

        Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateMapObjectsEnd] = DateTime.Now.TimeOfDay.Milliseconds;
        this.CheckForOvertakeSound();
        this.UpdateFinishLine();
        if (hitClosedGate) {
            this.HitClosedGate();
        }

        for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
            if (i != Constants.RECORDING_WHICH_PIGGY) {
                (playerPiggy[i]).UpdateEndOfFrame();
            }

        }

        #if !PLAYING_SIMULATOR_VIDEO
            playingGhost.UpdatePlaying();
        #endif

        recordingGhost.UpdateRecording();
        player.UpdateEndOfFrame();
        this.UpdateNetworkGame();

     //   #if ZOOMING_MATRIX_TEST
            this.UpdateZoomingCamera();
       // #endif

    }

    public void SetRiverGroundLevel(int whichRiver)
    {
    }

    public void SetGroundLevelFromRiverPositionP1(Player inPlayer, int whichRiver)
    {
        int i = whichRiver;
        float yOffset = inPlayer.GetPosition().y - (river[i]).yCliffStart;
        float groundLevel;
        float cliffEnd = (river[i]).yCliffStart + (river[i]).yCliffLength;
        if (inPlayer.GetPosition().y > cliffEnd) {
            groundLevel = 0;
        }
        else {
            int cliffLength = (int)(river[i]).yCliffLength;
            if (yOffset < kRiverDropLength) {
                float ratio = Utilities.GetCosInterpolationHalfP1P2(yOffset, 0, kRiverDropLength);
                groundLevel = ratio * -Game.kClifffDepth;
            }
            else if (yOffset > (cliffLength - (river[i]).raiseLength)) {
                float ratio = 1.0f - Utilities.GetCosInterpolationHalfP1P2(yOffset, (cliffLength - (river[i]).raiseLength), (cliffLength - kRiverUpSlopeEnd
                  ));
                groundLevel = ratio * -Game.kClifffDepth;
            }
            else {
                groundLevel = -Game.kClifffDepth;
            }

        }

        inPlayer.SetGroundLevel(groundLevel);
    }

    public void UpdateRiversP1(Player inPlayer, bool isPiggy)
    {
        int isOverRiver = -1;
        for (int i = 0; i < numRivers; i++) {
            float cliffEnd = (river[i]).yCliffStart + (river[i]).yCliffLength;
            if (inPlayer.GetPosition().y < cliffEnd) {
                if (inPlayer.GetPosition().y > (river[i]).yCliffStart) {
                    if (inPlayer.positionZ <= 0) {
                        if (inPlayer.inRiver == -1) {
                            if (!this.IsPlayerBalancingOnBridgeP1(inPlayer, i)) {
                                inPlayer.SetInRiver(i);
                                inPlayer.SetIsOverRiver(false);
                            }
                            else {
                                inPlayer.SetGroundLevel(0);
                            }

                        }

                    }
                    else {
                        isOverRiver = i;
                    }

                }

            }

        }

        if (inPlayer.onBridge != -1) {
            int i = inPlayer.onBridge;
            float endCliff = (river[i]).yCliffStart + (river[i]).yCliffLength;
            if (inPlayer.GetPosition().y > endCliff) {
                inPlayer.SetOnBridge(-1);
            }

        }

        if (inPlayer.inRiver == -1) {
            if (isOverRiver != -1) {
                inPlayer.SetIsOverRiver(true);
                if (this.IsPlayerBalancingOnBridgeP1(inPlayer, isOverRiver)) inPlayer.SetGroundLevel(0);
                else {
                    this.SetGroundLevelFromRiverPositionP1(inPlayer, isOverRiver);
                }

            }
            else {
                if (inPlayer.isOverRiver) {
                    inPlayer.SetIsOverRiver(false);
                    inPlayer.SetGroundLevel(0);
                }

            }

        }
        else {
            {
                this.UpdateNoGoZoneP1P2((river[inPlayer.inRiver]).noGoStem, inPlayer, false);
            }
            float yOffset = inPlayer.GetPosition().y - (river[inPlayer.inRiver]).yCliffStart;
            float groundLevel;
            int i = inPlayer.inRiver;
            float cliffEnd = (river[i]).yCliffStart + (river[i]).yCliffLength;
            if (inPlayer.GetPosition().y > cliffEnd) {
                inPlayer.SetInRiver(-1);
                groundLevel = 0;
                inPlayer.SetFoamyRatio(0);
            }
            else {
                float cliffLength = (river[i]).yCliffLength;
                float foamyRatio = 1 - Utilities.GetRatioP1P2(inPlayer.positionZ, -Game.kClifffDepth, -(Game.kClifffDepth-10));
                inPlayer.SetFoamyRatio(foamyRatio);
                if (yOffset < kRiverDropLength) {
                }
                else if (yOffset > (cliffLength - (river[i]).raiseLength)) {
                    if (inPlayer.splashingEffectId != -1) {
                        inPlayer.StopSplashing();
                    }

                }
                else {
                    if (inPlayer.splashingEffectId == -1) {
                        if (inPlayer.positionZ <= ((-Game.kClifffDepth) + 5)) {
                            if (inPlayer.state == PlayerState.kPlayerMoving_Normally) {
                                ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                                inPlayer.StartSplashing();
                                inPlayer.LandedInRiver();
                                info.type = EffectType.kEffect_SplashRing;
                                info.inList = ParticleList.t_DownInRiver;
                                inPlayer.SetActualSpeed();
                                info.velocity = inPlayer.GetActualSpeed();
                                info.startPosition = inPlayer.GetPosition();
                                info.rotation = inPlayer.moveAngle;
                                float groundLevelYThing = Utilities.kYShiftForZ * inPlayer.positionZ;
                                info.startPosition.y -= groundLevelYThing;
                                (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_Splash, 1.0f, inPlayer.position);
                            }

                        }

                    }

                }

            }

            this.SetGroundLevelFromRiverPositionP1(inPlayer, i);
        }

    }

    bool CheckAddMapObjectToDrawList(ListType listType)
    {
        if (nextMapObjectInPendingList[(int)listType] >= numMapObjectInPendingList[(int)listType]) return false;

        int nextMapObjectId = pendingListMapObjects[(int)listType, nextMapObjectInPendingList[(int)listType]];
        if (mapObject[nextMapObjectId].position.y <= (30.0f + scrollPosition.y + Globals.g_world.mapObjectAppearDistance)) {
            if ((mapObject[nextMapObjectId]).listType != (int)listType) {
                this.AddToEndOfUsedListP1((ListType)(mapObject[nextMapObjectId]).listType, nextMapObjectId);
            }
            else {
                this.AddToEndOfUsedListP1(listType, nextMapObjectId);
            }

            (mapObject[nextMapObjectId]).SetHasBeenDisplayed();
            nextMapObjectInPendingList[(int)listType]++;
            return true;
        }

        return false;
    }

    public void UpdateMapObjectAsSimpleObject(MapObject inMapObject)
    {
        if (inMapObject.listType ==  (int)ListType.e_RenderAbovePlayer) {
            if (player.position.y > inMapObject.position.y) {
                inMapObject.SetFlaggedToSwapbackwardNextFrame(true);
            }
            else if (player.positionZ > 20.0f) {
                inMapObject.SetFlaggedToSwapbackwardNextFrame(true);
            }

        }
        else {
            if ((player.positionZ <= 20.0f) && (player.position.y <= inMapObject.position.y)) {
                if (inMapObject.baseList ==  (int)ListType.e_RenderAbovePlayer) {
                    inMapObject.SetFlaggedToSwapForwardNextFrame(true);
                }

            }

        }

    }

    public void UpdateMapObjects(ListType listType)
    {
        if (flagStartPause) return;

        int safetyValve = 0;
        while (this.CheckAddMapObjectToDrawList(listType) && (safetyValve < 20)) {
            safetyValve++;
        };

        int i = usedListHead[(int)listType];
        while (i != -1) {
            if ((mapObject[i]).flaggedToRemoveNextFrame) {
                if ((mapObject[i]).type ==  MapObjectType.e_FlowerHead) {
                    Globals.Assert((mapObject[i]).objectId <  (int)Enum2.kMaxFlowerHeads);
                    (flowerHead[(mapObject[i]).objectId]).MapObjectRemoved();
                }
                else if ((mapObject[i]).type ==  MapObjectType.e_Tractor) {
                    Globals.Assert((mapObject[i]).objectId <  (int)Enum2.kMaxTractors);
                    (tractor[(mapObject[i]).objectId]).SetMapObjectRemoved(true);
                }
                else if ((mapObject[i]).type ==  MapObjectType.e_Cow) {
                    Globals.Assert((mapObject[i]).objectId <  (int)Enum2.kMaxCows);
                    (cow[(mapObject[i]).objectId]).SetStillHasMapObject(false);
                }
                else if ((mapObject[i]).type ==  MapObjectType.e_FlowerBunch) {
                    Globals.Assert((mapObject[i]).objectId <  (int)Enum2.kMaxFlowerBunches);
                    (flowerBunch[(mapObject[i]).objectId]).SetStillHasMapObject(false);
                }
                else if ((mapObject[i]).type ==  MapObjectType.e_Veg) {
                    Globals.Assert((mapObject[i]).objectId <  (int)Enum2.kMaxNoGoZones);
                    (noGoZone[(mapObject[i]).objectId]).SetStillHasMapObject(false);
                }
                else if ((mapObject[i]).type ==  MapObjectType.e_HayBale) {
                    Globals.Assert((mapObject[i]).objectId <  (int)Enum2.kMaxHayBales);
                    (hayBale[(mapObject[i]).objectId]).SetStillHasMapObject(false);
                }
                else if ((mapObject[i]).type ==  MapObjectType.e_Tree) {
                    Globals.Assert((mapObject[i]).objectId <  (int)Enum2.kMaxTrees);
                    (tree[(mapObject[i]).objectId]).SetStillHasMapObject(false);
                }
					
					if (mapObject[i].myAtlasBillboard != null)
					{
						mapObject[i].myAtlasBillboard.StopRender();
					}
					
                int nextI = (mapObject[i]).GetNext();

                #if MO_DEBUG
                #endif

                this.RemoveFromUsedListP1(listType, i);
                this.AddToFreeList(i);
                i = nextI;
                continue;
            }

            if ((mapObject[i]).flaggedToSwapbackwardNextFrame) {
                int nextI = (mapObject[i]).GetNext();
                (mapObject[i]).SetFlaggedToSwapbackwardNextFrame(false);
                this.CheckAndSwapMapObjectBackward(i);
                i = nextI;
                continue;
            }

            if ((mapObject[i]).flaggedToSwapForwardNextFrame) {
                int nextI = (mapObject[i]).GetNext();
                (mapObject[i]).SetFlaggedToSwapForwardNextFrame(false);
                this.CheckAndSwapMapObjectForward(i);
                i = nextI;
                continue;
            }

            withinMapObjectUpdate = true;
            if ((mapObject[i]).type ==  MapObjectType.e_FlowerHead)
			{
                Globals.Assert((mapObject[i]).objectId <  (int)Enum2.kMaxFlowerHeads);
                (flowerHead[(mapObject[i]).objectId]).Update();
                (mapObject[i]).SetPosition((flowerHead[(mapObject[i]).objectId]).position);
            }

            (mapObject[i]).UpdateAlpha();
            if ((mapObject[i]).isSimpleObject) {
                this.UpdateMapObjectAsSimpleObject(mapObject[i]);
            }

            if ((mapObject[i]).alpha <= 0.15f) {
                (mapObject[i]).SetFlaggedToRemoveNextFrame(true);
            }

            i = (mapObject[i]).GetNext();
            withinMapObjectUpdate = false;
        }

    }

    public void UpdateTransition()
    {
        if (!(Ztransition.GetTransition()).inTransition) return;

        if ((Ztransition.GetTransition()).area !=  TransitionArea.kTransition_Game) return;

        if ((Ztransition.GetTransition()).timeToDoStuff) {
            this.SetNewGameState((GameState)(Ztransition.GetTransition()).nextState);
        }

    }		
		
}
}