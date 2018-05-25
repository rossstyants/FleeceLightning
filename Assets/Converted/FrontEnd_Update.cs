using System;
using System.Diagnostics;

namespace Default.Namespace
{
     public partial class FrontEnd
    {
        public void UpdateLateralSlide()
        {
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel) {
                lateralSlideOffset = ((float) selectedTerrain) * 320.0f;
            }
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseControls) {
                lateralSlideOffset = ((float) selectedControls) * 320.0f;
            }
            else {
                lateralSlideOffset = ((float) selectedStage) * 320.0f;
            }

            if (chooseStageLateralSlideTimer > 0.0f) {
                chooseStageLateralSlideTimer -= Constants.kFrameRate;
                if (chooseStageLateralSlideTimer < 0.0f) {
                    if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel) {
                        selectedTerrain = lateralSlideTo;
                    }
                    else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseControls) {
                        selectedControls = lateralSlideTo;
                    }
                    else {
                        selectedStage = lateralSlideTo;
                    }

                    chooseStageLateralSlideTimer = 0.0f;
                    if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) {
                        ((screen[(int)currentScreen]).GetButton(chooseStageSideButtonId)).SetIsClickable(true);
                        ((screen[(int)currentScreen]).GetButton(chooseStageSideButtonId + 1)).SetIsClickable(true);
						
						//UpdateLateralSlide
						
						((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnStage + 0 + (lateralSlideFrom * 3))).StopRender();
						((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnStage + 1 + (lateralSlideFrom * 3))).StopRender();
						((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnStage + 2 + (lateralSlideFrom * 3))).StopRender();
                    }
                    else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel) {
                        ((screen[(int)currentScreen]).GetButton(chooseTerrainSideButtonId)).SetIsClickable(true);
                        ((screen[(int)currentScreen]).GetButton(chooseTerrainSideButtonId + 1)).SetIsClickable(true);
                    }
                    else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseControls) {
                        ((screen[(int)currentScreen]).GetButton(chooseControlsSideButtonId)).SetIsClickable(true);
                        ((screen[(int)currentScreen]).GetButton(chooseControlsSideButtonId + 1)).SetIsClickable(true);
                    }
                    else {
                        ((screen[(int)currentScreen]).GetButton(chooseStageSideButtonIdCT[(int)currentScreen])).SetIsClickable(true);
                        ((screen[(int)currentScreen]).GetButton(chooseStageSideButtonIdCT[(int)currentScreen] + 1)).SetIsClickable(true);

						//choose track
						//UpdateLateralSlide
						
						((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeTracks + (lateralSlideFrom * 9))).StopRender();
					}

                }

                float ratio = 1.0f - Utilities.GetCosInterpolationHalfP1P2(chooseStageLateralSlideTimer, 0.0f, kStageLateralSlideTime);
                if (lateralSlideTo < lateralSlideFrom) {
                    lateralSlideOffset -= ratio * 320.0f;
                }
                else {
                    lateralSlideOffset += ratio * 320.0f;
                }

            }

        }

        public void UpdateChooseTrackGenericStuff()
        {
            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
            }

            bool inTransition = ((Ztransition.GetTransition()).inTransition) && ((int)(Ztransition.GetTransition()).area == (int) TransitionArea.
              kTransition_Frontend);
            if (inTransition) return;

            int level = (screen[(int)currentScreen]).selectedLevel + kNumButtonsBeforeTracks;
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
                level -= ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup);
            }

            if (level != -1) {
                int buttId = level;
                if (((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) && ((int)currentScreen != (int) FrontEndScreenEnum.
                  kFrontEndScreen_BonusChooseTrack)) {
                    if (buttId >= 0) ((screen[(int)currentScreen]).GetButton(buttId + 1)).UpdateSparkles();

                }

            }

        }

        public void UpdateChooseTrackLateralSlide()
        {
			int digitIndex = 0;
			
            this.UpdateColourFading();
            this.UpdateLateralSlide();
            int buttonIndex = kNumButtonsBeforeTracks;
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                buttonIndex++;
            }

            float xSpaceBetween = 6;
            float xEdge = (320 - (64 * 3) - (2 * xSpaceBetween)) / 2;
            float ySpaceBetween = 6;
            float yEdge = kChooseTrackYEdge;
            if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_NetSendChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack)) {
                yEdge += kShiftWithMessage;
            }

            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                yEdge -= 64.0f;
            }

            int numStages = 3;
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                numStages =  (int)Enum2.kNumStages;
            }

            for (int i = 0; i < numStages; i++) {
                float xStageOffset = ((float) i) * 320.0f;
                if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
				
				float yExtraPos = 0.0f;
				if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese)|| (Globals.g_currentLanguage == World.Enum11.kLanguage_French)) {
                    yExtraPos = -15.0f;
						
					if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
					{
						yExtraPos = -24.0f;
					}
                }

					
                    CGPoint newPos = Utilities.CGPointMake(xStageOffset - lateralSlideOffset + 160.0f, kChooseTrackCupNameYPos + yExtraPos);
                    ((screen[(int)currentScreen]).GetFunnyWord((i * 1) + 0)).ChangePositionNew(newPos);
                }

                if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                    float posX = xStageOffset + 160.0f - lateralSlideOffset;
                    float posY = kChooseTrackCupNameYPos - 8.0f;

                    CGPoint newPos = Utilities.CGPointMake(posX, posY);
                    ((screen[(int)currentScreen]).GetButton(buttonIndex)).ChangePosition(newPos);
                    buttonIndex++;
                }

                for (int y = 0; y < 3; y++) {
                    int numX = 3;
                    if (y == 2) {
                        numX = 2;
                    }

                    for (int x = 0; x < numX; x++) {
                        if (i == (int)Enum2.kStageBonusLevels) {
                            if (y > 0) {
                                continue;
                            }

                        }

                        float posX = xStageOffset + 32 + xEdge + ((64 + xSpaceBetween) * ((float) x));
                        float posY = 32 + yEdge + ((64 + ySpaceBetween) * ((float) y));
                        CGPoint newPos = Utilities.CGPointMake(posX - lateralSlideOffset, posY);
                        ((screen[(int)currentScreen]).GetButton(buttonIndex)).ChangePosition(newPos);
                        buttonIndex++;
						

						if (currentScreen != FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack)
						{
							if (digitIndex < 80)
							{
		                        ((screen[(int)currentScreen]).GetNumber(digitIndex)).SetPosition(newPos);
								digitIndex++;
							}
						}
					}

                }

            }

        }

        public void UpdateRaysColour()
        {
            (((screen[(int)currentScreen]).GetButton(1)).zobject).SetColour(currentColour);
            (((screen[(int)currentScreen]).GetButton(0)).zobject).SetColour(currentColourRays);
        }

        public void UpdateSlideArrowsColour()
        {
            int chooseStageButton;
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) chooseStageButton = chooseStageSideButtonId;
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel) chooseStageButton = chooseTerrainSideButtonId;
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseControls) chooseStageButton = chooseControlsSideButtonId;
            else chooseStageButton = chooseStageSideButtonIdCT[(int)currentScreen];

            (((screen[(int)currentScreen]).GetButton(chooseStageButton)).zobject).SetColour(currentColour);
            (((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).zobject).SetColour(currentColour);
        }

        public void UpdateChooseControls()
        {
            this.UpdateLateralSlide();
            for (int i = 0; i < 3; i++) {
                float xOffset = (((float) i) * 320.0f);
                CGPoint newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, 210.0f);
                ((screen[(int)currentScreen]).GetButton(0 + (i * 1))).ChangePosition(newPos);
                newPos = Utilities.CGPointMake(163.0f - lateralSlideOffset + xOffset, 300.0f);
                ((screen[(int)currentScreen]).GetFunnyWord((i * 2))).ChangePosition(newPos);
                newPos = Utilities.CGPointMake(163.0f - lateralSlideOffset + xOffset, 340.0f);
                ((screen[(int)currentScreen]).GetFunnyWord(1 + (i * 2))).ChangePosition(newPos);
            }

        }

        public void UpdateChooseStage()
        {
            this.UpdateLateralSlide();
            for (int i = 0; i < (int)Profile.Enum4.kNumCups; i++) 
			{
                float xOffset = (((float) i) * 320.0f);
                CGPoint newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, 74.0f);
                ((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnStage + 2 + (i * 3))).ChangePosition(newPos);
                newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, kChooseStageMainIconYPos);
                ((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnStage + 1 + (i * 3))).ChangePosition(newPos);
                float throwThingsOffScreen = 0.0f;
                int levelThatNeedsToBeUnlocked = i * 8;
                if (!profile.IsLevelUnlocked(levelThatNeedsToBeUnlocked)) {
                    throwThingsOffScreen = 500.0f;
                }

                newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, kChooseStageHangingTotalPos + throwThingsOffScreen);
                ((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnStage + 0 + (i * 3))).ChangePosition(newPos);
                float extra = 0.0f;
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    extra = -6.0f;
                }

				float yExtraPos = 0.0f;	
				
                newPos = Utilities.CGPointMake(163.0f - lateralSlideOffset + xOffset, kTotalWordYPos + throwThingsOffScreen + extra);
                ((screen[(int)currentScreen]).GetFunnyWord((i * 2))).ChangePositionNew(newPos);
				
				if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) || (Globals.g_currentLanguage == World.Enum11.kLanguage_French)) 
				{
                    yExtraPos = -15.0f;

					if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
					{
						yExtraPos = -24.0f;
					}
				}
				
                newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, kChooseStageCupNameYPos + yExtraPos);
                ((screen[(int)currentScreen]).GetFunnyWord(1 + (i * 2))).ChangePositionNew(newPos);
                newPos = Utilities.CGPointMake(kChooseStageAppleXPos - lateralSlideOffset + xOffset, kChooseStageApplesYPos + throwThingsOffScreen);
                ((screen[(int)currentScreen]).GetNumber(i)).SetPosition(newPos);
            }

            int[] stageThing = new int [4]
            {4, 6, 8, 9};
            for (int i = 0; i < 4; i++) {
                int stageId = stageThing[i];
                float xOffset = ((float)(stageId)) * 320.0f;
                CGPoint newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, kChooseStageSpecialLockYPos);
                ((screen[(int)currentScreen]).GetButton(specialLockId + i)).ChangePosition(newPos);
                newPos = Utilities.CGPointMake(178.0f - lateralSlideOffset + xOffset, kChooseStageSpecialLockYPos - 1.0f);
                ((screen[(int)currentScreen]).GetNumber(specialLockWordId + (i * 2))).SetPosition(newPos);
                newPos = Utilities.CGPointMake(178.0f - lateralSlideOffset + xOffset, kChooseStageSpecialLockYPos + 17.0f);
                ((screen[(int)currentScreen]).GetNumber(specialLockWordId + 1 + (i * 2))).SetPosition(newPos);
                newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, kChooseStageSpecialLockYPos - 16.0f);
				
				if ((Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) ||  (Globals.g_currentLanguage == World.Enum11.kLanguage_China)||  (Globals.g_currentLanguage == World.Enum11.kLanguage_French))
				{
					newPos.y -= 8.0f;	
				}
				
                ((screen[(int)currentScreen]).GetFunnyWord(specialWordId + i)).ChangePositionNew(newPos);
            }

        }

        public void UpdateChooseTerrain()
        {
            this.UpdateLateralSlide();
            for (int i = 0; i < 2; i++) {
                float xOffset = (((float) i) * 320.0f);
                CGPoint newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, kChooseStageMainIconYPos);
                ((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnTerrain + (i * 2))).ChangePosition(newPos);
                newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, kChooseTerrainTerrainPos);
                ((screen[(int)currentScreen]).GetButton(kNumButtonsBeforeOnTerrain - 1 + (i * 2))).ChangePosition(newPos);
                newPos = Utilities.CGPointMake(160.0f - lateralSlideOffset + xOffset, kChooseTerrainTerrainPos + 9.0f);
                ((screen[(int)currentScreen]).GetFunnyWord(1 + (i * 1))).ChangePosition(newPos);
            }

        }

        int GetHowManyScreens(int inScreen)
        {
            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseStage) {
                return ((int)Profile.Enum4.kNumCups - 1);
            }
            else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                return ((int)Profile.Enum4.kNumCups - 1);
            }

            return 2;
        }
        
		int GetHowManyScreens(FrontEndScreenEnum inScreen)
        {
			return this.GetHowManyScreens((int) inScreen);
		}

        public void HideSlideButtonsAtShow()
        {
            int chooseStageButton;
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) chooseStageButton = chooseStageSideButtonId;
            else chooseStageButton = chooseStageSideButtonIdCT[(int)currentScreen];

            int howManyScreens = this.GetHowManyScreens(currentScreen);
            if (selectedStage == howManyScreens) {
                (((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).zobject).Disappear();
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            }
            else {
                if (false) {
                    (((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).zobject).Disappear();
                    ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
                }

            }

            if (selectedStage == 0) {
                (((screen[(int)currentScreen]).GetButton(chooseStageButton)).zobject).Disappear();
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            }
            else {
                if (false) {
                    (((screen[(int)currentScreen]).GetButton(chooseStageButton)).zobject).Disappear();
                    ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
                }

            }

        }

        public void HideSlideButtonsAtShowControls()
        {
            int chooseStageButton = chooseControlsSideButtonId;
            if (selectedControls == (3 - 1)) {
                (((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).zobject).Disappear();
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            }

            if (selectedControls == 0) {
                (((screen[(int)currentScreen]).GetButton(chooseStageButton)).zobject).Disappear();
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            }

        }

        public void HideSlideButtonsAtShowTerrain()
        {
            int chooseStageButton = chooseTerrainSideButtonId;
            if (selectedTerrain == (2 - 1)) 
			{
                (((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).zobject).Disappear();
                ((screen[(int)currentScreen]).GetButton(chooseStageButton + 1)).SetIsClickable(false);
            }

            if (selectedTerrain == 0) {
                (((screen[(int)currentScreen]).GetButton(chooseStageButton)).zobject).Disappear();
                ((screen[(int)currentScreen]).GetButton(chooseStageButton)).SetIsClickable(false);
            }

        }

        public void ShowScreenChooseTrackBonus()
        {
            currentColour = this.GetColourFromStageP1(2, false);
            currentColourRays = this.GetColourFromStageP1(2, true);
            exitInfo.playCustomLevel = false;
            exitInfo.goToLevelBuilder_Ross = false;
            this.HideAndShowTrackButtons(true);
            int newLevel = lastSelectedLevel[selectedStage];
            this.SetSelectedLevelOnChooseTrackP1((int)currentScreen, newLevel);
            this.ShowCurrentLevel();
        }

        public Constants.RossColour GetColourFromStageP1(int inStage, bool isRays)
        {

            return Constants.kColourPurpleMenuBack;
        }

        Constants.RossColour GetColourFromTerrainP1(int inTerrain, bool isRays)
        {
            if (inTerrain == (int) SceneType.kSceneGrass) {
                if (isRays) return Constants.kColourGreenMenuBackRays;
                else {
                    return Constants.kColourGreenMenuBack;
                }

            }
            else if (inTerrain == (int) SceneType.kSceneMud) {
                if (isRays) return Constants.kColourYellowMenuBackRays;
                else {
                    return Constants.kColourYellowMenuBack;
                }

            }
            else if (inTerrain == (int) SceneType.kSceneDesert) {
                if (isRays) return Constants.kColourYellow;
                else {
                    return Constants.kColourYellow;
                }

            }
            else if (inTerrain == (int) SceneType.kSceneIce) {
                if (isRays) return Constants.kColourLightblue;
                else {
                    return Constants.kColourLightblue;
                }

            }
            else if (inTerrain == (int) SceneType.kSceneMoon) {
                if (isRays) return Constants.kColourPurpleMenuBackRays;
                else {
                    return Constants.kColourPink;
                }

            }

            return Constants.kColourPurpleMenuBack;
        }

        public void ShowScreenChooseTrack()
        {
            currentColour = this.GetColourFromStageP1(selectedStage, false);
            currentColourRays = this.GetColourFromStageP1(selectedStage, true);
            exitInfo.playCustomLevel = false;
            exitInfo.goToLevelBuilder_Ross = false;
            this.HideAndShowTrackButtons(true);
            chooseStageLateralSlideTimer = 0.0f;
            ((screen[(int)currentScreen]).GetButton(chooseStageSideButtonIdCT[(int)currentScreen])).SetIsClickable(true);
            ((screen[(int)currentScreen]).GetButton(chooseStageSideButtonIdCT[(int)currentScreen] + 1)).SetIsClickable(true);
            this.HideSlideButtonsAtShow();
            int newLevel = lastSelectedLevel[selectedStage];
            this.SetSelectedLevelOnChooseTrackP1((int)currentScreen, newLevel);
            this.ShowCurrentLevel();
        }

        public void ShowScreenChooseControls()
        {
            this.HideSlideButtonsAtShowControls();
            this.SetControlFromSelected(selectedControls);
        }

        public void ShowScreenChooseTerrain()
        {
            this.HideSlideButtonsAtShowTerrain();
            for (int t = 0; t < 2; t++) {
                if (profile.profileInfo.terrainUnlocked[t]) 
				{
					(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).GetButton(kNumButtonsBeforeOnTerrain + (t * 2))).
                      zobjectLabel).SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_FrontendAndShowlevel));
                    (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).GetButton(kNumButtonsBeforeOnTerrain + (t * 2))).
                      zobjectLabel).SetSubTextureId((int)World.Enum9.kFE_StageLocked);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).GetButton(kNumButtonsBeforeOnTerrain + (t * 2))).
                      SetIsClickable(true);
                    if (t == 1) {
                        (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).GetButton(kNumButtonsBeforeOnTerrain + (t * 2))).
                          zobject).SetShowScale(0.78f);
                    }

                    if (t < 2) {
                        (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).GetButton(kNumButtonsBeforeOnTerrain + (t * 2))).
                          zobject).SetSubTextureId((int)World.Enum9.kFE_TerrainGrass + t);
                    }
                    else {
                    }

                }
                else {
                    if (t == 1) {
                        (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).GetButton(kNumButtonsBeforeOnTerrain + (t * 2))).
                          zobject).SetShowScale(1.0f);
                    }

                    (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).GetButton(kNumButtonsBeforeOnTerrain + (t * 2))).zobject
                      ).SetSubTextureId((int)World.Enum9.kFE_StageLocked);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).GetButton(kNumButtonsBeforeOnTerrain + (t * 2))).
                      SetIsClickable(false);
                }

            }

        }

        public void ShowScreenChooseStage()
        {
            if (initMenuAtRaceScreen >= 0) {
                if (showingThatCupIsUnlocked)
				{
                    profile.SetReachedCupWhenStillLockedP1(initMenuAtRaceScreen, false);
                    profile.SaveBestTimesAndPrefs();
                    this.ShowPopUpSpecialLockUnlocked();
                    showingThatCupIsUnlocked = false;
                }
                else {
                    profile.SetReachedCupWhenStillLockedP1(initMenuAtRaceScreen, true);
                    profile.SaveBestTimesAndPrefs();
                    this.ShowPopUpSpecialLock();
                }

                initMenuAtRaceScreen = -1;
            }

            currentColour = this.GetColourFromStageP1(selectedStage, false);
            currentColourRays = this.GetColourFromStageP1(selectedStage, true);
            exitInfo.goToLevelBuilder_Ross = false;
            exitInfo.playCustomLevel = false;
            int totalApples = profile.GetTotalNumberOfApples();
            for (int i = 0; i < (int)Profile.Enum4.kNumCups; i++) {
                int numDigits;
                int numApples = profile.GetNumApples(i);
                if (numApples <= 9) numDigits = 1;
                else {
                    numDigits = 2;
                }

                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(i)).ChangeNumDigits(numDigits);
								((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(i)).SetScore((float) numApples);
//								((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(i)).SetScore((float) 0.0f);
                int levelThatNeedsToBeUnlocked = i * (int)Profile.Enum6.kNumLevelsPerCup;
                bool isUnlocked = (profile.IsLevelUnlocked(levelThatNeedsToBeUnlocked));
                if (isUnlocked) 
				{
										(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(kNumButtonsBeforeOnStage + 1 + (i * 3))).zobject).
                      SetSubTextureId((profile.GetCup(i)).stageIcon);
                    (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(kNumButtonsBeforeOnStage + 1 + (i * 3))).zobjectLabel).
                      SetSubTextureId(Globals.g_world.GetSubTextLanguageP1((int) AtlasType.kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_StageButtonWordPlay));
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(kNumButtonsBeforeOnStage + 1 + (i * 3))).SetIsClickable(true);
                }
                else 
				{
                    (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(kNumButtonsBeforeOnStage + 1 + (i * 3))).zobject).
                      SetSubTextureId((int)World.Enum9.kFE_StageLocked);
                    (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(kNumButtonsBeforeOnStage + 1 + (i * 3))).zobjectLabel).
                      SetSubTextureId(100);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(kNumButtonsBeforeOnStage + 1 + (i * 3))).SetIsClickable(false);
                }

            }

            chooseStageLateralSlideTimer = 0.0f;
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(chooseStageSideButtonId)).SetIsClickable(true);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(chooseStageSideButtonId + 1)).SetIsClickable(true);
            this.HideSlideButtonsAtShow();
            int totalNumberOfApples = profile.GetTotalNumberOfApples();
            for (int i = 0; i < 4; i++) {
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + (i * 2))).SetScore(totalNumberOfApples);
            }

						(screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).SetFunnyWordsToStartPosition();
						//			(screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).let
						(screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).PrintOutFunnyWords();



            if (totalApples >= Constants.NUM_APPLES_TO_UNLOCK_10) {
                for (int i = 0; i < 4; i++) {
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(specialLockId + i)).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + (i * 2))).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + 1 + (i * 2))).Disappear();
					((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetFunnyWord(specialWordId + (i))).Disappear();
                }

            }
            else if (totalApples >= Constants.NUM_APPLES_TO_UNLOCK_9) {
                for (int i = 0; i < 3; i++) {
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(specialLockId + i)).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + (i * 2))).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + 1 + (i * 2))).Disappear();

//										UnityEngine.Debug.Log("ShowScreenChooseStage num Funnny Words = " + ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).funnyWord.Length));
//
//
//
//
//										for (int ik = 0; ik < screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage].funnyWord.Length;ik++)
//												{
//												UnityEngine.Debug.Log((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetFunnyWord(ik).textString);
//												}

										((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetFunnyWord(specialWordId + (i))).Disappear();
                }

            }
            else if (totalApples >= Constants.NUM_APPLES_TO_UNLOCK_7) {
                for (int i = 0; i < 2; i++) {
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(specialLockId + i)).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + (i * 2))).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + 1 + (i * 2))).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetFunnyWord(specialWordId + (i))).Disappear();
                }

            }
            else if (totalApples >= Constants.NUM_APPLES_TO_UNLOCK_5) {
                for (int i = 0; i < 1; i++) {
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetButton(specialLockId + i)).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + (i * 2))).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetNumber(specialLockWordId + 1 + (i * 2))).Disappear();
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).GetFunnyWord(specialWordId + (i))).Disappear();
                }

            }
			

			
        }

        public void ShowScreenP1(FrontEndScreenEnum newScreen, FrontEndScreenEnum oldScreen)
        {
            inScreenTimer = 0.0f;
            switch (newScreen) {
            case FrontEndScreenEnum.kFrontEndScreen_Legal :
                ((screen[(int)newScreen]).GetQuery(0)).Show();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTilt :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTiltExpert :
                (((screen[(int)currentScreen]).GetButton(4)).zobject).QueueAction( ZobjectAction.nThrobLooping);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTiltAuto :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowThumb :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Final :
                (((screen[(int)currentScreen]).GetButton(1)).zobject).QueueAction( ZobjectAction.nThrobLooping);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_GreenAnt :
				
				if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
				{
					Scissor.DoGLScissor(Globals.g_world.tileCam, 0, 260, 320, 480);
				}
				else
				{
					Scissor.DoGLScissor(Globals.g_world.tileCam, 0, 260, 320, 480);
				}
				
                if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                    (SoundEngine.Instance()).AVChangeToTrackP1((int)Audio.Enum2.kSoundEffect_MusicLoop, 0.4f);
                }

                blinkTimer = 0.0f;
                creditsText.Start();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel :
                this.ShowScreenChooseTerrain();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ChooseControls :
                this.ShowScreenChooseControls();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ChooseStage :
                this.MakeSureSelectedStageIsAppropriate(newScreen);
                this.ShowScreenChooseStage();
                (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_BubblesLowLoop, 0.1f);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_BehindCrystalSplash :
                this.ShowScreenBehindCrystalSplash();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_BehindGameCenterStart :
                this.ShowScreenBehindGameCenter();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_EnterTrackName :
                {
                    this.ShowScreenEnterName();
                }
                break;
            case FrontEndScreenEnum.kFrontEndScreen_WaitForClient :
                {
                    this.ShowScreenWaitForClient();
                }
                break;
            case FrontEndScreenEnum.kFrontEndScreen_MultiplayerConnect :
                {
                    this.ShowScreenMultiplayerConnect();
                }
                break;
            case FrontEndScreenEnum.kFrontEndScreen_FeatureNotAvailable :
                {
                    this.ShowScreenFeatureNot();
                }
                break;
            case FrontEndScreenEnum.kFrontEndScreen_BrowseServers :
                {
                    this.ShowScreenBrowseServers();
                }
                break;
            case FrontEndScreenEnum.kFrontEndScreen_TrackReceived :
                {
                    this.ShowScreenReceivedTrack();
                }
                break;
            case FrontEndScreenEnum.kFrontEndScreen_Title :
                ////glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
								/// 
								Globals.g_consentPopup.Show();
								Globals.g_world.SetHaveReachedTitleYet(true);
                Globals.g_world.DisappearLeaderBoardThing();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_Main :
                this.ShowScreenMain();
                Globals.g_world.DisappearLeaderBoardThing();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_About_2_8 :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_About_2_9 :
                break;
            case FrontEndScreenEnum.kFrontEndScreen_About_2_6 :
                profile.SetSeenHowTo();
                profile.SaveBestTimesAndPrefs();
                if ((int)oldScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main) {
                    this.EnteringTheAboutScreens();
                }

                break;
            case FrontEndScreenEnum.kFrontEndScreen_About_3 :
                this.ShowAboutSlideIn(3);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_About_4 :
                this.ShowAboutSlideIn(5);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_About_5 :
                this.ShowAboutSlideIn(6);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_Options :
                this.ShowScreenOptions();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_ChooseTrack :
                this.MakeSureSelectedStageIsAppropriate(newScreen);
                this.ShowScreenChooseTrack();
                this.HideButtonsNotVisibleYet(newScreen);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack :
                this.HideAndShowTrackButtons(true);
                (((screen[(int)currentScreen]).GetButton(startButtonIdnr)).zobject).QueueAction( ZobjectAction.nThrobLooping);
                (((screen[(int)currentScreen]).GetButton(startButtonIdnr)).zobject).SetThrobSize(0.075f);
                (((screen[(int)currentScreen]).GetButton(startButtonIdnr)).zobject).SetThrobTime(0.4f);
                this.MakeSureSelectedStageIsAppropriate(newScreen);
                this.HideSlideButtonsAtShow();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack :
                this.HideAndShowTrackButtons(true);
                this.MakeSureSelectedStageIsAppropriate(newScreen);
                this.HideSlideButtonsAtShow();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack :
                (((screen[(int)currentScreen]).GetButton(startButtonIdBonus)).zobject).QueueAction( ZobjectAction.nThrobLooping);
                (((screen[(int)currentScreen]).GetButton(startButtonIdBonus)).zobject).SetThrobSize(0.075f);
                (((screen[(int)currentScreen]).GetButton(startButtonIdBonus)).zobject).SetThrobTime(0.4f);
                this.MakeSureSelectedStageIsAppropriate(newScreen);
                this.ShowScreenChooseTrackBonus();
                this.HideButtonsNotVisibleYet(newScreen);
                break;
            case FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild :
                this.ShowScreenLBPlayOrBuild();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack :
                this.MakeSureSelectedStageIsAppropriate(newScreen);

                #if !LITE_VERSION
                //    currentColour = this.GetColourFromStageP1(kStageStarCup, false);
                  //  currentColourRays = this.GetColourFromStageP1(kStageStarCup, true);
                #endif

                this.HideAndShowTrackButtons(true);
                if (exitInfo.goToLevelBuilder_Ross) {
                    CGPoint buttonPos = Utilities.CGPointMake((320.0f - xBackButton), kChooseTrackBackBarTopPosY - 1.0f);
                    ((screen[(int)currentScreen]).GetButton(startButtonIdLB)).ChangePosition(buttonPos);
                    (((screen[(int)currentScreen]).GetButton(startButtonIdLB)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
                    (((screen[(int)currentScreen]).GetButton(startButtonIdLB)).zobject).SetSubTextureId(Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                      kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_BackBarCreate));
                    ((screen[(int)currentScreen]).GetButton(startButtonIdLB)).SetWidth(50.0f);
                    if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                        switch (Globals.g_currentLanguage) {
                        case World.Enum11.kLanguage_China :
                        case World.Enum11.kLanguage_Japanese :
                        case World.Enum11.kLanguage_French :
                            ((screen[(int)currentScreen]).GetFunnyWord(startButtonFWId)).ChangeTextNew(Globals.g_world.GetNSString ( StringId.kString_Create));
                            ((screen[(int)currentScreen]).GetFunnyWord(startButtonFWId)).FitToWidth(80.0f);
                            break;
                        default :
                            Globals.Assert(false);
                            break;
                        }

                    }

                }
                else {
                   // ((screen[(int)currentScreen]).GetButton(keybButtonIdLB)).Disappear();
                    ((screen[(int)currentScreen]).GetButton(trashButtonIdLB)).Disappear();
                    CGPoint buttonPos = Utilities.CGPointMake((320.0f - xBackButton), kChooseTrackBackBarTopPosY - 3.0f);
                    ((screen[(int)currentScreen]).GetButton(startButtonIdLB)).ChangePosition(buttonPos);
                    (((screen[(int)currentScreen]).GetButton(startButtonIdLB)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
                    (((screen[(int)currentScreen]).GetButton(startButtonIdLB)).zobject).SetSubTextureId(Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                      kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_BackBarPlay));
                    ((screen[(int)currentScreen]).GetButton(startButtonIdLB)).SetWidth(50.0f);
                    if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                        switch (Globals.g_currentLanguage) {
                        case World.Enum11.kLanguage_China :
                        case World.Enum11.kLanguage_Japanese :
                        case World.Enum11.kLanguage_French :
							((screen[(int)currentScreen]).GetFunnyWord(startButtonFWId)).ChangeTextNew(Globals.g_world.GetNSString ( StringId.kString_Practise));
                            ((screen[(int)currentScreen]).GetFunnyWord(startButtonFWId)).FitToWidth(80.0f);
                            break;
                        default :
                            Globals.Assert(false);
                            break;
                        }

                    }

                }

                (((screen[(int)currentScreen]).GetButton(startButtonIdLB)).zobject).SetShowScale(1.0f);
                (((screen[(int)currentScreen]).GetButton(startButtonIdLB)).zobject).SetThrobSize(0.075f);
                (((screen[(int)currentScreen]).GetButton(startButtonIdLB)).zobject).SetThrobTime(0.3f);
                (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_BubblesLowLoop, 0.3f);
                this.HideSlideButtonsAtShow();
                break;
            case FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack :
                this.MakeSureSelectedStageIsAppropriate(newScreen);
                this.HideButtonsNotVisibleYet(newScreen);
                (SoundEngine.Instance()).QueueFinchSoundP1((int)Audio.Enum1.kSoundEffect_BubblesLowLoop, 0.3f);
                break;
            default :
                break;
            }

        }

        public void SetupScreen(FrontEndScreenEnum newScreen)
        {
            this.ExitScreenP1(currentScreen, newScreen);
            FrontEndScreenEnum oldScreen = currentScreen;
            currentScreen = newScreen;
            this.DoScreenShowIndividualities();
            (screen[(int)currentScreen]).ShowButtons();
            (screen[(int)currentScreen]).Update();
            this.ShowScreenP1(newScreen, oldScreen);
            (screen[(int)currentScreen]).ShowIsActuallyStarting();
        }

        public void ChangeToScreen(FrontEndScreenEnum newScreen)
        {			
			UnityEngine.Debug.Log("From" + currentScreen + " to " + newScreen);
			
            if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_GreenAnt) || ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_GreenAnt)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).SetPBackTexture(buttonTexture[(int)Enum.kButtonTexture_GreenAnt]);
//                (Ztransition.GetTransition()).SetPTexture(buttonTexture[(int)Enum.kButtonTexture_GreenAnt]);
//                (Ztransition.GetTransition()).SetPBackTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_WhirlingShape);
                ((Ztransition.GetTransition()).zobject).SetShowScale(1.0f);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) && ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main))
              {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild) || ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_LBPlayOrBuild)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_Main)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_BonusChooseTrack)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Title) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_BehindGameCenterStart)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BrowseServers) || ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_BrowseServers)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_NetSendChooseTrack)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) && ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main) && ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Options)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Legal) || ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Legal)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_ChooseTerrainForCustomLevel)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_LBChooseTrack)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Options) && ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen >= (int) FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose) && ((int)currentScreen <= (int) FrontEndScreenEnum.
              kFrontEndScreen_ControlChoice_Final)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)newScreen >= (int) FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose) && ((int)newScreen <= (int) FrontEndScreenEnum.
              kFrontEndScreen_ControlChoice_Final)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Title) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_BehindCrystalSplash)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseControls) || ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_ChooseControls)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_ChooseStage)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_ChooseTrack)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) && ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_EnterTrackName) || ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_EnterTrackName)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_LBPlayOrBuild)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild) && ((int)newScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_LBChooseTrack)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main) && ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main) && ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_About_2_6)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if ((((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_About_2_6) || ((int)currentScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_About_5)) && ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Title) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBHowTo) || ((int)newScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LBHowTo)) {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }
            else if (((int)newScreen != (int) FrontEndScreenEnum.kFrontEndScreen_Main) || ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_Title)) {
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Invisible);
            }
            else {
                (Ztransition.GetTransition()).SetPTexture((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) newScreen, TransitionArea.kTransition_Frontend,  TransitionType.e_Fade);
            }

            (screen[(int)currentScreen]).HideButtons();
            if ((screen[(int)currentScreen]).GetPressedButton() != null) 
			{
                ((screen[(int)currentScreen]).GetPressedButton()).ThrobAndGo();
            }

        }

        public void UpdateMain()
        {
            hopTimerLB += Constants.kFrameRate;
            hopTimerGreenAnt += Constants.kFrameRate;
            if (hopTimerLB >= 10.0f) {
                hopTimerLB = 0.0f;
            }

            if (hopTimerGreenAnt >= 10.0f) {
                hopTimerGreenAnt = 0.0f;
            }

        }

        public void UpdateIndividualScreen()
        {
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_WaitForClient) {
            //    this.UpdateWaitForClient();
            }

            bool inTransition = ((Ztransition.GetTransition()).inTransition) && ((int)(Ztransition.GetTransition()).area == (int) TransitionArea.
              kTransition_Frontend);
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BehindCrystalSplash) {
                if (!inTransition) {
/*                    if (g_myViewController.HaveDoneWithDropBox()) 
					{
                        inScreenTimer += Constants.kFrameRate;
                        if (inScreenTimer > 1.0f) {
                            Globals.g_main.HideDropboxThing();
                        }

                    }*/

                }

            }

            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BehindGameCenterStart) {

                #if SHOW_GAMECENTER_OVER_MAIN
                    if (!inTransition) {
                        this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Main);
                        return;
                    }

                #endif

                if (!inTransition) {
                    if (!profile.haveTriedGameCenterYet) {
                        this.SetupCrystalForGameCentre();
                    }

                }

                inScreenTimer += Constants.kFrameRate;
                if (inScreenTimer >= 2.0f) {
                    if (!inTransition) this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Main);

                }

            }

            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BrowseServers) {
            //    this.UpdateBrowseServers();
            }

            if (!inTransition) {
                if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_LoadingScreenEnd) {
                    this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_Title);
					
                }

            }

            slideInCharacter.Update();
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage) {
                this.UpdateChooseStage();
            }
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseControls) {
                this.UpdateChooseControls();
            }
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel) {
                this.UpdateChooseTerrain();
            }

            if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_LBChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack) || ((int)currentScreen == (int)
              FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack)) {
                this.UpdateChooseTrackLateralSlide();
                this.UpdateAppleWon();
                this.UpdateChooseTrackGenericStuff();
            }
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
                bestTime.Update();
                this.UpdateChooseTrackGenericStuff();
            }
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Title) {
                shake.Update();
            }
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Main) {
                this.UpdateMain();
            }
            else if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_GreenAnt) {
                creditsText.Update();
            }

        }

        public bool Update()
        {
            inScreenTimer += Constants.kFrameRate;
            this.UpdateTransition();
            this.UpdateIndividualScreen();
			
            if ((screen[(int)currentScreen]).Update()) {
                FrontEndButton button = (screen[(int)currentScreen]).GetPressedButton();
                if (button != null) {
                    this.PerformButtonAction(button);
                    this.DoButtonIndividualitiesP1(currentScreen, ((screen[(int)currentScreen]).GetPressedButton()).myId);
                    if ((int)button.goToScreen != -1) {
                        this.ChangeToScreen(button.goToScreen);
                    }

                    (screen[(int)currentScreen]).SetLastPressedButton(-1);
                }

                FrontEndSwitch pSwitch = (screen[(int)currentScreen]).GetPressedSwitch();
                if (pSwitch != null) {
                    this.PerformSwitchAction(pSwitch);
                    (screen[(int)currentScreen]).SetLastPressedSwitch(-1);
                }

            }

            this.UpdateScreenQueries();
            Globals.g_world.UpdatePullTab();
            handStamp.Update();
            titleWord1.Update();
            titleWord2.Update();
            greenAntLogo.Update();
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_Title) {
                CGPoint screenPos = Utilities.CGPointMake(kStampX + shake.x, kStampY - shake.y);
                greenAntLogo.SetScreenPosition(screenPos);
            }

            if (handStamp.state ==  ZobjectState.kZobjectShown) {
                handStamp.SetWaitToHide(0.1f);
                handStamp.Hide();
            }

            Globals.g_world.UpdatePullTabNews();
            return frontEndDone;
        }

        public void RenderGreenAntBack()
        {
            //glPushMatrix();
            //glEnable (GL_SCISSOR_TEST);
			
			//Scissor.
			
            CGPoint thingPos = Utilities.CGPointMake(160.0f, 206.0f);
            if (Globals.deviceIPad) {
                thingPos.x = 384.0f;
                thingPos.y = 600.0f;
            }

            if (Globals.deviceIPad) {
                //glScissor(0, 580, 768, 500);
            }
            else {
//                if ( Globals.useRetina)//(UIScreen.MainScreen()).RespondsToSelector(@selector (scale)) == true && (UIScreen.MainScreen()).scale == 2.00) {
  //                  thingPos.y -= 90.0f;
                    //glScissor(0, 580, 640, 960);
    //            }
      //          else {
                    //glScissor(0, 290, 320, 480);
        //        }

            }

            //    (Globals.g_main._billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash]).RenderAtPosition(thingPos,1.0f,0.0f,1.0f,0);

            //glPopMatrix();
            //glDisable (GL_SCISSOR_TEST);
            const float kBlinkTime = 0.1f;
            if (blinkTimer > 0.0f) {
                blinkTimer -= Constants.kFrameRate;

                #if TEST_SHORTS
                    //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                #endif

                //glPushMatrix();
                Globals.g_world.DoGLTranslateP1(113.0f, Globals.g_world.tileMapHeight - 354.0f);
                float blinkScale = 1.37f;
                if (Globals.deviceIPhone4) {
                    blinkScale *= 0.5f;
                }

                (Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_Blink]).DrawAtPointScaled(blinkScale);

                #if TEST_SHORTS
                    //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                #endif

                //glPopMatrix();
            }
            else {
                if (Utilities.GetRand( 700) == 0) {
                    blinkTimer = kBlinkTime;
                }

            }

        }

        public void ShowCurrentLevel()
        {
            if (((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_BonusChooseTrack)) return;

            int myId = (int)currentScreen;
            Zscore.ZscoreInfo info = new Zscore.ZscoreInfo();
            if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack) info.position = Utilities.CGPointMake(160, kChooseTrackScoreYPos);
            else info.position = Utilities.CGPointMake(160, kChooseTrackScoreYPos);

            info.numDigits = 5;
            float fBestTime;
            if ((myId == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_HighScoresChooseTrack)) {
                if (false)//profile.preferences.diffEasy) 
					fBestTime = ((Globals.g_world.frontEnd).profile).GetBestTimeP1( BestTimeSet.t_Easy, (screen[myId]).
                  selectedLevel);
                else fBestTime = ((Globals.g_world.frontEnd).profile).GetBestTimeP1( BestTimeSet.t_Normal, (screen[myId]).selectedLevel);

            }
            else fBestTime = ((Globals.g_world.frontEnd).profile).GetBestTimeP1( BestTimeSet.t_Custom, (screen[myId]).selectedLevel);

            if (fBestTime < 1000) {
            }
            else {
            }

            int selectedLevel = (screen[myId]).selectedLevel;
            if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                TrophyType t = ((Globals.g_world.frontEnd).profile).GetTrophyGot(selectedLevel);
                if (t == 0) {
                }
                else {
                }

            }

			string charName;// = new char[32];
            string inString = "\n";
            Constants.RossColour inColour;
            bool changeWord = true;
            if ((myId == (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || ((int)currentScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_HighScoresChooseTrack)) {
                inString = profile.GetLevelName((screen[myId]).selectedLevel);
                inColour = profile.GetLevelColour((screen[myId]).selectedLevel);
            }
            else if (myId == (int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
                inString = profile.GetLevelName((screen[myId]).selectedLevel);
                inColour = profile.GetLevelColour((screen[myId]).selectedLevel);
            }
            else {
                string newName = profile.GetCustomLevelName();
                if (true ) {
                    charName = newName;
                    //strcat(charName, "\n");
                }
                else {
                    charName = "hmmmm\n";
                }

                inString = charName;
                inColour = profile.GetLevelColour(selectedLevel);
            }

            if (changeWord) {
                int wordId = 0;
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    string inNSString = profile.GetCustomLevelName();
                    ((screen[myId]).GetFunnyWord(wordId)).ChangeTextNew(inNSString);
                }
                else {
                    ((screen[myId]).GetFunnyWord(wordId)).ChangeText(inString);
                }

                ((screen[myId]).GetFunnyWord(wordId)).FitToWidth(260);
                ((screen[myId]).GetFunnyWord(wordId)).SetColour(inColour);
                ((screen[myId]).GetFunnyWord(wordId)).Show();
            }

        }

        public void ButtonAction_ChangeScreen()
        {
        }

        public void AlertViewClickedButtonAtIndex()
        {
            if (initMenuWithWellDone) 
			{
                this.ChangeToScreen( FrontEndScreenEnum.kFrontEndScreen_GreenAnt);
                initMenuWithWellDone = false;
            }
        }

        public void _showAlertNoMessage(string title)
        {
        }

        public void _showAlert(string title)
        {
        }

        public void _showAlertPermission(string title)
        {
//            alertViewPermission.SetTitle(title);
  //          alertViewPermission.Show();
        }

    }
}
