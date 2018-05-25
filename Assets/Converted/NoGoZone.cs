using System;

namespace Default.Namespace
{
    public enum  NoGoType {
        e_General,
        e_Rock,
        e_BigRock,
        e_Piggy,
        e_Tree,
        e_GatePost,
        e_HayBale,
        e_HayStack,
        e_Tractor,
        e_Chimney,
        e_Bucket,
        e_Cart,
        e_Welly,
        e_Cactus,
        e_BuildingCorner,
        e_StoneWell,
        e_StoneWallPost,
        e_OilDrum,
        e_FlockAnimal,
        e_Bollard,
        e_Seal,
        e_Igloo,
        e_Cow,
        e_WaterfallHead,
        e_CrossingThing,
        e_Elephant,
        e_Crocodile,
        e_Lion,
        e_Gnome,
        e_Squash,
        e_Courgette,
        e_Pumpkin,
        e_Cauliflower,
        e_Trampoline,
        e_Bridge
    }
    public class NoGoZone
    {
        public CGPoint mapPosition;
        public float radius;
        public float collidedTime;
        public float ceilingHeight;
        public float groundLevel;
        public NoGoType type;
        public bool stillHasMapObject;
        public bool isBouncable;
        public bool goneInactive;
        public int objectId;
        public int shadowObjectId;
        public CGPoint MapPosition
        {
            get;
            set;
        }

        public NoGoType Type
        {
            get;
            set;
        }

        public float CollidedTime
        {
            get;
            set;
        }

        public int ObjectId
        {
            get;
            set;
        }

        public int ShadowObjectId
        {
            get;
            set;
        }

        public bool GoneInactive
        {
            get;
            set;
        }

        public float CeilingHeight
        {
            get;
            set;
        }

        public bool IsBouncable
        {
            get;
            set;
        }

        public float GroundLevel
        {
            get;
            set;
        }

        public bool StillHasMapObject
        {
            get;
            set;
        }

public void SetMapPosition(CGPoint inThing) {mapPosition = inThing;}///@property(readwrite,assign) CGPoint mapPosition;
public void SetType(NoGoType inThing) {type = inThing;}///@property(readwrite,assign) NoGoType type;
public void SetCollidedTime(float inThing) {collidedTime = inThing;}///@property(readwrite,assign) float collidedTime;
public void SetCeilingHeight(float inThing) {ceilingHeight = inThing;}///@property(readwrite,assign) float ceilingHeight;
public void SetGroundLevel(float inThing) {groundLevel = inThing;}///@property(readwrite,assign) float groundLevel;
public void SetObjectId(int inThing) {objectId = inThing;}///@property(readwrite,assign) int objectId;
public void SetShadowObjectId(int inThing) {shadowObjectId = inThing;}///@property(readwrite,assign) int shadowObjectId;
public void SetGoneInactive(bool inThing) {goneInactive = inThing;}///@property(readwrite,assign) bool goneInactive;
public void SetIsBouncable(bool inThing) {isBouncable = inThing;}///@property(readwrite,assign) bool isBouncable;
public void SetStillHasMapObject(bool inThing) {stillHasMapObject = inThing;}///@property(readwrite,assign) bool stillHasMapObject;

	/*	public void SetMapPosition(CGPoint inThing)
        {
			mapPosition = inThing;
		}

		public void SetCollidedTime(float inThing)
        {
			collidedTime = inThing;
		}
		public void SetCeilingHeight(float inThing)
        {
			ceilingHeight = inThing;
		}
		public void SetGroundLevel(float inThing)
        {
			groundLevel = inThing;
		}
		public void SetObjectId(int inThing)
        {
			objectId = (short)inThing;
		}
		public void SetShadowObjectId(int inThing)
        {
			shadowObjectId = (short)inThing;
		}
		public void SetGoneInactive(bool inThing)
        {
			goneInactive = inThing;
		}
		public void SetIsBouncable(bool inThing)
        {
			isBouncable = inThing;
		}
		public void SetStillHasMapObject(bool inThing)
        {
			stillHasMapObject = inThing;
		}
		public void SetType(NoGoType inThing)
        {
			type = inThing;
		}*/


		public void Dealloc()
        {
        }

        public void InitialiseP1(CGPoint inMapPosition, float inRadius)
        {
            stillHasMapObject = true;
            mapPosition = inMapPosition;
            radius = inRadius;
            type = NoGoType.e_General;
            collidedTime = -1;
            goneInactive = false;
            isBouncable = false;
            ceilingHeight = 1000.0f;
            groundLevel = 0.0f;
        }

        public CGPoint GetPosition()
        {
            return mapPosition;
        }

        public float GetRadius()
        {
            return radius;
        }

    }
}
