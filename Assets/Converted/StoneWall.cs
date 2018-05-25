using System;

namespace Default.Namespace
{
    public class StoneWall
    {
        public float yMapPosition;
        public float xGatePosition;
        public float xGateWidth;
        public bool[] passedBy = new bool[(int)Enum.kMaxPlayersPerGame];
        public int[] idGate = new int[(int)Enum.kMaxGatesPerWall];
        public bool hasGate;
        public int numGates;
        public int numPlayersPast;
        public enum Enum {
            kMaxGatesPerWall = 2,
            kMaxPlayersPerGame = 10
        };
        public struct WallInfo{
            public float yMapPosition;
            public float xGatePosition;
            public float xGateWidth;
            public bool hasGate;
        };
        public float XGatePosition
        {
            get;
            set;
        }

        public float YMapPosition
        {
            get;
            set;
        }

        public float XGateWidth
        {
            get;
            set;
        }

        public bool HasGate
        {
            get;
            set;
        }

        public int NumPlayersPast
        {
            get;
            set;
        }

public void SetXGatePosition(float inThing) {xGatePosition = inThing;}///@property(readwrite,assign) float xGatePosition;
public void SetYMapPosition(float inThing) {yMapPosition = inThing;}///@property(readwrite,assign) float yMapPosition;
public void SetXGateWidth(float inThing) {xGateWidth = inThing;}///@property(readwrite,assign) float xGateWidth;
public void SetHasGate(bool inThing) {hasGate = inThing;}///@property(readwrite,assign) bool hasGate;
public void SetNumPlayersPast(int inThing) {numPlayersPast = inThing;}///@property(readwrite,assign) int numPlayersPast;
//public void SetPassed(bool inThing) {passed = inThing;}///@property(readwrite,assign) bool passed;

        public int GetGateId (int whichGate)
		{
			Globals.Assert (whichGate < (int)Enum.kMaxGatesPerWall);
            return idGate[whichGate];
        }

        public bool PassedBy (int whichPlayer)
		{
			Globals.Assert (whichPlayer < (int)Enum.kMaxPlayersPerGame);
            return passedBy[whichPlayer];
        }

        public void SetPassedBy (int whichPlayer)
		{
			Globals.Assert (whichPlayer < (int)Enum.kMaxPlayersPerGame);
            passedBy[whichPlayer] = true;
            numPlayersPast++;
        }

        public void Initialise (WallInfo info)
		{
			xGatePosition = info.xGatePosition;
			xGateWidth = info.xGateWidth;
			yMapPosition = info.yMapPosition;
			hasGate = info.hasGate;
			numPlayersPast = 0;
			for (int i = 0; i < (int)Enum.kMaxPlayersPerGame; i++) passedBy[i] = false;

            numGates = 0;
        }

        public void WobbleGate()
        {
            for (int i = 0; i < numGates; i++) {
                ((Globals.g_world.game).GetGate(idGate[i])).Wobble();
            }

        }

        public void GatesFlyOff()
        {
            if ((((Globals.g_world.game).GetGate(idGate[0])).startingState == StartingGateState.e_Open) && (((Globals.g_world.game).GetGate(idGate[0])).state == 
               StartingGateState.e_Open)) {
                for (int i = 0; i < numGates; i++) {
                    ((Globals.g_world.game).GetGate(idGate[i])).Close();
                }

                float distFromLine = yMapPosition - ((Globals.g_world.game).player).position.y;
                float volume = 1 - Utilities.GetRatioP1P2(distFromLine, 0, 600);
                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_GateClose, volume);
            }
            else if ((((Globals.g_world.game).GetGate(idGate[0])).startingState == StartingGateState.e_Closed) && (((Globals.g_world.game).GetGate(idGate[0])).
              state ==  StartingGateState.e_Closed)) {
                for (int i = 0; i < numGates; i++) {
                    ((Globals.g_world.game).GetGate(idGate[i])).Open();
                }

            }

        }

        public void AddGate (int inId)
		{
			Globals.Assert (numGates < (int)Enum.kMaxGatesPerWall);
            idGate[numGates] = inId;
            numGates++;
        }

    }
}
