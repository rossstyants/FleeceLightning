using UnityEngine;
using System;

namespace Default.Namespace
{
    public enum  ZobjectAction {
        nNone = -1,
        nHide,
        nThrobLooping,
        nThrobOnce,
        nFlash,
        nBounceOnce,
        nShow,
        nShowFromHideAndShow
    }
    public enum  ZobjectState {
        kZobjectActive,
        kZobjectShown,
        kZobjectHiding,
        kZobjectWaitingToShow,
        kZobjectShowing,
        kZobjectHidden,
        kZobjectMoving,
        kZobjectThrobbing,
        kZobjectFlashing
    }
    public enum  ZobjectShowStyle {
        kZobjectShow_Zoom,
        kZobjectShow_SlideInLeft,
        kZobjectShow_SlideInTop,
        kZobjectShow_SlideInBottom,
        kZobjectShow_SlideInRight,
        kZobjectShow_HandStamp,
        kZobjectShow_SpinIn,
        kZobjectShow_FadeIn,
        kZobjectShow_Immediate,
        kZobjectShow_ZoomAndWobble,
        kZobjectShow_DropIn,
        kZobjectShow_DropInFromBeneath,
        kZobjectShow_Boing
    }
    public enum  ZobjectHideStyle {
        kZobjectHide_Zoom,
        kZobjectHide_SlideToLeft,
        kZobjectHide_SlideToTop,
        kZobjectHide_SlideToBottom,
        kZobjectHide_SlideToRight,
        kZobjectHide_HandStamp,
        kZobjectHide_SpinOut,
        kZobjectHide_Immediate,
        kZobjectHide_FadeOut,
        kZobjectHide_DropOut,
        kZobjectHide_DontHide
    }
    public class Zobject
    {
		//atlases now work like this i think...
//nope		public Texture2D_Ross atlasTexture;
		
		public Billboard myAtlasBillboard;
		
        public Zanimation[] animation = new Zanimation[(int)Enum.kMaxAnimations];
        public Constants.RossColour zCol;
        public Constants.RossColour baseColour;
        public bool hasColour;
        public CGPoint startPosition;
        public CGPoint mapPosition;
        public CGPoint screenPosition;
        public CGPoint targetScreenPosition;
        public Texture2D_Ross texture;
        public ZobjectState state;
        public float stateTimer;
        public float waitToShow;
        public float waitToHide;
        public float queuedActionDelay;
        public ZobjectAction queuedAction;
        public bool isMapObject;
        public bool isLooping;
        public bool isFloaty;
        public bool stretchToScreen;
        public Zobject.FloatyInfo floatyInfo = new Zobject.FloatyInfo();
        //public ZBubble zBubble;
        public float showLagSpeed;
        public float scaleVelocity;
        public int numInterpolations;
        public int numAnimations;
        public int currentAnimation;
        public ZgravityInfo gravityInfo;
        public bool gravityOn;
        public float hasSpin;
        public float rotation;
        public float rotationScale;
        public float spinAmount;
        public CGPoint displayPosition;
        public bool isFlashOn;
        public float flashTime;
        public float showScale;
        public float actualDisplayScale;
        public float throbSize;
        public float throbTime;
        public float handFallVelocity;
        public float handInVelocity;
        public float alpha;
        public float showAlpha;
        public float defaultBounce;
        public float dropInDistance;
        public float hideAcc;
        public float hideStartSpeed;
        public ZobjectShowStyle showStyle;
        public ZobjectHideStyle hideStyle;
        public ZInterpolation[] interpolation = new ZInterpolation[(int)Enum.kMaxInterpolations];
        public Zshake shake;
        public ZAtlas tileBoxAtlas;
        public ZAtlas atlas;
        public Texture2D_Ross pendingTexture;
        public FunnyWord pendingChangeFunnyWord;
        public string pendingChangeFunnyWordText;
        public bool horizontallyFlipped;
        public bool isTileBox;
        public int soundEffectIdAppear;
        public int soundEffectIdBounce;
        public int subTextureId;
        public int tileBoxWidth;
        public int tileBoxHeight;
        public int pendingSubTexture;
        public int slideInBottomStartY;
        public HangingButton orientationButton;
        public float rotationWholeWord;
        public CGPoint rotationOffset;
        const float kMinHandScale = 0.7f;
        const float kHandInAcc = 0.13f;
        const float kHandInSpeed = 11f;
        const float kHandFallGravity = 0.005f;
        public struct TileBoxInfo{
            public ZAtlas tileBoxAtlas;
            public int tileBoxWidth;
            public int tileBoxHeight;
        };
        public enum Enum {
            kMaxInterpolations = 3,
            kMaxAnimations = 3
        };
        public struct FloatyInfo{
            public float xSpeed;
            public float ySpeed;
            public float xPosition;
            public float yPosition;
            public float xSize;
            public float ySize;
            public float xOffset;
            public float yOffset;
        };
        public struct ZgravityInfo{
            public float gravity;
            public float bounce;
            public float yStartVelocity;
            public float floorLevel;
            public int maxBounces;
            public int numBounces;
            public float yVelocity;
        };
        public struct ZobjectInfo{
            public CGPoint position;
            public Texture2D_Ross texture;
            public ZobjectState startState;
            public bool isMapObject;
            public CGPoint mapScrollPosition;
        };
        public HangingButton OrientationButton
        {
            get;
            set;
        }

        public int SlideInBottomStartY
        {
            get;
            set;
        }

        public FloatyInfo DoFloatyInfo
        {
            get;
            set;
        }

        public float WaitToShow
        {
            get;
			set;
        }

        public float WaitToHide
        {
            get;
            set;
        }

        public ZobjectState State
        {
            get;
            set;
        }

        public float StateTimer
        {
            get;
            set;
        }

        public Texture2D_Ross Texture
        {
            get;
            set;
        }

        public CGPoint MapPosition
        {
            get;
            set;
        }

        public bool IsFloaty
        {
            get;
            set;
        }

        public CGPoint ScreenPosition
        {
            get;
            set;
        }

        public float ThrobSize
        {
            get;
            set;
        }

        public float ThrobTime
        {
            get;
            set;
        }

        public float FlashTime
        {
            get;
            set;
        }

        public ZobjectShowStyle ShowStyle
        {
            get;
            set;
        }

        public float HasSpin
        {
            get;
            set;
        }

        public ZobjectHideStyle HideStyle
        {
            get;
            set;
        }

        public float ShowLagSpeed
        {
            get;
            set;
        }

        public bool StretchToScreen
        {
            get;
            set;
        }

        public float SpinAmount
        {
            get;
            set;
        }

        public CGPoint TargetScreenPosition
        {
            get;
            set;
        }

        public float ShowAlpha
        {
            get;
            set;
        }

        public int SubTextureId
        {
            get;
            set;
        }

        public int SoundEffectIdAppear
        {
            get;
            set;
        }

        public int SoundEffectIdBounce
        {
            get;
            set;
        }

        public ZAtlas Atlas
        {
            get;
            set;
        }

        public bool HorizontallyFlipped
        {
            get;
            set;
        }

        public float Rotation
        {
            get;
            set;
        }

        public CGPoint DisplayPosition
        {
            get;
            set;
        }

        public float DefaultBounce
        {
            get;
            set;
        }

        public float DropInDistance
        {
            get;
            set;
        }

/*        public ZBubble ZBubble
        {
            get;
            set;
        }*/

        public CGPoint StartPosition
        {
            get;
            set;
        }

        public float HideAcc
        {
            get;
            set;
        }

        public float HideStartSpeed
        {
            get;
            set;
        }

//public void SetZBubble(ZBubble inThing) {zBubble = inThing;}////@property(readwrite,assign) ZBubble* zBubble;
public void SetWaitToHide(float inThing) {waitToHide = inThing;}///@property(readwrite,assign) float waitToHide;
//public void SetWaitToShow(float inThing) {waitToShow = inThing;}///@property(readonly) float waitToShow;
public void SetStateTimer(float inThing) {stateTimer = inThing;}///@property(readwrite,assign) float stateTimer;
//public void SetShowScale(float inThing) {showScale = inThing;}///@property(readwrite,assign) float showScale;
public void SetThrobSize(float inThing) {throbSize = inThing;}///@property(readwrite,assign) float throbSize;
public void SetThrobTime(float inThing) {throbTime = inThing;}///@property(readwrite,assign) float throbTime;
public void SetFlashTime(float inThing) {flashTime = inThing;}///@property(readwrite,assign) float flashTime;
public void SetHasSpin(float inThing) {hasSpin = inThing;}///@property(readwrite,assign) float hasSpin;
public void SetRotation(float inThing) {rotation = inThing;}///@property(readwrite,assign) float rotation;
//public void SetShowLagSpeed(float inThing) {showLagSpeed = inThing;}///@property(readwrite,assign) float showLagSpeed;
//public void SetActualDisplayScale(float inThing) {actualDisplayScale = inThing;}///@property(readwrite,assign) float actualDisplayScale;
public void SetState(ZobjectState inThing) {state = inThing;}///@property(readwrite,assign) ZobjectState state;
public void SetMapPosition(CGPoint inThing) {mapPosition = inThing;}///@property(readwrite,assign) CGPoint mapPosition;
public void SetScreenPosition(CGPoint inThing) {screenPosition = inThing;}///@property(readwrite,assign) CGPoint screenPosition;
public void SetTexture(Texture2D_Ross inThing) 
		{	
			texture = inThing;
			if (texture != null)
			{
				this.SetNewTextureDetails();
			}		
		}////@property(readwrite,assign) Texture2D* texture;
public void SetIsFloaty(bool inThing) {isFloaty = inThing;}///@property(readwrite,assign) bool isFloaty;
public void SetFloatyInfo(FloatyInfo inThing) {floatyInfo = inThing;}///@property(readwrite,assign) Zobject.FloatyInfo floatyInfo = new Zobject.FloatyInfo();
//public void SetShowStyle(ZobjectShowStyle inThing) {showStyle = inThing;}///@property(readwrite,assign) ZobjectShowStyle showStyle;
public void SetHideStyle(ZobjectHideStyle inThing) {hideStyle = inThing;}///@property(readwrite,assign) ZobjectHideStyle hideStyle;
public void SetHideStyle(int inThing) {hideStyle = (ZobjectHideStyle)inThing;}///@property(readwrite,assign) ZobjectHideStyle hideStyle;
//public void SetZCol(Constants.RossColour inThing) {zCol = inThing;}///@property(readwrite,assign) RossColour zCol;
public void SetStretchToScreen(bool inThing) {stretchToScreen = inThing;}///@property(readwrite,assign) bool stretchToScreen;
public void SetSpinAmount(float inThing) {spinAmount = inThing;}///@property(readwrite,assign) float spinAmount;
public void SetShowAlpha(float inThing) {showAlpha = inThing;}///@property(readwrite,assign) float showAlpha;
public void SetTargetScreenPosition(CGPoint inThing) {targetScreenPosition = inThing;}///@property(readwrite,assign) CGPoint targetScreenPosition;
public void SetStartPosition(CGPoint inThing) {startPosition = inThing;}///@property(readwrite,assign) CGPoint startPosition;
//public void SetSoundEffectIdAppear(int inThing) {soundEffectIdAppear = inThing;}///@property(readwrite,assign) int soundEffectIdAppear;
public void SetSoundEffectIdBounce(int inThing) {soundEffectIdBounce = inThing;}///@property(readwrite,assign) int soundEffectIdBounce;
public void SetAtlas(ZAtlas inThing) 
		{
			atlas = inThing;
		}////@property(readwrite,assign) ZAtlas* atlas;
public void SetHorizontallyFlipped(bool inThing) {horizontallyFlipped = inThing;}///@property(readwrite,assign) bool horizontallyFlipped;
public void SetDisplayPosition(CGPoint inThing) {displayPosition = inThing;}///@property(readwrite,assign) CGPoint displayPosition;
public void SetDefaultBounce(float inThing) {defaultBounce = inThing;}///@property(readwrite,assign) float defaultBounce;
public void SetDropInDistance(float inThing) {dropInDistance = inThing;}///@property(readwrite,assign) float dropInDistance;
public void SetSlideInBottomStartY(int inThing) {slideInBottomStartY = inThing;}///@property(readwrite,assign) int slideInBottomStartY;
public void SetOrientationButton(HangingButton inThing) {orientationButton = inThing;}////@property(readwrite,assign) HangingButton* orientationButton;
public void SetHideAcc(float inThing) {hideAcc = inThing;}///@property(readwrite,assign) float hideAcc;
public void SetHideStartSpeed(float inThing) {hideStartSpeed = inThing;}///@property(readwrite,assign) float hideStartSpeed;

        public Zobject ()
		{
			//if (!base.init()) return null;
			
						myAtlasBillboard = null;

			
			for (int i = 0; i < (int)Enum.kMaxAnimations; i++)
				animation [i] = null;

			for (int i = 0; i < (int)Enum.kMaxInterpolations; i++) interpolation[i] = null;

            rotationWholeWord = 0.0f;
            orientationButton = null;

            #if USING_IPAD_COORDS

                    slideInBottomStartY = 1360;

            #else

                    slideInBottomStartY = 680;

            #endif
			
			zCol = new Constants.RossColour(0,0,0);
			baseColour = new Constants.RossColour(1,1,1);
			
            soundEffectIdAppear = -1;
            soundEffectIdBounce = -1;
            showScale = 1;
            isFloaty = false;
            state = ZobjectState.kZobjectHidden;
            isLooping = false;
            flashTime = 0.24f;
            throbSize = 0.35f;
            throbTime = 0.23f;
            showStyle = ZobjectShowStyle.kZobjectShow_Zoom;
            hideStyle = ZobjectHideStyle.kZobjectHide_Zoom;
            hasSpin = 0;
            rotation = 0;
            waitToHide = 0;
            waitToShow = 0;
            showLagSpeed = 0.2f;
            zCol.cRed = 1.0f;
            zCol.cGreen = 1.0f;
            zCol.cBlue = 1.0f;
            alpha = 1;
            stretchToScreen = false;
            numInterpolations = 1;
            spinAmount = 10;
            numAnimations = 0;
            currentAnimation = -1;
            showAlpha = 1;
            defaultBounce = 1.0f;
            hasColour = false;
            isTileBox = false;
            atlas = null;
            horizontallyFlipped = false;
            hideAcc = 0.002f;
            hideStartSpeed = 0.025f;
            gravityInfo.yVelocity = 0;
            gravityInfo.bounce = 0.5f;
            gravityInfo.gravity = 0.4f;
            gravityInfo.floorLevel = 300.0f;
            gravityInfo.numBounces = 0;
            gravityInfo.maxBounces = 3;
            gravityOn = false;
            dropInDistance = 100.0f;
            //return this;
        }
		
        public void Dealloc ()
		{
			if (myAtlasBillboard != null)
			{
				myAtlasBillboard.Dealloc();
				myAtlasBillboard = null;
			}	
			
			for (int i = 0; i < (int)Enum.kMaxInterpolations; i++) {
				if (interpolation [i] != null) {
					interpolation [i] = null;
				}

			}

			for (int i = 0; i < (int)Enum.kMaxAnimations; i++) {
                if (animation[i] != null) {
                    animation[i] = null;
                }

            }

        }
		
		//ross makey no thinky
		public void SetPosition(CGPoint newPos) 
		{
			screenPosition = newPos;
			startPosition = newPos;
		}
		
		//This signals that it is an atlas/st type..
		public void SetSubTextureId(int inThing) 
		{
			if (inThing < 0)
			{
				inThing = 0;
			}
			
			subTextureId = inThing;

			Globals.Assert(atlas != null);
			this.SetupAtlasBillboard();
			
			if (atlas.myId == (int)AtlasType.kAtlas_FrontendAndShowlevel)
			{
				myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			}
			
			rotationScale = atlas.GetSubTextureRotationScale(inThing);
		}
		
		public void StopRender()
        {
			if (myAtlasBillboard != null)
			{
				myAtlasBillboard.StopRender();
			}
			
			if (texture != null)
			{
				texture.StopRender();
			}
		}

		public void SetupAtlasBillboard() 
		{
//			Globals.Assert(myAtlasBillboard == null);
			
			if (myAtlasBillboard == null)
			{
				string[] atlasName =  {"kAtlas_RainbowParticles",
        "kAtlas_ParticlesScene",
        "kAtlas_Trees",
        "kAtlas_Footsteps",
        "kAtlas_GrassTiles",
        "kAtlas_GameThingsGrass",
        "kAtlas_Shadows",
        "kAtlas_FlowerHeads",
        "kAtlas_FlowerShadows",
        "kAtlas_GrassSpriteTiles",
        "kAtlas_FontLines",
        "kAtlas_FontColours",
        "kAtlas_InfoBubbles",
        "kAtlas_SceneButtons",
        "kAtlas_MudTiles",
        "kAtlas_MudSpriteTiles",
        "kAtlas_MudTiles3",
        "kAtlas_GameThingsMud",
        "kAtlas_ShadowsFarm",
        "kAtlas_321",
        "kAtlas_Hud",
        "kAtlas_DesertTiles",
        "kAtlas_DesertTiles2",
        "kAtlas_GameThingsGrassDesert",
        "kAtlas_IceTiles",
        "kAtlas_IceTiles2",
        "kAtlas_MoonTiles",
        "kAtlas_GrassCliff",
        "kAtlas_CommonLevelBuilder_Ross",
        "kAtlas_FontNumbers",
        "kAtlas_FontArial",
        "kAtlas_TerrainIcons",
        "kAtlas_IceSprites",
        "kAtlas_Debug",
        "kAtlas_SheepAnims",
        "kAtlas_PiggyAnims",
        "kAtlas_TilesJungle",
        "kAtlas_FrontendAndShowlevel",
        "kAtlas_RaceLose",
        "kAtlas_RaceWin",
        "kAtlas_ShowLevelAndTip",
        "kAtlas_AppleSign",
        "kAtlas_AnotherPiggy",
        "kAtlas_FeelGood"
					
				};
				
				
				myAtlasBillboard = new Billboard("_zobject_forAtlas" + atlasName[atlas.myId]);
			}
			
			myAtlasBillboard.SetAtlas(atlas);
			myAtlasBillboard.SetDetailsFromAtlas(atlas,subTextureId);
//			myAtlasBillboard.SetRenderQueue
		}		
		
        public void SetFloatySpeed(float inSpeed)
        {
            floatyInfo.xSpeed = inSpeed;
            floatyInfo.ySpeed = inSpeed;
        }
		
		public void SetSoundEffectIdAppear(int inId)
		{
			soundEffectIdAppear = inId;
		}
		
		public void SetShowLagSpeed(float inLag)
        {
            showLagSpeed = inLag;
        }
		public void SetShowStyle(ZobjectShowStyle inStyle)
        {
            showStyle = inStyle;
       }
		public void SetShowStyle(int inStyle)
        {
            showStyle = (ZobjectShowStyle)inStyle;
       }

        public void SetFloatySize(float inSize)
        {
            floatyInfo.xSize = inSize;
            floatyInfo.ySize = inSize;
        }

        public void PlayAnimationP1(int which, AnimationStyle inStyle)
        {
            Globals.Assert(which < numAnimations);
            if (inStyle == AnimationStyle.kAnimPlayOnce) (animation[which]).PlayOnce();
            else (animation[which]).PlayLooping();

            currentAnimation = which;
        }

        public int AddAnimation (ZAnimationInfo info)
		{
			Globals.Assert (numAnimations < (int)Enum.kMaxAnimations);
            if (animation[numAnimations] == null) {
                animation[numAnimations] = new Zanimation();
            }

            (animation[numAnimations]).Setup(info);
            numAnimations++;
            return (numAnimations - 1);
        }

        public void SetupShowInterpolation_SpinIn()
        {
            numInterpolations = 3;
            actualDisplayScale = 0;
            alpha = 0;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Lag;
            info.target = InterpolationTarget.kInterp_Scale;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(1)).Setup(info);
            (this.GetInterpolation(1)).SetupLag(showLagSpeed);
            info.type = InterpolationType.kInterp_Lag;
            info.target = InterpolationTarget.kInterp_Spin;
            info.range = InterpolationRange.kInterp_OneToZero;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupLag(showLagSpeed);
            (this.GetInterpolation(0)).SetEndValue(0.999f);
            info.type = InterpolationType.kInterp_Lag;
            info.target = InterpolationTarget.kInterp_Fade;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(2)).Setup(info);
            (this.GetInterpolation(2)).SetupLag(showLagSpeed + 0.1f);
        }

        public ZInterpolation GetInterpolation (int which)
		{
			Globals.Assert (which < (int)Enum.kMaxInterpolations);
            if (interpolation[which] == null) {
                interpolation[which] = new ZInterpolation();
            }

            return interpolation[which];
        }

        public void SetupShowInterpolation_FadeIn()
        {
            numInterpolations = 1;
            actualDisplayScale = showScale;
            alpha = 0;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Lag;
            info.target = InterpolationTarget.kInterp_Fade;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupLag(showLagSpeed);
        }

        public void SetupShowInterpolation_Zoom()
        {
            alpha = 1.0f;
            numInterpolations = 1;
            actualDisplayScale = 0;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Lag;
            info.target = InterpolationTarget.kInterp_Scale;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupLag(showLagSpeed);
        }

        public void SetupShowInterpolation_Boing()
        {
            targetScreenPosition = Utilities.CGPointMake(screenPosition.x, screenPosition.y + 100);
            numInterpolations = 1;
            actualDisplayScale = 1;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Boing;
            info.target = InterpolationTarget.kInterp_Screen;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_None;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupTargetScreenP1(screenPosition, targetScreenPosition);
            (this.GetInterpolation(0)).SetVelocity(0.25f);
        }

        public void SetupShowInterpolation_ZoomAndWobble()
        {
            alpha = 1.0f;
            numInterpolations = 3;
            actualDisplayScale = 0;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Accelerate;
            info.target = InterpolationTarget.kInterp_Scale;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetAcceleration(0.045f);
            info.type = InterpolationType.kInterp_Lag;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            info.target = InterpolationTarget.kInterp_ScaleThrob;
            (this.GetInterpolation(1)).Setup(info);
            (this.GetInterpolation(1)).SetupLag(0.6f);
            info.type = InterpolationType.kInterp_Accelerate;
            info.range = InterpolationRange.kInterp_OneToZero;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(2)).Setup(info);
            (this.GetInterpolation(2)).SetAcceleration(0.08f);
        }

        public void SetupShowInterpolation_SlideIn()
        {
            alpha = 1;
            actualDisplayScale = showScale;
            numInterpolations = 1;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Lag;
            if (isMapObject) info.target = InterpolationTarget.kInterp_Map;
            else info.target = InterpolationTarget.kInterp_Screen;

            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupLag(showLagSpeed);
            CGPoint targetPosition;
            if (isMapObject) targetPosition = mapPosition;
            else targetPosition = screenPosition;

            #if USING_IPAD_COORDS
                const float kOffBehind = 400.0f;
                const float kOffX = 1110.0f;
            #else
                const float kOffBehind = 200.0f;
                const float kOffX = 520.0f;
            #endif

            CGPoint inStartPosition = targetPosition;
            if (showStyle == ZobjectShowStyle.kZobjectShow_SlideInLeft) inStartPosition.x = -kOffBehind;
            else if (showStyle == ZobjectShowStyle.kZobjectShow_SlideInTop) inStartPosition.y = -kOffBehind;
            else if (showStyle ==  ZobjectShowStyle.kZobjectShow_SlideInBottom) inStartPosition.y = (float) slideInBottomStartY;
            else inStartPosition.x = kOffX;

            (this.GetInterpolation(0)).SetupTargetScreenP1(inStartPosition, targetPosition);
        }

        public void SetupHideInterpolation_SpinOut()
        {
            numInterpolations = 3;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Accelerate;
            info.target = InterpolationTarget.kInterp_Scale;
            info.range = InterpolationRange.kInterp_OneToZero;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(1)).Setup(info);
            (this.GetInterpolation(1)).SetupLag(showLagSpeed);
            info.type = InterpolationType.kInterp_Accelerate;
            info.target = InterpolationTarget.kInterp_Spin;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupLag(showLagSpeed);
            (this.GetInterpolation(0)).SetEndValue(0.975f);
            info.type = InterpolationType.kInterp_Accelerate;
            info.target = InterpolationTarget.kInterp_Fade;
            info.range = InterpolationRange.kInterp_OneToZero;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(2)).Setup(info);
            (this.GetInterpolation(2)).SetWaitToBegin(0.019f);
        }

        public void SetupHideInterpolation_FadeOut()
        {
            numInterpolations = 1;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Accelerate;
            info.target = InterpolationTarget.kInterp_Fade;
            info.range = InterpolationRange.kInterp_OneToZero;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupLag(showLagSpeed);
        }

        public void SetupHideInterpolation_Zoom()
        {
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Lag;
            info.target = InterpolationTarget.kInterp_Scale;
            info.range = InterpolationRange.kInterp_OneToZero;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupLag(0.25f);
            (this.GetInterpolation(0)).SetEndValue(0.97f);
        }

        public void SetupHideInterpolation_SlideOut()
        {
            numInterpolations = 1;

            #if USING_IPAD_COORDS
                const float kMoveDistance = 1000.0f;
            #else
                const float kMoveDistance = 500.0f;
            #endif

            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.type = InterpolationType.kInterp_Accelerate;
            info.target = InterpolationTarget.kInterp_Screen;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            CGPoint destination;
            if (hideStyle == ZobjectHideStyle.kZobjectHide_SlideToRight) destination = Utilities.CGPointMake(kMoveDistance, 0);
            else if (hideStyle == ZobjectHideStyle.kZobjectHide_SlideToLeft) destination = Utilities.CGPointMake(-kMoveDistance, 0);
            else if (hideStyle == ZobjectHideStyle.kZobjectHide_SlideToTop) destination = Utilities.CGPointMake(0, -kMoveDistance);
            else if (hideStyle == ZobjectHideStyle.kZobjectHide_SlideToBottom) destination = Utilities.CGPointMake(0, kMoveDistance);
			else destination = Utilities.CGPointMake(0, 0);

            CGPoint target = Utilities.CGPointMake(screenPosition.x + destination.x, screenPosition.y + destination.y);
            (this.GetInterpolation(0)).SetupTargetScreenP1(screenPosition, target);
            (this.GetInterpolation(0)).SetupAccelerateP1(hideAcc, hideStartSpeed);
        }

        public void SetWaitToShow(float newShow)
        {
            waitToShow = newShow;
            this.SetZobjectState( ZobjectState.kZobjectWaitingToShow);
        }

        public void SetupHideInterpolation()
        {
            switch (hideStyle) {
            case ZobjectHideStyle.kZobjectHide_DropOut :
                numInterpolations = 0;
                gravityInfo.floorLevel = 600.0f;
                gravityInfo.yVelocity = 10.0f;
                gravityInfo.gravity = 1.4f;
                break;
            case ZobjectHideStyle.kZobjectHide_DontHide :
                numInterpolations = 0;
                break;
            case ZobjectHideStyle.kZobjectHide_Immediate :
                numInterpolations = 0;
                state = ZobjectState.kZobjectHidden;
                break;
            case ZobjectHideStyle.kZobjectHide_SlideToTop :
            case ZobjectHideStyle.kZobjectHide_SlideToLeft :
            case ZobjectHideStyle.kZobjectHide_SlideToBottom :
            case ZobjectHideStyle.kZobjectHide_SlideToRight :
                this.SetupHideInterpolation_SlideOut();
                break;
            case ZobjectHideStyle.kZobjectHide_Zoom :
                this.SetupHideInterpolation_Zoom();
                break;
            case ZobjectHideStyle.kZobjectHide_FadeOut :
                this.SetupHideInterpolation_FadeOut();
                break;
            case ZobjectHideStyle.kZobjectHide_SpinOut :
                this.SetupHideInterpolation_SpinOut();
                break;
            case ZobjectHideStyle.kZobjectHide_HandStamp :
                break;
            }

            for (int i = 0; i < numInterpolations; i++) (this.GetInterpolation(i)).Start();

        }

        public void SetupShowInterpolation()
        {
            switch (showStyle) {
            case ZobjectShowStyle.kZobjectShow_SlideInLeft :
            case ZobjectShowStyle.kZobjectShow_SlideInTop :
            case ZobjectShowStyle.kZobjectShow_SlideInBottom :
            case ZobjectShowStyle.kZobjectShow_SlideInRight :
                this.SetupShowInterpolation_SlideIn();
                break;
            case ZobjectShowStyle.kZobjectShow_Zoom :
                this.SetupShowInterpolation_Zoom();
                break;
            case ZobjectShowStyle.kZobjectShow_Boing :
                this.SetupShowInterpolation_Boing();
                break;
            case ZobjectShowStyle.kZobjectShow_ZoomAndWobble :
                this.SetupShowInterpolation_ZoomAndWobble();
                break;
            case ZobjectShowStyle.kZobjectShow_FadeIn :
                this.SetupShowInterpolation_FadeIn();
                break;
            case ZobjectShowStyle.kZobjectShow_Immediate :
                numInterpolations = 0;
                alpha = 1.0f;
                state = ZobjectState.kZobjectShown;
                break;
            case ZobjectShowStyle.kZobjectShow_DropIn :
            case ZobjectShowStyle.kZobjectShow_DropInFromBeneath :
                numInterpolations = 0;
                break;
            case ZobjectShowStyle.kZobjectShow_SpinIn :
                this.SetupShowInterpolation_SpinIn();
                break;
            case ZobjectShowStyle.kZobjectShow_HandStamp :
                screenPosition.x = -140;
                targetScreenPosition.x = 100;
                handFallVelocity = 0;
                actualDisplayScale = 1.5f;
                handInVelocity = kHandInSpeed;
                break;
            }

            for (int i = 0; i < numInterpolations; i++) (this.GetInterpolation(i)).Start();

        }

        public CGPoint GetOffsetForWord()
        {
            CGPoint offset = Utilities.CGPointMake(screenPosition.x - startPosition.x, screenPosition.y - startPosition.y);
            return offset;
        }

        public void ShowWithStyle(ZobjectShowStyle inStyle)
        {
            showStyle = inStyle;
            this.Show();
        }

        public void Show()
        {
            if (!isMapObject) {
                screenPosition = startPosition;
            }

            if ((state ==  ZobjectState.kZobjectShown) || (state ==  ZobjectState.kZobjectShowing)) return;

            queuedAction = ZobjectAction.nNone;
            this.SetZobjectState( ZobjectState.kZobjectWaitingToShow);
            this.SetupShowInterpolation();
            //if (zBubble) {
              //  zBubble.Show();
            //}

        }

        public void Disappear()
        {
            if (state ==  ZobjectState.kZobjectHidden) return;

            this.SetZobjectState( ZobjectState.kZobjectHidden);
			
			if (myAtlasBillboard != null)
			{
				myAtlasBillboard.StopRender();
			}
			if (texture != null)
			{
				texture.StopRender();
			}
        }

        public void Hide()
        {
            if ((state ==  ZobjectState.kZobjectHidden) || (state ==  ZobjectState.kZobjectHiding)) return;

            this.SetZobjectState( ZobjectState.kZobjectHiding);
            this.SetupHideInterpolation();
        }

        public void Hide(ZobjectHideStyle inStyle)
        {
            hideStyle = inStyle;
            this.Hide();
        }

        public void QueueActionP1(ZobjectAction nextAction, float delayTime)
        {
            queuedAction = nextAction;
            queuedActionDelay = stateTimer + delayTime;
        }

        public void QueueActionAfterWaitToShowP1(ZobjectAction nextAction, float delayTime)
        {
            delayTime -= waitToShow;
            this.QueueActionP1(nextAction, delayTime);
        }

        public void QueueAction(ZobjectAction nextAction)
        {
            this.QueueActionP1(nextAction, 0);
        }

        public void CheckForQueuedActions()
        {
            if (stateTimer >= queuedActionDelay) {
                if (queuedAction == ZobjectAction.nHide) {
                    this.Hide();
                    queuedAction = ZobjectAction.nNone;
                }
                else if (queuedAction == ZobjectAction.nBounceOnce) {
                    this.BounceOnce(defaultBounce);
                    queuedAction = ZobjectAction.nNone;
                }
                else if (queuedAction == ZobjectAction.nThrobOnce) {
                    this.Throb();
                    queuedAction = ZobjectAction.nNone;
                }
                else if (queuedAction == ZobjectAction.nThrobLooping) {
                    this.ThrobLooping();
                    queuedAction = ZobjectAction.nNone;
                }
                else if (queuedAction == ZobjectAction.nFlash) {
                    this.StartFlashing();
                    queuedAction = ZobjectAction.nNone;
                }
                else if (queuedAction == ZobjectAction.nShowFromHideAndShow) {
                    screenPosition = startPosition;
                    this.Show();
                    stateTimer = waitToShow;
                    queuedAction = ZobjectAction.nNone;
                    if (pendingTexture == null) {
                        this.SetSubTextureId(pendingSubTexture);
                    }
                    else 
					{
                        this.SetTexture(pendingTexture);
                    }

                    if (pendingChangeFunnyWord != null) {
                        pendingChangeFunnyWord.ChangeTextNew(pendingChangeFunnyWordText);
                    }

                }

            }

        }

        public void StartFlashing()
        {
            this.SetZobjectState( ZobjectState.kZobjectFlashing);
            isLooping = true;
            isFlashOn = true;
            flashTime = 0.0f;
        }

        public void StopFlashing()
        {
            this.SetZobjectState( ZobjectState.kZobjectShown);
            zCol.cRed = baseColour.cRed;
            zCol.cGreen = baseColour.cGreen;
            zCol.cBlue = baseColour.cBlue;
        }

        public void ThrobP1(float inSize, float inTime)
        {
            throbTime = inTime;
            throbSize = inSize;
            this.SetZobjectState( ZobjectState.kZobjectThrobbing);
            isLooping = false;
        }

        public void Throb()
        {
            this.SetZobjectState( ZobjectState.kZobjectThrobbing);
            isLooping = false;
        }

        public void ThrobLooping()
        {
            this.SetZobjectState( ZobjectState.kZobjectThrobbing);
            isLooping = true;
        }

        public void RenderToDrawArraysSlice(float sliceAmount)
        {
            if (state ==  ZobjectState.kZobjectHidden) return;

            if (state ==  ZobjectState.kZobjectWaitingToShow) return;

            if (isFloaty) {
                //static float rossyCo = 0.0f;
                //rossyCo += 0.075f;
                displayPosition.x = screenPosition.x + floatyInfo.xOffset;
                displayPosition.y = screenPosition.y + floatyInfo.yOffset;
            }
            else {
                displayPosition = screenPosition;
            }

            (DrawManager.Instance()).AddSliceOfTextureToListP1P2P3(displayPosition, subTextureId, sliceAmount, showScale);
        }

        public void SetAtlasAndSubtextureP1(ZAtlas inAtlas, int inSubTextureId)
        {
            atlas = inAtlas;
            subTextureId = inSubTextureId;

			this.SetupAtlasBillboard();
			
			rotationScale = atlas.GetSubTextureRotationScale(inSubTextureId);
		}

        public void UpdateWordRotation()
        {
            if (orientationButton != null) {
                rotationWholeWord = orientationButton.currentRotation;
            }

            if (rotationWholeWord != 0.0f) {
                CGPoint thing = Utilities.GetVectorFromAngleNew(rotationWholeWord);
                rotationOffset.x = thing.x * 44.0f;
                rotationOffset.y = thing.y * 44.0f;
            }

        }

        public void RenderToDrawArrays()
        {
            if (state ==  ZobjectState.kZobjectHidden) return;

            if (state ==  ZobjectState.kZobjectWaitingToShow) return;

            this.UpdateWordRotation();
            if (isFloaty) {
                //static float rossyCo = 0.0f;
                //rossyCo += 0.075f;
                displayPosition.x = screenPosition.x + floatyInfo.xOffset;
                displayPosition.y = screenPosition.y + floatyInfo.yOffset;
            }
            else {
                displayPosition = screenPosition;
            }

            if (Globals.deviceIPad) {

                #if !MONKEY_PONG
                    displayPosition.x += 32.0f;
                #endif

                if (displayPosition.y < -200.0f) {
                    return;
                }

                if ((displayPosition.x < -200.0f) || (displayPosition.x > 600.0f)) {

                    #if !MONKEY_PONG
                        return;
                    #endif

                }

            }

//            if (zBubble) {
  //              zBubble.RenderP1(displayPosition, actualDisplayScale);
    //            if (!zBubble.Popped()) (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(displayPosition, actualDisplayScale * zBubble.yScale(),
      //            actualDisplayScale * zBubble.xScale(), subTextureId);
        //        else {
                 //   (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(displayPosition, actualDisplayScale, actualDisplayScale, subTextureId);
          //      }

              //  return;
            //}

            if (orientationButton != null) 
			{
                displayPosition.x += rotationOffset.x;
                displayPosition.y += -rotationOffset.y;
                float rts = atlas.GetSubTextureRotationScale(subTextureId);
                float justUseThisScale = 1.0f;
                (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard,displayPosition, justUseThisScale, rotationWholeWord, rts, alpha * showAlpha, subTextureId)
                  ;
            }
            else {
                if (hasColour) {
					
					
					float useAlpha = alpha;
					
					if (state == ZobjectState.kZobjectFlashing)
					{
	                    const float kFlashTime = 0.4f;
	                    float colourVal = 1.3f * (Utilities.GetCosInterpolationP1P2(flashTime, 0.0f, kFlashTime));	
						flashTime += Constants.kFrameRate;
	                    if (flashTime >= kFlashTime) flashTime = 0.0f;	
	                    if (colourVal > 1.0f) colourVal = 1.0f;

						useAlpha = 0.3f + (0.7f * colourVal);
					}					
					
					(DrawManager.Instance()).AddTextureToListWithColourP1P2P3P4(myAtlasBillboard,displayPosition, actualDisplayScale, useAlpha, zCol, subTextureId);
//                        (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard, displayPosition, actualDisplayScale, 0.0f, 0.0f, alpha * showAlpha, subTextureId);

				}
					else {

                    if (horizontallyFlipped) {
                        (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(displayPosition, -actualDisplayScale, actualDisplayScale, subTextureId);
                    }
                    else {
                        (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard, displayPosition, actualDisplayScale, rotation, rotationScale, alpha * showAlpha, subTextureId);
                    }
                }
            }

        }
		
		       public void RenderToDrawArrays_Unity()
        {
       

        }

		
        public void RenderWithoutRendering()
        {
            if (state ==  ZobjectState.kZobjectHidden) return;

            if (state ==  ZobjectState.kZobjectWaitingToShow) return;

            this.UpdateWordRotation();
            if (isFloaty) {
                //static float rossyCo = 0.0f;
                //rossyCo += 0.075f;
                displayPosition.x = screenPosition.x + floatyInfo.xOffset;
                displayPosition.y = screenPosition.y + floatyInfo.yOffset;
            }
            else {
                displayPosition = screenPosition;
            }

            if (Globals.deviceIPad) {

                #if !MONKEY_PONG
                    displayPosition.x += 32.0f;
                #endif

                if (displayPosition.y < -200.0f) {
                    return;
                }

                if ((displayPosition.x < -200.0f) || (displayPosition.x > 600.0f)) {

                    #if !MONKEY_PONG
                        return;
                    #endif

                }

            }

//            if (zBubble) {
  //              zBubble.RenderP1(displayPosition, actualDisplayScale);
    //            if (!zBubble.Popped()) (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(displayPosition, actualDisplayScale * zBubble.yScale(),
      //            actualDisplayScale * zBubble.xScale(), subTextureId);
        //        else {
                 //   (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(displayPosition, actualDisplayScale, actualDisplayScale, subTextureId);
          //      }

                //return;
            //}

            if (orientationButton != null) {
                displayPosition.x += rotationOffset.x;
                displayPosition.y += -rotationOffset.y;
            }
            else {
            }

        }

        public void RenderToDrawArrays_Rotatable()
        {
            if (state ==  ZobjectState.kZobjectHidden) return;

            if (state ==  ZobjectState.kZobjectWaitingToShow) return;

            displayPosition = screenPosition;
            if (Globals.deviceIPad) {
                displayPosition.x += 32.0f;
            }

            float rotationScale = atlas.GetSubTextureRotationScale(subTextureId);
            (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard, displayPosition, actualDisplayScale, rotation, rotationScale, alpha * showAlpha, subTextureId);
            if (Globals.deviceIPad) {
                displayPosition.x -= 32.0f;
            }

        }

        public void RenderFromAtlas()
        {
            if (atlas == null) return;

            (DrawManager.Instance()).Begin(atlas);
            this.RenderToDrawArrays();
            (DrawManager.Instance()).Flush();
        }

        public void SetColour(Constants.RossColour inColour)
        {
            baseColour = inColour;
            zCol = inColour;
            hasColour = true;
        }

        public void SetupTileBox(TileBoxInfo info)
        {
            tileBoxAtlas = info.tileBoxAtlas;
            tileBoxHeight = info.tileBoxHeight;
            tileBoxWidth = info.tileBoxWidth;
            isTileBox = true;
        }

        public void RenderAsTileBox()
        {
            (DrawManager.Instance()).Begin(tileBoxAtlas);
            float useScale = actualDisplayScale * 63.9f;
            for (int y = 0; y < tileBoxHeight; y++) {
                for (int x = 0; x < tileBoxWidth; x++) {
                    float minusX = (tileBoxWidth * 64.0f * actualDisplayScale * 0.5f);
                    minusX -= 32.0f * actualDisplayScale;
                    float minusY = (tileBoxHeight * 64.0f * actualDisplayScale * 0.5f);
                    minusY -= 32.0f * actualDisplayScale;
                    CGPoint topCornerPos = Utilities.CGPointMake(screenPosition.x - minusX, screenPosition.y - minusY);
                    CGPoint pos = Utilities.CGPointMake(((float) x * useScale) + topCornerPos.x, ((float) y * useScale) + topCornerPos.y);
                    float rot = 0;
                    int subtid = 0;
                    if (y == 0) {
                        if (x == (tileBoxWidth - 1)) {
                            rot = -Constants.TWO_PI;
                        }
                        else if (x > 0) {
                            subtid = 1;
                        }

                    }
                    else if (y == (tileBoxHeight - 1)) {
                        if (x == (tileBoxWidth - 1)) {
                            rot = Constants.PI_;
                        }
                        else if (x > 0) {
                            subtid = 1;
                            rot = Constants.PI_;
                        }
                        else {
                            rot = -Constants.TWO_PI * 3.0f;
                        }

                    }
                    else {
                        if (x == (tileBoxWidth - 1)) {
                            subtid = 1;
                            rot = Constants.TWO_PI * 3.0f;
                        }
                        else if (x > 0) {
                            subtid = 2;
                        }
                        else {
                            subtid = 1;
                            rot = Constants.TWO_PI;
                        }

                    }

                    (DrawManager.Instance()).AddRotatedTextureToListP1P2P3(pos, rot, actualDisplayScale * Constants.ROT_SCALE_64x64_20, subtid);
                }

            }

            (DrawManager.Instance()).Flush();
        }

        public void Render()
        {
            if (state ==  ZobjectState.kZobjectHidden) return;

            if (state ==  ZobjectState.kZobjectWaitingToShow) return;

            if (isTileBox) {
                this.RenderAsTileBox();
                return;
            }

            Texture2D_Ross useTexture;
            if (currentAnimation != -1) useTexture = (animation[currentAnimation]).GetTexture();
            else useTexture = texture;

            if (stretchToScreen) {
				if (useTexture != null)
				{
	                useTexture.DrawInRectAlphaP1(myAtlasBillboard,Utilities.GetScreenRectangle(), alpha * showAlpha);
				}
                return;
            }

            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPushMatrix();
            if (isFloaty) {
                displayPosition.x = screenPosition.x + floatyInfo.xOffset;
                displayPosition.y = screenPosition.y + floatyInfo.yOffset;
            }
            else {
                displayPosition = screenPosition;
            }

            #if PLAY_HORIZONTAL
                //glTranslatef(displayPosition.y, displayPosition.x, 0);
            #else
                Globals.g_world.DoGLTranslateP1(displayPosition.x, displayPosition.y);
            #endif

           // if (rotation != 0) //glRotatef(rotation * (360.0 / (Constants.TWO_PI)), 0, 0, 1);
			
			if (useTexture != null)
			{
	            if (horizontallyFlipped) 
					useTexture.DrawAtPointScaledWithColourAlphaP1P2P3(myAtlasBillboard,displayPosition,-actualDisplayScale, actualDisplayScale, rotation, zCol, alpha * showAlpha);
	            else {
	                useTexture.DrawAtPointScaledWithColourAlphaP1P2P3(myAtlasBillboard,displayPosition,actualDisplayScale, actualDisplayScale, rotation,zCol, alpha * showAlpha);
	            }
			}
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPopMatrix();
        }

        public void RenderSimple()
        {
            if (state ==  ZobjectState.kZobjectHidden) return;

            if (state ==  ZobjectState.kZobjectWaitingToShow) return;

            Texture2D_Ross useTexture;
            if (currentAnimation != -1) useTexture = (animation[currentAnimation]).GetTexture();
            else useTexture = texture;

            if (stretchToScreen) {
                useTexture.DrawInRectAlphaP1(Utilities.GetScreenRectangle(), alpha * showAlpha);
                return;
            }

            if (isFloaty) {
                displayPosition.x = screenPosition.x + floatyInfo.xOffset;
                displayPosition.y = screenPosition.y + floatyInfo.yOffset;
            }
            else {
                displayPosition = screenPosition;
            }
			
			if (useTexture == null)
			{
				return;
			}
			
            float widthCheck = (float) useTexture.pixelsWide;
            float heightCheck = (float) useTexture.pixelsHigh;
            if ((Globals.g_world.game).IsOnScreenNewP1P2(displayPosition, widthCheck * 0.5f, heightCheck * 0.5f)) {
                useTexture.DrawAtPointScaleAndRotateP1P2(displayPosition, actualDisplayScale, rotation);
            }

        }

        public void SetZobjectState(ZobjectState inState)
        {
            state = inState;
            stateTimer = 0;
        }

//    public void SetIsBubble(ZBubbleInfo info)
//    //    {
//            if (zBubble == null) {
  //              zBubble = new ZBubble();
    //        }

//            zBubble.Setup(info);
  //      }
	
        public void BounceOnce(float howMuch)
        {
            gravityInfo.yVelocity = 10 * howMuch;
            gravityInfo.bounce = 0.75f;
            gravityInfo.gravity = 1.1f;
            gravityInfo.floorLevel = screenPosition.y;
            gravityInfo.numBounces = 0;
            gravityInfo.maxBounces = 3;
            gravityOn = true;
        }

        public void InitialiseGravity(ZgravityInfo info)
        {
            gravityInfo.yVelocity = info.yStartVelocity;
            gravityInfo.bounce = info.bounce;
            gravityInfo.gravity = info.gravity;
            gravityInfo.floorLevel = info.floorLevel;
            gravityInfo.numBounces = 0;
            if (info.maxBounces > 0) gravityInfo.maxBounces = info.maxBounces;
            else gravityInfo.maxBounces = 3;

        }

        public void CosSlideP1(CGPoint destination, float time)
        {
            numInterpolations = 1;
            ZInterpolation.InterpolationInfo info = new ZInterpolation.InterpolationInfo();
            info.time = time;
            info.range = InterpolationRange.kInterp_ZeroToOne;
            info.type = InterpolationType.kInterp_Cos;
            info.target = InterpolationTarget.kInterp_Screen;
            info.endParameter = InterpolationEndParameter.kInterpEnd_Value;
            (this.GetInterpolation(0)).Setup(info);
            (this.GetInterpolation(0)).SetupTargetScreenP1(screenPosition, destination);
            (this.GetInterpolation(0)).Start();
            this.SetZobjectState( ZobjectState.kZobjectMoving);
        }

        public bool UpdateInterpolation(ZInterpolation inInterp)
        {
            bool finished = inInterp.Update();
            if (inInterp.target == InterpolationTarget.kInterp_Screen) {
                screenPosition = inInterp.GetPosition();
            }
            else if (inInterp.target == InterpolationTarget.kInterp_Map) {
                mapPosition = inInterp.GetPosition();
            }
            else if (inInterp.target == InterpolationTarget.kInterp_Scale) {
                actualDisplayScale = showScale * inInterp.GetValue();
            }
            else if (inInterp.target == InterpolationTarget.kInterp_ScaleThrob) {
                actualDisplayScale = showScale + (0.15f * showScale * inInterp.GetValue());
            }
            else if (inInterp.target == InterpolationTarget.kInterp_Fade) {
                alpha = inInterp.GetValue();
            }
            else if (inInterp.target == InterpolationTarget.kInterp_Spin) {
                rotation = (-spinAmount * (1.0f - inInterp.endValue)) + spinAmount * inInterp.GetValue();
            }

            return finished;
        }

        public void UpdateFloating()
        {
            if ((state !=  ZobjectState.kZobjectShown) && (showStyle != ZobjectShowStyle.kZobjectShow_Zoom)) return;

            floatyInfo.xPosition += floatyInfo.xSpeed;
            floatyInfo.yPosition += floatyInfo.ySpeed;
            if (floatyInfo.xPosition >= Constants.PI_) {
                floatyInfo.xPosition -= (2 * Constants.PI_);
            }

            if (floatyInfo.yPosition >= Constants.PI_) {
                floatyInfo.yPosition -= (2 * Constants.PI_);
            }

            floatyInfo.xOffset = (float)Math.Cos(floatyInfo.xPosition) * floatyInfo.xSize;
            floatyInfo.yOffset = (float)Math.Cos(floatyInfo.yPosition) * floatyInfo.ySize;
        }

        public void ActivateGravity()
        {
            gravityInfo.numBounces = 0;
            gravityOn = true;
        }

        public void UpdateGravity()
        {
            gravityInfo.yVelocity -= gravityInfo.gravity;
            CGPoint usePosition;
            if (isMapObject) usePosition = mapPosition;
            else usePosition = screenPosition;

            usePosition.y -= gravityInfo.yVelocity;
            bool hasBounced = false;
            if (gravityInfo.gravity > 0.0f) {
                if (usePosition.y >= gravityInfo.floorLevel) {
                    hasBounced = true;
                }

            }
            else {
                if (usePosition.y <= gravityInfo.floorLevel) {
                    hasBounced = true;
                }

            }

            if (hasBounced) {
                if (soundEffectIdBounce != -1) {
                    float volume = ((float)(gravityInfo.maxBounces - gravityInfo.numBounces)) / ((float) gravityInfo.maxBounces);
                    (SoundEngine.Instance()).PlayFinchSoundP1(soundEffectIdBounce, volume);
                }

                gravityInfo.yVelocity = -(gravityInfo.yVelocity*gravityInfo.bounce);
                usePosition.y = gravityInfo.floorLevel;
                gravityInfo.numBounces++;
                if (gravityInfo.numBounces > (gravityInfo.maxBounces - 1)) {
                    gravityOn = false;
                }

            }

            if (isMapObject) mapPosition = usePosition;
            else screenPosition = usePosition;

        }

        public float GetShowScale()
        {
            return showScale;
        }

        public void SetShowScale(float newScale)
        {
            showScale = newScale;
            actualDisplayScale = newScale;
        }

        public void UpdateAnimation ()
		{
			Globals.Assert (currentAnimation < (int)Enum.kMaxAnimations);
            if ((animation[currentAnimation]).Update()) subTextureId = (animation[currentAnimation]).GetSubTextureId();

        }

        public void Update()
        {
            stateTimer += Constants.kFrameRate;
            if (state ==  ZobjectState.kZobjectHidden) return;

            if ((gravityOn) && (state !=  ZobjectState.kZobjectHidden)) this.UpdateGravity();

            if (isFloaty) this.UpdateFloating();

            if (currentAnimation != -1) this.UpdateAnimation();

            if (hasSpin != 0) {
                rotation += hasSpin;
                if (rotation >= (Constants.TWO_PI)) rotation -= Constants.TWO_PI;

            }

            switch (state) {
            case ZobjectState.kZobjectMoving :
                for (int i = 0; i < numInterpolations; i++) {
                    if (this.UpdateInterpolation(this.GetInterpolation(i))) {
                        if (i == 0) this.SetZobjectState( ZobjectState.kZobjectShown);

                    }

                }

                break;
            case ZobjectState.kZobjectWaitingToShow :
                if (stateTimer >= waitToShow) {
                    this.SetZobjectState( ZobjectState.kZobjectShowing);
                    this.Update();
                    if (soundEffectIdAppear != -1) {
                        (SoundEngine.Instance()).QueueFinchSoundP1(soundEffectIdAppear, 0.1f);
                    }

                }

                break;
            case ZobjectState.kZobjectShowing :
                {
                    if (showStyle == ZobjectShowStyle.kZobjectShow_HandStamp) {
                        screenPosition.x += handInVelocity;
                        handInVelocity -= kHandInAcc;
                        actualDisplayScale -= handFallVelocity;
                        handFallVelocity += kHandFallGravity;
                        if (actualDisplayScale <= kMinHandScale) {
                            actualDisplayScale = kMinHandScale;
                            this.SetZobjectState( ZobjectState.kZobjectShown);
                        }

                    }
                    else if (showStyle == ZobjectShowStyle.kZobjectShow_DropIn) {
                        this.SetZobjectState( ZobjectState.kZobjectShown);
                        screenPosition.y = -50;
                        this.ActivateGravity();
                    }
                    else if (showStyle == ZobjectShowStyle.kZobjectShow_DropInFromBeneath) {
                        this.SetZobjectState( ZobjectState.kZobjectShown);
                        screenPosition.y = screenPosition.y + dropInDistance;
                        this.ActivateGravity();
                    }
                    else if (showStyle == ZobjectShowStyle.kZobjectShow_ZoomAndWobble) {
                        if (!(this.GetInterpolation(0)).active) {
                            if (!(this.GetInterpolation(1)).active) {
                                if (this.UpdateInterpolation(this.GetInterpolation(2))) {
                                    this.SetZobjectState( ZobjectState.kZobjectShown);
                                    actualDisplayScale = showScale;
                                }

                            }
                            else {
                                this.UpdateInterpolation(this.GetInterpolation(1));
                            }

                        }
                        else {
                            if (this.UpdateInterpolation(this.GetInterpolation(0))) {
                            }

                        }

                    }
                    else {
                        for (int i = 0; i < numInterpolations; i++) {
                            if (this.UpdateInterpolation(this.GetInterpolation(i))) {
                                if (i == 0) this.SetZobjectState( ZobjectState.kZobjectShown);

                            }

                        }

                    }

                }
                break;
            case ZobjectState.kZobjectHiding :
                if (stateTimer >= waitToHide) 
				{
                    if (hideStyle == ZobjectHideStyle.kZobjectHide_HandStamp) {
                        screenPosition.x -= handInVelocity;
                        handInVelocity += kHandInAcc;
                        actualDisplayScale += handFallVelocity;
                        handFallVelocity -= kHandFallGravity;
                        if (handFallVelocity <= 0) {
                            this.SetZobjectState( ZobjectState.kZobjectHidden);
                        }

                    }
                    else if (hideStyle == ZobjectHideStyle.kZobjectHide_DropOut) {
                        if (!gravityOn) {
                            this.ActivateGravity();
                        }

                        if (screenPosition.y > 550.0f) {
                            this.SetZobjectState( ZobjectState.kZobjectHidden);
                        }

                    }
                    else {
                        for (int i = 0; i < numInterpolations; i++) {
                            if (this.UpdateInterpolation(this.GetInterpolation(i))) {
                                this.SetZobjectState( ZobjectState.kZobjectHidden);
                                this.CheckForQueuedActions();
                            }

                        }

                    }
					
					if (myAtlasBillboard != null)
					{
						myAtlasBillboard.StopRender();
					}
					if (texture != null)
					{
						texture.StopRender();
					}

                }

                break;
            case ZobjectState.kZobjectShown :
                {
                    this.CheckForQueuedActions();
                }
                break;
            case ZobjectState.kZobjectThrobbing :
                {
                    actualDisplayScale = showScale + Utilities.GetCosInterpolationP1P2(stateTimer, 0, throbTime) * throbSize;
                    if (isLooping) {
                        if (stateTimer >= throbTime) {
                            stateTimer = 0;
                        }

                    }
                    else {
                        if (stateTimer > (throbTime + 0.16)) {
                            this.SetZobjectState( ZobjectState.kZobjectShown);
                        }

                    }

                }
                break;
            case ZobjectState.kZobjectFlashing :
                {
				
/*					Constants.RossColour betweenColour = new Constants.RossColour(0,0,0);
				//	Constants.RossColour slightlyLighterBlue = new Constants.RossColour(0.17f * 1.5f, 0.4f * 1.5f, 0.6f * 1.5f);
					
					betweenColour = Utilities.GetColourBetweenP1P2(colourVal,baseColour,Constants.kColourWhite);
				
                    zCol.cRed = betweenColour.cRed;
                    zCol.cGreen = betweenColour.cGreen;
                    zCol.cBlue = betweenColour.cBlue;
				*/
				
//				alpha
				}
                break;
            default :
                {
                }
                break;
            }

        }

        public void HideAndShowP1(Texture2D_Ross inNewStexture, int inNewSubTextureId)
        {
            this.Hide();
            pendingSubTexture = inNewSubTextureId;
            pendingTexture = inNewStexture;
            this.QueueAction( ZobjectAction.nShowFromHideAndShow);
            pendingChangeFunnyWord = null;
        }

        public void SetupTextChangeForHideAndShowP1(string newText, FunnyWord inFunnyWord)
        {
            pendingChangeFunnyWord = inFunnyWord;
			pendingChangeFunnyWordText = newText;//.Copy();
        }

        public void SetGravityFloorLevel(float inLevel)
        {
            gravityInfo.floorLevel = inLevel;
        }

        public void UpdateMapPosition(CGPoint inScrollPos)
        {
            Globals.Assert(isMapObject);
            screenPosition = Utilities.GetScreenPositionP1(mapPosition, inScrollPos);
        }
		
		public void SetNewTextureDetails()
		{
			myAtlasBillboard.SetTexture2D(texture);
			
//			myAtlasBillboard.CopyMaterial(texture.myBillboard.GetMaterial());			
//		    myAtlasBillboard.rotationScale = 0.5f * Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), Utilities.CGPointMake(myAtlasBillboard.height,myAtlasBillboard.width));
		    float thing = myAtlasBillboard.height / myAtlasBillboard.width;
		    myAtlasBillboard.rotationAngle1 = Constants.HALF_PI - (float)Math.Atan(thing);
		    myAtlasBillboard.rotationAngle2 = Constants.PI_ - (myAtlasBillboard.rotationAngle1 * 2.0f);							
		}
		
        public void Initialise(ZobjectInfo zobInfo)
        {
			rotationScale = 0.0f;
//			myAtlasBillboard = null;
            texture = zobInfo.texture;
            isMapObject = zobInfo.isMapObject;
            if (isMapObject) {
                mapPosition = zobInfo.position;
                screenPosition = Utilities.GetScreenPositionP1(mapPosition, zobInfo.mapScrollPosition);
            }
            else {
                screenPosition.x = zobInfo.position.x;
                screenPosition.y = zobInfo.position.y;
            }
			
			if (texture != null)
			{
				//hmmm one of these...
				
				if (myAtlasBillboard == null)
				{
					myAtlasBillboard = new Billboard("zobject_hmmm");
				}
				
				this.SetNewTextureDetails();
			}
			
            startPosition = screenPosition;
            queuedAction = ZobjectAction.nNone;
            gravityOn = false;
            this.SetZobjectState(zobInfo.startState);
            if (zobInfo.startState == ZobjectState.kZobjectShown) {
                alpha = 1.0f;
            }

            actualDisplayScale = 1;
        }

    }
}
