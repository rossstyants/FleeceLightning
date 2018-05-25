using System;

namespace Default.Namespace
{
    public enum  FlockAnimalType {
        kFlockAnimalCow = 0,
        kFlockAnimalPenguin,
        kFlockAnimalZebra,
        kFlockAnimalShirley,
        kFlockAnimalSheep
    }
    public enum  FlockAnimalState {
        kFA_NotActive = 0,
        kFA_IsActive
    }
    public class FlockAnimal
    {
		public int flockAnimalId; //??

        public FlockAnimalType flockAnimalType;
        public CGPoint position;
        public Flock myFlock;
        public float xLinePosition;
        public float animateRoll;
        public float yUndulationTimer;
        public float yUndulationTime;
        public float yUndulation;
        public float distanceBetweenHoofSounds;
        public float distSinceCloud;
        public float kRollAnimSpeed;
        public CGPoint shadowOffset;
        public CGPoint markerOffset;
        public float undulationDistance;
        public MapObject mapObject;
        public MapObject shadowMapObject;
        public int mapObjectId;
        public int shadowMapObjectId;
        public NoGoZone noGoZone;
        public int whichHoof;
        public int animateIndex;
        public int animMinSubTexture;
        public float bumpTimer;
        public float bumpMaxDistance;
        public CGPoint bumpDirection;
        public CGPoint bumpOffset;
        public bool hasShadow;
        public bool hasMarkerForAI;
        public float yStartPosition;
        public int framesForUndulationCycle;
        public int undulationStartFrame;
        const float kBumpTime = 0.5f;
        public struct FlockAnimalInfo{
            public float distanceToGo;
            public Flock myFlock;
            public float xLinePosition;
            public float yUndulationTime;
            public float yUndulationTimer;
            public int animalType;
            public int flockAnimalId;
            public bool hasMarkerForAI;
            public CGPoint markerOffset;
        };
        public float YStartPosition
        {
            get;
            set;
        }

        public CGPoint Position
        {
            get;
            set;
        }

        public int FlockAnimalId
        {
            get;
            set;
        }

        public MapObject MapObject
        {
            get;
            set;
        }

        public int MapObjectId
        {
            get;
            set;
        }

        public int ShadowMapObjectId
        {
            get;
            set;
        }

        public bool HasMarkerForAI
        {
            get;
            set;
        }

        public CGPoint MarkerOffset
        {
            get;
            set;
        }

		public void SetMapObject(MapObject inThing) {mapObject = inThing;}////@property(readwrite,assign) MapObject* mapObject;
public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetShadowMapObjectId(int inThing) {shadowMapObjectId = inThing;}///@property(readwrite,assign) int shadowMapObjectId;
public void SetYStartPosition(float inThing) {yStartPosition = inThing;}///@property(readwrite,assign) float yStartPosition;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetHasMarkerForAI(bool inThing) {hasMarkerForAI = inThing;}///@property(readwrite,assign) bool hasMarkerForAI;
public void SetMarkerOffset(CGPoint inThing) {markerOffset = inThing;}///@property(readwrite,assign) CGPoint markerOffset;
//public void SetState(FlockAnimalState inThing) {state = inThing;}///@property(readwrite,assign) FlockAnimalState state;
public void SetFlockAnimalId(int inThing) {flockAnimalId = inThing;}///@property(readwrite,assign) int flockAnimalId;

        public FlockAnimal()
        {
            //if (!base.init()) return null;

            whichHoof = 0;
            distanceBetweenHoofSounds = 0.0f;
            distSinceCloud = 0.0f;
            noGoZone = null;
            //return this;
        }
        public void AddToFlockP1(Flock.FlockAnimalInfo info, FlockAnimal prevAnimal)
        {
            myFlock = info.myFlock;
            xLinePosition = info.xLinePosition;
            position.x = info.xLinePosition;
            position.y = myFlock.yPositionStart;
            yUndulationTimer = info.yUndulationTimer;
            yUndulationTime = info.yUndulationTime;
            flockAnimalType = (FlockAnimalType)info.animalType;
            flockAnimalId = info.flockAnimalId;
            hasMarkerForAI = info.hasMarkerForAI;
            markerOffset = info.markerOffset;
            if (flockAnimalType == FlockAnimalType.kFlockAnimalShirley) {
                undulationDistance = 20.0f;
            }
            else {
                undulationDistance = 40.0f;
            }

            if (flockAnimalType == FlockAnimalType.kFlockAnimalPenguin) {
                hasShadow = false;
            }
            else {
                hasShadow = true;
            }

            framesForUndulationCycle = (int) (info.yUndulationTime / Constants.kFrameRate);
            if (prevAnimal == null) {
                yStartPosition = myFlock.yPositionStart;
                int framesAdded = (int) (info.yUndulationTimer / Constants.kFrameRate);
                undulationStartFrame = (int)(framesAdded % framesForUndulationCycle);
                if (undulationStartFrame < 0) undulationStartFrame += framesForUndulationCycle;

            }
            else {
                yStartPosition = prevAnimal.yStartPosition - info.distanceToGo;
                float distanceFromStart = myFlock.yPositionStart - yStartPosition;
                int framesSinceStart = (int) (distanceFromStart / myFlock.speed);
                int framesAdded = (int) ((info.yUndulationTimer) / Constants.kFrameRate);
                int totalNewFrames = -framesSinceStart + framesAdded;
                undulationStartFrame = (int)(totalNewFrames % framesForUndulationCycle);
                if (undulationStartFrame < 0) undulationStartFrame += framesForUndulationCycle;

            }

            mapObjectId = (Globals.g_world.game).AddMapObjectP1P2P3P4(TextureType.kTexture_DontAddThisMapObjectToPendingList, (int) 100, (int) -300, 
              ListType.e_RenderAbovePlayer, 0);
            Globals.Assert(!(Globals.g_world.game).IsMapObjectIdInvalid(mapObjectId));
            mapObject = (Globals.g_world.game).GetMapObject(mapObjectId);
            mapObject.SetType( MapObjectType.e_FlockAnimal);
            mapObject.SetSubTextureId(0);
            const float kMinScale = 0.73f;
            const float kMaxScale = 1.0f;
            float range = kMaxScale - kMinScale;
            float rPlus = Utilities.GetRandBetweenP1(0.0f, range);
            float rThing = kMinScale + rPlus;
            mapObject.SetScale(rThing);
            mapObject.SetIsSelfRemoving(false);
            shadowMapObjectId = -1;
            if (hasShadow) {
                shadowMapObjectId = (Globals.g_world.game).AddMapObjectP1P2P3P4( TextureType.kTexture_DontAddThisMapObjectToPendingList, (int) -100, (int) -300,
                   ListType.e_Shadows, 0);
            }

            Globals.Assert(!(Globals.g_world.game).IsMapObjectIdInvalid(mapObjectId));
            if (hasShadow) {
                Globals.Assert(!(Globals.g_world.game).IsMapObjectIdInvalid(shadowMapObjectId));
                shadowMapObject = (Globals.g_world.game).GetMapObject(shadowMapObjectId);
                shadowMapObject.SetIsSelfRemoving(false);
				
				shadowMapObject.SetAtlas(Globals.g_world.game.gameThingsAtlas);//				
				if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMud) {
                    shadowMapObject.SetSubTextureId((int)World.Enum2.kGTMud_PlayerShadow);
                    shadowMapObject.SetAtlas(Globals.g_world.game.gameThingsAtlas);// .SetSubTextureId((int)World.Enum2.kGTMud_PlayerShadow);
                }
                else {
                    shadowMapObject.SetSubTextureId((int)World.Enum3.kGTGrass_PlayerShadow);
                }

            }

            float noGoRadius = 0.0f;
            if (flockAnimalType == FlockAnimalType.kFlockAnimalCow) {
                shadowMapObject.SetScale(1.0f);
                noGoRadius = 42.0f;
            }
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalSheep) {
                shadowMapObject.SetScale(1.7f * rThing);
                noGoRadius = 42.0f;
            }
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalPenguin) {
                noGoRadius = 20.0f;
            }
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalZebra) {
                shadowMapObject.SetScale(1.5f);
                noGoRadius = 35.0f;
            }
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalShirley) {
                shadowMapObject.SetScale(2.7f);
                noGoRadius = 70.0f;
            }
            else {
                Globals.Assert(false);
            }

            if (noGoZone == null) 
			{
                noGoZone = new NoGoZone();
            }

            noGoZone.InitialiseP1(Utilities.CGPointMake(0, 0), noGoRadius);
            noGoZone.SetType(NoGoType.e_FlockAnimal);
            noGoZone.SetObjectId(myFlock.flockId);
            noGoZone.SetShadowObjectId(flockAnimalId);
        }

        public void SetStartOfRace()
        {
            animateIndex = (Utilities.GetRand( 4));
            animateRoll = ((float)(Utilities.GetRand( 200))) / 20.0f;
            bumpTimer = 0.0f;
            bumpOffset = Utilities.CGPointMake(0.0f, 0.0f);
            distSinceCloud = (float)(Utilities.GetRand( 100));
            if (flockAnimalType == FlockAnimalType.kFlockAnimalCow) {
                animMinSubTexture = (int)World.Enum3.kGTGrass_CowDown1;
                kRollAnimSpeed = 20.0f;
                shadowOffset = Utilities.CGPointMake(20.0f, 9.0f);
            }
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalSheep) {
                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMud) {
                    animMinSubTexture = (int)World.Enum2.kGTMud_FlockSheepDown1;
                }
                else {
                    animMinSubTexture = (int)World.Enum3.kGTGrass_CowDown1;
                }

                kRollAnimSpeed = 18.0f + Utilities.GetRandBetweenP1(0.0f, 8.0f);
//                shadowOffset = Utilities.CGPointMake(20.0f, 9.0f);
                shadowOffset = Utilities.CGPointMake(7.0f, 7.5f);
            }
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalPenguin) {
                animMinSubTexture = 1;
                kRollAnimSpeed = 10.0f;
                shadowOffset = Utilities.CGPointMake(10.0f, 5.0f);
            }
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalZebra) {
//                animMinSubTexture = (int)World.Enum2.kGTSavanna_Zebra1;
                kRollAnimSpeed = 20.0f;
                shadowOffset = Utilities.CGPointMake(20.0f, 9.0f);
            }
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalShirley) {
                animMinSubTexture = (int)World.Enum2.kGTMud_ShirleyDown1;
                kRollAnimSpeed = 8.0f;
                shadowOffset = Utilities.CGPointMake(20.0f, 9.0f);
            }
            else {
                Globals.Assert(false);
            }

        }

        public void SetSubtextureFromAnim()
        {
            mapObject.SetSubTextureId(animMinSubTexture + animateIndex);
        }

        public void UpdateMoveAnim()
        {
            animateRoll += myFlock.speed;
            if (animateRoll > kRollAnimSpeed) {
                animateIndex += 1;
                if (animateIndex > 2) {
                    animateIndex = 0;
                }

                this.SetSubtextureFromAnim();
                animateRoll -= kRollAnimSpeed;
            }

        }

        public void UpdateXPosition()
        {
            const float kCurveInDistance = 1000.0f;
            const float kCurveXSize = 450.0f;
            float distanceFromStart = position.y - myFlock.yPositionStart;
            if (distanceFromStart <= kCurveInDistance) {
                float xCurveIn = 1.0f - Utilities.GetCosInterpolationHalfP1P2(distanceFromStart, 0, kCurveInDistance);
                position.x = xLinePosition + (xCurveIn * kCurveXSize);
                return;
            }

            float distanceToEnd = myFlock.yPositionEnd - position.y;
            if (distanceToEnd <= kCurveInDistance) {
                float xCurveIn = 1.0f - Utilities.GetCosInterpolationHalfP1P2(distanceToEnd, 0, kCurveInDistance);
                position.x = xLinePosition - (xCurveIn * kCurveXSize);
                return;
            }

            position.x = xLinePosition;
        }

        public void SetYUndulation(float raceTime)
        {
            int framesSinceStart = (int) ((raceTime - myFlock.headStartTime) / Constants.kFrameRate);
            int undulationPosition = (undulationStartFrame + framesSinceStart) % framesForUndulationCycle;
            yUndulationTimer = (float) undulationPosition * Constants.kFrameRate;
            yUndulation = undulationDistance * Utilities.GetCosInterpolationP1P2(yUndulationTimer, 0.0f, yUndulationTime);
        }

        public void UpdateYUndulation()
        {
            yUndulationTimer += Constants.kFrameRate;
            if (yUndulationTimer >= yUndulationTime) {
                yUndulationTimer -= yUndulationTime;
            }

            yUndulation = 40.0f * Utilities.GetCosInterpolationP1P2(yUndulationTimer, 0.0f, yUndulationTime);
        }

        public void PlayHoofSound()
        {
            float distanceToPlayer = Utilities.GetDistanceP1(position, ((Globals.g_world.game).player).position);
            float volume = 0.3f + (0.5f * (1.0f - Utilities.GetRatioP1P2(distanceToPlayer, 0.0f, 300.0f)));
            volume *= 0.7f;
            (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_RunSoftPig1 + whichHoof, volume);
        }

        public void UpdateDustCloud()
        {
            if (Globals.g_world.artLevel == 0) return;

            const float kDistBetweenClouds = 115.0f;
            distSinceCloud += myFlock.speed;
            if (distSinceCloud >= kDistBetweenClouds) {
                distSinceCloud -= kDistBetweenClouds;
                ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                info.type = EffectType.kEffect_DustCloudTrailWithoutPlayer;
                info.startPosition = position;
                CGPoint normalDirection = Utilities.CGPointMake(0.0f, 1.0f);
                info.startPosition.y -= (normalDirection.y * 15.0f);
                info.startPosition.x -= (normalDirection.x * 15.0f);
                info.velocity = Utilities.CGPointMake(0.0f, myFlock.speed * 0.5f);
                info.player = null;
                (ParticleSystemRoss.Instance()).AddParticleEffect(info);
            }

        }

        public void UpdateHoofBeats()
        {
            const float kDistanceForAllHoofs = 200;
            float[] kHoofDistanceRatio = new float[4]
            {0.1f, 0.2f, 0.6f, 0.7f};
            distanceBetweenHoofSounds += myFlock.speed;
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

        public float BumpP1(CGPoint newVelocity, Player whoBy)
        {

            #if RACE_AS_PIGGY
                return false;
            #endif

            CGPoint bumpVelocity = Utilities.CGPointMake(newVelocity.x, newVelocity.y - myFlock.speed);
            float powerSqr = Utilities.GetSqrDistanceP1(Utilities.CGPointMake(0.0f, myFlock.speed), newVelocity);
            if (flockAnimalType == FlockAnimalType.kFlockAnimalShirley) {
                if (powerSqr > 120.0f) {
                    if (whoBy == (Globals.g_world.game).player) {
                        ((Globals.g_world.frontEnd).profile).QueueAchievement(Profile.Enum2.kAchievement_ShirleyThump);
                        ((Globals.g_world.frontEnd).profile).FlushPendingAchievements();
                    }

                }

                if (powerSqr > 24.0f) {
                    if (bumpTimer <= 0.25f) {
                        (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_HitShirley);
                    }

                }

            }

            if (bumpTimer > 0.0f) return 0.0f;

            if (flockAnimalType == FlockAnimalType.kFlockAnimalCow) bumpMaxDistance = 2.0f * Utilities.GetDistanceP1(Utilities.CGPointMake(0.0f, 0.0f), 
              bumpVelocity);
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalSheep) bumpMaxDistance = 2.0f * Utilities.GetDistanceP1(Utilities.CGPointMake(0.0f, 0.0f),
              bumpVelocity);
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalZebra) bumpMaxDistance = 3.2f * Utilities.GetDistanceP1(Utilities.CGPointMake(0.0f, 0.0f),
              bumpVelocity);
            else if (flockAnimalType == FlockAnimalType.kFlockAnimalShirley) bumpMaxDistance = 2.0f * Utilities.GetDistanceP1(Utilities.CGPointMake(0.0f, 0.0f),
              bumpVelocity);
            else {
                bumpMaxDistance = 5.0f * Utilities.GetDistanceP1(Utilities.CGPointMake(0.0f, 0.0f), bumpVelocity);
            }

            bumpDirection = Utilities.Normalise(bumpVelocity);
            bumpTimer = kBumpTime;
            return powerSqr;
        }

        public void UpdateBumping()
        {
            if (bumpTimer > 0.0f) {
                if (bumpTimer > (kBumpTime * 0.5f)) bumpTimer -= Constants.kFrameRate;
                else bumpTimer -= (Constants.kFrameRate / 3.0f);

                if (bumpTimer <= 0.0f) {
                    bumpOffset = Utilities.CGPointMake(0.0f, 0.0f);
                    return;
                }

                float bumpDistance = bumpMaxDistance * Utilities.GetCosInterpolationP1P2(bumpTimer, 0.0f, kBumpTime);
                bumpOffset = Utilities.CGPointMake(bumpDistance * bumpDirection.x, bumpDistance * bumpDirection.y);
            }

        }

        public void UpdateShadow(CGPoint realPosition)
        {
            const float kJogDistance = 3.0f;
            float animPosition = (((float) animateIndex) * 20.0f) + animateRoll;
            float shadowDistance;
            if (hasShadow) {
                shadowDistance = Utilities.GetCosInterpolationP1P2(animPosition, 0.0f, 80.0f);
                shadowMapObject.SetPosition(Utilities.CGPointMake(realPosition.x + shadowOffset.x + (kJogDistance * shadowDistance), realPosition.y + shadowOffset.y + (
                  kJogDistance * 0.7f * shadowDistance)));
            }

        }

        public void UpdateAmbientSound()
        {
            if (mapObject.GetScreenPos().y < 480.0f) {
                if ((position.x > 64.0f) && (position.x < 704.0f)) {
                    if (flockAnimalType == FlockAnimalType.kFlockAnimalCow) {
                        (Globals.g_world.game).UpdateAmbientMoo();
                    }
                    else if (flockAnimalType == FlockAnimalType.kFlockAnimalSheep) {
                        (Globals.g_world.game).UpdateAmbientMoo();
                    }
                    else if (flockAnimalType == FlockAnimalType.kFlockAnimalPenguin) {
                        (Globals.g_world.game).UpdateAmbientPenguin();
                    }
                    else if (flockAnimalType == FlockAnimalType.kFlockAnimalZebra) {
                        (Globals.g_world.game).UpdateAmbientPenguin();
                    }
                    else if (flockAnimalType == FlockAnimalType.kFlockAnimalShirley) {
                    }
                    else {
                        Globals.Assert(false);
                    }

                }

            }

        }

        public float CalculateYPosition(float raceTime)
        {
            float numFrames = raceTime / Constants.kFrameRate;
            float newY = yStartPosition + (numFrames * myFlock.speed);
            if (newY > myFlock.yPositionEnd) {
                newY -= myFlock.yLength;
            }

            if (newY > myFlock.yPositionEnd) {
                newY -= myFlock.yLength;
            }

            return newY;
        }

        public void UpdateNew(float raceTime)
        {
            position.y = this.CalculateYPosition(raceTime);
            this.SetYUndulation(raceTime);
            this.UpdateMoveAnim();
            this.UpdateXPosition();
            this.UpdateBumping();
            CGPoint realPosition = Utilities.CGPointMake(position.x + bumpOffset.x, position.y + bumpOffset.y + yUndulation);
            mapObject.SetPosition(realPosition);
            this.UpdateShadow(realPosition);
            this.UpdateDustCloud();
            this.UpdateHoofBeats();
            this.UpdateAmbientSound();
            noGoZone.SetMapPosition(realPosition);
            (Globals.g_world.game).UpdateNoGoZoneP1P2(noGoZone, (Globals.g_world.game).player, false);
            for (int i = (Globals.g_world.game).startFromPiggy; i < (Globals.g_world.game).lastPiggyIndex; i++) {
                (Globals.g_world.game).UpdateNoGoZoneP1P2(noGoZone, (Globals.g_world.game).GetPlayerPiggy(i), false);
            }

        }

        public void RenderMarkerForAI()
        {
            if (hasMarkerForAI) {
           /*     (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
                CGPoint realPosition = Utilities.CGPointMake(position.x + markerOffset.x, position.y + markerOffset.y);
                CGPoint screenPos = (Globals.g_world.game).GetScreenPosition(realPosition);
                (DrawManager.Instance()).AddTextureToListP1(screenPos, 0);
                (DrawManager.Instance()).Flush();*/
            }

        }

        public void Render()
        {
        }

    }
}
