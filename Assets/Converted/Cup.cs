using System;

namespace Default.Namespace
{
    public class Cup
    {
        public Constants.RossColour menuBackColour;
        public Constants.RossColour menuRaysColour;
        public Constants.RossColour fontColour;
        public Constants.RossColour levelColour;
        public string name;
        public string achievementIdPassed;
        public string achievementId24apples;
        public int iconSet;
        public int lockedIconSet;
        public int stageIcon;
        public int[] levelId = new int[(int)Enum.kCupNumLevelsPerCup];
        public enum Enum {
            kCupNumLevelsPerCup = 8
        };
        public Constants.RossColour MenuBackColour
        {
            get;
            set;
        }

        public Constants.RossColour MenuRaysColour
        {
            get;
            set;
        }

        public int IconSet
        {
            get;
            set;
        }

        public int LockedIconSet
        {
            get;
            set;
        }

        public Constants.RossColour FontColour
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string AchievementIdPassed
        {
            get;
            set;
        }

        public string AchievementId24apples
        {
            get;
            set;
        }

        public int StageIcon
        {
            get;
            set;
        }

        public Constants.RossColour LevelColour
        {
            get;
            set;
        }

public void SetLevelColour(Constants.RossColour inThing) {levelColour = inThing;}///@property(readwrite,assign) RossColour levelColour;
public void SetMenuBackColour(Constants.RossColour inThing) {menuBackColour = inThing;}///@property(readwrite,assign) RossColour menuBackColour;
public void SetMenuRaysColour(Constants.RossColour inThing) {menuRaysColour = inThing;}///@property(readwrite,assign) RossColour menuRaysColour;
public void SetIconSet(int inThing) {iconSet = inThing;}///@property(readwrite,assign) int iconSet;
public void SetLockedIconSet(int inThing) {lockedIconSet = inThing;}///@property(readwrite,assign) int lockedIconSet;
public void SetFontColour(Constants.RossColour inThing) {fontColour = inThing;}///@property(readwrite,assign) RossColour fontColour;
public void SetName(string inThing) {name = inThing;}////@property(readwrite,assign) NSString* name;	
public void SetAchievementIdPassed(string inThing) {achievementIdPassed = inThing;}////@property(readwrite,assign) NSString* achievementIdPassed;	
public void SetAchievementId24apples(string inThing) {achievementId24apples = inThing;}////@property(readwrite,assign) NSString* achievementId24apples;	
public void SetStageIcon(int inThing) {stageIcon = inThing;}///@property(readwrite,assign) int stageIcon;

        int GetLevelId(int inLevel)
        {
            Globals.Assert(inLevel < (int)Enum.kCupNumLevelsPerCup);
            return levelId[inLevel];
        }

        public void SetLevelIdArray(int inLevelIdArray)
        {
            for (int i = 0; i < (int)Enum.kCupNumLevelsPerCup; i++) {
                levelId[i] = (inLevelIdArray + i);
            }

        }

    }
}
