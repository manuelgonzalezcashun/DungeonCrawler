using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerStats stats;

    public void TakeDamage(float damage)
    {
        stats.health -= damage;
        Debug.Log("Player is taking damage. Current Health: " + stats.health);

        if (stats.health <= 0)
        {
            Debug.Log("Player died!");
            GameManagement.GetInstance().GameOver();
            gameObject.SetActive(false);
        }
    }
}
