using UnityEngine;
using System;
using System.Diagnostics;

namespace Default.Namespace
{
    public partial class FrontEnd
    {
        public void SetupAboutScreen_5()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_About_5;
            ButtonInfo info = new ButtonInfo();
            info.textureLabel = null;
            this.AddAboutGenericButtonsP1P2(thisScreen, false, true);
        }

        public void SetupEnterTrackNameScreen()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_EnterTrackName;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
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
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], buttonId);
            const float kWordScale = kAboutWordScale;
            float xPos = 160;
            float y = 100;
            string inString = "";
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                inString = "Streckenname eingeben\n";
            }
            else {
                inString = "enter track name\n";
            }

            int fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8P9(screen[(int)thisScreen], (int) StringId.kString_EnterTrack, Globals.g_world.font, Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, 
              Constants.kColourWhite);
            if (!Globals.g_world.DoesCurrentLanguageUseNSString()) ((screen[(int)thisScreen]).GetFunnyWord(fwId)).Jiggle(0.5f);

        }

        public void SetupAboutScreen_2()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_About_2_9;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            this.AddAboutGenericButtonsP1P2(thisScreen, false, false);
            string inString = "\n";
            inString = "you can even try\n";
            float xPos = 160;
            float y = 30;
            int fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), 0.5f, inString, true, Constants.kColourLightblue);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            inString = "'tilt expert mode'\n";
            xPos = 160;
            y = 65;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), 0.5f, inString, true, Constants.kColourLightblue);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 290;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_HowToTiltH];
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.75f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 150;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_HowToTiltV];
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.75f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            inString = "up and down for speed\n";
            xPos = 160;
            y = 205;
            float letterScale = 0.46f;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), letterScale, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            inString = "left and right to steer\n";
            y = 350;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), letterScale, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
        }

        public void SetupAboutScreen_2_6()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_About_2_6;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 80;
            buttonInfo.texture = null;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
              (int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            hInfo.showWobbleMultiplier = 1.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            this.AddAboutGenericButtonsP1P2(thisScreen, true, false);
            string inString = "\n";
            inString = "thumb controls\n";
            float xPos = 160;
            float y = buttonInfo.position.y + 8.0f;
            int fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), 0.5f, inString, true, Constants.kColourLightblue);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 185;
            buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_HowToThumbs);
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            inString = "left and right\n";
            xPos = 160;
            y = 270;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), 0.5f, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            inString = "buttons to steer\n";
            xPos = 160;
            y = 305;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), 0.5f, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
        }

        public void SetupAboutScreen_2_8()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_About_2_8;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 80;
            buttonInfo.texture = null;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
              (int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            hInfo.showWobbleMultiplier = 1.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            this.AddAboutGenericButtonsP1P2(thisScreen, false, true);
            string inString = "\n";
            inString = "tilt control\n";
            float xPos = 160;
            float y = buttonInfo.position.y + 8.0f;
            int fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), 0.5f, inString, true, Constants.kColourLightblue);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 185;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_HowToTiltH];
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            inString = "tilt left and\n";
            xPos = 160;
            y = 270;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), 0.5f, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            inString = "right to steer\n";
            xPos = 160;
            y = 305;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), 0.5f, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
        }

        public void SetupAboutScreen_3()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_About_3;
            this.AddAboutGenericButtonsP1P2(thisScreen, false, false);
            float y = 110;
            float yGap = 39;
//            string inString = "tilt left and\n";
  //          inString = "right to dodge\n";
            y += yGap;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.position = Utilities.CGPointMake(230, 231);
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_TwistedArrow];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_FadeIn);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetIsFloaty(true);
        }

        public void SetupAboutScreen_4()
        {
 
        }

        public void SetupNoBestTimesInEasy()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_NoBestTimesInEasy;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position.x = 80;
            buttonInfo.position.y = 420;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_Back];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            (screen[(int)thisScreen]).AddButton(buttonInfo);
            const float yStart = 70;
            float y = yStart;
            const float yGap = 40;
            const float xPos = 25;
            const float kWordScale = 0.5f;
            string inString = "sorry there are\n";
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, false, Constants.kColourLilac);
            inString = "no global best\n";
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, false, Constants.kColourLilac);
            inString = "times in\n";
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, false, Constants.kColourLilac);
            inString = "easy mode\n";
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, false, Constants.kColourLilac);
            inString = "try changing to\n";
            y += yGap;
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, false, Constants.kColourLilac);
            inString = "normal on the\n";
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, false, Constants.kColourLilac);
            inString = "options screen\n";
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, false, Constants.kColourLilac);
        }

        public void SetupWaitForDropbox()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_LoadingFilesFromDropbox;
            const float yStart = 70;
            float y = yStart;
            const float yGap = 40;
            const float xPos = 160;
            float kWordScale = 0.44f;
            string inString = "waiting for files\n";
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, Constants.kColourLilac);
            inString = "to load from\n";
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, Constants.kColourLilac);
            inString = "dropbox\n";
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, Constants.kColourLilac);
            inString = "Variables.plist\n";
            y += yGap;
            y += yGap;
            (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
              .kAtlas_FontColours), Utilities.CGPointMake(xPos, y), kWordScale, inString, true, Constants.kColourLightblue);
        }

        public void SetupGreenAnt()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_GreenAnt;
           
			screen[(int)thisScreen].backScreenBillboard.myObject.layer = LayerMask.NameToLayer("tiles");
			
			ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position = Utilities.GetScreenCentre();
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            int buttId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttId)).SetWidth(320);
            ((screen[(int)thisScreen]).GetButton(buttId)).SetHeight(480);
            buttonInfo.position = Utilities.CGPointMake(160.0f, 140.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            //buttId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            //((screen[(int)thisScreen]).GetButton(buttId)).SetIsClickable(false);
            //(((screen[(int)thisScreen]).GetButton(buttId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);

		
			//Setup the green ant and the black square (instead of bothering with glscissor blah)...
			
/*			FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo();
			bInfo.texture = null;
			bInfo.position = Utilities.CGPointMake (160.0f, 200.0f);
			
			bInfo.texture = (Globals.g_world.frontEnd).GetButtonTexture ((int)FrontEnd.Enum.kButtonTexture_ShaunOnPodium);
			bInfo.texture = Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash];
			
			buttId = (screen[(int)thisScreen]).AddButton (bInfo);
			((screen[(int)thisScreen]).GetButton (buttId)).SetIsClickable (false);
			(((screen[(int)thisScreen]).GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			(((screen[(int)thisScreen]).GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			(((screen[(int)thisScreen]).GetButton (buttId)).zobject).myAtlasBillboard.width = Globals.g_world.screenHeight;
			(((screen[(int)thisScreen]).GetButton (buttId)).zobject).myAtlasBillboard.height = Globals.g_world.screenWidth;
			(((screen[(int)thisScreen]).GetButton (buttId)).zobject).myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			*/
		}

        public void SetupLegalScreen()
        {
			//This is actually the "ABOUT" screen... 

            int thisScreen = (int)FrontEndScreenEnum.kFrontEndScreen_Legal;
            int buttonId;
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            const float kZigZagThing = 0.0f;
            const float yStart = 25;
            float y = yStart;
            const float yGap = 65;
            const float xPos = 160;
            const float kWordScale = 0.52f;
            string inString = "";
            int fwId = -1;
            inString = "DATA PRIVACY\n";
            y += yGap;

			//word DATA PRIVACY ==========================

			if (BuildBoss.Instance.buildType != BuildBoss.BuildTypeEnum.AMAZON_SUBSCRIPTION)
			{
				//in the amazon subscription build there is no Analytics so don't show this button
				//fw 0 = data privacy

	            fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], (int) StringId.kString_EULA, Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.
	              kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos - kZigZagThing - 4.0f, y), kWordScale, inString, true);
	            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(250.0f);
			}						
			//==============================================




			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) 
				inString = "Datenschutz- und Cookie-Richtlinie\n";
            else {
				inString = "Privacy and Cookie Policy\n";
            }


			float yPosition = 388.0f;
			if (BuildBoss.Instance.buildType == BuildBoss.BuildTypeEnum.AMAZON_SUBSCRIPTION)
			{
				//for Amazon Subscription we only display the web address... we don't link externally
				inString = "www shaunthesheep com/";//fleece-lightning-terms-privacy";
				yPosition = 380.0f;


				//trying to make this create a word here with the proper font... arial or whatever...
				//the object gets created but it won't show... it's as if it's not part of this screen or something...
				//hmmmm

//				AddButtonWithTextP1P2P3P4P5


//				FrontEndScreen.AddFunnyWordInfo fInfo;
//				fInfo.position = Utilities.CGPointMake(xPos + kZigZagThing - 4.0f, yPosition);
//				fInfo.scale = kWordScale;
//				fInfo.inString = "www.shaunthesheep.com/";
//				fwId = screen[(int)thisScreen].AddFunnyWord(fInfo);


				fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], 
					(int) StringId.kString_Privacy, 
					Globals.g_world.font, 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), 
					Utilities.CGPointMake(xPos + kZigZagThing - 4.0f, yPosition), 
					kWordScale, 
					inString, 
					true);

				((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(250.0f);


				float dotSize = 0.1f;
				yPosition = 384.0f;
				//how i'm doing the dots... ugh....
				inString = "o";

				fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], 
					(int) StringId.kString_Privacy, 
					Globals.g_world.font, 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), 
					Utilities.CGPointMake(79.0f, yPosition), 
					dotSize, 
					inString, 
					true);
				fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], 
					(int) StringId.kString_Privacy, 
					Globals.g_world.font, 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), 
					Utilities.CGPointMake(237.0f, yPosition), 
					dotSize, 
					inString, 
					true);

				inString = "fleece-lightning-terms-privacy";
				yPosition = 380.0f + 16;

				fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], 
					(int) StringId.kString_Privacy, 
					Globals.g_world.font, 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), 
					Utilities.CGPointMake(xPos + kZigZagThing - 4.0f, yPosition), 
					kWordScale, 
					inString, 
					true);

				((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(250.0f);
			
			}
			else
			{
				fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], 
					(int) StringId.kString_Privacy, 
					Globals.g_world.font, 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), 
					Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), 
					Utilities.CGPointMake(xPos + kZigZagThing - 4.0f, yPosition), 
					kWordScale, 
					inString, 
					true);

				((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(250.0f);
			}

            y += yGap;

//            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(250.0f);

			if (BuildBoss.Instance.buildType == BuildBoss.BuildTypeEnum.AMAZON_SUBSCRIPTION)
			{
				//needs a second line to fit it on button
//
//				inString = "fleece-lightning-terms-privacy";
//				yPosition = 380.0f + 16;
//
//				fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], 
//																	(int) StringId.kString_Privacy, 
//																	Globals.g_world.font, 
//																	Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), 
//																	Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), 
//																	Utilities.CGPointMake(xPos + kZigZagThing - 4.0f, yPosition), 
//																	kWordScale, 
//																	inString, 
//																	true);
//				
//				((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(250.0f);
			}

			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) inString = "Nutzungsbedingungen\n";
            else {
                inString = "terms of service\n";
            }

			//overwriting this.
			//inString = "www.shaunthesheep.com/fleece-lightning-terms-privacy";

            y += yGap;
            y = yStart;
            y += (yGap * 3.0f);
            y -= 10;
            ButtonInfo bInfo = new ButtonInfo();
			bInfo.position = Utilities.CGPointMake(160 - kZigZagThing, 240);
//			bInfo.position = Utilities.CGPointMake(160 - kZigZagThing, y);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
			hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
//            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
//            ((screen[(int)thisScreen]).GetFunnyWord(2)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            y -= yGap;
            bInfo.position = Utilities.CGPointMake(160 + kZigZagThing, 380);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;

			//Hanging button with privacy policy on...


			//BUTTON PRIVACY POLICY ==========================

			buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
              (int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);

			if (BuildBoss.Instance.buildType == BuildBoss.BuildTypeEnum.AMAZON_SUBSCRIPTION)
			{
				((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_None);
			}
			else
			{
				((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_LegalPrivacy);
			}

			((screen[(int)thisScreen]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
			((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);

			if (BuildBoss.Instance.buildType == BuildBoss.BuildTypeEnum.AMAZON_SUBSCRIPTION)
			{
				((screen[(int)thisScreen]).GetFunnyWord(0)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
				((screen[(int)thisScreen]).GetFunnyWord(1)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
			}
			else
			{
//				((screen[(int)thisScreen]).GetFunnyWord(0)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
				((screen[(int)thisScreen]).GetFunnyWord(1)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
			}
			//==============================================



			//BUTTON DATA PRIVACY ==========================

			y -= yGap;
            bInfo.position = Utilities.CGPointMake(160 - kZigZagThing, y);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;

			if (BuildBoss.Instance.buildType != BuildBoss.BuildTypeEnum.AMAZON_SUBSCRIPTION)
			{
				buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
				((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
	              (int)World.Enum9.kFE_LongNameButton);
	            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
	            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
				((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_OpenDataPrivacySettings);
	            ((screen[(int)thisScreen]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
				((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
	            ((screen[(int)thisScreen]).GetFunnyWord(0)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
			}
			//==============================================


			//BUTTON TEXT THING ==========================

            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Options;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], buttonId);
            FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
            qInfo.position = Utilities.CGPointMake(160, 240);
            qInfo.boxDimensions = Utilities.CGPointMake(200, 200);
            qInfo.backdropTexture = buttonTexture[(int)Enum.kButtonTexture_QueryBackdrop];
            qInfo.textTexture = null;
            qInfo.noButton = null;
            qInfo.yesButton = null;
            qInfo.useActualText = true;
            qInfo.dimTexture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureDimOverlay);
            float wordScale = 0.39f;
            float wordOffset = -10.0f;
			
			float screenRatio = Screen.width / Screen.height;
			
			if (screenRatio < 0.6f)
			{
				wordScale = 0.35f;
			}
			
			
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_German) {
                qInfo.theInfo1 = "by purchasing and/or using\n";
                qInfo.theInfo2 = "this application you agree\n";
                qInfo.theInfo3 = "to the terms of the\n";
                qInfo.theInfo4 = "end user license agreement\n";
                qInfo.theInfo5 = "and Aardman's privacy policy\n";
				qInfo.theInfo6 = "and terms of service\n";
                qInfo.theInfo7 = "\n";
            }
            else {
                wordScale = 0.32f;
                wordOffset = -24.0f;
                qInfo.theInfo1 = "Durch Kaufen und/oder Verwenden\n";
                qInfo.theInfo2 = "dieser Anwendung stimmst du\n";
                qInfo.theInfo3 = "den Bedingungen der\n";
                qInfo.theInfo4 = "Endbenutzer-Lizenzvereinbarung\n";
                qInfo.theInfo5 = "sowie der Datenschutzrichtlinie\n";
                qInfo.theInfo6 = "und den\n";
                qInfo.theInfo7 = "Nutzungsbedingungen von Aardman zu\n";
            }

            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndQuery.QueryInfoNew nqInfo  = new FrontEndQuery.QueryInfoNew();
                nqInfo.newStyleWithAtlas = false;
                nqInfo.queryText = Globals.g_world.GetNSString ( StringId.kString_EA);
                nqInfo.backdropTexture = qInfo.backdropTexture;
                nqInfo.position = qInfo.position;
                nqInfo.inTextScale = 28.0f;
                nqInfo.boxDimensions = Utilities.CGSizeMake(260.0f, 85.0f);
				nqInfo.numButtons = 0;

                if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    nqInfo.position.y += 0.0f;
                    nqInfo.inTextScale = 15.0f;
                    nqInfo.boxDimensions = Utilities.CGSizeMake(260.0f, 140.0f);
                }
				else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                    nqInfo.inTextScale = 15.0f;
                    nqInfo.boxDimensions = Utilities.CGSizeMake(260.0f, 140.0f);
                }

                nqInfo.yesButton = null;
                nqInfo.noButton = null;
                (screen[(int)thisScreen]).AddQueryNew(nqInfo);
            }
            else {
                int qId = (screen[(int)thisScreen]).AddQuery(qInfo);
                ((screen[(int)thisScreen]).GetQuery(qId)).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours));
                ((screen[(int)thisScreen]).GetQuery(qId)).SetNoDimZob(true);
                ((screen[(int)thisScreen]).GetQuery(qId)).SetWordScale(wordScale);
                ((screen[(int)thisScreen]).GetQuery(qId)).SetWordGap(20.0f);
                (((screen[(int)thisScreen]).GetQuery(qId)).backdrop).SetShowScale(1.2f);
                ((screen[(int)thisScreen]).GetQuery(qId)).SetWordOffset(wordOffset);
            }

        }

        int AddButtonWithTextP1P2P3P4P5(FrontEndScreenEnum inScreen, ButtonInfo bInfo, HangingButton.HangingButtonInfo hInfo, int stringId, float wordScale, CGPoint
          wordOffset)
        {
            int buttonId = (screen[(int)inScreen]).AddButton((bInfo));
            ((screen[(int)inScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            CGPoint wordPos = bInfo.position;
            wordPos.x += wordOffset.x;
            wordPos.y += wordOffset.y;
            int fwId = -1;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) 
			{
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = wordPos;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                    fInfo.scale = 0.4f;
                }
                else 
				{
                    fInfo.scale = wordScale;
                }

                fInfo.inString = Globals.g_world.GetNSString((StringId)stringId);
                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWord(fInfo);
            }
            else {
                string buttonName = Globals.g_world.GetString((StringId)stringId);
                fwId = (screen[(int)inScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours), wordPos, wordScale, buttonName, true);
            }

            HangingButton hb = ((screen[(int)inScreen]).GetButton(buttonId)).hangingButton;
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetFunnyWord(fwId)).SetPositionButton((screen[(int)inScreen]).GetButton(buttonId));
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetFunnyWord(fwId)).SetOrientationButton(hb);
            return buttonId;
        }

        public void SetupOptionsScreen()
        {
            int thisScreen = (int) FrontEndScreenEnum.kFrontEndScreen_Options;
            int buttonId;
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            const float kZigZagThing = 0.0f;
            const float yStart = 25;
            float y = yStart;
            const float yGap = 55;
            const float xPos = 160;
            const float kWordScale = 0.52f;
            const float kWordScaleCh = 0.4f;
            int fwId = -1;
            string inString = "diff\n";
            y += yGap;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = Utilities.CGPointMake(xPos - kZigZagThing - 4.0f, y - 3.0f);
                fInfo.scale = kWordScaleCh;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Music);
                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWord(fInfo);
            }
            else {
                inString = Globals.g_world.GetString((StringId) StringId.kString_Music);
                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.
                  kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos - kZigZagThing - 4.0f, y), kWordScale, inString,
                  true);
            }

            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetFunnyWord(fwId)).FitToWidth(170.0f);
            y += yGap;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = Utilities.CGPointMake(xPos - kZigZagThing - 4.0f, y - 3.0f);
                fInfo.scale = kWordScaleCh;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_SoundFX);
                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWord(fInfo);
            }
            else {
                inString = "fx\n";
                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.
                  kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos + kZigZagThing - 4.0f, y), kWordScale, inString,
                  true);
            }

            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetFunnyWord(fwId)).FitToWidth(170.0f);
            y += yGap;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = Utilities.CGPointMake(xPos - kZigZagThing - 4.0f, y - 3.0f);
                fInfo.scale = kWordScaleCh;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Ghost);
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                    fInfo.scale = 0.32f;
                }

                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWord(fInfo);
            }
            else {
                inString = Globals.g_world.GetString((StringId) StringId.kString_Ghost);
                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.
                  kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos - kZigZagThing - 4.0f, y), kWordScale, inString,
                  true);
            }

            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetFunnyWord(fwId)).FitToWidth(170.0f);
            inString = "control method\n";
            y += yGap;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = Utilities.CGPointMake(xPos - kZigZagThing - 4.0f, y + 6.0f);
                fInfo.scale = kWordScale;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_ControlMethod);
                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWord(fInfo);
            }
            else {
                inString = Globals.g_world.GetString((StringId) StringId.kString_ControlMethod);
                fwId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.
                  kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos - kZigZagThing - 4.0f, y), kWordScale, inString,
                  true);
            }

            buttonInfo.position = Utilities.CGPointMake(160, yStart + (yGap * 4.0f));
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetSoundEffectId((int)Audio.Enum1.kSoundEffect_Swish);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ChangeControlInOptions);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
              (int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            hInfo.showWobbleMultiplier = 1.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(1.0f, -15.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            y = yStart;
            y += (yGap * 3.0f);
            y -= 10;
            ButtonInfo bInfo = new ButtonInfo();
            bInfo.position = Utilities.CGPointMake(160 - kZigZagThing, y);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),(int) (int)World.Enum9.kFE_BlankButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            ((screen[(int)thisScreen]).GetFunnyWord(2)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            y -= yGap;
            bInfo.position = Utilities.CGPointMake(160 + kZigZagThing, y);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_BlankButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            ((screen[(int)thisScreen]).GetFunnyWord(1)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            y -= yGap;
            bInfo.position = Utilities.CGPointMake(160 - kZigZagThing, y);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_BlankButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            ((screen[(int)thisScreen]).GetFunnyWord(0)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            y = yStart + (yGap * 5.5f);
            bInfo.position = Utilities.CGPointMake(100 + kZigZagThing, y);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
            optionsControl = (short)buttonId;
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), Globals.g_world.
              GetSubTextLanguageP1((int) AtlasType.kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_Tilt));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetSoundEffectId((int)Audio.Enum1.kSoundEffect_Swish);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ChangeControlInOptions);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetWaitToShow(0.0f);
            hInfo.showWobbleMultiplier = 1.15f;
            hInfo.type = HangingButtonType.kHB_Chain;
            hInfo.subTextureId = 200;
            hInfo.offset = Utilities.CGPointMake(42.0f, -17.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_ControlTilt);
                fInfo.position = bInfo.position;
                fInfo.position.x -= 4.0f;
                fInfo.position.y += 6.0f;
                fInfo.scale = 0.38f;
                controlWordId = (short)(screen[(int)thisScreen]).AddFunnyWord(fInfo);
                ((screen[(int)thisScreen]).GetFunnyWord(controlWordId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
                ((screen[(int)thisScreen]).GetFunnyWord(controlWordId)).SetPositionButton((screen[(int)thisScreen]).GetButton(buttonId));
            }

            y = yStart;
            float yForPad = 0.0f;
						if (Globals.useIPadBackScreens) {
                //yForPad = -16.0f;
            }

            const float xSwitchPos = 160;
            SwitchInfo sInfo = new SwitchInfo();
            sInfo.texture[(int) SwitchState.kSwitch_On] = null;
            sInfo.texture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_On] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.position = Utilities.CGPointMake(160, y + yForPad);
            int switchId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddSwitch(sInfo);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton((SwitchState)0)).SetHeight(35.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton((SwitchState)1)).SetHeight(35.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton(SwitchState.kSwitch_On)).AddLabelP1(sInfo.
              labelTexture[(int) SwitchState.kSwitch_On], Utilities.CGPointMake(0.0f, 0));
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton(SwitchState.kSwitch_Off)).AddLabelP1(sInfo.
              labelTexture[(int) SwitchState.kSwitch_Off], Utilities.CGPointMake(-10.0f, 0));
            y += yGap;
            sInfo.texture[(int) SwitchState.kSwitch_On] = null;
            sInfo.texture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_On] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_Off] = buttonTexture[(int)Enum.kButtonTexture_SwitchOff];
            sInfo.position = Utilities.CGPointMake(xSwitchPos - kZigZagThing, y + yForPad);
            int sId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddSwitch(sInfo);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).SetActionId( FrontEndActions.kFrontEndAction_MusicPreference);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton( 
              SwitchState.kSwitch_On)).AddLabelP1(sInfo.labelTexture[(int) SwitchState.kSwitch_On], Utilities.CGPointMake(0, 0));
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton( SwitchState.kSwitch_Off)).AddLabelP1(sInfo.
              labelTexture[(int) SwitchState.kSwitch_Off], Utilities.CGPointMake(0, 0));
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).SetHeight(35.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).SetHeight(35.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).SetWidth(60.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).SetWidth(60.0f);
            const float kBackShowScale = 0.68f;
            const float kWordShowScale = 0.92f;
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).zobject).SetShowScale(kBackShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).zobjectLabel).SetShowScale(kWordShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).zobject).SetShowScale(kBackShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).zobjectLabel).SetShowScale(kWordShowScale);
             (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId))).SetLayerMask();
			y += yGap;
            sInfo.position = Utilities.CGPointMake(xSwitchPos + kZigZagThing, y + yForPad);
            sId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddSwitch(sInfo);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).SetActionId( FrontEndActions.kFrontEndAction_SoundFxPreference);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton( 
              SwitchState.kSwitch_On)).AddLabelP1(sInfo.labelTexture[(int) SwitchState.kSwitch_On], Utilities.CGPointMake(0, 0));
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton( SwitchState.kSwitch_Off)).AddLabelP1(sInfo.
              labelTexture[(int) SwitchState.kSwitch_Off], Utilities.CGPointMake(0, 0));
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).zobject).SetShowScale(kBackShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).zobjectLabel).SetShowScale(kWordShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).zobject).SetShowScale(kBackShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).zobjectLabel).SetShowScale(kWordShowScale);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).SetHeight(35.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).SetHeight(35.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).SetWidth(60.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).SetWidth(60.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId))).SetLayerMask();
            y += yGap;
            sInfo.position = Utilities.CGPointMake(xSwitchPos - kZigZagThing, y + yForPad);
            sId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddSwitch(sInfo);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton( 
              SwitchState.kSwitch_On)).AddLabelP1(sInfo.labelTexture[(int) SwitchState.kSwitch_On], Utilities.CGPointMake(0, 0));
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton( SwitchState.kSwitch_Off)).AddLabelP1(sInfo.
              labelTexture[(int) SwitchState.kSwitch_Off], Utilities.CGPointMake(0, 0));
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).zobject).SetShowScale(kBackShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).zobjectLabel).SetShowScale(kWordShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).zobject).SetShowScale(kBackShowScale);
            ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).zobjectLabel).SetShowScale(kWordShowScale);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).SetHeight(35.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).SetHeight(35.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)0)).SetWidth(60.0f);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId)).GetButton((SwitchState)1)).SetWidth(60.0f);
			 (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(sId))).SetLayerMask();
            y += yGap;
            sInfo.position = Utilities.CGPointMake(xSwitchPos + kZigZagThing, y + yForPad);
            sInfo.texture[(int) SwitchState.kSwitch_On] = null;
            sInfo.texture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_On] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.texture[(int) SwitchState.kSwitch_On] = null;
            sInfo.texture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_On] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_Off] = null;
            y += 50;
            sInfo.position = Utilities.CGPointMake(xSwitchPos, y + yForPad);
            sInfo.texture[(int) SwitchState.kSwitch_On] = null;
            sInfo.texture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_On] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.texture[(int) SwitchState.kSwitch_On] = null;
            sInfo.texture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_On] = null;
            sInfo.labelTexture[(int) SwitchState.kSwitch_Off] = null;
            sInfo.position = Utilities.CGPointMake(270.0f, yStart + yGap - 8);
			
//            switchId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddSwitch(sInfo);
  //          int facebookSwitchId = switchId;
    //        (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton((SwitchState)0)).SetHeight(35.0f);
      //      (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton((SwitchState)1)).SetHeight(35.0f);
        //    (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton((SwitchState)(int) SwitchState.kSwitch_On)).SetAtlasAndSubtextureP1(
      //        Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_FBLogin);
        //    (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( 
       //       SwitchState.kSwitch_Off)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_FBLogoff);
       //     if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
        //        (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( SwitchState.kSwitch_On)).
          //        SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_FaceBookEmpty);
            //    (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( SwitchState.kSwitch_Off)).
              //    SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_FaceBookEmpty);
            //}

  //          ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( 
    //          SwitchState.kSwitch_On)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
      //      ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( SwitchState.kSwitch_Off)).zobject).
     //         SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
       //     ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( 
       //       SwitchState.kSwitch_On)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
        //    ((((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( SwitchState.kSwitch_Off)).zobject).
        //  //    SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
          //  (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( SwitchState.kSwitch_On)).SetActionId(
         //     FrontEndActions.kFrontEndAction_FBLogin);
         //   (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( SwitchState.kSwitch_Off)).SetActionId(
         //     FrontEndActions.kFrontEndAction_FBLogoff);
            hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Chain;
            hInfo.subTextureId = (int)World.Enum9.kFE_Chain;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
      ////      (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( SwitchState.kSwitch_On)).AddHangingButton(hInfo);
          //  (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(switchId)).GetButton( SwitchState.kSwitch_Off)).AddHangingButton(hInfo)
            //  ;

						float extraForThinScreens = 0.0f;

						float aboutDistanceFromEdge = 60.0f;
//						if (Globals.deviceIPhone5)
						if (Globals.g_world.xScreenEdgeReal > 5.0f)								
						{
								aboutDistanceFromEdge = 46.0f;
//								extraForThinScreens = 2.0f;
								hInfo.hangingButtonScale = 0.78f;
						}

//						Globals.useIPadBackScreens


						buttonInfo.position = Utilities.CGPointMake(extraForThinScreens + xBackButton, sInfo.position.y);
            
						buttonInfo.position.x = Globals.g_world.xScreenEdgeReal + aboutDistanceFromEdge;

						buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Legal;
            float wordScale = 0.5f;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                wordScale = 0.26f;
            }
			else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                wordScale = 0.35f;
            }

            CGPoint offsetThing = Utilities.CGPointMake(-5.0f, 7.0f);
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                offsetThing = Utilities.CGPointMake(-14.0f, 1.0f);
				
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                	offsetThing = Utilities.CGPointMake(-6.0f, 5.0f);
            	}
            }
								
            buttonId = this.AddButtonWithTextP1P2P3P4P5((FrontEndScreenEnum)thisScreen, buttonInfo, hInfo, (int) StringId.kString_About, wordScale, offsetThing);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_BlankButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);

						hInfo.hangingButtonScale = 1.0f;



						buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);



            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            int backButtonId = buttonId;
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position.x = 220.0f;
            buttonInfo.position.y = 360.0f;
            buttonInfo.texture = this.GetButtonTexture((int)Enum.kButtonTexture_HowToTiltH);
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddButton(buttonInfo);
            optionsControlImage = buttonId;
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetSoundEffectId((int)Audio.Enum1.kSoundEffect_Swish);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetActionId( FrontEndActions.
              kFrontEndAction_ChangeControlInOptions);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetWidth(80.0f);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetHeight(80.0f);

            #if UNLOCK_ALL_BUTTON_IN_OPTIONS
                buttonInfo.position.x = 257;
                buttonInfo.position.y = 440.0f;
                buttonInfo.texture = null;
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddButton(buttonInfo);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.
                  kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Total);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetActionId( FrontEndActions.
                  kFrontEndAction_UnlockAllLevels);

                #if MULTIPLAYER_ENABLED
                    buttonInfo.position.x = 117;
                    buttonInfo.position.y = 440.0f;
                    buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_ButtonLittleCloud);
                    buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                    buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).AddButton(buttonInfo);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetButton(buttonId)).SetActionId( FrontEndActions.
                      kFrontEndAction_FakeMultiplayer);
                #endif

            #endif

            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], backButtonId);
        //        Globals.g_world.AddWordsP1P2(Globals.g_world.GetNSString ( StringId.kString_FBLogin), screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options], ((screen[(
          //        int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(facebookSwitchId)).GetButton((int) SwitchState.kSwitch_On));
            //    Globals.g_world.AddWordsP1P2(Globals.g_world.GetNSString ( StringId.kString_FBLogout), screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options], ((screen[(
              //    int) FrontEndScreenEnum.kFrontEndScreen_Options]).GetSwitch(facebookSwitchId)).GetButton((int) SwitchState.kSwitch_Off));
            }

        }

        public void SetupTest()
        {
        }

        bool IsBonusCloudVisible()
        {
            return false;
        }

        public void SetupCloudButtPositionsOnMain()
        {
            int i = 0;
            const float yTopLine = 155.0f;
            const float yBottomLine = 215.0f;
            const float xWidthTop = 186.0f;
            const float xWidthBott = 120.0f;
            float xStart = (320.0f - xWidthTop) / 2.0f;
            float xPlus = xWidthTop / 2.0f;
            CGPoint buttonPosition = Utilities.CGPointMake(xStart, yTopLine);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(i + 5)).ChangePosition(Utilities.CGPointMake(buttonPosition.x, buttonPosition.y - 3.0f));
            buttonPosition.x += xPlus;
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(i + 1)).ChangePosition(Utilities.CGPointMake(buttonPosition.x + 8.0f, buttonPosition.y +
              0.0f));
            buttonPosition.x += xPlus;
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(i + 3)).ChangePosition(Utilities.CGPointMake(buttonPosition.x, buttonPosition.y - 3.0f));
            xStart = (320.0f - xWidthBott) / 2.0f;
            xPlus = xWidthBott;
            buttonPosition = Utilities.CGPointMake(xStart, yBottomLine);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(i + 4)).ChangePosition(buttonPosition);
            buttonPosition.x += xPlus;
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(i + 2)).ChangePosition(Utilities.CGPointMake(buttonPosition.x, buttonPosition.y + 0.0f));
        }

        public void SetupContolChoice_Final()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Final;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position = Utilities.CGPointMake(160, 450);
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_FarmBottom];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_FinishedViewingControlChoiceSetup);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale((320.0f / 256.0f));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position.x = 320 - 42;
            buttonInfo.position.y = kChooseTrackBottomButtonsPos;
            buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_Done);
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseStage;
            buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.9f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetThrobSize(0.075f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetThrobTime(0.4f);
            string inString = "you can\n";
            float yPlus = 33.0f;
            float xPos = 160;
            float y = 160;
            int fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), 0.5f, inString, true, Constants.kColourLightblue);
            inString = "change your control\n";
            y += yPlus;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), 0.5f, inString, true, Constants.kColourLightblue);
            inString = "choice at any time\n";
            y += yPlus;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), 0.5f, inString, true, Constants.kColourLightblue);
            inString = "from the options\n";
            y += yPlus;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, y), 0.5f, inString, true, Constants.kColourLightblue);
        }

        public void SetupChooseControls()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ChooseControls;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 160;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_HowToTiltH];
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 160;
            buttonInfo.texture = this.GetButtonTexture((int)Enum.kButtonTexture_HowToFinger);
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 160;
            buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_HowToThumbs);
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            float wordScale = 0.5f;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) wordScale = 0.45f;

            string inString = "\n";
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) inString = "Ger#t zum Steuern nach\n";
            else {
                inString = "tilt left and\n";
            }

            float xPos = 160;
            float y = 245;
            int fwid;
            if (Globals.g_world.DoesCurrentLanguageUseNSString())
			{
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_TiltLeftAnd1);
                fInfo.position = Utilities.CGPointMake(xPos, y);
                fInfo.scale = wordScale;
                fwid = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
	           ((screen[(int)thisScreen]).GetFunnyWord(fwid)).FitToWidth(226.0f);				
            }
            else {
                fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
                  xPos, y), wordScale, inString, true, Constants.kColourWhite);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) inString = "links und rechts neigen\n";
            else {
                inString = "right to steer\n";
            }

            xPos = 160;
            y = 280;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_TiltLeftAnd2);
                fInfo.position = Utilities.CGPointMake(xPos, y);
                fInfo.scale = wordScale;
                fwid = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
	           ((screen[(int)thisScreen]).GetFunnyWord(fwid)).FitToWidth(226.0f);
			}
            else {
                fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
                  xPos, y), wordScale, inString, true, Constants.kColourWhite);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) inString = "Lass Shaun deinem\n";
            else {
                inString = "let shaun follow\n";
            }

            xPos = 160;
            y = 245;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_FingerFollow1);
                fInfo.position = Utilities.CGPointMake(xPos, y);
                fInfo.scale = wordScale;
                fwid = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
	           ((screen[(int)thisScreen]).GetFunnyWord(fwid)).FitToWidth(226.0f);												
            }
            else {
                fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
                  xPos, y), wordScale, inString, true, Constants.kColourWhite);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) inString = "Finger folgen\n";
            else {
                inString = "your finger\n";
            }

            xPos = 160;
            y = 280;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_FingerFollow2);
                fInfo.position = Utilities.CGPointMake(xPos, y);
                fInfo.scale = wordScale;
                fwid = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
	           ((screen[(int)thisScreen]).GetFunnyWord(fwid)).FitToWidth(226.0f);								
            }
            else {
                fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
                  xPos, y), wordScale, inString, true, Constants.kColourWhite);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) inString = "Zum Steuern Links und\n";
            else {
                inString = "press left and right\n";
            }

            xPos = 160;
            y = 245;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_ButtonControl1);
                fInfo.position = Utilities.CGPointMake(xPos, y);
                fInfo.scale = wordScale;
                fwid = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
	           ((screen[(int)thisScreen]).GetFunnyWord(fwid)).FitToWidth(226.0f);								
			}
            else {
                fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
                  xPos, y), wordScale, inString, true, Constants.kColourWhite);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) inString = "Rechts-Tasten dr%cken\n";
            else {
                inString = "buttons to steer\n";
            }

            xPos = 160;
            y = 280;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_ButtonControl2);
                fInfo.position = Utilities.CGPointMake(xPos, y);
                fInfo.scale = wordScale;
                fwid = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
	           ((screen[(int)thisScreen]).GetFunnyWord(fwid)).FitToWidth(226.0f);												
            }
            else {
                fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
                  xPos, y), wordScale, inString, true, Constants.kColourWhite);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            buttonInfo.position.x = 160.0f;
            buttonInfo.position.y = 440.0f;
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseStage;
            buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetSubTextLanguageP1((int) AtlasType.kAtlas_ShowLevelAndTip, (int)World.Enum6.kSSH_PlaySign));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ChooseThumbInControlChoiceSetup);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToBottom);
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            hInfo.showWobbleMultiplier = 0.3f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = 100;
            hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton).WobbleDeclineMultiplier(2.0f);
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Play);
                fInfo.position = buttonInfo.position;
                fInfo.position.y -= 2.0f;
                fInfo.scale = 0.25f;
				
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French)
				{
					fInfo.scale = 0.45f;
				}				
				
                int fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetPositionButton((screen[(int)thisScreen]).GetButton(buttonId));
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            }

            const float bigButtPos = 74.0f;
            buttonInfo.position = Utilities.CGPointMake(160, bigButtPos);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
              (int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            hInfo.showWobbleMultiplier = 1.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            float kWordScale = 0.63f;
            xPos = 160.0f;
            int fwId2;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_ChooseControl);
                fInfo.position = Utilities.CGPointMake(xPos, bigButtPos + 6.0f);
                fInfo.scale = kWordScale * 0.8f;
                fwId2 = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
            }
            else {
                inString = Globals.g_world.GetString((StringId) StringId.kString_ChooseControl);
                fwId2 = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, bigButtPos + 6.0f), kWordScale, inString, true);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwId2)).SetColour(Constants.kColourRed);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId2)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId2)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId2)).FitToWidth(240.0f);
            float sideArrowAdd = 0.0f;
						if (Globals.useIPadBackScreens) {
                sideArrowAdd = 0.0f;
            }

            buttonInfo.position = Utilities.CGPointMake(37.0f - sideArrowAdd, kChooseStageMainIconYPos);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            chooseControlsSideButtonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(chooseControlsSideButtonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
              (int)World.Enum9.kFE_Left);
            ((screen[(int)thisScreen]).GetButton(chooseControlsSideButtonId)).SetActionId( FrontEndActions.kFrontEndAction_ControlsSelectGoBackOne);
            ((screen[(int)thisScreen]).GetButton(chooseControlsSideButtonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            (((screen[(int)thisScreen]).GetButton(chooseControlsSideButtonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            (((screen[(int)thisScreen]).GetButton(chooseControlsSideButtonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            (((screen[(int)thisScreen]).GetButton(chooseControlsSideButtonId)).zobject).SetWaitToShow(0.3f);
            (((screen[(int)thisScreen]).GetButton(chooseControlsSideButtonId)).zobject).SetShowScale(0.6f);
            buttonInfo.position = Utilities.CGPointMake(283.0f + sideArrowAdd, kChooseStageMainIconYPos);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Right);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ControlsSelectGoForwardOne);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetWaitToShow(0.3f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.6f);
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
        }

        public void SetupContolChoice_ShowThumb()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowThumb;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 220;
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 160;
            buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_HowToThumbs);
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            string inString = "\n";
            inString = "press left and right\n";
            float xPos = 160;
            float y = 245;
            int fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
              xPos, y), 0.5f, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            inString = "buttons to steer\n";
            xPos = 160;
            y = 280;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), 0.5f, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            buttonInfo.position.x = 320.0f - 42.0f;
            buttonInfo.position.y = 350.0f;
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseStage;
            buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Right);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ChooseThumbInControlChoiceSetup);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.6f);
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], buttonId);
        }

        public void SetupContolChoice_ShowFinger()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowFinger;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 220;
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 160;
            buttonInfo.texture = this.GetButtonTexture((int)Enum.kButtonTexture_HowToFinger);
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            string inString = "\n";
            inString = "let shaun follow\n";
            float xPos = 160;
            float y = 245;
            int fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
              xPos, y), 0.5f, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            inString = "your finger\n";
            xPos = 160;
            y = 280;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), 0.5f, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            buttonInfo.position.x = 320.0f - 42.0f;
            buttonInfo.position.y = 350.0f;
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseStage;
            buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Right);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ChooseFingerInControlChoiceSetup);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.6f);
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], buttonId);
        }

        public void SetupContolChoice_ShowTilt()
        {
        }

        public void SetupContolChoice_ShowTiltExpert()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTiltExpert;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 280;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_HowToTiltH];
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.75f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 110;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_HowToTiltV];
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.75f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            string inString = "\n";
            inString = "up and down for speed\n";
            float xPos = 160;
            float y = 180;
            float letterScale = 0.46f;
            int fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
              xPos, y), letterScale, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            inString = "left and right to steer\n";
            y = 350;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), letterScale, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            buttonInfo.position = Utilities.CGPointMake(160, 450);
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_FarmBottom];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale((320.0f / 256.0f));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(42.0f, kChooseTrackBottomButtonsPos);
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_Back];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTilt;
            buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.9f);
            buttonInfo.position.x = 320.0f - 42.0f;
            buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_Done);
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseStage;
            buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ChooseTiltInControlChoiceSetupExpert);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.9f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetThrobSize(0.075f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetThrobTime(0.4f);
        }

        public void SetupContolChoice_ShowTiltAuto()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTiltAuto;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            int buttonId;
            buttonInfo.position.x = 160;
            buttonInfo.position.y = 160;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_HowToTiltH];
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.85f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            string inString = "\n";
            inString = "tilt device\n";
            float xPos = 160;
            float y = 240;
            float letterScale = 0.46f;
            int fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(
              xPos, y), letterScale, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            inString = "left and right to steer\n";
            y = 275;
            fwid = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6P7(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos
              , y), letterScale, inString, true, Constants.kColourWhite);
            ((screen[(int)thisScreen]).GetFunnyWord(fwid)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            buttonInfo.position.x = 320.0f - 42.0f;
            buttonInfo.position.y = 350.0f;
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseStage;
            buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Right);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ChooseTiltInControlChoiceSetupAuto);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.6f);
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], buttonId);
        }

        public void SetupContolChoice_Choose()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ControlChoice_Choose;
            ButtonInfo buttonInfo = new ButtonInfo();
            int buttonId;
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            const float bigButtPos = 74.0f;
            const float lilButtPos = 195.0f;
            const float thumbButtPos = 220.0f;
            const float tiltButtPos = 300.0f;
            buttonInfo.position = Utilities.CGPointMake(160.0f, tiltButtPos);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowTiltAuto;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), Globals.g_world.
              GetSubTextLanguageP1((int) AtlasType.kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_Tilt));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetWaitToShow(0.0f);
            hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Chain;
            hInfo.subTextureId = (int)World.Enum9.kFE_Chain;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton).SetLongerRope(3.0f);
            buttonInfo.position = Utilities.CGPointMake(230, lilButtPos);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowFinger;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), Globals.g_world.
              GetSubTextLanguageP1((int) AtlasType.kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_FingerButt));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetWaitToShow(0.0f);
            hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Chain;
            hInfo.subTextureId = (int)World.Enum9.kFE_Chain;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton).SetLongerRope(1.0f);
            buttonInfo.position = Utilities.CGPointMake(90, thumbButtPos);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ControlChoice_ShowThumb;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), Globals.g_world.
              GetSubTextLanguageP1((int) AtlasType.kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_Thumb));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetWaitToShow(0.0f);
            hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Chain;
            hInfo.subTextureId = (int)World.Enum9.kFE_Chain;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton).SetLongerRope(2.0f);
            buttonInfo.position = Utilities.CGPointMake(160, bigButtPos);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
              (int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            hInfo.showWobbleMultiplier = 1.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            float kWordScale = 0.63f;
            float xPos = 160.0f;
            string inString = "";
            inString = Globals.g_world.GetString((StringId) StringId.kString_ControlMethod);
            int fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, bigButtPos + 6.0f), kWordScale, inString, true);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kColourRed);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyleNew( (int)ZobjectShowStyle.kZobjectShow_Immediate);
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
        }
		
        public void SetupStoreScreen()
        {
        	return;
        	
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_Store;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            float yPlus = 200.0f;
            float yOffForRestore = 75.0f;
            float yStart = 105.0f;
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
  //          ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),0);

			((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
//            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip),9);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], buttonId);
            buttonInfo.position = Utilities.CGPointMake(160.0f, yStart + yOffForRestore);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
            int fwId = -1;
            if (true)//Globals.g_currentLanguage != World.Enum11.kLanguage_English) 
			{
                const float kErstWordScale = 0.32f;
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) 
				{
                    FrontEndScreen.AddFunnyWordInfo fInfo;
                    fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 2.0f, yStart + yOffForRestore - 3.0f);
                    fInfo.scale = kErstWordScale;
                    fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Restore);
                    fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
                    ((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(80.0f);
                }
                else {
                    string inString = "";
                    inString = Globals.g_world.GetString((StringId) StringId.kString_Restore);
                    fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
                      int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 2.0f, yStart + yOffForRestore), 0.36f, inString, true);
                }

                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_StartSmallButton1);
            }
            else {
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Create);
            }

            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            ////(((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetFloatyInfoo(floatyInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(80);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(70);
			((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId(FrontEndActions.kFrontEndAction_RestoreRemoveAds);			
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                HangingButton hb = ((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton;
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(hb);
            }
			
            buttonInfo.position = Utilities.CGPointMake(160.0f, yStart);
            buttonInfo.texture = null;
            buttonInfo.textureLabel = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
           // //(((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetFloatyInfoo(floatyInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(80);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(70);
			((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId(FrontEndActions.kFrontEndAction_BuyRemoveAds);			
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
            hInfo.subTextureId = 200;
            hInfo.showWobbleMultiplier = 1.0f;
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            Constants.RossColour darkStart;
            darkStart.cRed = 0.4f * 0.6f;
            darkStart.cGreen = 0.15f * 0.6f;
            darkStart.cBlue = 0.01f * 0.6f;
            float wordScale = 0.45f;
						
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 2.0f, yStart + 0.0f);
                fInfo.scale = 0.6f;
				
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French)
				{
					fInfo.scale = 0.42f;//5f;
				}				
				
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_BuyNoAds);
                fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
            }
            else {
                string inString = "";
                inString = Globals.g_world.GetString((StringId) StringId.kString_BuyNoAds);
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_English) {
                    wordScale = 0.42f;
                }

                fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 32.0f, yStart + 5.0f), wordScale, inString, true);
            }
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
			
			//And add the price...
			
	        FrontEndScreen.AddFunnyWordInfo fInfo2;
			fInfo2.position = Utilities.CGPointMake(buttonInfo.position.x + 100.0f, yStart + 4.0f);
            fInfo2.scale = 0.4f;			
            fInfo2.inString = "£0.69";
            fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo2);
			((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetUseTextureInstead(true);
//            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(darkStart);
		
			yStart += yPlus;
			
			
			
			
            buttonInfo.position = Utilities.CGPointMake(160.0f, yStart + yOffForRestore);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
//            int fwId = -1;

            if (true)//Globals.g_currentLanguage != World.Enum11.kLanguage_English) 
			{
                const float kErstWordScale = 0.32f;
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) 
				{
                    FrontEndScreen.AddFunnyWordInfo fInfo;
                    fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 2.0f, yStart + yOffForRestore - 3.0f);
                    fInfo.scale = kErstWordScale;
                    fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Restore);
                    fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
                    ((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(80.0f);
                }
                else {
                    string inString = "";
                    inString = Globals.g_world.GetString((StringId) StringId.kString_Restore);
                    fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
                      int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 2.0f, yStart + yOffForRestore), 0.36f, inString, true);
                }

                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_StartSmallButton1);
            }
            else {
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Create);
            }

            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            ////(((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetFloatyInfoo(floatyInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(80);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(70);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId(FrontEndActions.kFrontEndAction_RestoreUnlockAllLevels);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
           // HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                HangingButton hb = ((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton;
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(hb);
            }
			
            buttonInfo.position = Utilities.CGPointMake(160.0f, yStart);
            buttonInfo.texture = null;
            buttonInfo.textureLabel = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
           // //(((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetFloatyInfoo(floatyInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(80);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(70);
			((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId(FrontEndActions.kFrontEndAction_BuyUnlockAllLevels);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
            hInfo.subTextureId = 200;
            hInfo.showWobbleMultiplier = 1.0f;
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
						
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 2.0f, yStart + 0.0f);
                fInfo.scale = 0.6f;
				
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French)
				{
					fInfo.scale = 0.42f;//5f;
				}				
				
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_BuyAllLevels);
                fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
            }
            else {
                string inString = "";
                inString = Globals.g_world.GetString((StringId) StringId.kString_BuyAllLevels);
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_English) {
                    wordScale = 0.42f;
                }

                fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 32.0f, yStart + 5.0f), wordScale, inString, true);
            }
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
			
			//And add the price...
			
			fInfo2.position = Utilities.CGPointMake(buttonInfo.position.x + 100.0f, yStart + 4.0f);
            fInfo2.scale = 0.4f;			
            fInfo2.inString = "£0.69";
            fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo2);
			((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetUseTextureInstead(true);
//            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(darkStart);			
			
		}

        public void SetupMainScreen()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_Main;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            int buttonId;
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            const float kOutButtonLeft = 105.0f;
            const float kOutButtonRight = 218.0f;
            const float kRow1 = 165.0f;
            const float kRow2 = 215.0f;
            hInfo.showWobbleMultiplier = 1.15f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
			
			int fwId = -1;
			
            buttonInfo.position = Utilities.CGPointMake(kOutButtonRight, kRow2 + 22.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Store;
			
//			if (Constants.IAP_VERSION)
//			{
//				buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
//	            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
//	              kAtlas_FrontendAndShowlevel));
//	            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_HideNewsTab);
//	            if (true) //Globals.g_currentLanguage != World.Enum11.kLanguage_English) 
//				{
//	                const float kErstWordScale = 0.32f;
//	                string inString = "";
//	                inString = Globals.g_world.GetNSString ( StringId.kString_Store);
//	                if (!Globals.g_world.DoesCurrentLanguageUseNSString()) {
//	                    fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
//	                      int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 2.0f, buttonInfo.position.y - 2.0f), 0.36f, inString, true);
//	                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyle( 
//	                      FunnyWordShowStyle.kFunnyWordShow_Immediate);
//	                }
//	                else {
//	                    FrontEndScreen.AddFunnyWordInfo fInfo;
//	                    fInfo.scale = kErstWordScale;
//	                    fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Store);
//	                    if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_French))
//						{
//	                    }
//	                    else {
//	                        fInfo.scale = 0.26f;
//	                    }
//	
//	                    fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 1.0f, buttonInfo.position.y - 3.0f);
//	                    fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
//	                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyleNew((int) (int) ZobjectShowStyle.
//	                      kZobjectShow_Immediate);
//	                }
//	
//	                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
//	                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_StartSmallButton1);
//	            }
//	            else {
//	                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Create);
//	            }
//	
//	            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
//	              kZobjectShow_Immediate);
//	            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) 
//	              ZobjectHideStyle.kZobjectHide_DontHide);
//	            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetWidth(80);
//	            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetHeight(70);
//	            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
//	            hInfo.offset = Utilities.CGPointMake(0.1f, -5.0f);
//	            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
//	            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
//	                HangingButton hb = ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).hangingButton;
//	                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetOrientationButton(hb);
//	            }				
//			
//			
//			}
			
			
            buttonInfo.position = Utilities.CGPointMake(kOutButtonRight, kRow1 + 19.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Options;
            buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
              kAtlas_FrontendAndShowlevel));
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_HideNewsTab);
            fwId = -1;
            float kWordScale = 0.36f;
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                string inString = "";
                inString = "Optionen\n";
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
                      int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 2.0f, buttonInfo.position.y), kWordScale, inString, true);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyle( 
                      FunnyWordShowStyle.kFunnyWordShow_Immediate);
                }
                else {
                    FrontEndScreen.AddFunnyWordInfo fInfo;
                    fInfo.scale = 0.32f;
                    if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                        fInfo.inString = "选项";
                    }
                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                        fInfo.inString = "Options";
                    }
                    else {
                        fInfo.inString = "オプション";
                        fInfo.scale = 0.23f;
                    }

                    fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 0.0f, buttonInfo.position.y - 3.0f);
                    fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate)
                      ;
                }

                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
				
	            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));				
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_StartSmallButton3);
            }
            else {
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Options);
            }

            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
              kZobjectShow_Immediate);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) 
              ZobjectHideStyle.kZobjectHide_DontHide);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetWidth(80);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetHeight(70);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
            hInfo.offset = Utilities.CGPointMake(0.1f, -5.0f);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                HangingButton hb = ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).hangingButton;
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetOrientationButton(hb);
            }

            buttonInfo.position = Utilities.CGPointMake(kOutButtonLeft, kRow1 + 20.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_GreenAnt;
            buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
              kAtlas_FrontendAndShowlevel));
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                const float kErstWordScale = 0.36f;
                string inString = "";
                inString = "Mitwirk\n";
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
                      int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 1.0f, buttonInfo.position.y + 1.0f), kErstWordScale, inString,
                      true);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyle( 
                      FunnyWordShowStyle.kFunnyWordShow_Immediate);
                }
                else {
                    FrontEndScreen.AddFunnyWordInfo fInfo;
                    fInfo.scale = 0.3f;
                    if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                        fInfo.inString = "制作人员";
                    }
                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                        fInfo.inString = "Crédits";
                    }
                    else {
                        fInfo.inString = "クレジット";
                        fInfo.scale = 0.26f;
                    }

                    fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 1.0f, buttonInfo.position.y - 1.0f);
                    fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyleNew((int) (int) ZobjectShowStyle.
                      kZobjectShow_Immediate);
                }

                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_StartSmallButton2);
            }
            else {
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Credits);
            }

            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_HideNewsTab);
            hInfo.offset = Utilities.CGPointMake(0.1f, -5.0f);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                HangingButton hb = ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).hangingButton;
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetOrientationButton(hb);
            }

            bestTimesButtonId = buttonId;
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
              kZobjectShow_Immediate);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) 
              ZobjectHideStyle.kZobjectHide_DontHide);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetWidth(80);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetHeight(70);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
						buttonInfo.position = Utilities.CGPointMake(kOutButtonLeft, kRow2 + 19.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild;

//			/*  Create Level
//			buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
//            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
//              kAtlas_FrontendAndShowlevel));
//            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_HideNewsTab);
//            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
//                const float kErstWordScale = 0.32f;
//                string inString = "";
//                inString = "Erstellen\n";
//                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
//                    fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
//                      int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 2.0f, buttonInfo.position.y), kErstWordScale, inString, true);
//                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyle( 
//                      FunnyWordShowStyle.kFunnyWordShow_Immediate);
//                }
//                else {
//                    FrontEndScreen.AddFunnyWordInfo fInfo;
//                    fInfo.scale = kErstWordScale;
//                    fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Create);
//                    if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_French))
//					{
//                    }
//                    else {
//                        fInfo.scale = 0.26f;
//                    }
//
//                    fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 1.0f, buttonInfo.position.y - 3.0f);
//                    fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
//                    ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyleNew((int) (int) ZobjectShowStyle.
//                      kZobjectShow_Immediate);
//                }
//
//                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
//                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_StartSmallButton1);
//            }
//            else {
//                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Create);
//            }
//
//            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
//              kZobjectShow_Immediate);
//            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) 
//              ZobjectHideStyle.kZobjectHide_DontHide);
//            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetWidth(80);
//            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetHeight(70);
//            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
//            hInfo.offset = Utilities.CGPointMake(0.1f, -5.0f);
//            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
//            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
//                HangingButton hb = ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).hangingButton;
//                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetOrientationButton(hb);
//            }


						//Show Leaderboards button
						//actionid
//						buttonInfo.position = Utilities.CGPointMake(kOutButtonLeft, kRow2 + 19.0f);
//						buttonInfo.texture = null;
//						buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
////						buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild;
//						buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
//						(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
//								kAtlas_FrontendAndShowlevel));
//						((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_HideNewsTab);
////						if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
////								const float kErstWordScale = 0.32f;
////								string inString = "";
////								inString = "Erstellen\n";
////								if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
////										fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
////												int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 2.0f, buttonInfo.position.y), kErstWordScale, inString, true);
////										((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyle( 
////												FunnyWordShowStyle.kFunnyWordShow_Immediate);
////								}
////								else {
////										FrontEndScreen.AddFunnyWordInfo fInfo;
////										fInfo.scale = kErstWordScale;
////										fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Create);
////										if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_French))
////										{
////										}
////										else {
////												fInfo.scale = 0.26f;
////										}
////
////										fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 1.0f, buttonInfo.position.y - 3.0f);
////										fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
////										((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetShowStyleNew((int) (int) ZobjectShowStyle.
////												kZobjectShow_Immediate);
////								}
////
////								((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
////								(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_StartSmallButton1);
////						}
////						else {
//								(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Create);
////						}
//
//						(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
//								kZobjectShow_Immediate);
//						(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) 
//								ZobjectHideStyle.kZobjectHide_DontHide);
//						((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetWidth(80);
//						((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetHeight(70);
//						(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
//						hInfo.offset = Utilities.CGPointMake(0.1f, -5.0f);
//						((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
//						if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
//								HangingButton hb = ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).hangingButton;
//								((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetFunnyWord(fwId)).SetOrientationButton(hb);
//						}



           // 
//*/
		//	}
			
//            buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
  //          (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.
    //          kAtlas_FrontendAndShowlevel));
      //      (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Crystal);
     //       ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.
       //       kFrontEndAction_ViewScoresLeaderboard);
     //       ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
       //     ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetSoundEffectId((int)Audio.Enum1.kSoundEffect_BubblesLowLoop);
       //     ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
        //    hInfo.offset = Utilities.CGPointMake(0.1f, -5.0f);
    //        ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
      //      bestTimesButtonId = buttonId;
   //         (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
     //         kZobjectShow_Immediate);
    //        (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) 
    //          ZobjectHideStyle.kZobjectHide_DontHide);
    //        ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetWidth(80);
    //        ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetHeight(70);
    //        (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseControls;
            buttonInfo.position.x = 165;
            buttonInfo.position.y = kMainScreenRaceYPos;
            buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
            mainRaceButtonId = buttonId;
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Race);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
              kZobjectShow_Immediate);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowScale(1.0f);
						((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_PressRaceButton);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetWidth(140);
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetHeight(120);
            (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);

						if (Globals.deviceIPhone5)
						{
								(((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowScale(0.887f);
						}

						hInfo.type = HangingButtonType.kHB_Chain;
            hInfo.subTextureId = (int)World.Enum9.kFE_Chain;
            hInfo.offset = Utilities.CGPointMake(53.0f, -45.0f);
            hInfo.showWobbleMultiplier = 0.5f;
            ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).AddHangingButton(hInfo);
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                int stId = -1;
                switch (Globals.g_currentLanguage) {
                case World.Enum11.kLanguage_German :
                    buttonInfo.position.y += 4.0f;
                    stId = (int)World.Enum9.kFE_Rennen;
                    break;
                case World.Enum11.kLanguage_China :
                    buttonInfo.position.y += 4.0f;
                    buttonInfo.position.x -= 2.0f;
                    stId = (int)World.Enum9.kFE_RaceChin;
                    break;
                case World.Enum11.kLanguage_Japanese :
                    buttonInfo.position.y += 4.0f;
                    buttonInfo.position.x -= 3.0f;
                    stId = (int)World.Enum9.kFE_RaceJap;
                    break;
                case World.Enum11.kLanguage_French :
                    buttonInfo.position.y += 4.0f;
                    buttonInfo.position.x -= 3.0f;
                    stId = (int)World.Enum9.kFE_RaceFrench;
                    break;
                default :
                    Globals.Assert(false);
                    break;
                }

                buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetSubTextureId(stId);
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
                  kZobjectShow_Immediate);
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.
                  kZobjectHide_DontHide);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetIsClickable(false);
            }

            #if DROPBOX_ENABLED
                buttonInfo.position = Utilities.CGPointMake(280, 28);
                buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_FarmBottom];
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_DropBox);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas(kAtlas_MainMenuButts), 
                  12);
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
                  kZobjectShow_SlideInTop);
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.
                  kZobjectHide_SlideToTop);
            #endif

            #if EMAIL_BUTTON
                buttonInfo.position = Utilities.CGPointMake(280, 28);
                buttonInfo.texture = null;
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                buttonId = (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).AddButton(buttonInfo);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_EmailLog);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                ((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.
                  kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Level0apples);
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.
                  kZobjectShow_SlideInTop);
                (((screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.
                  kZobjectHide_SlideToTop);
            #endif

        }

        public void SetupBehindGameCenter()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_BehindGameCenterStart;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position = Utilities.CGPointMake(160, 450);
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_FarmBottom];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale((320.0f / 256.0f));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
        }

        public void SetupMultiplayerConnect()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_MultiplayerConnect;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position = Utilities.CGPointMake(160, 450);
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_FarmBottom];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale((320.0f / 256.0f));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
        }

        public void SetupFeatureNotAvailable()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_FeatureNotAvailable;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position = Utilities.CGPointMake(160, 450);
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_FarmBottom];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale((320.0f / 256.0f));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position.x = 50.0f;
            buttonInfo.position.y = 440;
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_Back];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack;
        }

        public void SetupTitleScreen()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_Title;
            if (Globals.useRetina) {
                ButtonInfo buttonInfo = new ButtonInfo();
                buttonInfo.position = Utilities.CGPointMake(169.0f, 145.0f);
								if (Globals.useIPadBackScreens) {
                    buttonInfo.position.y -= 5.0f;
                }

                buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureSplashTitlePlaque);
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            }

            if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) ||
				(Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese))
			{
                ButtonInfo buttonInfo = new ButtonInfo();
								if (Globals.useIPadBackScreens) 
								{
                    buttonInfo.position = Utilities.CGPointMake(160.0f, 263.0f);
                }
                else if (Globals.deviceIPhone4) {
                    buttonInfo.position = Utilities.CGPointMake(160.0f, 258.0f);
                }
                else {
                    buttonInfo.position = Utilities.CGPointMake(160.0f, 263.0f);
                }

                buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureSplashTitleSTSChinJap);
                
				if (true)//buttonInfo.texture.myBillboard.GetMaterial().mainTexture != null)
				{
					buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
	                int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
	                ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
	                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
	                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
					
					float stsWidth = 50.0f;
					float stsHeight = 87.0f;
					
					if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
					{
						stsWidth *= 2.0f;
						stsHeight *= 2.0f;
					}
					
	                ((screen[(int)thisScreen]).GetButton(buttonId)).zobject.myAtlasBillboard.width = stsWidth;
	                ((screen[(int)thisScreen]).GetButton(buttonId)).zobject.myAtlasBillboard.height = stsHeight;
				}
			}

        }

        public void SetupLBPlayOrBuild()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            float yPlus = 90.0f;
            float yStart = 65.0f;
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
  //          ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),0);

			((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
//            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip),9);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], buttonId);
            buttonInfo.position = Utilities.CGPointMake(160.0f, 245.0f);
            yStart += yPlus;
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
            int fwId = -1;
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                const float kErstWordScale = 0.32f;
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    FrontEndScreen.AddFunnyWordInfo fInfo;
                    fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 2.0f, buttonInfo.position.y - 3.0f);
                    fInfo.scale = kErstWordScale;
                    fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Create);
                    fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
                    ((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(80.0f);
                }
                else {
                    string inString = "";
                    inString = Globals.g_world.GetString((StringId) StringId.kString_Create);
                    fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
                      int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 2.0f, buttonInfo.position.y), kErstWordScale, inString, true);
                }

                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_StartSmallButton1);
            }
            else {
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Create);
            }

            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            ////(((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetFloatyInfoo(floatyInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(80);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(70);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            hInfo.showWobbleMultiplier = 2.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(0.1f, 1.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            if (Globals.g_currentLanguage != World.Enum11.kLanguage_English) {
                HangingButton hb = ((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton;
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(hb);
            }

            buttonInfo.position = Utilities.CGPointMake(160.0f, 150.0f);
            buttonInfo.texture = null;
            buttonInfo.textureLabel = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId((int)World.Enum9.kFE_Practise);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
           // //(((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetFloatyInfoo(floatyInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(80);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(70);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_Swish);
            hInfo.subTextureId = 200;
            hInfo.showWobbleMultiplier = 1.0f;
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            Constants.RossColour darkStart = new Constants.RossColour(0,0,0);
            darkStart.cRed = 0.4f * 0.6f;
            darkStart.cGreen = 0.15f * 0.6f;
            darkStart.cBlue = 0.01f * 0.6f;
            float wordScale = 0.45f;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = Utilities.CGPointMake(buttonInfo.position.x - 2.0f, buttonInfo.position.y + 0.0f);
                fInfo.scale = 0.6f;
				
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French)
				{
					fInfo.scale = 0.42f;//5f;
				}				
				
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_Practise);
                fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
            }
            else {
                string inString = "";
                inString = Globals.g_world.GetString((StringId) StringId.kString_Practise);
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_English) {
                    wordScale = 0.6f;
                }

                fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours), Utilities.CGPointMake(buttonInfo.position.x - 2.0f, buttonInfo.position.y), wordScale, inString, true);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kColourRed);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            buttonInfo.position.x = 180;
            buttonInfo.position.y = yStart;
            yStart += yPlus;

            #if !REMOVE_NETWORKING
            #endif

        }

        public void RoomTerminatedReason(object room, string reason)
        {
            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_BrowseServers) {
                return;
            }

            this._showAlert("Connection failed");
        }

        public void ReceiveMessage_NoTrack()
        {
            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_BrowseServers) {
                return;
            }

        }

        public void ReceiveMessage_DenyTrack()
        {
            if ((int)currentScreen != (int) FrontEndScreenEnum.kFrontEndScreen_BrowseServers) {
                return;
            }

        }

        public void RemoteRoomStreamsAreBothOpenToServer()
        {
            if ((int)currentScreen == (int) FrontEndScreenEnum.kFrontEndScreen_BrowseServers) {
                connectedToServerOk = true;
                ((screen[(int)currentScreen]).GetFunnyWord(5)).ChangeText("awaiting confirmation\n");
                ((screen[(int)currentScreen]).GetFunnyWord(5)).Show();
                ((screen[(int)currentScreen]).GetFunnyWord(5)).Jiggle(0.5f);
            }

            readGoogleTimer = 0.0f;
        }

        public void SetupWaitForClient()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_WaitForClient;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position = Utilities.CGPointMake(160, 450);
            buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_FarmBottom];
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale((320.0f / 256.0f));
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
        }

        public void SetupReceivedTrack()
        {
        }

        public void SetupSendComplete()
        {
		}

        public void SetupBrowseServers()
        {
        }

        public void SetupLBHowTo()
        {
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_LBHowTo;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            buttonInfo.position = Utilities.GetScreenCentre();
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild;
            int buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(320);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(480);
        }

        public void UpdateChooseTrackButtonsP1(FrontEndScreenEnum inScreen, bool fromSceneSelect)
        {
        }

        public void SetupChooseStageScreen()
        {
//			int ross = Screen.width;
//			int ross2 = Screen.height;
			
//			flaot vScale = 
//			float xRatioWidth = 320.0f *  vScale;
			
			//screen.width and height has already been rescaled so is at scale of newHeight / 480.0f

			
            ButtonInfo bInfo = new ButtonInfo();
            bInfo.textureLabel = null;
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ChooseStage;
            for (int i = 0; i <  (int)Enum2.kNumStages; i++) 
			{
                float xOffset = (((float) i) * 320.0f);
                float kWordScale = 0.7f;
                float xPos = 160.0f + xOffset;
                bInfo.position = Utilities.CGPointMake(160 + xOffset, kChooseStageHangingTotalPos);
                bInfo.texture = null;
                bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                int buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
                int totalSignId = buttonId;
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Total);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
                HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
                hInfo.showWobbleMultiplier = 1.15f;
                hInfo.type = HangingButtonType.kHB_Chain;
                hInfo.subTextureId = (int)World.Enum9.kFE_Chain;
                hInfo.offset = Utilities.CGPointMake(42.0f, -17.0f);
                ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
                string inStringL;
                inStringL = Globals.g_world.GetString((StringId) StringId.kString_Total);
                int fwId = -1;
                float yExtraPos = 0.0f;
                float wordscale = 0.48f;
                if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese)) {
                    yExtraPos = -3.0f;
                    wordscale = 0.4f;
                }

                fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], (int) StringId.kString_Total, Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.
                  kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(bInfo.position.x + 3.0f, kTotalWordYPos + yExtraPos),
                  wordscale, inStringL, true);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).startPosition = Utilities.CGPointMake(bInfo.position.x + 3.0f, kTotalWordYPos + yExtraPos);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kColourRedText);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
                hInfo.showWobbleMultiplier = 1.0f;
                bInfo.position = Utilities.CGPointMake(xPos + xOffset, kChooseStageMainIconYPos);
                bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ChooseTrack;
                bInfo.texture = null;
                buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
                if (i < (int)Profile.Enum4.kNumCups) {
                    ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (profile.
                      GetCup(i)).stageIcon);
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
                    ((screen[(int)thisScreen]).GetButton(buttonId)).AddLabelP1(null, Utilities.CGPointMake(0.0f, 0.0f));
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel).SetSubTextureId(Globals.g_world.GetSubTextLanguageP1((int) AtlasType.
                      kAtlas_FrontendAndShowlevel, (int)World.Enum9.kFE_StageButtonWordPlay));
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                }
                else {
//                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_TerrainIcons));
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetSubTextureId(3);
                    ((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(100.0f);
                    ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(100.0f);
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
                }

//								screen[(int)thisScreen].GetFunnyWord(fwId)

                hInfo.type = HangingButtonType.kHB_Chain;
                hInfo.subTextureId = (int)World.Enum9.kFE_Chain;
                hInfo.offset = Utilities.CGPointMake(70.0f, -55.0f);
                ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
                HangingButton hb = ((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton;
                if (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel != null)
				{
					(((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel).SetOrientationButton(hb);
				}
                bInfo.position = Utilities.CGPointMake(160 + xOffset, 74);
                bInfo.texture = null;
                bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
                int stageNameButtonId = buttonId;
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
                  (int)World.Enum9.kFE_LongNameButton);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
                hInfo.type = HangingButtonType.kHB_Rope;
                hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
                ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
                string inString = "";
                Constants.RossColour fontColour;
                if (i < (int)Enum2.kStageBonusLevels) 
				{
                    fontColour = (profile.GetCup(i)).fontColour;
					string nsstring;// = new char[32];
                    nsstring = ((profile.GetCup(i)).name);
                  //  strcat(nsstring, "\n");
                    inString = nsstring;
                }
                else {
                    fontColour = Constants.kColourYellow;
                    inString = "bonus levels\n";
                }
				
                if ((Globals.g_currentLanguage == World.Enum11.kLanguage_China) || (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese)) {
                    yExtraPos = -10.0f;
                }
				
				//UnityEngine.Debug.Log("GROAN " + fontColour.ToString() + " dfd " + i);
				
                fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, kChooseStageCupNameYPos+yExtraPos), kWordScale, inString, true);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(fontColour);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
                FunnyWord fwStageName = (screen[(int)thisScreen]).GetFunnyWord(fwId);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(230);
                fwStageName.SetOrientationButton(((screen[(int)thisScreen]).GetButton(stageNameButtonId)).hangingButton);
                if (i < (int)Profile.Enum4.kNumCups) {
//                    ((screen[(int)thisScreen]).GetButton(buttonId)).AddLabelP1(null, Utilities.CGPointMake(0.0f, 73.0f));

					if (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel != null)
					{					
//	                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
	     //               (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel).SetSubTextureId(-1);
	       //             (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
	         //           (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
					}

					((screen[(int)thisScreen]).GetButton(buttonId)).SetWidth(100.0f);
                    ((screen[(int)thisScreen]).GetButton(buttonId)).SetHeight(100.0f);
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetWaitToShow(0.25f);
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                    (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
                    Zscore.ZscoreInfo sInfo = new Zscore.ZscoreInfo();
                    sInfo.numDigits = 2;
                    sInfo.position = Utilities.CGPointMake(135.0f + xOffset, kChooseStageApplesYPos);
                    int numberId = (screen[(int)thisScreen]).AddNumber(sInfo);
                    ((screen[(int)thisScreen]).GetNumber(numberId)).SetScale(0.7f);
                    ((screen[(int)thisScreen]).GetNumber(numberId)).SetScore(24);
                    ((screen[(int)thisScreen]).GetNumber(numberId)).SetColour(Constants.kColourLightblue);
                    ((screen[(int)thisScreen]).GetNumber(numberId)).SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
			//							((screen[(int)thisScreen]).GetNumber(numberId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(totalSignId)).hangingButton);
										((screen[(int)thisScreen]).GetNumber(numberId)).SetOrientationParent(((screen[(int)thisScreen]).GetButton(totalSignId)).hangingButton);
                }

            }

          //  float sideArrowAdd = 0.0f;
						if (Globals.useIPadBackScreens) 
			{
//                sideArrowAdd = 20.0f;
            }
			
			//float scaleUp = Screen.height / 480.0f;
			//float pixels37fromEdge = 37.0f * scaleUp;
			
			float sideDistFromEdge = 29.0f + Globals.g_world.xScreenEdge;//37.0f + (320.0f - (Screen.width * 0.5f));//(37.0f / 320.0f) * Screen.width;
			
//            bInfo.position = Utilities.CGPointMake(37.0f - sideArrowAdd, kChooseStageMainIconYPos);
            bInfo.position = Utilities.CGPointMake(sideDistFromEdge, kChooseStageMainIconYPos);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            chooseStageSideButtonId = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(chooseStageSideButtonId)).SetActionId( FrontEndActions.kFrontEndAction_StageSelectGoBackOne);
            ((screen[(int)thisScreen]).GetButton(chooseStageSideButtonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
              (int)World.Enum9.kFE_Left);
            ((screen[(int)thisScreen]).GetButton(chooseStageSideButtonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            (((screen[(int)thisScreen]).GetButton(chooseStageSideButtonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            (((screen[(int)thisScreen]).GetButton(chooseStageSideButtonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            (((screen[(int)thisScreen]).GetButton(chooseStageSideButtonId)).zobject).SetWaitToShow(0.3f);
            (((screen[(int)thisScreen]).GetButton(chooseStageSideButtonId)).zobject).SetShowScale(0.6f);
//            bInfo.position = Utilities.CGPointMake(283.0f + sideArrowAdd, kChooseStageMainIconYPos);
            bInfo.position = Utilities.CGPointMake(320.0f - sideDistFromEdge, kChooseStageMainIconYPos);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId2 = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId2)).SetActionId( FrontEndActions.kFrontEndAction_StageSelectGoForwardOne);
            ((screen[(int)thisScreen]).GetButton(buttonId2)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Right);
            ((screen[(int)thisScreen]).GetButton(buttonId2)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetWaitToShow(0.3f);
            (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowScale(0.65f);
            bInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId2 = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId2)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId2)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            bInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            buttonId2 = (screen[(int)thisScreen]).AddButton(bInfo);
            int backButtonId = buttonId2;
            ((screen[(int)thisScreen]).GetButton(buttonId2)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            float xOffset2 = (((float)Enum2.kNumStages) * 320.0f);
            float kWordScale2 = 0.7f;
            float xPos2 = 160.0f + xOffset2;
            string inString2;
            inString2 = "more cups\n";
            int fwId2 = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos2, kChooseStageMoreCupsYPos), kWordScale2, inString2, true);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId2)).SetColour(Constants.kColourLightblue);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId2)).Jiggle(0.5f);
            inString2 = "coming soon!\n";
            fwId2 = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
              AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos2, kChooseStageMoreCupsYPos + 50.0f), kWordScale2, inString2, true);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId2)).SetColour(Constants.kColourLightblue);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId2)).Jiggle(0.5f);
            int totalNumberOfApples = profile.GetTotalNumberOfApples();
            int[] stageThing = new int[4]
            {4, 6, 8, 9};
            for (int i = 0; i < 4; i++) {
                int stageId = stageThing[i];
                float xOffset = ((float)(stageId)) * 320.0f;
                bInfo.position = Utilities.CGPointMake(160.0f + xOffset, kChooseStageSpecialLockYPos);
                bInfo.texture = null;
                bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
				
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) 
				{
					//bInfo.position.y -= 35.0f;	
				}
					
                buttonId2 = (screen[(int)thisScreen]).AddButton(bInfo);
                if (i == 0) {
                    specialLockId = buttonId2;
                    ((screen[(int)thisScreen]).GetButton(buttonId2)).SetActionId( FrontEndActions.kFrontEndAction_SpecialLock1);
                }
                else {
                    ((screen[(int)thisScreen]).GetButton(buttonId2)).SetActionId( FrontEndActions.kFrontEndAction_SpecialLock1 + i);
                }

                float fontSize = 0.34f;
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    fontSize = 0.3f;
                }

                string inString = "";
                inString = Globals.g_world.GetString((StringId) StringId.kString_Unlock);
                int fwId = -1;
                fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8(screen[(int)thisScreen], (int) StringId.kString_Unlock, Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType
                  .kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours), Utilities.CGPointMake(bInfo.position.x, bInfo.position.y), fontSize, inString
                  , true);
                if (i == 0) {
                    specialWordId = fwId;
                }

                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kColourTurquoiseText);
                ((screen[(int)thisScreen]).GetButton(buttonId2)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
                  (int)World.Enum9.kFE_SpecialLock);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
                ((screen[(int)thisScreen]).GetButton(buttonId2)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                Zscore.ZscoreInfo sInfo = new Zscore.ZscoreInfo();
                sInfo.numDigits = 3;
                sInfo.position = Utilities.CGPointMake(200.0f + xOffset, kChooseStageSpecialLockYPos - 20.0f);
                int numberId = (screen[(int)thisScreen]).AddNumber(sInfo);
                if (i == 0) {
                    specialLockWordId = numberId;
                }

                ((screen[(int)thisScreen]).GetNumber(numberId)).SetScale(0.36f);
                ((screen[(int)thisScreen]).GetNumber(numberId)).SetScore(totalNumberOfApples);
                ((screen[(int)thisScreen]).GetNumber(numberId)).SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
                ((screen[(int)thisScreen]).GetNumber(numberId)).SetDontDisplayLeadingZeros(true);
                ((screen[(int)thisScreen]).GetNumber(numberId)).SetColour(Constants.kColourPink);
                sInfo.numDigits = 3;
                sInfo.position = Utilities.CGPointMake(200.0f + xOffset, kChooseStageSpecialLockYPos + 20.0f);
                numberId = (screen[(int)thisScreen]).AddNumber(sInfo);
                ((screen[(int)thisScreen]).GetNumber(numberId)).SetScale(0.36f);
                if (i == 0) ((screen[(int)thisScreen]).GetNumber(numberId)).SetScore(Constants.NUM_APPLES_TO_UNLOCK_5);
                else if (i == 1) ((screen[(int)thisScreen]).GetNumber(numberId)).SetScore(Constants.NUM_APPLES_TO_UNLOCK_7);
                else if (i == 2) ((screen[(int)thisScreen]).GetNumber(numberId)).SetScore(Constants.NUM_APPLES_TO_UNLOCK_9);
                else {
                    ((screen[(int)thisScreen]).GetNumber(numberId)).SetScore(Constants.NUM_APPLES_TO_UNLOCK_10);
                }

                ((screen[(int)thisScreen]).GetNumber(numberId)).SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
                ((screen[(int)thisScreen]).GetNumber(numberId)).SetColour(Constants.kColourLightblue);
            }

            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], backButtonId);
        }

        public void SetupChooseTerrainScreen()
        {
            ButtonInfo bInfo = new ButtonInfo();
            bInfo.textureLabel = null;
            FrontEndScreenEnum thisScreen =  FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.position = Utilities.CGPointMake(160.0f, 75.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            int buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
              (int)World.Enum9.kFE_LongNameButton);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
            hInfo.showWobbleMultiplier = 1.0f;
            hInfo.type = HangingButtonType.kHB_Rope;
            hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
            hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
            ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            float kWordScale = 0.7f;
            float xPos = 160.0f;
            string inString = "";
            int fwId = -1;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                FrontEndScreen.AddFunnyWordInfo fInfo;
                fInfo.position = Utilities.CGPointMake(xPos, 80.0f);
                fInfo.scale = 0.6f;
                fInfo.inString = Globals.g_world.GetNSString ( StringId.kString_ChooseTerrain);
                fwId = (screen[(int)thisScreen]).AddFunnyWord(fInfo);
            }
            else {
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) inString = "Gel#nde w#hlen\n";
                else {
                    inString = "Choose Terrain\n";
                }

                fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, 80.0f), kWordScale, inString, true);
            }

            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(Constants.kColourRed);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).FitToWidth(240.0f);
            ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId)).hangingButton);
            for (int i = 0; i < 2; i++) {
                float xOffset = (((float) i) * 320.0f);
                kWordScale = 0.55f;
                xPos = 160.0f + xOffset;
                Constants.RossColour fontColour;
                if (i == 0) {
                    fontColour = Constants.kColourGreenMenuBack;
                    inString = "\n";
                }
                else if (i == 1) {
                    fontColour = Constants.kColourFarmText;
                    inString = "\n";
                }
                else if (i == 2) {
                    fontColour = Constants.kColourPink;
                    inString = "desert\n";
                }
                else if (i == 3) {
                    fontColour = Constants.kColourPink;
                    inString = "ice\n";
                }
                else if (i == 4) {
                    fontColour = Constants.kColourPink;
                    inString = "moon\n";
                }
                else {
                    Globals.Assert(false);
                    fontColour = Constants.kColourPink;
                }

                buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTerrainTerrainPos);
                buttonInfo.texture = null;
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                int buttonId2 = (screen[(int)thisScreen]).AddButton(buttonInfo);
                ((screen[(int)thisScreen]).GetButton(buttonId2)).SetIsClickable(false);
                HangingButton.HangingButtonInfo hInfo2;
                hInfo2.showWobbleMultiplier = 2.0f;
                hInfo2.type = HangingButtonType.kHB_Rope;
                hInfo2.subTextureId = (int)World.Enum9.kFE_Rope;
                hInfo2.offset = Utilities.CGPointMake(0.1f, 1.0f);
                fwId = (screen[(int)thisScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours), Utilities.CGPointMake(xPos, kChooseTerrainTerrainPos), kWordScale, inString, true);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetColour(fontColour);
                ((screen[(int)thisScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId2)).hangingButton);
                bInfo.position = Utilities.CGPointMake(xPos + xOffset, kChooseStageMainIconYPos);
                bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ExitMenuSystem;
                bInfo.texture = null;
                buttonId2 = (screen[(int)thisScreen]).AddButton(bInfo);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
                if (i < 2) {
                    (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowScale(0.78f);
                }

                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetSubTextureId(i);
                ((screen[(int)thisScreen]).GetButton(buttonId2)).AddLabelP1(null, Utilities.CGPointMake(0.0f, 73.0f));
				if (((screen[(int)thisScreen]).GetButton(buttonId)).zobjectLabel != null)
				{					

					(((screen[(int)thisScreen]).GetButton(buttonId2)).zobjectLabel).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel));
	                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobjectLabel).SetSubTextureId(-1);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobjectLabel).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobjectLabel).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
				}
				
					((screen[(int)thisScreen]).GetButton(buttonId2)).SetWidth(100.0f);
                ((screen[(int)thisScreen]).GetButton(buttonId2)).SetHeight(100.0f);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetWaitToShow(0.25f);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            }

            float sideArrowAdd = 0.0f;
						if (Globals.useIPadBackScreens) {
                sideArrowAdd = 20.0f;
            }

            bInfo.position = Utilities.CGPointMake(37.0f - sideArrowAdd, kChooseStageMainIconYPos);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            chooseTerrainSideButtonId = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(chooseTerrainSideButtonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
              (int)World.Enum9.kFE_Left);
            ((screen[(int)thisScreen]).GetButton(chooseTerrainSideButtonId)).SetActionId( FrontEndActions.kFrontEndAction_TerrainSelectGoBackOne);
            ((screen[(int)thisScreen]).GetButton(chooseTerrainSideButtonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            (((screen[(int)thisScreen]).GetButton(chooseTerrainSideButtonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
            (((screen[(int)thisScreen]).GetButton(chooseTerrainSideButtonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            (((screen[(int)thisScreen]).GetButton(chooseTerrainSideButtonId)).zobject).SetWaitToShow(0.3f);
            (((screen[(int)thisScreen]).GetButton(chooseTerrainSideButtonId)).zobject).SetShowScale(0.6f);
            bInfo.position = Utilities.CGPointMake(283.0f + sideArrowAdd, kChooseStageMainIconYPos);
            bInfo.texture = null;
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(bInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Right);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_TerrainSelectGoForwardOne);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetWaitToShow(0.3f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.6f);
            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            int backButtonId = buttonId;
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(245, kChooseStageSlideHeadsPos - 15);
            buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_SheepyHead);
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            buttonId = (screen[(int)thisScreen]).AddButtonP1(buttonInfo, 0.35f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowScale(0.8f);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHorizontallyFlipped(true);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], backButtonId);
        }

        public void SetupChooseTrackScreen(FrontEndScreenEnum inScreen)
        {
            FrontEndScreenEnum thisScreen = inScreen;
            int buttonId;
            int trackNameThingId;
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            (screen[(int)inScreen]).SetShowSpeed(0.08f);
            float yOffsetForLowerThings = 0.0f;
            if (((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_NetSendChooseTrack)) {
                yOffsetForLowerThings = kShiftWithMessage;
            }

            int numStages = 3;
            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                numStages =  (int)Enum2.kNumStages;
            }

            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                buttonInfo.position = Utilities.CGPointMake(160.0f, 74.0f);
                buttonInfo.texture = null;
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
                trackNameThingId = buttonId;
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
                ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
                  (int)World.Enum9.kFE_LongNameButton);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
                HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
                hInfo.showWobbleMultiplier = 1.0f;
                hInfo.type = HangingButtonType.kHB_Rope;
                hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
                hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
                ((screen[(int)thisScreen]).GetButton(buttonId)).AddHangingButton(hInfo);
            }

            for (int stage = 0; stage < numStages; stage++) {
                float xOffset = (((float) stage) * 320.0f);
                if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                    float kWordScale = 0.7f;
                    float xPos = 160.0f + xOffset;
                    string inString = "";
                    Constants.RossColour fontColour;
                    if (stage < (int)Enum2.kStageBonusLevels) {
                        fontColour = (profile.GetCup(stage)).fontColour;
						string nsstring;// = new char[32];
                        nsstring = ((profile.GetCup(stage)).name);
//                        strcat(nsstring, "\n");
                        inString = nsstring;
                    }
                    else {
                        fontColour = Constants.kColourYellow;
                        inString = "bonus levels\n";
                    }

                    int fwId = (screen[(int)inScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, null, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours),
                      Utilities.CGPointMake(xPos, kChooseTrackCupNameYPos), kWordScale, inString, true);
                    ((screen[(int)inScreen]).GetFunnyWord(fwId)).SetColour(fontColour);
                    ((screen[(int)inScreen]).GetFunnyWord(fwId)).SetShowStyle( FunnyWordShowStyle.kFunnyWordShow_Immediate);
                    ((screen[(int)inScreen]).GetFunnyWord(fwId)).SetTimeToShowSpeed(0.0f);
                    ((screen[(int)inScreen]).GetFunnyWord(fwId)).FitToWidth(230);
                    buttonInfo.position = Utilities.CGPointMake(160 + xOffset, 74);
                    buttonInfo.texture = null;
                    buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                    int buttonId2 = (screen[(int)thisScreen]).AddButton(buttonInfo);
                    ((screen[(int)thisScreen]).GetButton(buttonId2)).SetIsClickable(false);
                    ((screen[(int)thisScreen]).GetButton(buttonId2)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
                      (int)World.Enum9.kFE_LongNameButton);
                    (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                    (((screen[(int)thisScreen]).GetButton(buttonId2)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
                    HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
                    hInfo.showWobbleMultiplier = 1.0f;
                    hInfo.type = HangingButtonType.kHB_Rope;
                    hInfo.subTextureId = (int)World.Enum9.kFE_Rope;
                    hInfo.offset = Utilities.CGPointMake(98.0f, -15.0f);
                    ((screen[(int)thisScreen]).GetButton(buttonId2)).AddHangingButton(hInfo);
                    ((screen[(int)inScreen]).GetFunnyWord(fwId)).SetOrientationButton(((screen[(int)thisScreen]).GetButton(buttonId2)).hangingButton);
                }

                float xStageOffset = ((float) stage) * 320.0f;
                float xSpaceBetween = 6;
                float xEdge = (320 - (64 * 3) - (2 * xSpaceBetween)) / 2;
                float ySpaceBetween = 6;
                float yEdge = kChooseTrackYEdge;
                if (((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.
                  kFrontEndScreen_NetSendChooseTrack)) {
                    yEdge += kShiftWithMessage;
                }

                if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
                    yEdge += (64.0f + ySpaceBetween);
                }

                if ((int)inScreen != (int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                    yEdge -= 64.0f;
                }

                int level = 0;
                if (((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.
                  kFrontEndScreen_BonusChooseTrack)) {
                    buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ExitMenuSystem;
                }
                else {
                    buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                }

                bool firstButt = true;
                int buttonIndex = 0;
                for (int y = 0; y < 3; y++) {
                    int numX = 3;
                    if (y == 2) {
                        numX = 2;
                    }

                    for (int x = 0; x < numX; x++) {
                        if (stage == (int)Enum2.kStageBonusLevels) {
                            if (level >= (int)Profile.Enum6.kNumBonusLevels) {
                                continue;
                            }

                        }

                        int subTextureId = -1;
                        buttonInfo.position.x = xStageOffset + 32 + xEdge + ((64 + xSpaceBetween) * ((float) x));
                        buttonInfo.position.y = 32 + yEdge + ((64 + ySpaceBetween) * ((float) y));
                        if (profile.IsLevelUnlocked(level)) {
                            buttonInfo.texture = null;
                            subTextureId = level;
                            subTextureId = (7 * selectedStage) + 1 + (int)profile.GetTrophyGot(level);
                        }
                        else buttonInfo.texture = null;

                        subTextureId = 11 + (2 * selectedStage);
                        if (((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.
                          kFrontEndScreen_NetReceiveChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack)) {
                            buttonInfo.texture = null;
                            subTextureId = 0;
                        }

                        if (stage == (int)Enum2.kStageBonusLevels) {
                            buttonInfo.texture = null;
                            subTextureId = 4 + level;
                        }

                        float waitToShow = 0.08f * x + (0.02f * y);
                        int whichButton = (screen[(int)inScreen]).AddButtonP1(buttonInfo, waitToShow);
                        buttonIndex++;
                        if (((int)inScreen != (int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) && (stage != (int)Enum2.kStageBonusLevels) && ((int)inScreen != (int)
                          FrontEndScreenEnum.kFrontEndScreen_SendChooseTrack)) {
                            int levelId = buttonIndex + (stage * 8);
                            Zscore.ZscoreInfo sInfo = new Zscore.ZscoreInfo();
                            if (levelId < 10) sInfo.numDigits = 1;
                            else {
                                sInfo.numDigits = 2;
                            }

                            sInfo.position = buttonInfo.position;
                            sInfo.position.y -= 7.0f;
                            int numberId = (screen[(int)inScreen]).AddNumber(sInfo);
                            ((screen[(int)inScreen]).GetNumber(numberId)).SetScale(0.6f);
                            ((screen[(int)inScreen]).GetNumber(numberId)).SetScore(levelId);
                            ((screen[(int)inScreen]).GetNumber(numberId)).SetThrobSize(0.12f);
                            ((screen[(int)inScreen]).GetNumber(numberId)).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
                            ((screen[(int)inScreen]).GetNumber(numberId)).SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
                            ((screen[(int)inScreen]).GetNumber(numberId)).SetPositionButton((screen[(int)inScreen]).GetButton(whichButton));
                        }

                        (((screen[(int)inScreen]).GetButton(whichButton)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                        (((screen[(int)inScreen]).GetButton(whichButton)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
               			if (((screen[(int)thisScreen]).GetButton(whichButton)).zobjectLabel != null)
						{					

						(((screen[(int)inScreen]).GetButton(whichButton)).zobjectLabel).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
						}
						
							(((screen[(int)inScreen]).GetButton(whichButton)).zobject).SetShowScale(kLevelButtonScale);
                        ((screen[(int)inScreen]).GetButton(whichButton)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
                          (int)World.Enum9.kFE_LevelLocked);
                        ((screen[(int)inScreen]).GetButton(whichButton)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                        if (x == 0 && y == 0) {
                            chooseTrackButtonId = whichButton;
                        }

                        if (firstButt) {
                            (((screen[(int)inScreen]).GetButton(whichButton)).zobject).SetSoundEffectIdAppear((int)Audio.Enum1.kSoundEffect_BubblesHigh);
                            firstButt = false;
                        }

                        level++;
                    }

                }

            }

            if (true) 
						{
                float sideArrowAdd = 0.0f;
                
								if (Globals.useIPadBackScreens) 
				{
                    sideArrowAdd = 16.0f;
                }
								else if (Globals.deviceIPhone5) 
								{
										sideArrowAdd = -5.0f;
								}


                buttonInfo.position = Utilities.CGPointMake(33.0f - sideArrowAdd, kChooseTrackArrowsYPos + yOffsetForLowerThings);
                buttonInfo.texture = null;
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                chooseStageSideButtonIdCT[(int)inScreen] = (screen[(int)inScreen]).AddButton(buttonInfo);
                ((screen[(int)inScreen]).GetButton(chooseStageSideButtonIdCT[(int)inScreen])).SetActionId( FrontEndActions.kFrontEndAction_StageSelectGoBackOne);
                ((screen[(int)inScreen]).GetButton(chooseStageSideButtonIdCT[(int)inScreen])).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                ((screen[(int)inScreen]).GetButton(chooseStageSideButtonIdCT[(int)inScreen])).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.
                  kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Left);
                (((screen[(int)inScreen]).GetButton(chooseStageSideButtonIdCT[(int)inScreen])).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
                (((screen[(int)inScreen]).GetButton(chooseStageSideButtonIdCT[(int)inScreen])).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
                (((screen[(int)inScreen]).GetButton(chooseStageSideButtonIdCT[(int)inScreen])).zobject).SetWaitToShow(0.3f);
                (((screen[(int)inScreen]).GetButton(chooseStageSideButtonIdCT[(int)inScreen])).zobject).SetShowScale(0.6f);
                buttonInfo.position = Utilities.CGPointMake(287.0f + sideArrowAdd, kChooseTrackArrowsYPos + yOffsetForLowerThings);
                buttonInfo.texture = null;
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                int buttonId2 = (screen[(int)inScreen]).AddButton(buttonInfo);
                ((screen[(int)inScreen]).GetButton(buttonId2)).SetActionId( FrontEndActions.kFrontEndAction_StageSelectGoForwardOne);
                ((screen[(int)inScreen]).GetButton(buttonId2)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                ((screen[(int)inScreen]).GetButton(buttonId2)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), (int)World.Enum9.kFE_Right);
                (((screen[(int)inScreen]).GetButton(buttonId2)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
                (((screen[(int)inScreen]).GetButton(buttonId2)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
                (((screen[(int)inScreen]).GetButton(buttonId2)).zobject).SetWaitToShow(0.3f);
                (((screen[(int)inScreen]).GetButton(buttonId2)).zobject).SetShowScale(0.6f);
            }

            buttonInfo.position = Utilities.CGPointMake(160.0f, kChooseTrackBackBarTopPosY);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.
              GetIPadSubTexture((int)World.Enum6.kSSH_BackBar));
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetIsClickable(false);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            buttonInfo.position = Utilities.CGPointMake(xBackButton, kChooseTrackBackBarTopPosY - 1.0f);
            buttonInfo.texture = null;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            buttonId = (screen[(int)thisScreen]).AddButton(buttonInfo);
            int backButtonId = buttonId;
            ((screen[(int)thisScreen]).GetButton(buttonId)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetBackST());
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            (((screen[(int)thisScreen]).GetButton(buttonId)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_DontHide);
            if ((int)inScreen != (int) FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack) {
                buttonInfo.position.x = 320 - (42.0f);
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_ExitMenuSystem;
                if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
                }
                else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                    buttonInfo.position.x -= 10.0f;
                    buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_StartGame];
                    buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                    startButtonIdLB = (screen[(int)inScreen]).AddButtonP1(buttonInfo, 0.08f);
                    ((screen[(int)inScreen]).GetButton(startButtonIdLB)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                    ((screen[(int)inScreen]).GetButton(startButtonIdLB)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel),
                      (int)World.Enum9.kFE_BackBarPlay);
                    ((screen[(int)inScreen]).GetButton(startButtonIdLB)).SetActionId( FrontEndActions.kFrontEndAction_CreateTrack);
                    (((screen[(int)inScreen]).GetButton(startButtonIdLB)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                }
                else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack) {
                    buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LB_Done);
                    buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_TrackReceived;
                    startButtonIdnr = (screen[(int)inScreen]).AddButtonP1(buttonInfo, 0.08f);
                }
                else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack) {
                }
                else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack) {
                }

            }

            float kWordScale2;
            string inString2;
            kWordScale2 = 0.7f;
            inString2 = "easy one\n";
            if (((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.
              kFrontEndScreen_NetReceiveChooseTrack) || ((int)inScreen == (int) FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack)) {
                int thing = (screen[(int)inScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas((
                  int) AtlasType.kAtlas_FontColours), Utilities.CGPointMake(160.0f, 81.0f), kWordScale2, inString2, true);
                if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                    ((screen[(int)inScreen]).GetFunnyWord(thing)).SetOrientationButton(((screen[(int)inScreen]).GetButton(startButtonIdBonus)).hangingButton);
                }

            }

            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack) {
                kWordScale2 = 0.48f;
                float xPos = 163;
                float yPos = 30;
                inString2 = "choose slot to save track\n";
                (screen[(int)inScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
                  .kAtlas_FontColours), Utilities.CGPointMake(xPos, yPos), kWordScale2, inString2, true);
            }
            else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack) {
                kWordScale2 = 0.5f;
                float xPos = 163;
                float yPos = 30;
                inString2 = "choose track to send\n";
                (screen[(int)inScreen]).AddFunnyWordP1P2P3P4P5P6(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas( AtlasType
                  .kAtlas_FontColours), Utilities.CGPointMake(xPos, yPos), kWordScale2, inString2, true);
            }

            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                buttonInfo.position.x = 205;
                buttonInfo.position.y = kChooseTrackBottomButtonsPos + 10;
								if (Globals.useIPadBackScreens) {
                    buttonInfo.position.y += 16.0f;
                }

                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_EnterTrackName;
                buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_Keyboard];
            //    keybButtonIdLB = (screen[(int)inScreen]).AddButtonP1(buttonInfo, 0.08f);
              //  (((screen[(int)inScreen]).GetButton(keybButtonIdLB)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
              //  (((screen[(int)inScreen]).GetButton(keybButtonIdLB)).zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToBottom);
              //  (((screen[(int)inScreen]).GetButton(keybButtonIdLB)).zobject).SetShowScale(0.85f);
              //  ((screen[(int)inScreen]).GetButton(keybButtonIdLB)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
              //  ((screen[(int)inScreen]).GetButton(keybButtonIdLB)).SetWidth(80.0f);
              //  ((screen[(int)inScreen]).GetButton(keybButtonIdLB)).SetHeight(80.0f);
                buttonInfo.position.x = 115.0f;
                buttonInfo.position.y = kChooseTrackBottomButtonsPos + 10;
								if (Globals.useIPadBackScreens) {
                    buttonInfo.position.y += 32.0f;
                }

                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                buttonInfo.texture = null;
                trashButtonIdLB = (screen[(int)inScreen]).AddButtonP1(buttonInfo, 0.08f);
                ((screen[(int)inScreen]).GetButton(trashButtonIdLB)).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas( AtlasType.kAtlas_FrontendAndShowlevel), 
                  (int)World.Enum9.kFE_Trash);
                ((screen[(int)inScreen]).GetButton(trashButtonIdLB)).SetActionId( FrontEndActions.kFrontEndAction_TryTrashCustomLevel);
                (((screen[(int)inScreen]).GetButton(trashButtonIdLB)).zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
                (((screen[(int)inScreen]).GetButton(trashButtonIdLB)).zobject).SetHideStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
                (((screen[(int)inScreen]).GetButton(trashButtonIdLB)).zobject).SetShowScale(0.85f);
                ((screen[(int)inScreen]).GetButton(trashButtonIdLB)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                ((screen[(int)inScreen]).GetButton(trashButtonIdLB)).SetWidth(80.0f);
                ((screen[(int)inScreen]).GetButton(trashButtonIdLB)).SetHeight(80.0f);
                FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
                qInfo.position = Utilities.CGPointMake(160, 240);
                qInfo.boxDimensions = Utilities.CGPointMake(200, 200);
                qInfo.backdropTexture = buttonTexture[(int)Enum.kButtonTexture_QueryBackdrop];
                qInfo.textTexture = null;
                qInfo.noButton = buttonTexture[(int)Enum.kButtonTexture_QueryNo];
                qInfo.yesButton = buttonTexture[(int)Enum.kButtonTexture_QueryYes];
                qInfo.useActualText = true;
                qInfo.dimTexture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureDimOverlay);
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    qInfo.theInfo1 = "Dieses Level\n";
                    qInfo.theInfo2 = "wirklich\n";
                    qInfo.theInfo3 = "leeren?\n";
                }
                else {
                    qInfo.theInfo1 = "are you sure\n";
                    qInfo.theInfo2 = "you'd like to\n";
                    qInfo.theInfo3 = "clear this level?\n";
                }

                qInfo.theInfo4 = "\n";
                qInfo.theInfo5 = "\n";
                qInfo.theInfo6 = "\n";
                qInfo.theInfo7 = "\n";
                int qId;
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    FrontEndQuery.QueryInfoNew nqInfo = new FrontEndQuery.QueryInfoNew();
                    nqInfo.newStyleWithAtlas = false;
                    nqInfo.queryText = Globals.g_world.GetNSString ( StringId.kString_SureClearTrack);
                    nqInfo.backdropTexture = qInfo.backdropTexture;
                    nqInfo.position = qInfo.position;
                    nqInfo.inTextScale = 24.0f;
                    nqInfo.boxDimensions = Utilities.CGSizeMake(260.0f, 100.0f);
                    nqInfo.yesButton = qInfo.yesButton;
                    nqInfo.noButton = qInfo.noButton;
					nqInfo.numButtons = 0;
                    qId = (screen[(int)inScreen]).AddQueryNew(nqInfo);
                }
                else {
                    qId = (screen[(int)inScreen]).AddQuery(qInfo);
                }

                ((screen[(int)inScreen]).GetQuery(qId)).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours));
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    qInfo.theInfo1 = "Das Level\n";
                    qInfo.theInfo2 = "ist bereits leer\n";
                }
                else {
                    qInfo.theInfo1 = "level is\n";
                    qInfo.theInfo2 = "already empty\n";
                }

                qInfo.theInfo3 = "\n";
                qInfo.theInfo4 = "\n";
                qInfo.theInfo5 = "\n";
                qInfo.theInfo6 = "\n";
                qInfo.theInfo7 = "\n";
                qInfo.noButton = null;
                qInfo.yesButton = buttonTexture[(int)Enum.kButtonTexture_QueryOk];
//				qInfo.numButtons = 0;

                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
					FrontEndQuery.QueryInfoNew nqInfo = new FrontEndQuery.QueryInfoNew();
                    nqInfo.newStyleWithAtlas = false;
                    nqInfo.queryText = Globals.g_world.GetNSString ( StringId.kString_LevelAlreadyEmpty);
                    nqInfo.backdropTexture = qInfo.backdropTexture;
                    nqInfo.position = qInfo.position;
                    nqInfo.inTextScale = 28.0f;
                    nqInfo.boxDimensions = Utilities.CGSizeMake(260.0f, 100.0f);
                    nqInfo.yesButton = qInfo.yesButton;
                    nqInfo.noButton = qInfo.noButton;
					nqInfo.numButtons = 0;
                    qId = (screen[(int)inScreen]).AddQueryNew(nqInfo);
                }
                else {
                    qId = (screen[(int)inScreen]).AddQuery(qInfo);
                }

                ((screen[(int)inScreen]).GetQuery(qId)).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours));
                if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
                    qInfo.theInfo1 = "Sie haben\n";
                    qInfo.theInfo2 = "nicht das\n";
                    qInfo.theInfo3 = "Niveau angelegt\n";
                }
                else {
                    qInfo.theInfo1 = "you haven't\n";
                    qInfo.theInfo2 = "created that level\n";
                    qInfo.theInfo3 = "yet\n";
                }

                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    FrontEndQuery.QueryInfoNew nqInfo = new FrontEndQuery.QueryInfoNew();
                    nqInfo.newStyleWithAtlas = false;
                    nqInfo.queryText = Globals.g_world.GetNSString ( StringId.kString_LevelAlreadyEmpty);
                    nqInfo.backdropTexture = qInfo.backdropTexture;
                    nqInfo.position = qInfo.position;
                    nqInfo.inTextScale = 28.0f;
                    nqInfo.boxDimensions = Utilities.CGSizeMake(260.0f, 100.0f);
                    nqInfo.yesButton = qInfo.yesButton;
                    nqInfo.noButton = qInfo.noButton;
					nqInfo.numButtons = 0;
                    qId = (screen[(int)inScreen]).AddQueryNew(nqInfo);
                }
                else {
                    qId = (screen[(int)inScreen]).AddQuery(qInfo);
                }

                ((screen[(int)inScreen]).GetQuery(qId)).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours));
            }

            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack) {
                FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
                qInfo.position = Utilities.CGPointMake(160, 240);
                qInfo.boxDimensions = Utilities.CGPointMake(200, 200);
                qInfo.backdropTexture = null;
                qInfo.textTexture = null;
                qInfo.noButton = null;
                qInfo.yesButton = buttonTexture[(int)Enum.kButtonTexture_QueryOk];
                qInfo.useActualText = true;
                qInfo.dimTexture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureDimOverlay);
                qInfo.theInfo1 = "you haven't\n";
                qInfo.theInfo2 = "created that level\n";
                qInfo.theInfo3 = "yet\n";
                qInfo.theInfo4 = "\n";
                qInfo.theInfo5 = "\n";
                qInfo.theInfo6 = "\n";
                qInfo.theInfo7 = "\n";
                int qId = (screen[(int)inScreen]).AddQuery(qInfo);
                ((screen[(int)inScreen]).GetQuery(qId)).SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours));
            }

            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_ChooseTrack) {
            }
            else if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack) {
                buttonInfo.position = Utilities.CGPointMake(185, 430);
                buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_ViewLeaderboard];
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                buttonId = (screen[(int)inScreen]).AddButtonP1(buttonInfo, 0.2f);
                ((screen[(int)inScreen]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_Throb);
                ((screen[(int)inScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_ViewScoresLeaderboard);
                buttonInfo.position = Utilities.CGPointMake(270, 430);
                buttonInfo.texture = buttonTexture[(int)Enum.kButtonTexture_SubmitAll];
                buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
                buttonId = (screen[(int)inScreen]).AddButtonP1(buttonInfo, 0.2f);
                ((screen[(int)inScreen]).GetButton(buttonId)).SetClickStyle( ButtonClickStyle.kButtonClick_ThrobAndGo);
                ((screen[(int)inScreen]).GetButton(buttonId)).SetActionId( FrontEndActions.kFrontEndAction_SubmitScoresToAgon);
            }

            buttonInfo.textureLabel = null;
            if ((int)inScreen == (int)FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack) {
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    FrontEndScreen.AddFunnyWordInfo fInfo;
                    fInfo.inString = "创建";
                    fInfo.position = ((screen[(int)inScreen]).GetButton(startButtonIdLB)).position;
                    fInfo.position.y -= 0.0f;
                    fInfo.scale = 0.3f;
                    int fwId = (screen[(int)inScreen]).AddFunnyWord(fInfo);
                    startButtonFWId = fwId;
                    ((screen[(int)inScreen]).GetFunnyWord(fwId)).SetColour(Constants.kBrown_FleeceMenu);
                    ((screen[(int)inScreen]).GetFunnyWord(fwId)).SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
                    ((screen[(int)inScreen]).GetFunnyWord(fwId)).SetPositionButton((screen[(int)inScreen]).GetButton(startButtonIdLB));
                }

            }

            Globals.g_world.AddBackWordsP1(screen[(int)thisScreen], backButtonId);
        }

        public void SetupAllScreens()
        {
         //   for (int i = 0; i < kMaxClouds; i++) {
           //     (cloud[i]).Reset();
            //}

            AppleWon.AppleWonInfo aInfo = new AppleWon.AppleWonInfo();
            aInfo.position = Utilities.CGPointMake(90.0f, kChooseTrackApplesYPos);
            aInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureApple);
            aInfo.timeBetweenApples = 0.1f;
            aInfo.distanceBetweenApples = 26.0f;
            aInfo.appleScale = 0.55f;
            aInfo.soundEffectId = -1;
            //LightBallInfo ballInfo;
//            ballInfo.inBallTex = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LightBall);
  //          ballInfo.inBeamTex = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LightBeam);
    //        ballInfo.rotSpeed = 0.001f;
      //      lightBall.Initialise(ballInfo);
        //    lightBall.SetAppearing(true);
          //  lightBall.SetupTopLeft();
            for (int i = 0; i < (int) FrontEndScreenEnum.kNumFrontEndScreens; i++) {
                (screen[i]).ResetInfo();
            }

            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.position = Utilities.CGPointMake(100, 170);
            info.texture = buttonTexture[(int)Enum.kButtonTexture_HandStamp];
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            handStamp.Initialise(info);
            handStamp.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_HandStamp);
            handStamp.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_HandStamp);
            info.texture = buttonTexture[(int)Enum.kButtonTexture_GreenAntStamp];
            greenAntLogo.Initialise(info);
            greenAntLogo.SetShowScale(0.45f);
            info.position = Utilities.CGPointMake(140, 70);
            info.texture = buttonTexture[(int)Enum.kButtonTexture_TitleWord1];
            titleWord1.Initialise(info);
            titleWord1.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_ZoomAndWobble);
            titleWord1.SetShowScale((300 / 280));
            info.position = Utilities.CGPointMake(195, 163);
            info.texture = buttonTexture[(int)Enum.kButtonTexture_TitleWord2];
            titleWord2.Initialise(info);
            titleWord2.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_ZoomAndWobble);
            for (int i = 0; i < (int) FrontEndScreenEnum.kNumFrontEndScreens; i++) {
                (screen[i]).Setup();
                (screen[i]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_MenuBackGround]);
            }

            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Title]).SetBackScreen((Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureSplashTitlePic));
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_GreenAnt]).SetBackScreen(Globals.g_main._textures[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_LoadingScreenEnd]).SetBackScreen(null);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_LBHowTo]).SetBackScreen((Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_LBHowTo));
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Main]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ShaunOnPodium]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Options]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_MenuBackGround]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseStage]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ColouredBack]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_LBPlayOrBuild]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ColouredBack]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTrack]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ColouredBack]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ColouredBack]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ColouredBack]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ColouredBack]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ColouredBack]);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_ChooseTerrainForCustomLevel]).SetBackScreen(buttonTexture[(int)Enum.kButtonTexture_ColouredBack]);
            ButtonInfo buttonInfo = new ButtonInfo();
            buttonInfo.textureLabel = null;
            this.SetupBehindGameCenter();
            this.SetupMultiplayerConnect();
            this.SetupTitleScreen();
            this.SetupFeatureNotAvailable();
            this.SetupMainScreen();
            this.SetupStoreScreen();
            this.SetupTest();
            this.SetupOptionsScreen();
            this.SetupLegalScreen();
            this.SetupNoBestTimesInEasy();
            this.SetupWaitForDropbox();
            this.SetupGreenAnt();
            this.SetupChooseControls();
            this.SetupContolChoice_Choose();
            this.SetupContolChoice_ShowFinger();
            this.SetupContolChoice_ShowThumb();
            this.SetupContolChoice_ShowTilt();
            this.SetupContolChoice_ShowTiltExpert();
            this.SetupContolChoice_ShowTiltAuto();
            this.SetupContolChoice_Final();
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_Test]).SetBackScreen(null);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_About_3]).SetBackScreen(null);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_About_4]).SetBackScreen(null);
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_About_5]).SetBackScreen(null);
            this.SetupAboutScreen_2();
            this.SetupAboutScreen_2_8();
            this.SetupAboutScreen_2_6();
            this.SetupAboutScreen_3();
            this.SetupAboutScreen_4();
            this.SetupAboutScreen_5();
            this.SetupEnterTrackNameScreen();
            buttonInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_ButtonBigCloud);
            buttonInfo.position.y = 160;
            buttonInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Main;
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_PlayGameOptions]).AddButton(buttonInfo);
            buttonInfo.position.y += 60;
            (screen[(int) FrontEndScreenEnum.kFrontEndScreen_PlayGameOptions]).AddButton(buttonInfo);
            this.SetupChooseStageScreen();
            this.SetupChooseTerrainScreen();
            this.SetupChooseTrackScreen( FrontEndScreenEnum.kFrontEndScreen_ChooseTrack);
            this.SetupChooseTrackScreen( FrontEndScreenEnum.kFrontEndScreen_LBChooseTrack);
            this.SetupChooseTrackScreen( FrontEndScreenEnum.kFrontEndScreen_HighScoresChooseTrack);
            this.SetupChooseTrackScreen( FrontEndScreenEnum.kFrontEndScreen_NetSendChooseTrack);
            this.SetupChooseTrackScreen( FrontEndScreenEnum.kFrontEndScreen_NetReceiveChooseTrack);
            this.SetupChooseTrackScreen( FrontEndScreenEnum.kFrontEndScreen_BonusChooseTrack);
            this.SetupLBPlayOrBuild();
            this.SetupLBHowTo();
            this.SetupWaitForClient();
            this.SetupBrowseServers();
            this.SetupReceivedTrack();
            this.SetupSendComplete();
        }

    }
}
