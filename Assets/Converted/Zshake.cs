using System;

namespace Default.Namespace
{
    public class Zshake
    {
        public ShakeInfo shake;
        public float shakeTime;
        public float shakeTimer;
        public float x;
        public float y;
        public struct ShakeInfo{
            public float xSpeed;
            public float ySpeed;
            public float xPosition;
            public float yPosition;
            public float xSize;
            public float ySize;
        };
        public ShakeInfo Shake
        {
            get;
            set;
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

		public void SetShake(ShakeInfo inThing) {shake = inThing;}///@property(readwrite,assign) ShakeInfo shake;
//public void SetState(ShakeState inThing) {state = inThing;}///@property(readwrite,assign) ShakeState state;
public void SetX(float inThing) {x = inThing;}///@property(readwrite,assign) float x;
public void SetY(float inThing) {y = inThing;}///@property(readwrite,assign) float y;

        public Zshake()
        {
//            //if (!base.init()) return null;

            shake.xPosition = 0;
            shake.yPosition = 0;
            shake.xSize = 4;
            shake.ySize = 4;
            shakeTimer = 0.0f;
            shakeTime = 0.0f;
            this.Reset();
  //          //return this;
        }
        public void Setup(ShakeInfo info)
        {
            shake = info;
        }

        public void Start(float time)
        {
            shakeTime = time;
            shakeTimer = time;
            shake.xSpeed = 1 + (((float)(Utilities.GetRand( 400))) / 1000);
            shake.ySpeed = 1 + (((float)(Utilities.GetRand( 400))) / 1000);
        }

        public void StartP1(float time, float speedMultiply)
        {
            shakeTime = time;
            shakeTimer = time;
            shake.xSpeed = speedMultiply * (1 + (((float)(Utilities.GetRand( 400))) / 1000));
            shake.ySpeed = speedMultiply * (1 + (((float)(Utilities.GetRand( 400))) / 1000));
        }

        public bool IsShaking()
        {
            return (shakeTimer > 0);
        }

        public void Update()
        {
            if (shakeTimer <= 0) return;

            shake.xPosition += shake.xSpeed;
            shake.yPosition += shake.ySpeed;
            if (shake.xPosition >= Constants.PI_) {
                shake.xPosition -= (2 * Constants.PI_);
            }

            if (shake.yPosition >= Constants.PI_) {
                shake.yPosition -= (2 * Constants.PI_);
            }

            float size;
            const float kIncProportion = 0.94f;
            if (shakeTimer >= (shakeTime * kIncProportion)) {
                size = 1 - Utilities.GetCosInterpolationHalfP1P2(shakeTimer, (shakeTime * kIncProportion), shakeTime);
            }
            else {
                size = Utilities.GetCosInterpolationHalfP1P2(shakeTimer, 0, (shakeTime * kIncProportion));
            }

            x = (float)Math.Cos(shake.xPosition) * shake.xSize * size;
            y = (float)Math.Cos(shake.yPosition) * shake.ySize * size;
            shakeTimer -= Constants.kFrameRate;
        }

        public void Reset()
        {
            shakeTimer = 0;
            shake.xPosition = 0;
            shake.yPosition = 0;
            x = 0;
            y = 0;
        }

    }
}
