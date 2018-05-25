using System;

namespace Default.Namespace
{
    public enum  TractorMovementType {
        kTMT_Oscillate,
        kTMT_CrossingScreen
    }
    public enum  TractorMovement {
        kTractorGoingRight,
        kTractorStoppingRight,
        kTractorGoingLeft,
        kTractorStoppingLeft
    }
    public class Tractor
    {
        public float speed;
        public CGPoint position;
        public int wheelsMapObjectId1;
        public int wheelsMapObjectId2;
        public int mapObjectId;
        public int[] noGoZoneId = new int[2];
        public float[] zoneOffset = new float[2];
        public int currentWheelAnim;
        public TractorMovement movement;
        public TractorMovementType movementType;
        public float stateTimer;
        public int tractorType;
        public float xStartPosition;
        public int framesToCrossMap;
        public float animationTimer;
        public bool swappedBackward;
        public bool firstInGameUpdate;
        public bool mapObjectRemoved;
        const float kMapEdgeBufferTractor = 240.0f;
        const float kTimeStopped = 0.25f;
        const float kTimeMoving = 1.0f;
        const float kMaxSpeed = 3.0f;
        const float kTractorAcc = 0.5f;
        public class TractorInfo{
            public CGPoint position;
            public int mapObjectId;
            public int wheelsMapObjectId1;
            public int wheelsMapObjectId2;
            public int[] noGoZoneId = new int [2];
            public int type;
            public TractorMovementType inMovementType;
        };
        public CGPoint Position
        {
            get;
            set;
        }

        public int MapObjectId
        {
            get;
            set;
        }

        public bool MapObjectRemoved
        {
            get;
            set;
        }

        public bool SwappedBackward
        {
            get;
            set;
        }

        public TractorMovement Movement
        {
            get;
            set;
        }

        public float Speed
        {
            get;
            set;
        }

public void SetMapObjectId(int inThing) {mapObjectId = inThing;}///@property(readwrite,assign) int mapObjectId;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
public void SetMapObjectRemoved(bool inThing) {mapObjectRemoved = inThing;}///@property(readwrite,assign) bool mapObjectRemoved;
public void SetSwappedBackward(bool inThing) {swappedBackward = inThing;}///@property(readwrite,assign) bool swappedBackward;
public void SetMovement(TractorMovement inThing) {movement = inThing;}///@property(readwrite,assign) TractorMovement movement;
public void SetSpeed(float inThing) {speed = inThing;}///@property(readwrite,assign) float speed;

        public void IncrementUpdateToStartPosition()
        {
            float gameTimerToUse = (Globals.g_world.game).raceTimer;
            const int kTimePerCycle1000 = 2500;
            int timerInt1000 = (int) (gameTimerToUse * 1000.0f);
            timerInt1000 += (int) (position.y * 1.8f);
            int timerOffset1000 = timerInt1000 % kTimePerCycle1000;
            float timerOffset = ((float) timerOffset1000) / 1000.0f;
            while (timerOffset > 0.0f) {
                this.UpdateMovement();
                if (tractorType == (int) ObjectType.kOT_Tractor) {
                    position.x += speed;
                }
                else {
                    position.x -= speed;
                }

                timerOffset -= Constants.kFrameRate;
            };

        }

        public void AddToScene(TractorInfo info)
        {
            movementType = info.inMovementType;
            mapObjectRemoved = false;
            position = info.position;
            noGoZoneId[0] = info.noGoZoneId[0];
            noGoZoneId[1] = info.noGoZoneId[1];
            mapObjectId = info.mapObjectId;
            wheelsMapObjectId1 = info.wheelsMapObjectId1;
            wheelsMapObjectId2 = info.wheelsMapObjectId2;
            swappedBackward = false;
            speed = kMaxSpeed;
            movement = TractorMovement.kTractorGoingRight;
            stateTimer = (kTimeMoving * 0.5f);
            firstInGameUpdate = true;
            tractorType = info.type;
            currentWheelAnim = 0;
            animationTimer = 0.0f;
            xStartPosition = position.x;
            if (tractorType == (int) ObjectType.kOT_CrossingTractor) {
                speed = -3.0f;
                framesToCrossMap = (int) ((Constants.MAP_WIDTH + kMapEdgeBufferTractor) / -3.0f);
            }
            else if (tractorType == (int) ObjectType.kOT_CrossingLandRover) {
                speed = 3.0f;
                framesToCrossMap = (int) ((Constants.MAP_WIDTH + kMapEdgeBufferTractor) / -3.0f);
            }

            if (position.y < 550.0f) {
                this.IncrementUpdateToStartPosition();
                firstInGameUpdate = false;
                ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(position);
            }

            if ((tractorType == (int) ObjectType.kOT_CrossingTractor) || (tractorType == (int) ObjectType.kOT_Tractor)) {
                zoneOffset[0] = -47.0f;
                zoneOffset[1] = 40.0f;
            }
            else {
                zoneOffset[0] = -40.0f;
                zoneOffset[1] = 32.0f;
            }

        }

        public void BurstBale()
        {
        }

        float CalculateXPosition(float raceTime)
        {
            int numFrames = (int) (raceTime / Constants.kFrameRate);
            numFrames = numFrames % framesToCrossMap;
            float newX = xStartPosition + ((float) numFrames * speed);
            if (newX < (-kMapEdgeBufferTractor / 2.0f)) {
                newX += (Constants.MAP_WIDTH + kMapEdgeBufferTractor);
            }
            else if (newX > (Constants.MAP_WIDTH + (kMapEdgeBufferTractor / 2.0f))) {
                newX -= (Constants.MAP_WIDTH + kMapEdgeBufferTractor);
            }

            return newX;
        }

        public void UpdateMovement_CrossingScreen()
        {
            position.x = this.CalculateXPosition((Globals.g_world.game).raceTimer);
        }

        public void UpdateMovement_Oscillate()
        {
            if (movement == TractorMovement.kTractorGoingRight) {
                speed = Utilities.ApproachP1P2(speed, kMaxSpeed, kTractorAcc);
                if (stateTimer >= kTimeMoving) {
                    stateTimer = 0.0f;
                    movement = TractorMovement.kTractorStoppingRight;
                }

            }
            else if (movement == TractorMovement.kTractorStoppingRight) {
                speed = Utilities.ApproachP1P2(speed, 0.0f, kTractorAcc);
                if (stateTimer >= kTimeStopped) {
                    stateTimer = 0.0f;
                    movement = TractorMovement.kTractorGoingLeft;
                }

            }
            else if (movement == TractorMovement.kTractorGoingLeft) {
                speed = Utilities.ApproachP1P2(speed, -kMaxSpeed, kTractorAcc);
                if (stateTimer >= kTimeMoving) {
                    stateTimer = 0.0f;
                    movement = TractorMovement.kTractorStoppingLeft;
                }

            }
            else if (movement == TractorMovement.kTractorStoppingLeft) {
                speed = Utilities.ApproachP1P2(speed, 0.0f, kTractorAcc);
                if (stateTimer >= kTimeStopped) {
                    stateTimer	 = 0.0f;
                    movement = TractorMovement.kTractorGoingRight;
                }

            }

        }

        public void UpdateMovement()
        {
            stateTimer += Constants.kFrameRate;
            switch (movementType) {
            case TractorMovementType.kTMT_Oscillate :
                this.UpdateMovement_Oscillate();
                break;
            case TractorMovementType.kTMT_CrossingScreen :
                this.UpdateMovement_CrossingScreen();
                break;
            default :
                Globals.Assert(false);
                break;
            }

        }

        public void UpdateWheelAnimation()
        {
            float kWheelSpeed;
            if (tractorType == (int) ObjectType.kOT_Tractor) kWheelSpeed = 20.0f;
            else {
                kWheelSpeed = 14.0f;
            }

            animationTimer += speed;
            bool changedAnim = false;
            if (animationTimer >= kWheelSpeed) {
                animationTimer -= kWheelSpeed;
                currentWheelAnim = Utilities.IncrementLoopP1P2(currentWheelAnim, 0, 1);
                changedAnim = true;
            }
            else if (animationTimer < 0.0f) {
                animationTimer += kWheelSpeed;
                currentWheelAnim = Utilities.DecrementLoopP1P2(currentWheelAnim, 0, 1);
                changedAnim = true;
            }

            if (changedAnim) {
                if (currentWheelAnim == 1) {
                }

            }

        }

        public bool UpdateTractor(CGPoint playerPosition)
        {
            if (firstInGameUpdate) {
                this.IncrementUpdateToStartPosition();
                firstInGameUpdate = false;
            }

            this.UpdateMovement();
            this.UpdateWheelAnimation();
            if (tractorType == (int) ObjectType.kOT_BlueTractor) position.x -= speed;
            else {
                position.x += speed;
            }

            CGPoint bodyPosition = position;
            if (currentWheelAnim == 0) {
                bodyPosition.y -= 2.0f;
            }

            ((Globals.g_world.game).GetMapObject(mapObjectId)).SetPosition(bodyPosition);
            CGPoint wheelsPosition1;
            CGPoint wheelsPosition2;
            if (currentWheelAnim == 0) {
                if ((tractorType == (int) ObjectType.kOT_Tractor) || (tractorType == (int) ObjectType.kOT_CrossingTractor)) {
                    wheelsPosition1 = Utilities.CGPointMake(bodyPosition.x + 45.0f, bodyPosition.y + 3.0f);
                    wheelsPosition2 = Utilities.CGPointMake(bodyPosition.x - 66.0f, bodyPosition.y + 28.0f);
                }
                else {
                    if (Globals.deviceIPad) {
                        wheelsPosition1 = Utilities.CGPointMake(bodyPosition.x + 43.0f, bodyPosition.y + 25.0f);
                        wheelsPosition2 = Utilities.CGPointMake(bodyPosition.x - 45.0f, bodyPosition.y + 23.0f);
                    }
                    else {
                        wheelsPosition1 = Utilities.CGPointMake(bodyPosition.x + 34.0f, bodyPosition.y + 23.0f);
                        wheelsPosition2 = Utilities.CGPointMake(bodyPosition.x - 50.0f, bodyPosition.y + 23.0f);
                    }

                }

            }
            else {
                wheelsPosition1 = Utilities.CGPointMake(1300.0f, position.y);
                wheelsPosition2 = Utilities.CGPointMake(1300.0f, position.y);
            }

            ((Globals.g_world.game).GetMapObject(wheelsMapObjectId1)).SetPosition(wheelsPosition1);
            ((Globals.g_world.game).GetMapObject(wheelsMapObjectId2)).SetPosition(wheelsPosition2);
            ((Globals.g_world.game).GetNoGoZone(noGoZoneId[0])).SetMapPosition(Utilities.CGPointMake(position.x + zoneOffset[0], position.y + 2.0f));
            ((Globals.g_world.game).GetNoGoZone(noGoZoneId[1])).SetMapPosition(Utilities.CGPointMake(position.x + zoneOffset[1], position.y + 2.0f));
            return false;
        }

    }
}
