using System;

namespace Default.Namespace
{
    public class Trampoline
    {
        public CGPoint position;
        public bool hasLeapTarget;
        public CGPoint leapTarget;
        public struct TrampolineInfo{
            public CGPoint position;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public bool HasLeapTarget
        {
            get;
            set;
        }

        public CGPoint LeapTarget
        {
            get;
            set;
        }

public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetHasLeapTarget(bool inThing) {hasLeapTarget = inThing;}///@property(readwrite,assign) bool hasLeapTarget;
//public void SetLeapTarget(CGPoint inThing) {leapTarget = inThing;}///@property(readwrite,assign) CGPoint leapTarget;

        public Trampoline()
        {
            //if (!base.init()) return null;

            //return this;
        }
        public void AddToScene(TrampolineInfo info)
        {
            position = info.position;
            hasLeapTarget = false;
        }

        public void SetLeapTarget(CGPoint inTarget)
        {
            hasLeapTarget = true;
            leapTarget = inTarget;
        }

        public void SetStartOfRace()
        {
        }

    }
}
