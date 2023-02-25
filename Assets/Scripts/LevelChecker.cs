using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelChecker : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public LevelCounter count;
    void Start()
    {
        count.enemiesKilled = 0;
    }
    void Update()
    {
        levelText.text = "Enemies Killed: " + count.enemiesKilled;
    }
}
