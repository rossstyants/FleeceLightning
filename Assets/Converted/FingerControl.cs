using System;

namespace Default.Namespace
{
    public class FingerControl
    {
        public bool fingerDown;
        public CGPoint fingerPosition;
        public float maxDiffY;
        public CGPoint FingerPosition
        {
            get;
            set;
        }

        public bool FingerDown
        {
            get;
            set;
        }

        public float MaxDiffY
        {
            get;
            set;
        }

		//public void SetFingerPosition(CGPoint inThing) {fingerPosition = inThing;}///@property(readwrite,assign) CGPoint fingerPosition;
public void SetMaxDiffY(float inThing) {maxDiffY = inThing;}///@property(readwrite,assign) float maxDiffY;
public void SetFingerDown(bool inThing) {fingerDown = inThing;}///@property(readwrite,assign) bool fingerDown;

        public void SetStartOfRace()
        {
            fingerDown = false;
            maxDiffY = 50.0f;
        }

        public void SetFingerPosition(CGPoint pos)
        {
            fingerPosition = pos;
            maxDiffY = 50.0f + (40.0f * (Utilities.GetRatioP1P2(pos.y, 150.0f, 320.0f)));
        }

    }
}
