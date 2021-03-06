using UnityEngine;
using System;

namespace Default.Namespace
{
    public enum  AnotherPiggyType {
        kAP_AnotherPiggy = 0,
        kAP_RaceTip,
        kAP_PreFeelGoodWords,
        ggyTypes
    }
	
		 public enum  Enum {
            kAPMaxNumCommentLines = 5
        };

	
    public class AnotherPiggyScreen
    {
        public AnotherPiggyType type;
//        public Zobject sheepPic;
        public Zobject infoBubbleBackground;
        public FunnyWord[] commentLine = new FunnyWord[(int)Enum.kAPMaxNumCommentLines];
        //public FrontEndButton hangingTip;
        public FrontEndButton doneButton;
        public FrontEndScreen theScreen;
        public float shownTimer;
        public int numCommentLines;
        public int preCommentCounter;
        public int numCommentsInConversation;
        public int whoIsSpeaking;
        public bool returnedTrueOnce;
        public float bubbleRingRotate;
        public float debugScale;
        public CGPoint debugTopLeft;
        public CGPoint debugGridSize;
        public CGPoint debugOffset;
        public struct AnotherPiggyInfo{
            AnotherPiggyType type;
        };
				
        public FrontEndButton DoneButton
        {
            get;
            set;
        }

        public AnotherPiggyType Type
        {
            get;
            set;
        }

        public int PreCommentCounter
        {
            get;
            set;
        }

        public int NumCommentsInConversation
        {
            get;
            set;
        }

        public FrontEndScreen TheScreen
        {
            get;
            set;
        }

public void SetDoneButton(FrontEndButton inThing) {doneButton = inThing;}////@property(readwrite,assign) FrontEndButton* doneButton;
public void SetType(AnotherPiggyType inThing) {type = inThing;}///@property(readwrite,assign) AnotherPiggyType type;
public void SetPreCommentCounter(short inThing) {preCommentCounter = inThing;}///@property(readwrite,assign) int preCommentCounter;
public void SetNumCommentsInConversation(short inThing) {numCommentsInConversation = inThing;}///@property(readwrite,assign) int numCommentsInConversation;
public void SetTheScreen(FrontEndScreen inThing) {theScreen = inThing;}////@property(readwrite,assign) FrontEndScreen* theScreen;

        public AnotherPiggyScreen()
        {
            //if (!base.init()) return null;

//            sheepPic = new Zobject();
            infoBubbleBackground = new Zobject();
            for (int i = 0; i < (int)Enum.kAPMaxNumCommentLines; i++) commentLine[i] = new FunnyWord();

            doneButton = new FrontEndButton(0);
           // hangingTip = null;
            theScreen = null;
            //return this;
        }

		public void OnGUI ()
				{
            for (int i = 0; i < (int)Enum.kAPMaxNumCommentLines; i++) 
				commentLine[i].OnGUI();

			if (theScreen != null)
				theScreen.OnGUI();

				}

        public void InitialiseZobjects ()
		{
			Zobject.ZobjectInfo zInfo = new Zobject.ZobjectInfo() ;
			zInfo.position = Utilities.CGPointMake (160.0f, 225.0f);
			zInfo.texture = (Globals.g_world.game).GetTexture (TextureType.kTexture_BubbleBack);
			zInfo.isMapObject = false;
			zInfo.mapScrollPosition = Utilities.CGPointMake (0, 0);
			zInfo.startState = ZobjectState.kZobjectHidden;
			infoBubbleBackground.Initialise (zInfo);
			infoBubbleBackground.SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			infoBubbleBackground.SetShowScale ((320.0f / 256.0f));
			FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo ();
			bInfo.position = Utilities.CGPointMake (160.0f, 430.0f);
			bInfo.texture = (Globals.g_world.frontEnd).GetButtonTexture ((int)FrontEnd.Enum.kButtonTexture_StartGame);
			bInfo.goToScreen = FrontEndScreenEnum.kFrontEndScreen_Invalid;
			doneButton.Initialise (bInfo);
			(doneButton.zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_SlideInBottom);
			(doneButton.zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_SlideToBottom);
			(doneButton.zobject).SetThrobSize (0.075f);
			(doneButton.zobject).SetThrobTime (0.4f);
			zInfo.texture = (Globals.g_world.game).GetTexture (TextureType.kTextureApple);
			whoIsSpeaking = (short)PlayerType.kPlayerSheep;
			int feelGoodProgress = ((Globals.g_world.frontEnd).profile).profileInfo.feelGoodProgress;
			if (feelGoodProgress <= (int)Profile.Enum5.kFeelGoodProgress_WelcomeToStarCup) {
				whoIsSpeaking = (short)PlayerType.kPlayerPig;
			} else if ((feelGoodProgress >= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainDesert) && (feelGoodProgress <= (int)Profile.Enum5.kFeelGoodProgress_UnlockedTerrainMoon)) {
				whoIsSpeaking = (short)PlayerType.kPlayerPig;
			}

			if ((int)type == (int)AnotherPiggyType.kAP_AnotherPiggy) {
				whoIsSpeaking = (short)PlayerType.kPlayerPig;
				zInfo.position = Utilities.CGPointMake (160.0f, 285.0f);
			} else if ((int)type == (int)(AnotherPiggyType.kAP_PreFeelGoodWords)) {
				if (whoIsSpeaking == (int)PlayerType.kPlayerPig) {
					zInfo.position = Utilities.CGPointMake (250.0f, 300.0f);
					if ((((Globals.g_world.frontEnd).profile).selectedLevel == ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) || 
						(((Globals.g_world.frontEnd).profile).selectedLevel == (((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) + 1))) {
						zInfo.position = Utilities.CGPointMake (253.0f, 273.0f);
					}

				} else {
					zInfo.position = Utilities.CGPointMake (100.0f, 300.0f);
				}

			} else {
				whoIsSpeaking = (short)PlayerType.kPlayerPig;
				zInfo.position = Utilities.CGPointMake (160.0f, 445.0f);
				if ((((Globals.g_world.frontEnd).profile).selectedLevel == ((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup)) || (((Globals.g_world.frontEnd).profile).selectedLevel ==
					(((int)Profile.Enum4.kNumCups * (int)Profile.Enum6.kNumLevelsPerCup) + 1))) {
					zInfo.position = Utilities.CGPointMake (253.0f, 273.0f);
				}

			}

			zInfo.texture = null;
			/*sheepPic.Initialise (zInfo);
			sheepPic.SetAtlas (Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip));
			sheepPic.SetSubTextureId ((int)World.Enum6.kSSH_Piggy);
			if ((int)type == (int)AnotherPiggyType.kAP_AnotherPiggy)
				sheepPic.SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_FadeIn);
			else if ((int)type == (int)AnotherPiggyType.kAP_PreFeelGoodWords) {
				if (whoIsSpeaking == (int)PlayerType.kPlayerPig)
					sheepPic.SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_SlideInRight);
				else
					sheepPic.SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_SlideInLeft);

			} else {
				if (whoIsSpeaking == (int)PlayerType.kPlayerPig)
					sheepPic.SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
				else
					sheepPic.SetShowStyle ((int) ZobjectShowStyle.kZobjectShow_Immediate);

            }*/

        }


        public void SetAnotherPiggyWords()
        {
            float yStart = 62.0f;
            float yPlus = 44.0f;
            FunnyWord.WordInfo wInfo;
            wInfo.position = Utilities.CGPointMake(160.0f, yStart);
            wInfo.scale = 0.55f;
            wInfo.isCentrePos = true;
            string inWord = "watch out!\n";
            (commentLine[0]).InitWithWordP1(wInfo, inWord);
            yStart += yPlus;
            wInfo.position = Utilities.CGPointMake(160.0f, yStart);
            inWord = "another piggy has\n";
            (commentLine[1]).InitWithWordP1(wInfo, inWord);
            yStart += yPlus;
            wInfo.position = Utilities.CGPointMake(160.0f, yStart);
            inWord = "joined the race!\n";
            (commentLine[2]).InitWithWordP1(wInfo, inWord);
        }

        public string GetPreCommentLine(int whichLine)
        {
            return "aaa";
        }

        public string GetTipLineP1 (int whichLine, int inPlayingLevel)
		{
			string line1 = "\n";
			string line2 = "\n";
			string line3 = "\n";
			string line4 = "\n";
			string line5 = "\n";
			int levelRealId = LevelBuilder_Ross.levelOrder [inPlayingLevel];
			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
				switch (levelRealId) {
				case 206:
					line1 = "use the ramp\n";
					line2 = "to jump over\n";
					line3 = "the river!\n";
					break;
				case 204:
					line1 = "don't get tripped\n";
					line2 = "up!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge:
					line1 = "Nicht auf\n";
					line2 = "die K%rbisse\n";
					line3 = "treten!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips:
					line1 = "Rutsch nicht\n";
					line2 = "in den\n";
					line3 = "Schlammpf%tzen aus!\n";
					break;
				case 202:
					line1 = "try to stay on\n";
					line2 = "the bridge!\n";
					break;
				case 211:
					line1 = "Folge den Pfeilen\n";
					line2 = "und weiche den\n";
					line3 = "Scheunen aus!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers:
					line1 = "Versuche auf\n";
					line2 = "dem Schuppendach\n";
					line3 = "zu bleiben!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines:
					line1 = "Hol dir die\n";
					line2 = "Picknickdecke f%r\n";
					line3 = "einen Superschub!\n";
					break;
				case 209:
					line1 = "Bleib bis zum\n";
					line2 = "Ende auf\n";
					line3 = "dem Dach!\n";
					break;
				case 213:
					line1 = "get the roof\n";
					line2 = "rainbow if you\n";
					line3 = "can!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles:
					line1 = "Auf Trampolinen\n";
					line2 = "kann\n";
					line3 = "man h%pfen!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage:
					line1 = "Hol dir den Schub\n";
					line2 = "auf dem Dach\n";
					line3 = "wenn du's drauf hast!\n";
					break;
				case 212:
					line1 = "Lass dich\n";
					line2 = "nicht\n";
					line3 = "ablenkern!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne:
					line1 = "ICH WETTE\n";
					line2 = "ICH BIN SCHNELLER\n";
					line3 = "DURCH DIE TORE!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo:
					line1 = "VERGISS\n";
					line2 = "NICHT\n";
					line3 = "AUSZUWEICHEN!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks:
					line1 = "VERPASS NICHT\n";
					line2 = "DIE BR%CKE, SONST\n";
					line3 = "WIRD'S NASS!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail:
					line1 = "TRIFF DIE \n";
					line2 = "SAUSESCH%BE\n";
					line3 = "UM LOSZUSAUSEN!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes:
					line1 = "BLEIB NICHT\n";
					line2 = "IN DEN HECKEN\n";
					line3 = "STECKEN!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly:
					line1 = "Finde den\n";
					line2 = "Schub\n";
					line3 = "im Geb%sch!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard:
					line1 = "Versuche\n";
					line2 = "die Spr%nge schr#g\n";
					line3 = "auszuf%hren!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow:
					line1 = "Hier gibt's \n";
					line2 = "ein paar\n";
					line3 = "fiese Spr%nge!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville:
					line1 = "Diese Stadt ist\n";
					line2 = "nicht grunz genug\n";
					line3 = "f%r uns Beide!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop:
					line1 = "Zeit\n";
					line2 = "f%r's\n";
					line3 = "Schafsbad!\n";
					break;
				default :
					line1 = "\n";
					break;
				}

			} else {
				switch (levelRealId) {
				case 206:
					line1 = "use the ramp\n";
					line2 = "to jump over\n";
					line3 = "the river!\n";
					break;
				case 204:
					line1 = "don't get tripped\n";
					line2 = "up!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge:
					line1 = "don't put\n";
					line2 = "your foot in\n";
					line3 = "a marrow!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips:
					line1 = "muddy puddles\n";
					line2 = "make you\n";
					line3 = "slip!\n";
					break;
				case 202:
					line1 = "try to stay on\n";
					line2 = "the bridge!\n";
					break;
				case 211:
					line1 = "follow the arrows\n";
					line2 = "and dodge the\n";
					line3 = "barns!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers:
					line1 = "try to stay\n";
					line2 = "on the shed\n";
					line3 = "roof!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines:
					line1 = "get the\n";
					line2 = "super boost\n";
					line3 = "picnic blanket!\n";
					break;
				case 209:
					line1 = "stay on the\n";
					line2 = "roof 'til\n";
					line3 = "the end!\n";
					break;
				case 213:
					line1 = "get the roof\n";
					line2 = "rainbow if you\n";
					line3 = "can!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles:
					line1 = "trampolines\n";
					line2 = "are\n";
					line3 = "bouncy!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage:
					line1 = "get the boost\n";
					line2 = "on the roof\n";
					line3 = "if you can!\n";
					break;
				case 212:
					line1 = "don't get\n";
					line2 = "dis'tractored!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne:
					line1 = "bet you can't\n";
					line2 = "beat me through\n";
					line3 = "the gates!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo:
					line1 = "don't forget\n";
					line2 = "to\n";
					line3 = "dodge!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks:
					line1 = "don't miss the\n";
					line2 = "bridge or you'll\n";
					line3 = "get wet!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail:
					line1 = "hit the speed\n";
					line2 = "boost for some\n";
					line3 = "real speed!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes:
					line1 = "don't get\n";
					line2 = "stuck in a\n";
					line3 = "hedge!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly:
					line1 = "find the boost\n";
					line2 = "hidden in the\n";
					line3 = "bushes!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard:
					line1 = "take the jumps\n";
					line2 = "at an angle\n";
					line3 = "if you can!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow:
					line1 = "there are some\n";
					line2 = "tricky jumps\n";
					line3 = "in this one!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville:
					line1 = "this town ain't\n";
					line2 = "pig enough for the\n";
					line3 = "both of us!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop:
					line1 = "it's\n";
					line2 = "time for your\n";
					line3 = "sheep dip!\n";
					break;
				default :
					line1 = "\n";
					break;
				}

			}

			string outString = "";

			switch (whichLine) {
			case 0:
				outString = line1;
				break;
			case 1:
				outString = line2;
				break;
			case 2:
				outString = line3;
				break;
			case 3:
				outString = line4;
				break;
			case 4:
				outString = line5;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            return outString;
        }

        string GetTipLineChineseP1 (int whichLine, int inPlayingLevel)
		{
			string line1 = "";
			string line2 = "";
			string line3 = "";
			string line4 = "";
			string line5 = "";
			int levelRealId = LevelBuilder_Ross.levelOrder [inPlayingLevel];
			switch (levelRealId) {
			case 206:
				line1 = "use the ramp";
				line2 = "to jump over";
				line3 = "the river!";
				break;
			case 204:
				line1 = "don't get tripped";
				line2 = "up!";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge:
				line1 = "不要踩";
				line2 = "到葫芦！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips:
				line1 = "泥水坑让";
				line2 = "你打滑！";
				break;
			case 202:
				line1 = "try to stay on";
				line2 = "the bridge!";
				break;
			case 211:
				line1 = "跟着箭头并";
				line2 = "躲避谷仓！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers:
				line1 = "试着留在";
				line2 = "棚顶上！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines:
				line1 = "获得加速";
				line2 = "器野餐毯！";
				break;
			case 209:
				line1 = "留在屋顶上";
				line2 = "直到结束！";
				break;
			case 213:
				line1 = "get the roof";
				line2 = "rainbow if you";
				line3 = "can!";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles:
				line1 = "蹦床可以反弹！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage:
				line1 = "如果可以，在屋";
				line2 = "顶上获得加速器！";
				break;
			case 212:
				line1 = "注意力不要被";
				line2 = "拖拉机拉走了！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne:
				line1 = "打赌过门";
				line2 = "你赢不了我";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo:
				line1 = "别忘了";
				line2 = "躲避！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks:
				line1 = "别错过桥否";
				line2 = "则你会弄湿！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail:
				line1 = "撞到加速器来";
				line2 = "获得真正的速度！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes:
				line1 = "别被篱";
				line2 = "笆夹住了！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly:
				line1 = "在灌木丛里找";
				line2 = "到加速器！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard:
				line1 = "如果可以，";
				line2 = "以特定角度起跳！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow:
				line1 = "这儿有些";
				line2 = "狡猾的障碍。";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville:
				line1 = "这个小镇不能同";
				line2 = "时容下我们两个！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop:
				line1 = "是时候浸湿";
				line2 = "你的羊了";
				break;
			default :
				line1 = "";
				break;
			}

			string outString = "";

			switch (whichLine) {
			case 0:
					outString = line1;
					break;
			case 1:
				outString = line2;
				break;
			case 2:
				outString = line3;
				break;
			case 3:
				outString = line4;
				break;
			case 4:
				outString = line5;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            return outString;
        }

        string GetTipLineJapaneseP1 (int whichLine, int inPlayingLevel)
		{
			string line1 = "";
			string line2 = "";
			string line3 = "";
			string line4 = "";
			string line5 = "";
			int levelRealId = LevelBuilder_Ross.levelOrder [inPlayingLevel];
			switch (levelRealId) {
			case 206:
				line1 = "use the ramp";
				line2 = "to jump over";
				line3 = "the river!";
				break;
			case 204:
				line1 = "don't get tripped";
				line2 = "up!";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge:
				line1 = "ペポカボチ";
				line2 = "ャを踏まな";
				line3 = "いように！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips:
				line1 = "泥溜まりはス";
				line2 = "ピンしやすいぞ！";
				break;
			case 202:
				line1 = "try to stay on";
				line2 = "the bridge!";
				break;
			case 211:
				line1 = "矢印に従って";
				line2 = "小屋を避けろ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers:
				line1 = "差し掛け屋根";
				line2 = "の下にいるんだ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines:
				line1 = "ピクニック・ブラ";
				line2 = "ンケットでスーパ";
				line3 = "ーブーストだ！";
				break;
			case 209:
				line1 = "最後まで屋根";
				line2 = "の上にいるんだ！";
				break;
			case 213:
				line1 = "屋根の上のブース";
				line2 = "トをとってみろ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles:
				line1 = "トランポリンは";
				line2 = "弾み易いぞ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage:
				line1 = "屋根の上の";
				line2 = "ブーストをと";
				line3 = "ってみろ！";
				break;
			case 212:
				line1 = "トラクターに";
				line2 = "邪魔されるな！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne:
				line1 = "ゲートを通って";
				line2 = "ちゃ俺には勝てな";
				line3 = "いと思うぜ？";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo:
				line1 = "回避するの！";
				line2 = "を忘れるな！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks:
				line1 = "橋をしっかり渡";
				line2 = "れ！濡れちゃうぞ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail:
				line1 = "スピードブース";
				line2 = "とで加速するんだ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes:
				line1 = "囲いに捕";
				line2 = "まるな！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly:
				line1 = "茂みの中のブ";
				line2 = "ーストを探せ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard:
				line1 = "角度をつけて";
				line2 = "ジャンプしてみろ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow:
				line1 = "トリッキーなジ";
				line2 = "ャンプがあるぞ";
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville:
				line1 = "俺達にとって";
				line2 = "この街は小さ";
				line3 = "すぎるぜ！";
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop:
				line1 = "羊を濡らす時";
				line2 = "が来たようだ";
				break;
			default :
				line1 = "";
				break;
			}

			string outString = "";

			switch (whichLine) {
			case 0:
				outString = line1;
				break;
			case 1:
				outString = line2;
				break;
			case 2:
				outString = line3;
				break;
			case 3:
				outString = line4;
				break;
			case 4:
				outString = line5;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            return outString;
        }
		
		        string GetTipLineFrench (int whichLine, int inPlayingLevel)
		{
			string line1 = "";
			string line2 = "";
			string line3 = "";
			string line4 = "";
			string line5 = "";
			int levelRealId = LevelBuilder_Ross.levelOrder [inPlayingLevel];
			switch (levelRealId) {
				case 206:
					line1 = "use the ramp\n";
					line2 = "to jump over\n";
					line3 = "the river!\n";
					break;
				case 204:
					line1 = "don't get tripped\n";
					line2 = "up!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge:
					line1 = "ne marchez pas";
					line2 = "sur une";
					line3 = "courgette !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips:
					line1 = "les flaques";
					line2 = "de boue,";
					line3 = "ça glisse!";
					break;
				case 202:
					line1 = "try to stay on\n";
					line2 = "the bridge!\n";
					break;
				case 211:
					line1 = "suivez les flèches";
					line2 = "et évitez";
					line3 = "les granges !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers:
					line1 = "restez sur";
					line2 = "le toit";
					line3 = "de l’abri !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines:
					line1 = "visez le";
					line2 = "super bonus :";
					line3 = "la couverture !";
					break;
				case 209:
					line1 = "restez sur";
					line2 = "les toits";
					line3 = "jusqu’au bout !";
					break;
				case 213:
					line1 = "get the roof\n";
					line2 = "rainbow if you\n";
					line3 = "can!\n";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles:
					line1 = "les trampolines,";
					line2 = "ça";
					line3 = "rebondit!";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage:
					line1 = "visez le bonus";
					line2 = "sur le toit";
					line3 = "si vous pouvez !";
					break;
				case 212:
					line1 = "ne vous laissez";
					line2 = "pas dis-tracteur !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne:
					line1 = "je parie que";
					line2 = "vous ne pourrez pas";
					line3 = "me battre !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo:
					line1 = "n’oubliez pas";
					line2 = "d’éviter";
					line3 = "les obstacles !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks:
					line1 = "ne ratez pas";
					line2 = "le pont,";
					line3 = "ça mouille !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail:
					line1 = "visez le bonus";
					line2 = "de vitesse,";
					line3 = "croyez-moi !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes:
					line1 = "ne foncez pas";
					line2 = "dans une";
					line3 = "haie!";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly:
					line1 = "trouvez le";
					line2 = "bonus dans";
					line3 = "les buissons !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard:
					line1 = "sautez";
					line2 = "de côté";
					line3 = "si possible !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow:
					line1 = "certains sauts";
					line2 = "sont";
					line3 = "costauds !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville:
					line1 = "pas de place";
					line2 = "pour les porcs";
					line3 = "ici !";
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop:
					line1 = "c’est l’heure";
					line2 = "faire tourner";
					line3 = "le tambour !";
					break;
				default :
					line1 = "\n";
					break;
				}

			
			string outString = "";

			switch (whichLine) {
			case 0:
				outString = line1;
				break;
			case 1:
				outString = line2;
				break;
			case 2:
				outString = line3;
				break;
			case 3:
				outString = line4;
				break;
			case 4:
				outString = line5;
                break;
            default :
                Globals.Assert(false);
                break;
            }

            return outString;
        }

        float GetTipLineScaleP1 (int whichLine, int inPlayingLevel)
		{
			int levelRealId = LevelBuilder_Ross.levelOrder [inPlayingLevel];
			float[] lineScale = new float[5];
			for (int i = 0; i < 5; i++) {
				lineScale [i] = -1.0f;
			}

			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
				switch (levelRealId) {
				case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne:
					lineScale [1] = 0.42f;
					break;
				case 206:
					break;
				case 204:
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge:
					lineScale [0] = 0.48f;
					lineScale [1] = 0.6f;
					lineScale [2] = 0.46f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips:
					lineScale [0] = 0.58f;
					lineScale [1] = 0.48f;
					lineScale [2] = 0.4f;
					break;
				case 202:
					break;
				case 215:
					break;
				case 211:
					lineScale [0] = 0.44f;
					lineScale [1] = 0.48f;
					lineScale [2] = 0.56f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers:
					lineScale [1] = 0.44f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines:
					lineScale [0] = 0.5f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.42f;
					break;
				case 209:
					lineScale [0] = 0.48f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.58f;
					break;
				case 213:
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles:
					lineScale [0] = 0.44f;
					lineScale [1] = 0.44f;
					lineScale [2] = 0.58f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage:
					lineScale [0] = 0.44f;
					lineScale [1] = 0.56f;
					lineScale [2] = 0.39f;
					break;
				case 212:
					lineScale [1] = 0.56f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo:
					lineScale [0] = 0.6f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.46f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.6f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail:
					lineScale [0] = 0.47f;
					lineScale [1] = 0.55f;
					lineScale [2] = 0.44f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes:
					lineScale [0] = 0.48f;
					lineScale [1] = 0.48f;
					lineScale [2] = 0.56f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.6f;
					lineScale [2] = 0.5f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard:
					lineScale [0] = 0.56f;
					lineScale [1] = 0.44f;
					lineScale [2] = 0.5f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.56f;
					lineScale [2] = 0.46f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.4f;
					lineScale [2] = 0.54f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop:
					lineScale [0] = 0.5f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.6f;
					break;
				default :
					break;
				}

			} else {
				switch (levelRealId) {
				case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne:
					lineScale [1] = 0.42f;
					break;
				case 206:
					break;
				case 204:
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge:
					lineScale [0] = 0.44f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.54f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips:
					lineScale [0] = 0.44f;
					lineScale [1] = 0.48f;
					lineScale [2] = 0.56f;
					break;
				case 202:
					break;
				case 215:
					break;
				case 211:
					lineScale [0] = 0.4f;
					lineScale [1] = 0.48f;
					lineScale [2] = 0.56f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers:
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines:
					lineScale [0] = 0.44f;
					lineScale [1] = 0.56f;
					lineScale [2] = 0.46f;
					break;
				case 209:
					lineScale [0] = 0.48f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.58f;
					break;
				case 213:
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles:
					lineScale [0] = 0.44f;
					lineScale [1] = 0.44f;
					lineScale [2] = 0.58f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage:
					lineScale [0] = 0.44f;
					lineScale [1] = 0.56f;
					lineScale [2] = 0.46f;
					break;
				case 212:
					lineScale [1] = 0.56f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.6f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.46f;
					lineScale [2] = 0.6f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail:
					lineScale [0] = 0.45f;
					lineScale [1] = 0.45f;
					lineScale [2] = 0.54f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes:
					lineScale [0] = 0.48f;
					lineScale [1] = 0.48f;
					lineScale [2] = 0.56f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.52f;
					lineScale [2] = 0.56f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.56f;
					lineScale [2] = 0.46f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.56f;
					lineScale [2] = 0.46f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kMud6_7_StrCup_Race7_trottville:
					lineScale [0] = 0.46f;
					lineScale [1] = 0.4f;
					lineScale [2] = 0.54f;
					break;
				case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop :
                    lineScale[0] = 0.42f;
                    lineScale[1] = 0.42f;
                    lineScale[2] = 0.6f;
                    break;
                default :
                    break;
                }

            }

            return lineScale[whichLine];
        }

        public void HandleTap(CGPoint position)
        {
            theScreen.HandleTap(position);
        }

        public void SetRaceTipWords ()
		{
			float yStart = 190.0f;
			float yPlus = 22.0f;
			FunnyWord.WordInfo wInfo;
			wInfo.position = Utilities.CGPointMake (160.0f, yStart);
			wInfo.scale = 0.52f;
			wInfo.isCentrePos = true;
			string[] inNSString = new string[5];
			string[] inWord = new string[5];
			float[] newScale = new float[5];
			for (int i = 0; i < 5; i++) {
				newScale [i] = 0.52f;
			}

			if ((int)type == (int) AnotherPiggyType.kAP_RaceTip) {
                int whichLevel = ((Globals.g_world.frontEnd).profile).selectedLevel;
                for (int i = 0; i < 5; i++) {
                    if (Globals.g_currentLanguage == World.Enum11.kLanguage_China) {
                        inNSString[i] = this.GetTipLineChineseP1(i, whichLevel);
                    }
                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                        inNSString[i] = this.GetTipLineJapaneseP1(i, whichLevel);
                    }
                    else if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
                        inNSString[i] = this.GetTipLineFrench(i, whichLevel);
                    }
                    else {
                        inWord[i] = this.GetTipLineP1(i, whichLevel);
                    }

                }

                for (int i = 0; i < 5; i++) {
                    float tempScale = this.GetTipLineScaleP1(i, whichLevel);
                    if (tempScale > 0.0f) {
                        newScale[i] = tempScale;
                    }

                    if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
                        if ((whichLevel == 25) || (whichLevel == 79) || (whichLevel == 0)) {
                            newScale[i] *= 0.85f;
                        }

                    }

                }

            }
            else {
            }

            int numLines = 0;
            if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                for (int i = 0; i < 5; i++) 
				{
                    if ((inNSString[i]) != ("")) {
                        numLines++;
                    }

                }

                if (numLines == 1) {
                    yStart = 212.0f;
                }
                else if (numLines == 2) {
                    yStart = 194.0f;
                    yPlus = 34.0f;
                }

            }

            for (int i = 0; i < 5; i++) {
                wInfo.position = Utilities.CGPointMake(160.0f, yStart);
                wInfo.scale = newScale[i];
                if (Globals.g_world.DoesCurrentLanguageUseNSString()) {
                    if (numLines == 1) {
                        wInfo.scale *= 1.1f;
                    }
                    else {
                        wInfo.scale *= 0.92f;
                    }

                    (commentLine[i]).InitWithWordNewP1(wInfo, inNSString[i]);
                }
                else {
                    (commentLine[i]).InitWithWordP1(wInfo, inWord[i]);
                }

                yStart += yPlus;
            }

        }

        public void SetTypeVariables()
        {
            for (int i = 0; i < (int)Enum.kAPMaxNumCommentLines; i++) {
                (commentLine[i]).SetFont(Globals.g_world.font);
                (commentLine[i]).SetColour(Constants.kColourRed);
                (commentLine[i]).SetTimeToShowSpeed(0.0f);
            }

            switch (type) {
            case AnotherPiggyType.kAP_AnotherPiggy :
                numCommentLines = 3;
                this.SetAnotherPiggyWords();
                break;
            case AnotherPiggyType.kAP_RaceTip :
            case AnotherPiggyType.kAP_PreFeelGoodWords :
                numCommentLines = 5;
                this.SetRaceTipWords();
                break;
            default :
                Globals.Assert(false);
                break;
            }

        }
		
		public void DeallocTipOrAnotherPiggyScreen()
        {
			if (theScreen != null) 				
				Debug.Log("Dealloc AnotherPiggy " + theScreen.ToString());			
			else
				Debug.Log("Dealloc AnotherPiggy_");			
			
			if (theScreen != null) {
				theScreen.Dealloc();
				theScreen = null;
			}
		}		


        public void SetupTipScreen ()
		{
			if (theScreen != null)
				Debug.Log("SetupTipScreen " + theScreen.ToString());
			else
				Debug.Log("SetupTipScreen_");
			
			if (theScreen == null) 
			{
				theScreen = new FrontEndScreen (0, Globals.g_world.frontEnd);

				Debug.Log("Vreate " + theScreen.ToString());			
			}

			theScreen.SetBackScreen ((Globals.g_world.frontEnd).GetButtonTexture ((int)FrontEnd.Enum.kButtonTexture_MenuBackGround));
			FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo ();
			bInfo.texture = null;
			bInfo.position = Utilities.CGPointMake (160.0f, 337.0f);
			int buttId = theScreen.AddButton (bInfo);
			(theScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip),
				Globals.g_world.GetSubTextLanguageP1 ((int)AtlasType.kAtlas_ShowLevelAndTip, (int)World.Enum6.kSSH_PlaySign)
			);
			((theScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((theScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
			hInfo.showWobbleMultiplier = 2.0f;
			hInfo.type = HangingButtonType.kHB_Rope;
			hInfo.subTextureId = (int)World.Enum6.kSSH_Rope;
			hInfo.offset = Utilities.CGPointMake (0.1f, -10.0f);
			(theScreen.GetButton (buttId)).AddHangingButton (hInfo);
			if (Globals.g_world.DoesCurrentLanguageUseNSString ()) {
				FrontEndScreen.AddFunnyWordInfo fInfo;
				fInfo.inString = Globals.g_world.GetNSString (StringId.kString_Play);
				fInfo.position = bInfo.position;
				fInfo.position.y -= 2.0f;
				fInfo.scale = 0.25f;
				
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French)
				{
					fInfo.scale = 0.45f;
				}				
				
				int fwId = theScreen.AddFunnyWord (fInfo);
				(theScreen.GetFunnyWord (fwId)).SetColour (Constants.kBrown_FleeceMenu);
				(theScreen.GetFunnyWord (fwId)).SetShowStyleNew ((int)ZobjectShowStyle.kZobjectShow_Immediate);
				(theScreen.GetFunnyWord (fwId)).SetPositionButton (theScreen.GetButton (buttId));
				(theScreen.GetFunnyWord (fwId)).SetOrientationButton ((theScreen.GetButton (buttId)).hangingButton);
			}

			bInfo.position = Utilities.CGPointMake (160.0f, 155.0f);
			buttId = theScreen.AddButton (bInfo);
			(theScreen.GetButton (buttId)).SetIsClickable (false);
			(theScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip),
				(int)World.Enum6.kSSH_TipSign
			);
			((theScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((theScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			hInfo.subTextureId = (int)World.Enum6.kSSH_Rope;
			hInfo.type = HangingButtonType.kHB_Chain;
			hInfo.offset = Utilities.CGPointMake (90.0f, -80.0f);
			hInfo.showWobbleMultiplier = 0.4f;
			(theScreen.GetButton (buttId)).AddHangingButton (hInfo);
			bInfo.position = Utilities.CGPointMake (160.0f, 427.0f);
			if (Globals.deviceIPad) {
				bInfo.position.y += 30.0f;
			}

			buttId = theScreen.AddButton (bInfo);
			(theScreen.GetButton (buttId)).SetIsClickable (false);
			(theScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip),
				(int)World.Enum6.kSSH_Piggy);
			((theScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_SlideInBottom);
			((theScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			bInfo.position = Utilities.CGPointMake (160.0f, Globals.g_world.frontEnd.kChooseTrackBackBarTopPosY);
			buttId = theScreen.AddButton (bInfo);
			(theScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip), Globals.g_world.GetIPadSubTexture (
              (int)World.Enum6.kSSH_BackBar)
			);
			((theScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((theScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			bInfo.position = Utilities.CGPointMake (
				(Globals.g_world.frontEnd).xBackButton,
				Globals.g_world.frontEnd.kChooseTrackBackBarTopPosY - 1.0f);
			bInfo.texture = null;
			buttId = theScreen.AddButton (bInfo);
			(theScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_ShowLevelAndTip),
				Globals.g_world.GetBackST ()
			);
			((theScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((theScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			Globals.g_world.AddBackWordsP1 (theScreen, buttId);
			float kWordScale = 1.0f;
			string inString = "";
			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
				inString = "Tipp\n";
				kWordScale = 0.72f;
			} else {
				inString = "Tip\n";
				kWordScale = 0.8f;
			}

			CGPoint wordPos = Utilities.CGPointMake (92.0f, 64.0f);
			int fwId2;
			if (Globals.g_world.DoesCurrentLanguageUseNSString ()) {
				FrontEndScreen.AddFunnyWordInfo fInfo;
				fInfo.inString = Globals.g_world.GetNSString (StringId.kString_Tip);
				fInfo.position = wordPos;
				fInfo.position.x -= 9.0f;
				fInfo.scale = kWordScale * 0.5f;
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_Japanese) {
					fInfo.scale = kWordScale * 0.43f;
				}
				if (Globals.g_currentLanguage == World.Enum11.kLanguage_French) {
					fInfo.scale = kWordScale * 0.45f;
					//fInfo.position.y -= 4.0f;
				}

				fwId2 = theScreen.AddFunnyWord (fInfo);
				(theScreen.GetFunnyWord (fwId2)).SetColour (Constants.kColourRedTip);
			} else {
				fwId2 = theScreen.AddFunnyWordP1P2P3P4P5P6P7 (
					Globals.g_world.font,
					Globals.g_world.GetAtlas (AtlasType.kAtlas_FontLines),
					Globals.g_world.GetAtlas (AtlasType.kAtlas_FontColours),
					wordPos,
					kWordScale,
					inString,
					true,
					Constants.kColourRedTip
				);
			}

			(theScreen.GetFunnyWord (fwId2)).SetRotationWholeWord (0.125f);
			(theScreen.GetFunnyWord (fwId2)).SetShowStyle ( FunnyWordShowStyle.kFunnyWordShow_Immediate);
        }

        public void SetupAnotherPiggyScreen ()
		{
			if (theScreen == null) 
			{
				theScreen = new FrontEndScreen (0, Globals.g_world.frontEnd);
			}

			theScreen.SetBackScreen ((Globals.g_world.frontEnd).GetButtonTexture ((int)FrontEnd.Enum.kButtonTexture_MenuBackGround));
			FrontEnd.ButtonInfo bInfo = new FrontEnd.ButtonInfo ();
			bInfo.texture = null;
			bInfo.position = Utilities.CGPointMake (160.0f, 337.0f);
			int buttId = theScreen.AddButton (bInfo);
			(theScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_AnotherPiggy),
				(int)World.Enum8.kAN_PlaySign
			);
			((theScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((theScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			HangingButton.HangingButtonInfo hInfo = new HangingButton.HangingButtonInfo();
			hInfo.showWobbleMultiplier = 2.0f;
			hInfo.type = HangingButtonType.kHB_Rope;
			hInfo.subTextureId = (int)World.Enum8.kAN_Rope;
			hInfo.offset = Utilities.CGPointMake (0.1f, -10.0f);
			(theScreen.GetButton (buttId)).AddHangingButton (hInfo);
			bInfo.position = Utilities.CGPointMake (160.0f, 155.0f);
			buttId = theScreen.AddButton (bInfo);
			int bigButt = buttId;
			(theScreen.GetButton (buttId)).SetIsClickable (false);
			(theScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_AnotherPiggy),
				(int)World.Enum8.kAN_Pig
			);
			((theScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((theScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			hInfo.offset = Utilities.CGPointMake (87.0f, -122.0f);
			hInfo.showWobbleMultiplier = 0.4f;
			(theScreen.GetButton (buttId)).AddHangingButton (hInfo);
			bInfo.position = Utilities.CGPointMake (160.0f, 449.0f);
			if (Globals.deviceIPad) {
				bInfo.position.y += 32.0f;
			}

			buttId = theScreen.AddButton (bInfo);
			(theScreen.GetButton (buttId)).SetIsClickable (false);
			(theScreen.GetButton (buttId)).SetAtlasAndSubtextureP1 (
				Globals.g_world.GetAtlas (AtlasType.kAtlas_AnotherPiggy),
				(int)World.Enum8.kAN_Hedge
			);
			((theScreen.GetButton (buttId)).zobject).SetShowStyle ((int)ZobjectShowStyle.kZobjectShow_Immediate);
			((theScreen.GetButton (buttId)).zobject).SetHideStyle ((int)ZobjectHideStyle.kZobjectHide_DontHide);
			if (Globals.deviceIPad) {
				((theScreen.GetButton (buttId)).zobject).SetShowScale ((768.0f / 640.0f));
			}

			float kWordScale = 0.66f;
			string inString = "";
			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
				inString = "Achtung!\n";
			} else {
				inString = "Watch Out!\n";
			}

			CGPoint wordPos = Utilities.CGPointMake (173.0f, 51.0f);
			int fwId = -1;
			fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8P9 (
				theScreen,
				(int)StringId.kString_WatchOut,
				Globals.g_world.font,
				Globals.g_world.GetAtlas (AtlasType.kAtlas_FontLines
			),
				Globals.g_world.GetAtlas (AtlasType.kAtlas_FontColours),
				wordPos,
				kWordScale,
				inString,
				true,
				Constants.kColourRedTip
			);
			(theScreen.GetFunnyWord (fwId)).SetShowStyle (FunnyWordShowStyle.kFunnyWordShow_Immediate);
			(theScreen.GetFunnyWord (fwId)).SetOrientationButton ((theScreen.GetButton (bigButt)).hangingButton);
			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
				kWordScale = 0.38f;
				inString = "Ein weiteres Schwein\n";
			} else {
				kWordScale = 0.48f;
				inString = "Another Pig has\n";
			}

			wordPos = Utilities.CGPointMake (160.0f, 200.0f);
			fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8P9 (
				theScreen,
				(int)StringId.kString_AnotherPig,
				Globals.g_world.font,
				Globals.g_world.GetAtlas (AtlasType.
              kAtlas_FontLines
			),
				Globals.g_world.GetAtlas (AtlasType.kAtlas_FontColours),
				wordPos,
				kWordScale,
				inString,
				true,
				Constants.kColourRedText
			);
			(theScreen.GetFunnyWord (fwId)).SetShowStyle (FunnyWordShowStyle.kFunnyWordShow_Immediate);
			(theScreen.GetFunnyWord (fwId)).SetOrientationButton ((theScreen.GetButton (bigButt)).hangingButton);
			if (Globals.g_currentLanguage == World.Enum11.kLanguage_German) {
				kWordScale = 0.36f;
				inString = "nimmt am Rennen teil!\n";
			} else {
				inString = "joined the race!\n";
			}

			wordPos = Utilities.CGPointMake (160.0f, 224.0f);
			fwId = Globals.g_world.AddFunnyWordP1P2P3P4P5P6P7P8P9 (
				theScreen,
				(int)StringId.kString_JoinedRace,
				Globals.g_world.font,
				Globals.g_world.GetAtlas (AtlasType.
              kAtlas_FontLines
			),
				Globals.g_world.GetAtlas (AtlasType.kAtlas_FontColours),
				wordPos,
				kWordScale,
				inString,
				true,
				Constants.kColourRedText
			);
			(theScreen.GetFunnyWord (fwId)).SetShowStyle ( FunnyWordShowStyle.kFunnyWordShow_Immediate);
            (theScreen.GetFunnyWord(fwId)).SetOrientationButton((theScreen.GetButton(bigButt)).hangingButton);
        }

        public void Show ()
		{			
			if ((int)type == (int)AnotherPiggyType.kAP_RaceTip) {
			Globals.g_world.tileCam.enabled = true;
				debugScale = -1.0f;
				this.SetupTipScreen ();
				theScreen.ShowButtons ();
			} 
			else if ((int)type == (int)AnotherPiggyType.kAP_AnotherPiggy) 
			{
				((Globals.g_world.frontEnd).profile).SetAnotherPiggyScreenPending (false);
				((Globals.g_world.frontEnd).profile).SaveBestTimesAndPrefs ();
				this.SetupAnotherPiggyScreen ();
				theScreen.ShowButtons ();
				if (((Globals.g_world.frontEnd).profile).preferences.musicOn) {
					(SoundEngine.Instance()).AVChangeToTrackP1 ((int)Audio.Enum2.kSoundEffect_MudMusic, 0.5f);
				}

			}

			returnedTrueOnce = false;
			int scene = ((Globals.g_world.game).tileMap).currentScene;
			if (scene == -1)
				scene = 0;

			Globals.g_world.LoadSceneAtlases ();
			Globals.g_world.game.tileMap.SetStartFrontEnd();
			Globals.g_world.game.SetSpritesToTileCamera(true);
			
			for (int i = 0; i < (int)Enum.kAPMaxNumCommentLines; i++) {
				(commentLine [i]).SetFont (Globals.g_world.font);
				(commentLine [i]).SetColour (Constants.kColourLilac);
			}

			for (int i = 0; i < (int)Enum.kAPMaxNumCommentLines; i++) {
				(commentLine [i]).SetLineAtlas (Globals.g_world.GetAtlas (AtlasType.kAtlas_FontLines));
				(commentLine [i]).SetColourAtlas (Globals.g_world.GetAtlas (AtlasType.kAtlas_FontColours));
				(commentLine [i]).SetShowStyle ( FunnyWordShowStyle.kFunnyWordShow_Immediate);
            }
			
			
			this.SetTypeVariables ();
		//	if (whoIsSpeaking == (int)PlayerType.kPlayerPig)
		//		sheepPic.Show ();

			infoBubbleBackground.Show ();
			doneButton.Show ();
			(doneButton.zobject).QueueAction (ZobjectAction.nThrobLooping);
			for (int i = 0; i < numCommentLines; i++) {
                (commentLine[i]).Show();
            }

        }

        public void Hide()
        {
			for (int i = 0; i < (int)Enum.kAPMaxNumCommentLines; i++) {
				(commentLine [i]).StopRender();
			}
			doneButton.StopRender();
			theScreen.StopRender();
			((Globals.g_world.game).tileMap).StopRender();
			
			Scissor.DoGLScissor(Globals.g_world.tileCam, 0.0f, 0.0f, 320.0f, 480.0f);
        
			Globals.g_world.tileCam.enabled = false;
		}

        public bool Update()
        {
            shownTimer += Constants.kFrameRate;
            for (int i = 0; i < numCommentLines; i++) (commentLine[i]).Update();

            theScreen.Update();
            //sheepPic.Update();
            infoBubbleBackground.Update();
            doneButton.Update();
            if ((theScreen.lastPressedButton != -1) || ((int)type == (int) AnotherPiggyType.kAP_PreFeelGoodWords)) {
                if (!returnedTrueOnce) {
                    returnedTrueOnce = true;
                    return true;
                }

            }

            return false;
        }

        public void RenderHudImage ()
		{
			int selectedLevel = ((Globals.g_world.frontEnd).profile).selectedLevel;
			if ((int)type != (int)AnotherPiggyType.kAP_RaceTip)
				return;

			const float kBubbleRingStretch = 1.4f;
			float scale;
			CGPoint topLeft;
			CGPoint gridSize;
			CGPoint screenPosition;
			CGPoint screenOffset = Utilities.CGPointMake (0.0f, 0.0f);
			int levelRealId = LevelBuilder_Ross.levelOrder [selectedLevel];
			screenPosition = Utilities.CGPointMake (160.0f, 135.0f);
			if (Globals.deviceIPad) {
				screenPosition.x = 192.0f;
			}

			switch (levelRealId) {
			case (int)LevelBuilder_Ross.Enum2.kGrass_EasyOne:
				scale = 0.45f;
				topLeft = Utilities.CGPointMake (0, 48);
				gridSize = Utilities.CGPointMake (6, 6);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_2_MdwCup_Race2_MooMoo:
				scale = 0.3f;
				topLeft = Utilities.CGPointMake (-2, 31);
				gridSize = Utilities.CGPointMake (9, 6);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_5_OneRiverAndFlocks:
				scale = 0.4f;
				topLeft = Utilities.CGPointMake (-1, 20);
				gridSize = Utilities.CGPointMake (8, 20);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_4_MdwCup_Race4_ForestTrail:
				scale = 0.4f;
				topLeft = Utilities.CGPointMake (-1, 37);
				gridSize = Utilities.CGPointMake (8, 20);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass7_1_HedgesAndGnomes:
				scale = 0.5f;
				topLeft = Utilities.CGPointMake (-2, 16);
				gridSize = Utilities.CGPointMake (8, 18);
				screenOffset = Utilities.CGPointMake (0, -10);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass_DuckpondDance:
				scale = 0.55f;
				topLeft = Utilities.CGPointMake (0, 13);
				gridSize = Utilities.CGPointMake (4, 4);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass1_6_MdwCup_Race6_CattleRun:
				scale = 0.43f;
				topLeft = Utilities.CGPointMake (0, 6);
				gridSize = Utilities.CGPointMake (6, 14);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud2_7_MudCup_Race7_BarrelsOfFun:
				scale = 0.44f;
				topLeft = Utilities.CGPointMake (0, 50);
				gridSize = Utilities.CGPointMake (6, 10);
				screenOffset = Utilities.CGPointMake (18.0f, 0.0f);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass4_1_CntCup_Race1_CurlyWurly:
				scale = 0.4f;
				topLeft = Utilities.CGPointMake (-5, 50);
				gridSize = Utilities.CGPointMake (16, 20);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass4_7_CntCup_Race7_RP:
				scale = 0.46f;
				topLeft = Utilities.CGPointMake (-1, 6);
				gridSize = Utilities.CGPointMake (7, 9);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud3_4_PenCup_Race4_Huddles:
				scale = 0.38f;
				topLeft = Utilities.CGPointMake (0, 12);
				gridSize = Utilities.CGPointMake (8, 9);
				screenOffset = Utilities.CGPointMake (15.0f, 0.0f);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud3_2_PenCup_Race2_IglooVillage:
				scale = 0.4f;
				topLeft = Utilities.CGPointMake (-1, 72);
				gridSize = Utilities.CGPointMake (8, 9);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud5_5_FrmCup_Race5_TheBarnyard:
				scale = 0.33f;
				topLeft = Utilities.CGPointMake (-10, 19);
				gridSize = Utilities.CGPointMake (26, 25);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud5_7_FrmCup_Race7_HumptyJumpty:
				scale = 0.41f;
				topLeft = Utilities.CGPointMake (-10, 108);
				gridSize = Utilities.CGPointMake (26, 25);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass6_1_StrCup_Race1_PiggyMeadow:
				scale = 0.38f;
				topLeft = Utilities.CGPointMake (-10, 85);
				gridSize = Utilities.CGPointMake (26, 25);
				break;
			case (int)LevelBuilder_Ross.Enum2.kGrass6_8_StrCup_Race8_Hogzwallop:
				scale = 0.35f;
				topLeft = Utilities.CGPointMake (-10, 10);
				gridSize = Utilities.CGPointMake (26, 25);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud2_1_VegDodge:
				scale = 1.0f;
				topLeft = Utilities.CGPointMake (0, 23);
				gridSize = Utilities.CGPointMake (4, 6);
				screenOffset = Utilities.CGPointMake (-10.0f, 0.0f);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud7_3_MudTulips:
				scale = 0.35f;
				topLeft = Utilities.CGPointMake (-2, 19);
				gridSize = Utilities.CGPointMake (9, 20);
				screenOffset = Utilities.CGPointMake (-10.0f, -30.0f);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud_DayDreamFlowers:
				scale = 0.4f;
				topLeft = Utilities.CGPointMake (-3, 64);
				gridSize = Utilities.CGPointMake (10, 20);
				screenOffset = Utilities.CGPointMake (-20.0f, -55.0f);
				break;
			case (int)LevelBuilder_Ross.Enum2.kMud8_3_VegLines :
                scale = 0.4f;
                topLeft = Utilities.CGPointMake(-3, 49);
                gridSize = Utilities.CGPointMake(10, 20);
                screenOffset = Utilities.CGPointMake(-20.0f, -55.0f);
                break;
            case 209 :
                scale = 0.3f;
                topLeft = Utilities.CGPointMake(-11, 94);
                gridSize = Utilities.CGPointMake(26, 25);
                screenOffset = Utilities.CGPointMake(-12.0f, 1.0f);
                break;
            default :
                scale = 0.35f;
                topLeft = Utilities.CGPointMake(-10, 10);
                gridSize = Utilities.CGPointMake(26, 25);
                break;
            }

            if (debugScale == -1.0f) {
                debugScale = scale;
                debugTopLeft = topLeft;
                debugGridSize = gridSize;
                debugOffset = screenOffset;
            }

            scale = debugScale;
            topLeft = debugTopLeft;
            gridSize = debugGridSize;
            screenOffset = debugOffset;
            screenPosition.x += screenOffset.x;
            screenPosition.y += screenOffset.y;
            float onScreenWidthHalf = (128.0f * kBubbleRingStretch) * 0.5f;
            onScreenWidthHalf -= 20.0f;
            /*//glEnable (GL_SCISSOR_TEST);
            if (Globals.deviceIPad) {
                //glScissor(180, 650, 444, 195);
            }
            else {
                if ( Globals.useRetina)//(UIScreen.MainScreen()).RespondsToSelector(@selector (scale)) == true && (UIScreen.MainScreen()).scale == 2.00) {
                    //glScissor(132, 610, 370, 168);
                }
                else {
                    //glScissor(80, 300, 170, 100);
                }

            }*/
			
			Scissor.DoGLScissor(Globals.g_world.tileCam, 80, 300, 190, 100);
			
            ((Globals.g_world.game).tileMap).RenderTileArrayP1P2P3(topLeft, gridSize, scale, screenPosition);
            CGPoint topLeftPixels = Utilities.CGPointMake(topLeft.x * 64.0f, topLeft.y * 64.0f);
            CGPoint areaSize = Utilities.CGPointMake(gridSize.x * 64.0f, gridSize.y * 64.0f);
            (Globals.g_world.game).RenderMapObjectsInAreaP1P2P3(topLeftPixels, areaSize, scale, screenPosition);
         //   //glDisable (GL_SCISSOR_TEST);
        }

        public void Render ()
		{
			if ((int)type == (int) AnotherPiggyType.kAP_PreFeelGoodWords) {
                return;
            }

						theScreen.RenderBackScene_StretchToFit();
            this.RenderHudImage();
            //////glEnableClientState (GL_COLOR_ARRAY);
            theScreen.RenderFrontScene();
            if ((int)type != (int) AnotherPiggyType.kAP_AnotherPiggy) {
                for (int i = 0; i < numCommentLines; i++) (commentLine[i]).Render();

            }

            //////glDisableClientState (GL_COLOR_ARRAY);
        }

    }
}
