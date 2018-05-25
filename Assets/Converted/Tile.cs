using UnityEngine;
using System;

namespace Default.Namespace
{
    public class Tile
    {
		Billboard myBillboard;
        public CGPoint screenPosition;
        public float scale;
        public bool spriteSubOneDeep;
        public int subTextureId;
        public int atlasId;
        public int spriteSubTextureId;
        public int spriteAtlasId;
        public int[] verticePositions = new int[8];
        public float Scale
        {
            get;
            set;
        }

        public int AtlasId
        {
            get;
            set;
        }

        public int SpriteSubTextureId
        {
            get;
            set;
        }

        public int SubTextureId
        {
            get;
            set;
        }

        public int SpriteAtlasId
        {
            get;
            set;
        }

        public bool SpriteSubOneDeep
        {
            get;
            set;
        }

public void SetScale(float inThing) 
		{
			scale = inThing;
			if (myBillboard != null)
				myBillboard.SetScale(inThing);
			
		}///@property(readwrite,assign) float scale;
public void SetAtlasId(int inThing) {atlasId = inThing;}///@property(readwrite,assign) int atlasId;
public void SetSpriteSubTextureId(int inThing) {spriteSubTextureId = inThing;}///@property(readwrite,assign) int spriteSubTextureId;
public void SetSubTextureId(int inThing) {subTextureId = inThing;}///@property(readwrite,assign) int subTextureId;	//-1 if this is not from an atlas
public void SetSpriteAtlasId(int inThing) {spriteAtlasId = inThing;}///@property(readwrite,assign) int spriteAtlasId;
public void SetSpriteSubOneDeep(bool inThing) {spriteSubOneDeep = inThing;}///@property(readwrite,assign) bool spriteSubOneDeep;
		
		public Tile(string description)
        {
			myBillboard = new Billboard("tile" + description);
		}

		public void SetupAtlas(int inAtlasId)
        {

			myBillboard.SetAtlas(Globals.g_world.GetAtlas(inAtlasId));
			myBillboard.SetDetailsFromAtlas(Globals.g_world.GetAtlas(inAtlasId),0);
//			myBillboard.myObject.isStatic = true;

//						Debug.Log("Tile setup ATLAS - tile SCALE " + myBillboard.myObject.transform.localScale);
//						Debug.Log("Tile setup ATLAS - tile width " + myBillboard.width);

		}
		
		public void SetToLayer(string inLayer)
		{
			myBillboard.myObject.layer = LayerMask.NameToLayer(inLayer);
		}
		
        public CGPoint GetScreenPosition()
        {
            return screenPosition;
        }

        public void SetScreenPosition(CGPoint inPos)
        {
            screenPosition = inPos;

						return;

            inPos.x *= Constants.kScreenMultiplierForShorts;
            inPos.y *= Constants.kScreenMultiplierForShorts;
            float wx = Constants.TILE_SIZE_HALF * Constants.kScreenMultiplierForShorts;
            float wy = wx;
            
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High) 
			{
                wx *= 2.0f;
                wy *= 2.0f;
				
				inPos.x *= 0.5f;
				inPos.y *= 0.5f;
            }

                verticePositions[0] = (int)(inPos.x - wx);
                verticePositions[1] = (int)(inPos.y + wy);
                verticePositions[2] = (int)(inPos.x - wx);
                verticePositions[3] = (int)(inPos.y - wy);
                verticePositions[4] = (int)(inPos.x + wx);
                verticePositions[5] = (int)(inPos.y + wy);
                verticePositions[6] = (int)(inPos.x + wx);
                verticePositions[7] = (int)(inPos.y - wy);

//			myBillboard.RenderAtPosition(inPos,1.0f,0.0f,1.0f,subTextureId);
			
        }

        public void AddToYPosition(float yAdd)
        {
            screenPosition.y += yAdd;
        }

        public void ApplyTextureP1P2P3P4P5(Texture2D_Ross inTex, int inSubId, int inAtlasId, int inSpriteSubId, int inSpriteAtlasId, bool inOneDeep)
        {
            subTextureId = inSubId;
			atlasId = inAtlasId;
            spriteSubTextureId = inSpriteSubId;
            spriteAtlasId = inSpriteAtlasId;
            spriteSubOneDeep = inOneDeep;
        }

        public void ApplyNewTextureP1P2P3P4(int inSubId, int inAtlasId, int inSpriteSubId, int inSpriteAtlasId, bool inOneDeep)
        {
            subTextureId = inSubId;
            atlasId = inAtlasId;
            spriteSubTextureId = inSpriteSubId;
            spriteAtlasId = inSpriteAtlasId;
            spriteSubOneDeep = inOneDeep;
        }

        public void RenderSceneOldWay()
        {
        }
		
		public void StopRender()
		{
			myBillboard.StopRender();
		}
		
		public void Render_ForTip(float inScale)
        {

			CGPoint renderPos = screenPosition;
			
			myBillboard.RenderAtPosition(renderPos,inScale,0.0f,1.0f,subTextureId);

			
//            (DrawManager.Instance()).AddTile(verticePositions);
        }

        public void RenderScene_WithBigDrawArrays(float xOffset)
        {
			//return;
			
			CGPoint renderPos = screenPosition;
			renderPos.x += xOffset;
			
//			myBillboard.RenderAtPosition(renderPos,1.0f,0.0f,1.0f,subTextureId);
			myBillboard.RenderTileAtPosition(renderPos,subTextureId);
			
//            (DrawManager.Instance()).AddTile(verticePositions);
        }

        public void RenderScene()
        {
        }

        public void RenderSceneLevelBuilder_Ross()
        {
            if (screenPosition.y > 503.0f) {
            }

			myBillboard.RenderAtPosition(screenPosition,scale,0.0f,1.0f,subTextureId);
			
            #if TEST_VERT_SHORTS
           //     (DrawManager.Instance()).AddTile(verticePositions);
            #else
            //    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(screenPosition, scale, 0, 0, 1, subTextureId);
            #endif

        }

    }
}
