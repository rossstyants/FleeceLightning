using System;

namespace Default.Namespace
{
    public enum  HayBaleType {
        e_Single,
        e_Double,
        e_Stack
    }
    public class HayBale
    {
        public HayBaleType type;
        public CGPoint position;
        public float radiusSquared;
        public int mapObjectId;
        public int noGoZoneId;
        public bool swappedBackward;
        public bool burstYet;
        public bool stillHasMapObject;
        public struct HayBaleInfo{
            public HayBaleType type;
            public CGPoint position;
            public int mapObjectId;
            public int noGoZoneId;
            public float radius;
        };
        //extern const float HayBale.kBaleMaxHeight;
        public CGPoint Position
        {
            get;
            set;
        }

        public HayBaleType Type
        {
            get;
            set;
        }

        public int MapObjectId
        {
            get;
            set;
        }

        public bool BurstYet
        {
            get;
            set;
        }

        public float RadiusSquared
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
//public void SetShadowMapObjectId(int inThing) {shadowMapObjectId = inThing;}///@property(readwrite,assign) int shadowMapObjectId;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetType(HayBaleType inThing) {type = inThing;}///@property(readwrite,assign) HayBaleType type;
public void SetBurstYet(bool inThing) {burstYet = inThing;}///@property(readwrite,assign) bool burstYet;
public void SetRadiusSquared(float inThing) {radiusSquared = inThing;}///@property(readwrite,assign) float radiusSquared;
public void SetStillHasMapObject(bool inThing) {stillHasMapObject = inThing;}///@property(readwrite,assign) bool stillHasMapObject;

        public const float kBaleMaxHeight = 27.0f;
        public void AddToScene(HayBaleInfo info)
        {
            stillHasMapObject = true;
            position = info.position;
            type = info.type;
            noGoZoneId = info.noGoZoneId;
            mapObjectId = info.mapObjectId;
            radiusSquared = (info.radius * info.radius);
            swappedBackward = false;
            burstYet = false;
        }

        public void BurstBaleP1(CGPoint inVelocity, CGPoint inPlayerPosition)
        {
            burstYet = true;
            inVelocity.x *= 0.5f;
            inVelocity.y *= 0.5f;
            if (position.y < (Globals.g_world.game).scrollPosition.y) {
                return;
            }

            if ((int)type == (int) HayBaleType.e_Single) {
                CGPoint[] burstPos = new CGPoint[2];
                if (Utilities.GetRand( 2) == 0) {
                    burstPos[0] = Utilities.CGPointMake(position.x - 5.0f, position.y - 38.0f);
                    burstPos[1] = Utilities.CGPointMake(position.x + 5.0f, position.y - 16.0f);
                }
                else {
                    burstPos[0] = Utilities.CGPointMake(position.x + 5.0f, position.y - 38.0f);
                    burstPos[1] = Utilities.CGPointMake(position.x - 5.0f, position.y - 16.0f);
                }

                for (int i = 0; i < 2; i++) {
                    FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
                    info.addUnderPlayer = false;
                    info.position = burstPos[i];
                    info.velocity = inVelocity;
                    info.velocity.x += -1.0f + ((float)(Utilities.GetRand( 200))) / 100.0f;
                    info.velocity.y += -1.0f + ((float)(Utilities.GetRand( 200))) / 100.0f;
                    info.rotation = 0.0f;
                    info.type = FlowerHeadType.kFlowerHead_HayBurst;
                    FlowerHead hayBurst = (Globals.g_world.game).GetFreeFlowerHeadPointer();
                    if (hayBurst != null) {
                        hayBurst.AddToScene(info);
                    }

                }

                CGPoint newPosition = Utilities.CGPointMake(position.x + 10.0f, position.y);
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId(9);
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(newPosition);
                if (((Globals.g_world.game).GetMapObject(mapObjectId)).listType ==  (int)ListType.e_RenderAbovePlayer) {
                    (Globals.g_world.game).SwapMapObjectBackward(mapObjectId);
                }

            }
            else if ((int)type == (int) HayBaleType.e_Double) {
                CGPoint[] burstPos = new CGPoint[3];
                burstPos[0] = Utilities.CGPointMake(position.x, position.y - 38.0f);
                if (Utilities.GetRand( 2) == 0) {
                    burstPos[1] = Utilities.CGPointMake(position.x - 18.0f, position.y + 10.0f);
                    burstPos[2] = Utilities.CGPointMake(position.x + 18.0f, position.y);
                }
                else {
                    burstPos[1] = Utilities.CGPointMake(position.x + 18.0f, position.y + 10.0f);
                    burstPos[2] = Utilities.CGPointMake(position.x - 18.0f, position.y);
                }

                for (int i = 0; i < 3; i++) {
                    FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
                    info.addUnderPlayer = false;
                    info.position = burstPos[i];
                    info.velocity = inVelocity;
                    info.velocity.x += -1.0f + ((float)(Utilities.GetRand( 200))) / 100.0f;
                    info.velocity.y += -1.0f + ((float)(Utilities.GetRand( 200))) / 100.0f;
                    info.rotation = 0.0f;
                    info.type = FlowerHeadType.kFlowerHead_HayBurst;
                    {
                    }
                }

                if (stillHasMapObject) {
                    CGPoint newPosition = Utilities.CGPointMake(position.x - 5.0f, position.y);
                    ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId((int)World.Enum2.kGTMud_HayBaleSingleSquashed);
                    ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(newPosition);
                    if (((Globals.g_world.game).GetMapObject(mapObjectId)).listType ==  (int)ListType.e_RenderAbovePlayer) {
                        (Globals.g_world.game).SwapMapObjectBackward(mapObjectId);
                    }

                }

            }
            else {
                CGPoint[] burstPos = new CGPoint[2];
                if (Utilities.GetRand( 2) == 0) {
                    burstPos[0] = Utilities.CGPointMake(inPlayerPosition.x - 10.0f, inPlayerPosition.y + 10.0f);
                    burstPos[1] = Utilities.CGPointMake(inPlayerPosition.x + 10.0f, inPlayerPosition.y - 5.0f);
                }
                else {
                    burstPos[0] = Utilities.CGPointMake(inPlayerPosition.x + 10.0f, inPlayerPosition.y + 10.0f);
                    burstPos[1] = Utilities.CGPointMake(inPlayerPosition.x - 10.0f, inPlayerPosition.y - 5.0f);
                }

                burstPos[0] = Utilities.CGPointMake(inPlayerPosition.x, inPlayerPosition.y + 10.0f);
                for (int i = 0; i < 1; i++) {
                    FlowerHead.FlowerHeadInfo info = new FlowerHead.FlowerHeadInfo();
                    info.addUnderPlayer = false;
                    info.position = burstPos[i];
                    info.velocity = inVelocity;
                    inVelocity.y /= 2.0f;
                    info.velocity.x += -1.0f + ((float)(Utilities.GetRand( 200))) / 100.0f;
                    info.velocity.y += -1.0f + ((float)(Utilities.GetRand( 200))) / 100.0f;
                    info.rotation = 0.0f;
                    info.type = FlowerHeadType.kFlowerHead_HayBurstCloud;
                    FlowerHead hayBurst = (Globals.g_world.game).GetFreeFlowerHeadPointer();
                    if (hayBurst != null) {
                        hayBurst.AddToScene(info);
                    }

                }

            }

        }

        public bool Update(CGPoint playerPosition)
        {
            if (playerPosition.y > position.y) {
                if (!swappedBackward) {
                    swappedBackward = true;
                    return true;
                }

            }

            return false;
        }

    }
}
