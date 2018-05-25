using System;

namespace Default.Namespace
{
    public enum  WhichFlockType {
        kWFT_2by2Weave = 0,
        kWFT_JustShirley,
        kWFT_3Slow,
        kWFT_FlockHuddle,
        kWFT_FlockLines,
        kWFT_ThinWeaveOverBridge,
        kWFT_DownThroughTrees,
        kWFT_InTheForest,
        kWFT_Huddles,
        kWFT_PenguinsCurvy,
        kWFT_Migration,
        kWFT_SingleCurvyLine
    }
    public enum  FlockType {
        kFlockCows,
        kFlockPenguins,
        kFlockZebras,
        kFlockSheep
    }

    public class Flock
    {
        public FlockAnimal[] animal = new FlockAnimal[(int)Enum.kMaxFlockAnimals];
        public FlockType whichFlockAnimalType;
        public float speed;
        public float yPositionStart;
        public float yPositionEnd;
        public float yLength;
        public float headStart;
        public float headStartTime;
        public float timeOff;
        public float offscreenBuffer;
        public bool hasPathForAI;
        public int numAnimalsInFlock;
        public int flockId;
        public int whichFlock;
        public int updateStart;
        public int updateEnd;
        const float kBufferGap = 10.0f;
        public enum Enum {
            kMaxFlockAnimals = 80
        };
        public struct FlockAnimalInfo{
            public float distanceToGo;
            public Flock myFlock;
            public float xLinePosition;
            public float yUndulationTime;
            public float yUndulationTimer;
            public int animalType;
            public int flockAnimalId;
            public bool hasMarkerForAI;
            public CGPoint markerOffset;
        };

        public struct FlockInfo{
            public float speed;
            public float yPositionStart;
            public float yPositionEnd;
            public int whichFlock;
            public int flockId;
            public float headStart;
            public FlockType whichFlockAnimalType;
        };
        public float Speed
        {
            get;
            set;
        }

        public float YPositionStart
        {
            get;
            set;
        }

        public float YPositionEnd
        {
            get;
            set;
        }

        public float YLength
        {
            get;
            set;
        }

        public int FlockId
        {
            get;
            set;
        }

        public float HeadStartTime
        {
            get;
            set;
        }

        public bool HasPathForAI
        {
            get;
            set;
        }

        public int UpdateStart
        {
            get;
            set;
        }

        public int UpdateEnd
        {
            get;
            set;
        }

		public void SetSpeed(float inThing) {speed = inThing;}///@property(readwrite,assign) float speed;
public void SetYPositionStart(float inThing) {yPositionStart = inThing;}///@property(readwrite,assign) float yPositionStart;
public void SetYPositionEnd(float inThing) {yPositionEnd = inThing;}///@property(readwrite,assign) float yPositionEnd;
public void SetYLength(float inThing) {yLength = inThing;}///@property(readwrite,assign) float yLength;
public void SetFlockId(int inThing) {flockId = inThing;}///@property(readwrite,assign) int flockId;
public void SetUpdateStart(int inThing) {updateStart = inThing;}///@property(readwrite,assign) int updateStart;
public void SetUpdateEnd(int inThing) {updateEnd = inThing;}///@property(readwrite,assign) int updateEnd;
public void SetHeadStartTime(float inThing) {headStartTime = inThing;}///@property(readwrite,assign) float headStartTime;
public void SetHasPathForAI(bool inThing) {hasPathForAI = inThing;}///@property(readwrite,assign) bool hasPathForAI;

        public Flock()
        {
            //if (!base.init()) return null;

            for (int i = 0; i < (int)Enum.kMaxFlockAnimals; i++) animal[i] = null;

            //return this;
        }
        public void Dealloc()
        {
            for (int i = 0; i < numAnimalsInFlock; i++) {
                if (animal[i] != null) animal[i] = null;

            }

        }

        public FlockAnimal GetAnimal(int which)
        {
            Globals.Assert(which < numAnimalsInFlock);
            return animal[which];
        }

        public CGPoint GetNextMarkerForAI(CGPoint inPlayerPosition)
        {
            if (updateStart == -1) return Utilities.CGPointMake(0, 0);

            int i = updateStart;
            bool reachedEnd = false;
            if (updateStart == updateEnd) reachedEnd = true;

            float yDiffBest = 999999.0f;
            int closestMarker = -1;
            do {
                if (!reachedEnd) reachedEnd = (i == updateEnd);

                if ((animal[i]).hasMarkerForAI) {
                    float yDiff = ((animal[i]).position.y + (animal[i]).markerOffset.y) - inPlayerPosition.y;
                    if (yDiff > 30.0f) {
                        if (yDiff < yDiffBest) {
                            yDiffBest = yDiff;
                            closestMarker = i;
                        }

                    }

                }

                i++;
                if (i >= numAnimalsInFlock) {
                    i -= numAnimalsInFlock;
                }

            }
            while (!reachedEnd);

            if (closestMarker == -1) {
                return Utilities.CGPointMake(0, 0);
            }
            else {
                return Utilities.CGPointMake(((animal[closestMarker]).position.x + (animal[closestMarker]).markerOffset.x), ((animal[closestMarker]).position.y + (
                  animal[closestMarker]).markerOffset.y));
            }

        }

        public void AddAnimal(FlockAnimalInfo info)
        {
            Globals.Assert(numAnimalsInFlock < (int)Enum.kMaxFlockAnimals);
            if (animal[numAnimalsInFlock] == null) {
                animal[numAnimalsInFlock] = new FlockAnimal();
            }

            FlockAnimal prevAnimal = null;
            if (numAnimalsInFlock > 0) {
                prevAnimal = animal[numAnimalsInFlock - 1];
            }

            info.flockAnimalId = numAnimalsInFlock;
            (animal[numAnimalsInFlock]).AddToFlockP1(info, prevAnimal);
            numAnimalsInFlock++;
        }

        public void AddAnimals_Zebra()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalZebra;
            info.hasMarkerForAI = false;
            for (int i = 0; i < 9; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 105.0f;
                info.distanceToGo = 400.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 2.0f;
                info.xLinePosition = 275.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 5.0f;
                info.xLinePosition = 345.0f;
                info.distanceToGo = 80.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 45.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 2.0f;
                info.xLinePosition = 142.0f;
                info.distanceToGo = 400.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 2.0f;
                info.xLinePosition = 242.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 2.0f;
                info.xLinePosition = 192.0f;
                info.distanceToGo = 80.0f;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_ZebraChicane()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalZebra;
            info.hasMarkerForAI = false;
            for (int i = 0; i < 12; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 90.0f;
                info.distanceToGo = 350.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 180.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 5.0f;
                info.xLinePosition = 310.0f;
                info.distanceToGo = 350.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 2.0f;
                info.xLinePosition = 220.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_ThinWeave()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = true;
            for (int i = 0; i < 7; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 152.0f;
                info.distanceToGo = 200.0f;
                info.markerOffset = Utilities.CGPointMake(90.0f, 40.0f);
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 232.0f;
                info.distanceToGo = 200.0f;
                info.markerOffset = Utilities.CGPointMake(-90.0f, 40.0f);
                this.AddAnimal(info);
                info.yUndulationTime = 5.0f;
                info.xLinePosition = 162.0f;
                info.distanceToGo = 200.0f;
                info.markerOffset = Utilities.CGPointMake(90.0f, 40.0f);
                this.AddAnimal(info);
                info.yUndulationTime = 2.0f;
                info.xLinePosition = 226.0f;
                info.distanceToGo = 200.0f;
                info.markerOffset = Utilities.CGPointMake(-90.0f, 40.0f);
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_PenguinsWeave()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            const float kDistanceBetPs = 250.0f;
            const float kExtra = 42.0f;
            const float kGapBetween = 53.0f;
            for (int i = 0; i < 7; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 152.0f - kExtra;
                info.distanceToGo = kDistanceBetPs;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(90.0f + kGapBetween, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 152.0f - kExtra + kGapBetween;
                info.distanceToGo = 0.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(90.0f, 100.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 232.0f + kExtra;
                info.distanceToGo = kDistanceBetPs;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(-90.0f - kGapBetween, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 232.0f + kExtra - kGapBetween;
                info.distanceToGo = 0.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(-90.0f, 100.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 5.0f;
                info.xLinePosition = 157.0f - kExtra;
                info.distanceToGo = kDistanceBetPs;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(90.0f + kGapBetween, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 157.0f - kExtra + kGapBetween;
                info.distanceToGo = 0.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(90.0f, 100.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 2.0f;
                info.xLinePosition = 229.0f + kExtra;
                info.distanceToGo = kDistanceBetPs;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(-90.0f - kGapBetween, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 229.0f + kExtra - kGapBetween;
                info.distanceToGo = 0.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(-90.0f - kGapBetween, 100.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
            }

        }

        public void AddAnimals_Shirley()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalShirley;
            info.hasMarkerForAI = false;
            const float kDistanceBetPs = 250.0f;
            for (int i = 0; i < 1; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 192.0f;
                info.distanceToGo = kDistanceBetPs;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_3Slow()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            const float kDistanceBetPs = 250.0f;
            for (int i = 0; i < 1; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 192.0f;
                info.distanceToGo = kDistanceBetPs;
                info.hasMarkerForAI = false;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 50.0f;
                info.distanceToGo = 80.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 336.0f;
                info.distanceToGo = 90.0f;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_PenguinsMigration()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            const float kDistanceBetweenPenguins = 180.0f;
            const float kDistanceBetweenPenguins2 = 20.0f;
            for (int i = 0; i < 4; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 10.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(75.0f, 30.0f);
                info.distanceToGo = kDistanceBetweenPenguins;
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 182.0f;
                info.distanceToGo = kDistanceBetweenPenguins2;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 45.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(85.0f, -25.0f);
                info.distanceToGo = kDistanceBetweenPenguins;
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 217.0f;
                info.distanceToGo = kDistanceBetweenPenguins2;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 80.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(85.0f, -25.0f);
                info.distanceToGo = kDistanceBetweenPenguins;
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 252.0f;
                info.distanceToGo = kDistanceBetweenPenguins2;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 115.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(85.0f, -25.0f);
                info.distanceToGo = kDistanceBetweenPenguins;
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 287.0f;
                info.distanceToGo = kDistanceBetweenPenguins2;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 150.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(85.0f, -25.0f);
                info.distanceToGo = kDistanceBetweenPenguins;
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 322.0f;
                info.distanceToGo = kDistanceBetweenPenguins2;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_PenguinsHuddle(int numHuddles)
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            for (int i = 0; i < numHuddles; i++) {
                if (numHuddles > 1) {
                    info.yUndulationTime = 3.0f;
                    info.yUndulationTimer = 0.0f;
                    info.xLinePosition = 30.0f;
                    info.distanceToGo = 150.0f;
                    this.AddAnimal(info);
                    info.yUndulationTime = 3.0f;
                    info.yUndulationTimer = 0.0f;
                    info.xLinePosition = 355.0f;
                    info.distanceToGo = 0.0f;
                    this.AddAnimal(info);
                    info.yUndulationTime = 3.0f;
                    info.yUndulationTimer = 0.0f;
                    info.xLinePosition = 192.0f;
                    info.distanceToGo = 150.0f;
                    this.AddAnimal(info);
                }
                else {
                    info.yUndulationTime = 3.0f;
                    info.yUndulationTimer = 0.0f;
                    info.xLinePosition = 192.0f;
                    info.distanceToGo = 300.0f;
                    this.AddAnimal(info);
                }

                info.yUndulationTime = 4.0f;
                info.xLinePosition = 138.0f;
                info.distanceToGo = 70.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(-90.0f, 50.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 252.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 192.0f;
                info.distanceToGo = 65.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 86.0f;
                info.distanceToGo = 5.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(-75.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 308.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 132.0f;
                info.distanceToGo = 68.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(-80.0f, -50.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 242.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 194.0f;
                info.distanceToGo = 62.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(-100.0f, -50.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
            }

        }

        public void AddAnimals_FlockLines(int numLines)
        {
            const int kNumXSheep = 4;
            float kXGap = (384.0f - 80.0f) / (float)(kNumXSheep - 1);
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            for (int i = 0; i < numLines; i++) {
                float xPos = 40.0f;
                if (i % 2 == 1) {
                    xPos -= (kXGap / 2.0f);
                }

                for (int x = 0; x < 4; x++) {
                    info.yUndulationTime = 3.0f;
                    info.yUndulationTimer = 0.0f;
                    info.xLinePosition = xPos;
                    info.distanceToGo = 300.0f;
                    this.AddAnimal(info);
                    xPos += kXGap;
                }

            }

        }

        public void AddAnimals_FlockHuddle(int numHuddles)
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            for (int i = 0; i < numHuddles; i++) {
                {
                }
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 192.0f;
                info.distanceToGo = 300.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 138.0f;
                info.distanceToGo = 50.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 252.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 192.0f;
                info.distanceToGo = 85.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 96.0f;
                info.distanceToGo = 5.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 298.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 132.0f;
                info.distanceToGo = 88.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 242.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 194.0f;
                info.distanceToGo = 42.0f;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_PenguinsLines()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            const float kDistanceBetPens = 120.0f;
            for (int i = 0; i < 8; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 98;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 287.0f;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 2.5f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 82;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 3.2f;
                info.xLinePosition = 278.0f;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 2.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 111;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 4.2f;
                info.xLinePosition = 308.0f;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_PenguinsSideLines()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            const float kDistanceBetPens = 162.0f;
            const float kLittleGap = 30.0f;
            for (int i = 0; i < 10; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 75.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 2.5f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 360.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.2f;
                info.xLinePosition = 290.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 - kLittleGap;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 75.0f - kLittleGap;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 2.5f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 360.0f - kLittleGap;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.2f;
                info.xLinePosition = 290.0f - kLittleGap;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_SheepSideLines()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            const float kDistanceBetPens = 162.0f;
            const float kLittleGap = 30.0f;
            for (int i = 0; i < 10; i++) {
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 75.0f;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 3.2f;
                info.xLinePosition = 315.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 75 - kLittleGap;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 3.2f;
                info.xLinePosition = 310.0f + kLittleGap;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals_SingleCurvy()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            const float kDistanceBetPens = 222.0f;
            float curveWidth = 200.0f;
            int numSheepInOneFullCurve = 10;
            int numFullCurves = 5;
            float anglePerAnimal = Constants.PI_ / ((float)(numSheepInOneFullCurve - 1));
            float angle = 0.0f;
            for (int j = 0; j < numFullCurves; j++) {
                for (int i = 0; i < numSheepInOneFullCurve; i++) {
                    float xOffset = -0.5f + Utilities.GetCosInterpolationP1P2(angle, 0.0f, Constants.PI_);
                    angle += anglePerAnimal;
                    if (angle >= Constants.PI_) {
                        angle -= Constants.PI_;
                    }

                    xOffset *= curveWidth;
                    info.yUndulationTime = 3.0f;
                    info.yUndulationTimer = 0.0f;
                    info.xLinePosition = 192.0f + xOffset;
                    info.distanceToGo = kDistanceBetPens;
                    this.AddAnimal(info);
                }

            }

        }

        public void AddAnimals_PenguinsCurvy()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalSheep;
            info.hasMarkerForAI = false;
            const float kDistanceBetPens = 162.0f;
            for (int i = 0; i < 3; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 20;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 60;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 120;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 160;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 180;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 160;
                info.distanceToGo = kDistanceBetPens;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 120;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 60;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25 + 20;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 25;
                info.distanceToGo = kDistanceBetPens;
                info.hasMarkerForAI = true;
                info.markerOffset = Utilities.CGPointMake(100.0f, 0.0f);
                this.AddAnimal(info);
                info.hasMarkerForAI = false;
                info.yUndulationTime = 4.0f;
                info.xLinePosition += 200.0f;
                info.distanceToGo = 0.0f;
                this.AddAnimal(info);
            }

        }

        public void AddAnimals()
        {
            FlockAnimalInfo info = new FlockAnimalInfo();
            info.myFlock = this;
            info.animalType = (short)FlockAnimalType.kFlockAnimalCow;
            info.hasMarkerForAI = false;
            for (int i = 0; i < 4; i++) {
                info.yUndulationTime = 3.0f;
                info.yUndulationTimer = 0.0f;
                info.xLinePosition = 130.0f;
                info.distanceToGo = 170.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 265.0f;
                info.distanceToGo = 20.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 5.0f;
                info.xLinePosition = 40.0f;
                info.distanceToGo = 100.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 2.0f;
                info.xLinePosition = 190.0f;
                info.distanceToGo = 60.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 3.0f;
                info.xLinePosition = 240.0f;
                info.distanceToGo = 60.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 4.0f;
                info.xLinePosition = 160.0f;
                info.distanceToGo = 90.0f;
                this.AddAnimal(info);
                info.yUndulationTime = 5.0f;
                info.xLinePosition = 345.0f;
                info.distanceToGo = 110.0f;
                this.AddAnimal(info);
            }

        }

        public void CheckIfWeHavePathForAI()
        {
            for (int i = 0; i < numAnimalsInFlock; i++) {
                if ((animal[i]).hasMarkerForAI) {
                    hasPathForAI = true;
                    return;
                }

            }

            hasPathForAI = false;
        }

        public void SetupFlock(FlockInfo info)
        {
            numAnimalsInFlock = 0;
            speed = info.speed;
            yPositionStart = info.yPositionStart;
            yPositionEnd = info.yPositionEnd;
            headStart = info.headStart;
            flockId = info.flockId;
            whichFlockAnimalType = info.whichFlockAnimalType;
            float numFrames = info.headStart / speed;
            headStartTime = numFrames * Constants.kFrameRate;
            whichFlock = info.whichFlock;
            switch ((WhichFlockType)info.whichFlock) {
            case WhichFlockType.kWFT_2by2Weave :
                this.AddAnimals_PenguinsWeave();
                break;
            case WhichFlockType.kWFT_JustShirley :
                this.AddAnimals_Shirley();
                break;
            case WhichFlockType.kWFT_3Slow :
                this.AddAnimals_3Slow();
                break;
            case WhichFlockType.kWFT_FlockHuddle :
                this.AddAnimals_FlockHuddle(1);
                break;
            case WhichFlockType.kWFT_FlockLines :
                this.AddAnimals_FlockLines(1);
                break;
            case WhichFlockType.kWFT_ThinWeaveOverBridge :
                this.AddAnimals_ThinWeave();
                break;
            case WhichFlockType.kWFT_DownThroughTrees :
                this.AddAnimals_SheepSideLines();
                break;
            case WhichFlockType.kWFT_InTheForest :
                this.AddAnimals_PenguinsLines();
                break;
            case WhichFlockType.kWFT_Huddles :
                this.AddAnimals_PenguinsHuddle(1);
                break;
            case WhichFlockType.kWFT_PenguinsCurvy :
                this.AddAnimals_PenguinsCurvy();
                break;
            case WhichFlockType.kWFT_SingleCurvyLine :
                this.AddAnimals_SingleCurvy();
                break;
            case WhichFlockType.kWFT_Migration :
                this.AddAnimals_PenguinsMigration();
                break;
            default :
                this.AddAnimals_PenguinsWeave();
                break;
            }

            switch ((FlockType)whichFlockAnimalType) {
            case FlockType.kFlockPenguins :
                offscreenBuffer = 70.0f;
                break;
            case FlockType.kFlockCows :
                offscreenBuffer = 100.0f;
                break;
            case FlockType.kFlockSheep :
                offscreenBuffer = 100.0f;
                break;
            default :
                offscreenBuffer = 70.0f;
                break;
            }

            for (int i = 0; i < numAnimalsInFlock; i++) {
                (animal[i]).SetStartOfRace();
            }

            this.CheckIfWeHavePathForAI();
        }

        public void SetStartingUpdateStartAndEnd()
        {
            updateStart = -1;
            updateEnd = -1;
            float startScrollTop = 0.0f;
            float startScrollBott = 600.0f;
            float smallestY = 1000000000.0f;
            float biggestY = -10000000.0f;
            int topAnimal = -1;
            int bottAnimal = -1;
            for (int i = 0; i < numAnimalsInFlock; i++) {
                float yPos = (animal[i]).yStartPosition;
                yPos += ((headStartTime / Constants.kFrameRate) * speed);
                if (yPos > startScrollTop) {
                    if (yPos < startScrollBott) {
                        if (yPos > biggestY) {
                            biggestY = yPos;
                            topAnimal = i;
                        }

                        if (yPos <= smallestY) {
                            smallestY = yPos;
                            bottAnimal = i;
                        }

                    }

                }

            }

            if (topAnimal != -1) {
                updateStart = topAnimal;
                updateEnd = bottAnimal;
                bool reachedEnd = false;
                if (updateStart == updateEnd) reachedEnd = true;

                int i = updateStart;
                do {
                    if (!reachedEnd) reachedEnd = (i == updateEnd);

                    int moId = (animal[i]).mapObjectId;
                    (Globals.g_world.game).AddToUsedListP1( ListType.e_RenderAbovePlayer, moId);
                    int smoId = (animal[i]).shadowMapObjectId;
                    if (smoId != -1) {
                        (Globals.g_world.game).AddToUsedListP1( ListType.e_Shadows, smoId);
                    }

                    i++;
                    if (i >= numAnimalsInFlock) {
                        i -= numAnimalsInFlock;
                    }

                }
                while (!reachedEnd);

            }

        }

        public void StartRace()
        {
            for (int i = 0; i < numAnimalsInFlock; i++) {
                (animal[i]).SetStartOfRace();
            }

            this.SetStartingUpdateStartAndEnd();
        }

        public void CheckContractUpdateStartP1(float scrollEdgeScreenBottom, float raceTimer)
        {
            float yPos = (animal[updateStart]).CalculateYPosition(raceTimer);
            if (yPos > (scrollEdgeScreenBottom + kBufferGap)) {
                int moId = (animal[updateStart]).mapObjectId;
                (Globals.g_world.game).RemoveFromUsedListP1( ListType.e_RenderAbovePlayer, moId);
                int smoId = (animal[updateStart]).shadowMapObjectId;
                if (smoId != -1) {
                    (Globals.g_world.game).RemoveFromUsedListP1( ListType.e_Shadows, smoId);
					Globals.g_world.game.mapObject[smoId].StopRender();
				}
				Globals.g_world.game.mapObject[moId].StopRender();


                if (updateStart == updateEnd) {
                    updateStart = -1;
                    updateEnd = -1;
                }
                else {
                    updateStart += 1;
                    if (updateStart >= numAnimalsInFlock) {
                        updateStart -= numAnimalsInFlock;
                    }

                }

            }

        }

        public void CheckContractUpdateEndP1(float scrollEdgeScreenTop, float raceTimer)
        {
            float yPos = (animal[updateEnd]).CalculateYPosition(raceTimer);
            if (yPos < (scrollEdgeScreenTop - kBufferGap)) 
			{
                int moId = (animal[updateEnd]).mapObjectId;
                (Globals.g_world.game).RemoveFromUsedListP1( ListType.e_RenderAbovePlayer, moId);
                int smoId = (animal[updateEnd]).shadowMapObjectId;
                if (smoId != -1) {
                    (Globals.g_world.game).RemoveFromUsedListP1( ListType.e_Shadows, smoId);
					Globals.g_world.game.mapObject[smoId].StopRender();
				}
				Globals.g_world.game.mapObject[moId].StopRender();

                if (updateStart == updateEnd) {
                    updateStart = -1;
                    updateEnd = -1;
                }
                else {
                    updateEnd -= 1;
                    if (updateEnd < 0) {
                        updateEnd = (numAnimalsInFlock - 1);
                    }

                }

            }

        }

        public void CheckExtendUpdateStartP1(float scrollEdgeScreenBottom, float raceTimer)
        {
            int animalBeforeUpdate;
            if (updateStart == -1) {
                animalBeforeUpdate = (numAnimalsInFlock - 1);
            }
            else {
                if (numAnimalsInFlock == 1) {
                    return;
                }

                animalBeforeUpdate = updateStart - 1;
                if (animalBeforeUpdate < 0) animalBeforeUpdate += numAnimalsInFlock;

            }

            if (animalBeforeUpdate != updateEnd) {
                float yPos = (animal[animalBeforeUpdate]).CalculateYPosition(raceTimer);
                if ((yPos < scrollEdgeScreenBottom) && (yPos > (scrollEdgeScreenBottom - 100))) {
                    updateStart = animalBeforeUpdate;
                    int moId = (animal[updateStart]).mapObjectId;
                    (Globals.g_world.game).AddToUsedListP1( ListType.e_RenderAbovePlayer, moId);
                    int smoId = (animal[updateStart]).shadowMapObjectId;
                    if (smoId != -1) {
                        (Globals.g_world.game).AddToUsedListP1( ListType.e_Shadows, smoId);
                    }

                }

            }

        }

        public void CheckExtendUpdateEndP1(float scrollEdgeScreenTop, float raceTimer)
        {
            int animalAfterUpdate;
            if (updateEnd == -1) {
                animalAfterUpdate = 0;
            }
            else {
                if (numAnimalsInFlock == 1) return;

                animalAfterUpdate = updateEnd + 1;
                if (animalAfterUpdate >= numAnimalsInFlock) animalAfterUpdate -= numAnimalsInFlock;

            }

            if (animalAfterUpdate != updateStart) {
                float yPos = (animal[animalAfterUpdate]).CalculateYPosition(raceTimer);
                if ((yPos > scrollEdgeScreenTop) && (yPos < scrollEdgeScreenTop + 100)) {
                    updateEnd = animalAfterUpdate;
                    int moId = (animal[updateEnd]).mapObjectId;
                    (Globals.g_world.game).AddToUsedListP1( ListType.e_RenderAbovePlayer, moId);
                    int smoId = (animal[updateEnd]).shadowMapObjectId;
                    if (smoId != -1) {
                        (Globals.g_world.game).AddToUsedListP1( ListType.e_Shadows, smoId);
                    }

                }

            }

        }

        public void CheckNewStartOrEnd()
        {
            if (updateEnd == -1) {
                if (updateStart != -1) {
                    updateEnd = updateStart;
                }

            }
            else if (updateStart == -1) {
                updateStart = updateEnd;
            }

        }

        public void CheckExtendUpdateP1P2(float scrollEdgeScreenTop, float scrollEdgeScreenBottom, float raceTimer)
        {
            this.CheckExtendUpdateStartP1(scrollEdgeScreenBottom, raceTimer);
            this.CheckExtendUpdateEndP1(scrollEdgeScreenTop, raceTimer);
            this.CheckNewStartOrEnd();
        }

        public void CheckContractUpdateP1P2(float scrollEdgeScreenTop, float scrollEdgeScreenBottom, float raceTimer)
        {
            if (updateStart != -1) {
                this.CheckContractUpdateStartP1(scrollEdgeScreenBottom, raceTimer);
                if (updateEnd != -1) {
                    this.CheckContractUpdateEndP1(scrollEdgeScreenTop, raceTimer);
                }

            }

        }

        public void UpdateFlockNew()
        {
            float scrollEdgeScreenTop = (Globals.g_world.game).scrollPosition.y - offscreenBuffer;
            float scrollEdgeScreenBottom = (Globals.g_world.game).scrollPosition.y + Globals.g_world.mapObjectAppearDistance - 50.0f + offscreenBuffer;
            float raceTimer = (Globals.g_world.game).raceTimer + headStartTime;
            this.CheckExtendUpdateP1P2(scrollEdgeScreenTop, scrollEdgeScreenBottom, raceTimer);
            this.CheckContractUpdateP1P2(scrollEdgeScreenTop, scrollEdgeScreenBottom, raceTimer);
            if (updateStart == -1) return;

            int i = updateStart;
            bool reachedEnd = false;
            if (updateStart == updateEnd) reachedEnd = true;

            do {
                if (!reachedEnd) reachedEnd = (i == updateEnd);

                (animal[i]).UpdateNew(raceTimer);
                i++;
                if (i >= numAnimalsInFlock) {
                    i -= numAnimalsInFlock;
                }

            }
            while (!reachedEnd);

        }

        public void Render()
        {

            #if DEBUG_DRAW_RACING_LINE
                int i = updateStart;
                if (i < 0) return;

                bool reachedEnd = false;
                if (updateStart == updateEnd) reachedEnd = true;

                do {
                    if (!reachedEnd) reachedEnd = (i == updateEnd);

                    (animal[i]).RenderMarkerForAI();
                    i++;
                    if (i >= numAnimalsInFlock) {
                        i -= numAnimalsInFlock;
                    }

                }
                while (!reachedEnd);

            #endif

            #if DEBUG_FLOCKS
                if (updateStart == -1) return;

                int i = updateStart;
                bool reachedEnd = false;
                if (updateStart == updateEnd) reachedEnd = true;

                do {
                    if (!reachedEnd) reachedEnd = (i == updateEnd);

                    (animal[i]).Render();
                    i++;
                    if (i >= numAnimalsInFlock) {
                        i -= numAnimalsInFlock;
                    }

                }
                while (!reachedEnd);

            #endif

        }

    }
}
