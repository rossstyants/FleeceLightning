using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildBoss : Singleton<BuildBoss> {

	public enum BuildTypeEnum{
		IOS,
		GOOGLE_PLAY_AND_AMAZON,
		AMAZON_SUBSCRIPTION,
	};

	public BuildTypeEnum buildType;

	public float buildNumber;
	public string iosPackageName;
	public string gPlayAndAmazonPackageName;
	public string amazonSubscriptionPackageName;


	//------------------------------------------------------------
	void Update () 
	{
		if (!Application.isPlaying)
		{
			UnityEditor.PlayerSettings.bundleVersion = buildNumber.ToString();

			if (buildType == BuildTypeEnum.IOS)
				UnityEditor.PlayerSettings.applicationIdentifier = iosPackageName;
			else if (buildType == BuildTypeEnum.GOOGLE_PLAY_AND_AMAZON)
				UnityEditor.PlayerSettings.applicationIdentifier = gPlayAndAmazonPackageName;
			else// if (buildType == BuildTypeEnum.GOOGLE_PLAY_AND_AMAZON)
				UnityEditor.PlayerSettings.applicationIdentifier = amazonSubscriptionPackageName;
		}
	}
}
