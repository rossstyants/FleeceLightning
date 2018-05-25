using UnityEngine;
using System;

namespace Default.Namespace
{
    public class AppleWon
    {
        public Zobject[] apple = new Zobject[3];
        public int numApples;
        public float timeBetweenApples;

		public struct AppleWonInfo
		{
            public CGPoint position;
            public float timeBetweenApples;
            public float distanceBetweenApples;
            public float appleScale;
            public Texture2D_Ross texture;
            public int soundEffectId;
        };

        public AppleWon()
        {
            ////if (!base.init()) return null;

            for (int i = 0; i < 3; i++) {
                apple[i] = new Zobject();
            }

            ////return this;
        }
        public void Setup(AppleWonInfo info)
        {
            timeBetweenApples = info.timeBetweenApples;
            for (int i = 0; i < 3; i++) {
                Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
                zInfo.texture = info.texture;
                float xPos = (((float) i) * info.distanceBetweenApples);
                zInfo.position = Utilities.CGPointMake(info.position.x + xPos, info.position.y);
                zInfo.isMapObject = false;
                zInfo.startState = ZobjectState.kZobjectHidden;
				//zInfo.texture= null;
				zInfo.mapScrollPosition = Utilities.CGPointMake(0,0);
				
                (apple[i]).Initialise(zInfo);
                (apple[i]).SetShowLagSpeed(0.9f);
                (apple[i]).SetShowStyle(ZobjectShowStyle.kZobjectShow_ZoomAndWobble);
                (apple[i]).SetShowScale(info.appleScale);
               // (apple[i]).SetAtlasAndSubtextureP1(Globals.g_world.GetAtlas(AtlasType.kAtlas_AppleSign),0);
                if (info.soundEffectId != -1) (apple[i]).SetSoundEffectIdAppear((int)info.soundEffectId);
				
				apple[i].myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");

            }
        }

        public void ShowP1(int inNumApples, float delay)
        {
            numApples = (short)inNumApples;
            for (int i = 0; i < numApples; i++) {
                (apple[i]).Disappear();
                (apple[i]).Show();
                (apple[i]).SetWaitToShow(delay + (((float) i) * timeBetweenApples));
            }

        }

        public void Hide()
        {
            for (int i = 0; i < numApples; i++) {
                (apple[i]).Disappear();
            }

        }

        public void Update()
        {
            for (int i = 0; i < numApples; i++) {
                (apple[i]).Update();
            }

        }

        public void Render()
        {
            for (int i = 0; i < numApples; i++) {
//            for (int i = 0; i < 2; i++) {
                (apple[i]).Render();
            }

        }

    }
}
