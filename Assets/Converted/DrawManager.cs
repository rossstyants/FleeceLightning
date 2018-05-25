using System;

namespace Default.Namespace
{
    public partial class Constants
    {
        public const int MAX_VERTS = (20000);
        public const int ARRAY_SIZE = (Constants.MAX_VERTS + 6);
        public const int NUM_TEXTURES = (2);
        public const int MAX_PARTICLES = (20000);
    }
    public class DrawManager
    {
		private static DrawManager drawManagerInstance;
        public ZAtlas atlas;


        public enum Enum {
            H,
            S,
            V
        };
        static long _vertexCount = 0;
        static ParticleVert[] _interleavedVerts = new ParticleVert[Constants.MAX_VERTS];
        public class ParticleVert {

            short[] v = new short[2];

            long color;
			
            short[] uv = new short[2];

        };

		public static DrawManager Instance()
        {
         if (drawManagerInstance == null)
         {
            drawManagerInstance = new DrawManager();
         }
			
         return drawManagerInstance;
        }

        DrawManager()
        {
           // if (!(this=base.init())) return null;

            //return this;
        }
        public void Dealloc()
        {
            this.Reset();
        }

        public void _checkGLError () 
		{
//            GLpublic enum error = glGetError();
  //          if (error) {
    //            fprintf(stderr, "GL Error: %x\n", error);
      //          exit(0);
        //    }

        }

        public void Begin(ZAtlas inZ)
        {

            #if TEST_SHORTS
                float width = (inZ.texture).pixelsWide;
                float height = (inZ.texture).pixelsHigh;
                //Globals.g_main.SetGLMatrixMode(GL_TEXTURE);
                //glLoadIdentity();
                //glScalef(1.0f / width, 1.0f / height, 1.0f);
            #endif

            atlas = inZ;
//            (inZ.texture).Bind();
        }

//        static public void _addVertex (short x, short y, short uvx, short uvy, long color);
  //      static public void _addVertex (float x, float y, short uvx, short uvy, long color);
    //    static public void _addVertex (float x, float y, float uvx, float uvy, long color);
        public void AddRotatedAlphaScaledTextureToListP1P2P3P4P5(CGPoint inPos, float rotation, float rotationScale, float inAlpha, float scale, int inSubTextureId)
        {
        }

        public void AddAlphaScaledTextureToListP1P2P3(CGPoint inPos, float alpha, float scale, int inSubTextureId)
        {
        }

        public void AddRotatedTextureToListP1P2P3 (CGPoint inPos, float rotation, float rotationScale, int inSubTextureId)
		{
        }

        public void AddTextureToListWithColourP1P2P3P4 (Billboard inBillboard ,CGPoint inPos, float scale, float alpha, Constants.RossColour inCol, int inSubTextureId)
		{
			inBillboard.SetColour(inCol);
			inBillboard.RenderAtPosition(inPos,scale,0.0f,alpha,inSubTextureId);
        }

        public void AddTextureToListP1P2P3P4P5 (Billboard inBillboard ,CGPoint inPos, float scale, float rotation, float rotationScale, float alpha, int inSubTextureId)
		{
			if (inSubTextureId < 0)
			{
				return;
			}
			
			if (inBillboard == null)
				return;
			inBillboard.RenderAtPosition(inPos,scale,rotation,alpha,inSubTextureId);
        }

		public void AddTextureToListP1P2P3P4P5 (CGPoint inPos, float scale, float rotation, float rotationScale, float alpha, int inSubTextureId)
		{
        }

        public void AddTextureToListXYScaleRotatedAlphaP1P2P3P4P5 (CGPoint inPos, float xScale, float yScale, float rotation, float alpha, int inSubTextureId)
		{
        }

        public void AddRotatedVariableYScaleTextureToListP1P2P3 (CGPoint inPos, float rotation, float yScale, int inSubTextureId)
		{

        }

        public void AddRotatedTextureToListNewP1P2 (CGPoint inPos, float rotation, int inSubTextureId)
		{
        }

        public void AddRotatedScaledTextureToListNewP1P2P3 (CGPoint inPos, float scale, float rotation, int inSubTextureId)
		{
        }

        public void AddRotatedScaledTextureToListNewFlippedHorizontallyP1P2P3 (CGPoint inPos, float scale, float rotation, int inSubTextureId)
		{
        }

        public void AddSliceOfTextureToListP1P2P3 (CGPoint inPos, int inSubTextureId, float slicePercent, float inScale)
		{
        }

        public void AddPixelSliceOfTextureWithXScaleP1P2P3P4 (CGPoint inPos, float xScale, int sliceFrom, int sliceTo, int inSubTextureId)
		{
        }

        public void AddPixelSliceOfTextureP1P2P3 (CGPoint inPos, int sliceFrom, int sliceTo, int inSubTextureId)
		{
        }

        public void AddTextureToListXYScaleP1P2P3 (CGPoint inPos, float xScale, float yScale, int inSubTextureId)
		{
        }

        public void AddTextureToListXYScaleAlphaP1P2P3P4 (CGPoint inPos, float xScale, float yScale, float alpha, int inSubTextureId)
		{
        }

        public void AddTile (int[] verticePositions)
		{
        }

        public void AdjustInPosForIPad(CGPoint inPos)
        {
            if (Globals.deviceIPad) {
                inPos.x *= 2.0f;
                inPos.y *= 2.0f;
                inPos.y = Globals.g_world.tileMapHeight - inPos.y;
            }
            else {
                inPos.y = Globals.g_world.tileMapHeight - inPos.y;
            }

        }

        public void AdjustInPosForIPadHorizontal(CGPoint inPos)
        {
            if (Globals.deviceIPad) {
                inPos.x *= 0.5f;
                inPos.y *= 0.5f;
                inPos.x += 32.0f;
                inPos.y += 64.0f;
            }

        }

				public void AddTextureToListP1 (Billboard inBillboard ,CGPoint inPos, int inSubTextureId,float hangingButtonScale)
		{
//			if (inBillboard.height == 0)
			{
				//No texture yet then...
//				inBillboard.SetDetailsFromAtlas(
			}
						inBillboard.RenderAtPosition(inPos,hangingButtonScale,0.0f,1.0f,inSubTextureId);
		}

        public void AddTextureToListP1 (CGPoint inPos, int inSubTextureId)
		{
//			inBillboard.RenderAtPosition(inPos,1.0f,0.0f,1.0f,inSubTextureId);
		}		
		
        public void AddTextureToListAlphaP1P2 (CGPoint inPos, float alpha, int inSubTextureId)
		{
        }

        public void AddFlippedTextureToListP1P2 (CGPoint inPos, float inAlpha, int inSubTextureId)
		{
        }

        public void Reset()
        {
        }

		public void Flush()
        {
        }

        public void SetDecay(bool decay)
        {
        }

    }
}
