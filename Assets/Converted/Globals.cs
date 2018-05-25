using UnityEngine;
using System;
using System.Collections;
using System.Diagnostics;

namespace Default.Namespace
{
	static class Globals
    {
		public static void Assert(bool inThing)
        {			
			if (!inThing) 
			{
				//UnityEngine.//Debug.Log("Hit Assert");				
				throw new Exception();
			}
//			System.Diagnostics.Debug.Assert(inThing,"who cares");
		}
		
		public static float renderCounter;
		public static int renderQueueCounter;
		
		public static bool useRetina;
//        {
  //          get { return useRetina; }
    //        set { useRetina = value; }
      //  }
		
        public static bool deviceIPad;
				public static bool deviceIPhone4;
				public static bool deviceIPhone5;
        public static bool bInBackground;	

				public static bool useIPadBackScreens;

				public static AnalyticsWrapper g_analytics;
				public static Blowfish g_blowfish;
				public static GuiFrontend g_guiFrontend;
				public static Utilities g_util;
        public static World g_world;
        public static CrashLandingAppDelegate g_main;
				public static World.Enum11 g_currentLanguage;
				public static AchievementQueue g_achievementQueue;
				public static ConsentPopup g_consentPopup;
				public static LoadSave g_loadSave;
	}
}