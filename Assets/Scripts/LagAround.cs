using UnityEngine;
using System.Collections;

public class LagAround : MonoBehaviour {

	public enum State
	{
		Showing,
		Shown,
		Hiding,
		Hidden
	}

	Vector3 originalPosition;
	bool awakeCalled;
	Vector3 targetPos;
	Vector3 hidePos;
	public float kLag;
	public State state;

	//-----------------------------------------------------
	void Awake () 
	{
		#if UNITY_ANDROID

		//because of that annoying android achievement popup that you can't disable / move !

		Vector3 localPos = transform.localPosition;
		localPos.y -= 25.0f;
		transform.localPosition = localPos;

		#endif


		originalPosition = transform.position;

		awakeCalled = true;
		hidePos = originalPosition;
		hidePos.y += 0.6f;

		transform.position = hidePos;
		targetPos = hidePos;

		state = State.Hidden;
	}

	//-----------------------------------------------------
	public void Hide () 
	{
		targetPos = hidePos;
		state = State.Hiding;
	}
	//-----------------------------------------------------
	public void Show () 
	{
		targetPos = originalPosition;
		state = State.Showing;
	}

	//-----------------------------------------------------
	void FixedUpdate () 
	{
		Vector3 pos = transform.position;
		pos.y += ((targetPos.y - pos.y) * kLag);
		transform.position = pos;

		if (Mathf.Abs(targetPos.y - pos.y) <= 0.05f)
		{
			if (state == State.Hiding)
				state = State.Hidden;
			else if (state == State.Showing)
				state = State.Shown;
		}
	}
}
