using UnityEngine;
using System;

namespace Default.Namespace
{
    public enum  ButtonClickStyle {
        kButtonClick_Highlight,
        kButtonClick_ThrobAndGo,
        kButtonClick_Throb
    }
    public enum  ButtonState {
        EInactive,
        EActive,
        EClicked
    }
    public class FrontEndButton
    {
        public ButtonState state;
        public ButtonClickStyle clickStyle;
        public CGPoint position;
        public Zobject zobject;
        public Zobject zobjectLabel;
        public Texture2D_Ross normalTexture;
        public Texture2D_Ross highlightTexture;
        public Texture2D_Ross labelTexture;
        public HangingButton hangingButton;
        public CGPoint labelOffset;
        public float stateTimer;
        public float width;
        public float height;
        public FrontEndScreenEnum goToScreen;
        public int myId;
        public float sparklesPosition;
        public bool isClickable;
        public FrontEndActions actionId;
        public int soundEffectId;
        public int appearSoundEffectId;
        public bool makeClickableWhenShown;
        public bool isDisabled;
        public bool flagClicked;
        public bool clickedOneFrame;
        public bool wasPressed;
        public CGPoint Position
        {
            get;
            set;
        }

        public float Height
        {
            get;
            set;
        }

        public float Width
        {
            get;
            set;
        }

        public int MyId
        {
            get;
            set;
        }

        public ButtonClickStyle ClickStyle
        {
            get;
            set;
        }

        public Texture2D_Ross HighlightTexture
        {
            get;
            set;
        }

        public ButtonState State
        {
            get;
            set;
        }

        public bool IsClickable
        {
            get;
            set;
        }

        public FrontEndActions ActionId
        {
            get;
            set;
        }

        public FrontEndScreenEnum GoToScreen
        {
            get;
            set;
        }

        public bool WasPressed
        {
            get;
            set;
        }

        public Zobject ZobjectLabel
        {
            get;
            set;
        }

        public int SoundEffectId
        {
            get;
            set;
        }

        public HangingButton HangingButton
        {
            get;
            set;
        }

		//public void SetWaitToShow(float inThing) {waitToShow = inThing;}///@property(readwrite,assign) float waitToShow;
public void SetHangingButton(HangingButton inThing) {hangingButton = inThing;}////@property(readwrite,assign) HangingButton* hangingButton;
public void SetZobject(Zobject inThing) {zobject = inThing;}////@property(readwrite,assign) Zobject* zobject;
public void SetZobjectLabel(Zobject inThing) {zobjectLabel = inThing;}////@property(readwrite,assign) Zobject* zobjectLabel;
//public void SetAtlas(ZAtlas inThing) {atlas = inThing;}////@property(readwrite,assign) ZAtlas* atlas;
public void SetHeight(float inThing) {height = inThing;}///@property(readwrite,assign) float height;
public void SetWidth(float inThing) {width = inThing;}///@property(readwrite,assign) float width;
public void SetMyId(int inThing) {myId = inThing;}///@property(readwrite,assign) int myId;
public void SetClickStyle(ButtonClickStyle inThing) {clickStyle = inThing;}///@property(readwrite,assign) ButtonClickStyle clickStyle;
public void SetHighlightTexture(Texture2D_Ross inThing) {highlightTexture = inThing;}////@property(readwrite,assign) Texture2D* highlightTexture;
public void SetState(ButtonState inThing) {state = inThing;}///@property(readwrite,assign) ButtonState state;
public void SetIsClickable(bool inThing) {isClickable = inThing;}///@property(readwrite,assign) bool isClickable;
public void SetActionId(FrontEndActions inThing) {actionId = inThing;}///@property(readwrite,assign) FrontEndActions actionId;
public void SetGoToScreen(FrontEndScreenEnum inThing) {goToScreen = inThing;}///@property(readwrite,assign) FrontEndScreenEnum goToScreen;
public void SetWasPressed(bool inThing) {wasPressed = inThing;}///@property(readwrite,assign) bool wasPressed;
public void SetSoundEffectId(int inThing) {soundEffectId = inThing;}///@property(readwrite,assign) int soundEffectId;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;


        public FrontEndButton(int buttonId)
        {
            //if (!base.init()) return null;

            hangingButton = null;
            zobjectLabel = null;
            goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            myId = buttonId;
            zobject = new Zobject();
            state = ButtonState.EInactive;
            isClickable = true;
            actionId = FrontEndActions.kFrontEndAction_None;
            soundEffectId = (int)Audio.Enum1.kSoundEffect_ButtonPress;
            flagClicked = false;
            clickedOneFrame = false;
            wasPressed = false;
            isDisabled = false;
            labelOffset = Utilities.CGPointMake(0, 0);
            //return this;
        }

//        public FrontEndButton()
  //      {
    //        return this.init(0);
      //  }
        public void Dealloc()
        {
            if (zobjectLabel != null) {
				zobjectLabel.Dealloc();
				zobjectLabel = null;
			}

            if (hangingButton != null) {
				hangingButton.Dealloc();
				hangingButton = null;
			}

            if (zobject != null) {
				zobject.Dealloc();
				zobject = null;
			}			
        }

        public Zobject Zobject
        {
            get;
            set;
        }

        public void StopRender()
        {
			if (hangingButton != null)
			{
				hangingButton.StopRender ();
			}
			
			zobject.StopRender();
			if (zobjectLabel != null)
				zobjectLabel.StopRender();
//			if (hangingButton != null)
			//	hangingButton.StopRender();
		}
		
		
        public void Disable()
        {
            isClickable = false;
            isDisabled = true;
            zobject.SetShowAlpha(0.3f);
        }

        public void DisableUnHighlight()
        {
            isClickable = false;
            isDisabled = true;
            this.UnHighlight();
        }

        public void ShowIsActuallyStarting()
        {
        }

        public void Show()
        {
            if (hangingButton != null) 
			{
                hangingButton.Show(0.5f);
            }

            if (isDisabled) {
                isClickable = true;
                isDisabled = false;
                zobject.SetShowAlpha(1);
            }

            wasPressed = false;
            state = ButtonState.EActive;
            if (clickStyle == (int) ButtonClickStyle.kButtonClick_Highlight) {
                zobject.SetTexture(normalTexture);
            }

            zobject.SetScreenPosition(position);
            zobject.SetState( ZobjectState.kZobjectHidden);
            zobject.Show();
            if (zobjectLabel != null) {
                CGPoint labePos = Utilities.CGPointMake(position.x + labelOffset.x, position.y + labelOffset.y);
                zobjectLabel.SetScreenPosition(labePos);
                zobjectLabel.SetState( ZobjectState.kZobjectHidden);
                zobjectLabel.Show();
            }

        }

        public void AddHangingButton(HangingButton.HangingButtonInfo info)
        {
            if (hangingButton == null) {
                hangingButton = new HangingButton();
            }

            hangingButton.AddToSceneP1(info, this);
        }

        public void AddLabelP1(Texture2D_Ross inTex, CGPoint inOffset)
        {
            labelOffset = inOffset;
            if (zobjectLabel == null) {
                zobjectLabel = new Zobject();
            }

            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.texture = inTex;
            info.startState = ZobjectState.kZobjectHidden;
            zobjectLabel.Initialise(info);
            zobjectLabel.SetShowStyle(zobject.showStyle);
            zobjectLabel.SetHideStyle(zobject.hideStyle);
            zobjectLabel.SetWaitToShow(zobject.waitToShow);
            CGPoint labePos = Utilities.CGPointMake(position.x + labelOffset.x, position.y + labelOffset.y);
            zobjectLabel.SetScreenPosition(labePos);
            zobjectLabel.SetState( ZobjectState.kZobjectHidden);
        }

        public void AddLabelP1P2(ZAtlas inTex, int inSubTextureId, CGPoint inOffset)
        {
            labelOffset = inOffset;
            if (zobjectLabel == null) {
                zobjectLabel = new Zobject();
            }

            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.texture = null;
            info.startState = ZobjectState.kZobjectHidden;
            zobjectLabel.Initialise(info);
            zobjectLabel.SetAtlas(inTex);
            zobjectLabel.SetSubTextureId(inSubTextureId);
            zobjectLabel.SetShowStyle(zobject.showStyle);
            zobjectLabel.SetHideStyle(zobject.hideStyle);
            zobjectLabel.SetWaitToShow(zobject.waitToShow);
            CGPoint labePos = Utilities.CGPointMake(position.x + labelOffset.x, position.y + labelOffset.y);
            zobjectLabel.SetScreenPosition(labePos);
            zobjectLabel.SetState( ZobjectState.kZobjectHidden);
        }

        public void Hide()
        {
            state = ButtonState.EInactive;
            zobject.Hide();
			if (zobjectLabel != null)
	            zobjectLabel.Hide();
        }


        public void Disappear()
        {
            state = ButtonState.EInactive;
            zobject.Disappear();
            if (zobjectLabel != null) zobjectLabel.Disappear();

        }

        public void Highlight()
        {
            zobject.SetTexture(highlightTexture);
        }

        public void UnHighlight()
        {
            zobject.SetTexture(normalTexture);
        }

        public void Click()
        {
            flagClicked = true;
            (SoundEngine.Instance()).PlayFinchSound(soundEffectId);
            switch (clickStyle) {
            case ButtonClickStyle.kButtonClick_ThrobAndGo :
                this.ThrobAndGo();
                break;
            case ButtonClickStyle.kButtonClick_Throb :
                this.Throb();
                break;
            case ButtonClickStyle.kButtonClick_Highlight :
                this.Highlight();
                break;
            }

   //         if (zobject.zBubble) {
     //           (zobject.zBubble).Pop();
       //     }

        }

        public void Throb()
        {
            zobject.Throb();
			if (zobjectLabel != null)
	            zobjectLabel.Throb();
        }

        public void ThrobAndGo()
        {
            state = ButtonState.EInactive;
            zobject.Throb();
            zobject.QueueAction( ZobjectAction.nHide);
			if (zobjectLabel != null)
			{
	            zobjectLabel.Throb();
        	    zobjectLabel.QueueAction( ZobjectAction.nHide);
			}
        }

        public void Render()
        {
			
            if (zobject.atlas == null) {
				if (!this.IsOnScreen()) {
					this.StopRender();
				}
				else{
					zobject.Render();
	                if (zobjectLabel != null) {
	                    CGPoint labePos = Utilities.CGPointMake(zobject.displayPosition.x + labelOffset.x, zobject.displayPosition.y + labelOffset.y);
	                    zobjectLabel.SetScreenPosition(labePos);
	                    zobjectLabel.Render();
	                }
				}

            }
            else {
                if (this.IsOnScreen()) {
                    ////glEnableClientState (GL_COLOR_ARRAY);
                    (DrawManager.Instance()).Begin(zobject.atlas);
                    if (hangingButton != null) 
										{
                        zobject.SetRotation(hangingButton.UpdateRotation());
						if (hangingButton != null)
						{
	                        hangingButton.Render(this,zobject.atlas);
						}

												if (hangingButton.hangingButtonScale != 1.0f)
														zobject.SetShowScale(hangingButton.hangingButtonScale);

                        zobject.RenderToDrawArrays_Rotatable();
                    }
                    else {
                        zobject.RenderToDrawArrays();
                    }

                    (DrawManager.Instance()).Flush();
                    if (zobjectLabel != null) {
                        CGPoint labePos = Utilities.CGPointMake(zobject.displayPosition.x + labelOffset.x, zobject.displayPosition.y + labelOffset.y);
                        zobjectLabel.SetScreenPosition(labePos);
                        zobjectLabel.RenderFromAtlas();
                    }

                    ////glDisableClientState (GL_COLOR_ARRAY);
                }
				else
				{
					this.StopRender();
				}

            }

        }

        public bool IsOnScreen()
        {
            return (Utilities.IsOnScreenP1(zobject.screenPosition, 80.0f));
        }

        public void HideLabel()
        {
            zobjectLabel.Hide();
        }

        public void UpdateSparkles()
        {
						return;

            const float sparklesSpeed = 0.015f;
            sparklesPosition += sparklesSpeed;
            if (sparklesPosition >= 1) sparklesPosition -= 1;

            CGPoint screenPosition;
            CGPoint buttonPosition = zobject.screenPosition;
            if (sparklesPosition < 0.25f) {
                float ratio = Utilities.GetRatioP1P2(sparklesPosition, 0, 0.25f);
                screenPosition = Utilities.CGPointMake(buttonPosition.x - 32 + 64 * ratio, buttonPosition.y + 32);
            }
            else if (sparklesPosition < 0.5f) {
                float ratio = Utilities.GetRatioP1P2(sparklesPosition, 0.25f, 0.5f);
                screenPosition = Utilities.CGPointMake(buttonPosition.x - 32 + 64, buttonPosition.y + 32 - (64 * ratio));
            }
            else if (sparklesPosition < 0.75) {
                float ratio = Utilities.GetRatioP1P2(sparklesPosition, 0.5f, 0.75f);
                screenPosition = Utilities.CGPointMake(buttonPosition.x - 32 + 64 - (64 * ratio), buttonPosition.y + 32 - 64);
            }
            else {
                float ratio = Utilities.GetRatioP1P2(sparklesPosition, 0.75f, 1);
                screenPosition = Utilities.CGPointMake(buttonPosition.x - 32, buttonPosition.y + 32 - 64 + (64 * ratio));
            }

            screenPosition.x += (float)(Utilities.GetRand( 6) - 3);
            screenPosition.y += (float)(Utilities.GetRand( 6) - 3);
            if (Globals.deviceIPad) {
                screenPosition.x += 32.0f;
            }

            ParticleSystemRoss.EffectInfo info = new ParticleSystemRoss.EffectInfo();
            info.startPosition = screenPosition;
            info.type = EffectType.kEffect_SingleSparkle;
            (ParticleSystemRoss.Instance()).AddParticleEffect(info);
        }

        public void UpdateClickedFlag()
        {
            if (clickedOneFrame) {
                clickedOneFrame = false;
                flagClicked = false;
            }

            if (flagClicked) {
                clickedOneFrame = true;
                wasPressed = true;
            }

        }

        public bool Update()
        {
            this.UpdateClickedFlag();
            zobject.Update();
            if (zobjectLabel != null) zobjectLabel.Update();

            if (makeClickableWhenShown) if (zobject.state ==  ZobjectState.kZobjectShown) {
                makeClickableWhenShown = false;
                isClickable = true;
            }

            return clickedOneFrame;
        }

        public void SetShowStyle(int inStyle)
        {
            zobject.SetShowStyle((ZobjectShowStyle) inStyle);
            if (zobjectLabel != null) zobjectLabel.SetShowStyle((ZobjectShowStyle) inStyle);

        }

        public void SetDefaults()
        {
            clickStyle = ButtonClickStyle.kButtonClick_ThrobAndGo;
            actionId = FrontEndActions.kFrontEndAction_None;
            makeClickableWhenShown = false;
            flagClicked = false;
            clickedOneFrame = false;
            wasPressed = false;
        }

        public void Initialise(FrontEnd.ButtonInfo buttonInfo)
        {
            this.InitialiseP1(buttonInfo, (int) (int) ZobjectShowStyle.kZobjectShow_Zoom);
        }

        public void InitialiseP1(FrontEnd.ButtonInfo buttonInfo, int inShowStyle)
        {			
            this.SetDefaults();
            sparklesPosition = 0;
            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.position = buttonInfo.position;
            info.texture = buttonInfo.texture;
            normalTexture = info.texture;
            info.startState = ZobjectState.kZobjectHidden;
            info.isMapObject = false;
            zobject.Initialise(info);
            zobject.SetShowStyle(inShowStyle);
            zobject.SetThrobSize(0.1f);
            zobject.SetThrobTime(0.16f);
            position = buttonInfo.position;
			if (buttonInfo.texture != null)
			{
	            width = (float) (buttonInfo.texture).pixelsWide;
	            height = (float) (buttonInfo.texture).pixelsHigh;
			}
			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				width /= 2.0f;
				height /= 2.0f;
			}
			
			
            goToScreen = buttonInfo.goToScreen;
            zobject.SetAtlas(null);
            //buttonInfo.textureLabel = null;
            if (buttonInfo.textureLabel != null) {
                if (zobjectLabel == null) {
                    zobjectLabel = new Zobject();
                }

                info.texture = buttonInfo.textureLabel;
                zobjectLabel.Initialise(info);
                zobjectLabel.SetShowStyle(inShowStyle);
            }

        }

        public void NotClickableTilShown()
        {
            isClickable = false;
            makeClickableWhenShown = true;
        }

        public void ChangePosition(CGPoint newPos)
        {
            position = newPos;
            zobject.SetScreenPosition(position);
            zobject.SetStartPosition(position);
            if (zobjectLabel != null) 
			{
				zobjectLabel.SetScreenPosition(position);
				zobjectLabel.SetStartPosition(position);
			}
        }

        public void SetAtlasAndSubtextureP1(ZAtlas inAtlas, int inSubTextureId)
        {
            zobject.SetAtlas(inAtlas);
            zobject.SetSubTextureId(inSubTextureId);
            width = 2.0f * inAtlas.GetSubTextureWidth(inSubTextureId) / Constants.kScreenMultiplierForShorts;
            height = 2.0f * inAtlas.GetSubTextureHeight(inSubTextureId) / Constants.kScreenMultiplierForShorts;
            if (Globals.deviceIPad) {
                width = 1.0f * inAtlas.GetSubTextureWidth(inSubTextureId) / Constants.kScreenMultiplierForShorts;
                height = 1.0f * inAtlas.GetSubTextureHeight(inSubTextureId) / Constants.kScreenMultiplierForShorts;
            }
            else {
                width = 2.0f * inAtlas.GetSubTextureWidth(inSubTextureId) / Constants.kScreenMultiplierForShorts;
                height = 2.0f * inAtlas.GetSubTextureHeight(inSubTextureId) / Constants.kScreenMultiplierForShorts;
            }
			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				width /= 2.0f;
				height /= 2.0f;
			}
			
			zobject.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
        }

        public void ChangeTexture(Texture2D_Ross newTexture)
        {
            zobject.SetTexture(newTexture);
            if (newTexture == null) {
                width = 0;
                height = 0;
            }
            else {
                width = (float) newTexture.pixelsWide;
                height = (float) newTexture.pixelsHigh;
            }
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				width /= 2.0f;
				height /= 2.0f;
			}

        }

        bool CanClick()
        {
            if (state != ButtonState.EActive) return false;

            if ((width == 0) || (height == 0)) return false;

            if (!isClickable) {
                return false;
            }

            return true;
        }

        public bool HandleTap(CGPoint inPosition)
        {
            if (!this.CanClick()) return false;

            if (this.IsTouched(inPosition)) {
                this.Click();
                return true;
            }

            return false;
        }

        public bool IsTouched_NoCanClick(CGPoint inPos)
        {
            if (Utilities.IsWithinRectangleP1P2P3(inPos, position, width, height)) {
                return true;
            }

            return false;
        }

        public bool IsTouched(CGPoint inPos)
        {
            if (Utilities.IsWithinRectangleP1P2P3(inPos, position, width, height)) 
			{
                if (!this.CanClick()) return false;

                return true;
            }

            return false;
        }

        public bool IsTouchedP1(int xPos, int yPos)
        {
            return this.IsTouched(Utilities.CGPointMake(xPos, yPos));
        }

    }
}
