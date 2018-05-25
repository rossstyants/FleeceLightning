using System;

namespace Default.Namespace
{
    public class SpeedBoostScreen
    {
        public Zobject speedObject;
        public Zobject sheepPic;
        public Zobject sheepPicShadow;
        public Zobject infoBubbleBackground;
        public FunnyWord[] commentLine = new FunnyWord[(int)Enum.kNumCommentLines];
        public FrontEndButton doneButton;
        public float shownTimer;
        public int numApplesAdded;
        public int numApples;
        public int numApplesToAdd;
        public enum Enum {
            kNumCommentLines = 3
        };
        public FrontEndButton DoneButton
        {
            get;
            set;
        }

		public void SetDoneButton(FrontEndButton inThing) {doneButton = inThing;}////@property(readwrite,assign) FrontEndButton* doneButton;

        public SpeedBoostScreen ()
		{
			//if (!base.init()) return null;

			speedObject = new Zobject ();
			sheepPic = new Zobject ();
			infoBubbleBackground = new Zobject ();
			for (int i = 0; i < (int)Enum.kNumCommentLines; i++) commentLine[i] = new FunnyWord();

            doneButton = new FrontEndButton(0);
            //return this;
        }
        public void InitialiseZobjects()
        {
            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            zInfo.position = Utilities.CGPointMake(160.0f, 225.0f);
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_BubbleBack);
            infoBubbleBackground.Initialise(zInfo);
            infoBubbleBackground.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
            infoBubbleBackground.SetShowScale((320.0f / 256.0f));
            FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo();
            bInfo.position = Utilities.CGPointMake(160.0f, 430.0f);
            bInfo.texture = (Globals.g_world.frontEnd).GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_StartGame);
            bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            doneButton.Initialise(bInfo);
            (doneButton.zobject).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInBottom);
            (doneButton.zobject).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToBottom);
            (doneButton.zobject).SetThrobSize(0.075f);
            (doneButton.zobject).SetThrobTime(0.4f);
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureApple);
            zInfo.position = Utilities.CGPointMake(160.0f, 205.0f);
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureTurnip);
            speedObject.Initialise(zInfo);
            SpeedUpProgressEnum speedUp = ((Globals.g_world.frontEnd).profile).speedUpProgress;
            if (speedUp == SpeedUpProgressEnum.kSpeedUp_ThirdSpeedBoost) {
                speedObject.SetShowScale(1.0f);
            }
            else {
                speedObject.SetShowScale(0.7f);
            }

            speedObject.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_ZoomAndWobble);
            zInfo.position = Utilities.CGPointMake(160.0f, 298.0f);
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureTurnipSheep);
            sheepPic.Initialise(zInfo);
            sheepPic.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_FadeIn);
            zInfo.position = Utilities.CGPointMake(220.0f, 400.0f);
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureTurnipSheepShadow);
        }

        public void Setup()
        {
        }

        public void Show ()
		{
			this.Setup ();
			speedObject.Show ();
			speedObject.QueueAction (ZobjectAction.nThrobLooping);
			speedObject.SetThrobSize (0.05f);
			sheepPic.Show ();
			infoBubbleBackground.Show ();
			doneButton.Show ();
			(doneButton.zobject).QueueAction (ZobjectAction.nThrobLooping);
			for (int i = 0; i < (int)Enum.kNumCommentLines; i++) {
				(commentLine [i]).SetFont (Globals.g_world.font);
				(commentLine [i]).SetColour (Constants.kColourLilac);
			}

			float yStart = 62.0f;
			float yPlus = 40.0f;
			FunnyWord.WordInfo wInfo = new FunnyWord.WordInfo();
			wInfo.position = Utilities.CGPointMake (160.0f, yStart);
			wInfo.scale = 0.65f;
			wInfo.isCentrePos = true;
			string inWord = "you just got\n";
			(commentLine [0]).InitWithWordP1 (wInfo, inWord);
			yStart += yPlus;
			wInfo.position = Utilities.CGPointMake (160.0f, yStart);
			SpeedUpProgressEnum speedUp = ((Globals.g_world.frontEnd).profile).speedUpProgress;
			if (speedUp == SpeedUpProgressEnum.kSpeedUp_FirstSpeedBoost) {
				(commentLine [1]).SetColour (Constants.kColourLilac);
				inWord = "the turnip\n";
			} else if (speedUp == SpeedUpProgressEnum.kSpeedUp_SecondSpeedBoost) {
				(commentLine [1]).SetColour (Constants.kColourLilac);
				inWord = "the shear zen\n";
			} else if (speedUp == SpeedUpProgressEnum.kSpeedUp_ThirdSpeedBoost) {
				(commentLine [1]).SetColour (Constants.kColourLightblue);
				inWord = "the cattle prod\n";
			} else {
				Globals.Assert(false);
			}

			(commentLine [1]).InitWithWordP1 (wInfo, inWord);
			yStart += yPlus;
			wInfo.position = Utilities.CGPointMake (160.0f, yStart);
			inWord = "speed boost!\n";
			(commentLine [2]).InitWithWordP1 (wInfo, inWord);
			for (int i = 0; i < (int)Enum.kNumCommentLines; i++) {
                (commentLine[i]).SetLineAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines));
                (commentLine[i]).SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));
                float showTime = (((float) i) * 0.3f);
                (commentLine[i]).Show(showTime);
                (commentLine[i]).Jiggle(0.5f);
            }

        }

        public void Hide()
        {
        }

        public bool Update ()
		{
			shownTimer += Constants.kFrameRate;
			for (int i = 0; i < (int)Enum.kNumCommentLines; i++) (commentLine[i]).Update();

            speedObject.Update();
            sheepPic.Update();
            infoBubbleBackground.Update();
            doneButton.Update();
            if ((doneButton.zobject).state ==  ZobjectState.kZobjectHiding) {
                return true;
            }

            return false;
        }

        public void Render ()
		{
			infoBubbleBackground.Render ();
			for (int i = 0; i < (int)Enum.kNumCommentLines; i++) (commentLine[i]).Render();

            speedObject.Render();
            sheepPic.Render();
            doneButton.Render();
        }

    }
}
