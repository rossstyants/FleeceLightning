using System;

namespace Default.Namespace
{
    public class CliffPiece
    {
        public CGPoint topLeft;
        public CGPoint bottomRight;
        public bool upSlope;
        public bool isStartPiece;
        public bool isEndPiece;
        const float kCliffHeight = 12.0f;
        public struct CliffPieceInfo {
            public CGPoint topLeft;
            public CGPoint bottomRight;
        };
       // const float kCliffHeight;
        public CGPoint TopLeft
        {
            get;
            set;
        }

        public CGPoint BottomRight
        {
            get;
            set;
        }

        public bool IsStartPiece
        {
            get;
            set;
        }

        public bool IsEndPiece
        {
            get;
            set;
        }

        public bool UpSlope
        {
            get;
            set;
        }

public void SetTopLeft(CGPoint inThing) {topLeft = inThing;}///@property(readwrite,assign) CGPoint topLeft;
public void SetBottomRight(CGPoint inThing) {bottomRight = inThing;}///@property(readwrite,assign) CGPoint bottomRight;
public void SetIsEndPiece(bool inThing) {isEndPiece = inThing;}///@property(readwrite,assign) bool isEndPiece;
public void SetIsStartPiece(bool inThing) {isStartPiece = inThing;}///@property(readwrite,assign) bool isStartPiece;
public void SetUpSlope(bool inThing) {upSlope = inThing;}///@property(readwrite,assign) bool upSlope;

        public CliffPiece()
        {
            //if (!base.init()) return null;

            //return this;
        }
        public void AddToScene(CliffPieceInfo info)
        {
            topLeft = info.topLeft;
            bottomRight = info.bottomRight;
            isEndPiece = false;
            isStartPiece = false;
            upSlope = false;
        }

        public float GetRightEdgeForBumpP1(float inY, float inZ)
        {
            float ratio = Utilities.GetRatioP1P2(inZ, 0, kCliffHeight);
            float edgeAtTop = this.GetRightEdgeP1(inY, true);
            float edgeAtBottom = this.GetRightEdgeP1(inY, false);
            float outEdge = (ratio * edgeAtTop) + ((1.0f - ratio) * edgeAtBottom);
            return outEdge;
        }

        public float GetLeftEdgeForBumpP1(float inY, float inZ)
        {
            float ratio = Utilities.GetRatioP1P2(inZ, 0, kCliffHeight);
            float edgeAtTop = this.GetLeftEdgeP1(inY, true);
            float edgeAtBottom = this.GetLeftEdgeP1(inY, false);
            float outEdge = (ratio * edgeAtTop) + ((1.0f - ratio) * edgeAtBottom);
            return outEdge;
        }

        public float GetLeftEdgeP1(float inY, bool onTop)
        {
            int[] tileId = new int[5];
            int x = (int) (topLeft.x / 64.0f);
            int y = (int) (topLeft.y / 64.0f);
            for (int n = 0; n < 5; n++) {
               tileId[n] = (((Globals.g_world.game).tileMap).tileGrid).GetTileIdP1(x + n - 1, y) - (int)TileMap.Enum1.kTile_Cliff1 + 1;
            }

            float kFluffBuffer = -18.0f;
            if (onTop) {
                kFluffBuffer = -5.0f;
            }

            if (tileId[1] == 4) {
                if (onTop) {
                    return kFluffBuffer + topLeft.x;
                }

                if (tileId[0] == 19) {
                    return kFluffBuffer + topLeft.x - 64.0f + (inY - topLeft.y);
                }
                else return kFluffBuffer + topLeft.x;

            }
            else if (tileId[1] == 11) {
                upSlope = true;
                return kFluffBuffer + topLeft.x + 64.0f - (inY - topLeft.y);
            }
            else if (tileId[1] == 7) {
                if (onTop) {
                    return kFluffBuffer + topLeft.x + (inY - topLeft.y);
                }

                return kFluffBuffer + topLeft.x;
            }
            else {
            }

            return kFluffBuffer + topLeft.x - (inY - topLeft.y);
        }

        public float GetRightEdgeP1 (float inY, bool onTop)
		{
			int[] tileId = new int[5];
			int x = (int)(topLeft.x / 64.0f);
			int y = (int)(topLeft.y / 64.0f);
			for (int n = 0; n < 5; n++) {
				tileId [n] = (((Globals.g_world.game).tileMap).tileGrid).GetTileIdP1 (x + n - 1, y) - (int)TileMap.Enum1.kTile_Cliff1 + 1;
            }

            float kFluffBuffer = 18.0f;
            if (onTop) {
                kFluffBuffer = 2.0f;
            }

            if (tileId[3] == 9) {
                upSlope = true;
                return kFluffBuffer + bottomRight.x + (inY - topLeft.y);
            }
            else if (tileId[3] == 14) {
                float offset = (inY - topLeft.y);
                if (onTop) {
                    return kFluffBuffer + bottomRight.x + 64.0f - (offset);
                }
                else {
                    float kHowFar = 36.0f;
                    if (offset < kHowFar) {
                        return kFluffBuffer + bottomRight.x + 64.0f;
                    }
                    else {
                        float ratio = Utilities.GetRatioP1P2(offset, kHowFar, 64.0f);
                        return kFluffBuffer + bottomRight.x + 64.0f - (64.0f * ratio);
                    }

                }

            }

            return kFluffBuffer + bottomRight.x;
        }

    }
}
