using UnityEngine;
using System.Collections;

public class LoadADC : MonoBehaviour {
	
	public Texture loadedTexture;
	string nextResourceName;
	public bool isBusy; //loading something
	public State state;
	
	public enum State{
		kWaitingForNextLoad,
		kLoadingNow,
		kLoadFinished
	}
	
	void Start () {
	
	}


	public void LoadTextureFromADC2(string inName)
	{		
		string nameNoExtension = System.IO.Path.GetFileNameWithoutExtension(inName);		
		
		string url = "file:///" + Application.persistentDataPath + "/Done_HighRes/" + nameNoExtension + "@2x~iphone.png";		
		
		Debug.Log("open www with URL " + url);				
		Debug.Log("ISBUSY = true");				
		
		state = State.kLoadingNow;
		
		isBusy = true;
		
		WWW www = new WWW(url);			

		Debug.Log("www = " + www.ToString());					
		
		nextResourceName = inName;
		
	    StartCoroutine(LoadAsset(www));
	}
	
	
	IEnumerator LoadAsset(WWW www)
    {
		Debug.Log("LoadAsset"); 
		
		float elapsedTime = 0.0f;
		
		while (!www.isDone)
		{
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= 5.0f)
				break;
			yield return null;
		}
				
		if (!www.isDone || !string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Load Failed");
			Debug.Log("No Assets found, make sure SD card is inserted and mounted properly."); 
			loadedTexture = null;    // Pass null result.
            yield break;
        }

		Debug.Log("www is done!"); 	
		
		state = State.kLoadFinished;		
		
		loadedTexture = www.texture;		
		
		Default.Namespace.Globals.g_world.GetAtlas(Default.Namespace.AtlasType.kAtlas_FontNumbers).myMaterial.mainTexture = loadedTexture;
		
//		loadedTexture = www.assetBundle.Load(nextResourceName) as Texture;

		Debug.Log("loadedTexture = " + loadedTexture.ToString()); 
			
//			www.assetBundle.Unload(false);	
	}		
	
	void Update () {
	
	}
}