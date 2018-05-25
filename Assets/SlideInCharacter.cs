using System;

namespace Default.Namespace
{
    public enum  SlideInSide {
        eLeft = 0,
        eRight,
        Sides
    }
    public class SlideInCharacter
    {
        public Zobject speechBubble;
        public Zobject character;
        public FunnyWord[] commentLine = new FunnyWord[2];
        public float yPos;
        public struct SlideInCharacterInfo {
            public int whichCharacter;
            public float yPos;
            public SlideInSide side;
        };

        public SlideInCharacter()
        {
            //if (!base.init()) return null;

            speechBubble = new Zobject();
            character = new Zobject();
            for (int i = 0; i < 2; i++) {
                commentLine[i] = new FunnyWord();
            }

            //return this;
        }
        public void Initialise(SlideInCharacterInfo inInfo)
        {
            yPos = inInfo.yPos;
            for (int i = 0; i < 2; i++) {
                (commentLine[i]).SetFont(Globals.g_world.font);
                (commentLine[i]).SetLineAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines));
                (commentLine[i]).SetColourAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontColours));
            }

            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            zInfo.position = Utilities.CGPointMake(160, inInfo.yPos);
            zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_PiggySpeechBubble);
            zInfo.startState = ZobjectState.kZobjectHidden;
            zInfo.isMapObject = false;
            speechBubble.Initialise(zInfo);
            speechBubble.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInTop);
            speechBubble.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
            speechBubble.SetShowScale(1.1f);
            if (inInfo.side == (int) SlideInSide.eLeft) zInfo.position = Utilities.CGPointMake(55, inInfo.yPos + 80.0f);
            else zInfo.position = Utilities.CGPointMake(260, inInfo.yPos + 80.0f);

            if (inInfo.whichCharacter == (int) PlayerType.kPlayerPig) {
                zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_PiggyHeadFE);
            }
            else zInfo.texture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_SheepyHead);

            zInfo.startState = ZobjectState.kZobjectHidden;
            zInfo.isMapObject = false;
            character.Initialise(zInfo);
            if (inInfo.side == (int) SlideInSide.eLeft) {
                character.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInLeft);
                character.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToLeft);
            }
            else {
                character.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
                character.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToRight);
            }

            character.SetShowScale(0.6f);
            if (inInfo.side == (int) SlideInSide.eLeft) speechBubble.SetHorizontallyFlipped(true);
            else speechBubble.SetHorizontallyFlipped(false);

        }

        public void SetTextP1(string inString1, string inString2)
        {
            FunnyWord.WordInfo wInfo1, wInfo2;
            wInfo1.scale = 0.54f;
            wInfo2.scale = 0.54f;
            wInfo1.isCentrePos = true;
            wInfo2.isCentrePos = true;
            wInfo1.position = Utilities.CGPointMake(150, yPos - 12.0f);
            if (inString2 != "\n") {
                wInfo1.position.y = yPos - 28.0f;
                wInfo2.position = Utilities.CGPointMake(150, yPos + 8.0f);
                (commentLine[1]).InitWithWordP1(wInfo2, inString2);
                (commentLine[1]).Show(1.6f);
            }
            else {
                (commentLine[1]).Disappear();
            }

            (commentLine[0]).InitWithWordP1(wInfo1, inString1);
            (commentLine[0]).Show(1);
            for (int i = 0; i < 2; i++) {
                (commentLine[i]).SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SlideToTop);
            }

        }

        public void Show(float inWait)
        {
            character.Show();
            character.SetWaitToShow(inWait);
            speechBubble.Show();
            speechBubble.SetWaitToShow(inWait);
            (commentLine[0]).Show(inWait);
            (commentLine[1]).Show(inWait + 0.6f);
        }

        public void Hide()
        {
            character.Hide();
            speechBubble.Hide();
            (commentLine[0]).Hide();
            (commentLine[1]).Hide();
        }

        public void Update()
        {
            character.Update();
            speechBubble.Update();
            (commentLine[0]).Update();
            (commentLine[1]).Update();
        }

        public void Render()
        {
            speechBubble.Render();
            character.Render();
            (commentLine[0]).Render();
            (commentLine[1]).Render();
        }

    }
}
