using System;

namespace Default.Namespace
{
    public class TileInfo
    {
        public int atlasId;
        public int subTextureId;
        public int spriteAtlasId;
        public int spriteSubTextureId;
        public bool spriteSubOneDeep;
        public struct TileInfoInfo{
            public short atlasId;
            public short subTextureId;
            public short spriteAtlasId;
            public short spriteSubTextureId;
            public bool spriteSubOneDeep;
        };
        public void Setup(TileInfoInfo info)
        {
            atlasId = info.atlasId;
            subTextureId = info.subTextureId;
            spriteAtlasId = info.spriteAtlasId;
            spriteSubTextureId = info.spriteSubTextureId;
            spriteSubOneDeep = info.spriteSubOneDeep;
        }

    }
}
