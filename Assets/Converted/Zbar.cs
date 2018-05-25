using System;

namespace Default.Namespace
{
    public enum  BarType {
        e_HealthBar = 0,
        e_MovingObject
    }
    public enum  ZbarStateEnum {
        kZbarState_Hidden,
        kZbarState_Shown
    }
    public class Zbar
    {
        public BarType type;
        public CGPoint position;
        public CGPoint startPosition;
        public CGPoint endPosition;
        public float displayFillLevel;
        public float fillLevel;
        public float fillMaximum;
        public Zobject zobject;
        public Texture2D_Ross backTexture;
        public Texture2D_Ross fillTexture;
        public Texture2D_Ross borderTexture;
        public int currentAnim;
        public ZbarStateEnum state;
        public Texture2D_Ross[] inTextures = new Texture2D_Ross[3];
        public class ZbarInfoMoving{
            public CGPoint startPosition;
            public CGPoint endPosition;
            public Texture2D_Ross[] texture = new Texture2D_Ross [3];
            public ZbarStateEnum startState;
        };
        public struct ZbarInfo{
            public CGPoint position;
            public Texture2D_Ross backTexture;
            public Texture2D_Ross fillTexture;
            public Texture2D_Ross borderTexture;
            public Texture2D_Ross texture;
            public ZbarStateEnum startState;
        };
        public float FillLevel
        {
            get;
            set;
        }

		public void SetFillLevel(float inThing) {fillLevel = inThing;}///@property(readwrite,assign) float fillLevel;

        public Zbar()
        {
            //if (!base.init()) return null;

            type = BarType.e_HealthBar;
            //return this;
        }
        public void InitialiseHealthBar(ZbarInfo info)
        {
            type = BarType.e_HealthBar;
            fillLevel = 100;
            fillMaximum = 100;
            displayFillLevel = 0;
            position = info.position;
            fillTexture = info.fillTexture;
            backTexture = info.backTexture;
            borderTexture = info.borderTexture;
        }

        public void InitialiseMovingObject(ZbarInfoMoving info)
        {
            type = BarType.e_MovingObject;
            fillLevel = 0;
            fillMaximum = 100;
            displayFillLevel = 0;
            startPosition = info.startPosition;
            endPosition = info.endPosition;
            position = startPosition;
            if (zobject == null) {
                zobject = new Zobject();
            }

            Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
            zInfo.position = position;
            zInfo.texture = info.texture[0];
            zInfo.startState = ZobjectState.kZobjectShown;
            zInfo.isMapObject = false;
            zobject.Initialise(zInfo);
            currentAnim = 0;
            inTextures[0] = info.texture[0];
            inTextures[1] = info.texture[1];
            inTextures[2] = info.texture[2];
        }

        public void IterateAnim()
        {
            currentAnim++;
            if (currentAnim == 3) currentAnim = 0;
			
			if (zobject != null)
            zobject.SetTexture(inTextures[currentAnim]);
        }

        public void Show()
        {
        }

        public void SetYPosition(float yPos)
        {
            CGPoint nowPos = zobject.screenPosition;
            zobject.SetScreenPosition(Utilities.CGPointMake(nowPos.x, yPos));
        }

        public void SetXPosition(float xPos)
        {
            CGPoint nowPos = zobject.screenPosition;
            zobject.SetScreenPosition(Utilities.CGPointMake(xPos, nowPos.y));
        }

        public void Update()
        {
            if ((int)type == (int) BarType.e_MovingObject) {
                float ratio = Utilities.GetRatioP1P2(displayFillLevel, 0, fillMaximum);
                position = Utilities.GetPositionBetweenP1P2(ratio, startPosition, endPosition);
                zobject.SetScreenPosition(position);
                zobject.Update();
            }

            if (state != ZbarStateEnum.kZbarState_Shown) {
                {
                    state = ZbarStateEnum.kZbarState_Shown;
                }
            }
            else {
                displayFillLevel = displayFillLevel + ((fillLevel - displayFillLevel) * 0.2f);
            }

        }

        public void Hide()
        {
        }

        public void Render()
        {
            if ((int)type == (int) BarType.e_HealthBar) {
                //glPushMatrix();
                //glTranslatef(position.y, position.x, 0);
                backTexture.DrawAtPoint();
                float xPlus = 0;
                if (fillLevel > 0) {
                    xPlus = (-156 * ((100 - displayFillLevel) / 100));
                    //glTranslatef(0, xPlus, 0);
                    fillTexture.DrawAtPoint();
                }

                //glTranslatef(-2, -xPlus - 21, 0);
                borderTexture.DrawAtPoint();
                //glPopMatrix();
            }
            else if ((int)type == (int) BarType.e_MovingObject) {
                zobject.Render();
            }

        }

        public void AddFill(float addAmount)
        {
            fillLevel += addAmount;
            fillLevel = Utilities.ConstrainP1P2(fillLevel, 0, fillMaximum);
        }

        public void SetHardFill()
        {
            displayFillLevel = fillLevel;
        }

    }
}
