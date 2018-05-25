using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleFade : MonoBehaviour {

		public enum State 
		{
				Hidden,
				Showing,
				Shown,
				Hiding
		}
		public State state;

		public CanvasGroup canvasGroup;

		public AnimationCurve alphaCurve;

//		public float startAlpha;

		public float fadeDuration = 1.0f;
		float transitionTimer;

		public bool activateAndDeactivateGameObject;

	// Use this for initialization
	void Start () {
	
				if (canvasGroup == null)
						canvasGroup = gameObject.GetComponent<CanvasGroup>();
	}

		//-------------------------------------------
		public void ShowNow () 
		{
				canvasGroup.alpha = 1.0f;
				if (activateAndDeactivateGameObject)
						canvasGroup.gameObject.SetActive(true);
		}
		//-------------------------------------------
		public void HideNow () 
		{
				canvasGroup.alpha = 0.0f;
				if (activateAndDeactivateGameObject)
						canvasGroup.gameObject.SetActive(false);		}

		//---------------------------------------------
		void Update () 
		{
				if (transitionTimer > 0.0f)
				{
						transitionTimer -= Time.deltaTime;
						if (transitionTimer <= 0.0f)
						{
								if (state == State.Showing)
								{
										canvasGroup.alpha = 1.0f;
										state = State.Shown;
								}
								else
								{
										canvasGroup.alpha = 0.0f;
										state = State.Hidden;
										if (activateAndDeactivateGameObject)
												canvasGroup.gameObject.SetActive(false);		
								}						
						}
						else
						{
								float ratio = alphaCurve.Evaluate(transitionTimer/fadeDuration);
								if (state == State.Showing)
										ratio = 1.0f - ratio;

								canvasGroup.alpha = ratio;
						}
				}
		}


	//-------------------------------------------
	public void Hide () 
		{
				state = State.Hiding;
				transitionTimer = fadeDuration;
	}
		//-------------------------------------------
		public void Show () 
		{
				state = State.Showing;
				transitionTimer = fadeDuration;
				if (activateAndDeactivateGameObject)
						canvasGroup.gameObject.SetActive(true);	
		}

}
