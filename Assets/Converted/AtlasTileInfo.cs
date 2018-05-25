using System;

namespace Default.Namespace
{
    public class AtlasTileInfo
    {
		public enum Enum {
            kMaxTilesX = 20,
            kMaxTilesY = 20,
        };
		
        public TileInfo[,] tileInfo = new TileInfo[(int)Enum.kMaxTilesX, (int)Enum.kMaxTilesY];
					
        public TileInfo GetTileInfoP1 (int x, int y)
		{
			Globals.Assert (x < (int)Enum.kMaxTilesX);
			Globals.Assert (y < (int)Enum.kMaxTilesY);
            return tileInfo[x, y];
        }

        public void SetupTileInfoP1P2 (int x, int y, TileInfo.TileInfoInfo info)
		{
			Globals.Assert (x < (int)Enum.kMaxTilesX);
			Globals.Assert (y < (int)Enum.kMaxTilesY);
            if (tileInfo[x, y] == null) {
                tileInfo[x, y] = new TileInfo();
            }

            (tileInfo[x, y]).Setup(info);
        }

    }
}
