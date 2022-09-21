using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs 
{
    public static bool hasNewBest;
    public static void SetBool(bool isTrue, string key)
    {
        if (isTrue)
        {
            PlayerPrefs.SetInt(key, 1);
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }
    public static bool Getbool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
    public static int bestScore
    {
        set
        {
            if (PlayerPrefs.GetInt(PresfConst.BEST_SCORE, 0) <value)
            {
                hasNewBest = true;
                PlayerPrefs.SetInt(PresfConst.BEST_SCORE, value);
            }
            else
            {
                hasNewBest = false;
            }
        }
        get => PlayerPrefs.GetInt(PresfConst.BEST_SCORE, 0);
    }
    public static bool isLevelUnlocked(int level)
    {
        return Getbool(PresfConst.LEVEL_UNLOCKED + level);
    }
    public static bool isLevelpassed(int level )
    {
        return Getbool(PresfConst.LEVEL_PASSED + level);
    }
    public static void SetLevelUnlocked(int level , bool unlocked)
    {
        SetBool(unlocked, PresfConst.LEVEL_UNLOCKED + level);
    }
    public static void SetLevelPassed(int level, bool unlocked)
    {
        SetBool(unlocked, PresfConst.LEVEL_PASSED + level);
    }
    public static bool IsgameEnter()
    {
        return Getbool(PresfConst.IS_GAME_ENTERED);
    }
    public static void SetGameEntered(bool isEntered)
    {
        SetBool(isEntered, PresfConst.IS_GAME_ENTERED);
    }
}
