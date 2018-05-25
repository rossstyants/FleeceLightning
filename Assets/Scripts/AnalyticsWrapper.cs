using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Default.Namespace;


public class AnalyticsWrapper : MonoBehaviour {

	//----------------------------------------------------
	void Awake () 
	{
				Globals.g_analytics = this;
	}
				
	//----------------------------------------------------
	public void StartRace () 
	{
				string controlTypeString = "Thumb";

				if (((Globals.g_world.frontEnd).profile).preferences.controlTilt) 
						controlTypeString = "Tilt";
				else 
				{
						if (((Globals.g_world.frontEnd).profile).preferences.controlFinger) 
								controlTypeString = "Finger";
				}


				string musicOnString = "False";
				if (((Globals.g_world.frontEnd).profile).preferences.musicOn) 
						musicOnString = "True";

				string fxOnString = "False";
				if (((Globals.g_world.frontEnd).profile).preferences.soundFxOn) 
						fxOnString = "True";

				string ghostOnString = "False";
				if (((Globals.g_world.frontEnd).profile).preferences.ghostOn) 
						ghostOnString = "True";

				CallCustomEvent("PressRace", new Dictionary<string, object>
						{
								{ "ControlMethod", controlTypeString },
								{ "MusicOn", musicOnString },
								{ "FXOn", fxOnString },
								{ "GhostOn", ghostOnString },
						});		
	}

		//----------------------------------------------------
		public void UnlockNewStage (int cupId) 
		{
				cupId++;

//				playingLevel++;
//				string level = playingLevel.ToString();
//				int currentStage = playingLevel / 8;

				int stageNumber =cupId + 1;
				string stageNumberString = stageNumber.ToString();
				string stageName = Globals.g_world.frontEnd.profile.GetCup(cupId).name;


				//				currentStage
				//				the meadow
				//				((Globals.g_world.frontEnd).profile).Cup;

				CallCustomEvent("UnlockNewStage", new Dictionary<string, object>
						{
								{ "StageNumber", stageNumberString },
								{ "StageName",  stageName}
						});		
		}


		//----------------------------------------------------
		void CallCustomEvent (string eventName, IDictionary<string,object> inDict) 
		{		
				Debug.Log("<color=teal>Anaytics: "+eventName+"</color>");

				foreach(KeyValuePair<string,object> kp in inDict)
				{
						Debug.Log("<color=teal>"+kp.Key+" : "+kp.Value.ToString()+"</color>");
				}

				Analytics.CustomEvent(eventName,inDict);		
		}

		//----------------------------------------------------
		public void CompleteRace (int playingLevel, int playerFinishPosition) 
		{
				playingLevel++;
				string level = playingLevel.ToString();
				int currentStage = playingLevel / 8;

				int stageNumber =currentStage + 1;
				string stageNumberString = stageNumber.ToString();
				string stageName = Globals.g_world.frontEnd.profile.GetCup(currentStage).name;

				int numApplesThisRace = 0;
				if (playerFinishPosition == 1)
						numApplesThisRace = 3;
				else if (playerFinishPosition == 2)
						numApplesThisRace = 2;
				else if (playerFinishPosition == 3)
						numApplesThisRace = 1;

				string applesString = numApplesThisRace.ToString();

//				currentStage
//				the meadow
//				((Globals.g_world.frontEnd).profile).Cup;

				CallCustomEvent("CompleteLevel", new Dictionary<string, object>
						{
								{ "StageNumber", stageNumberString },
								{ "StageName",  stageName},
								{ "Level", level },
								{ "Apples", applesString },
						});		
		}

	//----------------------------------------------------
	void Update () {
		
	}
}
