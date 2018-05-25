using System;

namespace Default.Namespace
{
    public enum  ParticleType {
        kParticle_StarBurst,
        kParticle_RainbowStarTrail,
        kParticle_SingleSpark,
        kParticle_Sparks,
        kParticle_DustCloud,
        kParticle_DustCloudTrail,
        kParticle_BushCrash,
        kParticle_ScalingRipple,
        kParticle_MenuSparkle,
        kParticle_MaxSpeedShimmer,
        kParticle_Animated,
        kParticle_Grass,
        kParticle_Generic,
        kParticle_SingleSplash,
        kParticle_BoostGlow,
        kParticle_GreenAntScreen,
        kParticle_PowerSkid,
        kParticle_WaterSparkle,
        kParticle_WaterLine,
        kParticle_PondBlob
    }
    public enum  ParticleTextureType {
        kParticleTexture_SparkleRed = 0,
        kParticleTexture_SparkleRed2,
        kParticleTexture_SparkleRed3,
        kParticleTexture_SparkleRed4,
        kParticleTexture_SparkleRed5,
        kParticleTexture_SparkleRed6,
        kParticleTexture_SparkleOrange,
        kParticleTexture_SparkleOrange2,
        kParticleTexture_SparkleOrange3,
        kParticleTexture_SparkleOrange4,
        kParticleTexture_SparkleOrange5,
        kParticleTexture_SparkleOrange6,
        kParticleTexture_SparkleYellow,
        kParticleTexture_SparkleYellow2,
        kParticleTexture_SparkleYellow3,
        kParticleTexture_SparkleYellow4,
        kParticleTexture_SparkleYellow5,
        kParticleTexture_SparkleYellow6,
        kParticleTexture_SparkleBlue,
        kParticleTexture_SparkleBlue2,
        kParticleTexture_SparkleBlue3,
        kParticleTexture_SparkleBlue4,
        kParticleTexture_SparkleBlue5,
        kParticleTexture_SparkleBlue6,
        kParticleTexture_SparkleGreen,
        kParticleTexture_SparkleGreen2,
        kParticleTexture_SparkleGreen3,
        kParticleTexture_SparkleGreen4,
        kParticleTexture_SparkleGreen5,
        kParticleTexture_SparkleGreen6,
        kParticleTexture_SparkleMauve,
        kParticleTexture_SparkleMauve2,
        kParticleTexture_SparkleMauve3,
        kParticleTexture_SparkleMauve4,
        kParticleTexture_SparkleMauve5,
        kParticleTexture_SparkleMauve6,
        kParticleTexture_Grass1,
        kParticleTexture_Grass2,
        kParticleTexture_Grass3,
        kParticleTexture_Grass4,
        kParticleTexture_DustCloud1,
        kParticleTexture_DustCloud2,
        kParticleTexture_DustCloud3,
        kParticleTexture_DustCloud4,
        kParticleTexture_DustCloud5,
        kParticleTexture_DustCloudTrail1,
        kParticleTexture_DustCloudTrail2,
        kParticleTexture_DustCloudTrail3,
        kParticleTexture_DustCloudTrail4,
        kParticleTexture_DustCloudTrail5,
        kParticleTexture_Ripple,
        kParticleTexture_Splash1,
        kParticleTexture_Splash2,
        kParticleTexture_Splash3,
        kParticleTexture_Splash4,
        kParticleTexture_BoostGlowRed,
        kParticleTexture_BoostGlowYellow,
        kParticleTexture_BoostGlowGreen,
        kParticleTexture_BoostGlowBlue,
        kParticleTexture_BoostGlowPurple,
        kParticleTexture_PowerSkidDustPuff1,
        kParticleTexture_PowerSkidDustPuff2,
        kParticleTexture_PowerSkidDustPuff3,
        kParticleTexture_PowerSkidDustPuff4,
        kParticleTexture_PowerSkidDustPuff5,
        kParticleTexture_RainbowPop,
        kNumParticleTextures
    }
    public enum  EffectType {
        kEffect_SingleSparkle,
        kEffect_StarBurst,
        kEffect_RainbowStarTrail,
        kEffect_DustCloud,
        kEffect_Sparks,
        kEffect_Grass,
        kEffect_DustCloudTrail,
        kEffect_BushCrash,
        kEffect_SplashingInWater,
        kEffect_RainbowBurst,
        kEffect_MaxSpeedShimmer,
        kEffect_SplashRing,
        kEffect_SplashRingMud,
        kEffect_SpeedBoostStars,
        kEffect_BoostGlow,
        kEffect_BoostArrowStars,
        kEffect_PowerSkid,
        kEffect_GreenAntScreen,
        kEffect_DustCloudTrailWithoutPlayer
    }
    
    public class Particle
    {
		public Billboard myAtlasBillboard;
		
        public CGPoint mapPosition;
        public bool isAdditive;
        public CGPoint screenPosition;
        public CGPoint velocity;
        public float timer;
        public float scale;
        public float alpha;
        public float rotation;
        public float[] timeBetweenAnimFrames = new float[(int)Enum1.kMaxAnimFrames];
        public bool isActive;
        public bool isAnimated;
        public bool hasGravity;
        public int numAnimFrames;
        public int currentAnim;
        public ZAtlas atlas;
        public int subTextureId;
        public int[] animatedSubtexture = new int[(int)Enum1.kMaxAnimFrames];
        public Texture2D_Ross texture;
        public Texture2D_Ross[] animFrame = new Texture2D_Ross[(int)Enum1.kMaxAnimFrames];
        public ParticleType type;
        public int next;
        public float animTimer;
        public float rotationSpeed;
        public float scaleSpeed;
        public float alphaSpeed;
        public float alphaStart;
        public float rotationScale;
        public enum Enum {
            kMaxParticleEffects = 40,
            kMaxParticles = 200
        };
        public class ParticleInfo{
            public bool isAnimated;
            public bool isAdditive;
            public bool hasGravity;
            public int numAnimFrames;
            public float[] timeBetweenAnimFrames = new float [(int)Enum1.kMaxAnimFrames];
            public float rotationStart;
            public CGPoint velocity;
            public CGPoint startPosition;
            public Texture2D_Ross[] texture = new Texture2D_Ross [(int)Enum1.kMaxAnimFrames];
            public int[] animatedSubtexture = new int [(int)Enum1.kMaxAnimFrames];
            public ParticleType type;
            public float rotationSpeed;
            public float scaleStart;
            public float scaleSpeed;
            public float alphaSpeed;
            public float alphaStart;
            public ZAtlas atlas;
        };
        public enum Enum1 {
            kMaxAnimFrames = 6
        };

		public CGPoint ScreenPosition
        {
            get;
            set;
        }

        public int Next
        {
            get;
            set;
        }

        public float Rotation
        {
            get;
            set;
        }

        public int SubTextureId
        {
            get;
            set;
        }

        public bool IsAdditive
        {
            get;
            set;
        }

        public float RotationScale
        {
            get;
            set;
        }

public void SetScreenPosition(CGPoint inThing) {screenPosition = inThing;}///@property(readwrite,assign) CGPoint screenPosition;
public void SetNext(int inThing) {next = inThing;}///@property(readwrite,assign) int next;
public void SetRotation(float inThing) {rotation = inThing;}///@property(readwrite,assign) CGFloat rotation;
public void SetAtlasAndSubTextureId(ZAtlas inAtlas, int inThing) 
		{	
			atlas = inAtlas;
			
			myAtlasBillboard.SetAtlas(atlas);			
			myAtlasBillboard.SetDetailsFromAtlas(atlas,inThing);
			subTextureId = inThing;
			this.SetIsAdditive(isAdditive);
		}

		
public void ResetParticle() 
		{
			if (myAtlasBillboard != null)
				myAtlasBillboard.Reset();
		}
		
		///@property(readwrite,assign) short int subTextureId;
public void SetIsAdditive(bool inThing) 
		{
			//This is the instantiation of a new particle... so...
			this.ResetParticle();
			
			if (true)//inThing != isAdditive)
			{
				isAdditive = inThing;

				//change the shader...
				if (isAdditive)
				{
					myAtlasBillboard.SetNewShader(Billboard.ShaderTypeEnum.kShader_Additive);
				}
				else
				{
					myAtlasBillboard.SetNewShader(Billboard.ShaderTypeEnum.kShader_Transparent);
				}
			}	
		}///@property(readwrite,assign) BOOL isAdditive;
public void SetRotationScale(float inThing) {rotationScale = inThing;}///@property(readwrite,assign) CGFloat rotationScale;


        public Particle()
        {
            //if (!base.init()) return null;

            rotationScale = 100;
            //return this;
			
			isAdditive = false;

			myAtlasBillboard = new Billboard("particle");
		}

		public void SetupAtlasDetails()
        {
			myAtlasBillboard.SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_ParticlesScene));
			myAtlasBillboard.SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_ParticlesScene),0);
	//		myAtlasBillboard.SetRenderQueue(9000);			
		}
		
		public void Launch_AnimatedParticle(ParticleInfo info)
        {
//            isAdditive = false;
			this.SetIsAdditive(false);
            type = info.type;
            hasGravity = info.hasGravity;
            isAnimated = info.isAnimated;
            numAnimFrames = info.numAnimFrames;
            texture = info.texture[0];
            velocity = info.velocity;
            mapPosition = info.startPosition;
            rotation = info.rotationStart;
            for (int i = 0; i < numAnimFrames; i++) {
                Globals.Assert(i < (int)Enum1.kMaxAnimFrames);
                animFrame[i] = info.texture[i];
                animatedSubtexture[i] = info.animatedSubtexture[i];
                timeBetweenAnimFrames[i] = info.timeBetweenAnimFrames[i];
            }

            animTimer = 0;
            currentAnim = 0;
            scale = info.scaleStart;
            scaleSpeed = info.scaleSpeed;
            alpha = info.alphaStart;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
        }

        public void Launch_RainbowStarTrail(CGPoint inStartPosition)
        {
            currentAnim = 0;
            isAnimated = false;
            isActive = true;
            timer = 0;
            int randNumber = 140 + (Utilities.GetRand( 120));
            float angle = ((float) randNumber) * (Constants.PI_ / 360.0f);
            float outSpeed = 1.2f * ((Globals.g_world.GetGame()).GetPlayer()).GetActualSpeed().y;
            velocity = Utilities.GetVectorFromAngleP1(angle, outSpeed);
            int randX = Utilities.GetRand( 20);
            int randY = Utilities.GetRand( 10);
            float plusX = (float) randX - 10.0f;
            float plusY = (float) randY - 5.0f;
            CGPoint startPosition = Utilities.CGPointMake(inStartPosition.x + plusX + velocity.x * 2, inStartPosition.y + plusY + velocity.y * 2);
            mapPosition = startPosition;
            const int kNumFrames = 6;
            int particleId = (int) ParticleTextureType.kParticleTexture_SparkleRed + ((Utilities.GetRand( 5)) * kNumFrames);
            texture = (ParticleSystemRoss.Instance()).GetTexture((ParticleTextureType)particleId);
            atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_RainbowParticles);
			
			myAtlasBillboard.SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_RainbowParticles));
			myAtlasBillboard.SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_RainbowParticles),0);

			
            subTextureId = (Utilities.GetRand( 5)) * 6;
            for (int i = 0; i < kNumFrames; i++) animFrame[i] = (ParticleSystemRoss.Instance()).GetTexture((ParticleTextureType)particleId + i);

            currentAnim = 0;
            animTimer = 0;
            rotation = 0;
            type = ParticleType.kParticle_RainbowStarTrail;
            if (isAdditive) alpha = 0.2f;
            else alpha = 1;

        }

        public void Launch_GreenAntScreen(ParticleInfo inInfo)
        {
            currentAnim = 0;
            isAnimated = false;
            isActive = true;
            timer = 0;
            velocity = inInfo.velocity;
            CGPoint startPosition = inInfo.startPosition;
            mapPosition = startPosition;
            const int kNumFrames = 6;
            int particleId = (int) ParticleTextureType.kParticleTexture_SparkleRed + ((Utilities.GetRand( 5)) * kNumFrames);
            texture = (ParticleSystemRoss.Instance()).GetTexture((ParticleTextureType)particleId);
            atlas = Globals.g_world.GetAtlas( AtlasType.kAtlas_RainbowParticles);
            
			myAtlasBillboard.SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_RainbowParticles));
			myAtlasBillboard.SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_RainbowParticles),0);			
			
			subTextureId = (Utilities.GetRand( 5)) * 6;
            currentAnim = 0;
            animTimer = 0;
            rotation = 0;
            type = ParticleType.kParticle_GreenAntScreen;
            if (isAdditive) alpha = 0.2f;
            else alpha = 1.0f;

            scale = 1;
            if (isAdditive) {
                scale = 1.35f;
            }

        }

        public void StopRender()
        {
			myAtlasBillboard.StopRender();
		}		
		
        public void Launch_StarBurst(ParticleInfo info)
        {
            this.SetIsAdditive(true);
            isActive = true;
            type = ParticleType.kParticle_StarBurst;
            velocity = info.velocity;
            mapPosition = info.startPosition;
            texture = (ParticleSystemRoss.Instance()).GetTexture((ParticleTextureType) ParticleTextureType.kParticleTexture_RainbowPop);
            alpha = 0.8f;
            scale = 4.0f;
            subTextureId = 30;
            rotation = 0;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            alphaSpeed = 0.04f;
            if (Globals.g_world.artLevel == 0) {
                if ((Globals.g_world.game).numPlayersOnScreen >= 3) {
                    alphaSpeed = 0.06f;
                }

            }

        }

        public void Launch_SingleParticle(ParticleInfo info)
        {
           this.SetIsAdditive(info.isAdditive);
            timer = 0.0f;
            isActive = true;
            type = info.type;
            velocity = info.velocity;
            mapPosition = info.startPosition;
            texture = info.texture[0];
            alpha = info.alphaStart;
            scale = info.scaleStart;
            rotation = 0;
            rotationSpeed = info.rotationSpeed;
            scaleSpeed = info.scaleSpeed;
            alphaSpeed = info.alphaSpeed;
		//	this.SetupAtlasDetails();
            this.Update();
        }

        public void Launch_MenuSparkle(ParticleInfo info)
        {
            this.SetIsAdditive(true);
            timer = 0;
            isActive = true;
            type = ParticleType.kParticle_MenuSparkle;
            velocity = info.velocity;
            mapPosition = info.startPosition;
            texture = (ParticleSystemRoss.Instance()).GetTexture((ParticleTextureType) ParticleTextureType.kParticleTexture_SparkleOrange + Utilities.GetRand( 2));
            alpha = 0.7f;
            rotationScale = Globals.g_world.GetRotationScaleForShorts(12.24f);
            if (Globals.deviceIPad) {
                rotationScale *= 2.0f;
            }

            this.Update_MenuSparkle();
        }

        bool Update_BoostGlow()
        {
            scale += scaleSpeed;
            alpha -= alphaSpeed;
            if (alpha <= 0.05) return true;

            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            return false;
        }

        public bool Update_SingleParticle()
        {
            rotation += rotationSpeed;
            scale -= scaleSpeed;
            alpha -= alphaSpeed;
            if (scale <= 0.08f) return true;

            if (alpha <= 0.1f) return true;

            rotationScale -= scaleSpeed;
            mapPosition.x += velocity.x;
            mapPosition.y += velocity.y;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            if (!(Globals.g_world.game).IsOnScreen(screenPosition)) {
                return true;
            }

            return false;
        }

        bool Update_SingleSpark()
        {
            velocity.x *= 0.95f;
            velocity.y *= 0.95f;
            if (timer >= 0.06f) {
                alpha -= alphaSpeed;
            }
            else {
                timer += Constants.kFrameRate;
            }

            if (scale <= 0.08f) return true;

            if (alpha <= 0.1f) return true;

            mapPosition.x += velocity.x;
            mapPosition.y += velocity.y;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            if (!(Globals.g_world.game).IsOnScreen(screenPosition)) {
                return true;
            }

            return false;
        }

        public bool Update_StarBurst()
        {
            mapPosition.x += velocity.x;
            mapPosition.y += velocity.y;
            scale += 0.525f;
            alpha -= alphaSpeed;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            if (!(Globals.g_world.game).IsOnScreen(screenPosition)) {
                return true;
            }

            if (alpha <= 0.1f) {
                return true;
            }

            return false;
        }

        public bool Update_MenuSparkle()
        {
            timer += Constants.kFrameRate;
            mapPosition.x += velocity.x;
            mapPosition.y += velocity.y;
            rotation += 0.05f;
            if (rotation >= (Constants.PI_ * 2)) rotation -= (Constants.PI_ * 2);

            scale = 0 + (Utilities.GetCosInterpolationP1P2(timer + 0.65f, 0, 3) * 0.7f);
            alpha = 0.7f - (Utilities.GetCosInterpolationP1P2(timer + 0.3f, 0, 2.65f) * 0.7f);
            screenPosition = mapPosition;
            if (!(Globals.g_world.game).IsOnScreen(screenPosition)) {
                return true;
            }

            if (alpha <= 0.01f) {
                return true;
            }

            return false;
        }

        bool Update_RainbowStarTrail()
        {
            timer += Constants.kFrameRate;
            mapPosition.x += velocity.x;
            mapPosition.y += velocity.y;
            alpha -= 0.04f;
            velocity.x *= 0.85f;
            velocity.y *= 0.85f;
            const int kNumFrames = 6;
            animTimer += Constants.kFrameRate;
            if (animTimer >= 0.05f) {
                currentAnim++;
                if (currentAnim == kNumFrames) currentAnim = 0;

                texture = animFrame[currentAnim];
                animTimer = 0;
            }

            scale = 2.0f * (0.0f + (Utilities.GetCosInterpolationP1P2(timer + 0.3f, 0.0f, 0.85f) * 1.2f));
            if (isAdditive) {
                scale *= 1.35f;
            }

            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            if (!(Globals.g_world.game).IsOnScreen(screenPosition)) {
                return true;
            }

            if ((scale <= 0.1f) || (alpha < 0.1f)) {
                return true;
            }

            return false;
        }

        bool Update_GreenAntScreen()
        {
            timer += Constants.kFrameRate;
            mapPosition.x += velocity.x;
            mapPosition.y += velocity.y;
            velocity.y += 0.05f;
            const int kNumFrames = 6;
            animTimer += Constants.kFrameRate;
            if (animTimer >= 0.05) {
                currentAnim++;
                if (currentAnim == kNumFrames) {
                    currentAnim = 0;
                    subTextureId -= kNumFrames;
                }

                subTextureId++;
                animTimer = 0;
            }

            scale += 0.0075f;
            if (isAdditive) {
            }
            else {
            }

            screenPosition = mapPosition;
            if (!(Globals.g_world.game).IsOnScreen(screenPosition)) {
                return true;
            }

            if ((scale <= 0.1f) || (alpha < 0.1f)) {
                return true;
            }

            return false;
        }

        public void Launch_WaterSparkle(ParticleInfo info)
        {
            type = ParticleType.kParticle_WaterSparkle;
            mapPosition = info.startPosition;
            animTimer = 0.0f;
            alphaSpeed = 0.4f;
            alphaStart = 0.75f;
            subTextureId = 16;
            scale = 0.5f;
            rotation = 0.0f;
        }

        public void Launch_PondBlob(ParticleInfo info)
        {
            type = ParticleType.kParticle_PondBlob;
            mapPosition = info.startPosition;
            animTimer = 0.0f;
            alphaSpeed = 2.6f;
            alphaStart = 1.0f;
            subTextureId = 23;
            scale = 0.75f;
            rotation = 0.0f;
        }

        public void Launch_WaterLine(ParticleInfo info)
        {
            type = ParticleType.kParticle_WaterLine;
            mapPosition = info.startPosition;
            animTimer = 0.0f;
            alphaSpeed = 1.0f;
            alphaStart = 1.0f;
            subTextureId = 22;
            scale = 0.75f;
            rotation = 0.0f;
        }

        bool UpdatePondBlob()
        {
            const float kMaxAlpha = 0.35f;
            const float kBlobTime = 3.0f;
            animTimer += Constants.kFrameRate;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            alpha = kMaxAlpha * Utilities.GetCosInterpolationP1P2(animTimer, 0.0f, kBlobTime);
            scale += 0.0075f;
            return (animTimer >= kBlobTime);
        }

        bool UpdateWaterLine()
        {
            animTimer += Constants.kFrameRate;
            mapPosition.x += 2.4f;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            alpha = alphaStart * Utilities.GetCosInterpolationP1P2(animTimer, 0.0f, alphaSpeed);
            return (animTimer >= alphaSpeed);
        }

        bool UpdateWaterSparkle()
        {
            animTimer += Constants.kFrameRate;
            mapPosition.x += 0.3f;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            alpha = alphaStart * Utilities.GetCosInterpolationP1P2(animTimer, 0.0f, alphaSpeed);
            return (animTimer >= alphaSpeed);
        }

        public void Launch_ScalingRipple(CGPoint inStartPosition)
        {
            isAdditive = false;
            scale = 0.5f;
            mapPosition = inStartPosition;
            type = ParticleType.kParticle_ScalingRipple;
            texture = (ParticleSystemRoss.Instance()).GetTexture((ParticleTextureType) ParticleTextureType.kParticleTexture_Ripple);
            alpha = 1;
            rotation = 0;
        }

        public bool Update_ScalingRipple()
        {
            scale += 0.035f;
            alpha -= 0.025f;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            if ((scale >= 2.0f) || (!(Globals.g_world.game).IsOnScreen(screenPosition)) || (alpha < 0.05f)) {
                return true;
            }

            return false;
        }

        bool Update_Sparks()
        {
            velocity.y *= 0.9f;
            alpha -= 0.1f;
            if (alpha <= 0.1f) return true;

            return this.Update_Animated();
        }

        bool Update_DustCloud()
        {
            alpha -= 0.01f;
            if (alpha <= 0.1f) return true;

            return this.Update_Animated();
        }

        public bool Update_SingleSplash()
        {
            alpha -= 0.04f;
            velocity.x *= 0.995f;
            velocity.y *= 0.995f;
            return this.Update_Animated();
        }

        bool Update_PowerSkid()
        {
            alpha -= 0.02f;
            velocity.x *= 0.992f;
            velocity.y *= 0.992f;
            scale += scaleSpeed;
            return this.Update_Animated();
        }

        public bool Update_Animated()
        {
            animTimer += Constants.kFrameRate;
            mapPosition.x += velocity.x;
            mapPosition.y += velocity.y;
            screenPosition = (Globals.g_world.game).GetScreenPosition(mapPosition);
            if (!(Globals.g_world.game).IsOnScreen(screenPosition)) return true;

            if (animTimer >= timeBetweenAnimFrames[currentAnim]) {
                animTimer -= timeBetweenAnimFrames[currentAnim];
                currentAnim++;
                rotationScale = Globals.g_world.GetRotationScaleForShorts(45.2548f);
                if (Globals.deviceIPad) {
                    rotationScale *= 2.0f;
                }

                if (currentAnim == numAnimFrames) {
                    return true;
                }
                else {
                    if (currentAnim >= numAnimFrames) {
                    }

                    subTextureId = animatedSubtexture[currentAnim];
                    texture = animFrame[currentAnim];
                }

            }

            return false;
        }

        public bool Update()
        {
            switch (type) {
            case ParticleType.kParticle_RainbowStarTrail :
                return this.Update_RainbowStarTrail();
                
            case ParticleType.kParticle_GreenAntScreen :
                return this.Update_GreenAntScreen();
                
            case ParticleType.kParticle_StarBurst :
                return this.Update_StarBurst();
                
            case ParticleType.kParticle_MenuSparkle :
                return this.Update_MenuSparkle();
                
            case ParticleType.kParticle_WaterLine :
                return this.UpdateWaterLine();
                
            case ParticleType.kParticle_PondBlob :
                return this.UpdatePondBlob();
                
            case ParticleType.kParticle_WaterSparkle :
                return this.UpdateWaterSparkle();
                
            case ParticleType.kParticle_Sparks :
                return this.Update_Sparks();
                
            case ParticleType.kParticle_DustCloud :
            case ParticleType.kParticle_DustCloudTrail :
                return this.Update_DustCloud();
                
            case ParticleType.kParticle_Animated :
            case ParticleType.kParticle_Grass :
                return this.Update_Animated();
                
            case ParticleType.kParticle_PowerSkid :
                return this.Update_PowerSkid();
                
            case ParticleType.kParticle_SingleSplash :
                return this.Update_SingleSplash();
                
            case ParticleType.kParticle_Generic :
                return this.Update_SingleParticle();
                
            case ParticleType.kParticle_SingleSpark :
                return this.Update_SingleSpark();
                
            case ParticleType.kParticle_BoostGlow :
                return this.Update_BoostGlow();
                
            case ParticleType.kParticle_ScalingRipple :
                return this.Update_ScalingRipple();
                
            default :
                Globals.Assert(false);
                break;
            }

            return false;
        }

        public bool IsActive()
        {
            return isActive;
        }

        public void RenderNew()
        {
            if (isAdditive) texture.DrawAtPointScaledAlphaAdditiveP1(scale, alpha);
            else texture.DrawAtPointScaledAlphaP1(scale, alpha);

        }

        public void RenderToDrawArrays()
        {
            if ((Globals.g_world.game).IsOnScreenP1P2(screenPosition, 20.0f, Globals.g_world.mapObjectAppearDistance)) {
//                switch (type) {
  //              case ParticleType.kParticle_WaterSparkle :
    //                (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(screenPosition, scale, rotation, rotationScale, alpha, subTextureId);
      //              break;
        //        case ParticleType.kParticle_WaterLine :
          //          (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(screenPosition, scale, rotation, rotationScale, alpha, subTextureId);
            //        break;
              //  default :
                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard, screenPosition, scale, rotation, rotationScale, alpha, subTextureId);
                //    break;
                //}

            }

        }

        public void Render()
        {

            #if RECORDING_SIMULATOR_VIDEO_FULL_FRAMERATE
                return;
            #endif

            #if TEST_SHORTS
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            #endif

            //glPushMatrix();
            Globals.g_world.DoGLTranslateP1(screenPosition.x, screenPosition.y);
            texture.DrawAtPointScaledAlphaP1(scale, alpha);

            #if TEST_SHORTS
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            #endif

            //glPopMatrix();
        }

    }
}
