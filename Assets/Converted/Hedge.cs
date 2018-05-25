using System;

namespace Default.Namespace
{
    public class Hedge
    {
        public bool[] passedByPlayer = new bool[Constants.MAX_PLAYERS];
        public void AddToScene()
        {
            for (int i = 0; i < Constants.MAX_PLAYERS; i++) {
                passedByPlayer[i] = false;
            }

        }

        public bool IsPassedByPlayer(int playerId)
        {
            Globals.Assert(playerId < Constants.MAX_PLAYERS);
            return passedByPlayer[playerId];
        }

        public void SetPassedByPlayer(int playerId)
        {
            Globals.Assert(playerId < Constants.MAX_PLAYERS);
            passedByPlayer[playerId] = true;
        }

    }
}
