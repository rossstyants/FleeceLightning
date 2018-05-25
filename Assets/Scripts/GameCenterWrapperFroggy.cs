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

namespace Default.Namespace
{

public static class GameCenterWrapperFroggy
{
//	void Awake()
//	{
//		
//	}

	public enum AchievementType
	{
		LoopTheFish = 0,
		TheFastAndTheFilius,
		Tadpole,
		TadpoleWithLegs,
		YoungFrog,
		FullGrownFilius,
		WhosTheFrog,
		FastEddy,
		FlyingFrog,
		UltimateAmphibian,	//FRACH_010
		UnlockLevel6,
		AllStarsLevel3,
		Level9NoObstacles,
		Level15Time,
		UnlockLevel2,		//FRACH_015
		UnlockLevel54,
		NoSpawnLevel12,
		Collect100FrogSpawn,
		Collect20FrogSpawn,
		Collect1000FrogSpawn,	//FRACH_020
		Collect100FrogSpawn_GetFreeToken,
		GetFreeSonicScares,
		GetFreeHyperHops,
	}

	public static void Authenticate()
	{
//		#if UNITY_ANDROID
//
//		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder();
////			// enables saving game progress.
////			.EnableSavedGames()
////			// registers a callback to handle game invitations received while the game is not running.
////			.WithInvitationDelegate(<callback method>)
////			// registers a callback for turn based match notifications received while the
////			// game is not running.
////			.WithMatchDelegate(<callback method>)
////			// require access to a player's Google+ social graph (usually not needed)
////			.RequireGooglePlus()
////			.Build();
//
////		PlayGamesPlatform.InitializeInstance(config);
////		// recommended for debugging:
////		PlayGamesPlatform.DebugLogEnabled = true;
//		// Activate the Google Play Games platform
//		PlayGamesPlatform.Activate();
//
//		#endif

		#if UNITY_ANDROID
		// Select the Google Play Games platform as our social platform implementation
//		GooglePlayGames.PlayGamesPlatform.Activate();
		#endif


	    // Authenticate and register a ProcessAuthentication callback
	    // This call needs to be made before we can proceed to other calls in the Social API
        Social.localUser.Authenticate (ProcessAuthentication);
    }

	public static string GetGoogleAchievementCode(int achievementId)
	{
		string[] achCodes = {

			"CgkI44fNtdoOEAIQTQ",
			"CgkI44fNtdoOEAIQQQ",
			"CgkI44fNtdoOEAIQQg",
			"CgkI44fNtdoOEAIQRw",
			"CgkI44fNtdoOEAIQSg",
			"CgkI44fNtdoOEAIQSw",
			"CgkI44fNtdoOEAIQSQ",
			"CgkI44fNtdoOEAIQRg",
			"CgkI44fNtdoOEAIQSA",
			"CgkI44fNtdoOEAIQTw",
			"CgkI44fNtdoOEAIQPg",
			"CgkI44fNtdoOEAIQPQ",
			"CgkI44fNtdoOEAIQQA",
			"CgkI44fNtdoOEAIQRA",
			"CgkI44fNtdoOEAIQPA",
			"CgkI44fNtdoOEAIQTA",
			"CgkI44fNtdoOEAIQQw",
			"CgkI44fNtdoOEAIQRQ",
			"CgkI44fNtdoOEAIQPw",
			"CgkI44fNtdoOEAIQTg",
		};

		return achCodes[achievementId];
	}

	public static string GetGoogleLevelCode(int levelId)
	{
		string[] levelCodes = {

			"CgkI44fNtdoOEAIQAA"
			,"CgkI44fNtdoOEAIQAQ"
			,"CgkI44fNtdoOEAIQAg"
			,"CgkI44fNtdoOEAIQAw"
			,"CgkI44fNtdoOEAIQBA"
			,"CgkI44fNtdoOEAIQBQ"
			,"CgkI44fNtdoOEAIQBg"
			,"CgkI44fNtdoOEAIQBw"
			,"CgkI44fNtdoOEAIQCA"
			,"CgkI44fNtdoOEAIQCQ"
			,"CgkI44fNtdoOEAIQCg"
			,"CgkI44fNtdoOEAIQCw"
			,"CgkI44fNtdoOEAIQDA"
			,"CgkI44fNtdoOEAIQDQ"
			,"CgkI44fNtdoOEAIQDg"
			,"CgkI44fNtdoOEAIQDw"
			,"CgkI44fNtdoOEAIQEA"
			,"CgkI44fNtdoOEAIQEQ"
			,"CgkI44fNtdoOEAIQEg"
			,"CgkI44fNtdoOEAIQEw"
			,"CgkI44fNtdoOEAIQFA"
			,"CgkI44fNtdoOEAIQFQ"
			,"CgkI44fNtdoOEAIQFg"
			,"CgkI44fNtdoOEAIQFw"
			,"CgkI44fNtdoOEAIQGA"
			,"CgkI44fNtdoOEAIQGQ"
			,"CgkI44fNtdoOEAIQGg"
			,"CgkI44fNtdoOEAIQGw"
			,"CgkI44fNtdoOEAIQHA"
			,"CgkI44fNtdoOEAIQHQ"
			,"CgkI44fNtdoOEAIQHg"
			,"CgkI44fNtdoOEAIQHw"
			,"CgkI44fNtdoOEAIQIA"
			,"CgkI44fNtdoOEAIQIQ"
			,"CgkI44fNtdoOEAIQIg"
			,"CgkI44fNtdoOEAIQIw"
			,"CgkI44fNtdoOEAIQJA"
			,"CgkI44fNtdoOEAIQJQ"
			,"CgkI44fNtdoOEAIQJg"
			,"CgkI44fNtdoOEAIQJw"
			,"CgkI44fNtdoOEAIQKA"
			,"CgkI44fNtdoOEAIQKQ"
			,"CgkI44fNtdoOEAIQKg"
			,"CgkI44fNtdoOEAIQKw"
			,"CgkI44fNtdoOEAIQLA"
			,"CgkI44fNtdoOEAIQLQ"
			,"CgkI44fNtdoOEAIQLg"
			,"CgkI44fNtdoOEAIQLw"
			,"CgkI44fNtdoOEAIQMA"
			,"CgkI44fNtdoOEAIQMQ"
			,"CgkI44fNtdoOEAIQMg"
			,"CgkI44fNtdoOEAIQMw"
			,"CgkI44fNtdoOEAIQNA"
			,"CgkI44fNtdoOEAIQNQ"
			,"CgkI44fNtdoOEAIQNg"
			,"CgkI44fNtdoOEAIQNw"
			,"CgkI44fNtdoOEAIQOA"
			,"CgkI44fNtdoOEAIQOQ"
			,"CgkI44fNtdoOEAIQOg"
			,"CgkI44fNtdoOEAIQOw"};

		string thisLeaderboardCode = levelCodes[levelId];

		return thisLeaderboardCode;
	}

				public static void ReportAchievement_BannerOnly(Profile.Enum2 inType)
	{
		Globals.g_achievementQueue.ShowAchievement(inType);
	}

	public static void ReportAchievement(AchievementType inType)
	{
		string achievementStringIOS = "";
		string achievementStringAndroid = "";

		int intType = (int)inType;
		intType++;
		achievementStringIOS = "FRACH_0" + intType.ToString("00");
		achievementStringAndroid = GameCenterWrapper.GetGoogleAchievementCode((int)inType);

//		if (!Globals.g_loadSave.achievementGot[(int)inType])
//		{
//			Globals.g_achievementQueue.ShowAchievement(inType);
//			Globals.g_loadSave.achievementGot[(int)inType] = true;
//		}

#if UNITY_EDITOR
		return;
#endif

#if UNITY_IOS
		Social.ReportProgress(achievementStringIOS, 100.0f, (bool success) => {});	
#else

		Social.ReportProgress(achievementStringAndroid, 100.0f, (bool success) => {});	

		//		GoogleGPGS.Instance().UnlockAchievement(achievementStringAndroid);
#endif
	}

	public static void ReportScore(long inVal)
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

			string leaderboardId;

//			if (Globals.g_mainLoop.gameMode == MainLoop.GameMode.kNormal)
//			{
//				leaderboardId = "101";
//			}
//			else
//			{
//				leaderboardId = "201";
//			}

								int levelId = 1;//Globals.g_gameGUI.selectedLevel + 1;
			leaderboardId = "indeep_1" + levelId.ToString("00");

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

//			string leaderboardId;
//
//			int levelId = Globals.g_gameGUI.selectedLevel + 1;
////			leaderboardId = "indeep_1" + levelId.ToString("00");
//
//			leaderboardId = GameCenterWrapper.GetGoogleLevelCode(Globals.g_gameGUI.selectedLevel);
//
//			Debug.Log("Report score to " + leaderboardId + " : " + inVal);
//
//			Social.ReportScore (inVal, leaderboardId, success => {
//				Debug.Log(success ? "Reported score successfully" : "Failed to report score");
			//});
			
#endif
		}
	}

    // This function gets called when Authenticate completes
    // Note that if the operation is successful, Social.localUser will contain data from the server. 
    public static void ProcessAuthentication (bool success) 
	{
        if (success) 
		{
            Debug.Log ("Authenticated, loading leaderboard");

            // Request loaded achievements, and register a callback for processing them
//            Social.LoadAchievements (ProcessLoadedAchievements);

			ILeaderboard leaderboard = Social.CreateLeaderboard();
#if UNITY_IPHONE

			leaderboard.id = "indeep_101";
#else
			leaderboard.id = "CgkIqb-bqeIPEAIQAQ";
#endif
//			leaderboard.LoadScores (result => {				
//				Debug.Log("Received " + leaderboard.scores.Length + " scores");
//				foreach (IScore score in leaderboard.scores)
//					Debug.Log(score);
//			});		
		
		}
        else
            Debug.Log ("Failed to authenticate");
    }

    // This function gets called when the LoadAchievement call completes
//    public static void ProcessLoadedAchievements (IAchievement[] achievements) 
//	{
//        if (achievements.Length == 0)
//            Debug.Log ("Error: no achievements found");
//        else
//            Debug.Log ("Got " + achievements.Length + " achievements");
//
//        // You can also call into the functions like this
//        Social.ReportProgress ("Achievement01", 100.0, result => {
//            if (result)
//                Debug.Log ("Successfully reported achievement progress");
//            else
//                Debug.Log ("Failed to report achievement");
//        });
//    }
}


//	
//	private List<GameCenterLeaderboard> leaderboards;
//	
//	public bool leaderboardLoaded;
//	bool scoresRequested;
//
//	bool isDisabled = false;
//	
//	void Start () 
//	{
//		Debug.Log ("Start GameCenter");
//		
//		Globals.g_gameCenter = this;
//
//#if UNITY_IPHONE	
//		if (!isDisabled)
//		{
//
//			Utilities.Log ("Try Authenticate");		
//			this.Authenticate();
//		
//		GameCenterManager.categoriesLoaded += delegate( List<GameCenterLeaderboard> leaderboards )
//		{
//			leaderboardLoaded = true;
//			Utilities.Log ("categoriesLoaded is DONE");
//			this.leaderboards = leaderboards;
////			GameCenterBinding.retrieveScores( false, GameCenterLeaderboardTimeScope.AllTime, 1, 25, "Milky_LightYears" );		
//		};
//		
//		GameCenterManager.scoresLoaded += delegate(System.Collections.Generic.List<GameCenterScore> scores) 
//		{
//			Utilities.Log (scores.Count.ToString() + " Scores Got");
//
//			RateTable.RowData rowData = new RateTable.RowData();			
//			
//			int rowMin = 0;
//			int rowMax = scores.Count - 1;
//			if ((rowMax - rowMin) > 2)
//			{
//				rowMax = rowMin + 2;
//			}
//			
//			for (int i = rowMin; i <= rowMax; i++)
//			{
//				Utilities.Log (scores[i].ToString());
//
//				rowData.playerName = scores[i].alias;
//				rowData.rank = scores[i].rank;
//				rowData.score = (int)scores[i].value;
//				Globals.g_rateTable.SetRowData(i,rowData);
//			}
//			
//			Globals.g_rateTable.Show();
//		};
//
//		GameCenterManager.reportScoreFinished += delegate(string stringObj) 
//		{
//			Utilities.Log ("Report score done for " + stringObj);
//			
//			//Need to reload the table?
//			
//			this.LoadLeaderboard();
//					
////			GameCenterBinding.retrieveScores( false, GameCenterLeaderboardTimeScope.AllTime, 1, 25, "Milky_LightYears" );		
//		};
//		}
//#endif
//	}
//	
//	public bool IsPlayerAuthenticated()
//	{
//#if UNITY_IPHONE	
//		if (!isDisabled)
//		{
//		
//		bool isPlayerAuthenticated = GameCenterBinding.isPlayerAuthenticated();
//		
//	//	Utilities.Log ("isPlayerAuthenticated " + isPlayerAuthenticated.ToString());
//
//		return isPlayerAuthenticated;
//		}
//#endif
//
//		return false;
//	}
//	
//	void Update () 
//	{
//	
//	}
//
//	public void RetrieveScores()
//	{
//#if UNITY_IPHONE	
//		if (!isDisabled)
//		{					
//			Utilities.Log ("Try retrieve scores");
//	
////			GameCenterBinding.retrieveScores( false, GameCenterLeaderboardTimeScope.AllTime, 1, 25, "CC_LightYears" );
//			GameCenterBinding.retrieveScoresForPlayerId(GameCenterBinding.playerIdentifier(), "CC_LightYears" );
//		}
//#endif
//
//	}	
//	
//	public void ReportScore(int score)
//	{		
//#if UNITY_IPHONE	
//		if (!isDisabled)
//		{
//				
//		scoresRequested = false;
//		leaderboardLoaded = false;
//		Utilities.Log ("Try report score");
//
//		if ((leaderboards == null) || (leaderboards.Count < 1))
//		{
//			Utilities.Log ("No leaderboard loaded");
//			return;
//		}
//
//		Utilities.Log ("ok reporting");		
//		
//		GameCenterBinding.reportScore(score, "CC_LightYears" );
//		}
//#endif
//
//	}
//	
//	public void UpdateRetrieveLeaderboardScores()
//	{
//#if UNITY_IPHONE	
//		if (!isDisabled)
//		{
//				
//		if (leaderboardLoaded)
//		{
//			if (!scoresRequested)
//			{
//				scoresRequested = true;
//				GameCenterBinding.retrieveScores( false, GameCenterLeaderboardTimeScope.AllTime, 1, 25, "CC_LightYears" );
//			}
//		}
//		}
//#endif
//
//	}
//
//	public void Authenticate()
//	{
//#if UNITY_IPHONE	
//		if (!isDisabled)
//		{
//				
//			GameCenterBinding.authenticateLocalPlayer();
//		}
//#endif
//
//	}
//	
//	
//	public void LoadLeaderboard()
//	{
//#if UNITY_IPHONE	
//		if (!isDisabled)
//		{
//				
////		if (leaderboards != null)
////			return;
//		
//		Utilities.Log ("try loadLeaderboardTitles");
//		GameCenterBinding.loadLeaderboardTitles();
//		Utilities.Log ("got past here");		
//		}
//#endif
//
//	}
//}
}
