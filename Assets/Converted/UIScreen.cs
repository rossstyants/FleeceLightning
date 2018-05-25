using UnityEngine;
using System.Collections;

namespace Default.Namespace
{
public class UIScreen {

	public static CGRect bounds;


	// Use this for initialization
	public static void Start () {
		bounds.Origin.x = 0.0f;
		bounds.Origin.y = 0.0f;
			
			bounds.Size.Width = 320.0f;
			bounds.Size.Height = 480.0f;

			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				bounds.Size.Width *= 2.0f;
				bounds.Size.Height *= 2.0f;
			}

		}

		
	// Update is called once per frame
	public void Update () {
	
	}
}
}