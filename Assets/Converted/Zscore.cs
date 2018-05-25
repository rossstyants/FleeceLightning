using System;
using UnityEngine;

namespace Default.Namespace
{
    public enum  ZscoreState {
        e_Hidden,
        e_Shown
    }
    public class Zscore
    {
				public HangingButton positionZob;
        public ZAtlas myAtlas;
        public CGPoint position;
        public Zobject[] zobject = new Zobject[(int)Enum.kMaxNumScoreDigits];
        public float score;
        public float displayScore;
        public int prevScore;
        public float scale;
        public float timeBetweenShowingDigits;
        public ZscoreState state;
        public Texture2D_Ross[] digitTexture = new Texture2D_Ross[(int)Enum.kMaxDigitTextures];
        public Texture2D_Ross pointTexture;
        public int decimalPoint;
        public float digitWidth;
        public int numDigits;
        public Constants.RossColour defaultColour;
        public float[] xDigit = new float[11];
        public bool dontDisplayLeadingZeros;
        public float rotationWholeWord;
        public HangingButton orientationButton;
        public FrontEndButton positionButton;
        public enum Enum {
            kMaxNumScoreDigits = 5,
            kMaxDigitTextures = 10
        };
        public struct ZscoreInfo {
            public CGPoint position;
            public int numDigits;
        };
        public HangingButton OrientationButton
        {
            get;
            set;
        }

        public FrontEndButton PositionButton
        {
            get;
            set;
        }

        public ZscoreState State
        {
            get;
            set;
        }

        public int DecimalPoint
        {
            get;
            set;
        }

        public float DigitWidth
        {
            get;
            set;
        }

        public float Score
        {
            get;
            set;
        }

        public int NumDigits
        {
            get;
            set;
        }

        public bool DontDisplayLeadingZeros
        {
            get;
            set;
        }

        public float TimeBetweenShowingDigits
        {
            get;
			set;
        }

        public ZAtlas MyAtlas
        {
            get;
            set;
        }

		public void SetPositionButton(FrontEndButton inThing) {positionButton = inThing;}////@property(readwrite,assign) FrontEndButton* positionButton;
//public void SetTimeBetweenShowingDigits(float inThing) {timeBetweenShowingDigits = inThing;}///@property(readonly) float timeBetweenShowingDigits;
public void SetOrientationButton(HangingButton inThing) {orientationButton = inThing;}////@property(readwrite,assign) HangingButton* orientationButton;
public void SetNumDigits(int inThing) {numDigits = inThing;}///@property(readwrite,assign) int numDigits;
public void SetState(ZscoreState inThing) {state = inThing;}///@property(readwrite,assign) ZscoreState state;
public void SetDecimalPoint(int inThing) {decimalPoint = inThing;}///@property(readwrite,assign) int decimalPoint;
public void SetDigitWidth(float inThing) {digitWidth = inThing;}///@property(readwrite,assign) float digitWidth;
//public void SetScore(float inThing) {score = inThing;}///@property(readwrite,assign) float score;
public void SetDontDisplayLeadingZeros(bool inThing) {dontDisplayLeadingZeros = inThing;}///@property(readwrite,assign) bool dontDisplayLeadingZeros;
public void SetMyAtlas(ZAtlas inThing) {myAtlas = inThing;}////@property(readwrite,assign) ZAtlas* myAtlas;

        public Zscore ()
		{
			//  //if (!base.init()) return null;

			myAtlas = null;
			orientationButton = null;
			positionButton = null;
			for (int i = 0; i < (int)Enum.kMaxNumScoreDigits; i++) {
                zobject[i] = new Zobject();
            }

            rotationWholeWord = 0.0f;
            scale = 1;
            state = ZscoreState.e_Hidden;
            prevScore = -1;
            decimalPoint = -1;
            digitWidth = 31;
            defaultColour = Constants.kColourWhite;
            dontDisplayLeadingZeros = false;
            xDigit[0] = 10.5f;
            xDigit[1] = 6.5f;
            xDigit[2] = 10.0f;
            xDigit[3] = 10.0f;
            xDigit[4] = 10.0f;
            xDigit[5] = 10.0f;
            xDigit[6] = 10.0f;
            xDigit[7] = 8.5f;
            xDigit[8] = 10.0f;
            xDigit[9] = 10.0f;
            xDigit[10] = 6.0f;
            timeBetweenShowingDigits = 0.05f;
            for (int i = 0; i < 11; i++) {
                xDigit[i] *= 3.0f;
            }

        //    //return this;
        }
        public void Dealloc ()
		{
			for (int i = 0; i < (int)Enum.kMaxNumScoreDigits; i++) {
                zobject[i].Dealloc();
                zobject[i] = null;
            }

        }
		
		public void StopRender()
		{
			for (int i = 0; i < numDigits; i++) {
				zobject[i].StopRender();
			}
		}


        public void SetColour (Constants.RossColour inCol)
		{
			defaultColour = inCol;
			for (int i = 0; i < (int)Enum.kMaxNumScoreDigits; i++) {
                (zobject[i]).SetColour(inCol);
            }

        }

        public void SetFontAtlas(ZAtlas inAtlas)
        {
            myAtlas = inAtlas;
			
			for (int i = 0; i < (int)Enum.kMaxNumScoreDigits; i++) {
                zobject[i].SetAtlas(myAtlas);
                zobject[i].SetSubTextureId(0); //fake
				(zobject[i]).myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			}
        }

        public void ChangeNumDigits(int newNum)
        {
            numDigits = newNum;
            this.SetPosition(position);
            this.Hide();
            this.Show();
        }

        public void SetupDigits(ZFont inFont)
        {
            for (int i = 0; i < 10; i++) {
                this.SetupDigitTexturesP1(i, inFont.GetNumber(i));
            }

        }

        public void SetupDigitTexturesP1 (int digit, Texture2D_Ross inTex)
		{
			Globals.Assert (digit < (int)Enum.kMaxDigitTextures);
            digitTexture[digit] = inTex;
        }

        public void SetupPointTexture(Texture2D_Ross inTex)
        {
            pointTexture = inTex;
        }

        public void SetPosition(CGPoint newPosition)
        {
            position = newPosition;
            this.Update(true);
        }
		
		public void SetPositionNoUpdate(CGPoint newPosition)
        {
            position = newPosition;
        }

        public void Reset()
        {
            this.Hide();
            score = 0.0f;
        }

        public void Show(float waitToShow)
        {
            state = ZscoreState.e_Shown;
            for (int i = 0; i < numDigits; i++) {
                if (timeBetweenShowingDigits > 0.0f) {
                    (zobject[i]).SetWaitToShow(waitToShow + (((float) i) * timeBetweenShowingDigits));
                }

                (zobject[i]).Show();
            }

        }

        public void SetTimeBetweenShowingDigits(float inTime)
        {
            timeBetweenShowingDigits = inTime;
            if (inTime == 0.0f) {
                for (int i = 0; i < numDigits; i++) {
                    (zobject[i]).SetWaitToShow(0.0f);
                }

            }

        }

        public void Show()
        {
            this.Show(0);
        }

        public void SetShowStyle(int inStyle)
        {
            for (int i = 0; i < numDigits; i++) {
                (zobject[i]).SetShowStyle((ZobjectShowStyle) inStyle);
                (zobject[i]).SetShowScale(scale);
                (zobject[i]).SetGravityFloorLevel(position.y);
            }

        }

        public void SetHideStyle(int inStyle)
        {
            for (int i = 0; i < numDigits; i++) {
                (zobject[i]).SetHideStyle((ZobjectHideStyle) inStyle);
            }

        }

        public void SetScale(float inScale)
        {
            scale = inScale;
            for (int i = 0; i < numDigits; i++) {
                (zobject[i]).SetShowScale(inScale);
            }

            this.SetPosition(position);
        }

        public void Disappear()
        {
            if (state == (int) ZscoreState.e_Hidden) return;

            for (int i = 0; i < numDigits; i++) {
                (zobject[i]).Disappear();
            }

            state = ZscoreState.e_Hidden;
        }

        public void SetThrobSize(float inSize)
        {
            for (int i = 0; i < numDigits; i++) {
                (zobject[i]).SetThrobSize(inSize);
            }

        }

        public void Hide()
        {
            if (state == (int) ZscoreState.e_Hidden) return;

            for (int i = 0; i < numDigits; i++) {
                if ((zobject[i]).state !=  ZobjectState.kZobjectThrobbing) (zobject[i]).Hide();

            }

            state = ZscoreState.e_Hidden;
        }

        public void SetScore(float amount)
        {
            if (decimalPoint != -1) score = amount * 100;
            else score = amount;

        }

        public void SetNumDigitsFromScore()
        {
            if (score < 10.0f) this.SetNumDigits(1);
            else if (score < 100.0f) this.SetNumDigits(2);
            else if (score < 1000.0f) this.SetNumDigits(3);
            else if (score < 1000.0f) this.SetNumDigits(4);
            else if (score < 10000.0f) this.SetNumDigits(5);
            else if (score < 100000.0f) this.SetNumDigits(6);
            else {
                this.SetNumDigits(7);
            }

        }

        public void SetScoreAndDigits(float amount)
        {
            this.SetScore(amount);
            this.SetNumDigitsFromScore();
        }

        public void AddScore(float AddAmount)
        {
            score += AddAmount;
            if (state == (int) ZscoreState.e_Hidden) return;

            for (int i = 0; i < numDigits; i++) {
                (zobject[i]).Throb();
            }

        }

        public void UpdateWordPosition()
        {
            if (positionButton != null) {
                CGPoint offset = (positionButton.zobject).GetOffsetForWord();
                for (int i = 0; i < numDigits; i++) {
                    CGPoint oldPos = (zobject[i]).mapPosition;
                    oldPos.x += offset.x;
                    (zobject[i]).SetScreenPosition(oldPos);
                }

            }

        }

        public void Throb()
        {
            for (int i = 0; i < numDigits; i++) {
                (zobject[i]).Throb();
            }

        }

        public void Render()
        {
            Globals.Assert(myAtlas != null);
            this.UpdateWordRotation();
            this.UpdateWordPosition();
            if (true) {
                ////glEnableClientState (GL_COLOR_ARRAY);
            }

            (DrawManager.Instance()).Begin(myAtlas);
            bool displayedFirstDigit = false;
            for (int i = 0; i < numDigits; i++) {
                if (dontDisplayLeadingZeros) {
                    if (!displayedFirstDigit) {
                        if (((zobject[i]).subTextureId == 0) && (i != (numDigits - 1))) {
                            continue;
                        }
                        else {
                            displayedFirstDigit = true;
                        }

                    }

                }

                if (Utilities.IsOnScreenP1((zobject[i]).screenPosition, 50.0f)) {
                    (zobject[i]).RenderToDrawArrays();
                }
				else
				{
					(zobject[i]).StopRender();
				}

            }

            (DrawManager.Instance()).Flush();
            if (true) {
                ////glDisableClientState (GL_COLOR_ARRAY);
            }

            if (rotationWholeWord != 0.0f) {
                //glPopMatrix();
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
                //glLoadIdentity();
                //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
            }

        }

				void UpdateLocalPosition()
				{
						if (positionZob != null)
						{
								for (int i = 0; i < numDigits; i++) {

										CGPoint pos = new CGPoint();
										pos.x = zobject[i].screenPosition.x - positionZob.myButton.zobject.screenPosition.x;
										pos.y = zobject[i].screenPosition.y - positionZob.myButton.zobject.screenPosition.y;
										//										0.0f);

										//Uh?...
//										if (score > 9)
//												pos.x *= 0.8f;
//										else
										//		pos.x *= 1.1f;

										pos.y *= -1.0f;

//										zobject[i].myAtlasBillboard.myObject.transform.parent = 
//												positionZob.myButton.zobject.myAtlasBillboard.myObject.transform;

										zobject[i].myAtlasBillboard.localPosition = pos;

								}						}
				}
				public void SetOrientationParent(HangingButton inThing)
				{
						positionZob = inThing;

						for (int i = 0; i < numDigits; i++) {

								CGPoint pos = new CGPoint();
								pos.x = zobject[i].screenPosition.x - inThing.myButton.zobject.screenPosition.x;
								pos.y = zobject[i].screenPosition.y - inThing.myButton.zobject.screenPosition.y;
//										0.0f);

								//Uh?...
								if (score > 9)
									pos.x *= 0.8f;
								else
									pos.x *= 0.15f;

								pos.y *= -1.0f;

								zobject[i].myAtlasBillboard.myObject.transform.parent = 
							inThing.myButton.zobject.myAtlasBillboard.myObject.transform;

								zobject[i].myAtlasBillboard.localPosition = pos;

						}
//						positionZob = inThing;
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
                float roatation = rotationWholeWord;
                float yThing = Globals.g_world.screenHeight;
                float x = position.x;
                float y = position.y;
                if (Globals.deviceIPad) {
                    x *= 2.0f;
                    x += 64.0f;
                    y *= 2.0f;
                }

                CGPoint tempWordPos = Utilities.CGPointMake(x, y);
                CGPoint vectorToBasePos = Utilities.CGPointMake(tempWordPos.x, yThing - tempWordPos.y);
                float baseAngle = Constants.PI_ - Utilities.GetAngleFromXYP1(vectorToBasePos.x, vectorToBasePos.y);
                CGPoint positionWas = tempWordPos;
                float distance = Utilities.GetDistanceP1(Utilities.CGPointMake(0, yThing), positionWas);
                CGPoint newPosVec = Utilities.GetVectorFromAngle(baseAngle + roatation);
                newPosVec.x *= distance;
                newPosVec.y *= distance;
                CGPoint positionNow = newPosVec;
                positionNow.y = -positionNow.y;
                CGPoint diff;
                diff.x = positionNow.x - positionWas.x;
                diff.y = positionNow.y - (yThing - positionWas.y);
                //glRotatef((roatation) * (360.0 / (Constants.TWO_PI)), 0, 0, 1);
                //glTranslatef(diff.x * Constants.kScreenMultiplierForShorts, diff.y * Constants.kScreenMultiplierForShorts, 0.0f);
                CGPoint orientationButtonPos = Utilities.CGPointMake((orientationButton.myButton).position.x, (orientationButton.myButton).position.y);
                if (Globals.deviceIPad) {
                    orientationButtonPos.x *= 2.0f;
                    orientationButtonPos.x += 64.0f;
                    orientationButtonPos.y *= 2.0f;
                }

                CGPoint startOffset = Utilities.CGPointMake(tempWordPos.x - orientationButtonPos.x, tempWordPos.y - orientationButtonPos.y);
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

        }

				public void UpdateWordPositionNew()
				{
//						if (positionZob != null) {
//								CGPoint offset = positionZob.GetOffsetForWord();
//								CGPoint oldPos = zobTexture.mapPosition;
//								oldPos.x += offset.x;
//								oldPos.y += offset.y;
//								zobTexture.SetScreenPosition(oldPos);
//						}

				}


        public void Update()
        {
            this.Update(false);
        }

        public void Update(bool forceUpdate)
        {
            displayScore = displayScore + ((score - displayScore) * 0.1f);
            float[] xPosition = new float[10];
            float xLength = 0.0f;
            if (((int) score != prevScore) || forceUpdate) 
			{
                int whichDigit = 0;
                int numNumberDigits;
                if (decimalPoint != -1) numNumberDigits = numDigits - 1;
                else numNumberDigits = numDigits;

                float xStart = 0.0f;
                for (int i = 0; i < numDigits; i++) {
                    int digitForLength;
                    if (i == decimalPoint) {
                        (zobject[i]).SetAtlas(myAtlas);
                        (zobject[i]).SetSubTextureId(10);
//						(zobject[i]).myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
                        digitForLength = 10;
                    }
                    else {
                        int intScore = (int) score;
                        int toPower = (int)Math.Pow(10, (numNumberDigits - whichDigit));
                        int useScore = intScore % toPower;
                        toPower = (int)Math.Pow(10, ((numNumberDigits - 1) - whichDigit));
                        int digit = useScore / toPower;
                        (zobject[i]).SetAtlas(myAtlas);
                        (zobject[i]).SetSubTextureId(digit);
						//(zobject[i]).myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
						digitForLength = digit;
                        whichDigit++;
                    }

                    xLength += xDigit[digitForLength] * scale;
                    xStart += ((xDigit[digitForLength] / 2.0f) * scale);
                    xPosition[i] = xStart;
                    xStart += ((xDigit[digitForLength] / 2.0f) * scale);
                }

            }

            prevScore = (int) score;
            float wordStartX = position.x - (xLength / 2.0f);
            for (int i = 0; i < numDigits; i++) {
                if (xLength > 0.0f) {
                    CGPoint pos = Utilities.CGPointMake(wordStartX + xPosition[i], position.y);
                    (zobject[i]).SetScreenPosition(pos);
                    (zobject[i]).SetMapPosition(pos);
                }

                (zobject[i]).Update();
            }

						this.UpdateLocalPosition();
        }

        public void QueueAction(int zobjectActionId)
        {
            for (int i = 0; i < numDigits; i++) {
                (zobject[i]).QueueAction((ZobjectAction) zobjectActionId);
            }

        }

        public Zobject GetDigit (int which)
		{
			Globals.Assert (which < (int)Enum.kMaxNumScoreDigits);
            return zobject[which];
        }

        public void Jiggle()
        {
            Zobject.FloatyInfo floatyInfo = new Zobject.FloatyInfo();
            floatyInfo.xSize = 1;
            floatyInfo.ySize = 1;
            floatyInfo.xOffset = 0;
            floatyInfo.yOffset = 0;
            for (int i = 0; i < numDigits; i++) {
                floatyInfo.xSpeed = 0.12f + ((float)(Utilities.GetRand( 15)) / 1000);
                floatyInfo.ySpeed = 0.14f + ((float)(Utilities.GetRand( 15)) / 1000);
                floatyInfo.xPosition = (float)(Utilities.GetRand( 314)) / 100;
                floatyInfo.yPosition = (float)(Utilities.GetRand( 314)) / 100;
                (zobject[i]).SetFloatyInfo(floatyInfo);
                (zobject[i]).SetIsFloaty(true);
            }

        }

        public void Initialise (ZscoreInfo zInfo)
		{
			position = zInfo.position;
			score = 0;
			prevScore = -1;
			displayScore = score;
			Globals.Assert ((zInfo.numDigits <= 5) && (zInfo.numDigits > 0));
			numDigits = zInfo.numDigits;
			Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
			info.texture = digitTexture [0];
			info.startState = ZobjectState.kZobjectHidden;
			info.isMapObject = false;
			for (int i = 0; i < (int)Enum.kMaxNumScoreDigits; i++) {
                (zobject[i]).Initialise(info);
            }

            this.SetPosition(position);
        }

    }
}
