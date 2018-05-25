using System;

namespace Default.Namespace
{
    public enum  TreeType {
        kTree_LittleOne = 0,
        kTree_AppleTree,
        kTree_Pine
    }
    public class Tree
    {
        public CGPoint position;
        public int mapObjectId;
        public Zshake shake;
        public TreeType type;
        public bool stillHasApples;
        public bool stillHasMapObject;
        public struct TreeInfo{
            public short mapObjectId;
            public CGPoint inPosition;
            public TreeType inType;
        };
        public int MapObjectId
        {
            get;
            set;
        }

        public CGPoint Position
        {
            get;
            set;
        }

        public TreeType Type
        {
            get;
            set;
        }

        public bool StillHasApples
        {
            get;
            set;
        }

        public bool StillHasMapObject
        {
            get;
            set;
        }

		public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetType(TreeType inThing) {type = inThing;}///@property(readwrite,assign)TreeType type;
public void SetStillHasApples(bool inThing) {stillHasApples = inThing;}///@property(readwrite,assign) bool stillHasApples;
public void SetStillHasMapObject(bool inThing) {stillHasMapObject = inThing;}///@property(readwrite,assign) bool stillHasMapObject;

        public Tree()
        {
            //if (!base.init()) return null;

            shake = null;
            //return this;
        }
        public void AddToScene(TreeInfo info)
        {
            stillHasMapObject = true;
            mapObjectId = info.mapObjectId;
            position = info.inPosition;
            type = info.inType;
            stillHasApples = true;
        }

        public void SetStartOfRace()
        {
            if (shake != null) shake.Reset();

        }

        public bool Update()
        {
            if (shake != null) {
                if (shake.IsShaking()) {
                    shake.Update();
                    return true;
                }

            }

            return false;
        }

        public CGPoint GetShakingPosition()
        {
            return Utilities.CGPointMake(position.x + shake.x, position.y + shake.y);
        }

        public void Bump()
        {
            if (shake == null) {
                shake = new Zshake();
            }

            Zshake.ShakeInfo info = new Zshake.ShakeInfo();
            info.xSize = 0.0f;
            info.ySize = 2.3f;
            info.xSpeed = 0.0f;
            info.ySpeed = 0.0f;
            info.xPosition = 0.0f;
            info.yPosition = 0.0f;
            shake.Setup(info);
            shake.Reset();
            shake.StartP1(1.2f, 0.75f);
        }

    }
}
