using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreData
{
    public static Action OnScoreChanged;
    private static int _score = 0;
    public static int Score {
        get { 
            return _score; 
        }
        set{
            _score = value;
            if(OnScoreChanged != null) OnScoreChanged.Invoke();
        }
    }
    public static int HiScore
    {
        get
        {
            return PlayerPrefs.GetInt("HiScore",0);
        }
        set
        {
            PlayerPrefs.SetInt("HiScore", value);
        }
    }
}
