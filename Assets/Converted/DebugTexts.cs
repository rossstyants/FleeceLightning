using UnityEngine;
using System.Collections;

namespace Default.Namespace
{	
    public class DebugTexts
    {
		public enum DebugTextConstants
		{
			kMaxPerFrame = 20
		}
		
		static int numToShowThisFrame;
		static TextMeshWrapper[] texts = new TextMeshWrapper[(int)DebugTextConstants.kMaxPerFrame];

		public static void Initialise()
        {
			for (int i = 0; i < (int)DebugTextConstants.kMaxPerFrame; i++)
			{
				texts[i] = new TextMeshWrapper("debugText"+i.ToString());				
			}
		}		

		public static void StartUpdate()
        {
			numToShowThisFrame = 0;
		}		

		public static void AddText(string inDesc, int inVal)
        {
			if (numToShowThisFrame == (int)DebugTextConstants.kMaxPerFrame)
			{
				return;
			}
			
			texts[numToShowThisFrame].SetWords(inDesc + " : " + inVal.ToString());
			texts[numToShowThisFrame].SetFontSize(10.0f);
			texts[numToShowThisFrame].SetColour(Constants.kColourWhite);;
			numToShowThisFrame++;
		}	
		
		public static void Render()
        {
			float yPos = 25.0f;
			
			for (int i = 0; i < (int)DebugTextConstants.kMaxPerFrame; i++)
			{
				texts[i].StopRender();		
			}
			
			for (int i = 0; i < numToShowThisFrame; i++)
			{
				texts[i].Show();
				texts[i].RenderAtPosition(Utilities.CGPointMake(100.0f,yPos));
				yPos += 17.0f;
			}
		}		
		
	}
}
