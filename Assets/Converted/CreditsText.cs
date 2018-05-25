using System;

namespace Default.Namespace
{
    public enum  CreditsTextState {
        kStateHidingLastText = 0,
        kStateDisplayingText
    }
    public class CreditsText
    {
        public float timeSinceText;
        public FunnyWord[] funnyWord = new FunnyWord[(int)Enum.kCTMaxFunnyWords];
        public CreditsTextState state;
        public int currentText;
        public float aardmanAlpha;
        public FrontEndQuery aardmanCredit;
        public enum Enum {
            kCTMaxFunnyWords = 3,
            kCTNumTexts = 13
        };
        const float kAardFadeTime = 0.8f;

        public CreditsText()
        {
            //if (!base.init()) return null;

            for (int i = 0; i < (int)Enum.kCTMaxFunnyWords; i++) 
			{
                funnyWord[i] = new FunnyWord();
                (funnyWord[i]).SetUseTextureInstead(false);
            }

            aardmanCredit = new FrontEndQuery();
            this.SetupAardmanTexture();
            //return this;
        }
        public void SetupAardmanTexture()
        {
            FrontEndQuery.QueryInfoNew qInfo = new FrontEndQuery.QueryInfoNew();
            qInfo.backdropTexture = null;
            qInfo.boxDimensions = Utilities.CGSizeMake(280.0f, 140.0f);
            qInfo.inTextScale = 20.0f;
            qInfo.newStyleWithAtlas = false;
            qInfo.noButton = null;
            qInfo.yesButton = null;
            qInfo.useActualText = true;
            qInfo.queryText = "AARDMAN(C) AND\n TM AARDMAN ANIMATIONS\n LTD 2011";
            qInfo.position = Utilities.CGPointMake(160.0f, 410.0f);
			qInfo.numButtons = 0;
			qInfo.useNSStringForAnyLanguage = true;
            aardmanCredit.InitialiseNew(qInfo);
        }

        public void Setup()
        {
        }
        public void StopRender()
        {
            (funnyWord[0]).StopRender();
            (funnyWord[1]).StopRender();
            (funnyWord[2]).StopRender();

			Globals.g_world.tileCam.enabled = false;
			aardmanCredit.StopRender();
		}

        public void Start()
        {
			Globals.g_world.tileCam.enabled = true;
            state = CreditsTextState.kStateHidingLastText;
            timeSinceText = 0.0f;
            currentText = 0;
        }

        public void Hide()
        {
            (funnyWord[0]).StopRender();
            (funnyWord[1]).StopRender();
            (funnyWord[2]).StopRender();

			
			Globals.g_world.tileCam.enabled = false;
			aardmanCredit.StopRender();
        }

        public void HideThisText()
        {
            (funnyWord[0]).Hide();
            (funnyWord[1]).HideRipple();
            (funnyWord[2]).Hide();
        }

        public void ShowNextText()
        {
            aardmanAlpha = 0.0f;
            string[,] newText = new string[3, (int)Enum.kCTNumTexts];
            int creditIndex = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < (int)Enum.kCTNumTexts; j++) {
                    newText[i, j] = "\n";
                }

            }

            newText[0,creditIndex] = "made by\n";
            newText[1,creditIndex] = "green ant\n";
            newText[2,creditIndex] = "games\n";
            creditIndex++;
            newText[0,creditIndex] = "art design\n";
            newText[1,creditIndex++] = "and animation by\n";
            newText[0,creditIndex] = "game designed by\n";
            newText[1,creditIndex++] = "Ross Styants\n";
            newText[0,creditIndex] = "special thanks to\n";
            newText[1,creditIndex++] = "ben greenfield\n";
            newText[0,creditIndex] = "huge thanks to\n";
            newText[1,creditIndex] = "all the\n";
            newText[2,creditIndex++] = "testers!\n";
            newText[0,creditIndex] = "Derek Styants\n";
            newText[1,creditIndex] = "Mai Styants\n";
            newText[2,creditIndex++] = "Richard Styants\n";
            newText[0,creditIndex] = "Hannah Williams\n";
            newText[1,creditIndex] = "Ethan Williams\n";
            newText[2,creditIndex++] = "David Williams\n";
            newText[0,creditIndex] = "Michael Jones\n";
            newText[1,creditIndex] = "Rhys Jones\n";
            newText[2,creditIndex++] = "Tanya Gambling\n";
            newText[0,creditIndex] = "Irene Styants\n";
            newText[1,creditIndex] = "Simeon Smith\n";
            newText[2,creditIndex++] = "Mark Styants\n";
            newText[0,creditIndex] = "Thom Wilson\n";
            newText[1,creditIndex] = "Patrick Hughes\n";
            newText[2,creditIndex++] = "Adrian Hidalgo\n";
            newText[0,creditIndex] = "\n";
            newText[1,creditIndex++] = "\n";
            newText[0,creditIndex] = "\n";
            newText[1,creditIndex++] = "thanks for playing\n";
            newText[0,creditIndex] = "\n";
            newText[1,creditIndex++] = "\n";

            FunnyWord.WordInfo wInfo;
            wInfo.position = Utilities.CGPointMake(160.0f, 312.0f);
            wInfo.isCentrePos = true;
            wInfo.scale = 0.45f;
            Constants.RossColour textColour = Constants.kColourLilac;
            if (currentText == 1) {
                wInfo.scale = 0.55f;
            }

            if ((currentText >= 5) && (currentText <= 9)) {
                wInfo.scale = 0.55f;
                textColour = Constants.kColourLightblue;
            }

            (funnyWord[0]).SetFont(Globals.g_world.font);
            (funnyWord[0]).SetLineAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines));
            (funnyWord[0]).SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));
			(funnyWord[0]).InitWithWordP1(wInfo, newText[0, currentText]);
            (funnyWord[0]).SetColour(textColour);
            (funnyWord[0]).SetShowStyle(FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (funnyWord[0]).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_Zoom);
            (funnyWord[0]).Show();
            wInfo.scale = 0.8f;
            float waitForNextWord = 0.78f;
            textColour = Constants.kColourLightblue;
            wInfo.position = Utilities.CGPointMake(160.0f, 365.0f);
            if (currentText == 1) {
                wInfo.scale = 0.55f;
                waitForNextWord = 0.2f;
                wInfo.position.y = 340.0f;
                aardmanCredit.Show();
            }

            if (currentText == 2) {
                aardmanCredit.Hide();
            }

            if (currentText == 3) {
            }

            if ((currentText >= 5) && (currentText <= 9)) {
                wInfo.scale = 0.55f;
                waitForNextWord = 0.6f;
                wInfo.position.y = 340.0f;
                (funnyWord[0]).Jiggle(0.5f);
            }

            if (currentText == 11) {
                wInfo.scale = 0.6f;
            }

            (funnyWord[1]).SetFont(Globals.g_world.font);
            (funnyWord[1]).SetLineAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines));
            (funnyWord[1]).SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));

			(funnyWord[1]).InitWithWordP1(wInfo, newText[1, currentText]);
            (funnyWord[1]).SetColour(textColour);
            (funnyWord[1]).SetShowStyle(FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (funnyWord[1]).Show(waitForNextWord);
            (funnyWord[1]).Jiggle(0.5f);
            (funnyWord[1]).SetHideStyle((int) (int) ZobjectHideStyle.kZobjectHide_DropOut);
            wInfo.position = Utilities.CGPointMake(160.0f, 410.0f);
            if ((currentText >= 5) && (currentText <= 11)) {
                wInfo.position.y = 368.0f;
            }

            if (currentText == 2) {
                wInfo.scale = 0.8f;
            }

            (funnyWord[2]).SetFont(Globals.g_world.font);
            (funnyWord[2]).SetLineAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines));
            (funnyWord[2]).SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));

			(funnyWord[2]).InitWithWordP1(wInfo, newText[2, currentText]);
            (funnyWord[2]).SetColour(Constants.kColourLightblue);
            (funnyWord[2]).SetShowStyle(FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble);
            (funnyWord[2]).Show(1.2f);
            (funnyWord[2]).Jiggle(0.5f);
            currentText += 1;
            if (currentText >= (int)Enum.kCTNumTexts) {
                currentText = 0;
            }

        }

        public void UpdateShowNextText()
        {
            float kTimeBetweenTexts = 1.0f;
            if (timeSinceText >= kTimeBetweenTexts) {
                this.ShowNextText();
                state = CreditsTextState.kStateDisplayingText;
                timeSinceText = 0.0f;
            }

        }

        public void UpdateHideText()
        {
            float kTimeTextShown = 4.5f;
            const float kWaitForAard = 1.0f;
            if (currentText == 2) {
                kTimeTextShown = 6.5f;
            }

            if (currentText == ((int)Enum.kCTNumTexts - 1)) {
                kTimeTextShown = 6.5f;
            }

            if (currentText == 2) {
                if (timeSinceText >= (kTimeTextShown - kAardFadeTime)) {
                    aardmanAlpha = 1.0f - Utilities.GetRatioP1P2(timeSinceText, (kTimeTextShown - kAardFadeTime), kTimeTextShown);
                }
                else if (timeSinceText < kAardFadeTime + kWaitForAard) {
                    aardmanAlpha = Utilities.GetRatioP1P2(timeSinceText, kWaitForAard, kAardFadeTime + kWaitForAard);
                }

            }

            if (timeSinceText >= kTimeTextShown) {
                this.HideThisText();
                state = CreditsTextState.kStateHidingLastText;
                timeSinceText = 0.0f;
            }

        }

        public void Update()
        {
            switch (state) {
            case CreditsTextState.kStateHidingLastText :
                this.UpdateShowNextText();
                break;
            case CreditsTextState.kStateDisplayingText :
                this.UpdateHideText();
                break;
            default :
                Globals.Assert(false);
                break;
            }

            timeSinceText += Constants.kFrameRate;
            for (int i = 0; i < (int)Enum.kCTMaxFunnyWords; i++) {
                (funnyWord[i]).Update();
            }

            aardmanCredit.Update();
        }

        public void Render()
        {
            for (int i = 0; i < (int)Enum.kCTMaxFunnyWords; i++) {
                (funnyWord[i]).Render();
            }

            aardmanCredit.Render();
        }

    }
}
