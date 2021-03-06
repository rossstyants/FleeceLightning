using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Default.Namespace
{    public partial class Game
    {

				List<int> bridgesRenderedThisFrame = new List<int>();

        public void RenderOverlays()
        {
            (textureObject[(int) TextureType.kTexture_WarmOverlay]).DrawInRect(Utilities.CGRectMake(0, 0, Globals.g_world.screenWidth, Globals.g_world.screenHeight));
        }

        public void RenderLevelBuilder_Ross()
        {
            CGRect bounds = UIScreen.bounds;
            const float kMapScale = Constants.LEVEL_BUILDER_TILE_SCALE;
            tileMap.RenderSceneLevelBuilder_Ross((lBuilder.prevTileMapOffset - lBuilder.tileMapOffset));
            (DrawManager.Instance()).Begin(gameThingsAtlas);
            this.RenderMapObjectsToDrawArraysLevelBuilder_Ross( ListType.e_RenderUnderPlayer);
            this.RenderMapObjectsToDrawArraysLevelBuilder_Ross( ListType.e_RenderAbovePlayer);
            (DrawManager.Instance()).Flush();
            lBuilder.Render();
            (this.GetTexture((TextureType) TextureType.kTexture_LB_Back)).DrawInRect(bounds);
            lBuilder.RenderButtons();
            ////glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        public void RenderTrees()
        {
            (DrawManager.Instance()).Begin(gameThingsAtlas);
            this.RenderMapObjectsToDrawArrays( ListType.e_RenderTrees);
            (DrawManager.Instance()).Flush();
        }

        public void RenderThingsAbovePlayer()
        {
            (DrawManager.Instance()).Begin(gameThingsAtlas);
            this.RenderMapObjectsToDrawArrays( ListType.e_RenderAbovePlayer);
            (DrawManager.Instance()).Flush();
        }

        public void RenderThingsAbovePlayerFarm()
        {
            ////glEnableClientState (GL_COLOR_ARRAY);
            (DrawManager.Instance()).Begin(gameThingsAtlas);
            this.RenderMapObjectsToDrawArrays( ListType.e_RenderAbovePlayer);
            (DrawManager.Instance()).Flush();
            ////glDisableClientState (GL_COLOR_ARRAY);
        }

        public void RenderThingsBehindPlayer()
        {
            (DrawManager.Instance()).Begin(gameThingsAtlas);
            this.RenderMapObjectsToDrawArrays( ListType.e_RenderUnderPlayer);
            (DrawManager.Instance()).Flush();
        }

        public void RenderGatesUnderPlayer()
        {
        }

		public void PreRenderPlayers()
        {
			player.PreRenderRemoveSprites();
                for (int i = 0; i < lastPiggyIndex; i++) {
                    if (i != Constants.RECORDING_WHICH_PIGGY) {
                        (playerPiggy[i]).PreRenderRemoveSprites();
                    }

                }
        }

        public void RenderTracks()
        {
            this.RenderTrackMapObjectsToDrawArrays( ListType.e_RenderTracks);
        }

        public void RenderShadows()
        {
            player.RenderShadow();
            if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                for (int i = 0; i < lastPiggyIndex; i++) {
                    if (i != Constants.RECORDING_WHICH_PIGGY) {
                        (playerPiggy[i]).RenderShadow();
                    }

                }

            }

            this.RenderMapObjectsToDrawArrays( ListType.e_Shadows);
        }

        public void CheckAddPlayerToRenderListP1P2P3P4(PlayerHeight inHeight, Player inPlayer, int playerId, List<int> inList, List<int> inYPosList)
        {
            if ((inPlayer.positionZ >= playerHeightMin[(int)inHeight]) && (inPlayer.positionZ < playerHeightMax[(int)inHeight]))
			{
                float yValue = inPlayer.position.y;
                if ((inPlayer.positionZ > 10.0f) || (inPlayer.positionZ < -10.0f)) {
                    yValue += inPlayer.positionZ * 100.0f;
                    if (yValue < 0.0f) {
                        yValue /= 2000.0f;
                        yValue = 10.0f - yValue;
                        if (yValue < 0.0f) {
                            yValue = 0.0f;
                        }

                    }

                }

                Utilities.InsertThisObjectIntoOrderedListNewP1P2P3(playerId, yValue, inList, inYPosList);
            }
            else {
                Utilities.InsertThisObjectIntoOrderedListNewP1P2P3(playerId, -1.0f, inList, inYPosList);
            }

        }

        public void RenderBridgeAsSprite(int riverId)
        {
            (river[riverId]).RenderBridgeAsSprite();
        }

        public void RenderPlayers(PlayerHeight inHeight)
        {
            orderList.Clear();//RemoveAllObjects();
            yPosList.Clear();//RemoveAllObjects();
            this.CheckAddPlayerToRenderListP1P2P3P4(inHeight, player, 0, orderList, yPosList);
            for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
                this.CheckAddPlayerToRenderListP1P2P3P4(inHeight, playerPiggy[i], i + 1 - startFromPiggy, orderList, yPosList);
            }

            bool[] prevIsDrawn = new bool[Constants.MAX_PLAYERS];

			prevIsDrawn[0] = isDrawn[(int)inHeight,0];
			prevIsDrawn[1] = isDrawn[(int)inHeight,1];
			prevIsDrawn[2] = isDrawn[(int)inHeight,2];
			prevIsDrawn[3] = isDrawn[(int)inHeight,3];
			
			
			bool anybodyIsDrawn = false;
            //NSNumber item = null;
            foreach (int item in orderList) {
				int i = item;//.IntValue();

				float badHack = (float)(yPosList[i]);//.FloatValue();

				if (badHack < 0.0f) {
                    isDrawn[(int)inHeight,i] = false;
                    continue;
                }

                isDrawn[(int)inHeight,i] = false;
                if (i == 0) {
                    if (!anybodyIsDrawn) {
                        (DrawManager.Instance()).Begin(gameThingsAtlas);
                    }

                    isDrawn[(int)inHeight,i] = true;
                    anybodyIsDrawn = true;
                    player.RenderExtrasBeforePlayer();
                }
                else {
                    if (i > startFromPiggy) 
					{
                        if (this.IsOnScreenNewP1((playerPiggy[i - 1 + startFromPiggy]).GetScreenPosition(), 40.0f)) 
						{
                            if (!(playerPiggy[i - 1 + startFromPiggy]).isOnScreen) {
                                (playerPiggy[i - 1 + startFromPiggy]).SetIsOnScreen(true);
                                numPlayersOnScreen++;
                            }

                            if (!anybodyIsDrawn) {
                                (DrawManager.Instance()).Begin(gameThingsAtlas);
                            }

                            (playerPiggy[i - 1 + startFromPiggy]).RenderExtrasBeforePlayer();
                            isDrawn[(int)inHeight,i] = true;
                            anybodyIsDrawn = true;
                        }
                        else {
                            if ((playerPiggy[i - 1 + startFromPiggy]).isOnScreen) 
							{
                                (playerPiggy[i - 1 + startFromPiggy]).SetIsOnScreen(false);
                                numPlayersOnScreen--;
                            }

                        }

                    }

                }

            }
            if (!anybodyIsDrawn) {
                if (inHeight ==  PlayerHeight.t_High) {
                    (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_PiggyAnims));
                    this.RenderMapObjectsToDrawArrays( ListType.e_RenderGatesAbovePlayer);
                    (DrawManager.Instance()).Flush();
                }

                if ((playingCustom > 0) || (((Globals.g_world.frontEnd).profile).preferences.ghostOn)) 
				{
                    if (playingGhost.IsDrawn((int)inHeight)) 
					{
                        if (inHeight ==  PlayerHeight.t_High) {
                            ////glEnableClientState (GL_COLOR_ARRAY);
                        }

                        (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_PiggyAnims));
                        playingGhost.Render();
                        (DrawManager.Instance()).Flush();
                        if (inHeight ==PlayerHeight.t_High) {
                            ////glDisableClientState (GL_COLOR_ARRAY);
                        }

                    }

                }

                return;
            }

            (DrawManager.Instance()).Flush();
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_PiggyAnims));
            if (inHeight ==PlayerHeight.t_High) {
                this.RenderMapObjectsToDrawArrays( ListType.e_RenderGatesAbovePlayer);
            }

            foreach (int item2 in orderList) {
				int i = item2;//.IntValue();
                if (!isDrawn[(int)inHeight,i]) {
                    continue;
                }

                if (i == 0) {
					
            if (inHeight == (int) PlayerHeight.t_Low) 
			{
						int ross = 0;
					}					
					
					//Debug.Log ("player.RenderPlayer" + i + " " + Globals.renderCounter);										
					
                    player.RenderPlayer();
                }
                else {
                    (playerPiggy[i - 1 + startFromPiggy]).RenderPlayer();
                }

            }
            {
				
                if ((playingCustom > 0) || (((Globals.g_world.frontEnd).profile).preferences.ghostOn)) 
				{

					if (playingGhost.IsDrawn((int)inHeight)) 
					{
                        if (inHeight ==  PlayerHeight.t_High) {
                            ////glEnableClientState (GL_COLOR_ARRAY);
                        }

                        playingGhost.Render();
                    }

                }

            }
            (DrawManager.Instance()).Flush();
            if ((playingCustom > 0) || (((Globals.g_world.frontEnd).profile).preferences.ghostOn)) {
                if (inHeight ==  PlayerHeight.t_High) {
                    ////glDisableClientState (GL_COLOR_ARRAY);
                }

            }
			
//			if inHeight changes from normal to high or low then remove all tile sprites

            if (inHeight ==  PlayerHeight.t_Normal) 
			{
                if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
                    (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_GrassSpriteTiles));
                }
                else {
                    (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_MudSpriteTiles));
                }

                foreach (int item3 in orderList) {
					int i = item3;//.IntValue();

					if (!isDrawn[(int)inHeight,i]) 
					{
						if (prevIsDrawn[i])
						{
                    		if (i > 0) 
							{
                        		playerPiggy[i - 1 + startFromPiggy].StopRenderSpritesInFrontOfPlayer();
                    		}
						}
						
                        continue;
                    }

                    if (i == 0) 
					{
                        this.RenderSpritesInFrontOfPlayer(player);
                    }
                    else 
					{
                        this.RenderSpritesInFrontOfPlayer(playerPiggy[i - 1 + startFromPiggy]);
                    }

                }
                (DrawManager.Instance()).Flush();
            }

            (DrawManager.Instance()).Begin(gameThingsAtlas);
            int[] riverList = new int[Constants.MAX_PLAYERS];
            int inNumRivers = 0;
            foreach (int item in orderList) 
			{
				int i = item;//.IntValue();
                if (!isDrawn[(int)inHeight,i]) {
                    continue;
                }

                if (i == 0) 
				{
                    player.RenderExtrasAfterPlayer();
                    if (player.inRiver != -1) {
                        riverList[inNumRivers] = player.inRiver;
                        inNumRivers++;
												bridgesRenderedThisFrame.Add(player.inRiver);
//												Debug.Log("PLayer 0 is in river " + player.inRiver);
                    }

                }
                else {
                    (playerPiggy[i - 1 + startFromPiggy]).RenderExtrasAfterPlayer();
                    if ((playerPiggy[i - 1 + startFromPiggy]).inRiver != -1) 
					{
                        riverList[inNumRivers] = (playerPiggy[i - 1 + startFromPiggy]).inRiver;
                        inNumRivers++;
												bridgesRenderedThisFrame.Add((playerPiggy[i - 1 + startFromPiggy]).inRiver);

//												Debug.Log("Piggy whatever is in river " + playerPiggy[i - 1 + startFromPiggy].inRiver);

										}

								}
            }

            (DrawManager.Instance()).Flush();
            if (inHeight == (int) PlayerHeight.t_Low) 
			{
                for (int i = 0; i < inNumRivers; i++) 
				{
					//Debug.Log ("RenderBridgeAsSprite" + i + " " + Globals.renderCounter);					
					
                    this.RenderBridgeAsSprite(riverList[i]);
                }
				if (!isPlayerLow)
					isPlayerLow = true;
            }

						if (inHeight == PlayerHeight.t_High)
						{
								//make sure the renderer is stopped on all the other rivers...
//								for (int i = 0; i < numRivers; i++) 
//								{
//										bool beingDrawn = false;
//										foreach (int j in bridgesRenderedThisFrame) 
//										{
//												if (i == j)
//												{
//														//this river is being drawn
//														beingDrawn = true;
//														break;
//												}
//										}
//										if(!beingDrawn)
//										{
//												river[i].StopRenderBridgeAsSprite();
//										}
//								}
						}			


        }

        public void RenderNumPlayers()
        {
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glLoadIdentity();
            //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
            Globals.g_world.DoGLTranslateP1(60.0f, 60.0f);
            (Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers)).DrawAtPoint(numPlayersOnScreen);
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPopMatrix();
        }

        public void RenderScreenEdge()
        {
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glLoadIdentity();
            float renderScale = Globals.g_world.renderScale;
            //glTranslatef(0.0f, (480.0f * (1.0f - renderScale)), 0.0f);
            //glScalef(renderScale * Constants.kScaleForShorts, renderScale * Constants.kScaleForShorts, 0.0f);
            CGPoint mapPos = Utilities.CGPointMake(Globals.g_world.leftDrawEdge + scrollPosition.x, scrollPosition.y + 100);
            CGPoint mapPos2 = Utilities.CGPointMake(Globals.g_world.leftDrawEdge + scrollPosition.x + Globals.g_world.drawWidth, scrollPosition.y + 100);
            float centreX = (mapPos.x + mapPos2.x) / 2.0f;
            CGPoint mapPos3 = Utilities.CGPointMake(centreX, scrollPosition.y);
            CGPoint mapPos4 = Utilities.CGPointMake(centreX, scrollPosition.y + Globals.g_world.mapObjectAppearDistance - 50.0f);
            CGPoint sPos = this.GetScreenPosition(mapPos);
            CGPoint sPos2 = this.GetScreenPosition(mapPos2);
            CGPoint sPos3 = this.GetScreenPosition(mapPos3);
            CGPoint sPos4 = this.GetScreenPosition(mapPos4);
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud));
          //  (DrawManager.Instance()).AddTextureToListP1(sPos, (int)World.Enum2.kGTMud_Rainbow);
         //   (DrawManager.Instance()).AddTextureToListP1(sPos2, (int)World.Enum2.kGTMud_Rainbow);
          //  (DrawManager.Instance()).AddTextureToListP1(sPos3, (int)World.Enum2.kGTMud_Rainbow);
          //  (DrawManager.Instance()).AddTextureToListP1(sPos4, (int)World.Enum2.kGTMud_Rainbow);
            (DrawManager.Instance()).Flush();
        }

        public void DrawRacingLine()
        {
            for (int i = startFromPiggy; i < lastPiggyIndex; i++) {
                if (i != Constants.RECORDING_WHICH_PIGGY) {
                    ((playerPiggy[i]).racingBrain).Render();
                }

            }

        }

        public void RenderSceneAnotherPiggy()
        {
            hud.Render();
        }

        public void RenderScene()
        {
            if ((gameState == GameState.e_AnotherPiggy) || (gameState == GameState.e_FeelGoodScreen) || (gameState == GameState.e_ShowLevel))
              {
                this.RenderSceneAnotherPiggy();
                if (gameState == GameState.e_ShowLevel) 
								{
 //                   Globals.g_world.RenderPullTab();
                }

                return;
            }

            //glDisable (GL_BLEND);
			if (!shownHudYet)
			{
	            this.RenderTileMap();

				//glEnable (GL_BLEND);
            ////glEnableClientState (GL_COLOR_ARRAY);
            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPopMatrix();
            if (false) {
                //glLoadIdentity();
                float renderScale = Globals.g_world.renderScale;
                //glTranslatef((320.0f * (1.0f - renderScale)) / 2.0f, (480.0f * (1.0f - renderScale)), 0.0f);
                //glScalef(renderScale * Constants.kScaleForShorts, renderScale * Constants.kScaleForShorts, 0.0f);
            }
            else {
                //glLoadIdentity();
                float renderScale = Globals.g_world.renderScale;
                //glScalef(renderScale * Constants.kScaleForShorts, renderScale * Constants.kScaleForShorts, 0.0f);
                float scaleThing;
                if (Globals.deviceIPad) {
                    scaleThing = 2.0f;
                }
                else {
                    scaleThing = 1.0f;
                }

                float yOffset = scaleThing * (Globals.g_world.drawHeight - Globals.g_world.coordinatesHeight);
                //glTranslatef(0.0f, yOffset * Constants.kScreenMultiplierForShorts, 0);
            }

								#if PROFILING_OUT
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.Start_RenderScene_1] = DateTime.Now.TimeOfDay.Milliseconds;
								#endif


            (DrawManager.Instance()).Begin(gameThingsAtlas);
            this.RenderTracks();
								#if PROFILING_OUT
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.End_RenderScene_1] = DateTime.Now.TimeOfDay.Milliseconds;
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.Start_RenderScene_2] = DateTime.Now.TimeOfDay.Milliseconds;
								#endif

								this.RenderShadows();
            (DrawManager.Instance()).Flush();
            (ParticleSystemRoss.Instance()).RenderSceneDownLow();
				
			this.PreRenderPlayers();	
								#if PROFILING_OUT
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.End_RenderScene_2] = DateTime.Now.TimeOfDay.Milliseconds;
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.Start_RenderScene_3] = DateTime.Now.TimeOfDay.Milliseconds;
								#endif
				
			bool wasPlayerLow = isPlayerLow;				
			isPlayerLow = false;

								bridgesRenderedThisFrame.Clear();
            this.RenderPlayers( PlayerHeight.t_Low);
				
				if (wasPlayerLow)
				{
					if (!isPlayerLow)
					{
		                for (int i = 0; i < numRivers; i++) {
            				(river[i]).StopRenderBridgeAsSprite();
		                }						
					}
				}
//								else
//								{
//										for (int i = 0; i < numRivers; i++) 
//										{
//												for (int j = 0; i < numRivers; i++) 
//												{
//												(river[i]).StopRenderBridgeAsSprite();
//												}
//										}						
//								}
				
            #if DEBUG_DRAW_RACING_LINE
                for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Flock]; i++) {
                }

                this.DrawRacingLine();
            #endif

            this.RenderThingsBehindPlayer();
            (ParticleSystemRoss.Instance()).RenderSceneBeforePlayer();

								#if PROFILING_OUT
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.End_RenderScene_3] = DateTime.Now.TimeOfDay.Milliseconds;
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.Start_RenderScene_4] = DateTime.Now.TimeOfDay.Milliseconds;
								#endif

            //glBlendFunc(GL_ONE, GL_ONE_MINUS_SRC_ALPHA);
            if ((playingCustom > 0) || (((Globals.g_world.frontEnd).profile).preferences.ghostOn)) {
            }
//				RenderTracks
				
            this.RenderPlayers( PlayerHeight.t_Normal);
            Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartThings] = DateTime.Now.TimeOfDay.Milliseconds;
            if (lBuilder.currentScene == (int) SceneType.kSceneMud) {
                this.RenderThingsAbovePlayerFarm();
            }
            else {
                this.RenderThingsAbovePlayer();
            }

								#if PROFILING_OUT
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.End_RenderScene_4] = DateTime.Now.TimeOfDay.Milliseconds;
								Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.Start_RenderScene_5] = DateTime.Now.TimeOfDay.Milliseconds;
								#endif


            this.RenderPlayers( PlayerHeight.t_High);

								for (int i = 0; i < numRivers; i++) 
								{
										bool beingDrawn = false;
										foreach (int j in bridgesRenderedThisFrame) 
										{
												if (i == j)
												{
														//this river is being drawn
														beingDrawn = true;
														break;
												}
										}
										if(!beingDrawn)
										{
												river[i].StopRenderBridgeAsSprite();
										}
								}


            Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndThings] = DateTime.Now.TimeOfDay.Milliseconds;
            Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartTrees] = DateTime.Now.TimeOfDay.Milliseconds;
            this.RenderTrees();
          //  ////glEnableClientState (GL_COLOR_ARRAY);
            (ParticleSystemRoss.Instance()).RenderScene();
            //////glDisableClientState (GL_COLOR_ARRAY);

            #if RENDER_PIG_NUMBERS
                (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_FontNumbers));
                for (int i = 0; i < 3; i++) {
                    (playerPiggy[i]).RenderNumber();
                }

                (DrawManager.Instance()).Flush();
            #endif

            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glLoadIdentity();
            //glScalef(Constants.kScaleForShorts, Constants.kScaleForShorts, 0.0f);
            this.RenderOverlays();
            
							}

				
				hud.Render();

						#if PROFILING_OUT
						Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.End_RenderScene_5] = DateTime.Now.TimeOfDay.Milliseconds;
						#endif


            #if TEST_NUM_PLAYERS_ON_SCREEN
                this.RenderNumPlayers();
            #endif

            #if TEST_SCREENEDGE
                this.RenderScreenEdge();
            #endif

        }

        public void RenderSpriteTilesP1P2P3P4(Player inPlayer, int backCorner, int yNextPlayerTile, int xStartTile, int atlasId)
        {
            int numTilesPast = ((Globals.g_world.game).tileMap).tileYOffset - (int)TileMap.kTilesHigh;
            backCorner += (int)TileMap.kTilesWide;
            for (int y = 0; y < 3; y++) 
			{
                backCorner -= (int)TileMap.kTilesWide;
                if (backCorner < 0) 
				{	
					inPlayer.myAtlasBillboard[(int)PlayerBillboards.kBB_SpriteTile1 + (y*2)].StopRender();
					inPlayer.myAtlasBillboard[(int)PlayerBillboards.kBB_SpriteTile1 + (y*2) + 1].StopRender();
						
				//	return;
				}
				else{
                for (int i = xStartTile; i < (xStartTile + 2); i++) {
					
					int spriteTileId = y*2 + (i- xStartTile);
					
                    int physicalTile = i + backCorner;
                    Tile tile = tileMap.GetTile(physicalTile);
                    if (tile.spriteAtlasId != atlasId)
					{
						inPlayer.myAtlasBillboard[(int)PlayerBillboards.kBB_SpriteTile1 + spriteTileId].StopRender();						
						continue;
					}
					
                    if ((y > 1) && tile.spriteSubOneDeep) 
					{
						inPlayer.myAtlasBillboard[(int)PlayerBillboards.kBB_SpriteTile1 + spriteTileId].StopRender();						
						continue;
					}
					
                    CGPoint tileScreenPos = tile.GetScreenPosition();
                    //tileScreenPos.x -= 128.0f;
					tileScreenPos.x += 32.0f;
                    float tileMapYOffset = (float) numTilesPast * 64.0f;
                    CGPoint mapPosition = Utilities.CGPointMake(tileScreenPos.x, tileScreenPos.y + tileMapYOffset);
                    
					if ((mapPosition.y - inPlayer.position.y) > 75.0f) {
						inPlayer.myAtlasBillboard[(int)PlayerBillboards.kBB_SpriteTile1 + spriteTileId].StopRender();						                       
						continue;
                    }

                    CGPoint onScreenPosition = this.GetScreenPosition(mapPosition);
					onScreenPosition.y = tileScreenPos.y;
						
                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(inPlayer.myAtlasBillboard[(int)PlayerBillboards.kBB_SpriteTile1 + spriteTileId], 
						onScreenPosition,1.0f,0.0f,0.0f,1.0f, tile.spriteSubTextureId);
                }
				}

            }

        }

        public void RenderSpritesInFrontOfPlayer(Player inPlayer)
        {
            if (inPlayer.positionZ > 20.0f) 
			{
				if (inPlayer.prevPositionZ <= 20.0f)
				{
					for (int i = 0; i < 6; i++)
					{
						inPlayer.myAtlasBillboard[i + (int)PlayerBillboards.kBB_SpriteTile1].StopRender();
					}
				}
				
				return;
			}
            if (inPlayer.disableSpriteTiles) {
                return;
            }

            if (gameState == GameState.e_GetReady) return;

            int yNextPlayerTile = inPlayer.yCurrentTile + 2;
            int yRowOffset = yNextPlayerTile - (tileMap.tileYOffset - (int)TileMap.kTilesHigh);
            if (yRowOffset < 0) yRowOffset = 0;

            int backCorner = (tileMap.GetBackCornerTile() + (yRowOffset * (int)TileMap.kTilesWide));
            backCorner = backCorner % ((int)TileMap.Enum3.kNumTiles);
            int xStart = -1 + (int) ((inPlayer.position.x + 32.0f) / 64.0f);
            xStart += 2;
            if (lBuilder.currentScene == (int) SceneType.kSceneGrass) 
			{
                this.RenderSpriteTilesP1P2P3P4(inPlayer, backCorner, yNextPlayerTile, xStart, (int) AtlasType.kAtlas_GrassSpriteTiles);
            }
            else if (lBuilder.currentScene == (int) SceneType.kSceneMud) 
			{
                this.RenderSpriteTilesP1P2P3P4(inPlayer, backCorner, yNextPlayerTile, xStart, (int) AtlasType.kAtlas_MudSpriteTiles);
            }

        }

//        public void RenderThisMapObject(int i)
//        {
//            if ((mapObject[i]).atlas != null) {
//                if ((mapObject[i]).alpha == 1) {
//                    ((mapObject[i]).atlas).DrawAtPoint((mapObject[i]).subTextureId);
//                }
//                else {
//                    ((mapObject[i]).atlas).DrawAtPointAlphaP1((mapObject[i]).subTextureId, (mapObject[i]).alpha);
//                }
//
//            }
//            else {
//                if ((mapObject[i]).scale == 1) {
//                    if ((mapObject[i]).alpha == 1) {
//                        ((mapObject[i]).texture).DrawAtPoint();
//                    }
//                    else {
//                        ((mapObject[i]).texture).DrawAtPointAlpha((mapObject[i]).alpha);
//                    }
//
//                }
//                else {
//                    if ((mapObject[i]).alpha == 1) {
//                        ((mapObject[i]).texture).DrawAtPointScaled((mapObject[i]).scale);
//                    }
//                    else {
//                        ((mapObject[i]).texture).DrawAtPointScaledAlphaP1((mapObject[i]).scale, (mapObject[i]).alpha);
//                    }
//
//                }
//
//            }
//
//        }

        public bool IsOnScreenNewP1P2(CGPoint screenPosition, float xBuffer, float yBuffer)
        {
            if ((screenPosition.x < (Globals.g_world.drawWidth + xBuffer)) && (screenPosition.x > -xBuffer)) {
                return ((screenPosition.y < (Globals.g_world.mapObjectAppearDistance + yBuffer)) && (screenPosition.y > -yBuffer));
            }

            return false;
        }

        public bool IsOnScreenNewP1(CGPoint screenPosition, float buffer)
        {
            if ((screenPosition.x < (Globals.g_world.drawWidth + buffer)) && (screenPosition.x > -buffer)) {
                return ((screenPosition.y < Globals.g_world.mapObjectAppearDistance + buffer) && (screenPosition.y > -buffer));
            }

            return false;
        }

        public bool IsOnScreenP1(CGPoint screenPosition, float buffer)
        {
            if ((screenPosition.x < (Globals.g_world.coordinatesHeight + buffer)) && (screenPosition.x > -160.0f - buffer)) {
                return ((screenPosition.y < Globals.g_world.mapObjectAppearDistance + buffer) && (screenPosition.y > -buffer));
            }

            return false;
        }

        public bool IsOnScreenP1P2(CGPoint screenPosition, float buffer, float mapObjectAppearDistance)
        {
            if ((screenPosition.x < (Globals.g_world.coordinatesHeight + buffer)) && (screenPosition.x > -160.0f - buffer)) {
                return ((screenPosition.y < mapObjectAppearDistance + buffer) && (screenPosition.y > -buffer));
            }

            return false;
        }

        public bool IsOnScreen(CGPoint screenPosition)
        {
            if ((screenPosition.x < (Globals.g_world.coordinatesHeight)) && (screenPosition.x > -160.0f)) {
                return ((screenPosition.y < Globals.g_world.mapObjectAppearDistance) && (screenPosition.y > 0));
            }

            return false;
        }

        public void RenderTrackMapObjectsToDrawArrays(ListType listType)
        {
            int i = usedListHead[(int)listType];
            while (i != -1) {
                (mapObject[i]).UpdateScreenPos(scrollPosition);
                if (this.HasLeftScreen((mapObject[i]).GetScreenPos())) {
                    if ((mapObject[i]).isSelfRemoving) {
                        (mapObject[i]).SetFlaggedToRemoveNextFrame(true);
                    }

                }

                CGPoint displayPos = (mapObject[i]).GetScreenPos();
                if (inLevelBuilder) {
                    displayPos.x *= Constants.LEVEL_BUILDER_TILE_SCALE;
                    displayPos.y *= Constants.LEVEL_BUILDER_TILE_SCALE;
                }

                if ((Globals.g_world.game).IsOnScreenP1P2(displayPos, 15.0f, Globals.g_world.mapObjectAppearDistance) &&
					(mapObject[i]).alpha > 0.05f) 
				{
					
					(DrawManager.Instance()).AddTextureToListP1P2P3P4P5(mapObject[i].myAtlasBillboard, displayPos, (mapObject[i]).scale, (mapObject[i]).rotation, (mapObject[i]).
                      rotationScale, (mapObject[i]).alpha, (mapObject[i]).subTextureId);
				}
				else
				{
					if (mapObject[i].myAtlasBillboard != null)
						mapObject[i].myAtlasBillboard.StopRender();
				}

                i = (mapObject[i]).GetNext();
            }

        }

        public void RenderMapObjectsToDrawArraysLevelBuilder_Ross(ListType listType)
        {
            int i = usedListHead[(int)listType];
            while (i != -1) {
                (mapObject[i]).UpdateScreenPosLevelBuilder_Ross(scrollPosition);
                CGPoint displayPos = (mapObject[i]).GetScreenPos();
                if (Globals.deviceIPad) {
                    displayPos.x += 32.0f;
                    displayPos.y -= 10.0f;
                }

                bool showIt;
                if (Globals.deviceIPad) {
                    showIt = ((displayPos.y < 440.0f) && (displayPos.y > -235.0f));
                }
                else {
                    showIt = ((displayPos.y < 380.0f) && (displayPos.y > -720.0f));
                }

                if (showIt)
				{
//					(DrawManager.Instance()).AddTextureToListP1P2P3P4P5(displayPos, (mapObject[i]).scale, (mapObject[i]).rotation, (mapObject[i]).
  //                rotationScale, (mapObject[i]).alpha, (mapObject[i]).subTextureId);

                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(mapObject[i].myAtlasBillboard, displayPos, (mapObject[i]).scale, (mapObject[i]).rotation, (mapObject[i]).
                      rotationScale, (mapObject[i]).alpha, (mapObject[i]).subTextureId);
				
				}
				
                i = (mapObject[i]).GetNext();
            }

        }

        public void RenderMapObjectsToDrawArrays(ListType listType)
        {
            int i = usedListHead[(int)listType];
            while (i != -1) {
                (mapObject[i]).UpdateScreenPos(scrollPosition);
                if (this.HasLeftScreen((mapObject[i]).GetScreenPos())) {
                    if ((mapObject[i]).isSelfRemoving) {
                        (mapObject[i]).SetFlaggedToRemoveNextFrame(true);
                    }

                }

                CGPoint displayPos = (mapObject[i]).GetScreenPos();

                    if ((displayPos.y <= (Globals.g_world.mapObjectAppearDistance + 50.0f)) && 
						(displayPos.y > -50) && (displayPos.x > -100.0f) && 
						(displayPos.x < (Globals.g_world.drawWidth + 100.0f)) &&
						((mapObject[i]).alpha > 0.05f))
                {
//                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(mapObject[i].myAtlasBillboard, displayPos, (mapObject[i]).scale, (mapObject[i]).rotation, (mapObject[i]).
 //                     rotationScale, (mapObject[i]).alpha, (mapObject[i]).subTextureId);
                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(mapObject[i].myAtlasBillboard, displayPos, (mapObject[i]).scale, (mapObject[i]).rotation, (mapObject[i]).
                      rotationScale, 1.0f, (mapObject[i]).subTextureId);
                }
				else
				{
					if (mapObject[i].myAtlasBillboard != null)
						mapObject[i].myAtlasBillboard.StopRender();
				}
                i = (mapObject[i]).GetNext();
            }

        }

//        public void RenderMapObjects(ListType listType)
//        {
//
//            #if RECORDING_SIMULATOR_VIDEO_FULL_FRAMERATE
//                return;
//            #endif
//
//            int i = usedListHead[(int)listType];
//            while (i != -1) {
//                (mapObject[i]).UpdateScreenPos(scrollPosition);
//
//                #if TEST_SHORTS
//                    //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
//                #endif
//
//                //glPushMatrix();
//                CGPoint displayPos = (mapObject[i]).GetScreenPos();
//                if (inLevelBuilder) {
//                    displayPos.x *= Constants.LEVEL_BUILDER_TILE_SCALE;
//                    displayPos.y *= Constants.LEVEL_BUILDER_TILE_SCALE;
//                }
//
//                Globals.g_world.DoGLTranslateP1(displayPos.x, displayPos.y);
//                if ((mapObject[i]).GetRotation() != 0) {
//                    //glRotatef((mapObject[i]).GetRotation() * (360.0 / (2.0 * Constants.PI_)), 0, 0, 1);
//                }
//
//                this.RenderThisMapObject(i);
//
//                #if TEST_SHORTS
//                    //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
//                #endif
//
//                //glPopMatrix();
//                i = (mapObject[i]).GetNext();
//            }
//
//        }

        public void AddHedgeP1P2(int xPos, int yPos, int width)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_Hedges],  (int)Enum2.kMaxHedges)) {
                return;
            }

            if (hedge[numGameObject[(int) GameObjectType.kGameObject_Hedges]] == null) {
                hedge[numGameObject[(int) GameObjectType.kGameObject_Hedges]] = new Hedge();
            }

            gatePos[numGameObject[(int) GameObjectType.kGameObject_Hedges]] = Utilities.CGPointMake(xPos, yPos);
            gateWidth[numGameObject[(int) GameObjectType.kGameObject_Hedges]] = width;
            int noGoZoneId = this.AddNoGoZoneP1P2(xPos - (width / 2), yPos + 14, 8);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_GatePost);
            noGoZoneId = this.AddNoGoZoneP1P2(xPos + (width / 2), yPos + 14, 8);
            (noGoZone[noGoZoneId]).SetType(NoGoType.e_GatePost);
            (hedge[numGameObject[(int) GameObjectType.kGameObject_Hedges]]).AddToScene();
            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_Hedges, yPos);
            numGameObject[(int) GameObjectType.kGameObject_Hedges]++;
        }

		public int AddNoGoZoneP1P2 (float xPos, float yPos, float radius)
		{    
			return this.AddNoGoZoneP1P2((int)xPos,(int)yPos,(int)radius);
		}																																																																																																																																																																																																																																																																																		

        public int AddNoGoZoneP1P2(int xPos, int yPos, int radius)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_NoGoZones],  (int)Enum2.kMaxNoGoZones)) {
                return 0;
            }

            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_NoGoZones, yPos);
            if (noGoZone[numGameObject[(int) GameObjectType.kGameObject_NoGoZones]] == null) {
                noGoZone[numGameObject[(int) GameObjectType.kGameObject_NoGoZones]] = new NoGoZone();
            }

            (noGoZone[numGameObject[(int) GameObjectType.kGameObject_NoGoZones]]).InitialiseP1(Utilities.CGPointMake(xPos, yPos), (float) radius);
            numGameObject[(int) GameObjectType.kGameObject_NoGoZones]++;
            return numGameObject[(int) GameObjectType.kGameObject_NoGoZones] - 1;
        }

        int AddNoGoZoneP1(CGPoint pos, int radius)
        {
            return this.AddNoGoZoneP1P2((int) (pos.x), (int) (pos.y), radius);
        }

        public void AddRainbowTilePosP1P2P3(float yTilePos, float xTilePos, float yPos, float xPos)
        {
            this.AddRainbowP1((32 + xPos + (xTilePos * 64.0f)), (32 + yPos + (yTilePos * 64)));
        }

        public void AddRainbowTilePosP1(float yPos, float xPos)
        {
            this.AddRainbowP1((32 + (xPos * 64.0f)), (32 + (yPos * 64)));
        }

        public bool CheckNumObjectsP1(int inCount, int inMax)
        {
                return (inCount >= inMax);

        }

        public void AddRainbowP1(float xPos, float yPos)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_Rainbows],  (int)Enum2.kMaxRainbows)) {
                return;
            }

            Rainbow.RainbowInfo info = new Rainbow.RainbowInfo();
            info.position = Utilities.CGPointMake(xPos, yPos + 8);
            info.mapObjectId = this.AddMapObjectP1P2P3(0, (int) xPos, (int) yPos,  ListType.e_RenderUnderPlayer);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            if (lBuilder.currentScene == (int) SceneType.kSceneGrass) (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_Rainbow);
            else if (lBuilder.currentScene == (int) SceneType.kSceneMud) (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_Rainbow);
            else if (lBuilder.currentScene == (int) SceneType.kSceneIce) (mapObject[info.mapObjectId]).SetSubTextureId(5);
            else {
                (mapObject[info.mapObjectId]).SetSubTextureId(48);
            }

            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_Rainbows, info.position.y);
            if (rainbow[numGameObject[(int) GameObjectType.kGameObject_Rainbows]] == null) {
                rainbow[numGameObject[(int) GameObjectType.kGameObject_Rainbows]] = new Rainbow();
            }

            (rainbow[numGameObject[(int) GameObjectType.kGameObject_Rainbows]]).Initialise(info);
            numGameObject[(int) GameObjectType.kGameObject_Rainbows]++;
        }

        public void AddStarSpeedUpP1(float xPos, float yPos)
        {
            return;
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_StarSpeedUp],  (int)Enum2.kMaxStarSpeedUps)) {
                return;
            }

            StarSpeedUp.StarSpeedUpInfo info = new StarSpeedUp.StarSpeedUpInfo();
            info.position = Utilities.CGPointMake(xPos, yPos - 8);
            info.mapObjectId = this.AddMapObjectP1P2P3( TextureType.kTexture_Rainbow, (int) xPos, (int) yPos,  ListType.e_RenderUnderPlayer);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            if (lBuilder.currentScene == (int) SceneType.kSceneGrass) (mapObject[info.mapObjectId]).SetSubTextureId(3);
            else {
                (mapObject[info.mapObjectId]).SetSubTextureId(64);
            }

            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_StarSpeedUp, info.position.y);
            if (starSpeedUp[numGameObject[(int) GameObjectType.kGameObject_StarSpeedUp]] == null) {
                starSpeedUp[numGameObject[(int) GameObjectType.kGameObject_StarSpeedUp]] = new StarSpeedUp();
            }

            (starSpeedUp[numGameObject[(int) GameObjectType.kGameObject_StarSpeedUp]]).Initialise(info);
            numGameObject[(int) GameObjectType.kGameObject_StarSpeedUp]++;
        }

        public void AddBoostArrowP1(float xPos, float yPos)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_BoostArrows],  (int)Enum2.kMaxBoostArrows)) {
                return;
            }

            BoostArrow.ArrowInfo info = new BoostArrow.ArrowInfo();
            info.position = Utilities.CGPointMake(xPos, yPos);
            info.mapObjectId = this.AddMapObjectP1P2P3( TextureType.kTexture_BoostArrowStraightDown1, (int) xPos, (int) yPos,  ListType.
              e_RenderUnderPlayer);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            if (lBuilder.currentScene == (int) SceneType.kSceneGrass) (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_PicnicBlanket);
            else (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_PicnicBlanket);

            (mapObject[info.mapObjectId]).SetType( MapObjectType.e_BoostPicnic);
            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_BoostArrows, info.position.y);
            if (boostArrow[numGameObject[(int) GameObjectType.kGameObject_BoostArrows]] == null) {
                boostArrow[numGameObject[(int) GameObjectType.kGameObject_BoostArrows]] = new BoostArrow();
            }

            (boostArrow[numGameObject[(int) GameObjectType.kGameObject_BoostArrows]]).Setup(info);
            numGameObject[(int) GameObjectType.kGameObject_BoostArrows]++;
        }

        public void AddHedgeToSceneP1P2(int yPos, int gateStart, int width)
        {
            tileMap.AddHedgeP1P2(yPos, gateStart, width);
            this.AddHedgeP1P2((gateStart * 32) + (width * 16), (yPos * 64), (width * 32));
        }

        public void AddFlowerBunchP1P2P3(int yTilePos, int xTilePos, int yPos, int xPos)
        {
            float xFinal = 32 + (xTilePos * 64) + xPos;
            float yFinal = -64 + (yTilePos * 64) + yPos;
            this.AddFlowerBunchP1P2((int)yFinal, (int)xFinal, (int) FlowerBunchType.kFlowerBunch_Daffodil);
        }

        public void InsertThisObjectIntoListP1(GameObjectType objectType, float inYPos)
        {
            this.InsertThisObjectIntoOrderedListP1P2P3(numGameObject[(int)objectType], inYPos, updateOrder[(int)objectType], yPositionListForStart[(int)objectType]);
        }

        public void InsertThisObjectIntoOrderedListP1P2P3(int objectId, float inYPos, List<int> inList, List<int> inYPosList)
        {
           // NSNumber item = null;
            int i = 0;
            int index = -1;
            foreach (int item in inList) {
				int whatIsIndex = item;//.IntValue();
				float yPos = (float)(inYPosList[whatIsIndex]);//.FloatValue();
                if (inYPos < yPos) {
                    index = i;
                    break;
                }

                i++;
            }
			if (index == -1) inList.Add (objectId);//AddObject(NSNumber.NumberWithInt(objectId));
            else {
				inList.Insert(index,objectId);// ObjectAtIndex(NSNumber.NumberWithInt(objectId), index);
            }

			inYPosList.Add((int)inYPos);// Object(NSNumber.NumberWithFloat(inYPos));
         }

        public void InsertThisCowIntoListP1P2(int objectId, float inYPos, List<int> inList)
        {
          //  NSNumber item = null;
            int i = 0;
            int index = -1;
            foreach (int item in inList) {
                float yPos = cow[item].position.y;
                if (inYPos < yPos) {
                    index = i;
                    break;
                }

                i++;
            }
			if (index == -1) inList.Add(objectId);// Object(NSNumber.NumberWithInt(objectId));
            else {
				inList.Insert(index,objectId);// ObjectAtIndex(NSNumber.NumberWithInt(objectId), index);
            }

        }

        public void AddBushP1(int inType, CGPoint position)
        {
            this.AddFlowerBunchP1P2((int) position.y, (int) position.x, (int) FlowerBunchType.kFlowerBunch_Tulips);
        }

		public void AddFlowerBunchP1P2 (float yPos, float xPos, int inType)
		{
				this.AddFlowerBunchP1P2 ((int)yPos, (int)xPos, inType);
		}

        public void AddFlowerBunchP1P2(int yPos, int xPos, int inType)
        {
			//Debug.Log("numFlowerBunches = " + numGameObject[(int) GameObjectType.kGameObject_FlowerBunches]);
			
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_FlowerBunches],  (int)Enum2.kMaxFlowerBunches)) 
			{
                return;
            }

            #if UP_RACE
                yPos -= 42.0f;
            #endif

//			int pee = (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop;

            if (playingCustom == 0) {
                int realLevelId = LevelBuilder_Ross.levelOrder[((Globals.g_world.frontEnd).profile).selectedLevel];
                if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop) {
                    if (yPos < 6000) {
                        yPos += 12;
                    }

                }

            }

            FlowerBunch.FlowerBunchInfo info = new FlowerBunch.FlowerBunchInfo();
            info.mapObjectId = this.AddMapObjectP1P2P3( TextureType.kTexture_FlowerBunchWith, xPos, yPos,  ListType.e_RenderAbovePlayer);
            info.position = Utilities.CGPointMake(xPos, yPos);
            info.type = (FlowerBunchType) inType;
            (mapObject[info.mapObjectId]).SetType( MapObjectType.e_FlowerBunch);
            if (this.IsMapObjectIdInvalid(info.mapObjectId)) return;

            if (inType == (int) FlowerBunchType.kFlowerBunch_Sunflowers) {
                (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_Flowers);
            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_Daffodil) {
                (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_Flowers);
            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_Tulips) {
                if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_TulipsRed);
                }
                else {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_TulipsRed);
                }

            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_TulipsWhite) {
                if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_TulipWhite);
                }
                else {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_TulipWhite);
                }

            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_TulipsYellow) {
                if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_TulipsYellow);
                }
                else {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_TulipsYellow);
                }

            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_TulipsBlue) {
                if (lBuilder.currentScene == (int) SceneType.kSceneGrass) {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum3.kGTGrass_TulipsBlue);
                }
                else {
                    (mapObject[info.mapObjectId]).SetSubTextureId((int)World.Enum2.kGTMud_TulipsBlue);
                }

            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_Lilac) {
                (mapObject[info.mapObjectId]).SetSubTextureId(32);
            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_JunglePurple) {
               // (mapObject[info.mapObjectId]).SetSubTextureId(kGTJungle_FlowersPurp);
            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_Pink) {
                (mapObject[info.mapObjectId]).SetSubTextureId(33);
            }
            else if (inType == (int) FlowerBunchType.kFlowerBunch_SavannaBush) {
            //    (mapObject[info.mapObjectId]).SetSubTextureId(kGTSavanna_Bush);
            }
            else {
                Globals.Assert(false);
            }

            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_FlowerBunches, info.position.y);
            if (flowerBunch[numGameObject[(int) GameObjectType.kGameObject_FlowerBunches]] == null) {
                flowerBunch[numGameObject[(int) GameObjectType.kGameObject_FlowerBunches]] = new FlowerBunch(numGameObject[(int) GameObjectType.
                  kGameObject_FlowerBunches]);
            }

            (mapObject[info.mapObjectId]).SetObjectId(numGameObject[(int) GameObjectType.kGameObject_FlowerBunches]);
            (flowerBunch[numGameObject[(int) GameObjectType.kGameObject_FlowerBunches]]).AddToScene(info);
            numGameObject[(int) GameObjectType.kGameObject_FlowerBunches]++;
        }

        public void AddRiverP1P2(int yPos, int xPos, int width)
        {
            if (this.CheckNumObjectsP1(numRivers,  (int)Enum2.kMaxRivers)) {
                return;
            }

            tileMap.AddRiverP1P2(xPos, yPos, width);
            int mapX = 32 + (xPos * 64);
            int mapY = 32 + (yPos * 64);
            if (width == 2) mapX += 32;

            FlowerCliff.RiverInfo info = new FlowerCliff.RiverInfo();
            info.xPosBridge = mapX;
            info.yPos = mapY;
            info.widthBridge = width * 64;
            info.tileWidth = 6;
            info.riverType = RiverType.e_Country;
            (river[numRivers]).Initialise(info);
            numRivers++;
        }

        public void AddCrocRiver(CGPoint tilePosition)
        {
            if (this.CheckNumObjectsP1(numRivers,  (int)Enum2.kMaxRivers)) {
                return;
            }

            FlowerCliff.RiverInfo info = new FlowerCliff.RiverInfo();
            info.xPosBridge = -4;
            info.yPos = 32 + (int) (tilePosition.y * 64.0f);
            info.widthBridge = 1;
            info.tileWidth = 6;
            info.riverType = RiverType.e_CrocRiver;
            (river[numRivers]).Initialise(info);
            numRivers++;
        }

        public void AddTreeP1P2(int placedObjectId, int yPos, int xPos)
        {
            CGPoint spritePosition;
            int moId = -1;
            int noGoZoneId = -1;
            int treeType = 0;
			spritePosition.x = 0;
			spritePosition.y = 0;
            GameObjectType gameObject = GameObjectType.kGameObject_Tree;
            if (lBuilder.currentScene == (int) SceneType.kSceneIce) {
            }
            else if ((lBuilder.currentScene == (int) SceneType.kSceneGrass) || (lBuilder.currentScene == (int) SceneType.kSceneMud)) {
                treeType = Utilities.GetRand( 2);
                if (lBuilder.currentScene == (int) SceneType.kSceneMud) {
                    treeType = (int)TreeType.kTree_Pine;
                }

                CGPoint offset;
                if (false) {
                    lBuilder.SetPlacedObjectTypeP1(placedObjectId, (int) ObjectType.kOT_TreeGreen);
                    offset.y = -69.0f;
                    offset.x = 192.0f;
                }
                else {
                    lBuilder.SetPlacedObjectTypeP1(placedObjectId, (int) ObjectType.kOT_Tree);
                    offset.y = -180.0f;
                    offset.x = 64.0f;
                }

                noGoZoneId = this.AddNoGoZoneP1P2(64 + (xPos * 64), -20 + (yPos * 64), 16);
                (noGoZone[noGoZoneId]).SetType(NoGoType.e_Tree);
                float yExtra = 0.0f;
                if (treeType == (int) TreeType.kTree_LittleOne) {
                    yExtra = 10.0f;
                }

                spritePosition = Utilities.CGPointMake((xPos * 64) + offset.x + kShiftSpritesX, (yPos * 64) + offset.y + kShiftSpritesY + 150 + yExtra);
                moId = this.AddMapObjectP1P2P3(0, (int) spritePosition.x, (int) spritePosition.y,  ListType.e_RenderTrees);
                if (this.IsMapObjectIdInvalid(moId)) return;

                (mapObject[moId]).SetAtlas(gameThingsAtlas);
                (mapObject[moId]).SetType( MapObjectType.e_Tree);
                (mapObject[moId]).SetObjectId(numGameObject[(int)gameObject]);
                if (lBuilder.currentScene == (int) SceneType.kSceneMud) {
                    (mapObject[moId]).SetSubTextureId((int)World.Enum2.kGTMud_TreeTop3);
                }
                else {
                    (mapObject[moId]).SetSubTextureId((int)World.Enum3.kGTGrass_TreeTop2 - treeType);
                }

                (mapObject[moId]).SetScale(Constants.SPRITE_BASE_SCALE);
            }

            this.InsertThisObjectIntoListP1(gameObject, spritePosition.y);
            if (tree[numGameObject[(int)gameObject]] == null) {
                tree[numGameObject[(int)gameObject]] = new Tree();
            }

            Tree.TreeInfo info = new Tree.TreeInfo();
            info.inType = (TreeType)treeType;
            info.inPosition = spritePosition;
            info.mapObjectId = (short)moId;
            (tree[numGameObject[(int)gameObject]]).AddToScene(info);
            (noGoZone[noGoZoneId]).SetObjectId(numGameObject[(int)gameObject]);
            numGameObject[(int)gameObject]++;
        }

        public void AddElephant(CGPoint position)
        {
        }

        public void AddBuildingP1P2P3P4(float xPos, float yPos, float widthX, float lengthY, BuildingType inType)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_Buildings],  (int)Enum2.kMaxBuildings)) {
                return;
            }

            CGPoint topLeft;
            CGPoint bottomRight;
            topLeft = Utilities.CGPointMake(xPos - (widthX * 0.5f), yPos - (lengthY * 0.5f));
            bottomRight = Utilities.CGPointMake(xPos + (widthX * 0.5f), yPos + (lengthY * 0.5f));
            Building.BuildingInfo info = new Building.BuildingInfo();
            info.topLeft = topLeft;
            info.bottomRight = bottomRight;
            info.inType = inType;
            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_Buildings, info.topLeft.y);
            if (building[numGameObject[(int) GameObjectType.kGameObject_Buildings]] == null) {
                building[numGameObject[(int) GameObjectType.kGameObject_Buildings]] = new Building();
            }

            (building[numGameObject[(int) GameObjectType.kGameObject_Buildings]]).AddToScene(info);
            numGameObject[(int) GameObjectType.kGameObject_Buildings]++;
        }

        public void AddBuildingTilesP1P2P3P4(float xPos, float yPos, float widthX, float lengthY, BuildingType inType)
        {
            float leftX = (xPos * 64);
            float centreX = leftX + ((widthX * 64) / 2.0f);
            float centreY = (yPos * 64) + ((lengthY * 64) / 2.0f);
            this.AddBuildingP1P2P3P4(centreX, centreY, widthX * 64.0f, lengthY * 64.0f, inType);
        }

        public void AddBigSidewaysShedP1(float xPos, float yPos)
        {
            float widthX = 3.0f;
            float leftX = (xPos * 64);
            float centreX = leftX + ((widthX * 64.0f) / 2.0f);
            float lengthY = 6.0f;
            float centreY = (yPos * 64.0f) + ((lengthY * 64.0f) / 2.0f);
            centreY -= 10.0f;
            this.AddBuildingP1P2P3P4(centreX, centreY, widthX * 64.0f, lengthY * 64.0f, BuildingType.kBuilding_SideShed);
            float xLinePos = 0.0f;
            bool drawLine = false;
            if (xPos <= -1.0f) {
                drawLine = true;
                xLinePos = -1.0f;
            }
            else if (xPos >= 4) {
                drawLine = true;
                xLinePos = 6.0f;
            }

            if (drawLine) {
                for (int i = 0; i < 6; i++) {
                    float lineX = (xLinePos * 64.0f) + 32.0f;
                    float lineY = (yPos * 64.0f) + 32.0f + (((float) i) * 64.0f);
                    int subtextureId;
                    if (i == 0) {
                        subtextureId = (int)World.Enum2.kGTMud_RoofLine1;
                        lineY += 2.0f;
                    }
                    else if (i == 5) {
                        subtextureId = (int)World.Enum2.kGTMud_RoofLine3;
                        lineY -= 2.0f;
                    }
                    else {
                        subtextureId = (int)World.Enum2.kGTMud_RoofLine2;
                        lineX += 2.0f;
                    }

                    int moId = this.AddMapObjectP1P2P3(0, (int) lineX, (int) lineY,  ListType.e_RenderAbovePlayer);
                    (mapObject[moId]).SetAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud));
                    if (i == 0) (mapObject[moId]).SetSubTextureId((int)World.Enum2.kGTMud_RoofLine1);
                    else if (i == 5) (mapObject[moId]).SetSubTextureId((int)World.Enum2.kGTMud_RoofLine3);
                    else {
                        (mapObject[moId]).SetSubTextureId((int)World.Enum2.kGTMud_RoofLine2);
                    }

                }

            }

        }

        public void AddBusP1(float xPos, float yPos)
        {
            float widthX = 3.85f;
            float lengthY = 1.5f;
            float leftX = (xPos * 64);
            float centreX = leftX + ((widthX * 64) / 2.0f);
            float centreY = (yPos * 64) + ((lengthY * 64) / 2.0f);
            float lengthYShorter = (lengthY * 64.0f);
            this.AddBuildingP1P2P3P4(centreX, centreY, widthX * 64.0f, lengthYShorter, BuildingType.kBuilding_Barn);
        }

        public void AddBarnP1(float xPos, float yPos)
        {
            float widthX = 4.1f;
            float lengthY = 205.0f;
            float leftX = (xPos * 64);
            float centreX = 0.0f + leftX + ((widthX * 64) / 2.0f);
            float centreY = (yPos * 64) + 0 + (lengthY / 2.0f);
            centreY -= 9.0f;
            this.AddBuildingP1P2P3P4(centreX, centreY, widthX * 64.0f, lengthY, BuildingType.kBuilding_Barn);
        }

        public void AddHouseP1(float xPos, float yPos)
        {
            if (lBuilder.currentScene == (int) SceneType.kSceneMud) {
                this.AddBarnP1(xPos, yPos);
                return;
            }

            float widthX = 4.2f;
            float lengthY = 192.0f + 12.0f;
            float leftX = (xPos * 64) + 54;
            float centreX = leftX + ((widthX * 64.0f) / 2.0f);
            float centreY = (yPos * 64) + (lengthY / 2.0f) + 12.0f;
            centreY -= 10.0f;
            this.AddBuildingP1P2P3P4(centreX, centreY, widthX * 64.0f, lengthY, BuildingType.kBuilding_House);
            centreX -= 150;
            widthX = 70.0f;
            centreY += 5.0f;
            lengthY = 110.0f;
            if (xPos == 0) {
                centreY -= 35.0f;
                widthX = 140.0f;
            }
            else {
                centreY += 5.0f;
            }

            this.AddBuildingP1P2P3P4(centreX, centreY, widthX, lengthY, BuildingType.kBuilding_House);
        }

        public void AddSkip(CGPoint mapPosition)
        {
            float widthX = 120.0f;
            float lengthY = 12.0f;
            float centreX = mapPosition.x + 64.0f;
            float centreY = mapPosition.y + 14.0f;
            this.AddBuildingP1P2P3P4(centreX, centreY, widthX, lengthY, BuildingType.kBuilding_Skip);
        }

        public void AddTent(CGPoint mapPosition)
        {
            float widthX = 150.0f;
            float lengthY = 12.0f;
            float centreX = mapPosition.x + 90.0f;
            float centreY = mapPosition.y - 6.0f;
            this.AddBuildingP1P2P3P4(centreX, centreY, widthX, lengthY, BuildingType.kBuilding_Tent);
        }

        public void AddSnowdriftP1P2(int yPos, int xPos, int radius)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_Ponds],  (int)Enum2.kMaxPonds)) {
                return;
            }

            Pond.PondInfo info = new Pond.PondInfo();
            if (radius == 2) {
                info.position = Utilities.CGPointMake(64 + (xPos * 64), 64 + (yPos * 64));
                tileMap.PlaceObjectP1((int) ObjectType.kOT_Snowdrift, Utilities.CGPointMake(xPos, yPos));
            }
            else {
            }

            info.radius = 30 * ((float) radius);
            info.type = PondType.e_Snow;
            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_Ponds, info.position.y);
            if (pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]] == null) {
                pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]] = new Pond();
            }

            (pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]]).AddToScene(info);
            numGameObject[(int) GameObjectType.kGameObject_Ponds]++;
        }

        public void AddPondP1P2(int yPos, int xPos, int radius)
        {
            if (this.CheckNumObjectsP1(numGameObject[(int) GameObjectType.kGameObject_Ponds],  (int)Enum2.kMaxPonds)) {
                return;
            }

            Pond.PondInfo info = new Pond.PondInfo();
            if (radius == 2) {
                info.position = Utilities.CGPointMake(64 + (xPos * 64), 64 + (yPos * 64));
                tileMap.PlaceObjectP1((int) ObjectType.kOT_Puddle, Utilities.CGPointMake(xPos, yPos));
            }
            else {
                info.position = Utilities.CGPointMake(96 + (xPos * 64), 96 + (yPos * 64));
                tileMap.PlaceObjectP1((int) ObjectType.kOT_Pond, Utilities.CGPointMake(xPos, yPos));
            }

            #if UP_RACE
                info.position.y -= 64;
            #endif

            info.radius = 30 * ((float) radius);
            if (radius == 3) {
                info.radius -= 2;
                info.type = PondType.e_Normal;
            }
            else {
                info.type = PondType.e_Puddle;
            }

            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_Ponds, info.position.y);
            if (pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]] == null) {
                pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]] = new Pond();
            }

            (pond[numGameObject[(int) GameObjectType.kGameObject_Ponds]]).AddToScene(info);
            numGameObject[(int) GameObjectType.kGameObject_Ponds]++;
        }

        public void AddPondP1(int yPos, int xPos)
        {
            this.AddPondP1P2(yPos, xPos, 3);
        }

        int AddCliffSectionP1(CGPoint pos, ObjectType inType)
        {
			return -1;
        }

        public void AddFarmRampP1(float xPos, float yPos)
        {
            if (this.CheckNumObjectsP1(numRamps,  (int)Enum2.kMaxRamps)) {
                return;
            }

            Ramp.RampInfo info = new Ramp.RampInfo();
            info.width = 2;
            float extraX = 0;
            extraX = 32;
            info.mapPosition = Utilities.CGPointMake(48 + extraX + (xPos * 64), 16 + (yPos * 64));
            (ramp[numRamps]).AddToScene(info);
            numRamps++;
        }

        public void AddRampP1P2(int yPos, int xPos, int width)
        {
            if (this.CheckNumObjectsP1(numRamps,  (int)Enum2.kMaxRamps)) {
                return;
            }

            tileMap.AddRampP1P2(xPos, yPos, width);
            Ramp.RampInfo info = new Ramp.RampInfo();
            info.width = width;
            float extraX = 0;
            if (width == 2) extraX = 32;

            info.mapPosition = Utilities.CGPointMake(48 + extraX + (xPos * 64), 16 + (yPos * 64));
            (ramp[numRamps]).AddToScene(info);
            numRamps++;
        }

        public void AddRockP1(int yPos, int xPos)
        {
            tileMap.AddRockP1(xPos, yPos);
            int ngId = this.AddNoGoZoneP1P2(32 + (xPos * 64), 38 + (yPos * 64), 30);
            (noGoZone[ngId]).SetType(NoGoType.e_Rock);
        }

        public void AddBigRockP1(int yPos, int xPos)
        {
            tileMap.AddBigRockP1(xPos, yPos);
            int ngId = this.AddNoGoZoneP1P2(64 + (xPos * 64), 64 + (yPos * 64), 55);
            (noGoZone[ngId]).SetType(NoGoType.e_BigRock);
            (noGoZone[ngId]).SetCeilingHeight(20.0f);
            (noGoZone[ngId]).SetIsBouncable(true);
        }

        public bool IsPlayerBalancingOnBridgeP1(Player inPlayer, int i)
        {
            float xPlayer = inPlayer.GetPosition().x;
            float xFlower = (river[i]).xFlowerPosition;
            float stemWidth = (river[i]).xWidth + 20;
            if (xPlayer < (xFlower + (stemWidth / 2))) {
                if (xPlayer > (xFlower - (stemWidth / 2))) {
                    inPlayer.SetOnBridge(i);
                    return true;
                }

            }

            inPlayer.SetOnBridge(-1);
            return false;
        }

        public void AddStandardStartGate()
        {
            this.AddStoneWallP1P2(4, 2, 2);
            this.AddStartingGateP1P2P3(4, 2,  StartingGateType.e_Left,  StartingGateState.e_Closed);
            this.AddStartingGateP1P2P3(4, 3,  StartingGateType.e_Right,StartingGateState.e_Closed);
            (stoneWall[0]).AddGate(0);
            (stoneWall[0]).AddGate(1);
        }

        public void InitialiseTrackPieces()
        {
        }

        public void SetupScene()
        {
            this.CheckReleaseGameThings();
            (tileMap.tileGrid).ClearWithGrassyTiles(lBuilder.currentScene);
            numStoneWalls = 0;
            numStartingGates = 0;
            numRamps = 0;
            numCowPats = 0;
            numRivers = 0;
            for (int i = 0; i < (int) GameObjectType.Types; i++) {
                numGameObject[i] = 0;
            }

            this.InitialiseLinkedList();
            this.InitialiseTrackPieces();
            for (int i = 0; i < (int) GameObjectType.Types; i++) {
                (updateOrder[i]).Clear();//RemoveAllObjects();
                (yPositionListForStart[i]).Clear();//RemoveAllObjects();
            }

            finishYPos = 64 * 200;
            this.AddStandardStartGate();
            timeLimit = 26;
        }

        public void AddCrossingThing(CrossingThing.CrossingThingInfo info)
        {
            Globals.Assert(numGameObject[(int) GameObjectType.kGameObject_CrossingThing] <  (int)Enum2.kMaxCrossingThings);
            if (crossingThing[numGameObject[(int) GameObjectType.kGameObject_CrossingThing]] == null) {
                crossingThing[numGameObject[(int) GameObjectType.kGameObject_CrossingThing]] = new CrossingThing();
            }

            info.crossingThingId = numGameObject[(int) GameObjectType.kGameObject_CrossingThing];
            int realLevelId = LevelBuilder_Ross.levelOrder[((Globals.g_world.frontEnd).profile).selectedLevel];
            if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass9_8_Gardens) {
                if (numGameObject[(int) GameObjectType.kGameObject_CrossingThing] > 1) {
                    if (numGameObject[(int) GameObjectType.kGameObject_CrossingThing] == 3) {
                        info.startPosition.x = 32.0f;
                    }

                    info.xSpeed = -1.0f;
                }

            }
            else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrassN1_8_SquareHedgeShuffle) {
                if (numGameObject[(int) GameObjectType.kGameObject_CrossingThing] > 1) {
                    info.xSpeed = -2.0f;
                }
                else {
                    info.xSpeed = 3.5f;
                }

            }
            else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kGrass10_1_LotsOfSheep) {
                if (info.xSpeed < 0.0f) {
                    info.xSpeed = -4.2f;
                }
                else {
                    info.xSpeed = 4.2f;
                }

            }

            this.InsertThisObjectIntoListP1( GameObjectType.kGameObject_CrossingThing, info.startPosition.y);
            (crossingThing[numGameObject[(int) GameObjectType.kGameObject_CrossingThing]]).AddToScene(info);
            numGameObject[(int) GameObjectType.kGameObject_CrossingThing]++;
        }

        public void LoadLevelFromData()
        {
            for (int i = 0; i <  (int)Enum2.kMaxRivers; i++) {

				if (river[i] == null)
				{
					river[i] = new FlowerCliff();
				}
            }
			
			
            for (int i = 0; i < lBuilder.numPlacedObjects; i++) {
                int yPos = (int) (lBuilder.GetPlacedObject(i).position.y);
                int xPos = (int) (lBuilder.GetPlacedObject(i).position.x);
                ObjectType type = lBuilder.GetPlacedObject(i).objectType;
                CGPoint position = Utilities.CGPointMake(lBuilder.GetPlacedObject(i).position.x, lBuilder.GetPlacedObject(i).position.y);
                CGPoint mapPosition = Utilities.CGPointMake(position.x * 64.0f, position.y * 64.0f);
                if (lBuilder.GetObjectInfo(lBuilder.GetPlacedObject(i).objectType).isSprite) {
                    position.x += kShiftSpritesX;
                    position.y += kShiftSpritesY;
                    int realLevelId = LevelBuilder_Ross.levelOrder[((Globals.g_world.frontEnd).profile).selectedLevel];
                    if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                        if (realLevelId < 400) {
                            switch (realLevelId) {
                            case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne :
                            case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo :
                            case (int)LevelBuilder_Ross.Enum2.kGrass_DuckpondDance :
                            case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail :
                            case (int)LevelBuilder_Ross.Enum2.kGrass1_5_MdwCup_Race5_TwoRivers :
                            case (int)LevelBuilder_Ross.Enum2.kGrass1_6_MdwCup_Race6_CattleRun :
                            case (int)LevelBuilder_Ross.Enum2.kGrass1_7_MdwCup_Race7_Bollards :
                            case (int)LevelBuilder_Ross.Enum2.kGrass1_8_MdwCup_Race8_CowField :
                                position.y += 40.0f;
                                break;
                            case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly :
                                if (position.y > 800.0f) {
                                    position.y += 40.0f;
                                }

                                break;
                            }

                        }

                    }
					else{
						//position.x += 2;
					}

                }

                switch (type) {
                case ObjectType.kOT_MudPuddle2x2 :
                    {
                        this.AddMuddyPuddleP1(position, 2);
                        break;
                    };
                case ObjectType.kOT_MudPuddle2x1 :
                    {
                        break;
                    };
                case ObjectType.kOT_MudPuddle1x1 :
                    {
                        break;
                    };
                case ObjectType.kOT_ChimneyLeft :
                    {
                    }
                    break;
                case ObjectType.kOT_ChimneyRight :
                    {
                        this.AddChimney(position);
//                        tileMap.PlaceObjectP1((int)type, Utilities.CGPointMake(xPos, yPos));
                        break;
                    };
                case ObjectType.kOT_StoneWell :
                    {
                        this.AddStoneWell(position);
                        break;
                    };
                case ObjectType.kOT_FarmRamp :
                    {
                        this.AddFarmRampP1((lBuilder.GetPlacedObject(i).position.x), (lBuilder.GetPlacedObject(i).position.y));
                        break;
                    };
                case ObjectType.kOT_Cart :
                    {
                        this.AddCart(position);
                        break;
                    };
                case ObjectType.kOT_Cactus :
                    {
                        this.AddCactus(position);
                        break;
                    };
                case ObjectType.kOT_Tractor :
                case ObjectType.kOT_BlueTractor :
                    {
                        this.AddTractorP1(type, position);
                        break;
                    };
                case ObjectType.kOT_Igloo :
                    {
                        this.AddIgloo(mapPosition);
                        break;
                    };
                case ObjectType.kOT_Crocodile :
                    {
                        this.AddCrocodile(mapPosition);
                        break;
                    };
                case ObjectType.kOT_Seal :
                    {
                        this.AddSeal(position);
                        break;
                    };
                case ObjectType.kOT_SmallSnow :
                    {
                        this.AddSmallSnow(position);
                        break;
                    };
                case ObjectType.kOT_OilDrum :
                    {
                        this.AddOilDrum(position);
                        break;
                    };
                case ObjectType.kOT_Trampoline :
                    {
                        this.AddTrampoline(position);
                        break;
                    };
                case ObjectType.kOT_Scarecrow :
                    {
                        this.AddScarecrow(position);
                        break;
                    };
                case ObjectType.kOT_BushLilac :
                    {
                        this.AddBushP1((int) FlowerBunchType.kFlowerBunch_Lilac, position);
                        break;
                    };
                case ObjectType.kOT_BushPink :
                    {
                        this.AddBushP1((int) FlowerBunchType.kFlowerBunch_Pink, position);
                        break;
                    };
                case ObjectType.kOT_Chicken :
                    {
                        this.AddChicken(position);
                        break;
                    };
                case ObjectType.kOT_Waterfall :
                    {
                        this.AddWaterfall(position);
                        break;
                    };
                case ObjectType.kOT_Gnome :
                    {
                        this.AddGnome(position);
                        break;
                    };
                case ObjectType.kOT_Squash :
                case ObjectType.kOT_Courgette :
                case ObjectType.kOT_Pumpkin :
                    {
                        this.AddVegetableP1((int)type, position);
                        break;
                    };
                case ObjectType.kOT_Skip :
                    {
                        this.AddSkip(mapPosition);
                        break;
                    };
                case ObjectType.kOT_Tent :
                    {
                        this.AddTent(mapPosition);
                        break;
                    };
                case ObjectType.kOT_Log :
                    {
                        this.AddLog(position);
                        break;
                    };
                case ObjectType.kOT_Elephant :
                    {
                        this.AddElephant(position);
                        break;
                    };
                case ObjectType.kOT_Snake :
                    {
                        break;
                    };
                case ObjectType.kOT_CrossingShirley :
                    {
                        CrossingThing.CrossingThingInfo info = new CrossingThing.CrossingThingInfo();
                        info.crossingThingType = CrossingThingType.kCrossingThing_Shirley;
                        info.startPosition = position;
                        this.AddCrossingThing(info);
                        break;
                    };
                case ObjectType.kOT_CrossingTractor :
                case ObjectType.kOT_CrossingLandRover :
                    {
                        this.AddTractorP1(type, position);
                        break;
                    };
                case ObjectType.kOT_CrossingFlockLeft :
                    {
                        CrossingThing.CrossingThingInfo info = new CrossingThing.CrossingThingInfo();
                        info.crossingThingType = CrossingThingType.kCrossingThing_Sheep;
                        info.startPosition = position;
                        info.xSpeed = -5.0f;
                        this.AddCrossingThing(info);
                        break;
                    };
                case ObjectType.kOT_CrossingFlockRight :
                    {
                        CrossingThing.CrossingThingInfo info = new CrossingThing.CrossingThingInfo();
                        info.crossingThingType = CrossingThingType.kCrossingThing_Sheep;
                        info.startPosition = position;
                        info.xSpeed = 5.0f;
                        this.AddCrossingThing(info);
                        break;
                    };
                case ObjectType.kOT_Lion :
                    {
                        this.AddLion(mapPosition);
                        break;
                    };
                case ObjectType.kOT_Venus :
                    {
                        this.AddVenus(position);
                        break;
                    };
                case ObjectType.kOT_Crater :
                    {
                        break;
                    };
                case ObjectType.kOT_Crater2x2 :
                    {
                        break;
                    };
                case ObjectType.kOT_Crater1x1 :
                    {
                        break;
                    };
                case ObjectType.kOT_HillockFarmyard :
                    {
                        break;
                    };
                case ObjectType.kOT_SmallBump :
                    {
                        break;
                    };
                case ObjectType.kOT_HayStack :
                    {
                        this.AddSkip(mapPosition);
                        break;
                    };
                case ObjectType.kOT_HayBaleDouble :
                    {
                        this.AddHayBaleP1(position,  HayBaleType.e_Double);
                        break;
                    };
                case ObjectType.kOT_Welly :
                    {
                        this.AddWelly(position);
                        break;
                    };
                case ObjectType.kOT_Bollard :
                    {
                        this.AddBollard(position);
                        break;
                    };
                case ObjectType.kOT_Cauliflower :
                    {
                        this.AddCauliflower(position);
                        break;
                    };
                case ObjectType.kOT_Bucket :
                    {
                        this.AddBucket(position);
                        break;
                    };
                case ObjectType.kOT_Bus :
                    {
//                        this.AddBusP1(lBuilder.GetPlacedObject(i).position.x, lBuilder.GetPlacedObject(i).position.y);
  //                      tileMap.PlaceObjectP1((int)type, Utilities.CGPointMake(xPos, yPos));
                        break;
                    };
                case ObjectType.kOT_Barn :
                    {
                        this.AddBarnP1(lBuilder.GetPlacedObject(i).position.x, lBuilder.GetPlacedObject(i).position.y);
                        tileMap.PlaceObjectP1((int)type, Utilities.CGPointMake(xPos, yPos));
                        break;
                    };
                case ObjectType.kOT_House :
                    {
                        this.AddHouseP1(lBuilder.GetPlacedObject(i).position.x, lBuilder.GetPlacedObject(i).position.y);
                        tileMap.PlaceObjectP1((int)type, Utilities.CGPointMake(xPos, yPos));
                        break;
                    };
                case ObjectType.kOT_BigSidewaysShed :
                    {
                        this.AddBigSidewaysShedP1(lBuilder.GetPlacedObject(i).position.x, lBuilder.GetPlacedObject(i).position.y);
                        tileMap.PlaceObjectP1((int)type, Utilities.CGPointMake(xPos, yPos));
                        break;
                    };
                case ObjectType.kOT_Tree :
                case ObjectType.kOT_TreeGreen :
                    {
                        this.AddTreeP1P2(i, (int) (lBuilder.GetPlacedObject(i).position.y), (int) (lBuilder.GetPlacedObject(i).position.x));
                        break;
                    };
                case ObjectType.kOT_River :
                    {
                        int bridgeX = -4;
                        int bridgeWidth = 1;
                        for (int j = 0; j < lBuilder.numPlacedObjects; j++) {
                            if (lBuilder.GetPlacedObject(j).objectType == ObjectType.kOT_Bridge1) {
                                if (lBuilder.GetPlacedObject(j).position.y == yPos) {
                                    bridgeWidth = 1;
                                    bridgeX = (int)lBuilder.GetPlacedObject(j).position.x;
                                }

                            }
                            else if (lBuilder.GetPlacedObject(j).objectType == ObjectType.kOT_Bridge2) {
                                if (lBuilder.GetPlacedObject(j).position.y == yPos) {
                                    bridgeWidth = 2;
                                    bridgeX = (int)lBuilder.GetPlacedObject(j).position.x;
                                }

                            }

                        }

                        this.AddRiverP1P2(yPos, bridgeX, bridgeWidth);
                        break;
                    };
                case ObjectType.kOT_ArrowLeft :
                case ObjectType.kOT_ArrowDown :
                case ObjectType.kOT_ArrowRight :
                    {
                        tileMap.PlaceObjectP1((int)type, Utilities.CGPointMake(xPos, yPos));
                        break;
                    };
                case ObjectType.kOT_WallFarmYard :
                case ObjectType.kOT_WallFarmYardLong :
                    {
                        this.AddStoneWallFarmP1P2(xPos, yPos, (int) type);
                        tileMap.PlaceObjectP1((int)type, Utilities.CGPointMake(xPos, yPos));
                        break;
                    };
                case ObjectType.kOT_FinishingLine :
                case ObjectType.kOT_FinishingLineFarm :
                    {
                        finishYPos = 32 + (float) yPos * (float) 64;
                        timeLimit = 15 + (33 * ((float) yPos / (float) 200));
                        int whichWall = this.AddStoneWallP1P2(((int) finishYPos / 64), 2, 2);
                        this.AddStartingGateP1P2P3(((int) (finishYPos / 64)), 2, StartingGateType.e_Left, StartingGateState.e_Open);
                        this.AddStartingGateP1P2P3(((int) (finishYPos / 64)), 3,  StartingGateType.e_Right,  StartingGateState.e_Open);
                        (stoneWall[whichWall]).AddGate(2);
                        (stoneWall[whichWall]).AddGate(3);
                        break;
                    };
                case ObjectType.kOT_Pond :
                    {
                        this.AddPondP1P2((int) (lBuilder.GetPlacedObject(i).position.y), (int) (lBuilder.GetPlacedObject(i).position.x), 3);
                        break;
                    };
                case ObjectType.kOT_Cliff2 :
                case ObjectType.kOT_Cliff3 :
                    {
                        this.AddCliffSectionP1(position, type);
                        tileMap.PlaceObjectP1((int)type, Utilities.CGPointMake(xPos, yPos));
                        break;
                    };
                case ObjectType.kOT_Puddle :
                    {
                        this.AddPondP1P2((int) (lBuilder.GetPlacedObject(i).position.y), (int) (lBuilder.GetPlacedObject(i).position.x), 2);
                        break;
                    };
                case ObjectType.kOT_Snowdrift :
                    {
                        this.AddSnowdriftP1P2((int) (lBuilder.GetPlacedObject(i).position.y), (int) (lBuilder.GetPlacedObject(i).position.x), 2);
                        break;
                    };
                case ObjectType.kOT_Rock :
                    {
                        this.AddRockP1((int) (lBuilder.GetPlacedObject(i).position.y), (int) (lBuilder.GetPlacedObject(i).position.x));
                        break;
                    };
                case ObjectType.kOT_BigRock :
                    {
                        this.AddBigRockP1((int) (lBuilder.GetPlacedObject(i).position.y), (int) (lBuilder.GetPlacedObject(i).position.x));
                        break;
                    };
                case ObjectType.kOT_Flowers :
                    {
                        switch ((SceneType)lBuilder.currentScene) {
                        case SceneType.kSceneMud :
                            Globals.Assert(false);
                            this.AddFlowerBunchP1P2(position.y, position.x, (int) FlowerBunchType.kFlowerBunch_Tulips);
                            break;
                        case SceneType.kSceneGrass :
                            this.AddFlowerBunchP1P2(position.y, position.x, (int) FlowerBunchType.kFlowerBunch_Daffodil);
                            break;
                        default :
                            Globals.Assert(false);
                            break;
                        }

                        break;
                    };
                case ObjectType.kOT_Tulips :
                    {
                        this.AddFlowerBunchP1P2(position.y, position.x, (int) FlowerBunchType.kFlowerBunch_Tulips);
                        break;
                    };
                case ObjectType.kOT_TulipsYellow :
                    {
                        this.AddFlowerBunchP1P2(position.y, position.x, (int) FlowerBunchType.kFlowerBunch_TulipsYellow);
                        break;
                    };
                case ObjectType.kOT_TulipsWhite :
                    {
                        this.AddFlowerBunchP1P2(position.y, position.x, (int) FlowerBunchType.kFlowerBunch_TulipsWhite);
                        break;
                    };
                case ObjectType.kOT_TulipsBlue :
                    {
                        this.AddFlowerBunchP1P2(position.y, position.x, (int) FlowerBunchType.kFlowerBunch_TulipsBlue);
                        break;
                    };
                case ObjectType.kOT_StarSpeedUp :
                    {
                        this.AddStarSpeedUpP1((int) (lBuilder.GetPlacedObject(i).position.x), (int) (lBuilder.GetPlacedObject(i).position.y));
                        break;
                    };
                case ObjectType.kOT_Rainbow :
                    {
                        this.AddRainbowP1(position.x, position.y);
                        break;
                    };
                case ObjectType.kOT_CowPatSprite :
                    {
                        this.PutCowPatP1((int) (lBuilder.GetPlacedObject(i).position.y), (float)(lBuilder.GetPlacedObject(i).position.x));
                        break;
                    };
                case ObjectType.kOT_BoostArrowDown :
                    {
                        this.AddBoostArrowP1((int) (lBuilder.GetPlacedObject(i).position.x), (int) (lBuilder.GetPlacedObject(i).position.y));
                        break;
                    };
                case ObjectType.kOT_CowLeft :
                    {
                        CGPoint whereToPut = Utilities.CGPointMake(lBuilder.GetPlacedObject(i).position.x, lBuilder.GetPlacedObject(i).position.y);
                        int realLevelId = LevelBuilder_Ross.levelOrder[((Globals.g_world.frontEnd).profile).selectedLevel];
                        switch (realLevelId) {
                        case (int)LevelBuilder_Ross.Enum2.kMudN1_5_StarStables :
                            whereToPut.y += kShiftSpritesY;
                            break;
                        }

                        if (lBuilder.currentScene == (int) SceneType.kSceneMud) {
                            this.AddCowXYP1P2((int) whereToPut.y, (float) whereToPut.x, (int) CowMovement.kCowWalkingRight);
                        }
                        else {
                            this.AddCowXYP1P2((int) whereToPut.y, (float) whereToPut.x, (int) CowMovement.kCowWalkingLeft);
                        }

                        break;
                    };
                case ObjectType.kOT_CowRight :
                    {
                        CGPoint whereToPut = Utilities.CGPointMake(lBuilder.GetPlacedObject(i).position.x, lBuilder.GetPlacedObject(i).position.y);
                        int realLevelId = LevelBuilder_Ross.levelOrder[((Globals.g_world.frontEnd).profile).selectedLevel];
                        switch (realLevelId) {
                        case (int)LevelBuilder_Ross.Enum2.kMudN1_5_StarStables :
                            whereToPut.y += kShiftSpritesY;
                            break;
                        }

                        if (lBuilder.currentScene == (int) SceneType.kSceneMud) {
                            this.AddCowXYP1P2((int) whereToPut.y, (float) whereToPut.x, (int) CowMovement.kCowWalkingLeft);
                        }
                        else {
                            this.AddCowXYP1P2((int) whereToPut.y, (float) whereToPut.x, (int) CowMovement.kCowWalkingRight);
                        }

                        break;
                    };
                case ObjectType.kOT_BigRamp :
                    {
                        this.AddRampP1P2((int) (lBuilder.GetPlacedObject(i).position.y), (int) (lBuilder.GetPlacedObject(i).position.x), 2);
                        break;
                    };
                case ObjectType.kOT_Ramp :
                    {
                        this.AddRampP1P2((int) (lBuilder.GetPlacedObject(i).position.y), (int) (lBuilder.GetPlacedObject(i).position.x), 1);
                        break;
                    };
                case ObjectType.kOT_HedgeLeft :
                case ObjectType.kOT_HedgeRight :
                    {
                        int whereIsHedgeEnd = 13;
                        int takeOffPosForGateWidth = 14;
                        bool partnerFound = false;
                        int gatePosition = 0;
                        int gateWidthHere = 0;
                        ObjectType opposite;
                        int leftHedgePos = 0;
                        int rightHedgePos = 0;
                        if (lBuilder.GetPlacedObject(i).objectType == ObjectType.kOT_HedgeLeft) {
                            leftHedgePos = (int) (lBuilder.GetPlacedObject(i).position.x);
                            opposite = ObjectType.kOT_HedgeRight;
                        }
                        else {
                            rightHedgePos = (int) (lBuilder.GetPlacedObject(i).position.x + 1);
                            opposite = ObjectType.kOT_HedgeLeft;
                        }

                        leftHedgePos *= 2;
                        rightHedgePos *= 2;
                        bool noHedge = false;
                        for (int j = 0; j < lBuilder.numPlacedObjects; j++) {
                            if (lBuilder.GetPlacedObject(j).objectType == opposite) {
                                if (lBuilder.GetPlacedObject(j).position.y == lBuilder.GetPlacedObject(i).position.y) {
                                    if (j < i) {
                                        noHedge = true;
                                        break;
                                    }
                                    else {
                                        if (lBuilder.GetPlacedObject(i).objectType == ObjectType.kOT_HedgeLeft) {
                                            leftHedgePos = (int) (lBuilder.GetPlacedObject(i).position.x);
                                            rightHedgePos = (int) (lBuilder.GetPlacedObject(j).position.x + 1);
                                            opposite = ObjectType.kOT_HedgeRight;
                                        }
                                        else {
                                            leftHedgePos = (int) (lBuilder.GetPlacedObject(j).position.x);
                                            rightHedgePos = (int) (lBuilder.GetPlacedObject(i).position.x + 1);
                                            opposite = ObjectType.kOT_HedgeLeft;
                                        }

                                        leftHedgePos *= 2;
                                        rightHedgePos *= 2;
                                        gateWidthHere = rightHedgePos - leftHedgePos - takeOffPosForGateWidth;
                                        gatePosition = leftHedgePos + whereIsHedgeEnd;
                                        partnerFound = true;
                                    }

                                    break;
                                }

                            }

                        }

                        if (!partnerFound) {
                            if (lBuilder.GetPlacedObject(i).objectType == ObjectType.kOT_HedgeLeft) {
                                gatePosition = leftHedgePos + whereIsHedgeEnd;
                            }
                            else {
                                gatePosition = rightHedgePos - whereIsHedgeEnd;
                            }

                            gateWidthHere = 12;
                        }

                        if (!noHedge) 
					{
                            this.AddHedgeToSceneP1P2((int) (lBuilder.GetPlacedObject(i).position.y), gatePosition, gateWidthHere);
                        }

                        break;
				};
                    default :
                        break;
                  //  };
                }

            }

            lBuilder.LoadOfObjectsFinished();
        }

        public bool HasLeftScreen(CGPoint onScreenPosition)
        {

            #if UP_RACE
                return (onScreenPosition.y >= 1110.0f);
            #else
                return (onScreenPosition.y <= -50.0f);
            #endif

        }

        public void SetupLevelBuilder_Ross()
        {
            int levelToLoad = -1;
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) levelToLoad = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
            else levelToLoad = ((Globals.g_world.frontEnd).profile).selectedLevel;

            (Globals.g_world.audio).CheckAndLoadLevelBuilder_RossEffects();
            this.ResetMapObjects();
            this.SetupScene();

            this.LoadLevelBuilder_RossTextures();
            Globals.g_world.LoadAtlasForLevelBuilder_Ross();
            Globals.g_world.LoadSceneAtlases();			
			
			lBuilder.ReadSomeLevelDataP1(levelToLoad, true);
			Globals.g_world.game.tileMap.SetStartGame();
			Globals.g_world.game.SetSpritesToTileCamera(false);

            if (lBuilder.currentScene == (int) SceneType.kSceneGrass) this.SetGameThingsAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsGrass));
            else if (lBuilder.currentScene == (int) SceneType.kSceneMud) this.SetGameThingsAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_GameThingsMud));
            else if (lBuilder.currentScene == (int) SceneType.kSceneDesert) this.SetGameThingsAtlas(Globals.g_world.GetAtlas( AtlasType.
              kAtlas_GameThingsGrassDesert));
            else if (lBuilder.currentScene == (int) SceneType.kSceneIce) this.SetGameThingsAtlas(Globals.g_world.GetAtlas( AtlasType.kAtlas_IceSprites));
            else if (lBuilder.currentScene == (int) SceneType.kSceneMoon) this.SetGameThingsAtlas(Globals.g_world.GetAtlas( AtlasType.
              kAtlas_GameThingsGrassDesert));
            else {
                Globals.Assert(false);
            }

            lBuilder.Setup(levelToLoad);
            lBuilder.RefreshCurrentScene();
            tileMap.StartOfRace();
            tileMap.SetScale(Constants.LEVEL_BUILDER_TILE_SCALE);
        }

        public void ResetUpdateLists()
        {
            for (int i = 0; i < (int) GameObjectType.Types; i++) {
                startUpdateId[i] = 0;
                endUpdateId[i] = 0;
            }

        }

        public void FindCliffStarts()
        {
            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_CliffPieces]; i++) {
                bool foundPieceAbove = false;
                bool foundPieceBelow = false;
                for (int j = 0; j < numGameObject[(int) GameObjectType.kGameObject_CliffPieces]; j++) {
                    if (i == j) continue;

                    if ((cliffPiece[j]).topLeft.y == ((cliffPiece[i]).topLeft.y - 64.0f)) {
                        foundPieceAbove = true;
                    }

                    if ((cliffPiece[j]).topLeft.y == ((cliffPiece[i]).topLeft.y + 64.0f)) {
                        foundPieceBelow = true;
                    }

                }

                if (!foundPieceAbove) {
                    (cliffPiece[i]).SetIsStartPiece(true);
                }

                if (!foundPieceBelow) {
                    (cliffPiece[i]).SetIsEndPiece(true);
                }

            }

        }

        public void NewStateAnotherPiggy()
        {
            this.LoadAnotherPiggyTextures();
            hud.NewGameState_AnotherPiggy();
        }

        public void NewStateSpeedBoost()
        {
            this.LoadSpeedBoostTextures();
            hud.NewGameState_SpeedBoost();
            ((Globals.g_world.frontEnd).profile).SetSpeedUpScreenPending(false);
            ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
        }

        public void NewStateAppleCart()
        {
        }

        public void NewStatePaused()
        {
            this.CheckCrystalBackgroundActivity(true);
            if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                (SoundEngine.Instance()).AVFadeOutAndStop(0.75f);
            }

        }

        public void AddFlock(Flock.FlockInfo info)
        {
            Globals.Assert(numGameObject[(int) GameObjectType.kGameObject_Flock] <  (int)Enum2.kMaxFlocks);
            if (flock[numGameObject[(int) GameObjectType.kGameObject_Flock]] == null) {
                flock[numGameObject[(int) GameObjectType.kGameObject_Flock]] = new Flock();
            }

            info.flockId = numGameObject[(int) GameObjectType.kGameObject_Flock];
            (flock[numGameObject[(int) GameObjectType.kGameObject_Flock]]).SetupFlock(info);
            numGameObject[(int) GameObjectType.kGameObject_Flock]++;
        }

        public void AddFlock_Level301()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 1250.0f;
            info.yPositionEnd = 5250.0f;
            info.speed = 4.0f;
            info.whichFlockAnimalType = FlockType.kFlockSheep;
            info.whichFlock = (int)WhichFlockType.kWFT_Migration;
            info.headStart = 2000.0f;
            this.AddFlock(info);
            info.yPositionStart = 5250.0f;
            info.yPositionEnd = 10250.0f;
            info.speed = 4.0f;
            this.AddFlock(info);
            info.yPositionStart = 10250.0f;
            info.yPositionEnd = 16250.0f;
            info.speed = 4.0f;
            this.AddFlock(info);
        }

        public void AddFlock_Level300()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 800.0f;
            info.yPositionEnd = 7740.0f;
            info.speed = 6.5f;
            info.whichFlock = (int)WhichFlockType.kWFT_2by2Weave;
            info.headStart = 2000.0f;
            this.AddFlock(info);
        }

        public void AddFlock_3Slow()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 1100.0f;
            info.yPositionEnd = 5440.0f;
            info.speed = 1.5f;
            info.whichFlock = (int)WhichFlockType.kWFT_3Slow;
            info.headStart = 1800.0f;
            this.AddFlock(info);
        }

        public void AddFlock_Level1()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 800.0f;
            info.yPositionEnd = 7740.0f;
            info.speed = 1.5f;
            info.whichFlock = (int)WhichFlockType.kWFT_JustShirley;
            info.headStart = 700.0f;
            this.AddFlock(info);
        }

        public void AddFlock_SheepLines()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 800.0f;
            info.yPositionEnd = 7740.0f;
            info.speed = 3.0f;
            info.whichFlock = (int)WhichFlockType.kWFT_FlockLines;
            info.headStart = 1000.0f;
            this.AddFlock(info);
        }

        public void AddFlock_ShirleyAndHuddles()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 800.0f;
            info.yPositionEnd = 6240.0f;
            info.speed = 2.3f;
            info.whichFlock = (int)WhichFlockType.kWFT_FlockHuddle;
            info.headStart = 2700.0f;
            this.AddFlock(info);
            info.yPositionStart = 800.0f;
            info.yPositionEnd = 5740.0f;
            info.speed = 1.5f;
            info.whichFlock = (int)WhichFlockType.kWFT_JustShirley;
            info.headStart = 1600.0f;
            this.AddFlock(info);
        }

        public void AddFlock_Shirley()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 1100.0f;
            info.yPositionEnd = 5440.0f;
            info.speed = 1.5f;
            info.whichFlock = (int)WhichFlockType.kWFT_JustShirley;
            info.headStart = 1800.0f;
            this.AddFlock(info);
        }

        public void AddFlock_CurvyLine()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 800.0f;
            info.yPositionEnd = 14500.0f;
            info.speed = 6.5f;
            info.whichFlockAnimalType = FlockType.kFlockSheep;
            info.whichFlock = (int)WhichFlockType.kWFT_SingleCurvyLine;
            info.headStart = 8500.0f;
            this.AddFlock(info);
        }

        public void AddFlock_CurvyLines()
        {
            Flock.FlockInfo info = new Flock.FlockInfo();
            info.yPositionStart = 1500.0f;
            info.yPositionEnd = 8500.0f;
            info.speed = 4.5f;
            info.whichFlockAnimalType = FlockType.kFlockSheep;
            info.whichFlock = (int)WhichFlockType.kWFT_PenguinsCurvy;
            info.headStart = 4200.0f;
            this.AddFlock(info);
            info.yPositionStart = 8500.0f;
            info.yPositionEnd = 14500.0f;
            info.speed = 4.5f;
            info.headStart = 2500.0f;
            this.AddFlock(info);
        }

        public void AddSpecialObjects()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {

                #if ADD_CUSTOM_FLOCKS_TEST
                    if (playingLevel == 13) {
                    }
                    else if (playingLevel == 23) {
                    }
                    else if (playingLevel == 8) {
                        this.AddFlock_3Slow();
                    }
                    else if (playingLevel == 9) {
                    }
                    else if (playingLevel == 10) {
                    }

                #endif

                return;
            }

            int levelFileId = LevelBuilder_Ross.levelOrder[playingLevel];
            if (levelFileId == (int)LevelBuilder_Ross.Enum2.kMud8_1_PumpkinPatch) {
                this.AddFlock_Shirley();
            }
            else if (levelFileId == (int)LevelBuilder_Ross.Enum2.kMud2_2_VegShirleyAndFlock) {
                this.AddFlock_ShirleyAndHuddles();
            }
            else if (levelFileId == (int)LevelBuilder_Ross.Enum2.kMud8_6_BlueTulips) {
                this.AddFlock_CurvyLine();
            }
            else if (levelFileId == (int)LevelBuilder_Ross.Enum2.kGrass7_7_Orchard) {
                this.AddFlock_3Slow();
            }
            else if (levelFileId == 204) {
                Flock.FlockInfo info = new Flock.FlockInfo();
                info.yPositionStart = 1250.0f;
                info.yPositionEnd = 5250.0f;
                info.speed = 6.5f;
                info.whichFlockAnimalType = 0;
                info.headStart = 0;
                this.AddFlock(info);
                info.yPositionStart = 4500.0f;
                info.yPositionEnd = 9250.0f;
                info.speed = 6.5f;
                info.whichFlockAnimalType = 0;
                this.AddFlock(info);
            }
            else if (levelFileId == 205) {
                Flock.FlockInfo info = new Flock.FlockInfo();
                info.yPositionStart = 4050.0f;
                info.yPositionEnd = 10650.0f;
                info.speed = 6.5f;
                info.headStart = 1400.0f;
                info.whichFlockAnimalType = (FlockType)1;
                info.whichFlock = (int)WhichFlockType.kWFT_2by2Weave;
                this.AddFlock(info);
            }
            else if (levelFileId == 207) {
                Flock.FlockInfo info = new Flock.FlockInfo();
                info.yPositionStart = 1530.0f;
                info.yPositionEnd = 5650.0f;
                info.speed = 8.0f;
                info.whichFlockAnimalType = FlockType.kFlockSheep;
                info.whichFlock = (int)WhichFlockType.kWFT_ThinWeaveOverBridge;
                info.headStart = 0.0f;
                this.AddFlock(info);
            }
            else if (levelFileId == 14) {
                this.AddRainbowP1(190.0f, 1760.0f);
            }
            else if (levelFileId == (int)LevelBuilder_Ross.Enum2.kMud3_8_PenCup_Race8_Weave) {
                this.AddFlock_Level300();
            }
            else if (levelFileId == 301) {
                this.AddFlock_Level301();
            }
            else if (levelFileId == 304) {
                Flock.FlockInfo info = new Flock.FlockInfo();
                info.yPositionStart = 500.0f;
                info.yPositionEnd = 6350.0f;
                info.speed = 5.85f;
                info.whichFlockAnimalType = FlockType.kFlockSheep;
                info.whichFlock = (int)WhichFlockType.kWFT_InTheForest;
                info.headStart = 2800.0f;
                this.AddFlock(info);
            }
            else if (levelFileId == (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles) {
                Flock.FlockInfo info = new Flock.FlockInfo();
                info.yPositionStart = 1250.0f;
                info.yPositionEnd = 4350.0f;
                info.speed = 3.5f;
                info.whichFlockAnimalType = FlockType.kFlockSheep;
                info.whichFlock = (int)WhichFlockType.kWFT_Huddles;
                info.headStart = 800.0f;
                this.AddFlock(info);
                info.yPositionStart = 6550.0f;
                info.yPositionEnd = 10350.0f;
                info.headStart = 800.0f;
                info.whichFlockAnimalType = FlockType.kFlockSheep;
                this.AddFlock(info);
            }
            else if (levelFileId == (int)LevelBuilder_Ross.Enum2.kMud3_1_PenCup_Race1_IceHoles) {
                Flock.FlockInfo info = new Flock.FlockInfo();
                info.yPositionStart = 4250.0f;
                info.yPositionEnd = 9500.0f;
                info.speed = 4.5f;
                info.whichFlockAnimalType = FlockType.kFlockSheep;
                info.whichFlock = (int)WhichFlockType.kWFT_DownThroughTrees;
                info.headStart = 1200.0f;
                this.AddFlock(info);
            }
            else if (levelFileId == 307) {
                this.AddFlock_CurvyLines();
            }

        }

        public void CheckLoadSlowerPig()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                return;
            }

            Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
            if (savedInfo.level[playingLevel].usingSlowerPig) {
                return;
            }

            if (((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel) != TrophyType.kTrophy_NotGot) {
                return;
            }

            Profile.NotSavedProfileInfo info = ((Globals.g_world.frontEnd).profile).notSavedInfo;

            #if FAIL_ONCE_AND_SLOWER_PIG
                const int kNumCFailsNeeded = 1;
                const int kNumCFailsBTNeeded = 0;
            #else
                const int kNumCFailsNeeded = 2;
                const int kNumCFailsBTNeeded = 1;
            #endif

            if (info.level[playingLevel].numConsecutiveFails < kNumCFailsNeeded) {
                return;
            }

            if (info.level[playingLevel].numConsecutiveFailsByTime < kNumCFailsBTNeeded) {
                return;
            }

            savedInfo.level[playingLevel].usingSlowerPig = true;
            ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
            ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
            this.ReadPiggyData();
        }

        public void CheckLoadSlowerPig3apples()
        {
            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                return;
            }

            Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
            if (savedInfo.level[playingLevel].usingSlowerPig3apples) {
                return;
            }

            if (((Globals.g_world.frontEnd).profile).GetTrophyGot(playingLevel) != TrophyType.kTrophy_TwoApples) {
                return;
            }

            Profile.NotSavedProfileInfo info = ((Globals.g_world.frontEnd).profile).notSavedInfo;

           
                const int kNumCFailsNeeded = 3;
                const int kNumCFailsBTNeeded = 2;
           
            if (info.level[playingLevel].numConsecutiveFails3apples < kNumCFailsNeeded) {
                return;
            }

            if (info.level[playingLevel].numConsecutiveFailsByTime3apples < kNumCFailsBTNeeded) {
                return;
            }

            savedInfo.level[playingLevel].usingSlowerPig3apples = true;
            ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
            ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
            this.ReadPiggyData();
        }

        public void CheckCrystalBackgroundActivity(bool shouldBeEnabled)
        {
            if (true) {
                if (!Globals.useRetina) {

                    #if USE_CRYSTAL
                    #endif

                }

            }

        }

        public void SetSpecialJumpLengths()
        {
            for (int i = 0; i < numRamps; i++) {
                int closestTrampoline = -1;
                float closestTramp = 1000.0f;
                for (int j = 0; j < numGameObject[(int) GameObjectType.kGameObject_Trampoline]; j++) {
                    float distanceInFront = (trampoline[j]).position.y - (ramp[i]).mapPosition.y;
                    if (distanceInFront > 100.0f) {
                        if ((distanceInFront < 600.0f) && (distanceInFront < closestTramp)) {
                            closestTramp = distanceInFront;
                            closestTrampoline = j;
                        }

                    }

                }

                if (closestTrampoline != -1) {
                    (ramp[i]).SetLeapLengthAdjustment(closestTramp);
                }

            }

        }

        public void SetSpecialJumpLengthsTrampolines()
        {
            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Trampoline]; i++) {
                int closestTrampoline = -1;
                float closestTramp = 1000.0f;
                for (int j = 0; j < numGameObject[(int) GameObjectType.kGameObject_Trampoline]; j++) {
                    float distanceInFront = (trampoline[j]).position.y - (trampoline[i]).position.y;
                    if (distanceInFront > 100.0f) {
                        if ((distanceInFront < 800.0f) && (distanceInFront < closestTramp)) {
                            closestTramp = distanceInFront;
                            closestTrampoline = j;
                        }

                    }

                }

                if (closestTrampoline != -1) {
                    CGPoint targetPos = (trampoline[closestTrampoline]).position;
                    targetPos.y += 80.0f;
                    (trampoline[i]).SetLeapTarget(targetPos);
                }

            }

        }

        public void SetupEntireMap()
        {
            this.ResetMapObjects();
            tileMap.InitialiseBeforeObjectsAdded(lBuilder.currentScene);
            this.ResetUpdateLists();
            this.SetupScene();
            this.LoadLevelFromData();
            this.AddSpecialObjects();
            this.SetupObjectGroundLevels();
            this.FindCliffStarts();
            this.SetSpecialJumpLengths();
            this.SetSpecialJumpLengthsTrampolines();
            tileMap.StartOfRace();
        }

        public void SetupNumPlayersAllowedPastLine()
        {

            #if RACE_AS_PIGGY
                numAllowedPastLine = 3;
            #else
                int numPiggiesInRace = lastPiggyIndex - startFromPiggy;
                if (playingLevel >= ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) {
                    numAllowedPastLine = 3;
                }
                else {
                    numAllowedPastLine = numPiggiesInRace;
                }

            #endif

        }

        public void SetPlayerStartingPositions()
        {
            const float kSideGaps = 52.0f;
            const float kTriangleHeight = 37.0f;
            const float kTriangleY = 160.0f;
            CGPoint startPosition = Utilities.CGPointMake(Constants.TRACK_CENTRE_LINE, kTriangleY + kTriangleHeight);
            (playerPiggy[0]).SetStartPosition(startPosition);
            startPosition = Utilities.CGPointMake(Constants.TRACK_CENTRE_LINE - kSideGaps, kTriangleY);
            (playerPiggy[1]).SetStartPosition(startPosition);
            startPosition = Utilities.CGPointMake(Constants.TRACK_CENTRE_LINE + kSideGaps, kTriangleY);
            (playerPiggy[2]).SetStartPosition(startPosition);
            if (lastPiggyIndex == 2) {
                startPosition = Utilities.CGPointMake(Constants.TRACK_CENTRE_LINE - (kSideGaps * 0.8f), kTriangleY + (kTriangleHeight / 2.0f));
                (playerPiggy[0]).SetStartPosition(startPosition);
                startPosition = Utilities.CGPointMake(Constants.TRACK_CENTRE_LINE + (kSideGaps * 0.8f), kTriangleY + (kTriangleHeight / 2.0f));
                (playerPiggy[1]).SetStartPosition(startPosition);
            }

            #if RACE_AS_PIGGY
                player.SetStartPosition((playerPiggy[Constants.RECORDING_WHICH_PIGGY]).position);
            #endif

        }

        public void NewStateGetReady()
        {
			isPlayerLow = false;
			
            if (playingLevel != lastPlayedLevel) {
                my_Rank = -1;
                lastPlayedLevel = playingLevel;
            }
			
			Globals.g_world.game.tileMap.SetStartGame();
			Globals.g_world.game.SetSpritesToTileCamera(false);

			for (int i = 0; i <  (int)Enum2.kMaxMapObjects; i++) 
			{
                if (mapObject[i] != null)
				{
					mapObject[i].StopRender();		
				}
            }
			
            this.DropMenuAssetsPreGame();
            desiredRenderScale = 0.8f;
            actualRenderScale = 0.8f;
            this.CheckCrystalBackgroundActivity(false);
            reactivatedCrystalBackground = false;
            flushedAt3seconds = false;
            shownHudYet = false;
            startedGetLeaderboardPosYet = false;
            playedWinMusicYet = false;
            raceStartedAtTime = -1.0f;
            multiplayerInSync = false;
            serverSentMessage = false;
            timeToStart = -1.0f;
            this.CheckLoadSlowerPig();
            this.CheckLoadSlowerPig3apples();
            (Globals.g_world.audio).CheckAndLoadCommonGameEffects();
            withinMapObjectUpdate = false;
            lBuilder.SetupObjects();
            if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                (SoundEngine.Instance()).AVChangeToTrackP1P2((int)Audio.Enum2.kSoundEffect_StartLevel, 0, 1);
            }
            else if (((Globals.g_world.frontEnd).profile).preferences.soundFxOn) {
                if (Globals.g_world.artLevel == 0) {
                    (SoundEngine.Instance()).AVFadeOutAndStop(0.5f);
                }

            }

            for (int i = 0; i <  (int)Enum2.kMaxFlowerHeads; i++) {
                (flowerHead[i]).Reset();
            }

            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Cows]; i++) {
                (cow[i]).NewGameStateGetReady();
            }

            flagSaveProfileInfo = false;
            tileMap.SetScale(1);
			tileMap.SetupTilePositions();
            prevOffset = Utilities.CGPointMake(0, 0);
            prevOffset2 = Utilities.CGPointMake(0, 0);
            getReadyPhase = 1;
            getReadyNumberIndex = 0;
            lightYPos = -150;
            lightXPos = 60;
            justUnlockedCup = -1;
            lightYVelocity = 55;
            timeOfLastOink = 0;
            timeOfLastTreeBumpSound = 0;
            this.SetupEntireMap();
            numTrafBonce = 0;
            yScrollVelocity = -1;
            this.SetupNumPlayersAllowedPastLine();
            if (Constants.GAME_Y_ORIENTATION == 1) scrollPosition = Utilities.CGPointMake(0.0f, 480.0f);
            else scrollPosition = Utilities.CGPointMake(0.0f, 0.0f);

            tiltMuchTooBig = false;
            this.ResetControlTouches();
            prevScrollPosition = scrollPosition;
			//player.SetupNoGoZone(-1);
			player.SetStartOfRace();
            numPlayersOnScreen = lastPiggyIndex - startFromPiggy + 1;
            flagStartPause = false;
            newBestTimeRecorded = false;
            fingerControl.SetStartOfRace();

            #if UP_RACE
                player.SetBaseScale(Constants.SPRITE_BASE_SCALE * 1.1f);
            #else
                player.SetBaseScale(Constants.SPRITE_BASE_SCALE);
            #endif

            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Flock]; i++) {
                (flock[i]).StartRace();
            }
			
            for (int i = 0; i < 3; i++) {
                    (playerPiggy[i]).SetupRacingBrain();
					(playerPiggy[i]).SetStartOfRace();
			}			
			
            for (int i = startFromPiggy; i < lastPiggyIndex; i++) 
			{
                if (i != Constants.RECORDING_WHICH_PIGGY) 
				{
//                    (playerPiggy[i]).SetupRacingBrain();
                    (((playerPiggy[i]).racingBrain).racingLine).CreateRacingLineFromGhost(ghostPiggy[i]);
                    (ghostPiggy[i]).SetStartOfRace();
					                    (playerPiggy[i]).SetupNoGoZone(i);

//					(playerPiggy[i]).SetStartOfRace();
                    (playerPiggy[i]).SetBaseScale(Constants.SPRITE_BASE_SCALE * 1.0f);
//                    (playerPiggy[i]).SetupNoGoZone(i);
                    (playerPiggy[i]).SetControlType(PlayerControlType.kControlAI);
                }

            }

            this.SetPlayerStartingPositions();
            this.SetupPiggySpeeds();

            #if PLAYING_SIMULATOR_VIDEO
                player.SetControlType((int) PlayerControlType.kControlGhost);
            #endif

            #if !AI_PIGGIES
                this.UpdatePiggies(false);
            #endif

            playingGhost.SetStartOfRacePlaying();

            #if RUN_AND_RECORD_PIG_TIMES
                int cup = playingLevel % 8;
                if (cup == 0) {
                    int cupId = playingLevel / 8;
                }

            #endif

            rainbowUpdateBackDist = -1200.0f;
            buildingUpdateBackDist = -400.0f;
            if (playingCustom == 0) {
                int realLevelId = LevelBuilder_Ross.levelOrder[playingLevel];
                if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud8_6_BlueTulips) {
                    rainbowUpdateBackDist = -120.0f;
                }
                else if (realLevelId == (int)LevelBuilder_Ross.Enum2.kMud5_2_FrmCup_Race2_GetUp) {
                    buildingUpdateBackDist = -2800.0f;
                }

            }

            recordingGhost.SetStartOfRace();
            UIAcceleration acceleration;
            acceleration = new UIAcceleration();
            this.SetAccelerometer(acceleration);
            whichTiltSpeed = 0;
            currentTiltSpeedY = 0.0f;
            avgTiltSpeedTotalY = 0.0f;
            prevAccelerationY = 0.0f;
            distanceSinceTrackDown = 0.0f;
            hitClosedGate = false;
            raceTimer = 0;
            gameTimer = 0;
            hud.NewGameStateGetReady();
            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_CrossingThing]; i++) {
                (crossingThing[i]).SetStartOfRace();
            }

            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Tree]; i++) {
                (tree[i]).SetStartOfRace();
            }

            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Trampoline]; i++) {
                (trampoline[i]).SetStartOfRace();
            }

            switch ((SceneType)lBuilder.currentScene) {
            case SceneType.kSceneGrass :
                ////glClearColor(0.4f, 0.8f, 0.1f, 1.0f);
                break;
            case SceneType.kSceneMud :
                ////glClearColor(0.7f, 0.5f, 0.1f, 1.0f);
                break;
            case SceneType.kSceneIce :
                ////glClearColor(0.5f, 0.6f, 1.0f, 1.0f);
                break;
            case SceneType.kSceneDesert :
                ////glClearColor(0.8f, 0.6f, 0.1f, 1.0f);
                break;
            case SceneType.kSceneMoon :
                ////glClearColor(1.0f, 0.6f, 0.75f, 1.0f);
                break;
            default :
                Globals.Assert(false);
                break;
            }

        }

        public Flock GetFlock(int which)
        {
            Globals.Assert(which <  (int)Enum2.kMaxFlocks);
            return flock[which];
        }

        public Tractor GetTractor(int tracIndex)
        {
            Globals.Assert(tracIndex < numGameObject[(int) GameObjectType.kGameObject_Tractor]);
            return tractor[tracIndex];
        }

        public Pond GetPond(int pondIndex)
        {
            Globals.Assert(pondIndex < numGameObject[(int) GameObjectType.kGameObject_Ponds]);
            return pond[pondIndex];
        }

        public FlowerCliff GetRiver(int pondIndex)
        {
            Globals.Assert(pondIndex < numRivers);
            return river[pondIndex];
        }

        public Building GetBuilding(int bIndex)
        {
            Globals.Assert(bIndex < numGameObject[(int) GameObjectType.kGameObject_Buildings]);
            return building[bIndex];
        }

        public void ChangeToGameState(GameState inGameState)
        {
            if (inGameState == GameState.e_ShowLevel) {
                (Ztransition.GetTransition()).SetPTexture(this.GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).SetPBackTexture(this.GetTexture((TextureType) TextureType.kTexture_HudLoading));
                (Ztransition.GetTransition()).StartP1P2((int) inGameState,  TransitionArea.kTransition_Game,  TransitionType.e_WhirlingShape);
                ((Ztransition.GetTransition()).zobject).SetShowScale(1.0f);
                (((Ztransition.GetTransition()).zobject).GetInterpolation(0)).SetEndValue(0.99f);
            }
            else {
                (Ztransition.GetTransition()).SetPTexture(this.GetTexture((TextureType) TextureType.kTexture_Whiteout));
                (Ztransition.GetTransition()).StartP1P2((int) inGameState, TransitionArea.kTransition_Game,  TransitionType.e_Fade);
            }

        }

        public void PlayRandomOpponentSound(CGPoint inPosition)
        {
            if (Utilities.GetRand( 2) == 0) {
                (Globals.g_world.audio).PlayRandomPigOinkP1(1.0f, inPosition);
            }
            else {
                (Globals.g_world.audio).PlayRandomPigLaugh(inPosition);
            }

        }

        public void PlayPigBumpSheepSoundP1(Player inPlayer1, Player inPlayer2)
        {
            if ((inPlayer1.playerType == (int) PlayerType.kPlayerSheep) || (inPlayer2.playerType == (int) PlayerType.kPlayerSheep)) {
                if (Utilities.GetRand( 2) == 0) {
                    if (Utilities.GetRand( 2) == 0) {
                        (Globals.g_world.audio).PlayRandomShaunBaa();
                    }
                    else {
                        (Globals.g_world.audio).PlayRandomShaunImpact();
                    }

                }
                else {
                    this.PlayRandomOpponentSound(inPlayer1.position);
                }

            }
            else {
                if (Utilities.GetRand( 2) == 0) {
                    this.PlayRandomOpponentSound(inPlayer1.position);
                }

            }

            timeOfLastOink = raceTimer;
        }

        public void ReadPiggyData()
        {
            for (int i = 0; i < lastPiggyIndex; i++) {
                if (i != Constants.RECORDING_WHICH_PIGGY) {

                    #if READ_GHOST_FILES_OLD_WAY
                        NSDictionary dict = this.GetBestTimeAndGhostDictionaryP1P2P3(i, playingLevel, ((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet()
                          , true);
                        (ghostPiggy[i]).ReadDataFromDictionaryUsingIndices(dict);
                    #else
                        String fileName = this.GetBestTimeAndGhostBinaryFileP1P2P3(i, playingLevel, (int) ((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet(),
                          true);

					String fullFileName = "Piggies/" + fileName;				
					//var sr = new BinaryReader(File.Open(fullFileName, FileMode.Open));//Application.dataPath + "/" + "Resources/Levels/LevelBin0.lev");					
					
					Debug.Log ("Read Piggy Data " + fullFileName);
					
					TextAsset asset = Resources.Load(fullFileName) as TextAsset;
					Stream s = new MemoryStream(asset.bytes);
					BinaryReader sr = new BinaryReader(s);
					
					if (sr != null) {
                            (ghostPiggy[i]).ReadDataFromBinaryFileUsingIndices(sr);
//                            fclose (fp);
                        }
                        else {
                            (ghostPiggy[i]).Reset();
                        }

                    #endif

                }

            }

        }

        public void ReadGhostData()
        {
            int set = (int) ((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet();
            if (((Globals.g_world.frontEnd).profile).GetBestTimeP1(((Globals.g_world.frontEnd).profile).GetRelevantBestTimeSet(), playingLevel) == 1000) {
                playingGhost.Reset();
                whichSheepGhostLoaded = playingLevel;
                whichSheepGhostLoadedSet = set;
                return;
            }

            if ((whichSheepGhostLoaded != playingLevel) || 
				(whichSheepGhostLoadedSet != set)) 
			{
                this.ReadGhostInformationFromData();
                whichSheepGhostLoaded = playingLevel;
                whichSheepGhostLoadedSet = set;
            }

        }

        public void NewStateFeelGood()
        {
            this.LoadFeelGoodTextures();
            (SoundEngine.Instance()).EndSoundAV((int)Audio.Enum2.kSoundEffect_MenuMusicLoop);
            if (((Globals.g_world.frontEnd).profile).preferences.soundFxOn) {
                (Globals.g_world.audio).PlayRandomSheepWin();
            }

            if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                int cupId = ((Globals.g_world.frontEnd).profile).GetCupFromLevel(playingLevel);
                if (cupId % 2 == 0) (SoundEngine.Instance()).AVPlayAndFadeInP1((int)Audio.Enum2.kSoundEffect_MusicLoop, 0.3f);
                else (SoundEngine.Instance()).AVPlayAndFadeInP1((int)Audio.Enum2.kSoundEffect_CountrysideMusic, 0.3f);

            }

            hud.NewGameState_FeelGood();

						Globals.g_analytics.UnlockNewStage(((Globals.g_world.frontEnd).profile).GetCupFromLevel(playingLevel));
        }

        public int IsInTractor(CGPoint inPos)
        {
            const float kSquareWidth = 80.0f;
            const float kSquareHeight = 50.0f;
            for (int i = startUpdateId[(int) GameObjectType.kGameObject_Tractor]; i < endUpdateId[(int) GameObjectType.kGameObject_Tractor]; i++) {
                int arrayIndex = ((updateOrder[(int) GameObjectType.kGameObject_Tractor])[i]);
                CGPoint tracPos = (tractor[arrayIndex]).position;
                tracPos.y -= 32.0f;
                if (Utilities.IsWithinRectangleP1P2P3(inPos, tracPos, kSquareWidth, kSquareHeight)) {
                    return arrayIndex;
                }

            }

            return -1;
        }

        public int IsInFlock(CGPoint inPos)
        {
            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Flock]; i++) {
                if ((flock[i]).updateStart != -1) {
                    if ((flock[i]).updateEnd != -1) {
                        FlockAnimal endAnimal = (flock[i]).GetAnimal((flock[i]).updateStart);
                        FlockAnimal startAnimal = (flock[i]).GetAnimal((flock[i]).updateEnd);
                        float yEndPos = endAnimal.position.y;
                        float yStartPos = startAnimal.position.y;
                        if ((endAnimal.position.x < 0.0f) || (startAnimal.position.x < 0.0f)) {
                            return -1;
                        }

                        if ((endAnimal.position.x > 384.0f) || (startAnimal.position.x > 384.0f)) {
                            return -1;
                        }

                        if (inPos.y > (yStartPos - 140.0f)) {
                            if (inPos.y < (yEndPos + 180.0f)) {
                                if ((flock[i]).hasPathForAI) {
                                    return i;
                                }

                            }

                        }

                    }

                }

            }

            return -1;
        }

        public bool IsOnIgloo(CGPoint mapPos)
        {
            int xTilePos = (int) (mapPos.x / 64.0f);
            int yTilePos = (int) (mapPos.y / 64.0f);

                xTilePos += Constants.NUM_TILES_NOT_PLAYABLE_TO_LEFT;

            int tileId = (tileMap.GetTileGrid()).GetTileIdP1(xTilePos, yTilePos);
            int objectId = (int)lBuilder.GetObjectFromTileId(tileId);
            return (objectId == (int) ObjectType.kOT_Igloo);
        }

        bool IsOnMudHump(CGPoint mapPos)
        {
            int xTilePos = (int) (mapPos.x / 64.0f);
            int yTilePos = (int) (mapPos.y / 64.0f);

           // #if ZOOMING_MATRIX_TEST
                xTilePos += Constants.NUM_TILES_NOT_PLAYABLE_TO_LEFT;
           // #endif

            int tileId = (tileMap.GetTileGrid()).GetTileIdP1(xTilePos, yTilePos);
            int objectId = (int)lBuilder.GetObjectFromTileId(tileId);
            return (objectId == (int) ObjectType.kOT_HillockFarmyard);
        }

        bool IsOnBuilding(CGPoint mapPos)
        {
            int xTilePos = (int) (mapPos.x / 64.0f);
            int yTilePos = (int) (mapPos.y / 64.0f);

          //  #if ZOOMING_MATRIX_TEST
                xTilePos += Constants.NUM_TILES_NOT_PLAYABLE_TO_LEFT;
           // #endif

            int tileId = (tileMap.GetTileGrid()).GetTileIdP1(xTilePos, yTilePos);
            int objectId = (int)lBuilder.GetObjectFromTileId(tileId);
            return ((objectId == (int) ObjectType.kOT_House) || (objectId == (int) ObjectType.kOT_BigSidewaysShed) || (objectId == (int) ObjectType.kOT_Barn));
        }

        public void SetupObjectGroundLevels()
        {
            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Rainbows]; i++) {
                CGPoint mapPos = (rainbow[i]).position;
                if (this.IsOnBuilding(mapPos)) {
                    (rainbow[i]).SetGroundLevel(35.0f);
                }

                if (this.IsOnMudHump(mapPos)) {
                    (rainbow[i]).SetGroundLevel(48.0f);
                }

                if (this.IsOnIgloo(mapPos)) {
                    (rainbow[i]).SetGroundLevel(48.0f);
                }

            }

            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_BoostArrows]; i++) {
                CGPoint mapPos = (boostArrow[i]).position;
                if (this.IsOnBuilding(mapPos)) {
                    (boostArrow[i]).SetGroundLevel(35.0f);
                }

            }

            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_NoGoZones]; i++) {
                CGPoint mapPos = (noGoZone[i]).mapPosition;
                if ((noGoZone[i]).type != NoGoType.e_Pumpkin) {
                    continue;
                }

                if (this.IsOnBuilding(mapPos)) {
                    (noGoZone[i]).SetGroundLevel(30.0f);
                    float currentCeilingHeight = (noGoZone[i]).ceilingHeight;
                    (noGoZone[i]).SetCeilingHeight(35.0f + currentCeilingHeight);
                }

            }

        }

        public void SetupNumPiggies()
        {
            startFromPiggy = 0;
            lastPiggyIndex = 3;
            if (playingLevel < 4) {
                lastPiggyIndex = 1;
            }
            else if (playingLevel < 12) {
                lastPiggyIndex = 2;
            }

            #if SHOW_BOTH_PIG3
                lastPiggyIndex = 4;
            #endif

            if ((Globals.g_world.frontEnd).exitInfo.multiplayer) {
                lastPiggyIndex = 1;
                startFromPiggy = 0;
            }

            if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                startFromPiggy = 0;
                lastPiggyIndex = 0;
            }

            #if ONE_PIG_PER_RACE
                startFromPiggy = 0 + Constants.CAMERA_FOLLOW_WHICH_PIGGY;
                lastPiggyIndex = 1 + Constants.CAMERA_FOLLOW_WHICH_PIGGY;
            #endif

        }

 //       public void AlertViewClickedButtonAtIndex(UIAlertView alertView, NSInteger buttonIndex)
   //     {
/*            if (alertView == rateAlert) {
                Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
                if (buttonIndex == 0) {
                    savedInfo.numRacesWithoutBeingAskedToRate = -1;
                }
                else if (buttonIndex == 1) {
                    NSURL //url = NSURL.URLWithString("itms-apps://itunes.com/apps/fleecelightning");
                    //(UIApplication.SharedApplication()).OpenURL(url);
                    savedInfo.numRacesWithoutBeingAskedToRate = -1;
                }
                else if (buttonIndex == 2) {
                    savedInfo.numRacesWithoutBeingAskedToRate = 0;
                }

                ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
                ((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs();
            }*/

  //      }

        public void OpenHowYouLikeMeNowDialogue()
        {
//           rateAlert.Show();

            string gameName = "Fleece Lightning";
            string alertMessage;
            string buttonRate;
            string buttonNotNow;
            string buttonNever;
            if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
				alertMessage = String.Format("Bitte bewerte \n{0}\n im App Store \nwenn es dir gef#llt", gameName);
                buttonRate = "Jetzt Bewerten";
                buttonNotNow = "Vielleicht Sp#ter";
                buttonNever = "Nicht Nochmal Fragen";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                alertMessage = String.Format("如果你喜欢 \nFleece Lightning，\n请在App Store里评分。", gameName);
                buttonRate = "“现在就评分”";
                buttonNotNow = "“之后再说”";
                buttonNever = "“不要再问我”";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                alertMessage = String.Format(
                  "もしあなたが「フリース・\nライトニング」を楽しめ\nているのなら、App　Store\nで評価して下さい。");
                buttonRate = "「すぐ評価」";
                buttonNotNow = "「後で評価」";
                buttonNever = "「二度と表示しない」";
            }
            else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                alertMessage = String.Format("Si vous aimez\n Fleece Lightning,\n merci de le noter\n sur l'App Store.", gameName);
                buttonRate = "Noter";
                buttonNotNow = "Plus tard";
                buttonNever = "Ne plus demander";
            }
            else {
                alertMessage = String.Format("If you are enjoying\n{0}\nplease rate it\n in the App Store", gameName);
                buttonRate = "Rate It Now";
                buttonNotNow = "Maybe Later";
                buttonNever = "Don't ask me again";
            }


			UnityUIAlert.UnityUIAlertInfo uInfo = new UnityUIAlert.UnityUIAlertInfo();
			uInfo.type = UnityUIAlertType.e_RateMe;
			uInfo.title = "";
			uInfo.message = alertMessage;
			uInfo.numButtons = 3;
			uInfo.textScale = 0.6f;
			uInfo.useNSStringAnyway = false;

			uInfo.buttonString[0] = buttonRate;
			uInfo.buttonString[1] = buttonNotNow;
			uInfo.buttonString[2] = buttonNever;
			Globals.g_world.unityUIAlert.Show(uInfo);


        }

        public void IncreaseHowYouLikeMeNowCounter()
        {
            Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
            if (savedInfo.numRacesWithoutBeingAskedToRate >= 0) {
                savedInfo.numRacesWithoutBeingAskedToRate++;
                ((Globals.g_world.frontEnd).profile).SetProfileInfo(savedInfo);
                flagSaveProfileInfo = true;
            }

        }

        public void UpdateHowYouLikeMeNow()
        {
           int kNumTriesForRateMe = 32;

           if (Constants.TESTING_HOWYOULIKEMENOW)
                kNumTriesForRateMe = 2;

            Profile.ProfileInformation savedInfo = ((Globals.g_world.frontEnd).profile).profileInfo;
            
//						this.OpenHowYouLikeMeNowDialogue();


						if (savedInfo.numRacesWithoutBeingAskedToRate >= 0) {

              //  #if TESTING_HOWYOULIKEMENOW
                //    const int kThirdPenguinLevel = 1;
                  //  const int kLastLevelCup3 = 1;
                //#else
                    const int kThirdPenguinLevel = 24;
                    const int kLastLevelCup3 = 23;
                //#endif

                bool gotAppleOnFirstLevelCup4 = ((Globals.g_world.frontEnd).profile).GetTrophyGot(kThirdPenguinLevel) > TrophyType.kTrophy_NotGot;
                bool gotAppleOnLastLevelCup3 = ((Globals.g_world.frontEnd).profile).GetTrophyGot(kLastLevelCup3) > TrophyType.kTrophy_NotGot;
                bool canAskYet = (gotAppleOnLastLevelCup3 || gotAppleOnFirstLevelCup4 || Constants.TESTING_HOWYOULIKEMENOW);
                if ((savedInfo.numRacesWithoutBeingAskedToRate >= kNumTriesForRateMe) && (canAskYet)) {
                    this.OpenHowYouLikeMeNowDialogue();
                }
                else {
                }

            }

        }

        public void NewStateShowLevel ()
				{
						shownPullTabYet = false;
						this.LoadShowLevelAndTip ();
						this.UpdateHowYouLikeMeNow ();
						int nextLevelToPlay;
						if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel)
								nextLevelToPlay = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;
						else
								nextLevelToPlay = ((Globals.g_world.frontEnd).profile).selectedLevel;

						#if PRINTOUT_VALIDATION_NUMBERS
                for (int i = nextLevelToPlay; i < 80; i++) {
                    ((Globals.g_world.frontEnd).profile).SetSelectedLevel(i);
                    lBuilder.ReadSomeLevelDataP1(i, false);
                }

						#else
						lBuilder.ReadSomeLevelDataP1 (nextLevelToPlay, false);
						#endif
			
						Globals.g_world.LoadSceneAtlases ();

						if (lBuilder.currentScene == (int)SceneType.kSceneGrass)
								this.SetGameThingsAtlas (Globals.g_world.GetAtlas (AtlasType.kAtlas_GameThingsGrass));
						else if (lBuilder.currentScene == (int)SceneType.kSceneMud)
								this.SetGameThingsAtlas (Globals.g_world.GetAtlas (AtlasType.kAtlas_GameThingsMud));
						else if (lBuilder.currentScene == (int)SceneType.kSceneDesert)
								this.SetGameThingsAtlas (Globals.g_world.GetAtlas (AtlasType.
              kAtlas_GameThingsGrassDesert
								)
								);
						else if (lBuilder.currentScene == (int)SceneType.kSceneIce)
								this.SetGameThingsAtlas (Globals.g_world.GetAtlas (AtlasType.kAtlas_IceSprites));
						else if (lBuilder.currentScene == (int)SceneType.kSceneMoon)
								this.SetGameThingsAtlas (Globals.g_world.GetAtlas (AtlasType.
              kAtlas_GameThingsGrassDesert
								)
								);
									else {
								Globals.Assert (false);
						}

			
			
			
						this.SetupEntireMap ();

						#if PERFORM_LEVEL_FILE_VALIDATION_CHECK
                if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {
                    if (!lBuilder.CheckFileIntegrity()) {
                        Globals.g_world.SetGoingToFrontEndFromShowLevel(1);
                        goBackToFrontEnd = true;
                        return;
                    }

                }

						#endif

//						Globals.g_world.LoadSceneAtlases ();
						if (!(Globals.g_world.frontEnd).exitInfo.playCustomLevel) {

								#if !LITE_VERSION
								//              int stage = ((Globals.g_world.frontEnd).profile).GetCupFromLevel(nextLevelToPlay);
//                    if (stage == kCupStar) {
								//                      this.LoadStarCupStar();
								//                }

								#endif

						}

						lastPiggyIndex = 1;
						PlayerType opponent = PlayerType.kPlayerPig;
						int bonusLevel1 = ((int)Profile.Enum6.kNumLevelsNotBonus);
						int bonusLevel2 = ((int)Profile.Enum6.kNumLevelsNotBonus + 1);
						if (nextLevelToPlay == bonusLevel1) {
								opponent = PlayerType.kPlayerOstrich;
						} else if (nextLevelToPlay == bonusLevel2) {
								opponent = PlayerType.kPlayerPenguin;
						}

						currentOpponent = opponent;
						this.LoadOpponentSpecificTextures ((int)opponent);
						this.LoadOtherPlayer (opponent);
						for (int i = 0; i <  (int)Enum2.kMaxPiggiesPerLevel; i++)
								(playerPiggy [i]).SetPlayerType ((int)opponent);

						(Globals.g_world.audio).CheckAndLoadNewSceneSoundEffects (lBuilder.currentScene);
						(Globals.g_world.audio).CheckAndLoadNewOpponentSoundEffects ((int)opponent);

						this.LoadSceneSpecificTextures (lBuilder.currentScene);
						tileMap.SetCurrentScene (lBuilder.currentScene);
						(ParticleSystemRoss.Instance ()).SetMainAtlas ((int)AtlasType.kAtlas_ParticlesScene);
						hud.Reset ();
						hud.ShowNextLevel ();
   
						if ((Globals.g_world.frontEnd).exitInfo.playCustomLevel) 
			{
				playingCustom = 1;
						} else {
				playingCustom = 0;
						}
//			playingCustom = (int) (Globals.g_world.frontEnd).exitInfo.playCustomLevel;

			if (playingCustom == 0) playingLevel = ((Globals.g_world.frontEnd).profile).selectedLevel;
            else playingLevel = ((Globals.g_world.frontEnd).profile).selectedLevelCustom;

            this.SetupNumPiggies();

            #if PLAYING_SIMULATOR_VIDEO
                string inName;
                inName = String.Format("videoDataLevel{0}.vd", playingLevel);
                NSDictionary dict = Utilities.GetDictionaryFromResources(inName);
                playingGhost.ReadDataFromDictionary(dict);
            #else
                this.ReadGhostData();
            #endif

            this.ReadPiggyData();
            if (((Globals.g_world.frontEnd).profile).preferences.soundFxOn) {
                (SoundEngine.Instance()).AVChangeToTrackP1((int)Audio.Enum2.kSoundEffect_Ambience, 0.54f);
                (Globals.g_world.audio).StartBirds();
            }
            else {
                (SoundEngine.Instance()).AVFadeOutAndStop(0.5f);
            }

        }

        public void ExitGameStatePaused(GameState nextState)
        {

            #if CONVERT_LEVELS_TO_BINARY_FILES

             //   lBuilder.WriteLevelToBinaryFile();
            #endif

            this.CheckCrystalBackgroundActivity(false);
            if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
            }

            this.ResetControlTouches();
        }

        public void ExitGameStateShowLevel(GameState nextState)
        {
            hud.ExitGameState_ShowLevel();
        }

        public int GetNumPiggies()
        {
            return lastPiggyIndex - startFromPiggy;
        }

        public void ExitGameStateP1(GameState inGameState, GameState nextState)
        {
            switch (inGameState) {
            case GameState.e_FeelGoodScreen :
                this.ExitGameState_FeelGood();
                break;
            case GameState.e_GamePlay :
                this.ExitGameState_GamePlay();
                break;
            case GameState.e_AppleCartScreen :
                this.ExitGameState_AppleCart();
                break;
            case GameState.e_SpeedBoostScreen :
                this.ExitGameState_SpeedBoost();
                break;
            case GameState.e_AnotherPiggy :
                this.ExitGameState_AnotherPiggy();
                break;
            case GameState.e_ShowResultsWin :
            case GameState.e_ShowResultsLoseTooSlow :
            case GameState.e_ShowResultsLoseToPiggy :
                this.ExitGameStateShowResults(nextState);
                break;
            case GameState.e_Paused :
                this.ExitGameStatePaused(nextState);
                break;
            case GameState.e_ShowLevel :
                this.ExitGameStateShowLevel(nextState);
                break;
            default :
                break;
            }

        }

        public void ExitGameState_AnotherPiggy()
        {
			hud.anotherPiggyScreen.Hide();
			hud.DeallocAnotherPiggy();
            this.ReleaseAnotherPiggyTextures();
        }

        public void ExitGameState_SpeedBoost()
        {
            this.ReleaseSpeedBoostTextures();
        }

        public void ExitGameState_AppleCart()
        {
            this.ReleaseAppleCartTextures();
        }

        public void ExitGameState_FeelGood()
        {
            this.CheckAndReleaseStarCupTexture();
            this.ReleaseFeelGoodTextures();
            if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
                (SoundEngine.Instance()).AVFadeOutAndStop(0.5f);
            }
			hud.ExitGameState_FeelGood();
			hud.DeallocFeelGood();
		}

        public void ExitGameState_GamePlay()
        {
            player.SetEndOfRace();
        }

        public void NewStateGameShowResults()
        {

            #if TEST_LEADERBOARDRANK
                Globals.g_world.ShowLeaderboardRank(10);
            #endif
			
			tileMap.StopRender();
			
            Globals.g_world.DisappearLeaderBoardThing();
            shownPullTabYet = false;
            gameMusicStoppedYet = false;
            savedProfileInfoYet = false;
            for (int i = 0; i < numGameObject[(int) GameObjectType.kGameObject_Cows]; i++) {
                (cow[i]).NewGameStateShowResults();
            }

        }

        public void SetNewGameState(GameState inGameState)
        {
            this.ExitGameStateP1(gameState, inGameState);
            gameState = inGameState;
            switch (inGameState) {
            case GameState.e_Paused :
                this.NewStatePaused();
                break;
            case GameState.e_GetReady :
                this.NewStateGetReady();
                break;
            case GameState.e_AppleCartScreen :
                this.NewStateAppleCart();
                break;
            case GameState.e_SpeedBoostScreen :
                this.NewStateSpeedBoost();
                break;
            case GameState.e_AnotherPiggy :
                this.NewStateAnotherPiggy();
                break;
            case GameState.e_ShowLevel :
                this.NewStateShowLevel();
                break;
            case GameState.e_FeelGoodScreen :
                this.NewStateFeelGood();
                break;
            case GameState.e_GamePlay :
                this.NewStateGamePlay();
                break;
            case GameState.e_ShowResultsWin :
            case GameState.e_ShowResultsLoseTooSlow :
            case GameState.e_ShowResultsLoseToPiggy :
                this.NewStateGameShowResults();
                break;
            default :
                break;
            }

            stateTimer = 0;
        }

        public void AllocGameObjects()
        {
            for (int i = 0; i <  (int)Enum2.kMaxMapObjects; i++) {
                mapObject[i] = new MapObject();
            }

            for (int i = 0; i <  (int)Enum2.kMaxNoGoZones; i++) {
                noGoZone[i] = null;
            }

        }

        public void StartNewGameFromFrontEnd()
        {
            if (inLevelBuilder) {
                gameState = GameState.e_GamePlay;
                return;
            }

            firstTimeInShowLevelSinceMenu = true;
            goBackToFrontEnd = false;
            if (playingCustom > 0) {
                this.SetNewGameState( GameState.e_ShowLevel);
                return;
            }

            int level = ((Globals.g_world.frontEnd).profile).selectedLevel;
            this.CheckPreShowLevelScreens(level);
            if (((Globals.g_world.frontEnd).profile).profileInfo.anotherPiggyScreenPending) {
                (hud.anotherPiggyScreen).SetType( AnotherPiggyType.kAP_AnotherPiggy);
                this.SetNewGameState( GameState.e_AnotherPiggy);
                afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
            }
            else if (((Globals.g_world.frontEnd).profile).profileInfo.feelGoodScreenPending) {
                this.SetupPreFeelGoodWords(true);
                afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodNextLevel;
            }
            else {
                gameState = GameState.e_NotInGameYet;
                this.SetNewGameState( GameState.e_ShowLevel);
            }

        }

        bool IsOldControlTouchFingerP1(MyTouch inTouch, CGPoint inPosition)
        {
            if ((inTouch.phase == TouchPhase.Ended) || (inTouch.phase == TouchPhase.Canceled)) {
                if (inTouch.fingerId == controlTouchFinger) {
                    controlTouchFinger = -1;
                    fingerControl.SetFingerDown(false);
                    return true;
                }

            }
            else {
                if (inTouch.fingerId == controlTouchFinger) {
                    fingerControl.SetFingerPosition(inPosition);
                    return true;
                }

            }

            return false;
        }

        bool IsOldControlTouch(MyTouch inTouch)
        {
            if ((inTouch.phase == TouchPhase.Ended) || (inTouch.phase == TouchPhase.Canceled)) {
                if (inTouch.fingerId == controlTouchLeft) {
                    controlTouchLeft = -1;
                    return true;
                }
                else if (inTouch.fingerId == controlTouchRight) {
                    controlTouchRight = -1;
                    return true;
                }

            }
            else {
                if (inTouch.fingerId == controlTouchLeft) {
                    return true;
                }
                else if (inTouch.fingerId == controlTouchRight) {
                    return true;
                }

            }

            return false;
        }

        bool IsNewControlTouchP1(MyTouch inTouch, CGPoint inPosition)
        {
            const float kDistFromCornerForControl = 52900.0f;
            if (inPosition.x < 160.0f) {
                float distSqr = Utilities.GetSqrDistanceP1(Utilities.CGPointMake(0.0f, 440.0f), inPosition);
                if (distSqr <= kDistFromCornerForControl) {
                    if (controlTouchLeft == -1) {
                        controlTouchLeft = inTouch.fingerId;
                        return true;
                    }
                    else {
                    }

                    return true;
                }

            }
            else {
                float distSqr = Utilities.GetSqrDistanceP1(Utilities.CGPointMake(320.0f, 440.0f), inPosition);
                if (distSqr <= kDistFromCornerForControl) {
                    if (controlTouchRight == -1) {
                        controlTouchRight = inTouch.fingerId;
                    }
                    else {
                    }

                    return true;
                }

            }

            return false;
        }

        bool IsNewControlTouchFingerP1(MyTouch inTouch, CGPoint inPosition)
        {
            if ((inPosition.y > 80.0f) || (inPosition.x < 240.0f)) {
                if (controlTouchFinger == -1) {
                    controlTouchFinger = inTouch.fingerId;
                    fingerControl.SetFingerPosition(inPosition);
                    fingerControl.SetFingerDown(true);
                    return true;
                }

            }

            return false;
        }

        public void ResetControlTouches()
        {
            controlTouchLeft = -1;
            controlTouchRight = -1;
            controlTouchFinger = -1;
        }

        public void HandleTapP1(MyTouch inTouch, CGPoint position)
        {
            if (((Ztransition.GetTransition()).inTransition) && ((Ztransition.GetTransition()).area ==  TransitionArea.kTransition_Game)) return;

            if (inLevelBuilder) {
                WhichTouch whichTouch;
                if (inTouch.phase == TouchPhase.Began) whichTouch = WhichTouch.kTouchBegan;
                else if ((inTouch.phase == TouchPhase.Ended) || (inTouch.phase == TouchPhase.Canceled)) whichTouch = WhichTouch.kTouchEnded;
                else whichTouch = WhichTouch.kTouchMoved;

                lBuilder.HandleTouchP1(position, whichTouch);
                return;
            }

            if (gameState == GameState.e_GamePlay) {
                if (!((Globals.g_world.frontEnd).profile).preferences.controlTilt) {
                    if (!((Globals.g_world.frontEnd).profile).preferences.controlFinger) {
                        if (this.IsOldControlTouch(inTouch)) {
                            return;
                        }

                        if ((inTouch.phase != TouchPhase.Ended) && (inTouch.phase != TouchPhase.Canceled)) {
                            if (this.IsNewControlTouchP1(inTouch, position)) {
                                return;
                            }

                        }

                    }
                    else {
                        if (this.IsOldControlTouchFingerP1(inTouch, position)) {
                            return;
                        }

                        if ((inTouch.phase != TouchPhase.Ended) && (inTouch.phase != TouchPhase.Canceled)) {
                            if (this.IsNewControlTouchFingerP1(inTouch, position)) {
                                return;
                            }

                        }

                    }

                }

            }

            if (inTouch.phase != TouchPhase.Began) return;

            if (gameState == GameState.e_GamePlay) {
                if ((position.y > 50.0f) || (position.x < 270.0f)) {
                    return;
                }

                flagStartPause = true;
            }

            if (stateTimer > 0.5f) 
			{
                if (gameState == GameState.e_ShowLevel) {
                }
                else if ((gameState == GameState.e_FeelGoodScreen) && (Globals.g_world.worldState == WorldState.e_InGame)) {
                    int nextLevel = playingLevel + 1;
                    if (nextLevel == 32) {
                        if (!((Globals.g_world.frontEnd).profile).IsLevelUnlocked(nextLevel)) {
                            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
                            (Globals.g_world.frontEnd).SetInitMenuAtRaceScreen(4);
                        }

                    }
                    else if (nextLevel == 48) {
                        if (!((Globals.g_world.frontEnd).profile).IsLevelUnlocked(nextLevel)) {
                            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
                            (Globals.g_world.frontEnd).SetInitMenuAtRaceScreen(6);
                        }

                    }
                    else if (nextLevel == 64) {
                        if (!((Globals.g_world.frontEnd).profile).IsLevelUnlocked(nextLevel)) {
                            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
                            (Globals.g_world.frontEnd).SetInitMenuAtRaceScreen(8);
                        }

                    }
                    else if (nextLevel == 72) {
                        if (!((Globals.g_world.frontEnd).profile).IsLevelUnlocked(nextLevel)) {
                            afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
                            (Globals.g_world.frontEnd).SetInitMenuAtRaceScreen(9);
                        }

                    }
                    else if (nextLevel == 80) {
                        afterFeelGoodAction = (int)Game.Enum1.kAfterFeelGoodToMenu;
                        (Globals.g_world.frontEnd).SetInitMenuWithWellDone(true);
                    }

                    if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodToMenu) {
                        goToNextLevel = false;
                        goBackToFrontEnd = true;
                    }
                    else if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodGetReady) {
                        this.ChangeToGameState( GameState.e_GetReady);
                    }
                    else {
                        if (afterFeelGoodAction == (int)Game.Enum1.kAfterFeelGoodRetry) this.ChangeToShowLevelOrFeelGoodScreen(false);
                        else {
                            this.ChangeToShowLevelOrFeelGoodScreen(true);
                        }

                    }

                }
                else if (gameState == GameState.e_AppleCartScreen) {
                }
                else if (gameState == GameState.e_SpeedBoostScreen) {
                    ((hud.speedBoostScreen).doneButton).HandleTap(position);
                }
                else if (gameState == GameState.e_AnotherPiggy) {
                    ((hud.anotherPiggyScreen).doneButton).HandleTap(position);
                }

            }

            if ((gameState == GameState.e_ShowLevel) || (gameState == GameState.e_AnotherPiggy) || (gameState == GameState.
              e_ShowResultsLoseTooSlow) || (gameState == GameState.e_ShowResultsLoseToPiggy) || (gameState == GameState.e_ShowResultsWin)) {
                hud.HandleTap(position);
            }

            if (gameState == GameState.e_Paused) 
			{
                (hud.restartButton).HandleTap(position);
                (hud.nextLevelButton).HandleTap(position);
                (hud.menuButton).HandleTap(position);
            }
        }
  		
		  }

}
