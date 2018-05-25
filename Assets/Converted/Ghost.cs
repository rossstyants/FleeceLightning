using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace Default.Namespace
{
    public class Ghost
    {
		public Billboard myAtlasBillboard; 
		
		public bool ghostRecordedYet;
        public bool loadedFromDataYet;
        public GhostFrameData[] frameData = new GhostFrameData[(int)Enum.kMaxEntries];
        public int ghostCurrentFrame;
        public CGPoint ghostScreenPos;
        public CGPoint position;
        public int numFrames;
        public float alpha;
        public float scale;
        public int ghostPlayer;
        public float raceTime;
        public int yReadingTotal;
        public int yMaxSoFar;
        public float zReadingTotal;
        public float zMaxSoFar;
        public class GhostSaveStruct{
            bool ghostRecordedYet;
            int numFrames;
            int[] frameData = new int [(int)Enum.kMaxEntries];
        };
        public struct GhostFrameData{
            public short x;
            public short y;
            public short rotation;
            public short anim;
            public float positionZ;
        };
        public enum GhostEvents {
            kGhostEvent_None = 0,
            kGhostEvent_HitCow = 1
        };
        public enum Enum {
            kMaxEntries = 3050
        };
        public bool LoadedFromDataYet
        {
            get;
            set;
        }

        public int NumFrames
        {
            get;
            set;
        }

        public int GhostCurrentFrame
        {
            get;
            set;
        }

        public CGPoint Position
        {
            get;
            set;
        }

        public float Alpha
        {
            get;
            set;
        }

        public int GhostPlayer
        {
            get;
            set;
        }

        public float RaceTime
        {
            get;
            set;
        }

		//public void SetFrameData(GhostFrameData inThing) {frameData = inThing;}///@property(readwrite,assign) GhostFrameData frameData;
public void SetLoadedFromDataYet(bool inThing) {loadedFromDataYet = inThing;}///@property(readwrite,assign) bool loadedFromDataYet;
public void SetNumFrames(int inThing) {numFrames = inThing;}///@property(readwrite,assign) int numFrames;
public void SetGhostCurrentFrame(int inThing) {ghostCurrentFrame = inThing;}///@property(readwrite,assign) int ghostCurrentFrame;
public void SetPosition(CGPoint inThing) {position = inThing;}///@property(readwrite,assign) CGPoint position;
//public void SetNoGoId(int inThing) {noGoId = inThing;}///@property(readwrite,assign) int noGoId;
public void SetAlpha(float inThing) {alpha = inThing;}///@property(readwrite,assign) float alpha;
public void SetGhostPlayer(int inThing) {ghostPlayer = inThing;}///@property(readwrite,assign) int ghostPlayer;
public void SetRaceTime(float inThing) {raceTime = inThing;}///@property(readwrite,assign) float raceTime;

        public Ghost()
        {
            //if (!base.init()) return null;

            ghostRecordedYet = false;
            loadedFromDataYet = false;
            scale = 1;
            alpha = 0.4f;
            ghostPlayer = (int) (int) PlayerType.kPlayerSheep;
            raceTime = 25;
			myAtlasBillboard = new Billboard("Ghost");
        }
        public GhostFrameData GetFrameData(int whichFrame)
        {
            Globals.Assert(whichFrame < (int)Enum.kMaxEntries);
            return frameData[whichFrame];
        }
		
		public void Dereference()
        {
			if (myAtlasBillboard != null)
			{
				myAtlasBillboard.Dealloc();			
				myAtlasBillboard = null;			
			}
        }
		
		
		public void StopRender()
        {
			myAtlasBillboard.StopRender();
		}
		
		
        public void Reset()
        {
            loadedFromDataYet = false;
            numFrames = 0;
        }

        public void WriteGhostDataToBinaryFileUsingIndices(FileStream fp)
        {
			UnityEngine.Debug.Log("WriteGhostDataToBinaryFileUsingIndices " + fp.Name.ToString());
			
            int intValue = 1;
            int result;
//            result = fwrite((char) (intValue), sizeof (int), 1, fp);
  //          result = fwrite((char) (ghostCurrentFrame), sizeof (int), 1, fp);
    //        result = fwrite((char) (raceTime), sizeof (float), 1, fp);
//            result = fwrite((const void) (intValue), sizeof (int), 1, fp);
  //          result = fwrite((const void) (ghostCurrentFrame), sizeof (int), 1, fp);
    //        result = fwrite((const void) (raceTime), sizeof (float), 1, fp);
			
			BinaryWriter writer = new BinaryWriter(fp);
			
			writer.Write(1);
			writer.Write((int)ghostCurrentFrame);
			writer.Write(ghostCurrentFrame);
			
			for (int i = 0; i < ghostCurrentFrame; i++) 
			{
				int newData = this.ConvertOldToNew(frameData[i]);
				writer.Write(newData);
            }

        }

        public void WriteGhostDataToDictionaryUsingIndices(Dictionary<string,int> dict)
        {
/*            string string1 = String.Format("ghostRecordedYet");
            NSNumber value = new NSNumber(1);
            dict.SetObjectForKey(value, string1);
            string string2 = String.Format("numFrames");
            value = new NSNumber(ghostCurrentFrame);
            dict.SetObjectForKey(value, string2);
            string string3 = String.Format("RaceTime");
            value = new NSNumber(raceTime);
            dict.SetObjectForKey(value, string3);
            string string4 = String.Format("UsingIndicesNew");
            value = new NSNumber(-1);
            dict.SetObjectForKey(value, string4);
            List<int> array = new List<int>(0);
            for (int i = 0; i < ghostCurrentFrame; i++) {
                int newData = this.ConvertOldToNew(frameData[i]);
                array.AddObject(NSNumber.NumberWithInt(newData));
            }

            dict.SetObjectForKey(array, "array");*/
        }

        public void WriteGhostDataToDictionary(Dictionary<string,int> dict)
        {
 /*           string string1;
            string1 = String.Format("ghostRecordedYet");
            NSNumber value;
            value = new NSNumber(1);
            dict.SetObjectForKey(value, string1);
            string1 = String.Format("numFrames");
            value = new NSNumber(ghostCurrentFrame);
            dict.SetObjectForKey(value, string1);
            string1 = String.Format("RaceTime");
            value = new NSNumber(raceTime);
            dict.SetObjectForKey(value, string1);
            for (int i = 0; i < ghostCurrentFrame; i++) {
                string1 = String.Format("xPos%d", i);
                value = new NSNumber(frameData[i].x);
                dict.SetObjectForKey(value, string1);
                string1 = String.Format("yPos%d", i);
                value = new NSNumber(frameData[i].y);
                dict.SetObjectForKey(value, string1);
                string1 = String.Format("rotation%d", i);
                value = new NSNumber(frameData[i].rotation);
                dict.SetObjectForKey(value, string1);
                string1 = String.Format("anim%d", i);
                value = new NSNumber(frameData[i].anim);
                dict.SetObjectForKey(value, string1);
                string1 = String.Format("pZ%d", i);
                value = new NSNumber(frameData[i].positionZ);
                dict.SetObjectForKey(value, string1);
            }*/

        }

        public void ReadDataFromDictionary(System.Collections.Generic.Dictionary<string,int> dict)
        {
/*            loadedFromDataYet = true;
            string string1;
            string1 = String.Format("ghostRecordedYet");
            NSInteger myInt = (dict.ObjectForKey(string1)).IntValue();
            if (myInt != 1) {
                ghostRecordedYet = false;
                return;
            }

            ghostRecordedYet = true;
            string1 = String.Format("numFrames");
            myInt = (dict.ObjectForKey(string1)).IntValue();
            numFrames = myInt;
            string1 = String.Format("RaceTime");
            raceTime = (float)((dict.ObjectForKey(string1)).FloatValue());
            if (raceTime == 0) raceTime = 40;

            for (int i = 0; i < numFrames; i++) {
                string1 = String.Format("xPos%d", i);
                frameData[i].x = (dict.ObjectForKey(string1)).IntValue();
                string1 = String.Format("yPos%d", i);
                frameData[i].y = (dict.ObjectForKey(string1)).IntValue();
                string1 = String.Format("rotation%d", i);
                frameData[i].rotation = (dict.ObjectForKey(string1)).IntValue();
                string1 = String.Format("anim%d", i);
                frameData[i].anim = (dict.ObjectForKey(string1)).IntValue();
                string1 = String.Format("pZ%d", i);
                frameData[i].positionZ = (float)((dict.ObjectForKey(string1)).FloatValue());
            }*/

        }

        GhostFrameData ConvertNewToOld(int inData)
        {
            GhostFrameData outData;
            outData.x = (short)Utilities.GetIntFromBitsP1P2(inData, 0, 9);
            int yPos = Utilities.GetIntFromBitsP1P2(inData, 16, 23);
            if ((yPos + yReadingTotal) < ((yMaxSoFar) - 50)) {
                yReadingTotal += 128;
            }
            else if ((yPos + yReadingTotal) > ((yMaxSoFar) + 80)) {
                yReadingTotal -= 128;
            }

            outData.y = (short)(yReadingTotal + yPos);
            yMaxSoFar = outData.y;
            outData.rotation = (short)Utilities.GetIntFromBitsP1P2(inData, 10, 15);
            float posZ = (float) Utilities.GetIntFromBitsP1P2(inData, 24, 31);
            if (posZ > 0) {
            }

            if ((posZ + zReadingTotal) < ((zMaxSoFar) - 60)) {
                zReadingTotal += 128;
            }
            else if ((posZ + zReadingTotal) > ((zMaxSoFar) + 60)) {
                zReadingTotal -= 128;
            }

            outData.positionZ = zReadingTotal + posZ;
            zMaxSoFar = outData.positionZ;
            outData.anim = 0;
            return outData;
        }

        public int ConvertOldToNew(GhostFrameData inData)
        {
            int outDataX = inData.x;
            int outDataR = inData.rotation;
            int outDataY = (inData.y) % 128;
            int zData = (int) (inData.positionZ);
            int outDataZp = (zData) % 128;
            int outData = (outDataZp << 24) | (outDataY << 16) | (outDataR << 10) | outDataX;
            return outData;
        }

        public void ReadDataFromBinaryFileUsingIndices(BinaryReader sr)
        {
			
            int intValue = 0;
            float floatValue = 0;
			
			intValue = sr.ReadInt32();
			
			Debug.Log ("ReadDataFromBinaryFileUsingIndices " + intValue.ToString());
			
			if (intValue != 1) {
                ghostRecordedYet = false;
                return;
            }

            ghostRecordedYet = true;
			intValue = sr.ReadInt32();
            numFrames = intValue;
			floatValue = sr.ReadSingle();
            raceTime = floatValue;
            yReadingTotal = 128;
            yMaxSoFar = 150;
            zReadingTotal = 0;
            zMaxSoFar = 0;
            for (int i = 0; i < numFrames; i++) {
				intValue = sr.ReadInt32();
                frameData[i] = this.ConvertNewToOld(intValue);
            }
        }

        public void ReadDataFromDictionaryUsingIndices(Dictionary<string,int> dict)
        {
/*            loadedFromDataYet = true;
            string string1;
            string1 = String.Format("ghostRecordedYet");
            NSInteger myInt = (dict.ObjectForKey(string1)).IntValue();
            if (myInt != 1) {
                ghostRecordedYet = false;
                return;
            }

            ghostRecordedYet = true;
            string1 = String.Format("UsingIndicesNew");
            myInt = (dict.ObjectForKey(string1)).IntValue();
            if (myInt != -1) {
                this.ReadDataFromDictionary(dict);
                return;
            }

            string1 = String.Format("numFrames");
            myInt = (dict.ObjectForKey(string1)).IntValue();
            numFrames = myInt;
            string1 = String.Format("RaceTime");
            raceTime = (float)((dict.ObjectForKey(string1)).FloatValue());
            if (raceTime == 0) raceTime = 40;

            NSArray array = dict.ObjectForKey("array");
            yReadingTotal = 128;
            yMaxSoFar = 150;
            zReadingTotal = 0;
            zMaxSoFar = 0;
            for (int i = 0; i < numFrames; i++) {
                int newData = (array[i]).IntValue();
                frameData[i] = this.ConvertNewToOld(newData);
            }*/

        }

        public void SetStartOfRace()
        {
            ghostCurrentFrame = 2;
			
			myAtlasBillboard.SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_PiggyAnims));
			myAtlasBillboard.SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_PiggyAnims),0);			
		}

        public void SetStartOfRacePlaying()
        {
            ghostCurrentFrame = 2;
            this.UpdatePlaying();
            ghostCurrentFrame = 2;
            frameData[1] = frameData[2];

			myAtlasBillboard.SetAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_PiggyAnims));
			myAtlasBillboard.SetDetailsFromAtlas(Globals.g_world.GetAtlas(AtlasType.kAtlas_PiggyAnims),0);					
		}

        public void CopyData(Ghost raceGhost)
        {
            ghostRecordedYet = true;
            numFrames = raceGhost.ghostCurrentFrame;
            raceTime = raceGhost.raceTime;
            for (int i = 0; i < numFrames; i++) {
                frameData[i] = raceGhost.GetFrameData(i);
            }

        }

        public void UpdateRecording()
        {
            if (ghostCurrentFrame >= (int)Enum.kMaxEntries) return;

            frameData[ghostCurrentFrame].x = (short) ((Globals.g_world.GetGame()).GetPlayer()).GetPosition().x;
            frameData[ghostCurrentFrame].y = (short) ((Globals.g_world.GetGame()).GetPlayer()).GetPosition().y;
            frameData[ghostCurrentFrame].rotation = (short)((Globals.g_world.GetGame()).GetPlayer()).rotateAnim;
            frameData[ghostCurrentFrame].anim = (short)((Globals.g_world.GetGame()).GetPlayer()).moveAnim;
            frameData[ghostCurrentFrame].positionZ = ((Globals.g_world.GetGame()).GetPlayer()).positionZ;
            ghostCurrentFrame++;
        }

        public void UpdatePlaying()
        {
            if (ghostCurrentFrame >= numFrames) {
                ghostScreenPos.x = -100;
                ghostScreenPos.y = -100;
                return;
            }

            if (!ghostRecordedYet) return;

            position = Utilities.CGPointMake(frameData[ghostCurrentFrame].x, frameData[ghostCurrentFrame].y);
            ghostScreenPos = (Globals.g_world.game).GetScreenPosition(position);
            scale = Utilities.GetScaleFromHeight(frameData[ghostCurrentFrame].positionZ);
            ghostScreenPos.y += Utilities.GetYOffsetFromHeight(frameData[ghostCurrentFrame].positionZ);
            ghostCurrentFrame++;
        }

        public void UpdateNothingButTheFrame()
        {
            if ((ghostCurrentFrame + 1) >= numFrames) return;

            ghostCurrentFrame++;
        }

        public bool IsDrawn(int renderingHeight)
        {
			PlayerHeight pHeight = (PlayerHeight)renderingHeight;
			
			if (!ghostRecordedYet) return false;
			
            if (ghostCurrentFrame <= 2) return false;
			
            if ((frameData[ghostCurrentFrame - 1].positionZ >= Globals.g_world.game.playerHeightMin[renderingHeight]) && 
				(frameData[ghostCurrentFrame - 1].positionZ < Globals.g_world.game.playerHeightMax[renderingHeight])) 
			{

				if ((Globals.g_world.game).IsOnScreenNewP1(ghostScreenPos, 50.0f)) 
				{
					return true;
                }

            }

            return false;
        }

        public void Render()
        {
			(DrawManager.Instance()).AddTextureToListP1P2P3P4P5(myAtlasBillboard, ghostScreenPos, scale, 0.0f, 0.0f, alpha,frameData[ghostCurrentFrame - 1].rotation + 63);

            #if TEST_SHORTS
            #endif

            #if TEST_SHORTS
            #endif

        }

    }
}
