using System;

namespace Default.Namespace
{
    public class Ramp
    {
        public CGPoint mapPosition;
        public float width;
        public float length;
        public float maxHeight;
        public bool[] playerHasPassed = new bool[Constants.MAX_PLAYERS];
        public bool[] playerHasPassedEnd = new bool[Constants.MAX_PLAYERS];
        public float leapLengthAdjustment;
        public struct RampInfo{
            public CGPoint mapPosition;
            public int width;
        };
        public CGPoint MapPosition
        {
            get;
            set;
        }

        public float Width
        {
            get;
            set;
        }

        public float Length
        {
            get;
            set;
        }

        public float LeapLengthAdjustment
        {
            get;
            set;
        }

		public void SetMapPosition(CGPoint inThing) {mapPosition = inThing;}///@property(readwrite,assign) CGPoint mapPosition;
public void SetWidth(float inThing) {width = inThing;}///@property(readwrite,assign) float width;
public void SetLength(float inThing) {length = inThing;}///@property(readwrite,assign) float length;
public void SetLeapLengthAdjustment(float inThing) {leapLengthAdjustment = inThing;}///@property(readwrite,assign) float leapLengthAdjustment;
//public void SetPlayerHasPassed(bool inThing) {playerHasPassed = inThing;}///@property(readwrite,assign) bool playerHasPassed;
//public void SetPlayerHasPassedEnd(bool inThing) {playerHasPassedEnd = inThing;}///@property(readwrite,assign) bool playerHasPassedEnd;

        public void SetPlayerHasPassed(int playerId)
        {
            Globals.Assert(playerId < Constants.MAX_PLAYERS);
            playerHasPassed[playerId] = true;
        }

        public void SetPlayerHasPassedEnd(int playerId)
        {
            Globals.Assert(playerId < Constants.MAX_PLAYERS);
            playerHasPassedEnd[playerId] = true;
        }

        public bool GetPlayerHasPassed(int playerId)
        {
            Globals.Assert(playerId < Constants.MAX_PLAYERS);
            return playerHasPassed[playerId];
        }

        public bool GetPlayerHasPassedEnd(int playerId)
        {
            Globals.Assert(playerId < Constants.MAX_PLAYERS);
            return playerHasPassedEnd[playerId];
        }

        public void AddToScene(RampInfo info)
        {
            mapPosition = info.mapPosition;
            length = 70;
            maxHeight = 48;
            width = 21 + (Constants.TILE_SIZE * ((float) info.width));
            leapLengthAdjustment = -1.0f;
            for (int i = 0; i < Constants.MAX_PLAYERS; i++) {
                playerHasPassed[i] = false;
                playerHasPassedEnd[i] = false;
            }

        }

        public float GetGroundLevel(float yPosition)
        {
            float offset = yPosition - mapPosition.y;
            float groundLevel = maxHeight * Utilities.GetRatioP1P2(offset, 0, length);
            return groundLevel;
        }

    }
}
