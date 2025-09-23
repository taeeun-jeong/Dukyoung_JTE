using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;

    [SerializeField] int increaseScore = 10;
    int currentScore = 0;
    [SerializeField] ComboManager theCombo;

    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 100;
    void Start()
    {
        currentScore = 0;
        scoreText.text = "SCORE : 0";
    }

    public void IncreaseScore(int p_judgementState)
    {
        theCombo.IncreaseCombo();

        int t_currentCombo = theCombo.GetCurrentCombo();
        int t_bonusScore = (t_currentCombo / 100) * comboBonusScore;

        int t_increaseScore = increaseScore + t_bonusScore;

        t_increaseScore = (int)(t_increaseScore * weight[p_judgementState]);

        currentScore += t_increaseScore;
        scoreText.text = string.Format("SCORE : {0}", currentScore);
    }
}
