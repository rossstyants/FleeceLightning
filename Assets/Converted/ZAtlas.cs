using UnityEngine;
using System;
using System.Collections.Generic;

namespace Default.Namespace
{
    public class ZAtlas
    {
		public int myId;
        public float[,] storedCoordinates = new float[(int)Enum.kMaxTexturesPerAtlas, 8];
        public float[,] storedVertices = new float[(int)Enum.kMaxTexturesPerAtlas, 8];
        public int gridSize;
        public float halfGridSize;
        public int numTextures;
     //   public Texture2D texture;
				public UnityEngine.Material myMaterial;

				//just for tilemaps
				public UnityEngine.Material myMaterialTransparent;

				public UnityEngine.Material myMaterialAdditive;
		public UnityEngine.Material[] myMaterialWithColour = new UnityEngine.Material[(int)AtlasColours.kNum];
		
		public int lastUsedSubTexture;
        public float[] stWidth = new float[(int)Enum.kMaxTexturesPerAtlas];
        public float[] stHeight = new float[(int)Enum.kMaxTexturesPerAtlas];
        public int[,] minUV = new int[(int)Enum.kMaxTexturesPerAtlas, 2];
        public int[,] maxUV = new int[(int)Enum.kMaxTexturesPerAtlas, 2];
        public float[] rotationScale = new float[(int)Enum.kMaxTexturesPerAtlas];
        public float[] rotationAngle1 = new float[(int)Enum.kMaxTexturesPerAtlas];
        public float[] rotationAngle2 = new float[(int)Enum.kMaxTexturesPerAtlas];
        public World myWorld;
        public enum Enum {
            kMaxTexturesPerAtlas = 256
        };
		public enum AtlasColours
	{
		kRed = 0,
		kWhite,
		kLightGreen,
		kLilac,
		kLightBlue,
		kGreenMenuBack,
		kGreenMenuBackRays,
		kYellow,
		kPink,
		kPurpleMenuBack,
		kDarkBlue,
		kNum
	};

//		public void SetTexture2D* texture(T inThing) {Texture2D_Ross texture = inThing;}/@property(readwrite,assign) Texture2D*	texture;


        public void initAtlasWithString(World inWorld, bool canScale, int inGridSizeX, int inGridSizeY, List<int> inGridArray, string inName, Texture2D_RossPixelFormat forceType
          )
        {
           this.initAtlasWithString_IsDropbox(inWorld, canScale, inGridSizeX, inGridSizeY, inGridArray, inName, forceType, false, -1);
        }

		public ZAtlas(int enumId)
		{
			myId = enumId;
		}
		
		//doesn't happen...
		public void Dealloc()
		{
			if (myMaterial != null)
			{
//				GameObject.Destroy(myMaterial);
			//	GameObject.DestroyImmediate(myMaterial.mainTexture,true);
				
				Resources.UnloadAsset(myMaterial.mainTexture);
				
				
				//release the texture
				myMaterial.mainTexture = null;
								myMaterialAdditive.mainTexture = null;
								myMaterialTransparent.mainTexture = null;
				for (int i = 0; i < (int)AtlasColours.kNum; i++)
				{
					
				}
				
				//and the material
				myMaterial = null;
					myMaterialAdditive = null;
								myMaterialTransparent = null;
				//hopefully...
			}
		}

        public void initAtlasWithString_IsDropbox(World inWorld, bool canScale, int inGridSizeX, int inGridSizeY, List<int> inGridArray, string inName, Texture2D_RossPixelFormat forceType
          , bool isDropbox, int tempFileId)
		{
			//if (!base.init()) return null;

			myWorld = inWorld;
			gridSize = (short)inGridSizeX;
			halfGridSize = (float)inGridSizeX / 2.0f;
			//Globals.Assert (myMaterial == null);
			lastUsedSubTexture = -1;

//			if (inWorld == null) {
			
//			myMaterial = new UnityEngine.Material(Shader.Find( "Transparent/Diffuse" ));
			
			if (forceType == Texture2D_RossPixelFormat.t_RGB565)
			{
			//	myMaterial = new UnityEngine.Material(Shader.Find( "Diffuse" ));
		//		myMaterial = new UnityEngine.Material(Shader.Find( "Mobile/Unlit (Supports Lightmap)" ));
				//myMaterial = new UnityEngine.Material(Shader.Find( "Custom/SimpleOpaque" ));
				myMaterial = new UnityEngine.Material(Shader.Find( "Pi/OpaqueOverlay" ));
//				myMaterial = new UnityEngine.Material(Shader.Find( "Pi/TransparentOverlay" ));		
				//beacuse of bridge sprite and render order 
			}
			else
			{
		//		myMaterial = new UnityEngine.Material(Shader.Find( "Unlit/Transparent" ));
	//			myMaterial = new UnityEngine.Material(Shader.Find( "Transparent/VertexLit" ));
	//			myMaterial = new UnityEngine.Material(Shader.Find( "Custom/SimpleAlpha" ));
				myMaterial = new UnityEngine.Material(Shader.Find( "Pi/TransparentOverlay" ));
		//		myMaterial = new UnityEngine.Material(Shader.Find( "Pi/TransparentNoAlpha" ));
			}

						myMaterialAdditive = new UnityEngine.Material(Shader.Find( "Pi/Additive" ));
						myMaterialTransparent = new UnityEngine.Material(Shader.Find( "Pi/TransparentOverlay" ));
			
			string tempString;
			
			tempString = Default.Namespace.Globals.g_main.GetFolderPrefixForTextureResolution() + System.IO.Path.GetFileNameWithoutExtension(inName) + Default.Namespace.Globals.g_main.GetSuffixForTextureResolution();
			
			Debug.Log ("InitAtlas with : " + tempString);
			
//				texture = Resources.Load(tempString, typeof(Texture2D)) as Texture2D;	
			
			UnityEngine.Color tempC = new UnityEngine.Color();
			tempC.a=1.0f;
			tempC.r=1.0f;
			tempC.g=1.0f;
			tempC.b=1.0f;
			myMaterial.color = tempC;
			
//			Texture tempTexture =  Resources.Load(tempString, typeof(Texture2D)) as Texture;
			
			bool doingADCThing = false;
			
			if (false)//(Constants.ANDROID_25) && (Globals.g_main.loadADCQueue.state == LoadADCQueue.State.kStateBuildingUpAssetList))
			{
				doingADCThing = true;
				
				LoadADCQueue.AssetInfo assetInfo = new LoadADCQueue.AssetInfo();
				assetInfo.assetType = LoadADCQueue.AssetType.kAtlas;
				assetInfo.assetId = myId;
				assetInfo.name = inName;

//				Default.Namespace.Globals.g_main.loadADCQueue.AddAssetToList(assetInfo);
			}
			else
			{
				if (Default.Namespace.Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
				{
					if (Constants.ANDROID_25)
					{
						//loading something not using the list thing...
//						Globals.Assert(false);
					}
				}

				myMaterial.mainTexture = Resources.Load(tempString, typeof(Texture2D)) as Texture;
			}
			
			
			if (!doingADCThing)
			{
								myMaterialAdditive.mainTexture = myMaterial.mainTexture;
								myMaterialTransparent.mainTexture = myMaterial.mainTexture;
				
				Globals.Assert(myMaterial.mainTexture != null);
			}			
			
			
				//myMaterial.shader = Shader.Find( "Transparent/Diffuse" );
		
//			texture
			
			//	Globals.Assert(texture != null);
				//				texture = new Texture2D_Ross(true, inName, false);/
//			}
  //          else {
    //            if (isDropbox) {
      //          }
        //        else {
          //          texture = myWorld.LoadTextureP1P2(canScale, inName, forceType);
            //    }

            //}

            if (inGridArray == null) 
				this.SetupAtlasP1(inGridSizeX, inGridSizeY, doingADCThing);
            else {
                this.SetupAtlasWithGridArray(inGridArray);
            }

            //return this;
        }
		
		public void SetTextureForADC(UnityEngine.Texture inTex)
		{
			myMaterial.mainTexture = inTex;
						myMaterialAdditive.mainTexture = myMaterial.mainTexture;
						myMaterialTransparent.mainTexture = myMaterial.mainTexture;
			
			AtlasType myType = (AtlasType)myId;
			Debug.Log("Texture has been set for ADC for ZAtlas " + myType.ToString() + " with w:" + myMaterial.mainTexture.width + " and h:" + myMaterial.mainTexture.height);			
		}
		
		public UnityEngine.Material ReturnColour(AtlasColours inColour, Constants.RossColour rossCol)
	{	
		if (myMaterialWithColour[(int)inColour] == null)
		{
			myMaterialWithColour[(int)inColour] = new UnityEngine.Material(Shader.Find( "Pi/OpaqueOverlay" ));		
			
			UnityEngine.Color tempC = new UnityEngine.Color();
			tempC.a=0.8f;
			tempC.r=rossCol.cRed;
			tempC.g=rossCol.cGreen;
			tempC.b=rossCol.cBlue;
		
			myMaterialWithColour[(int)inColour].color = tempC;
		}
		
		return myMaterialWithColour[(int)inColour];
	}
	
		public UnityEngine.Material GetColourAtlasMaterial(Constants.RossColour inColour)
		{
			return null;
/*			

	see TextureMesh

switch(inColour)
			{
			case Constants.kColourWhite:
				return this.ReturnColour(AtlasColours.kWhite,inColour);
			break;
			case Constants.kColourLightGreen:
				return this.ReturnColour(AtlasColours.kLightGreen,inColour);
			break;
			case Constants.kColourRed:
				return this.ReturnColour(AtlasColours.kRed,inColour);
			break;
			case Constants.kColourLilac:
				return this.ReturnColour(AtlasColours.kLilac,inColour);
			break;
			case Constants.kColourLightBlue:
				return this.ReturnColour(AtlasColours.kLightBlue,inColour);
			break;
			case Constants.kColourGreenMenuBack:
				return this.ReturnColour(AtlasColours.kGreenMenuBack,inColour);
			break;
			case Constants.kColourGreenMenuBackRays:
				return this.ReturnColour(AtlasColours.kGreenMenuBackRays,inColour);
			break;
			case Constants.kColourYellow:
				return this.ReturnColour(AtlasColours.kYellow,inColour);
			break;
			case Constants.kColourPink:
				return this.ReturnColour(AtlasColours.kPink,inColour);
			break;
			case Constants.kColourPurpleMenuBack:
				return this.ReturnColour(AtlasColours.kPurpleMenuBack,inColour);
			break;
			case Constants.kColourDarkBlue:
				return this.ReturnColour(AtlasColours.kDarkBlue,inColour);
			break;

			}*/
		}		

        public void initAtlasWithString(World inWorld, bool canScale, int inGridSizeX, int inGridSizeY, List<int> inGridArray, string inName)
        {
            this.initAtlasWithString(inWorld, canScale, inGridSizeX, inGridSizeY, inGridArray, inName, (int) Texture2D_RossPixelFormat.t_Automatic);
        }

        public void initAtlasWithString(World inWorld, bool canScale, int inGridSizeX, int inGridSizeY, List<int> inGridArray, string inName, int tempFileId)
        {
            this.initAtlasWithString_IsDropbox(inWorld, canScale, inGridSizeX, inGridSizeY, inGridArray, inName,  Texture2D_RossPixelFormat.t_Automatic,true, tempFileId);
        }

        public void initAtlasWithString(World inWorld, bool canScale, int inGridSizeX, int inGridSizeY, List<int> inGridArray, string inName, int tempFileId,
          Texture2D_RossPixelFormat forceType)
        {
            this.initAtlasWithString_IsDropbox(inWorld, canScale, inGridSizeX, inGridSizeY, inGridArray, inName, forceType, true, tempFileId);
        }
        public void ShrinkSubtextureP1 (int howMuch, int whichST)
		{
			Globals.Assert (whichST < (int)Enum.kMaxTexturesPerAtlas);
            int multip = (int) Constants.kScreenMultiplierForShorts;
            stWidth[whichST] -= (howMuch * 2 * multip);
            stHeight[whichST] -= (howMuch * 2 * multip);
            minUV[whichST, 0] += howMuch;
            minUV[whichST, 1] += howMuch;
            maxUV[whichST, 0] -= howMuch;
            maxUV[whichST, 1] -= howMuch;
        }

        public void ShiftSubtextureDownP1 (int howMuch, int whichST)
		{
			Globals.Assert (whichST < (int)Enum.kMaxTexturesPerAtlas);
            minUV[whichST, 1] += howMuch;
            maxUV[whichST, 1] += howMuch;
        }

        public float GetRotationAngleToSecondPoint(int whichST)
        {
            return rotationAngle2[whichST];
        }

        public float GetRotationAngleToFirstPoint(int whichST)
        {
            return rotationAngle1[whichST];
        }

        public float GetSubTextureRotationScale(int whichST)
        {
            return rotationScale[whichST];
        }

        public float GetSubTextureWidth (int whichST)
		{
			if (whichST < 0)
			{
				int ross = 0;
			}

			Globals.Assert(whichST < (int)Enum.kMaxTexturesPerAtlas);
			Globals.Assert(whichST >= 0);
			
            return stWidth[whichST];
        }

        public float GetSubTextureHeight(int whichST)
        {
            return stHeight[whichST];
        }

        public float GetSubTextureHeightPixels(int whichST)
        {
            return stHeight[whichST] * Constants.kScaleForShorts * 2.0f;
        }

        public float GetSubTextureWidthPixels(int whichST)
        {
            return stWidth[whichST] * Constants.kScaleForShorts * 2.0f;
        }

        public int GetMinUVP1(int whichST, int which)
        {
            return minUV[whichST, which];
        }

        public int GetMaxUVP1(int whichST, int which)
        {
            return maxUV[whichST, which];
        }


        public void SetupAtlasWithGridArray(List<int> inGridArray)
        {
            int inGridSize = (inGridArray[0]);
            int numObjects = (inGridArray[1]);

            int index = 2;
            for (int i = 0; i < numObjects; i++) {

                    float a = (((float) (inGridArray[index])) * (float) inGridSize);
                    float b = (((float) (inGridArray[index + 1])) * (float) inGridSize);
                    float c = (((float) (inGridArray[index + 2])) * (float) inGridSize);
                    float d = (((float) (inGridArray[index + 3])) * (float) inGridSize);
                    minUV[i, 0] = (short) a;
                    minUV[i, 1] = (short) b;
                    maxUV[i, 0] = (short) c;
                    maxUV[i, 1] = (short) d;

                index += 4;


                        stWidth[i] = 0.5f * (float)(maxUV[i, 0] - minUV[i, 0]);
                        stHeight[i] = 0.5f * (float)(maxUV[i, 1] - minUV[i, 1]);

                    stWidth[i] *= Constants.kScreenMultiplierForShorts;
                    stHeight[i] *= Constants.kScreenMultiplierForShorts;

               // if (Globals.deviceIPhone4) {
               //     stWidth[i] *= 0.5f;
                 //   stHeight[i] *= 0.5f;
               // }

                rotationScale[i] = Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), Utilities.CGPointMake(stWidth[i], stHeight[i]));
                float thing = stWidth[i] / stHeight[i];
                rotationAngle1[i] = Constants.HALF_PI - (float)Math.Atan(thing);
                rotationAngle2[i] = Constants.PI_ - (rotationAngle1[i] * 2.0f);
            }

            this.SetupVertices(1);
            this.SetupTextureCoordinates(0);
        }

        public void SetupAtlasP1 (int inGridSizeX, int inGridSizeY, bool doingADC)
		{
			float textureWidth;// = myMaterial.mainTexture.width;
			float textureHeight;// = myMaterial.mainTexture.height;
			
			if (doingADC)// Constants.ANDROID_25)
			{
				textureWidth = 2048.0f;
				textureHeight = 2048.0f;
			}
			else
			{
				textureWidth = myMaterial.mainTexture.width;
				textureHeight = myMaterial.mainTexture.height;
			}
			
			float xGridPixels = (float)textureWidth / (float)inGridSizeX;
			float yGridPixels = (float)textureHeight / (float)inGridSizeY;
			int xGridWidth = (int)(xGridPixels + 0.9f);
			int yGridHeight = (int)(yGridPixels + 0.9f);
			float xGrid = 1.0f / xGridPixels;
			float yGrid = 1.0f / yGridPixels;
			int i = 0;
			float temp_width = ((float)textureWidth) * xGrid;
			float temp_height = ((float)textureHeight) * yGrid;
			for (int y = 0; y < yGridHeight; y++) {
				for (int x = 0; x < xGridWidth; x++) {
					Globals.Assert (i < (int)Enum.kMaxTexturesPerAtlas);
                    storedCoordinates[i, 0] = 0 + ((float) x * xGrid);
                    storedCoordinates[i, 1] = yGrid + ((float) y * yGrid);
                    storedCoordinates[i, 2] = xGrid + ((float) x * xGrid);
                    storedCoordinates[i, 3] = yGrid + ((float) y * yGrid);
                    storedCoordinates[i, 4] = 0 + ((float) x * xGrid);
                    storedCoordinates[i, 5] = 0 + ((float) y * yGrid);
                    storedCoordinates[i, 6] = xGrid + ((float) x * xGrid);
                    storedCoordinates[i, 7] = 0 + ((float) y * yGrid);

                        minUV[i, 0] = (short) ((float) x * inGridSizeX);
                        minUV[i, 1] = (short) ((float) y * inGridSizeY);
                        maxUV[i, 0] = (short) ((float) x * inGridSizeX) + inGridSizeX;
                        maxUV[i, 1] = (short) ((float) y * inGridSizeY) + inGridSizeY;

                    float[] tempStoredVertices = new float[]
                    {-temp_width / 2, -temp_height / 2, temp_width / 2, -temp_height / 2, -temp_width / 2, temp_height / 2, temp_width / 2, temp_height / 2};
                    for (int v = 0; v < 8; v++) storedVertices[i, v] = tempStoredVertices[v];

                        stWidth[i] = ((float) inGridSizeX) / 2.0f;
                        stHeight[i] = ((float) inGridSizeY) / 2.0f;

                        stWidth[i] *= Constants.kScreenMultiplierForShorts;
                        stHeight[i] *= Constants.kScreenMultiplierForShorts;

                    if (Globals.deviceIPhone4) {
                        stWidth[i] *= 0.5f;
                        stHeight[i] *= 0.5f;
                    }

                    i++;
                }

            }

           // this.SetupVertices(1);
            //this.SetupTextureCoordinates(0);
        }

        public void SetupTextureCoordinates(int inSubtextureId)
        {
//            Globals.Assert(texture != null);
  //          lastUsedSubTexture = inSubtextureId;
    //        texture.SetCoordinates(storedCoordinates);
        }

        public void SetupVertices(float inScale)
        {
//            texture.ScaleVerts((int)(inScale * halfGridSize));
        }

        public void DrawAtPoint(int inSubtextureId)
        {
//            this.SetupTextureCoordinates(inSubtextureId);
//            texture.DrawAtPoint();
        }

        public void DrawAtPointScaledAlphaP1P2(int inSubtextureId, float scale, float inAlpha)
        {
//            this.SetupVertices(scale);
//            this.SetupTextureCoordinates(inSubtextureId);
//            texture.DrawAtPointAlpha(inAlpha);
        }

        public void DrawAtPointAlphaP1(int inSubtextureId, float inAlpha)
        {
//            this.SetupTextureCoordinates(inSubtextureId);
//            texture.DrawAtPointAlpha(inAlpha);
        }

        public void DrawAtPointScaledAlphaAdditiveP1P2(int inSubtextureId, float scale, float inAlpha)
        {
//            this.SetupVertices(scale);
//            this.SetupTextureCoordinates(inSubtextureId);
//            texture.DrawAtPointAlphaAdditive(inAlpha);
        }

    }
}
