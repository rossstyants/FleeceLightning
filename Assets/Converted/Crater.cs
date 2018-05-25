using System;

namespace Default.Namespace
{
    public enum  CraterType {
        e_Normal,
        e_Normal2x2,
        e_Normal1x1,
        e_Hillock,
        e_SmallBump
    }
    public class Crater
    {
        public float height;
        public CGPoint position;
        public float bumpRadius;
        public float bumpRadiusSqr;
        public CraterType type;
        public struct CraterInfo {
            public CGPoint position;
            public CraterType type;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public CraterType Type
        {
            get;
            set;
        }

        public float BumpRadius
        {
            get;
            set;
        }

        public float BumpRadiusSqr
        {
            get;
            set;
        }

        public float Height
        {
            get;
            set;
        }

		public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetType(CraterType inThing) {type = inThing;}///@property(readwrite,assign) CraterType type;
public void SetBumpRadius(float inThing) {bumpRadius = inThing;}///@property(readwrite,assign) float bumpRadius;
public void SetBumpRadiusSqr(float inThing) {bumpRadiusSqr = inThing;}///@property(readwrite,assign) float bumpRadiusSqr;
public void SetHeight(float inThing) {height = inThing;}///@property(readwrite,assign) float height;

        public void AddToScene(CraterInfo info)
        {
            position = info.position;
            type = info.type;
            if ((int)type == (int) CraterType.e_Normal) {
                bumpRadius = 160.0f;
                height = 65.0f;
            }
            else if ((int)type == (int) CraterType.e_Normal2x2) {
                bumpRadius = 64.0f;
                height = 25.0f;
            }
            else if ((int)type == (int) CraterType.e_Normal1x1) {
                bumpRadius = 32.0f;
                height = 13.0f;
            }
            else if ((int)type == (int) CraterType.e_Hillock) {
                bumpRadius = 128.0f;
                height = 48.0f;
            }
            else if ((int)type == (int) CraterType.e_SmallBump) {
                bumpRadius = 64.0f;
                height = 13.0f;
            }
            else {
                Globals.Assert(false);
            }

            bumpRadiusSqr = (bumpRadius * bumpRadius);
        }

        public float GetGroundLevel(CGPoint inMapPos)
        {
            return 0.0f;
        }

    }
}
