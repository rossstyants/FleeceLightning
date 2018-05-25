using System;

namespace Default.Namespace
{
    public enum  StartingGateState {
        e_Open,
        e_Opening,
        e_Closed,
        e_Closing,
        e_Inactive
    }
    public enum  StartingGateType {
        e_Left,
        e_Right
    }
    public class StartingGate
    {
        public int mapObjectId;
        public StartingGateState state;
        public StartingGateState startingState;
        public StartingGateType type;
        public Zanimation animOpen;
        public Zanimation animClose;
        public Zshake shake;
        public CGPoint mapPosition;
        public struct StartingGateInfo{
            public StartingGateType inType;
            public StartingGateState startingState;
            public CGPoint mapPosition;
        };
        public StartingGateState State
        {
            get;
            set;
        }

        public StartingGateState StartingState
        {
            get;
            set;
        }

        public StartingGate()
        {
            //if (!base.init()) return null;

            this.Reset();
            animOpen = new Zanimation();
            animClose = new Zanimation();
            shake = new Zshake();
            //return this;
        }
        public void SetupAnimations()
        {
            int kStartGateSubtextures = 184;
            ZAnimationInfo aInfo = new ZAnimationInfo();
            ZAnimationInfo aCloseInfo = new ZAnimationInfo();
            aInfo.numFrames = 6;
            aInfo.gapType = GapType.kAnimGapTime;
            aCloseInfo.numFrames = 6;
            aCloseInfo.gapType = GapType.kAnimGapTime;
            if ((int)type == (int) StartingGateType.e_Left) {
                for (int i = 0; i < 6; i++) {
                    aCloseInfo.subTextureId[i] = kStartGateSubtextures + 5 - i;
                    aInfo.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_GateLeft1 + i);
                    aInfo.frameTime[i] = 0.04f;
                    aInfo.subTextureId[i] = kStartGateSubtextures + i;
                    aCloseInfo.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_GateLeft6 - i);
                    aCloseInfo.frameTime[i] = 0.04f;
                }

            }
            else {
                kStartGateSubtextures += 6;
                for (int i = 0; i < 6; i++) {
                    aCloseInfo.subTextureId[i] = kStartGateSubtextures + 5 - i;
                    aInfo.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_GateRight1 + i);
                    aInfo.frameTime[i] = 0.04f;
                    aInfo.subTextureId[i] = kStartGateSubtextures + i;
                    aCloseInfo.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_GateRight6 - i);
                    aCloseInfo.frameTime[i] = 0.04f;
                }

            }

            aCloseInfo.frameTime[0] = 0.12f;
            animOpen.Setup(aInfo);
            animClose.Setup(aCloseInfo);
        }

        public void Reset()
        {
            state = startingState;
            mapObjectId = -1;
        }

        public void AddToScene(StartingGateInfo info)
        {
            startingState = info.startingState;
            state = info.startingState;
            type = info.inType;
            mapPosition = info.mapPosition;
            this.SetupAnimations();
            shake.Reset();
        }

        public void SetMapObjectId(int i)
        {
            mapObjectId = i;
            CGPoint displayPosition;
            if (state == (int) StartingGateState.e_Open) {
                displayPosition = this.GetDisplayPosition(5);
            }
            else {
                displayPosition = this.GetDisplayPosition(0);
            }

            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(displayPosition);
        }

        public void Open()
        {
            state = StartingGateState.e_Opening;
            animOpen.PlayOnce();
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_GateOpen);
        }

        public void Close()
        {
            state = StartingGateState.e_Closing;
            animClose.PlayOnce();
        }

        public CGPoint GetDisplayPosition(int animFrame)
        {
            Globals.Assert(animFrame < 6);
            CGPoint[] displayOffset = new CGPoint[6];
            displayOffset[0] = Utilities.CGPointMake(0, -20);
            displayOffset[1] = Utilities.CGPointMake(-1, -14);
            displayOffset[2] = Utilities.CGPointMake(-5, -5);
            displayOffset[3] = Utilities.CGPointMake(-13, 1);
            displayOffset[4] = Utilities.CGPointMake(-22, 5);
            displayOffset[5] = Utilities.CGPointMake(-30, 5);
            if ((int)type == (int) StartingGateType.e_Right) {
                displayOffset[animFrame].x = -displayOffset[animFrame].x;
            }

            return Utilities.CGPointMake(mapPosition.x + displayOffset[animFrame].x, mapPosition.y + displayOffset[animFrame].y);
        }

        public void Wobble()
        {
            Zshake.ShakeInfo info = new Zshake.ShakeInfo();
            info.xSize = 0.0f;
            info.ySize = 1.8f;
            info.xSpeed = 0.0f;
            info.ySpeed = 0.0f;
            info.xPosition = 0.0f;
            info.yPosition = 0.0f;
            shake.Setup(info);
            shake.Reset();
            shake.StartP1(Utilities.GetRandBetweenP1(0.65f, 1.2f), 0.8f);
        }

        public void Update()
        {
            CGPoint displayPosition;
            if (shake.IsShaking()) {
                shake.Update();
                CGPoint displayPosition2 = this.GetDisplayPosition(animOpen.GetFrame());
                displayPosition2.x += shake.x;
                displayPosition2.y += shake.y;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(displayPosition2);
            }

            switch (state) {
            case StartingGateState.e_Opening :
                animOpen.Update();
                if (animOpen.state == AnimationState.kAnimFinished) {
                    state = StartingGateState.e_Open;
                }

                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId(animOpen.GetSubTextureId());
                displayPosition = this.GetDisplayPosition(animOpen.GetFrame());
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(displayPosition);
                break;
            case StartingGateState.e_Closing :
                animClose.Update();
                if (animClose.state == AnimationState.kAnimFinished) {
                    state = StartingGateState.e_Closed;
                }

                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId(animClose.GetSubTextureId());
                displayPosition = this.GetDisplayPosition(5 - animClose.GetFrame());
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(displayPosition);
                break;
            default :
                break;
            }

        }

        public int GetSubTextureId()
        {
            switch (state) {
            case StartingGateState.e_Opening :
            case StartingGateState.e_Closed :
                return animOpen.GetSubTextureId();
                break;
            case StartingGateState.e_Closing :
            case StartingGateState.e_Open :
                return animClose.GetSubTextureId();
            default :
                break;
            }

            return -1;
        }

    }
}
