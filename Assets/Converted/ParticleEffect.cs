using System;

namespace Default.Namespace
{
    public enum  EffectState {
        e_Active,
        e_Frozen,
        e_Inactive
    }
    public class ParticleEffect
    {
        public EffectType effectType;
        public float timer;
        public float timer2;
        public EffectState state;
        public Player player;
        public CGPoint emitPosition;
        public EffectState State
        {
            get;
            set;
        }

        public EffectType EffectType
        {
            get;
            set;
        }

        public Player Player
        {
            get;
            set;
        }

		public void SetState(EffectState inThing) {state = inThing;}///@property(readwrite,assign) EffectState state;
public void SetEffectType(EffectType inThing) {effectType = inThing;}///@property(readwrite,assign) EffectType effectType;
public void SetPlayer(Player inThing) {player = inThing;}////@property(readwrite,assign) Player* player;

        public ParticleEffect()
        {
            //if (!base.init()) return null;

            //return this;
        }
        public void Reset()
        {
            state = EffectState.e_Inactive;
        }

        public void Update()
        {
            if (state != (int) EffectState.e_Active) return;

            switch (effectType) {
            case EffectType.kEffect_StarBurst :
                this.UpdateStarBurst();
                break;
            case EffectType.kEffect_RainbowStarTrail :
                this.UpdateRainbowStarTrail();
                break;
            case EffectType.kEffect_GreenAntScreen :
                this.UpdateGreenAntScreen();
                break;
            case EffectType.kEffect_SplashingInWater :
                this.UpdateSplashingInWater();
                break;
            case EffectType.kEffect_SpeedBoostStars :
                this.UpdateSpeedBoostStars();
                break;
            case EffectType.kEffect_BoostArrowStars :
                this.UpdateBoostArrowStars();
                break;
            default :
                break;
            }

        }

        public void UpdateSplashingInWater()
        {
            timer += player.GetDistanceLastFrame() + 1;
            const float kTimeBetweenSplashes = 20;
            if (timer >= kTimeBetweenSplashes) {
                ParticleList inList;
                if (player.positionZ < -5.0f) {
                    inList = ParticleList.t_DownInRiver;
                }
                else {
                    inList = ParticleList.t_BeforePlayer;
                }

                Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(inList, "scal_rip");
                if (particle != null) {
                    CGPoint pos = player.position;
                    CGPoint speed = player.GetActualSpeed();
                    if ((Utilities.GetABS(speed.x) < 0.01f) && (Utilities.GetABS(speed.y) < 0.01f)) {
                        speed = Utilities.CGPointMake(0.0f, 0.0f);
                    }
                    else {
                        speed = Utilities.Normalise(speed);
                    }

                    pos.x = pos.x + (speed.x * 20);
                    pos.y = pos.y + (speed.y * 20);
                    particle.Launch_ScalingRipple(pos);
                    particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),9);
                }

                timer -= kTimeBetweenSplashes;
            }

        }

        public void UpdateSpeedBoostStars()
        {
            int howOften;
            if (Globals.g_world.deviceType == (int) UIDevicePlatform.UIDevice3GiPhone) howOften = 5;
            else {
                howOften = 3;
            }

            if (Utilities.GetRand( howOften) == 0) {
                Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_WhiteStars, "speedbooststars");
                if (particle != null) {
                    Particle.ParticleInfo info = new Particle.ParticleInfo();
                    info.isAdditive = true;
                    info.type = ParticleType.kParticle_Generic;
                    info.texture[0] = (Globals.g_world.GetGame()).GetTexture( TextureType.kTexture_SpeedTrailWhiteStar);
                    info.startPosition = player.GetPosition();
                    info.startPosition.x += ((float)(Utilities.GetRand( 30))) - 15;
                    info.startPosition.y += ((float)(Utilities.GetRand( 30))) - 15;
                    info.startPosition.y -= player.GetActualSpeed().y * 1.5f;
                    info.velocity = Utilities.CGPointMake(player.GetActualSpeed().x * 0.5f, player.GetActualSpeed().y * 0.5f);
                    info.startPosition.y += Utilities.GetYOffsetFromHeight(player.positionZ);
                    info.rotationSpeed = 0.2f;
                    info.alphaStart = 0.5f;
                    info.alphaSpeed = 0.025f;
                    info.scaleSpeed = Globals.g_world.GetRotationScaleForShorts(-0.075f);
                    info.scaleStart = 0.25f;
                    float scaleFactor = Utilities.GetScaleFromHeight(player.positionZ);
                    if (scaleFactor > 1.0f) {
                        info.scaleSpeed *= (scaleFactor * 1.0f);
                        info.scaleStart *= (scaleFactor * 1.0f);
                    }

                    particle.Launch_SingleParticle(info);
                    particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),16);
                    particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(22.63f * scaleFactor));
                    if (Globals.deviceIPad) {
                        float rotScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene)).GetSubTextureRotationScale(particle.subTextureId);
                        particle.SetRotationScale(rotScale);
                    }
					particle.SetIsAdditive(true);
                }

            }

        }

        public void UpdateBoostArrowStars()
        {
            for (int i = 0; i < 2; i++) {
                Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_WhiteStars, "boost arrow stars");
                if (particle != null) {
                    Particle.ParticleInfo info = new Particle.ParticleInfo();
                    info.isAdditive = true;
                    info.type = ParticleType.kParticle_Generic;
                    info.texture[0] = null;
                    info.startPosition = player.GetPosition();
                    info.startPosition.x += ((float)(Utilities.GetRand( 30))) - 15;
                    info.startPosition.y += ((float)(Utilities.GetRand( 30))) - 15;
                    info.startPosition.y -= 15.0f;
                    info.startPosition.y += Utilities.GetYOffsetFromHeight(player.positionZ);
                    info.velocity = Utilities.CGPointMake(player.GetActualSpeed().x * 0.5f, player.GetActualSpeed().y * 0.5f);
                    info.rotationSpeed = 0.2f;
                    info.alphaStart = 0.5f;
                    info.alphaSpeed = 0.035f;
                    info.scaleSpeed = Globals.g_world.GetRotationScaleForShorts(-0.05f * 3.56f);
                    info.scaleStart = 0.25f * 3.56f;
                    float scaleFactor = Utilities.GetScaleFromHeight(player.positionZ);
                    if (scaleFactor > 1.0f) {
                        info.scaleSpeed *= (scaleFactor * 1.0f);
                        info.scaleStart *= (scaleFactor * 1.0f);
                    }

                    if (Globals.deviceIPad) {
                        info.scaleSpeed *= 2.0f;
                    }

                    particle.Launch_SingleParticle(info);
                    particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),15);
                    particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(Constants.ROT_SCALE_64 * scaleFactor));
                    if (Globals.deviceIPad) {
                        particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(Constants.ROT_SCALE_64 * scaleFactor * 2.0f));
                    }
					particle.SetIsAdditive(true);
                }

            }

        }

        public void UpdateRainbowStarTrail()
        {
            CGPoint position = player.GetPosition();
            CGPoint screenPosition = Utilities.GetScreenPositionP1(position, (Globals.g_world.GetGame()).GetScrollPosition());
            if (!Utilities.IsOnScreen(screenPosition)) {
                return;
            }

            int howMany;
            if (Globals.g_world.artLevel == 0) {
                if ((Globals.g_world.game).numPlayersOnScreen >= 3) {
                    if (Utilities.GetRand( 2) == 0) {
                        return;
                    }

                }

                howMany = 1;
            }
            else {
                howMany = 2;
            }

            for (int i = 0; i < howMany; i++) {
                Particle particle;
                bool isAdditive = false;
                if (Utilities.GetRand( 9) == 0) {
                    particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_AdditiveInFrontOfPlayer, "rainbowstars");
                    isAdditive = true;
                }
                else {
                    particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_AfterEverything, "rainbowstars");
                }

                if (particle != null) {
                    particle.Launch_RainbowStarTrail(Utilities.CGPointMake(position.x, position.y - 15.0f));
                    particle.SetIsAdditive(isAdditive);
                }

            }

            if (timer >= 2) {
            }

            timer += Constants.kFrameRate;
        }

        public void UpdateGreenAntScreen()
        {
            Particle.ParticleInfo info = new Particle.ParticleInfo();
            info.startPosition = Utilities.CGPointMake(160, 140);
            info.velocity = Utilities.CGPointMake(0, 1);
            timer += Constants.kFrameRate;
            const float kSpinTime = 2.0f;
            if (timer >= kSpinTime) {
                timer -= kSpinTime;
            }

            float radians = Utilities.GetRatioP1P2(timer, 0, kSpinTime) * Constants.TWO_PI * 4.0f;
            float wx = 3.0f;
            info.velocity = Utilities.CGPointMake((float)(Math.Cos(radians) * wx), (float)(Math.Sin(radians) * wx));
            const float kSideSideTime = 10.0f;
            timer2 += Constants.kFrameRate;
            if (timer2 >= kSideSideTime) {
                timer2 = 0.0f;
            }

            info.startPosition.x = 50.0f + (220.0f * Utilities.GetCosInterpolationP1P2(timer2, 0, kSideSideTime));
            for (int i = 0; i < 2; i++) {
                Particle particle;
                bool isAdditive = false;
                if (Utilities.GetRand( 9) == 0) {
                    particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_AdditiveInFrontOfPlayer, "rainbowstars");
                    isAdditive = true;
                }
                else {
                    particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_AfterEverything, "rainbowstars");
                }

                if (particle != null) {
                    if (i == 1) {
                        info.startPosition.x = 320.0f - info.startPosition.x;
                        info.velocity.x = -info.velocity.x;
                    }

                    particle.Launch_GreenAntScreen(info);
                    particle.SetIsAdditive(isAdditive);
                }

            }

            if (timer >= 2) {
            }

            timer += 0.02f;
        }

        public void UpdateStarBurst()
        {
        }

        public void StartEffect_SingleSparkle(ParticleSystemRoss.EffectInfo info)
        {
            Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
            pInfo.startPosition = info.startPosition;
            pInfo.velocity.x = 0;
            pInfo.velocity.y = 0;
            Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_AdditiveInFrontOfPlayer, "singlesparkle");
            if (particle != null) {
                particle.Launch_MenuSparkle(pInfo);
            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_SplashRingP1(ParticleSystemRoss.EffectInfo info, bool isMud)
        {
            const int kNumSplashesInRing = 10;
            Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
            pInfo.type = ParticleType.kParticle_SingleSplash;
            pInfo.hasGravity = false;
            pInfo.isAnimated = true;
            pInfo.numAnimFrames = 4;
            pInfo.texture[0] = (ParticleSystemRoss.Instance()).GetTexture( ParticleTextureType.kParticleTexture_Splash1);
            pInfo.texture[1] = (ParticleSystemRoss.Instance()).GetTexture( ParticleTextureType.kParticleTexture_Splash2);
            pInfo.texture[2] = (ParticleSystemRoss.Instance()).GetTexture( ParticleTextureType.kParticleTexture_Splash3);
            pInfo.texture[3] = (ParticleSystemRoss.Instance()).GetTexture( ParticleTextureType.kParticleTexture_Splash4);
            pInfo.animatedSubtexture[0] = 5;
            pInfo.animatedSubtexture[1] = 6;
            pInfo.animatedSubtexture[2] = 7;
            pInfo.animatedSubtexture[3] = 8;
            if (isMud) {
                pInfo.animatedSubtexture[0] = 18;
                pInfo.animatedSubtexture[1] = 19;
                pInfo.animatedSubtexture[2] = 20;
                pInfo.animatedSubtexture[3] = 21;
            }

            pInfo.timeBetweenAnimFrames[0] = 0.1f;
            pInfo.timeBetweenAnimFrames[1] = 0.1f;
            pInfo.timeBetweenAnimFrames[2] = 0.1f;
            pInfo.timeBetweenAnimFrames[3] = 0.1f;
            pInfo.alphaStart = 1;
            int randSplash = 1 + Utilities.GetRand( 8);
            float circleSize = Constants.PI_ + Constants.HALF_PI;
            float perThing = circleSize / ((float) kNumSplashesInRing);
            float outSpeed = 3.2f;
            float playerSpeedInf = 0.8f;
            float dirMultip = 1.0f;
            if (isMud) {
                outSpeed = 2.6f;
                playerSpeedInf = 0.9f;
                dirMultip = 0.8f;
            }

            pInfo.scaleStart = 1;
            for (int i = 0; i < kNumSplashesInRing; i++) {
                if (isMud) {
                    if (i != randSplash) {
                        continue;
                    }

                }

                float directionMulti = Utilities.GetABS(4.5f - ((float) i));
                float angle = (info.rotation - Constants.HALF_PI) - (circleSize / 2) + (perThing * ((float) i));
                pInfo.rotationStart = -angle + (Constants.HALF_PI);
                pInfo.velocity = Utilities.GetVectorFromAngleP1(angle, outSpeed);
                pInfo.velocity.x += (playerSpeedInf * info.velocity.x);
                pInfo.velocity.y += (playerSpeedInf * info.velocity.y);
                pInfo.startPosition = Utilities.CGPointMake(info.startPosition.x + (pInfo.velocity.x * (directionMulti * dirMultip)), info.startPosition.y + (pInfo.
                  velocity.y * (directionMulti * dirMultip)));
                Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(info.inList, "splashring");
                if (particle != null) {
                    particle.Launch_AnimatedParticle(pInfo);
                    particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),pInfo.animatedSubtexture[0]);
                    particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(22.6274f));
                    if (Globals.deviceIPad) {
                        float rotScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene)).GetSubTextureRotationScale(particle.subTextureId);
                        particle.SetRotationScale(rotScale);
                    }

                }

            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_BoostGlow(ParticleSystemRoss.EffectInfo info)
        {
            Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
            pInfo.type = ParticleType.kParticle_BoostGlow;
            pInfo.isAdditive = true;
            pInfo.alphaSpeed = 0.04f;
            pInfo.scaleSpeed = 0.2f;
            pInfo.alphaStart = 1;
            pInfo.scaleStart = 1;
            pInfo.texture[0] = (ParticleSystemRoss.Instance()).GetTexture( ParticleTextureType.kParticleTexture_BoostGlowRed + ((int) info.velocity.x));
            pInfo.velocity = Utilities.CGPointMake(0, 0);
            pInfo.startPosition = info.startPosition;
            Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_BeforePlayer, "boost glow");
            if (particle != null) {
                particle.Launch_SingleParticle(pInfo);
            }
			particle.SetIsAdditive(true);
            state = EffectState.e_Inactive;
        }

        public void StartEffect_PowerSkid(ParticleSystemRoss.EffectInfo info)
        {
            Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
            pInfo.type = ParticleType.kParticle_PowerSkid;
            pInfo.hasGravity = false;
            pInfo.isAnimated = true;
            pInfo.numAnimFrames = 5;
            pInfo.rotationStart = info.rotation;
            pInfo.velocity = Utilities.CGPointMake(info.velocity.x, info.velocity.y);
            for (int i = 0; i < 5; i++) pInfo.texture[i] = (ParticleSystemRoss.Instance()).GetTexture( ParticleTextureType.kParticleTexture_PowerSkidDustPuff1
              + i);

            pInfo.timeBetweenAnimFrames[0] = 0.04f;
            pInfo.timeBetweenAnimFrames[1] = 0.04f;
            pInfo.timeBetweenAnimFrames[2] = 0.07f;
            pInfo.timeBetweenAnimFrames[3] = 0.09f;
            pInfo.timeBetweenAnimFrames[4] = 0.11f;
            pInfo.startPosition = info.startPosition;
            pInfo.alphaStart = 0.5f;
            pInfo.scaleStart = 1;
            pInfo.scaleSpeed = 0.01f;
            Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_BeforePlayer, "powerskid");
            if (particle != null) {
                particle.Launch_AnimatedParticle(pInfo);
            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_RainbowBurst(ParticleSystemRoss.EffectInfo info)
        {
            Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
            pInfo.startPosition = info.startPosition;
            pInfo.velocity.x = 0;
            pInfo.velocity.y = 5;
            {
                Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_AdditiveInFrontOfPlayer, "rainbow burst");
                if (particle != null) {
                    particle.Launch_StarBurst(pInfo);
                    particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),30);
                }

            }
            state = EffectState.e_Inactive;
        }

        public void StartEffect_SplashingInWater(ParticleSystemRoss.EffectInfo info)
        {
            timer = 10;
            player = info.player;
        }

        public void StartEffect_BushCrash(ParticleSystemRoss.EffectInfo info)
        {
        }

        public void StartEffect_Grass(ParticleSystemRoss.EffectInfo info)
        {
            Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_BeforePlayer, "grass");
            if (particle != null) {
                Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
                pInfo.type = ParticleType.kParticle_Grass;
                pInfo.isAnimated = true;
                pInfo.numAnimFrames = 4;
                pInfo.hasGravity = false;
                pInfo.alphaStart = 1;
                pInfo.velocity = Utilities.CGPointMake(0, 0);
                pInfo.rotationStart = 0;
                pInfo.rotationSpeed = 0;
                pInfo.scaleStart = 2.0f;
                pInfo.scaleSpeed = 0;
                for (int i = 0; i < pInfo.numAnimFrames; i++) {
                    pInfo.texture[i] = (ParticleSystemRoss.Instance()).GetTexture( ParticleTextureType.kParticleTexture_Grass1 + i);
                }

                pInfo.timeBetweenAnimFrames[0] = 0.07f;
                pInfo.timeBetweenAnimFrames[1] = 0.07f;
                pInfo.timeBetweenAnimFrames[2] = 0.07f;
                pInfo.timeBetweenAnimFrames[3] = 0.07f;
                pInfo.startPosition = info.startPosition;
                pInfo.animatedSubtexture[0] = 18;
                pInfo.animatedSubtexture[1] = 19;
                pInfo.animatedSubtexture[2] = 20;
                pInfo.animatedSubtexture[3] = 21;
                particle.Launch_AnimatedParticle(pInfo);
                particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),18);
            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_DustCloud(ParticleSystemRoss.EffectInfo info)
        {
            Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_BeforePlayer, "dustcloudf");
            if (particle != null) {
                Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
                pInfo.type = ParticleType.kParticle_DustCloud;
                pInfo.isAnimated = true;
                pInfo.numAnimFrames = 5;
                pInfo.hasGravity = false;
                pInfo.alphaStart = 0.6f;
                pInfo.scaleStart = 2.0f;
                pInfo.rotationStart = 0.0f;
                pInfo.rotationSpeed = 0.0f;
                pInfo.velocity = Utilities.CGPointMake(info.velocity.x * 0.5f, info.velocity.y * 0.5f);
                for (int i = 0; i < 5; i++) {
                    pInfo.texture[i] = null;
                    pInfo.animatedSubtexture[i] = i;
                }

                pInfo.timeBetweenAnimFrames[0] = 0.04f;
                pInfo.timeBetweenAnimFrames[1] = 0.04f;
                pInfo.timeBetweenAnimFrames[2] = 0.07f;
                pInfo.timeBetweenAnimFrames[3] = 0.09f;
                pInfo.timeBetweenAnimFrames[4] = 0.11f;
                pInfo.startPosition = info.startPosition;
                particle.Launch_AnimatedParticle(pInfo);
                particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),pInfo.animatedSubtexture[0]);
                particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(Constants.ROT_SCALE_64));
                if (Globals.deviceIPad) {
                    float rotScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene)).GetSubTextureRotationScale(particle.subTextureId);
                    particle.SetRotationScale(rotScale);
                }

            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_SparkBurst(ParticleSystemRoss.EffectInfo info)
        {
            const int kNumSplashesInRing = 3;
            Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
            pInfo.type = ParticleType.kParticle_SingleSpark;
            pInfo.hasGravity = false;
            pInfo.isAnimated = false;
            pInfo.alphaStart = info.rotation;
            pInfo.alphaSpeed = 0.07f;
            float circleSize = Constants.PI_ + Constants.HALF_PI;
            float perThing = circleSize / ((float) kNumSplashesInRing);
            float outSpeed = 7.2f;
            float playerSpeedInf = 1.6f;
            pInfo.scaleStart = 2.0f;
            pInfo.scaleSpeed = 0.0f;
			pInfo.isAdditive = true;
            for (int i = 0; i < kNumSplashesInRing; i++) {
                float angle = (0.0f - Constants.HALF_PI) - (circleSize / 2) + (perThing * ((float) i));
                angle += Utilities.GetRandBetweenP1(-0.5f, 0.5f);
                pInfo.rotationStart = -angle + (Constants.HALF_PI);
                pInfo.velocity = Utilities.GetVectorFromAngleP1(angle, outSpeed);
                pInfo.velocity.x += (playerSpeedInf * info.velocity.x);
                pInfo.velocity.y += (playerSpeedInf * info.velocity.y);
                pInfo.startPosition = info.startPosition;
                Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_WhiteStars, "splashring");
                if (particle != null) {
                    particle.Launch_SingleParticle(pInfo);
                    particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),25);
                    particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(44.3274f));
                    if (Globals.deviceIPad) {
                        float rotScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene)).GetSubTextureRotationScale(particle.subTextureId);
                        particle.SetRotationScale(rotScale);
                    }

                }

            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_Sparks(ParticleSystemRoss.EffectInfo info)
        {
            Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_BeforePlayer, "dustcloudf");
            if (particle != null) {
                Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
                pInfo.type = ParticleType.kParticle_Sparks;
                pInfo.isAnimated = true;
                pInfo.numAnimFrames = 3;
                pInfo.hasGravity = false;
                pInfo.alphaStart = 1.0f;
                pInfo.scaleStart = 4.0f;
                pInfo.rotationStart = 0.0f;
                pInfo.rotationSpeed = 0.0f;
                pInfo.velocity = Utilities.CGPointMake(info.velocity.x * 0.5f, info.velocity.y * 0.8f);
                for (int i = 0; i < 3; i++) {
                    pInfo.texture[i] = null;
                    pInfo.animatedSubtexture[i] = i + 22;
                }

                pInfo.timeBetweenAnimFrames[0] = 0.04f;
                pInfo.timeBetweenAnimFrames[1] = 0.04f;
                pInfo.timeBetweenAnimFrames[2] = 0.03f;
                pInfo.timeBetweenAnimFrames[3] = 0.09f;
                pInfo.timeBetweenAnimFrames[4] = 0.11f;
                pInfo.startPosition = info.startPosition;
                particle.Launch_AnimatedParticle(pInfo);
                particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),pInfo.animatedSubtexture[0]);
                particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(Constants.ROT_SCALE_64));
                if (Globals.deviceIPad) {
                    float rotScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene)).GetSubTextureRotationScale(particle.subTextureId);
                    particle.SetRotationScale(rotScale);
                }

            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_DustCloudTrail(ParticleSystemRoss.EffectInfo info)
        {
            Particle.ParticleInfo pInfo = new Particle.ParticleInfo();
            float minDustSpeed;
            if (Globals.g_world.artLevel == 0) {
                minDustSpeed = 6.5f;
            }
            else {
                minDustSpeed = 4.5f;
            }

            if (player.playerType != (int) PlayerType.kPlayerSheep) pInfo.alphaStart = 0.05f + (0.4f * Utilities.GetRatioP1P2(player.GetDistanceLastFrame(),
              minDustSpeed, 12.0f));
            else pInfo.alphaStart = 0.1f + (0.52f * Utilities.GetRatioP1P2(player.GetDistanceLastFrame(), minDustSpeed, 12.0f));

            if (pInfo.alphaStart < 0.3f) {
                state = EffectState.e_Inactive;
                return;
            }

            Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_BeforePlayer, "dust cloud trail");
            if (particle != null) {
                Particle.ParticleInfo info2 = new Particle.ParticleInfo();
                info2.isAdditive = false;
                info2.type = ParticleType.kParticle_Generic;
                info2.texture[0] = (Globals.g_world.game).GetTexture( TextureType.kTexture_BoostExplosion);
                info2.startPosition = player.GetPosition();
                info2.startPosition.x += ((float)(Utilities.GetRand( 30))) - 15;
                info2.startPosition.y += ((float)(Utilities.GetRand( 30))) - 15;
                info2.startPosition.x -= player.GetActualSpeed().x;
                info2.startPosition.y -= player.GetActualSpeed().y;
                info2.velocity = Utilities.CGPointMake(player.GetActualSpeed().x * 0.5f, player.GetActualSpeed().y * 0.5f);
                info2.rotationSpeed = 0.2f;
                info2.alphaStart = pInfo.alphaStart;
                if (Globals.g_world.artLevel == 2) {
                    if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMud) info2.alphaSpeed = 0.014f;
                    else info2.alphaSpeed = 0.012f;

                }
                else if (Globals.g_world.artLevel == 1) info2.alphaSpeed = 0.015f;
                else {
                    if ((Globals.g_world.game).numPlayersOnScreen >= 3) info2.alphaSpeed = 0.04f;
                    else {
                        info2.alphaSpeed = 0.0225f;
                    }

                }

                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneIce) {
                    if (Globals.g_world.artLevel == 2) info2.alphaSpeed = 0.007f;

                }

                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneMud) {
                    if (Globals.g_world.artLevel != 0) {
                        info2.alphaStart *= 1.65f;
                        info2.alphaSpeed *= 1.65f;
                    }

                }

                info2.scaleSpeed = -0.05f; //-1.0f * 0.05 ... //Globals.g_world.GetRotationScaleForShorts(-1.0f);
                info2.scaleStart = 1.0f;
                particle.Launch_SingleParticle(info2);
                particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),0);
                particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(45.1f));
                if (Globals.deviceIPad) {
                    float rotScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene)).GetSubTextureRotationScale(particle.subTextureId);
                    particle.SetRotationScale(rotScale);
                }
				particle.SetIsAdditive(false);

            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_DustCloudTrailWithoutPlayer(ParticleSystemRoss.EffectInfo inInfo)
        {
            Particle particle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(ParticleList.t_BeforePlayer, "dust cloud trail wo pla");
            if (particle != null) {
                Particle.ParticleInfo info = new Particle.ParticleInfo();
                info.isAdditive = false;
                info.type = ParticleType.kParticle_Generic;
                info.texture[0] = null;
                info.startPosition = inInfo.startPosition;
                info.velocity = inInfo.velocity;
                info.rotationSpeed = 0.2f;
                info.alphaStart = 0.75f;
                info.alphaSpeed = 0.02f;
                info.scaleSpeed = -0.05f;//Globals.g_world.GetRotationScaleForShorts(-1.0f);
                info.scaleStart = 1.0f;
                particle.Launch_SingleParticle(info);
                particle.SetAtlasAndSubTextureId(Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene),0);
                particle.SetRotationScale(Globals.g_world.GetRotationScaleForShorts(45.1f));
                if (Globals.deviceIPad) {
                    float rotScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_ParticlesScene)).GetSubTextureRotationScale(particle.subTextureId);
                    particle.SetRotationScale(rotScale);
                }
				particle.SetIsAdditive(false);
            }

            state = EffectState.e_Inactive;
        }

        public void StartEffect_RainbowStarTrail(ParticleSystemRoss.EffectInfo info)
        {
        }

        public void StartEffect(ParticleSystemRoss.EffectInfo info)
        {
            effectType = info.type;
            timer = 0;
            state = EffectState.e_Active;
            player = info.player;
            switch (effectType) {
            case EffectType.kEffect_DustCloud :
                this.StartEffect_DustCloud(info);
                break;
            case EffectType.kEffect_Sparks :
                this.StartEffect_SparkBurst(info);
                break;
            case EffectType.kEffect_DustCloudTrail :
                this.StartEffect_DustCloudTrail(info);
                break;
            case EffectType.kEffect_DustCloudTrailWithoutPlayer :
                this.StartEffect_DustCloudTrailWithoutPlayer(info);
                break;
            case EffectType.kEffect_BushCrash :
                this.StartEffect_BushCrash(info);
                break;
            case EffectType.kEffect_SplashingInWater :
                this.StartEffect_SplashingInWater(info);
                break;
            case EffectType.kEffect_RainbowBurst :
                this.StartEffect_RainbowBurst(info);
                break;
            case EffectType.kEffect_SingleSparkle :
                this.StartEffect_SingleSparkle(info);
                break;
            case EffectType.kEffect_SplashRing :
                this.StartEffect_SplashRingP1(info, false);
                break;
            case EffectType.kEffect_SplashRingMud :
                this.StartEffect_SplashRingP1(info, true);
                break;
            case EffectType.kEffect_Grass :
                this.StartEffect_Grass(info);
                break;
            case EffectType.kEffect_BoostGlow :
                this.StartEffect_BoostGlow(info);
                break;
            case EffectType.kEffect_PowerSkid :
                this.StartEffect_PowerSkid(info);
                break;
            case EffectType.kEffect_RainbowStarTrail :
                this.StartEffect_RainbowStarTrail(info);
                break;
            case EffectType.kEffect_GreenAntScreen :
                timer2 = 0.0f;
                break;
            default :
                break;
            }

        }

        public bool IsActive()
        {
            return (state == (int) EffectState.e_Active);
        }

    }
}
