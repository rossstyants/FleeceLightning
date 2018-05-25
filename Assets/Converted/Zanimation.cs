using System;

namespace Default.Namespace
{
    public enum  GapType {
        kAnimGapTime,
        kAnimGapDistance
    }
    public enum  AnimationState {
        kAnimNotStarted = -1,
        kAnimPlaying,
        kAnimFinished,
        kAnimStopped
    }
    public enum  AnimationStyle {
        kAnimPlayLooping,
        kAnimPlayOnce
    }
	
       public class ZAnimationInfo{
            public int numFrames;
            public Texture2D_Ross[] texture = new Texture2D_Ross [(int)Zanimation.Enum.kMaxTexturesInAnim];
            public float[] frameTime = new float[(int)Zanimation.Enum.kMaxTexturesInAnim];
            public int[] subTextureId = new int [(int)Zanimation.Enum.kMaxTexturesInAnim];
            public GapType gapType;
        };

	
    public class Zanimation
    {
        public Texture2D_Ross[] texture = new Texture2D_Ross[(int)Enum.kMaxTexturesInAnim];
        public float[] frameTime = new float[(int)Enum.kMaxTexturesInAnim];
        public int[] subTextureId = new int[(int)Enum.kMaxTexturesInAnim];
        public float timer;
        public int currentFrame;
        public int numFrames;
        public AnimationState state;
        public AnimationStyle style;
        public GapType gapType;
        public bool justChangedFrame;
        public int atlasId;

		public enum  Enum {
            kMaxTexturesInAnim = 13
        };
        public AnimationState State
        {
            get;
            set;
        }

        public GapType GapType
        {
            get;
            set;
        }

        public AnimationStyle Style
        {
            get;
            set;
        }

        public bool JustChangedFrame
        {
            get;
            set;
        }

        public int CurrentFrame
        {
            get;
            set;
        }

		public void SetState(AnimationState inThing) {state = inThing;}///@property(readwrite,assign) AnimationState state;
public void SetGapType(GapType inThing) {gapType = inThing;}///@property(readwrite,assign) GapType gapType;
public void SetStyle(AnimationStyle inThing) {style = inThing;}///@property(readwrite,assign) AnimationStyle style;
public void SetJustChangedFrame(bool inThing) {justChangedFrame = inThing;}///@property(readwrite,assign) bool justChangedFrame;
public void SetCurrentFrame(int inThing) {currentFrame = inThing;}///@property(readwrite,assign) int currentFrame;

        public void SetupP1 (ZAnimationInfo info, float standardGap)
		{
			justChangedFrame = false;
			numFrames = info.numFrames;
			Globals.Assert (numFrames <= (int)Enum.kMaxTexturesInAnim);
            for (int i = 0; i < numFrames; i++) {
                info.frameTime[i] = standardGap;
            }

            this.Setup(info);
        }

        public void Setup (ZAnimationInfo info)
		{
			numFrames = info.numFrames;
			Globals.Assert (numFrames <= (int)Enum.kMaxTexturesInAnim);
            float gapTotal = 0;
            for (int i = 0; i < numFrames; i++) {
                gapTotal += info.frameTime[i];
                texture[i] = info.texture[i];
                subTextureId[i] = info.subTextureId[i];
                frameTime[i] = gapTotal;
            }

            state = AnimationState.kAnimNotStarted;
            gapType = info.gapType;
            currentFrame = 0;
        }

        public void Stop()
        {
            state = AnimationState.kAnimStopped;
        }

        public void SetAnimTime(float speed)
        {
            float gapTotal = 0;
            for (int i = 0; i < numFrames; i++) {
                gapTotal += speed;
                frameTime[i] = gapTotal;
            }

        }

        public bool IsFinished()
        {
            return (state == AnimationState.kAnimFinished);
        }

        public void PlayLooping()
        {
            timer = 0;
            currentFrame = 0;
            state = AnimationState.kAnimPlaying;
            style = AnimationStyle.kAnimPlayLooping;
        }

        public void PlayOnce()
        {
            timer = 0;
            currentFrame = 0;
            state = AnimationState.kAnimPlaying;
            style = AnimationStyle.kAnimPlayOnce;
        }

        public int GetFrame()
        {
            if (state == AnimationState.kAnimFinished) return currentFrame - 1;
            else return currentFrame;

        }

        public Texture2D_Ross GetTexture()
        {
            if (state == AnimationState.kAnimFinished) return texture[currentFrame - 1];
            else return texture[currentFrame];

        }

        public int GetSubTextureId()
        {
            if (state == AnimationState.kAnimFinished) return subTextureId[currentFrame - 1];
            else return subTextureId[currentFrame];

        }

        public bool Update()
        {
            Globals.Assert(gapType !=  GapType.kAnimGapDistance);
            return this.UpdateWithDistance(0);
        }

        public bool UpdateWithDistance(float distanceTravelled)
        {
            if (state != (int) AnimationState.kAnimPlaying) return false;

            if (gapType ==  GapType.kAnimGapTime) timer += Constants.kFrameRate;
            else timer += distanceTravelled;

            if (timer >= frameTime[currentFrame]) {
                justChangedFrame = true;
                currentFrame++;
                if (currentFrame >= numFrames) {
                    if (style == (int) AnimationStyle.kAnimPlayLooping) {
                        currentFrame = 0;
                        timer = 0;
                    }
                    else {
                        state = AnimationState.kAnimFinished;
                    }

                }

                return true;
            }
            else {
                justChangedFrame = false;
            }

            return false;
        }

    }
}
