using UnityEngine;
using System;

namespace Default.Namespace
{
    public enum  MapObjectType {
        e_Whatever,
        e_FlowerBunch,
        e_FlowerHead,
        e_WellyShadow,
        e_Tractor,
        e_FlockAnimal,
        e_CrossingThing,
        e_Cow,
        e_BoostPicnic,
        e_Veg,
        e_HayBale,
        e_Tree
    }
    public class MapObject
    {
		public Billboard myAtlasBillboard;
		
        public MapObjectType type;
        public int objectId;
        public int nextMapObject;
        public float height;
        public CGPoint position;
        public CGPoint mapObjectScreenPos;
        public float rotation;
        public float alpha;
        public float alphaSpeed;
        public float scale;
        public bool hasBeenDisplayed;
        public bool mapObjectGone;
        public bool isOnScreen;
        public bool flaggedToRemoveNextFrame;
        public bool flaggedToSwapbackwardNextFrame;
        public bool flaggedToSwapForwardNextFrame;
        public int listType;
        public int baseList;
        public int textureType;
        public Texture2D_Ross texture;
        public bool isSelfRemoving;
        public bool isSimpleObject;
        public int subTextureId;
        public ZAtlas atlas;
        public float rotationScale;
        public int TextureType
        {
            get;
            set;
        }

        public Texture2D_Ross Texture
        {
            get;
            set;
        }

        public CGPoint Position
        {
            get;
            set;
        }

        public float Rotation
        {
            get;
            set;
        }

        public float RotationScale
        {
            get;
            set;
        }

        public float Alpha
        {
            get;
            set;
        }

        public float AlphaSpeed
        {
            get;
            set;
        }

        public float Scale
        {
            get;
            set;
        }

        public bool IsOnScreen
        {
            get;
            set;
        }

        public int ListType
        {
            get;
            set;
        }

        public bool FlaggedToRemoveNextFrame
        {
            get;
            set;
        }

        public bool FlaggedToSwapbackwardNextFrame
        {
            get;
            set;
        }

        public bool FlaggedToSwapForwardNextFrame
        {
            get;
            set;
        }

        public int SubTextureId
        {
            get;
            set;
        }

        public ZAtlas Atlas
        {
            get;
            set;
        }

        public bool IsSelfRemoving
        {
            get;
            set;
        }

        public MapObjectType Type
        {
            get;
            set;
        }

        public int ObjectId
        {
            get;
            set;
        }

        public bool IsSimpleObject
        {
            get;
            set;
        }

        public float Height
        {
            get;
            set;
        }

        public int BaseList
        {
            get;
            set;
        }

		public void SetTextureType(int inThing) {textureType = inThing;}///@property(readwrite,assign) int textureType;
public void SetIsSelfRemoving(bool inThing) {isSelfRemoving = inThing;}///@property(readwrite,assign) bool isSelfRemoving;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetTexture(Texture2D_Ross inThing) {texture = inThing;}////@property(readwrite,assign) Texture2D* texture;
public void SetRotation(float inThing) {rotation = inThing;}///@property(readwrite,assign) float rotation;
public void SetRotationScale(float inThing) {rotationScale = inThing;}///@property(readwrite,assign) float rotationScale;
public void SetAlpha(float inThing) {alpha = inThing;}///@property(readwrite,assign) float alpha;
public void SetAlphaSpeed(float inThing) {alphaSpeed = inThing;}///@property(readwrite,assign) float alphaSpeed;
public void SetScale(float inThing) {scale = inThing;}///@property(readwrite,assign) float scale;
public void SetIsOnScreen(bool inThing) {isOnScreen = inThing;}///@property(readwrite,assign) bool isOnScreen;
public void SetFlaggedToRemoveNextFrame(bool inThing) {flaggedToRemoveNextFrame = inThing;}///@property(readwrite,assign) bool flaggedToRemoveNextFrame;
public void SetFlaggedToSwapbackwardNextFrame(bool inThing) {flaggedToSwapbackwardNextFrame = inThing;}///@property(readwrite,assign) bool flaggedToSwapbackwardNextFrame;
public void SetFlaggedToSwapForwardNextFrame(bool inThing) {flaggedToSwapForwardNextFrame = inThing;}///@property(readwrite,assign) bool flaggedToSwapForwardNextFrame;
public void SetListType(int inThing) {listType = inThing;}///@property(readwrite,assign) int listType;
public void SetBaseList(int inThing) {baseList = inThing;}///@property(readwrite,assign) int baseList;
//public void SetIsAtlas(bool inThing) {isAtlas = inThing;}///@property(readwrite,assign) bool isAtlas;

		
public void ResetMapObject() 
		{
			if (myAtlasBillboard != null)
			{
				myAtlasBillboard.Reset();
			}
		}		
		
		
		public void SetSubTextureId(int inThing) 
		{
			subTextureId = inThing;
			
			this.ResetMapObject();			
			
		}///@property(readwrite,assign) int subTextureId;
public void SetAtlas(ZAtlas inThing) 
		{
			atlas = inThing;
			
			//return;
			
			if (myAtlasBillboard == null)
			{
				myAtlasBillboard = new Billboard("mapObject_" + type.ToString() + "_atlas" + atlas.myId.ToString());
			}
			
			myAtlasBillboard.SetAtlas(atlas);
			myAtlasBillboard.SetDetailsFromAtlas(atlas,0);
		//	myAtlasBillboard.SetRenderQueue(9000);

			this.ResetMapObject();						
		}////@property(readwrite,assign) ZAtlas* atlas;
public void SetType(MapObjectType inThing) {type = inThing;}///@property(readwrite,assign) MapObjectType type;
public void SetObjectId(int inThing) {objectId = inThing;}///@property(readwrite,assign) int objectId;
public void SetIsSimpleObject(bool inThing) {isSimpleObject = inThing;}///@property(readwrite,assign) bool isSimpleObject;
public void SetHeight(float inThing) {height = inThing;}///@property(readwrite,assign) float height;



        public MapObject()
        {
            //if (!base.init()) return null;
			
			myAtlasBillboard = null;
            atlas = null;
            isSelfRemoving = true;
            //return this;
        }
		
		//What i think this means is that we will remove here any references we have to , for example, an atlas texture from the previous round...
		//thus allowing that texture to be deleted by the garbage collector...
        public void Dereference()
        {
			if (myAtlasBillboard != null)
			{
				myAtlasBillboard.Dealloc();
				myAtlasBillboard = null;
//				myAtlasBillboard = new Billboard();			
			}
        }
		
		
		public void StopRender()
        {
			if (myAtlasBillboard != null)
			{
				myAtlasBillboard.StopRender();
			}
		}
		
		public void SetToTileCamera(bool isTipThing)
		{
			if (myAtlasBillboard == null)
				return;
			
			if (isTipThing)
			{
				myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("tiles");
			}
			else
			{
				myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("Default");
			}
		}
		
        public CGPoint GetScreenPos()
        {
            return mapObjectScreenPos;
        }

        public bool HasLeftScreen()
        {
            return mapObjectGone;
        }

        public int GetTextureType()
        {
            return textureType;
        }

        public int GetNext()
        {
            return nextMapObject;
        }

        public void SetNext(int pNext)
        {
            nextMapObject = pNext;
        }

        public float GetRotation()
        {
            return rotation;
        }

        public void UpdateAlpha()
        {
            if (alphaSpeed > 0.0f) alpha -= alphaSpeed;

        }

        public void UpdateScreenPos(CGPoint inScrollPos)
        {

            #if RACE_UP
                mapObjectScreenPos = (Globals.g_world.game).GetScreenPosition(position);
            #else
                mapObjectScreenPos = (Globals.g_world.game).GetScreenPosition(position);
                if (type ==  MapObjectType.e_FlowerHead) {
                    mapObjectScreenPos.y += Utilities.GetYOffsetFromHeight(height);
                }

            #endif

        }

        public void UpdateScreenPosLevelBuilder_Ross(CGPoint inScrollPos)
        {
            mapObjectScreenPos = (Globals.g_world.game).GetScreenPosition(position);
            mapObjectScreenPos.y -= 251.0f;
            mapObjectScreenPos.x += 33.0f;
        }

        public bool HasBeenDisplayed()
        {
            return hasBeenDisplayed;
        }

        public void SetHasLeftScreen()
        {
            mapObjectGone = true;
            isOnScreen = false;
        }

        public void SetHasBeenDisplayed()
        {
            hasBeenDisplayed = true;
            isOnScreen = true;
        }

        public void AddToSceneP1P2P3(int inType, CGPoint mapPosition, float inRotation, float inAlpha)
        {
            isSimpleObject = false;
            isSelfRemoving = true;
            atlas = null;
            flaggedToRemoveNextFrame = false;
            flaggedToSwapbackwardNextFrame = false;
            flaggedToSwapForwardNextFrame = false;
            position = mapPosition;
            textureType = inType;
            texture = (Globals.g_world.game).GetTexture((TextureType)(TextureType) inType);
            mapObjectGone = false;
            isOnScreen = false;
            hasBeenDisplayed = false;
            rotation = inRotation;
            alpha = inAlpha;
            scale = 1;
            alphaSpeed = 0;
            subTextureId = -1;
            type = MapObjectType.e_Whatever;
        }

        public void AddToSceneP1(int inType, CGPoint mapPosition)
        {
            this.AddToSceneP1P2P3(inType, mapPosition, 0, 1);
        }

    }
}
