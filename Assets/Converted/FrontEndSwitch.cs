using UnityEngine;
using System;

namespace Default.Namespace
{
		public enum SwitchState{
			kSwitch_On = 0,
			kSwitch_Off,
			tates
		};
	
	
    public class FrontEndSwitch
    {
        public FrontEndButton[] button = new FrontEndButton[(int)SwitchState.tates];
        public SwitchState state;
        public CGPoint position;
        public int soundId;
        public bool active;
        public FrontEndActions actionId;
        public SwitchState State
        {
            get;
            set;
        }

        public int SoundId
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public FrontEndActions ActionId
        {
            get;
            set;
        }

		public bool GetStateBool ()
		{
			if (state == SwitchState.kSwitch_On) {
					return true;
			}
	
			return false;
		}
	
		//public void SetState(SwitchState inThing) {state = inThing;}///@property(readwrite,assign) SwitchState state;
public void SetSoundId(int inThing) {soundId = inThing;}///@property(readwrite,assign) int soundId;
public void SetActive(bool inThing) {active = inThing;}///@property(readwrite,assign) bool active;
public void SetActionId(FrontEndActions inThing) {actionId = inThing;}///@property(readwrite,assign) FrontEndActions actionId;

        public FrontEndSwitch()
        {
            //if (!base.init()) return null;

            for (int i = 0; i < (int) SwitchState.tates; i++) button[i] = new FrontEndButton(i);

            soundId = 0;
            active = true;
        }
        public void Dealloc()
        {
            for (int i = 0; i < (int) SwitchState.tates; i++) {
                button[i].Dealloc();
                button[i] = null;
            }

        }

        public void Show()
        {
            (button[(int)state]).Show();
        }

        public void Update()
        {
            for (int i = 0; i < (int) SwitchState.tates; i++) (button[i]).Update();

        }

        public void Hide()
        {
            (button[(int)state]).Hide();
        }
        public void SetLayerMask()
        {
			for(int i = 0; i < 2; i++)
			{
				if (button[i].zobject.myAtlasBillboard != null)			
				{
					button[i].zobject.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
				}
				if (button[i].zobjectLabel != null)
					if (button[i].zobjectLabel.myAtlasBillboard != null)
						button[i].zobjectLabel.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			}
		}

        public void Initialise(FrontEnd.SwitchInfo switchInfo)
        {
            active = true;
            FrontEnd.ButtonInfo info = new FrontEnd.ButtonInfo();
            info.position = switchInfo.position;
            info.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            for (int i = 0; i < (int) SwitchState.tates; i++) {
                info.texture = switchInfo.texture[i];
                (button[i]).Initialise(info);
            }

            position = switchInfo.position;
            actionId = FrontEndActions.kFrontEndAction_None;
        }

       public void StopRender()
        {
            for (int i = 0; i < (int) SwitchState.tates; i++) (button[i]).StopRender();

		}		
		
        public void Render()
        {
            for (int i = 0; i < (int) SwitchState.tates; i++) (button[i]).Render();

        }

        public FrontEndButton GetButton(SwitchState which)
        {
            Globals.Assert(which < SwitchState.tates);
            return button[(int)which];
        }
        public FrontEndButton GetButton(int which)
        {
            return this.GetButton ((SwitchState) which);
        }

        public void SetState(SwitchState newState)
        {
            if (state != newState) {
                (button[(int)state]).Hide();
                state = newState;
                (button[(int)state]).Show();
            }

        }
        public void SetState (bool newState)
		{
			if (newState)
				this.SetState(SwitchState.kSwitch_On);
			else
				this.SetState(SwitchState.kSwitch_Off);
		}

        public bool IsTouched(CGPoint inPos)
        {
            if (!active) return false;

            if ((button[(int)state]).IsTouched(inPos)) {
                if (state == SwitchState.kSwitch_On) this.SetState( SwitchState.kSwitch_Off);
                else this.SetState( SwitchState.kSwitch_On);

                (SoundEngine.Instance()).PlayFinchSound(soundId);
                return true;
            }

            return false;
        }

    }
}
