using System;

namespace Default.Namespace
{
    public class BigHole
    {
        public CGPoint pos;
        CGPoint GetPosition()
        {
            return pos;
        }

        public void InitialiseP1(int xPos, int yPos)
        {
            pos = Utilities.CGPointMake(xPos, yPos);
        }

    }
}
