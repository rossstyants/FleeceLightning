using UnityEngine;
using System.Collections;

public class LoadADCQueue {
	
	public int numAssetsInList;
	public int currentAsset;
	public AssetInfo[] assetInfo = new AssetInfo[(int)LoadADCQueue.Constants.kMaxAssetsInList];
	public State state;
	public LoadType loadType;

	public enum LoadType{
		
		kReloadingFrontEnd,
		kLoadFirstInit,
	}
	
	public enum State{
		
		kStateNotStartedYet,
		kStateBuildingUpAssetList,
		kStateLoadingAssets,
		kStateFinishedLoading
	}
	
	public enum Constants
	{
		kMaxAssetsInList = 50
	}	
	
	public enum AssetType
	{
		kAtlas,
		kTextureGame,
		ktextureFrontEnd,
		ktextureStartup
	}

	public struct AssetInfo
	{
		public AssetType assetType;
		public int assetId;
		public string name;
	}
	
	public LoadADCQueue()
	{
		state = State.kStateNotStartedYet;
		Debug.Log("Set ADC state to " + state.ToString());
	}
	
	public void InitialiseLoad()
	{
		if (Default.Namespace.Globals.g_main.usingTextureResolution != TextureResolutionEnum.kTextureResolution_High)
			return;
		
		numAssetsInList = 0;		
		state = State.kStateBuildingUpAssetList;	
		Debug.Log("Set ADC state to " + state.ToString());		
	}
	
	public void DoLoad() 
	{
		if (!Default.Namespace.Constants.ANDROID_25)
			return;
		
		if (numAssetsInList == 0)
			return;
		
//		loadType = ofType;
		state = State.kStateLoadingAssets;		
		Debug.Log("Set ADC state to " + state.ToString());
		
		//assetInfo should have been populated by calls to Init ZAtlas etc...
		
		this.StartLoading();
		
/*		switch(ofType)
		{
		case LoadType.kLoadFirstInit:
			this.LoadFirstInit();
			break;
		case LoadType.kReloadingFrontEnd:
			this.ReloadFrontEnd();
			break;
		default:
			Default.Namespace.Globals.Assert(false);
			break;			
		}*/
	}	
	
/*	public void LoadFirstInit() 
	{
		AssetInfo inInfo = new AssetInfo();
		inInfo.assetType = AssetType.kAtlas;

		inInfo.assetId = (int)Default.Namespace.AtlasType.kAtlas_FrontendAndShowlevel;
		inInfo.name = "AtlasFrontEnd.png";
		this.AddAssetToList(inInfo);

		inInfo.assetId = (int)Default.Namespace.AtlasType.kAtlas_Hud;
		inInfo.name = "AtlasHud.png";
		this.AddAssetToList(inInfo);

		this.StartLoading();
	}
	
	
	public void ReloadFrontEnd() 
	{
		if (!Default.Namespace.Constants.ANDROID_25)
			return;		
		
		loadType = LoadType.kReloadingFrontEnd;
		state = State.kStateLoadingAssets;
		
		numAssetsInList = 0;		
		AssetInfo inInfo = new AssetInfo();
		inInfo.assetType = AssetType.kAtlas;

		inInfo.assetId = (int)Default.Namespace.AtlasType.kAtlas_FrontendAndShowlevel;
		inInfo.name = "AtlasFrontEnd.png";
		this.AddAssetToList(inInfo);

		inInfo.assetId = (int)Default.Namespace.AtlasType.kAtlas_Hud;
		inInfo.name = "AtlasHud.png";
		this.AddAssetToList(inInfo);

		this.StartLoading();
	}*/

	public bool CheckFinishedOrLoadNextAsset() 
	{
		currentAsset++;

		if (numAssetsInList > currentAsset)
		{
			this.LoadNextAsset();			
			return false;		
		}
		else
		{
			state = State.kStateFinishedLoading;			
			Debug.Log("Set ADC state to " + state.ToString());

			return true;		
		}
	}
	
	public void LoadNextAsset() 
	{
		Debug.Log ("ADC Load asset " + currentAsset.ToString());		
		
		Default.Namespace.Globals.g_main.loadADC.LoadTextureFromADC2(assetInfo[currentAsset].name);		
	}	
	
	public void StartLoading() 
	{
		Debug.Log ("ADC Start Load of " + numAssetsInList.ToString() + " assets.");
		
		currentAsset = 0;
		
		this.LoadNextAsset();
	}	
	
	public void AddAssetToList(AssetInfo newAsset) 
	{
		Debug.Log ("ADC Add " + newAsset.assetType.ToString() + " ("+ newAsset.assetId.ToString() +") to list : " + newAsset.name);
		
		assetInfo[numAssetsInList].assetId = newAsset.assetId;	
		assetInfo[numAssetsInList].assetType = newAsset.assetType;	
		assetInfo[numAssetsInList].name = newAsset.name;	

		numAssetsInList++;
	}
	
	public bool Update () 
	{
		if (state != State.kStateLoadingAssets)
			return false;
		
		if (Default.Namespace.Globals.g_main.loadADC.state == LoadADC.State.kLoadFinished)
		{
			Default.Namespace.Globals.g_main.loadADC.state = LoadADC.State.kWaitingForNextLoad;
			
			//next item has succesfully loaded.
			
			switch(assetInfo[currentAsset].assetType)
			{
			case AssetType.kAtlas:

				Default.Namespace.Globals.g_world.GetAtlas((Default.Namespace.AtlasType)assetInfo[currentAsset].assetId).SetTextureForADC(Default.Namespace.Globals.g_main.loadADC.loadedTexture);
				
				break;
			case AssetType.ktextureFrontEnd:

				Default.Namespace.Globals.g_world.frontEnd.GetButtonTexture(assetInfo[currentAsset].assetId).SetTextureForADC(Default.Namespace.Globals.g_main.loadADC.loadedTexture);				
				
				break;
			case AssetType.kTextureGame:

				Default.Namespace.Globals.g_world.game.GetTexture((Default.Namespace.TextureType)assetInfo[currentAsset].assetId).SetTextureForADC(Default.Namespace.Globals.g_main.loadADC.loadedTexture);								
				
				break;
			}
			
			return this.CheckFinishedOrLoadNextAsset();
		}	
		
		return false;
	}
}
