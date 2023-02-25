using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private int highScore = 0;
    public LevelCounter counter;

    void Update()
    {
        if (counter.enemiesKilled > highScore)
        {
            highScore = counter.enemiesKilled;
            PlayerPrefs.SetInt("Highscore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore");
    }
}
