using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (MeshCollider))]


public class TextMeshWrapper{

	public Texture2D texture2D;
	//public Material rossMat;
	public float width;	
	public float height;
			bool shown;
	
	Material materialForColourAndAlpha;
	
//	public float rotScaleNoAtlas;
	
	public GameObject myObject;
	Default.Namespace.ZAtlas myAtlas;
	Default.Namespace.Constants.RossColour myColour;
	int currentSubtextureId;
	
	public float rotationScale;
	public float rotationAngle1;
	public float rotationAngle2;

	public float myScale;
	public float myFontSize;
	
	const float kFontSize = 48.0f;
		
	
	public TextMeshWrapper(string description)
	{		
		string whatAmI = "TextMeshWrapperGameObject_" + description;
		
		materialForColourAndAlpha = null;
			
		myObject = new GameObject(whatAmI);
		myObject.AddComponent<TextMesh>();
		myObject.AddComponent<MeshRenderer>();
		myObject.layer = LayerMask.NameToLayer("guistuff");
		
//		TextMesh textMesh = myObject.GetComponent<TextMesh>();
		//textMesh.font = Default.Namespace.Globals.g_world.guiFont; 
		myObject.GetComponent<Renderer>().enabled = false;
		
		myFontSize = kFontSize;
		myScale = 1.0f;
		
		myColour = Default.Namespace.Constants.kColourWhite;
		
		
		
		myAtlas = null;
		//myColour.a = 0.8f;
//		myColour.cRed = 1.0f;
//		myColour.cGreen = 1.0f;
//		myColour.cBlue = 1.0f;
		
		shown = false;
		
		this.SetAlpha(0.8f);		
				
		currentSubtextureId = -1;
	}
	
	public void Dealloc()
	{
//		GameObject.Destroy(myObject.GetComponent<MeshRenderer>());
//		GameObject.Destroy(myObject.GetComponent<TextMesh>());		
//		GameObject.Destroy(myObject);
		myObject = null;
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
		myObject.GetComponent<Renderer>().enabled = false;
		shown = false;
	}	

	public void Show()
	{
		shown = true;
	}	
	

	
	public void SetFont()
	{
	}

	public void SetWords(string inString)
	{
		TextMesh textMesh = myObject.GetComponent<TextMesh>();
		
		textMesh.alignment = TextAlignment.Center;
		textMesh.anchor = TextAnchor.MiddleCenter;
		textMesh.fontStyle = FontStyle.Bold;
		textMesh.text = inString;
		textMesh.fontSize = (int)kFontSize;
		//textMesh.characterSize = 
		this.SetFontSize(textMesh.fontSize);
		textMesh.GetComponent<Renderer>().material = Default.Namespace.Globals.g_world.guiFont.material; //   new Material(Shader.Find("GUI/Text Shader"));
		textMesh.font = Default.Namespace.Globals.g_world.guiFont; 
		this.SetColour(myColour);
	}
	
	public void SetFontSize(float inFontSize)
	{
//		characterSize = targetSizeInWorldUnits*10.0f/fontSize;		
		
		myFontSize = inFontSize;
		
		TextMesh textMesh = myObject.GetComponent<TextMesh>();
		
		textMesh.characterSize = 32.0f * (inFontSize / kFontSize);//(int)((float)10 * myScale * (myFontSize / 20.0f));
	}
	
	public void SetScale(float inScale)
	{
		Default.Namespace.Globals.Assert(false);

		//
		
		myScale = inScale;
		
		TextMesh textMesh = myObject.GetComponent<TextMesh>();
		
		textMesh.characterSize = (int)((float)10 * myScale * (myFontSize / 20.0f));
	}
	
	
/*	public void SetColour(Colours inColour, Default.Namespace.Constants.RossColour rossCol)
	{	
		if (myMaterialWithColour[(int)inColour] == null)
		{
			myMaterialWithColour[(int)inColour] = new UnityEngine.Material(Shader.Find( "Pi/OpaqueOverlay" ));		
			
			UnityEngine.Color tempC = new UnityEngine.Color();
			tempC.a=0.8f;
			tempC.r=rossCol.cRed;
			tempC.g=rossCol.cGreen;
			tempC.b=rossCol.cBlue;
		
			myMaterialWithColour[(int)inColour].mainTexture = Default.Namespace.Globals.g_world.guiFont.material.mainTexture;
			myMaterialWithColour[(int)inColour].color = tempC;
		}
		TextMesh textMesh = myObject.GetComponent<TextMesh>();
		
		textMesh.renderer.sharedMaterial = myMaterialWithColour[(int)inColour];
		
//		return myMaterialWithColour[(int)inColour];
	}*/
	
	
	
	
	
	public void SetColour(Default.Namespace.Constants.RossColour inCol)
	{
		//return;//
		TextMesh textMesh = myObject.GetComponent<TextMesh>();
		
		textMesh.GetComponent<Renderer>().material = Default.Namespace.Globals.g_world.GetFontColourMaterial(inCol);

		return;//		
		
		myColour.cRed = inCol.cRed;
		myColour.cGreen = inCol.cGreen;
		myColour.cBlue = inCol.cBlue;
		
		//zatlas
		
/*		UnityEngine.Color tempC = new UnityEngine.Color();
		tempC.a=0.8f;
		tempC.r=myColour.cRed;
		tempC.g=myColour.cGreen;
		tempC.b=myColour.cBlue;

/*		if (materialForColourAndAlpha == null)
		{
			materialForColourAndAlpha = new Material(Shader.Find( "Pi/TransparentOverlay" ));
		}
		
		materialForColourAndAlpha.mainTexture = TextMesh
		materialForColourAndAlpha.color = tempC;
		myObject.renderer.material = materialForColourAndAlpha;*/
		
//		myObject.renderer.material.color = tempC;
	
	
	}

	public void SetBoundThing()
	{
//		TextMesh textMesh = myObject.GetComponent<TextMesh>();
		
		//Vector3 newSize = new Vector3();
	//	newSize.x = 128.0f;
//		newSize.y = 128.0f;
		//newSize.x = 1.0f;
		
	//	textMesh.renderer.bounds.size = newSize;
		
//		textMesh.renderer.bounds.size.x = 128.0f;
//		textMesh.renderer.bounds.size.y = 128.0f;
//		textMesh.renderer.bounds.size.z = 1.0f;
	}
	
	public void SetAlpha(float inAlpha)
	{
		return;
		
		UnityEngine.Color tempC = new UnityEngine.Color();
		tempC.a=inAlpha;
		tempC.r=myColour.cRed;
		tempC.g=myColour.cGreen;
		tempC.b=myColour.cBlue;
		
/*		if (materialForColourAndAlpha == null)
		{
			materialForColourAndAlpha = new Material(Shader.Find( "Pi/TransparentOverlay" ));
		}
		
		materialForColourAndAlpha.mainTexture = Default.Namespace.Globals.g_world.guiFont.material.mainTexture;
		materialForColourAndAlpha.color = tempC;
		myObject.renderer.sharedMaterial = materialForColourAndAlpha;*/
		
		myObject.GetComponent<Renderer>().material.color = tempC;
	}
	
	public void SetRotation(float inRot)
	{
//		TextMesh textMesh = myObject.GetComponent<TextMesh>();
		
//		UnityEngine.Quaternion newAngle = Vector3(0, 0, 0);
		
		myObject.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, inRot * Mathf.Rad2Deg );		
	}

	public void RenderAtPosition(Default.Namespace.CGPoint inPosition) 
	{	
		if (shown)
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
		
		myObject.transform.position = newPos;		
		
		Default.Namespace.Globals.renderCounter -= 0.1f;
	}	

	
	
	
	
	
	
}



