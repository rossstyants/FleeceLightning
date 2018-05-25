using System;

namespace Default.Namespace
{
   
    public enum  ParticleList {
        t_AfterEverything = 0,
        t_BeforePlayer,
        t_WhiteStars,
        t_AdditiveInFrontOfPlayer,
        t_DownInRiver,
        t_Additive,
        Lists
    }
    public class ParticleSystemRoss
    {
		private static ParticleSystemRoss particleSystemInstance;
        public ParticleEffect[] particleEffect = new ParticleEffect[(int)Enum.kMaxParticleEffects];
        public Texture2D_Ross[] texture = new Texture2D_Ross[(int)ParticleTextureType.kNumParticleTextures];
        public Particle[] particle = new Particle[(int)Enum.kMaxParticles];
        public int[] usedListHead = new int[(int)ParticleList.Lists];
        public int freeListHead;
        public int numActiveParticles;
        public int mainAtlas;
        public enum Enum {
            kMaxParticleEffects = 40,
            kMaxParticles = 200
        };
        public struct EffectInfo{
            public EffectType type;
            public CGPoint startPosition;
            public CGPoint velocity;
            public float rotation;
            public Player player;
            public ParticleList inList;
        };
        public int MainAtlas
        {
            get;
            set;
        }

		public void SetMainAtlas (int inThing)
		{
			mainAtlas = inThing;
            for (int i = 0; i < (int)Enum.kMaxParticles; i++) {
                particle[i].SetupAtlasDetails();
            }
		}

        public Texture2D_Ross GetTexture(ParticleTextureType tex)
        {
            return texture[(int)tex];
        }

/*        public void LoadSparkleTexturesP1P2(ParticleTextureType inType, string name, int inNum)
        {
            for (int i = 0; i < inNum; i++) {
                string string1;
                if (i == 0) string1 = String.Format("%@.png", name);
                else string1 = String.Format("%@%d.png", name, i + 1);

                texture[(int)inType + i] = Globals.g_world.LoadTextureP1(true, string1);
            }

        }*/

        public ParticleSystemRoss()
        {
            //if (!base.init()) return null;

            for (int i = 0; i < (int)Enum.kMaxParticleEffects; i++) {
                particleEffect[i] = new ParticleEffect();
            }

            for (int i = 0; i < (int)Enum.kMaxParticles; i++) {
                particle[i] = new Particle();
            }

            this.ResetParticleSystemRoss();
            mainAtlas = (short)AtlasType.kAtlas_ParticlesScene;
            //return this;
        }
        public static ParticleSystemRoss Instance()
        {
            //static ParticleSystemRoss particleSystemInstance = null;
            if (particleSystemInstance == null) {
                particleSystemInstance = new ParticleSystemRoss();
            }

            return particleSystemInstance;
        }

        public void RenderSceneDownLow()
        {
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas(mainAtlas));
            ////glEnableClientState (GL_COLOR_ARRAY);
            int i = usedListHead[(int) ParticleList.t_DownInRiver];
            while (i != -1) {
                (particle[i]).RenderToDrawArrays();
                i = (particle[i]).next;
            }

            (DrawManager.Instance()).Flush();
        }

        public void RenderSceneBeforePlayer()
        {
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas(mainAtlas));
            int i = usedListHead[(int) ParticleList.t_BeforePlayer];
            while (i != -1) {
                (particle[i]).RenderToDrawArrays();
                i = (particle[i]).next;
            }

            (DrawManager.Instance()).Flush();
            //glBlendFunc(GL_ONE, GL_ONE);
            i = usedListHead[(int) ParticleList.t_WhiteStars];
            while (i != -1) {
                (particle[i]).RenderToDrawArrays();
                i = (particle[i]).next;
            }

            (DrawManager.Instance()).Flush();
        }

        public void StopRender()
        {
			for (int i = 0; i < ((int)Enum.kMaxParticles - 1); i++) 
			{
                (particle[i]).StopRender();
            }
		}		
		
        public void RenderScene()
        {
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_RainbowParticles));
            int i = usedListHead[(int) ParticleList.t_AfterEverything];
            while (i != -1) {
                (particle[i]).RenderToDrawArrays();
                i = (particle[i]).next;
            }

            (DrawManager.Instance()).Flush();
            (DrawManager.Instance()).Begin(Globals.g_world.GetAtlas( AtlasType.kAtlas_RainbowParticles));
            //glBlendFunc(GL_ONE, GL_ONE);
            i = usedListHead[(int) ParticleList.t_AdditiveInFrontOfPlayer];
            while (i != -1) {
                (particle[i]).RenderToDrawArrays();
                i = (particle[i]).next;
            }

            (DrawManager.Instance()).Flush();
            //glBlendFunc(GL_ONE, GL_ONE_MINUS_SRC_ALPHA);
        }

        public void StopParticleEffect(int inId)
        {
            (particleEffect[inId]).SetState( EffectState.e_Inactive);
        }

        public void RemovePreExistingEffect_WithPlayer(EffectInfo info)
        {
            for (int i = 0; i < (int)Enum.kMaxParticleEffects; i++) {
                if ((particleEffect[i]).state == EffectState.e_Active) {
                    if ((particleEffect[i]).effectType == info.type) {
                        if ((particleEffect[i]).player == info.player) 
						{
                            (particleEffect[i]).SetState( EffectState.e_Frozen);
                        }

                    }

                }

            }

        }

        public void CheckRemovePreExistingEffect(EffectInfo info)
        {
            switch (info.type) {
            case EffectType.kEffect_RainbowStarTrail :
                this.RemovePreExistingEffect_WithPlayer(info);
                break;
            default :
                break;
            }

        }

        public void AddParticleP1(Particle.ParticleInfo info, ParticleList inList)
        {
            Particle useParticle = (ParticleSystemRoss.Instance()).GetNextFreeParticleP1(inList, "hmm");
            if (particle != null) {
                switch (info.type) {
                case ParticleType.kParticle_WaterSparkle :
                    useParticle.Launch_WaterSparkle(info);
                    break;
                case ParticleType.kParticle_WaterLine :
                    useParticle.Launch_WaterLine(info);
                    break;
                case ParticleType.kParticle_PondBlob :
                    useParticle.Launch_PondBlob(info);
                    break;
                default :
                    Globals.Assert(false);
                    break;
                }

            }

        }

        public int AddParticleEffect(EffectInfo info)
        {
            int useEffect = -1;
            for (int i = 0; i < (int)Enum.kMaxParticleEffects; i++) {
                if ((particleEffect[i]).state == EffectState.e_Inactive) {
                    useEffect = i;
                    break;
                }

            }

            this.CheckRemovePreExistingEffect(info);
            if (useEffect != -1) (particleEffect[useEffect]).StartEffect(info);
            else {
            }

            return useEffect;
        }

        public void UpdateList(ParticleList listType)
        {
            int listHead;
            listHead = usedListHead[(int)listType];
            int i = listHead;
            while (i != -1) {
                bool flagToRemove = false;
                if ((particle[i]).Update()) {
                    flagToRemove = true;
                }

                int prevI = i;
                i = (particle[i]).next;
                if (flagToRemove) {
					particle[prevI].myAtlasBillboard.StopRender();
                    this.RemoveFromListP1(listType, prevI);
                    this.AddToFreeList(prevI);
                }

            }

        }

        public void UpdateParticleSystemRoss()
        {
            for (int i = 0; i < (int)Enum.kMaxParticleEffects; i++) {
                (particleEffect[i]).Update();
            }

            for (int i = 0; i < (int) ParticleList.Lists; i++) {
                this.UpdateList((ParticleList)i);
            }

        }

        public void ResetParticleSystemRoss()
        {
			this.StopRender();
			
            numActiveParticles = 0;
            this.InitialiseLinkedList();
            for (int i = 0; i < (int)Enum.kMaxParticleEffects; i++) {
                (particleEffect[i]).Reset();
            }

            for (int i = 0; i < ((int)Enum.kMaxParticles - 1); i++) {
                (particle[i]).atlas = Globals.g_world.GetAtlas(AtlasType.kAtlas_ParticlesScene);
            }
        }

        public Particle GetNextFreeParticleP1(ParticleList inList, string debugName)
        {
            if (freeListHead == -1) return null;

            int oldHead = freeListHead;
            this.RemoveFromFreeList(oldHead);
            this.AddToListP1(inList, oldHead);
            return particle[oldHead];
        }

        public void InitialiseLinkedList()
        {
            for (int i = 0; i < (int) ParticleList.Lists; i++) {
                usedListHead[i] = -1;
            }

            freeListHead = 0;
            for (int i = 0; i < ((int)Enum.kMaxParticles - 1); i++) {
                (particle[i]).SetNext(i + 1);
            }

            (particle[((int)Enum.kMaxParticles - 1)]).SetNext(-1);
        }

        public void AddToListP1(ParticleList inList, int whichObject)
        {
            numActiveParticles++;
            (particle[whichObject]).SetNext(usedListHead[(int)inList]);
            usedListHead[(int)inList] = whichObject;
        }

        public void RemoveFromListP1(ParticleList listType, int whichObject)
        {
            numActiveParticles--;
            int listHead = usedListHead[(int)listType];
            if (whichObject == listHead) {
                usedListHead[(int)listType] = (particle[whichObject]).next;
                return;
            }

            int item = listHead;
            while ((particle[item]).next != whichObject) {
                item = (particle[item]).next;
            };

            (particle[item]).SetNext((particle[whichObject]).next);
        }

        public void AddToFreeList(int whichObject)
        {
            (particle[whichObject]).SetNext(freeListHead);
            freeListHead = whichObject;
        }

        public void RemoveFromFreeList(int whichObject)
        {
            if (whichObject == freeListHead) {
                freeListHead = (particle[whichObject]).next;
                return;
            }

            int item = freeListHead;
            while ((particle[item]).next != whichObject) {
                item = (particle[item]).next;
            };

            (particle[item]).SetNext((particle[whichObject]).next);
        }

    }
}
