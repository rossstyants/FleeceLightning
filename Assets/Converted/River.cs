using System;
using UnityEngine;

namespace Default.Namespace
{
    public enum  RiverType {
        e_Country = 0,
        e_CrocRiver
    }
    public class FlowerCliff
    {
		public Billboard[] myAtlasBillboard = new Billboard[12];
		
		bool isBeingDrawn;
        public float yCliffStart;
        public float yCliffLength;
        public float xFlowerPosition;
        public float xWidth;
        public NoGoZone noGoStem;
        public RiverType riverType;
        public float raiseLength;
        public struct RiverInfo{
            public int xPosBridge;
            public int yPos;
            public int widthBridge;
            public int tileWidth;
            public RiverType riverType;
        };
        public float YCliffLength
        {
            get;
            set;
        }

        public float YCliffStart
        {
            get;
            set;
        }

        public float XFlowerPosition
        {
            get;
            set;
        }

        public NoGoZone NoGoStem
        {
            get;
			set;
        }

        public float XWidth
        {
            get;
            set;
        }

        public float RaiseLength
        {
            get;
            set;
        }

        public RiverType RiverType
        {
            get;
            set;
        }

public void SetYCliffStart(float inThing) {yCliffStart = inThing;}///@property(readwrite,assign) float yCliffStart;
public void SetYCliffLength(float inThing) {yCliffLength = inThing;}///@property(readwrite,assign) float yCliffLength;
public void SetXWidth(float inThing) {xWidth = inThing;}///@property(readwrite,assign) float xWidth;
public void SetXFlowerPosition(float inThing) {xFlowerPosition = inThing;}///@property(readwrite,assign) float xFlowerPosition;
public void SetRaiseLength(float inThing) {raiseLength = inThing;}///@property(readwrite,assign) float raiseLength;
public void SetRiverType(RiverType inThing) {riverType = inThing;}///@property(readwrite,assign) RiverType riverType;
public void SetNoGoStem(NoGoZone inThing) {noGoStem = inThing;}////@property(readonly) NoGoZone* noGoStem;

        public FlowerCliff()
        {
            //if (!base.init()) return null;

            noGoStem = new NoGoZone();
            //return this;
        }
		
		public void Dealloc()
		{
			for (int i = 0; i < 12; i++)
			{
				if (myAtlasBillboard[i] != null)
				{
					myAtlasBillboard[i].Dealloc();
					myAtlasBillboard[i] = null;
				}
			}
		}
		
        public void Initialise(RiverInfo info)
        {
			for (int i = 0; i < 12; i++)
			{
				if (myAtlasBillboard[i] == null)
					myAtlasBillboard[i] = new Billboard("river");

				myAtlasBillboard[i].StopRender();
				
				myAtlasBillboard[i].SetAtlas(Globals.g_world.GetAtlas((int) AtlasType.kAtlas_GrassTiles));
				
								myAtlasBillboard[i].myObject.GetComponent<Renderer>().sharedMaterial = Globals.g_world.GetAtlas((int) AtlasType.kAtlas_GrassTiles).myMaterialTransparent;

				//int tileSubtexture = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, bridgeX + x, bridgeY + y);
				
				myAtlasBillboard[i].SetDetailsFromAtlas(Globals.g_world.GetAtlas((int) AtlasType.kAtlas_GrassTiles),0);

								//
//								myAtlasBillboard[i].myObject.GetComponent<MeshRenderer>().sharedMaterial = Globals.g_main.grassSpriteAtlas;
//								Globals.g_main.grassSpriteAtlas.SetTexture("_MainTex",);
						}
			
			isBeingDrawn = false;
			
            riverType = info.riverType;
            if (false) {
                yCliffStart = (float) info.yPos - 32 + 94 - 15 - 40.0f;
                yCliffLength = (float)(340);
                raiseLength = 120.0f;
            }
            else {
                yCliffStart = (float) info.yPos - 32 + 60 - 15 - 40.0f;
                yCliffLength = (float)(400);
                raiseLength = 80.0f;
            }

            xFlowerPosition = (float) info.xPosBridge;
            xWidth = (float) info.widthBridge;
            CGPoint stemPosition = Utilities.CGPointMake(xFlowerPosition, yCliffStart + yCliffLength - 65.0f);
            if (xWidth == 128.0f) {
                if (xFlowerPosition == 320.0f) {
                    stemPosition.x -= 8.0f;
                }
                else if (xFlowerPosition == 64.0f) {
                    stemPosition.x += 8.0f;
                }

            }

            if (info.widthBridge == 64) noGoStem.InitialiseP1(stemPosition, 30);
            else noGoStem.InitialiseP1(stemPosition, 65);

            noGoStem.SetGroundLevel(-Game.kClifffDepth);
            noGoStem.SetType(NoGoType.e_Bridge);
        }

        public void RenderOtherBank()
        {
            return;
            CGPoint mapPos = Utilities.CGPointMake(xFlowerPosition, yCliffStart + (6 * 64));
            CGPoint screenPosition = Utilities.GetScreenPositionP1(mapPos, (Globals.g_world.GetGame()).GetScrollPosition());
            int xPlayerTile = ((Globals.g_world.game).player).xCurrentTile;
            screenPosition.x = -32 + (((float)(xPlayerTile)) * 64.0f);
            screenPosition.y -= 40.0f;
            for (int i = 0; i < 5; i++) {
                if (((i + 1) >= xPlayerTile) && ((i - 1) <= xPlayerTile)) {
                    (DrawManager.Instance()).AddTextureToListP1(screenPosition, 6);
                    screenPosition.x += 64;
                }

            }

        }
		
		public void StopRenderBridgeAsSprite()
        {
			if (isBeingDrawn)
			{
				for (int i = 0; i < 12; i++)
				{
					if (myAtlasBillboard[i] != null)
					{
						myAtlasBillboard[i].StopRender();
					}
				}					
				isBeingDrawn = false;
			}
		}
		
        public void RenderBridgeAsSprite()
        {
//						if (yCliffStart < 1000.0f)
//						{
//								int ross = 0;
//						}
//						Debug.Log("ycliff " + yCliffStart.ToString());

			float scrollY = (Globals.g_world.GetGame()).GetScrollPosition().y;
			
			if ((yCliffStart + 500.0f) < scrollY)
			{
				if (isBeingDrawn)
				{
					for (int i = 0; i < 12; i++)
					{
						if (myAtlasBillboard[i] != null)
						{
							myAtlasBillboard[i].StopRender();
						}
					}					
					isBeingDrawn = false;
				}

				return;
			}
			
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_GrassTiles));
            CGPoint mapPos = Utilities.CGPointMake(xFlowerPosition, yCliffStart);
            mapPos.x -= 32.0f;
            mapPos.y += 28.0f;
            CGPoint screenPosition = (Globals.g_world.game).GetScreenPosition(mapPos);
            int bridgeX = 12;
            int bridgeY = 0;
			int billboardId = 0;
			//isBeingDrawn = true;
  
			for (int x = 0; x < 2; x++) 
			{
                for (int y = 0; y < 6; y++) 
				{
                    int tileSubtexture = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, bridgeX + x, bridgeY + y);
                    CGPoint pos = Utilities.CGPointMake(screenPosition.x + ((float) x * 64.0f), screenPosition.y + ((float) y * 64.0f));
                    if ((Globals.g_world.game).IsOnScreenNewP1(pos, 50.0f)) 
//										if (true)
										{
						isBeingDrawn = true;
						
                        (DrawManager.Instance()).AddTextureToListP1(myAtlasBillboard[billboardId], pos, tileSubtexture,1.0f);
					}
					else
					{
						myAtlasBillboard[billboardId].StopRender();
					}
					billboardId++;				
				}

            }

            (DrawManager.Instance()).Flush();
        }

    }
}
