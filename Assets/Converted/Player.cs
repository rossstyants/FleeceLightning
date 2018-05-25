using UnityEngine;
using System;

namespace Default.Namespace
{
    public enum  PlayerState {
        kPlayerMoving_Normally,
        kPlayerMoving_CrashingThroughHedge,
        kPlayerMoving_InAir
    }
    public enum  TrickState {
        e_NoTrick = -2,
        e_WaitingToStart,
        e_Starting,
        e_Holding,
        e_Finishing,
        e_BlinkAnim_Blinking,
        tates
    }
    public enum  HumanControlType {
        kControlHumanTilt,
        kControlHumanThumbs,
        kControlHumanFinger
    }
    public enum  PlayerControlType {
        kControlHuman = 0,
        kControlGhost,
        kControlAI,
        kNumControlTypes
    }

    public enum  PlayerBillboards {
		kBB_Me = 0,
		kBB_Shadow,
		kBB_ThingBefore,
		kBB_ThingAfter,
		kBB_SpriteTile1,
		kBB_SpriteTile2,
		kBB_SpriteTile3,
		kBB_SpriteTile4,
		kBB_SpriteTile5,
		kBB_SpriteTile6,
		kNumBillboards
	}	
	
	public partial class Player
    {
		const float kHeightForControlToWork = 8;
		const int kStartTrickSubtextures = 168;
		const int kStartBlinkSubtextures = 176;
		
		public Billboard[] myAtlasBillboard = new Billboard[(int)PlayerBillboards.kNumBillboards];
		
		public PlayerHeight playerHeight;
        public RacingBrain racingBrain;
        public NoGoZone noGoZone;
        public float topLateralSpeed;
        public float lateralControlAcceleration;
        public float whiteStarSpeedAddition;
        public float kFinalSpeedMultiplier;
        public float kPlayerAccelerationBoostArrow;
        public float rememberedTiltY;
        public CGPoint synthesizedTiltDesired;
        public CGPoint synthesizedTilt;
        public CGPoint bumpTilt;
        public HumanControlType humanControlType;
        public PlayerControlType controlType;
        public float timeSinceSkidParticle;
        public PlayerState state;
        public float stateTimer;
        public CGPoint position;
        public CGPoint prevPlayerPosition;
        public CGPoint speed;
        public float positionZ;
        public float prevPositionZ;
        public CGPoint desiredSpeed;
        public CGPoint desiredSpeedForAngleDisplay;
        public float powerSkidYLessDesired;
        public float powerSkidYLess;
        public float slowDownTimer;
        public TrickInfo trickInfo;
        public int whichHoof;
        public float distanceBetweenHoofSounds;
        public int boostArrowSoundId;
        public int swimmingSoundId;
        public float playerDisplayAngle;
        public float moveAngle;
        public float prevMoveAngle;
        public float playerScale;
        public CGPoint screenPos;
        public CGPoint normalisedSpeed;
        public float groundLevel;
        public float prevGroundLevel;
        public CGPoint shadowScreenPosition;
        public float zVelocity;
        public float minSpeedY;
        public float maxSpeedY;
        public float thumbControlMaxTimePressing;
        public Texture2D_Ross shadowTexture;
        public float thumbControlMaximum;
        public float tiltingWhichWay;
        public float prevXTilt;
        public float timeTiltingInSameDirection;
        public int currentTileIdObject;
        public int playerType;
        public int finishPosition;
        public float finishTime;
        public float fadingOutBushCrash;
        public float kRollAnimSpeed;
        public int numPlayerRotateAnims;
        public int numAnims;
        public int whichStep;
        public int onRamp;
        public int inVenus;
        public int onLog;
        public int inRiver;
        public int inWaterfall;
        public int onBridge;
        public int inPond;
        public int inHayStack;
        public int onRoof;
        public int onCliff;
        public int xCurrentTile;
        public int yCurrentTile;
        public int yCurrentTileForTileId;
        public int moveAnim;
        public int rotateAnim;
        public int animateIndex;
        public int shadowSubtextureId;
        public int animStartSubtexture;
        public int inMudFootstep;
        public int startShadowSubtextureId;
        public bool onRoad;
        public bool hitWaterInWaterfall;
        public bool isInDeepWater;
        public bool aboveRoof;
        public bool isJumping;
        public bool isJumpEnding;
        public bool isLeftCliff;
        public bool manualControlOfPiggy;
        public bool isInFinalThird;
        public float finalThirdLine;
        public float animateRoll;
        public float distanceTravelled;
        public float xBushPosition;
        public float yBushPosition;
        public float speedBoostTimer;
        public float speedBoostPower;
        public int speedBoostEffect;
        public float boostArrowTimer;
        public float boostArrowPower;
        public int boostArrowEffect;
        public float distSinceCloud;
        public float kPowerSkidAffect;
        public float kAccelAtMinTilt;
        public float kAccelAtMaxTilt;
        public float kAccelAtMaxTiltMinSpeed;
        public int splashingEffectId;
        public float distanceLastFrame;
        public float inCowPatTimer;
        public int numBounces;
        public float maxSpeedTime;
        public int maxSpeedExtraSpeed;
        public int[] maxSpeedEffect = new int[(int)Enum.kMaxNumMaxSpeeds];
        public float temporaryShadowLengthener;
        public float foamyRatio;
        public float baseScale;
        public bool dustCloudFlagged;
        public float inMudTimer;
        public int inVegFootsteps;
        public int inVegFootstepSubtextureId;
        public int foamyAssetId;
        public int numRainbowBoosts;
        public int numHitAppleTrees;
        public bool hitFlowers;
        public bool hitHouse;
        public bool hitMud;
        public bool hitFlock;
        public bool hitHedge;
        public bool hitVeg;
        public bool hitTree;
        public bool gotWet;
        public bool hitBarrel;
        public float distanceSinceTrackDown;
        public CGPoint inMudSpeed;
        public int playerId;
        public bool jumpAdjusting;
        public bool directionButtonLeft;
        public bool directionButtonRight;
        public bool hasPassedFinishLine;
        public bool canMakeSkidSound;
        public bool isOverRiver;
        public bool disableSpriteTiles;
        public float lastRockSoundTime;
        public float lastOvertakeSoundTime;
        public float kJumpGravity;
        public float xScrollLook;
        public int networkPlayerInterpolating;
        public CGPoint networkSentSpeed;
        public CGPoint netTiltSpeed;
        public bool isOnScreen;
        public bool jumpCelebrateCancelled;
        public CGPoint actualSpeed;
        public float timeOnRoof;
        public float[] playerFacingAngle = new float[(int)Enum.kMaxRotateAnims];
        public float[] maxAngleForRotateAnim = new float[(int)Enum.kMaxRotateAnims];
        public CGPoint[,] animationFrameOffset = new CGPoint[(int)Enum.kMaxRotateAnims, (int)Enum.kMaxRunAnims];
        public float faceAngleControlled;
        public float shadowRotScale;
        public bool controlFaceAngle;
        const float kPlayerBumpTime = 0.6f;
        const float kInMudMaxTimer = 1.0f;
        const float kInMudSlowDown = 0.9999f;
        const float kPatSlideTime = 0.4f;
        const float kIcySpinTime = 1.0f;
        public class TrickInfo{
            public TrickState trickState;
          //  short[] trickAnimSubtextureId = new int [(int)TrickState.tates,(int)Enum.kMaxAnimFramesPerTrickState];
            public short currentAnimSubtexture;
            public int whichTrick;
            public float timeToStartNextPhase;
            public Zanimation trickAnim;
            public float holdTime;
        };
        public enum Enum {
            kMaxNumMaxSpeeds = 5,
            kMaxRotateAnims = 22,
            kMaxRunAnims = 5,
            kMaxAnimFramesPerTrickState = 2
        };		public void SetPlayerId(int inId)
		{
			playerId = inId;
		}

        public Player()
        {
            //if (!base.init()) return null;
			
			for (int i = 0; i < (int)PlayerBillboards.kNumBillboards; i++)
			{
				myAtlasBillboard[i] = null;			
			}
			
            isOnScreen = true;
            playerDisplayAngle = 0;
            swimmingSoundId = -1;
            boostArrowSoundId = -1;

            #if SNOW_VERSION
                minSpeedY = 2;
                maxSpeedY = 11;
            #else
                minSpeedY = 1;
                maxSpeedY = 9;
            #endif
			
			trickInfo = new TrickInfo();
			
            trickInfo.trickAnim = null;
            kRollAnimSpeed = 20.0f;
            splashingEffectId = -1;
            speedBoostEffect = -1;
            boostArrowEffect = -1;
            maxSpeedExtraSpeed = 0;
            numPlayerRotateAnims = 17;
            rotateAnim = (short)(numPlayerRotateAnims / 2);
            baseScale = 1;
            temporaryShadowLengthener = 1.0f;
            controlType = PlayerControlType.kControlHuman;
            humanControlType = HumanControlType.kControlHumanThumbs;
            playerType = (int)(PlayerType.kPlayerSheep);
            distanceSinceTrackDown = 0;
            noGoZone = null;
      //      shadowRotScale = 1.0f;//42.5f * Constants.kScreenMultiplierForShorts;
            if (Globals.deviceIPad) {
                shadowRotScale *= 2.0f;
            }
			
//                if (playerType == (int) PlayerType.kPlayerSheep) {
  //              shadowRotScale *= 2.0f;
	//		}
            //return this;
        }
        public void CheckPlayOvertakeSound()
        {
            if (((Globals.g_world.game).raceTimer - lastOvertakeSoundTime) <= 1.0f) {
                return;
            }

            if (Utilities.GetRand( 2) == 0) {
                if (playerType == (int) PlayerType.kPlayerSheep) {
                    if (Utilities.GetRand( 2) == 0) (Globals.g_world.audio).PlayRandomShaunLaugh();
                    else {
                        (Globals.g_world.audio).PlayRandomShaunBaa();
                    }

                }
                else {
                    if (Utilities.GetRand( 2) == 0) (Globals.g_world.audio).PlayRandomPigOinkP1(1.0f, position);
                    else {
                        (Globals.g_world.audio).PlayRandomPigLaugh(position);
                    }

                }

            }

            lastOvertakeSoundTime = (Globals.g_world.game).raceTimer;
        }

        public void BounceSpeedX(float soften)
        {
            speed.x = (-actualSpeed.x * soften);
            inMudTimer = 0.0f;
        }

        public void SetBumpTiltX(float inX)
        {
            bumpTilt.x = inX;
        }

        public void SetBumpTiltY(float inY)
        {
            bumpTilt.y = inY;
        }

        public void SetActualSpeed()
        {
            actualSpeed.y = (speed.y - powerSkidYLess);
            actualSpeed.x = speed.x;
        }

        public void BounceSpeedY(float soften)
        {
            speed.y = (-actualSpeed.y * soften);
            inMudTimer = 0.0f;
            powerSkidYLessDesired = 0.0f;
            powerSkidYLess = 0.0f;
        }

        public void ResetSkidThing()
        {
            powerSkidYLessDesired *= 0.2f;
            powerSkidYLess *= 0.2f;
        }

        public void SetNewSpeed(CGPoint newSpeed)
        {
            inMudTimer = 0.0f;
            speed = newSpeed;
        }

        public void SetSpeedFromRacingBrain(CGPoint newSpeed)
        {
            speed = newSpeed;
        }

        public void SetupAfterDropbox()
        {

            #if DROPBOX_ENABLED
            #endif

        }

        public void SetupNoGoZone(int piggyId)
        {
            if (noGoZone == null) {
                noGoZone = new NoGoZone();
            }

            noGoZone.InitialiseP1(position, 23.0f);
            noGoZone.SetType(NoGoType.e_Piggy);
            noGoZone.SetObjectId(piggyId);
            noGoZone.SetIsBouncable(true);
        }

        public float GetDisplayAngle()
        {
            return playerDisplayAngle;
        }

        public float GetMoveAngle()
        {
            return moveAngle;
        }

        public float GetScale()
        {
            return playerScale;
        }

        public float GetMinSpeedY()
        {
            return minSpeedY;
        }

        public float GetMaxSpeedY()
        {
            return maxSpeedY;
        }

        public CGPoint GetPosition()
        {
            return position;
        }

        public CGPoint GetHeadPosition()
        {
            CGPoint headPosition;
            headPosition = position;
            CGPoint headDir = Utilities.GetVectorFromAngle(maxAngleForRotateAnim[rotateAnim]);
            int absThing = (int)Utilities.GetABS(10 - rotateAnim);
            float distThing = Utilities.GetRatioP1P2(absThing, 0.0f, 11.0f);
            float distToHead = 30.0f - (15.0f * distThing);
            headDir.x *= distToHead;
            headDir.y *= distToHead;
            headPosition.x += headDir.x;
            headPosition.y += headDir.y;
            return headPosition;
        }

        public CGPoint GetPositionForScrollOffset()
        {
            return Utilities.CGPointMake(position.x + xScrollLook, position.y + (Utilities.GetYOffsetFromHeight(positionZ) * 0.9f));
        }

        public CGPoint GetSpeed()
        {
            return speed;
        }

        public CGPoint GetActualSpeed()
        {
            return actualSpeed;
        }

        public CGPoint GetDesiredSpeed()
        {
            return desiredSpeed;
        }

        public CGPoint GetScreenPosition()
        {
            return screenPos;
        }

        public CGPoint GetNormalisedSpeed()
        {
            if ((speed.y == 0.0f) && (speed.x == 0.0f)) {
                return normalisedSpeed;
            }

            if (normalisedSpeed.x == -2.0f) normalisedSpeed = Utilities.Normalise(speed);

            return normalisedSpeed;
        }

        public float GetDistanceLastFrame()
        {
            if (distanceLastFrame == -1) {
                distanceLastFrame = Utilities.GetDistanceP1(position, prevPlayerPosition);
                return distanceLastFrame;
            }
            else {
                return distanceLastFrame;
            }

        }

        public void FallenOffBuilding()
        {
            timeOnRoof = 0.0f;
            if (speed.y > 5.0f) {
                float factor = 2.0f * Utilities.GetRatioP1P2(speed.y, 5.0f, 12.0f);
                speed.y -= factor;
            }

            onRoof = -1;
        }

        public float GetGroundLevel()
        {
            return groundLevel;
        }

        public void SetGroundLevel(float inLevel)
        {
            groundLevel = inLevel;
        }

        public void SetFlowerCliff(int inOnCliff)
        {
            inRiver = inOnCliff;
        }

        public void ShowObjects()
        {
        }

        public CGPoint GetPrevPlayerPosition()
        {
            return prevPlayerPosition;
        }

        public void SetPlayerPosition(CGPoint newPos)
        {
            position = newPos;
        }

        public void StartFalling()
        {
        }

        public void HitIcyPuddle()
        {
        }

        public void SetNewState(PlayerState instate)
        {
            if (instate != state) {
                if (state == PlayerState.kPlayerMoving_CrashingThroughHedge) {
                    if (controlFaceAngle) {
                        controlFaceAngle = false;
                    }

                }

            }

            state = instate;
            stateTimer = 0;
            if (state == PlayerState.kPlayerMoving_InAir) numBounces = 0;

        }

        public void CrashingThroughHedge(float yPos)
        {
            if (state != PlayerState.kPlayerMoving_CrashingThroughHedge) {
                controlFaceAngle = true;
                faceAngleControlled = Constants.PI_;
                hitHedge = true;
				if (racingBrain != null)
	                racingBrain.HitHedge();
                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_HitHedge, 0.7f, position);
            }

            this.SetNewState(PlayerState.kPlayerMoving_CrashingThroughHedge);
            fadingOutBushCrash = 1.0f;
            yBushPosition = yPos + 16;
            xBushPosition = position.x;
            speed.x *= 0.1f;
            speed.y *= 0.2f;
            powerSkidYLess = 0;
            powerSkidYLessDesired = 0;
        }

        public void SetPiggyAngleForShadow()
        {
            desiredSpeedForAngleDisplay.y = 1.5f;
            desiredSpeedForAngleDisplay.x = 10.0f * (Utilities.GetRatioP1P2((float) rotateAnim, 0.0f, 31.0f) - 0.5f);
        }

/*        public void GotNetworkPlayerData(NetworkPlayerInfo pInfo)
        {
            #if MULTIPLAYER_ENABLED
                float timeNowHere = (float)(DateTime.Now.TimeOfDay.Milliseconds - (Globals.g_world.game).RaceStartedAtTime());
                const float kNetworkPlayerDisplayTimeBehind = 0.2f;
                float timeTilPoint = (pInfo.raceTimer + kNetworkPlayerDisplayTimeBehind) - timeNowHere;
                int numFrames = (timeTilPoint / Constants.kFrameRate);
                if (numFrames <= 1) {
                }

                networkPlayerInterpolating = numFrames;
                networkSentSpeed = pInfo.speed;
                netTiltSpeed.x = (pInfo.tilt.x - synthesizedTilt.x) / ((float) numFrames);
                netTiltSpeed.y = (pInfo.tilt.y - synthesizedTilt.y) / ((float) numFrames);
                speed.x = (pInfo.position.x - position.x) / ((float) numFrames);
                speed.y = (pInfo.position.y - position.y) / ((float) numFrames);
                positionZ = 0.0f;
            #endif

        }*/

        public void CheckLineCrossAchievementsPiggy()
        {
            int realLevelId = LevelBuilder_Ross.levelOrder[(Globals.g_world.game).playingLevel];
            if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne) {
                if (gotWet) {
                    ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PigPush);
                }

            }

        }

        public void CheckLineCrossAchievements()
        {
            ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_Beat1Pig);
            if ((Globals.g_world.game).playingLevel > 11) {
                if (finishPosition == 1) {
                    ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_Beat3Pigs);
                }

            }

            int realLevelId = LevelBuilder_Ross.levelOrder[(Globals.g_world.game).playingLevel];
            if (finishPosition == 1) {
                if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud_TheWoods) {
                    if (!hitTree) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_WinSnowForestNoTrees);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop) {
                    if (!gotWet) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_WinHogzwallopNotWet);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud10_3_PumpkinJumps) {
                    if (!hitVeg) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_WinPumpkinJumpsNoPumpkins);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville) {
                    if (!hitHouse) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_WinTrottervilleNoHouse);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud3_8_PenCup_Race8_Weave) {
                    if (!hitFlock) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_WeaveMagic);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass_DuckpondDance) {
                    if (!gotWet) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_DryDucks);
                    }

                }

            }

            if (true) {
                if (numHitAppleTrees >= 5) {
                    ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_Hit5AppleTrees);
                }

                if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers) {
                    if (!hitFlowers) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PassDayDreamNoFlowers);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge) {
                    if (!hitVeg) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PassVegDodgeNoVeg);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud_MudVille) {
                    if (!hitHouse) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PassMudvilleNoHouse);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass6_6_StrCup_Race6_MazyD) {
                    if (!hitHedge) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PassMazyDazyNoHedge);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud_BarrelMaze) {
                    if (!hitBarrel) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_BarrelMaze);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud3_6_PenCup_Race6_PCurvy) {
                    if (!hitFlock) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PassPCurvyNoFlock);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud7_8_SquashDodge) {
                    if (!hitVeg) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PassSquashDodgeNoVeg);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud3_7_PenCup_Race7_Migration) {
                    if (!hitMud) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PassMigrationNoMud);
                    }

                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep) {
                    if (!hitFlock) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_PassRoadSheepNoSheep);
                    }

                }

            }

        }

        public void HasCrossedLine()
        {
            if (this == (Globals.g_world.game).player) {
                if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                    this.CheckLineCrossAchievements();
                }

            }

            xScrollLook = 0.0f;
            this.EndBoostArrow();
        }

        public void SetupRacingBrain()
        {
            if (racingBrain == null) {
                racingBrain = new RacingBrain();
            }

        }

        public void SetStartPosition(CGPoint inPosition)
        {
            position = inPosition;
			if (noGoZone != null)
			{
	            noGoZone.SetMapPosition(position);
			}
            prevPlayerPosition = position;
            shadowScreenPosition = position;
        }

        public void PlaceTrackPiece()
        {
            TextureType nextTrackTexture = TextureType.kTexture_Invalid;
            CGPoint offset;
            float rotation;
            float alpha;
            if (inCowPatTimer > 0) {
                nextTrackTexture = TextureType.kTexture_TrackSmudged;
                rotation = -moveAngle;
                offset = Utilities.CGPointMake(0, 0);
                const float kSolidTime = 0.7f;
                alpha = 0.2f + (0.8f * Utilities.GetRatioP1P2(inCowPatTimer, kSolidTime, kPatSlideTime));
                (Globals.g_world.game).AddMapObjectP1P2P3P4P5(nextTrackTexture, (int) position.x + ((int) offset.x), (int) position.y + ((int) offset.y), 
                  ListType.e_RenderTracks, rotation, alpha);
            }

            if (inCowPatTimer < (kPatSlideTime / 2)) {
                alpha = 1.0f;
                rotation = 0;
                if (whichStep == 0) {
                    whichStep = 1;
                    nextTrackTexture = TextureType.kTexture_Footstep1 + Utilities.GetRand( 2);
                    CGPoint direction = Utilities.GetVectorFromAngle(moveAngle + (Constants.PI_ / 2));
                    offset = Utilities.CGPointMake(direction.x * 4, direction.y * 4);
                }
                else {
                    whichStep = 0;
                    nextTrackTexture =  TextureType.kTexture_Footstep1 + Utilities.GetRand( 2);
                    CGPoint direction = Utilities.GetVectorFromAngle(moveAngle + (Constants.PI_ / 2));
                    offset = Utilities.CGPointMake(direction.x * -4, direction.y * -4);
                }

                int mId = (Globals.g_world.game).AddMapObjectP1P2P3P4P5(nextTrackTexture, (int) position.x + ((int) offset.x), (int) position.y + ((int) offset.y), 
                   ListType.e_RenderTracks, rotation, alpha);
                if (mId != -1) {
                    if ((((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneIce) || (((Globals.g_world.game).lBuilder).currentScene == (int)
                      SceneType.kSceneDesert)) {
                        if (Globals.g_world.artLevel == 0) {
                            if ((Globals.g_world.game).numPlayersOnScreen >= 3) {
                                if (Globals.g_world.mapObjectAppearDistance >= 800) {
                                    ((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.15f);
                                }
                                else {
                                    ((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.1f);
                                }

                            }
                            else ((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.06f);

                        }
                        else ((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.02f);

                    }
                    else {
                        if (Globals.g_world.artLevel == 0) {
                            if ((Globals.g_world.game).numPlayersOnScreen >= 3) {
                                if (Globals.g_world.mapObjectAppearDistance >= 800) {
                                    ((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.15f);
                                }
                                else {
                                    ((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.1f);
                                }

                            }
                            else ((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.06f);

                        }

						//TRACKS ALPHA SPEED !

                        else ((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.025f);

                    }

                      //((Globals.g_world.game).GetMapObject(mId)).SetAlphaSpeed(0.0f);
					
					
					
//                    ((Globals.g_world.game).GetMapObject(mId)).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass));
                    ((Globals.g_world.game).GetMapObject(mId)).SetAtlas(Globals.g_world.game.gameThingsAtlas);

					if (inVegFootsteps == 0) {
                        if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                            ((Globals.g_world.game).GetMapObject(mId)).SetSubTextureId((int)World.Enum3.kGTGrass_Footstep1 + Utilities.GetRand( 2));
                        }
                        else {
                            ((Globals.g_world.game).GetMapObject(mId)).SetSubTextureId((int)World.Enum2.kGTMud_Footstep1 + Utilities.GetRand( 2));
                        }

                    }

                    if (inVegFootsteps > 0) {
                        inVegFootsteps--;
                        ((Globals.g_world.game).GetMapObject(mId)).SetSubTextureId(inVegFootstepSubtextureId);
                    }

                }

            }

        }

        public bool CanPlaceTrackPieceOnThisTile()
        {
            int tileId = (((Globals.g_world.game).tileMap).GetTileGrid()).GetTileIdP1(xCurrentTile, yCurrentTileForTileId);
            if ((tileId >= (int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile) && (tileId <= (int)TileMap.Enum1.kTile_FarmAtlasHay3)) {
                return false;
            }
            else if ((tileId >= (int)TileMap.Enum1.kTile_FarmAtlasHay9) && (tileId <= (int)TileMap.Enum1.kTile_FarmAtlasHay11)) {
                return false;
            }

            if ((currentTileIdObject == (int) ObjectType.kOT_House) || (currentTileIdObject == (int) ObjectType.kOT_Barn) || (currentTileIdObject == (int)
              ObjectType.kOT_BigSidewaysShed) || (onRoad)) {
                return false;
            }

            return true;
        }

        public void SetEndOfRace()
        {
            this.EndSwimmingSound();
            this.EndBoostArrowSound();
        }

        public void SetupTopLateralSpeed()
        {
            const float maxXSpeed = 6.5f;
            topLateralSpeed = maxXSpeed;
        }

        public float GetWhiteStarExtraSpeed()
        {
            return ((float) maxSpeedExtraSpeed * whiteStarSpeedAddition);
        }

        public void SetupPlayerSpeed()
        {
            kFinalSpeedMultiplier = 1.0f;
            kPlayerAccelerationBoostArrow = 0.06f;
            whiteStarSpeedAddition = Constants.PLAYER_WHITE_STAR_SPEED;
            lateralControlAcceleration = 1.2f;
            thumbControlMaxTimePressing = 0.08f;
            this.SetupTopLateralSpeed();
            SpeedUpProgressEnum speedUp = ((Globals.g_world.frontEnd).profile).speedUpProgress;
            if (true)//!((Globals.g_world.frontEnd).profile).preferences.diffEasy) 
			{
                if (speedUp == SpeedUpProgressEnum.kSpeedUp_SecondSpeedBoost) {
                    kFinalSpeedMultiplier = Constants.PLAYER_MAX_SPEED - 1.2f;
                    topLateralSpeed *= 1.0f;
                    lateralControlAcceleration = 0.8f;
                    thumbControlMaxTimePressing = 0.08f;
                }
                else if (speedUp == SpeedUpProgressEnum.kSpeedUp_ThirdSpeedBoost) {
                    kFinalSpeedMultiplier = Constants.PLAYER_MAX_SPEED;
                    topLateralSpeed *= 1.0f;
                    lateralControlAcceleration = 1.0f;
                    thumbControlMaxTimePressing = 0.08f;
                }
                else {
                    Globals.Assert(false);
                }

            }
            else {
            }

            if (playerType == (int) PlayerType.kPlayerSheep) {

                #if SLOWER_SHEEP
                    kFinalSpeedMultiplier *= Constants.SLOWER_SHEEP_VALUE;
                    whiteStarSpeedAddition *= Constants.SLOWER_SHEEP_VALUE;
                    lateralControlAcceleration *= Constants.SLOWER_SHEEP_VALUE;
                #endif

            }

            #if RUN_AND_RECORD_PIG_TIMES
                kFinalSpeedMultiplier *= 0.4f;
                whiteStarSpeedAddition *= 0.4f;
                lateralControlAcceleration *= 0.4f;
            #endif

            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMoon) {
            }

            #if MAKE_THE_SHEEP_FASTER
                kFinalSpeedMultiplier *= 2.0f;
            #endif

            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneIce) {
                kFinalSpeedMultiplier *= 1.1f;
            }

        }

        public void SetupMaxRotateAnimAngles_Piggy()
        {
            float biggerGap = Constants.PI_ / 16.0f;
            float smallerGap = Constants.PI_ / 32.0f;
            float currentPosition = 0.5f * Constants.PI_;
            currentPosition += smallerGap;
            int whichAnim = 20;
            for (int i = 0; i < 6; i++) {
                maxAngleForRotateAnim[whichAnim] = currentPosition;
                currentPosition += biggerGap;
                whichAnim--;
            }

            currentPosition -= (smallerGap / 2.0f);
            for (int i = 6; i < 14; i++) {
                maxAngleForRotateAnim[whichAnim] = currentPosition;
                currentPosition += smallerGap;
                whichAnim--;
            }

            currentPosition += smallerGap;
            for (int i = 14; i < 21; i++) {
                maxAngleForRotateAnim[whichAnim] = currentPosition;
                currentPosition += biggerGap;
                whichAnim--;
            }

            Globals.Assert(whichAnim == -1);
            for (int i = 0; i < (int)Enum.kMaxRotateAnims - 1; i++) {
                float halfWay = maxAngleForRotateAnim[i] + maxAngleForRotateAnim[i + 1];
                halfWay /= 2.0f;
                playerFacingAngle[i] = halfWay;
            }

            playerFacingAngle[(int)Enum.kMaxRotateAnims - 2] = 1.56f;
        }

        public void SetupAnimationOffsets()
        {
            for (int r = 0; r < (int)Enum.kMaxRotateAnims; r++) {
                for (int m = 0; m < (int)Enum.kMaxRunAnims; m++) {
                    animationFrameOffset[r, m] = Utilities.CGPointMake(0, 0);
                }

            }

        }

        public void ShiftAnimationForward(float distance)
        {
            float biggerGap = Constants.PI_ / 16.0f;
            float smallerGap = Constants.PI_ / 32.0f;
            float currentPosition = 0.5f * Constants.PI_;
            for (int r = 0; r < (int)Enum.kMaxRotateAnims; r++) {
                CGPoint angleVector = Utilities.GetVectorFromAngle(currentPosition);
                for (int m = 0; m < (int)Enum.kMaxRunAnims; m++) {
                    animationFrameOffset[r, m].x += (angleVector.x * distance);
                    animationFrameOffset[r, m].y += (angleVector.y * distance);
                }

                if (r > 13) {
                    currentPosition += biggerGap;
                }
                else if (r > 5) {
                    currentPosition += smallerGap;
                }
                else {
                    currentPosition += biggerGap;
                }

            }

        }

        public void SetupAnimationOffsets_Pig()
        {
            CGPoint[,] xyGap = new CGPoint[(int)Enum.kMaxRotateAnims, (int)Enum.kMaxRunAnims];
            CGPoint[,] spriteSize = new CGPoint[(int)Enum.kMaxRotateAnims, (int)Enum.kMaxRunAnims];
            float[,] xGapMirrorThing = new float[(int)Enum.kMaxRotateAnims, (int)Enum.kMaxRunAnims];
            int rAnim = 1;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -14.1f;
            xGapMirrorThing[rAnim, 2] = -10.3f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -14.4f;
            xGapMirrorThing[rAnim, 2] = -9.9f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -15.2f;
            xGapMirrorThing[rAnim, 2] = -8.8f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -14.9f;
            xGapMirrorThing[rAnim, 2] = -8.1f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -15.3f;
            xGapMirrorThing[rAnim, 2] = -6.8f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -11.1f;
            xGapMirrorThing[rAnim, 2] = -2.9f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -8.0f;
            xGapMirrorThing[rAnim, 2] = -2.1f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -7.8f;
            xGapMirrorThing[rAnim, 2] = -2.0f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -4.4f;
            xGapMirrorThing[rAnim, 2] = 0.2f;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = 2.8f;
            xGapMirrorThing[rAnim, 2] = 4.4f;
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(4, 16.6f);
            xyGap[rAnim, 2] = Utilities.CGPointMake(3.1f, 16.6f);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(147, 78);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(149, 71);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(138, 71);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(4, 16.5f);
            xyGap[rAnim, 2] = Utilities.CGPointMake(3.0f, 17);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(146, 78);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(148, 72);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(136, 71);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(5.3f, 15.5f);
            xyGap[rAnim, 2] = Utilities.CGPointMake(3.7f, 17.8f);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(144, 78);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(144, 78);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(133.4f, 75);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(5.3f, 15.5f);
            xyGap[rAnim, 2] = Utilities.CGPointMake(3.9f, 17.6f);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(141, 81);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(141, 84);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(131.4f, 80);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(5.9f, 15);
            xyGap[rAnim, 2] = Utilities.CGPointMake(4, 17.9f);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(141, 89);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(136, 91);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(127.7f, 86.8f);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(6, 13);
            xyGap[rAnim, 2] = Utilities.CGPointMake(4.3f, 14.7f);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(132, 100);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(121, 105);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(119, 98);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(5.2f, 5.5f);
            xyGap[rAnim, 2] = Utilities.CGPointMake(3.8f, 9.1f);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(119, 109);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(106, 119);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(108, 112);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(7, -3.5f);
            xyGap[rAnim, 2] = Utilities.CGPointMake(9.5f, 2);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(101, 122);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(95, 130);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(97, 120);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(9.7f, -4.5f);
            xyGap[rAnim, 2] = Utilities.CGPointMake(12.7f, 1.0f);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(90, 134);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(85, 139);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(87, 129);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(12.3f, -6);
            xyGap[rAnim, 2] = Utilities.CGPointMake(16.1f, 0.8f);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(80, 143);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(73.6f, 144.7f);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(74.7f, 136.3f);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(14.7f, -9.8f);
            xyGap[rAnim, 2] = Utilities.CGPointMake(19.1f, 1);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(71, 147.7f);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(75, 147);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(67, 139);
            Globals.Assert((int)Enum.kMaxRotateAnims > 17);
            int numRunAnims = 3;
            Globals.Assert(10 == ((numPlayerRotateAnims - 1) / 2));
            for (int r = 0; r < 10; r++) {
                int mirroredRotateFrame = numPlayerRotateAnims - r;
                for (int m = 0; m < numRunAnims; m++) {
                    xyGap[r + 1, m] = xyGap[mirroredRotateFrame, m];
                    spriteSize[r + 1, m] = spriteSize[mirroredRotateFrame, m];
                    xyGap[r + 1, m].x = xGapMirrorThing[r + 1, m];
                }

            }

            for (int r = 0; r < numPlayerRotateAnims; r++) {
                CGPoint[] centrePosition = new CGPoint[(int)Enum.kMaxRunAnims];
                CGPoint averageCentrePosition = Utilities.CGPointMake(0, 0);
                for (int m = 0; m < numRunAnims; m++) {
                    centrePosition[m] = Utilities.CGPointMake(xyGap[r + 1, m].x + (spriteSize[r + 1, m].y / 2.0f), xyGap[r + 1, m].y + (spriteSize[r + 1, m].x / 2.0f));
                    averageCentrePosition.x += centrePosition[m].x;
                    averageCentrePosition.y += centrePosition[m].y;
                }

                averageCentrePosition.x /= (float) numRunAnims;
                averageCentrePosition.y /= (float) numRunAnims;
                for (int m = 0; m < numRunAnims; m++) {
                    animationFrameOffset[r, m] = Utilities.CGPointMake(centrePosition[m].x - averageCentrePosition.x, centrePosition[m].y - averageCentrePosition.y);
                }

            }

            for (int r = 0; r < (int)Enum.kMaxRotateAnims; r++) {
                for (int m = 0; m < (int)Enum.kMaxRunAnims; m++) {
                    animationFrameOffset[r, m].x *= 0.5f;
                    animationFrameOffset[r, m].y *= 0.5f;
                }

            }

        }

        public void SetupAnimationOffsets_Shaun()
        {
            CGPoint[,] xyGap = new CGPoint[(int)Enum.kMaxRotateAnims+1, (int)Enum.kMaxRunAnims+1];
            CGPoint[,] spriteSize = new CGPoint[(int)Enum.kMaxRotateAnims+1, (int)Enum.kMaxRunAnims+1];
            float[,] xGapMirrorThing = new float[(int)Enum.kMaxRotateAnims+1, (int)Enum.kMaxRunAnims+1];
            int rAnim = 1;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = 1;
            xGapMirrorThing[rAnim, 2] = 2;
            xGapMirrorThing[rAnim, 3] = 9;
            xGapMirrorThing[rAnim, 4] = 4;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -2;
            xGapMirrorThing[rAnim, 2] = 0;
            xGapMirrorThing[rAnim, 3] = 6;
            xGapMirrorThing[rAnim, 4] = 5;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -3;
            xGapMirrorThing[rAnim, 2] = -2;
            xGapMirrorThing[rAnim, 3] = 3;
            xGapMirrorThing[rAnim, 4] = 5;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = -2;
            xGapMirrorThing[rAnim, 2] = 0;
            xGapMirrorThing[rAnim, 3] = 2;
            xGapMirrorThing[rAnim, 4] = 4;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = 0;
            xGapMirrorThing[rAnim, 2] = 3;
            xGapMirrorThing[rAnim, 3] = 1;
            xGapMirrorThing[rAnim, 4] = 4;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = 2;
            xGapMirrorThing[rAnim, 2] = 6;
            xGapMirrorThing[rAnim, 3] = 0;
            xGapMirrorThing[rAnim, 4] = 4;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = 4;
            xGapMirrorThing[rAnim, 2] = 9;
            xGapMirrorThing[rAnim, 3] = 0;
            xGapMirrorThing[rAnim, 4] = 1;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = 5;
            xGapMirrorThing[rAnim, 2] = 11;
            xGapMirrorThing[rAnim, 3] = 1;
            xGapMirrorThing[rAnim, 4] = 3;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = 6;
            xGapMirrorThing[rAnim, 2] = 12;
            xGapMirrorThing[rAnim, 3] = 1;
            xGapMirrorThing[rAnim, 4] = 2;
            rAnim++;
            xGapMirrorThing[rAnim, 0] = 0;
            xGapMirrorThing[rAnim, 1] = 8;
            xGapMirrorThing[rAnim, 2] = 13;
            xGapMirrorThing[rAnim, 3] = 1;
            xGapMirrorThing[rAnim, 4] = 3;
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(8, -8);
            xyGap[rAnim, 2] = Utilities.CGPointMake(8, -17);
            xyGap[rAnim, 3] = Utilities.CGPointMake(2, -20);
            xyGap[rAnim, 4] = Utilities.CGPointMake(3, -16);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(160, 78);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(166, 62);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(171, 61);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(170, 76);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(170, 73);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(2, -8);
            xyGap[rAnim, 2] = Utilities.CGPointMake(2, -22);
            xyGap[rAnim, 3] = Utilities.CGPointMake(2, -28);
            xyGap[rAnim, 4] = Utilities.CGPointMake(3, -20);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(143, 78);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(148, 68);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(160, 63);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(162, 75);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(158, 73);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-1, -8);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-3, -18);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-3, -23);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-2, -17);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(150, 81);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(155, 77);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(166, 73);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(164, 85);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(162, 81);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-2, -8);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-4, -18);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-4, -22);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-2, -17);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(145, 91);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(151, 87);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(161, 84);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(158, 94);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(157, 90);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-3, -8);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-5, -19);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-6, -24);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-3, -17);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(138, 100);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(148, 99);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(157, 96);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(154, 106);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(152, 101);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-3, -7);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-6, -18);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-7, -24);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-5, -17);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(123, 116);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(135, 117);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(145, 116);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(144, 123);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(138, 117);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-4, -6);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-8, -16);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-8, -21);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-6, -16);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(110, 128);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(122, 132);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(132, 133);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(132, 135);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(123, 130);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-5, -5);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-9, -16);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-11, -22);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-8, -15);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(94, 137);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(104, 143);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(115, 146);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(117, 147);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(104, 140);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-5, -5);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-10, -15);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-12, -20);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-8, -15);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(79, 144);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(85, 152);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(96, 156);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(101, 154);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(89, 148);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-6, 1);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-10, -8);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-11, -13);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-9, -8);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(69, 150);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(67, 157);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(77, 161);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(84, 155);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(74, 155);
            rAnim++;
            xyGap[rAnim, 0] = Utilities.CGPointMake(0, 0);
            xyGap[rAnim, 1] = Utilities.CGPointMake(-6, 1);
            xyGap[rAnim, 2] = Utilities.CGPointMake(-11, -3);
            xyGap[rAnim, 3] = Utilities.CGPointMake(-12, -4);
            xyGap[rAnim, 4] = Utilities.CGPointMake(-10, -1);
            spriteSize[rAnim, 0] = Utilities.CGPointMake(69, 155);
            spriteSize[rAnim, 1] = Utilities.CGPointMake(66, 158);
            spriteSize[rAnim, 2] = Utilities.CGPointMake(66, 162);
            spriteSize[rAnim, 3] = Utilities.CGPointMake(67, 157);
            spriteSize[rAnim, 4] = Utilities.CGPointMake(67, 159);
            Globals.Assert(10 == ((numPlayerRotateAnims - 1) / 2));
            int numRunAnims = 5;
            for (int r = 0; r < 10; r++) {
                int mirroredRotateFrame = numPlayerRotateAnims - r;
                for (int m = 0; m < numRunAnims; m++) {
                    xyGap[r + 1, m] = xyGap[mirroredRotateFrame, m];
                    spriteSize[r + 1, m] = spriteSize[mirroredRotateFrame, m];
                    xyGap[r + 1, m].x = xGapMirrorThing[r + 1, m];
                }

            }

            for (int r = 0; r < (int)Enum.kMaxRotateAnims; r++) {
                CGPoint[] centrePosition = new CGPoint[(int)Enum.kMaxRunAnims];
                CGPoint averageCentrePosition = Utilities.CGPointMake(0, 0);
                for (int m = 0; m < numRunAnims; m++) {
                    centrePosition[m] = Utilities.CGPointMake(xyGap[r + 1, m].x + (spriteSize[r + 1, m].y / 2.0f), xyGap[r + 1, m].y + (spriteSize[r + 1, m].x / 2.0f));
                    averageCentrePosition.x += centrePosition[m].x;
                    averageCentrePosition.y += centrePosition[m].y;
                }

                averageCentrePosition.x /= (float) numRunAnims;
                averageCentrePosition.y /= (float) numRunAnims;
                for (int m = 0; m < numRunAnims; m++) {
                    animationFrameOffset[r, m] = Utilities.CGPointMake(centrePosition[m].x - averageCentrePosition.x, centrePosition[m].y - averageCentrePosition.y);
                }

            }

            for (int r = 0; r < (int)Enum.kMaxRotateAnims; r++) {
                for (int m = 0; m < (int)Enum.kMaxRunAnims; m++) {
                    animationFrameOffset[r, m].x *= 0.5f;
                    animationFrameOffset[r, m].y *= 0.5f;
                }

            }

        }
		
		public void StopRender()
        {
			for (int i = 0; i < (int)PlayerBillboards.kNumBillboards; i++)
			{
				if (myAtlasBillboard[i] != null)
				{
					myAtlasBillboard[i].StopRender();
				}
			}
		}

        public void SetStartOfRace()
        {
			if (playerType == (int) PlayerType.kPlayerSheep) {
                shadowRotScale = 2.0f;
			}
			else
                shadowRotScale = 1.0f;
			
			for (int i = 0; i < (int)PlayerBillboards.kNumBillboards; i++)
			{			
				if (myAtlasBillboard[i] == null)
				{
										PlayerBillboards playerBType = (PlayerBillboards)i;
										myAtlasBillboard[i] = new Billboard("player" + playerId.ToString() + playerBType.ToString());
				}
								else
								{
										myAtlasBillboard[i].StopRender();
								}
			}
			
			this.StopRenderSpritesInFrontOfPlayer();

			myAtlasBillboard[(int)PlayerBillboards.kBB_Me].SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_PiggyAnims));
			myAtlasBillboard[(int)PlayerBillboards.kBB_Me].SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_PiggyAnims),0);
			myAtlasBillboard[(int)PlayerBillboards.kBB_Shadow].SetAtlas(Globals.g_world.game.gameThingsAtlas);
			myAtlasBillboard[(int)PlayerBillboards.kBB_Shadow].SetDetailsFromAtlas(Globals.g_world.game.gameThingsAtlas,0);
			myAtlasBillboard[(int)PlayerBillboards.kBB_ThingBefore].SetAtlas(Globals.g_world.game.gameThingsAtlas);
			myAtlasBillboard[(int)PlayerBillboards.kBB_ThingBefore].SetDetailsFromAtlas(Globals.g_world.game.gameThingsAtlas,0);
			myAtlasBillboard[(int)PlayerBillboards.kBB_ThingAfter].SetAtlas(Globals.g_world.game.gameThingsAtlas);
			myAtlasBillboard[(int)PlayerBillboards.kBB_ThingAfter].SetDetailsFromAtlas(Globals.g_world.game.gameThingsAtlas,0);
			
			ZAtlas spriteTilesAtlas;
            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
				spriteTilesAtlas = Globals.g_world.GetAtlas(AtlasType.kAtlas_GrassSpriteTiles);
			}
			else
			{
				spriteTilesAtlas = Globals.g_world.GetAtlas(AtlasType.kAtlas_MudSpriteTiles);
			}
			
			for (int i = (int)PlayerBillboards.kBB_SpriteTile1; i <= (int)PlayerBillboards.kBB_SpriteTile6;i++)
			{
				myAtlasBillboard[i].SetAtlas(spriteTilesAtlas);
				myAtlasBillboard[i].SetDetailsFromAtlas(spriteTilesAtlas,0);
			}
			
            hitFlowers = false;
            hitHouse = false;
            hitMud = false;
            hitFlock = false;
            hitHedge = false;
            hitVeg = false;
            hitTree = false;
            gotWet = false;
            hitBarrel = false;
            numRainbowBoosts = 0;
            numHitAppleTrees = 0;
            timeOnRoof = 0.0f;
            xScrollLook = 0.0f;
            jumpAdjusting = false;
            float randExtra = (float)(Utilities.GetRand( 5)) / 10.0f;
            trickInfo.timeToStartNextPhase = 1.3f + randExtra;
            moveAngle = Constants.PI_;
            prevMoveAngle = moveAngle;
            controlFaceAngle = false;
            inVegFootsteps = 0;
            jumpCelebrateCancelled = false;
            trickInfo.trickState = TrickState.e_NoTrick;
            manualControlOfPiggy = false;
            disableSpriteTiles = false;
            isOnScreen = true;
            finishPosition = -1;
            finishTime = -1.0f;
            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                foamyAssetId = (int)World.Enum3.kGTGrass_FoamyRatio;
            }
            else if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMud) {
                foamyAssetId = (int)World.Enum2.kGTMud_Foamy;
            }
            else {
                Globals.Assert(false);
            }

            actualSpeed = Utilities.CGPointMake(0, 0);
            bumpTilt = Utilities.CGPointMake(0, 0);
            if (((Globals.g_world.frontEnd).profile).preferences.controlTilt) humanControlType = HumanControlType.kControlHumanTilt;
            else {
                if (((Globals.g_world.frontEnd).profile).preferences.controlFinger) humanControlType = HumanControlType.kControlHumanFinger;
                else {
                    humanControlType = HumanControlType.kControlHumanThumbs;
                }

            }

            this.SetupPlayerSpeed();
            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMoon) kJumpGravity = 0.3f;
            else kJumpGravity = 0.4f;

            if (false) {
            }
            else {
                thumbControlMaximum = 1.04f;
            }

            if (humanControlType != (int) HumanControlType.kControlHumanTilt) {
                kPowerSkidAffect = 0.78f;
            }
            else {
                if (!((Globals.g_world.frontEnd).profile).preferences.tiltExpert) {
                    kPowerSkidAffect = 0.97f;
                }
                else {
                    kPowerSkidAffect = 0.68f;
                }

            }

            if (!((Globals.g_world.frontEnd).profile).preferences.tiltExpert) {
                kAccelAtMinTilt = 0.1f;
                kAccelAtMaxTilt = 0.18f;
                kAccelAtMaxTiltMinSpeed = 0.06f;
            }
            else {
                kAccelAtMinTilt = 0.03f;
                kAccelAtMaxTilt = 0.15f;
                kAccelAtMaxTiltMinSpeed = 0.04f;
            }

            netTiltSpeed = Utilities.CGPointMake(0, 0);
            networkSentSpeed = Utilities.CGPointMake(0, 0);
            networkPlayerInterpolating = 0;
            tiltingWhichWay = 0.0f;
            prevXTilt = 0.0f;
            timeTiltingInSameDirection = 0.0f;
            synthesizedTilt = Utilities.CGPointMake(0.0f, 0.0f);
            synthesizedTiltDesired = Utilities.CGPointMake(0.0f, 0.0f);
            directionButtonLeft = false;
            directionButtonRight = false;
            temporaryShadowLengthener = 1.0f;
            inMudTimer = 0.0f;
            aboveRoof = false;
            lastRockSoundTime = 0.0f;
            lastOvertakeSoundTime = 0.0f;
            isOverRiver = false;
            this.EndSwimmingSound();
            this.EndBoostArrowSound();
            whichHoof = 0;
            distanceBetweenHoofSounds = 0;
            hasPassedFinishLine = false;
            this.SetNewState(PlayerState.kPlayerMoving_Normally);
            numBounces = 0;
            timeSinceSkidParticle = 0;
            powerSkidYLessDesired = 0;
            powerSkidYLess = 0;
            onRamp = -1;
            inVenus = -1;
            onLog = -1;
            desiredSpeedForAngleDisplay.x = 0;
            desiredSpeedForAngleDisplay.y = 1;
            playerDisplayAngle = 0;
            isInFinalThird = false;
            finalThirdLine = (Globals.g_world.game).finishYPos * 0.66f;
            distSinceCloud = 0;
            isInDeepWater = false;
            maxSpeedTime = 0;
            rotateAnim = (numPlayerRotateAnims / 2);
            this.EndMaxSpeed();
            inCowPatTimer = 0;
            speedBoostTimer = 0;
            boostArrowTimer = 0;
            slowDownTimer = 0.0f;
            this.EndSpeedBoost();
            this.EndBoostArrow();
            distanceLastFrame = -1;
            normalisedSpeed.x = -2;
            animateIndex = 1;
            animateRoll = 0;
            this.SetStartPosition(Utilities.CGPointMake(192.0f, 100.0f + Constants.MOVE_PLAYER_FORWARD));
            speed = Utilities.CGPointMake(0.0f, 0.0f);
            isJumping = false;
            isJumpEnding = false;
            screenPos = Utilities.CGPointMake(0.0f, 0.0f);
            groundLevel = 0;
            prevGroundLevel = groundLevel;
            positionZ = 0;
            prevPositionZ = 0;
            inRiver = -1;
            inWaterfall = -1;
            onBridge = -1;
            inPond = -1;
            inHayStack = -1;
            onRoof = -1;
            onCliff = -1;
            moveAnim = 1;
            if (playerType == (int) PlayerType.kPlayerSheep) {
                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                    shadowSubtextureId = (int)World.Enum3.kGTGrass_ShaunShadow1 + moveAnim;
                }
                else {
                    shadowSubtextureId = (int)World.Enum2.kGTMud_ShaunShadow1 + moveAnim;
                }

                startShadowSubtextureId = shadowSubtextureId - moveAnim;
            }
            else {
                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                    shadowSubtextureId = (int)World.Enum3.kGTGrass_PiggyShadow;
                }
                else {
                    shadowSubtextureId = (int)World.Enum2.kGTMud_PiggyShadow;
                }

                startShadowSubtextureId = shadowSubtextureId;
            }

            foamyRatio = 0;
            zVelocity = 0;
            if (splashingEffectId != -1) {
                (ParticleSystemRoss.Instance()).StopParticleEffect(splashingEffectId);
                splashingEffectId = -1;
            }

            this.EndSpeedBoost();
            this.EndBoostArrow();
            if (playerType == (int) PlayerType.kPlayerPenguin) {
                kRollAnimSpeed = 12.0f;
            }
            else {
                kRollAnimSpeed = 20.0f;
            }

            this.SetupAnimationOffsets();
            if (playerType == (int) PlayerType.kPlayerSheep) {
                animStartSubtexture = 63;
                numPlayerRotateAnims = 21;
                this.SetupAnimationOffsets_Shaun();
                this.SetupMaxRotateAnimAngles_Piggy();
                this.ShiftAnimationForward(5.0f);
                numAnims = 5;
            }
            else {
                animStartSubtexture = 0;
                numPlayerRotateAnims = 21;
                this.SetupAnimationOffsets_Pig();
                this.SetupMaxRotateAnimAngles_Piggy();
                this.ShiftAnimationForward(5.0f);
                numAnims = 3;
            }

            rotateAnim = (numPlayerRotateAnims / 2);

            #if DROPBOX_ENABLED
            #endif

            #if PARTICLE_PROFILING
                ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                info.type = EffectType.kEffect_RainbowStarTrail;
                info.startPosition = position;
                info.player = this;
                (ParticleSystemRoss.Instance()).AddParticleEffect(info);
            #endif
			
			if (racingBrain != null)
			{
	            RacingBrain.RacingBrainInfo racingBrainInfo = new RacingBrain.RacingBrainInfo();
	            racingBrainInfo.myPig = this;
	            racingBrain.SetStartOfRace(racingBrainInfo);
			}
        }

        public PlayerState Getstate()
        {
            return state;
        }

        public void StartBushCrashFragments()
        {
			Debug.Log("start bush crash");
			
            if (position.y > ((Globals.g_world.game).scrollPosition.y + Globals.g_world.drawHeight + 500.0f)) {
                return;
            }

            const int kMaxNumHeads = 10;
            FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
            info.addUnderPlayer = false;
            CGPoint[] startPositionOffset = new CGPoint[kMaxNumHeads];
            int numHeads;
            numHeads = 6;
            startPositionOffset[5] = Utilities.CGPointMake(-55, -20);
            startPositionOffset[4] = Utilities.CGPointMake(-40, 0);
            startPositionOffset[3] = Utilities.CGPointMake(-10, -20);
            startPositionOffset[2] = Utilities.CGPointMake(14, -40);
            startPositionOffset[1] = Utilities.CGPointMake(0, 0);
            startPositionOffset[0] = Utilities.CGPointMake(50, -10);
            for (int i = 0; i < 6; i++) {
                startPositionOffset[i].x /= 2.0f;
                startPositionOffset[i].y /= 2.0f;
                startPositionOffset[i].y += 20.0f;
            }

            info.type = FlowerHeadType.kFlowerHead_BushFragment;
            for (int i = 0; i < numHeads; i++) {
                info.position = Utilities.CGPointMake(position.x + startPositionOffset[i].x, position.y + startPositionOffset[i].y);
                float directionMulti = 3 - (Utilities.GetABS((((float) numHeads) / 2) - ((float) i)));
                float randVelocity = (((float)(Utilities.GetRand( 4))) / 10) + 0.4f;
                directionMulti *= randVelocity;
                float circleSize = Constants.PI_ - 1;
                float perThing = circleSize / ((float) numHeads);
                float angle = (moveAngle - Constants.HALF_PI) - (circleSize / 2) + (perThing * ((float) i));
                float outSpeed = 3.2f;
                info.velocity = Utilities.GetVectorFromAngleP1(angle, outSpeed);
                info.velocity.x += (0.8f * ((Globals.g_world.GetGame()).GetPlayer()).GetSpeed().x);
                info.velocity.y += (0.8f * ((Globals.g_world.GetGame()).GetPlayer()).GetSpeed().y);
                info.velocity.x *= 0.65f;
                info.velocity.y *= 0.65f;
                info.rotation = -angle;
                info.position = Utilities.CGPointMake(info.position.x + info.velocity.x * directionMulti, info.position.y + info.velocity.y * directionMulti);
                int freeHead = (Globals.g_world.game).GetFreeFlowerHead();
                if (freeHead != -1) {
                    ((Globals.g_world.game).GetFlowerHead(freeHead)).AddToScene(info);
                }

            }

        }

        public void HitFlockSheep(float bumpPower)
        {
            if (bumpPower > 0.1f) hitFlock = true;

        }

        public void HitTree(float bumpPower)
        {
            if (bumpPower > 0.1f) hitTree = true;

        }

        public void KnockedApplesOffTree()
        {
            numHitAppleTrees++;
            if (this == (Globals.g_world.game).player) {
                if (numHitAppleTrees <= 1) {
                    ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_HitAppleTree);
                    if (!((Globals.g_world.frontEnd).profile).HasAchievementBeenSeen((int)Profile.Enum2.kAchievement_HitAppleTree)) {
                        if (Globals.g_world.artLevel > 0) {
                            ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
                        }

                    }

                }

            }

        }

        public void HitBuilding(Building inBuilding)
        {
            if ((inBuilding.type ==  BuildingType.kBuilding_Barn) || (inBuilding.type ==  BuildingType.kBuilding_House) || (inBuilding.type == 
               BuildingType.kBuilding_SideShed)) {
                hitHouse = true;
            }

        }

        public void HitChicken()
        {
            speed.y *= 0.75f;
            zVelocity = 3.0f;
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_ChickenPop);
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_ChickenSquawk1, 1.0f);
        }

        public void HitHayBale()
        {
			if (racingBrain != null)
	            racingBrain.HitGeneric(1.0f);
            zVelocity = 5.0f;
            speed.x *= 0.2f;
            speed.y *= 0.2f;
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_HitFlowers);
        }

        public void HitHayStack(int i)
        {
            this.HitHayBale();
            inHayStack = i;
        }

        public void HitCowPat(float inTime)
        {
            inCowPatTimer = kPatSlideTime * inTime;
            speedBoostTimer = 0.04f;
            speedBoostPower = speed.y + 1.0f;
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_MudSquelch1 + Utilities.GetRand( 1));
        }

        public void AddDustCloud(CGPoint where)
        {
            if (onRoof != -1) {
                Building onWhichBuilding;
                onWhichBuilding = (Globals.g_world.game).GetBuilding(onRoof);
                if (onWhichBuilding.type ==  BuildingType.kBuilding_House) {
                    FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
                    info.addUnderPlayer = true;
                    info.position = position;
                    info.velocity = speed;
                    info.rotation = 0.0f;
                    info.type = FlowerHeadType.kFlowerHead_HayBurstCloud;
                    FlowerHead hayBurst = (Globals.g_world.game).GetFreeFlowerHeadPointer();
                    if (hayBurst != null) {
                        hayBurst.AddToScene(info);
                        return;
                    }

                }
                else if (onWhichBuilding.type ==  BuildingType.kBuilding_SideShed) {
                    ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                    info.type = EffectType.kEffect_Sparks;
                    info.startPosition = where;
                    info.velocity = speed;
                    info.rotation = 1.0f;
                    (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                    return;
                }

            }

            ParticleSystemRoss.EffectInfo info2 = new ParticleSystemRoss.EffectInfo();
            info2.type = EffectType.kEffect_DustCloud;
            info2.startPosition = where;
            info2.velocity = speed;
            (ParticleSystemRoss.Instance()).AddParticleEffect(info2);
            info2.type = EffectType.kEffect_Grass;
            info2.startPosition = where;
            (ParticleSystemRoss.Instance()).AddParticleEffect(info2);
        }

        public void HitCow(float hitPower)
        {
            if (hitPower > 5) {
                this.AddDustCloud(Utilities.CGPointMake(position.x, position.y + 15));
                if (Utilities.GetRand( 2) == 0) {
                    (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_HitCow);
                }

            }

            float volume = Utilities.GetRatioP1P2(hitPower, 3, 8);
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_Land, volume);
        }

        public void HitFlowerBunch(FlowerBunch inBunch)
        {
            hitFlowers = true;
            float kVelDecrease = 0.6f;
						if (racingBrain != null)
			{

            racingBrain.HitFlowerBunch();
			}
            speed.x *= kVelDecrease;
            speed.y *= kVelDecrease;
            if (inBunch.type == FlowerBunchType.kFlowerBunch_SavannaBush) {
                zVelocity = 5.0f;
            }
            else if (inBunch.type ==  FlowerBunchType.kFlowerBunch_Daffodil) {
                zVelocity = 2.5f;
            }
            else if ((inBunch.type ==  FlowerBunchType.kFlowerBunch_Tulips) || (inBunch.type ==  FlowerBunchType.kFlowerBunch_TulipsWhite) || (
              inBunch.type ==  FlowerBunchType.kFlowerBunch_TulipsYellow) || (inBunch.type ==  FlowerBunchType.kFlowerBunch_TulipsBlue)) {
                zVelocity = 2.5f;
            }

            Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_HitFlowers, 1.0f, position);
        }

        public void GotBumped()
        {
						if (racingBrain != null)
			{

            racingBrain.HitGeneric(1.0f);
			}
        }

        public void HitVegetable(int inVegType)
        {
            hitVeg = true;
						if (racingBrain != null)
			{

            racingBrain.HitGeneric(1.0f);
			}
            if (inVegType == (int) NoGoType.e_Cauliflower) {
                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_ChickenPop, 1.0f, position);
            }
            else {
                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_MudSquelch2, 1.0f, position);
                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_HitHedge, 1.0f, position);
            }

            if (false) {
                if (inMudTimer <= 0.0f) {
                    inMudTimer = kInMudMaxTimer;
                    inMudSpeed = this.GetActualSpeed();
                    inMudFootstep = (int)World.Enum2.kGTMud_FootstepWithSquash;
                }

            }
            else {
                float kVelDecrease = 0.25f;
                speed.x *= kVelDecrease;
                speed.y *= kVelDecrease;
                zVelocity = 2.5f;
                inVegFootsteps = 25;
                if (inVegType == (int) NoGoType.e_Squash) {
                    inVegFootstepSubtextureId = (int)World.Enum2.kGTMud_FootstepWithSquash;
                }
                else if (inVegType == (int) NoGoType.e_Courgette) {
                    inVegFootstepSubtextureId = (int)World.Enum2.kGTMud_FootstepWithMarrow;
                }
                else if (inVegType == (int) NoGoType.e_Pumpkin) {
                    inVegFootstepSubtextureId = (int)World.Enum2.kGTMud_FootstepWithPumpkin;
                }
                else {
                    Globals.Assert(false);
                }

            }

        }

        public void HitGnome(bool smashed)
        {
						if (racingBrain != null)
			{

            racingBrain.HitGeneric(1.0f);
			}
            float kVelDecrease = 0.25f;
            speed.x *= kVelDecrease;
            speed.y *= kVelDecrease;
            zVelocity = 2.5f;
            if (smashed) {
                Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_GnomeSmash, Utilities.GetRandBetweenP1(0.8f, 1.0f), position);
            }

        }

        public void HitRainbow()
        {
            numRainbowBoosts++;
            if (this == (Globals.g_world.game).player) {
                if (numRainbowBoosts <= 1) {
                    ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_SpeedBoost);
                    if (!((Globals.g_world.frontEnd).profile).HasAchievementBeenSeen((int)Profile.Enum2.kAchievement_SpeedBoost)) {
                        if (Globals.g_world.artLevel > 0) {
                            ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
                        }

                    }

                }

                if (numRainbowBoosts > 30) {
                    ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_Hit30Rainbows);
                    ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
                }

            }

            speedBoostTimer = 0.6f;
            speedBoostPower = kFinalSpeedMultiplier + 5.0f;
			if (racingBrain != null)
			{
	            racingBrain.SetBoostTimer(speedBoostTimer);
	            racingBrain.SetBoostPower(5.0f);
	            racingBrain.EndSkid();
			}
            float volume = 1;
            if (controlType != (int) PlayerControlType.kControlHuman) {
            }

            Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_Rainbow, volume, position);
            if (speedBoostEffect != -1) return;

            ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
            info.type = EffectType.kEffect_RainbowStarTrail;
            info.startPosition = position;
            info.player = this;
            speedBoostEffect = (ParticleSystemRoss.Instance()).AddParticleEffect(info);
        }

        public void HitStarSpeedUp()
        {
            speedBoostTimer = 0.15f;
            speedBoostPower = kFinalSpeedMultiplier + 15.0f;
            float volume = 1;
            if (controlType != (int) PlayerControlType.kControlHuman) {
            }

            Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_HitStar, volume, position);
            if (speedBoostEffect != -1) return;

            ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
            info.type = EffectType.kEffect_RainbowStarTrail;
            info.startPosition = position;
            info.player = this;
            zVelocity = 1.4f;
            speedBoostEffect = (ParticleSystemRoss.Instance()).AddParticleEffect(info);
        }

        public void AddBoost(CGPoint boostDir)
        {
            if (controlType == PlayerControlType.kControlHuman) {
                if (boostArrowSoundId == -1) {
                    (SoundEngine.Instance()).FadeInP1((int)Audio.Enum1.kSoundEffect_RoaringFire, 0.25f);
                    ((SoundEngine.Instance()).GetFinchSound((int)Audio.Enum1.kSoundEffect_RoaringFire)).SetLooping(true);
                    boostArrowSoundId = 0;
                }

            }

            boostArrowTimer += 0.24f;
            boostArrowPower = kFinalSpeedMultiplier + 5.85f;
			if (racingBrain != null)
			{

			racingBrain.SetBoostTimer(boostArrowTimer);
            racingBrain.SetBoostPower(5.85f);
            racingBrain.EndSkid();
			}
            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_HitBoostArrow);
            if (boostArrowEffect != -1) return;

            ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
            info.type = EffectType.kEffect_BoostArrowStars;
            info.startPosition = position;
            info.player = this;
            boostArrowEffect = (ParticleSystemRoss.Instance()).AddParticleEffect(info);
        }

        public void RenderExtrasBeforePlayer()
        {
            CGPoint bushScreenPos;
            if ((state == PlayerState.kPlayerMoving_CrashingThroughHedge) || (fadingOutBushCrash > 0.0f)) {
                bushScreenPos = (Globals.g_world.game).GetScreenPosition(Utilities.CGPointMake(xBushPosition, yBushPosition + 12.0f));
                if ((Globals.g_world.game).IsOnScreenP1(bushScreenPos, 50.0f)) {
					
					
                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard[(int)PlayerBillboards.kBB_ThingBefore], Utilities.CGPointMake(bushScreenPos.x, bushScreenPos.y), 1.0f,0.0f,0.0f,fadingOutBushCrash,
                      (int)World.Enum3.kGTGrass_BushCrashBottom);
                   // (DrawManager.Instance()).AddTextureToListAlphaP1P2(myAtlasBillboard[(int)PlayerBillboards.kBB_ThingBefore], Utilities.CGPointMake(bushScreenPos.x, bushScreenPos.y), fadingOutBushCrash,
                     // (int)World.Enum3.kGTGrass_BushCrashBottom);
                }

            }

            if (foamyRatio > 0) {
                float foamySize;
                if (Globals.deviceIPad) {
                    foamySize = 100.0f * Constants.kScreenMultiplierForShorts;
                }
                else {
                    foamySize = 50.0f * Constants.kScreenMultiplierForShorts;
                }
				foamySize *= 0.5f;
//kplayersheep
                (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard[(int)PlayerBillboards.kBB_ThingBefore],screenPos, 0.6f, Constants.PI_ - playerDisplayAngle, foamySize * playerScale, foamyRatio,
                  foamyAssetId);
            }

        }

        public void RenderNumber()
        {
            if ((Globals.g_world.game).IsOnScreenNewP1(screenPos, 40.0f)) {
                (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(screenPos, 0.4f, 0.4f, playerId - 1);
            }

        }
		
		public void Dereference()
        {
			for (int i = 0; i < (int)PlayerBillboards.kNumBillboards; i++)
			{
				if (myAtlasBillboard[i] != null)
				{
					myAtlasBillboard[i].Dealloc();			
					myAtlasBillboard[i] = null;			
				}
			}
        }


        public void RenderPlayer()
        {
            int animIndex;
            if ((trickInfo.trickState == TrickState.e_NoTrick) || (trickInfo.trickState == TrickState.e_WaitingToStart)) 
			{
                animIndex = rotateAnim + animStartSubtexture + (moveAnim * numPlayerRotateAnims);
            }
            else {
                animIndex = (trickInfo.trickAnim).GetSubTextureId();
            }

           // (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(screenPos, playerScale, playerScale, animIndex);
           
			if (false)//!Globals.g_world.game.IsOnScreenNewP1(screenPos,50.0f))
			{		
				this.StopRender();
			}
			else
			{
				(DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard[(int)PlayerBillboards.kBB_Me], screenPos, playerScale, 0.0f, 0.0f, 1.0f,animIndex);
			}
            #if DEBUG_DRAW_PLAYER_HEAD
                CGPoint headPos = this.GetHeadPosition();
                CGPoint headScreen = (Globals.g_world.game).GetScreenPosition(headPos);
                (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(headScreen, playerScale / 2.0f, playerScale / 2.0f, 184);
            #endif

        }

        public void StopRenderSpritesInFrontOfPlayer()
        {
					for (int i = 0; i < 6; i++)
					{
						myAtlasBillboard[i + (int)PlayerBillboards.kBB_SpriteTile1].StopRender();
					}			
		}		
		
		//If player has moved from normal to other level - remove pre-sprites (hedges etc...)
        public void PreRenderRemoveSprites()
        {
			PlayerHeight oldHeight = playerHeight;
			for(int i =0 ;i < 3;i++)
			{
	            if ((positionZ >= Globals.g_world.game.playerHeightMin[i]) && (	positionZ < Globals.g_world.game.playerHeightMax[i])) 
				{
					playerHeight = (PlayerHeight) i;	
				}
			}
			
			if (playerHeight != oldHeight)
			{
				if (oldHeight == PlayerHeight.t_Normal)
				{
				//	Debug.Log("PreRenderRemoveSprites for player " + playerId);
					this.StopRenderSpritesInFrontOfPlayer();
				}
			}
		}		
		
        public void RenderExtrasAfterPlayer()
        {
            CGPoint bushScreenPos;
            if ((state == PlayerState.kPlayerMoving_CrashingThroughHedge) || (fadingOutBushCrash > 0.0f)) {
                bushScreenPos = (Globals.g_world.game).GetScreenPosition(Utilities.CGPointMake(xBushPosition, yBushPosition + 11.0f));
                if ((Globals.g_world.game).IsOnScreenP1(bushScreenPos, 50.0f)) 
				{
                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard[(int)PlayerBillboards.kBB_ThingAfter],Utilities.CGPointMake(bushScreenPos.x, bushScreenPos.y), 1.0f,0.0f,0.0f,fadingOutBushCrash, 
                      (int)World.Enum3.kGTGrass_BushCrashTop);
//                    (DrawManager.Instance()).AddTextureToListAlphaP1P2(myAtlasBillboard[(int)PlayerBillboards.kBB_ThingAfter],Utilities.CGPointMake(bushScreenPos.x, bushScreenPos.y), fadingOutBushCrash, 
  //                    (int)World.Enum3.kGTGrass_BushCrashTop);
                }

                if (state != PlayerState.kPlayerMoving_CrashingThroughHedge) {
                    fadingOutBushCrash -= 0.1f;
                }

            }

        }

        public void RenderShadow()
        {
            const float kShadowAppearBuffer = 40.0f;
            if (!(Globals.g_world.game).IsOnScreenNewP1(shadowScreenPosition, kShadowAppearBuffer)) {
                return;
            }

            float shadowAngle = Constants.PI_ - playerFacingAngle[rotateAnim];
            if (onBridge != -1) {
                (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard[(int)PlayerBillboards.kBB_Shadow], shadowScreenPosition, shadowRotScale, shadowAngle, shadowRotScale, 0.7f, shadowSubtextureId);
            }
            else if ((inHayStack == -1) && (!isInDeepWater)) {
                (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard[(int)PlayerBillboards.kBB_Shadow],shadowScreenPosition, shadowRotScale, shadowAngle, shadowRotScale, 1.0f, shadowSubtextureId);
            }

        }

        public void PassedWall(bool isFinishLine)
        {
            if (!isFinishLine) return;

            if (!hasPassedFinishLine) {
                hasPassedFinishLine = true;
            }

            this.EndBoostArrow();
            if (controlType == PlayerControlType.kControlAI) {
                manualControlOfPiggy = true;
            }

            if (playerType == (int) (int) PlayerType.kPlayerSheep) {
            }

        }

        public void BumpingIntoWall(bool isFinishLineWall)
        {
            if ((controlType == PlayerControlType.kControlGhost) || (controlType == PlayerControlType.kControlAI)) {
                if (playerType != (int) PlayerType.kPlayerSheep) {
                    if (isFinishLineWall) {
                        if (((Globals.g_world.game).player).finishPosition != -1) {
                            if (!manualControlOfPiggy) {
                                manualControlOfPiggy = true;

                                #if NOT_FINAL_VERSION
                                #endif

                                this.EndBoostArrow();
                            }

                        }

                    }
								if (racingBrain != null)
			{

                    racingBrain.SetCloserTarget(0.5f);
					}
                }

            }

            float oldSpeed = (speed.y - (powerSkidYLess * 0.96f));
            speed.y = 0.3f * -oldSpeed;
            powerSkidYLess *= 0.5f;
        }

        public void HitPond()
        {
            gotWet = true;
            if (((Globals.g_world.game).GetPond(inPond)).type ==  PondType.e_Snow) {
                speed.y *= 0.85f;
                speed.x *= 0.85f;
            }
            else if (((Globals.g_world.game).GetPond(inPond)).type !=  PondType.e_MuddyPuddle) {
                if (((Globals.g_world.game).GetPond(inPond)).type ==  PondType.e_Puddle) {
                    speed.y *= 0.8f;
                    speed.x *= 0.8f;
                }
                else {
                    speed.y *= 0.6f;
                    speed.x *= 0.6f;
                }

            }

            this.EndSpeedBoost();
            this.EndBoostArrow();
            powerSkidYLess = 0;
            powerSkidYLessDesired = 0;
        }

        public void LandedInRiver()
        {

            #if NOT_FINAL_VERSION
            #endif

            gotWet = true;
            powerSkidYLess = 0;
            powerSkidYLessDesired = 0;
            			if (racingBrain != null)
			{

			racingBrain.HitGeneric(1.5f);
			}
        }

        public bool HitMuddyPuddle()
        {
            if (inMudTimer <= 0.0f) {
                hitMud = true;
                inMudTimer = kInMudMaxTimer;
                inMudSpeed = this.GetActualSpeed();
                inMudFootstep = 5;
                return true;
            }

            return false;
        }

        public void IsChargingThroughMud()
        {
        }

        public void EndSpeedBoost()
        {
            if (speedBoostEffect != -1) {
                (ParticleSystemRoss.Instance()).StopParticleEffect(speedBoostEffect);
                speedBoostEffect = -1;
            }

            speedBoostTimer = 0;
        }

        public void EndBoostArrow()
        {
            if (boostArrowEffect != -1) {
                (ParticleSystemRoss.Instance()).StopParticleEffect(boostArrowEffect);
                boostArrowEffect = -1;
            }

            this.EndBoostArrowSound();
            boostArrowTimer = 0;
        }

        public void StartSplashing()
        {
            speed.y *= 0.3f;
            speed.x *= 0.3f;
            isInDeepWater = true;
	
			myAtlasBillboard[(int)PlayerBillboards.kBB_Shadow].StopRender();			
			
            if (swimmingSoundId == -1) {
                (SoundEngine.Instance()).LoopFinchSoundP1((int)Audio.Enum1.kSoundEffect_SwimLoop, 1);
                swimmingSoundId = 0;
            }

            this.EndSpeedBoost();
            this.EndBoostArrow();
            if (splashingEffectId == -1) {
                ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                info.type = EffectType.kEffect_SplashingInWater;
                info.player = this;
                splashingEffectId = (ParticleSystemRoss.Instance()).AddParticleEffect(info);
            }

        }

        public void EndSwimmingSound()
        {
            if (swimmingSoundId != -1) {
                (SoundEngine.Instance()).FadeOutP1((int)Audio.Enum1.kSoundEffect_SwimLoop, 0.3f);
                swimmingSoundId = -1;
            }

        }

        public void EndBoostArrowSound()
        {
            if (boostArrowSoundId != -1) {
                (SoundEngine.Instance()).FadeOutP1((int)Audio.Enum1.kSoundEffect_RoaringFire, 0.5f);
                boostArrowSoundId = -1;
            }

        }

        public void StopSplashing()
        {
            isInDeepWater = false;
            this.EndSwimmingSound();
            if (splashingEffectId != -1) {
                (ParticleSystemRoss.Instance()).StopParticleEffect(splashingEffectId);
                splashingEffectId = -1;
            }

        }

        public void CheckStartTrick()
        {
            if (controlType != (int) PlayerControlType.kControlHuman) {
                return;
            }

            if (finishPosition == -1) {
                float numFrames = zVelocity / kJumpGravity;
                float jumpTime = numFrames * Constants.kFrameRate;
                if (jumpTime > 0.42f) {
                    trickInfo.trickState = TrickState.e_WaitingToStart;
                    trickInfo.timeToStartNextPhase = 0.4f * jumpTime;
                    trickInfo.holdTime = jumpTime * 0.8f;
                    trickInfo.whichTrick = Utilities.GetRand( 2);
                    controlFaceAngle = true;
                    faceAngleControlled = Constants.PI_;
                }

            }

        }

        public void AddTrickOffsetToScreenPos()
        {
            if (trickInfo.trickState != TrickState.e_NoTrick) {
                CGPoint displayPosition = Utilities.CGPointMake(position.x + animationFrameOffset[rotateAnim, moveAnim].x, position.y + animationFrameOffset[rotateAnim,
                  moveAnim].y);
 	            if ((!Globals.useRetina) && (Globals.g_main.usingTextureResolution != TextureResolutionEnum.kTextureResolution_High))
				{
                    displayPosition.x += 2.0f;
                    displayPosition.y += 1.0f;
                }

                screenPos = (Globals.g_world.game).GetScreenPosition(displayPosition);
            }

        }

        public void SetScreenPos()
        {
            CGPoint displayPosition = Utilities.CGPointMake(position.x + animationFrameOffset[rotateAnim, moveAnim].x, position.y + animationFrameOffset[rotateAnim,
              moveAnim].y);
            screenPos = (Globals.g_world.game).GetScreenPosition(displayPosition);
            playerScale = baseScale - 1 + Utilities.GetScaleFromHeight(positionZ);
            screenPos.y += Utilities.GetYOffsetFromHeight(positionZ);
            float desiredPlayerAngle;
            if ((desiredSpeedForAngleDisplay.x != 0) || (desiredSpeedForAngleDisplay.y != 0)) desiredPlayerAngle = 
              Utilities.GetAngleFromXYNewP1((-desiredSpeedForAngleDisplay.x * Constants.GAME_Y_ORIENTATION), desiredSpeedForAngleDisplay.y);
            else desiredPlayerAngle = 0;

            if (inMudTimer > 0.0f) {
                const float kWobbleThing = 0.4f;
                float kWobbleSize = 2.0f;
                float ratio = Utilities.GetRatioP1P2(inMudTimer, 0.0f, kInMudMaxTimer);
                kWobbleSize *= ratio;
                float thing = Utilities.WrapP1(inMudTimer / 1.0f, kWobbleThing);
                float addAmount = Utilities.GetCosInterpolationP1P2(thing, 0.0f, kWobbleThing);
                desiredPlayerAngle -= (0.5f * kWobbleSize);
                desiredPlayerAngle += (addAmount * kWobbleSize);
            }

            prevMoveAngle = moveAngle;
            moveAngle = Utilities.GetAngleFromXYP1((-speed.x * Constants.GAME_Y_ORIENTATION), speed.y);
            if (controlFaceAngle) {
                desiredPlayerAngle = faceAngleControlled;
            }

            playerDisplayAngle = playerDisplayAngle + ((desiredPlayerAngle - playerDisplayAngle) * 0.3f);
            this.UpdateShadow(screenPos);
        }

        public float GetPiggyFXVolumeRatio(float maxDist)
        {
            float yDist = Utilities.GetABS(((Globals.g_world.game).player).position.y - position.y);
            float ratio = 1.0f - Utilities.GetRatioP1P2(yDist, 100.0f, maxDist);
            return ratio;
        }

        public void PlayHoofSound()
        {
            if (inPond != -1) return;

            if (inRiver != -1) return;

            float heightOffset = positionZ - groundLevel;
            if (heightOffset > 5) return;

            float volume;
            if (controlType != (int) PlayerControlType.kControlHuman) {
                float ratio;
                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMud) {
                    volume = 0.1f + (0.46f * Utilities.GetRatioP1P2(this.GetDistanceLastFrame(), 3.0f, 12.0f));
                    ratio = 0.7f + (0.3f * this.GetPiggyFXVolumeRatio(300.0f));
                }
                else {
                    volume = 0.1f + (0.46f * Utilities.GetRatioP1P2(this.GetDistanceLastFrame(), 3.0f, 12.0f));
                    volume *= 0.8f;
                    ratio = 0.5f + (0.5f * this.GetPiggyFXVolumeRatio(300.0f));
                }

                volume *= ratio;
                if (volume <= 0.05f) {
                    return;
                }

            }
            else {
                volume = 0.1f + (0.46f * Utilities.GetRatioP1P2(this.GetDistanceLastFrame(), 3.0f, 12.0f));
            }

            if ((Globals.g_world.game).gameState !=  GameState.e_GamePlay) {
                float ratio = 1 - Utilities.GetRatioP1P2(stateTimer, 1, 3);
                volume *= ratio;
            }

            if ((onBridge == -1) && (onRamp == -1) && (onRoof == -1) && (!onRoad)) {
                if (controlType != (int) PlayerControlType.kControlHuman) {
                    Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_RunSoftPig1 + whichHoof, volume, position);
                }
                else {
                    Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_RunSoft1 + whichHoof, volume, position);
                }

            }
            else {
                if (onRoof != -1) {
                    if (((Globals.g_world.game).GetBuilding(onRoof)).type ==  BuildingType.kBuilding_SideShed) {
                        Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_MetalHoof, volume, position);
                    }
                    else {
                        Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_RunHard1 + whichHoof, volume, position);
                    }

                }
                else {
                    if (controlType != (int) PlayerControlType.kControlHuman) {
                        Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_RunHard1 + whichHoof, volume, position);
                    }
                    else {
                        Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_RunHard1 + whichHoof, volume, position);
                    }

                }

            }

        }

        public float GetHeightOffFloor()
        {
            return positionZ - groundLevel;
        }

        float IncreasePowerSkidAffectForThumbControls(float valueNow)
        {
            const float kTimeToStart = 0.15f;
            float kTimeToEnd;
            if (((Globals.g_world.frontEnd).profile).preferences.controlFinger) {
                kTimeToEnd = 0.9f;
            }
            else {
                kTimeToEnd = 0.5f;
            }

            if (timeTiltingInSameDirection > kTimeToStart) {
            }

            float ratio = Utilities.GetRatioP1P2(timeTiltingInSameDirection, kTimeToStart, kTimeToEnd);
            float powerDifference = thumbControlMaximum - valueNow;
            return valueNow + (powerDifference * ratio);
        }

        public void SetPowerTurnSpeedReduction()
        {
            const float kMinNoPower = 0.8f;
            float tiltXabs = Utilities.GetABS(synthesizedTilt.x);
            float piCos;
            if (tiltXabs < kMinNoPower) {
                piCos = 0;
            }
            else {
                tiltXabs -= kMinNoPower;
                tiltXabs *= (1 / (1 - kMinNoPower));
                float piTilt = tiltXabs * Constants.PI_ * 0.5f;
                piCos = 1 - (float)Math.Cos(piTilt);
            }

            if (humanControlType != (int) HumanControlType.kControlHumanTilt) {
                if (timeTiltingInSameDirection < 0.1f) {
                    piCos = 0.0f;
                }
                else kPowerSkidAffect = this.IncreasePowerSkidAffectForThumbControls(kPowerSkidAffect);

            }

            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneIce) {
            }

            powerSkidYLessDesired = speed.y * kPowerSkidAffect * piCos;
            powerSkidYLess += ((powerSkidYLessDesired - powerSkidYLess) * 0.061f);
            if (humanControlType != (int) HumanControlType.kControlHumanTilt) {
                powerSkidYLess += ((powerSkidYLessDesired - powerSkidYLess) * 0.011f);
            }

            if (!canMakeSkidSound) {
                float volume = Utilities.GetRatioP1P2(powerSkidYLessDesired, 5, 10);
                ((SoundEngine.Instance()).GetFinchSound((int)Audio.Enum1.kSoundEffect_SkidStart)).SetGain(volume);
            }

            if ((powerSkidYLessDesired > 8.5f) && (canMakeSkidSound)) {
                (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_SkidStart);
                float volume = Utilities.GetRatioP1P2(powerSkidYLessDesired, 5, 10);
                ((SoundEngine.Instance()).GetFinchSound((int)Audio.Enum1.kSoundEffect_SkidStart)).SetGain(volume);
                canMakeSkidSound = false;
            }

            if (powerSkidYLessDesired < 2) {
                canMakeSkidSound = true;
            }

        }

        public void LoseOneMaxSpeed()
        {
            if (maxSpeedExtraSpeed > 0) {
                maxSpeedExtraSpeed--;
                if (maxSpeedEffect[maxSpeedExtraSpeed] != -1) {
                    (ParticleSystemRoss.Instance()).StopParticleEffect(maxSpeedEffect[maxSpeedExtraSpeed]);
                    maxSpeedEffect[maxSpeedExtraSpeed] = -1;
                }

            }

        }

        public void MakeSplash()
        {
            ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
            info.type = EffectType.kEffect_SplashRing;
            info.inList = ParticleList.t_DownInRiver;
            info.velocity = speed;
            info.startPosition = position;
            info.rotation = moveAngle;
            float groundLevelYThing = Utilities.kYShiftForZ * positionZ;
            info.startPosition.y -= groundLevelYThing;
            (ParticleSystemRoss.Instance()).AddParticleEffect(info);
            Globals.g_world.PlayFinchSoundWithPositionP1P2((int)Audio.Enum1.kSoundEffect_Splash, 1.0f, position);
        }

        public void SetInWaterfall(int whichFall)
        {
            inWaterfall = whichFall;
            if (whichFall != -1) {
                speed.y = speed.y - powerSkidYLess;
                powerSkidYLess = 0.0f;
                powerSkidYLessDesired = 0.0f;
                hitWaterInWaterfall = false;
            }

        }

        public void SetOnLog(int whichLog)
        {
            onLog = whichLog;
            if (whichLog != -1) {
                speed.y *= 0.75f;
                zVelocity = 5.0f;
            }

        }

        public void SetInVenus(int whichVenus)
        {
            inVenus = whichVenus;
            if (whichVenus != -1) {
                speed.x = 0.0f;
                speed.y = 0.0f;
            }
            else {
                zVelocity = 5.0f;
                speed.x *= 0.5f;
                speed.y = 5.0f;
            }

        }

        public void JumpIntoRiver(int whichRiver)
        {
            speed.y = speed.y - powerSkidYLess;
            powerSkidYLess = 0.0f;
            powerSkidYLessDesired = 0.0f;
            if (((Globals.g_world.game).GetRiver(whichRiver)).riverType == RiverType.e_CrocRiver) {
                speed.y = 0.0f;
                zVelocity = 1.0f;
            }

        }

        public void SetInRiver(int whichRiver)
        {
            inRiver = whichRiver;
            if (whichRiver != -1) {
                speed.y = speed.y - powerSkidYLess;
                powerSkidYLess = 0.0f;
                powerSkidYLessDesired = 0.0f;
                if (((Globals.g_world.game).GetRiver(whichRiver)).riverType == RiverType.e_CrocRiver) {
                    speed.y = 5.0f;
                    zVelocity = 2.0f;
                }

            }

        }

        public float GetSpeedMultiplier()
        {
            if ((Globals.g_world.game).gameState == GameState.e_ShowResultsWin) {
                if (position.y > ((Globals.g_world.game).finishYPos + 35.0f)) {
                    return 0;
                }

            }

            if (((Globals.g_world.game).gameState == GameState.e_ShowResultsLoseTooSlow) || ((Globals.g_world.game).gameState == GameState.
              e_ShowResultsLoseToPiggy)) {
                if ((Globals.g_world.game).stateTimer < 0.35f) {
                    return 0.2f;
                }
                else {
                    return 0.0f;
                }

            }

            if ((inRiver != -1) || (isInDeepWater)) {
                if (inPond != -1) {
                    if (((Globals.g_world.game).GetPond(inPond)).type ==  PondType.e_Puddle) {
                        return 0.6f;
                    }

                }

                return 0.4f;
            }
            else {
                if (inPond != -1) {
                    if (((Globals.g_world.game).GetPond(inPond)).type ==  PondType.e_Snow) {
                        return 0.85f;
                    }
                    else if (((Globals.g_world.game).GetPond(inPond)).type != PondType.e_MuddyPuddle) {
                        return 0.65f;
                    }

                }

            }

            if (inMudTimer > 0.0f) {
                if (inMudTimer < (kInMudMaxTimer / 2.0f)) {
                    return 0.0f;
                }

            }

            return 1.0f;
        }

        public void EndMaxSpeed()
        {
            if (maxSpeedExtraSpeed > 0) {
                for (int i = 0; i < maxSpeedExtraSpeed; i++) {
                    if (maxSpeedEffect[i] != -1) {
                        (ParticleSystemRoss.Instance()).StopParticleEffect(maxSpeedEffect[i]);
                        maxSpeedEffect[i] = -1;
                    }

                }

            }

            maxSpeedTime = 0;
            maxSpeedExtraSpeed = 0;
        }
		
    }
}
