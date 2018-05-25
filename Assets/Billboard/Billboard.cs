using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (MeshCollider))]


public class Billboard{

	public Texture2D texture2D;
	//public Material rossMat;
	public float width;	
	public float height;
//	public float rotScaleNoAtlas;
	
	public GameObject myObject;
	
	Default.Namespace.ZAtlas myAtlas;
	Default.Namespace.Texture2D_Ross myTexture;
		
	UnityEngine.Color myColour;
	int currentSubtextureId;
	bool usingAlpha;
	float prevAlpha;
	
	Material materialForColourAndAlpha;
	
	public float rotationScale;
	public float rotationAngle1;
	public float rotationAngle2;
	public Default.Namespace.CGPoint localPosition;

	public float oldScale;
	
	public enum ShaderTypeEnum{
		
		kShader_Opaque,
		kShader_Transparent,
		kShader_Additive
		
	};

		int debugCounter;
	
	public Billboard(string description)
	{
		localPosition = new Default.Namespace.CGPoint();
		localPosition.x = 0.0f;
		localPosition.y = 0.0f;
		string whatAmI = "BillBoardGameObject_" + description;
		myObject = new GameObject(whatAmI);
		myObject.AddComponent<MeshFilter>();
		myObject.AddComponent<MeshRenderer>();
		myObject.GetComponent<Renderer>().enabled = false;
		
		myAtlas = null;
		myTexture = null;

		myColour.a = 1.0f;
		myColour.r = 1.0f;
		myColour.g = 1.0f;
		myColour.b = 1.0f;
		
		currentSubtextureId = -1;
		
		oldScale = -1.0f;
		usingAlpha = false;
		
		materialForColourAndAlpha = null;
		
		prevAlpha = -1.0f;
	}
	
	//bit of a shot in the dark but...
	//gets called just before object ref is set to null
	public void Dealloc()
	{
		if (myObject != null)
		{
//			Destroy(myObject);
//			Destroy(myObject);
			
//			myObject = null;
			
			if (myObject != null)
			{
			//	if (materialForColourAndAlpha != null)
			//		materialForColourAndAlpha.mainTexture = null;
	
			//	Debug.Log ("Dealloc BBsm - " + myObject.GetComponent<MeshRenderer>().sharedMaterial.mainTexture.ToString());
			//	Debug.Log ("Dealloc BBm - " + myObject.GetComponent<MeshRenderer>().material.mainTexture.ToString());
				
		//		GameObject.Destroy(myObject.GetComponent<MeshRenderer>().sharedMaterial);
		//		GameObject.Destroy(myObject.GetComponent<MeshRenderer>().material);
		//		GameObject.Destroy(myObject.GetComponent<MeshRenderer>());
		//		GameObject.Destroy(myObject.GetComponent<MeshFilter>().sharedMesh);
		//		GameObject.Destroy(myObject.GetComponent<MeshFilter>().mesh);
		//		GameObject.Destroy(myObject.GetComponent<MeshFilter>());
		
				//GameObject.Destroy(myObject);
				myObject = null;
	//			myObject = new GameObject("BillBoardGameObject");
				//myObject.AddComponent<MeshFilter>();
				//myObject.AddComponent<MeshRenderer>();
				//myObject.renderer.enabled = false;
			}
		}
	}
	
	
	public float pixelsWide()
	{
		return width;
	}
	public float pixelsHigh()
	{
		return height;
	}
	public void SetCoordinates(float[,] inCoords, int inSubtextureId)
	{
	}
	public void ScaleVerts(float inScale)
	{
	}
	
	public void CheckRender()
	{
		if (!myObject.GetComponent<Renderer>().enabled)
		{
			myObject.GetComponent<Renderer>().enabled = true;
		}
	}

	public void StopRender()
	{
		if (myObject != null)
			myObject.GetComponent<Renderer>().enabled = false;
	}	
	
	public void SetHeightAndWidth(float x, float y)//, MeshFilter mf, MeshRenderer meshRenderer)
	{
//		Debug.Log ("billboard set h: " + x.ToString() + "w:"+ y.ToString());
		
		height = x;
		width = y;
		
//		MeshFilter mf = new MeshFilter();// GetComponent<MeshFilter>();
		MeshFilter mf = myObject.GetComponent<MeshFilter>();
		
		Mesh mesh;
		
		if (mf.sharedMesh == null)
		{
			mesh = new Mesh();
		}
		else
		{
			mesh = mf.sharedMesh;
		}
	
		Vector3[] vertices = new Vector3[4];
	
		float halfWidth = (height * 0.5f);
		float halfHeight = (width * 0.5f);
		
		vertices[0] = new Vector3(-halfWidth, -halfHeight, 0);
		vertices[1] = new Vector3(halfWidth, -halfHeight, 0);
		vertices[2] = new Vector3(-halfWidth, halfHeight, 0);
		vertices[3] = new Vector3(halfWidth, halfHeight, 0);
	
		mesh.vertices = vertices;
	
		int[] tri = new int[6];
	
		tri[0] = 0;
		tri[1] = 2;
		tri[2] = 1;
	
		tri[3] = 2;
		tri[4] = 3;
		tri[5] = 1;
	
		mesh.triangles = tri;
	
		Vector3[] normals = new Vector3[4];
	
		normals[0] = -Vector3.forward;
		normals[1] = -Vector3.forward;
		normals[2] = -Vector3.forward;
		normals[3] = -Vector3.forward;
	
		mesh.normals = normals;
	
		Vector2[] uv = new Vector2[4];
	
//		int rx = Random.Range(0,15);
//		int ry = Random.Range(0,15);
		
//		float bim = 1.0f/16.0f;
//		float xBim = (bim * rx);
//		float xBimFin = xBim + bim;
//		float yBim = (bim * ry);
//		float yBimFin = yBim + bim;
		
		
//		uv[0] = new Vector2(xBim, yBim);
		//uv[1] = new Vector2(xBimFin, yBim);
	//	uv[2] = new Vector2(xBim, yBimFin);
//		uv[3] = new Vector2(xBimFin, yBimFin);
		uv[0] = new Vector2(0.0f, 0.0f);
		uv[1] = new Vector2(1.0f, 0.0f);
		uv[2] = new Vector2(0.0f, 1.0f);
		uv[3] = new Vector2(1.0f, 1.0f);
	
		mesh.uv = uv;

		mesh.RecalculateBounds();		
		
		mf.sharedMesh = mesh;
		
		//prevAlpha = 1.0f;
		
		//Now create a 
		
		//MeshRenderer meshRenderer = new MeshRenderer();// GetComponent<MeshRenderer>();	
		
/*		MeshRenderer meshRenderer = GetComponent<MeshRenderer>();		
		
		texture2D = Resources.Load(inTextureName, typeof(Texture2D)) as Texture2D;		
		
	    if (texture2D != null)
		{
	        meshRenderer.material.mainTexture = texture2D;		
		}*/
	}

	public void SetRenderQueue(int queueVal)
	{
		//Dis don't appen no more
		return;
			
		
       // meshRenderer.material.renderQueue = queueVal;	
	}	
	
	public void SetAtlas(Default.Namespace.ZAtlas inAtlas)
	{		
		if(!Default.Namespace.Constants.ANDROID_25)
			Default.Namespace.Globals.Assert(inAtlas.myMaterial.mainTexture != null);

		
	//	Debug.Log("SetAtlas " + inAtlas.myId + " for " + this.ToString());
		
		if (myAtlas != inAtlas)
		{
			if (myAtlas == null)
			{
	//		Debug.Log("ChangingAtlas from null to " + inAtlas.myId);				
			}
			else
			{
	//		Debug.Log("ChangingAtlas from " + myAtlas.myId + " to " +  inAtlas.myId);
			}
//			Debug.Log("ChangingAtlas from " myAtlas.myId + " to " +  inAtlas.myId);
		}
		
		myAtlas = inAtlas;
		
		//MeshRenderer meshRenderer = myObject.GetComponent<MeshRenderer>();				
		//meshRenderer.sharedMaterial = inAtlas.myMaterial;
		
		UnityEngine.Color tempC = new UnityEngine.Color();
		tempC.a=1.0f;
		tempC.r=myColour.r;
		tempC.g=myColour.g;
		tempC.b=myColour.b;		

		myObject.GetComponent<Renderer>().sharedMaterial = inAtlas.myMaterial;
		
/*		
		if (materialForColourAndAlpha == null)
		{
			materialForColourAndAlpha = new Material(Shader.Find( "Pi/TransparentOverlay" ));
		}
		
		materialForColourAndAlpha.mainTexture = inAtlas.myMaterial.mainTexture;
		materialForColourAndAlpha.color = tempC;

		myObject.renderer.material = materialForColourAndAlpha;*/
				
//		Material mat = myObject.renderer.material;		
//		mat.color = tempC;		
//		meshRenderer.material.shader = Shader.Find( "Decal" );
	}
	
	public UnityEngine.Material GetMaterial()
	{
		//Debug.Log ("GEtMaterial");		
		//if has alpha or colour then return the instance here....
		//otherwise the shared one from atlas?!
		
		return myObject.GetComponent<Renderer>().sharedMaterial;
		
//		return materialForColourAndAlpha;
//		MeshRenderer meshRenderer = myObject.GetComponent<MeshRenderer>();
		//return meshRenderer.material;	
//		return meshRenderer.sharedMaterial;	
	}	
	
	public void CopyMaterial(UnityEngine.Material inMat)
	{
//		Debug.Log ("CopyMaterial");
		
		MeshRenderer meshRenderer = myObject.GetComponent<MeshRenderer>();		
		
//		meshRenderer.sharedMaterial = inMat;
		
		if (materialForColourAndAlpha == null)
		{
			materialForColourAndAlpha = new Material(Shader.Find( "Pi/TransparentOverlay" ));
		}
		
		if (inMat != null)
		{
			if (inMat.mainTexture != null)
				materialForColourAndAlpha.mainTexture = inMat.mainTexture;
		}
		
		meshRenderer.material = materialForColourAndAlpha;
		
//		meshRenderer.material.mainTexture = inMat.mainTexture;	
//		meshRenderer.material.shader = inMat.shader;
		SetHeightAndWidth(inMat.mainTexture.width,inMat.mainTexture.height);
	}

	public void SetNewShader(ShaderTypeEnum inShaderType)
	{
		//return;		
		//MeshRenderer meshRenderer = myObject.GetComponent<MeshRenderer>();				
		//UnityEngine.Material myMaterial;		
		
		switch(inShaderType)
		{
		case ShaderTypeEnum.kShader_Additive:			
			
			myObject.GetComponent<Renderer>().sharedMaterial = myAtlas.myMaterialAdditive;			
			
			//in this case we want a new material with the new shader yeah?
			
/*			if (materialForColourAndAlpha == null)
			{
				materialForColourAndAlpha = new Material(Shader.Find( "Pi/Additive" ));
				
				if (myAtlas != null)
					materialForColourAndAlpha.mainTexture = myAtlas.myMaterial.mainTexture;
				else
					materialForColourAndAlpha.mainTexture = myTexture.myMaterial.mainTexture;			
			}
			else
			{
				materialForColourAndAlpha.shader = Shader.Find( "Pi/Additive" );
			}
			
			usingAlpha = true;
			myObject.renderer.material = materialForColourAndAlpha;*/
			break;
		case ShaderTypeEnum.kShader_Transparent:
						
			myObject.GetComponent<Renderer>().sharedMaterial = myAtlas.myMaterial;			
			
			//So i think in this case we can just leave it using the sharedMaterial - which is the material ffrom the
			//atlas...
			
//			materialForColourAndAlpha.shader = Shader.Find( "Pi/TransparentOverlay" );
//			myObject.renderer.material = materialForColourAndAlpha;
		
			break;
		default:
			Default.Namespace.Globals.Assert(false);
						//	myMaterial = new UnityEngine.Material(Shader.Find( "Pi/TransparentOverlay" ));
			break;
		}
				
		//meshRenderer.material = myMaterial;
				
//		float oldAlpha = prevAlpha;
//		this.SetAlpha(prevAlpha);
		
		
	}	
		

	//This is for single textures - i.e. not atlases...
	//The material gets loaded once but could hypothetically be used for a bunch of gmaeobjects...
	public void SetTexture2D(Default.Namespace.Texture2D_Ross inTextureThing)
	{
		myAtlas = null;
		myTexture = inTextureThing;
		
		myObject.GetComponent<Renderer>().sharedMaterial = inTextureThing.myMaterial;
		
		if (false)//(Default.Namespace.Constants.ANDROID_25) && (Default.Namespace.Globals.g_main.loadADCQueue.state == LoadADCQueue.State.kStateBuildingUpAssetList))
		{
			//
			this.SetHeightAndWidth(256.0f,256.0f);
		}
		else
		{
			//won't work with ADC yet...
			this.SetHeightAndWidth(inTextureThing.myMaterial.mainTexture.width,inTextureThing.myMaterial.mainTexture.height);
		}
	}
	
	//This is for single textures - i.e. not atlases...
	//The material gets loaded once but could hypothetically be used for a bunch of gmaeobjects...
/*	public void LoadAndSetMaterialOld(string inName, bool withTransparency)
	{
		string tempString = Default.Namespace.Globals.g_main.GetFolderPrefixForTextureResolution() + System.IO.Path.GetFileNameWithoutExtension(inName) + Default.Namespace.Globals.g_main.GetSuffixForTextureResolution();
				
		Debug.Log ("LoadAndSetMaterial : " + inName);
		Debug.Log ("tempString = " + tempString);
		
		if (materialForColourAndAlpha == null)
		{
			materialForColourAndAlpha = new Material(Shader.Find( "Pi/TransparentOverlay" ));
		}
		
//		MeshFilter mf = GetComponent<MeshFilter>();

		MeshRenderer meshRenderer = myObject.GetComponent<MeshRenderer>();		
		
		texture2D = Resources.Load(tempString, typeof(Texture2D)) as Texture2D;		
		
		//UnityEngine.Material myMaterial;
		
		if (!withTransparency)
			{
			//	meshRenderer.material.shader = Shader.Find( "Diffuse" );
//				meshRenderer.material.shader = Shader.Find( "Mobile/Unlit (Supports Lightmap)" );
				//meshRenderer.material.shader = Shader.Find( "Custom/SimpleOpaque" );
				//meshRenderer.material.shader = Shader.Find( "Pi/OpaqueOverlay" );
				
				//myMaterial = new UnityEngine.Material(Shader.Find( "Pi/OpaqueOverlay" ));

			materialForColourAndAlpha.shader = Shader.Find( "Pi/OpaqueOverlay" );
		}
			else
			{
		//		meshRenderer.material.shader = Shader.Find( "Unlit/Transparent" );
//				meshRenderer.material.shader = Shader.Find( "Transparent/VertexLit" );
//				meshRenderer.material.shader = Shader.Find( "Pi/TransparentOverlay" );
//				meshRenderer.material.shader = Shader.Find( "Pi/TransparentNoAlpha" );

//			myMaterial = new UnityEngine.Material(Shader.Find( "Pi/TransparentOverlay" ));
		
				materialForColourAndAlpha.shader = Shader.Find( "Pi/TransparentOverlay" );
		}
		
		
		
	    if (texture2D != null)
		{
	        materialForColourAndAlpha.mainTexture = texture2D;	
//	        meshRenderer.material.mainTexture = texture2D;				
			SetHeightAndWidth(texture2D.width,texture2D.height);			
			//if (withTransparency)
			//	meshRenderer.material.shader = Shader.Find( "Transparent/VertexLit" );
		}

		meshRenderer.material = materialForColourAndAlpha;// myMaterial;	
	}*/
		public void SetAlphaWithColour(float inAlpha) 
		{	 	
				Color col = myObject.GetComponent<MeshRenderer>().sharedMaterial.color;
				col.a = inAlpha;
				myObject.GetComponent<MeshRenderer>().material.color = col;
		}
	public void RenderInRect(Default.Namespace.CGRect inRect, float inAlpha) 
	{	
		this.CheckRender();
		
		myObject.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, 0.0f );	
		
		if (inAlpha != prevAlpha) 
			this.SetAlpha(inAlpha);
		
		MeshFilter mf = myObject.GetComponent<MeshFilter>();		
	
		Mesh mesh;
		
		if (mf.sharedMesh == null)
		{
			mesh = new Mesh();
		}
		else
		{
			mesh = mf.sharedMesh;
		}
		
		Vector3[] vertices = new Vector3[4];
		
		Vector3 newPos;
		newPos.x = inRect.Origin.x;
		newPos.y = inRect.Origin.y;
		newPos.z = Default.Namespace.Globals.renderCounter;
		
		inRect.Origin.x -= 160.0f;
		inRect.Origin.y -=240.0f;// - inRect.Origin.y;
		
		float halfWidth = inRect.Size.Width * 0.5f;
		float halfHeight = inRect.Size.Height * 0.5f;
		
		vertices[0] = new Vector3(-halfWidth, -halfHeight, 0.0f);
		vertices[1] = new Vector3(halfWidth, -halfHeight, 0.0f);
		vertices[2] = new Vector3(-halfWidth, halfHeight, 0.0f);
		vertices[3] = new Vector3(halfWidth, halfHeight, 0.0f);
		
		myObject.transform.position = newPos;
		
		Default.Namespace.Globals.renderCounter -= 0.1f;
		
		mesh.vertices = vertices;
		
		mesh.RecalculateBounds();
		
		mf.sharedMesh = mesh;
	}	
	
	public void SetupMyMaterialIfNull(string shaderName)
	{
		if (materialForColourAndAlpha == null)
		{
			materialForColourAndAlpha = new Material(Shader.Find(shaderName));
			if (myAtlas != null)
				materialForColourAndAlpha.mainTexture = myAtlas.myMaterial.mainTexture;
			else
				materialForColourAndAlpha.mainTexture = myTexture.myMaterial.mainTexture;			
		}		
	}

	public void SetColour(Default.Namespace.Constants.RossColour inCol)
	{
		myColour.r = inCol.cRed;
		myColour.g = inCol.cGreen;
		myColour.b = inCol.cBlue;
		
		UnityEngine.Color tempC = new UnityEngine.Color();
		tempC.a=0.9f;
		tempC.r=myColour.r;
		tempC.g=myColour.g;
		tempC.b=myColour.b;
		
		MeshFilter mf = myObject.GetComponent<MeshFilter>();				

			Mesh mesh;// = mf.mesh;
			
			if (mf.sharedMesh == null)
			{
				mesh = new Mesh();
			}
			else
			{
				mesh = mf.sharedMesh;
			}			
		
		
		Color[] colorThing = new Color[(int)mesh.vertices.Length];
		
//		Color alphaColor = new Color(0.5f,0.5f,0.5f,1.0f);
//		Color alphaColor = new Color(1.0f,1.0f,1.0f,inAlpha);
		
		for (int i = 0; i < mesh.vertices.Length; i++)
		{
			colorThing[i] = tempC;//Color.Lerp(tempC,alphaColor,0.5f);//mesh.vertices[i].y);
		}

		mesh.colors = colorThing;
		
		mf.sharedMesh = mesh;		
		
		return;
		
		
		
		
		this.SetupMyMaterialIfNull("Pi/TransparentOverlay");
				
		materialForColourAndAlpha.color = tempC;
		myObject.GetComponent<Renderer>().material = materialForColourAndAlpha;
	
		if (!usingAlpha)
		{
		//	MeshRenderer meshRenderer = myObject.GetComponent<MeshRenderer>();
			usingAlpha = true;
			//myObject.renderer.material.shader = Shader.Find( "Pi/TransparentOverlay" );
		}
	}
	
	
	//Used for example by a particle when spawned - so we can re-set the material to the texture atlas if it faded last time..
	public void Reset()
	{
		materialForColourAndAlpha = null;
		
		if (usingAlpha)
		{
			myObject.GetComponent<Renderer>().material = null;
		}
		
		prevAlpha = -1.0f;
		usingAlpha = false;
				
		if (myAtlas == null)
		{
			if (myTexture != null)
			{
				myObject.GetComponent<Renderer>().sharedMaterial = myTexture.myMaterial;
			}
		}
		else
		{
			myObject.GetComponent<Renderer>().sharedMaterial = myAtlas.myMaterial;			
		}
	}
	
	//In the case that the object has alpha on it... we need to make a new instance of the material 
	public void SetAlpha(float inAlpha)
	{
				//this is slow... like adding 4-5 miliseconds on some frames... when we only have 16 
				//altogether
				//i think
				//return;

		MeshFilter mf = myObject.GetComponent<MeshFilter>();				

			Mesh mesh;// = mf.mesh;
			
			if (mf.sharedMesh == null)
			{
				mesh = new Mesh();
			}
			else
			{
				mesh = mf.sharedMesh;
			}			
		
		
		Color[] colorThing = new Color[(int)mesh.vertices.Length];
		
//		Color alphaColor = new Color(0.5f,0.5f,0.5f,1.0f);
		Color alphaColor = new Color(myColour.r,myColour.g,myColour.b,inAlpha);
		
		for (int i = 0; i < mesh.vertices.Length; i++)
		{
			colorThing[i] = alphaColor;//Color.Lerp(alphaColor,alphaColor,0.5f);//mesh.vertices[i].y);
		}

		mesh.colors = colorThing;
		
		mf.sharedMesh = mesh;		
		
		prevAlpha = inAlpha;

		return;
		
		
		
		if (inAlpha == prevAlpha)
		{
			return;
		}
		
		UnityEngine.Color tempC = new UnityEngine.Color();
		tempC.a=inAlpha;
		tempC.r=myColour.r;
		tempC.g=myColour.g;
		tempC.b=myColour.b;
		
		this.SetupMyMaterialIfNull("Pi/TransparentOverlay");
				
		materialForColourAndAlpha.color = tempC;
		myObject.GetComponent<Renderer>().material = materialForColourAndAlpha;
		
		prevAlpha = inAlpha;

		if (!usingAlpha)
		{
			usingAlpha = true;
		}	
	}
	
	public void SetScale(float inScale) 
	{	

				myObject.transform.localScale = new Vector3(inScale,inScale,inScale);

		Default.Namespace.Globals.Assert(myAtlas != null);

		//this.SetUVs(currentSubtextureId);
		
		MeshFilter mf = myObject.GetComponent<MeshFilter>();				

			Mesh mesh;// = mf.mesh;
			
			if (mf.sharedMesh == null)
			{
				mesh = new Mesh();
			}
			else
			{
				mesh = mf.sharedMesh;
			}			
		
		
		Vector3[] vertices = new Vector3[4];
		
		height = myAtlas.GetSubTextureWidth(currentSubtextureId) * 2.0f;
		width = myAtlas.GetSubTextureHeight(currentSubtextureId) * 2.0f;
			
		if (true)
		{				
			float halfWidth = width * 0.5f * inScale;//(width * 0.5f);
			float halfHeight = height * 0.5f *  inScale;//(height * 0.5f);
						
			vertices[0] = new Vector3(-halfHeight, -halfWidth, 0.0f);
			vertices[1] = new Vector3(halfHeight, -halfWidth, 0.0f);
			vertices[2] = new Vector3(-halfHeight, halfWidth, 0.0f);
			vertices[3] = new Vector3(halfHeight, halfWidth, 0.0f);
		}
		mesh.vertices = vertices;
		
		//mesh.RecalculateBounds();
		
		mf.sharedMesh = mesh;
	}


		public void RenderAtPosition(Default.Namespace.CGPoint inPosition) 
		{			
				this.RenderAtPosition(inPosition,1.0f,0.0f,1.0f,0);
		}
	public void RenderAtPosition(Default.Namespace.CGPoint inPosition, float inScale, float inRot, float inAlpha, int inSubtextureId) 
	{			
//				if (true)//currentSubtextureId != inSubtextureId)
		if (currentSubtextureId != inSubtextureId)
		{
			currentSubtextureId = inSubtextureId;
			if (myAtlas != null)
			{
				this.SetUVs(currentSubtextureId);
				
				height = myAtlas.GetSubTextureWidth(inSubtextureId) * 2.0f;
				width = myAtlas.GetSubTextureHeight(inSubtextureId) * 2.0f;

								MeshFilter mf1 = myObject.GetComponent<MeshFilter>();	

								Mesh mesh1;// = mf.mesh;


								if (mf1.sharedMesh == null)
								{
										mesh1 = new Mesh();
								}
								else
								{
										mesh1 = mf1.sharedMesh;
								}

										Vector3[] vertices = new Vector3[4];

										float halfWidth = width * 0.5f * 1.0f;//(width * 0.5f);
										float halfHeight = height * 0.5f *  1.0f;//(height * 0.5f);

										vertices[0] = new Vector3(-halfHeight, -halfWidth, 0.0f);
										vertices[1] = new Vector3(halfHeight, -halfWidth, 0.0f);
										vertices[2] = new Vector3(-halfHeight, halfWidth, 0.0f);
										vertices[3] = new Vector3(halfHeight, halfWidth, 0.0f);			

										mesh1.vertices = vertices;

										mesh1.RecalculateBounds();

										mf1.sharedMesh = mesh1;




			}
		}
			

				//---------------------------------------------------------------------------------
				//trying something...

				MeshFilter mf = myObject.GetComponent<MeshFilter>();	

				Mesh mesh;// = mf.mesh;

				if (mf.sharedMesh == null)
				{
						mesh = new Mesh();
						Vector3[] vertices = new Vector3[4];

						float halfWidth = width * 0.5f * 1.0f;//(width * 0.5f);
						float halfHeight = height * 0.5f *  1.0f;//(height * 0.5f);

						vertices[0] = new Vector3(-halfHeight, -halfWidth, 0.0f);
						vertices[1] = new Vector3(halfHeight, -halfWidth, 0.0f);
						vertices[2] = new Vector3(-halfHeight, halfWidth, 0.0f);
						vertices[3] = new Vector3(halfHeight, halfWidth, 0.0f);			

						mesh.vertices = vertices;

						mesh.RecalculateBounds();

						mf.sharedMesh = mesh;

				}

				myObject.transform.localScale = new Vector3(inScale,inScale,inScale);

				//---------------------------------------------------------------------------------

		/*
			//Debug.Log ("RenderAtPosition");
			
			MeshFilter mf = myObject.GetComponent<MeshFilter>();	
			
			Mesh mesh;// = mf.mesh;
			
			if (mf.sharedMesh == null)
			{
				mesh = new Mesh();
			}
			else
			{
				mesh = mf.sharedMesh;
			}			
			
			Vector3[] vertices = new Vector3[4];
						
			float halfWidth = width * 0.5f * inScale;//(width * 0.5f);
			float halfHeight = height * 0.5f *  inScale;//(height * 0.5f);
						
			vertices[0] = new Vector3(-halfHeight, -halfWidth, 0.0f);
			vertices[1] = new Vector3(halfHeight, -halfWidth, 0.0f);
			vertices[2] = new Vector3(-halfHeight, halfWidth, 0.0f);
			vertices[3] = new Vector3(halfHeight, halfWidth, 0.0f);			
		
			mesh.vertices = vertices;
			
			mesh.RecalculateBounds();
		
			mf.sharedMesh = mesh;
//			mf.mesh = mesh;

				*/
			
			for (int i = 0; i < 4; i++)
			{
//				mf.mesh.vertices[i].x = vertices[i].y;		
				//mf.mesh.vertices[i].y = vertices[i].x;		
				//mf.mesh.vertices[i].z = vertices[i].z;	
			}
		
		this.CheckRender();		
		
		if (inAlpha != prevAlpha) 
			this.SetAlpha(inAlpha);		
		
		myObject.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, inRot * Mathf.Rad2Deg );	
	
		inPosition.x -= 160.0f;
		inPosition.y = 240.0f - inPosition.y;
		
		if (myObject.transform.parent != null)
		{
			Vector3 newPos;
			newPos.x = localPosition.x;
			newPos.y = localPosition.y;
			newPos.z = -0.1f;
			
			if (Default.Namespace.Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
					newPos.x *= 2.0f;
					newPos.y *= 2.0f;
			}
				
			myObject.transform.localPosition = newPos;
			
		}
		else
		{
			Vector3 newPos;
			newPos.x = inPosition.x;
			newPos.y = inPosition.y;
			newPos.z = Default.Namespace.Globals.renderCounter;
	
				if (Default.Namespace.Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
					newPos.x *= 2.0f;
					newPos.y *= 2.0f;
			}
			
			myObject.transform.position = newPos;
		}

		Default.Namespace.Globals.renderCounter -= 0.1f;
	
	}	
	
	public void RenderAtPositionOld(Default.Namespace.CGPoint inPosition, float inScale, float inRot, float inAlpha, int inSubtextureId) 
	{	
		//return;
		
		if (currentSubtextureId != inSubtextureId)
		{
			currentSubtextureId = inSubtextureId;
			if (myAtlas != null)
			{
				this.SetUVs(currentSubtextureId);
				
				height = myAtlas.GetSubTextureWidth(inSubtextureId) * 2.0f;
				width = myAtlas.GetSubTextureHeight(inSubtextureId) * 2.0f;
			}
		}
		
		this.CheckRender();
		
		if (inAlpha != prevAlpha) 
			this.SetAlpha(inAlpha);
				
		MeshFilter mf = myObject.GetComponent<MeshFilter>();				
		Vector3[] vertices = new Vector3[4];
		
		myObject.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, inRot * Mathf.Rad2Deg );	
		
	//	bool makeVectors = false;
		
		if (oldScale == inScale)
		{
	//		makeVectors = true;
		}
		
		if (true)//inRot == 0.0f)
		{				
//			oldScale = inScale;
			
			float halfWidth = width * 0.5f * inScale;//(width * 0.5f);
			float halfHeight = height * 0.5f *  inScale;//(height * 0.5f);
						
			vertices[0] = new Vector3(-halfHeight, -halfWidth, 0.0f);
			vertices[1] = new Vector3(halfHeight, -halfWidth, 0.0f);
			vertices[2] = new Vector3(-halfHeight, halfWidth, 0.0f);
			vertices[3] = new Vector3(halfHeight, halfWidth, 0.0f);
		}
///		else
		//{
/*			float rotationAngleToFirstPoint;// = myAtlas.GetRotationAngleToFirstPoint(inSubtextureId);
			float rotationAngleToSecondPoint;// = myAtlas.GetRotationAngleToSecondPoint(inSubtextureId);				
			float useRotationScale;// = myAtlas.GetSubTextureRotationScale(inSubtextureId) * inScale;			
			
			if (myAtlas == null)
			{
				//Just loading bar???
				
				rotationAngleToFirstPoint = rotationAngle1;
				rotationAngleToSecondPoint = rotationAngle2;
				useRotationScale = rotationScale;
			}
			else
			{
				Default.Namespace.Globals.Assert(inSubtextureId != -1);
				
				rotationAngleToFirstPoint = myAtlas.GetRotationAngleToFirstPoint(inSubtextureId);
				rotationAngleToSecondPoint = myAtlas.GetRotationAngleToSecondPoint(inSubtextureId);				
				useRotationScale = myAtlas.GetSubTextureRotationScale(inSubtextureId) * inScale;
			}
			
			float radians = inRot + rotationAngleToFirstPoint; //kRadiansAngleFor2x1y;
			float a = (Mathf.Cos(radians) * useRotationScale);
			float b = (Mathf.Sin(radians) * useRotationScale);
			radians += rotationAngleToSecondPoint; //0.9272f;//0.4636below*2//2.217f; //(M_PI - (kRadiansAngleFor2x1y * 2.0f));
			float c = (Mathf.Cos(radians) * useRotationScale);
			float d = (Mathf.Sin(radians) * useRotationScale);	
			float topRightX = a;
			float topRightY = b;
			float topLeftX = c;
			float topLeftY = d;
			float bottomLeftX = -a;
			float bottomLeftY = -b;
			float bottomRightX = -c;
			float bottomRightY = -d;		
			
			vertices[2] = new Vector3(topLeftX, topLeftY, 0.0f);
			vertices[3] = new Vector3(topRightX, topRightY, 0.0f);
			vertices[0] = new Vector3(bottomLeftX, bottomLeftY, 0.0f);
			vertices[1] = new Vector3(bottomRightX, bottomRightY, 0.0f);		*/	
		
	//	}
		inPosition.x -= 160.0f;
		inPosition.y = 240.0f - inPosition.y;
		
		if (myObject.transform.parent != null)
		{
			Vector3 newPos;
			newPos.x = localPosition.x;
			newPos.y = localPosition.y;
			newPos.z = -0.1f;
			
			if (Default.Namespace.Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
					newPos.x *= 2.0f;
					newPos.y *= 2.0f;
			}
				
			myObject.transform.localPosition = newPos;
			
		}
		else
		{
			Vector3 newPos;
			newPos.x = inPosition.x;
			newPos.y = inPosition.y;
			newPos.z = Default.Namespace.Globals.renderCounter;
	
				if (Default.Namespace.Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
					newPos.x *= 2.0f;
					newPos.y *= 2.0f;
			}
			
			myObject.transform.position = newPos;
		}
		
		//if (makeVectors)
		mf.mesh.vertices = vertices;		

		for (int i = 0; i < 4; i++)
		{
//			mf.mesh.vertices[i].x = vertices[i].x;		
			//mf.mesh.vertices[i].y = vertices[i].y;		
		//	mf.mesh.vertices[i].z = vertices[i].z;	
		}
		
		Default.Namespace.Globals.renderCounter -= 0.1f;
	}	
	
	public void RenderTileAtPosition(Default.Namespace.CGPoint inPosition, int inSubtextureId) 
	{	
		if (currentSubtextureId != inSubtextureId)
		{
			currentSubtextureId = inSubtextureId;
			if (myAtlas != null)
			{
				this.SetUVs(currentSubtextureId);
				
				height = myAtlas.GetSubTextureWidth(inSubtextureId) * 2.0f;
				width = myAtlas.GetSubTextureHeight(inSubtextureId) * 2.0f;
			}

//						debugCounter++;
//						if (debugCounter >= 40)
//						{
//								debugCounter = 0;
//								Debug.Log("tile width " + width);
//								Debug.Log("tile scale " + myObject.transform.localScale);
//								MeshFilter mf = myObject.GetComponent<MeshFilter>();				
//								//
//								Debug.Log("mf.mesh.bounds " + mf.mesh.bounds.ToString());		
//
//
//						}
		}
		
		this.CheckRender();
						
		inPosition.x -= 160.0f;
		inPosition.y = 240.0f - inPosition.y;
		
		Vector3 newPos;
		newPos.x = inPosition.x;
		newPos.y = inPosition.y;
		newPos.z = Default.Namespace.Globals.renderCounter;
		
		if (Default.Namespace.Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
		{
				newPos.x *= 2.0f;
				newPos.y *= 2.0f;
		}
		
		myObject.transform.localPosition = newPos;
	
				//should just be done at start of race...
				//because tiles can be scaled down for race tip... 
				//myObject.transform.localScale = new Vector3(1,1,1);
		
//		MeshFilter mf = myObject.GetComponent<MeshFilter>();				
//
//		mf.mesh.RecalculateBounds();		
		
		Default.Namespace.Globals.renderCounter -= 0.1f;
	}	
	
/*	public void RenderAtPositionOld_(Default.Namespace.CGPoint inPosition, float inScale, float inRot, float inAlpha, int inSubtextureId) 
	{	
		if (currentSubtextureId != inSubtextureId)
		{
			currentSubtextureId = inSubtextureId;
			if (myAtlas != null)
			{
				this.SetUVs(currentSubtextureId);
			}
		}
		
		this.CheckRender();
		
		if (inAlpha != prevAlpha) 
			this.SetAlpha(inAlpha);
		
		MeshFilter mf = myObject.GetComponent<MeshFilter>();				
		Vector3[] vertices = new Vector3[4];
		
		inPosition.x -= 160.0f;
		inPosition.y = 240.0f - inPosition.y;
		
		if (inRot == 0.0f)
		{					
			float halfWidth = width * 0.5f * inScale;//(width * 0.5f);
			float halfHeight = height * 0.5f *  inScale;//(height * 0.5f);
						
			vertices[0] = new Vector3(inPosition.x - halfHeight, inPosition.y - halfWidth, Default.Namespace.Globals.renderCounter);
			vertices[1] = new Vector3(inPosition.x + halfHeight, inPosition.y - halfWidth, Default.Namespace.Globals.renderCounter);
			vertices[2] = new Vector3(inPosition.x - halfHeight, inPosition.y + halfWidth, Default.Namespace.Globals.renderCounter);
			vertices[3] = new Vector3(inPosition.x + halfHeight, inPosition.y + halfWidth, Default.Namespace.Globals.renderCounter);
		}
		else
		{
			float rotationAngleToFirstPoint;// = myAtlas.GetRotationAngleToFirstPoint(inSubtextureId);
			float rotationAngleToSecondPoint;// = myAtlas.GetRotationAngleToSecondPoint(inSubtextureId);				
			float useRotationScale;// = myAtlas.GetSubTextureRotationScale(inSubtextureId) * inScale;			
			
			if (myAtlas == null)
			{
				//Just loading bar???
				
				rotationAngleToFirstPoint = rotationAngle1;
				rotationAngleToSecondPoint = rotationAngle2;
				useRotationScale = rotationScale;
			}
			else
			{
				Default.Namespace.Globals.Assert(inSubtextureId != -1);
				
				rotationAngleToFirstPoint = myAtlas.GetRotationAngleToFirstPoint(inSubtextureId);
				rotationAngleToSecondPoint = myAtlas.GetRotationAngleToSecondPoint(inSubtextureId);				
				useRotationScale = myAtlas.GetSubTextureRotationScale(inSubtextureId) * inScale;
			}
			
			float radians = inRot + rotationAngleToFirstPoint; //kRadiansAngleFor2x1y;
			float a = (Mathf.Cos(radians) * useRotationScale);
			float b = (Mathf.Sin(radians) * useRotationScale);
			radians += rotationAngleToSecondPoint; //0.9272f;//0.4636below*2//2.217f; //(M_PI - (kRadiansAngleFor2x1y * 2.0f));
			float c = (Mathf.Cos(radians) * useRotationScale);
			float d = (Mathf.Sin(radians) * useRotationScale);	
			float topRightX = inPosition.x + a;
			float topRightY = inPosition.y + b;
			float topLeftX = inPosition.x + c;
			float topLeftY = inPosition.y + d;
			float bottomLeftX = inPosition.x - a;
			float bottomLeftY = inPosition.y - b;
			float bottomRightX = inPosition.x - c;
			float bottomRightY = inPosition.y - d;		
			
			vertices[2] = new Vector3(topLeftX, topLeftY, Default.Namespace.Globals.renderCounter);
			vertices[3] = new Vector3(topRightX, topRightY, Default.Namespace.Globals.renderCounter);
			vertices[0] = new Vector3(bottomLeftX, bottomLeftY, Default.Namespace.Globals.renderCounter);
			vertices[1] = new Vector3(bottomRightX, bottomRightY, Default.Namespace.Globals.renderCounter);			
			
		//	float halfHeight = 50.0f;
		//	float halfWidth = 50.0f;
			
//			vertices[0] = new Vector3(inPosition.x - halfHeight, -80, Default.Namespace.Globals.renderCounter);
//			vertices[1] = new Vector3(inPosition.x + halfHeight, -80, Default.Namespace.Globals.renderCounter);
//			vertices[2] = new Vector3(inPosition.x - halfHeight, 85, Default.Namespace.Globals.renderCounter);
//			vertices[3] = new Vector3(inPosition.x + halfHeight, 85, Default.Namespace.Globals.renderCounter);
		
		}
		
		Default.Namespace.Globals.renderCounter -= 0.5f;
		
		//could save this...
	//	MeshRenderer meshRenderer = myObject.GetComponent<MeshRenderer>();				
    //    meshRenderer.material.renderQueue = Default.Namespace.Globals.renderQueueCounter;			
	//	Default.Namespace.Globals.renderQueueCounter += 1;
		
		mf.mesh.vertices = vertices;
	}*/
	
	public void SetDetailsFromAtlas(Default.Namespace.ZAtlas inAtlas, int subTextureId) 
	{	
		//Debug.Log ("SetDetailsFromAtlas");
		
		currentSubtextureId = subTextureId;
		
		height = inAtlas.GetSubTextureWidth(subTextureId) * 2.0f;
		width = inAtlas.GetSubTextureHeight(subTextureId) * 2.0f;
		
		MeshFilter mf = myObject.GetComponent<MeshFilter>();		
		
		Mesh mesh;
		bool newMesh = false;
		
		if (mf.sharedMesh == null)
		{
			mesh = new Mesh();
			newMesh = true;
		}
		else
		{
			mesh = mf.sharedMesh;
		}
		
//		var mesh = new Mesh();
//		mf.mesh = mesh;
	
		Vector3[] vertices = new Vector3[4];
	
		float halfWidth = (width * 0.5f);
		float halfHeight = (height * 0.5f);
		
		vertices[0] = new Vector3(-halfHeight, -halfWidth, 0);
		vertices[1] = new Vector3(halfHeight, -halfWidth, 0);
		vertices[2] = new Vector3(-halfHeight, halfWidth, 0);
		vertices[3] = new Vector3(halfHeight, halfWidth, 0);
	
		
		mesh.vertices = vertices;
		
		for (int i = 0; i < 4; i++)
		{
//			mesh.vertices[i].x = vertices[i].x;
//			mesh.vertices[i].y = vertices[i].y;
//			mesh.vertices[i].z = vertices[i].z;
		}
		
//		mesh.vertices = vertices;
	
		if (newMesh)
		{
			int[] tri = new int[6];
		
			tri[0] = 0;
			tri[1] = 2;
			tri[2] = 1;
		
			tri[3] = 2;
			tri[4] = 3;
			tri[5] = 1;
		
			mesh.triangles = tri;
			
			Vector3[] normals = new Vector3[4];
		
			normals[0] = -Vector3.forward;
			normals[1] = -Vector3.forward;
			normals[2] = -Vector3.forward;
			normals[3] = -Vector3.forward;
		
			mesh.normals = normals;
		}
		
		Vector2[] uv = new Vector2[4];
			
		float ux = inAtlas.GetMinUVP1(subTextureId,0);
		float uxm = inAtlas.GetMaxUVP1(subTextureId,0);
		float vx = inAtlas.GetMinUVP1(subTextureId,1);
		float vxm = inAtlas.GetMaxUVP1(subTextureId,1);
		
		float textureWidth;
		float textureHeight;
		
		if ((Default.Namespace.Constants.ANDROID_25) && (Default.Namespace.Globals.g_main.loadADCQueue.state == LoadADCQueue.State.kStateBuildingUpAssetList))
		{
			textureWidth = 256.0f;
			textureHeight = 256.0f;
		}
		else
		{
			textureWidth = inAtlas.myMaterial.mainTexture.width;
			textureHeight = inAtlas.myMaterial.mainTexture.height;
		}
		
		ux /= textureWidth;
		uxm /= textureWidth;
		vx /= textureHeight;
		vxm /= textureHeight;
		
		float tempVx = vx;
		vx = 1.0f - vxm;
		vxm = 1.0f - tempVx;
		
		//uv[0] = new Vector2(0.0f, 0.0f);
		//uv[1] = new Vector2(1.0f, 0.0f);
		//uv[2] = new Vector2(0.0f, 1.0f);
		//uv[3] = new Vector2(1.0f, 1.0f);
		
		uv[0] = new Vector2(ux, vx);
		uv[1] = new Vector2(uxm, vx);
		uv[2] = new Vector2(ux, vxm);
		uv[3] = new Vector2(uxm, vxm);
		//uv[0] = new Vector2(vx, ux);
		//uv[1] = new Vector2(vxm, ux);
		//uv[2] = new Vector2(vx, uxm);
		//uv[3] = new Vector2(vxm, uxm);
	
		mesh.uv = uv;
		
		for (int i = 0; i < 4; i++)
		{
//			mesh.uv[i].x = uv[i].x;
			//mesh.uv[i].y = uv[i].y;
		}	
		
		mesh.RecalculateBounds();
		
		mf.sharedMesh = mesh;
		
		//Now create a 
		
		//MeshRenderer meshRenderer = new MeshRenderer();// GetComponent<MeshRenderer>();		
		
//		texture2D = inAtlas.GetMaterial().GetTexture2D();//Resources.Load(inTextureName, typeof(Texture2D)) as Texture2D;		
		
	 //   if (texture2D != null)
//		{
	 //       meshRenderer.material.mainTexture = texture2D;		
	//	}
	}
	
	
	public void SetUVs(int subTextureId) 
	{	
	//	Debug.Log ("SetUVs");
		
		if (subTextureId < 0)
			return;
		
		height = myAtlas.GetSubTextureWidth(subTextureId) * 2.0f;
		width = myAtlas.GetSubTextureHeight(subTextureId) * 2.0f;
		
		Default.Namespace.Globals.Assert(myAtlas != null);
				
		MeshFilter mf = myObject.GetComponent<MeshFilter>();		

		Mesh mesh;
		
		if (mf.sharedMesh == null)
		{
			mesh = new Mesh();
		}
		else
		{
			mesh = mf.sharedMesh;
		}		
		
		Vector2[] uv = new Vector2[4];
		
		float ux = myAtlas.GetMinUVP1(subTextureId,0);
		float uxm = myAtlas.GetMaxUVP1(subTextureId,0);
		float vx = myAtlas.GetMinUVP1(subTextureId,1);
		float vxm = myAtlas.GetMaxUVP1(subTextureId,1);
		
		float textureWidth = myAtlas.myMaterial.mainTexture.width;
		float textureHeight = myAtlas.myMaterial.mainTexture.height;
		
		ux /= textureWidth;
		uxm /= textureWidth;
		vx /= textureHeight;
		vxm /= textureHeight;
		
		float tempVx = vx;
		vx = 1.0f - vxm;
		vxm = 1.0f - tempVx;
		
		//uv[0] = new Vector2(0.0f, 0.0f);
		//uv[1] = new Vector2(1.0f, 0.0f);
		//uv[2] = new Vector2(0.0f, 1.0f);
		//uv[3] = new Vector2(1.0f, 1.0f);
		
		uv[0] = new Vector2(ux, vx);
		uv[1] = new Vector2(uxm, vx);
		uv[2] = new Vector2(ux, vxm);
		uv[3] = new Vector2(uxm, vxm);
		//uv[0] = new Vector2(vx, ux);
		//uv[1] = new Vector2(vxm, ux);
		//uv[2] = new Vector2(vx, uxm);
		//uv[3] = new Vector2(vxm, uxm);
	
		mesh.uv = uv;
		mf.sharedMesh = mesh;
		
		for (int i = 0; i < 4; i++)
		{
//			mf.mesh.uv[i].x = uv[i].x;
			//mf.mesh.uv[i].y = uv[i].y;
		}	
		//Now create a 
		
		//MeshRenderer meshRenderer = new MeshRenderer();// GetComponent<MeshRenderer>();		
		
//		texture2D = inAtlas.GetMaterial().GetTexture2D();//Resources.Load(inTextureName, typeof(Texture2D)) as Texture2D;		
		
	 //   if (texture2D != null)
//		{
	 //       meshRenderer.material.mainTexture = texture2D;		
	//	}
	}	
	
	
	
	
	
	
	
	
	
	
	
}



