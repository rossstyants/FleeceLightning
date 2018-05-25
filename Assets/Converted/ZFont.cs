using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

namespace Default.Namespace
{
    public class ZFont
    {
        public Texture2D_Ross[] letter = new Texture2D_Ross[(int)Enum1.kNumLetters];
        public Texture2D_Ross[] letterColour = new Texture2D_Ross[(int)Enum1.kNumLetters];
        public Texture2D_Ross[] digit = new Texture2D_Ross[10];
        public ZAtlas atlas;
        public ccBitmapFontDef[] bitmapFontArray = new ccBitmapFontDef[(int)Enum.kBitmapFontAtlasMaxChars];
        public int commonHeight;
        public ccBitmapFontPadding padding;
        public Dictionary<string,int> kerningDictionary;
        public enum Enum {
            kGermanA = 35,
            kGermanU = 36,
            kGermanO = 37,
            kBitmapFontAtlasMaxChars = 200,
        };
        public struct ccBitmapFontPadding {
            public int left;
            public int top;
            public int right;
            public int bottom;
        };
		//ccBitmapFontPadding
        public struct ccBitmapFontDef {
            public int charID;
            public CGRect rect;
            public int xOffset;
            public int yOffset;
            public int xAdvance;
        };
		//ccBitmapFontDef
        public enum Enum1 {
            kNumLetters = 32,
            kNumDigits = 10
        };
        public ZAtlas Atlas
        {
            get;
            set;
        }

		public void SetAtlas(ZAtlas inThing) {atlas = inThing;}////@property(readwrite,assign) ZAtlas* atlas;


        public ZFont ()
		{
			//if (!base.init()) return null;

			for (int i = 0; i < (int)Enum1.kNumLetters; i++) {
				letter [i] = null;
				letterColour [i] = null;
			}

			for (int i = 0; i < (int)Enum1.kNumDigits; i++) {
                letter[i] = null;
            }

            //return this;
        }
/*        public void SetupDigits (string fontName)
		{
			for (int i = 0; i < (int)Enum1.kNumDigits; i++) {
                string string1 = String.Format("%@%d.png", fontName, i);
                digit[i] = new Texture2D_Ross(true, string1,true);
            }

        }*/

        int ConvertLetter(int asciiLetter)
        {
            if (asciiLetter > 91) {
                return asciiLetter - 97;
            }
            else {
                return asciiLetter - 65;
            }

        }

        public void FiddleWithAscii(int asciiCode)
        {
            if (asciiCode > 96) {
                asciiCode = asciiCode - 32;
            }

        }

        public CGPoint GetDrawOffsetForLetter(int i)
        {
            this.FiddleWithAscii(i);
            CGPoint offset = Utilities.CGPointMake(bitmapFontArray[i].xOffset, bitmapFontArray[i].yOffset);
            offset.y -= 11.0f;
            if (i == 73) {
            }
            else if (i == 79) {
            }
            else if (i == 87) {
            }

            return offset;
        }

        public int GetDistanceBetweenLettersP1 (int frontLetter, int backLetter)
		{
			if ((backLetter >= (int)Enum.kBitmapFontAtlasMaxChars) || (backLetter < 0))
				return 0;
			else if ((frontLetter >= (int)Enum.kBitmapFontAtlasMaxChars) || (frontLetter < 0)) return 0;

            this.FiddleWithAscii(frontLetter);
            this.FiddleWithAscii(backLetter);
            float fOut = (bitmapFontArray[backLetter].rect.Size.Width / 2.0f) + (bitmapFontArray[frontLetter].rect.Size.Width / 2.0f);
            fOut *= 1.0f;
            if ((fOut > 500.0f) || (fOut < -500.0f)) {
                return 0;
            }

            return (int)fOut;
        }

        public void SetupLetters (string fontName)
		{
			for (int i = 0; i < (int)Enum1.kNumLetters; i++) {
                string string1 = String.Format("Font_%d.png", i + 1);
                letter[i] = null;
                string1 = String.Format("FontColour_%d.png", i + 1);
                letterColour[i] = null;
            }

        }

        public Texture2D_Ross GetLetter (int i)
		{
			Globals.Assert (i < (int)Enum1.kNumLetters);
			if (i >= 0)
            return letter[i];
			
			return letter[0];
        }

        public Texture2D_Ross GetNumber (int i)
		{
			Globals.Assert (i < (int)Enum1.kNumDigits);
            return digit[i];
        }

        public Texture2D_Ross GetLetterColour (int i)
		{
			Globals.Assert (i < (int)Enum1.kNumLetters);
			//Globals.Assert (i >= 0);
			////Debug.Log("in i = " + i);
			if (i>=0)
			return letterColour[i];
			
			return letterColour[0];
        }

        public void AddSubtextureToAtlasP1P2P3P4(List<int> inArray, int minx, int miny, int maxx, int maxy)
        {
            inArray.Add(minx);
            inArray.Add(miny);
            inArray.Add(maxx);
            inArray.Add(maxy);
        }

        public void UseFntFileForAtlasP1(string atlasName, World inWorld)
        {
        }

        public void AddGermanLetters()
        {
        }

        public void ParseConfigFile(string fntFile)
        {				
			string fileName = Default.Namespace.Globals.g_main.GetFolderPrefixForTextureResolution() + fntFile + Default.Namespace.Globals.g_main.GetSuffixForTextureResolution();//System.IO.Path.GetFileNameWithoutExtension(fntFile);			
			
			Debug.Log("ParseConfigFile = " + fileName);			
			
			TextAsset asset = Resources.Load(fileName) as TextAsset;
			Stream s = new MemoryStream(asset.bytes);
			StreamReader sr = new StreamReader(s);			
			
//			Resources.Load(
				
//			var sr = new StreamReader(Application.dataPath + "/" + fileName);
    		var fileContents = sr.ReadToEnd();
    		sr.Close();

   			var lines = fileContents.Split("\n"[0]);
    		foreach (string line in lines) 
			{
                if (line.StartsWith("char")) 
				{
//                    ccBitmapFontDef characterDefinition;
  //                  this.ParseCharacterDefinitionCharDef(line, characterDefinition);
                
					ccBitmapFontDef characterDefinition = this.ParseCharacterDefinitionCharDef(line);
					
					bitmapFontArray[characterDefinition.charID] = characterDefinition;//characterDefinition;

				}
			}	
				
				
//            string resourcesPath = ((NSBundle.MainBundle()).ResourcePath()).StringByAppendingPathComponent(fntFile);
//            string contents = NSString.StringWithContentsOfFileEncodingError(resourcesPath, NSUTF8StringEncoding, null);
//            NSArray lines = new NSArray(contents.ComponentsSeparatedByString("\n"));
 //           NSEnumerator nse = lines.ObjectEnumerator();
 /*           string line;
            while ((line = nse.NextObject())) {
                if (line.HasPrefix("info face")) {
                }
                else if (line.HasPrefix("common lineHeight")) {
                    this.ParseCommonArguments(line);
                }
                else if (line.HasPrefix("chars c")) {
                }
                else if (line.HasPrefix("char")) {
                    ccBitmapFontDef characterDefinition;
                    this.ParseCharacterDefinitionCharDef(line, characterDefinition);
                    bitmapFontArray[characterDefinition.CharID] = characterDefinition;
                }
                else if (line.HasPrefix("kernings count")) {
                    this.ParseKerningCapacity(line);
                }
                else if (line.HasPrefix("kerning first")) {
                    this.ParseKerningEntry(line);
                }

            }
			 */
        }

        public void ParseInfoArguments(string line)
        {
/*            NSArray values = line.ComponentsSeparatedByString("=");
            NSEnumerator nse = values.ObjectEnumerator();
            string propertyValue = null;
            nse.NextObject();
            nse.NextObject();
            nse.NextObject();
            nse.NextObject();
            nse.NextObject();
            nse.NextObject();
            nse.NextObject();
            nse.NextObject();
            nse.NextObject();
            nse.NextObject();
            propertyValue = nse.NextObject();
            {
                NSArray paddingValues = propertyValue.ComponentsSeparatedByString(",");
                NSEnumerator paddingEnum = paddingValues.ObjectEnumerator();
                propertyValue = paddingEnum.NextObject();
                padding.Top = propertyValue.IntValue();
                propertyValue = paddingEnum.NextObject();
                padding.Right = propertyValue.IntValue();
                propertyValue = paddingEnum.NextObject();
                padding.Bottom = propertyValue.IntValue();
                propertyValue = paddingEnum.NextObject();
                padding.Left = propertyValue.IntValue();
            }
            nse.NextObject();*/
        }

        public void ParseCommonArguments(string line)
        {/*
            NSArray values = line.ComponentsSeparatedByString("=");
            NSEnumerator nse = values.ObjectEnumerator();
            string propertyValue = null;
            nse.NextObject();
            propertyValue = nse.NextObject();
            commonHeight = propertyValue.IntValue();
            nse.NextObject();
            propertyValue = nse.NextObject();
            NSAssert(propertyValue.IntValue() <= 1024, "BitmapFontAtlas: page can't be larger than 1024x1024");
            propertyValue = nse.NextObject();
            NSAssert(propertyValue.IntValue() <= 1024, "BitmapFontAtlas: page can't be larger than 1024x1024");
            propertyValue = nse.NextObject();
            NSAssert(propertyValue.IntValue() == 1, "BitfontAtlas: only supports 1 page");*/
        }

        public ccBitmapFontDef ParseCharacterDefinitionCharDef (string line) //, ccBitmapFontDef characterDefinition)
		{
			ccBitmapFontDef characterDefinition = new ccBitmapFontDef();
		
			int[] listOfInts = new int[100];
			int listThing = 0;
			
			var values = line.Split("="[0]);
    		foreach (string valString in values) 
			{
//				int start = valString.IndexOf("(");
				int end = valString.IndexOf(" ");	
				if (end > 0)
				{
					string result = valString.Substring(0,end);
					
					if ((result != "char") &&(result != "cha") &&(result != "chars"))
					{
						int ross = Convert.ToInt32(result);
//						int bill = 10+ross;
						listOfInts[listThing++] = ross;
					}
				}
			}
			
			characterDefinition.charID = listOfInts[0];
			characterDefinition.rect.Origin.x = listOfInts[1];
			characterDefinition.rect.Origin.y = listOfInts[2];
			characterDefinition.rect.Size.Width = listOfInts[3];
			characterDefinition.rect.Size.Height = listOfInts[4];
			characterDefinition.xOffset = listOfInts[5];
			characterDefinition.yOffset = listOfInts[6];
			characterDefinition.xAdvance = listOfInts[7];
			
			return characterDefinition;
			
//			NSArray values = line.ComponentsSeparatedByString ("=");
//			NSEnumerator nse = values.ObjectEnumerator ();
//			string propertyValue;
			/*
			nse.NextObject ();
			propertyValue = nse.NextObject ();
			propertyValue = propertyValue.SubstringToIndex (propertyValue.RangeOfString (" ").Location);
			characterDefinition.CharID = propertyValue.IntValue ();
			NSAssert (
				characterDefinition.CharID < (int)Enum.kBitmapFontAtlasMaxChars, "BitmpaFontAtlas: CharID bigger than supported");
            propertyValue = nse.NextObject();
            characterDefinition.Rect.Origin.x = propertyValue.IntValue();
            propertyValue = nse.NextObject();
            characterDefinition.Rect.Origin.y = propertyValue.IntValue();
            propertyValue = nse.NextObject();
            characterDefinition.Rect.Size.Width = propertyValue.IntValue();
            propertyValue = nse.NextObject();
            characterDefinition.Rect.Size.Height = propertyValue.IntValue();
            propertyValue = nse.NextObject();
            characterDefinition.xOffset = propertyValue.IntValue();
            propertyValue = nse.NextObject();
            characterDefinition.yOffset = propertyValue.IntValue();
            propertyValue = nse.NextObject();
            characterDefinition.xAdvance = propertyValue.IntValue();*/
		
        }

        public void ParseKerningCapacity(string line)
        {/*
            NSAssert(!kerningDictionary, "dictionary already initialized");
            NSArray values = line.ComponentsSeparatedByString("=");
            NSEnumerator nse = values.ObjectEnumerator();
            string propertyValue;
            nse.NextObject();
            propertyValue = nse.NextObject();
            int capacity = propertyValue.IntValue();
            if (capacity != -1) kerningDictionary = NSMutableDictionary.DictionaryWithCapacity(propertyValue.IntValue());
*/
        }

        public void ParseKerningEntry(string line)
        {/*
            NSArray values = line.ComponentsSeparatedByString("=");
            NSEnumerator nse = values.ObjectEnumerator();
            string propertyValue;
            nse.NextObject();
            propertyValue = nse.NextObject();
            int first = propertyValue.IntValue();
            propertyValue = nse.NextObject();
            int second = propertyValue.IntValue();
            propertyValue = nse.NextObject();
            int amount = propertyValue.IntValue();
            string key = String.Format("%d,%d", first, second);
            NSNumber value = amount;
            kerningDictionary.SetObjectForKey(value, key);*/
        }

    }
}
