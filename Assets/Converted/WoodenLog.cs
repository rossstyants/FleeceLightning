using System;

namespace Default.Namespace
{
    public class WoodenLog
    {
        public CGPoint position;
        public int myId;
        public struct WoodenLogInfo{
            public CGPoint position;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public int MyId
        {
            get;
            set;
        }

        public WoodenLog()
        {
            //if (!base.init()) return null;

            //return this;
        }
        public void AddToScene(WoodenLogInfo info)
        {
            position = info.position;
        }

        public bool HasFallenOff(CGPoint inPos)
        {
            const float kLogWidth = 38.0f;
            const float kLogLength = 68.0f;
            return (!Utilities.IsWithinRectangleP1P2P3(inPos, position, kLogWidth, kLogLength));
        }

        public bool IsOnLog(CGPoint inPos)
        {
            const float kLogWidth = 30.0f;
            const float kLogLength = 60.0f;
            return (Utilities.IsWithinRectangleP1P2P3(inPos, position, kLogWidth, kLogLength));
        }

    }
}
