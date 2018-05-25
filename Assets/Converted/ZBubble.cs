using System;

namespace Default.Namespace
{
    public class ZBubble
    {
        public float xSpeed;
        public float ySpeed;
        public float xPosition;
        public float yPosition;
        public float minScale;
        public float maxScale;
        public float xScale;
        public float yScale;
        public bool popped;
        public struct ZBubbleInfo{
            public float xSpeed;
            public float ySpeed;
            public float xPosition;
            public float yPosition;
            public float minScale;
            public float maxScale;
        };
        public float XScale
        {
            get;
			set;
        }

        public float YScale
        {
            get;
			set;
		}

        public bool Popped
        {
            get;
			set;
        }

		public void SetXScale(float inThing) {xScale = inThing;}///@property(readonly) float xScale;
public void SetYScale(float inThing) {yScale = inThing;}///@property(readonly) float yScale;
public void SetPopped(bool inThing) {popped = inThing;}///@property(readonly) bool popped;

        public void Setup(ZBubbleInfo inInfo)
        {
            xSpeed = inInfo.xSpeed;
            ySpeed = inInfo.ySpeed;
            xPosition = inInfo.xPosition;
            yPosition = inInfo.yPosition;
            minScale = inInfo.minScale;
            maxScale = inInfo.maxScale;
        }

        public void Show()
        {
            popped = false;
            xPosition = Utilities.GetRandBetweenP1(0.0f, Constants.PI_);
            yPosition = Utilities.GetRandBetweenP1(0.0f, Constants.PI_);
        }

        public void Pop()
        {
            popped = true;
            xPosition = 0.7f;
        }

        public void RenderP1(CGPoint inPos, float inScale)
        {
            if (popped) {
                if (xPosition > 0.1f) {
                    const float kPoppedScalePlus = 0.06f;
                    const float kPoppedAlphaDrop = 0.1f;
                    xScale += kPoppedScalePlus;
                    yScale += kPoppedScalePlus;
                    xPosition -= kPoppedAlphaDrop;
                    (DrawManager.Instance()).AddTextureToListXYScaleAlphaP1P2P3P4(inPos, (0.9f + xScale) * inScale, (0.9f + yScale) * inScale, xPosition, 2);
                }

                return;
            }

            xPosition += xSpeed;
            yPosition += ySpeed;
            xScale = 1.0f + ((1.0f + ((float)Math.Cos(xPosition)) / 2.0f) * maxScale);
            yScale = 1.0f + ((1.0f + ((float)Math.Cos(yPosition)) / 2.0f) * maxScale);
            (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(inPos, xScale * inScale, yScale * inScale, 0);
        }

    }
}
