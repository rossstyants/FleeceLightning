using System;

namespace Default.Namespace
{
    public class StarSpeedUp
    {
        public CGPoint position;
        public bool passedBySheep;
        public bool passedByPig;
        public int mapObjectId;
        public bool isGone;
        public struct StarSpeedUpInfo{
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

public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetIsGone(bool inThing) {isGone = inThing;}///@property(readwrite,assign) bool isGone;

        public void Initialise(StarSpeedUpInfo info)
        {
            position = info.position;
            passedBySheep = false;
            passedByPig = false;
            mapObjectId = info.mapObjectId;
            isGone = false;
        }

        public bool IsPassedBy(Player inPlayer)
        {
            if (inPlayer == (Globals.g_world.game).player) return passedBySheep;
            else return passedByPig;

        }

        public void SetPassedBy(Player inPlayer)
        {
            if (inPlayer == (Globals.g_world.game).player) passedBySheep = true;
            else passedByPig = true;

        }

    }
}
