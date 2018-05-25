// Shader by π 18.9.12

Shader "Pi/Additive" {
	Properties {
//		_Color ("(internal)color", Color) = (1,1,1, 0.0)
		_MainTex ("Greyscale+Alpha", 2D) = "white" {}
	}
	SubShader 
	{
		Tags { "Queue" = "Transparent" }

		BindChannels
		{
			Bind "vertex", vertex
			Bind "texcoord", texcoord
			Bind "color", color
		}


		ZWrite Off
		ZTest Always
		
		Blend SrcAlpha One
//		Blend SrcAlpha OneMinusSrcAlpha				
	
		Pass 
		{		
			// Use texture alpha to blend up to white ( = full illumination )
			SetTexture[_MainTex]
			{
				
				combine texture  * primary
				
				
				// Pull the color property into this blender
				
//				constantColor[_Color]
				
				
				// And use the texture's alpha to blend between it and o color
				// previous will be BLACK 
				//combine  constant lerp( texture ) previous ,  texture * constant
	//			combine  texture * constant// alpha, texture // primary * texture alpha,  primary alpha
			}
		}
	}
} 
