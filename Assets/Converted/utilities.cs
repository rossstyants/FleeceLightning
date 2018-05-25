using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Default.Namespace
{	
    public class Utilities
    {
        static float[] preCalculatedCos = new float[4096];
        public const float kYShiftForZ = 0.2f;
        public struct CollisionResults{
            public CGPoint sphereVelocity1, sphereVelocity2;
        };
        //extern float[] preCalculatedCos = new float[4096];
        public struct CollisionData{
            public float sphereRadius1, sphereRadius2;
            public CGPoint sphereVelocity1, sphereVelocity2;
            public CGPoint spherePosition1, spherePosition2;
            public float sphereMass1, sphereMass2;
        };

		public static CGSize CGSizeMake (float width, float height)
		{
			CGSize outR = new CGSize();

			outR.Height = height;
			outR.Width = width;

			return outR;
		}


		public static CGRect CGRectMake (float inX, float inY, float width, float height)
		{
			CGRect outR = new CGRect();

			outR.Origin.x = inX;
			outR.Origin.y = inY;
			outR.Size.Height = height;
			outR.Size.Width = width;

			return outR;
		}
 
		public static CGPoint CGPointMake(float inX, float inY)
		{
			CGPoint outT;
			outT.x = inX;
			outT.y = inY;
			return outT;
		}

		
		public static void Initialise()
        {
            const int kNumDiscreteBlobs = 4096;
            float thing = (2.0f * Constants.PI_) / ((float)(kNumDiscreteBlobs - 1));
            float cosPos = -Constants.PI_;
            for (int i = 0; i < kNumDiscreteBlobs; i++) {
                preCalculatedCos[i] = (float)Math.Cos(cosPos);
                preCalculatedCos[i] += 1.0f;
                preCalculatedCos[i] *= 0.5f;
                cosPos += thing;
            }

        }

        public static int EncryptInt(float inFloat)
        {
/*            int v = (int) (inFloat * 101238.0f);
            int r = v;
            int s = sizeof (int) * Constants.CHAR_BIT - 1;
            for (v >>= 1; v; v >>= 1) {
                r <<= 1;
                r |= v & 1;
                s--;
            }

            r <<= s;
            return r;*/

			return 0;
        }

        public static float DecryptInt(int v)
        {
  /*          int r = v;
            int s = sizeof (v) * CHAR_BIT - 1;
            for (v >>= 1; v; v >>= 1) {
                r <<= 1;
                r |= v & 1;
                s--;
            }

            r <<= s;
            float outF = (float) r;
            return (outF / 101238.0f);*/

		return 0;

        }

        public static void WriteDictionaryToFileP1(Dictionary<string,int> dict, string inName)
        {
/*            NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            if (!documentsDirectory) {
            }

            string appFile = documentsDirectory.StringByAppendingPathComponent(inName);
            dict.WriteToFileAtomically(appFile, true);*/

			//return null;
        }

        public static Dictionary<string,int> GetDictionary(string inName)
        {
  /*          NSArray paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, true);
            string documentsDirectory = paths.ObjectAtIndex(0);
            string name = inName;
            NSDictionary dict;
            string appFile = documentsDirectory.StringByAppendingPathComponent(name);
            dict = new NSDictionary(appFile);
            return dict;*/

			return null;		
		}

        public static Dictionary<string,int> GetDictionaryFromResources(string inName)
        {
  /*          string resourcesPath = ((NSBundle.MainBundle()).ResourcePath()).StringByAppendingPathComponent(inName);
            NSDictionary dict = new NSDictionary(resourcesPath);
            return dict;*/

			return null;
        }

        public static float GetMaxP1(float val1, float val2)
        {
            if (val2 > val1) return val2;
            else return val1;

        }

        public static float GetMinP1(float val1, float val2)
        {
            if (val2 > val1) return val1;
            else return val2;

        }

        public static CollisionResults GetSphereCollisionResults(CollisionData inData)
        {
            float dX, dY, R, M;
            float FX, FY, SS, TT;
            CGPoint newVel;
            float weight1 = inData.sphereMass1;
            float weight2 = inData.sphereMass2;
            dX = inData.spherePosition1.x - inData.spherePosition2.x;
            dY = inData.spherePosition1.y - inData.spherePosition2.y;
            R = inData.sphereRadius1 + inData.sphereRadius2;
            M = weight1 + weight2;
            FX = weight2 * inData.sphereVelocity2.x + 2 * weight1 * inData.sphereVelocity1.x - weight1 * inData.sphereVelocity2.x;
            FY = weight2 * inData.sphereVelocity2.y + 2 * weight1 * inData.sphereVelocity1.y - weight1 * inData.sphereVelocity2.y;
            SS = (dX * FX + dY * FY) / (R * M);
            TT = (inData.sphereVelocity2.y * dX - inData.sphereVelocity2.x * dY) / R;
            newVel.x = (dX * SS - dY * TT) / R;
            newVel.y = (dY * SS + dX * TT) / R;
            FX = weight1 * inData.sphereVelocity1.x + 2 * weight2 * inData.sphereVelocity2.x - weight2 * inData.sphereVelocity1.x;
            FY = weight1 * inData.sphereVelocity1.y + 2 * weight2 * inData.sphereVelocity2.y - weight2 * inData.sphereVelocity1.y;
            SS = -(dX*FX+dY*FY) / (R * M);
            TT = -(inData.sphereVelocity1.y*dX-inData.sphereVelocity1.x*dY) / R;
            CollisionResults results;
            results.sphereVelocity1.x = ((-dX * SS + dY * TT) / R);
            results.sphereVelocity1.y = ((-dY * SS - dX * TT) / R);
            results.sphereVelocity2 = newVel;
            return results;
        }

        public static CollisionResults GetSphereCollisionResultsWithMass(CollisionData inData)
        {
            float dX, dY, R, M;
            float FX, FY, SS, TT;
            CGPoint newVel;
            dX = inData.spherePosition1.x - inData.spherePosition2.x;
            dY = inData.spherePosition1.y - inData.spherePosition2.y;
            R = inData.sphereRadius1 + inData.sphereRadius2;
            M = inData.sphereMass1 + inData.sphereMass2;
            FX = inData.sphereMass1 * inData.sphereVelocity2.x + 2 * inData.sphereMass2 * inData.sphereVelocity1.x - inData.sphereMass1 * inData.
              sphereVelocity2.x;
            FY = inData.sphereMass1 * inData.sphereVelocity2.y + 2 * inData.sphereMass2 * inData.sphereVelocity1.y - inData.sphereMass1 * inData.
              sphereVelocity2.y;
            SS = (dX * FX + dY * FY) / (R * M);
            TT = (inData.sphereVelocity2.y * dX - inData.sphereVelocity2.x * dY) / R;
            newVel.x = (dX * SS - dY * TT) / R;
            newVel.y = (dY * SS + dX * TT) / R;
            FX = inData.sphereMass2 * inData.sphereVelocity1.x + 2 * inData.sphereMass1 * inData.sphereVelocity2.x - inData.sphereMass2 * inData.
              sphereVelocity1.x;
            FY = inData.sphereMass2 * inData.sphereVelocity1.y + 2 * inData.sphereMass1 * inData.sphereVelocity2.y - inData.sphereMass2 * inData.
              sphereVelocity1.y;
            SS = -(dX*FX+dY*FY) / (R * M);
            TT = -(inData.sphereVelocity1.y*dX-inData.sphereVelocity1.x*dY) / R;
            CollisionResults results;
            results.sphereVelocity1.x = ((-dX * SS + dY * TT) / R);
            results.sphereVelocity1.y = ((-dY * SS - dX * TT) / R);
            results.sphereVelocity2 = newVel;
            return results;
        }

        public static CGRect GetScreenRectangle()
        {

            #if PLAY_HORIZONTAL
                return Utilities.CGRectMake(0, 0, Globals.g_world.screenWidth, Globals.g_world.screenHeight);
            #else
                return Utilities.CGRectMake(0, 0, Globals.g_world.screenWidth, Globals.g_world.screenHeight);
            #endif

            #if PLAY_HORIZONTAL
                return Utilities.CGRectMake(0, 0, 480, 320);
            #else
                return Utilities.CGRectMake(0, 0, 320, 480);
            #endif

        }

        public static CGPoint GetScreenCentre()
        {

            #if PLAY_HORIZONTAL
                return Utilities.CGPointMake(240, 160);
            #else
                return Utilities.CGPointMake(160, 240);
            #endif

        }

        public static bool IsWithinRectangleP1P2P3(CGPoint inPoint, CGPoint rectCentre, float width, float height)
        {
            return ((inPoint.x < (rectCentre.x + (width / 2))) && (inPoint.x > (rectCentre.x - (width / 2))) && (inPoint.y < (rectCentre.y + (height / 2))) && (
              inPoint.y > (rectCentre.y - (height / 2))));
        }

        public static CGPoint GetVectorBetweenP1(CGPoint point1, CGPoint point2)
        {
            CGPoint difference = Utilities.CGPointMake(point2.x - point1.x, point2.y - point1.y);
            return difference;
        }

        public static CGPoint GetVectorBetweenNormalisedP1(CGPoint point1, CGPoint point2)
        {
            CGPoint difference = Utilities.CGPointMake(point2.x - point1.x, point2.y - point1.y);
            return Utilities.Normalise(difference);
        }

        public static CGPoint GetPositionBetweenP1P2(float ratio, CGPoint point1, CGPoint point2)
        {
            CGPoint difference = Utilities.CGPointMake(point2.x - point1.x, point2.y - point1.y);
            difference.x *= ratio;
            difference.y *= ratio;
            CGPoint outPoint = Utilities.CGPointMake(point1.x + difference.x, point1.y + difference.y);
            return outPoint;
        }
        public static Constants.RossColour GetColourBetweenP1P2(float ratio, Constants.RossColour col1, Constants.RossColour col2)
        {
            Constants.RossColour difference = new Constants.RossColour(col2.cRed - col1.cRed, col2.cGreen - col1.cGreen,col2.cBlue - col1.cBlue);
            difference.cRed *= ratio;
            difference.cGreen *= ratio;
            difference.cBlue *= ratio;
            Constants.RossColour outCol =  new Constants.RossColour(col1.cRed + difference.cRed, col1.cGreen + difference.cGreen,col1.cBlue + difference.cBlue);
            return outCol;
        }

        public static float GetAngleDiffP1(float inVal1, float inVal2)
        {
            if (inVal1 < 0.0f) {
                inVal1 += Constants.TWO_PI;
            }

            if (inVal1 > Constants.TWO_PI) {
                inVal1 -= Constants.TWO_PI;
            }

            if (inVal2 < 0.0f) {
                inVal2 += Constants.TWO_PI;
            }

            if (inVal2 > Constants.TWO_PI) {
                inVal2 -= Constants.TWO_PI;
            }

            float diff1 = Utilities.GetABS((inVal1 - inVal2));
            inVal1 -= Constants.PI_;
            if (inVal1 < 0.0f) {
                inVal1 += Constants.TWO_PI;
            }

            float diff2 = Utilities.GetABS((inVal1 - inVal2));
            return GetMinP1(diff1, diff2);
        }

        public static float QuickCos(float inVal)
        {
            Globals.Assert(inVal >= 0.0f);
            Globals.Assert(inVal <= Constants.TWO_PI);
            float ratio = (Constants.TWO_PI - inVal) / Constants.TWO_PI;
            ratio *= 4095.999f;
			
	//		if ((int)ratio == 4096)
	//		{
	//			int ross = 0;
	//		}
			
            return preCalculatedCos[(int) ratio];
        }

        public static float GetCosInterpolationP1P2(float inVal, float inMin, float inMax)
        {
            if (inVal < inMin) inVal = inMin;

            if (inVal > inMax) inVal = inMax;

            float ratio = (inMax - inVal) / (inMax - inMin);
            ratio *= 4095.999f;
			
//			if ((int)ratio == 4096)
			//{
			//	int ross = 0;
			//}
			
	//		Debug.Log("ratio" + ratio);
			
            return preCalculatedCos[(int) ratio];
        }

        public static float GetCosInterpolationSlowP1P2(float inVal, float inMin, float inMax)
        {
            const float kPi = Constants.PI_;
            if (inVal < inMin) inVal = inMin;

            if (inVal > inMax) inVal = inMax;

            float ratio = (inMax - inVal) / (inMax - inMin);
            float cosRatio = -kPi + (ratio * 2.0f * kPi);
            float outVal = (float)Math.Cos(cosRatio);
            outVal += 1.0f;
            outVal /= 2.0f;
            return outVal;
        }

        public static float GetCosInterpolationQuarterP1P2(float inVal, float inMin, float inMax)
        {
            if (inVal < inMin) inVal = inMin;

            if (inVal > inMax) inVal = inMax;

            const float kQuarterThing = 0.147445394f;
            float ratio = 1.0f - ((inMax - inVal) / (inMax - inMin));
            float cosRatio = Constants.PI_ + (ratio * (Constants.PI_ / 4.0f));
            float outVal = (float)Math.Cos(cosRatio);
            outVal += 1.0f;
            outVal /= 2.0f;
            float whatTheHeckAmIDoing = outVal / kQuarterThing;
            return whatTheHeckAmIDoing;
        }

        public static float GetCosInterpolationHalfP1P2(float inVal, float inMin, float inMax)
        {
            const float kPi = Constants.PI_;
            if (inVal < inMin) inVal = inMin;

            if (inVal > inMax) inVal = inMax;

            float ratio = (inMax - inVal) / (inMax - inMin);
            float cosRatio = (ratio * kPi);
            float outVal = (float)Math.Cos(cosRatio);
            outVal += 1.0f;
            outVal /= 2.0f;
            return outVal;
        }

        public static float GetScaleFromHeight(float inZ)
        {
            return (1.0f) + (inZ * 0.004f);
        }

        public static float GetYOffsetFromHeight(float inZ)
        {
            return (-inZ * Utilities.kYShiftForZ);
        }

        public static float GetAngleFromXYNewP1(float inX, float inY)
        {
            float angle = Utilities.GetABS(inX) / Utilities.GetABS(inY);
            float outAngle = (float)Math.Atan(angle);
            if (inX > 0.0f) {
                if (inY > 0.0f) {
                    outAngle = Constants.PI_ - outAngle;
                }

            }
            else {
                if (inY > 0.0f) {
                    outAngle = Constants.PI_ + outAngle;
                }
                else {
                    outAngle = (2.0f * Constants.PI_) - outAngle;
                }

            }

            return outAngle;
        }

        public static float GetAngleFromXYP1(float inX, float inY)
        {
            const float kPi = Constants.PI_;
            float angle = inY / inX;
            float outAngle = (float)Math.Atan(angle);
            if (outAngle < 0.0f) outAngle += (kPi);

            outAngle += (kPi / 2.0f);
            return outAngle;
        }

        public static CGPoint GetScreenPositionP1(CGPoint mapPosition, CGPoint inScrollPosition)
        {
            CGPoint outScreenPosition;
            outScreenPosition.x = mapPosition.x - inScrollPosition.x;
            outScreenPosition.y = (mapPosition.y - inScrollPosition.y);
            return outScreenPosition;
        }

        static float GetFastestRotationDirectionP1(float prevAngle, float angle)
        {
            float clockWiseDist;
            float antiClockWiseDist;
            if (angle < prevAngle) {
                clockWiseDist = Utilities.GetABS((prevAngle - (angle + (2.0f * Constants.PI_))));
                antiClockWiseDist = Utilities.GetABS((prevAngle - angle));
            }
            else {
                antiClockWiseDist = Utilities.GetABS(((prevAngle + (2.0f * Constants.PI_)) - angle));
                clockWiseDist = Utilities.GetABS((prevAngle - angle));
            }

            if (clockWiseDist < antiClockWiseDist) {
                return 1.0f;
                ;
            }

            return -1.0f;
        }

        public static float GetAngleDifferenceP1(float angle, float prevAngle)
        {
            float clockWiseDist;
            float antiClockWiseDist;
            if (angle < prevAngle) {
                clockWiseDist = Utilities.GetABS((prevAngle - (angle + (2.0f * Constants.PI_))));
                antiClockWiseDist = Utilities.GetABS((prevAngle - angle));
            }
            else {
                antiClockWiseDist = Utilities.GetABS(((prevAngle + (2.0f * Constants.PI_)) - angle));
                clockWiseDist = Utilities.GetABS((prevAngle - angle));
            }

            if (clockWiseDist < antiClockWiseDist) {
                return clockWiseDist;
            }

            return -antiClockWiseDist;
        }

        public static float GetTimeTilHitWithAccP1P2(float distance, float vel, float acc)
        {
            float topHalf = (2.0f * acc * distance);
            topHalf += ((vel * vel) - vel);
            float time = (float)Math.Sqrt(topHalf) / acc;
            return time;
        }

        public static int IncrementLoopP1P2(int inVal, int loopMin, int loopMax)
        {
            inVal++;
            if (inVal > loopMax) {
                inVal = loopMin;
            }

            return inVal;
        }

        public static int DecrementLoopP1P2(int inVal, int loopMin, int loopMax)
        {
            inVal--;
            if (inVal < loopMin) {
                inVal = loopMax;
            }

            return inVal;
        }

        public static void InsertThisObjectIntoOrderedListP1P2P3(int objectId, float inYPos, List<int> inList, List<int> inYPosList)
        {
            //NSNumber item = null;
            int i = 0;
            int index = -1;
            foreach (int item in inList) {
                int whatIsIndex = item;
                float yPos = (float)(inYPosList[whatIsIndex]);
                if (inYPos < yPos) {
                    index = i;
                    break;
                }

                i++;
            }
            if (index == -1) inList.Add((objectId));
            else {
                inList.Insert(index,(objectId));
            }

            inYPosList.Add((int)(inYPos));
        }

        public static void InsertThisObjectIntoOrderedListNewP1P2P3(int objectId, float inYPos, List<int> inList, List<int> inYPosList)
        {
            //NSNumber item = null;
            int i = 0;
            int index = -1;
            foreach (int item in inList) {
                int whatIsIndex = item;
                float yPos = (float)(inYPosList[whatIsIndex]);
                if (inYPos < yPos) {
                    index = i;
                    break;
                }

                i++;
            }
            if (index == -1) inList.Add((objectId));
            else {
                inList.Insert(index,(objectId));
            }

            inYPosList.Add((int)(inYPos));
        }

        public static CGPoint GetVectorFromAngleNew(float inAngle)
        {
            CGPoint outVector = Utilities.CGPointMake((float)Math.Sin(inAngle), (float)Math.Cos(inAngle));
            {
                outVector.y = -outVector.y;
            }
            return outVector;
        }

        public static CGPoint GetVectorFromAngleNewP1(float inAngle, float dist)
        {
            CGPoint outVector = GetVectorFromAngleNew(inAngle);
            outVector.x *= dist;
            outVector.y *= dist;
            return outVector;
        }

        public static CGPoint GetVectorFromAngle(float inAngle)
        {
            CGPoint outVector = Utilities.CGPointMake((float)Math.Sin(inAngle), -(float)Math.Cos(inAngle));
            return outVector;
        }

        public static CGPoint GetVectorFromAngleP1(float inAngle, float outLength)
        {
            CGPoint outVector = Utilities.CGPointMake((float)Math.Cos(inAngle) * outLength, (float)Math.Sin(inAngle) * outLength);
            return outVector;
        }

        public static float GetABS(float inVal)
        {
            if (inVal < 0) return -inVal;
            else return inVal;

        }

        public static int GetIntFromBitsP1P2(int inData, int fromBit, int toBit)
        {
            int outIntA = inData << (31 - toBit);
            int outInt = outIntA >> ((31 - toBit) + (fromBit));
            return outInt;
        }

        public static void PrintIntInBits(int inInt)
        {
//            const int SHIFT = 8 * sizeof (inInt) - 1;
  //          for (int i = 1; i <= SHIFT + 1; i++) {
    //            inInt <<= 1;
      //      }

        }

        public static float WrapP1(float inVal, float wrapToVal)
        {
            float outVal = inVal;
            while (outVal > wrapToVal) {
                outVal -= wrapToVal;
            }

            return outVal;
        }

        public static bool FIsBetweenP1P2(float inV, float minV, float maxV)
        {
            return ((inV >= minV) && (inV <= maxV));
        }

        public static bool IsBetweenP1P2(int inV, int minV, int maxV)
        {
            return ((inV >= minV) && (inV <= maxV));
        }

        public static bool IsOnScreen(CGPoint screenPosition)
        {

                if ((screenPosition.x < Globals.g_world.coordinatesWidth) && (screenPosition.x > 0.0f)) {
                    return ((screenPosition.y < Globals.g_world.coordinatesHeight) && (screenPosition.y > 0.0f));
                }

            return false;
        }

        public static bool IsOnScreenP1(CGPoint screenPosition, float edgeWidth)
        {

            #if PLAY_HORIZONTAL
                if ((screenPosition.x < (Globals.g_world.screenWidth + edgeWidth)) && (screenPosition.x > -edgeWidth)) {
                    return ((screenPosition.y < (Globals.g_world.screenHeight + edgeWidth)) && (screenPosition.y > -edgeWidth));
                }

            #else
                if ((screenPosition.x < (Globals.g_world.coordinatesWidth + edgeWidth)) && (screenPosition.x > -edgeWidth)) {
                    return ((screenPosition.y < (Globals.g_world.coordinatesHeight + edgeWidth)) && (screenPosition.y > -edgeWidth));
                }

            #endif

            return false;
        }

        public static bool IsOnScreenP1P2(CGPoint screenPosition, float buffer, float mapObjectAppearDistance)
        {

            #if PLAY_HORIZONTAL
            #else
                if ((screenPosition.x < (Globals.g_world.coordinatesHeight + buffer)) && (screenPosition.x > (-(Globals.g_world.coordinatesWidth * 0.5f)) - buffer)) {
                    return ((screenPosition.y < (mapObjectAppearDistance + buffer)) && (screenPosition.y > -buffer));
                }

            #endif

            return false;
        }

        public static float GetSqrDistanceP1(CGPoint point1, CGPoint point2)
        {
            float xDist = point2.x - point1.x;
            float yDist = point2.y - point1.y;
            float sqrDistance = ((xDist * xDist) + (yDist * yDist));
            return sqrDistance;
        }

        public static CGPoint Normalise(CGPoint inPoint)
        {
            float L = (float)Math.Sqrt(inPoint.x * inPoint.x + inPoint.y * inPoint.y);
            CGPoint w;
            if (L != 0.0f) {
                L = 1.0f / L;
                w = Utilities.CGPointMake(L * inPoint.x, L * inPoint.y);
            }
            else {
                return Utilities.CGPointMake(0.0f, 1.0f);
            }

            return w;
        }

        public static float GetDistanceP1(CGPoint point1, CGPoint point2)
        {
            float sqrDistance = GetSqrDistanceP1(point1, point2);
            return (float)Math.Sqrt(sqrDistance);
        }

        public static float GetRatioP1P2(float inVal, float inMin, float inMax)
        {
            if (inVal < inMin) inVal = inMin;

            if (inVal > inMax) inVal = inMax;

            return 1.0f - ((inMax - inVal) / (inMax - inMin));
        }

        public static float SetCosInterpolationHalfP1(float inVal, float portionOfCurve)
        {
            const float kPi = Constants.PI_;
            float cosRatio = (inVal * kPi * portionOfCurve);
            float outVal = (float)Math.Cos(cosRatio);
            float maxCos = (float)Math.Cos(kPi * portionOfCurve);
            float newOutVal = 1.0f - GetRatioP1P2(outVal, maxCos, 1.0f);
            return newOutVal;
        }

        public static float GetNumApplesFromTrophy(int inTrophy)
        {
            if (inTrophy == 0) return 3;
            else if (inTrophy == 1) return 2;
            else if (inTrophy == 2) return 1;
            else {
                return 0;
            }

        }

        public static float GetNumApplesFromRacePosition(int racePos)
        {
            if (racePos == 1) return 3;
            else if (racePos == 2) return 2;
            else if (racePos == 3) return 1;
            else {
                return 0;
            }

        }

		//so out is as per rand()%n
		public static int GetRand(int inMaxLessOne)
        {
		//	System.Random rand = new System.Random();
		//	int outVal = rand.Range(0,inMaxLessOne);

		//	return outVal;
			//not sure quite how this rounds at the mo - test later...
			return (int)(UnityEngine.Random.Range(0,inMaxLessOne));
		}


        public static float GetRandBetweenP1(float inValMin, float inValMax)
        {
            int min = (int) (inValMin * 1000.0f);
            int max = (int) (inValMax * 1000.0f);
            int outInt = min + (Utilities.GetRand( (max - min)));
            return ((float) outInt) / 1000.0f;
        }

        public static float ApproachP1P2(float inVal, float inTarget, float inApproachSpeed)
        {
            Globals.Assert(inApproachSpeed >= 0);
            if (inVal < inTarget) {
                inVal += inApproachSpeed;
                if ((inVal) > inTarget) inVal = inTarget;

            }
            else if (inVal > inTarget) {
                inVal -= inApproachSpeed;
                if ((inVal) < inTarget) inVal = inTarget;

            }

            return inVal;
        }

        public static float SetRatioP1P2(float inVal, float inMin, float inMax)
        {
            float ratio = inVal;
            if (inVal < 0) ratio = 0;

            if (inVal > 1.0f) ratio = 1.0f;

            return inMin + ((inMax - inMin) * ratio);
        }

        public static float GetRatioP1P2P3P4(float inVal, float inMin, float inMax, float outMin, float outMax)
        {
            if (inVal < inMin) inVal = inMin;

            if (inVal > inMax) inVal = inMax;

            float ratio = (1.0f - ((inMax - inVal) / (inMax - inMin)));
            return SetRatioP1P2(ratio, outMin, outMax);
        }

        public static float ConstrainP1P2(float inVal, float inMin, float inMax)
        {
            if (inVal < inMin) {
                return inMin;
            }
            else if (inVal > inMax) {
                return inMax;
            }
            else return inVal;

        }

    }
}
