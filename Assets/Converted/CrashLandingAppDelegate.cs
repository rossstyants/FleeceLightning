using UnityEngine;
using UnityEngine.UI;
using System;

//namespace Default.Namespace
//{
    public enum  State {
        e_StandBy = 0,
        e_Running,
        e_Success,
        e_Failure
    }

		public enum TextureResolutionEnum{

		kTextureResolution_Low,
		kTextureResolution_High,
	
	};


//		public enum BuildTypeEnum{
//			kWW,
//			kAJAKINDLE,
//			kROWKINDLE,
//			kSAMSUNG,
//			kAJAGPLAY,
//			kROWGPLAY
//		};
		


    public class CrashLandingAppDelegate : MonoBehaviour  
    {

		public Default.Namespace.World world;
//		public BuildTypeEnum BUILDTYPE;
	
	
				//public static AndroidJavaClass adcJavaClass;
	
		public LoadADC loadADC;
		public LoadADCQueue loadADCQueue;
	
	bool resourcesLoadedYet;
	
	
	TitleScreens titleScreens;
	
       // public CFTimeInterval lastStartUpdateTime;
		public TextureResolutionEnum  usingTextureResolution;

		//ross is adding these things in now.. because we want to opaquely put down tiles
		//but when they are sprites... e.g. on bridge... we want them to go with transparent
		//shader so they are not behind everything...
		public Material grassSpriteAtlas;
		public Material mudSpriteAtlas;

        public bool isFraming;
//        public double newLoadingTime;
        public int showFramingTimer;
        public float framePercent;
        public float updatePercent;
        public float renderPercent;
        public float loadingYPos;
        public float loadingYVel;
        public float animTimerX;
//        public Default.Namespace.World world;
        public Default.Namespace.Utilities util;
        public Default.Namespace.Zbar loadingBar;
        public Default.Namespace.Zbar loadingBarPig;
//        public IBOutlet UIWindow window;
       // public MyEAGLView glView;
        //public MyViewController viewController;
       // public UITextField _textField;
        //public UInt32[] _sounds = new UInt32[kNumSounds];
        public bool loadDone;
        public bool doneFirstInit;
        public bool inCrystalSplash;
        public Default.Namespace.CGRect _landerBounds;
        //public UIAccelerationValue[] _accelerometer = new UIAccelerationValue[3];
        public bool _firstTap;
        //public NSTimer _timer;
        //public NSTimer loadingTimer;
        public State _state;
      //  public CFTimeInterval _lastTime;
        public bool _lastThrust;
        //public GLfloat _basePosition;
        //public GLfloat _rotation, _rotationVelocity;
      // public Vector2D _position, _velocity;
       // public float _fuel;
       // public int _score;
        public double initTime;
        public double blink1StartTime;
        public double blink2StartTime;
        public float loadingStartTime;
        public double startLoopTime;
        public double prevStartLoopTime;
       // public CADisplayLink _displayLink;
        public int currentGLMatrixMode;
        public bool upsideDown;

        string emailString;
//        MyViewController g_myViewController;
//        MyEAGLView g_glView;
//        UITextField gameOverTextField;
		long lastStartUpdateTime;
        public long[] profileTime = new long[(int)Enum2.kNumProfilePoints];

		public double[,] timeCount = new double[(int)Enum1.kNumProfileCounts,5];//(int)Enum2.kNumProfilePoints]; 
		int testCount;

        Default.Namespace.ZAtlas loadingAtlas;
        public Default.Namespace.Texture2D_Ross[] _textures = new Default.Namespace.Texture2D_Ross[(int)Enum4.kNumTextures];
        public Billboard[] _billboards = new Billboard[(int)Enum4.kNumTextures];
        
		public CanvasGroup chillingoBoard;

        ////extern CFTimeInterval[] profileTime = new CFTimeInterval[kNumProfilePoints];
        public enum Enum {
            kFrameGapForCheck = 40
        };
        public enum Enum1 {
            kPr_Total = 0,
            kPr_Update,
            kPr_Render,
            kPr_UpdateFlock,
            kPr_UpdateMO,
            kPr_UpdateNGZ,
            kPr_UpdateGameThings,
            kPr_UpdateParticles,
            kPr_RenderTileMap,
            kPr_RenderScene,
            kNumProfileCounts,
        };
        public enum Enum2 {
            kPP_StartUpdate = 0,
            kPP_EndUpdate,
				kPP_StartRender,
				kPP_EndRender,
            kPP_StartTile,
            kPP_EndTile,
            kPP_StartTrees,
            kPP_EndTrees,
            kPP_StartThings,
            kPP_EndThings,
            kPP_StartRenderParticles,
            kPP_EndRenderParticles,
            kPP_StartUpdateFlock,
            kPP_EndUpdateFlock,
            kPP_StartRenderScene,
            kPP_EndRenderScene,
            kPP_UpdateMapObjectsStart,
            kPP_UpdateMapObjectsEnd,
            kPP_UpdateNGZStart,
            kPP_UpdateNGZEnd,
            kPP_StartUpdateGameThings,
            kPP_EndUpdateGameThings,
				kPP_StartUpdateParticles,
				kPP_EndUpdateParticles,
				kPP_StartUpdatePiggies,
				kPP_EndUpdatePiggies,
				kPP_StartUpdateShaun,
				kPP_EndUpdateShaun,

				Start_RenderScene_1,
				End_RenderScene_1,
				Start_RenderScene_2,
				End_RenderScene_2,
				Start_RenderScene_3,
				End_RenderScene_3,
				Start_RenderScene_4,
				End_RenderScene_4,
				Start_RenderScene_5,
				End_RenderScene_5,

				kNumProfilePoints
        };
        public enum Enum3 {
            kSound_Thrust = 0,
            kSound_Start,
            kSound_Success,
            kSound_Failure,
            kNumSounds
        };
        //extern bool (Default.Namespace.Globals.useRetina);
        //extern bool deviceIPad;
        //extern bool Default.Namespace.Globals.deviceIPhone4;
        //extern Default.Namespace.ZAtlas loadingAtlas;
        //extern Texture2D_Ross[] _textures = new Texture2D_Ross[kNumTextures];
        public enum Enum4 {
            kTexture_Title = 0,
            kTexture_GreenAntSplash,
            kTexture_Chillingo,
            kTexture_LoadingBack,
            kTexture_RunningSheep1,
            kTexture_RunningSheep2,
            kTexture_RunningSheep3,
            kTexture_SplashTitle,
            kTexture_Blink,
            kNumTextures
        };
        //extern UITextField gameOverTextField;
        //extern bool Default.Namespace.Globals.bInBackground;
        //extern Default.Namespace.Utilities g_util;
        //extern World Default.Namespace.Globals.g_world;
        //extern MyViewController g_myViewController;
        //extern CrashLandingAppDelegate Default.Namespace.Globals.g_main;
        //extern MyEAGLView g_glView;
        //;
        public bool UpsideDown
        {
            get;
            set;
        }

     /*   public static void Print_free_memory()
        {
            mach_port_t host_port;
            mach_msg_type_number_t host_size;
            vm_size_t pagesize;
            host_port = mach_host_self();
            host_size = sizeof (vm_statistics_data_t) / sizeof (integer_t);
            host_page_size(host_port, pagesize);

//            #if DEBUG_MESSAGES
    //            natural_t mem_used = (vm_stat.Active_count + vm_stat.Inactive_count + vm_stat.Wire_count) * pagesize;
      //          natural_t mem_free = vm_stat.Free_count * pagesize;
        //        natural_t mem_total = mem_used + mem_free;
  //          #endif

        }*/

        static CrashLandingAppDelegate ()
        {
//            if (this == [(int)CrashLandingAppDelegate class]) {
  //              (NSUserDefaults.StandardUserDefaults()).RegisterDefaults(NSDictionary.DictionaryWithObjectForKey(NSArray.Array(), Constants.
    //              KHighScoresDefaultKey));
      //      }
		
		
		
        }

		public void Start () {
				
//		loadADC = new LoadADC();
		
		Application.targetFrameRate = 60;
		
				Default.Namespace.GameCenterWrapper.Authenticate();

//		loadADCQueue = new LoadADCQueue();
		

				// Was the application published before 1st July 2013?
				// If so the preCOPPA option should be set to 'true'
				bool preCOPPA = true;

				// Has your producer specified that a custom skin would be more appropriate?
				// If so then set the useCustomSkin to 'true' and add the required assets 
				// to the XCode project once output
				bool useCustomSkin = false;

				// Initialise the Terms.  
				// This will call the Objective-C code when running on device
//				Terms.initialiseTermsSession(preCOPPA, useCustomSkin, Terms.ComplianceLevel.FULLY_COMPLIANT_CHILD_SAFE_CONTENT);


				print( "Start>>>" );

		StartApp();
		
				print( "Start<<<" );
		
	}

		public void FixedUpdate () 
		{
			RenderScene ();

				#if PROFILING_OUT
				#endif
		}

		public void OnGUI () {
		//	world.OnGUI();
		}


        public static void SetAcceleromterOnOrOff(bool turnItOn)
        {
/*            float accelerometerFrequency;
            if (turnItOn) {
                if (Default.Namespace.Globals.g_world.artLevel == 0) accelerometerFrequency = 15.0f;
                else {
                    accelerometerFrequency = 30.0f;
                }

            }
            else {
                accelerometerFrequency = 1.0f;
            }
		 */
          //  (UIAccelerometer.SharedAccelerometer()).SetUpdateInterval((1.0 / accelerometerFrequency));
        }

        public void StartApp()
        {
			//return;
		
			titleScreens = new TitleScreens();
			titleScreens.StartApp();
			
			Default.Namespace.Globals.g_main = this;
			
			float numPixels = Screen.width * Screen.height;
			
			Debug.Log("num pixels = " + numPixels + " w:" + Screen.width + " h:" + Screen.height);
			
			//480x800
//				#if UNITY_IOS
//				if (true)
//				#else
//				if (numPixels >= 384000)
//					#endif	
				if(true)
				{		
				Debug.Log("setting up in HIGH RES mode.");
				usingTextureResolution = TextureResolutionEnum.kTextureResolution_High;
			}
			else
			{
				Debug.Log("setting up in LOW RES mode.");
				usingTextureResolution = TextureResolutionEnum.kTextureResolution_Low;
			}
			
			Default.Namespace.UIScreen.Start();
			
			Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
			
			if (usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				cam.orthographicSize = 480.0f;
			}		

				float iPadRatio = 0.75f;
				float iPhone4Ratio = 0.666667f;
				float iPhone5Ratio = 0.5625f;

				float aspectRatio =  (float)Screen.width / (float)Screen.height;

				Default.Namespace.Globals.deviceIPad = false;
				Default.Namespace.Globals.deviceIPhone4 = false;
				Default.Namespace.Globals.deviceIPhone5 = false;
				Default.Namespace.Globals.useIPadBackScreens = false;

				//0.5625 = iPhone5s

				if (aspectRatio > 0.7f)
						Default.Namespace.Globals.useIPadBackScreens = true;

				if (aspectRatio < 0.6f)
						Default.Namespace.Globals.deviceIPhone5 = true;


				doneFirstInit = false;
				loadDone = false;
			            loadingStartTime = -1.0f;//DateTime.Now.TimeOfDay.Milliseconds;
			//newLoadingTime = 0.0f;
	 		prevStartLoopTime = 0;
	            Default.Namespace.Utilities.Initialise();
	            Default.Namespace.DebugTexts.Initialise();
	//            Default.Namespace.Colours.Initialise();
	            currentGLMatrixMode = -1;
	            inCrystalSplash = false;
	            initTime = -1;
	            Default.Namespace.Globals.bInBackground = false;
	           // Default.Namespace.CGRect rect = Default.Namespace.UIScreen.bounds;
	            _firstTap = true;
	            showFramingTimer = 0;
	            loadingYPos = 415.0f;
	            loadingYVel = 0.0f;
	            animTimerX = 0.0f;
	            blink1StartTime = -1.0f;
	            blink2StartTime = -1.0f;
					//	usingTextureResolution = TextureResolutionEnum.kTextureResolution_Low;
	
			
	
	      //      #if USE_CRYSTAL
	        //        this.PerformSelectorOnMainThreadWithObjectWaitUntilDone(@selector (initCrystal:), null, false);
	          //  #endif
	
	            _textures[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash] = new Default.Namespace.Texture2D_Ross(false,"LoadingBack.png",true,(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash,LoadADCQueue.AssetType.ktextureStartup);		
//				_textures[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo] = new Default.Namespace.Texture2D_Ross(false,"Chillingo.png",true,(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo,LoadADCQueue.AssetType.ktextureStartup);		
//				_textures[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo] = new Default.Namespace.Texture2D_Ross(chillingoBoard);		
	            _textures[(int)CrashLandingAppDelegate.Enum4.kTexture_Blink] = new Default.Namespace.Texture2D_Ross(false,"antblinking.png",false,(int)CrashLandingAppDelegate.Enum4.kTexture_Blink,LoadADCQueue.AssetType.ktextureStartup);		
				
			_billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash] = new Billboard("startupTextures");		
//			_billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo] = new Billboard("startupTextures");		
			_billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Blink] = new Billboard("startupTextures");		
			
			_billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash].SetTexture2D(_textures[(int)CrashLandingAppDelegate.Enum4.kTexture_GreenAntSplash]);
//			_billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo].SetTexture2D(_textures[(int)CrashLandingAppDelegate.Enum4.kTexture_Chillingo]);
			_billboards[(int)CrashLandingAppDelegate.Enum4.kTexture_Blink].SetTexture2D(_textures[(int)CrashLandingAppDelegate.Enum4.kTexture_Blink]);
					
				float scaleMultiplier = Screen.width / 768.0f;

//				Vector3 scale = chillingoBoard.gameObject.transform.localScale;
//				scale *= scaleMultiplier;
//				chillingoBoard.gameObject.transform.localScale = scale;


	            if (!Default.Namespace.Globals.useRetina) upsideDown = false;
	
	            this.initUINameEntry();
		}

        public void FunctionName()
        {
            if (Default.Namespace.Globals.deviceIPad) {
            }
            else {
            }

        }

        public void ShowDropboxThing()
        {

            #if DROPBOX_ENABLED
            #endif

        }

        public void HideDropboxThing()
        {

            #if DROPBOX_ENABLED
            #endif

        }

/*        bool TextFieldShouldChangeCharactersInRangeReplacementString(UITextField textField, NSRange range, string inString)
        {
            if (textField.Text.Length >= Constants.kMaxCharactersInCustomName && range.Length == 0) {
                return false;
            }
            else {
                return true;
            }

        }*/

        public void initUINameEntry()
        {
          //  Default.Namespace.CGRect frameThing;
            if (Default.Namespace.Globals.deviceIPad) {
            //    frameThing = Default.Namespace.Utilities.CGRectMake(64.0f, 300.0f, 260.0f, 25.0f);
            }
            else {
              //  frameThing = Default.Namespace.Utilities.CGRectMake(32.0f, 160.0f, 260.0f, 25.0f);
            }

//            glView.AddSubview(gameOverTextField);
        }

        public void Dealloc()
        {
            long i;
            for (i = 0; i < (int)Enum4.kNumTextures; ++i) _textures[i] = null;

        }

/*        public void AccelerometerDidAccelerate(UIAccelerometer accelerometer, UIAcceleration acceleration)
        {
            _accelerometer[0] = acceleration.x * Constants.kFilteringFactor + _accelerometer[0] * (1.0 - Constants.kFilteringFactor);
            _accelerometer[1] = acceleration.y * Constants.kFilteringFactor + _accelerometer[1] * (1.0 - Constants.kFilteringFactor);
            _accelerometer[2] = acceleration.Z * Constants.kFilteringFactor + _accelerometer[2] * (1.0 - Constants.kFilteringFactor);
            world.SetAccelerometer(acceleration);
        }*/

/*        public void TextFieldDidEndEditing(UITextField textField)
        {
            (NSUserDefaults.StandardUserDefaults()).SetObjectForKey(textField.Text(), Constants.kUserNameDefaultKey);
            this.SaveScore();
        }

        bool TextFieldShouldReturn(UITextField textField)
        {
            textField.ResignFirstResponder();
            return true;
        }*/
	
			public string GetSuffixForTextureResolution()
		{
			if (usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				return "@2x~iphone";
			}
				
			return "";
		}
		
		
		public string GetFolderPrefixForTextureResolution()
		{
			if (usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				return "Done_HighRes/";
			}
				
			return "Done/";
		}
	
        public void HandleTap(Default.Namespace.CGPoint position)
        {
        }

        public void SaveScore()
        {
        }

        public void DoGLTranslateP1(float x, float y)
        {
            if (Default.Namespace.Globals.deviceIPad) {
                x *= 2.0f;
                x += 64.0f;
                y *= 2.0f;
                y += 32.0f;
                y = 1024.0f - y;
                ////glTranslatef(x * Constants.kScreenMultiplierForShorts, y * Constants.kScreenMultiplierForShorts, 0);
            }
            else {
                ////glTranslatef(x * Constants.kScreenMultiplierForShorts, Constants.kScreenMultiplierForShorts480 - (y * Constants.kScreenMultiplierForShorts), 0)
                  ;
            }

        }
	

        public void RenderLoadingBarItems()
        {
            if (Default.Namespace.Globals.bInBackground) return;
		
			titleScreens.Render();
		
        }

        public void SetGLMatrixMode(int inMode)
        {
            if (currentGLMatrixMode != inMode) {
               // glMatrixMode (inMode);
                //currentGLMatrixMode = inMode;
            }

        }

        public void RenderLoadingBar()
        {
            if (Default.Namespace.Constants.SKIP_FRONTEND)
			{
				return;
			}		
		
            this.RenderLoadingBarItems();
           // glView.SwapBuffers();
        }

        public float GetTimeSinceLoadingStarted()
        {
			//return newLoadingTime;		
//            double nowTime = DateTime.Now.TimeOfDay.Milliseconds;
//            return (nowTime - loadingStartTime) / 1000.0f;
  
			return Time.time - loadingStartTime;
	}

        public void DoLoadingShit()
        {
			loadingBar = new Default.Namespace.Zbar();
            loadingBarPig = new Default.Namespace.Zbar();
			
//			world = new Default.Namespace.World();
				world.DoLoadingShit();

			this.RenderLoadingBar();
		
            util = new Default.Namespace.Utilities();
        
//			Default.Namespace.CGRect rect = Default.Namespace.UIScreen.bounds;
		
				float aspectRatio = (float)Screen.width / (float)Screen.height;
				float width = 960.0f * aspectRatio;

		if (usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
		{
			world.SetScreenWidth(640.0f);
            world.SetScreenHeight(960.0f);

						world.SetScreenWidth(width);

		}
		else
		{
			world.SetScreenWidth(320.0f);
            world.SetScreenHeight(480.0f);
		}
		
//			world.SetScreenWidth(rect.Size.Width);
  //          world.SetScreenHeight(rect.Size.Height);

                world.SetCoordinatesWidth(320.0f);
                world.SetCoordinatesHeight(480.0f);
				world.SetCoordinatesWidth(480.0f * aspectRatio);
		
		
		if (Default.Namespace.Globals.deviceIPad) {
//                world.SetCoordinatesWidth(384.0f);
//                world.SetCoordinatesHeight(512.0f);
                world.SetTileMapHeight(1024.0f);
            }
            else {
//                world.SetCoordinatesWidth(320.0f);
//                world.SetCoordinatesHeight(480.0f);
                world.SetTileMapHeight(480.0f);
            }

            ((world.game).tileMap).AllocTextures();
//            g_util = util;
  //          g_myViewController = viewController;
            //CrashLandingAppDelegate.Print_free_memory();
            world.FirstInitialisation();
           // firstFrame = false;
            //CrashLandingAppDelegate.Print_free_memory();
        }

        public void RenderScene()
        {

			if (loadingStartTime < 0.0f)
			{
				loadingStartTime = Time.time;
			}
		
            double loadingTimeSoFar = this.GetTimeSinceLoadingStarted();
		
	        if (!loadDone)// && (titleScreens.IsReadyToLoad()))
			{
				this.DoLoadingShit();
				loadDone = true;
				resourcesLoadedYet = true;
			}

            if (!Default.Namespace.Constants.SKIP_FRONTEND)
			{
				//float loadingTimeThing = 6.5f;
			
				if (!titleScreens.finished)//  loadingTimeSoFar < loadingTimeThing) 
				{
		            if (Default.Namespace.Globals.bInBackground) 
					{
						return;
					}
				
					//loadADCQueue.Update();				
					
					this.RenderLoadingBar();    
					return;		            
				}
			}		
		


            #if PROFILING_OUT
                lastStartUpdateTime = profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdate];
                profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdate] = DateTime.Now.TimeOfDay.Milliseconds;
            #endif
		
		
		//if done_loading_shit...
		if (loadDone)
		{
						world.ManualUpdate();

            #if PROFILING_OUT
						profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdate] = DateTime.Now.TimeOfDay.Milliseconds;
						profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartRender] = DateTime.Now.TimeOfDay.Milliseconds;
            #endif

			if (Default.Namespace.Constants.ANDROID_25)
			{
			//adding this jsut in case state jsut got changed in Update and don't want to render now...?
				//if (loadADCQueue.state != LoadADCQueue.State.kStateLoadingAssets)
				//{
		            world.RenderScene();
				//}
			}
			else
			{
	            world.RenderScene();
			}

						#if PROFILING_OUT
						profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndRender] = DateTime.Now.TimeOfDay.Milliseconds;
						#endif

		}
		else
		{
			
				float coordsWidth = 320.0f;
				float coordsHeight = 480.0f;
				float renderScale = 1.0f;
			
                float drawWidth = 1.0f / renderScale * coordsWidth;
                float drawHeight = 1.0f / renderScale * coordsHeight;

//				previousRenderScale = renderScale;
//                leftDrawEdge = Constants.TRACK_CENTRE_LINE - (drawWidth / 2.0f);
//                rightDrawEdge = leftDrawEdge + drawWidth;
//                mapObjectAppearDistance = drawHeight + 50.0f;
			
				Camera gameCam = GameObject.Find(" Main Camera For GUI").GetComponent<Camera>();
			
			if (usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				gameCam.orthographicSize = (drawHeight);
			}
			else
			{
				gameCam.orthographicSize = (drawHeight * 0.5f);
			}
//				gameCam.transform.position = 
				
			
			
			Vector3 newPosition = gameCam.transform.position;
			newPosition.y = -(drawHeight - 480.0f) * 0.5f;
			
			if (usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				newPosition.y *= 2.0f;
			}
			
			gameCam.transform.position = newPosition;
			
			
		}
		
//            #if PROFILING_OUT
////                isFraming = false;
//                profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndRender] = DateTime.Now.TimeOfDay.Milliseconds;
//                double timeElapsed = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdate] - lastStartUpdateTime);
//                double timeUpdate = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdate] - profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdate]);
//                double timeRender = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndRender] - profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdate]);
//                double timeRenderTiles = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndTile] - profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartTile]);
//                double timeUpdateFlock = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdateFlock] - profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdateFlock]);
//                double timeRenderScene = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndRenderScene] - lastStartUpdateTime);
//                double timeUpdateMO = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateMapObjectsEnd] - profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateMapObjectsStart]);
//                double timeUpdateNGZ = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateNGZEnd] - profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_UpdateNGZStart]);
//                double timeUpdateGT = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdateGameThings] - profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdateGameThings]);
//                double timeUpdatePartic = (double) (profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndUpdateParticles] - profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartUpdateParticles]);
////                framePercent = (float)(timeElapsed / ((double) Constants.kFrameRate));
////                updatePercent = (float)(timeUpdate / ((double) Constants.kFrameRate));
////                renderPercent = (float)(timeRender / ((double) Constants.kFrameRate));
//                
//				int kFrameGapForCheck = 5;
//
//				if (true) {
////                    static int testCount = 0;
//                    testCount++;
//                    if (testCount >= 1) {
//                        Default.Namespace.Globals.Assert(testCount - 1 < kFrameGapForCheck);
//                        Default.Namespace.Globals.Assert(testCount - 1 >= 0);
//								timeCount[(int)Enum1.kPr_Total, testCount - 1] = timeElapsed;
//								timeCount[(int)Enum1.kPr_Update, testCount - 1] = timeUpdate;
//								timeCount[(int)Enum1.kPr_Render, testCount - 1] = timeRender;
//								timeCount[(int)Enum1.kPr_RenderTileMap, testCount - 1] = timeRenderTiles;
//								timeCount[(int)Enum1.kPr_UpdateFlock, testCount - 1] = timeUpdateFlock;
//								timeCount[(int)Enum1.kPr_RenderScene, testCount - 1] = timeRenderScene;
//								timeCount[(int)Enum1.kPr_UpdateMO, testCount - 1] = timeUpdateMO;
//								timeCount[(int)Enum1.kPr_UpdateNGZ, testCount - 1] = timeUpdateNGZ;
//								timeCount[(int)Enum1.kPr_UpdateGameThings, testCount - 1] = timeUpdateGT;
//								timeCount[(int)Enum1.kPr_UpdateParticles, testCount - 1] = timeUpdatePartic;
//                    }
//
//                    #if PROFILING_OUT_TEXT
//                        string[] nameProfiling = new string[kNumProfileCounts];
//                        nameProfiling[kPr_Total] = "Total";
//                        nameProfiling[kPr_Update] = "Update";
//                        nameProfiling[kPr_Render] = "Render";
//                        nameProfiling[kPr_UpdateFlock] = "Flock Upd";
//                        nameProfiling[kPr_RenderTileMap] = "TileMap Ren";
//                        nameProfiling[kPr_RenderScene] = "RendScene Func";
//                        nameProfiling[kPr_UpdateMO] = "Update MO";
//                        nameProfiling[kPr_UpdateNGZ] = "Update NGZ";
//                        nameProfiling[kPr_UpdateGameThings] = "Update GameThings";
//                        nameProfiling[kPr_UpdateParticles] = "Update Partics";
//                    #endif
//
//                    if (testCount >= kFrameGapForCheck) {
//
//                        #if PROFILING_OUT_TEXT
//                        #endif
//
//                        for (int p = 0; p < kNumProfileCounts; p++) {
//                            sumProfiling[p] = 0.0f;
//                            for (int i = 0; i < kFrameGapForCheck; i++) {
//                                sumProfiling[p] += timeCount[p, i];
//                            }
//
//                            sumProfiling[p] /= (float) kFrameGapForCheck;
//
//                            #if PROFILING_OUT_TEXT
//                            #endif
//
//                        }
//
//								if (sumProfiling[Enum1.kPr_Total] < 0.1f) {
//										sumOfSums[Enum1.kPr_Total] += sumProfiling[Enum1.kPr_Total];
//                            sumOfSumsCount++;
//                        }
//
//                        #if PROFILING_OUT_TEXT
//                        #endif
//
//                        testCount = -3;
//                    }
//
//						if (sumProfiling[Enum1.kPr_Total] > (double) (Constants.kFrameRate * 1.1f)) {
//                        isFraming = true;
//                        showFramingTimer = 3;
//                    }
//
//                }
//
//                const float kNormalWidth = 100.0f;
//                const float kStartX = 10;
//				float uWidth = kNormalWidth * ((float)(sumProfiling[Enum1.kPr_Update] / ((double) Constants.kFrameRate)));
//				float thing = sumProfiling[Enum1.kPr_Render] / Constants.kFrameRate;
//                float renderWidth = kNormalWidth * thing;
//				thing = sumProfiling[Enum1.kPr_Total] - (sumProfiling[Enum1.kPr_Render] + sumProfiling[Enum1.kPr_Update]);
//                float othersWidth = kNormalWidth * (thing / Constants.kFrameRate);
//                //glEnable (GL_SCISSOR_TEST);
//                const int kBarHeight = 30;
//                const int kBarStart = 440;
//                //glScissor((int) kStartX, kBarStart, (int) uWidth, kBarHeight);
//                ////glClearColor(0.0f, 0.3f, 1.0f, 1.0f);
//                //glClear (GL_COLOR_BUFFER_BIT);
//                //glScissor((int) (kStartX + uWidth), kBarStart, (int) renderWidth, kBarHeight);
//                ////glClearColor(1.0f, 0.3f, 1.0f, 1.0f);
//                //glClear (GL_COLOR_BUFFER_BIT);
//                float start = kStartX + uWidth + renderWidth;
//                //glScissor((int) start, kBarStart, (int) othersWidth, kBarHeight);
//                ////glClearColor(1.0f, 1.0f, 0.3f, 1.0f);
//                //glClear (GL_COLOR_BUFFER_BIT);
//                if (showFramingTimer > 0) {
//                    ////glClearColor(1.0f, 0.3f, 0.0f, 1.0f);
//                    float framingWidth = uWidth + renderWidth + othersWidth - kNormalWidth;
//                    //glScissor((int) (kStartX + kNormalWidth), kBarStart - 20, (int) framingWidth, 20);
//                    //glClear (GL_COLOR_BUFFER_BIT);
//                    showFramingTimer--;
//                }
//
//                //glDisable (GL_SCISSOR_TEST);
//            #endif

           // glView.SwapBuffers();

            #if PROFILING_OUT
                profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndRenderScene] = DateTime.Now.TimeOfDay.Milliseconds;
            #endif

        }

        public void ChallengeStartedWithGameConfig(string gameConfig)
        {
        }

//        public void ApplicationDidFinishLaunching(UIApplication application)
  //      {
    //        this.StartApp();
      //  }

//        public void ApplicationDidRegisterForRemoteNotificationsWithDeviceToken(UIApplication application, NSData deviceToken)
  //      {
    //    }

      //  public void ApplicationDidFailToRegisterForRemoteNotificationsWithError(UIApplication application, NSError error)
      //  {
       // }

//        public void ApplicationDidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo)
//        {
//        }

//        bool ApplicationDidFinishLaunchingWithOptions(UIApplication application, NSDictionary launchOptions)
  //      {
		//
            //#if USE_CRYSTAL
            //#endif

//            this.StartApp(application);

  //          #if DROPBOX_ENABLED
    //        #endif

      //      return true;
       // }

/*        public void ApplicationWillTerminate(UIApplication application)
        {
            if (Default.Namespace.Globals.g_world.worldState == (int) WorldState.e_FrontEnd) {
                (Default.Namespace.Globals.g_world.frontEnd).ForceCleanupNetworkStuff();
            }
            else if (Default.Namespace.Globals.g_world.worldState == (int) WorldState.e_InGame) {
                if (((Default.Namespace.Globals.g_world.game).gameState == GameState.e_ShowResultsWin) || ((Default.Namespace.Globals.g_world.game).gameState == GameState.
                  e_ShowResultsLoseToPiggy)) {
                    (Default.Namespace.Globals.g_world.game).CheckSavesAndAchievements();
                }

            }

        }

        public void ApplicationDidReceiveMemoryWarning(UIApplication application)
        {
        }

        public void ApplicationDidEnterBackground(UIApplication application)
        {
            Default.Namespace.Globals.bInBackground = true;
        }

        public void ApplicationWillEnterForeground(UIApplication application)
        {
            Default.Namespace.Globals.bInBackground = false;
        }*/

        public void CrystalUiDeactivated()
        {
            if (((world.frontEnd).profile).preferences.musicOn) {
                (Default.Namespace.SoundEngine.Instance()).AVChangeToTrackP1((int)Default.Namespace.Audio.Enum2.kSoundEffect_MenuMusicLoop, 0.63f);
            }

            if (inCrystalSplash) {
                inCrystalSplash = false;
                (world.frontEnd).ChangeToScreen( Default.Namespace.FrontEndScreenEnum.kFrontEndScreen_Main);
            }

        }

        public void SplashScreenFinishedWithActivateCrystal(bool activateCrystal)
        {
            if (activateCrystal) 
			{
                inCrystalSplash = true;
            }
            else 
			{
                if (((world.frontEnd).profile).preferences.musicOn)
				{
                    (Default.Namespace.SoundEngine.Instance()).AVChangeToTrackP1((int)Default.Namespace.Audio.Enum2.kSoundEffect_MenuMusicLoop, 0.63f);
                }

                (world.frontEnd).ChangeToScreen( Default.Namespace.FrontEndScreenEnum.kFrontEndScreen_Main);
            }

        }

		public void OnApplicationExit()
		{
//			Terms.closeTermsSession();
		}

		public void OnApplicationFocus(bool focus)
	{
		if (Default.Namespace.Globals.g_world == null)
		{
			return;
		}
		
		if (!focus)
		{
            if (Default.Namespace.Globals.g_world.worldState == Default.Namespace.WorldState.e_InGame) 
			{
                if (((Default.Namespace.Globals.g_world.game).gameState == Default.Namespace.GameState.e_GamePlay) || ((Default.Namespace.Globals.g_world.game).gameState == Default.Namespace.GameState.e_GetReady)) 
				{
                    (Default.Namespace.Globals.g_world.game).SetFlagStartPause(true);
                }
            }
	        else if (Default.Namespace.Globals.g_world.worldState ==  Default.Namespace.WorldState.e_FrontEnd) 
			{
	             //   (Default.Namespace.Globals.g_world.frontEnd).ForceCleanupNetworkStuff();

				Default.Namespace.Globals.g_world.frontEnd.AttemptStopMusic();
			}
		}
		else
		{
	        if (Default.Namespace.Globals.g_world.worldState ==  Default.Namespace.WorldState.e_FrontEnd) 
			{
	             //   (Default.Namespace.Globals.g_world.frontEnd).ForceCleanupNetworkStuff();

				Default.Namespace.Globals.g_world.frontEnd.AttemptStartMusic();
			}
		}
	}
	
	public void OnApplicationPause(bool pause)
	{
				if (Default.Namespace.Globals.g_world == null)
						return;

				if (pause)
		{
            if (Default.Namespace.Globals.g_world.worldState == Default.Namespace.WorldState.e_InGame) 
			{
                if (((Default.Namespace.Globals.g_world.game).gameState == Default.Namespace.GameState.e_GamePlay) || ((Default.Namespace.Globals.g_world.game).gameState == Default.Namespace.GameState.e_GetReady)) {
                    (Default.Namespace.Globals.g_world.game).SetFlagStartPause(true);
                }

            }
            else if (Default.Namespace.Globals.g_world.worldState ==  Default.Namespace.WorldState.e_FrontEnd) 
			{
             //   (Default.Namespace.Globals.g_world.frontEnd).ForceCleanupNetworkStuff();
				Default.Namespace.Globals.g_world.frontEnd.AttemptStartMusic();
			}
		}
		else
		{
						if (Default.Namespace.Globals.g_world != null)
						{
					        if (Default.Namespace.Globals.g_world.worldState ==  Default.Namespace.WorldState.e_FrontEnd) 
							{
					             //   (Default.Namespace.Globals.g_world.frontEnd).ForceCleanupNetworkStuff();

								Default.Namespace.Globals.g_world.frontEnd.AttemptStartMusic();
							}
						}
		}
		
	}
	
/*        public void ApplicationWillResignActive(UIApplication application)
        {
            if (Default.Namespace.Globals.g_world.worldState == (int) WorldState.e_InGame) {
                if (((Default.Namespace.Globals.g_world.game).gameState == GameState.e_GamePlay) || ((Default.Namespace.Globals.g_world.game).gameState == GameState.e_GetReady)) {
                    (Default.Namespace.Globals.g_world.game).SetFlagStartPause(true);
                }

            }
            else if (Default.Namespace.Globals.g_world.worldState == (int) WorldState.e_FrontEnd) {
                (Default.Namespace.Globals.g_world.frontEnd).ForceCleanupNetworkStuff();
            }

        }*/

//        public bool ApplicationHandleOpenURL(UIApplication application, NSURL url)
  //      {
    //        return false;
      //  }

    }
//}
