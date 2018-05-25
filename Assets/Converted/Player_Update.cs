using System;

namespace Default.Namespace
{	
	public partial class Player
    {
        public float XScrollLook
        {
            get;
            set;
        }

        public RacingBrain RacingBrain
        {
            get;
            
            set;
        }

        public float LastRockSoundTime
        {
            get;
            set;
        }

        public float LastOvertakeSoundTime
        {
            get;
            set;
        }

        public bool HasPassedFinishLine
        {
            get;
            set;
        }

        public int InRiver
        {
            get;
            set;
        }

        public int InWaterfall
        {
            get;
            set;
        }

        public int OnBridge
        {
            get;
            set;
        }

        public int XCurrentTile
        {
            get;
            set;
        }

        public int YCurrentTile
        {
            get;
            set;
        }

        public PlayerState State
        {
            get;
            set;
        }

        public CGPoint Position
        {
            get;
            set;
        }

        public int SplashingEffectId
        {
            get;
            set;
        }

        public float DistanceLastFrame
        {
            get;
            set;
        }

        public int MoveAnim
        {
            get;
            set;
        }

        public int RotateAnim
        {
            get;
            set;
        }

        public int WhichStep
        {
            get;
            set;
        }

        public float InCowPatTimer
        {
            get;
            set;
        }

        public float PositionZ
        {
            get;
            set;
        }

        public float PrevPositionZ
        {
            get;
            set;
        }

        public float MoveAngle
        {
            get;
            set;
        }

        public float PrevMoveAngle
        {
            get;
            set;
        }

        public float FoamyRatio
        {
            get;
            set;
        }

        public int InPond
        {
            get;
            set;
        }

        public int InHayStack
        {
            get;
            set;
        }

        public int OnRoof
        {
            get;
            set;
        }

        public int OnCliff
        {
            get;
            set;
        }

        public float DistanceTravelled
        {
            get;
            set;
        }

        public int OnRamp
        {
            get;
            set;
        }

        public int InVenus
        {
            get;
            set;
        }

        public int OnLog
        {
            get;
            set;
        }

        public bool IsLeftCliff
        {
            get;
            set;
        }

        public float PlayerDisplayAngle
        {
            get;
            set;
        }

        public PlayerControlType ControlType
        {
            get;
            set;
        }

        public NoGoZone NoGoZone
        {
            get;
            set;
        }

        public float BaseScale
        {
            get;
            set;
        }

        public int NumBounces
        {
            get;
            set;
        }

        public int PlayerId
        {
            get;
            set;
        }

        public bool IsOverRiver
        {
            get;
            set;
        }

//        public bool InMud
  //      {
    //        get;
      //      set;
        //}

        public bool AboveRoof
        {
            get;
            set;
        }

        public float ZVelocity
        {
            get;
            set;
        }

        public HumanControlType HumanControlType
        {
            get;
            set;
        }

        public float TemporaryShadowLengthener
        {
            get;
            set;
        }

        public bool DirectionButtonLeft
        {
            get;
            set;
        }

        public bool DirectionButtonRight
        {
            get;
            set;
        }

        public int FinishPosition
        {
            get;
            set;
        }

        public float FinishTime
        {
            get;
            set;
        }

        public float PowerSkidYLess
        {
            get;
            set;
        }

        public CGPoint SynthesizedTilt
        {
            get;
            set;
        }

        public bool IsOnScreen
        {
            get;
            set;
        }

        public bool HitWaterInWaterfall
        {
            get;
            set;
        }

        public bool DisableSpriteTiles
        {
            get;
            set;
        }

        public bool JumpCelebrateCancelled
        {
            get;
            set;
        }

        public float KFinalSpeedMultiplier
        {
            get;
            set;
        }

        public float WhiteStarSpeedAddition
        {
            get;
            set;
        }

        public bool IsInFinalThird
        {
            get;
            set;
        }

        public CGPoint BumpTilt
        {
            get;
            set;
        }

        public int NumRainbowBoosts
        {
            get;
            set;
        }

        public int NumHitAppleTrees
        {
            get;
            set;
        }

        public bool HitFlowers
        {
            get;
            set;
        }

        public bool HitHouse
        {
            get;
            set;
        }

        public bool HitMud
        {
            get;
            set;
        }

        public bool HitFlock
        {
            get;
            set;
        }

        public bool HitHedge
        {
            get;
            set;
        }

        public bool HitVeg
        {
            get;
            set;
        }

        public bool DoHitTree
        {
            get;
            set;
        }

        public bool GotWet
        {
            get;
            set;
        }

        public bool HitBarrel
        {
            get;
            set;
        }

//public void SetSpeedTrail(SpeedTrail inThing) {speedTrail = inThing;}////@property(readwrite,assign) SpeedTrail* speedTrail;
public void SetXScrollLook(float inThing) {xScrollLook = inThing;}///@property(readwrite,assign) float xScrollLook;
//public void SetInWaterfall(int inThing) {inWaterfall = inThing;}///@property(readwrite,assign) int inWaterfall;
//public void SetInRiver(int inThing) {inRiver = inThing;}///@property(readwrite,assign) int inRiver;
public void SetOnBridge(int inThing) {onBridge = inThing;}///@property(readwrite,assign) int onBridge;
public void SetXCurrentTile(int inThing) {xCurrentTile = inThing;}///@property(readwrite,assign) int xCurrentTile;
public void SetYCurrentTile(int inThing) {yCurrentTile = inThing;}///@property(readwrite,assign) int yCurrentTile;
public void SetSplashingEffectId(int inThing) {splashingEffectId = inThing;}///@property(readwrite,assign) int splashingEffectId;
public void SetState(PlayerState inThing) {state = inThing;}///@property(readwrite,assign) PlayerState state;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
//public void SetSpeed(CGPoint inThing) {speed = inThing;}///@property(readwrite,assign) CGPoint speed;
public void SetDistanceLastFrame(float inThing) {distanceLastFrame = inThing;}///@property(readwrite,assign) float distanceLastFrame;
public void SetInCowPatTimer(float inThing) {inCowPatTimer = inThing;}///@property(readwrite,assign) float inCowPatTimer;
public void SetMoveAnim(int inThing) {moveAnim = inThing;}///@property(readwrite,assign) int moveAnim;
public void SetRotateAnim(int inThing) {rotateAnim = inThing;}///@property(readwrite,assign) int rotateAnim;
public void SetWhichStep(int inThing) {whichStep = inThing;}///@property(readwrite,assign) int whichStep;
public void SetPositionZ(float inThing) {positionZ = inThing;}///@property(readwrite,assign) float positionZ;
public void SetPrevPositionZ(float inThing) {prevPositionZ = inThing;}///@property(readwrite,assign) float prevPositionZ;
public void SetMoveAngle(float inThing) {moveAngle = inThing;}///@property(readwrite,assign) float moveAngle;
public void SetPrevMoveAngle(float inThing) {prevMoveAngle = inThing;}///@property(readwrite,assign) float prevMoveAngle;
public void SetPlayerDisplayAngle(float inThing) {playerDisplayAngle = inThing;}///@property(readwrite,assign) float playerDisplayAngle;
public void SetFoamyRatio(float inThing) {foamyRatio = inThing;}///@property(readwrite,assign) float foamyRatio;
public void SetInPond(int inThing) {inPond = inThing;}///@property(readwrite,assign) int inPond;
public void SetInHayStack(int inThing) {inHayStack = inThing;}///@property(readwrite,assign) int inHayStack;
public void SetOnRoof(int inThing) {onRoof = inThing;}///@property(readwrite,assign) int onRoof;
public void SetOnCliff(int inThing) {onCliff = inThing;}///@property(readwrite,assign) int onCliff;
public void SetOnRamp(int inThing) {onRamp = inThing;}///@property(readwrite,assign) int onRamp;
//public void SetInVenus(int inThing) {inVenus = inThing;}///@property(readwrite,assign) int inVenus;
//public void SetOnLog(int inThing) {onLog = inThing;}///@property(readwrite,assign) int onLog;
public void SetDistanceTravelled(float inThing) {distanceTravelled = inThing;}///@property(readwrite,assign) float distanceTravelled;
public void SetControlType(PlayerControlType inThing) {controlType = inThing;}///@property(readwrite,assign) PlayerControlType controlType;
public void SetHumanControlType(HumanControlType inThing) {humanControlType = inThing;}///@property(readwrite,assign) HumanControlType humanControlType;
public void SetNoGoZone(NoGoZone inThing) {noGoZone = inThing;}////@property(readwrite,assign) NoGoZone* noGoZone;
public void SetPlayerType(int inThing) {playerType = inThing;}///@property(readwrite,assign) int playerType;
public void SetBaseScale(float inThing) {baseScale = inThing;}///@property(readwrite,assign) float baseScale;
public void SetNumBounces(int inThing) {numBounces = inThing;}///@property(readwrite,assign) int numBounces;
//public void SetPlayerId(int inThing) {playerId = inThing;}///@property(readwrite,assign) int playerId;
public void SetHasPassedFinishLine(bool inThing) {hasPassedFinishLine = inThing;}///@property(readwrite,assign) bool hasPassedFinishLine;
public void SetIsOverRiver(bool inThing) {isOverRiver = inThing;}///@property(readwrite,assign) bool isOverRiver;
public void SetIsLeftCliff(bool inThing) {isLeftCliff = inThing;}///@property(readwrite,assign) bool isLeftCliff;
public void SetLastRockSoundTime(float inThing) {lastRockSoundTime = inThing;}///@property(readwrite,assign) float lastRockSoundTime;
public void SetLastOvertakeSoundTime(float inThing) {lastOvertakeSoundTime = inThing;}///@property(readwrite,assign) float lastOvertakeSoundTime;
public void SetTemporaryShadowLengthener(float inThing) {temporaryShadowLengthener = inThing;}///@property(readwrite,assign) float temporaryShadowLengthener;
//public void SetInMud(bool inThing) {inMud = inThing;}///@property(readwrite,assign) bool inMud;
public void SetZVelocity(float inThing) {zVelocity = inThing;}///@property(readwrite,assign) float zVelocity;
public void SetAboveRoof(bool inThing) {aboveRoof = inThing;}///@property(readwrite,assign) bool aboveRoof;
public void SetDisableSpriteTiles(bool inThing) {disableSpriteTiles = inThing;}///@property(readwrite,assign) bool disableSpriteTiles;
public void SetDirectionButtonLeft(bool inThing) {directionButtonLeft = inThing;}///@property(readwrite,assign) bool directionButtonLeft;
public void SetDirectionButtonRight(bool inThing) {directionButtonRight = inThing;}///@property(readwrite,assign) bool directionButtonRight;
public void SetFinishPosition(int inThing) {finishPosition = inThing;}///@property(readwrite,assign) int finishPosition;
public void SetFinishTime(float inThing) {finishTime = inThing;}///@property(readwrite,assign) float finishTime;
public void SetPowerSkidYLess(float inThing) {powerSkidYLess = inThing;}///@property(readwrite,assign) float powerSkidYLess;
public void SetSynthesizedTilt(CGPoint inThing) {synthesizedTilt = inThing;}///@property(readwrite,assign) CGPoint synthesizedTilt;
public void SetIsOnScreen(bool inThing) 
		{
			isOnScreen = inThing;
		
			if (!isOnScreen)
			{
				this.StopRender();
			}
		}///@property(readwrite,assign) bool isOnScreen;
public void SetRacingBrain(RacingBrain inThing) {racingBrain = inThing;}////@property(readwrite,assign) RacingBrain* racingBrain;
public void SetHitWaterInWaterfall(bool inThing) {hitWaterInWaterfall = inThing;}///@property(readwrite,assign) bool hitWaterInWaterfall;
public void SetJumpCelebrateCancelled(bool inThing) {jumpCelebrateCancelled = inThing;}///@property(readwrite,assign) bool jumpCelebrateCancelled;
public void SetIsInFinalThird(bool inThing) {isInFinalThird = inThing;}///@property(readwrite,assign) bool isInFinalThird;
public void SetKFinalSpeedMultiplier(float inThing) {kFinalSpeedMultiplier = inThing;}///@property(readwrite,assign) float kFinalSpeedMultiplier;
public void SetWhiteStarSpeedAddition(float inThing) {whiteStarSpeedAddition = inThing;}///@property(readwrite,assign) float whiteStarSpeedAddition;
public void SetBumpTilt(CGPoint inThing) {bumpTilt = inThing;}///@property(readwrite,assign) CGPoint bumpTilt;
public void SetNumRainbowBoosts(int inThing) {numRainbowBoosts = inThing;}///@property(readwrite,assign) int numRainbowBoosts;
public void SetNumHitAppleTrees(int inThing) {numHitAppleTrees = inThing;}///@property(readwrite,assign) int numHitAppleTrees;
public void SetHitFlowers(bool inThing) {hitFlowers = inThing;}///@property(readwrite,assign) bool hitFlowers;
public void SetHitHouse(bool  inThing) {hitHouse = inThing;}///@property(readwrite,assign) bool  hitHouse;
public void SetHitMud(bool  inThing) {hitMud = inThing;}///@property(readwrite,assign) bool  hitMud;
public void SetHitFlock(bool  inThing) {hitFlock = inThing;}///@property(readwrite,assign) bool  hitFlock;
public void SetHitHedge(bool  inThing) {hitHedge = inThing;}///@property(readwrite,assign) bool  hitHedge;
public void SetHitVeg(bool  inThing) {hitVeg = inThing;}///@property(readwrite,assign) bool  hitVeg;
public void SetHitTree(bool  inThing) {hitTree = inThing;}///@property(readwrite,assign) bool  hitTree;
public void SetHitBarrel(bool  inThing) {hitBarrel = inThing;}///@property(readwrite,assign) bool  hitBarrel;
public void SetGotWet(bool  inThing) {gotWet = inThing;}///@property(readwrite,assign) bool  gotWet;

		
		//Player_Update
		
		    public void UpdatePostRaceCelebration()
    {
        if (finishPosition != -1) {
            if (!jumpCelebrateCancelled) {
                if (state != PlayerState.kPlayerMoving_InAir) {
                    if (controlType == PlayerControlType.kControlAI) {
                        distanceLastFrame = Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), speed);
                    }

                    if (this.GetDistanceLastFrame() < 2.0f) {
                        if (stateTimer > 0.1f) {
                            kJumpGravity = 1.0f;
                            zVelocity = 6.0f;
                        }

                    }

                }

            }

        }

    }

    public void UpdateTrick()
    {
        if (playerType != (int) PlayerType.kPlayerSheep) return;

        switch (trickInfo.trickState) {
        case TrickState.e_WaitingToStart :
            if (stateTimer >= trickInfo.timeToStartNextPhase) {
                trickInfo.trickState = TrickState.e_Starting;
                if (trickInfo.trickAnim == null) {
                    trickInfo.trickAnim = new Zanimation();// [[Zanimation alloc] init];
                }

                ZAnimationInfo info = new ZAnimationInfo();
                info.numFrames = 2;
                info.frameTime[0] = 0.05f;
                info.frameTime[1] = 0.05f;
                info.subTextureId[0] = kStartTrickSubtextures + (trickInfo.whichTrick * 4);
                info.subTextureId[1] = kStartTrickSubtextures + 1 + (trickInfo.whichTrick * 4);
                info.gapType = GapType.kAnimGapTime;
                (trickInfo.trickAnim).Setup(info);
                (trickInfo.trickAnim).PlayOnce();
            }

            break;
        case TrickState.e_Starting :
            (trickInfo.trickAnim).Update();
            if ((trickInfo.trickAnim).state == AnimationState.kAnimFinished) {
                if (trickInfo.whichTrick == 0) {
                    (Globals.g_world.audio).PlayRandomShaunJump();
                }
                else {
                    (Globals.g_world.audio).PlayRandomShaunLaugh();
                }

                trickInfo.trickState = TrickState.e_Holding;
                trickInfo.timeToStartNextPhase = stateTimer + trickInfo.holdTime;
                ZAnimationInfo info = new ZAnimationInfo();
                info.numFrames = 2;
                info.frameTime[0] = 0.05f;
                info.frameTime[1] = 0.05f;
                info.subTextureId[0] = kStartTrickSubtextures + 2 + (trickInfo.whichTrick * 4);
                info.subTextureId[1] = kStartTrickSubtextures + 3 + (trickInfo.whichTrick * 4);
                info.gapType = GapType.kAnimGapTime;
                (trickInfo.trickAnim).Setup(info);
                (trickInfo.trickAnim).PlayLooping();
            }

            break;
        case TrickState.e_Holding :
            (trickInfo.trickAnim).Update();
            if (stateTimer >= trickInfo.timeToStartNextPhase) {
                trickInfo.trickState = TrickState.e_Finishing;
                ZAnimationInfo info = new ZAnimationInfo();
                info.numFrames = 2;
                info.frameTime[0] = 0.05f;
                info.frameTime[1] = 0.05f;
                info.subTextureId[0] = kStartTrickSubtextures + 1 + (trickInfo.whichTrick * 4);
                info.subTextureId[1] = kStartTrickSubtextures + (trickInfo.whichTrick * 4);
                info.gapType = GapType.kAnimGapTime;
                (trickInfo.trickAnim).Setup(info);
                (trickInfo.trickAnim).PlayOnce();
            }

            break;
        case TrickState.e_Finishing :
            (trickInfo.trickAnim).Update();
            if ((trickInfo.trickAnim).state == AnimationState.kAnimFinished) {
                controlFaceAngle = false;
                trickInfo.trickState = TrickState.e_NoTrick;
            }

            break;
        default :
            break;
        }

    }

    public void UpdateOnOrAboveRoof()
    {
        if (this == (Globals.g_world.game).player) {
            timeOnRoof += Constants.kFrameRate;
            if (timeOnRoof > 0.5f) {
                ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_RoofRunner);
                ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
                timeOnRoof = 0.0f;
            }

        }

    }

    public void UpdateOnRoad()
    {
        if (onRoad) {
            if ((currentTileIdObject != (int) ObjectType.kOT_Road) && (currentTileIdObject != (int) ObjectType.kOT_RoadCrossing)) {
                onRoad = false;
            }

        }
        else {
            if ((currentTileIdObject == (int) ObjectType.kOT_Road) || (currentTileIdObject == (int) ObjectType.kOT_RoadCrossing)) {
                onRoad = true;
            }

        }

    }

    public void Update()
    {
        Globals.Assert(controlType == PlayerControlType.kControlHuman);
        stateTimer += Constants.kFrameRate;
        switch (state) {
        case PlayerState.kPlayerMoving_CrashingThroughHedge :
            this.UpdateCrashingThroughHedge();
            break;
        default :
            break;
        }

        this.UpdatePostRaceCelebration();
        this.UpdateTiltValues();
        this.UpdateSpeedY();
        this.UpdateSpeedX();
        this.UpdateSlowDownHay();
        this.UpdateCowPat();
        this.UpdatePlayerPosition();
        this.UpdateHoofBeats();
        this.UpdateGroundLevelJump();
        this.UpdateCurrentTile();
        this.UpdateOnRoad();
        this.UpdateMoveAnim();
        this.UpdateDustCloud(this.GetDistanceLastFrame());
        this.SetScreenPos();
        this.UpdateRotateAnim();
        this.UpdateTracks();
        prevGroundLevel = groundLevel;
    }

    public void UpdateGhostValues(Ghost ghost)
    {
        prevPlayerPosition = position;
        
		Ghost.GhostFrameData frameData = new Ghost.GhostFrameData();

		frameData = ghost.GetFrameData(ghost.ghostCurrentFrame);
        position = Utilities.CGPointMake(frameData.x, frameData.y);
        rotateAnim = frameData.rotation;
        moveAnim = frameData.anim;
        positionZ = frameData.positionZ;
        speed.x = position.x - prevPlayerPosition.x;
        speed.y = position.y - prevPlayerPosition.y;
    }

    public void EndGetReady()
    {
        trickInfo.trickState = TrickState.e_NoTrick;
    }

    public void UpdateGetReady(float gameStateTimer)
    {
        if (trickInfo.trickState == TrickState.e_NoTrick) {
            if ((gameStateTimer < 2.0f) && (gameStateTimer >= trickInfo.timeToStartNextPhase)) {
                if (trickInfo.trickAnim == null) {
                    trickInfo.trickAnim = new Zanimation();// [[Zanimation alloc] init];
                }

                ZAnimationInfo info = new ZAnimationInfo();
                info.gapType = GapType.kAnimGapTime;
                for (int i = 0; i < 12; i++) {
                    info.frameTime[i] = 0.1f;
                }

                int whichAnim = Utilities.GetRand( 5);
                switch (whichAnim) {
                case 0 :
                    info.numFrames = 2;
                    info.subTextureId[0] = kStartBlinkSubtextures;
                    info.subTextureId[1] = kStartBlinkSubtextures + 1;
                    break;
                case 1 :
                    info.numFrames = 5;
                    info.subTextureId[0] = kStartBlinkSubtextures;
                    info.subTextureId[1] = kStartBlinkSubtextures + 1;
                    info.subTextureId[2] = kStartBlinkSubtextures + 2;
                    info.frameTime[2] = 0.7f;
                    info.subTextureId[3] = kStartBlinkSubtextures + 3;
                    info.subTextureId[4] = kStartBlinkSubtextures + 1;
                    break;
                case 2 :
                case 3 :
                    info.numFrames = 5;
                    info.subTextureId[0] = kStartBlinkSubtextures;
                    info.subTextureId[1] = kStartBlinkSubtextures + 1;
                    info.subTextureId[2] = kStartBlinkSubtextures + 4;
                    info.frameTime[2] = 0.6f;
                    info.subTextureId[3] = kStartBlinkSubtextures + 5;
                    if (Utilities.GetRand( 2) == 0) {
                        info.subTextureId[2] = kStartBlinkSubtextures + 6;
                        info.subTextureId[3] = kStartBlinkSubtextures + 7;
                    }

                    info.subTextureId[4] = kStartBlinkSubtextures + 1;
                    break;
                case 4 :
                    info.numFrames = 8;
                    info.subTextureId[0] = kStartBlinkSubtextures;
                    info.subTextureId[1] = kStartBlinkSubtextures + 1;
                    info.subTextureId[2] = kStartBlinkSubtextures + 4;
                    info.frameTime[2] = 0.4f;
                    info.subTextureId[3] = kStartBlinkSubtextures + 5;
                    info.subTextureId[4] = kStartBlinkSubtextures + 1;
                    info.subTextureId[5] = kStartBlinkSubtextures + 6;
                    info.frameTime[5] = 0.4f;
                    info.subTextureId[6] = kStartBlinkSubtextures + 7;
                    info.subTextureId[7] = kStartBlinkSubtextures + 1;
                    if (Utilities.GetRand( 2) == 0) {
                        info.subTextureId[2] = kStartBlinkSubtextures + 6;
                        info.subTextureId[3] = kStartBlinkSubtextures + 7;
                        info.subTextureId[5] = kStartBlinkSubtextures + 4;
                        info.subTextureId[6] = kStartBlinkSubtextures + 5;
                    }

                    break;
                default :
                    Globals.Assert(false);
                    break;
                }

                (trickInfo.trickAnim).Setup(info);
                (trickInfo.trickAnim).PlayOnce();
                trickInfo.trickState = TrickState.e_BlinkAnim_Blinking;
            }

        }
        else {
            (trickInfo.trickAnim).Update();
            if ((trickInfo.trickAnim).state == AnimationState.kAnimFinished) {
                trickInfo.trickState = TrickState.e_NoTrick;
                float randExtra = (float)(Utilities.GetRand( 6)) / 10.0f;
                trickInfo.timeToStartNextPhase = gameStateTimer + 0.7f + randExtra;
            }

        }

    }

    public void UpdateNetworkPlayer()
    {
        if (networkPlayerInterpolating <= 0) {
            speed = networkSentSpeed;
        }
        else {
            synthesizedTilt.x += netTiltSpeed.x;
            synthesizedTilt.y += netTiltSpeed.y;
        }

        networkPlayerInterpolating--;
        desiredSpeedForAngleDisplay.y = synthesizedTilt.y;
        desiredSpeedForAngleDisplay.x = (synthesizedTilt.x * topLateralSpeed * 0.685f);
        this.UpdateXYPos();
        distanceTravelled = this.GetDistanceLastFrame();
        this.UpdateMoveAnim();
        this.UpdateDustCloud(distanceTravelled);
        this.SetScreenPos();
        this.UpdateRotateAnim();
        this.UpdateTracks();
    }

    public void UpdateIsInFinalThird()
    {
        if (isInFinalThird) {
        }
        else {
            if (position.y > finalThirdLine) {
                isInFinalThird = true;
                			if (racingBrain != null)
			{

					racingBrain.EnteredFinalThird();
					}
            }

        }

    }

    public void UpdateWithBrain()
    {
        Globals.Assert(controlType == PlayerControlType.kControlAI);
        stateTimer += Constants.kFrameRate;
        if (manualControlOfPiggy) {
            this.UpdateManualPiggy();
            this.UpdatePostRaceCelebration();
            this.UpdateZPosition();
        }
        else {
            
				racingBrain.Update();
            if (state == PlayerState.kPlayerMoving_CrashingThroughHedge) {
                this.UpdateCrashingThroughHedge();
            }

            desiredSpeedForAngleDisplay = racingBrain.GetSpeedForAngleDisplay();
            this.UpdatePostRaceCelebration();
            this.UpdatePlayerPosition();
        }

        noGoZone.SetMapPosition(position);
        this.UpdateIsInFinalThird();
        this.UpdateGroundLevelJump();
        this.UpdateCurrentTile();
        this.UpdateOnRoad();
        this.UpdateTopSpeedStars();
        this.UpdateSpeedBoosts();
        this.UpdateBoostArrows();
        this.UpdateHoofBeats();
        this.UpdateCowPat();
        this.UpdateMoveAnim();
        this.UpdateDustCloud(this.GetDistanceLastFrame());
        this.UpdateRotateAnim();
        this.SetScreenPos();
        this.UpdateTracks();
        prevGroundLevel = groundLevel;
    }

    public void UpdateManualPiggy()
    {
        if (finishPosition != -1) {
            if (position.y > ((Globals.g_world.game).finishYPos + 95.0f)) {
                speed.y *= 0.8f;
                speed.x *= 0.8f;
            }
            else if (position.y > ((Globals.g_world.game).finishYPos + 35.0f)) {
                speed.y *= 0.91f;
                speed.x *= 0.91f;
            }
            else {
                if (speed.y < 0.0f) {
                    speed.y *= 0.72f;
                    speed.x *= 0.72f;
                }

            }

        }
        else {
            speed.y *= 0.91f;
            speed.x *= 0.91f;
        }

        this.UpdateXYPos();
    }

    public void UpdateAsGhost(Ghost ghost)
    {
        stateTimer += Constants.kFrameRate;
        switch (state) {
        case PlayerState.kPlayerMoving_CrashingThroughHedge :
            this.UpdateCrashingThroughHedge();
            break;
        default :
            break;
        }

        this.SetPiggyAngleForShadow();
        if (!manualControlOfPiggy) {
            this.UpdateGhostValues(ghost);
        }
        else {
            this.UpdateManualPiggy();
        }

        noGoZone.SetMapPosition(position);
        distanceTravelled = this.GetDistanceLastFrame();
        this.UpdateMoveAnim();
        this.UpdateDustCloud(distanceTravelled);
        this.UpdateTopSpeedStars();
        this.UpdateSpeedBoosts();
        this.UpdateBoostArrows();
        this.UpdateHoofBeats();
        this.UpdateCowPat();
        this.UpdateCurrentTile();
        this.SetScreenPos();
        this.UpdateTracks();
    }

    public void UpdateTracks()
    {
					//	return;

        if (positionZ > 10.0f) return;

        if (inHayStack != -1) {
            return;
        }

        if (inPond != -1) {
            if (((Globals.g_world.game).GetPond(inPond)).type != PondType.e_Snow) {
                return;
            }

        }

        if (onBridge != -1) {
            return;
        }

        if (inRiver != -1) {
            return;
        }

        if (!this.CanPlaceTrackPieceOnThisTile()) {
            return;
        }

        if (Globals.g_world.artLevel == 0) {
            if (boostArrowTimer > 0) {
                return;
            }

        }

        if (controlType == PlayerControlType.kControlGhost) {
            distanceTravelled = Utilities.GetDistanceP1(position, prevPlayerPosition);
        }

        distanceSinceTrackDown += distanceTravelled;
        float betweenBits = 13.0f;
        if (inCowPatTimer > 0) {
            betweenBits = 16.0f;
        }

        if (Globals.g_world.artLevel == 0) {
            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                if ((Globals.g_world.game).numPlayersOnScreen >= 3) betweenBits = 26.0f;
                else {
                    betweenBits = 15.0f;
                }

            }
            else {
                if ((Globals.g_world.game).numPlayersOnScreen >= 3) betweenBits = 28.0f;
                else {
                    betweenBits = 20.0f;
                }

            }

        }

        if (distanceSinceTrackDown >= betweenBits) {
            distanceSinceTrackDown -= betweenBits;
            this.PlaceTrackPiece();
        }

    }

    public void UpdateShadow(CGPoint inScreenPosition)
    {
        float kShadowHeightRatio = 0.455f * temporaryShadowLengthener;
        float kShadowHeightRatioX = 1.04f * temporaryShadowLengthener;
        float shadowHeight = (positionZ - groundLevel);
        shadowScreenPosition = Utilities.CGPointMake((11.0f + inScreenPosition.x + (shadowHeight * kShadowHeightRatioX)), 10.0f + inScreenPosition.y + (shadowHeight *
          kShadowHeightRatio));
    }

    public void UpdateCrashingThroughHedge()
    {
        if (!disableSpriteTiles) {
            if (stateTimer > 0.01f) {
			for (int i = (int)PlayerBillboards.kBB_SpriteTile1; i <= (int)PlayerBillboards.kBB_SpriteTile6;i++)
			{
					myAtlasBillboard[i].StopRender();
			}
						disableSpriteTiles = true;
                this.StartBushCrashFragments();
            }

        }

        if (stateTimer < 0.35f) {
            int useLevel;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) useLevel = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
            else useLevel = ((Globals.g_world.frontEnd).profile).selectedLevel;

            int realLev = LevelBuilder_Ross.levelOrder[useLevel];
            float kMaxYSpeedInHedge = 2.0f;
            if (realLev == (int)LevelBuilder_Ross.Enum2.kGrass6_6_StrCup_Race6_MazyD) {
                stateTimer -= (Constants.kFrameRate / 8.0f);
                kMaxYSpeedInHedge = 0.02f;
            }
            else if ((realLev == (int)LevelBuilder_Ross.Enum2.kGrass6_5_StrCup_Race5_scruba) || (realLev == (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep)) {
                if (playerId > 0) {
                    kMaxYSpeedInHedge = 2.0f;
                }
                else {
                    kMaxYSpeedInHedge = 0.04f;
                }

            }
            else {
                kMaxYSpeedInHedge = 0.04f;
            }

            if (speed.y > kMaxYSpeedInHedge) speed.y = kMaxYSpeedInHedge;

            speed.x *= 0.85f;
            if (speedBoostTimer > 0.0f) {
                if (speedBoostEffect != -1) {
                    stateTimer += (Constants.kFrameRate);
                }

            }

        }

        float yDiff = (position.y + 15) - yBushPosition;
        if (yDiff < 45) xBushPosition = position.x;

        if (yDiff > 51) {
            controlFaceAngle = false;
            this.SetNewState(PlayerState.kPlayerMoving_Normally);
            disableSpriteTiles = false;
            (Globals.g_world.game).AddMapObjectP1P2P3( TextureType.kTexture_BushCrashToPasteAfter, (int) xBushPosition, (int) yBushPosition + 9,  ListType.
              e_RenderUnderPlayer);
        }

    }

    public void UpdateCowPat()
    {
        if (inCowPatTimer > 0.0f) {
            inCowPatTimer -= Constants.kFrameRate;
        }

    }

    public void UpdateEndOfFrame()
    {
        if (dustCloudFlagged) {
            if (inPond == -1) {
                this.AddDustCloud(position);
            }

            dustCloudFlagged = false;
        }

        distanceLastFrame = -1;
        normalisedSpeed.x = -2;
    }

    public void CheckJumpLengthAdjustmentFromTrampoline(CGPoint targetPoint)
    {
        float distance = targetPoint.y - position.y;
        this.CheckJumpLengthAdjustmentFromRamp(distance);
    }

    public void CheckJumpLengthAdjustmentFromRamp(float distanceWanted)
    {
        if (distanceWanted > 0.0f) {
            const float kDiffAllowed = 180.0f;
            float frames = zVelocity / kJumpGravity;
            frames *= 2.0f;
            frames += 7;
            float nowSpeed = speed.y;
            float distanceWouldJump = 0.0f;
            float yAccel = 0.2f;
            float speedUpToSpeed;
            if (kFinalSpeedMultiplier > nowSpeed) {
                speedUpToSpeed = kFinalSpeedMultiplier;
            }
            else {
                speedUpToSpeed = nowSpeed;
            }

            for (int i = 0; i < (int) frames; i++) {
                distanceWouldJump += nowSpeed;
                nowSpeed = nowSpeed + ((kFinalSpeedMultiplier - nowSpeed) * yAccel);
            }

            if (Utilities.GetABS(distanceWouldJump - distanceWanted) < kDiffAllowed) {
                speed.y = distanceWanted / frames;
                speed.y *= 0.92f;
                jumpAdjusting = true;
            }
            else {
                jumpAdjusting = false;
            }

        }
        else {
            jumpAdjusting = false;
        }

    }

    public void FinishJumpAdjusting()
    {
        jumpAdjusting = false;
    }

    public void UpdateGroundLevelJump()
    {
        if (state != PlayerState.kPlayerMoving_InAir) {
            if (positionZ > groundLevel) {
                if (position.y > 200) {
                    if (onCliff != -1) {
                        positionZ = groundLevel;
                    }
                    else {
                        if (onRamp == -1) {
                            this.SetNewState(PlayerState.kPlayerMoving_InAir);
                            this.CheckStartTrick();
                        }

                    }

                }

            }
            else if (positionZ < groundLevel) {
                positionZ = groundLevel;
                zVelocity = ((groundLevel - prevGroundLevel));
                if (playerType == (int) PlayerType.kPlayerPig) {
                    if (onRoof != -1) {
                        if (zVelocity > 15.0f) {
                            zVelocity = 0.0f;
                        }

                    }

                }

            }
            else {
                zVelocity = ((groundLevel - prevGroundLevel));
            }

        }
        else {
            if (positionZ <= groundLevel) {
                positionZ = groundLevel;
                if ((numBounces == 2) || (inRiver != -1)) {
                    temporaryShadowLengthener = 1.0f;
                    this.SetNewState(PlayerState.kPlayerMoving_Normally);
                }
                else {
                    if (numBounces == 0) {
                        if (positionZ >= -5.0f) {
                            if (zVelocity < -3.0f) {
                                dustCloudFlagged = true;
                            }

                        }

                        jumpAdjusting = false;
                    }

                    float volume = (1 - Utilities.GetRatioP1P2(zVelocity, -15, 0));
                    Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_Land, volume, position);
                    zVelocity = (-zVelocity * 0.3f);
                    numBounces++;
                }

            }
            else {
                this.UpdateTrick();
            }

        }

    }

    public void UpdateDustCloud(float movedDist)
    {
        if (positionZ > (groundLevel + 2)) return;

        if ((screenPos.y > 550) || (screenPos.y < 0)) return;

        if (onBridge != -1) return;

        if (boostArrowTimer > 0) {
            if (Globals.g_world.artLevel < 2) return;

        }

        const float kDistBetweenClouds = 65.0f;
        distSinceCloud += movedDist;
        if (distSinceCloud >= kDistBetweenClouds) {
            if (onRoof == -1) {
                if ((speed.x != 0.0f) || (speed.y != 0.0f)) {
                    distSinceCloud -= kDistBetweenClouds;
                    ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                    info.type = EffectType.kEffect_DustCloudTrail;
                    info.startPosition = position;
                    CGPoint normalDirection = this.GetNormalisedSpeed();
                    info.startPosition.y -= (normalDirection.y * 15);
                    info.startPosition.x -= (normalDirection.x * 15);
                    info.player = this;
                    (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                }

            }
            else {
                if (((Globals.g_world.game).GetBuilding(onRoof)).type ==  BuildingType.kBuilding_SideShed) {
                    distSinceCloud -= kDistBetweenClouds;
                    ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                    info.type = EffectType.kEffect_Sparks;
                    info.startPosition = position;
                    CGPoint normalDirection = this.GetNormalisedSpeed();
                    info.startPosition.y -= (normalDirection.y * 15);
                    info.startPosition.x -= (normalDirection.x * 15);
                    info.velocity = speed;
                    info.player = this;
                    info.rotation = Utilities.GetRatioP1P2(this.GetDistanceLastFrame(), 6.0f, 10.0f);
                    if (info.rotation < 0.2f) {
                        return;
                    }

                    (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                }

            }

        }

    }

    public void UpdateFalling()
    {
    }

    public void UpdateXYPos()
    {
        prevPlayerPosition = position;
        if (inMudTimer > 0.0f) {
            inMudTimer -= Constants.kFrameRate;
            if (inMudTimer < 0.6f) {
                inMudSpeed.x *= 0.95f;
                inMudSpeed.y *= 0.95f;
                float ratio = 1.0f - Utilities.GetRatioP1P2(inMudTimer, 0.0f, 0.6f);
                actualSpeed = Utilities.GetPositionBetweenP1P2(ratio, inMudSpeed, speed);
            }
            else {
                actualSpeed.x = inMudSpeed.x;
                actualSpeed.y = inMudSpeed.y;
            }

        }
        else {
            actualSpeed.y = (speed.y - powerSkidYLess);
            actualSpeed.x = speed.x;
        }

        position.x += actualSpeed.x;
        position.y += actualSpeed.y;
        if (position.x < Constants.PLAYABLE_MAP_LEFT_EDGE) {
            if (speed.x < -5.0f) {
                (Globals.g_world.audio).UpdateRandomAnimalSoundCountry(10);
            }

            position.x = Constants.PLAYABLE_MAP_LEFT_EDGE;
            speed.x = (-speed.x * 1.0f);
        }

        if (position.x > Constants.PLAYABLE_MAP_RIGHT_EDGE) {
            if (speed.x > 5.0f) {
                (Globals.g_world.audio).UpdateRandomAnimalSoundCountry(10);
            }

            position.x = Constants.PLAYABLE_MAP_RIGHT_EDGE;
            speed.x = (-speed.x * 1.0f);
        }

    }

    public void UpdateHoofBeats()
    {
        const float kDistanceForAllHoofs = 200;
        float[] kHoofDistanceRatio = new float[4]
        {0.1f, 0.2f, 0.6f, 0.7f};
        distanceBetweenHoofSounds += this.GetDistanceLastFrame();
        if (distanceBetweenHoofSounds >= kDistanceForAllHoofs) {
            whichHoof = 0;
            distanceBetweenHoofSounds -= kDistanceForAllHoofs;
        }

        if (whichHoof < 4) {
            float ratio = distanceBetweenHoofSounds / kDistanceForAllHoofs;
            if (ratio >= kHoofDistanceRatio[whichHoof]) {
                this.PlayHoofSound();
                whichHoof++;
            }

        }

    }

    public void UpdateZPosition()
    {
        prevPositionZ = positionZ;
        zVelocity -= kJumpGravity;
        positionZ += zVelocity;
    }

    public void UpdatePlayerPosition()
    {
        this.UpdateZPosition();
        if (state == PlayerState.kPlayerMoving_Normally) {
        }

        this.UpdateXYPos();
    }

    public void UpdateSpeedBoosts()
    {
        if (speedBoostTimer > 0) {
            speedBoostTimer -= Constants.kFrameRate;
            desiredSpeed.y = speedBoostPower;
            speed.y += ((desiredSpeed.y - speed.y) * 0.06f);
            if (speedBoostTimer <= 0) {
                if (speedBoostEffect != -1) {
                    (ParticleSystemRoss.Instance()).StopParticleEffect(speedBoostEffect);
                    speedBoostEffect = -1;
                }

            }

        }

    }

    public void UpdateBoostArrows()
    {
        if (boostArrowTimer > 0) {
            boostArrowTimer -= Constants.kFrameRate;
            desiredSpeed.y = boostArrowPower;
            speed.y += ((desiredSpeed.y - speed.y) * kPlayerAccelerationBoostArrow);
            if (boostArrowTimer <= 0) this.EndBoostArrow();

        }

    }

    public void UpdateTopSpeedStars()
    {
        if (speed.y >= (kFinalSpeedMultiplier * 0.92f)) {
            maxSpeedTime += Constants.kFrameRate;
            if (maxSpeedTime >= 0.7f) {
                if (maxSpeedExtraSpeed < 5) {
                    maxSpeedTime = 0;
                    if (maxSpeedExtraSpeed > 0) {
                        ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                        info.type = EffectType.kEffect_SpeedBoostStars;
                        info.startPosition = position;
                        info.player = this;
                        maxSpeedEffect[maxSpeedExtraSpeed] = (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                    }

                    maxSpeedExtraSpeed += 1;
                }

            }

        }
        else {
            this.EndMaxSpeed();
        }

    }

    public void UpdateSlowDownHay()
    {
        if (slowDownTimer > 0.0f) {
            slowDownTimer -= Constants.kFrameRate;
            speed.x *= 0.9f;
            speed.y *= 0.9f;
        }

    }

    public void UpdateSpeedY()
    {
        float heightOffset = positionZ - groundLevel;
        float combinedTiltY;
        if (heightOffset < kHeightForControlToWork) {
            rememberedTiltY = synthesizedTilt.y;
            combinedTiltY = synthesizedTilt.y + bumpTilt.y;
        }
        else {
            combinedTiltY = rememberedTiltY;
        }

        if (combinedTiltY < 0) combinedTiltY = 0;

        #if FASTERSIMULTAORdEBUG
            combinedTiltY = 0.6f;
        #endif

        desiredSpeedForAngleDisplay.y = synthesizedTilt.y;
        desiredSpeed.y = (combinedTiltY * kFinalSpeedMultiplier);
        if (finishPosition == -1) {
            if (heightOffset < kHeightForControlToWork) {
                this.SetPowerTurnSpeedReduction();
            }

        }
        else {
            if ((speed.y - powerSkidYLess) < 0.5f) {
                powerSkidYLess = 0.0f;
            }
            else {
                if (powerSkidYLess > 0.0f) powerSkidYLess -= 0.125f;

            }

        }

        this.UpdateSpeedBoosts();
        this.UpdateBoostArrows();
        if (!jumpAdjusting) {
            desiredSpeed.y += ((float) maxSpeedExtraSpeed * whiteStarSpeedAddition);
        }

        float speedMultiplier = this.GetSpeedMultiplier();
        desiredSpeed.y *= speedMultiplier;
        float yAccel;
        yAccel = 0.2f;

        #if RACE_AS_PIGGY
        #else

            #if MAKE_THE_SHEEP_FASTER
                yAccel *= 2.0f;
            #endif

        #endif

        if (finishPosition != -1) {
            if (position.y > ((Globals.g_world.game).finishYPos + 125.0f)) {
                yAccel = 0.7f;
            }
            else if (position.y > ((Globals.g_world.game).finishYPos + 95.0f)) {
                yAccel = 0.4f;
            }
            else if (position.y > ((Globals.g_world.game).finishYPos + 70.0f)) {
                yAccel = 0.25f;
            }

        }

        #if SIMULTANEOUS_START_TEST
            const float kRaceTimeToFullAcc = 0.93f;
            if ((Globals.g_world.game).raceTimer < kRaceTimeToFullAcc) {
                float ratio = Utilities.GetRatioP1P2((Globals.g_world.game).raceTimer, 0.0f, kRaceTimeToFullAcc);
                yAccel *= ratio;
            }

        #endif

        if (inRiver != -1) {
            speed.y += ((desiredSpeed.y - speed.y) * yAccel);
        }
        else if (inPond != -1) {
            if (((Globals.g_world.game).GetPond(inPond)).type != PondType.e_MuddyPuddle) {
                speed.y += ((desiredSpeed.y - speed.y) * yAccel);
            }
            else {
                speed.y += ((desiredSpeed.y - speed.y) * (yAccel * 0.3f));
            }

        }
        else if (inWaterfall != -1) {
            speed.y += ((desiredSpeed.y - speed.y) * yAccel * 0.05f);
        }
        else {
            speed.y += ((desiredSpeed.y - speed.y) * (yAccel * 0.3f));
        }

        bool starSpeedDisabled = false;
        if (racingBrain != null) {
            if (racingBrain.skidding) {
                starSpeedDisabled = true;
            }

        }

        if (!starSpeedDisabled) this.UpdateTopSpeedStars();

    }

    public void UpdateTiltTimerFingerP1(float xTiltThisFrame, float xTiltLastFrame)
    {
        const float kHowBig = 0.9f;
        if ((xTiltThisFrame > kHowBig) && (xTiltLastFrame > kHowBig)) {
            timeTiltingInSameDirection += Constants.kFrameRate;
        }
        else if ((xTiltThisFrame < -kHowBig) && (xTiltLastFrame < -kHowBig)) {
            timeTiltingInSameDirection += Constants.kFrameRate;
        }
        else if ((xTiltThisFrame >= -kHowBig) && (xTiltLastFrame < -kHowBig)) {
            timeTiltingInSameDirection = 0.0f;
        }
        else if ((xTiltThisFrame <= kHowBig) && (xTiltLastFrame > kHowBig)) {
            timeTiltingInSameDirection = 0.0f;
        }

        prevXTilt = xTiltThisFrame;
    }

    public void UpdateTiltTimerP1(float xTiltThisFrame, float xTiltLastFrame)
    {
        if (xTiltThisFrame != xTiltLastFrame) {
            timeTiltingInSameDirection = 0.0f;
        }
        else {
            timeTiltingInSameDirection += Constants.kFrameRate;
        }

        prevXTilt = xTiltThisFrame;
    }

    public void UpdateTiltValuesFingerP1P2(bool fingerDown, CGPoint fingerPosition, float maxDiffY)
    {
        synthesizedTilt.y = 1.0f;
        if (fingerDown) {
            
//			float position320 = (screenPos.x / Globals.g_world.drawWidth) * 320.0f;
			float position320 = (screenPos.x / 320.0f) * TouchManager.xScreenWidth;
			position320 += TouchManager.xScreenStartPixel;				
				
			float xDifference = fingerPosition.x - position320;
            const float kMinDiffThing = 5.0f;
            if (xDifference > 0.0f) {
                synthesizedTilt.x = Utilities.GetRatioP1P2(xDifference, kMinDiffThing, maxDiffY);
            }
            else {
                synthesizedTilt.x = -Utilities.GetRatioP1P2(-xDifference, kMinDiffThing, maxDiffY);
            }

        }
        else {
            synthesizedTilt.x = 0.0f;
        }

    }

    public void UpdateTiltValues()
    {
        if (humanControlType == HumanControlType.kControlHumanTilt) {
            synthesizedTilt = Globals.g_world.game.GetTiltDirection();
            if (!((Globals.g_world.frontEnd).profile).preferences.tiltExpert) {
                synthesizedTilt.y = 1.0f;
            }

        }
        else if (humanControlType == HumanControlType.kControlHumanThumbs) {
            synthesizedTilt.y = 1.0f;
            if (directionButtonLeft) {
                CGPoint leftPos;
                if (Globals.deviceIPad) {
                    leftPos = Utilities.CGPointMake(18.0f, 440.0f);
                }
                else {
                    leftPos = Utilities.CGPointMake(30.0f, 440.0f);
                }

                prevXTilt = synthesizedTilt.x;
                this.UpdateTiltValuesFingerP1P2(true, leftPos, 90.0f);
                this.UpdateTiltTimerFingerP1(synthesizedTilt.x, prevXTilt);
            }
            else if (directionButtonRight) {
                CGPoint rightPos;
                if (Globals.deviceIPad) {
                    rightPos = Utilities.CGPointMake(300.0f, 440.0f);
                }
                else {
                    rightPos = Utilities.CGPointMake(290.0f, 440.0f);
                }

                prevXTilt = synthesizedTilt.x;
                this.UpdateTiltValuesFingerP1P2(true, rightPos, 90.0f);
                this.UpdateTiltTimerFingerP1(synthesizedTilt.x, prevXTilt);
            }
            else {
                CGPoint noPos = Utilities.CGPointMake(0, 0);
                prevXTilt = synthesizedTilt.x;
                this.UpdateTiltValuesFingerP1P2(false, noPos, 90.0f);
                this.UpdateTiltTimerFingerP1(synthesizedTilt.x, prevXTilt);
            }

        }
        else {
            prevXTilt = synthesizedTilt.x;
            this.UpdateTiltValuesFingerP1P2(((Globals.g_world.game).fingerControl).fingerDown, ((Globals.g_world.game).fingerControl).fingerPosition, ((Globals.g_world.
              game).fingerControl).maxDiffY);
            this.UpdateTiltTimerFingerP1(synthesizedTilt.x, prevXTilt);
        }

    }

    public void UpdateSpeedX()
    {
        if (state == PlayerState.kPlayerMoving_CrashingThroughHedge) return;

        #if MAKE_THE_CONTROLS_HARD
            synthesizedTilt.x += Utilities.GetRandBetweenP1(-0.25f, 0.25f);
            synthesizedTilt.x *= 10.0f;
            synthesizedTilt.x = Utilities.ConstrainP1P2(synthesizedTilt.x, -1.0f, 1.0f);
        #endif

        desiredSpeed.x = ((synthesizedTilt.x * topLateralSpeed) + bumpTilt.x);
        desiredSpeedForAngleDisplay.x = (synthesizedTilt.x * topLateralSpeed * 0.685f);
        const float scrollLookLag = 0.025f;
        if (((Globals.g_world.game).gameState == GameState.e_ShowResultsWin) || ((Globals.g_world.game).gameState == GameState.e_ShowResultsLoseToPiggy)) {
            xScrollLook = xScrollLook + (((0.0f) - xScrollLook) * scrollLookLag);
        }
        else {
            xScrollLook = xScrollLook + (((desiredSpeedForAngleDisplay.x * 80.0f) - xScrollLook) * scrollLookLag);
        }

        float heightOffset = positionZ - groundLevel;
        float kGetTractionHeight = 7;
        float offGroundRatio = 1;
        if (heightOffset > kGetTractionHeight) return;
        else if (state == PlayerState.kPlayerMoving_InAir) {
            offGroundRatio = 1 - Utilities.GetRatioP1P2(heightOffset, 0, kGetTractionHeight);
        }

        float absTiltX = Utilities.GetABS(synthesizedTilt.x);
        float xMaxAccel = Utilities.GetRatioP1P2P3P4(speed.y, minSpeedY, maxSpeedY, kAccelAtMaxTiltMinSpeed, kAccelAtMaxTilt);
        float cosRatio;
        if (!((Globals.g_world.frontEnd).profile).preferences.tiltExpert) {
            cosRatio = Utilities.SetCosInterpolationHalfP1(absTiltX, 0.75f);
        }
        else {
            cosRatio = Utilities.SetCosInterpolationHalfP1(absTiltX, 0.5f);
        }

        if (isInDeepWater) {
            if (inPond != -1) {
                if (((Globals.g_world.game).GetPond(inPond)).type ==  PondType.e_Puddle) {
                    desiredSpeed.x *= 0.3f;
                }
                else {
                    desiredSpeed.x *= 0.3f;
                }

            }
            else {
                desiredSpeed.x *= 0.3f;
            }

        }
        else if (inPond != -1) desiredSpeed.x *= 0.6f;

        if ((Globals.g_world.game).gameState == GameState.e_ShowResultsWin) {
            if (position.y > ((Globals.g_world.game).finishYPos + 35.0f)) {
                desiredSpeed.x = 0;
            }

        }

        if (((Globals.g_world.game).gameState == GameState.e_ShowResultsLoseToPiggy) || ((Globals.g_world.game).gameState == GameState.
          e_ShowResultsLoseTooSlow)) {
            desiredSpeed.x = 0;
        }

        float xAccel = Utilities.SetRatioP1P2(cosRatio, kAccelAtMinTilt, xMaxAccel);
        xAccel *= offGroundRatio;
        if (inCowPatTimer > 0) {
            const float kPatSlipperiness = 0.4f;
            float patMultiplier = 1 - (kPatSlipperiness * Utilities.GetRatioP1P2(inCowPatTimer, 0, kPatSlideTime));
            xAccel *= patMultiplier;
        }

        if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneIce) {
        }

        if (finishPosition != -1) {
            if (position.y > ((Globals.g_world.game).finishYPos + 125.0f)) {
                xAccel = 0.5f;
            }
            else if (position.y > ((Globals.g_world.game).finishYPos + 95.0f)) {
                xAccel = 0.25f;
            }
            else if (position.y > ((Globals.g_world.game).finishYPos + 70.0f)) {
                xAccel = 0.15f;
            }

        }

        speed.x += ((desiredSpeed.x - speed.x) * xAccel);
    }

    public void UpdateRotateAnim()
    {
        if (playerDisplayAngle > maxAngleForRotateAnim[rotateAnim]) {
            if (rotateAnim > 0) rotateAnim--;

        }
        else {
            int prevAnim = rotateAnim + 1;
            if (prevAnim <= 20) {
                if (playerDisplayAngle < maxAngleForRotateAnim[prevAnim]) {
                    if (rotateAnim < (numPlayerRotateAnims - 1)) rotateAnim++;

                }

            }

        }

    }

    public void UpdateCurrentTile()
    {
        int prevX = xCurrentTile;
        int prevY = yCurrentTileForTileId;
        xCurrentTile = (int)(((int) position.x) / 64.0f);
        yCurrentTile = (int)(((int) position.y - 32.0f) / 64.0f);
        yCurrentTileForTileId = (int)(((int) position.y) / 64.0f);
        if ((xCurrentTile != prevX) || (yCurrentTileForTileId != prevY)) {
            int tileId = (((Globals.g_world.game).tileMap).GetTileGrid()).GetTileIdP1(xCurrentTile + Constants.NUM_TILES_NOT_PLAYABLE_TO_LEFT, 
              yCurrentTileForTileId);
            currentTileIdObject = (int)((Globals.g_world.game).lBuilder).GetObjectFromTileId(tileId);
        }

    }

    public void UpdateMoveAnim()
    {
        distanceTravelled = this.GetDistanceLastFrame();
        animateRoll += distanceTravelled;
        if (animateRoll > kRollAnimSpeed) {
            moveAnim++;
            if (moveAnim >= numAnims) {
                moveAnim = 0;
            }

            if (playerType == (int)PlayerType.kPlayerSheep) {
                shadowSubtextureId = startShadowSubtextureId + moveAnim;
            }

            animateRoll -= kRollAnimSpeed;
        }

        if (state == PlayerState.kPlayerMoving_InAir) {
            if (zVelocity > 0.75f) {
                moveAnim = 2;
            }
            else if (zVelocity < -0.75f) {
                moveAnim = 0;
            }
            else {
                moveAnim = 1;
            }

            if (playerType == (int) PlayerType.kPlayerSheep) {
                shadowSubtextureId = startShadowSubtextureId + moveAnim;
            }

        }

    }

		
		
    }
}
