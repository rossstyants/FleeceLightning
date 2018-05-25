// Shader by π 18.9.12

Shader "Pi/TransparentOverlay" {
	Properties {
		//_Color ("(internal)color", Color) = (0.5,0.5,0.5, 0.5)
		//_Color ("Main Color", Color) = (1,1,1, 0.5)
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
		
		
		ZWrite On
		ZTest Always

		Blend SrcAlpha OneMinusSrcAlpha	
		
//		Lighting O
//		ColorMaterial AmbientAndDiffuse
//		Material
//		{
//			Ambient[_Color]
//			Diffuse[_Color]
//		}
		
		Pass
		{
			// Use texture alpha to blend up to white ( = full illumination )
			SetTexture[_MainTex]
			{
				// Pull the color property into this blender
//				constantColor[_Color]
					
//				Combine texture * primary, texture * primary					
				combine texture  * primary
//				combine texture * constant
										
//				combine constant Lerp(constant) primary
				
				//combine  texture * constant// alpha, texture // primary * texture alpha,  primary alpha
//				combine  primary * texture alpha Double // alpha, texture // primary * texture alpha,  primary alpha
			}
	//		SetTexture [_MainTex] 
		//	{
	      //      constantColor [_Color]
    	    //    Combine previous * constant DOUBLE, previous * constant
        	//} 
			
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
