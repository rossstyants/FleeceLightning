using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Default.Namespace
{
		[ExecuteInEditMode]
public class ProfilingOut : MonoBehaviour {

				public Text uiText;
				public CrashLandingAppDelegate.Enum2 profilingCategory;

				int numFrames = 10;
				int currentFrame = 0;
				double[] sumFrame = new double[10];

				int readFrame = 4;
				int readFrameCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
						if (!Application.isPlaying)
							uiText = gameObject.GetComponent<Text>();
						else
						{
								readFrameCount++;
								if (readFrameCount != readFrame)
										return;

								readFrameCount = 0;

								int catInt = (int)profilingCategory;
								double time = Globals.g_main.profileTime[catInt+1] - Globals.g_main.profileTime[catInt];

								sumFrame[currentFrame] = time;
								currentFrame++;
								if (currentFrame == 10)
										currentFrame = 0;
										
								double sum = 0;
								for(int i = 0; i < 10; i++)
								{
										sum += sumFrame[i];
								}
								sum /= 10.0f;

//								sum /= 1000.0f;

								string textString = sum.ToString("F4") + profilingCategory.ToString();
								uiText.text = textString;
						
						}

	}
}
}
