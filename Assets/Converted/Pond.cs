using System;

namespace Default.Namespace
{
    public enum  PondType {
        e_Normal = 0,
        e_Puddle,
        e_MuddyPuddle,
        e_Snow
    }
    public class Pond
    {
        public CGPoint position;
        public float radius;
        public float radiusSqr;
        public PondType type;
        public float timeSinceSplat;
        public struct PondInfo{
            public CGPoint position;
            public float radius;
            public PondType type;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public float RadiusSqr
        {
            get;
            set;
        }

        public float Radius
        {
            get;
            set;
        }

        public PondType Type
        {
            get;
            set;
        }

		public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetRadiusSqr(float inThing) {radiusSqr = inThing;}///@property(readwrite,assign) float radiusSqr;
public void SetRadius(float inThing) {radius = inThing;}///@property(readwrite,assign) float radius;
public void SetType(PondType inThing) {type = inThing;}///@property(readwrite,assign) PondType type;

        public void AddToScene(PondInfo info)
        {
            position = info.position;
            radius = info.radius - 7;
            radiusSqr = radius * radius;
            type = info.type;
            timeSinceSplat = 0.0f;
        }

        public void AddBlob()
        {
            const float kSparkleAreaWidth = 100.0f;
            float xOffset = Utilities.GetRandBetweenP1(0.0f, kSparkleAreaWidth);
            float yOffset = Utilities.GetRandBetweenP1(0.0f, kSparkleAreaWidth);
            //ParticleInfo info;
            //info.type = ParticleType.kParticle_PondBlob;
            //info.startPosition = Utilities.CGPointMake(position.x - (kSparkleAreaWidth / 2.0f) + xOffset, position.y - (kSparkleAreaWidth / 2.0f) + yOffset);
            //(ParticleSystemRoss.Instance()).AddParticleP1(info, (int) ParticleList.t_BeforePlayer);
        }

        public void UpdateBlobs()
        {
            if (Utilities.GetRand( 25) == 0) {
                this.AddBlob();
            }

        }

        public void UpdatePond()
        {
        }

        public void UpdateRipplesP1(float dist, Player inPlayer)
        {
            const float kMaxDistForRipple = 50;
            if ((type ==  PondType.e_Normal) || (type ==  PondType.e_Puddle)) {
                if (inPlayer.splashingEffectId == -1) {
                    if (dist < kMaxDistForRipple) {
                        inPlayer.StartSplashing();
                    }

                }
                else {
                    if (dist > (kMaxDistForRipple + 10)) {
                        inPlayer.StopSplashing();
                    }

                }

            }
            else if (type ==  PondType.e_Snow) {
                const float kTimeBetweenSplats = 10.0f;
                timeSinceSplat += inPlayer.GetDistanceLastFrame();
                if (timeSinceSplat >= kTimeBetweenSplats) {
                    ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                    info.type = EffectType.kEffect_SplashRingMud;
                    info.inList = ParticleList.t_BeforePlayer;
                    info.startPosition = inPlayer.position;
                    info.velocity = inPlayer.GetActualSpeed();
                    info.rotation = inPlayer.moveAngle;
                    (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                    timeSinceSplat = 0.0f;
                }

            }
            else {
                const float kTimeBetweenSplats = 10.0f;
                timeSinceSplat += inPlayer.GetDistanceLastFrame();
                if (timeSinceSplat >= kTimeBetweenSplats) {
                    ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
                    info.type = EffectType.kEffect_SplashRingMud;
                    info.inList = ParticleList.t_BeforePlayer;
                    info.startPosition = inPlayer.position;
                    info.velocity = inPlayer.GetActualSpeed();
                    info.rotation = inPlayer.moveAngle;
                    (ParticleSystemRoss.Instance()).AddParticleEffect(info);
                    timeSinceSplat = 0.0f;
                }

            }

        }

    }
}
