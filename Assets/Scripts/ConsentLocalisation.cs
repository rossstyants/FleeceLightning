using UnityEngine;
using System.Collections;

namespace Default.Namespace
{
		[ExecuteInEditMode]
public class ConsentLocalisation : MonoBehaviour {

				public World.Enum11 currentLanguage;

		public GameObject[] english;
		public GameObject[] french;
		public GameObject[] german;
		public GameObject[] japanese;
				public GameObject[] chinese;
				public GameObject[] spanish;



	// Use this for initialization
	void Start () {
	

						//this.SetLanguage(currentLanguage);
	}

				void Update () {
						if (!Application.isPlaying)
								this.SetLanguage(currentLanguage);

						}


	//-----------------------------------------------
		public void SetLanguage (World.Enum11 inLanguage) 
	{
	
//				if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {

						if (inLanguage == World.Enum11.kLanguage_China)
						{
								foreach(GameObject go in english)
										go.SetActive(false);
								foreach(GameObject go in french)
										go.SetActive(false);
								foreach(GameObject go in german)
										go.SetActive(false);
								foreach(GameObject go in japanese)
										go.SetActive(false);
								foreach(GameObject go in spanish)
										go.SetActive(false);
								foreach(GameObject go in chinese)
										go.SetActive(true);
						}
						else if (inLanguage == World.Enum11.kLanguage_English)
						{
								foreach(GameObject go in english)
										go.SetActive(true);
								foreach(GameObject go in french)
										go.SetActive(false);
								foreach(GameObject go in german)
										go.SetActive(false);
								foreach(GameObject go in japanese)
										go.SetActive(false);
								foreach(GameObject go in spanish)
										go.SetActive(false);
								foreach(GameObject go in chinese)
										go.SetActive(false);
						}
						else if (inLanguage == World.Enum11.kLanguage_French)
						{
								foreach(GameObject go in english)
										go.SetActive(false);
								foreach(GameObject go in french)
										go.SetActive(true);
								foreach(GameObject go in german)
										go.SetActive(false);
								foreach(GameObject go in japanese)
										go.SetActive(false);
								foreach(GameObject go in spanish)
										go.SetActive(false);
								foreach(GameObject go in chinese)
										go.SetActive(false);
						}
						else if (inLanguage == World.Enum11.kLanguage_German)
						{
								foreach(GameObject go in english)
										go.SetActive(false);
								foreach(GameObject go in french)
										go.SetActive(false);
								foreach(GameObject go in german)
										go.SetActive(true);
								foreach(GameObject go in japanese)
										go.SetActive(false);
								foreach(GameObject go in spanish)
										go.SetActive(false);
								foreach(GameObject go in chinese)
										go.SetActive(false);
						}
						else if (inLanguage == World.Enum11.kLanguage_Japanese)
						{
								foreach(GameObject go in english)
										go.SetActive(false);
								foreach(GameObject go in french)
										go.SetActive(false);
								foreach(GameObject go in german)
										go.SetActive(false);
								foreach(GameObject go in japanese)
										go.SetActive(true);
								foreach(GameObject go in spanish)
										go.SetActive(false);
								foreach(GameObject go in chinese)
										go.SetActive(false);
						}
						else if (inLanguage == World.Enum11.kLanguage_Spanish)
						{
								foreach(GameObject go in english)
										go.SetActive(false);
								foreach(GameObject go in french)
										go.SetActive(false);
								foreach(GameObject go in german)
										go.SetActive(false);
								foreach(GameObject go in japanese)
										go.SetActive(false);
								foreach(GameObject go in spanish)
										go.SetActive(true);
								foreach(GameObject go in chinese)
										go.SetActive(false);
						}

	}
}

		}