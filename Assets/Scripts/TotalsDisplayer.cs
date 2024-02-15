using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalsDisplayer : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text bestScore;
    [SerializeField] GameObject noHiScorePaner;
    [SerializeField] GameObject hiScorePaner;
    void Start()
    {
        var hiScore = ScoreData.HiScore; // кэширование для оптимизации числа вызовов GetValue в PlayerPrefs

        if(ScoreData.Score > hiScore)
        {
            hiScorePaner.SetActive(true);
            ScoreData.HiScore = ScoreData.Score;
            hiScore = ScoreData.Score;
        }
        else
        {
            noHiScorePaner.SetActive(true);
        }
        score.text = ScoreData.Score.ToString();
        bestScore.text = hiScore.ToString();
    }
}
