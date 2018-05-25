using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Default.Namespace{
public class AchievementPanel : MonoBehaviour {

		public Text achievementName;
		public Text achievementDescription;
	public GameObject achievementDetailsParent;
	public AchievementDetails[] achievementDetailsList;

	//-------------------------------------------
	void Awake () 
	{
		achievementDetailsList = achievementDetailsParent.GetComponentsInChildren<AchievementDetails>();
	}

	//-------------------------------------------
	void Start () 
	{
	
	}
	
	//-------------------------------------------
	void Update () 
	{
	
	}

	//----------------------------------------------
				public AchievementDetails GetAchievementDetails(Profile.Enum2 inAchievement)
	{
		for (int i = 0; i < achievementDetailsList.Length; i++)
		{
			if (achievementDetailsList[i].achievementType == inAchievement)
			{
				return achievementDetailsList[i];
			}
		}

		Ross_Utils.Assert(false);

		return achievementDetailsList[0];
	}

	//-------------------------------------------
				public void SetAchievementDetails (Profile.Enum2 inAchievement) 
	{
		AchievementDetails achDetails = this.GetAchievementDetails(inAchievement);

//		achievementName.text = achDetails.achievementName;
		achievementDescription.text = achDetails.achievementDescription;

//		if ((inAchievement == GameCenterWrapper.AchievementType.GetFreeSonicScares) ||
//			(inAchievement == GameCenterWrapper.AchievementType.Collect100FrogSpawn_GetFreeToken)||
//			(inAchievement == GameCenterWrapper.AchievementType.GetFreeHyperHops))
//		{
//			achievementName.text = "FREE * FREE * FREE";
//		}
//		else
			achievementName.text = "ACHIEVEMENT";

//			achievementName.gameObject.SetActive(!achDetails.dontShowHeading);
	}

}
}