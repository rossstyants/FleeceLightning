using System;

namespace Default.Namespace
{
    public enum  FlowerBunchType {
        kFlowerBunch_Sunflowers = 0,
        kFlowerBunch_Lilac,
        kFlowerBunch_Pink,
        kFlowerBunch_JunglePurple,
        kFlowerBunch_SavannaBush,
        kFlowerBunch_Daffodil,
        kFlowerBunch_Tulips,
        kFlowerBunch_TulipsWhite,
        kFlowerBunch_TulipsYellow,
        kFlowerBunch_TulipsBlue
    }
    public enum  FlowerBunchState {
        kFlowerBunchActive = 0,
        kFlowerBunchInactive,
        kFlowerBunchExploding
    }
    public class FlowerBunch
    {
        public FlowerBunchState state;
        public FlowerBunchType type;
        public CGPoint position;
        public float hitLine;
        public int mapObjectId;
        public int shadowMapObjectId;
        public int myId;
        public bool isSquashed;
        public bool[] hasBeenHitBy = new bool[Constants.MAX_PLAYERS];
        public bool stillHasMapObject;
        public struct FlowerBunchInfo{
            public CGPoint position;
            public int mapObjectId;
            public int shadowMapObjectId;
            public FlowerBunchType type;
        };
        public FlowerBunchState State
        {
            get;
            set;
        }

        public int MapObjectId
        {
            get;
            set;
        }

        public int ShadowMapObjectId
        {
            get;
            set;
        }

        public CGPoint Position
        {
            get;
            set;
        }

        public int MyId
        {
            get;
            set;
        }

        public FlowerBunchType Type
        {
            get;
            set;
        }

        public float HitLine
        {
            get;
            set;
        }

        public bool IsSquashed
        {
            get;
            set;
        }

        public bool StillHasMapObject
        {
            get;
            set;
        }

public void SetMyId(int inThing) {myId = inThing;}///@property(readwrite,assign) int myId;
public void SetState(FlowerBunchState inThing) {state = inThing;}///@property(readwrite,assign) FlowerBunchState state;
public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetShadowMapObjectId(int inThing) {shadowMapObjectId = inThing;}///@property(readwrite,assign) int shadowMapObjectId;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetHitLine(float inThing) {hitLine = inThing;}///@property(readwrite,assign) float hitLine;
public void SetType(FlowerBunchType inThing) {type = inThing;}///@property(readwrite,assign) FlowerBunchType type;
public void SetIsSquashed(bool inThing) {isSquashed = inThing;}///@property(readwrite,assign) bool isSquashed;
public void SetStillHasMapObject(bool inThing) {stillHasMapObject = inThing;}///@property(readwrite,assign) bool stillHasMapObject;	

        public FlowerBunch(int inId)
        {
            //if (!base.init()) return null;

            myId = (short)inId;
            //return this;
        }
		
		
		
        public void AddToScene(FlowerBunchInfo info)
        {
            stillHasMapObject = true;
            position = info.position;
            state = FlowerBunchState.kFlowerBunchActive;
            mapObjectId = info.mapObjectId;
            shadowMapObjectId = info.shadowMapObjectId;
            type = info.type;
            hitLine = info.position.y - 25;
            isSquashed = false;
            if (((int)type == (int) FlowerBunchType.kFlowerBunch_Pink) || ((int)type == (int) FlowerBunchType.kFlowerBunch_Lilac)) {
                hitLine -= 20.0f;
            }

            for (int i = 0; i < Constants.MAX_PLAYERS; i++) {
                hasBeenHitBy[i] = false;
            }

        }

        public void HitByPlayer()
        {
            isSquashed = true;
            int newSubTextureId = -1;
            CGPoint positionOffset = Utilities.CGPointMake(0, 0);
            switch (type) {
            case FlowerBunchType.kFlowerBunch_Tulips :
            case FlowerBunchType.kFlowerBunch_TulipsWhite :
            case FlowerBunchType.kFlowerBunch_TulipsYellow :
            case FlowerBunchType.kFlowerBunch_TulipsBlue :
                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                    newSubTextureId = (int)World.Enum3.kGTGrass_TulipsRed_Squashed;
                }
                else {
                    newSubTextureId = (int)World.Enum2.kGTMud_TulipsRedOnFloor;
                }

                positionOffset.x = -5.0f;
                positionOffset.y = 5.0f;
                break;
            case FlowerBunchType.kFlowerBunch_Daffodil :
                newSubTextureId = (int)World.Enum3.kGTGrass_Flowers2;
                break;
            case FlowerBunchType.kFlowerBunch_Sunflowers :
                newSubTextureId = (int)World.Enum3.kGTGrass_Flowers2;
                break;
            case FlowerBunchType.kFlowerBunch_JunglePurple :
                //newSubTextureId = kGTJungle_Flowers2;
                break;
            case FlowerBunchType.kFlowerBunch_SavannaBush :
                //newSubTextureId = kGTSavanna_BushFlat;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            if (stillHasMapObject) {
                CGPoint oldPosition = ((Globals.g_world.game).GetMapObject(mapObjectId)).position;
                oldPosition.x += positionOffset.x;
                oldPosition.y += positionOffset.y;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId(newSubTextureId);
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(oldPosition);
            }

        }

        public bool HasBeenHitBy(int inPlayerId)
        {
            Globals.Assert(inPlayerId < Constants.MAX_PLAYERS);
            return hasBeenHitBy[inPlayerId];
        }

        public void SetHasBeenHitBy(int inPlayerId)
        {
            Globals.Assert(inPlayerId < Constants.MAX_PLAYERS);
            hasBeenHitBy[inPlayerId] = true;
        }

    }
}
