using System;

namespace Default.Namespace
{
    public enum  BuildingType {
        kBuilding_Barn,
        kBuilding_SideShed,
        kBuilding_House,
        kBuilding_Skip,
        kBuilding_Tent
    }
    public class Building
    {
        public CGPoint topLeftRoof;
        public CGPoint bottomRightRoof;
        public CGPoint topLeftGround;
        public CGPoint bottomRightGround;
        public float height;
        public BuildingType type;
		
        public struct BuildingInfo{
            public CGPoint topLeft;
            public CGPoint bottomRight;
            public BuildingType inType;
        };
		
        public float Height
        {
            get;
            set;
        }

        public BuildingType Type
        {
            get;
            set;
        }

        public CGPoint BottomRightGround
        {
            get;
            set;
        }

        public CGPoint TopLeftGround
        {
            get;
            set;
        }

		public void SetHeight(float inThing) {height = inThing;}///@property(readwrite,assign) float height;
public void SetType(BuildingType inThing) {type = inThing;}///@property(readwrite,assign) BuildingType type;
public void SetTopLeftGround(CGPoint inThing) {topLeftGround = inThing;}///@property(readwrite,assign) CGPoint topLeftGround;
public void SetBottomRightGround(CGPoint inThing) {bottomRightGround = inThing;}///@property(readwrite,assign) CGPoint bottomRightGround;
//public void SetBottomRight(CGPoint inThing) {bottomRight = inThing;}///@property(readwrite,assign) CGPoint bottomRight;


        public void AddToScene (BuildingInfo info)
		{
			float kSideSpaceRoof = 0;
			float kTopSpaceRoof = 0;
			float kBottomSpaceRoof = 0;
			float kSideSpace = 0;
			float kTopSpace = 0;
			float kBottomSpace = 0;
			if ((int)info.inType == (int)BuildingType.kBuilding_SideShed) {
				kSideSpaceRoof = 0.0f;
				kTopSpaceRoof = -30.0f;
				kBottomSpaceRoof = 0.0f;
				kSideSpace = 15.0f;
				kTopSpace = 20.0f;
				kBottomSpace = 40.0f;
			} else if ((int)info.inType == (int)BuildingType.kBuilding_Barn) {
				kSideSpaceRoof = 0.0f;
				kTopSpaceRoof = -30.0f;
				kBottomSpaceRoof = 0.0f;
				kSideSpace = 15.0f;
				kTopSpace = 20.0f;
				kBottomSpace = 40.0f;
			} else if ((int)info.inType == (int)BuildingType.kBuilding_House) {
				kSideSpaceRoof = 0.0f;
				kTopSpaceRoof = -42.0f;
				kBottomSpaceRoof = 0.0f;
				kSideSpace = 15.0f;
				kTopSpace = 8.0f;
				kBottomSpace = 70.0f;
			} else if (((int)info.inType == (int)BuildingType.kBuilding_Skip) || ((int)info.inType ==  (int)BuildingType.kBuilding_Tent)) {
                kSideSpaceRoof = 0.0f;
                kTopSpaceRoof = -42.0f;
                kBottomSpaceRoof = 0.0f;
                kSideSpace = 15.0f;
                kTopSpace = 8.0f;
                kBottomSpace = 70.0f;
            }
            else {
                Globals.Assert(false);
            }

            topLeftRoof = Utilities.CGPointMake(info.topLeft.x - kSideSpaceRoof, info.topLeft.y + kTopSpaceRoof);
            bottomRightRoof = Utilities.CGPointMake(info.bottomRight.x + kSideSpaceRoof, info.bottomRight.y + kBottomSpaceRoof);
            topLeftGround = Utilities.CGPointMake(info.topLeft.x - kSideSpace, info.topLeft.y + kTopSpace);
            bottomRightGround = Utilities.CGPointMake(info.bottomRight.x + kSideSpace, info.bottomRight.y + kBottomSpace);
            type = info.inType;
            height = 35.0f;
        }

        public float GetLeftEdge(float inZ)
        {
            float ratio = Utilities.GetRatioP1P2(inZ, 0.0f, height);
            return (topLeftGround.x * (1.0f - ratio)) + (topLeftRoof.x * ratio);
        }

        public float GetRightEdgeP1(float inZ, float inY)
        {
            float ratio = Utilities.GetRatioP1P2(inZ, 0.0f, height);
            float outEdge = (bottomRightGround.x * (1.0f - ratio)) + (bottomRightRoof.x * ratio);
            return outEdge;
        }

        public float GetTopEdge(float inZ)
        {
            float ratio = Utilities.GetRatioP1P2(inZ, 0.0f, height);
            return (topLeftGround.y * (1.0f - ratio)) + (topLeftRoof.y * ratio);
        }

        public float GetBottomEdge(float inZ)
        {
            float ratio = Utilities.GetRatioP1P2(inZ, 0.0f, height);
            return (bottomRightGround.y * (1.0f - ratio)) + (bottomRightRoof.y * ratio);
        }

        public float GetGroundLevel (CGPoint inPos)
		{
			CGPoint offset = Utilities.CGPointMake (inPos.x - topLeftRoof.x, inPos.y - topLeftRoof.y);
			if ((int)type == (int)BuildingType.kBuilding_SideShed) {
				float kShedMaxHeight = height;
				float kShedMinHeight = height - 9.0f;
				if ((inPos.x > bottomRightRoof.x) || (inPos.x < topLeftRoof.x)) {
					return 0.0f;
				} else if (inPos.y > bottomRightRoof.y) {
					return 0.0f;
				} else {
					float distanceToPeak = 160.0f;
					if (offset.y < distanceToPeak) {
						float ratio = Utilities.GetRatioP1P2 (offset.y, 0, distanceToPeak);
						float extraHeight = (ratio * (kShedMaxHeight - kShedMinHeight));
						return kShedMinHeight + extraHeight;
					} else {
						float distanceToEnd = bottomRightRoof.y - topLeftRoof.y;
						float ratio = 1.0f - Utilities.GetRatioP1P2 (offset.y, distanceToPeak, distanceToEnd);
						float extraHeight = (ratio * (kShedMaxHeight - kShedMinHeight));
						return kShedMinHeight + extraHeight;
					}

				}

			} else if ((int)type == (int)BuildingType.kBuilding_Barn) {
				if ((inPos.x > bottomRightRoof.x) || (inPos.x < topLeftRoof.x)) {
					return 0.0f;
				} else if (inPos.y > bottomRightRoof.y) {
					return 0.0f;
				} else {
					return height;
				}

			} else if ((int)type == (int)BuildingType.kBuilding_House) {
				if ((inPos.x > bottomRightRoof.x) || (inPos.x < topLeftRoof.x)) {
					return 0.0f;
				} else if (inPos.y > bottomRightRoof.y) {
					return 0.0f;
				} else {
					return height;
				}

			} else if (((int)type == (int)BuildingType.kBuilding_Skip) || ((int)type ==  (int)BuildingType.kBuilding_Tent)) {
                if ((inPos.x > bottomRightRoof.x) || (inPos.x < topLeftRoof.x)) {
                    return 0.0f;
                }
                else if (inPos.y > bottomRightRoof.y) {
                    return 0.0f;
                }
                else {
                    return height;
                }

            }

            Globals.Assert(false);
            return 0.0f;
        }

    }
}
