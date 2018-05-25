using UnityEngine;
using System;
//using System.Drawing.Graphics;

namespace Default.Namespace
{
    public enum  FunnyWordState {
        e_Active,
        e_Inactive
    }
    public enum  FunnyWordShowStyle {
        kFunnyWordShow_Zoom,
        kFunnyWordShow_ZoomAndWobble,
        kFunnyWordShow_DropIn,
        kFunnyWordShow_SpinZoom,
        kFunnyWordShow_SlideInFromRight,
        kFunnyWordShow_Boing,
        kFunnyWordShow_Immediate
    }
    public class FunnyWord
    {
		public TextMeshWrapper myTextWrapper;		
		
		public CGPoint startPosition = new CGPoint();
		
        public bool initialised;
        public bool useTextureInstead;
        public bool dontUseTexture;
        public Texture2D_Ross textTexture;
        public float yTextureOffset;
        public string textString;
        public float fitToWidth;
        public float onguiFontSize;
        public float onguiWidth;
        public float onguiHeight;
        public CGPoint rotationOffset;
        public float orientationButtonDistanceFromCentre;
        public float orientationButtonStartAngle;
        public UITextAlignment alignment;
        public Zobject zobTexture;
        public Zobject[] letter = new Zobject[(int)Enum.kMaxLetters];
        public Zobject[] letterColour = new Zobject[(int)Enum.kMaxLetters];
        public FunnyWordState state;
        public int numLetters;
        public WordInfo wordInfo;
        public bool hasColourBack;
        public FunnyWordShowStyle showStyle;
        public float waitToShow;
        public ZFont font;
        public string theWord;
        public float timeToShowSpeed;
        public Constants.RossColour defaultColour;
        public ZAtlas lineAtlas;
        public ZAtlas colourAtlas;
        public float firstLetterXPos;
        public float lastLetterXPos;
        public float fitToWidthScale;
        public float rippleTimer;
        public bool renderOldStyle;
        public float spaceGap;
        public float letterGap;
        public float rotationWholeWord;
        public HangingButton orientationButton;
        public Zobject positionZob;
        public enum Enum {
            
		kMaxLetters = 80
        };
        public struct WordInfo{
            public CGPoint position;
            public float scale;
            public bool isCentrePos;
        };
        public struct LetterInfo{
            public CGPoint position;
            public Texture2D_Ross texture;
        };
        public FunnyWordShowStyle ShowStyle
        {
            get;
			set;
        }

        public float WaitToShow
        {
            get;
            set;
        }

        public float TimeToShowSpeed
        {
            get;
            set;
        }

        public ZAtlas LineAtlas
        {
            get;
            set;
        }

        public ZAtlas ColourAtlas
        {
            get;
            set;
        }

        public bool DoRenderOldStyle
        {
            get;
            set;
        }

        public float SpaceGap
        {
            get;
            set;
        }

        public float LetterGap
        {
            get;
            set;
        }

        public string TheWord
        {
            get;
            set;
        }

        public float RotationWholeWord
        {
            get;
            set;
        }

        public HangingButton OrientationButton
        {
            get
            {
                return orientationButton;
            }
            set
            {
                orientationButton = value;
                if (useTextureInstead) {
                    this.SetupOrientationButtonDistanceAndAngle(value);
                }

            }
        }

        public Zobject PositionZob
        {
            get;
            set;
        }

        public bool UseTextureInstead
        {
            get;
            set;
        }

        public bool DontUseTexture
        {
            get;
            set;
        }

        public UITextAlignment Alignment
        {
            get;
            set;
        }
		
		public void ClearOrientatinoThing()
		{
            for (int i = 0; i < numLetters; i++) 
			{
				if ((letterColour[i]).myAtlasBillboard != null)
				{
	                (letterColour[i]).myAtlasBillboard.myObject.transform.parent = null;// inThing.myButton.zobject.myAtlasBillboard.myObject.transform;
				}
			}
		}
		
		public void SetupOrientatinoThing(HangingButton inThing)
		{
            for (int i = 0; i < numLetters; i++) 
			{
				if (inThing.myButton != null)
				{
				if (inThing.myButton.zobject != null)
				{
					if (inThing.myButton.zobject.myAtlasBillboard != null)
					{
						if ((letterColour[i]).myAtlasBillboard != null)
								{
			                (letterColour[i]).myAtlasBillboard.myObject.transform.parent = inThing.myButton.zobject.myAtlasBillboard.myObject.transform;
								(letterColour[i]).myAtlasBillboard.myObject.transform.localEulerAngles = new Vector3(0.0f,0.0f,0.0f);
									
//									Vector3 localPosition = new Vector3(0,0,0);
									
								(letterColour[i]).myAtlasBillboard.localPosition.x = (letterColour[i]).startPosition.x - inThing.myButton.zobject.startPosition.x;	
								(letterColour[i]).myAtlasBillboard.localPosition.y = inThing.myButton.zobject.startPosition.y - (letterColour[i]).startPosition.y;	
//								(letterColour[i]).myAtlasBillboard.localPosition.x = 0.0f;	

									
							//		Vector3 starrtPos = new Vector3();
							//		starrtPos.x = 100.0f;
							//		starrtPos.y = 100.0f;
							//		starrtPos.z = -10.0f;
									
							//		
							//		(letterColour[i]).myAtlasBillboard.myObject.transform.position = starrtPos;
								}
							}
						}
					}
            	}
		}
		
		public void SetOrientationButton(HangingButton inThing) 
		{
			if (inThing != null)
			{
				this.SetupOrientatinoThing(inThing);
			}
			else
			{
				this.ClearOrientatinoThing();
			}
			
			orientationButton = inThing;
		
		}////@property(readwrite,assign) HangingButton* orientationButton;
public void SetPositionZob(Zobject inThing) {positionZob = inThing;}////@property(readwrite,assign) Zobject* positionZob;
public void SetTheWord(string inThing) {theWord = inThing;}////@property(readwrite,assign) char* theWord;
//public void SetShowStyle(FunnyWordShowStyle inThing) {showStyle = inThing;}///@property(readonly) FunnyWordShowStyle showStyle;
public void SetWaitToShow(float inThing) {waitToShow = inThing;}///@property(readwrite,assign) float waitToShow;
public void SetTimeToShowSpeed(float inThing) {timeToShowSpeed = inThing;}///@property(readwrite,assign) float timeToShowSpeed;
public void SetLineAtlas(ZAtlas inThing) {lineAtlas = inThing;}////@property(readwrite,assign) ZAtlas* lineAtlas;
public void SetColourAtlas(ZAtlas inThing) {colourAtlas = inThing;}////@property(readwrite,assign) ZAtlas* colourAtlas;
public void SetRenderOldStyle(bool inThing) {renderOldStyle = inThing;}///@property(readwrite,assign) bool renderOldStyle;
public void SetSpaceGap(float inThing) {spaceGap = inThing;}///@property(readwrite,assign) float spaceGap;
public void SetLetterGap(float inThing) {letterGap = inThing;}///@property(readwrite,assign) float letterGap;
public void SetRotationWholeWord(float inThing) {rotationWholeWord = inThing;}///@property(readwrite,assign) float rotationWholeWord;
public void SetUseTextureInstead(bool inThing) {useTextureInstead = inThing;}///@property(readwrite,assign) bool useTextureInstead;
public void SetDontUseTexture(bool inThing) {dontUseTexture = inThing;}///@property(readwrite,assign) bool dontUseTexture;
public void SetAlignment(UITextAlignment inThing) {alignment = inThing;}///@property(readwrite,assign) UITextAlignment alignment;

        public FunnyWord ()
		{
			//if (!base.init()) return null;

			for (int i = 0; i < (int)Enum.kMaxLetters; i++) {
				letter [i] = null;
				letterColour [i] = null;
			}
			
			myTextWrapper = null;
			
			textString = null;
			alignment = UITextAlignment.UITextAlignmentCenter;
            useTextureInstead = Globals.g_world.DoesCurrentLanguageUseNSString();
            textTexture = null;
            zobTexture = null;
            fitToWidth = -1.0f;
            orientationButton = null;
            positionZob = null;
            rotationWholeWord = 0.0f;
            rippleTimer = -1.0f;
            this.Reset();
            hasColourBack = false;
            showStyle = FunnyWordShowStyle.kFunnyWordShow_Immediate;
            waitToShow = 0;
            font = null;
            fitToWidthScale = 1;
            timeToShowSpeed = 0.03f;
            letterGap = 35;
            defaultColour = Constants.kColourWhite;
            colourAtlas = null;
            lineAtlas = null;
            renderOldStyle = false;
            spaceGap = 0.0f;
            initialised = false;
            //return this;
        }
        public void Dealloc()
        {
            if (textString != null) 
			{
                textString = null;
            }

            if (textTexture != null) 
			{
				textTexture.Dealloc();
				textTexture = null;
            }

            if (zobTexture != null) {
				zobTexture.Dealloc();
				zobTexture = null;
            }

			if (myTextWrapper != null) 
			{
				myTextWrapper.Dealloc();
				myTextWrapper = null;
            }

            for (int i = 0; i < (int)Enum.kMaxLetters; i++) 
			{
                if (letter[i] != null) {
                    letter[i].Dealloc();
                    letter[i] = null;
                }

                if (letterColour[i] != null) 
				{
                    letterColour[i].Dealloc();
                    letterColour[i] = null;
                }

            }

        }
		
		public void StopRender()
		{
            for (int i = 0; i < (int)Enum.kMaxLetters; i++) {
             //   (letter[i]).SetDefaultBounce(inSize);
				if (letterColour[i] != null)
	                (letterColour[i]).StopRender();
            }	
			
			if (myTextWrapper != null)
			{
				myTextWrapper.StopRender();
			}
		}

		
        public void SetPositionButton(FrontEndButton inButton)
        {
            positionZob = inButton.zobject;
        }

        public void SetFont(ZFont inFont)
        {
            font = inFont;
        }

        public void SetBounceSize(float inSize)
        {
            for (int i = 0; i < numLetters; i++) {
                (letter[i]).SetDefaultBounce(inSize);
                (letterColour[i]).SetDefaultBounce(inSize);
            }

        }

        public void FitToWidthNew(float inWidth)
        {
			if (true)//zobTexture == null)
			{
				//as should really be the case now -> unity
				
				if (myTextWrapper == null)
					return;
				
				if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
				{
					inWidth *= 2.0f;
				}
				
				GUIStyle boxStyle = new GUIStyle();
				boxStyle.fontSize = (int)(myTextWrapper.myFontSize * 3.2f);  //x32 in textwrapper thing...
				boxStyle.font = Globals.g_world.guiFont; 
				boxStyle.alignment = TextAnchor.MiddleCenter;
				boxStyle.fontStyle = FontStyle.Bold;
				
				Vector2 sizeOfLabel = boxStyle.CalcSize(new GUIContent(textString));			
				
				if (sizeOfLabel.x > inWidth)
				{
					float difference = inWidth / sizeOfLabel.x;
					float newFontSize = myTextWrapper.myFontSize * difference;
					myTextWrapper.SetFontSize(newFontSize);
				}
				
				return;
			}
			
			
            bool isShown = (zobTexture.state ==  ZobjectState.kZobjectShown);
            fitToWidth = inWidth;
            this.InitWithWordNewP1(wordInfo, textString);
            if (isShown) {
                zobTexture.Show();
            }

        }
		
		public void SetToStartPosition()
		{
			wordInfo.position = startPosition;
		}		
		
        public void PrintOut()
        {
	//		Debug.Log("Info for Funny Word - " + textString);
//			Debug.Log("at x: " + wordInfo.position.x + " y: " + wordInfo.position.y);
		}
		
        public void FitToWidth(float inWidth)
        {
            if (useTextureInstead) {
                this.FitToWidthNew(inWidth);
                return;
            }

            float xWidth = lastLetterXPos - firstLetterXPos;
            if (xWidth > inWidth) {
                float ratio = inWidth / xWidth;
                fitToWidthScale = ratio;
                this.SetupLetters();
            }
            else {
                fitToWidthScale = 1;
            }

        }

        public void RippleAgain()
        {
            const float kTimeTweenLetters = 0.06f;
            float wordShowTime = 1.2f;
            for (int i = 0; i < numLetters; i++) {
                (letter[i]).QueueActionAfterWaitToShowP1( ZobjectAction.nThrobLooping, wordShowTime + (kTimeTweenLetters * (float) i));
                (letterColour[i]).QueueActionAfterWaitToShowP1( ZobjectAction.nThrobLooping, wordShowTime + (kTimeTweenLetters * (float) i));
            }

        }

        public void RippleP1(float throbSize, float throbTime)
        {
            for (int i = 0; i < numLetters; i++) {
                (letter[i]).SetThrobSize(throbSize);
                (letterColour[i]).SetThrobSize(throbSize);
                (letter[i]).SetThrobTime(throbTime);
                (letterColour[i]).SetThrobTime(throbTime);
            }

            this.RippleAgain();
        }

        public void BounceOnce()
        {
            for (int i = 0; i < numLetters; i++) {
                (letter[i]).QueueActionP1( ZobjectAction.nBounceOnce, (0.03f * (float) i));
                (letterColour[i]).QueueActionP1( ZobjectAction.nBounceOnce, (0.03f * (float) i));
            }

        }

        public void Jiggle()
        {
            this.Jiggle(1);
        }

        public void Jiggle(float howMuch)
        {
            Zobject.FloatyInfo floatyInfo = new Zobject.FloatyInfo();
            floatyInfo.xSize = howMuch;
            floatyInfo.ySize = howMuch;
            floatyInfo.xOffset = 0;
            floatyInfo.yOffset = 0;
            for (int i = 0; i < numLetters; i++) {
                floatyInfo.xSpeed = 0.12f + ((float)(Utilities.GetRand( 15)) / 1000);
                floatyInfo.ySpeed = 0.14f + ((float)(Utilities.GetRand( 15)) / 1000);
                floatyInfo.xPosition = (float)(Utilities.GetRand( 314)) / 100;
                floatyInfo.yPosition = (float)(Utilities.GetRand( 314)) / 100;
                (letter[i]).SetFloatyInfo(floatyInfo);
                (letter[i]).SetIsFloaty(true);
                (letterColour[i]).SetFloatyInfo(floatyInfo);
                (letterColour[i]).SetIsFloaty(true);
            }

        }

        public void SetShowStyleNew(int inZobStyle)
        {
            if (useTextureInstead) {
				if (zobTexture != null)
	                zobTexture.SetShowStyle((ZobjectShowStyle) inZobStyle);

                return;
            }

            for (int i = 0; i < numLetters; i++) {
                (letter[i]).SetShowStyle((ZobjectShowStyle) inZobStyle);
                (letterColour[i]).SetShowStyle((ZobjectShowStyle) inZobStyle);
            }

        }

        public void SetShowStyle (int inStyle)
		{
			this.SetShowStyle((FunnyWordShowStyle) inStyle);
		}

        public void SetShowStyle(FunnyWordShowStyle inStyle)
        {
            if (useTextureInstead) {
                switch (inStyle) {
                case FunnyWordShowStyle.kFunnyWordShow_Immediate :
                    this.SetShowStyleNew((int) ZobjectShowStyle.kZobjectShow_Immediate);
                    break;
                default :
                    break;
                }

                return;
            }

            {
                showStyle = inStyle;
                for (int i = 0; i < numLetters; i++) {
                    switch (showStyle) {
                    case FunnyWordShowStyle.kFunnyWordShow_Boing :
                        (letter[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Boing);
                        (letterColour[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Boing);
                        CGPoint sPos = (letter[i]).screenPosition;
                        CGPoint tPos = Utilities.CGPointMake(sPos.x, sPos.y + 100);
                        (letter[i]).SetTargetScreenPosition(tPos);
                        (letterColour[i]).SetTargetScreenPosition(tPos);
                        break;
                    case FunnyWordShowStyle.kFunnyWordShow_Zoom :
                        (letter[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Zoom);
                        (letterColour[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Zoom);
                        break;
                    case FunnyWordShowStyle.kFunnyWordShow_ZoomAndWobble :
                        (letter[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_ZoomAndWobble);
                        (letterColour[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_ZoomAndWobble);
                        break;
                    case FunnyWordShowStyle.kFunnyWordShow_SpinZoom :
                        (letter[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SpinIn);
                        (letterColour[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SpinIn);
                        break;
                    case FunnyWordShowStyle.kFunnyWordShow_SlideInFromRight :
                        (letter[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
                        (letterColour[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SlideInRight);
                        break;
                    case FunnyWordShowStyle.kFunnyWordShow_Immediate :
                        (letter[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                        (letterColour[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_Immediate);
                        break;
                    case FunnyWordShowStyle.kFunnyWordShow_DropIn :
                        (letter[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_DropIn);
                        (letterColour[i]).SetShowStyle((int) ZobjectShowStyle.kZobjectShow_DropIn);
                        Zobject.ZgravityInfo gInfo = new Zobject.ZgravityInfo();
                        gInfo.floorLevel = wordInfo.position.y;
                        gInfo.bounce = 0.5f;
                        gInfo.yStartVelocity = -2;
                        gInfo.gravity = 0.4f;
                        gInfo.maxBounces = 5;
                        (letter[i]).InitialiseGravity(gInfo);
                        (letterColour[i]).InitialiseGravity(gInfo);
                        break;
                    }

                }

            }
        }

        public void SetSoundOnAppearing(int soundEffectId)
        {
            if (letter[0] != null) (letter[0]).SetSoundEffectIdAppear((int)soundEffectId);

        }

        int GetSubTexture(int charNumber)
        {
            if (charNumber == 63) {
                return 28;
            }
            else if (charNumber == 33) {
                return 26;
            }
            else if (charNumber == 39) {
                return 27;
            }
            else if (charNumber == 47) {
                return 32;
            }
            else if (charNumber == 35) {
                return 29;
            }
            else if (charNumber == 36) {
                return 30;
            }
            else if (charNumber == 37) {
                return 31;
            }
            else if (charNumber == 45) {
                return 33;
            }
            else {
                if (charNumber > 91) return (charNumber - 97);
                else {
                    return (charNumber - 65);
                }

            }

         //   return -1;
        }

        public void ChangeTextNew(string newText)
        {
            this.InitWithWordNewP1(wordInfo, newText);
            zobTexture.Show();
        }

        public void ChangeText(string newText)
        {
            if (useTextureInstead) {
               // string str = NSString.StringWithUTF8String(newText);
                this.InitWithWordNewP1(wordInfo, newText);
                return;
            }

            for (int i = 0; i < numLetters; i++) {
                (letter[i]).Hide();
            }

            WordInfo info;
            info = wordInfo;
            this.InitWithWordP1(info, newText);
        }

        public void SetColour(Constants.RossColour inCol)
        {
            defaultColour = inCol;
            for (int i = 0; i < numLetters; i++) {
                (letterColour[i]).SetColour(inCol);
            }
			
			if (myTextWrapper != null)
				myTextWrapper.SetColour(inCol);

        }

        public void SetupLetters()
        {
            float[] nextCharacterGap = new float[(int)Enum.kMaxLetters];
            numLetters = 0;
            float scale = wordInfo.scale * fitToWidthScale;
            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            float spaces = 0;
			int numLettersInWord = theWord.Length;
            float startX = wordInfo.position.x;
            int numSpaces = 0;
            float wordLengthPixels = 0.0f;
            nextCharacterGap[0] = 0.0f;
			if (numLettersInWord > 2)
			{
			//	//Debug.Log("theWord = " + theWord);
			}
            while (numLetters < numLettersInWord) {
                Globals.Assert(numLetters < ((int)Enum.kMaxLetters - 1));
						//	//Debug.Log("nl = " + numLetters);
				
//				Debug.Log ("Letter " + numLetters + " = " + theWord[numLetters].ToString());
				
				if (theWord[numLetters] == 32) {
                    numSpaces += 1;
                    nextCharacterGap[numLetters] = 20.0f * scale;
                    wordLengthPixels += nextCharacterGap[numLetters];
                }
                else {
					int backChar;
					if (numLetters == numLettersInWord-1)
					{
						backChar = -1;
					}
					else
					{
						backChar = theWord[numLetters + 1];
					}
				
//					Debug.Log ("numLetters " + numLetters.ToString());
//					Debug.Log ("nextCharacterGap[numLetters] " + nextCharacterGap[numLetters].ToString());
//					Debug.Log ("font " + font.ToString());
					
                    nextCharacterGap[numLetters] = scale * (float) font.GetDistanceBetweenLettersP1(backChar, theWord[numLetters]);
                    nextCharacterGap[numLetters] += (1.0f * scale);
                    wordLengthPixels += nextCharacterGap[numLetters];
                }

                numLetters++;
            };

            wordLengthPixels -= nextCharacterGap[numLetters - 1];
            if (wordInfo.isCentrePos) {
                startX -= (wordLengthPixels / 2.0f);
            }

            firstLetterXPos = startX;
            numLetters = 0;
            float letterPositionX = startX;
            while (numLetters < numLettersInWord) {
                Globals.Assert(numLetters < (int)Enum.kMaxLetters);
                int charNumber = theWord[numLetters];
                CGPoint posOffset = font.GetDrawOffsetForLetter(charNumber);
                posOffset.x *= scale;
                posOffset.y *= scale;
                zInfo.position = Utilities.CGPointMake(letterPositionX + posOffset.x, wordInfo.position.y + posOffset.y);
                letterPositionX += nextCharacterGap[numLetters];
                if (charNumber == 32) {
                    zInfo.texture = null;
                    spaces += (spaceGap * scale);
                }
                else {
                    if (charNumber > 91) zInfo.texture = font.GetLetter((charNumber - 97));
                    else {
                        zInfo.texture = font.GetLetter((charNumber - 65));
                    }

                }

                zInfo.startState = ZobjectState.kZobjectHidden;
                zInfo.isMapObject = false;
                if (letter[numLetters] == null) {
                    letter[numLetters] = new Zobject();
                }

                (letter[numLetters]).Initialise(zInfo);
                (letter[numLetters]).SetShowScale(scale);
                (letter[numLetters]).SetShowScale(scale);
                (letter[numLetters]).SetMapPosition(zInfo.position);
//				(letter[numLetters]).SetAtlas(lineAtlas);
//				(letter[numLetters]).SetSubTextureId(this.GetSubTexture(charNumber));
                if (charNumber != 32) {
                    zInfo.texture = font.GetLetterColour((charNumber - 97));
                }

                if (letterColour[numLetters] == null) {
                    letterColour[numLetters] = new Zobject();
                }

                (letterColour[numLetters]).Initialise(zInfo);
                (letterColour[numLetters]).SetShowScale(scale);
                (letterColour[numLetters]).SetColour(defaultColour);
				(letterColour[numLetters]).SetAtlas(colourAtlas);
				if ((charNumber != 32) && (charNumber != 10))
				{
					(letterColour[numLetters]).SetSubTextureId(this.GetSubTexture(charNumber));
				}
				else
				{
					(letterColour[numLetters]).SetSubTextureId(50);
				}
//				(letterColour[numLetters]).myAtlasBillboard.SetRenderQueue(10000);
				(letterColour[numLetters]).myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
				
				numLetters++;
            };

            lastLetterXPos = zInfo.position.x;
        }

        public void ChangePositionNew(CGPoint newPosition)
        {
            CGPoint offset = Utilities.CGPointMake(newPosition.x - wordInfo.position.x, newPosition.y - wordInfo.position.y);
            wordInfo.position = newPosition;
            if (useTextureInstead) {
                wordInfo.position.y += yTextureOffset;
                zobTexture.SetScreenPosition(wordInfo.position);
                zobTexture.SetMapPosition(wordInfo.position);
                return;
            }

            for (int i = 0; i < numLetters; i++) 
			{
                CGPoint oldPos = (letter[i]).mapPosition;
                oldPos.x += offset.x;
                oldPos.y += offset.y;
                (letter[i]).SetScreenPosition(oldPos);
                (letter[i]).SetMapPosition(oldPos);
                if (hasColourBack) {
                    (letterColour[i]).SetScreenPosition(oldPos);
                    (letterColour[i]).SetMapPosition(oldPos);
                }

            }

        }

        public void ChangePosition(CGPoint newPosition)
        {
            CGPoint offset = Utilities.CGPointMake(newPosition.x - wordInfo.position.x, newPosition.y - wordInfo.position.y);
            wordInfo.position = newPosition;
            if (useTextureInstead) {
                wordInfo.position.y += yTextureOffset;
                zobTexture.SetScreenPosition(wordInfo.position);
                zobTexture.SetMapPosition(wordInfo.position);
                return;
            }

            for (int i = 0; i < numLetters; i++) {
                CGPoint oldPos = (letter[i]).screenPosition;
                oldPos.x += offset.x;
                oldPos.y += offset.y;
                (letter[i]).SetScreenPosition(oldPos);
                (letter[i]).SetMapPosition(oldPos);
                if (hasColourBack) {
                    (letterColour[i]).SetScreenPosition(oldPos);
                    (letterColour[i]).SetMapPosition(oldPos);
                }

            }

        }
		
        public void InitWithWordNewP1(WordInfo info, string inWord)
        {			
            rotationOffset = Utilities.CGPointMake(0, 0);
            if (orientationButton != null) {
                if (initialised) {
                    CGPoint thing = Utilities.GetVectorFromAngleNew(rotationWholeWord + orientationButtonStartAngle);
                    rotationOffset.x = thing.x * orientationButtonDistanceFromCentre;
                    rotationOffset.y = thing.y * orientationButtonDistanceFromCentre;
                }
            }

            initialised = true;
            wordInfo = info;
            if (textString != inWord) {
                if (textString != null) {
                    textString = null;
                }

				textString = inWord;//.Copy();
            }

            if (textTexture != null) {
            }

            if (zobTexture == null) {
                zobTexture = new Zobject();
            }
			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				info.scale *= 2.0f;
			}
			
            CGSize size = Utilities.CGSizeMake(400.0f * info.scale, 64.0f * info.scale);
            float textSize = 64.0f * info.scale;
            float useWidth;
            if (fitToWidth > 0.0f) {
                useWidth = fitToWidth;
            }
            else {
                useWidth = size.Width;
            }

            if (Globals.useRetina) {
            //    size.Width *= 2.0f;
            //    size.Height *= 2.0f;
            //    textSize *= 2.0f;
            //    useWidth *= 2.0f;
            }

			float actualFontSize = 32.0f;
                //UIFont pFont = UIFont.FontWithNameSize("Arial", textSize);
			CGSize currentWidth = Utilities.CGSizeMake(100,100);//textString.SizeWithFontMinFontSizeActualFontSizeForWidthLineBreakMode(pFont, 12.0f, actualFontSize, useWidth,
                  //UILineBreakModeClip);
				
			int ross = 0;
			
                if (actualFontSize < textSize) 
			 	{
                    textSize = actualFontSize;
                }

                if (currentWidth.Width < size.Width) {
                    size.Width = currentWidth.Width;
                }

            float sizeThing = 32.0f;
            for (int i = 0; i < 6; i++) {
                if (size.Width < sizeThing) {
                    size.Width = sizeThing;
                    break;
                }

                sizeThing *= 2.0f;
            }

            sizeThing = 32.0f;
            for (int i = 0; i < 6; i++) {
                if (size.Height < sizeThing) {
                    size.Height = sizeThing;
                    break;
                }

                sizeThing *= 2.0f;
            }

			onguiWidth = size.Width;
			onguiHeight = size.Height;
			onguiFontSize = 32.0f;

			textTexture = null;//new Texture2D_Ross(inWord, size, alignment, "Arial", textSize);
            float diff = size.Height - textSize;
            yTextureOffset = diff * 0.5f;
            if ((Globals.useRetina) || (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High))
			{
                yTextureOffset *= 0.5f;
            }

            info.position.y += yTextureOffset;
            if (alignment == UITextAlignment.UITextAlignmentLeft) {
                info.position.x += (size.Width * 0.25f);
            }
            else if (alignment == UITextAlignment.UITextAlignmentRight) {
                info.position.x -= (size.Width * 0.5f);
            }
			
			
			if (myTextWrapper == null)
			{
				myTextWrapper = new TextMeshWrapper("forWord_" + inWord);
			}
			
			textSize = 16.0f * info.scale;
			
			myTextWrapper.SetWords(textString);
			myTextWrapper.SetFontSize(textSize);
			myTextWrapper.SetColour(defaultColour);
			
			return;
			
            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            zInfo.startState = ZobjectState.kZobjectHidden;
            zInfo.position = info.position;
            zInfo.isMapObject = false;
            zInfo.texture = textTexture;
            zobTexture.Initialise(zInfo);
            zobTexture.SetMapPosition(zInfo.position);
            if (orientationButton != null) {
                this.SetupOrientationButtonDistanceAndAngle(orientationButton);
            }

            if (Globals.useRetina) 
			{
                if (Globals.deviceIPhone4) {
                    zobTexture.SetShowScale(0.5f);
                }

            }

        }

        public void InitWithStringIdP1(WordInfo info, int inStringId)
        {
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                this.InitWithWordNewP1(info, Globals.g_world.GetNSString((StringId)inStringId));
            }
            else {
                string inWord = Globals.g_world.GetString((StringId)inStringId);
                this.InitWithWordP1(info, inWord);
            }

        }

        public void InitWithWordOrStringP1P2(WordInfo info, string inWord, string inString)
        {
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                this.InitWithWordNewP1(info, inString);
                return;
            }

            this.InitWithWordP1(info, inWord);
        }

        public void InitWithWordP1(WordInfo info, string inWord)
        {
			//Debug.Log ("InitWithWordP1( " + inWord);
			
			this.StopRender();
			
            if (useTextureInstead) {
                wordInfo.scale *= 0.8f;
                info.scale *= 0.8f;
				string str = inWord;// NSString.StringWithUTF8String(inWord);
                this.InitWithWordNewP1(info, str);
                return;
            }

            initialised = true;
            wordInfo = info;
            hasColourBack = true;
            fitToWidthScale = 1;
            theWord = inWord;
            this.SetupLetters();
        }

        public void AddLetter(LetterInfo info)
        {
            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            zInfo.position = info.position;
            zInfo.texture = info.texture;
            zInfo.startState = ZobjectState.kZobjectHidden;
            zInfo.isMapObject = false;
            if (letter[numLetters] == null) {
                letter[numLetters] = new Zobject();
            }

            (letter[numLetters]).Initialise(zInfo);
            Zobject.FloatyInfo floatyInfo = new Zobject.FloatyInfo();
            floatyInfo.xSpeed = 0.12f + ((float)(Utilities.GetRand( 15)) / 1000);
            floatyInfo.ySpeed = 0.14f + ((float)(Utilities.GetRand( 15)) / 1000);
            floatyInfo.xPosition = (float)(Utilities.GetRand( 314)) / 100;
            floatyInfo.yPosition = (float)(Utilities.GetRand( 314)) / 100;
            floatyInfo.xSize = 1;
            floatyInfo.ySize = 1;
            floatyInfo.xOffset = 0;
            floatyInfo.yOffset = 0;
            (letter[numLetters]).SetFloatyInfo(floatyInfo);
            (letter[numLetters]).SetIsFloaty(true);
            numLetters++;
        }

        public void Reset()
        {
            fitToWidthScale = 1;
            numLetters = 0;
            wordInfo.scale = 1;
        }

        public void Disappear()
        {
            if (zobTexture != null) {
                zobTexture.Disappear();
            }

            for (int i = 0; i < numLetters; i++) {
                (letter[i]).Disappear();
            }

            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) (letterColour[i]).Disappear();

            }
			
			if (myTextWrapper != null)
				myTextWrapper.StopRender();
			
        }

        public Zobject GetLetter(int i)
        {
            Globals.Assert(i < numLetters);
            return letter[i];
        }

        public void ShowIfHidden()
        {
            if ((letter[0]).state ==  ZobjectState.kZobjectHidden) {
                this.Show();
            }

        }

        public void Show(float inWaitToShow)
        {
			if (myTextWrapper != null)
			{
				myTextWrapper.Show();
			}
				
            waitToShow = inWaitToShow;
            this.Show();
        }

        public void ShowNew()
        {
			if (myTextWrapper != null)
				myTextWrapper.Show();
			
			if (zobTexture != null)
            zobTexture.Show();
        }

        public void Show()
        {			
            if (useTextureInstead) {

				
				this.ShowNew();
                return;
            }

            const float kLetterLag = 0.3f;
            for (int i = 0; i < numLetters; i++) {
                (letter[i]).SetShowLagSpeed(kLetterLag);
                (letter[i]).Disappear();
                (letter[i]).SetWaitToShow((waitToShow + (timeToShowSpeed * ((float) i))));
                (letter[i]).Show();
            }

            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) {
                    (letterColour[i]).SetShowLagSpeed(kLetterLag);
                    (letterColour[i]).Disappear();
                    (letterColour[i]).SetWaitToShow((waitToShow + (timeToShowSpeed * ((float) i))));
                    (letterColour[i]).Show();
                }

            }
			
			if (orientationButton != null)
			{
				this.SetupOrientatinoThing(orientationButton);
				
			//	 Vector3 oldEuler = orientationButton.myButton.zobject.myAtlasBillboard.myObject.transform.localEulerAngles;
				//
			//	 orientationButton.myButton.zobject.myAtlasBillboard.myObject.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, 0.0f );	
			//
				for (int i = 0; i < numLetters; i++) {
                 //   (letterColour[i]).RenderToDrawArrays_Unity();
                }
			}			

        }

        public void UpdateNewNew()
        {
			if (zobTexture != null)
	            zobTexture.Update();

            for (int i = 0; i < numLetters; i++) (letter[i]).Update();

            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) (letterColour[i]).Update();

            }
		
		}
		
		
        public void UpdateNew()
        {
			if (zobTexture != null)
	            zobTexture.Update();
        }

        public void Update()
        {
            if (useTextureInstead) {
                this.UpdateNew();
                return;
            }

            for (int i = 0; i < numLetters; i++) (letter[i]).Update();

            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) (letterColour[i]).Update();

            }

        }

        public void RenderOldStyle()
        {
            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) (letterColour[i]).Render();

            }

            for (int i = 0; i < numLetters; i++) {
                (letter[i]).Render();
            }

        }

        public void UpdateWordRotation()
        {
            if (orientationButton != null) {
                rotationWholeWord = orientationButton.currentRotation;
            }

            if (rotationWholeWord != 0.0f) {
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glLoadIdentity();
                //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
                //glPushMatrix();
 /*               float roatation = rotationWholeWord;
                float yTin = Globals.g_world.screenHeight;
                float x = wordInfo.position.x;
                float y = wordInfo.position.y;
                float kPadXTimes = 2.0f;
                float kPadYTimes = 2.0f;
                float kPadXPlus = 64.0f;
                if (Globals.deviceIPad) {
                    x *= kPadXTimes;
                    x += kPadXPlus;
                    y *= kPadYTimes;
                }

                CGPoint tempWordPos = Utilities.CGPointMake(x, y);
                CGPoint vectorToBasePos = Utilities.CGPointMake(tempWordPos.x, yTin - tempWordPos.y);
                float baseAngle = Constants.PI_ - Utilities.GetAngleFromXYP1(vectorToBasePos.x, vectorToBasePos.y);
                CGPoint positionWas = tempWordPos;
                float distance = Utilities.GetDistanceP1(Utilities.CGPointMake(0, yTin), positionWas);
                CGPoint newPosVec = Utilities.GetVectorFromAngle(baseAngle + roatation);
                newPosVec.x *= distance;
                newPosVec.y *= distance;
                CGPoint positionNow = newPosVec;
                positionNow.y = -positionNow.y;
                CGPoint diff;
                diff.x = positionNow.x - positionWas.x;
                diff.y = positionNow.y - (yTin - positionWas.y);
                //glRotatef((roatation) * (360.0 / (Constants.TWO_PI)), 0, 0, 1);
                //glTranslatef(diff.x * Constants.kScreenMultiplierForShorts, diff.y * Constants.kScreenMultiplierForShorts, 0.0f);
                CGPoint orientationButtonPos;
                if (orientationButton != null) {
                    orientationButtonPos = Utilities.CGPointMake((orientationButton.myButton).position.x, (orientationButton.myButton).position.y);
                }
                else {
                    orientationButtonPos = wordInfo.position;
                }

                if (Globals.deviceIPad) {
                    orientationButtonPos.x *= kPadXTimes;
                    orientationButtonPos.x += kPadXPlus;
                    orientationButtonPos.y *= kPadYTimes;
                }

                CGPoint startOffset = Utilities.CGPointMake(tempWordPos.x - orientationButtonPos.x, tempWordPos.y - orientationButtonPos.y);
                if ((startOffset.x != 0.0f) || (startOffset.y != 0.0f)) {
                    float startAngle = Utilities.GetAngleFromXYNewP1(startOffset.x, startOffset.y);
                    float offsetLength = Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), startOffset);
                    CGPoint normalAngle = Utilities.GetVectorFromAngleNew(startAngle - roatation);
                    normalAngle.x *= offsetLength;
                    normalAngle.y *= offsetLength;
                    CGPoint offset;
                    offset.x = startOffset.x - normalAngle.x;
                    offset.y = startOffset.y - normalAngle.y;
                    //glTranslatef(-offset.x * 20.0f, offset.y * 20.0f, 0.0f);
                }
                */

            }

        }

        public void UpdateWordPositionNew()
        {
            if (positionZob != null) {
                CGPoint offset = positionZob.GetOffsetForWord();
                CGPoint oldPos = zobTexture.mapPosition;
                oldPos.x += offset.x;
                oldPos.y += offset.y;
                zobTexture.SetScreenPosition(oldPos);
            }

        }

        public void UpdateWordPosition()
        {
            if (positionZob != null) {
                CGPoint offset = positionZob.GetOffsetForWord();
                for (int i = 0; i < numLetters; i++) {
                    CGPoint oldPos = (letter[i]).mapPosition;
                    oldPos.x += offset.x;
                    oldPos.y += offset.y;
                    (letter[i]).SetScreenPosition(oldPos);
                    (letterColour[i]).SetScreenPosition(oldPos);
                }

            }

        }

        public void SetupOrientationButtonDistanceAndAngle(HangingButton inOrientationButton)
        {
            CGPoint buttPos = ((inOrientationButton.myButton).zobject).startPosition;
            CGPoint myPos = zobTexture.mapPosition;
            orientationButtonDistanceFromCentre = Utilities.GetDistanceP1(buttPos, myPos);
            orientationButtonStartAngle = Utilities.GetAngleFromXYNewP1(-(buttPos.x-myPos.x), buttPos.y - myPos.y);
        }

        public void OnGUI()
		{
			return;
			
			
			if (!useTextureInstead) {
				return;
			}
			
//			this.UpdateWordPositionNew();

			CGPoint pos = zobTexture.mapPosition;			
			
            if (positionZob != null) {
                CGPoint offset = positionZob.GetOffsetForWord();
                //CGPoint oldPos = zobTexture.mapPosition;
                pos.x += offset.x;
                pos.y += offset.y;
                //zobTexture.SetScreenPosition(oldPos);
            }
			
			
			
			
			float heightScale = (Screen.height / 480.0f);
			
			pos.x *= (Screen.width / 320.0f);
			pos.y *= heightScale;
			
			
			float boxWidth = onguiWidth;
			float boxHeight = onguiHeight;

			GUIStyle boxStyle = new GUIStyle();// GUI.skin.box );
//			GUIStyle boxStyle = new GUIStyle(GUI.skin.box );

//			GUI.color = new Color(defaultColour.cRed,defaultColour.cGreen, defaultColour.cBlue,1.0f);
//			GUI.contentColor = new Color(defaultColour.cRed,defaultColour.cGreen, defaultColour.cBlue,1.0f);
			boxStyle.fontSize = (int)(onguiFontSize * heightScale * wordInfo.scale * 2.0f);
			boxStyle.font = Globals.g_world.guiFont; 
//boxStyle.fontSize = (int) 20;
			Constants.RossColour brighterColour = defaultColour;

			float brightThing = 1.0f;
			brighterColour.cBlue *= brightThing;
			brighterColour.cGreen *= brightThing;
			brighterColour.cRed *= brightThing;

			boxStyle.normal.textColor = new Color(brighterColour.cRed,brighterColour.cGreen, brighterColour.cBlue,0.85f);
			boxStyle.alignment = TextAnchor.MiddleCenter;
			boxStyle.fontStyle = FontStyle.Bold;
			
			pos.y -= (5.0f * heightScale);//((float)(boxStyle.fontSize - 32) * 0.5f);
			
			GUI.Box(new Rect(pos.x - (boxWidth / 2.0f),pos.y - (boxHeight / 2.0f),boxWidth,boxHeight),textString,boxStyle);
		}

        public void RenderNew()
        {
			if (!useTextureInstead) {
				return;
			}			

			CGPoint oldPos = wordInfo.position;
			
            if (positionZob != null) {
                CGPoint offset = positionZob.GetOffsetForWord();
                //oldPos = zobTexture.mapPosition;
                oldPos.x += offset.x;
                oldPos.y += offset.y;
                //zobTexture.SetScreenPosition(oldPos);
				
				if ((positionZob.state == ZobjectState.kZobjectHidden) || (positionZob.state == ZobjectState.kZobjectWaitingToShow))
				{
					return;
				}
            }
			
			
			if (myTextWrapper != null)
			{
		 if (orientationButton != null) {
                rotationWholeWord = orientationButton.currentRotation;
                if (rotationWholeWord != 0.0f) {
                 //   CGPoint thing = Utilities.GetVectorFromAngleNew(rotationWholeWord + orientationButtonStartAngle);
                 //   rotationOffset.x = thing.x * orientationButtonDistanceFromCentre;
                 //   rotationOffset.y = thing.y * orientationButtonDistanceFromCentre;
                }

             //   CGPoint oldPos;
             //   oldPos = ((orientationButton.myButton).zobject).screenPosition;
             //   oldPos.x += rotationOffset.x;
             //   oldPos.y -= rotationOffset.y;
             //   zobTexture.SetScreenPosition(oldPos);
            }				
				
				myTextWrapper.SetRotation(rotationWholeWord);
				myTextWrapper.RenderAtPosition(oldPos);			
			}
			
			return;

            if (positionZob != null) {
                if ((positionZob.state ==  ZobjectState.kZobjectWaitingToShow) || (positionZob.state ==  ZobjectState.kZobjectHidden)) {
                    return;
                }

            }

            //glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
            this.UpdateWordPositionNew();
            if (orientationButton != null) {
                rotationWholeWord = orientationButton.currentRotation;
                if (rotationWholeWord != 0.0f) {
                    CGPoint thing = Utilities.GetVectorFromAngleNew(rotationWholeWord + orientationButtonStartAngle);
                   // rotationOffset.x = thing.x * orientationButtonDistanceFromCentre;
                   // rotationOffset.y = thing.y * orientationButtonDistanceFromCentre;
                }

             //   CGPoint oldPos;
             //   oldPos = ((orientationButton.myButton).zobject).screenPosition;
             //   oldPos.x += rotationOffset.x;
             //   oldPos.y -= rotationOffset.y;
             //   zobTexture.SetScreenPosition(oldPos);
            }

            //glColor4f(defaultColour.cRed, defaultColour.cGreen, defaultColour.cBlue, 1.0f);
            zobTexture.SetRotation(rotationWholeWord);
            zobTexture.RenderSimple();
            //glBlendFunc(GL_ONE, GL_ONE_MINUS_SRC_ALPHA);
            //glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
        }

        public void Render()
        {
            if (useTextureInstead) {
                this.RenderNew();
                return;
            }

            if (positionZob != null) {
                if ((positionZob.state ==  ZobjectState.kZobjectWaitingToShow) || (positionZob.state ==  ZobjectState.kZobjectHidden)) {
                    return;
                }

            }

            if (renderOldStyle) {
                this.RenderOldStyle();
                return;
            }

            if (numLetters == 0) {
                return;
            }

            if (positionZob == null)
			{
				if ((wordInfo.position.x <= -160.0f) || (wordInfo.position.x >= 480.0f))
				{
					//to try and catch the cup name words that go off screen
					
					this.StopRender();
					return;
				}
				
//                if (((letter[0]).screenPosition.x > 420.0f) || ((letter[numLetters - 1]).screenPosition.x < -100.0f)) {
//                    return;
//                }

            }

            this.UpdateWordRotation();
            this.UpdateWordPosition();
            (DrawManager.Instance()).Begin(lineAtlas);
            for (int i = 0; i < numLetters; i++) {
//                if (Utilities.IsOnScreenP1((letter[i]).screenPosition, 50.0f)) {
  //                  (letter[i]).RenderToDrawArrays();
    //            }

            }

            (DrawManager.Instance()).Flush();
            if (hasColourBack) 
			{
                ////glEnableClientState (GL_COLOR_ARRAY);
                (DrawManager.Instance()).Begin(colourAtlas);
                for (int i = 0; i < numLetters; i++) {
                    if (Utilities.IsOnScreenP1((letter[i]).screenPosition, 50.0f)) 
					{
						//if (orientationButton == null) // || ((orientationButton.myButton.zobject.rotation >= -0.01f) && (orientationButton.myButton.zobject.rotation <= 0.01f)))
	                      
						//if (!(letterColour[i]).myAtlasBillboard.myObject.renderer.enabled)
						{
						(letterColour[i]).RenderToDrawArrays();
						}
                    }
					else
					{
                        (letterColour[i]).StopRender();
					}
                }

                (DrawManager.Instance()).Flush();
                ////glDisableClientState (GL_COLOR_ARRAY);
            }

            if (rotationWholeWord != 0.0f) {
                //glPopMatrix();
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glLoadIdentity();
                //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
            }

        }

        public void SetHideStyle(int zobHide)
        {
            if (useTextureInstead) {
                zobTexture.SetHideStyle((ZobjectHideStyle) zobHide);
                return;
            }

            for (int i = 0; i < numLetters; i++) (letter[i]).SetHideStyle((ZobjectHideStyle) zobHide);

            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) (letterColour[i]).SetHideStyle((ZobjectHideStyle) zobHide);

            }

        }

        public void Hide()
        {
            if (useTextureInstead) {
				if (zobTexture != null)
					zobTexture.Hide();
                return;
            }

            for (int i = 0; i < numLetters; i++) (letter[i]).Hide();

            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) (letterColour[i]).Hide();

            }

        }

        public void HideRipple()
        {
            const float kHideTweenLetters = 0.03f;
            for (int i = 0; i < numLetters; i++) {
                float waitHow = ((float) i) * kHideTweenLetters;
                (letter[i]).SetWaitToHide(waitHow);
                (letter[i]).Hide();
            }

            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) {
                    float waitHow = ((float) i) * kHideTweenLetters;
                    (letterColour[i]).SetWaitToHide(waitHow);
                    (letterColour[i]).Hide();
                }

            }

        }

        public void SetScale(float newScale)
        {
            wordInfo.scale = newScale;
            for (int i = 0; i < numLetters; i++) (letter[i]).SetShowScale(newScale);

            if (hasColourBack) {
                for (int i = 0; i < numLetters; i++) (letterColour[i]).SetShowScale(newScale);

            }
			
			if (myTextWrapper != null)
			{
				float fontSize = 16.0f * newScale;
				
				myTextWrapper.SetFontSize(fontSize);
			}
			
        }

    }
}
