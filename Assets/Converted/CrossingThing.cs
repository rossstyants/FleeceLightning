using System;

namespace Default.Namespace
{
    public enum  CrossingThingType {
        kCrossingThing_Elephant = 0,
        kCrossingThing_Snake,
        kCrossingThing_Tractor,
        kCrossingThing_LandRover,
        kCrossingThing_Shirley,
        kCrossingThing_Sheep
    }
    public class CrossingThing
    {
        public CGPoint startPosition;
        public float xSpeed;
        public int framesToCrossMap;
        public int crossingThingId;
        public int hoofSoundId;
        public CGPoint position;
        public CrossingThingType crossingThingType;
        public float distanceBetweenHoofSounds;
        public float distSinceCloud;
        public float xLinePosition;
        public float animateRoll;
        public float yUndulationTimer;
        public float yUndulationTime;
        public float yUndulation;
        public float kRollAnimSpeed;
        public CGPoint shadowOffset;
        public MapObject mapObject;
        public MapObject shadowMapObject;
        public int mapObjectId;
        public int shadowMapObjectId;
        public NoGoZone noGoZone;
        public int whichHoof;
        public int animateIndex;
        public int animMinSubTexture;
        public int numAnims;
        public float bumpTimer;
        public float bumpMaxDistance;
        public CGPoint bumpDirection;
        public CGPoint bumpOffset;
        public int framesForUndulationCycle;
        public int undulationStartFrame;
        const float kMapEdgeBuffer = 100.0f;
        const float kCTBumpTime = 0.5f;
        public struct CrossingThingInfo {
            public float xSpeed;
            public CGPoint startPosition;
            public CrossingThingType crossingThingType;
            public int crossingThingId;
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

        public int CrossingThingId
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

		public void SetMapObject(MapObject inThing) {mapObject = inThing;}////@property(readwrite,assign) MapObject* mapObject;
public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetShadowMapObjectId(int inThing) {shadowMapObjectId = inThing;}///@property(readwrite,assign) int shadowMapObjectId;
//public void SetYStartPosition(float inThing) {yStartPosition = inThing;}///@property(readwrite,assign) float yStartPosition;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
//public void SetState(CrossingThingState inThing) {state = inThing;}///@property(readwrite,assign) CrossingThingState state;
public void SetCrossingThingId(int inThing) {crossingThingId = inThing;}///@property(readwrite,assign) int crossingThingId;
//public void SetStillHasMapObject(bool inThing) {stillHasMapObject = inThing;}///@property(readwrite,assign) bool stillHasMapObject;

        public CrossingThing()
        {
            //if (!base.init()) return null;

            whichHoof = 0;
            distanceBetweenHoofSounds = 0.0f;
            distSinceCloud = 0.0f;
            noGoZone = null;
            //return this;
        }
        public void Dealloc()
        {
            if (noGoZone != null) 
			{
				noGoZone.Dealloc();
				noGoZone = null;
			}
        }

        public void AddToScene(CrossingThingInfo info)
        {
            numAnims = -1;
            switch ((CrossingThingType)info.crossingThingType) {
            case CrossingThingType.kCrossingThing_Elephant :
                xSpeed = -1.0f;
                break;
            case CrossingThingType.kCrossingThing_Snake :
                xSpeed = -2.0f;
				animMinSubTexture = 0;//kGTJungle_Snake1;
                numAnims = 3;
                break;
            case CrossingThingType.kCrossingThing_Shirley :
                xSpeed = 0.5f;
                animMinSubTexture = 0;
                numAnims = 3;
                break;
            case CrossingThingType.kCrossingThing_Tractor :
                xSpeed = -3.0f;
                animMinSubTexture = (short)World.Enum2.kGTMud_Tractor;
                numAnims = 1;
                break;
            case CrossingThingType.kCrossingThing_LandRover :
                xSpeed = 4.5f;
                animMinSubTexture = (short)World.Enum2.kGTMud_LandRover;
                numAnims = 1;
                break;
            case CrossingThingType.kCrossingThing_Sheep :
                xSpeed = info.xSpeed;
                if (xSpeed < 0.0f) {
                    animMinSubTexture = (short)World.Enum3.kGTGrass_CowLeft1;
                }
                else {
                    animMinSubTexture = (short)World.Enum3.kGTGrass_CowRight1;
                }

                numAnims = 3;
                break;
            default :
                xSpeed = -1.0f;
                break;
            }

            framesToCrossMap = (short) ((Constants.MAP_WIDTH + (kMapEdgeBuffer * 2.0f)) / -xSpeed);
            startPosition = info.startPosition;
            position = info.startPosition;
            crossingThingType = info.crossingThingType;
            crossingThingId = info.crossingThingId;
            mapObjectId = (short)(Globals.g_world.game).AddMapObjectP1P2P3P4((TextureType)0, (int) 100, (int) -300, ListType.e_RenderAbovePlayer, 0.0f);
            Globals.Assert(!(Globals.g_world.game).IsMapObjectIdInvalid(mapObjectId));
            mapObject = (Globals.g_world.game).GetMapObject(mapObjectId);
            mapObject.SetType( MapObjectType.e_CrossingThing);
            mapObject.SetSubTextureId(animMinSubTexture);
            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMud) {
                mapObject.SetRotationScale((Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud)).GetSubTextureRotationScale(animMinSubTexture));
            }
            else {
                mapObject.SetRotationScale((Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale(animMinSubTexture));
            }

            mapObject.SetIsSelfRemoving(false);
            mapObject.SetScale(Constants.SPRITE_BASE_SCALE);
            shadowMapObjectId = -1;
            if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Elephant) {
                shadowMapObjectId = (short)(Globals.g_world.game).AddMapObjectP1P2P3P4((TextureType)0, (int) -100, (int) -300,  ListType.e_Shadows, 0);
            }

            Globals.Assert(!(Globals.g_world.game).IsMapObjectIdInvalid(mapObjectId));
            if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Elephant) {
                Globals.Assert(!(Globals.g_world.game).IsMapObjectIdInvalid(shadowMapObjectId));
                shadowMapObject = (Globals.g_world.game).GetMapObject(shadowMapObjectId);
                shadowMapObject.SetSubTextureId(1);
                shadowMapObject.SetIsSelfRemoving(false);
            }

            float noGoRadius = 0.0f;
            if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Elephant) {
                shadowMapObject.SetScale(2.0f);
                noGoRadius = 42.0f;
            }
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Snake) {
                noGoRadius = 30.0f;
            }
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Shirley) {
                noGoRadius = 50.0f;
            }
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Sheep) {
                noGoRadius = 30.0f;
            }
            else if (((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Tractor) || ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_LandRover)) {
                noGoRadius = 80.0f;
            }
            else {
                Globals.Assert(false);
            }

            if (noGoZone == null) {
                noGoZone = new NoGoZone();
            }

            noGoZone.InitialiseP1(Utilities.CGPointMake(0, 0), noGoRadius);
            noGoZone.SetType(NoGoType.e_CrossingThing);
            noGoZone.SetObjectId(crossingThingId);
            noGoZone.SetShadowObjectId(crossingThingId);
            noGoZone.SetIsBouncable(true);
            noGoZone.SetCeilingHeight(20.0f);
        }

        public void SetupRunningSurface()
        {
            hoofSoundId = (short) Audio.Enum1.kSoundEffect_RunSoft1;
            int xTilePos = 3;
            int yTilePos = (int) (startPosition.y / 64.0f);
            int tileUnderMyFeet = (((Globals.g_world.game).tileMap).GetTileGrid()).GetTileIdP1(xTilePos, yTilePos);
            int objectUnderMyFeet = (int)((Globals.g_world.game).lBuilder).GetObjectFromTileId(tileUnderMyFeet);
            if ((objectUnderMyFeet == (int) ObjectType.kOT_Road) || (objectUnderMyFeet == (int) ObjectType.kOT_RoadCrossing)) {
                hoofSoundId = (short)Audio.Enum1.kSoundEffect_RunHard1;
            }

        }

        public void SetStartOfRace()
        {
            this.SetupRunningSurface();
            animateIndex = (short)(Utilities.GetRand( 4));
            animateRoll = (float)((float)Utilities.GetRand( 20) / 20.0f);
            bumpTimer = 0.0f;
            bumpOffset = Utilities.CGPointMake(0.0f, 0.0f);
            distSinceCloud = (float)(Utilities.GetRand( 100));
            if (crossingThingType == (int) CrossingThingType.kCrossingThing_Elephant) {
                kRollAnimSpeed = 20.0f;
                shadowOffset = Utilities.CGPointMake(20.0f, 9.0f);
            }
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Snake) {
                kRollAnimSpeed = 6.0f;
                shadowOffset = Utilities.CGPointMake(10.0f, 5.0f);
            }
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Sheep) {
                kRollAnimSpeed = 16.0f;
                shadowOffset = Utilities.CGPointMake(10.0f, 5.0f);
            }
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Shirley) {
                kRollAnimSpeed = 4.0f;
            }
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Tractor) {
                kRollAnimSpeed = 6.0f;
            }
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_LandRover) {
                kRollAnimSpeed = 6.0f;
            }
            else {
                Globals.Assert(false);
            }

        }

        public void SetSubtextureFromAnim()
        {
        }

        public void UpdateMoveAnim()
        {
            if (numAnims <= 1) return;

            animateRoll += Utilities.GetABS(xSpeed);
            if (animateRoll > kRollAnimSpeed) {
                animateIndex += 1;
                if (animateIndex >= numAnims) {
                    animateIndex = 0;
                }

                mapObject.SetSubTextureId(animMinSubTexture + animateIndex);
                animateRoll -= kRollAnimSpeed;
            }

        }

        public void SetYUndulation(float raceTime)
        {
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
            float distanceToPlayer = Utilities.GetABS(((Globals.g_world.game).player).position.y - position.y);
            float volume = 0.3f + (0.3f * (1.0f - Utilities.GetRatioP1P2(distanceToPlayer, 0.0f, 300.0f)));
            bool playIt = true;
            if (((Globals.g_world.game).gameState == GameState.e_ShowResultsWin) || ((Globals.g_world.game).gameState == GameState.e_ShowResultsLoseToPiggy
              )) {
                if ((Globals.g_world.game).stateTimer > 2.4f) {
                    playIt = false;
                }

            }

            if (playIt) {
                Globals.g_world.PlayFinchSoundWithPositionP1P2(hoofSoundId + whichHoof, volume, position);
            }

        }

        public void UpdateDustCloud()
        {
            if (Globals.g_world.artLevel == 0) return;

            const float kDistBetweenClouds = 115.0f;
            distSinceCloud += Utilities.GetABS(xSpeed);
            if (distSinceCloud >= kDistBetweenClouds) {
                distSinceCloud -= kDistBetweenClouds;
                ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                info.type = EffectType.kEffect_DustCloudTrailWithoutPlayer;
                info.startPosition = position;
                CGPoint normalDirection = Utilities.CGPointMake(0.0f, 1.0f);
                info.startPosition.y -= (normalDirection.y * 15.0f);
                info.startPosition.x -= (normalDirection.x * 15.0f);
                info.velocity = Utilities.CGPointMake(0.0f, xSpeed * 0.5f);
                if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Sheep) {
                    info.velocity = Utilities.CGPointMake(0.0f, 1.5f);
                }

                info.player = null;
                (ParticleSystemRoss.Instance()).AddParticleEffect(info);
            }

        }

        public float GetBumpPowerSqr(CGPoint newVelocity)
        {
            CGPoint diff = Utilities.CGPointMake(newVelocity.x - xSpeed, newVelocity.y);
            return Utilities.GetSqrDistanceP1(Utilities.CGPointMake(0, 0), diff);
        }

        public void BumpP1(CGPoint newVelocity, Player whoBy)
        {

            #if RACE_AS_PIGGY
                return;
            #endif

            if (bumpTimer > 0.0f) {

                #if NOT_FINAL_VERSION
                    if (whoBy == (Globals.g_world.game).player) {
                    }

                #endif

                return;
            }

            #if NOT_FINAL_VERSION
                if (whoBy == (Globals.g_world.game).player) {
                }

            #endif

            CGPoint bumpVelocity = Utilities.CGPointMake(newVelocity.x, newVelocity.y / 6.0f);
            if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Elephant) bumpMaxDistance = 2.0f * Utilities.GetDistanceP1(Utilities.CGPointMake(0.0f, 0.0f),
              bumpVelocity);
            else if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Sheep) bumpMaxDistance = 20.0f * Utilities.GetDistanceP1(Utilities.CGPointMake(0.0f, 
              0.0f), bumpVelocity);
            else {
                bumpMaxDistance = 5.0f * Utilities.GetDistanceP1(Utilities.CGPointMake(0.0f, 0.0f), bumpVelocity);
            }

            bumpDirection = Utilities.Normalise(bumpVelocity);
            const float kMaxBumpSameDir = 30.0f;
            const float kMaxBumpOppDir = 80.0f;
            float xThing = bumpMaxDistance * bumpDirection.x;
            if (xSpeed > 0.0f) {
                if (xThing > kMaxBumpSameDir) {
                    bumpMaxDistance = bumpDirection.x * kMaxBumpSameDir;
                }
                else if (xThing < -kMaxBumpOppDir) {
                    bumpMaxDistance = -bumpDirection.x * kMaxBumpOppDir;
                }

            }
            else {
                if (xThing < -kMaxBumpSameDir) {
                    bumpMaxDistance = -bumpDirection.x * kMaxBumpSameDir;
                }
                else if (xThing > kMaxBumpOppDir) {
                    bumpMaxDistance = bumpDirection.x * kMaxBumpOppDir;
                }

            }

            bumpTimer = kCTBumpTime;
        }

        public void UpdateHoofBeats()
        {
            if ((int)crossingThingType != (int) CrossingThingType.kCrossingThing_Sheep) {
                return;
            }

            const float kDistanceForAllHoofs = 200.0f;
            float[] hoofDistanceRatio = new float[4]
            {0.1f, 0.2f, 0.6f, 0.7f};
            distanceBetweenHoofSounds += Utilities.GetABS(xSpeed);
            if (distanceBetweenHoofSounds >= kDistanceForAllHoofs) {
                whichHoof = 0;
                distanceBetweenHoofSounds -= kDistanceForAllHoofs;
            }

            if (whichHoof < 4) {
                float ratio = distanceBetweenHoofSounds / kDistanceForAllHoofs;
                if (ratio >= hoofDistanceRatio[whichHoof]) {
                    this.PlayHoofSound();
                    whichHoof++;
                }

            }

        }

        public void UpdateBumping()
        {
            if (bumpTimer > 0.0f) {
                if (bumpTimer > (kCTBumpTime * 0.5f)) bumpTimer -= Constants.kFrameRate;
                else bumpTimer -= (Constants.kFrameRate / 3.0f);

                if (bumpTimer <= 0.0f) {
                    bumpOffset = Utilities.CGPointMake(0.0f, 0.0f);
                    return;
                }

                float bumpDistance = bumpMaxDistance * Utilities.GetCosInterpolationP1P2(bumpTimer, 0.0f, kCTBumpTime);
                bumpOffset = Utilities.CGPointMake(bumpDistance * bumpDirection.x, bumpDistance * bumpDirection.y);
            }

        }

        public void UpdateShadow(CGPoint realPosition)
        {
            const float kJogDistance = 5.0f;
            float animPosition = (((float) animateIndex) * 20.0f) + animateRoll;
            float shadowDistance;
            if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Elephant) {
                shadowDistance = Utilities.GetCosInterpolationP1P2(animPosition, 0.0f, 80.0f);
                shadowMapObject.SetPosition(Utilities.CGPointMake(realPosition.x + shadowOffset.x + (kJogDistance * shadowDistance), realPosition.y + shadowOffset.y + (
                  kJogDistance * 0.7f * shadowDistance)));
            }

        }

        public void UpdateAmbientSound()
        {
            if (mapObject.GetScreenPos().y < 480.0f) {
                if ((position.x > 64.0f) && (position.x < 704.0f)) {
                    if ((int)crossingThingType == (int) CrossingThingType.kCrossingThing_Elephant) {
                        (Globals.g_world.game).UpdateAmbientMoo();
                    }
                    else {
                        (Globals.g_world.game).UpdateAmbientPenguin();
                    }

                }

            }

        }

        public float CalculateXPosition(float raceTime)
        {
            int numFrames = (int) (raceTime / Constants.kFrameRate);
            numFrames = numFrames % framesToCrossMap;
            float newX = startPosition.x + ((float) numFrames * xSpeed);
            if (newX < (Constants.PLAYABLE_MAP_LEFT_EDGE - (kMapEdgeBuffer / 2.0f))) newX += (Constants.MAP_WIDTH + (kMapEdgeBuffer * 2.0f));
            else if (newX > (Constants.MAP_WIDTH + kMapEdgeBuffer)) {
                newX -= (Constants.MAP_WIDTH + (kMapEdgeBuffer * 2.0f));
            }

            return newX;
        }

        public void UpdateCrossingThing(float raceTime)
        {
            position.x = this.CalculateXPosition(raceTime);
            this.UpdateMoveAnim();
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
                if (i != Constants.RECORDING_WHICH_PIGGY) {
                    (Globals.g_world.game).UpdateNoGoZoneP1P2(noGoZone, (Globals.g_world.game).GetPlayerPiggy(i), false);
                }

            }

        }

        public void Render()
        {
    /*        (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
            CGPoint screenPos = Utilities.GetScreenPositionP1(position, (Globals.g_world.game).GetScrollPosition());
            CGPoint pos = Utilities.CGPointMake(screenPos.x, screenPos.y);
            (DrawManager.Instance()).AddTextureToListP1(pos, 0);
            pos = Utilities.CGPointMake(screenPos.x, screenPos.y + 40.0f);
            (DrawManager.Instance()).AddTextureToListP1(pos, 1);
            (DrawManager.Instance()).Flush();*/
        }

    }
}
