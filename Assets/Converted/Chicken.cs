using System;

namespace Default.Namespace
{
    public enum  ChickenDirection {
        kChickenFacingLeft,
        kChickenFacingRight
    }
    public enum  ChickenState {
        e_Inactive = -1,
        e_Pecking,
        e_RunningAway
    }
    public enum  ChickenAnimation {
        n_Peck = 0,
        n_RunAway,
        tions
    }
    public class Chicken
    {
        public int mapObjectId;
        public int currentAnim;
        public Zanimation[] anim = new Zanimation[(int)ChickenAnimation.tions];
        public ChickenState state;
        public CGPoint position;
        public ChickenDirection facingDirection;
        public bool renderInFrontOfPlayer;
        public float runAwaySpeed;
        public float runAwayAcc;
        public float rotation;
        public float peckRot;
        public float peckMove;
        public struct ChickenInfo{
            public CGPoint position;
            public int mapObjectId;
            public ChickenDirection facingDirection;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public ChickenState State
        {
            get;
            set;
        }

        public int MapObjectId
        {
            get;
            set;
        }

        public bool RenderInFrontOfPlayer
        {
            get;
            set;
        }


//public void SetState(ChickenState inThing) {state = inThing;}///@property(readwrite,assign) ChickenState state;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetMapObjectId(short inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetRenderInFrontOfPlayer(bool inThing) {renderInFrontOfPlayer = inThing;}///@property(readwrite,assign) bool renderInFrontOfPlayer;

        public Chicken()
        {
            //if (!base.init()) return null;

            for (int i = 0; i < (int) ChickenAnimation.tions; i++) anim[i] = new Zanimation();

            //return this;
        }
        public void Dealloc()
        {
            for (int i = 0; i < (int) ChickenAnimation.tions; i++) anim[i] = null;
        }

        public void SetupAnimations ()
		{
			ZAnimationInfo info = new ZAnimationInfo ();
			info.numFrames = 5;
			if (facingDirection == (int)ChickenDirection.kChickenFacingLeft) {
				info.subTextureId [0] = 17;
				info.subTextureId [1] = 18;
				info.subTextureId [2] = 19;
				info.subTextureId [3] = 18;
				info.subTextureId [4] = 17;
			} else {
				info.subTextureId [0] = (short)World.Enum2.kGTMud_ChickenPeck1;
				info.subTextureId [1] = (short)World.Enum2.kGTMud_ChickenPeck2;
				info.subTextureId [2] = (short)World.Enum2.kGTMud_ChickenPeck3;
				info.subTextureId [3] = (short)World.Enum2.kGTMud_ChickenPeck2;
				info.subTextureId [4] = (short)World.Enum2.kGTMud_ChickenPeck1;
			}

			for (int i = 0; i < info.numFrames; i++)
				info.frameTime [i] = 0.06f;

			info.gapType = GapType.kAnimGapTime;
			(anim [(int)ChickenAnimation.n_Peck]).Setup (info);
			info.numFrames = 2;
			if (facingDirection == (int)ChickenDirection.kChickenFacingLeft) {
				info.subTextureId [0] = (short)World.Enum2.kGTMud_ChickenFly1;
				info.subTextureId [1] = (short)World.Enum2.kGTMud_ChickenFly2;
			} else {
				info.subTextureId [0] = (short)World.Enum2.kGTMud_ChickenFly1;
				info.subTextureId [1] = (short)World.Enum2.kGTMud_ChickenFly2;
            }

            for (int i = 0; i < info.numFrames; i++) info.frameTime[i] = 0.06f;

            info.gapType = GapType.kAnimGapTime;
            (anim[(int) ChickenAnimation.n_RunAway]).Setup(info);
        }

        public void SetState(ChickenState newState)
        {
            state = newState;
        }

        public void AddToScene(ChickenInfo info)
        {
            facingDirection = info.facingDirection;
            this.SetupAnimations();
            renderInFrontOfPlayer = true;
            position = info.position;
            mapObjectId = (short)info.mapObjectId;
            this.SetState(ChickenState.e_Pecking);
            currentAnim = (short)ChickenAnimation.n_Peck;
            (anim[currentAnim]).PlayOnce();
            rotation = 0.0f;
        }

        public void Reset()
        {
            this.SetState(ChickenState.e_Inactive);
        }

        public void NewGameStateGetReady()
        {
        }

        public void RunAway(CGPoint playerSpeed)
        {
            if (Utilities.GetRand( 2) == 0) {
                float squawkVol = Utilities.GetRandBetweenP1(0.3f, 0.8f);
                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_ChickenSquawk1, squawkVol);
            }
            else {
                (SoundEngine.Instance()).PlayFinchSound((int)Audio.Enum1.kSoundEffect_ChickenFlapWings);
            }

            currentAnim = (short)ChickenAnimation.n_RunAway;
            this.SetState(ChickenState.e_RunningAway);
            (anim[currentAnim]).PlayLooping();
            runAwaySpeed = 1.2f + (playerSpeed.y / 5.0f);
            runAwayAcc = 0.35f + (playerSpeed.y / 20.0f);
        }

        public void Pop()
        {
            this.SetState(ChickenState.e_Inactive);
            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetFlaggedToRemoveNextFrame(true);
        }

        public bool CheckPop(CGPoint playerPosition)
        {
            const float kDistanceToPopSqr = 225.0f;
            float sqrDistance = Utilities.GetSqrDistanceP1(playerPosition, position);
            if (sqrDistance <= kDistanceToPopSqr) {
                this.Pop();
                return true;
            }

            return false;
        }

        public void CheckRunAwayP1(CGPoint playerPosition, CGPoint playerSpeed)
        {
            if (state != (int) ChickenState.e_Pecking) return;

            float distToRun = 100.0f + (playerSpeed.y * 10.0f);
            float kSqrDistanceToRun = (distToRun * distToRun);
            float sqrDistance = Utilities.GetSqrDistanceP1(playerPosition, position);
            if (sqrDistance <= kSqrDistanceToRun) {
                this.RunAway(playerSpeed);
            }

        }

        public void UpdateRunningAway()
        {
            if (facingDirection == (int) ChickenDirection.kChickenFacingLeft) {
                position.x -= runAwaySpeed;
            }
            else {
                position.x += runAwaySpeed;
            }

            const float kMaxRunSpeed = 12.0f;
            if (runAwaySpeed < kMaxRunSpeed) runAwaySpeed += runAwayAcc;

            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(position);
            (anim[(int) ChickenAnimation.n_RunAway]).Update();
            if (!Utilities.IsBetweenP1P2((int) (position.x), -50, 430)) {
                this.SetState(ChickenState.e_Inactive);
            }

        }

        public void UpdateCluckSound()
        {
            if (Utilities.GetRand( 50) == 0) 
			{
                float cluckVol = Utilities.GetRandBetweenP1(0.25f, 0.7f);

                (SoundEngine.Instance()).PlayFinchSoundP1((int)Audio.Enum1.kSoundEffect_ChickenCluck1 + Utilities.GetRand(2), cluckVol);
            }
        }

        public void UpdatePecking()
        {
            this.UpdateCluckSound();
            if ((int)(anim[(int) ChickenAnimation.n_Peck]).state == (int)AnimationState.kAnimFinished) {
                if (Utilities.GetRand( 50) == 0) {
                    (anim[(int) ChickenAnimation.n_Peck]).PlayOnce();
                    peckRot = ((float)(Utilities.GetRand( 20)) / 50.0f) - 0.02f;
                    peckMove = ((float)(Utilities.GetRand( 35)) / 100.0f) + 0.05f;
                    if (Utilities.GetRand( 2) == 0) {
                        peckMove = -peckMove;
                    }

                }

            }
            else {
                (anim[(int) ChickenAnimation.n_Peck]).Update();
                position.x += peckMove;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(position);
            }

        }

        public void Update()
        {
            int stId = -1;
            switch (state) {
            case ChickenState.e_Pecking :
                this.UpdatePecking();
                stId = (anim[currentAnim]).GetSubTextureId();
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId((short)stId);
                break;
            case ChickenState.e_RunningAway :
                this.UpdateRunningAway();
                stId = (anim[currentAnim]).GetSubTextureId();
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetSubTextureId((short)stId);
                break;
            default :
                break;
            }

        }

    }
}
