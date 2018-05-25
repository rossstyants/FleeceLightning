using UnityEngine;
using System;
using System.Collections.Generic;

namespace Default.Namespace
{
    public class SoundEngine
    {
		const int kNumSFXChannels = 16;
		
		public GameObject[] myObjectSFX = new GameObject [kNumSFXChannels];		
		public GameObject myObjectMusic;	
		
		int sfxChannel;
		
		private static SoundEngine soundEngineInstance;
        public AVAudioPlayer[] soundAV = new AVAudioPlayer[(int)Enum2.kMaxAVSounds];
        public float[] fadeTimer = new float[(int)Enum2.kMaxAVSounds];
        public float[] fadeTime = new float[(int)Enum2.kMaxAVSounds];
        public float[] delay = new float[(int)Enum2.kMaxAVSounds];
        public float[] fadeMinimum = new float[(int)Enum2.kMaxAVSounds];
        public int[] fadingIn = new int[(int)Enum2.kMaxAVSounds];
        public float[] playVolumeAV = new float[(int)Enum2.kMaxAVSounds];
        public int numSounds;
        public Finch finchSoundEngine;
		public AudioClip[] sfxClip = new AudioClip[(int)Enum2.kMaxFinchSounds];
		public AudioClip[] avClip = new AudioClip[(int)Enum2.kMaxAVSounds];
        public Sound[] finchSound = new Sound[(int)Enum2.kMaxFinchSounds];
		
		//my info class
		public SfxHandle[] sfxHandleInfo = new SfxHandle[(int)kNumSFXChannels];

		public bool[] avLoop = new bool[(int)Enum2.kMaxAVSounds];
		
		public List<int> updateListAV;
        public List<int> updateListFinch;
        public bool playSoundFX;
        public float[] maxVolumeFinch = new float[(int)Enum2.kMaxFinchSounds];
        public float volumeFinchOverall;
        public List<int> finchSoundQueue;
        public List<float> finchSoundQueueTime;
        public int changeToTrackAV;
        public float changeTimeAV;
        public int currentSoundAV;
        public int pendingAddToUpdateList;
        public float stateTimer;
        public enum Enum {
            kAVFade_NotFading = 255,
            kAVFade_In = 0,
            kAVPlayAndFade_In,
            kAVFade_Out,
            kAVFade_OutAndStop
        };
        public enum Enum2 {
            kMaxAVSounds = 30,
            kMaxFinchSounds = 150
        };

		public bool PlaySoundFX
        {
            get;
            set;
        }

		public void SetPlaySoundFX(bool inThing) {playSoundFX = inThing;}///@property(readwrite,assign) bool playSoundFX;

        public static SoundEngine Instance()
        {
//            static SoundEngine soundEngineInstance = null;
            if (soundEngineInstance == null) {
                soundEngineInstance = new SoundEngine();
            }

            return soundEngineInstance;
        }

        public SoundEngine ()
		{
			sfxChannel = 0;
			for (int i = 0; i < kNumSFXChannels; i++)
			{
				myObjectSFX[i] = new GameObject("SFXObject");
				myObjectSFX[i].AddComponent<AudioSource>();
			}
			
			for (int i = 0; i < kNumSFXChannels; i++)
			{
				sfxHandleInfo[i] = new SfxHandle();
				sfxHandleInfo[i].isFree = true;
			}

			
			myObjectMusic = new GameObject();
			myObjectMusic.AddComponent<AudioSource>();
		//	myObject.renderer.enabled = false;			
			
			//if (!base.init()) return null;

			finchSoundEngine = new Finch ();
			updateListAV = new List<int> (0);
			updateListFinch = new List<int> (0);
			finchSoundQueue = new List<int> (0);
			finchSoundQueueTime = new List<float> (0);
			playSoundFX = true;
			changeToTrackAV = -1;
			pendingAddToUpdateList = -1;
			currentSoundAV = -1;
			for (int i = 0; i < (int)Enum2.kMaxFinchSounds; i++) {
                finchSound[i] = null;//new Sound();
                maxVolumeFinch[i] = 1.0f;
            }
			
			
			
            volumeFinchOverall = 1;
            stateTimer = 0;
            //return this;
        }
        public void LoadAVSoundP1P2P3 (int soundId, string fileName, string ext, int numberOfLoops)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            Globals.Assert(soundAV[soundId] == null);

			string tempString = "Audio/Music/" + System.IO.Path.GetFileNameWithoutExtension(fileName);			
			
			if (avClip[soundId] == null)
			{
				avClip[soundId] = new AudioClip();
			}
			
			if (numberOfLoops == -1)
			{
				avLoop[soundId] = true;
			}
			else
			{
				avLoop[soundId] = false;
			}
			
			avClip[soundId] = Resources.Load(tempString, typeof(AudioClip)) as AudioClip;						
			
			//      soundAV[soundId] = new AVAudioPlayer(NSURL.FileURLWithPath((NSBundle.MainBundle()).PathForResourceOfType(new string(fileName), new string(ext))),
        //      NULL);
       //     (soundAV[soundId]).SetDelegate(this);
         //   (soundAV[soundId]).SetNumberOfLoops(numberOfLoops);
            playVolumeAV[soundId] = 1;
         //   fadingIn[soundId] = Enum.kAVFade_NotFading;
         //   (soundAV[soundId]).SetVolume(1);
            fadeMinimum[soundId] = 0.0f;
        }

        public void ReleaseFinchSound(int soundId)
        {
//            finchSound[soundId];
            finchSound[soundId] = null;
        }

        public void LoadFinchSoundP1P2 (int soundId, string fileName, float maxVolume)
		{
//			string fullPath = ((NSBundle.MainBundle ()).ResourcePath ()).StringByAppendingPathComponent (fileName);
			
			//public GameObject myObject;
			
			string tempString = "Audio/SFX/" + System.IO.Path.GetFileNameWithoutExtension(fileName);			
			
//			AudioClip sfxClip = new AudioClip();
			
			if (sfxClip[soundId] != null)
			{
				sfxClip[soundId] = null;
				//sfxClip[soundId] = new AudioClip();
			}
			
			sfxClip[soundId] = Resources.Load(tempString, typeof(AudioClip)) as AudioClip;						
			
			
			
			//sfxClip[soundId].
			
			
		//	AudioSource.PlayClipAtPoint(clip, UnityEngine.Vector3 (5, 1, 0));
			
		  //  var clip: AudioClip = Resources.Load(fileName);

			// example 1: play with PlayOneShot
	//	    audio.PlayOneShot(clip);
		    // example 2: play without an AudioSource component
	//	    AudioSource.PlayClipAtPoint(clip, transform.position);
		    // example 3: play with Play
	//	    audio.clip = clip;
	//	    audio.Play();
			
			
			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);
            Globals.Assert(finchSound[soundId] == null);
            finchSound[soundId] = new Sound();//fullPath);
           // Globals.Assert(finchSound[soundId] != null);
           // (finchSound[soundId]).SetMaxVolume(maxVolume);
        
			maxVolumeFinch[soundId] = maxVolume;
        }

        public void LoadFinchSoundP1(int soundId, string fileName)
        {
            this.LoadFinchSoundP1P2(soundId, fileName, 1.0f);
        }
		
        public void FadeInP1 (int soundId, float inFadeTime)
		{

			#if FINCH_DEBUG
			#endif

			if (!playSoundFX)
				return;
			
			//Debug.Log ("FadeIn Sound " + soundId);			
			
			//First check if another looping soundId like this is already playing...
			
			for (int i = 0; i < kNumSFXChannels; i++)
			{
				if (!sfxHandleInfo[i].isFree)
				{
					if (sfxHandleInfo[i].soundId == soundId)
					{
						//Ok then yes.. it is... so..						
						//Just in case it's fading out...
						sfxHandleInfo[i].fadeState = SfxHandleFadeState.kFadeState_FadingIn;

						//and that's all...
						return;
					}
				}
			}			
			
			this.PlayFinchSoundIsLooping(soundId,1.0f,true);
			
			return;
			
			
/*			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);
            (finchSound[soundId]).Play();
            (finchSound[soundId]).FadeIn(inFadeTime);
            updateListFinch.Add(soundId);*/
        }

        public void FadeOutP1 (int soundId, float inFadeTime)
		{

			#if FINCH_DEBUG
			#endif

			if (!playSoundFX)
				return;
						
			int whichChannel = finchSound[soundId].sfxChannel;
			
			//Debug.Log ("Fade Out Sound " + soundId + "on channel " + whichChannel);			
			
			sfxHandleInfo[whichChannel].fadeState = SfxHandleFadeState.kFadeState_FadingOut;
			
//			this.StopFinchSound(soundId);
			
//			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);
//            (finchSound[soundId]).FadeOut(inFadeTime);
//            updateListFinch.Add(soundId);
        }

     //   public void SetVolumeFinchOverall(float inVol)
     //   {
     //       volumeFinchOverall = inVol;
     //   }

     //   public void FinchSetMaxVolumeP1 (int soundId, float maxVolume)
	//	{
	//		Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);
     //       maxVolumeFinch[soundId] = maxVolume;
       // }

        public void PlayFinchSoundIsLooping (int soundId, float volume, bool isLooping)
		{
			if (!playSoundFX)
				return;
			
			AudioSource audio = myObjectSFX[sfxChannel].GetComponent<AudioSource>();
			
			audio.volume = maxVolumeFinch[soundId] * volume;
//			audio.maxVolume = 1.0f;
			
			audio.loop = isLooping;
						
			if (isLooping)
			{
				//Debug.Log ("Play Looping Sound " + soundId + " on sfxHandel " + sfxChannel);							

				audio.volume = 0.0f;//maxVolumeFinch[soundId] * volume;				
				finchSound[soundId].sfxChannel = sfxChannel;
				sfxHandleInfo[sfxChannel].isFree = false;
				sfxHandleInfo[sfxChannel].soundId = soundId;
				sfxHandleInfo[sfxChannel].fadeState = SfxHandleFadeState.kFadeState_FadingIn;
				sfxHandleInfo[sfxChannel].fadeVolume = 0.0f;
				audio.clip = sfxClip[soundId];
				audio.Play();

			}
			else
			{
				//Debug.Log ("Play One-Shot Sound " + soundId + " on sfxHandel " + sfxChannel);			
				
				sfxHandleInfo[sfxChannel].isFree = true;
				audio.PlayOneShot(sfxClip[soundId]);
			}
						
			int numTries = 0;
			
			do{
				sfxChannel++;
				if (sfxChannel == kNumSFXChannels)
				{
					sfxChannel = 0;
				}
				numTries++;
			}
			while((!sfxHandleInfo[sfxChannel].isFree) && (numTries < 15));
		}		
		
        public void PlayFinchSoundP1 (int soundId, float volume)
		{
			this.PlayFinchSoundIsLooping(soundId,volume,false);

			return;
/*			
			//return;
			if (!playSoundFX)
				return;
			
			AudioSource audio = myObjectSFX[sfxChannel].GetComponent<AudioSource>();
			
			audio.volume = maxVolumeFinch[soundId] * volume;
			
			audio.PlayOneShot(sfxClip[soundId]);
			
			sfxChannel++;
			if (sfxChannel == kNumSFXChannels)
			{
				sfxChannel = 0;
			}
			
			return;
			
			#if EMAIL_BUTTON
			#endif

			if (!playSoundFX)
				return;

			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);

			if (finchSound[soundId] == null)
				return;
			
			(finchSound[soundId]).SetGain((volume * volumeFinchOverall * maxVolumeFinch[soundId]));
            if ((finchSound[soundId]).pitchAdjustable) {

                #if EMAIL_BUTTON
                #endif

                (finchSound[soundId]).SetPitch(Utilities.GetRandBetweenP1(0.95f, 1.05f));
            }

            (finchSound[soundId]).Play();
            (finchSound[soundId]).SetLooping(false);*/
        }

        public void LoopFinchSoundP1 (int soundId, float volume)
		{
			if (!playSoundFX)
				return;

			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);
            (finchSound[soundId]).SetGain((volumeFinchOverall * volume * maxVolumeFinch[soundId]));
            (finchSound[soundId]).Play();
            (finchSound[soundId]).SetLooping(true);
            updateListFinch.Add(soundId);
        }

        public void LoopFinchSoundFadeInP1P2 (int soundId, float volume, float inFadeTime)
		{
			if (!playSoundFX)
				return;

			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);
            this.FadeInP1(soundId, inFadeTime);
            (finchSound[soundId]).SetLooping(true);
            updateListFinch.Add(soundId);
        }

        public void PlayFinchSound (int soundId)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);
            this.PlayFinchSoundP1(soundId, maxVolumeFinch[soundId] * volumeFinchOverall);
        }

        public void StopFinchSound (int soundId)
		{			
			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);

			int whichChannel = finchSound[soundId].sfxChannel;
		
			//Debug.Log ("Stop Looping Sound " + soundId + " on sfxHandel " + whichChannel);													
			
			AudioSource audio = myObjectSFX[whichChannel].GetComponent<AudioSource>();

			sfxHandleInfo[whichChannel].isFree = true;
			
			audio.clip = sfxClip[soundId];
			
			audio.Stop();
		}

        public void AVSetFadeMinimumP1 (int soundId, float fadeMin)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            fadeMinimum[soundId] = fadeMin;
        }

        public void AVFadeOutToHalfP1 (int soundId, float inFadeTime)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            this.AVFadeOutP1(soundId, inFadeTime);
            fadeMinimum[soundId] = playVolumeAV[soundId] / 2.0f;
        }

        public void AVSetSoundToBeginning (int soundId)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
     //       (soundAV[soundId]).SetCurrentTime(0);
        }

        public void AVPlaySound (int soundId)
		{
			AudioSource audio = myObjectMusic.GetComponent<AudioSource>();
			
			audio.volume =  playVolumeAV[soundId];
			
			audio.loop = avLoop[soundId];				
			
			audio.clip = avClip[soundId];

			audio.Play();
			
//			audio.PlayOneShot(avClip[soundId]);			
			
			this.AVSetSoundToBeginning (soundId);
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
    //        (soundAV[soundId]).Play();
            currentSoundAV = soundId;
        }

        public void AVStopSound (int soundId)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            this.EndSoundAV(soundId);
        }

        public void AVDelayPlayAndFadeInP1P2 (float delayTime, int soundId, float inFadeTime)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            delay[soundId] = delayTime;
            pendingAddToUpdateList = soundId;
            fadeTime[soundId] = inFadeTime;
            fadeTimer[soundId] = 0;
            fadingIn[soundId] = (int)Enum.kAVPlayAndFade_In;
            //(soundAV[soundId]).SetVolume(0);
        }

        public void AVFadeInP1 (int soundId, float inFadeTime)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            delay[soundId] = 0;
            pendingAddToUpdateList = soundId;
            fadeTime[soundId] = inFadeTime;
            fadeTimer[soundId] = 0;
            fadingIn[soundId] = (int)Enum.kAVFade_In;
            //(soundAV[soundId]).SetVolume(0);
        }

        public void AVPlayAndFadeInP1 (int soundId, float inFadeTime)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            this.AVPlaySound(soundId);
            this.AVFadeInP1(soundId, inFadeTime);
        }

        public void AVFadeOutP1 (int soundId, float inFadeTime)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            fadeMinimum[soundId] = 0.0f;
            pendingAddToUpdateList = soundId;
            fadeTime[soundId] = inFadeTime;
            fadeTimer[soundId] = 0;
 //           fadingIn[soundId] = Enum.kAVFade_Out;
            delay[soundId] = 0;
        }

        public void AVFadeOutAndStopP1 (int soundId, float inFadeTime)
		{
//			this.AVStopSound(soundId);
//			return;
			
			Globals.Assert (soundId < (int)Enum2.kMaxAVSounds);
            pendingAddToUpdateList = soundId;
            fadeTime[soundId] = inFadeTime;
            fadeTimer[soundId] = 0;
            fadingIn[soundId] = (int)Enum.kAVFade_OutAndStop;
            delay[soundId] = 0;
        }

        public void AVFadeOutAndStop(float inFadeTime)
        {
            if (currentSoundAV != -1) {
                this.AVFadeOutAndStopP1(currentSoundAV, inFadeTime);
            }

        }

        public int AVSetVolumeP1(int soundId, float volume)
        {
    //        (soundAV[soundId]).SetVolume(volume);
            playVolumeAV[soundId] = volume;
            return 0;
        }

        public float GetVolumeAV(int soundId)
        {
			return playVolumeAV[soundId];//(soundAV[soundId]).Volume();
        }

        public void AVChangeToTrackP1P2(int soundId, float timeOut, float timeIn)
        {
            if (timeOut == 0) {
                if (currentSoundAV != -1) {
                    this.EndSoundAV(currentSoundAV);
                }

                this.AVPlayAndFadeInP1(soundId, timeIn);
                return;
            }

            changeTimeAV = timeIn;
            if (currentSoundAV != -1) {
                this.AVFadeOutAndStopP1(currentSoundAV, timeOut);
                changeToTrackAV = soundId;
            }
            else {
                this.AVPlayAndFadeInP1(soundId, timeIn);
            }

        }

        public void AVChangeToTrackP1(int soundId, float changeTime)
        {
            this.AVChangeToTrackP1P2(soundId, changeTime / 2.0f, changeTime / 2.0f);
        }

        public void AudioPlayerDidFinishPlayingSuccessfully(AVAudioPlayer player, bool flag)
        {
        }

        public void EndSoundAV(int soundId)
        {
           // (soundAV[soundId]).Stop();
			
			AudioSource audio = myObjectMusic.GetComponent<AudioSource>();
						
			audio.clip = avClip[soundId];

			audio.Stop();
			
            currentSoundAV = -1;
            if (changeToTrackAV != -1) {
                this.AVDelayPlayAndFadeInP1P2(Constants.kFrameRate, changeToTrackAV, changeTimeAV);
                changeToTrackAV = -1;
            }

        }

        bool AVUpdateFade(int soundId)
        {
            if (delay[soundId] > 0) {
                delay[soundId] -= Constants.kFrameRate;
                return false;
            }

            if (fadeTimer[soundId] == 0) {
                if (fadingIn[soundId] == (int)Enum.kAVPlayAndFade_In) {
                    this.AVPlaySound(soundId);
                }

            }

            fadeTimer[soundId] += Constants.kFrameRate;
            if (fadeTimer[soundId] < fadeTime[soundId]) {
                float volume;
                if ((fadingIn[soundId] == (int)Enum.kAVFade_In) || (fadingIn[soundId] == (int)Enum.kAVPlayAndFade_In)) volume = fadeMinimum[soundId] + ((1.0f - 
                  fadeMinimum[soundId]) * Utilities.GetRatioP1P2(fadeTimer[soundId], 0, fadeTime[soundId]));
                else volume = fadeMinimum[soundId] + ((1.0f - fadeMinimum[soundId]) * (1 - Utilities.GetRatioP1P2(fadeTimer[soundId], 0, fadeTime[soundId])));

                volume *= playVolumeAV[soundId];
        //        (soundAV[soundId]).SetVolume(volume);
            }
            else {
                if ((fadingIn[soundId] == (int)Enum.kAVFade_In) || (fadingIn[soundId] == (int)Enum.kAVPlayAndFade_In)) {
          //          (soundAV[soundId]).SetVolume(playVolumeAV[soundId]);
                    fadeMinimum[soundId] = 0;
                }
                else {
                    if (fadingIn[soundId] == (int)Enum.kAVFade_OutAndStop) {
                        fadingIn[soundId] = (int)Enum.kAVFade_NotFading;
                        this.EndSoundAV(soundId);
                    }
                    else {
                  //      (soundAV[soundId]).SetVolume(0);
                        fadingIn[soundId] = (int)Enum.kAVFade_NotFading;
                    }

                }

                return true;
            }

            return false;
        }

        public void QueueFinchSoundP1(int soundId, float waitTime)
        {
            finchSoundQueue.Add(soundId);
            finchSoundQueueTime.Add(waitTime + stateTimer);
        }

        public void UpdateQueuedFinches()
        {
           // NSNumber item = null;
            stateTimer += Constants.kFrameRate;
            int index = 0;
            int playSound = -1;
            foreach (int item in finchSoundQueueTime) {
                if (stateTimer >= item) {
                    playSound = index;
                    break;
                }

                index++;
            }
            if (playSound != -1) {
                int soundId = (finchSoundQueue[playSound]);
             //   this.PlayFinchSound(soundId);
                finchSoundQueue.Remove(playSound);
                finchSoundQueueTime.Remove(playSound);
            }

        }

        public void UpdateSoundEngine ()
		{
			
			//simple way for now...
			
			for (int i = 0; i < kNumSFXChannels; i++)
			{
				if (!sfxHandleInfo[i].isFree)
				{
					//means it's a looping sound... and could be fading in or out...
					
					if (sfxHandleInfo[i].Update())
					{
						//it's all done...
						
						int mySoundId = sfxHandleInfo[i].soundId;
						
						this.StopFinchSound(mySoundId);

					}
					else
					{
						//int soundId = sfxHandleInfo[i].soundId;
						
						AudioSource audio = myObjectSFX[i].GetComponent<AudioSource>();
						
						audio.volume = sfxHandleInfo[i].fadeVolume;
					}
				}
			}
			
			if (pendingAddToUpdateList != -1) {
					updateListAV.Add (pendingAddToUpdateList);
					pendingAddToUpdateList = -1;
			}

			List<int> removeListAV = new List<int> (0);			
			
			foreach (int item5 in updateListAV) 
			{
					//soundId = item5;
					if (this.AVUpdateFade (item5)) 
					{
							removeListAV.Add (item5);
					}

			}
			
			foreach (int item7 in removeListAV) 
			{
				updateListAV.Remove (item7);
			}			
		}
/*						this.UpdateQueuedFinches ();
						int soundId;
						List<int> removeListAV = new List<int> (0);
						List<int> removeListFinch = new List<int> (0);
						//NSNumber item1 = null;
						//NSNumber item2 = null;
						if (pendingAddToUpdateList != -1) {
								updateListAV.Add (pendingAddToUpdateList);
								pendingAddToUpdateList = -1;
						}

						foreach (int item5 in updateListAV) {
								soundId = item5;
								if (this.AVUpdateFade (soundId)) {
										removeListAV.Add (item5);
								}

						}
			
			foreach (int item6 in updateListFinch) 
			{
				soundId = item6;

				if (finchSound[soundId] == null)
				{
					removeListFinch.Add (item6);
				}
				else
				{
					if ((finchSound [soundId]).Update()) 
					{
						if (!(finchSound [soundId]).looping) {

							//	#if FINCH_DEBUG
							//	#endif

							removeListFinch.Add (item6);
						}
					}
				}
			}

						foreach (int item7 in removeListAV) 
						{
							updateListAV.Remove (item7);
						}
						foreach (int item8 in removeListFinch) 
						{
							updateListFinch.Remove (item8);
						}


//			updateListAV.RemoveObjectsInArray (removeListAV);
			//updateListFinch.RemoveObjectsInArray (removeListFinch);

			#if SOUNDENGINE_DEBUG
                static int count = 0;
                count++;
                if (count == 100) {
                    count = 0;
                    for (int i = 0; i < (int)Enum2.kMaxAVSounds; i++) {
                    }

                }

            #endif

        }*/

        public Sound GetFinchSound (int soundId)
		{
			Globals.Assert (soundId < (int)Enum2.kMaxFinchSounds);
            return finchSound[soundId];
        }

    }
}
