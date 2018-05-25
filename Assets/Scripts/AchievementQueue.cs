using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Default.Namespace
{
public class AchievementQueue : MonoBehaviour {

	float showTimer;
	public LagAround achievementPanel;

				public List<Profile.Enum2> achievements;

	//----------------------------------------------
	void Awake () {

		Globals.g_achievementQueue = this;
	}

	//----------------------------------------------
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
//			this.ShowAchievement(GameCenterWrapper.AchievementType.FastEddy);
		}

		if (showTimer > 0.0f)
		{
			showTimer -= Time.deltaTime;
			if (showTimer <= 0.0f)
			{
				achievementPanel.Hide();
			}
		}

		if (achievementPanel.state == LagAround.State.Hidden)
		{
			if (achievements.Count > 0)
			{
				this.ShowPanel(achievements[0]);
				achievements.RemoveAt(0);
			}
		}
	}
		
	//----------------------------------------------
	void ShowPanel(Profile.Enum2 inAchievement)
	{
		showTimer = 4.0f;
		achievementPanel.Show();
		achievementPanel.gameObject.GetComponent<AchievementPanel>().SetAchievementDetails(inAchievement);
	}

	//----------------------------------------------
				public void ShowAchievement (Profile.Enum2 inAchievement) 
	{
		if (achievementPanel.state == LagAround.State.Hidden)
		{
			this.ShowPanel(inAchievement);
		}
		else
		{
			achievements.Add(inAchievement);
		}
	}
}
}