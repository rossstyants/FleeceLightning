//-----------------------------------------------------------------------------
// Green Ant Games Frog Hop
// (c) Copyright - Green Ant Games Limited 2014
//
// Original author: Ross Styants
//
//
//
//
//-----------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

namespace Default.Namespace
{
public static class GameCenterWrapper
{
//	void Awake()
//	{
//		
//	}

	public enum AchievementType
	{
		LoopTheFish = 0,
	}

	//------------------------------------------------------------------------------------------------
	public static void Authenticate()
	{
						#if UNITY_ANDROID
						#else
						GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
						#endif
	    // Authenticate and register a ProcessAuthentication callback
	    // This call needs to be made before we can proceed to other calls in the Social API
        Social.localUser.Authenticate (ProcessAuthentication);
    }

				//------------------------------------------------------------------------------------------------
				public static void ShowAchievementUI()
				{
						#if UNITY_ANDROID

						//		if (!GoogleGPGS.Instance().IsUserLoggedIn())
						//		{
						//			GoogleGPGS.Instance().Login();
						//		}
						//
						//
						////		string thisLeaderboardCode = GameCenterWrapper.GetGoogleLevelCode(Globals.g_gameGUI.selectedLevel);
						//		GoogleGPGS.Instance().ShowAchievements();

						Social.ShowAchievementsUI();

						#else
						Social.ShowAchievementsUI();
						#endif

				}
				//------------------------------------------------------------------------------------------------
				public static void ShowLeaderboardUI(int levelId)
				{
						#if UNITY_ANDROID

						//		if (!GoogleGPGS.Instance().IsUserLoggedIn())
						//		{
						//			GoogleGPGS.Instance().Login();
						//		}
						//
						//
//						string thisLeaderboardCode = GameCenterWrapper.GetGoogleLevelCode(Globals.g_gameGUI.selectedLevel);
						//		GoogleGPGS.Instance().ShowLeaderboard(thisLeaderboardCode);

//						if (Globals.g_mainLoop.state == MainLoop.State.kStartScreen)
//						Social.ShowLeaderboardUI();
//						else
//						GooglePlayGames.PlayGamesPlatform.Instance.ShowLeaderboardUI(thisLeaderboardCode);

						//		Social.ShowLeaderboardUI();

						#else
						if (levelId == -1)
							Social.ShowLeaderboardUI();
						else
						{
//								string leaderboardString = 
								string leaderboardString = ((Globals.g_world.frontEnd).profile).GetLeaderboardId(levelId);

								GameCenterPlatform.ShowLeaderboardUI(leaderboardString,TimeScope.AllTime);
							Social.ShowLeaderboardUI();
						}

						#endif


				}


	//------------------------------------------------------------------------------------------------
	public static string GetGoogleAchievementCode(int achievementId)
	{
		string[] achCodes = {
			"CgkI44fNtdoOEAIQTg",
		};

		return achCodes[achievementId];
	}
						
	//------------------------------------------------------------------------------------------------
	public static string GetGoogleLevelCode(int levelId)
	{
		string[] levelCodes = {

			"CgkI44fNtdoOEAIQAA"
			,"CgkI44fNtdoOEAIQOw"};

		string thisLeaderboardCode = levelCodes[levelId];

		return thisLeaderboardCode;
	}

	//------------------------------------------------------------------------------------------------
	public static void ReportAchievement_BannerOnly(AchievementType inType)
	{
//		Globals.g_achievementQueue.ShowAchievement(inType);
	}

	public static void ReportAchievement(string achievementStringIOS)
	{

#if UNITY_EDITOR
		return;
#endif

#if UNITY_IOS



		Social.ReportProgress(achievementStringIOS, 100.0f, (bool success) => {});	
#else
//		GoogleGPGS.Instance().UnlockAchievement(achievementStringAndroid);
#endif
	}


	//------------------------------------------------------------------------------------------------
	public static void ReportScore(long inVal, string leaderboardId)
	{
		bool inEditor = false;
		
#if UNITY_EDITOR
		inEditor = true;
#endif

//		Kongregate.SubmitStatistic("Score",(int)inVal);

		if (!inEditor)
		{
		// Authenticate and register a ProcessAuthentication callback
	    // This call needs to be made before we can proceed to other calls in the Social API
 //       Social.Active.ReportScore (inVal, "Best_Score_Licky", success => {

#if UNITY_IPHONE			

			Debug.Log("Report score to " + leaderboardId + " : " + inVal);

			Social.ReportScore (inVal, leaderboardId, success => {
					Debug.Log(success ? "Reported score successfully" : "Failed to report score");
				});
#else

//			if (GoogleGPGS.Instance().IsUserLoggedIn())
//			{
//				string levelCode = GameCenterWrapper.GetGoogleLevelCode(Globals.g_gameGUI.selectedLevel);
//
//				GoogleGPGS.Instance().SubmitScore(levelCode,inVal * 10);
//
//			}
			
#endif
		}
	}

	//------------------------------------------------------------------------------------------------
    // This function gets called when Authenticate completes
    // Note that if the operation is successful, Social.localUser will contain data from the server. 
    public static void ProcessAuthentication (bool success) 
	{
        if (success) 
		{
            Debug.Log ("Authenticated, loading leaderboard");

            // Request loaded achievements, and register a callback for processing them
//            Social.LoadAchievements (ProcessLoadedAchievements);

//			ILeaderboard leaderboard = Social.CreateLeaderboard();
//#if UNITY_IPHONE
//
//			leaderboard.id = "indeep_101";
//#else
//			leaderboard.id = "CgkIqb-bqeIPEAIQAQ";
//#endif
		
		}
        else
            Debug.Log ("Failed to authenticate");
    }
}
}
