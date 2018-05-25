using System;
using UnityEngine;

namespace Default.Namespace
{
    public enum  HangingButtonType {
        kHB_Rope = 0,
        kHB_Chain
    }
    public class HangingButton
    {
		float wobbleDeclineMultiplier;
		public Billboard[] myBillboard = new Billboard[6];
        public CGPoint currentOffset;
        public CGPoint currentOffset2;
        public float baseAngleFromCentre;
        public float baseAngleFromCentre2;
        public float baseDistance;
        public float baseAngleOffset;
        public HangingButtonType type;
        public float currentWobble;
        public float wobbleSize;
        public float wobbleTime;
        public float wobbleDecline;
        public float currentRotation;
        public float showWobbleMultiplier;
        public int subTextureId;
        public float longerRope;
        public FrontEndButton myButton;
        public float yOffset;

				public float hangingButtonScale = 1.0f;

        public struct HangingButtonInfo{
            public CGPoint offset;
            public HangingButtonType type;
            public int subTextureId;
            public float showWobbleMultiplier;
						public float hangingButtonScale;
        };
        public float YOffset
        {
            get;
            set;
        }
		public void SetYOffset (float inthing)
		{
			yOffset = inthing;
		}

		public void SetLongerRope (float inTHing)
		{
			longerRope = inTHing;
		}


        public CGPoint Position
        {
            get;
            set;
        }

        public float CurrentRotation
        {
            get;
            set;
        }

        public float LongerRope
        {
            get;
            set;
        }

        public FrontEndButton MyButton
        {
            get;
            set;
        }

        public float BaseAngleOffset
        {
            get;
            set;
        }

	//	public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetCurrentRotation(float inThing) {currentRotation = inThing;}///@property(readwrite,assign) float currentRotation;
//public void SetYOffset(float inThing) {yOffset = inThing;}///@property(readwrite,assign) float yOffset;
//public void SetButtonLabel(FunnyWord inThing) {buttonLabel = inThing;}////@property(readwrite,assign) FunnyWord* buttonLabel;
//public void SetLongerRope(float inThing) {longerRope = inThing;}///@property(readwrite,assign) float longerRope;
public void SetMyButton(FrontEndButton inThing) {myButton = inThing;}////@property(readwrite,assign) FrontEndButton* myButton;
public void SetBaseAngleOffset(float inThing) {baseAngleOffset = inThing;}///@property(readwrite,assign) float baseAngleOffset;

        public HangingButton()
        {
            //if (!base.init()) return null;

            myButton = null;
            baseAngleOffset = 0.0f;
            //return this;
			for (int i = 0; i < 6; i++)
			{
				myBillboard[i] = null;
			}
        }

		public void Dealloc()
		{
			for (int i = 0; i < 6; i++)
			{
				if (myBillboard[i] != null)
				{
					myBillboard[i].Dealloc();
					myBillboard[i] = null;
				}
			}
			
			if (myButton != null)
			{
//				myButton.Dealloc();
				myButton = null;
			}
		}
		
		public void StopRender()
		{
			for (int i = 0; i < 6; i++)
			{
				if (myBillboard[i] != null)
					myBillboard[i].StopRender();
			}
		}
		
        public void AddToSceneP1(HangingButton.HangingButtonInfo info, FrontEndButton inButt)
        {								

						hangingButtonScale = info.hangingButtonScale;
						if (hangingButtonScale <= 0.0f)
								hangingButtonScale = 1.0f;

						wobbleDeclineMultiplier = 1.0f;
            yOffset = 0.0f;
            myButton = inButt;
            showWobbleMultiplier = info.showWobbleMultiplier;
            longerRope = 0.0f;
            baseAngleFromCentre = Utilities.GetAngleFromXYP1(info.offset.x, info.offset.y);
            baseAngleFromCentre2 = Utilities.GetAngleFromXYP1(-info.offset.x, info.offset.y);
            baseDistance = Utilities.GetDistanceP1(Utilities.CGPointMake(0, 0), info.offset);
            currentOffset = info.offset;
            currentOffset2 = info.offset;
            currentOffset2.x = -currentOffset2.x;
            type = info.type;
            currentWobble = 0.0f;
            if ((int)type == (int) HangingButtonType.kHB_Rope) {
            }
            else {
            }

            subTextureId = info.subTextureId;
        }

        public void Show(float multiplier)
        {
            currentWobble = 0.0f;
            wobbleSize = 0.18f + Utilities.GetRandBetweenP1(0.0f, 0.04f);
            wobbleSize *= multiplier;
            wobbleSize *= showWobbleMultiplier;
            wobbleTime = 0.33f + Utilities.GetRandBetweenP1(0.0f, 0.1f);
            wobbleDecline = 0.003f + (Utilities.GetRandBetweenP1(0.0f, 0.06f) / 10.0f);
            wobbleDecline *= 0.7f;
			wobbleDecline *= wobbleDeclineMultiplier;
        }

        public void SetWobbleDeclineMultiplier(float multiplier)
        {
			wobbleDeclineMultiplier = multiplier;
//            wobbleDecline *= multiplier;
        }

		public void WobbleDeclineMultiplier(float multiplier)
        {
            wobbleDecline *= multiplier;
        }

        public void UpdateOffset(float currentAngle)
        {
            CGPoint angleVec = Utilities.GetVectorFromAngle(baseAngleFromCentre + currentAngle);
            CGPoint angleVec2 = Utilities.GetVectorFromAngle(baseAngleFromCentre2 + currentAngle);
            currentOffset.x = angleVec.x * baseDistance;
            currentOffset.y = -angleVec.y * baseDistance;
            currentOffset2.x = angleVec2.x * baseDistance;
            currentOffset2.y = -angleVec2.y * baseDistance;
        }

        public float UpdateRotation()
        {
            if (wobbleSize > 0.0f) {
                currentWobble += Constants.kFrameRate;
                wobbleSize -= wobbleDecline;
                if (currentWobble >= wobbleTime) {
                    currentWobble -= wobbleTime;
                }

            }
            else {
                wobbleSize = 0.0f;
            }

            currentRotation = -0.5f + Utilities.GetCosInterpolationP1P2(currentWobble, 0.0f, wobbleTime);
            currentRotation *= wobbleSize;
            currentRotation += baseAngleOffset;
            this.UpdateOffset(currentRotation);
            return currentRotation;
        }

        public void Render(FrontEndButton inButton, ZAtlas inAtlas)
        {
            if ((myButton.zobject).state ==  ZobjectState.kZobjectWaitingToShow) {
                return;
            }

            CGPoint renderPosition = (inButton.zobject).screenPosition;
            renderPosition.x += currentOffset.x;
            renderPosition.y += currentOffset.y;
            renderPosition.y += yOffset;
            renderPosition.y -= 35.0f;
            if (Globals.deviceIPad) {
                renderPosition.x += 32.0f;
            }
			
			if (myBillboard[0] == null)
			{
				myBillboard[0] = new Billboard("hangingButton1"); 
				myBillboard[0].SetAtlas(inAtlas);
				myBillboard[0].SetDetailsFromAtlas(inAtlas,subTextureId);
				myBillboard[0].myObject.layer = LayerMask.NameToLayer("guistuff");

				
			}

            (DrawManager.Instance()).AddTextureToListP1(myBillboard[0],renderPosition, subTextureId,1.0f);
            if (longerRope > 0.0f) {
			if (myBillboard[1] == null)
			{
				myBillboard[1] = new Billboard("hangingButton2");
				myBillboard[1].SetAtlas(inAtlas);
				myBillboard[1].SetDetailsFromAtlas(inAtlas,subTextureId);
				myBillboard[1].myObject.layer = LayerMask.NameToLayer("guistuff");
				}

                renderPosition.y -= 65.0f;
                (DrawManager.Instance()).AddTextureToListP1(myBillboard[1],renderPosition, subTextureId,1.0f);
                if (longerRope > 2.0f) {
							if (myBillboard[2] == null)
			{
				myBillboard[2] = new Billboard("hangingButton3");
				myBillboard[2].SetAtlas(inAtlas);
				myBillboard[2].SetDetailsFromAtlas(inAtlas,subTextureId);
				myBillboard[2].myObject.layer = LayerMask.NameToLayer("guistuff");						
			}
					
                    renderPosition.y -= 65.0f;
                    (DrawManager.Instance()).AddTextureToListP1(myBillboard[2],renderPosition, subTextureId,1.0f);
                    renderPosition.y += 65.0f;
                }

                renderPosition.y += 65.0f;
            }

            renderPosition = (inButton.zobject).screenPosition;
            renderPosition.x += currentOffset2.x;
            renderPosition.y += currentOffset2.y;
            renderPosition.y += yOffset;
            renderPosition.y -= 35.0f;
            if (Globals.deviceIPad) {
                renderPosition.x += 32.0f;
            }
			
			if (myBillboard[4] == null)
			{
				myBillboard[4] = new Billboard("hangingButton4");
				myBillboard[4].SetAtlas(inAtlas);
				myBillboard[4].SetDetailsFromAtlas(inAtlas,subTextureId);
				myBillboard[4].myObject.layer = LayerMask.NameToLayer("guistuff");										
			}			
			
						(DrawManager.Instance()).AddTextureToListP1(myBillboard[4],renderPosition, subTextureId,hangingButtonScale);
            if (longerRope > 0.0f) {

				renderPosition.y -= 65.0f;
//                (DrawManager.Instance()).AddTextureToListP1(myBillboard[1],renderPosition, subTextureId);
                if (longerRope > 2.0f) {
					renderPosition.y -= 65.0f;
  //                  (DrawManager.Instance()).AddTextureToListP1(myBillboard[2],renderPosition, subTextureId);
                    renderPosition.y += 65.0f;
                }

                renderPosition.y += 65.0f;
            }

        }

    }
}
