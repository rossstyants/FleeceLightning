using UnityEngine;
using System.Collections;

public class GuiFrontendButton : MonoBehaviour {


//		public enum ClickStyle
//		{
//				Throb
//		}
//
//		public ClickStyle clickStyle;

		//if not null throbs on click
		public Throb throb;

		public GameObject highlightImage;

		public ShowAndHide showAndHide;

	// Use this for initialization
	void Start () 
		{
				if (highlightImage)
				{
						highlightImage.SetActive(false);
				}
	}
	
	//-----------------------------------------
	public virtual void Show () {
				showAndHide.Show();
				if (highlightImage)
				{
						highlightImage.SetActive(false);
				}

		}
		//-----------------------------------------
		public virtual void Hide () {
				showAndHide.Hide();

		}

		//--------------------------------------------------
		public void OnClick () 
		{
				Debug.Log("<color=green>"+gameObject.name+" button clicked</color>");

				if (throb)
						throb.StartThrob();

				if (highlightImage)
						highlightImage.SetActive(true);
		}

}
