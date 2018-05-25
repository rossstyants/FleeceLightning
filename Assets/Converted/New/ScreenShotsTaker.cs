using UnityEngine;
using System.Collections;

public class ScreenShotsTaker : MonoBehaviour {

	public string screenShotName = "screenshot";

	public float timeBetweenShots = 0.1f;
	public float burstDuration = 1.0f;
	public float defaultDelayBeforeBurst;
	float burstTimer;
	int randomSessionId;
	int screenShotCounter;
	float timeSinceScreenShot;
	float delayBeforeBurst;

	int takeEveryOtherShot;

	//-----------------------------------------------------------------------------
	void Awake () 
	{
//		Globals.g_screenshottaker = this;
	}

	//-----------------------------------------------------------------------------
	void Start () 
	{
		burstTimer = 0.0f;
		randomSessionId = Random.Range(0,99000);
		screenShotCounter = 0;
		delayBeforeBurst = 0.0f;
		takeEveryOtherShot = 0;
	}

	//-----------------------------------------------------------------------------
	public void StartBurst()
	{
		this.StartBurst(defaultDelayBeforeBurst);
	}

	//-----------------------------------------------------------------------------
	public void StartBurst(float withDelay)
	{
		takeEveryOtherShot++;
		if (takeEveryOtherShot%2 ==0)
			return;

		if (withDelay > 0.0f)
		{
			delayBeforeBurst = withDelay;
		}

		burstTimer = burstDuration;
		timeSinceScreenShot = timeBetweenShots;
	}

	//-----------------------------------------------------------------------------
	void Update () 
	{
		if (delayBeforeBurst > 0.0f)
		{
			delayBeforeBurst -= Time.deltaTime;

			return;
		}

		if (burstTimer > 0.0f)
		{
			burstTimer -= Time.deltaTime;
			timeSinceScreenShot += Time.deltaTime;

			if (timeSinceScreenShot >= timeBetweenShots)
			{
				ScreenCapture.CaptureScreenshot(screenShotName + "_" + randomSessionId.ToString() + "_" + screenShotCounter.ToString("0000") + ".png");
				screenShotCounter++;
				timeSinceScreenShot = 0.0f;
			}
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.StartBurst();
		}
	}
}
