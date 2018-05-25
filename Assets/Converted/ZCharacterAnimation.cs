using System;

namespace Default.Namespace
{
    public class ZCharacterAnimation
    {
        public Zanimation[] anim = new Zanimation[(int)Enum.kMaxAnimationsPerCharacter];
        public int numAnimations;
        public int currentAnimId;
        public int[] queuedAnim = new int[(int)Enum.kMaxAnimsInQueue];
        public int[] queuedAnimStyle = new int[(int)Enum.kMaxAnimsInQueue];
        public int numQueuedAnims;
        public struct ZCharacterAnimationInfo{
            CGPoint position;
        };
        public enum Enum {
            kMaxAnimationsPerCharacter = 10,
            kMaxAnimsInQueue = 5
        };
        public int CurrentAnimId
        {
            get;
            set;
        }

        public int NumQueuedAnims
        {
            get;
            set;
        }

        public ZCharacterAnimation ()
		{
			//if (!base.init()) return null;

			for (int i = 0; i < (int)Enum.kMaxAnimationsPerCharacter; i++) {
                anim[i] = null;
            }

            //return this;
        }
        public void SetStartOfGame()
        {
            currentAnimId = -1;
            numAnimations = 0;
        }

        public int GetSubtextureId()
        {
            Globals.Assert(currentAnimId != -1);
            return (anim[currentAnimId]).GetSubTextureId();
        }

        public int AddAnimation (ZAnimationInfo zInfo)
		{
			Globals.Assert (numAnimations < (int)Enum.kMaxAnimationsPerCharacter);
            if (anim[numAnimations] == null) {
                anim[numAnimations] = new Zanimation();
            }

            (anim[numAnimations]).Setup(zInfo);
            numAnimations++;
            return (numAnimations - 1);
        }

        public Zanimation GetAnimation (int animId)
		{
			Globals.Assert (animId < (int)Enum.kMaxAnimationsPerCharacter);
            Globals.Assert(animId < numAnimations);
            return anim[animId];
        }

        public Zanimation GetCurrentAnimation()
        {
            Globals.Assert(currentAnimId != -1);
            return anim[currentAnimId];
        }

        public void PlayAnimationP1 (int animId, AnimationStyle inStyle)
		{
			Globals.Assert (animId < (int)Enum.kMaxAnimationsPerCharacter);
            if (inStyle ==  AnimationStyle.kAnimPlayOnce) {
                (anim[animId]).PlayOnce();
            }
            else {
                (anim[animId]).PlayLooping();
            }

            currentAnimId = animId;
        }

        public void PlayAnimation(int animId)
        {
            this.PlayAnimationP1(animId, AnimationStyle.kAnimPlayOnce);
        }

        public void QueueAnimationP1 (int animId, AnimationStyle inStyle)
		{
			if (numQueuedAnims >= (int)Enum.kMaxAnimsInQueue)
				return;

			Globals.Assert (numQueuedAnims < (int)Enum.kMaxAnimsInQueue);
            queuedAnim[numQueuedAnims] = animId;
            queuedAnimStyle[numQueuedAnims] = (int)inStyle;
            numQueuedAnims++;
        }

        public void QueueAnimation(int animId)
        {
            this.QueueAnimationP1(animId, AnimationStyle.kAnimPlayOnce);
        }

        public void UpdateQueuedAnims ()
		{
			if ((anim [currentAnimId]).state == AnimationState.kAnimFinished) {
				if (numQueuedAnims > 0) {
					this.PlayAnimationP1 (queuedAnim [0], (AnimationStyle)queuedAnimStyle [0]);
					for (int i = 0; i < (int)Enum.kMaxAnimsInQueue - 1; i++) {
                        queuedAnim[i] = queuedAnim[i + 1];
                        queuedAnimStyle[i] = queuedAnimStyle[i + 1];
                    }

                    numQueuedAnims--;
                }

            }

        }

        public bool Update()
        {
            if (currentAnimId == -1) return false;

            (anim[currentAnimId]).Update();
            this.UpdateQueuedAnims();
            return false;
        }

    }
}
