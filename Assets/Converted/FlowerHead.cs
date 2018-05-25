using System;
using UnityEngine;

namespace Default.Namespace
{
    public enum  FlowerHeadType {
        kFlowerHead_Sunflower = 0,
        kFlowerHead_Lilac,
        kFlowerHead_Pink,
        kFlowerHead_BushExplosion,
        kFlowerHead_HayBurst,
        kFlowerHead_HayBurstCloud,
        kFlowerHead_HayBurstStack,
        kFlowerHead_Bucket,
        kFlowerHead_Welly,
        kFlowerHead_Bollard,
        kFlowerHead_Cauliflower,
        kFlowerHead_Apple,
        kFlowerHead_GnomePiece,
        kFlowerHead_Daffodil,
        kFlowerHead_Tulip,
        kFlowerHead_TulipWhite,
        kFlowerHead_TulipYellow,
        kFlowerHead_TulipBlue,
        kFlowerHead_PumpkinPiece,
        kFlowerHead_SquashPiece,
        kFlowerHead_CourgettePiece,
        kFlowerHead_BushFragment
    }
    public enum  FlowerHeadState {
        e_Active,
        e_OnGround,
        e_Inactive
    }
    public enum  FlowerHeadAnimation {
        n_Spin = 0,
        tions
    }
    public class FlowerHead
    {
        public FlowerHeadState state;
        public CGPoint position;
        public CGPoint shadowPosition;
        public CGPoint velocity;
        public float upVelocity;
        public float height;
        public float rotation;
        public float spinSpeed;
        public float animTimer;
        public float rotationScale;
        public float useGravity;
        public float alpha;
        public float scale;
        public FlowerHeadType type;
        public int myId;
        public int numBounces;
        public int currentAnim;
        public int currentShadowAnim;
        public int shadowSubTextureStart;
        public int flowerSubTextureStart;
        public int numFlowerAnims;
        public int numShadowAnims;
        public int mapObjectId;
        public int shadowMapObjectId;
        public bool splattable;
        public struct FlowerHeadInfo{
            public CGPoint position;
            public CGPoint velocity;
            public float rotation;
            public FlowerHeadType type;
            public bool addUnderPlayer;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public CGPoint Velocity
        {
            get;
            set;
        }

        public FlowerHeadState State
        {
            get;
            set;
        }

		//public void SetState(FlowerHeadState inThing) {state = inThing;}///@property(readwrite,assign) FlowerHeadState state;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetVelocity(CGPoint inThing) {velocity = inThing;}///@property(readwrite,assign) CGPoint velocity;

        public FlowerHead(int inId)
        {
            //if (!base.init()) return null;

            myId = (short)inId;
            //return this;
        }

        public void SetupAnimations()
        {
            ZAnimationInfo info = new ZAnimationInfo();
            info.numFrames = 13;
            for (int i = 0; i < info.numFrames; i++) {
                info.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_FlyingFlower1 + i);
                info.frameTime[i] = 0.1f;
            }

            info.gapType = GapType.kAnimGapTime;
            info.numFrames = 7;
            for (int i = 0; i < info.numFrames; i++) {
                info.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_FlyingFlowerShadow1 + i);
                info.frameTime[i] = 0.1f;
            }

            info.gapType = GapType.kAnimGapTime;
        }

        public void SetState(FlowerHeadState newState)
        {
            state = newState;
        }

        public void AddToScene(FlowerHeadInfo info)
        {
			//Debug.Log("AddFlowerhead" + myId.ToString() + " "  + info.type.ToString());
			
            splattable = false;
            type = info.type;
            switch (info.type) {
            case FlowerHeadType.kFlowerHead_PumpkinPiece :
                shadowSubTextureStart = (short)World.Enum2.kGTMud_GenericShadow;
                flowerSubTextureStart = (short)World.Enum2.kGTMud_PumpkinPiece;
                numFlowerAnims = 1;
                numShadowAnims = 1;
                rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud)).GetSubTextureRotationScale(flowerSubTextureStart);
                upVelocity = ((float)(Utilities.GetRand( 5))) + 8.0f;
                upVelocity *= 1.0f;
                useGravity = 1.5f;
                height = 30;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 50.0f;
                if (Utilities.GetRand( 2) == 0) splattable = true;

                if (Utilities.GetRand( 2) == 0) {
                    spinSpeed = -spinSpeed;
                }

                break;
            case FlowerHeadType.kFlowerHead_SquashPiece :
                shadowSubTextureStart = (short)World.Enum2.kGTMud_GenericShadow;
                flowerSubTextureStart = (short)World.Enum2.kGTMud_SquashPiece;
                numFlowerAnims = 1;
                numShadowAnims = 1;
                rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud)).GetSubTextureRotationScale(flowerSubTextureStart);
                upVelocity = ((float)(Utilities.GetRand( 5))) + 8.0f;
                useGravity = 1.5f;
                height = 30;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 50.0f;
                if (Utilities.GetRand( 2) == 0) splattable = true;

                if (Utilities.GetRand( 2) == 0) {
                    spinSpeed = -spinSpeed;
                }

                break;
            case FlowerHeadType.kFlowerHead_CourgettePiece :
                shadowSubTextureStart = (short)World.Enum2.kGTMud_GenericShadow;
                flowerSubTextureStart = (short)World.Enum2.kGTMud_CourgettePiece;
                numFlowerAnims = 1;
                numShadowAnims = 1;
                rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud)).GetSubTextureRotationScale(flowerSubTextureStart);
                upVelocity = ((float)(Utilities.GetRand( 5))) + 8.0f;
                useGravity = 1.5f;
                height = 30;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 50.0f;
                if (Utilities.GetRand( 2) == 0) splattable = true;

                if (Utilities.GetRand( 2) == 0) {
                    spinSpeed = -spinSpeed;
                }

                break;
            case FlowerHeadType.kFlowerHead_TulipBlue :
            case FlowerHeadType.kFlowerHead_TulipWhite :
            case FlowerHeadType.kFlowerHead_TulipYellow :
            case FlowerHeadType.kFlowerHead_Tulip :
                shadowSubTextureStart = (short)World.Enum3.kGTGrass_FlowerShadow1;
                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                    int startPetal = 0;
                    if ((int)info.type == (int) FlowerHeadType.kFlowerHead_Tulip) startPetal = (int)World.Enum3.kGTGrass_TulipsRed_Petal1;
                    else if ((int)info.type == (int) FlowerHeadType.kFlowerHead_TulipWhite) startPetal = (int)World.Enum3.kGTGrass_TulipWhitePetal1;
                    else if ((int)info.type == (int) FlowerHeadType.kFlowerHead_TulipBlue) startPetal = (int)World.Enum3.kGTGrass_TulipBluePetal1;
                    else if ((int)info.type == (int) FlowerHeadType.kFlowerHead_TulipYellow) startPetal = (int)World.Enum3.kGTGrass_TulipYellowPetal1;

                    flowerSubTextureStart = (short)(startPetal + Utilities.GetRand( 2));
                    rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale(flowerSubTextureStart);
                }
                else {
                    shadowSubTextureStart = (short)World.Enum2.kGTMud_TulipPetalShadow;
                    int startPetal = 0;
                    if ((int)info.type == (int) FlowerHeadType.kFlowerHead_Tulip) startPetal = (int)World.Enum2.kGTMud_TulipRedPetal1;
                    else if ((int)info.type == (int) FlowerHeadType.kFlowerHead_TulipWhite) startPetal = (int)World.Enum2.kGTMud_TulipWhitePetal1;
                    else if ((int)info.type == (int) FlowerHeadType.kFlowerHead_TulipBlue) startPetal = (int)World.Enum2.kGTMud_TulipBluePetal1;
                    else if ((int)info.type == (int) FlowerHeadType.kFlowerHead_TulipYellow) startPetal = (int)World.Enum2.kGTMud_TulipYellowPetal1;

                    flowerSubTextureStart =  (short)(startPetal + Utilities.GetRand( 2));
                    rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud)).GetSubTextureRotationScale(flowerSubTextureStart);
                }

                numFlowerAnims = 1;
                numShadowAnims = 1;
                upVelocity = ((float)(Utilities.GetRand( 5))) + 8.0f;
                useGravity = 0.7f;
                height = 30;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 25.0f;
                if (Utilities.GetRand( 2) == 0) {
                    spinSpeed = -spinSpeed;
                }

                break;
            case FlowerHeadType.kFlowerHead_BushFragment :
                shadowSubTextureStart = (short)World.Enum3.kGTGrass_GenericShadow;
                flowerSubTextureStart = (short)((int)World.Enum3.kGTGrass_BushFragment1 + Utilities.GetRand( 2));
                numFlowerAnims = 1;
                numShadowAnims = 1;
                rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale(flowerSubTextureStart);
                upVelocity = ((float)(Utilities.GetRand( 5))) + 8.0f;
                useGravity = 1.2f;
                height = 30;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 50.0f;
                if (Utilities.GetRand( 2) == 0) {
                    spinSpeed = -spinSpeed;
                }

                break;
            case FlowerHeadType.kFlowerHead_Daffodil :
                shadowSubTextureStart = (short)World.Enum3.kGTGrass_FlowerShadow1;
                flowerSubTextureStart = (short)World.Enum3.kGTGrass_FlowerHead1;
                numFlowerAnims = 1;
                numShadowAnims = 1;
                rotationScale = (Globals.g_world.GetAtlas(AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale((int)World.Enum3.kGTGrass_FlowerHead1);
                upVelocity = ((float)(Utilities.GetRand( 5))) + 8.0f;
                useGravity = 1.2f;
                height = 30;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 50.0f;
                if (Utilities.GetRand( 2) == 0) {
                    spinSpeed = -spinSpeed;
                }

                break;
            case FlowerHeadType.kFlowerHead_Sunflower :
                shadowSubTextureStart = (short)World.Enum3.kGTGrass_FlowerShadow1;
                flowerSubTextureStart = (short)World.Enum3.kGTGrass_FlowerHead1;
                numFlowerAnims = 1;
                numShadowAnims = 7;
                rotationScale = Globals.g_world.GetRotationScaleForShorts(22.6274f);
                upVelocity = ((float)(Utilities.GetRand( 5))) + 5.0f;
                useGravity = 0.5f;
                height = 30;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 100;
                break;
            case FlowerHeadType.kFlowerHead_Lilac :
                shadowSubTextureStart = 3;
                flowerSubTextureStart = 20;
                numFlowerAnims = 8;
                numShadowAnims = 1;
                rotationScale = Globals.g_world.GetRotationScaleForShorts(11.3137f);
                upVelocity = ((float)(Utilities.GetRand( 3))) + 2.5f;
                useGravity = 0.15f;
                height = 10;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 100;
                alpha = 1.0f;
                break;
            case FlowerHeadType.kFlowerHead_Pink :
                shadowSubTextureStart = 3;
                flowerSubTextureStart = 34;
                numFlowerAnims = 14;
                numShadowAnims = 1;
                rotationScale = Globals.g_world.GetRotationScaleForShorts(11.3137f);
                upVelocity = ((float)(Utilities.GetRand( 2))) + 2.0f;
                useGravity = 0.1f;
                height = 10;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 250.0f;
                alpha = 1.0f;
                break;
            case FlowerHeadType.kFlowerHead_BushExplosion :
                shadowSubTextureStart = 2;
                flowerSubTextureStart = 28;
                numFlowerAnims = 4;
                numShadowAnims = 1;
                rotationScale = Globals.g_world.GetRotationScaleForShorts(45.3137f);
                upVelocity = 10.0f;
                useGravity = 0.7f;
                height = 10;
                alpha = 1.0f;
                scale = 1.0f;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 100;
                break;
            case FlowerHeadType.kFlowerHead_Bucket :
                shadowSubTextureStart = 2;
                flowerSubTextureStart = 56;
                numFlowerAnims = 7;
                numShadowAnims = 1;
                rotationScale = Globals.g_world.GetRotationScaleForShorts(45.3137f);
                upVelocity = 10.0f;
                useGravity = 0.7f;
                height = 10;
                alpha = 1.0f;
                scale = 1.0f;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 100;
                break;
            case FlowerHeadType.kFlowerHead_Bollard :
            case FlowerHeadType.kFlowerHead_Cauliflower :
                if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                    flowerSubTextureStart = (short)World.Enum3.kGTGrass_Bollard;
                    shadowSubTextureStart = (short)World.Enum3.kGTGrass_GenericShadow;
                }
                else {
                    if ((int)type == (int) FlowerHeadType.kFlowerHead_Cauliflower) {
                        flowerSubTextureStart = (short)World.Enum2.kGTMud_CauliFlower;
                    }
                    else {
                        flowerSubTextureStart = (short)World.Enum2.kGTMud_TrafficCone;
                    }

                    shadowSubTextureStart = (short)World.Enum2.kGTMud_GenericShadow;
                }

                numFlowerAnims = 1;
                numShadowAnims = 1;
                rotationScale = Globals.g_world.GetRotationScaleForShorts(45.3137f);
                upVelocity = 10.0f;
                useGravity = 0.7f;
                height = 10;
                alpha = 1.0f;
                scale = 1.0f;
                spinSpeed = 100000.0f;
                break;
            case FlowerHeadType.kFlowerHead_Apple :
                shadowSubTextureStart = (short)World.Enum3.kGTGrass_AppleShadow;
                flowerSubTextureStart = (short)World.Enum3.kGTGrass_Apple1;
                numFlowerAnims = 1;
                numShadowAnims = 1;
                rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale((int)World.Enum3.kGTGrass_Apple1);
                upVelocity = 6.0f;
                upVelocity += Utilities.GetRandBetweenP1(0.0f, 12.0f);
                useGravity = 2.5f;
                height = 480;
                alpha = 1.0f;
                scale = 1.0f;
                spinSpeed = 100000.0f;
                break;
            case FlowerHeadType.kFlowerHead_GnomePiece :
                shadowSubTextureStart = (short)World.Enum3.kGTGrass_AppleShadow;
                flowerSubTextureStart = (short)World.Enum3.kGTGrass_GnomePieceRed1;
                if (Utilities.GetRand( 2) == 0) {
                    flowerSubTextureStart = (short)World.Enum3.kGTGrass_GnomePieceBlack1;
                }

                numFlowerAnims = 5;
                numShadowAnims = 1;
                rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale((int)World.Enum3.kGTGrass_Apple1);
                upVelocity = 6.0f;
                upVelocity += Utilities.GetRandBetweenP1(0.0f, 12.0f);
                useGravity = 2.5f;
                height = Utilities.GetRandBetweenP1(60.0f, 160.0f);
                alpha = 1.0f;
                scale = 1.0f;
                spinSpeed = Utilities.GetRandBetweenP1(0.04f, 0.08f);
                break;
            case FlowerHeadType.kFlowerHead_Welly :
                shadowSubTextureStart = (short)World.Enum2.kGTMud_WellyShadow;
                flowerSubTextureStart = (short)World.Enum2.kGTMud_Welly;
                numFlowerAnims = 1;
                numShadowAnims = 1;
                rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud)).GetSubTextureRotationScale((int)World.Enum2.kGTMud_Welly);
                upVelocity = 10.0f;
                useGravity = 0.7f;
                height = 10;
                alpha = 1.0f;
                scale = 1.0f;
                spinSpeed = ((float)(5 + Utilities.GetRand( 15))) / 100;
                if (Utilities.GetRand( 2) == 0) {
                    spinSpeed = -spinSpeed;
                }

                break;
            case FlowerHeadType.kFlowerHead_HayBurst :
            case FlowerHeadType.kFlowerHead_HayBurstStack :
            case FlowerHeadType.kFlowerHead_HayBurstCloud :
                shadowSubTextureStart = 2;
                flowerSubTextureStart = 3;
                numFlowerAnims = 4;
                numShadowAnims = 1;
                rotationScale = Globals.g_world.GetRotationScaleForShorts(45.3137f);
                upVelocity = 10.0f;
                useGravity = 0.7f;
                height = 10;
                alpha = 1.0f;
                scale = 1.0f;
                spinSpeed = ((float)(5 + Utilities.GetRand( 8))) / 100;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            animTimer = 0.0f;
            currentAnim = 0;
            if ((int)type == (int) FlowerHeadType.kFlowerHead_GnomePiece) {
                currentAnim = (short)Utilities.GetRand( numFlowerAnims);
            }

            currentShadowAnim = 0;
            position = info.position;
            velocity = info.velocity;
            this.SetState( FlowerHeadState.e_Active);
            numBounces = 0;
            rotation = info.rotation;
            if (info.addUnderPlayer) {
                mapObjectId = (short)(Globals.g_world.game).AddMapObjectToFrontP1P2P3(0, (int)position.x, (int)position.y, ListType.e_RenderUnderPlayer);
            }
            else {
                if ((int)type == (int) FlowerHeadType.kFlowerHead_Apple) {
                    mapObjectId = (short)(Globals.g_world.game).AddMapObjectToFrontP1P2P3(0, (int)position.x, (int)position.y, ListType.e_RenderTrees);
                }
                else {
                    mapObjectId = (short)(Globals.g_world.game).AddMapObjectToFrontP1P2P3(0, (int)position.x, (int)position.y, ListType.e_RenderAbovePlayer);
                }

            }

            if (((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstStack) && ((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstCloud)) {
                shadowMapObjectId = (short)(Globals.g_world.game).AddMapObjectP1P2P3(0, (int)position.x, (int)position.y, ListType.e_Shadows);
			}

            if ((mapObjectId == -1) || (shadowMapObjectId == -1)) {
                this.SetState( FlowerHeadState.e_Inactive);

				Debug.Log ("NO DICE");
				
				return;
            }

			
			
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAtlas(Globals.g_world.game.gameThingsAtlas);
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetType( MapObjectType.e_FlowerHead);
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetObjectId(myId);
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetRotation(rotation);
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetRotationScale(rotationScale);
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetHeight(height);
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetHasBeenDisplayed();
            if (((int)type == (int) FlowerHeadType.kFlowerHead_Lilac) || ((int)type == (int) FlowerHeadType.kFlowerHead_Pink)) {
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAlpha(0.7f);
            }

            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId(flowerSubTextureStart + currentAnim);
            if (((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstStack) && ((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstCloud)) 
			{
	            ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetAtlas(Globals.g_world.game.gameThingsAtlas);
				((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetSubTextureId(shadowSubTextureStart + currentShadowAnim);
                if ((int)type == (int) FlowerHeadType.kFlowerHead_Apple) {
                    ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetRotation(-0.65f);
                }
                else {
                    ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetRotation(rotation);
                }

                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetRotationScale(rotationScale);
				
				float trueRotScale = Globals.g_world.game.gameThingsAtlas.GetSubTextureRotationScale( ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).subTextureId);
				
                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetScale(rotationScale / trueRotScale);
            }

        }

        public void Reset()
        {
            this.SetState( FlowerHeadState.e_Inactive);
            this.SetupAnimations();
        }

        public void UpdateOnGround()
        {
            velocity.x *= 0.95f;
            velocity.y *= 0.95f;
            position.x += velocity.x;
            position.y += velocity.y;
            this.UpdateShadow();
        }

        public void MapObjectRemoved()
        {
            this.SetState( FlowerHeadState.e_Inactive);
        }

        public void UpdateRotation(bool onGround)
        {
            if (((int)type == (int) FlowerHeadType.kFlowerHead_Welly) || ((int)type == (int) FlowerHeadType.kFlowerHead_Daffodil) || ((int)type == (int) FlowerHeadType.
              kFlowerHead_BushFragment) || ((int)type == (int) FlowerHeadType.kFlowerHead_Tulip) || ((int)type == (int) FlowerHeadType.kFlowerHead_TulipWhite) || ((int)type ==
              (int) FlowerHeadType.kFlowerHead_TulipBlue) || ((int)type == (int) FlowerHeadType.kFlowerHead_TulipYellow) || ((int)type == (int) FlowerHeadType.
              kFlowerHead_PumpkinPiece) || ((int)type == (int) FlowerHeadType.kFlowerHead_SquashPiece) || ((int)type == (int) FlowerHeadType.kFlowerHead_CourgettePiece))
              {
                if (onGround) {
                    float slowDownSpinSpeed;
                    if (((int)type == (int) FlowerHeadType.kFlowerHead_Tulip) || ((int)type == (int) FlowerHeadType.kFlowerHead_TulipWhite) || ((int)type == (int)
                      FlowerHeadType.kFlowerHead_TulipBlue) || ((int)type == (int) FlowerHeadType.kFlowerHead_TulipYellow)) {
                        slowDownSpinSpeed = 0.012f;
                    }
                    else {
                        slowDownSpinSpeed = 0.006f;
                    }

                    spinSpeed = Utilities.ApproachP1P2(spinSpeed, 0.0f, slowDownSpinSpeed);
                }

                rotation += spinSpeed;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetRotation(rotation);
                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetRotation(rotation);
            }

        }

        public void SwapToOnFloorImage()
        {
            int onFloorId = -1;
            switch (type) {
            case FlowerHeadType.kFlowerHead_SquashPiece :
                onFloorId = (int)World.Enum2.kGTMud_SquashPieceOnFloor;
                break;
            case FlowerHeadType.kFlowerHead_PumpkinPiece :
                onFloorId = (int)World.Enum2.kGTMud_PumpkinPieceOnFloor;
                break;
            case FlowerHeadType.kFlowerHead_CourgettePiece :
                onFloorId = (int)World.Enum2.kGTMud_CourgettePieceOnFloor;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId(onFloorId);
            ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetFlaggedToRemoveNextFrame(true);
        }

        public void PlayBounceSound()
        {
            if ((int)type == (int) FlowerHeadType.kFlowerHead_Apple) {
                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_AppleDrop, Utilities.GetRandBetweenP1(0.5f, 0.9f));
            }

        }

        public void UpdateActive()
        {
            animTimer += Constants.kFrameRate;
            if (animTimer >= spinSpeed) {
                animTimer = 0;
                currentAnim++;
                if ((int)type == (int) FlowerHeadType.kFlowerHead_BushExplosion) {
                    if (currentAnim == 3) {
                        scale = 2.0f;
                        ((Globals.g_world.game).GetMapObject(mapObjectId)).SetScale(scale);
                    }

                }

                if (currentAnim >= numFlowerAnims) {
                    if (((int)type != (int) FlowerHeadType.kFlowerHead_BushExplosion) && ((int)type != (int) FlowerHeadType.kFlowerHead_HayBurst) && ((int)type != (int)
                      FlowerHeadType.kFlowerHead_HayBurstStack) && ((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstCloud)) {
                        currentAnim = 0;
                    }
                    else {
                        currentAnim = (short)(numFlowerAnims - 1);
                    }

                }

                currentShadowAnim++;
                if (currentShadowAnim >= numShadowAnims) currentShadowAnim = 0;

                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId(flowerSubTextureStart + currentAnim);
                if (((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstStack) && ((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstCloud)) {
                    ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetSubTextureId(shadowSubTextureStart + currentShadowAnim);
                }

                if ((int)type == (int) FlowerHeadType.kFlowerHead_GnomePiece) {
                    rotationScale = (Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass)).GetSubTextureRotationScale(flowerSubTextureStart + currentAnim);
                    ((Globals.g_world.game).GetMapObject(mapObjectId)).SetRotationScale(rotationScale);
                }

            }

            if ((int)type == (int) FlowerHeadType.kFlowerHead_BushExplosion) {
                const float kBushFadeSpeed = 0.0225f;
                const float kScaleUpShadowSpeed = 0.0225f;
                alpha -= kBushFadeSpeed;
                scale += kScaleUpShadowSpeed;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAlpha(alpha);
                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetAlpha(alpha);
                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetScale(scale);
            }
            else if ((int)type == (int) FlowerHeadType.kFlowerHead_HayBurstStack) {
                const float kBushFadeSpeed = 0.04f;
                const float kScaleUpShadowSpeed = 0.018f;
                alpha -= kBushFadeSpeed;
                scale += kScaleUpShadowSpeed;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAlpha(alpha);
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetScale(scale);
                velocity.x *= 0.85f;
                velocity.y *= 0.85f;
            }
            else if ((int)type == (int) FlowerHeadType.kFlowerHead_HayBurst) {
                const float kBushFadeSpeed = 0.028f;
                const float kScaleUpShadowSpeed = 0.0225f;
                alpha -= kBushFadeSpeed;
                scale += kScaleUpShadowSpeed;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAlpha(alpha);
                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetAlpha(alpha);
                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetScale(scale);
            }
            else if ((int)type == (int) FlowerHeadType.kFlowerHead_HayBurstCloud) {
                const float kBushFadeSpeed = 0.04f;
                const float kScaleUpShadowSpeed = 0.018f;
                alpha -= kBushFadeSpeed;
                scale += kScaleUpShadowSpeed;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAlpha(alpha);
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetScale(scale);
                velocity.x *= 0.85f;
                velocity.y *= 0.85f;
            }
            else if ((int)type == (int) FlowerHeadType.kFlowerHead_Bollard) {
                const float kBollardFadeSpeed = 0.1f;
                if (animTimer > 0.325f) {
                    alpha -= kBollardFadeSpeed;
                    ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAlpha(alpha);
                    ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetAlpha(alpha);
                }

            }
            else if ((int)type == (int) FlowerHeadType.kFlowerHead_Cauliflower) {
                const float kBollardFadeSpeed = 0.1f;
                if (animTimer > 0.4f) {
                    alpha -= kBollardFadeSpeed;
                    ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAlpha(alpha);
                    ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetAlpha(alpha);
                }

            }
            else if (((int)type == (int) FlowerHeadType.kFlowerHead_Lilac) || ((int)type == (int) FlowerHeadType.kFlowerHead_Pink)) {
                const float kPetalFadeSpeed = 0.01f;
                alpha -= kPetalFadeSpeed;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetAlpha(alpha);
                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetAlpha(alpha);
            }
            else if (((int)type == (int) FlowerHeadType.kFlowerHead_Apple) || ((int)type == (int) FlowerHeadType.kFlowerHead_GnomePiece)) {
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetHeight(height);
            }

            if ((int)type == (int) FlowerHeadType.kFlowerHead_Daffodil) {
                velocity.x *= 0.99f;
                velocity.y *= 0.99f;
            }
            else if (((int)type == (int) FlowerHeadType.kFlowerHead_Tulip) || ((int)type == (int) FlowerHeadType.kFlowerHead_TulipWhite) || ((int)type == (int) FlowerHeadType
              .kFlowerHead_TulipBlue) || ((int)type == (int) FlowerHeadType.kFlowerHead_TulipYellow)) {
                velocity.x *= 0.985f;
                velocity.y *= 0.985f;
            }
            else if ((int)type == (int) FlowerHeadType.kFlowerHead_BushFragment) {
                velocity.x *= 0.99f;
                velocity.y *= 0.99f;
            }
            else {
                velocity.x *= 0.993f;
                velocity.y *= 0.993f;
            }

            if (height <= 10) {
                velocity.x *= 0.97f;
                velocity.y *= 0.97f;
                if (((int)type == (int) FlowerHeadType.kFlowerHead_Apple) || ((int)type == (int) FlowerHeadType.kFlowerHead_GnomePiece)) {
                    velocity.x *= 0.97f;
                    velocity.y *= 0.97f;
                }
                else if (((int)type == (int) FlowerHeadType.kFlowerHead_Daffodil) || ((int)type == (int) FlowerHeadType.kFlowerHead_Tulip) || ((int)type == (int)
                  FlowerHeadType.kFlowerHead_BushFragment)) {
                    velocity.x *= 0.95f;
                    velocity.y *= 0.95f;
                }

            }

            position.x += velocity.x;
            position.y += velocity.y;
            height += upVelocity;
            upVelocity -= useGravity;
            this.UpdateShadow();
            this.UpdateHeightScale();
            float groundLevel = 0;
            if (height <= groundLevel) {
                if (splattable) {
                    velocity.x *= 0.1f;
                    velocity.y *= 0.1f;
                    height = groundLevel;
                    this.SetState( FlowerHeadState.e_OnGround);
                    spinSpeed *= 0.1f;
                    this.SwapToOnFloorImage();
                }
                else {
                    if (numBounces == 2) {
                        height = groundLevel;
                        this.SetState( FlowerHeadState.e_OnGround);
                        if (((int)type == (int) FlowerHeadType.kFlowerHead_Bollard) || ((int)type == (int) FlowerHeadType.kFlowerHead_Cauliflower)) {
                            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetFlaggedToRemoveNextFrame(true);
                        }

                    }
                    else {
                        this.PlayBounceSound();
                        if (numBounces == 0) {
                            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetFlaggedToSwapbackwardNextFrame(true);
                        }

                        upVelocity = -upVelocity * 0.3f;
                        height = groundLevel;
                        numBounces++;
                    }

                }

            }

        }

        public void Update()
		{
//        Debug.Log("UpdateFH " + myId.ToString());
            switch (state) {
            case FlowerHeadState.e_Active :
                this.UpdateRotation(false);
                this.UpdateActive();
                break;
            case FlowerHeadState.e_OnGround :
                this.UpdateOnGround();
                this.UpdateRotation(true);
                break;
            default :
                break;
            }

            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(position);
            if (((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstStack) && ((int)type != (int) FlowerHeadType.kFlowerHead_HayBurstCloud)) {
                ((Globals.g_world.game).GetMapObject(shadowMapObjectId)).SetPosition(shadowPosition);
            }

        }

        public void UpdateHeightScale()
        {
            if (((int)type != (int) FlowerHeadType.kFlowerHead_Lilac) && ((int)type != (int) FlowerHeadType.kFlowerHead_Pink) && ((int)type != (int) FlowerHeadType.
              kFlowerHead_Welly) && ((int)type != (int) FlowerHeadType.kFlowerHead_Bucket) && ((int)type != (int) FlowerHeadType.kFlowerHead_Bollard) && ((int)type != (int)
              FlowerHeadType.kFlowerHead_Cauliflower) && ((int)type != (int) FlowerHeadType.kFlowerHead_Daffodil) && ((int)type != (int) FlowerHeadType.
              kFlowerHead_BushFragment) && ((int)type != (int) FlowerHeadType.kFlowerHead_Tulip) && ((int)type != (int) FlowerHeadType.kFlowerHead_TulipWhite) && ((int)type !=
              (int) FlowerHeadType.kFlowerHead_TulipBlue) && ((int)type != (int) FlowerHeadType.kFlowerHead_TulipYellow) && ((int)type != (int) FlowerHeadType.
              kFlowerHead_PumpkinPiece) && ((int)type != (int) FlowerHeadType.kFlowerHead_CourgettePiece) && ((int)type != (int) FlowerHeadType.kFlowerHead_SquashPiece))
              {
                return;
            }

            float kHeightScaleRatio = 0.005f;
            if ((int)type == (int) FlowerHeadType.kFlowerHead_Welly) {
                kHeightScaleRatio = 0.0025f;
            }
            else if (((int)type == (int) FlowerHeadType.kFlowerHead_Daffodil) || ((int)type == (int) FlowerHeadType.kFlowerHead_BushFragment)) {
                kHeightScaleRatio = 0.0025f;
            }
            else if (((int)type == (int) FlowerHeadType.kFlowerHead_Tulip) || ((int)type == (int) FlowerHeadType.kFlowerHead_TulipWhite) || ((int)type == (int) FlowerHeadType
              .kFlowerHead_TulipYellow) || ((int)type == (int) FlowerHeadType.kFlowerHead_TulipBlue)) {
                kHeightScaleRatio = 0.001f;
            }

            const float groundLevel = 0;
            float newScale = 1.0f + ((height - groundLevel - 10.0f) * kHeightScaleRatio);
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetRotationScale(rotationScale * newScale);
        }

        public void UpdateShadow()
        {
            const float kShadowHeightRatio = 0.455f;
            const float kShadowHeightRatioX = 1.04f;
            const float groundLevel = 0;
            float shadowHeight = (height - groundLevel) + 2;
            if ((int)type == (int) FlowerHeadType.kFlowerHead_Apple) {
                shadowHeight /= 5.4f;
            }
            else if ((int)type == (int) FlowerHeadType.kFlowerHead_GnomePiece) {
                shadowHeight /= 5.4f;
            }

            shadowPosition = Utilities.CGPointMake((position.x + (shadowHeight * kShadowHeightRatioX)), position.y + (shadowHeight * kShadowHeightRatio));
        }

    }
}
