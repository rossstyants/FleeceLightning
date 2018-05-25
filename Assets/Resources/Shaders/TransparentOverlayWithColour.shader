// Shader by π 18.9.12

Shader "Pi/TransparentOverlayWithColour" {
	Properties {
		_Color ("(internal)color", Color) = (1,1,1, 1.0)
		_MainTex ("Greyscale+Alpha", 2D) = "white" {}
	}
	SubShader 
	{
		Tags { "Queue" = "Transparent" }
		
//		ZWrite Off

//		ZTest Less
		ZWrite On
		ZTest Always
		
		// Not actually required to set black
		//Color (0,0,0,0)
		
		//Color [_Color]
		
		// Pixel Out = A*our generated col + B * already there colour
//		Blend one one
		Blend SrcAlpha OneMinusSrcAlpha	
		
		Pass 
		{
			// Use texture alpha to blend up to white ( = full illumination )
			SetTexture[_MainTex]
			{
				// Pull the color property into this blender
				constantColor[_Color]
				
				
				// And use the texture's alpha to blend between it and o color
				// previous will be BLACK 
				//combine  constant lerp( texture ) previous ,  texture * constant
				combine  texture * constant// alpha, texture // primary * texture alpha,  primary alpha
			}
			
//			SetTexture[_] {
	//			combine  previous * primary alpha
		//	}
			
			// Multiply in texture
			//SetTexture [_MainTex] 
			//{
			//	combine previous * texture, texture
			//}
		}
		
	
	}
} 
