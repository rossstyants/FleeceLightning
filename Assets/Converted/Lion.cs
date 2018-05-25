using System;

namespace Default.Namespace
{
    public class Lion
    {
        public CGPoint position;
        public struct LionInfo{
            CGPoint inPosition;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public Lion()
        {
            //if (!base.init()) return null;

            //return this;
        }
        public void AddToScene(LionInfo info)
        {
         //   position = info.inPosition;
        }

    }
}
