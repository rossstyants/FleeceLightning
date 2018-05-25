using UnityEngine;
using System.Collections;

public class ShowAndHide : MonoBehaviour {

		bool awakeCalled;

		public Vector3 hideOffset;

//		Vector3 originalPosition;

		Vector3 hiddenPosition;
		Vector3 shownPosition;

		public enum State
		{
				kHidden,
				kShowing,
				kShown,
				kHiding
		}

		public State state;

		public State startState;

		//these could be different to hidden and shown position if Show triggered halfway through transition etc.
		Vector3 moveFrom,moveTo;

		float transitionTimer;
		public float transitionDuration = 1.0f;

		public AnimationCurve transitionCurve;

		//---------------------------------------------
	void Awake () {
	
				if (!awakeCalled)
				{
						shownPosition = transform.localPosition;
						hiddenPosition = shownPosition + hideOffset;
						awakeCalled = true;
						if (startState == State.kHidden)
						{
								transform.localPosition = hiddenPosition;
								state = State.kHidden;
						}
						else
						{
								transform.localPosition = shownPosition;
								state = State.kShown;
						}
				}
	}
	
		//---------------------------------------------
		void Update () 
		{
				if (transitionTimer > 0.0f)
				{
						transitionTimer -= Time.deltaTime;
						if (transitionTimer <= 0.0f)
						{
								if (state == State.kShowing)
								{
										transform.localPosition = shownPosition;
										state = State.kShown;
								}
								else
								{
										transform.localPosition = hiddenPosition;
										state = State.kHidden;
								}
						}
						else
						{
								float ratio = 1.0f - transitionCurve.Evaluate(transitionTimer/transitionDuration);
								transform.localPosition = Ross_Utils.GetPositionBetween(ratio, moveFrom, moveTo);
						}
					}
		}

		//---------------------------------------------
		public void Show () 
		{
				moveFrom = transform.localPosition;
				moveTo = shownPosition;
				state = State.kShowing;
				transitionTimer = transitionDuration;
		}
		//---------------------------------------------
		public void Hide () 
		{
				moveFrom = transform.localPosition;
				moveTo = hiddenPosition;
				state = State.kHiding;
				transitionTimer = transitionDuration;

		}
}
