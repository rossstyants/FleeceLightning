using System;

namespace Default.Namespace
{
    public class Waterfall
    {
        public float yPosition;
        public int myId;
        public bool[] passedByPlayer = new bool[5];
        public struct WaterfallInfo{
            float yPosition;
        };
        public int MyId
        {
            get;
            set;
        }

        public float YPosition
        {
            get;
            set;
        }

        public Waterfall()
        {
            //if (!base.init()) return null;

            Globals.Assert(Constants.MAX_PLAYERS == 5);
            //return this;
        }
        public void AddToScene(WaterfallInfo info)
        {

        }

        public bool IsPassedBy(int playerId)
        {
            Globals.Assert(playerId < Constants.MAX_PLAYERS);
            return passedByPlayer[playerId];
        }

        public void SetPassedBy(int playerId)
        {
            Globals.Assert(playerId < Constants.MAX_PLAYERS);
            passedByPlayer[playerId] = true;
        }

        public void AddLine()
        {
        }

        public void AddSparkle()
        {
        }

        public void UpdateSparkles()
        {
            if (Utilities.GetRand( 5) == 0) {
                this.AddSparkle();
            }

        }

        public void UpdateSurfaceLines()
        {
            if (Utilities.GetRand( 5) == 0) {
                this.AddLine();
            }

        }

        public void UpdateWaterfall()
        {
            this.UpdateSurfaceLines();
            this.UpdateSparkles();
        }

    }
}
