using System;

namespace Default.Namespace
{
    public enum  CowMovement {
        kCowWalkingLeft = 0,
        kCowWalkingRight,
        kCowStandingStillLeft,
        kCowStandingStillRight
    }
    public enum  CowState {
        e_Active,
        e_Inactive
    }
    public enum  CowAnimation {
        n_Walk = 0,
        n_FallOver,
        tions
    }
    public class Cow
    {
        public MapObject mapObject;
        public int mapObjectId;
        public MapObject shadowMapObject;
        public Zanimation nowAnim;
        public Zanimation[] anim = new Zanimation[(int)CowAnimation.tions];
        public CowState state;
        public CGPoint position;
        public CGPoint velocity;
        public CGPoint screenPosition;
        public float noseAngle;
        public float wobbleSin;
        public bool knockedOver;
        public int noGoZoneId;
        public CowMovement movement;
        public bool renderInFrontOfPlayer;
        public float rotation;
        public bool stillHasMapObject;
        public bool blinking;
        public float timeToNextBlink;
        public struct CowInfo{
            public CGPoint position;
            public CGPoint velocity;
            public int mapObjectId;
            public int shadowMapObjectId;
            public CowMovement movement;
            public int noGoZoneId;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public CGPoint Velocity
        {
            get;
            set;
        }

        public CowState State
        {
            get;
            set;
        }

        public bool KnockedOver
        {
            get;
            set;
        }

        public int NoGoZoneId
        {
            get;
            set;
        }

        public MapObject MapObject
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

        public bool StillHasMapObject
        {
            get;
            set;
        }

		public void SetStillHasMapObject(bool inThing) {stillHasMapObject = inThing;}///@property(readwrite,assign) bool stillHasMapObject;
//public void SetState(CowState inThing) {state = inThing;}///@property(readwrite,assign) CowState state;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetVelocity(CGPoint inThing) {velocity = inThing;}///@property(readwrite,assign) CGPoint velocity;
public void SetKnockedOver(bool inThing) {knockedOver = inThing;}///@property(readwrite,assign) bool knockedOver;
public void SetNoGoZoneId(int inThing) {noGoZoneId = inThing;}///@property(readwrite,assign) int noGoZoneId;
public void SetMapObject(MapObject inThing) {mapObject = inThing;}////@property(readwrite,assign) MapObject* mapObject;
public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetRenderInFrontOfPlayer(bool inThing) {renderInFrontOfPlayer = inThing;}///@property(readwrite,assign) bool renderInFrontOfPlayer;

        public Cow()
        {
            //if (!base.init()) return null;

            for (int i = 0; i < (int) CowAnimation.tions; i++) anim[i] = new Zanimation();

            //return this;
        }
        public void Dealloc()
        {
            for (int i = 0; i < (int) CowAnimation.tions; i++) anim[i] = null;
        }

        public void SetupAnimations ()
		{
			ZAnimationInfo info = new ZAnimationInfo ();
			info.numFrames = 1;
			for (int i = 0; i < info.numFrames; i++) {
				if ((int)movement == (int)CowMovement.kCowWalkingLeft)
					info.texture [i] = (Globals.g_world.game).GetTexture (TextureType.kTexture_Cow);
				else if ((int)movement == (int) CowMovement.kCowWalkingRight) info.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Cow2);
                else {
                    int r = Utilities.GetRand( 2);
                    info.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Cow + r);
                }

                info.frameTime[i] = 5;
            }

            info.gapType = GapType.kAnimGapDistance;
            (anim[(int) CowAnimation.n_Walk]).Setup(info);
            for (int i = 0; i < info.numFrames; i++) {
                info.texture[i] = (Globals.g_world.game).GetTexture((TextureType) TextureType.kTexture_Cow2);
                info.frameTime[i] = 0.2f;
            }

            info.gapType = GapType.kAnimGapTime;
            (anim[(int) CowAnimation.n_FallOver]).Setup(info);
        }

        public void SetState(CowState newState)
        {
            state = newState;
        }

        public void SetTimeToNextBlink()
        {
            timeToNextBlink = Utilities.GetRandBetweenP1(0.4f, 1.8f);
        }

        public void SetBlinkTime()
        {
            timeToNextBlink = Utilities.GetRandBetweenP1(0.1f, 0.2f);
        }

        public void AddToScene (CowInfo info)
		{
			stillHasMapObject = true;
			blinking = false;
			this.SetTimeToNextBlink ();
			this.SetupAnimations ();
			renderInFrontOfPlayer = true;
			position = info.position;
			velocity = info.velocity;
			mapObject = (Globals.g_world.game).GetMapObject (info.mapObjectId);
			mapObjectId = info.mapObjectId;
			this.SetState ( CowState.e_Active);
            nowAnim = anim[(int) CowAnimation.n_Walk];
            nowAnim.PlayLooping();
            knockedOver = false;
            noGoZoneId = info.noGoZoneId;
            movement = info.movement;
            //mapObject.SetTexture(nowAnim.GetTexture());
        }

        public void Activate ()
		{
			this.SetState ( CowState.e_Active);
            nowAnim.PlayLooping();
            wobbleSin = 0;
            noseAngle = 0;
        }

        public void Reset ()
		{
			this.SetState ( CowState.e_Inactive);
        }

        public void NewGameStateGetReady()
        {
        }

        public void Blink ()
		{
			if (stillHasMapObject) {
				blinking = true;
				if (((Globals.g_world.game).lBuilder).currentScene == (int)SceneType.kSceneGrass) {
					if (((int)movement == (int)CowMovement.kCowWalkingLeft) || ((int)movement == (int)CowMovement.kCowStandingStillLeft)) {
						mapObject.SetSubTextureId ((int)World.Enum3.kGTGrass_CowLeft2Blink);
					} else {
						mapObject.SetSubTextureId ((int)World.Enum3.kGTGrass_CowRight2Blink);
					}

				} else {
					if (((int)movement == (int)CowMovement.kCowWalkingLeft) || ((int)movement == (int) CowMovement.kCowStandingStillLeft)) {
                        mapObject.SetSubTextureId((int)World.Enum2.kGTMud_CowLeft2Blink);
                    }
                    else {
                        mapObject.SetSubTextureId((int)World.Enum2.kGTMud_CowRight2Blink);
                    }

                }

                this.SetBlinkTime();
            }

        }

        public void BumpedInto(float bumpPower)
        {
            knockedOver = true;
            velocity.y = Utilities.GetMinP1(bumpPower/4.0f, 3.5f);
            if (!blinking) {
                this.Blink();
            }

        }

        public void UpdateWalkWobble ()
		{
			const float kWobbleSpeed = 0.25f;
			const float kWalkSpeed = 0.15f;
			wobbleSin += kWobbleSpeed;
			if (wobbleSin >= Constants.PI_)
				wobbleSin -= (2 * Constants.PI_);

			const float kAngleBigness = 0.6f;
			noseAngle = (Constants.PI_ / 2) + ((float)Math.Cos (wobbleSin) * kAngleBigness);
			if ((int)movement == (int) CowMovement.kCowWalkingRight) noseAngle += Constants.PI_;

            float showAngle = (Constants.PI_ / 2) + ((float)Math.Cos (wobbleSin) * kAngleBigness * 0.05f);
            velocity = Utilities.GetVectorFromAngle(noseAngle);
            velocity.x *= kWalkSpeed;
            velocity.y *= kWalkSpeed;
            rotation = (showAngle) - Constants.HALF_PI;
            mapObject.SetRotation(rotation);
        }

        public void UpdateBlinking ()
		{
			if (timeToNextBlink > 0.0f) {
				timeToNextBlink -= Constants.kFrameRate;
				if (timeToNextBlink <= 0.0f) {
					if (((int)movement == (int)CowMovement.kCowStandingStillLeft) || ((int)movement == (int) CowMovement.kCowWalkingLeft)) {
                        if (blinking) {
                            blinking = false;
                            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                                mapObject.SetSubTextureId((int)World.Enum3.kGTGrass_CowLeft2);
                            }
                            else {
                                mapObject.SetSubTextureId((int)World.Enum2.kGTMud_CowLeft2);
                            }

                            this.SetTimeToNextBlink();
                        }
                        else {
                            this.Blink();
                        }

                    }
                    else {
                        if (blinking) {
                            blinking = false;
                            if (((Globals.g_world.game).lBuilder).currentScene == (int) SceneType.kSceneGrass) {
                                mapObject.SetSubTextureId((int)World.Enum3.kGTGrass_CowRight2);
                            }
                            else {
                                mapObject.SetSubTextureId((int)World.Enum2.kGTMud_CowRight2);
                            }

                            this.SetTimeToNextBlink();
                        }
                        else {
                            this.Blink();
                        }

                    }

                }

            }

        }

        public void NewGameStateShowResults()
        {
            velocity.x *= 0.5f;
        }

        public void UpdateActive ()
		{
			if (knockedOver) {
				const float kHitSlowDown = 0.05f;
				velocity.y -= kHitSlowDown;
				if (velocity.y > 0) {
					position.y += velocity.y;
				}

			} else {
				if (((int)movement != (int)CowMovement.kCowStandingStillRight) && ((int)movement != (int) CowMovement.kCowStandingStillLeft)) {
                    this.UpdateWalkWobble();
                    position.x -= velocity.x;
                    position.y += velocity.y;
                    nowAnim.UpdateWithDistance(Utilities.GetABS(velocity.x));
                }

            }

            this.UpdateBlinking();
            ((Globals.g_world.game).GetNoGoZone(noGoZoneId)).SetMapPosition(Utilities.CGPointMake(position.x, position.y - 5.0f));
            screenPosition = Utilities.GetScreenPositionP1(position, (Globals.g_world.GetGame()).GetScrollPosition());
            if (screenPosition.y < -40) {
                this.SetState( CowState.e_Inactive);
            }

            if (stillHasMapObject) {
                mapObject.SetTexture(nowAnim.GetTexture());
                mapObject.SetPosition(position);
            }

        }

        public void Update()
        {
            switch (state) {
            case CowState.e_Active :
                this.UpdateActive();
                break;
            default :
                break;
            }

        }

    }
}
