using System;

namespace Default.Namespace
{
    public class TileGrid
    {
        public int[,] tileId = new int[(int)Enum.xMaxTiles, (int)Enum.yMaxTiles];
        public enum Enum {
            xMaxTiles = 10,
            yMaxTiles = 800
        };
        public int GetTileIdP1 (int x, int y)
		{
			if (x < 0 || x >= (int)Enum.xMaxTiles) return -1;

            if (y < 0) return -1;

            return tileId[x, y];
        }

        public bool IsGrassyTileP1(int whichScene, int inTileId)
        {
            if (whichScene == (int) SceneType.kSceneGrass) {
                bool isOtherFlower = ((inTileId >= (int)((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 4, 8)) && (inTileId <= (int)(
                  (Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 15, 8)));
                bool isGrass = (((inTileId >= (int)TileMap.Enum1.kTile_Grass) && (inTileId <= (int)(TileMap.Enum1.kTile_Grass + 2))) || ((inTileId >= (int)TileMap.Enum1.kTile_Flowers1) && (inTileId <= (int)(TileMap.Enum1.kTile_Flowers1
                  + 8))) || isOtherFlower);
                bool isRock = ((inTileId == (int)((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 3, 6)) || (inTileId == (int)((
                  Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 3, 7)) || (inTileId == (int)((Globals.g_world.game).lBuilder).
                  GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 4, 6)) || (inTileId == (int)((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType
                  .kAtlas_GrassTiles, 4, 7)));
                return (isGrass || isRock || isOtherFlower);
            }
            else if (whichScene == (int) SceneType.kSceneMud) {
                bool isGrass = ((inTileId >= (int)(TileMap.Enum1.kTile_FarmAtlasFirstTile + 3)) && (inTileId <= (int)(TileMap.Enum1.kTile_FarmAtlasFirstTile + 13)));
                bool isRock = ((inTileId == (int)((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_MudTiles, 4, 1)) || (inTileId == (int)((Globals.g_world.
                  game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_MudTiles, 6, 1)) || (inTileId == (int)((Globals.g_world.game).lBuilder).
                  GetTileMapTileP1P2((int) AtlasType.kAtlas_MudTiles, 5, 1)) || (inTileId == (int)((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.
                  kAtlas_MudTiles, 7, 1)));
                return (isGrass || isRock);
            }
            else {
                Globals.Assert(false);
            }

			return false;
        }

        public int GetRandomGrassyTileP1(int whichScene, int yRow)
        {
            int grassyTileId = 0;
            if (whichScene == (int) SceneType.kSceneGrass) {
                grassyTileId = (int)TileMap.Enum1.kTile_Grass + Utilities.GetRand( 2);
                if (Utilities.GetRand( 3) == 0) {
                    grassyTileId = (int)TileMap.Enum1.kTile_Flowers1 + Utilities.GetRand( 9);
                }

                const int kVioletsStart = 4;
                const int kButterCupsStart = 8;
                const int kPoppiesStart = 12;
                int flowerStart = 0;
                int thing = (Globals.g_world.game).playingLevel;
                if (thing % 4 == 0) return grassyTileId;
                else if (thing % 4 == 1) {
                    if ((Globals.g_world.game).playingLevel < 48) return grassyTileId;

                    flowerStart = kVioletsStart;
                }
                else if (thing % 4 == 2) {
                    if ((Globals.g_world.game).playingLevel < 16) return grassyTileId;

                    flowerStart = kButterCupsStart;
                }
                else if (thing % 4 == 3) {
                    if ((Globals.g_world.game).playingLevel < 32) return grassyTileId;

                    flowerStart = kPoppiesStart;
                }

                grassyTileId = (int)TileMap.Enum1.kTile_Grass + Utilities.GetRand( 2);
                if (Utilities.GetRand( 3) == 0) {
                    if (Utilities.GetRand( 2) == 0) {
                        grassyTileId = (int)TileMap.Enum1.kTile_Flowers1 + Utilities.GetRand( 9);
                    }
                    else {
                        grassyTileId = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, flowerStart, 8) + Utilities.GetRand( 4);
                    }

                }

            }
            else if (whichScene == (int) SceneType.kSceneMud) {
                int chanceOfTrash = 4;
                int thing = (Globals.g_world.game).playingLevel;
                thing *= 7;
                if (thing % 3 == 0) {
                    chanceOfTrash = 7;
                }
                else if (thing % 3 == 1) {
                    chanceOfTrash = 10;
                }

                if (Utilities.GetRand( chanceOfTrash) == 0) {
                    int whichMud = Utilities.GetRand( 11);
                    grassyTileId = (int)TileMap.Enum1.kTile_FarmAtlasFirstTile + 3 + whichMud;
                }
                else {
                    grassyTileId = (int)TileMap.Enum1.kTile_FarmAtlasFirstTile + 3;
                }

            }
            else if (whichScene == (int) SceneType.kSceneDesert) {
                grassyTileId = (int)TileMap.Enum1.kTile_Sand;
            }
            else if (whichScene == (int) SceneType.kSceneIce) {
                grassyTileId = (int)TileMap.Enum1.kTile_Ice;
            }
            else if (whichScene == (int) SceneType.kSceneMoon) {
                if (Utilities.GetRand( 5) == 0) {
                    if (Utilities.GetRand( 2) == 0) {
                        grassyTileId = (int)TileMap.Enum1.kTile_babyCrater1 + Utilities.GetRand( 3);
                    }
                    else {
                        grassyTileId = (int)TileMap.Enum1.kTile_babyCrater4 + Utilities.GetRand( 3);
                    }

                }
                else grassyTileId = (int)TileMap.Enum1.kTile_Moon;

            }
            else {
                Globals.Assert(false);
            }

            return grassyTileId;
        }

        int GetNormalSideWall(int whichScene)
        {
            int numRandoms = -1;
            int[] randomTiles = new int[4];
            switch ((SceneType)whichScene) {
            case SceneType.kSceneGrass :
                numRandoms = 4;
                randomTiles[0] = (int)TileMap.Enum1.kTile_SideRock1;
                randomTiles[1] = (int)TileMap.Enum1.kTile_SideRock2;
                randomTiles[2] = (int)TileMap.Enum1.kTile_SideRock3;
                randomTiles[3] = (int)TileMap.Enum1.kTile_SideRock4;
                break;
            case SceneType.kSceneMud :
                numRandoms = 1;
                randomTiles[0] = (int)TileMap.Enum1.kTile_SideFence;
                break;
            case SceneType.kSceneIce :
                numRandoms = 4;
                randomTiles[0] = (int)TileMap.Enum1.kTile_IceRock1;
                randomTiles[1] = (int)TileMap.Enum1.kTile_IceRock2;
                randomTiles[2] = (int)TileMap.Enum1.kTile_IceRock3;
                randomTiles[3] = (int)TileMap.Enum1.kTile_IceRock4;
                break;
            case SceneType.kSceneDesert :
                numRandoms = 4;
                randomTiles[0] = (int)TileMap.Enum1.kTile_DesertRock1;
                randomTiles[1] = (int)TileMap.Enum1.kTile_DesertRock2;
                randomTiles[2] = (int)TileMap.Enum1.kTile_DesertRock3;
                randomTiles[3] = (int)TileMap.Enum1.kTile_DesertRock4;
                break;
            case SceneType.kSceneMoon :
                numRandoms = 2;
                randomTiles[0] = (int)TileMap.Enum1.kTile_MoonRock1;
                randomTiles[1] = (int)TileMap.Enum1.kTile_MoonRock2;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            Globals.Assert(numRandoms > 0);
            int randTile = Utilities.GetRand( numRandoms);
            Globals.Assert(randTile < 4);
            return randomTiles[randTile];
        }

        public void CheckAndPlaceSideWallTileP1P2(int whichScene, int x, int y)
        {
            if (!this.IsGrassyTileP1(whichScene, tileId[x, y])) {
                return;
            }

            switch ((SceneType)whichScene) {
            case SceneType.kSceneGrass :
                tileId[x, y] = ((Globals.g_world.game).lBuilder).GetRandomTileFromSquareP1P2(whichScene, Utilities.CGPointMake(3, 6), Utilities.CGPointMake(2, 2));
                break;
            case SceneType.kSceneMud :
                tileId[x, y] = ((Globals.g_world.game).lBuilder).GetRandomTileFromSquareP1P2(whichScene, Utilities.CGPointMake(4, 1), Utilities.CGPointMake(4, 1));
                break;
            default :
                Globals.Assert(false);
                break;
            }

        }

        public void AddSideChimneysAtP1(int x, int y)
        {
            if ((tileId[x, y] == (int)TileMap.Enum1.kTile_FarmAtlasFirstTile) || (tileId[x, y] == (int)TileMap.Enum1.kTile_BigSideShed_2)) {
                tileId[x, y] = (int)TileMap.Enum1.kTile_SideChimneysTop;
            }
            else if (tileId[x, y] == (int)TileMap.Enum1.kTile_BigSideShed_3) {
                tileId[x, y] = (int)TileMap.Enum1.kTile_SideChimneysMid;
            }
            else if ((tileId[x, y] == (int)TileMap.Enum1.kTile_BigSideShed_4) || (tileId[x, y] == (int)TileMap.Enum1.kTile_BigSideShed_5) || (tileId[x, y] == (int)TileMap.Enum1.kTile_BigSideShed_6)) {
                tileId[x, y] = (int)TileMap.Enum1.kTile_SideChimneysBottom;
            }

        }

        public void AddSideChimneys (int whichScene)
		{
			for (int y = 0; y < (int)Enum.yMaxTiles; y++) {
                this.AddSideChimneysAtP1(2, y);
                this.AddSideChimneysAtP1(9, y);
            }

        }

        public void AddSideWalls (int whichScene)
		{
			if (whichScene == (int)SceneType.kSceneGrass) {
				for (int y = 0; y < (int)Enum.yMaxTiles; y++) {
					if (y % 2 == 0) {
						this.CheckAndPlaceSideWallTileP1P2 (whichScene, 1, y);
						this.CheckAndPlaceSideWallTileP1P2 (whichScene, 8, y);
					}

				}

			} else if (whichScene == (int)SceneType.kSceneMud) {
				for (int y = 0; y < (int)Enum.yMaxTiles; y++) {
                    if (y % 2 == 0) {
                        this.CheckAndPlaceSideWallTileP1P2(whichScene, 1, y);
                        this.CheckAndPlaceSideWallTileP1P2(whichScene, 8, y);
                    }

                }

            }
            else {
                Globals.Assert(false);
            }

        }

        public void CheckAndExtendRivers(int y)
        {
            int[] riverTiles = new int[6];
            riverTiles[0] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 15, 0);
            riverTiles[1] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 15, 1);
            riverTiles[2] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 15, 2);
            riverTiles[3] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 15, 3);
            riverTiles[4] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 15, 4);
            riverTiles[5] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 15, 5);
            for (int riverTileType = 0; riverTileType < 6; riverTileType++) {
                if ((tileId[3, y] == riverTiles[riverTileType]) || (tileId[4, y] == riverTiles[riverTileType]) || (tileId[5, y] == riverTiles[riverTileType]) ||
                  (tileId[2, y] == riverTiles[riverTileType])) {
                    tileId[0, y] = riverTiles[riverTileType];
                    tileId[1, y] = riverTiles[riverTileType];
                    tileId[8, y] = riverTiles[riverTileType];
                    tileId[9, y] = riverTiles[riverTileType];
                    break;
                }

            }

        }

        public void CheckAndExtendRoadsP1(int whichScene, int y)
        {
            int[] roadTiles = new int[3];
            if (whichScene == (int) SceneType.kSceneGrass) {
                const int kRoadX = 2;
                const int kRoadY = 8;
                roadTiles[0] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, kRoadX, kRoadY);
                roadTiles[1] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, kRoadX, kRoadY + 1);
                roadTiles[2] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, kRoadX, kRoadY + 2);
            }
            else {
                const int kRoadX = 2;
                const int kRoadY = 8;
                roadTiles[0] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_MudTiles, kRoadX, kRoadY);
                roadTiles[1] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_MudTiles, kRoadX, kRoadY + 1);
                roadTiles[2] = ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_MudTiles, kRoadX, kRoadY + 2);
            }

            for (int i = 0; i < 3; i++) {
                if ((tileId[3, y] == roadTiles[i]) || (tileId[4, y] == roadTiles[i]) || (tileId[5, y] == roadTiles[i])) {
                    tileId[0, y] = roadTiles[i];
                    tileId[1, y] = roadTiles[i];
                    tileId[8, y] = roadTiles[i];
                    tileId[9, y] = roadTiles[i];
                    break;
                }

            }

        }

        public void CheckAndExtendWallsP1(int y, int wallTile)
        {
            if (tileId[2, y] == wallTile) {
                tileId[0, y] = wallTile;
                tileId[1, y] = wallTile;
                tileId[8, y] = wallTile;
                tileId[9, y] = wallTile;
            }

        }

        public void AddFinishingWallsExtended (int whichScene)
		{
			if (whichScene == (int)SceneType.kSceneGrass) {
				for (int y = 0; y < (int)Enum.yMaxTiles; y++) {
					this.CheckAndExtendWallsP1 (
						y,
						((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_GrassTiles, 9, 6)
					);
					this.CheckAndExtendRivers (y);
					this.CheckAndExtendRoadsP1 ((int)SceneType.kSceneGrass, y);
				}

			} else if (whichScene == (int)SceneType.kSceneMud) {
				for (int y = 0; y < (int)Enum.yMaxTiles; y++) {
                    this.CheckAndExtendWallsP1(y, ((Globals.g_world.game).lBuilder).GetTileMapTileP1P2((int) AtlasType.kAtlas_MudTiles, 10, 5));
                    this.CheckAndExtendRoadsP1((int) SceneType.kSceneMud, y);
                }

            }

        }

        public void ClearWithGrassyTiles (int whichScene)
		{
			for (int x = 0; x < (int)Enum.xMaxTiles; x++) {
				for (int y = 0; y < (int)Enum.yMaxTiles; y++) {
                    tileId[x, y] = this.GetRandomGrassyTileP1(whichScene, y);
                }

            }

        }

        public void SetTileIdP1P2 (int x, int y, int inTileId)
		{

			//#if ZOOMING_MATRIX_TEST
                x += 2;
                Globals.Assert(Constants.LEFTMOST_TILE_ON_LB == 0);
			//#endif

			if (x < 0 || x >= (int)Enum.xMaxTiles)
				return;

			if (y < 0 || y >= (int)Enum.yMaxTiles) return;

            tileId[x, y] = inTileId;
        }

    }
}
