using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Default.Namespace
{
public class ConsentPopup : MonoBehaviour {

				public bool isShown;
				public Toggle transferDataToggle;
				public Button acceptButton;
				public SimpleFade simpleFade;
				float isHiddenTimer;
				public ConsentLocalisation consentLocalisation;
				public GameObject notNowButton;
				bool isHiding;

				//a fresh install of the transfer build
				public bool notNeeded;

		//---------------------------------------------
		void Awake () {

						Globals.g_consentPopup = this;
						simpleFade.HideNow();

						transferDataToggle.onValueChanged.AddListener(Tgl_OnChange);

		}

				void Tgl_OnChange(bool isClick)
				{
						
						Debug.Log("Toggle selected" +isClick.ToString());

						acceptButton.interactable = transferDataToggle.isOn;
				}

				//---------------------------------------------
				public void DeactivateForGood()
				{
						notNeeded = true;
						Globals.g_loadSave.hasAcceptedConsent = true;
						Globals.g_loadSave.SaveGameData();
				}

				//---------------------------------------------
				public void Show () {

						if (notNeeded)
								return;

						isHiding = false;
						if (Default.Namespace.Globals.g_loadSave.hasAcceptedConsent)
								return;
								
						System.DateTime transferDay = new System.DateTime(2017, 05, 15);

						Debug.Log("transferDay " +transferDay.ToString());
						Debug.Log("Today " +System.DateTime.Today.ToString());

						if (System.DateTime.Today >= transferDay)
						{
								//from this point on... no Not Now button
								notNowButton.SetActive(false);
						}

//						if (System.DateTime.Today == yourBirthday ) { print("Easter egg activated!"); }

						isShown = true;
						transferDataToggle.isOn = false;
						acceptButton.interactable = false;
						simpleFade.Show();
						consentLocalisation.SetLanguage(Globals.g_currentLanguage);

				}
				//---------------------------------------------
				public void Hide () {

						if (notNeeded)
								return;


						isHiding = true;
						isHiddenTimer = 0.5f;
						simpleFade.Hide();
				}
				//---------------------------------------------
				void Update () {
						if (isHiddenTimer > 0.0f)
						{
								isHiddenTimer -= Time.deltaTime;
								if (isHiddenTimer <= 0.0f)
								{
										isShown = false;
								}
						}
				}	
		//---------------------------------------------
		public void ClickPrivacyPolicy () 
		{
						Application.OpenURL("http://shaunthesheep.com/fleece-lightning-terms-privacy");		
		}
				//---------------------------------------------
				public void ClickTermsOfService () 
				{
						Application.OpenURL("http://shaunthesheep.com/fleece-lightning-terms-privacy");		
				}
				//---------------------------------------------
				public void ClickNotNow () 
				{
						if (isHiding)
								return;
						
						this.Hide();
				}
				//---------------------------------------------
				public void ClickAccept () 
				{
						if (isHiding)
								return;

						Default.Namespace.Globals.g_loadSave.hasAcceptedConsent = true;
						Default.Namespace.Globals.g_loadSave.SaveGameData();

						this.Hide();
				}
}
}