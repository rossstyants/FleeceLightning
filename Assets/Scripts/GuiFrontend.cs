using UnityEngine;
using System.Collections;

public class GuiFrontend : MonoBehaviour {

		public GuiFrontendButton achievementsAndLeaderboards;


		//-----------------------------------------------------------
		void Awake () 
		{
				Default.Namespace.Globals.g_guiFrontend = this;
		}


		//-----------------------------------------------------------
	void Start () 
		{
				Default.Namespace.Globals.g_loadSave.LoadGameData();
	}
	
		//-----------------------------------------------------------
	void Update () {
	
	}
}
