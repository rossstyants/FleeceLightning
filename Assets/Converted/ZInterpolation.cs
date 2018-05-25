using System;

namespace Default.Namespace
{
    public enum  InterpolationRange {
        kInterp_ZeroToOne,
        kInterp_OneToZero,
        kInterp_ZeroToOneToZero
    }
    public enum  InterpolationTarget {
        kInterp_None,
        kInterp_Scale,
        kInterp_ScaleThrob,
        kInterp_Fade,
        kInterp_Screen,
        kInterp_Spin,
        kInterp_Map
    }
    public enum  InterpolationEndParameter {
        kInterpEnd_None,
        kInterpEnd_Time,
        kInterpEnd_Value
    }
    public enum  InterpolationType {
        kInterp_Linear,
        kInterp_Lag,
        kInterp_Cos,
        kInterp_Accelerate,
        kInterp_Boing
    }
    public class ZInterpolation
    {
        public InterpolationRange range;
        public InterpolationType type;
        public InterpolationTarget target;
        public InterpolationEndParameter endParameter;
        public float time;
        public float timer;
        public float value;
        public bool active;
        public float lag;
        public CGPoint startPosition;
        public CGPoint endPosition;
        public float acceleration;
        public float velocity;
        public float endValue;
        public float startTimer;
        public float waitToBegin;
        public int phase;
        public struct InterpolationInfo{
            public InterpolationRange range;
            public InterpolationType type;
            public InterpolationTarget target;
            public InterpolationEndParameter endParameter;
            public float time;
        };
        public enum Enum {
            kInterp_Phase1 = 0,
            kInterp_Phase2
        };
        public float EndValue
        {
            get;
            set;
        }

        public InterpolationTarget Target
        {
            get;
            set;
        }

        public CGPoint EndPosition
        {
            get;
            set;
        }

        public float WaitToBegin
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public float Velocity
        {
            get;
            set;
        }

        public float Acceleration
        {
            get;
            set;
        }

		public void SetEndValue(float inThing) {endValue = inThing;}///@property(readwrite,assign) float endValue;
public void SetTarget(InterpolationTarget inThing) {target = inThing;}///@property(readwrite,assign) InterpolationTarget target;
public void SetEndPosition(CGPoint inThing) {endPosition = inThing;}///@property(readwrite,assign) CGPoint endPosition;
public void SetWaitToBegin(float inThing) {waitToBegin = inThing;}///@property(readwrite,assign) float waitToBegin;
public void SetActive(bool inThing) {active = inThing;}///@property(readwrite,assign) bool active;
public void SetVelocity(float inThing) {velocity = inThing;}///@property(readwrite,assign) float velocity;
public void SetAcceleration(float inThing) {acceleration = inThing;}///@property(readwrite,assign) float acceleration;

        public ZInterpolation()
        {
            //if (!base.init()) return null;

            active = false;
            //return this;
        }
        public void Setup(InterpolationInfo info)
        {
            range = info.range;
            type = info.type;
            target = info.target;
            time = info.time;
            active = false;
            endParameter = info.endParameter;
            lag = 0.95f;
            startPosition = Utilities.CGPointMake(0, 0);
            endPosition = Utilities.CGPointMake(320, 320);
            acceleration = 0.001f;
            velocity = 0.05f;
            endValue = 0.99f;
            startTimer = 0;
            waitToBegin = 0;
        }

        public void SetupLag(float lagAmount)
        {
            lag = lagAmount;
        }

        public void SetupAccelerateP1(float accel, float startVelocity)
        {
            acceleration = accel;
            velocity = startVelocity;
        }

        public void SetupTargetScreenP1(CGPoint inStart, CGPoint inEnd)
        {
            startPosition = inStart;
            endPosition = inEnd;
        }

        public bool Update()
        {
            if (!active) return false;

            if (startTimer < waitToBegin) startTimer += Constants.kFrameRate;

            switch (type) {
            case InterpolationType.kInterp_Accelerate :
                value += velocity;
                velocity += acceleration;
                break;
            case InterpolationType.kInterp_Lag :
                value = value + ((1 - value) * lag);
                break;
            case InterpolationType.kInterp_Linear :
                break;
            case InterpolationType.kInterp_Cos :
                timer += Constants.kFrameRate;
                value = Utilities.GetCosInterpolationHalfP1P2(timer, 0, time);
                break;
            case InterpolationType.kInterp_Boing :
                if (phase == (int)Enum.kInterp_Phase1) {
                    value += velocity;
                    if (value >= 1) {
                        acceleration = (-velocity * 0.1f);
                        phase = (int)Enum.kInterp_Phase2;
                    }

                }
                else {
                    velocity += acceleration;
                    value += velocity;
                    velocity *= 0.95f;
                    if (((acceleration > 0) && (value >= 1)) || ((acceleration < 0) && (value <= 1))) {
                        acceleration = (-acceleration * 1.05f);
                        if (Utilities.GetABS(acceleration) >= Utilities.GetABS((velocity))) {
                            value = 1;
                            active = false;
                            return true;
                        }

                    }

                }

                break;
            }

            switch (endParameter) {
            case InterpolationEndParameter.kInterpEnd_Time :
                if (timer >= time) {
                    active = false;
                    return true;
                }

                break;
            case InterpolationEndParameter.kInterpEnd_Value :
                if (value >= endValue) {
                    value = endValue;
                    active = false;
                    return true;
                }

                break;
            default :
                break;
            }

            return false;
        }

        public void Start()
        {
            timer = 0;
            value = 0;
            active = true;
        }

        public float GetValue()
        {
            switch ((InterpolationRange)range) {
            case InterpolationRange.kInterp_ZeroToOne :
                return value;
            case InterpolationRange.kInterp_OneToZero :
                return 1 - value;
            case InterpolationRange.kInterp_ZeroToOneToZero :
                return 1 - (Utilities.GetABS((2 * value - 1)));
            }

            Globals.Assert(false);
            return -1;
        }

        public CGPoint GetPosition()
        {
            Globals.Assert((target == InterpolationTarget.kInterp_Screen) || (target ==  InterpolationTarget.kInterp_Map));
            return Utilities.GetPositionBetweenP1P2(this.GetValue(), startPosition, endPosition);
        }

    }
}
