using UnityEngine;
using System;

namespace Default.Namespace
{
    public class FrontEndScreen
    {
        public int numNumbers;
        public int numButtons;
        public int numFunnyWords;
        public int numSwitches;
        public int numQueries;
        public FrontEndButton[] button = new FrontEndButton[(int)Enum.kMaxNumButtons];
        public FunnyWord[] funnyWord = new FunnyWord[(int)Enum.kMaxFunnyWords];
        public FrontEndSwitch[] frontEndSwitch = new FrontEndSwitch[(int)Enum.kMaxSwitches];
        public FrontEndQuery[] query = new FrontEndQuery[(int)Enum.kMaxQueries];
        public Zscore[] number = new Zscore[(int)Enum.kMaxNumbersPerScreen];
        public int pressedButton;
        public int pressedSwitch;
        public int lastPressedButton;
        public int lastPressedSwitch;
        public float showSpeed;
        public Texture2D_Ross backScreen;

		public Billboard backScreenBillboard;
		
		public int myId;
        public int selectedLevel;
        public FrontEnd menu;
        public bool inQuery;
        public struct SpecialBackParameters{
            public CGPoint renderOffset;
            public float scale;
        };

		public void SetBackScreen (Texture2D_Ross inTexture)
		{
//			need a billboard here to render the texture stored in this Texture2D - and in fact we don't need a t2d here at all
			
			if (inTexture == null)
			{
				backScreenBillboard = null;
				return;
			}
			
			if (backScreenBillboard == null)
				backScreenBillboard = new Billboard("fescreeback" + myId.ToString());
			
			backScreenBillboard.SetTexture2D(inTexture);
			
//			backScreen = inTexture;
		}

        public struct AddFunnyWordInfo{
            public CGPoint position;
            public float scale;
            public string inString;
        };

        public enum Enum {
            kMaxNumButtons = 110,
            kMaxFunnyWords = 29,
            kMaxSwitches = 6,
            kMaxQueries = 5,
            kMaxNumbersPerScreen = 80,
        };
        public float ShowSpeed
        {
            get;
            set;
        }

//        public Texture2D_Ross BackScreen
  //      {
    //        get;
      //      set;
       // }

        public bool InQuery
        {
            get;
            set;
        }

        public int LastPressedButton
        {
            get;
            set;
        }

        public int LastPressedSwitch
        {
            get;
            set;
        }

        public int SelectedLevel
        {
            get;
            set;
        }

        public int NumQueries
        {
            get;
            set;
        }

        public int NumNumbers
        {
            get;
            set;
        }
		public void SetShowSpeed(float inThing) {showSpeed = inThing;}///@property(readwrite,assign) float showSpeed;
//public void SetBackScreen(string inThing) {backScreen = inThing;}////@property(readwrite,assign) Texture2D* backScreen;
//public void SetShake(Zshake inThing) {shake = inThing;}////@property(readwrite,assign) Zshake* shake;
public void SetInQuery(bool inThing) {inQuery = inThing;}///@property(readwrite,assign) bool inQuery;
public void SetLastPressedButton(int inThing) {lastPressedButton = inThing;}///@property(readwrite,assign) int lastPressedButton;
public void SetLastPressedSwitch(int inThing) {lastPressedSwitch = inThing;}///@property(readwrite,assign) int lastPressedSwitch;
public void SetSelectedLevel(int inThing) {selectedLevel = inThing;}///@property(readwrite,assign) int selectedLevel;
public void SetNumQueries(int inThing) {numQueries = inThing;}///@property(readwrite,assign) int numQueries;
public void SetNumNumbers(int inThing) {numNumbers = inThing;}///@property(readwrite,assign) int numNumbers;
		
        public FrontEndScreen(int inId, FrontEnd inMenu)
        {
            //if (!base.init()) return null;

            myId = inId;
            menu = inMenu;
            showSpeed = 0.15f;
			
			backScreenBillboard = null;//new Billboard("fescreeback" + myId.ToString());
			
			//backScreen = new Texture2D_Ross();
            //return this;
        }
        public void Dealloc()
        {
            this.ReleaseAllButtons();
        }

        public void ResetInfo()
        {
            this.Setup();
        }
		
		public void StopRender()
		{
			if (backScreenBillboard != null)
				backScreenBillboard.StopRender();

            for (int i = 0; i < numButtons; i++) {
                    button[i].StopRender();
            }
            for (int i = 0; i < numSwitches; i++) {
                    frontEndSwitch[i].StopRender();
            }
            for (int i = 0; i < numFunnyWords; i++) {
                    funnyWord[i].StopRender();
            }
            for (int i = 0; i < numQueries; i++) {
					query[i].StopRender();
            }

            for (int i = 0; i < numNumbers; i++) {
            		number[i].StopRender();

            }
		
		}	
		
		public void SetFunnyWordsToStartPosition()
		{
            for (int i = 0; i < numFunnyWords; i++) 
			{
                if (funnyWord[i] != null) 
				{					
					funnyWord[i].SetupLetters();
					funnyWord[i].Show();
                }

            }
		}

        public void PrintOutFunnyWords()
        {
            for (int i = 0; i < numFunnyWords; i++) 
			{
                if (funnyWord[i] != null) 
				{					
					funnyWord[i].PrintOut();
                }

            }
		}		
		
        public void ReleaseAllButtons()
        {
			//Debug.Log("FrontEndScreen: " + this + " Release All Buttons");

			
            for (int i = 0; i < numButtons; i++) {
                if (button[i] != null) {
					button[i].StopRender();
                    button[i].Dealloc();
                    button[i] = null;
                }

            }

            for (int i = 0; i < numSwitches; i++) {
                if (frontEndSwitch[i] != null) {
					frontEndSwitch[i].StopRender();
                    frontEndSwitch[i].Dealloc();
                    frontEndSwitch[i] = null;
                }

            }

            for (int i = 0; i < numQueries; i++) {
                if (query[i] != null) {
					query[i].StopRender();
					query[i].Dealloc();
					query[i] = null;
                }

            }

            for (int i = 0; i < numNumbers; i++) {
                if (number[i] != null) {
            		number[i].StopRender();
                    number[i].Dealloc();
                    number[i] = null;
                }

            }

            for (int i = 0; i < numFunnyWords; i++) {
                if (funnyWord[i] != null) {
       				funnyWord[i].StopRender();
                    funnyWord[i].Dealloc();
                    funnyWord[i] = null;
                }

            }

        }

        public void OnGUI()
		{
            for (int i = 0; i < numFunnyWords; i++) {
                if (funnyWord[i] != null) {
       				funnyWord[i].OnGUI();
                }
            }
		}


        public Zscore GetNumber(int which)
        {
            Globals.Assert(which < numNumbers);
            return number[which];
        }

        public FrontEndQuery GetQuery(int which)
        {
            Globals.Assert(which < numQueries);
            return query[which];
        }

        public FrontEndSwitch GetSwitch(int which)
        {
            Globals.Assert(which < numSwitches);
            return frontEndSwitch[which];
        }

        public FrontEndButton GetButton(int which)
        {
            Globals.Assert(which < numButtons);
            return button[which];
        }

        public FrontEndButton GetPressedButton()
        {
            if (lastPressedButton != -1) return button[lastPressedButton];
            else return null;

        }

        public FrontEndSwitch GetPressedSwitch()
        {
            if (lastPressedSwitch != -1) return frontEndSwitch[lastPressedSwitch];
            else return null;

        }

        public void Setup()
        {
            numFunnyWords = 0;
            numSwitches = 0;
            numButtons = 0;
            numQueries = 0;
            numNumbers = 0;
        }

        public void WobbleAllHangingButtons()
        {
            for (int i = 0; i < numButtons; i++) {
                if ((button[i]).hangingButton != null) {
                    ((button[i]).hangingButton).Show(0.8f);
                }

            }

        }

        public FunnyWord GetFunnyWord(int which)
        {
            Globals.Assert(which < numFunnyWords);
            return funnyWord[which];
        }

        public void ShowIsActuallyStarting()
        {
            for (int i = 0; i < numButtons; i++) {
                (button[i]).ShowIsActuallyStarting();
            }

        }

        public void ShowButtons()
        {
            inQuery = false;
            lastPressedButton = -1;
            lastPressedSwitch = -1;
            pressedButton = -1;
            pressedSwitch = -1;
            for (int i = 0; i < numButtons; i++) {
                (button[i]).Show();
            }

            for (int i = 0; i < numSwitches; i++) (frontEndSwitch[i]).Show();

            for (int i = 0; i < numFunnyWords; i++) {
                (funnyWord[i]).Show((0.1f * ((float) i)));
            }

            for (int i = 0; i < numNumbers; i++) {
                (number[i]).Show();
            }

        }

        public void ShowQuery(int which)
        {
            inQuery = false;
            (query[which]).Show();
        }

        public void HideButtons()
        {
            for (int i = 0; i < numButtons; i++) {
                (button[i]).Hide();
            }

            for (int i = 0; i < numNumbers; i++) {
                (number[i]).Hide();
            }
			
		//	numSwitches
        }

        public bool HandleTapOnButtonP1(int whichButton, CGPoint position)
        {
            if ((button[whichButton]).IsTouchedP1((int) position.x, (int) position.y)) {
                (button[whichButton]).Click();
                pressedButton = whichButton;
                lastPressedButton = whichButton;
                return true;
            }

            return false;
        }

        public void HandleTap(CGPoint position)
        {
            if (!inQuery) {
                for (int i = 0; i < numButtons; i++) {
                    if (this.HandleTapOnButtonP1(i, position)) {
                        break;
                    }

                }

                for (int i = 0; i < numSwitches; i++) {
                    if ((frontEndSwitch[i]).IsTouched(position)) {
                        pressedSwitch = i;
                        lastPressedSwitch = i;
                        break;
                    }

                }

            }

            for (int i = 0; i < numQueries; i++) {
                (query[i]).HandleTap(position);
            }

        }

        public int AddFunnyWord(FrontEndScreen.AddFunnyWordInfo fInfo)
        {
            Globals.Assert(numFunnyWords < (int)Enum.kMaxFunnyWords);
            if (funnyWord[numFunnyWords] == null) {
                funnyWord[numFunnyWords] = new FunnyWord();
            }

            FunnyWord.WordInfo info;
            info.position = fInfo.position;
            info.scale = fInfo.scale;
            info.isCentrePos = true;
            (funnyWord[numFunnyWords]).InitWithWordNewP1(info, fInfo.inString);
            (funnyWord[numFunnyWords]).SetColour(Constants.kColourLightGreen);
            numFunnyWords++;
            return (numFunnyWords - 1);
        }

        public int AddFunnyWordP1P2P3P4P5P6(ZFont inFont, ZAtlas inLinesAtlas, ZAtlas inColoursAtlas, CGPoint position, float scale, string inWord, bool
          isCentrePosition)
        {
            return this.AddFunnyWordP1P2P3P4P5P6P7(inFont, inLinesAtlas, inColoursAtlas, position, scale, inWord, isCentrePosition, Constants.kColourLightGreen);
        }

        public void SetFunnyWordWaitToShowP1(int which, float inAmount)
        {
            Globals.Assert(which < (int)Enum.kMaxFunnyWords);
        }

        public int AddFunnyWordP1P2P3P4P5P6P7(ZFont inFont, ZAtlas inLinesAtlas, ZAtlas inColoursAtlas, CGPoint position, float scale, string inWord, bool
          isCentrePosition, Constants.RossColour inCol)
        {
            Globals.Assert(numFunnyWords < (int)Enum.kMaxFunnyWords);
            if (funnyWord[numFunnyWords] == null) {
                funnyWord[numFunnyWords] = new FunnyWord();
            }

            (funnyWord[numFunnyWords]).SetFont(inFont);
            FunnyWord.WordInfo info;
            info.position = position;
            info.scale = scale;
            info.isCentrePos = isCentrePosition;
			            (funnyWord[numFunnyWords]).SetColourAtlas(inColoursAtlas);
			(funnyWord[numFunnyWords]).InitWithWordP1(info, inWord);
            (funnyWord[numFunnyWords]).SetColour(inCol);
            (funnyWord[numFunnyWords]).SetLineAtlas(inLinesAtlas);
            numFunnyWords++;
            return (numFunnyWords - 1);
        }

        public int AddFunnyWordP1P2P3P4P5(ZFont inFont, ZAtlas inLinesAtlas, ZAtlas inColoursAtlas, CGPoint position, float scale, string inWord)
        {
            return this.AddFunnyWordP1P2P3P4P5P6(inFont, inLinesAtlas, inColoursAtlas, position, scale, inWord, false);
        }

        public int AddSwitch(FrontEnd.SwitchInfo info)
        {
            Globals.Assert(numSwitches < (int)Enum.kMaxSwitches);
            if (frontEndSwitch[numSwitches] == null) {
                frontEndSwitch[numSwitches] = new FrontEndSwitch();
            }

            (frontEndSwitch[numSwitches]).Initialise(info);
            numSwitches++;
            return (numSwitches - 1);
        }

        public int AddNumber(Zscore.ZscoreInfo info)
        {
            Globals.Assert(numNumbers < (int)Enum.kMaxNumbersPerScreen);
            if (number[numNumbers] == null) {
                number[numNumbers] = new Zscore();
            }
			
			(number[numNumbers]).SetFontAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));

            (number[numNumbers]).Initialise(info);
            numNumbers++;
            return (numNumbers - 1);
        }

        public int AddQuery(FrontEndQuery.QueryInfo info)
        {
            Globals.Assert(numQueries < (int)Enum.kMaxQueries);
            if (query[numQueries] == null) {
                query[numQueries] = new FrontEndQuery();
            }

            (query[numQueries]).Initialise(info);
            numQueries++;
            return (numQueries - 1);
        }

        public int AddQueryNew(FrontEndQuery.QueryInfoNew info)
        {
            Globals.Assert(numQueries < (int)Enum.kMaxQueries);
            if (query[numQueries] == null) {
                query[numQueries] = new FrontEndQuery();
            }

            (query[numQueries]).InitialiseNew(info);
            numQueries++;
            return (numQueries - 1);
        }

        public int AddButton(FrontEnd.ButtonInfo buttonInfo)
        {
            float waitShow = showSpeed * (float) numButtons;
            return this.AddButtonP1(buttonInfo, waitShow);
        }

        public int AddButtonP1(FrontEnd.ButtonInfo buttonInfo, float inWait)
        {
            Globals.Assert(numButtons < (int)Enum.kMaxNumButtons);
            if (button[numButtons] == null) {
                button[numButtons] = new FrontEndButton(numButtons);
            }

            (button[numButtons]).Initialise(buttonInfo);
            ((button[numButtons]).zobject).SetWaitToShow(inWait);
            numButtons++;
            return numButtons - 1;
        }

        public bool Update()
        {
            bool inTransition = ((Ztransition.GetTransition()).inTransition) && ((Ztransition.GetTransition()).area == TransitionArea.
              kTransition_Frontend);
            for (int i = 0; i < numButtons; i++) {
                (button[i]).Update();
            }

            for (int i = 0; i < numSwitches; i++) (frontEndSwitch[i]).Update();

            for (int i = 0; i < numFunnyWords; i++) (funnyWord[i]).Update();

            for (int i = 0; i < numNumbers; i++) (number[i]).Update();

            for (int i = 0; i < numQueries; i++) {
                if ((query[i]).Update()) {
                    inQuery = false;
                    if ((query[i]).chosenButton ==  QueryButton.nYes) {
                    }

                }

            }

            if (inTransition) {
                return false;
            }

            if (pressedButton != -1) {
                pressedButton = -1;
                return true;
            }

            if (pressedSwitch != -1) {
                pressedSwitch = -1;
                return true;
            }

            return false;
        }

        public void RenderScene()
        {
            this.RenderScene(Utilities.CGPointMake(0, 0));
        }

        public void RenderBackSceneSpecial(SpecialBackParameters info)
        {
            //glDisable (GL_BLEND);
            CGPoint pos;
            pos.x = 160.0f;
            pos.y = 240.0f;
            pos.x += info.renderOffset.x;
            pos.y += info.renderOffset.y;
			
			backScreenBillboard.RenderAtPosition(pos,1.0f,0.0f,1.0f,0);
			
//            backScreen.DrawAtPointAndScaleP1(pos, (0.5f * info.scale));
  
//			backScreenBillboard
			
			//glEnable (GL_BLEND);
        }

				public void RenderBackScene_StretchToFit()
				{

						CGRect bounds = UIScreen.bounds;

						if (backScreenBillboard != null)
						{
														bounds.Size.Height = Globals.g_world.screenHeight;
														bounds.Size.Width = Globals.g_world.screenWidth;

//								float scale = Globals.g_world.screenHeight / backScreenBillboard.width;
//								CGPoint pos;
//								pos.x = Globals.g_world.coordinatesWidth / 2.0f;
//								pos.y = 240.0f;

//								backScreenBillboard.RenderAtPosition(pos,scale,0.0f,1.0f,0);// .DrawInRect(bounds);
								backScreenBillboard.RenderInRect(bounds,1.0f);// .DrawInRect(bounds);

						}
						//						backScreenBillboard.RenderInRect(bounds,1.0f);// .DrawInRect(bounds);
						//glEnable (GL_BLEND);
				}

        public void RenderBackScene()
        {

            #if PLAY_HORIZONTAL
                CGRect bounds = UIScreen.bounds;
                float tempX = bounds.Size.Width;
                bounds.Size.Width = bounds.Size.Height;
                bounds.Size.Height = tempX;
            #else
                CGRect bounds = UIScreen.bounds;
            #endif

//						bounds.Size.Height = Globals.g_world.screenHeight;
//						bounds.Size.Width = Globals.g_world.screenWidth;
//
//								float scaleM = Default.Namespace.Globals.g_world.screenWidth / bounds.Size.Width;
//								bounds.Size.Width *= scaleM;
//								bounds.Size.Height *= scaleM;


            //glDisable (GL_BLEND);
			if (backScreenBillboard != null)
						{
								float scale = Globals.g_world.screenHeight / backScreenBillboard.width;
								CGPoint pos;
								pos.x = 160.0f;//Globals.g_world.coordinatesWidth / 2.0f;
								pos.y = 240.0f;


								backScreenBillboard.RenderAtPosition(pos,scale,0.0f,1.0f,0);// .DrawInRect(bounds);
						}
//						backScreenBillboard.RenderInRect(bounds,1.0f);// .DrawInRect(bounds);
            //glEnable (GL_BLEND);
        }

        public void RenderBackSceneWithColour(Constants.RossColour inCol)
        {
            CGRect bounds = Utilities.CGRectMake(0, 0, 320, 480);
            //glDisable (GL_BLEND);
            backScreen.DrawInRectColourP1(bounds, inCol);
            //glEnable (GL_BLEND);
        }

        public void RenderSwitch(int switchId)
        {
            Globals.Assert(switchId < numSwitches);
            (frontEndSwitch[switchId]).Render();
        }

        public void RenderFrontScene()
        {
            for (int i = 0; i < numButtons; i++) {
                (button[i]).Render();
            }

            for (int i = 0; i < numSwitches; i++) 
				(frontEndSwitch[i]).Render();

            for (int i = 0; i < numFunnyWords; i++) {
                (funnyWord[i]).Render();
            }

            for (int i = 0; i < numQueries; i++) (query[i]).Render();

            for (int i = 0; i < numNumbers; i++) (number[i]).Render();

        }

        public void RenderScene(CGPoint offset)
        {
            CGRect bounds = Utilities.CGRectMake(0 + offset.x, 0 + offset.y, 320, 480);
            //glDisable (GL_BLEND);
            backScreen.DrawInRect(bounds);
            //glEnable (GL_BLEND);
            for (int i = 0; i < numButtons; i++) {
                (button[i]).Render();
            }

            for (int i = 0; i < numSwitches; i++) (frontEndSwitch[i]).Render();

            for (int i = 0; i < numFunnyWords; i++) (funnyWord[i]).Render();

            for (int i = 0; i < numQueries; i++) (query[i]).Render();

            for (int i = 0; i < numNumbers; i++) (number[i]).Render();

        }

    }
}
