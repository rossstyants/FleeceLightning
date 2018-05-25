using System;

namespace Default.Namespace
{
    public class RacingBrain
    {
        public RacingLine racingLine;
        public Player myPig;
        public int targetPoint;
        public float currentSpeed;
        public float boostPower;
        public float boostTimer;
        public CGPoint desiredSpeed;
        public bool inFlock;
        public CGPoint inFlockTargetPos;
        public CGPoint showTargetPos;
        public float elasticity;
        public int elasticityCounter;
        public float differentAccelerationTimer;
        public float differentAcceleration;
        public float baseSpeed;
        public float baseSpeedInFinalThird;
        public float maxSlowdown;
        public float maxCatchup;
        public float closerTargetTimer;
        public float speedOutOfBlocks;
        public CGPoint skidAcceleration;
        public float timeTilCanSkidAgain;
        public CGPoint skidDirection;
        public CGPoint skidDisplayAngle;
        public CGPoint skidTarget;
        public CGPoint dodgingTractorPos;
        public CGPoint dodgingTractorOffset;
        public bool skidding;
        public int skidFrames;
        public int dodgingTractor;
        public struct RacingBrainInfo{
            public Player myPig;
        };
        public float SpeedOutOfBlocks
        {
            get;
            set;
        }

        public RacingLine RacingLine
        {
            get;
            set;
        }

        public CGPoint DesiredSpeed
        {
            get;
            set;
        }

        public float BoostPower
        {
            get;
            set;
        }

        public float BoostTimer
        {
            get;
            set;
        }

        public float CurrentSpeed
        {
            get;
            set;
        }

        public float DifferentAccelerationTimer
        {
            get;
            set;
        }

        public float DifferentAcceleration
        {
            get;
            set;
        }

        public CGPoint SkidDirection
        {
            get;
            set;
        }

        public bool Skidding
        {
            get;
            set;
        }

        public float BaseSpeed
        {
            get;
            set;
        }

		public void SetSkidding(bool inThing) {skidding = inThing;}///@property(readwrite,assign) bool skidding;
public void SetSkidDirection(CGPoint inThing) {skidDirection = inThing;}///@property(readwrite,assign) CGPoint skidDirection;
public void SetRacingLine(RacingLine inThing) {racingLine = inThing;}////@property(readwrite,assign) RacingLine* racingLine;
public void SetDesiredSpeed(CGPoint inThing) {desiredSpeed = inThing;}///@property(readwrite,assign) CGPoint desiredSpeed;
public void SetBoostPower(float inThing) {boostPower = inThing;}///@property(readwrite,assign) float boostPower;
public void SetBoostTimer(float inThing) {boostTimer = inThing;}///@property(readwrite,assign) float boostTimer;
public void SetCurrentSpeed(float inThing) {currentSpeed = inThing;}///@property(readwrite,assign) float currentSpeed;
public void SetDifferentAccelerationTimer(float inThing) {differentAccelerationTimer = inThing;}///@property(readwrite,assign) float differentAccelerationTimer;
public void SetDifferentAcceleration(float inThing) {differentAcceleration = inThing;}///@property(readwrite,assign) float differentAcceleration;
public void SetSpeedOutOfBlocks(float inThing) {speedOutOfBlocks = inThing;}///@property(readwrite,assign) float speedOutOfBlocks;
//public void SetBaseSpeed(float inThing) {baseSpeed = inThing;}///@property(readwrite,assign) float baseSpeed;

        public RacingBrain()
        {
            //if (!base.init()) return null;

            racingLine = new RacingLine();
            baseSpeed = -1.0f;
            maxSlowdown = 0.0f;
            maxCatchup = 0.0f;
            speedOutOfBlocks = 0.073f;
            //return this;
        }
        public void SetStartOfRace(RacingBrainInfo info)
        {
            dodgingTractor = -1;
            timeTilCanSkidAgain = 1.0f;
            skidding = false;
            inFlock = false;
            skidDirection = Utilities.CGPointMake(0, 1);
            closerTargetTimer = 0.0f;
            myPig = info.myPig;
            targetPoint = 0;
            this.SetNextTargetPoint();
            desiredSpeed = Utilities.CGPointMake(0, 0);
            currentSpeed = 5.0f;
            boostPower = 0.0f;
            boostTimer = 0.0f;
            elasticityCounter = 100;
            elasticity = 0.0f;
            if (myPig.playerId == 3) {
                speedOutOfBlocks = 0.066f;
            }
            else if (myPig.playerId == 2) {
                speedOutOfBlocks = 0.07f;
            }
            else {
                speedOutOfBlocks = 0.073f;
            }

            this.SetDifferentAccelerationP1(speedOutOfBlocks, 1.75f);
        }

        public void HitGeneric(float multiplier)
        {
            this.EndSkid();
            this.SetDifferentAccelerationP1(0.03f, 0.7f * multiplier);
        }

        public void HitFlowerBunch()
        {
            this.EndSkid();
            this.SetDifferentAccelerationP1(0.03f, 0.7f);
        }

        public void HitHedge()
        {
            this.EndSkid();
            int realLevelId = LevelBuilder_Ross.levelOrder[(Globals.g_world.game).playingLevel];
            if ((realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass6_5_StrCup_Race5_scruba) || (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass_RoadSheep)) {
                this.SetDifferentAccelerationP1(0.05f, 0.5f);
            }
            else {
                this.SetDifferentAccelerationP1(0.03f, 0.7f);
            }

        }

        public void SetDifferentAccelerationP1(float inAcc, float inTime)
        {
            differentAcceleration = inAcc;
            differentAccelerationTimer = inTime;
        }

        public void SetNextTargetPoint()
        {
            CGPoint targetPosition;
            if (dodgingTractor != -1) {
                targetPosition = dodgingTractorPos;

                #if DEBUG_DRAW_RACING_LINE
                    inFlockTargetPos = targetPosition;
                #endif

            }
            else {
                CGPoint lookPosition = myPig.position;
                lookPosition.y += 120.0f;
                int inWhichFlock = (Globals.g_world.game).IsInFlock(lookPosition);
                if (inWhichFlock == -1) {
                    if (inFlock) {
                        inFlock = false;
                        this.SetTargetPointFromHere(300.0f);
                    }

                    targetPosition = Utilities.CGPointMake(racingLine.GetPoint(targetPoint).x, racingLine.GetPoint(targetPoint).y);
                }
                else {
                    targetPosition = ((Globals.g_world.game).GetFlock(inWhichFlock)).GetNextMarkerForAI(myPig.position);
                    inFlock = true;

                    #if DEBUG_DRAW_RACING_LINE
                        inFlockTargetPos = targetPosition;
                    #endif

                }

            }

            CGPoint directionVector = Utilities.CGPointMake(targetPosition.x - myPig.position.x, targetPosition.y - myPig.position.y);
            if ((targetPosition.x != 0.0f) && (targetPosition.y != 0.0f)) {
                if ((directionVector.x != 0.0f) || (directionVector.y != 0.0f)) {
                    if (myPig.GetActualSpeed().y > 4.0f) {
                        float numFrames = directionVector.y / myPig.GetActualSpeed().y;
                        CGPoint nowPos = myPig.position;
                        CGPoint projectedPosition = Utilities.CGPointMake(nowPos.x + (myPig.GetActualSpeed().x * numFrames), nowPos.y + (myPig.GetActualSpeed().y *
                          numFrames));
                        float xDiff = targetPosition.x - projectedPosition.x;
                        targetPosition.x += xDiff * 0.75f;

                        #if DEBUG_DRAW_RACING_LINE
                            showTargetPos = targetPosition;
                        #endif

                        directionVector = Utilities.CGPointMake(targetPosition.x - myPig.position.x, targetPosition.y - myPig.position.y);
                        CGPoint normal = Utilities.Normalise(directionVector);
                        desiredSpeed.x = normal.x * currentSpeed;
                        desiredSpeed.y = normal.y * currentSpeed;
                    }
                    else {
                        CGPoint normal = Utilities.Normalise(directionVector);
                        desiredSpeed.x = normal.x * currentSpeed;
                        desiredSpeed.y = normal.y * currentSpeed;
                    }

                }

            }
            else {
            }

        }

        public void SetMinAndMaxSpeedP1(float inMin, float inMax)
        {
            Globals.Assert(baseSpeed != -1.0f);
            maxSlowdown = inMin;
            maxCatchup = inMax;
        }

        public void NewTargetPoint()
        {
            CGPoint projectedPosition = myPig.position;
            CGPoint projectedSpeed = myPig.GetActualSpeed();
            for (int i = 0; i < 5; i++) {
                float speedRatio = Utilities.GetRatioP1P2(currentSpeed, 9.0f, 15.0f);
                float speedLagX = Utilities.SetRatioP1P2(speedRatio, 0.03f, 0.05f);
                float speedLagY = Utilities.SetRatioP1P2(speedRatio, 0.05f, 0.85f);
                projectedSpeed.x = projectedSpeed.x + ((desiredSpeed.x - projectedSpeed.x) * speedLagX);
                projectedSpeed.y = projectedSpeed.y + ((desiredSpeed.y - projectedSpeed.y) * speedLagY);
                projectedPosition.x += projectedSpeed.x;
                projectedPosition.y += projectedSpeed.y;
            }

        }

        public void SetTargetPointFromHere(float howFarInFront)
        {
            targetPoint = this.GetTargetPointAt(myPig.position.y + howFarInFront);
            Globals.Assert(targetPoint != -1);
            return;
            bool founOne = false;
            float yDiffToLastPoint = 9999999.0f;
            int closestPoint = this.GetTargetPointAtBackwards(myPig.position.y);
            targetPoint = closestPoint;
            do {
                if (targetPoint < (racingLine.numPoints - 1)) {
                    float yDiffToNextPoint = (float)(racingLine.GetPoint(targetPoint + 1).y) - myPig.position.y;
                    if ((yDiffToNextPoint < 170.0f) && (yDiffToNextPoint > 100.0f)) {
                        founOne = true;
                    }
                    else if ((yDiffToNextPoint >= 170.0f) && (yDiffToNextPoint > yDiffToLastPoint)) {
                        founOne = true;
                    }
                    else {
                        targetPoint++;
                    }

                    yDiffToLastPoint = yDiffToNextPoint;
                }
                else {
                    founOne = true;
                }

            }
            while (!founOne);

        }

        public void UpdateTargetPoint()
        {
            float yDiffToNextPoint;
            float yDistanceInFrontToAimAt;
            if (closerTargetTimer > 0.0f) {
                closerTargetTimer -= Constants.kFrameRate;
                yDistanceInFrontToAimAt = 50.0f;
            }
            else {
                yDistanceInFrontToAimAt = 170.0f;
            }

            if (targetPoint < (racingLine.numPoints - 1)) {
                yDiffToNextPoint = Utilities.GetDistanceP1(Utilities.CGPointMake(racingLine.GetPoint(targetPoint + 1).x, racingLine.GetPoint(targetPoint + 1).y), myPig.
                  position);
                if (yDiffToNextPoint < yDistanceInFrontToAimAt) {
                    targetPoint++;
                }

            }

            this.SetNextTargetPoint();
        }

        public void UpdateCurrentElasticity()
        {

            #if RUN_AND_RECORD_PIG_TIMES
                return;
            #endif

            #if CAMERA_FOLLOW_PIGGY
                return;
            #endif

            const int kNumFramesBeforeRecheckElasticity = 10;
            if (elasticityCounter < kNumFramesBeforeRecheckElasticity) {
                elasticityCounter++;
            }
            else {
                elasticityCounter = 0;
                float yDiff = ((Globals.g_world.game).player).position.y - myPig.position.y;
                if (yDiff > 0.0f) {
                    const float kMinDistanceBehind = 60.0f;
                    const float kMaxDistanceBehind = 600.0f;
                    float boost = Utilities.GetRatioP1P2(yDiff, kMinDistanceBehind, kMaxDistanceBehind);
                    elasticity = boost * maxCatchup;
                }
                else {
                    const float kDistanceOffScreenStartSlowDown = 200.0f;
                    const float kDistanceOffScreenForFullSlowDown = 400.0f;
                    float handicap = Utilities.GetRatioP1P2(-yDiff, Globals.g_world.mapObjectAppearDistance + kDistanceOffScreenStartSlowDown, Globals.g_world.
                      mapObjectAppearDistance + kDistanceOffScreenForFullSlowDown);
                    elasticity = handicap * maxSlowdown;
                }

            }

        }

        public void SetCloserTarget(float howLong)
        {
            {
                closerTargetTimer = howLong;
                float yDiffToPrevPoint;
                if (targetPoint > 0) {
                    do {
                        targetPoint--;
                        yDiffToPrevPoint = (float)(racingLine.GetPoint(targetPoint).y) - myPig.position.y;
                    }
                    while ((targetPoint > 0) && (yDiffToPrevPoint > 10.0f));

                }

            }
        }

        public void UpdateSpeed()
        {
            if (boostTimer > 0.0f) {
                boostTimer -= Constants.kFrameRate;
                if (boostTimer <= 0.0f) {
                    boostPower = 0.0f;
                }

            }

            this.UpdateCurrentElasticity();
            currentSpeed = baseSpeed + elasticity + myPig.GetWhiteStarExtraSpeed() + boostPower;
            currentSpeed *= myPig.GetSpeedMultiplier();
            const float kMinTurnSizeForSpeedReduction = 0.02f;
            const float kMaxTurnSizeForSpeedReduction = 0.08f;
            const float kMaxSpeedReductionForCornering = 0.9f;
            float turnSize = Utilities.GetABS(myPig.moveAngle - myPig.prevMoveAngle);
            if (turnSize > kMinTurnSizeForSpeedReduction) {
                const float kMinCurrentSpeedForSpeedReduction = 8.0f;
                const float kMaxCurrentSpeedForSpeedReduction = 16.0f;
                float currentSpeedMultiplier = Utilities.GetRatioP1P2(myPig.GetDistanceLastFrame(), kMinCurrentSpeedForSpeedReduction,
                  kMaxCurrentSpeedForSpeedReduction);
                float reductionMultiplier = Utilities.GetRatioP1P2(turnSize, kMinTurnSizeForSpeedReduction, kMaxTurnSizeForSpeedReduction);
                currentSpeed -= (currentSpeed * kMaxSpeedReductionForCornering * reductionMultiplier * currentSpeedMultiplier);
            }

        }

        public void SetBaseSpeed(float inSpeed)
        {
            float relativeToPlayer = inSpeed / Constants.PLAYER_MAX_SPEED;
            baseSpeed = inSpeed;
            myPig.SetKFinalSpeedMultiplier(inSpeed);
            myPig.SetWhiteStarSpeedAddition(Constants.PLAYER_WHITE_STAR_SPEED * relativeToPlayer);
            baseSpeedInFinalThird = inSpeed;
        }

        public void SetBaseSpeedInFinalThird(float inSpeed)
        {
            baseSpeedInFinalThird = inSpeed;
        }

        public void EnteredFinalThird()
        {
            float relativeToPlayer = baseSpeedInFinalThird / Constants.PLAYER_MAX_SPEED;
            baseSpeed = baseSpeedInFinalThird;
            myPig.SetKFinalSpeedMultiplier(baseSpeed);
            myPig.SetWhiteStarSpeedAddition(Constants.PLAYER_WHITE_STAR_SPEED * relativeToPlayer);
        }

        public int GetTargetPointAtBackwards(float inY)
        {
            if (targetPoint < 10) return -1;

            int yDistMin = 10000;
            int closestTarget = -1;
            for (int i = 0; i < 50; i++) {
                int yDist = (int) Utilities.GetABS((float)(racingLine.GetPoint(targetPoint - i).y - inY));
                if ((yDist < yDistMin) || (i == 0)) {
                    yDistMin = yDist;
                    closestTarget = targetPoint - i;
                }
                else {
                    return closestTarget;
                }

            }

            return closestTarget;
        }

        int GetTargetPointAheadP1P2(int fromTargetPoint, float inY, int iteration)
        {
            int yDistMin = 100000;
            int closestTarget = -1;
            int whichTargetPoint = fromTargetPoint;
            for (int i = 0; i < 80; i++) {
                int yDist = (int) Utilities.GetABS((float) racingLine.GetPoint(whichTargetPoint).y - inY);
                if (yDist < yDistMin) {
                    yDistMin = yDist;
                    closestTarget = whichTargetPoint;
                }
                else {
                    return closestTarget;
                }

                whichTargetPoint += iteration;
            }

            return closestTarget;
        }

        int GetTargetPointBackP1P2(int fromTargetPoint, float inY, int iteration)
        {
            int yDistMin = 100000;
            int closestTarget = -1;
            int whichTargetPoint = fromTargetPoint;
            for (int i = 0; i < 80; i++) {
                int yDist = (int) Utilities.GetABS((float) racingLine.GetPoint(whichTargetPoint).y - inY);
                if (yDist < yDistMin) {
                    yDistMin = yDist;
                    closestTarget = whichTargetPoint;
                }
                else {
                    return closestTarget;
                }

                whichTargetPoint -= iteration;
            }

            return closestTarget;
        }

        public int GetTargetPointAt(float inY)
        {
            int newTargetPoint;
            if ((float) racingLine.GetPoint(targetPoint).y > inY) {
                newTargetPoint = this.GetTargetPointBackP1P2(targetPoint, inY, 10);
            }
            else {
                newTargetPoint = this.GetTargetPointAheadP1P2(targetPoint, inY, 10);
            }

            if ((float) racingLine.GetPoint(newTargetPoint).y > inY) {
                newTargetPoint = this.GetTargetPointBackP1P2(newTargetPoint, inY, 1);
            }
            else {
                newTargetPoint = this.GetTargetPointAheadP1P2(newTargetPoint, inY, 1);
            }

            return newTargetPoint;
        }

        bool IsThisSkidAGoodIdea()
        {
            CGPoint nowPos = myPig.position;
            CGPoint nowSpeed = skidDirection;
            float prevNumThings = 0.0f;
            float frame = 5.0f;
            for (int i = 0; i < 9; i++) {
                float numThings = (frame * (frame + 1.0f)) * 0.5f;
                float nowNumThings = numThings;
                numThings -= prevNumThings;
                prevNumThings = nowNumThings;
                nowPos.x += (nowSpeed.x * 5.0f);
                nowPos.y += (nowSpeed.y * 5.0f);
                nowPos.x += (numThings * skidAcceleration.x);
                nowPos.y += (numThings * skidAcceleration.y);
                frame += 5.0f;
                int whichTargetPoint = this.GetTargetPointAt(nowPos.y);
                CGPoint nearestPoint = Utilities.CGPointMake((float) racingLine.GetPoint(whichTargetPoint).x, (float) racingLine.GetPoint(whichTargetPoint).y);
                float sqrDistance = Utilities.GetSqrDistanceP1(nowPos, nearestPoint);
                float kMinSqrDistanceForPoint = 2500.0f;
                if (sqrDistance > kMinSqrDistanceForPoint) {
                    return false;
                }

            }

            return true;
        }

        bool CheckStartSkid()
        {
            if (inFlock) {
                return false;
            }

            if (timeTilCanSkidAgain > 0.0f) {
                timeTilCanSkidAgain -= Constants.kFrameRate;
                return false;
            }

            const float kExtrapFrames = 50.0f;
            CGPoint nowSpeed = myPig.GetActualSpeed();
            CGPoint extrapolatedPosition = Utilities.CGPointMake(myPig.position.x + (nowSpeed.x * kExtrapFrames), myPig.position.y + (nowSpeed.y * kExtrapFrames));
            float yDistInFront = extrapolatedPosition.y - myPig.position.y;
            if (yDistInFront < 700.0f) {
                return false;
            }

            int whichTargetPoint = this.GetTargetPointAtBackwards(myPig.position.y);
            if (whichTargetPoint == -1) {
                return false;
            }

            CGPoint nowTargetPos = Utilities.CGPointMake((float) racingLine.GetPoint(whichTargetPoint).x, (float) racingLine.GetPoint(whichTargetPoint).y);
            float distSqr = Utilities.GetSqrDistanceP1(myPig.position, nowTargetPos);
            const float kMinSqrDistForStart = 700.0f;
            if (distSqr > kMinSqrDistForStart) {
                return false;
            }

            CGPoint targetDirection = Utilities.CGPointMake((float) racingLine.GetPoint(whichTargetPoint + 1).x - nowTargetPos.x, (float) racingLine.GetPoint(
              whichTargetPoint + 1).y - nowTargetPos.y);
            float targetAngle = Utilities.GetAngleFromXYNewP1(targetDirection.x, targetDirection.y);
            float playerAngleNow = myPig.moveAngle;
            if (Utilities.GetABS(targetAngle - playerAngleNow) > 0.18f) {
                return false;
            }

            whichTargetPoint = this.GetTargetPointAt(extrapolatedPosition.y);
            if (whichTargetPoint == -1) {
                return false;
            }

            CGPoint diff = Utilities.CGPointMake((float) racingLine.GetPoint(whichTargetPoint).x - extrapolatedPosition.x, (float) racingLine.GetPoint(
              whichTargetPoint).y - extrapolatedPosition.y);
            skidDirection = Utilities.CGPointMake(nowSpeed.x, nowSpeed.y);
            float numAccelerationAdditions = (kExtrapFrames * (kExtrapFrames + 1.0f)) * 0.5f;
            skidAcceleration = Utilities.CGPointMake(diff.x / numAccelerationAdditions, diff.y / numAccelerationAdditions);
            float xAtEnd = nowSpeed.x + (skidAcceleration.x * kExtrapFrames);
            float yAtEnd = nowSpeed.y + (skidAcceleration.y * kExtrapFrames);
            float angleAtEnd = Utilities.GetAngleFromXYNewP1(xAtEnd, yAtEnd);
            CGPoint endPointDir = Utilities.CGPointMake(((float) racingLine.GetPoint(whichTargetPoint).x - (float) racingLine.GetPoint(whichTargetPoint - 1).x), ((
              float) racingLine.GetPoint(whichTargetPoint).y - (float) racingLine.GetPoint(whichTargetPoint - 1).y));
            float angleAtEndPoint = Utilities.GetAngleFromXYNewP1(endPointDir.x, endPointDir.y);
            if (Utilities.GetABS(angleAtEnd - angleAtEndPoint) > 0.18f) {
                return false;
            }

            float yDisplay;
            if (skidAcceleration.y >= 0.0f) {
                yDisplay = skidAcceleration.y;
            }
            else {
                yDisplay = 0.0f;
            }

            skidTarget = Utilities.CGPointMake((float) racingLine.GetPoint(whichTargetPoint).x, (float) racingLine.GetPoint(whichTargetPoint).y);
            if (!this.IsThisSkidAGoodIdea()) {
                return false;
            }

            skidDisplayAngle = Utilities.CGPointMake(skidAcceleration.x, yDisplay);
            skidding = true;
            skidFrames = (int) kExtrapFrames;
            return true;
        }

        public void EndSkid()
        {
            if (skidding) {
                skidding = false;
                this.SetTargetPointFromHere(140.0f);
                timeTilCanSkidAgain = 0.5f;
            }

        }

        public void UpdateSkidding()
        {
            float yDiff = myPig.position.y - skidTarget.y;
            skidFrames--;
            if ((skidFrames <= 0) || (yDiff > 15.0f)) {
                this.EndSkid();
                this.SetDifferentAccelerationP1(0.03f, 0.7f);
            }

        }

        public void UpdatePlayerSpeed()
        {
            float speedRatio = Utilities.GetRatioP1P2(currentSpeed, 5.0f, 20.0f);
            float speedLagX = Utilities.SetRatioP1P2(speedRatio, 0.08f, 0.2f);
            float speedLagY = Utilities.SetRatioP1P2(speedRatio, 0.05f, 0.85f);
            if (differentAccelerationTimer > 0.0f) {
                speedLagX = 0.03f;
                speedLagY = differentAcceleration;
                differentAccelerationTimer -= Constants.kFrameRate;
            }

            CGPoint newSpeed;
            newSpeed.x = myPig.GetSpeed().x + ((desiredSpeed.x - myPig.GetSpeed().x) * speedLagX);
            float maxXSpeed = 10.0f;
            if (newSpeed.x > maxXSpeed) newSpeed.x = maxXSpeed;
            else if (newSpeed.x < -maxXSpeed) newSpeed.x = -maxXSpeed;

            newSpeed.y = myPig.GetSpeed().y + ((desiredSpeed.y - myPig.GetSpeed().y) * speedLagY);
            if (skidding) {
                myPig.SetSpeedFromRacingBrain(skidDirection);
                skidDirection.x += skidAcceleration.x;
                skidDirection.y += skidAcceleration.y;
            }
            else {
                myPig.SetSpeedFromRacingBrain(newSpeed);
            }

        }

        public CGPoint GetSpeedForAngleDisplay()
        {
            if (skidding) {
                return skidDisplayAngle;
            }
            else {
                return desiredSpeed;
            }

        }

        public void UpdateGoRoundTractors_NotDodging()
        {
            CGPoint predictedPosition = myPig.position;
            int maxFramesAhead = 10;
            const float kFramesAhead = 2.0f;
            predictedPosition.x += (myPig.GetActualSpeed().x * kFramesAhead);
            predictedPosition.y += (myPig.GetActualSpeed().y * kFramesAhead);
            int trac = 0;
            for (int frameAhead = 2; frameAhead <= maxFramesAhead; frameAhead++) {
                trac = (Globals.g_world.game).IsInTractor(predictedPosition);
                if (trac != -1) {
                    break;
                }

                predictedPosition.x += myPig.GetActualSpeed().x;
                predictedPosition.y += myPig.GetActualSpeed().y;
            }

            if (trac != -1) {
                dodgingTractor = trac;
                dodgingTractorPos = ((Globals.g_world.game).GetTractor(trac)).position;
                dodgingTractorOffset.x = 130.0f;
                dodgingTractorOffset.y = -50.0f;
                if (((Globals.g_world.game).GetTractor(trac)).speed > 0.0f) {
                    bool goAheadOfIt = false;
                    if (myPig.position.x > (dodgingTractorPos.x + 85.0f)) {
                        goAheadOfIt = true;
                        dodgingTractorOffset.x += 40.0f;
                        dodgingTractorOffset.y += 40.0f;
                    }

                    if (!goAheadOfIt) dodgingTractorOffset.x = -dodgingTractorOffset.x;

                }

                dodgingTractorPos.x += dodgingTractorOffset.x;
                dodgingTractorPos.y += dodgingTractorOffset.y;
            }

        }

        public void UpdateGoRoundTractors_Dodging()
        {
            dodgingTractorPos = ((Globals.g_world.game).GetTractor(dodgingTractor)).position;
            dodgingTractorPos.x += dodgingTractorOffset.x;
            dodgingTractorPos.y += dodgingTractorOffset.y;
            if (dodgingTractorPos.x < 0.0f) {
                dodgingTractorPos.x = 0.0f;
            }

            float distSqr = Utilities.GetSqrDistanceP1(myPig.position, dodgingTractorPos);
            if (distSqr < 6400.0f) {
                dodgingTractor = -1;
                this.SetTargetPointFromHere(220.0f);
            }

        }

        public void UpdateGoRoundTractors()
        {
            int realLevelId = LevelBuilder_Ross.levelOrder[(Globals.g_world.game).playingLevel];
            if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud_Harvest) {
                if (dodgingTractor == -1) {
                    this.UpdateGoRoundTractors_NotDodging();
                }
                else {
                    this.UpdateGoRoundTractors_Dodging();
                }

            }

        }

        public void Update()
        {
            this.UpdateSpeed();

            #if HARVEST_TEST
                this.UpdateGoRoundTractors();
            #endif

            if (!skidding) {
                if (this.CheckStartSkid()) {
                    this.UpdateSkidding();
                }
                else {
                    this.UpdateTargetPoint();
                }

            }
            else {
                this.UpdateSkidding();
            }

            this.UpdatePlayerSpeed();
        }

        public void Render()
        {
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_Debug));
            racingLine.Render();
            racingLine.RenderTarget(targetPoint);
            CGPoint screenPosition = (Globals.g_world.game).GetScreenPosition(showTargetPos);
            (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(screenPosition, 2.3f, 2.3f, 1);
            if (dodgingTractor != -1) {
                CGPoint screenPosition2 = (Globals.g_world.game).GetScreenPosition(inFlockTargetPos);
                if ((Globals.g_world.game).IsOnScreen(screenPosition2)) {
                    (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(screenPosition2, 4.0f, 4.0f, 1);
                }

            }

            if (inFlock) {
                CGPoint screenPosition3 = (Globals.g_world.game).GetScreenPosition(inFlockTargetPos);
                if ((Globals.g_world.game).IsOnScreen(screenPosition3)) {
                    (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(screenPosition3, 4.0f, 4.0f, 1);
                }

            }

            if (skidding) {
                CGPoint screenPosition4 = (Globals.g_world.game).GetScreenPosition(skidTarget);
                if ((Globals.g_world.game).IsOnScreen(screenPosition4)) {
                    (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(screenPosition4, 4.0f, 4.0f, 0);
                }

            }

            (DrawManager.Instance()).Flush();
        }

    }
}
