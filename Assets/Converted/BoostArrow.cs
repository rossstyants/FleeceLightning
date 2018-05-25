using System;

namespace Default.Namespace
{
    public enum  BoostArrowType {
        kArrowType_StraightDown
    }
    public class BoostArrow
    {
        public CGPoint position;
        public CGPoint[] boostPointPosition = new CGPoint[(int)Enum.kNumBoostPoints];
        public BoostArrowType type;
        public Zanimation anim;
        public bool[,] pointHit = new bool[(int)Enum.kBAMaxPlayers, (int)Enum.kNumBoostPoints];
        public int mapObjectId;
        public bool hasLeftScreen;
        public float groundLevel;
        public struct ArrowInfo{
            public CGPoint position;
            public BoostArrowType type;
            public int mapObjectId;
        };
        public enum  Enum {
            kNumBoostPoints = 5,
            kBAMaxPlayers = 5,
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public int MapObjectId
        {
            get;
            set;
        }

        public bool HasLeftScreen
        {
            get;
            set;
        }

        public float GroundLevel
        {
            get;
            set;
        }


public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetHasLeftScreen(bool inThing) {hasLeftScreen = inThing;}///@property(readwrite,assign) bool hasLeftScreen;
public void SetGroundLevel(float inThing) {groundLevel = inThing;}///@property(readwrite,assign) float groundLevel;

        public BoostArrow()
        {
            //if (!base.init()) return null;

            anim = new Zanimation();
            //return this;
        }
        public void Setup (ArrowInfo info)
		{
			hasLeftScreen = false;
			type = info.type;
			position = info.position;
			mapObjectId = info.mapObjectId;
			groundLevel = 0.0f;
			for (int y = 0; y < (int)Enum.kNumBoostPoints; y++) {
                boostPointPosition[y] = Utilities.CGPointMake(info.position.x, -50 + info.position.y + ((float) y * 22));
                for (int i = 0; i < (int)Enum.kBAMaxPlayers; i++) {
                    pointHit[i, y] = false;
                }

            }

            ZAnimationInfo zaInfo = new ZAnimationInfo();
            zaInfo.numFrames = 5;
            for (int i = 0; i < zaInfo.numFrames; i++) {
                zaInfo.frameTime[i] = 0.2f;
                if ((int)((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) zaInfo.subTextureId[i] = (short)(6 + i);
                else zaInfo.subTextureId[i] = (short)(49 + i);

            }

            zaInfo.gapType = GapType.kAnimGapTime;
            anim.Setup(zaInfo);
            anim.PlayLooping();
        }

        public void Update (Player inPlayer)
		{
			CGPoint playerPosition = inPlayer.position;
			const float kSqrHitDistance = 33 * 33;
			float heightDiff = Utilities.GetABS (inPlayer.positionZ - groundLevel);
			if (heightDiff > 20.0f) {
				return;
			}

			for (int y = 0; y < (int)Enum.kNumBoostPoints; y++) {
				if (pointHit [inPlayer.playerId, y])
					continue;

				float distSqr = Utilities.GetSqrDistanceP1 (playerPosition, boostPointPosition [y]);
				if (distSqr <= kSqrHitDistance) {
					pointHit [inPlayer.playerId, y] = true;
					if (inPlayer == (Globals.g_world.game).player) {
						ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                        info.type = EffectType.kEffect_BoostGlow;
                        info.startPosition = boostPointPosition[y];
                        info.velocity.x = (float) y;
                        (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                    }

                    CGPoint boostDir = Utilities.CGPointMake(0, 1);
                    inPlayer.AddBoost(boostDir);

                    #if NOT_FINAL_VERSION
                    #endif

                }

            }

        }

    }
}
