using UnityEngine;
using System.Collections;
using System.IO;
//using System.Convert;

namespace Default.Namespace
{
public class LoadSave : MonoBehaviour {

	public bool logOn;
	public string fileName;// = "iGameSave.dat";
	

		public bool hasAcceptedConsent;


	void Awake () 
	{
				Globals.g_loadSave = this;

//		if (logOn)
		Debug.Log ("Awake LoadSave");
		
		this.DoAwake();
	}

	public virtual void DoAwake()
	{
	}

	void Update () {
	
	}

	public virtual void SetGameDataDefaults () 
	{
				//for transfer build we'll need to check if this is necessary... somehow...

		hasAcceptedConsent = false;
	}
	
	string pathForDocumentsFile( string filename ) 
	{ 
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			string path = Application.persistentDataPath + "/" + fileName;
			return path;
		}		
		else if(Application.platform == RuntimePlatform.Android)
		{
			string path = Application.persistentDataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ) );	
			return Path.Combine (path, filename);
		}	
		else 
		{
			string path = Application.dataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ) );
			return Path.Combine (path, filename);
		}
	}	
	
	public void SaveGameData()
	{
		#if UNITY_WEBPLAYER
		return;
		#endif

		if (logOn)
			Ross_Utils.Log("Write to GameSave File " + fileName);											
		
		string path = this.pathForDocumentsFile(fileName);		
		FileStream file = new FileStream (path, FileMode.Open, FileAccess.Write);			
		this.WriteGameDataToFile(file);		
		file.Close();
	}
	
	public void LoadGameData()
	{
#if UNITY_WEBPLAYER
		return;
#endif

		string path = pathForDocumentsFile( fileName );
				
		Debug.Log("try to load " + path);

		//if the file has not been made yet then set defaults and create it...
		if (!File.Exists(path))
		{
			Debug.Log("failed to load - Create GameSave File " + fileName);									

			this.SetGameDataDefaults();
			FileStream newFile = new FileStream (path, FileMode.Create, FileAccess.Write);
			this.WriteGameDataToFile(newFile);
			newFile.Close();
			
			return;
		}
		
		//Otherwise just read it

		Ross_Utils.Log("Read GameSave File " + fileName);						
		
		FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);		
		this.ReadGameDataFromFile(file);			
		file.Close();		
	}
	
	
	
	public virtual void ReadGameDataFromFile(FileStream filestream)
	{
				BinaryReader reader = new BinaryReader(filestream);
				hasAcceptedConsent = reader.ReadBoolean();
	}	
	
	
	public virtual void WriteGameDataToFile(FileStream filestream)
	{
				BinaryWriter writer = new BinaryWriter(filestream);
				writer.Write(hasAcceptedConsent);	
		}
}
}