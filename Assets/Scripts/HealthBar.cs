using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerStats stats;
    public Slider healthBar;

    void Update()
    {
        healthBar.value = stats.health / 10;
    }
}
