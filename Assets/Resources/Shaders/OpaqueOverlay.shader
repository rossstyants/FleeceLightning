// Shader by π 18.9.12

Shader "Pi/OpaqueOverlay" {
	Properties {
		//_Color ("(internal)color", Color) = (1,1,0, 0.1)
		_MainTex ("tehtexure", 2D) = "white" {}
	}
	SubShader 
	{
		Tags { "Queue" = "Background" }
		
		ZWrite Off
		//ZTest Always
		
		// Not actually required to set black
		//Color (0,0,0,0)
		
		//Color [_Color]
		
		// Add on top
		Blend one zero
			
		
		Pass 
		{
			// Use texture alpha to blend up to white ( = full illumination )
			SetTexture[_MainTex]
			{
				// Pull the color property into this blender
				//constantColor[_Color]
				
				
				// And use the texture's alpha to blend between it and o color
				// previous will be BLACK 
				//combine  constant lerp( texture ) previous ,  texture * constant
				combine texture //primary * texture alpha,  primary alpha
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
