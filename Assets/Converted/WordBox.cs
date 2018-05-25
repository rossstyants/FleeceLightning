using System;

namespace Default.Namespace
{
    public class WordBox
    {
        public CGRect boxDimensions;
        public FunnyWord[] line = new FunnyWord[(int)Enum.kMaxFunnyWords];
        public int numLines;
        public struct WordBoxInfo{
            public CGRect boxDimensions;
            public string inText;
        };
        public enum Enum {
            kMaxFunnyWords = 10
        };

        public WordBox ()
		{
			//if (!base.init()) return null;

			for (int i = 0; i < (int)Enum.kMaxFunnyWords; i++) {
                line[i] = null;
            }

            //return this;
        }
        public void Setup(WordBoxInfo inInfo)
        {
            boxDimensions = inInfo.boxDimensions;
        }

        public void Update()
        {
            for (int i = 0; i < numLines; i++) {
                (line[i]).Update();
            }

        }

        public void Render()
        {
            for (int i = 0; i < numLines; i++) {
                (line[i]).Render();
            }

        }

    }
}
