using System;

namespace Default.Namespace
{
    public class LightBall
    {
        public Texture2D_Ross ballTexture;
        public LightBeam[] beam = new LightBeam[(int)Enum.kNumBeams];
        public float beamBaseRotation;
        public float appearAlpha;
        public float angleSpaceBetweenBeams;
        public bool appearing;
        public float rotSpeed;
        public CGPoint position;
        public CGPoint beamPosition;
        public float startAngleForBeams;
        public float beamScale;
        public enum Enum {
            kNumBeams = 9
        };
        public struct LightBallInfo{
            Texture2D_Ross inBallTex;
            Texture2D_Ross inBeamTex;
            float rotSpeed;
        };
        public bool Appearing
        {
            get;
            set;
        }

        public float AppearAlpha
        {
            get;
            set;
        }

        public LightBall()
        {
            //if (!base.init()) return null;

            for (int i = 0; i < (int)Enum.kNumBeams; i++) beam[i] = new LightBeam();

            appearing = false;
            appearAlpha = 0;
            beamBaseRotation = 0;
            angleSpaceBetweenBeams = (Constants.HALF_PI / 6);
            rotSpeed = 0.1f;
            ballTexture = null;
            position = Utilities.CGPointMake(300.0f, 0.0f);
            beamPosition = Utilities.CGPointMake(320.0f, 0.0f);
            startAngleForBeams = 0.3f;
            beamScale = 4.4f;
            //return this;
        }
        public void SetupTopLeft()
        {
            position = Utilities.CGPointMake(20.0f, 20.0f);
            beamPosition = Utilities.CGPointMake(0.0f, 0.0f);
            startAngleForBeams = -1.25f;
            beamScale = 2.0f;
//            for (int i = 0; i < (int)Enum.kNumBeams; i++) (beam[i]).SetScale(beamScale);

        }

        public void Initialise(LightBallInfo inInfo)
        {
/*            ballTexture = inInfo.inBallTex;
            LightBeamInfo beamInfo;
            beamInfo.tex = inInfo.inBeamTex;
            for (int i = 0; i < (int)Enum.kNumBeams; i++) {
                (beam[i]).Initialise(beamInfo);
            }

            rotSpeed = inInfo.rotSpeed;*/
        }

        public void Update()
        {
/*            if (appearing) {
                const float kAppearSpeed = 0.04;
                appearAlpha += kAppearSpeed;
                if (appearAlpha >= 0.5f) {
                    appearing = false;
                    appearAlpha = 0.5f;
                }

                for (int i = 0; i < (int)Enum.kNumBeams; i++) (beam[i]).SetAlpha(appearAlpha);
            }

            beamBaseRotation += rotSpeed;
            if (beamBaseRotation >= angleSpaceBetweenBeams) {
                beamBaseRotation -= angleSpaceBetweenBeams;
            }

            for (int i = 0; i < (int)Enum.kNumBeams; i++) {
                float beamRot = (-Constants.HALF_PI) - startAngleForBeams + beamBaseRotation + (angleSpaceBetweenBeams * ((float) i));
                (beam[i]).SetRotation(beamRot);
                float xDir = sin(beamRot);
                float yDir = cos(beamRot);
                float distance = 67.5f * beamScale;
                xDir *= distance;
                yDir *= distance;
                CGPoint beamPos = Utilities.CGPointMake(beamPosition.x + xDir, (beamPosition.y) + yDir);
                (beam[i]).SetPosition(beamPos);
            }
*/

        }

        public void Render()
        {

            #if TURN_OFF_RAYS
                return;
            #endif

            if (appearAlpha <= 0) return;

            for (int i = 0; i < (int)Enum.kNumBeams; i++) (beam[i]).Render();

            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPushMatrix();
            Globals.g_world.DoGLTranslateP1(position.x, position.y);
            ballTexture.DrawAtPointScaled(3 * appearAlpha);
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPopMatrix();
        }

    }
}
