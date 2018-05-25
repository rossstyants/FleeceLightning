using UnityEngine;
using System.Collections;

public class Throb : MonoBehaviour {
	
	public bool throbOnAwake = false;
	
	float throbTimer = 0.0f;
	float throbDuration;
//	public float overrideOriginalScale = 0.0f;
	Vector3 originalScale;
	float scaleNow;
	public float kThrobSize = 0.1f;	
	public float kThrobDuration = 0.4f;	
	int numThrobs;

		bool awakeCalled;
		public AnimationCurve throbCurve;
	
	public enum State{
		kThrobbing,
		kThere
	};
	
	public State state = State.kThere;

	
		//-----------------------------------------------------------------------------
		void Awake () 
		{
				if (!awakeCalled)
						originalScale = gameObject.transform.localScale;					

				awakeCalled = true;
		}

	//-----------------------------------------------------------------------------
	void Start () 
	{
		if (throbOnAwake)
		{
			this.StartThrobMultiple(1);
		}
	}

	//-----------------------------------------------------------------------------
	public void StartThrobMultiple (int howManyThrobs) 
	{
				if (!awakeCalled)
						this.Awake();

		//Ross_Utils.Log("Throb: Start Throb");

		numThrobs = howManyThrobs;
		throbDuration = kThrobDuration;
		throbTimer = throbDuration;
		scaleNow = 1.0f;
		state = State.kThrobbing;
	}

    // oh yeah
    public void StopThrobbingBaby()
    {
        throbTimer = 0;
        numThrobs = 0;
    }
	
	//-----------------------------------------------------------------------------
	public void StartThrob () 
	{
		Ross_Utils.Log("Throb: Start Throb 0");

		this.StartThrobMultiple(1);
	}

	//-----------------------------------------------------------------------------
	void FixedUpdate () 
	{
		if (throbTimer > 0.0f)
		{
			throbTimer -= Time.deltaTime;			

						if (throbTimer <= 0.0f)
						{
								numThrobs--;

								if (numThrobs > 0)
								{
										throbTimer = throbDuration;
								}
								else
								{
										state = State.kThere;
								}

								transform.localScale = originalScale;
						}
						else
						{
								float ratio = throbTimer / throbDuration;
								float scale = 1.0f + (throbCurve.Evaluate(1.0f - ratio) * kThrobSize);
								transform.localScale = new Vector3(originalScale.x * scale,originalScale.y*scale,originalScale.z*scale);
						}
				}
		
	}
}
