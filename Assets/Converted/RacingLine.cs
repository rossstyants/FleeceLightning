using System;

namespace Default.Namespace
{
    public class RacingLine
    {
        public RacingPoint[] point = new RacingPoint[(int)Enum.kMaxPoints];
        public int numPoints;
        const float kDistanceBetweenPoints = 20.0f;
        public struct RacingPoint{
            public short x;
            public short y;
        };
        public enum Enum {
            kMaxPoints = 2000
        };
        public int NumPoints
        {
            get;
            set;
        }
		public void SetNumPoints(int inThing) {numPoints = inThing;}///@property(readwrite,assign) int numPoints;



        public void AddPoint (CGPoint nextPosition)
		{
			Globals.Assert (numPoints < (int)Enum.kMaxPoints);
            point[numPoints].x = (short)nextPosition.x;
            point[numPoints].y = (short)nextPosition.y;
            numPoints++;
        }

        public RacingPoint GetPoint (int which)
		{
			Globals.Assert (which < (int)Enum.kMaxPoints);
            return point[which];
        }

        public void CreateRacingLineFromGhost(Ghost inGhost)
        {
            numPoints = 0;
            CGPoint lastPoint = Utilities.CGPointMake(-1000, -1000);
            inGhost.SetStartOfRace();
            for (int i = 0; i < inGhost.numFrames; i++) {
                inGhost.UpdatePlaying();
                CGPoint ghostPosition = inGhost.position;
                float distanceFromLastPoint = Utilities.GetDistanceP1(ghostPosition, lastPoint);
                if (distanceFromLastPoint >= kDistanceBetweenPoints) {
                    this.AddPoint(ghostPosition);
                    lastPoint = ghostPosition;
                }

            }

        }

        public void Render()
        {
            for (int i = 0; i < numPoints; i++) {
                CGPoint pos = Utilities.CGPointMake(point[i].x, point[i].y);
                CGPoint screenPosition = (Globals.g_world.game).GetScreenPosition(pos);
                if ((Globals.g_world.game).IsOnScreen(screenPosition)) {
                    (DrawManager.Instance()).AddTextureToListP1(screenPosition, 0);
                }

            }

        }

        public void RenderTarget(int i)
        {
            CGPoint pos = Utilities.CGPointMake(point[i].x, point[i].y);
            CGPoint screenPosition = (Globals.g_world.game).GetScreenPosition(pos);
            if ((Globals.g_world.game).IsOnScreen(screenPosition)) {
                (DrawManager.Instance()).AddTextureToListP1(screenPosition, 1);
            }

        }

    }
}
