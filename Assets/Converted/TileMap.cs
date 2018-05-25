using UnityEngine;
using System;



namespace Default.Namespace
{
public enum TileMapConsts {
	kMaxTilesForLB = 5
};

	
	public class TileMap
    {
		Billboard[,] levelBuilderTiles = new Billboard[(int)TileMapConsts.kMaxTilesForLB,(int)TileMapConsts.kMaxTilesForLB];
		
		public int prevXStartTile;
		public int prevXEndTile;
		public int prevYEndTile;

        public CGPoint tileMapScrollOffset;
        public int tileYOffset;
        public int[] numAtlasesForScene = new int[Constants.NUM_SCENES];
        public int[,] atlasIdForScene = new int[Constants.NUM_SCENES, (int)Enum3.kMaxAtlasesPerScene];
        public int currentScene;
        public int backCornerTile;
        public int[] stripYOffset = new int[(int)Enum3.kNumStrips];
        public AtlasTileInfo[] atlasTileInfo = new AtlasTileInfo[(int)Enum.kNumTileAtlases];
        public int[] atlasId = new int[(int)Enum1.kNumTileTextures];
        public int[] subTextureId = new int[(int)Enum1.kNumTileTextures];
        public int[] spriteAtlasId = new int[(int)Enum1.kNumTileTextures];
        public int[] spriteSubTextureId = new int[(int)Enum1.kNumTileTextures];
        public bool[] spriteSubOneDeep = new bool[(int)Enum1.kNumTileTextures];
        public TileGrid tileGrid;
        public Tile[] tile = new Tile[(int)TileMap.Enum3.kNumTiles];
        public Texture2D_Ross[] tileTexture = new Texture2D_Ross[(int)Enum1.kNumTileTextures];
        public float scale;
        public float yLength;
        public Tile[] hackyExtraTiles = new Tile[12];
        public const int kTilesWide = 10;
        public const int kTilesHigh = 18;
        public enum Enum {
            kNumTileAtlases = 1
        };
        public enum Enum1 {
            kTile_Grass = 0,
            kTile_Grass2,
            kTile_Flowers1,
            kTile_Flowers2,
            kTile_Flowers3,
            kTile_Flowers4,
            kTile_Flowers5,
            kTile_Flowers6,
            kTile_Flowers7,
            kTile_Flowers8,
            kTile_Flowers9,
            kTile_TreeGreen1,
            kTile_TreeGreen2,
            kTile_Tree3,
            kTile_ArrowLeft,
            kTile_ArrowDown,
            kTile_Pond1,
            kTile_Pond2,
            kTile_Pond3,
            kTile_ArrowRight,
            kTile_Tree4,
            kTile_Tree5,
            kTile_Puddle1,
            kTile_Puddle2,
            kTile_Pond4,
            kTile_Pond5,
            kTile_Pond6,
            kTile_HedgeHalfLeft,
            kTile_Hedge,
            kTile_HedgeHalfRight,
            kTile_Puddle3,
            kTile_Puddle4,
            kTile_Pond7,
            kTile_Pond8,
            kTile_Pond9,
            kTile_Rock1,
            kTile_Rock2,
            kTile_StoneWallEndLeft,
            kTile_StoneWall,
            kTile_StoneWallEndRight,
            kTile_GatePosts,
            kTile_GatePostLeft,
            kTile_GatePostRight,
            kTile_Ramp1,
            kTile_WideRamp1,
            kTile_WideRamp2,
            kTile_WideRamp3,
            kTile_TreeGreen2OLD,
            kTile_BigRock1,
            kTile_BigRock2,
            kTile_BigRock3,
            kTile_Ramp2,
            kTile_WideRamp4,
            kTile_WideRamp5,
            kTile_WideRamp6,
            kTile_FlowerCliff,
            kTile_BigRock4,
            kTile_BigRock5,
            kTile_BigRock6,
            kTile_HedgeNearEnd,
            kTile_BigHole7,
            kTile_BigHole8,
            kTile_Water,
            kTile_WaterToNormal,
            kTile_StoneWallEndLeftOLD,
            kTile_EndGrass = 256,
            kTile_SideRock1,
            kTile_SideRock2,
            kTile_OtherBankWaterShadow,
            kTile_WaterShadow3OLD,
            kTile_Bridge1,
            kTile_BridgeStart,
            kTile_WaterShadow2,
            kTile_WaterShadow3,
            kTile_SideRock3,
            kTile_SideRock4,
            kTile_Ramp3NOTUSED,
            kTile_Bridge2,
            kTile_WaterRiverOLD,
            kTile_WideRamp3OLD,
            kTile_WaterShadow1,
            kTile_WaterRiver,
            kTile_WideRamp6OLD,
            kTile_BigHole4,
            kTile_BigHole5,
            kTile_ArrowRightOLD,
            kTile_LB_RemoveSpace,
            kTile_LB_InsertSpace,
            kTile_Cliff1,
            kTile_SideRock1O,
            kTile_SideRock2O,
            kTile_SideRock3O,
            kTile_SideRock4O,
            kTile_Cliff6,
            kTile_Cliff7,
            kTile_Cliff8,
            kTile_Cliff9,
            kTile_Cliff10,
            kTile_Cliff11,
            kTile_Cliff12,
            kTile_Cliff13,
            kTile_Cliff14,
            kTile_Cliff15,
            kTile_Cliff16,
            kTile_Cliff17,
            kTile_Cliff18,
            kTile_Cliff19,
            kSpriteTile_Rock1,
            kSpriteTile_BigRock1,
            kSpriteTile_BigRock2,
            kSpriteTile_HedgeHalfLeft,
            kSpriteTile_HedgeHalfRight,
            kTile_FarmAtlasFirstTile = 432,
            kTile_BigSideShed2,
            kTile_BigSideShed3,
            kTile_MudOLD,
            kTile_StoneWell1,
            kTile_StoneWell2,
            kTile_SideFenceDownEnd,
            kTile_SideFenceUpEnd,
            kTile_House,
            kTile_Barn6,
            kTile_Barn7,
            kTile_Barn8,
            kTile_Barn9,
            kTile_Barn10,
            kTile_Barn11,
            kTile_Barn12,
            kTile_BigSideShed_2,
            kTile_ChimneyRight1,
            kTile_Barn15,
            kTile_StoneWell1nnn,
            kTile_StoneWell3,
            kTile_StoneWell4,
            kTile_SideFence,
            kTile_Mud,
            kTile_BigSideShed6,
            kTile_BigSideShed7,
            kTile_BigSideShed8,
            kTile_BigSideShed9,
            kTile_BigSideShed10,
            kTile_BigSideShed11,
            kTile_BigSideShed12,
            kTile_BigSideShed13,
            kTile_BigSideShed_3,
            kTile_BigSideShed15,
            kTile_BigSideShed16,
            kTile_BigSideShed17,
            kTile_FarmRamp1,
            kTile_FarmRamp2,
            kTile_FarmRamp3,
            kTile_SideChimneysMidOLD,
            kTile_BigSideShed22,
            kTile_BigSideShed23,
            kTile_BigSideShed24,
            kTile_BigSideShed25,
            kTile_BigSideShed26,
            kTile_BigSideShed27,
            kTile_BigSideShed28,
            kTile_BigSideShed29,
            kTile_BigSideShed_4,
            kTile_SideChimneysTop,
            kTile_BigSideShed32,
            kTile_WideFarmRamp1,
            kTile_FarmRamp4,
            kTile_FarmRamp5,
            kTile_FarmRamp6,
            kTile_SideChimneysBottomOLD,
            kTile_WideFarmRamp6,
            kTile_WideMud1,
            kTile_WideMud2,
            kTile_SmallMud1,
            kTile_SmallMud2,
            kTile_SmallMud3,
            kTile_SmallMud4,
            kTile_Hmmmm,
            kTile_BigSideShed_5,
            kTile_SideChimneysMid,
            kTile_Hmmmm3,
            kTile_Hmmmm4,
            kTile_Hmmmm5,
            kTile_Hmmmm6,
            kTile_Hmmmm7,
            kTile_Hmmmm71,
            kTile_Hmmmm72,
            kTile_Hmmmm73,
            kTile_Hmmmm74,
            kTile_Hmmmm75,
            kTile_Hmmmm76,
            kTile_Hmmmm77,
            kTile_Hmmmm78,
            kTile_Hmmmm79,
            kTile_Hmmmm8,
            kTile_SideChimneysBottom,
            kTile_FarmWall1,
            kTile_FarmWall2,
            kTile_FarmWall3,
            kTile_FarmWall4,
            kTile_ShedJump,
            kTile_gdfghd,
            kTile_gdfghd1,
            kTile_gdfghd2,
            kTile_gdfghd3,
            kTile_BigSideShed_6,
            kTile_gdfghd4,
            kTile_gdfghd5,
            kTile_gdfghd6,
            kTile_gdfghd7,
            kTile_gdfghd8,
            kTile_gdfghd9,
            kTileEndOfFarmAtlas = 688,
            kTileStartOfDesertAtlas,
            kTile_Cactus2,
            kTile_DesertWall1,
            kTile_DesertWall2,
            kTile_DesertWall3,
            kTile_desramp1,
            kTile_desramp2,
            kTile_desramp3,
            kTile_Cactus3,
            kTile_Cactus4,
            kTile_arrowleft,
            kTile_Sand,
            kTile_Sande,
            kTile_Sandd,
            kTile_Sandf,
            kTile_Sandg,
            kTile_DesertRock1,
            kTile_DesertRock2,
            kTile_DesertRock3,
            kTile_DesertRock4,
            kTileEndOfDesertAtlas,
            kTileStartOfIceAtlas,
            kTile_snowdrift2,
            kTile_IceWall1,
            kTile_IceWall2,
            kTile_IceWall3,
            kTile_IceWall4,
            kTile_Ice,
            kTile_duh,
            kTile_ig1,
            kTile_ig2,
            kTile_ig3,
            kTile_ig4,
            kTile_ig5,
            kTile_IceRock1,
            kTile_IceRock2,
            kTile_IceRock3,
            kTile_snowdrift3,
            kTile_snowdrift4,
            kTile_duhc1,
            kTile_duhc2,
            kTile_duhc3,
            kTile_duhc4,
            kTile_duhc5,
            kTile_duhc6,
            kTile_duhc7,
            kTile_duhc8,
            kTile_duhc9,
            kTile_duhcd,
            kTile_duhcf,
            kTile_IceRock4,
            kTile_duhch,
            kTile_duhcj,
            kTile_SideHolenot,
            kTileEndOfIceAtlas,
            kTileStartOfMoonAtlas,
            kTile_Crater2,
            kTile_Crater3,
            kTile_Crater4,
            kTile_Crater5,
            kTile_non,
            kTile_non1,
            kTile_Moon,
            kTile_Crater1_2,
            kTile_Crater2_2,
            kTile_Crater3_2,
            kTile_Crater4_2,
            kTile_Crater5_2,
            kTile_non3,
            kTile_non31,
            kTile_non32,
            kTile_Crater1_3,
            kTile_Crater2_3,
            kTile_Crater3_3,
            kTile_Crater4_3,
            kTile_Crater5_3,
            kTile_non411,
            kTile_MoonRock1,
            kTile_MoonRock2,
            kTile_Crater1_4,
            kTile_Crater2_4,
            kTile_Crater3_4,
            kTile_Crater4_4,
            kTile_Crater5_4,
            kTile_babyCrater1,
            kTile_babyCrater2,
            kTile_babyCrater3,
            kTile_Crater1_5,
            kTile_Crater2_5,
            kTile_Crater3_5,
            kTile_Crater4_5,
            kTile_Crater5_5,
            kTile_babyCrater4,
            kTile_babyCrater5,
            kTile_babyCrater6,
            kTile_bus1,
            kTile_bus2,
            kTile_bus3,
            kTile_bus4,
            kTile_MoonWall1,
            kTile_MoonWall2,
            kTile_MoonWall3,
            kTile_MoonWall4,
            kTile_bus12,
            kTile_bus22,
            kTile_bus32,
            kTile_bus42,
            kTile_bus52,
            kTile_moonpuddle1,
            kTile_moonpuddle2,
            kTile_nonnnn,
            kTile_bus13,
            kTile_bus23,
            kTile_bus33,
            kTile_bus43,
            kTile_bus53,
            kTile_nonnnn2,
            kTile_nonnnn3,
            kTile_MoonWall1OLD,
            kTileEndOfMoonAtlas,
            kTile_StartGrassCliff,
            kTile_GrassCliff2,
            kTile_GrassCliff3,
            kTile_GrassCliff4,
            kTile_GrassCliff5,
            kTile_GrassCliff6,
            kTile_GrassCliff7,
            kTile_GrassCliff8,
            kTile_GrassCliff9,
            kTile_GrassCliff10,
            kTile_GrassCliff11,
            kTile_GrassCliff12,
            kTile_GrassCliff13,
            kTile_GrassCliff14,
            kTile_GrassCliff15,
            kTile_GrassCliff16,
            kTile_GrassCliff17,
            kTile_GrassCliff18,
            kTile_GrassCliff19,
            kTile_GrassCliff20,
            kTile_GrassCliff21,
            kTile_GrassCliff22,
            kTile_GrassCliff23,
            kTile_GrassCliff24,
            kTile_GrassCliff25,
            kTile_GrassCliff26,
            kTile_GrassCliff27,
            kTile_EndGrassCliff,
            kTile_FarmAtlasHayFirstTile,
            kTile_FarmAtlasHay2,
            kTile_FarmAtlasHay3,
            kTile_FarmAtlasHay4,
            kTile_FarmAtlasHay5,
            kTile_FarmAtlasHay6,
            kTile_FarmAtlasHay7,
            kTile_FarmAtlasHay8,
            kTile_FarmAtlasHay9,
            kTile_FarmAtlasHay10,
            kTile_FarmAtlasHay11,
            kTile_FarmAtlasHay12,
            kTile_FarmAtlasHay13,
            kTile_FarmAtlasHay14,
            kTile_FarmAtlasHay15,
            kTile_FarmAtlasHay16,
            kTile_FarmAtlasHay21,
            kTile_FarmAtlasHay22,
            kTile_FarmAtlasHay23,
            kTile_FarmAtlasHay24,
            kTile_FarmAtlasHay25,
            kTile_FarmAtlasHay26,
            kTile_FarmAtlasHay27,
            kTile_FarmAtlasHay28,
            kTile_FarmAtlasHay29,
            kTile_FarmAtlasHay210,
            kTile_FarmAtlasHay211,
            kTile_FarmAtlasHay212,
            kTile_FarmAtlasHay213,
            kTile_FarmAtlasHay214,
            kTile_FarmAtlasHay215,
            kTile_FarmAtlasHay216,
            kSpriteTile_StartFarmAtlas,
            kSpriteTile_hmmg,
            kSpriteTile_ggggg,
            kSpriteTile_StoneWell1,
            kSpriteTile_StoneWell2,
            kSpriteTile_House0,
            kSpriteTile_House1,
            kSpriteTile_House2,
            kSpriteTile_House3,
            kSpriteTile_House4,
            kSpriteTile_Chimney,
            kSpriteTile_Cart,
            kSpriteTile_House5,
            kSpriteTile_House6,
            kSpriteTile_House6_SideBit,
            kSpriteTile_House6_SideBit2,
            kSpriteTile_hay1,
            kSpriteTile_hay2,
            kSpriteTile_hay3,
            kSpriteTile_n6,
            kSpriteTile_Barn1,
            kSpriteTile_Barn2,
            kSpriteTile_Barn3,
            kSpriteTile_Barn4,
            kSpriteTile_hay4,
            kSpriteTile_hay5,
            kSpriteTile_hay6,
            kSpriteTile_n61,
            kSpriteTile_House9,
            kSpriteTile_House10,
            kSpriteTile_Ice1,
            kSpriteTile_Ice2,
            kSpriteTile_Desert1,
            kSpriteTile_Desert2,
            kNumTileTextures
        };
        public enum Enum2 {
            kTileJungle_Grass = 0,
            kTileJungle_Grass2,
            kTileJungle_Flowers1,
            kTileJungle_Flowers2,
            kTileJungle_Flowers3,
            kTileJungle_Flowers4,
            kTileJungle_Flowers5,
            kTileJungle_Flowers6,
            kTileJungle_Flowers7,
            kTileJungle_Nada,
            kTileJungle_Nada2,
            kTileJungle_Flowers8,
            kTileJungle_Flowers9,
            kTileJungle_TreeGreen1,
            kTileJungle_TreeGreen2,
            kTileJungle_Tree3,
            kTileJungle_ArrowLeft,
            kTileJungle_ArrowDown,
            kTileJungle_Pond1,
            kTileJungle_Pond2,
            kTileJungle_Pond3,
            kTileJungle_ArrowRight,
            kTileJungle_Tree4,
            kTileJungle_Tree5,
            kTileJungle_Puddle1,
            kTileJungle_Puddle2,
            kTileJungle_Pond4,
            kTileJungle_Pond5,
            kTileJungle_Pond6,
            kTileJungle_HedgeHalfLeft,
            kTileJungle_Hedge,
            kTileJungle_HedgeHalfRight,
            kTileJungle_Puddle3,
            kTileJungle_Puddle4,
            kTileJungle_Pond7,
            kTileJungle_Pond8,
            kTileJungle_Pond9,
            kTileJungle_Rock1,
            kTileJungle_Rock2,
            kTileJungle_StoneWallEndLeft,
            kTileJungle_StoneWall,
            kTileJungle_StoneWallEndRight,
            kTileJungle_GatePosts,
            kTileJungle_GatePostLeft,
            kTileJungle_GatePostRight,
            kTileJungle_Ramp1,
            kTileJungle_WideRamp1,
            kTileJungle_WideRamp2,
            kTileJungle_WideRamp3,
            kTileJungle_TreeGreen2OLD,
            kTileJungle_BigRock1,
            kTileJungle_BigRock2,
            kTileJungle_BigRock3,
            kTileJungle_Ramp2,
            kTileJungle_WideRamp4,
            kTileJungle_WideRamp5,
            kTileJungle_WideRamp6,
            kTileJungle_FlowerCliff,
            kTileJungle_BigRock4,
            kTileJungle_BigRock5,
            kTileJungle_BigRock6,
            kTileJungle_HedgeNearEnd,
            kTileJungle_BigHole7,
            kTileJungle_BigHole8,
            kTileJungle_Water,
            kTileJungle_WaterToNormal,
            kNumTiles_JungleAtlas
        };
        public struct SetSpriteTileInfo{
            public int tileAtlasId;
            public int spriteTileAtlasId;
            public int tileAtlasX;
            public int tileAtlasY;
            public int spriteTileAtlasX;
            public int spriteTileAtlasY;
            public bool spriteOneDeep;
        };
        public enum Enum3 {
            kNumTiles = 216,
            kNumStrips = 18,
            kMaxAtlasesPerScene = 3
        };
        //extern const int (int)TileMap.kTilesWide;
        //extern const int (int)TileMap.kTilesWide;
        public int TileYOffset
        {
            get;
            set;
        }

        public TileGrid TileGrid
        {
            get;
            set;
        }

        public int CurrentScene
        {
            get;
            set;
        }

        public CGPoint TileMapScrollOffset
        {
            get;
            set;
        }

public void SetTileYOffset(int inThing) {tileYOffset = inThing;}///@property(readwrite,assign) int tileYOffset;
public void SetTileGrid(TileGrid inThing) {tileGrid = inThing;}////@property(readwrite,assign) TileGrid* tileGrid;
public void SetCurrentScene(int inThing) {currentScene = inThing;}///@property(readwrite,assign) int currentScene;
public void SetTileMapScrollOffset(CGPoint inThing) {tileMapScrollOffset = inThing;}///@property(readwrite,assign) CGPoint tileMapScrollOffset;

        public TileMap ()
		{
			//if (!base.init()) return null;

			for (int i = 0; i < (int)Enum.kNumTileAtlases; i++) {
				atlasTileInfo [i] = new AtlasTileInfo ();
			}

			for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) {
				tile [i] = new Tile (i.ToString());
			}

			for (int i = 0; i < 6; i++) {
				hackyExtraTiles [i] = new Tile ("extra" + i.ToString());
			}

			Globals.Assert (Constants.TRACK_CENTRE_LINE == (Constants.PLAYABLE_MAP_LEFT_EDGE + (Constants.MAP_WIDTH / 2.0f)));
			Globals.Assert ((int)Enum3.kNumStrips == (int)TileMap.kTilesHigh);
            tileGrid = new TileGrid();
            scale = 1.0f;
            yLength = (Constants.TILE_SIZE * ((float) (int)TileMap.kTilesHigh));
            currentScene = (short)SceneType.kSceneGrass;
			
			for (int i = 0; i < (int)TileMapConsts.kMaxTilesForLB; i++) {
					for (int j = 0; j < (int)TileMapConsts.kMaxTilesForLB; j++) {
					levelBuilderTiles[i,j] = new Billboard("lbTile");
				}
			}

            //return this;
        }
		
		public void StartLevelBuilder(ZAtlas inAtlas)
		{
			for (int i = 0; i < (int)TileMapConsts.kMaxTilesForLB; i++) {
					for (int j = 0; j < (int)TileMapConsts.kMaxTilesForLB; j++) {
					levelBuilderTiles[i,j].SetAtlas(inAtlas);
					levelBuilderTiles[i,j].SetDetailsFromAtlas(inAtlas,0);
					levelBuilderTiles[i,j].myObject.layer = LayerMask.NameToLayer("tiles");

				}
			}
		}		
		
		public void StopRender()
		{
			for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) {
				tile [i].StopRender();
			}
		}
		
		public void SetupAtlas(int inAtlasId)
        {
			for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) 
						{
//								Debug.Log("<color= yellow>tile</color> " + i.ToString());
				tile [i].SetupAtlas(inAtlasId);
			}
		}
		
        public void FirstInit()
        {
            this.SetupTileKnowledge();
            this.SetupTilePositions();
        }

        public void SetStartFrontEnd()
		{
			for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) {
				tile [i].SetToLayer("tiles");
			}
		}
        public void SetStartGame()
		{
			for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) {
				tile [i].SetToLayer("Default");
				tile[i].SetScale(1.0f);
								tile[i].StopRender();
			}
		}
		
       public void SetupAtlasKnowledgeCliff(int tileId)
        {
            atlasId[tileId] = (int)AtlasType.kAtlas_GrassCliff;
            subTextureId[tileId] = (int)(tileId - (int)TileMap.Enum1.kTile_StartGrassCliff);
        }

       public void SetupAtlasKnowledgeMoon(int tileId)
        {
            atlasId[tileId] = (int)AtlasType.kAtlas_MoonTiles;
            subTextureId[tileId] = (int)(tileId - (int)TileMap.Enum1.kTileStartOfMoonAtlas);
        }

       public void SetupAtlasKnowledgeIceSprites(int tileId)
        {
            atlasId[tileId] = (int)AtlasType.kAtlas_IceTiles2;
            subTextureId[tileId] = (int)(tileId - (int)Enum1.kSpriteTile_Ice1);
        }

       public void SetupAtlasKnowledgeIce(int tileId)
        {
            atlasId[tileId] = (int)AtlasType.kAtlas_IceTiles;
            subTextureId[tileId] = (int)(tileId - (int)TileMap.Enum1.kTileStartOfIceAtlas);
        }

       public void SetupAtlasKnowledgeDesert(int tileId)
        {
            atlasId[tileId] = (int)AtlasType.kAtlas_DesertTiles;
            subTextureId[tileId] = (int)(tileId - (int)TileMap.Enum1.kTileStartOfDesertAtlas);
        }

       public void SetupAtlasKnowledgeFarmyardHay(int tileId)
        {
            atlasId[tileId] = (int)AtlasType.kAtlas_MudTiles3;
            subTextureId[tileId] = (int)(tileId - (int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile);
        }

       public void SetupAtlasKnowledgeFarmyard(int tileId)
        {
            atlasId[tileId] = (int)AtlasType.kAtlas_MudTiles;
            subTextureId[tileId] = (int)(tileId - (int)TileMap.Enum1.kTile_FarmAtlasFirstTile);
        }

       public void  SetSpriteTile(SetSpriteTileInfo info)
        {
            int tileId = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2(info.tileAtlasId, info.tileAtlasX, info.tileAtlasY);
            int numInRow = Globals.g_world.GetNumTilesInRow(info.spriteTileAtlasId);
            int x = info.spriteTileAtlasX;
            int y = info.spriteTileAtlasY;
            int spriteTileId = (y * numInRow) + x;
            spriteAtlasId[tileId] = info.spriteTileAtlasId;
            spriteSubTextureId[tileId] = spriteTileId;
            spriteSubOneDeep[tileId] = info.spriteOneDeep;
        }

       public void SetupSpriteTilesMud()
        {
            SetSpriteTileInfo info;
            CGPoint atlasPos = Utilities.CGPointMake(10, 3);
            CGPoint spriteAtlasPos = Utilities.CGPointMake(0, 0);
            info.tileAtlasId = (int)AtlasType.kAtlas_MudTiles;
            info.spriteTileAtlasId = (int)AtlasType.kAtlas_MudSpriteTiles;
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = false;
            this.SetSpriteTileRowP1(2, info);
            info.tileAtlasY += 1;
            info.spriteTileAtlasY += 1;
            this.SetSpriteTileRowP1(2, info);
            info.tileAtlasX = 9;
            info.tileAtlasY = 5;
            info.spriteTileAtlasX = 0;
            info.spriteTileAtlasY = 2;
            this.SetSpriteTileRowP1(2, info);
            info.tileAtlasX = 11;
            info.tileAtlasY = 5;
            info.spriteTileAtlasX = 5;
            info.spriteTileAtlasY = 2;
            this.SetSpriteTileRowP1(2, info);
            atlasPos = Utilities.CGPointMake(4, 4);
            spriteAtlasPos = Utilities.CGPointMake(2, 0);
            info.tileAtlasId = (int)AtlasType.kAtlas_MudTiles;
            info.spriteTileAtlasId = (int)AtlasType.kAtlas_MudSpriteTiles;
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = false;
            this.SetSpriteTileRowP1(4, info);
            info.tileAtlasY++;
            info.spriteTileAtlasY++;
            this.SetSpriteTileColumnP1(3, info);
            info.tileAtlasX += 3;
            info.spriteTileAtlasX++;
            this.SetSpriteTileColumnP1(3, info);
            atlasPos = Utilities.CGPointMake(0, 0);
            spriteAtlasPos = Utilities.CGPointMake(7, 0);
            info.tileAtlasId = (int)AtlasType.kAtlas_MudTiles;
            info.spriteTileAtlasId = (int)AtlasType.kAtlas_MudSpriteTiles;
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = false;
            this.SetSpriteTileColumnP1(4, info);
            info.tileAtlasX = 1;
            info.tileAtlasY = 0;
            info.spriteTileAtlasX = 4;
            info.spriteTileAtlasY = 1;
            this.SetSpriteTileRowP1(2, info);
            info.tileAtlasX = 2;
            info.tileAtlasY = 1;
            info.spriteTileAtlasX = 6;
            info.spriteTileAtlasY = 0;
            this.SetSpriteTileColumnP1(4, info);
            info.tileAtlasX = 2;
            info.tileAtlasY = 5;
            info.spriteTileAtlasX = 5;
            info.spriteTileAtlasY = 3;
            this.SetSpriteTileColumnP1(1, info);
            info.tileAtlasX = 0;
            info.tileAtlasY = 4;
            info.spriteTileAtlasX = 4;
            info.spriteTileAtlasY = 2;
            this.SetSpriteTileColumnP1(2, info);
            atlasPos = Utilities.CGPointMake(8, 1);
            spriteAtlasPos = Utilities.CGPointMake(0, 3);
            info.tileAtlasId = (int)AtlasType.kAtlas_MudTiles;
            info.spriteTileAtlasId = (int)AtlasType.kAtlas_MudSpriteTiles;
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = false;
            this.SetSpriteTileRowP1(2, info);
        }

       public void SetupSpriteTilesGrass()
        {
            SetSpriteTileInfo info;
            CGPoint atlasPos = Utilities.CGPointMake(5, 1);
            CGPoint spriteAtlasPos = Utilities.CGPointMake(0, 0);
            info.tileAtlasId = (int)AtlasType.kAtlas_GrassTiles;
            info.spriteTileAtlasId = (int)AtlasType.kAtlas_GrassSpriteTiles;
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = false;
            this.SetSpriteTile(info);
            info.tileAtlasX++;
            info.spriteTileAtlasX++;
            this.SetSpriteTile(info);
            info.tileAtlasX++;
            info.spriteTileAtlasX++;
            this.SetSpriteTile(info);
            info.tileAtlasX++;
            info.spriteTileAtlasX++;
            this.SetSpriteTile(info);
            info.tileAtlasX = (int)atlasPos.x + 4;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x + 1;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y + 1;
            this.SetSpriteTile(info);
            info.tileAtlasY++;
            info.spriteTileAtlasY++;
            this.SetSpriteTile(info);
            info.tileAtlasY++;
            info.spriteTileAtlasY++;
            this.SetSpriteTile(info);
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y + 1;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y + 1;
            this.SetSpriteTile(info);
            info.tileAtlasY++;
            info.spriteTileAtlasY++;
            this.SetSpriteTile(info);
            info.tileAtlasY++;
            info.spriteTileAtlasY++;
            this.SetSpriteTile(info);
            atlasPos = Utilities.CGPointMake(8, 6);
            spriteAtlasPos = Utilities.CGPointMake(2, 1);
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = true;
            this.SetSpriteTileRowP1(3, info);
            atlasPos = Utilities.CGPointMake(8, 7);
            spriteAtlasPos = Utilities.CGPointMake(2, 2);
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = true;
            this.SetSpriteTileRowP1(3, info);
            atlasPos = Utilities.CGPointMake(0, 6);
            spriteAtlasPos = Utilities.CGPointMake(2, 3);
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = true;
            this.SetSpriteTileRowP1(2, info);
            atlasPos = Utilities.CGPointMake(3, 5);
            spriteAtlasPos = Utilities.CGPointMake(4, 3);
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = true;
            this.SetSpriteTile(info);
            atlasPos = Utilities.CGPointMake(4, 9);
            spriteAtlasPos = Utilities.CGPointMake(4, 0);
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = false;
            this.SetSpriteTileRowP1(3, info);
            atlasPos = Utilities.CGPointMake(7, 9);
            spriteAtlasPos = Utilities.CGPointMake(5, 2);
            info.tileAtlasX = (int)atlasPos.x;
            info.tileAtlasY = (int)atlasPos.y;
            info.spriteTileAtlasX = (int)spriteAtlasPos.x;
            info.spriteTileAtlasY = (int)spriteAtlasPos.y;
            info.spriteOneDeep = true;
            this.SetSpriteTileRowP1(3, info);
        }

        public void SetSpriteTileRowP1(int howMany, SetSpriteTileInfo info)
        {
            for (int i = 0; i < howMany; i++) {
                this.SetSpriteTile(info);
                info.tileAtlasX++;
                info.spriteTileAtlasX++;
            }

        }

        public void SetSpriteTileColumnP1(int howMany, SetSpriteTileInfo info)
        {
            for (int i = 0; i < howMany; i++) {
                this.SetSpriteTile(info);
                info.tileAtlasY++;
                info.spriteTileAtlasY++;
            }

        }

       public void SetupSpriteTilesFarmyard()
        {
            int kAtlasTileWidth = 16;
            const int kObjectMaxWidth = 16;
            const int kObjectMaxHeight = 16;
            int[,,] objectSubTexture = new int[(int)ObjectType.Types, kObjectMaxWidth, kObjectMaxHeight];
            int[,,] objectAtlasId = new int[(int)ObjectType.Types, kObjectMaxWidth, kObjectMaxHeight];
            int[] objectStartX = new int[(int)ObjectType.Types];
            int[] objectStartY = new int[(int)ObjectType.Types];
            for (int i = 0; i < (int) ObjectType.Types; i++) {
                for (int x = 0; x < kObjectMaxWidth; x++) {
                    for (int y = 0; y < kObjectMaxHeight; y++) {
                        objectSubTexture[i, x, y] = -1;
                        objectAtlasId[i, x, y] = -1;
                    }

                }

                objectStartX[i] = -1;
                objectStartY[i] = -1;
            }

            objectStartX[(int) ObjectType.kOT_BigSidewaysShed] = (int)LevelBuilder_Ross.Enum1.kAtlasShedX;
            objectStartY[(int) ObjectType.kOT_BigSidewaysShed] = (int)LevelBuilder_Ross.Enum1.kAtlasShedY;
            objectSubTexture[(int) ObjectType.kOT_BigSidewaysShed, 0, 0] = (int)TileMap.Enum1.kTile_FarmAtlasFirstTile - (int)TileMap.Enum1.kTile_FarmAtlasFirstTile;
            objectAtlasId[(int) ObjectType.kOT_BigSidewaysShed, 0, 0] = (int)AtlasType.kAtlas_MudTiles;
            for (int s = 0; s < 5; s++) {
                objectSubTexture[(int) ObjectType.kOT_BigSidewaysShed, 0, s + 1] = ((int)TileMap.Enum1.kTile_FarmAtlasFirstTile + 16 + (16 * s)) - (int)TileMap.Enum1.kTile_FarmAtlasFirstTile;
                objectAtlasId[(int) ObjectType.kOT_BigSidewaysShed, 0, s + 1] = (int)AtlasType.kAtlas_MudTiles;
                spriteSubOneDeep[(int)TileMap.Enum1.kTile_FarmAtlasFirstTile + 16 + (s * 16)] = false;
                spriteSubOneDeep[(int)TileMap.Enum1.kTile_BigSideShed3 + 16 + (s * 16)] = false;
            }

            spriteSubOneDeep[(int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_BigSideShed2] = false;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_BigSideShed3] = false;
            spriteSubOneDeep[68 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[69 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[70 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[71 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[84 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[87 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[104 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[8 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[9 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[10 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[11 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[12 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[24 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[40 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[54 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[28 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[44 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[60 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_StoneWell1] = (int)Enum1.kSpriteTile_StoneWell1 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_StoneWell1] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_StoneWell2] = (int)Enum1.kSpriteTile_StoneWell2 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_StoneWell2] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_StoneWell1] = false;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_StoneWell2] = false;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile] = (int)Enum1.kSpriteTile_hay1 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_FarmAtlasHay2] = (int)Enum1.kSpriteTile_hay2 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_FarmAtlasHay2] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_FarmAtlasHay3] = (int)Enum1.kSpriteTile_hay3 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_FarmAtlasHay3] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_FarmAtlasHay9] = (int)Enum1.kSpriteTile_hay4 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_FarmAtlasHay9] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_FarmAtlasHay10] = (int)Enum1.kSpriteTile_hay5 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_FarmAtlasHay10] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_FarmAtlasHay11] = (int)Enum1.kSpriteTile_hay6 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_FarmAtlasHay11] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_SideChimneysTop] = (int)TileMap.Enum1.kTile_SideChimneysTop - (int)TileMap.Enum1.kTile_FarmAtlasFirstTile;
            spriteAtlasId[(int)TileMap.Enum1.kTile_SideChimneysTop] = (int)AtlasType.kAtlas_MudTiles;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_FarmWall2] = (int)TileMap.Enum1.kTile_FarmWall2 - (int)TileMap.Enum1.kTile_FarmAtlasFirstTile;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_FarmWall3] = (int)TileMap.Enum1.kTile_FarmWall3 - (int)TileMap.Enum1.kTile_FarmAtlasFirstTile;
            spriteAtlasId[(int)TileMap.Enum1.kTile_FarmWall2] = (int)AtlasType.kAtlas_MudTiles;
            spriteAtlasId[(int)TileMap.Enum1.kTile_FarmWall3] = (int)AtlasType.kAtlas_MudTiles;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile] = false;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_FarmAtlasHay2] = false;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_FarmAtlasHay3] = false;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_FarmAtlasHay9] = false;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_FarmAtlasHay10] = false;
            spriteSubOneDeep[(int)TileMap.Enum1.kTile_FarmAtlasHay11] = false;
            objectStartX[(int) ObjectType.kOT_Cart] = (int)LevelBuilder_Ross.Enum1.kAtlasCartX;
            objectStartY[(int) ObjectType.kOT_Cart] = (int)LevelBuilder_Ross.Enum1.kAtlasCartY;
            objectSubTexture[(int) ObjectType.kOT_Cart, 0, 0] = (int)Enum1.kSpriteTile_Cart - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectAtlasId[(int) ObjectType.kOT_Cart, 0, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectStartX[(int) ObjectType.kOT_Barn] = (int)LevelBuilder_Ross.Enum1.kAtlasBarnX;
            objectStartY[(int) ObjectType.kOT_Barn] = (int)LevelBuilder_Ross.Enum1.kAtlasBarnY;
            objectSubTexture[(int) ObjectType.kOT_Barn, 0, 0] = (int)Enum1.kSpriteTile_Barn1 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectSubTexture[(int) ObjectType.kOT_Barn, 1, 0] = (int)Enum1.kSpriteTile_Barn2 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectSubTexture[(int) ObjectType.kOT_Barn, 2, 0] = (int)Enum1.kSpriteTile_Barn3 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectSubTexture[(int) ObjectType.kOT_Barn, 3, 0] = (int)Enum1.kSpriteTile_Barn4 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectAtlasId[(int) ObjectType.kOT_Barn, 0, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectAtlasId[(int) ObjectType.kOT_Barn, 1, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectAtlasId[(int) ObjectType.kOT_Barn, 2, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectAtlasId[(int) ObjectType.kOT_Barn, 3, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            spriteSubOneDeep[(int)Enum1.kSpriteTile_Barn1] = false;
            spriteSubOneDeep[(int)Enum1.kSpriteTile_Barn2] = false;
            spriteSubOneDeep[(int)Enum1.kSpriteTile_Barn3] = false;
            spriteSubOneDeep[(int)Enum1.kSpriteTile_Barn4] = false;
            objectSubTexture[(int) ObjectType.kOT_Barn, 0, 1] = 84;
            objectSubTexture[(int) ObjectType.kOT_Barn, 3, 1] = 87;
            objectAtlasId[(int) ObjectType.kOT_Barn, 0, 1] = (int)AtlasType.kAtlas_MudTiles;
            objectAtlasId[(int) ObjectType.kOT_Barn, 3, 1] = (int)AtlasType.kAtlas_MudTiles;
            objectSubTexture[(int) ObjectType.kOT_Barn, 0, 2] = 100;
            objectSubTexture[(int) ObjectType.kOT_Barn, 3, 2] = 103;
            objectAtlasId[(int) ObjectType.kOT_Barn, 0, 2] = (int)AtlasType.kAtlas_MudTiles;
            objectAtlasId[(int) ObjectType.kOT_Barn, 3, 2] = (int)AtlasType.kAtlas_MudTiles;
            spriteSubOneDeep[84 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[100 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[103 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            spriteSubOneDeep[87 + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile] = false;
            objectStartX[(int) ObjectType.kOT_House] = (int)LevelBuilder_Ross.Enum1.kAtlasHouseX;
            objectStartY[(int) ObjectType.kOT_House] = (int)LevelBuilder_Ross.Enum1.kAtlasHouseY;
            objectSubTexture[(int) ObjectType.kOT_House, 1, 0] = (int)Enum1.kSpriteTile_House1 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectSubTexture[(int) ObjectType.kOT_House, 2, 0] = (int)Enum1.kSpriteTile_House2 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectSubTexture[(int) ObjectType.kOT_House, 3, 0] = (int)Enum1.kSpriteTile_House3 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectSubTexture[(int) ObjectType.kOT_House, 4, 0] = (int)Enum1.kSpriteTile_House4 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectSubTexture[(int) ObjectType.kOT_House, 0, 0] = (int)Enum1.kSpriteTile_House0 - (int)Enum1.kSpriteTile_StartFarmAtlas;
            objectAtlasId[(int) ObjectType.kOT_House, 1, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 2, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 3, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 4, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 0, 0] = (int)AtlasType.kAtlas_MudSpriteTiles;
            objectSubTexture[(int) ObjectType.kOT_House, 0, 1] = 24;
            objectSubTexture[(int) ObjectType.kOT_House, 0, 2] = 40;
            objectSubTexture[(int) ObjectType.kOT_House, 0, 3] = 56;
            objectSubTexture[(int) ObjectType.kOT_House, 4, 1] = 28;
            objectSubTexture[(int) ObjectType.kOT_House, 4, 2] = 44;
            objectSubTexture[(int) ObjectType.kOT_House, 4, 3] = 60;
            objectAtlasId[(int) ObjectType.kOT_House, 0, 1] = (int)AtlasType.kAtlas_MudTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 0, 3] = (int)AtlasType.kAtlas_MudTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 4, 1] = (int)AtlasType.kAtlas_MudTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 4, 3] = (int)AtlasType.kAtlas_MudTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 0, 2] = (int)AtlasType.kAtlas_MudTiles;
            objectAtlasId[(int) ObjectType.kOT_House, 4, 2] = (int)AtlasType.kAtlas_MudTiles;
            objectStartX[(int) ObjectType.kOT_ChimneyRight] = (int)LevelBuilder_Ross.Enum1.kAtlasChimneyRightX;
            objectStartY[(int) ObjectType.kOT_ChimneyRight] = (int)LevelBuilder_Ross.Enum1.kAtlasChimneyRightY;
            spriteSubTextureId[(int)TileMap.Enum1.kTile_ChimneyRight1] = (int)Enum1.kSpriteTile_Chimney - (int)Enum1.kSpriteTile_StartFarmAtlas;
            spriteAtlasId[(int)TileMap.Enum1.kTile_ChimneyRight1] = (int)AtlasType.kAtlas_MudSpriteTiles;
            for (int i = 0; i < (int) ObjectType.Types; i++) {
                if (objectStartX[i] == -1) continue;

                for (int y = 0; y < (int) ((Globals.g_world.game).lBuilder).GetObjectInfo((ObjectType)i).tileHeight; y++) {
                    for (int x = 0; x < (int) ((Globals.g_world.game).lBuilder).GetObjectInfo((ObjectType)i).tileWidth; x++) {
                        if (objectAtlasId[i, x, y] != -1) {
                            int index = objectStartX[i] + x + (y * kAtlasTileWidth) + (objectStartY[i] * kAtlasTileWidth);
                            int tileId = (int)TileMap.Enum1.kTile_FarmAtlasFirstTile + index;
                            spriteSubTextureId[tileId] = objectSubTexture[i, x, y];
                            spriteAtlasId[tileId] = objectAtlasId[i, x, y];
                        }

                    }

                }

            }

        }

        public void SetupCommonAtlasKnowledge()
        {
            subTextureId[(int)TileMap.Enum1.kTile_LB_RemoveSpace] = 0;
            subTextureId[(int)TileMap.Enum1.kTile_LB_InsertSpace] = 2;
            atlasId[(int)TileMap.Enum1.kTile_LB_RemoveSpace] = (int)AtlasType.kAtlas_CommonLevelBuilder_Ross;
            atlasId[(int)TileMap.Enum1.kTile_LB_InsertSpace] = (int)AtlasType.kAtlas_CommonLevelBuilder_Ross;
        }

        public int GetNumTilesInAtlas(int whichAtlas)
        {
            switch ((AtlasType)whichAtlas) {
            case AtlasType.kAtlas_GrassTiles :
                return 256;
                break;
            case AtlasType.kAtlas_MudTiles :
                return 128;
                break;
            case AtlasType.kAtlas_GrassSpriteTiles :
                return 32;
                break;
            case AtlasType.kAtlas_MudSpriteTiles :
                return 32;
                break;
            default :
                return 64;
                break;
            }

        }

        public void SetupAtlasKnowledgeCountry()
        {
            int numTiles = this.GetNumTilesInAtlas((int) AtlasType.kAtlas_GrassTiles);
            for (int i = 0; i < numTiles; i++) {
                spriteSubTextureId[i] = -1;
                spriteAtlasId[i] = -1;
                atlasId[i] = (int)AtlasType.kAtlas_GrassTiles;
                subTextureId[i] = i;
            }

        }

        public void SetupTileKnowledge ()
		{
			Globals.Assert (Constants.NUM_SCENES == (int)SceneType.kNumScenes);
			for (int i = 0; i < (int) SceneType.kNumScenes; i++)
				numAtlasesForScene [i] = -1;

			numAtlasesForScene [(int)SceneType.kSceneGrass] = 1;
			atlasIdForScene [(int)SceneType.kSceneGrass, 0] = (int)AtlasType.kAtlas_GrassTiles;
			numAtlasesForScene [(int)SceneType.kSceneMud] = 1;
			atlasIdForScene [(int)SceneType.kSceneMud, 0] = (int)AtlasType.kAtlas_MudTiles;
			numAtlasesForScene [(int)SceneType.kSceneDesert] = 1;
			atlasIdForScene [(int)SceneType.kSceneDesert, 0] = (int)AtlasType.kAtlas_DesertTiles;
			numAtlasesForScene [(int)SceneType.kSceneIce] = 2;
			atlasIdForScene [(int)SceneType.kSceneIce, 0] = (int)AtlasType.kAtlas_IceTiles;
			atlasIdForScene [(int)SceneType.kSceneIce, 1] = (int)AtlasType.kAtlas_IceTiles2;
			numAtlasesForScene [(int)SceneType.kSceneMoon] = 1;
			atlasIdForScene [(int)SceneType.kSceneMoon, 0] = (int)AtlasType.kAtlas_MoonTiles;
			numAtlasesForScene [(int)SceneType.kSceneSavanna] = 1;
			numAtlasesForScene [(int)SceneType.kSceneJungle] = 1;
			for (int i = 0; i < (int) SceneType.kNumScenes; i++)
				Globals.Assert (numAtlasesForScene [i] != -1);

			for (int i = 0; i < (int)Enum1.kNumTileTextures; i++) {
                spriteSubOneDeep[i] = true;
            }

            this.SetupAllAtlasKnowledge();
            this.SetupSpriteTilesGrass();
            this.SetupSpriteTilesMud();
        }

        public void SetupAllAtlasKnowledge()
        {
            this.SetupAtlasKnowledgeCountry();
            this.SetupCommonAtlasKnowledge();
            int farmyardAtlasNumTiles = 16 * 16;
            Globals.Assert(((int)TileMap.Enum1.kTile_FarmAtlasFirstTile + farmyardAtlasNumTiles) == (int)TileMap.Enum1.kTileEndOfFarmAtlas);
            for (int i = 0; i < farmyardAtlasNumTiles; i++) this.SetupAtlasKnowledgeFarmyard(i + (int)TileMap.Enum1.kTile_FarmAtlasFirstTile);

            for (int i = 0; i < 32; i++) this.SetupAtlasKnowledgeFarmyardHay(i + (int)TileMap.Enum1.kTile_FarmAtlasHayFirstTile);

            for (int i = (int)TileMap.Enum1.kTileStartOfDesertAtlas; i <= (int)TileMap.Enum1.kTileEndOfDesertAtlas; i++) {
                this.SetupAtlasKnowledgeDesert(i);
            }

            for (int i = (int)TileMap.Enum1.kTileStartOfIceAtlas; i <= (int)TileMap.Enum1.kTileEndOfIceAtlas; i++) {
                this.SetupAtlasKnowledgeIce(i);
            }

            for (int i = (int)Enum1.kSpriteTile_Ice1; i <= (int)Enum1.kSpriteTile_Ice2; i++) {
                this.SetupAtlasKnowledgeIceSprites(i);
            }

            for (int i = (int)TileMap.Enum1.kTileStartOfMoonAtlas; i <= (int)TileMap.Enum1.kTileEndOfMoonAtlas; i++) {
                this.SetupAtlasKnowledgeMoon(i);
            }

            for (int i = (int)TileMap.Enum1.kTile_StartGrassCliff; i <= (int)TileMap.Enum1.kTile_EndGrassCliff; i++) {
                this.SetupAtlasKnowledgeCliff(i);
            }

            Globals.Assert((int) SceneType.kNumScenes == 7);
        }

        public int GetAtlasId(int inTileID)
        {
            return atlasId[inTileID];
        }

        public int GetSubTextureId(int inTileID)
        {
            return subTextureId[inTileID];
        }

        public Texture2D_Ross GetTileTexture(int inTileID)
        {
            return tileTexture[inTileID];
        }

        public Tile GetTile (int which)
				{
						if ((which >= (int)TileMap.Enum3.kNumTiles) ||
			    (which < 0)){
				int ross = 0;
						}
            return tile[which];
        }

        public int GetBackCornerTile()
        {
            return backCornerTile;
        }

        public Texture2D_Ross GetTexture (int which)
		{
			Globals.Assert (which < (int)Enum1.kNumTileTextures);
            return tileTexture[which];
        }

/*        public void LoadTexturesP1P2(int numTextures, int firstTexture, string fileName)
        {
            string string1;
            for (int i = 0; i < numTextures; i++) {
                string1 = String.Format("%@%d.png", fileName, i + 1);
                tileTexture[firstTexture + i] = Globals.g_world.LoadTextureP1(false, string1);
            }

        }*/

        public void AllocTextures()
        {

            #if PROFILING_OUT
                subTextureId[(int)TileMap.Enum1.kTile_LB_RemoveSpace] = -1;
                subTextureId[(int)TileMap.Enum1.kTile_Bridge1] = -1;
                subTextureId[(int)TileMap.Enum1.kTile_Water] = -1;
                atlasId[(int)TileMap.Enum1.kTile_LB_RemoveSpace] = -1;
                atlasId[(int)TileMap.Enum1.kTile_Bridge1] = -1;
                atlasId[(int)TileMap.Enum1.kTile_Water] = -1;
            #endif

        }

        public TileGrid GetTileGrid()
        {
            return tileGrid;
        }

        public void InitialiseBeforeObjectsAdded(int whichScene)
        {
			prevYEndTile = 0;
			prevXStartTile = 0;
			prevXEndTile = 9;
            currentScene = whichScene;
            tileGrid.ClearWithGrassyTiles(whichScene);
        }

        public void RefreshTexturesOnStrip(int inBackCornerTile)
        {
            for (int i = inBackCornerTile; i < (inBackCornerTile + (int)TileMap.kTilesWide); i++) {
                int stripInt = inBackCornerTile / (int)TileMap.kTilesWide;
                int x = i % (int)TileMap.kTilesWide;
                int newTexture = tileGrid.GetTileIdP1(x, stripYOffset[stripInt]);
                (tile[i]).ApplyTextureP1P2P3P4P5(tileTexture[newTexture], subTextureId[newTexture], atlasId[newTexture], spriteSubTextureId[newTexture],
                  spriteAtlasId[newTexture], spriteSubOneDeep[newTexture]);
            }

        }

        public void RefreshTextures()
        {
            this.UpdateTileTextures();
        }

        public void StartOfRace()
        {
            tileMapScrollOffset = Utilities.CGPointMake(0.0f, 0.0f);
            tileYOffset = 0;
			
			if (Globals.g_main.usingTextureResolution == TextureResolutionEnum.kTextureResolution_High)
			{
				//tileMapScrollOffset.y = -64.0f;
			}
			

            #if !UP_RACE
                tileMapScrollOffset = Utilities.CGPointMake(0.0f, 63.9f);
            #endif

            int tileId = 0;
            for (int y = 0; y < (int)TileMap.kTilesHigh; y++) {
                for (int x = 0; x < (int)TileMap.kTilesWide; x++) {
                    this.SetNewTextureOnTileP1P2(tileId, x, y);
                    tileId++;
                }

                tileYOffset++;
            }

        }

        public void AddStoneWallP1P2(int yPos, int inGatePos, int inGateWidth)
        {
            if (currentScene == (int) SceneType.kSceneGrass) {
                this.PlaceObjectP1((int) ObjectType.kOT_FinishingLine, Utilities.CGPointMake(0, yPos));
            }
            else if (currentScene == (int) SceneType.kSceneMud) {
                this.PlaceObjectP1((int) ObjectType.kOT_FinishingLine, Utilities.CGPointMake(0, yPos));
            }
            else if (currentScene == (int) SceneType.kSceneIce) {
                this.PlaceObjectP1((int) ObjectType.kOT_FinishingLine, Utilities.CGPointMake(0.0f, (float) yPos));
            }
            else if (currentScene == (int) SceneType.kSceneMoon) {
                this.PlaceObjectP1((int) ObjectType.kOT_FinishingLine, Utilities.CGPointMake(0.0f, (float) yPos));
            }
            else if (currentScene == (int) SceneType.kSceneDesert) {
                this.PlaceObjectP1((int) ObjectType.kOT_FinishingLine, Utilities.CGPointMake(0.0f, (float) yPos));
            }
            else {
                Globals.Assert(false);
            }

        }

        public void AddBigHoleP1(int xPos, int yPos)
        {
        }

        public void AddRampP1P2(int xPos, int yPos, int width)
        {
            if (width == 1) {
                tileGrid.SetTileIdP1P2(xPos, yPos, (int)TileMap.Enum1.kTile_Ramp1);
                tileGrid.SetTileIdP1P2(xPos + 1, yPos, (int)TileMap.Enum1.kTile_WideRamp3);
                tileGrid.SetTileIdP1P2(xPos, yPos + 1, (int)TileMap.Enum1.kTile_Ramp2);
                tileGrid.SetTileIdP1P2(xPos + 1, yPos + 1, (int)TileMap.Enum1.kTile_WideRamp6);
            }
            else {
                tileGrid.SetTileIdP1P2(xPos, yPos, (int)TileMap.Enum1.kTile_WideRamp1);
                tileGrid.SetTileIdP1P2(xPos + 1, yPos, (int)TileMap.Enum1.kTile_WideRamp2);
                tileGrid.SetTileIdP1P2(xPos + 2, yPos, (int)TileMap.Enum1.kTile_WideRamp3);
                tileGrid.SetTileIdP1P2(xPos, yPos + 1, (int)TileMap.Enum1.kTile_WideRamp4);
                tileGrid.SetTileIdP1P2(xPos + 1, yPos + 1, (int)TileMap.Enum1.kTile_WideRamp5);
                tileGrid.SetTileIdP1P2(xPos + 2, yPos + 1, (int)TileMap.Enum1.kTile_WideRamp6);
            }

        }

        public void AddPondP1(int xPos, int yPos)
        {
            tileGrid.SetTileIdP1P2(xPos - 1, yPos - 1, (int)TileMap.Enum1.kTile_Pond1);
            tileGrid.SetTileIdP1P2(xPos, yPos - 1, (int)TileMap.Enum1.kTile_Pond2);
            tileGrid.SetTileIdP1P2(xPos + 1, yPos - 1, (int)TileMap.Enum1.kTile_Pond3);
            tileGrid.SetTileIdP1P2(xPos - 1, yPos, (int)TileMap.Enum1.kTile_Pond4);
            tileGrid.SetTileIdP1P2(xPos, yPos, (int)TileMap.Enum1.kTile_Pond5);
            tileGrid.SetTileIdP1P2(xPos + 1, yPos, (int)TileMap.Enum1.kTile_Pond6);
            tileGrid.SetTileIdP1P2(xPos - 1, yPos + 1, (int)TileMap.Enum1.kTile_Pond7);
            tileGrid.SetTileIdP1P2(xPos, yPos + 1, (int)TileMap.Enum1.kTile_Pond8);
            tileGrid.SetTileIdP1P2(xPos + 1, yPos + 1, (int)TileMap.Enum1.kTile_Pond9);
        }

        public void AddBigRockP1(int xPos, int yPos)
        {
            tileGrid.SetTileIdP1P2(xPos, yPos, (int)TileMap.Enum1.kTile_BigRock1);
            tileGrid.SetTileIdP1P2(xPos + 1, yPos, (int)TileMap.Enum1.kTile_BigRock2);
            tileGrid.SetTileIdP1P2(xPos + 2, yPos, (int)TileMap.Enum1.kTile_BigRock3);
            tileGrid.SetTileIdP1P2(xPos, yPos + 1, (int)TileMap.Enum1.kTile_BigRock4);
            tileGrid.SetTileIdP1P2(xPos + 1, yPos + 1, (int)TileMap.Enum1.kTile_BigRock5);
            tileGrid.SetTileIdP1P2(xPos + 2, yPos + 1, (int)TileMap.Enum1.kTile_BigRock6);
        }

        public void AddRockP1(int xPos, int yPos)
        {
            tileGrid.SetTileIdP1P2(xPos, yPos, (int)TileMap.Enum1.kTile_Rock1);
            tileGrid.SetTileIdP1P2(xPos + 1, yPos, (int)TileMap.Enum1.kTile_Rock2);
        }

        public void PlaceObjectP1(int inType, CGPoint tileSquare)
        {
            float tileWidth = ((Globals.g_world.game).lBuilder).GetObjectInfo((ObjectType)inType).tileWidth;
            float tileHeight = ((Globals.g_world.game).lBuilder).GetObjectInfo((ObjectType)inType).tileHeight;
            for (int x = 0; x < (int) tileWidth; x++) {
                for (int y = 0; y < (int) tileHeight; y++) {
                    int tileId = ((Globals.g_world.game).lBuilder).GetObjectInfo((ObjectType)inType).objectTile[x, y];
                    if (tileId != -1) {
                        int xPos = ((int) tileSquare.x) + x;

                        #if UP_RACE
                            int yPos = ((int) tileSquare.y) + tileHeight - 1 - y;
                        #else
                            int yPos = ((int) tileSquare.y) + y;
                        #endif

                        if (inType ==  (int)ObjectType.kOT_MudPuddle1x1) {
                            int randTile = Utilities.GetRand( 4);
                            if (randTile == 1) {
                                randTile += 1;
                            }
                            else if (randTile == 2) {
                                randTile += 33;
                            }
                            else if (randTile == 3) {
                                randTile += 49;
                            }

                        }

                        tileGrid.SetTileIdP1P2(xPos, yPos, tileId);
                    }

                }

            }

        }

        public int GetAtlasIdForThisSceneP1(int whichAtlas, int whichScene)
        {
            Globals.Assert(whichScene < (int) SceneType.kNumScenes);
            Globals.Assert(whichAtlas < numAtlasesForScene[whichScene]);
            return atlasIdForScene[whichScene, whichAtlas];
        }

        public int GetNumAtlasesForThisScene(int whichScene)
        {
            Globals.Assert(whichScene < (int) SceneType.kNumScenes);
            return numAtlasesForScene[whichScene];
        }

        public void AddTreeP1P2(int xPos, int yPos, int type)
        {
        }

        public void AddHedgeP1P2(int yPos, int gateStart, int width)
        {
            int gateEnd = gateStart + width;
            for (int i = 0; i < (int)TileMap.kTilesWide; i++) {
                if (((i * 2) + 1) < gateStart) tileGrid.SetTileIdP1P2(i, yPos, (int)TileMap.Enum1.kTile_Hedge);

                if ((i * 2) == gateEnd) tileGrid.SetTileIdP1P2(i, yPos, (int)TileMap.Enum1.kTile_HedgeNearEnd);
                else if ((i * 2) >= gateEnd) tileGrid.SetTileIdP1P2(i, yPos, (int)TileMap.Enum1.kTile_Hedge);
                else if ((i * 2) == gateStart) {
                    if (width == 2) tileGrid.SetTileIdP1P2(i, yPos, (int)TileMap.Enum1.kTile_GatePosts);
                    else tileGrid.SetTileIdP1P2(i, yPos, (int)TileMap.Enum1.kTile_GatePostLeft);

                }
                else if (((i * 2) + 1) == gateStart) tileGrid.SetTileIdP1P2(i, yPos, (int)TileMap.Enum1.kTile_HedgeHalfRight);
                else if (((i * 2) + 1) == gateEnd) tileGrid.SetTileIdP1P2(i, yPos, (int)TileMap.Enum1.kTile_HedgeHalfLeft);
                else if (((i * 2) + 2) == gateEnd) tileGrid.SetTileIdP1P2(i, yPos, (int)TileMap.Enum1.kTile_GatePostRight);

            }

        }

        public void AddRiverP1P2(int xPos, int yPos, int width)
        {
            for (int i = 0; i < (int)TileMap.kTilesWide; i++) {
                tileGrid.SetTileIdP1P2(i, yPos + 1, (int)TileMap.Enum1.kTile_FlowerCliff);
                tileGrid.SetTileIdP1P2(i, yPos + 2, (int)TileMap.Enum1.kTile_WaterShadow1);
                tileGrid.SetTileIdP1P2(i, yPos + 3, (int)TileMap.Enum1.kTile_Water);
                tileGrid.SetTileIdP1P2(i, yPos + 4, (int)TileMap.Enum1.kTile_Water);
                tileGrid.SetTileIdP1P2(i, yPos + 5, (int)TileMap.Enum1.kTile_Water);
                tileGrid.SetTileIdP1P2(i, yPos + 6, (int)TileMap.Enum1.kTile_WaterToNormal);
            }

            int sidePlus = 0;
            for (int i = 0; i < width; i++) {
                tileGrid.SetTileIdP1P2(xPos + i, yPos, (int)TileMap.Enum1.kTile_BridgeStart);
                tileGrid.SetTileIdP1P2(xPos + i, yPos + 1, (int)TileMap.Enum1.kTile_Bridge1);
                tileGrid.SetTileIdP1P2(xPos + i, yPos + 2, (int)TileMap.Enum1.kTile_Bridge2);
                tileGrid.SetTileIdP1P2(xPos + i, yPos + 3, (int)TileMap.Enum1.kTile_Bridge1);
                tileGrid.SetTileIdP1P2(xPos + i, yPos + 4, (int)TileMap.Enum1.kTile_Bridge2);
                tileGrid.SetTileIdP1P2(xPos + i, yPos + 5, (int)TileMap.Enum1.kTile_Bridge1);
                tileGrid.SetTileIdP1P2(xPos + i, yPos + 6, (int)TileMap.Enum1.kTile_Bridge2);
                sidePlus++;
            }

            if ((xPos + sidePlus) < (int)TileMap.kTilesWide) {
                tileGrid.SetTileIdP1P2(xPos + sidePlus, yPos + 2, (int)TileMap.Enum1.kTile_WaterShadow2);
                tileGrid.SetTileIdP1P2(xPos + sidePlus, yPos + 3, (int)TileMap.Enum1.kTile_WaterShadow3);
                tileGrid.SetTileIdP1P2(xPos + sidePlus, yPos + 4, (int)TileMap.Enum1.kTile_WaterShadow3);
                tileGrid.SetTileIdP1P2(xPos + sidePlus, yPos + 5, (int)TileMap.Enum1.kTile_WaterShadow3);
                tileGrid.SetTileIdP1P2(xPos + sidePlus, yPos + 6, (int)TileMap.Enum1.kTile_OtherBankWaterShadow);
            }

        }

        public void RenderScene(float scrollAmount)
        {
            tileMapScrollOffset.y += scrollAmount;
			
			for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) {
				tile[i].AddToYPosition(scrollAmount);
			}
			
            if (scrollAmount > 0.0f) {
                if (tileMapScrollOffset.y >= Constants.TILE_SIZE) {
                    tileMapScrollOffset.y -= Constants.TILE_SIZE;
                    tileYOffset--;
                    this.UpdateTileTextures();

					for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) {
						tile[i].AddToYPosition(-Constants.TILE_SIZE);
					}				
				}

            }
            else {
                if (tileMapScrollOffset.y < 0.0f) {
                    tileMapScrollOffset.y += Constants.TILE_SIZE;
                    tileYOffset++;
                    this.UpdateTileTextures();

					for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) {
						tile[i].AddToYPosition(Constants.TILE_SIZE);
					}								
				}

            }

            #if PROFILING_OUT
                Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_StartTile] = DateTime.Now.TimeOfDay.Milliseconds;
            #endif

            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPushMatrix();

                float tileSizeMultiplier;
                if (Globals.deviceIPad) {
                    tileSizeMultiplier = 2.0f;
                }
                else {
                    tileSizeMultiplier = 1.0f;
                }

                float yOffset;
                float xOffset;
                if (Globals.deviceIPad) {
                    xOffset = -704.0f + (Globals.g_world.drawWidth);
                    xOffset -= ((Globals.g_world.game).scrollPosition.x * 2.0f);
                    yOffset = 32.0f + ((Globals.g_world.drawHeight - Globals.g_world.coordinatesHeight) * 2.0f) - (tileMapScrollOffset.y * tileSizeMultiplier) + (Constants
                      .TILE_SIZE * 2.0f);
                }
                else {
                    xOffset = -320.0f + (Globals.g_world.drawWidth / 2.0f);
                    xOffset -= (Globals.g_world.game).scrollPosition.x;
                    yOffset = (Globals.g_world.drawHeight - 480.0f) - (tileMapScrollOffset.y * tileSizeMultiplier) + (Constants.TILE_SIZE);
                }
			
//			Vector3 newPosition = Globals.g_world.gameCam.transform.position;
			//newPosition.y = -yOffset;
			//Globals.g_world.gameCam.transform.position = newPosition;

			//			Camera.main.transform.position.x = 100.0f;// Translate(1,0,0);
			
			
            float left = Globals.g_world.leftDrawEdge + (Globals.g_world.game).scrollPosition.x + 128.0f;
            int xStartTile = (int) ((left) / Constants.TILE_SIZE);
            int xEndTile = 0 + (int)((left + Globals.g_world.drawWidth) / Constants.TILE_SIZE);
            int yStartTile = 0;
            int yEndTile = yStartTile + (int) ((Constants.TILE_SIZE + Globals.g_world.drawHeight - tileMapScrollOffset.y) / Constants.TILE_SIZE);
            if (xStartTile < 0) xStartTile = 0;

            if (xEndTile > 9) xEndTile = 9;
			
			//xStartTile += 2;
			
			//xStartTile = 0;
			//xEndTile = 9;
			
			if (xStartTile > prevXStartTile)
			{
				for (int i = yStartTile; i <= yEndTile; i++)
				{
					int tileId = prevXStartTile + (i * (int)TileMap.kTilesWide);
					tile[tileId].StopRender();
				}
			}
			if (xEndTile < prevXEndTile)
			{
				for (int i = yStartTile; i <= yEndTile; i++)
				{
					int tileId = prevXEndTile + (i * (int)TileMap.kTilesWide);
					tile[tileId].StopRender();
				}
			}
			if (yEndTile < prevYEndTile)
			{
				for (int i = xStartTile; i <= xEndTile; i++)
				{
					int tileId = i + (prevYEndTile * (int)TileMap.kTilesWide);
					tile[tileId].StopRender();
				}
			}
			
			
			prevXStartTile = xStartTile;
			prevXEndTile = xEndTile;
			prevYEndTile = yEndTile;			
			
            if (yEndTile > ((int)TileMap.kTilesHigh - 1)) yEndTile = ((int)TileMap.kTilesHigh - 1);

            for (int i = 0; i < numAtlasesForScene[currentScene]; i++) {
                int useAtlasId = atlasIdForScene[currentScene, i];
                (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas(useAtlasId));
                for (int y = yStartTile; y <= yEndTile; y++) {
                    for (int x = xStartTile; x <= xEndTile; x++) {
                        int useY;
                        if (y >= (int)TileMap.kTilesHigh) {
                            useY = y - (int)TileMap.kTilesHigh;
                        }
                        else {
                            useY = y;
                        }

                        int i2 = (useY * (int)TileMap.kTilesWide) + x;

                        #if TILE_DEBUG
                            if ((Globals.g_world.game).OutputTileInfo()) {
                                if ((Globals.g_world.game).gameState == GameState.e_Paused) {
                                }

                            }

                        #endif

                        if ((tile[i2]).atlasId == useAtlasId) {
                            (tile[i2]).RenderScene_WithBigDrawArrays(-(Globals.g_world.game).scrollPosition.x);//-xOffset);
                        }

                    }

                }

                (DrawManager.Instance()).Flush();
            }

            #if TILE_DEBUG
                (Globals.g_world.game).SetOutputTileInfo(false);
            #endif

            #if !UP_RACE
                //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            #endif

            //glPopMatrix();

            #if PROFILING_OUT
                Globals.g_main.profileTime[(int)CrashLandingAppDelegate.Enum2.kPP_EndTile] = DateTime.Now.TimeOfDay.Milliseconds;
            #endif

        }

        public void RenderTilesLevelBuilder_Ross (int inAtlasId)
		{
			for (int i = 0; i < (int)TileMap.Enum3.kNumTiles; i++) {
                if ((i % 10) < 2) {
                }

                if ((tile[i]).atlasId == inAtlasId) (tile[i]).RenderSceneLevelBuilder_Ross();

            }

        }

        public void RenderSceneLevelBuilder_Ross(float scrollAmount)
        {
            tileMapScrollOffset.y += scrollAmount;
            if (scrollAmount > 0.0f) {
                if (tileMapScrollOffset.y >= Constants.TILE_SIZE) {
                    tileMapScrollOffset.y -= Constants.TILE_SIZE;
                    tileYOffset--;
                    this.UpdateTileTextures();
                }

            }
            else {
                if (tileMapScrollOffset.y < 0.0f) {
                    tileMapScrollOffset.y += Constants.TILE_SIZE;
                    tileYOffset++;
                    this.UpdateTileTextures();
                }

            }

            //Globals.g_main.SetGLMatrixMode(GL_MODELVIEW);
            //glPushMatrix();

            #if UP_RACE
                float thing = 1.0f / Globals.g_world.renderScale;
                float kGapForBottomButtonsThing = (Constants.GAP_FOR_BOTTOM_BUTTS_ON_LB * thing * Constants.kScreenMultiplierForShorts);
                //glTranslatef(-1280.0f, kGapForBottomButtonsThing + (tileMapScrollOffset.y * Constants.kScreenMultiplierForShorts), 0);
            #else
                if (Globals.deviceIPad) {
                    float dHeight = 1.0f / Constants.LEVEL_BUILDER_TILE_SCALE * 480.0f;
                    //glTranslatef(-192.0f * Constants.kScreenMultiplierForShorts, -(((480.0f-dHeight)-416.0f)*Constants.kScreenMultiplierForShorts) - ((
                    //  tileMapScrollOffset.y * 2.0f) * Constants.kScreenMultiplierForShorts), 0.0f);
                }
                else {
                    float dHeight = 1.0f / Constants.LEVEL_BUILDER_TILE_SCALE * 480.0f;
                    //glTranslatef(-128.0f * Constants.kScreenMultiplierForShorts, -(((480.0f-dHeight)-64)*Constants.kScreenMultiplierForShorts) - ((
                      //tileMapScrollOffset.y * 1.0f) * Constants.kScreenMultiplierForShorts), 0.0f);
                }

            #endif

            for (int i = 0; i < numAtlasesForScene[currentScene]; i++) {
                (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas(atlasIdForScene[currentScene, i]));
                this.RenderTilesLevelBuilder_Ross(atlasIdForScene[currentScene, i]);
                (DrawManager.Instance()).Flush();
            }

            //glPopMatrix();
        }

        public void RenderSquareOfTilesP1P2P3P4(CGPoint centrePoint, float inScale, int width, int height, int inSubTextureId)
        {
			if (width > (int)TileMapConsts.kMaxTilesForLB)
			{
				width = (int)TileMapConsts.kMaxTilesForLB;
			}
			if (height > (int)TileMapConsts.kMaxTilesForLB)
			{
				height = (int)TileMapConsts.kMaxTilesForLB;
			}
			
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    CGPoint tilePosition;
                    tilePosition = Utilities.CGPointMake(-((inScale*0.5f*((float)width))) + (Constants.TILE_SIZE * 0.5f * inScale) + (centrePoint.x + ((float) x *
                      inScale * Constants.TILE_SIZE)), (-((inScale*0.5f*((float)height))) + (Constants.TILE_SIZE * 0.5f * inScale) + (centrePoint.y + ((
                      float) y * inScale * Constants.TILE_SIZE))));
                    tilePosition.x -= ((((float) width) * Constants.TILE_SIZE) * 0.5f * inScale);
                    tilePosition.y -= ((((float) height) * Constants.TILE_SIZE) * 0.5f * inScale);
//                    (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(tilePosition, inScale, inScale, inSubTextureId);
//                    (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(tilePosition, inScale, inScale, inSubTextureId);

                    (DrawManager.Instance()).AddTextureToListP1P2P3P4P5(levelBuilderTiles[x,y], tilePosition, inScale, 0.0f,1000.0f,1.0f, inSubTextureId);
				
				}

            }

        }

        public void RenderTileArrayP1P2P3(CGPoint topLeft, CGPoint gridSize, float inScale, CGPoint centrePoint)
        {
            int width = (int) (gridSize.x);
            int height = (int) (gridSize.y);
            int numAtlasesToRender = ((Globals.g_world.game).tileMap).GetNumAtlasesForThisScene(currentScene);
            int[] atlasIdToRender = new int[10];
            for (int i = 0; i < numAtlasesToRender; i++) {
                atlasIdToRender[i] = ((Globals.g_world.game).tileMap).GetAtlasIdForThisSceneP1(i, currentScene);
            }
			
			int useActualTilesIndex = 0;
			
            for (int i = 0; i < numAtlasesToRender; i++) {
                int useAtlas = this.GetAtlasIdForThisSceneP1(i, currentScene);
                (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas(useAtlas));
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        CGPoint tilePosition;
                        tilePosition = Utilities.CGPointMake(-((inScale*0.5f*((float)width))) + (Constants.TILE_SIZE * 0.5f * inScale) + (centrePoint.x + ((float) x *
                          inScale * Constants.TILE_SIZE)), (-((inScale*0.5f*((float)height))) + (Constants.TILE_SIZE * 0.5f * inScale) + (centrePoint.y + ((
                          float) y * inScale * Constants.TILE_SIZE))));
                        tilePosition.x -= ((((float) width) * Constants.TILE_SIZE) * 0.5f * inScale);
                        tilePosition.y -= ((((float) height) * Constants.TILE_SIZE) * 0.5f * inScale);

                      //  #if ZOOMING_MATRIX_TEST
                            int tileId = tileGrid.GetTileIdP1(2 + x + ((int) topLeft.x), y + ((int) topLeft.y));
                      //  #else
                        //    int tileId = tileGrid.GetTileIdP1(x + ((int) topLeft.x), y + ((int) topLeft.y));
                        //#endif

                        if (tileId != -1) {
                            if (true)//((Globals.g_world.game).tileMap).GetAtlasId(tileId) == useAtlas) {
							{
//								CGPoint thingPos = Utilities.CGPointMake(30+(x*30),30+(y*30));
								
								if (useActualTilesIndex < (int)TileMap.Enum3.kNumTiles)
								{
									tile[useActualTilesIndex].SetScreenPosition(tilePosition);
									tile[useActualTilesIndex].SetSubTextureId(GetSubTextureId(tileId));
									tile[useActualTilesIndex].Render_ForTip(inScale);
									useActualTilesIndex++;
								}
								
//                                (DrawManager.Instance()).AddTextureToListXYScaleP1P2P3(tilePosition, inScale, inScale, ((Globals.g_world.game).tileMap).
  //                                GetSubTextureId(tileId));
                            }

                        }

                    }

                }

                (DrawManager.Instance()).Flush();
            }

        }

        public void CheckTileSwap()
        {
        }

        public void SetupTilePositions()
        {
            Globals.Assert(((float)((int)TileMap.kTilesHigh - 1) * Constants.TILE_SIZE) == Constants.TILE_MAP_HEIGHT);
            for (int y = 0; y < (int)TileMap.kTilesHigh; y++) 
			{

               float yPos = (Constants.TILE_SIZE_HALF) + ((float) y * Constants.TILE_SIZE);

                for (int x = 0; x < (int)TileMap.kTilesWide; x++) 
				{
                    CGPoint pos = Utilities.CGPointMake(-160 + (Constants.TILE_SIZE_HALF) + ((float) x * Constants.TILE_SIZE), yPos);
                    (tile[((int)TileMap.kTilesWide * y) + x]).SetScreenPosition(pos);
                }

            }

        }

        public void SetScale(float inScale)
        {
        }

        public void UpdateTileTextures()
        {
            int tileId = 0;
            for (int y = 0; y < (int)TileMap.kTilesHigh; y++) {
                for (int x = 0; x < (int)TileMap.kTilesWide; x++) {
                    this.SetNewTextureOnTileP1P2(tileId, x, y + (tileYOffset - (int)TileMap.kTilesHigh));
                    tileId++;
                }

            }

        }

        public void SetNewTextureOnTileP1P2(int tileId, int x, int y)
        {
            int newTexture = tileGrid.GetTileIdP1(x, y);
		//	Debug.Log(newTexture + "x" + x + "y" + y);
            (tile[tileId]).ApplyNewTextureP1P2P3P4(subTextureId[newTexture], atlasId[newTexture], spriteSubTextureId[newTexture], spriteAtlasId[newTexture],
              spriteSubOneDeep[newTexture]);
        }

        public void SetNewTexturesOnStripP1(int inBackCornerTile, int yStrip)
        {
            for (int i = inBackCornerTile; i < (inBackCornerTile + (int)TileMap.kTilesWide); i++) {
                int x = i % (int)TileMap.kTilesWide;
                int newTexture = tileGrid.GetTileIdP1(x, yStrip);
                (tile[i]).ApplyTextureP1P2P3P4P5(tileTexture[newTexture], subTextureId[newTexture], atlasId[newTexture], spriteSubTextureId[newTexture],
                  spriteAtlasId[newTexture], spriteSubOneDeep[newTexture]);
            }

        }

    }
}
