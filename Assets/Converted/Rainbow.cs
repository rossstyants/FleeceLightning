using System;

namespace Default.Namespace
{
    public class Rainbow
    {
        public CGPoint position;
        public bool[] passedBy = new bool[(int)Enum.kRAMaxPlayers];
        public int mapObjectId;
        public bool isGone;
        public float groundLevel;
        public enum  Enum {
            kRAMaxPlayers = 5
        };
        public struct RainbowInfo{
            public CGPoint position;
            public int mapObjectId;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public int MapObjectId
        {
            get;
            set;
        }

        public bool IsGone
        {
            get;
            set;
        }

        public float GroundLevel
        {
            get;
            set;
        }

public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetIsGone(bool inThing) {isGone = inThing;}///@property(readwrite,assign) bool isGone;
public void SetGroundLevel(float inThing) {groundLevel = inThing;}///@property(readwrite,assign) float groundLevel;

        public void Initialise (RainbowInfo info)
		{
			position = info.position;
			for (int i = 0; i < (int)Enum.kRAMaxPlayers; i++)
				passedBy [i] = false;

			mapObjectId = info.mapObjectId;
			isGone = false;
			groundLevel = 0.0f;
			Globals.Assert ((int)Enum.kRAMaxPlayers == Constants.MAX_PLAYERS);
        }

        public bool IsPassedBy (Player inPlayer)
		{
			int plId = inPlayer.playerId;
			Globals.Assert (plId < (int)Enum.kRAMaxPlayers);
            return passedBy[plId];
        }

        public void SetPassedBy (Player inPlayer)
		{
			int plId = inPlayer.playerId;
			Globals.Assert (plId < (int)Enum.kRAMaxPlayers);
            passedBy[plId] = true;
        }

    }
}
