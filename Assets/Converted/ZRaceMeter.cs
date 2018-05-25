using UnityEngine;
using System;

namespace Default.Namespace
{
    public enum  RMPlayerState {
        kRMPlayer_Free,
        kRMPlayer_BeingOvertaken,
        kRMPlayer_Overtaking
    }
    public class ZRaceMeter
    {
        public Zobject pRaceTrack;
        public Zobject pRaceTrackLowerHalf;
        public Zobject[] pMarker = new Zobject[(int)Enum.kMaxNumTeams];
        public float[] markerPosition = new float[(int)Enum.kMaxNumTeams];
        public bool[] overTakeThisFrame = new bool[(int)Enum.kMaxNumTeams];
        public bool[] overTakeThisFramePlayer = new bool[(int)Enum.kMaxNumTeams];
        public int numTeams;
        public float raceFrom;
        public float raceTo;
        public CGPoint raceMeterScreenPosition;
        public CGPoint raceMarkerStartPos;
        public CGPoint raceMarkerFinishPos;
        public float markerSize;
        public float overtakeDistance;
        public float zDiffForLeader;
        public float overTakeTime;
        public float[] overTakingTimer = new float[(int)Enum.kMaxNumTeams];
        public bool useLocator;
        public CGPoint raceMarkerPosOffset;
        public float fMarkerThrobSizeMax;
        public float fMarkerThrobSizeMin;
        public int[] playerPosition = new int[(int)Enum.kMaxNumTeams];
        public RMPlayerState[] playerState = new RMPlayerState[(int)Enum.kMaxNumTeams];
        public float zRotation;
		
        public class ZRMUpdateData{
            public float[] racePos = new float[(int)Enum.kMaxNumTeams];
        };
        public struct ZRaceMeterGetReadyData{
            public float raceFrom;
            public float raceTo;
        } ;
        public struct ZRaceMeterReinitData{
            public float scale;
            public float markerScale;
            public CGPoint raceMeterScreenPosition;
            public CGPoint raceMarkersScreenFrom;
            public CGPoint raceMarkersScreenTo;
            public bool useLocator;
        };
        public class ZRaceMeterData{
            public int numTeams;
            public Texture2D_Ross trackTexture;
            public Texture2D_Ross[] markerTexture = new Texture2D_Ross [(int)Enum.kMaxNumTeams];
            public CGPoint position;
            public ZAtlas atlas;
            public int[] subtextureId = new int [(int)Enum.kMaxNumTeams];
        };
        public enum Enum {
            kMaxNumTeams = 6
        };

        public ZRaceMeter ()
		{
			//if (!base.init()) return null;

			for (int team = 0; team < (int)Enum.kMaxNumTeams; team++) pMarker[team] = null;

            pRaceTrack = null;
            pRaceTrackLowerHalf = null;
            //return this;
        }
		
		public void StopRender()
		{
			pRaceTrack.StopRender();
			pRaceTrackLowerHalf.StopRender();
			for (int i = 0; i < (int)Enum.kMaxNumTeams; i++)
			{
				if (pMarker[i] != null)
				{
					pMarker[i].StopRender();
				}
			}
		}
		
        public void FirstInitialisation (ZRaceMeterData inData)
		{
			Globals.Assert (inData.numTeams <= (int)Enum.kMaxNumTeams);
            numTeams = inData.numTeams;
            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.isMapObject = false;
            info.startState = ZobjectState.kZobjectShown;
            info.position = inData.position;
            for (int team = 0; team < numTeams; team++) {
                if (pMarker[team] == null) pMarker[team] = new Zobject();

                info.texture = null;
                (pMarker[team]).Initialise(info);
                (pMarker[team]).SetAtlas(inData.atlas);
                (pMarker[team]).SetSubTextureId(inData.subtextureId[team]);
				pMarker[team].myAtlasBillboard.SetRenderQueue(11000);
				pMarker[team].myAtlasBillboard.myObject.layer  = LayerMask.NameToLayer("guistuff");

            }

            if (pRaceTrack == null) {
                pRaceTrack = new Zobject();
                pRaceTrackLowerHalf = new Zobject();
            }

            info.texture = null;
            pRaceTrack.Initialise(info);
            pRaceTrack.SetAtlas(inData.atlas);
            pRaceTrack.SetSubTextureId(1);
            pRaceTrackLowerHalf.Initialise(info);
            pRaceTrackLowerHalf.SetAtlas(inData.atlas);
            pRaceTrackLowerHalf.SetSubTextureId(2);
				pRaceTrack.myAtlasBillboard.SetRenderQueue(11000);
				pRaceTrackLowerHalf.myAtlasBillboard.SetRenderQueue(11000);
				pRaceTrack.myAtlasBillboard.myObject.layer  = LayerMask.NameToLayer("guistuff");
				pRaceTrackLowerHalf.myAtlasBillboard.myObject.layer  = LayerMask.NameToLayer("guistuff");
			
			
        }

        public void SetDefaults()
        {
            markerSize = 0.11f;
            overtakeDistance = -10;
            zDiffForLeader = 2.0f;
            overTakeTime = 0.2f;
            raceMarkerPosOffset = Utilities.CGPointMake(0, 0);
            fMarkerThrobSizeMax = 0.4f;
            fMarkerThrobSizeMin = 0.2f;
        }

        public void NewGameStateGetReady(ZRaceMeterGetReadyData inData)
        {
            raceFrom = inData.raceFrom;
            raceTo = inData.raceTo;
        }

        public void ReInit(ZRaceMeterReinitData inData)
        {
            this.SetDefaults();
            useLocator = inData.useLocator;
            raceMeterScreenPosition = inData.raceMeterScreenPosition;
            raceMarkerStartPos = Utilities.CGPointMake(inData.raceMeterScreenPosition.x + inData.raceMarkersScreenFrom.x, inData.raceMeterScreenPosition.y + inData.
              raceMarkersScreenFrom.y);
            raceMarkerFinishPos = Utilities.CGPointMake(inData.raceMeterScreenPosition.x + inData.raceMarkersScreenTo.x, inData.raceMeterScreenPosition.y + inData.
              raceMarkersScreenTo.y);
            for (int team = 0; team < numTeams; team++) {
                markerPosition[team] = ((float) (numTeams - 1 - team)) * markerSize;
                (pMarker[team]).SetShowScale(inData.markerScale);
                overTakingTimer[team] = 0.0f;
                if (useLocator) {
                }

                playerPosition[team] = team;
                playerState[team] = RMPlayerState.kRMPlayer_Free;
            }
			
			pRaceTrack.SetPosition(inData.raceMeterScreenPosition);
            pRaceTrack.SetShowScale(inData.scale);
            pRaceTrackLowerHalf.SetShowScale(inData.scale);
            zRotation = 0;
        }

        public void RotateMarkers(float rads)
        {
            zRotation = rads;
        }

        public int GetOverTakerOfPlayer()
        {
            for (int team = 0; team < numTeams; team++) {
                if (overTakeThisFramePlayer[team]) {
                    return team;
                }

            }

            return -1;
        }

        public int GetOverTaker()
        {
            for (int team = 0; team < numTeams; team++) {
                if (overTakeThisFrame[team]) {
                    return team;
                }

            }

            return -1;
        }

        public void ForceWinner(int who)
        {
        }

        public int GetWinner()
        {
            if (playerState[playerPosition[1]] == RMPlayerState.kRMPlayer_Overtaking) {
                return playerPosition[1];
            }
            else {
                return playerPosition[0];
            }

            return -1;
        }

        public void StartOvertakeP1(int whoBehind, int whoInFront)
        {
            overTakingTimer[whoBehind] = overTakeTime;
            (pMarker[whoBehind]).ThrobP1(fMarkerThrobSizeMax, overTakeTime);
            overTakeThisFrame[whoBehind] = true;
            playerState[whoInFront] = RMPlayerState.kRMPlayer_BeingOvertaken;
            playerState[whoBehind] = RMPlayerState.kRMPlayer_Overtaking;
            if ((whoInFront == 0) || (whoBehind == 0)) {
                overTakeThisFramePlayer[whoBehind] = true;
            }

        }

        public void Update (ZRMUpdateData inData)
		{
			int[] realRacePos = new int[(int)Enum.kMaxNumTeams];
			float[] tempRacePosition = new float[(int)Enum.kMaxNumTeams];
			for (int team = 0; team < numTeams; team++) {
				realRacePos [team] = (int)inData.racePos [team];
				markerPosition [team] = Utilities.GetRatioP1P2 (realRacePos [team], raceFrom, raceTo);
				overTakeThisFrame [team] = false;
				overTakeThisFramePlayer [team] = false;
			}

			if (numTeams > 1) {
				float[] inFrontBy = new float[(int)Enum.kMaxNumTeams];
				float[] inFrontByReal = new float[(int)Enum.kMaxNumTeams];
                for (int playerPair = 0; playerPair < (numTeams - 1); playerPair++) {
                    int frontPlayer = playerPosition[playerPair];
                    int behindPlayer = playerPosition[playerPair + 1];
                    inFrontBy[playerPair] = markerPosition[frontPlayer] - markerPosition[behindPlayer];
                    inFrontByReal[playerPair] = realRacePos[frontPlayer] - realRacePos[behindPlayer];
                }

                for (int i = 0; i < numTeams - 1; i++) {
                    markerPosition[playerPosition[i + 1]] -= (markerSize * ((float)(i + 1)));
                }

                int behindPlayer8 = playerPosition[numTeams - 1];
                if (markerPosition[behindPlayer8] < 0.0f) {
                    float offBottomBy = -markerPosition[behindPlayer8];
                    for (int i = 0; i < (numTeams - 1); i++) {
                        markerPosition[playerPosition[i]] += offBottomBy;
                        tempRacePosition[playerPosition[i]] = markerPosition[playerPosition[i]];
                    }

                    markerPosition[behindPlayer8] = 0.0f;
                    tempRacePosition[behindPlayer8] = markerPosition[behindPlayer8];
                }
                else {
                    for (int i = 0; i < numTeams; i++) tempRacePosition[i] = markerPosition[i];

                }

                for (int playerPair = 0; playerPair < (numTeams - 1); playerPair++) {
                    int frontPlayer = playerPosition[playerPair];
                    int behindPlayer = playerPosition[playerPair + 1];
                    if ((inFrontByReal[playerPair] <= overtakeDistance) && (playerState[behindPlayer] == RMPlayerState.kRMPlayer_Free) && (playerState[
                      frontPlayer] ==  RMPlayerState.kRMPlayer_Free)) {
                        this.StartOvertakeP1(behindPlayer, frontPlayer);
                    }

                    if (overTakingTimer[behindPlayer] > 0.0f) {
                        overTakingTimer[behindPlayer] -= Constants.kFrameRate;
                        float ratio = 1.0f - Utilities.GetRatioP1P2(overTakingTimer[behindPlayer], 0.0f, overTakeTime);
                        tempRacePosition[behindPlayer] += ratio * markerSize;
                        tempRacePosition[frontPlayer] -= ratio * markerSize;
                        if (overTakingTimer[behindPlayer] <= 0.0f) {
                            int pos = playerPosition[playerPair];
                            playerPosition[playerPair] = playerPosition[playerPair + 1];
                            playerPosition[playerPair + 1] = pos;
                            playerState[frontPlayer] = RMPlayerState.kRMPlayer_Free;
                            playerState[behindPlayer] = RMPlayerState.kRMPlayer_Free;
                            markerPosition[behindPlayer] += markerSize;
                            markerPosition[frontPlayer] -= markerSize;
                        }

                    }

                }

            }
            else {
                tempRacePosition[0] = markerPosition[0];
            }

            for (int team = 0; team < numTeams; team++) {
                CGPoint markerScreenPos = Utilities.CGPointMake(0,0);
                if (useLocator) {
                }
                else {
                    markerScreenPos = Utilities.GetPositionBetweenP1P2(tempRacePosition[playerPosition[team]], raceMarkerStartPos, raceMarkerFinishPos);
                }

                int displayPos = team;
                if (playerState[playerPosition[team]] == RMPlayerState.kRMPlayer_Overtaking) {
                    displayPos -= 1;
                }
                else if (playerState[playerPosition[team]] ==  RMPlayerState.kRMPlayer_BeingOvertaken) {
                    displayPos += 1;
                }

                (pMarker[playerPosition[team]]).SetScreenPosition(markerScreenPos);
                (pMarker[playerPosition[team]]).Update();
            }

        }

        public void Render()
        {
			if (Globals.g_world.worldState == WorldState.e_FrontEnd)
			{
				return;
			}
			if ((Globals.g_world.game.gameState == GameState.e_ShowLevel) ||
				(Globals.g_world.game.gameState == GameState.e_AnotherPiggy))
			{
				return;
			}
			
            pRaceTrack.RenderToDrawArrays();
            if (playerState[playerPosition[1]] ==  RMPlayerState.kRMPlayer_Overtaking) {
            }
            else {
            }

            for (int team = (numTeams - 1); team >= 0; team--) {
                (pMarker[playerPosition[team]]).RenderToDrawArrays();
            }

        }

    }
}
