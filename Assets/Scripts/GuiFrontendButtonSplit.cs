using UnityEngine;
using System.Collections;

public class GuiFrontendButtonSplit : GuiFrontendButton {

		public SimpleFade highlightImage1;
		public SimpleFade highlightImage2;

		//----------------------------------------
		public override void Show () 
		{
				base.Show();

				highlightImage1.HideNow();
				highlightImage2.HideNow();

		}

		//----------------------------------------
		public void OnClickRight () 
		{
				base.OnClick();

				int soundEffectId = (int)Default.Namespace.Audio.Enum1.kSoundEffect_ButtonPress;
				(Default.Namespace.SoundEngine.Instance()).PlayFinchSound(soundEffectId);

				highlightImage2.ShowNow();
				highlightImage2.Hide();
				Default.Namespace.GameCenterWrapper.ShowAchievementUI();
		}
	
	//----------------------------------------
	public void OnClickLeft () 
		{
				base.OnClick();

				int soundEffectId = (int)Default.Namespace.Audio.Enum1.kSoundEffect_ButtonPress;
				(Default.Namespace.SoundEngine.Instance()).PlayFinchSound(soundEffectId);

				highlightImage1.ShowNow();
				highlightImage1.Hide();

				if (Default.Namespace.Globals.g_world.worldState == Default.Namespace.WorldState.e_FrontEnd)
					Default.Namespace.GameCenterWrapper.ShowLeaderboardUI(-1);
				else
				{
						Default.Namespace.GameCenterWrapper.ShowLeaderboardUI(Default.Namespace.Globals.g_world.game.playingLevel);
				}						
		}
}
