using System;

namespace Default.Namespace
{
    public enum  CowPatState {
        e_Active,
        e_Inactive
    }
    public enum  CowPatAnimation {
        n_Splat = 0,
        tions
    }
    public class CowPat
    {
        public Zanimation nowAnim;
        public Zanimation[] anim = new Zanimation[(int)CowPatAnimation.tions];
        public CowPatState state;
        public CGPoint position;
        public int mapObjectId;
        public struct CowPatInfo{
            public CGPoint position;
            public int mapObjectId;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public CowPatState State
        {
            get;
            set;
        }

		//public void SetState(CowPatState inThing) {state = inThing;}///@property(readwrite,assign) CowPatState state;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;

        public CowPat()
        {
            //if (!base.init()) return null;

            for (int i = 0; i < (int) CowPatAnimation.tions; i++) anim[i] = new Zanimation();

            //return this;
        }
        public void SetupAnimations()
        {
            ZAnimationInfo info = new ZAnimationInfo();
            info.numFrames = 1;
            for (int i = 0; i < info.numFrames; i++) {
                info.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_CowPat);
                info.frameTime[i] = 5;
            }

            info.gapType = GapType.kAnimGapDistance;
            (anim[(int) CowPatAnimation.n_Splat]).Setup(info);
        }

        public void SetState(CowPatState newState)
        {
            state = newState;
        }

        public void AddToScene(CowPatInfo info)
        {
            this.SetupAnimations();
            position = info.position;
            this.SetState( CowPatState.e_Active);
            nowAnim = anim[(int) CowPatAnimation.n_Splat];
            nowAnim.PlayLooping();
        }

        public void Reset()
        {
            this.SetState( CowPatState.e_Inactive);
        }

        public void UpdateActive()
        {
        }

        public void Update()
        {
            switch (state) {
            case CowPatState.e_Active :
                this.UpdateActive();
                break;
            default :
                break;
            }

        }

    }
}
