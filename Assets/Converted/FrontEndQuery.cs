using UnityEngine;
using System;

namespace Default.Namespace
{
    public enum  QueryButton {
        nPressActionDone = -2,
        nNothingPressedYet = -1,
        nNo,
        nYes,
        nMaybe,
        kNumButtonsOnQuery
    }
    public enum  QueryState {
        e_Inactive = 0,
        e_Active
    }
    
	public enum  QueryButtonStyle {
        kQButtonsEdges = 0,
        kQButtonsCentral
    }

	public class FrontEndQuery
    {
		public FunnyWord unityText;
		
		float waitToHide;
		QueryButtonStyle queryButtonStyle;
		public int numButtons;
        public bool newStyleQuery;
        public bool newStyleWithAtlas;
        public string queryText;
        public ZAtlas atlas;
        public Texture2D_Ross textTexture;
        public bool usingStrings;
        public QueryButton chosenButton;
        public FrontEndButton[] button = new FrontEndButton[(int)QueryButton.kNumButtonsOnQuery];
        public CGPoint position;
        public CGPoint boxDimensions;
        public Zobject dimZob;
        public Zobject backdrop;
        public Zobject text;
        public CGPoint scale;
        public float wordScale;
        public float wordGap;
        public float wordOffset;
        public FrontEnd menu;
        public QueryState state;
        public bool useActualText;
        public string theInfo1;
        public string theInfo2;
        public string theInfo3;
        public string theInfo4;
        public string theInfo5;
        public string theInfo6;
        public string theInfo7;
        public FunnyWord[] funnyWord = new FunnyWord[(int)Enum.kMaxFunnyWordsInQuery];
		public bool useNSString;
		public int numCrappyStrings;
		
		//really should have done this by adding a FunnyWord to FrontEndbutton... then a simple command like AddText("blah")... could always add text to a button...
        public FunnyWord[] buttonText = new FunnyWord[(int)Enum.kMaxCentralButtonsInQuery];
        public bool noDimZob;
        public Constants.RossColour myColour;
        public enum Enum : int {
            kMaxFunnyWordsInQuery = 7,
			kMaxCentralButtonsInQuery = 3
        };
        public class QueryInfoNew
		{
            public bool newStyleWithAtlas;
            public string inText;
            public string[] buttonString = new string[3];
            public CGPoint position;
            public CGSize boxDimensions;
            public float inTextScale;
            public ZAtlas inAtlas;
            public Texture2D_Ross backdropTexture;
            public Texture2D_Ross yesButton;
            public Texture2D_Ross noButton;
            public Texture2D_Ross dimOverlayTexture;
            public int buttonBackdropId;
            public int backdropId;
            public int dimId;
            public bool useActualText;
            public string queryText;
			public int numQueryStringsForCrappyWords;
            public string[] queryTextForCrappyWords = new string[5];
			public int numButtons;
			public float scale;
			
			public bool useNSStringForAnyLanguage;
        };

        public struct QueryInfo{
            public string inText;
            public CGPoint position;
            public CGPoint boxDimensions;
            public Texture2D_Ross textTexture;
            public Texture2D_Ross backdropTexture;
            public Texture2D_Ross yesButton;
            public Texture2D_Ross noButton;
            public Texture2D_Ross dimTexture;
            public bool useActualText;
            public string theInfo1;
            public string theInfo2;
            public string theInfo3;
            public string theInfo4;
            public string theInfo5;
            public string theInfo6;
            public string theInfo7;
        };
        public QueryButton ChosenButton
        {
            get;
            set;
        }

        public QueryState State
        {
            get;
            set;
        }

        public bool NoDimZob
        {
            get;
            set;
        }

        public float WordScale
        {
            get;
            set;
        }

        public float WordGap
        {
            get;
            set;
        }

        public float WordOffset
        {
            get;
            set;
        }

        public Zobject Backdrop
        {
            get;
            set;
        }

        public bool UsingStrings
        {
            get;
            set;
        }

		public void SetChosenButton(QueryButton inThing) {chosenButton = inThing;}///@property(readwrite,assign) QueryButton chosenButton;
public void SetState(QueryState inThing) {state = inThing;}///@property(readwrite,assign) QueryState state;
public void SetNoDimZob(bool inThing) {noDimZob = inThing;}///@property(readwrite,assign) bool noDimZob;
public void SetWordScale(float inThing) {wordScale = inThing;}///@property(readwrite,assign) float wordScale;
public void SetWordGap(float inThing) {wordGap = inThing;}///@property(readwrite,assign) float wordGap;
public void SetWordOffset(float inThing) {wordOffset = inThing;}///@property(readwrite,assign) float wordOffset;
public void SetBackdrop(Zobject inThing) {backdrop = inThing;}////@property(readwrite,assign) Zobject* backdrop;
public void SetUsingStrings(bool inThing) {usingStrings = inThing;}///@property(readwrite,assign) bool usingStrings;
//public void SetActionDone(bool inThing) {actionDone = inThing;}///@property(readwrite,assign) bool actionDone;

        public FrontEndQuery()
        {
            //if (!base.init()) return null;
			
			unityText = null;			
            textTexture = null;
			
            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) 
				button[i] = new FrontEndButton(i);

            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) 
				funnyWord[i] = null;

			for (int i = 0; i < (int)Enum.kMaxCentralButtonsInQuery; i++) 
				buttonText[i] = null;

            dimZob = new Zobject();
            backdrop = new Zobject();
            text = new Zobject();
            chosenButton = (QueryButton)(-1);
            noDimZob = false;
            wordScale = 0.42f;
            wordGap = 32.0f;
            wordOffset = 0.0f;
            myColour = Constants.kColourLightGreen;
            usingStrings = false;
            //return this;
        }
        public void Dealloc()
        {
            if (textTexture != null) 
			{
				textTexture.Dealloc();
				textTexture = null;
            }

			if (unityText != null) 
			{
				unityText.Dealloc();
				unityText = null;
            }
			if (dimZob != null) 
			{
				dimZob.Dealloc();
				dimZob = null;
            }
			if (backdrop != null) 
			{
				backdrop.Dealloc();
				backdrop = null;
            }
			if (text != null) 
			{
				text.Dealloc();
				text = null;
            }

            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) 
			{
                if (button[i] != null) {
                    button[i].Dealloc();
                    button[i] = null;
                }

            }

            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) {
                if (funnyWord[i] != null) {
                    funnyWord[i].Dealloc();
                    funnyWord[i] = null;
                }

            }

            for (int i = 0; i < (int)Enum.kMaxCentralButtonsInQuery; i++) {
                if (buttonText[i] != null) {
                    buttonText[i].Dealloc();
                    buttonText[i] = null;
                }

            }
			
			
        }
		
		public void StopRender()
		{
			if (dimZob != null)
				dimZob.StopRender();
	
			if (backdrop != null)
				backdrop.StopRender();
	
			for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) 
			{
                if (button[i] != null) {
					(button[i]).StopRender();
				}
			}
            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) 
			{
                if (funnyWord[i] != null) {
                    funnyWord[i].StopRender();
                }
            }	
            for (int i = 0; i < (int)Enum.kMaxCentralButtonsInQuery; i++) 
			{
                if (buttonText[i] != null) {
                    buttonText[i].StopRender();
                }
            }	
			
			if (unityText != null)
				unityText.StopRender();
		}

        public void SetupCentralButtons(QueryInfoNew qInfo)
        {			
            const float kButtonInX = 30;
            const float kButtonUpY = 20;
			CGPoint querySize = Utilities.CGPointMake(124.0f, 85.0f);

			float buttonPosY = position.y + ((querySize.y + kButtonUpY) * (scale.y));
			
            FrontEnd.ButtonInfo info = new FrontEnd.ButtonInfo();
            info.textureLabel = null;
            info.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
			
			HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
			hInfo.showWobbleMultiplier = 1.2f;
			hInfo.type = HangingButtonType.kHB_Rope;
			hInfo.subTextureId = 0;//(int)World.Enum6.kSSH_Rope;
            hInfo.offset = Utilities.CGPointMake(98.0f * qInfo.scale, -15.0f * qInfo.scale);
			
			buttonPosY += (65.0f * ((float)(qInfo.numButtons - 1)) * qInfo.scale);
			
			FunnyWord.WordInfo wInfo = new FunnyWord.WordInfo();
			wInfo.isCentrePos = true;
			wInfo.scale = qInfo.inTextScale * 0.32f;// * 0.25f;
			
			
            for (int i = 0; i < (int)Enum.kMaxCentralButtonsInQuery; i++) 
			{
				if (buttonText[i] != null)
				{
					buttonText[i].Disappear();
				}
				if (button[i] != null)
				{
					button[i].Disappear();
				}				
			}			
			
			for(int buttonIndex = 0; buttonIndex < qInfo.numButtons; buttonIndex++)
			{
				if (buttonText[buttonIndex] == null)
				{
					buttonText[buttonIndex] = new FunnyWord();
				}
				
				info.position = Utilities.CGPointMake(position.x, buttonPosY);
	            info.texture = null;
	            (button[buttonIndex]).Initialise(info);
	            ((button[buttonIndex]).zobject).SetShowScale(scale.x);
	            ((button[buttonIndex]).zobject).SetAtlasAndSubtextureP1(atlas, 2);//qInfo.buttonBackdropId);
				((button[buttonIndex]).zobject).myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
				(button[buttonIndex]).SetWidth(220.0f);				
				(button[buttonIndex]).SetHeight(60.0f);				
				(button[buttonIndex]).SetClickStyle(ButtonClickStyle.kButtonClick_Throb);

				(button[buttonIndex]).AddHangingButton (hInfo);				
				(button[buttonIndex]).hangingButton.SetWobbleDeclineMultiplier(0.5f);	
				
				((button[buttonIndex]).zobject).SetShowStyle(ZobjectShowStyle.kZobjectShow_SlideInLeft);
				((button[buttonIndex]).zobject).SetHideStyle(ZobjectHideStyle.kZobjectHide_SlideToRight);
				((button[buttonIndex]).zobject).SetHideAcc(0.02f);
			
				wInfo.position = info.position;
				wInfo.position.y += 10.0f;
				
	            if (useNSString) 
				{
					buttonText[buttonIndex].InitWithWordNewP1(wInfo,qInfo.buttonString[buttonIndex]);
	            }
				else
				{
					wInfo.scale = qInfo.inTextScale * 0.018f;// * 0.1f;// * 0.25f;
					buttonText[buttonIndex].SetFont(Globals.g_world.font);
					buttonText[buttonIndex].SetColourAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_FontColours));
					buttonText[buttonIndex].InitWithWordP1(wInfo,qInfo.buttonString[buttonIndex]);
				}
				
				buttonText[buttonIndex].SetPositionZob(((button[buttonIndex]).zobject));
				buttonText[buttonIndex].SetColour(myColour);
				
				if (useNSString) 
				{
					buttonText[buttonIndex].myTextWrapper.SetBoundThing();
					buttonText[buttonIndex].SetUseTextureInstead(true);
					buttonText[buttonIndex].myTextWrapper.SetFontSize(qInfo.inTextScale * 0.32f);
				}
				buttonText[buttonIndex].SetOrientationButton((button[buttonIndex]).hangingButton);
				
				buttonPosY -= (65.0f * qInfo.scale);
			}
        }
		
		
        public void SetupButtonsNew(QueryInfoNew qInfo)
        {
            const float kButtonInX = 30;
            const float kButtonUpY = 30;
            CGPoint querySize = Utilities.CGPointMake(124.0f, 115.0f);
            FrontEnd.ButtonInfo info = new FrontEnd.ButtonInfo();
            info.textureLabel = null;
            info.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            info.position = Utilities.CGPointMake(position.x - (querySize.x) + (kButtonInX * (scale.x)), position.y + (querySize.y) + (kButtonUpY * (scale.y)));
            info.texture = null;
            (button[(int) QueryButton.nNo]).Initialise(info);
            ((button[(int) QueryButton.nNo]).zobject).SetShowScale(scale.x);
            ((button[(int) QueryButton.nNo]).zobject).SetAtlasAndSubtextureP1(atlas, qInfo.buttonBackdropId);
            info.position = Utilities.CGPointMake(position.x + (querySize.x) - (kButtonInX * (scale.x)), position.y + (querySize.y) + (kButtonUpY * (scale.y)));
            info.texture = null;
            (button[(int) QueryButton.nYes]).Initialise(info);
            ((button[(int) QueryButton.nYes]).zobject).SetShowScale(scale.x);
            ((button[(int) QueryButton.nYes]).zobject).SetAtlasAndSubtextureP1(atlas, qInfo.buttonBackdropId);
        }

        public void SetupButtons(QueryInfo qInfo)
        {
            const float kButtonInX = 15;
            const float kButtonUpY = 15;
            FrontEnd.ButtonInfo info = new FrontEnd.ButtonInfo();
            info.textureLabel = null;
            info.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
            info.position = Utilities.CGPointMake(position.x - (boxDimensions.x / 2) + (kButtonInX * (scale.x)), position.y - (boxDimensions.y / 2) + boxDimensions.y - (
              kButtonUpY * (scale.y)));
            info.texture = qInfo.noButton;
            (button[(int) QueryButton.nNo]).Initialise(info);
            ((button[(int) QueryButton.nNo]).zobject).SetShowScale(scale.x);
            info.position = Utilities.CGPointMake(position.x - (boxDimensions.x / 2) - (kButtonInX * scale.x) + boxDimensions.x, position.y - (boxDimensions.y / 2) +
              boxDimensions.y - (kButtonUpY * scale.y));
            info.texture = qInfo.yesButton;
            (button[(int) QueryButton.nYes]).Initialise(info);
            ((button[(int) QueryButton.nYes]).zobject).SetShowScale(scale.x);
        }

        public void HandleTap(CGPoint inPosition)
        {
            if (backdrop.state !=  ZobjectState.kZobjectShown) return;

            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) 
			{
                if ((button[i]).IsTouched_NoCanClick(inPosition))
				{
                    (button[i]).Click();
                    chosenButton = (QueryButton)i;
                    {
                    }
                    break;
                }

            }

        }

        public void Initialise(QueryInfo info)
        {
			waitToHide = 0.0f;
            newStyleQuery = false;
            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) {
                if (funnyWord[i] == null) 
				{
                    funnyWord[i] = new FunnyWord();
                }

                (funnyWord[i]).Disappear();
            }

            state = QueryState.e_Inactive;
            chosenButton = (QueryButton)(-1);
            useActualText = info.useActualText;
            theInfo1 = info.theInfo1;
            theInfo2 = info.theInfo2;
            theInfo3 = info.theInfo3;
            theInfo4 = info.theInfo4;
            theInfo5 = info.theInfo5;
            theInfo6 = info.theInfo6;
            theInfo7 = info.theInfo7;
            position = info.position;
            boxDimensions = info.boxDimensions;
            if (info.backdropTexture == null) {
                scale.x = boxDimensions.x / 128;
                scale.y = boxDimensions.y / 128;
            }
            else {
                scale.x = 1.0f;
                scale.y = 1.0f;
            }

            this.SetupButtons(info);
            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            zInfo.texture = info.backdropTexture;
            zInfo.startState = ZobjectState.kZobjectHidden;
            zInfo.position = position;
            zInfo.isMapObject = false;
            backdrop.Initialise(zInfo);		
            backdrop.SetShowScale(scale.x);
			if (zInfo.texture != null)
				backdrop.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			
			
			zInfo.texture = info.dimTexture;
            zInfo.position = Utilities.CGPointMake(160.0f, 240.0f);
            dimZob.Initialise(zInfo);
            dimZob.SetStretchToScreen(true);
            dimZob.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_FadeIn);
            dimZob.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            dimZob.SetShowAlpha(0.9f);
            zInfo.texture = info.textTexture;
            zInfo.position = Utilities.CGPointMake(position.x, position.y - 40);
            text.Initialise(zInfo);
            text.SetShowScale(scale.x);
        }

        public void SetColour(Constants.RossColour inColour)
        {
            if (newStyleQuery) {
                myColour = inColour;
            }
			
			if (unityText != null)
				unityText.SetColour(myColour);

        }
		
		void DivideStringIntoFunnyWords(string queryString)
		{
			theInfo1 = queryString;
			
			for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) 
			{
				if (funnyWord[i] == null)
				{
					funnyWord[i] = new FunnyWord();
				}
					funnyWord[i].SetFont(Globals.g_world.font);
					funnyWord[i].SetColourAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_FontColours));
					funnyWord[i].SetColour(Constants.kColourRed);
			}
			
			string[] stringSeparators = new string[] {"\n"};
	       	string[] splitted = queryString.Split(stringSeparators,StringSplitOptions.None) ; //.ToDictionary(function(w){return w;});		

			string[] outString = new string[7];
			numCrappyStrings = 0;
			
			for (int i = 0; i < 7; i++)
			{
				outString[i] = "\n";
			}
			
			foreach (string s in splitted)
			{
				if (numCrappyStrings < 7)
				{
					Debug.Log("String " + numCrappyStrings.ToString() + " = " + s);
					
					outString[numCrappyStrings] = s;
					numCrappyStrings++;
				}
			}			
			
			theInfo1 = outString[0];
			theInfo1 += "\n";
			theInfo2 = outString[1];
			theInfo2 += "\n";
			theInfo3 = outString[2];
			theInfo3 += "\n";

			theInfo4 = outString[3];
			theInfo4 += "\n";


						theInfo5 = outString[4];
						theInfo5 += "\n";

			theInfo6 = outString[5];
						theInfo6 += "\n";

			theInfo7 = outString[6];
			theInfo7 += "\n";
			
			this.ShowFunnyWordsForUIAlert();
			
		}

        public void InitialiseNew(QueryInfoNew info)
        {
			waitToHide = 0.0f;
			
			if (unityText == null)
				unityText = new FunnyWord();
			
			if (info.numButtons > 0)
			{
				myColour = Constants.kColourRed;
			}
			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				info.inTextScale *= 2.0f;
			}
			
			if (Globals.g_world.DoesCurrentLanguageUseNSString() || info.useNSStringForAnyLanguage) 
			{
				useNSString = true;
			}
			else
			{
				useNSString = false;
			}
			
			FunnyWord.WordInfo wInfo;
			wInfo.position = info.position;
			wInfo.isCentrePos = true;
			wInfo.scale = info.inTextScale * 0.32f;// * 0.25f;
			
			if (useNSString) 
			{
				unityText.InitWithWordNewP1(wInfo,info.queryText);
			}
			else
			{
				position = info.position;
				this.DivideStringIntoFunnyWords(info.queryText);
			
				wInfo.scale = info.inTextScale * 0.012f;// * 0.1f;// * 0.25f;
				//unityText.SetFont(Globals.g_world.font);
				//unityText.SetColourAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_FontColours));
				//unityText.InitWithWordP1(wInfo,info.queryText);

			}
				
			unityText.SetColour(myColour);
			
			if (useNSString) 
			{
				unityText.myTextWrapper.SetBoundThing();
				unityText.SetUseTextureInstead(true);
				unityText.myTextWrapper.SetFontSize(info.inTextScale * 0.32f);
			}
			
            newStyleWithAtlas = info.newStyleWithAtlas;
            newStyleQuery = true;
            useActualText = false;
            FrontEndQuery.QueryInfo qInfo = new FrontEndQuery.QueryInfo();
            qInfo.noButton = info.noButton;
            qInfo.yesButton = info.yesButton;
            position = info.position;
            state = QueryState.e_Inactive;
            chosenButton = (QueryButton)(-1);
            queryText = (info.queryText);
            boxDimensions = Utilities.CGPointMake(info.boxDimensions.Width, info.boxDimensions.Height);
            scale.x = info.scale;
            scale.y = info.scale;
            atlas = info.inAtlas;
            if (newStyleWithAtlas) {
                this.SetupButtonsNew(info);
            }

            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            if (newStyleWithAtlas) {
                zInfo.texture = null;
            }
            else {
                zInfo.texture = info.backdropTexture;
            }

            zInfo.startState = ZobjectState.kZobjectHidden;
            zInfo.position = position;
            zInfo.isMapObject = false;
            backdrop.Initialise(zInfo);
            backdrop.SetShowScale(scale.x * 1.2f);
            if (newStyleWithAtlas) {
                backdrop.SetAtlasAndSubtextureP1(atlas, info.backdropId);
            }
            else {
//                backdrop.SetShowScale(1.2f);
            }
				
			if (backdrop.myAtlasBillboard != null)
				backdrop.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			
			numButtons = info.numButtons;
            zInfo.position = Utilities.CGPointMake(160.0f, 240.0f);
            zInfo.texture = info.dimOverlayTexture;
			dimZob.Initialise(zInfo);
            dimZob.SetStretchToScreen(true);
            dimZob.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_FadeIn);
            dimZob.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            dimZob.SetShowAlpha(0.7f);
            if (newStyleWithAtlas) 
			{
                dimZob.SetAtlasAndSubtextureP1(atlas, info.dimId);
            }

			if (dimZob.myAtlasBillboard != null)			
				dimZob.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			

            if (textTexture != null) {
            }

            CGSize dimensionsForText = info.boxDimensions;
            float textScale = info.inTextScale;
            if (Globals.deviceIPad) {
                dimensionsForText.Height *= 2.0f;
                dimensionsForText.Width *= 2.0f;
                textScale *= 2.0f;
            }

			textTexture = null;//new Texture2D_Ross(info.queryText, dimensionsForText, UITextAlignment.UITextAlignmentCenter, "Arial", textScale);
            zInfo.texture = textTexture;
            zInfo.position = position;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                if ((!Globals.deviceIPhone4) && (!Globals.deviceIPad)) {
                    zInfo.position.y += 3.0f;
                }
                else {
                    zInfo.position.y += 15.0f;
                }

            }

            text.Initialise(zInfo);
            text.SetShowScale(scale.x);
			
			if (text.myAtlasBillboard != null)			
				text.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			
			
            if (!newStyleWithAtlas) {
                boxDimensions.x = 200.0f;
                boxDimensions.y = 180.0f;
				if (info.numButtons == 0)
	                this.SetupButtons(qInfo);
            }
			
			
			if (info.numButtons > 0)
			{
				queryButtonStyle = QueryButtonStyle.kQButtonsCentral;
				this.SetupCentralButtons(info);
				
				//This means we want the new style central hanging buttons
			}
			else
			{
				queryButtonStyle = QueryButtonStyle.kQButtonsEdges;
			}
			
			backdrop.SetShowStyle(ZobjectShowStyle.kZobjectShow_SlideInLeft);
			backdrop.SetHideStyle(ZobjectHideStyle.kZobjectHide_SlideToRight);
			backdrop.SetHideAcc(0.02f);

			unityText.SetPositionZob(backdrop);
		}

        public void SetFontP1P2(ZFont inFont, ZAtlas lineAtlas, ZAtlas colourAtlas)
        {
			if (newStyleQuery)
				return;

            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) 
			{
				if (funnyWord[i] != null)
				{
    	            (funnyWord[i]).SetFont(inFont);
					(funnyWord[i]).SetLineAtlas(lineAtlas);
	                (funnyWord[i]).SetColourAtlas(colourAtlas);
	                (funnyWord[i]).SetColour(Constants.kColourRed);
				}
            }

            for (int i = 0; i < (int)Enum.kMaxCentralButtonsInQuery; i++) 
			{
				if (buttonText[i] != null)
				{
    	            (buttonText[i]).SetFont(inFont);
					(buttonText[i]).SetLineAtlas(lineAtlas);
	                (buttonText[i]).SetColourAtlas(colourAtlas);
	                (buttonText[i]).SetColour(Constants.kColourRed);
				}
            }
		
		}

        public void ShowFunnyWords()
        {
            FunnyWord.WordInfo info;
            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) (funnyWord[i]).SetSpaceGap(5.0f);

            info.position = position;
            info.scale = wordScale;
            info.isCentrePos = true;
            info.position.y -= 36.0f;
            if (Globals.deviceIPad) {
                info.position.y += 16.0f;
            }
			
            info.position.y += wordOffset;
            (funnyWord[0]).InitWithWordP1(info, theInfo1);
            info.position.y += wordGap;
            (funnyWord[1]).InitWithWordP1(info, theInfo2);
            info.position.y += wordGap;
            (funnyWord[2]).InitWithWordP1(info, theInfo3);
            info.position.y += wordGap;
            (funnyWord[3]).InitWithWordP1(info, theInfo4);
            info.position.y += wordGap;
            (funnyWord[4]).InitWithWordP1(info, theInfo5);
            info.position.y += wordGap;
            (funnyWord[5]).InitWithWordP1(info, theInfo6);
            info.position.y += wordGap;
            (funnyWord[6]).InitWithWordP1(info, theInfo7);
            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) {
                (funnyWord[i]).Show();
            }

        }
		
        public void ShowFunnyWordsForUIAlert()
        {
            FunnyWord.WordInfo info;
            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) (funnyWord[i]).SetSpaceGap(5.0f);

            info.position = position;
            info.scale = wordScale;
            info.isCentrePos = true;
            info.position.y -= 36.0f;
            if (Globals.deviceIPad) {
                info.position.y += 16.0f;
            }
			
			wordGap = 20.0f;

            info.position.y += wordOffset;
            (funnyWord[0]).InitWithWordP1(info, theInfo1);
            info.position.y += wordGap;
            (funnyWord[1]).InitWithWordP1(info, theInfo2);
            info.position.y += wordGap;
            (funnyWord[2]).InitWithWordP1(info, theInfo3);
            info.position.y += wordGap;
            (funnyWord[3]).InitWithWordP1(info, theInfo4);
            info.position.y += wordGap;
            (funnyWord[4]).InitWithWordP1(info, theInfo5);
            info.position.y += wordGap;
            (funnyWord[5]).InitWithWordP1(info, theInfo6);
            info.position.y += wordGap;
            (funnyWord[6]).InitWithWordP1(info, theInfo7);
            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) {
                (funnyWord[i]).SetPositionZob(backdrop);
                (funnyWord[i]).FitToWidth(230.0f);
                (funnyWord[i]).Show();
			}
			
			Debug.Log ("DONE SHOWING WORDS FOR UIALERT");
			
        }		

        public void ChangeFunnyWords(QueryInfo qInfo)
        {
            theInfo1 = qInfo.theInfo1;
            theInfo2 = qInfo.theInfo2;
            theInfo3 = qInfo.theInfo3;
            theInfo4 = qInfo.theInfo4;
            theInfo5 = qInfo.theInfo5;
            theInfo6 = qInfo.theInfo6;
            theInfo7 = qInfo.theInfo7;
        }

        public void Show()
        {
			if (unityText != null)
				unityText.Show();
			
			if (queryButtonStyle == QueryButtonStyle.kQButtonsCentral)
			{
				for (int i = 0; i < numButtons; i++) 
				{
	                (buttonText[i]).Show();
	            }
			}
			
            state = QueryState.e_Active;
            chosenButton = (QueryButton)(-1);
            dimZob.Show();
            backdrop.Show();
            if (useActualText) this.ShowFunnyWords();
            else {
                text.Show();
            }
			
			float timeTweenButtons = 0.04f;
			float maxWaitToShow = (float)numButtons * timeTweenButtons;
			
            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) 
			{
                (button[i]).Show();
				if (queryButtonStyle == QueryButtonStyle.kQButtonsEdges)
				{
	                ((button[i]).zobject).QueueAction( ZobjectAction.nThrobLooping);
	                ((button[i]).zobject).SetThrobSize(0.06f);
	                ((button[i]).zobject).SetThrobTime(0.5f);
					
				}
				else if (queryButtonStyle == QueryButtonStyle.kQButtonsCentral)
				{
					button[i].zobject.SetWaitToShow(maxWaitToShow - ((float)i * timeTweenButtons));
				}
            }

        }
		
        public void ShowForUIAlert()
        {
			if (unityText != null)
				unityText.Show();
			
			if (queryButtonStyle == QueryButtonStyle.kQButtonsCentral)
			{
				for (int i = 0; i < numButtons; i++) 
				{
	                (buttonText[i]).FitToWidth(170.0f);
	                (buttonText[i]).Show();
	            }
			}
			
            state = QueryState.e_Active;
            chosenButton = (QueryButton)(-1);
            dimZob.Show();
            backdrop.Show();
            if (useActualText) this.ShowFunnyWords();
            else {
                text.Show();
            }
			
			float timeTweenButtons = 0.04f;
			float maxWaitToShow = (float)numButtons * timeTweenButtons;
			
            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) 
			{
                (button[i]).Show();
				if (queryButtonStyle == QueryButtonStyle.kQButtonsEdges)
				{
	                ((button[i]).zobject).QueueAction( ZobjectAction.nThrobLooping);
	                ((button[i]).zobject).SetThrobSize(0.06f);
	                ((button[i]).zobject).SetThrobTime(0.5f);
					
				}
				else if (queryButtonStyle == QueryButtonStyle.kQButtonsCentral)
				{
					button[i].zobject.SetWaitToShow(maxWaitToShow - ((float)i * timeTweenButtons));
				}
            }
			
            for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) 
			{
               if (funnyWord[i] != null)
					(funnyWord[i]).Show();
            }

        }		

        public void Hide(float inWaitToHide)
        {
			if (waitToHide <= 0.0f)
				waitToHide = inWaitToHide;
			else
				this.Hide();
		}		
		
        public void Hide()
        {
			if (unityText != null)
			{
				if (queryButtonStyle == QueryButtonStyle.kQButtonsCentral)
				{
				}
				else
					unityText.StopRender();
			}
			
            state = QueryState.e_Inactive;
            dimZob.Hide();
            backdrop.Hide();
            if (useActualText) {
                for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) {
                    (funnyWord[i]).Hide();
                }
            }
            else {
                text.Hide();
            }

            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) (button[i]).Hide();

            (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_Swish);
        }

        public bool Update()
        {
			if (waitToHide > 0.0f)
			{
				waitToHide -= Constants.kFrameRate;
				if (waitToHide <= 0.0f)
				{
					this.Hide();
				}
			}
			
			if (unityText != null)
				unityText.UpdateNewNew();
			
            dimZob.Update();
            backdrop.Update();
            text.Update();
            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) 
			{
                (button[i]).Update();
            }

            if (!newStyleQuery) 
			{
                for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) 
				{
					if (funnyWord[i] != null)
					{
	                    (funnyWord[i]).Update();
					}
                }

            }
			
            for (int i = 0; i < (int)Enum.kMaxCentralButtonsInQuery; i++) 
			{
				if (buttonText[i] != null)
					buttonText[i].Update();
			}

        //    if (backdrop.state ==  ZobjectState.kZobjectShown) {
          //      if (chosenButton != (QueryButton)(-1)) {
            //        this.Hide();
              //      return true;
               // }

         //   }

            return false;
        }
		
        public bool UpdateForUIAlert()
        {
			if (waitToHide > 0.0f)
			{
				waitToHide -= Constants.kFrameRate;
				if (waitToHide <= 0.0f)
				{
					this.Hide();
				}
			}
			
			if (unityText != null)
				unityText.UpdateNewNew();
			
            dimZob.Update();
            backdrop.Update();
            text.Update();
            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) 
			{
                (button[i]).Update();
            }

//            if (!newStyleQuery || ) 
			if (!useNSString)
			{
                for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) 
				{
					if (funnyWord[i] != null)
					{
	                    (funnyWord[i]).UpdateNewNew();
					}
                }

            }
			
            for (int i = 0; i < (int)Enum.kMaxCentralButtonsInQuery; i++) 
			{
				if (buttonText[i] != null)
					buttonText[i].Update();
			}

            return false;
        }		

        public void SetupTileBox(ZAtlas inAtlas)
        {
            Zobject.TileBoxInfo info = new Zobject.TileBoxInfo();
            info.tileBoxAtlas = inAtlas;
            info.tileBoxWidth = 4;
            info.tileBoxHeight = 3;
            backdrop.SetupTileBox(info);
            backdrop.SetShowScale(1.0f);
        }

        public void RenderNewStyle()
        {
            (DrawManager.Instance()).Begin(atlas);
            if (!noDimZob) {
                dimZob.Render();//ToDrawArrays();
            }

            (DrawManager.Instance()).Flush();
            //glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
            //glColor4f(myColour.cRed, myColour.cGreen, myColour.cBlue, 1.0f);
            text.RenderSimple();
            //glBlendFunc(GL_ONE, GL_ONE_MINUS_SRC_ALPHA);
            //glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
            for (int i = 0; i < numButtons; i++) 
			{
                (button[i]).Render();
            }
            backdrop.RenderToDrawArrays();
					
			if (unityText != null)
			{
            	if (Globals.g_world.DoesCurrentLanguageUseNSString()) 
				{
					unityText.RenderNew();
				}
				else
				{
					unityText.Render();
				}
			}			
			
						for (int i = 0; i < numButtons; i++) 
			{
				if (buttonText[i] != null)					
					buttonText[i].Render();
			}


        }
		
        public void RenderForUIAlert()
        {
            (DrawManager.Instance()).Begin(atlas);
            if (!noDimZob) {
                dimZob.Render();//ToDrawArrays();
            }

            (DrawManager.Instance()).Flush();
            //glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
            //glColor4f(myColour.cRed, myColour.cGreen, myColour.cBlue, 1.0f);
            text.RenderSimple();
            //glBlendFunc(GL_ONE, GL_ONE_MINUS_SRC_ALPHA);
            //glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
            for (int i = 0; i < numButtons; i++) 
			{
                (button[i]).Render();
            }
            backdrop.RenderToDrawArrays();
					
			if (unityText != null)
			{
            	if (useNSString) 
				{
					unityText.RenderNew();
				}
				else
				{
//					unityText.Render();
				}
			}			
			
			for (int i = 0; i < numButtons; i++) 
			{
				if (buttonText[i] != null)					
					buttonText[i].Render();
			}
			
			if (!useNSString)
			{
                for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) {
					if (funnyWord[i] != null)
					{
						(funnyWord[i]).Render();
					}
                }
			}
        }		

        public void RenderNewStyleWithTextures()
        {
            if (!noDimZob) {
            }

            backdrop.Render();
            //glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
            //glColor4f(myColour.cRed, myColour.cGreen, myColour.cBlue, 1.0f);
			if (text != null)
	            text.RenderSimple();
            //glBlendFunc(GL_ONE, GL_ONE_MINUS_SRC_ALPHA);
            //glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) (button[i]).Render();

        }

        public void Render()
        {
            if (newStyleQuery) 
			{
                if (newStyleWithAtlas) 
					this.RenderNewStyle();
                else {
                    this.RenderNewStyleWithTextures();
             
                   }
				
			if (unityText != null)
			{
            	if (Globals.g_world.DoesCurrentLanguageUseNSString()) 
				{
					unityText.RenderNew();
				}
				else
				{
					unityText.Render();
				}
			}			
				
                return;
            }

            if (!noDimZob) {
                dimZob.Render();
            }

            backdrop.Render();
            if (useActualText) {
                for (int i = 0; i < (int)Enum.kMaxFunnyWordsInQuery; i++) {
					if (funnyWord[i] != null)
					{
						(funnyWord[i]).Render();
					}
                }

            }
            else {
                text.Render();
            }
			
			for (int i = 0; i < (int)Enum.kMaxCentralButtonsInQuery; i++) 
			{
				if (buttonText[i] != null)					
					buttonText[i].Render();
			}


            for (int i = 0; i < (int) QueryButton.kNumButtonsOnQuery; i++) (button[i]).Render();

        }

    }
}
