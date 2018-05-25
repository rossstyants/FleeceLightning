using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileInfoThing {

	//------------------------------------------
	public static void ListAllFiles (string path) 
	{
				Debug.Log("<color=yellow>List all files in "+path+"</color>");

		DirectoryInfo info = new DirectoryInfo(path);
		FileInfo[] fileInfo = info.GetFiles("*.*");
		
				foreach(FileInfo file in fileInfo) 
				{
						Debug.Log("<color=yellow>"+file+"</color>");			
				}
	}


		//------------------------------------------
		public static string GetFallbackPath (string filename) 
		{
				//ANDROID

			//fallback path
				string path = "/data/data/com.chillingo.fleecelightning.android.rowgplay/" + filename;
//				string path = "/storage/emulated/0/data/data/com.chillingo.fleecelightning.android.rowgplay/" + filename;

//				/storage/emulated/0


				Debug.Log("Android FALLBACK data path is : " + path);

				return path;
		}

		//------------------------------------------
//		public static void ListAllFiles (string filename) 
//		{
//
//		string path = "";
//		#if UNITY_ANDROID && UNITY_EDITOR
//		try {
//		IntPtr obj_context = AndroidJNI.FindClass("android/content/ContextWrapper");
//		IntPtr method_getFilesDir = AndroidJNIHelper.GetMethodID(obj_context, "getFilesDir", "()Ljava/io/File;");
//
//		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
//		using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
//		IntPtr file = AndroidJNI.CallObjectMethod(obj_Activity.GetRawObject(), method_getFilesDir, new jvalue[0]);
//		IntPtr obj_file = AndroidJNI.FindClass("java/io/File");
//		IntPtr method_getAbsolutePath = AndroidJNIHelper.GetMethodID(obj_file, "getAbsolutePath", "()Ljava/lang/String;");   
//
//		path = AndroidJNI.CallStringMethod(file, method_getAbsolutePath, new jvalue[0]);                    
//
//		if(path != null) {
//		Debug.Log("Got internal path: " + path);
//		}
//		else {
//		path = "/data/data/com.chillingo.fleecelightning.android.rowgplay/files";
//												Debug.Log("Using fallback path");
//
//										}
//		}
//		}
//		}
//		catch(Exception e) {
//		Debug.Log(e.ToString());
//		}
//		#else
//		path = Application.persistentDataPath;
//		#endif
//		}
}
