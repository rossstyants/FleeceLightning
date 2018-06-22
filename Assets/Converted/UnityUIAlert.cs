using UnityEngine;
using System;

namespace Default.Namespace
{
    public enum  UnityUIAlertType {
        e_RateMe,
        e_StageLocked,
        e_FinalWellDone,
        e_Quit,
    }

    public class UnityUIAlert
    {
		public const int kMaxButtons = 3;
		public bool visible;
		bool fadingIn;
		bool fading;
		float fadeValue;
		float boxWidth;
		float boxHeight;
		float titleHeight;
		
		FrontEndQuery query = new FrontEndQuery();

		public class UnityUIAlertInfo
		{
	        public UnityUIAlertType type;
			public int numButtons;
			public string title;
			public string message;
			public string[] buttonString = new string[kMaxButtons];
			public float textScale;
			public bool useNSStringAnyway;
		};

		public UnityUIAlertType type;
        public CGPoint position;
		public int numButtons;
		public string title;
		public string message;
		public string[] buttonString = new string[kMaxButtons];

		public UnityUIAlert()
        {
			visible = false;
		}

		public void DoItWithQuery (UnityUIAlertInfo info)
		{
			FrontEndQuery.QueryInfoNew nqInfo = new FrontEndQuery.QueryInfoNew();
			
            nqInfo.newStyleWithAtlas = false;
            
			if (info.title == "")
				nqInfo.queryText = info.message;
			else
				nqInfo.queryText = info.title + "\n\n" + info.message;
			
			nqInfo.useNSStringForAnyLanguage = info.useNSStringAnyway;
			nqInfo.backdropTexture = Globals.g_world.frontEnd.GetButtonTexture((int)FrontEnd.Enum.kButtonTexture_QueryBackdrop);
            nqInfo.position.x = 160.0f;
            nqInfo.position.y = 200.0f;
            nqInfo.inTextScale = 28.0f * info.textScale;
            nqInfo.boxDimensions = Utilities.CGSizeMake(260.0f, 100.0f);
            nqInfo.yesButton = null;
            nqInfo.noButton = null;
			nqInfo.backdropId = 0;
			nqInfo.numButtons = info.numButtons;
			nqInfo.inAtlas = Globals.g_world.GetAtlas((int)AtlasType.kAtlas_FeelGood);
			nqInfo.dimOverlayTexture = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTextureDimOverlay);
			nqInfo.scale = 0.86f;
			for (int i = 0; i < nqInfo.numButtons; i++) 
			{
				nqInfo.buttonString[i] = info.buttonString[i];			
			}
			
			query.InitialiseNew(nqInfo);
		}
		
		public void Show (UnityUIAlertInfo info)
		{
				type = info.type;
				title = info.title;
				message = info.message;
			
            if (!Globals.g_world.DoesCurrentLanguageUseNSString()) 
			{
				Debug.Log ("query.SetFontP1P2 " + Globals.g_world.font.ToString());
				
				query.SetFontP1P2(Globals.g_world.font, Globals.g_world.GetAtlas( AtlasType.kAtlas_FontLines), Globals.g_world.GetAtlas(
                  AtlasType.kAtlas_FontColours));
			}
			
			
			this.DoItWithQuery(info);

			query.ShowForUIAlert();
				visible = true;
			return;
			
			type = info.type;
				visible = true;
				boxWidth = 240.0f;
				boxHeight = 130.0f;
				titleHeight = 30.0f;

				numButtons = info.numButtons;
				for (int i = 0; i < numButtons; i++) {
						buttonString [i] = info.buttonString [i];
				}
				title = info.title;
				message = info.message;

				fadingIn = true;
				fadeValue = 0.0f;

			if (title == "") 
			{
				titleHeight = 0.0f;
			}
			
				titleHeight *= (Screen.height / 480.0f);
				boxHeight *= (Screen.height / 480.0f);
				boxWidth *= (Screen.width / 320.0f);

        }

        public void Hide(float waitToHide)
        {
			query.Hide(waitToHide);
			return;
			
//			fading = true;
//			fadeValue = 1.0f;
        } 
		
        public void HandleTouch (MyTouch inTouch)
		{
			if (inTouch.phase != TouchPhase.Began)
				return;

			query.HandleTap(inTouch.position);
			
			if (query.chosenButton != QueryButton.nNothingPressedYet)
			{
				this.ButtonPressed((int)query.chosenButton);	
			}
		}		

		void ButtonPressed (int buttonId)
		{
			switch (type) {
				case UnityUIAlertType.e_Quit:
				{
					if (buttonId == 0)
						Application.Quit();
					
					this.Hide(0.25f);
				}
				break;
				case UnityUIAlertType.e_FinalWellDone:
				{
						Globals.g_world.frontEnd.AlertViewClickedButtonAtIndex();
					this.Hide(0.25f);
				}
				break;
				case UnityUIAlertType.e_RateMe:
				{
	                Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
	                if (buttonId == 0) {
					
//					string urlString = "market://details?id=" + "com.GreenAntGames.Runner";
					
					#if UNITY_IPHONE

//												string urlString = "itms-apps://itunes.apple.com/gb/app/in-deep/id1084696451?mt=8";
//												string urlString = "itms-apps://itunes.apple.com/shaun-sheep-fleece-lightning/id460905456?mt=8";
//												string urlString = "itms-apps://itunes.apple.com/shaun-sheep-fleece-lightning/id460905456?mt=8";
												string urlString = "itms-apps://itunes.apple.com/gb/app/shaun-sheep-fleece-lightning/id460905456?mt=8";

					#endif

					#if UNITY_ANDROID		
					


					string urlString = "";
					

						switch(BuildBoss.Instance.buildType)
						{
						case BuildBoss.BuildTypeEnum.GOOGLE_PLAY:
							urlString = "market://details?id=" + BuildBoss.Instance.googlePlayPackageName;
							break;
						case BuildBoss.BuildTypeEnum.AMAZON:
							urlString = "market://details?id=" + BuildBoss.Instance.amazonPackageName;
							break;
						case BuildBoss.BuildTypeEnum.AMAZON_SUBSCRIPTION:
							urlString = "market://details?id=" + BuildBoss.Instance.amazonSubscriptionPackageName;
							break;
						default:
							urlString = "market://details?id=" + "com.chillingo.fleecelightning.android.rowgplay";
							break;
						}



//					switch(Globals.g_main.BUILDTYPE)
//					{
//					case BuildTypeEnum.kWW:
//						urlString = "market://details?id=" + "com.chillingo.fleecelightning.android.ww";
//						break;
//					case BuildTypeEnum.kAJAKINDLE:
//						urlString = "market://details?id=" + "com.chillingo.fleecelightning.android.ajakindle";
//						break;
//					case BuildTypeEnum.kROWKINDLE:
//						urlString = "market://details?id=" + "com.chillingo.fleecelightning.android.rowkindle";
//						break;
//					case BuildTypeEnum.kSAMSUNG:
//						urlString = "market://details?id=" + "com.ea.android.fleecelightning.rowsamsung";
//						break;
//					case BuildTypeEnum.kAJAGPLAY:
//						urlString = "market://details?id=" + "com.chillingo.fleecelightning.android.ajagplay";
//						break;
//					case BuildTypeEnum.kROWGPLAY:
//						urlString = "market://details?id=" + "com.chillingo.fleecelightning.android.rowgplay";
//						break;
//					}					
					
//					Application.OpenURL(urlString);
					
			#endif

												Application.OpenURL(urlString);		


	                   // NSURL //url = NSURL.URLWithString("itms-apps://itunes.com/apps/fleecelightning");
	                    //(UIApplication.SharedApplication()).OpenURL(url);
	                    savedInfo.numRacesWithoutBeingAskedToRate = -1;
	                }
	                else if (buttonId == 1) 
					{
					savedInfo.numRacesWithoutBeingAskedToRate = 0;

				}
	                else if (buttonId == 2) {

					savedInfo.numRacesWithoutBeingAskedToRate = -1;
	                }

               		((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
	                ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
					this.Hide(0.25f);
				}
				break;
			default:
			{
				this.Hide(0.25f);
			}
				break;
			}
		}
        public void Update ()
		{
			query.UpdateForUIAlert();
			
			if (visible)
			{
				if (query.state == QueryState.e_Inactive)
				{
					visible = false;
				}
			}
		}

        public void Render ()
		{
//			query.RenderNewStyle();
			query.RenderForUIAlert();
		}
		
        public void OnGUI ()
		{
			return;
		}
    }
}
