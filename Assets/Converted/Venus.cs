using System;

namespace Default.Namespace
{
    public enum  VenusState {
        kVenus_Open,
        kVenus_Closed
    }
    public class Venus
    {
        public CGPoint position;
        public VenusState state;
        public int mapObjectId;
        public float stateTimer;
        public struct VenusInfo{
            CGPoint position;
            short inMapObjectId;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public VenusState State
        {
            get;
            set;
        }

        public float StateTimer
        {
            get;
            set;
        }

        public Venus()
        {
            //if (!base.init()) return null;

            //return this;
        }
        public void AddToScene(VenusInfo info)
        {
        }

        public void UpdateVenus()
        {
        }

        public void PlayerEscaped()
        {
        }

        public void SnapShut()
        {
        }

    }
}
