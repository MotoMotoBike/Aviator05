using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] PlanePlayer player;
    [SerializeField] GameObject[] healtsIndicators;
    void Start()
    {
        ScoreData.OnScoreChanged += UpdateScore;
        player.OnHealthChanged += UpdateHealth;
    }
    private void OnDestroy()
    {
        ScoreData.OnScoreChanged -= UpdateScore;
        player.OnHealthChanged -= UpdateHealth;
    }

    void UpdateScore()
    {
        scoreText.text = ScoreData.Score.ToString(); //TODO можно использовать DoTween для красивой анимации изменения значений
    }
    
    void UpdateHealth(int newHealthValue)
    {
        healtsIndicators.ToList().ForEach(indicator => indicator.SetActive(false));
        for (int i = 0; i < newHealthValue; i++)
        {
            healtsIndicators[i].SetActive(true);
        }
    }
    
}
