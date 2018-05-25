using System;

namespace Default.Namespace
{
    public class LightBeam
    {
        public float rotation;
        public float alpha;
        public Texture2D_Ross texture;
        public CGPoint position;
        public float scale;
        public struct LightBeamInfo{
            Texture2D_Ross tex;
        };
        public float Rotation
        {
            get;
            set;
        }

        public float Alpha
        {
            get;
            set;
        }

        public CGPoint Position
        {
            get;
            set;
        }

        public float Scale
        {
            get;
            set;
        }

        public LightBeam()
        {
            //if (!base.init()) return null;

            rotation = 0;
            alpha = 0.5f;
            scale = 4.4f;
            //return this;
        }
        public void Initialise(LightBeamInfo inInfo)
        {
//            texture = inInfo.tex;
        }

        public void Render()
        {

            #if TURN_OFF_RAYS
                return;
            #endif

            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPushMatrix();
            Globals.g_world.DoGLTranslateP1(position.x, position.y);
            //glRotatef((rotation) * (360.0 / (Constants.TWO_PI)), 0, 0, 1);
           // texture.DrawAtPointScaledAlphaP1(scale, 0.6 * alpha);
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPopMatrix();
        }

    }
}
