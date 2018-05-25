using UnityEngine;
using System.Collections;
using System;


namespace Default.Namespace
{

    public enum  Texture2D_RossPixelFormat {
        t_Automatic = 0,
        t_RGBA8888,
        t_RGB565,
        t_RGBA5551,
        t_RGBA4444,
        t_A8
    }

	public enum  UIDevicePlatform{
		UIDevice1GiPod,
		UIDevice2GiPod,
		UIDevice3GiPhone,
		UIDevice1GiPhone,
		UIDeviceUnknown,
		UIDeviceUnknowniPod,

	};

	public struct UIAcceleration{
		public float x;
		public float y;
		public float z;
	};
	
	public enum  UITextAlignment{
		UITextAlignmentCenter,
		UITextAlignmentLeft,
		UITextAlignmentRight
	};
	
	public struct CGSize{
		public float Width;
		public float Height;
	};

	public struct CGPoint{
		public float x;
		public float y;
	};

	public struct CGRect{
		public CGPoint Origin;
		public CGSize Size;
	};


public class Texture2D_Ross {

			public int[] storedVertices = new int[8];
		public UnityEngine.Material myMaterial;
		public int pixelsHigh;
		public int pixelsWide;
		
//		public Billboard myBillboard;		

        public void Dealloc()
        {
//			if (myBillboard != null)
//			{
				//myBillboard.Dealloc();
				//myBillboard = null;
			//}
			if (myMaterial != null)
			{
				Resources.UnloadAsset(myMaterial.mainTexture);
				
//				GameObject.Destroy(myMaterial);
			//	GameObject.DestroyImmediate(myMaterial.mainTexture,true);
				
				//release the texture
				myMaterial.mainTexture = null;

				//and the material
				myMaterial = null;

				//hopefully...
			}			
        }
		
		public void SetTextureForADC(UnityEngine.Texture inTex)
		{
			myMaterial.mainTexture = inTex;	
	
			Globals.Assert(myMaterial.mainTexture != null);
			pixelsWide = (int)myMaterial.mainTexture.width;
			pixelsHigh = (int)myMaterial.mainTexture.height;
		}

				public Texture2D_Ross(MeshRenderer meshR)
				{		
						myMaterial=meshR.sharedMaterial;	
				}

        public Texture2D_Ross(bool canScale, string nameString, bool withTransparency, int assetId, LoadADCQueue.AssetType inType)
        {		
			if (!withTransparency)
			{
				myMaterial = new UnityEngine.Material(Shader.Find( "Pi/OpaqueOverlay" ));
			}
			else
			{
				myMaterial = new UnityEngine.Material(Shader.Find( "Pi/TransparentOverlay" ));
			}
			
			string tempString;
			
			tempString = Default.Namespace.Globals.g_main.GetFolderPrefixForTextureResolution() + System.IO.Path.GetFileNameWithoutExtension(nameString) + Default.Namespace.Globals.g_main.GetSuffixForTextureResolution();
			
			Debug.Log ("InitTexture2D with : " + tempString);

			UnityEngine.Color tempC = new UnityEngine.Color();
			tempC.a=1.0f;
			tempC.r=1.0f;
			tempC.g=1.0f;
			tempC.b=1.0f;
			myMaterial.color = tempC;
			
//			Texture tempTexture =  Resources.Load(tempString, typeof(Texture2D)) as Texture;
			
			
			if (false)//(Constants.ANDROID_25) && (Globals.g_main.loadADCQueue.state == LoadADCQueue.State.kStateBuildingUpAssetList))
			{
				LoadADCQueue.AssetInfo assetInfo = new LoadADCQueue.AssetInfo();
				assetInfo.assetType = inType;
				assetInfo.assetId = assetId;
				assetInfo.name = nameString;

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

				Globals.Assert(myMaterial.mainTexture != null);
				pixelsWide = (int)myMaterial.mainTexture.width;
				pixelsHigh = (int)myMaterial.mainTexture.height;
	
				Debug.Log("Texture loaded " + myMaterial.mainTexture.ToString() + " w:" + pixelsWide.ToString() + " h:" + pixelsHigh.ToString());
			}		
			
			
/*	        myBillboard = new Billboard("texture_" + nameString);			
			myBillboard.LoadAndSetMaterial(nameString,withTransparency);			
            myBillboard.rotationScale = 0.5f * Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), Utilities.CGPointMake(myBillboard.height,myBillboard.width));

			float thing = myBillboard.height / myBillboard.width;
            myBillboard.rotationAngle1 = Constants.HALF_PI - (float)Math.Atan(thing);
            myBillboard.rotationAngle2 = Constants.PI_ - (myBillboard.rotationAngle1 * 2.0f);
			*/
        }

 
        public void ScaleVerts(int vertSize)
        {
            storedVertices[0] = -vertSize;
            storedVertices[1] = -vertSize;
            storedVertices[2] = vertSize;
            storedVertices[3] = -vertSize;
            storedVertices[4] = -vertSize;
            storedVertices[5] = vertSize;
            storedVertices[6] = vertSize;
            storedVertices[7] = vertSize;
        }

        public void ScaleVertsXYP1(int vertSizeX, int vertSizeY)
        {

            #if PLAY_HORIZONTAL
                storedVertices[0] = -vertSizeX;
                storedVertices[1] = -vertSizeY;
                storedVertices[2] = vertSizeX;
                storedVertices[3] = -vertSizeY;
                storedVertices[4] = -vertSizeX;
                storedVertices[5] = vertSizeY;
                storedVertices[6] = vertSizeX;
                storedVertices[7] = vertSizeY;
            #else
                storedVertices[0] = -vertSizeX;
                storedVertices[1] = -vertSizeY;
                storedVertices[2] = vertSizeX;
                storedVertices[3] = -vertSizeY;
                storedVertices[4] = -vertSizeX;
                storedVertices[5] = vertSizeY;
                storedVertices[6] = vertSizeX;
                storedVertices[7] = vertSizeY;
            #endif

        }

        public void SetCoordinates(float[,] inArray)
        {
            for (int i = 0; i < 8; i++) {
//                storedCoordinates[i] = inArray[i];
            }

        }
		
		public void StopRender()
		{
			//if (myBillboard != null)
			//	myBillboard.StopRender();
		}	

		
        public void DrawAtPointScaledAlphaP1(float scale, float inAlpha)
        {
        }

        public void Bind()
        {
        }

        public void DrawAtPointScaledAlphaAdditiveP1(float scale, float inAlpha)
        {
        }

        public void DrawAtPointScaled(float scale)
        {
        }

        public void DrawAtPointScaledWithColourAlphaP1P2P3(CGPoint inPos, float scaleX, float scaleY, float rotation, Constants.RossColour inCol, float inAlpha)
        {
//			myBillboard.RenderAtPosition(inPos,scaleX,rotation,inAlpha,-1);
        }

		public void DrawAtPointScaledWithColourAlphaP1P2P3(Billboard useB, CGPoint inPos, float scaleX, float scaleY, float rotation, Constants.RossColour inCol, float inAlpha)
        {
			useB.RenderAtPosition(inPos,scaleX,rotation,inAlpha,-1);
        }

        public void DrawAtPointColour(Constants.RossColour inCol)
        {
        }

        public void DrawAtPoint()
        {
        }

        public void DrawAtPoint(CGPoint point)
        {
//			myBillboard.RenderAtPosition(point,1.0f,0.0f,1.0f,-1);
        }

        public void DrawAtPointAndScaleP1(CGPoint point, float inScale)
        {
        }

        public void AdjustInPosForIPad (CGPoint inPos)
		{
			if (Globals.deviceIPad) 
			{
								inPos.x *= 2.0f;
								inPos.y *= 2.0f;
								inPos.x += 64.0f;
//                inPos.y = g_world.tileMapHeight - inPos.Y;
						} else {
								//              inPos.y = g_world.tileMapHeight - inPos.Y;
						}

        }

        public void DrawAtPointScaleAndRotateP1P2(CGPoint point, float inScale, float rotation)
        {

        }

        public void DrawAtPointNoVertShorts(CGPoint point)
        {
        }

        public void DrawAtPointAlpha(float inAlpha)
        {
        }

        public void DrawAtPointAlphaAdditive(float inAlpha)
        {
        }

        public void DrawAtPointxyScaled(CGPoint xyscale)
        {
        }

        public void DrawInRectColourP1(CGRect rect, Constants.RossColour inCol)
        {
        }

        public void DrawInRect(CGRect rect)
        {
//			myBillboard.RenderInRect(rect,1.0f);
        }

        public void DrawInRectWithoutShorts(CGRect rect)
        {
        }
		
        public void DrawInRectAlphaP1(CGRect rect, float inAlpha)
        {
//			myBillboard.RenderInRect(rect,inAlpha);			
        }		
		
        public void DrawInRectAlphaP1(Billboard useB, CGRect rect, float inAlpha)
        {
			useB.RenderInRect(rect,inAlpha);			
        }

        public void DrawInRectTexScrollP1P2(CGRect rect, float ySize, float yScroll)
        {
        }

		public Texture2D GetTexture2D ()
		{
			return null;
		}
	}
}
