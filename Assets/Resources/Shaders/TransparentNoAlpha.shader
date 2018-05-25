// Shader by π 18.9.12

Shader "Pi/TransparentNoAlpha" {
	Properties {
		//_Color ("(internal)color", Color) = (1,1,0, 0.1)
		_MainTex ("Greyscale+Alpha", 2D) = "white" {}
	}
	SubShader 
	{
		Tags { "Queue" = "Transparent" }

		ZWrite On
		ZTest Always
				
		Pass 
		{
	//		Blend One One			
			Blend SrcAlpha OneMinusSrcAlpha	
		
			// Use texture alpha to blend up to white ( = full illumination )
			SetTexture[_MainTex]
			{
				// Pull the color property into this blender
				//constantColor[_Color]
				
				
				// And use the texture's alpha to blend between it and o color
				// previous will be BLACK 
				//combine  constant lerp( texture ) previous ,  texture * constant
				combine  texture //* constant// alpha, texture // primary * texture alpha,  primary alpha
			}
		}
	}
} 
